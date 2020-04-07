using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate.UserControls
{
    public partial class ucFileAccess : ucBase
    {
        public ucFileAccess()
        {
            InitializeComponent();
        }

        public void BindData(atriumDB.FileAccessDataTable a)
        {
            this.atriumDB_FileAccessDataTableBindingSource.DataSource = a.DataSet;
            this.atriumDB_FileAccessDataTableBindingSource.DataMember = a.TableName;
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.FileAccess;
        }

        public override void ReloadUserControlData()
        {
            FM.GetFileAccess().PreRefresh();
            FM.GetFileAccess().LoadByFileId(FM.CurrentFile.FileId);
            atriumDB_FileAccessDataTableGridEX.MoveFirst();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        private void ucFileAccess_Load(object sender, EventArgs e)
        {
            try
            {
                atriumDB_FileAccessDataTableGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
