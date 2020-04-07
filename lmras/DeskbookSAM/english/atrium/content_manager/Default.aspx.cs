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
    public partial class Default : System.Web.UI.Page
    {
        string PgId;
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
            string vQS = Request.QueryString["pgid"];
            if (vQS == null)
                PgId = "1999";
            else
                PgId = vQS;
            DoPageContent();
        }
        
        private void DoPageContent()
        {
            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");

            xmlPagesAdmin = HelpHelper.LoadXmlFile("pagesAdmin.xml", "", atDal, true);
            XmlNode pageNode = xmlPagesAdmin.SelectSingleNode("pages/page[@id='" + PgId + "']");
            if (pageNode == null)
            {
                Response.Redirect(HttpContext.Current.Server.MapPath("~") + "404.aspx", true);
            }
            pageElement = pageNode;

          
            Literal literalTitle;
            literalTitle = (Literal)Master.FindControl("h1PgTitle");
            if (literalTitle != null)
            {
                literalTitle.Text = pageElement.Attributes["eng"].Value;
            }
           

            //string vPath;
            //vPath = HttpContext.Current.Server.MapPath("~") + DESKBOOK_CONTENT_MANAGER_PAGES + pageElement.Attributes["path"].Value;
            
                switch (PgId)
                {
                    case "1999":
                        Response.Redirect("Login.aspx");
                        break;
                    case "3000": //Site structure and content
                        Response.Redirect("SAMStructure.aspx?pgid=3000");
                        break;
                    case "3001":
                        Response.Redirect("SAMStructure.aspx?pgid=3000&new=Y");
                        break;
                    case "3003":
                        Response.Redirect("SAMImages.aspx?pgid=3003");
                        break;
                    case "3004":
                        Response.Redirect("SAMFileUpload.aspx");
                        break;
                    case "3005":
                        Response.Redirect("SAMStylesheet.aspx?pgid=3005");
                        break;

                    case "3006":
                        Response.Redirect("SAMHelp.aspx?pgid=3006");
                        break;
                    case "3007":
                        Response.Redirect("SAMAcronyms.aspx");
                        break;
                    case "3008":
                        Response.Redirect("SAMAcronyms.aspx?pgid=3007&insert=new");
                        break;

                    case "3009": //Directory
                        Response.Redirect("SAMDirectory.aspx?pgid=3009");
                        break;
                    case "3010": //Directory
                        Response.Redirect("SAMDirectory.aspx?pgid=3009&insert=new");
                        break;
                    case "3014":  
                          Response.Redirect("SAMStructure.aspx?pgid=3000&new=Y&orphan=Y");
                        break;
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