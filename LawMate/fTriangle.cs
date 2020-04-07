using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

 namespace LawMate
{
    public partial class fTriangle : Form
    {
        System.Collections.Stack SeriesStack = new System.Collections.Stack();
        lmDatasets.ActivityConfig.SeriesRow Sr;
        lmDatasets.ActivityConfig.ACSeriesRow ACSr;
        atriumBE.atriumManager atmng;
        Workflow.Diagram diagram;
        bool StepOrConnectorSelected = false;
        
        public string myServer;


        public fTriangle()
        {
            InitializeComponent();
        }

        bool flowOrSeriesPassedOnConstructor = true;
        public fTriangle(atriumBE.atriumManager Atmng)
        {
            InitializeComponent();
            atmng = Atmng;
            ucWorkflowLegend1.InitLegend(Atmng.GetFile());
            ucWorkflowHeader1.Init(Atmng);
            uiPanel1.Activate();

            UIHelper.ComboBoxInit("vSeriesType", seriesGridEX.DropDowns["ddSeriesType"], atmng.GetFile());
            seriesBindingSource.DataSource = atmng.acMng.DB;

            myServer = atmng.AppMan.ServerInfo.helpUrl;
            this.WindowState = FormWindowState.Maximized;
            //cmdMailConnectors.Checked = Janus.Windows.UI.InheritableBoolean.True;
            uiCheckBox1.Checked = true;
            //ACSr = acr;
            flowOrSeriesPassedOnConstructor = false;
            Sr = CurrentSeries();

            Navigate(Sr);

            // InitDiagram();

        }

        public fTriangle(lmDatasets.ActivityConfig.SeriesRow sr, atriumBE.atriumManager Atmng)
        {
            InitializeComponent();
            atmng = Atmng;
            ucWorkflowLegend1.InitLegend(Atmng.GetFile());
            ucWorkflowHeader1.Init(Atmng);
            //uiPanel1.Activate();
            pnlLeft.Activate();
            this.WindowState = FormWindowState.Maximized;
            UIHelper.ComboBoxInit("vSeriesType", seriesGridEX.DropDowns["ddSeriesType"], atmng.GetFile());
            seriesBindingSource.DataSource = atmng.acMng.DB;

            myServer = atmng.AppMan.ServerInfo.helpUrl;
            
            //cmdMailConnectors.Checked = Janus.Windows.UI.InheritableBoolean.True;
            uiCheckBox1.Checked = true;
            //ACSr = acr;
            Sr = sr;

            Navigate(Sr);

            // InitDiagram();

        }

        public fTriangle(lmDatasets.ActivityConfig.ACSeriesRow acr,atriumBE.atriumManager Atmng)
        {
            InitializeComponent();
            atmng = Atmng;
            ucWorkflowLegend1.InitLegend(Atmng.GetFile());
            ucWorkflowHeader1.Init(Atmng);
            pnlLeft.Activate();
            this.WindowState = FormWindowState.Maximized;
            UIHelper.ComboBoxInit("vSeriesType", seriesGridEX.DropDowns["ddSeriesType"], atmng.GetFile());
            seriesBindingSource.DataSource = atmng.acMng.DB;

            myServer = atmng.AppMan.ServerInfo.helpUrl;
            //cmdMailConnectors.Checked = Janus.Windows.UI.InheritableBoolean.True;
            uiCheckBox1.Checked = true;

            ACSr = acr;
            Sr = acr.SeriesRow;

            InitDiagram();
            Navigate(ACSr);
            
           // InitDiagram();

        }
        public void Navigate(lmDatasets.ActivityConfig.ACSeriesRow acsr)
        {
            StepOrConnectorSelected = true;

            //TFS#54513 CJW 2013-8-23 switched to plain concat for url
            Uri server=new Uri(  myServer);
            if(UIHelper.AtMng.AppMan.Language.ToUpper()=="ENG" &&!acsr.IsHelpENull())
                webBrowser1.Navigate(myServer+acsr.HelpE);
            else if(!acsr.IsHelpFNull())
                webBrowser1.Navigate(myServer+acsr.HelpF);

      
            
            //InitDiagram();
        }

