using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class FileContactBE : atLogic.ObjectBE
    {
        FileManager myA;
        atriumDB.FileContactDataTable myFileContactDT;

        internal FileContactBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileContact)
        {
            myA = pBEMng;
            myFileContactDT = (atriumDB.FileContactDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileContact();
        }
        public atriumDAL.FileContactDAL myDAL
        {
            get
            {
                return (atriumDAL.FileContactDAL)myODAL;
            }
        }

        public void LoadByFileId(int fileId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().FileContactLoadByFileId(fileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByFileId(fileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByFileId(fileId));
                }
            }
        }


        /// <summary>
        /// Calls DebtorExists SP which verifies if contact has an opponent(debtor) record, i.e. Is an opponent on a file somewhere
        /// </summary>
        /// <param name="ContactId">ContactID</param>
        /// <returns>True if the contact is a debtor</returns>
        public bool IsADebtor(int ContactId)
        {
            try
            {
                return (int)myA.AtMng.AppMan.ExecuteScalar("DebtorExists", ContactId) > 0;
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                return (int)myA.AtMng.AppMan.ExecuteScalar("DebtorExists", ContactId) > 0;
            }

        }

        /// <summary>
        /// Calls FileContactCountByContactId SP which verifies if contact is shared across files, i.e. Has multiple FileContact records
        /// </summary>
        /// <param name="ContactId">ContactID</param>
        /// <returns>Count of FileContact records</returns>
        public int FileContactCount(int ContactId)
        {
            try
            {
                return (int)myA.AtMng.AppMan.ExecuteScalar("FileContactCountByContactId", ContactId);
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                return (int)myA.AtMng.AppMan.ExecuteScalar("FileContactCountByContactId", ContactId);
            }

        }


        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)dr;
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = fcr.EFileRow.FileStructXml;
            MyXml(fcr, xd);
            fcr.EFileRow.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        protected override void BeforeDelete(DataRow dr)
        {
            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)dr;

            if (!fcr.HideInToc)
            {
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.InnerXml = fcr.EFileRow.FileStructXml;
                System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='contact' and @id=" + fcr.FileContactid.ToString() + "]");
                RemoveFileContactFromXML(xe);
                fcr.EFileRow.FileStructXml = xd.InnerXml;
            }

            if (!fcr.IsNull("ContactType") && !fcr.IsNull("ContactId"))
            {
                if (fcr.ContactType == myA.AtMng.GetSetting(AppStringSetting.LeadPLContactType))
                {
                    fcr.EFileRow.SetLeadParalegalIDNull();
                    fcr.EFileRow.EndEdit();
                }
                if (fcr.ContactType == myA.AtMng.GetSetting(AppStringSetting.LeadLawyerContactype))
                {
                    fcr.EFileRow.SetLeadLawyerIDNull();
                    fcr.EFileRow.EndEdit();
                }
            }
        }

        private void RemoveFileContactFromXML(System.Xml.XmlElement xe)
        {

            if (xe != null && xe.ParentNode != null)
            {
                System.Xml.XmlElement parentNode = (System.Xml.XmlElement)xe.ParentNode;
                System.Xml.XmlNode removedNode = xe.ParentNode.RemoveChild(xe);
                if (parentNode.ChildNodes.Count == 0 && parentNode.ParentNode != null) //remove parent as well, nothing left below it
                    parentNode.ParentNode.RemoveChild(parentNode);
            }
        }

        private void MyXml(atriumDB.FileContactRow fcr, System.Xml.XmlDocument xd)
        {
            try
            {
                //JLL: MODIFIED 2009/07/24: take FileContact.Active into account - remove where not active
                bool removeNode = false;
                if (!fcr.HideInToc)
                {
                    System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='contact' and @id=" + fcr.FileContactid.ToString() + "]");

                    if (!fcr.Active)
                        removeNode = true;
                    else if (xe == null)
                    {
                        xe = xd.CreateElement("toc");
                        xe.SetAttribute("supertype", "contact");
                    }


                    if (removeNode)
                        RemoveFileContactFromXML(xe);
                    else
                    {

                        xe.SetAttribute("id", fcr.FileContactid.ToString());
                        //if (fcr.IsLastNameNull())
                        //{
                        //    xe.SetAttribute("titlee", String.Format(atriumRes.FileContactXmlTitle + " (" + fcr.ContactTypeDescEng.ToString() + ")", fcr.LegalName, ""));
                        //    xe.SetAttribute("titlef", String.Format(atriumRes.FileContactXmlTitle + " (" + fcr.ContactTypeDescFre.ToString() + ")", fcr.LegalName, ""));
                        //}
                        //else
                        //{
                        //    xe.SetAttribute("titlee", String.Format(atriumRes.FileContactXmlTitle + " (" + fcr.ContactTypeDescEng.ToString() + ")", fcr.LastName, fcr.FirstName));
                        //    xe.SetAttribute("titlef", String.Format(atriumRes.FileContactXmlTitle + " (" + fcr.ContactTypeDescFre.ToString() + ")", fcr.LastName, fcr.FirstName));
                        //}

                        xe.SetAttribute("titlee", String.Format(atriumRes.FileContactXmlTitle + " (" + fcr.ContactTypeDescEng.ToString() + ")", fcr.DisplayName, ""));
                        xe.SetAttribute("titlef", String.Format(atriumRes.FileContactXmlTitle + " (" + fcr.ContactTypeDescFre.ToString() + ")", fcr.DisplayName, ""));

                        if (fcr.ContactType == "FDB")
                        {
                            CLAS.DebtorRow debtor = myA.GetCLASMng().GetDebtor().CurrentDebtor;

                            xe.SetAttribute("type", "opponent");
                            //check for Contact/Notes
                            if (debtor != null && !debtor.IsNotesNull())
                            {
                                //tweek title
                                xe.SetAttribute("titlee", "*** " + xe.GetAttribute("titlee") + " ***");
                                xe.SetAttribute("titlef", "*** " + xe.GetAttribute("titlef") + " ***");
                                xe.SetAttribute("bold", "true");
                                xe.SetAttribute("tooltipe", "There are notes");
                                xe.SetAttribute("tooltipf", "Il y a des notes");
                            }
                            else
                            {
                                xe.SetAttribute("bold", "false");
                                xe.SetAttribute("tooltipe", "");
                                xe.SetAttribute("tooltipf", "");
                            }
                            //2014-06-11
                            //JLL
                            //calculate address country to determine icon
                            //assumes data is already loaded
                            //DOES NOT WORK WHEN OPENING A FILE; CONTACT ROW IS NULL ... ARG
                            if (debtor != null && !debtor.IsAddressCurrentIDNull())
                            {
                                atriumDB.AddressRow dbAddress = myA.DB.Address.FindByAddressId(debtor.AddressCurrentID);
                                if (dbAddress != null)
                                {
                                    string country = dbAddress.CountryCode;
                                    switch (country)
                                    {
                                        case "CDN":
                                            xe.SetAttribute("icon", "34");
                                            break;
                                        case "USA":
                                            xe.SetAttribute("icon", "35");
                                            break;
                                        default:
                                            xe.SetAttribute("icon", "36");
                                            break;
                                    }
                                }
                            }
                        }
                        else
                            xe.SetAttribute("type", "contact");

                        if (xe.GetAttribute("isParticipant") != "true" && !fcr.IsOfficeIdNull())
                            xe.SetAttribute("icon", "43"); //atrium officer; not necessarily a user

                        if (xe.ParentNode == null)
                        {
                            System.Xml.XmlElement xes = null;
                            if (fcr.IsOfficeIdNull())
                            {
                                xes = EFileBE.XmlAddFld(xd, "basecontacts", "Contacts", "Contacts", 210);
                                xes.AppendChild(xe);
                            }
                            else
                            {

                                System.Xml.XmlElement xe1 = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='fileoffice' and @officeid=" + fcr.OfficeId.ToString() + "]");
                                if (xe1 != null)
                                {
                                    xe1.AppendChild(xe);
                                }
                                else
                                {
                                    xes = EFileBE.XmlAddFld(xd, "basecontacts", "Contacts", "Contacts", 210);
                                    xes.AppendChild(xe);
                                }
                                //xes.AppendChild(xe);

                                //xes = EFileBE.XmlAddFld(xe1, "contacts", "Contacts", "Contacts", 320);
                                //else

                                //{
                                //JLL: Bug 2009/07/24
                                //When new contact is added through process (CM03.02), and no File Office record is present, 
                                // it sticks File Contact record on first "contact" match on filestructxml document
                                //    xes = EFileBE.XmlAddFld(xd, "contacts", "Contacts", "Contacts", 320);
                                //}
                            }
                            //xes.AppendChild(xe);
                        }
                    }
                }
            }
            catch (Exception x)
            { }
        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {

            foreach (atriumDB.FileContactRow fcr in efr.GetFileContactRows())
            {
                MyXml(fcr, xd);
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.FileContactRow dr = (atriumDB.FileContactRow)row;
            string ObjectName = this.myFileContactDT.TableName;

            dr.FileContactid = this.myA.AtMng.PKIDGet(ObjectName, 10);
            dr.StartDate = DateTime.Today;
            dr.Active = true;
            dr.NoReassign = false;
            dr.AllowAdministrativeEmail = false;
            dr.HideInToc = false;
            dr.CallCount = 0;
            dr.InterpreterBooked = false;
            //if(!dr.EFileRow.IsOpponentIDNull())
            //    dr.ContactId=dr.EFileRow.OpponentID;
        }


        protected override void BeforeUpdate(DataRow dr)
        {
            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)dr;

            // 2014-04-27 JLL
            // There still exists the issue of cleaning up unwanted fileoffice rows that were added in AfterChange, where contactid/contacttype were updated.
            // Some FileOffice records might have been added through AfterChange and should be cleaned up here, before updating.
            // assumption cannot be made that if fileoffice added row does not match up officeid-wise with added contact, that it can be deleted
            // it is possible that a fileoffice row was added without the use of a filecontact new record, meaning it's meant to be there without a filecontact record
            // how do we know the difference between a user changing contactid on filecontact, and a fileoffice record that was created on purpose.
            

            //if (fcr.IsOfficeIdNull())
            //{
            //    //update person
            //    //make sure it is not a debtor too!
            //    if (!this.IsADebtor(fcr.ContactId) )
            //    {
            //        atriumDB.ContactRow cr = myA.GetPerson().Load(fcr.ContactId);

            //        cr.LastName = fcr.LastName;
            //        cr.FirstName = fcr.FirstName;
            //        if (fcr.IsTelephoneExtensionNull())
            //            cr.SetTelephoneExtensionNull();
            //        else
            //            cr.TelephoneExtension = fcr.TelephoneExtension;

            //        cr.TelephoneNumber = fcr.TelephoneNumber;

            //    }
            //}

        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
            atriumDB.FileContactRow dr = (atriumDB.FileContactRow)ddr;

            //JLL: Fires too often on contactid when it hasn't changed - because of ucContactSelect control

            switch (dc.ColumnName)
            {
                case FileContactFields.ContactType:
                case FileContactFields.ContactId:
                    if (!dr.IsNull("ContactType") && dr.IsNull("ContactId"))
                    {
                        if (!dr.NoReassign) // only run it if noreassign not set JLL 2015-01-22
                        {
                            int id = myA.EFile.GetOfficerForContactType(dr.EFileRow, dr.ContactType);

                            if (id != 0)
                            {
                                dr.ContactId = id;
                                dr.EndEdit();
                            }
                        }
                    }

                    if (!dr.IsNull("ContactType") && !dr.IsNull("ContactId"))
                    {
                        if (dr.ContactType == myA.AtMng.GetSetting(AppStringSetting.LeadPLContactType) && (dr.EFileRow.IsLeadParalegalIDNull() || dr.EFileRow.LeadParalegalID != dr.ContactId))
                        {
                            dr.EFileRow.LeadParalegalID = dr.ContactId;
                            dr.EFileRow.EndEdit();
                        }
                        if (dr.ContactType == myA.AtMng.GetSetting(AppStringSetting.OfficerContactType) && (dr.EFileRow.IsOfficerIdNull() || dr.EFileRow.OfficerId != dr.ContactId))
                        {
                            dr.EFileRow.OfficerId = dr.ContactId;
                            dr.EFileRow.EndEdit();
                        }//if (dr.ContactType == "FLL" &&(dr.EFileRow.IsLeadLawyerIDNull() || dr.EFileRow.LeadLawyerID != dr.ContactId))
                        //{
                        //    dr.EFileRow.LeadLawyerID = dr.ContactId;
                        //    dr.EFileRow.EndEdit();
                        //}

                        //JLL: 2010/11/16 Can only have one Lead Lawyer on file
                        //update current Lead Lawyer to Assisting Lawyer, unless trying to update to same
                        if (dr.ContactType == myA.AtMng.GetSetting(AppStringSetting.LeadLawyerContactype))
                        {
                            foreach (atriumDB.FileContactRow fcr in myA.CurrentFile.GetFileContactRows())
                            {
                                if (!fcr.IsNull("ContactType") && dr != fcr && fcr.ContactType == "FLL" && fcr.Active)
                                {
                                    if (dr.ContactId == fcr.ContactId)
                                    {
                                        throw new AtriumException(String.Format(Properties.Resources.LeadLawyerAlreadyOnFile, myA.AtMng.AppMan.AppName));
                                    }
                                    else
                                    {
                                        //found current - update to assisting and leave
                                        fcr.ContactType = "FAL";
                                        fcr.EndEdit();
                                        break;
                                    }
                                }
                            }
                            if (dr.EFileRow.IsLeadLawyerIDNull() || dr.EFileRow.LeadLawyerID != dr.ContactId)
                            {
                                dr.EFileRow.LeadLawyerID = dr.ContactId;
                                dr.EFileRow.EndEdit();
                            }
                        }

                        //JLL: 2009/07/23 Can only have one Lead Client Contact on file
                        //update current Lead Client Contact to Secondary Client Contact
                        if (dr.ContactType == "FCC")
                        {
                            foreach (atriumDB.FileContactRow fcr in myA.CurrentFile.GetFileContactRows())
                            {
                                if (!fcr.IsNull("ContactType") && dr != fcr && fcr.ContactType == "FCC" && fcr.Active)
                                {
                                    //if (dr.ContactId == fcr.ContactId)
                                    //{

                                    //    //We need to delete the duplicate somehow.  
                                    //    //to skip the error entirely means we end up with two contacts on the file that is the same person
                                    //    // opinion/requestdocid beforeChange fires and adds another filecontact record when it is not needed
                                    //    // maybe perform a check in opinion/requestdocid beforeChange to see if contactids match already and don't add if already OK
                                    //    throw new AtriumException("The selected contact is already the Lead Client Contact on this file.  LawMate does not allow duplicate lead client contacts.");
                                    //}
                                    //else
                                    //found current - update to secondary and leave
                                    fcr.ContactType = "FSCC";
                                    fcr.EndEdit();
                                    break;
                                }
                            }
                        }
                    }

                    if (dr.RowState == DataRowState.Added & !dr.IsNull("ContactId") & !dr.IsNull("ContactType"))
                    {
                        //find officeid

                        officeDB.OfficerRow orr = myA.AtMng.OfficeMng.GetOfficer().FindLoad(dr.ContactId);
                        if (orr != null)
                        {
                            //add office to file
                            //if (myA.DB.FileOffice.Rows.Count == 0)
                            //    myA.GetFileOffice().LoadByFileId(dr.FileId);

                            if (myA.DB.FileOffice.Select("OfficeID=" + orr.OfficeId.ToString()).Length == 0)
                            {
                                atriumDB.FileOfficeRow fo = (atriumDB.FileOfficeRow)myA.GetFileOffice().Add(myA.CurrentFile);
                                fo.OfficeId = orr.OfficeId;
                                if (dr.ContactType == "FCC" || dr.ContactType == "FHGD")
                                {
                                    fo.IsClient = true;
                                    object alloc = myA.DB.FileOffice.Compute("Sum(PercentAlloc)", "isclient=1");
                                    if (alloc.GetType() == typeof(decimal))
                                    {
                                        fo.PercentAlloc = 100 - System.Convert.ToDecimal(alloc);
                                    }
                                    else
                                    {
                                        fo.PercentAlloc = 100;
                                    }

                                }
                            }
                        }
                    }
                    break;
                case FileContactFields.EndDate:
                    //JLL: 2009/07/23 - set active based on end date
                    dr.Active = dr.IsEndDateNull();
                    dr.HideInToc = !dr.IsEndDateNull();
                    dr.EndEdit();
                    break;
                default:
                    break;
            }

        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            atriumDB.FileContactRow dr = (atriumDB.FileContactRow)ddr;
            switch (dc.ColumnName)
            {
                case "ContactType":
                    if (!myA.CheckDomain(dr.ContactType, myA.Codes("ContactType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Contact Type");

                    //if contact type is once per file see if it it on any other records
                    bool once = false;
                    once = (bool)myA.Codes("ContactType").Select("ContactTypeCode='" + dr.ContactType + "'")[0]["OncePerFile"];
                    if (once)
                    {
                        foreach (atriumDB.FileContactRow fcr1 in myFileContactDT)
                        {
                            if (!fcr1.IsNull("ContactType") && fcr1.ContactType == dr.ContactType && dr.FileContactid != fcr1.FileContactid)
                                throw new AtriumException("A contact of type, {0}, already exists on this file.  You cannot add another.", dr.ContactType);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.CurrentFile};
        //}

        public override DataRow[] GetCurrentRow()
        {
            //this.LoadByFileId(this.myA.CurrentFile.FileId);
            return this.myA.DB.FileContact.Select("ContactType<>'FDB'");
        }

        public override string PromptColumnName()
        {
            return "DisplayName";
        }




        //public override void FixLookups(DataRow ddr)
        //{
        //    atriumDB.FileContactRow dr=(atriumDB.FileContactRow)ddr;

        //    OfficerBE ofr = this.myA.AtMng.OfficeMng.GetOfficer();
        //    if(!dr.IsOfficerCodeNull())
        //        dr.ContactId=ofr.LookupId(dr.OfficerCode);
        //}

        public atriumDB.FileContactRow GetByRole(string role)
        {
            //if (myA.CurrentFile.GetFileContactRows().Length == 0)
            //    LoadByFileId(myA.CurrentFile.FileId);

            foreach (atriumDB.FileContactRow fcr in myA.CurrentFile.GetFileContactRows())
            {
                if (fcr.ContactType.ToUpper() == role.ToUpper())
                    return fcr;
            }
            return null;
        }

        public bool IsInRole(string roleCode)
        {
            return IsInRole(roleCode, myA.AtMng.WorkingAsOfficer.OfficerId);
        }
        public bool IsInRole(string roleCode, int officerId)
        {
            //use workingas
            //if (myA.CurrentFile.GetFileContactRows().Length == 0)
            //    LoadByFileId(myA.CurrentFile.FileId);

            foreach (atriumDB.FileContactRow fcr in myA.CurrentFile.GetFileContactRows())
            {
                if (fcr.ContactType == roleCode & fcr.ContactId == officerId)
                {
                    return true;

                }
            }
            return false;
        }

        public bool IsAnAtriumUser(atriumDB.FileContactRow fcr)
        {
            if (!fcr.IsContactClassNull() && fcr.ContactClass.ToUpper() == "O")
            {
                //should we dig deeper?  valid user vs officer?
                // it is possible to have contact that are officers that aren't users making the BF to that contacttype go to no one.

                return true;
            }
            return false;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            atriumDB.FileContactRow ddr = (atriumDB.FileContactRow)dr;
            
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(ddr.FileId, atSecurity.SecurityManager.Features.FileContact);
            bool canOverride = myA.AtMng.SecurityManager.CanOverride(myA.CurrentFileId, atSecurity.SecurityManager.Features.FileContact) == atSecurity.SecurityManager.ExPermissions.Yes;

            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            if (ddr.ContactType == "FLL" || ddr.ContactType == "FLPL")
                if (canOverride)
                    ok = true;
                else
                    ok = false;

            return ok;
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(fcr.FileId, atSecurity.SecurityManager.Features.FileContact);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public atriumDB.FileContactRow Add(int contactId, string contactType)
        {

            if (myA.DB.FileContact.Select("ContactId=" + contactId.ToString()).Length == 0)
            {
                //add filecontact
                atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)Add(myA.CurrentFile);
                fcr.ContactId = contactId;
                fcr.ContactType = contactType;
                fcr.Active = true;
                fcr.StartDate = DateTime.Today;




            }

            return (atriumDB.FileContactRow)myA.DB.FileContact.Select("ContactId=" + contactId.ToString())[0];

        }
        public atriumDB.FileContactRow Add(officeDB.OfficerRow or, string contactType)
        {
            //if(myA.DB.FileContact.Rows.Count==0)
            //    LoadByFileId(myA.CurrentFile.FileId);

            if (myA.DB.FileContact.Select("ContactId=" + or.OfficerId.ToString()).Length == 0)
            {
                //add filecontact
                atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)Add(myA.CurrentFile);
                fcr.ContactId = or.OfficerId;
                fcr.ContactType = contactType;
                fcr.Active = true;
                fcr.StartDate = DateTime.Today;

                fcr.OfficeId = or.OfficeId;


            }

            return (atriumDB.FileContactRow)myA.DB.FileContact.Select("ContactId=" + or.OfficerId.ToString())[0];

        }
        public atriumDB.FileContactRow Add(docDB.RecipientRow or, string contactType)
        {
            //if (myA.DB.FileContact.Rows.Count == 0)
            //    LoadByFileId(myA.CurrentFile.FileId);

            if (or.IsOfficerIdNull())
            {
                //create free contact
                myA.GetPerson();
                atriumDB.ContactRow c = myA.DB.Contact.NewContactRow();
                myA.DB.Contact.AddContactRow(c);

                c.EmailAddress = or.Address;

                if (or.Name.Contains(","))
                {
                    c.LastName = or.Name.Split(',')[0];
                    c.FirstName = or.Name.Split(',')[1];
                }
                else if (or.Name.Contains(" "))
                {
                    c.LastName = or.Name.Split(' ')[1];
                    c.FirstName = or.Name.Split(' ')[0];
                }
                else
                {
                    c.FirstName = "[n/a]";
                    c.LastName = or.Name;
                }

                //assign contactid to recip record
                or.OfficerId = c.ContactId;
                atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)Add(myA.CurrentFile);
                fcr.ContactId = c.ContactId;
                fcr.ContactType = contactType;
                fcr.Active = true;
                fcr.StartDate = DateTime.Today;

                return fcr;
            }
            else
            {
                if (myA.DB.FileContact.Select("ContactId=" + or.OfficerId.ToString()).Length == 0)
                {
                    //add filecontact
                    //atriumDB.FileContactRow[] fcrs = (atriumDB.FileContactRow[])myA.DB.FileContact.Select("ContactType='"+contactType+"'","", DataViewRowState.Added);
                    //atriumDB.FileContactRow fcr;
                    //if (fcrs.Length == 1)
                    //{
                    //    fcr = fcrs[0];
                    //}
                    //else
                    //{
                    atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)Add(myA.CurrentFile);
                    fcr.ContactType = contactType;
                    fcr.ContactId = or.OfficerId;
                    fcr.Active = true;
                    fcr.StartDate = DateTime.Today;
                    if (!or.IsOfficeIdNull())
                        fcr.OfficeId = or.OfficeId;


                }
                return (atriumDB.FileContactRow)myA.DB.FileContact.Select("ContactId=" + or.OfficerId.ToString())[0];

            }



        }

    }
}

