using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nostradamus.Models.Helpers.GeoHelpers
{
    public class CitiesHelper
    {

        protected int IDCountry { get; }
        protected int IDState { get; }
        public List<MCityData> Data { get; protected set; }
        public CitiesHelper(int idCountry, int idState=0)
        {
            IDCountry = idCountry;
            IDState = idState;
            if (IDState > 0)
            {
                GetDataByState();
            }
            else if (IDCountry > 0)
            {
                GetDataByCuntry();
            }
        }
        protected void GetDataByState()
        {
            NostradamusGeoContextFactory factory = new NostradamusGeoContextFactory();
            using (var context = factory.CreateDbContext(new string[] { Constants.ConnectionGeoLocal }))
            {
                try
                {
                    var data = context.Cities.Where(x => x.RegionState == IDState).OrderBy(x=>x.CityName).ToList();
                    Data = ModelsTransformer.TransferModelList<City, MCityData>(data);
                }
                catch (Exception ex)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(ex.Message);
                }

            }

        }
        protected void GetDataByCuntry()
        {
            NostradamusGeoContextFactory factory = new NostradamusGeoContextFactory();
            using (var context = factory.CreateDbContext(new string[] { Constants.ConnectionGeoLocal }))
            {
                try
                {
                    var data = context.Cities.Where(x => x.Country == IDCountry).OrderBy(x => x.CityName).ToList();
                    Data = ModelsTransformer.TransferModelList<City,MCityData>(data);
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
