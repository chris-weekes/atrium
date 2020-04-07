using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Activation;


namespace lmras
{
    public class AtriumXCon
    {
        public string Connect;
        public string User;
        public string Pwd;
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "test" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public partial class AtriumX : IAtriumX
    {


       
        public ResponseMsg Update(UpdateMsg payload)
        {
            

            atriumDAL.atriumDALManager atDal = new atriumDAL.atriumDALManager(payload.User,payload.Pwd, payload.Connect);
            try
            {


                ResponseMsg rm = new ResponseMsg();

                rm.downDS = atDal.Update(payload.dtList, payload.upDS);

                
                return rm;

            }
            catch (Exception ex)
            {
                LogError(ex, atDal);
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n\r" + ex.InnerException.Message;

                throw new FaultException(msg);
            }
            finally
            {

            }
        }


      
        public ResponseMsgComp UpdateComp(UpdateMsgComp payload)
        {

            atriumDAL.atriumDALManager atDal = new atriumDAL.atriumDALManager(payload.User, payload.Pwd, payload.Connect);
            try
            {


               
                ResponseMsgComp rm = new ResponseMsgComp();

                byte[] ds = atDal.Update(payload.dtList, payload.upByte);

                rm.downByte = ds;

                return rm;

            }
            catch (Exception ex)
            {
                LogError(ex, atDal);
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n\r" + ex.InnerException.Message;

                throw new FaultException(msg);
            }
            finally
            {

            }
        }

        public void LogError(Exception x1, atriumDAL.atriumDALManager atDal)
        {
            if (x1.InnerException != null)
                LogError(x1.InnerException, atDal);

            try
            {
                atDal.LogEvent("Error", Environment.UserName, atDal.User, "AtriumX", x1.GetType().ToString(), x1.Source, x1.Message, x1.StackTrace);
            }
            catch (Exception x)
            {
                //ignore
            }
        }


        public byte[] LoadFile(int fileId, AtriumXCon ax)
        {

            System.Web.HttpContext.Current.Session.Add("test", "test");

            //ResponseMsgComp rm = new ResponseMsgComp();
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetEFile().MainLoadByFileId(fileId);
        }


        public byte[] LoadACInfo( AtriumXCon ax)
        {
            //ResponseMsgComp rm = new ResponseMsgComp();
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.LoadActivityConfig();
        }
        public byte[] LoadDDInfo(AtriumXCon ax)
        {
            //ResponseMsgComp rm = new ResponseMsgComp();
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.LoadDataDictionary();
        }

        public void LogEvent(string eventType, string windowsUser, string lmUser, string workAs, string exType, string exSource, string exMessage, string exStack, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            atDal.LogEvent(eventType, windowsUser, lmUser, workAs, exType, exSource, exMessage, exStack);
        }
     
        public byte[] Load(string objectName, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = new atriumDAL.atriumDALManager(ax.User,ax.Pwd , ax.Connect);
            return atDal.Load(objectName);
        }




        public lmDatasets.officeDB.OfficerDataTable OfficerLoadByUserName(string userName, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByUserName(userName);
        }


        public byte[] OfficerLoad(int officerId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByte(officerId);
        }

        public lmDatasets.officeDB.OfficerDataTable OfficerLoadByRoleCode(string roleCode, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByRoleCode(roleCode);
        }

        public lmDatasets.officeDB.OfficerDataTable OfficerLoadByEmail(string email, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByEmail(email);
        }

        public lmDatasets.officeDB.OfficerDataTable OfficerLoadByOfficerCode(string officerCode, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByOfficerCode(officerCode);
        }

        public lmDatasets.officeDB.OfficerDataTable OfficerLoadByMyFileId(int fileid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByMyFileId(fileid);
        }

        public byte[] OfficerLoadByOfficeId(int officeId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficer().LoadByOfficeIdByte(officeId);
        }


        public lmDatasets.Advisory.OpinionDataTable OpinionLoadByFileId(int fileid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOpinion().LoadByFileID(fileid);
        }

        private static atriumDAL.atriumDALManager InitDAL(AtriumXCon ax)
        {
            System.Web.HttpContext.Current.Session.Add("test", "test");

            atriumDAL.atriumDALManager atDal = new   atriumDAL.atriumDALManager(ax.User, ax.Pwd, ax.Connect);
            return atDal;
        }


        public lmDatasets.officeDB.ContactEmailDataTable ContactEmailLoadByContactId(int contactid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetContactEmail().LoadByContactId(contactid);
        }

        public lmDatasets.officeDB.ContactEmailDataTable ContactEmailLoadByEmail(string email, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetContactEmail().LoadByEmail(email);
        }


        public byte[] OfficeLoad(int officeid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOffice().LoadByte(officeid);
        }

        public lmDatasets.officeDB.OfficeDataTable OfficeLoadByOfficeFileId(int fileid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOffice().LoadByOfficeFileId(fileid);
        }

        public lmDatasets.officeDB.OfficeDataTable OfficeLoadbyOfficeCode(string officeCode, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOffice().LoadByOfficeCode(officeCode);
        }


        public lmDatasets.officeDB.OfficerDelegateDataTable OfficerDelegateLoadByOfficerId(int officerid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficerDelegate().LoadByOfficerId(officerid);
        }

        public lmDatasets.officeDB.OfficerDelegateDataTable OfficerDelegateLoadByDelegateId(int delegateid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficerDelegate().LoadByDelegateToId(delegateid);
        }


        public lmDatasets.officeDB.MemberProfileDataTable MemberProfileLoad(int id, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetMemberProfile().Load(id);
        }


        public lmDatasets.officeDB.OfficerPrefsDataTable OfficerPrefsLoad(int id, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficerPrefs().LoadByOfficerId(id);
        }

        public lmDatasets.officeDB.OfficerRoleDataTable OfficerRoleLoad(int officerid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetOfficerRole().LoadByOfficerID(officerid);
        }

        public lmDatasets.officeDB.ServiceCentreDataTable ServiceCentreLoad(int officeid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            return atDal.GetServiceCentre().Load(officeid);
        }


        public lmDatasets.SecurityDB.secMembershipDataTable secMembershipLoadByUserId(int userId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            return atDal.GetsecMembership().LoadByUserId(userId);
        }

        public lmDatasets.SecurityDB.secUserDataTable secUserLoadByUserid(int userId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            return atDal.GetsecUser().Load(userId);
        }

        public lmDatasets.SecurityDB.secUserDataTable secUserLoadByUserName(string userName, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            return atDal.GetsecUser().Load(userName);
        }


        public string Alert(AtriumXCon ax, string lang)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.Alert(lang);
        }

