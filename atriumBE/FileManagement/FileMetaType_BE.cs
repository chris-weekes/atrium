using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FileMetaTypeBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.FileMetaTypeDataTable myFileMetaTypeDT;

		
		internal FileMetaTypeBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.FileMetaType)
		{
			myA=pBEMng;
			myFileMetaTypeDT=(atriumDB.FileMetaTypeDataTable)myDT;

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileMetaType();
        }
        public atriumDAL.FileMetaTypeDAL myDAL
        {
            get
            {
                return (atriumDAL.FileMetaTypeDAL)myODAL;
            }
        }


	



	}
}

