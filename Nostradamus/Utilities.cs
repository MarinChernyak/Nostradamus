using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus
{
    public class Utilities
    {
        public static string FromUpperCaseToLowerWithFirstCapital<T>(object input)
        {
            string sinput = Enum.GetName(typeof(T), input).ToString();
            int iPos = sinput.IndexOf("_");
            if (iPos > 0)
            {
                sinput = sinput.Substring(iPos+1);
                sinput=sinput.Replace("_", " ");
            }
            string sout = sinput.ToLower();
            sout = char.ToUpper(sout[0]) + sout.Substring(1);
            return sout;
        }
        public static T FromStringToEnumType<T>(string name, string prefix="")
        {
            name = name.ToUpper();
            name = name.Contains(' ') ? name.Replace(' ', '_') : name;
            name = $"{prefix}{name}";
            T type = (T)Enum.Parse(typeof(T), name);
            return type;
        }
        public static bool IsErrorDouble(KeyPressEventArgs e, string toCheck)
        {
            bool IsError = true;
            if(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                IsError = false;
            }
            else if (e.KeyChar == '.')
            {
                if (toCheck.IndexOf('.') < 0)
                {
                    IsError = false;
                }
            }
            return IsError;
        }
        public static bool IsErrorInt(KeyPressEventArgs e)
        {
            bool IsError = true;
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                IsError = false;
            }
            return IsError;
        }
        public static Dictionary<int, string> GetMonthsData()
        {
            Dictionary<int, string> data = new Dictionary<int, string>();            
            data[1]= "Jan";
            data[2]= "Feb";
            data[3]= "Mar";
            data[4]= "Apr";
            data[5]= "May";
            data[6]= "Jun";
            data[7]= "Jul";
            data[8]= "Aug";
            data[9]= "Sep";
            data[10]= "Oct";
            data[11]= "Nov";
            data[12] = "Dec";            
            return data;
        }
    }
}
