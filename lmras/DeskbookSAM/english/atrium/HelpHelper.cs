
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using System.Configuration;
using System.Data;
 
namespace SSTDeskBooks.english.atrium
{
    public class HelpHelper 
    {

        //For Page file only
        public static bool AddPageFile(string filename, string lang, atriumBE.HelpManager atBE)
        {
            bool isAdded = false;
            
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true")
            {
                lmDatasets.HelpDB.hlpPageRow cur_row = (lmDatasets.HelpDB.hlpPageRow)atBE.GethlpPage().Add(null);
                cur_row.FileName = filename;
                cur_row.Lang = lang;
                cur_row.Publish = false;
                cur_row.Contents = "<!--Create your new content here-->";
                cur_row.updateDate = DateTime.Now;

                isAdded = true;
                atLogic.BusinessProcess bp = atBE.GetBP();
                bp.AddForUpdate(atBE.GethlpPage());
                bp.Update();


            }
            return isAdded;
        }

        //For Page file only
        public static void DeletePageFile(string filename, string lang, atriumBE.HelpManager atBE, bool isCommon)
        {
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true" && isCommon == true)
            {
                lmDatasets.HelpDB.hlpPageRow cur_row  = atBE.GethlpPage().Load(filename, lang);
                if (cur_row != null)
                {
                    cur_row.Delete();

                    atLogic.BusinessProcess bp = atBE.GetBP();
                    bp.AddForUpdate(atBE.GethlpPage());
                    bp.Update();
                }
                
            }
        }
        //For Page file only
        public static void SavePageFile(string filename, string content, string user, string lang, atriumBE.HelpManager atBE, bool isCommon)
        {
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true" && isCommon == true)
            {
                lmDatasets.HelpDB.hlpPageRow cur_row = atBE.GethlpPage().Load(filename, lang);
                cur_row.Contents = content;
                cur_row.updateDate = DateTime.Now;
                // peter: to add user name here: 
                cur_row.updateUser = user;
                atLogic.BusinessProcess bp = atBE.GetBP();
                bp.AddForUpdate(atBE.GethlpPage());
                bp.Update();
            }
            else 
            {
                throw new Exception("OOPS! The Page file could not be saved. Please contact an administrator.");
            }
        }

        //For Image file only
        public static bool DeleteImageFile(string filename,  atriumBE.HelpManager atBE)
        { 
            bool isDeleted =false;
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true") 
            {
                lmDatasets.HelpDB.hlpImageRow cur_row  = atBE.GethlpImage().Load(filename);
                cur_row.Delete();

                atLogic.BusinessProcess bp = atBE.GetBP();
                bp.AddForUpdate(atBE.GethlpImage());
                bp.Update();
                isDeleted =true;
            }

        return isDeleted;
        }




        public static string GetMimeType(string ext)
        {
            switch (ext.ToLower())
            {
                case ".txt":
                    return System.Net.Mime.MediaTypeNames.Text.Plain;
                case ".rtf":
                    return System.Net.Mime.MediaTypeNames.Text.RichText;
                case ".htm":
                case ".html":
                    return System.Net.Mime.MediaTypeNames.Text.Html;
                case ".xml":
                    return System.Net.Mime.MediaTypeNames.Text.Xml;
                case ".pdf":
                    return System.Net.Mime.MediaTypeNames.Application.Pdf;
                case ".zip":
                    return System.Net.Mime.MediaTypeNames.Application.Zip;
                case ".xls":
                case ".ppt":
                case ".doc":
                    return System.Net.Mime.MediaTypeNames.Application.Octet;
                case ".gif":
                    return System.Net.Mime.MediaTypeNames.Image.Gif;
                case ".jpg":
                case ".jpeg":
                    return System.Net.Mime.MediaTypeNames.Image.Jpeg;
                case ".tif":
                case ".tiff":
                    return System.Net.Mime.MediaTypeNames.Image.Tiff;

                default:
                    return System.Net.Mime.MediaTypeNames.Application.Octet;


            }
        }
        //For Image file only
        public static void AddImageFile(string filename, string user, byte[] InputBytes, atriumBE.HelpManager atBE)
        {
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true")
            {
                lmDatasets.HelpDB.hlpImageRow imgDR = (lmDatasets.HelpDB.hlpImageRow)atBE.myhlpImage.Add(null);
              
                imgDR.FileName = filename;
                imgDR.ContentType = GetMimeType((System.IO.Path.GetExtension(filename).ToLower())).ToString();
                imgDR.Contents = InputBytes;
                imgDR.Publish = false;

                atLogic.BusinessProcess bp = atBE.GetBP();
                bp.AddForUpdate(atBE.GethlpImage());
                bp.Update(); 
                
            }
            else
            {
                throw new Exception("OOPS! The Image file could not be saved. Please contact an administrator.");
            }
        }


        

