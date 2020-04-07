namespace LawMate
{
    partial class fBrowseTemplates
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
            System.Windows.Forms.Label SearchLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBrowseTemplates));
            Janus.Windows.GridEX.GridEXLayout templateGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.bSearch = new Janus.Windows.EditControls.UIButton();
            this.ebSearch = new Janus.Windows.GridEX.EditControls.EditBox();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.templateGridEX = new Janus.Windows.GridEX.GridEX();
            this.templateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.pnlBottom = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBottomContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.buttonCancel = new Janus.Windows.EditControls.UIButton();
            this.buttonOK = new Janus.Windows.EditControls.UIButton();
            this.pnlTemplates = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlOfficesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ucDocView1 = new LawMate.UserControls.ucDocView();
            this.pnlSearchOffice = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSearchOfficeContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBrowseOffices = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBrowseOfficesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlSearchOffices = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSearchOfficesContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlBrowseOffice = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBrowseOfficeContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlSearch = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.btnReset = new Janus.Windows.EditControls.UIButton();
            SearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
            this.uiPanel0Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.templateGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTemplates)).BeginInit();
            this.pnlTemplates.SuspendLayout();
            this.pnlOfficesContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffice)).BeginInit();
            this.pnlSearchOffice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffices)).BeginInit();
            this.pnlBrowseOffices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffices)).BeginInit();
            this.pnlSearchOffices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffice)).BeginInit();
            this.pnlBrowseOffice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchLabel
            // 
            resources.ApplyResources(SearchLabel, "SearchLabel");
            SearchLabel.BackColor = System.Drawing.Color.Transparent;
            SearchLabel.Name = "SearchLabel";
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideTabDisplay = Janus.Windows.UI.Dock.TabDisplayMode.ImageAndText;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontName = "arial";
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.FontSize = 8.25F;
            this.uiPanelManager1.DefaultPanelSettings.TabStateStyles.FormatStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.uiPanel0.Id = new System.Guid("874f0ed0-d050-4edc-8acb-255d66cad79b");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            this.pnlGrid.Id = new System.Guid("f1d5180e-fb67-4741-a4bf-23b507f38b01");
            this.uiPanelManager1.Panels.Add(this.pnlGrid);
            this.pnlBottom.Id = new System.Guid("11648e07-ccf1-4503-af53-add03c429133");
            this.uiPanelManager1.Panels.Add(this.pnlBottom);
            this.pnlTemplates.Id = new System.Guid("fb72ec5a-1c09-4241-a98c-14ae87dc3242");
            this.uiPanelManager1.Panels.Add(this.pnlTemplates);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("874f0ed0-d050-4edc-8acb-255d66cad79b"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1050, 40), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("f1d5180e-fb67-4741-a4bf-23b507f38b01"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(1050, 259), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("fb72ec5a-1c09-4241-a98c-14ae87dc3242"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(1050, 342), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("11648e07-ccf1-4503-af53-add03c429133"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(1050, 39), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("796def90-bc87-426f-81be-e8dd984b9ef8"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("4012f743-895c-4149-9014-d9e9543ce497"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a0dfa5af-6a9f-4d9a-9de5-eabe562f064e"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("11648e07-ccf1-4503-af53-add03c429133"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("fb72ec5a-1c09-4241-a98c-14ae87dc3242"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("874f0ed0-d050-4edc-8acb-255d66cad79b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("f1d5180e-fb67-4741-a4bf-23b507f38b01"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.uiPanel0.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            resources.ApplyResources(this.uiPanel0, "uiPanel0");
            this.uiPanel0.Name = "uiPanel0";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.BackColor = System.Drawing.SystemColors.Control;
            this.uiPanel0Container.Controls.Add(this.btnReset);
            this.uiPanel0Container.Controls.Add(this.bSearch);
            this.uiPanel0Container.Controls.Add(SearchLabel);
            this.uiPanel0Container.Controls.Add(this.ebSearch);
            resources.ApplyResources(this.uiPanel0Container, "uiPanel0Container");
            this.uiPanel0Container.Name = "uiPanel0Container";
            // 
            // bSearch
            // 
            this.bSearch.Image = global::LawMate.Properties.Resources.search;
            this.bSearch.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.Far;
            resources.ApplyResources(this.bSearch, "bSearch");
            this.bSearch.Name = "bSearch";
            this.bSearch.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // ebSearch
            // 
            resources.ApplyResources(this.ebSearch, "ebSearch");
            this.ebSearch.Name = "ebSearch";
            this.ebSearch.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.ebSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ebSearch_KeyDown);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BorderCaption = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.Controls.Add(this.templateGridEX);
            resources.ApplyResources(this.pnlGridContainer, "pnlGridContainer");
            this.pnlGridContainer.Name = "pnlGridContainer";
            // 
            // templateGridEX
            // 
            this.templateGridEX.AlternatingColors = true;
            resources.ApplyResources(this.templateGridEX, "templateGridEX");
            this.templateGridEX.DataSource = this.templateBindingSource;
            resources.ApplyResources(templateGridEX_DesignTimeLayout, "templateGridEX_DesignTimeLayout");
            this.templateGridEX.DesignTimeLayout = templateGridEX_DesignTimeLayout;
            this.templateGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.templateGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.templateGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.templateGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.templateGridEX.Name = "templateGridEX";
            this.templateGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.templateGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.templateGridEX_LoadingRow);
            this.templateGridEX.LinkClicked += new Janus.Windows.GridEX.ColumnActionEventHandler(this.officeGridEX_LinkClicked);
            // 
            // templateBindingSource
            // 
            this.templateBindingSource.DataMember = "Template";
            this.templateBindingSource.DataSource = this.appDB;
            this.templateBindingSource.CurrentChanged += new System.EventHandler(this.templateBindingSource_CurrentChanged);
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlBottom
            // 
            this.pnlBottom.AllowResize = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlBottom.InnerContainer = this.pnlBottomContainer;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // pnlBottomContainer
            // 
            this.pnlBottomContainer.Controls.Add(this.buttonCancel);
            this.pnlBottomContainer.Controls.Add(this.buttonOK);
            resources.ApplyResources(this.pnlBottomContainer, "pnlBottomContainer");
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.buttonOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlTemplates
            // 
            this.pnlTemplates.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTemplates.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTemplates.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlTemplates.InnerContainer = this.pnlOfficesContainer;
            resources.ApplyResources(this.pnlTemplates, "pnlTemplates");
            this.pnlTemplates.Name = "pnlTemplates";
            // 
            // pnlOfficesContainer
            // 
            this.pnlOfficesContainer.Controls.Add(this.ucDocView1);
            resources.ApplyResources(this.pnlOfficesContainer, "pnlOfficesContainer");
            this.pnlOfficesContainer.Name = "pnlOfficesContainer";
            // 
            // ucDocView1
            // 
            this.ucDocView1.ActionToolbarView = LawMate.UserControls.DocCommandBar.Hide;
            this.ucDocView1.AllowActionToolbar = false;
            this.ucDocView1.AllowMetadata = false;
            this.ucDocView1.AllowMetadataUpdate = false;
            resources.ApplyResources(this.ucDocView1, "ucDocView1");
            this.ucDocView1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocView1.DocDisplayType = LawMate.UserControls.DocViewDisplayType.DocHeader;
            this.ucDocView1.ForceTextControl = true;
            this.ucDocView1.Name = "ucDocView1";
            this.ucDocView1.NoDocDisplayed = false;
            this.ucDocView1.ShowAttachmentPanel = false;
            this.ucDocView1.ShowMetadata = false;
            this.ucDocView1.ShowVersion = false;
            this.ucDocView1.TempFile = null;
            this.ucDocView1.TempFld = null;
            // 
            // pnlSearchOffice
            // 
            resources.ApplyResources(this.pnlSearchOffice, "pnlSearchOffice");
            this.pnlSearchOffice.InnerContainer = this.pnlSearchOfficeContainer;
            this.pnlSearchOffice.Name = "pnlSearchOffice";
            // 
            // pnlSearchOfficeContainer
            // 
            resources.ApplyResources(this.pnlSearchOfficeContainer, "pnlSearchOfficeContainer");
            this.pnlSearchOfficeContainer.Name = "pnlSearchOfficeContainer";
            // 
            // pnlBrowseOffices
            // 
            resources.ApplyResources(this.pnlBrowseOffices, "pnlBrowseOffices");
            this.pnlBrowseOffices.InnerContainer = this.pnlBrowseOfficesContainer;
            this.pnlBrowseOffices.Name = "pnlBrowseOffices";
            // 
            // pnlBrowseOfficesContainer
            // 
            resources.ApplyResources(this.pnlBrowseOfficesContainer, "pnlBrowseOfficesContainer");
            this.pnlBrowseOfficesContainer.Name = "pnlBrowseOfficesContainer";
            // 
            // pnlSearchOffices
            // 
            this.pnlSearchOffices.InnerContainer = this.pnlSearchOfficesContainer;
            resources.ApplyResources(this.pnlSearchOffices, "pnlSearchOffices");
            this.pnlSearchOffices.Name = "pnlSearchOffices";
            // 
            // pnlSearchOfficesContainer
            // 
            resources.ApplyResources(this.pnlSearchOfficesContainer, "pnlSearchOfficesContainer");
            this.pnlSearchOfficesContainer.Name = "pnlSearchOfficesContainer";
            // 
            // pnlBrowseOffice
            // 
            this.pnlBrowseOffice.InnerContainer = this.pnlBrowseOfficeContainer;
            resources.ApplyResources(this.pnlBrowseOffice, "pnlBrowseOffice");
            this.pnlBrowseOffice.Name = "pnlBrowseOffice";
            // 
            // pnlBrowseOfficeContainer
            // 
            resources.ApplyResources(this.pnlBrowseOfficeContainer, "pnlBrowseOfficeContainer");
            this.pnlBrowseOfficeContainer.Name = "pnlBrowseOfficeContainer";
            // 
            // pnlSearch
            // 
            this.pnlSearch.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator;
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.SelectedPanel = this.pnlSearchOffice;
            // 
            // btnReset
            // 
            this.btnReset.ImageVerticalAlignment = Janus.Windows.EditControls.ImageVerticalAlignment.Far;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            this.btnReset.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // fBrowseTemplates
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.Controls.Add(this.pnlTemplates);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.uiPanel0);
            this.Name = "fBrowseTemplates";
            this.Load += new System.EventHandler(this.fBrowseTemplate_load);
            this.Shown += new System.EventHandler(this.fBrowseTemplates_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.uiPanel0Container.ResumeLayout(false);
            this.uiPanel0Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.templateGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.templateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTemplates)).EndInit();
            this.pnlTemplates.ResumeLayout(false);
            this.pnlOfficesContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffice)).EndInit();
            this.pnlSearchOffice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffices)).EndInit();
            this.pnlBrowseOffices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearchOffices)).EndInit();
            this.pnlSearchOffices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBrowseOffice)).EndInit();
            this.pnlBrowseOffice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlTemplates;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlOfficesContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSearchOffice;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSearchOfficeContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSearchOffices;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSearchOfficesContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBrowseOffice;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBrowseOfficeContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBrowseOffices;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBrowseOfficesContainer;
        private Janus.Windows.GridEX.GridEX templateGridEX;
        private Janus.Windows.UI.Dock.UIPanel pnlBottom;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBottomContainer;
        private Janus.Windows.EditControls.UIButton buttonCancel;
        private Janus.Windows.EditControls.UIButton buttonOK;
        private System.Windows.Forms.BindingSource templateBindingSource;
        private lmDatasets.appDB appDB;
        private UserControls.ucDocView ucDocView1;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlSearch;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private Janus.Windows.EditControls.UIButton bSearch;
        private Janus.Windows.GridEX.EditControls.EditBox ebSearch;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.EditControls.UIButton btnReset;
    }
}
