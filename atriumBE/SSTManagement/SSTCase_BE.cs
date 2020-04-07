using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class SSTCaseBE : atLogic.ObjectBE
    {
        SSTManager myA;
        SST.SSTCaseDataTable mySSTCaseDT;


        internal SSTCaseBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.SSTCase)
        {
            myA = pBEMng;
            mySSTCaseDT = (SST.SSTCaseDataTable)myDT;
            if (myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetSSTCase();

            this.mySSTCaseDT.DeemedDisabilityDateColumn.ExtendedProperties.Add("format", "MMMM yyyy");
            this.mySSTCaseDT.PaymentDateColumn.ExtendedProperties.Add("format", "MMMM yyyy");
            this.mySSTCaseDT.ApplicationDateColumn.ExtendedProperties.Add("format", "MMMM yyyy");
            this.mySSTCaseDT.OnsetDateColumn.ExtendedProperties.Add("format", "MMMM yyyy");
        }

        public atriumDAL.SSTCaseDAL myDAL
        {
            get
            {
                return (atriumDAL.SSTCaseDAL)myODAL;
            }
        }

        public SST.SSTCaseRow Load(int SSTCaseId)
        {
            try
            {
                Fill(myDAL.Load(SSTCaseId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(SSTCaseId));
            }
            CalcDates();

            return mySSTCaseDT.FindBySSTCaseId(SSTCaseId);
        }

        public void LoadByFileId(int FileId)
        {
            try
            {
                Fill(myDAL.LoadByFileId(FileId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByFileId(FileId));
            }
            CalcDates();

        }

        protected override void AfterAdd(DataRow row)
        {
            SST.SSTCaseRow dr = (SST.SSTCaseRow)row;
            string ObjectName = this.mySSTCaseDT.TableName;

            dr.SSTCaseId = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = myA.FM.CurrentFileId;
            dr.IgnoreLate = false;
            dr.IsLate = false;
            dr.ReceivedDate = DateTime.Today;
            dr.FileComplete = false;
            dr.CaseStatus = 1;
            dr.CaseStatusDate = DateTime.Today;
            dr.MaxRetroactivity = false;
            dr.Voluntary = false;
            dr.MQPAgreed = false;
            dr.NewFacts = false;
            dr.Disabled = false;
            dr.LeaveToAppealNotRequired = false;
            dr.HasMultipleApps = false;
            dr.IsCharter = false;
            dr.IsDeceased = false;
            dr.IsIncapacitated = false;
            dr.IsLate365 = false;
            dr.CopyDocs = false;
            dr.LateOverride = false;
            dr.ADReturnToGD = false;
        }

        protected override void AfterUpdate(DataRow dr)
        {
            SST.SSTCaseRow fcr = (SST.SSTCaseRow)dr;
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml; // fcr.EFileRow.FileStructXml;
            MyXml(fcr, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;

            //if (!fcr.IsCaseStatusDescEngNull() && !fcr.IsCaseStatusDescFreNull())
            //    EFileBE.XmlAddToc(myA.FM.CurrentFile, "sstcase", "SST Appeal (" + fcr.CaseStatusDescEng + ")", "Appel au TSS (" + fcr.CaseStatusDescFre + ")", 119);
            //else
            //    EFileBE.XmlAddToc(myA.FM.CurrentFile, "sstcase", "SST Appeal", "Appel au TSS", 119);
        }

        private int GetLateDays(SST.SSTCaseRow sstcaserow)
        {
            //if (!sstcaserow.IsOrigDecisionDateNull() && !sstcaserow.IsReceivedDateNull() && sstcaserow.OrigDecisionDate.AddDays(365) < sstcaserow.ReceivedDate)
            //{ return 365; }
            //now using filecomplete instead of receiveddate
            if (!sstcaserow.IsOrigDecisionDateNull() && !sstcaserow.IsAppealDateNull() && sstcaserow.OrigDecisionDate.AddDays(365) < sstcaserow.AppealDate)
            { return 365; }

            if (!sstcaserow.IsAppealLevelIDNull() && sstcaserow.AppealLevelID == 1)
            {
                if (IsEIProgram(sstcaserow))
                {
                    return myA.AtMng.GetSetting(AppIntSetting.EIDaysLate);
                }
                else if (!sstcaserow.IsProgramIdNull() && sstcaserow.ProgramId != 3)
                {
                    return myA.AtMng.GetSetting(AppIntSetting.ISDaysLate);
                }
            }
            else
            {
                if (IsEIProgram(sstcaserow))
                {
                    return myA.AtMng.GetSetting(AppIntSetting.EIAppDaysLate);
                }
                else if (!sstcaserow.IsProgramIdNull() && sstcaserow.ProgramId != 3)
                {
                    return myA.AtMng.GetSetting(AppIntSetting.ISAppDaysLate);
                }
            }
            return 10000;
        }

        public bool ReceivedComplete(SST.SSTCaseRow sstcaserow)
        {
            if (!sstcaserow.IsReceivedDateNull() && !sstcaserow.IsFileCompleteDateNull() && sstcaserow.FileCompleteDate == sstcaserow.ReceivedDate)
                return true;
            else if (sstcaserow.FileComplete && sstcaserow.RowState == DataRowState.Added)
                return true;
            else
                return false;
        }

        private bool IsLate(SST.SSTCaseRow sstcaserow)
        {
            //TODO move late days to program table?
            int days = GetLateDays(sstcaserow);

            //If it is an Appeal of a GD Summary Dismissal it can't be late
            if ((sstcaserow.LeaveToAppealNotRequired & sstcaserow.AppealLevelID == 2)|| sstcaserow.ADReturnToGD)
                return false;

            if (sstcaserow.FileComplete)
            {
                if (!sstcaserow.IsOrigDecisionDateNull() && !sstcaserow.IsAppealDateNull() && sstcaserow.OrigDecisionDate.AddDays(days) < sstcaserow.AppealDate)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            SST.SSTCaseRow sr = (SST.SSTCaseRow)dr;

            switch (dc.ColumnName)
            {
                case "AppealLevelID":
                    myA.FM.CurrentFile.Dim1Id = sr.AppealLevelID;
                    break;
                case "ProgramId":
                    myA.FM.CurrentFile.Dim2Id = sr.ProgramId;
                    break;
                case "CaseStatus":
                    sr.CaseStatusDate = DateTime.Today;
                    dr.EndEdit();
                    break;
                case "LowerFileId":
                    if (sr.RowState == DataRowState.Added && !sr.IsLowerFileIdNull())
                    {
                        CreateAppeal(sr.LowerFileId);
                    }
                    break;
                case "CopyDocs":
                    if (sr.CopyDocs && !sr.IsLowerFileIdNull())
                        CreateAppealDocs(sr.LowerFileId);
                    break;
                case "ReceivedDate":
                case "FileComplete":
                    if (sr.RowState == DataRowState.Added && sr.FileComplete && !sr.IsReceivedDateNull())
                    {
                        sr.FileCompleteDate = sr.ReceivedDate;
                        sr.AppealDate = sr.ReceivedDate;
                        HandleFileComplete(sr);
                    }
                    break;
                case "AppealDate":
                case "OrigDecisionDate":
                case "FileCompleteDate":
                    HandleFileComplete(sr);
                    break;
                case "OutcomeId":
                    //if (!sr.IsDecisionTypeNull() && sr.DecisionType == 1)
                    //{
                    foreach (SST.SSTCaseMatterRow scmr in sr.GetSSTCaseMatterRows())
                    {
                        if (scmr.IsOutcomeIdNull())
                        {
                            scmr.OutcomeId = sr.OutcomeId;
                            scmr.EndEdit();
                        }
                    }

                    //}
                    break;
            }
        }

        private void HandleFileComplete(SST.SSTCaseRow sr)
        {
            if (!sr.IsFileCompleteDateNull())
            {
                sr.FileComplete = true;
                //calculate new "AppealDate"
               //only use grace period if appeal was received after recon decision
                if (!sr.IsOrigDecisionDateNull() && sr.OrigDecisionDate <= sr.ReceivedDate)
                {
                    foreach (lmDatasets.SST.SSTRequestRow srr in myA.DB.SSTRequest)
                    {
                        //check type 16 request
                        if (srr.ReqType == 16)
                        {
                            if (sr.FileCompleteDate <= srr.DueDate)
                                sr.AppealDate = sr.ReceivedDate;
                        }
                    }

                }
                if (sr.IsAppealDateNull())
                    sr.AppealDate = sr.FileCompleteDate;

                if (!sr.IsOrigDecisionDateNull() && !sr.IsFileCompleteDateNull())
                    sr.IsLate365 = sr.OrigDecisionDate.AddDays(365) < sr.AppealDate;
                Late365daysWarning(sr);

                if (IsLate(sr))
                {
                    LateWarning(sr);
                    sr.IsLate = true;
                    sr.EndEdit();
                }
                else
                {
                    LateWarning(sr);
                    sr.IsLate = false;
                    sr.EndEdit();
                }
            }
            else
                sr.FileComplete = false;

            Calc365Deadline(sr);
        }

        private string[] GetAcronym()
        {
            string tzFre;
            string tzEng;
            string[] tzv = new string[2];

            switch (TimeZone.CurrentTimeZone.StandardName)
            {
                case "Eastern Standard Time":   // case "HEURE NORMALE DE L'EST":
                    tzFre = "HNE";
                    tzEng = "EST";
                    break;
                case "Newfoundland Standard Time": // case "HEURE NORMALE DE TERRE-NEUVE":
                    tzFre = "HNTN";
                    tzEng = "NST";
                    break;
                case "Atlantic Standard Time": // case "HEURE NORMALE DE L'ATLANTIQUE":
                    tzFre = "HNA";
                    tzEng = "AST";
                    break;
                case "Central Standard Time"://case "HEURE NORMALE DU CENTRE":
                    tzFre = "HNC";
                    tzEng = "CST";
                    break;
                case "Mountain Standard Time": // case "HEURE NORMALE DES ROCHEUSES":
                    tzFre = "HNR";
                    tzEng = "MST";
                    break;
                case "Pacific Standard Time":// case "HEURE NORMALE DU PACIFIQUE":
                    tzFre = "HNP";
                    tzEng = "PST";
                    break;
                default:
                    tzFre = TimeZoneInfo.Local.StandardName.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA"));
                    tzEng = TimeZoneInfo.Local.StandardName.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-CA"));
                    break;
            }
            tzv[0] = tzFre;
            tzv[1] = tzEng;
            return tzv;
        }

        public string[] GetAcronymTimeZoneLabel()
        {
            string[] tzv = new string[2];

            if (myA.AppMan.Language.ToUpper() == "FRE")
            {
                tzv = GetAcronym();
                return tzv;

            }
            else if (myA.AppMan.Language.ToUpper() == "ENG")
            {
                tzv = GetAcronym();
                return tzv;
            }
            else
            {
                tzv[0] = TimeZoneInfo.Local.StandardName.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA"));
                tzv[1] = TimeZoneInfo.Local.StandardName.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-CA"));
                return tzv;
            }
        }

        public void MyXml(SST.SSTCaseRow sstr, System.Xml.XmlDocument xd)
        {

            //special doc folders
            System.Xml.XmlElement xdoc = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='document' and @filter='true']");
            System.Xml.XmlElement xDocFilt;
            if (xdoc != null)
            {
                xdoc.InnerXml = "";
                if (sstr.AppealLevelID == 1)
                {
                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode='P1'");
                    xDocFilt.SetAttribute("titlee", "Part 1");
                    xDocFilt.SetAttribute("titlef", "Partie 1");
                    xDocFilt.SetAttribute("sort", "10");
                    xdoc.AppendChild(xDocFilt);

                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode='P2'");
                    xDocFilt.SetAttribute("titlee", "Part 2");
                    xDocFilt.SetAttribute("titlef", "Partie 2");
                    xDocFilt.SetAttribute("sort", "20");
                    xdoc.AppendChild(xDocFilt);

                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode is null");
                    xDocFilt.SetAttribute("titlee", "Internal");
                    xDocFilt.SetAttribute("titlef", "Interne");
                    xDocFilt.SetAttribute("sort", "30");
                    xdoc.AppendChild(xDocFilt);
                }
                else
                {
                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode='P1' and SourceDivision=1");
                    xDocFilt.SetAttribute("titlee", "GD - Part 1");
                    xDocFilt.SetAttribute("titlef", "GD - Partie 1");
                    xDocFilt.SetAttribute("sort", "10");
                    xdoc.AppendChild(xDocFilt);

                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode='P2' and SourceDivision=1");
                    xDocFilt.SetAttribute("titlee", "GD - Part 2");
                    xDocFilt.SetAttribute("titlef", "GD - Partie 2");
                    xDocFilt.SetAttribute("sort", "20");
                    xdoc.AppendChild(xDocFilt);

                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode='P1' and SourceDivision<>1");
                    xDocFilt.SetAttribute("titlee", "AD - Part 1");
                    xDocFilt.SetAttribute("titlef", "AD - Partie 1");
                    xDocFilt.SetAttribute("sort", "30");
                    xdoc.AppendChild(xDocFilt);

                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode='P2' and SourceDivision<>1");
                    xDocFilt.SetAttribute("titlee", "AD - Part 2");
                    xDocFilt.SetAttribute("titlef", "AD - Partie 2");
                    xDocFilt.SetAttribute("sort", "40");
                    xdoc.AppendChild(xDocFilt);

                    xDocFilt = xd.CreateElement("toc");
                    xDocFilt.SetAttribute("type", "document");
                    xDocFilt.SetAttribute("filter", "DocTypeMajorCode is null");
                    xDocFilt.SetAttribute("titlee", "AD - Internal");
                    xDocFilt.SetAttribute("titlef", "AD - Interne");
                    xDocFilt.SetAttribute("sort", "50");
                    xdoc.AppendChild(xDocFilt);
                }
            }

            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='sstcase' and @type='sstcase']");
            if (xe == null)
            {
                string sort = "109";
                xe = xd.CreateElement("toc");
                xe.SetAttribute("supertype", "sstcase");
                xe.SetAttribute("type", "sstcase");
                xe.SetAttribute("sort", sort);
                xe.SetAttribute("id", sstr.SSTCaseId.ToString());

                System.Xml.XmlElement xeAfter = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@sort>" + sort + "]");
                if (xeAfter == null)
                    xeAfter = (System.Xml.XmlElement)xd.SelectSingleNode("//fld[@sort>" + sort + "]");

                if (xeAfter == null)
                    xd.DocumentElement.AppendChild(xe);
                else
                    xd.DocumentElement.InsertBefore(xe, xeAfter);

            }

            xe.SetAttribute("titlee", "SST Appeal");
            xe.SetAttribute("titlef", "Appel au TSS");

            //if (!sstr.IsCaseStatusDescEngNull() && !sstr.IsCaseStatusDescFreNull())
            //{
            //    xe.SetAttribute("titlee", "SST Appeal (" + sstr.CaseStatusDescEng + ")");
            //    xe.SetAttribute("titlef", "Appel au TSS (" + sstr.CaseStatusDescFre + ")");
            //    if (sstr.CaseStatus == 2)//Hearing Scheduled
            //    {
            int Fileid = sstr.FileId;
            if (xe.HasChildNodes)
            {
                xe.RemoveChild(xe.FirstChild);

            }
            SST.HearingRow[] aHrs = (SST.HearingRow[])myA.DB.Hearing.Select("Fileid=" + Fileid.ToString() + " and HearingStatus=1");
            //myA.FM.CurrentFile.SetMisc1DateNull();  //it's all inhearing before update now 2015-3-10 CJW
            if (aHrs.Length > 0)
            {
                foreach (SST.HearingRow aHr in aHrs)
                {
                    //  JLL: If Hearing/ApptId is null, don't create xmldate node
                    if (!aHr.IsApptIdNull())
                    {
                        int ApptId = aHr.ApptId;
                        atriumDB.AppointmentRow aDr = (atriumDB.AppointmentRow)myA.FM.DB.Appointment.Select("ApptId=" + ApptId.ToString())[0];
                        DateTime dateTimeLocal = aDr.StartDateLocal;
                        string dtDateEng = dateTimeLocal.ToString("MMMM dd, yyyy @ hh:mm tt", System.Globalization.CultureInfo.CreateSpecificCulture("en-CA"));
                        string dtDateFre = dateTimeLocal.ToString("dd MMMM yyyy à HH:mm", System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA"));

                        string[] tzv = GetAcronymTimeZoneLabel();

                        System.Xml.XmlElement xmlDate = xd.CreateElement("toc");
                        xmlDate.SetAttribute("supertype", "sstcase");
                        xmlDate.SetAttribute("type", "sstcase");
                        xmlDate.SetAttribute("bold", "true");
                        xmlDate.SetAttribute("titlef", dtDateFre + " " + tzv[0]);
                        xmlDate.SetAttribute("titlee", dtDateEng + " " + tzv[1]);
                        if (xe.HasChildNodes)
                        {
                            xe.RemoveChild(xe.FirstChild);
                        }
                        xe.AppendChild(xmlDate);
                        if(!aHr.IsSCOfficeIdNull())
                            myA.FM.EFile.XmlAddTocACS(xd, 105352, "sstcase", 109);
                    }
                }
            }

            //}
            //Hearing Postponed ||  Hearing Adjourned ||Hearing Held || Decision Issued 
            //if ((sstr.CaseStatus == 6) || (sstr.CaseStatus == 7) || (sstr.CaseStatus == 5) || (sstr.CaseStatus == 4) || (sstr.CaseStatus == 9))
            //{
            //    if (xe.HasChildNodes)
            //    {
            //        xe.RemoveChild(xe.FirstChild);

            //    }
            //}

            //}
            //else
            //{
            //    xe.SetAttribute("titlee", "SST Appeal");
            //    xe.SetAttribute("titlef", "Appel au TSS");
            //}

            System.Xml.XmlElement xe2 = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='sstcase' and @type='sstdetail']");
            if (xe2 == null)
            {
                string sort = "110";
                xe2 = xd.CreateElement("toc");
                xe2.SetAttribute("supertype", "sstcase");
                xe2.SetAttribute("type", "sstdetail");
                xe2.SetAttribute("sort", sort);
                xe2.SetAttribute("id", sstr.SSTCaseId.ToString());
                xe2.SetAttribute("titlee", "Program Information");
                xe2.SetAttribute("titlef", "Information sur le Programme");

                System.Xml.XmlElement xeAfter = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@sort>" + sort + "]");
                if (xeAfter == null)
                    xeAfter = (System.Xml.XmlElement)xd.SelectSingleNode("//fld[@sort>" + sort + "]");

                if (xeAfter == null)
                    xd.DocumentElement.AppendChild(xe2);
                else
                    xd.DocumentElement.InsertBefore(xe2, xeAfter);
            }
        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {
            SST.SSTCaseRow dr = (SST.SSTCaseRow)row;

            switch (dc.ColumnName)
            {
                case "ReconsiderationID":
                    if (!dr.IsReconsiderationIDNull())
                    {
                        int dupCount = Convert.ToInt32(myA.AppMan.ExecuteScalar("[SSTCaseDuplicateReconId]", new object[] { dr.ReconsiderationID, dr.SSTCaseId }));
                        if (dupCount > 0)
                        {
                            //throw new AtriumException(Properties.Resources.DuplicateReconID);
                            myA.FM.RaiseWarning(WarningLevel.Display, Properties.Resources.DuplicateReconID, myA.AtMng.AppMan.AppName);
                        }
                    }
                    break;
                case "AppealDate":
                    if (ReceivedComplete(dr))
                    {
                        if (dr.IsAppealDateNull())
                            throw new RequiredException(dc.ColumnName);
                        else
                        {
                            myA.IsValidDate(dc.ColumnName, dr.AppealDate, false, dr.ReceivedDate, DateTime.Today, "Received Date", "Today");

                        }
                    }
                    else
                    {
                        if (!dr.IsAppealDateNull())
                        {
                            if (!dr.IsOrigDecisionDateNull())
                                myA.IsValidDate(dc.ColumnName, dr.AppealDate, false, dr.OrigDecisionDate, DateTime.Today, "Reconsideration date", atriumBE.Properties.Resources.ValidationToday);
                            else
                                myA.IsValidDate(dc.ColumnName, dr.AppealDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                        }
                    }
                    break;
                case "ReceivedDate":
                    if (dr.IsReceivedDateNull())
                        throw new RequiredException(dc.ColumnName);
                    else
                    {
                        if (ReceivedComplete(dr))
                        {
                            if (!dr.IsOrigDecisionDateNull())
                                myA.IsValidDate(dc.ColumnName, dr.ReceivedDate, false, dr.OrigDecisionDate, DateTime.Today, "Reconsideration date", atriumBE.Properties.Resources.ValidationToday);
                            else
                                myA.IsValidDate(dc.ColumnName, dr.ReceivedDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                        }
                        else
                        {
                            if (dr.IsAppealDateNull())
                                myA.IsValidDate(dc.ColumnName, dr.ReceivedDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                            else
                                myA.IsValidDate(dc.ColumnName, dr.ReceivedDate, false, DateTime.Today.AddYears(-15), dr.AppealDate, atriumBE.Properties.Resources.Validation15yearsago, "Appeal date");
                        }
                    }
                    break;
                case "OrigDecisionDate":
                    if (ReceivedComplete(dr))
                    {
                        if (dr.IsOrigDecisionDateNull())
                        {
                            throw new RequiredException(dc.ColumnName);
                        }
                        else
                        {
                            if (dr.IsReceivedDateNull())
                                myA.IsValidDate(dc.ColumnName, dr.OrigDecisionDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                            else
                                myA.IsValidDate(dc.ColumnName, dr.OrigDecisionDate, false, DateTime.Today.AddYears(-15), dr.ReceivedDate, atriumBE.Properties.Resources.Validation15yearsago, "Received Date");
                       
                        }
                    }
                    else
                    {
                        if (!dr.IsOrigDecisionDateNull())
                        {
                            if (dr.IsAppealDateNull())
                                myA.IsValidDate(dc.ColumnName, dr.OrigDecisionDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                            else
                                myA.IsValidDate(dc.ColumnName, dr.OrigDecisionDate, false, DateTime.Today.AddYears(-15), dr.AppealDate, atriumBE.Properties.Resources.Validation15yearsago, "Appeal Date");
                        }
                    }
                  
                    break;
                //case "OrigDecisionRecDate":
                //    if (dr.IsOrigDecisionRecDateNull())
                //        throw new RequiredException(dc.ColumnName);
                //    else
                //    {
                //        myA.IsValidDate(dc.ColumnName, dr.OrigDecisionRecDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                //    }
                //    break;
                case "IsLate":
                    if (dr.IsLate && !dr.IgnoreLate)
                        LateWarning(dr);
                    break;
                case "LateOverride":
                    //if (!dr.LateOverride)
                    //{
                    if (dr.IsLate && !dr.IgnoreLate)
                        LateWarning(dr);
                    //}
                    //else
                    //{
                    //    myA.FM.EFile.ClearImportantMessage();
                    //}
                    break;
                case "AppealLevelID":
                    if (dr.IsAppealLevelIDNull())
                        throw new RequiredException(dc.ColumnName);
                    else if (!myA.CheckDomain(dr.AppealLevelID, myA.FM.Codes("AppealLevel")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Appeal level");
                    break;
                case "ProgramId":
                    if (dr.IsProgramIdNull())
                        throw new RequiredException(dc.ColumnName);
                    else if (!myA.CheckDomain(dr.ProgramId, myA.FM.Codes("Program")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Program");
                    break;
                case "AccountId":
                    //TFS#54670 CJW 2013-09-05 added column and rule
                    //if (!dr.IsProgramIdNull() && (dr.ProgramId==8 || dr.ProgramId==9) && dr.IsAccountIdNull())
                    //    throw new RequiredException(dc.ColumnName);
                    break;
                case "DecisionDate":
                    if (!dr.IsDecisionDateNull())
                        myA.IsValidDate(dc.ColumnName, dr.DecisionDate, true, dr.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "DecisionSentDate":
                    if (!dr.IsDecisionSentDateNull())
                        myA.IsValidDate(dc.ColumnName, dr.DecisionSentDate, true, dr.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "WithdrawalDate":
                    if (!dr.IsWithdrawalDateNull())
                        myA.IsValidDate(dc.ColumnName, dr.WithdrawalDate, true, dr.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "FileCompleteDate":
                    if (ReceivedComplete(dr))
                    {
                        if (dr.IsFileCompleteDateNull())
                            throw new RequiredException(dc.ColumnName);
                        else
                        {
                            myA.IsValidDate(dc.ColumnName, dr.FileCompleteDate, false, dr.ReceivedDate, DateTime.Today, "Received Date", "Today");

                        }
                    }
                    else
                    {
                        if (!dr.IsFileCompleteDateNull())
                        {
                            if (!dr.IsOrigDecisionDateNull())
                                myA.IsValidDate(dc.ColumnName, dr.FileCompleteDate, false, dr.OrigDecisionDate, DateTime.Today, "Reconsideration date", atriumBE.Properties.Resources.ValidationToday);
                            else
                                myA.IsValidDate(dc.ColumnName, dr.FileCompleteDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);
                        }
                    }
                    break;
                case "LeaveToAppealDate":
                    myA.IsValidDate(dc.ColumnName, dr.LeaveToAppealDate, true, dr.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
                case "LeaveToAppealRecDate":
                    myA.IsValidDate(dc.ColumnName, dr.LeaveToAppealRecDate, true, dr.ReceivedDate, DateTime.Today, atriumBE.Properties.Resources.SSTAppealDate, atriumBE.Properties.Resources.ValidationToday);
                    break;
            }
        }

        private void LateWarning(SST.SSTCaseRow dr)
        {
            //if (!dr.LateOverride) // WI 83086
            //{
            int daysLate = GetLateDays(dr);

            string msgReceiptOfNoaIsLate = string.Empty;
            string msgReceiptOfNoaIsLate365days = string.Empty;

            if (!dr.IsAppealLevelIDNull() && dr.AppealLevelID == 1) // GD files
            {
                msgReceiptOfNoaIsLate = Properties.Resources.SSTLateWarningGD;
                msgReceiptOfNoaIsLate365days = Properties.Resources.SSTLateWarningGD;
            }
            else // AD files
            {
                msgReceiptOfNoaIsLate = Properties.Resources.SSTLateWarningAD;
                msgReceiptOfNoaIsLate365days = Properties.Resources.SSTLateWarningAD;
            }

            msgReceiptOfNoaIsLate = String.Format(msgReceiptOfNoaIsLate, daysLate);
            msgReceiptOfNoaIsLate365days = String.Format(msgReceiptOfNoaIsLate365days, 365);

            if (IsLate(dr) && daysLate != 365)
            {
                myA.FM.EFile.RemoveFromImportantMessage(msgReceiptOfNoaIsLate365days);
                if (!dr.LateOverride)
                {
                    myA.FM.EFile.AppendToImportantMessage(msgReceiptOfNoaIsLate);
                    myA.FM.RaiseWarning(WarningLevel.Display, msgReceiptOfNoaIsLate, myA.AtMng.AppMan.AppName);
                }
                else
                {
                    myA.FM.EFile.RemoveFromImportantMessage(msgReceiptOfNoaIsLate);
                }
            }
            else if (daysLate != 365)
            {
                myA.FM.EFile.RemoveFromImportantMessage(msgReceiptOfNoaIsLate);
            }
            //}
            //else
            //{
            //    myA.FM.EFile.ClearImportantMessage(); // WI 83086
            //}
        }

        private void Late365daysWarning(SST.SSTCaseRow dr)
        {
            //if (!dr.LateOverride) // WI 83086
            //{

            string msgReceiptOfNoaIsLate = string.Empty;
            string msgReceiptOfNoaIsLate365days = string.Empty;

            if (!dr.IsAppealLevelIDNull() && dr.AppealLevelID == 1) // GD files
            {
                msgReceiptOfNoaIsLate = Properties.Resources.SSTLateWarningGD;
                msgReceiptOfNoaIsLate365days = Properties.Resources.SSTLateWarningGD;
            }
            else // AD files
            {
                msgReceiptOfNoaIsLate = Properties.Resources.SSTLateWarningAD;
                msgReceiptOfNoaIsLate365days = Properties.Resources.SSTLateWarningAD;
            }


            if (IsEIProgram(dr))
            {
                msgReceiptOfNoaIsLate = String.Format(msgReceiptOfNoaIsLate, myA.AtMng.GetSetting(AppIntSetting.EIDaysLate));
            }
            else if (!dr.IsProgramIdNull() && dr.ProgramId != 3)
            {
                msgReceiptOfNoaIsLate = String.Format(msgReceiptOfNoaIsLate, myA.AtMng.GetSetting(AppIntSetting.ISDaysLate));
            }
            msgReceiptOfNoaIsLate365days = String.Format(msgReceiptOfNoaIsLate365days, 365);
            if (dr.IsLate365)
            {
                myA.FM.EFile.RemoveFromImportantMessage(msgReceiptOfNoaIsLate);
                if (!dr.LateOverride)
                {
                    myA.FM.EFile.AppendToImportantMessage(msgReceiptOfNoaIsLate365days);
                    myA.FM.RaiseWarning(WarningLevel.Display, msgReceiptOfNoaIsLate365days, myA.AtMng.AppMan.AppName);
                }
                else
                {
                    myA.FM.EFile.RemoveFromImportantMessage(msgReceiptOfNoaIsLate365days);
                }
            }
            else
            {
                myA.FM.EFile.RemoveFromImportantMessage(msgReceiptOfNoaIsLate365days);
            }
            //}
            //else
            //{
            //    myA.FM.EFile.ClearImportantMessage(); // WI 83086
            //}
        }

        protected override void BeforeUpdate(DataRow row)
        {
            SST.SSTCaseRow dr = (SST.SSTCaseRow)row;
            BeforeChange("AppealDate", dr);
            BeforeChange("ReceivedDate", dr);
            BeforeChange("OrigDecisionDate", dr);
            BeforeChange("FileCompleteDate", dr);
            BeforeChange("AccountId", dr);

            myA.FM.CurrentFile.Dim1Id = dr.AppealLevelID;
            myA.FM.CurrentFile.Dim2Id = dr.ProgramId;
            if (myA.FM.CurrentFile.StatusCode == "O" || myA.FM.CurrentFile.StatusCode == "P")
            {
                if (dr.FileComplete && myA.FM.CurrentFile.StatusCode == "P")
                    myA.FM.CurrentFile.StatusCode = "O";
                else if (!dr.FileComplete && myA.FM.CurrentFile.StatusCode == "O")
                    myA.FM.CurrentFile.StatusCode = "P";
            }
            Calc365Deadline(dr);
            //TFS#56157 BY 2013-9-20
            if (!dr.IsDecisionDateNull())
            {
                foreach (SST.SSTCaseMatterRow scmr in myA.DB.SSTCaseMatter)
                {
                    if (scmr.IsOutcomeIdNull())
                    {
                        throw new RequiredException("Outcome");
                    }
                }

                foreach (SST.SSTDecisionRow sdr in dr.GetSSTDecisionRows())
                {
                    if ((sdr.IsFinal | sdr.IsOutcomeIdNull()) && !dr.IsDecisionTypeNull() && sdr.DecisionType == dr.DecisionType)
                    {
                        sdr.OutcomeId = dr.OutcomeId;

                        sdr.DecisionDate = dr.DecisionDate;
                        if (!dr.IsDecisionSentDateNull())
                            sdr.DecisionSentDate = dr.DecisionSentDate;
                    }
                }
            }
            Warnings(dr);
        }

        private void Warnings(SST.SSTCaseRow dr)
        {
            //1.	Notice of Appeal received date should not be more than a month ago
            if (!dr.IsReceivedDateNull() && dr.ReceivedDate < DateTime.Today.AddMonths(-1))
            { }
            //2.	Date of Notice of Appeal cannot be after Notice of Appeal received date
            if (!dr.IsAppealDateNull() && !dr.IsReceivedDateNull() && dr.ReceivedDate < dr.AppealDate)
            { }
            //3.	Date of Notice of Appeal should not be more than a month ago
            if (!dr.IsAppealDateNull() && dr.AppealDate < DateTime.Today.AddMonths(-1))
            { }
            //4.	Date of Decision Being Appealed cannot be after Date of Notice of Appeal
            if (!dr.IsOrigDecisionDateNull() && !dr.IsAppealDateNull() && dr.AppealDate < dr.OrigDecisionDate)
            { }
        }

        public void Calc365Deadline(SST.SSTCaseRow dr)
        {
            if (!IsEIProgram(dr))
            {
                if (!dr.IsLate)
                {
                    //Set 365 date based
                    if (!dr.IsAppealDateNull())
                        dr.Received365Date = dr.AppealDate.AddDays(365);
                }
                else
                {
                    //double check there is late appeal decision if there is the date received 365 is set
                    //based on that record.
                    //See also SSTDEcision_BE.cs adding a late decision triggers update

                    foreach (SST.SSTDecisionRow sdr in dr.GetSSTDecisionRows())
                    {
                        if (sdr.DecisionType == 3 && !sdr.IsDecisionDateNull())  //who cares what the outcome is  !sdr.IsOutcomeIdNull() && sdr.OutcomeId == 7 &&
                        {
                            dr.Received365Date = sdr.DecisionDate.AddDays(365);
                        }

                    }
                }
            }
        }

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[] { this.myA.FM.CurrentFile };
        //}

        public override DataRow[] GetCurrentRow()
        {
            return mySSTCaseDT.Select();
        }

        public override string PromptColumnName()
        {
            return "AppealDate";
        }

        public override string FriendlyName()
        {
            return mySSTCaseDT.TableName; ;
        }

        public override string PromptFormat()
        {
            return "";
        }

        public void CalcDates()
        {
            myA.isMerging = true;
            foreach (SST.SSTCaseRow sr in mySSTCaseDT)
            {
                if (!sr.IsOrigDecisionDateNull() && !sr.IsAppealDateNull())
                {
                    sr.IsLate365 = sr.OrigDecisionDate.AddDays(365) < sr.AppealDate;
                    sr.AcceptChanges();
                }
            }
            myA.isMerging = false;
        }

        private void CreateAppeal(int fileAppealedId)
        {
            FileManager fmOrig = myA.AtMng.GetFile(fileAppealedId);
            SSTManager sstOrig = fmOrig.GetSSTMng();

            SST.SSTCaseRow scr = mySSTCaseDT[0];
            //copy sstcasematter

            if (!sstOrig.DB.SSTCase[0].IsDecisionSentDateNull())
                scr.OrigDecisionDate = sstOrig.DB.SSTCase[0].DecisionSentDate;


            //is leave to app0eal required!!
            if (sstOrig.DB.SSTCase[0].OutcomeId == 5 || sstOrig.DB.SSTCase[0].OutcomeId == 18)
                scr.LeaveToAppealNotRequired = true;
            else
                scr.LeaveToAppealNotRequired = false;

            scr.ProgramId = sstOrig.DB.SSTCase[0].ProgramId;
            if (!sstOrig.DB.SSTCase[0].IsAccountIdNull())
                scr.AccountId = sstOrig.DB.SSTCase[0].AccountId;

            foreach (SST.SSTCaseMatterRow scmr in sstOrig.DB.SSTCaseMatter)
            {
                SST.SSTCaseMatterRow newScmr = (SST.SSTCaseMatterRow)myA.GetSSTCaseMatter().Add(scr);
                if (!scmr.IsIssueIdNull())
                    newScmr.IssueId = scmr.IssueId;
                if (!scmr.IsAccountIdNull())
                    newScmr.AccountId = scmr.AccountId;

                newScmr.ProgramId = scmr.ProgramId;
            }

            //copy contacts/parties
            foreach (atriumDB.FileContactRow fcr in fmOrig.DB.FileContact)
            {
                if (fcr.ContactClass == "P")
                {
                    atriumDB.FileContactRow newFcr = (atriumDB.FileContactRow)myA.FM.GetFileContact().Add(myA.FM.CurrentFile);
                    newFcr.ContactId = fcr.ContactId;
                    newFcr.ContactType = fcr.ContactType;

                    SST.FilePartyRow fpr = (SST.FilePartyRow)sstOrig.DB.FileParty.Select("Filecontactid=" + fcr.FileContactid.ToString())[0];
                    SST.FilePartyRow newFpr = (SST.FilePartyRow)myA.GetFileParty().Add(scr);
                    newFpr.IsAppellant = fpr.IsAppellant;
                    newFpr.IsRespondent = fpr.IsRespondent;
                    newFpr.IsPending = true;
                    newFpr.FileContactId = newFcr.FileContactid;
                }
            }
        }

        bool copyOnce = false;
        private void CreateAppealDocs(int fileAppealedId)
        {
            if (copyOnce)
                return;
            copyOnce = true;

            FileManager fmOrig = myA.AtMng.GetFile(fileAppealedId);
            //need to add all copied docs as attachments on intial DC doc
            docDB.DocumentRow newDC = (docDB.DocumentRow)myA.FM.CurrentActivityProcess.CurrentACE.relTables["Document0"][0].Row;// (docDB.DocumentRow)myA.FM.GetDocMng().DB.Document[0];
            foreach (docDB.DocumentRow dr in fmOrig.GetDocMng().DB.Document)
            {
                //only bring over P1 and P2 doctypemajor documents
                if (!dr.IsDocTypeMajorCodeNull())
                {
                    switch (dr.DocTypeMajorCode.ToUpper())
                    {
                        case "P1":
                        case "P2":
                            docDB.DocumentRow newdr = (docDB.DocumentRow)myA.FM.GetDocMng().GetDocument().Add(myA.FM.CurrentFile);
                            int docid = newdr.DocId;
                            myA.FM.GetDocMng().isMerging = true;
                            ACManager.ImportRow(newdr, dr);
                            newdr.FileId = myA.FM.CurrentFileId;
                            newdr.DocId = docid;
                            //newdr.SourceDivision = dr.SourceDivision;
                            newdr.SetCheckedOutByNull();
                            newdr.SetCheckedOutDateNull();
                            newdr.SetCheckedOutPathNull();
                            if (newdr.efType == "GDEC" || newdr.efType == "ADEC")
                                newdr.efType = "ODEC";

                            myA.FM.GetDocMng().isMerging = false;

                            docDB.AttachmentRow attr = (docDB.AttachmentRow)myA.FM.GetDocMng().GetAttachment().Add(newDC);
                            attr.AttachmentId = newdr.DocId;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private bool IsEIProgram(SST.SSTCaseRow sstcaserow)
        {
            if (!sstcaserow.IsProgramIdNull() && sstcaserow.ProgramId == 3)
                return true;
            else
                return false;
        }

        public int EffectiveProgram(SST.SSTCaseRow sr)
        {
            if (IsEIProgram(sr))
                return sr.ProgramId;
            else
            {
                if (sr.IsAccountIdNull())
                    return sr.ProgramId;
                else
                {
                    //find programid for account
                    ObjectBE obe = myA.AtMng.GetCodeTableBE("AccountType");
                    if (obe.myDT.Rows.Count == 0)
                        obe.Load();
                    CodesDB.AccountTypeDataTable atdt = (CodesDB.AccountTypeDataTable)obe.myDT;
                    CodesDB.AccountTypeRow atr = atdt.FindByAccountTypeId(sr.AccountId);
                    return atr.ProgramID;
                }
            }
        }

        private int GetSettingDays(SST.SSTCaseRow sstcaserow)
        {
            if (IsEIProgram(sstcaserow))
            {
                return myA.AtMng.GetSetting(AppIntSetting.EIDaysLate);

            }
            else if (!sstcaserow.IsProgramIdNull() && sstcaserow.ProgramId != 3)
            {
                return myA.AtMng.GetSetting(AppIntSetting.ISDaysLate);

            }
            return 10000;
        }
    }
}