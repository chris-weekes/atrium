namespace LawMate
{
    partial class fApptNotification
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
            Janus.Windows.GridEX.GridEXLayout gridEXNotification_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference gridEXNotification_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.Image");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fApptNotification));
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.topPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.topPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.gridEXNotification = new Janus.Windows.GridEX.GridEX();
            this.bSourceAppointmentDataview = new System.Windows.Forms.BindingSource(this.components);
            this.btnDismissAll = new Janus.Windows.EditControls.UIButton();
            this.btnDismiss = new Janus.Windows.EditControls.UIButton();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.ldlStart = new System.Windows.Forms.Label();
            this.lblSnooze = new System.Windows.Forms.Label();
            this.ucDDReminder = new LawMate.UserControls.ucMultiDropDown();
            this.btnSnooze = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPanel0)).BeginInit();
            this.topPanel0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSourceAppointmentDataview)).BeginInit();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.topPanel0.Id = new System.Guid("89e3d0ca-8fdf-4802-b5af-18061f4e335b");
            this.uiPanelManager1.Panels.Add(this.topPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("89e3d0ca-8fdf-4802-b5af-18061f4e335b"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(484, 328), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("89e3d0ca-8fdf-4802-b5af-18061f4e335b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // topPanel0
            // 
            resources.ApplyResources(this.topPanel0, "topPanel0");
            this.topPanel0.InnerContainer = this.topPanel0Container;
            this.topPanel0.Name = "topPanel0";
            // 
            // topPanel0Container
            // 
            resources.ApplyResources(this.topPanel0Container, "topPanel0Container");
            this.topPanel0Container.Name = "topPanel0Container";
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("fed1861b-3365-411f-a7a2-e6861ee333c1");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.BottomRebar1, "BottomRebar1");
            this.BottomRebar1.Name = "BottomRebar1";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.LeftRebar1, "LeftRebar1");
            this.LeftRebar1.Name = "LeftRebar1";
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.RightRebar1, "RightRebar1");
            this.RightRebar1.Name = "RightRebar1";
            // 
            // TopRebar1
            // 
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            // 
            // gridEXNotification
            // 
            this.gridEXNotification.AllowColumnDrag = false;
            this.gridEXNotification.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEXNotification.CardBorders = false;
            this.gridEXNotification.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
            this.gridEXNotification.DataSource = this.bSourceAppointmentDataview;
            gridEXNotification_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("gridEXNotification_DesignTimeLayout_Reference_0.Instance")));
            gridEXNotification_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            gridEXNotification_DesignTimeLayout_Reference_0});
            resources.ApplyResources(gridEXNotification_DesignTimeLayout, "gridEXNotification_DesignTimeLayout");
            this.gridEXNotification.DesignTimeLayout = gridEXNotification_DesignTimeLayout;
            this.gridEXNotification.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.None;
            this.gridEXNotification.FlatBorderInHeaders = false;
            this.gridEXNotification.FocusCellDisplayMode = Janus.Windows.GridEX.FocusCellDisplayMode.UseSelectedFormatStyle;
            this.gridEXNotification.GroupByBoxVisible = false;
            this.gridEXNotification.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            resources.ApplyResources(this.gridEXNotification, "gridEXNotification");
            this.gridEXNotification.Name = "gridEXNotification";
            this.gridEXNotification.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.gridEXNotification.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEXNotification.VisualStyleAreas.HeadersStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.gridEXNotification.SelectionChanged += new System.EventHandler(this.gridEX_SelectionChanged);
            // 
            // btnDismissAll
            // 
            resources.ApplyResources(this.btnDismissAll, "btnDismissAll");
            this.btnDismissAll.Name = "btnDismissAll";
            this.btnDismissAll.Click += new System.EventHandler(this.btnDismissAll_Click);
            // 
            // btnDismiss
            // 
            resources.ApplyResources(this.btnDismiss, "btnDismiss");
            this.btnDismiss.Name = "btnDismiss";
            this.btnDismiss.Click += new System.EventHandler(this.btnDismiss_Click);
            // 
            // lblSubject
            // 
            resources.ApplyResources(this.lblSubject, "lblSubject");
            this.lblSubject.Name = "lblSubject";
            // 
            // lblStartDate
            // 
            resources.ApplyResources(this.lblStartDate, "lblStartDate");
            this.lblStartDate.Name = "lblStartDate";
            // 
            // ldlStart
            // 
            resources.ApplyResources(this.ldlStart, "ldlStart");
            this.ldlStart.Name = "ldlStart";
            // 
            // lblSnooze
            // 
            resources.ApplyResources(this.lblSnooze, "lblSnooze");
            this.lblSnooze.Name = "lblSnooze";
            // 
            // ucDDReminder
            // 
            this.ucDDReminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.ucDDReminder.Column1 = "Interval";
            resources.ApplyResources(this.ucDDReminder, "ucDDReminder");
            this.ucDDReminder.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucDDReminder.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bSourceAppointmentDataview, "Interval", true));
            this.ucDDReminder.DataSource = null;
            this.ucDDReminder.DDColumn1Visible = false;
            this.ucDDReminder.DropDownColumn1Width = 100;
            this.ucDDReminder.DropDownColumn2Width = 300;
            this.ucDDReminder.Name = "ucDDReminder";
            this.ucDDReminder.ReadOnly = false;
            this.ucDDReminder.ReqColor = System.Drawing.SystemColors.Window;
            this.ucDDReminder.SelectedValue = null;
            this.ucDDReminder.ValueMember = "Interval";
            // 
            // btnSnooze
            // 
            resources.ApplyResources(this.btnSnooze, "btnSnooze");
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            // 
            // fApptNotification
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(218)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.btnSnooze);
            this.Controls.Add(this.ucDDReminder);
            this.Controls.Add(this.lblSnooze);
            this.Controls.Add(this.ldlStart);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.btnDismiss);
            this.Controls.Add(this.btnDismissAll);
            this.Controls.Add(this.gridEXNotification);
            this.Controls.Add(this.topPanel0);
            this.Controls.Add(this.LeftRebar1);
            this.Controls.Add(this.RightRebar1);
            this.Controls.Add(this.TopRebar1);
            this.Controls.Add(this.BottomRebar1);
            this.MaximizeBox = false;
            this.Name = "fApptNotification";
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topPanel0)).EndInit();
            this.topPanel0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridEXNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSourceAppointmentDataview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.GridEX.GridEX gridEXNotification;
        private Janus.Windows.EditControls.UIButton btnDismiss;
        private Janus.Windows.EditControls.UIButton btnDismissAll;
        private System.Windows.Forms.BindingSource bSourceAppointmentDataview;
        private Janus.Windows.UI.Dock.UIPanel topPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer topPanel0Container;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label ldlStart;
        private System.Windows.Forms.Label lblSnooze;
        private System.Windows.Forms.Button btnSnooze;
        private UserControls.ucMultiDropDown ucDDReminder;
    }
}