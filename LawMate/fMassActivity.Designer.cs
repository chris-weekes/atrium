namespace LawMate
{
    partial class fMassActivity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMassActivity));
            Janus.Windows.GridEX.GridEXLayout gridFileList_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.searchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblActivity = new System.Windows.Forms.Label();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.ucActivity = new LawMate.UserControls.ucMultiDropDown();
            this.uiTemplate = new LawMate.UserControls.ucMultiDropDown();
            this.gridFileList = new Janus.Windows.GridEX.GridEX();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.chkConcatenate = new Janus.Windows.EditControls.UICheckBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
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
            // searchResultBindingSource
            // 
            this.searchResultBindingSource.DataMember = "EFileSearch";
            this.searchResultBindingSource.DataSource = typeof(lmDatasets.appDB);
            // 
            // lblActivity
            // 
            resources.ApplyResources(this.lblActivity, "lblActivity");
            this.lblActivity.BackColor = System.Drawing.Color.Transparent;
            this.lblActivity.Name = "lblActivity";
            this.helpProvider1.SetShowHelp(this.lblActivity, ((bool)(resources.GetObject("lblActivity.ShowHelp"))));
            // 
            // lblTemplate
            // 
            resources.ApplyResources(this.lblTemplate, "lblTemplate");
            this.lblTemplate.BackColor = System.Drawing.Color.Transparent;
            this.lblTemplate.Name = "lblTemplate";
            this.helpProvider1.SetShowHelp(this.lblTemplate, ((bool)(resources.GetObject("lblTemplate.ShowHelp"))));
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("d888e2f9-5c59-4d9c-9c50-a4cfc6b13a4f");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            this.helpProvider1.SetShowHelp(this.BottomRebar1, ((bool)(resources.GetObject("BottomRebar1.ShowHelp"))));
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
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // ucActivity
            // 
            this.ucActivity.BackColor = System.Drawing.Color.Transparent;
            this.ucActivity.Column1 = "StepCode";
            resources.ApplyResources(this.ucActivity, "ucActivity");
            this.ucActivity.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucActivity.DataSource = null;
            this.ucActivity.DDColumn1Visible = true;
            this.ucActivity.DropDownColumn1Width = 100;
            this.ucActivity.DropDownColumn2Width = 300;
            this.ucActivity.Name = "ucActivity";
            this.ucActivity.ReadOnly = false;
            this.ucActivity.ReqColor = System.Drawing.SystemColors.Window;
            this.ucActivity.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucActivity, ((bool)(resources.GetObject("ucActivity.ShowHelp"))));
            this.ucActivity.ValueMember = "ACSeriesId";
            this.ucActivity.ASelectedValueChanged += new System.EventHandler(this.ucActivity_ASelectedValueChanged);
            // 
            // uiTemplate
            // 
            this.uiTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTemplate.Column1 = "LetterName";
            resources.ApplyResources(this.uiTemplate, "uiTemplate");
            this.uiTemplate.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.uiTemplate.DataSource = null;
            this.uiTemplate.DDColumn1Visible = true;
            this.uiTemplate.DropDownColumn1Width = 100;
            this.uiTemplate.DropDownColumn2Width = 300;
            this.uiTemplate.Name = "uiTemplate";
            this.uiTemplate.ReadOnly = false;
            this.uiTemplate.ReqColor = System.Drawing.SystemColors.Window;
            this.uiTemplate.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.uiTemplate, ((bool)(resources.GetObject("uiTemplate.ShowHelp"))));
            this.uiTemplate.ValueMember = "LetterName";
            // 
            // gridFileList
            // 
            this.gridFileList.AlternatingColors = true;
            resources.ApplyResources(this.gridFileList, "gridFileList");
            this.gridFileList.DataSource = this.searchResultBindingSource;
            resources.ApplyResources(gridFileList_DesignTimeLayout, "gridFileList_DesignTimeLayout");
            this.gridFileList.DesignTimeLayout = gridFileList_DesignTimeLayout;
            this.gridFileList.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.gridFileList.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.gridFileList.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.gridFileList.GroupByBoxVisible = false;
            this.gridFileList.Name = "gridFileList";
            this.helpProvider1.SetShowHelp(this.gridFileList, ((bool)(resources.GetObject("gridFileList.ShowHelp"))));
            this.gridFileList.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridFileList.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.gridFileList_FormattingRow);
            this.gridFileList.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.gridFileList_LinkClicked);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = ((int)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionHeight")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("e1c45299-4d2a-4db4-a3fe-e0d50de2be01");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("e1c45299-4d2a-4db4-a3fe-e0d50de2be01"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(985, 625), true);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlAll.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Name = "pnlAll";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.Controls.Add(this.uiButton2);
            this.pnlAllContainer.Controls.Add(this.uiButton1);
            this.pnlAllContainer.Controls.Add(this.chkConcatenate);
            this.pnlAllContainer.Controls.Add(this.gridFileList);
            this.pnlAllContainer.Controls.Add(this.ucActivity);
            this.pnlAllContainer.Controls.Add(this.lblActivity);
            this.pnlAllContainer.Controls.Add(this.uiTemplate);
            this.pnlAllContainer.Controls.Add(this.lblTemplate);
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Name = "pnlAllContainer";
            // 
            // chkConcatenate
            // 
            this.chkConcatenate.BackColor = System.Drawing.Color.Transparent;
            this.chkConcatenate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            resources.ApplyResources(this.chkConcatenate, "chkConcatenate");
            this.chkConcatenate.Name = "chkConcatenate";
            // 
            // uiButton1
            // 
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton1.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // uiButton2
            // 
            resources.ApplyResources(this.uiButton2, "uiButton2");
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.uiButton2.Click += new System.EventHandler(this.btnCancel_click);
            // 
            // fMassActivity
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            this.Name = "fMassActivity";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.Label lblTemplate;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private System.Windows.Forms.BindingSource searchResultBindingSource;
        private UserControls.ucMultiDropDown ucActivity;
        private UserControls.ucMultiDropDown uiTemplate;
        private Janus.Windows.GridEX.GridEX gridFileList;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.EditControls.UICheckBox chkConcatenate;
    }
}
