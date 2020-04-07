using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using lmDatasets;
using atLogic;
using atriumBE.Properties;

namespace atriumBE
{
    public class FileManager : atLogic.BEManager
    {

        int bfListOfficerId = 0;
        bool needsRefresh = false;


        DateTime lastFileRefresh = DateTime.Now.AddSeconds(-60000);
        DateTime lastActivityRefresh = DateTime.Now.AddSeconds(-60000);

        public bool NeedsRefresh
        {
            get
            {
                if (needsRefresh)
                {
                    int delay = -AtMng.GetSetting(AppIntSetting.FileReloadInterval);
                    if (DateTime.Now.AddSeconds(delay).CompareTo(lastFileRefresh) > 0)
                        return true;
                    else
                        return false;
                }
                else
                    return false;

            }
            set { needsRefresh = value; }
        }

        public int BfListOfficerId
        {
            get { return bfListOfficerId; }
            set { bfListOfficerId = value; }
        }





        internal FileManager ParentFile = null;
        public FileManager SourceFile = null;

        bool isVirtualFM = false;
        bool isFileNumberAssigned = false;

        public bool IsFileNumberAssigned
        {
            get { return isFileNumberAssigned; }
            set { isFileNumberAssigned = value; }
        }

        public bool IsVirtualFM
        {
            get { return isVirtualFM; }
            set { isVirtualFM = value; }
        }

        public System.Collections.Generic.Dictionary<string, DataTable> MyColCodes
        {
            get { return myatMng.myColCodes; }
        }

        private OfficeManager myLeadOfficeMng;

        public OfficeManager LeadOfficeMng
        {
            get
            {
                if (CurrentFile != null)
                {
                    LeadOfficeMng = myatMng.GetOffice(CurrentFile.LeadOfficeId);
                }
                return myLeadOfficeMng;
            }
            set
            {
                myLeadOfficeMng = value;
                if (!myMngrs.ContainsKey(myLeadOfficeMng.DB.DataSetName))
                    myMngrs.Add(myLeadOfficeMng.DB.DataSetName, myLeadOfficeMng);
            }
        }

        private ActivityBP rfbp;

        atriumManager myatMng;
        public atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        private ApptRecurrenceBE myApptRecurrence;
        public ApptRecurrenceBE GetApptRecurrence()
        {
            if (myApptRecurrence == null)
            {
                myApptRecurrence = new ApptRecurrenceBE(this);
            }
            return myApptRecurrence;
        }

        private FileFlagBE myFileFlag;
        public FileFlagBE GetFileFlag()
        {
            if (myFileFlag == null)
            {
                myFileFlag = new FileFlagBE(this);
            }
            return myFileFlag;
        }

        private ProcessContextBE myProcessContext;
        public ProcessContextBE GetProcessContext()
        {
            if (myProcessContext == null)
            {
                myProcessContext = new ProcessContextBE(this);
            }
            return myProcessContext;
        }

        private AppointmentBE myAppointment;
        public AppointmentBE GetAppointment()
        {
            if (myAppointment == null)
            {
                myAppointment = new AppointmentBE(this);
            }
            return myAppointment;
        }

        private AttendeeBE myAttendee;
        public AttendeeBE GetAttendee()
        {
            if (myAttendee == null)
            {
                myAttendee = new AttendeeBE(this);
            }
            return myAttendee;
        }

        private FileAccessBE myFileAccess;
        public FileAccessBE GetFileAccess()
        {
            if (myFileAccess == null)
            {
                myFileAccess = new FileAccessBE(this);
            }
            return myFileAccess;
        }

        private FileXRefBE myFileXRef;
        public FileXRefBE GetFileXRef()
        {
            if (myFileXRef == null)
            {
                myFileXRef = new FileXRefBE(this);
            }
            return myFileXRef;
        }

        private ProcessBE myProcess;
        public ProcessBE GetProcess()
        {
            if (myProcess == null)
            {
                myProcess = new ProcessBE(this);
            }
            return myProcess;
        }

        private ActivityBE myActivity;
        public ActivityBE GetActivity()
        {
            if (myActivity == null)
            {
                myActivity = new ActivityBE(this);
            }
            return myActivity;
        }

        private Dictionary<string, ddEntityBE> myddEntity = new Dictionary<string, ddEntityBE>();


        public ddEntityBE GetddEntity(string entityName)
        {

            if (!myddEntity.ContainsKey(entityName))
            {
                ddEntityBE d = new ddEntityBE(this, entityName);
                myddEntity.Add(entityName, d);

            }
            return myddEntity[entityName];
        }

        private ActivityBFBE myActivityBF;
        public ActivityBFBE GetActivityBF()
        {
            if (myActivityBF == null)
            {
                myActivityBF = new ActivityBFBE(this);
            }
            return myActivityBF;
        }

