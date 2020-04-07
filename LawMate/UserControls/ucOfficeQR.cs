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
    public partial class ucOfficeQR : ucBase
    {
        public ucOfficeQR()
        {
            InitializeComponent();
        }

        public void BindQRData(CLAS.OfficeAccountDataTable dt)
        {

            UIHelper.ComboBoxInit("officeaccounttype", ucAccountTypeMcc, FM);
            UIHelper.ComboBoxInit("officeaccounttype", officeAccountGridEX.DropDowns["ddAccountType"], FM);

            officeAccountBindingSource.DataMember = dt.TableName;
            officeAccountBindingSource.DataSource = dt.DataSet;
            

            dt.ColumnChanged+=new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetCLASMng().GetOfficeAccount().OnUpdate += new atLogic.UpdateEventHandler(ucOfficeQR_OnUpdate);
        }

        void ucOfficeQR_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }
        
        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(officeAccountBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }

        public override void ReloadUserControlData()
        {
            FM.GetCLASMng().GetOfficeAccount().PreRefresh();
            FM.GetCLASMng().GetOfficeAccount().LoadByFileId(FM.CurrentFileId);
            officeAccountGridEX.MoveLast();
        }


        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.OfficeQR;
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        public override void ApplyBR(bool DataNotDirty)
        {
            fFile f = FileForm();
            if (f != null)
            {
                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }

            
            if (DataNotDirty)
            {
                tsNew.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                tsNew.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            CLAS.OfficeAccountRow qrr = (CLAS.OfficeAccountRow)dr;
            UIHelper.EnableControls(officeAccountBindingSource, FM.GetCLASMng().GetOfficeAccount().CanEdit(qrr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetOfficeAccount().CanDelete(qrr));
            UIHelper.EnableCommandBarCommand(tsNew, FM.GetCLASMng().GetOfficeAccount().CanAdd(FM.CurrentFile));
            
        }
        private CLAS.OfficeAccountRow CurrentRow()
        {
            if (officeAccountBindingSource.Current == null)
                return null;
            else
                return (CLAS.OfficeAccountRow)((DataRowView)officeAccountBindingSource.Current).Row;
        }
        public override void Save()
        {
            if (FM.GetCLASMng().DB.OfficeAccount.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.officeAccountBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetOfficeAccount());
                    bp.AddForUpdate(FM.EFile);
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
                    this.officeAccountBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetOfficeAccount());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();
                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }

            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public override void MoreInfo(string linkTable, int linkId)
        {
            officeAccountBindingSource.Position = officeAccountBindingSource.Find("OfficeAccountID", linkId);
        }
        public override void EndEdit()
        {
            officeAccountBindingSource.EndEdit();
        }

        public override void Cancel()
        {
            ApplyBR(true);
            UIHelper.Cancel(officeAccountBindingSource);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "tsNew":
                        lmDatasets.CLAS.OfficeAccountRow qrRow = (lmDatasets.CLAS.OfficeAccountRow)FM.GetCLASMng().GetOfficeAccount().Add(FM.CurrentFile);
                        officeAccountBindingSource.Position = officeAccountBindingSource.Find("OfficeAccountID", qrRow.OfficeAccountID);
                        transactionDateCalendarCombo.Focus();
                        break;
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

        private void officeAccountBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.OfficeAccountRow qrr = CurrentRow();

                if (qrr == null || qrr.IsNull("OfficeAccountID"))
                    return;

                ApplySecurity(qrr);
            }
            catch (Exception x)
            {
               // UIHelper.HandleUIException(x);
            }
        }

        private void ucOfficeQR_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                officeAccountGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


    }
}