        public static string LoadPageFile(string filename, string lang, atriumBE.HelpManager atBE, bool isInDB)
        {
            string sr;
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true" && isInDB == true)
            {
                lmDatasets.HelpDB.hlpPageRow cur_row = atBE.GethlpPage().Load(filename, lang);
                sr = cur_row.Contents;
                return sr;
            }
            else
            {
                throw new Exception("OOPS! The Page file could not be loaded. Please contact an administrator.");
            }

        }



        public static void SaveXmlFile(string filename, XmlDocument xmlDocToSave, atriumBE.HelpManager atBE, bool isCommon)
        {
            
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true" && isCommon == true)
            {
                lmDatasets.HelpDB.hlpXmlRow cur_row = atBE.GethlpXml().Load(filename);
              
                cur_row.Contents = xmlDocToSave.InnerXml;
                cur_row.updateDate = DateTime.Now;
                // peter: to add user name here: 
                cur_row.updateUser= "peter phong";
                atLogic.BusinessProcess bp = atBE.GetBP();
                bp.AddForUpdate(atBE.GethlpXml());
                bp.Update();
            }
            else 
            {
                throw new Exception("OOPS! The XML file could not be saved. Please contact an administrator.");
            }
          
        }


        public static XmlDocument LoadXmlFile(string filename, string strPath, atriumDAL.atriumDALManager atDal, bool  isCommon)
        {
            XmlDocument doc = null;

            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true" && isCommon == true)
            {
                lmDatasets.HelpDB.hlpXmlDataTable dt = atDal.GethlpXml().Load(filename);
                if (dt.Rows.Count == 1)
                {
                    doc = new XmlDocument();
                    doc.LoadXml(dt[0].Contents);
                    return doc;
                }
                else
                {
                    throw new Exception("OOPS! The XML file could not be found. Please contact an administrator.");
                }

            }
            else
            {
                doc = new XmlDocument();
                bool isFilesExist;
                isFilesExist = FileExists(HttpContext.Current.Server.MapPath("~") + strPath + filename);
                if (isFilesExist)
                {
                    doc.Load(HttpContext.Current.Server.MapPath("~") + strPath + filename);
                }
                return doc;
            }
                
        }

        public static XslCompiledTransform LoadXslTransformFile(string filename, string strPath, atriumDAL.atriumDALManager atDal, bool isCommon)
        {
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true" && isCommon == true)
            {
                lmDatasets.HelpDB.hlpXmlDataTable dt = atDal.GethlpXml().Load(filename);
                if (dt.Rows.Count == 1)
                {
                    XslCompiledTransform doc = new XslCompiledTransform();

                    //System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    //Byte[] bytes = encoding.GetBytes(dt[0].Contents);
                    //MemoryStream ms = new MemoryStream(bytes);

                    StringReader sr = new StringReader(dt[0].Contents);
                    XmlReader reader = XmlReader.Create(sr);
                    doc.Load(reader);
                    return doc;
                }
                else
                    throw new Exception("OOPS! The XSL Transform file could not be found. Please contact an administrator.");

            }
            else
            {
                XslCompiledTransform doc = new XslCompiledTransform();
                //string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();
                bool isFilesExist;
                string filepath = HttpContext.Current.Server.MapPath("~") + strPath + filename;
                isFilesExist = FileExists(filepath);
                if (isFilesExist)
                {
                    doc.Load(HttpContext.Current.Server.MapPath("~") + strPath + filename);
                }
                return doc;
            }
        }
        public static bool FileExists(string strPathName)
        {
            bool blnFileExists;
            try
            {
                FileInfo file = new FileInfo(strPathName);
                // tests for the file with the specified path
                if (file.Exists)
                {
                    blnFileExists = true;
                }
                else
                    blnFileExists = false;
            }

            catch (Exception x)
            {
                throw x;
            }
            return blnFileExists;
        }
        public static lmDatasets.HelpDB.hlpPageRow RetrievePageContent(string pagename, string lang, atriumDAL.atriumDALManager atDal)
        {
            lmDatasets.HelpDB.hlpPageDataTable dt = atDal.GethlpPage().Load(pagename, lang);
            if (dt.Rows.Count == 1)
                return dt[0]; //"No Page Content cound be found for this page. Please contact an administrator. Content=null";
            else
                return null; //"No Page Content cound be found for this page. Please contact an administrator. No rows returned;";
        }

        public static string OtherLangUrl(bool fromEngToFra, string serverUrl, string qs)
        {
            string lang1 = "english";
            string lang2 = "francais";
            if (fromEngToFra)
            {
                lang1 = "francais";
                lang2 = "english";
            }
            string origURL = serverUrl.ToLower();
            string newURL = origURL.Replace(lang2 + "/", lang1 + "/");
            newURL = newURL.Replace("default.aspx", "");
            if (qs.Length > 0)
                return newURL + "?" + qs.Replace("&", "&amp;");
            else
                return newURL;
        }


