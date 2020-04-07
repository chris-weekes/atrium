using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atriumBE;
using lmDatasets;

namespace lmras.Calendar
{
    public partial class Default : System.Web.UI.Page
    {
        AtriumApp appMan;
        atriumManager atMng;
        FileManager FM;
        OfficeManager myOfficeMng;

        protected void Page_Load(object sender, EventArgs e)
        {

            //try
            //{
            appMan = new AtriumApp("ENG", "DATABASE1");
            //}
            //catch (Exception x)
            //{
            //    string s = x.Message;
            //}
            
            atMng = appMan.AtMng;
            FM = atMng.GetFile();

            myOfficeMng = atMng.GetOffice(atMng.OfficeLoggedOn.OfficeId);
            myOfficeMng.GetOfficerDelegate().LoadByDelegateToId(atMng.OfficerLoggedOn.OfficerId);

            Session["AtriumManager"] = atMng;

            string url = string.Empty;
            url = ResolveServerUrl("~/Calendar/UserCalendar.aspx");
            url = url.Replace("http://", "");

            foreach (officeDB.OfficerDelegateRow odr in myOfficeMng.DB.OfficerDelegate)
            {
                string link = string.Empty;

                if (odr.WorkAs)
                {
                    atriumDB.ContactRow cr = FM.GetPerson().Load(odr.OfficerId);
                    link = "<a href='webcal://" + url + "?contactid=" + odr.OfficerId.ToString() + "'>";
                    Response.Write(link + "Atrium Calendar for " +cr.FirstName + " " + cr.LastName + "</a>");
                    Response.Write("<br />");
                }
            }

            // create calendar link for self
            Response.Write("<a href='webcal://" + url + "?contactid=" + atMng.OfficerLoggedOn.ContactId.ToString() + "'>My Calendar</a>");
            
        }
        
        //public string ResolveUrl(string originalUrl)
        //{    
        //    if (originalUrl == null)        
        //        return null;     
        //    if (originalUrl.IndexOf("://") != -1)        
        //        return originalUrl;     
        //    if (originalUrl.StartsWith("~"))
        //    {        
        //        string newUrl = "";        
        //        if (HttpContext.Current != null)            
        //            newUrl = HttpContext.Current.Request.ApplicationPath + originalUrl.Substring(1).Replace("//", "/");
        //        else            
        //            throw new ArgumentException("Invalid URL: Relative URL not allowed.");                                                
        //        return newUrl;    
        //    }     
        //    return originalUrl;
        //}

        public string ResolveServerUrl(string serverUrl, bool forceHttps)
        {    
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;
     
            string newUrl = ResolveUrl(serverUrl);

            Uri originalUri = HttpContext.Current.Request.Url;    

            newUrl = (forceHttps ? "https" : originalUri.Scheme) +  "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        public string ResolveServerUrl(string serverUrl)
        { 
            return ResolveServerUrl(serverUrl, false);
        }
    }
}