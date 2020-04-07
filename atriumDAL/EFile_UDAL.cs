using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>
    
    public partial class EFileDAL : atDAL.ObjectDAL
    {
        public atriumDB.EFileDataTable LoadByFullFileNumber(string fileNumber)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[EFileSelectByFileNumber]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fullFileNumber", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@fullFileNumber"].Value = fileNumber;

            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.EFileDataTable LoadBySIN(string SIN)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[EFileSelectBySIN]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@SIN", System.Data.SqlDbType.NVarChar, 9, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@SIN"].Value = SIN;

            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.EFileDataTable LoadFileRoots()
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[EFileSelectFileRoots]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }

        //public atriumDB.EFileDataTable LoadByThread(string ConvIndexBase)
        //{
        //    this.sqlDa.SelectCommand = sqlSelect;
        //    this.sqlSelect.Parameters.Clear();
        //    this.sqlSelect.CommandText = "[FileFindByThread]";
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
        //    this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ConvIndexBase", System.Data.SqlDbType.NVarChar, 44, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

        //    if (ConvIndexBase.Length > 44)
        //        ConvIndexBase = ConvIndexBase.Substring(0, 44);
        //    this.sqlSelect.Parameters["@ConvIndexBase"].Value = ConvIndexBase;

        //    atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
        //    Fill(dt);
        //    return dt;
        //}

        public atriumDB.EFileDataTable LoadByPath(string path)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[EFileSelectByPath]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@path", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));

            this.sqlSelect.Parameters["@path"].Value = path;

            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.EFileDataTable LoadByParentFileId(int FileId, int OfficeId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[EFileSelectByParentFileId]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ParentFileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@ParentFileId"].Value = FileId;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficeId"].Value = OfficeId;
            atriumDB.EFileDataTable dt = new atriumDB.EFileDataTable();
            Fill(dt);
            return dt;
        }

        public appDB.EFileSearchDataTable SearchByContact(int contactId, string contactType)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[FileSearchByContact]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ContactId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@ContactId"].Value = contactId;
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contactType", System.Data.SqlDbType.NVarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@contactType"].Value = contactType;
            appDB.EFileSearchDataTable dt = new appDB.EFileSearchDataTable();
            Fill(dt);
            return dt;
        }

        public byte[] CLASLoadByFileId(int fileId)
        {
            atriumDALManager aDAL=(atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
            ds.RemotingFormat = SerializationFormat.Binary;

            ds.Merge(aDAL.GetFileHistory().LoadByFileId(fileId));
            ds.Merge(aDAL.GetDebt().LoadByFileId(fileId));
            ds.Merge(aDAL.GetAccountHistory().LoadByFileId(fileId));
            ds.Merge(aDAL.GetTaxing().LoadByFileID(fileId));
            ds.Merge(aDAL.GetJudgment().LoadByFileID(fileId));
            ds.Merge(aDAL.GetJudgmentAccount().LoadByFileID(fileId));
            ds.Merge(aDAL.GetWrit().LoadByFileID(fileId));
            ds.Merge(aDAL.GetWritHistory().LoadByFileID(fileId));
            ds.Merge(aDAL.GetProperty().LoadByFileID(fileId));
            ds.Merge(aDAL.GetCashBlotter().LoadByFileId(fileId));
            ds.Merge(aDAL.GetCBDetail().LoadByFileID(fileId));
            ds.Merge(aDAL.GetBankruptcy().LoadByFileID(fileId));
            ds.Merge(aDAL.GetBankruptcyAccount().LoadByFileId(fileId));
            ds.Merge(aDAL.GetInsolvency().LoadByFileID(fileId));
            ds.Merge(aDAL.GetInsolvencyAccount().LoadByFileId(fileId));
            ds.Merge(aDAL.GetHardship().LoadByFileId(fileId));
            ds.Merge(aDAL.GetCost().LoadByFileID(fileId));
            ds.Merge(aDAL.GetCompOffer().LoadByFileID(fileId));
            ds.Merge(aDAL.GetCompOfferDetail().LoadByFileId(fileId));
            ds.Merge(aDAL.GetTaxing().LoadByFileID(fileId));
            ds.Merge(aDAL.GetOfficeAccount().LoadByFileID(fileId));


            ds.Merge(aDAL.GetDebtor().LoadByFileId(fileId));

            FixTZDSIssue(ds);
            return atriumDALManager.CompressData( ds);
        }

        public byte[] MainLoadByFileId(int fileId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
            //ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = SerializationFormat.Binary;

            ds.Merge(this.Load(fileId));
            // could conditionally load based on file type,etc...
            
            ds.Merge(aDAL.GetFileContact().LoadByFileId(fileId));
            ds.Merge(aDAL.GetContact().LoadByFileId(fileId));
            ds.Merge(aDAL.GetFileOffice().LoadByFileId(fileId));
            ds.Merge(aDAL.GetFileXRef().LoadByFileId(fileId));
            ds.Merge(aDAL.GetFileXRef().LoadByOtherFileId(fileId));
            ds.Merge(aDAL.GetFileAKA().LoadByFileId(fileId));
            ds.Merge(aDAL.GetAppointment().LoadByFileId(fileId));
            ds.Merge(aDAL.GetApptRecurrence().LoadByFileId(fileId));
            ds.Merge(aDAL.GetAttendee().LoadByFileId(fileId));
            ds.Merge(aDAL.GetAddress().LoadByFileIdP(fileId));

            ds.Merge(aDAL.GetsecFileRule().LoadByFileId(fileId));
            ds.Merge(aDAL.GetFileFlag().LoadByFileId(fileId)); // WI 75956
            //ds.Merge(aDAL.GetFileMetaType().Load());
            
            ds.Merge(aDAL.GetRiskAssessment().LoadByFileId(fileId));
            ds.Merge(aDAL.GetIRP().LoadByFileID(fileId));

            ds.Merge(aDAL.GetAKA().LoadByFileId(fileId));

            ds.Merge(aDAL.GetArchiveBatch().Load(fileId));

            ds.Merge(aDAL.GetddEntity().LoadByFileId(fileId));

            FixTZDSIssue(ds);

            return atriumDALManager.CompressData(ds);
        }
    }
}