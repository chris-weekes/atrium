using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class HearingBE:atLogic.ObjectBE
	{
		
        SSTManager myA;
		SST.HearingDataTable myHearingDT;

        internal HearingBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.Hearing)
		{
			myA=pBEMng;
			myHearingDT=(SST.HearingDataTable)myDT;
            if (myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetHearing();
	
		}
		
		public atriumDAL.HearingDAL myDAL
        {
            get
            {
                return (atriumDAL.HearingDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            SST.HearingRow dr = (SST.HearingRow)row;
            string ObjectName = this.myHearingDT.TableName;
            dr.HearingID = this.myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileID = myA.FM.CurrentFileId;
            dr.SSTCaseId = ((SST.SSTCaseRow)myA.GetSSTCase().GetCurrentRow()[0]).SSTCaseId;
            dr.HearingStatus = 1;

            foreach (lmDatasets.SST.HearingRow hrow in myHearingDT)
            {
                if (hrow.HearingID != dr.HearingID && hrow.HearingStatus == 1)
                    hrow.HearingStatus = 5;
            }
        }

        protected override void AfterUpdate(DataRow dr)
        {
            SST.HearingRow fcr = (SST.HearingRow)dr;

            //this updates the hearing info sub-node under the sst node in the TOC
            SST.SSTCaseRow scr=myA.DB.SSTCase[0];

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml; 
            myA.GetSSTCase().MyXml(scr, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
        }

        protected override void BeforeUpdate(DataRow row)
        {
            SST.HearingRow dr = (SST.HearingRow)row;
            myA.FM.CurrentFile.SetMisc1DateNull();
            foreach (SST.HearingRow ahr in myHearingDT)
            {
                if (ahr.HearingStatus == 1 && !ahr.IsApptIdNull())
                {
                    atriumDB.AppointmentRow aDr = myA.FM.DB.Appointment.FindByApptId(ahr.ApptId);
                    myA.FM.CurrentFile.Misc1Date = aDr.StartDateLocal.Date;
                }
            }
        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {
             SST.HearingRow dr = (SST.HearingRow)row;
             switch (dc.ColumnName)
             {
                 case "PINMode":
                     if (!dr.IsPINModeNull())
                     {
                         if (!dr.IsHearingMethodIdNull() && dr.HearingMethodId != 3 && dr.PINMode==3) // teleconference
                         {
                             throw new AtriumException(Properties.Resources.HearingPINMode);
                         }
                     
                     }
                     break;
             }
        }
        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.HearingRow dr = (SST.HearingRow)row;
            switch(dc.ColumnName)
            {
                case  "ApptId":
                    //add all the filecontacts as attendees
                    //atriumDB.AppointmentRow appr = myA.FM.DB.Appointment.FindByApptId(dr.ApptId);
                    //foreach (SST.FilePartyRow fcr in myA.DB.FileParty)
                    //{
                    //    atriumDB.AttendeeRow ar = (atriumDB.AttendeeRow)myA.FM.GetAttendee().Add(appr);
                    //    ar.ContactId = fcr.PartyId;
                    //    ar.Accepted = true;
                    //}
                    break;
                case "HearingToCloneId":
                    SST.HearingRow drHearing2Clone = (SST.HearingRow)myA.DB.Hearing.Select("ApptId=" + dr.HearingToCloneId)[0];
                    
                    //are attendees loaded already?
                    //myA.FM.GetAttendee().LoadByApptId(drHearing2Clone.ApptId);

                    //find new appointment 
                    atriumDB.AppointmentRow apptRow = myA.FM.DB.Appointment.FindByApptId(dr.ApptId);
                    atriumDB.AppointmentRow oldApptRow = myA.FM.DB.Appointment.FindByApptId(drHearing2Clone.ApptId);
                    oldApptRow.ShowAsBusy = false;

                    //add attendees for each attendee in cloned hearing
                    foreach (atriumDB.AttendeeRow attendeerow in myA.FM.DB.Attendee.Select("ApptId=" + drHearing2Clone.ApptId))
                    {
                        atriumDB.AttendeeRow newAttendee= (atriumDB.AttendeeRow)myA.FM.GetAttendee().Add(apptRow);
                        newAttendee.ContactId = attendeerow.ContactId;
                    }
                    dr.HearingMethodId = drHearing2Clone.HearingMethodId;
                    apptRow.Subject = oldApptRow.Subject;

                    break;
                case "HearingMethodId":
                    if (!dr.IsHearingMethodIdNull())
                    {
                        if (dr.HearingMethodId != 3) // teleconference
                        {
                            dr.SetSecurityPINNull();
                        }
                    }
                    break;
                case "PINMode":
                    if (!dr.IsHearingMethodIdNull())
                    {
                        if (dr.HearingMethodId == 3) // teleconference
                        {
                            atriumDB.FileContactRow fcrTM = myA.FM.GetFileContact().GetByRole("FTM");
                            //SST.HearingDataTable hdt = myDAL.LoadByMemberId(fcrTM.ContactId);
                            DataTable dt = myA.AtMng.GetGeneralRec("select * from vddeSecurityPIN where OfficerID=" + fcrTM.ContactId.ToString());
                            Random random = new Random();

                            int PIN = 0;
                            
                            if (!dr.IsPINModeNull())
                            {
                                if (!dr.IsSecurityPINNull())
                                {
                                    dr.PreviousSecurityPIN = dr.SecurityPIN;
                                }
                                else
                                {
                                    //see if there this member already has a PIN for the file.
                                    DataRow[] drs = dt.Select("Fileid=" + dr.FileID.ToString());
                                    if (drs.Length > 0)
                                    {
                                        dr.SecurityPIN = (int)drs[0]["SecurityPIN"];
                                        dr.PreviousSecurityPIN = dr.SecurityPIN;
                                    }
                                    else
                                    {
                                        dr.PreviousSecurityPIN = 0;
                                    }
                                }
                                if (dr.PINMode == 1 || dr.PINMode==3 || dr.IsSecurityPINNull()) // generate new PIN
                                {
                                
                                    PIN = GeneratePIN(dt);
                                }
                                else // check for duplicates not on the same file
                                {
                                    DataRow[] drs = dt.Select("SecurityPIN=" + dr.SecurityPIN.ToString() + " and Fileid<>"+dr.FileID.ToString() );
                                    if (drs.Length > 0)
                                    {
                                        PIN = GeneratePIN(dt);
                                    }
                                    else
                                    {
                                        dr.PreviousSecurityPIN = 0; //this is to force the current PIN into the member's PIN history
                                        PIN = dr.SecurityPIN;
                                    }
                                }
                            }
                         
                            dr.SecurityPIN = PIN;
                        }
                    }
                    break;
            }
        }

		public SST.HearingRow Load(int HearingID)
		{
		    try
            {
				Fill(myDAL.Load(HearingID));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.Load(HearingID));
            }

			return myHearingDT.FindByHearingID(HearingID);
		}


		public void LoadByApptId(int ApptId)
		{
		    try
            {
				Fill(myDAL.LoadByApptId(ApptId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadByApptId(ApptId));
            }
		}

		public void LoadByMemberId(int MemberId)
		{
		    try
            {
				Fill(myDAL.LoadByMemberId(MemberId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadByMemberId(MemberId));
            }
		}

		public void LoadByFileID(int FileID)
		{
		    try
            {
				Fill(myDAL.LoadByFileID(FileID));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadByFileID(FileID));
            }
		}

		public void LoadBySSTCaseId(int SSTCaseId)
		{
		    try
            {
				Fill(myDAL.LoadBySSTCaseId(SSTCaseId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
				Fill(myDAL.LoadBySSTCaseId(SSTCaseId));
            }
		}

        public void LoadByHearingRoomId(int HearingRoomId)
        {
            try
            {
                Fill(myDAL.LoadByHearingRoomId(HearingRoomId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByHearingRoomId(HearingRoomId));
            }
        }

        public void LoadBySCOfficeId(int SCOfficeId)
        {
            try
            {
                Fill(myDAL.LoadBySCOfficeId(SCOfficeId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadBySCOfficeId(SCOfficeId));
            }
        }

        public override string PromptColumnName()
        {
            return "HearingStatus";
        }

        public override string FriendlyName()
        {
            return myHearingDT.TableName; 
        }

        public override string PromptFormat()
        {
            return "";
        }

        private int GeneratePIN(DataTable hdt)
        {

            int PIN = 0;
            bool newPIN = false;
            Random random = new Random();

            do
            {
                PIN = random.Next(0000, 10000);
                DataRow[] drs = hdt.Select("SecurityPIN=" + PIN.ToString() );
                if (drs.Length == 0) { newPIN = true; }

            } while (!newPIN);

            return PIN;
        }

	}
}