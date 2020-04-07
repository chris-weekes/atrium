using System;
using System.Collections.Generic;
using System.Text;
using atLogic;
using System.Data;
using lmDatasets;

namespace atriumBE
{
    public class SSTManager : atLogic.BEManager
    {
        FileManager myFM;

        public FileManager FM
        {
            get { return myFM; }
            set { myFM = value; }
        }

        private atriumManager myAtMng;
        public atriumManager AtMng
        {
            get { return myAtMng; }
            set { myAtMng = value; }
        }

        internal SSTManager(FileManager fm)
            : base(fm.AppMan)
        {
            CurrentFileId = fm.CurrentFileId;
            Init(fm);

            if (!fm.IsVirtualFM && fm.CurrentFile != null)
            {
                if (fm.CurrentFile.RowState != DataRowState.Added)
                    LoadAll(false);
            }
        }

        private void Init(FileManager fm)
        {
            base.DAL = fm.DALMngr;
            myFM = fm;
            myAtMng = fm.AtMng;
            RuleHandler = fm.RuleHandler;
            MyDS = new SST();
            MyDS.EnforceConstraints = false;

            FixTZDSIssue(MyDS);
        }

        public static void FixTZDSIssue(DataSet myDS)
        {
           
            foreach (DataTable table in myDS.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        column.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
            }
        }

        public override void Update(BusinessProcess BP)
        {
            
            BP.AddForUpdate(DB.DocTransfer);
            BP.AddForUpdate(DB.DocDump,"Document");
            BP.AddForUpdate(DB.SSTCase);
            BP.AddForUpdate(DB.SSTGroup);
            BP.AddForUpdate(DB.SSTDecision);
            BP.AddForUpdate(DB.SSTRequest);
            BP.AddForUpdate(DB.SSTReqRecipient);
            BP.AddForUpdate(DB.SSTCaseMatter);
            BP.AddForUpdate(DB.SSTAppealGround); // WI 75221
            BP.AddForUpdate(DB.FileParty);
            BP.AddForUpdate(DB.Hearing);
            BP.AddForUpdate(DB.ADMSEAppeal);
            BP.AddForUpdate(DB.ADMSEDecision);
            BP.AddForUpdate(DB.ADMSEIssues);
            BP.AddForUpdate(DB.ADMSEParticipant);
            BP.AddForUpdate(DB.ADMSPAppeal);
            BP.AddForUpdate(DB.ADMSPDecision);
            BP.AddForUpdate(DB.ADMSPIssues);
            BP.AddForUpdate(DB.ADMSPParticipant);
            BP.AddForUpdate(DB.FormHearing);
        }

        public override void LoadAll(bool refresh)
        {
            if (refresh)
            {
                GetSSTCase().PreRefresh();
                GetSSTGroup().PreRefresh();
                GetSSTDecision().PreRefresh();
                GetSSTRequest().PreRefresh();
                GetSSTReqRecipient().PreRefresh();
                GetSSTCaseMatter().PreRefresh();
                GetSSTAppealGround().PreRefresh(); // WI 75221
                GetFileParty().PreRefresh();
                GetHearing().PreRefresh();
                GetFormHearing().PreRefresh();

            }


            DataSet ds;

            try
            {
                ds = BEManager.DecompressDataSet(GetSSTCase().myDAL.LoadAll(myFM.CurrentFileId),new SST());
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                GetSSTCase().RecoverDAL();
                ds = BEManager.DecompressDataSet(GetSSTCase().myDAL.LoadAll(myFM.CurrentFileId),new SST());
            }

            GetSSTCase().Fill(ds.Tables["SSTCase"]);
            GetSSTCase().CalcDates();

            GetSSTGroup().Fill(ds.Tables["SSTGroup"]);
            GetSSTDecision().Fill(ds.Tables["SSTDecision"]);
            GetSSTRequest().Fill(ds.Tables["SSTRequest"]);
            GetSSTReqRecipient().Fill(ds.Tables["SSTReqRecipient"]);
            GetSSTCaseMatter().Fill(ds.Tables["SSTCaseMatter"]);
            GetSSTAppealGround().Fill(ds.Tables["SSTAppealGround"]); // WI 75221
            GetFileParty().Fill(ds.Tables["FileParty"]);
            GetFileParty().CalcRecipType();
            GetHearing().Fill(ds.Tables["Hearing"]);
            GetFormHearing().Fill(ds.Tables["FormHearing"]);

            ds.Clear();
            ds.Dispose();
        }

