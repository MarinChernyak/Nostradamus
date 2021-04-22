using NostraTester.PlanetariumTests;
using NostraTester.ServiceTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NostraTester
{
    class NTesterEngine
    {
        protected static string separator;
        public static String StartTest()
        {
            separator = Constants.GetSeparator("=");
            StringBuilder txt = new StringBuilder();
            bool bPassedOK = true;
            List<GroupTestsBase> _groupsCollection = new List<GroupTestsBase>();
            _groupsCollection.Add(new GroupServiceTests());
            _groupsCollection.Add(new GroupPlanetariumTests());

            foreach (GroupTestsBase gtb in _groupsCollection)
            {
                 gtb.StartGroupTests();
                 txt.AppendLine(gtb.Result);
                if (!gtb.Passed)
                    bPassedOK = false;

                if (!bPassedOK && gtb.Interapted)
                {
                    bPassedOK = false;
                    break;
                }
            }
            txt.AppendLine(separator);
            if (bPassedOK)
                txt.AppendLine(  "All Tests passed sucessfully!");
            else
                txt.AppendLine("One or more Tests have FAILED!" );

            txt.AppendLine(separator);
            return txt.ToString();
            
        }
    }
}
