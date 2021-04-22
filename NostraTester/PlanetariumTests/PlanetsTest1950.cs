using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.PlanetariumTests
{
    public class PlanetsTest1950: PlanetsTestBase
    {
        public PlanetsTest1950()
        {
            testName = this.GetType().Name;
        }
        public override void GoTest()
        {
            SetJulianDay(1, 8, 1950);
            StartTestPlanets();
        }

        protected override void SetCorrectPositions()
        {
            _correctPosition[(int)NPTypes.tPlanetType.PT_SUN] = 128.1811111;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MOON] = 343.5333333;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MERCURY] = 148.2066667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_VENUS] = 101.1133333;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MARS] = 204.2983333;
            _correctPosition[(int)NPTypes.tPlanetType.PT_JUPITER] = 335.5616667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_SATURN] = 167.2083333;
            _correctPosition[(int)NPTypes.tPlanetType.PT_URANUS] = 97.195;
            _correctPosition[(int)NPTypes.tPlanetType.PT_NEPTUNE] = 194.9116667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_PLUTO] = 137.5166667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MEAN_NODE] = 0.886666667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_TRUE_NODE] = 359.4416667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_CHIRON] = 256.0;

        }
    }
}
