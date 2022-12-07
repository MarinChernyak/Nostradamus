using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstroMapProgressive : AstroMapDynamic        
    {
        protected double JDStatic { get; set; }
        public AstroMapProgressive()
        {

        }
        public AstroMapProgressive(MDynamicMapUpdateInfo info, double jdStatic)
            :base(info)
        {
            JDStatic = jdStatic;
            GetJD();
            CreateMap();
        }
        protected override void GetJD()
        {
            double JDreal = new JulianDay(DynamicDate.Day, DynamicDate.Month, DynamicDate.Year, DynamicDate.Hour, DynamicDate.Minute, 0, EventPlace.TimeZoneData.TimeOffset, AdditionalHour).JD;
            JD = JDStatic+(JDreal - JDStatic) / 365.25;
        }

     }
}
