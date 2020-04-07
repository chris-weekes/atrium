using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;

namespace lmras.Base
{
    public class WebPageBase : System.Web.UI.Page
    {
        
        protected override void InitializeCulture()
        {

            base.InitializeCulture();

            if (Request.QueryString["lang"] != null)
            {
                if (Request.QueryString["lang"] == "en")
                    Session["userLang"] = "en";
                else if (Request.QueryString["lang"] == "fr")
                    Session["userLang"] = "fr";
                else if (Session["userLang"] == null)
                    Session["userLang"] = "en";

                if ((String)Session["userLang"] == "en")
                    Session["DBLang"] = "Eng";
                else
                    Session["DBLang"] = "Fre";

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture((string)Session["userLang"]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo((string)Session["userLang"]);
            }

        }
    }
}