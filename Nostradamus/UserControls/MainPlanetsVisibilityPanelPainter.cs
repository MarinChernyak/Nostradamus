using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public class MainPlanetsVisibilityPanelPainter : PanelPainterBase
    {
        protected List<string> _maps_acr;
        protected override void SetPlanets()
        {
            _planets = new tPlanetType[]
            {
            tPlanetType.PT_SUN, tPlanetType.PT_MOON, tPlanetType.PT_MERCURY,tPlanetType.PT_VENUS,tPlanetType.PT_MARS,tPlanetType.PT_JUPITER,
            tPlanetType.PT_SATURN,tPlanetType.PT_URANUS,tPlanetType.PT_NEPTUNE,tPlanetType.PT_PLUTO
            }.ToList();
            _maps_acr = new List<string>()
            {
                "Natal","Transit","Progress","Direct","Solar", "Solar Pr","Synastry","Horar"
            };
        }

        protected override void SetSize()
        {
            _Height = 330;
            _Width = 550;
            _Height_Grid_Cell = 30;
            _Width_Grid_Cell = 60;
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            DrawPlanetsIcons(g);
            DrawMapsTypes(g);
        }
        protected void DrawMapsTypes(Graphics g)
        {
            Font f = new Font(FontFamily.GenericSansSerif, 10);
            for (int i = 0; i < _maps_acr.Count; i++)
            {
                g.DrawString(_maps_acr[i],f, Brushes.Black, new PointF((i + 1) * _Width_Grid_Cell + 5, 5));
            }            
        }
    }
}
