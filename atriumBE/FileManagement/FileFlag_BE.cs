using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FileFlagBE:atLogic.ObjectBE
	{
        FileManager myA;
        atriumDB.FileFlagDataTable myFileFlagDT;


        internal FileFlagBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileFlag)
		{
			myA=pBEMng;
            myFileFlagDT = (atriumDB.FileFlagDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileFlag();
	
		}
		
		public atriumDAL.FileFlagDAL myDAL
        {
            get
            {
                return (atriumDAL.FileFlagDAL)myODAL;
            }
        }

      

      

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.FileFlagRow dr = (atriumDB.FileFlagRow)row;
            string ObjectName = this.myFileFlagDT.TableName;

            dr.FileFlagId = myA.AtMng.PKIDGet(ObjectName, 10);
        }

	}
}

