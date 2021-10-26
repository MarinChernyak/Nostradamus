using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.UserControls
{
    public partial class NumericInt : UserControl
    {
        public int _Width
        {
            get
            {
                return Width;
            }
            set
            {
                Width = value+2;
                txtNum.Width = value;
            }
        }
        public NumericInt()
        {
            InitializeComponent();
        }

        private void OnKeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = !IsErrorInt(e);
        }
        public bool IsErrorInt(KeyPressEventArgs e)
        {
            bool IsError = true;
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                IsError = false;
            }
            return IsError;
        }

    }
}
