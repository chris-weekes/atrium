using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

namespace LawMate
{
    public partial class fCalendar : fBase
    {
        FileManager myFMCal;
        int myOfficerId;
        public fCalendar()
        {
            InitializeComponent();
        }
         
        OfficerPrefsBE OfficerPref;
        
        public fCalendar(Form f, int officerId)
            : base(f)
        {
            InitializeComponent();
            myOfficerId = officerId;
            myFMCal = AtMng.GetBFFile(myOfficerId);


            myFMCal.GetAppointment().LoadByContactId(myOfficerId);
          //  myFMCal.GetAttendee().LoadByContactId(myOfficerId);

            ucCalendar1.OfficerId = myOfficerId;
            ucCalendar1.FM = myFMCal;
            ucCalendar1.IsOfficerCal = true;
            ucCalendar1.BindData(myFMCal.DB.Appointment);

            uiCommandManager1.MergeCommandManager(ucCalendar1.CommandManager());

            timer1.Interval = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.BFTimerInterval, AtMng.GetSetting(atriumBE.AppIntSetting.DefaultBFTimerInterval));

            //set OfficerPrefBE
            OfficerPref = AtMng.OfficeMng.GetOfficerPrefs();
        }

        public void MoreInfo(string linkTable, int linkId)
        {
            ucCalendar1.MoreInfo(linkTable, linkId);
        }
        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        string GetStringDueIn(int dueInMinutes, TimeSpan timespan)
        {
            if (timespan.Minutes > 0) // upcoming
            {
                string sDays = null;
                string sHours = null;
                string sMinutes = null;
                int minutes = timespan.Minutes;
                int hours = timespan.Hours;
                int days = timespan.Days;

                if (minutes != 0)
                {
                    if (minutes == 1)
                        sMinutes = minutes.ToString() + " " + Properties.Resources.ResxMinute + " ";
                    else
                        sMinutes = minutes.ToString() + " " + Properties.Resources.ResxMinutes + " "; // sMinutes = minutes.ToString() + " minutes ";
                }

                if (hours != 0)
                {
                    if (hours == 1)
                        sHours = hours.ToString() + " " + Properties.Resources.ResxHour + " ";
                    else
                        sHours = hours.ToString() + " " + Properties.Resources.ResxHours + " ";
                }

                if (days != 0)
                {
                    if (days == 1)
                        sDays = days.ToString() + " " + Properties.Resources.Resxday + " ";
                    else
                        sDays = days.ToString() + " " + Properties.Resources.Resxdays + " ";
                }

                return sDays + sHours + sMinutes  ;
 
            }
            else //overdue
            {
                string sDays =null;
                string sHours=null;
                string sMinutes=null;
                int minutes = Math.Abs(timespan.Minutes);
                int hours = Math.Abs(timespan.Hours);
                int days = Math.Abs(timespan.Days);

            //    if (AtMng.AppMan.Language == "ENG")
           //     {
                    if (minutes != 0)
                    {
                        if (minutes== 1)
                            sMinutes = minutes.ToString() + " "+ Properties.Resources.ResxMinute + " ";
                        else
                            sMinutes = minutes.ToString() + " " + Properties.Resources.ResxMinutes + " "; // sMinutes = minutes.ToString() + " minutes ";
                    }

                    if (hours != 0)
                    {
                        if (hours == 1)
                            sHours = hours.ToString() + " " + Properties.Resources.ResxHour + " ";
                        else
                            sHours = hours.ToString() + " " + Properties.Resources.ResxHours + " ";
                    }

                    if (days != 0)
                    {
                        if (days == 1)
                            sDays = days.ToString() + " "+ Properties.Resources.Resxday + " ";
                        else
                            sDays = days.ToString() + " " + Properties.Resources.Resxdays + " ";
                    }
                    
                    return sDays + sHours + sMinutes + Properties.Resources.ResxLate;
              
            }

            
        }
 
        private DataTable notificationDT;
        private fApptNotification fApp =null;
        public void EnableReminders()
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                int dueInMinutes;

                notificationDT = new DataTable("AppointmentNotification");
                notificationDT.Columns.Add("AttendeeId", typeof(int));
                notificationDT.Columns.Add("Subject", typeof(string));
                notificationDT.Columns.Add("DueIn", typeof(string));
                notificationDT.Columns.Add("StartDateLocal", typeof(DateTime));
                notificationDT.Columns.Add("Interval", typeof(int));
                 //foreach (atriumDB.AttendeeRow attrow in myFMCal.DB.Attendee.Rows)
                atriumDB.AttendeeRow[] attrs = (atriumDB.AttendeeRow[])myFMCal.DB.Attendee.Select("ContactId=" + myOfficerId.ToString());
                foreach (atriumDB.AttendeeRow attrow in attrs)
                {
                    if (!attrow.IsIntervalNull() && !attrow.IsNotificationDismissNull())
                    {
                        atriumDB.AppointmentRow appr = attrow.AppointmentRow;
                        if (appr!= null && appr.RowState != DataRowState.Deleted)
                        { 
                            dueInMinutes = appr.StartDateLocal.Subtract(DateTime.Now).Minutes;
                            if (attrow.Interval > 0 && dueInMinutes <= attrow.Interval)
                            {
                                if (!attrow.NotificationDismiss)
                                {
                                    string sDueIn = GetStringDueIn(dueInMinutes, appr.StartDateLocal.Subtract(DateTime.Now));
                                    notificationDT.Rows.Add(attrow.AttendeeId, appr.Subject, sDueIn, appr.StartDateLocal, attrow.Interval);
                                    notificationDT.AcceptChanges();
                                }
                            }
                        }
                    }
                }
                if (notificationDT.Rows.Count > 0  )
                {
                 //   if (fApp == null  )
                    if (!VerifyOpenForm("fApptNotification"))
                    {
                        fApp = new fApptNotification(myFMCal, notificationDT);
                        fApp.Show();
                        fApp.WindowState = FormWindowState.Normal;
                    }
                    else 
                    {
                        fApp.Datasource = notificationDT;
                        fApp.Refresh();
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }



        public bool VerifyOpenForm(string id)
        {
            Form f = GetOpenForm(id);
            if (f == null)
                return false;
            else
                return true;
        }

        public Form GetOpenForm(string id)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == id) //form is open, activate it
                {
                    f.Activate();
                    return f;
                }
             }
            return null;

        }





       
        List<int> alreadydinged = new List<int>();
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (OfficerPref.GetPref(OfficerPrefsBE.EnableReminders, true))
                EnableReminders();
            return;
          
            //function deferred until release 1.9 CJW

            myFMCal.GetAppointment().LoadByContactId(myOfficerId);
         

            atriumDB.AppointmentRow[] ars = (atriumDB.AppointmentRow[])myFMCal.DB.Appointment.Select("StartDateLocal > #" + DateTime.Today.ToString("yyyy/MM/dd") + "#", "StartDateLocal");
            foreach (atriumDB.AppointmentRow ar in ars)
            {
                if (!alreadydinged.Contains(ar.ApptId))
                {
                    double diff=ar.StartDateLocal.Subtract(DateTime.Now).TotalMinutes;
                    int window = AtMng.GetSetting(AppIntSetting.CalNotifyWindow);
                    if (diff <= window && diff >= -window)
                    {
                        alreadydinged.Add(ar.ApptId);
                        fNotify fn = new fNotify(this, ar.ApptId);

                        break;
                    }
                }
            }
        }



    }
}

