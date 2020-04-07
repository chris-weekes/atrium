using System;
using System.Reflection;
using System.IO;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using lmDatasets;
using atLogic;
using atriumBE.Properties;
using System.Runtime.Caching;


namespace atriumBE
{

    public class atriumManager : atLogic.BEManager, IDisposable
    {


        public event UpdateEventHandler FXUpdate;
        public event UpdateEventHandler EfileUpdate;

        List<ACEState> saves = new List<ACEState>();



        internal System.Collections.Generic.Dictionary<string, DataTable> myColCodes;




        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return AppMan.DALMngr;

            }
            set { AppMan.DALMngr = value; }
        }

        public ACManager acMng;

        private MemberManager memMng;
        public MemberManager GetMemberMng()
        {
            if (memMng == null)
                memMng = new MemberManager(this);

            return memMng;
        }

        private OfficeManager myofficeMng;

        private System.Collections.Generic.Dictionary<int, OfficeManager> officeMngrs = new System.Collections.Generic.Dictionary<int, OfficeManager>();
        public OfficeManager OfficeMng
        {
            get
            {
                return myofficeMng;
            }
            set { myofficeMng = value; }
        }

        public OfficeManager GetOffice()
        {
            return new OfficeManager(this);


        }

        public void ClearCodesCache()
        {
            if (myColCodes != null)
            {
                myColCodes.Clear();

            }
        }

        PostalCodeLocationBE myPostalCodeLocation;
        public PostalCodeLocationBE GetPostalCodeLocation()
        {

            if (myPostalCodeLocation == null)
            {
                myPostalCodeLocation = new PostalCodeLocationBE(this);
            }

            return myPostalCodeLocation;
        }
        ddLookupBE myddLookup;
        public ddLookupBE GetddLookup()
        {

            if (myddLookup == null)
            {
                myddLookup = new ddLookupBE(this);
            }

            return myddLookup;
        }
        ddGenericBE myddGeneric;
        public ddGenericBE GetddGeneric()
        {

            if (myddGeneric == null)
            {
                myddGeneric = new ddGenericBE(this);
            }

            return myddGeneric;
        }

        SearchBE mySearch;
        public SearchBE GetSearch()
        {

            if (mySearch == null)
            {
                mySearch = new SearchBE(this);
            }

            return mySearch;
        }
        SearchTermBE mySearchTerm;
        public SearchTermBE GetSearchTerm()
        {

            if (mySearchTerm == null)
            {
                mySearchTerm = new SearchTermBE(this);
            }

            return mySearchTerm;
        }
        IssueBE myIssue;
        public IssueBE GetIssue()
        {

            if (myIssue == null)
            {
                myIssue = new IssueBE(this);
            }

            return myIssue;
        }
        public LegislationBE myLegislation;
        public ProvisionBE myProvision;

        public LegislationBE GetLegislation()
        {

            if (myLegislation == null)
            {
                myLegislation = new LegislationBE(this);
            }

            return myLegislation;
        }
        public ProvisionBE GetProvision()
        {

            if (myProvision == null)
            {
                myProvision = new ProvisionBE(this);
            }

            return myProvision;
        }

        TaxRateBE myTaxRate;
        public TaxRateBE GetTaxRate()
        {
            if (myTaxRate == null)
            {
                myTaxRate = new TaxRateBE(this);
            }

            return myTaxRate;
        }

        MsgBE myMsg;
        public MsgBE GetMsg()
        {

            if (myMsg == null)
            {
                myMsg = new MsgBE(this);
            }

            return myMsg;
        }
        AppSettingBE myAppSetting;
        public AppSettingBE GetAppSetting()
        {

            if (myAppSetting == null)
            {
                myAppSetting = new AppSettingBE(this);
            }

            return myAppSetting;
        }

        MapBE myMap;
        public MapBE GetMap()
        {

            if (myMap == null)
            {
                myMap = new MapBE(this);
            }

            return myMap;
        }

        public DateTime GetSetting(AppDateSetting s)
        {
            return System.Convert.ToDateTime(GetAppSetting().GetSetting((int)s));
        }

        public string GetSetting(AppStringSetting s)
        {
            return GetAppSetting().GetSetting((int)s);
        }

        public bool GetSetting(AppBoolSetting s)
        {
            return System.Convert.ToBoolean(GetAppSetting().GetSetting((int)s));
        }

        public int GetSetting(AppIntSetting s)
        {
            return System.Convert.ToInt32(GetAppSetting().GetSetting((int)s));
        }

        ListBE myList;
        public ListBE GetList()
        {

            if (myList == null)
            {
                myList = new ListBE(this);
            }

            return myList;
        }

        ListMemberBE myListMember;
        public ListMemberBE GetListMember()
        {

            if (myListMember == null)
            {
                myListMember = new ListMemberBE(this);
            }

            return myListMember;
        }

        public DataTable RecipientGetRecentSent()
        {
            if (!myColCodes.ContainsKey("RecipientGetRecentSent"))
            {
                DataTable dt = AppMan.ExecuteDataset("RecipientGetRecentSent", OfficerLoggedOn.OfficerId).Tables[0];
                foreach(DataRow dr in dt.Select())
                {
                    DataRow dr1 = dt.NewRow();
                    dr1["OfficerId"] = dr["OfficerId"];
                    dr1["Name"] = dr["Name"];
                    dr1["Address"] = dr["Name"].ToString()+"["+dr["email"].ToString()+"]";
                    dr1["email"] = dr["email"];
                    dr1["listid"] = dr["listid"];

                    dt.Rows.Add(dr1);
                }
                myColCodes.Add("RecipientGetRecentSent",dt);
            }
            return (DataTable)myColCodes["RecipientGetRecentSent"];
        }

        public void InitMailSubSystem()
        {
            RecipientGetRecentSent();
            GetList().Load();
            GetListMember().Load();
        }

        public OfficeManager GetOffice(int officeId)
        {
            if (!officeMngrs.ContainsKey(officeId))
            {
                OfficeManager off = new OfficeManager(this);
                off.GetOffice(officeId);

                officeMngrs.Add(officeId, off);
                //load all officers for this office to prevent loading them one-at-a-time
                off.GetOfficer().LoadByOfficeId(officeId);
                off.GetServiceCentre().Load(officeId);
            }

            return officeMngrs[officeId];
        }



        //public OfficeManager GetOffice(string officeCode)
        //{
        //    OfficeManager tmp = new OfficeManager(this);
        //    int officeId = tmp.GetOffice(officeCode).OfficeId;

        //    if (!officeMngrs.ContainsKey(officeId))
        //    {
        //        officeMngrs.Add(officeId, tmp);
        //    }

        //    return officeMngrs[officeId];
        //}

        private OfficeManager GetOfficeForOfficer(string username)
        {
            OfficeManager tmp = new OfficeManager(this);

            int officeId = tmp.GetOfficeForOfficer(username).OfficeId;
            if (!officeMngrs.ContainsKey(officeId))
            {
                officeMngrs.Add(officeId, tmp);
                //load all officers for this office to prevent loading them one-at-a-time
                tmp.GetOfficer().LoadByOfficeId(officeId);
            }

            return officeMngrs[officeId];
        }
        public OfficeManager GetOfficeForOfficer(int officerId)
        {
            OfficeManager tmp = new OfficeManager(this);

            int officeId = tmp.GetOfficeForOfficer(officerId).OfficeId;
            if (!officeMngrs.ContainsKey(officeId))
            {
                officeMngrs.Add(officeId, tmp);
                //load all officers for this office to prevent loading them one-at-a-time
                tmp.GetOfficer().LoadByOfficeId(officeId);
            }

            return officeMngrs[officeId];
        }

        internal MemoryCache FileMngrs
        {
            get
            {
                return fileMngrs;
            }
        }

        internal void UnloadFileMngr(int fileId)
        {
            if (fileMngrs.Contains(fileId.ToString()))
            {
                FileManager fm = (FileManager)fileMngrs.Get(fileId.ToString(), null);

                fileMngrs.Remove(fileId.ToString());
                if (LoadedFMs.Contains(fileId.ToString()))
                    LoadedFMs.Remove(fileId.ToString());
            }
        }

        public bool IsFileMngrLoaded(int fileId)
        {
            if (!fileMngrs.Contains(fileId.ToString()) && loadedFMs.Contains(fileId.ToString()))
                loadedFMs.Remove(fileId.ToString());

            return fileMngrs.Contains(fileId.ToString());
        }

        private void VerifyLoadedFMs()
        {
            string[] fms = loadedFMs.ToArray();
            foreach (string s in fms)
            {
                IsFileMngrLoaded(System.Convert.ToInt32(s));
            }
        }

        private CodesDB myCodesDB = new CodesDB();
        public CodesDB CodeDB
        {
            get { return myCodesDB; }
            set { myCodesDB = value; }
        }

        public appDB DB
        {
            get { return (appDB)MyDS; }
        }

        private int myOfficeLoggedOnId;
        private int myOfficerLoggedOnId;
        private int myWorkingAsOfficerId;

        internal bool loggedOnAsSystem = false;

        EventLogBE myEventLog;
        public EventLogBE GetEventLog()
        {
            if (myEventLog == null)
                myEventLog = new EventLogBE(this);

            return myEventLog;
        }

        private OutlookCalAppMsgBE myOutlookCalAppMsg;
        public OutlookCalAppMsgBE GetOutlookCalAppMsg()
        {
            if (myOutlookCalAppMsg == null)
                myOutlookCalAppMsg = new OutlookCalAppMsgBE(this);

            return myOutlookCalAppMsg;
        }

        private ddFieldBE myddField;
        public ddFieldBE GetddField()
        {

            if (myddField == null)
            {
                myddField = new ddFieldBE(this);
            }

            return myddField;
        }

        private ddTableBE myddTable;
        public ddTableBE GetddTable()
        {

            if (myddTable == null)
            {
                myddTable = new ddTableBE(this);
            }

            return myddTable;
        }
        private ddRuleBE myddRule;
        public ddRuleBE GetddRule()
        {

            if (myddRule == null)
            {
                myddRule = new ddRuleBE(this);
            }

            return myddRule;
        }

        private PLOfficeBE myPLOfficeBE;
        public PLOfficeBE GetPLOffice()
        {

            if (myPLOfficeBE == null)
            {
                myPLOfficeBE = new PLOfficeBE(this);
            }

            return myPLOfficeBE;
        }

        private BatchBE myBatch;
        public BatchBE GetBatch()
        {

            if (myBatch == null)
            {
                myBatch = new BatchBE(this);
            }

            return myBatch;
        }

        private ProvinceBE myProvince;
        public ProvinceBE GetProvince()
        {

            if (myProvince == null)
            {
                myProvince = new ProvinceBE(this);
            }

            return myProvince;
        }

        private TemplateBE myTemplate;
        public TemplateBE GetTemplate()
        {

            if (myTemplate == null)
            {
                myTemplate = new TemplateBE(this);
            }

            return myTemplate;
        }

        public AtriumApp AppMan
        {
            get { return (AtriumApp)base.AppMan; }
        }

        public atriumManager(AppManager appMan)
            : base(appMan)
        {
            CodeDB.EnforceConstraints = false;
            //fileMngrs = (Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager)Microsoft.Practices.EnterpriseLibrary.Caching.CacheFactory.GetCacheManager("FileManagers");
            fileMngrs = new MemoryCache("CachingProvider");

            myColCodes = new Dictionary<string, DataTable>();

            MyDS = new appDB();
            MyDS.EnforceConstraints = false;

            //load early so we can check min version
            GetAppSetting().Load();

            if (GetSetting(AppIntSetting.MinVersion) > System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build)
            {
                throw new AtriumException("You must install the new version of Atrium.");
            }

            acMng = new ACManager(this);
            try
            {
                myofficeMng = GetOfficeForOfficer(AppMan.myUser);

                myOfficerLoggedOnId = myofficeMng.CurrentOfficer.OfficerId;
                myofficeMng.GetOfficerPrefs().LoadByOfficerId(myOfficerLoggedOnId);
                myofficeMng.GetOfficerRole().LoadByOfficerID(myOfficerLoggedOnId);

                myWorkingAsOfficerId = myOfficerLoggedOnId;

                myOfficeLoggedOnId = myofficeMng.CurrentOffice.OfficeId;


                FillBooleanDT();
            }
            catch (atLogic.AtriumException exc)
            {
                System.Diagnostics.Trace.WriteLine(exc.Message);
                throw exc;
            }
            catch (Exception exc)
            {
                throw exc;
            }

            SecurityManager = new atSecurity.SecurityManager(this);

            SecurityDB.secUserRow sur = this.SecurityManager.GetsecUser().Load(AppMan.myUser);
            this.SecurityManager.VerifyLogin(sur.UserId);
            this.OfficeMng.GetOfficer().SecUserBE = SecurityManager.GetsecUser();
            this.OfficeMng.GetOfficer().SecUserRow = sur;

            GetCodeTableBE("FileFormat").Load();
            GetCodeTableBE("FileMetaType").Load();
            GetCodeTableBE("FileType").Load();
            GetCodeTableBE("CaseStatus").Load();
            GetCodeTableBE("DecisionType").Load();
            GetCodeTableBE("Outcome").Load();

            GetIssue().Load();
            GetLegislation().Load();
            GetProvision().Load();

            GetTaxRate().Load();

            RuleHandler = GetddRule();
        }






        //public atriumManager(atriumBE.Servers.ServerRow server)
        //{
        //    if (server.useRemote)
        //        throw new AtriumException("You cannot run batches remotely");

        //    //for service only
        //    AppDomain myDomain = System.Threading.Thread.GetDomain();

        //    myDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
        //    System.Security.Principal.WindowsPrincipal myPrincipal = (System.Security.Principal.WindowsPrincipal)System.Threading.Thread.CurrentPrincipal;

        //    string user = myPrincipal.Identity.Name;
        //    CodeDB.EnforceConstraints = false;
        //    myUser = user;

        //    this.loggedOnAsSystem = true;


        //    DALMngr = new atriumDAL.atriumDALManager(System.Net.CredentialCache.DefaultNetworkCredentials, server.dbConnect);
        //    DALMngr.RemotingFormat = SerializationFormat.Binary;
        //    OfficeMng = new OfficeManager(this);

        //    acMng = new ACManager(this);

        //    AppMan.SecurityManager = new atSecurity.SecurityManager(System.Net.CredentialCache.DefaultNetworkCredentials, user, null, false, server.dbConnect, null);



        //}

        public void Impersonate(string userName, string officeCode)
        {
            //user by atrium service
            if (this.loggedOnAsSystem == true)
            {
                try
                {
                    myOfficeLoggedOnId = this.OfficeMng.GetOffice(officeCode).OfficeId;
                    myOfficerLoggedOnId = this.OfficeMng.GetOfficer().Load(userName).OfficerId;
                    myWorkingAsOfficerId = myOfficerLoggedOnId;

                    //global roles need to be loaded
                    if (WorkingAsOfficer.GetOfficerRoleRows().Length == 0)
                        this.OfficeMng.GetOfficerRole().LoadByOfficerID(WorkingAsOfficer.OfficerId);

                    //WorkAs(myOfficerLoggedOnId);
                    //if (SecurityManager.VerifyLogin(myOfficerLoggedOnId))
                    //{
                    //    this.OfficeMng.GetOfficer().SecUserBE = SecurityManager.GetsecUser();
                    //    this.OfficeMng.GetOfficer().SecUserRow = SecurityManager.DB.secUser.FindByUserId(myOfficerLoggedOnId);

                    //}
                }
                catch (atLogic.AtriumException exc)
                {
                    System.Diagnostics.Trace.WriteLine(exc.Message);
                    throw new AtriumException(Resources.BadUserName);
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
            else
                throw new AtriumException(Resources.CannotImpersonate, userName);
        }



        //private void Init(System.Net.NetworkCredential nc, string user, string language, string pwd,  string fwPassword)
        //{
        //    myDALClient = new DALClient(this);

        //    myNC = nc;

        //    CodeDB.EnforceConstraints = false;
        //    myUser = user;
        //    myPwd = pwd;

        //    fileMngrs =(Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager) Microsoft.Practices.EnterpriseLibrary.Caching.CacheFactory.GetCacheManager("FileManagers");

        //    myColCodes = new Dictionary<string, DataTable>();



        //    //WindowsFormsApplicationBase creates a talk-back channel
        //    if (UsingRemote)
        //    {

        //        //start proxy
        //        if(ServerInfo.useProxy)
        //            StartProxy(ServerInfo, user, fwPassword);

        //        DALMngr =(atriumDAL.atriumDALManager) RemoteDAL(nc.UserName, fwPassword);


        //    }
        //    else
        //    {

        //        DALMngr = new atriumDAL.atriumDALManager(nc.UserName, nc.Password, ServerInfo.dbConnect);
        //    }

        //    //DALMngr.RemotingFormat = SerializationFormat.Binary;

        //    //System.Diagnostics.Trace.WriteLine("Remote account:" + DALMngr.User);


        //    acMng = new ACManager(this);
        //    try
        //    {
        //        myofficeMng = GetOfficeForOfficer(user);

        //        myOfficerLoggedOnId = myofficeMng.CurrentOfficer.OfficerId;
        //        myofficeMng.GetOfficerPrefs().LoadByOfficerId(myOfficerLoggedOnId);
        //        myofficeMng.GetOfficerRole().LoadByOfficerID(myOfficerLoggedOnId);

        //        myWorkingAsOfficerId = myOfficerLoggedOnId;

        //        myOfficeLoggedOnId = myofficeMng.CurrentOffice.OfficeId;

        //        if (language == "FRE")
        //        {
        //            atriumBE.Properties.Resources.Culture = new System.Globalization.CultureInfo("fr-CA");

        //            this.myLanguage = language;
        //        }

        //        AppMan.SecurityManager = new atSecurity.SecurityManager(nc, user, ServerInfo.proxyUrl,ServerInfo.useRemote, ServerInfo.dbConnect, fwPassword);

        //        StartPulse();
        //        pulse.Elapsed += new System.Timers.ElapsedEventHandler(pulse_Elapsed1);
        //        FillBooleanDT();
        //    }
        //    catch (atLogic.AtriumException exc)
        //    {
        //        System.Diagnostics.Trace.WriteLine(exc.Message);
        //        throw exc;
        //    }
        //    catch (Exception exc)
        //    {
        //        throw exc;
        //    }

        //    SecurityDB.secUserRow sur = this.SecurityManager.GetsecUser().Load(user);
        //    this.SecurityManager.VerifyLogin(sur.UserId);
        //    this.OfficeMng.GetOfficer().SecUserBE = AppMan.SecurityManager.GetsecUser();
        //    this.OfficeMng.GetOfficer().SecUserRow = sur;

        //    GetCodeTableBE("FileFormat").Load();
        //    GetCodeTableBE("FileMetaType").Load();
        //    GetCodeTableBE("FileType").Load();

        //    GetAppSetting().Load();
        //}
        public string Translate( string column)
        {
            string desc = column;
            if (desc.EndsWith("Eng", StringComparison.CurrentCultureIgnoreCase))
            {
                if (AppMan.Language.ToUpper() == "FRE")
                    desc = desc.Substring(0, desc.Length - 3) + "Fre";
            }
            else if (desc.EndsWith("E"))
            {
                if (AppMan.Language.ToUpper() == "FRE")
                {
                    desc = desc.Substring(0, desc.Length - 1) + "F";
                }
            }

            if (desc == "officename")
            {
                if (AppMan.Language.ToUpper() == "FRE")
                    desc = "officenamefre";
            }


            return desc;
        }

        private void FillBooleanDT()
        {
            CodesDB.BooleanValuesRow br;
            br = (CodesDB.BooleanValuesRow)CodeDB.BooleanValues.NewRow();
            br.BoolValue = "True";
            br.BoolDescEng = "Checked";
            br.BoolDescFre = "Coché";
            CodeDB.BooleanValues.AddBooleanValuesRow(br);

            CodesDB.BooleanValuesRow br1;
            br1 = (CodesDB.BooleanValuesRow)CodeDB.BooleanValues.NewRow();
            br1.BoolValue = "False";
            br1.BoolDescEng = "Unchecked";
            br1.BoolDescFre = "Non-coché";
            CodeDB.BooleanValues.AddBooleanValuesRow(br1);
        }

        public appDB.EFileSearchDataTable FileSearchBySIN(string SIN)
        {
            return FileSearch("SIN", SIN);
        }
        public appDB.EFileSearchThreadDataTable FileSearchByThread(string Thread)
        {
            appDB.EFileSearchThreadDataTable dt = new appDB.EFileSearchThreadDataTable();
            if (AppMan.UseService)
                return (appDB.EFileSearchThreadDataTable)DecompressDataTable(AppMan.AtriumX().FileSearchByThread(Thread, myOfficeLoggedOnId, AppMan.AtriumXCon), dt);
            else
                return (appDB.EFileSearchThreadDataTable)DecompressDataTable(DALMngr.FileSearchByThread(Thread, myOfficeLoggedOnId), dt);
        }

        public appDB.EFileSearchDataTable FileSearchByKeyword(string keyword)
        {
            return FileSearch("Keyword", keyword);
        }
        public appDB.EFileSearchDataTable FileSearchByFullFileName(string fullFileName)
        {
            return FileSearch("FullFileName", fullFileName);
        }
        public appDB.EFileSearchDataTable FileSearchByICASE(string keyword)
        {
            return FileSearch("ICASE", keyword);
        }
        public appDB.EFileSearchDataTable FileSearchByFileNumber(string fileNumber)
        {
            return FileSearch("FileNumber", fileNumber);
        }
        public appDB.EFileSearchDataTable FileSearchByFullFileNumber(string fullFileNumber)
        {
            return FileSearch("FullFileNumber", fullFileNumber);
        }
        public appDB.EFileSearchDataTable FileSearchByLastName(string lastName)
        {
            return FileSearch("LastName", lastName);
        }
        public appDB.EFileSearchDataTable FileSearchByOfficeFileNum(string officeFileNum)
        {
            return FileSearch("OfficeFileNum", officeFileNum);
        }
        public appDB.EFileSearchDataTable FileSearchByOfficeFileNum(string officeFileNum, int officeId)
        {
            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            if (AppMan.UseService)
                return (appDB.EFileSearchDataTable)DecompressDataTable(AppMan.AtriumX().FileSearch("OfficeFileNum", officeFileNum, officeId, AppMan.AtriumXCon), dt);
            else
                return (appDB.EFileSearchDataTable)DecompressDataTable(this.DALMngr.FileSearch("OfficeFileNum", officeFileNum, officeId), dt);

        }
        public appDB.EFileSearchDataTable FileSearchByRecentFiles(string userName, DateTime dateStart, DateTime dateEnd)
        {
            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            if (AppMan.UseService)
                return (appDB.EFileSearchDataTable)DecompressDataTable(AppMan.AtriumX().FileSearchDates(userName, dateStart, dateEnd, AppMan.AtriumXCon), dt);
            else
                return (appDB.EFileSearchDataTable)DecompressDataTable(this.DALMngr.FileSearch(userName, dateStart, dateEnd), dt);



        }

        public appDB.EFileSearchDataTable FileSearchByContact(int contactId, string contactType)
        {

            return this.GetFile().EFile.SearchByContact(contactId, contactType);

        }
        public appDB.EFileSearchDataTable FileSearchByFileId(int fileId)
        {

            return this.FileSearch("FileId", fileId.ToString());

        }
        public appDB.EFileSearchDataTable FileSearchByParentFileId(int parentFileId)
        {

            return this.FileSearch("ParentFileId", parentFileId.ToString());

        }

        public appDB.EFileSearchDataTable FileSearchFindParent(int fileId)
        {

            return this.FileSearch("ParentFile", fileId.ToString());

        }

        public appDB.EFileSearchDataTable FileSearch(WhereClause wc, WhereClause wcContact, WhereClause wcCaseStatus, bool includeXrefs)
        {
            string wcS = wc.Filter();
            string wccS = "";
            string wccsS = "";
            if (wcContact != null)
                wccS = wcContact.Filter();
            if (wcCaseStatus != null)
                wccsS = wcCaseStatus.Filter();


            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            if (AppMan.UseService)
                return (appDB.EFileSearchDataTable)DecompressDataTable(AppMan.AtriumX().FileSearchAdvanced(wcS, wccS, wccsS, includeXrefs, AppMan.AtriumXCon), dt);
            else
                return (appDB.EFileSearchDataTable)DecompressDataTable(DALMngr.FileSearch(wcS, wccS, wccsS, includeXrefs), dt);

        }

        private appDB.EFileSearchDataTable FileSearch(string search, string keyword)
        {
            try
            {
                appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
                if (AppMan.UseService)
                    dt = (appDB.EFileSearchDataTable)DecompressDataTable(AppMan.AtriumX().FileSearch(search, keyword, this.OfficeLoggedOn.OfficeId, AppMan.AtriumXCon), dt);
                else
                    dt = (appDB.EFileSearchDataTable)DecompressDataTable(DALMngr.FileSearch(search, keyword, this.OfficeLoggedOn.OfficeId), dt);

                dt.Lang = AppMan.Language;
                return dt;
            }

            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void Export(string where)
        {
            appDB.EFileSearchDataTable dtF = new appDB.EFileSearchDataTable();
            dtF = (appDB.EFileSearchDataTable)DecompressDataTable(DALMngr.FileSearch(where, null, null, false), dtF);

            foreach (appDB.EFileSearchRow efsr in dtF)
            {
                FileManager fm = GetFile(efsr.FileId);
                fm.InitActivityProcess();
                //now loaded in docmanager constructor
                //fm.GetDocMng().GetDocument().LoadByFileId(efsr.FileId);
                fm.GetDocMng().GetDocument().Export();
                fm.Dispose();
            }
        }

        public docDB.DocXRefDataTable DocShortcuts(int fileId)
        {
            docDB.DocXRefDataTable dt = new docDB.DocXRefDataTable();
            if (AppMan.UseService)
                return (docDB.DocXRefDataTable)DecompressDataTable(AppMan.AtriumX().DocShortcuts(fileId,AppMan.AtriumXCon), dt);
            else
                return (docDB.DocXRefDataTable)DecompressDataTable(DALMngr.DocShortcuts(fileId), dt);
        }
        public appDB.ContactSearchDataTable ContactSearch(string search)
        {
            if (AppMan.UseService)
                return AppMan.AtriumX().ContactSearch(search,AppMan.AtriumXCon);
            else
                return DALMngr.ContactSearch(search);
        }

        public appDB.ContactSearchDataTable PartySearch(string search)
        {
            if (AppMan.UseService)
                return AppMan.AtriumX().PartySearch(search, AppMan.AtriumXCon);
            else
                return DALMngr.PartySearch(search);
        }
        public atLogic.ObjectBE GetCity()
        {
            if (AppMan.UseService)
                return GetObjectBE(null, DB.City);
            else
                return this.GetObjectBE(DALMngr.GetCity(), DB.City);
        }
        public atLogic.ObjectBE GetFilePeriod()
        {
            return this.GetCodeTableBE("FilePeriod");
        }


        Dictionary<string, atLogic.ObjectBE> codeBEs = new Dictionary<string, atLogic.ObjectBE>();
        public atLogic.ObjectBE GetCodeTableBE(string tableName)
        {
            atLogic.ObjectBE obe;
            if (codeBEs.ContainsKey(tableName))
                obe = codeBEs[tableName];
            else
            {
                atDAL.ObjectDAL dal = null;
                if (!AppMan.UseService)
                {
                    dal = AppMan.myDALClient.ODAL(tableName + "DAL"); ;

                    if (dal == null)
                    {
                        Type ty = DALMngr.GetType();
                        System.Reflection.MethodInfo mi = ty.GetMethod("Get" + tableName);
                        dal = (atDAL.ObjectDAL)mi.Invoke(DALMngr, null);
                    }
                }

                if (CodeDB.Tables.Contains(tableName))
                {
                    obe = GetObjectBE(dal, CodeDB.Tables[tableName]);
                }
                else
                {

                    obe = GetObjectBE(dal, DB.Tables[tableName]);
                }
                codeBEs.Add(tableName, obe);

                if (obe.myDT.Columns.Contains("ReadOnly"))
                    obe.myDT.Columns["ReadOnly"].DefaultValue = false;

                if (obe.myDT.Columns.Contains("Obsolete"))
                    obe.myDT.Columns["Obsolete"].DefaultValue = false;
            }
            return obe;
        }


        public DataTable GetCity(string city, string prov)
        {
            DataTable dt;
            try
            {
                WhereClause wc = new WhereClause();
                wc.Add("ProvinceCode", "=", prov);
                wc.Add("City", "Like", city.Substring(0, 2));
                dt = this.GetGeneralRec("City", wc);
                return dt;
            }
            catch (atLogic.AtriumException cme)
            {
                throw cme;
            }
            catch (Exception exc)
            {
                throw exc;
            }

        }



        public officeDB.OfficeRow OfficeLoggedOn
        {
            get
            {
                return GetOffice(this.myOfficeLoggedOnId).CurrentOffice;
            }
        }

        public officeDB.OfficerRow OfficerLoggedOn
        {
            get
            {
                return OfficeMng.GetOfficer().FindLoad(myOfficerLoggedOnId);
                //return GetOffice(this.myOfficeLoggedOnId).DB.Officer.FindByOfficerId(myOfficerLoggedOnId);
            }
        }

        public officeDB.OfficerRow WorkingAsOfficer
        {
            get
            {
                return OfficeMng.GetOfficer().FindLoad(myWorkingAsOfficerId);
                //return GetOffice(this.myOfficeLoggedOnId).DB.Officer.FindByOfficerId(myWorkingAsOfficerId);
            }

            set
            {
                bool allowed = false;

                if (myOfficeLoggedOnId == value.OfficeId)
                    allowed = true;

                //2017-08-21 JLL: SysAdmin can work as anyone ...
                //not sure why the officeid check was implemented, but i need to work as other offices as admin, so we'll see if i hit any glitches with the officeid mismatch between logged on vs working as officeid
                if (OfficeMng.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                    allowed = true;
                    //remember to load data in officer delegate by delegatetoid

                    //check to make sure that this is allowed in the officerdelegate table
                    foreach (officeDB.OfficerDelegateRow odr in OfficerLoggedOn.GetOfficerDelegateRowsByOfficerWorkAs())
                {
                    if (odr.WorkAs & odr.OfficerId == value.OfficerId)
                        allowed = true;
                }
                if (allowed)
                    myWorkingAsOfficerId = value.OfficerId;
                else
                    throw new AtriumException(Resources.YouCannotWorkAsThisOfficer);
            }
        }

        public void WorkAs(int officerId)
        {
            WorkingAsOfficer = OfficeMng.GetOfficer().FindLoad(officerId);
            OfficeMng.GetOfficerRole().LoadByOfficerID(WorkingAsOfficer.OfficerId);
            if (WorkingAsOfficer.OfficeRow == null)
                OfficeMng.GetOffice().Load(WorkingAsOfficer.OfficeId);

        }


        public void LoadDDInfo()
        {
            DB.ddField.Clear();
            DB.ddTable.Clear();
            DB.ddGeneric.Clear();
            DB.ddLookup.Clear();
            DB.ddRule.Clear();
            DB.AcceptChanges();

            System.Data.DataSet ds;
            if (AppMan.UseService)
                ds = DecompressDataSet(AppMan.AtriumX().LoadDDInfo(AppMan.AtriumXCon), new lmDatasets.appDB());
            else
                ds = DecompressDataSet(DALMngr.LoadDataDictionary(), new lmDatasets.appDB());
            GetddTable().Fill(ds.Tables["ddTable"]);
            GetddField().Fill(ds.Tables["ddField"]);
            GetddLookup().Fill(ds.Tables["ddLookup"]);
            GetddGeneric().Fill(ds.Tables["ddGeneric"]);
            GetddRule().Fill(ds.Tables["ddRule"]);
        }

        HelpManager myHelpMng;

        public HelpManager HelpMng()
        {

            if (myHelpMng == null)
                myHelpMng = new HelpManager(this);

            return myHelpMng;


        }

        atSecurity.SecurityManager atSecMng;
        public atSecurity.SecurityManager SecurityManager
        {
            get { return atSecMng; }
            set { atSecMng = value; }
        }

        public FileManager CreateFile(FileManager parentFile)
        {
            FileManager tmp = new FileManager(this, parentFile);

            //fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
            fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, new CacheRefresh(), null);
            if (!LoadedFMs.Contains(tmp.CurrentFile.FileId.ToString()))
                LoadedFMs.Add(tmp.CurrentFile.FileId.ToString());
            tmp.GetFileXRef().OnUpdate += new UpdateEventHandler(fx_OnUpdate);

            return tmp;
        }
        Dictionary<int, FileManager> bfLists = new Dictionary<int, FileManager>();
        public FileManager GetBFFile(int officerId)
        {
            if (!bfLists.ContainsKey(officerId))
            {
                bfLists.Add(officerId, new FileManager(this));
                bfLists[officerId].BfListOfficerId = officerId;
            }


            return bfLists[officerId];
        }
        public FileManager GetFile()
        {
            return new FileManager(this);

        }
        //public FileManager GetTemplateFM()
        //{
        //    return new FileManager(this, GetSetting(AppIntSetting.TemplateFileId));
        //}
        MemoryCache fileMngrs;
        List<string> loadedFMs = new List<string>();

        public List<string> LoadedFMs
        {
            get
            {
                VerifyLoadedFMs();
                return loadedFMs;
            }
            //set { loadedFMs = value; }
        }

        //TFS#54353 CJW 20013-8-26
        //removed the "deep" parameter
        public FileManager GetFile(int fileId)
        {
            //resolve special fileids
            int _fileid = fileId;
            if (fileId < 0 & fileId > -20)
            {
                switch ((SpecialFileIds)fileId)
                {
                    case SpecialFileIds.Inbox:
                        _fileid = WorkingAsOfficer.InboxId;
                        break;
                    case SpecialFileIds.Personal:
                        _fileid = WorkingAsOfficer.MyFileId;
                        break;
                    case SpecialFileIds.SentItems:
                        _fileid = WorkingAsOfficer.SentItemsId;
                        break;
                    case SpecialFileIds.ShortCuts:
                        _fileid = WorkingAsOfficer.ShortcutsId;
                        break;
                }
            }
            if (!fileMngrs.Contains(_fileid.ToString()))
            {
                FileManager tmp = new FileManager(this, _fileid);
                //fileMngrs.Add(_fileid.ToString(), tmp, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
                fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, new CacheRefresh(), null);
                if (!LoadedFMs.Contains(_fileid.ToString()))
                    LoadedFMs.Add(_fileid.ToString());
                tmp.GetFileXRef().OnUpdate += new UpdateEventHandler(fx_OnUpdate);
            }

            //FileRefPlus(fileId);
            FileManager fm = (FileManager)fileMngrs.Get(_fileid.ToString());
            if (fm == null)
                return GetFile(fileId);
            else
                return fm;
        }

        public void fx_OnUpdate(object sender, UpdateEventArgs e)
        {
            if (FXUpdate != null & e.SavedOK)
            {
                UpdateEventArgs ev = new UpdateEventArgs();
                ev.SavedOK = true;
                ev.ChangedRows = e.ChangedRows;
                FXUpdate(this, ev);
            }
        }

        public void RaiseEfileUpdate(atriumDB.EFileRow er)
        {
            if (EfileUpdate != null)
            {
                UpdateEventArgs ev = new UpdateEventArgs();
                ev.SavedOK = true;
                ev.ChangedRows = new DataRow[] { er };
                EfileUpdate(this, ev);
            }
        }

        //public FileManager GetFileBySIN(string SIN)
        //{

        //    FileManager tmp = new FileManager(this, SIN);
        //    int fileId = tmp.CurrentFile.FileId;
        //    if (!fileMngrs.Contains(fileId.ToString()))
        //    {
        //        // fileMngrs.Add(fileId.ToString(), tmp, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
        //        fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, new CacheRefresh(), null);
        //        if (!LoadedFMs.Contains(fileId.ToString()))
        //            LoadedFMs.Add(fileId.ToString());
        //    }
        //    else
        //    {
        //        tmp = null;
        //    }

        //    return (FileManager)fileMngrs.Get(fileId.ToString());

        //}

        public FileManager GetFile(ACEState aces)
        {
            FileManager tmp;
            if (!fileMngrs.Contains(aces.FileId.ToString()))
            {
                tmp = new FileManager(this, aces.FileId);

                fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, new CacheRefresh(), null);
                if (!LoadedFMs.Contains(aces.FileId.ToString()))
                    LoadedFMs.Add(aces.FileId.ToString());
            }
            else
            {
                tmp = (FileManager)fileMngrs[aces.FileId.ToString()];

            }
            if (tmp.CurrentFile == null || tmp.CurrentFile.RowState == DataRowState.Detached)
            {
                tmp.isMerging = true;
                DataSet ds = null;
                foreach (ACEState.MyDS d1 in aces.MyDataSets)
                {
                    if (d1.DSName == tmp.DB.DataSetName)
                        ds = d1.DS;
                }
                tmp.DB.Merge(ds);
                tmp.isMerging = false;
                tmp.CurrentFile = tmp.DB.EFile.FindByFileId(aces.FileId);
                tmp.LeadOfficeMng = GetOffice(tmp.CurrentFile.LeadOfficeId);

            }

            return tmp;

        }

        public FileManager GetFile(string FullFileNumber)
        {

            FileManager tmp = new FileManager(this, "fullfilenumber", FullFileNumber);
            int fileId = tmp.CurrentFile.FileId;
            if (!fileMngrs.Contains(fileId.ToString()))
            {
                fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, new CacheRefresh(), null);
                //fileMngrs.Add(fileId.ToString(), tmp, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
                if (!LoadedFMs.Contains(fileId.ToString()))
                    LoadedFMs.Add(fileId.ToString());
            }
            else
            {
                tmp = null;
            }

            return (FileManager)fileMngrs.Get(fileId.ToString());

        }

        //private FileManager GetFileByThread(string Thread)
        //{

        //    FileManager tmp = new FileManager(this, "Thread", Thread);
        //    if (tmp.CurrentFile == null)
        //        return null;

        //    int fileId = tmp.CurrentFile.FileId;
        //    if (!fileMngrs.Contains(fileId.ToString()))
        //    {
        //        fileMngrs.Add(fileId.ToString(), tmp, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
        //        if (!LoadedFMs.Contains(fileId.ToString()))
        //            LoadedFMs.Add(fileId.ToString());
        //    }
        //    else
        //    {
        //        tmp = null;
        //    }

        //    return (FileManager)fileMngrs.GetData(fileId.ToString());

        //}

        private Dictionary<string, int> fmFO = new Dictionary<string, int>();
        public FileManager GetFile(string officeFileNo, int officeID)
        {
            string key = officeFileNo + "_" + officeID.ToString();
            int fileId;

            if (fmFO.ContainsKey(key))
            {
                fileId = fmFO[key];
                if (!fileMngrs.Contains(fileId.ToString()))
                {
                    FileManager tmp1 = new FileManager(this, fileId);
                    //fileMngrs.Add(fileId.ToString(), tmp1, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
                    fileMngrs.Add(tmp1.CurrentFile.FileId.ToString(), tmp1, new CacheRefresh(), null);
                    if (!LoadedFMs.Contains(fileId.ToString()))
                        LoadedFMs.Add(fileId.ToString());
                }
            }
            else
            {
                FileManager tmp = new FileManager(this, officeFileNo, officeID);
                fileId = tmp.CurrentFile.FileId;
                if (!fileMngrs.Contains(fileId.ToString()))
                {
                    //fileMngrs.Add(fileId.ToString(), tmp, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemPriority.NotRemovable, new atriumBE.CacheRefresh(), new Microsoft.Practices.EnterpriseLibrary.Caching.Expirations.SlidingTime(TimeSpan.FromMinutes(10)));
                    fileMngrs.Add(tmp.CurrentFile.FileId.ToString(), tmp, new CacheRefresh(), null);
                    if (!LoadedFMs.Contains(fileId.ToString()))
                        LoadedFMs.Add(fileId.ToString());
                }
                else
                {
                    tmp = null;
                }

                fmFO.Add(key, fileId);
            }

            return (FileManager)fileMngrs.Get(fileId.ToString());


        }
        private void ImportDoc(docDB.DocumentRow drIn, docDB.DocumentRow dr)
        {
            //dr.ItemArray = drIn.ItemArray;

            //override defaults from afteradd
            dr.DocContentRow.CreateDate = drIn.DocContentRow.CreateDate;
            dr.efDate = drIn.efDate.Date;

            dr.DocContentRow.Ext = drIn.DocContentRow.Ext;
            dr.DocContentRow.ModDate = drIn.DocContentRow.ModDate;
            if (drIn.DocContentRow.IsSizeNull())
                dr.DocContentRow.Size = 0;
            else
                dr.DocContentRow.Size = drIn.DocContentRow.Size;

            dr.Source = drIn.Source;

            if (drIn.IsefSubjectNull())
                dr.efSubject = "[No subject]";
            else
                dr.efSubject = drIn.efSubject;
            if(!drIn.IsReceivedTimeNull())
                dr.ReceivedTime = drIn.ReceivedTime;
            if (!drIn.IsSentTimeNull())
                dr.SentTime = drIn.SentTime;
            dr.CommMode = drIn.CommMode;
            if (!drIn.IsefTypeNull())
                dr.efType = drIn.efType;
            else
                dr.efType = "NOTE";

            dr.ConversationIndex = drIn.ConversationIndex;
            dr.isElectronic = drIn.isElectronic;
            dr.isPaper = drIn.isPaper;
            dr.IsDraft = drIn.IsDraft;

            //if(!drIn.IsefFromNull())
            //    dr.efFrom = drIn.efFrom;
            //dr.efTo=mail.Recipients.

            //dr.Name = drIn.Name;

            if (drIn.DocContentRow.IsContentsNull())
            {
                switch (dr.DocContentRow.Ext.ToLower())
                {
                    case ".rtf":
                        dr.DocContentRow.ContentsAsText = DocContentBE.RTF;
                        break;
                    case ".txt":
                        dr.DocContentRow.ContentsAsText = "";
                        break;
                    default:
                        dr.DocContentRow.Ext = ".txt";
                        dr.DocContentRow.ContentsAsText = "";
                        break;
                }

            }
            else
                dr.DocContentRow.Contents = drIn.DocContentRow.Contents;

            // 2013-06-12 JLL: update to use isDraft only
            dr.IsDraft = false;
            //dr.DocContentRow.ReadOnly = true;



        }
        private docDB.DocumentRow ImportDoc(docDB.DocumentRow drIn, DocManager dm)
        {
            docDB.DocumentRow dr = dm.DB.Document.NewDocumentRow();
            dm.DB.Document.AddDocumentRow(dr);

            docDB.DocContentRow dcr = dm.DB.DocContent.NewDocContentRow();
            dm.DB.DocContent.AddDocContentRow(dcr);
            dcr.DocId = dr.DocId;

            ImportDoc(drIn, dr);
            dr.FileId = dm.FM.CurrentFile.FileId;

            return dr;

        }
        public int ImportOutlookItems(docDB _ds, bool createBFs, int ImportFileId, ActivityConfig.ACSeriesRow acsr)
        {
            docDB ds = new docDB();
            ds.EnforceConstraints = false;
            ds.Merge(_ds);

            int lastActivityAdded = 0;


            //add docs and recips
            ActivityBP abp = null;
            foreach (docDB.DocumentRow drIn in ds.Document.Select("CommMode='EML' and efType='MEM'"))
            {

                try
                {
                    //search for file based on thread
                    FileManager fm = GetFile(ImportFileId);

                    //check to see if new file needs to be created
                    if (acsr.InitialStep == (int)ACEngine.Step.CreateFile)
                    {
                        FileManager fmParent = fm;
                        fm = CreateFile(fmParent);
                        fm.SourceFile = fmParent;

                    }



                    DocManager dm = fm.GetDocMng();

                    DocumentBE doc = dm.GetDocument();
                    dm.GetDocContent();
                    dm.GetRecipient();
                    dm.GetAttachment();

                    //init activity processm
                    abp = fm.InitActivityProcess();

                    //ignore warning for old mail
                    fm.GetActivity().IgnoreActivityDateWarning = true;

                    //look for activity with same thread
                    atriumDB.ActivityRow[] arsMatch = (atriumDB.ActivityRow[])fm.DB.Activity.Select("ConvIndexBase+ConversationIndex='" + drIn.ConversationIndex + "' or (ConvIndexBase='" + drIn.ConversationIndex + "' and ConversationIndex is null)");
                    if (arsMatch.Length > 0)
                    {
                        //throw new AtriumException("Mail item has already been imported.");
                        //uncomplete bf on item for work as officer
                        foreach (atriumDB.ActivityBFRow abfr in arsMatch[0].GetActivityBFRows())
                        {
                            if (abfr.isMail && !abfr.IsBFOfficerIDNull() && abfr.BFOfficerID == WorkingAsOfficer.OfficerId)
                            {
                                abfr.Completed = false;
                                abfr.BFDate = DateTime.Today;
                                abfr.isRead = false;
                            }
                        }
                        BusinessProcess bp = fm.GetBP();
                        fm.GetActivity().Update(bp);
                        bp.Update();

                    }
                    else
                    {

                        //use abp to create activity
                        //get process if it exists
                        atriumDB.ProcessRow proc = null;

                        atriumDB.ActivityRow[] arsThread = (atriumDB.ActivityRow[])fm.DB.Activity.Select("ConvIndexBase = '" + drIn.ConversationIndex.Substring(0, 44) + "'");

                        int iLen = 0;
                        atriumDB.ActivityRow prevAc = null;
                        if (arsThread.Length > 0)
                            proc = arsThread[0].ProcessRow;

                        foreach (atriumDB.ActivityRow ar in arsThread)
                        {
                            //get most recent message on thread
                            string cdx = ar.ConvIndexBase + ar.ConversationIndex;
                            if (cdx.Length > iLen & cdx.Length < drIn.ConversationIndex.Length)
                            {
                                iLen = cdx.Length;
                                proc = ar.ProcessRow;
                                prevAc = ar;
                            }
                        }

                        ActivityConfig.ACSeriesRow acsrTemp = acsr;

                        //the following is autoconvert code for importing mail
                        //not currently in use
                        //if (prevAc != null)
                        //{
                        //    //check next steps to see if there is a valid convert
                        //    Dictionary<int, CurrentFlow> aps = abp.Workflow.NextSteps(prevAc);
                        //    if (aps.Count > 0)
                        //    {
                        //        atriumBE.CurrentFlow ap = aps[prevAc.ProcessId];
                        //        foreach (NextStep ns in ap.NextSteps.Values)
                        //        {
                        //            ActivityConfig.ACConvertRow[] accs =(ActivityConfig.ACConvertRow[]) acMng.DB.ACConvert.Select("ACSeriesId ="+acsr.ACSeriesId.ToString() +" and AllowableACSeriesId="+ns.acs.ACSeriesId.ToString());
                        //            if (accs.Length == 1)
                        //            {
                        //                acsrTemp = ns.acs;
                        //                break;
                        //            }
                        //        }
                        //    }

                        //}

                        //TODO:  use AutoAC instead of Add - watch out for the send call at the end.  what about how recip bfs get created
                        //import document first then revise!!
                        docDB.DocumentRow dr = (docDB.DocumentRow)dm.GetDocument().Add(fm.CurrentFile);
                        fm.GetDocMng().GetDocContent().Add(dr);
                        ImportEmail(drIn, dm, dr);

                        //autoac has a problem with new files
                        ACEngine ace;// = abp.Add(drIn.efDate.Date, acsrTemp, proc, false, prevAc, drIn.ConversationIndex);
                        //abp.DoAutoAC(prevAc, acsrTemp, 0, ACEngine.RevType.Nothing, drIn.efDate.Date);
                        //ACEngine ace = abp.CurrentACE;
                        atriumDB.ActivityRow newAc;
                        abp.DoACAllSteps(prevAc, acsrTemp, dr.DocId, ACEngine.RevType.Document, drIn.efDate.Date, out ace, out newAc, null, drIn.ConversationIndex);

                        //JLL 2015-05-05 Flag Activity as an Outlook mail 
                        newAc.SendType = "O";

                        // atriumDB.ActivityRow newAc = ace.NewActivity;
                        lastActivityAdded = newAc.ActivityId;
                        newAc.ProcessRow.Active = true;

                        //if (!ace.HasDoc)
                        //{
                        //    //using "import as" may not have related fields
                        //    //    ace.DoRelFields(GetSetting( AppIntSetting.ImportedMailCodeAcId));// ActivityBP.ACImportedMailCodeId);
                        //}
                        //ace.DocumentDefaults(true);

                        //get the document from related fields

                        //docDB.DocumentRow dr = (docDB.DocumentRow)ace.relTables["Document0"][0].Row;
                        //ImportEmail(drIn, dm, dr);

                        //TFS#52162 CJW 2013-8-26
                        //if (!forFiling)
                        //    fm.GetActivity().CalculateBF(newAc, false, true);
                        //else
                        fm.GetActivity().CalculateBF(newAc, true, true);

                        //activity logic will ensure that bfs get created for all internal recipients 

                        //TFS#52162 CJW 2013-8-26
                        //ace.Save(createBFs, true);

                        //abp.CurrentACE = null;

                        fm.GetActivity().IgnoreActivityDateWarning = false;
                    }
                }
                catch (Exception x)
                {
                    if (abp != null)
                        abp.CurrentACE = null;

                    abp.FM.DB.RejectChanges();
                    abp.FM.GetActivity().IgnoreActivityDateWarning = false;
                    abp.FM.GetDocMng().DB.RejectChanges();
                    throw x;

                }
            }
            return lastActivityAdded;
        }

        public void ImportEmail(docDB.DocumentRow drIn, DocManager dm, docDB.DocumentRow dr)
        {
            ImportDoc(drIn, dr);


            foreach (docDB.RecipientRow rrIn in drIn.GetRecipientRows())
            {
                docDB.RecipientRow rr = dm.DB.Recipient.NewRecipientRow();
                rr.ItemArray = rrIn.ItemArray;
                rr.DocId = dr.DocId;

                dm.DB.Recipient.AddRecipientRow(rr);

                //resolve officer from recipient
                officeDB.OfficerRow or = OfficeMng.GetOfficer().LoadByEmail(rr.Address);
                if (or != null)
                {
                    rr.OfficerId = or.OfficerId;
                    rr.OfficeId = or.OfficeId;


                }

                rr.isNewMail = true;
                if (rrIn.AddressType == "DLX")
                    rr.AcceptChanges();

            }


            foreach (docDB.AttachmentRow att in drIn.GetAttachmentRowsByDocument_Attachment())
            {
                //import attached doc
                docDB.DocumentRow drAtt = ImportDoc(att.DocumentRowByDocument_Attachment1, dm);

                //create attachment record
                docDB.AttachmentRow attR = dm.DB.Attachment.NewAttachmentRow();
                attR.MsgId = dr.DocId;
                attR.AttachmentId = drAtt.DocId;
                dm.DB.Attachment.AddAttachmentRow(attR);
            }
        }

        Dictionary<string, List<int>> pkids = new Dictionary<string, List<int>>();
        public int PKIDGet(string obj, int inc)
        {

            //maintain an in memory(for now) list of allocated pkids per object
            if (!pkids.ContainsKey(obj))
            {

                //request 'inc' new ids when list is empty
                object firstAvail;
                if (AppMan.UseService)
                    firstAvail = AppMan.AtriumX().PKIDGet(obj, inc, AppMan.AtriumXCon);
                else
                {
                    try
                    {
                        firstAvail = AppMan.DALMngrX.PKIDGet(obj, inc);
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        AppMan.myDALClient.RecoverDALMngr();
                        firstAvail = AppMan.DALMngrX.PKIDGet(obj, inc);
                    }
                }

                if (firstAvail == null)
                {
                    throw new Exception("PKID not in table");
                }
                else
                {
                    pkids.Add(obj, new List<int>());
                    List<int> lNew = pkids[obj];
                    for (int i = 0; i < inc; i++)
                    {
                        lNew.Add(System.Convert.ToInt32(firstAvail) + i);
                    }
                }
            }
            List<int> l = pkids[obj];
            int id = l[0];
            l.RemoveAt(0);
            if (l.Count == 0)
            {
                pkids.Remove(obj);
            }

            return id;

        }

        public void PKIDSet(string obj,int init)
        {
            if (AppMan.UseService)
                AppMan.AtriumX().PKIDSet(obj, init, AppMan.AtriumXCon);
            else
            {
                try
                {
                    AppMan.DALMngrX.PKIDSet(obj, init);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    AppMan.myDALClient.RecoverDALMngr();
                    AppMan.DALMngrX.PKIDSet(obj, init);
                }
            }

        }
        public void LogError(Exception x1)
        {
            if (x1.InnerException != null)
                LogError(x1.InnerException);
            if (AppMan.UseService)
                AppMan.AtriumX().LogEvent("Error", Environment.UserName, OfficerLoggedOn.UserName, WorkingAsOfficer.UserName, x1.GetType().ToString(), x1.Source, x1.Message, x1.StackTrace,AppMan.AtriumXCon);
            else
            {
                try
                {
                    AppMan.DALMngrX.LogEvent("Error", Environment.UserName, OfficerLoggedOn.UserName, WorkingAsOfficer.UserName, x1.GetType().ToString(), x1.Source, x1.Message, x1.StackTrace);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    AppMan.myDALClient.RecoverDALMngr();
                    AppMan.DALMngrX.LogEvent("Error", Environment.UserName, OfficerLoggedOn.UserName, WorkingAsOfficer.UserName, x1.GetType().ToString(), x1.Source, x1.Message, x1.StackTrace);
                }
            }
        }
        public void LogMessage(string message)
        {
            if (AppMan.UseService)
                AppMan.AtriumX().LogEvent("Message", Environment.UserName, OfficerLoggedOn.UserName, WorkingAsOfficer.UserName, null, null, message, null, AppMan.AtriumXCon);
            else
            {
                try
                {
                    AppMan.DALMngrX.LogEvent("Message", Environment.UserName, OfficerLoggedOn.UserName, WorkingAsOfficer.UserName, null, null, message, Environment.StackTrace);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    AppMan.myDALClient.RecoverDALMngr();
                    AppMan.DALMngrX.LogEvent("Message", Environment.UserName, OfficerLoggedOn.UserName, WorkingAsOfficer.UserName, null, null, message, Environment.StackTrace);
                }
            }
        }

        /// <summary>
        /// This method is used to sync bf records between datasets
        /// It only works after the bf has been saved and committed
        /// </summary>
        /// <param name="abfr"></param>
        /// <param name="syncFile"></param>
        /// <param name="forDelete"></param>
        public void SyncBF(atriumDB.ActivityBFRow abfr, bool syncFile, bool forDelete)
        {
            if (syncFile & fileMngrs.Contains(abfr.FileId.ToString()))
            {
                GetFile(abfr.FileId).SyncBF(abfr, forDelete);
            }
            else if (!syncFile & bfLists.Count > 0)
            {
                //try with the generic filemanager
                foreach (FileManager bffm in bfLists.Values)
                {
                    bffm.SyncBF(abfr, forDelete);
                }
            }
        }

        /// <summary>
        /// This method is used to sync appointment records between datasets
        /// It only works after the appointment has been saved and committed
        /// </summary>
        /// <param name="apptRow"></param>
        /// <param name="syncFile"></param>
        /// <param name="forDelete"></param>
        public void SyncAppointment(atriumDB.AppointmentRow apptRow, bool syncFile, bool forDelete)
        {
            if (syncFile & fileMngrs.Contains(apptRow.FileId.ToString()))
            {
                GetFile(apptRow.FileId).SyncAppointment(apptRow, forDelete);
            }
            else if (!syncFile & bfLists.Count > 0)
            {
                //try with the generic filemanager
                foreach (FileManager bffm in bfLists.Values)
                {
                    bffm.SyncAppointment(apptRow, forDelete);
                }
            }
        }

        #region IDisposable Members

        public override void Dispose()
        {

            fileMngrs.Dispose();

            foreach (FileManager bffm in bfLists.Values)
            {
                bffm.Dispose();
            }

            foreach (OfficeManager om in officeMngrs.Values)
            {
                om.DB.Clear();

            }

            officeMngrs.Clear();

            //myColCodes.Flush();
            myColCodes.Clear();

            DB.Clear();
            CodeDB.Clear();


            myofficeMng = null;

            acMng = null;




        }

        #endregion
        public List<ACEState> SuspendedAcs
        {
            get
            {

                return saves;
            }
            set { saves = value; }
        }

        public void LoadSuspendedAcs()
        {
            saves.Clear();
            if(System.IO.Directory.Exists(AppMan.LawMatePath + "Drafts-Ebauches"))
            {
            foreach (string file in System.IO.Directory.GetFiles(AppMan.LawMatePath + "Drafts-Ebauches","*.lm_save"))
            {
                saves.Add(RestoreACState(file));
            }
            }
        }
        public void DeleteSuspendedAc(ACEState aces)
        {
            string saveas = String.Format("{0}Drafts-Ebauches\\File{1}AC{2}.lm_save", AppMan.LawMatePath, aces.FileId, aces.ActivityId);

            DeleteSuspendedAc(saveas);
        }
        public void DeleteSuspendedAc(string saveas)
        {
            System.IO.File.Delete(saveas);
            LoadSuspendedAcs();
        }
        public string SaveACState(ACEState aces)
        {
            string saveas = SaveFileName(aces.FileId, aces.ActivityId);

            if (true)
            {
                System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(ACEState));
                // To write to a file, create a StreamWriter object.
                using (StreamWriter myWriter = new StreamWriter(saveas))
                {
                    mySerializer.Serialize(myWriter, aces);
                    myWriter.Close();
                }
            }
            else
            {
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Stream stream = new FileStream(saveas, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, aces);
                stream.Close();
            }

            return saveas;
        }

        public string SaveFileName(int fileId, int activityId)
        {
            if (!System.IO.Directory.Exists(AppMan.LawMatePath + "Drafts-Ebauches"))
                System.IO.Directory.CreateDirectory(AppMan.LawMatePath + "Drafts-Ebauches");

            return String.Format("{0}Drafts-Ebauches\\File{1}AC{2}.lm_save", AppMan.LawMatePath, fileId, activityId);
        }
        private ACEState RestoreACState(string fromFile)
        {
            ACEState aces;
            if (true)
            {
                // Construct an instance of the XmlSerializer with the type
                // of object that is being deserialized.
                System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(ACEState));
                // To read the file, create a FileStream.
                using (System.IO.FileStream myFileStream = new System.IO.FileStream(fromFile, System.IO.FileMode.Open))
                {
                    // Call the Deserialize method and cast to the object type.
                    aces = (ACEState)mySerializer.Deserialize(myFileStream);
                    myFileStream.Close();
                }
            }
            else
            {
                System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.Stream stream = new System.IO.FileStream(fromFile, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                aces = (ACEState)formatter.Deserialize(stream);
                stream.Close();

            }
            return aces;
        }



        public DataTable GetGeneralRec(string tableName, WhereClause wc)
        {
            string query = "SELECT * FROM " + tableName + " " + wc.Clause();
            return GetGeneralRec(query);
        }


        public DataTable GetGeneralRec(string query)
        {
            DataSet ds = new DataSet();
            if (AppMan.UseService)
            {
                if (AppMan.Compression)
                {
                    DecompressDataSet(AppMan.AtriumX().GetDataTableByte(query, SerializationFormat.Binary, AppMan.AtriumXCon), ds);
                    return ds.Tables[0];
                }
                else
                    return AppMan.AtriumX().GetDataTable(query, AppMan.AtriumXCon);
            }
            else
            {
                if (this.AppMan.ServerInfo.useRemote)
                {
                   
                    ds = DecompressDataSet(AppMan.DALMngrX.GetDataTable(query, SerializationFormat.Binary), ds);
                    return ds.Tables[0];
                    //return DecompressDataTable(AppMan.DALMngrX.GetDataTable(query, SerializationFormat.Binary), new DataTable());
                }
                else
                    return AppMan.DALMngrX.GetDataTable(query);
            }
        }

        public void ExportDD(string file)
        {
            DataSet ds = new DataSet();
            ds.Merge(DB.ddTable);
            ds.Merge(DB.ddField);
            ds.Merge(DB.ddLookup);
            ds.Merge(DB.ddGeneric);

            SecurityManager.LoadAll(true);
            ds.Merge(SecurityManager.DB.secFeature);
            ds.Merge(SecurityManager.DB.secRule);
            ds.Merge(SecurityManager.DB.secPermission);


            ds.WriteXml(file, XmlWriteMode.WriteSchema);
        }

        public void ImportDD(string file)
        {

            SecurityManager.LoadAll(true);

            DataSet ds = new DataSet();
            ds.ReadXml(file);

            //deletes
            ACManager.DeleteFromTable(DB.ddGeneric, ds.Tables["ddGeneric"]);
            ACManager.DeleteFromTable(DB.ddLookup, ds.Tables["ddLookup"]);
            ACManager.DeleteFromTable(DB.ddField, ds.Tables["ddField"]);
            ACManager.DeleteFromTable(DB.ddTable, ds.Tables["ddTable"]);

            ACManager.DeleteFromTable(SecurityManager.DB.secPermission, ds.Tables["secPermission"]);
            ACManager.DeleteFromTable(SecurityManager.DB.secFeature, ds.Tables["secFeature"]);
            ACManager.DeleteFromTable(SecurityManager.DB.secRule, ds.Tables["secRule"]);

            //updates
            ACManager.ImportTable(DB.ddTable, ds.Tables["ddTable"]);
            ACManager.ImportTable(DB.ddField, ds.Tables["ddField"]);
            ACManager.ImportTable(DB.ddLookup, ds.Tables["ddLookup"]);
            ACManager.ImportTable(DB.ddGeneric, ds.Tables["ddGeneric"]);

            ACManager.ImportTable(SecurityManager.DB.secFeature, ds.Tables["secFeature"]);
            ACManager.ImportTable(SecurityManager.DB.secRule, ds.Tables["secRule"]);
            ACManager.ImportTable(SecurityManager.DB.secPermission, ds.Tables["secPermission"]);

            atLogic.BusinessProcess bpu = GetBP();
            bpu.AddForUpdate(DB.ddTable);
            bpu.AddForUpdate(DB.ddField);
            bpu.AddForUpdate(DB.ddLookup);
            bpu.AddForUpdate(DB.ddGeneric);

            bpu.AddForUpdate(SecurityManager.DB.secFeature);
            bpu.AddForUpdate(SecurityManager.DB.secRule);
            bpu.AddForUpdate(SecurityManager.DB.secPermission);

            bpu.Update();



        }

        public void ExportCodes(string file)
        {
            List<string> tables = new List<string>();
            tables.Add("CaseStatus");
            tables.Add("ContactType");
            tables.Add("RoleCode");
            tables.Add("DecisionType");
            tables.Add("Outcome");
            tables.Add("ReqType");
            tables.Add("ProgramPartyType");
            tables.Add("FlagCode");
            tables.Add("LanguageCode");

            tables.Add("DocDumpType");
            tables.Add("ApptRecurrenceType");
            // peter 22 may 2015 tables.Add("AppealGround");

            tables.Add("FileType");
         //   tables.Add("FileTypeChildren");
            tables.Add("AppSetting");



            ExportCodes(file, tables);
        }
        public void ExportCodes(string file, List<string> tables)
        {
            DataSet ds = new DataSet();
            foreach (string t in tables)
            {
                atLogic.ObjectBE obe = GetCodeTableBE(t);
                obe.Load();
                ds.Merge(obe.myDT);
            }

            ds.WriteXml(file, XmlWriteMode.WriteSchema);

        }

        public void ImportCodes(string file)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(file);

            //deletes
            atLogic.BusinessProcess bpd = GetBP();
            foreach (DataTable dt in ds.Tables)
            {
                atLogic.ObjectBE obe = GetCodeTableBE(dt.TableName);
                obe.Load();
                ACManager.DeleteFromTable(obe.myDT, dt);
                bpd.AddForUpdate(obe);
            }
            bpd.Update();

            //updates
            atLogic.BusinessProcess bpu = GetBP();
            foreach (DataTable dt in ds.Tables)
            {
                atLogic.ObjectBE obe = GetCodeTableBE(dt.TableName);
                obe.Load();
                ACManager.ImportTable(obe.myDT, dt);
                bpu.AddForUpdate(obe);
            }
            bpu.Update();



        }


        public void MassActivity(List<DataRow> toAction, lmDatasets.ActivityConfig.ACSeriesRow acsr, string templateCode, string pathConcatDocument, int revId, ACEngine.RevType revType, Dictionary<string, object> ctx, docDB.DocumentRow copyDoc,lmDatasets.atriumDB.ActivityRow PrototypeAC)
        {
            //create a holding document for the concatented result


            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            tc.CreateControl();
            tc.Text = "";

            if (PrototypeAC != null && pathConcatDocument != null && !PrototypeAC.IsDocIdNull())
            {
                FileManager fm = GetFile(PrototypeAC.FileId);

                int docid=fm.GetDocMng().DB.Document.FindByDocId(PrototypeAC.DocId).DocRefId;
                string contents=fm.GetDocMng().DB.DocContent.FindByDocId(docid).ContentsAsText;

                tc.Append(contents, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewSection);

                
            }


            //process search result
            foreach (lmDatasets.appDB.EFileSearchRow efsr in toAction)
            {

                try
                {
                    FileManager fm = GetFile(efsr.FileId);
                    ActivityBP abp = fm.InitActivityProcess();
                    abp.PrototypeAC = PrototypeAC;
                    DateTime acDate = DateTime.Today;
                    if (PrototypeAC != null)
                        acDate = PrototypeAC.ActivityDate;
               //     abp.TemplateCode = templateCode;
                    abp.ctx = ctx;
                    //make a copy of the document on the target file
                    if (copyDoc != null)
                    {
                        docDB.DocumentRow docCopy = fm.GetDocMng().GetDocument().MakeCopy(copyDoc, fm.CurrentFile, copyDoc.IsDraft);
                        abp.CreateAC(acsr.ACSeriesId, acDate, null, 0, docCopy.DocId, ACEngine.RevType.Document);
                    }
                    else
                    {
                        abp.CreateAC(acsr.ACSeriesId, acDate, null, 0, revId, revType);
                    }

                    if (pathConcatDocument != null && abp.Doc0 != null)
                    {
                        tc.Append(abp.Doc0, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewSection);

                        abp.Doc0 = null;
                    }
             //       abp.TemplateCode = null;
                    abp.ctx = null;
                    abp.PrototypeAC = null;


                    if (AppMan.Language == "ENG")
                        efsr.Result = "Success";
                    else
                        efsr.Result = "Succès";

                    efsr.EndEdit();
                    
                }



                catch (Exception x)
                {
                    LogError(x);
                    if (AppMan.Language == "ENG")
                        efsr.Result = "Failed";
                    else
                        efsr.Result = "Raté";
                    efsr.Message = x.Message;
                    efsr.EndEdit();
                }
            }


            if (pathConcatDocument != null)
            {
                string contentsRTF;

                tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
                System.IO.File.WriteAllText(pathConcatDocument, contentsRTF);
            }

        }
    }

    public class CacheRefresh : CacheItemPolicy
    {
        public CacheRefresh()
        {
            this.SlidingExpiration = TimeSpan.FromMinutes(10);
            this.Priority = CacheItemPriority.Default;
            this.RemovedCallback = new CacheEntryRemovedCallback(this.FileManagerRemovedCallback);

        }
        private void FileManagerRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            FileManager fm = (FileManager)arguments.CacheItem.Value;
            fm.Dispose();
        }
    }

    //public class CacheRefresh : Microsoft.Practices.EnterpriseLibrary.Caching.ICacheItemRefreshAction
    //{
    //    #region ICacheItemRefreshAction Members

    //    void Microsoft.Practices.EnterpriseLibrary.Caching.ICacheItemRefreshAction.Refresh(string removedKey, object expiredValue, Microsoft.Practices.EnterpriseLibrary.Caching.CacheItemRemovedReason removalReason)
    //    {
    //        FileManager fm = (FileManager)expiredValue;
    //        fm.Dispose();
    //        // throw new Exception("The method or operation is not implemented.");
    //    }

    //    #endregion
    //}

    public enum MessageType
    {
        System,
        Mail,
        Alert
    }

    public enum SpecialFileIds
    {
        Inbox = -1,
        SentItems = -2,
        ShortCuts = -3,
        Personal = -4
    }
    public class MessageArgs : EventArgs
    {
        public MessageType Type = MessageType.System;
        public string Message;
    }
    public delegate void AlertHandler(object sender, MessageArgs e);




}
/*
namespace Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class atriumManagerTest
    {
        atriumBE.atriumManager atmng;
        public atriumManagerTest()
        {}

        [SetUp]public void Init()
        {
            atmng=new atriumBE.atriumManager("week.c","doucette","JZ0","E");
        }

        [TearDown]public void Dispose()
        {
            atmng=null;
        }

        [Test]public void Logon()
        {
            atriumBE.atriumManager atmng1=new atriumBE.atriumManager("week.c","doucette","JZ0","E");
		 
        }

        [Test]
        [ExpectedException(typeof(atriumBE.AtriumException))]
        public void LogonBadOffice()
        {
            atriumBE.atriumManager atmng1=new atriumBE.atriumManager("week.c","doucette","999","E");
        }

	
        [Test]
        [ExpectedException(typeof(atSecurity.BadPasswordException))]
        public void LogonBadPwd()
        {
            atriumBE.atriumManager atmng1=new atriumBE.atriumManager("week.c","dotte","JZ0","E");
        }

        [Test]
        public void LogonBadUser()
        {
            try
            {
                atriumBE.atriumManager atmng1=new atriumBE.atriumManager("wec","doucette","JZ0","E");
            }
            catch(atriumBE.AtriumException x)
            {
                if(x.Number()!=atriumBE.AtriumEnum.AppErrorCodes.BadUserName)
                    throw x;
            }
        }

        [Test]public void GetFile()
        {
            atmng.GetFile(40015);
            if(atmng.CurrentFile.FileId!=40015)
                throw new Exception("file not loaded properly");
		 
        }

        [Test]public void GetFileByOfficeFileNum()
        {
            atmng.GetFile("82000-74",841);
            if(atmng.CurrentFile.FileId!=78829 )
                throw new Exception("file not loaded properly");
		 
        }

        [Test]public void CreateNewOffice()
        {

            //get parent file
            atmng.GetFile(5);

            //create efile
            atriumBE.atriumDB.EFileRow er=atmng.DB.EFile.NewEFileRow();
            er.ParentFileId=5;
            atmng.DB.EFile.AddEFileRow(er);
            er.BeginEdit();
            er.NameE="test office";
            er.NameF="test office";

            //create office
            atriumBE.officeDB.OfficeRow or=atmng.DB.Office.NewOfficeRow();
            atmng.DB.Office.AddOfficeRow(or);
            or.BeginEdit();
            or.OfficeCode="TEST1";
            or.OfficeName="Test office";
            or.OfficeTypeCode="D";
            or.Active=true;
            or.IsOnLine=true;
            or.ReappointedDate=DateTime.Today;
            or.UsesBilling=true;
            or.EndEdit();

            //fileid to neg officeid
            er.FileId=-or.OfficeId;
            er.EndEdit();

            //create address
            atriumBE.atriumDB.AddressRow ar=or.AddressRow;//atmng.DB.Address.NewAddressRow();
            //atmng.DB.Address.AddAddressRow(ar);
            ar.BeginEdit();
            ar.Address1="1 main";
            ar.City="Ottawa";
            ar.CountryCode="CDN";
            ar.PostalCode="H0H0H0";
            ar.ProvinceCode="ON";
            ar.EndEdit();

            //hookup address
            //or.AddressId=ar.AddressId;

            //create fileoffice
            atmng.GetFileOffice().AddOfficeToFile(or.OfficeId,"LO");

            atmng.EFile.Update();
            atmng.GetAddress().Update();
            atmng.GetOffice().Update();
            atmng.GetFileOffice().Update();

            if(atmng.DB.HasErrors)
            {
                AtMng.AppMan.Rollback();
                throw new Exception("Couldn't create new office");
            }
            else
                atmng.Commit();
        }
    }
}
*/



