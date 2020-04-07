using System;
using System.Collections.Generic;
using System.Text;
using atriumBE;
using lmDatasets;
using System.Windows.Forms;
using System.IO;

namespace LawMate
{


    public class lmWinHelper
    {
        public static void AddToMyShortcuts(atriumManager atmng, appDB.EFileSearchRow efsr)
        {
            fBrowse fb = new fBrowse(atmng, 0, false, false, true, true);
            fb.FindFile(atmng.WorkingAsOfficer.ShortcutsId);
            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                atriumBE.FileManager sfm = atmng.GetFile(fb.SelectedFile.FileId);

                fMove fMove1 = new fMove(sfm.CurrentFile.FileMetaTypeRow, true);
                fMove1.SetDefaultName(efsr.Name);
                fMove1.ShowDialog();
                if (fMove1.Cancel)
                {
                    fMove1.Close();
                    return;
                }
                else if (fMove1.moveOp == FXLinkType.Shortcut)
                {
                    //sfm.GetFileXRef().LoadByFileId(sfm.CurrentFile.FileId);
                    //sfm.GetFileXRef().LoadByOtherFileId(sfm.CurrentFile.FileId);
                    atriumDB.FileXRefRow fxrNew = (atriumDB.FileXRefRow)sfm.GetFileXRef().Add(sfm.CurrentFile);

                    //JL 2010-03-23: ensure linktype updated before otherfileid so when beforechange fires on otherfileid, linktype is already changed
                    fxrNew.LinkType = (int)fMove1.moveOp;
                    fxrNew.OtherFileId = efsr.FileId;
                    fxrNew.Name = fMove1.textBoxValue();
                    fMove1.Close();
                    if (fxrNew.HasErrors)
                    {
                        string msg = fxrNew.GetColumnError("OtherFileId");
                        fxrNew.RejectChanges();
                        throw new LMException(msg);
                    }
                    try
                    {
                        atLogic.BusinessProcess bp = sfm.GetBP();
                        bp.AddForUpdate(sfm.GetFileXRef());

                        bp.Update();

                    }
                    catch (Exception x)
                    {

                        sfm.DB.FileXRef.RejectChanges();
                        throw x;
                    }
                }
            }
        }

        //public static void LoadDocShortcuts(System.Windows.Forms.TreeNode treeNode, atriumManager atmng)
        //{
        //    if (treeNode == null)
        //        return;

        //    int fileid;
        //    if (treeNode.Tag.GetType() == typeof(int))
        //        fileid = (int)treeNode.Tag;
        //    else
        //    {
        //        appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)treeNode.Tag;
        //        fileid = efsr.FileId;
        //    }

        //    appDB.EFileSearchDataTable dt = atmng.FileSearchByParentFileId(fileid);

        //    //load folders
        //    appDB.EFileSearchRow[] efrSorted = (appDB.EFileSearchRow[])dt.Select("LinkType=" + (int)FXLinkType.ParentChild, "LinkType,Name" + Atmng.AppMan.Language.Substring(0, 1));
        //    foreach (appDB.EFileSearchRow efr in efrSorted)
        //    {
        //        System.Windows.Forms.TreeNode ndDocXrefContainer = new System.Windows.Forms.TreeNode();
        //        ndDocXrefContainer.Tag = efr;

        //        ndDocXrefContainer.Name = "nodeContainerDocXref" + efr.FileId.ToString();
        //        ndDocXrefContainer.ImageKey = "folder.gif";
        //        ndDocXrefContainer.SelectedImageKey = "folder.gif";
        //        ndDocXrefContainer.Text = efr.Name;

        //        treeNode.Nodes.Add(ndDocXrefContainer);
        //    }

        //    //loadshortcuts
        //    efrSorted = (appDB.EFileSearchRow[])dt.Select("LinkType=" + (int)FXLinkType.Shortcut, "LinkType,XRefName");
        //    foreach (appDB.EFileSearchRow efr in efrSorted)
        //    {
        //        System.Windows.Forms.TreeNode ndDocXrefContainer = new System.Windows.Forms.TreeNode();
        //        ndDocXrefContainer.Tag = efr;

        //        ndDocXrefContainer.Name = "nodeFileShortcut" + efr.FileId.ToString();
        //        ndDocXrefContainer.ImageKey = "fileShortcut.png";
        //        ndDocXrefContainer.SelectedImageKey = "fileShortcut.png";
        //        ndDocXrefContainer.Text = efr.XRefName;

        //        treeNode.Nodes.Add(ndDocXrefContainer);
        //    }


        //    //DocManager DMDocShortcut = atmng.GetFile(fileid, false).GetDocMng();
        //    //DMDocShortcut.GetDocXRef().LoadByFileId(fileid);

        //    docDB.DocXRefDataTable docSCs = atmng.DocShortcuts(fileid);
        //    foreach (docDB.DocXRefRow docXrefRow in docSCs)
        //    {
        //        System.Windows.Forms.TreeNode nd = new System.Windows.Forms.TreeNode();
        //        nd.Name = "nodeDocXRef" + docXrefRow.DocId.ToString();
        //        nd.Tag = docXrefRow;
        //        nd.Text = docXrefRow.Name;
        //        nd.ImageKey = "docShortcut.gif";
        //        nd.SelectedImageKey = "docShortcut.gif";
        //        treeNode.Nodes.Add(nd);
        //    }
        //    treeNode.Expand();
        //}

        public static void EditModeCommandToggle(Janus.Windows.UI.CommandBars.UICommand cmd, bool isEditMode)
        {
            if (isEditMode)
            {
                cmd.Image = LawMate.Properties.Resources.modified;
                cmd.IsChecked = true;
                cmd.ToolTipText = LawMate.Properties.Resources.YouAreInEditMode;
            }
            else
            {
                cmd.Image = LawMate.Properties.Resources.blank;
                cmd.IsChecked = false;
                cmd.ToolTipText = "";
            }
        }

