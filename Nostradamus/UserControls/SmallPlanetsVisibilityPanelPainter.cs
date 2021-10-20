using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.UserControls
{
    public class SmallPlanetsVisibilityPanelPainter : PanelPainterPlanetsVisisbilityBase
    {
        protected override void SetPlanets()
        {
            _planets = new tPlanetType[]
{
                tPlanetType.PT_CHIRON,//15
                tPlanetType.PT_PHOLUS,
                tPlanetType.PT_CERES,
                tPlanetType.PT_PALLAS,
                tPlanetType.PT_JUNO,
                tPlanetType.PT_VESTA,//20

            }.ToList();
        }

    }
}
