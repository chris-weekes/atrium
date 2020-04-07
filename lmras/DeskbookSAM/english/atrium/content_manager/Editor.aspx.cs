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
    public partial class Editor : System.Web.UI.Page
    {

        public string pgCSS;
        public string vStream;
        public string vAccessedDate, vAccessedTime, vAccessedPerson, vPageName;
        public string style, img, imgText;
        public string updateStyle, UpdateImg, UpdateImgText;
        public string errMessage;
        string SAMUser;

        atriumBE.HelpManager atBEHelp;
        public atriumDAL.atriumDALManager atDal;
        private string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();
        
        
        
         


          
        
        public string vUpdateDate, vUpdateTime, vUpdatePerson;

        // Access variables
        public bool HasUpdate, HasAccess = false;
        public bool displayAccessMessage, displayUpdateMessage;
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string inc;
            string writtenText;
            string sFilePath;


            atriumBE.AtriumApp appMan = Global.Login();
            atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");

            atBEHelp = appMan.AtMng.HelpMng();
            SAMUser = appMan.AtMng.OfficerLoggedOn.UserName;

            inc = (string)Request.QueryString["inc"];
             

           

            XmlDocument XMLFile;
            XMLFile = HelpHelper.LoadXmlFile("pages.xml", "", atDal, true);
            XmlNode N = XMLFile.SelectSingleNode("pages/page[@id='" + Request.QueryString["id"] + "']");

            string contentPage = N.Attributes["path"].Value;
            vfilefull.Value = contentPage;
            
            // "GET"
            if (Request.ServerVariables["REQUEST_METHOD"] == "GET")
            {
                vStream = HelpHelper.LoadPageFile(contentPage, inc, atBEHelp, true);
                vAccessedDate = "";
                vAccessedPerson = "";
                vPageName = "";
                GetAccessUpdateDate(N);
                GetConventSavedDate(N);

                XmlElement nAccess = XMLFile.CreateElement("access");
                XmlAttribute attr = XMLFile.CreateAttribute("contentAccessed");
                attr.Value = DateTime.UtcNow.ToString();
                nAccess.SetAttributeNode(attr);

                attr = XMLFile.CreateAttribute("contentAccessedPerson");
                attr.Value = SAMUser;
                nAccess.SetAttributeNode(attr);
                N.AppendChild(nAccess);

                HelpHelper.SaveXmlFile("pages.xml", XMLFile, atBEHelp, true);
                if (N.Attributes["pgCSS"] != null)
                        pgCSS = N.Attributes["pgCSS"].Value;
              
               
            }
            //POST
            else if (Request.ServerVariables["REQUEST_METHOD"] == "POST")
            { 
                // save file
                string vpath = (string)Request.Form["vfilefull"];
                if ( vpath != null)  
                {

                    if (Request.Form["stream"] != null)
                    {
                        string contents =Request.Form["stream"].ToString();
                        writtenText = writeTextFileContent(vpath, "utf-8", contents, inc);
                    }
                }
                // update file list to reflect update of page
                if (N != null)
                {
                    GetAccessUpdateDate(N);

                    XmlAttribute contentUpdated = XMLFile.CreateAttribute("contentUpdated");
                    contentUpdated.Value = DateTime.UtcNow.ToString();
                    N.Attributes.Append(contentUpdated);

                    XmlAttribute contentUpdatedPerson = XMLFile.CreateAttribute("contentUpdatedPerson");
                    contentUpdatedPerson.Value = SAMUser;
                    N.Attributes.Append(contentUpdatedPerson);

                    XmlAttribute oAttr = XMLFile.CreateAttribute("pgCSS");
                    oAttr.Value = Request.Form["pgCSS"];
                    N.Attributes.Append(oAttr);
                    HelpHelper.SaveXmlFile("pages.xml", XMLFile, atBEHelp, true);
                    GetConventSavedDate(N);
                }
                else
                { // record not found
                    errMessage = "File could not be found in file list.  Uppate flag could not be modified.";
                }
                // To continue on Wednesday
                 
                vStream = HelpHelper.LoadPageFile(vpath, inc, atBEHelp, true);
                if (N.Attributes["pgCSS"] != null)
                    pgCSS = N.Attributes["pgCSS"].Value;
                GetAccessUpdateDate(N);
            }


            InitializeVariables();
        }

        public void InitializeVariables()
        {
            HasAccess = false;
            displayAccessMessage = false;
            if ((vAccessedDate != null) || (vAccessedDate != ""))
            {
                HasAccess = true;
                if( (vAccessedDate == DateTime.UtcNow.Date.ToString())  && (vAccessedPerson!= SAMUser)) 
                {
                    displayAccessMessage = true; 
                    style="style=\"background-color:#ffffc0;height:62px;color:blue;font-size:1.1em;border:1px dashed blue;\"";
                    img = "<img src=\"images/tripup.gif\" alt=\"\" style=\"float:left;margin-top:5px;margin-left:5px;margin-right:12px;\"/>";
                    imgText = "<span style=\"position:relative;top:5px;\">Note that this page has already been <strong style=\"text-decoration:underline;font-size:1.2em;\"><em>accessed</em></strong> today.  That user may still be in the page and may be making changes to it.  Contact the user to coordinate access if you intend to make modifications to this page.</span><br>";
                }
            }
            HasUpdate = false;
            displayUpdateMessage = false;
            if ((vUpdateDate != null) || (vUpdateDate != ""))
            {
                HasUpdate = true;
                if ((vUpdateDate==DateTime.UtcNow.Date.ToString())  && (vUpdatePerson!= SAMUser))
                {
                    displayUpdateMessage=true;
                    updateStyle = "style=\"background-color:#ffffc0;height:62px;color:red;font-size:1.1em;border:1px dashed red\"";
                    UpdateImg = "<img src=\"images/tripup.gif\" alt=\"\" style=\"float:left;margin-top:5px;margin-left:5px;margin-right:12px;\"/>";
                    UpdateImgText = "<span style=\"position:relative;top:5px;\">Note that this page has already been <strong style=\"text-decoration:underline;font-size:1.2em;\"><em>saved</em></strong> today.  That user may still be in the page and may be making changes to it.  Contact the user to coordinate access if you intend to make modifications to this page.</span><br>";
                }
            }

        }
        public void loadListItems( )
        {
            //string list =null;
            XmlDocument oAcronymsXML;
            oAcronymsXML = HelpHelper.LoadXmlFile("acronyms.xml", "", atDal, true);

            foreach (XmlElement cn in oAcronymsXML.DocumentElement.ChildNodes)
            {
                if (cn.Attributes["quicklist"] != null)
                {

                    if (cn.Name == "acronym" && cn.Attributes["quicklist"].Value == "1")
                    {
                        if (Request.QueryString["inc"] == "eng")
                            Response.Write("<option value=\"" + cn.Attributes["desc_e"].Value + "\">" + cn.Attributes["english"].Value + "</option>");
                        else
                            Response.Write("<option value=\"" + cn.Attributes["desc_f"].Value + "\">" + cn.Attributes["french"].Value + "</option>");
                    }
                }
            }
           
          
        }

        private string writeTextFileContent(string strFileName, string strCharSet, string strContents, string lang)
        {
        const int adTypeText = 2;
        const int adSaveCreateOverWrite = 2;
        const int adSaveCreateNotExist = 1;
        
        string doc = null;
        // Set default CharSet
        if (strCharSet == "")
        {
            strCharSet = "ASCII";
        }
        HelpHelper.SavePageFile(strFileName, strContents,SAMUser,lang, atBEHelp, true);
             
         
        return doc;
    }

