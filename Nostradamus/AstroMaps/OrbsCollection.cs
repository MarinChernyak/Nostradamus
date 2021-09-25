using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class OrbsCollection
    {
        protected Dictionary<tPlanetType, Dictionary<AspectType, double>> _orbsMap;
        public OrbsCollection()
        {
            CreateDefaultCollection();
        }
        protected void CreateDefaultCollection()
        {
            _orbsMap = new Dictionary<tPlanetType, Dictionary<AspectType, double>>();
            _orbsMap[NPTypes.tPlanetType.PT_SUN] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_CONJUNCTION] = 9;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_SEMISEXTILE] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_QUINCUNX] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_SEXTILE] = 5.2;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_QUADRO] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_TRINE] = 8;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_OPPOSITION] = 9;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_QUINTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_BIQUINTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_OCTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_TRIOCTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_DECILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_SUN][AspectType.AT_TRIDECILE] = 2;

            _orbsMap[NPTypes.tPlanetType.PT_MOON] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_CONJUNCTION] = 9;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_SEMISEXTILE] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_QUINCUNX] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_SEXTILE] = 5.2;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_QUADRO] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_TRINE] = 8;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_OPPOSITION] = 9;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_QUINTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_BIQUINTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_OCTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_TRIOCTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_DECILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_MOON][AspectType.AT_TRIDECILE] = 2;

            _orbsMap[NPTypes.tPlanetType.PT_MERCURY] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_CONJUNCTION] = 7;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_SEMISEXTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_QUINCUNX] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_SEXTILE] = 4.2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_QUADRO] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_TRINE] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_OPPOSITION] = 7;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_QUINTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_BIQUINTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_OCTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_TRIOCTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_DECILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_MERCURY][AspectType.AT_TRIDECILE] = 1.2;

            _orbsMap[NPTypes.tPlanetType.PT_VENUS] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_CONJUNCTION] = 7;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_SEMISEXTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_QUINCUNX] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_SEXTILE] = 4.2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_QUADRO] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_TRINE] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_OPPOSITION] = 7;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_QUINTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_BIQUINTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_OCTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_TRIOCTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_DECILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_VENUS][AspectType.AT_TRIDECILE] = 1.2;

            _orbsMap[NPTypes.tPlanetType.PT_JUPITER] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_CONJUNCTION] = 7;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_SEMISEXTILE] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_QUINCUNX] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_SEXTILE] = 4.2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_QUADRO] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_TRINE] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_OPPOSITION] = 7;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_QUINTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_BIQUINTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_OCTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_TRIOCTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_DECILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_JUPITER][AspectType.AT_TRIDECILE] = 1.2;

            _orbsMap[NPTypes.tPlanetType.PT_MARS] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_CONJUNCTION] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_SEMISEXTILE] = 1.5;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_QUINCUNX] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_SEXTILE] = 3.2;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_QUADRO] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_TRINE] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_OPPOSITION] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_QUINTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_BIQUINTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_OCTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_TRIOCTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_DECILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_MARS][AspectType.AT_TRIDECILE] = 1.1;

            _orbsMap[NPTypes.tPlanetType.PT_SATURN] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_CONJUNCTION] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_SEMISEXTILE] = 1.5;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_QUINCUNX] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_SEXTILE] = 3.2;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_QUADRO] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_TRINE] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_OPPOSITION] = 6;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_QUINTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_BIQUINTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_OCTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_TRIOCTILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_DECILE] = 1.1;
            _orbsMap[NPTypes.tPlanetType.PT_SATURN][AspectType.AT_TRIDECILE] = 1.1;

            _orbsMap[NPTypes.tPlanetType.PT_URANUS] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_CONJUNCTION] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_SEMISEXTILE] = 1;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_QUINCUNX] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_SEXTILE] = 2.2;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_QUADRO] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_TRINE] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_OPPOSITION] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_QUINTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_BIQUINTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_OCTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_TRIOCTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_DECILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_URANUS][AspectType.AT_TRIDECILE] = 0.9;

            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_CONJUNCTION] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_SEMISEXTILE] = 1;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_QUINCUNX] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_SEXTILE] = 2.2;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_QUADRO] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_TRINE] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_OPPOSITION] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_QUINTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_BIQUINTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_OCTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_TRIOCTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_DECILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_NEPTUNE][AspectType.AT_TRIDECILE] = 0.9;

            _orbsMap[NPTypes.tPlanetType.PT_PLUTO] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_CONJUNCTION] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_SEMISEXTILE] = 1;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_QUINCUNX] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_SEXTILE] = 2.2;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_QUADRO] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_TRINE] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_OPPOSITION] = 5;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_QUINTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_BIQUINTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_OCTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_TRIOCTILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_DECILE] = 0.9;
            _orbsMap[NPTypes.tPlanetType.PT_PLUTO][AspectType.AT_TRIDECILE] = 0.9;

            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM] = new Dictionary<AspectType, double>();
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_CONJUNCTION] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_SEXTILE] = 0.5;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_SEMISEXTILE] = 1;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_SEXTILE] = 1.2;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_QUADRO] = 2;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_TRINE] = 3;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_OPPOSITION] = 4;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_QUINTILE] = 0.7;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_BIQUINTILE] = 0.7;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_OCTILE] = 0.7;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_TRIOCTILE] = 0.7;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_DECILE] = 0.7;
            _orbsMap[NPTypes.tPlanetType.PT_CUSTOM][AspectType.AT_TRIDECILE] = 0.7;

        }

        public double GetOrb(tPlanetType pt1,AspectType at)
        {
            double orb = 0;
            Dictionary<AspectType, double> amap = null;
            
            if(_orbsMap.ContainsKey(pt1))
                amap=_orbsMap[pt1];

            if(amap!=null && amap.ContainsKey(at))
            {
                orb = amap[at];
            }
            return orb;
        }
    }
}
