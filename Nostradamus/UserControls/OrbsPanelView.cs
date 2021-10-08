using Nostradamus.AstroMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public partial class OrbsPanelView : UserControl
    {
        private const int _Width = 420;
        private const int _Height = 390;
        private const int _Width_Grid_Cell = 30;
        private  List<string> _aspects;
        public List<PlanetsAspectsOrbsPairsCollection> OrbsData { get; set; }
        public OrbsPanelView()
        {
            InitializeComponent();

            _aspects = new string[]
            {
                "Conjunction","Semisextile","Sextile","Quadro","Trin","Quincunx","Opposition","Quintile","Biquintile","Octile","Trioctile","Decile","Tridecile"
            }.ToList();
        }

        private void OnPaintMain(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panMain.Handle);
            DrawRectangle(g);
            DrawGrid(g);
            DrawPlanetsIcons(g);
            DrawAspectsIcons(g);
            DrawData(g);
        }
        protected void DrawData(Graphics g)
        {
            if(OrbsData != null && OrbsData.Count>0)
            {
                Font f = new Font(FontFamily.GenericSansSerif, 10);

                for (int index= 0; index< OrbsData.Count;  index++)
                {
                    PlanetsAspectsOrbsPairsCollection paoc = OrbsData[index];
                    int counter = 1;
                    for(int j=0; j< paoc.AspectOrbsCollection.Count; ++j)
                    {
                        AspectOrbsPair aop = paoc.AspectOrbsCollection[j];
                        double dVal = aop.OrbValue;
                        float Y = (index + 1) * _Width_Grid_Cell + 5;
                        float X = counter * _Width_Grid_Cell + 5;
                        g.DrawString(dVal.ToString(), f, Brushes.Black, new PointF(X,Y));
                        counter++;
                    }
                }
            }
        }
        protected void DrawGrid(Graphics g)
        {
            Pen pengrid = new Pen(Brushes.LightGray, 1);
            //Vertical
            for (int i = 1; i <= 13; i++)
            {
                g.DrawLine(pengrid, new Point(i * _Width_Grid_Cell,0), new Point( i * _Width_Grid_Cell, _Height));
            }
            //Horisontal
            for (int i = (int)(tPlanetType.PT_SUN); i <= (int)(tPlanetType.PT_PLUTO)+2; i++)
            {
                g.DrawLine(pengrid, new Point(0, (i+1)*_Width_Grid_Cell), new Point(_Width, (i + 1) * _Width_Grid_Cell));
            }


        }
        protected void DrawRectangle(Graphics g)
        {
            Pen p = new Pen(Brushes.DarkGray, 1);
            g.DrawLine(p, new Point(0, 0), new Point(_Width,0));
            g.DrawLine(p, new Point(_Width, 0), new Point(_Width, _Height));
            g.DrawLine(p, new Point(_Width, _Height), new Point(0, _Height));
            g.DrawLine(p, new Point(0, _Height), new Point(0, 0));

        }
        protected void DrawPlanetsIcons(Graphics g)
        {
            string sname;
            tPlanetType planet = tPlanetType.PT_NONE;
            for (int i = (int)(tPlanetType.PT_SUN); i <= (int)(tPlanetType.PT_PLUTO); i++)
            {
                planet = (tPlanetType)i;
                sname = Enum.GetName(typeof(tPlanetType), planet).ToString();
                PutImage(g, sname, 5, (i + 1) * _Width_Grid_Cell + 5);
            }
            sname = Enum.GetName(typeof(tPlanetType), tPlanetType.PT_FICT_POINTS).ToString();
            PutImage(g, sname,5, ((int)(tPlanetType.PT_PLUTO)+2) * _Width_Grid_Cell + 5);
            sname = Enum.GetName(typeof(tPlanetType), tPlanetType.PT_SMALL_BODIES).ToString();
            PutImage(g, sname, 5, ((int)(tPlanetType.PT_PLUTO) + 3) * _Width_Grid_Cell + 5);
        }
        protected void DrawAspectsIcons(Graphics g)
        {
            for (int i = 0; i < 13; i++)
            {
                PutImage(g, $"Aspects\\{_aspects[i]}", (i + 1) * _Width_Grid_Cell + 5, 5);
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
