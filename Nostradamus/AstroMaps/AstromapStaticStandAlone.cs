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

namespace Nostradamus.AstroMaps
{
    public class AstroMapStaticStandAlone : AstroMapStaticStatistical
    {
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
        #endregion
    }
}
