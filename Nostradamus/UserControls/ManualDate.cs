using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.UserControls
{
    public partial class ManualDate : UserControl
    {
        public int Day { get { return (int)numDay.Value; } set { numDay.Value = value;  } }
        public int Year { get { return (int)numYear.Value; } set { numYear.Value = value; } }
        public int Month { get { return Convert.ToInt32(cmbMonths.SelectedValue); } set { cmbMonths.SelectedValue = value; } }
        public int Hour { get { return (int)numHour.Value; } set { numHour.Value = value; } }
        public int Min { get { return (int)numMinutes.Value; } set { numMinutes.Value = value; } }

        public ManualDate()
        {
            InitializeComponent();
            numYear.Maximum = 10000;
            numYear.Minimum = -5000;

            numDay.Minimum = 1;
            numDay.Maximum = 31;

            numHour.Minimum = 0;
            numHour.Maximum = 23;

            numMinutes.Minimum = 0;
            numMinutes.Maximum = 59;

            cmbMonths.DataSource = new BindingSource(Utilities.GetMonthsData(), null);
            cmbMonths.DisplayMember = "Value";
            cmbMonths.ValueMember = "Key";

        }

        private void OnToday(object sender, EventArgs e)
        {
            SetToday();
        }
        public void SetToday()
        {
            DateTime dt = DateTime.Now;
            SetDate(dt);
        }
        public void SetDate(DateTime dt)
        {            
            numDay.Value = dt.Day;
            numHour.Value = dt.Hour;
            numMinutes.Value = dt.Minute;
            numYear.Value = dt.Year;
            cmbMonths.SelectedValue = dt.Month;
        }
    }
}
