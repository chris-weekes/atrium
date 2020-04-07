using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on JudgmentAccount table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class JudgmentAccountDAL:atDAL.ObjectDAL
	{

    	internal JudgmentAccountDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "JudgmentAccount", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("JudgmentAccountID", "JudgmentAccountID"),
		  new System.Data.Common.DataColumnMapping("FileAccountID", "FileAccountID"),
		  new System.Data.Common.DataColumnMapping("JudgmentID", "JudgmentID"),
		  new System.Data.Common.DataColumnMapping("PostJudgmentInterestRate", "PostJudgmentInterestRate"),
		  new System.Data.Common.DataColumnMapping("PostJudgmentRateType", "PostJudgmentRateType"),
		  new System.Data.Common.DataColumnMapping("PostJIntRateOnCost", "PostJIntRateOnCost"),
		  new System.Data.Common.DataColumnMapping("PostJRateTypeOnCost", "PostJRateTypeOnCost"),
		  new System.Data.Common.DataColumnMapping("AccruedFromDate", "AccruedFromDate"),
		  new System.Data.Common.DataColumnMapping("PrincipalAmountBeforeJudgment", "PrincipalAmountBeforeJudgment"),
		  new System.Data.Common.DataColumnMapping("PreJudgmentInterestFrom", "PreJudgmentInterestFrom"),
		  new System.Data.Common.DataColumnMapping("PreJudgmentInterestTo", "PreJudgmentInterestTo"),
		  new System.Data.Common.DataColumnMapping("PreJudgmentInterestRate", "PreJudgmentInterestRate"),
		  new System.Data.Common.DataColumnMapping("PreJudgmentRateType", "PreJudgmentRateType"),
		  new System.Data.Common.DataColumnMapping("PreJudgmentInterestAmount", "PreJudgmentInterestAmount"),
		  new System.Data.Common.DataColumnMapping("JudgmentAmount", "JudgmentAmount"),
		  new System.Data.Common.DataColumnMapping("CostIncluded", "CostIncluded"),
		  new System.Data.Common.DataColumnMapping("InterestIncluded", "InterestIncluded"),
		  new System.Data.Common.DataColumnMapping("CostAmount", "CostAmount"),
		  new System.Data.Common.DataColumnMapping("CostDate", "CostDate"),
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

			this.sqlSelectAll.CommandText = "[JudgmentAccountSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[JudgmentAccountInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentAccountID", SqlDbType.Int, 4, "JudgmentAccountID"));
			this.sqlInsert.Parameters["@JudgmentAccountID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileAccountID", SqlDbType.Int, 4, "FileAccountID"));
			this.sqlInsert.Parameters["@FileAccountID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentID", SqlDbType.Int, 4, "JudgmentID"));
			this.sqlInsert.Parameters["@JudgmentID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostJudgmentInterestRate", SqlDbType.Decimal, 50, "PostJudgmentInterestRate"));
			this.sqlInsert.Parameters["@PostJudgmentInterestRate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostJudgmentRateType", SqlDbType.NVarChar, 1, "PostJudgmentRateType"));
			this.sqlInsert.Parameters["@PostJudgmentRateType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostJIntRateOnCost", SqlDbType.Decimal, 50, "PostJIntRateOnCost"));
			this.sqlInsert.Parameters["@PostJIntRateOnCost"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostJRateTypeOnCost", SqlDbType.NVarChar, 1, "PostJRateTypeOnCost"));
			this.sqlInsert.Parameters["@PostJRateTypeOnCost"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AccruedFromDate", SqlDbType.SmallDateTime, 24, "AccruedFromDate"));
			this.sqlInsert.Parameters["@AccruedFromDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PrincipalAmountBeforeJudgment", SqlDbType.Money, 19, "PrincipalAmountBeforeJudgment"));
			this.sqlInsert.Parameters["@PrincipalAmountBeforeJudgment"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PreJudgmentInterestFrom", SqlDbType.SmallDateTime, 24, "PreJudgmentInterestFrom"));
			this.sqlInsert.Parameters["@PreJudgmentInterestFrom"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PreJudgmentInterestTo", SqlDbType.SmallDateTime, 24, "PreJudgmentInterestTo"));
			this.sqlInsert.Parameters["@PreJudgmentInterestTo"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PreJudgmentInterestRate", SqlDbType.Decimal, 50, "PreJudgmentInterestRate"));
			this.sqlInsert.Parameters["@PreJudgmentInterestRate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PreJudgmentRateType", SqlDbType.NVarChar, 1, "PreJudgmentRateType"));
			this.sqlInsert.Parameters["@PreJudgmentRateType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PreJudgmentInterestAmount", SqlDbType.Money, 19, "PreJudgmentInterestAmount"));
			this.sqlInsert.Parameters["@PreJudgmentInterestAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentAmount", SqlDbType.Money, 19, "JudgmentAmount"));
			this.sqlInsert.Parameters["@JudgmentAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CostIncluded", SqlDbType.Bit, 1, "CostIncluded"));
			this.sqlInsert.Parameters["@CostIncluded"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InterestIncluded", SqlDbType.Bit, 1, "InterestIncluded"));
			this.sqlInsert.Parameters["@InterestIncluded"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CostAmount", SqlDbType.Money, 19, "CostAmount"));
			this.sqlInsert.Parameters["@CostAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CostDate", SqlDbType.SmallDateTime, 24, "CostDate"));
			this.sqlInsert.Parameters["@CostDate"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[JudgmentAccountUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentAccountID", SqlDbType.Int, 4, "JudgmentAccountID"));
			this.sqlUpdate.Parameters["@JudgmentAccountID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileAccountID", SqlDbType.Int, 4, "FileAccountID"));
			this.sqlUpdate.Parameters["@FileAccountID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentID", SqlDbType.Int, 4, "JudgmentID"));
			this.sqlUpdate.Parameters["@JudgmentID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostJudgmentInterestRate", SqlDbType.Decimal, 50, "PostJudgmentInterestRate"));
			this.sqlUpdate.Parameters["@PostJudgmentInterestRate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostJudgmentRateType", SqlDbType.NVarChar, 1, "PostJudgmentRateType"));
			this.sqlUpdate.Parameters["@PostJudgmentRateType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostJIntRateOnCost", SqlDbType.Decimal, 50, "PostJIntRateOnCost"));
			this.sqlUpdate.Parameters["@PostJIntRateOnCost"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostJRateTypeOnCost", SqlDbType.NVarChar, 1, "PostJRateTypeOnCost"));
			this.sqlUpdate.Parameters["@PostJRateTypeOnCost"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AccruedFromDate", SqlDbType.SmallDateTime, 24, "AccruedFromDate"));
			this.sqlUpdate.Parameters["@AccruedFromDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PrincipalAmountBeforeJudgment", SqlDbType.Money, 19, "PrincipalAmountBeforeJudgment"));
			this.sqlUpdate.Parameters["@PrincipalAmountBeforeJudgment"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PreJudgmentInterestFrom", SqlDbType.SmallDateTime, 24, "PreJudgmentInterestFrom"));
			this.sqlUpdate.Parameters["@PreJudgmentInterestFrom"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PreJudgmentInterestTo", SqlDbType.SmallDateTime, 24, "PreJudgmentInterestTo"));
			this.sqlUpdate.Parameters["@PreJudgmentInterestTo"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PreJudgmentInterestRate", SqlDbType.Decimal, 50, "PreJudgmentInterestRate"));
			this.sqlUpdate.Parameters["@PreJudgmentInterestRate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PreJudgmentRateType", SqlDbType.NVarChar, 1, "PreJudgmentRateType"));
			this.sqlUpdate.Parameters["@PreJudgmentRateType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PreJudgmentInterestAmount", SqlDbType.Money, 19, "PreJudgmentInterestAmount"));
			this.sqlUpdate.Parameters["@PreJudgmentInterestAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentAmount", SqlDbType.Money, 19, "JudgmentAmount"));
			this.sqlUpdate.Parameters["@JudgmentAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CostIncluded", SqlDbType.Bit, 1, "CostIncluded"));
			this.sqlUpdate.Parameters["@CostIncluded"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InterestIncluded", SqlDbType.Bit, 1, "InterestIncluded"));
			this.sqlUpdate.Parameters["@InterestIncluded"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CostAmount", SqlDbType.Money, 19, "CostAmount"));
			this.sqlUpdate.Parameters["@CostAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CostDate", SqlDbType.SmallDateTime, 24, "CostDate"));
			this.sqlUpdate.Parameters["@CostDate"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[JudgmentAccountDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JudgmentAccountID", System.Data.SqlDbType.Int, 4, "JudgmentAccountID"));
		    this.sqlDelete.Parameters["@JudgmentAccountID"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public CLAS.JudgmentAccountDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.JudgmentAccountDataTable dt=new CLAS.JudgmentAccountDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CLAS.JudgmentAccountDataTable Load(int JudgmentAccountID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[JudgmentAccountSelectByJudgmentAccountID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JudgmentAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@JudgmentAccountID"].Value=JudgmentAccountID;

            CLAS.JudgmentAccountDataTable dt=new CLAS.JudgmentAccountDataTable();
			Fill(dt);
            return dt;
		}


		public CLAS.JudgmentAccountDataTable LoadByFileAccountID(int FileAccountID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[JudgmentAccountSelectByFileAccountID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileAccountID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileAccountID"].Value=FileAccountID;

            CLAS.JudgmentAccountDataTable dt=new CLAS.JudgmentAccountDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.JudgmentAccountDataTable LoadByJudgmentID(int JudgmentID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[JudgmentAccountSelectByJudgmentID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JudgmentID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@JudgmentID"].Value=JudgmentID;

            CLAS.JudgmentAccountDataTable dt=new CLAS.JudgmentAccountDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
