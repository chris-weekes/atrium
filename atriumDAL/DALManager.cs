using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;
using System.Collections.Generic;

namespace atriumDAL
{
	/// <summary>
	/// Summary description for DALManager.
	/// </summary>
    /// 

	public class atriumDALManager:atDAL.DALManager
	{

       
        public atriumDALManager(System.Net.NetworkCredential nc, string dbConnect)
            : base(nc, dbConnect)
        {
        }

     
        public atriumDALManager(string user, string pwd, string dbConnect)
            : base(user, pwd,dbConnect)
        {
           // LogEvent("Logon", Environment.UserName, user, null, null, null, null, null);
        }

        public TaxRateDAL GetTaxRate()
        {
            return new TaxRateDAL(this);
        }
        public InsolvencyPeriodDAL GetInsolvencyPeriod()
        {
            return new InsolvencyPeriodDAL(this);
        }

        public ddRuleDAL GetddRule()
        {
            return new ddRuleDAL(this);
        }
        public MsgDAL GetMsg()
        {
            return new MsgDAL(this);
        }
        public SearchDAL GetSearch()
        {
            return new SearchDAL(this);
        }
        public SearchTermDAL GetSearchTerm()
        {
            return new SearchTermDAL(this);
        }

        public ApptRecurrenceDAL GetApptRecurrence()
        {
            return new ApptRecurrenceDAL(this);
        }

        public ApptRecurrenceTypeDAL GetApptRecurrenceType()
        {
            return new ApptRecurrenceTypeDAL(this);
        }

        public DocDumpTypeDAL GetDocDumpType()
        {
            return new DocDumpTypeDAL(this);
        }

        public OutlookCalAppMsgDAL GetOutlookCalAppMsg()
        {
            return new OutlookCalAppMsgDAL(this);
        }

        public FlagCodeDAL GetFlagCode()
        {
            return new FlagCodeDAL(this);
        }
        
        public SSTAppealGroundDAL GetSSTAppealGround()
        {
            return new SSTAppealGroundDAL(this);
        }

        public FileFlagDAL GetFileFlag()
        {
            return new FileFlagDAL(this);
        }

        public AppealGroundDAL GetAppealGround()
        {
            return new AppealGroundDAL(this);
        }

        public DocTypeUseDAL GetDocTypeUse()
        {
            return new DocTypeUseDAL(this);
        }

        public TribunalMemberAssignmentDAL GetTribunalMemberAssignment()
        {
            return new TribunalMemberAssignmentDAL(this);
        }

        public CaseMajorStatusDAL GetCaseMajorStatus()
        {
            return new CaseMajorStatusDAL(this);
        }

        public ddGenericDAL GetddGeneric()
        {
            return new ddGenericDAL(this);
        }
        public ddEntityDAL GetddEntity()
        {
            return new ddEntityDAL(this);
        }
        public ddLookupDAL GetddLookup()
        {
            return new ddLookupDAL(this);
        }
        public ACSeriesTypeDAL GetACSeriesType()
        {
            return new ACSeriesTypeDAL(this);
        }
        public ACControlTypeDAL GetACControlType()
        {
            return new ACControlTypeDAL(this);
        }
        public ACTaskTypeDAL GetACTaskType()
        {
            return new ACTaskTypeDAL(this);
        }
        public ACDependencyTypeDAL GetACDependencyType()
        {
            return new ACDependencyTypeDAL(this);
        }
        public SeriesStatusDAL GetSeriesStatus()
        {
            return new SeriesStatusDAL(this);
        }
        public SeriesPackageDAL GetSeriesPackage()
        {
            return new SeriesPackageDAL(this);
        }
        public ServiceCentreDAL GetServiceCentre()
        {
            return new ServiceCentreDAL(this);
        }

        public AdjournmentReasonDAL GetAdjournmentReason()
        {
            return new AdjournmentReasonDAL(this);
        }


         


        public PostalCodeLocationDAL GetPostalCodeLocation()
        {
            return new PostalCodeLocationDAL(this);
        }
        public ProgramDAL GetProgram()
        {
            return new ProgramDAL(this);
        }

        public SSTGroupDAL GetSSTGroup()
        {
            return new SSTGroupDAL(this);
        }
        
        public LocationDAL GetLocation()
        {
            return new LocationDAL(this);
        }

        public DecisionTypeDAL GetDecisionType()
        {
            return new DecisionTypeDAL(this);
        }
        public HearingStatusDAL GetHearingStatus()
        {
            return new HearingStatusDAL(this);
        }

        public ProgramIssueDAL GetProgramIssue()
        {
            return new ProgramIssueDAL(this);
        }

        public ProgramPartyTypeDAL GetProgramPartyType()
        {
            return new ProgramPartyTypeDAL(this);
        }
			
        public ReqTypeDAL GetReqType()
        {
            return new ReqTypeDAL(this);
        }
        public SSTDecisionDAL GetSSTDecision()
        {
            return new SSTDecisionDAL(this);
        }

