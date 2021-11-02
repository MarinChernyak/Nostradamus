using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapTransit : AstroMapDynamic
    {
        public AstroMapTransit(MDynamicMapUpdateInfo info)
            :base(info)
        {

        }
        public override void DrawMap(Graphics g)
        {
            base.DrawMap(g);
        }



    }
}
