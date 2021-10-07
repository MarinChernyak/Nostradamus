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
            string sout = sinput.ToLower();
            sout = char.ToUpper(sout[0]) + sout.Substring(1);
            return sout;
        }
    }
}
