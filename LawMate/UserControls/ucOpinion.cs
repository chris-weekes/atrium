using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;

 namespace LawMate
{
    public partial class ucOpinion : ucBase
    {
        DataView dvRequest;
        DataView dvOpinion;
        bool HasOpinionDoc = false;
        bool HasRequestDoc = false;
        fBrowseDocs OpenDocDialog;
        
        public ucOpinion()
        {
            InitializeComponent();
        }

        public void bindOpinionData(lmDatasets.Advisory.OpinionDataTable a)
        {
            ucMultiDropDown1.SetDataBinding(FM.Codes("LawyerList"), "");
            UIHelper.ComboBoxInit("OpinionType", mccOpinionType, FM);
            ucContactSelectBox1.FM = FM;
            ucOfficeSelectBox1.AtMng = FM.AtMng;

            this.opinionBindingSource.DataSource = a.DataSet;
            this.opinionBindingSource.DataMember = a.TableName;
            
            atriumBE.DocManager dm = FM.GetDocMng();
            OpenDocDialog = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;
            
            //ucDoc1.OpenDocDialog = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;
            //ucDoc1.Init(dm);
            ucDocView1.OpenDocDialog = ((fMain)Application.OpenForms["fMain"]).OpenDocDialog;
            ucDocView1.Init(dm);

            Advisory.OpinionRow or = CurrentRow();
            LoadDocs(or);

            a.ColumnChanged += new DataColumnChangeEventHandler(a_ColumnChanged);
            FM.GetAdvisoryMng().GetOpinion().OnUpdate += new atLogic.UpdateEventHandler(ucOpinion_OnUpdate);

            ApplySecurity(CurrentRow());
        }

        private void LoadDocs(Advisory.OpinionRow opnrow)
        {
            if (!opnrow.IsDocIdNull())
                dvOpinion = LoadDoc(opnrow.DocId, true);
            if (!opnrow.IsRequestDocIdNull())
                dvRequest = LoadDoc(opnrow.RequestDocId, false);

            if (HasOpinionDoc)
            {
                DisplayDoc(dvOpinion);
                tsShowOpinion.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                tsShowOpinion.IsChecked = true;
                tsShowRequest.IsChecked = false;
                if (!HasRequestDoc)
                    tsShowRequest.Enabled = Janus.Windows.UI.InheritableBoolean.False;
            }
            else
            {
                tsShowOpinion.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                if (!HasRequestDoc)
                {
                    tsShowRequest.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                    pnlDoc.Closed = true;
                }
                else
                {
                    DisplayDoc(dvRequest);
                    tsShowRequest.IsChecked = true;
                }
            }
        }

        private DataView LoadDoc(int docid, bool isOpnDoc)
        {
            FM.GetDocMng().GetDocument().Load(docid);
            docDB.DocumentRow[] dr = (docDB.DocumentRow[])FM.GetDocMng().DB.Document.Select("DocId=" + docid.ToString());
            DataView dv = new DataView(dr[0].Table, "DocId=" + dr[0].DocId.ToString(), "", DataViewRowState.CurrentRows);

            if (isOpnDoc)
                HasOpinionDoc = true;
            else
                HasRequestDoc = true;

            return dv;
        }

