using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    public partial class OutlookCalAppMsgDAL : atDAL.ObjectDAL
    {
        internal OutlookCalAppMsgDAL(atriumDALManager pDALManager)
            : base(pDALManager)
		{
			Init();
		}

        private void Init()
        {

          this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "OutlookCalAppMsg", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("NameE", "NameE"),
		  new System.Data.Common.DataColumnMapping("NameF", "NameF"),
          new System.Data.Common.DataColumnMapping("FullFileNumber", "FullFileNumber"),
		  new System.Data.Common.DataColumnMapping("HearingStatusEng", "HearingStatusEng"),
          new System.Data.Common.DataColumnMapping("HearingStatusFre", "HearingStatusFre"),
		  new System.Data.Common.DataColumnMapping("HearingMethodEng", "HearingMethodEng"),
		  new System.Data.Common.DataColumnMapping("HearingMethodFre", "HearingMethodFre"),
          new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
          new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
          new System.Data.Common.DataColumnMapping("LastName", "LastName"),
          new System.Data.Common.DataColumnMapping("ContactTypeCode", "ContactTypeCode"),
          new System.Data.Common.DataColumnMapping("ContactTypeDescEng", "ContactTypeDescEng"),
          new System.Data.Common.DataColumnMapping("ContactTypeDescFre", "ContactTypeDescFre"),
          new System.Data.Common.DataColumnMapping("AppealLevelId", "AppealLevelId"),
          new System.Data.Common.DataColumnMapping("AppealLevelEng", "AppealLevelEng"),
          new System.Data.Common.DataColumnMapping("AppealLevelFre", "AppealLevelFre"),
          new System.Data.Common.DataColumnMapping("ProgramId", "ProgramId"),
          new System.Data.Common.DataColumnMapping("ProgramDescriptionEng", "ProgramDescriptionEng"),
          new System.Data.Common.DataColumnMapping("ProgramDescriptionFre", "ProgramDescriptionFre"),
          new System.Data.Common.DataColumnMapping("IsAppellant", "IsAppellant"),
          new System.Data.Common.DataColumnMapping("DelegateFor", "DelegateFor"),
          new System.Data.Common.DataColumnMapping("LanguageCode", "LanguageCode"),
          })});

          // 
          // sqlSelect
          // 
          this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
          this.sqlSelect.Connection = myDALManager.SqlCon;

        }

        public appDB.OutlookCalAppMsgDataTable LoadOutlookCalendarAppointmentMsgByFileId(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[OutlookCalendarAppointmentMessageGet]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            appDB.OutlookCalAppMsgDataTable dt = new appDB.OutlookCalAppMsgDataTable();
            Fill(dt);
            return dt;
        }
    }
}
