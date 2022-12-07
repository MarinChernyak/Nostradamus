using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstroMapTransit: AstroMapDynamic
    {
        public AstroMapTransit(MDynamicMapUpdateInfo info)
            :base(info)
        {
            GetJD();
            CreateMap();
        }
    }
}
