using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus.Models.Helpers.GeoHelpers
{
    public class StatesHelper 
    {
        protected int IDCountry { get; }
        public List<MStateRegionData> Data { get; protected set; }
        public StatesHelper(int idCountry)
        {
            IDCountry = idCountry;
            GetData();
        }
        protected void GetData()
        {
            NostradamusGeoContextFactory factory = new NostradamusGeoContextFactory();
            using (var context = factory.CreateDbContext(new string[] { Constants.ConnectionGeoLocal }))
            {
                try
                {
                    var data = context.StateRegions.Where(x => x.CountryRef == IDCountry).OrderBy(x=>x.StateRegion1).ToList();
                    Data=ModelsTransformer.TransferModelList<StateRegion,MStateRegionData>(data);
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
