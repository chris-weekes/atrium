using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using lmDatasets;

namespace LawMate.Admin
{
    public partial class fTemplates : fBase
    {
        atriumBE.FileManager myFM;
        atriumBE.DocManager myDM;
        DataTable dtUsedInSteps;


        public fTemplates()
        {
            InitializeComponent();
        }
        public fTemplates(Form f)
            : base(f)
        {
            InitializeComponent();
            AtMng.GetTemplate();
            dtUsedInSteps = new DataTable("dtUsedInSteps");
            dtUsedInSteps.Columns.Add("ReferenceType", typeof(string));
            dtUsedInSteps.Columns.Add("StepCode", typeof(string));
            dtUsedInSteps.Columns.Add("ActivityNameEng", typeof(string));
            dtUsedInSteps.Columns.Add("Status", typeof(string));
            dtUsedInSteps.Columns.Add("SeriesCode", typeof(string));
            dtUsedInSteps.Columns.Add("SeriesDescEng", typeof(string));
            dtUsedInSteps.Columns.Add("ACSeriesId", typeof(int));
            dtUsedInSteps.Columns.Add("SeriesId", typeof(int));
            dtUsedInSteps.Columns.Add("ActivityFieldID", typeof(int));
            dtUsedInSteps.Columns.Add("Obsolete", typeof(bool));
            gridEX2.DataSource = dtUsedInSteps;
            gridEX2.DataMember = "";
            UIHelper.SetDataTableAsGridDataSource(gridEX2, dtUsedInSteps);
        }

        private void fTemplates_Load(object sender, EventArgs e)
        {
            myFM = AtMng.GetTemplate().FM;
            myDM = myFM.GetDocMng();
            ucDoc1.Init(myDM);

            UIHelper.ComboBoxInit(myFM.Codes("vDocType"), mccCommType, myFM);
            UIHelper.ComboBoxInit(myFM.Codes("TemplateLayoutStyle"), mccLayoutStyle, myFM);
            templateBindingSource.DataSource = AtMng.DB;
            templateBindingSource.CurrentChanged += new EventHandler(templateBindingSource_CurrentChanged);
            templateBindingSource.ResetBindings(false);

            templateGridEX.MoveFirst();

            cmdInsertTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        }


        private appDB.TemplateRow CurrentRow()
        {
            if (templateBindingSource.Current != null)
                return (appDB.TemplateRow)((DataRowView)templateBindingSource.Current).Row;
            else
                return null;
        }

        private void New(string fileExtention)
        {
            appDB.TemplateRow tr = (appDB.TemplateRow)AtMng.GetTemplate().Add(null);
            CurrentDocRow = AtMng.GetTemplate().GetTemplateDoc(tr);
            switch (fileExtention.ToUpper())
            {
                case "HTML":
                    CurrentDocRow.DocContentRow.Ext = ".html";
                    break;
                case "TXT":
                    CurrentDocRow.DocContentRow.Ext = ".txt";
                    break;
                default:
                    CurrentDocRow.DocContentRow.Ext = ".rtf";
                    break;
            }

            templateBindingSource.Position = templateBindingSource.Find("TemplateId", tr.TemplateId);
        }

        private void Cancel()
        {
            EditDocContents(false);
            UIHelper.Cancel(templateBindingSource, AtMng.DB.Template);
            ucDoc1.Cancel();
        }

        private void Save()
        {
            if (AtMng.DB.Template.HasErrors || myDM.DB.Document.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(AtMng.DB);
            }
            else
            {
                try
                {

                    this.templateBindingSource.EndEdit();
                    ucDoc1.EndEdit();

                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetTemplate());
                    bp.AddForUpdate(myDM.GetDocContent());
                    bp.AddForUpdate(myDM.GetDocument());

                    bp.Update();


                    EditDocContents(false);
                    templateGridEX.Focus();
                    //causes currentchanged on binding source to fire - changing order
                    //Atmng.DB.Template.AcceptChanges();

                    //myDM.DB.Document.AcceptChanges();
                    //myDM.DB.DocContent.AcceptChanges();


                }
                catch (Exception x)
                {

                    throw new Exception("Transaction Rolled Back", x);
                }
            }
        }

