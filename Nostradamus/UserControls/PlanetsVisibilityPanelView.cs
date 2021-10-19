using Nostradamus.AstroMaps;
using Nostradamus.Models.DataProcessors;
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
    public partial class PlanetsVisibilityPanelView : UserControl
    {
        public List<MapPlanetsVisibility> MapPlanetsVisibilityCollection { get; set; }

        protected PanelPainterPlanetsVisisbilityBase _painter;
        public PlanetsVisibilityPanelView()
        {
            InitializeComponent();
            
        }
        public void InitPanel(tPlanetsGroup pg)
        {
            CreatePainter(pg); 
        }
        protected void CreatePainter(tPlanetsGroup pg)
        {
            switch(pg)
            {
                case tPlanetsGroup.PG_MAIN:
                    _painter = new MainPlanetsVisibilityPanelPainter();
                  
                    break;
                case tPlanetsGroup.PG_FICTITIOUS:
                    _painter = new FictitiousPlanetsVisibilityPanelPainter();
                    break;
                case tPlanetsGroup.PG_SMALL:
                    _painter = new SmallPlanetsVisibilityPanelPainter();
                    break;
                default:
                    _painter = new MainPlanetsVisibilityPanelPainter();
                    break;
            };
            _painter.MapPlanetsVisibilityCollection = MapPlanetsVisibilityCollection;
        }
        private void OnPaintMain(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panMain.Handle);
            _painter.Draw(g);
       }

        private void OnDoubleClickPanel(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;

            int X = me.X;
            int Y = me.Y;
            int count = MapPlanetsVisibilityCollection[0].PlanetsVisibilityList.Count;

            if (Y <= (count + 1) * _painter._Height_Grid_Cell)
            {
                int planet = Y / _painter._Height_Grid_Cell - 1;

                int map = X / _painter._Width_Grid_Cell - 1;


                MapPlanetsVisibilityCollectionProcessor proc = new MapPlanetsVisibilityCollectionProcessor()
                {
                    MapPlanetsVisibilityCollection = MapPlanetsVisibilityCollection
                };
                proc.ToggleValue((tAstroMapType)map, (tPlanetType)planet);
                Refresh();
            }


        }
    }
}
