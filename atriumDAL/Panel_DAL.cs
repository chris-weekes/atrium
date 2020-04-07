using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
	/// <summary>
	/// Class generated by sgen 
	/// based on Panel table 
	/// in lawmate database
	/// on 2006/06/16
	/// </summary>
	public partial class PanelDAL:atDAL.ObjectDAL
	{

    	internal PanelDAL(atriumDALManager pDALManager) :base(pDALManager)
		  {
			  Init();
		  }

        private void Init()
		{


			this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "Panel", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("PanelID", "PanelID"),
		  new System.Data.Common.DataColumnMapping("HearingSetID", "HearingSetID"),
		  new System.Data.Common.DataColumnMapping("ParentPanelID", "ParentPanelID"),
		  new System.Data.Common.DataColumnMapping("PanelNumber", "PanelNumber"),
		  new System.Data.Common.DataColumnMapping("DaysOfWeek", "DaysOfWeek"),
		  new System.Data.Common.DataColumnMapping("OfficeID", "OfficeID"),
		  new System.Data.Common.DataColumnMapping("RoomDesc", "RoomDesc"),
		  new System.Data.Common.DataColumnMapping("HearingsPerDay", "HearingsPerDay"),
		  new System.Data.Common.DataColumnMapping("LanguageCode", "LanguageCode"),
		  new System.Data.Common.DataColumnMapping("LeadLawyerID", "LeadLawyerID"),
		  new System.Data.Common.DataColumnMapping("PrepRoomRequired", "PrepRoomRequired"),
		  new System.Data.Common.DataColumnMapping("Notes", "Notes"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
			})});
			
			// 
			// sqlSelect
			// 
			this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelect.Connection=myDALManager.SqlCon;

			this.sqlSelectAll.CommandText = "[PanelSelect]";
			this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectAll.Connection=myDALManager.SqlCon;
			this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4,	System.Data.ParameterDirection.ReturnValue,	false, ((System.Byte)(10)),	((System.Byte)(0)),	"",	System.Data.DataRowVersion.Current,	null));

			// 
			// sqlInsert
			// 
			this.sqlInsert.CommandText = "[PanelInsert]";
			this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlInsert.Connection=myDALManager.SqlCon;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlInsert.Parameters.Add(new SqlParameter("@PanelID", SqlDbType.Int, 10, "PanelID"));
			this.sqlInsert.Parameters["@PanelID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HearingSetID", SqlDbType.Int, 10, "HearingSetID"));
			this.sqlInsert.Parameters["@HearingSetID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ParentPanelID", SqlDbType.Int, 10, "ParentPanelID"));
			this.sqlInsert.Parameters["@ParentPanelID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PanelNumber", SqlDbType.TinyInt, 50, "PanelNumber"));
			this.sqlInsert.Parameters["@PanelNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@DaysOfWeek", SqlDbType.VarChar, 50, "DaysOfWeek"));
			this.sqlInsert.Parameters["@DaysOfWeek"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 10, "OfficeID"));
			this.sqlInsert.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@RoomDesc", SqlDbType.VarChar, 50, "RoomDesc"));
			this.sqlInsert.Parameters["@RoomDesc"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@HearingsPerDay", SqlDbType.TinyInt, 50, "HearingsPerDay"));
			this.sqlInsert.Parameters["@HearingsPerDay"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LanguageCode", SqlDbType.VarChar, 1, "LanguageCode"));
			this.sqlInsert.Parameters["@LanguageCode"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@LeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
			this.sqlInsert.Parameters["@LeadLawyerID"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@PrepRoomRequired", SqlDbType.Bit, 1, "PrepRoomRequired"));
			this.sqlInsert.Parameters["@PrepRoomRequired"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 1024, "Notes"));
			this.sqlInsert.Parameters["@Notes"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.VarChar, 20, "entryUser"));
			this.sqlInsert.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlInsert.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.VarChar, 20, "updateUser"));
			this.sqlInsert.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlInsert.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlInsert.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlInsert.Parameters["@ts"].SourceVersion=DataRowVersion.Current;

			// 
			// sqlUpdate
			// 
			this.sqlUpdate.CommandText = "[PanelUpdate]";
			this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlUpdate.Connection=myDALManager.SqlCon;
			this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PanelID", SqlDbType.Int, 10, "PanelID"));
			this.sqlUpdate.Parameters["@PanelID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingSetID", SqlDbType.Int, 10, "HearingSetID"));
			this.sqlUpdate.Parameters["@HearingSetID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ParentPanelID", SqlDbType.Int, 10, "ParentPanelID"));
			this.sqlUpdate.Parameters["@ParentPanelID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PanelNumber", SqlDbType.TinyInt, 50, "PanelNumber"));
			this.sqlUpdate.Parameters["@PanelNumber"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@DaysOfWeek", SqlDbType.VarChar, 50, "DaysOfWeek"));
			this.sqlUpdate.Parameters["@DaysOfWeek"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficeID", SqlDbType.Int, 10, "OfficeID"));
			this.sqlUpdate.Parameters["@OfficeID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@RoomDesc", SqlDbType.VarChar, 50, "RoomDesc"));
			this.sqlUpdate.Parameters["@RoomDesc"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@HearingsPerDay", SqlDbType.TinyInt, 50, "HearingsPerDay"));
			this.sqlUpdate.Parameters["@HearingsPerDay"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LanguageCode", SqlDbType.VarChar, 1, "LanguageCode"));
			this.sqlUpdate.Parameters["@LanguageCode"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@LeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
			this.sqlUpdate.Parameters["@LeadLawyerID"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@PrepRoomRequired", SqlDbType.Bit, 1, "PrepRoomRequired"));
			this.sqlUpdate.Parameters["@PrepRoomRequired"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@Notes", SqlDbType.VarChar, 1024, "Notes"));
			this.sqlUpdate.Parameters["@Notes"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.VarChar, 20, "entryUser"));
			this.sqlUpdate.Parameters["@entryUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
			this.sqlUpdate.Parameters["@entryDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.VarChar, 20, "updateUser"));
			this.sqlUpdate.Parameters["@updateUser"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
			this.sqlUpdate.Parameters["@updateDate"].SourceVersion=DataRowVersion.Current;
			this.sqlUpdate.Parameters.Add(new SqlParameter("@ts", SqlDbType.Timestamp, 50, "ts"));
			this.sqlUpdate.Parameters["@ts"].SourceVersion=DataRowVersion.Current;
			// 
			// sqlDelete
			// 
			this.sqlDelete.CommandText = "[PanelDelete]";
			this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlDelete.Connection=myDALManager.SqlCon;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PanelID", System.Data.SqlDbType.Int, 10, "PanelID"));
		    this.sqlDelete.Parameters["@PanelID"].SourceVersion=DataRowVersion.Original;
			this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
		    this.sqlDelete.Parameters["@ts"].SourceVersion=DataRowVersion.Original;



		}

		public override atriumDB.PanelDataTable Load()
		{
			this.sqlDa.SelectCommand=sqlSelectAll;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
        }

	
		
		public atriumDB.PanelDataTable Load(int PanelID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[PanelSelectByPanelID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@PanelID", System.Data.SqlDbType.Int, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

			this.sqlSelect.Parameters["@PanelID"].Value=PanelID;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
		}


		public atriumDB.PanelDataTable LoadByLeadLawyerID(int LeadLawyerID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[PanelSelectByLeadLawyerID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LeadLawyerID", System.Data.SqlDbType.Int, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@LeadLawyerID"].Value=LeadLawyerID;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
		}



		public atriumDB.PanelDataTable LoadByHearingSetID(int HearingSetID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[PanelSelectByHearingSetID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@HearingSetID", System.Data.SqlDbType.Int, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@HearingSetID"].Value=HearingSetID;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
		}



		public atriumDB.PanelDataTable LoadByLanguageCode(string LanguageCode)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[PanelSelectByLanguageCode]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LanguageCode", System.Data.SqlDbType.VarChar, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@LanguageCode"].Value=LanguageCode;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
		}



		public atriumDB.PanelDataTable LoadByOfficeID(int OfficeID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[PanelSelectByOfficeID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeID", System.Data.SqlDbType.Int, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@OfficeID"].Value=OfficeID;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
		}



		public atriumDB.PanelDataTable LoadByParentPanelID(int ParentPanelID)
		{
			this.sqlDa.SelectCommand=sqlSelect;
			this.sqlSelect.Parameters.Clear();
			this.sqlSelect.CommandText = "[PanelSelectByParentPanelID]";
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ParentPanelID", System.Data.SqlDbType.Int, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlSelect.Parameters["@ParentPanelID"].Value=ParentPanelID;

            atriumDB.PanelDataTable dt=new atriumDB.PanelDataTable();
			Fill(dt);
            return dt;
		}




	}
	

}
