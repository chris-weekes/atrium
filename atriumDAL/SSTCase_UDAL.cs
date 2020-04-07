using System;
using System.Data;
using System.Data.SqlClient;
using lmDatasets;

namespace atriumDAL
{
    public partial class SSTCaseDAL : atDAL.ObjectDAL
    {
        public byte[] LoadAll(int fileId)
        {
            atriumDALManager aDAL = (atriumDALManager)this.DAL;
            DataSet ds = new DataSet();
          //  ds.SchemaSerializationMode = SchemaSerializationMode.ExcludeSchema;
            ds.RemotingFormat = SerializationFormat.Binary;
            ds.EnforceConstraints = false;
          
            SST.SSTCaseDataTable scdt=aDAL.GetSSTCase().LoadByFileId(fileId);
            ds.Merge(scdt);
            ds.Merge(aDAL.GetSSTGroup().LoadByFileId(fileId));
            ds.Merge(aDAL.GetSSTDecision().LoadByFileId(fileId));
            ds.Merge(aDAL.GetSSTRequest().LoadByFileId(fileId));
            ds.Merge(aDAL.GetSSTReqRecipient().LoadByFileId(fileId));
            ds.Merge(aDAL.GetSSTCaseMatter().LoadByFileId(fileId));
            ds.Merge(aDAL.GetFileParty().LoadByFileId(fileId));
            ds.Merge(aDAL.GetHearing().LoadByFileID(fileId));
            ds.Merge(aDAL.GetSSTAppealGround().LoadByFileId(fileId));
            if(scdt.Rows.Count>0)
                ds.Merge(aDAL.GetFormHearing().LoadBySSTCaseId(scdt[0].SSTCaseId));
  
            FixTZDSIssue(ds);
            return atriumDALManager.CompressData(ds);
        }

    }
}
