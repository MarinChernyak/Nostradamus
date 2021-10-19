using Nostradamus.AstroMaps;
using Nostradamus.Models.DataProcessors;
using Nostradamus.Models.XMLSerializers;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Dialogs
{
    public partial class dlgPlanetsVisibility : Form
    {
        protected List<GroupMapPlanetsVisibilityCollection> GroupMapPlanetsVisibilityCollectionLst { get; set; }
        protected tPlanetsGroup CurrentPlanetGroup { get; set; }
        public dlgPlanetsVisibility()
        {
            InitializeComponent();
            InitGroupVisibilityCollection();
            InitPanels();
            InitTable();
        }
        protected void InitGroupVisibilityCollection()
        {
            PlanetsVisibilitySerializer ser = new PlanetsVisibilitySerializer();
            GroupMapPlanetsVisibilityCollectionLst = ser.LstGroupMapPlanetsVisibilityCollection;
        }
        protected void InitPanels()
        {
            pvMain.InitPanel(tPlanetsGroup.PG_MAIN);
            pvFict.InitPanel(tPlanetsGroup.PG_FICTITIOUS);
            pvSmall.InitPanel(tPlanetsGroup.PG_SMALL);
        }
        protected void UpdateViewPanel()
        {
            UserControls.PlanetsVisibilityPanelView opv = null;
            switch (CurrentPlanetGroup)
            {
                case tPlanetsGroup.PG_MAIN:
                    opv = pvMain;
                    break;
                case tPlanetsGroup.PG_FICTITIOUS:
                    opv = pvFict;
                    break;
                case tPlanetsGroup.PG_SMALL:
                    opv = pvSmall;
                    break;
            };

            if (opv != null)
            {
                GroupMapPlanetsVisibilityCollection gmp = GroupMapPlanetsVisibilityCollectionLst.Where(x => x.PlanetGroup == CurrentPlanetGroup).FirstOrDefault();
                if (gmp != null)
                {
                    opv.MapPlanetsVisibilityCollection = gmp.MapPlanetsVisibilityCollection;
                }
                opv.Refresh();
            }
        }

        protected void InitTable()
        {

        }
        protected GroupMapPlanetsVisibilityCollection GetCollection(tPlanetsGroup pg)
        {
            GroupMapPlanetsVisibilityCollection gmpvc = GroupMapPlanetsVisibilityCollectionLst.Where(x => x.PlanetGroup == pg).First();
            return gmpvc;
        }
        protected void UpdateVisibility(tPlanetsGroup pg, tAstroMapType mt, tPlanetType pt)
        {
            GroupMapPlanetsVisibilityCollection gmpvc = GroupMapPlanetsVisibilityCollectionLst.Where(x => x.PlanetGroup == pg).First();
            MapPlanetsVisibilityCollectionProcessor proc = new MapPlanetsVisibilityCollectionProcessor();
            proc.MapPlanetsVisibilityCollection = gmpvc.MapPlanetsVisibilityCollection;
            proc.ToggleValue(mt,pt);
        }
    }
}
