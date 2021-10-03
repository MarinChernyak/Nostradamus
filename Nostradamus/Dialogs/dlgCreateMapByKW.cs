using Nostradamus.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nostradamus.Dialogs
{
    public partial class dlgCreateMapByKW : Form
    {
        public MVwPeopleKeyWord SelectedPerson { get; protected set; }
        public dlgCreateMapByKW()
        {
            InitializeComponent();
            FillUpKeywords();
        }
        private void FillUpKeywords()
        {
            KeywordsCollection kwcollection = new KeywordsCollection();
            List<MKeyword> lstKW = kwcollection.GetKeywordsCollection(0);
            FillListKW( lstKW);
        }
        private void FillListKW(List<MKeyword>lstKW)
        {
            if (lstKW != null)
            {
                lstResult.DataSource = null;
                lstResult.Items.Clear();
                lstResult.DataSource = lstKW;
                lstResult.DisplayMember = "KeyWordDescription";
                lstResult.ValueMember = "Idkw";
                lstResult.SelectedIndex = 0;

                UpdateButtons(true);
            }
        }
        private void FillListPeople(List<MVwPeopleKeyWord> lst)
        {
            if (lst != null)
            {
                lstResult.DataSource = null;
                lstResult.Items.Clear();
                lstResult.DataSource = lst;
                lstResult.DisplayMember = "ToListPeople";
                lstResult.ValueMember = "IdPerson";
                lstResult.SelectedIndex = 0;

                UpdateButtons(false);
            }
        }
        private void UpdateButtons(bool IsKW)
        {
            btnReturnKW.Enabled = !IsKW;
            btnCreateMap.Enabled = !IsKW;
            btnDrillDown.Enabled = IsKW;
            btnDrillUp.Enabled = IsKW;
            btnGetPeople.Enabled = IsKW;
        }
        private void btnDrillDown_Click(object sender, EventArgs e)
        {            
            if (lstResult.SelectedValue!=null)
            {
                int Id = Convert.ToInt32(lstResult.SelectedValue);
                KeywordsCollection kwcollection = new KeywordsCollection();
                List<MKeyword> lstKW = kwcollection.GetKeywordsCollection(Id);
                FillListKW(lstKW);
            }
        }
        private void FillUpPeople()
        {
            MKeyword kw = (MKeyword)lstResult.SelectedItem;
            if (kw != null)
            {
                lstResult.DataSource = null;
                lstResult.Items.Clear();
                PersonsCollection collection = new PersonsCollection();
                List<MVwPeopleKeyWord> lst = collection.GetPersonalCollectionByKW(kw.Idkw);
                FillListPeople(lst);
            }
        }
        private void btnGetPeople_Click(object sender, EventArgs e)
        {
            if(lstResult.SelectedItem != null)
            {
                FillUpPeople();
            }
        }

        private void btnReturnKW_Click(object sender, EventArgs e)
        {
            FillUpKeywords();
            UpdateButtons(true);
        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            SelectedPerson = (MVwPeopleKeyWord)lstResult.SelectedItem;

            this.DialogResult = DialogResult.OK;
        }

        private void DrillUp_Click(object sender, EventArgs e)
        {
            if (lstResult.SelectedValue != null)
            {
                int Id = Convert.ToInt32(lstResult.SelectedValue);
                KeywordsCollection kwcollection = new KeywordsCollection();
                MKeyword kw = kwcollection.GetKWbyId(Id);

                if (kw != null )
                {
                    int idref = (int)kw.ReferenceId;
                    kw = kwcollection.GetKWbyId(idref);
                    if (kw != null && kw.ReferenceId != null)
                    {
                        List<MKeyword> lstKW = kwcollection.GetKeywordsCollection((int)kw.ReferenceId);
                        FillListKW(lstKW);
                    }

                }
            }
        }

        private void OnLstSelectionChanged(object sender, EventArgs e)
        {
            MKeyword kw = lstResult.SelectedItem as MKeyword;
            if(kw!=null)
            {
                txtSelected.Text = kw.KeyWordDescription;
            }
        }
    }
}
