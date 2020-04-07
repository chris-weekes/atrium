using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class WritHistoryBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.WritHistoryDataTable myWritHistoryDT;
		
		internal WritHistoryBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.WritHistory)
		{
			myA=pBEMng;
			myWritHistoryDT=(CLAS.WritHistoryDataTable)myDT;
        }
        public atriumDAL.WritHistoryDAL myDAL
        {
            get
            {
                return (atriumDAL.WritHistoryDAL)myODAL;
            }
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.WritHistoryRow or = (CLAS.WritHistoryRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.WritHistory);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.WritHistoryRow fo = (CLAS.WritHistoryRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.WritHistory);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }


		protected override void AfterAdd(DataRow row)
		{
			CLAS.WritHistoryRow dr=(CLAS.WritHistoryRow)row;
			string ObjectName = this.myWritHistoryDT.TableName;

			dr.WritHistoryID = this.myA.AtMng.PKIDGet(ObjectName,1);            
		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			CLAS.WritHistoryRow dr=(CLAS.WritHistoryRow)ddr;
			switch(dc.ColumnName)
			{
				default:
					break;
			}
		}
	}
}

