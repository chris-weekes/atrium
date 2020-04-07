using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>

    public partial class DocumentDAL : atDAL.ObjectDAL
    {
        public byte[] LoadAllFile(int fileId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
           // ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = SerializationFormat.Binary;
           

            ds.Merge(this.LoadByFileId(fileId));
            ds.Merge(aDAL.GetRecipient().LoadByFileId(fileId));
            ds.Merge(aDAL.GetAttachment().LoadByFileId(fileId));
            ds.Merge(LoadAttsNotOnFile(fileId));
            //foreach (docDB.DocumentRow dr in ds.Document)
            //{
            //    ds.Merge(aDAL.GetAttachment().LoadByMsgId(dr.DocId));
            //}
            //foreach (docDB.AttachmentRow att in ds.Attachment)
            //{
            //    if(ds.Document.FindByDocId(att.AttachmentId)==null)
            //        ds.Merge(this.Load(att.AttachmentId));
            //}
 
            FixTZDSIssue(ds);
            return atriumDALManager.CompressData(ds);

        }

        public byte[] LoadAll(int docId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
        //    ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = SerializationFormat.Binary;
   

            ds.Merge(this.Load(docId));
            ds.Merge(aDAL.GetRecipient().LoadByDocId(docId));
            docDB.AttachmentDataTable atts = aDAL.GetAttachment().LoadByMsgId(docId);
            ds.Merge(atts);

            foreach (docDB.AttachmentRow att in atts)
            {
                ds.Merge(this.Load(att.AttachmentId));
                ds.Merge(aDAL.GetRecipient().LoadByDocId(att.AttachmentId));
            }
         
            FixTZDSIssue(ds);
            return atriumDALManager.CompressData(ds);

        }

        public docDB.DocumentDataTable LoadAttsNotOnFile(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocumentSelectAttsByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            docDB.DocumentDataTable dt = new docDB.DocumentDataTable();
            Fill(dt);
            return dt;
        }

        public byte[] Search(string filter, bool includeXrefs)
        {

            DataSet ds = new docDB();// this.DAL.ExecuteDataset("DocumentSearch", filter, includeXrefs);
            ds.RemotingFormat = SerializationFormat.Binary;
            //ds.Tables[0].RemotingFormat = this.DAL.RemotingFormat ;
            //appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            //dt.Merge(ds.Tables[0]);
            //dt.RemotingFormat = this.RemotingFormat;

            sqlSelect.CommandTimeout = 60;

            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocumentSearch]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@where", System.Data.SqlDbType.NVarChar, 500));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@where"].Value = filter;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@includeXrefs", System.Data.SqlDbType.Bit, 1));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@includeXrefs"].Value = includeXrefs;

            //DataTable dt = new DataTable();
            Fill(ds);

            //ds.Tables[0].TableName = "Document";
            //ds.Tables[1].TableName = "Recipient";

            sqlSelect.CommandTimeout = 30;

            return atriumDALManager.CompressData( ds);
        }
        public byte[] SearchQuick(string filter, bool opinionsOnly)
        {

            DataSet ds = new docDB();// this.DAL.ExecuteDataset("DocumentSearchQuick", filter, opinionsOnly);
            ds.RemotingFormat = SerializationFormat.Binary;

            this.sqlDa.SelectCommand = sqlSelect;

            sqlSelect.CommandTimeout = 60;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocumentSearchQuick]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@where", System.Data.SqlDbType.NVarChar, 500));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@where"].Value = filter;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@opinionsOnly", System.Data.SqlDbType.Bit, 1));//, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@opinionsOnly"].Value = opinionsOnly;

            //DataTable dt = new DataTable();
            Fill(ds);
        //    ds.Tables[0].TableName = "Document";
         //   ds.Tables[1].TableName = "Recipient";

            sqlSelect.CommandTimeout = 30;

            return atriumDALManager.CompressData(ds);
        }

        //public DataTable LoadByFileIdAndDocName(int FileId,string DocName)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[DocumentSelectByFileIdAndDocName]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@FileId"].Value = FileId;
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocName", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@DocName"].Value = DocName;

        //    DataTable dt = new DataTable();
        //    Fill(dt);
        //    return dt;
        //}


        //public DataTable LoadByFileIdAndDocId(int FileId, int DocId)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[DocumentSelectByFileIdDocId]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@FileId"].Value = FileId;
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocId", System.Data.SqlDbType.Int , 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters["@DocId"].Value = DocId;

        //    DataTable dt = new DataTable();
        //    Fill(dt);
        //    return dt;
        //}

        public docDB.DocumentDataTable LoadByCheckedOutBy(int officerId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocumentSelectByCheckedoutBy]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficerId"].Value = officerId;

            docDB.DocumentDataTable dt = new docDB.DocumentDataTable();
            Fill(dt);
            return dt;
        }

        public docDB.DocumentDataTable LoadByFromId(int officerId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocumentSelectByFromId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficerId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficerId"].Value = officerId;

            docDB.DocumentDataTable dt = new docDB.DocumentDataTable();
            Fill(dt);
            return dt;
        }

    }
}
