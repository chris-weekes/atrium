using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Bankruptcy table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class BankruptcyDAL:atDAL.ObjectDAL
	{

    	internal BankruptcyDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Bankruptcy", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("BankruptcyID", "BankruptcyID"),
		  new System.Data.Common.DataColumnMapping("FileID", "FileID"),
		  new System.Data.Common.DataColumnMapping("OfficeID", "OfficeID"),
		  new System.Data.Common.DataColumnMapping("PreviousBankruptcyDate", "PreviousBankruptcyDate"),
		  new System.Data.Common.DataColumnMapping("StayOfProceeding", "StayOfProceeding"),
		  new System.Data.Common.DataColumnMapping("BankruptcyDate", "BankruptcyDate"),
		  new System.Data.Common.DataColumnMapping("ProvenClaimAmount", "ProvenClaimAmount"),
		  new System.Data.Common.DataColumnMapping("DateofOrder", "DateofOrder"),
		  new System.Data.Common.DataColumnMapping("CSLEligibleForDischargeDate", "CSLEligibleForDischargeDate"),
		  new System.Data.Common.DataColumnMapping("JudgmentObtained", "JudgmentObtained"),
		  new System.Data.Common.DataColumnMapping("BankruptcyOrderType", "BankruptcyOrderType"),
		  new System.Data.Common.DataColumnMapping("ConditionalOrderAmount", "ConditionalOrderAmount"),
		  new System.Data.Common.DataColumnMapping("JudgmentinFavourofCrown", "JudgmentinFavourofCrown"),
		  new System.Data.Common.DataColumnMapping("JudgmentAssignedtoCrownDate", "JudgmentAssignedtoCrownDate"),
		  new System.Data.Common.DataColumnMapping("DateofTrusteeDischarge", "DateofTrusteeDischarge"),
		  new System.Data.Common.DataColumnMapping("DebtorDischargeNonCSLDebtDate", "DebtorDischargeNonCSLDebtDate"),
		  new System.Data.Common.DataColumnMapping("CSLNonDischargeable", "CSLNonDischargeable"),
		  new System.Data.Common.DataColumnMapping("ConditionalOrderFufilled", "ConditionalOrderFufilled"),
		  new System.Data.Common.DataColumnMapping("SigningJudgmentATerm", "SigningJudgmentATerm"),
		  new System.Data.Common.DataColumnMapping("MisrepEligibleforDischarge", "MisrepEligibleforDischarge"),
		  new System.Data.Common.DataColumnMapping("ProofOfClaimFiledDate", "ProofOfClaimFiledDate"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
          new System.Data.Common.DataColumnMapping("InsolvencyPeriod", "InsolvencyPeriod"),
            })});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[BankruptcySelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[BankruptcyInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@BankruptcyID", SqlDbType.Int, 4, "BankruptcyID"));
			this.sqlInsert.Parameters["@BankruptcyID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileID", SqlDbType.Int, 4, "FileID"));
			this.sqlInsert.Parameters["@FileID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
			this.sqlInsert.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PreviousBankruptcyDate", SqlDbType.SmallDateTime, 24, "PreviousBankruptcyDate"));
			this.sqlInsert.Parameters["@PreviousBankruptcyDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@StayOfProceeding", SqlDbType.Bit, 1, "StayOfProceeding"));
			this.sqlInsert.Parameters["@StayOfProceeding"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@BankruptcyDate", SqlDbType.SmallDateTime, 24, "BankruptcyDate"));
			this.sqlInsert.Parameters["@BankruptcyDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvenClaimAmount", SqlDbType.Money, 19, "ProvenClaimAmount"));
			this.sqlInsert.Parameters["@ProvenClaimAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DateofOrder", SqlDbType.SmallDateTime, 24, "DateofOrder"));
			this.sqlInsert.Parameters["@DateofOrder"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CSLEligibleForDischargeDate", SqlDbType.SmallDateTime, 24, "CSLEligibleForDischargeDate"));
			this.sqlInsert.Parameters["@CSLEligibleForDischargeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentObtained", SqlDbType.Bit, 1, "JudgmentObtained"));
			this.sqlInsert.Parameters["@JudgmentObtained"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@BankruptcyOrderType", SqlDbType.NVarChar, 2, "BankruptcyOrderType"));
			this.sqlInsert.Parameters["@BankruptcyOrderType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ConditionalOrderAmount", SqlDbType.Money, 19, "ConditionalOrderAmount"));
			this.sqlInsert.Parameters["@ConditionalOrderAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentinFavourofCrown", SqlDbType.Bit, 1, "JudgmentinFavourofCrown"));
			this.sqlInsert.Parameters["@JudgmentinFavourofCrown"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JudgmentAssignedtoCrownDate", SqlDbType.SmallDateTime, 24, "JudgmentAssignedtoCrownDate"));
			this.sqlInsert.Parameters["@JudgmentAssignedtoCrownDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DateofTrusteeDischarge", SqlDbType.SmallDateTime, 24, "DateofTrusteeDischarge"));
			this.sqlInsert.Parameters["@DateofTrusteeDischarge"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DebtorDischargeNonCSLDebtDate", SqlDbType.SmallDateTime, 24, "DebtorDischargeNonCSLDebtDate"));
			this.sqlInsert.Parameters["@DebtorDischargeNonCSLDebtDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CSLNonDischargeable", SqlDbType.Bit, 1, "CSLNonDischargeable"));
			this.sqlInsert.Parameters["@CSLNonDischargeable"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ConditionalOrderFufilled", SqlDbType.Bit, 1, "ConditionalOrderFufilled"));
			this.sqlInsert.Parameters["@ConditionalOrderFufilled"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SigningJudgmentATerm", SqlDbType.Bit, 1, "SigningJudgmentATerm"));
			this.sqlInsert.Parameters["@SigningJudgmentATerm"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@MisrepEligibleforDischarge", SqlDbType.Bit, 1, "MisrepEligibleforDischarge"));
			this.sqlInsert.Parameters["@MisrepEligibleforDischarge"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProofOfClaimFiledDate", SqlDbType.SmallDateTime, 24, "ProofOfClaimFiledDate"));
			this.sqlInsert.Parameters["@ProofOfClaimFiledDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@InsolvencyPeriod", SqlDbType.Int, 4, "InsolvencyPeriod"));
            this.sqlInsert.Parameters["@InsolvencyPeriod"].SourceVersion = DataRowVersion.Current;
            //this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            //this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

            // 
            // sqlUpdate
            // 
            this.sqlUpdate.CommandText = "[BankruptcyUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@BankruptcyID", SqlDbType.Int, 4, "BankruptcyID"));
			this.sqlUpdate.Parameters["@BankruptcyID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileID", SqlDbType.Int, 4, "FileID"));
			this.sqlUpdate.Parameters["@FileID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 4, "OfficeID"));
			this.sqlUpdate.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PreviousBankruptcyDate", SqlDbType.SmallDateTime, 24, "PreviousBankruptcyDate"));
			this.sqlUpdate.Parameters["@PreviousBankruptcyDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@StayOfProceeding", SqlDbType.Bit, 1, "StayOfProceeding"));
			this.sqlUpdate.Parameters["@StayOfProceeding"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@BankruptcyDate", SqlDbType.SmallDateTime, 24, "BankruptcyDate"));
			this.sqlUpdate.Parameters["@BankruptcyDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvenClaimAmount", SqlDbType.Money, 19, "ProvenClaimAmount"));
			this.sqlUpdate.Parameters["@ProvenClaimAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DateofOrder", SqlDbType.SmallDateTime, 24, "DateofOrder"));
			this.sqlUpdate.Parameters["@DateofOrder"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CSLEligibleForDischargeDate", SqlDbType.SmallDateTime, 24, "CSLEligibleForDischargeDate"));
			this.sqlUpdate.Parameters["@CSLEligibleForDischargeDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentObtained", SqlDbType.Bit, 1, "JudgmentObtained"));
			this.sqlUpdate.Parameters["@JudgmentObtained"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@BankruptcyOrderType", SqlDbType.NVarChar, 2, "BankruptcyOrderType"));
			this.sqlUpdate.Parameters["@BankruptcyOrderType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ConditionalOrderAmount", SqlDbType.Money, 19, "ConditionalOrderAmount"));
			this.sqlUpdate.Parameters["@ConditionalOrderAmount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentinFavourofCrown", SqlDbType.Bit, 1, "JudgmentinFavourofCrown"));
			this.sqlUpdate.Parameters["@JudgmentinFavourofCrown"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JudgmentAssignedtoCrownDate", SqlDbType.SmallDateTime, 24, "JudgmentAssignedtoCrownDate"));
			this.sqlUpdate.Parameters["@JudgmentAssignedtoCrownDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DateofTrusteeDischarge", SqlDbType.SmallDateTime, 24, "DateofTrusteeDischarge"));
			this.sqlUpdate.Parameters["@DateofTrusteeDischarge"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DebtorDischargeNonCSLDebtDate", SqlDbType.SmallDateTime, 24, "DebtorDischargeNonCSLDebtDate"));
			this.sqlUpdate.Parameters["@DebtorDischargeNonCSLDebtDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CSLNonDischargeable", SqlDbType.Bit, 1, "CSLNonDischargeable"));
			this.sqlUpdate.Parameters["@CSLNonDischargeable"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ConditionalOrderFufilled", SqlDbType.Bit, 1, "ConditionalOrderFufilled"));
			this.sqlUpdate.Parameters["@ConditionalOrderFufilled"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SigningJudgmentATerm", SqlDbType.Bit, 1, "SigningJudgmentATerm"));
			this.sqlUpdate.Parameters["@SigningJudgmentATerm"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@MisrepEligibleforDischarge", SqlDbType.Bit, 1, "MisrepEligibleforDischarge"));
			this.sqlUpdate.Parameters["@MisrepEligibleforDischarge"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProofOfClaimFiledDate", SqlDbType.SmallDateTime, 24, "ProofOfClaimFiledDate"));
			this.sqlUpdate.Parameters["@ProofOfClaimFiledDate"].SourceVersion=DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@InsolvencyPeriod", SqlDbType.Int, 4, "InsolvencyPeriod"));
            this.sqlUpdate.Parameters["@InsolvencyPeriod"].SourceVersion = DataRowVersion.Current;
            // 
            // sqlDelete
            // 
            this.sqlDelete.CommandText = "[BankruptcyDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankruptcyID", System.Data.SqlDbType.Int, 4, "BankruptcyID"));
		    this.sqlDelete.Parameters["@BankruptcyID"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public CLAS.BankruptcyDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.BankruptcyDataTable dt=new CLAS.BankruptcyDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CLAS.BankruptcyDataTable Load(int BankruptcyID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[BankruptcySelectByBankruptcyID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@BankruptcyID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@BankruptcyID"].Value=BankruptcyID;

            CLAS.BankruptcyDataTable dt=new CLAS.BankruptcyDataTable();
			Fill(dt);
            return dt;
		}


		public CLAS.BankruptcyDataTable LoadByFileID(int FileID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[BankruptcySelectByFileID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileID"].Value=FileID;

            CLAS.BankruptcyDataTable dt=new CLAS.BankruptcyDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.BankruptcyDataTable LoadByOfficeID(int OfficeID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[BankruptcySelectByOfficeID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@OfficeID"].Value=OfficeID;

            CLAS.BankruptcyDataTable dt=new CLAS.BankruptcyDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}