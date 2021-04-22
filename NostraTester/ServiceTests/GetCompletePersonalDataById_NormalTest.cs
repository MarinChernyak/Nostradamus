using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NostraDAL;
using NostraDAL.NostraSrv;
using NostraDataContracts;

namespace NostraTester.ServiceTests
{
    class GetCompletePersonalDataById_NormalTest : PersonalRecordsTestBase
    {
        public GetCompletePersonalDataById_NormalTest()
        {
            testName = this.GetType().Name;
        }
        public override void GoTest()
        {

            DAL_Exctract de = new DAL_Exctract();
            PersonalRecord pr = de.GetCompletePersonalDataById(Constants.TestPersonID);
            if (pr == null)
            {
                SetErrorMessage("Test failed! PersonalRecord got empty, there probably was not provided correct personal Id");
            }
            else
            {
                CheckPersonalData(pr);

                if (pr.KeyWords.Count != Constants.CorrectNumberKW) SetErrorMessage("Test failed! Wrong keywords collection.");
                if (pr.Notes.Count != Constants.CorrectNumberNotes) SetErrorMessage("Test failed! Wrong Notes collection.");
                if (pr.Pictures.Count != Constants.CorrectNumberPictures) SetErrorMessage("Test failed! Wrong pictures collection.");
                if (pr.Relatives.Count != Constants.CorrectNumberRelatives) SetErrorMessage("Test failed! Wrong relatives collection.");
                if (pr.Events.Count != Constants.CorrectNumberEvents) SetErrorMessage("Test failed! Wrong events collection.");
            }


        }

        #region PROTECTED



        #endregion
    }
}
