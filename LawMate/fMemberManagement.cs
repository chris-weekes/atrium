using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;
using Janus.Windows.GridEX;

namespace LawMate
{
	public partial class fMemberManagement : fBase
	{

        MemberManager myMemMng;
        atriumManager myAtMng;
        FileManager FM;
      
        MemberManagement.MemberListAssignmentFilterDataTable mListAssignmentFilter;
        
        int maxDistance;

        const string LayoutVersionNumber = "4_0_14";
        System.IO.Stream gridLayoutStream = new System.IO.MemoryStream();

        public fMemberManagement()
		{
			InitializeComponent();
		}

        public fMemberManagement(Form f, atriumBE.atriumManager atMng)
            : base(f)
        {
            InitializeComponent();

            try
            {
                myAtMng = atMng;
                myMemMng = myAtMng.GetMemberMng();
                myMemMng.LoadTribunalMemberAssignment();
                myMemMng.LoadFileFlagVC();

                tribunalMemberWorkloadBindingSource.DataSource = myMemMng.LoadTribunalMemberWorkload();
                tribunalMemberAssignmentBindingSource.DataSource = myMemMng.DB.TribunalMemberAssignment;
                updateTribunalMemberAssignmentCounter();
                mListAssignmentFilter = myMemMng.LoadMemberListAssignmentFilter();

                maxDistance = Convert.ToInt32(maxDistanceEditBox.Text);
                
                FM = myAtMng.GetFile();
                atLogic.WhereClause wc = new atLogic.WhereClause();
                wc.Add("FlagCode", "<>", "ABEY");
                UIHelper.ComboBoxInit(FM.Codes("vFlagCode", wc, true), FlagCodeMultiDropDown, FM);

                InitCombos();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void InitCombos()
        {
            UIHelper.ComboBoxInit("vmemberlist", grexTribunalMemberWorkload.DropDowns["ddMemberList"], FM);
            UIHelper.ComboBoxInit("vMemberListAssignmentFilter", grexAppealsReadyForAssignment.DropDowns["ddMemberList"], FM);
            UIHelper.ComboBoxInit("vMemberListAssignmentFilter", grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"], FM);
            UIHelper.ComboBoxInit("vmemberlist", grexAppealsReadyForAssignment.DropDowns["ddPreviousMemberList"], FM);
            UIHelper.ComboBoxInit("vmemberlist", grexAppealsReadyForAssignment.DropDowns["ddRemovedMemberList"], FM);
            UIHelper.ComboBoxInit("DecisionType", grexAppealsReadyForAssignment.DropDowns["ddDecisionType"], FM);
            UIHelper.ComboBoxInit("CrisisType", grexAppealsReadyForAssignment.DropDowns["ddCrisisType"], FM);
            UIHelper.ComboBoxInit("AccountType", grexAppealsReadyForAssignment.DropDowns["ddProgramBenefit"], FM);
            UIHelper.ComboBoxInit("LanguageCode", grexAppealsReadyForAssignment.DropDowns["ddLanguage"], FM);
            UIHelper.ComboBoxInit("vOfficeSCList", grexAppealsReadyForAssignment.DropDowns["ddOfficeSCList"], FM);
        }

        public MemberManagement.TribunalMemberAssignmentRow CurrentRow()
        {
            if (tribunalMemberAssignmentBindingSource.Current == null)
                return null;
            else
                return (MemberManagement.TribunalMemberAssignmentRow)((DataRowView)tribunalMemberAssignmentBindingSource.Current).Row;
        }

        private void gbAppealsReadyForAssignment_Resize(object sender, EventArgs e)
        {
            try
            {
                grexAppealsReadyForAssignment.Width = gbAppealsReadyForAssignment.Width - 25;
                grexAppealsReadyForAssignment.Height = gbAppealsReadyForAssignment.Height - 100;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
   
        private void grexTribunalMemberWorkload_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {

                if (e.Row.DataRow != null)
                {
                    e.Row.Cells["uiVacationUpcoming"].Text = Properties.Resources.UINo; // set default

                    if (e.Row.Cells["VacationUpcoming"].Value != null)
                    {
                        int upcomingVacation;

                        try
                        {
                            if (((System.Data.DataRowView)e.Row.DataRow).Row.IsNull("VacationUpcoming"))
                                upcomingVacation = 0;
                            else
                                upcomingVacation = (int)e.Row.Cells["VacationUpcoming"].Value;
                        }
                        catch (Exception x)
                        {
                            upcomingVacation = 0;
                        }
                        
                        if (upcomingVacation > 0)
                            e.Row.Cells["uiVacationUpcoming"].Text = Properties.Resources.UIYes;
                    }
                }

                UIHelper.FormatDateGridEXColumn("TermExpiryDate", e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void grexAppealsReadyForAssignment_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                //int last = grexAppealsReadyForAssignment.LastVisibleRow(false);
                //if (e.Row.Position < grexAppealsReadyForAssignment.FirstRow || e.Row.Position > last + 1)
                //    return;

//                CalcSC(e);
                //e.Row.Cells["uiIsCharter"].Text = Properties.Resources.UINA;
                //if ((bool)e.Row.Cells["IsCharter"].Value)
                //{
                //    e.Row.Cells["uiIsCharter"].Text = Properties.Resources.UIYes;
                //}
                UIHelper.FormatDateGridEXColumn("OpenedDate", e);
                UIHelper.FormatDateGridEXColumn("RecDate", e);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void grexAppealsReadyForAssignment_DropDown(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "FilteredMemberId")
                    ApplyTribunalMemberFilter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
	
        private void ApplyTribunalMemberFilter()
        {
            // code to apply filter criteria to memmebrs list
            if (CurrentRow() != null)
            {

                grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].ApplyFilter(null); // clear filter

                GridEXFilterCondition filtTribunalMember = new GridEXFilterCondition();

                if (this.chkLanguage.Checked) // add language filter
                {
                    if (CurrentRow().FileLanguageCode == "F")
                    {
                        filtTribunalMember.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["CanHearFre"],
                                                                           ConditionOperator.Equal, true));
                    }
                    else if (CurrentRow().FileLanguageCode == "E")
                    {
                        filtTribunalMember.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["CanHearEng"],
                                                   ConditionOperator.Equal, true));
                    }
                    else
                    {
                        filtTribunalMember.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["CanHearFre"],
                                                                           ConditionOperator.Equal, true));
                        filtTribunalMember.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["CanHearEng"],
                                                   ConditionOperator.Equal, true));
                    }
                }

