using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

 namespace LawMate.UserControls
{
    public delegate void WebBrowserDocumentCompletedEventHandler(object sender, WebBrowserDocumentCompletedEventArgs e);
    public delegate void WebBrowserNavigatingEventHandler(object sender, WebBrowserNavigatingEventArgs e);
    public delegate void WebBrowserStatusTextChangedEventHandler(object sender, EventArgs e);
    public delegate void WebBrowserProgressChangedEventHandler(object sender, WebBrowserProgressChangedEventArgs e);

    public partial class ucWB : UserControl
    {
        public bool OpenLinksInNewWindows = false;
        public bool currentOLINW = false;
        public event WebBrowserDocumentCompletedEventHandler DocumentCompleted;
        public event WebBrowserNavigatingEventHandler DocumentNavigating;
        public event WebBrowserStatusTextChangedEventHandler StatusTextChanged;
        public event WebBrowserProgressChangedEventHandler ProgressChanged;
        public ucWB()
        {
            InitializeComponent();
            webBrowser1.AllowWebBrowserDrop = false;
            
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.WebBrowserShortcutsEnabled = true;
            webBrowser1.IsWebBrowserContextMenuEnabled = true;
            WebBrowser.StatusTextChanged += new EventHandler(WebBrowser_StatusTextChanged);

        }

        void WebBrowser_StatusTextChanged(object sender, EventArgs e)
        {
            if (StatusTextChanged != null)
                StatusTextChanged(this, e);
        }

        public WebBrowser WebBrowser
        {
            get { return webBrowser1; }
        }

        public Uri Url
        {
            get
            {
                return webBrowser1.Url;
            }
            set
            {
                currentOLINW = false;

                this.webBrowser1.Url = value;
                //this.Enabled = false;
            }
        }

        public void WriteContent(string content)
        {
            currentOLINW = false;
            //webBrowser1.Url = new Uri("about:blank");

            //remove the encoding line on sept 9 2009 because of display issue switching from pdf to html
            if (webBrowser1.Document != null)
                webBrowser1.Document.Encoding = "UTF-8";
            webBrowser1.DocumentText = content;
            //this.Enabled = true;
        }

        public void WriteContent(System.IO.Stream content)
        {
            currentOLINW = false;
            webBrowser1.DocumentStream = content;
            // this.Enabled = true;
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                //show browser if navigation succeeds
                //browser reamins hidden if user cancels nav
                webBrowser1.Visible = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                if (currentOLINW)
                {

                    e.Cancel = true;
                    webBrowser1.Visible = true;
                    if(!e.Url.ToString().ToLower().StartsWith("javascript:"))
                        webBrowser1.Navigate(e.Url, true);
                }
                else
                {
                    //hide browser when nav starts
                    if (e.Url.ToString() != "javascript:///")
                        webBrowser1.Visible = false;
                    if (DocumentNavigating != null)
                        DocumentNavigating(this, e);
                }
                currentOLINW = OpenLinksInNewWindows;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            try
            {
                if (DocumentCompleted != null)
                    DocumentCompleted(this, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void Print()
        {
            webBrowser1.ShowPrintDialog();
        }
        public void PrintPreview()
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                if (ProgressChanged != null)
                    ProgressChanged(this, e);

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void ucWB_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control & !e.Alt & !e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.C:
                            CopyText();
                            break;
                        case Keys.A:
                            SelectAllText();
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(new LMException(x.Message));
            }
        }

        public void CopyText()
        {
            object o = null;
            webBrowser1.Document.ExecCommand("Copy", false, o);
        }

        public void SelectAllText()
        {
            object o = null;
            webBrowser1.Document.ExecCommand("SelectAll", false, o);
        }


        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.Control & !e.Alt & !e.Shift)
                {
                    object o = null;
                    switch (e.KeyCode)
                    {
                        case Keys.C:

                            webBrowser1.Document.ExecCommand("Copy", false, o);
                            break;
                        case Keys.A:
                            webBrowser1.Document.ExecCommand("SelectAll", false, o);
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(new LMException(x.Message));
            }


        }


    }
}
