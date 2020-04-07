using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class ContactEmailBE:atLogic.ObjectBE
	{
		OfficeManager myA;
		officeDB.ContactEmailDataTable myContactEmailDT;


        internal ContactEmailBE(OfficeManager pBEMng)
            : base(pBEMng, pBEMng.DB.ContactEmail)
		{
			myA=pBEMng;
			myContactEmailDT=(officeDB.ContactEmailDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetContactEmail();
        }
        public atriumDAL.ContactEmailDAL myDAL
        {
            get
            {
                return (atriumDAL.ContactEmailDAL)myODAL;
            }
        }

	

        public void LoadByContactId(int contactId)
        {
            if (myA.AtMng.AppMan.UseService)
                Fill(myA.AtMng.AppMan.AtriumX().ContactEmailLoadByContactId(contactId, myA.AtMng.AppMan.AtriumXCon));
            else
            {
                try
                {
                    Fill(myDAL.LoadByContactId(contactId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByContactId(contactId));
                }
            }
        }

        public void LoadByEmail(string email)
        {
            if (myA.AtMng.AppMan.UseService)
                Fill(myA.AtMng.AppMan.AtriumX().ContactEmailLoadByEmail(email, myA.AtMng.AppMan.AtriumXCon));
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
        }

        protected override void AfterAdd(DataRow row)
        {
            officeDB.ContactEmailRow dr = (officeDB.ContactEmailRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = this.myA.AtMng.PKIDGet(ObjectName, 1);
            
            if (dr.OfficerRow != null)
            {
                //if (dr.OfficerRow.GetContactEmailRows().Length == 1)
                //    dr.Main = true;
                //else
                    dr.Main = false;

                dr.DisplayName = dr.OfficerRow.FirstName + " " + dr.OfficerRow.LastName;
            }
            else
                dr.Main = false;
            
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            officeDB.ContactEmailRow dr = (officeDB.ContactEmailRow)row;
            switch (dc.ColumnName)
            {
                case "Email":
                case "Main":
                    if (dr.Main)
                    {
                        dr.OfficerRow.EmailAddress = dr.Email;
                    }
                    foreach (officeDB.ContactEmailRow cr in dr.OfficerRow.GetContactEmailRows())
                    {
                        if(dr.Id!=cr.Id & cr.Main)
                            cr.Main = false;
                    }
                    break;
            }
        }
    }
}

