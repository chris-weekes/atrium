using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class OfficeAccountBE:atLogic.ObjectBE
	{
        CLASManager myA;
		CLAS.OfficeAccountDataTable myOfficeAccountDT;

        //FileManager myFM;
        internal OfficeAccountBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.OfficeAccount)
		{
			myA=pBEMng;
            myOfficeAccountDT = (CLAS.OfficeAccountDataTable)myDT;

			this.myOfficeAccountDT.AmountColumn.ExtendedProperties.Add("format","C");
			this.myOfficeAccountDT.CreditColumn.ExtendedProperties.Add("format","C");
			this.myOfficeAccountDT.DebitColumn.ExtendedProperties.Add("format","C");
			this.myOfficeAccountDT.BalanceColumn.ExtendedProperties.Add("format","C");

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOfficeAccount();
        }
        public atriumDAL.OfficeAccountDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficeAccountDAL)myODAL;
            }
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.OfficeAccountRow r = (CLAS.OfficeAccountRow)dr;
            EFileBE.XmlAddToc(myA.AtMng.GetFile(r.FileId).CurrentFile, "officeaccount", "Acomptes de bureau", "Office Account", 180);

        }

		public void LoadByFileId(int fileId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficeAccountLoadByFileId(fileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByFileID(fileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByFileID(fileId));
                }
            }
		}

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myOfficeAccountDT.TableName;
            CLAS.OfficeAccountRow dr = (CLAS.OfficeAccountRow)ddr;
			switch(dc.ColumnName)
			{
				default:
					break;
			}


			
		}
		protected override void AfterAdd(DataRow row)
		{
            CLAS.OfficeAccountRow dr = (CLAS.OfficeAccountRow)row;
			string ObjectName = this.myOfficeAccountDT.TableName;
			
			dr.OfficeAccountID = this.myA.AtMng.PKIDGet(ObjectName,1);
			dr.FileId=myA.FM.CurrentFile.FileId;
			dr.TransactionDate = DateTime.Today;
			dr.PostingDate = DateTime.Now;
			dr.Amount = 0;

            dr.OfficeID = myA.FM.CurrentFile.LeadOfficeId;

		}


		public decimal BalanceOn(DateTime statementDate)
		{
			DataRow[] drs=this.myOfficeAccountDT.Select("TransactionDate<='"+statementDate.ToLongDateString()+"'");
			if(drs.Length==0)
				return 0;
			else
				return (decimal)drs[drs.Length-1]["Balance"];
		}

       
        public override DataRow[] GetCurrentRow()
        {
           
                return this.myOfficeAccountDT.Select();
        }

        public override bool CanAdd(DataRow parent)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)parent;

            bool isOwner = false;
            if (!er.IsNull("OwnerOfficeId") && er.OwnerOfficeId == myA.AtMng.WorkingAsOfficer.OfficeId)
                isOwner = true;

            //JLL sysadmin hack
            if (myA.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                return true;

            if (!isOwner)
                return false;
            else
                return myA.AtMng.SecurityManager.CanAdd(er.FileId, atSecurity.SecurityManager.Features.OfficeAccount) > atSecurity.SecurityManager.ExPermissions.No;

        }

        public override bool CanEdit(DataRow dr)
        {
            atriumDB.EFileRow er = myA.FM.CurrentFile;

            bool isOwner = false;
            if (!er.IsNull("OwnerOfficeId") && er.OwnerOfficeId == myA.AtMng.WorkingAsOfficer.OfficeId)
                isOwner = true;

            //JLL sysadmin hack
            if (myA.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                return true;

            if (!isOwner)
                return false;
            else
                return myA.AtMng.SecurityManager.CanUpdate(er.FileId, atSecurity.SecurityManager.Features.OfficeAccount) != atSecurity.SecurityManager.LevelPermissions.No;

        }

        public override bool CanDelete(DataRow dr)
        {
            atriumDB.EFileRow er = myA.FM.CurrentFile;

            bool isOwner = false;
            if (!er.IsNull("OwnerOfficeId") && er.OwnerOfficeId == myA.AtMng.WorkingAsOfficer.OfficeId)
                isOwner = true;

            if (!isOwner)
                return false;
            else
                return myA.AtMng.SecurityManager.CanDelete(er.FileId, atSecurity.SecurityManager.Features.OfficeAccount) == atSecurity.SecurityManager.LevelPermissions.All;
            
        }

	}
}

