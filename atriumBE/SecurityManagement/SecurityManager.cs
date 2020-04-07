using System;
using System.Collections;
using lmDatasets;


namespace atSecurity
{
    /// <summary>
    /// 
    /// </summary>
    public class SecurityManager : atLogic.BEManager
    {
        
        SecurityDB.secUserRow ur;

        public enum Features
        {

            ACBF = 1166,
            ACBFCompleted = 1167,
            ACConvert = 1189,
            AccountHistory = 1135,
            AccountHistoryAudit = 1136,
            ACDependency = 1168,
            ACDisb = 1169,
            ACMajor = 1190,
            ACMandate = 1170,
            ACSeries = 1171,
            ACTemplate = 1184,
            Activity = 1036,
            ActivityAudit = 1137,
            ActivityBF = 1045,
            ActivityCode = 1102,
            ActivityCompleted = 1103,
            ActivityDetail = 1104,
            ActivityField = 1105,
            ActivityTime = 1172,
            ActivityXRef = 1197,
            Address = 1098,
            AKA = 1140,
            AppointmentType = 1067,
            ArchiveBatch = 1042,
            Attachment = 1200,
            Bankruptcy = 1021,
            Batch = 1141,
            BFList = 1100,
            BFType = 1196,
            CashBlotter = 1046,
            CBDetail = 1024,
            CBStatus = 1068,
            City = 1069,
            CommMode = 1198,
            CommType = 1176,
            ConsumerProposal = 1070,
            Contact = 1106,
            ContactEmail = 1180,
            Cost = 1040,
            Country = 1071,
            ddField = 1107,
            ddTable = 1108,
            Debt = 1017,
            Debtor = 1048,
            DebtorStatusAudit = 1072,
            Department = 1110,
            Disbursement = 1037,
            DisbursementAudit = 1142,
            DisbursementType = 1073,
            DispositionAuthority = 1188,
            DocType = 1178,
            DocTypeMajor = 1177,
            Document = 1187,
            DocXRef = 1194,
            dtproperties = 1074,
            Efile = 1054,
            EFileAudit = 1143,
            EfileScreen = 1206,
            EfileRT = 1207,
            EfilePX = 1208,
            EfilePT = 1209,
            EfileSN = 1210,
            FileAccess = 1192,
            fileAccount = 1016,
            FileAccountAudit = 1144,
            FileContact = 1114,
            FileFormat = 1179,
            FileHistory = 1057,
            FileHistoryAudit = 1145,
            FileIndex = 1115,
            fileOffice = 1055,
            FileOfficeAudit = 1146,
            FileRims = 1203,
            FileStatus = 1089,
            FileTypeMajor = 1199,
            FileXRef = 1195,
            Insolvency = 1022,
            IRP = 1033,
            IRPAudit = 1150,
            Issue = 1193,
            Judgment = 1019,
            JudgmentAccount = 1162,
            JudicialDistrict = 1076,
            LegalProcess = 1151,
            Letters = 1077,
            Litigation = 1090,
            Mail = 1119,
            MailAudit = 1152,
            MailFolder = 1120,
            Mandate = 1173,
            Office = 1003,
            Office2JD = 1066,
            OfficeAccount = 1011,
            OfficeAccountAudit = 1154,
            Officer = 1049,
            OfficerDelegate = 1201,
            OfficerRole = 1163,
            OPD = 1080,
            Opinion = 1185,
            Params = 1081,
            PKID = 1157,
            PLOffice = 1083,
            Process = 1191,
            Program = 1125,
            Proposal = 1084,
            Province = 1094,
            RAClientImpact = 1159,
            Recipient = 1181,
            RiskAssessment = 1160,
            RoleCode = 1085,
            secFeature = 1075,
            secFeatureType = 1182,
            secFileRule = 1202,
            secGroup = 1164,
            secGroups = 1093,
            secMembership = 1078,
            secPermission = 1082,
            secPermLevel = 1183,
            secRule = 1175,
            secUser = 1165,
            Series = 1174,
            SRP = 1091,
            SRPAudit = 1161,
            sysdiagrams = 1186,
            Taxing = 1035,
            Template = 1088,
            Timeslip = 1205,
            Writ = 1038,
            WritHistory = 1087,
            CompOffer = 1215,
            CompOfferDetail = 1218,
            SSTCase = 1219,
            SSTCaseMAtter = 1220,
            Party = 1221,
            FileParty = 1222,
            Appointment = 1223,
            Attendee = 1224,
            SysAdmin = 1225,
            DataAdmin = 1226,
            SSTRequest = 1227,
            SSTReqRecipient = 1228,
            SSTDecision = 1229,
            AppSetting=1231,
            MemberProfile=1232,
            ServiceCentre=1233,
            FileOwner=1234,
            DocVersion=1382,
            ConvertDoc=1384,
            MassActivity = 1385,
            LateOverride = 1386,
            Hardship = 1235,
            Atrium = 1236


        }
        //SRPDetail = 1216,
        //BillingReview = 1217,