        public SST DB
        {
            get
            {
                return (SST)MyDS;
            }
        }
 
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myAtMng.DALMngr;
            }
        }

        private SSTDecisionBE mySSTDecision;
        public SSTDecisionBE GetSSTDecision()
        {

            if (mySSTDecision == null)
            {
                mySSTDecision = new SSTDecisionBE(this);
            }

            return mySSTDecision;
        }

        private SSTRequestBE mySSTRequest;
        public SSTRequestBE GetSSTRequest()
        {

            if (mySSTRequest == null)
            {
                mySSTRequest = new SSTRequestBE(this);
            }

            return mySSTRequest;
        }

        private SSTReqRecipientBE mySSTReqRecipient;
        public SSTReqRecipientBE GetSSTReqRecipient()
        {

            if (mySSTReqRecipient == null)
            {
                mySSTReqRecipient = new SSTReqRecipientBE(this);
            }

            return mySSTReqRecipient;
        }

        private DocDumpBE myDocDump;
        public DocDumpBE GetDocDump()
        {

            if (myDocDump == null)
            {
                myDocDump = new DocDumpBE(this);
            }

            return myDocDump;
        }

        private DocTransferBE myDocTransfer;
        public DocTransferBE GetDocTransfer()
        {

            if (myDocTransfer == null)
            {
                myDocTransfer = new DocTransferBE(this);
            }

            return myDocTransfer;
        }

        private HearingBE myHearing;
        public HearingBE GetHearing()
        {

            if (myHearing == null)
            {
                myHearing = new HearingBE(this);
            }

            return myHearing;
        }

        private ADMSLookupBE myADMSLookup;
        public ADMSLookupBE GetADMSLookup()
        {

            if (myADMSLookup == null)
            {
                myADMSLookup = new ADMSLookupBE(this);
            }

            return myADMSLookup;
        }

        private ADMSEAppealBE myADMSEAppeal;
        public ADMSEAppealBE GetADMSEAppeal()
        {

            if (myADMSEAppeal == null)
            {
                myADMSEAppeal = new ADMSEAppealBE(this);
            }

            return myADMSEAppeal;
        }

        private ADMSEDecisionBE myADMSEDecision;
        public ADMSEDecisionBE GetADMSEDecision()
        {

            if (myADMSEDecision == null)
            {
                myADMSEDecision = new ADMSEDecisionBE(this);
            }

            return myADMSEDecision;
        }

        private ADMSEIssuesBE myADMSEIssues;
        public ADMSEIssuesBE GetADMSEIssues()
        {

            if (myADMSEIssues == null)
            {
                myADMSEIssues = new ADMSEIssuesBE(this);
            }

            return myADMSEIssues;
        }

        private ADMSEParticipantBE myADMSEParticipant;
        public ADMSEParticipantBE GetADMSEParticipant()
        {

            if (myADMSEParticipant == null)
            {
                myADMSEParticipant = new ADMSEParticipantBE(this);
            }

            return myADMSEParticipant;
        }

        private ADMSPAppealBE myADMSPAppeal;
        public ADMSPAppealBE GetADMSPAppeal()
        {

            if (myADMSPAppeal == null)
            {
                myADMSPAppeal = new ADMSPAppealBE(this);
            }

            return myADMSPAppeal;
        }

        private ADMSPDecisionBE myADMSPDecision;
        public ADMSPDecisionBE GetADMSPDecision()
        {

            if (myADMSPDecision == null)
            {
                myADMSPDecision = new ADMSPDecisionBE(this);
            }

            return myADMSPDecision;
        }

        private ADMSPIssuesBE myADMSPIssues;
        public ADMSPIssuesBE GetADMSPIssues()
        {

            if (myADMSPIssues == null)
            {
                myADMSPIssues = new ADMSPIssuesBE(this);
            }

            return myADMSPIssues;
        }

        private ADMSPParticipantBE myADMSPParticipant;
        public ADMSPParticipantBE GetADMSPParticipant()
        {

            if (myADMSPParticipant == null)
            {
                myADMSPParticipant = new ADMSPParticipantBE(this);
            }

            return myADMSPParticipant;
        }

        private SSTGroupBE mySSTGroup;
        public SSTGroupBE GetSSTGroup()
        {

            if (mySSTGroup == null)
            {
                mySSTGroup = new SSTGroupBE(this);
            }

            return mySSTGroup;
        }


        private FormHearingBE myFormHearing;
        public FormHearingBE GetFormHearing()
        {

            if (myFormHearing == null)
            {
                myFormHearing = new FormHearingBE(this);
            }

            return myFormHearing;
        }

        private SSTCaseBE mySSTCase;
        public SSTCaseBE GetSSTCase()
        {

            if (mySSTCase == null)
            {
                mySSTCase = new SSTCaseBE(this);
            }

            return mySSTCase;
        }

        private SSTCaseMatterBE mySSTCaseMatter;
        public SSTCaseMatterBE GetSSTCaseMatter()
        {

            if (mySSTCaseMatter == null)
            {
                mySSTCaseMatter = new SSTCaseMatterBE(this);
            }

            return mySSTCaseMatter;
        }

        private SSTAppealGroundBE mySSTAppealGround;
        public SSTAppealGroundBE GetSSTAppealGround() // WI 75221
        {

            if (mySSTAppealGround == null)
            {
                mySSTAppealGround = new SSTAppealGroundBE(this);
            }

            return mySSTAppealGround;
        }

        private FilePartyBE myFileParty;
        public FilePartyBE GetFileParty()
        {

            if (myFileParty == null)
            {
                myFileParty = new FilePartyBE(this);
            }

            return myFileParty;
        }
    }

}