using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    /// <summary>
    /// </summary>

    public partial class OfficeDAL : atDAL.ObjectDAL
    {
        public officeDB.OfficeDataTable LoadByOfficeCode(string OfficeCode)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[OfficeSelectByOfficeCode]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeCode", System.Data.SqlDbType.NVarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficeCode"].Value = OfficeCode;

            officeDB.OfficeDataTable dt = new officeDB.OfficeDataTable();
            Fill(dt);
            return dt;
        }
        public byte[] LoadByte(int OfficeId)
        {
            return atriumDALManager.CompressData(Load(OfficeId));
        }
    }
}
