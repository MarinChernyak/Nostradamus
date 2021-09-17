using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.GeoModels
{
    public class MCityData
    {
        public int Id { get; set; }
        public String CityName { get; set; }
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double Time { get; set; }



        public MCountryData CountryData { get; set; }

        public MStateRegionData StateRegionData { get; set; }
        public MTimeZoneData TimeZoneData { get; set; }
    }
}
