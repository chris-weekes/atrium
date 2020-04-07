using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using atLogic;

namespace atriumBE
{
    public class AtriumApp:atLogic.AppManager
    {
        public event AlertHandler AlertRaised;


        Proxy myProxy;
        System.Threading.Thread myProxyThread;

     
        atriumManager myAtmng;

        public atriumManager AtMng
        {
            get { return myAtmng; }
            set { myAtmng = value; }
        }

   

        atriumBE.Servers.ServerRow serverInfo;

        public atriumBE.Servers.ServerRow ServerInfo
        {
            get { return serverInfo; }
            set { serverInfo = value; }
        }

        System.Net.NetworkCredential myNC;

        public System.Net.NetworkCredential MyNC
        {
            get { return myNC; }
            set { myNC = value; }
        }


        public string AppMailName
        {
            get { return Properties.Resources.AppMailName; }
        }
        public string AppName
        {
            get { return Properties.Resources.AppName; }
        }
        public string AppOffice
        {
            get { return Properties.Resources.AppOffice; }
        }
        public string AppAdminModule
        {
            get { return Properties.Resources.AppAdminModule; }
        }

        public string ServerName
        {
            get { return ServerInfo.serverName; }

        }

        public bool UsingRemote
        {
            get { return ServerInfo.useRemote; }

        }

