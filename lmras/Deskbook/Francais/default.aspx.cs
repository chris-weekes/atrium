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

namespace lmras.Deskbook.Francais
{
    public partial class _default : System.Web.UI.Page
    {
        string PgId;
        bool isANode;
        bool isALeaf;
        public string pgTitle { get; set; }
        string dcDesc;
        string dcSubject;
        string dcKeywords;
        string otherLangURL;
        string pageLocalCSS;
        public XmlNode pageElement;
        XmlDocument xmlMenu;
        atriumDAL.atriumDALManager atDal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["serverName"] == null)
                Application["serverName"] = Request.ServerVariables["HTTP_HOST"];

            string vQS = Request.QueryString["pgid"];
            if (vQS == null)
                PgId = "1";
            else
                PgId = vQS;

            //make sure the id is an int - stops SQL injection
            int id;
            if (!int.TryParse(PgId, out id))
                Response.Redirect("404.html", true); //redirect to friendly 404?

            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");
            XmlDocument xmlPages = HelpHelper.LoadXmlFile("pages.xml", atDal);
            xmlMenu = HelpHelper.LoadXmlFile("sidemenu.xml", atDal);
            XmlNode xn = xmlPages.SelectSingleNode("pages/page[@id='" + PgId + "']");
            if (xn == null)
                Response.Redirect("404.html", true); //redirect to friendly 404?

            pageElement = xn;
            dcSubject = (pageElement.Attributes["dcSubjectFre"] != null) ? pageElement.Attributes["dcSubjectFre"].Value : "";
            dcDesc = (pageElement.Attributes["dcDescriptionFre"] != null) ? pageElement.Attributes["dcDescriptionFre"].Value : "";
            dcKeywords = (pageElement.Attributes["keywordsFre"] != null) ? pageElement.Attributes["keywordsFre"].Value : "";
            pageLocalCSS = (pageElement.Attributes["pgCSS"] != null) ? pageElement.Attributes["pgCSS"].Value : "";

            isANode = pageElement.Attributes["type"].Value == "node";
            isALeaf = pageElement.Attributes["type"].Value == "leaf";
            pgTitle = pageElement.Attributes["fre"].Value;
            otherLangURL = HelpHelper.OtherLangUrl(false, Request.ServerVariables["URL"], Request.ServerVariables["QUERY_STRING"]);

            DoPathResolves();
            DoPageContent();
            pgBcXml.Text = HelpHelper.DoBreadcrumb(atDal, xmlMenu, PgId, "fre");
            pgMenuXml.Text = HelpHelper.DoMenu("fre", xmlMenu, PgId, atDal);
        }

        private void DoPathResolves()
        {
            favIcon.Text = "<link rel=\"shortcut icon\" href=\"../wet20/favicon.ico\"/>";
            fdcTitle.Text = "<meta name=\"dc.title\" content=\"" + Application["serverName"] + "\" />";
            fdcDescription.Text = "<meta name=\"dc.description\" content=\"" + dcDesc + "\" />";
            fdcSubject.Text = "<meta name=\"dc.subject\" title=\"" + dcSubject + "\" content=\"\" /> ";
            fkeywords.Text = "<meta name=\"keywords\" content=\"" + dcKeywords + "\" />";
            css1.Text = "<link rel=\"stylesheet\" href=\"../wet20/grids/css/grid-small.css\" media=\"screen\" type=\"text/css\" id=\"grid-framework\" />";
            lclCSS.Text = "<style type=\"text/css\">" + pageLocalCSS + "</style>";
            h1PgTitle.Text = pgTitle;
            fLang.Text = "<a href=\"" + otherLangURL + "\" lang=\"en\">English</a>";
            AppNameFre.Text = ConfigurationManager.AppSettings["OwnerFre"];
        }

        private void DoPageContent()
        {
            if (isANode)
            {
                XmlNode menuItem = xmlMenu.SelectSingleNode("//item[@pgid='" + PgId + "']");
                XslCompiledTransform xslBreadcrumb = HelpHelper.LoadXslTransformFile("displayfirstchild.xsl", atDal);

                XsltArgumentList xslarg = new XsltArgumentList();
                xslarg.AddParam("server", "", "");
                xslarg.AddParam("lang", "", "fre");

                StringWriter sw = new StringWriter();
                xslBreadcrumb.Transform(menuItem, xslarg, sw);

                string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                sw.Close();

                pgContent.Text = result;

            }
            else if (isALeaf)
            {
                lmDatasets.HelpDB.hlpPageRow pgRow = HelpHelper.RetrievePageContent(pageElement.Attributes["path"].Value, "fre", atDal);
                if (pgRow != null)
                {
                    if (pgRow.IsContentsNull())
                    {
                        pgContent.Text = "<p>No Page Content cound be found for this page. Please contact an administrator. HelpPageRow Contents is null</p>";
                        lbLastMod.Text = "";
                        txtFileDate.Text = "";
                    }
                    else
                    {
                        pgContent.Text = pgRow.Contents;
                        lbLastMod.Text = "Dernière modification :";
                        txtFileDate.Text = pgRow.updateDate.ToString("yyyy/MM/dd");
                    }
                }
                else
                {
                    pgContent.Text = "No Page Content cound be found for this page. Please contact an administrator. No Help Page Row returned.";
                    lbLastMod.Text = "";
                    txtFileDate.Text = "";
                }
            }
            else
            {
                string content = "Leaf-Section not yet implemented. Please change the Leaf Type.";
                pgContent.Text = content;
                lbLastMod.Text = "";
                txtFileDate.Text = "";
            }
        }

    }
}