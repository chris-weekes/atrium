using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

namespace LawMate
{
    public interface IRelatedFieldsHost
    {
        FlowLayoutPanel flowLayoutPanel1 { get; }
      
        Janus.Windows.Common.JanusSuperTip janusSuperTip1 { get; }



     
        void SetHelpPanel(bool showpanel, string helptext);
        void EnableButtons(int required);
        void SkipStep();

    }
    public class RelatedFields : IDisposable
    {

        bool isDisposed = false;
        public void Dispose()
        {
            if (!isDisposed)
            {

                foreach(Control ctl in controlsToDispose)
                {
                    ctl.Dispose();
                }

                isDisposed = true;

            }
        }

        public List<Control> controlsToDispose = new List<Control>();

        public List<string> required = new List<string>();
        public Control firstCtl = null;
        public UserControls.IRequiredCtl requiresAction = null;

        ACEngine MyACE;
        atriumManager Atmng;
        FileManager FM;

        bool secReadOnly = false;

        IRelatedFieldsHost MyHost;

        public FlowLayoutPanel flowLayoutPanel1;
   
        public Janus.Windows.Common.JanusSuperTip janusSuperTip1;


        bool WizardMode = false;

        public RelatedFields(ACEngine ACE, IRelatedFieldsHost myHost, bool ReadOnly, bool wizardMode)
        {
            WizardMode = wizardMode;

            MyACE = ACE;
            FM = MyACE.FM;
            Atmng = FM.AtMng;

            MyHost = myHost;

           
            janusSuperTip1 = myHost.janusSuperTip1;
            flowLayoutPanel1 = myHost.flowLayoutPanel1;

            secReadOnly = ReadOnly;
        }

        public void FinishLayout()
        {
            flowLayoutPanel1.ResumeLayout();
        }
        public void BeginLayout()
        {
            flowLayoutPanel1.SuspendLayout();
            firstCtl = null;
            flowLayoutPanel1.Controls.Clear();
            required.Clear();
            //hook up error providers for each related table
            foreach (DataView dv in MyACE.relTables.Values)
            {
                ErrorProvider ep = new ErrorProvider();
                ep.ContainerControl = (ContainerControl)flowLayoutPanel1.Parent;
                ep.DataSource = dv;

                //this.Controls.Add(ep);
            }
        }