        public SSTRequestDAL GetSSTRequest()
        {
            return new SSTRequestDAL(this);
        }
        public SSTReqRecipientDAL GetSSTReqRecipient()
        {
            return new SSTReqRecipientDAL(this);
        }

        public ProcessContextDAL GetProcessContext()
        {
            return new ProcessContextDAL(this);
        }

        public LateIgnoreReasonDAL GetLateIgnoreReason()
        {
            return new LateIgnoreReasonDAL(this);
        }

        public LeaveToAppealTypeDAL GetLeaveToAppealType()
        {
            return new LeaveToAppealTypeDAL(this);
        }

        public hlpImageDAL GethlpImage()
        {
            return new hlpImageDAL(this);
        }

        public hlpPageDAL GethlpPage()
        {
            return new hlpPageDAL(this);
        }

        public hlpXmlDAL GethlpXml()
        {
            return new hlpXmlDAL(this);
        }

        public secUserDAL GetsecUser()
        {
            return new secUserDAL(this);
        }

        public secMembershipDAL GetsecMembership()
        {
            return new secMembershipDAL(this);
        }
        public secPermissionDAL GetsecPermission()
        {
            return new secPermissionDAL(this);
        }

        public secPermLevelDAL GetsecPermLevel()
        {
            return new secPermLevelDAL(this);
        }
        public secGroupDAL GetsecGroup()
        {
            return new secGroupDAL(this);
        }

        public secFeatureDAL GetsecFeature()
        {
            return new secFeatureDAL(this);
        }

        public secFileRuleDAL GetsecFileRule()
        {
            return new secFileRuleDAL(this);
        }
        public secRuleDAL GetsecRule()
        {
            return new secRuleDAL(this);
        }

        public CaseStatusDAL GetCaseStatus()
        {
            return new CaseStatusDAL(this);
        }

        public FormHearingDAL GetFormHearing()
        {
            return new FormHearingDAL(this);
        }

        public HearingDAL GetHearing()
        {
            return new HearingDAL(this);
        }
        public ProvisionDAL GetProvision()
        {
            return new ProvisionDAL(this);
        }

        public LegislationDAL GetLegislation()
        {
            return new LegislationDAL(this);
        }

        public OutcomeDAL GetOutcome()
        {
            return new OutcomeDAL(this);
        }

        public ADMSEAppealDAL GetADMSEAppeal()
        {
            return new ADMSEAppealDAL(this);
        }

        public ADMSEDecisionDAL GetADMSEDecision()
        {
            return new ADMSEDecisionDAL(this);
        }

        public ADMSEIssuesDAL GetADMSEIssues()
        {
            return new ADMSEIssuesDAL(this);
        }

        public ADMSEParticipantDAL GetADMSEParticipant()
        {
            return new ADMSEParticipantDAL(this);
        }

        public ADMSPAppealDAL GetADMSPAppeal()
        {
            return new ADMSPAppealDAL(this);
        }

        public ADMSPDecisionDAL GetADMSPDecision()
        {
            return new ADMSPDecisionDAL(this);
        }

        public ADMSPIssuesDAL GetADMSPIssues()
        {
            return new ADMSPIssuesDAL(this);
        }

        public ADMSPParticipantDAL GetADMSPParticipant()
        {
            return new ADMSPParticipantDAL(this);
        }
	
        public MapDAL GetMap()
        {
            return new MapDAL(this);
        }

        public AppointmentDAL GetAppointment()
        {
            return new AppointmentDAL(this);
        }
        public AttendeeDAL GetAttendee()
        {
            return new AttendeeDAL(this);
        }
        public AppSettingDAL GetAppSetting()
        {
            return new AppSettingDAL(this);
        }
        public AppealLevelDAL GetAppealLevel()
        {
            return new AppealLevelDAL(this);
        }
        public NativeLanguageDAL GetNativeLanguage()
        {
            return new NativeLanguageDAL(this);
        }
        public CrisisTypeDAL GetCrisisType()
        {
            return new CrisisTypeDAL(this);
        }
        public AppealTypeDAL GetAppealType()
        {
            return new AppealTypeDAL(this);
        }
        public AppelantSourceDAL GetAppelantSource()
        {
            return new AppelantSourceDAL(this);
        }
        public HearingMethodDAL GetHearingMethod()
        {
            return new HearingMethodDAL(this);
        }

        public SSTCaseDAL GetSSTCase()
        {
            return new SSTCaseDAL(this);
        }

        public SSTCaseMatterDAL GetSSTCaseMatter()
        {
            return new SSTCaseMatterDAL(this);
        }

