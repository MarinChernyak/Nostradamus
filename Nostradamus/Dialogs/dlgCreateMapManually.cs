using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.Dialogs
{
    public partial class dlgCreateMapManually : Form
    {
        public int Day { get { return manualDate1.Day; } }
        public int Month { get { return manualDate1.Month; } }
        public int Year { get { return manualDate1.Year; } }
        public int Hour { get { return manualDate1.Hour; } }
        public int Min { get { return manualDate1.Min; } }

        public int PLaceId { get { return geoPlaceSelector.GetPlaceId(); } }

        public dlgCreateMapManually()
        {
            InitializeComponent();
            geoPlaceSelector.FillUpCountries();
        }
        private void OnCreateMap(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
