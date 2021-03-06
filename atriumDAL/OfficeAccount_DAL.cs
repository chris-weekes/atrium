using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on OfficeAccount table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class OfficeAccountDAL:atDAL.ObjectDAL
	{

    	internal OfficeAccountDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "OfficeAccount", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("OfficeAccountID", "OfficeAccountID"),
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("OfficeID", "OfficeID"),
		  new System.Data.Common.DataColumnMapping("SRPID", "SRPID"),
		  new System.Data.Common.DataColumnMapping("Type", "Type"),
		  new System.Data.Common.DataColumnMapping("TransactionDate", "TransactionDate"),
		  new System.Data.Common.DataColumnMapping("PostingDate", "PostingDate"),
		  new System.Data.Common.DataColumnMapping("Amount", "Amount"),
		  new System.Data.Common.DataColumnMapping("Reason", "Reason"),
		  new System.Data.Common.DataColumnMapping("Description", "Description"),
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

			this.sqlSelectAll.CommandText = "[OfficeAccountSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[OfficeAccountInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeAccountID", SqlDbType.Int, 4, "OfficeAccountID"));
			this.sqlInsert.Parameters["@OfficeAccountID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
			this.sqlInsert.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
			this.sqlInsert.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SRPID", SqlDbType.Int, 4, "SRPID"));
			this.sqlInsert.Parameters["@SRPID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 2, "Type"));
			this.sqlInsert.Parameters["@Type"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.SmallDateTime, 24, "TransactionDate"));
			this.sqlInsert.Parameters["@TransactionDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostingDate", SqlDbType.SmallDateTime, 24, "PostingDate"));
			this.sqlInsert.Parameters["@PostingDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 19, "Amount"));
			this.sqlInsert.Parameters["@Amount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 4, "Reason"));
			this.sqlInsert.Parameters["@Reason"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 100, "Description"));
			this.sqlInsert.Parameters["@Description"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[OfficeAccountUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeAccountID", SqlDbType.Int, 4, "OfficeAccountID"));
			this.sqlUpdate.Parameters["@OfficeAccountID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
			this.sqlUpdate.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
			this.sqlUpdate.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SRPID", SqlDbType.Int, 4, "SRPID"));
			this.sqlUpdate.Parameters["@SRPID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Type", SqlDbType.NVarChar, 2, "Type"));
			this.sqlUpdate.Parameters["@Type"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TransactionDate", SqlDbType.SmallDateTime, 24, "TransactionDate"));
			this.sqlUpdate.Parameters["@TransactionDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostingDate", SqlDbType.SmallDateTime, 24, "PostingDate"));
			this.sqlUpdate.Parameters["@PostingDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money, 19, "Amount"));
			this.sqlUpdate.Parameters["@Amount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Reason", SqlDbType.NVarChar, 4, "Reason"));
			this.sqlUpdate.Parameters["@Reason"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 100, "Description"));
			this.sqlUpdate.Parameters["@Description"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[OfficeAccountDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeAccountID", System.Data.SqlDbType.Int, 4, "OfficeAccountID"));
		    this.sqlDelete.Parameters["@OfficeAccountID"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

        public CLAS.OfficeAccountDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.OfficeAccountDataTable dt = new CLAS.OfficeAccountDataTable();
			Fill(dt);
            return dt;
        }



        public CLAS.OfficeAccountDataTable Load(int OfficeAccountID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[OfficeAccountSelectByOfficeAccountID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@OfficeAccountID"].Value=OfficeAccountID;

            CLAS.OfficeAccountDataTable dt = new CLAS.OfficeAccountDataTable();
			Fill(dt);
            return dt;
		}


        public CLAS.OfficeAccountDataTable LoadByOfficeID(int OfficeID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[OfficeAccountSelectByOfficeID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@OfficeID"].Value=OfficeID;

            CLAS.OfficeAccountDataTable dt = new CLAS.OfficeAccountDataTable();
			Fill(dt);
            return dt;
		}



        public CLAS.OfficeAccountDataTable LoadBySRPID(int SRPID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[OfficeAccountSelectBySRPID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SRPID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@SRPID"].Value=SRPID;

            CLAS.OfficeAccountDataTable dt = new CLAS.OfficeAccountDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
