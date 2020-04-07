using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Caching;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using atriumBE;
using lmDatasets;

namespace lmras.Deskbook
{
    public partial class workflow : System.Web.UI.Page
    {
        public ACManager myACM;
        public ActivityConfig.SeriesRow mySeries;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = ConfigurationManager.AppSettings["DBConnUserName"];
            string pwd = ConfigurationManager.AppSettings["DBConnPassword"];


            AtriumApp appMan = new AtriumApp(user, pwd, "ENG", "DATABASE1");
            atriumManager atMng = appMan.AtMng;
            myACM = atMng.acMng;
            myACM.LoadAllConfigInfo();

            string sc = Request.QueryString["sc"];
            string id = Request.QueryString["id"];

            if (id != null)
                mySeries = myACM.DB.Series.FindBySeriesId(System.Convert.ToInt32(id));
            else
            {
                mySeries=(ActivityConfig.SeriesRow)myACM.DB.Series.Select("Seriescode='"+sc+"'")[0];

            }

        }
    }
}