 namespace LawMate.Admin
{
    partial class fBatch
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
            System.Windows.Forms.Label batchIDLabel1;
            System.Windows.Forms.Label officerIDLabel1;
            System.Windows.Forms.Label officeCodeLabel1;
            System.Windows.Forms.Label batchDateLabel1;
            System.Windows.Forms.Label priorityLabel1;
            System.Windows.Forms.Label runAfterDateLabel1;
            System.Windows.Forms.Label jobNameLabel1;
            System.Windows.Forms.Label parametersLabel1;
            System.Windows.Forms.Label startRunDateLabel1;
            System.Windows.Forms.Label endRunDateLabel1;
            System.Windows.Forms.Label statusLabel1;
            System.Windows.Forms.Label messageLabel1;
            System.Windows.Forms.Label outputFileLabel1;
            System.Windows.Forms.Label entryUserLabel;
            System.Windows.Forms.Label entryDateLabel;
            System.Windows.Forms.Label updateUserLabel;
            System.Windows.Forms.Label updateDateLabel;
            System.Windows.Forms.Label userNameLabel1;
            Janus.Windows.GridEX.GridEXLayout batchGridEX_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            Janus.Windows.Common.Layouts.JanusLayoutReference batchGridEX_DesignTimeLayout_Reference_0 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item0.Image");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBatch));
            Janus.Windows.Common.Layouts.JanusLayoutReference batchGridEX_DesignTimeLayout_Reference_1 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item1.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference batchGridEX_DesignTimeLayout_Reference_2 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item2.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference batchGridEX_DesignTimeLayout_Reference_3 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item3.Image");
            Janus.Windows.Common.Layouts.JanusLayoutReference batchGridEX_DesignTimeLayout_Reference_4 = new Janus.Windows.Common.Layouts.JanusLayoutReference("GridEXLayoutData.RootTable.Columns.Column0.ValueList.Item4.Image");
            this.batchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.atriumDB = new lmDatasets.appDB();
            this.batchGridEX = new Janus.Windows.GridEX.GridEX();
            this.uiCommandManager1 = new Janus.Windows.UI.CommandBars.UICommandManager(this.components);
            this.BottomRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiCommandBar1 = new Janus.Windows.UI.CommandBars.UICommandBar();
            this.cmdSave1 = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.Separator2 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdCancel1 = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.Separator3 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdDelete1 = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.Separator4 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdRun1 = new Janus.Windows.UI.CommandBars.UICommand("cmdRun");
            this.Separator1 = new Janus.Windows.UI.CommandBars.UICommand("Separator");
            this.cmdNewSQL1 = new Janus.Windows.UI.CommandBars.UICommand("cmdNewSQL");
            this.cmdSave = new Janus.Windows.UI.CommandBars.UICommand("cmdSave");
            this.cmdCancel = new Janus.Windows.UI.CommandBars.UICommand("cmdCancel");
            this.cmdDelete = new Janus.Windows.UI.CommandBars.UICommand("cmdDelete");
            this.cmdRun = new Janus.Windows.UI.CommandBars.UICommand("cmdRun");
            this.cmdNewSQL = new Janus.Windows.UI.CommandBars.UICommand("cmdNewSQL");
            this.LeftRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.RightRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.TopRebar1 = new Janus.Windows.UI.CommandBars.UIRebar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.pnlTop = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlTopContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.pnlDetail = new Janus.Windows.UI.Dock.UIPanel();
            this.pnlDetailContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.ebPriority = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.cbStatus = new Janus.Windows.EditControls.UIComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ucMultiDropDown1 = new LawMate.UserControls.ucMultiDropDown();
            this.batchIDEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.officeCodeEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.userNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.batchDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.runAfterDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.jobNameEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.parametersEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.startRunDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.endRunDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.completedUICheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.messageEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.outputFileEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.entryUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.entryDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.updateUserEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.updateDateCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            batchIDLabel1 = new System.Windows.Forms.Label();
            officerIDLabel1 = new System.Windows.Forms.Label();
            officeCodeLabel1 = new System.Windows.Forms.Label();
            batchDateLabel1 = new System.Windows.Forms.Label();
            priorityLabel1 = new System.Windows.Forms.Label();
            runAfterDateLabel1 = new System.Windows.Forms.Label();
            jobNameLabel1 = new System.Windows.Forms.Label();
            parametersLabel1 = new System.Windows.Forms.Label();
            startRunDateLabel1 = new System.Windows.Forms.Label();
            endRunDateLabel1 = new System.Windows.Forms.Label();
            statusLabel1 = new System.Windows.Forms.Label();
            messageLabel1 = new System.Windows.Forms.Label();
            outputFileLabel1 = new System.Windows.Forms.Label();
            entryUserLabel = new System.Windows.Forms.Label();
            entryDateLabel = new System.Windows.Forms.Label();
            updateUserLabel = new System.Windows.Forms.Label();
            updateDateLabel = new System.Windows.Forms.Label();
            userNameLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).BeginInit();
            this.TopRebar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlTopContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlDetailContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // batchIDLabel1
            // 
            batchIDLabel1.AutoSize = true;
            batchIDLabel1.BackColor = System.Drawing.Color.Transparent;
            batchIDLabel1.Location = new System.Drawing.Point(440, 19);
            batchIDLabel1.Name = "batchIDLabel1";
            batchIDLabel1.Size = new System.Drawing.Size(52, 13);
            batchIDLabel1.TabIndex = 1;
            batchIDLabel1.Text = "Batch ID:";
            // 
            // officerIDLabel1
            // 
            officerIDLabel1.AutoSize = true;
            officerIDLabel1.BackColor = System.Drawing.Color.Transparent;
            officerIDLabel1.Location = new System.Drawing.Point(8, 119);
            officerIDLabel1.Name = "officerIDLabel1";
            officerIDLabel1.Size = new System.Drawing.Size(44, 13);
            officerIDLabel1.TabIndex = 3;
            officerIDLabel1.Text = "Officer:";
            // 
            // officeCodeLabel1
            // 
            officeCodeLabel1.AutoSize = true;
            officeCodeLabel1.BackColor = System.Drawing.Color.Transparent;
            officeCodeLabel1.Location = new System.Drawing.Point(8, 92);
            officeCodeLabel1.Name = "officeCodeLabel1";
            officeCodeLabel1.Size = new System.Drawing.Size(40, 13);
            officeCodeLabel1.TabIndex = 5;
            officeCodeLabel1.Text = "Office:";
            // 
            // batchDateLabel1
            // 
            batchDateLabel1.AutoSize = true;
            batchDateLabel1.BackColor = System.Drawing.Color.Transparent;
            batchDateLabel1.Location = new System.Drawing.Point(8, 19);
            batchDateLabel1.Name = "batchDateLabel1";
            batchDateLabel1.Size = new System.Drawing.Size(64, 13);
            batchDateLabel1.TabIndex = 11;
            batchDateLabel1.Text = "Batch Date:";
            // 
            // priorityLabel1
            // 
            priorityLabel1.AutoSize = true;
            priorityLabel1.BackColor = System.Drawing.Color.Transparent;
            priorityLabel1.Location = new System.Drawing.Point(251, 19);
            priorityLabel1.Name = "priorityLabel1";
            priorityLabel1.Size = new System.Drawing.Size(45, 13);
            priorityLabel1.TabIndex = 13;
            priorityLabel1.Text = "Priority:";
            // 
            // runAfterDateLabel1
            // 
            runAfterDateLabel1.AutoSize = true;
            runAfterDateLabel1.BackColor = System.Drawing.Color.Transparent;
            runAfterDateLabel1.Location = new System.Drawing.Point(8, 47);
            runAfterDateLabel1.Name = "runAfterDateLabel1";
            runAfterDateLabel1.Size = new System.Drawing.Size(58, 13);
            runAfterDateLabel1.TabIndex = 15;
            runAfterDateLabel1.Text = "Run After:";
            // 
            // jobNameLabel1
            // 
            jobNameLabel1.AutoSize = true;
            jobNameLabel1.BackColor = System.Drawing.Color.Transparent;
            jobNameLabel1.Location = new System.Drawing.Point(8, 193);
            jobNameLabel1.Name = "jobNameLabel1";
            jobNameLabel1.Size = new System.Drawing.Size(58, 13);
            jobNameLabel1.TabIndex = 17;
            jobNameLabel1.Text = "Job Name:";
            // 
            // parametersLabel1
            // 
            parametersLabel1.AutoSize = true;
            parametersLabel1.BackColor = System.Drawing.Color.Transparent;
            parametersLabel1.Location = new System.Drawing.Point(8, 220);
            parametersLabel1.Name = "parametersLabel1";
            parametersLabel1.Size = new System.Drawing.Size(66, 13);
            parametersLabel1.TabIndex = 19;
            parametersLabel1.Text = "Parameters:";
            // 
            // startRunDateLabel1
            // 
            startRunDateLabel1.AutoSize = true;
            startRunDateLabel1.BackColor = System.Drawing.Color.Transparent;
            startRunDateLabel1.Location = new System.Drawing.Point(263, 119);
            startRunDateLabel1.Name = "startRunDateLabel1";
            startRunDateLabel1.Size = new System.Drawing.Size(83, 13);
            startRunDateLabel1.TabIndex = 21;
            startRunDateLabel1.Text = "Start Run Date:";
            // 
            // endRunDateLabel1
            // 
            endRunDateLabel1.AutoSize = true;
            endRunDateLabel1.BackColor = System.Drawing.Color.Transparent;
            endRunDateLabel1.Location = new System.Drawing.Point(263, 146);
            endRunDateLabel1.Name = "endRunDateLabel1";
            endRunDateLabel1.Size = new System.Drawing.Size(77, 13);
            endRunDateLabel1.TabIndex = 23;
            endRunDateLabel1.Text = "End Run Date:";
            // 
            // statusLabel1
            // 
            statusLabel1.AutoSize = true;
            statusLabel1.BackColor = System.Drawing.Color.Transparent;
            statusLabel1.Location = new System.Drawing.Point(254, 47);
            statusLabel1.Name = "statusLabel1";
            statusLabel1.Size = new System.Drawing.Size(42, 13);
            statusLabel1.TabIndex = 27;
            statusLabel1.Text = "Status:";
            // 
            // messageLabel1
            // 
            messageLabel1.AutoSize = true;
            messageLabel1.BackColor = System.Drawing.Color.Transparent;
            messageLabel1.Location = new System.Drawing.Point(8, 273);
            messageLabel1.Name = "messageLabel1";
            messageLabel1.Size = new System.Drawing.Size(53, 13);
            messageLabel1.TabIndex = 29;
            messageLabel1.Text = "Message:";
            // 
            // outputFileLabel1
            // 
            outputFileLabel1.AutoSize = true;
            outputFileLabel1.BackColor = System.Drawing.Color.Transparent;
            outputFileLabel1.Location = new System.Drawing.Point(8, 300);
            outputFileLabel1.Name = "outputFileLabel1";
            outputFileLabel1.Size = new System.Drawing.Size(64, 13);
            outputFileLabel1.TabIndex = 31;
            outputFileLabel1.Text = "Output File:";
            // 
            // entryUserLabel
            // 
            entryUserLabel.AutoSize = true;
            entryUserLabel.BackColor = System.Drawing.Color.Transparent;
            entryUserLabel.Cursor = System.Windows.Forms.Cursors.Default;
            entryUserLabel.Location = new System.Drawing.Point(251, 324);
            entryUserLabel.Name = "entryUserLabel";
            entryUserLabel.Size = new System.Drawing.Size(62, 13);
            entryUserLabel.TabIndex = 33;
            entryUserLabel.Text = "Entry User:";
            // 
            // entryDateLabel
            // 
            entryDateLabel.AutoSize = true;
            entryDateLabel.BackColor = System.Drawing.Color.Transparent;
            entryDateLabel.Location = new System.Drawing.Point(8, 324);
            entryDateLabel.Name = "entryDateLabel";
            entryDateLabel.Size = new System.Drawing.Size(63, 13);
            entryDateLabel.TabIndex = 35;
            entryDateLabel.Text = "Entry Date:";
            // 
            // updateUserLabel
            // 
            updateUserLabel.AutoSize = true;
            updateUserLabel.BackColor = System.Drawing.Color.Transparent;
            updateUserLabel.Location = new System.Drawing.Point(242, 352);
            updateUserLabel.Name = "updateUserLabel";
            updateUserLabel.Size = new System.Drawing.Size(71, 13);
            updateUserLabel.TabIndex = 37;
            updateUserLabel.Text = "Update User:";
            // 
            // updateDateLabel
            // 
            updateDateLabel.AutoSize = true;
            updateDateLabel.BackColor = System.Drawing.Color.Transparent;
            updateDateLabel.Location = new System.Drawing.Point(8, 352);
            updateDateLabel.Name = "updateDateLabel";
            updateDateLabel.Size = new System.Drawing.Size(72, 13);
            updateDateLabel.TabIndex = 39;
            updateDateLabel.Text = "Update Date:";
            // 
            // userNameLabel1
            // 
            userNameLabel1.AutoSize = true;
            userNameLabel1.BackColor = System.Drawing.Color.Transparent;
            userNameLabel1.Location = new System.Drawing.Point(8, 146);
            userNameLabel1.Name = "userNameLabel1";
            userNameLabel1.Size = new System.Drawing.Size(63, 13);
            userNameLabel1.TabIndex = 7;
            userNameLabel1.Text = "User Name:";
            // 
            // batchBindingSource
            // 
            this.batchBindingSource.DataMember = "Batch";
            this.batchBindingSource.DataSource = this.atriumDB;
            this.batchBindingSource.CurrentChanged += new System.EventHandler(this.batchBindingSource_CurrentChanged);
            // 
            // atriumDB
            // 
            this.atriumDB.DataSetName = "appDB";
            this.atriumDB.EnforceConstraints = false;
            this.atriumDB.Locale = new System.Globalization.CultureInfo("en-CA");
            this.atriumDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // batchGridEX
            // 
            this.batchGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
            this.batchGridEX.DataSource = this.batchBindingSource;
            batchGridEX_DesignTimeLayout_Reference_0.Instance = ((object)(resources.GetObject("batchGridEX_DesignTimeLayout_Reference_0.Instance")));
            batchGridEX_DesignTimeLayout_Reference_1.Instance = ((object)(resources.GetObject("batchGridEX_DesignTimeLayout_Reference_1.Instance")));
            batchGridEX_DesignTimeLayout_Reference_2.Instance = ((object)(resources.GetObject("batchGridEX_DesignTimeLayout_Reference_2.Instance")));
            batchGridEX_DesignTimeLayout_Reference_3.Instance = ((object)(resources.GetObject("batchGridEX_DesignTimeLayout_Reference_3.Instance")));
            batchGridEX_DesignTimeLayout_Reference_4.Instance = ((object)(resources.GetObject("batchGridEX_DesignTimeLayout_Reference_4.Instance")));
            batchGridEX_DesignTimeLayout.LayoutReferences.AddRange(new Janus.Windows.Common.Layouts.JanusLayoutReference[] {
            batchGridEX_DesignTimeLayout_Reference_0,
            batchGridEX_DesignTimeLayout_Reference_1,
            batchGridEX_DesignTimeLayout_Reference_2,
            batchGridEX_DesignTimeLayout_Reference_3,
            batchGridEX_DesignTimeLayout_Reference_4});
            batchGridEX_DesignTimeLayout.LayoutString = resources.GetString("batchGridEX_DesignTimeLayout.LayoutString");
            this.batchGridEX.DesignTimeLayout = batchGridEX_DesignTimeLayout;
            this.batchGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.batchGridEX.FilterMode = Janus.Windows.GridEX.FilterMode.Manual;
            this.batchGridEX.GridLines = Janus.Windows.GridEX.GridLines.None;
            this.batchGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.batchGridEX.Location = new System.Drawing.Point(0, 0);
            this.batchGridEX.Name = "batchGridEX";
            this.batchGridEX.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
            this.batchGridEX.Size = new System.Drawing.Size(957, 210);
            this.batchGridEX.TabIndex = 0;
            this.batchGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
            // 
            // uiCommandManager1
            // 
            this.uiCommandManager1.BottomRebar = this.BottomRebar1;
            this.uiCommandManager1.CommandBars.AddRange(new Janus.Windows.UI.CommandBars.UICommandBar[] {
            this.uiCommandBar1});
            this.uiCommandManager1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave,
            this.cmdCancel,
            this.cmdDelete,
            this.cmdRun,
            this.cmdNewSQL});
            this.uiCommandManager1.ContainerControl = this;
            // 
            // 
            // 
            this.uiCommandManager1.EditContextMenu.Key = "";
            this.uiCommandManager1.Id = new System.Guid("7d2b1131-19ba-42d2-af06-f4a797ed671c");
            this.uiCommandManager1.LeftRebar = this.LeftRebar1;
            this.uiCommandManager1.RightRebar = this.RightRebar1;
            this.uiCommandManager1.TopRebar = this.TopRebar1;
            this.uiCommandManager1.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            this.uiCommandManager1.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.uiCommandManager1_CommandClick);
            // 
            // BottomRebar1
            // 
            this.BottomRebar1.CommandManager = this.uiCommandManager1;
            this.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomRebar1.Location = new System.Drawing.Point(0, 551);
            this.BottomRebar1.Name = "BottomRebar1";
            this.BottomRebar1.Size = new System.Drawing.Size(751, 0);
            // 
            // uiCommandBar1
            // 
            this.uiCommandBar1.CommandManager = this.uiCommandManager1;
            this.uiCommandBar1.Commands.AddRange(new Janus.Windows.UI.CommandBars.UICommand[] {
            this.cmdSave1,
            this.Separator2,
            this.cmdCancel1,
            this.Separator3,
            this.cmdDelete1,
            this.Separator4,
            this.cmdRun1,
            this.Separator1,
            this.cmdNewSQL1});
            this.uiCommandBar1.FullRow = true;
            this.uiCommandBar1.Key = "CommandBar1";
            this.uiCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.uiCommandBar1.LockCommandBar = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Name = "uiCommandBar1";
            this.uiCommandBar1.RowIndex = 0;
            this.uiCommandBar1.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.False;
            this.uiCommandBar1.ShowToolTips = Janus.Windows.UI.InheritableBoolean.True;
            this.uiCommandBar1.Size = new System.Drawing.Size(965, 28);
            this.uiCommandBar1.Text = "CommandBar1";
            // 
            // cmdSave1
            // 
            this.cmdSave1.Key = "cmdSave";
            this.cmdSave1.Name = "cmdSave1";
            // 
            // Separator2
            // 
            this.Separator2.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator2.Key = "Separator";
            this.Separator2.Name = "Separator2";
            // 
            // cmdCancel1
            // 
            this.cmdCancel1.Key = "cmdCancel";
            this.cmdCancel1.Name = "cmdCancel1";
            // 
            // Separator3
            // 
            this.Separator3.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator3.Key = "Separator";
            this.Separator3.Name = "Separator3";
            // 
            // cmdDelete1
            // 
            this.cmdDelete1.Key = "cmdDelete";
            this.cmdDelete1.Name = "cmdDelete1";
            // 
            // Separator4
            // 
            this.Separator4.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator4.Key = "Separator";
            this.Separator4.Name = "Separator4";
            // 
            // cmdRun1
            // 
            this.cmdRun1.Key = "cmdRun";
            this.cmdRun1.Name = "cmdRun1";
            // 
            // Separator1
            // 
            this.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator;
            this.Separator1.Key = "Separator";
            this.Separator1.Name = "Separator1";
            // 
            // cmdNewSQL1
            // 
            this.cmdNewSQL1.Key = "cmdNewSQL";
            this.cmdNewSQL1.Name = "cmdNewSQL1";
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
            // cmdDelete
            // 
            this.cmdDelete.CommandStyle = Janus.Windows.UI.CommandBars.CommandStyle.TextImage;
            this.cmdDelete.Image = ((System.Drawing.Image)(resources.GetObject("cmdDelete.Image")));
            this.cmdDelete.Key = "cmdDelete";
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Text = "Delete";
            // 
            // cmdRun
            // 
            this.cmdRun.Image = ((System.Drawing.Image)(resources.GetObject("cmdRun.Image")));
            this.cmdRun.Key = "cmdRun";
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Text = "Run Pending Jobs";
            // 
            // cmdNewSQL
            // 
            this.cmdNewSQL.Image = ((System.Drawing.Image)(resources.GetObject("cmdNewSQL.Image")));
            this.cmdNewSQL.Key = "cmdNewSQL";
            this.cmdNewSQL.Name = "cmdNewSQL";
            this.cmdNewSQL.Text = "New SQL Job";
            // 
            // LeftRebar1
            // 
            this.LeftRebar1.CommandManager = this.uiCommandManager1;
            this.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftRebar1.Location = new System.Drawing.Point(0, 28);
            this.LeftRebar1.Name = "LeftRebar1";
            this.LeftRebar1.Size = new System.Drawing.Size(0, 523);
            // 
            // RightRebar1
            // 
            this.RightRebar1.CommandManager = this.uiCommandManager1;
            this.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightRebar1.Location = new System.Drawing.Point(751, 28);
            this.RightRebar1.Name = "RightRebar1";
            this.RightRebar1.Size = new System.Drawing.Size(0, 523);
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
            this.TopRebar1.Size = new System.Drawing.Size(965, 28);
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.DefaultPanelSettings.ActiveCaptionMode = Janus.Windows.UI.Dock.ActiveCaptionMode.Never;
            this.uiPanelManager1.DefaultPanelSettings.AutoHideButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.CaptionDoubleClickAction = Janus.Windows.UI.Dock.CaptionDoubleClickAction.None;
            this.uiPanelManager1.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.uiPanelManager1.DefaultPanelSettings.CloseButtonVisible = false;
            this.uiPanelManager1.DefaultPanelSettings.InnerAreaStyle = Janus.Windows.UI.Dock.PanelInnerAreaStyle.ContainerPanel;
            this.uiPanelManager1.VisualStyle = Janus.Windows.UI.Dock.PanelVisualStyle.Office2010;
            this.pnlTop.Id = new System.Guid("332b931a-139e-4ac5-94ad-a93ce8586594");
            this.uiPanelManager1.Panels.Add(this.pnlTop);
            this.pnlDetail.Id = new System.Guid("a0716c30-e8e0-465d-8680-c66b9cc66671");
            this.uiPanelManager1.Panels.Add(this.pnlDetail);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("332b931a-139e-4ac5-94ad-a93ce8586594"), Janus.Windows.UI.Dock.PanelDockStyle.Top, new System.Drawing.Size(959, 216), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a0716c30-e8e0-465d-8680-c66b9cc66671"), Janus.Windows.UI.Dock.PanelDockStyle.Fill, new System.Drawing.Size(959, 420), true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("59466cee-7156-4631-87a5-2a22fb966b6c"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e66ca4db-b710-440f-9e78-69a2449a22a1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("781514b0-d837-4426-b179-4cfa8bc6cf2b"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("b41e9eb9-a043-4d26-8bbe-8b54d893b734"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("7dd7c9eb-ceff-439e-88c8-e8a9a19120aa"), Janus.Windows.UI.Dock.PanelGroupStyle.HorizontalTiles, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("e67541b4-db01-4943-a3d2-eca11f81f0d1"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("420b2dad-9a8c-4eed-bac3-45d46e44e1cd"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("332b931a-139e-4ac5-94ad-a93ce8586594"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a0716c30-e8e0-465d-8680-c66b9cc66671"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // pnlTop
            // 
            this.pnlTop.CaptionVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.pnlTop.InnerContainer = this.pnlTopContainer;
            this.pnlTop.Location = new System.Drawing.Point(3, 31);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(959, 216);
            this.pnlTop.TabIndex = 4;
            this.pnlTop.Text = "Batch Review";
            // 
            // pnlTopContainer
            // 
            this.pnlTopContainer.Controls.Add(this.batchGridEX);
            this.pnlTopContainer.Location = new System.Drawing.Point(1, 1);
            this.pnlTopContainer.Name = "pnlTopContainer";
            this.pnlTopContainer.Size = new System.Drawing.Size(957, 210);
            this.pnlTopContainer.TabIndex = 0;
            // 
            // pnlDetail
            // 
            this.pnlDetail.InnerContainer = this.pnlDetailContainer;
            this.pnlDetail.Location = new System.Drawing.Point(3, 247);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(959, 420);
            this.pnlDetail.TabIndex = 4;
            this.pnlDetail.Text = "Batch Review Detail";
            // 
            // pnlDetailContainer
            // 
            this.pnlDetailContainer.AutoScroll = true;
            this.pnlDetailContainer.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.pnlDetailContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlDetailContainer.Controls.Add(this.ebPriority);
            this.pnlDetailContainer.Controls.Add(this.cbStatus);
            this.pnlDetailContainer.Controls.Add(this.ucMultiDropDown1);
            this.pnlDetailContainer.Controls.Add(batchIDLabel1);
            this.pnlDetailContainer.Controls.Add(this.batchIDEditBox);
            this.pnlDetailContainer.Controls.Add(officerIDLabel1);
            this.pnlDetailContainer.Controls.Add(officeCodeLabel1);
            this.pnlDetailContainer.Controls.Add(this.officeCodeEditBox);
            this.pnlDetailContainer.Controls.Add(userNameLabel1);
            this.pnlDetailContainer.Controls.Add(this.userNameEditBox);
            this.pnlDetailContainer.Controls.Add(batchDateLabel1);
            this.pnlDetailContainer.Controls.Add(this.batchDateCalendarCombo);
            this.pnlDetailContainer.Controls.Add(priorityLabel1);
            this.pnlDetailContainer.Controls.Add(runAfterDateLabel1);
            this.pnlDetailContainer.Controls.Add(this.runAfterDateCalendarCombo);
            this.pnlDetailContainer.Controls.Add(jobNameLabel1);
            this.pnlDetailContainer.Controls.Add(this.jobNameEditBox);
            this.pnlDetailContainer.Controls.Add(parametersLabel1);
            this.pnlDetailContainer.Controls.Add(this.parametersEditBox);
            this.pnlDetailContainer.Controls.Add(startRunDateLabel1);
            this.pnlDetailContainer.Controls.Add(this.startRunDateCalendarCombo);
            this.pnlDetailContainer.Controls.Add(endRunDateLabel1);
            this.pnlDetailContainer.Controls.Add(this.endRunDateCalendarCombo);
            this.pnlDetailContainer.Controls.Add(this.completedUICheckBox);
            this.pnlDetailContainer.Controls.Add(statusLabel1);
            this.pnlDetailContainer.Controls.Add(messageLabel1);
            this.pnlDetailContainer.Controls.Add(this.messageEditBox);
            this.pnlDetailContainer.Controls.Add(outputFileLabel1);
            this.pnlDetailContainer.Controls.Add(this.outputFileEditBox);
            this.pnlDetailContainer.Controls.Add(entryUserLabel);
            this.pnlDetailContainer.Controls.Add(this.entryUserEditBox);
            this.pnlDetailContainer.Controls.Add(entryDateLabel);
            this.pnlDetailContainer.Controls.Add(this.entryDateCalendarCombo);
            this.pnlDetailContainer.Controls.Add(updateUserLabel);
            this.pnlDetailContainer.Controls.Add(this.updateUserEditBox);
            this.pnlDetailContainer.Controls.Add(updateDateLabel);
            this.pnlDetailContainer.Controls.Add(this.updateDateCalendarCombo);
            this.pnlDetailContainer.Location = new System.Drawing.Point(1, 23);
            this.pnlDetailContainer.Name = "pnlDetailContainer";
            this.pnlDetailContainer.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.pnlDetailContainer.Size = new System.Drawing.Size(957, 396);
            this.pnlDetailContainer.TabIndex = 0;
            // 
            // ebPriority
            // 
            this.ebPriority.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "Priority", true));
            this.ebPriority.Location = new System.Drawing.Point(319, 16);
            this.ebPriority.Maximum = 5;
            this.ebPriority.MaxLength = 1;
            this.ebPriority.Name = "ebPriority";
            this.ebPriority.Size = new System.Drawing.Size(40, 21);
            this.ebPriority.TabIndex = 43;
            this.ebPriority.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // cbStatus
            // 
            this.cbStatus.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList;
            this.cbStatus.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.batchBindingSource, "Status", true));
            this.cbStatus.ImageList = this.imageList1;
            this.cbStatus.Location = new System.Drawing.Point(319, 43);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(120, 22);
            this.cbStatus.TabIndex = 42;
            this.cbStatus.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Batch_Pending.png");
            this.imageList1.Images.SetKeyName(1, "Batch_Active.png");
            this.imageList1.Images.SetKeyName(2, "batch_complete.png");
            this.imageList1.Images.SetKeyName(3, "Batch_Failed.png");
            this.imageList1.Images.SetKeyName(4, "batch_read.png");
            // 
            // ucMultiDropDown1
            // 
            this.ucMultiDropDown1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucMultiDropDown1.Column1 = "officercode";
            this.ucMultiDropDown1.Column2 = "fullname";
            this.ucMultiDropDown1.ComboType = Janus.Windows.GridEX.ComboStyle.DropDownList;
            this.ucMultiDropDown1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.batchBindingSource, "OfficerID", true));
            this.ucMultiDropDown1.DataSource = null;
            this.ucMultiDropDown1.DDColumn1Visible = true;
            this.ucMultiDropDown1.DisplayMember = "fullname";
            this.ucMultiDropDown1.DisplayNameColumn1 = "Code";
            this.ucMultiDropDown1.DisplayNameColumn2 = "Name";
            this.ucMultiDropDown1.DropDownColumn1Width = 100;
            this.ucMultiDropDown1.DropDownColumn2Width = 300;
            this.ucMultiDropDown1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.ucMultiDropDown1.Location = new System.Drawing.Point(98, 114);
            this.ucMultiDropDown1.Middle = 141;
            this.ucMultiDropDown1.Name = "ucMultiDropDown1";
            this.ucMultiDropDown1.ReadOnly = true;
            this.ucMultiDropDown1.ReqColor = System.Drawing.SystemColors.Control;
            this.ucMultiDropDown1.SelectedValue = null;
            this.ucMultiDropDown1.Size = new System.Drawing.Size(138, 21);
            this.ucMultiDropDown1.TabIndex = 41;
            this.ucMultiDropDown1.ValueMember = "officerid";
            // 
            // batchIDEditBox
            // 
            this.batchIDEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.batchIDEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "BatchID", true));
            this.batchIDEditBox.Location = new System.Drawing.Point(502, 16);
            this.batchIDEditBox.Name = "batchIDEditBox";
            this.batchIDEditBox.ReadOnly = true;
            this.batchIDEditBox.Size = new System.Drawing.Size(74, 21);
            this.batchIDEditBox.TabIndex = 2;
            this.batchIDEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // officeCodeEditBox
            // 
            this.officeCodeEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.officeCodeEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "OfficeCode", true));
            this.officeCodeEditBox.Location = new System.Drawing.Point(98, 87);
            this.officeCodeEditBox.Name = "officeCodeEditBox";
            this.officeCodeEditBox.ReadOnly = true;
            this.officeCodeEditBox.Size = new System.Drawing.Size(138, 21);
            this.officeCodeEditBox.TabIndex = 6;
            this.officeCodeEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // userNameEditBox
            // 
            this.userNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.userNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "UserName", true));
            this.userNameEditBox.Location = new System.Drawing.Point(98, 141);
            this.userNameEditBox.Name = "userNameEditBox";
            this.userNameEditBox.ReadOnly = true;
            this.userNameEditBox.Size = new System.Drawing.Size(138, 21);
            this.userNameEditBox.TabIndex = 8;
            this.userNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // batchDateCalendarCombo
            // 
            this.batchDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.batchDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd";
            this.batchDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "BatchDate", true));
            this.batchDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.batchDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.batchDateCalendarCombo.Location = new System.Drawing.Point(98, 16);
            this.batchDateCalendarCombo.Name = "batchDateCalendarCombo";
            this.batchDateCalendarCombo.ReadOnly = true;
            this.batchDateCalendarCombo.Size = new System.Drawing.Size(138, 21);
            this.batchDateCalendarCombo.TabIndex = 12;
            this.batchDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // runAfterDateCalendarCombo
            // 
            this.runAfterDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd HH:mm:ss";
            this.runAfterDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "RunAfterDate", true));
            this.runAfterDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.runAfterDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.runAfterDateCalendarCombo.Location = new System.Drawing.Point(98, 43);
            this.runAfterDateCalendarCombo.Name = "runAfterDateCalendarCombo";
            this.runAfterDateCalendarCombo.Size = new System.Drawing.Size(138, 21);
            this.runAfterDateCalendarCombo.TabIndex = 16;
            this.runAfterDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // jobNameEditBox
            // 
            this.jobNameEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.jobNameEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "JobName", true));
            this.jobNameEditBox.Location = new System.Drawing.Point(98, 188);
            this.jobNameEditBox.Name = "jobNameEditBox";
            this.jobNameEditBox.ReadOnly = true;
            this.jobNameEditBox.Size = new System.Drawing.Size(138, 21);
            this.jobNameEditBox.TabIndex = 18;
            this.jobNameEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // parametersEditBox
            // 
            this.parametersEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "Parameters", true));
            this.parametersEditBox.Location = new System.Drawing.Point(98, 215);
            this.parametersEditBox.Multiline = true;
            this.parametersEditBox.Name = "parametersEditBox";
            this.parametersEditBox.ReadOnly = true;
            this.parametersEditBox.Size = new System.Drawing.Size(842, 47);
            this.parametersEditBox.TabIndex = 20;
            this.parametersEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // startRunDateCalendarCombo
            // 
            this.startRunDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.startRunDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm:ss";
            this.startRunDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "StartRunDate", true));
            this.startRunDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.startRunDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.startRunDateCalendarCombo.Location = new System.Drawing.Point(353, 116);
            this.startRunDateCalendarCombo.Name = "startRunDateCalendarCombo";
            this.startRunDateCalendarCombo.ReadOnly = true;
            this.startRunDateCalendarCombo.Size = new System.Drawing.Size(139, 21);
            this.startRunDateCalendarCombo.TabIndex = 22;
            this.startRunDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // endRunDateCalendarCombo
            // 
            this.endRunDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.endRunDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm:ss";
            this.endRunDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "EndRunDate", true));
            this.endRunDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.endRunDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.endRunDateCalendarCombo.Location = new System.Drawing.Point(353, 143);
            this.endRunDateCalendarCombo.Name = "endRunDateCalendarCombo";
            this.endRunDateCalendarCombo.ReadOnly = true;
            this.endRunDateCalendarCombo.Size = new System.Drawing.Size(139, 21);
            this.endRunDateCalendarCombo.TabIndex = 24;
            this.endRunDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // completedUICheckBox
            // 
            this.completedUICheckBox.BackColor = System.Drawing.Color.Transparent;
            this.completedUICheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.completedUICheckBox.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "Completed", true));
            this.completedUICheckBox.Enabled = false;
            this.completedUICheckBox.Location = new System.Drawing.Point(501, 114);
            this.completedUICheckBox.Name = "completedUICheckBox";
            this.completedUICheckBox.Size = new System.Drawing.Size(74, 23);
            this.completedUICheckBox.TabIndex = 26;
            this.completedUICheckBox.Text = "Completed";
            this.completedUICheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007;
            // 
            // messageEditBox
            // 
            this.messageEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.messageEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "Message", true));
            this.messageEditBox.Location = new System.Drawing.Point(98, 268);
            this.messageEditBox.Name = "messageEditBox";
            this.messageEditBox.ReadOnly = true;
            this.messageEditBox.Size = new System.Drawing.Size(842, 21);
            this.messageEditBox.TabIndex = 30;
            this.messageEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // outputFileEditBox
            // 
            this.outputFileEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.outputFileEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "OutputFile", true));
            this.outputFileEditBox.Location = new System.Drawing.Point(98, 295);
            this.outputFileEditBox.Name = "outputFileEditBox";
            this.outputFileEditBox.ReadOnly = true;
            this.outputFileEditBox.Size = new System.Drawing.Size(842, 21);
            this.outputFileEditBox.TabIndex = 32;
            this.outputFileEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // entryUserEditBox
            // 
            this.entryUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.entryUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "entryUser", true));
            this.entryUserEditBox.Location = new System.Drawing.Point(319, 320);
            this.entryUserEditBox.Name = "entryUserEditBox";
            this.entryUserEditBox.ReadOnly = true;
            this.entryUserEditBox.Size = new System.Drawing.Size(120, 21);
            this.entryUserEditBox.TabIndex = 34;
            this.entryUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // entryDateCalendarCombo
            // 
            this.entryDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.entryDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm:ss";
            this.entryDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "entryDate", true));
            this.entryDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.entryDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.entryDateCalendarCombo.Location = new System.Drawing.Point(98, 320);
            this.entryDateCalendarCombo.Name = "entryDateCalendarCombo";
            this.entryDateCalendarCombo.ReadOnly = true;
            this.entryDateCalendarCombo.Size = new System.Drawing.Size(138, 21);
            this.entryDateCalendarCombo.TabIndex = 36;
            this.entryDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // updateUserEditBox
            // 
            this.updateUserEditBox.BackColor = System.Drawing.SystemColors.Control;
            this.updateUserEditBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.batchBindingSource, "updateUser", true));
            this.updateUserEditBox.Location = new System.Drawing.Point(319, 347);
            this.updateUserEditBox.Name = "updateUserEditBox";
            this.updateUserEditBox.ReadOnly = true;
            this.updateUserEditBox.Size = new System.Drawing.Size(120, 21);
            this.updateUserEditBox.TabIndex = 38;
            this.updateUserEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007;
            // 
            // updateDateCalendarCombo
            // 
            this.updateDateCalendarCombo.BackColor = System.Drawing.SystemColors.Control;
            this.updateDateCalendarCombo.CustomFormat = "yyyy\'/\'MM\'/\'dd hh:mm:ss";
            this.updateDateCalendarCombo.DataBindings.Add(new System.Windows.Forms.Binding("BindableValue", this.batchBindingSource, "updateDate", true));
            this.updateDateCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.updateDateCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            this.updateDateCalendarCombo.Location = new System.Drawing.Point(98, 347);
            this.updateDateCalendarCombo.Name = "updateDateCalendarCombo";
            this.updateDateCalendarCombo.ReadOnly = true;
            this.updateDateCalendarCombo.Size = new System.Drawing.Size(139, 21);
            this.updateDateCalendarCombo.TabIndex = 40;
            this.updateDateCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2007;
            // 
            // fBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(965, 670);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.TopRebar1);
            this.Name = "fBatch";
            this.Text = "Batch Review";
            this.Load += new System.EventHandler(this.fBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atriumDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batchGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BottomRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeftRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightRebar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopRebar1)).EndInit();
            this.TopRebar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTopContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetailContainer.ResumeLayout(false);
            this.pnlDetailContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.GridEX.GridEX batchGridEX;
        private System.Windows.Forms.BindingSource batchBindingSource;
        private lmDatasets.appDB atriumDB;
        private Janus.Windows.UI.CommandBars.UIRebar TopRebar1;
        private Janus.Windows.UI.CommandBars.UICommandBar uiCommandBar1;
        private Janus.Windows.UI.CommandBars.UICommandManager uiCommandManager1;
        private Janus.Windows.UI.CommandBars.UIRebar BottomRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete;
        private Janus.Windows.UI.CommandBars.UIRebar LeftRebar1;
        private Janus.Windows.UI.CommandBars.UIRebar RightRebar1;
        private Janus.Windows.UI.CommandBars.UICommand cmdSave1;
        private Janus.Windows.UI.CommandBars.UICommand Separator2;
        private Janus.Windows.UI.CommandBars.UICommand cmdCancel1;
        private Janus.Windows.UI.CommandBars.UICommand Separator3;
        private Janus.Windows.UI.CommandBars.UICommand cmdDelete1;
        private Janus.Windows.UI.Dock.UIPanel pnlDetail;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlDetailContainer;
        private UserControls.ucMultiDropDown ucMultiDropDown1;
        private Janus.Windows.GridEX.EditControls.EditBox batchIDEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox officeCodeEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox userNameEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo batchDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo runAfterDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox jobNameEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox parametersEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo startRunDateCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo endRunDateCalendarCombo;
        private Janus.Windows.EditControls.UICheckBox completedUICheckBox;
        private Janus.Windows.GridEX.EditControls.EditBox messageEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox outputFileEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox entryUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo entryDateCalendarCombo;
        private Janus.Windows.GridEX.EditControls.EditBox updateUserEditBox;
        private Janus.Windows.CalendarCombo.CalendarCombo updateDateCalendarCombo;
        private Janus.Windows.UI.Dock.UIPanel pnlTop;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer pnlTopContainer;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.EditControls.UIComboBox cbStatus;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown ebPriority;
        private Janus.Windows.UI.CommandBars.UICommand cmdRun1;
        private Janus.Windows.UI.CommandBars.UICommand cmdRun;
        private Janus.Windows.UI.CommandBars.UICommand Separator4;
        private Janus.Windows.UI.CommandBars.UICommand Separator1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewSQL1;
        private Janus.Windows.UI.CommandBars.UICommand cmdNewSQL;
    }
}