using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.UserControls
{
    public partial class PlanetsVisibilityPanelView : UserControl
    {
        protected MainPlanetsVisibilityPanelPainter _painter;
        public PlanetsVisibilityPanelView()
        {
            InitializeComponent();
        }

        private void OnPaintMain(object sender, PaintEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panMain.Handle);
            _painter = new MainPlanetsVisibilityPanelPainter();
            _painter.Draw(g);
            //DrawData(g);
        }

        private void OnDoubleClickPanel(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;

            int X = me.X;
            int Y = me.Y;

            int planet = Y / _painter._Height_Grid_Cell - 1;
            int map = X / _painter._Width_Grid_Cell - 1;


        }
    }
}
