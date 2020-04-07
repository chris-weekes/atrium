using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using atDAL;
namespace atLogic
{
    public class WarningEventArgs : EventArgs
    {
        public WarningLevel Level= WarningLevel.Display;
        public string Message = "";
        public string Source = "";
    }
    public delegate void WarningEventHandler(object sender, WarningEventArgs e);

    public enum WarningLevel
    {
        Display,
        Interrupt
    }

    /// <summary>
    /// A BEmanager manages all the ObjectBE objects associated with the dataset associated with the manager
    /// It can also manage child BEManagers
    /// It provides factory methods for creating ObjectBE and BEManager instances
    /// </summary>
    public class BEManager:IDisposable
    {

        public BEManager(AppManager appMan)
        {
            myAppMan = appMan;
        }

        protected internal atDAL.DALManager DAL
        {
            get
            {
                
                return AppMan.DAL;
            }
            set { AppMan.DAL = value; }
        }

      

        protected  int myCurrentFileId;
        public int CurrentFileId
        {
            get { return myCurrentFileId; }
            set { myCurrentFileId = value; }
        }

        private IRuleHandler myRuleHandler;
        public IRuleHandler RuleHandler
        {
            get { return myRuleHandler; }
            set { myRuleHandler = value; }
        }

        private AppManager myAppMan;
        public AppManager AppMan
        {
            get { return myAppMan; }
            set { myAppMan = value; }
        }

        public bool isMerging = false;
        public event WarningEventHandler OnWarning;
        public void RaiseWarning(WarningLevel level, string message, string source)
        {

            if (OnWarning != null)
            {
                WarningEventArgs weg = new WarningEventArgs();
                weg.Message = message;
                weg.Source = source;
                weg.Level = level;
                OnWarning(this, weg);
            }
        }

        protected internal Dictionary<string, ObjectBE> myBEs = new Dictionary<string, ObjectBE>();

        protected internal Dictionary<string, BEManager> myMngrs = new Dictionary<string, BEManager>();

        private DataSet myDS;

        public DataSet MyDS
        {
            get { return myDS; }
            set 
            { 
                myDS = value;
                AppManager.FixTZDSIssue(myDS);
            }
        }


        public virtual void Update(atLogic.BusinessProcess BP)
        {
        }
  
        public void IsValidDate(string label, DateTime dateValue, bool allowNull, DateTime beginDate, DateTime endDate, string beginLabel, string endLabel)
        {

            if (dateValue.GetTypeCode() != System.TypeCode.DateTime && Convert.IsDBNull(dateValue))
                throw new DateException(atLogic.Properties.Resources.NotValidDate, label); // this.RaiseError((int)AppErrorCodes.NotValidDate, label);
            if (Convert.IsDBNull(dateValue) && (!IsEmpty(beginDate.ToString()) || !IsEmpty(endDate.ToString())))
                return;


            if (dateValue < beginDate || dateValue > endDate)
                throw new DateException(atLogic.Properties.Resources.DateMustBeBetween,label,beginLabel,beginDate.ToShortDateString(),endLabel,endDate.ToShortDateString());
                
            if (dateValue < beginDate)
                throw new DateException(atLogic.Properties.Resources.DateMustBeAfter,label, beginLabel, beginDate.ToShortDateString());
            if (dateValue > endDate)
                throw new DateException(atLogic.Properties.Resources.DateMustBeBefore,label, endLabel, endDate.ToShortDateString());
        }