        public bool IsSingleBlock
        {
            get
            {
                if (MyACE.HasRel0 & !MyACE.HasRel1 & !MyACE.HasRel2 & !MyACE.HasRel3 & !MyACE.HasRel4 & !MyACE.HasRel5 & !MyACE.HasRel6 & !MyACE.HasRel7 & !MyACE.HasRel8 & !MyACE.HasRel9)
                    return true;
                else
                    return false;
            }
        }
        public void DoRelFields(ActivityConfig.ACSeriesRow acSeries, int step)
        {


            const int LBLWIDTH = 250;

            //try
            //{

            int vis = 0;

            FlowLayoutPanel flb;
            Janus.Windows.EditControls.UIGroupBox ugb = null;
            if (WizardMode | IsSingleBlock)
                flb = flowLayoutPanel1;
            else
            {
                ugb = new Janus.Windows.EditControls.UIGroupBox();
                ugb.Text = "";// "Block " + (step + 1).ToString();
                //    ugb.Dock = DockStyle.Top;
                ugb.BackColor = System.Drawing.Color.Transparent;
                ugb.Width = flowLayoutPanel1.Width - 10;
                ugb.UseThemes = false;
                ugb.FormatStyle.FontBold = Janus.Windows.UI.TriState.True;
                ugb.Height = 20;



                flowLayoutPanel1.Controls.Add(ugb);
                flowLayoutPanel1.SetFlowBreak(ugb, true);

                flb = new FlowLayoutPanel();
                flb.AutoScroll = true;
                flb.BackColor = System.Drawing.Color.Transparent;
                flb.Dock = System.Windows.Forms.DockStyle.Fill;
                flb.Location = new System.Drawing.Point(0, 0);
                flb.Name = "flb" + step.ToString();
                flb.Size = new System.Drawing.Size(763, 10);
                flb.TabIndex = 0;
                flb.AutoSize = true;
                flb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

                ugb.Controls.Add(flb);

            }
            //help panel text
            if (step >= 0 & step < 5)
            {
                string RelStepHelp = acSeries["Rel" + step.ToString() + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                if (RelStepHelp.Length > 0 & !WizardMode)
                    ugb.Text = RelStepHelp;
                else if (WizardMode) //RelStepHelp.Length > 0   JLL removed length check, needs to run everytime to hide panel when length was previously greater than zero
                    MyHost.SetHelpPanel(RelStepHelp.Length > 0, RelStepHelp);
            }
            else if (step == -1 & WizardMode)
            {
                string PromptStepHelp = acSeries["Prompt" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
                MyHost.SetHelpPanel(PromptStepHelp.Length > 0, PromptStepHelp);
            }

            if ( (!MyACE.skipBlock & WizardMode) | !WizardMode)
            {
                //create controls
                Janus.Windows.GridEX.GridEX gr = null;
                string gridObject = "";
                Janus.Windows.GridEX.GridEXColumn gc;
                foreach (ActivityConfig.ActivityFieldRow arf in Atmng.acMng.DB.ActivityField.Select("ACSeriesId=" + acSeries.ACSeriesId.ToString() + " and TaskType in ('F','P') and step=" + step.ToString(), "seq"))
                {
                    Control ctl = null;
                    bool customBinding = false;
                    string prop = "Text";

                    if (gridObject != arf.ObjectAlias)
                    {
                        gridObject = "";
                        if (gr != null)
                            SizeGrid(gr);
                        gr = null;
                    }
                    int maxLen = 0;

                    if (MyACE.relTables[arf.ObjectAlias].Count > 0 || arf.FieldType == "M" || gr != null)
                    {
                        if (MyACE.relTables[arf.ObjectAlias].Table.Columns.Contains(arf.DBFieldName))
                            maxLen = MyACE.relTables[arf.ObjectAlias].Table.Columns[arf.DBFieldName].MaxLength;
                        if (maxLen == -1)
                            maxLen = 0;

                        if (arf.Visible || MyACE.relTables[arf.ObjectAlias][0].Row.GetColumnError(arf.DBFieldName) != "")
                        {
                            ActivityConfig.ACControlTypeRow ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType(arf.FieldType);

                            vis++;
                            switch (arf.FieldType)
                            {

                                case "AG":
                                    ucSSTAppealGround ucsstag = new ucSSTAppealGround();
                                    ucsstag.FM = FM;
                                    ctl = (Control)ucsstag;
                                    customBinding = ctlTypeRow.IsCustomBinding;
                                    break;
                                case "TS":
                                    ucTemplateSelectBox uctsb = new ucTemplateSelectBox();
                                    uctsb.AtMng = FM.AtMng;
                                    uctsb.fm = FM;
                                    uctsb.list = arf.LookUp;
                                    ctl = (Control)uctsb;
                                    customBinding = ctlTypeRow.IsCustomBinding;
                                    break;
                                case "CM":
                                    ucSSTCaseMatter ucsstcm = new ucSSTCaseMatter();
                            
                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "PROMPT")
                                    {
                                        ucsstcm.PromptIssueMode = true;
                                    }
                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "SETOUTCOME")
                                    {
                                        ucsstcm.IsSettingOutcome = true;
                                    }
                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "PROMPTNOISSUE")
                                    {
                                        ucsstcm.PromptNoIssueMode = true;
                                    }
                                    ucsstcm.FM = FM;
                                    ucsstcm.DataSource = MyACE.relTables[arf.ObjectAlias];
                                    //ucsstcm.Width = 800;
                                    ctl = (Control)ucsstcm;
                                    customBinding = ctlTypeRow.IsCustomBinding;
                                    break;
                                case "?F": //browse for file
                                    ucFileSelectBox ucfsb = new ucFileSelectBox();
                                    ucfsb.AtMng = FM.AtMng;

                                    ucfsb.Width = ctlTypeRow.Width;
                                    ucfsb.Enabled = !arf.ReadOnly;
                                    ctl = (Control)ucfsb;
                                    prop = ctlTypeRow.BindingProp;
                                    break;
                                case "?O": // browse for office
                                    ucOfficeSelectBox ucosb = new ucOfficeSelectBox();
                                    ucosb.AtMng = FM.AtMng;

                                    ucosb.Width = ctlTypeRow.Width;
                                    ucosb.Enabled = !arf.ReadOnly;
                                    ctl = (Control)ucosb;
                                    prop = ctlTypeRow.BindingProp;
                                    break;
                                case "?I": // browse for issue
                                    ucIssueSelectBoxRF uciss = new ucIssueSelectBoxRF();
                                    uciss.FM = FM;

                                    uciss.Width = ctlTypeRow.Width;
                                    uciss.Enabled = !arf.ReadOnly;
                                    ctl = (Control)uciss;
                                    prop = ctlTypeRow.BindingProp;
                                    break;

                                case "?C":  //browse for contact
                                    ucContactSelectBox uccsb = new ucContactSelectBox();
                                    uccsb.FM = FM;
                                    uccsb.WLQuery = WorkloadQuery.NotApplicable;
                                    uccsb.Width = ctlTypeRow.Width;
                                    uccsb.Enabled = !arf.ReadOnly;
                                    ctl = (Control)uccsb;
                                    prop = ctlTypeRow.BindingProp;
                                    break;
                                case "?W":  //browse for contact - showWorkload
                                    ucContactSelectBox uccsbw = new ucContactSelectBox();
                                    uccsbw.FM = FM;
                                    uccsbw.Width = ctlTypeRow.Width;
                                    uccsbw.WLQuery = (WorkloadQuery)Enum.Parse(typeof(WorkloadQuery), arf.SpecialParameter);
                                    uccsbw.Enabled = !arf.ReadOnly;
                                    ctl = (Control)uccsbw;
                                    prop = ctlTypeRow.BindingProp;
                                    break;
                                case "?":
                                    ucDocUpload ucdu = new ucDocUpload();
                                    ucdu.DocMng = MyACE.FM.GetDocMng();
                                    ucdu.Document = (docDB.DocumentRow)MyACE.relTables[arf.ObjectAlias][0].Row;

                                    ucdu.Width = ctlTypeRow.Width;
                                    ucdu.Enabled = !arf.ReadOnly;
                                    ctl = (Control)ucdu;
                                    prop = "";
                                    customBinding = ctlTypeRow.IsCustomBinding;
                                    break;
                                case "CV":

                                    gr = new Janus.Windows.GridEX.GridEX();

                                    gridObject = arf.ObjectAlias;

                                    //gr.Width = ctlTypeRow.Width;
                                    gr.Width = MyHost.flowLayoutPanel1.ClientRectangle.Width-10;
                                    gr.BackColor = Color.FromArgb(219, 235, 255);
                                    gr.View = Janus.Windows.GridEX.View.CardView;
                                    gr.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
                                    gr.AllowCardSizing = false;
                                    gr.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
                                    gr.CardViewGridlines = Janus.Windows.GridEX.CardViewGridlines.FieldsOnly;
                                    gr.CardInnerSpacing = 5;
                                    gr.AutoEdit = true;
                                    gr.EnsureVisible();
                                    gr.CardSpacing = 6;
                                    gr.CardWidth = 290;
                                    gr.ExpandableCards = false;

                                    //if we set tab to navigate columns, the tab key can never tab out of the control.
                                    //use arrows within grid to navigate, tab to exit control.
                                    gr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
                                    gr.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
                                    gr.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
                                    gr.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(gr_CellUpdated);
                                    //handle height setting in VisibleChanged so we can count total columns.
                                    gr.VisibleChanged += new EventHandler(gr_VisibleChanged);

                                    gr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                    gr.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;

                                    gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                                    gr.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;


                                    ctl = (Control)gr;
                                    ctl.Name = arf.ObjectAlias + arf.FieldName;

                                    flb.Controls.Add(ctl);
                                    flb.SetFlowBreak(ctl, true);

                                    gr.DataSource = MyACE.relTables[arf.ObjectAlias];

                                    Janus.Windows.GridEX.GridEXTable gt2 = new Janus.Windows.GridEX.GridEXTable();
                                    gr.RootTable = gt2;
                                    gr.CardCaptionPrefix = (string)arf[UIHelper.Translate(FM, "LabelEng")];// LawMate.Properties.Resources.MultipleSelectEdit;
                                    gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
                                    gr.RootTable.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;

                                    string[] columns2 = arf.DBFieldName.Split(',');

                                    foreach (string s in columns2)
                                    {
                                        if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "hide")
                                        {
                                            //don't add arf as grid column
                                        }
                                        else
                                        {
                                            gc = new Janus.Windows.GridEX.GridEXColumn(s, Janus.Windows.GridEX.ColumnType.Text);
                                            gc.Caption = gr.RootTable.Caption;
                                            gr.RootTable.Columns.Add(gc);
                                            gc.Selectable = !arf.ReadOnly;
                                        }
                                    }


                                    break;
                                case "M":
                                    //multi-row so use grid
                                    gr = new Janus.Windows.GridEX.GridEX();
                                    gridObject = arf.ObjectAlias;
                                    gr.Height = 150;
                                    //gr.Left = 250;
                                    gr.Width = ctlTypeRow.Width;
                                    if (!WizardMode)
                                    {
                                        gr.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
                                        gr.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
                                    }
                                    gr.GroupByBoxVisible = false;
                                    gr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                    gr.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
                                    gr.GridLines = Janus.Windows.GridEX.GridLines.None;
                                    gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
                                    
                                    //START 2017-04-12 JLL MakePrompt grid; don't allow edits
                                    if (step == -1)
                                    { 
                                        gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
                                        gr.SelectedFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
                                    }
                                    //END   2017-04-12
                                    
                                    gr.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
                                    gr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
                                    gr.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
                                    gr.AutoEdit = true;
                                    gr.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
                                    gr.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
                                    gr.VisibleChanged += new EventHandler(gr_VisibleChanged);
                                    ctl = (Control)gr;
                                    ctl.Name = arf.ObjectAlias + arf.FieldName;

                                    flb.Controls.Add(ctl);
                                    flb.SetFlowBreak(ctl, true);

                                    gr.DataSource = MyACE.relTables[arf.ObjectAlias];

                                    Janus.Windows.GridEX.GridEXTable gt = new Janus.Windows.GridEX.GridEXTable();
                                    gr.RootTable = gt;
                                    if (!arf.IsLabelEngNull())
                                    {
                                        gr.RootTable.Caption = (string)arf[UIHelper.Translate(FM, "LabelEng")];// LawMate.Properties.Resources.MultipleSelectEdit;
                                        gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
                                        gr.RootTable.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
                                    }
                                    else
                                    {
                                        gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.False;
                                    }

                                    string[] columns = arf.DBFieldName.Split(',');

                                    foreach (string s in columns)
                                    {
                                        if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "hide")
                                        {
                                            //don't add arf as grid column
                                        }
                                        else
                                        {
                                            gc = new Janus.Windows.GridEX.GridEXColumn(s, Janus.Windows.GridEX.ColumnType.Text);
                                            gc.Selectable = false;
                                            //START 2017-04-12 JLL: attempt to lookup clean label in DD, and datatype
                                            if (step == -1)
                                            {
                                                string caption ="";
                                                appDB.ddFieldRow ddField = null;

                                                if(!arf.IsObjectAliasNull())
                                                    ddField = ddFieldBE.LookupDDFieldRow(Atmng, arf.ObjectName, s);
                                                if (ddField != null)
                                                {
                                                    caption = ddFieldBE.LookupDDFieldLabel(Atmng, ddField.FieldId);
                                                    if (!ddField.IsFieldTypeNull() && ddField.FieldType.ToUpper() == "A")
                                                        gc.FormatString = "yyyy'/'MM'/'dd";
                                                }

                                                if (caption == "")
                                                    gc.Caption = s;
                                                else
                                                    gc.Caption = caption;

                                            }
                                                
                                            else
                                                gc.Caption = gr.RootTable.Caption;
                                            //END 2017-04-12

                                            Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                            gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 15;
                                            if (gc.Width < 80)
                                                gc.Width = 80;

                                            gr.RootTable.Columns.Add(gc);
                                            if(step!=-1)
                                                gc.Selectable = !arf.ReadOnly;
                                        }
                                    }
                                    break;

                                case "A":    //Calendar Combo
                                    if (gr == null)
                                    {
                                        Janus.Windows.CalendarCombo.CalendarCombo jcb = new Janus.Windows.CalendarCombo.CalendarCombo();
                                        ctl = (Control)jcb;
                                        prop = ctlTypeRow.BindingProp;
                                        jcb.Width = ctlTypeRow.Width;
                                        jcb.EditStyle = Janus.Windows.CalendarCombo.EditStyle.Masked;
                                        jcb.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
                                        jcb.CustomFormat = "yyyy'/'MM'/'dd";
                                        jcb.Text = "";
                                        jcb.ReadOnly = arf.ReadOnly;
                                        jcb.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                        {
                                            jcb.BackColor = SystemColors.Control;
                                            //jcb.ForeColor = SystemColors.ControlDark;
                                        }
                                        if (arf.Required)
                                        {
                                            jcb.ShowNullButton = false;
                                            jcb.Nullable = false;
                                        }
                                        else
                                        {
                                            jcb.ShowNullButton = true;
                                            jcb.Nullable = true;
                                        }

                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        gc.EditType = Janus.Windows.GridEX.EditType.CalendarCombo;

                                        if (arf.Required)
                                            gc.CalendarNoneButtonVisible = Janus.Windows.GridEX.TriState.False;
                                        else
                                            gc.CalendarNoneButtonVisible = Janus.Windows.GridEX.TriState.True;

                                        gc.FormatString = "yyyy'/'MM'/'dd";
                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                //case "AR":    //Calendar Combo - Read Only
                                //    Janus.Windows.CalendarCombo.CalendarCombo jcbro = new Janus.Windows.CalendarCombo.CalendarCombo();
                                //    ctl = (Control)jcbro;
                                //    prop = "BindableValue";
                                //    jcbro.Enabled = false;
                                //    jcbro.Width = 100;
                                //    jc
                                //    jcbro.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
                                //    jcbro.CustomFormat = "yyyy'/'MM'/'dd";
                                //    break;
                                //case "Q":   //prompt drop down
                                //    ComboBox cbq = new ComboBox();
                                //    ctl = (Control)cbq;
                                //    prop = "SelectedValue";
                                //    cbq.DropDownStyle = ComboBoxStyle.DropDownList;
                                //    cbq.Width = 400;
                                //    cbq.Enabled = !arf.ReadOnly;
                                //    //need to set list LawMate.Properties

                                //    cbq.ValueMember = "id";
                                //    cbq.DisplayMember = "prompt";
                                //    cbq.DataSource = MyACE.Prompts[arf.LookUp];
                                //    break;
                                case "C":   //Enabled Dropdown
                                    Janus.Windows.EditControls.UIComboBox cb = new Janus.Windows.EditControls.UIComboBox();
                                    //ComboBox cb = new ComboBox();
                                    ctl = (Control)cb;
                                    prop = ctlTypeRow.BindingProp;
                                    cb.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList; //.DropDownStyle = ComboBoxStyle.DropDownList;
                                    cb.Width = ctlTypeRow.Width;
                                    cb.Enabled = !arf.ReadOnly;
                                    cb.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
                                    //need to set list LawMate.Properties
                                    DataTable dt = MyACE.FM.Codes(arf.LookUp);
                                    cb.ValueMember = dt.PrimaryKey[0].ColumnName;// dt.Columns[0].ColumnName;
                                    cb.DisplayMember = dt.Columns[UIHelper.Translate(FM, dt.Columns[1].ColumnName)].ColumnName;
                                    cb.DataSource = new DataView(dt);
                                    break;

                                case "T":   //Multiline Textbox
                                    //  TextBox tb = new TextBox();
                                    Janus.Windows.GridEX.EditControls.EditBox tb = new Janus.Windows.GridEX.EditControls.EditBox();
                                    ctl = (Control)tb;
                                    tb.Multiline = true;
                                    tb.AcceptsReturn = true;
                                    tb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                    tb.ScrollBars = ScrollBars.Vertical;
                                    tb.Height = 65;
                                    tb.Width = ctlTypeRow.Width;
                                    tb.ReadOnly = arf.ReadOnly;
                                    if (arf.ReadOnly)
                                    {
                                        tb.BackColor = SystemColors.ControlLight;
                                        //tb.ForeColor = SystemColors.ControlDark;
                                    }
                                    tb.MaxLength = maxLen;

                                    prop = ctlTypeRow.BindingProp;
                                    break;
                                case "MC":
                                    if (gr == null)
                                    {
                                        DoMCC(arf, ref ctl, ref prop, ctlTypeRow);
                                    }
                                    else
                                    {

                                        DataTable dt3 = MyACE.FM.Codes(arf.LookUp);
                                        Janus.Windows.GridEX.GridEXDropDown grdDD = gr.DropDowns.Add("dd" + arf.LookUp);

                                        grdDD.ValueMember = dt3.PrimaryKey[0].ColumnName;
                                        grdDD.DisplayMember = dt3.Columns[UIHelper.Translate(FM, dt3.Columns[1].ColumnName)].ColumnName;
                                        grdDD.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
                                        grdDD.Columns.Add(grdDD.DisplayMember, Janus.Windows.GridEX.ColumnType.Text);

                                        gr.DropDowns["dd" + arf.LookUp].SetDataBinding(dt3, "");
                                        // gr.DropDowns.Add(grdDD);

                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        gc.EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();

                                        gr.RootTable.Columns.Add(gc);
                                        gc.DropDown = gr.DropDowns["dd" + arf.LookUp];
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                case "AD":
                                    UserControls.ucAddress ucadd = new UserControls.ucAddress();
                                    ctl = (Control)ucadd;
                                    ucadd.ColumnTwoLeftPositionOffset = LBLWIDTH - 85;
                                    ucadd.Width = ctlTypeRow.Width;
                                    ucadd.DataSource = MyACE.relTables[arf.ObjectAlias];
                                    ucadd.Enabled = !arf.ReadOnly;
                                    ucadd.FM = FM;
                                    customBinding = ctlTypeRow.IsCustomBinding;
                                    break;
                                //case "SN":
                                //    Janus.Windows.GridEX.EditControls.MaskedEditBox meb = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
                                //    prop = "Text";
                                //    meb.IncludeLiterals = false;
                                //    meb.Width = 400;
                                //    meb.Mask = "### ### ###";
                                //    meb.PromptChar = ' ';
                                //    meb.Text = "";
                                //    meb.ReadOnly = arf.ReadOnly;
                                //    ctl = (Control)meb;
                                //    break;
                                case "B": //Currency Field
                                    if (gr == null)
                                    {
                                        Janus.Windows.GridEX.EditControls.NumericEditBox neb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
                                        ctl = (Control)neb;
                                        neb.Width = ctlTypeRow.Width;
                                        neb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
                                        neb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
                                        neb.ReadOnly = arf.ReadOnly;
                                        neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                        {
                                            neb.BackColor = SystemColors.ControlLight;
                                            //neb.ForeColor = SystemColors.ControlDark;
                                        }
                                        prop = ctlTypeRow.BindingProp;
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
                                        gc.FormatString = "c";
                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        gc.InputMask = "Currency";
                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();
                                        gr.RootTable.Columns.Add(gc);

                                        gc.Selectable = !arf.ReadOnly;
                                    }

                                    break;
                                case "IM":
                                    if (gr == null)
                                    {
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.BoundImage);

                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        gc.CellStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;


                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                case "I": //integer up down
                                    if (gr == null)
                                    {
                                        Janus.Windows.GridEX.EditControls.IntegerUpDown neb = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
                                        ctl = (Control)neb;
                                        neb.Width = ctlTypeRow.Width;
                                        neb.ReadOnly = arf.ReadOnly;
                                        neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                            neb.BackColor = SystemColors.ControlLight;

                                        if (!arf.IsSpecialParameterNull())
                                        {
                                            string[] values = arf.SpecialParameter.Split(',');
                                            if (values.Length == 3 && arf.SpecialParameter.ToLower().StartsWith("minmax"))
                                            {
                                                neb.Minimum = System.Convert.ToInt32(values[1]);
                                                neb.Maximum = System.Convert.ToInt32(values[2]);
                                            }
                                        }
                                        prop = ctlTypeRow.BindingProp;
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);

                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                case "DC": //decimal - added to allow decimals in relfields for taxing recommendations
                                    if (gr == null)
                                    {
                                        Janus.Windows.GridEX.EditControls.NumericEditBox ebDecimal = new Janus.Windows.GridEX.EditControls.NumericEditBox();
                                        ctl = (Control)ebDecimal;
                                        ebDecimal.Width = ctlTypeRow.Width;
                                        ebDecimal.ReadOnly = arf.ReadOnly;
                                        ebDecimal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                            ebDecimal.BackColor = SystemColors.ControlLight;

                                        if (!arf.IsSpecialParameterNull()) //num of decimals
                                        {
                                            ebDecimal.DecimalDigits = Convert.ToInt32(arf.SpecialParameter);
                                        }
                                        prop = ctlTypeRow.BindingProp;
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);

                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                case "N": //number Field
                                    if (gr == null)
                                    {
                                        Janus.Windows.GridEX.EditControls.NumericEditBox neb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
                                        ctl = (Control)neb;
                                        neb.Width = ctlTypeRow.Width;
                                        neb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
                                        neb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
                                        neb.ReadOnly = arf.ReadOnly;
                                        neb.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
                                        neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                        {
                                            neb.BackColor = SystemColors.ControlLight;
                                            //neb.ForeColor = SystemColors.ControlDark;
                                        }
                                        prop = ctlTypeRow.BindingProp;
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);

                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        //gc.InputMask = "Percent";

                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                case "P": //Percent Field
                                    if (gr == null)
                                    {
                                        Janus.Windows.GridEX.EditControls.NumericEditBox peb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
                                        ctl = (Control)peb;
                                        peb.Width = ctlTypeRow.Width;
                                        //peb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent;
                                        peb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
                                        peb.FormatString = "#0.000 \" %\"";
                                        peb.ReadOnly = arf.ReadOnly;
                                        peb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                        {
                                            peb.BackColor = SystemColors.ControlLight;
                                            //peb.ForeColor = SystemColors.ControlDark;
                                        }
                                        prop = ctlTypeRow.BindingProp;
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
                                        //gc.FormatMode = Janus.Windows.GridEX.FormatMode.UseStringFormat;
                                        gc.FormatString = "#0.000 \" %\"";
                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        //gc.InputMask = "Percent";

                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                //case "R": //Read-only Textbox
                                //    TextBox rb = new TextBox();
                                //    ctl = (Control)rb;
                                //    rb.ReadOnly = true;
                                //    rb.Width = 400;
                                //    prop = "Text";
                                //    break;

                                //case "Y": //Disabled Checkbox
                                //    CheckBox yb = new CheckBox();
                                //    ctl = (Control)yb;
                                //    yb.Enabled = false;
                                //    prop = "Checked";
                                //    break;

                                case "XW":
                                case "X": // Checkbox
                                    if (gr == null)
                                    {
                                        Janus.Windows.EditControls.UICheckBox xb = new Janus.Windows.EditControls.UICheckBox();
                                        //CheckBox xb = new CheckBox();
                                        ctl = (Control)xb;
                                        prop = ctlTypeRow.BindingProp;
                                        xb.Enabled = !arf.ReadOnly;
                                        xb.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
                                    }
                                    else
                                    {

                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.CheckBox);
                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
                                        if (gc.Width < 100)
                                            gc.Width = 100;
                                        //gc.AutoSize();
                                        gr.RootTable.Columns.Add(gc);
                                        gc.Selectable = !arf.ReadOnly;
                                    }
                                    break;
                                case "LB":
                                    Label lb1 = new Label();
                                    lb1.BackColor = System.Drawing.Color.Transparent;
                                    lb1.AutoEllipsis = true;
                                    lb1.Font = new Font("tahoma", lb1.Font.Size, FontStyle.Bold | FontStyle.Underline);

                                    lb1.Width = ctlTypeRow.Width;
                                    lb1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 12);
                                    lb1.MinimumSize = lb1.Size;
                                    lb1.MaximumSize = new System.Drawing.Size(lb1.Width, 20 * lb1.Height);
                                    lb1.AutoSize = true;
                                    lb1.Text = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                    if (!arf.IsSpecialParameterNull())
                                    {
                                        var cvt = new FontConverter();
                                        //        string s = cvt.ConvertToString(this.Font);
                                        Font fnt = cvt.ConvertFromInvariantString(arf.SpecialParameter) as Font;

                                        lb1.Font = fnt;
                                        lb1.Height = lb1.PreferredHeight;
                                    }
                                    customBinding = ctlTypeRow.IsCustomBinding;

                                    ctl = (Control)lb1;
                                    break;
                                case "TB":
                                case "ST":
                                case "MT":
                                default:   //text box
                                    ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType(arf.FieldType);
                                    if (ctlTypeRow == null)
                                        ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType("TB");
                                    if (gr == null)
                                    {
                                        Janus.Windows.GridEX.EditControls.MaskedEditBox txt = new Janus.Windows.GridEX.EditControls.MaskedEditBox();

                                        txt.Width = ctlTypeRow.Width;
                                        txt.ReadOnly = arf.ReadOnly;
                                        txt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
                                        if (arf.ReadOnly)
                                        {
                                            //txt.ForeColor = SystemColors.ControlDark;
                                            txt.BackColor = SystemColors.ControlLight;
                                        }
                                        if (!arf.IsMaskNull() && arf.Mask.Length > 0)
                                        {
                                            txt.CharacterCasing = CharacterCasing.Upper;
                                            txt.IncludeLiterals = false;
                                            if (arf.Mask == "PHONE")
                                            {
                                                if (MyACE.relTables.ContainsKey("Address0"))
                                                {
                                                    arf.Mask = FM.GetAddress().PhoneMask((atriumDB.AddressRow)MyACE.relTables["Address0"][0].Row);
                                                }
                                                else
                                                {
                                                    arf.Mask = "";
                                                }
                                            }
                                            else
                                            {
                                                txt.Mask = arf.Mask;
                                            }
                                        }
                                        txt.MaxLength = maxLen;
                                        ctl = (Control)txt;
                                        prop = ctlTypeRow.BindingProp;
                                    }
                                    else
                                    {
                                        gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
                                        gc.Caption = arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        gr.RootTable.Columns.Add(gc);
                                        gc.MaxLength = maxLen;
                                        Graphics grfx2 = flowLayoutPanel1.CreateGraphics();
                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 15;
                                        if (gc.Width < 80)
                                            gc.Width = 80;
                                        //gc.Width = 100;
                                        gc.Selectable = !arf.ReadOnly;
                                        if (!arf.IsMaskNull() && arf.Mask.Length > 0)
                                        {
                                            gc.CharacterCasing = CharacterCasing.Upper;
                                            gc.IncludeLiterals = false;
                                            if (arf.Mask == "PHONE")
                                            {
                                                if (MyACE.relTables.ContainsKey("Address0"))
                                                {
                                                    gc.InputMask = FM.GetAddress().PhoneMask((atriumDB.AddressRow)MyACE.relTables["Address0"][0].Row);
                                                }
                                                else
                                                {
                                                    gc.InputMask = "";
                                                }
                                            }
                                            else
                                            {
                                                gc.InputMask = arf.Mask;
                                            }
                                            gc.FormatMode = Janus.Windows.GridEX.FormatMode.UseInputMask;
                                        }

                                        if (arf.ReadOnly && gr.View == Janus.Windows.GridEX.View.CardView)
                                        {
                                            gc.CellStyle.BackColor = SystemColors.ControlLight;
                                            //gc.CellStyle.ForeColor = SystemColors.ControlDark;
                                            //JLL commented out for consistency. All readonly fields usually have control background with black forecolor text.
                                            //the controldark forecolor makes it look disabled rather than readonly (and selectable)
                                        }

                                    }
                                    break;
                            } //end switch (arf.FieldType)
                            if (gr != null)
                            {
                                if (arf.Required && !arf.ReadOnly)
                                {
                                    if (arf.TaskType != "P")
                                    {
                                        Janus.Windows.GridEX.GridEXFormatCondition fc = new Janus.Windows.GridEX.GridEXFormatCondition(gr.RootTable.Columns[arf.DBFieldName], Janus.Windows.GridEX.ConditionOperator.IsNull, null);
                                        fc.FormatStyle.BackColor = Color.Pink;
                                        //    string[] scols = arf.FieldName.Split(',');
                                        fc.TargetColumn = gr.RootTable.Columns[arf.DBFieldName];
                                        gr.RootTable.FormatConditions.Add(fc);
                                        gr.RootTable.Columns[arf.DBFieldName].Tag = "required";
                                        gr.RootTable.Columns[arf.DBFieldName].Caption += "*";

                                        gr.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(gr_CellEdited);

                                        foreach (DataRowView dr in MyACE.relTables[arf.ObjectAlias])
                                        {
                                            if (dr.Row.IsNull(arf.DBFieldName))
                                            {
                                                required.Add(dr.Row[dr.Row.Table.PrimaryKey[0]].ToString() + "_" + arf.DBFieldName);
                                            }
                                        }
                                    }
                                }


                            }
                            else if (gr == null)
                            {
                                Label lb = new Label();
                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "NOLABEL")
                                {
                                    lb.Visible = false;
                                    lb.Width = 0;
                                    ctl.Width = ctl.Width + LBLWIDTH + 6;
                                    if (arf.FieldType == "MC")
                                    {
                                        UserControls.ucMultiDropDown mdd = (UserControls.ucMultiDropDown)ctl;
                                        mdd.Middle = ctl.Width + 3;
                                        if (!mdd.DDColumn1Visible)
                                            mdd.DropDownColumn2Width = ctl.Width;
                                    }
                                }
                                else if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "2LINE")
                                {
                                    lb.Width = LBLWIDTH + 350;
                                    lb.AutoEllipsis = true;
                                    lb.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
                                    ctl.Width = ctl.Width + LBLWIDTH + 6;
                                    if (arf.FieldType == "MC")
                                    {
                                        UserControls.ucMultiDropDown mdd = (UserControls.ucMultiDropDown)ctl;
                                        mdd.Middle = ctl.Width + 3;
                                        if (!mdd.DDColumn1Visible)
                                            mdd.DropDownColumn2Width = ctl.Width;
                                    }
                                }
                                else
                                {
                                    if (arf.FieldType == "XW")
                                    {
                                        lb.Width = LBLWIDTH + 350 - 14;
                                        lb.MinimumSize = lb.Size;
                                        lb.MaximumSize = new System.Drawing.Size(lb.Width, lb.Height * 8);
                                        lb.AutoSize = true;
                                    }
                                    else
                                        lb.Width = LBLWIDTH;
                                    lb.AutoEllipsis = true;
                                    lb.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
                                    lb.Height = 25;

                                }
                                lb.Name = "lbl" + arf.ObjectAlias + arf.FieldName;

                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter != "NOLABEL" && arf.SpecialParameter != "2LINE" && arf.SpecialParameter.ToLower() != "hide" && !arf.SpecialParameter.ToLower().StartsWith("minmax"))
                                {
                                    var cvt = new FontConverter();
                                    //        string s = cvt.ConvertToString(this.Font);
                                    if (cvt.IsValid(arf.SpecialParameter))
                                    {
                                        Font fnt = cvt.ConvertFromInvariantString(arf.SpecialParameter) as Font;

                                        lb.Font = fnt;
                                        lb.Height = lb.PreferredHeight;
                                    }
                                }
                                if (arf.FieldType != "AD" && arf.FieldType != "CM" && arf.FieldType != "?I" && arf.FieldType != "LB")
                                {
                                    if (arf["Label" + FM.AtMng.AppMan.Language].ToString() != "")
                                    {
                                        flb.Controls.Add(lb);
                                        if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "2LINE")
                                        {
                                            flb.SetFlowBreak(lb, true);
                                        }
                                    }

                                }

