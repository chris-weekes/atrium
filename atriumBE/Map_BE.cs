using System;
using System.Data;
using System.Collections.Generic;
using atLogic;
using lmDatasets;
using System.Linq;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class MapBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.MapDataTable myMapDT;
	 
		
		internal MapBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.Map)
		{
			myA=pBEMng;
			myMapDT=(appDB.MapDataTable)myDT;
            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetMap();

            Load();
	
		}

        public atriumDAL.MapDAL myDAL
        {
            get
            {
                return (atriumDAL.MapDAL)myODAL;
            }
        }

		

        //map out
        public string MapOut(string atriumTable, string atriumCode)
        {
            var m1 = from m in myMapDT
                     where m.AtriumTable == atriumTable
                     
                     && m.AtriumCode == atriumCode
                     select m;

            if (m1.Count() == 1)
                return m1.Single().OtherCode;
            else
                return null;
        }

        //map in
        public string MapIn(string atriumTable, string otherCode)
        {
            var m1 = from m in myMapDT
                     where m.AtriumTable == atriumTable
                    
                     && m.OtherCode == otherCode
                     select m;

            if (m1.Count() == 1)
                return m1.Single().AtriumCode;
            else
                return null;
        }


	}
}

