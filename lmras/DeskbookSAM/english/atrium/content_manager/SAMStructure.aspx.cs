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
    public partial class SAMStructure : System.Web.UI.Page
    {
        atriumBE.HelpManager atBEHelp;
        atriumDAL.atriumDALManager atDal;
        private string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();




        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle();

            atriumBE.AtriumApp appMan = Global.Login();
            atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");
            atBEHelp = appMan.AtMng.HelpMng();

            //P.P.Ho wrote: 29/08/2013
            // Verify this line before check-in
            XmlDocument LinkData_filename = HelpHelper.LoadXmlFile("sidemenu.xml", "", atDal, true);
            if (!IsPostBack) //GET
            {
                string id;
                id = (string)Request.QueryString["id"];
                if (id != null) // GET 1
                {
                    showEditForm(id, LinkData_filename);
                }
                else if (Request.QueryString["new"] == "Y") // GET 2
                {
                    XmlNode vnn = LinkData_filename.SelectSingleNode("//nextid");
                    int newnextid;
                    newnextid = Convert.ToInt32(vnn.InnerXml) + 1;
                    vnn.InnerXml = newnextid.ToString();
                    HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);

                    XmlDocument blankXML = new XmlDocument();
                    if (Request.QueryString["orphan"] == "Y")
                    {
                        blankXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><menu><item orphan='true'  id='" + newnextid + "'/></menu>");
                    }
                    else
                    {
                        blankXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><menu><item orphan='false'  id='" + newnextid + "'/></menu>");
                    }

                    Literal h1PgTitle;
                    h1PgTitle = (Literal)Master.FindControl("h1PgTitle");
                    showNewForm(newnextid.ToString(), blankXML, h1PgTitle.Text, null, Request.QueryString["nodetype"]);

                }//"GET 3"
                else if (Request.QueryString["ColId"] != null)
                {

                    XmlNode TopNode = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["ColId"] + "']");
                    TopNode.Attributes["ColExp"].Value = Request.QueryString["colExp"];
                    HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);
                    showList(TopNode.Attributes["id"].Value, LinkData_filename);

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
                        HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);
                        showList(CutItem.Attributes["id"].Value, LinkData_filename);
                    }
                    else
                    {
                        XmlNode ParentItem = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["ParentItem"] + "']");
                        XmlNode CutItem = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["PasteItem"] + "']");
                        XmlNode removedNode = CutItem.ParentNode.RemoveChild(CutItem);

                        if (Request.QueryString["parent"] == "N") //Paste as Child
                        {
                            ParentItem.ParentNode.InsertAfter(CutItem, ParentItem);
                        }
                        else
                        {
                            removedNode.Attributes["orphan"].Value = "false";  // to bring orphan files to the hierarchy
                            ParentItem.AppendChild(removedNode);

                        }
                        HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);
                        showList(CutItem.Attributes["id"].Value, LinkData_filename);
                        ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#" + Request.QueryString["ParentItem"] + "';", true);
                    }

                }
                else if (Request.QueryString["parentId"] != null)// GET 5  ' insert new node or leaf
                {
                    XmlNode vnn = LinkData_filename.SelectSingleNode("item/nextid");
                    int newnextid = Convert.ToInt32(vnn.InnerXml) + 1;
                    vnn.InnerXml = newnextid.ToString();
                    HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);
                    XmlDocument blankXML = new XmlDocument();

                    blankXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><menu><item id='" + newnextid + "' orphan='false' pgid='' fre='' eng='' nodeType='" + Request.QueryString["nodetype"] + "' tocPath='' tocPathF=''/></menu>");
                    XmlNode N = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["parentId"] + "']");
                    string vParentEng = N.Attributes["eng"].Value;
                    showNewForm(newnextid.ToString(), blankXML, vParentEng, Request.QueryString["parentId"], Request.QueryString["nodetype"]);
                }
                else if (Request.QueryString["move"] == "down") // GET 6" 'move selected item down
                {
                    XmlNode NodeToMove = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["moveid"] + "']");
                    XmlNode NodeToMoveParent = NodeToMove.ParentNode;
                    XmlNode ReferenceNode = NodeToMove.NextSibling.NextSibling;
                    XmlNode RemovedNodeToMove = NodeToMove.ParentNode.RemoveChild(NodeToMove);

                    if (ReferenceNode != null)
                        ReferenceNode.ParentNode.InsertBefore(RemovedNodeToMove, ReferenceNode);
                    else
                        NodeToMoveParent.AppendChild(RemovedNodeToMove);

                    HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);
                    showList(NodeToMove.Attributes["id"].Value, LinkData_filename);
                    ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#" + Request.QueryString["moveid"] + "';", true);
                }
                else if (Request.QueryString["move"] == "up") //GET 7"
                {
                    XmlNode NodeToMove = LinkData_filename.SelectSingleNode("//item[@id='" + Request.QueryString["moveid"] + "']");
                    XmlNode ReferenceNode = NodeToMove.PreviousSibling;
                    XmlNode RemovedNodeToMove = NodeToMove.ParentNode.RemoveChild(NodeToMove);
                    ReferenceNode.ParentNode.InsertBefore(RemovedNodeToMove, ReferenceNode);
                    HelpHelper.SaveXmlFile("sidemenu.xml", LinkData_filename, atBEHelp, true);
                    showList(NodeToMove.Attributes["id"].Value, LinkData_filename);
                    ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#" + Request.QueryString["moveid"] + "';", true);
                }
                else if (Request.QueryString["list"] == "Y") //GET document list"
                {
                    if (Request.QueryString["Export"] == "Y")
                    {
                        excelDocumentList("", LinkData_filename);
                    }
                    else
                    {
                        showDocumentList("", LinkData_filename);
                    }
                }
                else
                {

                    showList("", LinkData_filename);
                }

            }
            else //POST
            {
                ProcessActionButtons(LinkData_filename);

            }
        }



        private void ProcessActionButtons(XmlDocument xmlDoc)
        {
            bool SaveAndReturn = false;
            string btnAction = Request.Form["btnAction"];
            string pageXMLFile;
            bool isFilesExist;
            XmlDocument pXML;
            XmlNode N;
            switch (btnAction)
            {
                case "Save":    // POST 1
                case "SaveReturn":

                    SaveAndReturn = false;
                    if (Request.Form["btnAction"] == "SaveReturn") // POST 2
                    {
                        SaveAndReturn = true;
                    }

                    XmlNode pageNode = xmlDoc.SelectSingleNode("//item[@id='" + Request.Form["id"] + "']");
                    if (pageNode != null)
                    {
                        //POST 3
                        UpdateNode(pageNode);
                        // peter
                        // xmlDoc.Save(@fileName);
                        HelpHelper.SaveXmlFile("sidemenu.xml", xmlDoc, atBEHelp, true);

                        // add js function to verify if ENG has changed, and if so, provide checkbox option to sync with page.xml
                        string itempgid = pageNode.Attributes["pgid"].Value;

                        //Peter: This section does nothing
                        //   pageXMLFile = HttpContext.Current.Server.MapPath("~") + XML_PATH_COMMON + "pages.xml";
                        pXML = HelpHelper.LoadXmlFile("pages.xml", "", atDal, true);
                        pageNode = pXML.SelectSingleNode("pages/page[@id='" + itempgid + "']");
                        if (pageNode != null)
                        {
                            pageNode.Attributes["eng"].Value = Request.Form["eng"];
                            pageNode.Attributes["fre"].Value = Request.Form["fre"];
                            pageNode.Attributes["type"].Value = Request.Form["nodetype"];

                            // peter xmlDoc.Save(@fileName);
                            HelpHelper.SaveXmlFile("pages.xml", pXML, atBEHelp, true);

                        }
                        //Peter:This section does nothing
                    }
                    else //no node found - new page
                    {
                        //POST 4
                        //create Content Pages
                        string id1;
                        id1 = Request.Form["id"];
                        createContentPages(id1);
                        pXML = HelpHelper.LoadXmlFile("pages.xml", "", atDal, true);

                        XmlElement element = pXML.CreateElement("page");
                        element.SetAttribute("id", (string)Request.Form["id"]);
                        element.SetAttribute("type", Request.Form["nodetype"]);
                        element.SetAttribute("path", Request.Form["id"] + ".asp");
                        element.SetAttribute("eng", Request.Form["eng"]);
                        element.SetAttribute("fre", Request.Form["fre"]);

                        pXML.DocumentElement.AppendChild(element);

                        HelpHelper.SaveXmlFile("pages.xml", pXML, atBEHelp, true);

                        UpdateElement(xmlDoc);


                        HelpHelper.SaveXmlFile("sidemenu.xml", xmlDoc, atBEHelp, true);


                    }
                    if (SaveAndReturn)// POST 5
                    {
                        showList(Request.Form["id"], xmlDoc);
                  
                        ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#" + Request.Form["id"] + "';", true);
                    }
                    else // POST 6
                    {
                        showEditForm(Request.Form["id"], xmlDoc);
                    }
                    break;
                case "Delete": // POST 7
                    string engFile;
                    string freFile;
                    N = xmlDoc.SelectSingleNode("//item[@id='" + Request.Form["id"] + "']");
                    string pgpgid = N.Attributes["pgid"].Value;
                    XmlNode parentXMLNode = N.ParentNode;

                    //pageXMLFile = HttpContext.Current.Server.MapPath("~") + XML_PATH_COMMON + "pages.xml";


                    pXML = HelpHelper.LoadXmlFile("pages.xml", "", atDal, true);
                    pageNode = pXML.SelectSingleNode("pages/page[@id='" + pgpgid + "']");
                    //engFile = HttpContext.Current.Server.MapPath("~") + DESKBOOK_ENGLISH_CONTENT + Request.Form["id"] + ".asp";
                    //freFile = HttpContext.Current.Server.MapPath("~") + DESKBOOK_FRANCAIS_CONTENT + Request.Form["id"] + ".asp";
                    engFile = Request.Form["id"] + ".asp";
                    freFile = Request.Form["id"] + ".asp";
                    HelpHelper.DeletePageFile(engFile, "Eng", atBEHelp, true);
                    HelpHelper.DeletePageFile(freFile, "Fre", atBEHelp, true);
                    if (N != null)
                        parentXMLNode.RemoveChild(N);

                    if (pageNode != null)
                        pXML.DocumentElement.RemoveChild(pageNode);
                    //peter pXML.Save(@pageXMLFile);
                    HelpHelper.SaveXmlFile("pages.xml", pXML, atBEHelp, true);
                    HelpHelper.SaveXmlFile("sidemenu.xml", xmlDoc, atBEHelp, true);
                    showList("", xmlDoc);

                    break;
                case "Cancel": //POST 8  
                    N = xmlDoc.SelectSingleNode("//item[@id='" + Request.Form["id"] + "']");
                    if (N != null)
                    {
                        showList(N.Attributes["id"].Value, xmlDoc);
                    }
                    else
                    {
                        showList("", xmlDoc);
                    }
                  
                    ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#" + Request.Form["id"] + "';", true);
                    break;


            }
        }
        public void createContentPages(string vPgId)
        {
            string fileName = vPgId + ".asp";
            HelpHelper.AddPageFile(fileName, "eng", atBEHelp);
            HelpHelper.AddPageFile(fileName, "fre", atBEHelp);

        }
        // response.write "createContentPages"
        //    Const adTypeText = 2
        //    Const adSaveCreateNotExist = 1
        //    strFileNameEng=server.MapPath(session("ISDefaultPath\")  & "content_manager\include\newpagetemplateEng.asp")
        //    strFileNameFre=server.MapPath(session("ISDefaultPath\")  & "content_manager\include\newpagetemplateFre.asp")

        //    Set objStreamFileEng = CreateObject("Adodb.Stream")
        //    Set objStreamFileFre = CreateObject("Adodb.Stream")

        //    objStreamFileEng.Open
        //    objStreamFileEng.Type= adTypeText
        //    objStreamFileEng.CharSet = "UTF-8"
        //    objStreamFileEng.LoadFromFile strFileNameEng
        //    objStreamFileEng.SaveToFile engPagePath & "\" & vPgId &".asp",   adSaveCreateNotExist

        //    objStreamFileFre.Open
        //    objStreamFileFre.Type= adTypeText
        //    objStreamFileFre.CharSet = "UTF-8"
        //    objStreamFileFre.LoadFromFile strFileNameFre
        //    objStreamFileFre.SaveToFile frePagePath & "\" & vPgId &".asp",   adSaveCreateNotExist

        //    objStreamFileEng.Close
        //    objStreamFileFre.Close
        //    Set objStreamFileEng = Nothing
        //    Set objStreamFileFre = Nothing

        //end sub
        private void UpdateElement(XmlDocument xmlDoc)
        {
            XmlElement element = xmlDoc.CreateElement("item");
            element.SetAttribute("id", Request.Form["id"]);
            element.SetAttribute("pgid", Request.Form["id"]);

            element.SetAttribute("nodeType", (string)Request.Form["nodetype"]);
            element.SetAttribute("eng", Request.Form["eng"]);
            element.SetAttribute("fre", Request.Form["fre"]);
            element.SetAttribute("orphan", Request.Form["orphan"]);
            element.SetAttribute("tocPath", Request.Form["tocPath"]);
            element.SetAttribute("tocPathF", Request.Form["tocPathF"]);
            element.SetAttribute("dcSubjectEng", Request.Form["dcSubjectEng"]);
            element.SetAttribute("dcSubjectFre", Request.Form["dcSubjectFre"]);
            element.SetAttribute("dcDescriptionEng", Request.Form["dcDescriptionEng"]);
            element.SetAttribute("dcDescriptionFre", Request.Form["dcDescriptionFre"]);
            element.SetAttribute("keywordsEng", Request.Form["keywordsEng"]);
            element.SetAttribute("keywordsFre", Request.Form["keywordsFre"]);
            element.SetAttribute("translateTo", Request.Form["translateTo"]);
            element.SetAttribute("translationProcess", Request.Form["translationProcess"]);
            element.SetAttribute("responsability", Request.Form["responsability"]);
            element.SetAttribute("process", Request.Form["process"]);
            element.SetAttribute("dateAssigned", Request.Form["dateAssigned"]);
            element.SetAttribute("fileNumber", Request.Form["fileNumber"]);
            element.SetAttribute("comment", Request.Form["comment"]);
            element.SetAttribute("updated", "1");
            element.SetAttribute("updatePerson", (string)Session["DLSUUser"]);
            element.SetAttribute("updateDate", (string)DateTime.UtcNow.ToString());

            if (Request.Form["parentID"] == null || Request.Form["parentID"] == "")
                xmlDoc.DocumentElement.AppendChild(element);
            else
            {
                XmlNode parentN;
                parentN = xmlDoc.SelectSingleNode("//item[@id='" + Request.Form["parentID"] + "']");
                parentN.AppendChild(element);
            }
            //element.Attributes["nodeType"].Value = (string)Request.Form["nodetype"];
            //element.Attributes["eng"].Value = Request.Form["eng"];
            //element.Attributes["fre"].Value = Request.Form["fre"];
            //element.Attributes["orphan"].Value = Request.Form["orphan"];
            //element.Attributes["tocPath"].Value = Request.Form["tocPath"];
            //element.Attributes["tocPathF"].Value = Request.Form["tocPathF"];
            //element.Attributes["dcSubjectEng"].Value = Request.Form["dcSubjectEng"];
            //element.Attributes["dcSubjectFre"].Value = Request.Form["dcSubjectFre"];
            //element.Attributes["dcDescriptionEng"].Value = Request.Form["dcDescriptionEng"];
            //element.Attributes["dcDescriptionFre"].Value = Request.Form["dcDescriptionFre"];
            //element.Attributes["keywordsEng"].Value = Request.Form["keywordsEng"];
            //element.Attributes["keywordsFre"].Value = Request.Form["keywordsFre"];
            //element.Attributes["translateTo"].Value = Request.Form["translateTo"];
            //element.Attributes["translationProcess"].Value = Request.Form["translationProcess"];
            //element.Attributes["responsability"].Value = Request.Form["responsability"];
            //element.Attributes["process"].Value = Request.Form["process"];
            //element.Attributes["dateAssigned"].Value = Request.Form["dateAssigned"];
            //element.Attributes["fileNumber"].Value = Request.Form["fileNumber"];
            //element.Attributes["comment"].Value = Request.Form["comment"];
            //element.Attributes["updated"].Value = "1";
            //element.Attributes["updatePerson"].Value = (string)Session["DLSUUser"];
            //element.Attributes["updateDate"].Value = (string)DateTime.Now.ToString();


        }
        private void UpdateNode(XmlNode xNode)
        {

            xNode.Attributes["nodeType"].Value = (string)Request.Form["nodetype"];
            xNode.Attributes["eng"].Value = Request.Form["eng"];
            xNode.Attributes["fre"].Value = Request.Form["fre"];
            xNode.Attributes["orphan"].Value = Request.Form["orphan"];
            xNode.Attributes["tocPath"].Value = Request.Form["tocPath"];
            xNode.Attributes["tocPathF"].Value = Request.Form["tocPathF"];
            xNode.Attributes["dcSubjectEng"].Value = Request.Form["dcSubjectEng"];
            xNode.Attributes["dcSubjectFre"].Value = Request.Form["dcSubjectFre"];
            xNode.Attributes["dcDescriptionEng"].Value = Request.Form["dcDescriptionEng"];
            xNode.Attributes["dcDescriptionFre"].Value = Request.Form["dcDescriptionFre"];
            xNode.Attributes["keywordsEng"].Value = Request.Form["keywordsEng"];
            xNode.Attributes["keywordsFre"].Value = Request.Form["keywordsFre"];
            xNode.Attributes["translateTo"].Value = Request.Form["translateTo"];
            xNode.Attributes["translationProcess"].Value = Request.Form["translationProcess"];
            xNode.Attributes["responsability"].Value = Request.Form["responsability"];
            xNode.Attributes["process"].Value = Request.Form["process"];
            xNode.Attributes["dateAssigned"].Value = Request.Form["dateAssigned"];
            xNode.Attributes["fileNumber"].Value = Request.Form["fileNumber"];
            xNode.Attributes["comment"].Value = Request.Form["comment"];
            xNode.Attributes["updated"].Value = "1";
            xNode.Attributes["updatePerson"].Value = (string)Session["DLSUUser"];
            xNode.Attributes["updateDate"].Value = (string)DateTime.UtcNow.ToString();


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


        private void showEditForm(string id, XmlDocument xmlDoc)
        {
            //.xsl

            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslStructure = HelpHelper.LoadXslTransformFile("manual_edit.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            xslarg.AddParam("id", "", id);

            StringWriter sw = new StringWriter();

            xslStructure.Transform(xmlDoc, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;



        }
        private void showNewForm(string id, XmlDocument xmlDoc, string parentName, string parentID, string nodeType)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            XslCompiledTransform xslStructure = HelpHelper.LoadXslTransformFile("manual_new.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            xslarg.AddParam("id", "", id);
            if (parentName != null)
                xslarg.AddParam("parentName", "", parentName);
            if (parentID != null)
                xslarg.AddParam("parentID", "", parentID);
            if (nodeType != null)
                xslarg.AddParam("nodeType", "", nodeType);
            StringWriter sw = new StringWriter();

            xslStructure.Transform(xmlDoc, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            pgContent.Text = result;

        }

        private void showList(string nodeToHighlight, XmlDocument LinkData_filename)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            string id = (string)Request.QueryString["pgid"];
            XslCompiledTransform xslStructure = HelpHelper.LoadXslTransformFile("manual_select.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
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

        private void showDocumentList(string nodeToHighlight, XmlDocument LinkData_filename)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            string id = (string)Request.QueryString["pgid"];
            XslCompiledTransform xslStructure = HelpHelper.LoadXslTransformFile("structure_list.xsl", DESKBOOK_SAM_PATH_XSL, atDal, false);
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


        private void excelDocumentList(string nodeToHighlight, XmlDocument LinkData_filename)
        {
            string DESKBOOK_SAM_PATH_XSL = System.Configuration.ConfigurationManager.AppSettings["DESKBOOK_SAM_PATH_XSL"].ToString();
            string id = (string)Request.QueryString["pgid"];
            XslCompiledTransform xslStructure = HelpHelper.LoadXslTransformFile("structure_excelexport.xslt", DESKBOOK_SAM_PATH_XSL, atDal, false);
            XsltArgumentList xslarg = new XsltArgumentList();
            if (id != null)
                xslarg.AddParam("pgid", "", id);

            if (nodeToHighlight != null)
                xslarg.AddParam("nodeToHighlight", "", nodeToHighlight);

            StringWriter sw = new StringWriter();
            xslStructure.Transform(LinkData_filename, xslarg, sw);


            this.Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=Export.xls");
            Response.Charset = "";
            this.EnableViewState = false;

            Response.Write(sw.ToString());
            //Response.End();

            //string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            //pgContent.Text = result;
            Response.End();
        }
    }
}