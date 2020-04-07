using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.IO;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentBE : atLogic.ObjectBE
    {
        DocManager myA;
        docDB.DocumentDataTable myDocumentDT;
        public bool AutoSubject = false;

        private global::System.Object missing = global::System.Type.Missing;

        internal DocumentBE(DocManager pBEMng)
            : base(pBEMng, pBEMng.DB.Document)
        {
            myA = pBEMng;
            myDocumentDT = (docDB.DocumentDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetDocument();
        }
        public atriumDAL.DocumentDAL myDAL
        {
            get
            {
                return (atriumDAL.DocumentDAL)myODAL;
            }
        }

        public override string FriendlyName()
        {
            return "Document";
        }
        public docDB.DocumentRow Load(int DocId)
        {

            //Fill(myDAL.Load(DocId));
            //now a deep load
            DataSet ds = new docDB();
            if (myA.AtMng.AppMan.UseService)
                ds = BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().LoadDocbyDocId(DocId, myA.AtMng.AppMan.AtriumXCon), ds);
            else
            {
                try
                {
                    ds = BEManager.DecompressDataSet(myDAL.LoadAll(DocId), ds);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    ds = BEManager.DecompressDataSet(myDAL.LoadAll(DocId), ds);
                }
            }

            LoadDS(ds);


            return myDocumentDT.FindByDocId(DocId);
        }

        public void FinalizeAllDrafts(atriumDB.EFileRow er)
        {
            foreach (docDB.DocumentRow dr in myDocumentDT.Select("isDraft=1 and FileId=" + er.FileId.ToString()))
            {
                dr.IsDraft = false;
            }
        }
        public int HitCount(string fullText, bool opinionsOnly, bool subjectSearch)
        {
            int hits = 0;

            if (subjectSearch)
            {
                hits = (int)myA.AtMng.AppMan.ExecuteScalar("DocumentHitCountSubject", fullText, opinionsOnly);
                return hits;
            }
            else
            {
                hits = (int)myA.AtMng.AppMan.ExecuteScalar("DocumentHitCount", fullText, opinionsOnly);
                return hits;
            }
        }
        public void Search(string fullText, bool opinionsOnly)
        {
            try
            {
                //JLL-DAL
                DataSet ds;
                if (myA.AtMng.AppMan.UseService)
                {
                    ds = BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().SearchQuick(fullText, opinionsOnly, myA.AtMng.AppMan.AtriumXCon), new docDB());
                }
                else
                {
                    try
                    {
                        ds = BEManager.DecompressDataSet(myDAL.SearchQuick(fullText, opinionsOnly), new docDB());
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        ds = BEManager.DecompressDataSet(myDAL.SearchQuick(fullText, opinionsOnly), new docDB());
                    }
                }

                Fill(ds.Tables[0]);
                myA.GetRecipient().Fill(ds.Tables[1]);
            }
            catch (System.Data.SqlClient.SqlException x)
            {

                throw new AtriumException(Properties.Resources.DocSearchError, x);
            }

        }
        public void Search(WhereClause wc, bool includeXrefs)
        {
            try
            {
                DataSet ds;
                //JLL-DAL
                if (myA.AtMng.AppMan.UseService)
                {
                    ds = BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().Search(wc.Filter(), includeXrefs, myA.AtMng.AppMan.AtriumXCon), new docDB());
                }
                else
                {
                    try
                    {
                        ds = BEManager.DecompressDataSet(myDAL.Search(wc.Filter(), includeXrefs), new docDB());
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        ds = BEManager.DecompressDataSet(myDAL.Search(wc.Filter(), includeXrefs), new docDB());
                    }
                }
                Fill(ds.Tables["Document"]);
                myA.GetRecipient().Fill(ds.Tables["Recipient"]);

                //Fill(myDAL.Search(wc.Filter(), includeXrefs));
                //myA.GetRecipient().Search(wc, includeXrefs);
            }
            catch (System.Data.SqlClient.SqlException x)
            {

                throw new AtriumException(Properties.Resources.DocSearchError, x);
            }
        }

        public override string PromptColumnName()
        {
            return "efSubject,efDate";
        }


        public void LoadByFileId(int fileId)
        {


            DataSet ds = new docDB();
            if (myA.AtMng.AppMan.UseService)
                ds = BEManager.DecompressDataSet(myA.AtMng.AppMan.AtriumX().LoadDoc(fileId, myA.AtMng.AppMan.AtriumXCon), ds);
            else
            {
                try
                {
                    ds = BEManager.DecompressDataSet(myDAL.LoadAllFile(fileId), ds);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    ds = BEManager.DecompressDataSet(myDAL.LoadAllFile(fileId), ds);
                }
            }
            LoadDS(ds);


        }

        private void LoadDS(DataSet ds)
        {
            Fill(ds.Tables["Document"]);
            myA.GetAttachment().Fill(ds.Tables["Attachment"]);
            myA.GetRecipient().Fill(ds.Tables["Recipient"]);
            ds.Clear();
            ds.Dispose();
            SetLocalDates();
        }

        public void SetLocalDates()
        {
            myA.isMerging = true;
            
            foreach (docDB.DocumentRow dr in myDocumentDT)
            {
                bool accept = false;
                if (dr.RowState == DataRowState.Unchanged)
                    accept = true;
                if(!dr.IsReceivedTimeNull())
                    dr.ReceivedLocal = dr.ReceivedTime.ToLocalTime();
                if(!dr.IsSentTimeNull())
                    dr.SentLocal = dr.SentTime.ToLocalTime();
                if(accept)
                    dr.AcceptChanges();
            }

            myA.isMerging = false;

        }


        public override bool CanAdd(DataRow parentRow)
        {
            int fileId;
            if (parentRow.GetType() == typeof(atriumDB.EFileRow))
            {
                atriumDB.EFileRow efr = (atriumDB.EFileRow)parentRow;
                fileId = efr.FileId;
                if (!efr.FileMetaTypeRow.AllowDocs)
                    return false;
            }
            else if (parentRow.GetType() == typeof(atriumDB.ActivityRow))
            {
                atriumDB.ActivityRow ar = (atriumDB.ActivityRow)parentRow;
                fileId = ar.FileId;
                if (!ar.EFileRow.FileMetaTypeRow.AllowDocs)
                    return false;
            }
            else
                return false;

            if (parentRow.RowState == DataRowState.Added)
                return true;

            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(fileId, atSecurity.SecurityManager.Features.Document) > atSecurity.SecurityManager.ExPermissions.No;

        }
        public override DataRow Add(DataRow parentRow)
        {

            if (!CanAdd(parentRow))
            {
                throw new AtriumException(Properties.Resources.DocumentFileDoesNotAllowDocuments);
            }
            docDB.DocumentRow dr = (docDB.DocumentRow)base.Add(parentRow);
            dr.FileId = (int)parentRow["FileId"];
            //if(parentRow.Table.Columns.Contains("ActivityId"))
            //    dr.ActivityId =(int) parentRow["ActivityId"];

            return dr;
        }

        public DataRow Add(DataRow parentRow, string fileName)
        {
            if (!CanAdd(parentRow))
            {
                throw new AtriumException(Properties.Resources.DocumentFileDoesNotAllowDocuments);
            }

            docDB.DocumentRow newDoc = (docDB.DocumentRow)this.Add(parentRow);
            try
            {
                LoadFile(newDoc, fileName);
                return newDoc;
            }
            catch (Exception x)
            {
                newDoc.DocContentRow.Delete();
                newDoc.Delete();
                throw x;
            }
        }

        public docDB.DocumentRow MakeCopy(docDB.DocumentRow drIn, atriumDB.EFileRow inFile, bool draft)
        {
            //check to see if copy already exists on file
            if (myA.DB.Document.Select("DocRefId=" + drIn.DocRefId).Length > 0)
                throw new AtriumException("A copy of this document already exists on the target file.");

            //docDB.DocContentRow dcrIn;
            //if (drIn.DocContentRow == null)
            //    dcrIn = myA.GetDocContent().Load(drIn.DocRefId, drIn.CurrentVersion);
            //else
            //    dcrIn = drIn.DocContentRow;

            docDB.DocumentRow drOut = (docDB.DocumentRow)Add(inFile);
            int docid = drOut.DocId;
            myA.isMerging = true;
            ACManager.ImportRow(drOut, drIn);
            drOut.DocId = docid;
            drOut.IsDraft = draft;
            //  drOut.efType = "OTH";
            drOut.SetCheckedOutByNull();
            drOut.SetCheckedOutDateNull();
            drOut.SetCheckedOutPathNull();
            drOut.FileId = inFile.FileId;
            //if (!drOut.IsLanguageCodeNull() && drOut.LanguageCode=="F")
            //    drOut.efSubject = DocumentBE.VerifySubjectLength("Copie de " + drOut.efSubject);
            //else
            //    drOut.efSubject = DocumentBE.VerifySubjectLength("Copy of " + drOut.efSubject);
            myA.isMerging = false;


            if (drOut.isElectronic)
            {
                //this is no longer needed as we can rely on the document versioning of the content to provde the copy

                //docDB.DocContentRow dcr = (docDB.DocContentRow)myA.GetDocContent().Add(drOut);
                //dcr.Contents = dcrIn.Contents;
                //dcr.Ext = dcrIn.Ext;
                //dcr.Size = dcrIn.Size;
                //      dcr.Version = "C" + drIn.DocId;
                // 2013-06-12 JLL: update to use isDraft only
                //dcr.ReadOnly = !draft;
            }

            foreach (docDB.RecipientRow r in drIn.GetRecipientRows())
            {
                myA.GetRecipient().AddRecipToMessage(r, drOut, (RecipType)Convert.ToInt32(r.Type));
            }

            //foreach (docDB.AttachmentRow atr in drIn.GetAttachmentRowsByDocument_Attachment())
            //{
            //    docDB.AttachmentRow newa=(docDB.AttachmentRow) myA.GetAttachment().Add(drOut);
            //    newa.ItemArray = atr.ItemArray;
            //    newa.MsgId = drOut.DocId;
            //    newa.Id= myA.AtMng.DALMngr.PKIDGet("Attachment", 1);
            //}

            drIn.AcceptChanges();
            return drOut;
        }
        public void LoadFile(docDB.DocumentRow newDoc, string f)
        {
            if (newDoc.DocContentRow == null)
                myA.GetDocContent().Add(newDoc);

            int intMaxFileSize;
            FileInfo fi = new FileInfo(f);
            intMaxFileSize = myA.AtMng.GetSetting(AppIntSetting.MaxFileSize);
            if ((int)fi.Length > intMaxFileSize * 1024 * 1024)
                throw new AtriumException(Properties.Resources.FileTooBig, intMaxFileSize.ToString());


            DocumentBE.LoadFileX(newDoc, f);


        }

        public static void LoadFileX(docDB.DocumentRow newDoc, string f)
        {
            //newDoc.Name = Path.GetFileName(f);

            docDB.DocContentRow newContent = newDoc.DocContentRow; ;
            newContent.Ext = Path.GetExtension(f);
            if (newContent.FileFormatRow == null || !newContent.FileFormatRow.AllowUpload)
            {
                // newDoc.RejectChanges();
                // newContent.RejectChanges();
                newDoc.SetColumnError("efSubject", String.Format(Properties.Resources.YouCanTAddThisTypeOfDocumentToLawMate, Path.GetExtension(f)));
                newContent.SetColumnError("Contents", String.Format(Properties.Resources.YouCanTAddThisTypeOfDocumentToLawMate, Path.GetExtension(f)));
                throw new AtriumException(Properties.Resources.YouCanTAddThisTypeOfDocumentToLawMate, Path.GetExtension(f));
            }
            else
            {
                newDoc.SetColumnError("efSubject", "");
                newContent.SetColumnError("Contents", "");

            }

            newContent.Contents = File.ReadAllBytes(f);

            FileInfo fi = new FileInfo(f);

            newContent.CreateDate = DocumentBE.FixFileDate(fi.CreationTime);
            newContent.ModDate = DocumentBE.FixFileDate(fi.LastWriteTime);
            newContent.Size = (int)fi.Length;

            if (newDoc.IsefDateNull())
                newDoc.efDate = DateTime.Today;

            if (newDoc.IsefSubjectNull() || newDoc.efSubject == "")
                newDoc.efSubject = Path.GetFileNameWithoutExtension(f);

            newDoc.EndEdit();

        }

        public static DateTime FixFileDate(DateTime fd)
        {
            DateTime min = new DateTime(1900, 1, 1);
            DateTime max = new DateTime(2150, 1, 1);
            if (fd == null)
                return DateTime.Now;
            else if (fd.CompareTo(min) < 0)
                return min;
            else if (fd.CompareTo(max) > 0)
                return max;
            else
                return fd;

        }
        protected override void AfterAdd(DataRow dr)
        {
            docDB.DocumentRow doc = (docDB.DocumentRow)dr;
            doc.DocId = myA.AtMng.PKIDGet("EFile", 10);
            //doc.FileId = myA.FM.CurrentFile.FileId;

            //doc.efSubject = "New document";
            //doc.Name = "New Document";
            doc.isElectronic = true;
            doc.isPaper = false;
            doc.isLawmail = false;
            doc.IsDraft = true;
            doc.PV = false;
            doc.PopDocViewer = false;
            doc.MailImportance = 0;
            doc.Opinion = false;
            if (myA.FM.IsVirtualFM)
                doc.Security = "NONE";
            else
                doc.Security = myA.FM.CurrentFile.Security;

            //doc.FiledBy = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            //doc.CreateDate = DateTime.Now;
            doc.Author = myA.AtMng.WorkingAsOfficer.UserName;
            doc.OfficerId = myA.AtMng.WorkingAsOfficer.OfficerId;
            doc.efDate = DateTime.Today;
            //doc.Ext = ".txt";
            doc.FiledBy = myA.AtMng.OfficerLoggedOn.UserName;
            //doc.ModDate = doc.CreateDate;
            //doc.Size = 0;
            doc.Source = "LM";
            doc.efType = "MEM";
            doc.CommMode = "LME";

            string langCd = myA.FM.CurrentFile.LanguageCode;// myA.FM.AppMan.Language.Substring(0, 1);

            //find appellant
            if (myA.FM.GetSSTMng() != null)
            {
                foreach (SST.FilePartyRow fpr in myA.FM.GetSSTMng().DB.FileParty)
                {
                    if (fpr.IsAppellant)
                    {
                        atriumDB.FileContactRow fcr = myA.FM.DB.FileContact.FindByFileContactid(fpr.FileContactId);
                        if (!fcr.IsLanguageCodeNull())
                        {
                            langCd = fcr.LanguageCode;
                            break;
                        }
                    }
                }
            }


            doc.LanguageCode = langCd;
            doc.CurrentVersion = "1";
            doc.DocRefId = doc.DocId;
            if (!myA.FM.CurrentFile.IsDim1IdNull())
                doc.SourceDivision = myA.FM.CurrentFile.Dim1Id;


        }

        protected override void AfterUpdate(DataRow dr)
        {
            docDB.DocumentRow doc = (docDB.DocumentRow)dr;

            //clear autosave for this doc
            //ClearAutoSave(doc);
        }

        public static string VerifySubjectLength(string subject)
        {
            if (subject.Length > 255)
                return subject.Substring(0, 255);
            else
                return subject;
        }

        public static string StripInvalidVarChar(string file)
        {
            foreach (Char c in System.IO.Path.GetInvalidFileNameChars())
            {
                file = file.Replace(c, '_');
            }
            return file;
        }
        protected override void AfterChange(DataColumn dc, DataRow r)
        {
            docDB.DocumentRow dr = (docDB.DocumentRow)r;

            switch (dc.ColumnName)
            {
                case "SentTime":
                    if(!dr.IsSentTimeNull())
                    {
                        dr.SentLocal = dr.SentTime.ToLocalTime();
                    }
                    break;
                case "ReceivedTime":
                    if(!dr.IsReceivedTimeNull())
                    {
                        dr.ReceivedLocal = dr.ReceivedTime.ToLocalTime();
                    }
                    break;
                case "MailImportance":
                    atriumDB.ActivityRow[] ar = (atriumDB.ActivityRow[])myA.FM.DB.Activity.Select("Docid=" + dr.DocId.ToString(), "", DataViewRowState.Added);
                    if (ar.Length == 1)
                    {
                        ar[0].BFPriority = (short)dr.MailImportance;
                    }
                    break;

                case "efSubject":
                    //if (dr.DocContentRow == null)
                    //    dr.Name = dr.efSubject;
                    //else
                    //{
                    //    if (StripInvalidVarChar(dr.efSubject).Length + dr.DocContentRow.Ext.Length > 255)
                    //    {
                    //        int maxSubject = 255 - dr.DocContentRow.Ext.Length;
                    //        dr.Name = StripInvalidVarChar(dr.efSubject).Substring(0,maxSubject) + dr.DocContentRow.Ext;
                    //    }
                    //    else
                    //        dr.Name = StripInvalidVarChar(dr.efSubject) + dr.DocContentRow.Ext;
                    //}
                    //dr.EndEdit();
                    break;
                case "Name":
                    //dr.Name = StripInvalidVarChar(dr.Name);
                    break;
                case "TemplateId":
                case "templateCode":
                    if (AutoSubject || dr.IsefSubjectNull())
                    {
                        if (!dr.IstemplateCodeNull())// && dr.IsefSubjectNull())
                        {
                            appDB.TemplateRow tr = myA.AtMng.GetTemplate().GetTemplateFromBaseName(myA.FM, dr.templateCode);
                            if (dr.templateCode.EndsWith("-F"))
                                dr.LanguageCode = "F";
                            else if (dr.templateCode.EndsWith("-E"))
                                dr.LanguageCode = "E";
                            else if (dr.templateCode.EndsWith("-B"))
                                dr.LanguageCode = "E";

                            if (dr.LanguageCode == "F")
                                dr.efSubject = tr.LetterDescFre;
                            else
                                dr.efSubject = tr.LetterDescEng;
                            dr.EndEdit();
                        }
                        else
                        {
                            dr.SetefSubjectNull();
                            dr.EndEdit();
                        }
                    }
                    break;
            }
        }
        public string GetMessageHeader(docDB.DocumentRow msg, bool forPrint)
        {
            string head = "";
            string from = "", to = "", cc = "", tc = "", ccc = "";
            if (msg.IsSourceNull() || msg.Source != "Outlook atriumFilerxxx")
            {
                //if (msg.GetRecipientRows().Length == 0)
                //    myA.GetRecipient().LoadByDocId(msg.DocId);
                foreach (docDB.RecipientRow r in msg.GetRecipientRows())
                {
                    switch (r.Type)
                    {
                        case "0":
                            from = String.Format("{0} [mailto:{1}]", r.Name, r.Address);
                            break;
                        case "1":
                            to += tc + r.Name;
                            tc = ", ";
                            break;
                        case "2":
                            cc += ccc + r.Name;
                            ccc = " ,";
                            break;

                    }
                }

                switch (msg.DocContentRow.Ext.ToLower())
                {

                    case ".html":
                    case ".htm":
                    //head += "<hr><br><b>"+Properties.Resources.From+"</b> " + from + "<br>";
                    //if (!msg.IsSentTimeNull())
                    //    head += "<b>"+Properties.Resources.Sent+"</b> " + msg.SentTime.ToString("dddd, MMMM d, yyyy hh:mm tt") + "<br>";
                    //else
                    //    head += "<b>"+Properties.Resources.Sent+"</b> " + msg.DocContentRow.CreateDate.ToString("dddd, MMMM d, yyyy hh:mm tt") + "<br>";

                    //head += "<b>"+Properties.Resources.To+"</b> " + to + "<br>";
                    //if(cc!="")
                    //    head += "<b>" + Properties.Resources.CC + "</b> " + cc + "<br>";
                    //head += "<b>" + Properties.Resources.Subject + "</b> " + msg.efSubject + "<br><br>";
                    //break;
                    case ".doc":
                    case ".docx":
                    case ".rtf":
                    case ".txt":
                        if (!forPrint)
                            head += Properties.Resources.OriginalMessage;
                        head += Properties.Resources.From + from + "\n\r";
                        if (!msg.IsReceivedTimeNull())
                            head += Properties.Resources.Sent + msg.ReceivedTime.ToLocalTime().ToString("dddd, MMMM d, yyyy hh:mm tt") + "\n\r";
                        else if (!msg.IsSentTimeNull())
                            head += Properties.Resources.Sent + msg.SentTime.ToLocalTime().ToString("dddd, MMMM d, yyyy hh:mm tt") + "\n\r";
                        else
                            head += Properties.Resources.Sent + msg.DocContentRow.CreateDate.ToString("dddd, MMMM d, yyyy hh:mm tt") + "\n\r";

                        head += Properties.Resources.To + to + "\n\r";
                        if (cc != "")
                            head += Properties.Resources.CC + cc + "\n\r";
                        head += Properties.Resources.Subject + msg.efSubject + "\n\r";
                        break;

                }
            }
            return head;

        }
        public docDB.DocContentRow Print(docDB.DocumentRow msg2Print)
        {
            return Print(msg2Print, msg2Print.CurrentVersion);
        }
        public docDB.DocContentRow Print(docDB.DocumentRow msg2Print, string version)
        {
            if (!msg2Print.isElectronic)
                return null;

            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            tc.CreateControl();
            tc.Text = "";

            docDB.DocContentRow printout;
            if (msg2Print.CurrentVersion == version || version == null)
            {
                // use loaded copy
                if (msg2Print.DocContentRow == null)
                    myA.GetDocContent().Load(msg2Print.DocRefId, version);

                printout = msg2Print.DocContentRow;
            }
            else
            {
                //use virtual fm copy
                FileManager virtFM = myA.AtMng.GetFile();
                DocManager virtDM = virtFM.GetDocMng();
                virtDM.GetDocument().Load(msg2Print.DocId);
                printout = virtDM.GetDocContent().Load(msg2Print.DocRefId, version);
            }

            if (msg2Print.isLawmail) //.GetRecipientRows().Length > 1
            {
                tc.Select(tc.Text.Length, 0);
                tc.Selection.Text = GetMessageHeader(msg2Print, true) + Environment.NewLine + Environment.NewLine;

                docDB.DocContentRow tempDC = printout;
                docDB db = new docDB();
                docDB.DocumentRow printmeta = db.Document.NewDocumentRow();
                db.Document.AddDocumentRow(printmeta);
                ACManager.ImportRow(printmeta, msg2Print);
                printout = db.DocContent.NewDocContentRow();
                db.DocContent.AddDocContentRow(printout);
                printout.Ext = msg2Print.DocContentRow.Ext;
                printout.DocId = msg2Print.DocRefId;

                // 2013-06-12 JLL: update to use isDraft only
                //printout.ReadOnly = true;

                switch (tempDC.Ext.Trim().ToLower())
                {
                    case ".pdf":
                        tc.Append(tempDC.Contents, TXTextControl.BinaryStreamType.AdobePDF, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".docx":
                        tc.Append(tempDC.Contents, TXTextControl.BinaryStreamType.WordprocessingML, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".txt":
                        tc.Append(tempDC.ContentsAsText, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".rtf":
                        tc.Append(tempDC.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".doc":
                        tc.Append(tempDC.Contents, TXTextControl.BinaryStreamType.MSWord, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".htm":
                    case ".html":
                        tc.Append(tempDC.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                }

                switch (tempDC.Ext.ToLower())
                {
                    case ".pdf":
                        byte[] contentsPDF;
                        tc.Save(out contentsPDF, TXTextControl.BinaryStreamType.AdobePDF);
                        printout.Contents = contentsPDF;

                        break;
                    case ".docx":
                        byte[] contentsXML;
                        tc.Save(out contentsXML, TXTextControl.BinaryStreamType.WordprocessingML);
                        printout.Contents = contentsXML;
                        break;
                    case ".doc":
                        byte[] contentsDOC;
                        tc.Save(out contentsDOC, TXTextControl.BinaryStreamType.MSWord);
                        printout.Contents = contentsDOC;
                        break;
                    case ".rtf":
                        string contentsRTF;
                        tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
                        printout.ContentsAsText = contentsRTF;
                        break;
                    case ".htm":
                    case ".html":
                        string contentsHTML;
                        tc.Save(out contentsHTML, TXTextControl.StringStreamType.HTMLFormat);
                        printout.ContentsAsText = contentsHTML;
                        break;
                    default:
                        string contentsTxt;
                        tc.Save(out contentsTxt, TXTextControl.StringStreamType.PlainText);
                        printout.ContentsAsText = contentsTxt;
                        break;
                }
            }

            return printout;
        }
        public void AddReplyHeader(docDB.DocumentRow origMsg, docDB.DocumentRow newMsg)
        {

            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            tc.CreateControl();
            tc.Text = "";
            switch (newMsg.DocContentRow.Ext.Trim().ToLower())
            {
                case ".docx":

                    tc.Append(newMsg.DocContentRow.Contents, TXTextControl.BinaryStreamType.WordprocessingML, TXTextControl.AppendSettings.StartWithNewParagraph);
                    break;

                case ".txt":
                    tc.Append(newMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewParagraph);
                    break;
                case ".rtf":
                    tc.Append(newMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                    break;
                case ".doc":
                    tc.Append(newMsg.DocContentRow.Contents, TXTextControl.BinaryStreamType.MSWord, TXTextControl.AppendSettings.StartWithNewParagraph);
                    break;
                case ".htm":
                case ".html":
                    tc.Append(newMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                    break;
            }

            tc.Select(tc.Text.Length, 0);

            tc.Selection.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + GetMessageHeader(origMsg, false) + Environment.NewLine + Environment.NewLine;

            tc.Select(tc.Text.Length, 0);
            if (!newMsg.IsReplyTextNull())
                tc.Selection.Text = newMsg.ReplyText;

            if (newMsg.DocContentRow.Ext.Trim().ToLower() == ".rtf")
            {
                tc.Selection.Start = tc.Text.Length;
                tc.Selection.Load(RTFForDoc(origMsg.DocContentRow), TXTextControl.StringStreamType.RichTextFormat);
                //tc.Append(RTFForDoc( origMsg.DocContentRow), TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
            }
            else
            {
                switch (origMsg.DocContentRow.Ext.Trim().ToLower())
                {
                    case ".docx":

                        tc.Append(origMsg.DocContentRow.Contents, TXTextControl.BinaryStreamType.WordprocessingML, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;

                    case ".txt":
                        tc.Append(origMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".rtf":
                        tc.Append(origMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".doc":
                        tc.Append(origMsg.DocContentRow.Contents, TXTextControl.BinaryStreamType.MSWord, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".htm":
                    case ".html":
                        tc.Selection.Start = tc.Text.Length;
                        tc.Selection.Load(origMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat);
                        //tc.Append(origMsg.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                }
            }
            switch (newMsg.DocContentRow.Ext.ToLower())
            {
                case ".pdf":
                    byte[] contentsPDF;
                    tc.Save(out contentsPDF, TXTextControl.BinaryStreamType.AdobePDF);
                    newMsg.DocContentRow.Contents = contentsPDF;

                    break;
                case ".docx":
                    byte[] contentsXML;
                    tc.Save(out contentsXML, TXTextControl.BinaryStreamType.WordprocessingML);
                    newMsg.DocContentRow.Contents = contentsXML;
                    break;
                case ".doc":
                    byte[] contentsDOC;
                    tc.Save(out contentsDOC, TXTextControl.BinaryStreamType.MSWord);
                    newMsg.DocContentRow.Contents = contentsDOC;
                    break;
                case ".rtf":
                    string contentsRTF;
                    tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
                    newMsg.DocContentRow.ContentsAsText = contentsRTF;
                    break;
                case ".htm":
                case ".html":
                    string contentsHTML;
                    tc.Save(out contentsHTML, TXTextControl.StringStreamType.HTMLFormat);
                    newMsg.DocContentRow.ContentsAsText = contentsHTML;
                    break;
                default:
                    string contentsTxt;
                    tc.Save(out contentsTxt, TXTextControl.StringStreamType.PlainText);
                    newMsg.DocContentRow.ContentsAsText = contentsTxt;
                    break;
            }


        }

        //public string RollupThread(atriumDB.ActivityRow msg)
        //{
        //    try
        //    {
        //        bool first = true;

        //        atriumDB.ActivityRow ar = msg;

        //        TXTextControl.TextControl tc = new TXTextControl.TextControl();
        //        tc.CreateControl();
        //        tc.Text = "";

        //        while (ar != null)
        //        {
        //            if (!ar.IsDocIdNull() & ar.Communication)
        //            {
        //                docDB.DocumentRow ddr = Load (ar.DocId);// myDocumentDT.FindByDocId(ar.DocId);
        //                if (!ddr.DocContentRow.IsContentsNull())
        //                {
        //                    if (!first)
        //                    {
        //                        tc.Selection.Start = tc.Text.Length;
        //                        tc.Selection.Load(GetMessageHeader(ddr), TXTextControl.StringStreamType.HTMLFormat);
        //                        first = false;
        //                    }

        //                    tc.Selection.Start = tc.Text.Length;

        //                    switch (ddr.DocContentRow.Ext.Trim().ToLower())
        //                    {
        //                        case ".txt":
        //                            tc.Selection.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.PlainText);
        //                            break;
        //                        case ".rtf":
        //                            tc.Selection.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat);
        //                            break;
        //                        case ".doc":
        //                            tc.Selection.Load(ddr.DocContentRow.Contents, TXTextControl.BinaryStreamType.MSWord);
        //                            break;
        //                        case ".htm":
        //                        case ".html":
        //                            tc.Selection.Load(ddr.DocContentRow.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat);
        //                            break;
        //                    }
        //                }
        //            }
        //            if (ar.IsPreviousActivityIdNull())
        //                ar = null;
        //            else
        //                ar = myA.FM.DB.Activity.FindByActivityId(ar.PreviousActivityId);
        //        }

        //        string html;
        //        tc.Save(out html, TXTextControl.StringStreamType.RichTextFormat);
        //        tc.Dispose();
        //        return html;
        //    }
        //    catch (Exception x)
        //    {
        //        return "Blank";

        //    }

        //}
        public string RTFForDoc(docDB.DocContentRow doc)
        {
            string contentsRTF = null;
            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            try
            {
                tc.CreateControl();
                tc.Text = "";
                switch (doc.Ext.Trim().ToLower())
                {
                    case ".docx":

                        tc.Append(doc.Contents, TXTextControl.BinaryStreamType.WordprocessingML, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;

                    case ".txt":
                        tc.Append(doc.ContentsAsText, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".rtf":
                        contentsRTF = doc.ContentsAsText;
                        break;
                    case ".doc":
                        tc.Append(doc.Contents, TXTextControl.BinaryStreamType.MSWord, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".htm":
                    case ".html":
                        tc.Append(doc.ContentsAsText, TXTextControl.StringStreamType.HTMLFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    default:
                        return null;
                }
                if (contentsRTF == null)
                {
                    // TXTextControl.SaveSettings txss = new TXTextControl.SaveSettings();
                    //   txss.ImageSaveMode= TXTextControl.ImageSaveMode.Auto
                    tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
                }
            }
            catch (Exception x)
            {
                //contentsRTF = DocContentBE.RTF;
                //throw new AtriumException("There is a problem with the HTML in the original message.  LawMate cannot format the reply.  Please exit and restart LawMate.", x);
                tc.ResetContents();
                tc.ResetText();

                tc.Append(StripHTML(doc.ContentsAsText), TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewParagraph);
                tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);

            }
            finally
            {
                tc.ResetContents();
                tc.ResetText();
                tc.Dispose();
            }
            return contentsRTF;

        }

        public static string StripHTML(string HTMLText)
        {

            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("&nbsp;", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, " ");

            reg = new System.Text.RegularExpressions.Regex("&amp;", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, "&");

            reg = new System.Text.RegularExpressions.Regex("\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, "");
            reg = new System.Text.RegularExpressions.Regex("\r", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, "");

            reg = new System.Text.RegularExpressions.Regex("<br>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, "\n\r");

            reg = new System.Text.RegularExpressions.Regex("</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, "\n\r");
            reg = new System.Text.RegularExpressions.Regex("</div>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            HTMLText = reg.Replace(HTMLText, "\n\r");

            reg = new System.Text.RegularExpressions.Regex("<[^>]+>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return reg.Replace(HTMLText, "");
        }
        public string HTMLForDoc(docDB.DocContentRow doc)
        {
            string contentsHTML = null;
            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            try
            {
                tc.CreateControl();
                tc.Text = "";
                switch (doc.Ext.Trim().ToLower())
                {
                    case ".docx":

                        tc.Append(doc.Contents, TXTextControl.BinaryStreamType.WordprocessingML, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;

                    case ".txt":
                        tc.Append(doc.ContentsAsText, TXTextControl.StringStreamType.PlainText, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".rtf":
                        tc.Append(doc.ContentsAsText, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);

                        break;
                    case ".doc":
                        tc.Append(doc.Contents, TXTextControl.BinaryStreamType.MSWord, TXTextControl.AppendSettings.StartWithNewParagraph);
                        break;
                    case ".htm":
                    case ".html":

                        contentsHTML = doc.ContentsAsText;
                        break;
                    default:
                        return null;
                }
                if (contentsHTML == null)
                    tc.Save(out contentsHTML, TXTextControl.StringStreamType.HTMLFormat);
            }
            catch (Exception x)
            {
                contentsHTML = "";// DocContentBE.RTF;
                throw new AtriumException(String.Format(Properties.Resources.ProblemWithHTML, myA.AtMng.AppMan.AppName), x);
            }
            finally
            {
                tc.ResetContents();
                tc.ResetText();
                tc.Dispose();
            }
            return contentsHTML;

        }
        public void Resend(atriumDB.ActivityRow msg)
        {
            if (msg.FailedToSend)
            {
                msg.FailedToSend = false;
                //docDB.DocumentRow msgDoc = myDocumentDT.FindByDocId(msg.DocId);
                //msgDoc.EncryptionRequired = true;
                SendCore(msg, true, true);
            }
            else
                throw new AtriumException(Properties.Resources.CantResendSentDoc);
        }

        public void Send(atriumDB.ActivityRow msg)
        {
            Send(msg, false);
        }
        public void Send(atriumDB.ActivityRow msg, bool encrypt)
        {
            if (!msg.Communication | msg.IsDocIdNull())
                return;

            docDB.DocumentRow msgDoc = SendCore(msg, false, encrypt);

            //myA.AtMng.AppMan.Commit();
            //msgDoc.AcceptChanges();
            //msgDoc.DocContentRow.AcceptChanges();

        }
        bool forceHTML = false;
        private docDB.DocumentRow SendCore(atriumDB.ActivityRow msg, bool resend, bool encrypt)
        {
            docDB.DocumentRow msgDoc = myDocumentDT.FindByDocId(msg.DocId);

            //check security to see if message can go out of atrium

            //go through recipients
            bool sendByEmail = false;
            sendByEmail = SendByMail(msgDoc)[0];
            if (sendByEmail)
            {
                Redemption.RDOMail mail = CreateMsg(msg, msgDoc);

                mail.Save();

                if (encrypt)
                {
                    try
                    {

                        mail.Display(true, missing);
                        if (!mail.Submitted)
                        {
                            // mail.Delete(Redemption.redDeleteFlags.dfSoftDelete);
                            throw new AtriumException(Properties.Resources.EmailWasNotSent);
                        }
                    }
                    catch (Exception xm)
                    {
                        mail.Delete(Redemption.redDeleteFlags.dfSoftDelete);

                        throw new AtriumException(Properties.Resources.EmailWasNotSent);
                    }
                }
                else
                    mail.Send();



            }
            else
            {
                //everyone is in atrium so setup bfs
                //or does the bf mech handle this 
                //automatically
                //
            }
            AllowEdit = true;
            msgDoc.SentTime = DateTime.UtcNow;
            msgDoc.ReceivedTime = msgDoc.SentTime;
            msgDoc.IsDraft = false;
            // 2013-06-12 JLL: update to use isDraft only
            //if (!msgDoc.DocContentRow.ReadOnly)
            //    msgDoc.DocContentRow.ReadOnly = true;
            if (!resend)
            {
                atLogic.BusinessProcess bp = myA.AtMng.GetBP();
                bp.AddForUpdate(myA.GetDocContent());
                bp.AddForUpdate(this);
                bp.Update();

                //Update();
                //myA.GetDocContent().Update();
            }
            AllowEdit = false;
            return msgDoc;
        }

        private Redemption.RDOMail CreateMsg(atriumDB.ActivityRow msg, docDB.DocumentRow msgDoc)
        {

            Redemption.RDOSession session = RDOSession();
            session.Logon(missing, missing, missing, missing, missing, missing);

            Redemption.RDOMail mail = session.GetDefaultFolder(Redemption.rdoDefaultFolders.olFolderOutbox).Items.Add("IPM.Note");


            return BuildMail(msg, msgDoc, mail);
        }

        private Redemption.RDOMail BuildMail(atriumDB.ActivityRow msg, docDB.DocumentRow msgDoc, Redemption.RDOMail mail)
        {
            //roll up thread to last rollup
            string rolledUp;

            switch (msgDoc.DocContentRow.Ext.ToLower())
            {
                case ".doc":
                case ".docx":
                    //get rtf for doc

                    if (forceHTML)
                        rolledUp = HTMLForDoc(msgDoc.DocContentRow);
                    else
                        rolledUp = RTFForDoc(msgDoc.DocContentRow);

                    break;
                default:
                    rolledUp = msgDoc.DocContentRow.ContentsAsText;
                    break;
            }

            mail.Subject = msgDoc.efSubject;

            if (!msg.IsBFPriorityNull())
            {
                switch (msg.BFPriority)
                {
                    case 0:
                        mail.Importance = 1;
                        break;
                    case 1:
                    case 2:
                        mail.Importance = 2;
                        break;
                }
            }

            if (msg != null)
            {
                mail.ConversationTopic = msg.ProcessRow.Thread;
                mail.ConversationIndex = msg.ConvIndexBase + msg.ConversationIndex;
            }

            switch (msgDoc.DocContentRow.Ext.ToLower())
            {
                case ".htm":
                case ".html":
                    mail.BodyFormat = 2;
                    mail.HTMLBody = rolledUp;
                    break;
                case ".doc":
                    if (forceHTML)
                    {
                        mail.BodyFormat = 2;
                        mail.HTMLBody = rolledUp;
                    }
                    else
                    {
                        mail.BodyFormat = 3;
                        mail.RTFBody = rolledUp;
                    }
                    break;
                case ".docx":
                case ".rtf":
                    mail.BodyFormat = 3;
                    mail.RTFBody = rolledUp;
                    break;
                case ".txt":
                    mail.BodyFormat = 1;
                    mail.Body = rolledUp;
                    break;
                default:
                    mail.BodyFormat = 0;
                    mail.Body = rolledUp;
                    break;

            }


            foreach (docDB.AttachmentRow att in msgDoc.GetAttachmentRowsByDocument_Attachment())
            {
                try
                {
                    docDB.DocumentRow d = att.DocumentRowByDocument_Attachment1;
                    //string tmp=myA.GetDocContent().WriteTempFile(d.DocContentRow);
                    if (d.isElectronic && d.DocContentRow == null)
                    {
                        myA.GetDocContent().Load(d.DocRefId, d.CurrentVersion);
                    }

                    //if attachment is a mail item force in header info

                    Redemption.RDOAttachment a = mail.Attachments.Add(Print(d).Contents, missing, missing, d.Name);
                    a.FileName = d.Name;


                }
                catch (Exception xa)
                {
                    System.Diagnostics.Trace.WriteLine(xa.Message);
                }
            }


            foreach (docDB.RecipientRow r in msgDoc.GetRecipientRows())
            {
                try
                {
                    if (r.Type != "0")
                    {
                        if (!r.IsAddressNull())
                            mail.Recipients.AddEx(r.Name, r.Address, r.AddressType, r.Type);
                        else
                            throw new AtriumException("Recipient does not have an email address");

                        //if (r.Address.Contains("@"))
                        //    mail.Recipients.AddEx(r.Name, r.Address, "SMTP", r.Type);
                        //else
                        //    mail.Recipients.AddEx(r.Name, r.Address, "EX", r.Type);
                    }
                    else if (r.Type == "0" && msg == null)
                    {
                        if (!r.IsAddressNull())
                        {


                            mail.SenderName = r.Name;
                            mail.SenderEmailType = r.AddressType;
                            mail.SenderEmailAddress = r.Address;

                        }
                    }
                }
                catch (Exception xr)
                {
                    System.Diagnostics.Trace.WriteLine(xr.Message);
                }
            }

            //mail.Recipients.ResolveAll(missing, missing);
            return mail;
        }

        public string GetCheckOutPath()
        {
            //string fld = myA.AtMng.OfficeMng.GetOfficer().GetPrefs(myA.AtMng.OfficerLoggedOn).CheckoutPath;

            //if (fld == "" || fld == null)
            //    fld = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);


            string fld = myA.AtMng.AppMan.LawMatePath;
            fld += @"Checked out documents en retrait\";
            if (!System.IO.Directory.Exists(fld))
                System.IO.Directory.CreateDirectory(fld);

            return fld;
        }


        public string Checkout(docDB.DocumentRow doc)
        {

            // 2013-06-12 JLL: update to use isDraft only
            //if (doc.ReadOnly | !doc.DocumentRow.IsDraft)
            if (!doc.IsDraft)
                throw new AtriumException(Properties.Resources.CannotCheckOutReadOnlyDoc);


            try
            {
                //create temp folder for viewing docs
                string fld = GetCheckOutPath();
                fld += doc.FileId.ToString() + @"\";
                if (!Directory.Exists(fld))
                    Directory.CreateDirectory(fld);

                //strip invalid characters out of file name
                string temp = fld + doc.Name;

                temp = temp.Trim();

                string test = temp;
                int i = 1;
                while (System.IO.File.Exists(test))
                {
                    test = fld + System.IO.Path.GetFileNameWithoutExtension(temp) + "_" + i.ToString() + System.IO.Path.GetExtension(temp);
                    i++;
                }
                temp = test;

                //write temp file
                if (!File.Exists(temp))
                    File.WriteAllBytes(temp, doc.DocContentRow.Contents);

                //File.Encrypt(temp);

                doc.CheckedOutDate = DateTime.Now;
                doc.CheckedOutBy = myA.AtMng.OfficerLoggedOn.OfficerId;
                doc.CheckedOutPath = temp;

                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(this);
                bp.Update();



                return temp;
            }
            catch (Exception x)
            {

                doc.RejectChanges();

                throw x;
            }

        }

        public void Checkin(docDB.DocumentRow doc)
        {
            //create temp folder for viewing docs

            if (doc.IsCheckedOutByNull())
                throw new AtriumException(Properties.Resources.DocIsNotCheckedOut);

            if (doc.CheckedOutBy != myA.AtMng.OfficerLoggedOn.OfficerId)
                throw new AtriumException(Properties.Resources.DocIsNotCheckedOutToYou);

            string temp = doc.CheckedOutPath;

            //write temp file

            if (File.Exists(temp))
            {
                try
                {
                    try
                    {
                        doc.DocContentRow.Contents = File.ReadAllBytes(temp);
                    }
                    catch (IOException xr)
                    {
                        throw new AtriumException(Properties.Resources.CloseDocBeforeCheckin);
                    }
                    catch (Exception x1)
                    {
                        throw x1;
                    }
                    doc.SetCheckedOutDateNull();
                    doc.SetCheckedOutByNull();
                    doc.SetCheckedOutPathNull();

                    BusinessProcess bp = myA.GetBP();
                    //doccontent must be updated before document!!!!!!! CJW 2015-2-26
                    bp.AddForUpdate(myA.GetDocContent());
                    bp.AddForUpdate(this);
                    bp.Update();

                    File.Delete(temp);
                }
                catch (Exception x)
                {

                    doc.RejectChanges();

                    throw x;
                }

            }
            else
            {
                throw new AtriumException(Properties.Resources.DocumentCouldNotBeFoundForCheckin);
            }

        }

        public void UndoCheckout(docDB.DocumentRow doc)
        {
            if (doc.IsCheckedOutByNull())
                throw new AtriumException(Properties.Resources.DocIsNotCheckedOut);

            if (doc.CheckedOutBy != myA.AtMng.OfficerLoggedOn.OfficerId)
                throw new AtriumException(Properties.Resources.DocIsNotCheckedOutToYou);

            //create temp folder for viewing docs
            string temp = doc.CheckedOutPath;

            //write temp file
            if (File.Exists(temp))
            {
                try
                {
                    File.Delete(temp);
                }
                catch (IOException xr)
                {
                    throw new AtriumException(Properties.Resources.CloseDocBeforeUndoCheckout);
                }
                catch (Exception x1)
                {
                    throw x1;
                }

            }
            try
            {

                doc.SetCheckedOutDateNull();
                doc.SetCheckedOutByNull();
                doc.SetCheckedOutPathNull();

                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(this);
                bp.Update();
            }
            catch (Exception x)
            {

                doc.RejectChanges();

                throw x;
            }


        }


        private bool CheckList(int listId)
        {
            bool sendByMail = false;

            appDB.ListRow lr = myA.AtMng.DB.List.FindByListId(listId);
            //create a bf for every list member
            foreach (appDB.ListMemberRow lmr in lr.GetListMemberRows())
            {
                if (!lmr.IsMemberListIdNull())
                {
                    if (CheckList(lmr.MemberListId))
                        sendByMail = true;
                }
                else
                {
                    //assume it is an officer
                    if (!lmr.IsContactIdNull() && IsOfficerUsingEmail(lmr.ContactId))
                        sendByMail = true;
                }
            }

            return sendByMail;
        }

        /// <summary>
        /// Returns [bool SendAsOutlook, bool SendAsAtriumMail] after having looped through all recipients and determined delivery method
        /// </summary>
        /// <param name="msgDoc"></param>
        /// <returns></returns>
        public bool[] SendByMail(docDB.DocumentRow msgDoc)
        {
            bool sendAsOutlook = false;
            bool sendAsAtriumMail = false;

            foreach (docDB.RecipientRow r in msgDoc.GetRecipientRows())
            {
                if (r.Type != "0")
                {
                    //also check if officer is online
                    if (r.IsOfficerIdNull() & r.IsListIdNull() & !r.IsAddressNull())
                    {
                        //send by email if we only have an email address
                        sendAsOutlook = true;
                    }
                    else if (!r.IsListIdNull())
                    {
                        //check to see if members are non-lawmail users
                        if (CheckList(r.ListId))
                            sendAsOutlook = true;
                    }
                    else if (!r.IsOfficerIdNull())
                    {
                        if (IsOfficerUsingEmail(r.OfficerId))
                            sendAsOutlook = true;
                        else
                            sendAsAtriumMail = true;
                    }
                    else
                        sendAsAtriumMail = true;
                }
            }

            return new bool[2] { sendAsOutlook, sendAsAtriumMail };
        }

        private bool IsOfficerUsingEmail(int officerId)
        {
            officeDB.OfficerRow orr = myA.AtMng.OfficeMng.GetOfficer().FindLoad(officerId);
            if (orr == null)
                return true;
            else
            {
                if (orr.IsActiveNull() || !orr.Active || !orr.IsMail)
                {
                    //send by email if the officer is not online
                    if (!orr.IsEmailAddressNull())
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        protected override void BeforeUpdate(DataRow r)
        {
            docDB.DocumentRow dr = (docDB.DocumentRow)r;
            if (!dr.isElectronic && dr.DocContentRow == null)
                dr.SetDocRefIdNull();

            dr.SettemplateCodeNull();

            //if (dr.IsNameNull())
            //{
            //    if (dr.efSubject.Length + dr.DocContentRow.Ext.Length > 255)
            //    {
            //        int maxSubject = 255 - dr.DocContentRow.Ext.Length;
            //        dr.Name = dr.efSubject.Substring(0, maxSubject) + dr.DocContentRow.Ext;
            //    }
            //    else
            //        dr.Name = dr.efSubject + dr.DocContentRow.Ext;
            //}


        }

        protected override void BeforeChange(DataColumn dc, DataRow r)
        {
            docDB.DocumentRow dr = (docDB.DocumentRow)r;

            switch (dc.ColumnName)
            {

                case "IsDraft":
                    //check override permission on document
                    if (myA.AtMng.SecurityManager.CanOverride(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.Document) == atSecurity.SecurityManager.ExPermissions.No)
                    {
                        if (dr.HasVersion(DataRowVersion.Original) && (bool)dr[dc, DataRowVersion.Original] == false && dr.IsDraft == true)
                            throw new ReadOnlyException();
                    }
                    if (!dr.IsCheckedOutByNull() && dr.IsDraft == false)
                        throw new AtriumException("You cannot finalize a document that is checked out");
                    break;
                case "CommMode":
                    if (!dr.IsCommModeNull() && !myA.CheckDomain(dr.CommMode, myA.FM.Codes("CommMode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Communication Mode");
                    break;
                case "efType":
                    if (dr.IsefTypeNull())
                        throw new RequiredException("Document Type");

                    if (!dr.IsefTypeNull() && !myA.CheckDomain(dr.efType, myA.FM.Codes("DocType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Document Type");
                    break;

            }
        }
        //public void VerifyDocuments(atriumDB.EFileRow er)
        //{
        //    //load docs
        //    LoadByFileId(er.FileId);

        //    //load files
        //    string[] files = System.IO.Directory.GetFiles(er.FullPath);

        //    //check for mis-matches            
        //    foreach (string fil in files)
        //    {
        //        string tmpFil = fil.Replace("'", "''");
        //        try
        //        {
        //            docDB.DocumentRow[] drs = (docDB.DocumentRow[])this.myDocumentDT.Select("Path='" + tmpFil + "'");
        //            if (fil.Length >= 260)
        //            {
        //                System.Diagnostics.Trace.WriteLine("DOCUMENT PATH TOO LONG;" + fil + ";" + fil.Length.ToString());
        //            }
        //            else if (drs.Length == 0)
        //            {
        //                //********************************************
        //                //add document record if file system is master copy
        //                //********************************************
        //                FileInfo fi = new FileInfo(fil);
        //                string name = fi.Name;


        //                docDB.DocumentRow newDoc = (docDB.DocumentRow)this.Add(er);
        //                myA.GetDocContent().Add(newDoc);

        //                newDoc.BeginEdit();
        //                newDoc.FileId = er.FileId;

        //                //*********************
        //                //load doc into database
        //                //*********************
        //                if (fil.Length < 2000000)
        //                    newDoc.DocContentRow.Contents = System.IO.File.ReadAllBytes(fil);


        //                newDoc.DocContentRow.Size = (int)fi.Length;
        //                newDoc.Name = fi.Name;
        //                newDoc.DocContentRow.Ext = fi.Extension;
        //                newDoc.DocContentRow.CreateDate = EFileBE.FixSQLDateLow(fi.CreationTime);
        //                newDoc.DocContentRow.ModDate = EFileBE.FixSQLDateLow(fi.LastWriteTime);

        //                if (fi.Name.ToUpper().IndexOf(" PV ") > 0)
        //                    newDoc.PV = true;
        //                else
        //                    newDoc.PV = false;

        //                newDoc.Security = "PRO";
        //                newDoc.isElectronic = true;
        //                newDoc.isPaper = false;
        //                newDoc.Source = "LoadEfiles";


        //                //newDoc.Author=how to get

        //                newDoc.Path = fil;
        //                newDoc.IsDraft = false;


        //                //strip extension from name for subject
        //                if (newDoc.Name.LastIndexOf(".") > 0)
        //                    newDoc.efSubject = newDoc.Name.Substring(0, newDoc.Name.LastIndexOf("."));
        //                else
        //                    newDoc.efSubject = newDoc.Name;

        //                try
        //                {
        //                    string from = "", to = "", re = "";

        //                    string date = fi.Name.Substring(0, 10);
        //                    DateTime dDate = DateTime.ParseExact(date, "yyyy-MM-dd", null);
        //                    newDoc.efDate = EFileBE.FixSQLDateLow(dDate);

        //                    int posFrom = name.ToLower().IndexOf(" from ");
        //                    int posTo = name.ToLower().IndexOf(" to ");
        //                    int posRe = name.ToLower().IndexOf(" re ");
        //                    int posDot = name.LastIndexOf(".");

        //                    int posFirstBlank = name.IndexOf(" ");
        //                    int posSecondBlank = name.IndexOf(" ", posFirstBlank + 1);

        //                    string type = "";
        //                    if (posFirstBlank > 0 & posSecondBlank > 0)
        //                    {
        //                        string seq = name.Substring(posFirstBlank + 1, posSecondBlank - posFirstBlank - 1);
        //                        seq = seq.Replace("_", ".");
        //                        if (EFileBE.IsNumeric(seq))
        //                        {
        //                            newDoc.efSeq = seq;
        //                        }
        //                        else
        //                        {
        //                            type = seq;
        //                        }
        //                    }
        //                    if (type.Length == 0)
        //                    {
        //                        posFirstBlank = posSecondBlank;
        //                        posSecondBlank = name.IndexOf(" ", posFirstBlank + 1);
        //                        //newDoc.efCodes=codes;
        //                        if (posFirstBlank > 0 & posSecondBlank > 0)
        //                            type = name.Substring(posFirstBlank + 1, posSecondBlank - posFirstBlank - 1);

        //                    }
        //                    if ("ATT EML FAX LET MEM".IndexOf(type.ToUpper()) >= 0)
        //                    {
        //                        newDoc.efType = type;
        //                    }


        //                    if (posFrom > 0)
        //                    {
        //                        if (posFrom > posSecondBlank)
        //                            newDoc.efCodes = name.Substring(posSecondBlank, posFrom - posSecondBlank);

        //                        from = name.Substring(posFrom + 6, posTo - posFrom - 6);
        //                        newDoc.efFrom = from;

        //                        re = name.Substring(posRe + 4, posDot - posRe - 4);
        //                        newDoc.efSubject = re;

        //                        to = name.Substring(posTo + 4, posRe - posTo - 4);
        //                        newDoc.efTo = to;

        //                    }
        //                    else if (newDoc.efType.ToUpper() == "ATT")
        //                    {

        //                        re = name.Substring(posSecondBlank, posDot - posSecondBlank);
        //                        newDoc.efSubject = re;
        //                    }
        //                }
        //                catch (Exception x)
        //                {
        //                    //newDoc.Error = x.Message;
        //                }

        //                newDoc.EndEdit();

        //                //save record
        //                Update();
        //                myA.GetDocContent().Update();
        //                myA.DALMngr.Commit();

        //                System.Diagnostics.Trace.WriteLine("ADD DOCUMENT;" + newDoc.Path);
        //            }
        //            else if (drs.Length == 1)
        //            {

        //                docDB.DocumentRow dr = drs[0];
        //                myA.GetDocContent().Load(dr.DocId);

        //                //if(dr.ModDate.ToString()!=fi.LastWriteTime.ToString())
        //                FileInfo fi = new FileInfo(fil);
        //                TimeSpan ts = dr.DocContentRow.ModDate.Subtract(fi.LastWriteTime);
        //                if (ts.Duration().Seconds > 5)
        //                {
        //                    dr.BeginEdit();
        //                    dr.DocContentRow.CreateDate = EFileBE.FixSQLDateLow(fi.CreationTime);
        //                    dr.DocContentRow.ModDate = EFileBE.FixSQLDateLow(fi.LastWriteTime);
        //                    dr.DocContentRow.Size = (int)fi.Length;
        //                    //*********************
        //                    //load doc into database
        //                    //*********************
        //                    if (fil.Length < 2000000)
        //                        dr.DocContentRow.Contents = System.IO.File.ReadAllBytes(fil);

        //                    dr.EndEdit();
        //                    //save record
        //                    Update();
        //                    myA.GetDocContent().Update();
        //                    myA.DALMngr.Commit();

        //                    System.Diagnostics.Trace.WriteLine("UPDATE DOCUMENT;" + fil);
        //                }
        //            }
        //        }
        //        catch (Exception x)
        //        {
        //            System.Diagnostics.Trace.WriteLine("ERROR ADD DOC;" + x.Message + ";" + fil);
        //        }

        //    }
        //    myDocumentDT.Clear();
        //    myDocumentDT.AcceptChanges();
        //}


        public override bool CanEdit(DataRow ddr)
        {
            try
            {

                docDB.DocumentRow dr = (docDB.DocumentRow)ddr;
                if (dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Unchanged)
                {
                    //make read-only if the document does not relate to the current file
                    if (myA.FM.IsVirtualFM || dr.IsNull("FileId") || dr.FileId != myA.FM.CurrentFile.FileId)
                        return false | AllowEdit;

                    bool ok = true;// (bool)dr["isDraft", DataRowVersion.Original];

                    return ok | AllowEdit;// | dr.isdraft
                }
                else
                    return true;
            }
            catch
            {
                return false;
            }


        }

        public override DataRow[] GetCurrentRow()
        {
            return myDocumentDT.Select(); ;
        }

        public override string PromptFormat()
        {
            return base.PromptFormat();
        }

        public static Redemption.RDOSession RDOSession()
        {
            //Type t = Type.GetTypeFromProgID("lmMail.atRDOSession");
            //return (Redemption.RDOSession)Activator.CreateInstance(t);

            //return new Redemption.RDOSession();

            //tell the app where the 32 and 64 bit dlls are located

            //by default, they are assumed to be in the same folder as the current assembly and be named 

            //Redemption.dll and Redemption64.dll. 

            //In that case, you do not need to set the two properties below

            Redemption.RedemptionLoader.DllLocation64Bit = AppDomain.CurrentDomain.BaseDirectory + @"redemption64.dll";

            Redemption.RedemptionLoader.DllLocation32Bit = AppDomain.CurrentDomain.BaseDirectory + @"redemption.dll";

            //  throw new Exception(Redemption.RedemptionLoader.DllLocation32Bit);
            //Create a Redemption object and use it

            return Redemption.RedemptionLoader.new_RDOSession();


            ;

        }
        public static Redemption.MAPIUtils MAPIUtils()
        {
            //Type t = Type.GetTypeFromProgID("lmMail.atMAPIUtils");
            //return (Redemption.MAPIUtils)Activator.CreateInstance(t);

            //return new Redemption.MAPIUtils();

            Redemption.RedemptionLoader.DllLocation64Bit = AppDomain.CurrentDomain.BaseDirectory + @"redemption64.dll";

            Redemption.RedemptionLoader.DllLocation32Bit = AppDomain.CurrentDomain.BaseDirectory + @"redemption.dll";


            //Create a Redemption object and use it

            return Redemption.RedemptionLoader.new_MAPIUtils();
        }

        Redemption.RDOSession sessionEx;
        public void Export()
        {


            System.Diagnostics.Trace.WriteLine(DateTime.Now);

            RDOSessionStart();

            foreach (docDB.DocumentRow dr in myDocumentDT.Rows)
            {
                if (dr.isElectronic)
                {
                    //check to see if it is only an attachment in this file - ignore other files
                    if (myA.DB.Attachment.Select("MsgId=" + dr.DocId.ToString()).Length > 0 || myA.FM.DB.Activity.Select("Docid=" + dr.DocId.ToString()).Length > 0)
                    {
                        if (dr.DocContentRow == null)
                            myA.GetDocContent().Load(dr.DocRefId, dr.CurrentVersion);

                        Export(dr, true, myA.GetDocContent().GetTempPath(dr));
                    }
                }
            }

            sessionEx.Logoff();
            System.Diagnostics.Trace.WriteLine(DateTime.Now);
        }

        private void RDOSessionStart()
        {
            sessionEx = RDOSession();
            sessionEx.Logon(missing, missing, missing, missing, missing, missing);
        }

        public void Export(docDB.DocumentRow dr, bool asMsg, string folder)
        {
            // we also need to restore the documnet time attributes
            bool hasAtt = false;
            if (dr.GetAttachmentRowsByDocument_Attachment().Length > 0)
                hasAtt = true;

            //if comm
            if (dr.isLawmail)
            {
                if (asMsg || dr.Source == "Outlook" || hasAtt)
                {

                    //  string oldExt = dr.DocContentRow.Ext;
                    dr.DocContentRow.Ext = ".msg";
                    string tmp = myA.GetDocContent().GetTempFileName(dr, folder);
                    //dr.DocContentRow.Ext = oldExt;
                    dr.RejectChanges();
                    dr.DocContentRow.RejectChanges();

                    Redemption.RDOMail mail = sessionEx.GetMessageFromMsgFile(tmp, true);
                    BuildMail(null, dr, mail);
                    mail.SentOn = dr.efDate;
                    mail.Sent = true;
                    mail.Save();
                    //mail.SaveAs(tmp,missing);
                    //mail.Delete();
                }
                else
                {
                    //TODO:  fix this line .DocumentRow will always be null
                    myA.GetDocContent().WriteTempFile(Print(dr).DocumentRow, false, folder);
                }

            }
            else
            {   //if document
                myA.GetDocContent().WriteTempFile(dr, false, folder);
            }
        }

        public int TotalSize(docDB.DocumentRow dr)
        {
            if (dr.DocContentRow == null)
                return 0;
            else
            {
                int s = dr.DocContentRow.Size;
                foreach (docDB.AttachmentRow atr in dr.GetAttachmentRowsByDocument_Attachment())
                {
                    if (atr.DocumentRowByDocument_Attachment1.DocContentRow != null)
                        s += atr.DocumentRowByDocument_Attachment1.DocContentRow.Size;
                }

                return s;

            }
        }

        public void Delete(int docid, atriumDB.ActivityRow ar, docDB.AttachmentRow attr)
        {
            //check to see if document can be deleted
            docDB.DocumentRow dr = myA.DB.Document.FindByDocId(docid);

            bool ok2Delete = false;
            //check other activities
            //check templates
            //check opinions
            //check to see if it is an attachment somewhere else
            Object[] obj = new Object[3];
            obj[0] = docid;
            if (ar == null)
            {
                obj[1] = DBNull.Value;
                obj[2] = attr.Id;
            }
            else
            {
                obj[1] = ar.ActivityId;
                obj[2] = DBNull.Value;
            }
            object result = myA.AtMng.AppMan.ExecuteScalar("DocumentOK2Delete", obj);
            if ((int)result == 1)
                ok2Delete = true;

            if (ok2Delete)
            {
                foreach (docDB.RecipientRow rr in dr.GetRecipientRows())
                {
                    rr.Delete();
                }
                foreach (docDB.AttachmentRow atr in dr.GetAttachmentRowsByDocument_Attachment())
                {
                    myA.GetAttachment().Delete(atr);
                }
                dr.Delete();
            }
        }



    }
}

