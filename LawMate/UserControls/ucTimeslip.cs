using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using System.IO;

namespace LawMate
{
    public partial class ucTimeslip : ucBase
    {
        List<int> LoadedSRPs = new List<int>();
        appDB tsData = new appDB();
        appDB.TimeSlipDataTable TSdt;
        appDB.SRPClientDataTable SRPClientDt;
        bool MoreThanTwoYearsSinceLastSlip = false;
        bool PromptForStartDate = false;
        bool NoTimeSlipRecordsExist = false;
        DateTime maxDate;
        const string LayoutVersionNumber = "4_0_5";


        public ucTimeslip()
        {
            InitializeComponent();

            TSdt = tsData.TimeSlip;
            SRPClientDt = tsData.SRPClient;
        }

        Stream gridLayoutStream = new MemoryStream();
        private void ucTimeslip_Load(object sender, EventArgs e)
        {
            try
            {
                RestoreExpandButtonText(FM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.TimekeepingGridExpanded, true));

                timeSlipGridEX.SaveLayoutFile(gridLayoutStream); //for resetting purposes
                lmWinHelper.LoadGridLayout(timeSlipGridEX, "TimeslipGridEx", LayoutVersionNumber);
                cmdFilter.IsChecked = FM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.cmdUcTimeslipFilter, false);

                if (PromptForStartDate)
                {
                    string promptText = "";
                    if (NoTimeSlipRecordsExist)
                        promptText = LawMate.Properties.Resources.NoTimekeepingPeriodExists;
                    else if (MoreThanTwoYearsSinceLastSlip)
                        promptText = LawMate.Properties.Resources.MoreThanTwoYearsLastTimekeepingPeriod;
                    else
                        promptText = LawMate.Properties.Resources.MoreThanOneMonthTimekeepingPeriod;

                    if (promptText.Length > 0 && maxDate != null)
                    {
                        fTimeslipStartDate fStartDate = new fTimeslipStartDate(promptText, maxDate.AddMonths(1));
                        fStartDate.ShowDialog();
                        if (fStartDate.DialogResult == DialogResult.OK)
                        {
                            DateTime StartDate = fStartDate.SelectedStartDate.AddDays(-(fStartDate.SelectedStartDate.Day - 1));
                            do
                            {
                                CreateNewTimeSlip(StartDate);
                                StartDate = StartDate.AddMonths(1);
                            }
                            while (StartDate <= atDates.StandardDate.ThisMonth.BeginDate.Date);
                        }

                    }
                    CalculateOpenPeriodTotals(FM.DB.SRP);
                }
                sRPGridEX.MoveFirst();
                if (CurrentRowSRP() != null)
                    TimeslipReadOnly(!CurrentRowSRP().IsSRPSubmittedDateNull());
                ToggleGridGroups();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void RestoreExpandButtonText(bool IsCollapsed)
        {
            if (IsCollapsed)
                btnExpandCollapseNextSteps.Text = LawMate.Properties.Resources.CollapseAll;
            else
                btnExpandCollapseNextSteps.Text = LawMate.Properties.Resources.ExpandAll;
        }

