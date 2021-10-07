using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class OrbsMapCollection
    {
        public tAstroMapType MapType {get;set;}
        public List<PlanetsAspectsOrbsPairsCollection> PlanetsAspectsOrbsCollection { get; set; }
    }
    public class PlanetsAspectsOrbsPairsCollection
    {
        public tPlanetType PlanetType { get; set; }
        public List<AspectOrbsPair> AspectOrbsCollection { get; set; }
    }
    public class AspectOrbsPair
    {
        public AspectType AspectType { get; set; }
        public double OrbValue { get; set; }
    }
}
