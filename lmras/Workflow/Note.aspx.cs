using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lmras.Workflow
{
    public partial class Note : System.Web.UI.Page
    {
        public WFHelp myWF = new WFHelp();

        public bool isInsert=false;
        public bool isEdit=false;
        public bool isDelete = false;
        public string linkTable;
        public int linkId;
        public string docKind;

        public override void Dispose()
        {
            myWF.Dispose();
            base.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //set properties
                string qsInsert = Request.QueryString["insert"];
                if (qsInsert != null && qsInsert.ToUpper() == "Y")
                    isInsert = true;

                linkTable = Request.QueryString["linktable"];
                linkId = Convert.ToInt32(Request.QueryString["linkid"]);
                docKind = Request.QueryString["kind"];


                string qsEdit = Request.QueryString["edit"];
                if (qsEdit != null && qsEdit.ToUpper() == "Y")
                    isEdit = true;

                string qsDelete = Request.QueryString["delete"];
                if (qsDelete != null && qsDelete.ToUpper() == "Y")
                    isDelete = true;

                string acDocId = Request.QueryString["acdocid"];

                if (isEdit)
                {
                    //retrieve acdocumentation row and retrieve values to display in textareas
                    lmDatasets.ActivityConfig.ACDocumentationRow[] acdr = (lmDatasets.ActivityConfig.ACDocumentationRow[])myWF.myACM.DB.ACDocumentation.Select("ACDocId=" + acDocId, "");
                    if (acdr.Length == 1)
                    {
                        linkTable = acdr[0].LinkTable;
                        linkId = acdr[0].LinkId;
                        docKind = acdr[0].Kind;

                        txtEng.Text = acdr[0].TextEng;
                        if(!acdr[0].IsTextFreNull())
                            txtFre.Text = acdr[0].TextFre;
                    }
                }
           
            if (IsPostBack)
            {
                if (isInsert)
                {
                    //create new acdocumentation row and set values
                    lmDatasets.ActivityConfig.ACDocumentationRow acdr = (lmDatasets.ActivityConfig.ACDocumentationRow)myWF.myACM.GetACDocumentation().Add(null);
                    acdr.LinkTable = linkTable.ToLower();
                    acdr.LinkId = linkId;
                    acdr.Kind = docKind.ToLower();
                    acdr.TextEng = Request.Form["oTextEng"].ToString();
                    acdr.TextFre = Request.Form["oTextFre"].ToString();
                    
                    //save new record
                    atLogic.BusinessProcess bp = myWF.myACM.AtMng.GetBP();
                    bp.AddForUpdate(myWF.myACM.AtMng.acMng.GetACDocumentation());
                    bp.Update();
                }
                if (isEdit)
                {
                    //retrieve acdocumentation row and save updated text
                    lmDatasets.ActivityConfig.ACDocumentationRow[] acdr = (lmDatasets.ActivityConfig.ACDocumentationRow[])myWF.myACM.DB.ACDocumentation.Select("ACDocId=" + acDocId, "");
                    if (acdr.Length == 1)
                    {
                        lmDatasets.ActivityConfig.ACDocumentationRow acd = acdr[0];
                        acd.TextEng =  Request.Form["oTextEng"].ToString();
                        acd.TextFre = Request.Form["oTextFre"].ToString();

                        atLogic.BusinessProcess bp = myWF.myACM.AtMng.GetBP();
                        bp.AddForUpdate(myWF.myACM.AtMng.acMng.GetACDocumentation());
                        bp.Update();

                        //redisplay updated text, otherwise leave values alone
                        txtEng.Text = acd.TextEng;
                        if(!acd.IsTextFreNull())
                            txtFre.Text = acd.TextFre;
                    }
                }
                if (isDelete)
                {
                    lmDatasets.ActivityConfig.ACDocumentationRow[] acdr = (lmDatasets.ActivityConfig.ACDocumentationRow[])myWF.myACM.DB.ACDocumentation.Select("ACDocId=" + acDocId, "");
                    if (acdr.Length == 1)
                    {
                        lmDatasets.ActivityConfig.ACDocumentationRow acd = acdr[0];
                        acd.Delete();

                        atLogic.BusinessProcess bp = myWF.myACM.AtMng.GetBP();
                        bp.AddForUpdate(myWF.myACM.AtMng.acMng.GetACDocumentation());
                        bp.Update();
                    }
                }
            }
                
        }

        public string DisplayCodeString()
        {
            if (linkTable.ToLower() == "series")
            {
                lmDatasets.ActivityConfig.SeriesRow[] srs = (lmDatasets.ActivityConfig.SeriesRow[])myWF.myACM.DB.Series.Select("seriesid=" + linkId, "");
                if (srs.Length == 1)
                    return srs[0].SeriesCode;
            }
            if (linkTable.ToLower() == "acseries")
            {
                lmDatasets.ActivityConfig.ACSeriesRow[] acss = (lmDatasets.ActivityConfig.ACSeriesRow[])myWF.myACM.DB.ACSeries.Select("acseriesid=" + linkId, "");
                if (acss.Length == 1)
                    return acss[0].StepCode;
            }
            if (linkTable.ToLower() == "activityfield")
            {
                lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ACSeries.Select("activityfieldid=" + linkId, "");
                if (afrs.Length == 1)
                    return "Block " + afrs[0].Step + ", Sequence " + afrs[0].Seq + " of Step Code " + afrs[0].ACSeriesRow.StepCode;
            }
            return "";
 
        }


        public lmDatasets.ActivityConfig.SeriesRow CurrentSeries()
        {
            if (linkTable.ToLower() == "series")
            {
                lmDatasets.ActivityConfig.SeriesRow[] srs = (lmDatasets.ActivityConfig.SeriesRow[])myWF.myACM.DB.Series.Select("seriesid=" + linkId, "");
                if (srs.Length == 1)
                    return srs[0];
            }
            if (linkTable.ToLower() == "acseries")
            {
                lmDatasets.ActivityConfig.ACSeriesRow[] acss = (lmDatasets.ActivityConfig.ACSeriesRow[])myWF.myACM.DB.ACSeries.Select("acseriesid=" + linkId, "");
                if (acss.Length == 1)
                    return acss[0].SeriesRow;
            }
            if (linkTable.ToLower() == "activityfield")
            {
                lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ACSeries.Select("activityfieldid=" + linkId, "");
                if (afrs.Length == 1)
                    return afrs[0].ACSeriesRow.SeriesRow;
            }
            return null;
        }

        public lmDatasets.ActivityConfig.ACSeriesRow CurrentAcSeries()
        {
            if (linkTable.ToLower() == "series")
            {
                return null;
            }
            if (linkTable.ToLower() == "acseries")
            {
                lmDatasets.ActivityConfig.ACSeriesRow[] acss = (lmDatasets.ActivityConfig.ACSeriesRow[])myWF.myACM.DB.ACSeries.Select("acseriesid=" + linkId, "");
                if (acss.Length == 1)
                    return acss[0];
            }
            if (linkTable.ToLower() == "activityfield")
            {
                lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ACSeries.Select("activityfieldid=" + linkId, "");
                if (afrs.Length == 1)
                    return afrs[0].ACSeriesRow;
            }
            return null;
        }

    }
}