        public void BindTimeSlipData(atriumDB.SRPDataTable dt)
        {
            DataView dvSRP = new DataView(dt, "Fileid=" + FM.CurrentFile.FileId.ToString(), "", DataViewRowState.CurrentRows);
            if (dvSRP.Count == 0)
            {
                NoTimeSlipRecordsExist = true;
                PromptForStartDate = true;
                maxDate = atDates.StandardDate.LastMonth.BeginDate.Date.AddYears(-1);
            }
            else
            {
                maxDate = Convert.ToDateTime((dt.Compute("max(SRPDate)", "Fileid=" + FM.CurrentFile.FileId.ToString())));
                DateTime maxDateFirstOfMonth = maxDate.AddDays(-(maxDate.Day - 1));
                if (maxDateFirstOfMonth != atDates.StandardDate.ThisMonth.BeginDate.Date)
                {
                    //no current record - is there a gap between last month and this month?
                    if (maxDate.AddMonths(1) == atDates.StandardDate.ThisMonth.BeginDate.Date)
                    {
                        //automatically create next month's srp
                        CreateNewTimeSlip(atDates.StandardDate.ThisMonth.BeginDate.Date);
                    }
                    else
                    {
                        //need to calculate how many
                        DateTime CurrentDate = maxDate;
                        int MonthCounter = 0;
                        while (CurrentDate != atDates.StandardDate.ThisMonth.BeginDate.Date)
                        {
                            MonthCounter++;
                            DateTime NextMonth = CurrentDate.AddMonths(+1);
                            CurrentDate = NextMonth;

                            if (MonthCounter >= 24)
                            {
                                MoreThanTwoYearsSinceLastSlip = true;
                                break;
                            }
                        }
                        PromptForStartDate = true;
                    }
                }

                CalculateOpenPeriodTotals(dt);
            }

            sRPBindingSource.DataSource = dvSRP;
            sRPBindingSource.DataMember = "";
            timeSlipBindingSource.DataSource = TSdt;
            timeSlipBindingSource.DataMember = "";
            sRPClientBindingSource.DataSource = SRPClientDt;
            sRPClientBindingSource.DataMember = "";
            sRPBindingSource.Filter = "FileID=" + FM.CurrentFile.FileId;
        }

        private void ClearData()
        {
            LoadedSRPs.Clear();
            SRPClientDt.Clear();
            SRPClientDt.AcceptChanges();
            TSdt.Clear();
            TSdt.AcceptChanges();
        }

        /// <summary>
        /// clears activitytime and srpclient rows related to the srprow from the datatables and reloads/recalculates totals for srp and srpclient for unclosed period.  will return w/o executing recalculation for closed period - i.e. srpsubmitted date is not null
        /// </summary>
        /// <param name="drSRP">the srp data row that requires the recalculation</param>
        private void CalculateOpenPeriodTotals(atriumDB.SRPRow drSRP)
        {
            //update total on timekeeping period based on data on client
            DateTime endDate = drSRP.SRPDate.AddMonths(1).AddMinutes(-1);
            officeDB.OfficerRow or = FM.AtMng.OfficeMng.GetOfficer().LoadByMyFileId(FM.CurrentFile.FileId);
            try
            {
                decimal srpHours = Convert.ToDecimal(TSdt.Compute("sum(Hours)", "StartTime>= '" + drSRP.SRPDate + "' and StartTime<='" + endDate + "' and OfficerId=" + or.OfficerId + " and SRPDate is null"));
                drSRP.FeesClaimed = srpHours;
            }

            catch (Exception x)
            {
                drSRP.FeesClaimed = 0;
            }


            //remove rows from srpclient datatable
            List<appDB.SRPClientRow> clientSRPsToRemove = new List<appDB.SRPClientRow>();
            foreach (appDB.SRPClientRow drSRPClient in SRPClientDt)
            {
                if (drSRPClient.SRPId == drSRP.SRPID)
                    clientSRPsToRemove.Add(drSRPClient);
            }
            foreach (appDB.SRPClientRow listClientRow in clientSRPsToRemove)
            {
                SRPClientDt.RemoveSRPClientRow(listClientRow);
            }
            LoadedSRPs.Remove(drSRP.SRPID);

            //reload client data
            LoadSrpClient(or.OfficerId, drSRP.SRPID, drSRP.SRPDate, endDate);
        }

        /// <summary>
        /// SRP Client for open period
        /// </summary>
        /// <param name="officerId"></param>
        /// <param name="SRPId"></param>
        /// <param name="srpStart"></param>
        /// <param name="srpEnd"></param>
        private void LoadSrpClient(int officerId, int SRPId, DateTime srpStart, DateTime srpEnd) //open period
        {
            appDB.SRPClientDataTable SrpClient2Merge = new appDB.SRPClientDataTable();
            SrpClient2Merge = (appDB.SRPClientDataTable)FM.GetActivityTime().LoadSRPClientByOfficerId(SRPId, officerId, srpStart, srpEnd);
            SRPClientDt.Merge(SrpClient2Merge);
        }

        /// <summary>
        /// SRP Client for closed period
        /// </summary>
        /// <param name="SRPId"></param>
        private void LoadSrpClient(int SRPId) // closed period
        {
            appDB.SRPClientDataTable SrpClient2Merge = new appDB.SRPClientDataTable();
            SrpClient2Merge = (appDB.SRPClientDataTable)FM.GetActivityTime().LoadSRPClientBySRPID(CurrentRowSRP().SRPID);
            SRPClientDt.Merge(SrpClient2Merge);
        }

