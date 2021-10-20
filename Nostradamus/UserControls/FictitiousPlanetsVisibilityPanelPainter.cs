using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    class FictitiousPlanetsVisibilityPanelPainter : PanelPainterPlanetsVisisbilityBase
    {
        protected override void SetPlanets()
        {
            _planets = new tPlanetType[]
            {
            tPlanetType.PT_TRUE_NODE, tPlanetType.PT_MEAN_APOG
            }.ToList();
        }
    }
}
