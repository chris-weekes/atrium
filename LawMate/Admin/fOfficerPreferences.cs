using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fOfficerPreferences : fBase
    {
        public fOfficerPreferences()
        {
            InitializeComponent();
        }

        public fOfficerPreferences(Form f)
            : base(f)
        {
            InitializeComponent();

            officerPrefsBindingSource.DataSource = AtMng.OfficeMng.DB;
            officerPrefsBindingSource.DataMember = AtMng.OfficeMng.DB.OfficerPrefs.TableName;
            UIHelper.ComboBoxInit("vofficerlist", officerPrefsGridEX.DropDowns["ddOfficer"], AtMng.GetFile());

            AtMng.OfficeMng.GetOfficerPrefs().Load();
        }

        private void fOfficerPreferences_Load(object sender, EventArgs e)
        {
            officerPrefsGridEX.MoveFirst();
            officerPrefsGridEX.CollapseGroups();
            
        }
    }
}

