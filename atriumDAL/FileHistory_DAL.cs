using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on FileHistory table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class FileHistoryDAL:atDAL.ObjectDAL
	{

    	internal FileHistoryDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "FileHistory", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("HistoryId", "HistoryId"),
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("OfficeId", "OfficeId"),
		  new System.Data.Common.DataColumnMapping("SentToOfficeDate", "SentToOfficeDate"),
		  new System.Data.Common.DataColumnMapping("ReceivedByOfficeDate", "ReceivedByOfficeDate"),
		  new System.Data.Common.DataColumnMapping("ReturnedByOfficeDate", "ReturnedByOfficeDate"),
		  new System.Data.Common.DataColumnMapping("ReceivedFromOfficeDate", "ReceivedFromOfficeDate"),
		  new System.Data.Common.DataColumnMapping("StatusCode", "StatusCode"),
		  new System.Data.Common.DataColumnMapping("ReturnCode", "ReturnCode"),
		  new System.Data.Common.DataColumnMapping("BillingCode", "BillingCode"),
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

			this.sqlSelectAll.CommandText = "[FileHistorySelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[FileHistoryInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@HistoryId", SqlDbType.Int, 4, "HistoryId"));
			this.sqlInsert.Parameters["@HistoryId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
			this.sqlInsert.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeId", SqlDbType.Int, 4, "OfficeId"));
			this.sqlInsert.Parameters["@OfficeId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SentToOfficeDate", SqlDbType.SmallDateTime, 24, "SentToOfficeDate"));
			this.sqlInsert.Parameters["@SentToOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReceivedByOfficeDate", SqlDbType.SmallDateTime, 24, "ReceivedByOfficeDate"));
			this.sqlInsert.Parameters["@ReceivedByOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReturnedByOfficeDate", SqlDbType.SmallDateTime, 24, "ReturnedByOfficeDate"));
			this.sqlInsert.Parameters["@ReturnedByOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReceivedFromOfficeDate", SqlDbType.SmallDateTime, 24, "ReceivedFromOfficeDate"));
			this.sqlInsert.Parameters["@ReceivedFromOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.NVarChar, 1, "StatusCode"));
			this.sqlInsert.Parameters["@StatusCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 4, "ReturnCode"));
			this.sqlInsert.Parameters["@ReturnCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@BillingCode", SqlDbType.NVarChar, 2, "BillingCode"));
			this.sqlInsert.Parameters["@BillingCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			//this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			//this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[FileHistoryUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HistoryId", SqlDbType.Int, 4, "HistoryId"));
			this.sqlUpdate.Parameters["@HistoryId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
			this.sqlUpdate.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeId", SqlDbType.Int, 4, "OfficeId"));
			this.sqlUpdate.Parameters["@OfficeId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SentToOfficeDate", SqlDbType.SmallDateTime, 24, "SentToOfficeDate"));
			this.sqlUpdate.Parameters["@SentToOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReceivedByOfficeDate", SqlDbType.SmallDateTime, 24, "ReceivedByOfficeDate"));
			this.sqlUpdate.Parameters["@ReceivedByOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReturnedByOfficeDate", SqlDbType.SmallDateTime, 24, "ReturnedByOfficeDate"));
			this.sqlUpdate.Parameters["@ReturnedByOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReceivedFromOfficeDate", SqlDbType.SmallDateTime, 24, "ReceivedFromOfficeDate"));
			this.sqlUpdate.Parameters["@ReceivedFromOfficeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.NVarChar, 1, "StatusCode"));
			this.sqlUpdate.Parameters["@StatusCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 4, "ReturnCode"));
			this.sqlUpdate.Parameters["@ReturnCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@BillingCode", SqlDbType.NVarChar, 2, "BillingCode"));
			this.sqlUpdate.Parameters["@BillingCode"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[FileHistoryDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HistoryId", System.Data.SqlDbType.Int, 4, "HistoryId"));
		    this.sqlDelete.Parameters["@HistoryId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public CLAS.FileHistoryDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.FileHistoryDataTable dt=new CLAS.FileHistoryDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CLAS.FileHistoryDataTable Load(int HistoryId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileHistorySelectByHistoryId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HistoryId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@HistoryId"].Value=HistoryId;

            CLAS.FileHistoryDataTable dt=new CLAS.FileHistoryDataTable();
			Fill(dt);
            return dt;
		}


		public CLAS.FileHistoryDataTable LoadByFileId(int FileId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileHistorySelectByFileId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileId"].Value=FileId;

            CLAS.FileHistoryDataTable dt=new CLAS.FileHistoryDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.FileHistoryDataTable LoadByOfficeId(int OfficeId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileHistorySelectByOfficeId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@OfficeId"].Value=OfficeId;

            CLAS.FileHistoryDataTable dt=new CLAS.FileHistoryDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}