using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class hlpPageBE:atLogic.ObjectBE
	{
		HelpManager myA;
		HelpDB.hlpPageDataTable myhlpPageDT;
	 
		
		internal hlpPageBE(HelpManager pBEMng):base(pBEMng,pBEMng.DB.hlpPage)
		{
			myA=pBEMng;
			myhlpPageDT=(HelpDB.hlpPageDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GethlpPage();
	
		}
		
		public atriumDAL.hlpPageDAL myDAL
        {
            get
            {
                return (atriumDAL.hlpPageDAL)myODAL;
            }
        }

		public HelpDB.hlpPageRow Load(string FileName, string lang)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().hlpPageLoad(FileName, lang, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(FileName, lang));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(FileName, lang));
                }
            }

			return myhlpPageDT.FindByFileNameLang(FileName,lang);
		}



	}
}

