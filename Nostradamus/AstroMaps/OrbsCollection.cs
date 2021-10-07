using Nostradamus.Models;
using Nostradamus.Models.XMLSerializers;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class OrbsCollectionData
    {
        public string OrbsSystemName { get; set; }
        public List<OrbsMapCollection> OrbsMapCollection { get; set; }
    }


    public class OrbsCollection
    {
        public OrbsCollectionData _data { get; set; }
        public OrbsCollection(string SystemName=Constants.DefaultOrbsSystem)
        {
            OrbsSystemSerializer orbs = new OrbsSystemSerializer(SystemName);
            _data = orbs.OrbsCollection;
            if(_data==null ||_data.OrbsMapCollection==null || _data.OrbsMapCollection.Count==0 )
            {
                InitDefaults();
            }
        }
        public OrbsCollection()
        {
            _data = new OrbsCollectionData();
        }
        public double GetOrb(tAstroMapType amt, tPlanetType pt1,AspectType at)
        {
            double orb = 0;
            //Dictionary<AspectType, double> amap = null;
            OrbsMapCollection omc = _data.OrbsMapCollection.Where(x => x.MapType == amt).FirstOrDefault();
            if (omc != null)
            {
                PlanetsAspectsOrbsPairsCollection paoc = omc.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == pt1).FirstOrDefault();
                if (paoc != null)
                {
                    AspectOrbsPair aop = paoc.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
                    if(aop!=null)
                    {
                        orb = aop.OrbValue;
                    }
                }
            }           

            //if(_data.OrbsMap[amt].ContainsKey(pt1))
            //    amap=_data.OrbsMap[amt][pt1];

            //if(amap!=null && amap.ContainsKey(at))
            //{
            //    orb = amap[at];
            //}
            return orb;
        }
        public void SetOrb(tAstroMapType amt, tPlanetType pt1, AspectType at, double value)
        {
            OrbsMapCollection omc = null;
            if (_data.OrbsMapCollection == null)
            {
                _data.OrbsMapCollection = new List<OrbsMapCollection>();
            }
            
            omc = _data.OrbsMapCollection.Where(x => x.MapType == amt).FirstOrDefault();
            
            if (omc == null)
            {
                omc = new OrbsMapCollection()
                {
                    MapType = amt,
                    PlanetsAspectsOrbsCollection = new List<PlanetsAspectsOrbsPairsCollection>()
                };
                _data.OrbsMapCollection.Add(omc);
            }

            PlanetsAspectsOrbsPairsCollection paoc = omc.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == pt1).FirstOrDefault();
            if (paoc == null)
            {
                paoc = new PlanetsAspectsOrbsPairsCollection()
                {
                    PlanetType = pt1,
                    AspectOrbsCollection = new List<AspectOrbsPair>()
                };
                omc.PlanetsAspectsOrbsCollection.Add(paoc);
            }
            AspectOrbsPair aop = paoc.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
            if (aop == null)
            {
                aop = new AspectOrbsPair()
                {
                    AspectType = at,
                    OrbValue = value
                };
                paoc.AspectOrbsCollection.Add(aop);
            }
            else
                aop.OrbValue = value;
            
        }
        protected void InitDefaults()
        {
            if(_data==null)
            {
                _data = new OrbsCollectionData();
                _data.OrbsSystemName = Constants.DefaultOrbsSystem;
                _data.OrbsMapCollection = new List<OrbsMapCollection>();
            }

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_CONJUNCTION, 9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_SEMISEXTILE, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_QUINCUNX, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_SEXTILE, 5.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_QUADRO, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_TRINE, 8);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_OPPOSITION, 9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_QUINTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_BIQUINTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_OCTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_TRIOCTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_DECILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SUN, AspectType.AT_TRIDECILE, 2);

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_CONJUNCTION, 9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_SEMISEXTILE, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_QUINCUNX, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_SEXTILE, 5.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_QUADRO, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_TRINE, 8);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_OPPOSITION, 9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_QUINTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_BIQUINTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_OCTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_TRIOCTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_DECILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MOON, AspectType.AT_TRIDECILE, 2);

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_CONJUNCTION, 7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_SEMISEXTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_QUINCUNX, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_SEXTILE, 4.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_QUADRO, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_TRINE, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_OPPOSITION, 7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_QUINTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_BIQUINTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_OCTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_TRIOCTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_DECILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MERCURY, AspectType.AT_TRIDECILE, 1.2);


            //OrbsCollection.OrbsMap[tAstroMapType.NATAL] = new XDictionary<tPlanetType, XDictionary<AspectType, double>>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_CONJUNCTION] = 9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_SEMISEXTILE] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_QUINCUNX] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_SEXTILE] = 5.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_QUADRO] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_TRINE] = 8;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_OPPOSITION] = 9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_QUINTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_BIQUINTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_OCTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_TRIOCTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_DECILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SUN][AspectType.AT_TRIDECILE] = 2;

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_CONJUNCTION] = 9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_SEMISEXTILE] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_QUINCUNX] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_SEXTILE] = 5.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_QUADRO] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_TRINE] = 8;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_OPPOSITION] = 9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_QUINTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_BIQUINTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_OCTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_TRIOCTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_DECILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MOON][AspectType.AT_TRIDECILE] = 2;

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_CONJUNCTION] = 7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_SEMISEXTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_QUINCUNX] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_SEXTILE] = 4.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_QUADRO] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_TRINE] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_OPPOSITION] = 7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_QUINTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_BIQUINTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_OCTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_TRIOCTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_DECILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MERCURY][AspectType.AT_TRIDECILE] = 1.2;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_CONJUNCTION, 7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_SEMISEXTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_QUINCUNX, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_SEXTILE, 4.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_QUADRO, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_TRINE, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_OPPOSITION, 7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_QUINTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_BIQUINTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_OCTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_TRIOCTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_DECILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_VENUS, AspectType.AT_TRIDECILE, 1.2);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_CONJUNCTION] = 7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_SEMISEXTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_QUINCUNX] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_SEXTILE] = 4.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_QUADRO] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_TRINE] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_OPPOSITION] = 7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_QUINTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_BIQUINTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_OCTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_TRIOCTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_DECILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_VENUS][AspectType.AT_TRIDECILE] = 1.2;

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_CONJUNCTION] = 7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_SEMISEXTILE] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_QUINCUNX] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_SEXTILE] = 4.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_QUADRO] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_TRINE] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_OPPOSITION] = 7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_QUINTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_BIQUINTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_OCTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_TRIOCTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_DECILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_JUPITER][AspectType.AT_TRIDECILE] = 1.2;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_CONJUNCTION, 7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_SEMISEXTILE, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_QUINCUNX, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_SEXTILE, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_QUADRO, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_TRINE, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_OPPOSITION, 7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_QUINTILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_BIQUINTILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_OCTILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_TRIOCTILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_DECILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_JUPITER, AspectType.AT_TRIDECILE, 1.5);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_CONJUNCTION] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_SEMISEXTILE] = 1.5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_QUINCUNX] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_SEXTILE] = 3.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_QUADRO] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_TRINE] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_OPPOSITION] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_QUINTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_BIQUINTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_OCTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_TRIOCTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_DECILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_MARS][AspectType.AT_TRIDECILE] = 1.1;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_CONJUNCTION, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_SEMISEXTILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_QUINCUNX, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_SEXTILE, 3.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_QUADRO, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_TRINE, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_OPPOSITION, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_QUINTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_BIQUINTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_OCTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_TRIOCTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_DECILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_MARS, AspectType.AT_TRIDECILE, 1.1);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_CONJUNCTION] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_SEMISEXTILE] = 1.5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_QUINCUNX] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_SEXTILE] = 3.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_QUADRO] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_TRINE] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_OPPOSITION] = 6;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_QUINTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_BIQUINTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_OCTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_TRIOCTILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_DECILE] = 1.1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_SATURN][AspectType.AT_TRIDECILE] = 1.1;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_CONJUNCTION, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_SEMISEXTILE, 1.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_QUINCUNX, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_SEXTILE, 3.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_QUADRO, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_TRINE, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_OPPOSITION, 6);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_QUINTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_BIQUINTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_OCTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_TRIOCTILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_DECILE, 1.1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_SATURN, AspectType.AT_TRIDECILE, 1.1);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_CONJUNCTION] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_SEMISEXTILE] = 1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_QUINCUNX] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_SEXTILE] = 2.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_QUADRO] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_TRINE] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_OPPOSITION] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_QUINTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_BIQUINTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_OCTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_TRIOCTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_DECILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_URANUS][AspectType.AT_TRIDECILE] = 0.9;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_CONJUNCTION, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_SEMISEXTILE, 1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_QUINCUNX, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_SEXTILE, 2.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_QUADRO, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_TRINE, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_OPPOSITION, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_QUINTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_BIQUINTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_OCTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_TRIOCTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_DECILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_URANUS, AspectType.AT_TRIDECILE, 0.9);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_CONJUNCTION] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_SEMISEXTILE] = 1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_QUINCUNX] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_SEXTILE] = 2.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_QUADRO] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_TRINE] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_OPPOSITION] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_QUINTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_BIQUINTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_OCTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_TRIOCTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_DECILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_NEPTUNE][AspectType.AT_TRIDECILE] = 0.9;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_CONJUNCTION, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_SEMISEXTILE, 1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_QUINCUNX, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_SEXTILE, 2.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_QUADRO, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_TRINE, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_OPPOSITION, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_QUINTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_BIQUINTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_OCTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_TRIOCTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_DECILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_NEPTUNE, AspectType.AT_TRIDECILE, 0.9);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_CONJUNCTION] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_SEMISEXTILE] = 1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_QUINCUNX] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_SEXTILE] = 2.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_QUADRO] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_TRINE] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_OPPOSITION] = 5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_QUINTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_BIQUINTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_OCTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_TRIOCTILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_DECILE] = 0.9;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_PLUTO][AspectType.AT_TRIDECILE] = 0.9;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_CONJUNCTION, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_SEMISEXTILE, 1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_QUINCUNX, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_SEXTILE, 2.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_QUADRO, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_TRINE, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_OPPOSITION, 5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_QUINTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_BIQUINTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_OCTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_TRIOCTILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_DECILE, 0.9);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_PLUTO, AspectType.AT_TRIDECILE, 0.9);

            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM] = new XDictionary<AspectType, double>();
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_CONJUNCTION] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_SEXTILE] = 0.5;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_SEMISEXTILE] = 1;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_SEXTILE] = 1.2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_QUADRO] = 2;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_TRINE] = 3;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_OPPOSITION] = 4;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_QUINTILE] = 0.7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_BIQUINTILE] = 0.7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_OCTILE] = 0.7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_TRIOCTILE] = 0.7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_DECILE] = 0.7;
            //OrbsCollection.OrbsMap[tAstroMapType.NATAL][tPlanetType.PT_CUSTOM][AspectType.AT_TRIDECILE] = 0.7;

            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_CONJUNCTION, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_SEMISEXTILE, 0.5);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_QUINCUNX, 1);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_SEXTILE, 1.2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_QUADRO, 2);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_TRINE, 3);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_OPPOSITION, 4);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_QUINTILE, 0.7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_BIQUINTILE, 0.7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_OCTILE, 0.7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_TRIOCTILE, 0.7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_DECILE, 0.7);
            SetOrb(tAstroMapType.NATAL, tPlanetType.PT_CUSTOM, AspectType.AT_TRIDECILE, 0.7);

            //_data = oc.
        }
    }
}
