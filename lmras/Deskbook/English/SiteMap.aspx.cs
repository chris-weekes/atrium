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

namespace lmras.Deskbook.English
{
    public partial class _SiteMap : System.Web.UI.Page
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

            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");
            XmlDocument xmlPages = HelpHelper.LoadXmlFile("pages.xml", atDal);
            xmlMenu = HelpHelper.LoadXmlFile("sidemenu.xml", atDal);
            XmlNode xn = xmlPages.SelectSingleNode("pages/page[@id='" + PgId + "']");
            if (xn == null)
                Response.Redirect("404.html", true); //redirect to friendly 404?

            pageElement = xn;
            dcSubject = (pageElement.Attributes["dcSubjectEng"] != null) ? pageElement.Attributes["dcSubjectEng"].Value : "";
            dcDesc = (pageElement.Attributes["dcDescriptionEng"] != null) ? pageElement.Attributes["dcDescriptionEng"].Value : "";
            dcKeywords = (pageElement.Attributes["keywordsEng"] != null) ? pageElement.Attributes["keywordsEng"].Value : "";
            pageLocalCSS = (pageElement.Attributes["pgCSS"] != null) ? pageElement.Attributes["pgCSS"].Value : "";

            isANode = pageElement.Attributes["type"].Value == "node";
            isALeaf = pageElement.Attributes["type"].Value == "leaf";
            pgTitle = pageElement.Attributes["eng"].Value;
            otherLangURL = HelpHelper.OtherLangUrl(true, Request.ServerVariables["URL"], Request.ServerVariables["QUERY_STRING"]);

            DoPathResolves();
            XmlDocument LinkData_filename = HelpHelper.LoadXmlFile2("sidemenu.xml", "", atDal, true);
            showList("", LinkData_filename);
            //DoPageContent();
            //pgBcXml.Text = HelpHelper.DoBreadcrumb(atDal, xmlMenu, PgId, "eng");
            //pgMenuXml.Text = HelpHelper.DoMenu("eng", xmlMenu, PgId, atDal);
        }

        private void showList(string nodeToHighlight, XmlDocument LinkData_filename)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            string id = (string)Request.QueryString["pgid"];
            XslCompiledTransform xslStructure = HelpHelper.LoadXslTransformFile2("deskbook_manual_select.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            if (id != null)
                xslarg.AddParam("pgid", "", id);

            if (nodeToHighlight != null)
                xslarg.AddParam("nodeToHighlight", "", nodeToHighlight);

            StringWriter sw = new StringWriter();
            xslStructure.Transform(LinkData_filename, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
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
            fLang.Text = "<a href=\"" + otherLangURL + "\" lang=\"fr\">Fran&ccedil;ais</a>";
        }



        private void DoPageContent()
        {
            if (isANode)
            {
                XmlNode menuItem = xmlMenu.SelectSingleNode("//item[@pgid='" + PgId + "']");
                XslCompiledTransform xslBreadcrumb = HelpHelper.LoadXslTransformFile("displayfirstchild.xsl", atDal);

                XsltArgumentList xslarg = new XsltArgumentList();
                xslarg.AddParam("server", "", "");
                xslarg.AddParam("lang", "", "eng");

                StringWriter sw = new StringWriter();
                xslBreadcrumb.Transform(menuItem, xslarg, sw);

                string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                sw.Close();

                pgContent.Text = result;
            }
            else if (isALeaf)
            {
                lmDatasets.HelpDB.hlpPageRow pgRow = HelpHelper.RetrievePageContent(pageElement.Attributes["path"].Value, "eng", atDal);
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
                        lbLastMod.Text = "Last updated:";
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