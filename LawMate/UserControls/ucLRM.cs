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
    public partial class ucLRM : ucBase
    {

        public ucLRM()
        {
            InitializeComponent();
        }
        public void bindLRMData(atriumDB.RiskAssessmentDataTable a)
        {
            UIHelper.ComboBoxInit("RAStatus", ucRAStatusMcc, FM);
            UIHelper.ComboBoxInit("RAComplexity",ucComplexityMcc , FM);
            UIHelper.ComboBoxInit("RAImpact",ucImpactMcc , FM);
            UIHelper.ComboBoxInit("RALikelihood",ucLikelihoodMcc , FM);
            UIHelper.ComboBoxInit("RARiskLevel",ucRiskLevelMcc, FM);
            UIHelper.ComboBoxInit("RASettlementPossibility",ucSettlementPossibilityMcc, FM);
            UIHelper.ComboBoxInit("LAWYERLIST", ucAssessedByMcc, FM);

            this.riskAssessmentBindingSource.DataSource = a.DataSet;
            this.riskAssessmentBindingSource.DataMember = a.TableName;

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetRiskAssessment().OnUpdate += new atLogic.UpdateEventHandler(ucLRM_OnUpdate);
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.LegalRiskManagement;
        }
        void ucLRM_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
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
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
        }

        public override void ApplySecurity(DataRow dr)
        {
            atriumDB.RiskAssessmentRow cbr = (atriumDB.RiskAssessmentRow)dr;
            UIHelper.EnableControls(riskAssessmentBindingSource, FM.GetRiskAssessment().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetRiskAssessment().CanDelete(cbr));
        }
        public override void MoreInfo(string linkTable, int linkId)
        {
            riskAssessmentBindingSource.Position = riskAssessmentBindingSource.Find("RiskAssessId", linkId);
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(riskAssessmentBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }

        public override void ReloadUserControlData()
        {
           
        }

        private void riskLevelUIComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //update Grid
                int RiskValue=0;
                bool LevelNotNull = ucRiskLevelMcc.SelectedIndex>0;

                if(LevelNotNull) 
                    RiskValue=(int)ucRiskLevelMcc.SelectedValue;

                string lvlKey = "RiskLevel" + RiskValue.ToString();
                pictureBox1.Image = (Image)LawMate.Properties.Resources.ResourceManager.GetObject(lvlKey); 
                
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
                
        }

        public override void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {

                    CurrentRow().Delete();
                    riskAssessmentBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetRiskAssessment());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();

              

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public override void Save()
        {
            if (FM.DB.RiskAssessment.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.riskAssessmentBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetRiskAssessment());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();


                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();


                }
                catch (Exception x)
                {
                    
                    UIHelper.HandleUIException(x);
                }
            }
        }
        private lmDatasets.atriumDB.RiskAssessmentRow CurrentRow()
        {
            if (riskAssessmentBindingSource.Current == null)
                return null;
            else
                return (lmDatasets.atriumDB.RiskAssessmentRow)((DataRowView)riskAssessmentBindingSource.Current).Row;
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

        public override  void Cancel()
        {
            UIHelper.Cancel(riskAssessmentBindingSource);
            ApplyBR(true);
        }

        private void riskAssessmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                atriumDB.RiskAssessmentRow dr = CurrentRow();
                ApplySecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void assessmentDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
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

        private void statusCommentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox tbText = (TextBox)sender;
                switch (tbText.Name)
                {
                    case "statusCommentTextBox":
                        UIHelper.TextBoxTextCounter(sender, StatusCommentCounter, 255);
                        break;
                    case "courtNameTextBox":
                        UIHelper.TextBoxTextCounter(sender, CourtNameCounter, 255);
                        break;
                    case "contigentLiabilityCommentTextBox":
                        UIHelper.TextBoxTextCounter(sender, ContingentLiabilityCommentCounter, 255);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucLRM_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

