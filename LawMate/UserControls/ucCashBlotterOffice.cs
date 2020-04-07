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
    public partial class ucCashBlotterOffice : ucBase
    {
        int cbId;

        public ucCashBlotterOffice()
        {
            InitializeComponent();
        }

        public void bindCBData(CLAS.CashBlotterDataTable dt)
        {
            UIHelper.ComboBoxInit("CBInstrumentType", valuableTypeComboBox, FM);
            UIHelper.ComboBoxInit("CBInstrumentType", cBDetailGridEX.DropDowns["ddInstrumentType"], FM);
            UIHelper.ComboBoxInit("CBNatureOfPayment", natureOfPaymentComboBox,FM);
            UIHelper.ComboBoxInit("CBPaymentSource",paymentSourceComboBox,FM);
            UIHelper.ComboBoxInit("CBStatus",statusCodeComboBox,FM);
            UIHelper.ComboBoxInit("CurrencyCode",currencyCodeComboBox,FM);
            UIHelper.ComboBoxInit("vofficelist", mccOfficeCode, FM);

            ucContactSelectBox1.FM = FM;
            ucContactSelectBox2.FM = FM;

            setBindingSources();

            CLAS.CBDetailDataTable cbDetailDt;
            cbDetailDt = FM.GetCLASMng().DB.CBDetail;

            //CLAS.CashBlotterRow cr = (CLAS.CashBlotterRow)FM.GetCLASMng().GetCashBlotter().GetCurrentRow()[0];

            //cashBlotterBindingSource.Position= cashBlotterBindingSource.Find("CashBlotterID", cr.CashBlotterID);
            cbDetailDt.ColumnChanged+= new DataColumnChangeEventHandler(cbDetailDt_ColumnChanged);

            FM.GetCLASMng().GetCashBlotter().OnUpdate += new atLogic.UpdateEventHandler(ucCashBlotterOffice_OnUpdate);
            FM.GetCLASMng().GetCBDetail().OnUpdate += new atLogic.UpdateEventHandler(ucCashBlotterOffice_OnUpdate);

            ApplySecurity(CurrentRow());
            FileTreeView.BuildMenu(FM, tsActions,"CBOffice");
        }
        
        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.CashBlotterOffice;
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        private void setBindingSources()
        {
            //cashBlotterBindingSource.DataMember = FM.GetCLASMng().DB.CashBlotter.TableName;
            //cashBlotterBindingSource.DataSource = FM.GetCLASMng().DB;
            //cashBlotterBindingSource.Sort = "cashblotterid desc";

            DataView dv = new DataView(FM.GetCLASMng().DB.CashBlotter, "", "cashblotterid desc", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);
            cashBlotterBindingSource.DataSource = dv;
            cashBlotterBindingSource.DataMember = "";

            cashBlotterBindingSource.Position = 0;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            cashBlotterGridEX.MoveFirst();
            cBDetailGridEX.MoveFirst();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public void MoreInfo(string linkTable, int linkId, int CBDetailId)
        {
            MoreInfo(linkTable, linkId);
            cBDetailBindingSource.Position = cBDetailBindingSource.Find("CashBlotterDetailID", CBDetailId);
 
        }
        public override void MoreInfo(string linkTable, int linkId)
        {
            cashBlotterBindingSource.Position = cashBlotterBindingSource.Find("CashBlotterID", linkId);
        }


        void ucCashBlotterOffice_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void cbDetailDt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                {
                    ApplyBR(false);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        public override void EndEdit()
        {
            cashBlotterBindingSource.EndEdit();
            cBDetailBindingSource.EndEdit();
        }
        private CLAS.CashBlotterRow CurrentRow()
        {
            if (cashBlotterBindingSource.Current == null)
                return null;
            else
                return (CLAS.CashBlotterRow)((DataRowView)cashBlotterBindingSource.Current).Row;
        }

        private CLAS.CBDetailRow CurrentDetailRow()
        {
            if (cBDetailBindingSource.Current == null)
                return null;
            else
                return(CLAS.CBDetailRow)((DataRowView)cBDetailBindingSource.Current).Row;
        }

        private void loadCBDetailData()
        {
            CLAS.CashBlotterRow cbr = CurrentRow();
            if (cbr.CashBlotterID != cbId)
            {
                FM.GetCLASMng().DB.CBDetail.Clear();
                FM.GetCLASMng().GetCBDetail().LoadByCashBlotterId(cbr.CashBlotterID);
                cbId = cbr.CashBlotterID;
            }
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(cashBlotterBindingSource, !makeReadOnly);
            UIHelper.EnableControls(cBDetailBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;
            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }

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
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }
        
        public override void ApplySecurity(DataRow dr)
        {
            CLAS.CashBlotterRow cbr = (CLAS.CashBlotterRow)dr;
            bool okToEdit = FM.GetCLASMng().GetCashBlotter().CanEdit(cbr);
            UIHelper.EnableControls(cashBlotterBindingSource, okToEdit);
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetCashBlotter().CanDelete(cbr));

            //if (okToEdit)
            //    cmdProcessCB.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            //else
            //    cmdProcessCB.Enabled = Janus.Windows.UI.InheritableBoolean.False;


        }
        public void ApplyCBDetailSecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.CBDetailRow cbr = (CLAS.CBDetailRow)dr;
                UIHelper.EnableControls(cBDetailBindingSource, FM.GetCLASMng().GetCBDetail().CanEdit(cbr));
            }
        }

        private void ApplyRowBR()
        {
            bool noDetailRow = false;
            CLAS.CashBlotterRow cbr = CurrentRow();
            if(cbr.GetCBDetailRows().Length==0)
                noDetailRow = true;
            
            //CLAS.CBDetailRow cbdr = CurrentDetailRow();
            //f (cbdr == null)
            //    noDetailRow = true;

            bool noAccess = (FM.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.Atrium) == atSecurity.SecurityManager.ExPermissions.No);
                
            if (noDetailRow || (!cbr.IsNull("FirstConfirm") && !cbr.IsNull("SecondConfirm")) || noAccess) //CB Processed; is Final
            {
                tsProcessFirst.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsProcessSecond.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdProcessCB.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                tsSave.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                valuableAmountNumericEditBox.ReadOnly = true;
                valuableAmountNumericEditBox.BackColor = SystemColors.Control;
                valuableDateCalendarCombo.ReadOnly = true;
                valuableDateCalendarCombo.BackColor = SystemColors.Control;
                valuableTypeComboBox.ReadOnly = true;
                currencyCodeComboBox.ReadOnly =true;
                statusCodeComboBox.ReadOnly = true;
                natureOfPaymentComboBox.ReadOnly = true;
                paymentSourceComboBox.ReadOnly = true;
                commentsEditBox.ReadOnly = true;
                commentsEditBox.BackColor = SystemColors.Control;
            }
            else
            {
                cmdProcessCB.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                if (!cbr.IsNull("FirstConfirm"))
                {
                    tsProcessFirst.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    tsProcessSecond.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    tsProcessFirst.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    tsProcessSecond.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }

                tsSave.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                valuableAmountNumericEditBox.ReadOnly = false;
                valuableAmountNumericEditBox.BackColor = SystemColors.Window;
                valuableDateCalendarCombo.ReadOnly = false;
                valuableDateCalendarCombo.BackColor = SystemColors.Window;
                valuableTypeComboBox.ReadOnly = false;
                currencyCodeComboBox.ReadOnly = false;
                statusCodeComboBox.ReadOnly = false;
                natureOfPaymentComboBox.ReadOnly = false;
                paymentSourceComboBox.ReadOnly = false;
                commentsEditBox.ReadOnly = false;
                commentsEditBox.BackColor = SystemColors.Window;
            }
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.CBDetail.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    cBDetailBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetCBDetail());
                //    bp.AddForUpdate(FM.EFile);
                    bp.Update();

                    ApplyBR(true);
                    ApplyRowBR();
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
                    CurrentDetailRow().Delete();
                    this.cBDetailBindingSource.EndEdit();

                    FM.SaveAll();

                    ApplyBR(true);
                }

            }
            catch (Exception x)
            {
                
               throw x;
            }
        }

        private void ProcessCashBlotter()
        {
            CLAS.CashBlotterRow drCB = (CLAS.CashBlotterRow) FM.GetCLASMng().DB.CashBlotter.Select("SecondConfirm is null")[0];
            bool createsNewCB = false;
            string processMessage = "Process Cash Blotter (First Confirm)?";
            if (!drCB.IsFirstConfirmNull())
            {
                processMessage = "Process Cash Blotter (Second Confirm)?";
                createsNewCB = true;
            }

            if (MessageBox.Show(processMessage, "Process Cash Blotter", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                ActivityConfig.ACSeriesRow acsr;
                if (createsNewCB)
                    acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(UIHelper.AtMng.GetSetting(atriumBE.AppIntSetting.CBSecondConfirmAcId));
                else
                    acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(UIHelper.AtMng.GetSetting(atriumBE.AppIntSetting.CBFirstConfirmAcId));

                this.FileForm().ReadOnly = true;
                fACWizard facwr = new fACWizard(FM, acsr.ACSeriesId, atriumBE.ACEngine.RevType.CashBlotter, CurrentRow().CashBlotterID,null);
                this.FileForm().HookupWizClose(facwr);
                facwr.Show();
            }
        }

        public override void Cancel()
        {
            UIHelper.Cancel(cBDetailBindingSource);
            UIHelper.Cancel(cashBlotterBindingSource);
            ApplyBR(true);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars["cbMergeToolbar"];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "tsProcessFirst":
                        ProcessCashBlotter();
                        break;
                    case "tsProcessSecond":
                        ProcessCashBlotter();
                        break;
                    case "tsSave":
                        Save();
                        break;
                    case "tsDelete":
                        Delete();
                        break;
                    case "cmdGoToActivity":
                        FileForm().MainForm.OpenFile(CurrentDetailRow().FileID);
                        break;
                    case "cmdGoToCB":
                        fFile f1 = FileForm().MainForm.OpenFile(CurrentDetailRow().FileID);
                        f1.MoreInfo("cbdetail", CurrentDetailRow().CashBlotterDetailID);
                        break;
                    case "cmdGoToGeneralFile":
                        FileForm().MainForm.OpenFile(CurrentDetailRow().FileID);
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                    case "tsPrintCB":
                        ActivityConfig.ACSeriesRow acsr;
                        if (CurrentRow().IsRemittedDateNull())
                            acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(UIHelper.AtMng.GetSetting(atriumBE.AppIntSetting.CBPrintDraftAcId));
                        else
                            acsr = FM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(UIHelper.AtMng.GetSetting(atriumBE.AppIntSetting.CBPrintCopyAcId));

                        this.FileForm().ReadOnly = true;
                        fACWizard facwr = new fACWizard(FM, acsr.ACSeriesId, atriumBE.ACEngine.RevType.CashBlotter, CurrentRow().CashBlotterID,null);
                        this.FileForm().HookupWizClose(facwr);
                        facwr.Show();

                        break;
                }
                FileForm().HandleACSMenu(e, CurrentRow());

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cashBlotterBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.CashBlotterRow cbr = CurrentRow();

                if (cbr == null)
                    return;

                
                if (cbr.IsNull("CashBlotterID"))
                    return;

                loadCBDetailData();
                ApplySecurity(cbr);
                ApplyRowBR();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void cBDetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.CBDetailRow cbr = CurrentDetailRow();
                ApplyCBDetailSecurity(cbr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void valuableDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                UIHelper.TodaysDateShortcutKey(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                atriumBE.FileManager jumpToFM = FM.AtMng.GetFile(CurrentDetailRow().FileID);
                if (!jumpToFM.CurrentFile.IsOpponentIDNull())
                {
                    cmdGoToActivity.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    cmdGoToCB.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    cmdGoToGeneralFile.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }
                else
                {
                    cmdGoToActivity.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdGoToCB.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdGoToGeneralFile.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                this.Cursor = Cursors.Default;

            }
            catch (Exception x)
            {
                this.Cursor = Cursors.Default;
                UIHelper.HandleUIException(x);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        private void ucCashBlotterOffice_Load(object sender, EventArgs e)
        {
            try
            {
                cashBlotterGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

