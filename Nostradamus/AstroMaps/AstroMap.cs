
using Nostradamus.Models;
using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Windows.Media;
using System.Windows.Shapes;

namespace Nostradamus.AstroMaps
{
    public abstract class AstroMapBase
    {
        protected MCityData BirthPlace { get; set; }
        protected List<Aspect> _aspects { get; set; }
        protected List<SpaceObject> _planets;
        protected AMHouses _houses;
        

        #region graph


        #endregion
        protected AstromapGeometry _geometry { get; set; }
        protected double JD;
        public AstroMapBase()
        {
            _aspects = new List<Aspect>();
            _planets = new List<SpaceObject>();
        }
        protected abstract void CreatePlanetsCollection();
        protected void GetMidleValue(MPersonBase person, out int h, out int m, out int s)
        {
            h = m = s = 0;
            double t1 = person.BirthHourFrom + person.BirthMinFrom / 60 + person.BirthSecFrom / 3600;
            double t2 = person.BirthHourTo + person.BirthMinTo / 60 + person.BirthSecTo / 3600;

            t1 = t1 + (t2 - t1) / 2;
            h = (int)t1;
            m = (int)((t1 - h) * 60);
            s = (int)((t1 - h - m / 60) * 3600);
        }
    }
    public class AstroMapPerson : AstroMapBase
    {
        protected MPersonBase Person { get; }
        public AstroMapPerson(int id)
        {
            Person = new MPersonBase();
            Person.Id = id;
            GetPersonalData();
            CreateHouses();
            CreatePlanetsCollection();
        }
        public AstroMapPerson(MPersonBase person)
        {
            _geometry = new AstromapGeometry();
            Person = person;
            GetBirthPlace();
            CreateHouses();
            CreatePlanetsCollection();
        
        }

        protected void GetPersonalData()
        {
            //GetData byID
        }
        protected void GetBirthPlace()
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


                    BirthPlace = ModelsTransformer.TransferModel<City, MCityData>(data);
                    BirthPlace.StateRegionData = ModelsTransformer.TransferModel<StateRegion, MStateRegionData>(state);
                    BirthPlace.CountryData = ModelsTransformer.TransferModel<Country, MCountryData>(country);
                    BirthPlace.TimeZoneData = ModelsTransformer.TransferModel<TimeZoneList, MTimeZoneData>(TZ);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        protected override void CreatePlanetsCollection()
        {
            int h, m, s;
            GetMidleValue(Person, out h, out m, out s);
            JulianDay jd = new JulianDay(Person.BirthDay, Person.BirthMonth, Person.BirthYear, h, m, s, BirthPlace.TimeZoneData.TimeOffset, Person.AdditionalHours);
            JD = jd.JD;
            for (int t = (int)NPTypes.tPlanetType.PT_SUN; t < (int)NPTypes.tPlanetType.PT_TRUE_NODE; ++t)
            {
                _planets.Add(new BigObject(JD, (NPTypes.tPlanetType)t));
            }
        }

        protected void CreateHouses()
        {
            _houses = new AMHouses(JD, BirthPlace.Longitude, BirthPlace.Latitude, 'K', _geometry);
        }
        public void DrawMap(Graphics g)
        {
            _houses.DrawHouses(g);
            DrawCircles(g);
        }
 

        protected void DrawCircles(Graphics g)
        {
            g.DrawEllipse(_houses.PenHouses, _geometry.ExtCirclePoint.X, _geometry.ExtCirclePoint.Y, _geometry.ExternalCircle.Width, _geometry.ExternalCircle.Height);
            g.FillEllipse(Brushes.White, _geometry.ExtCirclePoint.X + 1, _geometry.ExtCirclePoint.Y + 1, _geometry.ExternalCircle.Width - 2, _geometry.ExternalCircle.Height - 2);

            g.DrawEllipse(_houses.PenHouses, _geometry.IntCirclePoint.X, _geometry.IntCirclePoint.Y, _geometry.InternalCircle.Width, _geometry.InternalCircle.Height);
            g.FillEllipse(Brushes.White, _geometry.IntCirclePoint.X + 1, _geometry.IntCirclePoint.Y + 1, _geometry.InternalCircle.Width - 2, _geometry.InternalCircle.Height - 2);

            g.DrawEllipse(_houses.PenHouses, _geometry.LimbCirclePoint.X, _geometry.LimbCirclePoint.Y, _geometry.LimbCircle.Width, _geometry.LimbCircle.Height);
            g.FillEllipse(Brushes.White, _geometry.LimbCirclePoint.X + 1, _geometry.LimbCirclePoint.Y + 1, _geometry.LimbCircle.Width - 2, _geometry.LimbCircle.Height - 2);

        }
    }
}
