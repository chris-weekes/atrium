using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Sex table 
	/// in lawmate database
	/// on 3/12/2007
	/// </summary>
	public partial class SexDAL:atDAL.ObjectDAL
	{

    	internal SexDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Sex", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("SexCode", "SexCode"),
		  new System.Data.Common.DataColumnMapping("SexDescEng", "SexDescEng"),
		  new System.Data.Common.DataColumnMapping("SexDescFre", "SexDescFre"),
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

			this.sqlSelectAll.CommandText = "[SexSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[SexInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@SexCode", SqlDbType.NVarChar, 1, "SexCode"));
			this.sqlInsert.Parameters["@SexCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SexDescEng", SqlDbType.NVarChar, 50, "SexDescEng"));
			this.sqlInsert.Parameters["@SexDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SexDescFre", SqlDbType.NVarChar, 50, "SexDescFre"));
			this.sqlInsert.Parameters["@SexDescFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[SexUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SexCode", SqlDbType.NVarChar, 1, "SexCode"));
			this.sqlUpdate.Parameters["@SexCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SexDescEng", SqlDbType.NVarChar, 50, "SexDescEng"));
			this.sqlUpdate.Parameters["@SexDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SexDescFre", SqlDbType.NVarChar, 50, "SexDescFre"));
			this.sqlUpdate.Parameters["@SexDescFre"].SourceVersion=DataRowVersion.Current;
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
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            //this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Original;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[SexDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SexCode", System.Data.SqlDbType.NVarChar, 1, "SexCode"));
		    this.sqlDelete.Parameters["@SexCode"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public CodesDB.SexDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CodesDB.SexDataTable dt=new CodesDB.SexDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CodesDB.SexDataTable Load(string SexCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[SexSelectBySexCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SexCode", System.Data.SqlDbType.NVarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@SexCode"].Value=SexCode;

            CodesDB.SexDataTable dt=new CodesDB.SexDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
