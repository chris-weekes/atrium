using System.Data;
namespace LawMate
{
    partial class ucCompOffer
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
                FM.GetCLASMng().DB.CompOffer.ColumnChanged -= new DataColumnChangeEventHandler(compOfferTable_ColumnChanged);
                FM.GetCLASMng().DB.CompOfferDetail.ColumnChanged -= new DataColumnChangeEventHandler(compOfferTable_ColumnChanged);

                FM.GetCLASMng().GetCompOffer().OnUpdate -= new atLogic.UpdateEventHandler(ucCompOffer_OnUpdate);
                FM.GetCLASMng().GetCompOfferDetail().OnUpdate -= new atLogic.UpdateEventHandler(ucCompOffer_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCompOffer));
            System.Windows.Forms.Label termsFulfilledDateLabel;
            System.Windows.Forms.Label termsDefaultedDateLabel;
            System.Windows.Forms.Label officeIdLabel;
            System.Windows.Forms.Label compOfferDateLabel;
            System.Windows.Forms.Label compOfferAmountLabel;
            System.Windows.Forms.Label acceptedDateLabel;
            System.Windows.Forms.Label refusedDateLabel;
            System.Windows.Forms.Label termsLabel;
            System.Windows.Forms.Label compOfferExpiryDateLabel;
            System.Windows.Forms.Label withdrawalDateLabel;
            Janus.Windows.GridEX.GridEXLayout atriumDB_CompOfferDetailDataTableGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.atriumDB_CompOfferDetailDataTableGridEX = new Janus.Windows.GridEX.GridEX();
            this.atriumDB_CompOfferDetailDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiGroupBox1 = new Janus.Windows.EditControls.UIGroupBox();
            this.withdrawalDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.compOfferDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.initiatedByDebtorUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.compOfferExpiryDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.compOfferAmountNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.lumpSumUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.termsEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.acceptedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.refusedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.termsFulfilledDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.atriumDB_CompOfferDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.termsDefaultedDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.officeIducOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode1 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsDelete2 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsDelete = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave1 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDelete1 = new Janus.Windows.UI.CommandBars.UICommand("tsDelete");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            termsFulfilledDateLabel = new System.Windows.Forms.Label();
            termsDefaultedDateLabel = new System.Windows.Forms.Label();
            officeIdLabel = new System.Windows.Forms.Label();
            compOfferDateLabel = new System.Windows.Forms.Label();
            compOfferAmountLabel = new System.Windows.Forms.Label();
            acceptedDateLabel = new System.Windows.Forms.Label();
            refusedDateLabel = new System.Windows.Forms.Label();
            termsLabel = new System.Windows.Forms.Label();
            compOfferExpiryDateLabel = new System.Windows.Forms.Label();
            withdrawalDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CompOfferDetailDataTableGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CompOfferDetailDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).BeginInit();
            this.uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CompOfferDataTableBindingSource)).BeginInit();
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
            // termsFulfilledDateLabel
            // 
            resources.ApplyResources(termsFulfilledDateLabel, "termsFulfilledDateLabel");
            termsFulfilledDateLabel.BackColor = System.Drawing.Color.Transparent;
            termsFulfilledDateLabel.Name = "termsFulfilledDateLabel";
            this.helpProvider1.SetShowHelp(termsFulfilledDateLabel, ((bool)(resources.GetObject("termsFulfilledDateLabel.ShowHelp"))));
            // 
            // termsDefaultedDateLabel
            // 
            resources.ApplyResources(termsDefaultedDateLabel, "termsDefaultedDateLabel");
            termsDefaultedDateLabel.BackColor = System.Drawing.Color.Transparent;
            termsDefaultedDateLabel.Name = "termsDefaultedDateLabel";
            this.helpProvider1.SetShowHelp(termsDefaultedDateLabel, ((bool)(resources.GetObject("termsDefaultedDateLabel.ShowHelp"))));
            // 
            // officeIdLabel
            // 
            resources.ApplyResources(officeIdLabel, "officeIdLabel");
            officeIdLabel.BackColor = System.Drawing.Color.Transparent;
            officeIdLabel.Name = "officeIdLabel";
            this.helpProvider1.SetShowHelp(officeIdLabel, ((bool)(resources.GetObject("officeIdLabel.ShowHelp"))));
            // 
            // compOfferDateLabel
            // 
            resources.ApplyResources(compOfferDateLabel, "compOfferDateLabel");
            compOfferDateLabel.BackColor = System.Drawing.Color.Transparent;
            compOfferDateLabel.Name = "compOfferDateLabel";
            this.helpProvider1.SetShowHelp(compOfferDateLabel, ((bool)(resources.GetObject("compOfferDateLabel.ShowHelp"))));
            // 
            // compOfferAmountLabel
            // 
            resources.ApplyResources(compOfferAmountLabel, "compOfferAmountLabel");
            compOfferAmountLabel.BackColor = System.Drawing.Color.Transparent;
            compOfferAmountLabel.Name = "compOfferAmountLabel";
            this.helpProvider1.SetShowHelp(compOfferAmountLabel, ((bool)(resources.GetObject("compOfferAmountLabel.ShowHelp"))));
            // 
            // acceptedDateLabel
            // 
            resources.ApplyResources(acceptedDateLabel, "acceptedDateLabel");
            acceptedDateLabel.BackColor = System.Drawing.Color.Transparent;
            acceptedDateLabel.Name = "acceptedDateLabel";
            this.helpProvider1.SetShowHelp(acceptedDateLabel, ((bool)(resources.GetObject("acceptedDateLabel.ShowHelp"))));
            // 
            // refusedDateLabel
            // 
            resources.ApplyResources(refusedDateLabel, "refusedDateLabel");
            refusedDateLabel.BackColor = System.Drawing.Color.Transparent;
            refusedDateLabel.Name = "refusedDateLabel";
            this.helpProvider1.SetShowHelp(refusedDateLabel, ((bool)(resources.GetObject("refusedDateLabel.ShowHelp"))));
            // 
            // termsLabel
            // 
            termsLabel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(termsLabel, "termsLabel");
            termsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            termsLabel.Name = "termsLabel";
            this.helpProvider1.SetShowHelp(termsLabel, ((bool)(resources.GetObject("termsLabel.ShowHelp"))));
            // 
            // compOfferExpiryDateLabel
            // 
            resources.ApplyResources(compOfferExpiryDateLabel, "compOfferExpiryDateLabel");
            compOfferExpiryDateLabel.BackColor = System.Drawing.Color.Transparent;
            compOfferExpiryDateLabel.Name = "compOfferExpiryDateLabel";
            this.helpProvider1.SetShowHelp(compOfferExpiryDateLabel, ((bool)(resources.GetObject("compOfferExpiryDateLabel.ShowHelp"))));
            // 
            // withdrawalDateLabel
            // 
            resources.ApplyResources(withdrawalDateLabel, "withdrawalDateLabel");
            withdrawalDateLabel.BackColor = System.Drawing.Color.Transparent;
            withdrawalDateLabel.Name = "withdrawalDateLabel";
            this.helpProvider1.SetShowHelp(withdrawalDateLabel, ((bool)(resources.GetObject("withdrawalDateLabel.ShowHelp"))));
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.AllowPanelDrag = false;
            this.uiPanelManager1.AllowPanelDrop = false;
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.ContainerCaptionFocus;
            this.uiPanelManager1.DefaultPanelSettings.BorderCaption = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.BorderCaption")));
            this.uiPanelManager1.DefaultPanelSettings.BorderPanel = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(885, 523), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.atriumDB_CompOfferDetailDataTableGridEX);
            this.pnlAllContainer.Controls.Add(this.uiGroupBox1);
            this.pnlAllContainer.Controls.Add(termsFulfilledDateLabel);
            this.pnlAllContainer.Controls.Add(this.termsFulfilledDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(termsDefaultedDateLabel);
            this.pnlAllContainer.Controls.Add(this.termsDefaultedDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(officeIdLabel);
            this.pnlAllContainer.Controls.Add(this.officeIducOfficeSelectBox);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // atriumDB_CompOfferDetailDataTableGridEX
            // 
            this.atriumDB_CompOfferDetailDataTableGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.atriumDB_CompOfferDetailDataTableGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.atriumDB_CompOfferDetailDataTableGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.atriumDB_CompOfferDetailDataTableGridEX.DataSource = this.atriumDB_CompOfferDetailDataTableBindingSource;
            resources.ApplyResources(atriumDB_CompOfferDetailDataTableGridEX_DesignTimeLayout, "atriumDB_CompOfferDetailDataTableGridEX_DesignTimeLayout");
            this.atriumDB_CompOfferDetailDataTableGridEX.DesignTimeLayout = atriumDB_CompOfferDetailDataTableGridEX_DesignTimeLayout;
            this.atriumDB_CompOfferDetailDataTableGridEX.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown;
            this.atriumDB_CompOfferDetailDataTableGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            resources.ApplyResources(this.atriumDB_CompOfferDetailDataTableGridEX, "atriumDB_CompOfferDetailDataTableGridEX");
            this.atriumDB_CompOfferDetailDataTableGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.atriumDB_CompOfferDetailDataTableGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.atriumDB_CompOfferDetailDataTableGridEX.GroupByBoxVisible = false;
            this.atriumDB_CompOfferDetailDataTableGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.atriumDB_CompOfferDetailDataTableGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.atriumDB_CompOfferDetailDataTableGridEX.Name = "atriumDB_CompOfferDetailDataTableGridEX";
            this.helpProvider1.SetShowHelp(this.atriumDB_CompOfferDetailDataTableGridEX, ((bool)(resources.GetObject("atriumDB_CompOfferDetailDataTableGridEX.ShowHelp"))));
            this.atriumDB_CompOfferDetailDataTableGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.atriumDB_CompOfferDetailDataTableGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.atriumDB_CompOfferDetailDataTableGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // atriumDB_CompOfferDetailDataTableBindingSource
            // 
            this.atriumDB_CompOfferDetailDataTableBindingSource.CurrentChanged += new System.EventHandler(this.atriumDB_CompOfferDetailDataTableBindingSource_CurrentChanged);
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiGroupBox1.Controls.Add(compOfferDateLabel);
            this.uiGroupBox1.Controls.Add(this.withdrawalDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(this.compOfferDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(withdrawalDateLabel);
            this.uiGroupBox1.Controls.Add(this.initiatedByDebtorUICheckBox);
            this.uiGroupBox1.Controls.Add(this.compOfferExpiryDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(compOfferAmountLabel);
            this.uiGroupBox1.Controls.Add(compOfferExpiryDateLabel);
            this.uiGroupBox1.Controls.Add(this.compOfferAmountNumericEditBox);
            this.uiGroupBox1.Controls.Add(this.lumpSumUICheckBox);
            this.uiGroupBox1.Controls.Add(acceptedDateLabel);
            this.uiGroupBox1.Controls.Add(this.termsEditBox);
            this.uiGroupBox1.Controls.Add(this.acceptedDateCalendarCombo);
            this.uiGroupBox1.Controls.Add(termsLabel);
            this.uiGroupBox1.Controls.Add(refusedDateLabel);
            this.uiGroupBox1.Controls.Add(this.refusedDateCalendarCombo);
            this.uiGroupBox1.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            resources.ApplyResources(this.uiGroupBox1, "uiGroupBox1");
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.helpProvider1.SetShowHelp(this.uiGroupBox1, ((bool)(resources.GetObject("uiGroupBox1.ShowHelp"))));
            this.uiGroupBox1.UseThemes = false;
            // 
            // withdrawalDateCalendarCombo
            // 
            resources.ApplyResources(this.withdrawalDateCalendarCombo, "withdrawalDateCalendarCombo");
            this.withdrawalDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "WithdrawalDate", true));
            this.withdrawalDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.withdrawalDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.withdrawalDateCalendarCombo.MonthIncrement = 0;
            this.withdrawalDateCalendarCombo.Name = "withdrawalDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.withdrawalDateCalendarCombo, ((bool)(resources.GetObject("withdrawalDateCalendarCombo.ShowHelp"))));
            this.withdrawalDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.withdrawalDateCalendarCombo.YearIncrement = 0;
            // 
            // compOfferDateCalendarCombo
            // 
            resources.ApplyResources(this.compOfferDateCalendarCombo, "compOfferDateCalendarCombo");
            this.compOfferDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "CompOfferDate", true));
            this.compOfferDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.compOfferDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.compOfferDateCalendarCombo.MonthIncrement = 0;
            this.compOfferDateCalendarCombo.Name = "compOfferDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.compOfferDateCalendarCombo, ((bool)(resources.GetObject("compOfferDateCalendarCombo.ShowHelp"))));
            this.compOfferDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.compOfferDateCalendarCombo.YearIncrement = 0;
            // 
            // initiatedByDebtorUICheckBox
            // 
            this.initiatedByDebtorUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.initiatedByDebtorUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.initiatedByDebtorUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "InitiatedByDebtor", true));
            resources.ApplyResources(this.initiatedByDebtorUICheckBox, "initiatedByDebtorUICheckBox");
            this.initiatedByDebtorUICheckBox.Name = "initiatedByDebtorUICheckBox";
            this.helpProvider1.SetShowHelp(this.initiatedByDebtorUICheckBox, ((bool)(resources.GetObject("initiatedByDebtorUICheckBox.ShowHelp"))));
            this.initiatedByDebtorUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // compOfferExpiryDateCalendarCombo
            // 
            resources.ApplyResources(this.compOfferExpiryDateCalendarCombo, "compOfferExpiryDateCalendarCombo");
            this.compOfferExpiryDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "CompOfferExpiryDate", true));
            this.compOfferExpiryDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.compOfferExpiryDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.compOfferExpiryDateCalendarCombo.MonthIncrement = 0;
            this.compOfferExpiryDateCalendarCombo.Name = "compOfferExpiryDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.compOfferExpiryDateCalendarCombo, ((bool)(resources.GetObject("compOfferExpiryDateCalendarCombo.ShowHelp"))));
            this.compOfferExpiryDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.compOfferExpiryDateCalendarCombo.YearIncrement = 0;
            // 
            // compOfferAmountNumericEditBox
            // 
            this.compOfferAmountNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.atriumDB_CompOfferDetailDataTableBindingSource, "CompOfferAmount", true));
            this.compOfferAmountNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.compOfferAmountNumericEditBox, "compOfferAmountNumericEditBox");
            this.compOfferAmountNumericEditBox.Name = "compOfferAmountNumericEditBox";
            this.helpProvider1.SetShowHelp(this.compOfferAmountNumericEditBox, ((bool)(resources.GetObject("compOfferAmountNumericEditBox.ShowHelp"))));
            this.compOfferAmountNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.compOfferAmountNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lumpSumUICheckBox
            // 
            this.lumpSumUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.lumpSumUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lumpSumUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "LumpSum", true));
            resources.ApplyResources(this.lumpSumUICheckBox, "lumpSumUICheckBox");
            this.lumpSumUICheckBox.Name = "lumpSumUICheckBox";
            this.helpProvider1.SetShowHelp(this.lumpSumUICheckBox, ((bool)(resources.GetObject("lumpSumUICheckBox.ShowHelp"))));
            this.lumpSumUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // termsEditBox
            // 
            this.termsEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.atriumDB_CompOfferDetailDataTableBindingSource, "Terms", true));
            resources.ApplyResources(this.termsEditBox, "termsEditBox");
            this.termsEditBox.Multiline = true;
            this.termsEditBox.Name = "termsEditBox";
            this.termsEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.termsEditBox, ((bool)(resources.GetObject("termsEditBox.ShowHelp"))));
            this.termsEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // acceptedDateCalendarCombo
            // 
            resources.ApplyResources(this.acceptedDateCalendarCombo, "acceptedDateCalendarCombo");
            this.acceptedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "AcceptedDate", true));
            this.acceptedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.acceptedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.acceptedDateCalendarCombo.MonthIncrement = 0;
            this.acceptedDateCalendarCombo.Name = "acceptedDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.acceptedDateCalendarCombo, ((bool)(resources.GetObject("acceptedDateCalendarCombo.ShowHelp"))));
            this.acceptedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.acceptedDateCalendarCombo.YearIncrement = 0;
            // 
            // refusedDateCalendarCombo
            // 
            resources.ApplyResources(this.refusedDateCalendarCombo, "refusedDateCalendarCombo");
            this.refusedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDetailDataTableBindingSource, "RefusedDate", true));
            this.refusedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.refusedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.refusedDateCalendarCombo.MonthIncrement = 0;
            this.refusedDateCalendarCombo.Name = "refusedDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.refusedDateCalendarCombo, ((bool)(resources.GetObject("refusedDateCalendarCombo.ShowHelp"))));
            this.refusedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.refusedDateCalendarCombo.YearIncrement = 0;
            // 
            // termsFulfilledDateCalendarCombo
            // 
            resources.ApplyResources(this.termsFulfilledDateCalendarCombo, "termsFulfilledDateCalendarCombo");
            this.termsFulfilledDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDataTableBindingSource, "TermsFulfilledDate", true));
            this.termsFulfilledDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.termsFulfilledDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.termsFulfilledDateCalendarCombo.MonthIncrement = 0;
            this.termsFulfilledDateCalendarCombo.Name = "termsFulfilledDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.termsFulfilledDateCalendarCombo, ((bool)(resources.GetObject("termsFulfilledDateCalendarCombo.ShowHelp"))));
            this.termsFulfilledDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.termsFulfilledDateCalendarCombo.YearIncrement = 0;
            // 
            // atriumDB_CompOfferDataTableBindingSource
            // 
            this.atriumDB_CompOfferDataTableBindingSource.CurrentChanged += new System.EventHandler(this.atriumDB_CompOfferDataTableBindingSource_CurrentChanged);
            // 
            // termsDefaultedDateCalendarCombo
            // 
            resources.ApplyResources(this.termsDefaultedDateCalendarCombo, "termsDefaultedDateCalendarCombo");
            this.termsDefaultedDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.atriumDB_CompOfferDataTableBindingSource, "TermsDefaultedDate", true));
            this.termsDefaultedDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.termsDefaultedDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.termsDefaultedDateCalendarCombo.MonthIncrement = 0;
            this.termsDefaultedDateCalendarCombo.Name = "termsDefaultedDateCalendarCombo";
            this.helpProvider1.SetShowHelp(this.termsDefaultedDateCalendarCombo, ((bool)(resources.GetObject("termsDefaultedDateCalendarCombo.ShowHelp"))));
            this.termsDefaultedDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.termsDefaultedDateCalendarCombo.YearIncrement = 0;
            // 
            // officeIducOfficeSelectBox
            // 
            this.officeIducOfficeSelectBox.AtMng = null;
            this.officeIducOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIducOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.atriumDB_CompOfferDataTableBindingSource, "OfficeId", true));
            resources.ApplyResources(this.officeIducOfficeSelectBox, "officeIducOfficeSelectBox");
            this.officeIducOfficeSelectBox.Name = "officeIducOfficeSelectBox";
            this.officeIducOfficeSelectBox.OfficeId = null;
            this.officeIducOfficeSelectBox.ReadOnly = true;
            this.officeIducOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIducOfficeSelectBox, ((bool)(resources.GetObject("officeIducOfficeSelectBox.ShowHelp"))));
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
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit,
            this.tsEditmode});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = resources.GetString("uiCommandManager1.EditContextMenu.Key");
            this.uiCommandManager1.Id = new System.Guid("ff3236e4-6c52-4a26-a5c8-6bbb944ba029");
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
            this.uiCommandBar1.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            resources.ApplyResources(this.uiCommandBar1, "uiCommandBar1");
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.helpProvider1.SetShowHelp(this.uiCommandBar1, ((bool)(resources.GetObject("uiCommandBar1.ShowHelp"))));
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
            // uiCommandBar2
            // 
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode1,
            this.tsScreenTitle1,
            this.Separator1,
            this.tsSave2,
            this.tsDelete2,
            this.Separator2,
            this.tsAudit1});
            this.uiCommandBar2.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.FullRow = true;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // tsEditmode1
            // 
            resources.ApplyResources(this.tsEditmode1, "tsEditmode1");
            this.tsEditmode1.Name = "tsEditmode1";
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
            // tsSave2
            // 
            resources.ApplyResources(this.tsSave2, "tsSave2");
            this.tsSave2.Name = "tsSave2";
            // 
            // tsDelete2
            // 
            resources.ApplyResources(this.tsDelete2, "tsDelete2");
            this.tsDelete2.Name = "tsDelete2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
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
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave1});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSave1
            // 
            resources.ApplyResources(this.tsSave1, "tsSave1");
            this.tsSave1.Name = "tsSave1";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDelete1});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDelete1
            // 
            resources.ApplyResources(this.tsDelete1, "tsDelete1");
            this.tsDelete1.Name = "tsDelete1";
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
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
            // ucCompOffer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucCompOffer";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucCompOffer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CompOfferDetailDataTableGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CompOfferDetailDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGroupBox1)).EndInit();
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB_CompOfferDataTableBindingSource)).EndInit();
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
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode1;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDelete1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private System.Windows.Forms.BindingSource atriumDB_CompOfferDataTableBindingSource;
        private Janus.Windows.EditControls.UIGroupBox uiGroupBox1;
        private Janus.Windows.CalendarCombo.CalendarCombo withdrawalDateCalendarCombo;
        private System.Windows.Forms.BindingSource atriumDB_CompOfferDetailDataTableBindingSource;
        private Janus.Windows.CalendarCombo.CalendarCombo compOfferDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox initiatedByDebtorUICheckBox;
        private Janus.Windows.CalendarCombo.CalendarCombo compOfferExpiryDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.NumericEditBox compOfferAmountNumericEditBox;
        private Janus.Windows.EditControls.UICheckBox lumpSumUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox termsEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo acceptedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo refusedDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo termsFulfilledDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo termsDefaultedDateCalendarCombo;
        private ucOfficeSelectBox officeIducOfficeSelectBox;
        private Janus.Windows.GridEX.GridEX atriumDB_CompOfferDetailDataTableGridEX;
    }
}
