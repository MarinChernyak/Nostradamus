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

       

        public dlgDynamicMap()
        {
            InitializeComponent();

            DynMapsTypes = new Dictionary<string, tAstroMapType>();
            DynMapsTypes["Transit"] = tAstroMapType.TRANSIT;
            DynMapsTypes["Progressions"] = tAstroMapType.PROGRESSIVE;
            DynMapsTypes["Directions"] = tAstroMapType.DIRRECTIVE;
            cmbDynamicMapType.DataSource = new BindingSource(DynMapsTypes, null); ;
            cmbDynamicMapType.DisplayMember = "Key";
            cmbDynamicMapType.ValueMember = "Value";

            cmbDynamicStep.DataSource = DynStep;
            manualDate1.SetToday();


        }
        protected void RecalculateDynamic(DateTime dt)
        {
            tAstroMapType t = (tAstroMapType)Convert.ToInt32(cmbDynamicMapType.SelectedValue);
            MDynamicMapUpdateInfo info = new MDynamicMapUpdateInfo()
            {
                MapType = t,
                DynamicDate = dt
            };
            MyParent.UpdateMap(info);
        }
        private void OnDayChanged(object sender, EventArgs e)
        {

        }

        private void OnExit(object sender, EventArgs e)
        {
            if(MessageBox.Show("Would you like to return to natal map? If you press 'No', the dynamic map will be hanging on","Please provide your choise",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                MyParent.ResetStatic();
            }
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
            int Day = manualDate1.Day;
            int Month = manualDate1.Month;
            int Year = manualDate1.Year;
            int H = manualDate1.Hour;
            int M = manualDate1.Min;

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
            manualDate1.Day = dt.Day;
            manualDate1.Month = dt.Month;
            manualDate1.Year = dt.Year;
            manualDate1.Hour = dt.Hour;
            manualDate1.Min= dt.Minute;
                
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
