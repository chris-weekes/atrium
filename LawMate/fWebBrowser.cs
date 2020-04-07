using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;

namespace LawMate
{

    public partial class fWebBrowser : fBase
    {


        public event WebBrowserDocumentCompletedEventHandler DocumentCompleted;

        private string myServer;
        private string WhatsNewPath;
        private string DeskbookHomePath;
        private string DeskbookSearchPath;
        private string DeskbookCheatSheet;
        private string DeskbookQuickSearchHelpPath;
        private bool AppStartup = false;
        private bool autoClose = false;

        CookieContainer jar = new CookieContainer();
        System.Net.CredentialCache cc = new System.Net.CredentialCache();

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);



        public bool AutoCloseWhatsNew
        {
            get { return autoClose; }
        }

        public fWebBrowser()
        {
            InitializeComponent();
        }
        string authHdr = "";
        public fWebBrowser(Form f)
            : base(f)
        {
            InitializeComponent();


            myServer = AtMng.AppMan.ServerInfo.helpUrl;
            WhatsNewPath = AtMng.AppMan.ServerInfo.whatsnew;
            DeskbookHomePath = AtMng.AppMan.ServerInfo.DeskbookHomePath;
            DeskbookSearchPath = AtMng.AppMan.ServerInfo.DeskbookSearchPath;
            DeskbookCheatSheet = AtMng.AppMan.ServerInfo.DeskbookCheatSheet;
            DeskbookQuickSearchHelpPath = AtMng.AppMan.ServerInfo.DeskbookQuickSearchHelpPath;

            if (AtMng.AppMan.Language == "FRE")
            {
                WhatsNewPath = AtMng.AppMan.ServerInfo.whatsnew.Replace("english", "francais");
                DeskbookHomePath = AtMng.AppMan.ServerInfo.DeskbookHomePath.Replace("english", "francais");
                DeskbookSearchPath = AtMng.AppMan.ServerInfo.DeskbookSearchPath.Replace("english", "francais");
                DeskbookCheatSheet = AtMng.AppMan.ServerInfo.DeskbookCheatSheet.Replace("english", "francais");
                DeskbookQuickSearchHelpPath = AtMng.AppMan.ServerInfo.DeskbookQuickSearchHelpPath.Replace("english", "francais");
            }

            //if (AtMng.AppMan.UseProxy)
            //{

            //    authHdr = "Authorization: Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(AtMng.AppMan.myUser + ":" + AtMng.AppMan.myFWPassword)) + "\r\n";

            //  //  ucWB1.webBrowser1.Navigating += webBrowser1_Navigating;
            //}


        }
        //bool _redirected = false;
        //void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        //{
        //    if (_redirected)
        //    {
        //        _redirected = false;
        //        return;
        //    }
        // //   var newPage = e.Url.ToString();// BaseUrl + e.Uri.AbsolutePath;

        //    e.Cancel = true;
        //    _redirected = true;
        //    ucWB1.webBrowser1.Navigate(e.Url, null, null, authHdr);

        //}

        public void AppStartupSetToTrue()
        {
            AppStartup = true;
        }

        //public void NavigateFull(string fullURL)
        //{
        //    ucWB1.WebBrowser.Navigate(fullURL, null, null, authHdr);
        //    tbAddress.Text = fullURL;
        //}

        public void NavigateMyServer(string relURL)
        {
            string address = myServer + relURL;

            Uri u = new Uri(address);
            if (AtMng.AppMan.UseProxy)
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; }; 

                System.Net.NetworkCredential nc = new System.Net.NetworkCredential(AtMng.AppMan.myUser, AtMng.AppMan.myFWPassword);
                Uri up = new Uri(AtMng.AppMan.ServerInfo.remoteUrl);
                cc.Add(up, "Digest", nc);
                cc.Add(up, "Basic", nc);


                System.Net.HttpWebRequest wcinit = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(up);
              

