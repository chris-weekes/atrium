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
	public class DebtorBE:ContactBE
	{
		CLASManager myA;
		CLAS.DebtorDataTable myDebtorDT;
		
		internal DebtorBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Debtor)
		{
			myA=pBEMng;
			myDebtorDT=(CLAS.DebtorDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetDebtor();

            this.myDebtorDT.SINColumn.ExtendedProperties.Add("format", "### ### ###");
        }
        public atriumDAL.DebtorDAL myDAL
        {
            get
            {
                return (atriumDAL.DebtorDAL)myODAL;
            }
        }

        //public void LoadBySIN(string SIN)
        //{
        //    //implement loadbysin on debtordal
        //    //Fill(myA.DALMngr.ContactLoadBySIN(SIN));
        //}

        public CLAS.DebtorRow FindLoad(int DebtorId)
        {
            CLAS.DebtorRow dr = myDebtorDT.FindByDebtorId(DebtorId);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                if (myA.AtMng.AppMan.UseService)
                {
                    Fill(myA.AtMng.AppMan.AtriumX().DebtorLoad(DebtorId, myA.AtMng.AppMan.AtriumXCon));
                }
                else
                {
                    try
                    {
                        Fill(myDAL.Load(DebtorId));
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        Fill(myDAL.Load(DebtorId));
                    }
                }

                return myDebtorDT.FindByDebtorId(DebtorId);
            }
        }

        public CLAS.DebtorRow CurrentDebtor
        {
            get
            {
                return myDebtorDT.FindByDebtorId(myA.FM.CurrentFile.OpponentID);
            }
        }
		protected override void AfterAdd(DataRow row)
		{
			base.AfterAdd(row);
			CLAS.DebtorRow dr=(CLAS.DebtorRow)row;
			string ObjectName = this.myDebtorDT.TableName;

			dr.DebtorId =dr.ContactId;;         
			dr.AddressNotCurrent=false;
			dr.SIN="";
            dr.ContactClass = "D";
			
			this.myA.FM.CurrentFile.OpponentID=dr.DebtorId;

		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			base.BeforeChange(dc,ddr);
			string ObjectName = this.myDebtorDT.TableName;
			CLAS.DebtorRow dr=(CLAS.DebtorRow)ddr;
			switch(dc.ColumnName)
			{
				case "AddressCurrentID":
                    if (ddr.IsNull(dc))
                        throw new AtriumException(Resources.DebtAddressRqd);
					break;
				case "SexCode":
                    if (ddr.IsNull(dc))
                        throw new RequiredException(Resources.DebtorSexCode);
                    if (!dr.IsNull("SexCode") && !myA.CheckDomain(dr.SexCode, myA.FM.Codes("Sex")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Gender Code");
					break;
				case "LanguageCode":
                    if (ddr.IsNull(dc))
                        throw new RequiredException(Resources.DebtorLanguageCode);
                    else if (!myA.CheckDomain(dr.LanguageCode, myA.FM.Codes("LanguageCode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Language Code");
                    break;
				case "BirthDate":
                    if (ddr.IsNull(dc))
                        throw new RequiredException(Resources.DebtorBirthDate);
						
					myA.IsValidDate(Resources.DebtorBirthDate, (System.DateTime)ddr[dc], false, DateTime.Today.AddYears(-100), DateTime.Today.AddYears(-15),Resources.Validation100yearsago, Resources.Validation15yearsago);
					break;

				case "CeasedToBeStudentDate":
					if(!dr.IsCeasedToBeStudentDateNull())
						myA.IsValidDate(Resources.DebtorCeasedToBeStudentDate, dr.CeasedToBeStudentDate, false, DebtorBE.CSLBegin, DateTime.Today,Resources.ValidationCSLBegin, Resources.ValidationToday);
					break;
				default:
					break;
			}
		}

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.DebtorRow debtor = (CLAS.DebtorRow)dr;
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            myA.FM.GetFileContact().MyXml(myA.FM.CurrentFile, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }

		protected override void BeforeUpdate(DataRow row)
		{
			base.BeforeUpdate(row);
			CLAS.DebtorRow dr = (CLAS.DebtorRow) row;
			this.BeforeChange(dr.Table.Columns["CeasedToBeStudentDate"],dr);
			this.BeforeChange(row.Table.Columns["SIN"],row);
            if (dr.IsNull(atriumBE.ContactFields.SIN))
                throw new RequiredException(Resources.DebtorSIN);

		
			if (row.RowState!=DataRowState.Added && (!row["SIN",DataRowVersion.Original].Equals( row["SIN",DataRowVersion.Current]) ||!row["LastName",DataRowVersion.Original].Equals( row["LastName",DataRowVersion.Current]) || !row["FirstName",DataRowVersion.Original].Equals( row["FirstName",DataRowVersion.Current])))
			{
				this.myA.FM.GetAKA();

				atriumDB.AKARow drAka = this.myA.FM.DB.AKA.NewAKARow();
				this.myA.FM.DB.AKA.AddAKARow(drAka);
				drAka.BeginEdit();
				drAka.LastName = row["LastName",DataRowVersion.Original].ToString();
				drAka.FirstName = row["FirstName",DataRowVersion.Original].ToString();
				drAka.SIN = row["SIN",DataRowVersion.Original].ToString();
				drAka.ContactId=(int)row["ContactId"];
				drAka.EndEdit();
				
			}

			if(this.myA.FM.CurrentFile.OpponentID==(int)row["ContactId"])
			{
				this.myA.FM.CurrentFile.NameE=String.Format("{0}, {1}",row["LastName"],row["FirstName"]);
				this.myA.FM.CurrentFile.NameF=String.Format("{0}, {1}",row["LastName"],row["FirstName"]);

			}

		}
	
		public override DataRow[] GetCurrentRow()
		{
            return myDebtorDT.Select();
		}

        static public DateTime CSLBegin
        {
            get
            {
                return DateTime.Parse(@"1964/01/01");
            }
        }

        static public string FormattedSIN(string SIN)
        {
            Double rar = Convert.ToDouble(SIN);
            return String.Format("{0:### ### ###}", rar);
        }


        public override bool CanDelete(DataRow dr)
        {
            //JLL: defaulted to false;

            return false;
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.DebtorRow fhr = (CLAS.DebtorRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.Debtor);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }
    }
}

