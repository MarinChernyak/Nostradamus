using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NostraPlanetarium;

namespace NostraTester.PlanetariumTests
{
    public class PlanetsTest1905: PlanetsTestBase
    {
        
        public PlanetsTest1905()
        {
            testName = this.GetType().Name;
        }
        public override void GoTest()
        {
            SetJulianDay(1, 8, 1905);
            StartTestPlanets();
        }

        protected override void SetCorrectPositions()
        {
            _correctPosition[(int)NPTypes.tPlanetType.PT_SUN] = 128.056666667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MOON] = 125.8797222;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MERCURY] = 155.285;
            _correctPosition[(int)NPTypes.tPlanetType.PT_VENUS] = 84.18166667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MARS] = 229.5116667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_JUPITER] = 61.815;
            _correctPosition[(int)NPTypes.tPlanetType.PT_SATURN] = 331.1416667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_URANUS]=270.865;
            _correctPosition[(int)NPTypes.tPlanetType.PT_NEPTUNE] = 99.0216666;
            _correctPosition[(int)NPTypes.tPlanetType.PT_PLUTO] = 82.25166667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_MEAN_NODE] = 151.235;
            _correctPosition[(int)NPTypes.tPlanetType.PT_TRUE_NODE] = 150.2916667;
            _correctPosition[(int)NPTypes.tPlanetType.PT_CHIRON] = 304.2916667;




        }

    }
}
