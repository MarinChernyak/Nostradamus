using Nostradamus.AstroMaps;
using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Models.DataFactories
{
    public class PlanetsVisibilityFactory : DataFactoryBase<List<GroupMapPlanetsVisibilityCollection>>
    {
        protected override void CreateDefaultData()
        {
            Data = new List<GroupMapPlanetsVisibilityCollection>();
            for(int igr=(int)tPlanetsGroup.PG_MAIN; igr< (int)tPlanetsGroup.PG_CUSTOM; ++igr)
            {
                List<MapPlanetsVisibility> lstMapPlanetsVisibility = new List<MapPlanetsVisibility>();

                GroupMapPlanetsVisibilityCollection gr = new GroupMapPlanetsVisibilityCollection()
                {
                    PlanetGroup = (tPlanetsGroup)igr,
                    MapPlanetsVisibilityCollection = lstMapPlanetsVisibility
                };
                for(int imap = (int)tAstroMapType.NATAL; imap< (int)tAstroMapType.NUMBER_DYNAMIC_TYPES; ++imap)
                {
                    List<PlanetsVisibility> lpv = new List<PlanetsVisibility>();
                    UpdateListPlanetsVisibility((tPlanetsGroup)igr, lpv);
                    MapPlanetsVisibility mpv = new MapPlanetsVisibility()
                    {
                        MapType = (tAstroMapType)imap,
                        PlanetsVisibilityList = lpv
                    };                    
                    lstMapPlanetsVisibility.Add(mpv);
                }
                Data.Add(gr);
            }            
        }
        protected void UpdateListPlanetsVisibility(tPlanetsGroup pg, List<PlanetsVisibility> lpv)
        {
            tPlanetType ptstart= tPlanetType.PT_EARTH;
            tPlanetType ptend = tPlanetType.PT_EARTH;

            switch(pg)
            {
                case tPlanetsGroup.PG_MAIN:
                    ptstart = tPlanetType.PT_SUN;
                    ptend = tPlanetType.PT_PLUTO;
                    break;
                case tPlanetsGroup.PG_FICTITIOUS:
                    ptstart = tPlanetType.PT_TRUE_NODE;
                    ptend = tPlanetType.PT_MEAN_APOG;
                    break;
                case tPlanetsGroup.PG_SMALL:
                    ptstart = tPlanetType.PT_TRUE_NODE;
                    ptend = tPlanetType.PT_MEAN_APOG;
                    break;
            };
            for(int index=(int)ptstart; index<= (int)ptend; ++index)
            {
                lpv.Add(new PlanetsVisibility()
                {
                    IsVisible= pg== tPlanetsGroup.PG_MAIN? true:false,
                    PlanetsType = (tPlanetType)index
                });
            }
        }

        protected override void CreateSerializer()
        {
            _serializer = new PlanetsVisibilitySerializer();
        }

     }
}
