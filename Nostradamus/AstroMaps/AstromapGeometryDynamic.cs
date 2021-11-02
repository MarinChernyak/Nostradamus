using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstromapGeometryDynamic : AstromapGeometry
    {
        public int RExtCircleDynamic { get; set; }
        public Point ExtCircleDynamicPoint { get; set; }
        public Size ExternalCircleDynamic { get; set; }
        public AstromapGeometryDynamic()
        {
            RExtCircleDynamic = (int)(RExtCircle + (RExtCircle - RIntCircle) / 1.2);
            ExtCircleDynamicPoint = new Point(Center.X - RExtCircleDynamic, Center.Y - RExtCircleDynamic);
            ExternalCircleDynamic = new Size(2 * RExtCircleDynamic, 2 * RExtCircleDynamic);
        }
        public override int GetExternalRadius()
        {
            return RExtCircleDynamic;
        }
        public override int GetHouseShift()
        {
            return 35;
        }
    }
}
