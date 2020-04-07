using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lmDatasets;
using atriumBE;

namespace lmras.Workflow
{
    public partial class RFInclude : System.Web.UI.Page
    {
        public WFHelp myWF = new WFHelp();
        public ActivityConfig.ACSeriesRow acs;
        public ActivityConfig.ACSeriesRow hostAcs;

        public override void Dispose()
        {
            myWF.Dispose();
            base.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            string id = Request.QueryString["acseriesid"];
            if (id != null)
                acs = myWF.myACM.DB.ACSeries.FindByACSeriesId(System.Convert.ToInt32(id));

            string hostid = Request.QueryString["hostacseriesid"];
            if (hostid != null)
                hostAcs = myWF.myACM.DB.ACSeries.FindByACSeriesId(System.Convert.ToInt32(hostid));
        }
    }
}