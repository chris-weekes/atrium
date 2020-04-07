using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

namespace LawMate.Admin
{
    public partial class fSystemMessage : LawMate.Admin.fBase
    {
        public fSystemMessage()
        {
            InitializeComponent();
        }

        public fSystemMessage(Form f)
            : base(f)
        {
            InitializeComponent();
            
            AtMng.GetMsg().Load();

            msgBindingSource.DataSource = AtMng.DB;
            msgBindingSource.DataMember = AtMng.DB.Msg.TableName;
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdSave":
                        Save();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void Cancel()
        {
            UIHelper.Cancel(msgBindingSource);
        }

        private void Save()
        {
            if (AtMng.DB.Msg.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {
                    msgBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetMsg());
                    bp.Update();
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }
    }
}
