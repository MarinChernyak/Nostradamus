using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus
{
    public class Utilities
    {
        public static string FromUpperCaseToLowerWithFirstCapital<T>(object input)
        {
            string sinput = Enum.GetName(typeof(T), input).ToString();
            //int iPos = sinput.IndexOf("_");
            //if(iPos>0)
            //{
            //    sinput = sinput.Substring(iPos);
            //}
            string sout = sinput.ToLower();
            sout = char.ToUpper(sout[0]) + sout.Substring(1);
            return sout;
        }
    }
}
