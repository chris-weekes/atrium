using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class InsolvencyAccountBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.InsolvencyAccountDataTable myInsolvencyAccountDT;
	 
		
		internal InsolvencyAccountBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.InsolvencyAccount)
		{
			myA=pBEMng;
			myInsolvencyAccountDT=(CLAS.InsolvencyAccountDataTable)myDT;
	
		}
        
        public atriumDAL.InsolvencyAccountDAL myDAL
        {
            get
            {
                return (atriumDAL.InsolvencyAccountDAL)myODAL;
            }
        }


        protected override void AfterAdd(DataRow dr)
        {
            CLAS.InsolvencyAccountRow    abf = (CLAS.InsolvencyAccountRow)dr;
            string ObjectName = this.myDT.TableName;

            abf.IAId = this.myA.AtMng.PKIDGet(ObjectName, 1);
            abf.FileId = myA.FM.CurrentFileId;
           
        }

        protected override void BeforeUpdate(DataRow ddr)
        {
            CLAS.InsolvencyAccountRow dr = (CLAS.InsolvencyAccountRow)ddr;
            if (dr.RowState == DataRowState.Added && !dr.Include)
                dr.Delete();
        }

        public override DataRow[] GetCurrentRow()
        {
          
                return this.myInsolvencyAccountDT.Select();
        }


        public override string PromptColumnName()
        {
            return "FileAccountId"; ;
        }

        public override string PromptFormat()
        {
            return "{0}";
        }

        public override string FriendlyName()
        {
            return "Account";
        }

        public override System.Collections.Generic.List<int> Accounts(int id)
        {
            CLAS.InsolvencyAccountRow ahr = myInsolvencyAccountDT.FindByIAId(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
            l.Add(ahr.FileAccountID);
            return l;
        }

	}
}

