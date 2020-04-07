using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ListBE:atLogic.ObjectBE
	{
        public appDB.ListDataTable myListDT
        {
            get
            {
                return (appDB.ListDataTable)myDT;
            }
        }
        public atriumManager myA
        {
            get
            {
                return (atriumManager)MyMngr;
            }
        }
        public atriumDAL.ListDAL myDAL
        {
            get
            {
                return (atriumDAL.ListDAL)myODAL;
            }
        }


        internal ListBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.List)
		{
            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetList();
		}


      
        protected override void AfterAdd(DataRow dr)
        {
            appDB.ListRow lstr = (appDB.ListRow)dr;
            string ObjectName = this.myListDT.TableName;

            lstr.ListId = this.myA.PKIDGet(ObjectName, 1);
            lstr.ListNameEng = "New Distribution List";
            lstr.ListNameFre = "Nouvelle liste de distribution";
            lstr.SyncExchange = false;
            lstr.Type = 0;
        }
	}
}

