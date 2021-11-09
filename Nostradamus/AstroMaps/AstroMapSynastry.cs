using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstroMapSynastry : AstromapComplex
    {
        public AstroMapSynastry(AstroMapStaticComplex mapstatic, AstroMapDynamic synastry)
        {
            _map_static = mapstatic;
            _map_dynamic = synastry;
            CreateMap();
        }

     }
}
