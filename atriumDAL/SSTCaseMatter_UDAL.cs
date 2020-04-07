using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lmDatasets;

namespace atriumDAL
{
    public partial class SSTCaseMatterDAL : atDAL.ObjectDAL
    {
        public SST.SSTCaseMatterDataTable LoadByFileId(int fileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[SSTCaseMatterSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@fileId"].Value = fileId;

            SST.SSTCaseMatterDataTable dt = new SST.SSTCaseMatterDataTable();
            Fill(dt);
            return dt;
        }
    }
}
