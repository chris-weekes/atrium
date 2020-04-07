using System;
using System.Data;
using atLogic;
using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FileHistoryBE:atLogic.ObjectBE
	{
        CLASManager myA;
        CLAS.FileHistoryDataTable myFileHistoryDT;

        internal FileHistoryBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.FileHistory)
		{
			myA=pBEMng;
            myFileHistoryDT = (CLAS.FileHistoryDataTable)myDT;
        }
        public atriumDAL.FileHistoryDAL myDAL
        {
            get
            {
                return (atriumDAL.FileHistoryDAL)myODAL;
            }
        }

		protected  override void AfterUpdate(DataRow row)
		{
            CLAS.FileHistoryRow dr = (CLAS.FileHistoryRow)row;
            EFileBE.XmlAddToc(myA.FM.CurrentFile, "filehistory", "File History", "Cheminement de dossier",130);
		}

		protected  override void BeforeAdd(DataRow dr)
		{
			if(this.GetCurrentRow().Length>=1)
			{
				//dr.EFileRow.RowError="You cannot transfer the file before returned.";
                throw new AtriumException(Resources.YouCannotTransferTheFileBeforeItIsReturned);
			}
		}

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.FileHistoryRow fhr = (CLAS.FileHistoryRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fhr.FileId, atSecurity.SecurityManager.Features.FileHistory);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

		protected override void AfterAdd(DataRow row)
		{
            CLAS.FileHistoryRow dr = (CLAS.FileHistoryRow)row;
			string ObjectName = this.myFileHistoryDT.TableName;

			//need ot load all rows for account and checkfor return

			dr.HistoryId = myA.AtMng.PKIDGet(ObjectName,1);  
			
            dr.FileId=myA.FM.CurrentFile.FileId;
			dr.StatusCode=myA.FM.CurrentFile.StatusCode;
            dr.SentToOfficeDate=DateTime.Today;
            dr.BillingCode="HR";

            if (myFileHistoryDT.Count > 1)
                dr.PreviousOfficeId = myA.FM.CurrentFile.LeadOfficeId;

			//need to assign office based on debtor address
			if(!myA.FM.CurrentFile.IsOpponentIDNull())
			{
				object tempid=this.myA.AppMan.ExecuteScalar("AssignOfficeByCity",dr.FileId, myA.FM.CurrentFile.OpponentID);
				if(tempid==System.DBNull.Value)
					dr.OfficeId=this.myA.AtMng.OfficeLoggedOn.OfficeId;
				else
					dr.OfficeId=System.Convert.ToInt32(tempid);
			}
			
		}



		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myFileHistoryDT.TableName;
            CLAS.FileHistoryRow dr = (CLAS.FileHistoryRow)ddr;
			switch(dc.ColumnName)
			{
				case "SentToOfficeDate":
					if(dr.IsSentToOfficeDateNull())
                        throw new RequiredException(Resources.FileHistorySentToOfficeDate);
                    if (myA.FM.CurrentFile.IsOpenedDateNull())
                        throw new RelatedException(Resources.FileHistorySentToOfficeDate, Resources.EFileOpenedDate);
                    myA.IsValidDate(Resources.FileHistorySentToOfficeDate, dr.SentToOfficeDate, false, myA.FM.CurrentFile.OpenedDate, DateTime.Today.AddDays(7), Resources.EFileOpenedDate, Resources.ValidationSevenDaysLater);

                    //this should be moved to before update
                    // ok, moved 2015-04-29 JLL to row.added condition
                    //if (dr.IsReceivedByOfficeDateNull())
                    //{
                    //    this.myA.FM.GetFileOffice().AddOfficeToFile(dr.OfficeId, false, true, false);
                    //}

					break;
				case "ReceivedByOfficeDate":
					if(myA.FM.CurrentFile.LeadOfficeId!=this.myA.AtMng.WorkingAsOfficer.OfficeId )
					{
						//and lead office is not online
                        officeDB.OfficeRow or = this.myA.AtMng.OfficeMng.DB.Office.FindByOfficeId(myA.FM.CurrentFile.LeadOfficeId);
                        if (or == null)
                            or = this.myA.AtMng.GetOffice(myA.FM.CurrentFile.LeadOfficeId).CurrentOffice;
                        if (or.IsOnLine && myA.FM.CurrentFile.StatusCode == "O")
							throw new AtriumException(Resources.OnlyTheLeadOfficeCanReceiveTheFile);
					}
					if(!dr.IsReceivedByOfficeDateNull())
					{
                        if (dr.IsSentToOfficeDateNull())
                            throw new RelatedException(Resources.FileHistoryReceivedByOfficeDate, Resources.FileHistorySentToOfficeDate);
						myA.IsValidDate(Resources.FileHistoryReceivedByOfficeDate, dr.ReceivedByOfficeDate, true, dr.SentToOfficeDate, DateTime.Today, Resources.FileHistorySentToOfficeDate,Resources.ValidationToday);
					}

					break;
				case "ReturnedByOfficeDate":
					if(!dr.IsReturnedByOfficeDateNull())
					{
						if(dr.IsReceivedByOfficeDateNull())
							throw new RelatedException(Resources.FileHistoryReturnedByOfficeDate, Resources.FileHistoryReceivedByOfficeDate);
						myA.IsValidDate(Resources.FileHistoryReturnedByOfficeDate, dr.ReturnedByOfficeDate, true, dr.ReceivedByOfficeDate, DateTime.Today, Resources.FileHistoryReceivedByOfficeDate, Resources.ValidationToday);
					}
					break;
				case "ReceivedFromOfficeDate":
					if(!dr.IsReceivedFromOfficeDateNull())
					{
						if(dr.IsReturnedByOfficeDateNull())
							throw new RelatedException(Resources.FileHistoryReceivedFromOfficeDate, Resources.FileHistoryReturnedByOfficeDate);
						myA.IsValidDate(Resources.FileHistoryReceivedFromOfficeDate, dr.ReceivedFromOfficeDate, true, dr.ReturnedByOfficeDate, DateTime.Today, Resources.FileHistoryReturnedByOfficeDate, Resources.ValidationToday);
					}
					break;
				case "OfficeId":
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.FileHistoryOfficeId);
                    else if (!myA.CheckDomain(dr.OfficeId, myA.FM.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
                    //don't allow officeid to be updated after it has been created
                    if (dr.RowState != DataRowState.Added && !ddr[dc, DataRowVersion.Current].Equals(ddr[dc, DataRowVersion.Original]))
                    {
                        throw new AtriumException("The Office Code cannot be changed. Either return the file, or delete the File History record altogether (if applicable)");
                    }
					break;
				case "BillingCode":
					if (dr.IsBillingCodeNull())
                        throw new RequiredException(Resources.FileHistoryBillingCode);
                    break;
				default:
					break;
			}
		}

        private void AddUpdateLeadOfficeContact(CLAS.FileHistoryRow fhr)
        {
            OfficeManager om = myA.FM.AtMng.GetOffice(fhr.OfficeId);
            officeDB.OfficerRow[] OfficerRow = (officeDB.OfficerRow[])om.DB.Officer.Select("OfficerCode='" + om.CurrentOffice.OfficeCode + ".REC'", "");
            if (OfficerRow.Length == 0)
                throw new AtriumException("Officer Record for Officer Code: {0}.REC could not be found. Office does not have a proper Reception Officer.  Contact an administrator.", om.CurrentOffice.OfficeCode);
            //verify if FLO contact type exists already
            atriumDB.FileContactRow[] LeadOfficeContact = (atriumDB.FileContactRow[])myA.FM.DB.FileContact.Select("ContactType='FLO'", "");
            if (LeadOfficeContact.Length == 1)
            {
                //found it, need to update it to new office
                LeadOfficeContact[0].StartDate = DateTime.Today;
                LeadOfficeContact[0].ContactId = OfficerRow[0].ContactId;
            }
            else
            {
                //create a new one.  FLO should be set to only onePerFile otherwise this code will run when there is more than one LFO
                atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)myA.FM.GetFileContact().Add(myA.FM.CurrentFile);
                fcr.ContactId = OfficerRow[0].ContactId;
                fcr.ContactType = "FLO";
            }
 
        }

        private void AddSecFileRuleOnAssignment(CLAS.FileHistoryRow fhr)
        {
            
            OfficeManager om = myA.FM.AtMng.GetOffice(fhr.OfficeId);
            if(!om.CurrentOffice.IsDefaultGroupNull())
            {
                atriumDB.secFileRuleRow secRule = (atriumDB.secFileRuleRow)myA.FM.GetsecFileRule().Add(myA.FM.CurrentFile);
                secRule.StartDate = DateTime.Today;
                secRule.Inherited = false;
                secRule.GroupId = om.CurrentOffice.DefaultGroup;
                try
                {
                    secRule.RuleId = myA.AtMng.GetSetting(AppIntSetting.LeadOfficeSecFileRule);
                }
                catch (Exception x)
                {
                    throw new AtriumException("ATTEMPT TO SET RULEID ON SECURITY FILE RULE HAS FAILED. RETRIEVAL OF LEAD OFFICE APPSETTING CAUSED AN ERROR");
                }
            }
            else
            {
                throw new AtriumException("SELECTED OFFICE'S DEFAULT SECURITY GROUP IS NOT DEFINED.");
            }
        }

		protected override void BeforeUpdate(DataRow row)
		{
            CLAS.FileHistoryRow dr = (CLAS.FileHistoryRow)row;
			//this.BeforeChange(dr.Table.Columns["SubFileType"], dr);
			this.BeforeChange(dr.Table.Columns["BillingCode"], dr);
			this.BeforeChange(dr.Table.Columns["SentToOfficeDate"],dr);
			this.BeforeChange(dr.Table.Columns["OfficeId"],dr);

            if (!dr.IsReceivedFromOfficeDateNull())
            {
                //update leadoffice to owner on efile
                bool demoteLead = false;
                if (myA.FM.CurrentFile.LeadOfficeId != myA.FM.CurrentFile.OwnerOfficeId)
                    demoteLead = true;

                myA.FM.CurrentFile.LeadOfficeId = myA.FM.CurrentFile.OwnerOfficeId;
                
                //demote leadoffice to ag
                if(demoteLead)
                    this.myA.FM.GetFileOffice().AddOfficeToFile(dr.OfficeId, false, false, false);
                
                //else
                //    this.myA.FM.GetFileOffice().AddOfficeToFile(dr.OfficeId, true, true, false);
                
                //set LeadOfficeContact endDate
                //atriumDB.FileContactRow[] LeadOfficeContact = (atriumDB.FileContactRow[])myA.FM.DB.FileContact.Select("ContactType='FLO'", "");
                //if (LeadOfficeContact.Length == 1)
                //    LeadOfficeContact[0].EndDate = DateTime.Today;

                //update secfilerule table
                //OfficeManager om = myA.FM.AtMng.GetOffice(dr.OfficeId);
                //atriumDB.secFileRuleRow[] secRule = (atriumDB.secFileRuleRow[])myA.FM.DB.secFileRule.Select("GroupId=" + om.CurrentOffice.DefaultGroup, "");
                //if (secRule.Length == 1)
                //{
                //    atriumDB.secFileRuleRow secRecord = secRule[0];
                //    secRecord.EndDate = atDates.StandardDate.NextQuarter.EndDate;
 
                //}
                //else
                //      throw new AtriumException("(OFFICEID: " + dr.OfficeId + ") - NO SECFILERULE RECORD WAS FOUND, OR THIS OFFICE HAS MULTIPLE SECFILERULE RECORDS.");

            }
			
			if(dr.RowState==DataRowState.Added)
			{
                this.myA.FM.GetFileOffice().AddOfficeToFile(dr.OfficeId, false, true, false);

                //AddUpdateLeadOfficeContact(dr);
                //AddSecFileRuleOnAssignment(dr);

				//for each fileaccount assign to this office
				AccountHistoryBE ahBE=this.myA.GetAccountHistory();
                
				foreach(CLAS.DebtRow far in this.myA.DB.Debt.Rows)
				{
					if(far.AssignToAgent)
					{
                        if(!far.ActiveWithJustice)
                            far.ActiveWithJustice = true; // if user selected account to assign, set active to true

						CLAS.AccountHistoryRow ahr=(CLAS.AccountHistoryRow)ahBE.Add(far);
                        ahr.FileId = myA.FM.CurrentFileId;
						ahr.FileHistoryId=dr.HistoryId;
						ahr.OfficeId=dr.OfficeId;
						ahr.SentToOfficeDate=dr.SentToOfficeDate;
					}
				}
			}
			else
			{
				//for each fileaccount assigned to this office
				foreach(CLAS.AccountHistoryRow ahr in myA.DB.AccountHistory.Select("FileHistoryId="+dr.HistoryId.ToString()))
				{
					if(ahr.IsReceivedFromOfficeDateNull() && ahr.DebtRow.ActiveWithJustice )
					{
						if(ahr.IsReceivedFromOfficeDateNull() && !dr.IsReceivedFromOfficeDateNull())
							ahr.ReceivedFromOfficeDate=dr.ReceivedFromOfficeDate;

						if(ahr.IsReturnedByOfficeDateNull() && !dr.IsReturnedByOfficeDateNull())
						{
							if(ahr.IsReceivedByOfficeDateNull())
								throw new AtriumException(Resources.AccountNotReceived);
							ahr.ReturnedByOfficeDate=dr.ReturnedByOfficeDate;
						}
						
						if(ahr.IsReceivedByOfficeDateNull() && !dr.IsReceivedByOfficeDateNull())
							ahr.ReceivedByOfficeDate=dr.ReceivedByOfficeDate;

						if(ahr.IsReturnCodeNull() && !dr.IsReturnCodeNull())
							ahr.ReturnCode=dr.ReturnCode;
					}
				}
			}
			
		}

		protected override void BeforeDelete(DataRow row) 
		{
            CLAS.FileHistoryRow dr = (CLAS.FileHistoryRow)row;
			string ObjectName = this.myFileHistoryDT.TableName;
			this.myA.FM.GetActivity().DeleteRelatedCA(dr.FileId, ObjectName,dr.HistoryId);
		}

     

		public override DataRow[] GetCurrentRow()
		{
			
			return this.myFileHistoryDT.Select("ReceivedFromOfficeDate is null");
		}

		public override string PromptColumnName()
		{
			return "OfficeCode,SentToOfficeDate";
		}


	}
}