        public FilePartyDAL GetFileParty()
        {
            return new FilePartyDAL(this);
        }

        
        public ActivityAttributionDAL GetActivityAttribution()
        {
            return new ActivityAttributionDAL(this);
        }
        public BankruptcyAccountDAL GetBankruptcyAccount()
        {
            return new BankruptcyAccountDAL(this);
        }
        public InsolvencyAccountDAL GetInsolvencyAccount()
        {
            return new InsolvencyAccountDAL(this);
        }
        public HardshipDAL GetHardship()
        {
            return new HardshipDAL(this);
        }
        public CompOfferDAL GetCompOffer()
        {
            return new CompOfferDAL(this);
        }
        public CompOfferDetailDAL GetCompOfferDetail()
        {
            return new CompOfferDetailDAL(this);
        }
        public EventLogDAL GetEventLog()
        {
            return new EventLogDAL(this);
        }
        public FilePeriodDAL GetFilePeriod()
        {
            return new FilePeriodDAL(this);
        }

        public FileTypeChildrenDAL GetFileTypeChildren()
        {
            return new FileTypeChildrenDAL(this);
        }
        public MetaTypeChildrenDAL GetMetaTypeChildren()
        {
            return new MetaTypeChildrenDAL(this);
        }
        public OfficerPrefsDAL GetOfficerPrefs()
        {
            return new OfficerPrefsDAL(this);
        }
        public SecurityLevelDAL GetSecurityLevel()
        {
            return new SecurityLevelDAL(this);
        }

        public ACFileTypeDAL GetACFileType()
        {
            return new ACFileTypeDAL(this);
        }
        public ACMenuDAL GetACMenu()
        {
            return new ACMenuDAL(this);
        }
        public MenuDAL GetMenu()
        {
            return new MenuDAL(this);
        }

        public DepartmentDAL GetDepartment()
        {
            return new DepartmentDAL(this);
        }
        public ListDAL GetList()
        {
            return new ListDAL(this);
        }
        public ListMemberDAL  GetListMember()
        {
            return new ListMemberDAL (this);
        }

        FileAKADAL myFileAKA;
        public FileAKADAL GetFileAKA()
        {
            if(myFileAKA==null)
                myFileAKA=new FileAKADAL(this);

            return myFileAKA;
        }
        public OfficeMandateDAL GetOfficeMandate()
        {
            return new OfficeMandateDAL(this);
        }
        public ACMajorDAL GetACMajor()
        {
            return new ACMajorDAL(this);
        }
        public FileMetaTypeDAL GetFileMetaType()
        {
            return new FileMetaTypeDAL(this);
        }

        public ACBFDAL GetACBF()
        {
            return new ACBFDAL(this);
        }

        public ACDocumentationDAL GetACDocumentation()
        {
            return new ACDocumentationDAL(this);
        }

        public AccessTypeDAL GetAccessType()
        {
            return new AccessTypeDAL(this);
        }

        public ACConvertDAL GetACConvert()
        {
            return new ACConvertDAL(this);
        }

        public AccountHistoryDAL GetAccountHistory()
        {
            return new AccountHistoryDAL(this);
        }

        //public AccountHistoryAuditDAL GetAccountHistoryAudit()
        //{
        //    return new AccountHistoryAuditDAL(this);
        //}

        public AccountTypeDAL GetAccountType()
        {
            return new AccountTypeDAL(this);
        }

        public ACDependencyDAL GetACDependency()
        {
            return new ACDependencyDAL(this);
        }

        public ACDisbDAL GetACDisb()
        {
            return new ACDisbDAL(this);
        }

        //public ACMandateDAL GetACMandate()
        //{
        //    return new ACMandateDAL(this);
        //}

        public ACSeriesDAL GetACSeries()
        {
            return new ACSeriesDAL(this);
        }

        //public ACTemplateDAL GetACTemplate()
        //{
        //    return new ACTemplateDAL(this);
        //}

        public ActivityDAL GetActivity()
        {
            return new ActivityDAL(this);
        }

        //public ActivityAuditDAL GetActivityAudit()
        //{
        //    return new ActivityAuditDAL(this);
        //}

        public ActivityBFDAL GetActivityBF()
        {
            return new ActivityBFDAL(this);
        }

        public ActivityCodeDAL GetActivityCode()
        {
            return new ActivityCodeDAL(this);
        }

        //public ActivityCodeFileTypeDAL GetActivityCodeFileType()
        //{
        //    return new ActivityCodeFileTypeDAL(this);
        //}

        //public ActivityCodeOfficeTypeDAL GetActivityCodeOfficeType()
        //{
        //    return new ActivityCodeOfficeTypeDAL(this);
        //}

        //public ActivityCompletedDAL GetActivityCompleted()
        //{
        //    return new ActivityCompletedDAL(this);
        //}

        //public ActivityDetailDAL GetActivityDetail()
        //{
        //    return new ActivityDetailDAL(this);
        //}

        public ActivityFieldDAL GetActivityField()
        {
            return new ActivityFieldDAL(this);
        }

        public ActivityTimeDAL GetActivityTime()
        {
            return new ActivityTimeDAL(this);
        }

        public ActivityXRefDAL GetActivityXRef()
        {
            return new ActivityXRefDAL(this);
        }

        public AddressDAL GetAddress()
        {
            return new AddressDAL(this);
        }

        public AddressSourceDAL GetAddressSource()
        {
            return new AddressSourceDAL(this);
        }