        private void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {

                    docDB.DocumentRow dr = AtMng.GetTemplate().GetTemplateDoc(CurrentRow());

                    CurrentRow().Delete();
                    if (dr != null)
                        dr.Delete();

                    this.templateBindingSource.EndEdit();
                    atLogic.BusinessProcess bp = AtMng.GetBP();
                    bp.AddForUpdate(AtMng.GetTemplate());
                    bp.AddForUpdate(myDM.GetDocContent());
                    bp.AddForUpdate(myDM.GetDocument());

                    bp.Update();

                }
            }
            catch (Exception x)
            {
                throw new Exception("Transaction Rolled Back", x);
            }
        }

        private void SelectAllFlaggedTemplatesForExport()
        {
            foreach (appDB.TemplateRow tr in AtMng.DB.Template)
            {
                if (tr.FlagForExport)
                    tr.Export = true;
                else
                    tr.Export = false;
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars[0];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "cmdChangeCode":
                        if (MessageBox.Show("Do you want to update all occurences of this template code?  Make sure you have saved any workflow changes first.", "TEMPLATES", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            AtMng.GetTemplate().ChangeTemplateCode(ebBaseTemplate.Text, editBox1.Text);
                        }
                        break;
                    case "cmdSelectAllFlaggedDocs":
                        SelectAllFlaggedTemplatesForExport();
                        break;
                    case "cmdCancel":
                        Cancel();
                        break;
                    case "cmdDelete":
                        Delete();
                        break;
                    case "cmdNewRTFTemplate":
                        New("RTF");
                        break;
                    case "cmdNewHTMLTemplate":
                        New("HTML");
                        break;
                    case "cmdNewTextTemplate":
                        New("TXT");
                        break;
                    case "cmdSave":
                        Save();
                        break;
                    case "cmdExport":
                        Export();
                        break;
                    case "cmdImport":
                        Import();
                        break;
                    case "cmdClone":
                        Clone();
                        break;
                    case "cmdClearSelectedDocs":
                        ClearSelectedDocs();
                        break;
                    case "cmdPreviewDoc":
                        ToggleDocPreview(cmdPreviewDoc.IsChecked);
                        break;

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ClearSelectedDocs()
        {
            templateGridEX.UpdateData();
            templateBindingSource.EndEdit();
            foreach (appDB.TemplateRow tr in AtMng.DB.Template.Rows)
            {
                tr.Export = false;
            }
        }

        bool DisplayDocPreview = true;
        private void ToggleDocPreview(bool hide)
        {
            DisplayDocPreview = hide;
        }

        private void Export()
        {
            templateGridEX.CurrentRow.EndEdit();
            templateGridEX.UpdateData();

            appDB.TemplateRow[] selectedTemplates = (appDB.TemplateRow[])AtMng.DB.Template.Select("Export=True");
            if (selectedTemplates.Length == 0)
            {
                MessageBox.Show("You have not selected any templates to export.");
                return;
            }

            fTemplateVersionTag fVT = new fTemplateVersionTag(selectedTemplates);
            DialogResult dr = fVT.ShowDialog(this);
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("The Template Export was cancelled.", "Export Cancelled", MessageBoxButtons.OK);
                return;
            }


            saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FileName = "{0}_templates" + DateTime.Today.ToString("yyyyMMdd") + ".xml";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string saveas = saveFileDialog1.FileName;

                using (fWait fw = new fWait("Exporting templates, please wait."))
                {

                    int iPart = 1;
                    int iMax = 30000000;
                    int iCount = 0;
                    TemplateExchange tex = new TemplateExchange();
                    foreach (appDB.TemplateRow tr in selectedTemplates)
                    {
                        tr.ExportedDate = fVT.ExportDate;
                        tr.Tag = fVT.TagVersion;
                        if (fVT.ClearFlag)
                            tr.FlagForExport = false;

                        tex.trs.ImportRow(tr);
                        if (tex.dcrs.FindByDocId(tr.DocID) == null)
                        {
                            docDB.DocumentRow dr1 = myDM.DB.Document.FindByDocId(tr.DocID);
                            tex.drs.ImportRow(dr1);

                            docDB.DocContentRow dcr1 = myDM.DB.DocContent.FindByDocId(dr1.DocRefId);

                            if (dcr1 == null)
                                myDM.GetDocContent().Load(dr1.DocRefId, dr1.CurrentVersion); //WI 73696 - added current version

                            dcr1=myDM.DB.DocContent.FindByDocId(dr1.DocRefId);
                            iCount+=dcr1.Size;
                            tex.dcrs.ImportRow(dcr1);
                        }
                        if (iCount >= iMax)
                        {
                            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(TemplateExchange));
                            // To write to a file, create a StreamWriter object.
                            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(String.Format(saveas, iPart));
                            mySerializer.Serialize(myWriter, tex);
                            myWriter.Close();
                            Save();

                            iCount = 0;
                            iPart++;
                            tex = new TemplateExchange();
                        }
                    }


                    System.Xml.Serialization.XmlSerializer mySerializer1 = new System.Xml.Serialization.XmlSerializer(typeof(TemplateExchange));
                    // To write to a file, create a StreamWriter object.
                    System.IO.StreamWriter myWriter1 = new System.IO.StreamWriter(String.Format(saveas, iPart));
                    mySerializer1.Serialize(myWriter1, tex);
                    myWriter1.Close();
                    Save();
                }
            }
            else
                MessageBox.Show("The Template Export was cancelled.", "Export Cancelled", MessageBoxButtons.OK);
        }

        private void Import()
        {
            openFileDialog1.Filter = "XML files (*.xml)|*.xml|Zip files (*.zip)|*.zip|All files (*.*)|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                {
                    ImportZip(openFileDialog1.FileName);
                }
                else
                {
                    ImportXML(openFileDialog1.FileName);
                }
            }
        }
        private void ImportZip(string fileName)
        {

            //needs .net 4.5
            //using (fWait fw = new fWait("Importing templates, please wait."))
            //{
            //    using (FileStream zipToOpen = new FileStream(@"c:\users\exampleuser\release.zip", FileMode.Open))
            //    {
            //        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            //        {

            //            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(TemplateExchange));
            //            // To read the file, create a FileStream.
            //            System.IO.FileStream myFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
            //            // Call the Deserialize method and cast to the object type.
            //            TemplateExchange tex = (TemplateExchange)mySerializer.Deserialize(myFileStream);
            //            myFileStream.Close();

            //            UpdateTemplates(tex);
            //        }
            //    }
            //}
        }
        private void ImportXML(string fileName)
        {
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(TemplateExchange));
            // To read the file, create a FileStream.
            System.IO.FileStream myFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            TemplateExchange tex = (TemplateExchange)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            fTemplateVersionTag fVT = new fTemplateVersionTag(tex.trs);
            DialogResult dr = fVT.ShowDialog(this);
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show("The Template Import operation was cancelled.", "Import Cancelled", MessageBoxButtons.OK);

            }
            else
            {
                using (fWait fw = new fWait("Importing templates, please wait."))
                {
                    UpdateTemplates(tex);
                }
            }
        }

        private void UpdateTemplates(TemplateExchange tex)
        {
            atriumBE.ACManager.ImportTable(myDM.DB.Document, tex.drs);
            //need to load doccontent records
            foreach (docDB.DocContentRow dcr in tex.dcrs)
            {
                myDM.GetDocContent().Load(dcr.DocId, null);// myDM.DB.Document.FindByDocId(dcr.DocId).CurrentVersion); //WI 73696 - added current version
            }
            atriumBE.ACManager.ImportTable(myDM.DB.DocContent, tex.dcrs);
            atriumBE.ACManager.ImportTable(AtMng.DB.Template, tex.trs);

            atLogic.BusinessProcess bpD = AtMng.GetBP();

            bpD.AddForUpdate(myDM.DB.DocContent);
            bpD.AddForUpdate(myDM.DB.Document);
            bpD.AddForUpdate(AtMng.DB.Template);

            bpD.Update();
        }

        private void Clone()
        {
            if (CurrentRow() == null)
            {
                MessageBox.Show("No current template on binding source.");
                return;
            }

            appDB.TemplateRow trCurrent = CurrentRow();
            appDB.TemplateRow trCopy = (appDB.TemplateRow)AtMng.GetTemplate().Add(null);
            trCopy.LetterName = trCurrent.LetterName + "COPY";
            trCopy.LetterDescEng = "(Copy of) " + trCurrent.LetterDescEng;
            trCopy.LetterDescFre = "(Copie de) " + trCurrent.LetterDescFre;

            docDB.DocumentRow docCurrent = AtMng.GetTemplate().GetTemplateDoc(trCurrent);
            docDB.DocContentRow docContentCurrent = docCurrent.DocContentRow;

            docDB.DocumentRow docCopy = AtMng.GetTemplate().GetTemplateDoc(trCopy);
            docDB.DocContentRow docContentCopy = docCopy.DocContentRow;

            docCopy.CommMode = docCurrent.CommMode;
            docCopy.efSubject = docCurrent.efSubject;
            docCopy.efType = docCurrent.efType;

            docContentCopy.Contents = docContentCurrent.Contents;
            docContentCopy.Ext = docContentCurrent.Ext;

            CurrentDocRow = docCopy;
            templateBindingSource.Position = templateBindingSource.Find("TemplateId", trCopy.TemplateId);
        }

        bool pnlMetaAutoHidden = false;
        bool LeftWasAutoHidden = false;
        private void EditDocContents(bool EditOn)
        {
            if (!DisplayDocPreview)
                return;

            if (EditOn)
            {
                ucDoc1.ForceTextControl = false;
              //  ucDoc1.AllowUserCompose = true;
                ucDoc1.EditMode = UserControls.ucDoc.EditModeEnum.Compose;
                ucDoc1.Preview();
                //set it to modified so that the update date gets changed even if only doccontent get editted
                if (CurrentRow().RowState == DataRowState.Unchanged)
                    CurrentRow().SetModified();

                CurrentRow().FlagForExport = true;
                cmdEditContents.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdInsertTag.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                templateGridEX.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Black;
                templateGridEX.RootTable.RowFormatStyle.ForeColor = SystemColors.Control;
                LeftWasAutoHidden = pnlLeft.AutoHide;
                pnlLeft.AutoHide = true;
                pnlMeta.AutoHide = true; 
            }
            else
            {
                ucDoc1.ForceTextControl = true;
             //   ucDoc1.AllowUserCompose = false;
                ucDoc1.EditMode = UserControls.ucDoc.EditModeEnum.Read;
                ucDoc1.Preview();
                cmdEditContents.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                cmdInsertTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                templateGridEX.OfficeColorScheme = Janus.Windows.GridEX.OfficeColorScheme.Blue;
                templateGridEX.RootTable.RowFormatStyle.ForeColor = SystemColors.WindowText;
                pnlLeft.AutoHide = LeftWasAutoHidden;
                pnlMeta.AutoHide = pnlMetaAutoHidden;
            }

        //    ucDoc1.Enabled = EditOn;
            templateGridEX.Enabled = !EditOn;
            // ucDoc1.Preview();

        }

        private void VerifyTemplateTags()
        {
            ucDoc1.EndEdit();
            lbTagVerify.Items.Clear();
            string templateText = CurrentDocRow.DocContentRow.ContentsAsText;

            //for testing and debugging
            string sPath = AtMng.AppMan.LawMatePath + CurrentRow().LetterName + ".xsl";
            System.IO.File.WriteAllText(sPath, myFM.AtMng.GetTemplate().PreParseVerify(templateText));

            string rtfData = templateText;

            int position = 0;
            int posEndTag = 0;
            string prefix;

            int ifCount = 0;
            int elseCount = 0;
            int endifCount = 0;
            int repeatCount = 0, endrepeatCount = 0;

            lbTagVerify.BeginUpdate();
            while (rtfData.IndexOf("[", position) != -1)
            {
                position = rtfData.IndexOf("[", position);
                posEndTag = rtfData.IndexOf("]", position);
                prefix = rtfData.Substring(position + 1, posEndTag - position - 1);

                if (prefix != "Normal" && prefix != "NC")
                {
                    if (prefix.ToLower().StartsWith("endif")) { endifCount++; }
                    else if (prefix.ToLower().StartsWith("else")) { elseCount++; }
                    else if (prefix.ToLower().StartsWith("repeat")) { repeatCount++; }
                    else if (prefix.ToLower().StartsWith("value")) { }
                    else if (prefix.ToLower().StartsWith("nvalue")) { }
                    else if (prefix.ToLower().StartsWith("include")) { }
                    else if (prefix.ToLower().StartsWith("if")) { ifCount++; }
                    else if (prefix.ToLower().StartsWith("end repeat")) { endrepeatCount++; }
                    else if (prefix.ToLower().StartsWith("special")) { }
                    else
                    {
                        prefix = "???" + prefix;
                    }
                    foreach (var c in prefix)
                    {
                        if (char.IsControl(c))
                        {
                            prefix = "*" + prefix;
                        }
                    }

                    lbTagVerify.Items.Add(prefix);
                }
                position++;
            }
            if (ifCount != elseCount | ifCount != endifCount | elseCount != endifCount)
                MessageBox.Show("The if, else and endif statements are mismatched", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (endrepeatCount != repeatCount)
                MessageBox.Show("The repeat and end repeat statements are mismatched", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            position = 0;
            posEndTag = 0;
            while (rtfData.IndexOf("((", position) != -1)
            {
                position = rtfData.IndexOf("((", position);
                posEndTag = rtfData.IndexOf("))", position);
                prefix = rtfData.Substring(position + 1, posEndTag - position - 1);

                if (prefix != "Normal")
                    lbTagVerify.Items.Add(prefix);

                position++;
            }

            lbTagVerify.EndUpdate();

            pnlTagParse.Closed = false;
        }

        private void HookupDocToTemplate()
        {
            fBrowseDocs fBrowseDoc = new fBrowseDocs(AtMng);
            fBrowseDoc.FindFile(myFM.CurrentFile.FileId);
            DialogResult dRes = fBrowseDoc.ShowDialog(this);
            if (dRes == DialogResult.OK && fBrowseDoc.SelectedDocument != null)
            {
                docDB.DocumentRow docToLink = fBrowseDoc.SelectedDocument;
                CurrentRow().DocID = docToLink.DocId;
                Save();
                templateBindingSource.Position = templateBindingSource.Find("TemplateId", CurrentRow().TemplateId);
            }
        }

        private bool DoTemplateInView(string ViewName, string ListName)
        {
            bool rTemplateUsed = false;
            ActivityConfig.ActivityFieldRow[] ViewAFRRows = (ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select("objectname='Document' and fieldname='templatecode' and lookup='" + ViewName + "'");
            foreach (ActivityConfig.ActivityFieldRow afr in ViewAFRRows)
            {
                dtUsedInSteps.Rows.Add(ListName, afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                rTemplateUsed = true;
            }
            return rTemplateUsed;

        }

        docDB.DocumentRow CurrentDocRow;
        private void templateBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                lbTagVerify.Items.Clear();
                //lbACsUsingTemplate.Items.Clear();
                dtUsedInSteps.Clear();

                bool TemplateIsUsed = false;

                CurrentDocRow = AtMng.GetTemplate().GetTemplateDoc(CurrentRow());


                if (!CurrentRow().IsNull("LetterName"))
                {
                    string baseTemplateCode = CurrentRow().LetterName;
                    if (CurrentRow().LetterName.IndexOf("-") != -1)
                        baseTemplateCode = CurrentRow().LetterName.Substring(0, CurrentRow().LetterName.IndexOf("-"));

                    ebBaseTemplate.Text = baseTemplateCode;
                    if (baseTemplateCode == CurrentRow().LetterName)
                    {
                        cmdChangeCode.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                    }
                    else
                    {
                        cmdChangeCode.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    }
                    gridEX2.RootTable.Caption = baseTemplateCode + " is used by following Workflow Steps:";

                    //find all related fields that reference base template and add to Steps That Reference Template datatable
                    ActivityConfig.ActivityFieldRow[] afRows = (ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select("objectname='Document' and fieldname='templatecode' and (defaultvalue='" + baseTemplateCode + "' or defaultvalue like'" + baseTemplateCode + "-%')");
                    foreach (ActivityConfig.ActivityFieldRow afr in afRows)
                    {
                        dtUsedInSteps.Rows.Add("0B", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                        TemplateIsUsed = true;
                    }

                    //find direct uses
                    if (baseTemplateCode != CurrentRow().LetterName)
                    {
                        afRows = (ActivityConfig.ActivityFieldRow[])AtMng.acMng.DB.ActivityField.Select("objectname='Document' and fieldname='templatecode' and defaultvalue='" + CurrentRow().LetterName + "'");
                        foreach (ActivityConfig.ActivityFieldRow afr in afRows)
                        {
                            dtUsedInSteps.Rows.Add("0D", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                            TemplateIsUsed = true;
                        }
                    }

                    //see if template is used in one of four lists, and if so, verify which related fields reference that view that relates to list.

                    if (CurrentRow().AboutDebtor) //GE List
                    {
                        bool u1 = DoTemplateInView("vTemplateList1", "L1"); //returns whether template is referenced
                        if (!TemplateIsUsed) // if not already referenced, set to return value of u1
                            TemplateIsUsed = u1;
                    }

                    if (CurrentRow().AboutAgent) //GP List
                    {
                        bool u1 = DoTemplateInView("vTemplateList2", "L2"); //returns whether template is referenced
                        if (!TemplateIsUsed) // if not already referenced, set to return value of u1
                            TemplateIsUsed = u1;
                    }

                    if (CurrentRow().HQ) //AD List
                    {
                        bool u1 = DoTemplateInView("vTemplateList3", "L3"); //returns whether template is referenced
                        if (!TemplateIsUsed) // if not already referenced, set to return value of u1
                            TemplateIsUsed = u1;
                    }

                    if (CurrentRow().Agent) //List 4
                    {
                        bool u1 = DoTemplateInView("vTemplateList4", "L4"); //returns whether template is referenced
                        if (!TemplateIsUsed) // if not already referenced, set to return value of u1
                            TemplateIsUsed = u1;
                    }

                    if (TemplateIsUsed)
                        cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    else
                        cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                }


                if (DisplayDocPreview)
                {

                    if (CurrentDocRow != null)
                    {
                        pnlContents.Closed = false;
                     //   ucDoc1.Enabled = false;


                        switch (CurrentDocRow.DocContentRow.Ext.ToLower())
                        {
                            case ".rtf":
                                cmdInsertTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                                cmdVerifyDocTag.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                                break;
                            case ".html":
                                cmdInsertTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                                cmdVerifyDocTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                                break;
                            case ".txt":
                                cmdInsertTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                                cmdVerifyDocTag.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                                break;
                        }
                        if (ucDoc1.DocRecord == null || ucDoc1.DocRecord != null && ucDoc1.DocRecord.DocId != CurrentDocRow.DocId)
                        {
                            ucDoc1.Datasource = new DataView(CurrentDocRow.Table, "Docid=" + CurrentDocRow.DocId.ToString(), "", DataViewRowState.CurrentRows);
                            ucDoc1.Preview();
                        }
                    }
                    else
                    {
                        ucDoc1.Clear();
                        pnlContents.Closed = true;
                        MessageBox.Show("An error has occurred.  No document could be found for this template.  Delete the template record and create a new one.");
                        cmdDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                    }
                }
                else
                {
                    ucDoc1.Clear();
                    pnlContents.Closed = true;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }



        private void templateGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(templateGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiCommandManager2_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                switch (e.Command.Key)
                {
                    case "cmdLinkToDifferentDoc":
                        HookupDocToTemplate();
                        break;
                    case "cmdEditContents":
                        EditDocContents(true);
                        break;
                    case "cmdVerifyDocTag":
                        VerifyTemplateTags();
                        break;
                    case "cmdInsertTag":
                        string sc = "";
                        if (dtUsedInSteps.Select("Status<>'OBS' and Obsolete=0").Length > 0)
                        {
                            sc = dtUsedInSteps.Select("Status<>'OBS' and Obsolete=0", "ReferenceType,Status")[0][1].ToString();
                        }
                        fTagPicker frmTagPicker = new fTagPicker(AtMng, sc, ucDoc1);
                        frmTagPicker.Show(this);
                        //frmTagPicker.ShowDialog(this);
                        //if (frmTagPicker.DialogResult == DialogResult.OK)
                        //    ucDoc1.WriteContentToDoc(frmTagPicker.TagToInsert);
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void templateGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.Cells["LetterName"].Value != null)
                {
                    string tCode = e.Row.Cells["LetterName"].Value.ToString();
                    int posDash = tCode.IndexOf("-");
                    if (posDash != -1)
                    {
                        e.Row.Cells["TemplatePrefix"].Value = tCode.Substring(0, posDash);
                    }
                    else // no dash
                    {
                        e.Row.Cells["TemplatePrefix"].Value = e.Row.Cells["LetterName"].Value.ToString();
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void gridEX2_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                if (e.Column.Key == "StepCode")
                {
                    if (gridEX2.CurrentRow != null)
                    {
                        int acseriesid = (int)gridEX2.CurrentRow.Cells["AcSeriesId"].Value;
                        int seriesid = (int)gridEX2.CurrentRow.Cells["SeriesId"].Value;
                        int afrid = (int)gridEX2.CurrentRow.Cells["ActivityFieldID"].Value;

                        MainAdminForm.MoreInfoRelField(seriesid, acseriesid, afrid);
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void timFMHeartbeat_Tick(object sender, EventArgs e)
        {
            try
            {
                atriumBE.FileManager fm = AtMng.GetFile(myFM.CurrentFile.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }

    [Serializable]
    public class TemplateExchange
    {

        public appDB.TemplateDataTable trs = new appDB.TemplateDataTable();


        public docDB.DocContentDataTable dcrs = new docDB.DocContentDataTable();


        public docDB.DocumentDataTable drs = new docDB.DocumentDataTable();
    }
}