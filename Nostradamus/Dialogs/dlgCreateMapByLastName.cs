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
    public partial class dlgCreateMapByLastName : Form
    {
        private const string InvitationInputCtrl = "Enter a last name or a part of it...";
        protected Color BGEmptyInputCtrl = SystemColors.Info;
        protected Color FGEmptyInputCtrl = SystemColors.InactiveCaption;
        protected List<MPersonBase> PeopleCollection;
        public MPersonBase SelectedPerson { get; protected set; }
        public dlgCreateMapByLastName()
        {
            InitializeComponent();
            txtInputCtrl.Text = InvitationInputCtrl;
        }

        private void OnTxtLastNameClicked(object sender, EventArgs e)
        {

            if (txtInputCtrl.Text == InvitationInputCtrl)
            {
                txtInputCtrl.Text = "";
                txtInputCtrl.BackColor = SystemColors.Control;
                txtInputCtrl.ForeColor = SystemColors.ControlText;
            }
            else if (txtInputCtrl.Text == "")
            {
                txtInputCtrl.BackColor = BGEmptyInputCtrl;
                txtInputCtrl.ForeColor = FGEmptyInputCtrl;
                txtInputCtrl.Text = InvitationInputCtrl;
            }
        }

        private void OnLastNameKeyUp(object sender, KeyEventArgs e)
        {
            if (txtInputCtrl.Text == "")
            {
                txtInputCtrl.BackColor = BGEmptyInputCtrl;
                txtInputCtrl.ForeColor = FGEmptyInputCtrl;
                txtInputCtrl.Text = InvitationInputCtrl;
                btnSearch.Enabled = false;
            }
            else if(txtInputCtrl.Text == InvitationInputCtrl)
            {
                txtInputCtrl.Text = "";
                txtInputCtrl.BackColor = SystemColors.Control;
                txtInputCtrl.ForeColor = SystemColors.ControlText;

            }
            else
            {
                btnSearch.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PeopleCollection = new PersonsCollection().GetPersonalCollectionByLastName(txtInputCtrl.Text);
            if (PeopleCollection != null)
            {
                lstResult.DataSource = PeopleCollection;
                lstResult.DisplayMember = "ToListBox";
                lstResult.ValueMember = "Id";
            }
        }

        private void OnLstPeopleSelectedValueChanged(object sender, EventArgs e)
        {
            if (lstResult.SelectedValue != null)
            {
                Type t = lstResult.SelectedValue.GetType();
                if (t != typeof(MPersonBase))
                {
                    string text = lstResult.GetItemText(lstResult.SelectedItem);
                    int Id = Convert.ToInt32(lstResult.SelectedValue);
                    txtSelectedItem.Text = $"{text}, <{Id}>";
                }
            }
        }

        private void OnCreateMap(object sender, EventArgs e)
        {
            if (lstResult.SelectedValue != null)
            {
                int Id = Convert.ToInt32(lstResult.SelectedValue);
                SelectedPerson = PeopleCollection.Where(x => x.Id == Id).FirstOrDefault();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void OnLastNameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 16)//Shift
            {
                if (txtInputCtrl.Text == ""&& (e.KeyValue==8 || e.KeyValue==46))
                {
                    txtInputCtrl.BackColor = BGEmptyInputCtrl;
                    txtInputCtrl.ForeColor = FGEmptyInputCtrl;
                    txtInputCtrl.Text = InvitationInputCtrl;
                    btnSearch.Enabled = false;
                }
                else if (txtInputCtrl.Text == InvitationInputCtrl)
                {
                    txtInputCtrl.Text = "";
                    txtInputCtrl.BackColor = SystemColors.Control;
                    txtInputCtrl.ForeColor = SystemColors.ControlText;
                    btnSearch.Enabled = false;
                }
                else
                {
                    btnSearch.Enabled = true;
                }
            }
        }
    }
}
