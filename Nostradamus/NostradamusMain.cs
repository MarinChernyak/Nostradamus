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
        protected UserPreferenses _userpref;
        protected List<AstroMapBase> _maps;
        public NostradamusMain()
        {
            _maps = new List<AstroMapBase>();
            InitializeComponent();
        }
        
        private void NostradamusMain_Load(object sender, EventArgs e)
        {
            _userpref = new UserPreferenses();
            SetStausBar();
        }
        protected void SetStausBar()
        {
            if (_userpref.SelectedHousesSystem != null)
            {
                mnuStatusHouses.Text = $"Houses System: {_userpref.SelectedHousesSystem.SystemName}";
            }
        }
        private void OnCreateMapByLastName(object sender, EventArgs e)
        {
            MPersonBase person = null;
            using (dlgCreateMapByLastName dlg = new dlgCreateMapByLastName())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    person = dlg.SelectedPerson;
                    dlg.Close();
                }
            }
            if (person != null)
            {
                TabPage tp = UpdateTab(person.Id);

                AstroMapPerson map = new AstroMapPerson(person);
                _maps.Add(map);
                
                //tabMapsCollection.SelectedTab.Invalidate();
            }       

        }
        private TabPage UpdateTab(int id)
        {

            TabPage tp = new TabPage($"Map #{id}");
            tp.Tag = id;
            tabMapsCollection.TabPages.Add(tp);
            tabMapsCollection.SelectedTab = tp;
            tp.CausesValidation = false;
            tabMapsCollection.SelectedTab.Paint += new PaintEventHandler(TabPagePaint);
            return tabMapsCollection.SelectedTab;
        }
        protected void TabPagePaint(object sender, PaintEventArgs e)
        {
            int id = (int)((TabPage)sender).Tag;
            AstroMapBase map = _maps.Where(x => x.ID == id).FirstOrDefault();
            if (map != null)
            {
                Graphics g = Graphics.FromHwnd(tabMapsCollection.SelectedTab.Handle);
                map.DrawMap(g);
            }
        }
        private void ClearPanel()
        {
            SolidBrush white = new SolidBrush(Color.White);
            Graphics g = System.Drawing.Graphics.FromHwnd(tabMapsCollection.TabPages[0].Handle);
            g.FillRectangle(white, tabMapsCollection.TabPages[0].Location.X, tabMapsCollection.TabPages[0].Location.Y, tabMapsCollection.TabPages[0].Width, tabMapsCollection.TabPages[0].Height);
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
            Graphics g = System.Drawing.Graphics.FromHwnd(tabMapsCollection.TabPages[0].Handle);
            map.DrawMap(g);
        }

        private void NostradamusMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _userpref.Save();
        }

        private void AddNewMap_Click(object sender, EventArgs e)
        {

            TabPage tp = new TabPage($"Map #...");
            tabMapsCollection.TabPages.Add(tp);
            tabMapsCollection.SelectedTab = tp;
        }

        private void deleteMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = tabMapsCollection.SelectedTab;
            tabMapsCollection.TabPages.Remove(tp);
        }

        private void OnCreateMapById(object sender, EventArgs e)
        {
            MPersonBase person = null;
            using (dlgCreateMapByID dlg = new dlgCreateMapByID())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    person = dlg.Person;
                }
            }
            if (person != null)
            {
                TabPage tp = UpdateTab(person.Id);

                AstroMapPerson map = new AstroMapPerson(person);
                _maps.Add(map);
            }

        }

        private void OnCreateMapByKeyword(object sender, EventArgs e)
        {
            MVwPeopleKeyWord person = null;
            using (dlgCreateMapByKW dlg = new dlgCreateMapByKW())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    person = dlg.SelectedPerson;
                }
            }
            if (person != null)
            {
                AstroMapPerson map = new AstroMapPerson(person.IdPerson);
                _maps.Add(map);
                TabPage tp = UpdateTab(person.IdPerson);
            }
        }

        private void setHouses_Click(object sender, EventArgs e)
        {
            HousesData selectedsys = null;
            using (dlgHousesSystems dlg = new dlgHousesSystems(_userpref.SelectedHousesSystem))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    selectedsys = dlg.SelectedSystem;
                    if (selectedsys!=null && !string.IsNullOrEmpty(selectedsys.SystemID) && !string.IsNullOrEmpty(selectedsys.SystemName))
                    {

                        _userpref.SelectedHousesSystem = selectedsys;
                        _userpref.Save();

                    }
                }
            }
        }

        private void OnOrbsClicked(object sender, EventArgs e)
        {
            //HousesData selectedsys = null;
            using (dlgOrbsSystem dlg = new dlgOrbsSystem())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }

        private void OnClickObjectsVisibility(object sender, EventArgs e)
        {
            using (dlgPlanetsVisibility dlg = new dlgPlanetsVisibility())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                }
            }
        }
    }
}
