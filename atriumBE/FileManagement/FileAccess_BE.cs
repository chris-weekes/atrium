using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FileAccessBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.FileAccessDataTable myFileAccessDT;


        internal FileAccessBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileAccess)
		{
			myA=pBEMng;
            myFileAccessDT = (atriumDB.FileAccessDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileAccess();
        }

        public atriumDAL.FileAccessDAL myDAL
        {
            get
            {
                return (atriumDAL.FileAccessDAL)myODAL;
            }
        }

		public void LoadByFileId(int FileId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().FileAccessLoadByFileId(FileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(FileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(FileId));
                }
            }
		}

	}
}