        public AddressTypeDAL GetAddressType()
        {
            return new AddressTypeDAL(this);
        }

        public AKADAL GetAKA()
        {
            return new AKADAL(this);
        }

        public AppointmentNotificationDAL GetAppointmentNotification()
        {
            return new AppointmentNotificationDAL(this);
        }

        public AppointmentTypeDAL GetAppointmentType()
        {
            return new AppointmentTypeDAL(this);
        }

        public ArchiveBatchDAL GetArchiveBatch()
        {
            return new ArchiveBatchDAL(this);
        }

        public AttachmentDAL GetAttachment()
        {
            return new AttachmentDAL(this);
        }

        public BankruptcyDAL GetBankruptcy()
        {
            return new BankruptcyDAL(this);
        }

        public BankruptcyOrderTypeDAL GetBankruptcyOrderType()
        {
            return new BankruptcyOrderTypeDAL(this);
        }

        public BatchDAL GetBatch()
        {
            return new BatchDAL(this);
        }

        //public BFListDAL GetBFList()
        //{
        //    return new BFListDAL(this);
        //}

        public BFTypeDAL GetBFType()
        {
            return new BFTypeDAL(this);
        }

        public BillingCodeDAL GetBillingCode()
        {
            return new BillingCodeDAL(this);
        }

        public CashBlotterDAL GetCashBlotter()
        {
            return new CashBlotterDAL(this);
        }

        public CBDetailDAL GetCBDetail()
        {
            return new CBDetailDAL(this);
        }

        public CBInstrumentTypeDAL GetCBInstrumentType()
        {
            return new CBInstrumentTypeDAL(this);
        }

        public CBNatureOfPaymentDAL GetCBNatureOfPayment()
        {
            return new CBNatureOfPaymentDAL(this);
        }

        public CBPaymentSourceDAL GetCBPaymentSource()
        {
            return new CBPaymentSourceDAL(this);
        }

        public CBStatusDAL GetCBStatus()
        {
            return new CBStatusDAL(this);
        }

        public CityDAL GetCity()
        {
            return new CityDAL(this);
        }

        public CommModeDAL GetCommMode()
        {
            return new CommModeDAL(this);
        }

        public CommTypeDAL GetCommType()
        {
            return new CommTypeDAL(this);
        }

        public ContactDAL GetContact()
        {
            return new ContactDAL(this);
        }

        public ContactEmailDAL GetContactEmail()
        {
            return new ContactEmailDAL(this);
        }

        public ContactTypeDAL GetContactType()
        {
            return new ContactTypeDAL(this);
        }

        public ContactTypePositionCodeDAL GetContactTypePositionCode()
        {
            return new ContactTypePositionCodeDAL(this);
        }

        public ConversationWithCodeDAL GetConversationWithCode()
        {
            return new ConversationWithCodeDAL(this);
        }

        public CostDAL GetCost()
        {
            return new CostDAL(this);
        }

        public CountryDAL GetCountry()
        {
            return new CountryDAL(this);
        }

        public CurrencyCodeDAL GetCurrencyCode()
        {
            return new CurrencyCodeDAL(this);
        }

        public ddFieldDAL GetddField()
        {
            return new ddFieldDAL(this);
        }

        public ddTableDAL GetddTable()
        {
            return new ddTableDAL(this);
        }

        public DebtDAL GetDebt()
        {
            return new DebtDAL(this);
        }

        public DebtorDAL GetDebtor()
        {
            return new DebtorDAL(this);
        }

        public FileAccessDAL GetFileAccess()
        {
            return new FileAccessDAL(this);
        }

        //public DepartmentDAL GetDepartment()
        //{
        //    return new DepartmentDAL(this);
        //}

        public DisbursementDAL GetDisbursement()
        {
            return new DisbursementDAL(this);
        }

        //public DisbursementAuditDAL GetDisbursementAudit()
        //{
        //    return new DisbursementAuditDAL(this);
        //}

        public DisbursementTypeDAL GetDisbursementType()
        {
            return new DisbursementTypeDAL(this);
        }

        public DispositionAuthorityDAL GetDispositionAuthority()
        {
            return new DispositionAuthorityDAL(this);
        }

        //public DocDetailDAL GetDocDetail()
        //{
        //    return new DocDetailDAL(this);
        //}

        public DocTypeDAL GetDocType()
        {
            return new DocTypeDAL(this);
        }

        public DocTypeMajorDAL GetDocTypeMajor()
        {
            return new DocTypeMajorDAL(this);
        }

        public DocumentDAL GetDocument()
        {
            return new DocumentDAL(this);
        }

        public DocContentDAL GetDocContent()
        {
            return new DocContentDAL(this);
        }
        public DocXRefDAL GetDocXRef()
        {
            return new DocXRefDAL(this);
        }

        EFileDAL myEfileDAL;
        public EFileDAL GetEFile()
        {
            if (myEfileDAL == null)
                myEfileDAL = new EFileDAL(this);

            return myEfileDAL;
            //return new EFileDAL(this);
        }

