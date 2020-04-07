using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atriumBE;
using lmDatasets;

namespace lmras.Workflow
{
    public partial class Step : System.Web.UI.Page
    {
        public WFHelp myWF = new WFHelp();

        public ActivityConfig.ACSeriesRow myACSeries;

        public override void Dispose()
        {
            myWF.Dispose();
            base.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string sc = Request.QueryString["stepcode"];
            string id = Request.QueryString["acseriesid"];

            if (id != null)
                myACSeries = myWF.myACM.DB.ACSeries.FindByACSeriesId(System.Convert.ToInt32(id));
            else
            {
                myACSeries = (ActivityConfig.ACSeriesRow)myWF.myACM.DB.ACSeries.Select("Stepcode='" + sc + "'")[0];

            }
        }
    }
}