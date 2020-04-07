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
    public partial class workflow : System.Web.UI.Page
    {
        public WFHelp myWF=new WFHelp();

        public ActivityConfig.SeriesRow mySeries;

        public override void Dispose()
        {
            myWF.Dispose();
            base.Dispose();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         


            string sc = Request.QueryString["seriescode"];
            string id = Request.QueryString["seriesid"];

            if (id != null)
                mySeries = myWF.myACM.DB.Series.FindBySeriesId(System.Convert.ToInt32(id));
            else if(sc != null && sc.ToString()!="")
                mySeries = (ActivityConfig.SeriesRow)myWF.myACM.DB.Series.Select("Seriescode='" + sc + "'")[0];
        }

    }
}