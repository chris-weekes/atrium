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
    public partial class SAM : System.Web.UI.MasterPage
    {
        public string bodyScript;
        public string PgId;

          private string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();
        
        
        private string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
        private string DESKBOOK_CONTENT_MANAGER_PAGES = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_CONTENT_MANAGER_PAGES"].ToString();
        public XmlNode pageElement;
        XmlDocument xmlMenu;
        XmlDocument xmlPagesAdmin;
        bool blnFileExists;

        atriumDAL.atriumDALManager atDal;

        protected void Page_Load(object sender, EventArgs e)
        {
            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");
            if (Login.GlobalServer != null)
            {
                urlLogOn.Text = "You are logged on."; 
                urlLogOn.NavigateUrl = "#";
            }
            else
            {
                urlLogOn.Text = "User not authenticated";
                urlLogOn.NavigateUrl = "#";

            }
            //if ((bool)Application["DevSite"] == false)
            //{
            //    Response.Redirect(ENGLISH_PATH_ROOT + "?adminredir=Y");
            //}

            string vQS = Request.QueryString["pgid"];
            if (vQS == null)
                PgId = "1999";
            else
                PgId = vQS;
            css1.Text = "<link rel=\"stylesheet\" href=\"../../../wet20/grids/css/grid-small.css\" media=\"screen\" type=\"text/css\" id=\"grid-framework\" />";
    
            xmlMenu = HelpHelper.LoadXmlFile("side-menu-admin.xml", "", atDal,true);
            pgMenuXml.Text = HelpHelper.DoMenu("eng", xmlMenu, PgId, atDal);



        }
    }
}