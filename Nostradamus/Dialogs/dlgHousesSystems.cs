using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.Dialogs
{
    public partial class dlgHousesSystems : Form
    {
        public HousesData SelectedSystem { get; protected set; }
        private List<HousesData> _lstSystems;
        public dlgHousesSystems(HousesData selected)
        {
            InitializeComponent();
            InitSystemsList(selected);
            
        }
        protected void InitSystemsList(HousesData selected)
        {
            bool enablebuttons = false;
            CreateSystemDataList();
            lstHouses.DataSource = _lstSystems;
            lstHouses.DisplayMember = "SystemName";
            lstHouses.ValueMember = "SystemID";
            if(selected !=null)
            {
                lstHouses.SelectedValue = selected.SystemID;
                enablebuttons = true;
            }
            SetButtonsEnabled(enablebuttons);
        }
        protected void CreateSystemDataList()
        {
            _lstSystems = new List<HousesData>();
            _lstSystems.Add(new HousesData()
            {
                SystemID = "P",
                SystemName = "Placidus",
                SystemRef = "This system of  houses cusps cannot be computed beyond the polar circle. In such cases, Nostardamus switches to Porphyry houses (each quadrant is divided into three equal parts).\nThe choosen system is named after the Italian monk Placidus de Titis (1590-1668). The cusps are defined by divisions of semidiurnal and seminocturnal arcs. The 11th cusp is the point on the ecliptic that has completed 2/3 of its semidiurnal arc, the 12th cusp the point that has completed 1/3 of it. The 2nd cusp has completed 2/3 of its seminocturnal arc, and the 3rd cusp 1/3. "

            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "K",
                SystemName = "Koch",
                SystemRef = "This system is called after the German astrologer Walter Koch (1895-1970)."

            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "O",
                SystemName = "Porphyrius",
                SystemRef = "This system is called after the Porphyrius, who described it on III c.ac."

            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "R",
                SystemName = "Regiomontanus",
                SystemRef = "The system named after the Johannes Müller (called \"Regiomontanus\" 1436-1476). The equator is divided into 12 equal parts and great circles are drawn through these divisions and the north and south points on the horizon. The intersection points of these circles with the ecliptic are the house cusps."

            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "C",
                SystemName = "Campanus",
                SystemRef = "The system named after Giovanni di Campani (1233-1296).\nThe vertical great circle from east to west is divided into 12 equal parts and great circles are drawn through these divisions and the north and south points on the horizon. The intersection points of these circles with the ecliptic are the house cusps."

            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "E",
                SystemName = "Equal (cusp 1 is Ascendant)",
                SystemRef = "The Zodiac is divided into 12 houses of 30 degrees each starting from the Ascendant."
            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "V",
                SystemName = "Vehlow equal (Asc. in middle of house 1)",
                SystemRef = "Equal houses with the Ascendant positioned in the middle of the first house."
            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "X",
                SystemName = "Axial rotation system",
                SystemRef = "Equal houses with the Ascendant positioned in the middle of the first house."
            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "H",
                SystemName = "Azimuthal or horizontal system",
                SystemRef = "Also called the \"Meridian house system\". The equator is partitioned into 12 equal parts starting from the ARMC. Then the ecliptic points are computed that have these divisions as their rectascension.\nThe house cusps are defined by division of the horizon into 12 directions. The first house cusp is not identical with the Ascendant but is located precisely in the east."
            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "T",
                SystemName = "Polich/Page (\"topocentric\" system)",
                SystemRef = "The \"topocentric\" house cusps are close to Placidus house cusps except for high geographical latitudes."
            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "B",
                SystemName = "Alcabitus",
                SystemRef = "A method of house division named for Alcabitius, an Arab, who is supposed to have lived in the 1st century A.D. The MC and ASC are respectively the 10th- and 1st- house cusps. The remaining cusps are determined by the trisection of the semidiurnal and seminocturnal arcs of the ascendant, measured on the celestial equator. The houses are formed by the great circles that pass through these trisection points on the equator and the North and South points of the Horizon."
            });
            _lstSystems.Add(new HousesData()
            {
                SystemID = "G",
                SystemName = "Gauquelin sectors",
                SystemRef = "A method of house division named for Alcabitius, an Arab, who is supposed to have lived in the 1st century A.D. The MC and ASC are respectively the 10th- and 1st- house cusps. The remaining cusps are determined by the trisection of the semidiurnal and seminocturnal arcs of the ascendant, measured on the celestial equator. The houses are formed by the great circles that pass through these trisection points on the equator and the North and South points of the Horizon."
            });
            _lstSystems = _lstSystems.OrderBy(x => x.SystemName).ToList();
        }

        private void OnSystemChanged(object sender, EventArgs e)
        {
            HousesData hd = lstHouses.SelectedItem as HousesData;
            if(hd!=null)
            {
                SelectedSystem = hd;
                txtSelected.Text = hd.SystemName;
            }
            SetButtonsEnabled(!string.IsNullOrEmpty(hd.SystemName));
        }
        protected void SetButtonsEnabled(bool isEnabled)
        {
            btnOK.Enabled = isEnabled;
            btnHelp.Enabled = isEnabled;
        }
        private void OnHelp(object sender, EventArgs e)
        {
            HousesData hd = lstHouses.SelectedItem as HousesData;
            if (hd != null)
            {
                MessageBox.Show(hd.SystemRef, $"The system of {hd.SystemName} means",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void OnOK(object sender, EventArgs e)
        {
            HousesData hd = lstHouses.SelectedItem as HousesData;
            if (hd != null)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
