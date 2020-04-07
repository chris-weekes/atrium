using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	public class MsgBE : ObjectBE
	{
        atriumManager myA;
        appDB.MsgDataTable myMsgDT;


        internal MsgBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.Msg)
		{
			myA=pBEMng;
            myMsgDT = (appDB.MsgDataTable)myDT;
            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetMsg();
	
		}
		
		public atriumDAL.MsgDAL myDAL
        {
            get
            {
                return (atriumDAL.MsgDAL)myODAL;
            }
        }

	
	}
}