                wcinit.CookieContainer = jar;
                wcinit.Credentials = cc;
                wcinit.PreAuthenticate = true;
                wcinit.UnsafeAuthenticatedConnectionSharing = true; //for kerberos
                try
                {
                    System.Net.HttpWebResponse hwinit = (System.Net.HttpWebResponse)wcinit.GetResponse();

                    hwinit.Close();
                    System.Diagnostics.Trace.WriteLine("Ready to start Lawmate...");
                }
                catch (Exception x)
                {
                    System.Diagnostics.Trace.WriteLine(x.Message);

                  //  return;
                }
                for (int i = 0; i < jar.GetCookies(u).Count; i++)
                {
                    Cookie c = jar.GetCookies(u)[i];
                    InternetSetCookie(address, c.Name, c.Value);
                }
            }


            ucWB1.WebBrowser.Navigate(u, null, null, authHdr);
            tbAddress.Text = address;

        }
        public void NavigateToDeskbookHome()
        {
            NavigateMyServer(DeskbookHomePath);
        }

        public void NavigateToWhatsNew()
        {
            NavigateMyServer(WhatsNewPath);
        }

        public void NavigateToDeskbookSearch()
        {
            NavigateMyServer(DeskbookSearchPath);
        }

        public void NavigateToDeskbookCheatSheet()
        {
            NavigateMyServer(DeskbookCheatSheet);
        }

        private void ucWB1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (AppStartup && e.Url.ToString() == myServer + WhatsNewPath)
                {
                    HtmlElement elmt = ucWB1.WebBrowser.Document.GetElementById("LastModDate");
                    if (elmt != null)
                    {
                        //DateTime lastMod = Convert.ToDateTime(elmt.InnerText.Substring(16, 10));
                        DateTime lastMod = DateTime.Parse(elmt.InnerText, new System.Globalization.CultureInfo("ja-JP"));
                        DateTime lastDismissedWhatsNew = AtMng.OfficeMng.GetOfficerPrefs().GetPref(atriumBE.OfficerPrefsBE.DismissWhatsNew, lastMod);
                        autoClose = (lastDismissedWhatsNew > lastMod);
                        cmdDismiss.Visible = Janus.Windows.UI.InheritableBoolean.True;
                        this.Text = Properties.Resources.WhatsNew;
                    }
                    else
                    {
                        autoClose = true;
                    }
                    if (DocumentCompleted != null)
                        DocumentCompleted(this, e);

                    AppStartup = false;
                }
                else
                {
                    cmdDismiss.Visible = Janus.Windows.UI.InheritableBoolean.False;
                    if (ucWB1.WebBrowser.Document.Title.Length > 0)
                        this.Text = ucWB1.WebBrowser.Document.Title;
                    else
                        this.Text = "Atrium Browser";
                }

                if (ucWB1.WebBrowser.CanGoBack)
                    cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                if (ucWB1.WebBrowser.CanGoForward)
                    cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                else
                    cmdForward.Enabled = Janus.Windows.UI.InheritableBoolean.False;

                if (!ucWB1.WebBrowser.IsDisposed && ucWB1.WebBrowser.Url != null && ucWB1.WebBrowser.Url.ToString() != "")
                    tbAddress.Text = ucWB1.WebBrowser.Url.ToString();
            }
            catch (Exception x)
            {
                autoClose = true;
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdBack":
                        ucWB1.WebBrowser.GoBack();
                        break;
                    case "cmdForward":
                        ucWB1.WebBrowser.GoForward();
                        break;
                    case "cmdRefresh":
                        ucWB1.WebBrowser.Refresh();
                        break;
                    case "cmdDismiss":
                        AtMng.OfficeMng.GetOfficerPrefs().SetPref(atriumBE.OfficerPrefsBE.DismissWhatsNew, DateTime.Now);
                        this.Close();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucWB1_StatusTextChanged(object sender, EventArgs e)
        {
            try
            {
                UserControls.ucWB wb = (UserControls.ucWB)sender;
                uiStatusBar1.Panels[0].Text = wb.WebBrowser.StatusText;
            }
            catch (Exception x)
            {
                // do nothing
            }
        }

        private void ucWB1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.MaximumProgress > 0 && e.CurrentProgress < e.MaximumProgress)
            {
                UserControls.ucWB wb = (UserControls.ucWB)sender;
                uiStatusBar1.Panels[1].ProgressBarValue = System.Convert.ToInt32(100 * e.CurrentProgress / e.MaximumProgress);
                if (e.CurrentProgress == e.MaximumProgress)
                    uiStatusBar1.Panels[1].ProgressBarValue = 0;
            }
        }

    }
}