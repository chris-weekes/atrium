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
    public partial class SAMImages : System.Web.UI.Page
    {
        atriumBE.HelpManager atBEHelp;
        atriumDAL.atriumDALManager atDal;
        string vTreeview;
        string vPreview;
        bool showUpload;

        XmlDocument LinkData_filename;
        protected void Page_Load(object sender, EventArgs e)
        {

            //LinkData_filename = Server.MapPath(session("ISdefaultPath\") & "content_manager\include\xml\images.xml")
            //LinkSelect_filename = Server.MapPath(session("ISdefaultPath\") & "content_manager\include\xsl\images_select.xsl")
            //LinkSelectTree_filename = Server.MapPath(session("ISdefaultPath\") & "content_manager\include\xsl\images_selectTree.xsl")
            //LinkEdit_filename = Server.MapPath(session("ISdefaultPath\") & "content_manager\include\xsl\images_edit.xsl")
            //LinkEditFolder_filename = Server.MapPath(session("ISdefaultPath\") & "content_manager\include\xsl\images_edit_folder.xsl")
            XmlNode N;
            SetPageTitle();

            if (Request.QueryString["preview"] != null)
            {
                vPreview = Request.QueryString["preview"];
                Response.Cookies["preview"].Value = vPreview;
            }
            else
            {
                if (Request.Cookies["preview"] != null)
                    vPreview = Request.Cookies["preview"].Value;
                else
                    vPreview = "";
            }


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



            atriumBE.AtriumApp appMan = Global.Login();
            atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");
            atBEHelp = appMan.AtMng.HelpMng();



            LinkData_filename = HelpHelper.LoadXmlFile("images.xml", "", atDal, true);

            if (!IsPostBack) //GET
            {
                string id;
                id = (string)Request.QueryString["id"];
                if (id != null) // GET 1
                {
                    if (Request.QueryString["isfolder"] == "Y")
                        showFolderEditForm(id, LinkData_filename);
                    else
                        showEditForm(id, LinkData_filename);
                }
                else if (Request.QueryString["NewUpload"] == "Y")
                {
                    showUpload = true;
                }
                else if (Request.QueryString["NoFiles"] == "Y")
                {
                    showUpload = true;
                }
                else if (Request.QueryString["NewFolder"] == "Y")
                {
                    XmlNode vnn = LinkData_filename.SelectSingleNode("images/nextid");
                    int newnextid;
                    newnextid = Convert.ToInt32(vnn.InnerXml) + 1;
                    vnn.InnerXml = newnextid.ToString();
                    HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);
                    XmlDocument blankXML = new XmlDocument();
                    blankXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><images><container id='" + newnextid + "' name=''/></images>");

                    showFolderEditForm(newnextid.ToString(), blankXML);
                }
                //"GET 4"
                else if (Request.QueryString["paste"] == "Y")
                {
                    if (Request.QueryString["ParentItem"] == "ROOT")
                    {
                        XmlElement ParentItem = LinkData_filename.DocumentElement;
                        XmlNode CutItem = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["PasteItem"] + "']");
                        XmlNode removedNode = CutItem.ParentNode.RemoveChild(CutItem);
                        ParentItem.AppendChild(removedNode);
                        HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);
                        showList("");
                    }
                    else
                    {
                        XmlNode ParentItem = LinkData_filename.SelectSingleNode("//container[@id='" + Request.QueryString["ParentItem"] + "']");
                        XmlNode CutItem = LinkData_filename.SelectSingleNode("//image[@id='" + Request.QueryString["PasteItem"] + "']");
                        XmlNode removedNode = CutItem.ParentNode.RemoveChild(CutItem);

                        if (Request.QueryString["parent"] == "N") //Paste as Child
                        {
                            ParentItem.ParentNode.InsertAfter(CutItem, ParentItem);
                        }
                        else
                        {
                            ParentItem.AppendChild(removedNode);

                        }
                        HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);
                        showList("");
                        ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#" + Request.QueryString["ParentItem"] + "';", true);
                    }

                }
                else //GET 9
                {
                    showList("");
                }
            }
            else //POST
            {

                bool SaveAndReturn = false;
                string id = (string)Request.Form["id"];
                string btnAction = (string)Request.Form["btnAction"];
                switch (btnAction)
                {

                    case "SaveFolder":
                    case "SaveReturnFolder":
                        SaveAndReturn = false;
                        if (btnAction == "SaveReturnFolder")
                            SaveAndReturn = true;
                        N = LinkData_filename.SelectSingleNode("//image[@id='" + Request.Form["id"] + "']");
                        if (N != null)
                        {
                            N.Attributes["name"].Value = Request.Form["name"];
                            HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);
                        }
                        if (SaveAndReturn)
                            showList(Request.Form["id"]);
                        else
                            showEditForm(Request.Form["id"], LinkData_filename);
                        break;
                    case "Save":
                    case "SaveReturn":
                        SaveAndReturn = false;
                        if (btnAction == "SaveReturn")
                            SaveAndReturn = true;
                        N = LinkData_filename.SelectSingleNode("//image[@id='" + Request.Form["id"] + "']");
                        if (N != null)
                        {
                            N.Attributes["name"].Value = Request.Form["name"];
                            HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);
                        }
                        if (SaveAndReturn)
                            showList(Request.Form["id"]);
                        else
                            showEditForm(Request.Form["id"], LinkData_filename);
                        break;
                    case "Delete":
                        N = LinkData_filename.SelectSingleNode("//image[@id='" + Request.Form["id"] + "']");
                        if (N != null)
                        {
                            string imgFile = N.Attributes["src"].Value; //n.getattribute("src")
                            XmlNode parentXMLNode = N.ParentNode;
                            parentXMLNode.RemoveChild(N);   //   N.n.parentnode.removeChild N
                            HelpHelper.DeleteImageFile(imgFile, atBEHelp);
                            HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);
                        }

                        showList("");
                        break;

                    case "Return to List":
                        showList(Request.Form["id"]);
                        break;
                }
            }

        }

        private void showFolderEditForm(string id, XmlDocument xmldoc)
        {

            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslEditFolderImages = HelpHelper.LoadXslTransformFile("images_edit_folder.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            if (id != null)
                xslarg.AddParam("id", "", id);
            xslarg.AddParam("parentid", "", Request.QueryString["parentId"]);
            StringWriter sw = new StringWriter();
            xslEditFolderImages.Transform(xmldoc, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
        }

        private void showEditForm(string id, XmlDocument xmldoc)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslEditFolderImages = HelpHelper.LoadXslTransformFile("images_edit.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            if (id != null)
                xslarg.AddParam("id", "", id);
            StringWriter sw = new StringWriter();
            xslEditFolderImages.Transform(xmldoc, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;
        }

        private void SetPageTitle()
        {
            string PgId;
            string vQS = Request.QueryString["pgid"];
            if (vQS == null || vQS == "")
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

        private void showList(string nodeToHighlight)
        {

            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            if (vTreeview == "false")
            {
                XslCompiledTransform xslImages = HelpHelper.LoadXslTransformFile("images_select.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
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
                XslCompiledTransform xslImages = HelpHelper.LoadXslTransformFile("images_selectTree.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);

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