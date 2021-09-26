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
    public partial class dlgCreateMapByID : Form
    {
        private const string InvitationInputCtrl = "Enter an ID of a map...";
        protected Color BGEmptyInputCtrl = SystemColors.Info;
        protected Color FGEmptyInputCtrl = SystemColors.InactiveCaption;
        protected Color clrInfo = Color.Blue;
        protected Color clrError = Color.Red;

        protected List<MPersonBase> PeopleCollection;
        public MPersonBase Person { get; protected set; }
        public dlgCreateMapByID()
        {
            InitializeComponent();
        }
        protected void PutLineToResult(string Label, string nextText)
        {
            int length = rtResult.Text.Length;
            rtResult.AppendText(Environment.NewLine + Label);
            rtResult.SelectionStart = length;
            rtResult.SelectionLength = Label.Length;
            rtResult.SelectionColor = clrInfo;

            length = rtResult.Text.Length;
            rtResult.AppendText(nextText);
            rtResult.SelectionStart = length;
            rtResult.SelectionLength = nextText.Length;
            rtResult.SelectionColor = Color.Black;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Id = 0;
            Int32.TryParse(txtInputCtrl.Text, out Id);
            if (Id != 0)
            {
                PeopleCollection = new PersonsCollection().GetPersonalCollectionByID(Id);
                if (PeopleCollection != null)
                {
                    Person = PeopleCollection[0];

                    PutLineToResult("First Name: \t", Person.FirstName);
                    PutLineToResult("Last Name: \t", Person.SecondName);
                    PutLineToResult("Date of Birth: \t", $"{Person.BirthDay}-{Person.BirthMonth}-{Person.BirthYear}");
                }
                else
                {
                    rtResult.Text = "The map with this Id was not found!";
                    rtResult.SelectionStart = 0;
                    rtResult.SelectionLength = rtResult.Text.Length;
                    rtResult.SelectionColor = clrError;
                }
            }
        }

        private void OnInputCtrlKeyUp(object sender, KeyEventArgs e)
        {
            if (txtInputCtrl.Text == "")
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

            }
            else
            {
                btnSearch.Enabled = true;
            }
        }

        private void OnInputCtrlKeyDown(object sender, KeyEventArgs e)
        {
            //if(char.IsDigit((char)e.KeyValue));

            if (e.KeyValue != 16)//Shift
            {
                if (txtInputCtrl.Text == "" && (e.KeyValue == 8 || e.KeyValue == 46))
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

        private void OnInputCtrlClicked(object sender, EventArgs e)
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

        private void OnCreateMap(object sender, EventArgs e)
        {
            int Id = 0;
            Int32.TryParse(txtInputCtrl.Text, out Id);

            if (Id>0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void OnInputCtrlKryPressed(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }
    }
}