                                if (!customBinding)
                                    ctl.DataBindings.Add(prop, MyACE.relTables[arf.ObjectAlias], arf.DBFieldName);

                                ctl.Name = arf.ObjectAlias + arf.FieldName;

                                if (arf.Required & !arf.ReadOnly && arf.FieldType != "LB")
                                {
                                    if (arf["Label" + FM.AtMng.AppMan.Language].ToString() == "")
                                        lb.Text = "";
                                    else
                                        lb.Text = arf["Label" + FM.AtMng.AppMan.Language].ToString() + "*:";
                                    if (MyACE.relTables[arf.ObjectAlias][0][arf.DBFieldName].ToString() == "" || customBinding)
                                    {

                                        UserControls.IRequiredCtl ireq = ctl as UserControls.IRequiredCtl;
                                        if (ireq == null)
                                        {
                                            if (ctl.Text == "")
                                            {
                                                ctl.BackColor = Color.Pink;
                                                required.Add(ctl.Name);

                                            }
                                        }
                                        else
                                        {
                                            if (!ireq.IsPopulated)
                                            {
                                                if (requiresAction == null)
                                                    requiresAction = ireq;

                                                ireq.ReqColor = Color.Pink;
                                                required.Add(ctl.Name);

                                            }
                                        }

                                    }

                                    ctl.Validated += new EventHandler(ctl_Validated);
                                    ctl.TextChanged += new EventHandler(ctl_TextChanged);

                                }
                                else
                                    lb.Text = arf["Label" + FM.AtMng.AppMan.Language].ToString() + ":";