//        Function writeTextFileContent(strFileName, strCharSet, strContents)
//    Const adTypeText = 2
//    Const adSaveCreateOverWrite = 2
//    Const adSaveCreateNotExist = 1

//    'Set default CharSet
//    If strCharSet = "" Then strCharSet = "ASCII"
//    Set objStreamFile = CreateObject("Adodb.Stream")
//    objStreamFile.Open
//    objStreamFile.Type= adTypeText
//    objStreamFile.CharSet = strCharSet
//    objStreamFile.LoadFromFile strFileName
//    objStreamFile.Position = 0
//    objStreamFile.WriteText(strContents)
//    If (objStreamFile.Position < objStreamFile.Size) Then
//       objStreamFile.SetEOS
//    End If 
//    objStreamFile.SaveToFile strFileName,   adSaveCreateOverWrite
//    writeTextFileContent=streamText
//    objStreamFile.Close

//    Set objStreamFile = Nothing
//End Function

        //private string ConvertDate(string dt)
        //{
        //    DateTime date = new DateTime(;

        //    return date;
        //}

        private void GetAccessUpdateDate(XmlNode pgNode)
        {
            XmlNode nLastChild = pgNode.LastChild;
            if (nLastChild != null)
            {
                if (nLastChild.Name == "access")
                {
                    vAccessedDate = nLastChild.Attributes["contentAccessed"].Value ;
                    // not need vAccessedTime = nLastChild.Attributes["contentAccessed"].Value;
                    vAccessedPerson = nLastChild.Attributes["contentAccessedPerson"].Value;
                    vPageName = nLastChild.ParentNode.Attributes["eng"].Value;
                }
            }
        }
        private void GetConventSavedDate(XmlNode pgNode)
        { 
             if (pgNode.Attributes["contentUpdated"] != null)
             {
                 vUpdateDate = pgNode.Attributes["contentUpdated"].Value;
                 // not need -- vUpdateTime = pgNode.Attributes["contentUpdated"].Value;
                 vUpdatePerson = pgNode.Attributes["contentUpdatedPerson"].Value;
             }
        } 
 
    }
}