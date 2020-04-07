using System;
using System.Data;
using atLogic;
using lmDatasets;


namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class EFileBE : atLogic.ObjectBE
    {
        string DefaultXML = "<toc><toc titlee=\"Activity\" titlef=\"Activité\" type=\"activity\" sort=\"100\" /><toc titlee=\"BFs\" titlef=\"Rappels\" type=\"activitybf\" sort=\"101\" /><toc type=\"document\" filter=\"true\" titlee=\"Documents\" titlef=\"Documents\" sort=\"105\" /><toc type=\"efile\" titlee=\"File Properties\" titlef=\"Propriétés du dossier\"  sort=\"106\" /></toc>";

        appDB.EFileSearchRow parentEFileRow;

        public atriumDB.EFileDataTable myEFileDT
        {
            get
            {
                return (atriumDB.EFileDataTable)myDT;
            }
        }
        public FileManager myA
        {
            get
            {
                return (FileManager)MyMngr;
            }
        }

        internal EFileBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.EFile)
        {

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetEFile();
        }
        public atriumDAL.EFileDAL myDAL
        {
            get
            {
                return (atriumDAL.EFileDAL)myODAL;
            }
        }

        public appDB.EFileSearchDataTable SearchByContact(int contactId, string contactType)
        {
            if (myA.AtMng.AppMan.UseService)
                return myA.AtMng.AppMan.AtriumX().SearchByContact(contactId, contactType, myA.AtMng.AppMan.AtriumXCon);
            else
            {
                try
                {
                    return myDAL.SearchByContact(contactId, contactType);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    return myDAL.SearchByContact(contactId, contactType);
                }
            }
        }

        /// <summary>
        /// Moves a File to another file
        /// </summary>
        /// <param name="file">File to move</param>
        /// <param name="toFile">Target file</param>
        public void Move(atriumDB.EFileRow file, int toFileId, bool renumber, string newNumber)
        {
            //need to check permissions on current file
            if (!CanEdit(file))
                throw new AtriumException(Properties.Resources.YouNeedDeletePermissionOnTheFileToMoveIt);

            FileManager toFM = myA.AtMng.GetFile(toFileId);
            atriumDB.EFileRow toFile = toFM.CurrentFile;

            if (!(toFile.FileMetaTypeRow.AllowSubFiles | toFile.FileMetaTypeRow.AllowPockets))
                throw new AtriumException(Properties.Resources.EFileParentFileDoesNotAllowSubFiles);

            //need to check permissions on target file
            if (!toFM.EFile.CanAdd(toFile))
                throw new AtriumException(Properties.Resources.YouNeedAddFilePermissionOnTheDestinationFile);

            //check to see if record is being editted
            if (file.RowState == DataRowState.Modified || file.HasVersion(DataRowVersion.Proposed))
                throw new AtriumException(Properties.Resources.RowIsBeingEditted);

            //check for parent-child relation
            if (toFile.SortKey.StartsWith(file.SortKey))
                throw new AtriumException(Properties.Resources.CanTMoveFileToAChildOfItself);

            //load x-refs so validation of duplicates can occurr
            myA.GetFileXRef().LoadByFileId(toFileId);
            myA.GetFileXRef().LoadByOtherFileId(file.FileId);

            //move file
            atriumDB.FileXRefRow fxr = GetParentFileXref(file);
            fxr.FileId = toFile.FileId;

            if (fxr.HasErrors)
            {
                string msg = fxr.GetColumnError("FileId");
                fxr.RejectChanges();
                throw new AtriumException(msg);
            }

            parentEFileRow = null;
            //file.ParentFileId = toFile.FileId;


            ////remove old security rules
            //myA.AtMng.SecurityManager.GetsecFileRule().LoadByFileId(file.FileId);
            //foreach (lmDatasets.SecurityDB.secFileRuleRow sfr in myA.AtMng.SecurityManager.DB.secFileRule.Select("Fileid=" + file.FileId.ToString()))
            //{
            //    sfr.Delete();
            //}

            ////apply new security rules
            //myA.AtMng.SecurityManager.GetsecFileRule().LoadByFileId(toFile.FileId);
            //foreach (lmDatasets.SecurityDB.secFileRuleRow sfr in myA.AtMng.SecurityManager.DB.secFileRule.Select("Fileid=" + toFile.FileId.ToString()))
            //{
            //    lmDatasets.SecurityDB.secFileRuleRow sfrNew =(lmDatasets.SecurityDB.secFileRuleRow) myA.AtMng.SecurityManager.GetsecFileRule().Add(null);
            //    sfrNew.FileId = file.FileId;
            //    sfrNew.ApplyTo = sfr.ApplyTo;
            //    sfrNew.Disabled = sfr.Disabled;
            //    sfrNew.EndDate = sfr.EndDate;
            //    sfrNew.GroupId = sfr.GroupId;
            //    sfrNew.Inherited = true;
            //    //sfrNew.InheritedFrom=sfr.InheritedFrom
            //    sfrNew.RuleId = sfr.RuleId;
            //    sfrNew.StartDate = sfr.StartDate;

            //}

            //update fullfilenumber & fullpath
            if (renumber)
            {
                myA.EFile.AssignFileNumber(toFile, file);
            }
            else
            {
                file.FileNumber = newNumber;
                //file.FullFileNumber = toFile.FullFileNumber + "-" + file.FileNumber;
            }

            file.FullPath = toFile.FullPath + @"\" + file.NameE;
        }

        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.EFileRow r = (atriumDB.EFileRow)dr;

        }

        protected override void AfterDelete(DataRow dr)
        {


            myA.AtMng.RaiseEfileUpdate((atriumDB.EFileRow)dr);

        }
   
        private atriumDB.EFileRow Load(int FileId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().EFileLoad(FileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(FileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(FileId));
                }
            }
            return myEFileDT.FindByFileId(FileId);
        }

     

        public atriumDB.EFileRow Load(int FileId, bool updateFSxml)
        {

            atriumDB.EFileRow efr = myEFileDT.FindByFileId(FileId);
            if (efr == null)
            {

                efr = Load(FileId);

                //if (efr != null && (updateFSxml || efr.IsFileStructXmlNull()))
                //{

                //    RebuildFileStruct(efr);

                //    //Update();
                //    //efr.AcceptChanges();  //line chnaged by cjw on 2010-2-17 to fix issue with filestruct not saving
                //}
            }
            return efr;

        }

        public void RebuildFileStruct(atriumDB.EFileRow er)
        {
            AllowEdit = true;
            er.FileStructXml = CalcFileStructXml(er, false, false).OuterXml;
            er.RebuildTOC = false;
            AllowEdit = false;
            try
            {
                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(this );
                bp.Update();


            }
            catch (Exception x)
            {
                //suppress error - probably caused by someone without write perm on efile

            }
        }

     

        internal int LoadByOfficeFileNum(string officeFileNum, int officeID)
        {
            //do a search and return the first hit
            //throw error if more than one hit
            //return null if no hits


            appDB.EFileSearchDataTable dt = this.myA.AtMng.FileSearchByOfficeFileNum(officeFileNum, officeID);
            if (dt.Rows.Count == 0)
            {
                throw new AtriumException(atriumBE.Properties.Resources.NoFile);
            }
            else if (dt.Rows.Count == 1)
            {
                //atriumDB.EFileRow drFile;
                //drFile = Load(dt[0].FileId, false);
                return dt[0].FileId;

            }
            else
            {
                appDB.EFileSearchRow[] drs = (appDB.EFileSearchRow[])dt.Select("OfficeFileNum='" + officeFileNum + "'");
                if (drs.Length == 1)
                {
                    //atriumDB.EFileRow drFile;
                    //drFile = Load(Convert.ToInt32(drs[0].FileId), false);

                    return drs[0].FileId;
                }
                else
                    throw new AtriumException(atriumBE.Properties.Resources.DuplicateFileOfficeNumber);
            }


        }
        public atriumDB.EFileRow LoadByFullFileNumber(string FileNumber)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().EFileLoadByFullFileNumber(FileNumber, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByFullFileNumber(FileNumber));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByFullFileNumber(FileNumber));
                }
            }
            if (myEFileDT.Select("FullFileNumber='" + FileNumber + "'").Length == 1)
            {
                atriumDB.EFileRow drwEFile = (atriumDB.EFileRow)myEFileDT.Select("FullFileNumber='" + FileNumber + "'")[0];
                return drwEFile;
            }
            else
                throw new AtriumException(atriumBE.Properties.Resources.NoFile);
        }

        public atriumDB.FileXRefRow GetParentFileXref(atriumDB.EFileRow dr)
        {
            atriumDB.FileXRefRow[] fxrParents = (atriumDB.FileXRefRow[])myA.DB.FileXRef.Select("LinkType=0 and OtherFileid=" + dr.FileId.ToString());

            if (fxrParents.Length == 0)
                myA.GetFileXRef().LoadByOtherFileId(dr.FileId);

            fxrParents = (atriumDB.FileXRefRow[])myA.DB.FileXRef.Select("LinkType=0 and OtherFileid=" + dr.FileId.ToString());

            if (fxrParents.Length == 0)
                return null;

            return fxrParents[0];
        }

        public atriumDB.EFileRow[] GetEFileRows(atriumDB.EFileRow dr)
        {
            atriumDB.FileXRefRow[] fxrKids = (atriumDB.FileXRefRow[])myA.DB.FileXRef.Select("LinkType=0 and Fileid=" + dr.FileId.ToString(), "Name");

            atriumDB.EFileRow[] efrs = new atriumDB.EFileRow[fxrKids.Length];
            int i = 0;
            foreach (atriumDB.FileXRefRow fxr in fxrKids)
            {
                efrs.SetValue(fxr.EFileRowByEFile_FileXRefParent, i);
                i++;
            }

            return efrs;

        }
        public atriumDB.EFileRow[] GetEFileRows(atriumDB.EFileRow dr, FXLinkType xrefType)
        {
            atriumDB.FileXRefRow[] fxrKids;

            if (xrefType == FXLinkType.XRef)
            {
                myA.GetFileXRef().LoadByOtherFileId(dr.FileId);
                fxrKids = (atriumDB.FileXRefRow[])myA.DB.FileXRef.Select("LinkType=" + ((int)xrefType).ToString() + " and (Fileid=" + dr.FileId.ToString() + " or otherfileid=" + dr.FileId.ToString() + ")", "Name");
            }
            else
                fxrKids = (atriumDB.FileXRefRow[])myA.DB.FileXRef.Select("LinkType=" + ((int)xrefType).ToString() + " and Fileid=" + dr.FileId.ToString(), "Name");

            atriumDB.EFileRow[] efrs = new atriumDB.EFileRow[fxrKids.Length];
            int i = 0;
            foreach (atriumDB.FileXRefRow fxr in fxrKids)
            {
                if (fxr.FileId == dr.FileId)
                {
                    if (fxr.EFileRowByEFile_FileXRefParent == null)
                        myA.EFile.Load(fxr.OtherFileId);
                    efrs.SetValue(fxr.EFileRowByEFile_FileXRefParent, i);
                }
                else
                {
                    if (fxr.EFileRowByEFile_FileXRefChild == null)
                        myA.EFile.Load(fxr.FileId);
                    efrs.SetValue(fxr.EFileRowByEFile_FileXRefChild, i);

                }
                i++;
            }

            return efrs;

        }
        public appDB.EFileSearchRow GetEfileParentRow(atriumDB.EFileRow dr)
        {
            if (dr.FileId == myA.CurrentFileId && parentEFileRow != null)
                return parentEFileRow;

            atriumDB.FileXRefRow fxrParent = GetParentFileXref(dr);
            if (fxrParent == null)
                return null;

            appDB.EFileSearchDataTable dt = myA.AtMng.FileSearchByFileId(fxrParent.FileId);
            if (dt.Rows.Count == 0)
                return null;
            else
            {
                appDB.EFileSearchRow pdr = dt[0];
                if (dr.FileId == myA.CurrentFileId)
                    parentEFileRow = pdr;

                return pdr;
            }
            //  atriumDB.EFileRow pdr = fxrParent.EFileRowByEFile_FileXRefChild;
            //  if (pdr == null)
            //      pdr = myA.AtMng.GetFile(fxrParent.FileId, false).CurrentFile;// this.Load(fxrParent.FileId, false);

            //  return pdr;

        }

        //private void UpdateFullPath(atriumDB.EFileRow efr)
        //{
        //    atriumDB.EFileRow pdr = GetEfileParentRow(efr);

        //    if (pdr != null)
        //    {
        //        if (pdr.IsPathFormatNull())
        //        {
        //            efr.FullPath = pdr.FullPath + efr.FileNumber + "\\";
        //        }
        //        else
        //        {
        //            efr.FullPath = pdr.FullPath + Convert.ToInt32(efr.FileNumber).ToString(pdr.PathFormat) + "\\";
        //        }
        //    }

        //}
        internal static System.Xml.XmlElement XmlAddFld(System.Xml.XmlDocument xd, string type, string titlee, string titlef, int sort)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//fld[@type='" + type + "']");
            if (xe == null)
            {
                xe = xd.CreateElement("fld");
                System.Xml.XmlElement xeAfter = (System.Xml.XmlElement)xd.SelectSingleNode("//fld[@sort>" + sort.ToString() + "]");
                if (xeAfter == null)
                    xd.DocumentElement.AppendChild(xe);
                else
                    xd.DocumentElement.InsertBefore(xe, xeAfter);

            }
            xe.SetAttribute("sort", sort.ToString());
            xe.SetAttribute("type", type);
            xe.SetAttribute("titlee", titlee);
            xe.SetAttribute("titlef", titlef);

            return xe;
        }
        internal static System.Xml.XmlElement XmlAddFld(System.Xml.XmlElement xe1, string type, string titlee, string titlef, int sort)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xe1.SelectSingleNode("fld[@type='" + type + "']");
            if (xe == null)
            {
                xe = xe1.OwnerDocument.CreateElement("fld");
                System.Xml.XmlElement xeAfter = (System.Xml.XmlElement)xe1.SelectSingleNode("fld[@sort>" + sort.ToString() + "]");
                if (xeAfter == null)
                    xe1.AppendChild(xe);
                else
                    xe1.OwnerDocument.DocumentElement.InsertBefore(xe, xeAfter);

            }
            xe.SetAttribute("sort", sort.ToString());
            xe.SetAttribute("type", type);
            xe.SetAttribute("titlee", titlee);
            xe.SetAttribute("titlef", titlef);

            return xe;
        }
        internal static void XmlAddToc(System.Xml.XmlDocument xd, string toc, string titlee, string titlef, int sort)
        {
            XmlAddToc(xd, toc, titlee, titlef, sort, null);
        }
        internal static void XmlAddToc(System.Xml.XmlDocument xd, string toc, string titlee, string titlef, int sort, string id)
        {
            XmlAddToc(xd, toc, titlee, titlef, sort, null,null,null);
        }
        
        internal static void XmlAddToc(System.Xml.XmlDocument xd, string toc, string titlee, string titlef, int sort, string id, string superType, string filter)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='" + toc + "']");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                System.Xml.XmlElement xeAfter = (System.Xml.XmlElement)xd.SelectSingleNode("//fld[@sort>" + sort.ToString() + "]");
                if (xeAfter == null)
                    xd.DocumentElement.AppendChild(xe);
                else
                    xd.DocumentElement.InsertBefore(xe, xeAfter);


            }
            xe.SetAttribute("sort", sort.ToString());
            xe.SetAttribute("type", toc);
            xe.SetAttribute("titlee", titlee);
            xe.SetAttribute("titlef", titlef);
            if (superType != null)
                xe.SetAttribute("supertype", superType);
            if (filter != null)
                xe.SetAttribute("filter", filter);
            if (id != null)
                xe.SetAttribute("id", id);

        }
        internal void XmlAddTocACS(System.Xml.XmlDocument xd, int acSeriesId, string superType, int sort)
        {
            ActivityConfig.ACSeriesRow acsr = myA.AtMng.acMng.DB.ACSeries.FindByACSeriesId(acSeriesId);
            string toc="acs-"+acSeriesId.ToString();
            XmlAddToc(xd, toc, acsr.DescEng, acsr.DescFre, sort);

            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='"+toc+"']");
            xe.SetAttribute("supertype", superType);
        }
        internal static void XmlAddToc(atriumDB.EFileRow efr, string toc, string titlee, string titlef, int sort)
        {
            XmlAddToc(efr, toc, titlee, titlef, sort, null);
        }
        internal static void XmlAddToc(atriumDB.EFileRow efr, string toc, string titlee, string titlef, int sort, string id)
        {
            if (efr == null)
                return;
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = efr.FileStructXml;
            XmlAddToc(xd, toc, titlee, titlef, sort, id);
            efr.FileStructXml = xd.InnerXml;
        }
        public System.Xml.XmlNode CalcFileStructXml(atriumDB.EFileRow efr, bool isLoaded, bool child)
        {

           System.Xml.XmlDocument xd = new System.Xml.XmlDocument();

            if (child)
            {
                xd.InnerXml = "<toc></toc>";
                this.MyXml(efr, xd);
            }
            else
            {

                xd.InnerXml = DefaultXML;
                this.MyXml(efr, xd);



                if (efr.FileMetaTypeRow.HasTOC)
                {

                 
                    //special for office identity file
                    if (efr.FileType == "OF")
                    {
                        OfficeXML(efr, xd);
                    }
                   

                    if(myA.AtMng.GetSetting(AppBoolSetting.useCLASMngr))
                    {
                        CLASXML(efr, xd);
                    }

                    if (efr.FileType == "AV")
                    {
                        myA.GetAdvisoryMng().GetOpinion().MyXml(efr, xd);
                    }

                    //***for testing html/javascript based forms
                    //if (efr.FileType == "CL")
                    //{
                    //    EFileBE.XmlAddToc(xd, "s-11358084", "TOC", "TOC", 5);
                    //    System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='s-11358084']");
                    //    xe.SetAttribute("supertype", "efile");
                    //}

                  
                    if (efr.FileType == "PR") //Personal File TimeSlip
                    {
                        OfficeManager ofm = myA.AtMng.GetOffice();
                        officeDB.OfficerRow OfficerRow = ofm.GetOfficer().LoadByMyFileId(efr.FileId);
                        if (OfficerRow != null)
                        {
                            officeDB.OfficeRow OfficeRow = ofm.GetOffice().Load(OfficerRow.OfficeId);

                            if (OfficerRow != null && OfficerRow.UsesBilling && !OfficeRow.UsesBilling)
                                XmlAddToc(xd, "timeslip", "Timekeeping", "Comptabilisation du temps", 130);
                        }
                    }

                
                    //if(myA.DB.Appointment.Rows.Count>0)
                    //    XmlAddToc(xd, "appointment", "Calendar", "Calendrier", 119);

                    myA.GetFileOffice().MyXml(efr, xd);
                    myA.GetFileContact().MyXml(efr, xd);

                    if (myA.AtMng.GetSetting(AppBoolSetting.useSSTMngr))
                    {

                        SSTXML(efr, xd);

                    }
                 
                    if (this.myA.DB.RiskAssessment.Select("fileid=" + efr.FileId.ToString()).Length > 0)
                    {
                        EFileBE.XmlAddToc(xd, "riskassessment", "Legal Risk Management", "Gestion du risque juridique", 140);

                    }

                    if (efr.FileType == "AB" || efr.FileType == "AD" || efr.FileType == "AC" || efr.FileType == "CI" || efr.FileType == "CL")
                    {
                      
                        if (myA.DB.IRP.Select("FileId=" + efr.FileId.ToString()).Length > 0)
                        {
                            EFileBE.XmlAddToc(xd, "irp", "Taxation", "Taxation", 190);
                        }
                    }

                    //handle dynamic TOC!
                    appDB.ddTableRow[] dtrs =(appDB.ddTableRow[]) myA.AtMng.DB.ddTable.Select("ShowInTOC=1");
                    foreach(appDB.ddTableRow dtr in dtrs)
                    {
                        //is there any data?
                        if (myA.GetBEMngrForTable(dtr.TableName).MyDS.Tables[dtr.TableName].Rows.Count > 0)
                        {
                            int id = dtr.TableId;
                            if (!dtr.IstblGroupNull() && IsNumeric(dtr.tblGroup))
                                id = System.Convert.ToInt32(dtr.tblGroup);

                            //dynamic forms
                            if (!dtr.IsDefaultFormIDNull())
                            {
                                string superType = "EFile";
                                if (!dtr.IsFeatureIdNull())
                                {
                                    atSecurity.SecurityManager.Features f = (atSecurity.SecurityManager.Features)dtr.FeatureId;

                                    superType = f.ToString();
                                }
                                XmlAddTocACS(xd, dtr.DefaultFormID, superType, id);

                            }
                            else //basic links
                            {
                                XmlAddToc(xd, dtr.TableName.ToLower(), dtr.DescriptionEng, dtr.DescriptionFre, id);
                            }
                        }

                    }
                 

                }
            }


      
            return xd.DocumentElement;
        }

        private void SSTXML(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
            if (myA.GetSSTMng() != null)
                myA.GetSSTMng().GetFileParty().MyXml(efr, xd);


            if (myA.GetSSTMng() != null && this.myA.GetSSTMng().DB.SSTCase.Select("fileid=" + efr.FileId.ToString()).Length > 0)
            {

                SST.SSTCaseRow scr = (SST.SSTCaseRow)myA.GetSSTMng().DB.SSTCase.Select("fileid=" + efr.FileId.ToString())[0];
                myA.GetSSTMng().GetSSTCase().MyXml(scr, xd);
            }


            if (myA.GetSSTMng() != null && myA.GetSSTMng().DB.SSTRequest.Select("fileid=" + efr.FileId.ToString()).Length > 0)
            {
                EFileBE.XmlAddToc(xd, "sstrequest", "Correspondence Requests", "Demandes de correspondances", 111);
            }


            if (myA.GetSSTMng() != null && myA.GetSSTMng().DB.SSTDecision.Select("fileid=" + efr.FileId.ToString()).Length > 0)
            {
                EFileBE.XmlAddToc(xd, "sstdecision", "Tribunal Member Decisions", "Décisions de Membre du Tribunal", 112);
            }
            //if (myA.GetSSTMng().DB.FormHearing.Rows.Count > 0)
            //{
            //    XmlAddTocACS(xd, 105008, "SSTCase", 113);
            //    //XmlAddToc(xd, "acs-105008", "Form of Hearing", "Mode d'audience", 113);
            //    //System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='acs-105008']");
            //    //xe.SetAttribute("supertype", "SSTCase");
            //}
            //if (myA.GetSSTMng().DB.SSTAppealGround.Rows.Count > 0)
            //{
            //    XmlAddTocACS(xd, 105010, "SSTCase", 114);
            //    //XmlAddToc(xd, "acs-105010", "Appeal Grounds", "Moyens d'appel", 114);
            //    //System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='acs-105010']");
            //    //xe.SetAttribute("supertype", "SSTCase");
            //}
        }

     
        private void CLASXML(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
            if (efr.FileType == "AC" && myA.GetCLASMng() != null)
            {
                //myA.GetCLASMng().GetCashBlotter().LoadByFileID(efr.FileId);
                //JLL commented out above 2015-09-01 w/ move to webservice
                if (this.myA.GetCLASMng().DB.CashBlotter.Select("fileid=" + efr.FileId.ToString()).Length > 0)
                {
                    EFileBE.XmlAddToc(xd, "cashblotter", "Cash Blotter", "Registre de paiements", 120);


                }
            }
            if (efr.FileType == "AB" && myA.GetCLASMng() != null)
            {
                //myA.GetCLASMng().GetOfficeAccount().LoadByFileId(efr.FileId);
                if (myA.GetCLASMng().DB.OfficeAccount.Select("fileid=" + efr.FileId.ToString()).Length > 0)
                {
                    EFileBE.XmlAddToc(xd, "officeaccount", "Office Account", "Comptes de bureau", 180);
                }

                myA.GetSRP().LoadByFileId(efr.FileId);
                myA.GetSRP().MyXml(efr, xd);

                //this code is not needed anymore new srp is created on submit
                //if (this.myA.AtMng.officeMng.DB.SRP.Rows.Count == 0)
                //{
                //    myA.AtMng.officeMng.GetSRP().Add(efr);
                //}
                //else if (!this.myA.AtMng.officeMng.DB.SRP[0].IsSRPSubmittedDateNull())
                //{
                //    myA.AtMng.officeMng.GetSRP().Add(efr);
                //}

                //the following is unecessary in windows
                //int i = 0;
                //foreach (officeDB.SRPRow sr in ofm.DB.SRP.Select("FileId=" + efr.FileId.ToString(), "SRPDate desc"))
                //{
                //    i++;
                //    if (i >= 4)
                //    { break; }
                //    xe = xd.CreateElement("srp");
                //    xe.SetAttribute("srpid", sr.SRPID.ToString());
                //    xe.SetAttribute("srpdate", sr.SRPDate.ToString("yyyy/MM/dd"));
                //    xd.DocumentElement.AppendChild(xe);
                //    xe.AppendChild(xd.CreateElement("irp"));
                //    if (or.UsesBilling)
                //        xe.AppendChild(xd.CreateElement("br"));

                //}


            }

            if (myA.GetCLASMng() != null && myA.GetCLASMng().DB.FileHistory.Count > 0)
            {
                XmlAddToc(xd, "filehistory", "File History", "Cheminement de dossier", 130);
            }


            if (myA.GetCLASMng() != null)
                myA.GetCLASMng().GetHardship().MyXml(efr, xd);

            if (myA.GetCLASMng() != null && myA.GetCLASMng().DB.Taxing.Count > 0)
            {
                XmlAddToc(xd, "filetaxing", "Taxing recommendations", "Recommendations de taxation", 200,null,"taxing","fileid="+efr.FileId.ToString());
            }

            if (myA.GetCLASMng() != null)
                myA.GetCLASMng().GetJudgment().MyXml(efr, xd);

         
            if (myA.GetCLASMng() != null)
                myA.GetCLASMng().GetDebt().MyXml(efr, xd);

            if (myA.GetCLASMng() != null && myA.GetCLASMng().DB.CBDetail.Rows.Count > 0)
            {
                EFileBE.XmlAddToc(xd, "cbdetail", "Payments Received", "Paiements reçus", 110);
            }

         
            if (myA.GetCLASMng() != null)
                myA.GetCLASMng().GetBankruptcy().MyXml(efr, xd);

       
            if (myA.GetCLASMng() != null)
                myA.GetCLASMng().GetInsolvency().MyXml(efr, xd);

        
            //myA.GetCLASMng().GetCompOffer().MyXml(efr, xd);

        }

        private void OfficeXML(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
          
                OfficeManager ofm = myA.AtMng.GetOffice();
                officeDB.OfficeRow or = null;
                try
                {
                    or = ofm.GetOffice().LoadByOfficeFileIdNX(efr.FileId);
                }
                catch (Exception x)
                {
                    or = null;
                }
                if (or != null)
                {

                    ofm.GetOffice().MyXml(efr, xd, or);
                    DataRow drOffType;
                    WhereClause ow = new WhereClause();

                    ow.Add("OfficeTypeCode", "=", efr.LeadOfficeTypeCode);
                    DataTable dt = this.myA.Codes("OfficeType", ow, true);
                    drOffType = dt.Rows[0];

                    if (Convert.ToBoolean(drOffType["Billing"]) && myA.GetCLASMng() != null)
                    {
                        //myA.GetCLASMng().GetTaxing().LoadByOfficeID(or.OfficeId);
                        if (this.myA.GetCLASMng().DB.Taxing.Rows.Count > 0)
                        {
                            EFileBE.XmlAddToc(xd, "officetaxing", "All Taxing Recommendations", "Tous recommendations de taxation", 201, null,"taxing","OfficeId="+or.OfficeId.ToString());
                        }
                    }

                    if (ofm.GetServiceCentre().Load(or.OfficeId) != null)
                    {
                        XmlAddTocACS(xd, 104127, "Office", 500);
                        //XmlAddToc(xd, "acs-104127", "Service Centre", "Centre de service", 500);
                        //System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='acs-104127']");
                        //xe.SetAttribute("supertype", "Office");
                    }
                }
            
        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {

            System.Xml.XmlElement xe = xd.DocumentElement;

            xe.SetAttribute("titlee", String.Format("{0} ({1})", efr.NameE, efr.FileNumber));
            xe.SetAttribute("titlef", String.Format("{0} ({1})", efr.NameF, efr.FileNumber));

            //if (efr.IsFullFileNumberNull())
            //    xe.SetAttribute("titlee", efr.NameE);
            //else
            //    xe.SetAttribute("titlee", efr.FullFileNumber);

            xe.SetAttribute("tooltipe", efr.NameE);
            xe.SetAttribute("tooltipf", efr.NameF);
            xe.SetAttribute("type", "efile");
            xe.SetAttribute("id", efr.FileId.ToString());

            //xe.SetAttribute("fileid", efr.FileId.ToString());
            //xe.SetAttribute("filename", efr.NameE);
            //xe.SetAttribute("filenumber", efr.FileNumber);
            //xe.SetAttribute("filetype", efr.FileType);
            //if (!efr.IsParentFileIdNull())
            //{
            //    xe.SetAttribute("parentfileid", efr.ParentFileId.ToString());
            //}

            //if (!efr.IsFullPathNull())
            //    xe.SetAttribute("fullpath", efr.FullPath.ToString());


        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
            string ObjectName = this.myEFileDT.TableName;
            atriumDB.EFileRow dr = (atriumDB.EFileRow)ddr;
            switch (dc.ColumnName)
            {
                case EFileFields.LeadLawyerID:
                  //  SyncFileContact(dr, dr.LeadLawyerID, "FLL");
                    break;
                case EFileFields.LeadParalegalID:
                 //   SyncFileContact(dr, dr.LeadParalegalID, "FLPL");
                    break;
                case EFileFields.NameE:
                    if (dr.IsNameFNull() || dr.NameF == dr[dc, DataRowVersion.Current])
                    {
                        dr.NameF = dr.NameE;
                        dr.EndEdit();
                    }
                    string fp = null;
                    appDB.EFileSearchRow er1 = this.GetEfileParentRow(dr);
                    if (er1 == null & myA.ParentFile != null)
                    { fp = myA.ParentFile.CurrentFile.FullPath; }
                    else if (er1 != null)
                    { fp = er1.FullPath; }
                    if (fp != null)
                    {
                        dr.FullPath = fp + "\\" + dr.NameE;
                    }
                    break;
                case EFileFields.DescriptionE:
                    if (dr.IsDescriptionFNull() || dr.DescriptionF == dr[dc, DataRowVersion.Current])
                    {
                        dr.DescriptionF = dr.DescriptionE;
                        dr.EndEdit();
                    }
                    break;
                case EFileFields.NameF:
                    if (dr.IsNameENull())
                    {
                        dr.NameE = dr.NameF;
                        dr.EndEdit();
                    }
                    break;
                case EFileFields.DescriptionF:
                    if (dr.IsDescriptionENull() && !dr.IsDescriptionFNull())
                    {
                        dr.DescriptionE = dr.DescriptionF;
                        dr.EndEdit();
                    }
                    break;
                case EFileFields.StatusCode:
                    if (dr.StatusCode == "O" || dr.StatusCode == "R" || dr.StatusCode == "F")
                    {
                        dr.SetCloseCodeNull();
                        dr.SetClosedDateNull();
                        dr.EndEdit();
                    }
                    else if (dr.StatusCode == "C")
                    {
                        dr.ClosedDate = DateTime.Today;
                        //ARG
                        //do SST manager check before using it
                        if (myA.GetSSTMng() != null)
                        {
                            //SetReturnCode(ref dr);
                            SST.SSTCaseRow sstcr = myA.GetSSTMng().DB.SSTCase[0];
                            DataTable dt = myA.Codes("Outcome");
                            // CodesDB.OutcomeRow  ocr = (CodesDB.OutcomeRow )dt.Select("OutcomeId=" + sstcr.OutcomeId.ToString())[0];
                            if (!sstcr.IsOutcomeIdNull())
                            {
                                CodesDB.OutcomeRow ocr = myA.AtMng.CodeDB.Outcome.FindByOutcomeId(sstcr.OutcomeId);
                                dr.CloseCode = ocr.ReturnCode;
                                dr.EndEdit();
                            }
                        }
                    }
                    break;
                case "MetaType":
                case EFileFields.FileNumber:
                    appDB.EFileSearchRow er = this.GetEfileParentRow(dr);
                    string ffn = null, sk = null;
                    if (er == null && myA.ParentFile != null)
                    {
                        sk = myA.ParentFile.CurrentFile.SortKey;
                        ffn = myA.ParentFile.CurrentFile.FullFileNumber;
                    }
                    else if (er != null)
                    {
                        sk = er.SortKey;
                        ffn = er.FullFileNumber;
                    }
                    if (sk != null & !dr.IsNull(EFileFields.FileNumber))
                    {
                        ConcatFullFileNumber(ffn, dr);
                        //if (dr.FileMetaTypeRow.HasFileNumber)
                        //    dr.FullFileNumber = ffn + "-" + dr.FileNumber;
                        //else
                        //    dr.FullFileNumber = ffn;

                        int ipad = 16;
                        if (dr.FileNumber.IndexOf("(") > 0)
                            ipad = 16 + dr.FileNumber.Length - dr.FileNumber.IndexOf("(");
                        else if (dr.FileNumber.IndexOf(".") > 0)
                            ipad = 16 + dr.FileNumber.Length - dr.FileNumber.IndexOf(".");

                        dr.SortKey = sk + dr.FileNumber.PadLeft(ipad, '0');

                        dr.EndEdit();
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            string ObjectName = this.myEFileDT.TableName;
            atriumDB.EFileRow dr = (atriumDB.EFileRow)ddr;
            switch (dc.ColumnName)
            {
                case EFileFields.OpenedDate:
                    if (dr.IsOpenedDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.EFileOpenedDate);
                    
                    //myA.IsValidDate(atriumBE.Properties.Resources.EFileOpenedDate, dr.OpenedDate, false, DateTime.Today.AddYears(-15), DateTime.Today, atriumBE.Properties.Resources.Validation15yearsago, atriumBE.Properties.Resources.ValidationToday);

                    break;
                case EFileFields.FileNumber:
                    if (dr.IsNull(dc))
                        throw new RequiredException(dc.ColumnName);
                    if (dr.FileNumber.Length > 16)
                        throw new AtriumException("Filenumber must be 16 digits or less.");
                    break;
                case EFileFields.NameE:
                case EFileFields.NameF:
                case EFileFields.FullFileNumber:
                    if (dr.IsNull(dc))
                        throw new RequiredException(dc.ColumnName);

                    break;
                case EFileFields.ClosedDate:
                    if (!dr.IsClosedDateNull())
                        myA.IsValidDate(atriumBE.Properties.Resources.EFileClosedDate, dr.ClosedDate, false, dr.OpenedDate, DateTime.Today, atriumBE.Properties.Resources.EFileOpenedDate, atriumBE.Properties.Resources.ValidationToday);

                    break;
                case EFileFields.StatusCode:
                    if (dr.IsNull(dc))
                        throw new RequiredException(atriumBE.Properties.Resources.EFileStatusCode);
                    else if (!myA.CheckDomain(dr.StatusCode, myA.Codes("Status")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Status Code");

                    break;
                case EFileFields.CloseCode:
                    if (!dr.IsCloseCodeNull() && !myA.CheckDomain(dr.CloseCode, myA.Codes("ReturnCode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Closure Code");
                    break;
                case EFileFields.FileType:
                    if (!myA.CheckDomain(dr.FileType, myA.Codes("ChildFileType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "File Type");
                    break;
                case "LanguageCode":
                    if (!myA.CheckDomain(dr.LanguageCode, myA.Codes("LanguageCodeAll"))) // WI 74356
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Language Code");
                    break;
                case "MetaType":
                    if (!myA.CheckDomain(dr.MetaType, myA.Codes("ChildMetaType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Meta File Type");
                    break;
                case "LocationId":
                    if (!myA.CheckDomain(dr.LocationId, myA.Codes("Location")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Location");
                    break;
                case "Disposition":
                    if (!myA.CheckDomain(dr.DispositionId, myA.Codes("DispositionAuthority")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Disposition Authority");
                    break;
                case "Security":
                    if (!myA.CheckDomain(dr.Security, myA.Codes("SecurityLevel")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Security Level");
                    break;


                default:
                    break;
            }
        }

        //#region Implementation of ILookup
        //public override void FixLookups(System.Data.DataRow ddr)
        //{
        //    atriumDB.EFileRow dr = (atriumDB.EFileRow)ddr;

        //    if (!dr.IsLeadOfficeCodeNull())
        //        dr.LeadOfficeId = this.myA.AtMng.GetOffice(dr.LeadOfficeCode).CurrentOffice.OfficeId;
        //    if (!dr.IsNull("OwnerOfficeCode"))
        //        dr.OwnerOfficeId = this.myA.AtMng.GetOffice(dr.OwnerOfficeCode).CurrentOffice.OfficeId;

        //    OfficerBE ofr = this.myA.AtMng.GetOffice(dr.OwnerOfficeId).GetOfficer();
        //    if (!dr.IsLeadParalegalCodeNull())
        //        dr.LeadParalegalID = ofr.LookupId(dr.LeadParalegalCode);

        //}
        //#endregion
        protected override void BeforeUpdate(DataRow row)
        {
            atriumDB.EFileRow dr = (atriumDB.EFileRow)row;
            this.BeforeChange(dr.Table.Columns[EFileFields.StatusCode], dr);

            if(!dr.IsAdd2ImportantMsgNull())
            {
                if (dr.IsImportantMsgNull())
                    dr.ImportantMsg = dr.Add2ImportantMsg;
                else
                    dr.ImportantMsg += Environment.NewLine + dr.Add2ImportantMsg;

                dr.SetAdd2ImportantMsgNull();
            }
            if (dr.HasVersion(DataRowVersion.Original) && !dr["StatusCode", DataRowVersion.Original].Equals(dr["StatusCode", DataRowVersion.Current]) && "ACM".IndexOf(dr.StatusCode) > 0)
            {
                if (dr.StatusCode == "C" && myA.AtMng.GetSetting( AppBoolSetting.useSSTMngr ))
                {
                    myA.GetActivityBF().CompleteAllBFs(dr, true);
                    myA.GetDocMng().GetDocument().FinalizeAllDrafts(dr);
                }

                //check for incomplete bfs
                if (dr.StatusCode == "C" && this.myA.GetActivityBF().HasIncompleteBFs(dr, false))
                {
                    RaiseWarning(WarningLevel.Interrupt, atriumBE.Properties.Resources.EFileIncompleteBFs);
                }
                if (dr.StatusCode == "M" && this.myA.GetActivityBF().HasIncompleteBFs(dr, true))
                    RaiseWarning(WarningLevel.Interrupt, atriumBE.Properties.Resources.UncompletedBFWarning);

                //check for unreturned file
                if (myA.GetCLASMng() != null && this.myA.GetCLASMng().GetFileHistory().GetCurrentRow().Length > 0)
                    throw new AtriumException(atriumBE.Properties.Resources.FileNotReturned);

                //check for assigned accounts
                if (dr.FileType == "CL" && myA.GetCLASMng() != null)
                {
                    foreach (CLAS.DebtRow debt in myA.GetCLASMng().DB.Debt)
                    {
                        if (debt.ActiveWithJustice)
                            throw new AtriumException(atriumBE.Properties.Resources.AccountsStillAssigned);
                    }
                }
            }

            if (dr.RowState == DataRowState.Added & myA.ParentFile != null)
            {

                atriumDB.EFileRow pdr = myA.ParentFile.CurrentFile;
                if (pdr.FileMetaTypeRow.SubFileAutoNumber & !myA.IsFileNumberAssigned)
                    AssignFileNumber(pdr, dr);
            }

            this.BeforeChange(dr.Table.Columns["FileNumber"], dr);

            //if(dr.GetFileContactRows().Length==0)
            //    myA.GetFileContact().LoadByFileId(dr.FileId);

            //if (dr.RowState == DataRowState.Added || (dr.HasVersion(DataRowVersion.Original) && !dr["StatusCode", DataRowVersion.Current].Equals(dr["StatusCode", DataRowVersion.Original])))
            //{
            //    //todo: fix
            //    this.AssignOfficer(dr);
            //}
            //else
            //{
            //    if (!dr.IsLeadParalegalIDNull())
            //        SyncFileContact(dr, dr.LeadParalegalID, "PL");
            //    if (!dr.IsLeadLawyerIDNull())
            //        SyncFileContact(dr, dr.LeadLawyerID, "LA");
            //}
            //if(myA.IsFieldChanged(myEFileDT.LeadOfficeIdColumn ,dr))
            //{
            //    //update all bf's for the old office to the new office
            //    //myA.DAL.ExecuteSP("ActivityBFChangeForOffice",dr["LeadOfficeId",DataRowVersion.Original] ,dr.LeadOfficeId);
            //    myA.GetActivityBF();
            //    foreach (atriumDB.ActivityBFRow abr in myA.DB.ActivityBF)
            //    {
            //        if (!abr.Completed & abr.BFType == 1 & abr.ForOfficeId == (int)dr["LeadOfficeId", DataRowVersion.Original])
            //        {
            //            abr.ForOfficeId = dr.LeadOfficeId;
            //        }
            //    }

            //}

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            if (dr.IsFileStructXmlNull() || dr.FileStructXml == "")
                xd.InnerXml = DefaultXML;
            else
                xd.InnerXml = dr.FileStructXml;
            MyXml(dr, xd);
            dr.FileStructXml = xd.InnerXml;



        }


        protected override void BeforeDelete(DataRow dr)
        {
            if (!CanDelete(dr))
            {
                throw new AtriumException(Properties.Resources.EFileNoDelete);
            }


        }
        protected override void BeforeAdd(DataRow row)
        {
            //atriumDB.EFileRow dr = (atriumDB.EFileRow)row;

            //atriumDB.EFileRow pdr = myA.ParentFile.CurrentFile;

            //if (!(pdr.FileMetaTypeRow.AllowSubFiles | pdr.FileMetaTypeRow.AllowPockets))
            //{
            //    throw new AtriumException(Properties.Resources.EFileParentFileDoesNotAllowSubFiles);

            //}

        }
        protected override void AfterAdd(DataRow row)
        {
            atriumDB.EFileRow dr = (atriumDB.EFileRow)row;
            string ObjectName = this.myEFileDT.TableName;

            dr.FileId = this.myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TemporarilyRecalled = false;
            dr.Essential = true;
            dr.StatusCode = "O";
            dr.OpenedDate = DateTime.Today;
            dr.LanguageCode = myA.AppMan.Language.Substring(0, 1);
            dr.RebuildTOC = false;
            dr.SubFileNumMin = 1;
            dr.LocationId = 1;

            atriumDB.EFileRow pdr = myA.ParentFile.CurrentFile;
            if (pdr != null)
            {
                //if (pdr.FileMetaTypeRow.SubFileAutoNumber == true)
                //{
                //    AssignFileNumber(pdr, dr);
                //}
                dr.MetaType = pdr.FileMetaTypeRow.SubFileMetaType;
                if (pdr.FileTypeRow.IsChildFileTypeNull())
                    dr.FileType = pdr.FileType;
                else
                    dr.FileType = pdr.FileTypeRow.ChildFileType;
                dr.RiskManage = pdr.RiskManage;
                dr.RiskManageChildren = pdr.RiskManageChildren;
                //dr.HaveSubFolder = pdr.HaveSubFolder;
                //dr.HaveFile = pdr.HaveFile;

                dr.Security = pdr.Security;

                //UpdateFullPath(dr);

                dr.LeadOfficeId = myA.AtMng.WorkingAsOfficer.OfficeId;// pdr.LeadOfficeId;
                dr.LeadOfficeTypeCode = myA.AtMng.WorkingAsOfficer.OfficeRow.OfficeTypeCode;// pdr.LeadOfficeTypeCode;
                dr.OwnerOfficeId = pdr.OwnerOfficeId;
                //dr.SubFileAutoNumber = pdr.SubFileAutoNumber;
                //dr.SubFileNumSize = pdr.SubFileNumSize;
                //dr.SubFileNumIncrement = pdr.SubFileNumIncrement;

                //myA.ParentFile.GetFileOffice().LoadByFileId(pdr.FileId);
                atriumDB.FileOfficeRow[] drsFO;
                switch (dr.FileType)
                {
                    case "IR":
                    case "IL":
                    case "IA":
                        drsFO = (atriumDB.FileOfficeRow[])myA.ParentFile.DB.FileOffice.Select("(accesstype='OO' or officeid=" + this.myA.AtMng.OfficeLoggedOn.OfficeId.ToString() + ") and fileid=" + pdr.FileId);
                        break;
                    default:
                        drsFO = (atriumDB.FileOfficeRow[])myA.ParentFile.DB.FileOffice.Select("fileid=" + pdr.FileId);
                        break;
                }
                foreach (atriumDB.FileOfficeRow drfo in drsFO)
                {
                    atriumDB.FileOfficeRow fodr = (atriumDB.FileOfficeRow)this.myA.GetFileOffice().Add(dr);
                    fodr.BeginEdit();
                    fodr.FileId = dr.FileId;
                    fodr.OfficeId = drfo.OfficeId;
                    fodr.IsOwner = drfo.IsOwner;
                    if (drfo.OfficeId == dr.LeadOfficeId)
                        fodr.IsLead = true;
                    else
                        fodr.IsLead = false;
                    fodr.IsClient = drfo.IsClient;
                    fodr.IsAgent = drfo.IsAgent;
                    fodr.PercentAlloc = drfo.PercentAlloc;
                    //fodr.AccessType = drfo.AccessType;
                    //if(drfo.AccessType=="OO" && !dr.IsFullFileNumberNull())
                    //    fodr.OfficeFileNum=dr.FullFileNumber;

                    if ( !drfo.IsOrderNumberNull())
                    {
                        //copy OrderNumber
                        fodr.OrderNumber = drfo.OrderNumber;

                    }
                    fodr.EndEdit();

                }
            }
            else
            {

                atriumDB.FileOfficeRow fodr = (atriumDB.FileOfficeRow)this.myA.GetFileOffice().Add(dr);
                fodr.BeginEdit();
                fodr.FileId = dr.FileId;
                fodr.OfficeId = this.myA.AtMng.OfficeLoggedOn.OfficeId;
                fodr.IsOwner = true;
                //fodr.AccessType = "OO";
                fodr.EndEdit();
            }

        }


        public void AssignFileNumber(atriumDB.EFileRow pdr, atriumDB.EFileRow dr)
        {
            int iMax = pdr.SubFileNumMin;

            //check to see the max filenumber used in block
            appDB.EFileSearchDataTable dt = myA.AtMng.FileSearchByParentFileId(pdr.FileId);
            foreach (appDB.EFileSearchRow efr in dt)
            {
                if (efr.LinkType == (int)FXLinkType.ParentChild && IsNumeric(efr.FileNumber) && Convert.ToInt32(efr.FileNumber) > iMax)
                {
                    iMax = Convert.ToInt32(efr.FileNumber);
                }
            }
            //object maxId = dt.Compute("Max(FileNumber)", "");
            //if (maxId.GetType() == typeof(string) && IsNumeric((string)maxId))
            //{
            //    iMax = System.Convert.ToInt32(maxId) + pdr.FileMetaTypeRow.SubFileNumIncrement;
            //}

            int o = 0;
            bool notInPKID = false;
            try
            {
                o = this.myA.AtMng.PKIDGet("PF+" + pdr.FileId.ToString(), pdr.FileMetaTypeRow.SubFileNumIncrement);
                if (o <= iMax)
                {
                    //we need to fix pkid as it is out of sync
                    int dif = iMax - o;
                    if(dif>0)
                        this.myA.AtMng.PKIDGet("PF+" + pdr.FileId.ToString(), dif);

                    o = this.myA.AtMng.PKIDGet("PF+" + pdr.FileId.ToString(), pdr.FileMetaTypeRow.SubFileNumIncrement);
                }
            }
            catch (Exception x)
            {
                myA.AtMng.LogError(x);
                notInPKID = true;
            }
            if(notInPKID)
            {
                myA.AtMng.PKIDSet("PF+" + pdr.FileId.ToString(), iMax);

                o = this.myA.AtMng.PKIDGet("PF+" + pdr.FileId.ToString(), pdr.FileMetaTypeRow.SubFileNumIncrement);

            }
            dr.FileNumber = o.ToString();

            //we are getting rid of padding
            //int fnlength = dr.FileNumber.Length;
            //for (int i=0; i< pdr.FileMetaTypeRow.SubFileNumSize-fnlength;i++)
            //    dr.FileNumber = "0" + dr.FileNumber;
            ConcatFullFileNumber(pdr.FullFileNumber, dr);

            myA.IsFileNumberAssigned = true;

        }

        private static void ConcatFullFileNumber(string ffn, atriumDB.EFileRow dr)
        {
            if (dr.FileMetaTypeRow.HasFileNumber)
            {
                if (ffn != null && ffn != "")
                    dr.FullFileNumber = ffn + "-" + dr.FileNumber;
                else
                    dr.FullFileNumber = dr.FileNumber;
            }
            else if (ffn != null && ffn != "")
                dr.FullFileNumber = ffn;
            else if (ffn == "" && dr.IsFullFileNumberNull())
                dr.FullFileNumber = ffn; //can't let it be null
        }

        //public void RenumberAllChildren(atriumDB.EFileRow dr)
        //{
        //    this.LoadByParentFileId(dr.FileId);
        //    dr.BeginEdit();
        //    foreach(atriumDB.EFileRow drChild in dr.GetEFileRows())
        //    {
        //        drChild.BeginEdit();
        //        AssignFileNumber(dr,drChild);
        //        drChild.EndEdit();
        //    }
        //    dr.EndEdit();
        //}

        //public void AssignOfficer(atriumDB.EFileRow dr)
        //{
        //    bool okPL = true;
        //    bool okLA = true;
        //    bool okOfficer = true;
        //    foreach (atriumDB.FileContactRow fcdr in dr.GetFileContactRows())
        //    {
        //        if (!fcdr.NoReassign)
        //        {
        //            //AssignOfficer(dr, fcdr.ContactType);
        //            if (fcdr.ContactType == myA.AtMng.GetSetting(AppStringSetting.LeadPLContactType))
        //                okPL = false;

        //            if (fcdr.ContactType == myA.AtMng.GetSetting(AppStringSetting.LeadLawyerContactype))
        //                okLA = false;

        //            if (fcdr.ContactType == myA.AtMng.GetSetting(AppStringSetting.OfficerContactType))
        //                okOfficer = false;
        //        }
        //    }

        //    if (okPL)
        //        AssignOfficer(dr, myA.AtMng.GetSetting(AppStringSetting.LeadPLContactType));

        //    if (okLA)
        //        AssignOfficer(dr, myA.AtMng.GetSetting(AppStringSetting.LeadLawyerContactype));

        //    if (okOfficer)
        //        AssignOfficer(dr, myA.AtMng.GetSetting(AppStringSetting.OfficerContactType));
        //}

        //private void AssignOfficer(atriumDB.EFileRow dr, string contactType)
        //{
        //    int officerId = GetOfficerForContactType(dr, contactType);

        //    if (officerId == 0)
        //    {
        //        //this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.OfficerNotAssigned,dr.FileId.ToString());
        //    }
        //    else
        //    {
        //        if (contactType == myA.AtMng.GetSetting(AppStringSetting.LeadPLContactType))
        //            dr.LeadParalegalID = officerId;
        //        else if (contactType == myA.AtMng.GetSetting(AppStringSetting.LeadLawyerContactype))
        //            dr.LeadLawyerID = officerId;
        //        else if (contactType == myA.AtMng.GetSetting(AppStringSetting.OfficerContactType))
        //            dr.OfficerId = officerId;
        //        // this.SyncFileContact(dr, officerId, contactType);
        //    }


        //}

        public int GetOfficerForContactType(atriumDB.EFileRow dr, string contactType)
        {
            Object[] obj = new Object[8];
            int officerId = 0;
            object tempId;

            obj[0] = dr.LeadOfficeId;
            obj[1] = dr.StatusCode;
            obj[2] = dr.OwnerOfficeId;
            obj[3] = dr.FileType;
            if (dr.IsLeadOfficeTypeCodeNull())
                obj[4] = "";
            else
                obj[4] = dr.LeadOfficeTypeCode;

            obj[5] = dr.FileId.ToString();  //was filenumber
            obj[6] = contactType;
            obj[7] = dr.LanguageCode;

            tempId = this.myA.AppMan.ExecuteScalar("PLOfficeIDGet", obj);
            if (tempId != DBNull.Value && tempId!=null)
                officerId = (int)tempId;
            else
                officerId = 0;
            return officerId;
        }

        //we will always add it though filecontact
        //private void SyncFileContact(atriumDB.EFileRow dr, int officerId, string contactType)
        //{
        //    bool notFound = true;
        //    //if (dr.GetFileContactRows().Length == 0)
        //    //    myA.GetFileContact().LoadByFileId(dr.FileId);

        //    foreach (atriumDB.FileContactRow fcdr in dr.GetFileContactRows())
        //    {
        //        if (!fcdr.IsNull("ContactType") && fcdr.ContactType == contactType)
        //        {
        //            fcdr.ContactId = officerId;
        //            notFound = false;
        //        }
        //    }


        //    if (notFound)
        //    {
        //        atriumDB.FileContactRow fcdr = (atriumDB.FileContactRow)this.myA.GetFileContact().Add(dr);
        //        fcdr.BeginEdit();
        //        fcdr.ContactId = officerId;
        //        fcdr.ContactType = contactType;
        //        fcdr.EndEdit();
        //    }

        //}
    
        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[] { this.myA.CurrentFile };
        //}


        public override DataRow[] GetCurrentRow()
        {
            return new DataRow[] { this.myA.CurrentFile };
        }


        public bool IsFileReceived()
        {
            if (myA.GetCLASMng() != null)
            {
                if (this.myA.AtMng.WorkingAsOfficer.OfficeId == myA.CurrentFile.LeadOfficeId && this.myA.AtMng.WorkingAsOfficer.OfficeId != myA.CurrentFile.OwnerOfficeId)
                {
                    if (this.myA.GetCLASMng().GetFileHistory().GetCurrentRow().Length == 0)
                        return true;
                    else
                    {
                        if (((CLAS.FileHistoryRow)this.myA.GetCLASMng().GetFileHistory().GetCurrentRow()[0]).IsReceivedByOfficeDateNull())
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                }
                else
                    return true;
            }
            else
                return true;
        }

        public int LookupId(string FileNumber)
        {
            return this.LoadByFullFileNumber(FileNumber).FileId;
        }

        public void BreakInherit()
        {

            lmDatasets.atriumDB.FileXRefRow pxr = GetParentFileXref(myA.CurrentFile);
            pxr.secBreakInherit = true;
            try
            {
                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(myA.GetFileXRef());
                bp.Update();

                
            }
            catch (Exception x)
            {
                pxr.RejectChanges();
              //  myA.AtMng.AppMan.Rollback();
                throw;
            }
            myA.GetsecFileRule().LoadByFileId(myA.CurrentFile.FileId);

        }

        public void UnBreakInherit()
        {

            lmDatasets.atriumDB.FileXRefRow pxr = GetParentFileXref(myA.CurrentFile);
            pxr.secBreakInherit = false;
            try
            {
                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(myA.GetFileXRef());
                bp.Update();

            }
            catch (Exception x)
            {
                pxr.RejectChanges();
              //  myA.AtMng.AppMan.Rollback();
                throw;
            }
            myA.GetsecFileRule().PreRefresh();
            myA.GetsecFileRule().LoadByFileId(myA.CurrentFile.FileId);

        }

        public static string FixPath(string path)
        {
            if (!path.EndsWith("\\"))
                path += "\\";

            path = path.Replace("'", "''");

            return path;

        }
        //public void VerifyFolders(atriumDB.EFileRow er, bool deep)
        //{

        //    //check for too long path
        //    if (er.FullPath.Length >= 248)
        //        return;

        //    //check documents 
        //    myA.GetDocMng().GetDocument().VerifyDocuments(er);

        //    //load sub-files
        //    this.LoadByParentFileId(er.FileId);
        //    //load fileoffice records first -- should only be done once per folder but are only needed for adding
        //    myA.GetFileOffice().LoadByFileId(er.FileId);

        //    //get sub directories
        //    string[] dirs = System.IO.Directory.GetDirectories(er.FullPath);

        //    //check for mis-matches
        //    foreach (string dir in dirs)
        //    {

        //        string tmpDir = FixPath(dir);
        //        if (tmpDir.Length > 248)
        //        {
        //            System.Diagnostics.Trace.WriteLine(dir);
        //        }
        //        else if (this.myEFileDT.Select("FullPath='" + tmpDir + "'").Length == 0)
        //        {
        //            //********************************************
        //            //add efile record if file system is master copy
        //            //********************************************
        //            atriumDB.EFileRow newFile = (atriumDB.EFileRow)this.Add(er);

        //            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(tmpDir);
        //            string fileNum = "";
        //            //concat numeric folder names
        //            if (IsNumeric(di.Name))
        //            {
        //                fileNum = di.Name;
        //                if (di.GetFiles().Length == 0)
        //                {
        //                    //return;
        //                }
        //                else
        //                {
        //                    //concat all numeric parents

        //                }
        //            }
        //            else if (di.Name.IndexOf(" ") > 0 && IsNumeric(di.Name.Substring(0, di.Name.IndexOf(" "))))
        //            {
        //                fileNum = di.Name.Substring(0, di.Name.IndexOf(" "));
        //            }

        //            newFile.BeginEdit();
        //            newFile.NameE = di.Name;
        //            newFile.FileStructXml = "";
        //            newFile.NameF = newFile.NameE;
        //            newFile.FileType = "F";
        //            newFile.OpenedDate = FixSQLDateLow(di.CreationTime);
        //            newFile.StatusCode = "O";
        //            if (fileNum.Length > 0)
        //                newFile.FileNumber = fileNum;

        //            newFile.FullPath = tmpDir;
        //            newFile.EndEdit();
        //            newFile.FullPath = tmpDir;

        //            Update();

        //            myA.GetFileOffice().Update();
        //            myA.GetFileContact().Update();

        //            myA.AtMng.AppMan.Commit();
        //            myA.DB.AcceptChanges();


        //        }
        //    }

        //    atriumDB.EFileRow[] subFiles = GetEFileRows(er);
        //    foreach (atriumDB.EFileRow subFile in subFiles)
        //    {
        //        if (subFile.FullPath.Length < 248)
        //        {
        //            if (!System.IO.Directory.Exists(subFile.FullPath))
        //            {
        //                //************************************
        //                //create folder if db is master copy
        //                //************************************
        //                //System.IO.Directory.CreateDirectory(subFile.FullPath);
        //            }
        //            if (deep)
        //            {
        //                try
        //                {
        //                    VerifyFolders(subFile, deep);
        //                }
        //                catch (Exception x)
        //                {
        //                    System.Diagnostics.Trace.WriteLine(x.Message);
        //                }
        //            }
        //        }
        //        myEFileDT.RemoveEFileRow(subFile);
        //        myA.DB.AcceptChanges();
        //    }

        //}

        public override bool CanDelete(DataRow dr)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)dr;
            return AllowDelete || myA.AtMng.SecurityManager.CanDelete(er.FileId, EfileFeature(er.MetaType)) > atSecurity.SecurityManager.LevelPermissions.No;
        }

        public static atSecurity.SecurityManager.Features EfileFeature(string metaType)
        {
            atSecurity.SecurityManager.Features feat;
            switch (metaType)
            {
                case "RT":
                    feat = atSecurity.SecurityManager.Features.EfileRT;
                    break;
                case "PX":
                    feat = atSecurity.SecurityManager.Features.EfilePX;
                    break;
                case "PT":
                    feat = atSecurity.SecurityManager.Features.EfilePT;
                    break;
                case "SN":
                case "SA":
                    feat = atSecurity.SecurityManager.Features.EfileSN;
                    break;
                default:
                    feat = atSecurity.SecurityManager.Features.Efile;
                    break;
            }
            return feat;
        }
        public override bool CanAdd(DataRow parent)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)parent;

            //JLL: 2009/07/24 If parent file was just added (e.g. creating office file), cannot check against database - file isn't there yet
            // assume return true for now
            if (er.RowState == DataRowState.Added)
            { return true; }

            if (!(er.FileMetaTypeRow.AllowSubFiles | er.FileMetaTypeRow.AllowPockets))
            {
                return false;
                //throw new AtriumException(Properties.Resources.EFileParentFileDoesNotAllowSubFiles);

            }

            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(er.FileId, EfileFeature(er.MetaType)) > atSecurity.SecurityManager.ExPermissions.No;
        }
        public override bool CanEdit(DataRow dr)
        {
            atriumDB.EFileRow er = (atriumDB.EFileRow)dr;
            return AllowEdit || myA.AtMng.SecurityManager.CanUpdate(er.FileId, EfileFeature(er.MetaType)) > atSecurity.SecurityManager.LevelPermissions.No;
        }
        public static bool IsNumeric(string test)
        {
            char[] cTest = test.ToCharArray();
            foreach (char c in cTest)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public static DateTime FixSQLDateLow(DateTime d)
        {
            if (System.Data.SqlTypes.SqlDateTime.MinValue.Value.CompareTo(d) > 0)
                return System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            else
                return d;

        }

        public static DateTime FixSQLSmallDateLow(DateTime d)
        {
            if (DateTime.Parse("1900/1/1").CompareTo(d) > 0)
                return DateTime.Parse("1900/1/1");
            else
                return d;

        }

        public void AppendToImportantMessage(string MessageText)
        {
            if (myA.CurrentFile.IsImportantMsgNull())
            {
                myA.CurrentFile.ImportantMsg = MessageText;
            }
            else
            {
                string currentImportantMessage = myA.CurrentFile.ImportantMsg;
                int startPoint = currentImportantMessage.IndexOf(MessageText);
                if (startPoint > -1) //Message already appears in Important Message field, don't bother adding it again
                    return;
                else //append to current Important Message field
                    myA.CurrentFile.ImportantMsg += Environment.NewLine + MessageText;
            }
            myA.CurrentFile.ImportantMsg = myA.CurrentFile.ImportantMsg.Trim();
        }
        public void RemoveFromImportantMessage(string MessageText)
        {
            if (myA.CurrentFile.IsImportantMsgNull()) //Nothing to remove, we're done here
                return;

            string currentImportantMessage = myA.CurrentFile.ImportantMsg;

            if (currentImportantMessage == MessageText)
                myA.CurrentFile.SetImportantMsgNull();
            else
            {
                int startPoint = currentImportantMessage.IndexOf(MessageText);
                int MessageTextLength = MessageText.Length;
                if (startPoint > -1) //found MessageText in ImportantMessage field - remove it
                {
                    string newMessageText = currentImportantMessage.Remove(startPoint, MessageTextLength);
                    myA.CurrentFile.ImportantMsg = newMessageText.Trim();
                }
                myA.CurrentFile.ImportantMsg = myA.CurrentFile.ImportantMsg.Trim();
            }
        }

    }
}

