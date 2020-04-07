using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class EventLogBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.EventLogDataTable myEventLogDT;



        internal EventLogBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.EventLog)
		{
			myA=pBEMng;
            myEventLogDT = (appDB.EventLogDataTable)myDT;

            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetEventLog();
        }
        public atriumDAL.EventLogDAL myDAL
        {
            get
            {
                return (atriumDAL.EventLogDAL)myODAL;
            }
        }


	

	}
}

