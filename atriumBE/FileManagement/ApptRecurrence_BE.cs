using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ApptRecurrenceBE:atLogic.ObjectBE
	{
        FileManager myA;
		atriumDB.ApptRecurrenceDataTable myApptRecurrenceDT;

        internal ApptRecurrenceBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.ApptRecurrence)
		{
			myA=pBEMng;
            myApptRecurrenceDT = (atriumDB.ApptRecurrenceDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetApptRecurrence();
		}
		
		public atriumDAL.ApptRecurrenceDAL myDAL
        {
            get
            {
                return (atriumDAL.ApptRecurrenceDAL)myODAL;
            }
        }

        public atriumDB.ApptRecurrenceRow Load(int ApptRecurrenceId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().ApptRecurrenceLoad(ApptRecurrenceId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(ApptRecurrenceId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(ApptRecurrenceId));
                }
            }
			return myApptRecurrenceDT.FindByApptRecurrenceId(ApptRecurrenceId);
		}

        protected override void AfterAdd(DataRow row)
        {

            atriumDB.ApptRecurrenceRow dr = (atriumDB.ApptRecurrenceRow)row;
            string ObjectName = this.myApptRecurrenceDT.TableName;

            dr.ApptRecurrenceId = myA.AtMng.PKIDGet(ObjectName, 10);

        }
        
        atriumDB.AppointmentRow originalApptRow;

        protected override void BeforeUpdate(DataRow dr)
        {
            atriumDB.ApptRecurrenceRow drApptRecurrence = (atriumDB.ApptRecurrenceRow)dr;

            DataRow[] apptRows = myA.DB.Appointment.Select("ApptRecurrenceId=" + drApptRecurrence.ApptRecurrenceId.ToString() + " AND OriginalRecurrence='True'");
            if (apptRows.Length > 0)
            {
                originalApptRow = (atriumDB.AppointmentRow)apptRows[0];

                atriumDB.AppointmentRow[] appdt = originalApptRow.ApptRecurrenceRow.GetAppointmentRows();
                foreach (atriumDB.AppointmentRow apptRow in appdt)
                {
                    if (originalApptRow.ApptId != apptRow.ApptId)
                    {
                        atriumDB.AttendeeRow[] attRows = apptRow.GetAttendeeRows();
                        foreach (atriumDB.AttendeeRow attRow in attRows)
                        {
                            attRow.Delete();
                        }
                        apptRow.Delete();
                    }
                }
                if (drApptRecurrence.RecurrenceRemoved)
                {
                  //  originalApptRow.SetApptRecurrenceIdNull();
                    originalApptRow.OriginalRecurrence = false;
                    //drApptRecurrence.Delete();
                }
                else
                {
                    CreateRecurrenceAppointments(originalApptRow);
                }
            }
        }

        public override DataRow[] GetCurrentRow()
        {
            return myApptRecurrenceDT.Select();
        }

        DateTime trackDate;
        TimeSpan tsAppointmentLength;
        atriumDB.AttendeeRow[] originalAttRows;
        DateTime recurrenceEndDate;
        int occursEvery;

        private void CreateRecurrenceAppointments(atriumDB.AppointmentRow apptRow)
        {

            originalApptRow = apptRow;

            originalAttRows = originalApptRow.GetAttendeeRows();
            trackDate = originalApptRow.StartDateLocal;

            DateTime tmpDateTime = apptRow.ApptRecurrenceRow.EndRangeDate.DateTime;
            tmpDateTime = tmpDateTime.AddHours(trackDate.TimeOfDay.Hours);
            recurrenceEndDate = tmpDateTime;
            occursEvery = apptRow.ApptRecurrenceRow.OccursEvery;
            tsAppointmentLength = originalApptRow.EndDateLocal - originalApptRow.StartDateLocal;

            switch (originalApptRow.ApptRecurrenceRow.ApptRecurrenceTypeId)
            {
                case 0:
                    AddRecurrenceAppointmentDaily();
                    break;
                case 1:
                    AddRecurrenceAppointmentWeekly();
                    break;
                case 2:
                    AddRecurrenceAppointmentMonthly();
                    break;
                default:
                    // do nothing
                    break;
            }
        }

        private void AddRecurringAppointment()
        {

            atriumDB.AppointmentRow newApptRow;
            atriumDB.AttendeeRow newAttRow;

            newApptRow = (atriumDB.AppointmentRow)myA.GetAppointment().Add(null);
            newApptRow.FileId = originalApptRow.FileId;
            if (!originalApptRow.IsActivityIdNull())
                newApptRow.ActivityId = originalApptRow.ActivityId;
            newApptRow.StartDateLocal = trackDate;
            newApptRow.EndDateLocal = trackDate + tsAppointmentLength;
            if (!originalApptRow.IsTypeNull())
                newApptRow.Type = originalApptRow.Type;
            if (!originalApptRow.IsSubjectNull())
                newApptRow.Subject = originalApptRow.Subject;
            newApptRow.ShowAsBusy = originalApptRow.ShowAsBusy;
            newApptRow.AllDayEvent = originalApptRow.AllDayEvent;
            if (!originalApptRow.IsDescriptionNull())
                newApptRow.Description = originalApptRow.Description;
            if (!originalApptRow.IsLocationNull())
                newApptRow.Location = originalApptRow.Location;
            newApptRow.Tentative = originalApptRow.Tentative;
            newApptRow.Vacation = originalApptRow.Vacation;
            newApptRow.ApptRecurrenceId = originalApptRow.ApptRecurrenceId;

            // add attendees to new recurring appointment
            foreach (atriumDB.AttendeeRow originalAttRow in originalAttRows)
            {
                newAttRow = (atriumDB.AttendeeRow)myA.GetAttendee().Add(newApptRow);
                newAttRow.FileId = originalAttRow.FileId;
                newAttRow.ContactId = originalAttRow.ContactId;
                newAttRow.Accepted = originalAttRow.Accepted;
                newAttRow.Declined = originalAttRow.Declined;
                newAttRow.Required = originalAttRow.Required;
                newAttRow.Tentative = originalAttRow.Tentative;
            }
        }

        private void AddRecurrenceAppointmentDaily()
        {
            trackDate = trackDate.AddDays(occursEvery);
            if (trackDate < recurrenceEndDate)
            {
                do
                {
                    AddRecurringAppointment();
                    trackDate = trackDate.AddDays(occursEvery);
                } while (trackDate < recurrenceEndDate);
            }
        }

        private void AddRecurrenceAppointmentWeekly()
        {
            DateTime startRecurrenceDate = trackDate;

            System.Collections.Generic.List<int> dayList = new System.Collections.Generic.List<int>();

            recurrenceEndDate = recurrenceEndDate.AddDays(1); // end date will be respected

            // get all selected days
            
            if(originalApptRow.ApptRecurrenceRow.Sunday)
                dayList.Add(0);
            if (originalApptRow.ApptRecurrenceRow.Monday)
                dayList.Add(1);
            if (originalApptRow.ApptRecurrenceRow.Tuesday)
                dayList.Add(2);
            if (originalApptRow.ApptRecurrenceRow.Wednesday)
                dayList.Add(3);
            if (originalApptRow.ApptRecurrenceRow.Thursday)
                dayList.Add(4);
            if (originalApptRow.ApptRecurrenceRow.Friday)
                dayList.Add(5);
            if (originalApptRow.ApptRecurrenceRow.Saturday)
                dayList.Add(6);

            int daysAdded = 1;
            trackDate = trackDate.AddDays(1); // first time around we account for the fact that the original appointment has already been added

            if (trackDate < recurrenceEndDate)
            {
                do
                {
                    if (daysAdded < dayList.Count)
                    {
                        if (dayList.Contains((int)trackDate.DayOfWeek))
                        {
                            AddRecurringAppointment();
                            daysAdded += 1;
                        }
                        trackDate = trackDate.AddDays(1);
                    }
                    else
                    {
                        startRecurrenceDate = startRecurrenceDate.AddDays(7 * occursEvery);
                        trackDate = startRecurrenceDate;
                        daysAdded = 0;
                    }

                } while (trackDate < recurrenceEndDate);
            }
        }

        private void AddRecurrenceAppointmentMonthly()
        {
            trackDate = trackDate.AddMonths(occursEvery);
            if (trackDate <= recurrenceEndDate)
            {
                do
                {
                    AddRecurringAppointment();
                    trackDate = trackDate.AddMonths(occursEvery);

                } while (trackDate <= recurrenceEndDate);
            }
        }

	}
}