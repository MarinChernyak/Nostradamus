using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.Models.GeoModels
{
    public class MTimeZoneData
    {
        public short Idtzone { get; set; }
        public string Abbreviation { get; set; }
        public string TzoneName { get; set; }
        public string Location { get; set; }
        public double TimeOffset { get; set; }
        public string LocationWorldWide { get; set; }

    }
}
