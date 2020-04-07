using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Provision table 
	/// in atrium database
	/// on 12/06/2012
	/// </summary>
	public partial class ProvisionDAL:atDAL.ObjectDAL
	{

    	internal ProvisionDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Provision", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ProvisionId", "ProvisionId"),
		  new System.Data.Common.DataColumnMapping("LegislationId", "LegislationId"),
		  new System.Data.Common.DataColumnMapping("ProvisionNameEng", "ProvisionNameEng"),
		  new System.Data.Common.DataColumnMapping("ProvisionNameFre", "ProvisionNameFre"),
		  new System.Data.Common.DataColumnMapping("ProvisionTextEng", "ProvisionTextEng"),
		  new System.Data.Common.DataColumnMapping("ProvisionTextFre", "ProvisionTextFre"),
		  new System.Data.Common.DataColumnMapping("AnalysisTextEng", "AnalysisTextEng"),
		  new System.Data.Common.DataColumnMapping("AnalysisTextFre", "AnalysisTextFre"),
		  new System.Data.Common.DataColumnMapping("URLEng", "URLEng"),
		  new System.Data.Common.DataColumnMapping("URLFre", "URLFre"),
		  new System.Data.Common.DataColumnMapping("EffectiveDate", "EffectiveDate"),
		  new System.Data.Common.DataColumnMapping("Seq", "Seq"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
          new System.Data.Common.DataColumnMapping("ProvisionNumber", "ProvisionNumber"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[ProvisionSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ProvisionInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvisionId", SqlDbType.Int, 10, "ProvisionId"));
			this.sqlInsert.Parameters["@ProvisionId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LegislationId", SqlDbType.Int, 10, "LegislationId"));
			this.sqlInsert.Parameters["@LegislationId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvisionNameEng", SqlDbType.NVarChar, 255, "ProvisionNameEng"));
			this.sqlInsert.Parameters["@ProvisionNameEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvisionNameFre", SqlDbType.NVarChar, 255, "ProvisionNameFre"));
			this.sqlInsert.Parameters["@ProvisionNameFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvisionTextEng", SqlDbType.NVarChar, -1, "ProvisionTextEng"));
			this.sqlInsert.Parameters["@ProvisionTextEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvisionTextFre", SqlDbType.NVarChar, -1, "ProvisionTextFre"));
			this.sqlInsert.Parameters["@ProvisionTextFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AnalysisTextEng", SqlDbType.NVarChar, -1, "AnalysisTextEng"));
			this.sqlInsert.Parameters["@AnalysisTextEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AnalysisTextFre", SqlDbType.NVarChar, -1, "AnalysisTextFre"));
			this.sqlInsert.Parameters["@AnalysisTextFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@URLEng", SqlDbType.NVarChar, 1000, "URLEng"));
			this.sqlInsert.Parameters["@URLEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@URLFre", SqlDbType.NVarChar, 1000, "URLFre"));
			this.sqlInsert.Parameters["@URLFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@EffectiveDate", SqlDbType.DateTime, 24, "EffectiveDate"));
			this.sqlInsert.Parameters["@EffectiveDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Seq", SqlDbType.Int, 10, "Seq"));
			this.sqlInsert.Parameters["@Seq"].SourceVersion=DataRowVersion.Current;
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
            this.sqlInsert.Parameters.Add(new SqlParameter("@ProvisionNumber", SqlDbType.NVarChar, 30, "ProvisionNumber"));
            this.sqlInsert.Parameters["@ProvisionNumber"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[ProvisionUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvisionId", SqlDbType.Int, 10, "ProvisionId"));
			this.sqlUpdate.Parameters["@ProvisionId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LegislationId", SqlDbType.Int, 10, "LegislationId"));
			this.sqlUpdate.Parameters["@LegislationId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvisionNameEng", SqlDbType.NVarChar, 255, "ProvisionNameEng"));
			this.sqlUpdate.Parameters["@ProvisionNameEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvisionNameFre", SqlDbType.NVarChar, 255, "ProvisionNameFre"));
			this.sqlUpdate.Parameters["@ProvisionNameFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvisionTextEng", SqlDbType.NVarChar, -1, "ProvisionTextEng"));
			this.sqlUpdate.Parameters["@ProvisionTextEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvisionTextFre", SqlDbType.NVarChar, -1, "ProvisionTextFre"));
			this.sqlUpdate.Parameters["@ProvisionTextFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AnalysisTextEng", SqlDbType.NVarChar, -1, "AnalysisTextEng"));
			this.sqlUpdate.Parameters["@AnalysisTextEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AnalysisTextFre", SqlDbType.NVarChar, -1, "AnalysisTextFre"));
			this.sqlUpdate.Parameters["@AnalysisTextFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@URLEng", SqlDbType.NVarChar, 1000, "URLEng"));
			this.sqlUpdate.Parameters["@URLEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@URLFre", SqlDbType.NVarChar, 1000, "URLFre"));
			this.sqlUpdate.Parameters["@URLFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@EffectiveDate", SqlDbType.DateTime, 24, "EffectiveDate"));
			this.sqlUpdate.Parameters["@EffectiveDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Seq", SqlDbType.Int, 10, "Seq"));
			this.sqlUpdate.Parameters["@Seq"].SourceVersion=DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvisionNumber", SqlDbType.NVarChar, 30, "ProvisionNumber"));
            this.sqlUpdate.Parameters["@ProvisionNumber"].SourceVersion = DataRowVersion.Current;
			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[ProvisionDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvisionId", System.Data.SqlDbType.Int, 4, "ProvisionId"));
		    this.sqlDelete.Parameters["@ProvisionId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public appDB.ProvisionDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            appDB.ProvisionDataTable dt=new appDB.ProvisionDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public appDB.ProvisionDataTable Load(int ProvisionId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ProvisionSelectByProvisionId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProvisionId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ProvisionId"].Value=ProvisionId;

            appDB.ProvisionDataTable dt=new appDB.ProvisionDataTable();
			Fill(dt);
            return dt;
		}


		public appDB.ProvisionDataTable LoadByLegislationId(int LegislationId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ProvisionSelectByLegislationId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LegislationId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@LegislationId"].Value=LegislationId;

            appDB.ProvisionDataTable dt=new appDB.ProvisionDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}