        private ActivityTimeBE myActivityTime;
        public ActivityTimeBE GetActivityTime()
        {
            if (myActivityTime == null)
            {
                myActivityTime = new ActivityTimeBE(this);
            }
            return myActivityTime;
        }

        private AddressBE myAddress;
        public AddressBE GetAddress()
        {
            if (myAddress == null)
            {
                myAddress = new AddressBE(this);
            }
            return myAddress;
        }

        private FileAKABE myFileAKA;
        public FileAKABE GetFileAKA()
        {
            if (myFileAKA == null)
            {
                myFileAKA = new FileAKABE(this);
            }
            return myFileAKA;
        }

        private ArchiveBatchBE myArchiveBatch;
        public ArchiveBatchBE GetArchiveBatch()
        {
            if (myArchiveBatch == null)
            {
                myArchiveBatch = new ArchiveBatchBE(this);
            }
            return myArchiveBatch;
        }

        private AKABE myAKA;
        public AKABE GetAKA()
        {
            if (myAKA == null)
            {
                myAKA = new AKABE(this);
            }
            return myAKA;
        }

        private PersonBE myPerson;
        public PersonBE GetPerson()
        {
            if (myPerson == null)
            {
                myPerson = new PersonBE(this);
            }
            return myPerson;
        }

        private DisbursementBE myDisbursement;
        public DisbursementBE GetDisbursement()
        {
            if (myDisbursement == null)
            {
                myDisbursement = new DisbursementBE(this);
            }
            return myDisbursement;
        }

        public EFileBE EFile
        {
            get
            {
                if (myBEs.ContainsKey("EFile"))
                    return (EFileBE)myBEs["EFile"];
                else
                    return new EFileBE(this);
            }
        }

        private FileContactBE myFileContact;
        public FileContactBE GetFileContact()
        {
            if (myFileContact == null)
            {
                myFileContact = new FileContactBE(this);
            }
            return myFileContact;
        }

        private FileOfficeBE myFileOffice;
        public FileOfficeBE GetFileOffice()
        {
            if (myFileOffice == null)
            {
                myFileOffice = new FileOfficeBE(this);
            }
            return myFileOffice;
        }

        private ActivityXRefBE myActivityXRef;
        public ActivityXRefBE GetActivityXRef()
        {
            if (myActivityXRef == null)
            {
                myActivityXRef = new ActivityXRefBE(this);
            }
            return myActivityXRef;
        }

        private secFileRuleBE mySecFileRule;
        public secFileRuleBE GetsecFileRule()
        {
            if (mySecFileRule == null)
            {
                mySecFileRule = new secFileRuleBE(this);
            }
            return mySecFileRule;
        }

        private RiskAssessmentBE myRiskAssessment;
        public RiskAssessmentBE GetRiskAssessment()
        {
            if (myRiskAssessment == null)
            {
                myRiskAssessment = new RiskAssessmentBE(this);
            }
            return myRiskAssessment;
        }

        private RAClientImpactBE myRAClientImpact;
        public RAClientImpactBE GetRAClientImpact()
        {
            if (myRAClientImpact == null)
            {
                myRAClientImpact = new RAClientImpactBE(this);
            }
            return myRAClientImpact;
        }

        private SRPBE mySRP;
        public SRPBE GetSRP()
        {
            if (mySRP == null)
            {
                mySRP = new SRPBE(this);
            }
            return mySRP;
        }

        private IRPBE myIRP;
        public IRPBE GetIRP()
        {
            if (myIRP == null)
            {
                myIRP = new IRPBE(this);
            }
            return myIRP;
        }

        public FileManager(atriumManager atMng, FileManager parentFile)
            : base(atMng.AppMan)
        {
            Init(atMng);

            myCurrentFileId = CreateFile(parentFile).FileId;
            LeadOfficeMng = myatMng.GetOffice(CurrentFile.LeadOfficeId);

            //create dd entities
            LoadDDEntities(null);
        }

        public FileManager(atriumManager atMng, int fileId)
            : base(atMng.AppMan)
        {
            Init(atMng);

            myCurrentFileId = fileId;
            LoadAll(false);

            if (CurrentFile == null)
                throw new AtriumException("Could not load file");

            //if (this.CurrentFile.IsFileStructXmlNull())
            //{
            //    this.CurrentFile.FileStructXml = EFile.CalcFileStructXml(this.CurrentFile, true, false).OuterXml;
            //    this.CurrentFile.AcceptChanges();
            //}

        }