        public static string DoMenu(string lang, XmlDocument xmlMenu, string PgId, atriumDAL.atriumDALManager atDal)
        {
            string sOutput = "";
            PgId = "1999"; // peter
            XmlDocument tempXMLMenu = new XmlDocument();
            tempXMLMenu.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?><menu></menu>");

            XmlNode SelectedMenuNode = xmlMenu.SelectSingleNode("//item[@pgid='" + PgId + "']");

            if (SelectedMenuNode == null)
                sOutput = "OOPS! Could not find requested Menu Node. Please contact an administrator.";
            else
            {
                if (SelectedMenuNode.HasChildNodes)
                {
                    XmlNode menuNode = tempXMLMenu.ImportNode(SelectedMenuNode, true);
                    CreateXMLAttribute("isSelected", "true", tempXMLMenu, menuNode);

                    if (PgId == "1999") //set parent attribute, otherwise pgid 1 node is not treated as top level
                        CreateXMLAttribute("parent", "true", tempXMLMenu, menuNode);
                    else
                        CreateXMLAttribute("parent", "false", tempXMLMenu, menuNode);

                    tempXMLMenu.DocumentElement.AppendChild(menuNode);
                    SetMenuXML(menuNode, tempXMLMenu, false, xmlMenu);
                }
                else
                {
                    if (SelectedMenuNode.ParentNode != null)
                    {
                        XmlNode menuNode = tempXMLMenu.ImportNode(SelectedMenuNode.ParentNode, true);
                        CreateXMLAttribute("isSelected", "true", tempXMLMenu, menuNode);

                        if (PgId == "1999")
                            CreateXMLAttribute("parent", "true", tempXMLMenu, menuNode);
                        else
                            CreateXMLAttribute("parent", "false", tempXMLMenu, menuNode);

                        tempXMLMenu.DocumentElement.AppendChild(menuNode);
                        SetMenuXML(menuNode, tempXMLMenu, false, xmlMenu);
                    }
                }
            }
            string XSLT_PATH_COMMON = System.Configuration.ConfigurationManager.AppSettings["XSLT_PATH_COMMON"].ToString();
            
            XslCompiledTransform xslMenu = HelpHelper.LoadXslTransformFile("sidemenu.xsl", XSLT_PATH_COMMON, atDal,true);
            XsltArgumentList xslarg = new XsltArgumentList();
            
            xslarg.AddParam("server", "", "Default.aspx");
            xslarg.AddParam("lang", "", lang);

            StringWriter sw = new StringWriter();
            xslMenu.Transform(tempXMLMenu, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();

            string rvalue;
            if (sOutput == "")
                rvalue = result;
            else
                rvalue = sOutput;

            return rvalue;
        }

        private static void CreateXMLAttribute(string name, string value, XmlDocument xmldoc, XmlNode xmlnode)
        {
            XmlAttribute oAttr = xmldoc.CreateAttribute(name);
            oAttr.Value = value;
            xmlnode.Attributes.Append(oAttr);
        }

        private static void SetMenuXML(XmlNode passedClone, XmlDocument tempmenuxml, bool doneFirstPass, XmlDocument xmlMenu)
        {

            XmlNode passedNode = xmlMenu.SelectSingleNode("//item[@pgid='" + passedClone.Attributes["pgid"].Value + "']");
            if (passedNode != null)
            {
                if (passedNode.ParentNode != null)
                {
                    if (passedNode.ParentNode.Name == "item")
                    {
                        XmlNode passedNodeParent = passedNode.ParentNode;
                        XmlNode parentClone = tempmenuxml.ImportNode(passedNodeParent, false);
                        CreateXMLAttribute("parent", "true", tempmenuxml, parentClone);
                        XmlNode remNode = tempmenuxml.DocumentElement.RemoveChild(passedClone);
                        if (!doneFirstPass)
                        {
                            foreach (XmlNode xn in passedNodeParent.ChildNodes)
                            {
                                if (xn.Name.ToLower() != "nextid")
                                {
                                    if (xn.Attributes["pgid"].Value == passedClone.Attributes["pgid"].Value)
                                    {
                                        XmlNode cloneChild = tempmenuxml.ImportNode(xn, true);
                                        CreateXMLAttribute("isSelected", "true", tempmenuxml, cloneChild);
                                        parentClone.AppendChild(cloneChild);
                                    }
                                    else
                                    {
                                        XmlNode cloneChild = tempmenuxml.ImportNode(xn, true);
                                        CreateXMLAttribute("isSelected", "false", tempmenuxml, cloneChild);
                                        parentClone.AppendChild(cloneChild);
                                    }
                                }
                            }
                            doneFirstPass = true;
                        }
                        else
                        {
                            parentClone.AppendChild(remNode);
                        }
                        tempmenuxml.DocumentElement.AppendChild(parentClone);
                        SetMenuXML(parentClone, tempmenuxml, doneFirstPass, xmlMenu);
                    }
                }
            }
        }

       

    }
}