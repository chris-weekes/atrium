using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace lmras
{
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string virt = Request.ApplicationPath;
            string ftFld = Server.MapPath(virt + "/fulltext/");
            string website = Request.Url.Host;
            string fmt = "vpath: {0} <br/>host: {1} <br/>ft: {2}";
            Label4.Text = String.Format(fmt,virt,website,ftFld);

            int loop1, loop2;
            System.Collections.Specialized.NameValueCollection coll;

            // Load ServerVariable collection into NameValueCollection object.
            coll = Request.ServerVariables;
            // Get names of all keys into a string array. 
            String[] arr1 = coll.AllKeys;
            for (loop1 = 0; loop1 < arr1.Length; loop1++)
            {
               // Response.Write("Key: " + arr1[loop1] + "<br>");
                String[] arr2 = coll.GetValues(arr1[loop1]);
                for (loop2 = 0; loop2 < arr2.Length; loop2++)
                {
                 //   Response.Write("Value " + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
                }
            }

            Response.Write("Dummy " + GetDummyUrl());
        }

        private string GetDummyUrl()
        {
            System.Web.HttpContext ctx = System.Web.HttpContext.Current;

            string virt = ctx.Request.ApplicationPath;


            string website = ctx.Request.Url.Host;
            if (System.Configuration.ConfigurationManager.AppSettings["HHUseIP"].ToString().ToLower() == "true")
                website = ctx.Request.ServerVariables["LOCAL_ADDR"];

            return "http://" + website + virt + "/fulltext/test2.aspx";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                atriumDAL.atriumDALManager atDAL = new atriumDAL.atriumDALManager(tbUser.Text, tbPwd.Text, tbServer.Text);
                atDAL.LogEvent("MSG", Request.LogonUserIdentity.Name, atDAL.User, atDAL.User, "", "", "Test log in", "");
                if (atDAL.User == null || atDAL.User == "")
                {
                    Label3.Text = "Log in succeded for " + Request.LogonUserIdentity.Name + "<br /><br />";
                }
                else
                    Label3.Text = "Log in succeded for " + atDAL.User + "<br /><br />";

                Assembly asm = Assembly.GetExecutingAssembly();
                this.Label3.Text += "File Version:<br />" + asm.FullName + "<br /><br />";

                this.Label3.Text += "References :" + "<br />";
                AssemblyName[] asmNames = asm.GetReferencedAssemblies();
                foreach (AssemblyName nm in asmNames)
                {
                    this.Label3.Text += nm.FullName + "<br />";
                }



            }
            catch (Exception x)
            {
                Label3.Text = x.Message;
            }
        }
    }
}