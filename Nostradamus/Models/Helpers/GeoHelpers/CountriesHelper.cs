using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus.Models.Helpers.GeoHelpers
{
    public class CountriesHelper
    {
        public List<MCountryData> Data { get; protected set; }
        public CountriesHelper()
        {
            GetData();
        }
        protected void GetData()
        {

            NostradamusGeoContextFactory factory = new NostradamusGeoContextFactory();
            using (var context = factory.CreateDbContext(new string[] { Constants.ConnectionGeoLocal }))
            {
                try
                {
                    var data = context.Countries.OrderBy(x=>x.CountryName).ToList();
                    Data = ModelsTransformer.TransferModelList<Country, MCountryData>(data);
                }
                catch (Exception ex)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(ex.Message);
                }

            }            
        }
    }
}
