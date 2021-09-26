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
        public dlgCreateMapByKW()
        {
            InitializeComponent();
            FillUpKeywords();
        }
        private void FillUpKeywords()
        {
            KeywordsCollection kwcollection = new KeywordsCollection();
            List<MKeyword> lstKW = kwcollection.GetKeywordsCollection(0);
            FillList( lstKW);
        }
        private void FillList(List<MKeyword>lstKW)
        {
            if (lstKW != null)
            {
                lstResult.DataSource = lstKW;
                lstResult.DisplayMember = "KeyWordDescription";
                lstResult.ValueMember = "Idkw";
            }

        }
        private void btnDrillDown_Click(object sender, EventArgs e)
        {
            
            if (lstResult.SelectedValue!=null)
            {
                int Id = Convert.ToInt32(lstResult.SelectedValue);
                KeywordsCollection kwcollection = new KeywordsCollection();
                List<MKeyword> lstKW = kwcollection.GetKeywordsCollection(Id);
                FillList(lstKW);
            }
        }

        private void btnGetPeople_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnKW_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
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
                        FillList(lstKW);
                    }

                }
            }
        }
    }
}