        public void IsWarningDate(string msg, DateTime dateValue, bool allowNull, DateTime beginDate, DateTime endDate)
        {

            if (Convert.IsDBNull(dateValue) && (!IsEmpty(beginDate.ToString()) || !IsEmpty(endDate.ToString())))
                return;


            if (dateValue < beginDate || dateValue > endDate)
                RaiseWarning(WarningLevel.Display, msg, "Warning");
            else if (dateValue < beginDate)
                RaiseWarning(WarningLevel.Display, msg, "Warning");
            else if (dateValue > endDate)
                RaiseWarning(WarningLevel.Display, msg, "Warning");
        }
        public void IsWarningDate(string label, DateTime dateValue, bool allowNull, DateTime beginDate, DateTime endDate, string beginLabel, string endLabel)
        {

            if (dateValue.GetTypeCode() != System.TypeCode.DateTime && Convert.IsDBNull(dateValue))
                throw new DateException(atLogic.Properties.Resources.NotValidDate, label); // this.RaiseError((int)AppErrorCodes.NotValidDate, label);
            if (Convert.IsDBNull(dateValue) && (!IsEmpty(beginDate.ToString()) || !IsEmpty(endDate.ToString())))
                return;


            if (dateValue < beginDate || dateValue > endDate)
                RaiseWarning(WarningLevel.Display,String.Format( atLogic.Properties.Resources.DateShouldBeBetween, label, beginLabel, beginDate.ToShortDateString(), endLabel, endDate.ToShortDateString()),"Warning");
            else if (dateValue < beginDate)
                RaiseWarning(WarningLevel.Display, String.Format(atLogic.Properties.Resources.DateShouldBeAfter, label, beginLabel, beginDate.ToShortDateString()),"Warning");
            else if (dateValue > endDate)
                RaiseWarning(WarningLevel.Display, String.Format(atLogic.Properties.Resources.DateShouldBeBefore, label, endLabel, endDate.ToShortDateString()),"Warning");
        }
        public bool CheckDomain(string val, DataTable domain)
        {
            string id = domain.PrimaryKey[0].ColumnName;
            string sql = "";
            if (domain.Columns.Contains("Obsolete"))
                sql = id + "='" + val + "' and obsolete=false";
            else
                sql=id + "='" + val + "'";

            return domain.Select(sql).Length > 0; 
        }

        public bool CheckDomain(int val, DataTable domain)
        {
            string id = domain.PrimaryKey[0].ColumnName;
            string sql = "";
            if (domain.Columns.Contains("Obsolete"))
                sql = id + "=" + val.ToString() + " and obsolete=false";
            else
                sql=id + "=" + val.ToString() ;

            return domain.Select(sql).Length > 0; 

        }

        public bool IsEmpty(string str)
        {
            if (str == "")
                return true;
            else
                return false;
        }

        public bool IsFieldChanged(DataColumn dc, DataRow dr)
        {
            if (dr.RowState == DataRowState.Detached)
                return false;

            if (dr.HasVersion(DataRowVersion.Proposed))
            {
                if (!dr[dc, DataRowVersion.Current].Equals(dr[dc, DataRowVersion.Proposed]))
                {
                    return true;
                }
                else
                    return false;
            }
            else if (dr.HasVersion(DataRowVersion.Original))
            {
                if (!dr[dc, DataRowVersion.Current].Equals(dr[dc, DataRowVersion.Original]))
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

        public StringBuilder WriteDataTableToCSV( DataTable dt, string header, bool useQuotes)
        {
            StringBuilder sb = new StringBuilder();

            StringWriter sr = new StringWriter(sb);
            WriteCSV(dt, header, useQuotes, sr);
            sr.Close();

            return sb;
        }

        private static void WriteCSV(DataTable dt, string header, bool useQuotes, TextWriter sr)
        {
            if (header.Length != 0)
                sr.WriteLine(header);
            else
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    header += dc.ColumnName + ",";

                }
                sr.WriteLine(header);
            }

            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.Ordinal < dt.Columns.Count - 1)
                    {
                        if (useQuotes)
                            sr.Write(@"""" + dr[dc].ToString() + @""",");
                        else
                            sr.Write(dr[dc].ToString() + ",");
                    }
                    else
                    {
                        if (useQuotes)
                            sr.WriteLine(@"""" + dr[dc].ToString() + @"""");
                        else
                            sr.WriteLine(dr[dc].ToString());
                    }
                }
            }
            
        }

