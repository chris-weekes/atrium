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
	public class AddressBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.AddressDataTable myAddressDT;
		
		internal AddressBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.Address)
		{
			myA=pBEMng;
			myAddressDT=(atriumDB.AddressDataTable)myDT;

			myAddressDT.WorkPhoneColumn.ExtendedProperties.Add("format","(###) ###-####");
			myAddressDT.HomePhoneColumn.ExtendedProperties.Add("format","(###) ###-####");
			myAddressDT.FaxNumberColumn.ExtendedProperties.Add("format","(###) ###-####");
			myAddressDT.MobilePhoneColumn.ExtendedProperties.Add("format","(###) ###-####");

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetAddress();
        }
        public atriumDAL.AddressDAL myDAL
        {
            get
            {
                return (atriumDAL.AddressDAL)myODAL;
            }
        }


		public atriumDB.AddressRow Load(int AddressId)
		{
			atriumDB.AddressRow or=myAddressDT.FindByAddressId(AddressId);
			if(or==null)
			{
                if (myA.AtMng.AppMan.UseService)
                {
                    Fill(myA.AtMng.AppMan.AtriumX().AddressLoad(AddressId, myA.AtMng.AppMan.AtriumXCon));
                }
                else
                {
                    try
                    {
                        Fill(myDAL.Load(AddressId));
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        Fill(myDAL.Load(AddressId));
                    }
                }
				or=myAddressDT.FindByAddressId(AddressId);
			}
			return or;


		}
        public string PhoneMask(atriumDB.AddressRow adr)
        {
            if (adr == null)
                return "";

            if (adr.IsNull("CountryCode"))
                return "";
            switch (adr.CountryCode)
            {
                case "US":
                case "CA":
                case "USA":
                case "CDN":
                    return "(###) ###-####";  
                   
                default:
                    return "";
                   
            }
        }
		public void LoadByContactId(int ContactId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().AddressLoadByContactId(ContactId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByContactId(ContactId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByContactId(ContactId));
                }
            }
		}

      
		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myAddressDT.TableName;
			atriumDB.AddressRow dr=(atriumDB.AddressRow)ddr;
			WhereClause whereCl = new WhereClause();
			switch(dc.ColumnName)
			{
				case  "City":
					if(!dr.IsNull("CountryCode") && dr.CountryCode=="CDN")
					{
                        if (dr.IsCityNull())
                            throw new RequiredException(Resources.AddressCity);

                        if (myA.AtMng.GetSetting(AppBoolSetting.ValidateCity))
                        {
                            if (!dr.IsProvinceCodeNull())
                            {
                                DataTable dt = myA.Codes("vCity");
                                whereCl.Add("ProvinceCode", "=", dr.ProvinceCode);
                                
                                if (dt.Select(whereCl.Filter()).Length != 0)
                                {
                                    whereCl.Add("City", "=", dr.City);
                                    //dt = myA.AtMng.GetGeneralRec("City", whereCl);
                                    if (dt.Select(whereCl.Filter()).Length == 0)
                                        throw new AtriumException(Resources.AddressCityNotInProv, Resources.AddressCity, Resources.AddressProvince);
                                }
                            }
                        }
					}
					break;
				case  "ProvinceCode":
                    if (dr.IsProvinceCodeNull())
                    {
                        if (!dr.IsNull("CountryCode"))
                        {
                            if (dr.CountryCode == "CDN" || dr.CountryCode == "USA")
                                throw new RequiredException(Resources.AddressProvinceCode);
                        }
                    }
                    else
                    {
                        if (!dr.IsNull("CountryCode"))
                        {
                            if (dr.CountryCode == "CDN" || dr.CountryCode == "USA")
                            {
                                DataTable dtP = myA.Codes("Province");
                                atLogic.WhereClause wc = new atLogic.WhereClause();
                                wc.Add("CountryCode", "=", dr.CountryCode);

                                //if (!myA.Codes("Province").Rows.Contains(dr.ProvinceCode))
                                if (!dtP.Rows.Contains(dr.ProvinceCode))
                                    throw new AtriumException(Resources.IsNotValid, Resources.AddressProvinceCode);
                            }
                        }
                    }
					break;
				case  "CountryCode":
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.AddressCountryCode);

                    else if (!myA.Codes("Country").Rows.Contains(dr.CountryCode))
                        throw new AtriumException(Resources.IsNotValid, Resources.AddressCountryCode);
					break;
				case  "AddressSourceCode":
                    if (dr.IsAddressSourceCodeNull())
                        throw new RequiredException(Resources.AddressAddressSourceCode);
                    else if (!myA.Codes("AddressSource").Rows.Contains(dr.AddressSourceCode))
                        throw new AtriumException(Resources.IsNotValid, Resources.AddressAddressSourceCode);
					break;
				case  "AddressType":
                    if (dr.IsAddressTypeNull())
                        throw new RequiredException(Resources.AddressAddressType);
                    else if (!myA.Codes("AddressType").Rows.Contains(dr.AddressType))
                        throw new AtriumException(Resources.IsNotValid, Resources.AddressAddressType);
					break;
				case "Address1":
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.AddressAddress1);
					break;
				case  "EffectiveTo":
                    if (dr.IsEffectiveToNull())
                        throw new RequiredException(Resources.AddressEffectiveTo);
					myA.IsValidDate(Resources.AddressEffectiveTo,dr.EffectiveTo, false, DebtorBE.CSLBegin, DateTime.Today, Resources.ValidationCSLBegin, Resources.ValidationToday);
					break;
				default:
					break;
			}
		}

        public override void Validate(DataRow row)
        {
            atriumDB.AddressRow dr = (atriumDB.AddressRow)row;
            this.Validate("City", dr);
            this.Validate("ProvinceCode", dr);
            this.Validate("CountryCode", dr);
            this.Validate("Address1", dr);

            if (!dr.IsContactIdNull())
            {
                this.Validate("EffectiveTo", dr);
                this.Validate("AddressSourceCode", dr);
                this.Validate("AddressType", dr);
            }

        }
		protected override void BeforeUpdate(DataRow  row)
		{
			atriumDB.AddressRow dr = (atriumDB.AddressRow) row;
            Validate(row);
            if (dr.HasErrors)
                throw new AtriumException(ErrorsForTable(myDT));

		
            if (!myA.CurrentFile.IsOpponentIDNull() && dr.AddressType=="RE")
            {
                //COMMENTED OUT. DON'T NEED TO AUTO UPDATE VALUE OF "CURRENT" ANYMORE, RELFIELDS SHOULD HANDLE IT.
                //WTF?????
                //NOW there is an item in TFS to restore this.  What is the expected behaviour???

//                //check to see if this address has the most recent effective to
                atriumDB.AddressRow max = dr;
                foreach (atriumDB.AddressRow add in myAddressDT.Select("ContactId=" + myA.CurrentFile.OpponentID.ToString()))
                {
                    if (add.AddressType == "RE")
                    {
                        if (add.IsCurrentNull() || add.Current)
                            add.Current = false;
                        if (add.EffectiveTo > max.EffectiveTo)
                            max = add;
                    }
                }
                //                if (dr.EffectiveTo >= max.EffectiveTo)
                myA.GetCLASMng().GetDebtor().CurrentDebtor.AddressCurrentID = max.AddressId;

                max.Current = true;
            }
        }

		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myAddressDT.TableName;

			atriumDB.AddressRow dr=(atriumDB.AddressRow)ddr;
			switch(dc.ColumnName)
            {
                case "PostalCode":
                    if (dr.CountryCode == "CDN" || dr.CountryCode == "USA")
                    {
                        dr.PostalCode = dr.PostalCode.ToUpper();
                    }
                    break;
				default:
					break;
			}
		}
		
		protected override void BeforeAdd(DataRow dr)
		{
		}

        public override DataRow Add(DataRow parentRow)
        {
            if (parentRow.GetType() == typeof(CLAS.DebtorRow))
            {
                return AddX((CLAS.DebtorRow)parentRow);
            }
            else if (parentRow.GetType() == typeof(CLAS.PropertyRow))
            {
                return AddX((CLAS.PropertyRow)parentRow);
            }
            else if (parentRow.GetType() == typeof(atriumDB.ContactRow))
            {
                return AddX((atriumDB.ContactRow)parentRow);
            }
            else if (parentRow.GetType() == typeof(officeDB.OfficerRow))
            {
                return AddX((officeDB.OfficerRow)parentRow);
            }
            else if (parentRow.GetType() == typeof(officeDB.OfficeRow))
            {
                return AddX((officeDB.OfficeRow)parentRow);
            }

            else
                return base.Add(parentRow);
        }

        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.AddressRow addr = (atriumDB.AddressRow)dr;

            //CLAS hook
            if (!myA.CurrentFile.IsOpponentIDNull() && addr.ContactId == myA.CurrentFile.OpponentID)
            {
                //find contact and determine if update is occuring on current address
                atriumDB.ContactRow cr= myA.DB.Contact.FindByContactId(addr.ContactId);
                bool updateFileStuct=false;
                if (cr == null) //collections file opening; contact not in DB yet
                {
                    //find debtor in CLASManager DB
                    if (myA.GetCLASMng().DB.Debtor[0].AddressCurrentID == addr.AddressId)
                        updateFileStuct = true;
                }
                else if (!cr.IsAddressCurrentIDNull() && cr.AddressCurrentID == addr.AddressId)
                    updateFileStuct = true;

                if (updateFileStuct)
                {
                    //update toc for DB filecontact
                    System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                    xd.InnerXml = myA.CurrentFile.FileStructXml;
                    myA.GetFileContact().MyXml(myA.CurrentFile, xd);
                    myA.CurrentFile.FileStructXml = xd.InnerXml;
                }
            }
        }

        private DataRow AddX(CLAS.DebtorRow cr)
        {
            atriumDB.AddressRow dr = (atriumDB.AddressRow)base.Add(cr);

            dr.ContactId = cr.ContactId;
            if (cr.IsAddressCurrentIDNull())
                cr.AddressCurrentID = dr.AddressId;

            return dr;
        }

        private  DataRow AddX(atriumDB.ContactRow cr)
        {
            atriumDB.AddressRow dr = (atriumDB.AddressRow)base.Add(cr);

            dr.ContactId = cr.ContactId;
            if(cr.IsAddressCurrentIDNull())
                cr.AddressCurrentID = dr.AddressId;

            return dr;
        }
        private DataRow AddX(officeDB.OfficerRow cr)
        {
            atriumDB.AddressRow dr = (atriumDB.AddressRow)base.Add(cr);

            dr.ContactId = cr.OfficerId;
            if (cr.IsAddressCurrentIDNull())
                cr.AddressCurrentID = dr.AddressId;

            return dr;
        }

        private DataRow AddX(officeDB.OfficeRow cr)
        {
            atriumDB.AddressRow dr = (atriumDB.AddressRow)base.Add(cr);

            cr.AddressId = dr.AddressId;

            return dr;
        }
        private DataRow AddX(CLAS.PropertyRow cr)
        {
            atriumDB.AddressRow dr = (atriumDB.AddressRow)base.Add(cr);

            cr.AddressID = dr.AddressId;

            return dr;
        }
		protected override void AfterAdd(DataRow row)
		{
			atriumDB.AddressRow dr=(atriumDB.AddressRow)row;
			string ObjectName = this.myAddressDT.TableName;

            dr.Current = false;
            dr.AddressType = "RE";
            dr.EffectiveTo = DateTime.Today;

			//System.Diagnostics.Debug.WriteLine(dr["AddressId"] + dr.RowState.ToString() );
			if(dr.IsNull("AddressId") ||dr.AddressId==0 )
				dr.AddressId = this.myA.AtMng.PKIDGet(ObjectName,10);
            
            dr.CountryCode = "CDN";
            dr.AddressSourceCode = "HRDC";
			
            //if (!dr.IsContactIdNull())
            //{
            //    if(!myA.CurrentFile.IsOpponentIDNull() && (myA.GetCLASMng().GetDebtor().CurrentDebtor.IsAddressCurrentIDNull() || myA.GetCLASMng().GetDebtor().CurrentDebtor.RowState==DataRowState.Added))
            //        myA.GetCLASMng().GetDebtor().CurrentDebtor.AddressCurrentID=dr.AddressId;
            //}

		}
		
		protected override void BeforeDelete(DataRow row)
		{
			atriumDB.AddressRow dr = (atriumDB.AddressRow) row;
			string ObjectName = this.myAddressDT.TableName;
            if (myA.AtMng.GetSetting(AppBoolSetting.useCLASMngr))
            {
                //if (this.myA.GetCLASMng().DB.Debtor.FindByDebtorId(dr.ContactId) == null)
                //    this.myA.GetCLASMng().GetDebtor().Load(dr.ContactId);

                if (!myA.CurrentFile.IsOpponentIDNull() && dr.AddressId == myA.GetCLASMng().GetDebtor().CurrentDebtor.AddressCurrentID)
                    throw new AtriumException(Resources.AddressNoDelete);
                else
                    this.myA.GetActivity().DeleteRelatedCA(this.myA.CurrentFile.FileId, ObjectName, dr.AddressId);
            }
		}
		
		protected override void AfterDelete(DataRow dr)
		{
   

		}

        //public override DataRow[] GetParentRow()
        //{
        //    //load all rows so that effective date calc works
            

        //    //---JLL START
        //    //2010-08-09 cast fails when on one line, moving it to two seems to do the trick ... ??
        //    // broke it up on two lines, cast is fine.

        //    //atriumDB.DebtorRow[] drs=(atriumDB.DebtorRow[])myA.GetDebtor().GetCurrentRow();

        //    DataRow[] dr = myA.GetCLASMng().GetDebtor().GetCurrentRow();
        //    atriumDB.DebtorRow[] drs = (atriumDB.DebtorRow[])dr;
        //    //--JLL END


        //    if (drs.Length == 1)
        //        LoadByContactId(drs[0].ContactId);
        //    if (drs.Length == 0)
        //        return null;
        //    else
        //        return drs;
        //}

		public override DataRow[] GetCurrentRow()
		{
			if(!this.myA.CurrentFile.IsOpponentIDNull())
			{
                CLAS.DebtorRow dr = ( CLAS.DebtorRow)myA.GetCLASMng().GetDebtor().CurrentDebtor;
                LoadByContactId(dr.ContactId);
				return new DataRow[]{myAddressDT.FindByAddressId(dr.AddressCurrentID)};
			}
			else
				return base.GetCurrentRow();
		}

		public override string BestFKName()
		{
			return "AddressId";
		}


	}
}

