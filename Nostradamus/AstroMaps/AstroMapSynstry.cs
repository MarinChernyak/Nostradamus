using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstroMapSynstry:AstroMapDynamic
    {

        public AstroMapSynstry(MDynamicMapUpdateInfo info)
            : base(info)
        {
            GetJD();
            CreateMap();
        }
    }
}