        //public EFileAuditDAL GetEFileAudit()
        //{
        //    return new EFileAuditDAL(this);
        //}

        //public FileAccessDAL GetFileAccess()
        //{
        //    return new FileAccessDAL(this);
        //}

        public FileAccountDAL GetFileAccount()
        {
            return new FileAccountDAL(this);
        }

        //public FileAccountAuditDAL GetFileAccountAudit()
        //{
        //    return new FileAccountAuditDAL(this);
        //}

        public FileContactDAL GetFileContact()
        {
            return new FileContactDAL(this);
        }

        public FileFormatDAL GetFileFormat()
        {
            return new FileFormatDAL(this);
        }

        public FileHistoryDAL GetFileHistory()
        {
            return new FileHistoryDAL(this);
        }

        //public FileHistoryAuditDAL GetFileHistoryAudit()
        //{
        //    return new FileHistoryAuditDAL(this);
        //}

        //public FileIndexDAL GetFileIndex()
        //{
        //    return new FileIndexDAL(this);
        //}

        public FileOfficeDAL GetFileOffice()
        {
            return new FileOfficeDAL(this);
        }

        //public FileOfficeAuditDAL GetFileOfficeAudit()
        //{
        //    return new FileOfficeAuditDAL(this);
        //}

        public FileTypeDAL GetFileType()
        {
            return new FileTypeDAL(this);
        }

        public FileXRefDAL GetFileXRef()
        {
            return new FileXRefDAL(this);
        }

        //public HearingDAL GetHearing()
        //{
        //    return new HearingDAL(this);
        //}

        //public HearingContactDAL GetHearingContact()
        //{
        //    return new HearingContactDAL(this);
        //}

        //public HearingSetDAL GetHearingSet()
        //{
        //    return new HearingSetDAL(this);
        //}

        public HistoryTypeDAL GetHistoryType()
        {
            return new HistoryTypeDAL(this);
        }

        public InsolvencyDAL GetInsolvency()
        {
            return new InsolvencyDAL(this);
        }

        public InsolvencyTypeDAL GetInsolvencyType()
        {
            return new InsolvencyTypeDAL(this);
        }

        public InterestRateTypeDAL GetInterestRateType()
        {
            return new InterestRateTypeDAL(this);
        }

        public IRPDAL GetIRP()
        {
            return new IRPDAL(this);
        }

        //public IRPAuditDAL GetIRPAudit()
        //{
        //    return new IRPAuditDAL(this);
        //}

        public IssueDAL GetIssue()
        {
            return new IssueDAL(this);
        }

        public JudgmentDAL GetJudgment()
        {
            return new JudgmentDAL(this);
        }

        public JudgmentAccountDAL GetJudgmentAccount()
        {
            return new JudgmentAccountDAL(this);
        }

        public JudgmentCourtLevelDAL GetJudgmentCourtLevel()
        {
            return new JudgmentCourtLevelDAL(this);
        }

        public JudgmentTypeDAL GetJudgmentType()
        {
            return new JudgmentTypeDAL(this);
        }

        //public JudicialDistrictDAL GetJudicialDistrict()
        //{
        //    return new JudicialDistrictDAL(this);
        //}

        public LanguageCodeDAL GetLanguageCode()
        {
            return new LanguageCodeDAL(this);
        }

        public LegalProcessDAL GetLegalProcess()
        {
            return new LegalProcessDAL(this);
        }

        public LPDAL GetLP()
        {
            return new LPDAL(this);
        }

        //public MailDAL GetMail()
        //{
        //    return new MailDAL(this);
        //}

        //public MailAuditDAL GetMailAudit()
        //{
        //    return new MailAuditDAL(this);
        //}

        //public MailFolderDAL GetMailFolder()
        //{
        //    return new MailFolderDAL(this);
        //}

 
        public MilestoneCodeDAL GetMilestoneCode()
        {
            return new MilestoneCodeDAL(this);
        }

        //public MotionDAL GetMotion()
        //{
        //    return new MotionDAL(this);
        //}

        public NatureofPropertyDAL GetNatureofProperty()
        {
            return new NatureofPropertyDAL(this);
        }

        public OfficeDAL GetOffice()
        {
            return new OfficeDAL(this);
        }

        public Office2JDDAL GetOffice2JD()
        {
            return new Office2JDDAL(this);
        }

        public OfficeAccountDAL GetOfficeAccount()
        {
            return new OfficeAccountDAL(this);
        }

        //public OfficeAccountAuditDAL GetOfficeAccountAudit()
        //{
        //    return new OfficeAccountAuditDAL(this);
        //}

        public OfficeAccountTypeDAL GetOfficeAccountType()
        {
            return new OfficeAccountTypeDAL(this);
        }

        public MemberProfileDAL GetMemberProfile()
        {
            return new MemberProfileDAL(this);
        }

        public OfficerDAL GetOfficer()
        {
            return new OfficerDAL(this);
        }

