using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.PlanetariumTests
{
    public abstract class PlanetsTestBase : Test_Base
    {
        protected double [] _correctPosition;
        protected const int NUMBER_BODIES = 16;


        protected double _jd;
        public PlanetsTestBase()
        {
            _correctPosition = new double[NUMBER_BODIES];
            SetCorrectPositions();
           
        }
        protected void SetJulianDay(int Day, int Month, int Year)
        {
            JulianDay JD = new JulianDay(Day, Month, Year, 0, 0, 0, 0, 0);
            _jd = JD.JD;
        }
        protected abstract void SetCorrectPositions();

        protected void AnalyzeRezult(double lambda, NPTypes.tPlanetType type)
        {
            int index = (int)type; 
            double delta = lambda - _correctPosition[index];
            delta = delta < 0 ? delta * -1 : delta;
            double criterion = type == NPTypes.tPlanetType.PT_TRUE_NODE ? 0.01 : 0.005;
            if (delta > criterion)
            {
                SetErrorMessage(String.Format("Position of {0} is wrong, delta = {1}", type, delta));
            }
            else
            {
                SetInfoMessage(String.Format(" Position of {0} is correct", type));
            }
        }
        protected void TestPlanet(NPTypes.tPlanetType type)
        {
            SpaceObject so = null;
            if (type <= NPTypes.tPlanetType.PT_OSCU_APOG)
            {
                so = new BigPlanet(_jd, type);
            }
            else
            {
                so = new SmallPlanet(_jd, type);
            }
            if (so != null && so.Enable)
            {
                AnalyzeRezult(so.Lambda, type);
            }
            else
            {
                SetErrorMessage(String.Format("Test of the body {0} has failed!", type));
            }
        }
        protected void StartTestPlanets()
        {
            TestPlanet(NPTypes.tPlanetType.PT_SUN);
            TestPlanet(NPTypes.tPlanetType.PT_MOON);
            TestPlanet(NPTypes.tPlanetType.PT_MERCURY);
            TestPlanet(NPTypes.tPlanetType.PT_VENUS);
            TestPlanet(NPTypes.tPlanetType.PT_MARS);
            TestPlanet(NPTypes.tPlanetType.PT_JUPITER);
            TestPlanet(NPTypes.tPlanetType.PT_SATURN);
            TestPlanet(NPTypes.tPlanetType.PT_URANUS);
            TestPlanet(NPTypes.tPlanetType.PT_NEPTUNE);
            TestPlanet(NPTypes.tPlanetType.PT_PLUTO);
            //TestPlanet(NPTypes.tPlanetType.PT_CHIRON);
            TestPlanet(NPTypes.tPlanetType.PT_TRUE_NODE);
            TestPlanet(NPTypes.tPlanetType.PT_MEAN_NODE);
        }
    }
}
