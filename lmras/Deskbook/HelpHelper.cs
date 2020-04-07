using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using System.Configuration;

namespace lmras
{
    public class HelpHelper
    {

        public static XmlDocument LoadXmlFile(string filename, atriumDAL.atriumDALManager atDal)
        {
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true")
            {
                lmDatasets.HelpDB.hlpXmlDataTable dt = atDal.GethlpXml().Load(filename);
                if (dt.Rows.Count == 1)
                {
                    XmlDocument doc = new XmlDocument();
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
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Configuration.ConfigurationManager.AppSettings["LocalPathToXML"] + filename);
                return doc;
 
            }
                
        }

        public static XslCompiledTransform LoadXslTransformFile(string filename, atriumDAL.atriumDALManager atDal)
        {
            if (ConfigurationManager.AppSettings["LoadXMLFromDB"] == "true")
            {
                lmDatasets.HelpDB.hlpXmlDataTable dt = atDal.GethlpXml().Load(filename);
                if (dt.Rows.Count == 1)
                {
                    XslCompiledTransform doc = new XslCompiledTransform();

                    //System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    //Byte[] bytes = encoding.GetBytes(dt[0].Contents);
                    //MemoryStream ms = new MemoryStream(bytes);

                    StringReader sr = new StringReader(dt[0].Contents);
                    XmlReader reader =XmlReader.Create(sr);
                    doc.Load(reader);
                    return doc;
                }
                else
                    throw new Exception("OOPS! The XSL Transform file could not be found. Please contact an administrator.");
            }
            else
            {
                XslCompiledTransform doc = new XslCompiledTransform();
                doc.Load(ConfigurationManager.AppSettings["LocalPathToXSL"] + filename);
                return doc;
            }
        }


        public static XslCompiledTransform LoadXslTransformFile2(string filename, string strPath, atriumDAL.atriumDALManager atDal, bool isCommon)
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

        public static XmlDocument LoadXmlFile2(string filename, string strPath, atriumDAL.atriumDALManager atDal, bool isCommon)
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



        public static string DoBreadcrumb(atriumDAL.atriumDALManager atDal, XmlDocument xmlMenu, string PgId, string lang)
        {
            XslCompiledTransform xslBreadcrumb = HelpHelper.LoadXslTransformFile("breadcrumb.xsl", atDal);

            XmlDocument cMenu = new XmlDocument();
            cMenu.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?><menu></menu>");

            XmlNode cMenuNode = xmlMenu.SelectSingleNode("//item[@pgid='" + PgId + "']");

            if (cMenuNode != null)
            {
                XmlNode importNode = cMenu.ImportNode(cMenuNode, false);
                cMenu.DocumentElement.AppendChild(importNode);
                SetParentBreadcrumbNode(importNode, xmlMenu, cMenu);
            }

            XsltArgumentList xslarg = new XsltArgumentList();
            xslarg.AddParam("lang", "", lang);

            StringWriter sw = new StringWriter();
            xslBreadcrumb.Transform(cMenu, xslarg, sw);

            string result = sw.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
            sw.Close();
            return result;
        }

        private static void SetParentBreadcrumbNode(XmlNode vNode, XmlDocument origMenuXML, XmlDocument BreadcrumbXml)
        {
            XmlNode OrigPassedNode = origMenuXML.SelectSingleNode("//item[@pgid='" + vNode.Attributes["pgid"].Value + "']");
            if (OrigPassedNode != null)
            {
                if (OrigPassedNode.ParentNode.Name == "item")
                {
                    XmlNode OrigPassedNodeParent = OrigPassedNode.ParentNode;
                    XmlNode parentClone = BreadcrumbXml.ImportNode(OrigPassedNodeParent, false);
                    XmlNode vNodeCopy = BreadcrumbXml.SelectSingleNode("//item[@pgid='" + vNode.Attributes["pgid"].Value + "']");
                    BreadcrumbXml.DocumentElement.InsertBefore(parentClone, vNode);
                    SetParentBreadcrumbNode(parentClone, origMenuXML, BreadcrumbXml);
                }
            }
        }

        public static string DoMenu(string lang, XmlDocument xmlMenu, string PgId, atriumDAL.atriumDALManager atDal)
        {
            string sOutput = "";
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

                    if (PgId == "1") //set parent attribute, otherwise pgid 1 node is not treated as top level
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

                        if (PgId == "1")
                            CreateXMLAttribute("parent", "true", tempXMLMenu, menuNode);
                        else
                            CreateXMLAttribute("parent", "false", tempXMLMenu, menuNode);

                        tempXMLMenu.DocumentElement.AppendChild(menuNode);
                        SetMenuXML(menuNode, tempXMLMenu, false, xmlMenu);
                    }
                }
            }

            XslCompiledTransform xslMenu = HelpHelper.LoadXslTransformFile("sidemenu.xsl", atDal);
            XsltArgumentList xslarg = new XsltArgumentList();
            xslarg.AddParam("server", "", "");
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