using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class hlpXmlBE:atLogic.ObjectBE
	{
		HelpManager myA;
		HelpDB.hlpXmlDataTable myhlpXmlDT;
	 
		
		internal hlpXmlBE(HelpManager pBEMng):base(pBEMng,pBEMng.DB.hlpXml)
		{
			myA=pBEMng;
			myhlpXmlDT=(HelpDB.hlpXmlDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GethlpXml();
	
		}
		
		public atriumDAL.hlpXmlDAL myDAL
        {
            get
            {
                return (atriumDAL.hlpXmlDAL)myODAL;
            }
        }

		public HelpDB.hlpXmlRow Load(string FileName)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().hlpXmlLoad(FileName, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(FileName));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(FileName));
                }
            }

			return myhlpXmlDT.FindByFileName(FileName);
		}



	}
}

