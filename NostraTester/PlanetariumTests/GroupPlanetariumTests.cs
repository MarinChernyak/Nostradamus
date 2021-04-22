using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.PlanetariumTests
{
    public class GroupPlanetariumTests :GroupTestsBase
    {
        protected override void CreateGroup()
        {
            _testCollection.Add(new PlanetsTest1905());
            _testCollection.Add(new PlanetsTest1950());
            _testCollection.Add(new PlanetsTest2000());

        }
        protected override void SetGroupName()
        {
            _grouptestname = this.GetType().Name;
        }
    }
}
