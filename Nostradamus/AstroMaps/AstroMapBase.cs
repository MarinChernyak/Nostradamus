using Nostradamus.Models;
using Nostradamus.Models.DataProcessors;
using Nostradamus.Models.GeoModels;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public abstract class AstroMapBase
    {
        public int ID { get; protected set; }
        public MCityData EventPlace { get; protected set; }
        protected MapPlanetsVisibilityCollectionProcessor MapPlanetsVisibility;
        public AspectsCollection _aspects { get; protected set; }
        public List<SpaceObjectData> _space_objects { get; protected set; }
        public AMHouses _houses { get; set; }

        public double JD { get; protected set; }
        public AstroMapBase()
        {
            MapPlanetsVisibility = new MapPlanetsVisibilityCollectionProcessor();
           
        }

        protected abstract void CreateSOCollection();




        protected abstract void Createaspects();
        protected virtual List<SpaceObjectData> CreateMainCollection(tAstroMapType at)
        {

            List<SpaceObjectData> lst_objects = new List<SpaceObjectData>();

            for (int t = (int)NPTypes.tPlanetType.PT_SUN; t <= (int)NPTypes.tPlanetType.PT_TRUE_NODE; ++t)
            {
                bool isVisible = MapPlanetsVisibility.GetValue(at, (NPTypes.tPlanetType)t);

                if (t == (int)NPTypes.tPlanetType.PT_MEAN_NODE || !isVisible)
                    continue;

                SpaceObject so = new BigObject(JD, (tPlanetType)t);
                lst_objects.Add(new SpaceObjectData()
                {
                    _so = so
                });
            }
            return lst_objects;
        }
        protected virtual void GetJD(int day, int month, int year, int hour, int min, double time_offset)
        {
            JD = new JulianDay(day, month, year, hour, min, 0, time_offset, 0).JD;
        }
        protected virtual void GetJD(DateTime dt, double additional_hour=0)
        {
            JD = new JulianDay(dt.Day, dt.Month, dt.Year, dt.Hour, dt.Minute, 0, EventPlace.TimeZoneData.TimeOffset, additional_hour).JD;
        }
        public virtual void DrawMap(Graphics g)
        {

        }
        protected virtual void ProvideMapNotes(Graphics g) { }

    }
}
