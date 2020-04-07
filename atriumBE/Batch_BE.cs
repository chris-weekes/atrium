using System;
using System.Data;
using System.Collections.Generic;
using atLogic;
using lmDatasets;
using System.IO;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class BatchBE : atLogic.ObjectBE
    {
        atriumManager myA;
        appDB.BatchDataTable myBatchDT;

        internal BatchBE(atriumManager pBEMng)
            : base(pBEMng, pBEMng.DB.Batch)
        {
            myA = pBEMng;
            myBatchDT = (appDB.BatchDataTable)myDT;
            if (!myA.AppMan.UseService && myODAL == null)
                myODAL = myA.DALMngr.GetBatch();
        }
        public atriumDAL.BatchDAL myDAL
        {
            get
            {
                return (atriumDAL.BatchDAL)myODAL;
            }
        }

      

        public void LoadPending()
        {
            try
            {
                Fill(myDAL.LoadPending());
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadPending());
            }
        }

        public void LoadByOfficeCode(string OfficeCode)
        {
            try
            {
                Fill(myDAL.LoadByOfficeCode(OfficeCode));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByOfficeCode(OfficeCode));
            }
        }



        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            appDB.BatchRow sur = (appDB.BatchRow)ddr;
            switch (dc.ColumnName)
            {
                default:
                    break;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            appDB.BatchRow dr = (appDB.BatchRow)row;
            string ObjectName = this.myBatchDT.TableName;

            dr.BatchID = this.myA.PKIDGet(ObjectName, 1);
            dr.Status = "P";
            dr.BatchDate = DateTime.Now;
            dr.RunAfterDate = DateTime.Now;
            dr.Priority = 5;
            dr.Completed = false;
            dr.OfficerID = this.myA.OfficerLoggedOn.OfficerId;
            dr.UserName = this.myA.OfficerLoggedOn.UserName;
            //			dr.Password = this.myA.DBOfficerLoggedOn.
            dr.OfficeCode = this.myA.OfficeLoggedOn.OfficeCode;
        }

        public void Save()
        {
            try
            {
                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(this);
                bp.Update();
            }
            catch (Exception ex)
            {
                this.myBatchDT.RejectChanges();
                throw ex;
            }

        }

        public void SubmitJob(string job,string parameters)
        {
            try
            {
                lmDatasets.appDB.BatchRow br = (lmDatasets.appDB.BatchRow)Add(null);
                br.JobName = job;
                br.Parameters = parameters;

                BusinessProcess bp = myA.GetBP();
                bp.AddForUpdate(this);
                bp.Update();
            }
            catch (Exception x)
            {
                myBatchDT.RejectChanges();
                throw x;
            }

        }
        public void Execute(appDB.BatchRow drBatch)
        {
            try
            {

                
                //JLL:2012-01-30 change as a result of moving SRP to atriumDB
                //SRPBE srpBE = this.myA.OfficeMng.GetSRP();
                SRPBE srpBE = this.myA.GetFile().GetSRP();

                this.myA.Impersonate(drBatch.UserName, drBatch.OfficeCode);

                drBatch.BeginEdit();
                drBatch.Status = "A";
                drBatch.StartRunDate = DateTime.Now;
                drBatch.EndEdit();
                Save();

                drBatch.BeginEdit();

                int srpId;
                string[] param;

                switch (drBatch.JobName)
                {
                    case "RunSQL":
                        myA.DALMngr.ExecuteNonQuery(drBatch.Parameters);

                        break;
                    case "CreateACFFN":
                        param = drBatch.Parameters.Split(',');
                        string ffn = param[0];
                        int fileId1 = myA.GetFile(ffn).CurrentFileId;
                        int acseriesId1 = System.Convert.ToInt32(param[1]);
                                                
                        DateTime acDate1 = drBatch.BatchDate.Date;
                        if (param.Length >= 3)
                        {
                            acDate1 = DateTime.Parse(param[2]);
                        }
                        string ctxTable1 = null;
                        int ctxId1 = 0;
                        if (param.Length >= 4)
                            ctxTable1 = param[3];
                        if (param.Length >= 5)
                            ctxId1 = System.Convert.ToInt32(param[4]);
                        CreateAC(fileId1, acseriesId1, acDate1, ctxTable1,ctxId1);
                        break;
                    case "CreateAC":
                        param = drBatch.Parameters.Split(',');
                        int fileId = System.Convert.ToInt32(param[0]);
                        int acseriesId = System.Convert.ToInt32(param[1]);
                        DateTime acDate = drBatch.BatchDate.Date;
                        if (param.Length >= 3)
                        {
                            acDate = DateTime.Parse(param[2]);
                        }
                        string ctxTable = null;
                        int ctxId = 0;
                        if (param.Length >= 4)
                            ctxTable = param[3];
                        if (param.Length >= 5)
                            ctxId = System.Convert.ToInt32(param[4]);

                        CreateAC(fileId, acseriesId, acDate,ctxTable,ctxId);

                        break;
                    case "CommitSRP":
                        srpId = Convert.ToInt32(drBatch.Parameters);
                        srpBE.LoadOfficeManager(srpId);
                        srpBE.GenSrp(srpId);
                        srpBE.SubmitSrp(srpId);
                        break;
                    case "GenerateSRP":
                        srpId = Convert.ToInt32(drBatch.Parameters);
                        srpBE.LoadOfficeManager(srpId);
                        srpBE.GenSrp(srpId);
                        break;
                    //case "ExportDisb":
                    //    srpId = Convert.ToInt32(drBatch.Parameters);
                    //    srpBE.LoadOfficeManager(srpId);
                    //    //drBatch.OutputFile = myA.OfficeMng.GetSRP().Export("Disb", srpId).ToString();
                    //    drBatch.OutputFile = myA.GetFile().GetSRP().Export("Disb", srpId).ToString();
                    //    break;
                    //case "ExportFees":
                    //    srpId = Convert.ToInt32(drBatch.Parameters);
                    //    srpBE.LoadOfficeManager(srpId);
                    //    //drBatch.OutputFile = myA.OfficeMng.GetSRP().Export("Fees", srpId).ToString();
                    //    drBatch.OutputFile = myA.GetFile().GetSRP().Export("Fees", srpId).ToString();
                    //    break;
                    case "PLOfficeUpdate":
                        this.myA.AppMan.ExecuteSP("PLOfficeDistribUpdate");
                        break;
                    case "ImportDisb":
                        param = drBatch.Parameters.Split(',');

                        // param[0] srpid
                        // param[1] UploadPath
                        // param[2] DisbType

                        srpId = Convert.ToInt32(param[0]);
                        srpBE.LoadOfficeManager(srpId);
                        int uploadPath =Convert.ToInt32( param[1]);
                        string disbType = param[2];

                    
                        //JLL: I know this ain't right, that's for sure. Add fileid parameter?
                        atriumDB.SRPRow drSrp = this.myA.GetFile().DB.SRP.FindBySRPID(srpId);
                        if (drSrp == null)
                        {
                            drSrp = srpBE.Load(srpId);
                        }
                        if (drSrp.IsSRPSubmittedDateNull())
                        {
                            //string errLogFileName = Path.GetFileNameWithoutExtension(uploadPath) + "_err.log";
                            //string errLogPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(uploadPath)), "Output\\" + errLogFileName);

                            try
                            {
                                srpBE.Import(disbType, srpId, uploadPath);
                            }
                            catch (Exception e)
                            {
                                //drBatch.OutputFile = errLogPath;
                                throw e;
                            }
                        }
                        else
                            throw new AtriumException(atriumBE.Properties.Resources.BatchImportNotAllowed);
                        break;
                    default:
                        throw new AtriumException(atriumBE.Properties.Resources.BatchInvalidJobName);
                    
                }

                drBatch.Message = "Job succeeded";
                drBatch.Status = "F";
                drBatch.Completed = true;
                drBatch.EndRunDate = DateTime.Now;
                drBatch.EndEdit();
                Save();
            }
            catch (Exception err)
            {
                drBatch.Message = "Job failed: " + "/n/r" + err.Message;
                drBatch.Status = "X";
                drBatch.Completed = true;
                drBatch.EndRunDate = DateTime.Now;
                drBatch.EndEdit();
                Save();

                myA.LogError(err);
                
                CreateAC(myA.GetSetting(AppIntSetting.BatchJobFailedFileId),myA.GetSetting(AppIntSetting.BatchJobFailedAcSeriesId) );
                
            }
        }

        //TFS#54543 BY 2013-8-29
        //made the function overloading so that we can set the activitydate 
        private void CreateAC(int fileId, int acseriesId)
        {
            CreateAC(fileId, acseriesId, DateTime.Today,null,0);
        }


        private void CreateAC(int fileId, int acseriesId, DateTime acDate,string ctxTable,int ctxId)
        {
            ActivityConfig.ACSeriesRow acsr = myA.acMng.DB.ACSeries.FindByACSeriesId(acseriesId);
            FileManager fm = myA.GetFile(fileId);

            ActivityBP abp = fm.InitActivityProcess();
            abp.CreateAC(acseriesId, acDate,ctxTable,ctxId,0, ACEngine.RevType.Nothing);

        }

       

        public void RunAllJobs()
        {
            myA.loggedOnAsSystem = true;

            myBatchDT.Clear();
            myBatchDT.AcceptChanges();
            LoadPending();
            //Status='P' and RunAfterDate<#"+ DateTime.Now.ToString() +"#
            foreach (lmDatasets.appDB.BatchRow br in myBatchDT.Select("","Priority,batchid"))
            {
                Execute(br);

                //System.Diagnostics.EventLog.WriteEntry(br.Message, System.Diagnostics.EventLogEntryType.Information);
            
            }

           // Load();
            myA.loggedOnAsSystem = false;
        }
    }
}