        private Advisory.OpinionRow CurrentRow()
        {
            if (opinionBindingSource.Current == null)
                return null;
            else
                return (Advisory.OpinionRow)((DataRowView)opinionBindingSource.Current).Row;
        }
        private docDB.DocumentRow CurrentRowDocument()
        {
            if (documentBindingSource.Current == null)
                return null;
            else
                return (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
        }

        private void HookupNewOpinionDoc(bool ForOpinion)
        {
            if (ForOpinion)
                OpenDocDialog.SetDocFilter("opinion=1");

            OpenDocDialog.AllowBrowseFiles = false;
            OpenDocDialog.FindFile(FM.CurrentFileId);

            DialogResult dRes = OpenDocDialog.ShowDialog(FileForm());
            OpenDocDialog.SetDocFilter("");
            OpenDocDialog.AllowBrowseFiles = true;
            if (dRes == DialogResult.OK && OpenDocDialog.SelectedDocument != null)
            {
                docDB.DocumentRow newOpnDoc = OpenDocDialog.SelectedDocument;
                if (ForOpinion)
                    CurrentRow().DocId = newOpnDoc.DocId;
                else
                    CurrentRow().RequestDocId = newOpnDoc.DocId;
                LoadDocs(CurrentRow());
            }

        }

        private void opinionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                Advisory.OpinionRow dr = CurrentRow();
                if (dr == null)
                    return;
                ApplySecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                docDB.DocumentRow dr = CurrentRowDocument();
                ApplyDocSecurity(dr);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void requestDateCalendarCombo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                UIHelper.TodaysDateShortcutKey(sender, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void subjectEditBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.TextBoxTextCounter(subjectEditBox, acCommentCounter, 1024);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
 

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try
            {
                Janus.Windows.UI.CommandBars.UICommandBar bar = uiCommandManager1.CommandBars["cbMergeToolbar"];
                if (bar.Commands.Contains(e.Command.Key) && bar.Commands[e.Command.Key].Commands.Count > 0)
                    bar.Commands[e.Command.Key].Expand();

                switch (e.Command.Key)
                {
                    case "cmdLinkOpinion":
                        HookupNewOpinionDoc(true);
                        break;
                    case "cmdLinkRequest":
                        HookupNewOpinionDoc(false);
                        break;
                    case "tsSave":
                        Save();
                        break;
                    case "tsShowOpinion":
                        if (e.Command.IsChecked)
                        {
                            DisplayDoc(dvOpinion);
                            tsShowRequest.IsChecked = false;
                        }
                        else
                            tsShowOpinion.IsChecked = true;
                        break;
                    case "tsShowRequest":
                        if (e.Command.IsChecked)
                        {
                            DisplayDoc(dvRequest);
                            tsShowOpinion.IsChecked = false;
                        }
                        else
                            tsShowRequest.IsChecked = true;
                        break;
                    case "tsDelete":
                        Delete();
                        break;
                    case "tsAudit":
                        fData fAudit = new fData(CurrentRow());
                        fAudit.Show();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public void ApplyDocSecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            if (dr != null)
            {
                docDB.DocumentRow cbr = (docDB.DocumentRow)dr;
                UIHelper.EnableControls(documentBindingSource, FM.GetDocMng().GetDocument().CanEdit(cbr));
            }
        }

        private void DisplayDoc(DataView dv)
        {
            //ucDoc1.Datasource = dv;
            //ucDoc1.PreviewAsync();
            ucDocView1.Datasource = dv;
            ucDocView1.PreviewAsync();
        }

        void ucOpinion_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            ApplyBR(e.SavedOK);
        }

        void a_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (FM.IsFieldChanged(e.Column, e.Row))
                    ApplyBR(false);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public override string ucDisplayName()
        {
            return LawMate.Properties.Resources.DisplayNameLegalOpinion;
        }

        public override Janus.Windows.UI.CommandBars.UICommandManager CommandManager()
        {
            return uiCommandManager1;
        }

        public override void ReadOnly(bool makeReadOnly)
        {
            UIHelper.EnableControls(opinionBindingSource, !makeReadOnly);
            uiCommandBar1.Enabled = !makeReadOnly;
            if (!HasOpinionDoc)
                tsShowOpinion.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            if (!makeReadOnly)
                ApplySecurity(CurrentRow());

        }

        public override void ReloadUserControlData()
        {
            HasOpinionDoc = false;
            HasRequestDoc = false;
            //FM.GetAdvisoryMng().GetOpinion().PreRefresh();

            //FM.GetAdvisoryMng().GetOpinion().LoadByFileId(FM.CurrentFile.FileId);
            LoadDocs(CurrentRow());
        }

        public override void ApplyBR(bool DataNotDirty)
        {
            fFile f = FileForm();
            if (f != null)
            {
                f.IsDirty = !DataNotDirty;
                if (f.ReadOnly)
                    return;

                f.fileToc.Enabled = DataNotDirty;
                f.EditModeTitle(!DataNotDirty);
            }
        
            if (DataNotDirty)
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            else
                tsDelete.Enabled = Janus.Windows.UI.InheritableBoolean.False;

            lmWinHelper.EditModeCommandToggle(tsEditmode, !DataNotDirty);
             
        }
        public override void ApplySecurity(DataRow dr)
        {
            if (FileForm() != null && FileForm().ReadOnly)
                return;

            Advisory.OpinionRow cbr = (Advisory.OpinionRow)dr;
            UIHelper.EnableControls(opinionBindingSource, FM.GetAdvisoryMng().GetOpinion().CanEdit(cbr));
            UIHelper.EnableCommandBarCommand(tsDelete, FM.GetAdvisoryMng().GetOpinion().CanDelete(cbr));
        }
     
        public override void MoreInfo(string linkTable, int linkId)
        {
            opinionBindingSource.Position = opinionBindingSource.Find("OpinionId", linkId);
        }
        public override void Save()
        {
            if (FM.GetAdvisoryMng().DB.Opinion.HasErrors)
            {
                UIHelper.TableHasErrorsOnSaveMessBox(FM.DB);
            }
            else
            {
                try
                {
                    this.opinionBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetAdvisoryMng().GetOpinion());
                    bp.AddForUpdate(FM.GetDocMng().GetDocument());
                    bp.AddForUpdate(FM.GetDocMng().GetDocContent());
                    bp.AddForUpdate(FM.GetActivityBF());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();

                   

                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();

                }
                catch (Exception x)
                {
                    throw x;
                }
            }
        }

        public override void Delete()
        {
            try
            {
                if (UIHelper.ConfirmDelete())
                {
                    CurrentRow().Delete();
                    this.opinionBindingSource.EndEdit();

                    atLogic.BusinessProcess bp = FM.GetBP();
                    bp.AddForUpdate(FM.GetAdvisoryMng().GetOpinion());
                    bp.AddForUpdate(FM.EFile);
                    bp.Update();


                    ApplyBR(true);

                    fFile f = (fFile)this.ParentForm;
                    f.fileToc.LoadTOC();
                }

            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public override void Cancel()
        {
            UIHelper.Cancel(opinionBindingSource);
            ApplyBR(true);
        }

        private void ucOpinion_Load(object sender, EventArgs e)
        {
            try
            {
                ApplySecurity(CurrentRow());
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}

