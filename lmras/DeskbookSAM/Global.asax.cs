using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Collections;
using System.Collections.Specialized;
using lmDatasets;
using atriumBE;


namespace SSTDeskBooks
{
    public class Global : System.Web.HttpApplication
    {
        public string vsite;
        public string sEng;
        public string sFre;
        public ArrayList urlarray = new ArrayList();
        public NameValueCollection coll;
        public string sRootPath1;
        public string sadeDevServer = "sst-tss-i.sade-edap.prv";
        public string serverName;
        public string RemoteUser;

        public   atriumBE.Servers.ServerRow GlobalServer;

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
        
        public static atriumBE.AtriumApp Login()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["UseDBAuthentication"].ToString() == "true")
                return new atriumBE.AtriumApp(System.Configuration.ConfigurationManager.AppSettings["SQLUserNameForWorkflow"], System.Configuration.ConfigurationManager.AppSettings["SQLPasswordForWorfklow"], "ENG", "DATABASE1");
            else
                return new atriumBE.AtriumApp("ENG", "DATABASE1");
            //return Login;
        }

        public static string AppPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        void Session_Start(object sender, EventArgs e)
        {

            
            Session.Timeout = 240;
            vsite="atrium";
            sEng="english";
            sFre="francais";
          
            atriumBE.Servers servers = new atriumBE.Servers();
            servers.ReadXml(HttpContext.Current.Server.MapPath("~") + "\\serverlist.xml");
            string sName = servers.Server[0].serverName;
            GlobalServer = servers.Server.FindByserverName(sName);
            

            serverName=HttpContext.Current.Request.ServerVariables["SERVER_NAME"];  // lcase(request.ServerVariables("SERVER_NAME")) 
            
            if  (Application["DevSite"] == null )
            {
                switch(serverName)
                {
                    case "localhost":
                    case "sst-tss-i.sade-edap.prv": 
                    case "127.0.0.1": 
                        Application["DevSite"]=true;
                        break;
                    default:
                        Application["DevSite"]=false;
                        break;
                }
            
            }
            
            //Authenticate user if Development site
            string [] arrayUser;
            string DLSUUser;
            if (Application["DevSite"] != null && Session["isSiteAdmin"] == null)
            {
                RemoteUser = Request.ServerVariables["REMOTE_USER"];
                if (RemoteUser != "")
                {
                    arrayUser = RemoteUser.Split("\\".ToCharArray());
                    DLSUUser = arrayUser[1].ToLower();
                    switch (DLSUUser)
                    {
                        case "peterphong.ho":
                            Session["isSiteAdmin"] = true;
                            break;
                        default:
                            Session["isSiteAdmin"] = false;
                            break;
                    }
                    Session["DLSUUser"] = DLSUUser;
                }
                else
                {
                    HttpContext.Current.Response.Write("DevSite is not configured to use Windows Authentication. Please contact a System Administrator.");
                }
            }

          //peter   vserver = serverName;
            // Code that runs when a new session is started
            Session["iSamAuthenticated"] =  "Peter Phong";
            Session["isSiteAdmin"] =   "Test";     

     //   If Session("Authenticated") Is Nothing Then
        //    Response.Redirect("default.aspx")
        //End If

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
