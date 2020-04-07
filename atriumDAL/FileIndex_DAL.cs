using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on FileIndex table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class FileIndexDAL:atDAL.ObjectDAL
	{

    	internal FileIndexDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "FileIndex", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("FileIndexID", "FileIndexID"),
		  new System.Data.Common.DataColumnMapping("SIN", "SIN"),
		  new System.Data.Common.DataColumnMapping("List", "List"),
		  new System.Data.Common.DataColumnMapping("JobNumber", "JobNumber"),
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

			this.sqlSelectAll.CommandText = "[FileIndexSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[FileIndexInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileIndexID", SqlDbType.Int, 4, "FileIndexID"));
			this.sqlInsert.Parameters["@FileIndexID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SIN", SqlDbType.VarChar, 9, "SIN"));
			this.sqlInsert.Parameters["@SIN"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@List", SqlDbType.Int, 4, "List"));
			this.sqlInsert.Parameters["@List"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JobNumber", SqlDbType.Int, 4, "JobNumber"));
			this.sqlInsert.Parameters["@JobNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.VarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.VarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			//this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			//this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[FileIndexUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileIndexID", SqlDbType.Int, 4, "FileIndexID"));
			this.sqlUpdate.Parameters["@FileIndexID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SIN", SqlDbType.VarChar, 9, "SIN"));
			this.sqlUpdate.Parameters["@SIN"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@List", SqlDbType.Int, 4, "List"));
			this.sqlUpdate.Parameters["@List"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JobNumber", SqlDbType.Int, 4, "JobNumber"));
			this.sqlUpdate.Parameters["@JobNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.VarChar, 20, "entryUser"));
			this.sqlUpdate.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlUpdate.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.VarChar, 20, "updateUser"));
			this.sqlUpdate.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlUpdate.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[FileIndexDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileIndexID", System.Data.SqlDbType.Int, 4, "FileIndexID"));
		    this.sqlDelete.Parameters["@FileIndexID"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public atriumDB.FileIndexDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.FileIndexDataTable dt=new atriumDB.FileIndexDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public atriumDB.FileIndexDataTable Load(int FileIndexID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileIndexSelectByFileIndexID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileIndexID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@FileIndexID"].Value=FileIndexID;

            atriumDB.FileIndexDataTable dt=new atriumDB.FileIndexDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
