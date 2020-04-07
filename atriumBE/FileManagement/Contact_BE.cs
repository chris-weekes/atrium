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
	public class ContactBE:atLogic.ObjectBE
	{
        //atriumBE.atriumManager myA;
        atLogic.BEManager myA;
		//atriumDB.ContactDataTable myContactDT;

        protected ContactBE(atLogic.BEManager pBEMng, DataTable pdt)
            : base(pBEMng,pdt)
		{
			myA=pBEMng;
			init(pdt);

		}

		private void init(DataTable pdt)
		{
		}

		protected override void AfterAdd(DataRow row)
		{
			//atriumDB.ContactRow dr=(atriumDB.ContactRow)row;
			string ObjectName = "Contact";
			//System.Diagnostics.Debug.WriteLine(dr["ContactId"] + dr.RowState.ToString() );
//|| System.Convert.ToInt32(row["ContactId"])!=0
            if (row.IsNull("ContactId"))
            {
                AtriumApp aa = (AtriumApp)myA.AppMan;
                row["ContactId"] =aa.AtMng.PKIDGet(ObjectName, 10);
            }
			row["AddressNotCurrent"]=false;

            
		}

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {
            switch (dc.ColumnName)
            {

                case "FirstName":
                case "LastName":
                    if (!ddr.IsNull("LastName") && (ddr["LastName"].ToString().StartsWith(" ") || ddr["LastName"].ToString().EndsWith(" ")))
                        ddr["LastName"] = ddr["LastName"].ToString().Trim();

                    if (!ddr.IsNull("FirstName") && (ddr["FirstName"].ToString().StartsWith(" ") || ddr["FirstName"].ToString().EndsWith(" ")))
                        ddr["FirstName"] = ddr["FirstName"].ToString().Trim();

                    if (!ddr.IsNull("LastName") & !ddr.IsNull("FirstName") && ddr.GetType()!=typeof(CLAS.DebtorRow))
                        ddr["DisplayName"] = ddr["LastName"].ToString() + ", " + ddr["FirstName"].ToString();
                    break;
                case "LegalName":
                case "OperatingAs":
                    if (!ddr.IsNull("LegalName"))
                        ddr["DisplayName"] = ddr["LegalName"].ToString().Trim();
                    break;
            }
        }
		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = "Contact";
            //atriumDB.ContactRow dr = (atriumDB.ContactRow)ddr;
            //LanguageCode;
            //dr.SexCode
			switch(dc.ColumnName)
			{
                    
				case "FirstName":
				case "LastName":
                    if (ddr["ContactClass"].ToString() != "P" && ddr["ContactClass"].ToString() != "B" && (ddr.IsNull(dc) || ddr[dc].ToString() == ""))
						throw new RequiredException(Resources.ResourceManager.GetString(dc.ColumnName));

                    if (ddr["ContactClass"].ToString() == "P")
                    {
                        if ((!ddr.IsNull("LastName") | !ddr.IsNull("FirstName") | !ddr.IsNull("SIN")) & (!ddr.IsNull("LegalName") | !ddr.IsNull("BusinessNumber") | !ddr.IsNull("OperatingAs")))
                        {
                            throw new AtriumException("A party cannot be a person and an entity");
                        }
                    }
                    if (ddr["ContactClass"].ToString() == "B") //CLAS
                    {
                        if ((!ddr.IsNull("LastName") | !ddr.IsNull("FirstName") | !ddr.IsNull("SIN")) & (!ddr.IsNull("LegalName") | !ddr.IsNull("BusinessNumber") | !ddr.IsNull("OperatingAs")))
                        {
                            throw new AtriumException("A business cannot be a person.  Use the To The Attention Of field to capture someone's name at the business level");
                        }
                    }
					break;
                case "LegalName":
                case "BusinessNumber":
                case "OperatingAs":
                    if (ddr["ContactClass"].ToString() == "P")
                    {
                        if ((!ddr.IsNull("LastName") | !ddr.IsNull("FirstName") | !ddr.IsNull("SIN")) & (!ddr.IsNull("LegalName") | !ddr.IsNull("BusinessNumber") | !ddr.IsNull("OperatingAs")))
                        {
                            throw new AtriumException("A party cannot be a person and an entity");
                        }
                    }
                    if (ddr["ContactClass"].ToString() == "B") //CLAS
                    {
                        if ((!ddr.IsNull("LastName") | !ddr.IsNull("FirstName") | !ddr.IsNull("SIN")) & (!ddr.IsNull("LegalName") | !ddr.IsNull("BusinessNumber") | !ddr.IsNull("OperatingAs")))
                        {
                            throw new AtriumException("A party cannot be a person and an entity");
                        }
                    }

                    if (dc.ColumnName=="BusinessNumber" && !ddr.IsNull(dc))
                        ddr[dc] = ddr[dc].ToString().ToUpper();

                    break;
				case "SIN":
					if(!ddr.IsNull(dc))
					{
						int dupCount=Convert.ToInt32(myA.AppMan.ExecuteScalar("ContactDuplicateSIN",new object[]{ddr[dc].ToString()}));
						if (ddr[dc].ToString().Length!= 9 || !ContactBE.IsValidSIN(ddr[dc].ToString()) )
						{
                            throw new AtriumException(Resources.BadSIN, ddr[dc].ToString());
						}
						if (dupCount > 0 && ddr.RowState==DataRowState.Added)
                            throw new AtriumException(Resources.DebtDuplicateSIN);
						if(dupCount > 1 )
						{
                            throw new AtriumException(Resources.DebtDuplicateSIN);
						}
					}
                    if (ddr["ContactClass"].ToString() == "P")
                    {
                        if ((!ddr.IsNull("LastName") | !ddr.IsNull("FirstName") | !ddr.IsNull("SIN")) & (!ddr.IsNull("LegalName") | !ddr.IsNull("BusinessNumber") | !ddr.IsNull("OperatingAs")))
                        {
                            throw new AtriumException("A party cannot be a person and an entity");
                        }
                    }
					break;
                case "LanguageCode":
                    if (!ddr.IsNull(dc))
                    {
                        //if (!myA.CheckDomain(ddr["LanguageCode"], myA.Codes("LanguageCode")))
                        //    throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Language Code");
                    }
                    break;
                case "SexCode":
                    if (!ddr.IsNull(dc))
                    {
                        //if (!myA.CheckDomain(ddr["SexCode"], myA.Codes("Sex")))
                        //    throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Gender Code");
                    }
                    break;
				default:
					break;
			}
		}
        public override void Validate(DataRow dr)
        {
            this.Validate("FirstName", dr);
            this.Validate("LastName", dr);
            //if (dr.HasErrors)
            //    throw new AtriumException(ErrorsForTable(myDT));
        }
		protected override void BeforeUpdate(DataRow row)
		{

            Validate(row);
            if (row.HasErrors)
                throw new AtriumException(ErrorsForTable(myDT));
		}
        public static bool IsValidSIN(string sin)
        {
            //this function validates the SIN using the mod 10 method
            int a;
            int b;
            int c;
            int d;
            int e;
            int f;
            int g;
            int h;
            int i;
            int J;
            int K;
            int m;

            //string sSIN;

            //sSIN = CStr(vSIN)

            a = Convert.ToInt32(sin.Substring(0, 1));
            b = Convert.ToInt32(sin.Substring(1, 1));
            c = Convert.ToInt32(sin.Substring(2, 1));
            d = Convert.ToInt32(sin.Substring(3, 1));
            e = Convert.ToInt32(sin.Substring(4, 1));
            f = Convert.ToInt32(sin.Substring(5, 1));
            g = Convert.ToInt32(sin.Substring(6, 1));
            h = Convert.ToInt32(sin.Substring(7, 1));
            i = Convert.ToInt32(sin.Substring(8, 1));

            b = 2 * b;
            if (b > 9) { b = b - 9; }

            d = 2 * d;
            if (d > 9) { d = d - 9; }

            f = 2 * f;
            if (f > 9) { f = f - 9; }

            h = 2 * h;
            if (h > 9) { h = h - 9; }

            J = 0;
            J = a + b + c + d + e + f + g + h;
            if (J % 10 == 0)
                K = (J / 10) * 10;
            else
                K = ((J / 10) + 1) * 10;

            m = K - J;

            if (m == i)
                return true;
            else
                return false;
        }

	}
}

