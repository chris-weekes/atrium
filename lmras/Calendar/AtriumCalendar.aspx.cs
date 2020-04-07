using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atriumBE;
using lmDatasets;

namespace lmras.Calendar
{
    public partial class AtriumCalendar : lmras.Base.WebPageBase
    {
        AtriumApp appMan;
        atriumManager atMng;
        FileManager FM;
        OfficeManager myOfficeMng;

        protected void Page_Load(object sender, EventArgs e)
        {

            appMan = new AtriumApp("ENG", "DATABASE1");

            atMng = appMan.AtMng;
            FM = atMng.GetFile();

            myOfficeMng = atMng.GetOffice(atMng.OfficeLoggedOn.OfficeId);
            myOfficeMng.GetOfficerDelegate().LoadByDelegateToId(atMng.OfficerLoggedOn.OfficerId);

            Session["AtriumManager"] = atMng;

            string url = string.Empty;
            url = ResolveServerUrl("~/Calendar/UserCalendar.aspx");
            url = url.Replace("http://", "");
            int i = 0;

            pnlCalendarLinks.Controls.Add(new LiteralControl("<ul>"));

            foreach (officeDB.OfficerDelegateRow odr in myOfficeMng.DB.OfficerDelegate)
            {
                string link = string.Empty;

                if (odr.WorkAs)
                {
                    atriumDB.ContactRow cr = FM.GetPerson().Load(odr.OfficerId);
                    createCalLink("lnkCal" + i.ToString(), "webcal://" + url + "?contactid=" + odr.OfficerId.ToString(), Resources.LocalizedText.AtriumCalFor + " " + cr.FirstName + " " + cr.LastName);
                    i += 1;
                }
            }

            // create calendar link for self
            createCalLink("lnkCal" + i.ToString(), "webcal://" + url + "?contactid=" + atMng.OfficerLoggedOn.ContactId.ToString(), Resources.LocalizedText.MyCal);
            pnlCalendarLinks.Controls.Add(new LiteralControl("</ul>"));
        }

        private void createCalLink(string ID, string url, string text)
        {

            HyperLink lnkCalendar = new HyperLink(); ;

            lnkCalendar.ID = ID;
            lnkCalendar.NavigateUrl = url;
            lnkCalendar.Text = text;
            pnlCalendarLinks.Controls.Add(new LiteralControl("<li>"));
            pnlCalendarLinks.Controls.Add(lnkCalendar);
            pnlCalendarLinks.Controls.Add(new LiteralControl("</li>"));
            pnlCalendarLinks.Controls.Add(new LiteralControl("<br /><br />")); 

        }

        public string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = ResolveUrl(serverUrl);

            Uri originalUri = HttpContext.Current.Request.Url;

            newUrl = (forceHttps ? "https" : originalUri.Scheme) + "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        public string ResolveServerUrl(string serverUrl)
        {
            return ResolveServerUrl(serverUrl, false);
        }
    }
}