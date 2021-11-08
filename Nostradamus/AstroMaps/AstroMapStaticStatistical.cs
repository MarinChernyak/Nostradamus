using Nostradamus.Models;
using Nostradamus.Models.DataFactories;
using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapStaticStatistical : AstroMapBase
    {
        protected MPersonBase Person { get; set; }


        public AstroMapStaticStatistical()
        {

        }
        public AstroMapStaticStatistical(int Day, int Month, int Year, int H, int Min, int IdCity)
        {
            CalculateEventPlace(IdCity);
            GetJD(Day, Month, Year, H, Min, EventPlace.TimeZoneData.TimeOffset);
            CreateMap();    
        }
        public AstroMapStaticStatistical(int id)
        {
            if (id > 0)
            {
                ID = id;
                PersonsCollection pc = new PersonsCollection();
                Person = pc.GetPersonById(id);
                if (Person != null)
                {

                    CreateMap();
                }
            }
            else
            {
                MessageBox.Show("Unknown error in AstroMapStatic!");
            }
        }
        public AstroMapStaticStatistical(MPersonBase person)
        {
            if (person != null)
            {
                Person = person;
                ID = person.Id;
                CreateMap();
            }
            else
            {
                MessageBox.Show("Unknown error in AstroMapStatic!");
            }
        }
        protected virtual void CreateMap()
        {
            GetEventPlace();
            CreateHouses();
            CreateSOCollection();
            Createaspects();
        }
        protected virtual void CreateHouses()
        {
            UserPreferncesDataFactory up = new UserPreferncesDataFactory();
            HousesData hd = up.Data.HousesData;
            char system = 'K';
            if (hd != null && !string.IsNullOrEmpty(hd.SystemID))
            {
                char[] cc = hd.SystemID.ToCharArray();
                system = cc[0];
            }

            _houses = new AMHouses(JD, EventPlace.Longitude, EventPlace.Latitude, system, null);
        }
        protected override void Createaspects()
        {
            _aspects = new AspectsCollection(_space_objects);
        }

        protected void GetMidleValue(MPersonBase person, out int h, out int m, out int s)
        {
            h = m = s = 0;
            if (person != null)
            {
                double t1 = person.BirthHourFrom + person.BirthMinFrom / 60 + person.BirthSecFrom / 3600;
                double t2 = person.BirthHourTo + person.BirthMinTo / 60 + person.BirthSecTo / 3600;

                t1 = t1 + (t2 - t1) / 2;
                h = (int)t1;
                m = (int)((t1 - h) * 60);
                s = (int)((t1 - h - m / 60) * 3600);
            }
        }

        protected override void CreateSOCollection()
        {
            _space_objects = CreateMainCollection(tAstroMapType.NATAL);
        }

        protected void CreateSmallObjectsCollection(tAstroMapType at = tAstroMapType.NATAL)
        {
            for (int t = (int)NPTypes.tPlanetType.PT_SUN; t <= (int)NPTypes.tPlanetType.PT_TRUE_NODE; ++t)
            {
                bool isVisible = MapPlanetsVisibility.GetValue(at, (NPTypes.tPlanetType)t);

                if (t == (int)NPTypes.tPlanetType.PT_MEAN_NODE || !isVisible)
                    continue;

                SpaceObject so = new BigObject(JD, (NPTypes.tPlanetType)t);
                _space_objects.Add(new SpaceObjectData()
                {
                    _so = so
                });
            }
        }
        protected void GetEventPlace()
        {
            if (Person != null)
            {
                CalculateEventPlace(Person.Place);
            }

        }
        protected void CalculateEventPlace(int Id)
        {
            int IDCity = Id;
            NostradamusGeoContextFactory factory = new NostradamusGeoContextFactory();
            using (var context = factory.CreateDbContext(new string[] { Constants.ConnectionGeoLocal }))
            {
                try
                {
                    var data = context.Cities.Where(x => x.Id == IDCity).FirstOrDefault();
                    var state = context.StateRegions.Where(x => x.Id == data.RegionState).FirstOrDefault();
                    var country = context.Countries.Where(x => x.Id == data.Country).FirstOrDefault();
                    var TZ = context.TimeZoneLists.Where(x => x.Idtzone == data.TimeZone).FirstOrDefault();


                    EventPlace = ModelsTransformer.TransferModel<City, MCityData>(data);
                    EventPlace.StateRegionData = ModelsTransformer.TransferModel<StateRegion, MStateRegionData>(state);
                    EventPlace.CountryData = ModelsTransformer.TransferModel<Country, MCountryData>(country);
                    EventPlace.TimeZoneData = ModelsTransformer.TransferModel<TimeZoneList, MTimeZoneData>(TZ);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
