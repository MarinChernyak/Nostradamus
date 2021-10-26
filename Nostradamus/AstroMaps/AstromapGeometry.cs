using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AstromapGeometry
    {
        public Point Center { get; set; }
        public int RExtCircle { get; set; }
        public int RIntCircle { get; set; }
        public int RLimbCircle { get; set; }

        //public int HouseShift { get; set; }

        public Point ExtCirclePoint { get; set; }
        public Size ExternalCircle { get; set; }
        public Size InternalCircle { get; set; }
        public Point IntCirclePoint { get; set; }
        public Size LimbCircle { get; set; }
        public Point LimbCirclePoint { get; set; }

        public int ArrowsLength { get; set; }
        public double ArrowsAngle { get; set; }
        public AstromapGeometry()
        {
            Center = new Point(810, 440);
            RExtCircle = 320;            
            RIntCircle = 240;
            RLimbCircle = 232;
            //HouseShift = 30;
            ArrowsLength = 15;
            ArrowsAngle = 25;

            ExtCirclePoint = new Point(Center.X-RExtCircle, Center.Y-RExtCircle);
            ExternalCircle = new Size(2* RExtCircle, 2* RExtCircle);

            IntCirclePoint = new Point(Center.X - RIntCircle, Center.Y - RIntCircle);
            InternalCircle = new Size(2 * RIntCircle, 2 * RIntCircle);

            LimbCirclePoint = new Point(Center.X - RLimbCircle, Center.Y - RLimbCircle);
            LimbCircle = new Size(2* RLimbCircle, 2* RLimbCircle);
        }
        public virtual int GetExternakRadius()
        {
            return RExtCircle;
        }
        public virtual int GetHouseShift()
        {
            return 30;
        }
    }
}
