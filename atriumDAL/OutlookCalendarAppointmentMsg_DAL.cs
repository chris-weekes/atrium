using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    public partial class OutlookCalendarAppointmentMsgDAL : atDAL.ObjectDAL
    {
        internal OutlookCalendarAppointmentMsgDAL(atriumDALManager pDALManager)
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
          new System.Data.Common.DataColumnMapping("FileNumber", "FileNumber"),
		  new System.Data.Common.DataColumnMapping("HearingStatus", "HearingStatus"),
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
          })});

            // 
            // sqlSelect
            // 
          this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
          this.sqlSelect.Connection = myDALManager.SqlCon;

            //this.sqlSelectAll.CommandText = "[OutlookCalendarAppointmentMessageGet]";
            //this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            //this.sqlSelectAll.Connection = myDALManager.SqlCon;
            //this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            //// 
            //// sqlUpdate
            //// 
            //this.sqlUpdate.CommandText = "[OutlookCalendarAppointmentMessageGet]";
            //this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            //this.sqlUpdate.Connection = myDALManager.SqlCon;
            //this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            //this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
            //this.sqlUpdate.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@NameE", SqlDbType.NVarChar, 255, "NameE"));
            //this.sqlUpdate.Parameters["@NameE"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@NameF", SqlDbType.NVarChar, 255, "NameF"));
            //this.sqlUpdate.Parameters["@NameF"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@FileNumber", SqlDbType.NVarChar, 16, "FileNumber"));
            //this.sqlUpdate.Parameters["@FileNumber"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingStatus", SqlDbType.Int, 10, "HearingStatus"));
            //this.sqlUpdate.Parameters["@HearingStatus"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodEng", SqlDbType.NVarChar, 50, "HearingMethodEng"));
            //this.sqlUpdate.Parameters["@HearingMethodEng"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodFre", SqlDbType.NVarChar, 50, "HearingMethodFre"));
            //this.sqlUpdate.Parameters["@HearingMethodFre"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTimeOffset, 50, "StartDate"));
            //this.sqlUpdate.Parameters["@StartDate"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName"));
            //this.sqlUpdate.Parameters["@FirstName"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName"));
            //this.sqlUpdate.Parameters["@LastName"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ContactTypeCode", SqlDbType.NVarChar, 4, "ContactTypeCode"));
            //this.sqlUpdate.Parameters["@ContactTypeCode"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ContactTypeDescEng", SqlDbType.NVarChar, 50, "ContactTypeDescEng"));
            //this.sqlUpdate.Parameters["@ContactTypeDescEng"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ContactTypeDescFre", SqlDbType.NVarChar, 50, "ContactTypeDescFre"));
            //this.sqlUpdate.Parameters["@ContactTypeDescFre"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@AppealLevelId", SqlDbType.Int, 10, "AppealLevelId"));
            //this.sqlUpdate.Parameters["@AppealLevelId"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@AppealLevelEng", SqlDbType.NVarChar, 50, "AppealLevelEng"));
            //this.sqlUpdate.Parameters["@AppealLevelEng"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@AppealLevelFre", SqlDbType.NVarChar, 50, "AppealLevelFre"));
            //this.sqlUpdate.Parameters["@AppealLevelFre"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ProgramID", SqlDbType.Int, 10, "ProgramID"));
            //this.sqlUpdate.Parameters["@ProgramID"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ProgramDescriptionEng", SqlDbType.NVarChar, 50, "ProgramDescriptionEng"));
            //this.sqlUpdate.Parameters["@ProgramDescriptionEng"].SourceVersion = DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ProgramDescriptionFre", SqlDbType.NVarChar, 50, "ProgramDescriptionFre"));
            //this.sqlUpdate.Parameters["@ProgramDescriptionFre"].SourceVersion = DataRowVersion.Current;

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
