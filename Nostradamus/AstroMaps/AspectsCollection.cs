using Nostradamus.Models.DataFactories;
using Nostradamus.Models.DataProcessors;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public enum AspectType
    {
        AT_NONE=-1,
        AT_CONJUNCTION=0,
        AT_SEMISEXTILE=30,
        AT_DECILE=36,
        AT_OCTILE=45,
        AT_SEXTILE=60,
        AT_QUINTILE=72,
        AT_QUADRO = 90,
        AT_TRIDECILE=108,
        AT_TRINE=120,
        AT_TRIOCTILE=135,
        AT_BIQUINTILE=144,
        AT_QUINCUNX=150,
        AT_OPPOSITION=180
    }
    public class AspectData
    {
        public decimal Angle { get; }
        public string Name { get; }
        public string Acronym { get; }
        public AspectType Type { get; set; }
        public int R;
        public int G;
        public int B;
        public float Width;
        public DashStyle DStyle;
        public AspectData(AspectType type, decimal angle, string name, string acr, int r, int g, int b, float w= 1.5F, DashStyle dstyle= DashStyle.Solid)
        {
            Angle = angle;
            Name = name;
            Acronym = acr;            
            Type = type;
            R = r;
            G = g;
            B = b;
            Width = w;
            DStyle = dstyle;
        }
        public Pen GetPen()
        {
            Pen p =  new Pen(Color.FromArgb(R, G, B), Width);
            p.DashStyle = DStyle;
            return p;
        }
    }
    public class AspectsMap
    {
        public List<AspectData> _AspectsDataCollection { get; protected set; }
        public AspectsMap()
        {
            CreateAspectsMap();
        }
        protected void CreateAspectsMap()
        {
            AspectsMapFactory fact = new AspectsMapFactory();
            _AspectsDataCollection = fact.Data;
        }
    }
    public class AspectsCollection : AspectsMap
    {
        protected tAstroMapType AstroMapType { get; set; }
        protected OrbsCollectionDataProcessor _ocdp;

        public List<Aspect> Aspects { get { return _aspects; } }
        protected List<Aspect> _aspects;

        public AspectsCollection(List<SpaceObjectData> lstSO)
        {
            UserPreferncesDataFactory _upfact = new UserPreferncesDataFactory();
            _ocdp = new OrbsCollectionDataProcessor(_upfact.Data.OrbsSystemName);
            CreateAspectsCollection(lstSO);
        }

        protected void InitRedBuletsStatic(List<SpaceObjectData> lstSO1)
        {
            foreach(SpaceObjectData sod in lstSO1)
            {
                sod.IsRed = false;
            }
        }
        public void CreateAspectsCollection(List<SpaceObjectData> lstSO1)
        {
            InitRedBuletsStatic(lstSO1);
            _aspects = new List<Aspect>();
            for (int i = 0; i < lstSO1.Count; ++i)
            {
                SpaceObject so1 = lstSO1[i]._so;
                for (int j = i+1; j < lstSO1.Count; ++j)
                {
                    SpaceObject so2 = lstSO1[j]._so;
                    double dLambda = Math.Abs(so1.Lambda - so2.Lambda);
                    if (dLambda > 180)
                    {
                        dLambda =  360-dLambda;
                    }

                     AspectType at = GetAspectType(dLambda, so1.PlanetType, so2.PlanetType);
                    if (at == AspectType.AT_CONJUNCTION)
                    {
                        lstSO1[i].IsRed = lstSO1[j].IsRed = true;
                    }

                    if (at!= AspectType.AT_NONE)
                    {
                        _aspects.Add(new Aspect()
                        {
                            Angle = Math.Abs(dLambda),
                            PlanetType1 = so1.PlanetType,
                            PlanetType2 = so2.PlanetType,
                            _aspect_data = (AspectData)_AspectsDataCollection.Where(x => x.Angle == ((decimal)at)).FirstOrDefault()
                        }); 
                    }
                   
                }
            }
        }
        protected AspectType GetAspectType(double angle, tPlanetType pt1, tPlanetType pt2)
        {
            AspectType at = AspectType.AT_NONE;
            
            double remainder = 0;
            at = GetAspectDataByvalue(30, angle, out remainder);
            double o1 = _ocdp.GetOrb(AstroMapType, pt1, at);
            double o2 = _ocdp.GetOrb(AstroMapType, pt2, at);
            double o = Math.Max(o1, o2);
            if(o< remainder)
                at = AspectType.AT_NONE;

            return at;
        }
        protected AspectType GetAspectDataByvalue(int Devider, double angle, out double remainder)
        {
            
            remainder = 0;
            AspectType at = AspectType.AT_NONE;
            int aspect = ((int)(angle / Devider)) * Devider;
            remainder = angle % Devider;
            double rem2 = 0;
            if(remainder> Devider/2)
            {
                int a2 = aspect+Devider;
                rem2 = a2 - Math.Abs(angle);
                if(Math.Abs(rem2)<remainder)
                {
                    aspect = a2;
                    remainder = rem2;
                }
            }


            at = (AspectType)aspect;

            return at;
        }
    }
}
