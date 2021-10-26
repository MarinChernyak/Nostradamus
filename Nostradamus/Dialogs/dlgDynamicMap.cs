using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Dialogs
{
    public partial class dlgDynamicMap : Form
    {
        const string ds1 = "1 hour";
        const string ds2 = "1 day";
        const string ds3 = "1 week";
        const string ds4 = "1 month";
        const string ds5 = "1 year";

        private Dictionary<string, tAstroMapType> DynMapsTypes;// = new string[] { "Transit", "Progressions", "Directions" };
        private string[] DynStep = new string[] { ds1,ds2,ds3,ds4,ds5 };
        public NostradamusMain MyParent { get; set; }
        public int Day
        {
            get
            {
                return (int)numDay.Value;
            }
             set
            {
                if (ValidateDayValue(value))
                    numDay.Value = value;
            }
                
         }
       
        protected bool ValidateDayValue(int value)
        {
            bool isOK = false;
            DateTime dt = new DateTime((int)numYear.Value, (int)cmbMonths.SelectedValue, value);

            return isOK;
        }
        public dlgDynamicMap()
        {
            InitializeComponent();

            numYear.Maximum = 10000;
            numYear.Minimum = -5000;
            numYear.Value = 2000;

            numDay.Minimum = 1;
            numDay.Maximum = 31;
            numDay.Value = 1;

            numHour.Minimum = 0;
            numHour.Maximum = 23;
            numHour.Value = 12;

            numMinutes.Minimum = 0;
            numMinutes.Maximum = 59;
            numMinutes.Value = 0;

            cmbMonths.DataSource = new BindingSource( Utilities.GetMonthsData(),null);
            cmbMonths.DisplayMember = "Key";
            cmbMonths.ValueMember = "Value";

            DynMapsTypes = new Dictionary<string, tAstroMapType>();
            DynMapsTypes["Transit"] = tAstroMapType.TRANSIT;
            DynMapsTypes["Progressions"] = tAstroMapType.PROGRESSIVE;
            DynMapsTypes["Directions"] = tAstroMapType.DIRRECTIVE;
            cmbDynamicMapType.DataSource = new BindingSource(DynMapsTypes, null); ;
            cmbDynamicMapType.DisplayMember = "Key";
            cmbDynamicMapType.ValueMember = "Value";

            cmbDynamicStep.DataSource = DynStep;



        }
        protected void RecalculateDynamic(DateTime dt)
        {
            tAstroMapType t = (tAstroMapType)Convert.ToInt32(cmbDynamicMapType.SelectedValue);
            MDynamicMapUpdateInfo info = new MDynamicMapUpdateInfo()
            {
                MapType = t,
                DynamicDate = dt,
                IdStatic=0
            };
            MyParent.UpdateMap(info);
        }
        private void OnDayChanged(object sender, EventArgs e)
        {

        }

        private void OnExit(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void OnBack(object sender, EventArgs e)
        {
            DateTime dt = GetCalculatedData(-1);
            RecalculateDynamic(dt);
        }
        protected DateTime GetCalculatedData(int step)
        {
            int Day = (int)numDay.Value;
            int Month = Convert.ToInt32(cmbMonths.SelectedValue);
            int Year = (int)numYear.Value;
            int H = (int)numHour.Value;
            int M = (int)numMinutes.Value;

            DateTime dt = new DateTime(Year, Month, Day, H, M, 0);
            string factor = cmbDynamicStep.SelectedValue.ToString();

            switch (factor)
            {
                case ds1:
                    dt = dt.AddHours(step);
                    break;
                case ds2:
                    dt = dt.AddDays(step);
                    break;
                case ds3:
                    dt = dt.AddDays(step*7);
                    break;
                case ds4:
                    dt = dt.AddMonths(step);
                    break;
                case ds5:
                    dt = dt.AddYears(step);
                    break;
            };
            numDay.Value = dt.Day;
            cmbMonths.SelectedValue = dt.Month;
            numYear.Value = dt.Year;
            numHour.Value = dt.Hour;
            numMinutes.Value = dt.Minute;
                
            return dt;
        }
        private void OnFront(object sender, EventArgs e)
        {
            DateTime dt = GetCalculatedData(1);
            RecalculateDynamic(dt);
        }

        private void OnMapTypeKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OnDynamicStepKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void OnRecalculate(object sender, EventArgs e)
        {

            DateTime dt = GetCalculatedData(0);
            RecalculateDynamic(dt);
        }


    }
}
