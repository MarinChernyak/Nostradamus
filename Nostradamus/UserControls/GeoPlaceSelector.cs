using Nostradamus.Models;
using Nostradamus.Models.GeoModels;
using Nostradamus.Models.Helpers.GeoHelpers;
using NostradamusDAL.EntitiesGeo;
using NostradamusDAL.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.UserControls
{
    public partial class GeoPlaceSelector : UserControl
    {
        public int GetPlaceId()
        {
            int Id =0;
            if(cmbCities.SelectedItem!=null)
            {
                Id = ((MCityData)cmbCities.SelectedItem).Id;
            }
            return Id;
        }
        //public int SelectedCity { get { return cmbCities.SelectedItem != null ? Convert.ToInt32(cmbCities.SelectedValue) : 0; } }
        public GeoPlaceSelector()
        {
            InitializeComponent();
            //FillUpCountries();
        }
        public void FillUpCountries()
        {
            CountriesHelper Countries = new CountriesHelper();
            cmbCountries.DataSource = Countries.Data; //Countries.Data;
            cmbCountries.ValueMember = "Id";
            cmbCountries.DisplayMember = "CountryName";
        }
        private void OnCountryChanged(object sender, EventArgs e)
        {
            UpdateByCountry();
        }
        protected void UpdateByCountry()
        {
            if (cmbCountries.SelectedItem != null)
            {
                MCountryData mdata = (MCountryData)cmbCountries.SelectedItem;
                int IDCountry = mdata.Id;

                StatesHelper sth = new StatesHelper(IDCountry);

                cmbState.ValueMember = "Id";
                cmbState.DisplayMember = "StateRegion1";
                cmbState.DataSource = sth.Data;
                int idstate = 0;
                if(sth.Data!=null)
                {
                    MStateRegionData sdata = (MStateRegionData)cmbState.SelectedItem;
                    if(sdata!=null)
                        idstate = sdata.Id;
                }

                UpdateCityData(IDCountry, idstate);
            }
        }
        private void OnStateChanged(object sender, EventArgs e)
        {
            if (cmbState.SelectedValue != null)
            {
                int IdState = Convert.ToInt32(cmbState.SelectedValue);
                if(IdState > 0)
                {
                    UpdateCityData(0, IdState);
                }
                else
                {
                    MCountryData mdata = (MCountryData)cmbCountries.SelectedItem;
                    int IDCountry = mdata.Id;
                    UpdateCityData(IDCountry, 0);
                }
            }
        }
        protected void UpdateCityData(int IdCountry, int IdState)
        {
            CitiesHelper ch = new CitiesHelper(IdCountry, IdState);
            cmbCities.DataSource = ch.Data;
            cmbCities.ValueMember = "Id";
            cmbCities.DisplayMember = "CityName";
        }
    }
}
