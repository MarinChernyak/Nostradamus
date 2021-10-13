using Nostradamus.AstroMaps;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Dialogs
{
    public partial class dlgOrbsEdit : Form
    {
        public double OrbValue { get { return Convert.ToDouble(txtOrbValue.Text); } }
        public bool SameDown { get; set; }
        public dlgOrbsEdit(string planet, string aspect, double value)
        {
            InitializeComponent();
            txtOrbValue.Text = value.ToString();
            lblPlanetData.Text = planet;
            lblSelAspectData.Text = aspect;
            SameDown = chDown.Checked;
        }

        private void OnValueKeyDown(object sender, KeyEventArgs e)
        {

          

        }

        private void OnCancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void OnOK(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void chDown_CheckedChanged(object sender, EventArgs e)
        {
            SameDown = chDown.Checked;
        }

        private void OnValuePressed(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
            //if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (e.KeyChar == '.')
            //{
            //    if (txtOrbValue.Text.IndexOf('.') < 0)
            //    {
            //        e.Handled = false;
            //    }
            //}
            e.Handled = Utilities.IsErrorDouble(e, txtOrbValue.Text);
        }
    }
}