                                //apply security when not in wizard
                                if (!WizardMode)
                                {
                                    if (secReadOnly)
                                    {
                                        ctl.Enabled = false;

                                    }
                                    else
                                    {
                                        //check field level perm if it exists
                                        appDB.ddFieldRow[] dfrs = (appDB.ddFieldRow[])Atmng.DB.ddField.Select("fieldname='" + arf.FieldName + "' and tablename='" + arf.ObjectName + "'", "");
                                        if (dfrs.Length == 1)
                                        {
                                            if (!dfrs[0].IsFeatureIdNull())
                                            {
                                                ctl.Enabled = Atmng.SecurityManager.CanUpdate(FM.CurrentFileId, (atSecurity.SecurityManager.Features)dfrs[0].FeatureId) != atSecurity.SecurityManager.LevelPermissions.No;
                                            }
                                        }

                                    }
                                }

                                //if (arf.Visible)
                                //{
                                flb.Controls.Add(ctl);

                                if (arf.FieldType != "LB")
                                {
                                    Label helpLbl = new Label();
                                    helpLbl.Width = 24;
                                    helpLbl.Margin = new Padding(0);
                                    janusSuperTip1.ClearToolTipArea();

                                    if (!arf.IsNull(UIHelper.Translate(FM, "HelpE")))
                                    {
                                        helpLbl.Image = LawMate.Properties.Resources.help;
                                        Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();
                                        //      jstSettings.HeaderText = "Help About " + arf["Label" + FM.AtMng.AppMan.Language].ToString();
                                        jstSettings.Text = arf[UIHelper.Translate(FM, "HelpE")].ToString();
                                        //      jstSettings.HeaderImage = LawMate.Properties.Resources.help;
                                        janusSuperTip1.SetSuperTip(helpLbl, jstSettings);
                                        //flb.Controls.Add(helpLbl);

                                    }
                                    flb.Controls.Add(helpLbl);
                                    flb.SetFlowBreak(helpLbl, true);
                                }
                                else
                                {
                                    flb.SetFlowBreak(ctl, true);
                                }
                                if (arf.Visible & !arf.ReadOnly && firstCtl == null)
                                    firstCtl = ctl;

