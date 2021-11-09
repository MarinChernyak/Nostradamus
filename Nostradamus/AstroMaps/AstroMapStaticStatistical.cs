using Nostradamus.Models;
using Nostradamus.Models.DataFactories;
using Nostradamus.Models.GeoModels;
using Nostradamus.Models.Helpers.GeoHelpers;
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
            MCityDataHelper mhelper = new MCityDataHelper(Id);
            EventPlace = mhelper.Data;
        }
    }
}
