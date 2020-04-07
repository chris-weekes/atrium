using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ADMSEDecision table 
	/// in atrium database
	/// on 11/26/2012
	/// </summary>
	public partial class ADMSEDecisionDAL:atDAL.ObjectDAL
	{

    	internal ADMSEDecisionDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
        {


            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ADMSEDecision", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("SSTFileNumber", "SSTFileNumber"),
		  new System.Data.Common.DataColumnMapping("AppealSeqId", "AppealSeqId"),
		  new System.Data.Common.DataColumnMapping("DecisionDate", "DecisionDate"),
		  new System.Data.Common.DataColumnMapping("DecisionDocument", "DecisionDocument"),
		  new System.Data.Common.DataColumnMapping("AtriumUser", "AtriumUser"),
		  new System.Data.Common.DataColumnMapping("TransferStatus", "TransferStatus"),
		  new System.Data.Common.DataColumnMapping("ActionStatus", "ActionStatus"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("Id", "Id"),
		  new System.Data.Common.DataColumnMapping("WithdrawalRecDate", "WithdrawalRecDate"),
		  new System.Data.Common.DataColumnMapping("LeaveToAppealDecType", "LeaveToAppealDecType"),
		  new System.Data.Common.DataColumnMapping("LeaveToAppealDecDate", "LeaveToAppealDecDate"),
		  new System.Data.Common.DataColumnMapping("HearingDate", "HearingDate"),
		  new System.Data.Common.DataColumnMapping("HearingMethod", "HearingMethod"),
			})});

            // 
            // sqlSelect
            // 
            this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelect.Connection = myDALManager.SqlCon;

            this.sqlSelectAll.CommandText = "[ADMSEDecisionSelect]";
            this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectAll.Connection = myDALManager.SqlCon;
            this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            // 
            // sqlInsert
            // 
            this.sqlInsert.CommandText = "[ADMSEDecisionInsert]";
            this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsert.Connection = myDALManager.SqlCon;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlInsert.Parameters.Add(new SqlParameter("@SSTFileNumber", SqlDbType.NVarChar, 12, "SSTFileNumber"));
            this.sqlInsert.Parameters["@SSTFileNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AppealSeqId", SqlDbType.Int, 10, "AppealSeqId"));
            this.sqlInsert.Parameters["@AppealSeqId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DecisionDate", SqlDbType.DateTime, 24, "DecisionDate"));
            this.sqlInsert.Parameters["@DecisionDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DecisionDocument", SqlDbType.VarBinary,  0, "DecisionDocument"));
            this.sqlInsert.Parameters["@DecisionDocument"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AtriumUser", SqlDbType.NVarChar, 80, "AtriumUser"));
            this.sqlInsert.Parameters["@AtriumUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@TransferStatus", SqlDbType.NVarChar, 30, "TransferStatus"));
            this.sqlInsert.Parameters["@TransferStatus"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ActionStatus", SqlDbType.NVarChar, 100, "ActionStatus"));
            this.sqlInsert.Parameters["@ActionStatus"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
            this.sqlInsert.Parameters["@entryUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
            this.sqlInsert.Parameters["@entryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
            this.sqlInsert.Parameters["@updateUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
            this.sqlInsert.Parameters["@updateDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            this.sqlInsert.Parameters["@ts"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 10, "Id"));
            this.sqlInsert.Parameters["@Id"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@WithdrawalRecDate", SqlDbType.DateTime, 24, "WithdrawalRecDate"));
            this.sqlInsert.Parameters["@WithdrawalRecDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LeaveToAppealDecType", SqlDbType.NVarChar, 2, "LeaveToAppealDecType"));
            this.sqlInsert.Parameters["@LeaveToAppealDecType"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LeaveToAppealDecDate", SqlDbType.DateTime, 24, "LeaveToAppealDecDate"));
            this.sqlInsert.Parameters["@LeaveToAppealDecDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@HearingDate", SqlDbType.DateTime, 24, "HearingDate"));
            this.sqlInsert.Parameters["@HearingDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@HearingMethod", SqlDbType.NVarChar, 2, "HearingMethod"));
            this.sqlInsert.Parameters["@HearingMethod"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlUpdate
            // 
            this.sqlUpdate.CommandText = "[ADMSEDecisionUpdate]";
            this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdate.Connection = myDALManager.SqlCon;
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlUpdate.Parameters.Add(new SqlParameter("@SSTFileNumber", SqlDbType.NVarChar, 12, "SSTFileNumber"));
            this.sqlUpdate.Parameters["@SSTFileNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AppealSeqId", SqlDbType.Int, 10, "AppealSeqId"));
            this.sqlUpdate.Parameters["@AppealSeqId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DecisionDate", SqlDbType.DateTime, 24, "DecisionDate"));
            this.sqlUpdate.Parameters["@DecisionDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DecisionDocument", SqlDbType.VarBinary, 0, "DecisionDocument"));
            this.sqlUpdate.Parameters["@DecisionDocument"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AtriumUser", SqlDbType.NVarChar, 80, "AtriumUser"));
            this.sqlUpdate.Parameters["@AtriumUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@TransferStatus", SqlDbType.NVarChar, 30, "TransferStatus"));
            this.sqlUpdate.Parameters["@TransferStatus"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ActionStatus", SqlDbType.NVarChar, 100, "ActionStatus"));
            this.sqlUpdate.Parameters["@ActionStatus"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
            this.sqlUpdate.Parameters["@entryUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
            this.sqlUpdate.Parameters["@entryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
            this.sqlUpdate.Parameters["@updateUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
            this.sqlUpdate.Parameters["@updateDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            this.sqlUpdate.Parameters["@ts"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 10, "Id"));
            this.sqlUpdate.Parameters["@Id"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@WithdrawalRecDate", SqlDbType.DateTime, 24, "WithdrawalRecDate"));
            this.sqlUpdate.Parameters["@WithdrawalRecDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LeaveToAppealDecType", SqlDbType.NVarChar, 2, "LeaveToAppealDecType"));
            this.sqlUpdate.Parameters["@LeaveToAppealDecType"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LeaveToAppealDecDate", SqlDbType.DateTime, 24, "LeaveToAppealDecDate"));
            this.sqlUpdate.Parameters["@LeaveToAppealDecDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingDate", SqlDbType.DateTime, 24, "HearingDate"));
            this.sqlUpdate.Parameters["@HearingDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethod", SqlDbType.NVarChar, 2, "HearingMethod"));
            this.sqlUpdate.Parameters["@HearingMethod"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlDelete
            // 
            this.sqlDelete.CommandText = "[ADMSEDecisionDelete]";
            this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDelete.Connection = myDALManager.SqlCon;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, "Id"));
            this.sqlDelete.Parameters["@Id"].SourceVersion = DataRowVersion.Original;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
            this.sqlDelete.Parameters["@ts"].SourceVersion = DataRowVersion.Original;



        }


		 public SST.ADMSEDecisionDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            SST.ADMSEDecisionDataTable dt=new SST.ADMSEDecisionDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public SST.ADMSEDecisionDataTable Load(int Id)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ADMSEDecisionSelectById]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@Id"].Value=Id;

            SST.ADMSEDecisionDataTable dt=new SST.ADMSEDecisionDataTable();
			Fill(dt);
            return dt;
		}

        public SST.ADMSEDecisionDataTable LoadByFileNumber(string SSTFileNumber)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ADMSEDecisionSelectBySSTFileNumber]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SSTFileNumber", System.Data.SqlDbType.NVarChar, 12));

            this.sqlSelect.Parameters["@SSTFileNumber"].Value = SSTFileNumber;

            SST.ADMSEDecisionDataTable dt = new SST.ADMSEDecisionDataTable();
            Fill(dt);
            return dt;
        }

	}
	

}