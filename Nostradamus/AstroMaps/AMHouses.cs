using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nostradamus.AstroMaps
{
    public class AMHouses
    {
        protected Houses _houses;
        protected char SystemAcronym;
        protected double[] _houses_draw;
        private Pen _pforHouses;
        public double GelAlfa() { return _houses.GetCusp(1);  }
        private Dictionary<int, string> _notations;
        public Pen PenHouses
        {
            get
            {
                if (_pforHouses == null)
                    _pforHouses = new Pen(Color.Navy, 2);

                return _pforHouses;
            }
        }
        private Pen _pasc;
        protected Pen PenASC
        {
            get
            {
                if (_pasc == null)
                    _pasc = new Pen(Color.Green, 2);

                return _pasc;
            }
        }
        protected AstromapGeometry _geometry;

        public AMHouses(double jd, double longitude, double latitude, char system, AstromapGeometry geometry)
        {
            SystemAcronym = system;
            _geometry = geometry;
            CreateHouses(jd, longitude, latitude, system);
            CreateNotations();
        }
        private void CreateNotations()
        {
            _notations = new Dictionary<int, string>();
            _notations[1] = "Asc";
            _notations[2] = "II";
            _notations[3] = "III";
            _notations[4] = "IC";
            _notations[5] = "V";
            _notations[6] = "VI";
            _notations[7] = "Dsc";
            _notations[8] = "VIII";
            _notations[9] = "IX";
            _notations[10] = "MC";
            _notations[11] = "XI";
            _notations[12] = "XII";

        }
        protected void CreateHouses(double jd, double longitude, double latitude, char system)
        {
            _houses = new Houses(jd, longitude, latitude, system);
        }
        public void DrawHouses(Graphics g)
        {
            double alfa = _houses.GetCusp(1);
            _houses_draw = new double[8];
            _houses_draw[1] = _houses.GetCusp(1) - alfa;
            _houses_draw[2] = _houses.GetCusp(2) - alfa;
            _houses_draw[3] =_houses.GetCusp(3) - alfa;
            _houses_draw[4] =_houses.GetCusp(4) - alfa;
            _houses_draw[5] = _houses.GetCusp(5) - alfa;
            _houses_draw[6] = _houses.GetCusp(6) - alfa;
            //_houses_draw[7] = _houses.GetCusp(7) - alfa;
            //_houses_draw[8] = _houses.GetCusp(8) - alfa;
            //_houses_draw[9] = _houses.GetCusp(9) - alfa;

            _houses_draw[7] = _houses.GetCusp(10) - alfa;
            //_houses_draw[11] = _houses.GetCusp(11) - alfa;
            //_houses_draw[12] = _houses.GetCusp(12) - alfa;

            PointF ptb = new Point();
            PointF pte = new Point();

            for (int i = 1; i < 7; ++i)
            {
                ptb.X = (float)(_geometry.Center.X - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[i] * Math.PI / 180));
                ptb.Y = (float)(_geometry.Center.Y + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[i] * Math.PI / 180)); 
                pte.X = (float)(_geometry.Center.X + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[i] * Math.PI / 180));
                pte.Y = (float)(_geometry.Center.Y - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[i] * Math.PI / 180));

                Pen p = PenHouses;
                if (i == 1)
                {
                    p = PenASC;
                    DrawArrowsAC(g, ptb, pte, i);
                }

                g.DrawLine(p, ptb, pte);
                DrawNotations(g, ptb, pte, i);
            }
            ptb.X = (float)(_geometry.Center.X - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[7] * Math.PI / 180));
            ptb.Y = (float)(_geometry.Center.Y + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[7] * Math.PI / 180));
            pte.X = (float)(_geometry.Center.X + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[7] * Math.PI / 180));
            pte.Y = (float)(_geometry.Center.Y - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[7] * Math.PI / 180));

            DrawArrowsMC(g, ptb, pte, 7);

        }
        protected void DrawArrowsMC(Graphics g, PointF ptb, PointF pte, int house)
        {

            double fi = 90 - _houses_draw[house];

            PointF pte2 = new Point();
            pte2.X = (float)(ptb.X + _geometry.ArrowsLength * Math.Sin((fi + _geometry.ArrowsAngle) * Math.PI / 180));
            pte2.Y = (float)(ptb.Y -  _geometry.ArrowsLength * Math.Cos((fi + _geometry.ArrowsAngle) * Math.PI / 180));
            g.DrawLine(PenASC, ptb, pte2);

            pte2.X = (float)(ptb.X + _geometry.ArrowsLength * Math.Sin((fi - _geometry.ArrowsAngle) * Math.PI / 180));
            pte2.Y = (float)(ptb.Y -  _geometry.ArrowsLength * Math.Cos((fi - _geometry.ArrowsAngle) * Math.PI / 180));
            g.DrawLine(PenASC, ptb, pte2);

            float width = 10.5F;
            float height = 10.5F;
            float x = (float)(pte.X - 5.25);
            float y = (float)(pte.Y - 5.25);
            g.FillEllipse(Brushes.Green, x, y, width, height);

        }
        protected void DrawArrowsAC(Graphics g, PointF ptb, PointF pte, int house)
        {
            double shift = house == 4 ? 180 : 0;
            //int isign1 = house == 1 ? 1 : -1;
            //int isign2 = house == 1 ? -1 : 1;

            double fi = 90- _houses_draw[house];
            
            PointF pte1 = new Point();
            pte1.X = (float)(ptb.X + _geometry.ArrowsLength*Math.Sin((fi - _geometry.ArrowsAngle) * Math.PI / 180));
            pte1.Y = (float)(ptb.Y- _geometry.ArrowsLength*Math.Cos((fi - _geometry.ArrowsAngle) * Math.PI / 180));
            g.DrawLine(PenASC, ptb, pte1);

            pte1.X = (float)(ptb.X + _geometry.ArrowsLength * Math.Sin((fi - _geometry.ArrowsAngle) * Math.PI / 180));
            pte1.Y = (float)(ptb.Y + _geometry.ArrowsLength * Math.Cos((fi - _geometry.ArrowsAngle) * Math.PI / 180));
            g.DrawLine(PenASC, ptb, pte1);

            float width =10.5F;
            float height = 10.5F;
            float x = (float)(pte.X - 5.25);
            float y = (float)(pte.Y - 5.25);
             g.FillEllipse(Brushes.Green,x,y,width,height );    

        }
        protected double NormaliseAngle(double angle)
        {
            if (angle < 0)
                angle += 360;
            if (angle > 360)
                angle -= 360;

            return angle;
        }

        protected void DrawNotations(Graphics g, PointF ptb, PointF pte, int house)
        {
            Font drawFont = new Font("Algerian", 12, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            PointF pt = GetPoint(ptb, house);
            g.DrawString(_notations[house], drawFont, drawBrush, pt.X, pt.Y);
            pt = GetPoint(pte, house+6);
            g.DrawString(_notations[house+6], drawFont, drawBrush, pt.X, pt.Y);
        }
        private PointF GetPoint(PointF pt, int house)
        {
            float X = 0;
            float Y = 0;
            PointF ptf = new Point();
            if (house == 1)
            {
                X = pt.X-10 ;
                Y = pt.Y + 8;
            }
            else if (house > 1 && house < 7)
            {
                X = pt.X + 10;
                Y = pt.Y;
            }
            else if(house ==7)
            {
                X = pt.X-25;
                Y = pt.Y + 8;
            }
            else if (house == 10)
            {
                X = pt.X - 10;
                Y = pt.Y -18;
            }
            else
            {
                X = pt.X -30;
                Y = pt.Y-10;
            }

            ptf.X = X;
            ptf.Y = Y;
            
            return ptf;
        }

    }
}
