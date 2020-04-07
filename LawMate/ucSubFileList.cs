using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate
{

    public partial class ucSubFileList : UserControl
    {
        FileManager myFM;
        fBrowse fileBrowser;
        public ucSubFileList()
        {
            InitializeComponent();
            this.uiCommandManager1.SetContextMenu(this.eFileSearchGridEX, this.uiContextMenu1);
        }

        public void LoadChildren(FileManager fm)
        {
            eFileSearchBindingSource.DataSource = "";
            myFM = fm;
            appDB.EFileSearchDataTable dt = myFM.AtMng.FileSearchByParentFileId(myFM.CurrentFileId);
            eFileSearchBindingSource.DataSource = dt;
            eFileSearchGridEX.MoveFirst();
        }
        public void Clear()
        {
            eFileSearchBindingSource.DataSource = "";
            myFM = null;
        }

        private void uiContextMenu1_Popup(object sender, EventArgs e)
        {
            try
            {
                
                if (eFileSearchGridEX.HitTest() != Janus.Windows.GridEX.GridArea.Cell)
                {
                    uiContextMenu1.Close();
                    return;
                }


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
                switch (e.Command.Key)
                {
                    case "cmdMove":
                        DoMove();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void DoMove()
        {
            fWait fProgress = new fWait();

            try
            {
                if(fileBrowser==null)
                    fileBrowser = new fBrowse(myFM.AtMng, 0, false, false, false, true);

                fileBrowser.FindFile(myFM.CurrentFileId);
                if (fileBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    //make dict of rows
                    Dictionary<int, appDB.EFileSearchRow> FilesToMove = new Dictionary<int, appDB.EFileSearchRow>();
                    foreach (Janus.Windows.GridEX.GridEXSelectedItem gsi in eFileSearchGridEX.SelectedItems)
                    {

                        appDB.EFileSearchRow efsr1 = (appDB.EFileSearchRow)((DataRowView)gsi.GetRow().DataRow).Row;
                        FilesToMove.Add(efsr1.FileId, efsr1);

                    }
                    try
                    {

                        foreach (appDB.EFileSearchRow efsr in FilesToMove.Values)
                        {
                            fProgress.setMessageText("Moving: " + efsr.Name);
                            fProgress.Show();
                            fProgress.Refresh();

                            FileManager filetomove1 = myFM.AtMng.GetFile(efsr.FileId);
                            //filetomove1.EFile.Move(filetomove1.CurrentFile, f.SelectedFile.FileId, true);
                            UIHelper.MoveFile(filetomove1, fileBrowser.SelectedFile.FileId);

                            atLogic.BusinessProcess bp = myFM.AtMng.GetBP();
                            bp.AddForUpdate(filetomove1.GetFileXRef());
                            bp.AddForUpdate(filetomove1.EFile);
                            bp.Update();

                           
                        }
                    }
                    catch (Exception x)
                    {
                        myFM.DB.FileXRef.RejectChanges();
                        myFM.DB.EFile.RejectChanges();
                     
                        Cursor.Current = Cursors.Default;
                        fProgress.Close();
                        UIHelper.HandleUIException(x);

                    }
                    Cursor.Current = Cursors.Default;
                    fProgress.Close();
                }
                LoadChildren(myFM);
            }
            catch (Exception x1)
            {
                fProgress.Close();
                throw x1;
            }
        }

        private void eFileSearchBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (eFileSearchGridEX.RootTable.Columns[0].EditType == Janus.Windows.GridEX.EditType.CheckBox)
                    eFileSearchGridEX.RootTable.Columns[0].EditType = Janus.Windows.GridEX.EditType.NoEdit;
                else
                    eFileSearchGridEX.RootTable.Columns[0].EditType = Janus.Windows.GridEX.EditType.CheckBox;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

    }
}
