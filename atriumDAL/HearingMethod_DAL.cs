using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on HearingMethod table 
	/// in lawmatedev database
	/// on 16/07/2012
	/// </summary>
	public partial class HearingMethodDAL:atDAL.ObjectDAL
	{

    	internal HearingMethodDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "HearingMethod", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("HearingMethodId", "HearingMethodId"),
		  new System.Data.Common.DataColumnMapping("HearingMethodEng", "HearingMethodEng"),
		  new System.Data.Common.DataColumnMapping("HearingMethodFre", "HearingMethodFre"),
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

			this.sqlSelectAll.CommandText = "[HearingMethodSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[HearingMethodInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@HearingMethodId", SqlDbType.Int, 10, "HearingMethodId"));
			this.sqlInsert.Parameters["@HearingMethodId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HearingMethodEng", SqlDbType.NVarChar, 50, "HearingMethodEng"));
			this.sqlInsert.Parameters["@HearingMethodEng"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HearingMethodFre", SqlDbType.NVarChar, 50, "HearingMethodFre"));
			this.sqlInsert.Parameters["@HearingMethodFre"].SourceVersion=DataRowVersion.Current;
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
            this.sqlInsert.Parameters.Add(new SqlParameter("@HearingMethodAbbrEng", SqlDbType.NVarChar, 10, "HearingMethodAbbrEng"));
            this.sqlInsert.Parameters["@HearingMethodAbbrEng"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@HearingMethodAbbrFre", SqlDbType.NVarChar, 10, "HearingMethodAbbrFre"));
            this.sqlInsert.Parameters["@HearingMethodAbbrFre"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[HearingMethodUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodId", SqlDbType.Int, 10, "HearingMethodId"));
			this.sqlUpdate.Parameters["@HearingMethodId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodEng", SqlDbType.NVarChar, 50, "HearingMethodEng"));
			this.sqlUpdate.Parameters["@HearingMethodEng"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodFre", SqlDbType.NVarChar, 50, "HearingMethodFre"));
			this.sqlUpdate.Parameters["@HearingMethodFre"].SourceVersion=DataRowVersion.Current;
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
            this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodAbbrEng", SqlDbType.NVarChar, 10, "HearingMethodAbbrEng"));
            this.sqlUpdate.Parameters["@HearingMethodAbbrEng"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingMethodAbbrFre", SqlDbType.NVarChar, 10, "HearingMethodAbbrFre"));
            this.sqlUpdate.Parameters["@HearingMethodAbbrFre"].SourceVersion = DataRowVersion.Current;


			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[HearingMethodDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HearingMethodId", System.Data.SqlDbType.Int, 4, "HearingMethodId"));
		    this.sqlDelete.Parameters["@HearingMethodId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		 public CodesDB.HearingMethodDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            CodesDB.HearingMethodDataTable dt=new CodesDB.HearingMethodDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public CodesDB.HearingMethodDataTable Load(int HearingMethodId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[HearingMethodSelectByHearingMethodId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HearingMethodId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@HearingMethodId"].Value=HearingMethodId;

            CodesDB.HearingMethodDataTable dt=new CodesDB.HearingMethodDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}
