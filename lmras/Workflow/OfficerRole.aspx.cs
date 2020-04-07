using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lmras.Workflow
{
    public partial class OfficerRole : System.Web.UI.Page
    {
        public WFHelp myWF = new WFHelp();
        lmDatasets.officeDB.OfficerRoleRow[] orDt;
        System.Data.DataRow rcRow;
        string pgTitle = "";

        public override void Dispose()
        {
            myWF.Dispose();
            base.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string qsGRole = Request.QueryString["grole"];
            if (qsGRole != null)
            {
                myWF.myACM.AtMng.OfficeMng.GetOfficerRole().Load();

                orDt = (lmDatasets.officeDB.OfficerRoleRow[])myWF.myACM.AtMng.OfficeMng.DB.OfficerRole.Select("RoleCode='" + qsGRole + "'", "");
                System.Data.DataTable rcDT = myWF.myACM.AtMng.GetFile().Codes("RoleCode");
                System.Data.DataRow[] rcDr = rcDT.Select("RoleCode='" + qsGRole + "'", "");
                if (rcDr.Length == 1)
                    rcRow = rcDr[0];
                else
                    rcRow = null;
            }
            else
                orDt = null;

            if (rcRow != null)
                pgTitle = rcRow["RoleEng"].ToString();
            
        }

        public string wTitle()
        {
            return pgTitle;
        }

        public lmDatasets.officeDB.OfficerRoleRow[] OrDt()
        {
            return orDt;
        }

        public System.Data.DataRow RcRow()
        {
            return rcRow;
        }
    }
}