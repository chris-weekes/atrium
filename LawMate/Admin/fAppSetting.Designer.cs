namespace LawMate.Admin
{
    partial class fAppSetting
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
            System.Windows.Forms.Label settingIdLabel;
            System.Windows.Forms.Label settingNameLabel;
            System.Windows.Forms.Label settingValueLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAppSetting));
            Janus.Windows.GridEX.GridEXLayout appSettingGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.settingIdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.appSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appDB = new lmDatasets.appDB();
            this.settingNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.settingValueEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.appSettingGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlmessage = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlmessageContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            settingIdLabel = new System.Windows.Forms.Label();
            settingNameLabel = new System.Windows.Forms.Label();
            settingValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appSettingGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlmessage)).BeginInit();
            this.pnlmessage.SuspendLayout();
            this.pnlmessageContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // settingIdLabel
            // 
            settingIdLabel.AutoSize = true;
            settingIdLabel.BackColor = System.Drawing.Color.Transparent;
            settingIdLabel.Location = new System.Drawing.Point(474, 11);
            settingIdLabel.Name = "settingIdLabel";
            settingIdLabel.Size = new System.Drawing.Size(58, 13);
            settingIdLabel.TabIndex = 1;
            settingIdLabel.Text = "Setting Id:";
            // 
            // settingNameLabel
            // 
            settingNameLabel.AutoSize = true;
            settingNameLabel.BackColor = System.Drawing.Color.Transparent;
            settingNameLabel.Location = new System.Drawing.Point(474, 38);
            settingNameLabel.Name = "settingNameLabel";
            settingNameLabel.Size = new System.Drawing.Size(75, 13);
            settingNameLabel.TabIndex = 3;
            settingNameLabel.Text = "Setting Name:";
            // 
            // settingValueLabel
            // 
            settingValueLabel.AutoSize = true;
            settingValueLabel.BackColor = System.Drawing.Color.Transparent;
            settingValueLabel.Location = new System.Drawing.Point(474, 66);
            settingValueLabel.Name = "settingValueLabel";
            settingValueLabel.Size = new System.Drawing.Size(74, 13);
            settingValueLabel.TabIndex = 5;
            settingValueLabel.Text = "Setting Value:";
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave,
            this.cmdCancel});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("579ecc65-9bb9-4f7b-aaf6-dbab86fc13f6");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.LockCommandBars = true;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.ShowQuickCustomizeMenu = false;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 509);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(830, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave1,
            this.Separator1,
            this.cmdCancel1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.Size = new System.Drawing.Size(880, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            this.uiCommandBar1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // cmdSave1
            // 
            this.cmdSave1.Key = "cmdSave";
            this.cmdSave1.Name = "cmdSave1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdCancel1
            // 
            this.cmdCancel1.Key = "cmdCancel";
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // cmdSave
            // 
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Key = "cmdSave";
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Text = "Save";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancel.Image")));
            this.cmdCancel.Key = "cmdCancel";
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Text = "Cancel";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 509);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(830, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 509);
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopRebar1.Location = new System.Drawing.Point(0, 0);
            this.TopRebar1.Name = "TopRebar1";
            this.TopRebar1.Size = new System.Drawing.Size(880, 28);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = false;
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = 0;
            this.uiPanelManager1.PanelPadding.Left = 0;
            this.uiPanelManager1.PanelPadding.Right = 0;
            this.uiPanelManager1.PanelPadding.Top = 0;
            this.uiPanelManager1.SplitterSize = 0;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlmessage.Id = new System.Guid("a200b905-bcc2-422b-9796-7be7a703ab66");
            this.uiPanelManager1.Panels.Add(this.pnlmessage);
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(880, 338), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a200b905-bcc2-422b-9796-7be7a703ab66"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(880, 50), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Location = new System.Drawing.Point(0, 78);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(880, 338);
            this.pnlAll.TabIndex = 8;
            this.pnlAll.Text = "Personnel";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.AutoScroll = true;
            this.pnlAllContainer.AutoScrollMargin = new System.Drawing.Size(0, 12);
            this.pnlAllContainer.Controls.Add(settingIdLabel);
            this.pnlAllContainer.Controls.Add(this.settingIdEditBox);
            this.pnlAllContainer.Controls.Add(settingNameLabel);
            this.pnlAllContainer.Controls.Add(this.settingNameEditBox);
            this.pnlAllContainer.Controls.Add(settingValueLabel);
            this.pnlAllContainer.Controls.Add(this.settingValueEditBox);
            this.pnlAllContainer.Controls.Add(this.appSettingGridEX);
            this.pnlAllContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.pnlAllContainer.Size = new System.Drawing.Size(880, 338);
            this.pnlAllContainer.TabIndex = 0;
            // 
            // settingIdEditBox
            // 
            this.settingIdEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.settingIdEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appSettingBindingSource, "SettingId", true));
            this.settingIdEditBox.Location = new System.Drawing.Point(565, 6);
            this.settingIdEditBox.Name = "settingIdEditBox";
            this.settingIdEditBox.ReadOnly = true;
            this.settingIdEditBox.Size = new System.Drawing.Size(90, 21);
            this.settingIdEditBox.TabIndex = 2;
            this.settingIdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // appSettingBindingSource
            // 
            this.appSettingBindingSource.DataMember = "AppSetting";
            this.appSettingBindingSource.DataSource = this.appDB;
            this.appSettingBindingSource.CurrentChanged += new System.EventHandler(this.appSettingBindingSource_CurrentChanged);
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // settingNameEditBox
            // 
            this.settingNameEditBox.ButtonImage = ((System.Drawing.Image)(resources.GetObject("settingNameEditBox.ButtonImage")));
            this.settingNameEditBox.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image;
            this.settingNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appSettingBindingSource, "SettingName", true));
            this.settingNameEditBox.Location = new System.Drawing.Point(565, 33);
            this.settingNameEditBox.Name = "settingNameEditBox";
            this.settingNameEditBox.ReadOnly = true;
            this.settingNameEditBox.Size = new System.Drawing.Size(285, 22);
            this.settingNameEditBox.TabIndex = 4;
            this.settingNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.settingNameEditBox.ButtonClick += new System.EventHandler(this.settingNameEditBox_ButtonClick);
            // 
            // settingValueEditBox
            // 
            this.settingValueEditBox.ButtonImage = ((System.Drawing.Image)(resources.GetObject("settingValueEditBox.ButtonImage")));
            this.settingValueEditBox.ButtonStyle = Janus.Windows.GridEX.EditControls.EditButtonStyle.Image;
            this.settingValueEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.appSettingBindingSource, "SettingValue", true));
            this.settingValueEditBox.Location = new System.Drawing.Point(565, 61);
            this.settingValueEditBox.Name = "settingValueEditBox";
            this.settingValueEditBox.ReadOnly = true;
            this.settingValueEditBox.Size = new System.Drawing.Size(285, 22);
            this.settingValueEditBox.TabIndex = 6;
            this.settingValueEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.settingValueEditBox.ButtonClick += new System.EventHandler(this.settingValueEditBox_ButtonClick);
            // 
            // appSettingGridEX
            // 
            this.appSettingGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.appSettingGridEX.DataSource = this.appSettingBindingSource;
            appSettingGridEX_DesignTimeLayout.LayoutString = resources.GetString("appSettingGridEX_DesignTimeLayout.LayoutString");
            this.appSettingGridEX.DesignTimeLayout = appSettingGridEX_DesignTimeLayout;
            this.appSettingGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.appSettingGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.appSettingGridEX.GroupByBoxVisible = false;
            this.appSettingGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.appSettingGridEX.Location = new System.Drawing.Point(12, 6);
            this.appSettingGridEX.Name = "appSettingGridEX";
            this.appSettingGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.appSettingGridEX.Size = new System.Drawing.Size(441, 310);
            this.appSettingGridEX.TabIndex = 0;
            this.appSettingGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // pnlmessage
            // 
            this.pnlmessage.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlmessage.InnerContainer = this.pnlmessageContainer;
            this.pnlmessage.Location = new System.Drawing.Point(0, 28);
            this.pnlmessage.Name = "pnlmessage";
            this.pnlmessage.Size = new System.Drawing.Size(880, 50);
            this.pnlmessage.TabIndex = 4;
            // 
            // pnlmessageContainer
            // 
            this.pnlmessageContainer.Controls.Add(this.pictureBox1);
            this.pnlmessageContainer.Controls.Add(this.label1);
            this.pnlmessageContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlmessageContainer.Name = "pnlmessageContainer";
            this.pnlmessageContainer.Size = new System.Drawing.Size(880, 50);
            this.pnlmessageContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Application Settings cannot be added.  They must first be implemented through" +
    " programming, therefore you can only modify the values of the existing Applicati" +
    "on Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LawMate.Properties.Resources.lightbulb;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // fAppSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(880, 416);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.pnlmessage);
            this.Controls.Add(this.TopRebar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fAppSetting";
            this.ShowIcon = true;
            this.Text = "Application Settings";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appSettingGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlmessage)).EndInit();
            this.pnlmessage.ResumeLayout(false);
            this.pnlmessageContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.GridEX.EditControls.EditBox settingIdEditBox;
        private System.Windows.Forms.BindingSource appSettingBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.GridEX.EditControls.EditBox settingNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox settingValueEditBox;
        private Janus.Windows.GridEX.GridEX appSettingGridEX;
        private Janus.Windows.UI.Dock.UIPanel pnlmessage;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlmessageContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
