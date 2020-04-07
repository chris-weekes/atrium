using System;
using System.Collections.Generic;
using System.Text;
using lmDatasets;

namespace atriumDAL
{
    public partial class RecipientDAL:atDAL.ObjectDAL
    {
        public docDB.RecipientDataTable LoadByFileId(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[RecipientSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            docDB.RecipientDataTable dt = new docDB.RecipientDataTable();
            Fill(dt);
            return dt;
        }

        //public docDB.RecipientDataTable Search(string filter, bool includeXrefs)
        //{
        //    //companion to document search
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[RecipientSearch]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@where", System.Data.SqlDbType.NVarChar, 500));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@where"].Value = filter;
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@includeXrefs", System.Data.SqlDbType.Bit, 1));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@includeXrefs"].Value = includeXrefs;

        //    docDB.RecipientDataTable dt = new docDB.RecipientDataTable();
        //    Fill(dt);
        //    return dt;
        //}
        //public docDB.RecipientDataTable SearchQuick(string filter, bool opinionsOnly)
        //{
        //    //companion to document search
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[RecipientSearchQuick]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@where", System.Data.SqlDbType.NVarChar, 500));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@where"].Value = filter;
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@opinionsOnly", System.Data.SqlDbType.Bit, 1));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@opinionsOnly"].Value = opinionsOnly;

        //    docDB.RecipientDataTable dt = new docDB.RecipientDataTable();
        //    Fill(dt);
        //    return dt;
        //}
    }
}
