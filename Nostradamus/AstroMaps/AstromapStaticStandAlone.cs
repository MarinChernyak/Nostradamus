using Nostradamus.Models;
using Nostradamus.Models.DataFactories;
using NostradamusDAL.Entities;
using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.AstroMaps
{
    public class AstroMapStaticStandAlone : AstroMapStaticStatistical
    {
        protected const float tablerect_height = 25f;
        protected const float tablerect_width = 40f;

        #region graph
        protected Dictionary<int, string> _mapSigns;

        #endregion
        protected AstromapGeometry _geometry { get; set; }
        public AstromapGeometry GetGeometry()
        {
            return _geometry;
        }
        protected AstroMapStaticStandAlone()
        {

        }
        public AstroMapStaticStandAlone(int id)
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
        public AstroMapStaticStandAlone(MPersonBase person)
        {
            if (person != null)
            {
                ID = person.Id;
                Person = person;
                
                CreateMap();
            }
            else
            {
                MessageBox.Show("Unknown error in AstroMapStatic!");
            }


        }
        protected void CreateHouses()
        {
            UserPreferncesDataFactory up = new UserPreferncesDataFactory();
            HousesData hd = up.Data.HousesData;
            char system = 'K';
            if (hd != null && !string.IsNullOrEmpty(hd.SystemID))
            {
                char[] cc = hd.SystemID.ToCharArray();
                system = cc[0];
            }

            _houses = new AMHouses(JD, EventPlace.Longitude, EventPlace.Latitude, system, _geometry);
        }
        protected virtual void CreateGeometry()
        {
            _geometry = new AstromapGeometry();
        }
        protected virtual void CreateMap()
        {
            CreateMapSigns();
            GetEventPlace();
            GetJD();
            CreateGeometry();
            CreateHouses();
            CreateSOCollection();
            Createaspects();
        }
        protected void CreateMapSigns()
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
        #region DRAW

        public void DrawHouses(Graphics g)
        {
            _houses.DrawHouses(g);
        }
        public override void DrawMap(Graphics g)
        {
            DrawHouses(g);
            DrawCircles(g);
            DrawSigns(g);
            DrawPlanets(g);
            DrawAspects(g);
            ProvideMapNotes(g);
        }

        protected void DrawPlanets(Graphics g)
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\StaticObjects\\");

            double alfa = _houses.GelAlfa();
            Icon bbicon = new Icon($"{path}BuletBlue.ico");
            Icon bricon = new Icon($"{path}BuletRed.ico");

            int planetShift = (_geometry.RExtCircle - _geometry.RIntCircle) / 4 + _geometry.RIntCircle;
            const int iNumIntervals = 90;
            int[] iZuz1 = new int[iNumIntervals];
            int[] iZuz2 = new int[iNumIntervals];
            int[] iZuz3 = new int[iNumIntervals];

            foreach (SpaceObjectData sod in _space_objects)
            {
                //New
                int intWidth = 360 / iNumIntervals;
                int index1 = (int)sod._so.Lambda / intWidth;
                double dl = sod._so.Lambda - intWidth / 2;
                if (dl < 0)
                    dl += 360;
                int index2 = (int)(dl / intWidth);
                int index3 = (int)((sod._so.Lambda + intWidth / 2) / intWidth);
                if (index3 >= iNumIntervals)
                    index3 = iNumIntervals - 1;

                string pt = sod._so.PlanetType.ToString();
                double delta = sod._so.Lambda - alfa;
                if (delta < 0)
                    delta += 360;


                int iZuz = Math.Max(iZuz1[index1], iZuz2[index2]);
                iZuz = Math.Max(iZuz, iZuz3[index3]);

                string r = sod._so.SpeedLong < 0 ? "R" : "";
                //Image icon = new Image($"{path}{pt}{r}.png");
                Image ic = Image.FromFile($"{path}{pt}{r}.png");

                double bbx = _geometry.Center.X - _geometry.RLimbCircle * Math.Cos(delta * Math.PI / 180) - _geometry.BULET_SHIFT;
                double bby = _geometry.Center.Y + _geometry.RLimbCircle * Math.Sin(delta * Math.PI / 180) - _geometry.BULET_SHIFT;
                sod._bullet = new PointF((float)bbx, (float)bby);

                Icon bb = sod.IsRed ? bricon : bbicon;
                g.DrawIcon(bb, (int)bbx, (int)bby);

                // - _geometry.BULET_SHIFT*Math.Cos(delta * Math.PI / 180)
                //+ -_geometry.BULET_SHIFT * Math.Sin(delta * Math.PI / 180)
                int planetIconShift = delta > 270 || (delta > 0 && delta < 90) ? _geometry.BULET_SHIFT : 0;
                double px = _geometry.Center.X - planetShift  * (1 + 0.09 * iZuz) * Math.Cos((delta) * Math.PI / 180)- planetIconShift;
                double py = _geometry.Center.Y + planetShift  * (1 + 0.09 * iZuz) * Math.Sin((delta) * Math.PI / 180) - planetIconShift;
                g.DrawImage(ic, (int)px, (int)py);


                iZuz1[index1]++;
                iZuz2[index2]++;
                iZuz3[index3]++;
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
            if (alfa < 0)
                alfa += 360;

            //drow ari
            for (int i = 0; i < 12; ++i)
            {

                double X1 = _geometry.Center.X - _geometry.RExtCircle * Math.Cos((30 * i - alfa) * Math.PI / 180);
                double Y1 = _geometry.Center.Y + _geometry.RExtCircle * Math.Sin((30 * i - alfa) * Math.PI / 180);

                double X2 = _geometry.Center.X - _geometry.RIntCircle * Math.Cos((30 * i - alfa) * Math.PI / 180);
                double Y2 = _geometry.Center.Y + _geometry.RIntCircle * Math.Sin((30 * i - alfa) * Math.PI / 180);

                g.DrawLine(_houses.PenHouses, new PointF((float)X1, (float)Y1), new PointF((float)X2, (float)Y2));
                DrawTerms(g, alfa, i);


                double beta = 30 * i + 18 - alfa;
                double R = _geometry.RIntCircle + (_geometry.RExtCircle - _geometry.RIntCircle) * 0.6;
                double X3 = _geometry.Center.X - (R - 5) * Math.Cos(beta * Math.PI / 180);
                double Y3 = _geometry.Center.Y + (R - 5) * Math.Sin(beta * Math.PI / 180);
                DrawSignsNotations(g, X3, Y3, beta, i);
            }
        }
        protected void DrawSignsNotations(Graphics g, double X, double Y, double beta, int sign)
        {

            Font drawFont = new Font("Wingdings", 12, System.Drawing.FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            GraphicsState state = g.Save();
            g.ResetTransform();
            g.RotateTransform((float)(90 - beta));
            g.TranslateTransform((float)X, (float)Y, MatrixOrder.Append);

            g.DrawString(_mapSigns[sign], drawFont, drawBrush, 0, 0);
            g.Restore(state);
        }
        protected void DrawTerms(Graphics g, double alfa, int sign)
        {
            Pen p = _houses.PenHouses;
            Pen p2 = Pens.Gray;
            int aggleshift = 5;
            for (int i = 0; i < 6; ++i)
            {
                double X0 = _geometry.Center.X - _geometry.RIntCircle * Math.Cos((30 * sign + aggleshift * i - alfa) * Math.PI / 180);
                double Y0 = _geometry.Center.Y;

                double X1 = X0;
                double Y1 = Y0 + _geometry.RIntCircle * Math.Sin((30 * sign + aggleshift * i - alfa) * Math.PI / 180);

                double X2 = _geometry.Center.X - _geometry.RLimbCircle * Math.Cos((30 * sign + aggleshift * i - alfa) * Math.PI / 180);
                double Y2 = Y0 + _geometry.RLimbCircle * Math.Sin((30 * sign + aggleshift * i - alfa) * Math.PI / 180);

                Pen pr = i % 2 == 0 ? p : p2;
                g.DrawLine(pr, new PointF((float)X1, (float)Y1), new PointF((float)X2, (float)Y2));
            }
        }
        protected void DrawAspects(Graphics g)
        {
            if (_aspects != null)
            {
                foreach (Aspect at in _aspects.Aspects)
                {
                    NPTypes.tPlanetType p1 = at.PlanetType1;
                    NPTypes.tPlanetType p2 = at.PlanetType2;

                    SpaceObjectData sod1 = _space_objects.Where(x => x._so.PlanetType == p1).FirstOrDefault();
                    SpaceObjectData sod2 = _space_objects.Where(x => x._so.PlanetType == p2).FirstOrDefault();

                    if (sod1 != null && sod2 != null)
                    {

                        PointF bulet1 = new PointF(sod1._bullet.X + _geometry.BULET_SHIFT, sod1._bullet.Y + _geometry.BULET_SHIFT);
                        PointF bulet2 = new PointF(sod2._bullet.X + _geometry.BULET_SHIFT, sod2._bullet.Y + _geometry.BULET_SHIFT);

                        g.DrawLine(at._aspect_data.GetPen(), bulet1, bulet2);
                    }
                }
            }
        }

        #region DRAW NOTES
        protected float DrawFirstNameNotes(Graphics g, float top_shift)
        {
            Font df = new Font("Arial Black", 18, System.Drawing.FontStyle.Regular);
            SolidBrush db = new SolidBrush(Color.Navy);
            g.DrawString($"{Person.FirstName} {Person.SecondName}", df, db, MapNotesGeometry.LeftMargin, top_shift);
            top_shift += 3 * MapNotesGeometry.LineSpace;
            return top_shift;
        }
        protected float DrawDOPNotes(Graphics g, float top_shift, Font drawFont, SolidBrush drawBrush)
        {

            g.DrawString($"{Person.BirthDay}/{Person.BirthMonth}/{Person.BirthYear}  {EventPlace.CityName} ({EventPlace.CountryData.CountryName})", drawFont, drawBrush, MapNotesGeometry.LeftMargin, top_shift);
            top_shift += 3 * MapNotesGeometry.LineSpace;

            return top_shift;
        }
        protected float DrawCoordinatesNotes(Graphics g, float top_shift, Font drawFont, SolidBrush drawBrush)
        {

            top_shift = DrawSubTitle(g, top_shift, "Coordinates of Planets");

            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\StaticObjects\\");
            foreach (SpaceObjectData sod in _space_objects)
            {
                double Lambda = sod._so.Lambda;
                string r = sod._so.SpeedLong < 0 ? "R" : "";
                string l = String.Format("{0:0.00}", Lambda % 30);
                string sign = _mapSigns[(int)(Lambda / 30)];
                string pt = sod._so.PlanetType.ToString();
                Image ic = Image.FromFile($"{path}{pt}{r}.png");
                g.DrawImage(ic, (int)MapNotesGeometry.LeftMargin, (int)top_shift);
                float left_shift = MapNotesGeometry.LeftMargin + 15f;

                g.DrawString($" = {l} ", drawFont, drawBrush, left_shift, top_shift);
                left_shift = MapNotesGeometry.LeftMargin + 85f;

                Font ds = new Font("Wingdings", 12, System.Drawing.FontStyle.Bold);
                g.DrawString($"{sign}", ds, drawBrush, left_shift, top_shift);
                top_shift += 2 * MapNotesGeometry.LineSpace;
            }
            top_shift += 3 * MapNotesGeometry.LineSpace;
            return top_shift;
        }
        protected float DrawHomesCoordinatesNotes(Graphics g, float top_shift, Font drawFont, SolidBrush drawBrush)
        {

            Font fcnote = new Font("Algerian", 12, System.Drawing.FontStyle.Regular);
            SolidBrush brNotation = new SolidBrush(Color.Black);
            // for signs
            Font ds = new Font("Wingdings", 11, System.Drawing.FontStyle.Regular);
            SolidBrush db = new SolidBrush(Color.Navy);

            top_shift = DrawSubTitle(g, top_shift, "Coordinates of Casps");

            Dictionary<int,string> _notations = _houses.GetNotations();

            for (int i=1; i< 7; i++)
            {
                float L = MapNotesGeometry.LeftMargin;
                g.DrawString(_notations[i], fcnote, brNotation, L , top_shift);

                string scoord = String.Format("{0:0.00}", _houses.GetCusp(i) % 30);
                L += 30;
                g.DrawString($"= {scoord}", drawFont, drawBrush, L, top_shift);

                L += 45;
                string sign = _mapSigns[(int)(_houses.GetCusp(i) / 30)];
                g.DrawString($" {sign}", ds, brNotation, L, top_shift);
                //-------------------
                L += 50;
                g.DrawString(_notations[i+6], fcnote, brNotation, L, top_shift);

                scoord = String.Format("{0:0.00}", _houses.GetCusp(i+6) % 30);
                L += 30;
                g.DrawString($"= {scoord}", drawFont, drawBrush, L, top_shift);
                L += 45;
                sign = _mapSigns[(int)(_houses.GetCusp(i+6) / 30)];
                g.DrawString($" {sign}", ds, brNotation, L, top_shift);

                top_shift += 2 * MapNotesGeometry.LineSpace;

            }
            top_shift += 3 * MapNotesGeometry.LineSpace;
            return top_shift;
        }

        protected void DrawAspectsTable(Graphics g, float top_shift)
        {
            SolidBrush brCovegentive = new SolidBrush(Color.FromArgb(204, 226, 234));
            SolidBrush brNA = new SolidBrush(Color.FromArgb(84, 99, 101));
            top_shift = DrawSubTitle(g, top_shift, "Aspects Table");
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\StaticObjects\\");
            string pathaspect = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\Aspects\\");
            float left_shift = MapNotesGeometry.LeftMargin;
            for (int i = -1; i<_space_objects.Count-1; ++i)
            {
                left_shift = MapNotesGeometry.LeftMargin;
                for (int j =0; j< _space_objects.Count; ++j)
                {
                    if (i < 0 && j==0)
                    {
                        left_shift = DrawRectangle(g, top_shift, left_shift);
                        continue;
                    }
                        
                    left_shift = DrawRectangle(g, top_shift, left_shift);
                    
                    if(i<0)
                    {
                        tPlanetType pt = _space_objects[j]._so.PlanetType;
                        Image ic = Image.FromFile($"{path}{pt}.png");
                        g.DrawImage(ic, (int)left_shift-25, (int)top_shift+5);
                    }
                    else if(j==0)// vertical icons
                    {
                        tPlanetType pt = _space_objects[i]._so.PlanetType;
                        Image ic = Image.FromFile($"{path}{pt}.png");
                        g.DrawImage(ic, (int)left_shift - 25, (int)top_shift + 5);
                    }
                    else if(i<j)
                    {
                        Aspect asp = _aspects.Aspects.Where(x => (x.PlanetType1 == (tPlanetType)i && x.PlanetType2 == (tPlanetType)j)||(x.PlanetType1 == (tPlanetType)j && x.PlanetType2 == (tPlanetType)i)).FirstOrDefault();
                        if (asp != null)
                        {

                            string aspname = asp._aspect_data.Type.ToString().Substring(3);
                            Image aspicon = Image.FromFile($"{pathaspect}{aspname}.png");
                            if (asp.IsConvergative)
                            {
                                g.FillRectangle(brCovegentive, (int)left_shift - tablerect_width+1, (int)top_shift+1, tablerect_width-1, tablerect_height-1);
                            }
                            g.DrawImage(aspicon, (int)left_shift - 25, (int)top_shift + 5);
                        }
                    }
                    else
                    {
                        g.FillRectangle(brNA, (int)left_shift - tablerect_width + 1, (int)top_shift + 1, tablerect_width - 1, tablerect_height - 1);
                    }
                }
                top_shift += tablerect_height;
            }
            
        }
        protected float DrawRectangle(Graphics g, float top_shift, float left_shift)
        {
            float width = tablerect_width;
            float height = tablerect_height;
            Pen p = new Pen(Color.FromArgb(140, 140, 140));
            g.DrawRectangle(p, left_shift, top_shift, width, height);
            return left_shift + width;
        }
        protected float DrawSubTitle(Graphics g, float top_shift, string subtitle)
        {
            Font df = new Font("Calibri", 15, System.Drawing.FontStyle.Bold);
            SolidBrush db = new SolidBrush(Color.Navy);
            g.DrawString(subtitle, df, db, MapNotesGeometry.LeftMargin, top_shift);
            top_shift += 3 * MapNotesGeometry.LineSpace;
            return top_shift;
        }
        protected override void ProvideMapNotes(Graphics g)
        {
            Font drawFont = new Font("Arial", 13, System.Drawing.FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(80, 80, 80));
            MapNotesFactory fact = new MapNotesFactory();
            float top_shift = MapNotesGeometry.TopMargin;

            if (fact.Data.StaticMapNotes.FirstLastName)
            {
                top_shift=DrawFirstNameNotes(g, top_shift);
            }
            if (fact.Data.StaticMapNotes.DOB)
            {
                top_shift = DrawDOPNotes(g, top_shift, drawFont, drawBrush);
            }
            if (fact.Data.StaticMapNotes.Coordinates)
            {
                top_shift = DrawCoordinatesNotes(g, top_shift, drawFont, drawBrush);
            }
            if (fact.Data.StaticMapNotes.Coordinates)
            {
                top_shift=DrawHomesCoordinatesNotes(g, top_shift, drawFont, drawBrush);
            }
            if (fact.Data.StaticMapNotes.Aspects)
            {
                DrawAspectsTable(g, top_shift);
            }

            #endregion

            #endregion
        }
    }
}
