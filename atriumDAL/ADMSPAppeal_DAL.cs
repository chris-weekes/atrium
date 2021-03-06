using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ADMSPAppeal table 
	/// in atrium database
	/// on 11/26/2012
	/// </summary>
	public partial class ADMSPAppealDAL:atDAL.ObjectDAL
	{

    	internal ADMSPAppealDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ADMSPAppeal", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("Id", "Id"),
		  new System.Data.Common.DataColumnMapping("SSTFileNumber", "SSTFileNumber"),
		  new System.Data.Common.DataColumnMapping("AppealLevelId", "AppealLevelId"),
		  new System.Data.Common.DataColumnMapping("AtriumUser", "AtriumUser"),
		  new System.Data.Common.DataColumnMapping("AppealLevelDate", "AppealLevelDate"),
		  new System.Data.Common.DataColumnMapping("ClientId", "ClientId"),
		  new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
		  new System.Data.Common.DataColumnMapping("LastName", "LastName"),
		  new System.Data.Common.DataColumnMapping("IdentifierNumber", "IdentifierNumber"),
		  new System.Data.Common.DataColumnMapping("TransferStatus", "TransferStatus"),
		  new System.Data.Common.DataColumnMapping("ActionStatus", "ActionStatus"),
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

			this.sqlSelectAll.CommandText = "[ADMSPAppealSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ADMSPAppealInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 10, "Id"));
			this.sqlInsert.Parameters["@Id"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SSTFileNumber", SqlDbType.NVarChar, 12, "SSTFileNumber"));
			this.sqlInsert.Parameters["@SSTFileNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AppealLevelId", SqlDbType.Int, 10, "AppealLevelId"));
			this.sqlInsert.Parameters["@AppealLevelId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AtriumUser", SqlDbType.NVarChar, 80, "AtriumUser"));
			this.sqlInsert.Parameters["@AtriumUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AppealLevelDate", SqlDbType.DateTime, 24, "AppealLevelDate"));
			this.sqlInsert.Parameters["@AppealLevelDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ClientId", SqlDbType.Int, 10, "ClientId"));
			this.sqlInsert.Parameters["@ClientId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName"));
			this.sqlInsert.Parameters["@FirstName"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName"));
			this.sqlInsert.Parameters["@LastName"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@IdentifierNumber", SqlDbType.NVarChar, 12, "IdentifierNumber"));
			this.sqlInsert.Parameters["@IdentifierNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TransferStatus", SqlDbType.NVarChar, 30, "TransferStatus"));
			this.sqlInsert.Parameters["@TransferStatus"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ActionStatus", SqlDbType.NVarChar, 100, "ActionStatus"));
			this.sqlInsert.Parameters["@ActionStatus"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[ADMSPAppealUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 10, "Id"));
			this.sqlUpdate.Parameters["@Id"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SSTFileNumber", SqlDbType.NVarChar, 12, "SSTFileNumber"));
			this.sqlUpdate.Parameters["@SSTFileNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AppealLevelId", SqlDbType.Int, 10, "AppealLevelId"));
			this.sqlUpdate.Parameters["@AppealLevelId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AtriumUser", SqlDbType.NVarChar, 80, "AtriumUser"));
			this.sqlUpdate.Parameters["@AtriumUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AppealLevelDate", SqlDbType.DateTime, 24, "AppealLevelDate"));
			this.sqlUpdate.Parameters["@AppealLevelDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ClientId", SqlDbType.Int, 10, "ClientId"));
			this.sqlUpdate.Parameters["@ClientId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName"));
			this.sqlUpdate.Parameters["@FirstName"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName"));
			this.sqlUpdate.Parameters["@LastName"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@IdentifierNumber", SqlDbType.NVarChar, 12, "IdentifierNumber"));
			this.sqlUpdate.Parameters["@IdentifierNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TransferStatus", SqlDbType.NVarChar, 30, "TransferStatus"));
			this.sqlUpdate.Parameters["@TransferStatus"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ActionStatus", SqlDbType.NVarChar, 100, "ActionStatus"));
			this.sqlUpdate.Parameters["@ActionStatus"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[ADMSPAppealDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"));
		    this.sqlDelete.Parameters["@Id"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public SST.ADMSPAppealDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            SST.ADMSPAppealDataTable dt=new SST.ADMSPAppealDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public SST.ADMSPAppealDataTable Load(int Id)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ADMSPAppealSelectById]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@Id"].Value=Id;

            SST.ADMSPAppealDataTable dt=new SST.ADMSPAppealDataTable();
			Fill(dt);
            return dt;
		}


        public SST.ADMSPAppealDataTable LoadByFileNumber(string SSTFileNumber)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ADMSPAppealSelectBySSTFileNumber]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SSTFileNumber", System.Data.SqlDbType.NVarChar, 12));

            this.sqlSelect.Parameters["@SSTFileNumber"].Value = SSTFileNumber;

            SST.ADMSPAppealDataTable dt = new SST.ADMSPAppealDataTable();
            Fill(dt);
            return dt;
        }
	}
	

}
