using Nostradamus.AstroMaps;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models
{
    public class OrbsSystemSerializer : XMLSerializerBase
    {
        public OrbsCollectionData OrbsCollection { get; set; }
        public  OrbsSystemSerializer(string system)
        {
            if (string.IsNullOrEmpty(system))
            {
                InitDefaults();
            }
            else
            {
                _filename = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Models\\Data\\");
                _filename = $"{_filename}{system}.xml";
                OrbsCollection = new OrbsCollectionData();
                OrbsCollection.OrbsSystemName = system;
                GetData();
            }
        }
        public override void GetData()
        {
            XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));

            using (Stream reader = new FileStream(_filename, FileMode.Open))
            {
                try
                {
                    OrbsCollection = (OrbsCollectionData)ser.Deserialize(reader);
                }
                catch
                {

                }
            }
        }

        public override void Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(OrbsCollectionData));
                using (Stream fs = new FileStream(_filename, FileMode.Create))
                {
                    using (XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode))
                    {
                        ser.Serialize(writer, OrbsCollection);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        protected override void InitDefaults()
        {
            OrbsCollection = new OrbsCollectionData();
            OrbsCollection.OrbsSystemName = Constants.DefaultOrbsSystem;

            OrbsCollection.OrbsMap = new Dictionary<tAstroMapType, Dictionary<tPlanetType, Dictionary<AspectType, double>>>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL] = new Dictionary<tPlanetType, Dictionary<AspectType, double>>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_CONJUNCTION] = 9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_SEMISEXTILE] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_QUINCUNX] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_SEXTILE] = 5.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_QUADRO] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_TRINE] = 8;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_OPPOSITION] = 9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_QUINTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_BIQUINTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_OCTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_TRIOCTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_DECILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SUN][AspectType.AT_TRIDECILE] = 2;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_CONJUNCTION] = 9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_SEMISEXTILE] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_QUINCUNX] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_SEXTILE] = 5.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_QUADRO] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_TRINE] = 8;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_OPPOSITION] = 9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_QUINTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_BIQUINTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_OCTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_TRIOCTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_DECILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MOON][AspectType.AT_TRIDECILE] = 2;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_CONJUNCTION] = 7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_SEMISEXTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_QUINCUNX] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_SEXTILE] = 4.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_QUADRO] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_TRINE] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_OPPOSITION] = 7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_QUINTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_BIQUINTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_OCTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_TRIOCTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_DECILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_TRIDECILE] = 1.2;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_CONJUNCTION] = 7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_SEMISEXTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_QUINCUNX] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_SEXTILE] = 4.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_QUADRO] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_TRINE] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_OPPOSITION] = 7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_QUINTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_BIQUINTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_OCTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_TRIOCTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_DECILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_VENUS][AspectType.AT_TRIDECILE] = 1.2;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_CONJUNCTION] = 7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_SEMISEXTILE] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_QUINCUNX] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_SEXTILE] = 4.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_QUADRO] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_TRINE] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_OPPOSITION] = 7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_QUINTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_BIQUINTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_OCTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_TRIOCTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_DECILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_TRIDECILE] = 1.2;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_CONJUNCTION] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_SEMISEXTILE] = 1.5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_QUINCUNX] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_SEXTILE] = 3.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_QUADRO] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_TRINE] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_OPPOSITION] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_QUINTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_BIQUINTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_OCTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_TRIOCTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_DECILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_MARS][AspectType.AT_TRIDECILE] = 1.1;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_CONJUNCTION] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_SEMISEXTILE] = 1.5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_QUINCUNX] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_SEXTILE] = 3.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_QUADRO] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_TRINE] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_OPPOSITION] = 6;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_QUINTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_BIQUINTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_OCTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_TRIOCTILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_DECILE] = 1.1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_SATURN][AspectType.AT_TRIDECILE] = 1.1;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_CONJUNCTION] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_SEMISEXTILE] = 1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_QUINCUNX] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_SEXTILE] = 2.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_QUADRO] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_TRINE] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_OPPOSITION] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_QUINTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_BIQUINTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_OCTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_TRIOCTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_DECILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_URANUS][AspectType.AT_TRIDECILE] = 0.9;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_CONJUNCTION] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_SEMISEXTILE] = 1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_QUINCUNX] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_SEXTILE] = 2.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_QUADRO] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_TRINE] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_OPPOSITION] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_QUINTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_BIQUINTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_OCTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_TRIOCTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_DECILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_TRIDECILE] = 0.9;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_CONJUNCTION] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_SEMISEXTILE] = 1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_QUINCUNX] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_SEXTILE] = 2.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_QUADRO] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_TRINE] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_OPPOSITION] = 5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_QUINTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_BIQUINTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_OCTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_TRIOCTILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_DECILE] = 0.9;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_TRIDECILE] = 0.9;

            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM] = new Dictionary<AspectType, double>();
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_CONJUNCTION] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_SEXTILE] = 0.5;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_SEMISEXTILE] = 1;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_SEXTILE] = 1.2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_QUADRO] = 2;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_TRINE] = 3;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_OPPOSITION] = 4;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_QUINTILE] = 0.7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_BIQUINTILE] = 0.7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_OCTILE] = 0.7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_TRIOCTILE] = 0.7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_DECILE] = 0.7;
            OrbsCollection.OrbsMap[tAstroMapType.RADICAL][NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_TRIDECILE] = 0.7;
        }
    }
}
