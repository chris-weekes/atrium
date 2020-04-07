using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Series table 
	/// in atrium database
	/// on 1/30/2008
	/// </summary>
	public partial class SeriesDAL:atDAL.ObjectDAL
	{

    	internal SeriesDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Series", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("SeriesId", "SeriesId"),
		  new System.Data.Common.DataColumnMapping("SeriesCode", "SeriesCode"),
		  new System.Data.Common.DataColumnMapping("ParentSeriesId", "ParentSeriesId"),
		  new System.Data.Common.DataColumnMapping("SeriesTypeCode", "SeriesTypeCode"),
		  new System.Data.Common.DataColumnMapping("SeriesDescEng", "SeriesDescEng"),
		  new System.Data.Common.DataColumnMapping("SeriesDescFre", "SeriesDescFre"),
		  new System.Data.Common.DataColumnMapping("OncePerFile", "OncePerFile"),
		  new System.Data.Common.DataColumnMapping("SingleInstancePerFile", "SingleInstancePerFile"),
		  new System.Data.Common.DataColumnMapping("CreatesFile", "CreatesFile"),
		  new System.Data.Common.DataColumnMapping("ConfirmMultipleInstance", "ConfirmMultipleInstance"),
		  new System.Data.Common.DataColumnMapping("NameFormatE", "NameFormatE"),
		  new System.Data.Common.DataColumnMapping("NameFormatF", "NameFormatF"),
		  new System.Data.Common.DataColumnMapping("Obsolete", "Obsolete"),
		  new System.Data.Common.DataColumnMapping("ContainerFileId", "ContainerFileId"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("Notes", "Notes"),
		  new System.Data.Common.DataColumnMapping("HelpLinkE", "HelpLinkE"),
		  new System.Data.Common.DataColumnMapping("HelpLinkF", "HelpLinkF"),
		  new System.Data.Common.DataColumnMapping("HelpTextE", "HelpTextE"),
		  new System.Data.Common.DataColumnMapping("HelpTextF", "HelpTextF"),
          new System.Data.Common.DataColumnMapping("Status", "Status"),
          new System.Data.Common.DataColumnMapping("AllowMove", "AllowMove"),
          new System.Data.Common.DataColumnMapping("AlwaysAvailable", "AlwaysAvailable"),
          new System.Data.Common.DataColumnMapping("SeriesPackage", "SeriesPackage"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[SeriesSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[SeriesInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@SeriesId", SqlDbType.Int, 10, "SeriesId"));
			this.sqlInsert.Parameters["@SeriesId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SeriesCode", SqlDbType.NVarChar, 10, "SeriesCode"));
			this.sqlInsert.Parameters["@SeriesCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ParentSeriesId", SqlDbType.Int, 10, "ParentSeriesId"));
			this.sqlInsert.Parameters["@ParentSeriesId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SeriesTypeCode", SqlDbType.NVarChar, 3, "SeriesTypeCode"));
			this.sqlInsert.Parameters["@SeriesTypeCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SeriesDescEng", SqlDbType.NVarChar, 255, "SeriesDescEng"));
			this.sqlInsert.Parameters["@SeriesDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SeriesDescFre", SqlDbType.NVarChar, 255, "SeriesDescFre"));
			this.sqlInsert.Parameters["@SeriesDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OncePerFile", SqlDbType.Bit, 1, "OncePerFile"));
			this.sqlInsert.Parameters["@OncePerFile"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@SingleInstancePerFile", SqlDbType.Bit, 1, "SingleInstancePerFile"));
			this.sqlInsert.Parameters["@SingleInstancePerFile"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CreatesFile", SqlDbType.Bit, 1, "CreatesFile"));
			this.sqlInsert.Parameters["@CreatesFile"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ConfirmMultipleInstance", SqlDbType.Bit, 1, "ConfirmMultipleInstance"));
			this.sqlInsert.Parameters["@ConfirmMultipleInstance"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@NameFormatE", SqlDbType.NVarChar, 512, "NameFormatE"));
			this.sqlInsert.Parameters["@NameFormatE"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@NameFormatF", SqlDbType.NVarChar, 512, "NameFormatF"));
			this.sqlInsert.Parameters["@NameFormatF"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Obsolete", SqlDbType.Bit, 1, "Obsolete"));
			this.sqlInsert.Parameters["@Obsolete"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ContainerFileId", SqlDbType.Int, 10, "ContainerFileId"));
			this.sqlInsert.Parameters["@ContainerFileId"].SourceVersion=DataRowVersion.Current;
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
			this.sqlInsert.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar, 0, "Notes"));
			this.sqlInsert.Parameters["@Notes"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HelpLinkE", SqlDbType.NVarChar, 50, "HelpLinkE"));
			this.sqlInsert.Parameters["@HelpLinkE"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HelpLinkF", SqlDbType.NVarChar, 50, "HelpLinkF"));
			this.sqlInsert.Parameters["@HelpLinkF"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HelpTextE", SqlDbType.NVarChar, 0, "HelpTextE"));
			this.sqlInsert.Parameters["@HelpTextE"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HelpTextF", SqlDbType.NVarChar, 0, "HelpTextF"));
			this.sqlInsert.Parameters["@HelpTextF"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 3, "Status"));
            this.sqlInsert.Parameters["@Status"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AllowMove", SqlDbType.Bit, 1, "AllowMove"));
            this.sqlInsert.Parameters["@AllowMove"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AlwaysAvailable", SqlDbType.Bit, 1, "AlwaysAvailable"));
            this.sqlInsert.Parameters["@AlwaysAvailable"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SeriesPackage", SqlDbType.Int, 10, "SeriesPackage"));
            this.sqlInsert.Parameters["@SeriesPackage"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[SeriesUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SeriesId", SqlDbType.Int, 10, "SeriesId"));
			this.sqlUpdate.Parameters["@SeriesId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SeriesCode", SqlDbType.NVarChar, 10, "SeriesCode"));
			this.sqlUpdate.Parameters["@SeriesCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ParentSeriesId", SqlDbType.Int, 10, "ParentSeriesId"));
			this.sqlUpdate.Parameters["@ParentSeriesId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SeriesTypeCode", SqlDbType.NVarChar, 3, "SeriesTypeCode"));
			this.sqlUpdate.Parameters["@SeriesTypeCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SeriesDescEng", SqlDbType.NVarChar, 255, "SeriesDescEng"));
			this.sqlUpdate.Parameters["@SeriesDescEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SeriesDescFre", SqlDbType.NVarChar, 255, "SeriesDescFre"));
			this.sqlUpdate.Parameters["@SeriesDescFre"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OncePerFile", SqlDbType.Bit, 1, "OncePerFile"));
			this.sqlUpdate.Parameters["@OncePerFile"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@SingleInstancePerFile", SqlDbType.Bit, 1, "SingleInstancePerFile"));
			this.sqlUpdate.Parameters["@SingleInstancePerFile"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CreatesFile", SqlDbType.Bit, 1, "CreatesFile"));
			this.sqlUpdate.Parameters["@CreatesFile"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ConfirmMultipleInstance", SqlDbType.Bit, 1, "ConfirmMultipleInstance"));
			this.sqlUpdate.Parameters["@ConfirmMultipleInstance"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@NameFormatE", SqlDbType.NVarChar, 512, "NameFormatE"));
			this.sqlUpdate.Parameters["@NameFormatE"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@NameFormatF", SqlDbType.NVarChar, 512, "NameFormatF"));
			this.sqlUpdate.Parameters["@NameFormatF"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Obsolete", SqlDbType.Bit, 1, "Obsolete"));
			this.sqlUpdate.Parameters["@Obsolete"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ContainerFileId", SqlDbType.Int, 10, "ContainerFileId"));
			this.sqlUpdate.Parameters["@ContainerFileId"].SourceVersion=DataRowVersion.Current;
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
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar, 0, "Notes"));
			this.sqlUpdate.Parameters["@Notes"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HelpLinkE", SqlDbType.NVarChar, 50, "HelpLinkE"));
			this.sqlUpdate.Parameters["@HelpLinkE"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HelpLinkF", SqlDbType.NVarChar, 50, "HelpLinkF"));
			this.sqlUpdate.Parameters["@HelpLinkF"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HelpTextE", SqlDbType.NVarChar, 0, "HelpTextE"));
			this.sqlUpdate.Parameters["@HelpTextE"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HelpTextF", SqlDbType.NVarChar, 0, "HelpTextF"));
			this.sqlUpdate.Parameters["@HelpTextF"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 3, "Status"));
            this.sqlUpdate.Parameters["@Status"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AllowMove", SqlDbType.Bit, 1, "AllowMove"));
            this.sqlUpdate.Parameters["@AllowMove"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AlwaysAvailable", SqlDbType.Bit, 1, "AlwaysAvailable"));
            this.sqlUpdate.Parameters["@AlwaysAvailable"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SeriesPackage", SqlDbType.Int, 10, "SeriesPackage"));
            this.sqlUpdate.Parameters["@SeriesPackage"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[SeriesDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SeriesId", System.Data.SqlDbType.Int, 4, "SeriesId"));
		    this.sqlDelete.Parameters["@SeriesId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public ActivityConfig.SeriesDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            ActivityConfig.SeriesDataTable dt=new ActivityConfig.SeriesDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public ActivityConfig.SeriesDataTable Load(int SeriesId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[SeriesSelectBySeriesId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SeriesId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@SeriesId"].Value=SeriesId;

            ActivityConfig.SeriesDataTable dt=new ActivityConfig.SeriesDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
