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
    public partial class ucFileAccount : ucBase
    {
        public ucFileAccount()
        {
            InitializeComponent();
            
        }
        public void bindFileAccountData(lmDatasets.CLAS.DebtDataTable dt)
        {
            uiTabPage2.Enabled = false;
            officeIducOfficeSelectBox.AtMng = FM.AtMng;
            UIHelper.ComboBoxInit("ReturnCode", ucClosureCodeMcc, FM);
            UIHelper.ComboBoxInit("vaccounttypelist", ucAccountTypeMcc, FM);
            UIHelper.ComboBoxInit("LP", ucLPCodeMcc, FM);
            UIHelper.ComboBoxInit("ReturnCode", ucReturnCodeMcc, FM);
            UIHelper.ComboBoxInit("InterestRateType", rateTypeucMultiDropDown,FM);

            setBindingSources();

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetCLASMng().DB.AccountHistory.ColumnChanged+= new DataColumnChangeEventHandler(dt_ColumnChanged);

            FM.GetCLASMng().GetDebt().OnUpdate += new atLogic.UpdateEventHandler(ucFileAccount_OnUpdate);
            FM.GetCLASMng().GetAccountHistory().OnUpdate += new atLogic.UpdateEventHandler(ucFileAccount_OnUpdate);
            
            debtGridEX.MoveFirst();
            accountHistoryGridEX.MoveLast();

        }
        public override bool controlHasBorder()
        {
            return false;
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.DebtorAccounts;
        }

        private void setBindingSources()
        {
            debtBindingSource.DataMember = FM.GetCLASMng().DB.Debt.TableName;
            debtBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            debtGridEX.MoveFirst();
            accountHistoryGridEX.MoveFirst();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        void ucFileAccount_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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
            debtBindingSource.EndEdit();
            accountHistoryBindingSource.EndEdit();
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(debtBindingSource, !makeReadOnly);
            UIHelper.EnableControls(accountHistoryBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled=!makeReadOnly;
            uiCommandBar3.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
                ApplyHistorySecurity(CurrentRowAccountHistory());
            }
        }

        public override void ApplySecurity(DataRow dr)
        {
            CLAS.DebtRow cbr = (CLAS.DebtRow)dr;
            bool okToEdit = FM.GetCLASMng().GetDebt().CanEdit(cbr);
            UIHelper.EnableControls(debtBindingSource, okToEdit);
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetDebt().CanDelete(cbr));
            
            accountHistoryGridEX.RootTable.Columns["colDelete"].Visible = okToEdit;

        }

        public void ApplyHistorySecurity(DataRow dr)
        {
            if (dr != null)
                UIHelper.EnableControls(accountHistoryBindingSource, FM.GetCLASMng().GetDebt().CanEdit(CurrentRow()));
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            debtBindingSource.Position = debtBindingSource.Find("DebtId", linkId);
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

        public override void Save()
        {
            if (FM.GetCLASMng().DB.Debt.HasErrors || FM.GetCLASMng().DB.AccountHistory.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    debtBindingSource.EndEdit();
                    accountHistoryBindingSource.EndEdit();

                    //atLogic.BusinessProcess bp = FM.GetBP();

                    //bp.AddForUpdate(FM.GetCLASMng().GetDebt());
                    //bp.AddForUpdate(FM.GetCLASMng().GetAccountHistory());
                    //bp.AddForUpdate(FM.GetActivityBF());
                    //bp.AddForUpdate(FM.EFile);

                    //bp.Update();

                    FM.SaveAll();
                   
                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();

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
                if (accountHistoryBindingSource.Count > 0)
                {
                    throw new LMException(LawMate.Properties.Resources.UIDeleteAccountHistoryBeforeAccount);
                }
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    debtBindingSource.EndEdit();

                    FM.SaveAll();

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

        private void DeleteAccountHistory()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowAccountHistory().Delete();
                    accountHistoryBindingSource.EndEdit();

                    FM.SaveAll();


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

        private CLAS.DebtRow CurrentRow()
        {
            if (debtBindingSource.Current == null)
                return null;
            else
                return (CLAS.DebtRow)((DataRowView)debtBindingSource.Current).Row;
        }

        private CLAS.AccountHistoryRow CurrentRowAccountHistory()
        {
            if (accountHistoryBindingSource.Current == null)
                return null;
            else
                return (CLAS.AccountHistoryRow)((DataRowView)accountHistoryBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(debtBindingSource);
            UIHelper.Cancel(accountHistoryBindingSource);
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
                    case "cmdFilter":
                        if (e.Command.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            debtGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            debtGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "cmdGroupBy":
                        if (e.Command.Checked == Janus.Windows.UI.InheritableBoolean.True)
                            debtGridEX.GroupByBoxVisible = true;
                        else
                            debtGridEX.GroupByBoxVisible = false;
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


        private void accountHistoryGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DeleteAccountHistory();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void debtBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("DebtId"))
                    return;

                //apply security
                ApplySecurity(CurrentRow());


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void accountHistoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            uiTabPage2.Enabled = true;
            CLAS.AccountHistoryRow cbr = CurrentRowAccountHistory();
            ApplyHistorySecurity(cbr);
        }

        private void accountHistoryGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
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

        private void debtGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
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

        private void uiCheckBox1_BindableValueChanged(object sender, EventArgs e)
        {
            try
            {
                if(uiCheckBox1.BindableValue.ToString() != "")
                    lblStatuteBarredMessage.Visible = (bool)uiCheckBox1.BindableValue;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}

