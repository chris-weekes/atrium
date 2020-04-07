using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    public partial class ActivityDAL : atDAL.ObjectDAL
    {
        public atriumDB.ActivityDataTable LoadByIRP(int FileId, int IRPId, DateTime SRPDate, int officeId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivitySelectByIRP]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IRPId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            if (IRPId == 0)
                this.sqlSelect.Parameters["@IRPId"].Value = System.DBNull.Value;
            else
                this.sqlSelect.Parameters["@IRPId"].Value = IRPId;

            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SRPDate", System.Data.SqlDbType.DateTime, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@SRPDate"].Value = SRPDate;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@officeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@officeId"].Value = officeId;
            atriumDB.ActivityDataTable dt = new atriumDB.ActivityDataTable();
            Fill(dt);
            return dt;
        }


        //ActivitySelectWithXref
        public atriumDB.ActivityDataTable LoadByXrefId(int Id)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivitySelectByXrefId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Id", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@Id"].Value = Id;

            atriumDB.ActivityDataTable dt = new atriumDB.ActivityDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.ActivityDataTable LoadByThread(string Thread)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[ActivitySelectByThread]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Thread", System.Data.SqlDbType.NVarChar,512, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@Thread"].Value = Thread;

            atriumDB.ActivityDataTable dt = new atriumDB.ActivityDataTable();
            Fill(dt);
            return dt;
        }

        public DataSet DeepLoadByFileId(int fileId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
        //    ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = SerializationFormat.Binary;
            

            myLastEdit = new DateTime(1900, 1, 1);
            ds.Merge(this.LoadByFileId(fileId));
            ds.Merge(aDAL.GetProcess().LoadByFileId(fileId));
            ds.Merge(aDAL.GetProcessContext().LoadByFileId(fileId));
            ds.Merge(aDAL.GetDisbursement().LoadByFileID(fileId));
            ds.Merge(aDAL.GetActivityTime().LoadByFileId(fileId));
            ds.Merge(aDAL.GetActivityBF().LoadByFileId(fileId));
            ds.Merge(aDAL.GetActivityAttribution().LoadByFileID(fileId));

            FixTZDSIssue(ds);
            return ds;
        }

        public byte[] DeepLoadByFileId(int fileId, SerializationFormat sf)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
        //    ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = sf;
       

            myLastEdit = new DateTime(1900, 1, 1);
            ds.Merge(this.LoadByFileId(fileId));
            ds.Merge(aDAL.GetProcess().LoadByFileId(fileId));
            ds.Merge(aDAL.GetProcessContext().LoadByFileId(fileId));
            ds.Merge(aDAL.GetDisbursement().LoadByFileID(fileId));
            ds.Merge(aDAL.GetActivityTime().LoadByFileId(fileId));
            ds.Merge(aDAL.GetActivityBF().LoadByFileId(fileId));
            ds.Merge(aDAL.GetActivityAttribution().LoadByFileID(fileId));

            FixTZDSIssue(ds);
            
            return atDAL.DALManager.CompressData( ds);
        }
    }
}
