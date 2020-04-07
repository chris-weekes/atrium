using System;
using System.Collections.Generic;
using System.Text;
using lmDatasets;

namespace atriumDAL
{
    public partial class ContactEmailDAL : atDAL.ObjectDAL
    {
        public officeDB.ContactEmailDataTable LoadByContactId(int ContactId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ContactEmailSelectByContactId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@ContactId"].Value = ContactId;

            officeDB.ContactEmailDataTable dt = new officeDB.ContactEmailDataTable();
            Fill(dt);
            return dt;
        }

        public officeDB.ContactEmailDataTable LoadByEmail(string Email)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ContactEmailSelectByEmail]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@Email"].Value = Email;

            officeDB.ContactEmailDataTable dt = new officeDB.ContactEmailDataTable();
            Fill(dt);
            return dt;
        }

    }
}
