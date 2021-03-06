using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on LegalProcess table 
	/// in lawmate database
	/// on 3/12/2007
	/// </summary>
	public partial class LegalProcessDAL:atDAL.ObjectDAL
	{

    	internal LegalProcessDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "LegalProcess", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("LegalProcessID", "LegalProcessID"),
		  new System.Data.Common.DataColumnMapping("FileID", "FileID"),
		  new System.Data.Common.DataColumnMapping("CourtID", "CourtID"),
		  new System.Data.Common.DataColumnMapping("ApplicantIsAppelant", "ApplicantIsAppelant"),
		  new System.Data.Common.DataColumnMapping("FiledDate", "FiledDate"),
		  new System.Data.Common.DataColumnMapping("HearingDate", "HearingDate"),
		  new System.Data.Common.DataColumnMapping("LeadLawyerID", "LeadLawyerID"),
		  new System.Data.Common.DataColumnMapping("DecisionDate", "DecisionDate"),
		  new System.Data.Common.DataColumnMapping("DecisionForCrown", "DecisionForCrown"),
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

			this.sqlSelectAll.CommandText = "[LegalProcessSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[LegalProcessInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@LegalProcessID", SqlDbType.Int, 10, "LegalProcessID"));
			this.sqlInsert.Parameters["@LegalProcessID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FileID", SqlDbType.Int, 10, "FileID"));
			this.sqlInsert.Parameters["@FileID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CourtID", SqlDbType.Int, 10, "CourtID"));
			this.sqlInsert.Parameters["@CourtID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ApplicantIsAppelant", SqlDbType.Bit, 1, "ApplicantIsAppelant"));
			this.sqlInsert.Parameters["@ApplicantIsAppelant"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FiledDate", SqlDbType.SmallDateTime, 24, "FiledDate"));
			this.sqlInsert.Parameters["@FiledDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HearingDate", SqlDbType.SmallDateTime, 24, "HearingDate"));
			this.sqlInsert.Parameters["@HearingDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
			this.sqlInsert.Parameters["@LeadLawyerID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DecisionDate", SqlDbType.SmallDateTime, 24, "DecisionDate"));
			this.sqlInsert.Parameters["@DecisionDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DecisionForCrown", SqlDbType.Bit, 1, "DecisionForCrown"));
			this.sqlInsert.Parameters["@DecisionForCrown"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.CommandText = "[LegalProcessUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LegalProcessID", SqlDbType.Int, 10, "LegalProcessID"));
			this.sqlUpdate.Parameters["@LegalProcessID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FileID", SqlDbType.Int, 10, "FileID"));
			this.sqlUpdate.Parameters["@FileID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CourtID", SqlDbType.Int, 10, "CourtID"));
			this.sqlUpdate.Parameters["@CourtID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ApplicantIsAppelant", SqlDbType.Bit, 1, "ApplicantIsAppelant"));
			this.sqlUpdate.Parameters["@ApplicantIsAppelant"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FiledDate", SqlDbType.SmallDateTime, 24, "FiledDate"));
			this.sqlUpdate.Parameters["@FiledDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingDate", SqlDbType.SmallDateTime, 24, "HearingDate"));
			this.sqlUpdate.Parameters["@HearingDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
			this.sqlUpdate.Parameters["@LeadLawyerID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DecisionDate", SqlDbType.SmallDateTime, 24, "DecisionDate"));
			this.sqlUpdate.Parameters["@DecisionDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DecisionForCrown", SqlDbType.Bit, 1, "DecisionForCrown"));
			this.sqlUpdate.Parameters["@DecisionForCrown"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlUpdate.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlUpdate.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlUpdate.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlUpdate.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
            ////this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            //this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Original;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[LegalProcessDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LegalProcessID", System.Data.SqlDbType.Int, 4, "LegalProcessID"));
		    this.sqlDelete.Parameters["@LegalProcessID"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public CLAS.LegalProcessDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CLAS.LegalProcessDataTable dt=new CLAS.LegalProcessDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CLAS.LegalProcessDataTable Load(int LegalProcessID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[LegalProcessSelectByLegalProcessID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LegalProcessID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@LegalProcessID"].Value=LegalProcessID;

            CLAS.LegalProcessDataTable dt=new CLAS.LegalProcessDataTable();
			Fill(dt);
            return dt;
		}


		public CLAS.LegalProcessDataTable LoadByLeadLawyerID(int LeadLawyerID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[LegalProcessSelectByLeadLawyerID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LeadLawyerID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@LeadLawyerID"].Value=LeadLawyerID;

            CLAS.LegalProcessDataTable dt=new CLAS.LegalProcessDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.LegalProcessDataTable LoadByFileID(int FileID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[LegalProcessSelectByFileID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@FileID"].Value=FileID;

            CLAS.LegalProcessDataTable dt=new CLAS.LegalProcessDataTable();
			Fill(dt);
            return dt;
		}



		public CLAS.LegalProcessDataTable LoadByCourtID(int CourtID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[LegalProcessSelectByCourtID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CourtID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@CourtID"].Value=CourtID;

            CLAS.LegalProcessDataTable dt=new CLAS.LegalProcessDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
