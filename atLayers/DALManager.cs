
using System;
using System.IO;
//using System.ComponentModel;
//using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Runtime.Remoting.Services;
using System.Collections.Generic;

namespace atDAL
{
    /// <summary>
    /// Summary description for DALManager.
    /// </summary>
    public class DALManager : System.MarshalByRefObject
    {
        private System.Data.SqlClient.SqlConnection mySqlCon;
        protected internal System.Data.SqlClient.SqlTransaction myTrans;

        SqlDatabase SQLHelper;
        private string user;
        private string myDBConnect;
        private string origDBConnect;

        public string DBConnect
        {
            get { return myDBConnect; }
            set { myDBConnect = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public int userid;


        public DALManager(System.Net.NetworkCredential nc, string dbConnect)
        {
            origDBConnect = dbConnect;
            CreateCon(nc.UserName, nc.Password, dbConnect);
            user = nc.UserName;
            System.Diagnostics.Trace.WriteLine(user);

        }

        public DALManager(string _user, string pwd, string dbConnect)
        {
            origDBConnect = dbConnect;

            _user = _user.Trim();
            pwd = pwd.Trim();
            CreateCon(_user, pwd, dbConnect);
            user = _user;
            System.Diagnostics.Trace.WriteLine(user);
        }

        public void CreateCon(string _user, string pwd)
        {
            CreateCon(_user, pwd, origDBConnect);
        }

        public void CreateCon(string _user, string pwd, string dbConnect)
        {
            if (dbConnect.StartsWith("DATABASE"))
            {
                DBConnect = System.Configuration.ConfigurationManager.AppSettings[dbConnect].ToString();
            }
            else
            {
                DBConnect = dbConnect;
            }

            if (DBConnect == null)
            {
                System.Diagnostics.Trace.WriteLine("Null connect string", "atDal");
                throw new Exception("Null connect string");
            }

            DBConnect = DBConnect.Trim();
            if (!DBConnect.EndsWith(";"))
                DBConnect += ";";


            if (_user.Contains(@"\") || _user == "")
                DBConnect += "Integrated Security=True;";
            else
            {
                DBConnect += "user=" + _user + ";";
                DBConnect += "pwd=" + pwd + ";";
            }

            if (mySqlCon != null)
            {
                if (myTrans == null && mySqlCon != null && mySqlCon.State == ConnectionState.Open)
                    mySqlCon.Close();
                mySqlCon = null;
            }
            mySqlCon = new SqlConnection(DBConnect);
            SQLHelper = new SqlDatabase(mySqlCon);
        }

        public void OpenCon()
        {
            if (mySqlCon.State != ConnectionState.Open)
                mySqlCon.Open();
        }

        public void CloseCon()
        {
            if (myTrans == null && mySqlCon != null && mySqlCon.State == ConnectionState.Open)
                mySqlCon.Close();
        }
        public SqlConnection SqlCon
        {
            get
            {
                return mySqlCon;
            }
        }

        public void BeginTrans()
        {
            GetTrans();
        }
        public SqlTransaction GetTrans()
        {
            if (myTrans == null)
            {
                OpenCon();
                myTrans = mySqlCon.BeginTransaction();
            }
            return myTrans;
        }

        public void Commit()
        {
            if (myTrans != null)
            {
                myTrans.Commit();
                myTrans = null;
                CloseCon();
            }
        }

        public void Rollback()
        {
            if (myTrans != null)
            {
                myTrans.Rollback();
                myTrans = null;
                CloseCon();
            }
        }

        public ObjectDAL GetObjectDAL()
        {
            return new ObjectDAL(this);
        }

        public DataTable GetDataTable(string query)
        {
            System.Diagnostics.Trace.WriteLine(query, "GetDT");
            DataTable dt;
            if (myTrans == null)
            {
                //OpenCon();
                dt = SQLHelper.ExecuteDataSet(CommandType.Text, query).Tables[0];

            }
            else
                dt = SQLHelper.ExecuteDataSet(this.myTrans, CommandType.Text, query).Tables[0];

            dt.DataSet.RemotingFormat = this.RemotingFormat;
            dt.RemotingFormat = this.RemotingFormat;
            //CloseCon();
            return dt;
        }

        public byte[] GetDataTable(string query, SerializationFormat sf)
        {
            System.Diagnostics.Trace.WriteLine(query, "GetDT");

            if (myTrans == null)
            {
                //OpenCon();
                DataSet ds = SQLHelper.ExecuteDataSet(CommandType.Text, query);
                ds.RemotingFormat = sf;
                
                //CloseCon();
               
                return CompressData(ds,true);
            }
            else
            {

                DataSet ds = SQLHelper.ExecuteDataSet(this.myTrans, CommandType.Text, query);
                
                ds.RemotingFormat = sf;
                //CloseCon();
                return CompressData(ds);
            }
        }
        public void ExecuteNonQuery(string query)
        {
            if (myTrans == null)
            {
                //OpenCon();
                SQLHelper.ExecuteNonQuery(CommandType.Text, query);
                //CloseCon();
            }
            else
                SQLHelper.ExecuteNonQuery(this.myTrans, CommandType.Text, query);
        }

        public void ExecuteSP(string spName, params  object[] parameterValues)
        {
            if (myTrans == null)
            {
                //OpenCon();
                SQLHelper.ExecuteNonQuery(spName, parameterValues);
                //CloseCon();
            }
            else
                SQLHelper.ExecuteNonQuery(this.myTrans, spName, parameterValues);
        }

        //public void ExecuteSP (int timeOut, string spName, params object[] parameterValues)
        //{
        //    //			if(base.myTrans==null)
        //    //            SqlHelper.ExecuteNonQuery(this.SqlCon,spName, timeOut, parameterValues);

        //    SqlCommand cmd = new SqlCommand();
        //    //OpenCon();
        //    if(myTrans==null)
        //        cmd.Connection = this.SqlCon;
        //    else
        //        cmd.Transaction=this.myTrans;

        //    cmd.CommandTimeout = timeOut;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = spName;

        //    //if we receive parameter values, we need to figure out where they go
        //    if ((parameterValues != null) && (parameterValues.Length > 0)) 
        //    {
        //        //pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
        //        SqlParameter[] commandParameters = SqlHelperParameterCache.GetSpParameterSet(this.SqlCon, spName);

        //        //assign the provided values to these parameters based on parameter order
        //        SQLHelper.AssignParameterValues(commandParameters, parameterValues);
        //        SQLHelper.AttachParameters(cmd, commandParameters);
        //    }
        //    cmd.ExecuteNonQuery();
        //    //CloseCon();
        //}
        public DataSet ExecuteDatasetSQL(string spName)
        {
            System.Diagnostics.Trace.WriteLine(spName, "ExecDS");
            if (myTrans == null)
            {
                //OpenCon();
                SqlCommand cmd = new SqlCommand(spName);
                cmd.CommandTimeout = 0;
                DataSet ds = SQLHelper.ExecuteDataSet(cmd);
                //DataSet ds = SQLHelper.ExecuteDataSet(CommandType.Text, spName,);
                ds.RemotingFormat = RemotingFormat;
                //CloseCon();
                FixTZDSIssue(ds);

                return ds;
            }
            else
                return SQLHelper.ExecuteDataSet(this.myTrans, CommandType.Text, spName);
        }
        public static void FixTZDSIssue(DataSet myDS)
        {
            ObjectDAL.FixTZDSIssue(myDS);
        }

        public DataSet ExecuteDataset(string spName, params  object[] parameterValues)
        {
            System.Diagnostics.Trace.WriteLine(spName, "ExecDS");
            DataSet ds;
            if (myTrans == null)
            {
                SqlCommand cmd = new SqlCommand(spName, mySqlCon);
                
                ds = SQLHelper.ExecuteDataSet(spName, parameterValues);
            }
            else
                ds = SQLHelper.ExecuteDataSet(this.myTrans, spName, parameterValues);

            ds.RemotingFormat = this.RemotingFormat;
            return ds;
        }

        public byte[] ExecuteDatasetByte(string spName, params  object[] parameterValues)
        {
            System.Diagnostics.Trace.WriteLine(spName, "ExecDS");
            DataSet ds;
            if (myTrans == null)
            {
                ds = SQLHelper.ExecuteDataSet(spName, parameterValues);
            }
            else
                ds = SQLHelper.ExecuteDataSet(this.myTrans, spName, parameterValues);

            ds.RemotingFormat = this.RemotingFormat;
            return CompressData( ds,true);
        }

        public object ExecuteScalar(string spName, params  object[] parameterValues)
        {
            if (myTrans == null)
            {
                //OpenCon();
                object o = SQLHelper.ExecuteScalar(spName, parameterValues);
                //CloseCon();
                return o;
            }
            else
                return SQLHelper.ExecuteScalar(this.myTrans, spName, parameterValues);
        }

        public object ExecuteScalarSQL(string sql)
        {
            if (myTrans == null)
            {
                //OpenCon();
                object o = SQLHelper.ExecuteScalar(CommandType.Text, sql);
                //CloseCon();
                return o;
            }
            else
                return SQLHelper.ExecuteScalar(this.myTrans, CommandType.Text, sql);
        }

        public object PKIDGet(string objectName, int increment)
        {
            return this.ExecuteScalar("PKIDGetNext", objectName, increment);
        }

        public void PKIDSet(string objectName, int initial)
        {
            this.ExecuteSP("PKIDSetNext", objectName, initial);
        }

        SerializationFormat myRemotingFormat = SerializationFormat.Binary;
        public SerializationFormat RemotingFormat
        {
            get
            {
                return myRemotingFormat;
            }
            set
            {
                myRemotingFormat = value;
            }
        }

        public static byte[] CompressData(DataSet ds)
        {
            return CompressData(ds, false);
        }
        public static byte[] CompressData(DataSet ds,bool includeSchema)
        {
            return CompressStream(ds, includeSchema);

         ////   ds.RemotingFormat = SerializationFormat.Binary;
         //   if (includeSchema)
         //   {
         //       System.Text.StringBuilder sb = new System.Text.StringBuilder();
         //       System.IO.StringWriter sw = new System.IO.StringWriter(sb);
         //       ds.WriteXml(sw, XmlWriteMode.WriteSchema);
         //       string xml = sb.ToString();
         //       sw.Close();
         //       return CompressStream(xml);
         //   }
         //   else
         //   {
         //       return CompressStream(ds.GetXml());
         //   }

        }
        public static byte[] CompressData(DataTable dt)
        {

             DataSet ds=new DataSet();
                ds.Tables.Add(dt);
                return CompressData(ds);

            ////  dt.RemotingFormat = SerializationFormat.Binary;

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            //dt.WriteXml(sw, XmlWriteMode.IgnoreSchema);
            //string xml = sb.ToString();
            //sw.Close();
            //return CompressStream(xml);

        }

        //public static byte[] CompressStream(object obj)
        //{
        //    byte[] b;
        //    BinaryFormatter bf = new BinaryFormatter();

        //    using (MemoryTributary objStream = new MemoryTributary())
        //    {
        //      //  using (MemoryTributary ms = new MemoryTributary())
        //        using (System.IO.Compression.DeflateStream objZS = new System.IO.Compression.DeflateStream(objStream, System.IO.Compression.CompressionMode.Compress))
        //        {
        //            bf.Serialize(objZS, obj);
        //         //   ms.Position = 0;
        //          //  ms.CopyTo(objZS);
        //        };
        //        b = objStream.ToArray();
        //    };
        //    return b;
        //}

        public static byte[] CompressStream(DataSet ds, bool includeSchema)
        {
            XmlWriteMode xwm;
            if (includeSchema)
                xwm= XmlWriteMode.WriteSchema;
            else
                xwm = XmlWriteMode.IgnoreSchema;

                
              

            byte[] b;
          

            using (MemoryTributary objStream = new MemoryTributary())
            {
                
                
                using (System.IO.Compression.DeflateStream deflateStream = new System.IO.Compression.DeflateStream(objStream, System.IO.Compression.CompressionMode.Compress))
                {
                    ds.WriteXml(deflateStream, xwm);
                };
                b = objStream.ToArray();
            };
            return b;
        }


        public static DataSet DecompressDataSet(byte[] bytDs)
        {

            //Debug.Write(bytDs.Length.ToString());

            DataSet outDs = new DataSet();

            using (MemoryTributary inMs = new MemoryTributary(bytDs))
            {

                inMs.Seek(0, 0);

                using (DeflateStream zipStream = new DeflateStream(inMs, CompressionMode.Decompress, true))
                {

                //    outDs.ReadXml(zipStream, XmlReadMode.DiffGram);
                    BinaryFormatter bf = new BinaryFormatter();
                    outDs = (DataSet)bf.Deserialize(zipStream, null);

                }
            }

            return outDs;

        }



        //public static byte[] ReadFullStream(Stream stream)
        //{

        //    byte[] buffer = new byte[4096];

        //    using (MemoryTributary ms = new MemoryTributary())
        //    {

        //        while (true)
        //        {

        //            int read = stream.Read(buffer, 0, buffer.Length);

        //            if (read <= 0)

        //                return ms.ToArray();

        //            ms.Write(buffer, 0, read);

        //        }



        //    }

        //}

        public void LogEvent(string eventType, string windowsUser, string lmUser, string workAs, string exType, string exSource, string exMessage, string exStack)
        {
            //OpenCon();
            //SqlTransaction tran = mySqlCon.BeginTransaction();
            //try
            //{

            //    SQLHelper.ExecuteNonQuery(tran, "EventLogInsert", DateTime.Now, eventType, windowsUser, lmUser, workAs, exType, exSource, exMessage, exStack);
            //    tran.Commit();
            //}
            //catch (Exception x)
            //{
            //    tran.Rollback();
            //    throw x;
            //}
            ExecuteSP("EventLogInsert", DateTime.Now, eventType, windowsUser, lmUser, workAs, exType, exSource, exMessage, exStack);
        }

        public byte[] Load(string dalName)
        {
            Type ty = this.GetType();

            System.Reflection.MethodInfo mi = ty.GetMethod("Get" + dalName);
            atDAL.ObjectDAL od = (atDAL.ObjectDAL)mi.Invoke(this, null);

            return od.LoadByte();
        }
        public byte[] Update(List<string> dtList, byte[] compDS)
        {
            DataSet dsIn = DecompressDataSet(compDS);
            dsIn = Update(dtList, dsIn);
            return CompressData(dsIn);
           
        }

        public DataSet Update(List<string> dtList, DataSet dsIn)
        {
            FixTZDSIssue(dsIn);
            string curTblNm = "";
            int retries = 3;
            while (retries > 0)
            {
                try
                {
                    //deletes
                    dtList.Reverse();
                    foreach (string dtName in dtList)
                    {
                        string[] bits = dtName.Split(new Char[] { '.' });
                        curTblNm = bits[0];
                        //get a dal for the table
                        Type ty = this.GetType();
                        string dal=bits[0];
                        if (bits.Length > 1)
                            dal = bits[1];

                        System.Reflection.MethodInfo mi = ty.GetMethod("Get" + dal);
                        atDAL.ObjectDAL od = (atDAL.ObjectDAL)mi.Invoke(this, null);

                        DataTable dtIn = dsIn.Tables[bits[0]];
                        DataTable dtDEL = dtIn.GetChanges(DataRowState.Deleted);
                        if(dtDEL!=null)
                            od.Update(dtDEL);

                    }

                    //inserts and updates
                    dtList.Reverse();
                    foreach (string dtName in dtList)
                    {
                        string[] bits = dtName.Split(new Char[] { '.' });
                        curTblNm = bits[0];
                        //get a dal for the table
                        Type ty = this.GetType();
                        string dal = bits[0];
                        if (bits.Length > 1)
                            dal = bits[1];

                        System.Reflection.MethodInfo mi = ty.GetMethod("Get" + dal);
                        atDAL.ObjectDAL od = (atDAL.ObjectDAL)mi.Invoke(this, null);

                        DataTable dtIn = dsIn.Tables[bits[0]];
                       
                        DataTable dtUPD = dtIn.GetChanges(DataRowState.Modified | DataRowState.Added);
                        if (dtUPD != null)
                        {
                            od.Update(dtUPD);
                            dsIn.Tables.Remove(bits[0]);
                            dsIn.Tables.Add( dtUPD);
                        }
                    }

                    Commit();

                    retries = 0;
                    // return CompressData(dsIn);
                }
                catch (SqlException sqlx)
                {
                    if (sqlx.Number == 1205 && retries > 1)
                    {
                        retries--;
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {
                       
                        string msg = "Could not update table: {0}";
                        try
                        {
                            Rollback();
                        }
                        catch(Exception x)
                        {
                            msg += ": Rollback " + x.Message;
                        }

                        throw new ApplicationException(String.Format(msg, curTblNm), sqlx);

                    }
                }
                catch (Exception xr)
                {

                    string msg = "Could not update table: {0}";
                    try
                    {
                        Rollback();
                    }
                    catch (Exception x)
                    {
                        msg += ": Rollback " + x.Message;
                    }
                    throw new ApplicationException(String.Format(msg, curTblNm), xr);

                }
            }
            return dsIn;
        }
    }
}
