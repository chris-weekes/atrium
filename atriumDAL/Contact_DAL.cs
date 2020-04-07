using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Contact table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class ContactDAL:atDAL.ObjectDAL
	{

    	internal ContactDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
        {


            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Contact", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("ContactId", "ContactId"),
		  new System.Data.Common.DataColumnMapping("SIN", "SIN"),
		  new System.Data.Common.DataColumnMapping("Salutation", "Salutation"),
		  new System.Data.Common.DataColumnMapping("LastName", "LastName"),
		  new System.Data.Common.DataColumnMapping("MiddleName", "MiddleName"),
		  new System.Data.Common.DataColumnMapping("FirstName", "FirstName"),
		  new System.Data.Common.DataColumnMapping("Suffix", "Suffix"),
		  new System.Data.Common.DataColumnMapping("AddressCurrentID", "AddressCurrentID"),
		  new System.Data.Common.DataColumnMapping("TelephoneNumber", "TelephoneNumber"),
		  new System.Data.Common.DataColumnMapping("TelephoneExtension", "TelephoneExtension"),
		  new System.Data.Common.DataColumnMapping("CellPhone", "CellPhone"),
		  new System.Data.Common.DataColumnMapping("FaxNumber", "FaxNumber"),
		  new System.Data.Common.DataColumnMapping("EmailAddress", "EmailAddress"),
		  new System.Data.Common.DataColumnMapping("SexCode", "SexCode"),
		  new System.Data.Common.DataColumnMapping("BirthDate", "BirthDate"),
		  new System.Data.Common.DataColumnMapping("LanguageCode", "LanguageCode"),
		  new System.Data.Common.DataColumnMapping("AddressNotCurrent", "AddressNotCurrent"),
		  new System.Data.Common.DataColumnMapping("Notes", "Notes"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("Company", "Company"),
		  new System.Data.Common.DataColumnMapping("PartyTypeCode", "PartyTypeCode"),
		  new System.Data.Common.DataColumnMapping("BusinessNumber", "BusinessNumber"),
		  new System.Data.Common.DataColumnMapping("LegalName", "LegalName"),
		  new System.Data.Common.DataColumnMapping("OperatingAs", "OperatingAs"),
		  new System.Data.Common.DataColumnMapping("Attention", "Attention"),
		  new System.Data.Common.DataColumnMapping("ContactClass", "ContactClass"), 
			})});

            // 
            // sqlSelect
            // 
            this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelect.Connection = myDALManager.SqlCon;

            this.sqlSelectAll.CommandText = "[ContactSelect]";
            this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectAll.Connection = myDALManager.SqlCon;
            this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            // 
            // sqlInsert
            // 
            this.sqlInsert.CommandText = "[ContactInsert]";
            this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsert.Connection = myDALManager.SqlCon;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlInsert.Parameters.Add(new SqlParameter("@ContactId", SqlDbType.Int, 10, "ContactId"));
            this.sqlInsert.Parameters["@ContactId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SIN", SqlDbType.Char, 9, "SIN"));
            this.sqlInsert.Parameters["@SIN"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Salutation", SqlDbType.NVarChar, 50, "Salutation"));
            this.sqlInsert.Parameters["@Salutation"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50, "LastName"));
            this.sqlInsert.Parameters["@LastName"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName"));
            this.sqlInsert.Parameters["@MiddleName"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, "FirstName"));
            this.sqlInsert.Parameters["@FirstName"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Suffix", SqlDbType.NVarChar, 50, "Suffix"));
            this.sqlInsert.Parameters["@Suffix"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AddressCurrentID", SqlDbType.Int, 10, "AddressCurrentID"));
            this.sqlInsert.Parameters["@AddressCurrentID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@TelephoneNumber", SqlDbType.NVarChar, 30, "TelephoneNumber"));
            this.sqlInsert.Parameters["@TelephoneNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@TelephoneExtension", SqlDbType.NVarChar, 6, "TelephoneExtension"));
            this.sqlInsert.Parameters["@TelephoneExtension"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@CellPhone", SqlDbType.NVarChar, 30, "CellPhone"));
            this.sqlInsert.Parameters["@CellPhone"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FaxNumber", SqlDbType.NVarChar, 30, "FaxNumber"));
            this.sqlInsert.Parameters["@FaxNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 255, "EmailAddress"));
            this.sqlInsert.Parameters["@EmailAddress"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SexCode", SqlDbType.Char, 1, "SexCode"));
            this.sqlInsert.Parameters["@SexCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.SmallDateTime, 24, "BirthDate"));
            this.sqlInsert.Parameters["@BirthDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LanguageCode", SqlDbType.Char, 1, "LanguageCode"));
            this.sqlInsert.Parameters["@LanguageCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@AddressNotCurrent", SqlDbType.Bit, 1, "AddressNotCurrent"));
            this.sqlInsert.Parameters["@AddressNotCurrent"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar, -1, "Notes"));
            this.sqlInsert.Parameters["@Notes"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
            this.sqlInsert.Parameters["@entryUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
            this.sqlInsert.Parameters["@entryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
            this.sqlInsert.Parameters["@updateUser"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
            this.sqlInsert.Parameters["@updateDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            this.sqlInsert.Parameters["@ts"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Company", SqlDbType.NVarChar, 128, "Company"));
            this.sqlInsert.Parameters["@Company"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@PartyTypeCode", SqlDbType.NVarChar, 4, "PartyTypeCode"));
            this.sqlInsert.Parameters["@PartyTypeCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BusinessNumber", SqlDbType.NVarChar, 50, "BusinessNumber"));
            this.sqlInsert.Parameters["@BusinessNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LegalName", SqlDbType.NVarChar, 255, "LegalName"));
            this.sqlInsert.Parameters["@LegalName"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OperatingAs", SqlDbType.NVarChar, 255, "OperatingAs"));
            this.sqlInsert.Parameters["@OperatingAs"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Attention", SqlDbType.NVarChar, 50, "Attention"));
            this.sqlInsert.Parameters["@Attention"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ContactClass", SqlDbType.Char, 1, "ContactClass"));
            this.sqlInsert.Parameters["@ContactClass"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlUpdate
            // 
            this.sqlUpdate.CommandText = "[ContactUpdate]";
            this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdate.Connection = myDALManager.SqlCon;
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlUpdate.Parameters.Add(new SqlParameter("@ContactId", SqlDbType.Int, 10, "ContactId"));
            this.sqlUpdate.Parameters["@ContactId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SIN", SqlDbType.Char, 9, "SIN"));
            this.sqlUpdate.Parameters["@SIN"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Salutation", SqlDbType.NVarChar, 50, "Salutation"));
            this.sqlUpdate.Parameters["@Salutation"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50, "LastName"));
            this.sqlUpdate.Parameters["@LastName"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName"));
            this.sqlUpdate.Parameters["@MiddleName"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50, "FirstName"));
            this.sqlUpdate.Parameters["@FirstName"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Suffix", SqlDbType.NVarChar, 50, "Suffix"));
            this.sqlUpdate.Parameters["@Suffix"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AddressCurrentID", SqlDbType.Int, 10, "AddressCurrentID"));
            this.sqlUpdate.Parameters["@AddressCurrentID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@TelephoneNumber", SqlDbType.NVarChar, 30, "TelephoneNumber"));
            this.sqlUpdate.Parameters["@TelephoneNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@TelephoneExtension", SqlDbType.NVarChar, 6, "TelephoneExtension"));
            this.sqlUpdate.Parameters["@TelephoneExtension"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@CellPhone", SqlDbType.NVarChar, 30, "CellPhone"));
            this.sqlUpdate.Parameters["@CellPhone"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FaxNumber", SqlDbType.NVarChar, 30, "FaxNumber"));
            this.sqlUpdate.Parameters["@FaxNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 255, "EmailAddress"));
            this.sqlUpdate.Parameters["@EmailAddress"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SexCode", SqlDbType.Char, 1, "SexCode"));
            this.sqlUpdate.Parameters["@SexCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.SmallDateTime, 24, "BirthDate"));
            this.sqlUpdate.Parameters["@BirthDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LanguageCode", SqlDbType.Char, 1, "LanguageCode"));
            this.sqlUpdate.Parameters["@LanguageCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@AddressNotCurrent", SqlDbType.Bit, 1, "AddressNotCurrent"));
            this.sqlUpdate.Parameters["@AddressNotCurrent"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Notes", SqlDbType.NVarChar, -1, "Notes"));
            this.sqlUpdate.Parameters["@Notes"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
            this.sqlUpdate.Parameters["@entryUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
            this.sqlUpdate.Parameters["@entryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
            this.sqlUpdate.Parameters["@updateUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
            this.sqlUpdate.Parameters["@updateDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
            this.sqlUpdate.Parameters["@ts"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Company", SqlDbType.NVarChar, 128, "Company"));
            this.sqlUpdate.Parameters["@Company"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@PartyTypeCode", SqlDbType.NVarChar, 4, "PartyTypeCode"));
            this.sqlUpdate.Parameters["@PartyTypeCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BusinessNumber", SqlDbType.NVarChar, 50, "BusinessNumber"));
            this.sqlUpdate.Parameters["@BusinessNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LegalName", SqlDbType.NVarChar, 255, "LegalName"));
            this.sqlUpdate.Parameters["@LegalName"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OperatingAs", SqlDbType.NVarChar, 255, "OperatingAs"));
            this.sqlUpdate.Parameters["@OperatingAs"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Attention", SqlDbType.NVarChar, 50, "Attention"));
            this.sqlUpdate.Parameters["@Attention"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ContactClass", SqlDbType.Char, 1, "ContactClass"));
            this.sqlUpdate.Parameters["@ContactClass"].SourceVersion = DataRowVersion.Current;

             
            // 
            // sqlDelete
            // 
            this.sqlDelete.CommandText = "[ContactDelete]";
            this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDelete.Connection = myDALManager.SqlCon;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, "ContactId"));
            this.sqlDelete.Parameters["@ContactId"].SourceVersion = DataRowVersion.Original;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
            this.sqlDelete.Parameters["@ts"].SourceVersion = DataRowVersion.Original;



        }
        public atriumDB.ContactDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.ContactDataTable dt=new atriumDB.ContactDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public atriumDB.ContactDataTable Load(int ContactId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[ContactSelectByContactId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@ContactId"].Value=ContactId;

            atriumDB.ContactDataTable dt=new atriumDB.ContactDataTable();
			Fill(dt);
            return dt;
		}



	}
	

}