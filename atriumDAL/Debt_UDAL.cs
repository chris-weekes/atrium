using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>
    
    public partial class DebtDAL : atDAL.ObjectDAL
    {
        public CLAS.DebtDataTable LoadByFileId(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DebtSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            CLAS.DebtDataTable dt = new CLAS.DebtDataTable();
            Fill(dt);
            return dt;
        }
    }
}
