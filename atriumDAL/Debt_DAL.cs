using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Debt table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class DebtDAL:atDAL.ObjectDAL
	{

    	internal DebtDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Debt", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("DebtId", "DebtId"),
		  new System.Data.Common.DataColumnMapping("PrincipalAmount", "PrincipalAmount"),
		  new System.Data.Common.DataColumnMapping("InterestRate", "InterestRate"),
		  new System.Data.Common.DataColumnMapping("InterestFromDate", "InterestFromDate"),
		  new System.Data.Common.DataColumnMapping("RateType", "RateType"),
		  new System.Data.Common.DataColumnMapping("InterestAmount", "InterestAmount"),
		  new System.Data.Common.DataColumnMapping("LPCode", "LPCode"),
		  new System.Data.Common.DataColumnMapping("LPDate", "LPDate"),
		  new System.Data.Common.DataColumnMapping("LPExpires", "LPExpires"),
		  new System.Data.Common.DataColumnMapping("CurrentTo", "CurrentTo"),
		  new System.Data.Common.DataColumnMapping("DARSOccurenceDate", "DARSOccurenceDate"),
		  new System.Data.Common.DataColumnMapping("MostRecentPCACode", "MostRecentPCACode"),
		  new System.Data.Common.DataColumnMapping("MSOAOverDARS", "MSOAOverDARS"),
          new System.Data.Common.DataColumnMapping("SequenceBalance", "SequenceBalance"),
          new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),

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
          new System.Data.Common.DataColumnMapping("LPComment", "LPComment"),
          new System.Data.Common.DataColumnMapping("StatBarred", "StatBarred"),

			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[DebtSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[DebtInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@DebtId", SqlDbType.Int, 4, "DebtId"));
			this.sqlInsert.Parameters["@DebtId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PrincipalAmount", SqlDbType.Money, 19, "PrincipalAmount"));
			this.sqlInsert.Parameters["@PrincipalAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InterestRate", SqlDbType.Decimal, 50, "InterestRate"));
            this.sqlInsert.Parameters["@InterestRate"].Precision = 5;
            this.sqlInsert.Parameters["@InterestRate"].Scale = 3;

			this.sqlInsert.Parameters["@InterestRate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InterestFromDate", SqlDbType.SmallDateTime, 24, "InterestFromDate"));
			this.sqlInsert.Parameters["@InterestFromDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RateType", SqlDbType.NVarChar, 1, "RateType"));
			this.sqlInsert.Parameters["@RateType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InterestAmount", SqlDbType.Money, 19, "InterestAmount"));
			this.sqlInsert.Parameters["@InterestAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LPCode", SqlDbType.NVarChar, 4, "LPCode"));
			this.sqlInsert.Parameters["@LPCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LPDate", SqlDbType.SmallDateTime, 24, "LPDate"));
			this.sqlInsert.Parameters["@LPDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LPExpires", SqlDbType.SmallDateTime, 24, "LPExpires"));
			this.sqlInsert.Parameters["@LPExpires"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CurrentTo", SqlDbType.SmallDateTime, 24, "CurrentTo"));
			this.sqlInsert.Parameters["@CurrentTo"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DARSOccurenceDate", SqlDbType.SmallDateTime, 24, "DARSOccurenceDate"));
			this.sqlInsert.Parameters["@DARSOccurenceDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@MostRecentPCACode", SqlDbType.NVarChar, 5, "MostRecentPCACode"));
			this.sqlInsert.Parameters["@MostRecentPCACode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@MSOAOverDARS", SqlDbType.Bit, 1, "MSOAOverDARS"));
			this.sqlInsert.Parameters["@MSOAOverDARS"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SequenceBalance", SqlDbType.NVarChar, 2, "SequenceBalance"));
            this.sqlInsert.Parameters["@SequenceBalance"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@InvoiceNumber", SqlDbType.NVarChar, 8, "InvoiceNumber"));
            this.sqlInsert.Parameters["@InvoiceNumber"].SourceVersion = DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LPComment", SqlDbType.NVarChar, 0, "LPComment"));
            this.sqlInsert.Parameters["@LPComment"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@StatBarred", SqlDbType.Bit, 1, "StatBarred"));
            this.sqlInsert.Parameters["@StatBarred"].SourceVersion = DataRowVersion.Current;


            this.sqlInsert.Parameters.Add(new SqlParameter("@FileAccountId", SqlDbType.Int, 4, "FileAccountId"));
            this.sqlInsert.Parameters["@FileAccountId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
            this.sqlInsert.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AccountTypeId", SqlDbType.Int, 4, "AccountTypeId"));
            this.sqlInsert.Parameters["@AccountTypeId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
            this.sqlInsert.Parameters["@OfficeID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ActiveWithJustice", SqlDbType.Bit, 1, "ActiveWithJustice"));
            this.sqlInsert.Parameters["@ActiveWithJustice"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.NVarChar, 1, "StatusCode"));
            this.sqlInsert.Parameters["@StatusCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ReceivedByJusticeDate", SqlDbType.SmallDateTime, 24, "ReceivedByJusticeDate"));
            this.sqlInsert.Parameters["@ReceivedByJusticeDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ClosureDate", SqlDbType.SmallDateTime, 24, "ClosureDate"));
            this.sqlInsert.Parameters["@ClosureDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ClosureCode", SqlDbType.NVarChar, 4, "ClosureCode"));
            this.sqlInsert.Parameters["@ClosureCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@StatementRequest", SqlDbType.SmallInt, 5, "StatementRequest"));
            this.sqlInsert.Parameters["@StatementRequest"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@MSOARequest", SqlDbType.SmallInt, 5, "MSOARequest"));
            this.sqlInsert.Parameters["@MSOARequest"].SourceVersion = DataRowVersion.Current;

			//this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			//this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[DebtUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DebtId", SqlDbType.Int, 4, "DebtId"));
			this.sqlUpdate.Parameters["@DebtId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PrincipalAmount", SqlDbType.Money, 19, "PrincipalAmount"));
			this.sqlUpdate.Parameters["@PrincipalAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InterestRate", SqlDbType.Decimal, 50, "InterestRate"));
            this.sqlUpdate.Parameters["@InterestRate"].Precision = 5;
            this.sqlUpdate.Parameters["@InterestRate"].Scale =3;
			this.sqlUpdate.Parameters["@InterestRate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InterestFromDate", SqlDbType.SmallDateTime, 24, "InterestFromDate"));
			this.sqlUpdate.Parameters["@InterestFromDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@RateType", SqlDbType.NVarChar, 1, "RateType"));
			this.sqlUpdate.Parameters["@RateType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InterestAmount", SqlDbType.Money, 19, "InterestAmount"));
			this.sqlUpdate.Parameters["@InterestAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LPCode", SqlDbType.NVarChar, 4, "LPCode"));
			this.sqlUpdate.Parameters["@LPCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LPDate", SqlDbType.SmallDateTime, 24, "LPDate"));
			this.sqlUpdate.Parameters["@LPDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LPExpires", SqlDbType.SmallDateTime, 24, "LPExpires"));
			this.sqlUpdate.Parameters["@LPExpires"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CurrentTo", SqlDbType.SmallDateTime, 24, "CurrentTo"));
			this.sqlUpdate.Parameters["@CurrentTo"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DARSOccurenceDate", SqlDbType.SmallDateTime, 24, "DARSOccurenceDate"));
			this.sqlUpdate.Parameters["@DARSOccurenceDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@MostRecentPCACode", SqlDbType.NVarChar, 5, "MostRecentPCACode"));
			this.sqlUpdate.Parameters["@MostRecentPCACode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@MSOAOverDARS", SqlDbType.Bit, 1, "MSOAOverDARS"));
			this.sqlUpdate.Parameters["@MSOAOverDARS"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SequenceBalance", SqlDbType.NVarChar, 2, "SequenceBalance"));
            this.sqlUpdate.Parameters["@SequenceBalance"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@InvoiceNumber", SqlDbType.NVarChar, 8, "InvoiceNumber"));
            this.sqlUpdate.Parameters["@InvoiceNumber"].SourceVersion = DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileAccountId", SqlDbType.Int, 4, "FileAccountId"));
            this.sqlUpdate.Parameters["@FileAccountId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
            this.sqlUpdate.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AccountTypeId", SqlDbType.Int, 4, "AccountTypeId"));
            this.sqlUpdate.Parameters["@AccountTypeId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
            this.sqlUpdate.Parameters["@OfficeID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ActiveWithJustice", SqlDbType.Bit, 1, "ActiveWithJustice"));
            this.sqlUpdate.Parameters["@ActiveWithJustice"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.NVarChar, 1, "StatusCode"));
            this.sqlUpdate.Parameters["@StatusCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ReceivedByJusticeDate", SqlDbType.SmallDateTime, 24, "ReceivedByJusticeDate"));
            this.sqlUpdate.Parameters["@ReceivedByJusticeDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ClosureDate", SqlDbType.SmallDateTime, 24, "ClosureDate"));
            this.sqlUpdate.Parameters["@ClosureDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ClosureCode", SqlDbType.NVarChar, 4, "ClosureCode"));
            this.sqlUpdate.Parameters["@ClosureCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@StatementRequest", SqlDbType.SmallInt, 5, "StatementRequest"));
            this.sqlUpdate.Parameters["@StatementRequest"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@MSOARequest", SqlDbType.SmallInt, 5, "MSOARequest"));
            this.sqlUpdate.Parameters["@MSOARequest"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LPComment", SqlDbType.NVarChar, 0, "LPComment"));
            this.sqlUpdate.Parameters["@LPComment"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@StatBarred", SqlDbType.Bit, 1, "StatBarred"));
            this.sqlUpdate.Parameters["@StatBarred"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[DebtDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DebtId", System.Data.SqlDbType.Int, 4, "DebtId"));
		    this.sqlDelete.Parameters["@DebtId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public CLAS.DebtDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.DebtDataTable dt=new CLAS.DebtDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CLAS.DebtDataTable Load(int DebtId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[DebtSelectByDebtId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DebtId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@DebtId"].Value=DebtId;

            CLAS.DebtDataTable dt=new CLAS.DebtDataTable();
			Fill(dt);
            return dt;
		}


		public CLAS.DebtDataTable LoadByDebtId(int DebtId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[DebtSelectByDebtId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DebtId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@DebtId"].Value=DebtId;

            CLAS.DebtDataTable dt=new CLAS.DebtDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.DebtDataTable LoadByLPCode(string LPCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[DebtSelectByLPCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LPCode", System.Data.SqlDbType.NVarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@LPCode"].Value=LPCode;

            CLAS.DebtDataTable dt=new CLAS.DebtDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}