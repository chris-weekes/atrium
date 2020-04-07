using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class OfficerPrefsBE:atLogic.ObjectBE
	{

		OfficeManager myA;
		officeDB.OfficerPrefsDataTable myOfficerPrefsDT;

        internal OfficerPrefsBE(OfficeManager pBEMng)
            : base(pBEMng, pBEMng.DB.OfficerPrefs)
		{
			myA=pBEMng;
            //if (myA != myA.AtMng.OfficeMng)
            //    throw new AtriumException("Class can only be used for logged on officer");

			myOfficerPrefsDT=(officeDB.OfficerPrefsDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOfficerPrefs();
        }
        
        public atriumDAL.OfficerPrefsDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficerPrefsDAL)myODAL;
            }
        }

	

		public void LoadByOfficerId(int OfficerId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerPrefsLoad(OfficerId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficerId(OfficerId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficerId(OfficerId));
                }
            }
		}

        protected override void AfterAdd(DataRow row)
        {
            officeDB.OfficerPrefsRow dr = (officeDB.OfficerPrefsRow)row;
            string ObjectName = this.myOfficerPrefsDT.TableName;

            dr.PrefId = this.myA.AtMng.PKIDGet(ObjectName, 10);
        }

        public string GetPref(string prefName,string defaultValue)
        {
            officeDB.OfficerPrefsRow[] opr = (officeDB.OfficerPrefsRow[])myA.DB.OfficerPrefs.Select("officerid=" + myA.AtMng.OfficerLoggedOn.OfficerId + " and prefname='" + prefName + "'");
            if(opr.Length==0)
            {
                SetPref(prefName,defaultValue);
                return defaultValue;
            }
            else
                return opr[0].PrefValue;
        }

        public int GetPref(string prefName, int defaultValue)
        {
            return Convert.ToInt32(GetPref(prefName, defaultValue.ToString()));
        }

        public bool GetPref(string prefName, bool defaultValue)
        {
            return Convert.ToBoolean(GetPref(prefName, defaultValue.ToString()));
        }

        public DateTime GetPref(string prefName, DateTime defaultValue)
        {
            return Convert.ToDateTime(GetPref(prefName, defaultValue.ToString()));
        }

        public void SetPref(string prefName, string prefValue)
        {
            officeDB.OfficerPrefsRow[] opr = (officeDB.OfficerPrefsRow[])myA.DB.OfficerPrefs.Select("officerid="+myA.AtMng.OfficerLoggedOn.OfficerId+" and prefname='"+prefName+"'","");
            if (opr.Length == 0)
            {
                //add new pref
                officeDB.OfficerPrefsRow newOpr = (officeDB.OfficerPrefsRow)myA.GetOfficerPrefs().Add(myA.AtMng.OfficerLoggedOn);
                newOpr.OfficerId = myA.AtMng.OfficerLoggedOn.OfficerId;
                newOpr.PrefName = prefName;
                newOpr.PrefValue = prefValue;
            }
            else
            {
                if(prefValue!=opr[0].PrefValue)
                    opr[0].PrefValue = prefValue;
            }
        }

        public void SetPref(string prefName, int prefValue)
        {
            SetPref(prefName, prefValue.ToString());
        }

        public void SetPref(string prefName, bool prefValue)
        {
            SetPref(prefName, prefValue.ToString());
        }

        public void SetPref(string prefName, DateTime prefValue)
        {
            SetPref(prefName, prefValue.ToString());
        }

        public void SavePrefsCommit()
        {
            //save and commit
            try
            {
                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(this);
                bp.Update();
            }
            catch (Exception x)
            {
               // myA.AtMng.AppMan.Rollback();
                //Add an entry to auditlog if setpref fails?
                //throw an error?  no, right?
            }
        }
        
        //////////////Preference Names/Values
        public const string UserLanguage = "UserLanguage";
        public const string vUserLanguageEng = "ENG";
        public const string vUserLanguageFre = "FRE";
        public const string LoadBFListOnStartup = "LoadBFListOnStartup";
        public const string LoadCalendarOnStartup = "LoadCalendarOnStartup";
        public const string LoadPersonalFileOnStartup = "LoadPersonalFileOnStartup";
        public const string AutoHideOfficerToolkitOnStartup = "AutoHideOfficerToolkitOnStartup";
        public const string GridSelectionMode = "GridSelectionMode";
        public const string vGridSelectionModeCheckbox = "check";
        public const string vGridSelectionModeMulti = "multi";
        public const string DismissWhatsNew = "DismissWhatsNew";
        public const string OutOfOffice = "OutOfOffice";

        //Peter Phong Ho  Test
        public const string EnableReminders = "EnableReminders";

        public const string qsOpnBool = "qsOpnBool";
        public const string qsOpnFullText = "qsOpnFullText";
        public const string qsOpnSubj = "qsOpnSubj";
        public const string qsDocBool = "qsDocBool";
        public const string qsDocFullText = "qsDocFullText";
        public const string qsDocSubj = "qsDocSubj";
        public const string qsFileNameEng = "qsFileNameEng";
        public const string qsFileNameFre = "qsFileNameFre";
        public const string qsFullFileName = "qsFullFileName";
        public const string qsFileNumber = "qsFileNumber";
        public const string qsFullFileNumber = "qsFullFileNumber";
        public const string qsiCaseFileNumber = "qsiCaseFileNumber";
        public const string qsSIN = "qsSIN";
        public const string qsOfficeFileNumber = "qsOfficeFileNumber";
        public const string qsLastName = "qsLastName";

        //Officer Toolkit Prefs
        public const string OfficerTKHideBF = "OfficerTKHideBF";
        public const string OfficerTKHideDocs = "OfficerTKHideDocs";
        public const string OfficerTKHideFiles = "OfficerTKHideFiles";
        public const string OfficerTKHideCalendar = "OfficerTKHideCalendar";
        public const string OfficerTKHideAddBook = "OfficerTKHideAddBook";
        public const string OfficerTKHidePersonalFile = "OfficerTKHidePersonalFile";
        public const string OfficerTKHideMyOffice = "OfficerTKHideMyOffice";
        //End Officer Toolkit Prefs

        public const string ReceiveLawMailInOutlook = "ReceiveLawMailInOutlook";
        public const string TimeslipForEveryActivity = "TimeslipForEveryActivity";
        public const string ReviseDocOnDocCheckIn = "ReviseDocOnDocCheckIn";
        public const string AlwaysDisplayDraftDocMessage = "AlwaysDisplayDraftDocMessage";
        public const string PromptOnClose = "PromptOnClose";
        public const string F4On = "F4On";
        public const string FastDataEntry = "FastDataEntry";

        public const string TocAutoHide = "TocAutoHide";

        public const string RememberSearchOnSelection = "RememberSearchOnSelection";
        public const string SearchOnDefault = "SearchOnDefault";

        public const string RetrieveHitCount = "RetrieveHitCount";
        public const string HitCountTimerDelay = "HitCountTimerDelay";

        public const string hhBackground = "hhBackground";
        public const string hhForeground = "hhForeground";

        public const string BFListMailOnly = "BFListMailOnly";
        public const string BFListMailType = "BFListMailType";
        public const string CompletedBFListMailOnly = "CompletedBFListMailOnly";
        public const string CompletedBFListMailType = "CompletedBFListMailType";
        public const string BFTimerInterval = "BFTimerInterval";
        public const string ReadMailOnTimer = "ReadMailOnTimer";
        public const string BFShowNotify = "BFShowNotify";
        public const string BFDaysAhead = "BFDaysAhead";

        public const string LawMateExplorerShowSubFiles = "LawMateExplorerShowSubFiles";

        public const string TimekeepingGridExpanded = "TimekeepingGridExpanded";

        public const string FTVShowFileNumber = "FTVShowFileNumber";
        public const string FTVShowOpenFiles = "FTVShowOpenFiles";
        public const string FTVShowXrefs = "FTVShowXrefs";

        //BEGIN ucControl Command Bar preferences
        
        //begin ucactivity
        public const string cmdUcActivityGroupBy = "cmdUcActivityGroupBy";
        public const string cmdUcActivityShowEditFields = "cmdUcActivityShowEditFields";
        public const string cmdUcActivityExpandGrid = "cmdUcActivityExpandGrid";
        public const string cmdUcActivityFilter = "cmdUcActivityFilter";
        public const string cmdUcActivityBFFilter = "cmdUcActivityBFFilter";
        public const string cmdUcActivityTKFilter = "cmdUcActivityTKFilter";
        public const string cmdUcActivityBFGroupBy = "cmdUcActivityBFGroupBy";
        public const string cmdUcActivityTKGroupBy = "cmdUcActivityTKGroupBy";
        //end ucactivity
        
        //begin uctimeslip
        public const string cmdUcTimeslipFilter = "cmdUcTimeslipFilter";

        //end uctimeslip

        //begin ucdoc
        public const string DocSizeLimit = "DocSizeLimit";
        public const string PromptMetaData = "PromptMetaData";
        //end ucdoc

        //END ucControl Command Bar preferences


        //////////////End Preference Names
    }
}