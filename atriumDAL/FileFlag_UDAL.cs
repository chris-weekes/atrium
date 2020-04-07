using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    public partial class FileFlagDAL
    {

        public atriumDB.FileFlagDataTable LoadByFileId(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[FileFlagSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            atriumDB.FileFlagDataTable dt = new atriumDB.FileFlagDataTable();
            Fill(dt);
            return dt;
        }
    }
}
