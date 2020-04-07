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
    public partial class SAMAcronyms : System.Web.UI.Page
    {
        atriumDAL.atriumDALManager atDal;
        atriumBE.HelpManager atBEHelp;
        private string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();
        



        private string setSort(string cookieName)
        {
            string sortQS;
            if (Request.QueryString["sort"] != null)
            {
                sortQS = Request.QueryString["sort"];
                Response.Cookies[cookieName].Value = sortQS;
            }
            else
            {
                if (Response.Cookies[cookieName] != null)
                    sortQS = Response.Cookies[cookieName].Value;
                else
                    sortQS = "";
            }


            return sortQS;
        
        }
             

        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle();

            string sortQS = setSort("acronymSort");
            atriumBE.AtriumApp appMan = Global.Login();
            atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");
            atBEHelp = appMan.AtMng.HelpMng();
            XmlDocument LinkData_filename = HelpHelper.LoadXmlFile("acronyms.xml", "", atDal, true);
            string id;
            if (!IsPostBack)//GET
            {
                id = (string)Request.QueryString["id"];
                if (id == null)
                {
                    if (Request.QueryString["insert"] == "new")
                    {
                        // get the next id value from the XML file
                        XmlNode N = LinkData_filename.SelectSingleNode("acronyms/nextid");
                        // set the id to that value
                        int result;
                        result = Convert.ToInt32(N.InnerXml) + 1;

                        N.InnerXml = result.ToString();
                        id = "s" + (string)result.ToString();

                        //string file = HttpContext.Current.Server.MapPath("~") + XML_PATH_COMMON + "acronyms.xml";
                        //LinkData_filename.Save(@file);
                        HelpHelper.SaveXmlFile("acronyms.xml", LinkData_filename, atBEHelp, true);

                        XmlDocument blankXML = new XmlDocument();
                        blankXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><acronyms><acronym id='" + id + "' english='' french='' desc_e='' desc_f='' letter_e='' letter_f='' quicklist=''/></acronyms>");//("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><directory><staff id='" + id + "' f_name='' l_name='' inc='' status='' group='' position_e='' position_f='' phone_area_code='' phone_3='' phone_4='' intercom='' cell_area_code='' cell_3='' cell_4='' craUserName='' email='' dojEmail='' assistant_id='' team_e='' team_f='' acrnm_e='' acrnm_f='' updated='' hidden='' isAssistant='' isDLSUCoach='' notes='' EfilerAccess='' isDLSUPublisher='' isProjectMember='' hasPaperlessDummyAccount='' quicklawAccount='' location=''/></directory>");
                        // show the blank edit form
                        showEditForm(id, blankXML);
                    }
                    else
                    {
                        showList(sortQS, LinkData_filename);
                    }

                }
                else 
                {
                    showEditForm(Request.QueryString["id"], LinkData_filename);
                }
            }
            else //POST
            {   
                XmlNode N; 
                id = (string)Request.QueryString["id"];
                string btnAction = (string)Request.Form["btnAction"];
                switch (btnAction)
                {
                    case "Delete":
                     // set N = xml.selectSingleNode("acronyms/acronym[@id='" & Request.QueryString("id") & "']")
                        N = LinkData_filename.SelectSingleNode("acronyms/acronym[@id='" + (string)Request.Form["id"] + "']");
                        if (N != null)
                        {
                            XmlNode root = LinkData_filename.DocumentElement;
                            root.RemoveChild(N);
                        }
                        HelpHelper.SaveXmlFile("acronyms.xml", LinkData_filename, atBEHelp, true);
                        showList(sortQS, LinkData_filename);
                    break;
                    case "Save":
                        N = LinkData_filename.SelectSingleNode("acronyms/acronym[@id='" + (string)Request.Form["id"] + "']");
                        if (N != null)
                        { 
                         

                            N.Attributes["english"].Value =Request.Form["english"];
		                    N.Attributes["french"].Value = Request.Form["french"];
		                    N.Attributes["desc_e"].Value = Request.Form["desc_e"];
		                    N.Attributes["desc_f"].Value = Request.Form["desc_f"];
		                    N.Attributes["letter_e"].Value = Request.Form["letter_e"];
		                    N.Attributes["letter_f"].Value = Request.Form["letter_f"];
		                    N.Attributes["quicklist"].Value = Request.Form["quicklist"];
		                    N.Attributes["updated"].Value = "1";
                            N.Attributes["updateType"].Value = "UPDATED";
                            HelpHelper.SaveXmlFile("acronyms.xml", LinkData_filename, atBEHelp, true);

                        }
                        else 
                        {//create a new node
                            
                            XmlElement E =  LinkData_filename.CreateElement("acronym");
                            E.SetAttribute("id", (string)Request.Form["id"]);
                            E.SetAttribute("english", Request.Form["english"]);
                            E.SetAttribute("french", Request.Form["french"]);
                            E.SetAttribute("desc_e", Request.Form["desc_e"]);

                            E.SetAttribute("desc_f", Request.Form["desc_f"]);
                            E.SetAttribute("letter_e", Request.Form["letter_e"]);
                            E.SetAttribute("letter_f", Request.Form["letter_f"]);
                            E.SetAttribute("quicklist", Request.Form["quicklist"]);
                            E.SetAttribute("updated", "1");
                            E.SetAttribute("updateType", "NEW");
                        
                            LinkData_filename.DocumentElement.AppendChild(E);//.documentElement.appendChild N
                            HelpHelper.SaveXmlFile("acronyms.xml", LinkData_filename, atBEHelp, true);

                        }
                        showList(sortQS, LinkData_filename);

                    break;
                    case "Cancel":
                        showList(sortQS, LinkData_filename);
                    break;

                }
            }
        }

        private void showEditForm(string id, XmlDocument xmldoc)
        {

            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslDirectory = HelpHelper.LoadXslTransformFile("acronyms_edit.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();


            if (id != null)
                xslarg.AddParam("id", "", id);
            StringWriter sw = new StringWriter();
            xslDirectory.Transform(xmldoc, xslarg, sw);
            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
        
        } 

        private void showList(string vSort, XmlDocument LinkData_filename)
        {

            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslDirectory = HelpHelper.LoadXslTransformFile("acronyms_select.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            if (vSort != null)
                xslarg.AddParam("sort", "", vSort);
            StringWriter sw = new StringWriter();
            xslDirectory.Transform(LinkData_filename, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
        
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
            
            xmlPagesAdmin = HelpHelper.LoadXmlFile("pagesAdmin.xml", "", atDal, true);
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