        public void ExecuteSP(AtriumXCon ax, string spName, params object[] parameterValues)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            for (int i = 0; i < parameterValues.Length; i++)
            {
                if (parameterValues[i] != null && parameterValues[i].ToString() == "System.DBNull.Value")
                {
                    parameterValues[i] = System.DBNull.Value;
                }
            }
            atDal.ExecuteSP(spName, parameterValues);
        }

        public void ExecuteNonQuery(AtriumXCon ax, string sql)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            atDal.ExecuteNonQuery(sql);

        }

        public byte[] ExecuteDatasetByte(AtriumXCon ax, string spName, params object[] parameterValues)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            for (int i = 0; i < parameterValues.Length; i++)
            {
                if (parameterValues[i] != null && parameterValues[i].ToString() == "System.DBNull.Value")
                {
                    parameterValues[i] = System.DBNull.Value;
                }
            }

            return atDal.ExecuteDatasetByte(spName, parameterValues);
        }

        public System.Data.DataSet ExecuteDatasetSQL(AtriumXCon ax, string sql)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.ExecuteDatasetSQL(sql);
        }

        public object ExecuteScalar(AtriumXCon ax, string spName, params object[] parameterValues)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);

            for (int i = 0; i < parameterValues.Length; i++)
            {
                if (parameterValues[i] != null && parameterValues[i].ToString() == "System.DBNull.Value")
                {
                    parameterValues[i] = System.DBNull.Value;
                }
            }
            object o = atDal.ExecuteScalar(spName, parameterValues);
            if (o == System.DBNull.Value)
                return null;
            else
                return o;
        }

        public object ExecuteScalarSQL(AtriumXCon ax, string sql)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            object o = atDal.ExecuteScalarSQL(sql);
            if (o == System.DBNull.Value)
                return null;
            else
                return o;
        }
        public byte[] LoadCLAS(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetEFile().CLASLoadByFileId(fileId);
        }

        public byte[] LoadSST(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetSSTCase().LoadAll(fileId);
        }

        public byte[] LoadActivity(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivity().DeepLoadByFileId(fileId, System.Data.SerializationFormat.Binary);
        }

        public byte[] LoadDoc(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocument().LoadAllFile(fileId);
        }

        public byte[] LoadDocbyDocId(int docid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocument().LoadAll(docid);
        }


        public byte[] DocContentLoad(int docid, string version, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocContent().Load(docid, version);
        }

        public byte[] ActivityBFLoadBF(int officeId, int officerId, DateTime date, bool officerBF, long tmpLastEdit, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetActivityBF().LoadBF(officeId, officerId, date, officerBF, tmpLastEdit);
        }


        public System.Data.DataTable GetDataTable(string query, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDataTable(query);
        }

        public byte[] GetDataTableByte(string query, System.Data.SerializationFormat sf, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDataTable(query, sf);
        }

        public object PKIDGet(string objectName, int increment, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            object o=atDal.PKIDGet(objectName, increment);
            if (o == System.DBNull.Value)
                return null;
            else
                return o; 
        }

        public void PKIDSet(string objectName, int initial, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            atDal.PKIDSet(objectName, initial);
        }


        public byte[] ContactLoadByte(int contactid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetContact().LoadByte(contactid);
        }

        public byte[] FileSearch(string search, string keyword, int officeId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.FileSearch(search, keyword, officeId);
        }


        public lmDatasets.docDB.DocXRefDataTable DocXrefLoad(int Id, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocXRef().Load(Id);
        }

        public byte[] DocShortcuts(int fileId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.DocShortcuts(fileId);
        }


        public lmDatasets.appDB.ContactSearchDataTable ContactSearch(string where, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.ContactSearch(where);
        }

        public lmDatasets.appDB.ContactSearchDataTable PartySearch(string where, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.PartySearch(where);
        }

        public byte[] FileSearchDates(string userName, DateTime dateStart, DateTime dateEnd, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.FileSearch(userName, dateStart, dateEnd);
        }

        public byte[] FileSearchSimple(string where, bool includeXrefs, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.FileSearch(where, includeXrefs);
        }

        public byte[] FileSearchAdvanced(string where, string whereContact, string whereCaseStatus, bool includeXrefs, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.FileSearch(where, whereContact, whereCaseStatus, includeXrefs);
        }

        public byte[] FileSearchByThread(string keyword, int officeId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.FileSearchByThread(keyword, officeId);
        }

        public string HitHilite(int docRefId, string searchTerm, bool summaryResults, string VersionNumber, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.HitHilite(docRefId, searchTerm, summaryResults, VersionNumber);
        }


        public lmDatasets.appDB.EFileSearchDataTable SearchByContact(int contactId, string contactType, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetEFile().SearchByContact(contactId, contactType);
        }

        public byte[] Search(string filter, bool includeXrefs, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocument().Search(filter, includeXrefs);
        }

        public byte[] SearchQuick(string filter, bool opinionsOnly, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocument().SearchQuick(filter, opinionsOnly);
        }


        public lmDatasets.atriumDB.AddressDataTable AddressLoad(int AddressId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetAddress().Load(AddressId);
        }

        public lmDatasets.atriumDB.AddressDataTable AddressLoadByContactId(int ContactId, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetAddress().LoadByContactId(ContactId);
        }


        public int DocContentAuditDelete(int docId, string version, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocContent().DocContentAuditDelete(docId, version);
        }

        public bool DocContentIsLatest(int docId, byte[] timeStamp, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocContent().IsLatest(docId, timeStamp);
        }

        public lmDatasets.docDB.VersionHistoryListDataTable DocContentLoadVersionHistory(int DocId, int Fileid, AtriumXCon ax)
        {
            atriumDAL.atriumDALManager atDal = InitDAL(ax);
            return atDal.GetDocContent().LoadVersionHistory(DocId, Fileid);
        }
    }
}
