using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on CompOfferDetail table 
	/// in atrium database
	/// on 12/09/2011
	/// </summary>
	public partial class CompOfferDetailDAL:atDAL.ObjectDAL
	{

    	internal CompOfferDetailDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "CompOfferDetail", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("CompOfferId", "CompOfferId"),
		  new System.Data.Common.DataColumnMapping("CompOfferDetailId", "CompOfferDetailId"),
		  new System.Data.Common.DataColumnMapping("CompOfferDate", "CompOfferDate"),
		  new System.Data.Common.DataColumnMapping("InitiatedByDebtor", "InitiatedByDebtor"),
		  new System.Data.Common.DataColumnMapping("CompOfferAmount", "CompOfferAmount"),
		  new System.Data.Common.DataColumnMapping("AcceptedDate", "AcceptedDate"),
		  new System.Data.Common.DataColumnMapping("RefusedDate", "RefusedDate"),
		  new System.Data.Common.DataColumnMapping("DocId", "DocId"),
		  new System.Data.Common.DataColumnMapping("OfficerId", "OfficerId"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
          new System.Data.Common.DataColumnMapping("Terms", "Terms"),
          new System.Data.Common.DataColumnMapping("LumpSum", "LumpSum"),
          new System.Data.Common.DataColumnMapping("CompOfferExpiryDate", "CompOfferExpiryDate"),
          new System.Data.Common.DataColumnMapping("WithdrawalDate", "WithdrawalDate"),

			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[CompOfferDetailSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[CompOfferDetailInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
			this.sqlInsert.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CompOfferId", SqlDbType.Int, 10, "CompOfferId"));
			this.sqlInsert.Parameters["@CompOfferId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CompOfferDetailId", SqlDbType.Int, 10, "CompOfferDetailId"));
			this.sqlInsert.Parameters["@CompOfferDetailId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CompOfferDate", SqlDbType.SmallDateTime, 24, "CompOfferDate"));
			this.sqlInsert.Parameters["@CompOfferDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InitiatedByDebtor", SqlDbType.Bit, 1, "InitiatedByDebtor"));
			this.sqlInsert.Parameters["@InitiatedByDebtor"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CompOfferAmount", SqlDbType.Money, 19, "CompOfferAmount"));
			this.sqlInsert.Parameters["@CompOfferAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AcceptedDate", SqlDbType.SmallDateTime, 24, "AcceptedDate"));
			this.sqlInsert.Parameters["@AcceptedDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RefusedDate", SqlDbType.SmallDateTime, 24, "RefusedDate"));
			this.sqlInsert.Parameters["@RefusedDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DocId", SqlDbType.Int, 10, "DocId"));
			this.sqlInsert.Parameters["@DocId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficerId", SqlDbType.Int, 10, "OfficerId"));
			this.sqlInsert.Parameters["@OfficerId"].SourceVersion=DataRowVersion.Current;
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
            this.sqlInsert.Parameters.Add(new SqlParameter("@Terms", SqlDbType.NVarChar, 2147483647, "Terms"));
            this.sqlInsert.Parameters["@Terms"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LumpSum", SqlDbType.Bit, 1, "LumpSum"));
            this.sqlInsert.Parameters["@LumpSum"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@CompOfferExpiryDate", SqlDbType.SmallDateTime, 24, "CompOfferExpiryDate"));
            this.sqlInsert.Parameters["@CompOfferExpiryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@WithdrawalDate", SqlDbType.SmallDateTime, 24, "WithdrawalDate"));
            this.sqlInsert.Parameters["@WithdrawalDate"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[CompOfferDetailUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
			this.sqlUpdate.Parameters["@FileId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CompOfferId", SqlDbType.Int, 10, "CompOfferId"));
			this.sqlUpdate.Parameters["@CompOfferId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CompOfferDetailId", SqlDbType.Int, 10, "CompOfferDetailId"));
			this.sqlUpdate.Parameters["@CompOfferDetailId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CompOfferDate", SqlDbType.SmallDateTime, 24, "CompOfferDate"));
			this.sqlUpdate.Parameters["@CompOfferDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InitiatedByDebtor", SqlDbType.Bit, 1, "InitiatedByDebtor"));
			this.sqlUpdate.Parameters["@InitiatedByDebtor"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CompOfferAmount", SqlDbType.Money, 19, "CompOfferAmount"));
			this.sqlUpdate.Parameters["@CompOfferAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AcceptedDate", SqlDbType.SmallDateTime, 24, "AcceptedDate"));
			this.sqlUpdate.Parameters["@AcceptedDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@RefusedDate", SqlDbType.SmallDateTime, 24, "RefusedDate"));
			this.sqlUpdate.Parameters["@RefusedDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DocId", SqlDbType.Int, 10, "DocId"));
			this.sqlUpdate.Parameters["@DocId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficerId", SqlDbType.Int, 10, "OfficerId"));
			this.sqlUpdate.Parameters["@OfficerId"].SourceVersion=DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Terms", SqlDbType.NVarChar, 2147483647, "Terms"));
            this.sqlUpdate.Parameters["@Terms"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LumpSum", SqlDbType.Bit, 1, "LumpSum"));
            this.sqlUpdate.Parameters["@LumpSum"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@CompOfferExpiryDate", SqlDbType.SmallDateTime, 24, "CompOfferExpiryDate"));
            this.sqlUpdate.Parameters["@CompOfferExpiryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@WithdrawalDate", SqlDbType.SmallDateTime, 24, "WithdrawalDate"));
            this.sqlUpdate.Parameters["@WithdrawalDate"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[CompOfferDetailDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompOfferDetailId", System.Data.SqlDbType.Int, 4, "CompOfferDetailId"));
		    this.sqlDelete.Parameters["@CompOfferDetailId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public CLAS.CompOfferDetailDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.CompOfferDetailDataTable dt=new CLAS.CompOfferDetailDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CLAS.CompOfferDetailDataTable Load(int CompOfferDetailId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[CompOfferDetailSelectByCompOfferDetailId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompOfferDetailId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@CompOfferDetailId"].Value=CompOfferDetailId;

            CLAS.CompOfferDetailDataTable dt=new CLAS.CompOfferDetailDataTable();
			Fill(dt);
            return dt;
		}


		public CLAS.CompOfferDetailDataTable LoadByCompOfferId(int CompOfferId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[CompOfferDetailSelectByCompOfferId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompOfferId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@CompOfferId"].Value=CompOfferId;

            CLAS.CompOfferDetailDataTable dt=new CLAS.CompOfferDetailDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.CompOfferDetailDataTable LoadByFileId(int FileId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[CompOfferDetailSelectByFileId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileId"].Value=FileId;

            CLAS.CompOfferDetailDataTable dt=new CLAS.CompOfferDetailDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