        public void WriteDataTableToCSV(string fullFilePath, DataTable dt, string header, bool useQuotes)
        {
            StreamWriter sr = File.CreateText(fullFilePath);
            WriteCSV(dt,header,useQuotes,sr);
       
            sr.Close();
        }

   
        //public string IfEmptyReturnNull(string qry)
        //{
        //    if (qry == "" || qry == null)
        //        return null;
        //    else
        //    {
        //        string[] str = qry.Split(new char[] { ' ' }, 2);
        //        if (str.Length > 1)
        //        {

        //            if (str[1] == "ascending")
        //                return str[0] + " " + "ASC";
        //            else if (str[1] == "descending")
        //                return str[0] + " " + "DESC";
        //            else
        //                return qry;
        //        }
        //        else
        //            return qry;
        //    }
        //}

        protected ObjectBE GetObjectBE(atDAL.ObjectDAL oDAL,DataTable dt)
        {
            if (dt.ExtendedProperties.ContainsKey("BE"))
                return (ObjectBE) dt.ExtendedProperties["BE"];
            else
            {
                ObjectBE o = new ObjectBE(this, dt);
                if(oDAL!=null)
                    o.myODAL = oDAL;
                return o;
            }
        }
   

        //TimeSpan tsKeepAlive = new TimeSpan(0, 5, 00);
        //protected virtual void pulse_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    //keep the dalmanager alive for remote access
        //    string test;
        //    try
        //    {
        //        test = DAL.User;
        //        System.Diagnostics.Trace.WriteLine(test, "Pulse");
        //    }
        //    catch (Exception x)
        //    {
        //        //dalmng gone - need to get all new dal objects
        //        myDALClient.RecoverDALMngr();
        //    }
            
        //    //check the dal objects
        //    foreach (DALHandle dh in myDALClient.LoadedDals.Values)
        //    {
             

        //        if (DateTime.Now.Subtract(dh.LastAccess) > tsKeepAlive)
        //        {
        //            try
        //            {
        //                test = dh.ODAL.User;
        //                dh.LastAccess = DateTime.Now;
                        
        //                System.Diagnostics.Trace.WriteLine(dh.Name, "KeepAlive");
        //            }
        //            catch (Exception x)
        //            { 
        //                //single dal gone

        //                dh.ODAL =myDALClient.RecoverDAL(dh.Name.Replace("DAL", ""));
        //                 System.Diagnostics.Trace.WriteLine(x.Message); 
        //            }
        //        }
        //    }

        //}

    

