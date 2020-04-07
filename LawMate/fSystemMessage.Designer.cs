namespace LawMate.Admin
{
    partial class fSystemMessage
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
            Janus.Windows.GridEX.GridEXLayout msgGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSystemMessage));
            System.Windows.Forms.Label msgCodeLabel;
            System.Windows.Forms.Label msgEngLabel;
            System.Windows.Forms.Label msgFreLabel;
            System.Windows.Forms.Label startDateLabel;
            System.Windows.Forms.Label endDateLabel;
            System.Windows.Forms.Label entryUserLabel;
            System.Windows.Forms.Label entryDateLabel;
            System.Windows.Forms.Label updateUserLabel;
            System.Windows.Forms.Label updateDateLabel;
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlAll = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlAllContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.appDB = new lmDatasets.appDB();
            this.msgBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.msgGridEX = new Janus.Windows.GridEX.GridEX();
            this.msgCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.msgEngEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.msgFreEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.startDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.endDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.entryUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.entryDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.updateUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.updateDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            msgCodeLabel = new System.Windows.Forms.Label();
            msgEngLabel = new System.Windows.Forms.Label();
            msgFreLabel = new System.Windows.Forms.Label();
            startDateLabel = new System.Windows.Forms.Label();
            endDateLabel = new System.Windows.Forms.Label();
            entryUserLabel = new System.Windows.Forms.Label();
            entryDateLabel = new System.Windows.Forms.Label();
            updateUserLabel = new System.Windows.Forms.Label();
            updateDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).BeginInit();
            this.pnlAll.SuspendLayout();
            this.pnlAllContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgGridEX)).BeginInit();
            this.SuspendLayout();
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
            this.pnlAll.Id = new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c");
            this.uiPanelManager1.Panels.Add(this.pnlAll);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(830, 481), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("de84ef89-599a-4164-9a35-303ae0665a6c"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a200b905-bcc2-422b-9796-7be7a703ab66"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlAll
            // 
            this.pnlAll.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.pnlAll.InnerContainer = this.pnlAllContainer;
            this.pnlAll.Location = new System.Drawing.Point(0, 28);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(830, 481);
            this.pnlAll.TabIndex = 4;
            this.pnlAll.Text = "Personnel";
            // 
            // pnlAllContainer
            // 
            this.pnlAllContainer.Controls.Add(msgCodeLabel);
            this.pnlAllContainer.Controls.Add(this.msgCodeEditBox);
            this.pnlAllContainer.Controls.Add(msgEngLabel);
            this.pnlAllContainer.Controls.Add(this.msgEngEditBox);
            this.pnlAllContainer.Controls.Add(msgFreLabel);
            this.pnlAllContainer.Controls.Add(this.msgFreEditBox);
            this.pnlAllContainer.Controls.Add(startDateLabel);
            this.pnlAllContainer.Controls.Add(this.startDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(endDateLabel);
            this.pnlAllContainer.Controls.Add(this.endDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(entryUserLabel);
            this.pnlAllContainer.Controls.Add(this.entryUserEditBox);
            this.pnlAllContainer.Controls.Add(entryDateLabel);
            this.pnlAllContainer.Controls.Add(this.entryDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(updateUserLabel);
            this.pnlAllContainer.Controls.Add(this.updateUserEditBox);
            this.pnlAllContainer.Controls.Add(updateDateLabel);
            this.pnlAllContainer.Controls.Add(this.updateDateCalendarCombo);
            this.pnlAllContainer.Controls.Add(this.msgGridEX);
            this.pnlAllContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlAllContainer.Name = "pnlAllContainer";
            this.pnlAllContainer.Size = new System.Drawing.Size(830, 481);
            this.pnlAllContainer.TabIndex = 0;
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
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
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
            this.TopRebar1.Size = new System.Drawing.Size(830, 28);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 0);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 0);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 0);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(0, 0);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 0);
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
            this.uiCommandBar1.Size = new System.Drawing.Size(830, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // appDB
            // 
            this.appDB.DataSetName = "appDB";
            this.appDB.EnforceConstraints = false;
            this.appDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // msgBindingSource
            // 
            this.msgBindingSource.DataMember = "Msg";
            this.msgBindingSource.DataSource = this.appDB;
            // 
            // msgGridEX
            // 
            this.msgGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.msgGridEX.DataSource = this.msgBindingSource;
            msgGridEX_DesignTimeLayout.LayoutString = resources.GetString("msgGridEX_DesignTimeLayout.LayoutString");
            this.msgGridEX.DesignTimeLayout = msgGridEX_DesignTimeLayout;
            this.msgGridEX.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
            this.msgGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.msgGridEX.GroupByBoxVisible = false;
            this.msgGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.msgGridEX.Location = new System.Drawing.Point(12, 6);
            this.msgGridEX.Name = "msgGridEX";
            this.msgGridEX.Size = new System.Drawing.Size(788, 136);
            this.msgGridEX.TabIndex = 0;
            this.msgGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // msgCodeLabel
            // 
            msgCodeLabel.AutoSize = true;
            msgCodeLabel.BackColor = System.Drawing.Color.Transparent;
            msgCodeLabel.Location = new System.Drawing.Point(16, 165);
            msgCodeLabel.Name = "msgCodeLabel";
            msgCodeLabel.Size = new System.Drawing.Size(119, 13);
            msgCodeLabel.TabIndex = 1;
            msgCodeLabel.Text = "System Message Code:";
            // 
            // msgCodeEditBox
            // 
            this.msgCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.msgBindingSource, "MsgCode", true));
            this.msgCodeEditBox.Location = new System.Drawing.Point(141, 160);
            this.msgCodeEditBox.Name = "msgCodeEditBox";
            this.msgCodeEditBox.Size = new System.Drawing.Size(115, 21);
            this.msgCodeEditBox.TabIndex = 2;
            this.msgCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // msgEngLabel
            // 
            msgEngLabel.AutoSize = true;
            msgEngLabel.BackColor = System.Drawing.Color.Transparent;
            msgEngLabel.Location = new System.Drawing.Point(16, 201);
            msgEngLabel.Name = "msgEngLabel";
            msgEngLabel.Size = new System.Drawing.Size(97, 13);
            msgEngLabel.TabIndex = 3;
            msgEngLabel.Text = "Message (English):";
            // 
            // msgEngEditBox
            // 
            this.msgEngEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.msgBindingSource, "MsgEng", true));
            this.msgEngEditBox.Location = new System.Drawing.Point(141, 198);
            this.msgEngEditBox.Multiline = true;
            this.msgEngEditBox.Name = "msgEngEditBox";
            this.msgEngEditBox.Size = new System.Drawing.Size(566, 69);
            this.msgEngEditBox.TabIndex = 4;
            this.msgEngEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // msgFreLabel
            // 
            msgFreLabel.AutoSize = true;
            msgFreLabel.BackColor = System.Drawing.Color.Transparent;
            msgFreLabel.Location = new System.Drawing.Point(16, 276);
            msgFreLabel.Name = "msgFreLabel";
            msgFreLabel.Size = new System.Drawing.Size(97, 13);
            msgFreLabel.TabIndex = 5;
            msgFreLabel.Text = "Message (French):";
            // 
            // msgFreEditBox
            // 
            this.msgFreEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.msgBindingSource, "MsgFre", true));
            this.msgFreEditBox.Location = new System.Drawing.Point(141, 273);
            this.msgFreEditBox.Multiline = true;
            this.msgFreEditBox.Name = "msgFreEditBox";
            this.msgFreEditBox.Size = new System.Drawing.Size(566, 69);
            this.msgFreEditBox.TabIndex = 6;
            this.msgFreEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // startDateLabel
            // 
            startDateLabel.AutoSize = true;
            startDateLabel.BackColor = System.Drawing.Color.Transparent;
            startDateLabel.Location = new System.Drawing.Point(351, 165);
            startDateLabel.Name = "startDateLabel";
            startDateLabel.Size = new System.Drawing.Size(61, 13);
            startDateLabel.TabIndex = 7;
            startDateLabel.Text = "Start Date:";
            // 
            // startDateCalendarCombo
            // 
            this.startDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.startDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.msgBindingSource, "StartDate", true));
            this.startDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.startDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.startDateCalendarCombo.Location = new System.Drawing.Point(418, 160);
            this.startDateCalendarCombo.Name = "startDateCalendarCombo";
            this.startDateCalendarCombo.Size = new System.Drawing.Size(88, 21);
            this.startDateCalendarCombo.TabIndex = 8;
            this.startDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // endDateLabel
            // 
            endDateLabel.AutoSize = true;
            endDateLabel.BackColor = System.Drawing.Color.Transparent;
            endDateLabel.Location = new System.Drawing.Point(555, 165);
            endDateLabel.Name = "endDateLabel";
            endDateLabel.Size = new System.Drawing.Size(55, 13);
            endDateLabel.TabIndex = 9;
            endDateLabel.Text = "End Date:";
            // 
            // endDateCalendarCombo
            // 
            this.endDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.endDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.msgBindingSource, "EndDate", true));
            this.endDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.endDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.endDateCalendarCombo.Location = new System.Drawing.Point(616, 160);
            this.endDateCalendarCombo.Name = "endDateCalendarCombo";
            this.endDateCalendarCombo.Size = new System.Drawing.Size(91, 21);
            this.endDateCalendarCombo.TabIndex = 10;
            this.endDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // entryUserLabel
            // 
            entryUserLabel.AutoSize = true;
            entryUserLabel.BackColor = System.Drawing.Color.Transparent;
            entryUserLabel.Location = new System.Drawing.Point(73, 378);
            entryUserLabel.Name = "entryUserLabel";
            entryUserLabel.Size = new System.Drawing.Size(62, 13);
            entryUserLabel.TabIndex = 11;
            entryUserLabel.Text = "Entry User:";
            // 
            // entryUserEditBox
            // 
            this.entryUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.entryUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.msgBindingSource, "entryUser", true));
            this.entryUserEditBox.Image = ((System.Drawing.Image)(resources.GetObject("entryUserEditBox.Image")));
            this.entryUserEditBox.Location = new System.Drawing.Point(141, 373);
            this.entryUserEditBox.Name = "entryUserEditBox";
            this.entryUserEditBox.ReadOnly = true;
            this.entryUserEditBox.Size = new System.Drawing.Size(200, 22);
            this.entryUserEditBox.TabIndex = 12;
            this.entryUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // entryDateLabel
            // 
            entryDateLabel.AutoSize = true;
            entryDateLabel.BackColor = System.Drawing.Color.Transparent;
            entryDateLabel.Location = new System.Drawing.Point(73, 404);
            entryDateLabel.Name = "entryDateLabel";
            entryDateLabel.Size = new System.Drawing.Size(63, 13);
            entryDateLabel.TabIndex = 13;
            entryDateLabel.Text = "Entry Date:";
            // 
            // entryDateCalendarCombo
            // 
            this.entryDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.entryDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.entryDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.msgBindingSource, "entryDate", true));
            this.entryDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.entryDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.entryDateCalendarCombo.Location = new System.Drawing.Point(141, 399);
            this.entryDateCalendarCombo.Name = "entryDateCalendarCombo";
            this.entryDateCalendarCombo.ReadOnly = true;
            this.entryDateCalendarCombo.Size = new System.Drawing.Size(91, 21);
            this.entryDateCalendarCombo.TabIndex = 14;
            this.entryDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // updateUserLabel
            // 
            updateUserLabel.AutoSize = true;
            updateUserLabel.BackColor = System.Drawing.Color.Transparent;
            updateUserLabel.Location = new System.Drawing.Point(431, 378);
            updateUserLabel.Name = "updateUserLabel";
            updateUserLabel.Size = new System.Drawing.Size(71, 13);
            updateUserLabel.TabIndex = 15;
            updateUserLabel.Text = "Update User:";
            // 
            // updateUserEditBox
            // 
            this.updateUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.updateUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.msgBindingSource, "updateUser", true));
            this.updateUserEditBox.Image = ((System.Drawing.Image)(resources.GetObject("updateUserEditBox.Image")));
            this.updateUserEditBox.Location = new System.Drawing.Point(507, 373);
            this.updateUserEditBox.Name = "updateUserEditBox";
            this.updateUserEditBox.ReadOnly = true;
            this.updateUserEditBox.Size = new System.Drawing.Size(200, 22);
            this.updateUserEditBox.TabIndex = 16;
            this.updateUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // updateDateLabel
            // 
            updateDateLabel.AutoSize = true;
            updateDateLabel.BackColor = System.Drawing.Color.Transparent;
            updateDateLabel.Location = new System.Drawing.Point(431, 404);
            updateDateLabel.Name = "updateDateLabel";
            updateDateLabel.Size = new System.Drawing.Size(72, 13);
            updateDateLabel.TabIndex = 17;
            updateDateLabel.Text = "Update Date:";
            // 
            // updateDateCalendarCombo
            // 
            this.updateDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.updateDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.updateDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.msgBindingSource, "updateDate", true));
            this.updateDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.updateDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            this.updateDateCalendarCombo.Location = new System.Drawing.Point(507, 399);
            this.updateDateCalendarCombo.Name = "updateDateCalendarCombo";
            this.updateDateCalendarCombo.ReadOnly = true;
            this.updateDateCalendarCombo.Size = new System.Drawing.Size(91, 21);
            this.updateDateCalendarCombo.TabIndex = 18;
            this.updateDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
            // 
            // fSystemMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.pnlAll);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fSystemMessage";
            this.Text = "System Messages";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlAll)).EndInit();
            this.pnlAll.ResumeLayout(false);
            this.pnlAllContainer.ResumeLayout(false);
            this.pnlAllContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgGridEX)).EndInit();
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
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.GridEX.GridEX msgGridEX;
        private System.Windows.Forms.BindingSource msgBindingSource;
        private lmDatasets.appDB appDB;
        private Janus.Windows.GridEX.EditControls.EditBox msgCodeEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox msgEngEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox msgFreEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo startDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo endDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox entryUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo entryDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox updateUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo updateDateCalendarCombo;
    }
}
