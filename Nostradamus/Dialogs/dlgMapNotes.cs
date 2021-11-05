using Nostradamus.Models.DataFactories;
using Nostradamus.Models.XMLSerializers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Nostradamus.Dialogs
{
    public partial class dlgMapNotes : Form
    {
        public dlgMapNotes()
        {
            InitializeComponent();
        }

        private void dlgMapNotes_Load(object sender, EventArgs e)
        {
            MapNotesFactory fact = new MapNotesFactory();

            chFLNames.Checked = fact.Data.StaticMapNotes.FirstLastName;
            chStaticAspectsTable.Checked = fact.Data.StaticMapNotes.Aspects;
            chCoordHouses.Checked = fact.Data.StaticMapNotes.Houses;
            chCoordinamesStatic.Checked = fact.Data.StaticMapNotes.Coordinates;
            chDOB.Checked = fact.Data.StaticMapNotes.DOB;

            chDynamicAspects.Checked = fact.Data.DynamicMapNotes.Aspects;
            chCoordDynamic.Checked = fact.Data.DynamicMapNotes.Coordinates;


        }

        private void OnSaveUpdate(object sender, EventArgs e)
        {
            MapNotesFactory fact = new MapNotesFactory();
            MapNotes mn = new MapNotes()
            {
                DynamicMapNotes = new MapNotesBase()
                {
                    Aspects = chDynamicAspects.Checked,
                    Coordinates = chCoordDynamic.Checked
                },
                StaticMapNotes = new StaticMapNotes()
                {
                    Aspects = chStaticAspectsTable.Checked,
                    Coordinates = chCoordinamesStatic.Checked,
                    FirstLastName = chFLNames.Checked,
                    Houses = chCoordHouses.Checked,
                    DOB = chDOB.Checked
                }
            };
            fact.Update(mn);
            DialogResult = DialogResult.OK;
        }
    }
}
