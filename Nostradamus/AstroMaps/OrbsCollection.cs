using Nostradamus.Models;
using Nostradamus.Models.XMLSerializers;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class OrbsCollectionData
    {
        public string OrbsSystemName { get; set; }
        public List<OrbsMapCollection> OrbsMapCollection { get; set; }
    }


    //public class OrbsCollection
    //{
    //    public OrbsCollectionData _data { get; set; }
    //    public OrbsCollection(string SystemName=Constants.DefaultOrbsSystem)
    //    {
    //        OrbsSystemSerializer orbs = new OrbsSystemSerializer(SystemName);
    //        _data = orbs.OrbsCollection;

    //    }
    //    public OrbsCollection()
    //    {
    //        _data = new OrbsCollectionData();
    //    }
    //    public double GetOrb(tAstroMapType amt, tPlanetType pt1,AspectType at)
    //    {
    //        double orb = 0;
    //        //Dictionary<AspectType, double> amap = null;
    //        OrbsMapCollection omc = _data.OrbsMapCollection.Where(x => x.MapType == amt).FirstOrDefault();
    //        if (omc != null)
    //        {
    //            PlanetsAspectsOrbsPairsCollection paoc = omc.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == pt1).FirstOrDefault();
    //            if (paoc != null)
    //            {
    //                AspectOrbsPair aop = paoc.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
    //                if(aop!=null)
    //                {
    //                    orb = aop.OrbValue;
    //                }
    //            }
    //        }           

    //        //if(_data.OrbsMap[amt].ContainsKey(pt1))
    //        //    amap=_data.OrbsMap[amt][pt1];

    //        //if(amap!=null && amap.ContainsKey(at))
    //        //{
    //        //    orb = amap[at];
    //        //}
    //        return orb;
    //    }
    //    public void SetOrb(tAstroMapType amt, tPlanetType pt1, AspectType at, double value)
    //    {
    //        OrbsMapCollection omc = null;
    //        if (_data.OrbsMapCollection == null)
    //        {
    //            _data.OrbsMapCollection = new List<OrbsMapCollection>();
    //        }
            
    //        omc = _data.OrbsMapCollection.Where(x => x.MapType == amt).FirstOrDefault();
            
    //        if (omc == null)
    //        {
    //            omc = new OrbsMapCollection()
    //            {
    //                MapType = amt,
    //                PlanetsAspectsOrbsCollection = new List<PlanetsAspectsOrbsPairsCollection>()
    //            };
    //            _data.OrbsMapCollection.Add(omc);
    //        }

    //        PlanetsAspectsOrbsPairsCollection paoc = omc.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == pt1).FirstOrDefault();
    //        if (paoc == null)
    //        {
    //            paoc = new PlanetsAspectsOrbsPairsCollection()
    //            {
    //                PlanetType = pt1,
    //                AspectOrbsCollection = new List<AspectOrbsPair>()
    //            };
    //            omc.PlanetsAspectsOrbsCollection.Add(paoc);
    //        }
    //        AspectOrbsPair aop = paoc.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
    //        if (aop == null)
    //        {
    //            aop = new AspectOrbsPair()
    //            {
    //                AspectType = at,
    //                OrbValue = value
    //            };
    //            paoc.AspectOrbsCollection.Add(aop);
    //        }
    //        else
    //            aop.OrbValue = value;
            
    //    }
    //}
}