        public void Navigate(lmDatasets.ActivityConfig.SeriesRow sr)
        {
            //TFS#54513 CJW 2013-8-23 switched to plain concat for url
            if (myServer == null)
                return;

            Uri server = new Uri(myServer);
            if (UIHelper.AtMng.AppMan.Language.ToUpper() == "ENG" && !sr.IsHelpLinkENull())
                    webBrowser1.Navigate(myServer+sr.HelpLinkE);
            else if(!sr.IsHelpLinkFNull())
                webBrowser1.Navigate(myServer+sr.HelpLinkF);

            //InitDiagram();
        }

        private void SetWorkflowName(lmDatasets.ActivityConfig.SeriesRow sr)
        {
            ucWorkflowHeader1.SetWorkflow(sr);
            //if (UIHelper.AtMng.AppMan.Language.ToUpper() == "ENG")
            //    ebWorkflowName.Text = "(" + sr.SeriesCode + ") " + sr.SeriesDescEng;
            //else
            //    ebWorkflowName.Text = "(" + sr.SeriesCode + ") " + sr.SeriesDescFre;
        }

        private void InitDiagram()
        {
            if (diagram == null)
            {
                diagram = new Workflow.Diagram(panel1.CreateGraphics());
            }
            
            diagram.Reset();
            
            diagram.DrawMailConnectors = !uiCheckBox1.Checked;
            diagram.DrawEnableDisableLinkConnectors = !chkHideEnables.Checked;
            diagram.DrawBFOnlyConnectors = !chkHideBFOnly.Checked;

            
            if (Sr != null)
            {
                diagram.Draw(Sr);
                SetWorkflowName(Sr);
                if (diagram.SelectedStep != null)
                {
                    ucWorkflowHeader1.SetStep(diagram.SelectedStep.myACS);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (diagram != null)
                    diagram.Refresh();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                ebAddress.Text = webBrowser1.Url.ToString();
                //tbAddress.Text = webBrowser1.Url.ToString();
                //URLStack.Push(webBrowser1.Url);

                //if (URLStack.Count < 2)
                //    cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //else
                //    cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                if (!StepOrConnectorSelected)
                {

                    lmDatasets.ActivityConfig.SeriesRow[] nsr;
                    if (UIHelper.AtMng.AppMan.Language.ToUpper() == "FRE")
                        nsr = (lmDatasets.ActivityConfig.SeriesRow[])atmng.acMng.DB.Series.Select("'" + myServer + "'+HelpLinkF='" + e.Url.GetLeftPart(UriPartial.Query) + "'");
                    else
                        nsr = (lmDatasets.ActivityConfig.SeriesRow[])atmng.acMng.DB.Series.Select("'" + myServer + "'+HelpLinkE='" + e.Url.GetLeftPart(UriPartial.Query) + "'");



                    if (nsr.Length > 0)
                    {
                        if (!nsr[0].IsHelpLinkENull())
                        {
                            Sr = nsr[0];
                            ACSr = null;
                            InitDiagram();
                            //pnlRight.AutoHide = false;
                            //cmdMailConnectors.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                        }

                        seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", nsr[0].SeriesId);
                    }
                    else
                    {
                        //ebWorkflowName.Text = "";
                        //Sr = null;
                        //ACSr = null;
                        //pnlRight.AutoHide = true;
                        //cmdMailConnectors.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                        //if (diagram != null)
                        //{
                            //diagram.Reset();
                            //diagram.Refresh();
                        //}
                    }
                }
                else
                    StepOrConnectorSelected = false;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Workflow.Step s = diagram.HitStep(e.Location);
                if (s != null)
                {
                    if (s.GetType() == typeof(Workflow.SubProcess))
                    {
                        seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", s.myACS.SubseriesId);

                        //lmDatasets.ActivityConfig.SeriesRow nsr = (lmDatasets.ActivityConfig.SeriesRow)atmng.acMng.DB.Series.FindBySeriesId(s.myACS.SubseriesId);
                        //Sr = nsr;
                        //ACSr = null;
                        //if (!nsr.IsHelpLinkENull())
                        //    Navigate(nsr);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                if (e.Command.Key == "cmdBack")
                {
                    SeriesStack.Pop(); // remove current series;
                    int SeriesId = (int)SeriesStack.Pop(); //return previous series
                    BackButtonSelected = true;
                    seriesBindingSource.Position = seriesBindingSource.Find("SeriesId", SeriesId);

                }
                //if (e.Command.Key == "cmdMailConnectors")
                //    InitDiagram();
                //if (e.Command.Key == "cmdHideBF")
                //    InitDiagram();
                //if(e.Command.Key == "cmdImage")
                //{
                                        
                //        saveFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
                //        saveFileDialog1.FileName =  this.CurrentSeries().SeriesDescEng + ".bmp";
                //        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //        {
                //            string saveas = saveFileDialog1.FileName;
                //            diagram.SaveAsImg(saveas);
                //        }
                        
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager1_CommandMouseHover(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                if(e.Command.Key=="cmdBack")
                {
                    if (e.Command.Enabled == Janus.Windows.UI.InheritableBoolean.True)
                    {
                        int CurrentSeriesId = (int)SeriesStack.Pop();
                        int PreviousSeriesId = (int)SeriesStack.Peek();
                        lmDatasets.ActivityConfig.SeriesRow[] sra = (lmDatasets.ActivityConfig.SeriesRow[])atmng.acMng.DB.Series.Select("SeriesId=" + PreviousSeriesId);
                        //lmDatasets.ActivityConfig.SeriesRow sr = atmng.acMng.GetSeries().Load(PreviousSeriesId);
                        atriumBE.FileManager FMforTranslation=atmng.GetFile();
                        e.Command.ToolTipText =  sra[0][UIHelper.Translate(FMforTranslation, "SeriesDescEng")].ToString();
                        SeriesStack.Push(CurrentSeriesId);
                    }
                    else
                        e.Command.ToolTipText = "";
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                Workflow.Step s = diagram.HitStep(e.Location);
                if (s != null)
                {
                    diagram.SelectStep(s);
                    ucWorkflowHeader1.SetStep(s.myACS);
                    atriumBE.FileManager FMforTranslation=atmng.GetFile();
                    StepOrConnectorSelected = true;
                    if (!s.myACS.IsNull(UIHelper.Translate(FMforTranslation,"HelpE")))
                    {
                        
                        Navigate(s.myACS);
                    }
                    
                }
                //else
                //{
                //    Workflow.Connector c = diagram.HitConnector(e.Location);
                //    if (c != null)
                //    {
                //        if(!c.myACD.
                //        diagram.SelectConnector(c);
                //        StepOrConnectorSelected = true;
                //    }
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool BackButtonSelected = false;
        private void seriesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {

                Sr = CurrentSeries();
                ACSr = null;
                Navigate(CurrentSeries());
                InitDiagram();

                if(SeriesStack.Count==0 || (int)SeriesStack.Peek()!=CurrentSeries().SeriesId)
                    SeriesStack.Push(CurrentSeries().SeriesId);

                if (BackButtonSelected) //pop stack
                {
                    BackButtonSelected = false;
                    if (SeriesStack.Count == 1)
                        cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }
                else // add to stack
                {
                    if (SeriesStack.Count > 1)
                        cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    else
                        cmdBack.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
        private lmDatasets.ActivityConfig.SeriesRow CurrentSeries()
        {
            if (seriesBindingSource.Current != null)
                return (lmDatasets.ActivityConfig.SeriesRow)((DataRowView)seriesBindingSource.Current).Row;
            else
                return null;
        }

        private void seriesGridEX_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                pnlRight.Activate();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fTriangle_Load(object sender, EventArgs e)
        {
            try
            {
                if (!flowOrSeriesPassedOnConstructor)
                    seriesGridEX.MoveFirst();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //redraw after changing draw options
        private void chkHideBFOnly_CheckedChanged(object sender, EventArgs e)
        {
            try { InitDiagram(); }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try 
            {
                saveFileDialog1.Filter = "BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
                saveFileDialog1.FileName = this.CurrentSeries().SeriesDescEng + ".bmp";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string saveas = saveFileDialog1.FileName;
                    diagram.SaveAsImg(saveas);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void chkLegend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                pnlLegend.Closed = !chkLegend.Checked;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}