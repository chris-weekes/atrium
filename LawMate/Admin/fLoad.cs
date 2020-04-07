using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using lmDatasets;
using atriumBE;
using System.IO;
using System.Xml;
using System.Globalization;

namespace LawMate.Admin
{
    public partial class fLoad : fBase
    {
        enum ImportSource
        {
            LocalPath,
            LotusNotes,
            InfoBank,
            LotusPrePass,
            LotusEmptyFolderFinder
        }

        ActivityConfig.ACSeriesRow acsr;
        int iCount = 0,iFiles=0;

        const string NoFolder = "No local path was selected.";
        const string NoAtriumPath = "No Atrium destination was selected.";
        const string NoActivity = "No Atrium Activity was selected.";
        const string NoFileType = "No Atrium File Type was selected.";
        string pathToEmptyRtfDoc = string.Empty;
        string rtfTemplateName = "C:/LotusDump/RtfTemplate.rtf";
        CultureInfo provider = CultureInfo.InvariantCulture;
        string format = "dd/MM/yyyy hh:mm:ss tt";


        public fLoad()
        {
            InitializeComponent();
        }

        public fLoad(Form f)
            : base(f)
        {
            InitializeComponent();
            ucDest.AtMng = AtMng;
            UIHelper.ComboBoxInit(AtMng.acMng.DB.ACSeries, ucMultiDropDown1, AtMng.GetFile());
            UIHelper.ComboBoxInit(AtMng.GetFile().Codes("FileType"), ucMultiDropDown2, AtMng.GetFile());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                if (folderBrowserDialog1.SelectedPath == "")
                    return;

                ebImportFile.Text = folderBrowserDialog1.SelectedPath;
                pathToEmptyRtfDoc = rtfTemplateName;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        int counter = 0;
        string fileXmlFilename = "__SectionMetadata.xml";
        string leafXmlFilename = "__FileMetadata.xml";
        string StartPath = string.Empty;
        bool isOkToContinue = true;
        private void MakeLotusFile(string localpath, FileManager fmRoot)
        {
            if (!isOkToContinue)
            {
                //check path to see if it matches starting point
                //if not, skip to next
                //if so, start import, and set isoktocontinue to true

                if (localpath == StartPath)
                {
                    //start here
                    isOkToContinue = true;
                    //fmRoot = AtMng.GetFile(Convert.ToInt32(ebParentFileID.Text));
                }
            }

            FileManager fm;
            fm = fmRoot;

            if (!isOkToContinue)
            {
                counter++;
                //continue to next in loop; don't create file/docs
                foreach (string subfile in System.IO.Directory.GetDirectories(localpath))
                {
                    MakeLotusFile(subfile, fm);
                }
            }
            else
            {
                if (chkNewFile.Checked)
                {
                    iFiles++;
                    fm = AtMng.CreateFile(fmRoot);


                    //
                    //  NEED to set FileOpened date ... do we have that date?
                    //


                    string foldername = Path.GetFileName(localpath);
                    string sectionXmlFilename = "__SectionMetadata.xml";
                    string fileXmlFilename = "__FileMetadata.xml";

                    string sectionXmlPath = Path.Combine(localpath, sectionXmlFilename);
                    string fileXmlPath = Path.Combine(localpath, fileXmlFilename);


                    if (counter == 0)
                    {
                        if (foldername == "Human Resources")
                            fm.CurrentFile.FileNumber = "HR";
                        else
                            fm.CurrentFile.FileNumber = NormalizeLength(foldername, 16);
                        fm.CurrentFile.NameE = foldername;
                        fm.CurrentFile.NameF = foldername;
                        fm.CurrentFile.MetaType = "FN";
                        fm.CurrentFile.FileType = "F";
                    }
                    else
                    {
                        if (System.IO.File.Exists(sectionXmlPath))
                        {
                            //We are on a File Container
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(sectionXmlPath);

                            string FileNumber = getNodeValue(xmlDoc, "FileClassDisp");
                            string FullFileNameNumber = getNodeValue(xmlDoc, "FileClass");
                            string FileClassGCDOC = getNodeValue(xmlDoc, "FileClassGCDOC");

                            string FileName;// = FullFileNameNumber.Substring(FileNumber.Length + 1);

                            if (FileClassGCDOC != "")
                            {
                                fm.CurrentFile.MetaType = "SN";
                                fm.CurrentFile.FileType = "F";
                                FileName = FileClassGCDOC;
                                fm.CurrentFile.FileNumber = fm.CurrentFileId.ToString();
                            }
                            else
                            {
                                FileName = FullFileNameNumber.Substring(FileNumber.Length + 1);
                                fm.CurrentFile.MetaType = "SN";
                                fm.CurrentFile.FileType = "F";
                                fm.CurrentFile.FileNumber = NormalizeLength(FileNumber, 16);
                            }

                            fm.CurrentFile.NameE = FileName;
                            fm.CurrentFile.NameF = FileName;

                        }
                        else if (System.IO.File.Exists(fileXmlPath))
                        {
                            //Volume
                            fm.CurrentFile.MetaType = "FD";

                            if (localpath.Contains("DocRejects"))
                            {

                                //if localpath contains text DocRejects, it's a reject

                            }

                            foldername = foldername.Replace("Volume", "v.");
                            foldername = foldername.Replace("_", "/");

                            fm.CurrentFile.FileNumber = fm.CurrentFileId.ToString();// NormalizeLength(foldername, 16);
                            fm.CurrentFile.NameE = foldername;
                            fm.CurrentFile.NameF = foldername;
                            fm.CurrentFile.FileType = "F";

                            //set parent properties
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(fileXmlPath);
                            setFilePropertiesFromXML(fm, xmlDoc, "FL", foldername);

                        }
                        else
                        {
                            //check to see if name set already; if not set defaults that should get replaced by volume child file on first pass
                            if (fm.CurrentFile.IsNameENull())
                            {
                                if (localpath.Contains("DocRejects"))
                                {
                                    foldername = foldername.Replace("Volume", "v.");
                                    foldername = foldername.Replace("_", "/");

                                    fm.CurrentFile.FileNumber = NormalizeLength(foldername, 16);
                                    fm.CurrentFile.NameE = foldername;
                                    fm.CurrentFile.NameF = foldername;
                                    fm.CurrentFile.MetaType = "FL";
                                    fm.CurrentFile.FileType = "F";
                                }
                                else
                                {
                                    fm.CurrentFile.FileNumber = NormalizeLength(foldername, 16);
                                    fm.CurrentFile.NameE = "[NameNotSet]";
                                    fm.CurrentFile.NameF = "[NameNotSet]";
                                    fm.CurrentFile.MetaType = "FL";
                                    fm.CurrentFile.FileType = "F";
                                }
                            }
                        }
                    }

                    ImportDocs(fm, localpath);

                    atLogic.BusinessProcess bp = fm.GetBP();

                    bp.AddForUpdate(fm.EFile);
                    bp.AddForUpdate(fm.GetFileXRef());
                    bp.AddForUpdate(fm.GetFileOffice());

                    bp.Update();

                    AddListItem("Created file " + localpath);
                    counter++;
                }

                GC.Collect();
            }
            if (chkInclude.Checked)
            {
                chkNewFile.Checked = true;
                foreach (string subfile in System.IO.Directory.GetDirectories(localpath))
                {
                    MakeLotusFile(subfile, fm);
                }
            }
        }

        StreamWriter ExtTW;
        lmDatasets.docDB.FileFormatDataTable ffDt;
        private void ImportPrepass(atriumManager atmng, string folderpath)
        {
            if (ffDt == null)
            {
                ffDt = atmng.GetFile().GetDocMng().DB.FileFormat;
            }

            foreach (string doc in System.IO.Directory.GetFiles(folderpath))
            {
                string ext = Path.GetExtension(doc);
                docDB.FileFormatRow fmt = ffDt.FindByFileFormat(ext);

                if (fmt==null)
                {
                    AddListItem("Extension not permitted: " + System.IO.Path.GetFileName(doc));
                    ExtTW.WriteLine(ext + ", " + doc);
                }
            }
            foreach (string subfile in System.IO.Directory.GetDirectories(folderpath))
            {
                ImportPrepass(atmng, subfile);
            }

        }

        private void CheckForEmptyLotusFolder(atriumManager atmng, string folderpath)
        {
            int countofDocs = System.IO.Directory.GetFiles(folderpath).Length;
            int countOfFolders = System.IO.Directory.GetDirectories(folderpath).Length;

            if (countofDocs == 0 && countOfFolders == 0)
            {
                //zero content in folder
                //log it
                AddListItem("Empty Folder: " + folderpath);
                ExtTW.WriteLine(folderpath);
            }
            
            foreach (string subfile in System.IO.Directory.GetDirectories(folderpath))
            {
                CheckForEmptyLotusFolder(atmng, subfile);
            }

        }

        private void ImportDocs(FileManager fm, string folderpath)
        {
            ActivityBP abp = fm.InitActivityProcess();
            List<string> listOfXmlDocs = new List<string>();
            List<string> listOfDocAttachments = new List<string>();
            
            //retrieve list of docId'ed xml files
            foreach (string doc in System.IO.Directory.GetFiles(folderpath))
            {
                if (Path.GetFileName(doc) == fileXmlFilename || Path.GetFileName(doc) == leafXmlFilename)
                    continue;

                if (Path.GetExtension(doc) == ".xml")
                {
                    //how do we ensure the xml doc is ours and not meant for import?
                    //check filename length?  safe enough?
                    //check the filename can be parsed as int?
                    //both checks?
                    string filenameOfXMLFile = Path.GetFileNameWithoutExtension(doc);
                    bool isNumeric = int.TryParse(filenameOfXMLFile, out int filedocid);

                    if (filenameOfXMLFile.Length > 7 || !isNumeric)
                    {
                        continue;
                    }

                    listOfXmlDocs.Add(doc);
                }
                    
            }

            //loop through doc metadata xml files
            foreach (string docXmlFile in listOfXmlDocs)
            {
                //load file into XmlDocument for metadata
                XmlDocument xmlDocMetadata = new XmlDocument();
                xmlDocMetadata.Load(docXmlFile);

                //check to see if there is an rtf file for it
                string folderPath = Path.GetDirectoryName(docXmlFile);
                string docId = Path.GetFileNameWithoutExtension(docXmlFile);


                string docsubject = getNodeValue(xmlDocMetadata, "Subject");
                if (docsubject.Length > 255)
                    docsubject = docsubject.Substring(0, 255);
                DateTime docDate = getDocDateValue(xmlDocMetadata);

                string rtfFile = Path.Combine(folderpath, docId + ".docx");

                if (!File.Exists(rtfFile))
                {
                    if(pathToEmptyRtfDoc=="")
                        pathToEmptyRtfDoc = rtfTemplateName;
                    //create blank rtf file so a record of the doc exists
                    rtfFile = pathToEmptyRtfDoc;
                }
                //find any related embedded objects using startsWith doc id
                listOfDocAttachments.Clear();
                foreach (string doc in System.IO.Directory.GetFiles(folderpath))
                {
                    if (Path.GetFileName(doc).StartsWith(docId + " "))
                    {
                        listOfDocAttachments.Add(doc);
                    }
                }
                CreateDocument(fm, abp, docId, rtfFile, docsubject, docDate, listOfDocAttachments);
            }

        }

        private void AddListItem(string ListItemString)
        {
            listBox1.Items.Add(ListItemString);
            listBox1.Refresh();
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private string NormalizeLength(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        private void setFilePropertiesFromXML(FileManager fm, XmlDocument efileXml, string fileMetaType, string foldername)
        {
            appDB.EFileSearchRow efs = fm.EFile.GetEfileParentRow(fm.CurrentFile);
            FileManager fmParent = AtMng.GetFile(efs.FileId);
            atriumDB.EFileRow pFile = fmParent.CurrentFile;
            if(pFile.NameE == "[NameNotSet]")
            {
                //set name properly
                string filenum = getNodeValue(efileXml, "FileNo2");

                string fileopened = getNodeValue(efileXml, "FileOpenDate");
                string fileclosed = getNodeValue(efileXml, "FileCloseDate");

                if (!string.IsNullOrEmpty(fileopened))
                {
                    DateTime fileOpenedDate = DateTime.ParseExact(fileopened, "dd/MM/yyyy hh:mm:ss tt", provider);
                    pFile.OpenedDate = fileOpenedDate;
                }
                if (!string.IsNullOrEmpty(fileclosed))
                { 
                    DateTime fileClosedDate = DateTime.ParseExact(fileclosed, "dd/MM/yyyy hh:mm:ss tt", provider);
                    pFile.ClosedDate = fileClosedDate;
                    pFile.CloseCode = "800";
                }

                pFile.StatusCode = (getNodeValue(efileXml, "Status") == "Open") ? "O" : "C";

                string fileDesc = getNodeValue(efileXml, "FileDescription");

                if (fileDesc.Length > 0)
                    pFile.DescriptionE = fileDesc;

                if (filenum.IndexOf(" ") == -1)
                    pFile.FileNumber = filenum;
                else
                    pFile.FileNumber = filenum.Substring(0, filenum.IndexOf(" "));

                pFile.NameE = getNodeValue(efileXml, "Subject");
                pFile.NameF = pFile.NameE;
                pFile.FileType = "F";

                if (!string.IsNullOrEmpty(fileMetaType))
                    pFile.MetaType = fileMetaType;

                //fileAKA
                string FileNo = getNodeValue(efileXml, "FileNo");
                if (!string.IsNullOrEmpty(FileNo) || FileNo != "-")
                {
                    //create new AKA record using FileNo

                }
                atLogic.BusinessProcess bp = fmParent.GetBP();

                bp.AddForUpdate(fmParent.EFile);
                bp.AddForUpdate(fmParent.GetFileXRef());
                bp.AddForUpdate(fmParent.GetFileOffice());

                bp.Update();
            }            

            //TODO: Identify other properties and decide how to handle ones that don't have a home (e.g. new entity? store in xml file like extract from lotus?)
        }

        private DateTime parseLotusDate(string sDate)
        {
                return DateTime.ParseExact(sDate, "dd/MM/yyyy h:mm:ss tt", provider);
                //return DateTime.ParseExact(sDate, "yyyy-MM-dd hh:mm:ss.fff", provider);
        }

        private DateTime getDocDateValue(XmlDocument efileXml)
        {
            //if DateCorr exists, use it first
            //if DateRecd exists, use it next
            //if date not valid (before 1950? and after 2018?)
            //otherwise return null

            DateTime returnDate;

            XmlNodeList nodeDateCorr = efileXml.GetElementsByTagName("DateCorr");
            XmlNodeList nodeDateRecd = efileXml.GetElementsByTagName("DateRecd");
            XmlNodeList nodeDateDocument = efileXml.GetElementsByTagName("DATEDOCUMENT");

            if (nodeDateCorr.Count == 1 && nodeDateCorr[0].InnerText.Length > 0)
            {
                returnDate = parseLotusDate(nodeDateCorr[0].InnerText);
            }
            else if (nodeDateRecd.Count == 1 && nodeDateRecd[0].InnerText.Length > 0)
            {
                returnDate = parseLotusDate(nodeDateRecd[0].InnerText);
            }
            else if (nodeDateDocument.Count == 1 && nodeDateDocument[0].InnerText.Length > 0)
            {
                returnDate = parseLotusDate(nodeDateDocument[0].InnerText);
            }
            else
            {
                //default date if can't be found
                returnDate = new DateTime(2000, 1, 1);
                string nodeDocId = efileXml.GetElementsByTagName("DocID")[0].InnerText;
                string nodeFileClass = "FileClassNotFound";
                if (efileXml.GetElementsByTagName("FileClass")[0] != null)
                {
                    nodeFileClass = efileXml.GetElementsByTagName("FileClass")[0].InnerText;
                }
                string nodeFileNo2 = efileXml.GetElementsByTagName("FileNo2")[0].InnerText;
                DocsWithModifiedDocDate.WriteLine("No Date, " + nodeDocId + ", " + nodeFileClass + ", " + nodeFileNo2);
            }

            if (!isDateValid(returnDate))
            {
                DateTime BadDate = returnDate;
                returnDate = new DateTime(2019, 1, 1);
                string nodeDocId = efileXml.GetElementsByTagName("DocID")[0].InnerText;
                string nodeFileClass = efileXml.GetElementsByTagName("FileClass")[0].InnerText;
                string nodeFileNo2 = efileXml.GetElementsByTagName("FileNo2")[0].InnerText;
                DocsWithModifiedDocDate.WriteLine("Invalid Date: " + BadDate.ToString() + ", " + nodeDocId + ", " + nodeFileClass + ", " + nodeFileNo2);
            }

            return returnDate;
        }

        private bool isDateValid(DateTime docDate)
        {
            if (docDate.Year <= 1950)
                return false;
            if (docDate.Year > 2018)
                return false;

            return true;
        }

        private string getNodeValue(XmlDocument efileXml, string nodeName)
        {
            XmlNodeList nodeList = efileXml.GetElementsByTagName(nodeName);
            if (nodeList.Count == 1)
            {
                return nodeList[0].InnerText;
            }
            else
                return "";
        }

        atLogic.ObjectBE obe;
        private void AddExtensionToFileFormatTable(string ext, docDB.FileFormatDataTable ffTable)
        {
            if (obe == null)
            {
                obe = AtMng.GetCodeTableBE("FileFormat");
                obe.Load();
            }

            CodesDB.FileFormatRow ffRow = (CodesDB.FileFormatRow)obe.Add(null);
            ffRow.AllowEdit = false;
            ffRow.AllowPreview = false;
            ffRow.AllowSearch = true;
            ffRow.AllowUpload = true;
            ffRow.FileDescEng = "Lotus Notes Import";
            ffRow.FileDescFre = "Lotus Notes Import";
            ffRow.FileFormat = ext;
            ffRow.IsBinary = false;

            ffRow.EndEdit();
            atLogic.BusinessProcess bp = AtMng.GetBP();
            bp.AddForUpdate(obe);
            bp.Update();

            ffTable.ImportRow(ffRow);
        }

        private void AddExtensionToDocWithoutExt(string documentPath)
        {
            //.LONOEXT
            File.Move(documentPath, Path.ChangeExtension(documentPath, ".LONOEXT"));
        }

        private void CreateDocument(FileManager fm, ActivityBP abp, string lotusDocId, string documentPath, string docSubject, DateTime docDate, List<string> listOfDocAttachments)
        {
            string ext = System.IO.Path.GetExtension(documentPath);

            docDB.FileFormatRow fmt = fm.GetDocMng().DB.FileFormat.FindByFileFormat(ext);

            if (fmt != null && fmt.AllowUpload)
            {
                iCount++;
                ACEngine ace = abp.Add(docDate, acsr, null, false, null);
                atriumDB.ActivityRow newAc = ace.NewActivity;
                ace.DocumentDefaults(true);

                docDB.DocumentRow dr = (docDB.DocumentRow)ace.relTables["Document0"][0].Row;

                DocumentBE.LoadFileX(dr, documentPath);

                dr.efSubject = docSubject;
                dr.efDate = docDate;
                dr.Source = "Lotus: " + lotusDocId;
                dr.IsDraft = false;
                AddListItem("Document added: " + System.IO.Path.GetFileName(documentPath));

                if (listOfDocAttachments.Count > 0)
                {
                    DocManager myDM = fm.GetDocMng();
                    atriumBE.AttachmentBE d = myDM.GetAttachment();

                    foreach (string attachment in listOfDocAttachments)
                    {
                        string localAttach = attachment;
                        string attExt = Path.GetExtension(localAttach);
                        if (attExt.Length > 10)
                        { 
                            attExt = attExt.Substring(0, 10);
                            //modify extension on disk
                            File.Move(attachment, Path.ChangeExtension(attachment, attExt));
                            localAttach = Path.Combine(Path.GetDirectoryName(attachment), Path.GetFileNameWithoutExtension(attachment) + attExt);
                        }
                        
                        //if extension is empty, modify doc extension
                        //.LONOEXT
                        if (string.IsNullOrEmpty(attExt))
                        {
                            AddExtensionToDocWithoutExt(attachment);
                            attExt = ".LONOEXT";
                            localAttach = localAttach + attExt;
                        }

                        docDB.FileFormatRow attFmt = fm.GetDocMng().DB.FileFormat.FindByFileFormat(attExt);

                        //if extension not allowed, add it
                        if (attFmt == null)
                        {
                            AddExtensionToFileFormatTable(attExt, fm.GetDocMng().DB.FileFormat);
                            attFmt = fm.GetDocMng().DB.FileFormat.FindByFileFormat(attExt);
                        }

                        if (attFmt != null && attFmt.AllowUpload)
                        {
                            docDB.DocumentRow newDoc = (docDB.DocumentRow)myDM.GetDocument().Add(myDM.FM.CurrentFile, localAttach);

                            int indexOfSpaceInAttachment = localAttach.IndexOf(' ')-1;

                            newDoc.efSubject = Path.GetFileNameWithoutExtension(localAttach).Substring(indexOfSpaceInAttachment).TrimStart(' '); //atts start with 6 digit lotus docNumber + space; let's remove that before import
                            newDoc.efType = "ATT";
                            newDoc.IsDraft = false;
                            newDoc.efDate = newDoc.DocContentRow.ModDate;
                            newDoc.Source = "Lotus: " + lotusDocId;

                            lmDatasets.docDB.AttachmentRow att = (lmDatasets.docDB.AttachmentRow)d.Add(dr);
                            att.AttachmentId = newDoc.DocId;
                            att.Version = newDoc.CurrentVersion;
                            AddListItem("Attachment added: " + System.IO.Path.GetFileName(localAttach));
                        }
                        else
                        {
                            AddListItem("Attachment - Extension not permitted: " + System.IO.Path.GetFileName(localAttach));
                            ExtTW.WriteLine(attExt + ", " + localAttach);
                        }
                    }
                }

                ace.Save(true, false);
                abp.CurrentACE = null;
            }
            else
            {
                AddListItem("Extension not permitted: " + System.IO.Path.GetFileName(documentPath));
                ExtTW.WriteLine(ext + ", " + documentPath);
            }
        }

        private void MakeFile(string file, FileManager fmRoot)
        {
            FileManager fm;
            fm = fmRoot;

            if (chkNewFile.Checked)
            {
                iFiles++;
                fm = AtMng.CreateFile(fmRoot);

                if (!fmRoot.CurrentFile.FileMetaTypeRow.SubFileAutoNumber)
                {
                    fm.CurrentFile.FileNumber = "999";
                }
                fm.CurrentFile.NameE = System.IO.Path.GetFileName(file);
                fm.CurrentFile.NameF = System.IO.Path.GetFileName(file);
                fm.CurrentFile.FileType = ucMultiDropDown2.SelectedValue.ToString();

                atLogic.BusinessProcess bp = fm.GetBP();

                bp.AddForUpdate(fm.EFile);
                bp.AddForUpdate(fm.GetFileXRef());
                bp.AddForUpdate(fm.GetFileOffice());

                bp.Update();

                AddListItem("Created file " + file);
            }

            ActivityBP abp = fm.InitActivityProcess();

            foreach (string doc in System.IO.Directory.GetFiles(file))
            {
                string ext = System.IO.Path.GetExtension(doc);
                docDB.FileFormatRow fmt=fm.GetDocMng().DB.FileFormat.FindByFileFormat(ext);
                if (fmt != null && fmt.AllowUpload)
                {
                    iCount++;
                    ACEngine ace = abp.Add(DateTime.Today, acsr, null, false, null);
                    atriumDB.ActivityRow newAc = ace.NewActivity;
                    ace.DocumentDefaults(true);
                    
                    //ace.DoStep(0);

                    //get the document from related fields
                    docDB.DocumentRow dr = (docDB.DocumentRow)ace.relTables["Document0"][0].Row;

                    DocumentBE.LoadFileX(dr, doc);

                    AddListItem("Added document: " + System.IO.Path.GetFileName(doc));
                    ace.Save(true,false);
                    abp.CurrentACE = null;
                }
                else
                {
                    AddListItem("ILLEGAL EXTENSION: " + System.IO.Path.GetFileName(doc));
                }

            }
           

            if (chkInclude.Checked)
            {
                chkNewFile.Checked = true;
                foreach (string subfile in System.IO.Directory.GetDirectories(file))
                {
                    MakeFile(subfile, fm);
                }
            }

        }

        private void SetDefaults()
        {
            ucMultiDropDown1.SelectedValue =AtMng.GetSetting(AppIntSetting.ImportDocAcId);
            ucMultiDropDown2.SelectedValue = "F";
            ucDest.FileId = 0;
        }

        private void ebImportFile_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                if (folderBrowserDialog1.SelectedPath == "")
                    return;

                ebImportFile.Text= folderBrowserDialog1.SelectedPath;
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private bool okToRun()
        {
            bool OkToRun = true;
            if (ebImportFile.Text == "")
            {
                MessageBox.Show(NoFolder);
                OkToRun = false;
            }
            if (ucDest.FileId == null)
            {
                MessageBox.Show(NoAtriumPath);
                OkToRun = false;
            }
            if (ucMultiDropDown1.SelectedValue == null)
            {
                MessageBox.Show(NoActivity);
                OkToRun = false;
            }

            if (ucMultiDropDown2.SelectedValue == null)
            {
                MessageBox.Show(NoFileType);
                OkToRun = false;
            }
            return OkToRun;
        }

        StreamWriter DocsWithModifiedDocDate;
        private void runImport(ImportSource sourceData)
        {
            iCount = 0;
            iFiles = 0;
            DateTime start = DateTime.Now;


            FileManager fmRoot;
            if (ebParentFileID.Text.Length>0)
                fmRoot = AtMng.GetFile(Convert.ToInt32(ebParentFileID.Text));
            else
                fmRoot = AtMng.GetFile((int)ucDest.FileId);

            acsr = AtMng.acMng.DB.ACSeries.FindByACSeriesId((int)ucMultiDropDown1.SelectedValue);

            switch (sourceData)
            {
                case ImportSource.LocalPath:
                    MakeFile(ebImportFile.Text, fmRoot);
                    break;
                case ImportSource.LotusPrePass:
                    string ExtFilePath = Path.Combine("C:\\AtriumFileExtensionRejects", "FileExtRejects.txt");
                    ExtTW = new StreamWriter(ExtFilePath);
                    ImportPrepass(AtMng, ebImportFile.Text);
                    ExtTW.Close();
                    break;
                case ImportSource.LotusEmptyFolderFinder:
                    string ExtFilePath2 = Path.Combine("C:\\AtriumRejects", "emptyDiskFoldersFromLotusExtract.txt");
                    ExtTW = new StreamWriter(ExtFilePath2);
                    CheckForEmptyLotusFolder(AtMng, ebImportFile.Text);
                    ExtTW.Close();
                    break;
                case ImportSource.LotusNotes:
                    DateTime dt = DateTime.Now;
                    string sDt = dt.ToString("yyyy-MM-dd hh_mm");
                    string PathToListOfDocsWithModifiedDocDate = "C:\\AtriumFileExtensionRejects\\ListOfDocsWithModifiedDocDate" + sDt + ".txt";
                    DocsWithModifiedDocDate = new StreamWriter(PathToListOfDocsWithModifiedDocDate);
                    StartPath = ebStartAt.Text;
                    if (StartPath.Length > 0)
                        isOkToContinue = false;
                    MakeLotusFile(ebImportFile.Text, fmRoot);
                    DocsWithModifiedDocDate.Close();
                    break;
                case ImportSource.InfoBank:
                    MessageBox.Show("InfoBank import not implemented");
                    break;
            }
            AddListItem(iFiles.ToString() + " files created in Atrium");
            AddListItem(iCount.ToString() + " documents created in Atrium");
            TimeSpan ts = DateTime.Now.Subtract(start);
            AddListItem(ts.ToString() + " elapsed time");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!okToRun())
                    return;

                runImport(ImportSource.LocalPath);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }


        private void btnImportLotus_Click(object sender, EventArgs e)
        {
            try
            {
                if (!okToRun())
                    return;

                runImport(ImportSource.LotusNotes);

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
                if (ebImportFile.Text == "")
                {
                    MessageBox.Show(NoFolder);
                    return;
                }

                runImport(ImportSource.LotusPrePass);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }

        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ebImportFile.Text == "")
                {
                    MessageBox.Show(NoFolder);
                    return;
                }

                runImport(ImportSource.LotusEmptyFolderFinder);
            }
            catch (Exception x)
            {
                UIHelper.HandleUIException(x);
            }
        }

        private void fLoad_Load(object sender, EventArgs e)
        {
            try
            {
                SetDefaults();
            }
            catch (Exception x)
            {
                
                UIHelper.HandleUIException(x);
            }
        }
    }
}