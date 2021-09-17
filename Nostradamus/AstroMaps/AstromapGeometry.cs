using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstromapGeometry
    {
        protected Point Center { get; set; }
        protected int RExtCircle { get; set; }
        protected int RIntCircle { get; set; }
        protected int RLimbCircle { get; set; }

        public Point ExtCirclePoint { get; set; }
        public Size ExternalCircle { get; set; }
        public Size InternalCircle { get; set; }
        public Point IntCirclePoint { get; set; }
        public Size LimbCircle { get; set; }
        public Point LimbCirclePoint { get; set; }
        public AstromapGeometry()
        {
            Center = new Point(710, 335);
            RExtCircle = 310;            
            RIntCircle = 230;
            RLimbCircle = 222;
            ExtCirclePoint = new Point(Center.X-RExtCircle, Center.Y-RExtCircle);
            ExternalCircle = new Size(2* RExtCircle, 2* RExtCircle);

            IntCirclePoint = new Point(Center.X - RIntCircle, Center.Y - RIntCircle);
            InternalCircle = new Size(2 * RIntCircle, 2 * RIntCircle);

            LimbCirclePoint = new Point(Center.X - RLimbCircle, Center.Y - RLimbCircle);
            LimbCircle = new Size(2* RLimbCircle, 2* RLimbCircle);
        }
    }
}
