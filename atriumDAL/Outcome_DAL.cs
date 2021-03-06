using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Outcome table 
	/// in lawmate_dev database
	/// on 2013-11-28
	/// </summary>
	public partial class OutcomeDAL:atDAL.ObjectDAL
	{

    	internal OutcomeDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Outcome", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("OutcomeId", "OutcomeId"),
		  new System.Data.Common.DataColumnMapping("OutcomeEng", "OutcomeEng"),
		  new System.Data.Common.DataColumnMapping("OutcomeFre", "OutcomeFre"),
		  new System.Data.Common.DataColumnMapping("ReadOnly", "ReadOnly"),
		  new System.Data.Common.DataColumnMapping("Obsolete", "Obsolete"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("DecisionType", "DecisionType"),
		  new System.Data.Common.DataColumnMapping("IsFinal", "IsFinal"),
		  new System.Data.Common.DataColumnMapping("ForIssue", "ForIssue"),
		  new System.Data.Common.DataColumnMapping("SortKey", "SortKey"),
		  new System.Data.Common.DataColumnMapping("OutcomeGroupEng", "OutcomeGroupEng"),
		  new System.Data.Common.DataColumnMapping("OutcomeGroupFre", "OutcomeGroupFre"),
	      new System.Data.Common.DataColumnMapping("ReturnCode", "ReturnCode"),
          })});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[OutcomeSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[OutcomeInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@OutcomeId", SqlDbType.Int, 10, "OutcomeId"));
			this.sqlInsert.Parameters["@OutcomeId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OutcomeEng", SqlDbType.NVarChar, 50, "OutcomeEng"));
			this.sqlInsert.Parameters["@OutcomeEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OutcomeFre", SqlDbType.NVarChar, 50, "OutcomeFre"));
			this.sqlInsert.Parameters["@OutcomeFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlInsert.Parameters.Add(new SqlParameter("@DecisionType", SqlDbType.Int, 10, "DecisionType"));
			this.sqlInsert.Parameters["@DecisionType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@IsFinal", SqlDbType.Bit, 1, "IsFinal"));
			this.sqlInsert.Parameters["@IsFinal"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ForIssue", SqlDbType.Bit, 1, "ForIssue"));
			this.sqlInsert.Parameters["@ForIssue"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SortKey", SqlDbType.Int, 10, "SortKey"));
			this.sqlInsert.Parameters["@SortKey"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OutcomeGroupEng", SqlDbType.NVarChar, 50, "OutcomeGroupEng"));
			this.sqlInsert.Parameters["@OutcomeGroupEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OutcomeGroupFre", SqlDbType.NVarChar, 50, "OutcomeGroupFre"));
			this.sqlInsert.Parameters["@OutcomeGroupFre"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20, "ReturnCode"));
            this.sqlInsert.Parameters["@ReturnCode"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[OutcomeUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OutcomeId", SqlDbType.Int, 10, "OutcomeId"));
			this.sqlUpdate.Parameters["@OutcomeId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OutcomeEng", SqlDbType.NVarChar, 50, "OutcomeEng"));
			this.sqlUpdate.Parameters["@OutcomeEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OutcomeFre", SqlDbType.NVarChar, 50, "OutcomeFre"));
			this.sqlUpdate.Parameters["@OutcomeFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DecisionType", SqlDbType.Int, 10, "DecisionType"));
			this.sqlUpdate.Parameters["@DecisionType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@IsFinal", SqlDbType.Bit, 1, "IsFinal"));
			this.sqlUpdate.Parameters["@IsFinal"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ForIssue", SqlDbType.Bit, 1, "ForIssue"));
			this.sqlUpdate.Parameters["@ForIssue"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SortKey", SqlDbType.Int, 10, "SortKey"));
			this.sqlUpdate.Parameters["@SortKey"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OutcomeGroupEng", SqlDbType.NVarChar, 50, "OutcomeGroupEng"));
			this.sqlUpdate.Parameters["@OutcomeGroupEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OutcomeGroupFre", SqlDbType.NVarChar, 50, "OutcomeGroupFre"));
			this.sqlUpdate.Parameters["@OutcomeGroupFre"].SourceVersion=DataRowVersion.Current;

            this.sqlUpdate.Parameters.Add(new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20, "ReturnCode"));
            this.sqlUpdate.Parameters["@ReturnCode"].SourceVersion = DataRowVersion.Current;


            // 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[OutcomeDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OutcomeId", System.Data.SqlDbType.Int, 4, "OutcomeId"));
		    this.sqlDelete.Parameters["@OutcomeId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public CodesDB.OutcomeDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CodesDB.OutcomeDataTable dt=new CodesDB.OutcomeDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CodesDB.OutcomeDataTable Load(int OutcomeId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[OutcomeSelectByOutcomeId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OutcomeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@OutcomeId"].Value=OutcomeId;

            CodesDB.OutcomeDataTable dt=new CodesDB.OutcomeDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
