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
        protected UserPreferenses _userpref;
        private void NostradamusMain_Load(object sender, EventArgs e)
        {
            _userpref = new UserPreferenses();
            _userpref.GetPrefernces();
        }

        private void OnCreateMapByLastName(object sender, EventArgs e)
        {
            using (dlgCreateMapByLastName dlg = new dlgCreateMapByLastName())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MPersonBase person = dlg.SelectedPerson;
                    dlg.Close();
                    ClearPanel();
                    AstroMapPerson map = new AstroMapPerson(person);
                    Graphics g = System.Drawing.Graphics.FromHwnd(panMain.Handle);
                    map.DrawMap(g);

                }
            }

        }
        private void ClearPanel()
        {
            SolidBrush white = new SolidBrush(Color.White);
            Graphics g = System.Drawing.Graphics.FromHwnd(panMain.Handle);
            g.FillRectangle(white, panMain.Location.X, panMain.Location.Y, panMain.Width, panMain.Height);
        }

        private void testMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPersonBase person = new MPersonBase()
            {
                BirthDay = 1,
                BirthHourFrom = 1,
                AdditionalHours = 1,
                BirthHourTo = 2,
                BirthMinFrom = 1,
                BirthMinTo = 2,
                BirthMonth = 1,
                BirthSecFrom = 0,
                BirthSecTo = 0,
                BirthYear = 2000,
                FirstName = "Vasya",
                SecondName = "Pupkind",
                Place = 2
            };
            AstroMapPerson map = new AstroMapPerson(person);
            Graphics g = System.Drawing.Graphics.FromHwnd(panMain.Handle);
            map.DrawMap(g);
        }

        private void NostradamusMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _userpref.SavePreferenses();
        }
    }
}
