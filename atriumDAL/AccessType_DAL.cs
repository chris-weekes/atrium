using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on AccessType table 
	/// in lawmate database
	/// on 3/12/2007
	/// </summary>
	public partial class AccessTypeDAL:atDAL.ObjectDAL
	{

    	internal AccessTypeDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "AccessType", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("AccessTypeCode", "AccessTypeCode"),
		  new System.Data.Common.DataColumnMapping("AccessTypeDescEng", "AccessTypeDescEng"),
		  new System.Data.Common.DataColumnMapping("AccessTypeDescFre", "AccessTypeDescFre"),
		  new System.Data.Common.DataColumnMapping("IsOwner", "IsOwner"),
		  new System.Data.Common.DataColumnMapping("IsLead", "IsLead"),
		  new System.Data.Common.DataColumnMapping("IsClient", "IsClient"),
		  new System.Data.Common.DataColumnMapping("AllAccounts", "AllAccounts"),
		  new System.Data.Common.DataColumnMapping("AssignedAccount", "AssignedAccount"),
		  new System.Data.Common.DataColumnMapping("EntryUser", "EntryUser"),
		  new System.Data.Common.DataColumnMapping("EntryDate", "EntryDate"),
		  new System.Data.Common.DataColumnMapping("UpdateUser", "UpdateUser"),
		  new System.Data.Common.DataColumnMapping("UpdateDate", "UpdateDate"),
		  new System.Data.Common.DataColumnMapping("ReadOnly", "ReadOnly"),
		  new System.Data.Common.DataColumnMapping("Obsolete", "Obsolete"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[AccessTypeSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[AccessTypeInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@AccessTypeCode", SqlDbType.NVarChar, 4, "AccessTypeCode"));
			this.sqlInsert.Parameters["@AccessTypeCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AccessTypeDescEng", SqlDbType.NVarChar, 50, "AccessTypeDescEng"));
			this.sqlInsert.Parameters["@AccessTypeDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AccessTypeDescFre", SqlDbType.NVarChar, 50, "AccessTypeDescFre"));
			this.sqlInsert.Parameters["@AccessTypeDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@IsOwner", SqlDbType.Bit, 1, "IsOwner"));
			this.sqlInsert.Parameters["@IsOwner"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@IsLead", SqlDbType.Bit, 1, "IsLead"));
			this.sqlInsert.Parameters["@IsLead"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@IsClient", SqlDbType.Bit, 1, "IsClient"));
			this.sqlInsert.Parameters["@IsClient"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AllAccounts", SqlDbType.Bit, 1, "AllAccounts"));
			this.sqlInsert.Parameters["@AllAccounts"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AssignedAccount", SqlDbType.Bit, 1, "AssignedAccount"));
			this.sqlInsert.Parameters["@AssignedAccount"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@EntryUser", SqlDbType.NVarChar, 20, "EntryUser"));
			this.sqlInsert.Parameters["@EntryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.SmallDateTime, 24, "EntryDate"));
			this.sqlInsert.Parameters["@EntryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@UpdateUser", SqlDbType.NVarChar, 20, "UpdateUser"));
			this.sqlInsert.Parameters["@UpdateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@UpdateDate", SqlDbType.SmallDateTime, 24, "UpdateDate"));
			this.sqlInsert.Parameters["@UpdateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Bit, 1, "ReadOnly"));
			this.sqlInsert.Parameters["@ReadOnly"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Obsolete", SqlDbType.Bit, 1, "Obsolete"));
			this.sqlInsert.Parameters["@Obsolete"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[AccessTypeUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AccessTypeCode", SqlDbType.NVarChar, 4, "AccessTypeCode"));
			this.sqlUpdate.Parameters["@AccessTypeCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AccessTypeDescEng", SqlDbType.NVarChar, 50, "AccessTypeDescEng"));
			this.sqlUpdate.Parameters["@AccessTypeDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AccessTypeDescFre", SqlDbType.NVarChar, 50, "AccessTypeDescFre"));
			this.sqlUpdate.Parameters["@AccessTypeDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@IsOwner", SqlDbType.Bit, 1, "IsOwner"));
			this.sqlUpdate.Parameters["@IsOwner"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@IsLead", SqlDbType.Bit, 1, "IsLead"));
			this.sqlUpdate.Parameters["@IsLead"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@IsClient", SqlDbType.Bit, 1, "IsClient"));
			this.sqlUpdate.Parameters["@IsClient"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AllAccounts", SqlDbType.Bit, 1, "AllAccounts"));
			this.sqlUpdate.Parameters["@AllAccounts"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AssignedAccount", SqlDbType.Bit, 1, "AssignedAccount"));
			this.sqlUpdate.Parameters["@AssignedAccount"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@EntryUser", SqlDbType.NVarChar, 20, "EntryUser"));
			this.sqlUpdate.Parameters["@EntryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.SmallDateTime, 24, "EntryDate"));
			this.sqlUpdate.Parameters["@EntryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@UpdateUser", SqlDbType.NVarChar, 20, "UpdateUser"));
			this.sqlUpdate.Parameters["@UpdateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@UpdateDate", SqlDbType.SmallDateTime, 24, "UpdateDate"));
			this.sqlUpdate.Parameters["@UpdateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ReadOnly", SqlDbType.Bit, 1, "ReadOnly"));
			this.sqlUpdate.Parameters["@ReadOnly"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Obsolete", SqlDbType.Bit, 1, "Obsolete"));
			this.sqlUpdate.Parameters["@Obsolete"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
			//this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    //this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Original;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[AccessTypeDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccessTypeCode", System.Data.SqlDbType.NVarChar, 4, "AccessTypeCode"));
		    this.sqlDelete.Parameters["@AccessTypeCode"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public CodesDB.AccessTypeDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CodesDB.AccessTypeDataTable dt=new CodesDB.AccessTypeDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CodesDB.AccessTypeDataTable Load(string AccessTypeCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[AccessTypeSelectByAccessTypeCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AccessTypeCode", System.Data.SqlDbType.NVarChar, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@AccessTypeCode"].Value=AccessTypeCode;

            CodesDB.AccessTypeDataTable dt=new CodesDB.AccessTypeDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
