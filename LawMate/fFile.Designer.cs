using System;
using System.Data;
 namespace LawMate
{
    partial class fFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {

                //fmCurrent.Dispose();
                //fmCurrent.KeepAlive = false;
                fmCurrent.OnWarning -= new atLogic.WarningEventHandler(fmCurrent_OnWarning);
                fmCurrent.GetFileXRef().OnUpdate -= new atLogic.UpdateEventHandler(fFile_OnUpdate);
                fmCurrent.DB.EFile.ColumnChanged -= new DataColumnChangeEventHandler(EFile_ColumnChanged);

                foreach (ucBase ctl in ucDic.Values)
                {
                    ctl.Dispose();
                }
                ucDic.Clear();
                fileToc.Dispose();

                this.timer1.Tick -= new System.EventHandler(this.timer1_Tick);
                timer1.Dispose();
                
                this.timFMHeartbeat.Tick -= new System.EventHandler(this.timFMHeartbeat_Tick);
                timFMHeartbeat.Dispose();


                //try
                //{
                //    //delete temp folder
                //    string temp = System.IO.Path.GetTempPath() + @"lawmate\" + fmCurrent.CurrentFileId.ToString() + @"\";
                //    if (System.IO.Directory.Exists(temp))
                //    {
                //        foreach (string f in System.IO.Directory.GetFiles(temp))
                //        {
                //            try
                //            {
                //                System.IO.File.SetAttributes(f, System.IO.FileAttributes.Normal);
                //                System.IO.File.Delete(f);
                //            }
                //            catch (Exception x)
                //            { }
                //        }
                //        System.IO.Directory.Delete(temp, true);
                //    }
                //}
                //catch (Exception x)
                //{ }

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFile));
            Janus.Windows.UI.StatusBar.UIStatusBarPanel uiStatusBarPanel1 = new Janus.Windows.UI.StatusBar.UIStatusBarPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsTOC = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlMessage = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlMessageContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebInfoMessage = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiFileFlagBanner = new Janus.Windows.UI.Dock.UIPanel();
            this.uiFileFlagBannerContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.edFileBanner = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiPanel2 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel2Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebMessage = new Janus.Windows.GridEX.EditControls.EditBox();
            this.eFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlNewActivity = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlNewActivityContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucActivityNew2 = new LawMate.UserControls.ucActivityNew();
            this.uiPanel1 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel1Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.fileToc = new LawMate.ucToC();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdWarningImg1 = new Janus.Windows.UI.CommandBars.UICommand("cmdWarningImg");
            this.cmdReadOnly1 = new Janus.Windows.UI.CommandBars.UICommand("cmdReadOnly");
            this.cmdWarningImg2 = new Janus.Windows.UI.CommandBars.UICommand("cmdWarningImg");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdView1 = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdTools1 = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.tsActions1 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.Separator10 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNewWizard2 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewWizard");
            this.tsActions2 = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.Separator9 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAddToShortcuts2 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddToShortcuts");
            this.cmdNewXRef2 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewXRef");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRefresh2 = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.cmdImportantFileMessageToggle2 = new Janus.Windows.UI.CommandBars.UICommand("cmdImportantFileMessageToggle");
            this.cmdHideToc2 = new Janus.Windows.UI.CommandBars.UICommand("cmdHideToc");
            this.Separator5 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdJumpToExplorer2 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToExplorer");
            this.Separator6 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdClose1 = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.cmdRefresh1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdAddToShortcuts1 = new Janus.Windows.UI.CommandBars.UICommand("cmdAddToShortcuts");
            this.cmdNewXRef1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewXRef");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdClose = new Janus.Windows.UI.CommandBars.UICommand("cmdClose");
            this.cmdReadOnly = new Janus.Windows.UI.CommandBars.UICommand("cmdReadOnly");
            this.cmdView = new Janus.Windows.UI.CommandBars.UICommand("cmdView");
            this.cmdHideToc1 = new Janus.Windows.UI.CommandBars.UICommand("cmdHideToc");
            this.cmdImportantFileMessageToggle1 = new Janus.Windows.UI.CommandBars.UICommand("cmdImportantFileMessageToggle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdJumpToExplorer1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToExplorer");
            this.cmdRefresh = new Janus.Windows.UI.CommandBars.UICommand("cmdRefresh");
            this.cmdAddToShortcuts = new Janus.Windows.UI.CommandBars.UICommand("cmdAddToShortcuts");
            this.cmdNewXRef = new Janus.Windows.UI.CommandBars.UICommand("cmdNewXRef");
            this.cmdImportantFileMessageToggle = new Janus.Windows.UI.CommandBars.UICommand("cmdImportantFileMessageToggle");
            this.cmdJumpToExplorer = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToExplorer");
            this.cmdHideToc = new Janus.Windows.UI.CommandBars.UICommand("cmdHideToc");
            this.cmdWarningImg = new Janus.Windows.UI.CommandBars.UICommand("cmdWarningImg");
            this.tsActions = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.cmdNewWizard1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewWizard");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsTimeKeeping1 = new Janus.Windows.UI.CommandBars.UICommand("tsTimeKeeping");
            this.Separator8 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNewWizard = new Janus.Windows.UI.CommandBars.UICommand("cmdNewWizard");
            this.tsTimeKeeping = new Janus.Windows.UI.CommandBars.UICommand("tsTimeKeeping");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdFileFlag = new Janus.Windows.UI.CommandBars.UICommand("cmdFileFlag");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.timFMHeartbeat = new System.Windows.Forms.Timer(this.components);
            this.uiStatusBar1 = new Janus.Windows.UI.StatusBar.UIStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).BeginInit();
            this.pnlMessage.SuspendLayout();
            this.pnlMessageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFileFlagBanner)).BeginInit();
            this.uiFileFlagBanner.SuspendLayout();
            this.uiFileFlagBannerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).BeginInit();
            this.uiPanel2.SuspendLayout();
            this.uiPanel2Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNewActivity)).BeginInit();
            this.pnlNewActivity.SuspendLayout();
            this.pnlNewActivityContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).BeginInit();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListfBase
            // 
            this.imageListfBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListfBase.ImageStream")));
            this.imageListfBase.Images.SetKeyName(0, "");
            this.imageListfBase.Images.SetKeyName(1, "");
            this.imageListfBase.Images.SetKeyName(2, "");
            this.imageListfBase.Images.SetKeyName(3, "");
            this.imageListfBase.Images.SetKeyName(4, "");
            this.imageListfBase.Images.SetKeyName(5, "");
            this.imageListfBase.Images.SetKeyName(6, "");
            this.imageListfBase.Images.SetKeyName(7, "");
            this.imageListfBase.Images.SetKeyName(8, "");
            this.imageListfBase.Images.SetKeyName(9, "");
            this.imageListfBase.Images.SetKeyName(10, "");
            this.imageListfBase.Images.SetKeyName(11, "");
            this.imageListfBase.Images.SetKeyName(12, "");
            this.imageListfBase.Images.SetKeyName(13, "");
            this.imageListfBase.Images.SetKeyName(14, "");
            this.imageListfBase.Images.SetKeyName(15, "");
            this.imageListfBase.Images.SetKeyName(16, "");
            this.imageListfBase.Images.SetKeyName(17, "");
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTOC,
            this.toolStripSeparator1});
            this.toolStrip1.Name = "toolStrip1";
            this.helpProvider1.SetShowHelp(this.toolStrip1, ((bool)(resources.GetObject("toolStrip1.ShowHelp"))));
            // 
            // tsTOC
            // 
            this.tsTOC.Checked = true;
            this.tsTOC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsTOC.Name = "tsTOC";
            resources.ApplyResources(this.tsTOC, "tsTOC");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanelManager1.PanelClosedChanged += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelClosedChanged);
            this.uiPanelManager1.PanelAutoHideChanged += new Janus.Windows.UI.Dock.PanelActionEventHandler(this.uiPanelManager1_PanelAutoHideChanged);
            this.pnlMessage.Id = new System.Guid("416a4814-d59f-4bd4-8e74-ff4136065752");
            this.uiPanelManager1.Panels.Add(this.pnlMessage);
            this.uiFileFlagBanner.Id = new System.Guid("f5385d3b-4118-4f44-b586-1e2afe779040");
            this.uiPanelManager1.Panels.Add(this.uiFileFlagBanner);
            this.uiPanel2.Id = new System.Guid("b6de9318-8dcb-49a5-8c88-91bbb1bf99ec");
            this.uiPanelManager1.Panels.Add(this.uiPanel2);
            this.pnlNewActivity.Id = new System.Guid("8d18e95c-427d-4b95-ae80-1087ec18a778");
            this.uiPanelManager1.Panels.Add(this.pnlNewActivity);
            this.uiPanel1.Id = new System.Guid("ff50c56d-f5f5-423c-b923-0bb724a8b921");
            this.uiPanelManager1.Panels.Add(this.uiPanel1);
            this.uiPanel0.Id = new System.Guid("80a2aab8-0c9e-4ab4-856e-f3e8163152c1");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("416a4814-d59f-4bd4-8e74-ff4136065752"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1228, 35), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f5385d3b-4118-4f44-b586-1e2afe779040"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1228, 52), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("b6de9318-8dcb-49a5-8c88-91bbb1bf99ec"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1228, 117), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("8d18e95c-427d-4b95-ae80-1087ec18a778"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1228, 28), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ff50c56d-f5f5-423c-b923-0bb724a8b921"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(787, 554), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("80a2aab8-0c9e-4ab4-856e-f3e8163152c1"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(441, 554), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("80a2aab8-0c9e-4ab4-856e-f3e8163152c1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ff50c56d-f5f5-423c-b923-0bb724a8b921"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b6de9318-8dcb-49a5-8c88-91bbb1bf99ec"), new System.Drawing.Point(13, 201), new System.Drawing.Size(1000, 170), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8d18e95c-427d-4b95-ae80-1087ec18a778"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f5385d3b-4118-4f44-b586-1e2afe779040"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(20, 20), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("416a4814-d59f-4bd4-8e74-ff4136065752"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlMessage
            // 
            this.pnlMessage.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlMessage.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlMessage.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlMessage.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlMessage, "pnlMessage");
            this.pnlMessage.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlMessage.InnerContainer = this.pnlMessageContainer;
            this.pnlMessage.Name = "pnlMessage";
            this.helpProvider1.SetShowHelp(this.pnlMessage, ((bool)(resources.GetObject("pnlMessage.ShowHelp"))));
            // 
            // pnlMessageContainer
            // 
            this.pnlMessageContainer.Controls.Add(this.ebInfoMessage);
            resources.ApplyResources(this.pnlMessageContainer, "pnlMessageContainer");
            this.pnlMessageContainer.Name = "pnlMessageContainer";
            this.helpProvider1.SetShowHelp(this.pnlMessageContainer, ((bool)(resources.GetObject("pnlMessageContainer.ShowHelp"))));
            // 
            // ebInfoMessage
            // 
            this.ebInfoMessage.BackColor = System.Drawing.Color.LemonChiffon;
            this.ebInfoMessage.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ebInfoMessage.ButtonFont = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold);
            this.ebInfoMessage.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.TextButton;
            resources.ApplyResources(this.ebInfoMessage, "ebInfoMessage");
            this.ebInfoMessage.ForeColor = System.Drawing.Color.Blue;
            this.ebInfoMessage.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Near;
            this.ebInfoMessage.Name = "ebInfoMessage";
            this.helpProvider1.SetShowHelp(this.ebInfoMessage, ((bool)(resources.GetObject("ebInfoMessage.ShowHelp"))));
            this.ebInfoMessage.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.ebInfoMessage.ButtonClick += new System.EventHandler(this.ebInfoMessage_ButtonClick);
            // 
            // uiFileFlagBanner
            // 
            this.uiFileFlagBanner.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiFileFlagBanner.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiFileFlagBanner.BackColor = System.Drawing.SystemColors.Control;
            this.uiFileFlagBanner.CaptionFormatStyle.Font = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Bold);
            this.uiFileFlagBanner.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiFileFlagBanner.CaptionFormatStyle.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.uiFileFlagBanner, "uiFileFlagBanner");
            this.uiFileFlagBanner.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiFileFlagBanner.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiFileFlagBanner.FloatingSize = new System.Drawing.Size(20, 20);
            this.uiFileFlagBanner.InfoTextFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.uiFileFlagBanner.InnerContainer = this.uiFileFlagBannerContainer;
            this.uiFileFlagBanner.Name = "uiFileFlagBanner";
            this.helpProvider1.SetShowHelp(this.uiFileFlagBanner, ((bool)(resources.GetObject("uiFileFlagBanner.ShowHelp"))));
            // 
            // uiFileFlagBannerContainer
            // 
            this.uiFileFlagBannerContainer.Controls.Add(this.edFileBanner);
            resources.ApplyResources(this.uiFileFlagBannerContainer, "uiFileFlagBannerContainer");
            this.uiFileFlagBannerContainer.Name = "uiFileFlagBannerContainer";
            this.helpProvider1.SetShowHelp(this.uiFileFlagBannerContainer, ((bool)(resources.GetObject("uiFileFlagBannerContainer.ShowHelp"))));
            // 
            // edFileBanner
            // 
            this.edFileBanner.BackColor = System.Drawing.Color.LemonChiffon;
            this.edFileBanner.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            resources.ApplyResources(this.edFileBanner, "edFileBanner");
            this.edFileBanner.ForeColor = System.Drawing.Color.Red;
            this.edFileBanner.Multiline = true;
            this.edFileBanner.Name = "edFileBanner";
            this.edFileBanner.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.edFileBanner, ((bool)(resources.GetObject("edFileBanner.ShowHelp"))));
            this.edFileBanner.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiPanel2
            // 
            this.uiPanel2.CaptionFormatStyle.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.uiPanel2.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanel2.CaptionFormatStyle.ForeColor = System.Drawing.Color.DarkRed;
            resources.ApplyResources(this.uiPanel2, "uiPanel2");
            this.uiPanel2.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanel2.FloatingLocation = new System.Drawing.Point(13, 201);
            this.uiPanel2.FloatingSize = new System.Drawing.Size(1000, 170);
            this.uiPanel2.InfoTextFormatStyle.FontSize = 8F;
            this.uiPanel2.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.uiPanel2.InnerContainer = this.uiPanel2Container;
            this.uiPanel2.InnerContainerFormatStyle.BackColor = System.Drawing.Color.DarkRed;
            this.uiPanel2.InnerContainerFormatStyle.BackColorGradient = System.Drawing.Color.DarkOrange;
            this.uiPanel2.InnerContainerFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.uiPanel2.Name = "uiPanel2";
            this.helpProvider1.SetShowHelp(this.uiPanel2, ((bool)(resources.GetObject("uiPanel2.ShowHelp"))));
            // 
            // uiPanel2Container
            // 
            this.uiPanel2Container.Controls.Add(this.ebMessage);
            resources.ApplyResources(this.uiPanel2Container, "uiPanel2Container");
            this.uiPanel2Container.Name = "uiPanel2Container";
            this.helpProvider1.SetShowHelp(this.uiPanel2Container, ((bool)(resources.GetObject("uiPanel2Container.ShowHelp"))));
            // 
            // ebMessage
            // 
            this.ebMessage.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.ebMessage.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eFileBindingSource, "ImportantMsg", true));
            resources.ApplyResources(this.ebMessage, "ebMessage");
            this.ebMessage.Multiline = true;
            this.ebMessage.Name = "ebMessage";
            this.ebMessage.ReadOnly = true;
            this.ebMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.ebMessage, ((bool)(resources.GetObject("ebMessage.ShowHelp"))));
            // 
            // pnlNewActivity
            // 
            this.pnlNewActivity.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlNewActivity.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlNewActivity.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlNewActivity.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.pnlNewActivity, "pnlNewActivity");
            this.pnlNewActivity.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlNewActivity.InnerContainer = this.pnlNewActivityContainer;
            this.pnlNewActivity.Name = "pnlNewActivity";
            this.helpProvider1.SetShowHelp(this.pnlNewActivity, ((bool)(resources.GetObject("pnlNewActivity.ShowHelp"))));
            // 
            // pnlNewActivityContainer
            // 
            this.pnlNewActivityContainer.Controls.Add(this.ucActivityNew2);
            resources.ApplyResources(this.pnlNewActivityContainer, "pnlNewActivityContainer");
            this.pnlNewActivityContainer.Name = "pnlNewActivityContainer";
            this.helpProvider1.SetShowHelp(this.pnlNewActivityContainer, ((bool)(resources.GetObject("pnlNewActivityContainer.ShowHelp"))));
            // 
            // ucActivityNew2
            // 
            resources.ApplyResources(this.ucActivityNew2, "ucActivityNew2");
            this.ucActivityNew2.BackColor = System.Drawing.Color.Transparent;
            this.ucActivityNew2.Name = "ucActivityNew2";
            this.helpProvider1.SetShowHelp(this.ucActivityNew2, ((bool)(resources.GetObject("ucActivityNew2.ShowHelp"))));
            // 
            // uiPanel1
            // 
            this.uiPanel1.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel1.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanel1.InnerContainer = this.uiPanel1Container;
            resources.ApplyResources(this.uiPanel1, "uiPanel1");
            this.uiPanel1.Name = "uiPanel1";
            this.helpProvider1.SetShowHelp(this.uiPanel1, ((bool)(resources.GetObject("uiPanel1.ShowHelp"))));
            // 
            // uiPanel1Container
            // 
            resources.ApplyResources(this.uiPanel1Container, "uiPanel1Container");
            this.uiPanel1Container.Name = "uiPanel1Container";
            this.helpProvider1.SetShowHelp(this.uiPanel1Container, ((bool)(resources.GetObject("uiPanel1Container.ShowHelp"))));
            // 
            // uiPanel0
            // 
            this.uiPanel0.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.BorderCaption = Janus.Windows.UI.InheritableBoolean.True;
            this.uiPanel0.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanel0.CaptionFormatStyle.FontName = "Arial";
            this.uiPanel0.CaptionFormatStyle.FontSize = 8F;
            resources.ApplyResources(this.uiPanel0, "uiPanel0");
            this.uiPanel0.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Name = "uiPanel0";
            this.helpProvider1.SetShowHelp(this.uiPanel0, ((bool)(resources.GetObject("uiPanel0.ShowHelp"))));
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Controls.Add(this.fileToc);
            resources.ApplyResources(this.uiPanel0Container, "uiPanel0Container");
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.helpProvider1.SetShowHelp(this.uiPanel0Container, ((bool)(resources.GetObject("uiPanel0Container.ShowHelp"))));
            // 
            // fileToc
            // 
            this.fileToc.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.fileToc, "fileToc");
            this.fileToc.Name = "fileToc";
            this.helpProvider1.SetShowHelp(this.fileToc, ((bool)(resources.GetObject("fileToc.ShowHelp"))));
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar1,
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile,
            this.cmdTools,
            this.cmdSave,
            this.cmdClose,
            this.cmdReadOnly,
            this.cmdView,
            this.cmdRefresh,
            this.cmdAddToShortcuts,
            this.cmdNewXRef,
            this.cmdImportantFileMessageToggle,
            this.cmdJumpToExplorer,
            this.cmdHideToc,
            this.cmdWarningImg,
            this.tsActions,
            this.cmdNewWizard,
            this.tsTimeKeeping,
            this.cmdCancel,
            this.cmdFileFlag});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("3eb74549-dcf0-41f9-961c-5b43b40f6f67");
            this.uiCommandManager1.KeepMergeSettings = false;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShortcutBehavior = Janus.Windows.UI.CommandBars.ShortcutBehavior.OnToolbarCommands;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowMerge = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdWarningImg1,
            this.cmdReadOnly1,
            this.cmdWarningImg2});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.FullRow = true;
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.MergeRowOrder = 0;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // cmdWarningImg1
            // 
            resources.ApplyResources(this.cmdWarningImg1, "cmdWarningImg1");
            this.cmdWarningImg1.Name = "cmdWarningImg1";
            // 
            // cmdReadOnly1
            // 
            resources.ApplyResources(this.cmdReadOnly1, "cmdReadOnly1");
            this.cmdReadOnly1.Name = "cmdReadOnly1";
            // 
            // cmdWarningImg2
            // 
            resources.ApplyResources(this.cmdWarningImg2, "cmdWarningImg2");
            this.cmdWarningImg2.Name = "cmdWarningImg2";
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdView1,
            this.cmdTools1,
            this.tsActions1});
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.MergeRowOrder = 1;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdView1
            // 
            resources.ApplyResources(this.cmdView1, "cmdView1");
            this.cmdView1.Name = "cmdView1";
            // 
            // cmdTools1
            // 
            resources.ApplyResources(this.cmdTools1, "cmdTools1");
            this.cmdTools1.Name = "cmdTools1";
            // 
            // tsActions1
            // 
            resources.ApplyResources(this.tsActions1, "tsActions1");
            this.tsActions1.Name = "tsActions1";
            // 
            // uiCommandBar3
            // 
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.Separator10,
            this.cmdNewWizard2,
            this.tsActions2,
            this.Separator3,
            this.cmdCancel1,
            this.Separator9,
            this.cmdAddToShortcuts2,
            this.cmdNewXRef2,
            this.Separator4,
            this.cmdRefresh2,
            this.cmdImportantFileMessageToggle2,
            this.cmdHideToc2,
            this.Separator5,
            this.cmdJumpToExplorer2,
            this.Separator6});
            this.uiCommandBar3.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.MergeRowOrder = 2;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.uiCommandBar3.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            this.uiCommandBar3.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandBar3_CommandClick);
            // 
            // Separator10
            // 
            this.Separator10.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator10, "Separator10");
            this.Separator10.Name = "Separator10";
            // 
            // cmdNewWizard2
            // 
            this.cmdNewWizard2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.cmdNewWizard2, "cmdNewWizard2");
            this.cmdNewWizard2.Name = "cmdNewWizard2";
            // 
            // tsActions2
            // 
            this.tsActions2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsActions2.DropDownButtonStyle = Janus.Windows.UI.CommandBars.DropDownButtonStyle.SplitButton;
            resources.ApplyResources(this.tsActions2, "tsActions2");
            this.tsActions2.Name = "tsActions2";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // cmdCancel1
            // 
            resources.ApplyResources(this.cmdCancel1, "cmdCancel1");
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // Separator9
            // 
            this.Separator9.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator9, "Separator9");
            this.Separator9.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.Separator9.Name = "Separator9";
            // 
            // cmdAddToShortcuts2
            // 
            resources.ApplyResources(this.cmdAddToShortcuts2, "cmdAddToShortcuts2");
            this.cmdAddToShortcuts2.Name = "cmdAddToShortcuts2";
            // 
            // cmdNewXRef2
            // 
            resources.ApplyResources(this.cmdNewXRef2, "cmdNewXRef2");
            this.cmdNewXRef2.Name = "cmdNewXRef2";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // cmdRefresh2
            // 
            resources.ApplyResources(this.cmdRefresh2, "cmdRefresh2");
            this.cmdRefresh2.Name = "cmdRefresh2";
            // 
            // cmdImportantFileMessageToggle2
            // 
            resources.ApplyResources(this.cmdImportantFileMessageToggle2, "cmdImportantFileMessageToggle2");
            this.cmdImportantFileMessageToggle2.Name = "cmdImportantFileMessageToggle2";
            // 
            // cmdHideToc2
            // 
            resources.ApplyResources(this.cmdHideToc2, "cmdHideToc2");
            this.cmdHideToc2.Name = "cmdHideToc2";
            // 
            // Separator5
            // 
            this.Separator5.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator5, "Separator5");
            this.Separator5.Name = "Separator5";
            // 
            // cmdJumpToExplorer2
            // 
            resources.ApplyResources(this.cmdJumpToExplorer2, "cmdJumpToExplorer2");
            this.cmdJumpToExplorer2.Name = "cmdJumpToExplorer2";
            // 
            // Separator6
            // 
            this.Separator6.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator6, "Separator6");
            this.Separator6.Name = "Separator6";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdClose1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // cmdClose1
            // 
            resources.ApplyResources(this.cmdClose1, "cmdClose1");
            this.cmdClose1.Name = "cmdClose1";
            // 
            // cmdTools
            // 
            this.cmdTools.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdRefresh1,
            this.Separator2,
            this.cmdAddToShortcuts1,
            this.cmdNewXRef1});
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdTools.Name = "cmdTools";
            // 
            // cmdRefresh1
            // 
            resources.ApplyResources(this.cmdRefresh1, "cmdRefresh1");
            this.cmdRefresh1.Name = "cmdRefresh1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // cmdAddToShortcuts1
            // 
            resources.ApplyResources(this.cmdAddToShortcuts1, "cmdAddToShortcuts1");
            this.cmdAddToShortcuts1.Name = "cmdAddToShortcuts1";
            // 
            // cmdNewXRef1
            // 
            resources.ApplyResources(this.cmdNewXRef1, "cmdNewXRef1");
            this.cmdNewXRef1.Name = "cmdNewXRef1";
            // 
            // cmdSave
            // 
            resources.ApplyResources(this.cmdSave, "cmdSave");
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.ShowInCustomizeDialog = false;
            // 
            // cmdClose
            // 
            resources.ApplyResources(this.cmdClose, "cmdClose");
            this.cmdClose.Name = "cmdClose";
            // 
            // cmdReadOnly
            // 
            this.cmdReadOnly.Checked = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdReadOnly.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.cmdReadOnly.ControlWidth = 100;
            this.cmdReadOnly.IsEditableControl = Janus.Windows.UI.InheritableBoolean.True;
            resources.ApplyResources(this.cmdReadOnly, "cmdReadOnly");
            this.cmdReadOnly.Name = "cmdReadOnly";
            this.cmdReadOnly.ShowInCustomizeDialog = false;
            this.cmdReadOnly.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Yellow;
            this.cmdReadOnly.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.cmdReadOnly.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.cmdReadOnly.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.cmdReadOnly.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.ImageBeforeText;
            // 
            // cmdView
            // 
            this.cmdView.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdHideToc1,
            this.cmdImportantFileMessageToggle1,
            this.Separator1,
            this.cmdJumpToExplorer1});
            resources.ApplyResources(this.cmdView, "cmdView");
            this.cmdView.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdView.Name = "cmdView";
            // 
            // cmdHideToc1
            // 
            resources.ApplyResources(this.cmdHideToc1, "cmdHideToc1");
            this.cmdHideToc1.Name = "cmdHideToc1";
            // 
            // cmdImportantFileMessageToggle1
            // 
            resources.ApplyResources(this.cmdImportantFileMessageToggle1, "cmdImportantFileMessageToggle1");
            this.cmdImportantFileMessageToggle1.Name = "cmdImportantFileMessageToggle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // cmdJumpToExplorer1
            // 
            resources.ApplyResources(this.cmdJumpToExplorer1, "cmdJumpToExplorer1");
            this.cmdJumpToExplorer1.Name = "cmdJumpToExplorer1";
            // 
            // cmdRefresh
            // 
            resources.ApplyResources(this.cmdRefresh, "cmdRefresh");
            this.cmdRefresh.Name = "cmdRefresh";
            // 
            // cmdAddToShortcuts
            // 
            resources.ApplyResources(this.cmdAddToShortcuts, "cmdAddToShortcuts");
            this.cmdAddToShortcuts.Name = "cmdAddToShortcuts";
            // 
            // cmdNewXRef
            // 
            resources.ApplyResources(this.cmdNewXRef, "cmdNewXRef");
            this.cmdNewXRef.Name = "cmdNewXRef";
            // 
            // cmdImportantFileMessageToggle
            // 
            resources.ApplyResources(this.cmdImportantFileMessageToggle, "cmdImportantFileMessageToggle");
            this.cmdImportantFileMessageToggle.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.cmdImportantFileMessageToggle.Name = "cmdImportantFileMessageToggle";
            // 
            // cmdJumpToExplorer
            // 
            resources.ApplyResources(this.cmdJumpToExplorer, "cmdJumpToExplorer");
            this.cmdJumpToExplorer.Name = "cmdJumpToExplorer";
            // 
            // cmdHideToc
            // 
            this.cmdHideToc.Checked = Janus.Windows.UI.InheritableBoolean.True;
            this.cmdHideToc.CommandType = Janus.Windows.UI.CommandBars.CommandType.ToggleButton;
            resources.ApplyResources(this.cmdHideToc, "cmdHideToc");
            this.cmdHideToc.Name = "cmdHideToc";
            // 
            // cmdWarningImg
            // 
            this.cmdWarningImg.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.cmdWarningImg.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdWarningImg, "cmdWarningImg");
            this.cmdWarningImg.Name = "cmdWarningImg";
            this.cmdWarningImg.ShowInCustomizeDialog = false;
            // 
            // tsActions
            // 
            this.tsActions.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdNewWizard1,
            this.Separator7,
            this.tsTimeKeeping1,
            this.Separator8});
            resources.ApplyResources(this.tsActions, "tsActions");
            this.tsActions.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.tsActions.Name = "tsActions";
            // 
            // cmdNewWizard1
            // 
            this.cmdNewWizard1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.cmdNewWizard1, "cmdNewWizard1");
            this.cmdNewWizard1.Name = "cmdNewWizard1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // tsTimeKeeping1
            // 
            resources.ApplyResources(this.tsTimeKeeping1, "tsTimeKeeping1");
            this.tsTimeKeeping1.Name = "tsTimeKeeping1";
            // 
            // Separator8
            // 
            this.Separator8.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator8, "Separator8");
            this.Separator8.Name = "Separator8";
            // 
            // cmdNewWizard
            // 
            resources.ApplyResources(this.cmdNewWizard, "cmdNewWizard");
            this.cmdNewWizard.Name = "cmdNewWizard";
            // 
            // tsTimeKeeping
            // 
            resources.ApplyResources(this.tsTimeKeeping, "tsTimeKeeping");
            this.tsTimeKeeping.Name = "tsTimeKeeping";
            // 
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            // 
            // cmdFileFlag
            // 
            this.cmdFileFlag.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.cmdFileFlag, "cmdFileFlag");
            this.cmdFileFlag.Name = "cmdFileFlag";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            this.helpProvider1.SetShowHelp(this.LeftRebar1, ((bool)(resources.GetObject("LeftRebar1.ShowHelp"))));
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            this.helpProvider1.SetShowHelp(this.RightRebar1, ((bool)(resources.GetObject("RightRebar1.ShowHelp"))));
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar3,
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // timFMHeartbeat
            // 
            this.timFMHeartbeat.Interval = 5000;
            this.timFMHeartbeat.Tick += new System.EventHandler(this.timFMHeartbeat_Tick);
            // 
            // uiStatusBar1
            // 
            this.uiStatusBar1.ColorScheme = "Scheme1";
            resources.ApplyResources(this.uiStatusBar1, "uiStatusBar1");
            this.uiStatusBar1.Name = "uiStatusBar1";
            uiStatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            uiStatusBarPanel1.BorderColor = System.Drawing.Color.Empty;
            uiStatusBarPanel1.Key = "sbMessage";
            resources.ApplyResources(uiStatusBarPanel1, "uiStatusBarPanel1");
            this.uiStatusBar1.Panels.AddRange(new Janus.Windows.UI.StatusBar.UIStatusBarPanel[] {
            uiStatusBarPanel1});
            this.helpProvider1.SetShowHelp(this.uiStatusBar1, ((bool)(resources.GetObject("uiStatusBar1.ShowHelp"))));
            this.uiStatusBar1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // fFile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.uiPanel1);
            this.Controls.Add(this.pnlNewActivity);
            this.Controls.Add(this.uiPanel2);
            this.Controls.Add(this.uiFileFlagBanner);
            this.Controls.Add(this.pnlMessage);
            this.Controls.Add(this.uiStatusBar1);
            this.Controls.Add(this.TopRebar1);
            this.KeyPreview = true;
            this.MakeMdiChild = false;
            this.Name = "fFile";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fFile_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fFile_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fFile_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMessage)).EndInit();
            this.pnlMessage.ResumeLayout(false);
            this.pnlMessageContainer.ResumeLayout(false);
            this.pnlMessageContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiFileFlagBanner)).EndInit();
            this.uiFileFlagBanner.ResumeLayout(false);
            this.uiFileFlagBannerContainer.ResumeLayout(false);
            this.uiFileFlagBannerContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel2)).EndInit();
            this.uiPanel2.ResumeLayout(false);
            this.uiPanel2Container.ResumeLayout(false);
            this.uiPanel2Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlNewActivity)).EndInit();
            this.pnlNewActivity.ResumeLayout(false);
            this.pnlNewActivityContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel1)).EndInit();
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsTOC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timer1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel1;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel1Container;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        public ucToC fileToc;
        private Janus.Windows.UI.Dock.UIPanel uiPanel2;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel2Container;
        private System.Windows.Forms.BindingSource eFileBindingSource;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose1;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdClose;
        internal Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdReadOnly1;
        private Janus.Windows.UI.CommandBars.UICommand cmdReadOnly;
        private System.Windows.Forms.Timer timFMHeartbeat;
        private Janus.Windows.UI.CommandBars.UICommand cmdView;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddToShortcuts;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh1;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddToShortcuts1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewXRef1;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportantFileMessageToggle1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewXRef;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportantFileMessageToggle;
        private Janus.Windows.UI.CommandBars.UICommand cmdView1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToExplorer1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToExplorer;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideToc1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideToc;
        private Janus.Windows.UI.CommandBars.UICommand cmdWarningImg;
        private Janus.Windows.UI.CommandBars.UICommand cmdWarningImg1;
        private Janus.Windows.UI.CommandBars.UICommand cmdWarningImg2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdAddToShortcuts2;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewXRef2;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdRefresh2;
        private Janus.Windows.UI.CommandBars.UICommand cmdImportantFileMessageToggle2;
        private Janus.Windows.UI.CommandBars.UICommand cmdHideToc2;
        private Janus.Windows.UI.CommandBars.UICommand Separator5;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToExplorer2;
        private Janus.Windows.UI.CommandBars.UICommand Separator6;
        private Janus.Windows.UI.CommandBars.UICommand tsActions;
        private Janus.Windows.UI.CommandBars.UICommand tsActions1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewWizard1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewWizard;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand tsActions2;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewWizard2;
        private Janus.Windows.UI.CommandBars.UICommand tsTimeKeeping1;
        private Janus.Windows.UI.CommandBars.UICommand Separator8;
        private Janus.Windows.UI.CommandBars.UICommand tsTimeKeeping;
        private Janus.Windows.UI.CommandBars.UICommand Separator9;
        private Janus.Windows.UI.StatusBar.UIStatusBar uiStatusBar1;
        private Janus.Windows.UI.CommandBars.UICommand Separator10;
        private Janus.Windows.UI.Dock.UIPanel pnlNewActivity;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlNewActivityContainer;
        private UserControls.ucActivityNew ucActivityNew2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdFileFlag;
        private Janus.Windows.UI.Dock.UIPanel uiFileFlagBanner;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiFileFlagBannerContainer;
        private Janus.Windows.GridEX.EditControls.EditBox edFileBanner;
        private Janus.Windows.UI.Dock.UIPanel pnlMessage;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlMessageContainer;
        private Janus.Windows.GridEX.EditControls.EditBox ebInfoMessage;
        private Janus.Windows.GridEX.EditControls.EditBox ebMessage;
        
    }
}