                                //can't proceed because error in hidden field
                                if (arf.ReadOnly & !arf.Visible)
                                {
                                   // buttonNext.Enabled = false;
                                    Label stopLbl = new Label();
                                    stopLbl.AutoSize = true;
                                    stopLbl.Text = LawMate.Properties.Resources.ThereIsAnErrorInAReadOnlyHiddenRelatedField;
                                    flb.Controls.Add(stopLbl);
                                    flb.SetFlowBreak(stopLbl, true);
                                }
                                //}

                            }
                        }
                    }
                }
                if (ugb != null)
                    ugb.Height = flb.DisplayRectangle.Height + 15;

                MyHost.EnableButtons(required.Count);
            }
            //skip step
            if (vis == 0)
            {
                if(WizardMode)
                    MyHost.SkipStep();
            }
            else
            {
                //if (requiresAction != null)
                //    requiresAction.RequiredAction();

                if (firstCtl != null)
                    firstCtl.Focus();
            }



            //}
            //catch (Exception x)
            //{
            //    UIHelper.HandleUIException(x);
            //}


            //Application.OpenForms[0].Activate();
            //this.Activate();
        }

        private void DoMCC(ActivityConfig.ActivityFieldRow arf, ref Control ctl, ref string prop, ActivityConfig.ACControlTypeRow ctlTypeRow)
        {
            UserControls.ucMultiDropDown mdd = new UserControls.ucMultiDropDown();
            controlsToDispose.Add(mdd);
            mdd.Width = ctlTypeRow.Width;
            ctl = (Control)mdd;
            mdd.BackColor = System.Drawing.Color.Transparent;
            prop = ctlTypeRow.BindingProp;

            DataTable dt2 = MyACE.FM.Codes(arf.LookUp);
            string luv = arf.LookUp.ToUpper();

            if (FM.AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.FastDataEntry, false))
            {
                if (luv == "VLAWYERLIST" || luv == "LAWYERLIST" || luv == "OFFICERLIST" || luv == "VOFFICERLIST" || luv == "VOFFICERGDLIST" || luv == "VMEMBERLIST")
                {
                    mdd.Middle = 100;
                    mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
                    mdd.DisplayMember = dt2.Columns["fullname"].ColumnName;
                    mdd.Column1 = dt2.Columns["fullname"].ColumnName;
                    mdd.DropDownColumn1Width = 200;
                    mdd.DropDownColumn2Width = 200;
                    mdd.Column2 = dt2.Columns[UIHelper.Translate(FM, dt2.Columns[2].ColumnName)].ColumnName;
                }
                else
                {
                    mdd.Middle = 100;
                    mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
                    mdd.DisplayMember = dt2.Columns[0].ColumnName;// = dt2.Columns[UIHelper.Translate(FM, dt2.Columns[1].ColumnName)].ColumnName;
                    mdd.Column1 = dt2.Columns[0].ColumnName;
                    if (dt2.Columns[0].DataType == typeof(Int32))
                    {
                        mdd.DDColumn1Visible = false;
                        mdd.DropDownColumn2Width = 0;// mdd.Width;
                    }
                    mdd.Column2 = dt2.Columns[UIHelper.Translate(FM, dt2.Columns[1].ColumnName)].ColumnName;
                }
                mdd.Enabled = !arf.ReadOnly;
                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter == "filter")
                {

                    DataView dv = new DataView(dt2, "", "", DataViewRowState.CurrentRows);
                    mdd.SetDataBinding(dv, "");
                    mdd.SetFilter(arf.DefaultValue, arf.DefaultFieldName, MyACE.relTables[arf.DefaultObjectName][0].Row);
                }
                else
                {
                    mdd.SetDataBinding(dt2, "");

                }
                //  if (!arf.Required)
                mdd.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;

            }
            else
            {
                if (luv == "VLAWYERLIST" || luv == "LAWYERLIST" || luv == "OFFICERLIST" || luv == "VOFFICERLIST" || luv == "VOFFICERGDLIST" || luv == "VMEMBERLIST")
                {
                    mdd.Middle = 353;
                    mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
                    mdd.DisplayMember = dt2.Columns["fullname"].ColumnName;
                    mdd.Column1 = dt2.Columns["fullname"].ColumnName;
                    mdd.DropDownColumn1Width = 200;
                    mdd.DropDownColumn2Width = 200;
                    mdd.Column2 = dt2.Columns[UIHelper.Translate(FM, dt2.Columns[2].ColumnName)].ColumnName;
                }
                else
                {
                    mdd.Middle = 353;
                    mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
                    mdd.DisplayMember = dt2.Columns[UIHelper.Translate(FM, dt2.Columns[1].ColumnName)].ColumnName;
                    mdd.Column1 = dt2.Columns[0].ColumnName;
                    if (dt2.Columns[0].DataType == typeof(Int32))
                    {
                        mdd.DDColumn1Visible = false;
                        mdd.DropDownColumn2Width = 0;// mdd.Width;
                    }
                    mdd.Column2 = dt2.Columns[UIHelper.Translate(FM, dt2.Columns[1].ColumnName)].ColumnName;
                }
                mdd.Enabled = !arf.ReadOnly;
                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter == "filter")
                {

                    DataView dv = new DataView(dt2, "", "", DataViewRowState.CurrentRows);
                    mdd.SetDataBinding(dv, "");
                    mdd.SetFilter(arf.DefaultValue, arf.DefaultFieldName, MyACE.relTables[arf.DefaultObjectName][0].Row);
                }
                else
                {
                    mdd.SetDataBinding(dt2, "");

                }
                if (!arf.Required)
                    mdd.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
            }
        }

        void gr_CellUpdated(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            //handling of endedit for grid cardview when a change is made to a cell
            //in order to force calculations to update right away
            try
            {
                e.Column.GridEX.UpdateData();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        void gr_VisibleChanged(object sender, EventArgs e)
        {
           // return;
            try
            {
                Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
                SizeGrid(g);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private static void SizeGrid(Janus.Windows.GridEX.GridEX g)
        {
            if (g.RootTable != null)
            {
                int columnCount = g.RootTable.Columns.Count;
                if (g.View == Janus.Windows.GridEX.View.CardView)
                { // CARD VIEW
                    g.Height = columnCount * 25 + 68;

                }
                else
                {
                    //TABLE VIEW

                    //CALCULATE HEIGHT
                    g.Height = g.GetDataRows().Length * 19 + 42 + 32;

                    //CALCULATE WIDTH
                    int width = 20;
                    foreach (Janus.Windows.GridEX.GridEXColumn gec in g.RootTable.Columns)
                    {
                        if (gec.DropDown != null)
                        {

                            gec.DropDown.Columns[0].AutoSize();
                            if (gec.DropDown.Columns[0].Width > 500)
                                gec.Width = 500;
                            else
                                gec.Width = gec.DropDown.Columns[0].Width;

                        }
                        else
                        {
                            gec.AutoSize();

                        }
                        width += gec.Width;
                    }
                    g.Width = width;
                    int newWidth = 20;
                    if (g.GetDataRows().Length < 3 && g.Width < 250)
                    {
                        foreach (Janus.Windows.GridEX.GridEXColumn gec in g.RootTable.Columns)
                        {
                            if (gec.Width < 250)
                                gec.Width = 250;
                            newWidth += gec.Width;
                        }
                    }
                    if (newWidth != 20)
                        g.Width = newWidth;
                    
                }

            }
        }

        void gr_CellEdited(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.GridEX g = (Janus.Windows.GridEX.GridEX)sender;
                if (g.CurrentRow == null)
                    return;

                DataRowView dvr = (DataRowView)g.CurrentRow.DataRow;
                DataRow dr = dvr.Row;
                string skey = dr[dr.Table.PrimaryKey[0]].ToString() + "_" + e.Column.Key;

                if (g.CurrentRow.Cells[e.Column].Text != "")
                {

                    if (required.Contains(skey))
                        required.Remove(skey);
                }
                else
                {

                    if (!required.Contains(skey) && e.Column.Tag != null && e.Column.Tag.ToString() == "required")
                        required.Add(skey);
                }
            }
            catch (Exception x)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }

            MyHost.EnableButtons(required.Count);
        }

        void ValidateControl(object sender, EventArgs e)
        {


            Control ctl = (Control)sender;
            UserControls.IRequiredCtl ireq = ctl as UserControls.IRequiredCtl;
            bool ok = false;
            if (ireq == null)
            {
                if (ctl.Text != "")
                {
                    ctl.BackColor = Color.White;
                    ok = true;
                }
                else
                {
                    ctl.BackColor = Color.Pink;
                    ok = false;
                }

            }
            else
            {
                if (ireq.IsPopulated)
                {
                    ireq.ReqColor = Color.White;
                    ok = true;
                }
                else
                {
                    ireq.ReqColor = Color.Pink;
                    ok = false;
                }

            }
            if (ok)
            {
                if (required.Contains(ctl.Name))
                    required.Remove(ctl.Name);

            }
            else
            {
                if (!required.Contains(ctl.Name))
                    required.Add(ctl.Name);
            }
            MyHost.EnableButtons(required.Count);
        }

        void ctl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateControl(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        void ctl_Validated(object sender, EventArgs e)
        {
            try
            {
                ValidateControl(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }





    }

    //class oldRF
    //{
    //    public void DoRelFields(ActivityConfig.ACSeriesRow acSeries, int step)
    //    {

    //        firstCtl = null;
    //        const int LBLWIDTH = 250;

    //        //try
    //        //{
    //        flowLayoutPanel1.Controls.Clear();
    //        required.Clear();
    //        int vis = 0;

    //        //hook up error providers for each related table
    //        foreach (DataView dv in MyACE.relTables.Values)
    //        {
    //            ErrorProvider ep = new ErrorProvider();
    //            ep.ContainerControl = this;
    //            ep.DataSource = dv;

    //            //this.Controls.Add(ep);
    //        }

    //        //help panel text
    //        if (step >= 0)
    //        {
    //            string RelStepHelp = acSeries["Rel" + step.ToString() + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
    //            SetHelpPanel(RelStepHelp.Length > 0, RelStepHelp);
    //        }
    //        else if (step == -1)
    //        {
    //            string PromptStepHelp = acSeries["Prompt" + Atmng.AppMan.Language.Substring(0, 1).ToUpper()].ToString();
    //            SetHelpPanel(PromptStepHelp.Length > 0, PromptStepHelp);
    //        }

    //        if (!MyACE.skipBlock)
    //        {
    //            //create controls
    //            Janus.Windows.GridEX.GridEX gr = null;
    //            string gridObject = "";
    //            Janus.Windows.GridEX.GridEXColumn gc;
    //            foreach (ActivityConfig.ActivityFieldRow arf in fmCurrent.AtMng.acMng.DB.ActivityField.Select("ACSeriesId=" + acSeries.ACSeriesId.ToString() + " and TaskType in ('F','P') and step=" + step.ToString(), "seq"))
    //            {
    //                Control ctl = null;
    //                bool customBinding = false;
    //                string prop = "Text";

    //                if (gridObject != arf.ObjectAlias)
    //                {
    //                    gridObject = "";
    //                    gr = null;
    //                }
    //                int maxLen = 0;

    //                if (MyACE.relTables[arf.ObjectAlias].Count > 0)
    //                {
    //                    if (MyACE.relTables[arf.ObjectAlias].Table.Columns.Contains(arf.DBFieldName))
    //                        maxLen = MyACE.relTables[arf.ObjectAlias].Table.Columns[arf.DBFieldName].MaxLength;
    //                    if (maxLen == -1)
    //                        maxLen = 0;

    //                    if (arf.Visible || MyACE.relTables[arf.ObjectAlias][0].Row.GetColumnError(arf.DBFieldName) != "")
    //                    {
    //                        ActivityConfig.ACControlTypeRow ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType(arf.FieldType);

    //                        vis++;
    //                        switch (arf.FieldType)
    //                        {

    //                            case "AG":
    //                                ucSSTAppealGround ucsstag = new ucSSTAppealGround();
    //                                ucsstag.FM = fmCurrent;
    //                                ctl = (Control)ucsstag;
    //                                customBinding = ctlTypeRow.IsCustomBinding;
    //                                break;
    //                            case "CM":
    //                                ucSSTCaseMatter ucsstcm = new ucSSTCaseMatter();
    //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "PROMPT")
    //                                {
    //                                    ucsstcm.PromptIssueMode = true;
    //                                }
    //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "SETOUTCOME")
    //                                {
    //                                    ucsstcm.IsSettingOutcome = true;
    //                                }
    //                                if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "PROMPTNOISSUE")
    //                                {
    //                                    ucsstcm.PromptNoIssueMode = true;
    //                                }
    //                                ucsstcm.DataSource = MyACE.relTables[arf.ObjectAlias];
    //                                ucsstcm.FM = fmCurrent;
    //                                // fmCurrent.GetSSTMng();
    //                                //ucsstcm.Width = 800;
    //                                ctl = (Control)ucsstcm;
    //                                customBinding = ctlTypeRow.IsCustomBinding;
    //                                break;
    //                            case "?F": //browse for file
    //                                ucFileSelectBox ucfsb = new ucFileSelectBox();
    //                                ucfsb.AtMng = fmCurrent.AtMng;

    //                                ucfsb.Width = ctlTypeRow.Width;
    //                                ucfsb.Enabled = !arf.ReadOnly;
    //                                ctl = (Control)ucfsb;
    //                                prop = ctlTypeRow.BindingProp;
    //                                break;
    //                            case "?O": // browse for office
    //                                ucOfficeSelectBox ucosb = new ucOfficeSelectBox();
    //                                ucosb.AtMng = fmCurrent.AtMng;

    //                                ucosb.Width = ctlTypeRow.Width;
    //                                ucosb.Enabled = !arf.ReadOnly;
    //                                ctl = (Control)ucosb;
    //                                prop = ctlTypeRow.BindingProp;
    //                                break;
    //                            case "?I": // browse for issue
    //                                ucIssueSelectBoxRF uciss = new ucIssueSelectBoxRF();
    //                                uciss.FM = fmCurrent;

    //                                uciss.Width = ctlTypeRow.Width;
    //                                uciss.Enabled = !arf.ReadOnly;
    //                                ctl = (Control)uciss;
    //                                prop = ctlTypeRow.BindingProp;
    //                                break;

    //                            case "?C":  //browse for contact
    //                                ucContactSelectBox uccsb = new ucContactSelectBox();
    //                                uccsb.FM = fmCurrent;
    //                                uccsb.WLQuery = WorkloadQuery.NotApplicable;
    //                                uccsb.Width = ctlTypeRow.Width;
    //                                uccsb.Enabled = !arf.ReadOnly;
    //                                ctl = (Control)uccsb;
    //                                prop = ctlTypeRow.BindingProp;
    //                                break;
    //                            case "?W":  //browse for contact - showWorkload
    //                                ucContactSelectBox uccsbw = new ucContactSelectBox();
    //                                uccsbw.FM = fmCurrent;
    //                                uccsbw.Width = ctlTypeRow.Width;
    //                                uccsbw.WLQuery = (WorkloadQuery)Enum.Parse(typeof(WorkloadQuery), arf.SpecialParameter);
    //                                uccsbw.Enabled = !arf.ReadOnly;
    //                                ctl = (Control)uccsbw;
    //                                prop = ctlTypeRow.BindingProp;
    //                                break;
    //                            case "?":
    //                                ucDocUpload ucdu = new ucDocUpload();
    //                                ucdu.DocMng = MyACE.FM.GetDocMng();
    //                                ucdu.Document = (docDB.DocumentRow)MyACE.relTables[arf.ObjectAlias][0].Row;

    //                                ucdu.Width = ctlTypeRow.Width;
    //                                ucdu.Enabled = !arf.ReadOnly;
    //                                ctl = (Control)ucdu;
    //                                prop = "";
    //                                customBinding = ctlTypeRow.IsCustomBinding;
    //                                break;
    //                            case "?D": //browse for doc
    //                                //?
    //                                docDB.DocumentRow newDoc = (docDB.DocumentRow)MyACE.relTables[arf.ObjectAlias][0].Row;
    //                                //newDoc.FileId = FM.CurrentFile.FileId;
    //                                string f = "";
    //                                openFileDialog1.FileName = "";
    //                                if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
    //                                {
    //                                    if (MessageBox.Show(LawMate.Properties.Resources.ActivityExpectsExternalDocumentToBeUploaded, LawMate.Properties.Resources.NoDocumentSelected, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    //                                    {
    //                                        if (this.openFileDialog1.ShowDialog() == DialogResult.Cancel)
    //                                        {
    //                                            MessageBox.Show(LawMate.Properties.Resources.NewActivityWizardCancelled);

    //                                            buttonCancel.PerformClick();
    //                                        }
    //                                        else
    //                                            f = this.openFileDialog1.FileName;
    //                                    }
    //                                    else
    //                                    {
    //                                        MessageBox.Show(LawMate.Properties.Resources.NewActivityWizardCancelled);
    //                                        buttonCancel.PerformClick();
    //                                    }
    //                                }
    //                                else
    //                                    f = this.openFileDialog1.FileName;

    //                                if (f != "")
    //                                {
    //                                    //try
    //                                    //{
    //                                    MyACE.FM.GetDocMng().GetDocument().LoadFile(newDoc, f);

    //                                    newDoc.icon = UIHelper.GetFileIcon(f);
    //                                    //}
    //                                    //catch (Exception x)
    //                                    //{
    //                                    //    UIHelper.HandleUIException(x);
    //                                    //    buttonCancel.PerformClick();
    //                                    //}
    //                                }
    //                                else
    //                                {
    //                                    if (ABP != null && ABP.CurrentACE != null)
    //                                    {
    //                                        ABP.CurrentACE.Cancel();
    //                                        ABP.CurrentACE = null;
    //                                    }
    //                                    return;
    //                                }
    //                                Janus.Windows.GridEX.EditControls.EditBox xrb = new Janus.Windows.GridEX.EditControls.EditBox();
    //                                //TextBox xrb = new TextBox();
    //                                ctl = (Control)xrb;
    //                                //xrb.Text = f;
    //                                xrb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                xrb.ReadOnly = true;
    //                                xrb.Enabled = false;
    //                                xrb.Width = ctlTypeRow.Width;
    //                                prop = ctlTypeRow.BindingProp;

    //                                break;
    //                            case "CV":

    //                                gr = new Janus.Windows.GridEX.GridEX();

    //                                gridObject = arf.ObjectAlias;

    //                                gr.Width = ctlTypeRow.Width;
    //                                gr.BackColor = Color.FromArgb(219, 235, 255);
    //                                gr.View = Janus.Windows.GridEX.View.CardView;
    //                                gr.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
    //                                gr.AllowCardSizing = false;
    //                                gr.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
    //                                gr.CardViewGridlines = Janus.Windows.GridEX.CardViewGridlines.FieldsOnly;
    //                                gr.CardInnerSpacing = 5;
    //                                gr.AutoEdit = true;
    //                                gr.EnsureVisible();
    //                                gr.CardSpacing = 6;
    //                                gr.CardWidth = 290;
    //                                gr.ExpandableCards = false;

    //                                //if we set tab to navigate columns, the tab key can never tab out of the control.
    //                                //use arrows within grid to navigate, tab to exit control.
    //                                gr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
    //                                gr.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
    //                                gr.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
    //                                gr.CellUpdated += new Janus.Windows.GridEX.ColumnActionEventHandler(gr_CellUpdated);
    //                                //handle height setting in VisibleChanged so we can count total columns.
    //                                gr.VisibleChanged += new EventHandler(gr_VisibleChanged);

    //                                gr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                gr.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;

    //                                gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
    //                                gr.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;


    //                                ctl = (Control)gr;
    //                                ctl.Name = arf.ObjectAlias + arf.FieldName;

    //                                flowLayoutPanel1.Controls.Add(ctl);
    //                                flowLayoutPanel1.SetFlowBreak(ctl, true);

    //                                gr.DataSource = MyACE.relTables[arf.ObjectAlias];

    //                                Janus.Windows.GridEX.GridEXTable gt2 = new Janus.Windows.GridEX.GridEXTable();
    //                                gr.RootTable = gt2;
    //                                gr.CardCaptionPrefix = (string)arf[UIHelper.Translate(fmCurrent, "LabelEng")];// LawMate.Properties.Resources.MultipleSelectEdit;
    //                                gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;
    //                                gr.RootTable.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;

    //                                string[] columns2 = arf.DBFieldName.Split(',');

    //                                foreach (string s in columns2)
    //                                {
    //                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "hide")
    //                                    {
    //                                        //don't add arf as grid column
    //                                    }
    //                                    else
    //                                    {
    //                                        gc = new Janus.Windows.GridEX.GridEXColumn(s, Janus.Windows.GridEX.ColumnType.Text);
    //                                        gc.Caption = gr.RootTable.Caption;
    //                                        gr.RootTable.Columns.Add(gc);
    //                                        gc.Selectable = !arf.ReadOnly;
    //                                    }
    //                                }


    //                                break;
    //                            case "M":
    //                                //multi-row so use grid
    //                                gr = new Janus.Windows.GridEX.GridEX();
    //                                gridObject = arf.ObjectAlias;
    //                                gr.Height = 150;
    //                                //gr.Left = 250;
    //                                gr.Width = ctlTypeRow.Width;

    //                                gr.GroupByBoxVisible = false;
    //                                gr.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                gr.OfficeScrollBarStyle = Janus.Windows.GridEX.OfficeScrollBarStyle.Light;
    //                                gr.GridLines = Janus.Windows.GridEX.GridLines.None;
    //                                gr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.True;
    //                                gr.FocusStyle = Janus.Windows.GridEX.FocusStyle.Solid;
    //                                gr.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
    //                                gr.HideSelection = Janus.Windows.GridEX.HideSelection.HighlightInactive;
    //                                gr.AutoEdit = true;
    //                                gr.UpdateMode = Janus.Windows.GridEX.UpdateMode.CellUpdate;
    //                                gr.EnterKeyBehavior = Janus.Windows.GridEX.EnterKeyBehavior.NextCell;
    //                                gr.VisibleChanged += new EventHandler(gr_VisibleChanged);
    //                                ctl = (Control)gr;
    //                                ctl.Name = arf.ObjectAlias + arf.FieldName;

    //                                flowLayoutPanel1.Controls.Add(ctl);
    //                                flowLayoutPanel1.SetFlowBreak(ctl, true);

    //                                gr.DataSource = MyACE.relTables[arf.ObjectAlias];

    //                                Janus.Windows.GridEX.GridEXTable gt = new Janus.Windows.GridEX.GridEXTable();
    //                                gr.RootTable = gt;
    //                                if (!arf.IsLabelEngNull())
    //                                {
    //                                    gr.RootTable.Caption = (string)arf[UIHelper.Translate(fmCurrent, "LabelEng")];// LawMate.Properties.Resources.MultipleSelectEdit;
    //                                    gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.True;

    //                                    //gr.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
    //                                    //gr.RootTable.HeaderLines = 3;

    //                                    gr.RootTable.TableHeaderFormatStyle.FontBold = Janus.Windows.GridEX.TriState.True;
    //                                }
    //                                else
    //                                {
    //                                    gr.RootTable.TableHeader = Janus.Windows.GridEX.InheritableBoolean.False;
    //                                }
    //                                string[] columns = arf.DBFieldName.Split(',');

    //                                foreach (string s in columns)
    //                                {
    //                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToLower() == "hide")
    //                                    {
    //                                        //don't add arf as grid column
    //                                    }
    //                                    else
    //                                    {
    //                                        gc = new Janus.Windows.GridEX.GridEXColumn(s, Janus.Windows.GridEX.ColumnType.Text);
    //                                        //gc.AutoSize();
    //                                        gc.Caption = gr.RootTable.Caption;
    //                                        Graphics grfx2 = CreateGraphics();
    //                                        gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 15;
    //                                        if (gc.Width < 80)
    //                                            gc.Width = 80;

    //                                        gr.RootTable.Columns.Add(gc);
    //                                        gc.Selectable = !arf.ReadOnly;
    //                                    }
    //                                }
    //                                break;

    //                            case "A":    //Calendar Combo
    //                                if (gr == null)
    //                                {
    //                                    Janus.Windows.CalendarCombo.CalendarCombo jcb = new Janus.Windows.CalendarCombo.CalendarCombo();
    //                                    ctl = (Control)jcb;
    //                                    prop = ctlTypeRow.BindingProp;
    //                                    jcb.Width = ctlTypeRow.Width;
    //                                    jcb.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
    //                                    jcb.CustomFormat = "yyyy'/'MM'/'dd";
    //                                    jcb.Text = "";
    //                                    jcb.ReadOnly = arf.ReadOnly;
    //                                    jcb.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2010;
    //                                    if (arf.ReadOnly)
    //                                    {
    //                                        jcb.BackColor = SystemColors.Control;
    //                                        jcb.ForeColor = SystemColors.ControlDark;
    //                                    }
    //                                    if (arf.Required)
    //                                    {
    //                                        jcb.ShowNullButton = false;
    //                                        jcb.Nullable = false;
    //                                    }
    //                                    else
    //                                    {
    //                                        jcb.ShowNullButton = true;
    //                                        jcb.Nullable = true;
    //                                    }
    //                                }
    //                                else
    //                                {
    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    gc.EditType = Janus.Windows.GridEX.EditType.CalendarCombo;
    //                                    if (arf.Required)
    //                                        gc.CalendarNoneButtonVisible = Janus.Windows.GridEX.TriState.False;
    //                                    else
    //                                        gc.CalendarNoneButtonVisible = Janus.Windows.GridEX.TriState.True;

    //                                    gc.FormatString = "yyyy'/'MM'/'dd";
    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();
    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }
    //                                break;
    //                            //case "AR":    //Calendar Combo - Read Only
    //                            //    Janus.Windows.CalendarCombo.CalendarCombo jcbro = new Janus.Windows.CalendarCombo.CalendarCombo();
    //                            //    ctl = (Control)jcbro;
    //                            //    prop = "BindableValue";
    //                            //    jcbro.Enabled = false;
    //                            //    jcbro.Width = 100;
    //                            //    jc
    //                            //    jcbro.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
    //                            //    jcbro.CustomFormat = "yyyy'/'MM'/'dd";
    //                            //    break;
    //                            //case "Q":   //prompt drop down
    //                            //    ComboBox cbq = new ComboBox();
    //                            //    ctl = (Control)cbq;
    //                            //    prop = "SelectedValue";
    //                            //    cbq.DropDownStyle = ComboBoxStyle.DropDownList;
    //                            //    cbq.Width = 400;
    //                            //    cbq.Enabled = !arf.ReadOnly;
    //                            //    //need to set list LawMate.Properties

    //                            //    cbq.ValueMember = "id";
    //                            //    cbq.DisplayMember = "prompt";
    //                            //    cbq.DataSource = MyACE.Prompts[arf.LookUp];
    //                            //    break;
    //                            case "C":   //Enabled Dropdown
    //                                Janus.Windows.EditControls.UIComboBox cb = new Janus.Windows.EditControls.UIComboBox();
    //                                //ComboBox cb = new ComboBox();
    //                                ctl = (Control)cb;
    //                                prop = ctlTypeRow.BindingProp;
    //                                cb.ComboStyle = Janus.Windows.EditControls.ComboStyle.DropDownList; //.DropDownStyle = ComboBoxStyle.DropDownList;
    //                                cb.Width = ctlTypeRow.Width;
    //                                cb.Enabled = !arf.ReadOnly;
    //                                cb.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
    //                                //need to set list LawMate.Properties
    //                                DataTable dt = MyACE.FM.Codes(arf.LookUp);
    //                                cb.ValueMember = dt.PrimaryKey[0].ColumnName;// dt.Columns[0].ColumnName;
    //                                cb.DisplayMember = dt.Columns[UIHelper.Translate(fmCurrent, dt.Columns[1].ColumnName)].ColumnName;
    //                                cb.DataSource = new DataView(dt);
    //                                break;

    //                            case "T":   //Multiline Textbox
    //                                //  TextBox tb = new TextBox();
    //                                Janus.Windows.GridEX.EditControls.EditBox tb = new Janus.Windows.GridEX.EditControls.EditBox();
    //                                ctl = (Control)tb;
    //                                tb.Multiline = true;
    //                                tb.AcceptsReturn = true;
    //                                tb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                tb.ScrollBars = ScrollBars.Vertical;
    //                                tb.Height = 65;
    //                                tb.Width = ctlTypeRow.Width;
    //                                tb.ReadOnly = arf.ReadOnly;
    //                                if (arf.ReadOnly)
    //                                {
    //                                    tb.BackColor = SystemColors.ControlLight;
    //                                    tb.ForeColor = SystemColors.ControlDark;
    //                                }
    //                                tb.MaxLength = maxLen;

    //                                prop = ctlTypeRow.BindingProp;
    //                                break;
    //                            case "MC":
    //                                if (gr == null)
    //                                {
    //                                    UserControls.ucMultiDropDown mdd = new UserControls.ucMultiDropDown();
    //                                    mdd.Width = ctlTypeRow.Width;
    //                                    ctl = (Control)mdd;
    //                                    mdd.BackColor = System.Drawing.Color.Transparent;
    //                                    prop = ctlTypeRow.BindingProp;

    //                                    DataTable dt2 = MyACE.FM.Codes(arf.LookUp);
    //                                    string luv = arf.LookUp.ToUpper();

    //                                    if (luv == "VLAWYERLIST" || luv == "LAWYERLIST" || luv == "OFFICERLIST" || luv == "VOFFICERLIST" || luv == "VOFFICERGDLIST" || luv == "VMEMBERLIST")
    //                                    {
    //                                        mdd.Middle = 353;
    //                                        mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
    //                                        mdd.DisplayMember = dt2.Columns["fullname"].ColumnName;
    //                                        mdd.Column1 = dt2.Columns["fullname"].ColumnName;
    //                                        mdd.DropDownColumn1Width = 200;
    //                                        mdd.DropDownColumn2Width = 200;
    //                                        mdd.Column2 = dt2.Columns[UIHelper.Translate(fmCurrent, dt2.Columns[2].ColumnName)].ColumnName;
    //                                    }
    //                                    else
    //                                    {
    //                                        mdd.Middle = 353;
    //                                        mdd.ValueMember = dt2.PrimaryKey[0].ColumnName;
    //                                        mdd.DisplayMember = dt2.Columns[UIHelper.Translate(fmCurrent, dt2.Columns[1].ColumnName)].ColumnName;
    //                                        mdd.Column1 = dt2.Columns[0].ColumnName;
    //                                        if (dt2.Columns[0].DataType == typeof(Int32))
    //                                        {
    //                                            mdd.DDColumn1Visible = false;
    //                                            mdd.DropDownColumn2Width = mdd.Width;
    //                                        }
    //                                        mdd.Column2 = dt2.Columns[UIHelper.Translate(fmCurrent, dt2.Columns[1].ColumnName)].ColumnName;
    //                                    }
    //                                    mdd.Enabled = !arf.ReadOnly;
    //                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter == "filter")
    //                                    {
    //                                        DataView dv = new DataView(dt2, arf.DefaultValue + "=" + MyACE.relTables[arf.DefaultObjectName][0][arf.DefaultFieldName].ToString(), "", DataViewRowState.CurrentRows);
    //                                        mdd.SetDataBinding(dv, "");
    //                                    }
    //                                    else
    //                                    {
    //                                        mdd.SetDataBinding(dt2, "");

    //                                    }
    //                                    if (!arf.Required)
    //                                        mdd.ComboType = Janus.Windows.GridEX.ComboStyle.Combo;
    //                                }
    //                                else
    //                                {

    //                                    DataTable dt3 = MyACE.FM.Codes(arf.LookUp);
    //                                    Janus.Windows.GridEX.GridEXDropDown grdDD = gr.DropDowns.Add("dd" + arf.LookUp);

    //                                    grdDD.ValueMember = dt3.PrimaryKey[0].ColumnName;
    //                                    grdDD.DisplayMember = dt3.Columns[UIHelper.Translate(fmCurrent, dt3.Columns[1].ColumnName)].ColumnName;
    //                                    grdDD.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
    //                                    grdDD.Columns.Add(grdDD.DisplayMember, Janus.Windows.GridEX.ColumnType.Text);

    //                                    gr.DropDowns["dd" + arf.LookUp].SetDataBinding(dt3, "");
    //                                    // gr.DropDowns.Add(grdDD);

    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    gc.EditType = Janus.Windows.GridEX.EditType.MultiColumnCombo;

    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();

    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.DropDown = gr.DropDowns["dd" + arf.LookUp];
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }
    //                                break;
    //                            case "AD":
    //                                UserControls.ucAddress ucadd = new UserControls.ucAddress();
    //                                ctl = (Control)ucadd;
    //                                ucadd.ColumnTwoLeftPositionOffset = LBLWIDTH - 85;
    //                                ucadd.Width = ctlTypeRow.Width;
    //                                ucadd.DataSource = MyACE.relTables[arf.ObjectAlias];
    //                                ucadd.Enabled = !arf.ReadOnly;
    //                                ucadd.FM = fmCurrent;
    //                                customBinding = ctlTypeRow.IsCustomBinding;
    //                                break;
    //                            //case "SN":
    //                            //    Janus.Windows.GridEX.EditControls.MaskedEditBox meb = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
    //                            //    prop = "Text";
    //                            //    meb.IncludeLiterals = false;
    //                            //    meb.Width = 400;
    //                            //    meb.Mask = "### ### ###";
    //                            //    meb.PromptChar = ' ';
    //                            //    meb.Text = "";
    //                            //    meb.ReadOnly = arf.ReadOnly;
    //                            //    ctl = (Control)meb;
    //                            //    break;
    //                            case "B": //Currency Field
    //                                if (gr == null)
    //                                {
    //                                    Janus.Windows.GridEX.EditControls.NumericEditBox neb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
    //                                    ctl = (Control)neb;
    //                                    neb.Width = ctlTypeRow.Width;
    //                                    neb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency;
    //                                    neb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
    //                                    neb.ReadOnly = arf.ReadOnly;
    //                                    neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                    if (arf.ReadOnly)
    //                                    {
    //                                        neb.BackColor = SystemColors.ControlLight;
    //                                        neb.ForeColor = SystemColors.ControlDark;
    //                                    }
    //                                    prop = ctlTypeRow.BindingProp;
    //                                }
    //                                else
    //                                {
    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
    //                                    gc.FormatString = "c";
    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    gc.InputMask = "Currency";
    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();
    //                                    gr.RootTable.Columns.Add(gc);

    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }

    //                                break;
    //                            case "IM":
    //                                if (gr == null)
    //                                {
    //                                }
    //                                else
    //                                {
    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.BoundImage);

    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    gc.CellStyle.ImageHorizontalAlignment = Janus.Windows.GridEX.ImageHorizontalAlignment.Center;


    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();
    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }
    //                                break;
    //                            case "N": //number Field
    //                                if (gr == null)
    //                                {
    //                                    Janus.Windows.GridEX.EditControls.NumericEditBox neb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
    //                                    ctl = (Control)neb;
    //                                    neb.Width = ctlTypeRow.Width;
    //                                    neb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.General;
    //                                    neb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
    //                                    neb.ReadOnly = arf.ReadOnly;
    //                                    neb.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
    //                                    neb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                    if (arf.ReadOnly)
    //                                    {
    //                                        neb.BackColor = SystemColors.ControlLight;
    //                                        neb.ForeColor = SystemColors.ControlDark;
    //                                    }
    //                                    prop = ctlTypeRow.BindingProp;
    //                                }
    //                                else
    //                                {
    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);

    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    //gc.InputMask = "Percent";

    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();
    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }
    //                                break;
    //                            case "P": //Percent Field
    //                                if (gr == null)
    //                                {
    //                                    Janus.Windows.GridEX.EditControls.NumericEditBox peb = new Janus.Windows.GridEX.EditControls.NumericEditBox();
    //                                    ctl = (Control)peb;
    //                                    peb.Width = ctlTypeRow.Width;
    //                                    peb.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Percent;
    //                                    peb.NullBehavior = Janus.Windows.GridEX.NumericEditNullBehavior.AllowDBNull;
    //                                    peb.FormatString = "##0.000 %";
    //                                    peb.ReadOnly = arf.ReadOnly;
    //                                    peb.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                    if (arf.ReadOnly)
    //                                    {
    //                                        peb.BackColor = SystemColors.ControlLight;
    //                                        peb.ForeColor = SystemColors.ControlDark;
    //                                    }
    //                                    prop = ctlTypeRow.BindingProp;
    //                                }
    //                                else
    //                                {
    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
    //                                    gc.FormatString = "#0.000 %";
    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    //gc.InputMask = "Percent";

    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();
    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }
    //                                break;
    //                            //case "R": //Read-only Textbox
    //                            //    TextBox rb = new TextBox();
    //                            //    ctl = (Control)rb;
    //                            //    rb.ReadOnly = true;
    //                            //    rb.Width = 400;
    //                            //    prop = "Text";
    //                            //    break;

    //                            //case "Y": //Disabled Checkbox
    //                            //    CheckBox yb = new CheckBox();
    //                            //    ctl = (Control)yb;
    //                            //    yb.Enabled = false;
    //                            //    prop = "Checked";
    //                            //    break;

    //                            case "XW":
    //                            case "X": // Checkbox
    //                                if (gr == null)
    //                                {
    //                                    Janus.Windows.EditControls.UICheckBox xb = new Janus.Windows.EditControls.UICheckBox();
    //                                    //CheckBox xb = new CheckBox();
    //                                    ctl = (Control)xb;
    //                                    prop = ctlTypeRow.BindingProp;
    //                                    if (!arf.IsLookUpNull())
    //                                    {
    //                                        prop = "BindableValue";
    //                                        xb.ThreeState = false;
    //                                        xb.UncheckedValue = System.DBNull.Value;
    //                                        // value will be the first value in the lookup list
    //                                        xb.CheckedValue = arf.SpecialParameter;
    //                                    }
    //                                    xb.Enabled = !arf.ReadOnly;
    //                                    xb.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010;
    //                                }
    //                                else
    //                                {

    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.CheckBox);
    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 12;
    //                                    if (gc.Width < 100)
    //                                        gc.Width = 100;
    //                                    //gc.AutoSize();
    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                }
    //                                break;
    //                            case "LB":
    //                                Label lb1 = new Label();
    //                                lb1.BackColor = System.Drawing.Color.Transparent;
    //                                lb1.AutoEllipsis = true;
    //                                lb1.Width = ctlTypeRow.Width;
    //                                lb1.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
    //                                lb1.MinimumSize = lb1.Size;
    //                                lb1.MaximumSize = new System.Drawing.Size(lb1.Width, 20 * lb1.Height);
    //                                lb1.AutoSize = true;
    //                                lb1.Text = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                if (!arf.IsSpecialParameterNull())
    //                                {
    //                                    var cvt = new FontConverter();
    //                                    //        string s = cvt.ConvertToString(this.Font);
    //                                    Font fnt = cvt.ConvertFromInvariantString(arf.SpecialParameter) as Font;

    //                                    lb1.Font = fnt;
    //                                    lb1.Height = lb1.PreferredHeight;
    //                                }
    //                                customBinding = ctlTypeRow.IsCustomBinding;

    //                                ctl = (Control)lb1;
    //                                break;
    //                            case "TB":
    //                            case "ST":
    //                            case "MT":
    //                            default:   //text box
    //                                ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType(arf.FieldType);
    //                                if (ctlTypeRow == null)
    //                                    ctlTypeRow = Atmng.acMng.DB.ACControlType.FindByACControlType("TB");
    //                                if (gr == null)
    //                                {
    //                                    Janus.Windows.GridEX.EditControls.MaskedEditBox txt = new Janus.Windows.GridEX.EditControls.MaskedEditBox();

    //                                    txt.Width = ctlTypeRow.Width;
    //                                    txt.ReadOnly = arf.ReadOnly;
    //                                    txt.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010;
    //                                    if (arf.ReadOnly)
    //                                    {
    //                                        txt.ForeColor = SystemColors.ControlDark;
    //                                        txt.BackColor = SystemColors.ControlLight;
    //                                    }
    //                                    if (!arf.IsMaskNull() && arf.Mask.Length > 0)
    //                                    {
    //                                        txt.CharacterCasing = CharacterCasing.Upper;
    //                                        txt.IncludeLiterals = false;
    //                                        if (arf.Mask == "PHONE")
    //                                        {
    //                                            if (MyACE.relTables.ContainsKey("Address0"))
    //                                            {
    //                                                arf.Mask = fmCurrent.GetAddress().PhoneMask((atriumDB.AddressRow)MyACE.relTables["Address0"][0].Row);
    //                                            }
    //                                            else
    //                                            {
    //                                                arf.Mask = "";
    //                                            }
    //                                        }
    //                                        else
    //                                        {
    //                                            txt.Mask = arf.Mask;
    //                                        }
    //                                    }
    //                                    txt.MaxLength = maxLen;
    //                                    ctl = (Control)txt;
    //                                    prop = ctlTypeRow.BindingProp;
    //                                }
    //                                else
    //                                {
    //                                    gc = new Janus.Windows.GridEX.GridEXColumn(arf.DBFieldName, Janus.Windows.GridEX.ColumnType.Text);
    //                                    gc.Caption = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    gr.RootTable.Columns.Add(gc);
    //                                    gc.MaxLength = maxLen;
    //                                    Graphics grfx2 = CreateGraphics();
    //                                    gc.Width = (int)grfx2.MeasureString(gc.Caption, gr.Font).Width + 15;
    //                                    if (gc.Width < 80)
    //                                        gc.Width = 80;
    //                                    //gc.Width = 100;
    //                                    gc.Selectable = !arf.ReadOnly;
    //                                    if (arf.ReadOnly && gr.View == Janus.Windows.GridEX.View.CardView)
    //                                    {
    //                                        gc.CellStyle.BackColor = SystemColors.ControlLight;
    //                                        gc.CellStyle.ForeColor = SystemColors.ControlDark;
    //                                    }

    //                                }
    //                                break;
    //                        } //end switch (arf.FieldType)
    //                        if (gr != null)
    //                        {
    //                            if (arf.Required && !arf.ReadOnly)
    //                            {
    //                                if (arf.TaskType != "P")
    //                                {
    //                                    Janus.Windows.GridEX.GridEXFormatCondition fc = new Janus.Windows.GridEX.GridEXFormatCondition(gr.RootTable.Columns[arf.DBFieldName], Janus.Windows.GridEX.ConditionOperator.IsNull, null);
    //                                    fc.FormatStyle.BackColor = Color.Pink;
    //                                    //    string[] scols = arf.FieldName.Split(',');
    //                                    fc.TargetColumn = gr.RootTable.Columns[arf.DBFieldName];
    //                                    gr.RootTable.FormatConditions.Add(fc);
    //                                    gr.RootTable.Columns[arf.DBFieldName].Caption += "*";

    //                                    gr.CellEdited += new Janus.Windows.GridEX.ColumnActionEventHandler(gr_CellEdited);

    //                                    foreach (DataRowView dr in MyACE.relTables[arf.ObjectAlias])
    //                                    {
    //                                        if (dr.Row.IsNull(arf.DBFieldName))
    //                                        {
    //                                            required.Add(dr.Row[dr.Row.Table.PrimaryKey[0]].ToString() + "_" + arf.DBFieldName);
    //                                        }
    //                                    }
    //                                }
    //                            }


    //                        }
    //                        else if (gr == null)
    //                        {
    //                            Label lb = new Label();
    //                            if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "NOLABEL")
    //                            {
    //                                lb.Visible = false;
    //                                lb.Width = 0;
    //                                ctl.Width = ctl.Width + LBLWIDTH + 6;
    //                                if (arf.FieldType == "MC")
    //                                {
    //                                    UserControls.ucMultiDropDown mdd = (UserControls.ucMultiDropDown)ctl;
    //                                    mdd.Middle = ctl.Width + 3;
    //                                    if (!mdd.DDColumn1Visible)
    //                                        mdd.DropDownColumn2Width = ctl.Width;
    //                                }
    //                            }
    //                            else if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "2LINE")
    //                            {
    //                                lb.Width = LBLWIDTH + 350;
    //                                lb.AutoEllipsis = true;
    //                                lb.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
    //                                ctl.Width = ctl.Width + LBLWIDTH + 6;
    //                                if (arf.FieldType == "MC")
    //                                {
    //                                    UserControls.ucMultiDropDown mdd = (UserControls.ucMultiDropDown)ctl;
    //                                    mdd.Middle = ctl.Width + 3;
    //                                    if (!mdd.DDColumn1Visible)
    //                                        mdd.DropDownColumn2Width = ctl.Width;
    //                                }
    //                            }
    //                            else
    //                            {
    //                                if (arf.FieldType == "XW")
    //                                {
    //                                    lb.Width = LBLWIDTH + 350 - 14;
    //                                    lb.MinimumSize = lb.Size;
    //                                    lb.MaximumSize = new System.Drawing.Size(lb.Width, lb.Height * 8);
    //                                    lb.AutoSize = true;
    //                                }
    //                                else
    //                                    lb.Width = LBLWIDTH;
    //                                lb.AutoEllipsis = true;
    //                                lb.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);

    //                            }
    //                            lb.Name = "lbl" + arf.ObjectAlias + arf.FieldName;

    //                            if (!arf.IsSpecialParameterNull() && arf.SpecialParameter != "NOLABEL" && arf.SpecialParameter != "2LINE" && arf.SpecialParameter.ToLower() != "hide")
    //                            {
    //                                var cvt = new FontConverter();
    //                                //        string s = cvt.ConvertToString(this.Font);
    //                                if (cvt.IsValid(arf.SpecialParameter))
    //                                {
    //                                    Font fnt = cvt.ConvertFromInvariantString(arf.SpecialParameter) as Font;

    //                                    lb.Font = fnt;
    //                                    lb.Height = lb.PreferredHeight;
    //                                }
    //                            }
    //                            if (arf.FieldType != "AD" && arf.FieldType != "CM" && arf.FieldType != "?I" && arf.FieldType != "LB")
    //                            {
    //                                if (arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() != "")
    //                                {
    //                                    flowLayoutPanel1.Controls.Add(lb);
    //                                    if (!arf.IsSpecialParameterNull() && arf.SpecialParameter.ToUpper() == "2LINE")
    //                                    {
    //                                        flowLayoutPanel1.SetFlowBreak(lb, true);
    //                                    }
    //                                }

    //                            }

    //                            if (!customBinding)
    //                                ctl.DataBindings.Add(prop, MyACE.relTables[arf.ObjectAlias], arf.DBFieldName);

    //                            if (arf.Required & !arf.ReadOnly && arf.FieldType != "LB")
    //                            {
    //                                if (arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() == "")
    //                                    lb.Text = "";
    //                                else
    //                                    lb.Text = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() + "*:";
    //                                if (MyACE.relTables[arf.ObjectAlias][0][arf.DBFieldName].ToString() == "" || customBinding)
    //                                {

    //                                    UserControls.IRequiredCtl ireq = ctl as UserControls.IRequiredCtl;
    //                                    if (ireq == null)
    //                                    {
    //                                        if (ctl.Text == "")
    //                                        {
    //                                            ctl.BackColor = Color.Pink;
    //                                            required.Add(ctl);

    //                                        }
    //                                    }
    //                                    else
    //                                    {
    //                                        if (!ireq.IsPopulated)
    //                                        {
    //                                            if (requiresAction == null)
    //                                                requiresAction = ireq;


    //                                            ireq.ReqColor = Color.Pink;
    //                                            required.Add(ctl);


    //                                        }
    //                                    }

    //                                }

    //                                ctl.Validated += new EventHandler(ctl_Validated);
    //                                ctl.TextChanged += new EventHandler(ctl_TextChanged);

    //                            }
    //                            else
    //                                lb.Text = arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString() + ":";

    //                            ctl.Name = arf.ObjectAlias + arf.FieldName;
    //                            //if (arf.Visible)
    //                            //{
    //                            flowLayoutPanel1.Controls.Add(ctl);

    //                            if (arf.FieldType != "LB")
    //                            {
    //                                Label helpLbl = new Label();
    //                                helpLbl.Width = 24;
    //                                helpLbl.Margin = new Padding(0);
    //                                janusSuperTip1.ClearToolTipArea();

    //                                if (!arf.IsNull(UIHelper.Translate(fmCurrent, "HelpE")))
    //                                {
    //                                    helpLbl.Image = LawMate.Properties.Resources.help;
    //                                    Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();
    //                                    //      jstSettings.HeaderText = "Help About " + arf["Label" + fmCurrent.AtMng.AppMan.Language].ToString();
    //                                    jstSettings.Text = arf[UIHelper.Translate(fmCurrent, "HelpE")].ToString();
    //                                    //      jstSettings.HeaderImage = LawMate.Properties.Resources.help;
    //                                    janusSuperTip1.SetSuperTip(helpLbl, jstSettings);
    //                                    //flowLayoutPanel1.Controls.Add(helpLbl);

    //                                }
    //                                flowLayoutPanel1.Controls.Add(helpLbl);
    //                                flowLayoutPanel1.SetFlowBreak(helpLbl, true);
    //                            }
    //                            else
    //                            {
    //                                flowLayoutPanel1.SetFlowBreak(ctl, true);
    //                            }
    //                            if (arf.Visible & !arf.ReadOnly && firstCtl == null)
    //                                firstCtl = ctl;

    //                            //can't proceed because error in hidden field
    //                            if (arf.ReadOnly & !arf.Visible)
    //                            {
    //                                buttonNext.Enabled = false;
    //                                Label stopLbl = new Label();
    //                                stopLbl.AutoSize = true;
    //                                stopLbl.Text = LawMate.Properties.Resources.ThereIsAnErrorInAReadOnlyHiddenRelatedField;
    //                                flowLayoutPanel1.Controls.Add(stopLbl);
    //                                flowLayoutPanel1.SetFlowBreak(stopLbl, true);
    //                            }
    //                            //}

    //                        }
    //                    }
    //                }
    //            }


    //            if (required.Count > 0)
    //                buttonNext.Enabled = false;
    //        }
    //        //skip step
    //        if (vis == 0)
    //        {
    //            skipping = true;
    //            if (buttonBack.Focused)
    //            {
    //                this.InvokeOnClick(buttonBack, new EventArgs());
    //                //                        CurrentStep = Back();
    //            }
    //            else
    //            {
    //                this.InvokeOnClick(buttonNext, new EventArgs());
    //                // CurrentStep = Next();
    //            }
    //        }
    //        else
    //        {
    //            //if (requiresAction != null)
    //            //    requiresAction.RequiredAction();

    //            if (firstCtl != null)
    //                firstCtl.Focus();
    //        }

    //        //}
    //        //catch (Exception x)
    //        //{
    //        //    UIHelper.HandleUIException(x);
    //        //}


    //        //Application.OpenForms[0].Activate();
    //        //this.Activate();
    //    }

    //}

}
