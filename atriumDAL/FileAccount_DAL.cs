using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on FileAccount table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class FileAccountDAL:atDAL.ObjectDAL
	{

    	internal FileAccountDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "FileAccount", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("FileAccountId", "FileAccountId"),
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("AccountTypeId", "AccountTypeId"),
		  new System.Data.Common.DataColumnMapping("OfficeID", "OfficeID"),
		  new System.Data.Common.DataColumnMapping("ActiveWithJustice", "ActiveWithJustice"),
		  new System.Data.Common.DataColumnMapping("StatusCode", "StatusCode"),
		  new System.Data.Common.DataColumnMapping("ReceivedByJusticeDate", "ReceivedByJusticeDate"),
		  new System.Data.Common.DataColumnMapping("ClosureDate", "ClosureDate"),
		  new System.Data.Common.DataColumnMapping("ClosureCode", "ClosureCode"),
		  new System.Data.Common.DataColumnMapping("StatementRequest", "StatementRequest"),
		  new System.Data.Common.DataColumnMapping("MSOARequest", "MSOARequest"),
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

			this.sqlSelectAll.CommandText = "[FileAccountSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[FileAccountInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileAccountId", SqlDbType.Int, 4, "FileAccountId"));
			this.sqlInsert.Parameters["@FileAccountId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
			this.sqlInsert.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AccountTypeId", SqlDbType.Int, 4, "AccountTypeId"));
			this.sqlInsert.Parameters["@AccountTypeId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
			this.sqlInsert.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ActiveWithJustice", SqlDbType.Bit, 1, "ActiveWithJustice"));
			this.sqlInsert.Parameters["@ActiveWithJustice"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.NVarChar, 1, "StatusCode"));
			this.sqlInsert.Parameters["@StatusCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReceivedByJusticeDate", SqlDbType.SmallDateTime, 24, "ReceivedByJusticeDate"));
			this.sqlInsert.Parameters["@ReceivedByJusticeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ClosureDate", SqlDbType.SmallDateTime, 24, "ClosureDate"));
			this.sqlInsert.Parameters["@ClosureDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ClosureCode", SqlDbType.NVarChar, 4, "ClosureCode"));
			this.sqlInsert.Parameters["@ClosureCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@StatementRequest", SqlDbType.SmallInt, 5, "StatementRequest"));
			this.sqlInsert.Parameters["@StatementRequest"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@MSOARequest", SqlDbType.SmallInt, 5, "MSOARequest"));
			this.sqlInsert.Parameters["@MSOARequest"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[FileAccountUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileAccountId", SqlDbType.Int, 4, "FileAccountId"));
			this.sqlUpdate.Parameters["@FileAccountId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
			this.sqlUpdate.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AccountTypeId", SqlDbType.Int, 4, "AccountTypeId"));
			this.sqlUpdate.Parameters["@AccountTypeId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
			this.sqlUpdate.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ActiveWithJustice", SqlDbType.Bit, 1, "ActiveWithJustice"));
			this.sqlUpdate.Parameters["@ActiveWithJustice"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.NVarChar, 1, "StatusCode"));
			this.sqlUpdate.Parameters["@StatusCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReceivedByJusticeDate", SqlDbType.SmallDateTime, 24, "ReceivedByJusticeDate"));
			this.sqlUpdate.Parameters["@ReceivedByJusticeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ClosureDate", SqlDbType.SmallDateTime, 24, "ClosureDate"));
			this.sqlUpdate.Parameters["@ClosureDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ClosureCode", SqlDbType.NVarChar, 4, "ClosureCode"));
			this.sqlUpdate.Parameters["@ClosureCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@StatementRequest", SqlDbType.SmallInt, 5, "StatementRequest"));
			this.sqlUpdate.Parameters["@StatementRequest"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@MSOARequest", SqlDbType.SmallInt, 5, "MSOARequest"));
			this.sqlUpdate.Parameters["@MSOARequest"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[FileAccountDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileAccountId", System.Data.SqlDbType.Int, 4, "FileAccountId"));
		    this.sqlDelete.Parameters["@FileAccountId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public CLAS.FileAccountDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.FileAccountDataTable dt = new CLAS.FileAccountDataTable();
			Fill(dt);
            return dt;
        }



        public CLAS.FileAccountDataTable Load(int FileAccountId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileAccountSelectByFileAccountId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileAccountId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@FileAccountId"].Value=FileAccountId;

            CLAS.FileAccountDataTable dt = new CLAS.FileAccountDataTable();
			Fill(dt);
            return dt;
		}


        public CLAS.FileAccountDataTable LoadByFileId(int FileId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileAccountSelectByFileId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileId"].Value=FileId;

            CLAS.FileAccountDataTable dt = new CLAS.FileAccountDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
