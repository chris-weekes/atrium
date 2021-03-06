using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on ACControlType table 
	/// in lawmate_dev database
	/// on 2014-02-12
	/// </summary>
	public partial class ACControlTypeDAL:atDAL.ObjectDAL
	{

    	internal ACControlTypeDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "ACControlType", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ACControlType", "ACControlType"),
		  new System.Data.Common.DataColumnMapping("ACControlTypeDescEng", "ACControlTypeDescEng"),
		  new System.Data.Common.DataColumnMapping("ACControlTypeDescFre", "ACControlTypeDescFre"),
		  new System.Data.Common.DataColumnMapping("ACControlTypeFullDescEng", "ACControlTypeFullDescEng"),
		  new System.Data.Common.DataColumnMapping("ACControlTypeFullDescFre", "ACControlTypeFullDescFre"),
		  new System.Data.Common.DataColumnMapping("BindingProp", "BindingProp"),
		  new System.Data.Common.DataColumnMapping("IsCustomBinding", "IsCustomBinding"),
		  new System.Data.Common.DataColumnMapping("Width", "Width"),
		  new System.Data.Common.DataColumnMapping("ImgResource", "ImgResource"),
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

			this.sqlSelectAll.CommandText = "[ACControlTypeSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[ACControlTypeInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACControlType", SqlDbType.NVarChar, 2, "ACControlType"));
			this.sqlInsert.Parameters["@ACControlType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACControlTypeDescEng", SqlDbType.NVarChar, 50, "ACControlTypeDescEng"));
			this.sqlInsert.Parameters["@ACControlTypeDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACControlTypeDescFre", SqlDbType.NVarChar, 50, "ACControlTypeDescFre"));
			this.sqlInsert.Parameters["@ACControlTypeDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACControlTypeFullDescEng", SqlDbType.NVarChar, 255, "ACControlTypeFullDescEng"));
			this.sqlInsert.Parameters["@ACControlTypeFullDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ACControlTypeFullDescFre", SqlDbType.NVarChar, 255, "ACControlTypeFullDescFre"));
			this.sqlInsert.Parameters["@ACControlTypeFullDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@BindingProp", SqlDbType.NVarChar, 50, "BindingProp"));
			this.sqlInsert.Parameters["@BindingProp"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@IsCustomBinding", SqlDbType.Bit, 1, "IsCustomBinding"));
			this.sqlInsert.Parameters["@IsCustomBinding"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Width", SqlDbType.Int, 10, "Width"));
			this.sqlInsert.Parameters["@Width"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ImgResource", SqlDbType.NVarChar, 50, "ImgResource"));
			this.sqlInsert.Parameters["@ImgResource"].SourceVersion=DataRowVersion.Current;
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

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[ACControlTypeUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACControlType", SqlDbType.NVarChar, 2, "ACControlType"));
			this.sqlUpdate.Parameters["@ACControlType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACControlTypeDescEng", SqlDbType.NVarChar, 50, "ACControlTypeDescEng"));
			this.sqlUpdate.Parameters["@ACControlTypeDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACControlTypeDescFre", SqlDbType.NVarChar, 50, "ACControlTypeDescFre"));
			this.sqlUpdate.Parameters["@ACControlTypeDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACControlTypeFullDescEng", SqlDbType.NVarChar, 255, "ACControlTypeFullDescEng"));
			this.sqlUpdate.Parameters["@ACControlTypeFullDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ACControlTypeFullDescFre", SqlDbType.NVarChar, 255, "ACControlTypeFullDescFre"));
			this.sqlUpdate.Parameters["@ACControlTypeFullDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@BindingProp", SqlDbType.NVarChar, 50, "BindingProp"));
			this.sqlUpdate.Parameters["@BindingProp"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@IsCustomBinding", SqlDbType.Bit, 1, "IsCustomBinding"));
			this.sqlUpdate.Parameters["@IsCustomBinding"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Width", SqlDbType.Int, 10, "Width"));
			this.sqlUpdate.Parameters["@Width"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ImgResource", SqlDbType.NVarChar, 50, "ImgResource"));
			this.sqlUpdate.Parameters["@ImgResource"].SourceVersion=DataRowVersion.Current;
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
			this.sqlDelete.CommandText = "[ACControlTypeDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ACControlType", System.Data.SqlDbType.NVarChar, 2, "ACControlType"));
		    this.sqlDelete.Parameters["@ACControlType"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public ActivityConfig.ACControlTypeDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            ActivityConfig.ACControlTypeDataTable dt = new ActivityConfig.ACControlTypeDataTable();
			Fill(dt);
            return dt;
        }



         public ActivityConfig.ACControlTypeDataTable Load(string ACControlType)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ACControlTypeSelectByACControlType]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ACControlType", System.Data.SqlDbType.NVarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ACControlType"].Value=ACControlType;

            ActivityConfig.ACControlTypeDataTable dt = new ActivityConfig.ACControlTypeDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
