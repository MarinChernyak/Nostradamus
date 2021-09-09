using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.GeoModels
{
    public class MCityData
    {
        public int Id { get; set; }
        public String PlaceName { get; set; }
        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public double DiffTime { get; set; }

        public MCountryData CountryData { get; set; }

        public MStateRegionData StateRegionData { get; set; }
    }
}