        //TFS#54344 CJW 2013-8-21
        //new mthod clears data before loading when refreshing
        public override void LoadAll(bool refresh)
        {
            int delay = -AtMng.GetSetting(AppIntSetting.FileReloadInterval);

            if (refresh)
            {
                lastFileRefresh = DateTime.Now.AddSeconds(delay - 60);
                GetFileContact().PreRefresh();
                GetPerson().PreRefresh();
                GetFileOffice().PreRefresh();
                GetFileXRef().PreRefresh();
                GetFileAKA().PreRefresh();
                GetAppointment().PreRefresh();
                GetAppointment().SetLocalDates();
                GetApptRecurrence().PreRefresh();
                GetAttendee().PreRefresh();
                GetAddress().PreRefresh();
                GetsecFileRule().PreRefresh();
                GetFileFlag().PreRefresh();

                GetIRP().PreRefresh();
                GetRiskAssessment().PreRefresh();
                GetAKA().PreRefresh();
                GetArchiveBatch().PreRefresh();

                foreach (ddEntityBE d in myddEntity.Values)
                {
                    d.PreRefresh();
                }
            }

            if (DateTime.Now.AddSeconds(delay).CompareTo(lastFileRefresh) > 0)
            {
                DataSet ds = null;
                if (AtMng.AppMan.ServerInfo.useService)
                {
                    atLogic.AtriumX.AtriumXClient axc = AtMng.AppMan.AtriumX();

                    ds = BEManager.DecompressDataSet(axc.LoadFile(CurrentFileId, AtMng.AppMan.AtriumXCon), new atriumDB());

                }
                else
                {
                    try
                    {
                        ds = BEManager.DecompressDataSet(this.EFile.myDAL.MainLoadByFileId(CurrentFileId), new atriumDB());
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        this.EFile.RecoverDAL();
                        ds = BEManager.DecompressDataSet(this.EFile.myDAL.MainLoadByFileId(CurrentFileId), new atriumDB());
                    }
                }
                EFile.Fill(ds.Tables["EFile"]);

                this.GetFileContact().Fill(ds.Tables["FileContact"]);
                this.GetPerson().Fill(ds.Tables["Contact"]);
                this.GetFileOffice().Fill(ds.Tables["FileOffice"]);
                this.GetFileXRef().Fill(ds.Tables["FileXRef"]);
                this.GetFileAKA().Fill(ds.Tables["FileAKA"]);
                this.GetAppointment().Fill(ds.Tables["Appointment"]);
                this.GetAppointment().SetLocalDates();
                this.GetApptRecurrence().Fill(ds.Tables["ApptRecurrence"]);
                this.GetAttendee().Fill(ds.Tables["Attendee"]);
                this.GetAddress().Fill(ds.Tables["Address"]);
                this.GetsecFileRule().Fill(ds.Tables["secFileRule"]);
                this.GetFileFlag().Fill(ds.Tables["FileFlag"]);
                this.GetArchiveBatch().Fill(ds.Tables["ArchiveBatch"]);

                this.GetIRP().Fill(ds.Tables["IRP"]);
                this.GetRiskAssessment().Fill(ds.Tables["RiskAssessment"]);
                this.GetAKA().Fill(ds.Tables["AKA"]);

                LoadDDEntities(ds.Tables["ddEntity"]);
                // this.GetddEntity("MOP").Fill(ds.Tables["ddEntity"]);

                ds.Clear();
                ds.Dispose();
                lastFileRefresh = DateTime.Now;


                this.CurrentFile.FileStructXml = EFile.CalcFileStructXml(this.CurrentFile, true, false).OuterXml;
                this.CurrentFile.AcceptChanges();

            }

        }

      
        private void LoadDDEntities(DataTable dt)
        {
            //look in ddtable for all "isDynamic" tables
            //we can make this smarter later
            //if we create them all now it will make adding rows easier
            foreach (lmDatasets.appDB.ddTableRow dtr in myatMng.DB.ddTable.Select("isDynamic=1"))
            {
                ddEntityBE d = GetddEntity(dtr.TableName);
                if (dt != null)
                {
                    DataRow[] drs = dt.Select("TableId=" + dtr.TableId.ToString());
                    if (drs.Length > 0)
                    {
                        DataTable dtFilter = drs.CopyToDataTable();
                        d.Fill(dtFilter);
                    }
                }
            }

        }

        public FileManager(atriumManager atMng)
            : base(atMng.AppMan)
        {
            Init(atMng);
            isVirtualFM = true;
        }

        public FileManager(atriumManager atMng, string officeFileNo, int officeID)
            : base(atMng.AppMan)
        {
            Init(atMng);
            myCurrentFileId = EFile.LoadByOfficeFileNum(officeFileNo, officeID);
            LoadAll(false);

            LeadOfficeMng = myatMng.GetOffice(CurrentFile.LeadOfficeId);
        }

        //public FileManager(atriumManager atMng, string SIN)
        //    : base(atMng.AppMan)
        //{
        //    Init(atMng);
        //    myCurrentFileId = EFile.LoadBySIN(SIN).FileId;
        //    LeadOfficeMng = myatMng.GetOffice(CurrentFile.LeadOfficeId);
        //}

