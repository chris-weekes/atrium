 namespace LawMate.Admin
{
    partial class fOfficerPreferences
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
            Janus.Windows.GridEX.GridEXLayout officerPrefsGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOfficerPreferences));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.officerPrefsGridEX = new Janus.Windows.GridEX.GridEX();
            this.officerPrefsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.officeDB = new lmDatasets.officeDB();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.officerPrefsGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerPrefsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Light;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("1c629ce5-a267-4d7e-a718-030936886e4c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("1c629ce5-a267-4d7e-a718-030936886e4c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(934, 503), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("1c629ce5-a267-4d7e-a718-030936886e4c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Location = new System.Drawing.Point(3, 3);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(934, 503);
            this.pnlAll.TabIndex = 4;
            this.pnlAll.Text = " Officer Preferences";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.Controls.Add(this.officerPrefsGridEX);
            this.pnlAllContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.pnlAllContainer.Size = new System.Drawing.Size(932, 501);
            this.pnlAllContainer.TabIndex = 0;
            // 
            // officerPrefsGridEX
            // 
            this.officerPrefsGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.officerPrefsGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.officerPrefsGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.officerPrefsGridEX.DataSource = this.officerPrefsBindingSource;
            officerPrefsGridEX_DesignTimeLayout.LayoutString = resources.GetString("officerPrefsGridEX_DesignTimeLayout.LayoutString");
            this.officerPrefsGridEX.DesignTimeLayout = officerPrefsGridEX_DesignTimeLayout;
            this.officerPrefsGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.officerPrefsGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.officerPrefsGridEX.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.officerPrefsGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.officerPrefsGridEX.GroupIndent = 28;
            this.officerPrefsGridEX.GroupRowFormatStyle.BackColor = System.Drawing.Color.PowderBlue;
            this.officerPrefsGridEX.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.LightSkyBlue;
            this.officerPrefsGridEX.GroupRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
            this.officerPrefsGridEX.GroupRowFormatStyle.FontSize = 7F;
            this.officerPrefsGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.officerPrefsGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.officerPrefsGridEX.Location = new System.Drawing.Point(0, 0);
            this.officerPrefsGridEX.Name = "officerPrefsGridEX";
            this.officerPrefsGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.officerPrefsGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.officerPrefsGridEX.Size = new System.Drawing.Size(932, 501);
            this.officerPrefsGridEX.TabIndex = 0;
            this.officerPrefsGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.officerPrefsGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officerPrefsBindingSource
            // 
            this.officerPrefsBindingSource.DataMember = "OfficerPrefs";
            this.officerPrefsBindingSource.DataSource = this.officeDB;
            // 
            // officeDB
            // 
            this.officeDB.DataSetName = "officeDB";
            this.officeDB.EnforceConstraints = false;
            this.officeDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // fOfficerPreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(940, 509);
            this.Controls.Add(this.pnlAll);
            this.Name = "fOfficerPreferences";
            this.Text = "Officer Preferences";
            this.Load += new System.EventHandler(this.fOfficerPreferences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.officerPrefsGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officerPrefsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeDB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.GridEX.GridEX officerPrefsGridEX;
        private System.Windows.Forms.BindingSource officerPrefsBindingSource;
        private lmDatasets.officeDB officeDB;
    }
}
