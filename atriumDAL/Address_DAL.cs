using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Address table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class AddressDAL:atDAL.ObjectDAL
	{

    	internal AddressDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Address", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("AddressId", "AddressId"),
		  new System.Data.Common.DataColumnMapping("ContactId", "ContactId"),
		  new System.Data.Common.DataColumnMapping("Address1", "Address1"),
		  new System.Data.Common.DataColumnMapping("Address2", "Address2"),
		  new System.Data.Common.DataColumnMapping("Address3", "Address3"),
		  new System.Data.Common.DataColumnMapping("City", "City"),
		  new System.Data.Common.DataColumnMapping("ProvinceCode", "ProvinceCode"),
		  new System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"),
		  new System.Data.Common.DataColumnMapping("CountryCode", "CountryCode"),
		  new System.Data.Common.DataColumnMapping("EmailAddress", "EmailAddress"),
		  new System.Data.Common.DataColumnMapping("HomePhone", "HomePhone"),
		  new System.Data.Common.DataColumnMapping("WorkPhone", "WorkPhone"),
		  new System.Data.Common.DataColumnMapping("WorkExtension", "WorkExtension"),
		  new System.Data.Common.DataColumnMapping("MobilePhone", "MobilePhone"),
		  new System.Data.Common.DataColumnMapping("FaxNumber", "FaxNumber"),
		  new System.Data.Common.DataColumnMapping("AddressSourceCode", "AddressSourceCode"),
		  new System.Data.Common.DataColumnMapping("JDCode", "JDCode"),
		  new System.Data.Common.DataColumnMapping("AddressType", "AddressType"),
		  new System.Data.Common.DataColumnMapping("EffectiveTo", "EffectiveTo"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("Address1Fre", "Address1Fre"),
		  new System.Data.Common.DataColumnMapping("Address2Fre", "Address2Fre"),
		  new System.Data.Common.DataColumnMapping("Address3Fre", "Address3Fre"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[AddressSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[AddressInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@AddressId", SqlDbType.Int, 4, "AddressId"));
			this.sqlInsert.Parameters["@AddressId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ContactId", SqlDbType.Int, 4, "ContactId"));
			this.sqlInsert.Parameters["@ContactId"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 50, "Address1"));
			this.sqlInsert.Parameters["@Address1"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 50, "Address2"));
			this.sqlInsert.Parameters["@Address2"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Address3", SqlDbType.NVarChar, 50, "Address3"));
			this.sqlInsert.Parameters["@Address3"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 50, "City"));
			this.sqlInsert.Parameters["@City"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ProvinceCode", SqlDbType.NVarChar, 50, "ProvinceCode"));
			this.sqlInsert.Parameters["@ProvinceCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar, 20, "PostalCode"));
			this.sqlInsert.Parameters["@PostalCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@CountryCode", SqlDbType.NVarChar, 50, "CountryCode"));
			this.sqlInsert.Parameters["@CountryCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 255, "EmailAddress"));
			this.sqlInsert.Parameters["@EmailAddress"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HomePhone", SqlDbType.NVarChar, 30, "HomePhone"));
			this.sqlInsert.Parameters["@HomePhone"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@WorkPhone", SqlDbType.NVarChar, 30, "WorkPhone"));
			this.sqlInsert.Parameters["@WorkPhone"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@WorkExtension", SqlDbType.NVarChar, 10, "WorkExtension"));
			this.sqlInsert.Parameters["@WorkExtension"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 30, "MobilePhone"));
			this.sqlInsert.Parameters["@MobilePhone"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@FaxNumber", SqlDbType.NVarChar, 30, "FaxNumber"));
			this.sqlInsert.Parameters["@FaxNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AddressSourceCode", SqlDbType.NVarChar, 6, "AddressSourceCode"));
			this.sqlInsert.Parameters["@AddressSourceCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@JDCode", SqlDbType.NVarChar, 50, "JDCode"));
			this.sqlInsert.Parameters["@JDCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@AddressType", SqlDbType.NVarChar, 2, "AddressType"));
			this.sqlInsert.Parameters["@AddressType"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@EffectiveTo", SqlDbType.SmallDateTime, 24, "EffectiveTo"));
			this.sqlInsert.Parameters["@EffectiveTo"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			//this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			//this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Address1Fre", SqlDbType.NVarChar, 50, "Address1Fre"));
            this.sqlInsert.Parameters["@Address1Fre"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Address2Fre", SqlDbType.NVarChar, 50, "Address2Fre"));
            this.sqlInsert.Parameters["@Address2Fre"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Address3Fre", SqlDbType.NVarChar, 50, "Address3Fre"));
            this.sqlInsert.Parameters["@Address3Fre"].SourceVersion = DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[AddressUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AddressId", SqlDbType.Int, 4, "AddressId"));
			this.sqlUpdate.Parameters["@AddressId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ContactId", SqlDbType.Int, 4, "ContactId"));
			this.sqlUpdate.Parameters["@ContactId"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Address1", SqlDbType.NVarChar, 50, "Address1"));
			this.sqlUpdate.Parameters["@Address1"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Address2", SqlDbType.NVarChar, 50, "Address2"));
			this.sqlUpdate.Parameters["@Address2"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Address3", SqlDbType.NVarChar, 50, "Address3"));
			this.sqlUpdate.Parameters["@Address3"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 50, "City"));
			this.sqlUpdate.Parameters["@City"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ProvinceCode", SqlDbType.NVarChar, 50, "ProvinceCode"));
			this.sqlUpdate.Parameters["@ProvinceCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar, 20, "PostalCode"));
			this.sqlUpdate.Parameters["@PostalCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@CountryCode", SqlDbType.NVarChar, 50, "CountryCode"));
			this.sqlUpdate.Parameters["@CountryCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@EmailAddress", SqlDbType.NVarChar, 255, "EmailAddress"));
			this.sqlUpdate.Parameters["@EmailAddress"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HomePhone", SqlDbType.NVarChar, 30, "HomePhone"));
			this.sqlUpdate.Parameters["@HomePhone"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@WorkPhone", SqlDbType.NVarChar, 30, "WorkPhone"));
			this.sqlUpdate.Parameters["@WorkPhone"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@WorkExtension", SqlDbType.NVarChar, 10, "WorkExtension"));
			this.sqlUpdate.Parameters["@WorkExtension"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@MobilePhone", SqlDbType.NVarChar, 30, "MobilePhone"));
			this.sqlUpdate.Parameters["@MobilePhone"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@FaxNumber", SqlDbType.NVarChar, 30, "FaxNumber"));
			this.sqlUpdate.Parameters["@FaxNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AddressSourceCode", SqlDbType.NVarChar, 6, "AddressSourceCode"));
			this.sqlUpdate.Parameters["@AddressSourceCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@JDCode", SqlDbType.NVarChar, 50, "JDCode"));
			this.sqlUpdate.Parameters["@JDCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@AddressType", SqlDbType.NVarChar, 2, "AddressType"));
			this.sqlUpdate.Parameters["@AddressType"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@EffectiveTo", SqlDbType.SmallDateTime, 24, "EffectiveTo"));
			this.sqlUpdate.Parameters["@EffectiveTo"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
			this.sqlUpdate.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlUpdate.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
			this.sqlUpdate.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlUpdate.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Address1Fre", SqlDbType.NVarChar, 50, "Address1Fre"));
            this.sqlUpdate.Parameters["@Address1Fre"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Address2Fre", SqlDbType.NVarChar, 50, "Address2Fre"));
            this.sqlUpdate.Parameters["@Address2Fre"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Address3Fre", SqlDbType.NVarChar, 50, "Address3Fre"));
            this.sqlUpdate.Parameters["@Address3Fre"].SourceVersion = DataRowVersion.Current;
            // 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[AddressDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AddressId", System.Data.SqlDbType.Int, 4, "AddressId"));
		    this.sqlDelete.Parameters["@AddressId"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public atriumDB.AddressDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.AddressDataTable dt=new atriumDB.AddressDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public atriumDB.AddressDataTable Load(int AddressId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[AddressSelectByAddressId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AddressId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@AddressId"].Value=AddressId;

            atriumDB.AddressDataTable dt=new atriumDB.AddressDataTable();
			Fill(dt);
            return dt;
		}


		public atriumDB.AddressDataTable LoadByContactId(int ContactId)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[AddressSelectByContactId]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@ContactId"].Value=ContactId;

            atriumDB.AddressDataTable dt=new atriumDB.AddressDataTable();
			Fill(dt);
            return dt;
		}



		public atriumDB.AddressDataTable LoadByJDCode(string JDCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[AddressSelectByJDCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@JDCode", System.Data.SqlDbType.NVarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@JDCode"].Value=JDCode;

            atriumDB.AddressDataTable dt=new atriumDB.AddressDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
