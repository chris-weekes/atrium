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
    public partial class SAMPageSelector : System.Web.UI.Page
    {


        atriumBE.HelpManager atBEHelp;
        public atriumDAL.atriumDALManager atDal;
        XmlDocument LinkData_filename;
        private string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            string user = ConfigurationManager.AppSettings["DBConnUserName"];
            string pwd = ConfigurationManager.AppSettings["DBConnPassword"];
            atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");
            LinkData_filename = HelpHelper.LoadXmlFile("sidemenu.xml", "", atDal, true);


            XslCompiledTransform xslImages = HelpHelper.LoadXslTransformFile("page_selector.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            StringWriter sw = new StringWriter();
            xslImages.Transform(LinkData_filename, null, sw);
            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;



        }
    }
}