using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models
{
    public class MDynamicMapUpdateInfo
    {
        public int IdStatic { get; set; }
        public tAstroMapType MapType { get; set; }
        public DateTime DynamicDate { get; set; }
    }
}
