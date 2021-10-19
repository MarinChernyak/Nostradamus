using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class PlanetsVisibility
    {
        public tPlanetType PlanetsType { get; set; }
        public bool IsVisible { get; set; }
    }
    public class MapPlanetsVisibility
    {
        public tAstroMapType MapType { get; set; }
        public List<PlanetsVisibility> PlanetsVisibilityList { get; set; }
    }
    public class GroupMapPlanetsVisibilityCollection
    {
        public tPlanetsGroup PlanetGroup { get; set; }
        public List<MapPlanetsVisibility> MapPlanetsVisibilityCollection { get; set; }
    }
    
}
    