        public FileManager(atriumManager atMng, string mode, string term)
            : base(atMng.AppMan)
        {
            Init(atMng);
            atriumDB.EFileRow er = null;
            switch (mode.ToLower())
            {
                //case "path":
                //    er = EFile.LoadByPath(term);
                //    break;
                case "fullfilenumber":
                    er = EFile.LoadByFullFileNumber(term);
                    break;
                //case "sin":
                //    er = EFile.LoadBySIN(term);
                //    break;
                default:
                    break;
            }
            if (er != null)
            {
                myCurrentFileId = er.FileId;
                LoadAll(false);

            }
        }

        private void Init(atriumManager atMng)
        {
            base.DAL = atMng.DALMngr;
            RuleHandler = atMng.RuleHandler;
            myatMng = atMng;

            MyDS = new atriumDB(); ;
            MyDS.EnforceConstraints = false;
            MyDS.RemotingFormat = SerializationFormat.Binary;
            DB.Lang = myatMng.AppMan.Language;

            myMngrs.Add(DB.DataSetName, this);
            EFileBE tmp = EFile;

            DB.FileMetaType.Merge(myatMng.CodeDB.FileMetaType);
            DB.FileType.Merge(myatMng.CodeDB.FileType);
        }

        //public string DBXML
        //{
        //    get
        //    {
        //        return DB.GetXml();
        //    }
        //}

        public atriumDB DB
        {
            get
            {
                return (atriumDB)MyDS;
            }
        }

        public atriumDB.EFileRow CurrentFile
        {
            get
            {
                if (IsVirtualFM)
                    throw new AtriumException(Properties.Resources.YouCannotUseCurrentFileOnAVirtualFileManager);

                return DB.EFile.FindByFileId(myCurrentFileId);
            }
            set
            {
                myCurrentFileId = value.FileId;

            }
        }

        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

