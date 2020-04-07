using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using atriumBE;
using lmDatasets;

 namespace LawMate
{
    public partial class fExplorer : fBase
    {
        atriumManager myAtmng;
        bool AllowMoveSubFiles = false;
        bool LoadSubFiles = false;
//        DocManager myDM;

        public fExplorer()
        {
            InitializeComponent();
        }

        public fExplorer(Form f, int RootFileId)
            : base(f)
        {
            InitializeComponent();
            myAtmng = MainForm.AtMng;
            LoadLabel();
            VerifySecurityForSubFiles();
            LoadRootFile(RootFileId);
            ucBrowse1.Focus();
            
        }

        private void LoadLabel()
        {
            this.Text = String.Format(LawMate.Properties.Resources.AppExplorer, AtMng.AppMan.AppName);
        }

        public void FindFile(int fileid)
        {
            appDB.EFileSearchRow esr = myAtmng.FileSearchByFileId(fileid)[0];
            if (ucBrowse1.myFTV.FindNode(esr) == null)
            {
                MessageBox.Show("could not find file");
            }
        }

        private void VerifySecurityForSubFiles()
        {
            int perm = (int)myAtmng.SecurityManager.CanUpdate(myAtmng.GetFile(0).CurrentFileId, atSecurity.SecurityManager.Features.EfileScreen);
            if (perm > 0 & perm < 10)
            {
                AllowMoveSubFiles = true;
                cmdToggleSubFiles.Visible = Janus.Windows.UI.InheritableBoolean.True;

                cmdToggleSubFiles.IsChecked = AtMng.OfficeMng.GetOfficerPrefs().GetPref(OfficerPrefsBE.LawMateExplorerShowSubFiles, false);
                pnlChildren.Closed = !cmdToggleSubFiles.IsChecked;
                LoadSubFiles = cmdToggleSubFiles.IsChecked;

                //if (UIHelper.GetSetting("ShowSubFilesInLawMateExplorer") == "")
                //{
                //    cmdToggleSubFiles.IsChecked = false;
                //    UIHelper.SaveSetting("ShowSubFilesInLawMateExplorer", "false");
                //}
                //else
                //{
                //    cmdToggleSubFiles.IsChecked = Convert.ToBoolean(UIHelper.GetSetting("ShowSubFilesInLawMateExplorer"));
                //    pnlChildren.Closed = !cmdToggleSubFiles.IsChecked;
                //    LoadSubFiles = cmdToggleSubFiles.IsChecked;
                //}
            }
            else
            {
                AllowMoveSubFiles = false;
                cmdToggleSubFiles.Visible = Janus.Windows.UI.InheritableBoolean.False;
                pnlChildren.Closed = true;
            }
        }

        private void LoadRootFile(int RootFileid)
        {
            ucBrowse1.LoadRoot(myAtmng, RootFileid,false,false,false);

            DocManager myDM = myAtmng.GetFile(RootFileid).GetDocMng();
            timFMHeartbeat.Start();
            //now loaded in docmanager constructor
            //myDM.GetDocument().LoadByFileId(ucBrowse1.SelectedFile.FileId);
            //myDM.GetRecipient().LoadByFileId(ucBrowse1.SelectedFile.FileId);
            ucRecords1.FM = myDM.FM;
            ucRecords1.BindDocumentData(myDM.DB.Document, false, myDM);
        }

        DocManager myDM;
        private void ucBrowse1_FileSelected(object sender, FileContextEventArgs e)
        {
            myDM = myAtmng.GetFile(ucBrowse1.SelectedFile.FileId).GetDocMng();
            timFMHeartbeat.Start(); 
            ucRecords1.FM = myDM.FM;
            if (LoadSubFiles)
                ucSubFileList1.LoadChildren(myDM.FM);
            else
                ucSubFileList1.Clear();

           // myDM.GetDocument().Clear();
            //now loaded in docmanager constructor
            //myDM.GetDocument().LoadByFileId(ucBrowse1.SelectedFile.FileId);
            //myDM.GetRecipient().LoadByFileId(ucBrowse1.SelectedFile.FileId);
            ucRecords1.BindDocumentData(myDM.DB.Document, false, myDM);
            if (!myDM.FM.CurrentFile.IsFullPathNull())
                tbPath.Text = myDM.FM.CurrentFile.FullPath;
            else
                tbPath.Text = "";
            if (!myDM.FM.CurrentFile.IsFullFileNumberNull())
                tbNumber.Text = myDM.FM.CurrentFile.FullFileNumber;
            else
                tbNumber.Text = "";
        }

        private void ucBrowse1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {
            try
            {
                lmWinHelper.HelpContextMenuClicked(MainForm, sender, e);
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
                if (ucRecords1.FM.CurrentFile != null)
                {
                    FileManager fm = myAtmng.GetFile(ucRecords1.FM.CurrentFile.FileId);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucBrowse1_TreeNodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                lmWinHelper.ucBrowseDoubleClickHandler(sender, e);
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
                    case "cmdJumpToFile":
                        fMain fmain = (fMain)System.Windows.Forms.Application.OpenForms["fMain"];
                        fmain.OpenFile(ucRecords1.FM.CurrentFileId);
                        break;
                    case "cmdPreviewDoc":
                        ucRecords1.ShowDocument = cmdPreviewDoc.IsChecked;
                        break;
                    case "cmdToggleSubFiles":
                        pnlChildren.Closed = !cmdToggleSubFiles.IsChecked;
                        AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.LawMateExplorerShowSubFiles, cmdToggleSubFiles.IsChecked);
                        //UIHelper.SaveSetting("ShowSubFilesInLawMateExplorer", cmdToggleSubFiles.IsChecked.ToString());
                        LoadSubFiles = cmdToggleSubFiles.IsChecked;
                        if (LoadSubFiles && myDM != null)
                            ucSubFileList1.LoadChildren(myDM.FM);
                        else
                            ucSubFileList1.Clear();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void uiPanelManager1_PanelClosedChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                if (e.Panel.Name == "pnlChildren" && e.Panel.Closed && cmdToggleSubFiles.IsChecked)
                {
                    cmdToggleSubFiles.IsChecked = false;
                    AtMng.OfficeMng.GetOfficerPrefs().SetPref(OfficerPrefsBE.LawMateExplorerShowSubFiles, cmdToggleSubFiles.IsChecked);
                    //UIHelper.SaveSetting("ShowSubFilesInLawMateExplorer", cmdToggleSubFiles.IsChecked.ToString());
                }
 
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fExplorer_Shown(object sender, EventArgs e)
        {
            try
            {
                ucBrowse1.Focus();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fExplorer_Load(object sender, EventArgs e)
        {
            try
            {
                lmWinHelper.LoadPanelManagerLayout(uiPanelManager1, "ExplorerPanelManager");

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fExplorer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                lmWinHelper.SavePanelManagerLayout(uiPanelManager1, "ExplorerPanelManager", AtMng);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void SetCommandsState()
        {
            cmdPreviewDoc.IsChecked = !pnlDocViewer.Closed;
            cmdToggleSubFiles.IsChecked = !pnlChildren.Closed;
        }

        private void uiPanelManager1_CurrentLayoutChanging(object sender, CancelEventArgs e)
        {
            try
            {
                lmWinHelper.UpdateLayout(uiPanelManager1);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }
    }
}

