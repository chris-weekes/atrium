using System;
using System.Data;
using atLogic;using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class OfficeBE:atLogic.ObjectBE
	{
        OfficeManager myA;
		officeDB.OfficeDataTable myOfficeDT;

        internal OfficeBE(OfficeManager pBEMng)
            : base(pBEMng, pBEMng.DB.Office)
		{
			myA=pBEMng;
			myOfficeDT=(officeDB.OfficeDataTable)myDT;
			this.myOfficeDT.HourlyRateColumn.ExtendedProperties.Add("format","C");
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOffice();
        }
        public atriumDAL.OfficeDAL myDAL
        {
            get
            {
                return (atriumDAL.OfficeDAL)myODAL;
            }
        }



		public officeDB.OfficeRow Load(int OfficeId)
		{
			officeDB.OfficeRow or=myOfficeDT.FindByOfficeId(OfficeId);
			if(or==null)
			{
                if (myA.AtMng.AppMan.UseService)
                {
                    Fill(myA.AtMng.AppMan.AtriumX().OfficeLoad(OfficeId, myA.AtMng.AppMan.AtriumXCon));
                }
                else
                {
                    try
                    {
                        Fill(myDAL.LoadByte(OfficeId));
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        Fill(myDAL.LoadByte(OfficeId));
                    }
                }
				or=myOfficeDT.FindByOfficeId(OfficeId);
			}
			return or;

		}
        public officeDB.OfficeRow LoadByOfficeFileId(int OfficeFileId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficeLoadByOfficeFileId(OfficeFileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficeFileId(OfficeFileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficeFileId(OfficeFileId));
                }
            }
            return (officeDB.OfficeRow)this.myOfficeDT.Select("OfficeFileId=" + OfficeFileId.ToString())[0]; ;

        }
        public officeDB.OfficeRow LoadByOfficeFileIdNX(int OfficeFileId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficeLoadByOfficeFileId(OfficeFileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficeFileId(OfficeFileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficeFileId(OfficeFileId));
                }
            }

            officeDB.OfficeRow[] ors = (officeDB.OfficeRow[])this.myOfficeDT.Select("OfficeFileId=" + OfficeFileId.ToString());
            if(ors.Length==1)
                return ors[0]; 
            else 
                return null;

        }
        internal officeDB.OfficeRow Load(string officeCode)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().OfficeLoadbyOfficeCode(officeCode, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOfficeCode(officeCode));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOfficeCode(officeCode));
                }
            }

			if(this.myOfficeDT.Select("officeCode='"+officeCode +"'").Length==1)
			{
				officeDB.OfficeRow or=(officeDB.OfficeRow)this.myOfficeDT.Select("officeCode='"+officeCode +"'")[0];
				return or;
			}
			else
				throw new AtriumException(atriumBE.Properties.Resources.BadOfficeCode);

		}

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            officeDB.OfficeRow or = (officeDB.OfficeRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.OfficeFileId, atSecurity.SecurityManager.Features.Office);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            officeDB.OfficeRow fo = (officeDB.OfficeRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.OfficeFileId, atSecurity.SecurityManager.Features.Office);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }


		protected override void AfterAdd(DataRow row)
		{
			officeDB.OfficeRow dr=(officeDB.OfficeRow)row;
			string ObjectName = this.myOfficeDT.TableName;

			if (dr.IsNull("OfficeId") || dr.OfficeId!=0)
				dr.OfficeId= this.myA.AtMng.PKIDGet(ObjectName,1);


			dr.IsOnLine=false;
			dr.UsesBilling=false;
			dr.Retainer=false;
			dr.ReappointedDate=DateTime.Today;
			dr.IsMail=false;
			dr.Active=true;
			dr.HourlyRate=0;
            dr.Even = false;
            dr.IsBranch = false;
            dr.IsLrmOffice = false;
            dr.UploadsDisb = false;
            dr.IsClientOffice = false;
		}

        internal void CreateGroup(officeDB.OfficeRow or, FileManager offFM)
        {
            SecurityDB.secGroupRow gr = (SecurityDB.secGroupRow)offFM.AtMng.SecurityManager.GetsecGroup().Add(null);
            gr.GroupName = or.OfficeName;
            gr.DescE = or.OfficeName;
            gr.DescF = or.OfficeNameFre;

            BusinessProcess bp = myA.GetBP();
            bp.AddForUpdate(offFM.AtMng.SecurityManager.GetsecGroup());
            bp.Update();


            offFM.EFile.BreakInherit();
            atriumDB.secFileRuleRow sfr = (atriumDB.secFileRuleRow)offFM.GetsecFileRule().Add(offFM.CurrentFile);
            sfr.FileId = offFM.CurrentFile.FileId;
            sfr.GroupId = gr.GroupId;
            sfr.RuleId = (int)atSecurity.SpecialRules.GeneralRule;

            BusinessProcess bp1 = myA.GetBP();
            bp1.AddForUpdate( offFM.GetsecFileRule());
            bp1.Update();

            //get rid of new row if present as database new row will have been returned with a different pkid
            lmDatasets.atriumDB.secFileRuleRow sfr0 = offFM.DB.secFileRule.FindById(0);
            if (sfr0 != null)
            {
                offFM.DB.secFileRule.RemovesecFileRuleRow(sfr0);
                offFM.DB.secFileRule.AcceptChanges();
            }
 
        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd,officeDB.OfficeRow or)
        {

            EFileBE.XmlAddToc(xd, "office", "Office", "Bureau", 160, or.OfficeId.ToString());
            EFileBE.XmlAddToc(xd, "officer", "Personnel", "Personnel", 170);
        }
        //JLL: 2007/07/28 - added after update to handle added office/new files
        //what about permissions?  completely separate? as part of creating office?
        protected override void AfterUpdate(DataRow dr)
        {
            officeDB.OfficeRow or = (officeDB.OfficeRow)dr;
            FileManager fm = this.myA.AtMng.GetFile(or.OfficeFileId);

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = fm.CurrentFile.FileStructXml;

            MyXml(fm.CurrentFile, xd, or);
            fm.CurrentFile.FileStructXml = xd.InnerXml;


            //assume it's new - how else?
            if (fm.CurrentFile.LeadOfficeId != or.OfficeId)
            {
                //JLL: 2009/07/28

                ////update lead office to new office
                //fm.CurrentFile.LeadOfficeId = or.OfficeId;
                //atriumDB.FileOfficeRow forow = (atriumDB.FileOfficeRow)fm.GetFileOffice().Add(fm.CurrentFile);
                //forow.IsLead = true;
                //forow.OfficeId = or.OfficeId;


                //rebuild file structure and save
                //fm.EFile.Update();
                //fm.GetFileXRef().Update();
                //fm.GetFileOffice().Update();
                //fm.GetFileContact().Update();

                //fm.EFile.Update();
                //fm.AppMan.Commit();

                //create new group, break inheritance, add new group with office file rule
                //CreateGroup(or, fm);

                //create Personnel Management
                //FileManager PMFile = fm.AtMng.CreateFile(fm);
                //PMFile.CurrentFile.NameE = "Personnel Management";
                //PMFile.CurrentFile.NameF = "Personnel Management";
                //PMFile.CurrentFile.FileType = "PM";
                //PMFile.EFile.Update();
                //PMFile.GetFileXRef().Update();
                //PMFile.GetFileOffice().Update();
                //PMFile.GetFileContact().Update();
                //PMFile.EFile.Update();
                //PMFile.AppMan.Commit();


            }

            //fm.EFile.CalcFileStructXml(fm.CurrentFile, false, false);
            //fm.EFile.Update();
            //fm.AppMan.Commit();
        }

		protected override void BeforeUpdate(DataRow row)
		{
			officeDB.OfficeRow dr=(officeDB.OfficeRow)row;
            FileManager fm = this.myA.AtMng.GetFile(dr.OfficeFileId);
            

			fm.CurrentFile.NameE=dr.OfficeName;
			fm.CurrentFile.NameF=dr.OfficeNameFre;

            

            //JLL: 2007/07/28
            //commented out below, fails to execute properly - moved to afterupdate


            if (dr.RowState == DataRowState.Added)
            {
                fm.GetFileOffice().AddOfficeToFile(dr.OfficeId, false, true, false);
            }
            //    atriumDB.EFileRow currentFile=fm.CurrentFile;

            //    atriumDB.EFileRow pmFile=(atriumDB.EFileRow)fm.EFile.Add(currentFile);
            //    pmFile.BeginEdit();
            //    pmFile.LeadOfficeId = currentFile.LeadOfficeId;
            //    pmFile.NameE="Personnel Management";
            //    pmFile.NameF="Personnel Management";
            //    pmFile.FileType="PM";
            //    pmFile.EndEdit();
            //    //fm.CurrentFile=currentFile;

            //    if(dr.IsOnLine)
            //    {
            //        //add help desk file
            //        atriumDB.EFileRow helpFile=(atriumDB.EFileRow)fm.EFile.Add(currentFile);
            //        helpFile.BeginEdit();
            //        helpFile.LeadOfficeId = currentFile.LeadOfficeId;
            //        helpFile.NameE="Help Desk Requests";
            //        helpFile.NameF="Help Desk Requests";
            //        helpFile.FileType="HD";
            //        helpFile.EndEdit();
            //        //fm.CurrentFile=currentFile;

            //    }

            //    //JLL: How do i get that data loaded in here?
            //    if(dr.CB) //OfficeType data not loaded
            //    {
            //        //add payment file
            //        atriumDB.EFileRow payFile=(atriumDB.EFileRow)fm.EFile.Add(currentFile);
            //        payFile.BeginEdit();
            //        payFile.LeadOfficeId = currentFile.LeadOfficeId;
            //        payFile.NameE="Receipt and Remittance of Payments";
            //        payFile.NameF="Receipt and Remittance of Payments";
            //        payFile.FileType="AC";
            //        payFile.EndEdit();
            //        //fm.CurrentFile=currentFile;
            //    }
            //    //JLL: How do i get that data loaded in here?
            //    if(dr.Billing) //OfficeType data not loaded
            //    {
            //        //add billing file
            //        atriumDB.EFileRow billFile=(atriumDB.EFileRow)fm.EFile.Add(currentFile);
            //        billFile.BeginEdit();
            //        billFile.LeadOfficeId = currentFile.LeadOfficeId;
            //        billFile.NameE="Billings";
            //        billFile.NameF="Billings";
            //        billFile.FileType="AB";
            //        billFile.EndEdit();
            //        //fm.CurrentFile=currentFile;
            //    }

            //    //fm.CurrentFile=currentFile;
            //}
		}
        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
            officeDB.OfficeRow dr = (officeDB.OfficeRow)ddr;
            switch (dc.ColumnName)
            {
                case "OfficeFileId":
                    if (dr.IsAddressIdNull())
                    {
                        //atriumDB.AddressRow ar = (atriumDB.AddressRow)this.myA.AtMng.GetFile(dr.OfficeFileId, false).GetAddress().Add(dr);
                        //dr.AddressId = ar.AddressId;

                    }
                    break;
            }
        }

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myOfficeDT.TableName;
			officeDB.OfficeRow dr=(officeDB.OfficeRow)ddr;
			switch(dc.ColumnName)
			{
				case "OfficeName":
                    if (dr.IsOfficeNameNull())
                        throw new RequiredException(Resources.OfficeOfficeName);
					break;
				case "OfficeNameFre":
					if (dr.IsOfficeNameFreNull())
                        throw new RequiredException(Resources.OfficeOfficeNameFre);
					break;
				case "OfficeTypeCode":
					if (dr.IsOfficeTypeCodeNull())
                        throw new RequiredException(Resources.OfficeOfficeTypeCode);
                    else if (!myA.CheckDomain(dr.OfficeTypeCode, myA.AtMng.GetFile().Codes("OfficeType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office Type");
					break;
				case "AppointmentTypeCode":
                    //if (dr.IsAppointmentTypeCodeNull())
                    //    throw new RequiredException(Resources.OfficeAppointmentTypeCode);
                    //else if (!myA.CheckDomain(dr.AppointmentTypeCode, myA.AtMng.GetFile().Codes("AppointmentType")))
                    //    throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Appointment Type");
                    break;
                case "CurrencyCode":
                    if (dr.UsesBilling && dr.IsCurrencyCodeNull())
                        throw new RequiredException(Resources.OfficeCurrencyCode);
                    else if (!dr.IsCurrencyCodeNull() && !myA.CheckDomain(dr.CurrencyCode, myA.AtMng.GetFile().Codes("CurrencyCode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Currency Code");
                    break;
                case "DefaultTaxRate":
                    if (!dr.IsDefaultTaxRateNull() && !myA.CheckDomain(dr.DefaultTaxRate, myA.AtMng.GetFile().Codes("TaxRate")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Tax Rate");
                    break;
                case "HourlyRate":
                    if (dr.UsesBilling && dr.IsHourlyRateNull())
                        throw new RequiredException(Resources.OfficeHourlyRate);
                    break;
                case "LetterSignatory":
                    //if (dr.IsLetterSignatoryNull())
                    //    throw new RequiredException(Resources.OfficeLetterSignatory);
                    break;
                case "ReappointedDate":
                    //if(dr.IsReappointedDateNull())
                    //    throw new RequiredException(Resources.OfficeReappointedDate);
                    //myA.IsValidDate(Resources.OfficeReappointedDate, dr.ReappointedDate, false, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin,Resources.ValidationToday);
                    break;
                default:
					break;
			}
		}

		internal int LookupId(string officeCode)
		{
			return this.Load(officeCode).OfficeId;
		}

       

		public override string BestFKName()
		{
			return "AddressId";
		}

		public override string PromptColumnName()
		{
			return "OfficeCode,OfficeName";
		}

		public override string PromptFormat()
		{
			return "{0} - {1}";
		}



	}
}
