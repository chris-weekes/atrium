using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ddField table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class ddFieldDAL:atDAL.ObjectDAL
	{

    	internal ddFieldDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

         private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ddField", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("FieldId", "FieldId"),
		  new System.Data.Common.DataColumnMapping("TableId", "TableId"),
		  new System.Data.Common.DataColumnMapping("FieldName", "FieldName"),
		  new System.Data.Common.DataColumnMapping("LeftEng", "LeftEng"),
		  new System.Data.Common.DataColumnMapping("LeftFre", "LeftFre"),
		  new System.Data.Common.DataColumnMapping("DataType", "DataType"),
		  new System.Data.Common.DataColumnMapping("FieldType", "FieldType"),
		  new System.Data.Common.DataColumnMapping("Lookup", "Lookup"),
		  new System.Data.Common.DataColumnMapping("TopEng", "TopEng"),
		  new System.Data.Common.DataColumnMapping("TopFre", "TopFre"),
		  new System.Data.Common.DataColumnMapping("DescEng", "DescEng"),
		  new System.Data.Common.DataColumnMapping("DescFre", "DescFre"),
		  new System.Data.Common.DataColumnMapping("ToolEng", "ToolEng"),
		  new System.Data.Common.DataColumnMapping("ToolFre", "ToolFre"),
		  new System.Data.Common.DataColumnMapping("HelpEng", "HelpEng"),
		  new System.Data.Common.DataColumnMapping("HelpFre", "HelpFre"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("AllowInRelatedFields", "AllowInRelatedFields"),
		  new System.Data.Common.DataColumnMapping("DefaultSystemValue", "DefaultSystemValue"),
		  new System.Data.Common.DataColumnMapping("InputMask", "InputMask"),
		  new System.Data.Common.DataColumnMapping("isFromView", "isFromView"),
		  new System.Data.Common.DataColumnMapping("isVirtualColumn", "isVirtualColumn"),
		  new System.Data.Common.DataColumnMapping("isMissing", "isMissing"),
		  new System.Data.Common.DataColumnMapping("DBFieldName", "DBFieldName"),
		  new System.Data.Common.DataColumnMapping("Relation", "Relation"),
		  new System.Data.Common.DataColumnMapping("Cardinality", "Cardinality"),
		  new System.Data.Common.DataColumnMapping("FeatureId", "FeatureId"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[ddFieldSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ddFieldInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@FieldId", SqlDbType.Int, 10, "FieldId"));
			this.sqlInsert.Parameters["@FieldId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TableId", SqlDbType.Int, 10, "TableId"));
			this.sqlInsert.Parameters["@TableId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FieldName", SqlDbType.NVarChar, 50, "FieldName"));
			this.sqlInsert.Parameters["@FieldName"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LeftEng", SqlDbType.NVarChar, 512, "LeftEng"));
			this.sqlInsert.Parameters["@LeftEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LeftFre", SqlDbType.NVarChar, 512, "LeftFre"));
			this.sqlInsert.Parameters["@LeftFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DataType", SqlDbType.NVarChar, 255, "DataType"));
			this.sqlInsert.Parameters["@DataType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FieldType", SqlDbType.NVarChar, 2, "FieldType"));
			this.sqlInsert.Parameters["@FieldType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Lookup", SqlDbType.NVarChar, 50, "Lookup"));
			this.sqlInsert.Parameters["@Lookup"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TopEng", SqlDbType.NVarChar, 50, "TopEng"));
			this.sqlInsert.Parameters["@TopEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@TopFre", SqlDbType.NVarChar, 50, "TopFre"));
			this.sqlInsert.Parameters["@TopFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DescEng", SqlDbType.NVarChar, 2147483647, "DescEng"));
			this.sqlInsert.Parameters["@DescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DescFre", SqlDbType.NVarChar, 2147483647, "DescFre"));
			this.sqlInsert.Parameters["@DescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ToolEng", SqlDbType.NVarChar, 255, "ToolEng"));
			this.sqlInsert.Parameters["@ToolEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ToolFre", SqlDbType.NVarChar, 255, "ToolFre"));
			this.sqlInsert.Parameters["@ToolFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HelpEng", SqlDbType.NVarChar, 100, "HelpEng"));
			this.sqlInsert.Parameters["@HelpEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HelpFre", SqlDbType.NVarChar, 100, "HelpFre"));
			this.sqlInsert.Parameters["@HelpFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlInsert.Parameters.Add(new SqlParameter("@AllowInRelatedFields", SqlDbType.Bit, 1, "AllowInRelatedFields"));
			this.sqlInsert.Parameters["@AllowInRelatedFields"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DefaultSystemValue", SqlDbType.NVarChar, 100, "DefaultSystemValue"));
			this.sqlInsert.Parameters["@DefaultSystemValue"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@InputMask", SqlDbType.NVarChar, 100, "InputMask"));
			this.sqlInsert.Parameters["@InputMask"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@isFromView", SqlDbType.Bit, 1, "isFromView"));
			this.sqlInsert.Parameters["@isFromView"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@isVirtualColumn", SqlDbType.Bit, 1, "isVirtualColumn"));
			this.sqlInsert.Parameters["@isVirtualColumn"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@isMissing", SqlDbType.Bit, 1, "isMissing"));
			this.sqlInsert.Parameters["@isMissing"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DBFieldName", SqlDbType.NVarChar, 50, "DBFieldName"));
			this.sqlInsert.Parameters["@DBFieldName"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Relation", SqlDbType.NVarChar, 50, "Relation"));
			this.sqlInsert.Parameters["@Relation"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Cardinality", SqlDbType.NVarChar, 50, "Cardinality"));
			this.sqlInsert.Parameters["@Cardinality"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FeatureId", SqlDbType.Int, 10, "FeatureId"));
            this.sqlInsert.Parameters["@FeatureId"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[ddFieldUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FieldId", SqlDbType.Int, 10, "FieldId"));
			this.sqlUpdate.Parameters["@FieldId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TableId", SqlDbType.Int, 10, "TableId"));
			this.sqlUpdate.Parameters["@TableId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FieldName", SqlDbType.NVarChar, 50, "FieldName"));
			this.sqlUpdate.Parameters["@FieldName"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LeftEng", SqlDbType.NVarChar, 512, "LeftEng"));
			this.sqlUpdate.Parameters["@LeftEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LeftFre", SqlDbType.NVarChar, 512, "LeftFre"));
			this.sqlUpdate.Parameters["@LeftFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DataType", SqlDbType.NVarChar, 255, "DataType"));
			this.sqlUpdate.Parameters["@DataType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FieldType", SqlDbType.NVarChar, 2, "FieldType"));
			this.sqlUpdate.Parameters["@FieldType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Lookup", SqlDbType.NVarChar, 50, "Lookup"));
			this.sqlUpdate.Parameters["@Lookup"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TopEng", SqlDbType.NVarChar, 50, "TopEng"));
			this.sqlUpdate.Parameters["@TopEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@TopFre", SqlDbType.NVarChar, 50, "TopFre"));
			this.sqlUpdate.Parameters["@TopFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DescEng", SqlDbType.NVarChar, 2147483647, "DescEng"));
			this.sqlUpdate.Parameters["@DescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DescFre", SqlDbType.NVarChar, 2147483647, "DescFre"));
			this.sqlUpdate.Parameters["@DescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ToolEng", SqlDbType.NVarChar, 255, "ToolEng"));
			this.sqlUpdate.Parameters["@ToolEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ToolFre", SqlDbType.NVarChar, 255, "ToolFre"));
			this.sqlUpdate.Parameters["@ToolFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HelpEng", SqlDbType.NVarChar, 100, "HelpEng"));
			this.sqlUpdate.Parameters["@HelpEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HelpFre", SqlDbType.NVarChar, 100, "HelpFre"));
			this.sqlUpdate.Parameters["@HelpFre"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AllowInRelatedFields", SqlDbType.Bit, 1, "AllowInRelatedFields"));
			this.sqlUpdate.Parameters["@AllowInRelatedFields"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DefaultSystemValue", SqlDbType.NVarChar, 100, "DefaultSystemValue"));
			this.sqlUpdate.Parameters["@DefaultSystemValue"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@InputMask", SqlDbType.NVarChar, 100, "InputMask"));
			this.sqlUpdate.Parameters["@InputMask"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@isFromView", SqlDbType.Bit, 1, "isFromView"));
			this.sqlUpdate.Parameters["@isFromView"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@isVirtualColumn", SqlDbType.Bit, 1, "isVirtualColumn"));
			this.sqlUpdate.Parameters["@isVirtualColumn"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@isMissing", SqlDbType.Bit, 1, "isMissing"));
			this.sqlUpdate.Parameters["@isMissing"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DBFieldName", SqlDbType.NVarChar, 50, "DBFieldName"));
			this.sqlUpdate.Parameters["@DBFieldName"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Relation", SqlDbType.NVarChar, 50, "Relation"));
			this.sqlUpdate.Parameters["@Relation"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Cardinality", SqlDbType.NVarChar, 50, "Cardinality"));
			this.sqlUpdate.Parameters["@Cardinality"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FeatureId", SqlDbType.Int, 10, "FeatureId"));
            this.sqlUpdate.Parameters["@FeatureId"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[ddFieldDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FieldId", System.Data.SqlDbType.Int, 4, "FieldId"));
		    this.sqlDelete.Parameters["@FieldId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

        public appDB.ddFieldDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            appDB.ddFieldDataTable dt = new appDB.ddFieldDataTable();
			Fill(dt);
            return dt;
        }



        public appDB.ddFieldDataTable Load(int FieldId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ddFieldSelectByFieldId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FieldId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@FieldId"].Value=FieldId;

            appDB.ddFieldDataTable dt = new appDB.ddFieldDataTable();
			Fill(dt);
            return dt;
		}


        public appDB.ddFieldDataTable LoadByTableId(int TableId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ddFieldSelectByTableId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@TableId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@TableId"].Value=TableId;

            appDB.ddFieldDataTable dt = new appDB.ddFieldDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}