using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    public enum RecipType
    {
        From,
        To,
        CC,
        BCC
    }
    /// <summary>
    /// 
    /// </summary>
    public class RecipientBE : atLogic.ObjectBE
    {
        DocManager myA;
        docDB.RecipientDataTable myRecipientDT;


        internal RecipientBE(DocManager pBEMng)
            : base(pBEMng, pBEMng.DB.Recipient)
        {
            myA = pBEMng;
            myRecipientDT = (docDB.RecipientDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetRecipient();
        }
        public atriumDAL.RecipientDAL myDAL
        {
            get
            {
                return (atriumDAL.RecipientDAL)myODAL;
            }
        }
        public override int Fill(DataTable dt)
        {
            base.Fill(dt);

            //load from and to tables
            DataView dv = new DataView(myDT, "Type=1", "", DataViewRowState.CurrentRows);
            DataTable dtTo = dv.ToTable();
            myA.DB.To.Clear();
            myA.DB.To.AcceptChanges();
            myA.DB.To.Merge(dtTo);
            myA.DB.To.AcceptChanges();

            DataView dvF = new DataView(myDT, "Type=0", "", DataViewRowState.CurrentRows);
            DataTable dtF = dvF.ToTable();
            myA.DB.From.Clear();
            myA.DB.From.AcceptChanges();
            myA.DB.From.Merge(dtF);
            myA.DB.From.AcceptChanges();

            SyncActivity(dt);

            return dt.Rows.Count;
        }

        bool isSyncing = false;

        public bool IsSyncing
        {
            get { return isSyncing; }
            set { isSyncing = value; }
        }

        public void SyncActivity(DataTable dt)
        {
            IsSyncing = true;
            myA.FM.isMerging = true;
            myA.isMerging = true;

            //syncup the fields on activity
            //myA.FM.DB.Activity.BeginLoadData();
            foreach (atriumDB.ActivityRow ar in myA.FM.DB.Activity)
            {
                if (!ar.IsDocIdNull())
                {
                    DataRowState initialState = ar.RowState;

                   // docDB.RecipientDataTable recipdt = (docDB.RecipientDataTable)dt;
                    if (dt.Select("DocID=" + ar.DocId.ToString()).Length > 0)
                    {
                        docDB.ToRow[] tos = (docDB.ToRow[])myA.DB.To.Select("Docid=" + ar.DocId.ToString());
                        docDB.FromRow[] from = (docDB.FromRow[])myA.DB.From.Select("Docid=" + ar.DocId.ToString());


                        if (from.Length == 1)
                        {
                            ar.From = from[0].Name;
                        }
                        ar.To = " ";
                        foreach (docDB.ToRow to in tos)
                        {
                            ar.To += to.Name + ", ";
                        }

                    }
                    docDB.DocumentRow dr = myA.DB.Document.FindByDocId(ar.DocId);
                    if (dr != null)
                    {
                        ar.efSubject = dr.efSubject;
                        ar.HasAttachment = myA.DB.Attachment.Select("MsgId=" + ar.DocId.ToString()).Length > 0;
                        DataRowState intDocState = dr.RowState;
                        if (ar.FailedToSend)
                        {
                            dr.FailedToSend = true;
                            if (intDocState == DataRowState.Unchanged)
                                dr.AcceptChanges();
                        }

                    }
                    if (initialState == DataRowState.Unchanged && ar.RowState != DataRowState.Unchanged)
                        ar.AcceptChanges();


                }
            }
            // myA.FM.DB.Activity.EndLoadData();
            IsSyncing = false;
            myA.FM.isMerging = false;
            myA.isMerging = false;


        }
        protected override void AfterAdd(DataRow dr)
        {
            docDB.RecipientRow row = (docDB.RecipientRow)dr;
            row.RecipId = myA.AtMng.PKIDGet("Recipient", 10);
            row.AddressType = "SMTP";
            row.isNewMail = false;

        }
        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            docDB.RecipientRow row = (docDB.RecipientRow)dr;
            switch (dc.ColumnName)
            {
                case "OfficerId":
                    //get officer record and set officeid,name,email
                    officeDB.OfficerRow or = myA.AtMng.OfficeMng.DB.Officer.FindByOfficerId(row.OfficerId);
                    if(or==null)
                        or=myA.AtMng.OfficeMng.GetOfficer().Load(row.OfficerId);

                    if (or != null)
                    {
                        DoNotResolve = true;
                        row.OfficeId = or.OfficeId;
                        row.Name = or.LastName + ", " + or.FirstName + " (" + or.OfficerCode + ")";

                        row.Address = or.EmailAddress;
                        row.EndEdit();
                        DoNotResolve = false;
                    }
                    else
                    {
                        atriumDB.ContactRow cr= myA.FM.GetPerson().Load(row.OfficerId);
                        if (cr != null)
                        {
                            DoNotResolve = true;
                       //     row.SetOfficerIdNull();
                            Resolve(cr, row);
                            DoNotResolve = false;
                        }
                    }
                    break;
                case "Address":
                    //get officer record and set officeid,name,email
                    if (row.IsAddressNull())
                    { row.Delete(); }
                    else
                    {
                        if (!DoNotResolve)
                        {
                            Resolve(row.Address, row.Address, row,false);
                        }
                        row.EndEdit();
                    }
                    break;
            }

        }
        public void Resolve(officeDB.OfficeRow or, docDB.RecipientRow newR)
        {
            newR.Address = myA.FM.GetAddress().Load(or.AddressId).EmailAddress;
            newR.OfficeId = or.OfficeId;
            newR.Name = or.OfficeName + " (" + or.OfficeCode + ")";


        }
        public void Resolve(officeDB.OfficerRow or, docDB.RecipientRow newR)
        {

            if (!or.IsEmailAddressNull())
                newR.Address = or.EmailAddress;  //addresstype will default to SMTP so that shouldbe the primary email type for all users
            newR.OfficeId = or.OfficeId;
            newR.OfficerId = or.OfficerId;
            newR.Name = or.LastName + ", " + or.FirstName + " (" + or.OfficerCode + ")";



        }

        public void Resolve(atriumDB.ContactRow cr, docDB.RecipientRow newR)
        {

            if (!cr.IsEmailAddressNull())
            {  newR.Address = cr.EmailAddress;  //addresstype will default to SMTP so that shouldbe the primary email type for all users
            }
            else
            {
                if (!cr.IsAddressCurrentIDNull())
                {
                    atriumDB.AddressRow ar = myA.FM.DB.Address.FindByAddressId(cr.AddressCurrentID);
                    if (ar == null)
                    {
                        myA.FM.GetAddress().LoadByContactId(cr.ContactId);
                        ar = myA.FM.DB.Address.FindByAddressId(cr.AddressCurrentID);
                    }
                    if (!ar.IsEmailAddressNull())
                    {
                        newR.Address = ar.EmailAddress;
                    }
                }
                if (newR.DocumentRow.isLawmail && newR.IsAddressNull())
                   throw new ValidationException(String.Format(Properties.Resources.ContactNoEmailOnResolveAttempt, cr.DisplayName));
            }
            
            newR.Name = cr.DisplayName;

        }
        
        public void Resolve(appDB.ListRow lr, docDB.RecipientRow newR)
        {
            if (!lr.IsExchangeNameNull())
                newR.Address = lr.ExchangeName;  //addresstype will default to SMTP so that shouldbe the primary email type for all users
            newR.Name = lr.ListNameEng;
            newR.ListId = lr.ListId;

        }

        public void Resolve(string userInput, string display, docDB.RecipientRow newR,bool showDialog)
        {
            officeDB.OfficerRow or = null;

            //TODO:resolve from autocomplete first!
            userInput = userInput.Replace("'", "''");

            //not sure why auto-complete was taking precedence
            //this will prevent look up from resolving officer before they were created
            or = myA.AtMng.OfficeMng.GetOfficer().LoadByEmail(userInput);
            if (or != null && or.CurrentEmployee)
            {
                Resolve(or, newR);
                return;
            }

            //JL: old email addresses with 'INET[' fail on line below:  Address='" + userInput +"
            //data clean up required?
            //userInput = userInput.Replace("INET[", "");
            //userInput = userInput.Replace("]", "");

            DataRow[] drAuto = myA.AtMng.RecipientGetRecentSent().Select("Address='" + userInput + "'");
            if (drAuto.Length > 0)
            {
                //add recipient row
                if (drAuto[0].IsNull("OfficerId"))
                {
                    newR.Address = drAuto[0]["email"].ToString();
                    newR.Name = drAuto[0]["Name"].ToString();
                    if (!drAuto[0].IsNull("ListId"))
                        newR.ListId = (int)drAuto[0]["ListId"];
                }
                else
                {
                    or = myA.AtMng.OfficeMng.GetOfficer().FindLoad((int)drAuto[0]["OfficerId"]);
                    if (or != null)
                        Resolve(or, newR);
                    else
                    {
                        newR.OfficerId = (int)drAuto[0]["OfficerId"];
                        newR.Address = drAuto[0]["email"].ToString();
                        newR.Name = drAuto[0]["Name"].ToString();
                    }
                }
                return;
            }

            ////resolve by officecode
            //try
            //{
            //    officeDB.OfficeRow off = myA.AtMng.GetOffice(userInput).CurrentOffice;
            //    Resolve(off,   newR);
            //    return;
            //}
            //catch (Exception xo)
            //{
            //    //do nothing it just means the office didn't exist
            //}

            //resolve by list
            appDB.ListRow[] lr = (appDB.ListRow[])myA.AtMng.DB.List.Select("ListNameEng like '" + userInput + "%'");
            if (lr.Length > 0)
            {
                Resolve(lr[0], newR);
                return;

            }

            //resolve by role on file
            atriumDB.FileContactRow fcr = myA.FM.GetFileContact().GetByRole(userInput);
            if (fcr != null && fcr.Active )
            {
                //if it is not an officer then get the contact record
                if (fcr.IsOfficeIdNull())
                {
                    atriumDB.ContactRow cr = fcr.ContactRow;
                    if(cr==null)
                        myA.FM.GetPerson().Load(fcr.ContactId);

                    Resolve(cr,newR);
                    return;
                }
                else
                {
                    or = myA.AtMng.OfficeMng.GetOfficer().FindLoad(fcr.ContactId);
                }
            }

            if (or == null)
            {
                //resolve by officer code first
                or = myA.AtMng.OfficeMng.GetOfficer().LoadByOfficerCode(userInput);
                if (or!=null && !or.CurrentEmployee)
                    or = null;
            }
            if (or != null)
            {
                Resolve(or, newR);
                return;
            }

            //or = myA.AtMng.OfficeMng.GetOfficer().LoadByEmail(userInput);
            //if (or != null && or.CurrentEmployee )
            //{
            //    Resolve(or, newR);
            //    return;
            //}

            if (!newR.DocumentRow.isLawmail)
            {
                //this is good for non-comm documents
                newR.Address = userInput;
                newR.Name = display;
                newR.AddressType = "NONE";

            }
            else
            {
                string addrType = "SMTP";

                
                try
                {
                    Redemption.MAPIUtils mapiUtil = DocumentBE.MAPIUtils();
               
                    Redemption.SafeRecipient rdoRecip = mapiUtil.CreateRecipient(userInput, showDialog, 0);

                    addrType = "SMTP";//always get the SMTP address rdoRecip.AddressEntry.Type;
                    //resolution of distrib lists gets done  on acbf now
                    //if (addrType == "SMTP")
                    //    userInput = rdoRecip.AddressEntry.SMTPAddress;
                    //else if (addrType == "MAPIPDL")
                    //{
                    //    //go thorugh all entries in list
                    //    Redemption.AddressEntry ade = rdoRecip.AddressEntry;
                    //    Redemption.AddressEntries mbrs = (Redemption.AddressEntries)ade.Members;
                    //    foreach (Redemption.AddressEntry addr in mbrs)
                    //    {
                    //        if (addr.Type == "EX")
                    //            Add(addr.Address, addr.Name);
                    //        else
                    //            Add(addr.SMTPAddress, addr.Name);
                    //    }
                    //    return;
                    //}
                    //else

                    userInput = rdoRecip.AddressEntry.SMTPAddress;
                    if (userInput == null || userInput == "")
                    {
                        addrType = "X400";
                        userInput = rdoRecip.Address;
                    }
                    display = rdoRecip.Name;
                }
                catch (System.NullReferenceException xnull)
                {
                   // myA.AtMng.LogError(xnull);
                    //address not found in address book or cancel hit
                    throw new AtriumException("Cancel of address pick");
                }
                catch(Exception x)
                {
                    myA.AtMng.LogError(x);
                    //address not found in address book or cancel hit
                    throw x;

                }

                if (userInput == null) //personal\outlook distribution lists cause this
                    userInput = display;

                or = myA.AtMng.OfficeMng.GetOfficer().LoadByEmail(userInput);
                if (or == null || !or.CurrentEmployee )
                {
                    //add recipient row
                    newR.Address = userInput;
                    newR.Name = display;
                    newR.AddressType = addrType;

                    return;
                }
                else
                    Resolve(or, newR);

            }
        }
        protected override void BeforeChange(DataColumn dc, DataRow dr)
        {
            docDB.RecipientRow row = (docDB.RecipientRow)dr;
            switch (dc.ColumnName)
            {
                case "OfficerId":
                    if (!row.IsOfficerIdNull() && !row.IsOfficeIdNull() && !myA.CheckDomain(row.OfficerId, myA.FM.Codes("OfficerList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Officer List");
                    break;
                case "Type":
                    if (!Enum.IsDefined(typeof(RecipType), System.Convert.ToInt32(row.Type)))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Recipient Type");
                    break;
                default:
                    break;
            }
        }
        public atriumDB.FileContactRow AddRecipToFile(docDB.RecipientRow r, bool save,string contactType)
        {
            FileManager fm = myA.FM;
            atriumDB.FileContactRow fcr = fm.GetFileContact().Add(r, contactType); ;


            if (save)
            {
                BusinessProcess bp = fm.GetBP();
                bp.AddForUpdate(fm.GetFileOffice());
                bp.AddForUpdate(fm.GetPerson());
                bp.AddForUpdate(fm.GetFileContact());
                bp.AddForUpdate(fm.EFile);
                bp.Update();
              
            }

            return fcr;
        }
        bool DoNotResolve = false;
        public void AddRecipToMessage(docDB.RecipientRow r, docDB.DocumentRow d, RecipType rtype)
        {
            try
            {
                docDB.RecipientRow newr = (docDB.RecipientRow)Add(d);
                DoNotResolve = true;
                newr.Type = ((int)rtype).ToString();
                if (!r.IsOfficeIdNull())
                    newr.OfficeId = r.OfficeId;
                if (!r.IsOfficerIdNull())
                    newr.OfficerId = r.OfficerId;
                if (!r.IsAddressNull())
                    newr.Address = r.Address;
                if (!r.IsNameNull())
                    newr.Name = r.Name;
            }
            catch (Exception x)
            {
            }
            DoNotResolve = false;
        }
        //public override DataRow[] GetParentRow()
        //{
        //    return myA.GetDocument().GetCurrentRow();
        //}

    }
}

