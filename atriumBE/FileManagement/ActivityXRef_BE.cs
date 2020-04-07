using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ActivityXRefBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.ActivityXRefDataTable myActivityXRefDT;

		
		internal ActivityXRefBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.ActivityXRef)
		{
			myA=pBEMng;
			myActivityXRefDT=(atriumDB.ActivityXRefDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetActivityXRef();
        }
        public atriumDAL.ActivityXRefDAL myDAL
        {
            get
            {
                return (atriumDAL.ActivityXRefDAL)myODAL;
            }
        }


		public atriumDB.ActivityXRefRow Load(int Id)
        {
            try
            {
                Fill(myDAL.Load(Id));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(Id));
            }
			
			return myActivityXRefDT.FindById(Id);
		}


	

	}
}