        private atriumDB.EFileRow CreateFile(FileManager parentFile)
        {
            try
            {
                ParentFile = parentFile;
                atriumDB.EFileRow drFile = (atriumDB.EFileRow)EFile.Add(parentFile.CurrentFile);

                atriumDB.FileXRefRow fxr = (atriumDB.FileXRefRow)GetFileXRef().Add(parentFile.CurrentFile);
                fxr.LinkType = 0;
                fxr.FileId = parentFile.CurrentFile.FileId;
                fxr.OtherFileId = drFile.FileId;
                if (!drFile.IsNull("FileNumber"))
                {
                    fxr.Name = drFile.FileNumber;
                    fxr.FullFileNumber = drFile.FullFileNumber;
                }

                return drFile;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public DataTable Codes(string tableName)
        {
            return Codes(tableName, null, false);
        }

        public DataTable Codes(string codeName, object vWhere, bool noCache)
        {
            string sListname = codeName + this.AppMan.Language;
            DataTable olist = new DataTable(codeName);
            WhereClause wc = new WhereClause();

            if (!noCache)
                if (this.MyColCodes.ContainsKey(sListname))
                    return (DataTable)this.MyColCodes[sListname];

            switch (codeName.ToUpper())
            {
                case "VOUTCOME":
                case "OUTCOME":
                    if (vWhere == null)
                    {
                        int decID = 1;

                        if (GetSSTMng().DB.SSTCase.Count > 0 && !GetSSTMng().DB.SSTCase[0].IsDecisionTypeNull())
                            decID = GetSSTMng().DB.SSTCase[0].DecisionType;

                        if (GetSSTMng().DB.SSTDecision.Count > 0)
                        {
                            SST.SSTDecisionRow[] sdrs = (SST.SSTDecisionRow[])GetSSTMng().GetSSTDecision().GetCurrentRow();
                            if (sdrs.Length == 1)
                            {
                                decID = sdrs[0].DecisionType;
                            }
                        }
                        wc.Add("DecisionType", "=", decID);
                        wc.Add("Obsolete", "=", 0);
                        olist = this.AtMng.GetGeneralRec("select * from vOutcomeList " + wc.Clause() + " order by sortkey");
                        noCache = true;
                    }
                    else
                    {
                        wc = (WhereClause)vWhere;
                        wc.Add("Obsolete", "=", 0);
                        olist = this.AtMng.GetGeneralRec("select * from vOutcomeList " + wc.Clause() + " order by sortkey");
                    }
                    break;
                case "SSTPARTYTYPE":
                    int prgId = 0;
                    if (GetSSTMng().DB.SSTCase.Rows.Count > 0)
                        prgId = GetSSTMng().GetSSTCase().EffectiveProgram(GetSSTMng().DB.SSTCase[0]);

                    wc.Add("ProgramId", "=", prgId);
                    wc.Add("Obsolete", "=", 0);
                    olist = this.AtMng.GetGeneralRec("vSSTContactTypeList", wc);
                    noCache = true;
                    break;
                case "CHILDFILETYPE":
                    appDB.EFileSearchRow pfr = this.EFile.GetEfileParentRow(this.CurrentFile);
                    if (pfr != null)
                    {
                        string ft = pfr.FileType;
                        wc.Add("ParentFileType", "=", ft);
                        sListname += ft;
                    }
                    else
                    {
                        string ft = this.CurrentFile.FileType;
                        wc.Add("ParentFileType", "=", ft);
                        sListname += ft;
                    }
                    if (this.MyColCodes.ContainsKey(sListname))
                        return (DataTable)this.MyColCodes[sListname];

                    olist = this.AtMng.GetGeneralRec("vFileTypeList", wc);
                    break;
                case "CHILDMETATYPE":
                    appDB.EFileSearchRow pfr1 = this.EFile.GetEfileParentRow(this.CurrentFile);
                    if (pfr1 != null)
                    {
                        string mt = pfr1.MetaType;
                        wc.Add("ParentMetaType", "=", mt);
                        sListname += mt;
                    }
                    else
                    {
                        string mt = this.CurrentFile.MetaType;
                        wc.Add("ParentMetaType", "=", mt);
                        sListname += mt;
                    }

                    if (this.MyColCodes.ContainsKey(sListname))
                        return (DataTable)this.MyColCodes[sListname];

                    olist = this.AtMng.GetGeneralRec("vMetaTypeList", wc);

                    break;
                case "PROVINCE":
                    if (vWhere != null)
                        wc = (WhereClause)vWhere;
                    wc.Add("Obsolete", "=", 0);
                    olist = this.AtMng.GetGeneralRec(codeName, wc);
                    if (1 == 1)
                    {
                        DataColumn[] keys = new DataColumn[1];
                        keys[0] = olist.Columns["ProvinceCode"];
                        olist.PrimaryKey = keys;
                    }
                    break;
                case "VOFFICECLIENTLIST":
                    olist = this.AtMng.GetGeneralRec("vOfficeClientList", wc);
                    olist.PrimaryKey = new DataColumn[] { olist.Columns["OfficeID"] };
                    break;
                case "VOFFICELIST":
                case "OFFICELIST":
                case "AGENTLIST":
                    olist = this.AtMng.GetGeneralRec("vOfficeList", wc);
                    olist.PrimaryKey = new DataColumn[] { olist.Columns["OfficeID"] };
                    break;
                case "AGENTLISTSPECIAL":
                    olist = this.AtMng.GetGeneralRec("Select * from Office as a inner join address as ad on a.addressid=ad.addressid");
                    break;
                case "VOFFICERLIST":
                case "OFFICERLIST":
                    if (vWhere == null)
                        olist = this.AtMng.GetGeneralRec("vOfficerList", wc);
                    else if (vWhere.GetType() == typeof(WhereClause))
                        olist = this.AtMng.GetGeneralRec("vOfficerList", (WhereClause)vWhere);
                    else if ((bool)vWhere == true)
                    {
                        wc.Add("CurrentEmployee", "=", 1);
                        olist = this.AtMng.GetGeneralRec("vOfficerList", wc);
                    }
                    olist.PrimaryKey = new DataColumn[] { olist.Columns["OfficerID"] };
                    break;
                case "LAWYERLIST":
                    wc.Add("CurrentEmployee", "=", 1);
                    olist = AtMng.GetGeneralRec("vLawyerList", wc);

                    olist.PrimaryKey = new DataColumn[] { olist.Columns["OfficerID"] };
                    break;
                case "OWNERLIST":
                    olist = this.OfficerByOffice(this.CurrentFile.OwnerOfficeId, true, true);
                    break;
                case "AGENTLOGGEDONOFFLIST":
                    olist = this.OfficerByOffice(this.AtMng.OfficeLoggedOn.OfficeId, true, true);
                    break;
                case "OFFICERACCESSLIST":
                    wc.Add("FileId", "=", this.CurrentFile.FileId);
                    wc.Add("CurrentEmployee", "=", 1);
                    olist = this.AtMng.GetGeneralRec("vOfficerAccessList", wc);
                    olist.PrimaryKey = new DataColumn[] { olist.Columns["OfficerID"] };
                    break;
                case "LEADLIST":
                case "AGENTOFFLIST":
                    olist = this.OfficerByOffice(this.CurrentFile.LeadOfficeId, true, true);
                    break;
                default:
                    if (vWhere == null)
                    {
                        return AtMng.GetddLookup().Codes(codeName, this);
                    }
                    else
                        olist = this.AtMng.GetGeneralRec(codeName, (WhereClause)vWhere);
                    break;
            }
            switch (codeName.ToUpper())
            {
                case "SELJUDGMENT":
                    break;
                case "SELWRIT":
                    break;
                default:
                    if (!noCache)
                    {
                        this.MyColCodes.Add(sListname, olist);
                    }
                    break;
            }

            if (olist.PrimaryKey.Length == 0)
            {
                olist.PrimaryKey = new DataColumn[] { olist.Columns[0] };

            }
            return olist;
        }

        public DataTable OfficerByOffice(int officeID, bool onlyCurrent, bool noCache)
        {
            WhereClause wc = new WhereClause();
            wc.Add("OfficeID", "=", officeID);
            if (onlyCurrent)
                wc.Add("CurrentEmployee", "=", 1);
            return Codes("vOfficerList", wc, noCache);
        }

        public void KillACEngine()
        {
            if (rfbp != null)
            {
                if (rfbp.CurrentACE != null)
                {
                    rfbp.CurrentACE.Cancel();
                    rfbp.CurrentACE = null;
                }
            }
        }

        public ActivityBP CurrentActivityProcess
        {
            get
            {
                return rfbp;
            }
        }

        public ActivityBP InitActivityProcess()
        {
            if (CurrentFile.RowState != DataRowState.Added)
            {
                LoadAll(false);
            }
            if (rfbp == null)
            {
                rfbp = new ActivityBP(this);
                lastActivityRefresh = DateTime.Now;
            }
            else
            {
                int delay = -AtMng.GetSetting(AppIntSetting.ActivityReloadInterval);
                if (DateTime.Now.AddSeconds(delay).CompareTo(lastActivityRefresh) > 0)
                {
                    GetActivity().DeepLoadByFileId(CurrentFileId);
                    lastActivityRefresh = DateTime.Now;
                }
            }
            return rfbp;
        }

        public Dictionary<string, BEManager> MyMngrs
        {
            get
            {
                return myMngrs;
            }
        }

        public BEManager GetBEMngrForTable(string tblName)
        {
            BEManager mngr;
            //this is causing loadall to run on each mngr even if it diesn't contain the right table
            if (DB.Tables.Contains(tblName))
                mngr = this;

            else if (GetDocMng().DB.Tables.Contains(tblName))
                mngr = GetDocMng();
            else if (GetSSTMng() != null && GetSSTMng().DB.Tables.Contains(tblName))
                mngr = GetSSTMng();
            else if (LeadOfficeMng.DB.Tables.Contains(tblName))
                mngr = LeadOfficeMng;
            else if (GetAdvisoryMng().DB.Tables.Contains(tblName))
                mngr = GetAdvisoryMng();
            else if (AtMng.SecurityManager.DB.Tables.Contains(tblName))
                mngr = AtMng.SecurityManager;
            else if (GetCLASMng() != null && GetCLASMng().DB.Tables.Contains(tblName))
                mngr = GetCLASMng();
            else if (AtMng.DB.Tables.Contains(tblName))
                mngr = AtMng;
            else if (AtMng.acMng.DB.Tables.Contains(tblName))
                mngr = AtMng.acMng;
            else
                throw new Exception("Unknown object    name: " + tblName);

            return mngr;
        }

        public BEManager GetBEMngrForDS(string dsName)
        {
            BEManager mngr;
            if (DB.DataSetName == dsName)
                mngr = this;

            else if (GetDocMng().DB.DataSetName == dsName)
                mngr = GetDocMng();
            else if (GetSSTMng() != null && GetSSTMng().DB.DataSetName == dsName)
                mngr = GetSSTMng();
            else if (LeadOfficeMng.DB.DataSetName == dsName)
                mngr = LeadOfficeMng;
            else if (GetAdvisoryMng().DB.DataSetName == dsName)
                mngr = GetAdvisoryMng();
            else if (AtMng.SecurityManager.DB.DataSetName == dsName)
                mngr = AtMng.SecurityManager;
            else if (GetCLASMng() != null && GetCLASMng().DB.DataSetName == dsName)
                mngr = GetCLASMng();
            else
                throw new Exception("Unknown object    name: " + dsName);

            return mngr;
        }
        public atLogic.ObjectBE GetBEFromTable(DataTable dt)
        {
            atLogic.ObjectBE oBE = (atLogic.ObjectBE)dt.ExtendedProperties["BE"];
            if (oBE == null)
            {
                if (dt.TableName == "Contact")
                {
                    oBE = GetPerson();
                }
                else
                {
                    BEManager mngr = MyMngrs[dt.DataSet.DataSetName];
                    Type ty = mngr.GetType();
                    System.Reflection.MethodInfo mi = ty.GetMethod("Get" + dt.TableName);
                    oBE = (atLogic.ObjectBE)mi.Invoke(mngr, null);
                }
            }
            return oBE;
        }

        public void RefreshMngrs()
        {
            if (rfbp != null)
            {
                rfbp.Refresh();
            }
            foreach (atLogic.BEManager mgr in myMngrs.Values)
            {
                mgr.LoadAll(true);
            }
        }
        public void SaveAll()
        {
            BusinessProcess bp = GetBP();

            if (!IsVirtualFM && this.CurrentFile != null && this.CurrentFile.RowState == DataRowState.Added)
            {
                bp.AddForUpdate(this.EFile);


                bp.AddForUpdate(this.GetFileXRef());

                this.GetActivity().Update(bp);

            }
            else
            {
                this.GetActivity().Update(bp);

                //efile must be update again at the end to save the filestructxml changes
                bp.AddForUpdate(this.EFile);
            }

            foreach (BEManager be in this.MyMngrs.Values)
            {
                be.Update(bp);
            }


            bp.Update();

            if (!IsVirtualFM && this.CurrentFile != null)
            {
                this.CurrentFile.FileStructXml = EFile.CalcFileStructXml(this.CurrentFile, true, false).OuterXml;
                this.CurrentFile.AcceptChanges();
            }
        }

        public bool AllowedForOffice(int officeID)
        {
            bool canJumpToCBOffice = false;

            if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                canJumpToCBOffice = true;
            if (officeID == AtMng.WorkingAsOfficer.OfficeId || AtMng.WorkingAsOfficer.OfficeId == CurrentFile.OwnerOfficeId)
                canJumpToCBOffice = true;
            return canJumpToCBOffice;
        }

        public bool AllowedForOwnerOrSysAdmin()
        {
            bool isAllowed = false;
            if (AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                isAllowed = true;
            if (AtMng.WorkingAsOfficer.OfficeId == CurrentFile.OwnerOfficeId)
                isAllowed = true;
            return isAllowed;
        }

        public override void Update(BusinessProcess BP)
        {
            BP.AddForUpdate(GetPerson());
            BP.AddForUpdate(DB.AKA);
            BP.AddForUpdate(DB.Address);
            BP.AddForUpdate(DB.ApptRecurrence);
            BP.AddForUpdate(DB.Appointment);
            BP.AddForUpdate(DB.Attendee);
            BP.AddForUpdate(DB.SRP);
            BP.AddForUpdate(DB.IRP);
            BP.AddForUpdate(DB.RiskAssessment);
            BP.AddForUpdate(DB.RAClientImpact);
            BP.AddForUpdate(DB.FileOffice);
            BP.AddForUpdate(DB.FileContact);
            BP.AddForUpdate(GetFileXRef());
            BP.AddForUpdate(DB.secFileRule);
            BP.AddForUpdate(DB.FileFlag);
            BP.AddForUpdate(DB.ArchiveBatch);

            if (myddEntity != null)
            {
                foreach (ddEntityBE d in myddEntity.Values)
                {
                    BP.AddForUpdate(d);
                }
            }
        }

        private DocManager myDM;
        public bool IsDocMng
        {
            get { return myDM != null; }
        }

        public DocManager GetDocMng()
        {
            if (myDM == null)
            {
                myDM = new DocManager(this);
                myMngrs.Add(myDM.DB.DataSetName, myDM);
            }
            return myDM;
        }

        private AdvisoryManager myAdvM;
        public bool IsAdvMng
        {
            get { return myAdvM != null; }
        }

        public AdvisoryManager GetAdvisoryMng()
        {
            if (myAdvM == null)
            {
                myAdvM = new AdvisoryManager(this);
                myMngrs.Add(myAdvM.DB.DataSetName, myAdvM);
            }
            return myAdvM;
        }

        private SSTManager mySSTM;
        public bool IsSSTMng
        {
            get { return mySSTM != null; }
        }

        public SSTManager GetSSTMng()
        {
            if (AtMng.GetSetting(AppBoolSetting.useSSTMngr))
            {
                if (mySSTM == null)
                {
                    mySSTM = new SSTManager(this);
                    myMngrs.Add(mySSTM.DB.DataSetName, mySSTM);
                }
                return mySSTM;
            }
            else
                return null;

        }

        public object GetDefaultValue(string defaultValue)
        {
            object val = null;
            switch (defaultValue.ToLower())
            {
                case "forcenull":
                    val = System.DBNull.Value;
                    break;
                case "currentofficerid":
                    val = AtMng.OfficerLoggedOn.OfficerId;
                    break;
                case "workingasid":
                    val = AtMng.WorkingAsOfficer.OfficerId;
                    break;
                case "workingasofficeid":
                    val = AtMng.WorkingAsOfficer.OfficeRow.OfficeId;
                    break;
                case "utcnow":
                    val = DateTime.UtcNow;
                    break;
                case "now":
                    val = DateTime.Now;
                    break;
                case "today":
                    val = DateTime.Today;
                    break;
                default:
                    if (defaultValue.ToLower().StartsWith("today"))
                    {
                        val = ActivityBE.AtriumDateAdd(DateTime.Today, defaultValue.ToLower().Replace("today", ""));
                    }
                    else
                    {
                        val = defaultValue;
                    }
                    break;
            }

            return val;

        }
        private CLASManager myCLASM;
        public bool IsCLASMng
        {
            get { return myCLASM != null; }
        }

        public CLASManager GetCLASMng()
        {
            if (AtMng.GetSetting(AppBoolSetting.useCLASMngr))
            {
                if (myCLASM == null)
                {
                    myCLASM = new CLASManager(this);
                    myMngrs.Add(myCLASM.DB.DataSetName, myCLASM);
                }
                return myCLASM;
            }
            else
                return null;
        }

        /// <summary>
        /// This method is used to sync bf records between datasets
        /// It only works after the bf has been saved and committed
        /// </summary>
        /// <param name="abfr"></param>
        public void SyncBF(atriumDB.ActivityBFRow abfr, bool forDelete)
        {
            //see if bf is loaded
            atriumDB.ActivityBFRow abfrToSync = DB.ActivityBF.FindByActivityBFId(abfr.ActivityBFId);
            if (abfrToSync != null)
            {
                if (abfrToSync.RowState == DataRowState.Unchanged)
                {
                    if (forDelete)
                    {
                        abfrToSync.Delete();
                        abfrToSync.AcceptChanges();
                    }
                    else
                    {
                        abfrToSync.EndEdit();
                        abfrToSync.RejectChanges();
                        //if it is sync it
                        GetActivityBF().Load(abfr.ActivityBFId);
                    }
                }
              
            }
            else
            {
                //load it
                atriumDB.ActivityBFRow abr = (atriumDB.ActivityBFRow)GetActivityBF().Load(abfr.ActivityBFId);
                //need to add some tests for role as well
                if (!abr.IsRoleCodeNull() && (myatMng.OfficeMng.GetOfficer().IsInRole(abr.RoleCode) || myatMng.GetFile(abr.FileId).GetFileContact().IsInRole(abr.RoleCode)))
                {
                    //ok to keep
                }
                else if (BfListOfficerId != 0 && !abr.IsBFOfficerIDNull() && abr.BFOfficerID == BfListOfficerId)
                {
                    //ok to keep
                }
                else
                {
                    try
                    {
                        abr.Delete();
                    }
                    catch (Exception x)
                    {
                        //do nothing
                        abr.RowError = "";
                    }
                    abr.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// This method is used to sync bf records between datasets
        /// It only works after the bf has been saved and committed
        /// </summary>
        /// <param name="abfr"></param>
        public void SyncAppointment(atriumDB.AppointmentRow apptRow, bool forDelete)
        {
            //see if bf is loaded
            atriumDB.AppointmentRow apptRowToSync = DB.Appointment.FindByApptId(apptRow.ApptId);
            if (apptRowToSync != null)
            {
                if (apptRowToSync.RowState == DataRowState.Unchanged)
                {
                    if (forDelete)
                    {
                        try
                        {
                            apptRowToSync.Delete();
                        }
                        catch (Exception x)
                        {
                            apptRowToSync.RowError = "";
                        }
                        apptRowToSync.AcceptChanges();
                    }
                    else
                    {
                        //if it is sync it
                        GetAppointment().Load(apptRow.ApptId);
                        if (IsVirtualFM && apptRowToSync.GetAttendeeRows().Length > apptRow.GetAttendeeRows().Length)
                        {
                            //an attendee must have been deleted
                            foreach (atriumDB.AttendeeRow atrd in apptRowToSync.GetAttendeeRows())
                            {
                                atrd.Delete();

                            }
                            DB.Attendee.AcceptChanges();
                        }
                        GetAttendee().LoadByApptId(apptRow.ApptId);
                        if (apptRow.OriginalRecurrence)
                            GetApptRecurrence().Load(apptRow.ApptRecurrenceId);
                    }
                }
            }
            else
            {
                //load it
                atriumDB.AppointmentRow appr = (atriumDB.AppointmentRow)GetAppointment().Load(apptRow.ApptId);
                GetAttendee().LoadByApptId(appr.ApptId);
                if (appr.OriginalRecurrence)
                    GetApptRecurrence().Load(appr.ApptRecurrenceId);
                //check to see if bflistofficer is an attendee
                atriumDB.AttendeeRow[] attrs = (atriumDB.AttendeeRow[])DB.Attendee.Select("ApptId=" + appr.ApptId.ToString() + " and ContactId=" + BfListOfficerId.ToString());
                if (attrs.Length > 0)
                {
                    //ok 2 keep
                }
                else
                {
                    try
                    {
                        appr.Delete();
                    }
                    catch (Exception x)
                    {
                        //do nothing
                        appr.RowError = "";
                    }
                    appr.AcceptChanges();
                }
            }
        }

        bool isDisposed = false;
        public override void Dispose()
        {
            if (!isDisposed)
            {
                GetFileXRef().OnUpdate -= new UpdateEventHandler(AtMng.fx_OnUpdate);

                isDisposed = true;
                if (!IsVirtualFM)
                {
                    if (this.CurrentFile != null && this.CurrentFile.RowState != DataRowState.Detached)
                        this.AtMng.UnloadFileMngr(this.CurrentFileId);
                }

                foreach (atLogic.BEManager mgr in myMngrs.Values)
                {
                    if (mgr.MyDS.DataSetName.ToUpper() != "OFFICEDB")
                        mgr.Dispose();
                }

                myMngrs.Clear();
                base.Dispose();
            }
        }
    }
}
