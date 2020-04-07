using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ProcessContextBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.ProcessContextDataTable myProcessContextDT;
	 
		
		internal ProcessContextBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.ProcessContext)
		{
			myA=pBEMng;
			myProcessContextDT=(atriumDB.ProcessContextDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetProcessContext();
	
		}
		
		public atriumDAL.ProcessContextDAL myDAL
        {
            get
            {
                return (atriumDAL.ProcessContextDAL)myODAL;
            }
        }

		

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.ProcessContextRow dr = (atriumDB.ProcessContextRow)row;
            string ObjectName = this.myProcessContextDT.TableName;

            dr.CtxId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = dr.ProcessRow.FileId;
        }


	}
}

