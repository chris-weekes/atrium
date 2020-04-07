namespace LawMate.Admin
{
    partial class fSelectFeatures
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSelectFeatures));
            Janus.Windows.GridEX.GridEXLayout secFeatureGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlBottom = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlBottomContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnOK = new Janus.Windows.EditControls.UIButton();
            this.pnlRelFldSelector = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlRelFldSelectorContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.secFeatureGridEX = new Janus.Windows.GridEX.GridEX();
            this.secFeatureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.securityDB = new lmDatasets.SecurityDB();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlBottomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRelFldSelector)).BeginInit();
            this.pnlRelFldSelector.SuspendLayout();
            this.pnlRelFldSelectorContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secFeatureGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secFeatureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionHeight = 34;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.Window;
            this.uiPanelManager1.DefaultPanelSettings.LightCaptionFormatStyle.FontName = "tahoma";
            this.uiPanelManager1.PanelPadding.Bottom = 12;
            this.uiPanelManager1.PanelPadding.Left = 12;
            this.uiPanelManager1.PanelPadding.Right = 12;
            this.uiPanelManager1.PanelPadding.Top = 12;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.VS2010;
            this.pnlBottom.Id = new System.Guid("ebbceece-8e86-4154-8b91-91a517e241a0");
            this.uiPanelManager1.Panels.Add(this.pnlBottom);
            this.pnlRelFldSelector.Id = new System.Guid("fde8c0ee-87fd-4ff0-9db6-80a9059eab1c");
            this.uiPanelManager1.Panels.Add(this.pnlRelFldSelector);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("fde8c0ee-87fd-4ff0-9db6-80a9059eab1c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(548, 408), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("ebbceece-8e86-4154-8b91-91a517e241a0"), Janus.Windows.UI.Dock.PanelDockStyle.Bottom, new System.Drawing.Size(548, 31), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ebbceece-8e86-4154-8b91-91a517e241a0"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("fde8c0ee-87fd-4ff0-9db6-80a9059eab1c"), new System.Drawing.Point(392, 327), new System.Drawing.Size(200, 200), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderPanel = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlBottom.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlBottom.InnerContainer = this.pnlBottomContainer;
            this.pnlBottom.Location = new System.Drawing.Point(12, 420);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(548, 31);
            this.pnlBottom.TabIndex = 4;
            // 
            // pnlBottomContainer
            // 
            this.pnlBottomContainer.Controls.Add(this.btnCancel);
            this.pnlBottomContainer.Controls.Add(this.btnOK);
            this.pnlBottomContainer.Location = new System.Drawing.Point(0, 4);
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            this.pnlBottomContainer.Size = new System.Drawing.Size(548, 27);
            this.pnlBottomContainer.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(464, -1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(367, -1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pnlRelFldSelector
            // 
            this.pnlRelFldSelector.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.pnlRelFldSelector.FloatingLocation = new System.Drawing.Point(392, 327);
            this.pnlRelFldSelector.Image = ((System.Drawing.Image)(resources.GetObject("pnlRelFldSelector.Image")));
            this.pnlRelFldSelector.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlRelFldSelector.InnerContainer = this.pnlRelFldSelectorContainer;
            this.pnlRelFldSelector.Location = new System.Drawing.Point(12, 12);
            this.pnlRelFldSelector.Name = "pnlRelFldSelector";
            this.pnlRelFldSelector.Size = new System.Drawing.Size(548, 408);
            this.pnlRelFldSelector.TabIndex = 4;
            this.pnlRelFldSelector.Text = "Select the Features you want to add to this Rule by using the checkbox in the fir" +
    "st column";
            // 
            // pnlRelFldSelectorContainer
            // 
            this.pnlRelFldSelectorContainer.Controls.Add(this.secFeatureGridEX);
            this.pnlRelFldSelectorContainer.Location = new System.Drawing.Point(1, 34);
            this.pnlRelFldSelectorContainer.Name = "pnlRelFldSelectorContainer";
            this.pnlRelFldSelectorContainer.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.pnlRelFldSelectorContainer.Size = new System.Drawing.Size(546, 373);
            this.pnlRelFldSelectorContainer.TabIndex = 0;
            // 
            // secFeatureGridEX
            // 
            this.secFeatureGridEX.AllowColumnDrag = false;
            this.secFeatureGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.secFeatureGridEX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secFeatureGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.secFeatureGridEX.CardInnerSpacing = 4;
            this.secFeatureGridEX.CardWidth = 650;
            this.secFeatureGridEX.DataSource = this.secFeatureBindingSource;
            secFeatureGridEX_DesignTimeLayout.LayoutString = resources.GetString("secFeatureGridEX_DesignTimeLayout.LayoutString");
            this.secFeatureGridEX.DesignTimeLayout = secFeatureGridEX_DesignTimeLayout;
            this.secFeatureGridEX.DynamicFiltering = true;
            this.secFeatureGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.secFeatureGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.secFeatureGridEX.GridLineColor = System.Drawing.SystemColors.ControlText;
            this.secFeatureGridEX.GridLines = Janus.Windows.GridEX.GridLines.RowOutline;
            this.secFeatureGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.secFeatureGridEX.GroupByBoxVisible = false;
            this.secFeatureGridEX.GroupExpandBoxStyle = Janus.Windows.GridEX.ExpandBoxStyle.Classic;
            this.secFeatureGridEX.GroupRowFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.SunkenLight;
            this.secFeatureGridEX.GroupRowFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.secFeatureGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
            this.secFeatureGridEX.Location = new System.Drawing.Point(0, 5);
            this.secFeatureGridEX.Name = "secFeatureGridEX";
            this.secFeatureGridEX.RowFormatStyle.BackColor = System.Drawing.Color.Empty;
            this.secFeatureGridEX.RowFormatStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.secFeatureGridEX.Size = new System.Drawing.Size(547, 365);
            this.secFeatureGridEX.TabIndex = 0;
            this.secFeatureGridEX.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.secFeatureGridEX.TableHeaderFormatStyle.FontName = "calibri";
            this.secFeatureGridEX.TableHeaderFormatStyle.FontSize = 14F;
            this.secFeatureGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.VS2010;
            this.secFeatureGridEX.RowCheckStateChanged += new Janus.Windows.GridEX.RowCheckStateChangeEventHandler(this.secFeatureGridEX_RowCheckStateChanged);
            this.secFeatureGridEX.FormattingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.secFeatureGridEX_FormattingRow);
            // 
            // secFeatureBindingSource
            // 
            this.secFeatureBindingSource.DataMember = "secFeature";
            this.secFeatureBindingSource.DataSource = this.securityDB;
            // 
            // securityDB
            // 
            this.securityDB.DataSetName = "SecurityDB";
            this.securityDB.EnforceConstraints = false;
            this.securityDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // fSelectFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(572, 463);
            this.Controls.Add(this.pnlRelFldSelector);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fSelectFeatures";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Related Fields Selector";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottomContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlRelFldSelector)).EndInit();
            this.pnlRelFldSelector.ResumeLayout(false);
            this.pnlRelFldSelectorContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secFeatureGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secFeatureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.securityDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.UI.Dock.UIPanel pnlRelFldSelector;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlRelFldSelectorContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlBottom;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlBottomContainer;
        private Janus.Windows.EditControls.UIButton btnOK;
        private Janus.Windows.GridEX.GridEX secFeatureGridEX;
        private System.Windows.Forms.BindingSource secFeatureBindingSource;
        private lmDatasets.SecurityDB securityDB;
    }
}
