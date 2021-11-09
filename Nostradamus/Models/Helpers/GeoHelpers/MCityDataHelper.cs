using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus.Models.Helpers.GeoHelpers
{
    public class MCityDataHelper
    {
        public MCityData Data { get; protected set; }
        public MCityDataHelper(int IdCity)
        {
            UpdateData(IdCity);
        }
        
        protected void UpdateData(int IdCity)
        {
            int IDCity = IdCity;
            NostradamusGeoContextFactory factory = new NostradamusGeoContextFactory();
            using (var context = factory.CreateDbContext(new string[] { Constants.ConnectionGeoLocal }))
            {
                try
                {
                    var data = context.Cities.Where(x => x.Id == IDCity).FirstOrDefault();
                    var state = context.StateRegions.Where(x => x.Id == data.RegionState).FirstOrDefault();
                    var country = context.Countries.Where(x => x.Id == data.Country).FirstOrDefault();
                    var TZ = context.TimeZoneLists.Where(x => x.Idtzone == data.TimeZone).FirstOrDefault();


                    Data = ModelsTransformer.TransferModel<City, MCityData>(data);
                    Data.StateRegionData = ModelsTransformer.TransferModel<StateRegion, MStateRegionData>(state);
                    Data.CountryData = ModelsTransformer.TransferModel<Country, MCountryData>(country);
                    Data.TimeZoneData = ModelsTransformer.TransferModel<TimeZoneList, MTimeZoneData>(TZ);
                }
                catch (Exception ex)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog($"MCityDataHelper ->UpdateData-> {ex.Message}");

                }

            }
        }
    }
}
