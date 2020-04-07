using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class OfficerBE : ContactBE
    {

        OfficeManager myA;
        officeDB.OfficerDataTable myOfficerDT;

        atSecurity.secUserBE mySecUserBE;
        SecurityDB.secUserRow mySecUserRow;

        internal OfficerBE(OfficeManager pBEMng)
            : base(pBEMng, pBEMng.DB.Officer)
        {
            myA = pBEMng;
            myOfficerDT = (officeDB.OfficerDataTable)myDT;
            // myOfficerDT.ContactIdColumn.ColumnMapping = MappingType.Hidden;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOfficer();
        }
        public atriumDAL.OfficerDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficerDAL)myODAL;
            }
        }

        public void CopyPreferences(int fromOfficer, int toOfficer, bool clearFirst)
        {
            myA.GetOfficerPrefs().LoadByOfficerId(fromOfficer);
            myA.GetOfficerPrefs().LoadByOfficerId(toOfficer);
            lmDatasets.officeDB.OfficerPrefsRow[] fromPrefs =(lmDatasets.officeDB.OfficerPrefsRow[])myA.DB.OfficerPrefs.Select("OfficerId="+fromOfficer.ToString()) ;
            lmDatasets.officeDB.OfficerPrefsRow[] toPrefs =(lmDatasets.officeDB.OfficerPrefsRow[]) myA.DB.OfficerPrefs.Select("OfficerId=" + toOfficer.ToString());

            if (clearFirst) 
            {
                foreach(officeDB.OfficerPrefsRow opr in toPrefs)
                {
                    opr.Delete();
                }
            }
            OfficerPrefsBE obe=myA.GetOfficerPrefs();
            foreach (officeDB.OfficerPrefsRow opr in fromPrefs)
            {
                officeDB.OfficerPrefsRow newPref =(officeDB.OfficerPrefsRow) obe.Add(null);
                newPref.PrefName = opr.PrefName;
                newPref.PrefValue = opr.PrefValue;
                newPref.OfficerId = toOfficer;
                
            }

        }

        public void CreatePersonalFiles(int parentFileId, officeDB.OfficerRow or, bool useSeparatePersonalFiles)
        {
            //JLL: 2009/07/27 Note about CONVERSION
            // when creating personal files in Personnel Management file, structure should be:
            // Personnel Management
            //      Officers
            //      Role-Based Accounts

            //check to make sure myfileid is null
            //if (!or.IsMyFileIdNull())
            //    throw new AtriumException("File already created.");

            //check to make sure the officer has an account
            SecurityDB.secUserRow sur = myA.AtMng.SecurityManager.GetsecUser().GetSecUserForOfficer(or);

            try
            {
                //create my file
                FileManager myFile = myA.AtMng.CreateFile(myA.AtMng.GetFile(parentFileId));
                myFile.CurrentFile.NameE = string.Format("{0}, {1} [{2}]", or.LastName, or.FirstName, or.OfficerCode);
                myFile.CurrentFile.FileType = "PR";

                BusinessProcess bp = myA.GetBP();

                bp.AddForUpdate(myFile.EFile);
                bp.AddForUpdate(myFile.GetFileXRef());
                bp.AddForUpdate(myFile.GetFileOffice());
                bp.AddForUpdate(myFile.GetFileContact());
                bp.AddForUpdate(myFile.EFile);
                bp.Update();
                //myFile.AtMng.AppMan.Commit();

                or.MyFileId = myFile.CurrentFile.FileId;

                //break security inheritance
                myFile.EFile.BreakInherit();

                //set new perms to this user and sysadmin?
                AddUserFileRule(sur.UserId, myFile.CurrentFile, (int)atSecurity.SpecialRules.MyPersonalFile);
                AddUserFileRule((int)atSecurity.SpecialGroups.Everyone, myFile.CurrentFile, (int)atSecurity.SpecialRules.ReadMail);



                //Create Setting For Below
                if (!useSeparatePersonalFiles)
                {
                    or.InboxId = or.MyFileId;
                    or.SentItemsId = or.MyFileId;
                }
                else
                {
                    //create inbox
                    FileManager inbox = myA.AtMng.CreateFile(myFile);
                    inbox.CurrentFile.NameE = "Inbox";
                    inbox.CurrentFile.NameF = "Dossier corbeille arrivée";
                    BusinessProcess bpi = myA.GetBP();

                    bpi.AddForUpdate(inbox.EFile);
                    bpi.AddForUpdate(inbox.GetFileXRef());
                    bpi.AddForUpdate(inbox.GetFileOffice());
                    bpi.AddForUpdate(inbox.GetFileContact());
                    bpi.AddForUpdate(inbox.EFile);
                    bpi.Update();

                    or.InboxId = inbox.CurrentFile.FileId;

                    //create sentitems
                    FileManager sentItems = myA.AtMng.CreateFile(myFile);
                    sentItems.CurrentFile.NameE = "Sent Items";
                    sentItems.CurrentFile.NameF = "Dossier corbeille envoyée";
                    BusinessProcess bpsi = myA.GetBP();

                    bpsi.AddForUpdate(sentItems.EFile);
                    bpsi.AddForUpdate(sentItems.GetFileXRef());
                    bpsi.AddForUpdate(sentItems.GetFileOffice());
                    bpsi.AddForUpdate(sentItems.GetFileContact());
                    bpsi.AddForUpdate(sentItems.EFile);
                    bpsi.Update();

                    or.SentItemsId = sentItems.CurrentFile.FileId;
                }
                //create shortcuts
                FileManager shortcuts = myA.AtMng.CreateFile(myFile);
                shortcuts.CurrentFile.NameE = "My Shortcuts";
                shortcuts.CurrentFile.NameF = "Dossier de raccourcis";
                shortcuts.CurrentFile.MetaType = "SC";
                BusinessProcess bpsc = myA.GetBP();

                bpsc.AddForUpdate(shortcuts.EFile);
                bpsc.AddForUpdate(shortcuts.GetFileXRef());
                bpsc.AddForUpdate(shortcuts.GetFileOffice());
                bpsc.AddForUpdate(shortcuts.GetFileContact());
                bpsc.AddForUpdate(shortcuts.EFile);
                bpsc.Update();

                or.ShortcutsId = shortcuts.CurrentFile.FileId;
            }
            catch (Exception x)
            {
                //myA.AtMng.AppMan.Rollback();
                throw x;
            }

        }


        internal void AddUserFileRule(int groupId, atriumDB.EFileRow file, int ruleId)
        {
            FileManager fm = myA.AtMng.GetFile(file.FileId);
            atriumDB.secFileRuleRow sfr = (atriumDB.secFileRuleRow)fm.GetsecFileRule().Add(file);
            sfr.FileId = file.FileId;
            sfr.GroupId = groupId;
            sfr.RuleId = ruleId;

            BusinessProcess bp = fm.GetBP();

            bp.AddForUpdate(fm.GetsecFileRule());
            bp.Update();
            //myA.AtMng.SecurityManager.Commit();

            //get rid of new row if present as database new row will have been returned with a different pkid
            //lmDatasets.SecurityDB.secFileRuleRow sfr0 = myA.AtMng.SecurityManager.DB.secFileRule.FindById(0);
            //if (sfr0 != null)
            //{
            //    myA.AtMng.SecurityManager.DB.secFileRule.RemovesecFileRuleRow(sfr0);
            //    myA.AtMng.SecurityManager.DB.secFileRule.AcceptChanges();
            //}
        }

        public officeDB.OfficerRow FindLoad(int OfficerId)
        {
            officeDB.OfficerRow orr = myOfficerDT.FindByOfficerId(OfficerId);
            if (orr == null)
            {
                orr = Load(OfficerId);
                if (orr != null && !orr.IsOutOfOfficeEndDateNull() && orr.IsOutEndEngNull())
                {
                    orr.OutEndEng = orr.OutOfOfficeEndDate.ToString("MMMM d, yyyy h:mm tt", new System.Globalization.CultureInfo("en-US"));
                    orr.OutEndFre = orr.OutOfOfficeEndDate.ToString("d MMMM yyyy H:mm", new System.Globalization.CultureInfo("fr-CA"));
                    orr.AcceptChanges();
                }
            }

            return orr;

        }
        public officeDB.OfficerRow Load(int OfficerId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerLoad(OfficerId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByte(OfficerId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByte(OfficerId));
                }
            }
            SetLocalDates();
            return myOfficerDT.FindByOfficerId(OfficerId);

        }

        public officeDB.OfficerRow LoadByRoleCode(string RoleCode)
        {
            officeDB.OfficerDataTable dt = null;
            if (myA.AtMng.AppMan.UseService)
            {
                dt =(officeDB.OfficerDataTable) myA.AtMng.AppMan.AtriumX().OfficerLoadByRoleCode(RoleCode, myA.AtMng.AppMan.AtriumXCon);
                Fill(dt);
            }
            else
            {
                try
                {
                    dt = myDAL.LoadByRoleCode(RoleCode);
                    Fill(dt);
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    dt = myDAL.LoadByRoleCode(RoleCode);
                    Fill(dt);
                }
            }
            SetLocalDates();
            if (dt.Rows.Count == 0)
                return null;
            else
                return myOfficerDT.FindByOfficerId(dt[0].OfficerId);
        }

        public officeDB.OfficerRow Load(string userName)
        {
            if (myA.AtMng.AppMan.UseService)
            {
           

                Fill(myA.AtMng.AppMan.AtriumX().OfficerLoadByUserName(userName, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByUserName(userName));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByUserName(userName));
                }
            }

            officeDB.OfficerRow[] ors = (officeDB.OfficerRow[])this.myOfficerDT.Select("UserName='" + userName.Replace("'", "''") + "'");
            if (ors.Length == 1)
            {
                SetLocalDates();
                officeDB.OfficerRow or = ors[0];
                return or;
            }
            else
                throw new AtriumException(atriumBE.Properties.Resources.BadUserName);

        }


        public officeDB.OfficerRow LoadByEmail(string email)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerLoadByEmail(email, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByEmail(email));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByEmail(email));
                }
            }

            officeDB.OfficerRow[] ors = (officeDB.OfficerRow[])this.myOfficerDT.Select("EmailAddress='" + email.Replace("'", "''") + "'");
            if (ors.Length == 1)
            {
                SetLocalDates();
                officeDB.OfficerRow or = ors[0];
                return or;
            }
            else
            {
                myA.GetContactEmail().LoadByEmail(email);
                officeDB.ContactEmailRow[] cers = (officeDB.ContactEmailRow[])myA.DB.ContactEmail.Select("Email='" + email.Replace("'", "''") + "'");
                if (cers.Length > 0)
                {
                    SetLocalDates();
                    officeDB.OfficerRow or = myA.GetOfficer().Load(cers[0].ContactId);
                    return or;
                }
                else
                    return null;
            }
        }
        public officeDB.OfficerRow LoadByOfficerCode(string officerCode)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerLoadByOfficerCode(officerCode, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficerCode(officerCode));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficerCode(officerCode));
                }
            }

            officeDB.OfficerRow[] or = (officeDB.OfficerRow[])this.myOfficerDT.Select("officerCode='" + officerCode.Replace("'", "''") + "'");
            SetLocalDates();
            if (or.Length == 1)
                return or[0];
            else
                return null;// throw new AtriumException(String.Format(Properties.Resources.BadOfficerCode, officerCode));

        }


        public officeDB.OfficerRow LoadByMyFileId(int fileId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerLoadByMyFileId(fileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByMyFileId(fileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByMyFileId(fileId));
                }

            }
            officeDB.OfficerRow[] or = (officeDB.OfficerRow[])this.myOfficerDT.Select("myFileId=" + fileId.ToString());
            SetLocalDates();
            if (or.Length == 1)
                return or[0];
            else
                return null;// throw new AtriumException(String.Format(Properties.Resources.BadOfficerCode, officerCode));

        }

        public void LoadByOfficeId(int officeId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficerLoadByOfficeId(officeId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficeIdByte(officeId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficeIdByte(officeId));
                }
            }
            SetLocalDates();
        }

        public officeDB.OfficerRow AddFromContact(atriumDB.ContactRow contactR, officeDB.OfficeRow officeR)
        {
            officeDB.OfficerRow or = (officeDB.OfficerRow)Add(officeR);
            or.ContactId = contactR.ContactId;
            or.OfficerId = or.ContactId;
            or.OfficeId = officeR.OfficeId;

            foreach (DataColumn dc in contactR.Table.Columns)
            {
                if (!contactR.IsNull(dc))
                    or[dc.ColumnName] = contactR[dc];
            }
            return or;
        }
        protected override void AfterAdd(DataRow row)
        {
            base.AfterAdd(row);
            officeDB.OfficerRow dr = (officeDB.OfficerRow)row;
            string ObjectName = this.myOfficerDT.TableName;

            dr.OfficerId = dr.ContactId;// this.myA.AtMng.PKIDGet(ObjectName,1);   
            dr.CreateAccount = false;
            dr.CurrentEmployee = true;
            dr.IsMail = true;
            dr.UsesBilling = dr.OfficeRow.UsesBilling;
            dr.ContactClass = "O";
            dr.OutOfOffice = false;

            myA.AtMng.ClearCodesCache();
        }

        public override bool CanAdd(DataRow parent)
        {
            officeDB.OfficeRow er = (officeDB.OfficeRow)parent;
            return myA.AtMng.SecurityManager.CanAdd(er.OfficeFileId, atSecurity.SecurityManager.Features.Officer) > atSecurity.SecurityManager.ExPermissions.No;
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            officeDB.OfficerRow or = (officeDB.OfficerRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.OfficeRow.OfficeFileId, atSecurity.SecurityManager.Features.Officer);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;
            if (or.OfficerId == myA.AtMng.OfficerLoggedOn.OfficerId)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            officeDB.OfficerRow fo = (officeDB.OfficerRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.OfficeRow.OfficeFileId, atSecurity.SecurityManager.Features.Officer);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        protected override void BeforeUpdate(DataRow ddr)
        {
            officeDB.OfficerRow dr = (officeDB.OfficerRow)ddr;
            //if(!dr.IsCreateAccountNull() && dr.CreateAccount)
            //{
            //    myA.AtMng.SecurityManager.GetsecUser();
            //    myA.AtMng.SecurityManager.GetsecMembership();

            //    SecurityDB.secUserRow sur = myA.AtMng.SecurityManager.DB.secUser.NewsecUserRow();
            //    myA.AtMng.SecurityManager.DB.secUser.AddsecUserRow(sur);

            //    sur.BeginEdit();
            //    sur.UserId=dr.OfficerId;
            //    //if(dr.OfficeRow.OfficeTypeCode=="HQ" ||dr.OfficeRow.OfficeTypeCode=="C")
            //    //    sur.UserName=dr.OfficeRow.OfficeCode+@"\"+dr.LastName.Replace(" ","")+"."+dr.FirstName.Substring(0,1);
            //    //else
            //    //    sur.UserName=dr.OfficeRow.OfficeCode+@"\"+dr.LastName.Replace(" ","")+"."+dr.FirstName.Substring(0,1);
            //    sur.UserName = dr.UserName;
            //    sur.Active = true;
            //    sur.LockedOut=false;
            //    //sur.Password="password";
            //    sur.EndEdit();


            //    dr.BeginEdit();
            //    dr.CreateAccount=false;
            //    dr.EndEdit();


            //}
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            officeDB.OfficerRow dr = (officeDB.OfficerRow)row;

            switch (dc.ColumnName)
            {
                case "OutOfOfficeStartDateLocal":
                    if (!dr.IsOutOfOfficeStartDateLocalNull())
                    {
                        if (dr.OutOfOfficeStartDateLocal > dr.OutOfOfficeEndDateLocal)
                        {
                            dr.OutOfOfficeEndDateLocal = dr.OutOfOfficeStartDateLocal;
                            dr.OutOfOfficeEndDateLocal = dr.OutOfOfficeEndDateLocal.AddMinutes(15);
                            dr.OutOfOfficeEndDate = dr.OutOfOfficeEndDateLocal.ToUniversalTime();
                        }
                        dr.OutOfOfficeStartDate = dr.OutOfOfficeStartDateLocal.ToUniversalTime();
                        dr.EndEdit();
                    }
                    break;
                case "OutOfOfficeEndDateLocal":
                    if (!dr.IsOutOfOfficeEndDateLocalNull())
                    {
                        if (dr.OutOfOfficeStartDateLocal > dr.OutOfOfficeEndDateLocal)
                        {
                            dr.OutOfOfficeStartDateLocal = dr.OutOfOfficeEndDateLocal;
                            dr.OutOfOfficeEndDateLocal = dr.OutOfOfficeEndDateLocal.AddMinutes(15);
                            dr.OutOfOfficeStartDate = dr.OutOfOfficeStartDateLocal.ToUniversalTime();
                        }
                        dr.OutOfOfficeEndDate = dr.OutOfOfficeEndDateLocal.ToUniversalTime();
                        dr.EndEdit();
                    }
                    break;
                case "OutOfOffice":
                    if (dr.IsOutOfOfficeNull() || !dr.OutOfOffice)
                    {
                        dr.SetOutOfOfficeStartDateNull();
                        dr.SetOutOfOfficeStartDateLocalNull();
                        dr.SetOutEndEngNull();
                        dr.SetOutEndFreNull();
                        dr.SetOutOfOfficeEndDateNull();
                        dr.SetOutOfOfficeEndDateLocalNull();
                        dr.EndEdit();
                    }
                    else
                    {
                        dr.OutOfOfficeStartDateLocal = DateTime.Today.AddHours(DateTime.Now.Hour);
                        dr.OutOfOfficeEndDateLocal = dr.OutOfOfficeStartDateLocal.AddDays(1);
                        dr.OutOfOfficeEndDate = dr.OutOfOfficeEndDateLocal.ToUniversalTime();
                        dr.OutOfOfficeStartDate = dr.OutOfOfficeStartDateLocal.ToUniversalTime();
                        dr.EndEdit();
                    }
                    break;
            }
        }


        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            base.BeforeChange(dc, ddr);
            string ObjectName = this.myOfficerDT.TableName;
            officeDB.OfficerRow dr = (officeDB.OfficerRow)ddr;
            switch (dc.ColumnName)
            {
                case "OfficerCode":
                    if (dr.IsUserNameNull())
                        dr.UserName = dr.OfficerCode;
                    break;
                case "PositionCode":
                    if (!myA.CheckDomain(dr.PositionCode, myA.AtMng.GetFile().Codes("PositionCode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Position Code");
                    if (dr.PositionCode == "LA" && dr.IsAssistantIdNull())
                        throw new RequiredException("Assistant");
                    break;
                case "EmailAddress":
                    if (dr.IsEmailAddressNull())
                        throw new RequiredException(dc.ColumnName);
                    break;
                default:
                    break;
            }
        }



        internal SecurityDB.secUserRow SecUserRow
        {
            get
            {
                return mySecUserRow;
            }
            set
            {
                mySecUserRow = value;
            }
        }

        internal atSecurity.secUserBE SecUserBE
        {
            get
            {
                return mySecUserBE;
            }
            set
            {
                mySecUserBE = value;
            }
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            this.SecUserBE.ChangeSQLPassword(mySecUserRow, newPassword, oldPassword);

        }

        public override string BestFKName()
        {
            return "OfficeId";
        }

        public bool IsInRole(string roleCode)
        {
            return IsInRole(roleCode, myA.AtMng.WorkingAsOfficer.OfficerId);
        }
        public bool IsInRole(string roleCode, int officerId)
        {
            //use workingas
            //if( myA.AtMng.WorkingAsOfficer.GetOfficerRoleRows().Length==0)
            //    myA.GetOfficerRole().LoadByOfficerID(myA.AtMng.WorkingAsOfficer.OfficerId);

            officeDB.OfficerRow officer = FindLoad(officerId);

            officeDB.OfficerRoleRow[] orrs = officer.GetOfficerRoleRows();
            foreach (officeDB.OfficerRoleRow orr in orrs)
            {
                if (orr.RoleCode == roleCode)
                {
                    return true;

                }
            }
            return false;
        }

        public void SetLocalDates()
        {
            myA.isMerging = true;

            foreach (officeDB.OfficerRow dr in myOfficerDT)
            {
                if (!dr.IsOutOfOfficeStartDateNull())
                    dr.OutOfOfficeStartDateLocal = dr.OutOfOfficeStartDate.LocalDateTime;

                if (!dr.IsOutOfOfficeEndDateNull())
                    dr.OutOfOfficeEndDateLocal = dr.OutOfOfficeEndDate.LocalDateTime;

                if (dr != null && !dr.IsOutOfOfficeEndDateLocalNull() && dr.IsOutEndEngNull())
                {
                    dr.OutEndEng = dr.OutOfOfficeEndDateLocal.ToString("MMMM d, yyyy h:mm tt", new System.Globalization.CultureInfo("en-US"));
                    dr.OutEndFre = dr.OutOfOfficeEndDateLocal.ToString("d MMMM yyyy H:mm", new System.Globalization.CultureInfo("fr-CA"));
                }

                //we need to do acceptchanges here or the officer record gets saved when ever it is loaded! CJW 2016-2-10
                dr.AcceptChanges();
            }

            myA.isMerging = false;
        }

    }
}

