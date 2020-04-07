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
    public partial class SAMHelp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle();
            pgContent.Text = "<p>There is currently no help available. Good luck!</p>";
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