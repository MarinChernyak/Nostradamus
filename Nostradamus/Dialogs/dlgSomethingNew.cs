using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.Dialogs
{
    public partial class dlgSomethingNew : Form
    {
        public string NewValue 
        { 
            get
            {
                return textNewVal.Text;
            } 
        }
        public dlgSomethingNew(string whatsNew)
        {
            InitializeComponent();
            lblNew.Text = $"Enter a new {whatsNew}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblNew.Text))
                DialogResult = DialogResult.Cancel;
            else
                DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