                if (this.chkTraining.Checked) // add training filter
                {
                    // charter condition
                    if (CurrentRow().IsCharter)
                    {
                        filtTribunalMember.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["TrainedCharter"],
                                                                               ConditionOperator.Equal, true));
                    }

                    // program & benefit condition
                    if (!CurrentRow().IsAccountIdNull())
                    {
                        atLogic.ObjectBE obe = myAtMng.GetCodeTableBE("AccountType");
                        if (obe.myDT.Rows.Count == 0)
                            obe.Load();
                        CodesDB.AccountTypeDataTable atdt = (CodesDB.AccountTypeDataTable)obe.myDT;
                        CodesDB.AccountTypeRow atr = atdt.FindByAccountTypeId(CurrentRow().AccountId);

                        string trainedByProgramColumn = "";

                        switch (atr.ProgramID)
                        {
                            case 3: // EI
                                trainedByProgramColumn = "TrainedEI";
                                break;
                            case 8: // CPP
                                trainedByProgramColumn = "TrainedCPP";
                                break;
                            case 9: // OAS
                                trainedByProgramColumn = "TrainedOAS";
                                break;
                        }

                        if (trainedByProgramColumn != "")
                        {
                            filtTribunalMember.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns[trainedByProgramColumn],
                                                          ConditionOperator.Equal, true));
                        }
                    }
                }

                if (this.chkLocation.Checked) // add location filter
                {
                    var memberId = new List<int>();

                    if (!CurrentRow().IsOfficeIdNull())
                    {

                        int selectedSCOfficeId = CurrentRow().OfficeId;

                        // get service centre latitude and longitude
                        lmDatasets.MemberManagement.OfficeSCListRow scr = myMemMng.DB.OfficeSCList.FindByOfficeId(selectedSCOfficeId);// myAtMng.OfficeMng.GetServiceCentre().Load(selectedSCOfficeId);
                        
                        if (!scr.IsLatitudeNull() && !scr.IsLongitudeNull())
                        {
                            
                            // get member postal code
                            double distance;

                            maxDistance = (int)maxDistanceEditBox.Value;

                            foreach (MemberManagement.MemberListAssignmentFilterRow  mlafr in mListAssignmentFilter)
                            {
                                if (!mlafr.IsLatitudeNull())
                                {
                                    distance = myAtMng.GetPostalCodeLocation().CalculateDistance((double)mlafr.Latitude,(double)mlafr.Longitude, (double)scr.Latitude, (double)scr.Longitude);
                                    if (distance >= 0 && distance <= maxDistance)
                                    {
                                        memberId.Add(mlafr.OfficerId);
                                    }
                                }
                            }
                        }
                    }

                    if (memberId.Count == 0)
                    {
                        memberId.Add(-1);
                    }

                    GridEXFilterCondition filtLocation = new GridEXFilterCondition();
                    foreach (int memID in memberId)
                    {
                        if (filtLocation.Conditions.Count == 0)
                        {
                            filtLocation.AddCondition(new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["OfficerId"], ConditionOperator.Equal, memID));
                        }
                        else
                        {
                            filtLocation.AddCondition(LogicalOperator.Or, new GridEXFilterCondition(grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].Columns["OfficerId"], ConditionOperator.Equal, memID));
                        }
                    }
                    filtTribunalMember.AddCondition(filtLocation);
                }

                // apply filter only if conditions exist
                if (filtTribunalMember.Conditions.Count > 0)
                {
                    grexAppealsReadyForAssignment.DropDowns["ddMemberListAssignmentFilter"].ApplyFilter(filtTribunalMember);
                }
             }
        }

        private void btnAssignAppeals_Click(object sender, EventArgs e)
        {
            try
            {
                List<DataRow> rowList = UIHelper.GridGetSelectedData(grexAppealsReadyForAssignment);
                if (rowList.Count > 0)
                {
                    Application.UseWaitCursor = true; Cursor = Cursors.WaitCursor;
                    using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                    {
                        myMemMng.CreateBatchRecord(rowList);
                    }
                    grexAppealsReadyForAssignment.UpdateData();
                    this.tribunalMemberAssignmentBindingSource.EndEdit();
                    myMemMng.LoadTribunalMemberAssignment();
                    updateTribunalMemberAssignmentCounter();
                    tribunalMemberWorkloadBindingSource.DataSource = myMemMng.LoadTribunalMemberWorkload();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                Application.UseWaitCursor = false; Cursor = Cursors.Default;
            }
        }

        private void btnSaveTentativeMembers_Click(object sender, EventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    SaveTentativeMember();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                Application.UseWaitCursor = false; Cursor = Cursors.Default;
            }
        }

        private void SaveTentativeMember()
        {
            grexAppealsReadyForAssignment.UpdateData();
            this.tribunalMemberAssignmentBindingSource.EndEdit();
            atLogic.BusinessProcess bp= myAtMng.GetBP();
            bp.AddForUpdate(myMemMng.GetTribunalMemberAssignment());
            bp.Update();
        }

        private void fMemberManagement_Load(object sender, EventArgs e)
        {
            grexAppealsReadyForAssignment.SaveLayoutFile(gridLayoutStream); //for resetting purposes

            lmWinHelper.LoadGridLayout(grexAppealsReadyForAssignment, "VCGridLayout", LayoutVersionNumber);
            grexAppealsReadyForAssignment.SelectionMode = Janus.Windows.GridEX.SelectionMode.SingleSelection;
            grexAppealsReadyForAssignment.RootTable.Columns[0].Visible = true;
            grexAppealsReadyForAssignment.UseGroupRowSelector = true;

            InitCombos();
            grexAppealsReadyForAssignment.Refetch();
            grexAppealsReadyForAssignment.Focus();
            grexAppealsReadyForAssignment.MoveFirst();

            grexAppealsReadyForAssignment.RootTable.RemoveFilter();
        }

        private void fMemberManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            lmWinHelper.SaveGridLayout(grexAppealsReadyForAssignment, "VCGridLayout", this.AtMng, LayoutVersionNumber);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                myMemMng.LoadTribunalMemberAssignment();
                myMemMng.LoadFileFlagVC();
                tribunalMemberWorkloadBindingSource.DataSource = myMemMng.LoadTribunalMemberWorkload();
                updateTribunalMemberAssignmentCounter();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void updateTribunalMemberAssignmentCounter()
        {
            lblCount.Text = myMemMng.DB.TribunalMemberAssignment.Rows.Count.ToString();
        }

        private void grexAppealsReadyForAssignment_LinkClicked(object sender, ColumnActionEventArgs e)
        {
            try
            {
                using (fWait fProgress = new fWait(LawMate.Properties.Resources.waitLoading))
                {
                    this.MainForm.OpenFile(CurrentRow().FileId);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkUseSpecialCase_CheckedChanged(object sender, EventArgs e)
        {
            FlagCodeMultiDropDown.Enabled = chkUseSpecialCase.Checked;
            btnApplySpecialCaseFilter.Enabled = chkUseSpecialCase.Checked;
            if (!chkUseSpecialCase.Checked)
            {
                grexAppealsReadyForAssignment.RootTable.RemoveFilter();
            }
        }

        private void btnApplySpecialCaseFilter_Click(object sender, EventArgs e)
        {
            grexAppealsReadyForAssignment.RootTable.RemoveFilter();
            if (FlagCodeMultiDropDown.Text.Trim() != string.Empty)
            {
                GridEXFilterCondition filtSpecialCase = new GridEXFilterCondition(grexAppealsReadyForAssignment.RootTable.Columns["SpecialCase"], ConditionOperator.Contains, FlagCodeMultiDropDown.Text.Trim());
                grexAppealsReadyForAssignment.RootTable.ApplyFilter(filtSpecialCase);
            }
        }
    }
}