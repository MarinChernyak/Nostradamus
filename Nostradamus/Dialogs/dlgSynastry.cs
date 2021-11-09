using Nostradamus.Models;
using Nostradamus.Models.GeoModels;
using Nostradamus.Models.Helpers.GeoHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.Dialogs
{
    public partial class dlgSynastry : Form
    {
        private const string opp1 = "By Last Name";
        private const string opp2 = "By Id";
        private const string opp3 = "Enter manually";

        private MPersonBase _person;

        public MDynamicMapUpdateInfo DynamInfo { get; protected set; }

        //public MPersonBase GetSynastryPerson() { return _person; }
        public dlgSynastry()
        {
            InitializeComponent();
            FillUpCombo();
        }
        protected void FillUpCombo()
        {
            List<string> lst = new List<string>()
            {
                opp1,opp2,opp3
            };
            cmbSelectionType.DataSource = lst; 
        }

        private void OnSelectSecondary(object sender, EventArgs e)
        {
            switch(cmbSelectionType.SelectedItem)
            {
                case opp1:
                    GetSecomdaryMapByLastName();
                    break;
                case opp2:
                    GetSecomdaryMapById();
                    break;
                case opp3:
                    GetSecomdaryMapManually();
                    break;
            }
        }
        protected void GetSecomdaryMapByLastName()
        {
            using (dlgCreateMapByLastName dlg = new dlgCreateMapByLastName())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _person = dlg.SelectedPerson;
                    dlg.Close();
                }
            }
            UpdateDynamoInfo();
        }
        protected void GetSecomdaryMapById()
        {
            using (dlgCreateMapByID dlg = new dlgCreateMapByID())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _person = dlg.Person;
                    dlg.Close();
                }
            }
            UpdateDynamoInfo();
        }
        protected void GetSecomdaryMapManually()
        {
            using (dlgCreateMapManually dlg = new dlgCreateMapManually())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    MCityDataHelper chelp = new MCityDataHelper(dlg.PLaceId);
                    DynamInfo = new MDynamicMapUpdateInfo()
                    {
                        AdditionalHour = 0,
                        DynamicDate = new DateTime(dlg.Year,dlg.Month,dlg.Day,dlg.Hour,dlg.Min,0),
                        EventPlace = chelp.Data,
                        MapType = NostraPlanetarium.NPTypes.tAstroMapType.SYNASTRY
                    };
                    dlg.Close();
                }
            }
        }
        private void OnCreateMap(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
        protected void UpdateDynamoInfo()
        {
            if (_person != null)
            {
                int h = 0;
                int m = 0;
                int s = 0;
                Utilities.GetMidleValue(_person, out h, out m, out s);
                lblSelected.Text = $"{_person.SecondName} {_person.FirstName.Substring(0, 1)}. ({_person.BirthDay}/{_person.BirthMonth}/{_person.BirthYear})";
                MCityDataHelper mcd = new MCityDataHelper(_person.Place);
                DynamInfo = new MDynamicMapUpdateInfo()
                {
                    AdditionalHour = _person.AdditionalHours,
                    DynamicDate = new DateTime(_person.BirthYear, _person.BirthMonth, _person.BirthDay, h, m, s),
                    EventPlace = mcd.Data,
                    MapType = NostraPlanetarium.NPTypes.tAstroMapType.SYNASTRY
                };
            }
        }
    }
}
