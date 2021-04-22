using NostraDAL.NostraSrv;
using NostraDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.ServiceTests
{
    class PersonalRecordsTestBase :Test_Base
    {
        public override void GoTest()
        {
            //throw new NotImplementedException();
        }
        protected void CheckPersonalData(PersonalRecordBase prb)
        {
            if (prb.Additional_hours != 0) { SetErrorMessage("A test failed! Wrong Additional_hours."); }
            if (prb.Birth_Day != 19) { SetErrorMessage("A test failed! Wrong a birthday."); }
            if (prb.Birth_Hour_From != 0) { SetErrorMessage("A test failed! Wrong Birth_Hour_From."); }
            if (prb.Birth_Hour_To != 1) { SetErrorMessage("A test failed! Wrong Birth_Hour_From."); }
            if (prb.Birth_Min_From != 30) { SetErrorMessage("A test failed! Wrong Birth_Min_From."); }
            if (prb.Birth_Min_To != 30) { SetErrorMessage("A test failed! Wrong Birth_Min_To."); }
            if (prb.Birth_Month != 12) { SetErrorMessage("A test failed! Wrong Birth_Month."); }
            if (prb.Birth_Year != 1961) { SetErrorMessage("A test failed! Wrong Birth_Year."); }
            if (prb.BirthPlace.IDCity != 5) { SetErrorMessage("A test failed! Wrong BirthPlace."); }
            if (prb.BirthPlace.Latitude != 50.43) { SetErrorMessage("A test failed! Wrong Latitude."); }
            if (prb.BirthPlace.Longitude != 30.52) { SetErrorMessage("A test failed! Wrong Longitude."); }
            if (prb.BirthPlace.TimeDiff != 3) { SetErrorMessage("A test failed! Wrong TimeDiff."); }
            if (prb.BirthPlace.CityName != "Kiev") { SetErrorMessage("A test failed! Wrong CityName."); }
            if (prb.DataType != 3) { SetErrorMessage("A test failed! Wrong DataType."); }
            if (prb.First_Name != "Mary") { SetErrorMessage("A test failed! Wrong First_Name."); }
            if (prb.Second_Name != "Poppins") { SetErrorMessage("A test failed! Wrong Second_Name."); }
            if (prb.ID_contributor != 79) { SetErrorMessage("A test failed! Wrong ID_contributor."); }
            if (prb.Sex != 2) { SetErrorMessage("A test failed! Wrong Sex."); }

        }
    }
}
