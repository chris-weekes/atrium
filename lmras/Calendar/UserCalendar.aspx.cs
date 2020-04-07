using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atriumBE;

namespace lmras.Calendar
{
    public partial class UserCalendar : System.Web.UI.Page
    {
        atriumManager atMng;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AtriumManager"] != null)
                atMng = (atriumManager)Session["AtriumManager"];
            else
            {
                AtriumApp appMan = new AtriumApp("ENG", "DATABASE1");
                atMng = appMan.AtMng;
                //FileManager FM = atMng.GetFile();

                OfficeManager myOfficeMng = atMng.GetOffice(atMng.OfficeLoggedOn.OfficeId);
                myOfficeMng.GetOfficerDelegate().LoadByDelegateToId(atMng.OfficerLoggedOn.OfficerId);
            }
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString[0] != string.Empty )
                {

                 //   atMng = (atriumManager)Session["AtriumManager"];

                    Calendar myCal;
                    int id;

                    try
                    {
                        id = Convert.ToInt32(Request.QueryString[0]);
                    }
                    catch
                    {
                        id = 0;
                    }
                    if (id > 0)
                    {
                        myCal = new Calendar(atMng, id);
                    }
                    else
                    {
                        myCal = new Calendar(atMng);
                    }
                    myCal.ProcessRequest(this.Context); 
                }
            }
        }
    }
}