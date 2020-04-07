using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Map table 
	/// in atrium database
	/// on 11/26/2012
	/// </summary>
	public partial class MapDAL:atDAL.ObjectDAL
	{

    	internal MapDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Map", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("Id", "Id"),
		  new System.Data.Common.DataColumnMapping("AtriumTable", "AtriumTable"),
		  new System.Data.Common.DataColumnMapping("AtriumField", "AtriumField"),
		  new System.Data.Common.DataColumnMapping("AtriumId", "AtriumId"),
		  new System.Data.Common.DataColumnMapping("AtriumCode", "AtriumCode"),
		  new System.Data.Common.DataColumnMapping("OtherTable", "OtherTable"),
		  new System.Data.Common.DataColumnMapping("OtherField", "OtherField"),
		  new System.Data.Common.DataColumnMapping("OtherId", "OtherId"),
		  new System.Data.Common.DataColumnMapping("OtherCode", "OtherCode"),
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

			this.sqlSelectAll.CommandText = "[MapSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[MapInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 10, "Id"));
			this.sqlInsert.Parameters["@Id"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AtriumTable", SqlDbType.NVarChar, 50, "AtriumTable"));
			this.sqlInsert.Parameters["@AtriumTable"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AtriumField", SqlDbType.NVarChar, 50, "AtriumField"));
			this.sqlInsert.Parameters["@AtriumField"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AtriumId", SqlDbType.Int, 10, "AtriumId"));
			this.sqlInsert.Parameters["@AtriumId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AtriumCode", SqlDbType.NVarChar, 50, "AtriumCode"));
			this.sqlInsert.Parameters["@AtriumCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OtherTable", SqlDbType.NVarChar, 50, "OtherTable"));
			this.sqlInsert.Parameters["@OtherTable"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OtherField", SqlDbType.NVarChar, 50, "OtherField"));
			this.sqlInsert.Parameters["@OtherField"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OtherId", SqlDbType.Int, 10, "OtherId"));
			this.sqlInsert.Parameters["@OtherId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OtherCode", SqlDbType.NVarChar, 50, "OtherCode"));
			this.sqlInsert.Parameters["@OtherCode"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[MapUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 10, "Id"));
			this.sqlUpdate.Parameters["@Id"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AtriumTable", SqlDbType.NVarChar, 50, "AtriumTable"));
			this.sqlUpdate.Parameters["@AtriumTable"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AtriumField", SqlDbType.NVarChar, 50, "AtriumField"));
			this.sqlUpdate.Parameters["@AtriumField"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AtriumId", SqlDbType.Int, 10, "AtriumId"));
			this.sqlUpdate.Parameters["@AtriumId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AtriumCode", SqlDbType.NVarChar, 50, "AtriumCode"));
			this.sqlUpdate.Parameters["@AtriumCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OtherTable", SqlDbType.NVarChar, 50, "OtherTable"));
			this.sqlUpdate.Parameters["@OtherTable"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OtherField", SqlDbType.NVarChar, 50, "OtherField"));
			this.sqlUpdate.Parameters["@OtherField"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OtherId", SqlDbType.Int, 10, "OtherId"));
			this.sqlUpdate.Parameters["@OtherId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OtherCode", SqlDbType.NVarChar, 50, "OtherCode"));
			this.sqlUpdate.Parameters["@OtherCode"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[MapDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"));
		    this.sqlDelete.Parameters["@Id"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public appDB.MapDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            appDB.MapDataTable dt = new appDB.MapDataTable();
			Fill(dt);
            return dt;
        }



         public appDB.MapDataTable Load(int Id)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[MapSelectById]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@Id"].Value=Id;

            appDB.MapDataTable dt = new appDB.MapDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
