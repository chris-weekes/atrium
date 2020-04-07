using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate
{
    public partial class ucFileHistory : ucBase
    {

        fFile f;

        public ucFileHistory()
        {
            InitializeComponent();
        }

        public void BindFileHistoryData(CLAS.FileHistoryDataTable a)
        {
            officeIducOfficeSelectBox.AtMng = FM.AtMng;
            UIHelper.ComboBoxInit("ReturnCode", ucMultiDropDown1, FM);

            setBindingSources();

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetCLASMng().GetFileHistory().OnUpdate += new atLogic.UpdateEventHandler(ucFileHistory_OnUpdate);
        }

        void ucFileHistory_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.FileHistory;
        }
        
        public override bool controlHasBorder()
        {
            return false;
        }

        private void setBindingSources()
        {
            fileHistoryBindingSource.DataMember = FM.GetCLASMng().DB.FileHistory.TableName;
            fileHistoryBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            fileHistoryGridEX1.MoveFirst();
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            fileHistoryBindingSource.Position = fileHistoryBindingSource.Find("HistoryId", linkId);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void EndEdit()
        {
            fileHistoryBindingSource.EndEdit();
        }

        bool InEditMode = false;
        public override void ApplyBR(bool DataNotDirty)
        {
            fFile f = FileForm();
            if (f != null)
            {
                f.IsDirty = !DataNotDirty;

                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }

            if (DataNotDirty)
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                InEditMode = false;
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                InEditMode = true;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(fileHistoryBindingSource, !makeReadOnly);
            uiCommandBar3.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        public override void ApplySecurity(DataRow brow)
        {
            CLAS.FileHistoryRow br = (CLAS.FileHistoryRow)brow;
            UIHelper.EnableControls(fileHistoryBindingSource, FM.GetCLASMng().GetFileHistory().CanEdit(br));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetFileHistory().CanDelete(br));


            if (FM.GetCLASMng().GetFileHistory().CanEdit(br))
            {   //toggle appropriate fields

                //OWNER
                if (FM.CurrentFile.OwnerOfficeId == FM.AtMng.WorkingAsOfficer.OfficeId)
                {
                    officeDB.OfficeRow or = FM.AtMng.OfficeMng.DB.Office.FindByOfficeId(FM.CurrentFile.LeadOfficeId);
                    if (or == null)
                        or = FM.AtMng.GetOffice(FM.CurrentFile.LeadOfficeId).CurrentOffice;
                    if (or.IsOnLine && FM.CurrentFile.LeadOfficeId!=FM.CurrentFile.OwnerOfficeId) //lead is online
                    {
                        receivedByOfficeDateCalendarCombo.ReadOnly = true;
                        returnedByOfficeDateCalendarCombo.ReadOnly = true;
                        ucMultiDropDown1.ReadOnly = true;
                    }
                }
                else //AGENT
                {
                    sentToOfficeDateCalendarCombo.ReadOnly = true;
                    officeIducOfficeSelectBox.ReadOnly = true;
                    receivedFromOfficeDateCalendarCombo.ReadOnly = true;
                    if (br.OfficeId != FM.AtMng.WorkingAsOfficer.OfficeId)
                    {
                        receivedByOfficeDateCalendarCombo.ReadOnly = true;
                        returnedByOfficeDateCalendarCombo.ReadOnly = true;
                        ucMultiDropDown1.ReadOnly = true;
                    }
                }
            }
        }

        private CLAS.FileHistoryRow CurrentRow()
        {
            if (fileHistoryBindingSource.Current == null)
                return null;
            else
                return (CLAS.FileHistoryRow)((DataRowView)fileHistoryBindingSource.Current).Row;
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.FileHistory.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.fileHistoryBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetFileHistory());
                    bp.Update();
                    ApplyBR(true);
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        public override void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    fileHistoryBindingSource.EndEdit();
                    FM.SaveAll();

                    ApplyBR(true);

                    f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
             
               throw x;
            }
        }

        public override void Cancel()
        {
            UIHelper.Cancel(fileHistoryBindingSource);
            ApplyBR(true);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsSave":
                        Save();
                        break;
                    case "tsDelete":
                        Delete();
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileHistoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("HistoryId"))
                    return;

                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fileHistoryGridEX1_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                { e.Cancel = true; }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucFileHistory_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                fileHistoryGridEX1.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

