using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>
    
    public partial class ContactDAL : atDAL.ObjectDAL
    {
        public atriumDB.ContactDataTable LoadByFileId(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ContactSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4));

            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            atriumDB.ContactDataTable dt = new atriumDB.ContactDataTable();
            Fill(dt);
            return dt;
        }
        public atriumDB.ContactDataTable LoadBySIN(string SIN)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ContactSelectBySIN]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SIN", System.Data.SqlDbType.Char, 9));

            this.sqlSelect.Parameters["@SIN"].Value = SIN;

            atriumDB.ContactDataTable dt = new atriumDB.ContactDataTable();
            Fill(dt);
            return dt;
        }

        public byte[] LoadByte(int contactid)
        {
            return atriumDALManager.CompressData(Load(contactid));
        }
    }
}
