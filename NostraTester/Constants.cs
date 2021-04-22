using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraTester
{
    public class Constants
    {
        public static String Salt { get { return "GhuY^t7@"; } }
        public static String PassCode { get { return "i0@LSa+0"; } }

        public static String TestPassedOK { get { return "Test has passed OK!"; } }
        public static String TestError { get { return "Test has FAILED!"; } }

        public static int TestPersonID { get { return 8664; } }
        public static int CorrectNumberKW { get { return 2; } }
        public static int CorrectNumberEvents { get { return 10; } }
        public static int CorrectNumberNotes { get { return 3; } }
        public static int CorrectNumberPictures { get { return 2; } }
        public static int CorrectNumberRelatives { get { return 1; } }
        public static int CorrectRelativeId { get { return 8217; } }
        public static int LengthLineSeparator { get {return 75;}}
        public static int CorrectTimeSource { get { return 1; } }
        public static string CorrecttDataType_Description { get { return "Top Secret"; } }
        public static string CorrectSex_Description { get { return "Female"; } }


        //public static String GetEmail() { return String.Format("{0}@test.com", Cache.Get(Constants.TestUserNameCache)); }


        /////////////////// functions //////////////////////////
        public static string GetSeparator(string symbol)
        {
            string sout = String.Empty;
            for (int i = 0; i < LengthLineSeparator; ++i)
            {
                sout += symbol;
            }
            return sout;
        }
    }
}
