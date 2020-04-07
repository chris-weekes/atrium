using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Province table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class ProvinceDAL:atDAL.ObjectDAL
	{

    	internal ProvinceDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Province", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ProvinceCode", "ProvinceCode"),
		  new System.Data.Common.DataColumnMapping("ProvinceDescriptionEng", "ProvinceDescriptionEng"),
		  new System.Data.Common.DataColumnMapping("ProvinceDescriptionFre", "ProvinceDescriptionFre"),
		  new System.Data.Common.DataColumnMapping("CountryCode", "CountryCode"),
		  new System.Data.Common.DataColumnMapping("TaxName", "TaxName"),
		  new System.Data.Common.DataColumnMapping("TaxRate", "TaxRate"),
		  new System.Data.Common.DataColumnMapping("TypeOfWritCode", "TypeOfWritCode"),
		  new System.Data.Common.DataColumnMapping("NameofSmallClaimsCourt", "NameofSmallClaimsCourt"),
		  new System.Data.Common.DataColumnMapping("NameofSuperiorCourt", "NameofSuperiorCourt"),
		  new System.Data.Common.DataColumnMapping("CosttoIssueSofC", "CosttoIssueSofC"),
		  new System.Data.Common.DataColumnMapping("SimpleContractDebtLP", "SimpleContractDebtLP"),
		  new System.Data.Common.DataColumnMapping("JudgmentLP", "JudgmentLP"),
		  new System.Data.Common.DataColumnMapping("WritofExecutionLP", "WritofExecutionLP"),
		  new System.Data.Common.DataColumnMapping("PostJdgmntInterestRateType", "PostJdgmntInterestRateType"),
		  new System.Data.Common.DataColumnMapping("RateonCostsDiffers", "RateonCostsDiffers"),
		  new System.Data.Common.DataColumnMapping("InterestRateonCost", "InterestRateonCost"),
		  new System.Data.Common.DataColumnMapping("PostJdgmntInterestRate", "PostJdgmntInterestRate"),
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

			this.sqlSelectAll.CommandText = "[ProvinceSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ProvinceInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvinceCode", SqlDbType.NVarChar, 50, "ProvinceCode"));
			this.sqlInsert.Parameters["@ProvinceCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvinceDescriptionEng", SqlDbType.NVarChar, 50, "ProvinceDescriptionEng"));
			this.sqlInsert.Parameters["@ProvinceDescriptionEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvinceDescriptionFre", SqlDbType.NVarChar, 50, "ProvinceDescriptionFre"));
			this.sqlInsert.Parameters["@ProvinceDescriptionFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CountryCode", SqlDbType.NVarChar, 50, "CountryCode"));
			this.sqlInsert.Parameters["@CountryCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TaxName", SqlDbType.NVarChar, 10, "TaxName"));
			this.sqlInsert.Parameters["@TaxName"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TaxRate", SqlDbType.Decimal, 50, "TaxRate"));
			this.sqlInsert.Parameters["@TaxRate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TypeOfWritCode", SqlDbType.NVarChar, 4, "TypeOfWritCode"));
			this.sqlInsert.Parameters["@TypeOfWritCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@NameofSmallClaimsCourt", SqlDbType.NVarChar, 50, "NameofSmallClaimsCourt"));
			this.sqlInsert.Parameters["@NameofSmallClaimsCourt"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@NameofSuperiorCourt", SqlDbType.NVarChar, 50, "NameofSuperiorCourt"));
			this.sqlInsert.Parameters["@NameofSuperiorCourt"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CosttoIssueSofC", SqlDbType.Money, 19, "CosttoIssueSofC"));
			this.sqlInsert.Parameters["@CosttoIssueSofC"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SimpleContractDebtLP", SqlDbType.Int, 4, "SimpleContractDebtLP"));
			this.sqlInsert.Parameters["@SimpleContractDebtLP"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentLP", SqlDbType.Int, 4, "JudgmentLP"));
			this.sqlInsert.Parameters["@JudgmentLP"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@WritofExecutionLP", SqlDbType.Int, 4, "WritofExecutionLP"));
			this.sqlInsert.Parameters["@WritofExecutionLP"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostJdgmntInterestRateType", SqlDbType.NVarChar, 1, "PostJdgmntInterestRateType"));
			this.sqlInsert.Parameters["@PostJdgmntInterestRateType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RateonCostsDiffers", SqlDbType.Bit, 1, "RateonCostsDiffers"));
			this.sqlInsert.Parameters["@RateonCostsDiffers"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InterestRateonCost", SqlDbType.Decimal, 50, "InterestRateonCost"));
			this.sqlInsert.Parameters["@InterestRateonCost"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostJdgmntInterestRate", SqlDbType.Decimal, 50, "PostJdgmntInterestRate"));
			this.sqlInsert.Parameters["@PostJdgmntInterestRate"].SourceVersion=DataRowVersion.Current;
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
			//this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			//this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[ProvinceUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvinceCode", SqlDbType.NVarChar, 50, "ProvinceCode"));
			this.sqlUpdate.Parameters["@ProvinceCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvinceDescriptionEng", SqlDbType.NVarChar, 50, "ProvinceDescriptionEng"));
			this.sqlUpdate.Parameters["@ProvinceDescriptionEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvinceDescriptionFre", SqlDbType.NVarChar, 50, "ProvinceDescriptionFre"));
			this.sqlUpdate.Parameters["@ProvinceDescriptionFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CountryCode", SqlDbType.NVarChar, 50, "CountryCode"));
			this.sqlUpdate.Parameters["@CountryCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TaxName", SqlDbType.NVarChar, 10, "TaxName"));
			this.sqlUpdate.Parameters["@TaxName"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TaxRate", SqlDbType.Decimal, 50, "TaxRate"));
			this.sqlUpdate.Parameters["@TaxRate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TypeOfWritCode", SqlDbType.NVarChar, 4, "TypeOfWritCode"));
			this.sqlUpdate.Parameters["@TypeOfWritCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@NameofSmallClaimsCourt", SqlDbType.NVarChar, 50, "NameofSmallClaimsCourt"));
			this.sqlUpdate.Parameters["@NameofSmallClaimsCourt"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@NameofSuperiorCourt", SqlDbType.NVarChar, 50, "NameofSuperiorCourt"));
			this.sqlUpdate.Parameters["@NameofSuperiorCourt"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CosttoIssueSofC", SqlDbType.Money, 19, "CosttoIssueSofC"));
			this.sqlUpdate.Parameters["@CosttoIssueSofC"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SimpleContractDebtLP", SqlDbType.Int, 4, "SimpleContractDebtLP"));
			this.sqlUpdate.Parameters["@SimpleContractDebtLP"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentLP", SqlDbType.Int, 4, "JudgmentLP"));
			this.sqlUpdate.Parameters["@JudgmentLP"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@WritofExecutionLP", SqlDbType.Int, 4, "WritofExecutionLP"));
			this.sqlUpdate.Parameters["@WritofExecutionLP"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostJdgmntInterestRateType", SqlDbType.NVarChar, 1, "PostJdgmntInterestRateType"));
			this.sqlUpdate.Parameters["@PostJdgmntInterestRateType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@RateonCostsDiffers", SqlDbType.Bit, 1, "RateonCostsDiffers"));
			this.sqlUpdate.Parameters["@RateonCostsDiffers"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InterestRateonCost", SqlDbType.Decimal, 50, "InterestRateonCost"));
			this.sqlUpdate.Parameters["@InterestRateonCost"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostJdgmntInterestRate", SqlDbType.Decimal, 50, "PostJdgmntInterestRate"));
			this.sqlUpdate.Parameters["@PostJdgmntInterestRate"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[ProvinceDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvinceCode", System.Data.SqlDbType.NVarChar, 50, "ProvinceCode"));
		    this.sqlDelete.Parameters["@ProvinceCode"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public appDB.ProvinceDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            appDB.ProvinceDataTable dt = new appDB.ProvinceDataTable();
			Fill(dt);
            return dt;
        }



        public appDB.ProvinceDataTable Load(string ProvinceCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ProvinceSelectByProvinceCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvinceCode", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ProvinceCode"].Value=ProvinceCode;

            appDB.ProvinceDataTable dt = new appDB.ProvinceDataTable();
			Fill(dt);
            return dt;
		}


        public appDB.ProvinceDataTable LoadByCountryCode(string CountryCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ProvinceSelectByCountryCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CountryCode", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@CountryCode"].Value=CountryCode;

            appDB.ProvinceDataTable dt = new appDB.ProvinceDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}