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
        private AspectType _AspectType { get; set; }
        private tAstroMapType _MapType { get; set; }
        private OrbsCollection Orbs { get; set; }
        private string SystemToEdit { get; set; }
        public dlgOrbsEdit(string systemToEdit)
        {
            InitializeComponent();
            InitMapsTypes();
            InitAspectsTypes();
            textSystemName.Text = systemToEdit;
            textSystemName.ReadOnly = true;
            Orbs = new OrbsCollection(SystemToEdit);
            SetupPlanetsImages();

        }
        public dlgOrbsEdit()
        {
            InitializeComponent();
            InitMapsTypes();
            InitAspectsTypes();
            SetupPlanetsImages();
            Orbs = new OrbsCollection();

        }
        protected void InitMapsTypes()
        {
            /*            
            NATAL = 0,
            TRANSIT,
            PROGRESS,
            DIRRECTIVE,
            SOLAR,
            SOLAR_PROGRESS,
            SYNASTRY,
            */
            Dictionary<string, int> maps = new Dictionary<string, int>();
            for (int i = (int)tAstroMapType.NATAL; i< (int)tAstroMapType.NUMBER_DYNAMIC_TYPES; ++i)
            {
                string maptype = Utilities.FromUpperCaseToLowerWithFirstCapital<tAstroMapType>(i);
                maps[maptype] = i;

            }
            cmbKindMap.DataSource = new BindingSource(maps,null);
            cmbKindMap.DisplayMember = "Key";
            cmbKindMap.ValueMember = "Value";

        }
        protected void InitAspectsTypes()
        {
            AspectsMap adc = new AspectsMap();
            cmbKindAspect.DataSource = adc._AspectsDataCollection;
            cmbKindAspect.DisplayMember = "Name";
            cmbKindAspect.ValueMember = "Acronym";

        }
        private void OnSave(object sender, EventArgs e)
        {
            if(!textSystemName.ReadOnly)
            {
                if(string.IsNullOrEmpty(textSystemName.Text))
                {
                    MessageBox.Show("Please enter a system name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OrbsSystemSerializer ser = new OrbsSystemSerializer(textSystemName.Text);
                    ser.OrbsCollection = Orbs._data;
                    ser.Save();
                }
            }
        }

        private void OnMapKindChanged(object sender, EventArgs e)
        {
            _MapType = (tAstroMapType)((KeyValuePair<string, int>)cmbKindMap.SelectedValue).Value;
        }

        private void OnAspetTypeChanged(object sender, EventArgs e)
        {
            _AspectType = (AspectType)((AspectData)cmbKindAspect.SelectedItem).Type;
        }
        protected void SetupPlanetsImages()
        {
            for (int i = (int)(tPlanetType.PT_SUN); i <= (int)(tPlanetType.PT_PLUTO); i++)
            {
                tPlanetType planet = (tPlanetType)i;
                PutPlenetIcon(planet);
            }
            PutPlanetByImage("PT_Fict", 10);
            PutPlanetByImage("PT_Small", 11);
        }
        protected void PutPlenetIcon(tPlanetType type)
        {
            string splanet = Enum.GetName(typeof(tPlanetType), (int)type).ToString();
            PutPlanetByImage(splanet, (int)type);
        }
        protected void PutPlanetByImage(string imagename, int row)
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\");
            string imagepath = $"{path}{imagename}.png";
            PutImage(imagepath, 0, row);
        }
        protected void PutImage(string ImagePath, int column, int row)
        {
            Panel panel = new Panel();
            PictureBox pb = new PictureBox();
            pb.Image = new Bitmap(ImagePath);
            pb.Size = new Size(16, 16);
            panel.Controls.Add(pb);
            panel.Dock = DockStyle.Fill;
            pb.Top = 4;
            pb.Left = 4;
            tableOrbsEdit.Controls.Add(panel, column, row);
        }

        private void OnSunLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtSun.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_SUN, _AspectType, val);
        }

        private void OnMoonLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtMon.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_MOON, _AspectType, val);

        }

        private void OnMercuryLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtMer.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_MERCURY, _AspectType, val);

        }

        private void OnVenusLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtVen.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_VENUS, _AspectType, val);

        }

        private void OnMarsLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtMar.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_MARS, _AspectType, val);

        }

        private void OnJupiterLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtJup.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_JUPITER, _AspectType, val);

        }

        private void OnSaturnLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtSat.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_SATURN, _AspectType, val);

        }

        private void OnUranLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtUra.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_URANUS, _AspectType, val);

        }

        private void OnNeptunLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtNep.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_NEPTUNE, _AspectType, val);

        }

        private void OnPlutoLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtPlu.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_PLUTO, _AspectType, val);

        }

        private void OnFictivePlanetLeasve(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtFic.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_FICT_POINTS, _AspectType, val);
        }

        private void OnSmallBodiesLeave(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtSml.Text);
            Orbs.SetOrb(_MapType, tPlanetType.PT_SMALL_BODIES, _AspectType, val);
        }
    }
}
