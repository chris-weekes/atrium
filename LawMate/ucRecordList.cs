using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;

 namespace LawMate
{
    public delegate void LinkClickedEventHandler(object sender,Janus.Windows.GridEX.ColumnActionEventArgs e);
    public delegate void ColumnButtonClickEventHandler(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e);
    public delegate void RowDoubleClickedEventHandler( object sender, Janus.Windows.GridEX.RowActionEventArgs e);


    public partial class ucRecordList : UserControl
    {
        public Janus.Windows.GridEX.GridEX RecordsGridEx
        {
            get { return documentGridEX; }
        }

        bool inEditMode = false;
        public bool InEditMode
        {
            get 
            {
                return inEditMode;
            }
            set
            {
                inEditMode = value;
            }
        }

        public event LinkClickedEventHandler LinkClicked;
        public event ColumnButtonClickEventHandler ColumnButtonClicked;
        public event RowDoubleClickedEventHandler RowDoubleClicked;

        public docDB.DocumentRow SelectedDocument()
        {
            return (docDB.DocumentRow)((DataRowView)documentBindingSource.Current).Row;
        }

        public Janus.Windows.GridEX.SelectionMode SelectionMode
        {
            get { return documentGridEX.SelectionMode; }
            set { documentGridEX.SelectionMode = value; }
        }
        public List<DataRow> SelectedDocuments()
        {
            return UIHelper.GridGetSelectedData(documentGridEX);
        }

        public ucRecordList()
        {
            InitializeComponent();
        }

        atriumBE.DocManager myDM;

        public BindingSource DataSource
        {
            get { return documentBindingSource; }
            set
            {
                documentBindingSource = value;
                documentGridEX.DataSource = documentBindingSource;
            }
        }

       


        public void SearchResult(bool IsSearchResults)
        {
            documentGridEX.RootTable.Columns["FailedToSend"].Visible = !IsSearchResults;
            
            documentGridEX.RootTable.Columns["folderPath"].Visible = IsSearchResults;

            //JLL: NameF not in DataSet; what to do about french file name
            documentGridEX.RootTable.Columns["NameE"].Visible = IsSearchResults;
            documentGridEX.RootTable.FormatConditions[0].Enabled = IsSearchResults;
            documentGridEX.RootTable.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            
            //hides documents that end up getting loaded in table when viewed as attachments - fullfilenumber is null when these attachments get loaded.
            if (IsSearchResults)
            {
                documentGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.None;
                string filter = "fullfilenumber is not null";
                if (documentBindingSource.Filter != null && documentBindingSource.Filter != filter && documentBindingSource.Filter!="")
                {
                    documentBindingSource.Filter +=" and "+ filter;
                }
                else
                    documentBindingSource.Filter = filter;
            }
            else
            { 
                documentBindingSource.Filter = "";
                documentGridEX.BorderStyle = Janus.Windows.GridEX.BorderStyle.SunkenLight3D;
            }
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, byte[]> icons = new Dictionary<string, byte[]>();
            try
            {
                //get icons for files
                foreach (docDB.DocumentRow dr in  myDM.DB.Document)
                {

                    if (!icons.ContainsKey(dr.ext))
                    {
                        icons.Add(dr.ext, UIHelper.GetFileIcon(dr.ext.Trim()));
                    }

                }
            }
            catch (Exception x)
            {
                //ignore the exception
            }
            e.Result = icons;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                myDM.isMerging = true;
                Dictionary<string, byte[]> icons = (Dictionary<string, byte[]>)e.Result;
                foreach (docDB.DocumentRow dr in myDM.DB.Document)
                {
                    if (icons.ContainsKey(dr.ext))
                    {
                        if (dr.RowState == DataRowState.Unchanged)
                        {
                            dr.icon = icons[dr.ext];
                            dr.AcceptChanges();
                        }
                        else
                        {
                            dr.icon = icons[dr.ext];
                        }
                    }
                }
            }
            catch (Exception x)
            {
                //ignore the exception
            }
            finally
            {
                myDM.isMerging = false;

            }

        }

