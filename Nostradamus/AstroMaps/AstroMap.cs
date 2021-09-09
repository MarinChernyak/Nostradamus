
using Nostradamus.Models;
using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Nostradamus.AstroMaps
{
    public abstract class AstroMapBase
    {
        protected MCityData BirthPlace { get; set; }
        protected List<Aspect> _aspects { get; set; }
        protected List<SpaceObject> _planets;
        protected Houses _houses;

        public List<Shape> ImgShapes;

        protected double JD;
        public AstroMapBase()
        {
            _aspects = new List<Aspect>();
            _planets = new List<SpaceObject>();
            ImgShapes = new List<Shape>();

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

            Person = new MPersonBase();
            Person = person;
            GetBirthPlace();
            CreateHouses();
            CreatePlanetsCollection();

            CreateShapesCollection();
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
                var data = context.Cities.Where(x => x.Id == IDCity).FirstOrDefault();
                var state = context.StateRegions.Where(x => x.Id == data.RegionState).FirstOrDefault();
                var country = context.Countries.Where(x => x.Id == data.Country).FirstOrDefault();

                BirthPlace = ModelsTransformer.TransferModel<City, MCityData>(data);
                BirthPlace.StateRegionData = ModelsTransformer.TransferModel<StateRegion, MStateRegionData>(state);
                BirthPlace.CountryData = ModelsTransformer.TransferModel<Country, MCountryData>(country);

            }

        }
        protected override void CreatePlanetsCollection()
        {
            int h, m, s;
            GetMidleValue(Person, out h, out m, out s);
            JulianDay jd = new JulianDay(Person.BirthDay, Person.BirthMonth, Person.BirthYear, h, m, s, BirthPlace.DiffTime, Person.AdditionalHours);
            JD = jd.JD;
            for (int t = (int)NPTypes.tPlanetType.PT_SUN; t < (int)NPTypes.tPlanetType.PT_TRUE_NODE; ++t)
            {
                _planets.Add(new BigObject(JD, (NPTypes.tPlanetType)t));
            }
        }

        protected void CreateHouses()
        {
            _houses = new Houses(JD, BirthPlace.Longitude, BirthPlace.Latitude, 'K');
        }
        protected void CreateShapesCollection()
        {
            ImgShapes = new List<Shape>();
            CreateCircles();
        }
        protected void CreateCircles()
        {
            Ellipse e = new Ellipse()
            {
                Width = 200,
                Height = 200,
                Fill = Brushes.White,
                Stroke = Brushes.Navy,
                StrokeThickness = 2,

            };
            ImgShapes.Add(e);
            ImgShapes.Add(new Ellipse()
            {
                Width = 150,
                Height = 150,
                Fill = Brushes.White,
                Stroke = Brushes.Navy,
                StrokeThickness = 2
            });
        }
    }
}
