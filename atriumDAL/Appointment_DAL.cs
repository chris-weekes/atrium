using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Appointment table 
	/// in atrium database
	/// on 10/31/2012
	/// </summary>
	public partial class AppointmentDAL:atDAL.ObjectDAL
	{

    	internal AppointmentDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

          private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Appointment", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ApptId", "ApptId"),
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("ActivityId", "ActivityId"),
		  new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
		  new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
		  new System.Data.Common.DataColumnMapping("Type", "Type"),
		  new System.Data.Common.DataColumnMapping("Subject", "Subject"),
		  new System.Data.Common.DataColumnMapping("ShowAsBusy", "ShowAsBusy"),
		  new System.Data.Common.DataColumnMapping("AllDayEvent", "AllDayEvent"),
		  new System.Data.Common.DataColumnMapping("Description", "Description"),
		  new System.Data.Common.DataColumnMapping("Location", "Location"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("Tentative", "Tentative"),
          new System.Data.Common.DataColumnMapping("Vacation", "Vacation"),
          new System.Data.Common.DataColumnMapping("ApptRecurrenceId", "ApptRecurrenceId"),
          new System.Data.Common.DataColumnMapping("OriginalRecurrence", "OriginalRecurrence"),

          
          
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[AppointmentSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[AppointmentInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@ApptId", SqlDbType.Int, 10, "ApptId"));
			this.sqlInsert.Parameters["@ApptId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
			this.sqlInsert.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ActivityId", SqlDbType.Int, 10, "ActivityId"));
			this.sqlInsert.Parameters["@ActivityId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTimeOffset, 50, "StartDate"));
			this.sqlInsert.Parameters["@StartDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTimeOffset, 50, "EndDate"));
			this.sqlInsert.Parameters["@EndDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 10, "Type"));
			this.sqlInsert.Parameters["@Type"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 255, "Subject"));
			this.sqlInsert.Parameters["@Subject"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ShowAsBusy", SqlDbType.Bit, 1, "ShowAsBusy"));
			this.sqlInsert.Parameters["@ShowAsBusy"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AllDayEvent", SqlDbType.Bit, 1, "AllDayEvent"));
			this.sqlInsert.Parameters["@AllDayEvent"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1, "Description"));
			this.sqlInsert.Parameters["@Description"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Location", SqlDbType.NVarChar, 255, "Location"));
			this.sqlInsert.Parameters["@Location"].SourceVersion=DataRowVersion.Current;
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
			this.sqlInsert.Parameters.Add(new SqlParameter("@Tentative", SqlDbType.Bit, 1, "Tentative"));
			this.sqlInsert.Parameters["@Tentative"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Vacation", SqlDbType.Bit, 1, "Vacation"));
            this.sqlInsert.Parameters["@Vacation"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ApptRecurrenceId", SqlDbType.Int, 10, "ApptRecurrenceId"));
            this.sqlInsert.Parameters["@ApptRecurrenceId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OriginalRecurrence", SqlDbType.Bit, 1, "OriginalRecurrence"));
            this.sqlInsert.Parameters["@OriginalRecurrence"].SourceVersion = DataRowVersion.Current;


            
			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[AppointmentUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ApptId", SqlDbType.Int, 10, "ApptId"));
			this.sqlUpdate.Parameters["@ApptId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
			this.sqlUpdate.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ActivityId", SqlDbType.Int, 10, "ActivityId"));
			this.sqlUpdate.Parameters["@ActivityId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTimeOffset , 50, "StartDate"));
			this.sqlUpdate.Parameters["@StartDate"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTimeOffset, 50, "EndDate"));
			this.sqlUpdate.Parameters["@EndDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Type", SqlDbType.Int, 10, "Type"));
			this.sqlUpdate.Parameters["@Type"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Subject", SqlDbType.NVarChar, 255, "Subject"));
			this.sqlUpdate.Parameters["@Subject"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ShowAsBusy", SqlDbType.Bit, 1, "ShowAsBusy"));
			this.sqlUpdate.Parameters["@ShowAsBusy"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AllDayEvent", SqlDbType.Bit, 1, "AllDayEvent"));
			this.sqlUpdate.Parameters["@AllDayEvent"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, -1, "Description"));
			this.sqlUpdate.Parameters["@Description"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Location", SqlDbType.NVarChar, 255, "Location"));
			this.sqlUpdate.Parameters["@Location"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Tentative", SqlDbType.Bit, 1, "Tentative"));
			this.sqlUpdate.Parameters["@Tentative"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Vacation", SqlDbType.Bit, 1, "Vacation"));
            this.sqlUpdate.Parameters["@Vacation"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ApptRecurrenceId", SqlDbType.Int, 10, "ApptRecurrenceId"));
            this.sqlUpdate.Parameters["@ApptRecurrenceId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OriginalRecurrence", SqlDbType.Bit, 1, "OriginalRecurrence"));
            this.sqlUpdate.Parameters["@OriginalRecurrence"].SourceVersion = DataRowVersion.Current;


            

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[AppointmentDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApptId", System.Data.SqlDbType.Int, 4, "ApptId"));
		    this.sqlDelete.Parameters["@ApptId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public atriumDB.AppointmentDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.AppointmentDataTable dt=new atriumDB.AppointmentDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public atriumDB.AppointmentDataTable Load(int ApptId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[AppointmentSelectByApptId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApptId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ApptId"].Value=ApptId;

            atriumDB.AppointmentDataTable dt=new atriumDB.AppointmentDataTable();
			Fill(dt);
            return dt;
		}


		public atriumDB.AppointmentDataTable LoadByFileId(int FileId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[AppointmentSelectByFileId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileId"].Value=FileId;

            atriumDB.AppointmentDataTable dt=new atriumDB.AppointmentDataTable();
			Fill(dt);
            return dt;
		}

        public atriumDB.AppointmentDataTable LoadByApptRecurrenceId(int ApptRecurrenceId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[AppointmentSelectByApptRecurrenceId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApptRecurrenceId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@ApptRecurrenceId"].Value = ApptRecurrenceId;

            atriumDB.AppointmentDataTable dt = new atriumDB.AppointmentDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.AppointmentDataTable LoadByOrigApptRecurrenceId(int ApptRecurrenceId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[AppointmentSelectByOrigApptRecurrenceId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ApptRecurrenceId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@ApptRecurrenceId"].Value = ApptRecurrenceId;

            atriumDB.AppointmentDataTable dt = new atriumDB.AppointmentDataTable();
            Fill(dt);
            return dt;
        }
	}
	

}
