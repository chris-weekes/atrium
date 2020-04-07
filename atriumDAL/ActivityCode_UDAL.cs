using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>
    
    public partial class ActivityCodeDAL : atDAL.ObjectDAL
    {
        public ActivityConfig.ActivityCodeDataTable LoadByActivityCode(string ActivityCode)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivityCodeSelectByActivityCode]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ActivityCode", System.Data.SqlDbType.NVarChar, 4));

            this.sqlSelect.Parameters["@ActivityCode"].Value = ActivityCode;

            ActivityConfig.ActivityCodeDataTable dt = new ActivityConfig.ActivityCodeDataTable();
            Fill(dt);
            return dt;
        }
    }
}
