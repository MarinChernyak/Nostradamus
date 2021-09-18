
using Nostradamus.Models;
using Nostradamus.Models.GeoModels;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        protected Dictionary<int, string> _mapSigns;

        #endregion
        protected AstromapGeometry _geometry { get; set; }
        protected double JD;
        public AstroMapBase()
        {
            _aspects = new List<Aspect>();
            _planets = new List<SpaceObject>();
            CreateMapSigns();
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
        protected  void CreateMapSigns()
        {
            _mapSigns = new Dictionary<int, string>();
            _mapSigns[0] = "^";//ari
            _mapSigns[1] = "_";//tau
            _mapSigns[2] = "`";//gem
            _mapSigns[3] = "a";//cnc
            _mapSigns[4] = "b";//leo
            _mapSigns[5] = "c";//vir
            _mapSigns[6] = "d";//lib
            _mapSigns[7] = "e";//sco
            _mapSigns[8] = "f";//sgt
            _mapSigns[9] = "g";//cap
            _mapSigns[10] = "h";//aqr
            _mapSigns[11] = "i";//pis
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
            DrawSigns(g);
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
        protected void DrawSigns(Graphics g)
        {
            double alfa = _houses.GelAlfa();
            //drow ari
            for(int i=0; i<12; ++i)
            {
                double X0 = _geometry.Center.X - _geometry.RExtCircle * Math.Cos((alfa + 30*i) * Math.PI / 180);
                double Y0 = _geometry.Center.Y;

                double X1 = X0;
                double Y1 = Y0 + _geometry.RExtCircle * Math.Sin((alfa + 30 * i) * Math.PI / 180);

                double X2 = _geometry.Center.X - _geometry.RIntCircle * Math.Cos((alfa + 30 * i) * Math.PI / 180);
                double Y2 = Y0+ _geometry.RIntCircle * Math.Sin((alfa + 30 * i) * Math.PI / 180);

                g.DrawLine(_houses.PenHouses, new PointF((float)X1, (float)Y1), new PointF((float)X2, (float)Y2));
                DrawTerms(g, alfa, i);


                double beta = alfa + 15 + 30 * i;
                double R = _geometry.RIntCircle + (_geometry.RExtCircle - _geometry.RIntCircle)*0.6;
                double X3 = _geometry.Center.X- R* Math.Cos(beta * Math.PI / 180)-3;
                double Y3 = _geometry.Center.Y+R * Math.Sin(beta * Math.PI / 180)-3;
                DrawSignsNotations(g, X3, Y3, beta, i);
            }
        }
        protected void DrawSignsNotations(Graphics g, double X, double Y, double  beta, int sign)
        {
            
            Font drawFont = new Font("Wingdings", 12, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            GraphicsState state = g.Save();
            g.ResetTransform();
            g.RotateTransform((float)(90- beta));
            g.TranslateTransform((float)X, (float)Y, MatrixOrder.Append);

            g.DrawString(_mapSigns[sign], drawFont, drawBrush, 0, 0);
            g.Restore(state);
        }

        protected void DrawTerms(Graphics g, double alfa, int sign)
        {
            Pen p = _houses.PenHouses;
            Pen p2 = Pens.Gray;
            int aggleshift = 5;
            for(int i=0; i<6; ++i)
            {
                double X0 = _geometry.Center.X - _geometry.RIntCircle * Math.Cos((alfa + 30 * sign+ aggleshift * i) * Math.PI / 180);
                double Y0 = _geometry.Center.Y;

                double X1 = X0;
                double Y1 = Y0 + _geometry.RIntCircle * Math.Sin((alfa + 30 * sign + aggleshift * i) * Math.PI / 180);

                double X2 = _geometry.Center.X - _geometry.RLimbCircle * Math.Cos((alfa + 30 * sign + aggleshift * i) * Math.PI / 180);
                double Y2 = Y0 + _geometry.RLimbCircle * Math.Sin((alfa + 30 * sign + aggleshift * i) * Math.PI / 180);

                Pen pr = i % 2 == 0 ? p : p2;
                g.DrawLine(pr, new PointF((float)X1, (float)Y1), new PointF((float)X2, (float)Y2));
            }
        }
    }
}
