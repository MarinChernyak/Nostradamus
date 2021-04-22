using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NostraPlanetarium
{
    public class JulianDay
    {
        protected double _jd;
        protected int _gregflag;

        public double JD { get { return _jd; } }

        public JulianDay(DateTime dt)
        {
            
            CalculateJD(dt);
        }
        public JulianDay(int a_iBDay, int a_iBMonth, int a_iBYear,
                      int a_iBHour, int a_iBMinutes, int a_iBSeconds,
                      double a_dDiffTime, double additionalTime)
        {
            CalculateJD(a_iBDay, a_iBMonth, a_iBYear, a_iBHour, a_iBMinutes, a_iBSeconds, a_dDiffTime, additionalTime);
        }
        protected void CalculateJD(DateTime dt)
        {
            CalculateGregFlag(dt.Day, dt.Month, dt.Year);
            using (var sweph = new SwissEphNet.SwissEph())
            {
                _jd = sweph.swe_julday(dt.Year, dt.Month, dt.Day, dt.Hour + dt.Minute / 60, _gregflag);
            }
        }
        protected void CalculateJD(int a_iBDay, int a_iBMonth, int a_iBYear,
                      int a_iBHour, int a_iBMinutes, int a_iBSeconds,
                      double a_dDiffTime, double additionalTime)
        {
            CalculateGregFlag(a_iBDay, a_iBMonth, a_iBYear);
            double dTime= a_iBHour+ a_iBMinutes/60 +a_iBSeconds/3600-a_dDiffTime-additionalTime;

            using (var sweph = new SwissEphNet.SwissEph())
            {
                _jd = sweph.swe_julday(a_iBYear, a_iBMonth, a_iBDay, dTime , _gregflag);
            }
        }
        protected void CalculateGregFlag(int a_iBDay, int a_iBMonth, int a_iBYear)
        {
            if (a_iBYear >= 1582 || (a_iBYear == 1582 && a_iBMonth >= 10) ||
               (a_iBYear == 1582 && a_iBMonth == 10 && a_iBDay >= 15)
               )
                _gregflag = 1;
            else
                _gregflag = 0;
        }
    }
}
