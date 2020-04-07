using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class DocXRefBE:atLogic.ObjectBE
	{
		DocManager myA;
		docDB.DocXRefDataTable myDocXRefDT;

		
		internal DocXRefBE(DocManager pBEMng):base(pBEMng,pBEMng.DB.DocXRef)
		{
			myA=pBEMng;
			myDocXRefDT=(docDB.DocXRefDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetDocXRef();
        }
        public atriumDAL.DocXRefDAL myDAL
        {
            get
            {
                return (atriumDAL.DocXRefDAL)myODAL;
            }
        }

		public docDB.DocXRefRow Load(int Id)
		{
            if (myA.AtMng.AppMan.UseService)
                Fill(myA.AtMng.AppMan.AtriumX().DocXrefLoad(Id,myA.AtMng.AppMan.AtriumXCon));
            else
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
            }
			return myDocXRefDT.FindById(Id);
		}


    

        protected override void AfterAdd(DataRow dr)
        {
            docDB.DocXRefRow row = (docDB.DocXRefRow)dr;
            //use even
            row.Id = myA.AtMng.PKIDGet("DocXRef", 1);
        }


	}
}

