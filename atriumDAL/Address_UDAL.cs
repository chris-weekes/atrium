using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lmDatasets;

namespace atriumDAL
{
    public partial class AddressDAL : atDAL.ObjectDAL
    {

        public atriumDB.AddressDataTable LoadByFileIdP(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[AddressSelectByFileIdP]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            atriumDB.AddressDataTable dt = new atriumDB.AddressDataTable();
            Fill(dt);
            return dt;
        }
    }
}
