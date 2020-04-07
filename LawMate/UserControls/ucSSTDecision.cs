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
    public partial class ucSSTDecision : ucBase
    {
        atriumBE.SSTManager SSTM;

        public ucSSTDecision()
        {
            InitializeComponent();

          
        }

        public void bindData(lmDatasets.SST.SSTDecisionDataTable dt)
        {
            SSTM = FM.GetSSTMng();

            if (SSTM.GetSSTDecision().CanDelete(dt[0]))
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
            else
            {
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            setBindingSources();

            atLogic.WhereClause wc = new atLogic.WhereClause();
         

            DataTable dtOutcome = FM.Codes("vOutcome", wc, true);

            UIHelper.ComboBoxInit("vDecisionType", sSTDecisionGridEX.DropDowns["ddDecisionType"], FM);
            UIHelper.ComboBoxInit(dtOutcome, sSTDecisionGridEX.DropDowns["ddOutcome"], FM);
            UIHelper.ComboBoxInit("vmemberlist", sSTDecisionGridEX.DropDowns["ddMemberList"], FM);
            UIHelper.ComboBoxInit("vDecisionType", decisionTypeucMultiDropDown, FM);

           // UIHelper.ComboBoxInit(dtOutcome, outcomeIducMultiDropDown, FM);

            FilterOutcomes();

            memberIducContactSelectBox.FM = FM;

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);


            SSTM.GetSSTDecision().OnUpdate += new atLogic.UpdateEventHandler(ucSSTDecision_OnUpdate);
            
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (FM.IsFieldChanged(e.Column, e.Row))
                ApplyBR(false);
        }

        void ucSSTDecision_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
            
        }

        private void setBindingSources()
        {
            sSTDecisionBindingSource.DataMember = SSTM.DB.SSTDecision.TableName;
            sSTDecisionBindingSource.DataSource = SSTM.DB;
        }

        public override string ucDisplayName()
        {
            return "Tribunal Member Decisions";
        }

        public override void ReloadUserControlData()
        {
            setBindingSources();
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void EndEdit()
        {
            sSTDecisionBindingSource.EndEdit();
        }

        public override void ApplySecurity(DataRow dr)
        {
            SST.SSTDecisionRow cbr = (SST.SSTDecisionRow)dr;
            UIHelper.EnableControls(sSTDecisionBindingSource, SSTM.GetSSTDecision().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, SSTM.GetSSTDecision().CanDelete(cbr));

            isFinalUICheckBox.Enabled = false;
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
            lmWinHelper.EditModeCommandToggle(tsEditMode, InEditMode);
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(sSTDecisionBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            sSTDecisionBindingSource.Position = sSTDecisionBindingSource.Find("SSTDecisionId", linkId);
        }

        public override void Save()
        {
            if (SSTM.DB.SSTDecision.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(SSTM.DB);
            }
            else
            {
                try
                {
                    this.sSTDecisionBindingSource.EndEdit();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();

                    //bp.AddForUpdate(SSTM.GetSSTCase());
                    //bp.AddForUpdate(SSTM.GetSSTDecision());
                    //bp.AddForUpdate(SSTM.GetSSTCaseMatter());


                    //bp.AddForUpdate(FM.EFile);
                    //bp.Update();


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
                if (UIHelper.ConfirmDelete())
                {

                    CurrentRow().Delete();

                    FM.SaveAll();
                    //atLogic.BusinessProcess bp = FM.GetBP();
                    
                    //bp.AddForUpdate(SSTM.GetSSTDecision());

                    //bp.Update();

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        private SST.SSTDecisionRow CurrentRow()
        {
            if (sSTDecisionBindingSource.Current == null)
                return null;
            else
                return (SST.SSTDecisionRow)((DataRowView)sSTDecisionBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(sSTDecisionBindingSource);
            SSTM.DB.SSTDecision.RejectChanges();
            FM.CurrentFile.RejectChanges();
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

        private void sSTDecisionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("SSTDecisionId"))
                    return;

                ApplySecurity(CurrentRow());


                FilterOutcomes();
            
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void FilterOutcomes()
        {
            atLogic.WhereClause wc = new atLogic.WhereClause();


            wc.Add("DecisionType", "=", CurrentRow().DecisionType);
            DataTable dtOutcome = FM.Codes("vOutcome", wc, true);

            UIHelper.ComboBoxInit(dtOutcome, outcomeIducMultiDropDown, FM);
        }


    }
}
