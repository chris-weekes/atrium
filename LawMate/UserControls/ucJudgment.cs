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
    public partial class ucJudgment : ucBase
    {
        public ucJudgment()
        {
            InitializeComponent();
        }

        public void bindJudgmentData(lmDatasets.CLAS ds)
        {
            UIHelper.ComboBoxInit("ProcessType", processTypeCodeucMultiDropDown1,FM);
            UIHelper.ComboBoxInit("JudgmentCourtLevel", judgmentCourtLevelCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("JudgmentType", judgmentTypeCodeucMultiDropDown, FM);
            officeIDucOfficeSelectBox.AtMng = FM.AtMng;
            officeIDucOfficeSelectBox1.AtMng = FM.AtMng;

            UIHelper.ComboBoxInit("InterestRateType", preJudgmentRateTypeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("InterestRateType", postJudgmentRateTypeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("InterestRateType", postJRateTypeOnCostucMultiDropDown, FM);
            UIHelper.ComboBoxInit("vaccounttypelist", ucAccountTypeMcc, FM);
            UIHelper.ComboBoxInit("InterestRateType", rateTypeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("TypeofWrit", typeofWritCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("PostJudgmentActivity", postJudgmentActivityCodeucMultiDropDown, FM);
            UIHelper.ComboBoxInit("TypeofWrit", writGridEX.DropDowns["ddTypeOfWrit"], FM);
            UIHelper.ComboBoxInit("PostJudgmentActivity", costGridEX.DropDowns["ddPostJudgmentActivity"], FM);

            setBindingSources();

            ds.Judgment.ColumnChanged+=new DataColumnChangeEventHandler(dt_ColumnChanged);
            ds.JudgmentAccount.ColumnChanged += dt_ColumnChanged;
            ds.Writ.ColumnChanged += dt_ColumnChanged;
            ds.Cost.ColumnChanged += dt_ColumnChanged;

            FM.GetCLASMng().GetJudgment().OnUpdate += new atLogic.UpdateEventHandler(ucJudgment_OnUpdate);
            FM.GetCLASMng().GetJudgmentAccount().OnUpdate += ucJudgment_OnUpdate;
            FM.GetCLASMng().GetWrit().OnUpdate += ucJudgment_OnUpdate;
            FM.GetCLASMng().GetCost().OnUpdate += ucJudgment_OnUpdate;

            ApplySecurity(CurrentRow());
            ApplyBRJudgment();
        }

        private void setBindingSources()
        {
            atriumDB_JudgmentDataTableBindingSource.DataMember = "Judgment";
            atriumDB_JudgmentDataTableBindingSource.DataSource = FM.GetCLASMng().DB;
        }

        void ucJudgment_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }
        public override bool controlHasBorder()
        {
            return false;
        }
        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                {
                    ApplyBR(false);

                    switch (e.Column.Table.TableName)
                    {
                        case "JudgmentAccount":
                            judgmentAccountGridEX.Enabled = false;
                            uiTabPage2.Enabled = false;
                            uiTabPage3.Enabled = false;
                            break;
                        case "Writ":
                            writGridEX.Enabled = false;
                            uiTabPage1.Enabled = false;
                            uiTabPage3.Enabled = false;
                            break;
                        case "Cost":
                            costGridEX.Enabled = false;
                            uiTabPage1.Enabled = false;
                            uiTabPage2.Enabled = false;
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }   
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(atriumDB_JudgmentDataTableBindingSource, !makeReadOnly);
            UIHelper.EnableControls(atriumDB_JudgmentAccountDataTableBindingSource, !makeReadOnly);
            UIHelper.EnableControls(atriumDB_WritDataTableBindingSource, !makeReadOnly);
            UIHelper.EnableControls(atriumDB_CostDataTableBindingSource, !makeReadOnly);
            uiCommandBar2.Enabled = !makeReadOnly;
            uiCommandBar3.Enabled = !makeReadOnly;

            if (!makeReadOnly)
            {
                ApplySecurity(CurrentRow());
                ApplyJudgementAccountSecurity(CurrentRowJudgmentAccount());
                ApplyWritSecurity(CurrentRowWrit());
                ApplyWritHistorySecurity(CurrentRowWritHistory());
                ApplyCostSecurity(CurrentRowCost());
            }
        }

        private CLAS.JudgmentRow CurrentRow()
        {
            if (atriumDB_JudgmentDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.JudgmentRow)((DataRowView)this.atriumDB_JudgmentDataTableBindingSource.Current).Row;
        }

        private CLAS.JudgmentAccountRow CurrentRowJudgmentAccount()
        {
            if (atriumDB_JudgmentAccountDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.JudgmentAccountRow)((DataRowView)this.atriumDB_JudgmentAccountDataTableBindingSource.Current).Row;
        }

        private CLAS.WritRow CurrentRowWrit()
        {
            if (atriumDB_WritDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.WritRow)((DataRowView)this.atriumDB_WritDataTableBindingSource.Current).Row;
        }

        private CLAS.WritHistoryRow CurrentRowWritHistory()
        {
            if (atriumDB_WritHistoryDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.WritHistoryRow)((DataRowView)this.atriumDB_WritHistoryDataTableBindingSource.Current).Row;
        }

        private CLAS.CostRow CurrentRowCost()
        {
            if (atriumDB_CostDataTableBindingSource.Current == null)
                return null;
            else
                return (CLAS.CostRow)((DataRowView)this.atriumDB_CostDataTableBindingSource.Current).Row;
        }
        public override void EndEdit()
        {
            atriumDB_JudgmentDataTableBindingSource.EndEdit();
            atriumDB_JudgmentAccountDataTableBindingSource.EndEdit();
            atriumDB_WritDataTableBindingSource.EndEdit();
            atriumDB_CostDataTableBindingSource.EndEdit();
        }

        

        public override void ApplySecurity(DataRow dr)
        {
            CLAS.JudgmentRow jr = (CLAS.JudgmentRow)dr;
            UIHelper.EnableControls(atriumDB_JudgmentDataTableBindingSource, FM.GetCLASMng().GetJudgment().CanEdit(jr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetCLASMng().GetJudgment().CanDelete(jr));
        }
        public void ApplyJudgementAccountSecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.JudgmentAccountRow jr = (CLAS.JudgmentAccountRow)dr;
                UIHelper.EnableControls(atriumDB_JudgmentAccountDataTableBindingSource, FM.GetCLASMng().GetJudgmentAccount().CanEdit(jr));
            }
        }
        public void ApplyWritSecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.WritRow jr = (CLAS.WritRow)dr;
                UIHelper.EnableControls(atriumDB_WritDataTableBindingSource, FM.GetCLASMng().GetWrit().CanEdit(jr));
                bool canDelete = FM.GetCLASMng().GetWrit().CanDelete(jr);
                writGridEX.RootTable.Columns["colDelete"].Visible = canDelete;
            }
        }
        public void ApplyCostSecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.CostRow jr = (CLAS.CostRow)dr;
                UIHelper.EnableControls(atriumDB_CostDataTableBindingSource, FM.GetCLASMng().GetCost().CanEdit(jr));
                bool canDelete = FM.GetCLASMng().GetCost().CanDelete(jr);
                costGridEX.RootTable.Columns["colDelete"].Visible = canDelete;
            }
        }
        public void ApplyWritHistorySecurity(DataRow dr)
        {
            if (dr != null)
            {
                CLAS.WritHistoryRow jr = (CLAS.WritHistoryRow)dr;
                UIHelper.EnableControls(atriumDB_WritHistoryDataTableBindingSource, FM.GetCLASMng().GetWritHistory().CanEdit(jr));
            }
        }

        bool InEditMode = false;
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

            InEditMode = !DataNotDirty;

            if (DataNotDirty)
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }

            lmWinHelper.EditModeCommandToggle(tsEditmode, InEditMode);
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.Judgment;
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
            MoreInfo("Judgment", navId);
            
        }

        private void ApplyBRJudgment()
        {
            CLAS.JudgmentRow jr = CurrentRow();
            judgmentAccountGridEX.Enabled = true;
            costGridEX.Enabled = true;
            writGridEX.Enabled = true;
            uiTabPage1.Enabled = true;
            uiTabPage3.Enabled = !HasNoCostRecords(jr);
            uiTabPage2.Enabled = !HasNoWritRecords(jr);
            

            uiTab3.Visible = !jr.IsJudgmentDateNull();
            uiTab1.Visible = !jr.IsJudgmentDateNull();
        }

        private bool HasNoCostRecords(CLAS.JudgmentRow dr)
        {
            foreach (CLAS.CostRow cr in FM.GetCLASMng().DB.Cost.Rows)
            {
                if (cr.JudgmentID == dr.JudgmentID)
                    return false;
            }
            return true;
        }

        private bool HasNoWritRecords(CLAS.JudgmentRow dr)
        {
            foreach (CLAS.WritRow wr in FM.GetCLASMng().DB.Writ.Rows)
            {
                if (wr.JudgmentID == dr.JudgmentID)
                {
                    writGridEX.ExpandRecords();
                    return false;
                }
            }
            return true;
        }

        private int navId = -1;
        public override void MoreInfo(string linkTable, int linkId)
        {
            switch (linkTable.ToLower())
            {
                case "writ":
                    CLAS.WritRow wr = FM.GetCLASMng().DB.Writ.FindByWritID(linkId);
                    atriumDB_JudgmentDataTableBindingSource.Position = atriumDB_JudgmentDataTableBindingSource.Find("JudgmentID", wr.JudgmentID);
                    atriumDB_WritDataTableBindingSource.Position = atriumDB_WritDataTableBindingSource.Find("WritID", linkId);
                    uiTab1.SelectedTab = uiTabPage2;
                    pnlAllContainer.ScrollControlIntoView(uiTabPage2);
                    break;
                case "cost":
                    CLAS.CostRow cr = FM.GetCLASMng().DB.Cost.FindByCostID(linkId);
                    atriumDB_JudgmentDataTableBindingSource.Position = atriumDB_JudgmentDataTableBindingSource.Find("JudgmentID", cr.JudgmentID);
                    atriumDB_CostDataTableBindingSource.Position = atriumDB_CostDataTableBindingSource.Find("CostID", linkId);
                    uiTab1.SelectedTab = uiTabPage3;
                    pnlAllContainer.ScrollControlIntoView(uiTabPage3);
                    break;
                default:
                    atriumDB_JudgmentDataTableBindingSource.Position = atriumDB_JudgmentDataTableBindingSource.Find("JudgmentID", linkId);
                    uiTab1.SelectedTab = uiTabPage1;
                    navId = linkId;
                    break;
            }
            ApplySecurity(CurrentRow());
            ApplyBRJudgment();
        }

        public override void Save()
        {
            if (FM.GetCLASMng().DB.Judgment.HasErrors || FM.GetCLASMng().DB.JudgmentAccount.HasErrors || FM.GetCLASMng().DB.Cost.HasErrors || FM.GetCLASMng().DB.Writ.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.GetCLASMng().DB);
            }
            else
            {
                try
                {
                    this.atriumDB_JudgmentDataTableBindingSource.EndEdit();
                    this.atriumDB_JudgmentAccountDataTableBindingSource.EndEdit();
                    this.atriumDB_CostDataTableBindingSource.EndEdit();
                    this.atriumDB_WritDataTableBindingSource.EndEdit();
                    

                    FM.SaveAll();

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                    ApplyBR(true);
                    ApplyBRJudgment();
                }
                catch (Exception x)
                {
                    
                    UIHelper.HandleUIException(x);
                }
            }
        }
        public override void Delete()
        {
            try
            {
                if (CurrentRow().GetCostRows().Length > 0 || CurrentRow().GetWritRows().Length>0)
                    throw new LMException(Properties.Resources.CantDeleteWritCostBeforeJudgment);

                if (UIHelper.ConfirmDelete())
                {

                    foreach (CLAS.JudgmentAccountRow jar in FM.GetCLASMng().DB.JudgmentAccount)
                    {
                        if (jar.JudgmentID == CurrentRow().JudgmentID)
                        {
                            jar.Delete();
                        }
                    }
                    CurrentRow().Delete();
                    this.atriumDB_JudgmentAccountDataTableBindingSource.EndEdit();
                    this.atriumDB_JudgmentDataTableBindingSource.EndEdit();

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

        private void DeleteCost()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowCost().Delete();
                    atriumDB_CostDataTableBindingSource.EndEdit();

                    FM.SaveAll();

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        private void DeleteWrit()
        {
            try
            {
                if (atriumDB_WritHistoryDataTableBindingSource.Count > 0)
                {
                    throw new LMException(LawMate.Properties.Resources.UIDeleteWritHistoryBeforeWrit);
                }
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowWrit().Delete();
                    atriumDB_WritDataTableBindingSource.EndEdit();

                    FM.SaveAll();

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        private void DeleteWritHistory()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRowWritHistory().Delete();
                    atriumDB_WritHistoryDataTableBindingSource.EndEdit();

                    FM.SaveAll();


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
            UIHelper.Cancel(atriumDB_JudgmentDataTableBindingSource);
            UIHelper.Cancel(atriumDB_JudgmentAccountDataTableBindingSource);
            UIHelper.Cancel(atriumDB_WritDataTableBindingSource);
            UIHelper.Cancel(atriumDB_CostDataTableBindingSource);
            ApplyBR(true);
            ApplyBRJudgment();
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

        private void costGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DeleteCost();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }

        private void writGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Table.Key == "Writ")
                    DeleteWrit();

                if (e.Column.Table.Key == "WritWritHistory")
                    DeleteWritHistory();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void judgmentAccountGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(judgmentAccountGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void writGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(writGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void costGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(costGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        
        private void judgmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.JudgmentRow dr = CurrentRow();

                if (dr == null)
                    return;

                if (dr.IsNull("JudgmentID"))
                    return;

                ApplySecurity(dr);
                atriumDB_JudgmentAccountDataTableBindingSource.Filter = "JudgmentID=" + dr.JudgmentID.ToString();

                DataView dv = new DataView(FM.GetCLASMng().DB.JudgmentAccount, "JudgmentID=" + dr.JudgmentID.ToString(),"", DataViewRowState.CurrentRows);
                AccountIncludedGridEx.DataSource = dv;
                ApplyBRJudgment();
                uiTab1.SelectedTab = uiTabPage1;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void judgmentAccountBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.JudgmentAccountRow dr = CurrentRowJudgmentAccount();
                ApplyJudgementAccountSecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void writBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            { 
                CLAS.WritRow dr = CurrentRowWrit();
                atriumDB_WritHistoryDataTableBindingSource.RemoveFilter();
                if(dr!=null && !dr.IsNull("WritID"))
                    atriumDB_WritHistoryDataTableBindingSource.Filter = "WritID=" + dr.WritID ;

                ApplyWritSecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void costBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                //call applycost security and provide current row
                CLAS.CostRow dr = CurrentRowCost();
                ApplyCostSecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void writHistoryBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                CLAS.WritHistoryRow dr = CurrentRowWritHistory();
                ApplyWritHistorySecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void judgmentGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void judgmentAccountGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void writGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void costGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (InEditMode)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AccountIncludedGridEx_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                int faId = (int)e.Row.Cells["FileAccountId"].Value;
                CLAS.DebtRow[] dr = (CLAS.DebtRow[])FM.GetCLASMng().DB.Debt.Select("FileAccountId=" + faId, "");
                if (dr.Length == 1)
                {
                    //JLL: can't translate AccountTypeDescEng to Fre as AccountTypeDescFre not in dataset
                    //it will be for another day
                    e.Row.Cells["DARSAccountType"].Value =  dr[0].AccountTypeCode + " - " + dr[0].DARSAccountType + " - " + dr[0].AccountTypeDescEng;
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AccountIncludedGridEx_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    int faId = (int)e.Row.Cells["FileAccountId"].Value;
                    FileForm().MoreInfo("debt", faId);

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucJudgment_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
                ApplyJudgementAccountSecurity(CurrentRowJudgmentAccount());
                ApplyCostSecurity(CurrentRowCost());
                ApplyWritSecurity(CurrentRowWrit());
                ApplyWritHistorySecurity(CurrentRowWritHistory());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

