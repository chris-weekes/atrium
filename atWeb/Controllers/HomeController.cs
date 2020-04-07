using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atriumBE;

namespace lmras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return Redirect("~/default.aspx");
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ReloadConfig()
        {
            atriumBE.atriumManager atmng = Helper.Atmng();
            atmng.acMng.LoadAllConfigInfo();
            atmng.LoadDDInfo();

            return RedirectToAction("Index", "Search");
        }
        public ActionResult About()
        {

            atriumBE.atriumManager atmng = Helper.Atmng();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            atriumBE.atriumManager atmng = Helper.Atmng();

            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        public ActionResult Login()
        {
            if (this.Session["Atmng"] == null)
                return View();
            else
                return RedirectToAction("Index", "Search");
        }

        public ActionResult Logout()
        {
            this.Session["Atmng"] = null;
            return RedirectToAction("Login", "Home");
        }

        public ActionResult LoginFailed()
        {
            ViewBag.LoginFailed = "true";
            ViewBag.Message = "Username or password is incorrect. Please try again. / Nom d'utilisateur ou mot de passe incorrect. Veuillez essayer de nouveau.";
            return View("Login");
        }

        public ActionResult Lang()
        {
            atriumBE.atriumManager atmng = Helper.Atmng();
            if (atmng.AppMan.Language.ToUpper() == "ENG")
                atmng.AppMan.Language = "FRE";
            else
                atmng.AppMan.Language = "ENG";

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldPassword,string newPassword,string confPassword)
        {
            try
            {
                if (newPassword != confPassword) { throw new Exception("Password does not match."); }
                atriumBE.atriumManager atmng = Helper.Atmng();
                lmDatasets.SecurityDB.secUserRow sur = atmng.SecurityManager.CurrentUser;
                atmng.SecurityManager.GetsecUser().ChangeSQLPassword(sur, newPassword, oldPassword);
                return RedirectToAction("Index", "Search");
            }
            catch(Exception x)
            {
                ViewBag.Error = x.Message;
                return View();
            }
        }

        public ActionResult VerifyLogin(string username,string password,string language,string db)
        {
            try
            {
              

                atriumBE.Servers servers = new atriumBE.Servers();
                servers.ReadXml(Server.MapPath("~") + "\\serverlist.xml");
                Servers.ServerRow sr= servers.Server.FindByserverName(db);

                AtriumApp app = new AtriumApp(username, password, language, sr,password);

                //if(this.HttpContext.Cache["ACCONFIG"]==null)
                //{
                //    app.AtMng.acMng.LoadAllConfigInfo();
                //    app.AtMng.acMng.DB.WriteXml("test.xml");
                //    this.HttpContext.Cache.Insert("ACCONFIG", "LOADED");
                //}
                //else
                //{
                    
                //    app.AtMng.acMng.DB.ReadXml("test.xml");
                //}
                app.AtMng.acMng.LoadAllConfigInfo();
                app.AtMng.LoadDDInfo();

                this.Session["Atmng"] = app.AtMng; 
                return RedirectToAction("Index", "Search");
            }
            catch(Exception x)
            {
                return RedirectToAction("LoginFailed");
            }
            
        }
    }
}