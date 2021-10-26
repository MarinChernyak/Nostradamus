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
        public AstroMapTransit(int id, DateTime dt)
            :base(id,dt,NPTypes.tAstroMapType.TRANSIT)
        {

        }
        public override void DrawMap(Graphics g)
        {
            base.DrawMap(g);
        }



    }
}
