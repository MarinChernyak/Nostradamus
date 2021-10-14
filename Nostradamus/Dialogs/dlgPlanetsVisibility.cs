using Nostradamus.AstroMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Dialogs
{
    public partial class dlgPlanetsVisibility : Form
    {
        protected List<MapPlanetsVisibilityCollection> MapPlanetsVisibilityCollection { get; set; }
        protected tPlanetsGroup CurrentPlanetGroup { get; set; }
        public dlgPlanetsVisibility()
        {
            InitializeComponent();

            InitTable();
        }

        protected void InitTable()
        {

        }
        protected MapPlanetsVisibilityCollection GetCollection(tPlanetsGroup pg)
        {
            MapPlanetsVisibilityCollection map = null;
            if (MapPlanetsVisibilityCollection==null)
            {
                MapPlanetsVisibilityCollection = new List<MapPlanetsVisibilityCollection>();
            }

            map = MapPlanetsVisibilityCollection.Where(x => x.PlanetGroup == pg).First();
            if (map == null)
            {
                map = new MapPlanetsVisibilityCollection()
                {
                    PlanetGroup = pg,
                    PlanetsVisibilityCollection = new List<PlanetsVisibility>()
                };
            }
            return map;
        }
        protected void UpdateVisibility(tPlanetsGroup pg , tPlanetType pt)
        {
            MapPlanetsVisibilityCollection map = GetCollection(pg);
            MapPlanetsVisibilityCollectionProcessor proc = new MapPlanetsVisibilityCollectionProcessor(map);
            proc.ToggleValue(pg, pt);
        }
    }
}