        public void Init(atriumBE.DocManager dm)
        {
            myDM = dm;
            if(!backgroundWorker1.IsBusy)
             backgroundWorker1.RunWorkerAsync();

           // string filter = "fileid = " + myDM.FM.CurrentFileId.ToString();
           // documentBindingSource.Filter = filter;

            //jll: header icon keeps disappearing when changing language in design.  just set it at run time ... arg.
            documentGridEX.RootTable.Columns["CheckedOut"].HeaderImage = Properties.Resources.lock_icon;
            documentGridEX.RootTable.Columns["CheckedOut"].ValueList[true].Image = Properties.Resources.lock_icon;
            documentGridEX.RootTable.Columns["isPaper"].HeaderImage = Properties.Resources.cbProcess;
            if (myDM.FM.GetSSTMng() != null)
                documentGridEX.RootTable.Columns["SentToShareFolder"].Visible = true;
            else
                documentGridEX.RootTable.Columns["SentToShareFolder"].Visible = false;
        }

        public void GridMoveFirst()
        {
            documentGridEX.MoveFirst();
        }
        public void GridMoveLast()
        {
            documentGridEX.MoveLast();
        }

        private void documentGridEX_LinkClicked(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                LinkClicked(this, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                UIHelper.GridEnabledChanged(documentGridEX);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (documentGridEX.CurrentRow == null)
                    return;
                if (documentGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.GroupHeader)
                    documentGridEX.Row++;
                if (documentGridEX.CurrentRow.RowType == Janus.Windows.GridEX.RowType.Record  && documentGridEX.Tag!=null && (bool)documentGridEX.Tag==true)
                {
                    documentGridEX.CurrentRow.BeginEdit();
                    documentGridEX.CurrentRow.Cells["IsViewed"].Value = true;
                    documentGridEX.CurrentRow.EndEdit();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            
        }

        private void documentGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                ColumnButtonClicked(this, e);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_FormattingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.DataRow == null)
                    return;
                docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)e.Row.DataRow).Row;
                if (dr == null )
                    return;

                if (!dr.IsSizeNull())
                {
                    e.Row.Cells["Size"].Text = String.Format("{0} kb", dr.Size / 1024);
                }

                if (!dr.IsSentToShareFolderNull())
                {
                    if (dr.SentToShareFolder == 2)
                    {
                        e.Row.Cells["SentToShareFolder"].Image = Properties.Resources.SentToShareSuccess;
                    }
                    else if (dr.SentToShareFolder == 3)
                    {
                        e.Row.Cells["SentToShareFolder"].Image = Properties.Resources.SentToShareFail;
                    }
                }

                if( myDM == null || myDM.FM.IsVirtualFM || dr.IsNull("FileId"))
                    return;

                //JLL: When Selecting Add Doc/Record/Send from ucRecords action, dr.fileid is null, making below statement fail
                if (dr.FileId != myDM.FM.CurrentFile.FileId)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle fmt = new Janus.Windows.GridEX.GridEXFormatStyle();
                    fmt.BackColor = Color.LightYellow;
                    e.Row.RowStyle = fmt;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try 
            {
                if(e.Row.RowType== Janus.Windows.GridEX.RowType.Record & RowDoubleClicked!=null)
                    RowDoubleClicked(this, e);
 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_CurrentCellChanging(object sender, Janus.Windows.GridEX.CurrentCellChangingEventArgs e)
        {
            try
            {
                if (inEditMode)
                    e.Cancel = true;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_SortKeysChanged(object sender, EventArgs e)
        {
            try
            {

                if (documentGridEX.RootTable.SortKeys.Count == 1 && documentGridEX.RootTable.SortKeys[0].Column.Key == "efDate")
                {
                    documentGridEX.RootTable.SortKeys.Add(new Janus.Windows.GridEX.GridEXSortKey(documentGridEX.RootTable.Columns["entryDate"], documentGridEX.RootTable.Columns["efDate"].SortOrder));
                    documentGridEX.RootTable.SortKeys.Add(new Janus.Windows.GridEX.GridEXSortKey(documentGridEX.RootTable.Columns["DocId"], documentGridEX.RootTable.Columns["efDate"].SortOrder));
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void documentGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            try
            {
                if (e.Row.DataRow == null)
                    return;
                docDB.DocumentRow dr = (docDB.DocumentRow)((DataRowView)e.Row.DataRow).Row;
                if (dr == null)
                    return;

                e.Row.Cells["CheckedOut"].Value = !dr.IsCheckedOutByNull();

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
    }
}
