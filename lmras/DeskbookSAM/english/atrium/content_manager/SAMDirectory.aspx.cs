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
    public partial class SAMDirectory : System.Web.UI.Page
    {
        atriumDAL.atriumDALManager atDal;
        atriumBE.HelpManager atBEHelp;
      

        private string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();
        
        private string sortQS;
         
        protected void Page_Load(object sender, EventArgs e)
        {

            SetPageTitle();
            atriumBE.AtriumApp appMan = Global.Login();
            atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");
            atBEHelp = appMan.AtMng.HelpMng();


            XmlDocument  LinkData_filename = HelpHelper.LoadXmlFile("directory.xml", "", atDal, true);
            sortQS = (string)Request.QueryString["sort"];
            string id;

            if (!IsPostBack)
            {
                id = (string)Request.QueryString["id"];
                if (id == null)
                {
                    //if request.querystring("insert")="new" then
                    string newQS = (string) Request.QueryString["insert"];
                    if (newQS == "new")
                    {
                        XmlNode node = LinkData_filename.SelectSingleNode("directory/nextid");
                        // update the nextid value in the XML file
                        int result;
                        result = Convert.ToInt32(node.InnerXml) + 1;
                        node.InnerXml = result.ToString();
                        id = "s" + (string) result.ToString();
                        
                        // Peter: probably missing a Save statement here
                         // peter LinkData_filename.Save(@file);
                        HelpHelper.SaveXmlFile("directory.xml", LinkData_filename, atBEHelp, true);


                        XmlDocument blankXML = new XmlDocument();
                        blankXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><directory><staff id='" + id + "' f_name='' l_name='' inc='' status='' group='' position_e='' position_f='' phone_area_code='' phone_3='' phone_4='' intercom='' cell_area_code='' cell_3='' cell_4='' craUserName='' email='' dojEmail='' assistant_id='' team_e='' team_f='' acrnm_e='' acrnm_f='' updated='' hidden='' isAssistant='' isDLSUCoach='' notes='' EfilerAccess='' isDLSUPublisher='' isProjectMember='' hasPaperlessDummyAccount='' quicklawAccount='' location=''/></directory>");
                        showEditForm(id, blankXML);
   

                    }
                    else
                    {
                        showList(   LinkData_filename);
                    }
                   
                }
                else 
                {
                    // display form
                    showEditForm(id,   LinkData_filename);
                }
            }
            else //POST
            {
                FormNotify(LinkData_filename);
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

        private void showList(XmlDocument LinkData_filename)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslDirectory = HelpHelper.LoadXslTransformFile("directoryEditSelect.xsl", DESKBOOK_SAM_PATH_XSL, atDal,false);


            XsltArgumentList xslarg = new XsltArgumentList();
            if (sortQS != null)
                    xslarg.AddParam("sort", "", sortQS);
            StringWriter sw = new StringWriter();
            xslDirectory.Transform(LinkData_filename, xslarg, sw); 

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
        
        }

        private void FormNotify(XmlDocument xml)
        {
            string id = (string)Request.Form["id"];
            string btnAction = (string)Request.Form["btnAction"];
            switch (btnAction)
            {
                case "Save":
                    XmlNode node = xml.SelectSingleNode("directory/staff[@id='" + (string)Request.Form["id"] + "']");
                    if (node != null)
                    {
                        node.Attributes["f_name"].Value = (string)Request.Form["f_name"];
                        node.Attributes["l_name"].Value = Request.Form["l_name"];
                        node.Attributes["inc"].Value = Request.Form["inc"];
                        node.Attributes["status"].Value = Request.Form["status"];
                        node.Attributes["group"].Value = Request.Form["group"];
                        node.Attributes["team_e"].Value = Request.Form["team_e"];
                        node.Attributes["team_f"].Value = Request.Form["team_f"];
                        node.Attributes["acrnm_e"].Value = Request.Form["acrnm_e"];
                        node.Attributes["acrnm_f"].Value = Request.Form["acrnm_f"];
                        node.Attributes["position_e"].Value = Request.Form["position_e"];
                        node.Attributes["position_f"].Value = Request.Form["position_f"];
                        node.Attributes["phone_area_code"].Value = Request.Form["phone_area_code"];
                        node.Attributes["phone_3"].Value = Request.Form["phone_3"];
                        node.Attributes["phone_4"].Value = Request.Form["phone_4"];
                        node.Attributes["intercom"].Value = Request.Form["intercom"];
                        node.Attributes["cell_area_code"].Value = Request.Form["cell_area_code"];
                        node.Attributes["cell_3"].Value = Request.Form["cell_3"];
                        node.Attributes["cell_4"].Value = Request.Form["cell_4"];
                        node.Attributes["craUserName"].Value = Request.Form["craUserName"];
                        node.Attributes["email"].Value = Request.Form["email"];
                        node.Attributes["dojEmail"].Value = Request.Form["dojEmail"];
                        node.Attributes["CLASMateOffice"].Value = Request.Form["CLASMateOffice"];
                        node.Attributes["CLASMateUserName"].Value = Request.Form["CLASMateUserName"];
                        node.Attributes["location"].Value = Request.Form["location"];
                        node.Attributes["assistant_id"].Value = Request.Form["assistant_id"];
                        node.Attributes["isAssistant"].Value = Request.Form["isAssistant"];
                        node.Attributes["isDLSUCoach"].Value = Request.Form["isDLSUCoach"];
                        node.Attributes["isProjectMember"].Value = Request.Form["isProjectMember"];
                        node.Attributes["isDLSUPublisher"].Value = Request.Form["isDLSUPublisher"];
                        node.Attributes["hasPaperlessDummyAccount"].Value = Request.Form["hasPaperlessDummyAccount"];
                        node.Attributes["notes"].Value = Request.Form["notes"];
                        node.Attributes["EfilerAccess"].Value = Request.Form["EfilerAccess"];
                       // node.Attributes["imageDate"].Value = Request.Form["imageDate"]; 
                        node.Attributes["quicklawAccount"].Value = Request.Form["quicklawAccount"];
                        node.Attributes["updated"].Value = "1";


                       // string fileName = HttpContext.Current.Server.MapPath("~") + XML_PATH_COMMON + "directory.xml";
                        // peter
                        // xml.Save(@fileName);
                        HelpHelper.SaveXmlFile("directory.xml", xml, atBEHelp, true);

                        if (Request.Form["status"] != "1" && Request.Form["group"] == "LA")
                        {
                            //XmlDocument groups_xmlfile = HelpHelper.LoadXmlFile("groups.xml", XML_PATH_COMMON, atDal,false);
                            //if (groups_xmlfile != null)
                            //{
                            //}
                        }
                    }
                    else
                    { 
                        //create a new node
                        XmlElement element =  xml.CreateElement("staff");

                        element.SetAttribute("id",(string)Request.Form["id"]);

                        element.SetAttribute("l_name",Request.Form["l_name"]);
			            element.SetAttribute("f_name", Request.Form["f_name"]);
			            element.SetAttribute("inc",Request.Form["inc"]);
			            element.SetAttribute("status",Request.Form["status"]);
			            element.SetAttribute("group", Request.Form["group"]);
			            element.SetAttribute("team_e",Request.Form["team_e"]);
			            element.SetAttribute("team_f",Request.Form["team_f"]);
			            element.SetAttribute("acrnm_e",Request.Form["acrnm_e"]);
			            element.SetAttribute("acrnm_f",Request.Form["acrnm_f"]);
			            element.SetAttribute("position_e",Request.Form["position_e"]);
			            element.SetAttribute("position_f",Request.Form["position_f"]);
			            element.SetAttribute("phone_area_code",Request.Form["phone_area_code"]);
			            element.SetAttribute("phone_3",Request.Form["phone_3"]);
			            element.SetAttribute("phone_4",Request.Form["phone_4"]);
			            element.SetAttribute("intercom", Request.Form["intercom"]);
			            element.SetAttribute("cell_area_code", Request.Form["cell_area_code"]);
			            element.SetAttribute("cell_3",Request.Form["cell_3"]);
			            element.SetAttribute("cell_4", Request.Form["cell_4"]);
			            element.SetAttribute("craUserName", Request.Form["craUserName"]);
			            element.SetAttribute("email",Request.Form["email"]);
			            element.SetAttribute("dojEmail", Request.Form["dojEmail"]);
			            element.SetAttribute("CLASMateOffice", Request.Form["CLASMateOffice"]);
			            element.SetAttribute("CLASMateUserName", Request.Form["CLASMateUserName"]);
			            element.SetAttribute("location", Request.Form["location"]);
			            element.SetAttribute("assistant_id", Request.Form["assistant_id"]);
			            element.SetAttribute("isAssistant", Request.Form["isAssistant"]);
			            element.SetAttribute("isDLSUCoach", Request.Form["isDLSUCoach"]);
			            element.SetAttribute("isProjectMember", Request.Form["isProjectMember"]);
			            element.SetAttribute("isDLSUPublisher", Request.Form["isDLSUPublisher"]);
			            element.SetAttribute("hasPaperlessDummyAccount", Request.Form["hasPaperlessDummyAccount"]);
			            element.SetAttribute("notes", Request.Form["notes"]);
			            element.SetAttribute("EfilerAccess", Request.Form["EfilerAccess"]);
			            element.SetAttribute("quicklawAccount",Request.Form["quicklawAccount"]);
			            element.SetAttribute("updated","2");
                        element.SetAttribute("hidden", "0");
                        
                        xml.DocumentElement.AppendChild(element);//.documentElement.appendChild N
                    //    string fileName = HttpContext.Current.Server.MapPath("~") + XML_PATH_COMMON + "directory.xml";
                        // peter xml.Save(@fileName);
                        HelpHelper.SaveXmlFile("directory.xml", xml, atBEHelp, true);

                    }
                    showList(xml);
                 break;
                case "Cancel":
                 showList(xml);
                 break;

            }

        }
        private void showEditForm(string id, XmlDocument LinkData_filename)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslDirectory = HelpHelper.LoadXslTransformFile("directoryEdit.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            //proc.addParameter "sort", vSort
            xslarg.AddParam("id", "", id);
            StringWriter sw = new StringWriter();
            xslDirectory.Transform(LinkData_filename, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
        }

    }
}