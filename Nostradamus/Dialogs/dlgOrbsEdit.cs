using Nostradamus.AstroMaps;
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
    public partial class dlgOrbsEdit : Form
    {
        private OrbsCollection Orbs { get; set; }
        private string SystemToEdit { get; set; }
        public dlgOrbsEdit(string systemToEdit)
        {
            InitializeComponent();
            InitMapsTypes();
            InitAspectsTypes();
            SystemToEdit = systemToEdit;
            Orbs = new OrbsCollection(SystemToEdit);

        }
        protected void InitMapsTypes()
        {
            /*            
            RADICAL = 0,
            TRANSIT,
            PROGRESS,
            DIRRECTIVE,
            SOLAR,
            SOLAR_PROGRESS,
            SYNASTRY,
            */
            Dictionary<string, int> maps = new Dictionary<string, int>();
            for (int i = (int)tAstroMapType.RADICAL; i< (int)tAstroMapType.NUMBER_DYNAMIC_TYPES; ++i)
            {
                string maptype = Enum.GetName(typeof(tAstroMapType), i).ToString().ToLower();
                maptype = char.ToUpper(maptype[0]) + maptype.Substring(1);
                maps[maptype] = i;

            }
            cmbKindMap.DataSource = maps;
            cmbKindMap.DisplayMember = "Key";
            cmbKindMap.ValueMember = "Value";

        }
        protected void InitAspectsTypes()
        {
            AspectsCollection adc = new AspectsCollection();
            cmbKindAspect.DataSource = adc._AspectsDataCollection;
            cmbKindMap.DisplayMember = "Name";
            cmbKindMap.ValueMember = "Acronym";

        }
        private void OnSave(object sender, EventArgs e)
        {

        }

        private void OnMapKindChanged(object sender, EventArgs e)
        {

        }

        private void OnAspetTypeChanged(object sender, EventArgs e)
        {

        }
    }
}
