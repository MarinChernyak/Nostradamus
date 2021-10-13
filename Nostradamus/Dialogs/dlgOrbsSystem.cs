using Nostradamus.AstroMaps;
using Nostradamus.Models;
using Nostradamus.Models.XMLSerializers;
using Nostradamus.UserControls;
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
        protected string CurrentSystem { get; set; }
        protected tAstroMapType MapType { get; set; }
        protected List<OrbsCollectionData> OrbsCollection {get; set;}
        public dlgOrbsSystem()
        {
            InitializeComponent();
            
            InitOrbsCollection();
            MapType = tAstroMapType.NATAL;
            InitTable();
            InitCombos();
        }
        protected void InitTable()
        {
            OrbsCollectionData ocd = OrbsCollection.Where(x => x.OrbsSystemName == CurrentSystem).FirstOrDefault();
            OrbsMapCollection omc =  ocd.OrbsMapCollection.Where(x=>x.MapType == MapType).FirstOrDefault();
            if(omc==null || omc.PlanetsAspectsOrbsCollection==null)
            {
                omc = new OrbsMapCollection();
                omc.MapType = MapType;
                omc.PlanetsAspectsOrbsCollection = new List<PlanetsAspectsOrbsPairsCollection>();
                ocd.OrbsMapCollection.Add(omc);
            }
            UpdateViewPanel(omc.PlanetsAspectsOrbsCollection);

        }
        protected void UpdateViewPanel(List<PlanetsAspectsOrbsPairsCollection> lstOrbsCollection)
        {
            UserControls.OrbsPanelView opv = null;
            switch(MapType)
            {
                case tAstroMapType.NATAL:
                    opv = orbsNatalPanelView;
                    break;
                case tAstroMapType.TRANSIT:
                    opv = orbsTransitPanelView;
                    break;
                case tAstroMapType.PROGRESSIVE:
                    opv = orbsProgressivePanelView;
                    break;
                case tAstroMapType.DIRRECTIVE:
                    opv = orbsDirectivePanelView;
                    break;
                case tAstroMapType.SOLAR:
                    opv = orbsSolarPanelView;
                    break;
                case tAstroMapType.SOLAR_PROGRESSIONS:
                    opv = orbsSolarProgressPanelView;
                    break;
                case tAstroMapType.SYNASTRY:
                    opv = orbsSynastryPanelView;
                    break;
                case tAstroMapType.HORAR:
                    opv = orbsHorarPanelView;
                    break;
            };

            if(opv!=null)
            {
                opv.OrbsData = lstOrbsCollection;
                opv.Refresh();
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
                if (ocd == null)
                {
                    ocd = new OrbsCollectionData();
                    ocd.OrbsSystemName = system;
                }
                if (ocd.OrbsMapCollection == null)
                {

                    ocd.OrbsMapCollection = new List<OrbsMapCollection>();
                }
                if(ocd.OrbsMapCollection.Count==0)
                { 
                    ocd.OrbsMapCollection.Add(new OrbsMapCollection()
                    {
                        MapType = tAstroMapType.NATAL,
                        PlanetsAspectsOrbsCollection = new List<PlanetsAspectsOrbsPairsCollection>()
                    });
                }

                OrbsCollection.Add(ocd);
            }
        }
        protected void InitCombos()
        {
            InitSystemsCombo();
            InitMapsTypesCombo();
            InitAspectTypeCombo();
        }
        protected void InitMapsTypesCombo()
        {
            List<string> mapsfrom = new List<string>(); 
             List<string> mapsto = new List<string>(); 
           
            foreach(tAstroMapType map in Enum.GetValues(typeof(tAstroMapType)))
            {
                string smap = Utilities.FromUpperCaseToLowerWithFirstCapital<tAstroMapType>(map);
                mapsfrom.Add(smap);
                mapsto.Add(smap);
            }
            cmbMapFrom.DataSource = mapsfrom;
            cmbMapTo.DataSource = mapsto;
        }
        protected void InitAspectTypeCombo()
        {
            List<string> sfrom = new List<string>();
            List<string> sto = new List<string>();
            foreach(string asp in Constants._aspects)
            {
                sfrom.Add(asp);
                sto.Add(asp);
            }
            cmbAspectTo.DataSource = sto;
            cmbAspectFrom.DataSource = sfrom;
        }
        protected void InitSystemsCombo()
        {
            OrbsSystemListSerializer ser = new OrbsSystemListSerializer();
            List<string> systems = ser.OrbsSystemsList;
            if (systems == null)
            {
                systems = new List<string>();

            }
            if (systems.Count == 0)
            {
                systems.Add(Constants.DefaultHuseSystem);
            }
            else
            {
                systems = ser.OrbsSystemsList;
            }

            cmbExisting.DataSource = systems;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        private void SaveData()
        {
            OrbsCollectionData ocd = OrbsCollection.Where(x => x.OrbsSystemName == CurrentSystem).FirstOrDefault();
            if (ocd != null)
            {
                OrbsSystemListSerializer serlist = new OrbsSystemListSerializer();
                serlist.AddSystemToCollection(CurrentSystem);
                serlist.Save();

                OrbsSystemSerializer ser = new OrbsSystemSerializer(CurrentSystem);
                ser.OrbsCollection = ocd;
                ser.Save();
                //this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (dlgSomethingNew dlg = new dlgSomethingNew("Orbs System"))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CurrentSystem = dlg.NewValue;
                    OrbsSystemListSerializer ser = new OrbsSystemListSerializer();
                    ser.AddSystemToCollection(CurrentSystem);
                    ser.Save();

                    cmbExisting.DataSource = ser.OrbsSystemsList;
                    cmbExisting.SelectedItem = CurrentSystem;

                    OrbsCollectionData newcol = new OrbsCollectionData();
                    newcol.OrbsSystemName = CurrentSystem;
                    newcol.OrbsMapCollection = new List<OrbsMapCollection>();
                    OrbsCollection.Add(newcol);

                    InitTable();
                }
            }
        }

        private void OnSystemChanged(object sender, EventArgs e)
        {
            SaveData();
            CurrentSystem = cmbExisting.SelectedItem.ToString();
            MapType = tAstroMapType.NATAL;
            InitTable();
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            SaveData();
            MapType = Utilities.FromStringToEnumType<tAstroMapType>(tabCollectionsOrbs.SelectedTab.Text);
            InitTable();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void OnCopyOrbsByAspect(object sender, EventArgs e)
        {
            bool isOK = false;
            AspectType atFrom = Utilities.FromStringToEnumType<AspectType>(cmbAspectFrom.SelectedValue.ToString(), "AT_");
            AspectType atTo = Utilities.FromStringToEnumType<AspectType>(cmbAspectTo.SelectedValue.ToString(), "AT_");
            OrbsCollectionData ocd = OrbsCollection.Where(x => x.OrbsSystemName == CurrentSystem).FirstOrDefault();
            OrbsMapCollection omc = ocd.OrbsMapCollection.Where(x => x.MapType == MapType).FirstOrDefault();
            foreach(PlanetsAspectsOrbsPairsCollection papc in omc.PlanetsAspectsOrbsCollection)
            {
                tPlanetType pt = papc.PlanetType;
                AspectOrbsPair aop1 = papc.AspectOrbsCollection.Where(x => x.AspectType == atFrom).FirstOrDefault();
                if (aop1 != null)
                {
                    AspectOrbsPair aop2 = papc.AspectOrbsCollection.Where(x => x.AspectType == atTo).FirstOrDefault();
                    if (aop2 == null)
                    {
                        aop2 = new AspectOrbsPair();
                        aop2.AspectType = atTo;
                        papc.AspectOrbsCollection.Add(aop2);
                    }
                    aop2.OrbValue = aop1.OrbValue;
                    isOK = true;
                }

            }
            if(isOK)
                InitTable();
        }

        private void OnCopyOrbsByMap(object sender, EventArgs e)
        {
            bool isOK = false;
            tAstroMapType typeFrom = Utilities.FromStringToEnumType<tAstroMapType>(cmbMapFrom.SelectedValue.ToString());
            tAstroMapType typeTo = Utilities.FromStringToEnumType<tAstroMapType>(cmbMapTo.SelectedValue.ToString());
            OrbsCollectionData ocd = OrbsCollection.Where(x => x.OrbsSystemName == CurrentSystem).FirstOrDefault();
            OrbsMapCollection mapFrom = ocd.OrbsMapCollection.Where(x => x.MapType == typeFrom).FirstOrDefault();
            OrbsMapCollection mapTo = ocd.OrbsMapCollection.Where(x => x.MapType == typeTo).FirstOrDefault();
            
            if(mapFrom != null)
            {
                if(mapTo==null)
                {
                    mapTo = new OrbsMapCollection();
                    mapTo.MapType = typeTo;
                    mapFrom.PlanetsAspectsOrbsCollection = new List<PlanetsAspectsOrbsPairsCollection>();
                    ocd.OrbsMapCollection.Add(mapTo);
                }
                foreach(PlanetsAspectsOrbsPairsCollection collectionFrom in mapFrom.PlanetsAspectsOrbsCollection)
                {
                    tPlanetType ptypeFrom = collectionFrom.PlanetType;
                    PlanetsAspectsOrbsPairsCollection collectionTo = mapTo.PlanetsAspectsOrbsCollection.Where(x => x.PlanetType == ptypeFrom).FirstOrDefault();
                    if (collectionTo == null)
                    {
                        collectionTo = new PlanetsAspectsOrbsPairsCollection();
                        collectionTo.PlanetType = ptypeFrom;
                        collectionTo.AspectOrbsCollection = new List<AspectOrbsPair>();
                        mapTo.PlanetsAspectsOrbsCollection.Add(collectionTo);
                    }                    
                    foreach (AspectOrbsPair orbs in collectionFrom.AspectOrbsCollection)
                    {
                        AspectType at = orbs.AspectType;
                        double dorbval = orbs.OrbValue;
                        AspectOrbsPair orb2 = collectionTo.AspectOrbsCollection.Where(x => x.AspectType == at).FirstOrDefault();
                        if(orb2 == null)
                        {
                            orb2 = new AspectOrbsPair()
                            {
                                AspectType = at                                
                            };
                            collectionTo.AspectOrbsCollection.Add(orb2);
                        }
                        orb2.OrbValue = dorbval;
                    }
                }
                isOK = true;
            }
            if (isOK)
            {
                InitTable();
                string tabname = Utilities.FromUpperCaseToLowerWithFirstCapital<tAstroMapType>(mapTo.MapType);
                int ipos = tabname.IndexOf(" ");
                if(ipos>=0)
                {
                    tabname = tabname.Replace(" ", "");
                }
                tabname = $"tab{tabname}";
                TabPage tp = tabCollectionsOrbs.TabPages[tabname];
                tabCollectionsOrbs.SelectedTab = tp;
            }
        }
    }
}
