using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;
using System.Runtime.InteropServices;

namespace LawMate
{
    public partial class ucToC : UserControl
    {
        atriumBE.FileManager fmCurrent;
        atriumBE.atriumManager Atmng;
        fFile ParentFile;
        int fileId;
        int programId = 0; // WI 75873
        int defaultTopHeight = 172;
        int defaultRowHeight = 18;
        /// <summary>
        /// Sets the selected node on tvContents of file's TOC by passing the string to find the node (string is used to set tvContents.Nodes[value]).
        /// </summary>
        public string SelectedNode
        {
            set
            {
                try
                {
                    if (tvContents.Nodes.ContainsKey(value))
                        tvContents.SelectedNode = tvContents.Nodes.Find(value, true)[0];
                }
                catch (Exception x)
                {
                    //ignore
                }
            }
        }
        public int FileId
        {
            get { return fileId; }
        }

        public ucToC()
        {
            InitializeComponent();
        }
        public void Init(atriumBE.FileManager fm, fFile parentFile)
        {
            fmCurrent = fm;
            Atmng = fm.AtMng;

            ParentFile = parentFile;
            fileId = fm.CurrentFile.FileId;

            
            if (UIHelper.getScalingFactor() > 1)
                tvContents.ItemHeight = tvContents.ItemHeight + 2;

            //JLL 2015-08-30 higher dpi setting handling
            //defaultTopHeight = UIHelper.AdjustHeightInt(this, defaultTopHeight);
            //defaultRowHeight = UIHelper.AdjustHeightInt(this, defaultRowHeight);
            //END JLL 2015-08-30


                // WI 75873
            if (fm.GetSSTMng()!=null && !fm.CurrentFile.IsDim2IdNull())
                programId = fm.CurrentFile.Dim2Id;
            // -- end // WI 75873

            fm.EFile.OnUpdate += new atLogic.UpdateEventHandler(EFile_OnUpdate);
            fm.GetFileXRef().OnUpdate += new atLogic.UpdateEventHandler(ucToC_OnUpdate);

            LoadTOC();
        }

        void ucToC_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            LoadTOC();
        }


        void EFile_OnUpdate(object sender, atLogic.UpdateEventArgs e)
        {
            if (e.ChangedRows[0].RowState == DataRowState.Deleted)
                ParentFile.Close();
            else
                LoadTOC();
        }

        private void SetFileStatusColor(string statuscode)
        {
            Janus.Windows.UI.UIFormatStyle fs = new Janus.Windows.UI.UIFormatStyle();
            Color bgcolor = Color.Blue;
            switch (statuscode.ToUpper())
            {
                case "A":
                    bgcolor = Color.Navy;
                    break;
                case "C":
                    bgcolor = Color.Fuchsia;
                    break;
                case "M":
                    bgcolor = Color.Red;
                    break;
                case "P":
                    bgcolor = Color.DarkOrange;
                    break;
                case "O":
                case "R":
                case "F":
                default:
                    bgcolor = Color.Blue;
                    break;
            }

            lblStatusValue.BackColor = bgcolor;
        }

