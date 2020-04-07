using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    public class AppSettingBE : ObjectBE
    {

        atriumManager myA;
        appDB.AppSettingDataTable myAppSettingDT;

        internal AppSettingBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.AppSetting)
        {
            myA = pBEMng;
            myAppSettingDT = (appDB.AppSettingDataTable)myDT;
            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetAppSetting();
        }

        public atriumDAL.AppSettingDAL myDAL
        {
            get
            {
                return (atriumDAL.AppSettingDAL)myODAL;
            }
        }

        public appDB.AppSettingRow Load(int SettingId)
        {
            try
            {
                Fill(myDAL.Load(SettingId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(SettingId));
            }

            return myAppSettingDT.FindBySettingId(SettingId);
        }

        //this method is called by typed GetSetting mmethods on atriumManager for ease of access
        public string GetSetting(int id)
        {
            return myAppSettingDT.FindBySettingId(id).SettingValue;
        }

    }

    public enum AppDateSetting
    { }

    public enum AppIntSetting
    {
        TemplateFileId = 1,
        MailCodeAcId = 2,
        ImportedMailCodeAcId = 3,
        NewDocAcId = 4,
        NewRecordAcId = 5,
        NewWordDocAcId = 6,
        ReviseDocCodeAcId = 7,
        DocumentCopyAcId = 8,
        ReplyForwardCodeAcId = 9,
        NewMemoAcId = 10,
        NewFaxCoverAcId = 11,
        NewShortcutContainerAcId = 12,
        NewFileAcId = 13,
        NewOfficeAcId = 14,
        NewContactAcId = 15,
        NewFileContactAcId = 16,
        AddressBookNewContactAcId = 17,
        AddressBookFileContactAcId = 18,
        DocumentPreviewSize = 19,
        DefaultBFTimerInterval = 20,
        NewApptAcId = 24,
        EIDaysLate = 27,
        ISDaysLate = 28,
        EIAppDaysLate = 31,
        ISAppDaysLate = 32,
        BatchJobFailedFileId = 35,
        BatchJobFailedAcSeriesId = 36,
        MaxFileSize = 37,
        SSTOfficeId = 38,
        AtriumOfficeId = 39,
        EditHearingAcId = 41,
        RescheduleHearingAcId = 42,
        AssignedVCAcId = 43,
        ImportDocAcId = 44,
        CalNotifyWindow = 54,
        OutOfOfficeNotification = 55,
        LeadOfficeSecFileRule = 1000,
        CBFirstConfirmAcId = 1003,
        CBSecondConfirmAcId = 1004,
        CBPrintDraftAcId = 1005,
        CBPrintCopyAcId = 1006,
        FileReloadInterval=56,
        ActivityReloadInterval=57,
        MinVersion=1007,
        PLOfficeForecastDocID=1009,
        ImportReadReceiptID=1010,
        BlankDocSkipSize=1011
    }

    public enum AppStringSetting
    {
        DataExchangeNetworkPath = 21,
        EmailSaveFormat = 22,
        MovedToAtriumFolderEng = 25,
        MovedToAtriumFolderFre = 26,
        ToADMSFolder = 29,
        TOAtriumFolder = 30,
        LeadPLContactType = 47,
        LeadLawyerContactype = 48,
        OfficerContactType = 50,
        ISDataExchangeNetworkPath = 51,
        ISToADMSFolder = 52,
        ISTOAtriumFolder = 53,
        OwnerOfficeEng = 1012,
        OwnerOfficeFre = 1013
    }

    public enum AppBoolSetting
    {
        ValidateCity = 23,
        AllowActivityDeleteOnConfigPush = 40,
        RoleBFRead = 45,
        FileBFRead = 46,
        ShowAllSteps = 49,
        useSSTMngr = 1001,
        useCLASMngr = 1002,
        useOutOfOfficeFunctionality = 58,
        isPROD=1008,
        isCVB=1014
    }
}
