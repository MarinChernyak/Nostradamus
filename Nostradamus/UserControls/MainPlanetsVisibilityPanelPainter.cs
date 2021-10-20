using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public class MainPlanetsVisibilityPanelPainter : PanelPainterPlanetsVisisbilityBase
    {
        protected override void SetPlanets()
        {
            _planets = new tPlanetType[]
            {
            tPlanetType.PT_SUN, tPlanetType.PT_MOON, tPlanetType.PT_MERCURY,tPlanetType.PT_VENUS,tPlanetType.PT_MARS,tPlanetType.PT_JUPITER,
            tPlanetType.PT_SATURN,tPlanetType.PT_URANUS,tPlanetType.PT_NEPTUNE,tPlanetType.PT_PLUTO
            }.ToList();

        }


    }
}
