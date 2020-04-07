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

//namespace lmras.DeskbookSAM.english.atrium.content_manager
namespace SSTDeskBooks.english.atrium.content_manager
{
    public partial class SAMImageSelector : System.Web.UI.Page
    {
        string vTreeview;
        string vPreview;
        atriumBE.HelpManager atBEHelp;
        public atriumDAL.atriumDALManager atDal; 
        XmlDocument LinkData_filename;
        private string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["treeview"] != null)
            {
                vTreeview = Request.QueryString["treeview"];
                Response.Cookies["treeview"].Value = vTreeview;

            }
            else
            {
                if (Request.Cookies["treeview"] != null)
                    vTreeview = Request.Cookies["treeview"].Value;
                else
                    vTreeview = "";
            }


            string user = ConfigurationManager.AppSettings["DBConnUserName"];
            string pwd = ConfigurationManager.AppSettings["DBConnPassword"];
            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");
            LinkData_filename = HelpHelper.LoadXmlFile("images.xml","", atDal, true);

            showList("");
            //XslCompiledTransform xslImages = HelpHelper.LoadXslTransformFile("image_selector.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            //StringWriter sw = new StringWriter();
            //xslImages.Transform(LinkData_filename, null, sw);
            //string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            //sw.Close();
            //pgContent.Text = result;
         }

        private void showList(string nodeToHighlight)
        {

            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            if (vTreeview == "false")
            {
                XslCompiledTransform xslImages = HelpHelper.LoadXslTransformFile("image_selector_list.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
                XsltArgumentList xslarg = new XsltArgumentList();

                xslarg.AddParam("highlightNode", "", nodeToHighlight);
                if (vPreview != null)
                    xslarg.AddParam("preview", "", vPreview);

                if (Request.QueryString["pgid"] != null)
                    xslarg.AddParam("pgid", "", Request.QueryString["pgid"]);

                StringWriter sw = new StringWriter();
                xslImages.Transform(LinkData_filename, xslarg, sw);
                string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                sw.Close();
                pgContent.Text = result;
            }
            else
            {
                XslCompiledTransform xslImages = HelpHelper.LoadXslTransformFile("image_selector.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);

                XsltArgumentList xslarg = new XsltArgumentList();
                xslarg.AddParam("highlightNode", "", nodeToHighlight);
                if (Request.QueryString["pgid"] != null)
                    xslarg.AddParam("pgid", "", Request.QueryString["pgid"]);

                StringWriter sw = new StringWriter();
                xslImages.Transform(LinkData_filename, xslarg, sw);
                string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
                sw.Close();
                pgContent.Text = result;
            }
        }
    }
}