using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// Class generated by sgen 
    /// based on EFile table 
    /// in atrium database
    /// on 6/12/2007
    /// </summary>
    public partial class EFileDAL : atDAL.ObjectDAL
    {

        internal EFileDAL(atriumDALManager pDALManager)
            : base(pDALManager)
        {
            Init();
        }

        private void Init()
        {


            this.sqlDa.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
		  new System.Data.Common.DataTableMapping("Table", "EFile", new System.Data.Common.DataColumnMapping[] {
		  
		  new System.Data.Common.DataColumnMapping("FileId", "FileId"),
		  new System.Data.Common.DataColumnMapping("StatusCode", "StatusCode"),
          new System.Data.Common.DataColumnMapping("secOwnerId", "secOwnerId"),
          new System.Data.Common.DataColumnMapping("OfficerId", "OfficerId"),
		  new System.Data.Common.DataColumnMapping("ArchiveId", "ArchiveId"),
		  new System.Data.Common.DataColumnMapping("TemporarilyRecalled", "TemporarilyRecalled"),
		  new System.Data.Common.DataColumnMapping("BoxNumber", "BoxNumber"),
		  new System.Data.Common.DataColumnMapping("FileStructXml", "FileStructXml"),
		  new System.Data.Common.DataColumnMapping("FileNumber", "FileNumber"),
		  new System.Data.Common.DataColumnMapping("OwnerOfficeId", "OwnerOfficeId"),
		  new System.Data.Common.DataColumnMapping("LeadOfficeId", "LeadOfficeId"),
		  new System.Data.Common.DataColumnMapping("LeadParalegalID", "LeadParalegalID"),
		  new System.Data.Common.DataColumnMapping("LeadLawyerID", "LeadLawyerID"),
		  new System.Data.Common.DataColumnMapping("OpponentID", "OpponentID"),
		  new System.Data.Common.DataColumnMapping("OpenedDate", "OpenedDate"),
		  new System.Data.Common.DataColumnMapping("ClosedDate", "ClosedDate"),
		  new System.Data.Common.DataColumnMapping("CloseCode", "CloseCode"),
		  new System.Data.Common.DataColumnMapping("FileType", "FileType"),
		  new System.Data.Common.DataColumnMapping("DescriptionE", "DescriptionE"),
		  new System.Data.Common.DataColumnMapping("DescriptionF", "DescriptionF"),
		  new System.Data.Common.DataColumnMapping("FullPath", "FullPath"),
		  new System.Data.Common.DataColumnMapping("FullFileNumber", "FullFileNumber"),
		  new System.Data.Common.DataColumnMapping("RiskManage", "RiskManage"),
		  new System.Data.Common.DataColumnMapping("RiskManageChildren", "RiskManageChildren"),
		  new System.Data.Common.DataColumnMapping("NameE", "NameE"),
		  new System.Data.Common.DataColumnMapping("NameF", "NameF"),
		  new System.Data.Common.DataColumnMapping("entryUser", "entryUser"),
		  new System.Data.Common.DataColumnMapping("entryDate", "entryDate"),
		  new System.Data.Common.DataColumnMapping("updateUser", "updateUser"),
		  new System.Data.Common.DataColumnMapping("updateDate", "updateDate"),
		  new System.Data.Common.DataColumnMapping("ts", "ts"),
		  new System.Data.Common.DataColumnMapping("MetaType", "MetaType"),
		  new System.Data.Common.DataColumnMapping("SubFileNumMax", "SubFileNumMax"),
		  new System.Data.Common.DataColumnMapping("SubFileNumMin", "SubFileNumMin"),
		  new System.Data.Common.DataColumnMapping("ImportantMsg", "ImportantMsg"),
          new System.Data.Common.DataColumnMapping("SortKey", "SortKey"),
          new System.Data.Common.DataColumnMapping("Security", "Security"),
          new System.Data.Common.DataColumnMapping("LocationId", "LocationId"),
          new System.Data.Common.DataColumnMapping("DispositionId", "DispositionId"),
          new System.Data.Common.DataColumnMapping("LanguageCode", "LanguageCode"),
          new System.Data.Common.DataColumnMapping("HasPaperFile", "HasPaperFile"),
          new System.Data.Common.DataColumnMapping("Essential", "Essential"),
          new System.Data.Common.DataColumnMapping("SourceFileId", "SourceFileId"),	
          new System.Data.Common.DataColumnMapping("RebuildTOC", "RebuildTOC"),	
          new System.Data.Common.DataColumnMapping("Dim1Id", "Dim1Id"),	
          new System.Data.Common.DataColumnMapping("Dim2Id", "Dim2Id"),
          new System.Data.Common.DataColumnMapping("BoxAlpha", "BoxAlpha"),	
                    new System.Data.Common.DataColumnMapping("Misc1Date", "Misc1Date"),	
          new System.Data.Common.DataColumnMapping("Misc2Date", "Misc2Date"),
})});

            // 
            // sqlSelect
            // 
            this.sqlSelect.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelect.Connection = myDALManager.SqlCon;

            this.sqlSelectAll.CommandText = "[EFileSelect]";
            this.sqlSelectAll.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlSelectAll.Connection = myDALManager.SqlCon;
            this.sqlSelectAll.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            // 
            // sqlInsert
            // 
            this.sqlInsert.CommandText = "[EFileInsert]";
            this.sqlInsert.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlInsert.Connection = myDALManager.SqlCon;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlInsert.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
            this.sqlInsert.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.Char, 1, "StatusCode"));
            this.sqlInsert.Parameters["@StatusCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@secOwnerId", SqlDbType.Int, 10, "secOwnerId"));
            this.sqlInsert.Parameters["@secOwnerId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OfficerId", SqlDbType.Int, 10, "OfficerId"));
            this.sqlInsert.Parameters["@OfficerId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ArchiveId", SqlDbType.Int, 10, "ArchiveId"));
            this.sqlInsert.Parameters["@ArchiveId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@TemporarilyRecalled", SqlDbType.Bit, 1, "TemporarilyRecalled"));
            this.sqlInsert.Parameters["@TemporarilyRecalled"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@BoxNumber", SqlDbType.Int, 10, "BoxNumber"));
            this.sqlInsert.Parameters["@BoxNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FileStructXml", SqlDbType.NVarChar, 0, "FileStructXml"));
            this.sqlInsert.Parameters["@FileStructXml"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FileNumber", SqlDbType.NVarChar, 16, "FileNumber"));
            this.sqlInsert.Parameters["@FileNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OwnerOfficeId", SqlDbType.Int, 10, "OwnerOfficeId"));
            this.sqlInsert.Parameters["@OwnerOfficeId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LeadOfficeId", SqlDbType.Int, 10, "LeadOfficeId"));
            this.sqlInsert.Parameters["@LeadOfficeId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LeadParalegalID", SqlDbType.Int, 10, "LeadParalegalID"));
            this.sqlInsert.Parameters["@LeadParalegalID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
            this.sqlInsert.Parameters["@LeadLawyerID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OpponentID", SqlDbType.Int, 10, "OpponentID"));
            this.sqlInsert.Parameters["@OpponentID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@OpenedDate", SqlDbType.SmallDateTime, 24, "OpenedDate"));
            this.sqlInsert.Parameters["@OpenedDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ClosedDate", SqlDbType.SmallDateTime, 24, "ClosedDate"));
            this.sqlInsert.Parameters["@ClosedDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@CloseCode", SqlDbType.NVarChar, 4, "CloseCode"));
            this.sqlInsert.Parameters["@CloseCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FileType", SqlDbType.NVarChar, 6, "FileType"));
            this.sqlInsert.Parameters["@FileType"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DescriptionE", SqlDbType.NVarChar, 512, "DescriptionE"));
            this.sqlInsert.Parameters["@DescriptionE"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DescriptionF", SqlDbType.NVarChar, 512, "DescriptionF"));
            this.sqlInsert.Parameters["@DescriptionF"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FullPath", SqlDbType.NVarChar, 0, "FullPath"));
            this.sqlInsert.Parameters["@FullPath"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@FullFileNumber", SqlDbType.NVarChar, 255, "FullFileNumber"));
            this.sqlInsert.Parameters["@FullFileNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RiskManage", SqlDbType.Bit, 1, "RiskManage"));
            this.sqlInsert.Parameters["@RiskManage"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@RiskManageChildren", SqlDbType.Bit, 1, "RiskManageChildren"));
            this.sqlInsert.Parameters["@RiskManageChildren"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@NameE", SqlDbType.NVarChar, 255, "NameE"));
            this.sqlInsert.Parameters["@NameE"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@NameF", SqlDbType.NVarChar, 255, "NameF"));
            this.sqlInsert.Parameters["@NameF"].SourceVersion = DataRowVersion.Current;
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
            this.sqlInsert.Parameters.Add(new SqlParameter("@MetaType", SqlDbType.NVarChar, 6, "MetaType"));
            this.sqlInsert.Parameters["@MetaType"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SubFileNumMax", SqlDbType.Int, 10, "SubFileNumMax"));
            this.sqlInsert.Parameters["@SubFileNumMax"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SubFileNumMin", SqlDbType.Int, 10, "SubFileNumMin"));
            this.sqlInsert.Parameters["@SubFileNumMin"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@ImportantMsg", SqlDbType.NVarChar, 0, "ImportantMsg"));
            this.sqlInsert.Parameters["@ImportantMsg"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SortKey", SqlDbType.NVarChar, 255, "SortKey"));
            this.sqlInsert.Parameters["@SortKey"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Security", SqlDbType.NVarChar, 8, "Security"));
            this.sqlInsert.Parameters["@Security"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LocationId", SqlDbType.Int, 10, "LocationId"));
            this.sqlInsert.Parameters["@LocationId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@DispositionId", SqlDbType.Int, 10, "DispositionId"));
            this.sqlInsert.Parameters["@DispositionId"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 3, "LanguageCode"));
            this.sqlInsert.Parameters["@LanguageCode"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@HasPaperFile", SqlDbType.Bit, 1, "HasPaperFile"));
            this.sqlInsert.Parameters["@HasPaperFile"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Essential", SqlDbType.Bit, 1, "Essential"));
            this.sqlInsert.Parameters["@Essential"].SourceVersion = DataRowVersion.Current;

            this.sqlInsert.Parameters.Add(new SqlParameter("@PeriodID", SqlDbType.Int, 10, "PeriodID"));
            this.sqlInsert.Parameters["@PeriodID"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@PeriodStartDate", SqlDbType.SmallDateTime, 24, "PeriodStartDate"));
            this.sqlInsert.Parameters["@PeriodStartDate"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@SourceFileId", SqlDbType.Int, 10, "SourceFileId"));
            this.sqlInsert.Parameters["@SourceFileId"].SourceVersion = DataRowVersion.Current;

            this.sqlInsert.Parameters.Add(new SqlParameter("@RebuildTOC", SqlDbType.Bit, 1, "RebuildTOC"));
            this.sqlInsert.Parameters["@RebuildTOC"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Dim1Id", SqlDbType.Int, 10, "Dim1Id"));
            this.sqlInsert.Parameters["@Dim1Id"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Dim2Id", SqlDbType.Int, 10, "Dim2Id"));
            this.sqlInsert.Parameters["@Dim2Id"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Misc1Date", SqlDbType.SmallDateTime, 24, "Misc1Date"));
            this.sqlInsert.Parameters["@Misc1Date"].SourceVersion = DataRowVersion.Current;
            this.sqlInsert.Parameters.Add(new SqlParameter("@Misc2Date", SqlDbType.SmallDateTime, 24, "Misc2Date"));
            this.sqlInsert.Parameters["@Misc2Date"].SourceVersion = DataRowVersion.Current;

            this.sqlInsert.Parameters.Add(new SqlParameter("@BoxAlpha", SqlDbType.NVarChar, 50, "BoxAlpha"));
            this.sqlInsert.Parameters["@BoxAlpha"].SourceVersion = DataRowVersion.Current;

            // 
            // sqlUpdate
            // 
            this.sqlUpdate.CommandText = "[EFileUpdateNew]";
            this.sqlUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlUpdate.Connection = myDALManager.SqlCon;
            sqlUpdate.CommandTimeout = 300;
            
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileId", SqlDbType.Int, 10, "FileId"));
            this.sqlUpdate.Parameters["@FileId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@StatusCode", SqlDbType.Char, 1, "StatusCode"));
            this.sqlUpdate.Parameters["@StatusCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@secOwnerId", SqlDbType.Int, 10, "secOwnerId"));
            this.sqlUpdate.Parameters["@secOwnerId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OfficerId", SqlDbType.Int, 10, "OfficerId"));
            this.sqlUpdate.Parameters["@OfficerId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ArchiveId", SqlDbType.Int, 10, "ArchiveId"));
            this.sqlUpdate.Parameters["@ArchiveId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@TemporarilyRecalled", SqlDbType.Bit, 1, "TemporarilyRecalled"));
            this.sqlUpdate.Parameters["@TemporarilyRecalled"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BoxNumber", SqlDbType.Int, 10, "BoxNumber"));
            this.sqlUpdate.Parameters["@BoxNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileStructXml", SqlDbType.NVarChar, 0, "FileStructXml"));
            this.sqlUpdate.Parameters["@FileStructXml"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileNumber", SqlDbType.NVarChar, 16, "FileNumber"));
            this.sqlUpdate.Parameters["@FileNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OwnerOfficeId", SqlDbType.Int, 10, "OwnerOfficeId"));
            this.sqlUpdate.Parameters["@OwnerOfficeId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LeadOfficeId", SqlDbType.Int, 10, "LeadOfficeId"));
            this.sqlUpdate.Parameters["@LeadOfficeId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LeadParalegalID", SqlDbType.Int, 10, "LeadParalegalID"));
            this.sqlUpdate.Parameters["@LeadParalegalID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
            this.sqlUpdate.Parameters["@LeadLawyerID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OpponentID", SqlDbType.Int, 10, "OpponentID"));
            this.sqlUpdate.Parameters["@OpponentID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@OpenedDate", SqlDbType.SmallDateTime, 24, "OpenedDate"));
            this.sqlUpdate.Parameters["@OpenedDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ClosedDate", SqlDbType.SmallDateTime, 24, "ClosedDate"));
            this.sqlUpdate.Parameters["@ClosedDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@CloseCode", SqlDbType.NVarChar, 4, "CloseCode"));
            this.sqlUpdate.Parameters["@CloseCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FileType", SqlDbType.NVarChar, 6, "FileType"));
            this.sqlUpdate.Parameters["@FileType"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DescriptionE", SqlDbType.NVarChar, 512, "DescriptionE"));
            this.sqlUpdate.Parameters["@DescriptionE"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DescriptionF", SqlDbType.NVarChar, 512, "DescriptionF"));
            this.sqlUpdate.Parameters["@DescriptionF"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FullPath", SqlDbType.NVarChar, 0, "FullPath"));
            this.sqlUpdate.Parameters["@FullPath"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@FullFileNumber", SqlDbType.NVarChar, 255, "FullFileNumber"));
            this.sqlUpdate.Parameters["@FullFileNumber"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@RiskManage", SqlDbType.Bit, 1, "RiskManage"));
            this.sqlUpdate.Parameters["@RiskManage"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@RiskManageChildren", SqlDbType.Bit, 1, "RiskManageChildren"));
            this.sqlUpdate.Parameters["@RiskManageChildren"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@NameE", SqlDbType.NVarChar, 255, "NameE"));
            this.sqlUpdate.Parameters["@NameE"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@NameF", SqlDbType.NVarChar, 255, "NameF"));
            this.sqlUpdate.Parameters["@NameF"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@entryUser", SqlDbType.NVarChar, 20, "entryUser"));
            this.sqlUpdate.Parameters["@entryUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@entryDate", SqlDbType.SmallDateTime, 24, "entryDate"));
            this.sqlUpdate.Parameters["@entryDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@updateUser", SqlDbType.NVarChar, 20, "updateUser"));
            this.sqlUpdate.Parameters["@updateUser"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@updateDate", SqlDbType.SmallDateTime, 24, "updateDate"));
            this.sqlUpdate.Parameters["@updateDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@MetaType", SqlDbType.NVarChar, 6, "MetaType"));
            this.sqlUpdate.Parameters["@MetaType"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SubFileNumMax", SqlDbType.Int, 10, "SubFileNumMax"));
            this.sqlUpdate.Parameters["@SubFileNumMax"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SubFileNumMin", SqlDbType.Int, 10, "SubFileNumMin"));
            this.sqlUpdate.Parameters["@SubFileNumMin"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
            this.sqlUpdate.Parameters["@ts"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@ImportantMsg", SqlDbType.NVarChar, 0, "ImportantMsg"));
            this.sqlUpdate.Parameters["@ImportantMsg"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SortKey", SqlDbType.NVarChar, 255, "SortKey"));
            this.sqlUpdate.Parameters["@SortKey"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Security", SqlDbType.NVarChar, 8, "Security"));
            this.sqlUpdate.Parameters["@Security"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LocationId", SqlDbType.Int, 10, "LocationId"));
            this.sqlUpdate.Parameters["@LocationId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@DispositionId", SqlDbType.Int, 10, "DispositionId"));
            this.sqlUpdate.Parameters["@DispositionId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@LanguageCode", SqlDbType.NVarChar, 3, "LanguageCode"));
            this.sqlUpdate.Parameters["@LanguageCode"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@HasPaperFile", SqlDbType.Bit, 1, "HasPaperFile"));
            this.sqlUpdate.Parameters["@HasPaperFile"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Essential", SqlDbType.Bit, 1, "Essential"));
            this.sqlUpdate.Parameters["@Essential"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@PeriodID", SqlDbType.Int, 10, "PeriodID"));
            this.sqlUpdate.Parameters["@PeriodID"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@PeriodStartDate", SqlDbType.SmallDateTime, 24, "PeriodStartDate"));
            this.sqlUpdate.Parameters["@PeriodStartDate"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@SourceFileId", SqlDbType.Int, 10, "SourceFileId"));
            this.sqlUpdate.Parameters["@SourceFileId"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@RebuildTOC", SqlDbType.Bit, 1, "RebuildTOC"));
            this.sqlUpdate.Parameters["@RebuildTOC"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Dim1Id", SqlDbType.Int, 10, "Dim1Id"));
            this.sqlUpdate.Parameters["@Dim1Id"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Dim2Id", SqlDbType.Int, 10, "Dim2Id"));
            this.sqlUpdate.Parameters["@Dim2Id"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@BoxAlpha", SqlDbType.NVarChar, 50, "BoxAlpha"));
            this.sqlUpdate.Parameters["@BoxAlpha"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Misc1Date", SqlDbType.SmallDateTime, 24, "Misc1Date"));
            this.sqlUpdate.Parameters["@Misc1Date"].SourceVersion = DataRowVersion.Current;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@Misc2Date", SqlDbType.SmallDateTime, 24, "Misc2Date"));
            this.sqlUpdate.Parameters["@Misc2Date"].SourceVersion = DataRowVersion.Current;


            this.sqlUpdate.Parameters.Add(new SqlParameter("@origStatusCode", SqlDbType.Char, 1, "StatusCode"));
            this.sqlUpdate.Parameters["@origStatusCode"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origsecOwnerId", SqlDbType.Int, 10, "secOwnerId"));
            this.sqlUpdate.Parameters["@origsecOwnerId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origOfficerId", SqlDbType.Int, 10, "OfficerId"));
            this.sqlUpdate.Parameters["@origOfficerId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origArchiveId", SqlDbType.Int, 10, "ArchiveId"));
            this.sqlUpdate.Parameters["@origArchiveId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origTemporarilyRecalled", SqlDbType.Bit, 1, "TemporarilyRecalled"));
            this.sqlUpdate.Parameters["@origTemporarilyRecalled"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origBoxNumber", SqlDbType.Int, 10, "BoxNumber"));
            this.sqlUpdate.Parameters["@origBoxNumber"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origFileStructXml", SqlDbType.NVarChar, 0, "FileStructXml"));
            this.sqlUpdate.Parameters["@origFileStructXml"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origFileNumber", SqlDbType.NVarChar, 16, "FileNumber"));
            this.sqlUpdate.Parameters["@origFileNumber"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origOwnerOfficeId", SqlDbType.Int, 10, "OwnerOfficeId"));
            this.sqlUpdate.Parameters["@origOwnerOfficeId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origLeadOfficeId", SqlDbType.Int, 10, "LeadOfficeId"));
            this.sqlUpdate.Parameters["@origLeadOfficeId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origLeadParalegalID", SqlDbType.Int, 10, "LeadParalegalID"));
            this.sqlUpdate.Parameters["@origLeadParalegalID"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origLeadLawyerID", SqlDbType.Int, 10, "LeadLawyerID"));
            this.sqlUpdate.Parameters["@origLeadLawyerID"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origOpponentID", SqlDbType.Int, 10, "OpponentID"));
            this.sqlUpdate.Parameters["@origOpponentID"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origOpenedDate", SqlDbType.SmallDateTime, 24, "OpenedDate"));
            this.sqlUpdate.Parameters["@origOpenedDate"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origClosedDate", SqlDbType.SmallDateTime, 24, "ClosedDate"));
            this.sqlUpdate.Parameters["@origClosedDate"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origCloseCode", SqlDbType.NVarChar, 4, "CloseCode"));
            this.sqlUpdate.Parameters["@origCloseCode"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origFileType", SqlDbType.NVarChar, 6, "FileType"));
            this.sqlUpdate.Parameters["@origFileType"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origDescriptionE", SqlDbType.NVarChar, 512, "DescriptionE"));
            this.sqlUpdate.Parameters["@origDescriptionE"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origDescriptionF", SqlDbType.NVarChar, 512, "DescriptionF"));
            this.sqlUpdate.Parameters["@origDescriptionF"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origFullPath", SqlDbType.NVarChar, 0, "FullPath"));
            this.sqlUpdate.Parameters["@origFullPath"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origFullFileNumber", SqlDbType.NVarChar, 255, "FullFileNumber"));
            this.sqlUpdate.Parameters["@origFullFileNumber"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origRiskManage", SqlDbType.Bit, 1, "RiskManage"));
            this.sqlUpdate.Parameters["@origRiskManage"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origRiskManageChildren", SqlDbType.Bit, 1, "RiskManageChildren"));
            this.sqlUpdate.Parameters["@origRiskManageChildren"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origNameE", SqlDbType.NVarChar, 255, "NameE"));
            this.sqlUpdate.Parameters["@origNameE"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origNameF", SqlDbType.NVarChar, 255, "NameF"));
            this.sqlUpdate.Parameters["@origNameF"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origMetaType", SqlDbType.NVarChar, 6, "MetaType"));
            this.sqlUpdate.Parameters["@origMetaType"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origSubFileNumMax", SqlDbType.Int, 10, "SubFileNumMax"));
            this.sqlUpdate.Parameters["@origSubFileNumMax"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origSubFileNumMin", SqlDbType.Int, 10, "SubFileNumMin"));
            this.sqlUpdate.Parameters["@origSubFileNumMin"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origImportantMsg", SqlDbType.NVarChar, 0, "ImportantMsg"));
            this.sqlUpdate.Parameters["@origImportantMsg"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origSortKey", SqlDbType.NVarChar, 255, "SortKey"));
            this.sqlUpdate.Parameters["@origSortKey"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origSecurity", SqlDbType.NVarChar, 8, "Security"));
            this.sqlUpdate.Parameters["@origSecurity"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origLocationId", SqlDbType.Int, 10, "LocationId"));
            this.sqlUpdate.Parameters["@origLocationId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origDispositionId", SqlDbType.Int, 10, "DispositionId"));
            this.sqlUpdate.Parameters["@origDispositionId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origLanguageCode", SqlDbType.NVarChar, 3, "LanguageCode"));
            this.sqlUpdate.Parameters["@origLanguageCode"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origHasPaperFile", SqlDbType.Bit, 1, "HasPaperFile"));
            this.sqlUpdate.Parameters["@origHasPaperFile"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origEssential", SqlDbType.Bit, 1, "Essential"));
            this.sqlUpdate.Parameters["@origEssential"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origPeriodID", SqlDbType.Int, 10, "PeriodID"));
            this.sqlUpdate.Parameters["@origPeriodID"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origPeriodStartDate", SqlDbType.SmallDateTime, 24, "PeriodStartDate"));
            this.sqlUpdate.Parameters["@origPeriodStartDate"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origSourceFileId", SqlDbType.Int, 10, "SourceFileId"));
            this.sqlUpdate.Parameters["@origSourceFileId"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origRebuildTOC", SqlDbType.Bit, 1, "RebuildTOC"));
            this.sqlUpdate.Parameters["@origRebuildTOC"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origDim1Id", SqlDbType.Int, 10, "Dim1Id"));
            this.sqlUpdate.Parameters["@origDim1Id"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origDim2Id", SqlDbType.Int, 10, "Dim2Id"));
            this.sqlUpdate.Parameters["@origDim2Id"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origBoxAlpha", SqlDbType.NVarChar, 50, "BoxAlpha"));
            this.sqlUpdate.Parameters["@origBoxAlpha"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origMisc1Date", SqlDbType.SmallDateTime, 24, "Misc1Date"));
            this.sqlUpdate.Parameters["@origMisc1Date"].SourceVersion = DataRowVersion.Original;
            this.sqlUpdate.Parameters.Add(new SqlParameter("@origMisc2Date", SqlDbType.SmallDateTime, 24, "Misc2Date"));
            this.sqlUpdate.Parameters["@origMisc2Date"].SourceVersion = DataRowVersion.Original;

            // 
            // sqlDelete
            // 
            this.sqlDelete.CommandText = "[EFileDelete]";
            this.sqlDelete.CommandType = System.Data.CommandType.StoredProcedure;
            this.sqlDelete.Connection = myDALManager.SqlCon;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, "FileId"));
            this.sqlDelete.Parameters["@FileId"].SourceVersion = DataRowVersion.Original;
            this.sqlDelete.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ts", System.Data.SqlDbType.Timestamp, 50, "ts"));
            this.sqlDelete.Parameters["@ts"].SourceVersion = DataRowVersion.Original;



        }

        public atriumDB.EFileDataTable Load()
        {
            this.sqlDa.SelectCommand = sqlSelectAll;

            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }



        public atriumDB.EFileDataTable Load(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[EFileSelectByFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }



    }


}
