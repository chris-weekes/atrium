using System.Data;
namespace LawMate
{
    partial class ucSRPDetail
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
                FM.DB.IRP.ColumnChanged -= new DataColumnChangeEventHandler(a_ColumnChanged);
                FM.GetIRP().OnUpdate -= new atLogic.UpdateEventHandler(ucIRP_OnUpdate);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucSRPDetail));
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label18;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label20;
            System.Windows.Forms.Label label21;
            System.Windows.Forms.Label label22;
            System.Windows.Forms.Label label23;
            System.Windows.Forms.Label label24;
            System.Windows.Forms.Label label25;
            System.Windows.Forms.Label dateTaxedLabel;
            System.Windows.Forms.Label officerCodeLabel;
            System.Windows.Forms.Label fileTotalTaxedLabel;
            System.Windows.Forms.Label sINLabel;
            System.Windows.Forms.Label percentOfPrincipalLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label fileIDLabel;
            Janus.Windows.GridEX.GridEXLayout iRPGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.GridEX.GridEXLayout taxingGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.label26 = new System.Windows.Forms.Label();
            this.officeIDLabel = new System.Windows.Forms.Label();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlTab = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.pnlIRPs = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlIRPsContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.totalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.iRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.atriumDB();
            this.totalTaxTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesTaxedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.totalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.totalTaxClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.netTotalClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.disbursementTaxExemptClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedTaxNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.feesClaimedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.mccTaxingOfficer = new LawMate.UserControls.ucMultiDropDown();
            this.fileIDucFileSelectBox = new LawMate.ucFileSelectBox();
            this.btnValidateSIN = new Janus.Windows.EditControls.UIButton();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            this.uiContextMenu2 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode2 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitleIRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitleIRP");
            this.Separator7 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsNewIRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsNewIRP");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSaveIRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsSaveIRP");
            this.tsDeleteIRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsDeleteIRP");
            this.tsSaveIRP = new Janus.Windows.UI.CommandBars.UICommand("tsSaveIRP");
            this.tsDeleteIRP = new Janus.Windows.UI.CommandBars.UICommand("tsDeleteIRP");
            this.tsNewIRP = new Janus.Windows.UI.CommandBars.UICommand("tsNewIRP");
            this.tsGoToSRP = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRP");
            this.tsGoToBillingReview = new Janus.Windows.UI.CommandBars.UICommand("tsGoToBillingReview");
            this.tsScreenTitleIRP = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitleIRP");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsMessage = new Janus.Windows.UI.CommandBars.UICommand("tsMessage");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSaveIRP2 = new Janus.Windows.UI.CommandBars.UICommand("tsSaveIRP");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsNewIRP2 = new Janus.Windows.UI.CommandBars.UICommand("tsNewIRP");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.tsDeleteIRP2 = new Janus.Windows.UI.CommandBars.UICommand("tsDeleteIRP");
            this.tsActions = new Janus.Windows.UI.CommandBars.UICommand("tsActions");
            this.cmdJumpToActivity = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToActivity");
            this.cmdJumpToTaxation = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToTaxation");
            this.uiContextMenu1 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.cmdJumpToActivity1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToActivity");
            this.cmdJumpToTaxation1 = new Janus.Windows.UI.CommandBars.UICommand("cmdJumpToTaxation");
            this.uiContextMenu3 = new Janus.Windows.UI.CommandBars.UIContextMenu();
            this.tsGoToSRP1 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToSRP");
            this.tsGoToBillingReview1 = new Janus.Windows.UI.CommandBars.UICommand("tsGoToBillingReview");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.iRPGridEX = new Janus.Windows.GridEX.GridEX();
            this.percentOfPrincipalNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.fileTotalTaxedNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.dateTaxedCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.taxingDifferenceNumericEditBox = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.sINMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.officeIDucOfficeSelectBox = new LawMate.ucOfficeSelectBox();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label9 = new System.Windows.Forms.Label();
            this.gbMessage = new Janus.Windows.EditControls.UIGroupBox();
            this.btnBeginTaxation = new Janus.Windows.EditControls.UIButton();
            this.label10 = new System.Windows.Forms.Label();
            this.taxingGridEX = new Janus.Windows.GridEX.GridEX();
            this.pnlGrid = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlGridContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlSRP = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlSRPContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            dateTaxedLabel = new System.Windows.Forms.Label();
            officerCodeLabel = new System.Windows.Forms.Label();
            fileTotalTaxedLabel = new System.Windows.Forms.Label();
            sINLabel = new System.Windows.Forms.Label();
            percentOfPrincipalLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            fileIDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).BeginInit();
            this.pnlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIRPs)).BeginInit();
            this.pnlIRPs.SuspendLayout();
            this.pnlIRPsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMessage)).BeginInit();
            this.gbMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRP)).BeginInit();
            this.pnlSRP.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.iRPBindingSource;
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
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            this.helpProvider1.SetShowHelp(label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            this.helpProvider1.SetShowHelp(label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            this.helpProvider1.SetShowHelp(label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            this.helpProvider1.SetShowHelp(label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            this.helpProvider1.SetShowHelp(label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            this.helpProvider1.SetShowHelp(label1, ((bool)(resources.GetObject("label1.ShowHelp"))));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Name = "label2";
            this.helpProvider1.SetShowHelp(label2, ((bool)(resources.GetObject("label2.ShowHelp"))));
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.BackColor = System.Drawing.Color.Transparent;
            label17.Name = "label17";
            this.helpProvider1.SetShowHelp(label17, ((bool)(resources.GetObject("label17.ShowHelp"))));
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.BackColor = System.Drawing.Color.Transparent;
            label18.Name = "label18";
            this.helpProvider1.SetShowHelp(label18, ((bool)(resources.GetObject("label18.ShowHelp"))));
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.Name = "label19";
            this.helpProvider1.SetShowHelp(label19, ((bool)(resources.GetObject("label19.ShowHelp"))));
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.BackColor = System.Drawing.Color.Transparent;
            label20.Name = "label20";
            this.helpProvider1.SetShowHelp(label20, ((bool)(resources.GetObject("label20.ShowHelp"))));
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.BackColor = System.Drawing.Color.Transparent;
            label21.Name = "label21";
            this.helpProvider1.SetShowHelp(label21, ((bool)(resources.GetObject("label21.ShowHelp"))));
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.Name = "label22";
            this.helpProvider1.SetShowHelp(label22, ((bool)(resources.GetObject("label22.ShowHelp"))));
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.BackColor = System.Drawing.Color.Transparent;
            label23.Name = "label23";
            this.helpProvider1.SetShowHelp(label23, ((bool)(resources.GetObject("label23.ShowHelp"))));
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.BackColor = System.Drawing.Color.Transparent;
            label24.Name = "label24";
            this.helpProvider1.SetShowHelp(label24, ((bool)(resources.GetObject("label24.ShowHelp"))));
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.BackColor = System.Drawing.Color.Transparent;
            label25.Name = "label25";
            this.helpProvider1.SetShowHelp(label25, ((bool)(resources.GetObject("label25.ShowHelp"))));
            // 
            // dateTaxedLabel
            // 
            resources.ApplyResources(dateTaxedLabel, "dateTaxedLabel");
            dateTaxedLabel.BackColor = System.Drawing.Color.Transparent;
            dateTaxedLabel.Name = "dateTaxedLabel";
            this.helpProvider1.SetShowHelp(dateTaxedLabel, ((bool)(resources.GetObject("dateTaxedLabel.ShowHelp"))));
            // 
            // officerCodeLabel
            // 
            resources.ApplyResources(officerCodeLabel, "officerCodeLabel");
            officerCodeLabel.BackColor = System.Drawing.Color.Transparent;
            officerCodeLabel.Name = "officerCodeLabel";
            this.helpProvider1.SetShowHelp(officerCodeLabel, ((bool)(resources.GetObject("officerCodeLabel.ShowHelp"))));
            // 
            // fileTotalTaxedLabel
            // 
            resources.ApplyResources(fileTotalTaxedLabel, "fileTotalTaxedLabel");
            fileTotalTaxedLabel.BackColor = System.Drawing.Color.Transparent;
            fileTotalTaxedLabel.Name = "fileTotalTaxedLabel";
            this.helpProvider1.SetShowHelp(fileTotalTaxedLabel, ((bool)(resources.GetObject("fileTotalTaxedLabel.ShowHelp"))));
            // 
            // sINLabel
            // 
            resources.ApplyResources(sINLabel, "sINLabel");
            sINLabel.BackColor = System.Drawing.Color.Transparent;
            sINLabel.Name = "sINLabel";
            this.helpProvider1.SetShowHelp(sINLabel, ((bool)(resources.GetObject("sINLabel.ShowHelp"))));
            // 
            // percentOfPrincipalLabel
            // 
            resources.ApplyResources(percentOfPrincipalLabel, "percentOfPrincipalLabel");
            percentOfPrincipalLabel.BackColor = System.Drawing.Color.Transparent;
            percentOfPrincipalLabel.Name = "percentOfPrincipalLabel";
            this.helpProvider1.SetShowHelp(percentOfPrincipalLabel, ((bool)(resources.GetObject("percentOfPrincipalLabel.ShowHelp"))));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            this.helpProvider1.SetShowHelp(label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            // 
            // fileIDLabel
            // 
            resources.ApplyResources(fileIDLabel, "fileIDLabel");
            fileIDLabel.BackColor = System.Drawing.Color.Transparent;
            fileIDLabel.Name = "fileIDLabel";
            this.helpProvider1.SetShowHelp(fileIDLabel, ((bool)(resources.GetObject("fileIDLabel.ShowHelp"))));
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Name = "label26";
            this.helpProvider1.SetShowHelp(this.label26, ((bool)(resources.GetObject("label26.ShowHelp"))));
            // 
            // officeIDLabel
            // 
            resources.ApplyResources(this.officeIDLabel, "officeIDLabel");
            this.officeIDLabel.BackColor = System.Drawing.Color.Transparent;
            this.officeIDLabel.Name = "officeIDLabel";
            this.helpProvider1.SetShowHelp(this.officeIDLabel, ((bool)(resources.GetObject("officeIDLabel.ShowHelp"))));
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
            this.uiPanelManager1.DefaultPanelSettings.CaptionVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CaptionVisible")));
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = ((bool)(resources.GetObject("uiPanelManager1.DefaultPanelSettings.CloseButtonVisible")));
            this.uiPanelManager1.DefaultPanelSettings.DarkCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uiPanelManager1.PanelPadding.Bottom = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Bottom")));
            this.uiPanelManager1.PanelPadding.Left = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Left")));
            this.uiPanelManager1.PanelPadding.Right = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Right")));
            this.uiPanelManager1.PanelPadding.Top = ((int)(resources.GetObject("uiPanelManager1.PanelPadding.Top")));
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlTab.Id = new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e");
            this.pnlTab.StaticGroup = true;
            this.pnlIRPs.Id = new System.Guid("5c30eda2-4594-41e2-9985-376c5fce72e9");
            this.pnlTab.Panels.Add(this.pnlIRPs);
            this.uiPanelManager1.Panels.Add(this.pnlTab);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, Janus.Windows.UI.Dock.PanelDockStyle.Fill, true, new System.Drawing.Size(771, 657), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("5c30eda2-4594-41e2-9985-376c5fce72e9"), new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), -1, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c09a97c6-ff02-4dcf-87ac-c7526d2d809e"), Janus.Windows.UI.Dock.PanelGroupStyle.Tab, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("c45f40d3-3a69-4b5f-9bb4-bcc4041b2c39"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("5c30eda2-4594-41e2-9985-376c5fce72e9"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e11a25cc-9449-486a-b562-5ebf98e4b383"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("ea2edd7d-ea58-44fc-8638-9bbef782288a"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7a215468-170d-44d8-8b5f-64d5240cf142"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlTab
            // 
            this.pnlTab.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.Tab;
            resources.ApplyResources(this.pnlTab, "pnlTab");
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.SelectedPanel = this.pnlIRPs;
            this.helpProvider1.SetShowHelp(this.pnlTab, ((bool)(resources.GetObject("pnlTab.ShowHelp"))));
            this.pnlTab.TabAlignment = Janus.Windows.UI.Dock.TabAlignment.Top;
            // 
            // pnlIRPs
            // 
            this.pnlIRPs.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlIRPs.InnerContainer = this.pnlIRPsContainer;
            resources.ApplyResources(this.pnlIRPs, "pnlIRPs");
            this.pnlIRPs.Name = "pnlIRPs";
            this.helpProvider1.SetShowHelp(this.pnlIRPs, ((bool)(resources.GetObject("pnlIRPs.ShowHelp"))));
            // 
            // pnlIRPsContainer
            // 
            resources.ApplyResources(this.pnlIRPsContainer, "pnlIRPsContainer");
            this.pnlIRPsContainer.Controls.Add(this.uiTab2);
            this.pnlIRPsContainer.Controls.Add(this.uiTab1);
            this.pnlIRPsContainer.Controls.Add(this.uiTab3);
            this.pnlIRPsContainer.Controls.Add(this.officeIDLabel);
            this.pnlIRPsContainer.Controls.Add(this.officeIDucOfficeSelectBox);
            this.pnlIRPsContainer.Controls.Add(this.calendarCombo1);
            this.pnlIRPsContainer.Controls.Add(this.label26);
            this.pnlIRPsContainer.Controls.Add(this.label9);
            this.pnlIRPsContainer.Controls.Add(this.iRPGridEX);
            this.pnlIRPsContainer.Controls.Add(this.gbMessage);
            this.pnlIRPsContainer.Name = "pnlIRPsContainer";
            this.helpProvider1.SetShowHelp(this.pnlIRPsContainer, ((bool)(resources.GetObject("pnlIRPsContainer.ShowHelp"))));
            // 
            // uiTab2
            // 
            resources.ApplyResources(this.uiTab2, "uiTab2");
            this.uiTab2.BackColor = System.Drawing.Color.Transparent;
            this.uiTab2.Name = "uiTab2";
            this.uiTab2.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab2.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab2, ((bool)(resources.GetObject("uiTab2.ShowHelp"))));
            this.uiTab2.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage2});
            this.uiTab2.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab2.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab2.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab2.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab2.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab2.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab2.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage2
            // 
            this.uiTabPage2.Controls.Add(this.totalTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label6);
            this.uiTabPage2.Controls.Add(this.totalTaxTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label17);
            this.uiTabPage2.Controls.Add(label2);
            this.uiTabPage2.Controls.Add(this.disbursementTaxedTaxNumericEditBox);
            this.uiTabPage2.Controls.Add(label1);
            this.uiTabPage2.Controls.Add(this.disbursementTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(this.disbursementTaxExemptTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label5);
            this.uiTabPage2.Controls.Add(this.feesTaxedTaxNumericEditBox);
            this.uiTabPage2.Controls.Add(label4);
            this.uiTabPage2.Controls.Add(this.feesTaxedNumericEditBox);
            this.uiTabPage2.Controls.Add(label3);
            this.uiTabPage2.Controls.Add(label7);
            this.uiTabPage2.Controls.Add(this.netTotalTaxedNumericEditBox);
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // totalTaxedNumericEditBox
            // 
            this.totalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalTaxed", true));
            this.totalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalTaxedNumericEditBox, "totalTaxedNumericEditBox");
            this.totalTaxedNumericEditBox.Name = "totalTaxedNumericEditBox";
            this.totalTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalTaxedNumericEditBox, ((bool)(resources.GetObject("totalTaxedNumericEditBox.ShowHelp"))));
            this.totalTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // iRPBindingSource
            // 
            this.iRPBindingSource.DataMember = "IRP";
            this.iRPBindingSource.DataSource = this.atriumDB;
            this.iRPBindingSource.CurrentChanged += new System.EventHandler(this.iRPBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "atriumDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // totalTaxTaxedNumericEditBox
            // 
            this.totalTaxTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalTaxTaxed", true));
            this.totalTaxTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalTaxTaxedNumericEditBox, "totalTaxTaxedNumericEditBox");
            this.totalTaxTaxedNumericEditBox.Name = "totalTaxTaxedNumericEditBox";
            this.totalTaxTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalTaxTaxedNumericEditBox, ((bool)(resources.GetObject("totalTaxTaxedNumericEditBox.ShowHelp"))));
            this.totalTaxTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTaxTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxedTaxNumericEditBox
            // 
            this.disbursementTaxedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxedTax", true));
            this.disbursementTaxedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxedTaxNumericEditBox, "disbursementTaxedTaxNumericEditBox");
            this.disbursementTaxedTaxNumericEditBox.Name = "disbursementTaxedTaxNumericEditBox";
            this.disbursementTaxedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxedTaxNumericEditBox, ((bool)(resources.GetObject("disbursementTaxedTaxNumericEditBox.ShowHelp"))));
            this.disbursementTaxedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxedNumericEditBox
            // 
            this.disbursementTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxed", true));
            this.disbursementTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxedNumericEditBox, "disbursementTaxedNumericEditBox");
            this.disbursementTaxedNumericEditBox.Name = "disbursementTaxedNumericEditBox";
            this.disbursementTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxedNumericEditBox.ShowHelp"))));
            this.disbursementTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxExemptTaxedNumericEditBox
            // 
            this.disbursementTaxExemptTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxExemptTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxExemptTaxed", true));
            this.disbursementTaxExemptTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxExemptTaxedNumericEditBox, "disbursementTaxExemptTaxedNumericEditBox");
            this.disbursementTaxExemptTaxedNumericEditBox.Name = "disbursementTaxExemptTaxedNumericEditBox";
            this.disbursementTaxExemptTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxExemptTaxedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxExemptTaxedNumericEditBox.ShowHelp"))));
            this.disbursementTaxExemptTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxExemptTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesTaxedTaxNumericEditBox
            // 
            this.feesTaxedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesTaxedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesTaxedTax", true));
            this.feesTaxedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesTaxedTaxNumericEditBox, "feesTaxedTaxNumericEditBox");
            this.feesTaxedTaxNumericEditBox.Name = "feesTaxedTaxNumericEditBox";
            this.feesTaxedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesTaxedTaxNumericEditBox, ((bool)(resources.GetObject("feesTaxedTaxNumericEditBox.ShowHelp"))));
            this.feesTaxedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesTaxedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesTaxedNumericEditBox
            // 
            this.feesTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesTaxed", true));
            this.feesTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesTaxedNumericEditBox, "feesTaxedNumericEditBox");
            this.feesTaxedNumericEditBox.Name = "feesTaxedNumericEditBox";
            this.feesTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesTaxedNumericEditBox, ((bool)(resources.GetObject("feesTaxedNumericEditBox.ShowHelp"))));
            this.feesTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // netTotalTaxedNumericEditBox
            // 
            this.netTotalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.netTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "NetTotalTaxed", true));
            this.netTotalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.netTotalTaxedNumericEditBox, "netTotalTaxedNumericEditBox");
            this.netTotalTaxedNumericEditBox.Name = "netTotalTaxedNumericEditBox";
            this.netTotalTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.netTotalTaxedNumericEditBox, ((bool)(resources.GetObject("netTotalTaxedNumericEditBox.ShowHelp"))));
            this.netTotalTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.netTotalTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiTab1
            // 
            resources.ApplyResources(this.uiTab1, "uiTab1");
            this.uiTab1.BackColor = System.Drawing.Color.Transparent;
            this.uiTab1.Name = "uiTab1";
            this.uiTab1.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab1.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab1, ((bool)(resources.GetObject("uiTab1.ShowHelp"))));
            this.uiTab1.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage1});
            this.uiTab1.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab1.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab1.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab1.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab1.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage1
            // 
            this.uiTabPage1.Controls.Add(this.totalClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(label21);
            this.uiTabPage1.Controls.Add(this.totalTaxClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(label25);
            this.uiTabPage1.Controls.Add(this.netTotalClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(label24);
            this.uiTabPage1.Controls.Add(this.disbursementClaimedTaxNumericEditBox);
            this.uiTabPage1.Controls.Add(label23);
            this.uiTabPage1.Controls.Add(this.disbursementClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(this.disbursementTaxExemptClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(label20);
            this.uiTabPage1.Controls.Add(this.feesClaimedTaxNumericEditBox);
            this.uiTabPage1.Controls.Add(label19);
            this.uiTabPage1.Controls.Add(this.feesClaimedNumericEditBox);
            this.uiTabPage1.Controls.Add(label18);
            this.uiTabPage1.Controls.Add(label22);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // totalClaimedNumericEditBox
            // 
            this.totalClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalClaimed", true));
            this.totalClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalClaimedNumericEditBox, "totalClaimedNumericEditBox");
            this.totalClaimedNumericEditBox.Name = "totalClaimedNumericEditBox";
            this.totalClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalClaimedNumericEditBox, ((bool)(resources.GetObject("totalClaimedNumericEditBox.ShowHelp"))));
            this.totalClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // totalTaxClaimedNumericEditBox
            // 
            this.totalTaxClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalTaxClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TotalTaxClaimed", true));
            this.totalTaxClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.totalTaxClaimedNumericEditBox, "totalTaxClaimedNumericEditBox");
            this.totalTaxClaimedNumericEditBox.Name = "totalTaxClaimedNumericEditBox";
            this.totalTaxClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.totalTaxClaimedNumericEditBox, ((bool)(resources.GetObject("totalTaxClaimedNumericEditBox.ShowHelp"))));
            this.totalTaxClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalTaxClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // netTotalClaimedNumericEditBox
            // 
            this.netTotalClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.netTotalClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "NetTotalClaimed", true));
            this.netTotalClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.netTotalClaimedNumericEditBox, "netTotalClaimedNumericEditBox");
            this.netTotalClaimedNumericEditBox.Name = "netTotalClaimedNumericEditBox";
            this.netTotalClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.netTotalClaimedNumericEditBox, ((bool)(resources.GetObject("netTotalClaimedNumericEditBox.ShowHelp"))));
            this.netTotalClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.netTotalClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementClaimedTaxNumericEditBox
            // 
            this.disbursementClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementClaimedTax", true));
            this.disbursementClaimedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementClaimedTaxNumericEditBox, "disbursementClaimedTaxNumericEditBox");
            this.disbursementClaimedTaxNumericEditBox.Name = "disbursementClaimedTaxNumericEditBox";
            this.disbursementClaimedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementClaimedTaxNumericEditBox, ((bool)(resources.GetObject("disbursementClaimedTaxNumericEditBox.ShowHelp"))));
            this.disbursementClaimedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementClaimedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementClaimedNumericEditBox
            // 
            this.disbursementClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementClaimed", true));
            this.disbursementClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementClaimedNumericEditBox, "disbursementClaimedNumericEditBox");
            this.disbursementClaimedNumericEditBox.Name = "disbursementClaimedNumericEditBox";
            this.disbursementClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementClaimedNumericEditBox, ((bool)(resources.GetObject("disbursementClaimedNumericEditBox.ShowHelp"))));
            this.disbursementClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // disbursementTaxExemptClaimedNumericEditBox
            // 
            this.disbursementTaxExemptClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.disbursementTaxExemptClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "DisbursementTaxExemptClaimed", true));
            this.disbursementTaxExemptClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.disbursementTaxExemptClaimedNumericEditBox, "disbursementTaxExemptClaimedNumericEditBox");
            this.disbursementTaxExemptClaimedNumericEditBox.Name = "disbursementTaxExemptClaimedNumericEditBox";
            this.disbursementTaxExemptClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.disbursementTaxExemptClaimedNumericEditBox, ((bool)(resources.GetObject("disbursementTaxExemptClaimedNumericEditBox.ShowHelp"))));
            this.disbursementTaxExemptClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.disbursementTaxExemptClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesClaimedTaxNumericEditBox
            // 
            this.feesClaimedTaxNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedTaxNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesClaimedTax", true));
            this.feesClaimedTaxNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesClaimedTaxNumericEditBox, "feesClaimedTaxNumericEditBox");
            this.feesClaimedTaxNumericEditBox.Name = "feesClaimedTaxNumericEditBox";
            this.feesClaimedTaxNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesClaimedTaxNumericEditBox, ((bool)(resources.GetObject("feesClaimedTaxNumericEditBox.ShowHelp"))));
            this.feesClaimedTaxNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesClaimedTaxNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // feesClaimedNumericEditBox
            // 
            this.feesClaimedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.feesClaimedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FeesClaimed", true));
            this.feesClaimedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.feesClaimedNumericEditBox, "feesClaimedNumericEditBox");
            this.feesClaimedNumericEditBox.Name = "feesClaimedNumericEditBox";
            this.feesClaimedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.feesClaimedNumericEditBox, ((bool)(resources.GetObject("feesClaimedNumericEditBox.ShowHelp"))));
            this.feesClaimedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.feesClaimedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
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
            this.uiTabPage3.Controls.Add(this.mccTaxingOfficer);
            this.uiTabPage3.Controls.Add(this.fileIDucFileSelectBox);
            this.uiTabPage3.Controls.Add(this.btnValidateSIN);
            this.uiTabPage3.Controls.Add(percentOfPrincipalLabel);
            this.uiTabPage3.Controls.Add(this.uiButton2);
            this.uiTabPage3.Controls.Add(this.percentOfPrincipalNumericEditBox);
            this.uiTabPage3.Controls.Add(fileIDLabel);
            this.uiTabPage3.Controls.Add(sINLabel);
            this.uiTabPage3.Controls.Add(label8);
            this.uiTabPage3.Controls.Add(fileTotalTaxedLabel);
            this.uiTabPage3.Controls.Add(this.uiButton1);
            this.uiTabPage3.Controls.Add(officerCodeLabel);
            this.uiTabPage3.Controls.Add(this.fileTotalTaxedNumericEditBox);
            this.uiTabPage3.Controls.Add(this.dateTaxedCalendarCombo);
            this.uiTabPage3.Controls.Add(this.taxingDifferenceNumericEditBox);
            this.uiTabPage3.Controls.Add(dateTaxedLabel);
            this.uiTabPage3.Controls.Add(this.sINMaskedEditBox);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // mccTaxingOfficer
            // 
            this.mccTaxingOfficer.BackColor = System.Drawing.Color.Transparent;
            this.mccTaxingOfficer.Column1 = "officercode";
            resources.ApplyResources(this.mccTaxingOfficer, "mccTaxingOfficer");
            this.mccTaxingOfficer.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            this.mccTaxingOfficer.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.iRPBindingSource, "OfficerID", true));
            this.mccTaxingOfficer.DataSource = null;
            this.mccTaxingOfficer.DDColumn1Visible = true;
            this.mccTaxingOfficer.DropDownColumn1Width = 100;
            this.mccTaxingOfficer.DropDownColumn2Width = 300;
            this.mccTaxingOfficer.Name = "mccTaxingOfficer";
            this.mccTaxingOfficer.ReadOnly = false;
            this.mccTaxingOfficer.ReqColor = System.Drawing.SystemColors.Window;
            this.mccTaxingOfficer.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.mccTaxingOfficer, ((bool)(resources.GetObject("mccTaxingOfficer.ShowHelp"))));
            this.mccTaxingOfficer.ValueMember = "officerid";
            // 
            // fileIDucFileSelectBox
            // 
            this.fileIDucFileSelectBox.AtMng = null;
            this.fileIDucFileSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.fileIDucFileSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("FileId", this.iRPBindingSource, "FileID", true));
            this.fileIDucFileSelectBox.FileId = null;
            resources.ApplyResources(this.fileIDucFileSelectBox, "fileIDucFileSelectBox");
            this.fileIDucFileSelectBox.Name = "fileIDucFileSelectBox";
            this.fileIDucFileSelectBox.ReadOnly = true;
            this.fileIDucFileSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.fileIDucFileSelectBox, ((bool)(resources.GetObject("fileIDucFileSelectBox.ShowHelp"))));
            // 
            // btnValidateSIN
            // 
            this.btnValidateSIN.Image = global::LawMate.Properties.Resources.subprocess;
            resources.ApplyResources(this.btnValidateSIN, "btnValidateSIN");
            this.btnValidateSIN.Name = "btnValidateSIN";
            this.helpProvider1.SetShowHelp(this.btnValidateSIN, ((bool)(resources.GetObject("btnValidateSIN.ShowHelp"))));
            this.btnValidateSIN.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnValidateSIN.Click += new System.EventHandler(this.btnValidateSIN_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.uiButton2.DropDownContextMenu = this.uiContextMenu2;
            resources.ApplyResources(this.uiButton2, "uiButton2");
            this.uiButton2.Name = "uiButton2";
            this.helpProvider1.SetShowHelp(this.uiButton2, ((bool)(resources.GetObject("uiButton2.ShowHelp"))));
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // uiContextMenu2
            // 
            this.uiContextMenu2.CommandManager = this.uiCommandManager1;
            resources.ApplyResources(this.uiContextMenu2, "uiContextMenu2");
            this.uiContextMenu2.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
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
            this.tsSaveIRP,
            this.tsDeleteIRP,
            this.tsNewIRP,
            this.tsGoToSRP,
            this.tsGoToBillingReview,
            this.tsScreenTitleIRP,
            this.tsEditmode,
            this.tsMessage,
            this.cmdFile,
            this.cmdEdit,
            this.tsActions,
            this.cmdJumpToActivity,
            this.cmdJumpToTaxation});
            this.uiCommandManager1.ContainerControl = this;
            this.uiCommandManager1.ContextMenus.AddRange(new Janus.Windows.UI.CommandBars.UIContextMenu[] {
            this.uiContextMenu1,
            this.uiContextMenu3,
            this.uiContextMenu2});
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
            this.tsEditmode2,
            this.tsScreenTitleIRP1,
            this.Separator7,
            this.tsNewIRP1,
            this.Separator1,
            this.tsSaveIRP1,
            this.tsDeleteIRP1});
            this.uiCommandBar2.FullRow = true;
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.helpProvider1.SetShowHelp(this.uiCommandBar2, ((bool)(resources.GetObject("uiCommandBar2.ShowHelp"))));
            // 
            // tsEditmode2
            // 
            resources.ApplyResources(this.tsEditmode2, "tsEditmode2");
            this.tsEditmode2.Name = "tsEditmode2";
            // 
            // tsScreenTitleIRP1
            // 
            resources.ApplyResources(this.tsScreenTitleIRP1, "tsScreenTitleIRP1");
            this.tsScreenTitleIRP1.Name = "tsScreenTitleIRP1";
            // 
            // Separator7
            // 
            this.Separator7.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator7, "Separator7");
            this.Separator7.Name = "Separator7";
            // 
            // tsNewIRP1
            // 
            resources.ApplyResources(this.tsNewIRP1, "tsNewIRP1");
            this.tsNewIRP1.Name = "tsNewIRP1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator1, "Separator1");
            this.Separator1.Name = "Separator1";
            // 
            // tsSaveIRP1
            // 
            resources.ApplyResources(this.tsSaveIRP1, "tsSaveIRP1");
            this.tsSaveIRP1.Name = "tsSaveIRP1";
            // 
            // tsDeleteIRP1
            // 
            resources.ApplyResources(this.tsDeleteIRP1, "tsDeleteIRP1");
            this.tsDeleteIRP1.Name = "tsDeleteIRP1";
            // 
            // tsSaveIRP
            // 
            this.tsSaveIRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsSaveIRP, "tsSaveIRP");
            this.tsSaveIRP.Name = "tsSaveIRP";
            // 
            // tsDeleteIRP
            // 
            this.tsDeleteIRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsDeleteIRP, "tsDeleteIRP");
            this.tsDeleteIRP.Name = "tsDeleteIRP";
            // 
            // tsNewIRP
            // 
            this.tsNewIRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.tsNewIRP, "tsNewIRP");
            this.tsNewIRP.Name = "tsNewIRP";
            // 
            // tsGoToSRP
            // 
            this.tsGoToSRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsGoToSRP, "tsGoToSRP");
            this.tsGoToSRP.Name = "tsGoToSRP";
            // 
            // tsGoToBillingReview
            // 
            this.tsGoToBillingReview.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            resources.ApplyResources(this.tsGoToBillingReview, "tsGoToBillingReview");
            this.tsGoToBillingReview.Name = "tsGoToBillingReview";
            // 
            // tsScreenTitleIRP
            // 
            this.tsScreenTitleIRP.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            this.tsScreenTitleIRP.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsScreenTitleIRP, "tsScreenTitleIRP");
            this.tsScreenTitleIRP.Name = "tsScreenTitleIRP";
            this.tsScreenTitleIRP.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.StateStyles.FormatStyle.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.ImageBeforeText;
            this.tsEditmode.Visible = Janus.Windows.UI.InheritableBoolean.True;
            // 
            // tsMessage
            // 
            this.tsMessage.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.tsMessage.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsMessage, "tsMessage");
            this.tsMessage.IsEditableControl = Janus.Windows.UI.InheritableBoolean.False;
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsMessage.StateStyles.FormatStyle.FontName = "arial";
            this.tsMessage.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Red;
            this.tsMessage.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSaveIRP2,
            this.Separator2,
            this.tsNewIRP2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.Name = "cmdFile";
            // 
            // tsSaveIRP2
            // 
            resources.ApplyResources(this.tsSaveIRP2, "tsSaveIRP2");
            this.tsSaveIRP2.Name = "tsSaveIRP2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsNewIRP2
            // 
            resources.ApplyResources(this.tsNewIRP2, "tsNewIRP2");
            this.tsNewIRP2.Name = "tsNewIRP2";
            // 
            // cmdEdit
            // 
            this.cmdEdit.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsDeleteIRP2});
            resources.ApplyResources(this.cmdEdit, "cmdEdit");
            this.cmdEdit.Name = "cmdEdit";
            // 
            // tsDeleteIRP2
            // 
            resources.ApplyResources(this.tsDeleteIRP2, "tsDeleteIRP2");
            this.tsDeleteIRP2.Name = "tsDeleteIRP2";
            // 
            // tsActions
            // 
            resources.ApplyResources(this.tsActions, "tsActions");
            this.tsActions.Name = "tsActions";
            // 
            // cmdJumpToActivity
            // 
            resources.ApplyResources(this.cmdJumpToActivity, "cmdJumpToActivity");
            this.cmdJumpToActivity.Name = "cmdJumpToActivity";
            // 
            // cmdJumpToTaxation
            // 
            resources.ApplyResources(this.cmdJumpToTaxation, "cmdJumpToTaxation");
            this.cmdJumpToTaxation.Name = "cmdJumpToTaxation";
            // 
            // uiContextMenu1
            // 
            this.uiContextMenu1.CommandManager = this.uiCommandManager1;
            this.uiContextMenu1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdJumpToActivity1,
            this.cmdJumpToTaxation1});
            resources.ApplyResources(this.uiContextMenu1, "uiContextMenu1");
            this.uiContextMenu1.UseThemes = Janus.Windows.UI.InheritableBoolean.True;
            this.uiContextMenu1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // cmdJumpToActivity1
            // 
            resources.ApplyResources(this.cmdJumpToActivity1, "cmdJumpToActivity1");
            this.cmdJumpToActivity1.Name = "cmdJumpToActivity1";
            // 
            // cmdJumpToTaxation1
            // 
            resources.ApplyResources(this.cmdJumpToTaxation1, "cmdJumpToTaxation1");
            this.cmdJumpToTaxation1.Name = "cmdJumpToTaxation1";
            // 
            // uiContextMenu3
            // 
            this.uiContextMenu3.CommandManager = this.uiCommandManager1;
            this.uiContextMenu3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsGoToSRP1,
            this.tsGoToBillingReview1});
            resources.ApplyResources(this.uiContextMenu3, "uiContextMenu3");
            this.uiContextMenu3.Popup += new System.EventHandler(this.uiContextMenu3_Popup);
            // 
            // tsGoToSRP1
            // 
            resources.ApplyResources(this.tsGoToSRP1, "tsGoToSRP1");
            this.tsGoToSRP1.Name = "tsGoToSRP1";
            // 
            // tsGoToBillingReview1
            // 
            resources.ApplyResources(this.tsGoToBillingReview1, "tsGoToBillingReview1");
            this.tsGoToBillingReview1.Name = "tsGoToBillingReview1";
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
            this.uiCommandBar2,
            this.uiCommandBar1});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Controls.Add(this.uiCommandBar1);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // iRPGridEX
            // 
            this.iRPGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.iRPGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.iRPGridEX, "iRPGridEX");
            this.iRPGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.Sunken;
            this.uiCommandManager1.SetContextMenu(this.iRPGridEX, this.uiContextMenu3);
            this.iRPGridEX.DataSource = this.iRPBindingSource;
            resources.ApplyResources(iRPGridEX_DesignTimeLayout, "iRPGridEX_DesignTimeLayout");
            this.iRPGridEX.DesignTimeLayout = iRPGridEX_DesignTimeLayout;
            this.iRPGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.iRPGridEX.GridLineColor = System.Drawing.SystemColors.Control;
            this.iRPGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.iRPGridEX.GroupByBoxVisible = false;
            this.iRPGridEX.HeaderFormatStyle.Appearance = Janus.Windows.GridEX.Appearance.Raised;
            this.iRPGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.iRPGridEX.Name = "iRPGridEX";
            this.helpProvider1.SetShowHelp(this.iRPGridEX, ((bool)(resources.GetObject("iRPGridEX.ShowHelp"))));
            this.iRPGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.iRPGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.iRPGridEX.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.iRPGridEX_RowDoubleClick);
            this.iRPGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.iRPGridEX_CurrentCellChanging);
            // 
            // percentOfPrincipalNumericEditBox
            // 
            this.percentOfPrincipalNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.percentOfPrincipalNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "PercentOfPrincipal", true));
            this.percentOfPrincipalNumericEditBox.DecimalDigits = 3;
            this.percentOfPrincipalNumericEditBox.FormatString = "0.000 %";
            resources.ApplyResources(this.percentOfPrincipalNumericEditBox, "percentOfPrincipalNumericEditBox");
            this.percentOfPrincipalNumericEditBox.Name = "percentOfPrincipalNumericEditBox";
            this.percentOfPrincipalNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.percentOfPrincipalNumericEditBox, ((bool)(resources.GetObject("percentOfPrincipalNumericEditBox.ShowHelp"))));
            this.percentOfPrincipalNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.percentOfPrincipalNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiButton1
            // 
            this.uiButton1.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            this.uiButton1.DropDownContextMenu = this.uiContextMenu1;
            resources.ApplyResources(this.uiButton1, "uiButton1");
            this.uiButton1.Name = "uiButton1";
            this.helpProvider1.SetShowHelp(this.uiButton1, ((bool)(resources.GetObject("uiButton1.ShowHelp"))));
            this.uiButton1.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            // 
            // fileTotalTaxedNumericEditBox
            // 
            this.fileTotalTaxedNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.fileTotalTaxedNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "FileTotalTaxed", true));
            this.fileTotalTaxedNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.fileTotalTaxedNumericEditBox, "fileTotalTaxedNumericEditBox");
            this.fileTotalTaxedNumericEditBox.Name = "fileTotalTaxedNumericEditBox";
            this.fileTotalTaxedNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.fileTotalTaxedNumericEditBox, ((bool)(resources.GetObject("fileTotalTaxedNumericEditBox.ShowHelp"))));
            this.fileTotalTaxedNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.fileTotalTaxedNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // dateTaxedCalendarCombo
            // 
            resources.ApplyResources(this.dateTaxedCalendarCombo, "dateTaxedCalendarCombo");
            this.dateTaxedCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.iRPBindingSource, "DateTaxed", true));
            // 
            // 
            // 
            this.dateTaxedCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2007, 3, 1, 0, 0, 0, 0);
            this.dateTaxedCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateTaxedCalendarCombo.HourIncrement = 0;
            this.dateTaxedCalendarCombo.MonthIncrement = 0;
            this.dateTaxedCalendarCombo.Name = "dateTaxedCalendarCombo";
            this.dateTaxedCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.dateTaxedCalendarCombo, ((bool)(resources.GetObject("dateTaxedCalendarCombo.ShowHelp"))));
            this.dateTaxedCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.dateTaxedCalendarCombo.YearIncrement = 0;
            // 
            // taxingDifferenceNumericEditBox
            // 
            this.taxingDifferenceNumericEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.taxingDifferenceNumericEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.iRPBindingSource, "TaxingDifference", true));
            this.taxingDifferenceNumericEditBox.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
            resources.ApplyResources(this.taxingDifferenceNumericEditBox, "taxingDifferenceNumericEditBox");
            this.taxingDifferenceNumericEditBox.Name = "taxingDifferenceNumericEditBox";
            this.taxingDifferenceNumericEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.taxingDifferenceNumericEditBox, ((bool)(resources.GetObject("taxingDifferenceNumericEditBox.ShowHelp"))));
            this.taxingDifferenceNumericEditBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.taxingDifferenceNumericEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sINMaskedEditBox
            // 
            this.sINMaskedEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.sINMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.iRPBindingSource, "SIN", true));
            resources.ApplyResources(this.sINMaskedEditBox, "sINMaskedEditBox");
            this.sINMaskedEditBox.Mask = "000 000 000";
            this.sINMaskedEditBox.Name = "sINMaskedEditBox";
            this.sINMaskedEditBox.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.sINMaskedEditBox, ((bool)(resources.GetObject("sINMaskedEditBox.ShowHelp"))));
            this.sINMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // officeIDucOfficeSelectBox
            // 
            resources.ApplyResources(this.officeIDucOfficeSelectBox, "officeIDucOfficeSelectBox");
            this.officeIDucOfficeSelectBox.AtMng = null;
            this.officeIDucOfficeSelectBox.BackColor = System.Drawing.Color.Transparent;
            this.officeIDucOfficeSelectBox.DataBindings.Add(new System.Windows.Forms.Binding("OfficeId", this.iRPBindingSource, "OfficeID", true));
            this.officeIDucOfficeSelectBox.Name = "officeIDucOfficeSelectBox";
            this.officeIDucOfficeSelectBox.OfficeId = null;
            this.officeIDucOfficeSelectBox.ReadOnly = true;
            this.officeIDucOfficeSelectBox.ReqColor = System.Drawing.SystemColors.Control;
            this.helpProvider1.SetShowHelp(this.officeIDucOfficeSelectBox, ((bool)(resources.GetObject("officeIDucOfficeSelectBox.ShowHelp"))));
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.calendarCombo1, "calendarCombo1");
            this.calendarCombo1.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.iRPBindingSource, "SRPDate", true));
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.FirstMonth = new System.DateTime(2007, 3, 1, 0, 0, 0, 0);
            this.calendarCombo1.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.ReadOnly = true;
            this.helpProvider1.SetShowHelp(this.calendarCombo1, ((bool)(resources.GetObject("calendarCombo1.ShowHelp"))));
            this.calendarCombo1.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Image = global::LawMate.Properties.Resources.hourglass;
            this.label9.Name = "label9";
            this.helpProvider1.SetShowHelp(this.label9, ((bool)(resources.GetObject("label9.ShowHelp"))));
            // 
            // gbMessage
            // 
            resources.ApplyResources(this.gbMessage, "gbMessage");
            this.gbMessage.BackColor = System.Drawing.Color.Transparent;
            this.gbMessage.Controls.Add(this.btnBeginTaxation);
            this.gbMessage.Controls.Add(this.label10);
            this.gbMessage.FrameStyle = Janus.Windows.EditControls.FrameStyle.Top;
            this.gbMessage.Image = global::LawMate.Properties.Resources.blue_info2_gif;
            this.gbMessage.ImageAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.gbMessage.Name = "gbMessage";
            this.helpProvider1.SetShowHelp(this.gbMessage, ((bool)(resources.GetObject("gbMessage.ShowHelp"))));
            this.gbMessage.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.gbMessage.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            // 
            // btnBeginTaxation
            // 
            this.btnBeginTaxation.Image = global::LawMate.Properties.Resources.save1;
            resources.ApplyResources(this.btnBeginTaxation, "btnBeginTaxation");
            this.btnBeginTaxation.Name = "btnBeginTaxation";
            this.btnBeginTaxation.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.btnBeginTaxation, ((bool)(resources.GetObject("btnBeginTaxation.ShowHelp"))));
            this.btnBeginTaxation.VisualStyle = Janus.Windows.UI.VisualStyle.VS2010;
            this.btnBeginTaxation.Click += new System.EventHandler(this.btnBeginTaxation_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Name = "label10";
            this.helpProvider1.SetShowHelp(this.label10, ((bool)(resources.GetObject("label10.ShowHelp"))));
            // 
            // taxingGridEX
            // 
            this.taxingGridEX.AllowColumnDrag = false;
            this.taxingGridEX.AutomaticSort = false;
            resources.ApplyResources(taxingGridEX_DesignTimeLayout, "taxingGridEX_DesignTimeLayout");
            this.taxingGridEX.DesignTimeLayout = taxingGridEX_DesignTimeLayout;
            this.taxingGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.taxingGridEX.GroupByBoxVisible = false;
            resources.ApplyResources(this.taxingGridEX, "taxingGridEX");
            this.taxingGridEX.Name = "taxingGridEX";
            this.helpProvider1.SetShowHelp(this.taxingGridEX, ((bool)(resources.GetObject("taxingGridEX.ShowHelp"))));
            this.taxingGridEX.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.taxingGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // pnlGrid
            // 
            this.pnlGrid.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.pnlGrid.CaptionStyle = Janus.Windows.UI.Dock.PanelCaptionStyle.Dark;
            this.pnlGrid.CaptionVisible = Janus.Windows.UI.InheritableBoolean.True;
            this.pnlGrid.InnerContainer = this.pnlGridContainer;
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            this.helpProvider1.SetShowHelp(this.pnlGrid, ((bool)(resources.GetObject("pnlGrid.ShowHelp"))));
            // 
            // pnlGridContainer
            // 
            resources.ApplyResources(this.pnlGridContainer, "pnlGridContainer");
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.helpProvider1.SetShowHelp(this.pnlGridContainer, ((bool)(resources.GetObject("pnlGridContainer.ShowHelp"))));
            // 
            // pnlSRP
            // 
            this.pnlSRP.InnerContainer = this.pnlSRPContainer;
            resources.ApplyResources(this.pnlSRP, "pnlSRP");
            this.pnlSRP.Name = "pnlSRP";
            this.helpProvider1.SetShowHelp(this.pnlSRP, ((bool)(resources.GetObject("pnlSRP.ShowHelp"))));
            // 
            // pnlSRPContainer
            // 
            resources.ApplyResources(this.pnlSRPContainer, "pnlSRPContainer");
            this.pnlSRPContainer.Name = "pnlSRPContainer";
            this.helpProvider1.SetShowHelp(this.pnlSRPContainer, ((bool)(resources.GetObject("pnlSRPContainer.ShowHelp"))));
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ucSRPDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.TopRebar1);
            resources.ApplyResources(this, "$this");
            this.Name = "ucSRPDetail";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.Load += new System.EventHandler(this.ucSRPDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTab)).EndInit();
            this.pnlTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIRPs)).EndInit();
            this.pnlIRPs.ResumeLayout(false);
            this.pnlIRPsContainer.ResumeLayout(false);
            this.pnlIRPsContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage2.ResumeLayout(false);
            this.uiTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iRPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            this.uiTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiContextMenu3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iRPGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbMessage)).EndInit();
            this.gbMessage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.taxingGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSRP)).EndInit();
            this.pnlSRP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel pnlGrid;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlGridContainer;
        private Janus.Windows.UI.Dock.UIPanel pnlSRP;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlSRPContainer;
        private Janus.Windows.UI.Dock.UIPanelGroup pnlTab;
        private Janus.Windows.UI.Dock.UIPanel pnlIRPs;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlIRPsContainer;
        private System.Windows.Forms.BindingSource iRPBindingSource;
        private Janus.Windows.GridEX.GridEX taxingGridEX;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.CalendarCombo.CalendarCombo dateTaxedCalendarCombo;
        private Janus.Windows.GridEX.EditControls.NumericEditBox percentOfPrincipalNumericEditBox;
        private Janus.Windows.GridEX.GridEX iRPGridEX;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitleIRP;
        private Janus.Windows.UI.CommandBars.UICommand tsNewIRP;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToBillingReview;
        private Janus.Windows.UI.CommandBars.UICommand tsSaveIRP;
        private Janus.Windows.UI.CommandBars.UICommand tsDeleteIRP;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRP;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitleIRP1;
        private Janus.Windows.UI.CommandBars.UICommand Separator7;
        private Janus.Windows.UI.CommandBars.UICommand tsSaveIRP1;
        private Janus.Windows.UI.CommandBars.UICommand tsDeleteIRP1;
        private Janus.Windows.UI.CommandBars.UICommand tsNewIRP1;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode2;
        private Janus.Windows.UI.CommandBars.UICommand tsMessage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ucOfficeSelectBox officeIDucOfficeSelectBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox totalTaxClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox netTotalClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox disbursementTaxExemptClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedTaxNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox feesClaimedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox fileTotalTaxedNumericEditBox;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox sINMaskedEditBox;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSaveIRP2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsNewIRP2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand tsDeleteIRP2;
        private Janus.Windows.UI.CommandBars.UICommand tsActions;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToActivity;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToTaxation;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToActivity1;
        private Janus.Windows.UI.CommandBars.UICommand cmdJumpToTaxation1;
        private ucFileSelectBox fileIDucFileSelectBox;
        private Janus.Windows.GridEX.EditControls.NumericEditBox taxingDifferenceNumericEditBox;
        private Janus.Windows.EditControls.UIButton uiButton2;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu2;
        private lmDatasets.atriumDB atriumDB;
        private Janus.Windows.EditControls.UIButton btnValidateSIN;
        private UserControls.ucMultiDropDown mccTaxingOfficer;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label officeIDLabel;
        private System.Windows.Forms.Label label9;
        private Janus.Windows.UI.CommandBars.UIContextMenu uiContextMenu3;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToSRP1;
        private Janus.Windows.UI.CommandBars.UICommand tsGoToBillingReview1;
        private Janus.Windows.EditControls.UIGroupBox gbMessage;
        private System.Windows.Forms.Label label10;
        private Janus.Windows.EditControls.UIButton btnBeginTaxation;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
    }
}