        DateTime lastCall = DateTime.Now;
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                if (UseService)
                    return null;
                else
                {
                    try
                    {
                        if (DateTime.Now.AddMinutes(-2) > lastCall)
                        {
                            string test = DAL.User;
                            lastCall = DateTime.Now;
                        }
                        return (atriumDAL.atriumDALManager)DAL;
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        myDALClient.RecoverDALMngr();
                        return (atriumDAL.atriumDALManager)DAL;
                    }
                }
            }
            set { DAL = value; }
        }
        
        public atriumDAL.atriumDALManager DALMngrX
        {
            get { return (atriumDAL.atriumDALManager)DAL; }
        }

 
        public AtriumApp(string language,atriumBE.Servers.ServerRow server)
        {
            //for windows authentication only
            serverInfo = server;

            InitAD(language);

        }

        private void InitAD(string language)
        {
            DateTime start = DateTime.Now;
            AppDomain myDomain = System.Threading.Thread.GetDomain();

            myDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            System.Security.Principal.WindowsPrincipal myPrincipal = (System.Security.Principal.WindowsPrincipal)System.Threading.Thread.CurrentPrincipal;

            string user = myPrincipal.Identity.Name;
            System.Net.NetworkCredential nc = System.Net.CredentialCache.DefaultNetworkCredentials;
            Init(nc, user, language, "", "");

            TimeSpan ts = DateTime.Now.Subtract(start);
            AtMng.LogMessage("Login " + serverInfo.serverName + "("+ ts.ToString() +")");
        }

        public AtriumApp(string user, string password, string language, atriumBE.Servers.ServerRow server, string fwPassword)
        {
            //for prompted authentication only
            serverInfo = server;

            InitSQLAuth(user, password, language, fwPassword);

        }

        private void InitSQLAuth(string user, string password, string language, string fwPassword)
        {
            DateTime start = DateTime.Now;
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential(user, password);
            Init(nc, user, language, password, fwPassword);


            TimeSpan ts = DateTime.Now.Subtract(start);
            AtMng.LogMessage("Login " + serverInfo.serverName + "(" + ts.ToString() + ")");
        }


        public AtriumApp(string user, string password, string language, string db)
        {
            //for service authentication only

            CreateServer(db, false);

            InitSQLAuth(user, password, language, password);

            AtMng.loggedOnAsSystem = true;
            

        }

        public AtriumApp(string language, string db)
        {
            

            CreateServer(db,true);

            InitAD(language);

        }

        private void CreateServer(string db,bool trustedConnection)
        {
            Servers ds = new Servers();
            serverInfo = ds.Server.NewServerRow();
            serverInfo.dbConnect = db;
            serverInfo.serverName = "BATCH";
            serverInfo.trustedConnection = trustedConnection;
            serverInfo.useProxy = false;
            serverInfo.useRemote = false;

            serverInfo.remoteUrl = "";
            serverInfo.ADMSWS = "";
            serverInfo.DeskbookCheatSheet = "";
            serverInfo.DeskbookHomePath = "";
            serverInfo.DeskbookQuickSearchHelpPath = "";
            serverInfo.DeskbookSearchPath = "";
            serverInfo.helpUrl = "";
            serverInfo.proxyUrl = "";
            serverInfo.reportAdminUrl = "";
            serverInfo.reportService = "";
            serverInfo.reportUrl = "";
            serverInfo.whatsnew = "";
            serverInfo.AtriumX = "";
            serverInfo.Compression = true;
            serverInfo.useService = false;
            ds.Server.AddServerRow(serverInfo);
        }
      
    
        private void Init(System.Net.NetworkCredential nc, string user, string language, string pwd,  string fwPassword)
        {

            myNC = nc;

            myUser = user;
            myPwd = pwd;
            myFWPassword = fwPassword;

            AtriumXURL = ServerInfo.AtriumX;
            if (ServerInfo.IsCompressionNull())
                Compression = true;
            else
                Compression = ServerInfo.Compression;

            UseProxy = ServerInfo.useProxy;
            UseService = ServerInfo.useService;
            UseTrusted = serverInfo.trustedConnection;

            Connect = ServerInfo.dbConnect;

            if (language == "FRE")
            {
                atriumBE.Properties.Resources.Culture = new System.Globalization.CultureInfo("fr-CA");

                this.myLanguage = language;
            }

            //WindowsFormsApplicationBase creates a talk-back channel
            if (!UseService)
            {
                if (UsingRemote)
                {

                    //start proxy
                    if (ServerInfo.useProxy)
                        StartProxy(ServerInfo, user, fwPassword);

                    DALMngr = (atriumDAL.atriumDALManager)RemoteDAL(nc.UserName, fwPassword);


                }
                else
                {

                    DALMngr = new atriumDAL.atriumDALManager(nc.UserName, nc.Password, ServerInfo.dbConnect);
                }

                myDALClient = new DALClient(this);
            }
            

            //atSecurity.SecurityApp secApp= new atSecurity.SecurityApp(nc, user, ServerInfo.proxyUrl, ServerInfo.useRemote, ServerInfo.dbConnect, fwPassword);
            //SecurityManager = secApp.SecurityManager;


            AtMng = new atriumManager(this);

            StartPulse();
            pulse.Elapsed += new System.Timers.ElapsedEventHandler(pulse_Elapsed1);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void pulse_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //check for messages
                string alert;
                if (UseService)
                    alert = AtriumX().Alert(AtriumXCon, Language);
                else
                {
                    try
                    {
                        alert = DALMngrX.Alert(Language);

                    }
                    catch (System.Runtime.Serialization.SerializationException sx)
                    {
                        myDALClient.RecoverDALMngr();
                        alert = DALMngrX.Alert(Language);

                    }
                }
                if (alert != null && alert!="")
                {
                    MessageArgs m = new MessageArgs();

                    m.Message = alert;
                    if (AlertRaised != null)
                        AlertRaised(this, m);
                }

                //check for mail
                //replace with bf list refresh mechanism
                //int mail = (int)DALMngr.ExecuteScalar("ActivityBFUnReadMailCount", OfficerLoggedOn.OfficerId);
                //if (mail > 0)
                //{
                //    MessageArgs m1 = new MessageArgs();
                //    m1.Message = String.Format("You have {0} new messages.",mail);
                //    m1.Type = MessageType.Mail;
                //    if (AlertRaised != null)
                //        AlertRaised(this, m1);
                //}
            }
            catch (Exception x)
            {
                //do nothing
            }
        }



        protected override atDAL.DALManager RemoteDAL(string user, string fwPassword)
        {
            System.Runtime.Remoting.Channels.Http.HttpClientChannel hcc = null;
            try
            {

                hcc = RegisterChannel(hcc, user, fwPassword, ServerInfo.proxyUrl);
                object obj = Activator.GetObject(typeof(atriumDAL.atriumDALManager), ServerInfo.proxyUrl + "/RemoteActivationService.rem");
                IDictionary dict = System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties(obj);
                //ObjRef objectReference = RemotingServices.Marshal((System.MarshalByRefObject)obj);
                //Uri objectUri = new Uri(objectReference.URI);
                //set credentials on the proxy object 
                dict["credentials"] = cc;
                dict["preauthenticate"] = true;


                if (System.Runtime.Remoting.RemotingConfiguration.GetRegisteredActivatedClientTypes().Length == 0)
                {
                    System.Runtime.Remoting.RemotingConfiguration.RegisterActivatedClientType(typeof(atriumDAL.atriumDALManager), ServerInfo.proxyUrl);
                    //get instance of your object 
                }
                atriumDAL.atriumDALManager atDALMngr = new atriumDAL.atriumDALManager(myNC.UserName, myNC.Password, ServerInfo.dbConnect);

                //object[] url ={ new System.Runtime.Remoting.Activation.UrlAttribute(remoteServer) };
                //DALMngr = (atriumDAL.atriumDALManager)Activator.CreateInstance(typeof(atriumDAL.atriumDALManager), BindingFlags.ExactBinding , url,nc.UserName,nc.Password);

                //get channel sink object for your object and set credentials on that 
                dict = System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties(atDALMngr);
                dict["credentials"] = cc;


                //ObjRef rem= RemotingServices.GetObjRefForProxy(atDALMngr);

                return atDALMngr;
            }
            catch (System.Reflection.TargetInvocationException tex)
            {
                if (tex.InnerException != null)
                    throw tex.InnerException;
                else
                    throw tex;
            }
            catch (Exception xRemote)
            {

                ChannelServices.UnregisterChannel(hcc);

                throw;
            }

        }
        internal atriumDAL.DirectHelper RemoteHelper()
        {
            System.Runtime.Remoting.Channels.Http.HttpClientChannel hcc = null;
            try
            {
                hcc = RegisterChannel(hcc, myNC.UserName, myNC.Password, ServerInfo.remoteUrl);
                object obj = Activator.GetObject(typeof(atriumDAL.DirectHelper), ServerInfo.remoteUrl + "/RemoteActivationService.rem");
                IDictionary dict = System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties(obj);
                //set credentials on the proxy object 
                dict["credentials"] = cc;

                if (System.Runtime.Remoting.RemotingConfiguration.GetRegisteredActivatedClientTypes().Length == 0)
                {
                    System.Runtime.Remoting.RemotingConfiguration.RegisterActivatedClientType(typeof(atriumDAL.DirectHelper), ServerInfo.remoteUrl);
                    //get instance of your object 
                }
                atriumDAL.DirectHelper helper = new atriumDAL.DirectHelper(myNC.UserName, myNC.Password, ServerInfo.dbConnect);

                //object[] url ={ new System.Runtime.Remoting.Activation.UrlAttribute(remoteServer) };
                //DALMngr = (atriumDAL.atriumDALManager)Activator.CreateInstance(typeof(atriumDAL.atriumDALManager), BindingFlags.ExactBinding , url,nc.UserName,nc.Password);

                //get channel sink object for your object and set credentials on that 
                dict = System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties(helper);
                dict["credentials"] = cc;

                return helper;
            }
            catch (Exception xRemote)
            {

                ChannelServices.UnregisterChannel(hcc);

                throw;
            }

        }

        private System.Runtime.Remoting.Channels.Http.HttpClientChannel RegisterChannel(System.Runtime.Remoting.Channels.Http.HttpClientChannel hcc, string user, string fwPassword, string serverUrl)
        {
            if (ChannelServices.GetChannel("atrium" + user) == null)
            {
                System.Collections.Hashtable props = new System.Collections.Hashtable();

                props["port"] = 0;
                props["name"] = "atrium" + user;
                props["timeout"] = 300000;
                props["useDefaultCredentials"] = true;  //must be true to pass through authenticating firewalls

                //props["useAuthenticatedConnectionSharing"] = true;

                //props["proxyName"] = "lawmate.secure";
                //props["proxyPort"] = 80;

                hcc = new System.Runtime.Remoting.Channels.Http.HttpClientChannel(props, new BinaryClientFormatterSinkProvider());

                ChannelServices.RegisterChannel(hcc, true);
            }
            System.Uri u = new Uri(serverUrl);
            cc = new System.Net.CredentialCache();

            //set global default credentials - see CRA version
            System.Net.WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            
            
            if (user == "")
                cc.Add(u, "Negotiate", myNC);
            else
            {
                cc.Add(u, "Basic", new System.Net.NetworkCredential(user, fwPassword));
                cc.Add(u, "Digest", new System.Net.NetworkCredential(user, fwPassword));
            }
            //System.Net.HttpWebRequest wc = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(u);
            //wc.CookieContainer = new System.Net.CookieContainer();

            //wc.Credentials = cc;

            //System.Net.HttpWebResponse hw = (System.Net.HttpWebResponse)wc.GetResponse();

            return hcc;
        }

        private void StartProxy(Servers.ServerRow server, string user, string fwpwd)
        {

            ProxyConfig pxc = new ProxyConfig();
            pxc.serverR = server;
            pxc.user = user;
            pxc.password = fwpwd;

            myProxy = new Proxy(pxc);

            myProxyThread = new System.Threading.Thread(myProxy.Start);

            myProxyThread.Start();


        }

        //public void Commit()
        //{
        //    this.DALMngr.Commit();
         

        //}
      

        //public void Rollback()
        //{
        //    DALMngr.Rollback();
          

        //}

        public string TempPath
        {
            get { return System.IO.Path.GetTempPath() + @"Atrium\"; }
        }

        public string LawMatePath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Atrium\";

            }
        }

        #region IDisposable Members

        public void Dispose()
        {
           
            pulse.Stop();

           
            if(!UseService)
                DALMngr.CloseCon();

            if (myProxyThread != null)
            {
                myProxy.Stop();

                myProxyThread.Abort();
            }

            if(!UseService)
                DALMngr = null;


        }

        #endregion

    }
}
