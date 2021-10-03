using Nostradamus.Models;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class OrbsCollectionData
    {
        public string OrbsSystemName { get; set; }
        public Dictionary<tAstroMapType, Dictionary<tPlanetType, Dictionary<AspectType, double>>> OrbsMap { get; set; }
    }
    public class OrbsCollection
    {
        protected  OrbsCollectionData _data;
        public OrbsCollection(string SystemName=Constants.DefaultOrbsSystem)
        {
            OrbsSystemSerializer orbs = new OrbsSystemSerializer(SystemName);
            _data = orbs.OrbsCollection;
        }
        
        public double GetOrb(tAstroMapType amt, tPlanetType pt1,AspectType at)
        {
            double orb = 0;
            Dictionary<AspectType, double> amap = null;
            
            if(_data.OrbsMap[amt].ContainsKey(pt1))
                amap=_data.OrbsMap[amt][pt1];

            if(amap!=null && amap.ContainsKey(at))
            {
                orb = amap[at];
            }
            return orb;
        }
    }
}
