 namespace LawMate
{
    partial class ucOpponent
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
                FM.DB.Address.ColumnChanged-= new System.Data.DataColumnChangeEventHandler(Address_ColumnChanged);
                FM.GetAddress().OnUpdate -= new atLogic.UpdateEventHandler(ucOpponent_OnUpdate);

                FM.GetCLASMng().DB.Debtor.ColumnChanged -= new System.Data.DataColumnChangeEventHandler(Address_ColumnChanged);
                FM.GetCLASMng().GetDebtor().OnUpdate -= new atLogic.UpdateEventHandler(ucOpponent_OnUpdate);

                this.uiCommandManager1.CommandClick -= new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);

                this.debtorBindingSource.CurrentChanged -= new System.EventHandler(this.debtorBindingSource_CurrentChanged);
                this.addressBindingSource.CurrentChanged -= new System.EventHandler(this.addressBindingSource_CurrentChanged);
                this.addressGridEX.ColumnButtonClick -= new Janus.Windows.GridEX.ColumnActionEventHandler(this.addressGridEX_ColumnButtonClick);
                this.aKAGridEX.ColumnButtonClick -= new Janus.Windows.GridEX.ColumnActionEventHandler(this.aKAGridEX_ColumnButtonClick);
                this.aKABindingSource.CurrentChanged -= new System.EventHandler(this.aKABindingSource_CurrentChanged);

                ucAddress1.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOpponent));
            System.Windows.Forms.Label lastNameLabel;
            System.Windows.Forms.Label firstNameLabel;
            System.Windows.Forms.Label birthDateLabel;
            System.Windows.Forms.Label ceasedToBeStudentDateLabel;
            System.Windows.Forms.Label sINLabel1;
            System.Windows.Forms.Label emailAddressLabel;
            System.Windows.Forms.Label homePhoneLabel;
            System.Windows.Forms.Label workPhoneLabel;
            System.Windows.Forms.Label workExtensionLabel;
            System.Windows.Forms.Label mobilePhoneLabel;
            System.Windows.Forms.Label faxNumberLabel;
            System.Windows.Forms.Label effectiveToLabel;
            System.Windows.Forms.Label languageCodeLabel;
            System.Windows.Forms.Label sexCodeLabel;
            System.Windows.Forms.Label addressTypeLabel;
            System.Windows.Forms.Label addressSourceCodeLabel;
            System.Windows.Forms.Label suffixLabel;
            System.Windows.Forms.Label salutationLabel;
            System.Windows.Forms.Label middleNameLabel;
            Janus.Windows.GridEX.GridEXLayout aKAGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference aKAGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column3.ButtonImage");
            Janus.Windows.GridEX.GridEXLayout addressGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference addressGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference addressGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item0.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference addressGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference addressGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item2.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference addressGridEX_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column1.ValueList.Item3.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference addressGridEX_DesignTimeLayout_Reference_5 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column7.ButtonImage");
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiTab4 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage4 = new Janus.Windows.UI.Tab.UITabPage();
            this.uiCheckBox1 = new Janus.Windows.EditControls.UICheckBox();
            this.debtorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CLAS = new lmDatasets.CLAS();
            this.ucLanguageCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ucSexCodeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.ceasedToBeStudentDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.birthDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.uiTab2 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage2 = new Janus.Windows.UI.Tab.UITabPage();
            this.notesEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiTab1 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage1 = new Janus.Windows.UI.Tab.UITabPage();
            this.aKAGridEX = new Janus.Windows.GridEX.GridEX();
            this.aKABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uiTab3 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage3 = new Janus.Windows.UI.Tab.UITabPage();
            this.firstNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.sINMaskedEditBox = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.lastNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.suffixEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.middleNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.salutationEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.uiTab5 = new Janus.Windows.UI.Tab.UITab();
            this.uiTabPage5 = new Janus.Windows.UI.Tab.UITabPage();
            this.emailAddressEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addressGridEX = new Janus.Windows.GridEX.GridEX();
            this.ucAddressSourceMcc = new LawMate.UserControls.ucMultiDropDown();
            this.telephoneExtensionEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.maskedEditBox4 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.ucAddressTypeMcc = new LawMate.UserControls.ucMultiDropDown();
            this.effectiveToCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.maskedEditBox3 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.maskedEditBox2 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.ucAddress1 = new LawMate.UserControls.ucAddress();
            this.maskedEditBox1 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar2 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdFile1 = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.cmdEdit1 = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.uiCommandBar3 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.tsEditmode2 = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsScreenTitle2 = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsSave3 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.tsAudit1 = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.tsSave = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.tsScreenTitle = new Janus.Windows.UI.CommandBars.UICommand("tsScreenTitle");
            this.tsEditmode = new Janus.Windows.UI.CommandBars.UICommand("tsEditmode");
            this.tsAudit = new Janus.Windows.UI.CommandBars.UICommand("tsAudit");
            this.cmdFile = new Janus.Windows.UI.CommandBars.UICommand("cmdFile");
            this.tsSave2 = new Janus.Windows.UI.CommandBars.UICommand("tsSave");
            this.cmdEdit = new Janus.Windows.UI.CommandBars.UICommand("cmdEdit");
            this.cmdTools = new Janus.Windows.UI.CommandBars.UICommand("cmdTools");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            this.janusSuperTip1 = new Janus.Windows.Common.JanusSuperTip(this.components);
            lastNameLabel = new System.Windows.Forms.Label();
            firstNameLabel = new System.Windows.Forms.Label();
            birthDateLabel = new System.Windows.Forms.Label();
            ceasedToBeStudentDateLabel = new System.Windows.Forms.Label();
            sINLabel1 = new System.Windows.Forms.Label();
            emailAddressLabel = new System.Windows.Forms.Label();
            homePhoneLabel = new System.Windows.Forms.Label();
            workPhoneLabel = new System.Windows.Forms.Label();
            workExtensionLabel = new System.Windows.Forms.Label();
            mobilePhoneLabel = new System.Windows.Forms.Label();
            faxNumberLabel = new System.Windows.Forms.Label();
            effectiveToLabel = new System.Windows.Forms.Label();
            languageCodeLabel = new System.Windows.Forms.Label();
            sexCodeLabel = new System.Windows.Forms.Label();
            addressTypeLabel = new System.Windows.Forms.Label();
            addressSourceCodeLabel = new System.Windows.Forms.Label();
            suffixLabel = new System.Windows.Forms.Label();
            salutationLabel = new System.Windows.Forms.Label();
            middleNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab4)).BeginInit();
            this.uiTab4.SuspendLayout();
            this.uiTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).BeginInit();
            this.uiTab2.SuspendLayout();
            this.uiTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).BeginInit();
            this.uiTab1.SuspendLayout();
            this.uiTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aKAGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aKABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).BeginInit();
            this.uiTab3.SuspendLayout();
            this.uiTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab5)).BeginInit();
            this.uiTab5.SuspendLayout();
            this.uiTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.DataSource = this.debtorBindingSource;
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
            this.imageListBase.Images.SetKeyName(18, "audit.gif");
            this.imageListBase.Images.SetKeyName(19, "DRedit.gif");
            // 
            // lastNameLabel
            // 
            resources.ApplyResources(lastNameLabel, "lastNameLabel");
            lastNameLabel.BackColor = System.Drawing.Color.Transparent;
            lastNameLabel.Name = "lastNameLabel";
            this.helpProvider1.SetShowHelp(lastNameLabel, ((bool)(resources.GetObject("lastNameLabel.ShowHelp"))));
            // 
            // firstNameLabel
            // 
            resources.ApplyResources(firstNameLabel, "firstNameLabel");
            firstNameLabel.BackColor = System.Drawing.Color.Transparent;
            firstNameLabel.Name = "firstNameLabel";
            this.helpProvider1.SetShowHelp(firstNameLabel, ((bool)(resources.GetObject("firstNameLabel.ShowHelp"))));
            // 
            // birthDateLabel
            // 
            resources.ApplyResources(birthDateLabel, "birthDateLabel");
            birthDateLabel.BackColor = System.Drawing.Color.Transparent;
            birthDateLabel.Name = "birthDateLabel";
            this.helpProvider1.SetShowHelp(birthDateLabel, ((bool)(resources.GetObject("birthDateLabel.ShowHelp"))));
            // 
            // ceasedToBeStudentDateLabel
            // 
            resources.ApplyResources(ceasedToBeStudentDateLabel, "ceasedToBeStudentDateLabel");
            ceasedToBeStudentDateLabel.BackColor = System.Drawing.Color.Transparent;
            ceasedToBeStudentDateLabel.Name = "ceasedToBeStudentDateLabel";
            this.helpProvider1.SetShowHelp(ceasedToBeStudentDateLabel, ((bool)(resources.GetObject("ceasedToBeStudentDateLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(ceasedToBeStudentDateLabel, resources.GetString("ceasedToBeStudentDateLabel.ToolTip"));
            // 
            // sINLabel1
            // 
            resources.ApplyResources(sINLabel1, "sINLabel1");
            sINLabel1.BackColor = System.Drawing.Color.Transparent;
            sINLabel1.Name = "sINLabel1";
            this.helpProvider1.SetShowHelp(sINLabel1, ((bool)(resources.GetObject("sINLabel1.ShowHelp"))));
            // 
            // emailAddressLabel
            // 
            resources.ApplyResources(emailAddressLabel, "emailAddressLabel");
            emailAddressLabel.BackColor = System.Drawing.Color.Transparent;
            emailAddressLabel.Name = "emailAddressLabel";
            this.helpProvider1.SetShowHelp(emailAddressLabel, ((bool)(resources.GetObject("emailAddressLabel.ShowHelp"))));
            // 
            // homePhoneLabel
            // 
            resources.ApplyResources(homePhoneLabel, "homePhoneLabel");
            homePhoneLabel.BackColor = System.Drawing.Color.Transparent;
            homePhoneLabel.Name = "homePhoneLabel";
            this.helpProvider1.SetShowHelp(homePhoneLabel, ((bool)(resources.GetObject("homePhoneLabel.ShowHelp"))));
            // 
            // workPhoneLabel
            // 
            resources.ApplyResources(workPhoneLabel, "workPhoneLabel");
            workPhoneLabel.BackColor = System.Drawing.Color.Transparent;
            workPhoneLabel.Name = "workPhoneLabel";
            this.helpProvider1.SetShowHelp(workPhoneLabel, ((bool)(resources.GetObject("workPhoneLabel.ShowHelp"))));
            // 
            // workExtensionLabel
            // 
            resources.ApplyResources(workExtensionLabel, "workExtensionLabel");
            workExtensionLabel.BackColor = System.Drawing.Color.Transparent;
            workExtensionLabel.Name = "workExtensionLabel";
            this.helpProvider1.SetShowHelp(workExtensionLabel, ((bool)(resources.GetObject("workExtensionLabel.ShowHelp"))));
            // 
            // mobilePhoneLabel
            // 
            resources.ApplyResources(mobilePhoneLabel, "mobilePhoneLabel");
            mobilePhoneLabel.BackColor = System.Drawing.Color.Transparent;
            mobilePhoneLabel.Name = "mobilePhoneLabel";
            this.helpProvider1.SetShowHelp(mobilePhoneLabel, ((bool)(resources.GetObject("mobilePhoneLabel.ShowHelp"))));
            // 
            // faxNumberLabel
            // 
            resources.ApplyResources(faxNumberLabel, "faxNumberLabel");
            faxNumberLabel.BackColor = System.Drawing.Color.Transparent;
            faxNumberLabel.Name = "faxNumberLabel";
            this.helpProvider1.SetShowHelp(faxNumberLabel, ((bool)(resources.GetObject("faxNumberLabel.ShowHelp"))));
            // 
            // effectiveToLabel
            // 
            resources.ApplyResources(effectiveToLabel, "effectiveToLabel");
            effectiveToLabel.BackColor = System.Drawing.Color.Transparent;
            effectiveToLabel.Name = "effectiveToLabel";
            this.helpProvider1.SetShowHelp(effectiveToLabel, ((bool)(resources.GetObject("effectiveToLabel.ShowHelp"))));
            // 
            // languageCodeLabel
            // 
            resources.ApplyResources(languageCodeLabel, "languageCodeLabel");
            languageCodeLabel.BackColor = System.Drawing.Color.Transparent;
            languageCodeLabel.Name = "languageCodeLabel";
            this.helpProvider1.SetShowHelp(languageCodeLabel, ((bool)(resources.GetObject("languageCodeLabel.ShowHelp"))));
            // 
            // sexCodeLabel
            // 
            resources.ApplyResources(sexCodeLabel, "sexCodeLabel");
            sexCodeLabel.BackColor = System.Drawing.Color.Transparent;
            sexCodeLabel.Name = "sexCodeLabel";
            this.helpProvider1.SetShowHelp(sexCodeLabel, ((bool)(resources.GetObject("sexCodeLabel.ShowHelp"))));
            // 
            // addressTypeLabel
            // 
            resources.ApplyResources(addressTypeLabel, "addressTypeLabel");
            addressTypeLabel.BackColor = System.Drawing.Color.Transparent;
            addressTypeLabel.Name = "addressTypeLabel";
            this.helpProvider1.SetShowHelp(addressTypeLabel, ((bool)(resources.GetObject("addressTypeLabel.ShowHelp"))));
            // 
            // addressSourceCodeLabel
            // 
            resources.ApplyResources(addressSourceCodeLabel, "addressSourceCodeLabel");
            addressSourceCodeLabel.BackColor = System.Drawing.Color.Transparent;
            addressSourceCodeLabel.Name = "addressSourceCodeLabel";
            this.helpProvider1.SetShowHelp(addressSourceCodeLabel, ((bool)(resources.GetObject("addressSourceCodeLabel.ShowHelp"))));
            // 
            // suffixLabel
            // 
            resources.ApplyResources(suffixLabel, "suffixLabel");
            suffixLabel.BackColor = System.Drawing.Color.Transparent;
            suffixLabel.Name = "suffixLabel";
            this.helpProvider1.SetShowHelp(suffixLabel, ((bool)(resources.GetObject("suffixLabel.ShowHelp"))));
            // 
            // salutationLabel
            // 
            resources.ApplyResources(salutationLabel, "salutationLabel");
            salutationLabel.BackColor = System.Drawing.Color.Transparent;
            salutationLabel.Name = "salutationLabel";
            this.helpProvider1.SetShowHelp(salutationLabel, ((bool)(resources.GetObject("salutationLabel.ShowHelp"))));
            this.toolTip1.SetToolTip(salutationLabel, resources.GetString("salutationLabel.ToolTip"));
            // 
            // middleNameLabel
            // 
            resources.ApplyResources(middleNameLabel, "middleNameLabel");
            middleNameLabel.BackColor = System.Drawing.Color.Transparent;
            middleNameLabel.Name = "middleNameLabel";
            this.helpProvider1.SetShowHelp(middleNameLabel, ((bool)(resources.GetObject("middleNameLabel.ShowHelp"))));
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
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(774, 600), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.AppWorkspace;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            resources.ApplyResources(this.pnlAll, "pnlAll");
            this.pnlAll.Name = "pnlAll";
            this.helpProvider1.SetShowHelp(this.pnlAll, ((bool)(resources.GetObject("pnlAll.ShowHelp"))));
            // 
            // pnlAllContainer
            // 
            resources.ApplyResources(this.pnlAllContainer, "pnlAllContainer");
            this.pnlAllContainer.Controls.Add(this.uiTab4);
            this.pnlAllContainer.Controls.Add(this.uiTab2);
            this.pnlAllContainer.Controls.Add(this.uiTab1);
            this.pnlAllContainer.Controls.Add(this.uiTab3);
            this.pnlAllContainer.Controls.Add(this.uiTab5);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.helpProvider1.SetShowHelp(this.pnlAllContainer, ((bool)(resources.GetObject("pnlAllContainer.ShowHelp"))));
            // 
            // uiTab4
            // 
            resources.ApplyResources(this.uiTab4, "uiTab4");
            this.uiTab4.BackColor = System.Drawing.Color.Transparent;
            this.uiTab4.Name = "uiTab4";
            this.uiTab4.PanelFormatStyle.BackColor = System.Drawing.Color.White;
            this.uiTab4.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab4, ((bool)(resources.GetObject("uiTab4.ShowHelp"))));
            this.uiTab4.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage4});
            this.uiTab4.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab4.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab4.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab4.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab4.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab4.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab4.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab4.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab4.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage4
            // 
            this.uiTabPage4.Controls.Add(this.uiCheckBox1);
            this.uiTabPage4.Controls.Add(this.ucLanguageCodeMcc);
            this.uiTabPage4.Controls.Add(this.ucSexCodeMcc);
            this.uiTabPage4.Controls.Add(birthDateLabel);
            this.uiTabPage4.Controls.Add(sexCodeLabel);
            this.uiTabPage4.Controls.Add(languageCodeLabel);
            this.uiTabPage4.Controls.Add(ceasedToBeStudentDateLabel);
            this.uiTabPage4.Controls.Add(this.ceasedToBeStudentDateCalendarCombo);
            this.uiTabPage4.Controls.Add(this.birthDateCalendarCombo);
            resources.ApplyResources(this.uiTabPage4, "uiTabPage4");
            this.uiTabPage4.Name = "uiTabPage4";
            this.helpProvider1.SetShowHelp(this.uiTabPage4, ((bool)(resources.GetObject("uiTabPage4.ShowHelp"))));
            this.uiTabPage4.TabStop = true;
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.uiCheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.debtorBindingSource, "AddressNotCurrent", true));
            this.uiCheckBox1.ForeColor = System.Drawing.Color.Red;
            this.uiCheckBox1.Image = global::LawMate.Properties.Resources.warning_16x16;
            resources.ApplyResources(this.uiCheckBox1, "uiCheckBox1");
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.helpProvider1.SetShowHelp(this.uiCheckBox1, ((bool)(resources.GetObject("uiCheckBox1.ShowHelp"))));
            this.uiCheckBox1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
            // 
            // debtorBindingSource
            // 
            this.debtorBindingSource.DataMember = "Debtor";
            this.debtorBindingSource.DataSource = this.CLAS;
            this.debtorBindingSource.CurrentChanged += new System.EventHandler(this.debtorBindingSource_CurrentChanged);
            // 
            // CLAS
            // 
            this.CLAS.DataSetName = "CLAS";
            this.CLAS.EnforceConstraints = false;
            this.CLAS.Locale = new System.Globalization.CultureInfo("en-CA");
            this.CLAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.ExcludeSchema;
            // 
            // ucLanguageCodeMcc
            // 
            this.ucLanguageCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucLanguageCodeMcc.Column1 = "LanguageCode";
            resources.ApplyResources(this.ucLanguageCodeMcc, "ucLanguageCodeMcc");
            this.ucLanguageCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucLanguageCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.debtorBindingSource, "LanguageCode", true));
            this.ucLanguageCodeMcc.DataSource = null;
            this.ucLanguageCodeMcc.DDColumn1Visible = true;
            this.ucLanguageCodeMcc.DropDownColumn1Width = 100;
            this.ucLanguageCodeMcc.DropDownColumn2Width = 300;
            this.ucLanguageCodeMcc.Name = "ucLanguageCodeMcc";
            this.ucLanguageCodeMcc.ReadOnly = false;
            this.ucLanguageCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucLanguageCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucLanguageCodeMcc, ((bool)(resources.GetObject("ucLanguageCodeMcc.ShowHelp"))));
            this.ucLanguageCodeMcc.ValueMember = "LanguageCode";
            // 
            // ucSexCodeMcc
            // 
            this.ucSexCodeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucSexCodeMcc.Column1 = "SexCode";
            resources.ApplyResources(this.ucSexCodeMcc, "ucSexCodeMcc");
            this.ucSexCodeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucSexCodeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.debtorBindingSource, "SexCode", true));
            this.ucSexCodeMcc.DataSource = null;
            this.ucSexCodeMcc.DDColumn1Visible = true;
            this.ucSexCodeMcc.DropDownColumn1Width = 100;
            this.ucSexCodeMcc.DropDownColumn2Width = 300;
            this.ucSexCodeMcc.Name = "ucSexCodeMcc";
            this.ucSexCodeMcc.ReadOnly = false;
            this.ucSexCodeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucSexCodeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucSexCodeMcc, ((bool)(resources.GetObject("ucSexCodeMcc.ShowHelp"))));
            this.ucSexCodeMcc.ValueMember = "SexCode";
            // 
            // ceasedToBeStudentDateCalendarCombo
            // 
            resources.ApplyResources(this.ceasedToBeStudentDateCalendarCombo, "ceasedToBeStudentDateCalendarCombo");
            this.ceasedToBeStudentDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtorBindingSource, "CeasedToBeStudentDate", true));
            this.ceasedToBeStudentDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.ceasedToBeStudentDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.ceasedToBeStudentDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.ceasedToBeStudentDateCalendarCombo.MonthIncrement = 0;
            this.ceasedToBeStudentDateCalendarCombo.Name = "ceasedToBeStudentDateCalendarCombo";
            this.ceasedToBeStudentDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.ceasedToBeStudentDateCalendarCombo, ((bool)(resources.GetObject("ceasedToBeStudentDateCalendarCombo.ShowHelp"))));
            this.ceasedToBeStudentDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.ceasedToBeStudentDateCalendarCombo.YearIncrement = 0;
            // 
            // birthDateCalendarCombo
            // 
            resources.ApplyResources(this.birthDateCalendarCombo, "birthDateCalendarCombo");
            this.birthDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.debtorBindingSource, "BirthDate", true));
            this.birthDateCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.birthDateCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.birthDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.birthDateCalendarCombo.MonthIncrement = 0;
            this.birthDateCalendarCombo.Name = "birthDateCalendarCombo";
            this.birthDateCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.birthDateCalendarCombo, ((bool)(resources.GetObject("birthDateCalendarCombo.ShowHelp"))));
            this.birthDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.birthDateCalendarCombo.YearIncrement = 0;
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
            this.uiTabPage2.Controls.Add(this.notesEditBox);
            resources.ApplyResources(this.uiTabPage2, "uiTabPage2");
            this.uiTabPage2.Name = "uiTabPage2";
            this.helpProvider1.SetShowHelp(this.uiTabPage2, ((bool)(resources.GetObject("uiTabPage2.ShowHelp"))));
            this.uiTabPage2.TabStop = true;
            // 
            // notesEditBox
            // 
            this.notesEditBox.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.notesEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "Notes", true));
            resources.ApplyResources(this.notesEditBox, "notesEditBox");
            this.notesEditBox.Multiline = true;
            this.notesEditBox.Name = "notesEditBox";
            this.notesEditBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.helpProvider1.SetShowHelp(this.notesEditBox, ((bool)(resources.GetObject("notesEditBox.ShowHelp"))));
            this.notesEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
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
            this.uiTabPage1.Controls.Add(this.aKAGridEX);
            resources.ApplyResources(this.uiTabPage1, "uiTabPage1");
            this.uiTabPage1.Name = "uiTabPage1";
            this.helpProvider1.SetShowHelp(this.uiTabPage1, ((bool)(resources.GetObject("uiTabPage1.ShowHelp"))));
            this.uiTabPage1.TabStop = true;
            // 
            // aKAGridEX
            // 
            this.aKAGridEX.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.aKAGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.aKAGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            this.aKAGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.aKAGridEX.DataSource = this.aKABindingSource;
            aKAGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("aKAGridEX_DesignTimeLayout_Reference_0.Instance")));
            aKAGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            aKAGridEX_DesignTimeLayout_Reference_0});
            resources.ApplyResources(aKAGridEX_DesignTimeLayout, "aKAGridEX_DesignTimeLayout");
            this.aKAGridEX.DesignTimeLayout = aKAGridEX_DesignTimeLayout;
            resources.ApplyResources(this.aKAGridEX, "aKAGridEX");
            this.aKAGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.aKAGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.aKAGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.aKAGridEX.GroupByBoxVisible = false;
            this.aKAGridEX.Name = "aKAGridEX";
            this.aKAGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.helpProvider1.SetShowHelp(this.aKAGridEX, ((bool)(resources.GetObject("aKAGridEX.ShowHelp"))));
            this.aKAGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.aKAGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.aKAGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.aKAGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.aKAGridEX_ColumnButtonClick);
            // 
            // aKABindingSource
            // 
            this.aKABindingSource.CurrentChanged += new System.EventHandler(this.aKABindingSource_CurrentChanged);
            // 
            // uiTab3
            // 
            this.uiTab3.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.uiTab3, "uiTab3");
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
            this.uiTabPage3.Controls.Add(this.firstNameEditBox);
            this.uiTabPage3.Controls.Add(this.sINMaskedEditBox);
            this.uiTabPage3.Controls.Add(this.lastNameEditBox);
            this.uiTabPage3.Controls.Add(lastNameLabel);
            this.uiTabPage3.Controls.Add(this.suffixEditBox);
            this.uiTabPage3.Controls.Add(firstNameLabel);
            this.uiTabPage3.Controls.Add(this.middleNameEditBox);
            this.uiTabPage3.Controls.Add(sINLabel1);
            this.uiTabPage3.Controls.Add(this.salutationEditBox);
            this.uiTabPage3.Controls.Add(suffixLabel);
            this.uiTabPage3.Controls.Add(middleNameLabel);
            this.uiTabPage3.Controls.Add(salutationLabel);
            resources.ApplyResources(this.uiTabPage3, "uiTabPage3");
            this.uiTabPage3.Name = "uiTabPage3";
            this.helpProvider1.SetShowHelp(this.uiTabPage3, ((bool)(resources.GetObject("uiTabPage3.ShowHelp"))));
            this.uiTabPage3.TabStop = true;
            // 
            // firstNameEditBox
            // 
            this.firstNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "FirstName", true));
            resources.ApplyResources(this.firstNameEditBox, "firstNameEditBox");
            this.firstNameEditBox.Name = "firstNameEditBox";
            this.helpProvider1.SetShowHelp(this.firstNameEditBox, ((bool)(resources.GetObject("firstNameEditBox.ShowHelp"))));
            this.firstNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // sINMaskedEditBox
            // 
            this.sINMaskedEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "SIN", true));
            this.sINMaskedEditBox.IncludeLiterals = false;
            resources.ApplyResources(this.sINMaskedEditBox, "sINMaskedEditBox");
            this.sINMaskedEditBox.Mask = "### ### ###";
            this.sINMaskedEditBox.Name = "sINMaskedEditBox";
            this.sINMaskedEditBox.PromptChar = ' ';
            this.helpProvider1.SetShowHelp(this.sINMaskedEditBox, ((bool)(resources.GetObject("sINMaskedEditBox.ShowHelp"))));
            this.sINMaskedEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // lastNameEditBox
            // 
            this.lastNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "LastName", true));
            resources.ApplyResources(this.lastNameEditBox, "lastNameEditBox");
            this.lastNameEditBox.Name = "lastNameEditBox";
            this.helpProvider1.SetShowHelp(this.lastNameEditBox, ((bool)(resources.GetObject("lastNameEditBox.ShowHelp"))));
            this.lastNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // suffixEditBox
            // 
            this.suffixEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "Suffix", true));
            resources.ApplyResources(this.suffixEditBox, "suffixEditBox");
            this.suffixEditBox.Name = "suffixEditBox";
            this.helpProvider1.SetShowHelp(this.suffixEditBox, ((bool)(resources.GetObject("suffixEditBox.ShowHelp"))));
            this.suffixEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // middleNameEditBox
            // 
            this.middleNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "MiddleName", true));
            resources.ApplyResources(this.middleNameEditBox, "middleNameEditBox");
            this.middleNameEditBox.Name = "middleNameEditBox";
            this.helpProvider1.SetShowHelp(this.middleNameEditBox, ((bool)(resources.GetObject("middleNameEditBox.ShowHelp"))));
            this.middleNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // salutationEditBox
            // 
            this.salutationEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.debtorBindingSource, "Salutation", true));
            resources.ApplyResources(this.salutationEditBox, "salutationEditBox");
            this.salutationEditBox.Name = "salutationEditBox";
            this.helpProvider1.SetShowHelp(this.salutationEditBox, ((bool)(resources.GetObject("salutationEditBox.ShowHelp"))));
            this.salutationEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiTab5
            // 
            resources.ApplyResources(this.uiTab5, "uiTab5");
            this.uiTab5.BackColor = System.Drawing.Color.Transparent;
            this.uiTab5.Name = "uiTab5";
            this.uiTab5.ShowFocusRectangle = false;
            this.helpProvider1.SetShowHelp(this.uiTab5, ((bool)(resources.GetObject("uiTab5.ShowHelp"))));
            this.uiTab5.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.uiTabPage5});
            this.uiTab5.TabsStateStyles.DisabledFormatStyle.FontStrikeout = Janus.Windows.UI.TriState.True;
            this.uiTab5.TabsStateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiTab5.TabsStateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.uiTab5.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Blue;
            this.uiTab5.TabsStateStyles.PressedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab5.TabsStateStyles.SelectedFormatStyle.FontUnderline = Janus.Windows.UI.TriState.False;
            this.uiTab5.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Black;
            this.uiTab5.TabStripFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.uiTab5.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2010;
            // 
            // uiTabPage5
            // 
            this.uiTabPage5.Controls.Add(this.emailAddressEditBox);
            this.uiTabPage5.Controls.Add(this.addressGridEX);
            this.uiTabPage5.Controls.Add(this.ucAddressSourceMcc);
            this.uiTabPage5.Controls.Add(this.telephoneExtensionEditBox);
            this.uiTabPage5.Controls.Add(this.maskedEditBox4);
            this.uiTabPage5.Controls.Add(addressSourceCodeLabel);
            this.uiTabPage5.Controls.Add(emailAddressLabel);
            this.uiTabPage5.Controls.Add(mobilePhoneLabel);
            this.uiTabPage5.Controls.Add(faxNumberLabel);
            this.uiTabPage5.Controls.Add(this.ucAddressTypeMcc);
            this.uiTabPage5.Controls.Add(effectiveToLabel);
            this.uiTabPage5.Controls.Add(this.effectiveToCalendarCombo);
            this.uiTabPage5.Controls.Add(workPhoneLabel);
            this.uiTabPage5.Controls.Add(this.maskedEditBox3);
            this.uiTabPage5.Controls.Add(homePhoneLabel);
            this.uiTabPage5.Controls.Add(this.maskedEditBox2);
            this.uiTabPage5.Controls.Add(this.ucAddress1);
            this.uiTabPage5.Controls.Add(this.maskedEditBox1);
            this.uiTabPage5.Controls.Add(addressTypeLabel);
            this.uiTabPage5.Controls.Add(workExtensionLabel);
            resources.ApplyResources(this.uiTabPage5, "uiTabPage5");
            this.uiTabPage5.Name = "uiTabPage5";
            this.helpProvider1.SetShowHelp(this.uiTabPage5, ((bool)(resources.GetObject("uiTabPage5.ShowHelp"))));
            this.uiTabPage5.TabStop = true;
            // 
            // emailAddressEditBox
            // 
            this.emailAddressEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "EmailAddress", true));
            resources.ApplyResources(this.emailAddressEditBox, "emailAddressEditBox");
            this.emailAddressEditBox.Name = "emailAddressEditBox";
            this.helpProvider1.SetShowHelp(this.emailAddressEditBox, ((bool)(resources.GetObject("emailAddressEditBox.ShowHelp"))));
            this.emailAddressEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.CurrentChanged += new System.EventHandler(this.addressBindingSource_CurrentChanged);
            // 
            // addressGridEX
            // 
            this.addressGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.addressGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.LavenderBlush;
            resources.ApplyResources(this.addressGridEX, "addressGridEX");
            this.addressGridEX.DataSource = this.addressBindingSource;
            addressGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("addressGridEX_DesignTimeLayout_Reference_0.Instance")));
            addressGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("addressGridEX_DesignTimeLayout_Reference_1.Instance")));
            addressGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("addressGridEX_DesignTimeLayout_Reference_2.Instance")));
            addressGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("addressGridEX_DesignTimeLayout_Reference_3.Instance")));
            addressGridEX_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("addressGridEX_DesignTimeLayout_Reference_4.Instance")));
            addressGridEX_DesignTimeLayout_Reference_5.Instance = ((object)(resources.GetObject("addressGridEX_DesignTimeLayout_Reference_5.Instance")));
            addressGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            addressGridEX_DesignTimeLayout_Reference_0,
            addressGridEX_DesignTimeLayout_Reference_1,
            addressGridEX_DesignTimeLayout_Reference_2,
            addressGridEX_DesignTimeLayout_Reference_3,
            addressGridEX_DesignTimeLayout_Reference_4,
            addressGridEX_DesignTimeLayout_Reference_5});
            resources.ApplyResources(addressGridEX_DesignTimeLayout, "addressGridEX_DesignTimeLayout");
            this.addressGridEX.DesignTimeLayout = addressGridEX_DesignTimeLayout;
            this.addressGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.addressGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.addressGridEX.GroupByBoxVisible = false;
            this.addressGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.addressGridEX.Name = "addressGridEX";
            this.addressGridEX.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.helpProvider1.SetShowHelp(this.addressGridEX, ((bool)(resources.GetObject("addressGridEX.ShowHelp"))));
            this.addressGridEX.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.addressGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            this.addressGridEX.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            this.addressGridEX.LoadingRow += new Janus.Windows.GridEX.RowLoadEventHandler(this.addressGridEX_LoadingRow);
            this.addressGridEX.ColumnButtonClick += new Janus.Windows.GridEX.ColumnActionEventHandler(this.addressGridEX_ColumnButtonClick);
            this.addressGridEX.CurrentCellChanging += new Janus.Windows.GridEX.CurrentCellChangingEventHandler(this.addressGridEX_CurrentCellChanging);
            // 
            // ucAddressSourceMcc
            // 
            this.ucAddressSourceMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucAddressSourceMcc.Column1 = "AddressSourceCode";
            resources.ApplyResources(this.ucAddressSourceMcc, "ucAddressSourceMcc");
            this.ucAddressSourceMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucAddressSourceMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.addressBindingSource, "AddressSourceCode", true));
            this.ucAddressSourceMcc.DataSource = null;
            this.ucAddressSourceMcc.DDColumn1Visible = true;
            this.ucAddressSourceMcc.DropDownColumn1Width = 100;
            this.ucAddressSourceMcc.DropDownColumn2Width = 300;
            this.ucAddressSourceMcc.Name = "ucAddressSourceMcc";
            this.ucAddressSourceMcc.ReadOnly = false;
            this.ucAddressSourceMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucAddressSourceMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucAddressSourceMcc, ((bool)(resources.GetObject("ucAddressSourceMcc.ShowHelp"))));
            this.ucAddressSourceMcc.ValueMember = "AddressSourceCode";
            // 
            // telephoneExtensionEditBox
            // 
            this.telephoneExtensionEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "WorkExtension", true));
            resources.ApplyResources(this.telephoneExtensionEditBox, "telephoneExtensionEditBox");
            this.telephoneExtensionEditBox.Name = "telephoneExtensionEditBox";
            this.helpProvider1.SetShowHelp(this.telephoneExtensionEditBox, ((bool)(resources.GetObject("telephoneExtensionEditBox.ShowHelp"))));
            this.telephoneExtensionEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox4
            // 
            this.maskedEditBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "FaxNumber", true));
            resources.ApplyResources(this.maskedEditBox4, "maskedEditBox4");
            this.maskedEditBox4.Mask = "(###) ###-####";
            this.maskedEditBox4.Name = "maskedEditBox4";
            this.helpProvider1.SetShowHelp(this.maskedEditBox4, ((bool)(resources.GetObject("maskedEditBox4.ShowHelp"))));
            this.maskedEditBox4.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucAddressTypeMcc
            // 
            this.ucAddressTypeMcc.BackColor = System.Drawing.Color.Transparent;
            this.ucAddressTypeMcc.Column1 = "AddressType";
            resources.ApplyResources(this.ucAddressTypeMcc, "ucAddressTypeMcc");
            this.ucAddressTypeMcc.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucAddressTypeMcc.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.addressBindingSource, "AddressType", true));
            this.ucAddressTypeMcc.DataSource = null;
            this.ucAddressTypeMcc.DDColumn1Visible = true;
            this.ucAddressTypeMcc.DropDownColumn1Width = 100;
            this.ucAddressTypeMcc.DropDownColumn2Width = 300;
            this.ucAddressTypeMcc.Name = "ucAddressTypeMcc";
            this.ucAddressTypeMcc.ReadOnly = false;
            this.ucAddressTypeMcc.ReqColor = System.Drawing.SystemColors.Window;
            this.ucAddressTypeMcc.SelectedValue = null;
            this.helpProvider1.SetShowHelp(this.ucAddressTypeMcc, ((bool)(resources.GetObject("ucAddressTypeMcc.ShowHelp"))));
            this.ucAddressTypeMcc.ValueMember = "AddressType";
            // 
            // effectiveToCalendarCombo
            // 
            resources.ApplyResources(this.effectiveToCalendarCombo, "effectiveToCalendarCombo");
            this.effectiveToCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.addressBindingSource, "EffectiveTo", true));
            this.effectiveToCalendarCombo.DayIncrement = 0;
            // 
            // 
            // 
            this.effectiveToCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2006, 11, 1, 0, 0, 0, 0);
            this.effectiveToCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.effectiveToCalendarCombo.MonthIncrement = 0;
            this.effectiveToCalendarCombo.Name = "effectiveToCalendarCombo";
            this.effectiveToCalendarCombo.Nullable = true;
            this.helpProvider1.SetShowHelp(this.effectiveToCalendarCombo, ((bool)(resources.GetObject("effectiveToCalendarCombo.ShowHelp"))));
            this.effectiveToCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.effectiveToCalendarCombo.YearIncrement = 0;
            // 
            // maskedEditBox3
            // 
            this.maskedEditBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "MobilePhone", true));
            resources.ApplyResources(this.maskedEditBox3, "maskedEditBox3");
            this.maskedEditBox3.Mask = "(###) ###-####";
            this.maskedEditBox3.Name = "maskedEditBox3";
            this.helpProvider1.SetShowHelp(this.maskedEditBox3, ((bool)(resources.GetObject("maskedEditBox3.ShowHelp"))));
            this.maskedEditBox3.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // maskedEditBox2
            // 
            this.maskedEditBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "WorkPhone", true));
            resources.ApplyResources(this.maskedEditBox2, "maskedEditBox2");
            this.maskedEditBox2.Mask = "(###) ###-####";
            this.maskedEditBox2.Name = "maskedEditBox2";
            this.helpProvider1.SetShowHelp(this.maskedEditBox2, ((bool)(resources.GetObject("maskedEditBox2.ShowHelp"))));
            this.maskedEditBox2.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // ucAddress1
            // 
            this.ucAddress1.BackColor = System.Drawing.Color.Transparent;
            this.ucAddress1.ColumnTwoLeftPositionOffset = 0;
            this.ucAddress1.FM = null;
            resources.ApplyResources(this.ucAddress1, "ucAddress1");
            this.ucAddress1.IsReadOnly = false;
            this.ucAddress1.Name = "ucAddress1";
            this.ucAddress1.ReqColor = System.Drawing.SystemColors.Window;
            this.helpProvider1.SetShowHelp(this.ucAddress1, ((bool)(resources.GetObject("ucAddress1.ShowHelp"))));
            // 
            // maskedEditBox1
            // 
            this.maskedEditBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.addressBindingSource, "HomePhone", true));
            resources.ApplyResources(this.maskedEditBox1, "maskedEditBox1");
            this.maskedEditBox1.Mask = "(###) ###-####";
            this.maskedEditBox1.Name = "maskedEditBox1";
            this.helpProvider1.SetShowHelp(this.maskedEditBox1, ((bool)(resources.GetObject("maskedEditBox1.ShowHelp"))));
            this.maskedEditBox1.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            resources.ApplyResources(this.uiCommandManager1, "uiCommandManager1");
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar2,
            this.uiCommandBar3});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave,
            this.tsScreenTitle,
            this.tsEditmode,
            this.tsAudit,
            this.cmdFile,
            this.cmdEdit,
            this.cmdTools});
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
            // uiCommandBar2
            // 
            this.uiCommandBar2.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar2.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu;
            this.uiCommandBar2.CommandManager = this.uiCommandManager1;
            this.uiCommandBar2.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdFile1,
            this.cmdEdit1});
            resources.ApplyResources(this.uiCommandBar2, "uiCommandBar2");
            this.uiCommandBar2.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar2.MergeRowOrder = 1;
            this.uiCommandBar2.Name = "uiCommandBar2";
            this.uiCommandBar2.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
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
            // uiCommandBar3
            // 
            this.uiCommandBar3.AllowClose = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.AllowCustomize = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar3.CommandManager = this.uiCommandManager1;
            this.uiCommandBar3.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsEditmode2,
            this.tsScreenTitle2,
            this.Separator2,
            this.tsSave3,
            this.Separator4,
            this.tsAudit1});
            this.uiCommandBar3.CommandsStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            resources.ApplyResources(this.uiCommandBar3, "uiCommandBar3");
            this.uiCommandBar3.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar3.MergeRowOrder = 2;
            this.uiCommandBar3.Name = "uiCommandBar3";
            this.uiCommandBar3.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.helpProvider1.SetShowHelp(this.uiCommandBar3, ((bool)(resources.GetObject("uiCommandBar3.ShowHelp"))));
            // 
            // tsEditmode2
            // 
            resources.ApplyResources(this.tsEditmode2, "tsEditmode2");
            this.tsEditmode2.Name = "tsEditmode2";
            // 
            // tsScreenTitle2
            // 
            this.tsScreenTitle2.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Text;
            resources.ApplyResources(this.tsScreenTitle2, "tsScreenTitle2");
            this.tsScreenTitle2.Name = "tsScreenTitle2";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator2, "Separator2");
            this.Separator2.Name = "Separator2";
            // 
            // tsSave3
            // 
            resources.ApplyResources(this.tsSave3, "tsSave3");
            this.tsSave3.Name = "tsSave3";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            resources.ApplyResources(this.Separator4, "Separator4");
            this.Separator4.Name = "Separator4";
            // 
            // tsAudit1
            // 
            resources.ApplyResources(this.tsAudit1, "tsAudit1");
            this.tsAudit1.Name = "tsAudit1";
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
            this.tsScreenTitle.StateStyles.FormatStyle.FontSize = 8F;
            this.tsScreenTitle.TextAlignment = Janus.Windows.UI.CommandBars.ContentAlignment.MiddleCenter;
            // 
            // tsEditmode
            // 
            this.tsEditmode.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.Image;
            this.tsEditmode.CommandType = Janus.Windows.UI.CommandBars.CommandType.Label;
            resources.ApplyResources(this.tsEditmode, "tsEditmode");
            this.tsEditmode.Name = "tsEditmode";
            this.tsEditmode.ShowInCustomizeDialog = false;
            this.tsEditmode.StateStyles.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.tsEditmode.StateStyles.FormatStyle.FontName = "arial";
            this.tsEditmode.StateStyles.FormatStyle.FontUnderline = Janus.Windows.UI.TriState.True;
            this.tsEditmode.TextImageRelation = Janus.Windows.UI.CommandBars.TextImageRelation.TextBeforeImage;
            // 
            // tsAudit
            // 
            resources.ApplyResources(this.tsAudit, "tsAudit");
            this.tsAudit.Name = "tsAudit";
            // 
            // cmdFile
            // 
            this.cmdFile.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.tsSave2});
            resources.ApplyResources(this.cmdFile, "cmdFile");
            this.cmdFile.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
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
            this.cmdEdit.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdEdit.Name = "cmdEdit";
            // 
            // cmdTools
            // 
            resources.ApplyResources(this.cmdTools, "cmdTools");
            this.cmdTools.MergeType = Janus.Windows.UI.CommandBars.CommandMergeType.MergeItems;
            this.cmdTools.Name = "cmdTools";
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
            this.uiCommandBar3});
            this.TopRebar1.CommandManager = this.uiCommandManager1;
            this.TopRebar1.Controls.Add(this.uiCommandBar2);
            this.TopRebar1.Controls.Add(this.uiCommandBar3);
            resources.ApplyResources(this.TopRebar1, "TopRebar1");
            this.TopRebar1.Name = "TopRebar1";
            this.helpProvider1.SetShowHelp(this.TopRebar1, ((bool)(resources.GetObject("TopRebar1.ShowHelp"))));
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.DataSource = this.addressBindingSource;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            this.errorProvider3.DataSource = this.aKABindingSource;
            // 
            // janusSuperTip1
            // 
            this.janusSuperTip1.AutoPopDelay = 2000;
            this.janusSuperTip1.BodyWidth = 380;
            this.janusSuperTip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.janusSuperTip1.ImageList = null;
            this.janusSuperTip1.InitialDelay = 200;
            this.janusSuperTip1.ShowAlways = true;
            // 
            // ucOpponent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "ucOpponent";
            this.helpProvider1.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ucOpponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiTab4)).EndInit();
            this.uiTab4.ResumeLayout(false);
            this.uiTabPage4.ResumeLayout(false);
            this.uiTabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debtorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLAS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab2)).EndInit();
            this.uiTab2.ResumeLayout(false);
            this.uiTabPage2.ResumeLayout(false);
            this.uiTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab1)).EndInit();
            this.uiTab1.ResumeLayout(false);
            this.uiTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aKAGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aKABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab3)).EndInit();
            this.uiTab3.ResumeLayout(false);
            this.uiTabPage3.ResumeLayout(false);
            this.uiTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiTab5)).EndInit();
            this.uiTab5.ResumeLayout(false);
            this.uiTabPage5.ResumeLayout(false);
            this.uiTabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private System.Windows.Forms.BindingSource debtorBindingSource;
        private lmDatasets.CLAS CLAS;
        private Janus.Windows.CalendarCombo.CalendarCombo ceasedToBeStudentDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo birthDateCalendarCombo;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private Janus.Windows.GridEX.GridEX aKAGridEX;
        private System.Windows.Forms.BindingSource aKABindingSource;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox sINMaskedEditBox;
        private Janus.Windows.GridEX.GridEX addressGridEX;
        private Janus.Windows.CalendarCombo.CalendarCombo effectiveToCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanel pnlAll;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlAllContainer;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsSave;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode;
        private UserControls.ucAddress ucAddress1;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox1;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox4;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox3;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox2;
        private Janus.Windows.Common.JanusSuperTip janusSuperTip1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar2;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar3;
        private Janus.Windows.UI.CommandBars.UICommand tsEditmode2;
        private Janus.Windows.UI.CommandBars.UICommand tsScreenTitle2;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand tsSave3;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile;
        private Janus.Windows.UI.CommandBars.UICommand tsSave2;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit;
        private Janus.Windows.UI.CommandBars.UICommand cmdTools;
        private Janus.Windows.UI.CommandBars.UICommand cmdFile1;
        private Janus.Windows.UI.CommandBars.UICommand cmdEdit1;
        private UserControls.ucMultiDropDown ucSexCodeMcc;
        private UserControls.ucMultiDropDown ucLanguageCodeMcc;
        private UserControls.ucMultiDropDown ucAddressTypeMcc;
        private UserControls.ucMultiDropDown ucAddressSourceMcc;
        private Janus.Windows.GridEX.EditControls.EditBox firstNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox lastNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox suffixEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox middleNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox salutationEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox notesEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox emailAddressEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox telephoneExtensionEditBox;
        private Janus.Windows.UI.CommandBars.UICommand tsAudit1;
        private Janus.Windows.UI.Tab.UITab uiTab5;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage5;
        private Janus.Windows.UI.Tab.UITab uiTab4;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage4;
        private Janus.Windows.UI.Tab.UITab uiTab2;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage2;
        private Janus.Windows.UI.Tab.UITab uiTab1;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage1;
        private Janus.Windows.UI.Tab.UITab uiTab3;
        private Janus.Windows.UI.Tab.UITabPage uiTabPage3;
        private Janus.Windows.EditControls.UICheckBox uiCheckBox1;
    }
}
