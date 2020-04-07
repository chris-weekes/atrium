using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using atriumBE;
using lmDatasets;

namespace lmras.Calendar
{
    public class Calendar : IHttpHandler
    {
        //11084134 bob white
        atriumManager atMng;
        AppointmentBE aBE;
        AttendeeBE attBE;
        HearingBE hearBE;
        FileContactBE fcBE;
        FilePartyBE fpBE;

        string description;

        public Calendar(atriumManager atSessionMng)
        {
            atMng = atSessionMng;
        }

        public Calendar(atriumManager atSessionMng, int contactID)
        {
            atMng = atSessionMng;
            atMng.WorkAs(contactID);
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        string DateFormat
        {
            get
            {
                return "yyyyMMddTHHmmssZ";
            }
        }

        private void AddNewLine()
        {
            description += "\\r\\n";
        }

        private string FormatDateYYYYMMDD(DateTimeOffset date)
        {
            string mnth;
            string day;

            if (date.Month < 10)
                mnth = "0" + date.Month.ToString();
            else
                mnth = date.Month.ToString();

            if (date.Day < 10)
                day = "0" + date.Day.ToString();
            else
                day = date.Day.ToString();

            return day + "/" + mnth + "/" + date.Year;

        }

        public string FormatMinutes(int minutes)
        {
            TimeSpan ts = new TimeSpan(0, minutes, 0);

            string vminutes = "00";

            if (ts.Minutes > 0 && ts.Minutes < 10)
                vminutes = "0" + ts.Minutes.ToString();
            else if (ts.Minutes >= 10)
                vminutes = ts.Minutes.ToString();

            return vminutes;
        }

        private void writeEventHeader(HttpContext ctx, atriumDB.AppointmentRow ar)
        {
            ctx.Response.Write("\n\rBEGIN:VEVENT");
            if (ar.Tentative)
                ctx.Response.Write("\n\rSTATUS:TENTATIVE");
            ctx.Response.Write("\n\rORGANIZER:MAILTO:" + atMng.WorkingAsOfficer.EmailAddress);
            ctx.Response.Write("\n\rDTSTART:" + ar.StartDate.ToUniversalTime().ToString(DateFormat));
            ctx.Response.Write("\n\rDTEND:" + ar.EndDate.ToUniversalTime().ToString(DateFormat));

            //location
            if (!ar.IsLocationNull())
                ctx.Response.Write("\n\rLOCATION:" + ar.Location);

            ctx.Response.Write("\n\rUID:" + "ATRIUM-" + ar.ApptId + "-" + ar.FileId);
            ctx.Response.Write("\n\rDTSTAMP:" + ar.updateDate.ToUniversalTime().ToString(DateFormat));

            // subject
            if (!ar.IsSubjectNull())
                ctx.Response.Write("\n\rSUMMARY:" + ar.Subject);
        }

        private void writeEventFooter(HttpContext ctx)
        {
            ctx.Response.Write("\n\rDESCRIPTION:" + description);

            // Reminder functionality not working yet
            //ctx.Response.Write("\n\rBEGIN:VALARM");
            //ctx.Response.Write("\n\rTRIGGER:-P2D");
            //ctx.Response.Write("\n\rACTION:DISPLAY");
            //ctx.Response.Write("\n\rDESCRIPTION:Reminder");
            //ctx.Response.Write("\n\rEND:VALARM");

            ctx.Response.Write("\n\rPRIORITY:5");
            ctx.Response.Write("\n\rCLASS:PUBLIC");
            ctx.Response.Write("\n\rEND:VEVENT");
        }

        public void ProcessRequest(HttpContext ctx)
        {
            try
            {

                int officerID = atMng.WorkingAsOfficer.OfficerId;

                FileManager FM = atMng.GetBFFile(officerID);

                aBE = FM.GetAppointment();
                attBE = FM.GetAttendee();
                hearBE = FM.GetSSTMng().GetHearing();
                fcBE = FM.GetFileContact();
                fpBE = FM.GetSSTMng().GetFileParty();

                string organizerEmail = atMng.WorkingAsOfficer.EmailAddress;
                string organizerFirstName = atMng.WorkingAsOfficer.FirstName;
                string organizerLastName = atMng.WorkingAsOfficer.LastName;

                aBE.LoadByContactId(officerID);
            //    attBE.LoadByContactId(officerID);

                ctx.Response.Clear();
                ctx.Response.Buffer = true;
                ctx.Response.ContentEncoding = System.Text.Encoding.UTF8;
                ctx.Response.ContentType = "text/v-calendar";
                ctx.Response.AddHeader("Content-disposition", "attachment; filename=" + organizerFirstName + " " + organizerLastName + ".ics");

                ctx.Response.Write("BEGIN:VCALENDAR");
                ctx.Response.Write("\n\rVERSION:2.0");
                ctx.Response.Write("\n\rPRODID:Atrium");
                ctx.Response.Write("\n\rMETHOD:PUBLISH");
                ctx.Response.Write("\n\rNAME:(Atrium) " + organizerFirstName + " " + organizerLastName);
                ctx.Response.Write("\n\rX-WR-CALNAME:(Atrium) " + organizerFirstName + " " + organizerLastName);

                atriumDB.AttendeeDataTable adt = (atriumDB.AttendeeDataTable)attBE.myDT;

                foreach (atriumDB.AppointmentRow ar in (atriumDB.AppointmentDataTable)aBE.myDT)
                {

                    try
                    {
                        if (ar.ShowAsBusy)
                        {
                            hearBE.myDT.Clear();
                            hearBE.LoadByApptId(ar.ApptId);
                            SST.HearingDataTable hdt = (SST.HearingDataTable)hearBE.myDT;

                            fcBE.myDT.Clear();
                            fcBE.LoadByFileId(ar.FileId);

                            fpBE.myDT.Clear();
                            fpBE.LoadByFileId(ar.FileId);

                            description = string.Empty;

                            System.Globalization.CultureInfo originalCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                            System.Globalization.CultureInfo newCulture = System.Threading.Thread.CurrentThread.CurrentCulture;

                            string langCode = string.Empty;

                            //appDB.OutlookCalAppMsgRow[] ocamr;
                            appDB.OutlookCalAppMsgDataTable ocamdt = atMng.GetOutlookCalAppMsg().LoadOutlookCalendarAppointmentMsgByFileId(ar.FileId);
                            
                            atriumDB.FileContactDataTable fcdt = (atriumDB.FileContactDataTable)fcBE.myDT;
                            SST.FilePartyDataTable fpdt = (SST.FilePartyDataTable)fpBE.myDT;
                            atriumDB.FileContactRow[] fcr;
                            SST.FilePartyRow[] fpr;
                            atriumDB.FileContactRow appellantCR = null;

                            if (fpdt.Rows.Count > 0)
                            {
                                fpr = (SST.FilePartyRow[])fpdt.Select("IsAppellant = 'True'");
                                if (fpr.GetUpperBound(0) > -1)
                                {
                                    fcr = (atriumDB.FileContactRow[])fcdt.Select("FileContactId = " + fpr[0].FileContactId);
                                    appellantCR = fcr[0];
                                    if (appellantCR != null && !appellantCR.IsLanguageCodeNull())
                                        langCode = appellantCR.LanguageCode;
                                }

                            }

                            if (langCode == "F")
                            {
                                newCulture = new System.Globalization.CultureInfo("fr-CA");
                            }
                            else if (langCode == "E")
                            {
                                newCulture = new System.Globalization.CultureInfo("en-CA");
                            }

                            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
                            System.Threading.Thread.CurrentThread.CurrentUICulture = newCulture;

                            //ctx.Response.Write("\n\rBEGIN:VEVENT");
                            //if (ar.Tentative)
                            //    ctx.Response.Write("\n\rSTATUS:TENTATIVE");
                            //ctx.Response.Write("\n\rORGANIZER:MAILTO:" + organizerEmail);
                            //ctx.Response.Write("\n\rDTSTART:" + ar.StartDate.ToUniversalTime().ToString(DateFormat));
                            //ctx.Response.Write("\n\rDTEND:" + ar.EndDate.ToUniversalTime().ToString(DateFormat));

                            ////location
                            //if (!ar.IsLocationNull())
                            //    ctx.Response.Write("\n\rLOCATION:" + ar.Location);

                            //ctx.Response.Write("\n\rUID:" + "ATRIUM-" + ar.ApptId + "-" + ar.FileId);
                            //ctx.Response.Write("\n\rDTSTAMP:" + ar.updateDate.ToUniversalTime().ToString(DateFormat));

                            //// subject
                            //if (!ar.IsSubjectNull())
                            //    ctx.Response.Write("\n\rSUMMARY:" + ar.Subject);

                            if (hdt.Rows.Count <= 0) // general appointment
                            {
                                writeEventHeader(ctx, ar);

                                description = Resources.LocalizedText.CALGeneralAppointment;
                                AddNewLine();
                                description += Resources.LocalizedText.CALGeneralAppointmentMessage;
                                AddNewLine();
                                description += Resources.LocalizedText.CALNoteAppointment;

                                writeEventFooter(ctx);

                            }
                            else // hearing
                            {
                                SST.HearingRow hr = null;
                                hr = (SST.HearingRow)hdt.Rows[0];

                                if (hr != null && hr.HearingStatus < 3) // HearingStatus is either Current or Held
                                {

                                    writeEventHeader(ctx, ar);

                                    // === add attendees, if any
                                    foreach (atriumDB.AttendeeRow atr in adt.Select("ApptId=" + ar.ApptId))
                                    {
                                        string role = "REQ-PARTICIPANT"; //default
                                        string partstat = "ACCEPTED"; //default

                                        if (officerID != atr.ContactId)
                                        {

                                            // participation status
                                            if (atr.Declined) { partstat = "DECLINED"; }
                                            else if (atr.Tentative) { partstat = "TENTATIVE"; }

                                            // required or optional participant
                                            if (!atr.Required) { role = "OPT-PARTICIPANT"; }

                                            atriumDB.ContactRow cr = FM.DB.Contact.FindByContactId(atr.ContactId);

                                            if (cr == null) { cr = FM.GetPerson().Load(atr.ContactId); }

                                            string attendee = "\n\rATTENDEE;ROLE=" + role + ";PARTSTAT=" + partstat + ";RSVP=TRUE;CN=" + cr.FirstName + " " + cr.LastName + ":MAILTO:";

                                            if (!cr.IsEmailAddressNull())
                                                attendee += cr.EmailAddress;
                                            else
                                                attendee += cr.FirstName + "." + cr.LastName + "@noemail.tmp"; // outlook ignores contact if no email provided

                                            ctx.Response.Write(attendee);

                                        }
                                    }
                                    // === end add attendee

                                    appDB.EFileSearchDataTable efsdt = atMng.FileSearchByFileId(ar.FileId);
                                    appDB.EFileSearchRow efsdr = efsdt[0];
                                    atriumDB.FileTypeRow ftr = FM.DB.FileType.FindByFileTypeCode(efsdr.FileType);

                                    // === begin hearing body

                                    if (ocamdt.Rows.Count > 0)
                                    {

                                        appDB.OutlookCalAppMsgRow ocamFirstRow = (appDB.OutlookCalAppMsgRow)ocamdt.Rows[0];
                                        
                                        // Title

                                        description = Resources.LocalizedText.CALHearingAppointment;
                                        AddNewLine();

                                        // Hearing Type (Method)

                                        description += Resources.LocalizedText.CALHearingMethod + " ";
                                        if (langCode == "F")
                                            description += ocamFirstRow.HearingMethodFre;
                                        else
                                            description += ocamFirstRow.HearingMethodEng;
                                        AddNewLine();

                                        // Hearing Date / Time

                                        description += Resources.LocalizedText.CALHearingDateTime;
                                        description += FormatDateYYYYMMDD(ocamFirstRow.StartDate);
                                        int hour = ocamFirstRow.StartDate.LocalDateTime.Hour;

                                        string am_pm = "am";
                                        if (hour >= 12)
                                        {
                                            am_pm = "pm";
                                            if (hour > 12)
                                                hour = hour - 12;
                                        }
                                        description += " " + hour.ToString() + ":" + FormatMinutes(ocamFirstRow.StartDate.Minute) + am_pm + " EST";
                                        AddNewLine();

                                        // Hearing Status

                                        description += Resources.LocalizedText.CALHearingStatus;

                                        if (langCode == "F")
                                            description += ocamFirstRow.HearingStatusFre;
                                        else
                                            description += ocamFirstRow.HearingStatusEng;
                                        AddNewLine();

                                        // Case Management Officer

                                        description += Resources.LocalizedText.CALCMO;
                                        fcr = (atriumDB.FileContactRow[])fcdt.Select("ContactType = 'FAIA'");
                                        if (fcr != null && fcr.GetUpperBound(0) > -1)
                                            if (!fcr[0].IsFirstNameNull() && !fcr[0].IsLastNameNull())
                                                description += fcr[0].FirstName + " " + fcr[0].LastName;
                                        AddNewLine();

                                        // Tribunal Member

                                        description += Resources.LocalizedText.CALTribunalMember;
                                        fcr = (atriumDB.FileContactRow[])fcdt.Select("ContactType = 'FTM'");
                                        if (fcr != null && fcr.GetUpperBound(0) > -1)
                                            if (!fcr[0].IsFirstNameNull() && !fcr[0].IsLastNameNull())
                                                description += fcr[0].FirstName + " " + fcr[0].LastName;
                                        AddNewLine();

                                        // File Number

                                        description += Resources.LocalizedText.CALFileNumber;
                                        description += ocamFirstRow.FullFileNumber.ToString();
                                        AddNewLine();

                                        // File Name

                                        description += Resources.LocalizedText.CALFileName;
                                        if (langCode == "F")
                                            description += ocamFirstRow.NameF;
                                        else
                                            description += ocamFirstRow.NameE;
                                        AddNewLine();

                                        // Appellant Name

                                        description += Resources.LocalizedText.CALAppellantName;
                                        //fcr = (atriumDB.FileContactRow[])fcdt.Select("ContactType = 'PCL'");
                                        if (appellantCR != null && !appellantCR.IsFirstNameNull() && !appellantCR.IsLastNameNull())
                                            description += appellantCR.FirstName + " " + appellantCR.LastName;
                                        AddNewLine();

                                        // Rep Name

                                        description += Resources.LocalizedText.CALRepName;
                                        fcr = (atriumDB.FileContactRow[])fcdt.Select("DelegateFor = 'PCL'");
                                        if (fcr != null && fcr.GetUpperBound(0) > -1)
                                            if (!fcr[0].IsFirstNameNull() && !fcr[0].IsLastNameNull())
                                                description += fcr[0].FirstName + " " + fcr[0].LastName;
                                        AddNewLine();

                                        // Appeal Level

                                        description += Resources.LocalizedText.CALLevel;

                                        if (langCode == "F")
                                            description += ocamFirstRow.AppealLevelFre;
                                        else
                                            description += ocamFirstRow.AppealLevelEng;
                                        AddNewLine();

                                        // Program

                                        description += Resources.LocalizedText.CALProgram;
                                        if (langCode == "F")
                                            description += ocamFirstRow.ProgramDescriptionFre;
                                        else
                                            description += ocamFirstRow.ProgramDescriptionEng;

                                        AddNewLine();

                                        // Hearing Note

                                        description += Resources.LocalizedText.CALNoteHearing;

                                        // === end hearing body

                                        
                                    }

                                    writeEventFooter(ctx);
                                }
                            }

                            
                            //ctx.Response.Write("\n\rDESCRIPTION:" + description);

                            //// Reminder functionality not working yet
                            ////ctx.Response.Write("\n\rBEGIN:VALARM");
                            ////ctx.Response.Write("\n\rTRIGGER:-P2D");
                            ////ctx.Response.Write("\n\rACTION:DISPLAY");
                            ////ctx.Response.Write("\n\rDESCRIPTION:Reminder");
                            ////ctx.Response.Write("\n\rEND:VALARM");

                            //ctx.Response.Write("\n\rPRIORITY:5");
                            //ctx.Response.Write("\n\rCLASS:PUBLIC");
                            //ctx.Response.Write("\n\rEND:VEVENT");

                            System.Threading.Thread.CurrentThread.CurrentCulture = originalCulture;
                            System.Threading.Thread.CurrentThread.CurrentUICulture = originalCulture;

                        }
                    }
                    catch (Exception e)
                    {
                        //ignore
                    }

                }

                ctx.Response.Write("\n\rEND:VCALENDAR");
                ctx.Response.End();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}