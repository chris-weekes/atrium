using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace atriumBE
{
    /// <summary>
    /// Summary description for TemplateBE.
    /// </summary>
    public class TemplateBE : atLogic.ObjectBE
    {
        atriumManager myA;
        appDB.TemplateDataTable myTemplateDT;

        static string PARAG = @"\par ";
        string lang = "";
        //int lastTemplate=0;

        //  FileManager FM;

        public FileManager FM
        {
            get { return myA.GetFile(myA.GetSetting(AppIntSetting.TemplateFileId)); ; }
            //   set { FM = value; }
        }

        internal TemplateBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.Template)
        {
            myA = pBEMng;
            myTemplateDT = (appDB.TemplateDataTable)myDT;

            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetTemplate();

            Init();
        }
        public atriumDAL.TemplateDAL myDAL
        {
            get
            {
                return (atriumDAL.TemplateDAL)myODAL;
            }
        }

        public bool WhereUsed(bool TemplateIsUsed, string baseTemplateCode, DataTable _dtUsedInSteps, appDB.TemplateRow templateRow)
        {
            ActivityConfig.ActivityFieldRow[] afRows = (ActivityConfig.ActivityFieldRow[])myA.acMng.DB.ActivityField.Select("objectname='Document' and fieldname='templatecode' and ((defaultvalue='" + baseTemplateCode + "' or defaultvalue like'" + baseTemplateCode + "-%') or   (defaultvalue='" + templateRow.LetterName + "') or (lookup in ('vTemplateList1','vTemplateList2','vTemplateList3','vTemplateList4'))  )");

            foreach (ActivityConfig.ActivityFieldRow afr in afRows)
            {
                if (!afr.IsDefaultValueNull() && afr.DefaultValue == templateRow.LetterName)
                {
                    _dtUsedInSteps.Rows.Add("0D", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                    TemplateIsUsed = true;
                }
                else if (!afr.IsDefaultValueNull() && afr.DefaultValue.StartsWith(baseTemplateCode))
                {
                    _dtUsedInSteps.Rows.Add("0B", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                    TemplateIsUsed = true;
                }
                else if (templateRow.AboutDebtor && !afr.IsLookUpNull() && afr.LookUp == "vTemplateList1")
                {
                    _dtUsedInSteps.Rows.Add("List1", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                    TemplateIsUsed = true;
                }
                else if (templateRow.AboutAgent && !afr.IsLookUpNull() && afr.LookUp == "vTemplateList2")
                {
                    _dtUsedInSteps.Rows.Add("List2", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                    TemplateIsUsed = true;
                }
                else if (templateRow.HQ && !afr.IsLookUpNull() && afr.LookUp == "vTemplateList3")
                {
                    _dtUsedInSteps.Rows.Add("List3", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                    TemplateIsUsed = true;
                }
                else if (templateRow.Agent && !afr.IsLookUpNull() && afr.LookUp == "vTemplateList4")
                {
                    _dtUsedInSteps.Rows.Add("List4", afr.ACSeriesRow.StepCode, afr.ACSeriesRow.ActivityNameEng, afr.ACSeriesRow.SeriesRow.Status, afr.ACSeriesRow.SeriesCode, afr.ACSeriesRow.SeriesDescEng, afr.ACSeriesId, afr.ACSeriesRow.SeriesId, afr.ActivityFieldID, afr.ACSeriesRow.Obsolete);
                    TemplateIsUsed = true;
                }
            }

            return TemplateIsUsed;

        }


        public DataTable InitddtUsedInSteps()
        {
            DataTable _dtUsedInSteps;
            _dtUsedInSteps = new DataTable("dtUsedInSteps");
            _dtUsedInSteps.Columns.Add("ReferenceType", typeof(string));
            _dtUsedInSteps.Columns.Add("StepCode", typeof(string));
            _dtUsedInSteps.Columns.Add("ActivityNameEng", typeof(string));
            _dtUsedInSteps.Columns.Add("Status", typeof(string));
            _dtUsedInSteps.Columns.Add("SeriesCode", typeof(string));
            _dtUsedInSteps.Columns.Add("SeriesDescEng", typeof(string));
            _dtUsedInSteps.Columns.Add("ACSeriesId", typeof(int));
            _dtUsedInSteps.Columns.Add("SeriesId", typeof(int));
            _dtUsedInSteps.Columns.Add("ActivityFieldID", typeof(int));
            _dtUsedInSteps.Columns.Add("Obsolete", typeof(bool));

            return _dtUsedInSteps;
        }


        private void Init()
        {
            Load();
            //return new FileManager(this, GetSetting(AppIntSetting.TemplateFileId));
            //  FM = myA.GetFile(myA.GetSetting(AppIntSetting.TemplateFileId));
            //FM.KeepAlive = true;

            FM.GetDocMng().GetDocument();
        }

     

        public appDB.TemplateRow Load(string LetterName, string nameParam)
        {
            appDB.TemplateRow[] tmps;
            //look for most specific first default to general 

            //office + lang
            string office = myA.OfficeLoggedOn.OfficeCode + "-" + lang;
            tmps = (appDB.TemplateRow[])this.myTemplateDT.Select("LetterName='" + LetterName + "-" + office + "'");
            if (tmps.Length > 0)
                return tmps[0];

            //just office
            tmps = (appDB.TemplateRow[])this.myTemplateDT.Select("LetterName='" + LetterName + "-" + myA.OfficeLoggedOn.OfficeCode + "'");
            if (tmps.Length > 0)
                return tmps[0];

            //nameParam + lang
            if (nameParam.Length > 0)
            {

                string prov = nameParam.ToUpper() + "-" + lang;
                tmps = (appDB.TemplateRow[])this.myTemplateDT.Select("LetterName='" + LetterName + "-" + prov + "'");
                if (tmps.Length > 0)
                {
                    return tmps[0];
                }
                else
                {

                    //name param only
                    tmps = (appDB.TemplateRow[])this.myTemplateDT.Select("LetterName='" + LetterName + "-" + nameParam + "'");
                    if (tmps.Length > 0)
                        return tmps[0];
                }
            }

            //lang
            tmps = (appDB.TemplateRow[])this.myTemplateDT.Select("LetterName='" + LetterName + "-" + lang + "'");
            if (tmps.Length > 0)
                return tmps[0];


            tmps = (appDB.TemplateRow[])this.myTemplateDT.Select("LetterName='" + LetterName + "'");
            if (tmps.Length > 0)
                return tmps[0];
            else
                return null;

        }



        public void ChangeTemplateCode(string oldCode, string newCode)
        {
            //update templates with same base
            lmDatasets.appDB.TemplateRow[] trs = (lmDatasets.appDB.TemplateRow[])myTemplateDT.Select("LetterName='" + oldCode + "' or LetterName like '" + oldCode + "-%'");
            foreach (lmDatasets.appDB.TemplateRow tr in trs)
            {
                tr.LetterName = tr.LetterName.Replace(oldCode, newCode);
            }

            //update acfields where it is used
            lmDatasets.ActivityConfig.ActivityFieldRow[] afrs = (lmDatasets.ActivityConfig.ActivityFieldRow[])myA.acMng.DB.ActivityField.Select("FieldName='TemplateCode' and (DefaultValue='" + oldCode + "' or DefaultValue like '" + oldCode + "-%')");
            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in afrs)
            {
                afr.DefaultValue = afr.DefaultValue.Replace(oldCode, newCode);
            }

            atLogic.BusinessProcess bp = myA.GetBP();
            bp.AddForUpdate(this);
            bp.AddForUpdate(myA.acMng.GetActivityField());
            bp.Update();
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            lmDatasets.appDB.TemplateRow tr = (lmDatasets.appDB.TemplateRow)row;

            switch (dc.ColumnName)
            {
                case TemplateFields.LetterDescEng:
                    tr.FlagForExport = true;
                    docDB.DocumentRow doc = GetTemplateDoc(tr);
                    doc.efSubject = String.Format("({0}) {1}", tr.LetterName, tr.LetterDescEng);
                    doc.EndEdit();
                    break;
                case "AboutAgent":
                case "AboutDebtor":
                case "Agent":
                case "DocID":
                case "ExportedDate":
                case "HQ":
                case "LetterDescFre":
                case "LayoutStyle":
                case "Obsolete":
                case "ReadOnly":
                    tr.FlagForExport = true;
                    break;

                case "LetterName":

                    tr.FlagForExport = true;
                    break;

            }
        }
        protected override void AfterAdd(DataRow row)
        {

            lmDatasets.appDB.TemplateRow tr = (lmDatasets.appDB.TemplateRow)row;
            string ObjectName = this.myTemplateDT.TableName;

            tr.TemplateId = this.myA.PKIDGet(ObjectName, 1);
            tr.AboutAgent = true;
            tr.AboutDebtor = true;
            tr.Agent = true;
            tr.HQ = true;
            tr.ReadOnly = false;
            tr.Obsolete = false;
            tr.FlagForExport = false;

            lmDatasets.docDB.DocumentRow dr = (lmDatasets.docDB.DocumentRow)FM.GetDocMng().GetDocument().Add(FM.CurrentFile);
            FM.GetDocMng().GetDocContent().Add(dr);
            dr.efSubject = FM.AtMng.AppMan.AppName + " Template";
            dr.IsDraft = true;
            dr.DocContentRow.Ext = ".rtf";
            tr.DocID = dr.DocId;
        }

        public void GenLetter(docDB.DocumentRow doc, FileManager fm, string letterName, Dictionary<string, DataView> relTables)
        {
            _GenLetter(doc, fm, letterName, relTables, null);
        }


        public docDB.DocumentRow GetTemplateDoc(appDB.TemplateRow drTemplate)
        {
            //search through template folders
            //load document row for template
            docDB.DocumentRow[] templateDoc;

            //templateDoc = myA.GetFile().GetDocMng().GetDocument().LoadByFileIdAndDocName(myA.DocPath, drTemplate.Filename); 
            if (!drTemplate.IsDocIDNull())
            {
                templateDoc = (docDB.DocumentRow[])FM.GetDocMng().DB.Document.Select("DocId='" + drTemplate.DocID + "'");
                if (templateDoc.Length == 1)
                {
                    if (templateDoc[0].DocContentRow == null)
                        FM.GetDocMng().GetDocContent().Load(drTemplate.DocID, templateDoc[0].CurrentVersion);

                    return templateDoc[0];
                }
                else if (templateDoc.Length == 0)
                {
                    return null;
                }
                else
                {
                    templateDoc = (docDB.DocumentRow[])FM.GetDocMng().DB.Document.Select("DocId='" + drTemplate.DocID + "'");
                    FM.GetDocMng().GetDocument().Load(drTemplate.DocID);
                    FM.GetDocMng().GetDocContent().Load(drTemplate.DocID, templateDoc[0].CurrentVersion);

                    return templateDoc[0];
                }
            }
            else
                return null;

        }

        private void _GenLetter(docDB.DocumentRow newDoc, FileManager fm, string letterName, Dictionary<string, DataView> relTables, System.Collections.Hashtable QueryString)
        {
            lang = newDoc.LanguageCode;

            //let's change this function to get the template using the documents object
            //we only need to get the template into a stringreader/textreader so we don't need to write it to disk

            //load template definition
            //JLL 2012-06-15: modified Load to include debtor province code parameter for loading province specific template based on debtor province code and not logged on agent province code
            appDB.TemplateRow drTemplate;
            drTemplate = GetTemplateFromBaseName(fm, letterName);

            if (newDoc.IsefSubjectNull() || newDoc.efSubject == "" || newDoc.efSubject == "New document")
            {
                if (newDoc.LanguageCode == "E")
                    newDoc.efSubject = drTemplate.LetterDescEng.ToString();
                else
                    newDoc.efSubject = drTemplate.LetterDescFre.ToString();
            }

            docDB.DocumentRow templateDoc = GetTemplateDoc(drTemplate);
            string templateText = templateDoc.DocContentRow.ContentsAsText;


            //handle letterhead if present
            if (!drTemplate.IsLetterHeadNameNull())
            {
                appDB.TemplateRow drLH;
                drLH = GetTemplateFromBaseName(fm, drTemplate.LetterHeadName);

                docDB.DocumentRow LHDoc = GetTemplateDoc(drLH);
                string LHText = LHDoc.DocContentRow.ContentsAsText;
                newDoc.DocContentRow.Ext = LHDoc.ext;

                templateText = HandleBodyTag(fm, templateText, LHText,templateDoc.ext);
            }
            else
            {
                newDoc.DocContentRow.Ext = templateDoc.ext;

            }

            switch (newDoc.DocContentRow.Ext.ToLower())
            {
                case ".rtf":
                    PARAG = @"\par ";
                    break;
                case ".html":
                case ".htm":
                    //case ".mht":
                    PARAG = @"<br />";
                    break;
                default:
                    PARAG = "\r\n";
                    break;
            }

            string newDocText = Parse(fm, relTables, templateText, newDoc.DocContentRow.Ext.ToLower());

            newDoc.DocContentRow.ContentsAsText = newDocText;
            newDoc.TemplateId = drTemplate.TemplateId;
            //newDoc.SettemplateCodeNull();  moved to document before update to prevent required field issues in the wizard

            if (!drTemplate.IsDocTypeNull() && (newDoc.IsefTypeNull() || newDoc.efType == "MEM")) //only update if efType is the default value
                newDoc.efType = drTemplate.DocType;

            //newDoc.DocContentRow.Ext = ".rtf";


        }

        public appDB.TemplateRow GetTemplateFromBaseName(FileManager fm, string letterName)
        {
            appDB.TemplateRow drTemplate;
            if (fm.GetSSTMng() != null && fm.GetSSTMng().DB.SSTCase.Rows.Count == 1)
            {
                //SST method
                string level = "GD";
                string prog = "EI";
                SST.SSTCaseRow sstr = fm.GetSSTMng().DB.SSTCase[0];
                if (sstr.AppealLevelID > 1)
                    level = "AD";
                if (sstr.ProgramId != 3)
                    prog = "IS";

                drTemplate = Load(letterName, level + "-" + prog);
                if (drTemplate == null)
                    drTemplate = Load(letterName, level);
            }
            else //clas method
            {
                if (fm.CurrentFile.IsOpponentIDNull())
                    drTemplate = this.Load(letterName, "");
                else
                {
                    CLAS.DebtorRow debtorRow = (CLAS.DebtorRow)fm.GetCLASMng().GetDebtor().FindLoad(fm.CurrentFile.OpponentID);
                    if (debtorRow.AddressNotCurrent || debtorRow.IsAddressCurrentIDNull())
                        drTemplate = this.Load(letterName, "");
                    else
                    {
                        atriumDB.AddressRow debtorAddressRow = (atriumDB.AddressRow)fm.GetAddress().Load(debtorRow.AddressCurrentID);
                        if (debtorAddressRow.IsProvinceCodeNull())
                        {
                            drTemplate = this.Load(letterName, "");
                        }
                        else
                        {
                            drTemplate = this.Load(letterName, debtorAddressRow.ProvinceCode);
                        }
                    }
                }
            }
            if (drTemplate == null)
                throw new AtriumException("Template, {0}, not found.", letterName);
            return drTemplate;
        }

        public string PreParseVerify(string templateText)
        {
            string TemplateXsl = Merge(templateText);
            return TemplateXsl;
        }

        System.Globalization.CultureInfo myCult = new System.Globalization.CultureInfo("en-US");

        internal string Parse(FileManager fm, Dictionary<string, DataView> relTables, string templateText,string templateFormat)
        {


            //replace include tags with referenced templates
            string afterIncludes = HandleIncludes(fm, templateText, templateFormat);

            //replace tags with xsl
            string xsl = Merge(afterIncludes);

            //load template into textreader
            StringReader xReader = new StringReader(xsl);

            System.Xml.XmlTextReader xrdr = new System.Xml.XmlTextReader(xReader);
            System.Xml.Xsl.XslCompiledTransform xTran = new System.Xml.Xsl.XslCompiledTransform();

            xTran.Load(xrdr);

            //get culture for lang
            myCult = new System.Globalization.CultureInfo("en-US");
            if (lang == "F")
            {
                myCult = new System.Globalization.CultureInfo("fr-CA");
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            // begin write


            System.IO.StringWriter sw = new System.IO.StringWriter(sb);

            XmlTextWriter xw = new XmlTextWriter(sw);

            xw.WriteRaw(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
            xw.WriteStartElement("atriumDB");

            xw.WriteStartElement("Special");
            string dtFmt = "yyyy/MM/dd";
            if (myCult.Name == "en-US")
            {
                dtFmt = "MMMM d, yyyy";
            }
            else
            {
                dtFmt = "d MMMM yyyy";
            }
            xw.WriteElementString("Today", DateTime.Today.ToString(dtFmt, myCult));
            xw.WriteElementString("Plus30day", DateTime.Today.AddDays(30).ToString(dtFmt, myCult));
            xw.WriteElementString("Time", DateTime.Now.ToString("t", myCult));
            xw.WriteElementString("PreviousQuarterStartDate", atDates.StandardDate.LastQuarter.BeginDate.ToString(dtFmt));
            xw.WriteElementString("PreviousQuarterEndDate", atDates.StandardDate.LastQuarter.EndDate.ToString(dtFmt));
            xw.WriteElementString("CurrentQuarterStartDate", atDates.StandardDate.ThisQuarter.BeginDate.ToString(dtFmt));
            xw.WriteElementString("CurrentQuarterEndDate", atDates.StandardDate.ThisQuarter.EndDate.ToString(dtFmt));
            xw.WriteElementString("NextQuarterStartDate", atDates.StandardDate.NextQuarter.BeginDate.ToString(dtFmt));
            xw.WriteElementString("NextQuarterEndDate", atDates.StandardDate.NextQuarter.EndDate.ToString(dtFmt));
            xw.WriteEndElement();


            atriumDB.EFileRow drFile = fm.CurrentFile;
            WriteRows(new DataRow[] { drFile }, xw, "File");


            officeDB.OfficerRow[] drsOfficerWorkingAs = new officeDB.OfficerRow[1] { myA.WorkingAsOfficer };
            WriteRows(drsOfficerWorkingAs, xw, "Officer");

            //jll added on 2015-1-21 - always provide for access to officerloggedon
            officeDB.OfficerRow[] drsOfficerLoggedOn = new officeDB.OfficerRow[1] { myA.OfficerLoggedOn };
            WriteRows(drsOfficerLoggedOn, xw, "OfficerLoggedOn");

            //CJW new on aug 20 2009
            if (myA.WorkingAsOfficer.OfficeRow == null)
                myA.OfficeMng.GetOffice().Load(myA.WorkingAsOfficer.OfficeId);

            officeDB.OfficeRow[] drOfficeWorkingAs = new officeDB.OfficeRow[1] { myA.WorkingAsOfficer.OfficeRow };
            WriteRows(drOfficeWorkingAs, xw, "OfficeWorkingAs");
            WriteRows(new atriumDB.AddressRow[1] { FM.GetAddress().Load(myA.WorkingAsOfficer.OfficeRow.AddressId) }, xw, "OfficeWorkingAsAddress");


            foreach (string key in relTables.Keys)
            {
                WriteRows(relTables[key], xw, key);
            }


            xw.WriteEndElement();

            System.IO.StringReader sr = new System.IO.StringReader(sb.ToString());
            System.Xml.XmlTextReader xr = new XmlTextReader(sr);


            System.Text.StringBuilder sbOut = new System.Text.StringBuilder();
            StringWriter stringW = new StringWriter(sbOut);


            XmlTextWriter xwrite = new XmlTextWriter(stringW);//, System.Text.Encoding.GetEncoding("ISO-8859-1"));

            xTran.Transform(xr, xwrite);
            xr.Close();
            xwrite.Close();

            xrdr.Close();

            string rtfIn = sbOut.ToString();

            rtfIn = HandleSUB(rtfIn);

            string start = "((rtf:";


            if (rtfIn.IndexOf(start, 0) == -1)
                return rtfIn;
            else
                return HandleRTF(rtfIn);


        }
        private string HandleBodyTag(FileManager fm, string templateText, string LHText,string templateFormat)
        {

            templateText=HandleIncludes(fm, templateText, templateFormat);

            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            tc.CreateControl();
            tc.Text = "";
            tc.Append(LHText, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
            tc.Select(1, 0);


            tc.Find("[include:BODY]");

           
            switch (templateFormat.ToLower())
            {
                case ".rtf":
                    tc.Selection.Load(templateText, TXTextControl.StringStreamType.RichTextFormat);
                    break;
                case ".txt":
                    tc.Selection.Load(templateText, TXTextControl.StringStreamType.PlainText);
                    break;
                case ".htm":
                case ".html":
                    
                    tc.Selection.Load(templateText, TXTextControl.StringStreamType.HTMLFormat);
                    break;
            }





            string contentsRTF;
            tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
            return contentsRTF;

        }
        private string HandleIncludes(FileManager fm, string templateText,string templateFormat)
        {

            if (templateText.IndexOf("[include:", 0) == -1)
                return templateText;
            else
            {
                bool useTC = false;
                string contentsRTF=templateText;
                TXTextControl.TextControl tc = new TXTextControl.TextControl();
                tc.CreateControl();
                tc.Text = "";

                switch (templateFormat.ToLower())
                {
                    case ".rtf":
                        tc.Append(templateText, TXTextControl.StringStreamType.RichTextFormat, TXTextControl.AppendSettings.StartWithNewParagraph);
                        tc.Select(1, 0);
                        useTC = true;
                        break;
                    case ".txt":
                        
                        break;
                    case ".htm":
                    case ".html":

                        
                        break;
                }



                bool ok = true;
                int pos1 = 0;
                string start = "[include:";
                string end = "]";
                do
                {
                    //replace with appropriate rtf text
                    //tag will look like this ((rtf:Provision:12345:ProvisionTextEng))
                    //     tc.Find("[include:INC_TAG]");

                    pos1 = templateText.IndexOf(start, pos1);
                    if (pos1 == -1)
                        break;
                    int pos2 = templateText.IndexOf(end, pos1);

                    string fullTag = templateText.Substring(pos1, pos2 - pos1 + 1);


                    string letterName = fullTag.Replace(start, "").Replace(end, "");
                    appDB.TemplateRow drTemplate = GetTemplateFromBaseName(fm, letterName);



                    docDB.DocumentRow templateDoc = GetTemplateDoc(drTemplate);
                    string rtfInclude = templateDoc.DocContentRow.ContentsAsText; ;

                    //this des not account for different formats of include templates in the same document
                    switch (templateDoc.ext.ToLower())
                    {
                        case ".rtf":
                            tc.Find(fullTag);
                            tc.Selection.Load(rtfInclude, TXTextControl.StringStreamType.RichTextFormat);
                            //   System.Windows.Forms.Clipboard.SetText(rtfInclude, System.Windows.Forms.TextDataFormat.Rtf);
                            //   tc.Paste(TXTextControl.ClipboardFormat.RichTextFormat);
                            break;
                        case ".txt":
                            contentsRTF = contentsRTF.Replace(fullTag, rtfInclude);
                            break;
                        case ".htm":
                        case ".html":

                            contentsRTF = contentsRTF.Replace(fullTag, rtfInclude);
                            break;
                    }

                    templateText = templateText.Replace(fullTag, "XXXXXXXXXXXXXXXXXXXXXX");
                } while (ok);




                if(useTC)
                    tc.Save(out contentsRTF, TXTextControl.StringStreamType.RichTextFormat);
                return contentsRTF;
            }
        }
        private string HandleSUB(string rtfIn)
        {
            string rtfOut = rtfIn;


            //find all remaining rtf tags
            bool ok = true;
            int pos1 = 0;
            do
            {
                //replace with appropriate rtf text
                //tag will look like this ((rtf:Provision:12345:ProvisionTextEng))
                string start = "((sub:";
                string end = "))";
                pos1 = rtfIn.IndexOf(start, pos1);
                if (pos1 == -1)
                    break;
                int pos2 = rtfIn.IndexOf(end, pos1);

                string fullTag = rtfIn.Substring(pos1, pos2 - pos1 + 2);
                string selectVal = new string(fullTag.Where(c => !char.IsControl(c)).ToArray());
                string[] tagParts = selectVal.Split(new Char[] { ':' });
                string rtf = "";

                tagParts[3] = tagParts[3].Replace("))", "");
                if (tagParts[2].ToString() == "")
                { rtf = ""; }
                else
                {

                    int id = 0;
                    switch (tagParts[1])
                    {
                        case "Provision":
                            id = System.Convert.ToInt32(tagParts[2]);
                            rtf = myA.DB.Provision.FindByProvisionId(id)[tagParts[3].ToString()].ToString();
                            break;
                        case "Issue":
                            id = System.Convert.ToInt32(tagParts[2]);
                            rtf = myA.DB.Issue.FindByIssueId(id)[tagParts[3].ToString()].ToString();
                            break;
                        default:
                            //TFS#54684 CJW 2013-08-28  Added support for code table lookups
                            DataTable dt = myA.GetFile().Codes(tagParts[1]);
                            if (dt.PrimaryKey[0].DataType.Name == "Int32")
                                rtf = dt.Select(dt.PrimaryKey[0].ColumnName + "=" + tagParts[2].ToString())[0][tagParts[3].ToString()].ToString();
                            else
                                rtf = dt.Select(dt.PrimaryKey[0].ColumnName + "='" + tagParts[2].ToString() + "'")[0][tagParts[3].ToString()].ToString();
                            break;
                    }
                }

                rtfOut = rtfOut.Replace(fullTag, rtf);
                pos1++;

            } while (ok);

            return rtfOut;
        }


        private string HandleRTF(string rtfIn)
        {
            string rtfOut = rtfIn;

            TXTextControl.TextControl tc = new TXTextControl.TextControl();
            tc.CreateControl();

            tc.Text = rtfIn;
            //tc.Load(rtfIn, TXTextControl.StringStreamType.PlainText);

            //find all remaining rtf tags
            bool ok = true;
            int pos1 = 0;
            do
            {
                //replace with appropriate rtf text
                //tag will look like this ((rtf:Provision:12345:ProvisionTextEng))
                string start = "((rtf:";
                string end = "))";
                pos1 = rtfIn.IndexOf(start, pos1);
                if (pos1 == -1)
                    break;
                int pos2 = rtfIn.IndexOf(end, pos1);

                string fullTag = rtfIn.Substring(pos1, pos2 - pos1 + 2);
                string selectVal = new string(fullTag.Where(c => !char.IsControl(c)).ToArray());
                string[] tagParts = selectVal.Split(new Char[] { ':' });

                string rtf = "";

                tagParts[3] = tagParts[3].Replace("))", "");
                tc.Find(fullTag);
                if (tagParts[2].ToString() == "")
                { rtf = ""; }
                else
                {

                    int id = 0;
                    switch (tagParts[1])
                    {
                        case "Provision":
                            id = System.Convert.ToInt32(tagParts[2]);
                            rtf = myA.DB.Provision.FindByProvisionId(id)[tagParts[3].ToString()].ToString();
                            break;
                        case "Issue":
                            id = System.Convert.ToInt32(tagParts[2]);
                            rtf = myA.DB.Issue.FindByIssueId(id)[tagParts[3].ToString()].ToString();
                            break;
                        default:
                            //TFS#54684 CJW 2013-08-28  Added support for code table lookups
                            DataTable dt = myA.GetFile().Codes(tagParts[1]);
                            rtf = dt.Select(dt.PrimaryKey[0].ColumnName + "='" + tagParts[2].ToString() + "'")[0][tagParts[3].ToString()].ToString();
                            break;
                    }
                }
                //merge using textcontrol
                if (rtf.StartsWith(DocContentBE.RTF.Substring(0, 5)))
                {

                    //tc.Selection.Load(rtf, TXTextControl.StringStreamType.RichTextFormat);
                    tc.Selection.Text = rtf;
                }
                else
                {
                    tc.Selection.Load(rtf, TXTextControl.StringStreamType.PlainText);
                }
                pos1++;

            } while (ok);

            return tc.Text;
        }

        /// <summary>
        /// Generates documents from templates
        /// </summary>
        /// <param name="fm">A filemanager object</param>
        /// <param name="letterName">The name of the template</param>
        /// <param name="QueryString">A collection of parameters for the template</param>
        /// <returns></returns>
        public docDB.DocumentRow GenLetter(FileManager fm, string letterName, System.Collections.Hashtable QueryString)
        {
            //create a new document record
            docDB.DocumentRow newDoc = (docDB.DocumentRow)fm.GetDocMng().GetDocument().Add(fm.CurrentFile);
            fm.GetDocMng().GetDocContent().Add(newDoc);

            _GenLetter(newDoc, fm, letterName, null, QueryString);

            return newDoc;
        }

        //public string GetFileName(atriumDB.EFileRow drFile, appDB.TemplateRow drTemplate)
        //{
        //    if ( drFile.IsFullPathNull())
        //    {
        //        officeDB.OfficeRow drOffice = myA.OfficeMng.DB.Office.FindByOfficeId(drFile.LeadOfficeId);

        //        //@"\Output\" +
        //        return  drOffice.OfficeCode + "_" + drTemplate.LetterName + "_" + DateTime.Today.ToString("yyyyMMdd") + "_" + myDAL.DAL.PKIDGet("Letters", 1).ToString() + ".rtf";
        //    }
        //    else
        //    {
        //        //string folder = drFile.FullPath;

        //        //get count of files for today
        //        string fileName = DateTime.Today.ToString("yyyy-MM-dd");
        //        int count = 0;// System.IO.Directory.GetFiles(folder, fileName + "*").Length + 1;
        //        fileName += " " + count.ToString("00") + " " + drTemplate.LetterDescEng + ".rtf";
        //        //string path = @"\efiles" + folder + fileName;
        //        return fileName;
        //    }
        //}
        private string Merge(string rtfData)
        {

            //escape & characters in the rtf
            rtfData = rtfData.Replace("&", "<![CDATA[&]]>");

            // This function requires that the begin begin tag [value: is correctly typed, any ommision will crash the program

            string endText = @"</xsl:text>";
            string startText = @"<xsl:text disable-output-escaping=""yes"">";

            string sPrefix = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                              <xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" version=""2.0"">
                                                              <xsl:output method=""text""/>
                                                              <xsl:preserve-space elements=""*"" />
                                                              <xsl:template match=""atriumDB"">
                                                              " + startText;
            switch (PARAG)
            {
                case "<br />":
                    endText = "";
                    startText = "";

                    sPrefix = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                                              <xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" version=""2.0"">
                                                              <xsl:output method=""html""/>
                                                              <xsl:preserve-space elements=""*"" />
                                                              <xsl:template match=""atriumDB"">
                                                              " + startText;
                    break;
                default:
                    break;
            }

            string valuePrefix = "[value:";
            string valueSuffix = "]";
            string valuePrefixXSL = endText + @"<xsl:choose><xsl:when test=""//";
            string valueSuffixXSL = @"""><xsl:value-of select=""//";
            string valueSuffix1 = @""" disable-output-escaping=""yes"" /></xsl:when><xsl:otherwise>";
            string valueSuffix2 = @"</xsl:otherwise></xsl:choose>" + startText;


            string nvaluePrefix = "[nvalue:";
            string nvalueSuffix = "]";
            string nvaluePrefixXSL = endText + @"<xsl:choose><xsl:when test=""//";
            string nvalueSuffixXSL = @"!=''""><xsl:text>\par </xsl:text><xsl:value-of select=""//";
            string nvalueSuffix1 = @""" disable-output-escaping=""yes"" /></xsl:when><xsl:otherwise>";
            string nvalueSuffix2 = @"</xsl:otherwise></xsl:choose>" + startText;


            string repeatPrefix = "[repeat:";
            string repeatSuffix = "]";
            string repeatPrefixXSL = endText + @"<xsl:for-each select=""";
            string repeatSuffixXSL = @""">" + startText;

            string repeatEnd = "[end repeat]";
            string repeatEndXSL = endText + @"</xsl:for-each>" + startText;

            string counter = "[special:counter]";
            string counterXSL = endText + @"<xsl:number />" + startText;

            //if tag
            string ifPrefix = "[if:";
            string ifSuffix = "]";
            string ifPrefixXSL = endText + @"<xsl:choose><xsl:when test=""//";
            string ifSuffixXSL = @""">" + startText;

            string elseTag = "[else]";
            string elseXsl = endText + @"</xsl:when><xsl:otherwise>" + startText;

            string ifEnd = "[endif]";
            string ifEndXSL = endText + @"</xsl:otherwise></xsl:choose>" + startText;


            string sSuffix = endText + @"</xsl:template></xsl:stylesheet>";

            int position = 0;
            int posEndTag = 0;
            bool inRepeat = false;
            string repeatValue = "";
            string prefix = "";
            int position1;
            int position2;
            string selectVal;
            string selectValWithTags;

            Regex pattern1 = new Regex(Regex.Escape(valuePrefix));
            Regex pattern2 = new Regex(Regex.Escape(valueSuffix));

            while (rtfData.IndexOf("[", position) != -1)
            {
                position = rtfData.IndexOf("[", position);
                posEndTag = rtfData.IndexOf("]", position);
                prefix = rtfData.Substring(position + 1, posEndTag - position - 1);

                if (prefix.IndexOf(":", 1) != -1)
                    prefix = prefix.Substring(0, prefix.IndexOf(":", 0));
                else if (prefix.IndexOf(" ", 1) != -1)
                    prefix = prefix.Substring(0, prefix.IndexOf(" ", 0));

                switch (prefix)
                {
                    case "special":

                        string prefix1 = rtfData.Substring(position + 1, posEndTag - position - 1);
                        string specialNode = prefix1.Substring(prefix1.IndexOf(":", 0) + 1);
                        if (specialNode == "counter")
                            rtfData = Regex.Replace(rtfData, Regex.Escape(counter), counterXSL);
                        //else if (specialNode == "date")
                        // rtfData = Regex.Replace(rtfData, Regex.Escape(dateNow), dateNowXSL);

                        position = posEndTag + 1;
                        break;
                    case "value":
                        position1 = rtfData.IndexOf(valuePrefix, position);
                        position2 = rtfData.IndexOf(valueSuffix, position1);
                        selectVal = rtfData.Substring(position1 + valuePrefix.Length, position2 - position1 - valuePrefix.Length);
                        selectValWithTags = rtfData.Substring(position1, position2 - position1 + 1);

                        selectVal=new string(selectVal.Where(c =>!char.IsControl(c)).ToArray());
                        pattern1 = new Regex(Regex.Escape(valuePrefix));
                        pattern2 = new Regex(Regex.Escape(valueSuffix));

                        rtfData = pattern1.Replace(rtfData, valuePrefixXSL, 1, position);
                        rtfData = pattern2.Replace(rtfData, valueSuffixXSL + selectVal + valueSuffix1 + "" + valueSuffix2, 1, position);
                        position = rtfData.IndexOf(valueSuffix2, position) + 1;

                        // replace repeatEnd if in repeat
                        //rtfData = Regex.Replace(rtfData, Regex.Escape("//" + repeatValue + "/"), "");
                        if (inRepeat)
                        {
                            pattern1 = new Regex(@"//" + repeatValue + @"/");
                            int ln = rtfData.Length;
                            rtfData = pattern1.Replace(rtfData, "");
                            position = position - (ln - rtfData.Length);
                        }
                        break;

                    case "nvalue":

                        position1 = rtfData.IndexOf(nvaluePrefix, position);
                        position2 = rtfData.IndexOf(nvalueSuffix, position1);
                        selectVal = rtfData.Substring(position1 + nvaluePrefix.Length, position2 - position1 - nvaluePrefix.Length);
                        selectValWithTags = rtfData.Substring(position1, position2 - position1 + 1);

                        selectVal = new string(selectVal.Where(c => !char.IsControl(c)).ToArray());

                        pattern1 = new Regex(Regex.Escape(nvaluePrefix));
                        pattern2 = new Regex(Regex.Escape(nvalueSuffix));

                        rtfData = pattern1.Replace(rtfData, nvaluePrefixXSL, 1, position);
                        rtfData = pattern2.Replace(rtfData, nvalueSuffixXSL + selectVal + nvalueSuffix1 + "" + nvalueSuffix2, 1, position);
                        position = rtfData.IndexOf(nvalueSuffix2, position) + 1;


                        // replace repeatEnd if in repeat
                        if (inRepeat)
                        {
                            pattern1 = new Regex(@"//" + repeatValue + @"/");
                            int ln = rtfData.Length;
                            rtfData = pattern1.Replace(rtfData, "");
                            position = position - (ln - rtfData.Length);
                        }
                        break;

                    case "repeat":
                        inRepeat = true;
                        int position3 = rtfData.IndexOf(repeatPrefix, position);
                        int position4 = rtfData.IndexOf(repeatSuffix, position3);
                        repeatValue = rtfData.Substring(position3 + repeatPrefix.Length, position4 - position3 - repeatSuffix.Length - repeatPrefix.Length + 1);

                        position = position3;// rtfData.IndexOf(repeatPrefix, position);
                        Regex pattern3 = new Regex(Regex.Escape(repeatPrefix));
                        Regex pattern4 = new Regex(Regex.Escape(repeatSuffix));

                        rtfData = pattern3.Replace(rtfData, repeatPrefixXSL, 1, position);
                        rtfData = pattern4.Replace(rtfData, repeatSuffixXSL, 1, position);

                        break;

                    case "end":
                        inRepeat = false;
                        rtfData = Regex.Replace(rtfData, Regex.Escape(repeatEnd), repeatEndXSL);
                        position++;
                        break;

                    case "if":
                        position1 = rtfData.IndexOf(ifPrefix, position);
                        position2 = rtfData.IndexOf(ifSuffix, position1);
                        selectVal = rtfData.Substring(position1 + ifPrefix.Length, position2 - position1 - ifPrefix.Length);
                        selectValWithTags = rtfData.Substring(position1, position2 - position1 + 1);

                        selectVal = new string(selectVal.Where(c => !char.IsControl(c)).ToArray());

                        pattern1 = new Regex(Regex.Escape(ifPrefix));
                        pattern2 = new Regex(Regex.Escape(ifSuffix));

                        rtfData = pattern1.Replace(rtfData, ifPrefixXSL, 1, position);
                        rtfData = pattern2.Replace(rtfData, ifSuffixXSL, 1, position);
                        position = rtfData.IndexOf(ifSuffixXSL, position) + 1;

                        // replace repeatEnd if in repeat
                        //rtfData = Regex.Replace(rtfData, Regex.Escape("//" + repeatValue + "/"), "");
                        //if (inRepeat)
                        //{
                        //    pattern1 = new Regex(@"//" + repeatValue + @"/");
                        //    rtfData = pattern1.Replace(rtfData, "", 2);
                        //}
                        break;
                    case "else":

                        rtfData = Regex.Replace(rtfData, Regex.Escape(elseTag), elseXsl);
                        position++;
                        break;
                    case "endif":

                        rtfData = Regex.Replace(rtfData, Regex.Escape(ifEnd), ifEndXSL);
                        position++;
                        break;
                    default:
                        //myA.RaiseError((int)AtriumEnum.AppErrorCodes.LetterInvalidLetter);
                        position++;
                        break;

                }


            }
            rtfData = Regex.Replace(rtfData, Regex.Escape("//" + repeatValue + "/"), "");
            //System.Diagnostics.Debug.WriteLine(" with1 " + sPrefix + rtfData + sSuffix + "\n");
            //System.Diagnostics.Debug.WriteLine(" with " + Regex.Escape(sPrefix + rtfData + sSuffix));
            //System.Diagnostics.Debug.WriteLine(" first " + Regex.Escape(sPrefix + rtfData ) + sSuffix);
            //System.Diagnostics.Debug.WriteLine("second " + Regex.Escape(sPrefix) + Regex.Escape(rtfData) + Regex.Escape(sSuffix));

            //System.Diagnostics.Debug.WriteLine(sSuffix);
            //  rtfData = System.Security.SecurityElement.Escape(rtfData);

            return sPrefix + rtfData + sSuffix;
        }

        internal void WriteRows(System.Collections.ICollection drs, XmlTextWriter xwMem)
        {
            WriteRows(drs, xwMem, null);
        }

        internal void WriteRows(DataView dv, XmlTextWriter xwMem, string tableName)
        {
            foreach (DataRowView drv in dv)
            {
                WriteRow(drv.Row, xwMem, tableName);
            }
        }

        internal void WriteRow(DataRow dr, XmlTextWriter xwMem, string tableName)
        {
            if (tableName == null)
            {
                xwMem.WriteStartElement(dr.Table.TableName);
            }
            else
            {
                xwMem.WriteStartElement(tableName);
            }
            foreach (DataRelation dRel in dr.Table.ChildRelations)
            {
                if (dRel.Nested)
                {
                    foreach (DataRow drc in dr.GetChildRows(dRel))
                    {
                        WriteRow(drc, xwMem, tableName + drc.Table.TableName);
                    }

                }
            }
            foreach (DataColumn dc in dr.Table.Columns)
            {
                string columnName = dc.ColumnName;
                if (dc.ExtendedProperties.ContainsKey("FieldName"))
                    columnName = dc.ExtendedProperties["FieldName"].ToString();
                switch (dc.ColumnMapping)
                {
                    case MappingType.Element:
                        if (dc.DataType == System.Type.GetType("System.Boolean"))
                        {
                            if (dr.IsNull(dc))
                            {
                                xwMem.WriteElementString(columnName, "false");
                            }
                            else if ((bool)dr[dc])
                            {
                                xwMem.WriteElementString(columnName, "true");
                            }
                            else
                            {
                                xwMem.WriteElementString(columnName, "false");
                            }
                        }
                        else if (dc.DataType == System.Type.GetType("System.DateTimeOffset"))
                        {
                            if (dr[dc].ToString().Length == 0)
                            {
                                xwMem.WriteElementString(columnName, "");
                            }
                            else
                            {
                                DateTimeOffset dto = (DateTimeOffset)dr[dc];
                                if (dc.ExtendedProperties.ContainsKey("format"))
                                {
                                    xwMem.WriteElementString(columnName, dto.ToString(dc.ExtendedProperties["format"].ToString(), myCult));
                                }
                                else
                                {
                                    if (myCult.Name == "en-US")
                                    {
                                        xwMem.WriteElementString(columnName, dto.ToString("MMMM d, yyyy", myCult));
                                    }
                                    else
                                    {
                                        xwMem.WriteElementString(columnName, dto.ToString("d MMMM yyyy", myCult));
                                    }
                                }
                            }
                        }
                        else if (dc.DataType == System.Type.GetType("System.DateTime"))
                        {
                            if (dr[dc].ToString().Length == 0)
                            {
                                xwMem.WriteElementString(columnName, "");
                            }
                            else
                            {
                                if (dc.ExtendedProperties.ContainsKey("format"))
                                {
                                    string val = Convert.ToDateTime(dr[dc]).ToString(dc.ExtendedProperties["format"].ToString(), myCult);
                                    if (dc.ExtendedProperties["format"].ToString() == "f")
                                        val += " " + TimeZoneInfo.Local.StandardName;
                                    xwMem.WriteElementString(columnName, val);
                                }
                                else
                                {
                                    //xwMem.WriteElementString(dc.ColumnName, Convert.ToDateTime(dr[dc]).ToString("yyyy/MM/dd"));
                                    if (myCult.Name == "en-US")
                                    {
                                        xwMem.WriteElementString(columnName, Convert.ToDateTime(dr[dc]).ToString("MMMM d, yyyy", myCult));
                                    }
                                    else
                                    {
                                        xwMem.WriteElementString(columnName, Convert.ToDateTime(dr[dc]).ToString("d MMMM yyyy", myCult));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dc.ExtendedProperties.ContainsKey("format") && !dr.IsNull(dc) && dr[dc].ToString().Length > 0)
                            {
                                xwMem.WriteElementString(columnName, Format(dr[dc], dc.ExtendedProperties["format"].ToString()));
                            }
                            //else if (dc.ExtendedProperties.ContainsKey("rtf") && !dr.IsNull(dc) && dr[dc].ToString().Length > 0)
                            //{


                            //    xwMem.WriteElementString(dc.ColumnName, Format(dr[dc], dc.ExtendedProperties["format"].ToString()));
                            //}

                            else
                            {
                                //                                                       xwMem.WriteStartElement(dc.ColumnName);
                                //                                                       xwMem.WriteRaw(dr[dc].ToString().Replace("\r\n",@"\par "));
                                //                                                       xwMem.WriteEndElement();
                                xwMem.WriteElementString(columnName, dr[dc].ToString().Replace("\r\n", PARAG));
                            }
                        }
                        break;
                    case MappingType.Attribute:
                        xwMem.WriteAttributeString(columnName, dr[dc].ToString());
                        break;
                    default:
                        break;
                }
            }
            xwMem.WriteEndElement();

        }
        internal void WriteRows(System.Collections.ICollection drs, XmlTextWriter xwMem, string tableName)
        {

            //xwMem.WriteAttributeString("xmlns:dt","urn:schemas-microsoft-com:datatypes");


            foreach (DataRow dr in drs)
            {
                WriteRow(dr, xwMem, tableName);
            }
        }

        public string Format(object val, string format)
        {
            //                    string temp=UnFormat(val.ToString());
            //                    return Convert.ToDecimal(temp).ToString(format);
            try
            {
                string temp = UnFormat(val.ToString(), format);
                if (format == "C")
                    return Convert.ToDecimal(temp).ToString("$#,##0.00;-$#,##0.00");
                else
                    return Convert.ToDecimal(temp).ToString(format, myCult);
            }
            catch
            {
                return val.ToString();
            }

        }

        public static string UnFormat(string val, string format)
        {
            //                    Regex pattern=new Regex(@"[\(\)-\ \+\$%]");

            //                    try
            //                    {
            //                           return Regex.Replace(val,@"[\(\)\ \+\$%-]","");
            //                    }
            //                    catch(Exception e)
            //                    {
            //                           System.Diagnostics.Trace.WriteLine(e.Message);
            //                           return val;
            //                    }
            //                    return pattern.Replace(val,"");
            //return val.Replace(,''); 

            try
            {
                switch (format)
                {
                    case "C":
                        return Regex.Replace(val, @"[\(\)\ \+\$%]", "");
                    default:
                        return Regex.Replace(val, @"[\(\)\ \+\$%-]", "");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                return val;
            }

        }



    }
}




