using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on DocContent table 
	/// in lawmate database
	/// on 1/21/2008
	/// </summary>
	public partial class DocContentDAL:atDAL.ObjectDAL
	{

    	internal DocContentDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "DocContent", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("DocId", "DocId"),
		  new System.Data.Common.DataColumnMapping("Ext", "Ext"),
		  new System.Data.Common.DataColumnMapping("ModDate", "ModDate"),
		  new System.Data.Common.DataColumnMapping("CreateDate", "CreateDate"),
		  new System.Data.Common.DataColumnMapping("Size", "Size"),
		  new System.Data.Common.DataColumnMapping("Version", "Version"),
		  new System.Data.Common.DataColumnMapping("ReadOnly", "ReadOnly"),
		  new System.Data.Common.DataColumnMapping("Contents", "Contents"),
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

			this.sqlSelectAll.CommandText = "[DocContentSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[DocContentInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
////****************************************************************            
            this.sqlInsert.CommandTimeout = 300;
////****************************************************************		
            this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@DocId", SqlDbType.Int, 10, "DocId"));
			this.sqlInsert.Parameters["@DocId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Ext", SqlDbType.NVarChar, 16, "Ext"));
			this.sqlInsert.Parameters["@Ext"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ModDate", SqlDbType.SmallDateTime, 24, "ModDate"));
			this.sqlInsert.Parameters["@ModDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 24, "CreateDate"));
			this.sqlInsert.Parameters["@CreateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Size", SqlDbType.Int, 10, "Size"));
			this.sqlInsert.Parameters["@Size"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Version", SqlDbType.Char, 10, "Version"));
			this.sqlInsert.Parameters["@Version"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Bit, 1, "ReadOnly"));
			this.sqlInsert.Parameters["@ReadOnly"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Contents", SqlDbType.VarBinary, 0, "Contents"));
			this.sqlInsert.Parameters["@Contents"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[DocContentUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
            ////****************************************************************            
            this.sqlUpdate.CommandTimeout = 300;
            ////****************************************************************		
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DocId", SqlDbType.Int, 10, "DocId"));
			this.sqlUpdate.Parameters["@DocId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Ext", SqlDbType.NVarChar, 16, "Ext"));
			this.sqlUpdate.Parameters["@Ext"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ModDate", SqlDbType.SmallDateTime, 24, "ModDate"));
			this.sqlUpdate.Parameters["@ModDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CreateDate", SqlDbType.SmallDateTime, 24, "CreateDate"));
			this.sqlUpdate.Parameters["@CreateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Size", SqlDbType.Int, 10, "Size"));
			this.sqlUpdate.Parameters["@Size"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Version", SqlDbType.Char, 10, "Version"));
			this.sqlUpdate.Parameters["@Version"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Bit, 1, "ReadOnly"));
			this.sqlUpdate.Parameters["@ReadOnly"].SourceVersion=DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@CheckedOutBy", SqlDbType.Int, 10, "CheckedOutBy"));
            //this.sqlUpdate.Parameters["@CheckedOutBy"].SourceVersion=DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@CheckedOutDate", SqlDbType.SmallDateTime, 24, "CheckedOutDate"));
            //this.sqlUpdate.Parameters["@CheckedOutDate"].SourceVersion=DataRowVersion.Current;
            //this.sqlUpdate.Parameters.Add(new SqlParameter("@CheckedOutPath", SqlDbType.NVarChar, 300, "CheckedOutPath"));
            //this.sqlUpdate.Parameters["@CheckedOutPath"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Contents", SqlDbType.VarBinary, 0, "Contents"));
			this.sqlUpdate.Parameters["@Contents"].SourceVersion=DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origVersion", SqlDbType.Char, 10, "Version"));
            this.sqlUpdate.Parameters["@origVersion"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@forceInsert", SqlDbType.Bit, 1, "forceInsert"));
            this.sqlUpdate.Parameters["@forceInsert"].SourceVersion = DataRowVersion.Current;
			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[DocContentDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocId", System.Data.SqlDbType.Int, 4, "DocId"));
		    this.sqlDelete.Parameters["@DocId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public docDB.DocContentDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            docDB.DocContentDataTable dt=new docDB.DocContentDataTable();
			Fill(dt);
            return dt;
        }



	}
	

}