        public void LoadTOC()
        {
            pnlDockTop.Height = defaultTopHeight;
            if (fmCurrent.DB.FileXRef.Select("LinkType=0 and fileid=" + fmCurrent.CurrentFileId.ToString()).Length > 0)
                pnlBrowseFiles.Enabled = true;
            else
                pnlBrowseFiles.Enabled = false;

            if (fmCurrent.DB.FileXRef.Select("LinkType=1").Length > 0 || fmCurrent.DB.FileXRef.Select("LinkType=2 and fileid="+fmCurrent.CurrentFileId).Length > 0)
                pnlXRefs.Enabled = true;
            else
                pnlXRefs.Enabled = false;

            SetTooltipsForLinks();
            SetFileStatusColor(fmCurrent.CurrentFile.StatusCode);

            officeDB.OfficeRow orOwnerOffice = null;
            try
            {
                orOwnerOffice = fmCurrent.AtMng.GetOffice(fmCurrent.CurrentFile.OwnerOfficeId).CurrentOffice;
                lnkJumpToOwnerFile.Tag = orOwnerOffice.OfficeFileId;
                lnkJumpToOwnerFile.Enabled = (orOwnerOffice.OfficeFileId != fileId);
            }
            catch (Exception xoo)
            {
                lnkJumpToOwnerFile.Enabled = false;
            }

            officeDB.OfficeRow orLeadOffice = null;
            if (!fmCurrent.CurrentFile.IsLeadOfficeIdNull())
            {
                try
                {
                    orLeadOffice = fmCurrent.AtMng.GetOffice(fmCurrent.CurrentFile.LeadOfficeId).CurrentOffice;
                    lnkJumpToLeadFile.Visible = true;
                    lnkJumpToLeadFile.Tag = orLeadOffice.OfficeFileId;
                    lnkJumpToLeadFile.Enabled = (orLeadOffice.OfficeFileId != fileId);
                }
                catch (Exception xlo)
                {
                    lnkJumpToLeadFile.Enabled = false;
                }
            }
            else
                lnkJumpToLeadFile.Visible = false;

            if (!fmCurrent.CurrentFile.IsFullFileNumberNull())
                lblFullNumberValue.Text = fmCurrent.CurrentFile.FullFileNumber;
            else
                lblFullNumberValue.Text = "";

            lblFilenameValue.Text = fmCurrent.CurrentFile.Name;

            atriumDB.ActivityRow ar = fmCurrent.GetActivity().GetCurrentCaseStatus(DateTime.Today.AddDays(100));
            int csId =0;
            if (ar != null)
            {
                csId = ar.CaseStatusId;
                lblStatusDateValue.Text = ar.ActivityDate.ToString("yyyy/MM/dd");
            }
            else
            {
                lblStatusDateValue.Text ="N/A";
            }

            // WI 75873
            DataRow drProgram = null;
            if (programId > 0)
            {
                DataTable dt = Atmng.GetFile().Codes("Dim2");
                DataRow[] dr = dt.Select("ProgramId = " + programId.ToString());
                drProgram = dr[0];

                appDB.ddLookupRow dlr = (appDB.ddLookupRow)Atmng.DB.ddLookup.Select("LookupName='Dim2'")[0];
                lblProgram.Text = dlr["Description" + Atmng.AppMan.Language].ToString();
            }
            else
            {
                lblProgram.Visible = false;
                lblProgramValue.Visible = false;
                pnlDockTop.Height -= defaultRowHeight;
            }
            // -- End // WI 75873
            
            //Shared Folder START
            lblSharedFolder.Visible = false;
            lnkSharedFolder.Visible = false;
            string sharedPath = string.Empty;
            if (programId == 3)
                sharedPath = Atmng.GetSetting(AppStringSetting.DataExchangeNetworkPath) + fmCurrent.CurrentFile.FullFileNumber.Replace("-", @"\");
            else if (programId == 2)
                sharedPath = Atmng.GetSetting(AppStringSetting.ISDataExchangeNetworkPath) + fmCurrent.CurrentFile.FullFileNumber.Replace("-", @"\");

            if (sharedPath != string.Empty && System.IO.Directory.Exists(sharedPath))
            {
                lnkSharedFolder.Text = sharedPath;
                lblSharedFolder.Visible = true;
                lnkSharedFolder.Visible = true;
            }
            else
                pnlDockTop.Height -= defaultRowHeight;
            //Shared Folder END

            lblTypeValue.Text = fmCurrent.AtMng.CodeDB.FileType.FindByFileTypeCode(fmCurrent.CurrentFile.FileType)["FileTypeDesc" + Atmng.AppMan.languageCamel].ToString();
            lblStatusValue.Text = fmCurrent.AtMng.CodeDB.Status.FindByStatusCode(fmCurrent.CurrentFile.StatusCode)["StatusDesc" + Atmng.AppMan.languageCamel].ToString();
            lblCaseStatusValue.Text = fmCurrent.AtMng.CodeDB.CaseStatus.FindByCaseStatusId(csId)["CaseStatusDesc" + Atmng.AppMan.languageCamel].ToString();
            if (drProgram != null)
                lblProgramValue.Text = (string)drProgram["ProgramDescription" + Atmng.AppMan.languageCamel].ToString();

            if (orOwnerOffice != null)
                setOfficeTooltip(lnkJumpToOwnerFile, orOwnerOffice);
            if (orLeadOffice != null)
                setOfficeTooltip(lnkJumpToLeadFile, orLeadOffice);

            //CLAS
            if (fmCurrent.GetCLASMng()!=null && !fmCurrent.CurrentFile.IsOpponentIDNull())
            {
                lmDatasets.CLAS.DebtorRow orDB = fmCurrent.GetCLASMng().GetDebtor().FindLoad(fmCurrent.CurrentFile.OpponentID);

                if (!orDB.IsNull("SIN"))
                    lblSINValue.Text = atriumBE.DebtorBE.FormattedSIN(orDB.SIN);
                else
                    lblSINValue.Text = "";

                lnkSINLabel.Visible = true;
                lblSINValue.Visible = true;

                if (!fmCurrent.CurrentFile.IsLeadParalegalIDNull())
                {
                    lmDatasets.officeDB.OfficerRow orPL = fmCurrent.AtMng.GetOffice(fmCurrent.CurrentFile.OwnerOfficeId).GetOfficer().FindLoad(fmCurrent.CurrentFile.LeadParalegalID);
                    lblParaLegalValue.Text = orPL.LastName + ", " + orPL.FirstName + " (" + orPL.OfficerCode + ")";
                    lblParalegal.Visible = true;
                    lblParaLegalValue.Visible = true;
                }
                else
                {
                    lblParaLegalValue.Text = "";
                    lblParalegal.Visible = false;
                    lblParaLegalValue.Visible = false;
                }
            }
            else
            {   //no CLAS; hide row
                lnkSINLabel.Visible = false;
                lblSINValue.Visible = false;
                lblParalegal.Visible = false;
                lblParaLegalValue.Visible = false;
                pnlDockTop.Height -= defaultRowHeight;
            }

            ParentFile.uiPanel0.Text = fmCurrent.CurrentFile.Name;
            ucBrowse1.FileContextMenu.UsedInTreeView = false;

            if (fmCurrent.CurrentFile.FileStructXml != null)
            {
                tvContents.Nodes.Clear();
                System.Xml.XmlDocument xdToc = new System.Xml.XmlDocument();
                xdToc.InnerXml = fmCurrent.CurrentFile.FileStructXml;
                LoadTOCNode(tvContents.Nodes, xdToc.DocumentElement);
                tvContents.ExpandAll();
                tvContents.Nodes[0].EnsureVisible();
            }
        }

        private void setOfficeTooltip(LinkLabel lnk, officeDB.OfficeRow or)
        {
            lnk.Text = or.OfficeCode;
            string address = "";
            if (!or.IsCityNull())
                address = or.City;
            if (!or.IsProvinceCodeNull())
            {
                if (address == "")
                    address = or.ProvinceCode;
                else
                    address += ", " + or.ProvinceCode;
            }
            if (!or.IsCountryCodeNull())
            {
                if (address == "")
                    address = or.CountryCode;
                else
                    address += ", " + or.CountryCode;
            }
            string addressLbl = address + Environment.NewLine;

            string tel = "";
            string tollfree = "";
            string fax = "";

            if (!or.IsWorkPhoneNull())
            {
                string tmp = or.WorkPhone;
                if (!or.IsWorkExtensionNull())
                    tmp += " Ext. " + or.WorkExtension;
                tel = Environment.NewLine + Properties.Resources.TocOfficeTKTelephone +  tmp;
            }
            if (!or.IsHomePhoneNull())
                tollfree = Environment.NewLine + Properties.Resources.TocOfficeTKTollFree  + or.HomePhone;

            if (!or.IsFaxNumberNull())
                fax = Environment.NewLine + Properties.Resources.TocOfficeTKFax + or.FaxNumber;


            string jlpvalue = "";
            if (!or.IsJudgmentLPNull()) //Judgment LP value exists, show it
                jlpvalue= Environment.NewLine + Environment.NewLine + Properties.Resources.TocOfficeTKJudgLP +  or.JudgmentLP.ToString() + Properties.Resources.TocOfficeTKyears;

            string wlpvalue = "";
            if (!or.IsWritofExecutionLPNull()) //
                wlpvalue = Environment.NewLine + Properties.Resources.TocOfficeTKWritLP + or.WritofExecutionLP.ToString() + Properties.Resources.TocOfficeTKyears;

            
            Janus.Windows.Common.SuperTipSettings jstSettings1 = new Janus.Windows.Common.SuperTipSettings();
            jstSettings1.Image = Properties.Resources.office;
            if (fmCurrent.AtMng.AppMan.Language == "FRE")
                jstSettings1.HeaderText = "(" + or.OfficeCode + ") " + or.OfficeNameFre;
            else
                jstSettings1.HeaderText = "(" + or.OfficeCode + ") " + or.OfficeName;

            if (or.IsOnLine)
            {
                jstSettings1.FooterImage = Properties.Resources.atriumtrans16;
                jstSettings1.FooterText = or.OfficeCode + Properties.Resources.TocOfficeTKusesAtrium;
            }
                
            jstSettings1.Text = addressLbl + tel+ tollfree +fax+  jlpvalue + wlpvalue;
            janusSuperTip1.SetSuperTip(lnk, jstSettings1);
        }

        Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();
        public void SetTooltipsForLinks()
        {
            //full file number tooltip on File Number link

            jstSettings.Text = fmCurrent.CurrentFile.FullFileNumber + "\n" + fmCurrent.CurrentFile.FullPath;
            jstSettings.HeaderText = fmCurrent.CurrentFile.Name;
            jstSettings.HeaderImageKey = "folder.gif";
            janusSuperTip1.SetSuperTip(lblFilenameValue, jstSettings);
            janusSuperTip1.SetSuperTip(lblFullNumberValue, jstSettings);
        }

        public void SetShortcutsXrefs()
        {
            bool hasControls = false;
            if (Atmng != null && fmCurrent != null)
            {
                appDB.EFileSearchDataTable dt = Atmng.FileSearchByParentFileId(fmCurrent.CurrentFileId);
                docDB.DocXRefDataTable dtDocShortcuts = Atmng.DocShortcuts(fmCurrent.CurrentFileId);

                int x = 1;
                string thisParent;
                if (fmCurrent.CurrentFile.FullFileNumber.LastIndexOf("-") < 0)
                    thisParent = fmCurrent.CurrentFile.FullFileNumber;
                else
                    thisParent = fmCurrent.CurrentFile.FullFileNumber.Substring(0, fmCurrent.CurrentFile.FullFileNumber.LastIndexOf("-")); ;

                while (pnlXRefsContainer.Controls.Count > 1)
                {
                    pnlXRefsContainer.Controls.RemoveAt(0); //pnlXRefsContainer.Controls.Count - 1
                }

                Label lblDocShortcut = CreateXrefGroupLabel(LawMate.Properties.Resources.DocumentShortcuts, x);
                x++;
                int count = 0;
                foreach (docDB.DocXRefRow docxref in dtDocShortcuts)
                {
                    CreateShortcutXRefButton(docxref, x);
                    x++;
                    count++;
                }
                lblDocShortcut.Text += " (" + count + ")";
                if (count > 0)
                    hasControls = true;


                Label lblShortcut = CreateXrefGroupLabel(LawMate.Properties.Resources.FileShortcuts, x);
                x++;
                count = 0;
                foreach (appDB.EFileSearchRow efr in dt.Select(" LinkType=2", "XRefName"))
                {
                    CreateShortcutXRefButton(efr, x);
                    x++;
                    count++;
                }
                lblShortcut.Text += " (" + count + ")";
                if (count > 0)
                    hasControls = true;


                Label lblContainer = CreateXrefGroupLabel(LawMate.Properties.Resources.ContainerCrossReferences, x);
                x++;
                count = 0;
                foreach (appDB.EFileSearchRow efr in dt.Select("LinkType=1 ", UIHelper.Translate(fmCurrent, "NameE")))
                {
                    if (fmCurrent.DB.FileMetaType.FindByMetaTypeCode(efr.MetaType).IsContainer)
                    {
                        CreateShortcutXRefButton(efr, x);
                        x++;
                        count++;
                    }
                }
                lblContainer.Text += " (" + count + ")";
                if (count > 0)
                    hasControls = true;

                Label lblLeafOther = CreateXrefGroupLabel(LawMate.Properties.Resources.LeafCrossReferencesInOtherContainers, x);
                x++;
                count = 0;
                foreach (appDB.EFileSearchRow efr in dt.Select("LinkType=1 ", UIHelper.Translate(fmCurrent, "NameE")))
                {
                    if (!fmCurrent.DB.FileMetaType.FindByMetaTypeCode(efr.MetaType).IsContainer)
                    {
                        string trgParent = efr.FullFileNumber.Substring(0, efr.FullFileNumber.LastIndexOf("-"));
                        if (trgParent != thisParent)
                        {
                            CreateShortcutXRefButton(efr, x);
                            x++;
                            count++;
                        }
                    }
                }
                lblLeafOther.Text += " (" + count + ")";
                if (count > 0)
                    hasControls = true;

                Label lblLeafSame = CreateXrefGroupLabel(LawMate.Properties.Resources.LeafCrossReferencesInSameContainer, x);
                x++;
                count = 0;
                foreach (appDB.EFileSearchRow efr in dt.Select("LinkType=1 ", UIHelper.Translate(fmCurrent, "NameE")))
                {
                    if (!fmCurrent.DB.FileMetaType.FindByMetaTypeCode(efr.MetaType).IsContainer)
                    {
                        string trgParent = efr.FullFileNumber.Substring(0, efr.FullFileNumber.LastIndexOf("-"));
                        if (trgParent == thisParent)
                        {
                            CreateShortcutXRefButton(efr, x);
                            x++;
                            count++;
                        }
                    }
                }
                lblLeafSame.Text += " (" + count + ")";
                //if (count > 0)
                //    hasControls = true;
                //pnlXRefs.Enabled = hasControls;
            }
        }

        private Label CreateXrefGroupLabel(string caption, int count)
        {
            Label lbl = new Label();
            lbl.Name = "lblXref" + count.ToString();
            lbl.AutoSize = true;
            lbl.Left = 6;
            lbl.Font = new Font(this.Font, FontStyle.Bold);
            lbl.Top = 28 * count;
            lbl.Text = caption;
            lbl.Padding = new Padding(0, 10, 0, 0);
            pnlXRefsContainer.Controls.Add(lbl);
            return lbl;

        }

        private void LoadTOCNode(TreeNodeCollection nodes, System.Xml.XmlElement xE)
        {
            //check permission on the node before adding it
            string feature = xE.GetAttribute("supertype");
            if (feature == null || feature == "")
                feature = xE.GetAttribute("type");

            
            string fld = xE.Name;
            try
            {
                if (fld == "fld" || Atmng.SecurityManager.CanRead(fmCurrent.CurrentFile.FileId, (atSecurity.SecurityManager.Features)Enum.Parse(typeof(atSecurity.SecurityManager.Features), feature, true)) > atSecurity.SecurityManager.LevelPermissions.No)
                {
                    string tocTitle;
                    string tocTooltip;
                    if (Atmng.AppMan.Language.ToUpper() == "FRE")
                    {
                        tocTitle = "titlef";
                        tocTooltip = "tooltipf";
                    }
                    else
                    {
                        tocTitle = "titlee";
                        tocTooltip = "tooltipe";
                    }

                    TreeNode n = nodes.Add(xE.GetAttribute(tocTitle));
                    n.ToolTipText = xE.GetAttribute(tocTooltip);
                    
                    if (xE.GetAttribute("id") == "")
                        n.Tag = xE.GetAttribute("filter");
                    else
                        n.Tag = xE.GetAttribute("id");

                    n.Name = xE.GetAttribute("type");
                    if (fld == "fld")
                    {
                        n.Tag = "noform";
                        n.NodeFont = new Font("Calibri", (float)9.75, FontStyle.Bold);
                    }
                    else
                    {
                        bool applyDefaults = false;
                        n.ForeColor = Color.Blue;

                        switch (feature)
                        {   //handle features to draw different icons
                            case "efile":
                                if (n.Parent == null) //top node only, not efile properties.
                                {
                                    n.ImageIndex = setTocStatusIcon();
                                    n.SelectedImageIndex = setTocStatusIcon();
                                    n.NodeFont = new Font("Calibri", (float)10, FontStyle.Bold);
                                    n.Text = n.Text; //c# treeview hack to redraw node properly because of font change
                                    n.ForeColor = SystemColors.ControlText;
                                }
                                else
                                    applyDefaults = true;
                                break;
                            default:
                                applyDefaults = true;
                                break;
                        }
                        if (applyDefaults)
                        {
                            n.NodeFont = new Font("Calibri", (float)8.75, FontStyle.Regular);
                            n.Text = n.Text; //c# treeview hack to redraw node properly because of font change
                            n.ImageIndex = 25;
                            n.SelectedImageIndex = 25;
                        }


                        if (xE.GetAttribute("italicize") == "true")
                        {
                            n.ForeColor = SystemColors.ControlDark;
                            n.NodeFont = new Font("Calibri", (float)8.75, FontStyle.Italic);
                        }
                        if (xE.GetAttribute("bold") == "true")
                        {
                            n.NodeFont = new Font("Calibri", (float)8.75, FontStyle.Bold);
                        }
                        if (xE.GetAttribute("strikeout") == "true")
                        {
                            n.NodeFont = new Font("Calibri", (float)8.75, FontStyle.Strikeout);
                        }
                        if (xE.GetAttribute("icon").Length > 0)
                        {
                            n.ImageIndex = Convert.ToInt32(xE.GetAttribute("icon"));
                            n.SelectedImageIndex = Convert.ToInt32(xE.GetAttribute("icon"));
                        }
                    }

                    foreach (System.Xml.XmlElement xc in xE.ChildNodes)
                    {
                        LoadTOCNode(n.Nodes, xc);
                    }
                }
            }
            catch (Exception x)
            {
            }
        }

        private int setTocStatusIcon()
        {
            int rValue;
            switch (fmCurrent.CurrentFile.StatusCode)
            {
                case "P":
                    rValue = 41;
                    break;
                case "M":
                    rValue = 39;
                    break;
                case "C":
                    rValue = 38;
                    break;
                case "A":
                    rValue = 37;
                    break;
                default:
                    rValue = 40;
                    break;
            }
            return rValue;
        }

        private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lnk = (LinkLabel)sender;
                string fileNumber = (string)lnk.Tag;
                atriumBE.FileManager fmLink = Atmng.GetFile(fileNumber);
                ParentFile.MainForm.OpenFile(fmLink.CurrentFile.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tvContents_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    switch (tvContents.HitTest(e.Location).Location)
                    {
                        case TreeViewHitTestLocations.Label:
                        case TreeViewHitTestLocations.Image:
                        case TreeViewHitTestLocations.PlusMinus:
                            if (e.Node.Name == "filexref" | e.Node.Name == "tocxref")
                            {
                                lmDatasets.atriumDB.FileXRefRow fxr = fmCurrent.GetFileXRef().Load(System.Convert.ToInt32(e.Node.Tag));
                                if (fmCurrent.CurrentFile.FileId == fxr.FileId)
                                    ParentFile.MainForm.OpenFile(fxr.OtherFileId);
                                else
                                    ParentFile.MainForm.OpenFile(fxr.FileId);
                                return;
                            }

                            ParentFile.EndEdit();
                            if (this.Enabled == false)
                                return;

                            if (e.Node.Tag.ToString() != "noform")
                            {
                                try
                                {
                                    if ((string)e.Node.Tag == "")
                                        ParentFile.GetUcCtlToc(GetControlForNode(e.Node.Name));
                                    else
                                    {
                                        int id;

                                        if (int.TryParse((string)e.Node.Tag, out id))
                                        {
                                            ParentFile.GetUcCtlToc(GetControlForNode(e.Node.Name), e.Node.Name, System.Convert.ToInt32(e.Node.Tag));
                                        }
                                        else
                                        {
                                            ParentFile.GetUcCtlToc(GetControlForNode(e.Node.Name), e.Node.Name, (string)e.Node.Tag);
                                        }
                                    }
                                }
                                catch (Exception x)
                                {
                                    UIHelper.HandleUIException(x);
                                }
                            }
                            ParentFile.Activate();
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private string GetControlForNode(string node)
        {
            switch (node.ToLower())
            {
                case "writ":
                case "cost":
                    return "judgment";
                  
                default:
                    return node;
                  
            }
        }

        //public void EnableImportantMessageLink(bool enable)
        //{
        //    if (enable)
        //        cmdImportantMessage.Enabled = Janus.Windows.UI.InheritableBoolean.True;
        //    else
        //        cmdImportantMessage.Enabled = Janus.Windows.UI.InheritableBoolean.False;
        //}


        private void CreateCheckbox(int id, int count, bool isDocXref)
        {
            //Janus.Windows.EditControls.UICheckBox chk = new Janus.Windows.EditControls.UICheckBox();
            CheckBox chk = new CheckBox();
            if (isDocXref)
                chk.Name = "chkDocXref" + id;
            else
                chk.Name = "chkXref" + id;
            chk.Left = 18;
            chk.Top = (28 * count) + 2;
            chk.Width = 20;
            chk.Checked = true;
            pnlXRefsContainer.Controls.Add(chk);
        }

        private LinkLabel CreateXrefLinkLabel(int id, int count, bool isDocXref)
        {
            LinkLabel lnkLabel = new LinkLabel();
            if (isDocXref)
                lnkLabel.Name = "ebDocXref" + id;
            else
                lnkLabel.Name = "ebXref" + id;

            lnkLabel.Left = 36;
            lnkLabel.Top = 28 * count;
            lnkLabel.ImageList = imageList1;
            lnkLabel.ImageAlign = ContentAlignment.MiddleLeft;
            lnkLabel.Padding = new Padding(18, 0, 0, 0);
            lnkLabel.TextAlign = ContentAlignment.MiddleLeft;
            lnkLabel.AutoEllipsis = true;
            lnkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkLabel_LinkClicked);
            return lnkLabel;
        }

        private void CreateShortcutXRefButton(appDB.EFileSearchRow efr, int count)
        {
            CreateCheckbox(efr.xrefId, count, false);
            LinkLabel lnkLabel = CreateXrefLinkLabel(efr.xrefId, count, false);

            Janus.Windows.Common.SuperTipSettings jstSettings = new Janus.Windows.Common.SuperTipSettings();
            jstSettings.Text = String.Format(LawMate.Properties.Resources.FileName0FileNumber1, efr.Name, efr.FullFileNumber);
            jstSettings.HeaderText = efr.XRefName;

            switch (efr.LinkType)
            {
                case (int)atriumBE.FXLinkType.Shortcut:
                    lnkLabel.ImageKey = "fileShortcut.png";
                    Size sz = System.Windows.Forms.TextRenderer.MeasureText(efr.XRefName, lnkLabel.Font);
                    lnkLabel.Width = sz.Width + 32;
                    lnkLabel.Text = efr.XRefName;
                    jstSettings.HeaderImageKey = "fileShortcut.png";
                    break;
                case (int)atriumBE.FXLinkType.XRef:
                    lnkLabel.ImageKey = "XRefFile.gif";
                    string linkText = String.Format("{0} ({1})", efr.Name, efr.FullFileNumber);
                    Size sz2 = System.Windows.Forms.TextRenderer.MeasureText(linkText, lnkLabel.Font);
                    lnkLabel.Width = sz2.Width + 32;
                    lnkLabel.Text = String.Format("{0} ({1})", efr.Name, efr.FullFileNumber);
                    jstSettings.HeaderImageKey = "XRefFile.gif";
                    break;
            }
            janusSuperTip1.SetSuperTip(lnkLabel, jstSettings);
            lnkLabel.Tag = efr;
            pnlXRefsContainer.Controls.Add(lnkLabel);
        }

        private void CreateShortcutXRefButton(docDB.DocXRefRow docxref, int count)
        {
            CreateCheckbox(docxref.Id, count, false);
            LinkLabel lnkLabel = CreateXrefLinkLabel(docxref.Id, count, false);

            lnkLabel.ImageKey = "docShortcut.gif";
            lnkLabel.Text = docxref.Name;
            Size sz = System.Windows.Forms.TextRenderer.MeasureText(docxref.Name, lnkLabel.Font);
            lnkLabel.Width = sz.Width + 32;
            lnkLabel.Tag = docxref;
            pnlXRefsContainer.Controls.Add(lnkLabel);
        }

        private void lnkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lnklabel = (LinkLabel)sender;
                if (lnklabel.Tag == null)
                    return;

                if (lnklabel.Tag.GetType() == typeof(appDB.EFileSearchRow))
                {
                    int fileid = ((appDB.EFileSearchRow)lnklabel.Tag).FileId;
                    ParentFile.MainForm.OpenFile(fileid);
                }
                else if (lnklabel.Tag.GetType() == typeof(docDB.DocXRefRow))
                {
                    docDB.DocXRefRow docxref = (docDB.DocXRefRow)lnklabel.Tag;
                    lmWinHelper.DisplayDocInLawMateViewer(docxref);
                }

            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void tbLead_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                Janus.Windows.GridEX.EditControls.EditBox ctl = (Janus.Windows.GridEX.EditControls.EditBox)sender;
                int fileid = (int)ctl.Tag;
                ParentFile.MainForm.OpenFile(fileid);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void DoLoadXrefData()
        {
            //fmCurrent.GetFileXRef().LoadByFileId(fmCurrent.CurrentFile.FileId);
            //fmCurrent.GetFileXRef().LoadByOtherFileId(fmCurrent.CurrentFile.FileId);
            foreach (atriumDB.FileXRefRow fxr in fmCurrent.DB.FileXRef)
            {
                if (fxr.LinkType == 1 && ((CheckBox)pnlXRefsContainer.Controls["chkXref" + fxr.Id]).Checked)
                {
                    if (fxr.OtherFileId != fmCurrent.CurrentFile.FileId)
                    {
                        fmCurrent.GetActivity().DeepLoadByFileId(fxr.OtherFileId);
                        fmCurrent.GetDocMng().GetDocument().LoadByFileId(fxr.OtherFileId);
                        //fmCurrent.GetDocMng().GetRecipient().LoadByFileId(fxr.OtherFileId);
                    }
                    else if (fxr.FileId != fmCurrent.CurrentFile.FileId)
                    {
                        fmCurrent.GetActivity().DeepLoadByFileId(fxr.FileId);
                        fmCurrent.GetDocMng().GetDocument().LoadByFileId(fxr.FileId);
                        //fmCurrent.GetDocMng().GetRecipient().LoadByFileId(fxr.FileId);
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
                    case "cmdLoadXrefData":
                        DoLoadXrefData();
                        break;
                    case "cmdSelectAll":
                        foreach (Control ctl in pnlXRefsContainer.Controls)
                        {
                            if (ctl.Name.StartsWith("chkXref"))
                            {
                                ((CheckBox)ctl).Checked = true;
                            }
                        }
                        break;
                    case "cmdDeselectAll":
                        foreach (Control ctl in pnlXRefsContainer.Controls)
                        {
                            if (ctl.Name.StartsWith("chkXref"))
                            {
                                ((CheckBox)ctl).Checked = false;
                            }
                        }
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void ucBrowse1_ContextMenuClicked(object sender, FileContextEventArgs e)
        {
            try
            {
                lmWinHelper.HelpContextMenuClicked(ParentFile.MainForm, sender, e);
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

        private void lnkJumpToOwnerFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lnk = (LinkLabel)sender;
                int FileId = (int)lnk.Tag;
                atriumBE.FileManager fmLink = Atmng.GetFile(FileId);
                ParentFile.MainForm.OpenFile(fmLink.CurrentFile.FileId);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void lnkCopyPathToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                LinkLabel lnk = (LinkLabel)sender;

                if (lnk.Name == "lnkCopyPathToClipboard")
                    Clipboard.SetText(fmCurrent.CurrentFile.FullFileNumber);
                else if (lnk.Name == "lnkCopyNameToClipboard")
                    Clipboard.SetText(fmCurrent.CurrentFile.FullPath);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DoLoadXrefData();
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void uiPanelManager1_PanelAutoHideChanging(object sender, Janus.Windows.UI.Dock.PanelActionCancelEventArgs e)
        {
            try
            {
                if (e.Panel.Name == "pnlDockTop")
                {
                    e.Cancel = true;
                    ParentFile.uiPanel0.AutoHide = !(ParentFile.uiPanel0.AutoHide);
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void lnkSINLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string orig = lnkSINLabel.Text;
                if (lblSINValue.Text.Length > 0)
                {
                    Clipboard.SetText(lblSINValue.Text.Replace(" ", ""));
                    lnkSINLabel.Text = Properties.Resources.TocCopy;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                    lnkSINLabel.Text = orig;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        bool firstBrowse = true;
        private void pnlTab_SelectedPanelChanged(object sender, Janus.Windows.UI.Dock.PanelActionEventArgs e)
        {
            try
            {
                Application.UseWaitCursor = true;
                Application.DoEvents();
                switch (e.Panel.Name)
                {
                    case "pnlBrowseFiles":
                        if (firstBrowse && fmCurrent != null)
                        {
                            ucBrowse1.LoadRoot(Atmng, fmCurrent.CurrentFileId, false, false, false);
                            firstBrowse = false;
                        }

                        break;
                    case "pnlXRefs":
                        SetShortcutsXrefs();
                        break;
                }
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
            finally { Application.UseWaitCursor = false; }
        }

        private void lnkSharedFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lnkSharedFolder.Text);
        }

        //2017-08-03 JLL IUTIR-9831: added linkLabel to copy filename from FileInfoPane
        private void copyFileInfoPaneText(Label label, Label labelValue)
        {
            string orig = label.Text;
            if (labelValue.Text.Length > 0)
            {
                Clipboard.SetText(labelValue.Text);
                label.Text = Properties.Resources.TocCopy;
                Application.DoEvents();
                System.Threading.Thread.Sleep(300);
                label.Text = orig;
            }
        }

        private void lblFullNumber_Click(object sender, EventArgs e)
        {
            try
            {
                copyFileInfoPaneText(lblFullNumber, lblFullNumberValue);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        //2017-08-03 JLL IUTIR-9831: added linkLabel to copy filename from FileInfoPane
        private void lblFileName_Click(object sender, EventArgs e)
        {
            try
            {
                copyFileInfoPaneText(lblFileName, lblFilenameValue);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }
    }
}