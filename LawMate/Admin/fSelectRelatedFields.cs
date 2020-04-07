using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawMate.Admin
{
    public partial class fSelectRelatedFields : LawMate.Admin.fBase
    {
        public Janus.Windows.GridEX.GridEXRow[] checkedRows
        {
            get
            {
                return ddFieldGridEX.GetCheckedRows();
            }
        }

        public fSelectRelatedFields()
        {
            InitializeComponent();
        }

        public fSelectRelatedFields(atriumBE.atriumManager atmng, string TableName,string ObjectAlias)
        {
            InitializeComponent();
            ddFieldGridEX.RootTable.Caption = ObjectAlias + " (" + TableName + ")";

            if (atmng.DB.ddField.Rows.Count == 0)
            {
                //atmng.GetddTable().Load();
                atmng.GetddField().Load();
            }
            ddFieldBindingSource.DataSource = atmng.DB.ddField;
            ddFieldBindingSource.Filter = "AllowInRelatedFields=1 and TableName='" + TableName + "'";
            ddFieldGridEX.CheckAllRecords();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
