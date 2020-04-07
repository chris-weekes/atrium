using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lmras.Workflow
{
    public partial class docdisplay : System.Web.UI.Page
    {
        public WFHelp myWF = new WFHelp(false);
        public bool fileSpecified = false;
        public bool isTemplate = false;
        public string templateCode;
        public int docId;
        public int fileId;
        public atriumBE.FileManager myFM;
        public atriumBE.DocManager myDM;

        public override void Dispose()
        {
            myWF.Dispose();
            base.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string qsFileId = Request.QueryString["fileid"];
            string qsTemplateCode = Request.QueryString["templatecode"];
            string qsDocId = Request.QueryString["docid"];

            //is fileid passed in?
            if (qsFileId != null)
            {
                fileSpecified = true;
            }
            else
            {
                fileId=Convert.ToInt32(qsFileId);
            }

            //is templatecode passed in?
            if (qsTemplateCode != null)
            {
                isTemplate = true;
                templateCode = qsTemplateCode;
            }
            else if (qsDocId != null) //is docid passed in?
            {
                docId = Convert.ToInt32(qsDocId);
            }
            else
                throw new Exception("expected query string arguments not present (1)"); //did not provide at least templatecode or docid

            if(!fileSpecified)
                throw new Exception("expected query string arguments not present (2)"); //did not provide fileid ||DEV TEMPLATES:1028654


            if (isTemplate)
            {
                //load template row from template code
                lmDatasets.appDB.TemplateRow tr =myWF.myACM.AtMng.GetTemplate().Load(templateCode, "");
                if (tr==null)
                    throw new Exception("template code not found");

                
                retrieveDoc(tr.DocID);
                
            }
            else
            {
                //lookup document

            }
        }

        private void retrieveDoc(int docId)
        {
            //get file manager from fileid; load doc from template row docid
            myFM = myWF.myACM.AtMng.GetFile(fileId);
            myDM = myFM.GetDocMng();
            lmDatasets.docDB.DocumentRow dr = myDM.GetDocument().Load(docId);
            lmDatasets.docDB.DocContentRow dcr = myDM.GetDocContent().Load(dr.DocRefId, dr.CurrentVersion);
            download(dr);

        }

        private void download (lmDatasets.docDB.DocumentRow dr)
        {

            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/msword"; //for RTF templates
            Response.AddHeader("content-disposition", "inline;filename="+dr.DocId);
            Response.BinaryWrite(dr.DocContentRow.Contents);
            Response.Flush(); 
            Response.End();
        } 
    }
}