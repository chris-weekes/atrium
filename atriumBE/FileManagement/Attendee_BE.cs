using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class AttendeeBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.AttendeeDataTable myAttendeeDT;
	 
		internal AttendeeBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.Attendee)
		{
			myA=pBEMng;
			myAttendeeDT=(atriumDB.AttendeeDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetAttendee();
		}
        
        public atriumDAL.AttendeeDAL myDAL
        {
            get
            {
                return (atriumDAL.AttendeeDAL)myODAL;
            }
        }

		public void LoadByApptId(int ApptId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().AttendeeLoadByApptId(ApptId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
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
		}

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.AttendeeRow dr = (atriumDB.AttendeeRow)row;
            string ObjectName = this.myAttendeeDT.TableName;

            //System.Diagnostics.Debug.WriteLine(dr["ContactId"] + dr.RowState.ToString() );

            dr.AttendeeId = this.myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = myA.CurrentFileId;
            dr.Accepted = false;
            dr.Declined = false;
            dr.Required = true;
            dr.Tentative = false;
        }

        protected override void AfterUpdate(DataRow dr)
        {
            //atriumDB.AttendeeRow attRow = (atriumDB.AttendeeRow)dr;
            //attRow.AppointmentRow.updateDate = DateTime.Now;
        }

        protected override void BeforeDelete(DataRow row)
        {
            //atriumDB.AttendeeRow attRow = (atriumDB.AttendeeRow)row;
            //attRow.AppointmentRow.updateDate = DateTime.Now;
        }

        public override DataRow[] GetCurrentRow()
        {
            return myAttendeeDT.Select();
        }

        public override string PromptColumnName()
        {
            return "ContactId";
        }

        public override string FriendlyName()
        {
            return myAttendeeDT.TableName; ;
        }

        public override string PromptFormat()
        {
            return "";
        }
	}
}