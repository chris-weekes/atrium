using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FileAKABE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.FileAKADataTable myFileAKADT;


        internal FileAKABE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileAKA)
		{
			myA=pBEMng;
			myFileAKADT=(atriumDB.FileAKADataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileAKA();
        }
        public atriumDAL.FileAKADAL myDAL
        {
            get
            {
                return (atriumDAL.FileAKADAL)myODAL;
            }
        }


	


	}
}

