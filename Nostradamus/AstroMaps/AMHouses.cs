﻿using NostraPlanetarium;
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
        }
        protected void CreateHouses(double jd, double longitude, double latitude, char system)
        {
            _houses = new Houses(jd, longitude, latitude, system);
        }
        public void DrawHouses(Graphics g)
        {
            double alfa = _houses.GetCusp(1) - 360;
            _houses_draw = new double[13];
            _houses_draw[1] = NormaliseAngle(_houses.GetCusp(1) - alfa);
            _houses_draw[2] = NormaliseAngle(_houses.GetCusp(2) - alfa);
            _houses_draw[3] = NormaliseAngle(_houses.GetCusp(3) - alfa);
            _houses_draw[4] = NormaliseAngle(_houses.GetCusp(4) - alfa);
            _houses_draw[5] = NormaliseAngle(_houses.GetCusp(5) - alfa);
            _houses_draw[6] = NormaliseAngle(_houses.GetCusp(6) - alfa);
            _houses_draw[7] = NormaliseAngle(_houses.GetCusp(7) - alfa);
            _houses_draw[8] = NormaliseAngle(_houses.GetCusp(8) - alfa);
            _houses_draw[9] = NormaliseAngle(_houses.GetCusp(9) - alfa);

            _houses_draw[10] = NormaliseAngle(_houses.GetCusp(10) - alfa);
            _houses_draw[11] = NormaliseAngle(_houses.GetCusp(11) - alfa);
            _houses_draw[12] = NormaliseAngle(_houses.GetCusp(12) - alfa);

            PointF ptb = new Point();
            PointF pte = new Point();

            for (int i = 1; i < 7; ++i)
            {
                ptb.X = (float)(_geometry.Center.X - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[i] * Math.PI / 180));
                ptb.Y = (float)(_geometry.Center.Y + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[i] * Math.PI / 180)); 
                pte.X = (float)(_geometry.Center.X + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[i] * Math.PI / 180));
                pte.Y = (float)(_geometry.Center.Y - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[i] * Math.PI / 180));

                Pen p = PenHouses;
                if (i == 1 || i==4)
                {
                    p = PenASC;
                    if(i==1)
                        DrawArrows(g, ptb, pte, i);
                }

                g.DrawLine(p, ptb, pte);
            }
            ptb.X = (float)(_geometry.Center.X - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[10] * Math.PI / 180));
            ptb.Y = (float)(_geometry.Center.Y + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[10] * Math.PI / 180)); 
            pte.X = (float)(_geometry.Center.X + (_geometry.RExtCircle + _geometry.HouseShift) * Math.Cos(_houses_draw[10] * Math.PI / 180));
            pte.Y = (float)(_geometry.Center.Y - (_geometry.RExtCircle + _geometry.HouseShift) * Math.Sin(_houses_draw[10] * Math.PI / 180));

            DrawArrows(g, ptb, pte, 10);

        }
        protected void DrawArrows(Graphics g, PointF ptb, PointF pte, int house)
        {
            double beta = house == 10 ? 180 : 0;
            PointF pte1 = new Point();
            pte1.X = (float)(ptb.X+_geometry.ArrowsLength*Math.Sin((beta+90 - _houses_draw[house]- _geometry.ArrowsAngle) * Math.PI / 180));
            pte1.Y = (float)(ptb.Y+_geometry.ArrowsLength*Math.Cos((beta+90 - _houses_draw[house] - _geometry.ArrowsAngle) * Math.PI / 180));
            g.DrawLine(PenASC, ptb, pte1);
            pte1.X = (float)(ptb.X + _geometry.ArrowsLength * Math.Cos((beta+_houses_draw[house] - _geometry.ArrowsAngle) * Math.PI / 180));
            pte1.Y = (float)(ptb.Y + _geometry.ArrowsLength * Math.Sin((beta+ _houses_draw[house] - _geometry.ArrowsAngle) * Math.PI / 180));
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
    }
}
