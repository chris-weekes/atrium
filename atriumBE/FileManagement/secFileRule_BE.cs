using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
    /// 

    public enum ApplyTo
    {
        ThisFile,
        ThisFileAndChildFiles,
        ChildFiles
        
    }

	public class secFileRuleBE:atLogic.ObjectBE
	{
        FileManager myA;
		atriumDB.secFileRuleDataTable mysecFileRuleDT;

        static DateTime EndDateHack = new DateTime(2035, 12, 31);

		internal secFileRuleBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.secFileRule)
		{
			myA=pBEMng;
			mysecFileRuleDT=(atriumDB.secFileRuleDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetsecFileRule();

        }

        public atriumDAL.secFileRuleDAL myDAL
        {
            get
            {
                return (atriumDAL.secFileRuleDAL  )myODAL;
            }
        }

        public override bool CanAdd(DataRow parent)
        {
            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(myA.CurrentFileId, atSecurity.SecurityManager.Features.secFileRule) > atSecurity.SecurityManager.ExPermissions.No;
        }

        public override bool CanDelete(DataRow row)
        {
            atriumDB.secFileRuleRow dr = (atriumDB.secFileRuleRow)row;
            if (dr.Inherited)
                return false;
            else
                return AllowDelete || myA.AtMng.SecurityManager.CanDelete(dr.FileId, atSecurity.SecurityManager.Features.secFileRule) > atSecurity.SecurityManager.LevelPermissions.No;
        }

        public override bool CanEdit(DataRow row)
        {
            atriumDB.secFileRuleRow dr = (atriumDB.secFileRuleRow)row;
            if (dr.Inherited)
                return false;
            else
                return AllowEdit || myA.AtMng.SecurityManager.CanUpdate(dr.FileId, atSecurity.SecurityManager.Features.secFileRule) > atSecurity.SecurityManager.LevelPermissions.No;
        }

		public void LoadByFileId(int FileId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().secFileRuleLoadByFileId(FileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByFileId(FileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByFileId(FileId));
                }
            }
		}

        public override DataRow[] GetCurrentRow()
        { 
            return base.GetCurrentRow();
        }

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.secFileRuleRow dr = (atriumDB.secFileRuleRow)row;
            dr.ApplyTo = (int)ApplyTo.ThisFileAndChildFiles;
            dr.Disabled = false;
            dr.Inherited = false;
            dr.StartDate = DateTime.Today;
            dr.EndDate = EndDateHack;
            
        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {
            atriumDB.secFileRuleRow dr = (atriumDB.secFileRuleRow)row;

            switch(dc.ColumnName)
            {
                case "Inherited":
                    if (dr.RowState != DataRowState.Added & myA.IsFieldChanged(dc, dr))
                        throw new ReadOnlyException(dc.ColumnName);
                        break;
            }
        }

        protected override void AfterUpdate(DataRow row)
        {
            atriumDB.secFileRuleRow dr = (atriumDB.secFileRuleRow)row;
            if (dr.Id >= 0 & dr.Id<=20)
            {
                mysecFileRuleDT.RemovesecFileRuleRow(dr);
                mysecFileRuleDT.AcceptChanges();
            }

        }
	}
}

