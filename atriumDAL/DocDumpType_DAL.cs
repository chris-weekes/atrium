using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on DocDumpType table 
	/// in Lawmate_DEV database
	/// on 2015-01-05
	/// </summary>
	public partial class DocDumpTypeDAL : atDAL.ObjectDAL
	{

    	internal DocDumpTypeDAL(atriumDALManager pDALManager) :base(pDALManager)
		{
		    Init();
		}

        private void Init()
		{

            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] 
            {
		        new System.Data.Common.DataTableMapping("Table", "DocDumpType", new System.Data.Common.DataColumnMapping[] 
                {
		            new System.Data.Common.DataColumnMapping("DocDumpTypeId", "DocDumpTypeId"),
		            new System.Data.Common.DataColumnMapping("DocDumTypeDescEng", "DocDumTypeDescEng"),
		            new System.Data.Common.DataColumnMapping("DocDumpTypeDescFre", "DocDumpTypeDescFre"),
		            new System.Data.Common.DataColumnMapping("ReadOnly", "ReadOnly"),
		            new System.Data.Common.DataColumnMapping("Obsolete", "Obsolete"),
		            new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		            new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		            new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		            new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		            new System.Data.Common.DataColumnMapping("ts", "ts"),
			    })
            });
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[DocDumpTypeSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[DocDumpTypeInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@DocDumpTypeId", SqlDbType.Int, 10, "DocDumpTypeId"));
			this.sqlInsert.Parameters["@DocDumpTypeId"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DocDumTypeDescEng", SqlDbType.NVarChar, 50, "DocDumTypeDescEng"));
			this.sqlInsert.Parameters["@DocDumTypeDescEng"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DocDumpTypeDescFre", SqlDbType.NVarChar, 50, "DocDumpTypeDescFre"));
			this.sqlInsert.Parameters["@DocDumpTypeDescFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[DocDumpTypeUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DocDumpTypeId", SqlDbType.Int, 10, "DocDumpTypeId"));
			this.sqlUpdate.Parameters["@DocDumpTypeId"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DocDumTypeDescEng", SqlDbType.NVarChar, 50, "DocDumTypeDescEng"));
			this.sqlUpdate.Parameters["@DocDumTypeDescEng"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DocDumpTypeDescFre", SqlDbType.NVarChar, 50, "DocDumpTypeDescFre"));
			this.sqlUpdate.Parameters["@DocDumpTypeDescFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[DocDumpTypeDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocDumpTypeId", System.Data.SqlDbType.Int, 4, "DocDumpTypeId"));
		    this.sqlDelete.Parameters["@DocDumpTypeId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;

		}

		public CodesDB.DocDumpTypeDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CodesDB.DocDumpTypeDataTable dt = new CodesDB.DocDumpTypeDataTable();
			Fill(dt);
            return dt;
        }

        public CodesDB.DocDumpTypeDataTable Load(int DocDumpTypeId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[DocDumpTypeSelectByDocDumpTypeId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocDumpTypeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@DocDumpTypeId"].Value=DocDumpTypeId;

            CodesDB.DocDumpTypeDataTable dt = new CodesDB.DocDumpTypeDataTable();
			Fill(dt);
            return dt;
		}
	}

}