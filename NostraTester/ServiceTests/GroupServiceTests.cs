using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.ServiceTests
{
    public class GroupServiceTests :GroupTestsBase
    {
        public GroupServiceTests()
        {
            
        }
        protected override void CreateGroup()
        {
            _testCollection.Add(new GetCompletePersonalDataById_NormalTest());
            _testCollection.Add(new GetDisplayPersonalDataById_NormalTest());

        }
        protected override void SetGroupName()
        {
            _grouptestname = this.GetType().Name;
        }
    }
}
