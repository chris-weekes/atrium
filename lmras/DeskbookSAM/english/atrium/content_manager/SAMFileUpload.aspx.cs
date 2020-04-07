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
    public partial class SAMFileUpload : System.Web.UI.Page
    {
        XmlDocument LinkData_filename;
        atriumDAL.atriumDALManager atDal;
        string SAMUser;
        atriumBE.HelpManager atBEHelp;
        public bool NoFiles = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPageTitle();
            if (IsPostBack)
            {
                string btnAction = (string)Request.Form["btnAction"];
                switch (btnAction)
                {
                    case "Upload File":
                        if (FileUploadMulti.HasFile)
                        {
                            foreach (var file in FileUploadMulti.PostedFiles)
                            {
                                // Get the name of the file to upload.
                                string fileName =Path.GetFileName(file.FileName);
                                bool IsFileExist = CheckFileExists(fileName);
                                if (IsFileExist == true)
                                {
                                    Response.Write("<script>alert('FileName: " + fileName + " already exists.  Please rename your local file and try again.')</script>");
                                    Response.Write("<script>window.location.href='" + "SAMFileUpload.aspx" + "'</script>");
                                }
                                else
                                {
                                    BinaryReader sr = new BinaryReader(file.InputStream);
                                    byte[] fileBytes = sr.ReadBytes(file.ContentLength);
                                  
                                    HelpHelper.AddImageFile(fileName, SAMUser, fileBytes, atBEHelp);

                                    LinkData_filename = HelpHelper.LoadXmlFile("images.xml", "", atDal, true);
                                    XmlNode vnn = LinkData_filename.SelectSingleNode("images/nextid");
                                    int newnextid;
                                    newnextid = Convert.ToInt32(vnn.InnerXml) + 1;
                                    vnn.InnerXml = newnextid.ToString();
                                    XmlElement N;
                                    N = LinkData_filename.CreateElement("image");

                                    N.SetAttribute("id", newnextid.ToString());
                                    N.SetAttribute("src", fileName);

                                    int fileExtPos = fileName.LastIndexOf(".");
                                    if (fileExtPos >= 0)
                                        fileName = fileName.Substring(0, fileExtPos);
                                    N.SetAttribute("name", fileName);
                                    XmlNode pN = LinkData_filename.SelectSingleNode("//container[@id='1']");
                                    pN.AppendChild(N);
                                    HelpHelper.SaveXmlFile("images.xml", LinkData_filename, atBEHelp, true);


                                    // Confirm file saved and redirect to previous page if more files to be uploaded
                                    Response.Write("<script>alert('Image has uploaded successfully')</script>");
                                    Response.Write("<script>window.location.href='" + "SAMImages.aspx" + "'</script>");
                                }

                            }
                        }
                        else
                        {
                            NoFiles = true;
                        }
                        break;
                }

            }
        }

        bool CheckFileExists(string fileName)
        {
            bool isFileExist = false;
            lmDatasets.HelpDB.hlpImageRow imgDR = (lmDatasets.HelpDB.hlpImageRow)atBEHelp.GethlpImage().Load(fileName);
            if (imgDR != null)
                isFileExist = true;
            return isFileExist;

        }

        protected void FileUpload1_DataBinding(object sender, EventArgs e)
        {

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


            atriumBE.AtriumApp appMan = Global.Login();
            atDal = appMan.DALMngrX;// new atriumDAL.atriumDALManager(user, pwd, "DATABASE1");
            atBEHelp = appMan.AtMng.HelpMng();
            SAMUser = appMan.AtMng.OfficerLoggedOn.UserName;



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