using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using lmDatasets;

namespace atriumDAL
{
    public partial class DocContentDAL : atDAL.ObjectDAL
    {
        public override DataTable Update(DataTable myData)
        {
            //this prevents large documents from getting send back to the client after an update
            //    base.Update(myData);

            this.myDALManager.OpenCon();

            sqlDa.UpdateCommand.Connection = myDALManager.SqlCon;
            sqlDa.InsertCommand.Connection = myDALManager.SqlCon;
            sqlDa.DeleteCommand.Connection = myDALManager.SqlCon;

            System.Data.SqlClient.SqlTransaction tran = myDALManager.GetTrans();

            this.sqlDa.UpdateCommand.Transaction = tran;
            this.sqlDa.DeleteCommand.Transaction = tran;
            this.sqlDa.InsertCommand.Transaction = tran;

            myData.Columns["ts"].ReadOnly = false;
            foreach (DataRow dr in myData.Select("", "", DataViewRowState.CurrentRows))
            {

                int pos = 8040;
                int docid = (int)dr["DocId"];
               
                byte[] c = (byte[])dr["Contents"];
            
                int len1 = c.Length ;
                if (len1 > 8040)
                    len1 = 8040;

                byte[] p1 = new byte[len1];
                Array.Copy(c, 0, p1, 0, len1);

                dr["Contents"] = p1;
                sqlDa.Update(new DataRow[]{dr});

               

                if (c.Length > 8040)
                {
                    do
                    {
                        //update contents
                        
                        int len = c.Length - pos;
                        if (len > 8040)
                            len = 8040;
                        byte[] param = new byte[len];
                        Array.Copy(c, pos, param, 0, len);

                        dr["ts"]=myDALManager.ExecuteScalar("DocContentAppendContent", docid, dr["version"], param, dr["ts"]);


                        pos += 8040;
                    } while (pos < c.Length);

                }
            }

            this.myDALManager.CloseCon();

            myData.Columns.Remove("Contents");
            //myData.AcceptChanges();
            return myData;
        }

        public docDB.DocContentDataTable LoadDT(int DocId, string Version)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocContentSelectByDocId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Version", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@DocId"].Value = DocId;
            this.sqlSelect.Parameters["@Version"].Value = Version;

            docDB.DocContentDataTable dt = new docDB.DocContentDataTable();
            Fill(dt);
            return dt;
        }

        public docDB.VersionHistoryListDataTable LoadVersionHistory(int DocId, int Fileid)
        {

            DataTable dt = myDALManager.ExecuteDataset("DocContentListAudit", DocId, Fileid).Tables[0];

            docDB.VersionHistoryListDataTable vhl = new docDB.VersionHistoryListDataTable();

            vhl.Merge(dt);
            vhl.RemotingFormat = myDALManager.RemotingFormat;

            return vhl;

        }

        public int DocContentAuditDelete(int docId, string version)
        {
            int returnValue = 0;
            myDALManager.ExecuteSP("DocContentAuditDelete", returnValue, docId, version);
            return returnValue;
        }

        public byte[] Load(int DocId, string Version)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[DocContentSelectByDocId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Version", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@DocId"].Value = DocId;
            if (Version == null)
                this.sqlSelect.Parameters["@Version"].Value = DBNull.Value;
            else
                this.sqlSelect.Parameters["@Version"].Value = Version;

            docDB.DocContentDataTable dt = new docDB.DocContentDataTable();
            Fill(dt);
            return atriumDALManager.CompressData(dt);
        }

        public bool IsLatest(int docId, byte[] timeStamp)
        {
            int i = 0;
            i = (int)myDALManager.ExecuteScalar("[DocContentIsLatest]", docId, timeStamp);
            return i == 1;
        }

        public void ReadStream(int DocId, System.IO.Stream responseStream, string Version)
        {

            try
            {

                this.sqlSelect.Parameters.Clear();
                this.sqlSelect.CommandText = "[DocContentSelectByDocId]";
                this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DocId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
                this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Version", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

                this.sqlSelect.Parameters["@DocId"].Value = DocId;
                this.sqlSelect.Parameters["@Version"].Value = Version;

                this.myDALManager.OpenCon();

                this.sqlSelect.Connection = myDALManager.SqlCon;

                SqlDataReader myReader = sqlSelect.ExecuteReader(CommandBehavior.SequentialAccess);

                while (myReader.Read())
                {


                    //System.IO.BinaryWriter bw = new System.IO.BinaryWriter(responseStream);

                    int bufferSize = 1024;                   // Size of the BLOB buffer.
                    byte[] outbyte = new byte[bufferSize];  // The BLOB byte[] buffer to be filled by GetBytes.
                    long retval;                            // The bytes returned from GetBytes.
                    long startIndex = 0;                    // The starting position in the BLOB output.


                    // Reset the starting byte for the new BLOB.
                    startIndex = 0;

                    // Read the bytes into outbyte[] and retain the number of bytes returned.
                    retval = myReader.GetBytes(7, startIndex, outbyte, 0, bufferSize);

                    // Continue reading and writing while there are bytes beyond the size of the buffer.
                    while (retval == bufferSize)
                    {

                        //bw.Write(outbyte);

                        //bw.Flush();
                        responseStream.Write(outbyte, 0, bufferSize);
                        responseStream.Flush();

                        // Reposition the start index to the end of the last buffer and fill the buffer.
                        startIndex += bufferSize;
                        retval = myReader.GetBytes(7, startIndex, outbyte, 0, bufferSize);
                    }

                    // Write the remaining buffer.
                    responseStream.Write(outbyte, 0, (int)retval);
                    responseStream.Flush();

                    // Close the output file.
                    //bw.Close();

                }

                // Close the reader and the connection.
                myReader.Close();
                this.myDALManager.CloseCon();

            }
            catch (Exception x)
            {
                myDALManager.LogEvent("Error", myDALManager.User, myDALManager.User, myDALManager.User, x.GetType().ToString(), x.Source, x.Message, x.StackTrace);
                throw;
            }

        }
    }
}
