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
    public partial class ucCashBlotter : ucBase
    {
        public ucCashBlotter()
        {
            InitializeComponent();
        }

        public void bindCBData(lmDatasets.CLAS.CBDetailDataTable a)
        {

            UIHelper.ComboBoxInit("CBInstrumentType", valuableTypeComboBox, FM);
            UIHelper.ComboBoxInit("CBNatureOfPayment", natureOfPaymentComboBox, FM);
            UIHelper.ComboBoxInit("CBPaymentSource", paymentSourceComboBox, FM);
            UIHelper.ComboBoxInit("CBStatus",statusCodeComboBox , FM);
            UIHelper.ComboBoxInit("CurrencyCode",currencyCodeComboBox , FM);
            ucOfficeSelectBox1.AtMng = FM.AtMng;

            UIHelper.ComboBoxInit("CBInstrumentType", cBDetailGridEX.DropDowns["ddCBInstrumentType"], FM);
            UIHelper.ComboBoxInit("CBNatureOfPayment", cBDetailGridEX.DropDowns["ddNatureOfPayment"], FM);
            UIHelper.ComboBoxInit("CBPaymentSource", cBDetailGridEX.DropDowns["ddCBPaymentSource"], FM);
            UIHelper.ComboBoxInit("vofficelist", cBDetailGridEX.DropDowns["ddOffice"], FM);
            UIHelper.ComboBoxInit("CBStatus", cBDetailGridEX.DropDowns["ddCBStatus"], FM);
            UIHelper.ComboBoxInit("CurrencyCode", cBDetailGridEX.DropDowns["ddCurrency"], FM);

            setBindingSources();

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetCLASMng().GetCBDetail().OnUpdate += new atLogic.UpdateEventHandler(ucCashBlotter_OnUpdate);

        

            CalculateAllAndCompletedPayments();
            ApplySecurity(CurrentRow());


        }

        private void setBindingSources()
        {
            cBDetailBindingSource.DataMember = FM.GetCLASMng().DB.CBDetail.TableName;
            cBDetailBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            cBDetailGridEX.MoveFirst();
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            cBDetailBindingSource.Position = cBDetailBindingSource.Find("CashBlotterDetailID", linkId);
        }

        public override bool controlHasBorder()
        {
            return false;
        }

        void ucCashBlotter_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.CashBlotter;
        }

        private void CalculateAllAndCompletedPayments()
        {
            tbAllPayments.Text = FM.GetCLASMng().GetCBDetail().AllPayments().ToString();
            tbCompletedPayments.Text = FM.GetCLASMng().GetCBDetail().CompletedPayments().ToString();
            
            if(FM.GetCLASMng().GetCBDetail().MoreThanTwoNSFs())
                lblMoreThan2NSFs.Visible = true;
            else
                lblMoreThan2NSFs.Visible = false;
        }

        public override void EndEdit()
        {
            cBDetailBindingSource.EndEdit();
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(cBDetailBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;
            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
            }
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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

            lmWinHelper.EditModeCommandToggle(tsEditMode, !DataNotDirty);
        }

        public override void ApplySecurity(DataRow brow)
        {
            CLAS.CBDetailRow cbr = (CLAS.CBDetailRow)brow;
            UIHelper.EnableControls(cBDetailBindingSource, FM.GetCLASMng().GetCBDetail().CanEdit(cbr));

            btnGoToOfficeCB.Visible = FM.AllowedForOffice(cbr.OfficeID);
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
                    this.cBDetailBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetCLASMng().GetCBDetail());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();

                    ApplyBR(true);
                    CalculateAllAndCompletedPayments();
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
                    this.cBDetailBindingSource.EndEdit();

                    FM.SaveAll();

                    ApplyBR(true);
                    CalculateAllAndCompletedPayments();

                    fFile f = (fFile)this.ParentForm;
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
            ApplyBR(true);
            UIHelper.Cancel(cBDetailBindingSource);
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


        private CLAS.CBDetailRow CurrentRow()
        {
            if (cBDetailBindingSource.Current == null)
                return null;
            else
                return (CLAS.CBDetailRow)((DataRowView)cBDetailBindingSource.Current).Row;
        }


        private void receivedDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            UIHelper.TodaysDateShortcutKey(sender, e);
        }

        private void cBDetailBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.CBDetailRow cbr = CurrentRow();

                
                if (cbr == null || (cbr != null && cbr.IsNull("CashBlotterDetailID")))
                    return;

                ApplySecurity(cbr);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnGoToOfficeCB_Click(object sender, EventArgs e)
        {
            try
            {
                CLAS.CashBlotterRow cbr = FM.GetCLASMng().GetCashBlotter().Load(CurrentRow().CashBlotterID);
                fFile cbFile = FileForm().MainForm.OpenFile(cbr.FileID);
                ucBase ctl = cbFile.MoreInfo("cashblotter");
                ucCashBlotterOffice cbCtl = (ucCashBlotterOffice)ctl;
                cbCtl.MoreInfo("cashblotter", cbr.CashBlotterID, CurrentRow().CashBlotterDetailID);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucCashBlotter_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                cBDetailGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}
