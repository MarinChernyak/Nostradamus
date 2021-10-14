using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public class OrbsPanelPainter : PanelPainterBase
    {


        public List<string> _aspects { get; }


        public OrbsPanelPainter()
        {
            _aspects = Constants._aspects;
           
        }
        public override void Draw(Graphics g)
        {
            base.Draw(g);
            DrawPlanetsIcons(g);
            DrawAspectsIcons(g);
        }


        protected void DrawAspectsIcons(Graphics g)
        {
            for (int i = 0; i < 13; i++)
            {
                PutImage(g, $"Aspects\\{_aspects[i]}", (i + 1) * _Width_Grid_Cell + 5, 5);
            }
        }
        protected override void SetSize()
        {
            _Width = 420;
            _Height = 390;
            _Width_Grid_Cell = 30;
            _Height_Grid_Cell = 30;
        }

        protected override void SetPlanets()
        {
            _planets = new tPlanetType[]
           {
                tPlanetType.PT_SUN, tPlanetType.PT_MOON, tPlanetType.PT_MERCURY,tPlanetType.PT_VENUS,tPlanetType.PT_MARS,tPlanetType.PT_JUPITER,
                tPlanetType.PT_SATURN,tPlanetType.PT_URANUS,tPlanetType.PT_NEPTUNE,tPlanetType.PT_PLUTO,tPlanetType.PT_FICT_POINTS,tPlanetType.PT_SMALL_BODIES
           }.ToList();
        }
    }
}
