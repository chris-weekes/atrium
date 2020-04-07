using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.Collections.Generic;
using System.Linq;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class PersonBE:ContactBE
	{
		FileManager myA;
		atriumDB.ContactDataTable myPersonDT;
		
		internal PersonBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.Contact)
		{
			myA=pBEMng;
			myPersonDT=(atriumDB.ContactDataTable)myDT;

            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetContact();
        }

        public atriumDAL.ContactDAL myDAL
        {
            get
            {
                return (atriumDAL.ContactDAL)myODAL;
            }
        }

        public void LoadBySIN(string SIN)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().PersonLoadBySIN(SIN, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadBySIN(SIN));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadBySIN(SIN));
                }
            }
        }

		public atriumDB.ContactRow Load(int PersonId)
		{
            if (myA.AtMng.AppMan.UseService)
                Fill(myA.AtMng.AppMan.AtriumX().ContactLoadByte(PersonId, myA.AtMng.AppMan.AtriumXCon));
            else
            {
                try
                {
                    Fill(myDAL.LoadByte(PersonId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByte(PersonId));
                }
            }
			return myPersonDT.FindByContactId(PersonId);

		}

		

		protected override void AfterAdd(DataRow row)
		{
			base.AfterAdd(row);
			atriumDB.ContactRow dr=(atriumDB.ContactRow)row;
			string ObjectName = this.myPersonDT.TableName;

            dr.AddressNotCurrent = false;
            dr.ContactClass = "C";

            //TODO 2013-2-12 CJW do we really need this here?  What lists are getting cached of contacts
            //myA.AtMng.ClearCodesCache();

		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
            string ObjectName = this.myPersonDT.TableName;
            atriumDB.ContactRow dr = (atriumDB.ContactRow)ddr;

            try
            {
                base.BeforeChange(dc, ddr);
            }
            catch (AtriumException x)
            {
                switch (dc.ColumnName)
                {
                       
                    case "SIN":
                        //TFS#54669 CJW 2013-09-20  call swapsin when a duplicate
                        if (x.Message == atriumBE.Properties.Resources.DebtDuplicateSIN)
                        {
                            SwapBySIN(dr, dr.SIN);
                        }
                        else
                            throw;
                        break;
                    default:
                        throw;
                }


            }

		}
        public override void Validate(DataRow row)
        {
            base.Validate(row);
        }

		protected override void BeforeUpdate(DataRow row)
		{
			base.BeforeUpdate(row);
            atriumDB.ContactRow dr = (atriumDB.ContactRow)row;
             
                //find the related filecontact record and force an update on it by setting updateDate = DateTime.Now.ToUniversalTime();
            atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)myA.DB.FileContact.Select("ContactId=" + dr.ContactId.ToString())[0];
            if (fcr != null)
            {
                fcr.updateDate = DateTime.Now.ToUniversalTime();
            }
			if (row.RowState!=DataRowState.Added && (!row["SIN",DataRowVersion.Original].Equals( row["SIN",DataRowVersion.Current]) ||!row["LastName",DataRowVersion.Original].Equals( row["LastName",DataRowVersion.Current]) || !row["FirstName",DataRowVersion.Original].Equals( row["FirstName",DataRowVersion.Current])))
			{
                if(!row.IsNull(myPersonDT.LastNameColumn, DataRowVersion.Original) && !row.IsNull(myPersonDT.FirstNameColumn, DataRowVersion.Original))
                {
				this.myA.GetAKA();

				atriumDB.AKARow drAka = this.myA.DB.AKA.NewAKARow();
				this.myA.DB.AKA.AddAKARow(drAka);
				drAka.BeginEdit();
				drAka.LastName = row["LastName",DataRowVersion.Original].ToString();
				drAka.FirstName = row["FirstName",DataRowVersion.Original].ToString();
				drAka.SIN = row["SIN",DataRowVersion.Original].ToString();
				drAka.ContactId=(int)row["ContactId"];
				drAka.EndEdit();
                }
				//this.myA.GetAKA().Update();
				//drAka.AcceptChanges();
				
			}


		}

        //public override DataRow[] GetParentRow()
        //{
        //    return base.GetParentRow();
        //}
		public override DataRow[] GetCurrentRow()
		{
			if(this.myPersonDT.Rows.Count==1)
				return myPersonDT.Select();

			if(!this.myA.CurrentFile.IsOpponentIDNull())
			{
				int PersonId=this.myA.CurrentFile.OpponentID;
				return new DataRow[]{Load( PersonId)};
			}
			else
			{
				return myPersonDT.Select();
				//throw new AtriumException(this.myA,(int)AtriumEnum.AppErrorCodes.BadSIN);
			}
		}


        public atriumDB.ContactRow SwapBySIN(atriumDB.ContactRow pr, string SIN)
        {
            if (pr.RowState == DataRowState.Added)
            {
                //load exisiting party row
                LoadBySIN(SIN);

                myA.RaiseWarning(WarningLevel.Display, Properties.Resources.ExistingPartyFound, myA.AtMng.AppMan.AppName);

                var ps = from p in myPersonDT
                         where !p.IsSINNull() && p.SIN == SIN
                         && pr.ContactId != p.ContactId
                         select p;

                atriumDB.ContactRow existingPerson = ps.Single();


                int currentContactId = pr.ContactId;


                //replace party row in related fields
                ACEngine ace = myA.CurrentActivityProcess.CurrentACE;
                if (ace.relTables.ContainsKey("Party0"))
                {
                    DataView dv = new DataView(myPersonDT, "ContactId=" + existingPerson.ContactId.ToString(), "", DataViewRowState.CurrentRows);
                    
                    ace.relTables["Party0"].RowFilter = dv.RowFilter;
                }

                //swap address
                if (ace.relTables.ContainsKey("Address0") && !existingPerson.IsAddressCurrentIDNull())
                {
                    myA.DB.Address.FindByAddressId(pr.AddressCurrentID).Delete();
                    myA.GetAddress().Load(existingPerson.AddressCurrentID);
                    DataView dv = new DataView(myA.DB.Address, "AddressId=" + existingPerson.AddressCurrentID.ToString(), "", DataViewRowState.CurrentRows);
                    ace.relTables["Address0"].RowFilter = dv.RowFilter;
                }
                else if (ace.relTables.ContainsKey("Address0") && existingPerson.IsAddressCurrentIDNull())
                {
                    atriumDB.AddressRow adr = myA.DB.Address.FindByAddressId(pr.AddressCurrentID);
                    adr.ContactId = existingPerson.ContactId;
                    existingPerson.AddressCurrentID = adr.AddressId;
                }


                //change contact id on filecontact
                var fcs = from fc in myA.DB.FileContact
                          where !fc.IsNull("ContactId") && fc.ContactId == currentContactId
                          select fc;

                if (fcs.Count() == 1)
                {
                    atriumDB.FileContactRow fcr = fcs.Single();
                    fcr.ContactId = existingPerson.ContactId;
                }

                pr.Delete();
                //    pr.AcceptChanges();

                return existingPerson;
            }
            else
                return pr;
        }

        

    }
}

