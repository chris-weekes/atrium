using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using System.Linq;
using atriumBE;

namespace LawMate
{
    public partial class ucCalendar : ucBase
    {

        private bool isOfficerCal = false;
        private int myOfficerId;

        public int OfficerId
        {
            get { return myOfficerId; }
            set { myOfficerId = value; }
        }

        public bool IsOfficerCal
        {
            get { return isOfficerCal; }
            set
            {
                isOfficerCal = value;
                if (isOfficerCal)
                {
                    schedule1.AddNewMode = Janus.Windows.Schedule.AddNewMode.Manual;
                    cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    cmdRefreshCal.Visible = Janus.Windows.UI.InheritableBoolean.True;
                    cmdRefreshCal1.Visible = Janus.Windows.UI.InheritableBoolean.True;
                }
                else
                {
                    cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    cmdRefreshCal.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    cmdRefreshCal1.Visible = Janus.Windows.UI.InheritableBoolean.False;
                }
            }
        }

        public ucCalendar()
        {
            InitializeComponent();
            schedule1.Date = DateTime.Today;
        }

        public void SoonestAppointment()
        {
            atriumDB.AppointmentRow[] apptrs = (atriumDB.AppointmentRow[])FM.DB.Appointment.Select("ShowAsBusy = 1 and StartDateLocal>='" + DateTime.Today.ToString("yyyy/MM/dd") + "'", "StartDateLocal");
            if (apptrs.Length > 0)
            {
                AppointmentBindingSource.Position = AppointmentBindingSource.Find("ApptId", apptrs[0].ApptId);
            }
            else
            {
                AppointmentBindingSource.MoveLast();
            }

        }

        public void BindData(lmDatasets.atriumDB.AppointmentDataTable dt)
        {
            //JLL: 2013-09-26 Translation for 2013/10 build
            lblTZ.Text = UIHelper.GetTimeZoneLabel(); // TimeZoneInfo.Local.StandardName;

            DataView dv = new DataView(dt, "ShowAsBusy = 1", "StartDate", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);
            AppointmentBindingSource.DataSource = dv;

            //display the last appointment - this is not having the desired effect CJW 2015-5-13
            SoonestAppointment();
            if(IsOfficerCal)
            {
                //make sure the current month is displayed
                schedule1.EnsureVisible(DateTime.Today.AddDays(- DateTime.Today.Day+1));
            }
        //  SetNotificationTimer();
            //AddRecurrenceSymbol();

            dt.ColumnChanged += new DataColumnChangeEventHandler(dt_ColumnChanged);
            FM.GetAppointment().OnUpdate += new atLogic.UpdateEventHandler(ucAppointment_OnUpdate);
            LoadAttendeeContacts();

            CreateAddNewAppointMenu();
            calMonthDisplay.Text = schedule1.Date.ToString("MMMM yyyy");
            //if (dt.Rows.Count == 0)
            //{
            //create add menu now
            //if (FM.IsVirtualFM)
            //{
            //    FileTreeView.BuildMenu(FM.AtMng.GetFile(FM.AtMng.WorkingAsOfficer.MyFileId), cmdHearing, FileTreeView.dmApptNew);
            //}
            //else
            //{
            //    FileTreeView.BuildMenu(FM, cmdHearing, FileTreeView.dmApptNew);
            //}
            //}
        }
 
         

        private void CreateAddNewAppointMenu()
        {
            // NOTE: do NOT use CurrentRow() property in this method
            if (FM.IsVirtualFM)
            {
                FileTreeView.BuildMenu(FM.AtMng.GetFile(FM.AtMng.WorkingAsOfficer.MyFileId), cmdHearing, FileTreeView.dmApptNew);
            }
            else
            {
                FileTreeView.BuildMenu(FM, cmdHearing, FileTreeView.dmApptNew);
            }
        }

        private void AddRecurrenceSymbol()
        {
            foreach (Janus.Windows.Schedule.ScheduleAppointment apptScheduled in schedule1.Appointments)
            {
                DataRowView drv = (DataRowView)apptScheduled.DataRow;
                atriumDB.AppointmentRow apptRow = (atriumDB.AppointmentRow)drv.Row;

                if (!apptRow.IsApptRecurrenceIdNull())
                {
                    apptScheduled.ImageIndex1 = 3;
                }
            }
        }
        
