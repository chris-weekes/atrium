using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using lmDatasets;

namespace lmras
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Itest" in both code and config file together.
    [ServiceContract]
    public partial interface IAtriumX
    {
        [OperationContract(IsOneWay = false)]
        string Alert(AtriumXCon ax, string lang);

        [OperationContract(IsOneWay = false)]
        System.Data.DataTable GetDataTable(string query, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] GetDataTableByte(string query, System.Data.SerializationFormat sf, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        object PKIDGet(string objectName, int increment, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        void PKIDSet(string objectName, int initial, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        void ExecuteSP(AtriumXCon ax, string spName, params  object[] parameterValues);

        [OperationContract(IsOneWay = false)]
        void ExecuteNonQuery(AtriumXCon ax, string sql);

        [OperationContract(IsOneWay = false)]
        byte[] ExecuteDatasetByte(AtriumXCon ax, string spName, params  object[] parameterValues);

        [OperationContract(IsOneWay = false)]
        System.Data.DataSet ExecuteDatasetSQL(AtriumXCon ax, string sql);

        [OperationContract(IsOneWay = false)]
        object ExecuteScalar(AtriumXCon ax, string spName, params  object[] parameterValues);

        [OperationContract(IsOneWay = false)]
        object ExecuteScalarSQL(AtriumXCon ax, string sql);

        [OperationContract(IsOneWay = false)]
        ResponseMsg Update(UpdateMsg payload);

        [OperationContract(IsOneWay = false)]
        ResponseMsgComp UpdateComp(UpdateMsgComp payload);

        //methods that load multiple tables
        [OperationContract(IsOneWay = false)]
        byte[] LoadFile(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadCLAS(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadSST(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadActivity(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadDoc(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadDocbyDocId(int docid, AtriumXCon ax);

        //end

        [OperationContract(IsOneWay = false)]
        byte[] Load(string objectName, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadACInfo(AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] LoadDDInfo(AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        void LogEvent(string eventType, string windowsUser, string lmUser, string workAs, string exType, string exSource, string exMessage, string exStack, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDataTable OfficerLoadByUserName(string userName, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] OfficerLoad(int officerId, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDataTable OfficerLoadByRoleCode(string roleCode, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDataTable OfficerLoadByEmail(string email, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDataTable OfficerLoadByOfficerCode(string officerCode, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDataTable OfficerLoadByMyFileId(int fileid, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] OfficerLoadByOfficeId(int officeId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.Advisory.OpinionDataTable OpinionLoadByFileId(int fileid, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.ContactEmailDataTable ContactEmailLoadByContactId(int contactid, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.ContactEmailDataTable ContactEmailLoadByEmail(string email, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] OfficeLoad(int officeid, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficeDataTable OfficeLoadByOfficeFileId(int fileid, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficeDataTable OfficeLoadbyOfficeCode(string officeCode, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDelegateDataTable OfficerDelegateLoadByOfficerId(int officerid, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerDelegateDataTable OfficerDelegateLoadByDelegateId(int delegateid, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.MemberProfileDataTable MemberProfileLoad(int id, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerPrefsDataTable OfficerPrefsLoad(int id, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.OfficerRoleDataTable OfficerRoleLoad(int officerid, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.officeDB.ServiceCentreDataTable ServiceCentreLoad(int officeid, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.SecurityDB.secMembershipDataTable secMembershipLoadByUserId(int userId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.SecurityDB.secUserDataTable secUserLoadByUserid(int userId, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        lmDatasets.SecurityDB.secUserDataTable secUserLoadByUserName(string userName, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        int DocContentAuditDelete(int docId, string version, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        bool DocContentIsLatest(int docId, byte[] timeStamp, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] DocContentLoad(int docid,string version, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        docDB.VersionHistoryListDataTable DocContentLoadVersionHistory(int DocId, int Fileid, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        lmDatasets.docDB.DocXRefDataTable DocXrefLoad(int Id, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] ActivityBFLoadBF(int officeId, int officerId, DateTime date, bool officerBF, Int64 tmpLastEdit, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] ContactLoadByte(int contactid, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] FileSearch(string search, string keyword, int officeId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        byte[] DocShortcuts(int fileId, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        appDB.ContactSearchDataTable ContactSearch(string where, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        appDB.ContactSearchDataTable PartySearch(string where, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] FileSearchDates(string userName, DateTime dateStart, DateTime dateEnd, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] FileSearchSimple(string where, bool includeXrefs, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] FileSearchAdvanced(string where, string whereContact, string whereCaseStatus, bool includeXrefs, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] FileSearchByThread(string keyword, int officeId, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        string HitHilite(int docRefId, string searchTerm, bool summaryResults, string VersionNumber, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        appDB.EFileSearchDataTable SearchByContact(int contactId, string contactType, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] Search(string filter, bool includeXrefs, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        byte[] SearchQuick(string filter, bool opinionsOnly, AtriumXCon ax);

        [OperationContract(IsOneWay = false)]
        atriumDB.AddressDataTable AddressLoad(int AddressId, AtriumXCon ax);
        [OperationContract(IsOneWay = false)]
        atriumDB.AddressDataTable AddressLoadByContactId(int ContactId, AtriumXCon ax);
    }
    [MessageContract]
    public class UpdateMsg
    {
        [MessageHeader(MustUnderstand = true)]
        public List<string> dtList;
        [MessageHeader(MustUnderstand = true)]
        public string Connect;
        [MessageHeader(MustUnderstand = true)]
        public string User;
        [MessageHeader(MustUnderstand = true)]
        public string Pwd;

        [MessageBodyMember]
        public System.Data.DataSet upDS;

    }

    [MessageContract]
    public class ResponseMsg
    {

        [MessageBodyMember]
        public System.Data.DataSet downDS;
    }

    [MessageContract]
    public class UpdateMsgComp
    {
        [MessageHeader(MustUnderstand = true)]
        public List<string> dtList;
        [MessageHeader(MustUnderstand = true)]
        public string Connect;
        [MessageHeader(MustUnderstand = true)]
        public string User;
        [MessageHeader(MustUnderstand = true)]
        public string Pwd;

        [MessageBodyMember]
        public byte[] upByte;

    }

    [MessageContract]
    public class ResponseMsgComp
    {
        [MessageBodyMember]
        public byte[] downByte;

    }

}
