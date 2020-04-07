using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using System.Linq;

 namespace LawMate
{
    public partial class ucSSTCase : ucBase
    {
        atriumBE.SSTManager SSTM;

        public ucSSTCase()
        {
            InitializeComponent();
        }

        public void bindData(lmDatasets.SST.SSTCaseDataTable dt)
        {
            SSTM = FM.GetSSTMng();
       
            
            //ucSSTCaseMatterIssues.DataSource = SSTM.DB.SSTCaseMatter;
            ucSSTCaseMatterIssues.FM = FM;
            setBindingSources();
          

            atLogic.WhereClause wc=new atLogic.WhereClause();
            
            if(!SSTM.DB.SSTCase[0].IsDecisionTypeNull())
                wc.Add("DecisionType","=",SSTM.DB.SSTCase[0].DecisionType);
            else
                wc.Add("DecisionType", "=", 1);

            DataTable dtOutcome = FM.Codes("vOutcome", wc,true);
            UIHelper.ComboBoxInit(dtOutcome, OutcomeMultiDropDown, FM);
            UIHelper.ComboBoxInit("Program", ProgramMultiDropDown, FM);
            UIHelper.ComboBoxInit("LeaveToAppealType", LeaveToAppealDecisionMultiDropDown, FM);
            UIHelper.ComboBoxInit("CrisisType", CrisisTypeMultiDropDown, FM);
            UIHelper.ComboBoxInit("vAppealLevel", LevelMultiDropDown, FM);
            UIHelper.ComboBoxInit("vCaseStatus", CaseStatusMultiDropDown, FM);
            UIHelper.ComboBoxInit("HearingMethod", HearingGridEX.DropDowns["ddHearingMethod"], FM);
            UIHelper.ComboBoxInit("HearingStatus", HearingGridEX.DropDowns["ddStatusHearing"], FM);
            UIHelper.ComboBoxInit("vBenefitList", BenefitMultiDropDown, FM);
            //UIHelper.ComboBoxInit("vLateIgnoreReason", ignoreReasonucMultiDropDown, FM);

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            SSTM.DB.SSTCaseMatter.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);

            SSTM.DB.SSTCaseMatter.RowDeleted += new DataRowChangeEventHandler(dt_RowDeleted);

            SSTM.GetSSTCase().OnUpdate += new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);
            SSTM.GetSSTCaseMatter().OnUpdate += new atLogic.UpdateEventHandler(ucSSTCase_OnUpdate);

