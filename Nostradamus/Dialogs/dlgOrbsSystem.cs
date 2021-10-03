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
    public partial class dlgOrbsSystem : Form
    {
        string[] _aspects;
        public dlgOrbsSystem()
        {
            InitializeComponent();
            InitOrbsCollection();
        }
        private void InitOrbsCollection()
        {
            _aspects = new string[]
            {
                "Conjunction","Semisextile","Sextile","Quadro","Trin","Quincunx","Opposition","Quintile","Biquintile","Octile","Trioctile","Decile","Tridecile"
            };
            try
            {
                SetupPlanetsImages();
                SetUpAspectsImages();    
            }
            catch(Exception e)
            {

            }
        }
        protected void SetUpAspectsImages()
        {
            for(int i=0; i<13; i++)
            {
                string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\Aspects\\");
                string imagepath = $"{path}{_aspects[i]}.png";
                PutImage(imagepath, i + 1, 0);
            }
        }
        protected void SetupPlanetsImages()
        {
            for (int i = (int)(tPlanetType.PT_SUN); i <= (int)(tPlanetType.PT_PLUTO); i++)
            {
                tPlanetType planet = (tPlanetType)i;
                PutPlenetIcon(planet);
            }
            PutPlanetByImage("PT_Fict", 11);
            PutPlanetByImage("PT_Small", 12);
        }
        protected void PutPlenetIcon(tPlanetType type)
        {
            string splanet = Enum.GetName(typeof(tPlanetType), (int)type).ToString();
            PutPlanetByImage(splanet, (int)type + 1);
        }
        protected void PutPlanetByImage(string imagename, int row)
        {
            string path = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Resources\\icons\\");
            string imagepath = $"{path}{imagename}.png";
            PutImage(imagepath, 0, row);
        }
        protected void PutImage(string ImagePath,int column, int row)
        {
            Panel panel = new Panel();
            PictureBox pb = new PictureBox();
            pb.Image = new Bitmap(ImagePath);
            pb.Size = new Size(16, 16);
            panel.Controls.Add(pb);
            panel.Dock = DockStyle.Fill;
            pb.Top = 4;
            pb.Left = 4;
            tableOtbs.Controls.Add(panel, column, row);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
