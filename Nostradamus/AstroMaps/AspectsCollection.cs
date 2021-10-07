using Nostradamus.Models;
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
        public Pen PenToDraw { get; }
        public AspectType Type { get; set; }
        public AspectData(AspectType type, decimal angle, string name, string acr, Pen pen)
        {
            Angle = angle;
            Name = name;
            Acronym = acr;
            PenToDraw = pen;
            Type = type;
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
            AspectType value = AspectType.AT_CONJUNCTION;

            _AspectsDataCollection = new List<AspectData>();
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_CONJUNCTION, (int)value, "Conjunction", "con", null));

            value = AspectType.AT_SEMISEXTILE;
            Pen pen = new Pen(Color.FromArgb(232, 102, 79), 1.5F);
            pen.DashStyle = DashStyle.Dash;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_SEMISEXTILE,(int)value, "Semi-sextile", "ssxt", pen));

            value = AspectType.AT_SEXTILE;
            pen = new Pen(Color.FromArgb(38, 34, 213), 1.5F);
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_SEXTILE, (int)value, "Sextile", "sxt", pen));

            value = AspectType.AT_QUADRO;
            pen = new Pen(Color.FromArgb(255, 40, 40), 1.5F);
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_QUADRO, (int)value, "Quadro", "qdr", pen));

            value = AspectType.AT_TRINE;
            pen = new Pen(Color.FromArgb(0, 0, 255), 1.5F);
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_TRINE, (int)value, "Trin", "trn", pen));

            value = AspectType.AT_QUINCUNX;
            pen = new Pen(Color.FromArgb(187, 49, 206), 1.5F);
            pen.DashStyle = DashStyle.Dash;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_QUINCUNX, (int)value, "Quincunx", "qcx", pen));

            value = AspectType.AT_OPPOSITION;
            pen = new Pen(Color.FromArgb(208, 34, 51), 1.5F);
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_OPPOSITION,(int)value, "Opposition", "opp", pen));

            //======= Minor ====
            //72
            value = AspectType.AT_QUINTILE;
            pen = new Pen(Color.FromArgb(132, 184, 92), 1.5F);
            pen.DashStyle = DashStyle.DashDot;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_QUINTILE,(int)value, "Quintile", "qtl", pen));
            //144
            value = AspectType.AT_BIQUINTILE;
            pen = new Pen(Color.FromArgb(95, 140, 62), 1.5F);
            pen.DashStyle = DashStyle.DashDot;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_BIQUINTILE,(int)value, "Biquintile", "qtl", pen));
            //45
            value = AspectType.AT_OCTILE;
            pen = new Pen(Color.FromArgb(189, 132, 53), 1.5F);
            pen.DashStyle = DashStyle.DashDotDot;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_OCTILE,(int)value, "Octile", "oct", pen));
            //135
            value = AspectType.AT_TRIOCTILE;
            pen = new Pen(Color.FromArgb(151, 105, 43), 1.5F);
            pen.DashStyle = DashStyle.DashDotDot;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_TRIOCTILE,(int)value, "Trioctile", "tct", pen));
            //36
            value = AspectType.AT_DECILE;
            pen = new Pen(Color.FromArgb(181, 84, 245), 1.5F);
            pen.DashStyle = DashStyle.DashDotDot;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_DECILE, (int)value, "Decile", "dcl", pen));
            //108
            value = AspectType.AT_TRIDECILE;
            pen = new Pen(Color.FromArgb(149, 13, 240), 1.5F);
            pen.DashStyle = DashStyle.DashDotDot;
            _AspectsDataCollection.Add(new AspectData(AspectType.AT_TRIDECILE, (int)value, "Tridecile", "tdc", pen));

        }
    }
    public class AspectsCollection : AspectsMap
    {
        protected tAstroMapType AstroMapType { get; }

        
        public List<Aspect> Aspects { get { return _aspects; } }
        protected List<Aspect> _aspects;

        protected OrbsCollection _orbs;

        public AspectsCollection(List<SpaceObjectData> lstSO, tAstroMapType amt = tAstroMapType.NATAL)
        {
            UserPreferenses up = new UserPreferenses();
            string orbssys = Constants.DefaultOrbsSystem;
            AstroMapType = amt;
            if (up != null && up.OrbsSystem != null)
                _orbs = new OrbsCollection(up.OrbsSystem);
            else
                _orbs = new OrbsCollection(orbssys);
            
            CreateAspectsCollection(lstSO);
        }
        

        public void CreateAspectsCollection(List<SpaceObjectData> lstSO)
        {
            for (int i = 0; i < lstSO.Count; ++i)
            {
                SpaceObject so1 = lstSO[i]._so;
                for (int j = i+1; j < lstSO.Count; ++j)
                {
                    SpaceObject so2 = lstSO[j]._so;
                    double dLambda = Math.Abs(so1.Lambda - so2.Lambda);
                    if (dLambda > 180)
                    {
                        dLambda =  360-dLambda;
                    }

                     AspectType at = GetAspectType(dLambda, so1.PlanetType, so2.PlanetType);
                    if (at == AspectType.AT_CONJUNCTION)
                    {
                        lstSO[j].IsRed = lstSO[i].IsRed = true;
                    }
                    if (at!= AspectType.AT_NONE)
                    {
                        _aspects.Add(new Aspect()
                        {
                            Angle = Math.Abs(dLambda),
                            PlanetType1 = so1.PlanetType,
                            PlanetType2 = so2.PlanetType,
                            _aspect_data = (AspectData)_AspectsDataCollection.Where(x => x.Angle == ((decimal)at)).FirstOrDefault()
                        }); ;
                    }
                   
                }
            }
        }
        protected AspectType GetAspectType(double angle, tPlanetType pt1, tPlanetType pt2)
        {
            AspectType at = AspectType.AT_NONE;
            double remainder = 0;
            at = GetAspectDataByvalue(30, angle, out remainder);
            double o1 = _orbs.GetOrb(AstroMapType, pt1, at);
            double o2 = _orbs.GetOrb(AstroMapType, pt2, at);
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
