using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NostraPlanetarium
{
    public class SmallPlanet:SpaceObject
    {
        public SmallPlanet(double JD, NPTypes.tPlanetType ptype)
            :base(JD,ptype)
        {

        }
        public override void CalcObjPosition(double JD, NPTypes.tPlanetType ptype)
        {
            using (var sweph = new SwissEphNet.SwissEph())
            {
              
                base.CalcObjPosition(JD, ptype);
            }
        }
    }
}
