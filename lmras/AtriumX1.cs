using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace lmras
{
   
    public partial interface IAtriumX
    {
        [OperationContract(IsOneWay = false)]
        lmDatasets.HelpDB.hlpImageDataTable hlpImageLoad(string FileName, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.HelpDB.hlpPageDataTable hlpPageLoad(string FileName, string lang, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.HelpDB.hlpXmlDataTable hlpXmlLoad(string FileName, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.CLAS.CashBlotterDataTable CashBlotterLoad(int CashBlotterID, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.CLAS.CashBlotterDataTable CashBlotterLoadbyOfficeId(int OfficeId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.CLAS.CBDetailDataTable CBDetailLoadByCashBlotterId(int cashBlotterId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.CLAS.DebtorDataTable DebtorLoad(int DebtorId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.CLAS.OfficeAccountDataTable OfficeAccountLoadByFileId(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] TaxingLoadByOfficeId(int OfficeId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] TaxingLoadBySrpID(int SrpID, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.DisbursementDataTable DisbursementLoadByActivityId(int activityId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityDataTable Activity_Load(int ActivityId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityDataTable ActivityLoadByProcessId(int processId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityBFDataTable ActivityBFLoadCompleted(int officerId, DateTime fromDtate, DateTime toDate, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityBFDataTable ActivityBFLoad(int ActivityBFId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityBFDataTable ActivityBFLoadByActivityId(int ActivityId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityTimeDataTable ActivityTimeLoad(int ActivityTimeId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityTimeDataTable ActivityTimeLoadByActivityId(int ActivityId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.appDB.SRPClientDataTable ActivityTimeLoadSRPClientByOfficerId(int SRPID, int OfficerId, DateTime StartDate, DateTime EndDate, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.appDB.SRPClientDataTable ActivityTimeLoadSRPClientBySRPID(int SRPID, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.appDB.TimeSlipDataTable ActivityTimeLoadByOfficerId(int OfficerId, DateTime StartDate, DateTime EndDate, int shortcutsForId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.appDB.TimeSlipDataTable ActivityTimeLoadBySRPID(int SRPID, int shortcutsForId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.appDB.TimeSlipBranchDataTable ActivityTimeLoadBranchByOfficerId(int OfficerId, DateTime StartDate, DateTime EndDate, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.appDB.TimeSlipBranchDataTable ActivityTimeLoadBranchBySRPID(int SRPID, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ActivityXRefDataTable ActivityXRefLoad(int Id, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.AppointmentDataTable AppointmentLoad(int ApptId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] AppointmentLoadByContactId(int ContactId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.TimeLineDataTable AppointmentLoadByContactIdDates(int ContactId, DateTime startDate, DateTime endDate, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ApptRecurrenceDataTable ApptRecurrenceLoad(int ApptRecurrenceId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ArchiveBatchDataTable ArchiveBatchLoad(int ArchiveId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.AttendeeDataTable AttendeeLoadByApptId(int ApptId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ddEntityDataTable ddEntityLoad(int Id, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.FileAccessDataTable FileAccessLoadByFileId(int FileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.FileContactDataTable FileContactLoadByFileId(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.FileXRefDataTable FileXRefLoad(int Id, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.FileXRefDataTable FileXRefLoadByFileId(int FileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.FileXRefDataTable FileXRefLoadByOtherFileId(int OtherFileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] IRPLoadBySRPId(int srpId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ContactDataTable PersonLoadBySIN(string SIN, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.ProcessDataTable ProcessLoad(int ProcessId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.secFileRuleDataTable secFileRuleLoadByFileId(int FileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.SRPDataTable SRPLoad(int SRPID, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] SRPLoadByFileId(int FileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.SRPDataTable SubmitSRP(byte[] dt, int srpId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.EFileDataTable EFileLoad(int FileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.atriumDB.EFileDataTable EFileLoadByFullFileNumber(string FileNumber, AtriumXCon ax);

    }


    public partial class AtriumX : IAtriumX
    {
        public lmDatasets.HelpDB.hlpImageDataTable hlpImageLoad(string FileName, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GethlpImage().Load(FileName);
        }

        public lmDatasets.HelpDB.hlpPageDataTable hlpPageLoad(string FileName, string lang, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GethlpPage().Load(FileName, lang);
        }

        public lmDatasets.HelpDB.hlpXmlDataTable hlpXmlLoad(string FileName, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GethlpXml().Load(FileName);
        }

        public lmDatasets.CLAS.CashBlotterDataTable CashBlotterLoad(int CashBlotterID, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetCashBlotter().Load(CashBlotterID);
        }
        public lmDatasets.CLAS.CashBlotterDataTable CashBlotterLoadbyOfficeId(int OfficeId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetCashBlotter().LoadByOfficeID(OfficeId);
        }

        public lmDatasets.CLAS.CBDetailDataTable CBDetailLoadByCashBlotterId(int cashBlotterId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetCBDetail().LoadByCashBlotterID(cashBlotterId);
        }

        public lmDatasets.CLAS.DebtorDataTable DebtorLoad(int DebtorId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDebtor().Load(DebtorId);
        }

        public lmDatasets.CLAS.OfficeAccountDataTable OfficeAccountLoadByFileId(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficeAccount().LoadByFileID(fileId);
        }

        public byte[] TaxingLoadByOfficeId(int OfficeId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetTaxing().LoadByOfficeIDByte(OfficeId);
        }

        public byte[] TaxingLoadBySrpID(int SrpID, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetTaxing().LoadBySRPIDByte(SrpID);
        }

        public lmDatasets.atriumDB.DisbursementDataTable DisbursementLoadByActivityId(int activityId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDisbursement().LoadByActivityID(activityId);
        }

        public lmDatasets.atriumDB.ActivityDataTable Activity_Load(int ActivityId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivity().Load(ActivityId);
        }

        public lmDatasets.atriumDB.ActivityDataTable ActivityLoadByProcessId(int processId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivity().LoadByProcessId(processId);
        }

        public lmDatasets.atriumDB.ActivityBFDataTable ActivityBFLoadCompleted(int officerId, DateTime fromDtate, DateTime toDate, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityBF().LoadByCompleted(officerId, fromDtate, toDate);
        }

        public lmDatasets.atriumDB.ActivityBFDataTable ActivityBFLoad(int ActivityBFId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityBF().Load(ActivityBFId);
        }

        public lmDatasets.atriumDB.ActivityBFDataTable ActivityBFLoadByActivityId(int ActivityId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityBF().LoadByActivityId(ActivityId);
        }

        public lmDatasets.atriumDB.ActivityTimeDataTable ActivityTimeLoad(int ActivityTimeId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().Load(ActivityTimeId);
        }

        public lmDatasets.atriumDB.ActivityTimeDataTable ActivityTimeLoadByActivityId(int ActivityId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadByActivityId(ActivityId);
        }

        public lmDatasets.appDB.SRPClientDataTable ActivityTimeLoadSRPClientByOfficerId(int SRPID, int OfficerId, DateTime StartDate, DateTime EndDate, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadSRPClientByOfficerId(SRPID, OfficerId, StartDate, EndDate);
        }

        public lmDatasets.appDB.SRPClientDataTable ActivityTimeLoadSRPClientBySRPID(int SRPID, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadSRPClientBySRPID(SRPID);
        }

        public lmDatasets.appDB.TimeSlipDataTable ActivityTimeLoadByOfficerId(int OfficerId, DateTime StartDate, DateTime EndDate, int shortcutsForId,  AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadByOfficerId(OfficerId, StartDate, EndDate, shortcutsForId);
        }

        public lmDatasets.appDB.TimeSlipDataTable ActivityTimeLoadBySRPID(int SRPID, int shortcutsForId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadBySRPID(SRPID, shortcutsForId);
        }

        public lmDatasets.appDB.TimeSlipBranchDataTable ActivityTimeLoadBranchByOfficerId(int OfficerId, DateTime StartDate, DateTime EndDate, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadBranchByOfficerId(OfficerId, StartDate, EndDate);
        }

        public lmDatasets.appDB.TimeSlipBranchDataTable ActivityTimeLoadBranchBySRPID(int SRPID, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityTime().LoadBranchBySRPID(SRPID);
        }

        public lmDatasets.atriumDB.ActivityXRefDataTable ActivityXRefLoad(int Id, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityXRef().Load(Id);
        }

        public lmDatasets.atriumDB.AppointmentDataTable AppointmentLoad(int ApptId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetAppointment().Load(ApptId);
        }

        public byte[] AppointmentLoadByContactId(int ContactId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetAppointment().LoadAllForOfficer(ContactId);
        }

        public lmDatasets.atriumDB.TimeLineDataTable AppointmentLoadByContactIdDates(int ContactId, DateTime startDate, DateTime endDate, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetAppointment().LoadByContactIdDates(ContactId, startDate, endDate);
        }

        public lmDatasets.atriumDB.ApptRecurrenceDataTable ApptRecurrenceLoad(int ApptRecurrenceId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetApptRecurrence().Load(ApptRecurrenceId);
        }


        public lmDatasets.atriumDB.ArchiveBatchDataTable ArchiveBatchLoad(int ArchiveId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetArchiveBatch().Load(ArchiveId);
        }

        public lmDatasets.atriumDB.AttendeeDataTable AttendeeLoadByApptId(int ApptId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetAttendee().LoadByApptId(ApptId);
        }

        public lmDatasets.atriumDB.ddEntityDataTable ddEntityLoad(int Id, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetddEntity().Load(Id);
        }

        public lmDatasets.atriumDB.FileAccessDataTable FileAccessLoadByFileId(int FileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetFileAccess().Load(FileId);
        }

        public lmDatasets.atriumDB.FileContactDataTable FileContactLoadByFileId(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetFileContact().LoadByFileId(fileId);
        }

        public lmDatasets.atriumDB.FileXRefDataTable FileXRefLoad(int Id, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetFileXRef().Load(Id);
        }

        public lmDatasets.atriumDB.FileXRefDataTable FileXRefLoadByFileId(int FileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetFileXRef().LoadByFileId(FileId);
        }

        public lmDatasets.atriumDB.FileXRefDataTable FileXRefLoadByOtherFileId(int OtherFileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetFileXRef().LoadByOtherFileId(OtherFileId);
        }

        public byte[] IRPLoadBySRPId(int srpId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetIRP().LoadBySRPIDByte(srpId);
        }

        public lmDatasets.atriumDB.ContactDataTable PersonLoadBySIN(string SIN, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetContact().LoadBySIN(SIN);
        }

        public lmDatasets.atriumDB.ProcessDataTable ProcessLoad(int ProcessId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetProcess().Load(ProcessId);
        }

        public lmDatasets.atriumDB.secFileRuleDataTable secFileRuleLoadByFileId(int FileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetsecFileRule().LoadByFileId(FileId);
        }

        public lmDatasets.atriumDB.SRPDataTable SRPLoad(int SRPID, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetSRP().Load(SRPID);
        }

        public byte[] SRPLoadByFileId(int FileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetSRP().LoadByFileIDByte(FileId);
        }

        
        public lmDatasets.atriumDB.EFileDataTable EFileLoad(int FileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetEFile().Load(FileId);
        }

        public lmDatasets.atriumDB.EFileDataTable EFileLoadByFullFileNumber(string FileNumber, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetEFile().LoadByFullFileNumber(FileNumber);
        }


        public lmDatasets.atriumDB.SRPDataTable SubmitSRP(byte[] compDs, int srpId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            System.Data.DataSet ds=atriumDAL.atriumDALManager.DecompressDataSet(compDs);

            lmDatasets.atriumDB.SRPDataTable dt =(lmDatasets.atriumDB.SRPDataTable) ds.Tables[0];
            return atDal.GetSRP().SubmitSRP(dt, srpId);
        }
    }
}