        public OfficerDelegateDAL GetOfficerDelegate()
        {
            return new OfficerDelegateDAL(this);
        }

        public OfficerRoleDAL GetOfficerRole()
        {
            return new OfficerRoleDAL(this);
        }

        public OfficeTypeDAL GetOfficeType()
        {
            return new OfficeTypeDAL(this);
        }

        public OpinionDAL GetOpinion()
        {
            return new OpinionDAL(this);
        }

        //public PanelDAL GetPanel()
        //{
        //    return new PanelDAL(this);
        //}

        //public PanelContactDAL GetPanelContact()
        //{
        //    return new PanelContactDAL(this);
        //}

        //public PKIDDAL GetPKID()
        //{
        //    return new PKIDDAL(this);
        //}

        public PLOfficeDAL GetPLOffice()
        {
            return new PLOfficeDAL(this);
        }

        public PositionCodeDAL GetPositionCode()
        {
            return new PositionCodeDAL(this);
        }

        public PostJudgmentActivityDAL GetPostJudgmentActivity()
        {
            return new PostJudgmentActivityDAL(this);
        }

        public ProcessDAL GetProcess()
        {
            return new ProcessDAL(this);
        }

        public ProcessTypeDAL GetProcessType()
        {
            return new ProcessTypeDAL(this);
        }

        //public ProgramDAL GetProgram()
        //{
        //    return new ProgramDAL(this);
        //}

        public PropertyDAL GetProperty()
        {
            return new PropertyDAL(this);
        }

        public ProvinceDAL GetProvince()
        {
            return new ProvinceDAL(this);
        }

        public RAClientImpactDAL GetRAClientImpact()
        {
            return new RAClientImpactDAL(this);
        }

        public RAClientImpactTypeDAL GetRAClientImpactType()
        {
            return new RAClientImpactTypeDAL(this);
        }

        public RAComplexityDAL GetRAComplexity()
        {
            return new RAComplexityDAL(this);
        }

        public RAImpactDAL GetRAImpact()
        {
            return new RAImpactDAL(this);
        }

        public RALikelihoodDAL GetRALikelihood()
        {
            return new RALikelihoodDAL(this);
        }

        public RARiskLevelDAL GetRARiskLevel()
        {
            return new RARiskLevelDAL(this);
        }

        public RASettlementPossibilityDAL GetRASettlementPossibility()
        {
            return new RASettlementPossibilityDAL(this);
        }

        public RAStatusDAL GetRAStatus()
        {
            return new RAStatusDAL(this);
        }

        public ReasonCodeDAL GetReasonCode()
        {
            return new ReasonCodeDAL(this);
        }

        public RecipientDAL GetRecipient()
        {
            return new RecipientDAL(this);
        }

        public ReturnCodeDAL GetReturnCode()
        {
            return new ReturnCodeDAL(this);
        }

        public RiskAssessmentDAL GetRiskAssessment()
        {
            return new RiskAssessmentDAL(this);
        }

        public RoleCodeDAL GetRoleCode()
        {
            return new RoleCodeDAL(this);
        }

        //public secFeatureDAL GetsecFeature()
        //{
        //    return new secFeatureDAL(this);
        //}

        //public secFeatureTypeDAL GetsecFeatureType()
        //{
        //    return new secFeatureTypeDAL(this);
        //}

        //public secFileRuleDAL GetsecFileRule()
        //{
        //    return new secFileRuleDAL(this);
        //}

        //public secGroupDAL GetsecGroup()
        //{
        //    return new secGroupDAL(this);
        //}

        //public secMembershipDAL GetsecMembership()
        //{
        //    return new secMembershipDAL(this);
        //}

        //public secPermissionDAL GetsecPermission()
        //{
        //    return new secPermissionDAL(this);
        //}

        //public secPermLevelDAL GetsecPermLevel()
        //{
        //    return new secPermLevelDAL(this);
        //}

        //public secRuleDAL GetsecRule()
        //{
        //    return new secRuleDAL(this);
        //}

        //public secUserDAL GetsecUser()
        //{
        //    return new secUserDAL(this);
        //}

        public SeriesDAL GetSeries()
        {
            return new SeriesDAL(this);
        }

        public SeriesTypeDAL GetSeriesType()
        {
            return new SeriesTypeDAL(this);
        }

        public SexDAL GetSex()
        {
            return new SexDAL(this);
        }

        public SRPDAL GetSRP()
        {
            return new SRPDAL(this);
        }

        //public SRPAuditDAL GetSRPAudit()
        //{
        //    return new SRPAuditDAL(this);
        //}

        public StatusDAL GetStatus()
        {
            return new StatusDAL(this);
        }

        public TaxingDAL GetTaxing()
        {
            return new TaxingDAL(this);
        }

        public TemplateDAL GetTemplate()
        {
            return new TemplateDAL(this);
        }

        public TypeofWritDAL GetTypeofWrit()
        {
            return new TypeofWritDAL(this);
        }

        public WritDAL GetWrit()
        {
            return new WritDAL(this);
        }

