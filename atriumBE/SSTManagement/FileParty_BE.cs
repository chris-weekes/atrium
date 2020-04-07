using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class FilePartyBE : atLogic.ObjectBE
    {
        SSTManager myA;
        SST.FilePartyDataTable myFilePartyDT;

        internal FilePartyBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileParty)
        {
            myA = pBEMng;
            myFilePartyDT = (SST.FilePartyDataTable)myDT;
            if (myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileParty();
        }

        public atriumDAL.FilePartyDAL myDAL
        {
            get
            {
                return (atriumDAL.FilePartyDAL)myODAL;
            }
        }

        public SST.FilePartyRow Load(int FilePartyId)
        {
            try
            {
                Fill(myDAL.Load(FilePartyId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(FilePartyId));
            }

            return myFilePartyDT.FindByFilePartyId(FilePartyId);
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
        }

        public void LoadByFilePartyId(int FilePartyId)
        {
            try
            {
                Fill(myDAL.LoadByFilePartyId(FilePartyId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByFilePartyId(FilePartyId));
            }
        }

        protected override void BeforeChange(DataColumn dc, DataRow row)
        {
            SST.FilePartyRow dr = (SST.FilePartyRow)row;

            if (!dr.IsFileContactIdNull()) // ensure FileContactId is not null
            {
                atriumDB.FileContactRow fcr = myA.FM.DB.FileContact.FindByFileContactid(dr.FileContactId);
                switch (dc.ColumnName)
                {
                    case "IsRespondent":
                        //add this test to prevent duplicate IsRespondent on a file

                        if (dr.IsRespondent)
                        {

                            if (!fcr.IsNull("ContactType"))
                            {
                                if (fcr.ContactType.EndsWith("R"))
                                    throw new AtriumException("A rep. cannot be the respondent");
                            }
                        }
                        foreach (SST.FilePartyRow fcr1 in myFilePartyDT)
                        {
                            if (fcr1.RowState != DataRowState.Deleted)
                            {
                                fcr1.SetColumnError(dc, "");
                                if (dr.IsRespondent && fcr1.IsRespondent && dr.FilePartyId != fcr1.FilePartyId)
                                    throw new AtriumException(Properties.Resources.DuplicateRespondent);
                            }
                        }

                        break;
                    case "IsAddedParty":
                        if (dr.IsAddedParty)
                        {

                            if (!fcr.IsNull("ContactType"))
                            {
                                if (fcr.ContactType.EndsWith("R"))
                                    throw new AtriumException("A rep. cannot be an added party");
                            }
                        }
                        break;
                    case "IsAppellant":
                        //TFS#51004 CJW 2013-8-26
                        //add this test to prevent duplicate appellants on a file

                        if (dr.IsAppellant)
                        {

                            if (!fcr.IsNull("ContactType"))
                            {
                                if (fcr.ContactType.EndsWith("R"))
                                    throw new AtriumException("A rep. cannot be the appellant");
                            }
                        }
                        foreach (SST.FilePartyRow fcr1 in myFilePartyDT)
                        {
                            if (fcr1.RowState != DataRowState.Deleted)
                            {
                                fcr1.SetColumnError(dc, "");
                                if (dr.IsAppellant && fcr1.IsAppellant && dr.FilePartyId != fcr1.FilePartyId)
                                    throw new AtriumException(Properties.Resources.DuplicateAppellant); //JLL 2013-09-27: Translation for 2013/10 build - string moved to resource.
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
        }

        protected override void BeforeUpdate(DataRow row)
        {
            SST.FilePartyRow dr = (SST.FilePartyRow)row;
            if ((dr.IsRespondent & dr.IsAppellant) |(dr.IsRespondent & dr.IsAddedParty)|(dr.IsAddedParty & dr.IsAppellant))
                throw new AtriumException("A file party can only be one of the following: appellant, respondent or added party");

            BeforeChange("IsRespondent", row);
            BeforeChange("IsAppellant", row);
        }

        protected override void AfterAdd(DataRow row)
        {
            SST.FilePartyRow dr = (SST.FilePartyRow)row;
            string ObjectName = this.myFilePartyDT.TableName;

            dr.FilePartyId = this.myA.AtMng.PKIDGet(ObjectName, 10);
            dr.FileId = myA.FM.CurrentFileId;
            dr.IsAppellant = false;
            dr.IsRespondent = false;
            dr.IsPending = false;
            dr.AllowAdministrativeEmail = false;
            dr.IsAddedParty = false;
        }

        public override bool CanDelete(DataRow dr)
        {
            SST.FilePartyRow fpRow = (SST.FilePartyRow)dr;
            if (fpRow.IsPending | (!fpRow.IsAppellant & !fpRow.IsRespondent))
                return true;
            else
                return false;
        }

        public void CalcRecipType()
        {
            myA.isMerging = true;
            //clear column first
            myFilePartyDT.AcceptChanges();
            foreach (SST.FilePartyRow fpr in myFilePartyDT)
            {
                if (fpr.RowState != DataRowState.Deleted)
                {
                    fpr.SetRecipTypeNull();
                    fpr.AcceptChanges();
                }
            }

            //determine whether this record should be the recipient 
            foreach (SST.FilePartyRow fpr in myFilePartyDT)
            {
                fpr.ClosestSCCId = 0;
                atriumDB.FileContactRow fcr = myA.FM.DB.FileContact.FindByFileContactid(fpr.FileContactId);

                if (fcr != null)
                {
                    if (fcr.ContactRow != null)
                    {
                        if (!fcr.ContactRow.IsAddressCurrentIDNull())
                        {
                            //calc sc
                            atriumDB.AddressRow ar = myA.FM.DB.Address.FindByAddressId(fcr.ContactRow.AddressCurrentID);
                            appDB.PostalCodeLocationRow pclr = null;
                            if (ar != null)
                            {
                                if (!ar.IsPostalCodeNull())
                                {
                                    pclr = myA.AtMng.GetPostalCodeLocation().Load(ar.PostalCode.Replace(" ", ""));
                                }

                                if (pclr != null)
                                {
                                    MemberManager mem = myA.AtMng.GetMemberMng();
                                    fpr.ClosestSCCId = mem.GetClosestSCC(pclr.Latitude, pclr.Longitude);
                                    fpr.AcceptChanges();
                                }
                            }
                        }
                    }

                    //calc recip type
                    if (fcr.IsDelegateForNull())
                    {
                        atriumDB.FileContactRow[] fcrRep = (atriumDB.FileContactRow[])myA.FM.DB.FileContact.Select("DelegateFor='" + fcr.ContactType + "'");
                        if (fcrRep.Length == 1)
                        {
                            SST.FilePartyRow[] fprs = (SST.FilePartyRow[])myFilePartyDT.Select("FileContactId=" + fcrRep[0].FileContactid.ToString());
                            if (!fprs[0].IsPending)
                            {
                                fprs[0].RecipType = fpr.ContactType;
                                fprs[0].AcceptChanges();
                            }
                            else
                            {
                                fpr.RecipType = fpr.ContactType;
                                fpr.AcceptChanges();
                            }
                        }
                        else
                        {
                            fpr.RecipType = fpr.ContactType;
                            fpr.AcceptChanges();
                        }
                    }
                }

            }
            myA.isMerging = false;

        }

        protected override void AfterUpdate(DataRow dr)
        {
            SST.FilePartyRow fpr = (SST.FilePartyRow)dr;
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();

            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(fpr, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;

            CalcRecipType();
        }

        public override DataRow[] GetCurrentRow()
        {
            return myFilePartyDT.Select();
        }

        public override string PromptColumnName()
        {
            return "DisplayName";
        }

        private void MyXml(SST.FilePartyRow fcr, System.Xml.XmlDocument xd)
        {
            //TODO: need to fix this up
            //return;
            try
            {

                System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='contact' and @id=" + fcr.FileContactId.ToString() + "]");
                if (xe == null)
                    return;

                if (fcr.IsPending)
                {
                    xe.SetAttribute("italicize", "true");
                    xe.SetAttribute("icon", "26"); //hourglass pending
                    xe.SetAttribute("tooltipe", "Pending Party");
                    xe.SetAttribute("tooltipf", "À confirmer");
                }
                else if (fcr.IsAppellant)
                {
                    xe.SetAttribute("icon", "27"); //appelant
                    xe.SetAttribute("italicize", "false");
                    xe.SetAttribute("tooltipe", "Appellant");
                    xe.SetAttribute("tooltipf", "Appelant");
                }
                else if (fcr.IsRespondent)
                {
                    xe.SetAttribute("icon", "31"); //respondent
                    xe.SetAttribute("italicize", "false");
                    xe.SetAttribute("tooltipe", "Respondent");
                    xe.SetAttribute("tooltipf", "Intimé");
                }
                else if (fcr.IsAddedParty)
                {
                    xe.SetAttribute("icon", "37"); //IsAddedParty
                    xe.SetAttribute("italicize", "false");
                    xe.SetAttribute("tooltipe", "Added Party");
                    xe.SetAttribute("tooltipf", "Partie mise en cause");
                }
                else
                {
                    xe.SetAttribute("italicize", "false"); //added party
                    xe.SetAttribute("icon", "32");
                    xe.SetAttribute("tooltipe", "Added Party");
                    xe.SetAttribute("tooltipf", "Partie jointe");
                }

                xe.SetAttribute("isParticipant", "true");
            }
            catch (Exception x)
            { }
        }

        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
            foreach (SST.FilePartyRow r in myFilePartyDT)
            {
                MyXml(r, xd);
            }
        }
    }
}