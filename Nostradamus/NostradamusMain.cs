using Nostradamus.AstroMaps;
using Nostradamus.Dialogs;
using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nostradamus
{
    public partial class NostradamusMain : Form
    {
        public NostradamusMain()
        {
            InitializeComponent();
        }

        private void NostradamusMain_Load(object sender, EventArgs e)
        {

        }

        private void OnCreateMapByLastName(object sender, EventArgs e)
        {
            using (dlgCreateMapByLastName dlg = new dlgCreateMapByLastName())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MPersonBase person = dlg.SelectedPerson;
                    dlg.Close();

                    AstroMapPerson map = new AstroMapPerson(person);
                    Graphics g = System.Drawing.Graphics.FromHwnd(panMain.Handle);
                    g.DrawEllipse(Pens.Navy, 100, 100, 400, 400);
                    g.DrawEllipse(Pens.Green, 200, 200, 600, 600);
                }
            }

        }
    }
}
