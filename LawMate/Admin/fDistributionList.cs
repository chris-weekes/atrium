using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.Admin
{
    public partial class fDistributionList : fBase
    {
        public fDistributionList()
        {
            InitializeComponent();
        }
        public fDistributionList(Form f)
            : base(f)
        {
            InitializeComponent();

            listBindingSource.DataSource = AtMng.DB;
            listMemberBindingSource.DataSource = AtMng.DB;
            listMemberGridEX.DropDowns["ddOfficer"].SetDataBinding(AtMng.GetFile().Codes("vOfficerList"), "");

            AtMng.GetList().Load();
            AtMng.GetListMember().Load();
        }

        private void fDistributionList_Load(object sender, EventArgs e)
        {
            try
            {
                listGridEX.Row = 0;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
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
                    case "cmdNewList":
                        lmDatasets.appDB.ListRow lstr = (lmDatasets.appDB.ListRow)AtMng.GetList().Add(null);
                        listGridEX.Find(listGridEX.RootTable.Columns["ListNameEng"], Janus.Windows.GridEX.ConditionOperator.Equal, "New Distribution List", 0, 1);
                        listGridEX.CurrentColumn = listGridEX.RootTable.Columns["ListNameEng"];
                        listGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                        break;
                    case "cmdNew":
                        cmdNew1.Expand();
                        break;
                    case "cmdNewMember":
                        if (CurrentRowList() != null)
                        {
                            lmDatasets.appDB.ListMemberRow lmemr = (lmDatasets.appDB.ListMemberRow)AtMng.GetListMember().Add(CurrentRowList());
                            listMemberGridEX.Find(listMemberGridEX.RootTable.Columns["Id"], Janus.Windows.GridEX.ConditionOperator.Equal, lmemr.Id, 0, 1);
                            listMemberGridEX.CurrentColumn = listMemberGridEX.RootTable.Columns["ContactId"];
                            listMemberGridEX.EditMode = Janus.Windows.GridEX.EditMode.EditOn;
                        }
                        else
                            MessageBox.Show("Please select a Distribution List row before choosing to create a new Member", "No List Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public lmDatasets.appDB.ListRow CurrentRowList()
        {
            if (listBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ListRow)((DataRowView)listBindingSource.Current).Row;
        }

        public lmDatasets.appDB.ListMemberRow CurrentRowListMember()
        {
            if (listMemberBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.appDB.ListMemberRow)((DataRowView)listMemberBindingSource.Current).Row;
        }

        private void Cancel()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be cancelled.  Are you sure you want to proceed?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    UIHelper.Cancel(listBindingSource);
                    UIHelper.Cancel(AtMng.DB);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        private void Save()
        {
            try
            {
                if (MessageBox.Show("All edits (to all records) will be saved.  Are you sure you want to proceed?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    listGridEX.CurrentRow.EndEdit();
                    listGridEX.UpdateData();
                    listBindingSource.EndEdit();
                    
                    listMemberGridEX.CurrentRow.EndEdit();
                    listMemberGridEX.UpdateData();
                    listMemberBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();

                    bp.AddForUpdate(AtMng.GetList());
                    bp.AddForUpdate(AtMng.GetListMember());
                    bp.Update();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void listBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRowList() != null)
                {
                    pnlMember.Text = "List Members (" + CurrentRowList().ListNameEng + ")";
                    cmdNewMember.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdNewMember.Text = "New Member in following Distribution List: " + CurrentRowList().ListNameEng;
                    cmdNewMember.Tag = CurrentRowList().ListId;
                    listMemberBindingSource.Filter = "ListId=" + CurrentRowList().ListId;

                    DataView dvDL = new DataView(AtMng.DB.List, "SyncExchange=1 and ListId<>" + CurrentRowList().ListId.ToString(), "listnameeng", DataViewRowState.CurrentRows);
                    listMemberGridEX.DropDowns["ddDistList"].SetDataBinding(dvDL, "");
                }
                else
                {
                    pnlMember.Text = "List Members";
                    cmdNewMember.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    listMemberBindingSource.Filter = "ListId=-1";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void listGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try 
            {
                MessageBox.Show("You cannot delete Distribution Lists");
                e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void listMemberGridEX_DeletingRecords(object sender, CancelEventArgs e)
        {
            try
            {
                if (!UIHelper.ConfirmDelete())
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        fContactSelect fSearchContact;

        private void listMemberGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column == listMemberGridEX.RootTable.Columns["MemberListId"] && !CurrentRowListMember().IsMemberListIdNull())
                {
                    foreach (Janus.Windows.GridEX.GridEXRow gr in listGridEX.GetRows())
                    {
                        if ((int)gr.Cells["ListId"].Value == CurrentRowListMember().MemberListId)
                        {
                            listGridEX.Row = gr.Position;
                            return;
                        }
                    }
                }
                if (e.Column == listMemberGridEX.RootTable.Columns["ContactId"])
                {
                    if (fSearchContact == null)
                        fSearchContact = new fContactSelect(AtMng.GetFile(), null,false);

                    fSearchContact.ShowDialog();

                    if (fSearchContact.ContactId != 0)
                        CurrentRowListMember().ContactId = fSearchContact.ContactId;

                    fSearchContact.Hide();
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

