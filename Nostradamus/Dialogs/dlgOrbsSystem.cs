using Nostradamus.AstroMaps;
using Nostradamus.Models;
using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using static NostraPlanetarium.NPTypes;

namespace Nostradamus.Dialogs
{
    public partial class dlgOrbsSystem : Form
    {
        List<string> _aspects;
        protected string CurrentSystem { get; set; }
        protected List<OrbsCollectionData> OrbsCollection {get; set;}
        public dlgOrbsSystem()
        {
            InitializeComponent();
            InitOrbsCollection();
            InitCombos();
            InitTable();
            InitDialogsImages();
        }
        protected void InitTable()
        {
            if(OrbsCollection!=null && OrbsCollection.Count>0)
            {
                OrbsCollectionData ocd = OrbsCollection.Where(x => x.OrbsSystemName == CurrentSystem).FirstOrDefault();
                if(ocd!=null)
                {
                    foreach(OrbsMapCollection tab in ocd.OrbsMapCollection)
                    {
                        tAstroMapType type = tab.MapType;
                        string tabtype = Utilities.FromUpperCaseToLowerWithFirstCapital< tAstroMapType>(type);
                        List<PlanetsAspectsOrbsPairsCollection> paoclst = tab.PlanetsAspectsOrbsCollection;
                        tabCollectionsOrbs.SelectTab($"tab{tabtype}");

                        foreach(PlanetsAspectsOrbsPairsCollection paoc in paoclst)
                        {
                            tPlanetType pt = paoc.PlanetType;
                            foreach(AspectOrbsPair aop in paoc.AspectOrbsCollection)
                            {
                                AspectType AspectType = aop.AspectType;
                                string aspectt = Utilities.FromUpperCaseToLowerWithFirstCapital<AspectType>(AspectType);
                                double value = aop.OrbValue;
                                TabPage tpage = tabCollectionsOrbs.SelectedTab;
                                Label l = new Label();
                                l.Text = value.ToString();
                                int index = _aspects.FindIndex(x => x == aspectt);
                                tableOtbs.Controls.Add(l, index+1, (int)pt + 1);
                            }
                        }

                    }
                }
            }
        }
        protected void InitOrbsCollection()
        {
            OrbsCollection = new List<OrbsCollectionData>();
            UserPreferenses up = new UserPreferenses();
            CurrentSystem = Constants.DefaultOrbsSystem;
            if (up != null && up.OrbsSystem != null)
            {
                CurrentSystem = up.OrbsSystem;
            }
            OrbsSystemListSerializer OrbsListser = new OrbsSystemListSerializer();
            List<string> OrbsList = OrbsListser.OrbsSystemsList;
            if (OrbsList != null)
            {
                foreach (string system in OrbsList)
                {
                    AddOrbsCollectionData(system);
                }
            }
            else
            {
                AddOrbsCollectionData(Constants.DefaultOrbsSystem);
            }
        }
        protected void AddOrbsCollectionData(string system)
        {
            OrbsSystemSerializer oss = new OrbsSystemSerializer(system);
            if (oss != null)
            {
                OrbsCollectionData ocd = oss.OrbsCollection;
                if (ocd != null)
                {
                    OrbsCollection.Add(ocd);
                }
            }
        }
        protected void InitCombos()
        {
            OrbsSystemListSerializer ser = new OrbsSystemListSerializer();
            cmbExisting.DataSource =  ser.OrbsSystemsList;

        }
        private void InitDialogsImages()
        {
            _aspects = new string[]
            {
                "Conjunction","Semisextile","Sextile","Quadro","Trin","Quincunx","Opposition","Quintile","Biquintile","Octile","Trioctile","Decile","Tridecile"
            }.ToList();
            try
            {
                SetupPlanetsImages();
                SetUpAspectsImages();    
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show($"dlgOrbsSystem: InitDialogsImages => {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            pb.Size = new System.Drawing.Size(16, 16);
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
            //string system = cmbExisting.SelectedItem;

            using (dlgOrbsEdit dlg = new dlgOrbsEdit(""))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //selectedsys = dlg.SelectedSystem;
                    //if (selectedsys != null && !string.IsNullOrEmpty(selectedsys.SystemID) && !string.IsNullOrEmpty(selectedsys.SystemName))
                    //{

                    //    _userpref.SelectedHousesSystem = selectedsys;
                    //    _userpref.SavePreferenses();

                    //}
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (dlgOrbsEdit dlg = new dlgOrbsEdit())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //selectedsys = dlg.SelectedSystem;
                    //if (selectedsys != null && !string.IsNullOrEmpty(selectedsys.SystemID) && !string.IsNullOrEmpty(selectedsys.SystemName))
                    //{

                    //    _userpref.SelectedHousesSystem = selectedsys;
                    //    _userpref.SavePreferenses();

                    //}
                }
            }
        }
    }
}
