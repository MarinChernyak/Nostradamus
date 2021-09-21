
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
using System.IO;
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
            CreatePlanetsCollection();
            CreateHouses();

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
            DrawPlanets(g);
        }
        protected void DrawPlanets(Graphics g)
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1","Resources\\icons\\");

            double alfa = _houses.GelAlfa();
            Icon bbicon = new Icon($"{path}BuletBlue.ico");
            int planetShift = (_geometry.RExtCircle - _geometry.RIntCircle) / 3 + _geometry.RIntCircle;
            const int iNumIntervals = 90;
            int[] iZuz1 = new int[iNumIntervals];
            int[] iZuz2 = new int[iNumIntervals];
            int[] iZuz3 = new int[iNumIntervals];

            foreach (SpaceObject so in _planets)
            {
                //New

                int intWidth = 360/ iNumIntervals;
                int index1 = (int)so.Lambda/ intWidth;
                double dl = so.Lambda - intWidth / 2;
                if (dl < 0)
                    dl += 360;
                int index2 = (int)(dl / intWidth);
                int index3 = (int)((so.Lambda + intWidth / 2) / intWidth);

                float dX = 0;
                float dY = 0;
                string pt = so.PlanetType.ToString();
                GetDeltaPlanets(so, out dX, out dY);
                int iZuz = Math.Max(iZuz1[index1], iZuz2[index2]);
                iZuz = Math.Max(iZuz, iZuz3[index3]);

                string r = so.SpeedLong < 0 ? "R" : "";
                Icon icon = new Icon($"{path}{pt}{r}.ico");

                double bbx = _geometry.Center.X - _geometry.RLimbCircle * Math.Cos((so.Lambda - alfa) * Math.PI / 180) - 8;
                double bby = _geometry.Center.Y + _geometry.RLimbCircle * Math.Sin((so.Lambda - alfa) * Math.PI / 180) - 8;
                g.DrawIcon(bbicon, (int)bbx, (int)bby);

                double px = _geometry.Center.X - planetShift * (1+0.09*iZuz)*Math.Cos((so.Lambda - alfa) * Math.PI / 180) - 4+dX;
                double py = _geometry.Center.Y + planetShift * (1 + 0.09 * iZuz)*Math.Sin((so.Lambda - alfa) * Math.PI / 180) - 4+dY;
                g.DrawIcon(icon, (int)px, (int)py);

                iZuz1[index1]++;
                iZuz2[index2]++;
                iZuz3[index3]++;
            }

        }
        protected void GetConjunctionMove(SpaceObject so, out float dX, out float dY)
        {
            dX = 0;
            dY = 0;

        }
        protected void GetDeltaPlanets(SpaceObject so, out float dX, out float dY)
        {
            double alfa = _houses.GelAlfa();
            dX = 0;
            dY = 0;
            double signdelta = so.Lambda % 30;
            double L1 = so.Lambda - alfa <0 ? so.Lambda - alfa+360: so.Lambda - alfa;
           
            if (signdelta > 0 && signdelta < 5)
            {
                if (L1 > 0 && L1 < 90)
                {
                    dY = 8;
                }
                else if (L1 >= 90 && L1 < 180)
                {
                    dX = 8;
                }
                else if (L1 >= 180 && L1 < 270)
                {
                    dX = 8;
                    dY = -8;
                }
                else if (L1 >= 270 && L1 < 360)
                {
                    dY = 8;
                }
            }
            else if (signdelta > 25 && signdelta < 30)
            {
                if (L1 > 0 && L1 < 90)
                {
                    dX = -8;
                    dY = 8;
                }
                else if (L1 >= 90 && L1 < 180)
                {
                    dY = 8;
                }
                else if (L1 >= 180 && L1 < 270)
                {
                    dX = 8;
                }
                else if (L1 >= 270 && L1 < 360)
                {
                    dY = 8;
                }
            }
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
            if (alfa > 360)
                alfa -= 360;
            if(alfa<0)
                alfa += 360;

            //drow ari
            for (int i=0; i<12; ++i)
            {

                double X1 = _geometry.Center.X - _geometry.RExtCircle * Math.Cos((30 * i - alfa) * Math.PI / 180);
                double Y1 = _geometry.Center.Y + _geometry.RExtCircle * Math.Sin(( 30 * i- alfa ) * Math.PI / 180);

                double X2 = _geometry.Center.X - _geometry.RIntCircle * Math.Cos(( 30 * i-alfa) * Math.PI / 180);
                double Y2 = _geometry.Center.Y + _geometry.RIntCircle * Math.Sin((30 * i-alfa) * Math.PI / 180);

                g.DrawLine(_houses.PenHouses, new PointF((float)X1, (float)Y1), new PointF((float)X2, (float)Y2));
                DrawTerms(g, alfa, i);


                double beta =  30 * i+18 - alfa;
                double R = _geometry.RIntCircle + (_geometry.RExtCircle - _geometry.RIntCircle)*0.6;
                double X3 = _geometry.Center.X- (R-5)* Math.Cos(beta * Math.PI / 180);
                double Y3 = _geometry.Center.Y+(R-5) * Math.Sin(beta * Math.PI / 180);
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
                double X0 = _geometry.Center.X - _geometry.RIntCircle * Math.Cos(( 30 * sign+ aggleshift * i -alfa) * Math.PI / 180);
                double Y0 = _geometry.Center.Y;

                double X1 = X0;
                double Y1 = Y0 + _geometry.RIntCircle * Math.Sin((30 * sign + aggleshift * i - alfa) * Math.PI / 180);

                double X2 = _geometry.Center.X - _geometry.RLimbCircle * Math.Cos(( 30 * sign + aggleshift * i - alfa) * Math.PI / 180);
                double Y2 = Y0 + _geometry.RLimbCircle * Math.Sin(( 30 * sign + aggleshift * i - alfa) * Math.PI / 180);

                Pen pr = i % 2 == 0 ? p : p2;
                g.DrawLine(pr, new PointF((float)X1, (float)Y1), new PointF((float)X2, (float)Y2));
            }
        }
    }
}
