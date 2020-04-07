using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ddTable table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class ddTableDAL:atDAL.ObjectDAL
	{

    	internal ddTableDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
        {


            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ddTable", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("TableId", "TableId"),
		  new System.Data.Common.DataColumnMapping("TableName", "TableName"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("DescriptionEng", "DescriptionEng"),
		  new System.Data.Common.DataColumnMapping("DescriptionFre", "DescriptionFre"),
		  new System.Data.Common.DataColumnMapping("isDBTable", "isDBTable"),
		  new System.Data.Common.DataColumnMapping("tblGroup", "tblGroup"),
		  new System.Data.Common.DataColumnMapping("tblType", "tblType"),
		  new System.Data.Common.DataColumnMapping("isLookup", "isLookup"),
		  new System.Data.Common.DataColumnMapping("LookupName", "LookupName"),
		  new System.Data.Common.DataColumnMapping("AllowInRelatedFields", "AllowInRelatedFields"),
		  new System.Data.Common.DataColumnMapping("DBTableName", "DBTableName"),
		  new System.Data.Common.DataColumnMapping("ShowInTOC", "ShowInTOC"),
		  new System.Data.Common.DataColumnMapping("DefaultFormID", "DefaultFormID"),
		  new System.Data.Common.DataColumnMapping("isDynamic", "isDynamic"),
		  new System.Data.Common.DataColumnMapping("FeatureId", "FeatureId"),
			})});

            // 
            // sqlSelect
            // 
            this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelect.Connection = myDALManager.SqlCon;

            this.sqlSelectAll.CommandText = "[ddTableSelect]";
            this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectAll.Connection = myDALManager.SqlCon;
            this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            // 
            // sqlInsert
            // 
            this.sqlInsert.CommandText = "[ddTableInsert]";
            this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsert.Connection = myDALManager.SqlCon;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlInsert.Parameters.Add(new SqlParameter("@TableId", SqlDbType.Int, 10, "TableId"));
            this.sqlInsert.Parameters["@TableId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@TableName", SqlDbType.NVarChar, 50, "TableName"));
            this.sqlInsert.Parameters["@TableName"].SourceVersion = DataRowVersion.Current;
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
            this.sqlInsert.Parameters.Add(new SqlParameter("@DescriptionEng", SqlDbType.NVarChar, 255, "DescriptionEng"));
            this.sqlInsert.Parameters["@DescriptionEng"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DescriptionFre", SqlDbType.NVarChar, 255, "DescriptionFre"));
            this.sqlInsert.Parameters["@DescriptionFre"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@isDBTable", SqlDbType.Bit, 1, "isDBTable"));
            this.sqlInsert.Parameters["@isDBTable"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@tblGroup", SqlDbType.NVarChar, 50, "tblGroup"));
            this.sqlInsert.Parameters["@tblGroup"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@tblType", SqlDbType.NVarChar, 50, "tblType"));
            this.sqlInsert.Parameters["@tblType"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@isLookup", SqlDbType.Bit, 1, "isLookup"));
            this.sqlInsert.Parameters["@isLookup"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LookupName", SqlDbType.NVarChar, 50, "LookupName"));
            this.sqlInsert.Parameters["@LookupName"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AllowInRelatedFields", SqlDbType.Bit, 1, "AllowInRelatedFields"));
            this.sqlInsert.Parameters["@AllowInRelatedFields"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DBTableName", SqlDbType.NVarChar, 50, "DBTableName"));
            this.sqlInsert.Parameters["@DBTableName"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ShowInTOC", SqlDbType.Bit, 1, "ShowInTOC"));
            this.sqlInsert.Parameters["@ShowInTOC"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DefaultFormID", SqlDbType.Int, 10, "DefaultFormID"));
            this.sqlInsert.Parameters["@DefaultFormID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@isDynamic", SqlDbType.Bit, 1, "isDynamic"));
            this.sqlInsert.Parameters["@isDynamic"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FeatureId", SqlDbType.Int, 10, "FeatureId"));
            this.sqlInsert.Parameters["@FeatureId"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlUpdate
            // 
            this.sqlUpdate.CommandText = "[ddTableUpdate]";
            this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdate.Connection = myDALManager.SqlCon;
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlUpdate.Parameters.Add(new SqlParameter("@TableId", SqlDbType.Int, 10, "TableId"));
            this.sqlUpdate.Parameters["@TableId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@TableName", SqlDbType.NVarChar, 50, "TableName"));
            this.sqlUpdate.Parameters["@TableName"].SourceVersion = DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DescriptionEng", SqlDbType.NVarChar, 255, "DescriptionEng"));
            this.sqlUpdate.Parameters["@DescriptionEng"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DescriptionFre", SqlDbType.NVarChar, 255, "DescriptionFre"));
            this.sqlUpdate.Parameters["@DescriptionFre"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@isDBTable", SqlDbType.Bit, 1, "isDBTable"));
            this.sqlUpdate.Parameters["@isDBTable"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@tblGroup", SqlDbType.NVarChar, 50, "tblGroup"));
            this.sqlUpdate.Parameters["@tblGroup"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@tblType", SqlDbType.NVarChar, 50, "tblType"));
            this.sqlUpdate.Parameters["@tblType"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@isLookup", SqlDbType.Bit, 1, "isLookup"));
            this.sqlUpdate.Parameters["@isLookup"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LookupName", SqlDbType.NVarChar, 50, "LookupName"));
            this.sqlUpdate.Parameters["@LookupName"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AllowInRelatedFields", SqlDbType.Bit, 1, "AllowInRelatedFields"));
            this.sqlUpdate.Parameters["@AllowInRelatedFields"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DBTableName", SqlDbType.NVarChar, 50, "DBTableName"));
            this.sqlUpdate.Parameters["@DBTableName"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ShowInTOC", SqlDbType.Bit, 1, "ShowInTOC"));
            this.sqlUpdate.Parameters["@ShowInTOC"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DefaultFormID", SqlDbType.Int, 10, "DefaultFormID"));
            this.sqlUpdate.Parameters["@DefaultFormID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@isDynamic", SqlDbType.Bit, 1, "isDynamic"));
            this.sqlUpdate.Parameters["@isDynamic"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FeatureId", SqlDbType.Int, 10, "FeatureId"));
            this.sqlUpdate.Parameters["@FeatureId"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlDelete
            // 
            this.sqlDelete.CommandText = "[ddTableDelete]";
            this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDelete.Connection = myDALManager.SqlCon;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TableId", System.Data.SqlDbType.Int, 4, "TableId"));
            this.sqlDelete.Parameters["@TableId"].SourceVersion = DataRowVersion.Original;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
            this.sqlDelete.Parameters["@ts"].SourceVersion = DataRowVersion.Original;



        }


        public appDB.ddTableDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            appDB.ddTableDataTable dt = new appDB.ddTableDataTable();
			Fill(dt);
            return dt;
        }



        public appDB.ddTableDataTable Load(int TableId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ddTableSelectByTableId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TableId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@TableId"].Value=TableId;

            appDB.ddTableDataTable dt = new appDB.ddTableDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
