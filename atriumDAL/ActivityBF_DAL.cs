using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ActivityBF table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class ActivityBFDAL:atDAL.ObjectDAL
	{

    	internal ActivityBFDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
        {


            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ActivityBF", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ActivityBFId", "ActivityBFId"),
		  new System.Data.Common.DataColumnMapping("ActivityId", "ActivityId"),
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("ACBFId", "ACBFId"),
		  new System.Data.Common.DataColumnMapping("ForOfficeId", "ForOfficeId"),
		  new System.Data.Common.DataColumnMapping("Priority", "Priority"),
		  new System.Data.Common.DataColumnMapping("BFOfficerID", "BFOfficerID"),
		  new System.Data.Common.DataColumnMapping("BFComment", "BFComment"),
		  new System.Data.Common.DataColumnMapping("BFDate", "BFDate"),
		  new System.Data.Common.DataColumnMapping("Completed", "Completed"),
		  new System.Data.Common.DataColumnMapping("CompletedByID", "CompletedByID"),
		  new System.Data.Common.DataColumnMapping("CompletedDate", "CompletedDate"),
		  new System.Data.Common.DataColumnMapping("BFType", "BFType"),
		  new System.Data.Common.DataColumnMapping("isRead", "isRead"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("ACDepId", "ACDepId"),
		  new System.Data.Common.DataColumnMapping("isMail", "isMail"),
		  new System.Data.Common.DataColumnMapping("RoleCode", "RoleCode"),
		  new System.Data.Common.DataColumnMapping("InitialBFDate", "InitialBFDate"),
		  new System.Data.Common.DataColumnMapping("ManuallyCompleted", "ManuallyCompleted"),
			})});

            // 
            // sqlSelect
            // 
            this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelect.Connection = myDALManager.SqlCon;

            this.sqlSelectAll.CommandText = "[ActivityBFSelect]";
            this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectAll.Connection = myDALManager.SqlCon;
            this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            // 
            // sqlInsert
            // 
            this.sqlInsert.CommandText = "[ActivityBFInsert]";
            this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsert.Connection = myDALManager.SqlCon;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlInsert.Parameters.Add(new SqlParameter("@ActivityBFId", SqlDbType.Int, 10, "ActivityBFId"));
            this.sqlInsert.Parameters["@ActivityBFId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ActivityId", SqlDbType.Int, 10, "ActivityId"));
            this.sqlInsert.Parameters["@ActivityId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
            this.sqlInsert.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ACBFId", SqlDbType.Int, 10, "ACBFId"));
            this.sqlInsert.Parameters["@ACBFId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ForOfficeId", SqlDbType.Int, 10, "ForOfficeId"));
            this.sqlInsert.Parameters["@ForOfficeId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Priority", SqlDbType.SmallInt, 5, "Priority"));
            this.sqlInsert.Parameters["@Priority"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BFOfficerID", SqlDbType.Int, 10, "BFOfficerID"));
            this.sqlInsert.Parameters["@BFOfficerID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BFComment", SqlDbType.NVarChar, 255, "BFComment"));
            this.sqlInsert.Parameters["@BFComment"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BFDate", SqlDbType.SmallDateTime, 24, "BFDate"));
            this.sqlInsert.Parameters["@BFDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Completed", SqlDbType.Bit, 1, "Completed"));
            this.sqlInsert.Parameters["@Completed"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@CompletedByID", SqlDbType.Int, 10, "CompletedByID"));
            this.sqlInsert.Parameters["@CompletedByID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@CompletedDate", SqlDbType.SmallDateTime, 24, "CompletedDate"));
            this.sqlInsert.Parameters["@CompletedDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BFType", SqlDbType.Int, 10, "BFType"));
            this.sqlInsert.Parameters["@BFType"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@isRead", SqlDbType.Bit, 1, "isRead"));
            this.sqlInsert.Parameters["@isRead"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
            this.sqlInsert.Parameters["@entryUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
            this.sqlInsert.Parameters["@entryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
            this.sqlInsert.Parameters["@updateUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
            this.sqlInsert.Parameters["@updateDate"].SourceVersion = DataRowVersion.Current;
            //this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            //this.sqlInsert.Parameters["@ts"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ACDepId", SqlDbType.Int, 10, "ACDepId"));
            this.sqlInsert.Parameters["@ACDepId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@isMail", SqlDbType.Bit, 1, "isMail"));
            this.sqlInsert.Parameters["@isMail"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RoleCode", SqlDbType.NVarChar, 4, "RoleCode"));
            this.sqlInsert.Parameters["@RoleCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@InitialBFDate", SqlDbType.SmallDateTime, 24, "InitialBFDate"));
            this.sqlInsert.Parameters["@InitialBFDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ManuallyCompleted", SqlDbType.Bit, 1, "ManuallyCompleted"));
            this.sqlInsert.Parameters["@ManuallyCompleted"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlUpdate
            // 
            this.sqlUpdate.CommandText = "[ActivityBFUpdateNew]";
            this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdate.Connection = myDALManager.SqlCon;
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlUpdate.Parameters.Add(new SqlParameter("@ActivityBFId", SqlDbType.Int, 4, "ActivityBFId"));
            this.sqlUpdate.Parameters["@ActivityBFId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ActivityId", SqlDbType.Int, 4, "ActivityId"));
            this.sqlUpdate.Parameters["@ActivityId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 4, "FileId"));
            this.sqlUpdate.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@RoleCode", SqlDbType.NVarChar, 4, "RoleCode"));
            this.sqlUpdate.Parameters["@RoleCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BFType", SqlDbType.Int, 10, "BFType"));
            this.sqlUpdate.Parameters["@BFType"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@isMail", SqlDbType.Bit, 1, "isMail"));
            this.sqlUpdate.Parameters["@isMail"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ACBFId", SqlDbType.Int, 4, "ACBFId"));
            this.sqlUpdate.Parameters["@ACBFId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ForOfficeId", SqlDbType.Int, 4, "ForOfficeId"));
            this.sqlUpdate.Parameters["@ForOfficeId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Priority", SqlDbType.SmallInt, 5, "Priority"));
            this.sqlUpdate.Parameters["@Priority"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BFOfficerID", SqlDbType.Int, 4, "BFOfficerID"));
            this.sqlUpdate.Parameters["@BFOfficerID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BFComment", SqlDbType.NVarChar, 255, "BFComment"));
            this.sqlUpdate.Parameters["@BFComment"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BFDate", SqlDbType.SmallDateTime, 24, "BFDate"));
            this.sqlUpdate.Parameters["@BFDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@isRead", SqlDbType.Bit, 1, "isRead"));
            this.sqlUpdate.Parameters["@isRead"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Completed", SqlDbType.Bit, 1, "Completed"));
            this.sqlUpdate.Parameters["@Completed"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@CompletedByID", SqlDbType.Int, 4, "CompletedByID"));
            this.sqlUpdate.Parameters["@CompletedByID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@CompletedDate", SqlDbType.SmallDateTime, 24, "CompletedDate"));
            this.sqlUpdate.Parameters["@CompletedDate"].SourceVersion = DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ACDepId", SqlDbType.Int, 4, "ACDepId"));
            this.sqlUpdate.Parameters["@ACDepId"].SourceVersion = DataRowVersion.Current;

            this.sqlUpdate.Parameters.Add(new SqlParameter("@origActivityId", SqlDbType.Int, 4, "ActivityId"));
            this.sqlUpdate.Parameters["@origActivityId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origFileId", SqlDbType.Int, 4, "FileId"));
            this.sqlUpdate.Parameters["@origFileId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origRoleCode", SqlDbType.NVarChar, 4, "RoleCode"));
            this.sqlUpdate.Parameters["@origRoleCode"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origBFType", SqlDbType.Int, 10, "BFType"));
            this.sqlUpdate.Parameters["@origBFType"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origisMail", SqlDbType.Bit, 1, "isMail"));
            this.sqlUpdate.Parameters["@origisMail"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origACBFId", SqlDbType.Int, 4, "ACBFId"));
            this.sqlUpdate.Parameters["@origACBFId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origForOfficeId", SqlDbType.Int, 4, "ForOfficeId"));
            this.sqlUpdate.Parameters["@origForOfficeId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origPriority", SqlDbType.SmallInt, 5, "Priority"));
            this.sqlUpdate.Parameters["@origPriority"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origBFOfficerID", SqlDbType.Int, 4, "BFOfficerID"));
            this.sqlUpdate.Parameters["@origBFOfficerID"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origBFComment", SqlDbType.NVarChar, 255, "BFComment"));
            this.sqlUpdate.Parameters["@origBFComment"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origBFDate", SqlDbType.SmallDateTime, 24, "BFDate"));
            this.sqlUpdate.Parameters["@origBFDate"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origisRead", SqlDbType.Bit, 1, "isRead"));
            this.sqlUpdate.Parameters["@origisRead"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origCompleted", SqlDbType.Bit, 1, "Completed"));
            this.sqlUpdate.Parameters["@origCompleted"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origCompletedByID", SqlDbType.Int, 4, "CompletedByID"));
            this.sqlUpdate.Parameters["@origCompletedByID"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origCompletedDate", SqlDbType.SmallDateTime, 24, "CompletedDate"));
            this.sqlUpdate.Parameters["@origCompletedDate"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origACDepId", SqlDbType.Int, 4, "ACDepId"));
            this.sqlUpdate.Parameters["@origACDepId"].SourceVersion = DataRowVersion.Original;

            this.sqlUpdate.Parameters.Add(new SqlParameter("@InitialBFDate", SqlDbType.SmallDateTime, 24, "InitialBFDate"));
            this.sqlUpdate.Parameters["@InitialBFDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ManuallyCompleted", SqlDbType.Bit, 1, "ManuallyCompleted"));
            this.sqlUpdate.Parameters["@ManuallyCompleted"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlDelete
            // 
            this.sqlDelete.CommandText = "[ActivityBFDelete]";
            this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDelete.Connection = myDALManager.SqlCon;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActivityBFId", System.Data.SqlDbType.Int, 4, "ActivityBFId"));
            this.sqlDelete.Parameters["@ActivityBFId"].SourceVersion = DataRowVersion.Original;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
            this.sqlDelete.Parameters["@ts"].SourceVersion = DataRowVersion.Original;



        }

		public atriumDB.ActivityBFDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.ActivityBFDataTable dt=new atriumDB.ActivityBFDataTable();
			//Fill(dt);
            return dt;
        }

	
		
		public atriumDB.ActivityBFDataTable Load(int ActivityBFId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ActivityBFSelectByActivityBFId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActivityBFId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ActivityBFId"].Value=ActivityBFId;

            atriumDB.ActivityBFDataTable dt=new atriumDB.ActivityBFDataTable();
			Fill(dt);
            return dt;
		}


		public atriumDB.ActivityBFDataTable LoadByActivityId(int ActivityId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ActivityBFSelectByActivityId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActivityId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@ActivityId"].Value=ActivityId;

            atriumDB.ActivityBFDataTable dt=new atriumDB.ActivityBFDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