        public WritHistoryDAL GetWritHistory()
        {
            return new WritHistoryDAL(this);
        }

        public appDB.ContactSearchDataTable ContactSearch(string where)
        {
            DataSet ds = this.ExecuteDataset("ContactSearchByLastName", where);
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;

            appDB.ContactSearchDataTable dt = new appDB.ContactSearchDataTable();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return dt;
        }

        public appDB.ContactSearchDataTable PartySearch(string where)
        {
            DataSet ds = this.ExecuteDataset("PartySearchByName", where);
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;

            appDB.ContactSearchDataTable dt = new appDB.ContactSearchDataTable();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return dt;
        }

        public byte[] FileSearch(string userName, DateTime dateStart, DateTime dateEnd)
        {
            DataSet ds = this.ExecuteDataset("FileSearchRecentFiles", userName, dateStart, dateEnd);

           

            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;

            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return CompressData( dt);

        }
        public byte[] FileSearch(string where, bool includeXrefs)
        {
            DataSet ds = this.ExecuteDataset("FileSearchXref", where, includeXrefs);
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;
            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return CompressData(dt);
        }
        public byte[] FileSearch(string where, string whereContact, string whereCaseStatus, bool includeXrefs)
        {
            DataSet ds = this.ExecuteDataset("FileSearchXref", where, whereContact, whereCaseStatus, includeXrefs);
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;
            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return CompressData(dt);
        }

        public byte[] FileSearchByThread(string keyword, int officeId)
        {
            DataSet ds = this.ExecuteDataset("FileSearchByThread", keyword, officeId);
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;
            appDB.EFileSearchThreadDataTable dt = new appDB.EFileSearchThreadDataTable();
            dt.Constraints.Clear();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return CompressData(dt);

        }
        public byte[] FileSearch(string search, string keyword, int officeId)
		{
			string spName;
			switch( search)
			{
                case "ICASE":
                    spName = "FileSearchByICASENumber";
                    break;
                case "ParentFile":
                    spName = "FileSearchFindParentFile";
                    break;
                case "FileId":
                    spName = "FileSearchByFileId";
                    break;
                case "ParentFileId":
                    spName="FileSearchByParentFileId";
                    break;
				case "SIN":
					spName="FileSearchBySIN";
					break;
				case "OfficeFileNum":
					spName="FileSearchByOfficeFileNum";
					break;
				case "LastName":
					spName="FileSearchByLastName";
					break;
                case "LastNameExact":
                    spName = "FileSearchByLastNameExact";
                    break;
                case "FileNumber":
					spName="FileSearchByFileNumber";
					break;
                case "FullFileNumber":
                    spName = "FileSearchByFullFileNumber";
                    break;
                case "FullFileName":
                    spName = "FileSearchByFullFileName";
                    break;
				default:
					spName="FileSearchByKeyword";
					break;
			}
//			DataSet ds=this.ExecuteDataset( spName, new SqlParameter("@keyword", keyword), new SqlParameter("@officeid",officeId));
			DataSet ds=this.ExecuteDataset( spName,  keyword,officeId);
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.Tables[0].RemotingFormat = SerializationFormat.Binary;
//			if(base.myTrans==null)
//				ds=SqlHelper.ExecuteDataset(this.SqlCon, CommandType.StoredProcedure, spName, new SqlParameter("@keyword", keyword), new SqlParameter("@officeid",officeId));
//			else
//				ds=SqlHelper.ExecuteDataset(this.myTrans, CommandType.StoredProcedure, spName, new SqlParameter("@keyword", keyword), new SqlParameter("@officeid",officeId));
            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            dt.Constraints.Clear();
            dt.Merge(ds.Tables[0]);
            dt.RemotingFormat = this.RemotingFormat;

            return CompressData(dt);
        }



        public string Alert(string lang)
        {
            if (myTrans != null)
                return null;

            string alert = null;
            object oret=ExecuteScalarSQL("Select Msg"+ lang +" from Msg where MsgCode='ALERT'");
            if(oret !=null )
                alert=oret.ToString();

            return alert;
        }
        public byte[] DocShortcuts(int fileId)
        {
            return CompressData(GetDocXRef().LoadByFileId(fileId));
        }

