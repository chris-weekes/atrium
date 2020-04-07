using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ACSeriesType table 
	/// in lawmate_dev database
	/// on 2014-02-12
	/// </summary>
	public partial class ACSeriesTypeDAL:atDAL.ObjectDAL
	{

    	internal ACSeriesTypeDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ACSeriesType", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ACSeriesTypeId", "ACSeriesTypeId"),
		  new System.Data.Common.DataColumnMapping("ACSeriesTypeDescEng", "ACSeriesTypeDescEng"),
		  new System.Data.Common.DataColumnMapping("ACSeriesTypeDescFre", "ACSeriesTypeDescFre"),
		  new System.Data.Common.DataColumnMapping("ACSeriesTypeFullDescEng", "ACSeriesTypeFullDescEng"),
		  new System.Data.Common.DataColumnMapping("ACSeriesTypeFullDescFre", "ACSeriesTypeFullDescFre"),
		  new System.Data.Common.DataColumnMapping("ReadOnly", "ReadOnly"),
		  new System.Data.Common.DataColumnMapping("Obsolete", "Obsolete"),
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

			this.sqlSelectAll.CommandText = "[ACSeriesTypeSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ACSeriesTypeInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACSeriesTypeId", SqlDbType.Int, 10, "ACSeriesTypeId"));
			this.sqlInsert.Parameters["@ACSeriesTypeId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACSeriesTypeDescEng", SqlDbType.NVarChar, 50, "ACSeriesTypeDescEng"));
			this.sqlInsert.Parameters["@ACSeriesTypeDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACSeriesTypeDescFre", SqlDbType.NVarChar, 50, "ACSeriesTypeDescFre"));
			this.sqlInsert.Parameters["@ACSeriesTypeDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACSeriesTypeFullDescEng", SqlDbType.NVarChar, 512, "ACSeriesTypeFullDescEng"));
			this.sqlInsert.Parameters["@ACSeriesTypeFullDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACSeriesTypeFullDescFre", SqlDbType.NVarChar, 512, "ACSeriesTypeFullDescFre"));
			this.sqlInsert.Parameters["@ACSeriesTypeFullDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Bit, 1, "ReadOnly"));
			this.sqlInsert.Parameters["@ReadOnly"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Obsolete", SqlDbType.Bit, 1, "Obsolete"));
			this.sqlInsert.Parameters["@Obsolete"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[ACSeriesTypeUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACSeriesTypeId", SqlDbType.Int, 10, "ACSeriesTypeId"));
			this.sqlUpdate.Parameters["@ACSeriesTypeId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACSeriesTypeDescEng", SqlDbType.NVarChar, 50, "ACSeriesTypeDescEng"));
			this.sqlUpdate.Parameters["@ACSeriesTypeDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACSeriesTypeDescFre", SqlDbType.NVarChar, 50, "ACSeriesTypeDescFre"));
			this.sqlUpdate.Parameters["@ACSeriesTypeDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACSeriesTypeFullDescEng", SqlDbType.NVarChar, 512, "ACSeriesTypeFullDescEng"));
			this.sqlUpdate.Parameters["@ACSeriesTypeFullDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACSeriesTypeFullDescFre", SqlDbType.NVarChar, 512, "ACSeriesTypeFullDescFre"));
			this.sqlUpdate.Parameters["@ACSeriesTypeFullDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Bit, 1, "ReadOnly"));
			this.sqlUpdate.Parameters["@ReadOnly"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Obsolete", SqlDbType.Bit, 1, "Obsolete"));
			this.sqlUpdate.Parameters["@Obsolete"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[ACSeriesTypeDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ACSeriesTypeId", System.Data.SqlDbType.Int, 4, "ACSeriesTypeId"));
		    this.sqlDelete.Parameters["@ACSeriesTypeId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

        public ActivityConfig.ACSeriesTypeDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            ActivityConfig.ACSeriesTypeDataTable dt = new ActivityConfig.ACSeriesTypeDataTable();
			Fill(dt);
            return dt;
        }



        public ActivityConfig.ACSeriesTypeDataTable Load(int ACSeriesTypeId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ACSeriesTypeSelectByACSeriesTypeId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ACSeriesTypeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ACSeriesTypeId"].Value=ACSeriesTypeId;

            ActivityConfig.ACSeriesTypeDataTable dt = new ActivityConfig.ACSeriesTypeDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
