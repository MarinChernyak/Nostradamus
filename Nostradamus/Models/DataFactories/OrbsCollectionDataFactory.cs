using Nostradamus.AstroMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models.DataFactories
{
    
    public class OrbsCollectionDataFactory
    {
        protected OrbsCollectionDataSerializer _serializer;
        public OrbsCollectionData Data { get; set; }
        private string _system { get; set; }
        public OrbsCollectionDataFactory(string system)
        {
            _system = system;
            CreateSerializer();
            GetData();
        }
        protected void CreateDefaultData()
        {
            Data = new OrbsCollectionData()
            {
                OrbsSystemName = _system,
                OrbsMapCollection = new List<OrbsMapCollection>()
            };
            for (int imap = (int)tAstroMapType.NATAL; imap < (int)tAstroMapType.NUMBER_DYNAMIC_TYPES; imap++)
            {
                Data.OrbsMapCollection.Add(
                    new OrbsMapCollection()
                    {
                        MapType = (tAstroMapType)imap,
                        PlanetsAspectsOrbsCollection = new List<PlanetsAspectsOrbsPairsCollection>()

                    }
                 );
                for (int pt = (int)tPlanetType.PT_SUN; pt <= (int)tPlanetType.PT_PLUTO; ++pt)
                {
                    PlanetsAspectsOrbsPairsCollection poc = new PlanetsAspectsOrbsPairsCollection()
                    {
                        PlanetType = (tPlanetType)pt,
                        AspectOrbsCollection = new List<AspectOrbsPair>()
                    };
                    for (int iasp = 0; iasp < Constants._aspects.Count; ++iasp)
                    {
                        AspectType at = Utilities.FromStringToEnumType<AspectType>(Constants._aspects[iasp], "AT_");
                        poc.AspectOrbsCollection.Add(
                            new AspectOrbsPair()
                            {
                                AspectType = at,
                                OrbValue = 1
                            }
                            );
                    }
                    Data.OrbsMapCollection[0].PlanetsAspectsOrbsCollection.Add(poc);
                }
            }
            InitDefaults();


        }
        protected void GetData()
        {
            //_serializer.GetData();
            Data = (OrbsCollectionData)_serializer.Data;
            if (Data == null)
            {
                CreateDefaultData();
            }
        }
        protected void CreateSerializer()
        {
            _serializer = new OrbsCollectionDataSerializer(_system);
        }
        public void SetOrb(tAstroMapType amt, tPlanetType pt1, AspectType at, double value)
        {
            OrbsMapCollection omc = null;
            omc = Data.OrbsMapCollection.Where(x => x.MapType == amt).FirstOrDefault();

            PlanetsAspectsOrbsPairsCollection paoc = omc.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == pt1).FirstOrDefault();
            if (paoc != null)
            {
                AspectOrbsPair aop = paoc.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
                aop.OrbValue = value;
            }

        }
        protected void InitDefaults()
        {

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

            //Data = oc.
        }

        public void SetData()
        {
            _serializer.Data = Data;
            _serializer.Save();
        }
        public void SetData(OrbsCollectionData data)
        {
            _serializer.Data = data;
            _serializer.Save();
        }
    }
}