        public string HitHilite(int docRefId, string searchTerm, bool summaryResults, string VersionNumber)
        {
            System.Web.HttpContext ctx = System.Web.HttpContext.Current;

            string virt = ctx.Request.ApplicationPath;
            if (virt == "/")
                virt = "";

            string ftFld = ctx.Server.MapPath(virt + "/fulltext/");


            string website = ctx.Request.Url.Host;
            string scheme = ctx.Request.Url.Scheme;
            if (System.Configuration.ConfigurationManager.AppSettings["HHUseIP"].ToString().ToLower() == "true")
                website = ctx.Request.ServerVariables["LOCAL_ADDR"];

            string query="",tempName="";
            try
            {


                //searchTerm = searchTerm.Replace("(", " ");
                //searchTerm = searchTerm.Replace(")", " ");

                //if (!summaryResults)
                //    query =scheme+ "://"+website + virt + "/fulltext/qfullhit.htw?ciwebhitsfile=" + virt + "/fulltext/{0}&cirestriction={1}&cihilitetype=Full&CiBold=y&cidialect=1";
                //else
                //    query = scheme + "://" + website + virt + "/fulltext/qfullhit.htw?ciwebhitsfile" + virt + "/fulltext/{0}&cirestriction={1}&cihilitetype=Summary&CiBold=y&cidialect=1";

                //JLL For CHRC Evaluation - hook into localhost
                if (!summaryResults)
                    query = scheme + "://localhost/" + virt + "/fulltext/qfullhit.htw?ciwebhitsfile=" + virt + "/fulltext/{0}&cirestriction={1}&cihilitetype=Full&CiBold=y&cidialect=1";
                else
                    query = scheme + "://localhost/" + virt + "/fulltext/qfullhit.htw?ciwebhitsfile" + virt + "/fulltext/{0}&cirestriction={1}&cihilitetype=Summary&CiBold=y&cidialect=1";


                //get doc
                lmDatasets.docDB.DocContentDataTable ddt = GetDocContent().LoadDT(docRefId, VersionNumber);
                lmDatasets.docDB.DocContentRow dcr = ddt.FindByDocId(docRefId);

                //write doc to disk in fulltext folder
                tempName = System.IO.Path.GetRandomFileName() + dcr.Ext;
                System.IO.File.WriteAllBytes(ftFld + tempName, dcr.Contents);
                //searchTerm = Uri.EscapeDataString(searchTerm);
                //if (!summaryResults)
                //{
                // //   searchTerm = Uri.EscapeDataString(searchTerm);
                //}
                //else
                //    searchTerm = Uri.EscapeUriString(searchTerm);

                //qfullhit.htw to get html

                System.Net.WebClient wc = new System.Net.WebClient();
                //wc.Encoding = System.Text.Encoding.UTF8;

                //wc.QueryString.Add("ciwebhitsfile",String.Format("/lmras/fulltext/{0}",tempName));

                //byte[] t = System.Text.Encoding.ASCII.GetBytes(searchTerm);

                //wc.QueryString.Add("cirestriction", System.Text.Encoding.ASCII.GetString(t));

                //if (!summaryResults)
                //    wc.QueryString.Add("cihilitetype", "Full");
                //else
                //    wc.QueryString.Add("cihilitetype", "Summary");

                //wc.QueryString.Add("CiBold", "y");
                //wc.QueryString.Add("cidialect", "1");

                searchTerm = System.Web.HttpUtility.UrlEncodeUnicode(searchTerm);

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(String.Format(query, tempName, searchTerm));
                System.IO.File.AppendAllText(@"C:/atrium/log.txt", sb.ToString());
                sb.Clear();

                System.Uri address = new Uri(String.Format(query, tempName, searchTerm));
                string html = wc.DownloadString(address);

                //delete temp doc from ft folder
                System.IO.File.Delete(ftFld + tempName);

                //return html
                return html;
            }
            catch (Exception x)
            {
                LogEvent("Error", Environment.UserName, User, User, x.GetType().ToString(), x.Source, x.Message, String.Format(query, tempName, searchTerm));
                throw x;
            }
        }

        public byte[] LoadActivityConfig()
        {
            lmDatasets.ActivityConfig ds = new ActivityConfig();
            ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.EnforceConstraints = false;

            ds.Merge(GetMenu().Load());
            ds.Merge(GetACMajor().Load());
            ds.Merge(GetActivityCode().Load());
            ds.Merge(GetACSeries().Load());
            ds.Merge(GetACDependency().Load());
            ds.Merge(GetACBF().Load());
            ds.Merge(GetACDisb().Load());
            ds.Merge(GetActivityField().Load());
            ds.Merge(GetSeries().Load());
            ds.Merge(GetOfficeMandate().Load());
            ds.Merge(GetACConvert().Load());
            ds.Merge(GetACFileType().Load());
            ds.Merge(GetACMenu().Load());
            ds.Merge(GetACDocumentation().Load());
            ds.Merge(GetACControlType().Load());
            ds.Merge(GetACDependencyType().Load());
            ds.Merge(GetACSeriesType().Load());
            ds.Merge(GetACTaskType().Load());
            ds.Merge(GetSeriesPackage().Load());
            ds.Merge(GetSeriesStatus().Load());

            FixTZDSIssue(ds);
            return CompressData( ds);
        }

        public byte[] LoadDataDictionary()
        {
            lmDatasets.appDB ds = new appDB();
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.EnforceConstraints = false;

            ds.Merge(GetddTable().Load());
            ds.Merge(GetddField().Load());
            ds.Merge(GetddLookup().Load());
            ds.Merge(GetddGeneric().Load());
            ds.Merge(GetddRule().Load());

            FixTZDSIssue(ds);
            return CompressData(ds);
        }
 
	}
}

