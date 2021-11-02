using Nostradamus.Models;
using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapStaticStatistical : AstroMapBase
    {
        protected MPersonBase Person { get; set; }
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
        protected void GetJD()
        {
            int h, m, s;
            GetMidleValue(Person, out h, out m, out s);
            JD = new JulianDay(Person.BirthDay, Person.BirthMonth, Person.BirthYear, h, m, s, EventPlace.TimeZoneData.TimeOffset, Person.AdditionalHours).JD;

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
            int IDCity = Person.Place;
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