        public static void CreateNewXRef(atriumManager atmng, appDB.EFileSearchRow efsr)
        {
            fBrowse fb = new fBrowse(atmng, 0, false, false, false, true);
            fb.FindFile(efsr.FileId);

            if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                atriumBE.FileManager sfm = atmng.GetFile(efsr.FileId);
                atriumDB.FileXRefRow fxrNew = (atriumDB.FileXRefRow)sfm.GetFileXRef().Add(sfm.CurrentFile);
                fxrNew.LinkType = (int)atriumBE.FXLinkType.XRef;
                fxrNew.OtherFileId = fb.SelectedFile.FileId;
                if (fxrNew.HasErrors)
                {
                    string msg = fxrNew.GetColumnError("OtherFileId");
                    fxrNew.RejectChanges();
                    throw new LMException(msg);
                }

                try
                {
                    atLogic.BusinessProcess bp = sfm.GetBP();
                    bp.AddForUpdate(sfm.GetFileXRef());
                    bp.Update();
                }
                catch (Exception x)
                {

                    sfm.DB.FileXRef.RejectChanges();
                    throw x;
                }

            }
        }

        public static void FormatGridRowBFOfficer(Janus.Windows.GridEX.GridEXRow grdRow)
        {
            if (grdRow.Cells["BFOfficerID"].Text == "")
                grdRow.Cells["To"].Value = grdRow.Cells["RoleCode"].Text;
            else
                grdRow.Cells["To"].Value = grdRow.Cells["BFOfficerID"].Text;
        }

        public static void FormatGridRowBFDateLoading(Janus.Windows.GridEX.GridEXRow grdRow)
        {
            try
            {
                if (grdRow.Cells["isMail"].Value != null && (bool)grdRow.Cells["isMail"].Value == true)
                {
                    int Hours = ((DateTime)grdRow.Cells["entryDate"].Value).Hour;
                    int Minutes = ((DateTime)grdRow.Cells["entryDate"].Value).Minute;
                    TimeSpan ts = new TimeSpan(Hours, Minutes, 0);
                    DateTime fv = ((DateTime)grdRow.Cells["BFDate"].Value).Date;
                    fv += ts;
                    grdRow.Cells["DateTime"].Value = fv;
                }
                else
                    grdRow.Cells["DateTime"].Value = grdRow.Cells["BFDate"].Value;
            }
            catch (Exception x)
            { }
        }

        public static void FormatGridRowBFIsUnread(atriumBE.FileManager fmCurrent, Janus.Windows.GridEX.GridEXRow grdRow)
        {
            if (grdRow.DataRow!=null)
            {
                lmDatasets.atriumDB.ActivityBFRow abr = (lmDatasets.atriumDB.ActivityBFRow)((System.Data.DataRowView)grdRow.DataRow).Row;
                if (fmCurrent.GetActivityBF().IsDirect(abr) && !abr.isRead)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle fmt = new Janus.Windows.GridEX.GridEXFormatStyle();
                    fmt.FontBold = Janus.Windows.GridEX.TriState.True;
                    grdRow.RowStyle = fmt;
                }
            }
        }

        public static void FormatGridRowBFDate(atriumBE.FileManager fmCurrent, Janus.Windows.GridEX.GridEXRow grdRow)
        {
            if (grdRow.Cells["isMail"].Value != null && (bool)grdRow.Cells["isMail"].Value != true)
            {
                DateTime tm = (DateTime)grdRow.Cells["DateTime"].Value;
                TimeSpan ts = new TimeSpan(0, 0, 0);
                if (tm.TimeOfDay == ts)
                {
                    string mnth;
                    string day;
                    if (tm.Month < 10)
                        mnth = "0" + tm.Month.ToString();
                    else
                        mnth = tm.Month.ToString();

                    if (tm.Day < 10)
                        day = "0" + tm.Day.ToString();
                    else
                        day = tm.Day.ToString();

                    grdRow.Cells["DateTime"].Text = tm.Year + "/" + mnth + "/" + day;
                }
            }
        }


        /// <summary>
        /// Delete command from ucFileContextMenu
        /// </summary>
        /// <param name="nd">TreeView node that is to be deleted</param>
        /// <param name="main">Reference to MainForm for Atmng</param>
        public static void DeleteFileShortcutOrCrossReference(TreeNode nd, fMain main)
        {
            if (UIHelper.ConfirmDelete())
            {
                TreeNode pnd = nd.Parent;
                appDB.EFileSearchRow parentEfileSearchRow;

                if (pnd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    parentEfileSearchRow = (appDB.EFileSearchRow)pnd.Tag;
                else
                {
                    appDB.EFileSearchDataTable efdt = main.AtMng.FileSearchByFileId((int)pnd.Tag);
                    parentEfileSearchRow = (appDB.EFileSearchRow)efdt[0];
                }

                appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)nd.Tag;

                atriumBE.FileManager parentFM = main.AtMng.GetFile(parentEfileSearchRow.FileId);
                atriumDB.FileXRefRow fxr = parentFM.GetFileXRef().Load(efsr.xrefId);
                fxr.Delete();

                try
                {
                    atLogic.BusinessProcess bp = parentFM.GetBP();
                    bp.AddForUpdate(parentFM.GetFileXRef());
                    bp.Update();

                    nd.Remove();
                }
                catch (Exception x)
                {

                    parentFM.DB.FileXRef.RejectChanges();
                    UIHelper.HandleUIException(x);
                }
            }
        }


        public static void HelpContextMenuClicked(fMain main, object sender, FileContextEventArgs e)
        {
            try
            {
                switch (e.MenuItem)
                {
                    case FileContextMenuItem.BrowseFileInExplorer:
                        ucFileContextMenu ucfcm2 = (ucFileContextMenu)sender;
                        FileTreeView ftv2 = ucfcm2.Ftv;
                        if (ftv2.IsExplorer)
                        {
                            TreeNode tn = ftv2.FindNode(e.SelectedFile);

                            if (tn == null)
                            {
                                throw new LMException(LawMate.Properties.Resources.CannotJumpToADifferentLocationInThisTree);
                            }
                            //e.Node.Expand();
                        }
                        else
                        {
                            JumpToExplorer(main, e.SelectedFile.FileId);

                        }
                        break;
                    case FileContextMenuItem.DeleteFileShortcut:
                    case FileContextMenuItem.FileXrefDelete:
                        DeleteFileShortcutOrCrossReference(e.Node, main);
                        break;
                    case FileContextMenuItem.DocXrefDelete:
                        if (UIHelper.ConfirmDelete())
                        {
                            TreeNode nd = (TreeNode)e.Node;
                            docDB.DocXRefRow docxrefrow = (docDB.DocXRefRow)nd.Tag;

                            FileManager fmDel = main.AtMng.GetFile(docxrefrow.FileId);
                            DocManager dmDel = fmDel.GetDocMng();
                            docDB.DocXRefRow docxrefDelete = fmDel.GetDocMng().GetDocXRef().Load(docxrefrow.Id);
                            docxrefDelete.Delete();
                            try
                            {
                                atLogic.BusinessProcess bp = dmDel.GetBP();
                                bp.AddForUpdate(dmDel.GetDocXRef());
                                bp.Update();
                                nd.Remove();
                            }
                            catch (Exception x)
                            {
                                dmDel.DB.DocXRef.RejectChanges();
                                UIHelper.HandleUIException(x);
                            }
                        }
                        break;
                    case FileContextMenuItem.DocXrefJumpToFile:
                        if (e.Node.Tag != null)
                        {
                            TreeNode nd = (TreeNode)e.Node;
                            docDB.DocXRefRow docxrefrow = (docDB.DocXRefRow)nd.Tag;

                            docDB.DocumentRow dr5 = main.AtMng.GetFile().GetDocMng().GetDocument().Load(docxrefrow.DocId);
                            fFile fJumpToFileDocXref = main.OpenFile(dr5.FileId);
                            fJumpToFileDocXref.MoreInfo("document", dr5.DocId);
                        }
                        break;
                    case FileContextMenuItem.DocXrefMove:
                        if (e.Node.Tag != null)
                        {
                            TreeNode ndDocXrefMove = (TreeNode)e.Node;
                            docDB.DocXRefRow docr = null;
                            if (ndDocXrefMove.Tag.GetType() == typeof(docDB.DocXRefRow))
                                docr = (docDB.DocXRefRow)ndDocXrefMove.Tag;

                            fBrowse fbdocXref = new fBrowse(main.AtMng, 0, false, true, true, true);
                            fbdocXref.FindFile(docr.FileId);

                            if (fbdocXref.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {

                                FileManager thisfm = main.AtMng.GetFile(docr.FileId);
                                DocManager dmDel = thisfm.GetDocMng();
                                docDB.DocXRefRow docxrefDelete = thisfm.GetDocMng().GetDocXRef().Load(docr.Id);
                                docxrefDelete.FileId = fbdocXref.SelectedFile.FileId;
                                atLogic.BusinessProcess bp = main.AtMng.GetBP();
                                bp.AddForUpdate(thisfm.GetDocMng().GetDocXRef());
                                bp.AddForUpdate(thisfm.EFile);
                                try
                                {
                                    bp.Update();

                                }
                                catch (Exception x)
                                {

                                    thisfm.DB.EFile.RejectChanges();
                                    thisfm.GetDocMng().DB.DocXRef.RejectChanges();
                                    throw;
                                }
                                e.Node.Remove();
                                ucFileContextMenu ucfcm = (ucFileContextMenu)sender;
                                TreeNode newparentNode = ucfcm.Ftv.FindLoadedNode(fbdocXref.SelectedFile.FileId);
                                if (newparentNode != null)
                                {
                                    newparentNode.Nodes.Clear();
                                    ucfcm.Ftv.LoadLevelPublic(newparentNode, (appDB.EFileSearchRow)newparentNode.Tag);
                                }
                            }
                        }
                        break;
                    case FileContextMenuItem.DocXrefViewInExternalApp:
                        TreeNode nd2 = (TreeNode)e.Node;
                        docDB.DocXRefRow docxrefrow2 = (docDB.DocXRefRow)nd2.Tag;
                        FileManager fmView = main.AtMng.GetFile(docxrefrow2.FileId);
                        DocManager dmView = fmView.GetDocMng();
                        docDB.DocumentRow dr = dmView.GetDocument().Load(docxrefrow2.DocId);
                        dmView.GetDocContent().Load(dr.DocRefId, dr.CurrentVersion); //WI 73696 - added current version
                        UIHelper.LaunchNative(dmView.GetDocContent().WriteTempFile(dr, true), null, "");
                        break;
                    case FileContextMenuItem.DocXrefViewInLMViewer:
                        TreeNode nodeLMViewer = (TreeNode)e.Node;
                        docDB.DocXRefRow docXrefRow = (docDB.DocXRefRow)nodeLMViewer.Tag;
                        DisplayDocInLawMateViewer(docXrefRow);
                        break;
                    case FileContextMenuItem.NewShortcutContainer:
                        TreeNode ndShortcutContainer = (TreeNode)e.Node;
                        int fileid = ((appDB.EFileSearchRow)ndShortcutContainer.Tag).FileId;
                        FileManager fmShortcutContainer = main.AtMng.GetFile(fileid);
                        fACWizard fACWNewShortcutContainer = new fACWizard(fmShortcutContainer, ACEngine.Step.CreateFile, UIHelper.AtMng.GetSetting(AppIntSetting.NewShortcutContainerAcId));
                        fACWNewShortcutContainer.OpenFile = false;
                        fACWNewShortcutContainer.ShowDialog(main);
                        fACWNewShortcutContainer.Close();

                        //UserControls.ucBrowse ucb = (UserControls.ucBrowse)sender;
                        //ucb.myFTV.LoadLevelPublic(

                        //Have to find a way to reload nodes appropriately
                        //need a reference to FileTreeView to reload node
                        //this code does not function in FileTreeView since moved from ucOfficerToolkit
                        //ndShortcutContainer.Nodes.Clear();
                        //lmWinHelper.LoadDocShortcuts(ndShortcutContainer, main.AtMng);
                        break;
                    case FileContextMenuItem.MoveFileShortcut:
                        TreeNode nd7 = (TreeNode)e.Node;
                        appDB.EFileSearchRow efilesr = null;

                        if (nd7.Tag.GetType() == typeof(appDB.EFileSearchRow))
                            efilesr = (appDB.EFileSearchRow)nd7.Tag;

                        fBrowse fbmfs = new fBrowse(main.AtMng, 0, false, true, true, true);
                        fbmfs.FindFile(efilesr.FileId);

                        if (fbmfs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            FileManager thisfm = main.AtMng.GetFile(efilesr.FileId);
                            UIHelper.MoveFileShortcut(thisfm, efilesr.xrefId, fbmfs.SelectedFile.FileId);
                            atLogic.BusinessProcess bp = main.AtMng.GetBP();
                            bp.AddForUpdate(thisfm.GetFileXRef());
                            try
                            {
                                bp.Update();

                            }
                            catch (Exception x)
                            {

                                thisfm.DB.FileXRef.RejectChanges();
                                throw;
                            }
                            e.Node.Remove();
                        }
                        break;
                    case FileContextMenuItem.RenameFileShortcut:
                    case FileContextMenuItem.RenameShortcutContainer:
                    case FileContextMenuItem.docXrefRename:
                        if (e.Node != null)
                        {
                            e.Node.TreeView.LabelEdit = true;
                            TreeNode nd6 = e.Node;
                            if (e.SelectedFile != null && e.Node.Tag != null && e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                            {
                                appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)e.Node.Tag;
                                if (efsr.LinkType == (int)FXLinkType.ParentChild)
                                    e.Node.Text = e.SelectedFile.Name;
                            }
                            nd6.BeginEdit();
                        }
                        break;
                    case FileContextMenuItem.DeleteShortcutContainer:
                        TreeNode nd5 = (TreeNode)e.Node;
                        appDB.EFileSearchRow efsr5 = (appDB.EFileSearchRow)nd5.Tag;
                        FileManager fmDelFolder = main.AtMng.GetFile(efsr5.FileId);

                        if (fmDelFolder.EFile.CanDelete(fmDelFolder.CurrentFile))
                        {
                            if (UIHelper.ConfirmDelete(LawMate.Properties.Resources.ConfirmDeleteShortcutFile))
                            {
                                try
                                {
                                    fmDelFolder.CurrentFile.Delete();

                                    atLogic.BusinessProcess bp = fmDelFolder.GetBP();
                                    bp.AddForUpdate(fmDelFolder.EFile);
                                    bp.Update();
                                    nd5.Remove();
                                }
                                catch (Exception x)
                                {
                                    fmDelFolder.DB.EFile.RejectChanges();
                                    UIHelper.HandleUIException(x);
                                }
                            }
                        }
                        break;
                    case FileContextMenuItem.MoveShortcutContainer:
                        fBrowse fb = new fBrowse(main.AtMng, 0, false, true, true, true);
                        fb.FindFile(e.SelectedFile.FileId);

                        if (fb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            FileManager thisfm = main.AtMng.GetFile(e.SelectedFile.FileId);
                            UIHelper.MoveFile(thisfm, fb.SelectedFile.FileId);
                            atLogic.BusinessProcess bp = main.AtMng.GetBP();
                            bp.AddForUpdate(thisfm.GetFileXRef());
                            bp.AddForUpdate(thisfm.EFile);
                            try
                            {
                                bp.Update();

                            }
                            catch (Exception x)
                            {

                                thisfm.DB.EFile.RejectChanges();
                                thisfm.DB.FileXRef.RejectChanges();
                                throw;
                            }
                            e.Node.Remove();
                        }
                        break;
                    case FileContextMenuItem.MoveFile:
                        fBrowse f = new fBrowse(main.AtMng, 0, false, false, false, true);
                        f.FindFile(e.SelectedFile.FileId);
                        if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            FileManager thisfm = main.AtMng.GetFile(e.SelectedFile.FileId);
                            UIHelper.MoveFile(thisfm, f.SelectedFile.FileId);
                            atLogic.BusinessProcess bp = main.AtMng.GetBP();
                            bp.AddForUpdate(thisfm.GetFileXRef());
                            bp.AddForUpdate(thisfm.EFile);
                            try
                            {
                                bp.Update();

                            }
                            catch (Exception x)
                            {

                                thisfm.DB.EFile.RejectChanges();
                                thisfm.DB.FileXRef.RejectChanges();
                                throw;
                            }
                            e.Node.Remove();
                        }
                        break;
                    case FileContextMenuItem.ViewExplorer:
                        JumpToExplorer(main, e.SelectedFile.FileId);
                        break;
                    case FileContextMenuItem.Refresh:
                        ucFileContextMenu ufcm = (ucFileContextMenu)sender;
                        FileTreeView ftv = ufcm.Ftv;
                        e.Node.Nodes.Clear();
                        ftv.LoadLevelPublic(e.Node, e.SelectedFile);
                        e.Node.Expand();
                        break;
                    case FileContextMenuItem.AddToShortcuts:
                        AddToMyShortcuts(main.AtMng, e.SelectedFile);
                        break;
                    case FileContextMenuItem.CreateXRef:
                        CreateNewXRef(main.AtMng, e.SelectedFile);
                        break;
                    case FileContextMenuItem.RenameFile:
                        e.Node.BeginEdit();
                        break;
                    case FileContextMenuItem.SearchFiles:
                        fAdvancedSearch fsf = new fAdvancedSearch(main);
                        fsf.MdiParent = main;
                        fsf.setSearchPath(e.SelectedFile, fAdvancedSearch.SearchType.File);
                        fsf.Show();
                        break;
                    case FileContextMenuItem.SearchDocuments:
                        fAdvancedSearch fsd = new fAdvancedSearch(main);
                        fsd.MdiParent = main;
                        fsd.setSearchPath(e.SelectedFile, fAdvancedSearch.SearchType.Document);
                        fsd.Show();
                        break;
                    case FileContextMenuItem.SearchOpinions:
                        fAdvancedSearch fsopn = new fAdvancedSearch(main);
                        fsopn.MdiParent = main;
                        fsopn.setSearchPath(e.SelectedFile, fAdvancedSearch.SearchType.Document);
                        fsopn.OpinionSearch();
                        fsopn.Show();
                        break;
                    case FileContextMenuItem.NewFile:
                        FileManager fm = main.AtMng.GetFile(e.SelectedFile.FileId);
                        fACWizard fACW = new fACWizard(fm, ACEngine.Step.CreateFile, UIHelper.AtMng.GetSetting(AppIntSetting.NewFileAcId));
                        fACW.ShowDialog(main);
                        fACW.Close();
                        break;
                    case FileContextMenuItem.NewOffice:
                        FileManager fmOffice = main.AtMng.GetFile(e.SelectedFile.FileId);
                        fACWizard fACWOffice = new fACWizard(fmOffice, ACEngine.Step.CreateFile, UIHelper.AtMng.GetSetting(AppIntSetting.NewOfficeAcId));
                        fACWOffice.ShowDialog(main);
                        fACWOffice.Close();
                        break;
                    case FileContextMenuItem.FileXrefView:
                    case FileContextMenuItem.ViewFile:
                        main.OpenFile(e.SelectedFile.FileId);
                        break;
                    case FileContextMenuItem.NewActivity:
                        fFile flw = main.OpenFile(e.SelectedFile.FileId);
                        flw.LaunchWizard();
                        break;
                    case FileContextMenuItem.NewMail:
                        fFile flnm = main.OpenFile(e.SelectedFile.FileId);
                        flnm.LaunchNewDocMailMemo(ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.MailCodeAcId));
                        break;
                    case FileContextMenuItem.NewDocument:
                        fFile flnd = main.OpenFile(e.SelectedFile.FileId);
                        flnd.LaunchNewDocMailMemo(ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.NewWordDocAcId));
                        break;
                    case FileContextMenuItem.NewFaxCoverSheet:
                        fFile flfax = main.OpenFile(e.SelectedFile.FileId);
                        flfax.LaunchNewDocMailMemo(ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.NewFaxCoverAcId));
                        break;
                    case FileContextMenuItem.NewMemo:
                        fFile flMemo = main.OpenFile(e.SelectedFile.FileId);
                        flMemo.LaunchNewDocMailMemo(ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.NewMemoAcId));
                        break;
                    case FileContextMenuItem.FileProperties:
                        fFile f1 = main.OpenFile(e.SelectedFile.FileId);
                        f1.MoreInfo("efile", e.SelectedFile.FileId);
                        break;
                    case FileContextMenuItem.FileStats:
                        //TODO: re-enable when 2010 reportviewer is approved.
                        //Microsoft.Reporting.WinForms.ReportParameter pf = new Microsoft.Reporting.WinForms.ReportParameter("file", e.SelectedFile.FullFileNumber);
                        //Microsoft.Reporting.WinForms.ReportParameter pb = new Microsoft.Reporting.WinForms.ReportParameter("begin", atDates.StandardDate.ThisYear.BeginDate.ToShortDateString());
                        //Microsoft.Reporting.WinForms.ReportParameter pe = new Microsoft.Reporting.WinForms.ReportParameter("end", atDates.StandardDate.ThisYear.EndDate.ToShortDateString());
                        //fReportViewer frw = new fReportViewer(main, "/Lawmate Rpts/File Stats", new Microsoft.Reporting.WinForms.ReportParameter[] { pf, pb, pe });
                        //frw.Show();
                        break;
                    //case FileContextMenuItem.Delete:
                    //if (UIHelper.ConfirmDelete("Are you sure you want to delete this shortcut/cross-reference?"))
                    //{
                    //    appDB.EFileSearchRow parentEfileSearchRow;
                    //    appDB.EFileSearchRow shortcutEfileSearchRow;
                    //    System.Windows.Forms.TreeNode pnd = e.Node.Parent;

                    //    if (pnd.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    //        parentEfileSearchRow = (appDB.EFileSearchRow)pnd.Tag;
                    //    else
                    //    {
                    //        appDB.EFileSearchDataTable efdt = main.AtMng.FileSearchByFileId((int)pnd.Tag);
                    //        parentEfileSearchRow = (appDB.EFileSearchRow)efdt[0];
                    //    }
                    //    if (e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                    //        shortcutEfileSearchRow = (appDB.EFileSearchRow)e.Node.Tag;
                    //    else
                    //    {
                    //        appDB.EFileSearchDataTable efdt2 = main.AtMng.FileSearchByFileId((int)e.Node.Tag);
                    //        shortcutEfileSearchRow = (appDB.EFileSearchRow)efdt2[0];
                    //    }

                    //    atriumBE.FileManager parentFM = main.AtMng.GetFile(parentEfileSearchRow.FileId, false);
                    //    CodesDB.FileXRefRow fxr = parentFM.GetFileXRef().Load(shortcutEfileSearchRow.xrefId);

                    //    fxr.Delete(); ;
                    //    //e.Node.ToolTipText = ShortcutTo + xrefr.Name + " (" + xrefr.FullFileNumber + ")";

                    //    //save
                    //    try
                    //    {
                    //        parentFM.GetFileXRef().Update();
                    //        parentFM.AtMng.AppMan.Commit();
                    //        parentFM.DB.AcceptChanges();
                    //        e.Node.Remove();
                    //    }
                    //    catch (Exception x)
                    //    {
                    //        parentFM.AtMng.AppMan.Rollback();
                    //        parentFM.DB.RejectChanges();
                    //        System.Windows.Forms.MessageBox.Show(x.Message);
                    //    }
                    //}
                    //break;
                    case FileContextMenuItem.DynMenu:
                        if (e.ACSeries.InitialStep == (int)ACEngine.Step.CreateFile)
                        {
                            FileManager fmDyn = main.AtMng.GetFile(e.SelectedFile.FileId);
                            fACWizard fACWDyn = new fACWizard(fmDyn, (ACEngine.Step)e.ACSeries.InitialStep, e.ACSeries.ACSeriesId);
                            fACWDyn.ShowDialog(main);
                            fACWDyn.Close();
                        }
                        else// if (e.ACSeries.InitialStep == (int)ACEngine.Step.Document)
                        {
                            fFile fldyn = main.OpenFile(e.SelectedFile.FileId);
                            fldyn.LaunchNewDocMailMemo((ACEngine.Step)e.ACSeries.InitialStep, e.ACSeries.ACSeriesId);

                        }

                        break;
                    default:
                        throw new LMException("Shortcut menu option not implemented");

                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        public static void JumpToExplorer(fMain main, int fileId)
        {
            fExplorer fbd = new fExplorer(main, 0);
            fbd.FindFile(fileId);
            fbd.Show();
        }

        public static void SaveGridLayout(Janus.Windows.GridEX.GridEX gridEx, string gridExName, atriumManager atmng, string versionNumber)
        {
            string layoutDir;
            FileStream layoutStream;
            DirectoryInfo dInfo;
            dInfo = new DirectoryInfo(atmng.AppMan.LawMatePath);
            dInfo = new DirectoryInfo(dInfo.FullName + @"\LayoutData");
            if (!dInfo.Exists) dInfo.Create();
            layoutDir = dInfo.FullName + @"\" + gridExName + "_" + versionNumber + "_" + UIHelper.AtMng.AppMan.Language.ToUpper() + ".gxl";
            layoutStream = new FileStream(layoutDir, FileMode.Create);
            gridEx.SaveLayoutFile(layoutStream);
            layoutStream.Close();
        }

        public static void SaveCommandManagerLayout(Janus.Windows.UI.CommandBars.UICommandManager cmdManager, string cmdMngrName, atriumManager atmng, string versionNumber)
        {
            string layoutDir;
            FileStream layoutStream;
            DirectoryInfo dInfo;
            dInfo = new DirectoryInfo(atmng.AppMan.LawMatePath);
            dInfo = new DirectoryInfo(dInfo.FullName + @"\LayoutData");
            if (!dInfo.Exists) dInfo.Create();
            if (versionNumber != null && versionNumber != "")
                layoutDir = dInfo.FullName + @"\" + cmdMngrName + "_" + versionNumber + "_" + UIHelper.AtMng.AppMan.Language.ToUpper() + ".xml";
            else
                layoutDir = dInfo.FullName + @"\" + cmdMngrName + "_" + UIHelper.AtMng.AppMan.Language.ToUpper() + ".xml";

            layoutStream = new FileStream(layoutDir, FileMode.Create);

            cmdManager.SaveLayoutFile(layoutStream);
            layoutStream.Close();
        }

        public static void SavePanelManagerLayout(Janus.Windows.UI.Dock.UIPanelManager pnlManager, string pnlMngrName, atriumManager atmng)
        {
            string layoutDir;
            FileStream layoutStream;
            DirectoryInfo dInfo;
            dInfo = new DirectoryInfo(atmng.AppMan.LawMatePath);
            dInfo = new DirectoryInfo(dInfo.FullName + @"\LayoutData");
            if (!dInfo.Exists) dInfo.Create();
            layoutDir = dInfo.FullName + @"\" + pnlMngrName + "_" + UIHelper.AtMng.AppMan.Language.ToUpper() + ".xml";
            layoutStream = new FileStream(layoutDir, FileMode.Create);
            pnlManager.SaveLayoutFile(layoutStream);
            layoutStream.Close();
        }

        public static void LoadGridLayout(Janus.Windows.GridEX.GridEX gridEx, string gridExName, string versionNumber)
        {
            string layoutDir = GetLayoutDirectory() + @"\" + gridExName + "_" + versionNumber + "_" + main.AtMng.AppMan.Language.ToUpper() + ".gxl";
            if (FileExists(layoutDir))
            {
                //TFS#50988 BY 2013-08-22 
                //added to enure layout file can be read, otherwise reset to defaultLayout 
                Janus.Windows.GridEX.GridEXLayout defaultLayout = gridEx.GetLayout();
                try
                {
                    using (FileStream layoutStream = new FileStream(layoutDir, FileMode.Open))
                    {
                        gridEx.ClearStructure();
                        gridEx.LoadLayoutFile(layoutStream);
                        layoutStream.Close();
                    }
                }
                catch (Exception x)
                {
                    gridEx.LoadLayout(defaultLayout);
                    MessageBox.Show(Properties.Resources.layoutResetGridEx, Properties.Resources.layoutGridExCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            UIHelper.GridToggleSelectMode(gridEx);
        }
        public static void LoadCommandManagerLayout(Janus.Windows.UI.CommandBars.UICommandManager cmdManager, string cmdMngrName, string versionNumber)
        {
            string layoutDir;
            if (versionNumber != null && versionNumber != "")
                layoutDir = GetLayoutDirectory() + @"\" + cmdMngrName + "_" + versionNumber + "_" + main.AtMng.AppMan.Language.ToUpper() + ".xml";
            else
                layoutDir = GetLayoutDirectory() + @"\" + cmdMngrName + "_" + main.AtMng.AppMan.Language.ToUpper() + ".xml";

            if (FileExists(layoutDir))
            {
                Janus.Windows.UI.CommandBars.UICommandBarsLayout defaultLayout = cmdManager.GetLayout();
                try
                {
                    FileStream layoutStream;
                    layoutStream = new FileStream(layoutDir, FileMode.Open);
                    cmdManager.LoadLayoutFile(layoutStream);
                    layoutStream.Close();
                }
                catch (Exception x)
                {
                    cmdManager.LoadLayout(defaultLayout);
                    MessageBox.Show(Properties.Resources.layoutResetCmdMngr, Properties.Resources.layoutCmdMngrCaption, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
            
        }


        public static void LoadPanelManagerLayout(Janus.Windows.UI.Dock.UIPanelManager pnlManager, string pnlMngrName)
        {
            string layoutDir = GetLayoutDirectory() + @"\" + pnlMngrName + "_" + main.AtMng.AppMan.Language.ToUpper() + ".xml";
            if (FileExists(layoutDir))
            {
                Janus.Windows.UI.Dock.UIPanelLayout defaultLayout = pnlManager.GetLayout();

                try
                {
                    FileStream layoutStream;
                    layoutStream = new FileStream(layoutDir, FileMode.Open);
                    pnlManager.LoadLayoutFile(layoutStream);
                    layoutStream.Close();
                }
                catch (Exception x)
                {
                    pnlManager.LoadLayout(defaultLayout);
                    MessageBox.Show(Properties.Resources.layoutResetPanelMngr, Properties.Resources.layoutPanelMngrCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public static void UpdateLayout(Janus.Windows.UI.Dock.UIPanelManager pnlManager)
        {
            //To persist user changes in the current layout,
            //call the Update method explicitly before changing the layout
            if (pnlManager.CurrentLayout != null)
                pnlManager.CurrentLayout.Update();
        }

        public static void UpdateLayout(Janus.Windows.UI.CommandBars.UICommandManager cmdManager)
        {
            //To persist user changes in the current layout,
            //call the Update method explicitly before changing the layout
            if (cmdManager.CurrentLayout != null)
                cmdManager.CurrentLayout.Update();
        }

        public static void UpdateLayout(Janus.Windows.GridEX.GridEX gridEx)
        {
            //To persist user changes in the current layout,
            //call the Update method explicitly before changing the layout
            if (gridEx.CurrentLayout != null)
                gridEx.CurrentLayout.Update();
        }


        public static bool FileExists(string fileName)
        {
            FileInfo fInfo = new FileInfo(fileName);
            return fInfo.Exists;
        }

        public static string GetLayoutDirectory()
        {
            if (!Directory.Exists(main.AtMng.AppMan.LawMatePath))
                Directory.CreateDirectory(main.AtMng.AppMan.LawMatePath);

            DirectoryInfo currentDirectory = new DirectoryInfo(main.AtMng.AppMan.LawMatePath);

            DirectoryInfo[] childDirectories = currentDirectory.GetDirectories();
            foreach (DirectoryInfo childDir in childDirectories)
            {

                if (childDir.Name == "LayoutData")
                {
                    return childDir.FullName;
                }

            }

            return "";
        }


        public static void DisplayDocInLawMateViewer(docDB.DocXRefRow docxrefrow)
        {
            FileManager fmDoc = main.AtMng.GetFile(docxrefrow.FileId);
            DocManager dmDoc = fmDoc.GetDocMng();
            docDB.DocumentRow dr2 = dmDoc.GetDocument().Load(docxrefrow.DocId);
            fDocView fd = new fDocView(dmDoc, dr2);
            fd.Show();
        }

        public static void ucBrowseDoubleClickHandler(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag.GetType() == typeof(appDB.EFileSearchRow))
                {
                    appDB.EFileSearchRow efsr = (appDB.EFileSearchRow)e.Node.Tag;
                    main.OpenFile(efsr.FileId);
                }
                else if (e.Node.Tag.GetType() == typeof(docDB.DocXRefRow))
                {
                    docDB.DocXRefRow docxrefrow = (docDB.DocXRefRow)e.Node.Tag;
                    DisplayDocInLawMateViewer(docxrefrow);
                }
            }
        }

        public static void ReplyForward(atriumBE.FileManager ActFM, int actId, atriumBE.ConnectorType conn)
        {
            ReplyForward(ActFM, actId, conn, false);
        }
        public static void ReplyForward(atriumBE.FileManager ActFM, int actId, atriumBE.ConnectorType conn,bool allowCancel)
        {

            bool isSingle = false;
            fFile ffns = null;
            if (!main.VerifyOpenForm("fFile" + ActFM.CurrentFile.FileId.ToString()))
                ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            else
                ffns = (fFile)main.GetOpenForm("fFile" + ActFM.CurrentFile.FileId.ToString());

            try
            {
                if (ActFM.InitActivityProcess().CurrentACE != null | (ffns != null && ffns.ReadOnly))
                {
                    isSingle = true;
                    throw new LMException("You cannot enter more than one activity at a time on a file.");
                }

                if (ffns != null)
                    ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.ReplyForwardCodeAcId), actId, conn);
                if (ffns != null)
                {
                    ffns.HookupWizClose(facwr);

                    ffns.fileToc.LoadTOC();
                }
                if (allowCancel)
                {
                    if (facwr.ShowDialog() != DialogResult.OK)
                    {
                        facwr.Close();
                        throw new LMException("Import cancelled.");
                    }
                    facwr.Close();
                }
                else
                {
                    facwr.Show();
                }
            }
            catch (Exception x1)
            {
                if (!isSingle)
                {
                    if (ffns != null)
                        ffns.ReadOnly = false;
                    ActFM.KillACEngine();
                }
                throw x1;
            }

        }

        private static fMain main
        {
            get
            {
                return fMain.Main;
            }
        }

        public static void NewMail(atriumBE.FileManager ActFM)
        {

            fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            try
            {
                ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.MailCodeAcId));
                ffns.HookupWizClose(facwr);
                ffns.fileToc.LoadTOC();
                facwr.Show();
            }
            catch (Exception x1)
            {
                ffns.ReadOnly = false;
                ActFM.KillACEngine();
                throw x1;
            }

        }

        public static void NewMail(atriumBE.FileManager ActFM, int attDocId)
        {
            fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            try
            {
                ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.MailCodeAcId), attDocId, "SENDATT");
                ffns.HookupWizClose(facwr);
                ffns.fileToc.LoadTOC();
                facwr.Show();
            }
            catch (Exception x1)
            {
                ffns.ReadOnly = false;
                ActFM.KillACEngine();
                throw x1;
            }
        }

        public static void NewMail(atriumBE.FileManager ActFM, string ContactEmail)
        {
            fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            try
            {
                ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.MailCodeAcId), ContactEmail);
                ffns.HookupWizClose(facwr);
                ffns.fileToc.LoadTOC();
                facwr.Show();
            }
            catch (Exception x1)
            {
                ffns.ReadOnly = false;
                ActFM.KillACEngine();
                throw x1;
            }
        }

        public static void ReviseDocument(atriumBE.FileManager ActFM, int docId)
        {
            fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            try
            {
                ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.ReviseDocCodeAcId), docId, "REVISE");
                ffns.HookupWizClose(facwr);
                ffns.fileToc.LoadTOC();
                facwr.Show();
            }
            catch (Exception x1)
            {
                ffns.ReadOnly = false;
                ActFM.KillACEngine();
                throw x1;
            }
        }
        public static void CopyDocument(atriumBE.FileManager ActFM, int docId, UserControls.DocActionEnum docAction)
        {
            switch (docAction)
            {
                case UserControls.DocActionEnum.CopyAndOpen:
                    fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
                    try
                    {
                        ffns.ReadOnly = true;
                        fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, UIHelper.AtMng.GetSetting(AppIntSetting.DocumentCopyAcId), docId, "REVISE");
                        ffns.HookupWizClose(facwr);
                        ffns.fileToc.LoadTOC();
                        facwr.Show();
                    }
                    catch (Exception x1)
                    {
                        ffns.ReadOnly = false;
                        ActFM.KillACEngine();
                        throw x1;
                    }
                    break;
                case UserControls.DocActionEnum.CopyOnly:
                    ActFM.InitActivityProcess().DoAutoAC(null, ActFM.AtMng.acMng.DB.ACSeries.FindByACSeriesId(UIHelper.AtMng.GetSetting(AppIntSetting.DocumentCopyAcId)), docId, ACEngine.RevType.Document);
                    break;
            }
        }

        public static void NewDocument(atriumBE.FileManager ActFM, int acSeriesId)
        {
            fFile ffns = main.OpenFile(ActFM.CurrentFile.FileId);
            try
            {
                ffns.ReadOnly = true;
                fACWizard facwr = new fACWizard(ActFM, ACEngine.Step.Document, acSeriesId);
                ffns.HookupWizClose(facwr);
                ffns.fileToc.LoadTOC();
                facwr.Show();
            }
            catch (Exception x1)
            {
                ffns.ReadOnly = false;
                ActFM.KillACEngine();
                throw x1;
            }
        }

        public static void DocAction(FileManager fm, UserControls.DocActionEventArgs e)
        {
            switch (e.Action)
            {
                case UserControls.DocActionEnum.Revise:
                    ReviseDocument(fm, e.DocRecord.DocId);
                    break;
                case UserControls.DocActionEnum.CopyAndOpen:
                    CopyDocument(fm, e.DocRecord.DocId, UserControls.DocActionEnum.CopyAndOpen);
                    break;
                case UserControls.DocActionEnum.CopyOnly:
                    CopyDocument(fm, e.DocRecord.DocId, UserControls.DocActionEnum.CopyOnly);
                    break;
                case UserControls.DocActionEnum.SendAsAttachment:
                    NewMail(fm, e.DocRecord.DocId);
                    break;
            }
        }


    }

    public class HourGlass : IDisposable
    {
        public HourGlass()
        {
            Enabled = true;
        }
        public void Dispose()
        {
            Enabled = false;
        }
        public static bool Enabled
        {
            get { return Application.UseWaitCursor; }
            set
            {
                if (value == Application.UseWaitCursor) return;
                Application.UseWaitCursor = value;
                Form f = Form.ActiveForm;
                if (f != null && f.Handle != null)   // Send WM_SETCURSOR
                    SendMessage(f.Handle, 0x20, f.Handle, (IntPtr)1);
            }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }

}



