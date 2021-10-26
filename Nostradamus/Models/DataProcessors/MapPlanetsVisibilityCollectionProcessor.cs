using Nostradamus.AstroMaps;
using Nostradamus.Models.DataFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models.DataProcessors
{
    public class MapPlanetsVisibilityCollectionProcessor: BaseProcessor
    {
        public bool _justcreated { get; protected set; }
        public List<MapPlanetsVisibility> Data { get; set; }

        public MapPlanetsVisibilityCollectionProcessor(bool initdata = true)
            :base(initdata)
        {
        }
        protected PlanetsVisibility GetPlanetsVisibility(tAstroMapType mt, tPlanetType pt)
        {
            _justcreated = false;
            if (Data == null)
            {
                Data = new List<MapPlanetsVisibility>();
            }
            MapPlanetsVisibility mpv = Data.Where(x => x.MapType == mt).FirstOrDefault();

            if (mpv.PlanetsVisibilityList == null)
            {
                mpv.PlanetsVisibilityList = new List<PlanetsVisibility>();
            }
            PlanetsVisibility pv = mpv.PlanetsVisibilityList.Where(x => x.PlanetsType == pt).FirstOrDefault();
            if(pv==null)
            {
                pv = new PlanetsVisibility()
                {
                    IsVisible = true,
                    PlanetsType = pt
                };
                mpv.PlanetsVisibilityList.Add(pv);
            }
            return pv;
        }
        public List<PlanetsVisibility> GetSimpleVisibilityCollection(tAstroMapType mt)
        {
            MapPlanetsVisibility mpv = Data.Where(x => x.MapType == mt).First();
            return mpv.PlanetsVisibilityList;
        }
        public bool GetValue(tAstroMapType mt, tPlanetType pt)
        {
            PlanetsVisibility obj = GetPlanetsVisibility(mt, pt);
            return obj.IsVisible;
        }
        public void SetValue(tAstroMapType mt, tPlanetType pt, bool isVisible)
        {
            PlanetsVisibility obj = GetPlanetsVisibility(mt, pt);
            obj.IsVisible = isVisible;
        }
        public void ToggleValue(tAstroMapType mt, tPlanetType pt)
        {
            if (mt != tAstroMapType.UNKNOWN)
            {
                PlanetsVisibility obj = GetPlanetsVisibility(mt, pt);
                if (!_justcreated)
                {
                    obj.IsVisible = !obj.IsVisible;
                }
            }
        }

        protected override void GetData()
        {
            PlanetsVisibilityFactory _fact = new PlanetsVisibilityFactory();
            Data = _fact.Data.Where(x => x.PlanetGroup == tPlanetsGroup.PG_MAIN).FirstOrDefault().MapPlanetsVisibilityCollection ;
            Data.AddRange(_fact.Data.Where(x => x.PlanetGroup == tPlanetsGroup.PG_FICTITIOUS).FirstOrDefault().MapPlanetsVisibilityCollection);
            Data.AddRange(_fact.Data.Where(x => x.PlanetGroup == tPlanetsGroup.PG_SMALL).FirstOrDefault().MapPlanetsVisibilityCollection);
            //Data.AddRange(_fact.Data.Where(x => x.PlanetGroup == tPlanetsGroup.PG_CUSTOM).FirstOrDefault().MapPlanetsVisibilityCollection);
            //Data.AddRange(_fact.Data.Where(x => x.PlanetGroup == tPlanetsGroup.PG_HAMBURGERS).FirstOrDefault().MapPlanetsVisibilityCollection);

        }
    }
}
