using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.Collections.Generic;
using System.Linq;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class SSTCaseMatterBE : atLogic.ObjectBE
    {

        SSTManager myA;
        SST.SSTCaseMatterDataTable mySSTCaseMatterDT;

        internal SSTCaseMatterBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.SSTCaseMatter)
        {
            myA = pBEMng;
            mySSTCaseMatterDT = (SST.SSTCaseMatterDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetSSTCaseMatter();

        }

        public atriumDAL.SSTCaseMatterDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTCaseMatterDAL)myODAL;
            }
        }

        public SST.SSTCaseMatterRow Load(int SSTCaseMatterId)
        {

            try
            {
                Fill(myDAL.Load(SSTCaseMatterId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(SSTCaseMatterId));
            }

            return mySSTCaseMatterDT.FindBySSTCaseMatterId(SSTCaseMatterId);

        }

        public void LoadBySSTCaseId(int SSTCaseId)
        {

            try
            {
                Fill(myDAL.LoadBySSTCaseId(SSTCaseId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadBySSTCaseId(SSTCaseId));
            }

        }

        //TFS #59851 JLL: 2013-11-29. For sstcasematter control
        public override bool CanAdd(DataRow parent)
        {
            if (parent == null)
                return true;
            if (parent.RowState == DataRowState.Added)
                return true;
            else
            {
                SST.SSTCaseRow sstr = (SST.SSTCaseRow)parent;
                bool canAdd = myA.AtMng.SecurityManager.CanAdd(sstr.FileId, atSecurity.SecurityManager.Features.SSTCaseMAtter) > atSecurity.SecurityManager.ExPermissions.No;
                return canAdd;
            }
        }

        //TFS #59851 JLL: 2013-11-29. For sstcasematter control
        public override bool CanDelete(DataRow dr)
        {
            SST.SSTCaseMatterRow sstcmr = (SST.SSTCaseMatterRow)dr;
            bool canDelete = myA.AtMng.SecurityManager.CanDelete(sstcmr.FileId, atSecurity.SecurityManager.Features.SSTCaseMAtter) > atSecurity.SecurityManager.LevelPermissions.No;
            return canDelete;
        }
        
        protected override void AfterAdd(DataRow row)
        {

            SST.SSTCaseMatterRow dr = (SST.SSTCaseMatterRow)row;
            string ObjectName = this.mySSTCaseMatterDT.TableName;

            dr.SSTCaseMatterId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = myA.FM.CurrentFileId;
            dr.SSTCaseId = myA.DB.SSTCase[0].SSTCaseId; //WI 92073 - ensures SSTCaseId is set
            if (dr.SSTCaseRow!=null && !dr.SSTCaseRow.IsProgramIdNull())
                dr.ProgramId = dr.SSTCaseRow.ProgramId;
            //                dr.ConfirmedByMemberId = 0;
            dr.AcceptIssue = false;

        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {

            SST.SSTCaseMatterRow dr = (SST.SSTCaseMatterRow)row;

            switch (dc.ColumnName)
            {

                case "IssueId":
                    //set legislation
                    if (!dr.IsIssueIdNull())
                    {
                        appDB.IssueRow ir = myA.AtMng.DB.Issue.FindByIssueId(dr.IssueId);
                        if (!ir.IsLegProvisionIdNull())
                        {
                            dr.LegislationId = ir.LegProvisionId;
                            dr.EndEdit();
                        }
                    }
                    break;
            }

        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {

            SST.SSTCaseMatterRow dr = (SST.SSTCaseMatterRow)row;

            switch (dc.ColumnName)
            {

                case "IssueId":
                    if (dr.IsNull(dc))
                        throw new RequiredException(dc.ColumnName);
                    break;
                //TFS#56157 BY 2013-9-20
                case "OutcomeId":
                    SST.SSTCaseRow cr = dr.SSTCaseRow;
                    if (!cr.IsDecisionDateNull() && (dr.IsNull(dc)))
                        throw new RequiredException(dc.ColumnName);
                    break;
                case "AcceptIssue":
                    if (dr.IsAcceptIssueNull())
                        dr.AcceptIssue = false;
                    break;
            }

        }

        protected override void BeforeUpdate(DataRow row)
        {

            SST.SSTCaseMatterRow dr = (SST.SSTCaseMatterRow)row;
            BeforeChange(mySSTCaseMatterDT.IssueIdColumn, dr);

            //TFS#56157 BY 2013-9-20
            BeforeChange(mySSTCaseMatterDT.OutcomeIdColumn, dr);

            BeforeChange(mySSTCaseMatterDT.AcceptIssueColumn, dr);

            //add or update filexref for issue
            if (!dr.IsIssueIdNull())
            {
                appDB.IssueRow ir = myA.AtMng.DB.Issue.FindByIssueId(dr.IssueId);

                if (dr.RowState == DataRowState.Added && !ir.IsFileIdNull())
                {
                    if (!XrefExists(ir.FileId))
                    {
                        atriumDB.FileXRefRow fxr = (atriumDB.FileXRefRow)myA.FM.GetFileXRef().Add(myA.FM.CurrentFile);

                        fxr.LinkType = 1;
                        fxr.OtherFileId = ir.FileId;
                        fxr.Rollup = false;
                        fxr.FullFileNumber = myA.FM.EFile.Load(ir.FileId, false).FullFileNumber;
                    }
                }
                else if (myA.IsFieldChanged(mySSTCaseMatterDT.IssueIdColumn, dr))
                {
                    int origIssueId = (int)dr[mySSTCaseMatterDT.IssueIdColumn, DataRowVersion.Original];
                    appDB.IssueRow origIr = myA.AtMng.DB.Issue.FindByIssueId(origIssueId);

                    var fxrq = from f in myA.FM.DB.FileXRef
                               where f.OtherFileId == origIr.FileId & f.LinkType == 1
                               select f;

                    if (fxrq.Count() > 0) // if false, no issue found.
                    {

                        atriumDB.FileXRefRow fxr = fxrq.Single();
                        if (ir.IsFileIdNull())
                            fxr.Delete();
                        else
                        {
                            if (XrefExists(ir.FileId))
                                fxr.Delete();
                            else
                            {
                                //check 
                                List<int> files = new List<int>();
                                foreach (SST.SSTCaseMatterRow scmr in mySSTCaseMatterDT)
                                {
                                    if (!scmr.IsIssueIdNull() && scmr.SSTCaseMatterId != dr.SSTCaseMatterId)
                                    {
                                        appDB.IssueRow ir1 = myA.AtMng.DB.Issue.FindByIssueId(scmr.IssueId);
                                        if (!ir1.IsFileIdNull())
                                        {
                                            files.Add(ir1.FileId);
                                        }
                                    }
                                }
                                if (files.Contains(fxr.OtherFileId))
                                {
                                    //another issue uses that xref so add a new xref and don't change the current one
                                    atriumDB.FileXRefRow fxr1 = (atriumDB.FileXRefRow)myA.FM.GetFileXRef().Add(myA.FM.CurrentFile);

                                    fxr1.LinkType = 1;
                                    fxr1.OtherFileId = ir.FileId;
                                    fxr1.Rollup = false;
                                    fxr1.FullFileNumber = myA.FM.EFile.Load(ir.FileId, false).FullFileNumber;
                                }
                                else
                                {
                                    fxr.OtherFileId = ir.FileId;
                                }
                            }
                        }
                    }
                    else // no issue found, so no xref to update; add a new xref.
                    {
                        atriumDB.FileXRefRow fxr1 = (atriumDB.FileXRefRow)myA.FM.GetFileXRef().Add(myA.FM.CurrentFile);

                        fxr1.LinkType = 1;
                        fxr1.OtherFileId = ir.FileId;
                        fxr1.Rollup = false;
                        fxr1.FullFileNumber = myA.FM.EFile.Load(ir.FileId, false).FullFileNumber;
                    }
                }
            }
        }

        private bool XrefExists(int otherFileId)
        {
            var fxrTest = from f in myA.FM.DB.FileXRef
                          where f.OtherFileId == otherFileId & f.LinkType == 1
                          select f;
            return fxrTest.Count() > 0;
        }

        public override DataRow[] GetCurrentRow() { return mySSTCaseMatterDT.Select(); }

        public override string FriendlyName() { return mySSTCaseMatterDT.TableName; }

        public override string PromptColumnName() { return ""; }

        public override string PromptFormat() { return ""; }

    }

}