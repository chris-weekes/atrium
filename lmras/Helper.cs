using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atriumBE;
using lmDatasets;

namespace lmras
{
    public class Helper
    {
        public static atriumManager Atmng( )
        {
            if(HttpContext.Current.Session["Atmng"]==null)
            {
               
                throw new LoginException("You must log in");
            }
            else
            {
                return (atriumManager)HttpContext.Current.Session["Atmng"];
            }
        }
    }
    public class LoginException:Exception
    { 
        public LoginException(string message)
            :base(message)
        { }
    }

    public static class MyExtensions
    {

        public static string Translate(this System.Data.DataRow dr,string column, atriumBE.FileManager fm)
        {
            string colnm = fm.AtMng.Translate(column);
            if (dr.IsNull(colnm))
                return "";
            else
                return dr[colnm].ToString();

        }

        public static string TranlateLabel(this System.Web.Mvc.HtmlHelper helper, atriumBE.atriumManager Atmng, string EngLabel, string FreLabel)
        {
            if (Atmng==null || Atmng.AppMan.Language.ToUpper() == "ENG")
                return EngLabel;
            else
                return FreLabel;
        }

        public static string ResolveLookup(this System.Web.Mvc.HtmlHelper helper, object id, string list, atriumBE.FileManager fm,string description)
        {
            System.Data.DataTable dt = fm.Codes(list);
            string result = id.ToString();
            System.Data.DataRow dr= dt.Rows.Find(id);
            if (dr == null)
                return result;
            else if (description == null)
            {
                string col = dt.Columns[1].ColumnName;
                return dr.Translate(col, fm);
            }
            else
                return dr.Translate(description, fm);

        }

        public static IHtmlString LabelForStatusCode(this System.Web.Mvc.HtmlHelper helper, string statusCode,  atriumBE.FileManager fm)
        {
            string label = "<span class=\"label{1}\" >{0}</span>";
            string color = "";
            switch(statusCode)
            {
                case "A":
                    color = " label-default statusA";
                    break;
                case "C":
                    color = " label-default statusC";
                    break;
                case "P":
                    color = " label-default statusP";
                    break;
                case "O":
                    color = " label-default statusO";
                    break;
                case "M":
                    color = " label-default statusM";
                    break;
                default:
                    color = "";
                    break;
            }
            return new HtmlString(String.Format(label, ResolveLookup(helper, statusCode, "Status",fm, null) , color) );
        }
    }
}