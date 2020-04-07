using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fGroups : fBase
    {
        atSecurity.SecurityManager mySecMan;

        public fGroups()
        {
            InitializeComponent();
        }

        public fGroups(Form f)
            : base(f)
        {
            InitializeComponent();

            mySecMan = AtMng.SecurityManager;
            mySecMan.GetsecGroup().Load();
            mySecMan.GetsecMembership().Load();
            mySecMan.GetsecUser().Load();

            secGroupBindingSource.DataSource = mySecMan.DB;
            
            secGroupGridEX.DropDowns["ddGroup"].SetDataBinding(mySecMan.DB.secGroup, "");
            secGroupGridEX.DropDowns["ddUser"].SetDataBinding(mySecMan.DB.secUser, "");
           
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdCancel":
                        UIHelper.Cancel(secGroupBindingSource);
                        break;
                    case "cmdNew":
                        mySecMan.GetsecGroup().Add(null);
                        break;
                    case "cmdNewMember":
                        mySecMan.GetsecMembership().Add(CurrentRow());
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

        public void Save()
        {
            try
            {
                secGroupGridEX.UpdateData();
                secGroupBindingSource.EndEdit();

                atLogic.BusinessProcess bp = mySecMan.GetBP();
                bp.AddForUpdate(mySecMan.GetsecGroup());
                bp.AddForUpdate(mySecMan.GetsecMembership());
                bp.Update();

              
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public lmDatasets.SecurityDB.secGroupRow CurrentRow()
        {
            return (lmDatasets.SecurityDB.secGroupRow)((DataRowView)secGroupBindingSource.Current).Row;
        }

    }
}

