using System.Data;
 namespace LawMate
{
    partial class ucCashBlotter
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

                FM.GetCLASMng().DB.CBDetail.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetCLASMng().GetCBDetail().OnUpdate -= new atLogic.UpdateEventHandler(ucCashBlotter_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCashBlotter));
            System.Windows.Forms.Label receivedDateLabel;
            System.Windows.Forms.Label paymentSourceLabel;
            System.Windows.Forms.Label valuableTypeLabel;
            System.Windows.Forms.Label valuableAmountLabel;
            System.Windows.Forms.Label valuableDateLabel;
            System.Windows.Forms.Label natureOfPaymentLabel;
            System.Windows.Forms.Label statusCodeLabel;
            System.Windows.Forms.Label currencyCodeLabel;
            System.Windows.Forms.Label officeIDLabel;
            System.Windows.Forms.Label commentsLabel;
            System.Windows.Forms.Label cashBlotterIDLabel;
            Janus.Windows.GridEX.GridEXLayout cBDetailGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.btnGoToOfficeCB = new Janus.Windows.EditControls.UIButton();
            this.ucOfficeSelectBox1 = new LawMate.ucOfficeSelectBox();
            this.cBDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CLAS = new lmDatasets.CLAS();
            this.editBox1 = new Janus.Windows.GridEX.EditControls.EditBox();
            this.commentsEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.valuableAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.valuableTypeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.currencyCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.statusCodeComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.receivedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.paymentSourceComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.natureOfPaymentComboBox = new LawMate.UserControls.ucMultiDropDown();
            this.valuableDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.lblMoreThan2NSFs = new System.Windows.Forms.Label();
            this.tbCompletedPayments = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.tbAllPayments = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBDetailGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditMode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditMode = new Janus.Windows.UI.CommandBars.UICommand("tsEditMode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            receivedDateLabel = new System.Windows.Forms.Label();
            paymentSourceLabel = new System.Windows.Forms.Label();
            valuableTypeLabel = new System.Windows.Forms.Label();
            valuableAmountLabel = new System.Windows.Forms.Label();
            valuableDateLabel = new System.Windows.Forms.Label();
            natureOfPaymentLabel = new System.Windows.Forms.Label();
            statusCodeLabel = new System.Windows.Forms.Label();
            currencyCodeLabel = new System.Windows.Forms.Label();
            officeIDLabel = new System.Windows.Forms.Label();
            commentsLabel = new System.Windows.Forms.Label();
            cashBlotterIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.cBDetailBindingSource;
            // 
            // imageListBase
            // 
            this.imageListBase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBase.ImageStream")));
            this.imageListBase.Images.SetKeyName(0, "");
            this.imageListBase.Images.SetKeyName(1, "");
            this.imageListBase.Images.SetKeyName(2, "");
            this.imageListBase.Images.SetKeyName(3, "");
            this.imageListBase.Images.SetKeyName(4, "");
            this.imageListBase.Images.SetKeyName(5, "");
            this.imageListBase.Images.SetKeyName(6, "");
            this.imageListBase.Images.SetKeyName(7, "");
            this.imageListBase.Images.SetKeyName(8, "");
            this.imageListBase.Images.SetKeyName(9, "");
            this.imageListBase.Images.SetKeyName(10, "");
            this.imageListBase.Images.SetKeyName(11, "");
            this.imageListBase.Images.SetKeyName(12, "");
            this.imageListBase.Images.SetKeyName(13, "");
            this.imageListBase.Images.SetKeyName(14, "");
            this.imageListBase.Images.SetKeyName(15, "");
            this.imageListBase.Images.SetKeyName(16, "");
            this.imageListBase.Images.SetKeyName(17, "");
            this.imageListBase.Images.SetKeyName(18, "DRedit.gif");
            this.imageListBase.Images.SetKeyName(19, "audit.gif");
            // 
            // receivedDateLabel
            // 
            resources.ApplyResources(receivedDateLabel, "receivedDateLabel");
            receivedDateLabel.BackColor = System.Drawing.Color.Transparent;
            receivedDateLabel.Name = "receivedDateLabel";
            this.helpProvider1.SetShowHelp(receivedDateLabel, ((bool)(resources.GetObject("receivedDateLabel.ShowHelp"))));
            // 
            // paymentSourceLabel
            // 
            resources.ApplyResources(paymentSourceLabel, "paymentSourceLabel");
            paymentSourceLabel.BackColor = System.Drawing.Color.Transparent;
            paymentSourceLabel.Name = "paymentSourceLabel";
            this.helpProvider1.SetShowHelp(paymentSourceLabel, ((bool)(resources.GetObject("paymentSourceLabel.ShowHelp"))));
            // 
            // valuableTypeLabel
            // 
            resources.ApplyResources(valuableTypeLabel, "valuableTypeLabel");
            valuableTypeLabel.BackColor = System.Drawing.Color.Transparent;
            valuableTypeLabel.Name = "valuableTypeLabel";
            this.helpProvider1.SetShowHelp(valuableTypeLabel, ((bool)(resources.GetObject("valuableTypeLabel.ShowHelp"))));
            // 
            // valuableAmountLabel
            // 
            resources.ApplyResources(valuableAmountLabel, "valuableAmountLabel");
            valuableAmountLabel.BackColor = System.Drawing.Color.Transparent;
            valuableAmountLabel.Name = "valuableAmountLabel";
            this.helpProvider1.SetShowHelp(valuableAmountLabel, ((bool)(resources.GetObject("valuableAmountLabel.ShowHelp"))));
            // 
            // valuableDateLabel
            // 
            resources.ApplyResources(valuableDateLabel, "valuableDateLabel");
            valuableDateLabel.BackColor = System.Drawing.Color.Transparent;
            valuableDateLabel.Name = "valuableDateLabel";
            this.helpProvider1.SetShowHelp(valuableDateLabel, ((bool)(resources.GetObject("valuableDateLabel.ShowHelp"))));
            // 
            // natureOfPaymentLabel
            // 
            resources.ApplyResources(natureOfPaymentLabel, "natureOfPaymentLabel");
            natureOfPaymentLabel.BackColor = System.Drawing.Color.Transparent;
            natureOfPaymentLabel.Name = "natureOfPaymentLabel";
            this.helpProvider1.SetShowHelp(natureOfPaymentLabel, ((bool)(resources.GetObject("natureOfPaymentLabel.ShowHelp"))));
            // 
            // statusCodeLabel
            // 
            resources.ApplyResources(statusCodeLabel, "statusCodeLabel");
            statusCodeLabel.BackColor = System.Drawing.Color.Transparent;
            statusCodeLabel.Name = "statusCodeLabel";
            this.helpProvider1.SetShowHelp(statusCodeLabel, ((bool)(resources.GetObject("statusCodeLabel.ShowHelp"))));
            // 
            // currencyCodeLabel
            // 
            resources.ApplyResources(currencyCodeLabel, "currencyCodeLabel");
            currencyCodeLabel.BackColor = System.Drawing.Color.Transparent;
            currencyCodeLabel.Name = "currencyCodeLabel";
            this.helpProvider1.SetShowHelp(currencyCodeLabel, ((bool)(resources.GetObject("currencyCodeLabel.ShowHelp"))));
            // 
            // officeIDLabel
            // 
            resources.ApplyResources(officeIDLabel, "officeIDLabel");
            officeIDLabel.BackColor = System.Drawing.Color.Transparent;
            officeIDLabel.Name = "officeIDLabel";
            this.helpProvider1.SetShowHelp(officeIDLabel, ((bool)(resources.GetObject("officeIDLabel.ShowHelp"))));
            // 
            // commentsLabel
            // 
            resources.ApplyResources(commentsLabel, "commentsLabel");
            commentsLabel.BackColor = System.Drawing.Color.Transparent;
            commentsLabel.Name = "commentsLabel";
            this.helpProvider1.SetShowHelp(commentsLabel, ((bool)(resources.GetObject("commentsLabel.ShowHelp"))));
            // 
            // cashBlotterIDLabel
            // 
            resources.ApplyResources(cashBlotterIDLabel, "cashBlotterIDLabel");
            cashBlotterIDLabel.BackColor = System.Drawing.Color.Transparent;
            cashBlotterIDLabel.Name = "cashBlotterIDLabel";
            this.helpProvider1.SetShowHelp(cashBlotterIDLabel, ((bool)(resources.GetObject("cashBlotterIDLabel.ShowHelp"))));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.AllowPanelResize = false;
            this.uiPanelManager1.BackColorGradientSplitter = System.Drawing.Color.White;
            this.uiPanelManager1.BackColorSplitter = System.Drawing.SystemColors.Control;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackColor = System.Drawing.Color.GhostWhite;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackColorGradient = System.Drawing.Color.SteelBlue;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.BlendGradient = 0.2F;
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlGrid.Id = new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01");
            this.uiPanelManager1.Panels.Add(this.pnlGrid);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(757, 509), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("dfda71cf-ab3f-47c3-aca6-c56befdc2f01"), new System.Drawing.Point(110, 145), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e3f110de-6163-4ce2-9f98-11895e93a274"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ddb7cd2a-0f8f-4b59-b734-c0cd75555fac"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7915bdab-733d-4860-8369-72faa5ba24de"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("0b04cb99-a0ca-4630-9bf2-db3ddf5440fb"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c3c29af3-af5c-4f04-a1c5-f26e3699372b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("8daabda9-ee30-44d5-a4cc-ba4716c3635a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("06e5b083-a7a3-4541-ad66-c662e7b965c1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c94e8660-e166-42fe-b72b-97e571a2f1ba"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlGrid
            // 
            this.pnlGrid.CaptionFormatStyle.BackgroundGradientMode = Janus.Windows.UI.BackgroundGradientMode.Vertical;
            this.pnlGrid.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlGrid.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlGrid.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlGrid.FloatingLocation = new System.Drawing.Point(110, 145);
            this.pnlGrid.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            this.helpProvider1.SetShowHelp(this.pnlGrid, ((bool)(resources.GetObject("pnlGrid.ShowHelp"))));
            // 
            // pnlGridContainer
            // 
            resources.ApplyResources(this.pnlGridContainer, "pnlGridContainer");
            this.pnlGridContainer.Controls.Add(this.uiTab3);
            this.pnlGridContainer.Controls.Add(this.lblMoreThan2NSFs);
            this.pnlGridContainer.Controls.Add(this.tbCompletedPayments);
            this.pnlGridContainer.Controls.Add(this.tbAllPayments);
            this.pnlGridContainer.Controls.Add(this.label2);
            this.pnlGridContainer.Controls.Add(this.label1);
            this.pnlGridContainer.Controls.Add(this.cBDetailGridEX);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.helpProvider1.SetShowHelp(this.pnlGridContainer, ((bool)(resources.GetObject("pnlGridContainer.ShowHelp"))));
            // 
            // uiTab3
            // 
            resources.ApplyResources(this.uiTab3, "uiTab3");
            this.uiTab3.BackColor = System.Drawing.Color.Transparent;
            this.uiTab3.Name = "uiTab3";
            this.uiTab3.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab3.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab3, ((bool)(resources.GetObject("uiTab3.ShowHelp"))));
            this.uiTab3.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage3});
            this.uiTab3.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab3.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab3.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab3.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab3.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab3.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab3.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage3
            // 
            this.uiTabPage3.Controls.Add(this.btnGoToOfficeCB);
            this.uiTabPage3.Controls.Add(cashBlotterIDLabel);
            this.uiTabPage3.Controls.Add(this.ucOfficeSelectBox1);
            this.uiTabPage3.Controls.Add(valuableAmountLabel);
            this.uiTabPage3.Controls.Add(this.editBox1);
            this.uiTabPage3.Controls.Add(paymentSourceLabel);
            this.uiTabPage3.Controls.Add(this.commentsEditBox);
            this.uiTabPage3.Controls.Add(currencyCodeLabel);
            this.uiTabPage3.Controls.Add(this.valuableAmountNumericEditBox);
            this.uiTabPage3.Controls.Add(natureOfPaymentLabel);
            this.uiTabPage3.Controls.Add(this.valuableTypeComboBox);
            this.uiTabPage3.Controls.Add(commentsLabel);
            this.uiTabPage3.Controls.Add(this.currencyCodeComboBox);
            this.uiTabPage3.Controls.Add(valuableTypeLabel);
            this.uiTabPage3.Controls.Add(this.statusCodeComboBox);
            this.uiTabPage3.Controls.Add(officeIDLabel);
            this.uiTabPage3.Controls.Add(statusCodeLabel);
            this.uiTabPage3.Controls.Add(this.receivedDateCalendarCombo);
            this.uiTabPage3.Controls.Add(this.paymentSourceComboBox);
            this.uiTabPage3.Controls.Add(receivedDateLabel);
            this.uiTabPage3.Controls.Add(this.natureOfPaymentComboBox);
            this.uiTabPage3.Controls.Add(this.valuableDateCalendarCombo);
            this.uiTabPage3.Controls.Add(valuableDateLabel);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // btnGoToOfficeCB
            // 
            this.btnGoToOfficeCB.Image = global::LawMate.Properties.Resources.folder;
            resources.ApplyResources(this.btnGoToOfficeCB, "btnGoToOfficeCB");
            this.btnGoToOfficeCB.Name = "btnGoToOfficeCB";
            this.helpProvider1.SetShowHelp(this.btnGoToOfficeCB, ((bool)(resources.GetObject("btnGoToOfficeCB.ShowHelp"))));
            this.btnGoToOfficeCB.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnGoToOfficeCB.Click += new System.EventHandler(this.btnGoToOfficeCB_Click);
            // 
            // ucOfficeSelectBox1
            // 
            this.ucOfficeSelectBox1.AtMng = null;
            this.ucOfficeSelectBox1.BackColor = System.Drawing.Color.Transparent;
            this.ucOfficeSelectBox1.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.cBDetailBindingSource, "OfficeID", true));
            resources.ApplyResources(this.ucOfficeSelectBox1, "ucOfficeSelectBox1");
            this.ucOfficeSelectBox1.Name = "ucOfficeSelectBox1";
            this.ucOfficeSelectBox1.OfficeId = null;
            this.ucOfficeSelectBox1.ReadOnly = true;
            this.ucOfficeSelectBox1.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.ucOfficeSelectBox1, ((bool)(resources.GetObject("ucOfficeSelectBox1.ShowHelp"))));
            // 
            // cBDetailBindingSource
            // 
            this.cBDetailBindingSource.DataMember = "CBDetail";
            this.cBDetailBindingSource.DataSource = this.CLAS;
            this.cBDetailBindingSource.CurrentChanged += new System.EventHandler(this.cBDetailBindingSource_CurrentChanged);
            // 
            // CLAS
            // 
            this.CLAS.DataSetName = "CLAS";
            this.CLAS.EnforceConstraints = false;
            this.CLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.CLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.SystemColors.Control;
            this.editBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cBDetailBindingSource, "CashBlotterID", true));
            resources.ApplyResources(this.editBox1, "editBox1");
            this.editBox1.Name = "editBox1";
            this.editBox1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.editBox1, ((bool)(resources.GetObject("editBox1.ShowHelp"))));
            this.editBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // commentsEditBox
            // 
            this.commentsEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.commentsEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cBDetailBindingSource, "Comments", true));
            resources.ApplyResources(this.commentsEditBox, "commentsEditBox");
            this.commentsEditBox.Multiline = true;
            this.commentsEditBox.Name = "commentsEditBox";
            this.commentsEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.commentsEditBox, ((bool)(resources.GetObject("commentsEditBox.ShowHelp"))));
            this.commentsEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // valuableAmountNumericEditBox
            // 
            this.valuableAmountNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.valuableAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cBDetailBindingSource, "ValuableAmount", true));
            this.valuableAmountNumericEditBox.DecimalDigits = 2;
            this.valuableAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.valuableAmountNumericEditBox, "valuableAmountNumericEditBox");
            this.valuableAmountNumericEditBox.Name = "valuableAmountNumericEditBox";
            this.valuableAmountNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.valuableAmountNumericEditBox, ((bool)(resources.GetObject("valuableAmountNumericEditBox.ShowHelp"))));
            this.valuableAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valuableAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // valuableTypeComboBox
            // 
            this.valuableTypeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.valuableTypeComboBox.Column1 = "CBInstrumentTypeDescEng";
            resources.ApplyResources(this.valuableTypeComboBox, "valuableTypeComboBox");
            this.valuableTypeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.valuableTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "ValuableType", true));
            this.valuableTypeComboBox.DataSource = null;
            this.valuableTypeComboBox.DDColumn1Visible = true;
            this.valuableTypeComboBox.DropDownColumn1Width = 100;
            this.valuableTypeComboBox.DropDownColumn2Width = 300;
            this.valuableTypeComboBox.Name = "valuableTypeComboBox";
            this.valuableTypeComboBox.ReadOnly = true;
            this.valuableTypeComboBox.ReqColor = System.Drawing.SystemColors.Control;
            this.valuableTypeComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.valuableTypeComboBox, ((bool)(resources.GetObject("valuableTypeComboBox.ShowHelp"))));
            this.valuableTypeComboBox.ValueMember = "CBInstrumentType";
            // 
            // currencyCodeComboBox
            // 
            this.currencyCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.currencyCodeComboBox.Column1 = "CurrencyDescEng";
            resources.ApplyResources(this.currencyCodeComboBox, "currencyCodeComboBox");
            this.currencyCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.currencyCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "CurrencyCode", true));
            this.currencyCodeComboBox.DataSource = null;
            this.currencyCodeComboBox.DDColumn1Visible = true;
            this.currencyCodeComboBox.DropDownColumn1Width = 100;
            this.currencyCodeComboBox.DropDownColumn2Width = 300;
            this.currencyCodeComboBox.Name = "currencyCodeComboBox";
            this.currencyCodeComboBox.ReadOnly = true;
            this.currencyCodeComboBox.ReqColor = System.Drawing.SystemColors.Control;
            this.currencyCodeComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.currencyCodeComboBox, ((bool)(resources.GetObject("currencyCodeComboBox.ShowHelp"))));
            this.currencyCodeComboBox.ValueMember = "CurrencyCode";
            // 
            // statusCodeComboBox
            // 
            this.statusCodeComboBox.BackColor = System.Drawing.Color.Transparent;
            this.statusCodeComboBox.Column1 = "CBStatus";
            resources.ApplyResources(this.statusCodeComboBox, "statusCodeComboBox");
            this.statusCodeComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.statusCodeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "StatusCode", true));
            this.statusCodeComboBox.DataSource = null;
            this.statusCodeComboBox.DDColumn1Visible = true;
            this.statusCodeComboBox.DropDownColumn1Width = 100;
            this.statusCodeComboBox.DropDownColumn2Width = 300;
            this.statusCodeComboBox.Name = "statusCodeComboBox";
            this.statusCodeComboBox.ReadOnly = false;
            this.statusCodeComboBox.ReqColor = System.Drawing.SystemColors.Window;
            this.statusCodeComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.statusCodeComboBox, ((bool)(resources.GetObject("statusCodeComboBox.ShowHelp"))));
            this.statusCodeComboBox.ValueMember = "CBStatus";
            // 
            // receivedDateCalendarCombo
            // 
            this.receivedDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.receivedDateCalendarCombo, "receivedDateCalendarCombo");
            this.receivedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.cBDetailBindingSource, "ReceivedDate", true));
            this.receivedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.receivedDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 12, 1, 0, 0, 0, 0);
            this.receivedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedDateCalendarCombo.MonthIncrement = 0;
            this.receivedDateCalendarCombo.Name = "receivedDateCalendarCombo";
            this.receivedDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.receivedDateCalendarCombo, ((bool)(resources.GetObject("receivedDateCalendarCombo.ShowHelp"))));
            this.receivedDateCalendarCombo.Value = new System.DateTime(2014, 9, 25, 0, 0, 0, 0);
            this.receivedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.receivedDateCalendarCombo.YearIncrement = 0;
            this.receivedDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receivedDateCalendarCombo_KeyDown);
            // 
            // paymentSourceComboBox
            // 
            this.paymentSourceComboBox.BackColor = System.Drawing.Color.Transparent;
            this.paymentSourceComboBox.Column1 = "CBPaymentSourceDescEng";
            resources.ApplyResources(this.paymentSourceComboBox, "paymentSourceComboBox");
            this.paymentSourceComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.paymentSourceComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "PaymentSource", true));
            this.paymentSourceComboBox.DataSource = null;
            this.paymentSourceComboBox.DDColumn1Visible = true;
            this.paymentSourceComboBox.DropDownColumn1Width = 100;
            this.paymentSourceComboBox.DropDownColumn2Width = 300;
            this.paymentSourceComboBox.Name = "paymentSourceComboBox";
            this.paymentSourceComboBox.ReadOnly = true;
            this.paymentSourceComboBox.ReqColor = System.Drawing.SystemColors.Control;
            this.paymentSourceComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.paymentSourceComboBox, ((bool)(resources.GetObject("paymentSourceComboBox.ShowHelp"))));
            this.paymentSourceComboBox.ValueMember = "CBPaymentSource";
            // 
            // natureOfPaymentComboBox
            // 
            this.natureOfPaymentComboBox.BackColor = System.Drawing.Color.Transparent;
            this.natureOfPaymentComboBox.Column1 = "CBNatureOfPaymentDescEng";
            resources.ApplyResources(this.natureOfPaymentComboBox, "natureOfPaymentComboBox");
            this.natureOfPaymentComboBox.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.natureOfPaymentComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cBDetailBindingSource, "NatureOfPayment", true));
            this.natureOfPaymentComboBox.DataSource = null;
            this.natureOfPaymentComboBox.DDColumn1Visible = true;
            this.natureOfPaymentComboBox.DropDownColumn1Width = 100;
            this.natureOfPaymentComboBox.DropDownColumn2Width = 300;
            this.natureOfPaymentComboBox.Name = "natureOfPaymentComboBox";
            this.natureOfPaymentComboBox.ReadOnly = true;
            this.natureOfPaymentComboBox.ReqColor = System.Drawing.SystemColors.Control;
            this.natureOfPaymentComboBox.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.natureOfPaymentComboBox, ((bool)(resources.GetObject("natureOfPaymentComboBox.ShowHelp"))));
            this.natureOfPaymentComboBox.ValueMember = "CBNatureOfPayment";
            // 
            // valuableDateCalendarCombo
            // 
            this.valuableDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.valuableDateCalendarCombo, "valuableDateCalendarCombo");
            this.valuableDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.cBDetailBindingSource, "ValuableDate", true));
            this.valuableDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.valuableDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 12, 1, 0, 0, 0, 0);
            this.valuableDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.valuableDateCalendarCombo.MonthIncrement = 0;
            this.valuableDateCalendarCombo.Name = "valuableDateCalendarCombo";
            this.valuableDateCalendarCombo.Nullable = true;
            this.valuableDateCalendarCombo.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.valuableDateCalendarCombo, ((bool)(resources.GetObject("valuableDateCalendarCombo.ShowHelp"))));
            this.valuableDateCalendarCombo.Value = new System.DateTime(2014, 9, 25, 0, 0, 0, 0);
            this.valuableDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.valuableDateCalendarCombo.YearIncrement = 0;
            this.valuableDateCalendarCombo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.receivedDateCalendarCombo_KeyDown);
            // 
            // lblMoreThan2NSFs
            // 
            this.lblMoreThan2NSFs.BackColor = System.Drawing.Color.LightYellow;
            resources.ApplyResources(this.lblMoreThan2NSFs, "lblMoreThan2NSFs");
            this.lblMoreThan2NSFs.Image = global::LawMate.Properties.Resources.warning_16x16;
            this.lblMoreThan2NSFs.Name = "lblMoreThan2NSFs";
            this.helpProvider1.SetShowHelp(this.lblMoreThan2NSFs, ((bool)(resources.GetObject("lblMoreThan2NSFs.ShowHelp"))));
            // 
            // tbCompletedPayments
            // 
            this.tbCompletedPayments.BackColor = System.Drawing.SystemColors.Control;
            this.tbCompletedPayments.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.tbCompletedPayments, "tbCompletedPayments");
            this.tbCompletedPayments.Name = "tbCompletedPayments";
            this.tbCompletedPayments.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this.tbCompletedPayments.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbCompletedPayments, ((bool)(resources.GetObject("tbCompletedPayments.ShowHelp"))));
            this.tbCompletedPayments.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbCompletedPayments.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // tbAllPayments
            // 
            this.tbAllPayments.BackColor = System.Drawing.SystemColors.Control;
            this.tbAllPayments.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.tbAllPayments, "tbAllPayments");
            this.tbAllPayments.Name = "tbAllPayments";
            this.tbAllPayments.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowNull;
            this.tbAllPayments.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.tbAllPayments, ((bool)(resources.GetObject("tbAllPayments.ShowHelp"))));
            this.tbAllPayments.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbAllPayments.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // cBDetailGridEX
            // 
            this.cBDetailGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.cBDetailGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.cBDetailGridEX, "cBDetailGridEX");
            this.cBDetailGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.cBDetailGridEX.DataSource = this.cBDetailBindingSource;
            resources.ApplyResources(cBDetailGridEX_DesignTimeLayout, "cBDetailGridEX_DesignTimeLayout");
            this.cBDetailGridEX.DesignTimeLayout = cBDetailGridEX_DesignTimeLayout;
            this.cBDetailGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.cBDetailGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.cBDetailGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.cBDetailGridEX.GroupByBoxVisible = false;
            this.cBDetailGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.cBDetailGridEX.Name = "cBDetailGridEX";
            this.helpProvider1.SetShowHelp(this.cBDetailGridEX, ((bool)(resources.GetObject("cBDetailGridEX.ShowHelp"))));
            this.cBDetailGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.cBDetailGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.cBDetailGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1,
            this.uiCommandBar2});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete,
            this.tsSave,
            this.tsScreenTitle,
            this.tsEditMode,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("e84fd5d2-99ef-4b3d-be32-c13755915580");
            this.uiCommandManager1.ImageList = this.imageListBase;
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
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
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditMode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave1,
            this.Separator3,
            this.tsAudit1});
            this.uiCommandBar1.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
            // 
            // tsEditMode1
            // 
            resources.ApplyResources(this.tsEditMode1, "tsEditMode1");
            this.tsEditMode1.Name = "tsEditMode1";
            // 
            // tsScreenTitle1
            // 
            this.tsScreenTitle1.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsScreenTitle1.ControlWidth = 100;
            resources.ApplyResources(this.tsScreenTitle1, "tsScreenTitle1");
            this.tsScreenTitle1.Name = "tsScreenTitle1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator3, "Separator3");
            this.Separator3.Name = "Separator3";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
            // 
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // cmdFile1
            // 
            resources.ApplyResources(this.cmdFile1, "cmdFile1");
            this.cmdFile1.Name = "cmdFile1";
            // 
            // cmdEdit1
            // 
            resources.ApplyResources(this.cmdEdit1, "cmdEdit1");
            this.cmdEdit1.Name = "cmdEdit1";
            // 
            // tsDelete
            // 
            resources.ApplyResources(this.tsDelete, "tsDelete");
            this.tsDelete.Name = "tsDelete";
            // 
            // tsSave
            // 
            resources.ApplyResources(this.tsSave, "tsSave");
            this.tsSave.Name = "tsSave";
            // 
            // tsScreenTitle
            // 
            this.tsScreenTitle.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitle, "tsScreenTitle");
            this.tsScreenTitle.Name = "tsScreenTitle";
            this.tsScreenTitle.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsEditMode
            // 
            this.tsEditMode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditMode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditMode, "tsEditMode");
            this.tsEditMode.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsEditMode.Name = "tsEditMode";
            this.tsEditMode.StateStyles.FormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tsEditMode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditMode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditMode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // tsAudit
            // 
            this.tsAudit.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // cmdEdit
            // 
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
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
            this.uiCommandBar2});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // ucCashBlotter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucCashBlotter";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.ucCashBlotter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            this.pnlGridContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBDetailGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.GridEX.GridEX cBDetailGridEX;
        private System.Windows.Forms.BindingSource cBDetailBindingSource;
        private lmDatasets.CLAS CLAS;
        private Janus.Windows.CalendarCombo.CalendarCombo receivedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo valuableDateCalendarCombo;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditMode1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox tbCompletedPayments;
        private Janus.Windows.GridEX.EditControls.NumericEditBox tbAllPayments;
        private System.Windows.Forms.Label lblMoreThan2NSFs;
        private UserControls.ucMultiDropDown currencyCodeComboBox;
        private UserControls.ucMultiDropDown paymentSourceComboBox;
        private UserControls.ucMultiDropDown natureOfPaymentComboBox;
        private UserControls.ucMultiDropDown statusCodeComboBox;
        private UserControls.ucMultiDropDown valuableTypeComboBox;
        private Janus.Windows.GridEX.EditControls.EditBox commentsEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox valuableAmountNumericEditBox;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.GridEX.EditControls.EditBox editBox1;
        private ucOfficeSelectBox ucOfficeSelectBox1;
        private Janus.Windows.EditControls.UIButton btnGoToOfficeCB;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
    }
}
