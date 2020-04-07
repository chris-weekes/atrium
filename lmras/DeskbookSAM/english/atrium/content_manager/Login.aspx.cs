using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using System.Configuration;


namespace SSTDeskBooks.english.atrium.content_manager
{
    public partial class Login : System.Web.UI.Page
    {
        atriumBE.HelpManager atBEHelp; 
        string SAMUser;
        public static atriumBE.Servers.ServerRow GlobalServer;
        protected void Page_Load(object sender, EventArgs e)
        {

            SetPageTitle();
            
            atriumBE.Servers servers = new atriumBE.Servers();
            servers.ReadXml(HttpContext.Current.Server.MapPath("~") + "\\serverlist.xml");
            string sName = servers.Server[0].serverName;
            GlobalServer = servers.Server.FindByserverName(sName);
            atriumBE.AtriumApp appMan = Global.Login();
            atriumDAL.atriumDALManager atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");
            atBEHelp = appMan.AtMng.HelpMng();
            SAMUser = appMan.AtMng.OfficerLoggedOn.UserName;
            if (GlobalServer != null)
                pgContent.Text = "<p>Welcome, you, " + SAMUser + ", are authenticated.</p> <p>Use the left-side menu to navigate through the Site Administration Module.</p>";
            else
            {
                pgContent.Text = "<p>OOPS! You are not allow to use Atrium Deskbook. Please contact an administrator.</p>";
                Response.Redirect(HttpContext.Current.Server.MapPath("~") + "404.aspx", true);
            }
        }

        private void SetPageTitle()
        {
            string PgId;
            string vQS = Request.QueryString["pgid"];
            if (vQS == null)
                PgId = "1999";
            else
                PgId = vQS;
            Literal h1PgTitle;
            h1PgTitle = (Literal)Master.FindControl("h1PgTitle");
            XmlDocument xmlPagesAdmin;
            atriumDAL.atriumDALManager atDal;
            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");
            
            xmlPagesAdmin = HelpHelper.LoadXmlFile("pagesAdmin.xml", "", atDal,true);
            XmlNode pageNode = xmlPagesAdmin.SelectSingleNode("pages/page[@id='" + PgId + "']");
            if (pageNode == null)
            {
                Response.Redirect(HttpContext.Current.Server.MapPath("~") + "404.aspx", true);
            }
            if (h1PgTitle != null)
            {
                h1PgTitle.Text = pageNode.Attributes["eng"].Value;
            }
        }
    }
}