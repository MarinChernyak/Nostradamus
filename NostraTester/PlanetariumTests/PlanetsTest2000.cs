using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.PlanetariumTests
{
    public class PlanetsTest2000: PlanetsTestBase
    {
        public PlanetsTest2000()
        {
            testName = this.GetType().Name;
        }
        public override void GoTest()
        {
            SetJulianDay(1, 8, 2000);
            StartTestPlanets();
        }

        protected override void SetCorrectPositions()
        {
            _correctPosition[(int)NPTypes.tPlanetType.PT_SUN] = 129.0525;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MOON] = 141.6813889;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MERCURY] = 110.195;
            _correctPosition[(int)NPTypes.tPlanetType.PT_VENUS] = 142.9516667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MARS] = 119.9633333;
            _correctPosition[(int)NPTypes.tPlanetType.PT_JUPITER] = 65.945;
            _correctPosition[(int)NPTypes.tPlanetType.PT_SATURN] = 59.42;
            _correctPosition[(int)NPTypes.tPlanetType.PT_URANUS] = 319.2516667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_NEPTUNE] = 305.0683333;
            _correctPosition[(int)NPTypes.tPlanetType.PT_PLUTO] = 250.2566667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MEAN_NODE] = 113.7866667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_TRUE_NODE] = 114.61;
            _correctPosition[(int)NPTypes.tPlanetType.PT_CHIRON] = 251.1316667;

        }
    }
}
