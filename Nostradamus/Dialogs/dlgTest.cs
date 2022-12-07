using NostraPlanetarium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.Dialogs
{
    public partial class dlgTest : Form
    {
        public dlgTest()
        {
            InitializeComponent();
        }

        private void butCalc_Click(object sender, EventArgs e)
        {
            JulianDay JD1 = new JulianDay(1,1,2001,0,0,0,0,0);
            DateTime zeroTime = new DateTime(1, 1, 1);
            JulianDay JD2 = new JulianDay(1, 1, 2014, 0, 0, 0, 0, 0);
            double ydays = JD2.JD - JD1.JD;
            double yesr = ydays / 365.25;
            //DateTime dt2= JD2.FromJDtoDate();
            //DateTime dt1 = JD1.FromJDtoDate();
            //var days= (dt2 -dt1).Days;
            //TimeSpan span = dt2 - dt1;
            //double ydays = 365; 
            //int years = (zeroTime + span).Year - 1;
            //if (years % 4 == 0)
            //    ydays = 365.25;
            //double yesr = days/ ydays;
            //DateTime dt = JD.FromJDtoDate();
            //lblDate.Text = $"{dt.Day}/{dt.Month}/{dt.Year}  {dt.Hour}:{dt.Minute}:{dt.Second}";
        }

        private void dlgTest_Load(object sender, EventArgs e)
        {

        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
