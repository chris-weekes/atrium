using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;


namespace atriumDAL
{
    /// <summary>
    /// </summary>
    
    public partial class SRPDAL : atDAL.ObjectDAL
    {
        public atriumDB.SRPDataTable LoadCurrentByOfficeID(int OfficeID)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[SRPSelectCurrentByOfficeID]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OfficeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@OfficeID"].Value = OfficeID;

            atriumDB.SRPDataTable dt = new atriumDB.SRPDataTable();
            Fill(dt);
            return dt;
        }

        public atriumDB.SRPDataTable LoadByFileID(int FileId)
        {
            this.sqlDa.SelectCommand = sqlSelect;
            this.sqlSelect.Parameters.Clear();
            this.sqlSelect.CommandText = "[SRPSelectByFileID]";
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FileId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
            this.sqlSelect.Parameters["@FileId"].Value = FileId;

            atriumDB.SRPDataTable dt = new atriumDB.SRPDataTable();
            Fill(dt);
            return dt;
        }
        public byte[] LoadByFileIDByte(int FileId)
        {
            return atriumDALManager.CompressData(LoadByFileID(FileId));
        }
        public atriumDB.SRPDataTable SubmitTimeslip(int srpId,int officerId,DateTime SRPDate,DateTime endPeriod)
        {
            myDALManager.ExecuteSP("SubmitTimeslip", srpId, officerId, SRPDate, endPeriod, DateTime.Today);

            return Load(srpId);
        }

        public atriumDB.SRPDataTable SubmitSRP(atriumDB.SRPDataTable dt,int srpId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            try
            {
               

                atriumDB.SRPDataTable dtOut = (atriumDB.SRPDataTable)Update(dt);

                atriumDB.SRPRow drSrp = dt.FindBySRPID(srpId);

                atriumDB.IRPDataTable irps = aDAL.GetIRP().LoadBySRPID(srpId);


                foreach (atriumDB.IRPRow drIrp in irps)
                {
                    aDAL.ExecuteSP("SubmitIRP", drSrp.OfficeID, drIrp.IRPId, drIrp.FileID, drSrp.SRPDate);
                }

                aDAL.Commit();
                return dtOut;
            }
            catch (Exception x)
            {
                myDALManager.Rollback();
                    throw;
            }

        }
    }
}
