using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class setup by JLL
	/// based on File Access table 
	/// in lawmatedev database
	/// on 2012-02-09
	/// </summary>
    public partial class FileAccessDAL : atDAL.ObjectDAL
	{

    	internal FileAccessDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{
            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		        new System.Data.Common.DataTableMapping("Table", "FileAccess", new System.Data.Common.DataColumnMapping[] {
		            new System.Data.Common.DataColumnMapping("Id", "Id"),
		            new System.Data.Common.DataColumnMapping("FileId", "FileId"),
                    new System.Data.Common.DataColumnMapping("UserName", "UserName"),
                    new System.Data.Common.DataColumnMapping("AccessTime", "AccessTime"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[FileAccessSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

		}

		public DataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            DataTable dt=new DataTable();
			Fill(dt);
            return dt;
        }



        public lmDatasets.atriumDB.FileAccessDataTable Load(int FileId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[FileAccessSelectByFileId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@FileId"].Value=FileId;

            lmDatasets.atriumDB.FileAccessDataTable dt = new lmDatasets.atriumDB.FileAccessDataTable();
			Fill(dt);
            return dt;
		}
	}
}