        private void CalculateOpenPeriodTotals(atriumDB.SRPDataTable dtSRP)
        {
            foreach (atriumDB.SRPRow srpRow in dtSRP.Select("Fileid=" + FM.CurrentFile.FileId.ToString()))
            {
                if (!LoadedSRPs.Contains(srpRow.SRPID) && srpRow.IsSRPSubmittedDateNull())
                {
                    appDB.TimeSlipDataTable TSdt2Merge = new appDB.TimeSlipDataTable();

                    DateTime endDate = srpRow.SRPDate.AddMonths(1).AddMinutes(-1);
                    officeDB.OfficerRow or = FM.AtMng.OfficeMng.GetOfficer().LoadByMyFileId(FM.CurrentFile.FileId);
                    if (or != null)
                    {
                        TSdt2Merge = (appDB.TimeSlipDataTable)FM.GetActivityTime().LoadByOfficerId(or.OfficerId, srpRow.SRPDate, endDate);
                        if (TSdt2Merge.Rows.Count > 0)
                        {
                            decimal srpTotalTime = Convert.ToDecimal((TSdt2Merge.Compute("sum(Hours)", String.Empty)));
                            srpRow.FeesClaimed = srpTotalTime;
                        }
                        else
                            srpRow.FeesClaimed = 0;

                        LoadedSRPs.Add(srpRow.SRPID);
                        TSdt.Merge(TSdt2Merge);
                        LoadSrpClient(or.OfficerId, srpRow.SRPID, srpRow.SRPDate, endDate);
                        tsData.TimeSlipBranch.Merge(FM.GetActivityTime().LoadBranchByOfficerId(or.OfficerId, srpRow.SRPDate, endDate));
                    }
                    else
                    {
                        MessageBox.Show(LawMate.Properties.Resources.ThePersonalFileAssociatedTimekeepingNotFound, LawMate.Properties.Resources.PersonalFileNotFound, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        private void sRPBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                if (CurrentRowSRP() == null)
                {
                    //TODO: handle unloading of grid data
                    return;
                }

                if (!LoadedSRPs.Contains(CurrentRowSRP().SRPID) && !CurrentRowSRP().IsSRPSubmittedDateNull()) //unclosed period - load by officer
                {
                    appDB.TimeSlipDataTable TSdt2Merge = new appDB.TimeSlipDataTable();

                    TSdt2Merge = (appDB.TimeSlipDataTable)FM.GetActivityTime().LoadBySRPID(CurrentRowSRP().SRPID);
                    LoadedSRPs.Add(CurrentRowSRP().SRPID);
                    TSdt.Merge(TSdt2Merge);
                    LoadSrpClient(CurrentRowSRP().SRPID);
                    tsData.TimeSlipBranch.Merge(FM.GetActivityTime().LoadBranchBySRPID(CurrentRowSRP().SRPID));
                }

                //Enabling/Disabling
                // AND FILTER ON TIMESLIP BINDING SOURCE

                sRPClientBindingSource.Filter = "SRPID=" + CurrentRowSRP().SRPID.ToString();
                TimeslipReadOnly(!CurrentRowSRP().IsSRPSubmittedDateNull());
                ToggleGridGroups();
                timeSlipGridEX.RootTable.ApplyFilter(timeSlipGridEX.RootTable.FilterApplied);

                //if (CurrentRowSRP().IsSRPSubmittedDateNull())
                //{
                //    Janus.Windows.GridEX.GridEXFormatStyle fsTSNotClosed;
                //    Janus.Windows.GridEX.GridEXFormatCondition fcNoHours;
                //    Janus.Windows.GridEX.GridEXFormatStyle fsNoHours;

                //    fsTSNotClosed = new Janus.Windows.GridEX.GridEXFormatStyle();
                //    fsTSNotClosed.ForeColor = Color.Empty;
                //    fsTSNotClosed.BackColor = Color.Empty;
                //    fcNoHours = new Janus.Windows.GridEX.GridEXFormatCondition(timeSlipGridEX.RootTable.Columns["Hours"], Janus.Windows.GridEX.ConditionOperator.Equal, 0);
                //    fsNoHours = new Janus.Windows.GridEX.GridEXFormatStyle();
                //    fsNoHours.ForeColor = Color.Red;
                //    fsNoHours.BackColor = Color.PaleGoldenrod;
                //    fcNoHours.FormatStyle = fsNoHours;


                //    timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                //    timeSlipGridEX.RootTable.Columns["Hours"].Selectable = true;
                //    timeSlipGridEX.RootTable.Columns["Comment"].Selectable = true;
                //    timeSlipGridEX.RootTable.RowFormatStyle = fsTSNotClosed;
                //    timeSlipGridEX.RootTable.FormatConditions.Add(fcNoHours);
                //    timeSlipGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;

                //    DateTime endDate = CurrentRowSRP().SRPDate.AddMonths(1).AddMinutes(-1);
                //    timeSlipBindingSource.Filter = "StartTime >= '" + CurrentRowSRP().SRPDate + "' and StartTime <='" + endDate + "'";

                //    DateTime DateOKToClose = CurrentRowSRP().SRPDate.AddMonths(1).AddDays(-1);
                //    if (DateTime.Today >= DateOKToClose)
                //        cmdCloseTimeSlip.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                //    else
                //        cmdCloseTimeSlip.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //}
                //else
                //{
                //    Janus.Windows.GridEX.GridEXFormatStyle fsTSClosed;
                //    fsTSClosed = new Janus.Windows.GridEX.GridEXFormatStyle();
                //    fsTSClosed.ForeColor = SystemColors.ControlDarkDark;
                //    fsTSClosed.BackColor = SystemColors.ControlLight;

                //    timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                //    timeSlipGridEX.RootTable.Columns["Hours"].Selectable = false;
                //    timeSlipGridEX.RootTable.Columns["Comment"].Selectable = false;
                //    timeSlipGridEX.RootTable.RowFormatStyle = fsTSClosed;
                //    timeSlipGridEX.RootTable.FormatConditions.Clear();
                //    timeSlipGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
                //    timeSlipBindingSource.Filter = "SRPID=" + CurrentRowSRP().SRPID.ToString();
                //    cmdCloseTimeSlip.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //}

                //if (btnExpandCollapseNextSteps.Text == LawMate.Properties.Resources.ExpandAll)
                //    timeSlipGridEX.CollapseGroups();
                //else
                //    timeSlipGridEX.ExpandGroups();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void ToggleGridGroups()
        {
            if (btnExpandCollapseNextSteps.Text == LawMate.Properties.Resources.CollapseAll)
                timeSlipGridEX.ExpandGroups();
            else
                timeSlipGridEX.CollapseGroups();
        }

        private void TimeslipReadOnly(bool setToReadOnly)
        {



            if (setToReadOnly)
            {
                Janus.Windows.GridEX.GridEXFormatStyle fsTSClosed;
                fsTSClosed = new Janus.Windows.GridEX.GridEXFormatStyle();
                fsTSClosed.ForeColor = SystemColors.ControlDarkDark;
                fsTSClosed.BackColor = SystemColors.ControlLight;

                timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                timeSlipGridEX.RootTable.Columns["Hours"].Selectable = false;
                timeSlipGridEX.RootTable.Columns["Comment"].Selectable = false;
                timeSlipGridEX.RootTable.RowFormatStyle = fsTSClosed;
                timeSlipGridEX.RootTable.FormatConditions.Clear();
                timeSlipGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2005;
                timeSlipBindingSource.Filter = "SRPID=" + CurrentRowSRP().SRPID.ToString();
                cmdCloseTimeSlip.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                Janus.Windows.GridEX.GridEXFormatStyle fsTSNotClosed;
                Janus.Windows.GridEX.GridEXFormatCondition fcNoHours;
                Janus.Windows.GridEX.GridEXFormatStyle fsNoHours;

                fsTSNotClosed = new Janus.Windows.GridEX.GridEXFormatStyle();
                fsTSNotClosed.ForeColor = Color.Empty;
                fsTSNotClosed.BackColor = Color.Empty;
                fcNoHours = new Janus.Windows.GridEX.GridEXFormatCondition(timeSlipGridEX.RootTable.Columns["Hours"], Janus.Windows.GridEX.ConditionOperator.Equal, 0);
                fcNoHours.TargetColumn = timeSlipGridEX.RootTable.Columns["Hours"];
                fsNoHours = new Janus.Windows.GridEX.GridEXFormatStyle();
                fsNoHours.ForeColor = Color.Black;
                fsNoHours.BackColor = Color.Moccasin;
                fcNoHours.FormatStyle = fsNoHours;

                timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                timeSlipGridEX.RootTable.Columns["Hours"].Selectable = true;
                timeSlipGridEX.RootTable.Columns["Comment"].Selectable = true;
                timeSlipGridEX.RootTable.RowFormatStyle = fsTSNotClosed;
                timeSlipGridEX.RootTable.FormatConditions.Add(fcNoHours);
                timeSlipGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;

                DateTime endDate = CurrentRowSRP().SRPDate.AddMonths(1).AddMinutes(-1);
                timeSlipBindingSource.Filter = "StartTime >= '" + CurrentRowSRP().SRPDate + "' and StartTime <='" + endDate + "'";

                DateTime DateOKToClose = CurrentRowSRP().SRPDate.AddMonths(1).AddDays(-1);
                if (DateTime.Today >= DateOKToClose)
                    cmdCloseTimeSlip.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdCloseTimeSlip.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }



        }

        private void CreateNewTimeSlip(DateTime SRPDate)
        {
            atriumDB.SRPRow newSrp = (atriumDB.SRPRow)FM.GetSRP().Add(FM.CurrentFile);
            newSrp.FileID = FM.CurrentFile.FileId;
            if (SRPDate != null)
                newSrp.SRPDate = SRPDate;
            try
            {
                atLogic.BusinessProcess bp = FM.GetBP();
                bp.AddForUpdate(FM.GetSRP());

                bp.Update();


            }
            catch (Exception x)
            {

                FM.DB.SRP.RejectChanges();
            }
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(sRPBindingSource, !makeReadOnly);
            UIHelper.EnableControls(timeSlipBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.TimekeepingData;
        }

        public override void ReloadUserControlData()
        {
            ClearData();

            FM.GetSRP().PreRefresh();
            FM.GetSRP().LoadByFileId(FM.CurrentFileId);
            CalculateOpenPeriodTotals(FM.DB.SRP);
            sRPGridEX.MoveFirst();
        }

        private atriumDB.SRPRow CurrentRowSRP()
        {
            if (sRPBindingSource.Current == null)
                return null;
            else
                return (atriumDB.SRPRow)((DataRowView)sRPBindingSource.Current).Row;
        }

        private appDB.TimeSlipRow CurrentRowACTimeSlip()
        {
            if (timeSlipBindingSource.Current == null)
                return null;
            else
                return (appDB.TimeSlipRow)((DataRowView)timeSlipBindingSource.Current).Row;
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            sRPBindingSource.Position = sRPBindingSource.Find("SRPID", linkId);
        }

        private string SplitFullPathForEllipsisDisplay(string fullpath)
        {
            string tmpString = "";
            string[] filenames = fullpath.Split('\\');
            int i = 0;
            foreach (string fn in filenames)
            {
                if (i > 0)
                {
                    i++;
                    if (filenames.Length == i)
                        break;
                    if (fn.Length > 12)
                        tmpString += fn.Substring(0, 9) + ".../";
                    else
                        tmpString += fn + "/";
                }
                else
                    i++;
            }
            return tmpString;

        }


        private void timeSlipGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record || e.Row.RowType == Janus.Windows.GridEX.RowType.GroupHeader || e.Row.RowType == Janus.Windows.GridEX.RowType.TotalRow)
                {
                  //  if (e.Row.Cells["Hours"].Value != null && e.Row.Cells["Hours"].Text != "")
                  //      e.Row.Cells["Hours"].Text = UIHelper.FormatMinutes(decimal.ToInt32((decimal)e.Row.Cells["Hours"].Value));

                    e.Row.Cells["Filename"].ToolTipText = e.Row.Cells["FullPath"].Text;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void JumpToFile()
        {
            ((fFile)ParentForm).MainForm.OpenFile(CurrentRowACTimeSlip().FileId);
        }

        private void JumpToActivity()
        {
            fFile f = ((fFile)ParentForm).MainForm.OpenFile(CurrentRowACTimeSlip().FileId);
            f.MoreInfo("activity", CurrentRowACTimeSlip().ActivityId);
        }

        private void DisplayTimeConvertor()
        {
            fTimeConvertor ftc = new fTimeConvertor(CurrentRowACTimeSlip().Hours);
            ftc.ShowDialog();
            if (ftc.DialogResult == DialogResult.OK)
            {
                CurrentRowACTimeSlip().Hours = (decimal)ftc.totalminutes / (decimal)60;// ftc.totalminutes;
                timeSlipGridEX.Refetch();
            }
        }

        private void DisplayTimeConvertor(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            fTimeConvertor ftc = new fTimeConvertor(CurrentRowACTimeSlip().Hours);
            ftc.ShowDialog();
            if (ftc.DialogResult == DialogResult.OK)
            {
                CurrentRowACTimeSlip().Hours = (decimal)ftc.totalminutes / (decimal)60;// ftc.totalminutes;
                timeSlipGridEX.Refetch();
                timeSlipGridEX_CellUpdated(sender, e);
            }
        }

        private void timeSlipGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (CurrentRowACTimeSlip() == null)
                    return;

                if (e.Column.Key == "Filename")
                    JumpToFile();

                if (e.Column.Key == "StepCode")
                    JumpToActivity();

                if (e.Column.Key == "Hours")
                    DisplayTimeConvertor(sender, e);

                if (e.Column.Key == "Delete")
                    DeleteTimeSlip(CurrentRowACTimeSlip());


            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void DeleteTimeSlip(appDB.TimeSlipRow actr)
        {
            if (UIHelper.ConfirmDelete())
            {
                atriumBE.FileManager FMActivityTime = FM.AtMng.GetFile(actr.FileId);
                FMActivityTime.GetActivity().Load(actr.ActivityId);
                atriumDB.ActivityTimeRow atr = FMActivityTime.GetActivityTime().Load(actr.ActivityTimeId);
                Application.UseWaitCursor = true;
                atr.Delete();
                actr.Delete();
                try
                {
                    atLogic.BusinessProcess bp = FMActivityTime.GetBP();
                    bp.AddForUpdate(FMActivityTime.GetActivityTime());

                    bp.Update();

                    if (CurrentRowSRP().IsSRPSubmittedDateNull())
                        CalculateOpenPeriodTotals(CurrentRowSRP());

                }
                catch (Exception x1)
                {

                    FMActivityTime.DB.ActivityTime.RejectChanges();
                    throw x1;
                }
                finally
                {
                    Application.UseWaitCursor = false;
                }
            }
        }

        private void timeSlipGridEX_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                int fileid = CurrentRowACTimeSlip().FileId;
                if (e.Column.Key == "Hours" || e.Column.Key == "Comment")
                {
                    timeSlipGridEX.UpdateData();
                    Application.UseWaitCursor = true;
                    //get FM, load activitytime record and update hours/comment
                    atriumBE.FileManager FMActivityTime = FM.AtMng.GetFile(fileid);
                    FMActivityTime.GetActivity().Load(CurrentRowACTimeSlip().ActivityId);
                    atriumDB.ActivityTimeRow atr = FMActivityTime.GetActivityTime().Load(CurrentRowACTimeSlip().ActivityTimeId);
                    if (CurrentRowACTimeSlip().IsHoursNull())
                        CurrentRowACTimeSlip().Hours = 0;
                    atr.Hours = CurrentRowACTimeSlip().Hours;
                    atr.Comment = CurrentRowACTimeSlip().Comment;

                    timeSlipBindingSource.EndEdit();
                    try
                    {
                        atLogic.BusinessProcess bp = FM.GetBP();
                        bp.AddForUpdate(FMActivityTime.GetActivityTime());

                        bp.Update();

                        CalculateOpenPeriodTotals(CurrentRowSRP());
                    }
                    catch (Exception x1)
                    {

                        FMActivityTime.DB.ActivityTime.RejectChanges();
                        throw x1;
                    }
                    Application.UseWaitCursor = false;

                }
            }
            catch (Exception x)
            {

                Application.UseWaitCursor = false;
                UIHelper.HandleUIException(x);
            }
        }

        List<int> FileIDsInSRP = new List<int>();
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {

                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars[1];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "cmdSetLayout":
                        lmWinHelper.LoadGridLayout(timeSlipGridEX, "TimeslipGridExUser", LayoutVersionNumber);
                        sRPGridEX.MoveFirst();
                        TimeslipReadOnly(!CurrentRowSRP().IsSRPSubmittedDateNull());
                        ToggleGridGroups();
                        if (timeSlipGridEX.FilterMode == Janus.Windows.GridEX.FilterMode.None)
                            cmdFilter.IsChecked = false;
                        else
                            cmdFilter.IsChecked = true;
                        break;
                    case "cmdResetGridToAppLayout":
                        if (gridLayoutStream != null)
                        {
                            gridLayoutStream.Position = 0;
                            ClearData();
                            BindTimeSlipData(FM.DB.SRP);
                            timeSlipGridEX.LoadLayoutFile(gridLayoutStream);
                            UIHelper.ComboBoxInit("vOfficerList", timeSlipGridEX.DropDowns["ddOfficer"], FM);
                            cmdFilter.IsChecked = false;
                            timeSlipGridEX.Refetch();
                            sRPGridEX.MoveFirst();
                            TimeslipReadOnly(!CurrentRowSRP().IsSRPSubmittedDateNull());
                            ToggleGridGroups();
                        }
                        break;
                    case "cmdStoreLayout":
                        lmWinHelper.UpdateLayout(timeSlipGridEX);
                        lmWinHelper.SaveGridLayout(timeSlipGridEX, "TimeslipGridExUser", FM.AtMng, LayoutVersionNumber);
                        break;
                    case "cmdCloseTimeSlip":
                        if (MessageBox.Show(LawMate.Properties.Resources.AreYouSureYouWantToCloseTimekeeping, LawMate.Properties.Resources.TimekeepingPeriodClosure, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            int selectedSRPid = CurrentRowSRP().SRPID;
                            FM.GetSRP().CloseActivityTimePeriod(CurrentRowSRP().SRPID);
                            foreach (appDB.TimeSlipRow tsdr in TSdt.Select("SRPID is null and StartTime >= '" + CurrentRowSRP().SRPDate + "' and StartTime <= '" + CurrentRowSRP().SRPDate.AddMonths(1).AddMinutes(-1) + "'", "FileId"))
                            {
                                if (!FileIDsInSRP.Contains(tsdr.FileId))
                                    FileIDsInSRP.Add(tsdr.FileId);
                            }
                            ((fFile)ParentForm).MainForm.PostSubmitTimekeepingReloadActivityTime(FileIDsInSRP);
                            ReloadUserControlData();
                            ((fFile)ParentForm).GetUcCtlToc("timeslip", "SRP", selectedSRPid);
                            //sRPBindingSource.Position = sRPBindingSource.Find("SRPID", selectedSRPid);
                        }
                        break;
                    case "cmdFilter":
                        if (e.Command.IsChecked)
                            timeSlipGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
                        else
                            timeSlipGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.None;
                        break;
                    case "cmdFieldChooser":
                        timeSlipGridEX.ShowFieldChooser(this.ParentForm, LawMate.Properties.Resources.FieldSelector);
                        break;
                    case "cmdRefresh":
                        //int currentSRP = CurrentRowSRP().SRPID;
                        ReloadUserControlData();
                        //((fFile)ParentForm).GetUcCtlToc("timeslip", "SRP", currentSRP);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void timeSlipGridEX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (timeSlipGridEX.CurrentRow != null && timeSlipGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    if (e.Shift && e.Control && e.KeyCode == Keys.F) // jump to file
                        JumpToFile();
                    if (e.Shift && e.Control && e.KeyCode == Keys.A) // jump to activity
                        JumpToActivity();
                    if (e.Shift && e.Control && e.KeyCode == Keys.T) // load time convertor form
                        DisplayTimeConvertor();
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void timeSlipGridEX_GroupsChanged(object sender, Janus.Windows.GridEX.GroupsChangedEventArgs e)
        {
            try
            {
                ToggleGridGroups();
                foreach (Janus.Windows.GridEX.GridEXGroup geg in e.Table.Groups)
                {

                    if (geg.Column != null && geg.Column.Key == "StartTime")
                    {
                        geg.GroupFormatString = "D";
                        return;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void sRPGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
                {
                    DataRowView dv = (DataRowView)e.Row.DataRow;
                    string fees = dv["FeesClaimed"].ToString();
                    if (fees != null & fees != "")
                    {
                        e.Row.Cells["TotalTime"].Text = Convert.ToDecimal(fees).ToString();// UIHelper.FormatMinutes(Convert.ToInt32(Convert.ToDecimal(fees)));
                    }
                    else
                        e.Row.Cells["TotalTime"].Text = "0";// UIHelper.FormatMinutes(0);

                }
                //if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record && (decimal)e.Row.Cells["FeesClaimed"].Text.Length > 0)
                //    e.Row.Cells["TotalTime"].Text = UIHelper.FormatMinutes(decimal.ToInt32((decimal)e.Row.Cells["FeesClaimed"].Value));
                else
                    e.Row.Cells["TotalTime"].Text = UIHelper.FormatMinutes(0);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void sRPClientGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record && (decimal)e.Row.Cells["Minutes"].Text.Length > 0)
                    e.Row.Cells["TotalTime"].Text = Convert.ToDecimal(e.Row.Cells["Minutes"].Value).ToString( "#.0#");// UIHelper.FormatMinutes(decimal.ToInt32((decimal)e.Row.Cells["Minutes"].Value));
                else
                    e.Row.Cells["TotalTime"].Text = "0";// UIHelper.FormatMinutes(0);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnExpandCollapseNextSteps_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnExpandCollapseNextSteps.Text == LawMate.Properties.Resources.ExpandAll)
                {
                    timeSlipGridEX.ExpandGroups();
                    btnExpandCollapseNextSteps.Text = LawMate.Properties.Resources.CollapseAll;
                    btnExpandCollapseNextSteps.Image = LawMate.Properties.Resources.CollapseAllSteps2;
                }
                else
                {
                    timeSlipGridEX.CollapseGroups();
                    btnExpandCollapseNextSteps.Text = LawMate.Properties.Resources.ExpandAll;
                    btnExpandCollapseNextSteps.Image = LawMate.Properties.Resources.ExpandAllSteps2;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void timeSlipGridEX_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(timeSlipGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override void SaveLayout()
        {
            lmWinHelper.SaveGridLayout(timeSlipGridEX, "TimeslipGridEx", FM.AtMng, LayoutVersionNumber);

            if (btnExpandCollapseNextSteps.Text == LawMate.Properties.Resources.ExpandAll)
                FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.TimekeepingGridExpanded, false);
            else
                FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.TimekeepingGridExpanded, true);

            FM.AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.cmdUcTimeslipFilter, cmdFilter.IsChecked);

        }

        private void timeSlipBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                appDB.TimeSlipRow bfr = CurrentRowACTimeSlip();
                if (bfr != null)
                    ApplyTimeslipSecurity(bfr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ApplyTimeslipSecurity(appDB.TimeSlipRow atr)
        {
            try
            {
                atriumBE.FileManager FMActivityTime = FM.AtMng.GetFile(atr.FileId);
                FMActivityTime.GetActivity().Load(atr.ActivityId);
                atriumDB.ActivityTimeRow actr = FMActivityTime.GetActivityTime().Load(atr.ActivityTimeId);

                bool canDelete = FMActivityTime.GetActivityTime().CanDelete(actr);

                if (canDelete)
                    timeSlipGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.Image;
                else
                    timeSlipGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;

                if (FMActivityTime.GetActivityTime().CanEdit(actr))
                {
                    timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                }
                else
                {
                    timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                }
            }
            catch (Exception x)
            {
                timeSlipGridEX.RootTable.Columns["Delete"].ButtonStyle = Janus.Windows.GridEX.ButtonStyle.NoButton;
                timeSlipGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            }
        }

        private void timeSlipGridEX_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                JumpToActivity();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }



    }
}