        public enum ExPermissions
        {
            No = 0,
            Yes = 1
            //Deny=10
        }

        public enum LevelPermissions
        {
            No = 0,
            Mine = 2,
            MyOffice = 3,
            All = 4
            //Deny = 10
        }

        atriumBE.atriumManager myatMng;
        public atriumBE.atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        public SecurityManager(atriumBE.atriumManager atmng):base(atmng.AppMan)
        {
            base.DAL = atmng.DALMngr;
            myatMng = atmng;
           

            MyDS = new SecurityDB();
            MyDS.EnforceConstraints = false;

        }


        public override void LoadAll(bool refresh)
        {
            if(refresh)
            {
                GetsecFeature().PreRefresh();
                GetsecRule().PreRefresh();
                GetsecPermission().PreRefresh();
            }

            GetsecFeature().Load();
            GetsecRule().Load();
            GetsecPermission().Load();
        }
        
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;

            }
            
        }
        public SecurityDB.secUserRow CurrentUser
        {
            get { return ur; }
            set { ur = value; }
        }

        private secUserBE mysecUser;
        private secMembershipBE mysecMembership;


    
        secRuleBE mySecRule;
        public secRuleBE GetsecRule()
        {
            if (mySecRule == null)
            {
                mySecRule = new secRuleBE(this);
            }

            return mySecRule;
        }


        secPermissionBE mySecPermission;
        public secPermissionBE GetsecPermission()
        {
            if (mySecPermission == null)
            {
                mySecPermission = new secPermissionBE(this);
            }

            return mySecPermission;
        }

        secPermLevelBE mySecPermLevel;
        public secPermLevelBE GetsecPermLevel()
        {
            if (mySecPermLevel == null)
            {
                mySecPermLevel = new secPermLevelBE(this);
            }

            return mySecPermLevel;
        }

        secGroupBE mySecGroup;
        public secGroupBE GetsecGroup()
        {
            if (mySecGroup == null)
            {
                mySecGroup = new secGroupBE(this);
            }

            return mySecGroup;
        }

        secFeatureBE mySecFeature;
        public secFeatureBE GetsecFeature()
        {
            if (mySecFeature == null)
            {
                mySecFeature = new secFeatureBE(this);
            }

            return mySecFeature;
        }

    

        public secUserBE GetsecUser()
        {
            if (mysecUser == null)
            {
                mysecUser = new secUserBE(this);
            }

            return mysecUser;
        }

        public secMembershipBE GetsecMembership()
        {
            if (mysecMembership == null)
            {
                mysecMembership = new secMembershipBE(this);
            }

            return mysecMembership;
        }


        public SecurityDB DB
        {
            get
            {
                return (SecurityDB)MyDS;
            }
        }

   

        public bool VerifyLogin(int userId, string password)
        {
            ur = this.GetsecUser().Load(userId);
            if (ur == null)
                throw new InvalidUserId();
            else
                return VerifyLoginCommon(ur, password);
        }

        public bool VerifyLogin(string userName, string password)
        {
            ur = this.GetsecUser().Load(userName);
            if (ur == null)
                throw new InvalidUserId();
            else
                return VerifyLoginCommon(ur, password);
        }

        public bool VerifyLogin(int UserId)
        {
            ur = DB.secUser.FindByUserId(UserId);
            if (ur == null)
                ur = this.GetsecUser().Load(UserId);
            if (ur == null)
            {
                //Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry log = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry();
                //log.EventId = 100;
                //log.Message = "Invalid UserID";
                //log.Severity = System.Diagnostics.TraceEventType.Error;
                //log.Categories.Add("Security");

                //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(log);
                throw new InvalidUserId();
            }
            if (ur.LockedOut || !ur.Active)
            {
                //Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry log = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry();
                //log.EventId = 101;
                //log.Message = "Account is locked out or inactive";
                //log.Severity = System.Diagnostics.TraceEventType.Error;
                //log.Categories.Add("Security");
                //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(log);
                throw new InvalidAccount();
            }

            //Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry l = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry();
            //l.EventId = 102;
            //l.Severity = System.Diagnostics.TraceEventType.Information;
            //l.Message = "Successfull login";
            //l.Categories.Add("Security");

            //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(l);

            return true; //VerifyLoginCommon(ur);
        }


        private bool VerifyLoginCommon(SecurityDB.secUserRow ur, string password)
        {
            if (ur == null)
            {
                //Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry log = new Microsoft.Practices.EnterpriseLibrary.Logging.LogEntry();
                //log.EventId = 100;
                //log.Message = "Invalid UserID";
                //log.Categories.Add("Security");
                //Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(log);
                throw new InvalidUserId();
            }
            if (ur.LockedOut || !ur.Active)
            {
                throw new InvalidAccount();
            }
            //if (ur.Password != secUserBE.EncryptPassword(password) )
            //{
            //    throw new BadPasswordException();
            //}
            return true;
        }


        public ExPermissions CanExecute(int fileId, Features feature)
        {
            SecurityDB.vsecRowLevelCheckRow r = LoadPermission(fileId, feature);
            if (r == null)
                return ExPermissions.No;
            else
                return (ExPermissions)r.AllowExecute;
        }
        public ExPermissions CanOverride(int fileId, Features feature)
        {
            SecurityDB.vsecRowLevelCheckRow r = LoadPermission(fileId, feature);
            if (r == null)
                return ExPermissions.No;
            else
                return (ExPermissions)r.OverrideRule;
        }
        public ExPermissions CanAdd(int fileId, Features feature)
        {
            SecurityDB.vsecRowLevelCheckRow r = LoadPermission(fileId, feature);
            if (r == null)
                return ExPermissions.No;
            else
                return (ExPermissions)r.AllowCreate;
        }
        public LevelPermissions CanRead(int fileId, Features feature)
        {
            SecurityDB.vsecRowLevelCheckRow r = LoadPermission(fileId, feature);
            if (r == null)
                return LevelPermissions.No;
            else
                return (LevelPermissions)r.ReadLevel;
        }
        public LevelPermissions CanUpdate(int fileId, Features feature)
        {
            SecurityDB.vsecRowLevelCheckRow r = LoadPermission(fileId, feature);
            if (r == null)
                return LevelPermissions.No;
            else
                return (LevelPermissions)r.UpdateLevel;
        }
        public LevelPermissions CanDelete(int fileId, Features feature)
        {
            SecurityDB.vsecRowLevelCheckRow r = LoadPermission(fileId, feature);
            if (r == null)
                return LevelPermissions.No;
            else
                return (LevelPermissions)r.DeleteLevel;
        }

        private SecurityDB.vsecRowLevelCheckRow LoadPermission(int fileId, Features feature)
        {
            //if loaded then return recor
            lmDatasets.SecurityDB.vsecRowLevelCheckRow vsr = DB.vsecRowLevelCheck.FindByFileIdFeatureId(fileId, (int)feature);
            if (vsr == null && DB.vsecRowLevelCheck.Select("Fileid="+fileId.ToString()).Length==0)
            {
                //load best permissions for file/feature/user combo into dataset
                System.Data.DataSet ds = new System.Data.DataSet();
                ds = myatMng.AppMan.ExecuteDataset("secBestPermByFile", fileId);
                if (ds.Tables.Count == 1)
                {
                    DB.vsecRowLevelCheck.Merge(ds.Tables[0], false, System.Data.MissingSchemaAction.Ignore);
                    vsr = DB.vsecRowLevelCheck.FindByFileIdFeatureId(fileId, (int)feature);
                }
            }

            return vsr;
        }

        public int PKIDGet(string obj, int inc)
        {
           return myatMng.PKIDGet(obj, inc);
            
        }

    }
}
