using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class hlpImageBE:atLogic.ObjectBE
	{
		HelpManager myA;
		HelpDB.hlpImageDataTable myhlpImageDT;
	 
		
		internal hlpImageBE(HelpManager pBEMng):base(pBEMng,pBEMng.DB.hlpImage)
		{
			myA=pBEMng;
			myhlpImageDT=(HelpDB.hlpImageDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GethlpImage();
	
		}
		
		public atriumDAL.hlpImageDAL myDAL
        {
            get
            {
                return (atriumDAL.hlpImageDAL)myODAL;
            }
        }

		public HelpDB.hlpImageRow Load(string FileName)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().hlpImageLoad(FileName, myA.AtMng.AppMan.AtriumXCon));
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
			return myhlpImageDT.FindByFileName(FileName);
		}



	}
}