        #region IDisposable Members
        private bool isDisposed = false;
        public virtual void Dispose()
        {
            Dispose(true);
            
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {

   
                    foreach (ObjectBE obe in myBEs.Values)
                    {
                        obe.Dispose();
                    }

                    if (myDS != null)
                    {
                        //myDS.Clear();
                        myDS.Dispose();
                    }


                    myBEs.Clear();

                }
            }
            isDisposed = true;
        }

      

        ~BEManager()
        {
            Dispose(false);
        }
        #endregion

        public BusinessProcess GetBP()
        {
            return new BusinessProcess(this);
        }
        public static DataSet GetChanges(DataSet inDs)
        {
            DataSet outDs = inDs.Clone();
            foreach (DataTable dt in inDs.Tables)
            {
                DataTable tmp = dt.GetChanges();
                if (tmp!=null && tmp.ExtendedProperties.ContainsKey("BE"))
                    tmp.ExtendedProperties.Remove("BE");
                if (outDs.Tables[dt.TableName].ExtendedProperties.ContainsKey("BE"))
                    outDs.Tables[dt.TableName].ExtendedProperties.Remove("BE");
                if (tmp != null)
                    outDs.Merge(tmp);
            }
            return outDs;
        }

        public static byte[] CompressData(DataSet ds)
        {

            ds.RemotingFormat = SerializationFormat.Binary;
            return CompressStream(ds);

        }
        //public static byte[] CompressData(DataTable dt)
        //{

        //    dt.RemotingFormat = SerializationFormat.Binary;

        //    return CompressStream(dt);

        //}

        private static byte[] CompressStream(DataSet obj)
        {
            byte[] b;
            BinaryFormatter bf = new BinaryFormatter();

            using (MemoryTributary objStream = new MemoryTributary())
            {
                
                using (System.IO.Compression.DeflateStream objZS = new System.IO.Compression.DeflateStream(objStream, System.IO.Compression.CompressionMode.Compress))
                {
                    //obj.WriteXml(objZS, XmlWriteMode.DiffGram);
                    bf.Serialize(objZS, obj);
              
                };
                b = objStream.ToArray();
            };
            return b;
        }

        public static DataSet DecompressDataSet(byte[] bytDs,DataSet ds)
        {

            using (MemoryTributary inMs = new MemoryTributary(bytDs))
            {
                inMs.Seek(0, 0);

                using (DeflateStream zipStream = new DeflateStream(inMs, CompressionMode.Decompress, true))
                {

                    System.IO.StreamReader sr = new StreamReader(zipStream);
                    ds.ReadXml(sr);
                }
            }

            //string xml = (string)atLogic.BEManager.DecompressStream(bytDs);

            //using (System.IO.StringReader sw = new System.IO.StringReader(xml))
            //{
            //    ds.ReadXml(sw);
            //}
            ds.AcceptChanges();

           
            ds.RemotingFormat = SerializationFormat.Binary;
          
            AppManager.FixTZDSIssue(ds);
            return ds;

        }
        //public static DataSet DecompressDataSet(byte[] bytDs)
        //{

        //    DataSet outDs = new DataSet();
        //    outDs.RemotingFormat = SerializationFormat.Binary;
        //    outDs = (DataSet)DecompressStream(bytDs);
        //    AppManager.FixTZDSIssue(outDs);
        //    return outDs;

        //}

        public static DataTable DecompressDataTable(byte[] bytDs, DataTable dt)
        {

            DataSet ds = new DataSet();
            ds.EnforceConstraints = false;
            ds.Tables.Add(dt.Clone());
            ds=DecompressDataSet(bytDs,ds);
            return ds.Tables[0];

            //DataTable outDs = new DataTable();
            //outDs.DataSet.EnforceConstraints = false;
            //outDs.RemotingFormat = SerializationFormat.Binary;
            //string xml = (string)DecompressStream(bytDs);
            //System.IO.StringReader sr = new StringReader(xml);
            //outDs.ReadXml(sr);
            //sr.Close();
            //return outDs;

        }
        //public static DataTable DecompressDataTable(byte[] bytDs)
        //{


        //    DataTable outDs = new DataTable();
        //    outDs.RemotingFormat = SerializationFormat.Binary;
        //    outDs = (DataTable)DecompressStream(bytDs);
        //    return outDs;

        //}

        //public static object DecompressStream(byte[] bytDs)
        //{
        //    using (MemoryTributary inMs = new MemoryTributary(bytDs))
        //    {
        //        inMs.Seek(0, 0);

        //        using (DeflateStream zipStream = new DeflateStream(inMs, CompressionMode.Decompress, true))
        //        {

        //            System.IO.StreamReader sr = new StreamReader(zipStream);
        //            return sr.ReadToEnd();
        //           // byte[] outByt = ReadFullStream(zipStream);
        //            BinaryFormatter bf = new BinaryFormatter();
                    
        //            return bf.Deserialize(zipStream, null); ;
        //        //    zipStream.Flush();

        //         //   zipStream.Close();

        //            //using (MemoryTributary outMs = new MemoryTributary(outByt))
        //            //{

        //            //    outMs.Seek(0, 0);

        //            //    BinaryFormatter bf = new BinaryFormatter();

        //            //    return bf.Deserialize(outMs, null); ;
        //            //}
        //        }
        //    }
        //}



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

        //public void LogEvent(string eventType, string windowsUser, string lmUser, string workAs, string exType, string exSource, string exMessage, string exStack)
        //{
        //    DAL.LogEvent(eventType, windowsUser, lmUser, workAs, exType, exSource, exMessage, exStack);
        //}

        public virtual void LoadAll(bool refresh)
        {

        }
    }


}
