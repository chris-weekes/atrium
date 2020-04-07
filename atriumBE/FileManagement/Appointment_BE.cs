using System;
using System.Data;
using atLogic;
using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class AppointmentBE : atLogic.ObjectBE
    {
        FileManager myA;
        atriumDB.AppointmentDataTable myAppointmentDT;

        atriumDB.TimeLineDataTable myTimelineDT;
        private global::System.Object missing = global::System.Type.Missing;

        internal AppointmentBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.Appointment)
        {
            myA = pBEMng;
            myAppointmentDT = (atriumDB.AppointmentDataTable)myDT;

            myTimelineDT = myA.DB.TimeLine;

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetAppointment();

            this.myAppointmentDT.StartDateColumn.ExtendedProperties.Add("format", "f");
            this.myAppointmentDT.StartDateLocalColumn.ExtendedProperties.Add("format", "f");
            this.myAppointmentDT.EndDateColumn.ExtendedProperties.Add("format", "f");
            this.myAppointmentDT.EndDateLocalColumn.ExtendedProperties.Add("format", "f");
        }

        public atriumDAL.AppointmentDAL myDAL
        {
            get
            {
                return (atriumDAL.AppointmentDAL)myODAL;
            }
        }

        public atriumDB.AppointmentRow Load(int ApptId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().AppointmentLoad(ApptId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(ApptId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ApptId));
                }
            }
            SetLocalDates();

            return myAppointmentDT.FindByApptId(ApptId);
        }

        public void LoadByContactId(int ContactId)
        {
            DataSet ds = new atriumDB();

            PreRefresh();
            myA.GetAttendee().PreRefresh();

            if (myA.AtMng.AppMan.UseService)
            {
                ds = BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().AppointmentLoadByContactId(ContactId, myA.AtMng.AppMan.AtriumXCon), ds);
            }
            else
            {
                try
                {
                    ds = BEManager.DecompressDataSet(myDAL.LoadAllForOfficer(ContactId), ds);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    ds = BEManager.DecompressDataSet(myDAL.LoadAllForOfficer(ContactId), ds);
                }
            }
            Fill(ds.Tables["Appointment"]);
            myA.GetApptRecurrence().Fill(ds.Tables["ApptRecurrence"]);
            myA.GetAttendee().Fill(ds.Tables["Attendee"]);
            SetLocalDates();
            ds.Clear();
            ds.Dispose();
        }

       
        public void LoadByContactIdDates(int ContactId, DateTime startDate, DateTime endDate)
        {
            //only for use by ucTimeline
            atriumDB.TimeLineDataTable dt;
            if (myA.AtMng.AppMan.UseService)
            {
                dt = myA.AtMng.AppMan.AtriumX().AppointmentLoadByContactIdDates(ContactId, startDate, endDate, myA.AtMng.AppMan.AtriumXCon);
            }
            else
            {
                try
                {
                    dt = myDAL.LoadByContactIdDates(ContactId, startDate, endDate);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    dt = myDAL.LoadByContactIdDates(ContactId, startDate, endDate);
                }
            }
            myTimelineDT.Merge(dt);

           // LoadOutlookFreeBusy(ContactId, startDate, endDate);
            SetLocalTimeLineDates();
        }

        private void LoadOutlookFreeBusy(int ContactId, DateTime startDate, DateTime endDate)
        {
            //get email for contact
            officeDB.OfficerRow or = myA.AtMng.OfficeMng.DB.Officer.FindByOfficerId(ContactId);
            if(or==null)
                or = myA.AtMng.OfficeMng.GetOfficer().Load(ContactId);
            
            if (or != null)
            {
                string sEmail = or.EmailAddress;

                //get addressentry from RDO
                Redemption.RDOSession sess = DocumentBE.RDOSession();
                sess.Logon(missing, missing, missing, missing, missing, missing);
                //Redemption.RDOAddressList gal = sess.AddressBook.GAL;
                Redemption.RDOAddressEntry ae = sess.AddressBook.ResolveName(sEmail);
                //get free busy
                if (ae.Type == "EX")
                {
                    string s = ae.GetFreeBusy(startDate, 30);
                    Redemption.RDOFreeBusyRange fbr = ae.FreeBusyList;
                    //loop over array
                    foreach (Redemption.RDOFreeBusySlot fbs in fbr)
                    {
                        //load myTimelineDT
                        atriumDB.TimeLineRow tlr = myTimelineDT.NewTimeLineRow();
                        tlr.ContactId = ContactId;
                        tlr.StartDate = fbs.Start;
                        tlr.EndDate = fbs.End;
                        myTimelineDT.AddTimeLineRow(tlr);
                    }
                }
            }
        }

        // not used AC - Mar 27, 2014
        //public void LoadByAllFileContactDates(int FileId, DateTime startDate, DateTime endDate)
        //{
        //    //only for use by ucTimeline

        //    atriumDB.TimeLineDataTable dt;

        //    try
        //    {
        //        dt = myDAL.LoadByAllFileContactDates(FileId, startDate, endDate);
        //    }
        //    catch (System.Runtime.Serialization.SerializationException x)
        //    {
        //        RecoverDAL();
        //        dt = myDAL.LoadByAllFileContactDates(FileId, startDate, endDate);
        //    }
        //    myTimelineDT.Merge(dt);
        //    SetLocalTimeLineDates();

        //}

        public void ClearTimeLine()
        {
            myTimelineDT.Clear();
        }
       

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.AppointmentRow dr = (atriumDB.AppointmentRow)row;
            string ObjectName = this.myAppointmentDT.TableName;

            //System.Diagnostics.Debug.WriteLine(dr["ContactId"] + dr.RowState.ToString() );

            dr.ApptId = this.myA.AtMng.PKIDGet(ObjectName, 10);
            if (dr.IsNull("FileId"))
                dr.FileId = myA.CurrentFileId;
            dr.Type = 0;
            dr.ShowAsBusy = true;
            dr.AllDayEvent = false;
            dr.Subject = "...";
            dr.Tentative = false;
            dr.Vacation = false;

            DateTime d = DateTime.Now.AddHours(1);
            
            dr.StartDateLocal = new DateTime(d.Year, d.Month, d.Day, d.Hour , 0, 0);
            dr.StartDate = dr.StartDateLocal.ToUniversalTime();
            d = d.AddHours(1);
            dr.EndDateLocal = new DateTime(d.Year, d.Month, d.Day, d.Hour, 0, 0);
            dr.EndDate = dr.EndDateLocal.ToUniversalTime();
            dr.OriginalRecurrence = false;

            //atriumDB.AttendeeRow ar = (atriumDB.AttendeeRow)myA.GetAttendee().Add(dr);
            //ar.ContactId = myA.AtMng.WorkingAsOfficer.OfficerId;
            //ar.Accepted = true;

            EFileBE.XmlAddToc(myA.CurrentFile, "appointment", "Calendar", "Calendrier", 119);
        }

        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.AppointmentRow apptRow = (atriumDB.AppointmentRow)dr;
            myA.AtMng.SyncAppointment(apptRow, myA.IsVirtualFM, false);
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            atriumDB.AppointmentRow dr = (atriumDB.AppointmentRow)row;
            if (!dr.IsApptRecurrenceIdNull() && dr.OriginalRecurrence == true && dr.ApptRecurrenceRow!=null)
            {
                dr.ApptRecurrenceRow.updateDate = DateTime.Now;
            }
            switch (dc.ColumnName)
            {
                case "StartDateLocal":
                    
                    if (!dr.IsEndDateLocalNull() && !dr.IsStartDateLocalNull() && !dr.IsNull("EndDate") && !dr.IsNull("StartDate") )
                    {
                        //keep duration
                        TimeSpan ts = dr.StartDate.DateTime.Subtract(dr.EndDate.DateTime);
                        dr.EndDateLocal=dr.StartDateLocal.Add(ts.Duration());
                        dr.EndDate = dr.EndDateLocal.ToUniversalTime();
                    }

                    dr.StartDate = dr.StartDateLocal.ToUniversalTime();

                    dr.EndEdit();
                    break;
                case "EndDateLocal":
                    if (!dr.IsEndDateLocalNull() && !dr.IsStartDateLocalNull() && !dr.IsNull("EndDate") && !dr.IsNull("StartDate"))
                    {
                        if (dr.EndDateLocal <= dr.StartDateLocal)
                        {
                            dr.StartDateLocal = dr.EndDateLocal.AddHours(-1);
                        }                        
                    }
                    dr.EndDate = dr.EndDateLocal.ToUniversalTime();
                    dr.EndEdit();
                    break;
            }
        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {
            atriumDB.AppointmentRow dr = (atriumDB.AppointmentRow)row;

            switch (dc.ColumnName)
            {
                case "Subject":
                    if (dr.IsSubjectNull())
                    {
                        throw new RequiredException(dc.ColumnName);
                    }
                    break;
                case "StartDate":

                    //  myA.IsValidDate(Resources.ActivityActivityDate, dr.StartDate, false, DateTime.Today.AddYears(-1), DateTime.Today.AddYears(1), String.Format(Resources.ValidationXYearsAgo, 1), String.Format(Resources.ValidationXYearsFromToday, 1));

                    //   myA.IsWarningDate(Resources.ActivityDateWarning, dr.StartDate, false, DateTime.Today, DateTime.Today.AddYears(1));

                    break;
                case "EndDate":
                    break;
            }
        }

        protected override void BeforeDelete(DataRow row)
        {
            if(!myA.IsVirtualFM)
                myA.AtMng.SyncAppointment((atriumDB.AppointmentRow)row, false, true);
        }

        protected override void BeforeUpdate(DataRow dr)
        {
            BeforeChange("Subject", dr);

             atriumDB.AppointmentRow apptRow = (atriumDB.AppointmentRow)dr;

             if (!apptRow.IsIntervalNull()) 
             {

               officeDB.OfficerRow workingas = myA.AtMng.WorkingAsOfficer; 
               foreach (atriumDB.AttendeeRow att in apptRow.GetAttendeeRows())
               {
                   if (att.ContactId == workingas.OfficerId || att.RowState== DataRowState.Added)
                   { 
                       att.Interval = apptRow.Interval;
                       att.NotificationDismiss = false;
                   }
                     
               }
             } 

            //if (!apptRow.IsApptRecurrenceIdNull() && apptRow.OriginalRecurrence == true)
            //{
            //    apptRow.ApptRecurrenceRow.updateDate = DateTime.Now;
            //}
            if (!apptRow.IsApptRecurrenceIdNull())
            {
                if (apptRow.ApptRecurrenceRow.RecurrenceRemoved)
                {
                    apptRow.ApptRecurrenceRow.Delete();
                    apptRow.SetApptRecurrenceIdNull();
                    myA.DB.ApptRecurrence.AcceptChanges();
                }
            }
        }

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[] { this.myA.CurrentFile };
        //}

        public override DataRow[] GetCurrentRow()
        {
            return myAppointmentDT.Select();
        }

        public override string PromptColumnName()
        {
            return "Subject";
        }

        public override string FriendlyName()
        {
            return myAppointmentDT.TableName; ;
        }

        public override string PromptFormat()
        {
            return "";
        }

        public void SetLocalDates()
        {
            myA.isMerging = true;

            foreach (atriumDB.AppointmentRow dr in myAppointmentDT)
            {
                dr.EndDateLocal = dr.EndDate.LocalDateTime;
                dr.StartDateLocal = dr.StartDate.LocalDateTime;
                dr.AcceptChanges();
            }

            myA.isMerging = false;

        }

        public void SetLocalTimeLineDates()
        {
            myA.isMerging = true;

            foreach (atriumDB.TimeLineRow dr in myTimelineDT)
            {
                dr.EndDateLocal = dr.EndDate.LocalDateTime;
                dr.StartDateLocal = dr.StartDate.LocalDateTime;
                dr.AcceptChanges();
            }

            myA.isMerging = false;

        }
    }
}