using NostraDAL;
using NostraDataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester.ServiceTests
{
    class GetDisplayPersonalDataById_NormalTest : PersonalRecordsTestBase
    {
        public GetDisplayPersonalDataById_NormalTest()
        {
            testName = this.GetType().Name;
        }
        public override void GoTest()
        {

            DAL_Exctract de = new DAL_Exctract();
            DisplayPersonalRecord pr = de.GetDisplayPersonalDataById(Constants.TestPersonID);
            if (pr == null)
            {
                SetErrorMessage("Test failed! PersonalRecord got empty, there probably was not provided correct personal Id");
            }
            else
            {
                CheckPersonalData(pr);

                if (!pr.IsAvailable) SetErrorMessage("Test failed! IsAvailable = false");
                if (pr.SourceBirthTime != Constants.CorrectTimeSource) SetErrorMessage("Test failed! Wrong sa source birth time");
                if (pr.SexDescription != Constants.CorrectSex_Description) SetErrorMessage("Test failed! Wrong sex description.");
                if (pr.NumEvents != Constants.CorrectNumberEvents) SetErrorMessage("Test failed! Wrong number of events.");
                if (pr.NumKW != Constants.CorrectNumberKW) SetErrorMessage("Test failed! Wrong number of keywords.");
                if (pr.NumPictures != Constants.CorrectNumberPictures) SetErrorMessage("Test failed! Wrong number of pictures.");
            }

        }
    }
}
