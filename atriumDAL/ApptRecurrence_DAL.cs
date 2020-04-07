using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ApptRecurrence table 
	/// in Lawmate_DEV database
	/// on 2015-01-22
	/// </summary>
	public partial class ApptRecurrenceDAL:atDAL.ObjectDAL
	{

    	internal ApptRecurrenceDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ApptRecurrence", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ApptRecurrenceId", "ApptRecurrenceId"),
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("ApptRecurrenceTypeId", "ApptRecurrenceTypeId"),
		  new System.Data.Common.DataColumnMapping("OccursEvery", "OccursEvery"),
		  new System.Data.Common.DataColumnMapping("StartRangeDate", "StartRangeDate"),
		  new System.Data.Common.DataColumnMapping("EndRangeDate", "EndRangeDate"),
		  new System.Data.Common.DataColumnMapping("Monday", "Monday"),
		  new System.Data.Common.DataColumnMapping("Tuesday", "Tuesday"),
		  new System.Data.Common.DataColumnMapping("Wednesday", "Wednesday"),
		  new System.Data.Common.DataColumnMapping("Thursday", "Thursday"),
		  new System.Data.Common.DataColumnMapping("Friday", "Friday"),
		  new System.Data.Common.DataColumnMapping("Saturday", "Saturday"),
		  new System.Data.Common.DataColumnMapping("Sunday", "Sunday"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[ApptRecurrenceSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ApptRecurrenceInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@ApptRecurrenceId", SqlDbType.Int, 10, "ApptRecurrenceId"));
			this.sqlInsert.Parameters["@ApptRecurrenceId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
			this.sqlInsert.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ApptRecurrenceTypeId", SqlDbType.Int, 10, "ApptRecurrenceTypeId"));
			this.sqlInsert.Parameters["@ApptRecurrenceTypeId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OccursEvery", SqlDbType.Int, 10, "OccursEvery"));
			this.sqlInsert.Parameters["@OccursEvery"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@StartRangeDate", SqlDbType.DateTimeOffset, 50, "StartRangeDate"));
			this.sqlInsert.Parameters["@StartRangeDate"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@EndRangeDate", SqlDbType.DateTimeOffset, 50, "EndRangeDate"));
			this.sqlInsert.Parameters["@EndRangeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Monday", SqlDbType.Bit, 1, "Monday"));
			this.sqlInsert.Parameters["@Monday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Tuesday", SqlDbType.Bit, 1, "Tuesday"));
			this.sqlInsert.Parameters["@Tuesday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Wednesday", SqlDbType.Bit, 1, "Wednesday"));
			this.sqlInsert.Parameters["@Wednesday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Thursday", SqlDbType.Bit, 1, "Thursday"));
			this.sqlInsert.Parameters["@Thursday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Friday", SqlDbType.Bit, 1, "Friday"));
			this.sqlInsert.Parameters["@Friday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Saturday", SqlDbType.Bit, 1, "Saturday"));
			this.sqlInsert.Parameters["@Saturday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Sunday", SqlDbType.Bit, 1, "Sunday"));
			this.sqlInsert.Parameters["@Sunday"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[ApptRecurrenceUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ApptRecurrenceId", SqlDbType.Int, 10, "ApptRecurrenceId"));
			this.sqlUpdate.Parameters["@ApptRecurrenceId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
			this.sqlUpdate.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ApptRecurrenceTypeId", SqlDbType.Int, 10, "ApptRecurrenceTypeId"));
			this.sqlUpdate.Parameters["@ApptRecurrenceTypeId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OccursEvery", SqlDbType.Int, 10, "OccursEvery"));
			this.sqlUpdate.Parameters["@OccursEvery"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@StartRangeDate", SqlDbType.DateTimeOffset, 50, "StartRangeDate"));
			this.sqlUpdate.Parameters["@StartRangeDate"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@EndRangeDate", SqlDbType.DateTimeOffset, 50, "EndRangeDate"));
			this.sqlUpdate.Parameters["@EndRangeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Monday", SqlDbType.Bit, 1, "Monday"));
			this.sqlUpdate.Parameters["@Monday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Tuesday", SqlDbType.Bit, 1, "Tuesday"));
			this.sqlUpdate.Parameters["@Tuesday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Wednesday", SqlDbType.Bit, 1, "Wednesday"));
			this.sqlUpdate.Parameters["@Wednesday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Thursday", SqlDbType.Bit, 1, "Thursday"));
			this.sqlUpdate.Parameters["@Thursday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Friday", SqlDbType.Bit, 1, "Friday"));
			this.sqlUpdate.Parameters["@Friday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Saturday", SqlDbType.Bit, 1, "Saturday"));
			this.sqlUpdate.Parameters["@Saturday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Sunday", SqlDbType.Bit, 1, "Sunday"));
			this.sqlUpdate.Parameters["@Sunday"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlUpdate.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlUpdate.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlUpdate.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlUpdate.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[ApptRecurrenceDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApptRecurrenceId", System.Data.SqlDbType.Int, 4, "ApptRecurrenceId"));
		    this.sqlDelete.Parameters["@ApptRecurrenceId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public atriumDB.ApptRecurrenceDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.ApptRecurrenceDataTable dt = new atriumDB.ApptRecurrenceDataTable();
			Fill(dt);
            return dt;
        }



         public atriumDB.ApptRecurrenceDataTable Load(int ApptRecurrenceId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ApptRecurrenceSelectByApptRecurrenceId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApptRecurrenceId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ApptRecurrenceId"].Value=ApptRecurrenceId;

            atriumDB.ApptRecurrenceDataTable dt = new atriumDB.ApptRecurrenceDataTable();
			Fill(dt);
            return dt;
		}

         public atriumDB.ApptRecurrenceDataTable LoadByFileId(int FileId)
         {
             this.sqlDa.SelectCommand = sqlSelect;
             this.sqlSelect.Parameters.Clear();
             this.sqlSelect.CommandText = "[ApptRecurrenceSelectByFileId]";
             this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
             this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
             this.sqlSelect.Parameters["@FileId"].Value = FileId;

             atriumDB.ApptRecurrenceDataTable dt = new atriumDB.ApptRecurrenceDataTable();
             Fill(dt);
             return dt;

         }
	}
	

}
