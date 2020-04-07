using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class BankruptcyAccountBE : atLogic.ObjectBE
    {
        CLASManager myA;
        CLAS.BankruptcyAccountDataTable myBankruptcyAccountDT;


        internal BankruptcyAccountBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.BankruptcyAccount)
        {
            myA = pBEMng;
            myBankruptcyAccountDT = (CLAS.BankruptcyAccountDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetBankruptcyAccount();

        }

        public atriumDAL.BankruptcyAccountDAL myDAL
        {
            get
            {
                return (atriumDAL.BankruptcyAccountDAL)myODAL;
            }
        }

        protected override void AfterAdd(DataRow dr)
        {
            CLAS.BankruptcyAccountRow abf = (CLAS.BankruptcyAccountRow)dr;
            string ObjectName = this.myDT.TableName;

            abf.BAId = this.myA.AtMng.PKIDGet(ObjectName, 1);
            abf.FileId = myA.FM.CurrentFileId;

        }

        protected override void BeforeUpdate(DataRow ddr)
        {
            CLAS.BankruptcyAccountRow dr = (CLAS.BankruptcyAccountRow)ddr;
            if (dr.RowState == DataRowState.Added && !dr.Include)
                dr.Delete();
        }

        public override DataRow[] GetCurrentRow()
        {
            DataRow[] dr = base.GetCurrentRow();
            if (dr == null)
                return myBankruptcyAccountDT.Select("Fileid=" + myA.FM.CurrentFileId.ToString());
            else
                return this.myBankruptcyAccountDT.Select();
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
            CLAS.BankruptcyAccountRow ahr = myBankruptcyAccountDT.FindByBAId(id);
            System.Collections.Generic.List<int> l = new System.Collections.Generic.List<int>();
            l.Add(ahr.FileAccountID);
            return l;
        }
    }
}

