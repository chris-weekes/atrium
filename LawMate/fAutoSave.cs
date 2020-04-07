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
    public partial class fAutoSave : fBase
    {
        FileManager myFM;

        public fAutoSave()
        {
            InitializeComponent();
        }
        public fAutoSave(Form f)
            : base(f)
        {
            InitializeComponent();
        }
 

        private void fAutoSave_Load(object sender, EventArgs e)
        {
            myFM = AtMng.GetFile();
            try
            {
                LoadData();
            }
            catch(Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            //DocManager dm = myFM.GetDocMng();

            //dm.GetDocument();
            //dm.GetDocContent();
            //dm.GetAttachment();
            //dm.GetRecipient();

            //ucDoc1.Init(dm);

            //Atmng.LoadSuspendedAcs();
            //LoadAutoSaveDT();
            //autoSaveBindingSource.DataSource = AutoSaveDT;
            //SetRowChangeUI(autoSaveBindingSource.Count == 0);
            //ucDoc1.ReturnFocusTo = this.autoSaveGridEX;
            //autoSaveGridEX.MoveFirst();
        }

        private void LoadData()
        {
            DocManager dm = myFM.GetDocMng();

            dm.GetDocument();
            dm.GetDocContent();
            dm.GetAttachment();
            dm.GetRecipient();

            //ucDoc1.Init(dm);
            ucDocView1.Init(dm);

            AtMng.LoadSuspendedAcs();
            LoadAutoSaveDT();
            autoSaveBindingSource.DataSource = AutoSaveDT;
            SetRowChangeUI(autoSaveBindingSource.Count == 0);
            //ucDoc1.ReturnFocusTo = this.autoSaveGridEX;
            ucDocView1.ReturnFocusTo = this.autoSaveGridEX;
            autoSaveGridEX.MoveFirst();
            cmdLastLoad.Text = LawMate.Properties.Resources.DataRetrievalTime + DateTime.Now.ToString("HH:mm:ss tt");

        }

        appDB.AutoSaveDataTable AutoSaveDT;
        Dictionary<int, ACEState> ACEStateDictionnary;


        private void LoadAutoSaveDT()
        {
            ACEStateDictionnary = new Dictionary<int, ACEState>();
            AutoSaveDT = new appDB.AutoSaveDataTable();
            AutoSaveDT.BeginLoadData();
            foreach (ACEState itm in AtMng.SuspendedAcs)
            {
                //itm.Doc_DB.FileFormat.Merge(myFM.GetDocMng().DB.FileFormat);
                appDB.AutoSaveRow autoSaveRow = AutoSaveDT.NewAutoSaveRow();
                ActivityConfig.ACSeriesRow[] acsr = (ActivityConfig.ACSeriesRow[])AtMng.acMng.DB.ACSeries.Select("acseriesid=" + itm.AcSeriesId);
                ACEStateDictionnary.Add(itm.ActivityId, itm);
                if (acsr.Length == 1)
                {
                    autoSaveRow.StepCode = acsr[0].StepCode;
                    autoSaveRow.ActivityNameEng = acsr[0].ActivityNameEng;
                }
                else
                {
                    autoSaveRow.StepCode = LawMate.Properties.Resources.INVALIDACTIVITY;
                    autoSaveRow.ActivityNameEng = LawMate.Properties.Resources.INVALIDACTIVITY;
                    autoSaveRow.RowError = LawMate.Properties.Resources.CannotResumeThisActivity;
                }
                autoSaveRow.ActivityId = itm.ActivityId;
                atriumDB dsA = new atriumDB();
                dsA.Merge(ACEState.GetDSFromACE(itm,myFM.GetBEMngrForTable("EFile").MyDS.DataSetName));
                autoSaveRow.SaveDate = dsA.Activity.FindByActivityId(itm.ActivityId).ActivityEntryDate;

                if (!dsA.Activity.FindByActivityId(itm.ActivityId).IsDocIdNull())
                    DocumentIsLatest(itm, autoSaveRow);

                atriumDB.EFileRow efr = dsA.EFile.FindByFileId(itm.FileId);
                if (efr == null)
                {
                    try
                    {

                        efr = AtMng.GetFile(itm.FileId).CurrentFile;
                    }
                    catch (Exception x)
                    {
                        efr = null;
                    }
                }

                if (efr == null)
                {
                    autoSaveRow.FileName = LawMate.Properties.Resources.DELETEDFILE;
                    autoSaveRow.FullFileNumber = LawMate.Properties.Resources.DELETEDFILE;
                    autoSaveRow.RowError = LawMate.Properties.Resources.CannotResumeThisActivity;
                }
                else
                {
                    autoSaveRow.FileName = efr.NameE;
                    autoSaveRow.FullFileNumber = efr.FullFileNumber;
                }
                
                AutoSaveDT.AddAutoSaveRow(autoSaveRow);
            }
            AutoSaveDT.EndLoadData();
        }

        private bool DocumentIsLatest(ACEState aceState, appDB.AutoSaveRow autoSaveRow)
        {
            atriumDB dsA = new atriumDB();
            dsA.Merge(ACEState.GetDSFromACE(aceState, myFM.GetBEMngrForTable("EFile").MyDS.DataSetName));
            docDB dsD = new docDB();
            dsD.Merge( ACEState.GetDSFromACE(aceState, myFM.GetBEMngrForTable("Document").MyDS.DataSetName));
            int docid = dsA.Activity.FindByActivityId(aceState.ActivityId).DocId;
            if (!myFM.GetDocMng().GetDocContent().IsLatest(dsD.DocContent.FindByDocId(docid)))
            {
                autoSaveRow.RowError = LawMate.Properties.Resources.DocumentPartOfSuspendedActivityHasBeenModified;
                return false;
            }
            return true;
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ResumeActivity();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    DeleteSuspendedActivity();
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ResumeActivity()
        {

            //if (listBox1.SelectedIndex != -1)
            if (CurrentRow() != null)
            {
                if (CurrentRow().HasErrors)
                {
                    pnlCannotResume.Closed = false;
                    throw new LMException(CurrentRow().RowError);
                }
                else
                {
                    //restores aces object
                    ACEState aces = ACEStateDictionnary[CurrentRow().ActivityId];
                    
                    //check for latest on resume
                    if (DocumentIsLatest(aces, CurrentRow()))
                    {
                        Close();
                        //get fm
                        FileManager fm = AtMng.GetFile(aces);

                        fFile f = MainForm.OpenFile(fm.CurrentFile.FileId);
                        f.RestoreWizard(aces);
                    }
                    else if (CurrentRow().HasErrors)
                    {
                        pnlCannotResume.Closed = false;
                        throw new LMException(CurrentRow().RowError);
                    }

                }
            }
        }
        private void DeleteSuspendedActivity()
        {
            if (CurrentRow() != null)
            {
                if (MessageBox.Show(LawMate.Properties.Resources.AreYouSureYouWantToDeleteThisSuspendedActivity, LawMate.Properties.Resources.DeleteSuspendedActivity, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    int pos = autoSaveGridEX.CurrentRow.Position;
                    ACEState aces = ACEStateDictionnary[CurrentRow().ActivityId];
                    ACEStateDictionnary.Remove(aces.ActivityId);
                    AtMng.DeleteSuspendedAc(aces);
                    autoSaveBindingSource.DataSource = null;
                    AutoSaveDT.Clear();
                    AutoSaveDT.AcceptChanges();
                    LoadAutoSaveDT();
                    autoSaveBindingSource.DataSource = AutoSaveDT;
                    SetRowChangeUI(autoSaveBindingSource.Count == 0);
                    if (autoSaveBindingSource.Count != 0)
                    {
                        if (autoSaveBindingSource.Count == pos)
                            autoSaveGridEX.Row = pos - 1;
                        else
                            autoSaveGridEX.Row = pos;
                    }
                }
            }
        }

        private void uiCommandManager1_CommandClick(object sender, Janus.Windows.UI.CommandBars.CommandEventArgs e)
        {
            try 
            {
                switch (e.Command.Key)
                {
                    case "cmdDeleteSuspendedAC":
                            DeleteSuspendedActivity();
                        break;
                    case "cmdResume":
                            ResumeActivity();
                        break;
                    case "cmdJumpToFile":
                        ACEState aces = ACEStateDictionnary[CurrentRow().ActivityId];
                        fFile f = MainForm.OpenFile(aces.FileId);
                        break;
                    case "cmdRefresh":
                        LoadData();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (listBox1.SelectedIndex != -1)
                //{

                //    ACEState aces = (ACEState)listBox1.SelectedItem;

                //    if (aces.FM_DB.Activity.FindByActivityId(aces.ActivityId).IsDocIdNull())
                //    {
                //        ucDoc1.NoDoc("No document");
                //    }
                //    else
                //    {
                //        docDB.DocumentRow dr = aces.Doc_DB.Document.FindByDocId(aces.FM_DB.Activity.FindByActivityId(aces.ActivityId).DocId);

                //        DataView dvDoc = new DataView(dr.Table, "DocId=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);

                //        ucDoc1.Datasource = dvDoc;
                //        ucDoc1.PreviewAsync();
                //    }
                //}
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private appDB.AutoSaveRow CurrentRow()
        {
            if (autoSaveBindingSource.Current == null)
                return null;
            else
                return (appDB.AutoSaveRow)((DataRowView)autoSaveBindingSource.Current).Row;
        }

        private void SetRowChangeUI(bool nodata)
        {
            if (nodata)
            {
                cmdDeleteSuspendedAC.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdResume.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                //ucDoc1.Clear();
                ucDocView1.Clear();
                pnlAutoSave.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
                pnlDoc.Closed = true;
                pnlCannotResume.Closed = true;
                
            }
            else
            {
                if (pnlDoc.Closed)
                {
                    pnlDoc.Closed = false;
                    pnlAutoSave.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
                }
                cmdDeleteSuspendedAC.Enabled = Janus.Windows.UI.InheritableBoolean.True;
                 if (CurrentRow().RowError.Length > 0)
                     cmdResume.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                else
                    cmdResume.Enabled = Janus.Windows.UI.InheritableBoolean.True;

                cmdJumpToFile.Enabled = Janus.Windows.UI.InheritableBoolean.True;
            }
        }


        private void autoSaveBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentRow() != null)
                {

                    ACEState aces = ACEStateDictionnary[CurrentRow().ActivityId];
                    atriumDB dsA = new atriumDB();
                    dsA.Merge(ACEState.GetDSFromACE(aces, myFM.GetBEMngrForTable("EFile").MyDS.DataSetName));

                    docDB dsD = new docDB();
                    dsD.Merge(ACEState.GetDSFromACE(aces, myFM.GetBEMngrForTable("Document").MyDS.DataSetName)); 
                    SetRowChangeUI(false);

                    if (dsA.Activity.FindByActivityId(aces.ActivityId).IsDocIdNull())
                    {
                        ucDocView1.NoAssociatedDocument(LawMate.Properties.Resources.NoDocument);
                        //ucDoc1.NoAssociatedDocument(LawMate.Properties.Resources.NoDocument);
                    }
                    else
                    {
                        myFM.GetDocMng().isMerging = true;
                        myFM.GetDocMng().DB.Merge(dsD);
                        myFM.GetDocMng().isMerging = false;
                        docDB.DocumentRow dr = myFM.GetDocMng().DB.Document.FindByDocId(dsA.Activity.FindByActivityId(aces.ActivityId).DocId);
                        
                        DataView dvDoc = new DataView(dr.Table, "DocId=" + dr.DocId.ToString(), "", DataViewRowState.CurrentRows);

                        //ucDoc1.Datasource = dvDoc;
                        //ucDoc1.PreviewAsync();

                        ucDocView1.Datasource = dvDoc;
                        ucDocView1.PreviewAsync();

                        if (CurrentRow().RowError.Length > 0)
                        {
                            pnlCannotResume.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
                            pnlCannotResume.Closed = false;
                            cmdResume.Enabled = Janus.Windows.UI.InheritableBoolean.False;
                            pnlAutoSave.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Top;
                            label1.Text = CurrentRow().RowError;
                        }
                        else
                        {
                            pnlCannotResume.Closed = true;
                            pnlCannotResume.DockStyle = Janus.Windows.UI.Dock.PanelDockStyle.Fill;
                            label1.Text = "";
                        }

                    }
                }
                else
                {
                    SetRowChangeUI(true);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void autoSaveGridEX_RowDoubleClick(object sender, Janus.Windows.GridEX.RowActionEventArgs e)
        {
            try
            {
                ResumeActivity();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void autoSaveGridEX_ColumnButtonClick(object sender, Janus.Windows.GridEX.ColumnActionEventArgs e)
        {
            try
            {
                DeleteSuspendedActivity();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}

