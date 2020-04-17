using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Net;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.ServiceModel.Activation;
using System.Web.Caching;

namespace lmras
{
    public class Global : System.Web.HttpApplication
    {

        private const string DummyCacheItemKey = "AtriumService";
      
       
    
     

        protected void Application_Start(object sender, EventArgs e)
        {

            //AreaRegistration.RegisterAllAreas();

            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            if (lmras.Properties.Settings.Default.useAlias)
                System.Runtime.Remoting.Services.TrackingServices.RegisterTrackingHandler(new TrackingHandler());


            RegisterCacheEntry();
           

            Application.Add("DummyPageURL", GetDummyUrl());
        }

        private string GetDummyUrl()
        {
            System.Web.HttpContext ctx = System.Web.HttpContext.Current;

            string virt = ctx.Request.ApplicationPath;


            string website = ctx.Request.Url.Host;
            if (System.Configuration.ConfigurationManager.AppSettings["HHUseIP"].ToString().ToLower() == "true")
                website = ctx.Request.ServerVariables["LOCAL_ADDR"];

            //TFS#54553 CJW 2013-08-28 check for double slash
            if (virt == @"/" || virt == @"\")
                virt = "";

            return "http://" + website + virt + "/fulltext/test2.aspx";
        }

        public void CacheItemRemovedCallback(string key,
            object value, CacheItemRemovedReason reason)
        {

            HitPage();

            // Do the service works

            try
            {
                DoWork();
            }
            catch (Exception x)
            {
                //do nothing
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // If the dummy page is hit, then it means we want to add another item

            // in cache
       //     DummyPageUrl = "http://" + Request.Url.Host + Request.ApplicationPath + "/test.aspx";
            if (HttpContext.Current.Request.Url.ToString().ToLower() ==Application["DummyPageURL"].ToString().ToLower())
            {
                // Add the item in cache and when succesful, do the work.

                RegisterCacheEntry();
            }
        }

        private void RegisterRoutes()
        {


            RouteTable.Routes.Add(new ServiceRoute("Atrium", new WebServiceHostFactory(), typeof(Atrium)));

        }

        private bool RegisterCacheEntry()
        {
            if (null != HttpContext.Current.Cache[DummyCacheItemKey]) return false;

            HttpContext.Current.Cache.Add(DummyCacheItemKey, "Tick", null,
                DateTime.MaxValue, TimeSpan.FromMinutes(5),
                CacheItemPriority.Normal,
                new CacheItemRemovedCallback(CacheItemRemovedCallback));

            return true;
        }

       
        private void HitPage()
        {
            

            WebClient wc = new WebClient();
            //System.Uri address = new Uri(Application["DummyPageURL"].ToString(), true);
            //string html = wc.DownloadString(address);
            wc.DownloadData(Application["DummyPageURL"].ToString());
            wc.Dispose();
        }

        private void DoWork()
        {

            string user = ConfigurationManager.AppSettings["DBConnUserName"];
            string pwd=ConfigurationManager.AppSettings["DBConnPassword"];

            atriumBE.AtriumApp appMan = new atriumBE.AtriumApp(user, pwd, "ENG", "DATABASE1");
            atriumBE.atriumManager batchMan = appMan.AtMng;

          //  batchMan.LogMessage(DummyPageUrl);
            try
            {

                batchMan.acMng.LoadAllConfigInfo();
                batchMan.LoadDDInfo();
                atriumBE.BatchBE batch = batchMan.GetBatch();
                batch.RunAllJobs();

            }
            catch (Exception x)
            {
                batchMan.LogError(x);
                //throw;
            }
            finally
            {
                batchMan.LogMessage("Batch job ran");
                batchMan.Dispose();
                appMan.Dispose();
                batchMan = null;
                appMan = null;
            }
        }
    }
}