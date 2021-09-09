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
        private const string InvitationLastName = "Enter a last name or a part of it...";
        private Color BGEmptyLastName = SystemColors.Info;
        private Color FGEmptyLastName = SystemColors.InactiveCaption;
        private List<MPersonBase> PeopleCollection;

        public MPersonBase SelectedPerson { get; protected set; }
        public dlgCreateMapByLastName()
        {
            InitializeComponent();
            txtLastName.Text = InvitationLastName;
        }

        private void OnTxtLastNameClicked(object sender, EventArgs e)
        {

            if (txtLastName.Text == InvitationLastName)
            {
                txtLastName.Text = "";
                txtLastName.BackColor = SystemColors.Control;
                txtLastName.ForeColor = SystemColors.ControlText;
            }
            else if (txtLastName.Text == "")
            {
                txtLastName.BackColor = BGEmptyLastName;
                txtLastName.ForeColor = FGEmptyLastName;
                txtLastName.Text = InvitationLastName;
            }
        }

        private void OnLastNameKeyUp(object sender, KeyEventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.BackColor = BGEmptyLastName;
                txtLastName.ForeColor = FGEmptyLastName;
                txtLastName.Text = InvitationLastName;
                btnSearch.Enabled = false;
            }
            else
            {
                btnSearch.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PeopleCollection = new PersonsCollection().GetPersonalCollectionByLastName(txtLastName.Text);
            if (PeopleCollection != null)
            {
                lstResult.DataSource = PeopleCollection;
                lstResult.DisplayMember = "ToListBox";
                lstResult.ValueMember = "Id";
            }
        }

        private void OnLstPeopleSelectedValueChanged(object sender, EventArgs e)
        {
            Type t = lstResult.SelectedValue.GetType();
            if (t != typeof(MPersonBase))
            {
                string text = lstResult.GetItemText(lstResult.SelectedItem);
                int Id = Convert.ToInt32(lstResult.SelectedValue);
                txtSelectedItem.Text = $"{text}, <{Id}>";
            }
        }

        private void OnCreateMap(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(lstResult.SelectedValue);
            SelectedPerson = PeopleCollection.Where(x => x.Id == Id).FirstOrDefault();
            this.DialogResult = DialogResult.OK;
        }
    }
}
