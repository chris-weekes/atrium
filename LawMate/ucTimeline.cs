using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.TimeLine;
using lmDatasets;

namespace LawMate
{
    public partial class ucTimeline : UserControl
    {
        atriumBE.FileManager myFM;

        DateTime RangeStartDate;
        DateTime RangeEndDate;
        atriumDB.AppointmentRow apptRow;

        public ucTimeline()
        {
            InitializeComponent();

        }

        public object Datasource
        {
            get { return appointmentBindingSource.DataSource; }
            set
            {
                if (myFM == null)
                    return;

                appointmentBindingSource.DataSource = value;
                if (appointmentBindingSource.Current != null)
                    apptRow = (atriumDB.AppointmentRow)((DataRowView)appointmentBindingSource.Current).Row;

               
                // check if hearing
                atriumBE.FileManager contextFM = myFM.AtMng.GetFile(apptRow.FileId);

                DataRow[] drs = contextFM.GetSSTMng().DB.Hearing.Select("ApptId=" + apptRow.ApptId.ToString());
                if (drs.Length > 0)
                {
                    RecurrenceUIButton.Visible = false;
                }
                else
                {
                    ToggleRecurrenceButton();
                    //UIHelper.ToggleUIButton(RecurrenceUIButton, !apptRow.IsApptRecurrenceIdNull());
                }

                // load appointment data for all attendees
                TimeLineField ContactField = this.timeLine1.Fields["ContactId"];
                ContactField.HasValueList = true;
                myFM.DB.TimeLine.Clear();

                InitReminder(); 

                foreach (atriumDB.AttendeeRow atr in apptRow.GetAttendeeRows())
                {
                    AddAttendeeToTimeline(ContactField, atr);
                }
                timeLine1.DataSource = myFM.DB.TimeLine;
                timeLine1.ToolTipMember = "Tooltip" + myFM.AtMng.AppMan.Language;

                timeLine1.SelectedRange = new DateRange(apptRow.StartDateLocal, apptRow.EndDateLocal);
                timeLine1.EnsureVisible(timeLine1.SelectedRange.Start);
                setConflictImage(false);
                if (myFM.AppMan.Language.ToUpper() == "ENG")
                {
                    timeLine1.BottomTier.CustomFormat = "hh:mm tt";
                    calendarCombo1.CustomFormat = "hh:mm tt";
                    calendarCombo2.CustomFormat = "hh:mm tt";
                }
                else
                {
                    timeLine1.BottomTier.CustomFormat = "HH:mm";
                    calendarCombo1.CustomFormat = "HH:mm";
                    calendarCombo2.CustomFormat = "HH:mm";
                }
            }
        }

        private void AddAttendeeToTimeline(TimeLineField ContactField, atriumDB.AttendeeRow atr)
        {
            var fcx = from fc in myFM.DB.FileContact
                      where fc.ContactId == atr.ContactId
                      select fc;

            if (fcx.Count() == 1)
            {
                atriumDB.FileContactRow fcr = fcx.Single();
                ContactField.ValueList.Add(new TimeLineValueListItem(atr.ContactId, fcr.DisplayName, 0));
            }
            else
            {
                atriumDB.ContactRow cr = myFM.GetPerson().Load(atr.ContactId);
                ContactField.ValueList.Add(new TimeLineValueListItem(atr.ContactId, cr.DisplayName, 0));
                //TODO find contact
            }

            myFM.GetAppointment().LoadByContactIdDates(atr.ContactId, RangeStartDate, RangeEndDate);

            AddDummyAppointmentForFileContacts(atr);
        }

        private void AddDummyAppointmentForFileContacts(atriumDB.AttendeeRow fcr)
        {

            //TODO only add if contactid not in timeline table
            var tx = from t in myFM.DB.TimeLine
                     where t.ContactId == fcr.ContactId
                     select t;

            if (tx.Count() == 0)
            {
                atriumDB.TimeLineRow appr = myFM.DB.TimeLine.NewTimeLineRow();
                appr.ContactId = fcr.ContactId;
                appr.StartDate = DateTime.Today.AddYears(-1);
                appr.EndDate = DateTime.Today.AddYears(-1);
                appr.StartDateLocal = DateTime.Today.AddYears(-1);
                appr.EndDateLocal = DateTime.Today.AddYears(-1);
                myFM.DB.TimeLine.AddTimeLineRow(appr);
            }
        }

