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
    public class MapPlanetsVisibilityCollection
    {
        public tPlanetsGroup PlanetGroup { get; set; }
        public List<PlanetsVisibility> PlanetsVisibilityCollection { get; set; }
    }
    public class MapPlanetsVisibilityCollectionProcessor
    {
        private bool _justcreated;
        public MapPlanetsVisibilityCollection MapPlanetsVisibilityCollection { get; set; }

        public MapPlanetsVisibilityCollectionProcessor(MapPlanetsVisibilityCollection MapPlanetsVisibilityCollection)
        {
            _justcreated = false;
            this.MapPlanetsVisibilityCollection = MapPlanetsVisibilityCollection;
        }

        protected PlanetsVisibility GetPlanetsVisibility(tPlanetsGroup pg, tPlanetType pt)
        {
            _justcreated = false;
            if (MapPlanetsVisibilityCollection == null)
            {
                MapPlanetsVisibilityCollection = new MapPlanetsVisibilityCollection()
                {
                    PlanetGroup = pg,
                    PlanetsVisibilityCollection = new List<PlanetsVisibility>()
                };
            }
            if (MapPlanetsVisibilityCollection.PlanetsVisibilityCollection == null)
            {
                MapPlanetsVisibilityCollection.PlanetsVisibilityCollection = new List<PlanetsVisibility>();
            }
            PlanetsVisibility obj = MapPlanetsVisibilityCollection.PlanetsVisibilityCollection.Where(x => x.PlanetsType == pt).First();
            if (obj == null)
            {
                _justcreated = true;
                obj = new PlanetsVisibility()
                {
                    IsVisible = true,
                    PlanetsType = pt

                };
                MapPlanetsVisibilityCollection.PlanetsVisibilityCollection.Add(obj);
            }
            return obj;
        }
        public bool GetValue (tPlanetsGroup pg,  tPlanetType pt)
        {
            PlanetsVisibility obj = GetPlanetsVisibility(pg, pt);            
            return obj.IsVisible;
        }
        public void SetValue(tPlanetsGroup pg, tPlanetType pt, bool isVisible)
        {
            PlanetsVisibility obj = GetPlanetsVisibility(pg, pt);
            obj.IsVisible = isVisible;
        }
        public void ToggleValue(tPlanetsGroup pg, tPlanetType pt)
        {
            PlanetsVisibility obj = GetPlanetsVisibility(pg, pt);
            if (!_justcreated )
            {
                obj.IsVisible = !obj.IsVisible;
            }
        }
    }
}
