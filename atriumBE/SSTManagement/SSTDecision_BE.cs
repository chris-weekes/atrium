using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class SSTDecisionBE : atLogic.ObjectBE
    {
        SSTManager myA;
        SST.SSTDecisionDataTable mySSTDecisionDT;


        internal SSTDecisionBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.SSTDecision)
        {
            myA = pBEMng;
            mySSTDecisionDT = (SST.SSTDecisionDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetSSTDecision();

        }

        public override bool CanDelete(DataRow dr)
        {
            if (myA.AtMng.SecurityManager.CanDelete(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.SSTDecision) == atSecurity.SecurityManager.LevelPermissions.All)
                return true;
            else
                return false;
        }

        public atriumDAL.SSTDecisionDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTDecisionDAL)myODAL;
            }
        }

        public SST.SSTDecisionRow Load(int SSTDecisionId)
        {
            try
            {
                Fill(myDAL.Load(SSTDecisionId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(SSTDecisionId));
            }

            return mySSTDecisionDT.FindBySSTDecisionId(SSTDecisionId);
        }


        public void LoadByFileId(int FileId)
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



        public void LoadByMemberId(int MemberId)
        {
            try
            {
                Fill(myDAL.LoadByMemberId(MemberId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByMemberId(MemberId));
            }
        }



        public void LoadByOutcomeId(int OutcomeId)
        {
            try
            {
                Fill(myDAL.LoadByOutcomeId(OutcomeId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByOutcomeId(OutcomeId));
            }
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

        protected override void BeforeChange(DataColumn dc, DataRow dr)
        {
            SST.SSTDecisionRow sdr = (SST.SSTDecisionRow)dr;
            switch (dc.ColumnName)
            {
                case "IsCombined":
                    if(sdr.IsCombined)
                    {
                        //must be "allowed"
                        if (!sdr.IsOutcomeIdNull() && sdr.OutcomeId==10 && sdr.DecisionType==4)
                        {
                            throw new AtriumException(Properties.Resources.SSTDecisionIsCombined);
                        }
                    }
                    break;
                case "DecisionDate":
                    if (!sdr.IsDecisionDateNull())
                        myA.IsValidDate(dc.ColumnName, sdr.DecisionDate, true, sdr.SSTCaseRow.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "DecisionSentDate":
                    if (!sdr.IsDecisionSentDateNull())
                        myA.IsValidDate(dc.ColumnName, sdr.DecisionSentDate, true, sdr.SSTCaseRow.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "DecisionType":
                    if (!sdr.IsNull(dc))
                    {
                        CodesDB.DecisionTypeRow dtr = myA.AtMng.CodeDB.DecisionType.FindByDecisionTypeId(sdr.DecisionType);
                        if (dtr.OncePerFile)
                        {
                            //check to see if there is already a design of this type
                            foreach (SST.SSTDecisionRow xsdr in mySSTDecisionDT)
                            {
                                if (xsdr.SSTDecisionId != sdr.SSTDecisionId && xsdr.DecisionType == sdr.DecisionType)
                                {
                                    string msg = String.Format(atriumBE.Properties.Resources.SSTDecisionTypeDup, dtr["DecType" + myA.AppMan.Language].ToString());
                                    myA.FM.RaiseWarning(WarningLevel.Interrupt, msg, myA.AtMng.AppMan.AppName);
                                }
                            }
                        }
                    }
                    else
                        throw new RequiredException(dc.ColumnName);
                    break;
                case "OutcomeId":
                    if (!sdr.IsOutcomeIdNull())
                    {
                        CodesDB.OutcomeRow orr = myA.AtMng.CodeDB.Outcome.FindByOutcomeId(sdr.OutcomeId);
                        if (orr.DecisionType != sdr.DecisionType)
                            throw new AtriumException("Not a valid outcome for this decision type");
                    }
                    break;
            }
        }

        public override string PromptColumnName()
        {

            return "RecDate,AssignedDate,DecisionDate";
        }


        protected override void AfterAdd(DataRow row)
        {
            SST.SSTDecisionRow dr = (SST.SSTDecisionRow)row;
            string ObjectName = this.mySSTDecisionDT.TableName;

            dr.SSTCaseId = myA.DB.SSTCase[0].SSTCaseId;
            dr.SSTDecisionId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.IsFinal = false;
            dr.FileId = myA.FM.CurrentFileId;
            dr.IsCombined = false;
        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            SST.SSTDecisionRow sdr = (SST.SSTDecisionRow)dr;
            switch (dc.ColumnName)
            {
                case "OutcomeId":
                case "DecisionDate":
                    if (sdr.DecisionType == 3 && !sdr.IsDecisionDateNull())
                    {
                        SST.SSTCaseRow scr = myA.DB.SSTCase.FindBySSTCaseId(sdr.SSTCaseId);
                        scr.Received365Date = sdr.DecisionDate.AddDays(365);
                        scr.EndEdit();
                    }
                    if (!sdr.IsOutcomeIdNull())
                    {
                        CodesDB.OutcomeRow orr = myA.AtMng.CodeDB.Outcome.FindByOutcomeId(sdr.OutcomeId);
                        sdr.IsFinal = orr.IsFinal;
                    }
                    break;
            }
        }

        public override DataRow[] GetCurrentRow()
        {

            return mySSTDecisionDT.Select("DecisionSentDate is null");
        }

        protected override void BeforeUpdate(DataRow dr)
        {
            SST.SSTDecisionRow sdr = (SST.SSTDecisionRow)dr;
            if (sdr.IsFinal)
            {
                SST.SSTCaseRow scr = sdr.SSTCaseRow;
                if (!sdr.IsDecisionDateNull())
                    scr.DecisionDate = sdr.DecisionDate;
                if (!sdr.IsDecisionSentDateNull())
                    scr.DecisionSentDate = sdr.DecisionSentDate;
                if (!sdr.IsOutcomeIdNull())
                    scr.OutcomeId = sdr.OutcomeId;

                scr.DecisionType = sdr.DecisionType;


            }
            BeforeChange("IsCombined", dr);
        }

        protected override void AfterUpdate(DataRow row)
        {
            SST.SSTDecisionRow dr = (SST.SSTDecisionRow)row;
            EFileBE.XmlAddToc(myA.FM.CurrentFile, "sstdecision", "Tribunal Member Decisions", "Décisions de Membre du Tribunal", 112);
        }
    }
}