        public void Init(atriumBE.FileManager fm, DateTime rangeStartDate, DateTime rangeEndDate)
        {
             

            if (myFM == null)
            {
                myFM = fm;

                TimeLineGroup group = new TimeLineGroup(this.timeLine1.Fields["ContactId"]);
                timeLine1.Groups.Add(group);
            }

            UIHelper.ComboBoxInit("AppointmentNotification", ReminderDropDown, myFM);

            
            //JLL 2013-09-27 Translation for 2013/10 Build
            lblTZ.Text = UIHelper.GetTimeZoneLabel();// TimeZoneInfo.Local.StandardName;
            RangeStartDate = rangeStartDate;
            RangeEndDate = rangeEndDate;

            timeLine1.FirstDate = DateTime.Now.AddHours(-2);
            timeLine1.MinDate = DateTime.Today;
             
        }
        private void InitReminder()
        {
            try
            {
                officeDB.OfficerRow workingas = myFM.AtMng.WorkingAsOfficer;
                int OfficerId = workingas.OfficerId;
                atriumDB.AttendeeRow[] attws = (atriumDB.AttendeeRow[])myFM.DB.Attendee.Select("ApptId = " + apptRow.ApptId.ToString() + " AND ContactId =" + OfficerId.ToString());
                int len = attws.Length;
                if (len > 0)
                {
                    atriumDB.AttendeeRow attw = attws[0];
                    if (!attw.IsIntervalNull())
                        apptRow.Interval = attw.Interval;
                }
             }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdAddAttendee":
                        AddAttendee();
                        break;
                    case "cmdAddResource":
                        AddResource();
                        break;
                    case "cmdRemoveAttendee":
                        RemoveAttendee();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void AddAttendee()
        {
            fContactSelect f = new fContactSelect(myFM, null, true);
            f.ShowDialog();

            if (f.ContactId != 0)
            {
                //if contact is allready an attendee ignore
                if (myFM.DB.Attendee.Select("ApptId=" + apptRow.ApptId.ToString() + " and ContactId=" + f.ContactId.ToString()).Length == 0)
                {
                    atriumDB.AttendeeRow attRow = (atriumDB.AttendeeRow)myFM.GetAttendee().Add(apptRow);
                    attRow.ContactId = f.ContactId;
                    AddAttendeeToTimeline(this.timeLine1.Fields["ContactId"], attRow);
                }
            }
            f.Close();
        }

        private void AddEditRecurrence()
        {
            fApptRecurrence f = new fApptRecurrence(myFM, apptRow);
            f.ShowDialog();
            f.Close();
            ToggleRecurrenceButton();
        }

        private void ToggleRecurrenceButton()
        {
            if (!apptRow.IsApptRecurrenceIdNull())
            {
                UIHelper.ToggleUIButton(RecurrenceUIButton, !apptRow.ApptRecurrenceRow.RecurrenceRemoved);
                startDateCalendarCombo.Enabled = apptRow.ApptRecurrenceRow.RecurrenceRemoved;
                endDateCalendarCombo.Enabled = apptRow.ApptRecurrenceRow.RecurrenceRemoved;
            }
            else
            {
                UIHelper.ToggleUIButton(RecurrenceUIButton, !apptRow.IsApptRecurrenceIdNull());
                startDateCalendarCombo.Enabled = apptRow.IsApptRecurrenceIdNull();
                endDateCalendarCombo.Enabled = apptRow.IsApptRecurrenceIdNull();
            }
            subjectEditBox.Focus();
        }

        private void AddResource()
        {
            MessageBox.Show(Properties.Resources.UINotImplemented);
            AddAttendee();
        }

        private void RemoveAttendee()
        {
            int contactId = (int)cmdRemoveAttendee.Tag;
            //delete attendee with contactId
            //TFS#54976 JLL: added ApptId in select clause, otherwise query returned one attendee row per appt.
            atriumDB.AttendeeRow[] attendeeRow = (atriumDB.AttendeeRow[])myFM.DB.Attendee.Select("ContactId=" + contactId + " and ApptId="+ apptRow.ApptId);
            if (attendeeRow.Length == 1)
            {
                attendeeRow[0].Delete();

                atriumDB.TimeLineRow[] tlr = (atriumDB.TimeLineRow[])myFM.DB.TimeLine.Select("ContactId=" + contactId.ToString());

                //TFS#54976                
                //JLL: doesn't matter how many timeline rows are in the array, the attendee is deleted, so remove all timeline rows for that contact
                foreach (atriumDB.TimeLineRow tl in tlr)
                {
                    tl.Delete();
                }

                myFM.DB.TimeLine.AcceptChanges();
            }

        }

        private void setConflictImage(bool hide)
        {
            if (hide)
                lblConflict.Image = null;
            else
            {
                TimeLineItem[] tlitms = timeLine1.GetItemsFromRange(timeLine1.SelectedRange);
                if (tlitms.Length > 0)
                    lblConflict.Image = imageList1.Images[3];
                else
                    lblConflict.Image = imageList1.Images[2];
            }
        }

        private void timeLine1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                timeLine1.ShowLastGroupAsRowHeader = true;

                if (e.Button == System.Windows.Forms.MouseButtons.Right && timeLine1.HitTest(e.X, e.Y) == Janus.Windows.TimeLine.TimeLineArea.GroupRow)
                {
                    TimeLineGroupRow tgr = timeLine1.GetGroupRowAt();
                    if (tgr != null)
                    {
                        cmdRemoveAttendee.Tag = tgr.Value;
                        uiContextMenu2.Show(timeLine1);
                    }
                }

                if (e.Button == System.Windows.Forms.MouseButtons.Right && timeLine1.HitTest(e.X, e.Y) == Janus.Windows.TimeLine.TimeLineArea.GroupIndent)
                {
                    MessageBox.Show("group indent");
                    TimeLineGroupRow tgr = timeLine1.GetGroupRowAt();
                    if (tgr != null)
                    {
                        cmdRemoveAttendee.Tag = tgr.Value;
                        uiContextMenu2.Show(timeLine1);
                    }
                }
                if (e.Button == System.Windows.Forms.MouseButtons.Right && timeLine1.HitTest(e.X, e.Y) == Janus.Windows.TimeLine.TimeLineArea.RowHeader)
                {
                    TimeLineGroupRow tgr = timeLine1.GetGroupRowAt();
                    if (tgr != null)
                    {
                        cmdRemoveAttendee.Tag = tgr.Value;
                        uiContextMenu2.Show(timeLine1);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
        
        private void calendarCombo1_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                Janus.Windows.CalendarCombo.CalendarCombo calcombo = (Janus.Windows.CalendarCombo.CalendarCombo)sender;
                
                if (calcombo == calendarCombo1 || calcombo == startDateCalendarCombo)
                {
                    if (timeLine1.SelectedRange.Start != apptRow.StartDateLocal)
                    {
                        timeLine1.SelectedRange = new DateRange(apptRow.StartDateLocal, apptRow.EndDateLocal);
                        timeLine1.EnsureVisible(timeLine1.SelectedRange.Start);
                        setConflictImage(false);
                    }
                }
                
                if (calcombo == calendarCombo2 || calcombo == endDateCalendarCombo)
                {
                    if (timeLine1.SelectedRange.End != apptRow.EndDateLocal)
                    {
                        timeLine1.SelectedRange = new DateRange(apptRow.StartDateLocal, apptRow.EndDateLocal);
                        timeLine1.EnsureVisible(timeLine1.SelectedRange.Start);
                        setConflictImage(false);
                    }
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkTentative_CheckedChanged(object sender, EventArgs e)
        {
            timeLine1.Refresh();
        }

        private void chkVacation_CheckedChanged(object sender, EventArgs e)
        {
            timeLine1.Refresh();
        }

        private void btnAddAttendees_Click(object sender, EventArgs e)
        {
            try
            {
                AddAttendee();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void RecurrenceUIButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddEditRecurrence();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}