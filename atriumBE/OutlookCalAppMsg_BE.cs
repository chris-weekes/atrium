using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    public class OutlookCalAppMsgBE : atLogic.ObjectBE
    {
        atriumManager myA;
        appDB.OutlookCalAppMsgDataTable myOutlookCalAppMsgDT;

        internal OutlookCalAppMsgBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.OutlookCalAppMsg)
		{
			myA=pBEMng;
            myOutlookCalAppMsgDT = (appDB.OutlookCalAppMsgDataTable)myDT;

            if (myODAL == null)
                myODAL = myA.DALMngr.GetOutlookCalAppMsg();
        }

        public atriumDAL.OutlookCalAppMsgDAL myDAL
        {
            get
            {
                return (atriumDAL.OutlookCalAppMsgDAL)myODAL;
            }
        }

        public appDB.OutlookCalAppMsgDataTable LoadOutlookCalendarAppointmentMsgByFileId(int FileID)
        {
            try
            {
                appDB.OutlookCalAppMsgDataTable dt = myDAL.LoadOutlookCalendarAppointmentMsgByFileId(FileID);
                return dt;
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                return myDAL.LoadOutlookCalendarAppointmentMsgByFileId(FileID);
            }
        }
    }
}