        DataTable contactDT;

        private void InitContactTable()
        {
            if (contactDT == null)
            {
                contactDT = new DataTable();
                contactDT.Columns.Add("contactId", typeof(int));
                contactDT.Columns.Add("contactName", typeof(string));
            }
        }

        private void LoadAttendeeContacts(int contactID)
        {

            InitContactTable();

            DataRow[] crow = (DataRow[])contactDT.Select("contactId=" + contactID);
            
            if (crow.Length == 0)
            {
                atriumDB.ContactRow cr = FM.GetPerson().Load(contactID);
                contactDT.Rows.Add(cr.ContactId, cr.DisplayName);
            }

            contactDT.AcceptChanges();

            DataView contactDV = new DataView(contactDT);
            attendeeGridEX.DropDowns["ddContact"].SetDataBinding(contactDV, "");
        }

        private void LoadAttendeeContacts()
        {

            InitContactTable();

            foreach (atriumDB.AttendeeRow attrow in FM.DB.Attendee.Rows)
            {
                var fcx = from fc in FM.DB.FileContact
                          where fc.ContactId == attrow.ContactId
                          select fc;

                if (fcx.Count() == 1)
                {
                    atriumDB.FileContactRow fcr = fcx.Single();
                    DataRow[] crow = (DataRow[])contactDT.Select("contactId=" + fcr.ContactId);
                    if (crow.Length < 1)
                        contactDT.Rows.Add(fcr.ContactId, fcr.DisplayName);
                }
                else
                {
                    DataRow[] crow = (DataRow[])contactDT.Select("contactId=" + attrow.ContactId);
                    atriumDB.ContactRow cr = null;
                    if (crow.Length == 0)
                    {
                        cr = FM.GetPerson().Load(attrow.ContactId);
                        contactDT.Rows.Add(cr.ContactId, cr.DisplayName);
                    }
                }
            }
            contactDT.AcceptChanges();

            DataView contactDV = new DataView(contactDT);
            attendeeGridEX.DropDowns["ddContact"].SetDataBinding(contactDV, "");
        }

