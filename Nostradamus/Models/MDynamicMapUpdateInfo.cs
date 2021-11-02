using Nostradamus.Models.GeoModels;
using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models
{
    public class MDynamicMapUpdateInfo
    {
        public tAstroMapType MapType { get; set; }
        public DateTime DynamicDate { get; set; }
        public MCityData EventPlace { get; set; }
        public double AdditionalHour { get; set; }
    }
}
