using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public abstract class PanelPainterBase
    {
        protected int _Width;
        protected int _Height;
        public int _Width_Grid_Cell { get; protected set; }
        public  int _Height_Grid_Cell { get; protected set; }
        public List<tPlanetType> _planets { get; protected set; }

        public PanelPainterBase()
        {
            SetSize();
            SetPlanets();
        }

        protected abstract void SetSize();
        protected abstract void SetPlanets();
        public virtual void Draw(Graphics g)
        {
            DrawRectangle(g);
            DrawGrid(g);
        }

        protected void DrawGrid(Graphics g)
        {
            Pen pengrid = new Pen(Brushes.LightGray, 1);
            //Vertical
            for (int i = 1; i <= 13; i++)
            {
                g.DrawLine(pengrid, new Point(i * _Width_Grid_Cell, 0), new Point(i * _Width_Grid_Cell, _Height));
            }
            //Horisontal
            for (int i = (int)(tPlanetType.PT_SUN); i <= (int)(tPlanetType.PT_PLUTO) + 2; i++)
            {
                g.DrawLine(pengrid, new Point(0, (i + 1) * _Height_Grid_Cell), new Point(_Width, (i + 1) * _Height_Grid_Cell));
            }


        }
        protected void DrawRectangle(Graphics g)
        {
            Pen p = new Pen(Brushes.DarkGray, 1);
            g.DrawLine(p, new Point(0, 0), new Point(_Width, 0));
            g.DrawLine(p, new Point(_Width, 0), new Point(_Width, _Height));
            g.DrawLine(p, new Point(_Width, _Height), new Point(0, _Height));
            g.DrawLine(p, new Point(0, _Height), new Point(0, 0));

        }
        protected void DrawPlanetsIcons(Graphics g)
        {
            string sname;
            tPlanetType planet = tPlanetType.PT_NONE;
            for (int i = 0; i < _planets.Count; i++)
            {
                planet = _planets[i];
                sname = Enum.GetName(typeof(tPlanetType), planet).ToString();
                PutImage(g, sname, 5, (i + 1) * _Height_Grid_Cell + 5);
            }
        }
        protected void PutImage(Graphics g, string name, int X, int Y)
        {
            try
            {
                string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\");
                string imagepath = $"{path}{name}.png";
                Image ic = Image.FromFile(imagepath);
                g.DrawImage(ic, X, Y);
            }
            catch
            {

            }
        }
    }
}
