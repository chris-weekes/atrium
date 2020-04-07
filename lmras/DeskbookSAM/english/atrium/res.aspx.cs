using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
/************************************
 * Attention: There is a duplicated res file in Deskbook directory.
 *            If you need to modify this file, you also have to modify
 *            the other one.
 * 
 * 
 * 
 ************************************/
namespace lmras.DeskbookSAM
{
    public partial class res : System.Web.UI.Page
    {
        public atriumDAL.atriumDALManager atDal;
        protected void Page_Load(object sender, EventArgs e)
        {
            //get resource name
            string resName = Request.QueryString["f"];

            Response.Cache.SetExpires(DateTime.Now.AddHours(1));
            Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
            Response.Cache.SetValidUntilExpires(true);
            Response.Cache.VaryByParams["f"] = true;

            if (resName != null)
            {

                //retirieve resource from db
                atDal = new atriumDAL.atriumDALManager(ConfigurationManager.AppSettings["DBConnUserName"], ConfigurationManager.AppSettings["DBConnPassword"], "DATABASE1");

                lmDatasets.HelpDB.hlpImageDataTable dt = atDal.GethlpImage().Load(resName);
                if (dt.Rows.Count == 1)
                {

                    //write resource to stream
                    Response.ContentType = dt[0].ContentType; 
                    Response.BinaryWrite(dt[0].Contents);
                }
            }

       
           // Response.End();
        }
    }
}