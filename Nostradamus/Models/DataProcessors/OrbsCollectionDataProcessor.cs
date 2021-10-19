using Nostradamus.AstroMaps;
using Nostradamus.Models.DataFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models.DataProcessors
{
    public class OrbsCollectionDataProcessor
    {
        protected string CurrentSystem;
        public OrbsCollectionData Data { get; set; }
        protected OrbsCollectionDataFactory _fact;
        public OrbsCollectionDataProcessor(string system, bool initdata=true)
        {
            CurrentSystem = system;
            if (initdata)
            {
                GetData();
            }
        }
        protected void GetData()
        {
            _fact = new OrbsCollectionDataFactory(CurrentSystem);
            Data = _fact.Data;
        }
        public double GetOrb(tAstroMapType amt , tPlanetType pt, AspectType at)
        {
            double orb = 1;
            
            AspectOrbsPair aop = GetAspectOrbsPair(amt,pt,at);
            if(aop!=null)
            {
                orb = aop.OrbValue;
            }
             
            return orb;
        }
        public void SetOrb(tAstroMapType amt, tPlanetType pt, AspectType at, double orb)
        {
            AspectOrbsPair aop = GetAspectOrbsPair(amt, pt, at);
            aop.OrbValue = orb;
        }
        protected AspectOrbsPair GetAspectOrbsPair(tAstroMapType amt, tPlanetType pt, AspectType at)
        {
            AspectOrbsPair aop = null;

            OrbsMapCollection omc = Data.OrbsMapCollection.Where(x => x.MapType == amt).First();
            if (omc != null)
            {
                PlanetsAspectsOrbsPairsCollection paopc = omc.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == pt).FirstOrDefault();
                if (paopc != null)
                {
                    aop = paopc.AspectOrbsCollection.Where(x => x.AspectType == at).First();
                }
            }
            return aop;
        }
    }
}
