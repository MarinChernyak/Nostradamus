using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class Aspect
    {

        public double Angle { get; set; }

        public NPTypes.tPlanetType PlanetType1 { get; set; }
        public NPTypes.tPlanetType PlanetType2 { get; set; }
        public AspectData _aspect_data { get; set; }
        public bool IsConvergative { get; set; }

        public Aspect()
        {

        }
        public Aspect(double angle, AspectData ad)
        {
            Angle = angle;
            _aspect_data = ad;
        }
    }
}
