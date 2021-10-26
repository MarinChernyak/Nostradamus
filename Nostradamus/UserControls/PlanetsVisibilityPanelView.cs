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
        protected tPlanetsGroup _pg { get; set; }
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
        public  void SetData(List<MapPlanetsVisibility> mapPlanetsVisibilityCollection)
        {
            MapPlanetsVisibilityCollection = mapPlanetsVisibilityCollection;
        }
        protected void CreatePainter(tPlanetsGroup pg)
        {
            _pg = pg;
            switch (pg)
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
            if(_painter!=null)
                _painter.Draw(g);
       }
        protected int GetShift()
        {
            int iShift = 0;
            if(_pg==tPlanetsGroup.PG_FICTITIOUS)
            {
                iShift = (int)tPlanetType.PT_TRUE_NODE;
            }
            if(_pg == tPlanetsGroup.PG_SMALL)
            {
                iShift = (int)tPlanetType.PT_CHIRON;
            }
            return iShift;
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


                MapPlanetsVisibilityCollectionProcessor proc = new MapPlanetsVisibilityCollectionProcessor(false)
                {
                    Data = MapPlanetsVisibilityCollection
                };
                int iShift = GetShift();
                proc.ToggleValue((tAstroMapType)map, (tPlanetType)(planet+ iShift));
                Refresh();
            }


        }
    }
}