            if(FM.CurrentFile.FileType == "RP" || FM.CurrentFile.FileType == "RE")
                     ckbADReturnToGD.Visible = true;
            else
                     ckbADReturnToGD.Visible = false;
            
            
        }

        private void setBindingSources()
        {
            SSTCaseBindingSource.DataSource = SSTM.DB.SSTCase;
            SSTCaseBindingSource.DataMember = "";// SSTM.DB.SSTCase.TableName;
            ucSSTCaseMatterIssues.DataSource = SSTM.DB.SSTCaseMatter;

            HearingBindingSource.DataSource = SSTM.DB.Hearing;
            HearingBindingSource.DataMember = "";// SSTM.DB.Hearing.TableName;

            IssuesGroupBox.Visible = SSTM.DB.SSTCaseMatter.Count > 0;
            gbNoIssues.Visible = (SSTM.DB.SSTCaseMatter.Count == 0);
        }

        void ucSSTCase_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);

            if (e.SavedOK && SSTM.DB.SSTCaseMatter.Count > 0)
            {
                IssuesGroupBox.Visible = SSTM.DB.SSTCaseMatter.Count > 0;
                gbNoIssues.Visible = (SSTM.DB.SSTCaseMatter.Count == 0);
            }
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName == "Received365Date")
                    return;
                if (e.Column.ColumnName == "IsLate365")
                    return;
                if (FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void dt_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            ApplyBR(false);
        }

        public override string ucDisplayName()
        {
            return Properties.Resources.DisplayNameSSTAppeal;
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
            SSTCaseBindingSource.EndEdit();
        }

        public override void ApplySecurity(DataRow dr)
        {
            SST.SSTCaseRow cbr = (SST.SSTCaseRow)dr;
            UIHelper.EnableControls(SSTCaseBindingSource, SSTM.GetSSTCase().CanEdit(cbr));
            ucSSTCaseMatterIssues.ApplySecurity(dr);
            UIHelper.EnableCommandBarCommand(tsDelete, SSTM.GetSSTCase().CanDelete(cbr));

            //Keep these fields disabled at all times, regardless of CanEdit call above
            MoreThan365DaysUICheckBox.Enabled = false;
            AppealFiledLateUICheckBox.Enabled = false;
            LevelMultiDropDown.Enabled = false;
            ProgramMultiDropDown.Enabled = false;
            CharterUICheckBox.Enabled = false;
            MultipleAppealssUICheckBox.Enabled = false;
            LateAcceptedUICheckBox.Enabled = false;
            FileCompleteUICheckBox.Enabled = false;

            // WI: 83086
            OverrideUserEditBox.Enabled = false;
            OverrideDateCalendarCombo.Enabled = false;

            if (SSTM.AtMng.SecurityManager.CanExecute(FM.CurrentFileId, atSecurity.SecurityManager.Features.LateOverride) == atSecurity.SecurityManager.ExPermissions.Yes)
                LateOverrideUICheckBox.Enabled = cbr.IsLate;
            else
                LateOverrideUICheckBox.Enabled = false;
            
            //====

            if (cbr.ProgramId != 2) //is not IS, then disable sstcase/benefit
                BenefitMultiDropDown.Enabled = false;
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
            UIHelper.EnableControls(SSTCaseBindingSource, !makeReadOnly); 
            ucSSTCaseMatterIssues.ReadOnly(makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            SSTCaseBindingSource.Position = SSTCaseBindingSource.Find("SSTCaseId", linkId);
        }

        public override void Save()
        {
            if (SSTM.DB.SSTCase.HasErrors || SSTM.DB.SSTCaseMatter.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(SSTM.DB);
            }
            else if(FM.DB.FileXRef.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.SSTCaseBindingSource.EndEdit();
                    this.ucSSTCaseMatterIssues.sSTCaseMatterBindingSource.EndEdit();

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
                if (UIHelper.ConfirmDelete())
                {
                    throw new Exception("Delete functionality not implemented on SST Appeal screen. / La fonction supprimer n'est pas accessible pour cet écran.");
                    //CurrentRow().Delete();
                    //atriumDB_SSTDemoDataTableBindingSource.EndEdit();
                    //FM.GetSSTDemo().Update();
                    //FM.EFile.Update();
                    //FM.AtMng.AppMan.Commit();
                    //ApplyBR(true);
                    //fFile f = (fFile)this.ParentForm;
                    //f.fileToc.LoadTOC();
                }
            }
            catch (Exception x)
            {
               throw x;
            }
        }

        private SST.SSTCaseRow CurrentRow()
        {
            if (SSTCaseBindingSource.Current == null)
                return null;
            else
                return (SST.SSTCaseRow)((DataRowView)SSTCaseBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(SSTCaseBindingSource);
            UIHelper.Cancel(ucSSTCaseMatterIssues.sSTCaseMatterBindingSource);
            SSTM.DB.SSTCaseMatter.RejectChanges();
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

        private void SSTCaseBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() == null)
                    return;
                
                if (CurrentRow().IsNull("SSTCaseId"))
                    return;

                ApplySecurity(CurrentRow());
                
                IssuesGroupBox.Visible = SSTM.DB.SSTCaseMatter.Count>0;
                gbNoIssues.Visible = (SSTM.DB.SSTCaseMatter.Count == 0);
                
               

                //there is no flip side to the IF. currentchanged should fire only once, when screen loads.
                //layout currently set to display as if Leave To Appeal should display.
                if (CurrentRow().AppealLevelID == 2) //Appeal Division File; Update Labels
                {
                    LTANotRequiredUICheckBox.Visible = true;
                    //LTANotRequiredCheck(CurrentRow().LeaveToAppealNotRequired);
                    LTANotRequiredCheck(true);  //never show as data is now on decision screen
                    ReconsiderationDecisionDateLabel.Text = Properties.Resources.sstCasePreviousDecisionDate;
                    ReconsiderationIdLabel.Text = Properties.Resources.sstCaseAppealRecordId;
                }
                else if (CurrentRow().AppealLevelID == 1) //General Division File
                {
                    LTANotRequiredUICheckBox.Visible = false;
                    LTANotRequiredCheck(true);
                }
                
                //Hide Benefit at SSTCase level if not EI
                BenefitLabel.Visible = (CurrentRow().ProgramId != 3);
                BenefitMultiDropDown.Visible = (CurrentRow().ProgramId != 3);

                FileLateCalc();
                FileCompleteCalc();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void FileLateCalc()
        {
            if (!CurrentRow().LateOverride || !LateOverrideUICheckBox.Checked) // WI: 83086
            {
                string fileLate;
                if (CurrentRow().IsLate)
                    fileLate = Properties.Resources.AppealLate;
                else
                    fileLate = Properties.Resources.AppealNotLate;
                UIHelper.ToggleGroupBoxWarning(LateFilingGroupBox, fileLate, CurrentRow().IsLate);
            }
        }

        private void FileCompleteCalc()
        {
            string fileComplete;
            if (CurrentRow().FileComplete)
                fileComplete = Properties.Resources.AppealComplete;
            else
                fileComplete = Properties.Resources.AppealIncomplete;
            UIHelper.ToggleGroupBoxWarning(AppealCompleteGroupBox, fileComplete, !CurrentRow().FileComplete);
        }

        private void LTANotRequiredCheck(bool NotRequired)
        {
            if (this.Visible) //this line prevents redraw when refreshing from other ucControls.
            {
                if (NotRequired)
                {
                    if (ApplicationLeaveToAppealGroupBox.Visible)
                    {
                        ApplicationLeaveToAppealGroupBox.Visible = false;
                        SSTDecisionGroupBox.Location = new Point(SSTDecisionGroupBox.Location.X, SSTDecisionGroupBox.Location.Y - (ApplicationLeaveToAppealGroupBox.Height + 6));
                        IssuesGroupBox.Location = new Point(IssuesGroupBox.Location.X, IssuesGroupBox.Location.Y - (ApplicationLeaveToAppealGroupBox.Height + 6));
                        gbNoIssues.Location = new Point(gbNoIssues.Location.X, gbNoIssues.Location.Y - (ApplicationLeaveToAppealGroupBox.Height + 6));
                        HearingGroupBox.Location = new Point(HearingGroupBox.Location.X, HearingGroupBox.Location.Y - (ApplicationLeaveToAppealGroupBox.Height + 6));
                        LateFilingGroupBox.Location = new Point(LateFilingGroupBox.Location.X, LateFilingGroupBox.Location.Y - (ApplicationLeaveToAppealGroupBox.Height + 6));
                        AppealCompleteGroupBox.Location = new Point(AppealCompleteGroupBox.Location.X, AppealCompleteGroupBox.Location.Y - (ApplicationLeaveToAppealGroupBox.Height + 6));
                    }
                }
                else
                {
                    if (!ApplicationLeaveToAppealGroupBox.Visible)
                    {
                        ApplicationLeaveToAppealGroupBox.Visible = true;
                        SSTDecisionGroupBox.Location = new Point(SSTDecisionGroupBox.Location.X, SSTDecisionGroupBox.Location.Y + (ApplicationLeaveToAppealGroupBox.Height + 6));
                        IssuesGroupBox.Location = new Point(IssuesGroupBox.Location.X, IssuesGroupBox.Location.Y + (ApplicationLeaveToAppealGroupBox.Height + 6));
                        gbNoIssues.Location = new Point(gbNoIssues.Location.X, gbNoIssues.Location.Y + (ApplicationLeaveToAppealGroupBox.Height + 6));
                        HearingGroupBox.Location = new Point(HearingGroupBox.Location.X, HearingGroupBox.Location.Y + (ApplicationLeaveToAppealGroupBox.Height + 6));
                        LateFilingGroupBox.Location = new Point(LateFilingGroupBox.Location.X, LateFilingGroupBox.Location.Y + (ApplicationLeaveToAppealGroupBox.Height + 6));
                        AppealCompleteGroupBox.Location = new Point(AppealCompleteGroupBox.Location.X, AppealCompleteGroupBox.Location.Y + (ApplicationLeaveToAppealGroupBox.Height + 6));
                    }
                }
            }
        }	

        private void HearingGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                string timeZone = UIHelper.GetAcronymTimeZoneLabel();
             
                SST.HearingRow hearingRow = (SST.HearingRow)((DataRowView) e.Row.DataRow).Row;
                if (!hearingRow.IsNull("ApptId"))
                {
                    var fcx = from fc in FM.DB.Appointment
                              where fc.ApptId == hearingRow.ApptId
                              select fc;

                    atriumDB.AppointmentRow apptRow;
                    
                    if (fcx.Count() == 1)
                        apptRow = fcx.Single();
                    else
                        apptRow = FM.GetAppointment().Load(hearingRow.ApptId);

                    if (FM.AppMan.Language.ToUpper() == "ENG")
                        e.Row.Cells["StartDate"].Value = apptRow.StartDateLocal.ToString("MMMM dd, yyyy @ hh:mm tt", System.Globalization.CultureInfo.CreateSpecificCulture("en-CA")) + " " + timeZone;
                    else
                        e.Row.Cells["StartDate"].Value = apptRow.StartDateLocal.ToString("dd MMMM yyyy à HH:mm", System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA")) + " " + timeZone;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AppealFiledLateUICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                FileLateCalc();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void FileCompleteUICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FileCompleteCalc();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void LateOverrideUICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FileLateOverrideCalc();
            }
            catch(Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        // WI: 83086
        private void FileLateOverrideCalc()
        {
            if (LateOverrideUICheckBox.Checked)
            {
                //string fileLateOverride = LateOverrideUICheckBox.Text.Replace(":", "").Trim();
                //UIHelper.ToggleGroupBoxWarning(LateFilingGroupBox, LateOverrideUICheckBox.Text.Replace(":", "").Trim(), !LateOverrideUICheckBox.Checked);
                OverrideDateCalendarCombo.BindableValue = DateTime.Now;
                OverrideUserEditBox.Text = SSTM.AtMng.OfficerLoggedOn.OfficerCode;
            }
            else
            {
                OverrideDateCalendarCombo.BindableValue = null;
                OverrideUserEditBox.Text = string.Empty;
                //FileLateCalc();
            }
        }
    }
}