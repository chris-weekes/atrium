using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace atLogic
{
    //public class AtriumXCon
    //{
    //    public string Connect;
    //    public string User;
    //    public string Pwd;
    //}
    public class AppManager : IDisposable
    {
        protected string myLanguage = "Eng";
        public string myUser = "";
        public string myPwd = "";
        public string myFWPassword = "";
        public System.Net.CredentialCache cc;
        public DALClient myDALClient;
        public string AtriumXURL = "";
        public bool Compression = false;
        public string Connect = "DATABASE1";
        public bool UseService = false;
        public bool UseProxy = false;
        public bool IsOffline = false;
        public bool AllowOffline = false;
        public string CachePath = "";
        public bool UseTrusted = false;
        protected System.Timers.Timer pulse;

        public string Version
        {
            get
            {
                return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
            }
        }

        public string ProductName
        {
            get
            {
                return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).ProductName;
            }
        }

        public string Title
        {
            get
            {
                return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).InternalName;
            }
        }

        public string Path
        {
            get
            {
                return System.Reflection.Assembly.GetExecutingAssembly().Location;
            }
        }


        public string Language
        {
            get
            {
                return this.myLanguage;
            }
            set
            {
                string tempLang = value.ToUpper();
                switch (tempLang)
                {
                    case "ENG":
                        break;
                    case "FRE":
                        break;
                    default:
                        tempLang = "ENG";
                        break;
                }
                this.myLanguage = tempLang;
            }
        }

        public string languageCamel
        {
            get
            {
                string returnLang = "";
                switch (this.myLanguage.ToUpper())
                {
                    case "FRE":
                        returnLang = "Fre";
                        break;
                    default:
                        returnLang = "Eng";
                        break;
                }
                return returnLang;
            }
        }

        private atDAL.DALManager myDAL;

        protected internal atDAL.DALManager DAL
        {
            get
            {

                return myDAL;
            }
            set { myDAL = value; }
        }
        protected void StartPulse()
        {
            int ticks = 1 * 60 * 1000;  //must be less than the server object timeout of 5 minutes
            pulse = new System.Timers.Timer(ticks);
            // pulse.Elapsed += new System.Timers.ElapsedEventHandler(pulse_Elapsed);
            pulse.Enabled = true;




        }

        AtriumX.AtriumXClient myaxc;
        public AtriumX.AtriumXClient AtriumX()
        {
            if (myaxc == null)
            {
                //  System.Net.ServicePointManager.SecurityProtocol =System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                //            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                //((sender, certificate, chain, sslPolicyErrors) => true);

                AtriumX.AtriumXClient axc = new AtriumX.AtriumXClient();

                if (!UseTrusted)
                {
                    axc.ClientCredentials.UserName.UserName = myUser;
                    axc.ClientCredentials.UserName.Password = myFWPassword;
                }
                else
                {
                    axc.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                }
                if (AtriumXURL.ToLower().StartsWith("https"))
                    axc.Endpoint.Binding = new System.ServiceModel.BasicHttpBinding("secureAtriumX");

                axc.Endpoint.Address = new System.ServiceModel.EndpointAddress(AtriumXURL);
                myaxc = axc;
            }
            return myaxc;
        }

        public AtriumX.AtriumXCon AtriumXCon
        {
            get
            {

                AtriumX.AtriumXCon ax = new AtriumX.AtriumXCon();
                ax.Connect = this.Connect;
                ax.User = myUser;
                ax.Pwd = myPwd;
                return ax;
            }
        }
        protected internal virtual atDAL.DALManager RemoteDAL(string user, string fwPassword)
        {
            return null;
        }

        public string RemoveIllegalChar(string file)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                file = file.Replace(c, '_');
            }
            return file;
        }

        string ParamList(params object[] parameterValues)
        {
            string ret = "";
            foreach (object o in parameterValues)
            {
                ret += "," + o.ToString();
            }
            return ret;
        }

        public void EncryptDTAes(string path, DataTable dt)
        {

            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(path));

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = data;
                aesAlg.IV = data;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (System.IO.FileStream msEncrypt = new System.IO.FileStream(path, System.IO.FileMode.Create))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        dt.WriteXml(csEncrypt, XmlWriteMode.WriteSchema);
                    }
                }
            }


        }
        public void EncryptDSAes(string path, DataSet ds, XmlWriteMode mode)
        {

            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(path));

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = data;
                aesAlg.IV = data;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (System.IO.FileStream msEncrypt = new System.IO.FileStream(path, System.IO.FileMode.Create))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        ds.WriteXml(csEncrypt, mode);
                    }
                }
            }


        }
        public void EncryptStreamAes(string path, System.IO.Stream str)
        {

            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(path));

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = data;
                aesAlg.IV = data;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (System.IO.FileStream msEncrypt = new System.IO.FileStream(path, System.IO.FileMode.Create))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        str.CopyTo(csEncrypt);
                    }
                }
            }


        }
        public byte[] DecryptToByteAes(string path)
        {


            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(path));

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = data;
                aesAlg.IV = data;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (System.IO.FileStream msDecrypt = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            csDecrypt.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }

            }



        }
        public void DecryptDTAes(string path, DataTable dt)
        {


            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(path));

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = data;
                aesAlg.IV = data;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (System.IO.FileStream msDecrypt = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        dt.ReadXml(csDecrypt);
                    }
                }

            }



        }
        public void DecryptDSAes(string path, DataSet ds)
        {


            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(path));

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = data;
                aesAlg.IV = data;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (System.IO.FileStream msDecrypt = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        ds.ReadXml(csDecrypt);
                    }
                }

            }



        }
        public string GetHash(string input)
        {
            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();


        }
        public void CacheDataSet(DataTable dt, string name)
        {

            string path = GetHashFilename(RemoveIllegalChar(name));

            EncryptDTAes(path, dt);
            //dt.WriteXml(path, XmlWriteMode.WriteSchema);

        }



        public string GetHashFilename(string name)
        {
            string path = CachePath + name + ".dat";
            string folder = System.IO.Path.GetDirectoryName(path);
            string file = System.IO.Path.GetFileNameWithoutExtension(path);

            path = folder + "\\" + GetHash(file) + ".dat";
            return path;
        }

        public void CreateMissingFolder(string name)
        {
            string path = CachePath + name;
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
        }
        public void CacheDataSet(DataSet ds, string name)
        {

            CacheDataSet(ds, name, XmlWriteMode.IgnoreSchema);
        }
        public void CacheDataSet(DataSet ds, string name, XmlWriteMode mode)
        {

            string path = GetHashFilename(name);
            // ds.WriteXml(path, mode);
            EncryptDSAes(path, ds, mode);
        }
        public void CacheDataGet(DataTable dt, string name)
        {
            DataTable dt1 = dt.Clone();
            //    dt1.ReadXml(GetHashFilename(RemoveIllegalChar(name)));
            DecryptDTAes(GetHashFilename(RemoveIllegalChar(name)), dt1);
            atLogic.ObjectBE obe = null;
            if (dt.ExtendedProperties.ContainsKey("BE"))
            {
                obe = (ObjectBE)dt.ExtendedProperties["BE"];
                obe.Fill(dt1);
                obe.myDT.AcceptChanges();
            }
            else
            {
                dt.Merge(dt1);
                dt.AcceptChanges();
            }
        }
        public void CacheDataGet(DataSet ds, string name, bool mustExist)
        {
            try
            {
                string path = GetHashFilename(name);
                if (System.IO.File.Exists(path))
                {
                    //ds.ReadXml(path);
                    DecryptDSAes(path, ds);
                    ds.AcceptChanges();
                }
                else
                {
                    if (mustExist)
                        throw new AtriumException(atLogic.Properties.Resources.SyncDataIsNotCached);
                }
            }
            catch (Exception x)
            {
                throw new AtriumException(atLogic.Properties.Resources.SyncYouCanTWorkOffline, x);
            }
        }

        public void CacheSerialize(object toCache, string name)
        {
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(toCache.GetType());
            // To write to a file, create a StreamWriter object.
            using (System.IO.StreamWriter myWriter = new System.IO.StreamWriter(CachePath + RemoveIllegalChar(name) + ".cache"))
            {
                mySerializer.Serialize(myWriter, toCache);
                myWriter.Close();
            }
        }

        public object CacheDeserialize(string fromFile, object fromCache)
        {


            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(fromCache.GetType());
            // To read the file, create a FileStream.
            using (System.IO.FileStream myFileStream = new System.IO.FileStream(CachePath + fromFile + ".cache", System.IO.FileMode.Open))
            {
                // Call the Deserialize method and cast to the object type.
                fromCache = mySerializer.Deserialize(myFileStream);
                myFileStream.Close();
            }

            return fromCache;
        }
        //public void ResetDBConnection(System.Net.NetworkCredential nc)
        //{
        //    try
        //    {
        //        DAL.CreateCon(nc.UserName, nc.Password);
        //    }
        //    catch (System.Runtime.Serialization.SerializationException x)
        //    {
        //        myDALClient.RecoverDALMngr();
        //        DAL.CreateCon(nc.UserName, nc.Password);
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
                    if (pulse != null)
                    {
                        pulse.Enabled = false;
                        pulse.Stop();
                        pulse.Dispose();
                    }


                    myDAL = null;
                    cc = null;




                }
            }
            isDisposed = true;
        }



        ~AppManager()
        {
            Dispose(false);
        }
        #endregion



        //public void ExecuteSP(int timeOut, string spName, params object[] parameterValues)
        //{
        //    this.DAL.ExecuteSP(timeOut, spName, parameterValues);
        //}
        private object[] FixParameters(object[] parameterValues)
        {
            for (int i = 0; i < parameterValues.Length; i++)
            {
                if (parameterValues[i] != null && parameterValues[i] == System.DBNull.Value)
                {
                    parameterValues[i] = "System.DBNull.Value";
                }
            }
            return parameterValues;
        }
        public void ExecuteSP(string spName, params object[] parameterValues)
        {

            if (UseService)
            {
                parameterValues = FixParameters(parameterValues);
                AtriumX().ExecuteSP(AtriumXCon, spName, parameterValues);
            }
            else
                this.DAL.ExecuteSP(spName, parameterValues);
        }

        public DataSet ExecuteDataset(string spName, params  object[] parameterValues)
        {

            DataSet ds = new DataSet();
            if (IsOffline)
            {
                CacheDataGet(ds, spName + ParamList(parameterValues), true);

            }
            else
            {
                if (UseService)
                {
                    parameterValues = FixParameters(parameterValues);
                    ds = BEManager.DecompressDataSet(AtriumX().ExecuteDatasetByte(AtriumXCon, spName, parameterValues), ds);
                }
                else
                    ds = BEManager.DecompressDataSet(this.DAL.ExecuteDatasetByte(spName, parameterValues), ds);
                if (AllowOffline)
                    CacheDataSet(ds, spName + ParamList(parameterValues));
            }
            return ds;
        }

        public DataSet ExecuteDatasetSQL(string spName)
        {
            DataSet ds;
            if (UseService)
            {
                ds = AtriumX().ExecuteDatasetSQL(AtriumXCon, spName);
            }
            else
            {
                ds = DAL.ExecuteDatasetSQL(spName);
            }
            FixTZDSIssue(ds);
            return ds;
        }
        public object ExecuteScalar(string spName, params object[] parameterValues)
        {

            if (UseService)
            {
                parameterValues = FixParameters(parameterValues);
                return AtriumX().ExecuteScalar(AtriumXCon, spName, parameterValues);
            }
            else
                return this.DAL.ExecuteScalar(spName, parameterValues);
        }
        public object ExecuteScalarSQL(string sql)
        {
            if (UseService)
                return AtriumX().ExecuteScalarSQL(AtriumXCon, sql);
            else
                return this.DAL.ExecuteScalarSQL(sql);
        }
        public void ExecuteNonQuery(string query)
        {
            if (UseService)
                AtriumX().ExecuteNonQuery(AtriumXCon, query);
            else
                this.DAL.ExecuteNonQuery(query);
        }

        public static void FixTZDSIssue(DataSet myDS)
        {
            foreach (DataTable table in myDS.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        column.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
            }
        }

    }

   
}