        void ucAppointment_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void dt_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Column.ColumnName != "EndDateLocal" && e.Column.ColumnName != "StartDateLocal")
                {
                    if (FM.IsFieldChanged(e.Column, e.Row))
                        ApplyBR(false);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override string ucDisplayName()
        {
            return Properties.Resources.CalendarDisplayName;
        }

        public override void ReloadUserControlData()
        {
            int apptId = 0;
            if (CurrentRow() != null)
                apptId = CurrentRow().ApptId;

            AppointmentBindingSource.SuspendBinding();


            if (IsOfficerCal)
            {
                //must be calendar screen
                FM.GetAppointment().LoadByContactId(OfficerId);
            }
            //else
            //{
            //    FM.GetAppointment().LoadByContactId(FM.AtMng.WorkingAsOfficer.OfficerId);
            //}
            LoadAttendeeContacts();
            //AddRecurrenceSymbol();
            AppointmentBindingSource.ResumeBinding();
            schedule1.Refetch();

            if (IsOfficerCal)
            {
                if (apptId == 0)
                    SoonestAppointment();
                else
                {
                    int pos = AppointmentBindingSource.Find("ApptId", apptId);
                    if (pos != -1)
                        AppointmentBindingSource.Position = pos;
                    else
                        SoonestAppointment();
                }
            }
            else
            {
                SoonestAppointment();
            }
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ApplySecurity(DataRow dr)
        {
            atriumDB.AppointmentRow cbr = (atriumDB.AppointmentRow)dr;
            UIHelper.EnableControls(AppointmentBindingSource, FM.GetAppointment().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetAppointment().CanDelete(cbr));
            if (ApptIsHearing())
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            tentativeUICheckBox.Enabled = false;
            vacationUICheckBox.Enabled = false;
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
            UIHelper.EnableControls(AppointmentBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            uiCommandBar2.Enabled = !makeReadOnly;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());
        }

        public override void MoreInfo(string linkTable, int linkId)
        {
            AppointmentBindingSource.Position = AppointmentBindingSource.Find("ApptId", linkId);
        }

        private void Save(atriumBE.FileManager contextFM)
        {
            //atriumBE.FileManager contextFM = FM.AtMng.GetFile(CurrentRow().FileId);

            if (contextFM.DB.Appointment.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(contextFM.DB);
            }
            else
            {
                try
                {
                    this.AppointmentBindingSource.EndEdit();

                    contextFM.SaveAll();
                    ApplyBR(true);

                    if (!isOfficerCal)
                    {
                        fFile f = (fFile)this.ParentForm;
                        f.fileToc.LoadTOC();
                    }
                }
                catch (Exception x)
                {
                    throw x;
                }
            }
            CreateAddNewAppointMenu();
        }

        public override void Delete()
        {
            if (schedule1.CurrentAppointment != null)
            {
                atriumBE.FileManager contextFM = FM.AtMng.GetFile(CurrentRow().FileId);
                DataRow[] drAppt = contextFM.DB.Appointment.Select("ApptId=" + CurrentRow().ApptId.ToString());

                atriumDB.AppointmentRow apptRow; //= (atriumDB.AppointmentRow)drAppt[0];

                if (drAppt.Length > 0)
                {
                    apptRow = (atriumDB.AppointmentRow)drAppt[0];
                }
                else
                {
                    apptRow = contextFM.GetAppointment().Load(CurrentRow().ApptId);
                }

                if (apptRow.IsApptRecurrenceIdNull())
                {
                    if (UIHelper.ConfirmDelete())
                    {
                        atriumDB.AttendeeRow[] atrs = (atriumDB.AttendeeRow[])contextFM.DB.Attendee.Select("ApptID=" + apptRow.ApptId.ToString());
                        foreach (atriumDB.AttendeeRow atr in atrs)
                        {
                            atr.Delete();
                        }
                        apptRow.Delete();
                        Save(contextFM);
                        UpdateReminders();
                       
                    }
                }
                else
                {
                    if (UIHelper.ConfirmDelete(Properties.Resources.UIDeleteAllRecurringAppointments + " " + Properties.Resources.UIConfirmDelete, "Deleting Multiple Appointments")) //Properties.Resources.ConfirmDeleteAppRecurrence))
                    {
                        if (apptRow.ApptRecurrenceRow == null)
                        {
                            DataRow[] drRecurr = contextFM.DB.ApptRecurrence.Select("ApptRecurrenceId=" + apptRow.ApptRecurrenceId.ToString());
                            if (drRecurr.Length > 0)
                            {
                                apptRow.ApptRecurrenceRow = (atriumDB.ApptRecurrenceRow)drRecurr[0];
                            }
                            else
                            {
                                apptRow.ApptRecurrenceRow = contextFM.GetApptRecurrence().Load(apptRow.ApptRecurrenceId);
                            }
                        }
                        atriumDB.AppointmentRow[] appdt = apptRow.ApptRecurrenceRow.GetAppointmentRows();
                        atriumDB.ApptRecurrenceRow apptrecRow = apptRow.ApptRecurrenceRow;
                        foreach (atriumDB.AppointmentRow ar in appdt)
                        {
                            atriumDB.AttendeeRow[] attRows = ar.GetAttendeeRows();
                            foreach (atriumDB.AttendeeRow attRow in attRows)
                            {
                                attRow.Delete();
                            }
                            ar.Delete();
                        }
                        apptrecRow.Delete();
                        Save(contextFM);
                        UpdateReminders();
                    }
                }
                //AddRecurrenceSymbol();
            }
        }
        private void UpdateReminders()
        {
            if (FM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.EnableReminders, true))
            {
                if (isOfficerCal)
                {

                    fCalendar fcal = (fCalendar)this.ParentForm;
                    fcal.EnableReminders();
                }
            }
           
        }
        private atriumDB.AppointmentRow CurrentRow()
        {
            if (AppointmentBindingSource.Current == null)
                return null;
            else
                return (atriumDB.AppointmentRow)((DataRowView)AppointmentBindingSource.Current).Row;
        }

        public override void Cancel()
        {
            UIHelper.Cancel(AppointmentBindingSource);
            ApplyBR(true);
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdRefreshCal":
                        ReloadUserControlData();
                        break;
                    case "cmdJumpToFile":
                        JumpToFile();
                        break;
                    case "tsSave":
                        //Save();
                        break;
                    case "tsDelete":
                        Delete();
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                    case "cmdOneDay":
                        schedule1.View = Janus.Windows.Schedule.ScheduleView.DayView;
                        break;
                    case "cmdWorkWeek":
                        schedule1.View = Janus.Windows.Schedule.ScheduleView.WorkWeek;
                        break;
                    case "cmdWeek":
                        schedule1.View = Janus.Windows.Schedule.ScheduleView.WeekView;
                        break;
                    case "cmdMonth":
                        schedule1.View = Janus.Windows.Schedule.ScheduleView.MonthView;
                        calMonthDisplay.Text = schedule1.Date.ToString("MMMM yyyy");
                        break;
                    case "cmdGoToToday":
                        schedule1.Date = DateTime.Today;
                        schedule1.View = Janus.Windows.Schedule.ScheduleView.DayView;
                        break;
                    case "cmdGoToNextSevenDays":
                        schedule1.View = Janus.Windows.Schedule.ScheduleView.WeekView;
                        schedule1.Date = DateTime.Today;
                        break;
                }

                if (e.Command.Key.StartsWith("tsACMenu"))
                {
                    ActivityConfig.ACSeriesRow acsr = (ActivityConfig.ACSeriesRow)e.Command.Tag;
                    int apptId;
                    if (acsr.ACSeriesId == FM.AtMng.GetSetting(AppIntSetting.NewApptAcId))
                    {
                        AddNewAppointment(acsr.ACSeriesId);
                        apptId = FM.DB.Appointment[FM.DB.Appointment.Count - 1].ApptId;
                    }
                    else
                    {
                        apptId = CurrentRow().ApptId;
                        EditReschedule(acsr.ACSeriesId);

                    }
                    if (IsOfficerCal)
                    {
                        ReloadUserControlData();

                        //find just added or updated appt
                        AppointmentBindingSource.Position = AppointmentBindingSource.Find("ApptId", apptId);
                    }
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AddNewAppointment(int NawACSeriesId)
        {
            try
            {
                fACWizard facwr;
                //Launch AcWizard Constructor to Add Appointment
                if (!IsOfficerCal)
                {
                    this.FileForm().ReadOnly = true;
                    facwr = new fACWizard(FM, ACEngine.Step.ACInfo, NawACSeriesId);
                    this.FileForm().HookupWizClose(facwr);
                    facwr.Show();
                   
                }
                else
                {
                    atriumBE.FileManager fmCurrent = FM.AtMng.GetFile(FM.AtMng.WorkingAsOfficer.MyFileId);
                    facwr = new fACWizard(fmCurrent, ACEngine.Step.ACInfo, NawACSeriesId);
                    facwr.ShowDialog();
                    facwr.Close();
                }
               
            }
            catch (Exception x)
            {
                if (this.FileForm() != null)
                {
                    this.FileForm().ReadOnly = false;
                }
                UIHelper.HandleUIException(x);
            }
        }

        private void EditReschedule(int NawACSeriesId)
        {
            try
            {
                //check to see if appt has a hearing
                if (CurrentRow() != null)
                {
                    atriumBE.FileManager contextFM = FM.AtMng.GetFile(CurrentRow().FileId);

                    atriumDB.FileContactRow FCR = contextFM.GetFileContact().GetByRole("FTM");
                    bool isTM = false;

                    if (FCR != null)
                        isTM = (FCR.ContactId == FM.AtMng.WorkingAsOfficer.ContactId);

                    if (ApptIsHearing() && isTM)
                    {
                        UIHelper.CannotEditAppointment();
                    }
                    else
                    {
                        //Create Step to handle editing Appointment

                        fACWizard facwr;
                        //Launch AcWizard Constructor to Edit Appointment
                        if (!IsOfficerCal)
                        {
                            this.FileForm().ReadOnly = true;
                            GetOriginalRecurrenceAppointment(FM);
                            facwr = new fACWizard(FM, NawACSeriesId, CurrentRow().ApptId);
                            this.FileForm().HookupWizClose(facwr);
                            facwr.Show();
                          
                        }
                        else
                        {
                            atriumBE.FileManager fmCurrent = FM.AtMng.GetFile(CurrentRow().FileId);
                            GetOriginalRecurrenceAppointment(fmCurrent);
                            facwr = new fACWizard(fmCurrent, NawACSeriesId, CurrentRow().ApptId);
                            facwr.ShowDialog();
                            facwr.Close();
                        }
                      
                    }
                }
                else
                {
                    AddNewAppointment(NawACSeriesId);
                }
            }
            catch (Exception x)
            {
                if (this.FileForm() != null)
                {
                    this.FileForm().ReadOnly = false;
                }
                UIHelper.HandleUIException(x);
            }
        }

        private void GetOriginalRecurrenceAppointment(FileManager fm)
        {
            atriumDB.AppointmentRow apptr = (atriumDB.AppointmentRow)((DataRowView)AppointmentBindingSource.Current).Row;
            if (!apptr.IsApptRecurrenceIdNull())
            {
                DataRow[] drs = fm.DB.Appointment.Select("ApptRecurrenceId=" + apptr.ApptRecurrenceId.ToString() + " AND OriginalRecurrence='True'");
                if (drs.Length > 0)
                {
                    atriumDB.AppointmentRow origRecurrApptRow = (atriumDB.AppointmentRow)drs[0];
                    AppointmentBindingSource.Position = AppointmentBindingSource.Find("ApptId", origRecurrApptRow.ApptId);
                }
            }
        }

        private void JumpToFile()
        {
            if (this.ParentForm.GetType() == typeof(fCalendar) && IsOfficerCal && CurrentRow() != null)
            {
                fCalendar fcal = (fCalendar)this.ParentForm;
                fFile f = fcal.MainForm.OpenFile(CurrentRow().FileId);
                f.MoreInfo("appointment", CurrentRow().ApptId);
            }
        }



        private void AppointmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {

                if (CurrentRow() == null)
                    return;

                if (CurrentRow().IsNull("ApptId"))
                    return;

                if (!CurrentRow().IsStartDateLocalNull())
                    schedule1.EnsureVisible(CurrentRow().StartDateLocal);

                if (ApptIsHearing())
                {
                    FileTreeView.BuildMenu(FM.AtMng.GetFile(CurrentRow().FileId), cmdHearing, FileTreeView.dmHearing);
                }
                else
                {
                    if (CurrentRow() != null)
                        FileTreeView.BuildMenu(FM.AtMng.GetFile(CurrentRow().FileId), cmdHearing, FileTreeView.dmAppt);
                    else
                        CreateAddNewAppointMenu();
                }

                DataView dv = new DataView(FM.DB.Attendee, "ApptId = " + CurrentRow().ApptId + "", "", DataViewRowState.ModifiedCurrent | DataViewRowState.Unchanged);
                attendeeBindingSource.DataSource = dv;

                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ToggleApptPnlContents(bool Hide)
        {
            lblTZ.Visible = !Hide;
            startDateLabel.Visible = !Hide;
            endDateLabel.Visible = !Hide;
            subjectLabel.Visible = !Hide;
            startDateCalendarCombo.Visible = !Hide;
            endDateCalendarCombo.Visible = !Hide;
            subjectEditBox.Visible = !Hide;
            attendeeGridEX.Visible = !Hide;
            tentativeUICheckBox.Visible = !Hide;
            vacationUICheckBox.Visible = !Hide;
            if (Hide)
            {
                cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }

        private void schedule1_SelectedAppointmentsChanged(object sender, EventArgs e)
        {
            try
            {
                if (schedule1.CurrentAppointment != null)
                {
                    int id = (int)schedule1.CurrentAppointment.GetValue("ApptId");

                    AppointmentBindingSource.Position = AppointmentBindingSource.Find("ApptId", id);
                    //   FileTreeView.BuildMenu(FM.AtMng.GetFile(CurrentRow().FileId), cmdHearing, FileTreeView.dmAppt);
                    if (ApptIsHearing())
                    {
                        FileTreeView.BuildMenu(FM.AtMng.GetFile(CurrentRow().FileId), cmdHearing, FileTreeView.dmHearing);
                    }
                    else
                    {
                        if (CurrentRow() != null)
                            FileTreeView.BuildMenu(FM.AtMng.GetFile(CurrentRow().FileId), cmdHearing, FileTreeView.dmAppt);
                        else
                            CreateAddNewAppointMenu();
                    }
                    ToggleApptPnlContents(false);
                }
                else
                {
                    if (CurrentRow() != null)
                        FileTreeView.BuildMenu(FM.AtMng.GetFile(CurrentRow().FileId), cmdHearing, FileTreeView.dmApptNew);
                    else
                        CreateAddNewAppointMenu();
                    ToggleApptPnlContents(true);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void attendeeGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.Cells["Accepted"].Value != null && (bool)e.Row.Cells["Accepted"].Value == true)
                {
                    e.Row.Cells["AttendeeStatus"].Value = Properties.Resources.apptAccepted;
                }
                if (e.Row.Cells["Tentative"].Value != null && (bool)e.Row.Cells["Tentative"].Value == true)
                {
                    e.Row.Cells["AttendeeStatus"].Value = Properties.Resources.apptTentative;
                }
                if (e.Row.Cells["Declined"].Value != null && (bool)e.Row.Cells["Declined"].Value == true)
                {
                    e.Row.Cells["AttendeeStatus"].Value = Properties.Resources.apptDeclined;
                }
                if (e.Row.Cells["ContactId"].Value != null)
                {
                    int contactID = 0;
                    if (int.TryParse(e.Row.Cells["ContactId"].Value.ToString(), out contactID))
                    {
                        LoadAttendeeContacts(contactID);
                    }
                }
            }
            catch (Exception x)
            {
                //  UIHelper.HandleUIException(x);
            }
        }

        private bool ApptIsHearing()
        {
            if (CurrentRow() == null)
                return false;

            atriumBE.FileManager contextFM = FM.AtMng.GetFile(CurrentRow().FileId);

            DataRow[] drs = contextFM.GetSSTMng().DB.Hearing.Select("ApptId=" + CurrentRow().ApptId.ToString());
            if (drs.Length > 0)
                return true;

            return false;
        }

        private void schedule1_AppointmentDoubleClick(object sender, Janus.Windows.Schedule.AppointmentEventArgs e)
        {
            JumpToFile();
        }

        private void schedule1_AppointmentRead(object sender, Janus.Windows.Schedule.AppointmentEventArgs e)
        {
            DataRowView drv = (DataRowView)e.Appointment.DataRow;
            atriumDB.AppointmentRow apptRow = (atriumDB.AppointmentRow)drv.Row;

            if (!apptRow.IsApptRecurrenceIdNull())
            {
                e.Appointment.ImageIndex1 = 3;
            }
        }

        private void Calendar_CurrentDateChanged(object sender, EventArgs e)
        {
            calMonthDisplay.Text = schedule1.Date.ToString("MMMM yyyy");
        }

        private void Schedule_DateChanged(object sender, EventArgs e)
        {
            ScheduleEvent(sender, e);
        }

        private void schedule1_Scroll(object sender, EventArgs e)
        {
            ScheduleEvent(sender, e);
        }
        private void ScheduleEvent(object sender, EventArgs e)
        {
            Janus.Windows.Schedule.DateRange dr = schedule1.DateRange;
            Janus.Windows.Schedule.DateCollection dc = schedule1.Dates;
            string dStart = dr.Start.ToString("yyyy");//MMMM yyyy
            string dEnd = dr.End.ToString("yyyy");
            string monthStart = dr.Start.ToString("MMMM");//MMMM yyyy
            string monthEnd = dr.End.ToString("MMMM");


            string dResult;
            if (dStart == dEnd)
            {
                if (monthStart == monthEnd)
                {
                    dResult = dr.Start.ToString("MMMM yyyy");
                }
                else
                {
                    dResult = dr.Start.ToString("MMMM") + " - " + dr.End.ToString("MMMM yyyy");
                }
            }
            else
            {
                dResult = dr.Start.ToString("MMMM yyyy") + " - " + dr.End.ToString("MMMM yyyy");
            }



            calMonthDisplay.Text = dResult;

        }



            

    }
}