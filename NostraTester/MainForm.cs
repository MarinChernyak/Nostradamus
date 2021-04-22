using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NostraTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtTestResult.Text = NTesterEngine.StartTest();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
