using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atriumBE;
using PagedList;
using lmDatasets;

namespace lmras.Controllers
{
    [HandleError]
    public class SearchController : Controller
    {



        //
        // GET: /Search/
        public ActionResult Index()
        {
            atriumManager myAtmng = Helper.Atmng();

            return View();

        }


        public ActionResult Search(string term, string method, int page)
        {
            atriumManager myAtmng = Helper.Atmng();
            appDB.EFileSearchDataTable dt;
            switch (method)
            {
                case "filenumber":
                    dt = myAtmng.FileSearchByFileNumber(term+"%");
                    break;
                case "sin":
                    dt = myAtmng.FileSearchBySIN(term);
                    break;
                case "lastname":
                    dt = myAtmng.FileSearchByLastName(term);
                    break;
                case "fullfilenumber":
                    dt = myAtmng.FileSearchByFullFileNumber(term+"%");
                    break;
                default:
                    throw new Exception("Not a valid search method");

            }
            if (dt.Rows.Count == 1)
            {
                return RedirectToAction("Activity", "File", new { fileid = dt[0]["Fileid"] });
            }
            else if (dt.Rows.Count == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Atmng = myAtmng;
                ViewBag.term = term;
                ViewBag.method = method;
                ViewBag.Action = "Search";

                return View(dt.AsEnumerable().ToPagedList(page, 12));
            }
        }



        public ActionResult RecentFiles(string method, int page)
        {
            atriumManager myAtmng = Helper.Atmng();
            appDB.EFileSearchDataTable dt;
            switch (method)
            {
                case "today":
                    dt = myAtmng.FileSearchByRecentFiles(myAtmng.AppMan.myUser, atDates.StandardDate.Today.BeginDate, atDates.StandardDate.Today.EndDate);
                    break;
                case "thisweek":
                    dt = myAtmng.FileSearchByRecentFiles(myAtmng.AppMan.myUser, atDates.StandardDate.ThisWeek.BeginDate, atDates.StandardDate.ThisWeek.EndDate);
                    break;
                case "lastweek":
                    dt = myAtmng.FileSearchByRecentFiles(myAtmng.AppMan.myUser, atDates.StandardDate.LastWeek.BeginDate, atDates.StandardDate.LastWeek.EndDate);
                    break;
                case "yesterday":
                    dt = myAtmng.FileSearchByRecentFiles(myAtmng.AppMan.myUser, atDates.StandardDate.Yesterday.BeginDate, atDates.StandardDate.Yesterday.EndDate);
                    break;
                default:
                    throw new Exception("Not a valid search method");

            }

            ViewBag.Atmng = myAtmng;
            ViewBag.keyword = "";
            ViewBag.method = method;
            ViewBag.Action = "RecentFiles";

            return View("Search", dt.AsEnumerable().ToPagedList(page, 12));

        }
    }
}