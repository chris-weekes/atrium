using System;
using System.Collections.Generic;
using System.Data;
using atLogic;
using lmDatasets;
using System.IO;
using atriumBE;
using atriumBE.Properties;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class SRPBE : atLogic.ObjectBE
    {
        FileManager myA;
        atriumDB.SRPDataTable mySRPDT;

        docDB.DocumentRow errorLog;

        //FileManager myFM;
        Dictionary<int, FileManager> fms;
        internal SRPBE(FileManager pBEMng)
            : base(pBEMng, pBEMng.DB.SRP)
        {
            myA = pBEMng;
            mySRPDT = (atriumDB.SRPDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetSRP();

            this.mySRPDT.FeesClaimedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.FeesClaimedTaxColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.FeesTaxedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.FeesTaxedTaxColumn.ExtendedProperties.Add("format", "C");
       
            this.mySRPDT.DisbursementClaimedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.DisbursementClaimedTaxColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.DisbursementTaxedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.DisbursementTaxedTaxColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.DisbursementTaxExemptClaimedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.DisbursementTaxExemptTaxedColumn.ExtendedProperties.Add("format", "C");

            this.mySRPDT.AmountPayableColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.NetTotalClaimedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.NetTotalTaxedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.QRWithdrawalColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.TaxingDifferenceColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.TotalClaimedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.TotalDisbursementTaxedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.TotalTaxClaimedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.TotalTaxedColumn.ExtendedProperties.Add("format", "C");
            this.mySRPDT.TotalTaxTaxedColumn.ExtendedProperties.Add("format", "C");
            
        }

        public atriumDAL.SRPDAL myDAL
        {
            get
            {
                return (atriumDAL.SRPDAL)myODAL;
            }
        }

        public atriumDB.SRPRow Load(int SRPID)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().SRPLoad(SRPID, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(SRPID));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(SRPID));
                }
            }
            return mySRPDT.FindBySRPID(SRPID);

        }

    

        public void LoadByFileId(int FileId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().SRPLoadByFileId(FileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByFileID(FileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByFileID(FileId));
                }
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            atriumDB.SRPRow dr = (atriumDB.SRPRow)row;
            string ObjectName = this.mySRPDT.TableName;

            dr.SRPID = this.myA.AtMng.PKIDGet(ObjectName, 1);
            //jll commented out 2012-01-27; myFM is null, OfficeManager.OfficeId is same as LeadOfficeId on myFM
            dr.OfficeID = myA.CurrentFile.LeadOfficeId;
            //dr.OfficeID = myA.CurrentOffice.OfficeId;

            //office row must be loaded kerim
            // test this code with dec 31/2003, jan 1/2004, mar 31/2004, april 1/2004
            if (myA.LeadOfficeMng.CurrentOffice.UsesBilling)
                dr.SRPDate = atDates.StandardDate.ThisQuarter.EndDate.Date;

            //JLL: added myFM!=null since myFM no longer set on Load
            else if (myA.CurrentFile.FileType.ToUpper() == "PR") //Timekeeping SRP JL: 2009/07/06
                dr.SRPDate = atDates.StandardDate.ThisMonth.BeginDate.Date;
            
            else
                dr.SRPDate = DateTime.Today;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            atriumDB.SRPRow srpr = (atriumDB.SRPRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(srpr.FileID, atSecurity.SecurityManager.Features.SRP);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public bool isSRPTaxationCompleted(atriumDB.IRPRow irpRow)
        {
            atriumDB.SRPRow srprow = myA.GetSRP().Load(irpRow.SRPID);
            if (srprow.IsTaxationCompletedNull())
                return false;
            else
                return true;
        }

        public bool isAllIRPsTaxed(atriumDB.SRPRow srpRow)
        {
            bool allTaxed = true;
            atriumDB.IRPRow[] trc = srpRow.GetIRPRows();
            if (trc.Length == 0)
            {
                myA.GetIRP().LoadBySRPId(srpRow.SRPID);
                trc = srpRow.GetIRPRows();
            }

            foreach (atriumDB.IRPRow tr in trc)
            {
                if (tr.IsDateTaxedNull())
                {
                    allTaxed = false;
                    break;
                }
            }
            return allTaxed;
 
        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            string ObjectName = this.mySRPDT.TableName;
            atriumDB.SRPRow dr = (atriumDB.SRPRow)ddr;
            switch (dc.ColumnName)
            {
                case "SRPDate":
                    if (dr.IsSRPDateNull())
                        throw new RequiredException(Resources.SRPSRPDate);
                    this.myA.IsValidDate(Resources.SRPSRPDate, dr.SRPDate, false, DebtorBE.CSLBegin, DateTime.Today.AddYears(30), Resources.ValidationCSLBegin, Resources.ValidationThirtyYearsLater);
                    if (this.myA.IsFieldChanged(dc, dr))
                        if (!dr.IsSRPSubmittedDateNull())
                            throw new AtriumException(Resources.SRPDateChangeNotAllowed);
                    break;
                case "SRPSubmittedDate":
                    if (!dr.IsSRPSubmittedDateNull())
                    {
                        //	this.myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
                        if (dr.IsSRPDateNull())
                            throw new RelatedException(Resources.SRPSRPSubmittedDate,Resources.SRPSRPDate);
                        this.myA.IsValidDate(Resources.SRPSRPSubmittedDate, dr.SRPSubmittedDate, true, dr.SRPDate, DateTime.Today, Resources.SRPSRPDate,Resources.ValidationToday);
                    }
                    break;

                case "SRPReceivedDate":
                    if (dr.IsSRPReceivedDateNull())
                        throw new RequiredException(Resources.SRPSRPReceivedDate);
                    if (myA.LeadOfficeMng.CurrentOffice.UsesBilling)
                    {
                        if (dr.IsSRPSubmittedDateNull())
                            throw new RelatedException(Resources.SRPSRPReceivedDate,Resources.SRPSRPSubmittedDate);
                        myA.IsValidDate(Resources.SRPSRPReceivedDate, dr.SRPReceivedDate, true, dr.SRPSubmittedDate, DateTime.Today, Resources.SRPSRPReceivedDate,Resources.ValidationToday);
                    }
                    else
                    {
                        if (dr.IsSRPDateNull())
                            throw new RelatedException(Resources.SRPSRPReceivedDate, Resources.SRPSRPDate);
                        myA.IsValidDate(Resources.SRPSRPReceivedDate, dr.SRPReceivedDate, true, dr.SRPDate, DateTime.Today, Resources.SRPSRPDate,Resources.ValidationToday);
                    }
                    break;

                case "TaxationBegan":
                    if (dr.IsTaxationBeganNull())
                        throw new RequiredException(Resources.SRPTaxationBegan);
                    if (myA.LeadOfficeMng.CurrentOffice.UsesBilling)
                    {
                        if (dr.IsSRPSubmittedDateNull())
                            throw new RelatedException (Resources.SRPTaxationBegan, Resources.SRPSRPSubmittedDate);
                        myA.IsValidDate(Resources.SRPTaxationBegan, dr.TaxationBegan, true, dr.SRPSubmittedDate, DateTime.Today, Resources.SRPSRPSubmittedDate,Resources.ValidationToday);
                    }
                    else
                    {
                        if (dr.IsSRPReceivedDateNull())
                            throw new RelatedException (Resources.SRPTaxationBegan,Resources.SRPSRPReceivedDate);
                        myA.IsValidDate(Resources.SRPTaxationBegan, dr.TaxationBegan, true, dr.SRPReceivedDate, DateTime.Today, Resources.SRPSRPReceivedDate, Resources.ValidationToday);
                    }
                    break;
                case "TaxationCompleted":
                    if (dr.IsTaxationCompletedNull())
                        throw new RequiredException(Resources.SRPTaxationCompleted);
                    if (dr.IsTaxationBeganNull())
                        throw new RelatedException(Resources.SRPTaxationCompleted,Resources.SRPTaxationBegan);
                    myA.IsValidDate(Resources.SRPTaxationCompleted, dr.TaxationCompleted, true, dr.TaxationBegan, DateTime.Today, Resources.SRPTaxationBegan, Resources.ValidationToday);
                    
                    //check to see that all taxation records have been taxed
                    if(!isAllIRPsTaxed(dr))
                        throw new AtriumException(Resources.SRPIRPNotTaxed);

                    break;

                case "OfficeID":
                    break;

                case "SRPID":
                    break;

                default:
                    //myA.RaiseError((int)AtriumEnum.AppErrorCodes.SRPReadOnly);
                    break;
            }
        }

 
        protected override void BeforeUpdate(DataRow row)
        {
            atriumDB.SRPRow dr = (atriumDB.SRPRow)row;
            this.BeforeChange(dr.Table.Columns["SRPDate"], dr);
            this.BeforeChange(dr.Table.Columns["SRPSubmittedDate"], dr);

            if (!dr.IsTaxationCompletedNull() &&
                dr.HasVersion(DataRowVersion.Original) && dr.IsNull(mySRPDT.TaxationCompletedColumn, DataRowVersion.Original))
                //!dr["TaxationCompleted", DataRowVersion.Original].Equals(dr["TaxationCompleted", DataRowVersion.Current]))
            {
                OfficeAccountBE agentAcc = this.myA.GetCLASMng().GetOfficeAccount();
                FileManager fm = myA.AtMng.GetFile(dr.FileID);

                decimal qraBalance = agentAcc.BalanceOn(dr.SRPDate);
                decimal srpTotal = dr.TotalTaxed;
                decimal qrw = 0;


                if (qraBalance != 0)
                {
                    if (srpTotal < qraBalance)
                    {
                        qrw = srpTotal;
                    }
                    else
                    {
                        qrw = qraBalance;
                    }
                    CLAS.OfficeAccountRow agentAccRow = (CLAS.OfficeAccountRow)agentAcc.Add(fm.CurrentFile);

                    agentAccRow.Amount = -qrw;
                    agentAccRow.TransactionDate = dr.SRPDate;
                    agentAccRow.PostingDate = DateTime.Today;
                    agentAccRow.Description = "QR Withdrawal";
                    agentAccRow.Type = "QW";
                    agentAccRow.SRPID = dr.SRPID;



                }
            }

        }
        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.SRPRow r = (atriumDB.SRPRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = r.EFileRow.FileStructXml;
            MyXml(r.EFileRow, xd);
            r.EFileRow.FileStructXml = xd.InnerXml;
        }

        public void CloseActivityTimePeriod(int srpId)
        {
            atriumDB.SRPRow drSrp = this.Load(srpId);
            if (drSrp.IsSRPSubmittedDateNull())
            {
                FileManager fm = this.myA.AtMng.GetFile(drSrp.FileID);
                officeDB.OfficerRow or = fm.AtMng.OfficeMng.GetOfficer().LoadByMyFileId(fm.CurrentFile.FileId);
                if (or != null)
                {
                try
                {
                    //drSrp.BeginEdit();
                    //drSrp.SRPSubmittedDate = DateTime.Today;
                    //drSrp.EndEdit();

                    ////officeDB.SRPRow newSrp = (officeDB.SRPRow)this.Add(fm.CurrentFile);
                    ////newSrp.FileID = fm.CurrentFile.FileId;
                    ////newSrp.entryUser = "saPeriodClosed";
                    ////newSrp.SRPDate = drSrp.SRPDate.AddMonths(1);

                    //BusinessProcess bp = myA.GetBP();
                    //bp.AddForUpdate(this);
                    //bp.Update();
                   
                    //TODO: make sure this is part of the transaction
                    //this.myA.AppMan.ExecuteSP("SubmitTimeslip", drSrp.SRPID, or.OfficerId, drSrp.SRPDate, drSrp.SRPDate.AddMonths(1).AddDays(-1), DateTime.Today);
                    
                    atriumDB.SRPDataTable dt= myDAL.SubmitTimeslip(drSrp.SRPID, or.OfficerId, drSrp.SRPDate, drSrp.SRPDate.AddMonths(1).AddDays(-1));
                    Fill(dt);
                    //this.Load(srpId);
                    
                }
                catch
                {
                    
                    throw;
                }
            }
                else
                throw new AtriumException("No officer for file");
            }
            else
                throw new AtriumException("Activity Time Period is already closed");
        }

        public void RollbackSRP(atriumDB.SRPRow srpRow)
        {
            if (!srpRow.IsSRPSubmittedDateNull() && myA.AtMng.SecurityManager.CanExecute(0, atSecurity.SecurityManager.Features.SysAdmin) == atSecurity.SecurityManager.ExPermissions.Yes)
                myA.AtMng.AppMan.ExecuteSP("adm_UndoSRP", srpRow.SRPID);
        }

        public void GenSrp(int srpId)
        {

            atriumDB.SRPRow drSrp = this.Load(srpId);
            officeDB.OfficeRow drOffice = this.myA.LeadOfficeMng.CurrentOffice; //.GetOffice(drSrp.OfficeID);

            if (!drOffice.UsesBilling)
                throw new AtriumException(Resources.SRPNoOnlineBilling);

            if (drSrp.IsSRPSubmittedDateNull())
                this.myA.AppMan.ExecuteSP( "InsertIRP", drSrp.OfficeID, srpId);
            else
                throw new AtriumException(Resources.SRPAlreadySubmitted);
        }


        public void SubmitSrp(int srpId)
        {

            atriumDB.SRPRow drSrp = this.Load(srpId);
            officeDB.OfficeRow drOffice = this.myA.LeadOfficeMng.CurrentOffice;// GetOffice(drSrp.OfficeID);
            FileManager fm = this.myA.AtMng.GetFile(drSrp.FileID);

            if (!drOffice.UsesBilling)
            {
                throw new AtriumException(Resources.SRPNoOnlineBilling);
            }

            if (drSrp.IsSRPSubmittedDateNull())
            {
                try
                {
                    drSrp.BeginEdit();
                    drSrp.SRPSubmittedDate = DateTime.Today;
                    drSrp.EndEdit();

                    atriumDB.SRPRow newSrp = (atriumDB.SRPRow)this.Add(fm.CurrentFile);
                    newSrp.FileID = fm.CurrentFile.FileId;
                    newSrp.entryUser = "SubmitSRP";

                    if (myA.AtMng.AppMan.UseService)
                    {
                        DataSet ds = new DataSet();
                        //ds.Tables.Add((atriumDB.SRPDataTable)myDT.GetChanges());
                         System.Data.DataTable dt = myDT.GetChanges();
                         if (dt != null)
                         {
                             dt.ExtendedProperties.Remove("BE");
                         }
                         ds.Tables.Add(dt);
                        Fill(myA.AtMng.AppMan.AtriumX().SubmitSRP(atLogic.BEManager.CompressData(ds), drSrp.SRPID, myA.AtMng.AppMan.AtriumXCon));
                    }
                    else
                    {
                        Fill(myDAL.SubmitSRP((atriumDB.SRPDataTable)myDT.GetChanges(), drSrp.SRPID));
                        
                    }
                    myA.SaveAll();

                    //this.myA.GetIRP().LoadBySRPId(srpId);

                    ////TODO: long running transaction issue
                    //BusinessProcess bp = myA.GetBP();
                    //bp.AddForUpdate(this);

                    //foreach (atriumDB.IRPRow drIrp in drSrp.GetIRPRows())
                    //{
                    //    this.myA.AppMan.ExecuteSP("SubmitIRP", drSrp.OfficeID, drIrp.IRPId, drIrp.FileID, drSrp.SRPDate);
                    //}
 
                    //bp.Update();
                }
                catch
                {
                    throw;
                }

            }
            else
                throw new AtriumException(Resources.SRPAlreadySubmitted);
        }


        private void DisbAll(atriumDB.SRPRow drSrp, int docId)
        {
            bool encounteredError = false;
            int lineNum = 0;

            try
            {
                docDB.DocumentRow doc = myA.GetDocMng().GetDocument().Load(docId);

                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StringReader sr = new StringReader(doc.DocContentRow.ContentsAsText))
                {
                    String line;

                    // Read and display lines from the file until the end of 
                    // the file is reached.

                    while ((line = sr.ReadLine()) != null && (line != ""))
                    {
                        lineNum++;
                        string[] elem = new string[7];
                        line.Split(new char[] { ',' }, 7).CopyTo(elem, 0);

                        string officeFileNo = elem[0].Replace("\"", "");
                        DateTime activityDate = DateTime.Parse(elem[1].Replace("\"", ""));
                        DateTime disbDate = DateTime.Parse(elem[2].Replace("\"", ""));
                        string disbTypeCode = elem[3].Replace("\"", "");
                        string comment = elem[6] == null ? "" : elem[6].Substring(1, elem[6].Length - 2);

                        if (elem[4] == null && elem[5] == null)
                        {
                            WriteErrorLog(officeFileNo, activityDate, disbTypeCode, disbDate, Resources.BothTaxableDisbursementAndNonTaxableDisbursementCannotBeBlank);
                            encounteredError = true;
                        }
                        else
                        {
                            decimal taxableDisb = elem[4] == null ? 0 : Convert.ToDecimal(elem[4]);
                            decimal nonTaxableDisb = elem[5] == null ? 0 : Convert.ToDecimal(elem[5]);

                            CodesDB.DisbursementTypeRow disbTypeR = myA.AtMng.CodeDB.DisbursementType.FindByDisbursementType(disbTypeCode);
                            if (disbTypeR == null)
                            {
                            }
                            else if (disbTypeR.IsBulk)
                            {
                                DisbBulkRow(officeFileNo, disbDate, disbTypeR, taxableDisb, nonTaxableDisb, comment, ref encounteredError, drSrp.OfficeID, drSrp.SRPDate);
                            }
                            else
                            {
                                DisbDetailRow(officeFileNo, activityDate, disbDate, disbTypeR, taxableDisb, nonTaxableDisb, comment, ref encounteredError, drSrp.OfficeID, drSrp.SRPDate);
                            }

                        }
                    } // end of while loop
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                WriteErrorLog(Resources.LineNumber + lineNum.ToString() + " - " + e.Message);
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw e;
            }
            DisbUpdate(encounteredError);

            WriteErrorLog(lineNum.ToString() + Resources.DisbursementRecordsImportedSuccessfully);

        }

        private void DisbDetailRow(string officeFileNo, DateTime activityDate, DateTime disbDate, CodesDB.DisbursementTypeRow disbTypeR, decimal taxableDisb, decimal nonTaxableDisb, string comment, ref bool encounteredError, int officeId, DateTime srpDate)
        {
            if (officeFileNo == "")
            {
                officeFileNo = "General Account";
            }

            try
            {

                FileManager fmCur = myA.AtMng.GetFile(officeFileNo, officeId);
                fms.Add(fmCur.CurrentFile.FileId, fmCur);

                atriumDB.EFileRow drEfile = fmCur.CurrentFile;// fm.EFile.LoadByOfficeFileNum(officeFileNo, officeId);
                atriumDB.ActivityRow drActivity;

                if (drEfile != null)
                {
                    //fmCur.GetActivity().LoadByFileId(drEfile.FileId);

                    drActivity = GetClosestActivity(fmCur, activityDate, officeFileNo, officeId.ToString(), disbTypeR, disbDate, drEfile.FileId.ToString(), ref encounteredError);

                    if (drActivity != null)
                    {
                        atriumDB.DisbursementRow drDisb = (atriumDB.DisbursementRow)fmCur.GetDisbursement().Add(drActivity);
                        AddDisbursement(drDisb, officeId, disbDate, srpDate, nonTaxableDisb, taxableDisb, disbTypeR.DisbursementType, comment);
                        if (drDisb.HasErrors)
                        {
                            WriteErrorLog(officeFileNo, disbTypeR.DisbursementType, disbDate, Resources.CouldNotAddDisbursement + drDisb.RowError);
                            encounteredError = true;
                        }

                    }
                    else
                    {
                        WriteErrorLog(officeFileNo, disbTypeR.DisbursementType, disbDate, Resources.MatchingActivityNotFound);
                        encounteredError = true;

                    }

                }

            }
            catch (Exception x)
            {
                WriteErrorLog(officeFileNo, activityDate, disbTypeR.DisbursementType, disbDate, Resources.OfficeFileNumberNotValid + x.Message);
                encounteredError = true;
            }

        }

        private string PrintArray(string[] strArr)
        {
            string output = "";
            foreach (string str in strArr)
            {
                output += ", " + str;
            }
            return output;
        }

        private atriumDB.ActivityRow GetClosestActivity(FileManager fmCur, DateTime activityDate, string officeFileNo, string officeId, CodesDB.DisbursementTypeRow disbTypeR, DateTime disbDate, string fileId, ref bool encounteredError)
        {
            string concat = "";
            string activityQuery = "officeid = " + officeId + " and fileid = " + fileId + " and (";
            //foreach (ActivityConfig.ACDisbRow acdr in disbTypeR.GetACDisbRows())
            //{
            //    activityQuery +=concat+ " activitycodeid = " + acdr.ActivityCodeId  ;
            //    concat = " or ";
            //}

            activityQuery += ")";

            atriumDB.ActivityRow[] drActivityArr = (atriumDB.ActivityRow[])fmCur.DB.Activity.Select(activityQuery);

            atriumDB.ActivityRow drClosest = null;

            if (drActivityArr.Length == 0)
            {
                WriteErrorLog(officeFileNo, activityDate, disbTypeR.DisbursementType, disbDate, Resources.FileDoesNotHaveRequiredActivity );
                encounteredError = true;

            }
            else if (drActivityArr.Length == 1)
            {
                drClosest = drActivityArr[0];
            }
            else //if (drActivityArr.Length == 2)
            {

                for (int i = 0; i < drActivityArr.Length; i++)
                {
                    DateTime t2 = drActivityArr[i].ActivityDate;
                    DateTime t3 = drClosest == null ? DateTime.MinValue : drClosest.ActivityDate;

                    System.TimeSpan ts1 = activityDate - t2;
                    System.TimeSpan ts2 = activityDate - t3;


                    if (ts1.Duration() <= ts2.Duration())
                        drClosest = drActivityArr[i];
                }
            }

            return drClosest;
        }

      
        public void Import(string disbType, int srpId, int docId)
        {
            fms = new Dictionary<int, FileManager>();
            atriumDB.SRPRow drSrp = Load(srpId);

           switch (disbType)
            {
                case "Bulk":
                    DisbBulk(drSrp, docId);
                    break;
                case "All":
                    DisbAll(drSrp, docId);
                    break;
            }
          
        }

        private void DisbBulk(atriumDB.SRPRow drSrp, int docId)
        {
            bool encounteredError = false;
            int lineNum = 0;


            try
            {
                docDB.DocumentRow doc = myA.GetDocMng().GetDocument().Load(docId);

                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StringReader sr = new StringReader(doc.DocContentRow.ContentsAsText))
                {
                    String line;

                    // Read and display lines from the file until the end of 
                    // the file is reached.

                    while ((line = sr.ReadLine()) != null && (line != ""))
                    {
                        line = line.Replace("\"", "");
                        lineNum++;
                        string[] elem = new string[6];
                        line.Split(',').CopyTo(elem, 0);

                        string officeFileNo = elem[0];
                        DateTime disbDate = DateTime.Parse(elem[1]);
                        string disbTypeCode = elem[2];
                        string comment = elem[5] == null ? "" : elem[5];

                        if ((elem[3] == null || elem[3] == "") && (elem[4] == null || elem[4] == ""))
                        {
                            WriteErrorLog(officeFileNo, disbTypeCode, disbDate, Resources.BothTaxableDisbursementAndNonTaxableDisbursementCannotBeBlank);
                            encounteredError = true;
                        }
                        else
                        {
                            decimal taxableDisb;
                            decimal nonTaxableDisb;
                            if (elem[3] == null || elem[3] == "")
                                taxableDisb = 0;
                            else
                                taxableDisb = Convert.ToDecimal(elem[3]);

                            if (elem[4] == null || elem[4] == "")
                                nonTaxableDisb = 0;
                            else
                                nonTaxableDisb = Convert.ToDecimal(elem[4]);
                            CodesDB.DisbursementTypeRow disbTypeR = myA.AtMng.CodeDB.DisbursementType.FindByDisbursementType(disbTypeCode);
                            DisbBulkRow(officeFileNo, disbDate, disbTypeR, taxableDisb, nonTaxableDisb, comment, ref encounteredError, drSrp.OfficeID, drSrp.SRPDate);

                        }
                    } // end of while loop
                }


            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                WriteErrorLog(Resources.LineNumber + lineNum.ToString() + " - " + e.Message);
                System.Diagnostics.Debug.WriteLine(e.ToString());
                throw e;
            }
            DisbUpdate(encounteredError);

            WriteErrorLog(lineNum.ToString() + Resources.DisbursementRecordsImportedSuccessfully);


        }

        private void DisbUpdate(bool encounteredError)
        {

            if (encounteredError )
            {
                fms.Clear();
                throw new AtriumException(Resources.SRPDisbErr);

            }
            else
            {
                try
                {
                    foreach (FileManager fmCur in fms.Values)
                    {
                        if (!fmCur.DB.HasErrors)
                        {
                            atriumBE.DisbursementBE disbBE = fmCur.GetDisbursement();
                            atriumBE.ActivityBE activityBE = fmCur.GetActivity();
                            BusinessProcess bp = fmCur.GetBP();
                            bp.AddForUpdate(activityBE);
                            bp.AddForUpdate(disbBE);
                            bp.Update();
                        }
                        else
                        {
                            throw new AtriumException(Resources.SRPDisbErr);

                        }

                    }
                    
                    fms.Clear();
                }
                catch (Exception x)
                {
                    fms.Clear();
                    
                    throw x;

                }
            }

        }


        private void DisbBulkRow(string officeFileNo, DateTime disbDate, CodesDB.DisbursementTypeRow disbTypeR, decimal taxableDisb, decimal nonTaxableDisb, string comment, ref bool encounteredError, int officeId, DateTime srpDate)
        {

            if (!disbTypeR.IsBulk)//  disbTypeCode == "CO" || disbTypeCode == "FA" || disbTypeCode == "LD" || disbTypeCode == "PH" || disbTypeCode == "PO" || disbTypeCode == "RM")
            {
                if (officeFileNo == "")
                {
                    officeFileNo = "General Account";
                }
                atriumDB.EFileRow drEfile = null;

                try
                {
                    FileManager fmCur = myA.AtMng.GetFile(officeFileNo, officeId);
                    fms.Add(fmCur.CurrentFile.FileId, fmCur);
                    drEfile = fmCur.CurrentFile;

                    if (drEfile != null)
                    {
                        //fmCur.GetActivity().LoadByFileId(drEfile.FileId);
                        //JL: Change to DisbursementType from ACManagement to CodesDB bobo.
                        //string activityQuery = "officeid=" + officeId.ToString() + " and fileid=" + drEfile.FileId.ToString() + " and activitycodeid=" + disbTypeR.GetACDisbRows()[0].ActivityCodeId.ToString() + " and activitydate='" + srpDate.ToString("yyyy/MM/dd") + "'";
                        string activityQuery = "";
                        atriumDB.ActivityRow[] drActivityArr = (atriumDB.ActivityRow[])fmCur.DB.Activity.Select(activityQuery);
                        atriumDB.ActivityRow drActivity;
                        if (drActivityArr.Length == 0)
                        {
                            //JL: Change of DisbursementType from ACMAnager dataset to CodesDB dataset bobo.
                            //ActivityConfig.ACSeriesRow bulkACS =(ActivityConfig.ACSeriesRow) myA.AtMng.acMng.DB.ACSeries.Select("ActivityCodeId=" + disbTypeR.GetACDisbRows()[0].ActivityCodeId.ToString())[0];//.FindByACSeriesId(disbTypeR.GetACDisbRows()[0].ACSeriesId);
                            ActivityConfig.ACSeriesRow bulkACS = null;
                            ACEngine ace=fmCur.InitActivityProcess().Add(srpDate, bulkACS, null, false, null);
                            drActivity = ace.NewActivity;

                            drActivity.BeginEdit();
                            drActivity.OfficeId = officeId;
                            drActivity.EndEdit();
                            if (drActivity.HasErrors)
                            {
                                if (drActivity.HasErrors)
                                {
                                    WriteErrorLog(officeFileNo, "", srpDate, Resources.CouldNotCreateAC022 + drActivity.RowError);
                                    encounteredError = true;
                                }
                            }
                        }
                        else
                            drActivity = drActivityArr[0];

                        atriumDB.DisbursementRow drDisb = (atriumDB.DisbursementRow)fmCur.GetDisbursement().Add(drActivity);
                        AddDisbursement(drDisb, officeId, disbDate, srpDate, nonTaxableDisb, taxableDisb, disbTypeR.DisbursementType, comment);
                        if (drDisb.HasErrors)
                        {
                            WriteErrorLog(officeFileNo, disbTypeR.DisbursementType, disbDate, Resources.CouldNotAddDisbursement + drDisb.RowError);
                            encounteredError = true;
                        }

                    }

                }
                catch (Exception x)
                {
                    WriteErrorLog(officeFileNo, disbTypeR.DisbursementType, disbDate, Resources.OfficeFileNumberNotValid + x.Message);
                    encounteredError = true;
                }

            }
            else
            {
                WriteErrorLog(officeFileNo, disbTypeR.DisbursementType, disbDate, Resources.InvalidDisbursmentTypeCode);
                encounteredError = true;
            }

        }

        private void AddDisbursement(atriumDB.DisbursementRow drDisb, int officeId, DateTime disbDate, DateTime srpDate, decimal disbTaxExempt, decimal disbTax, string disbType, string comment)
        {


            drDisb.BeginEdit();
            drDisb.OfficeId = officeId;
            drDisb.DisbDate = disbDate;
            drDisb.DisbTaxExempt = disbTaxExempt;
            drDisb.DisbTaxable = disbTax;
            drDisb.DisbType = disbType;
            drDisb.Comment = comment;
            drDisb.entryDate = srpDate;
            drDisb.EndEdit();
        }

        private void WriteErrorLog(string officeFileNum, DateTime activityDate, string disbTypeCode, DateTime disbDate,  string errorMsg)
        {
            string msg = DateTime.Now.ToString() + "," + officeFileNum + "," + activityDate.ToString("yyyy/MM/dd") + "," + disbTypeCode + "," + disbDate.ToString("yyyy/MM/dd") + "," + errorMsg;

            WriteErrorLog(msg);
        }

        private void WriteErrorLog(string officeFileNum, string disbTypeCode, DateTime disbDate,  string errorMsg)
        {
            string msg = DateTime.Now.ToString() + "," + officeFileNum + "," + "" + "," + disbTypeCode + "," + disbDate.ToString("yyyy/MM/dd") + "," + errorMsg;

            WriteErrorLog(msg);
        }

        private void WriteErrorLog(string errorMsg)
        {
            if (errorLog == null)
            {
                //create error log doc
                errorLog = (docDB.DocumentRow)myA.GetDocMng().GetDocument().Add(myA.CurrentFile);
                myA.GetDocMng().GetDocContent().Add(errorLog);
                errorLog.IsDraft = true;
                errorLog.DocContentRow.Ext = ".txt";
                errorLog.efSubject = DocumentBE.VerifySubjectLength(Resources.DisbursementImportErrorLog);
                errorLog.DocContentRow.ContentsAsText = Resources.DisbErrorHeader+Environment.NewLine;
            }
            //StreamWriter sr;

            //if (!File.Exists(filePath)) 
            //    sr = File.CreateText(filePath);
            //else
            //    sr = new StreamWriter(filePath, true);

            //sr.WriteLine (errorMsg);
            //sr.Close();

            errorLog.DocContentRow.ContentsAsText += errorMsg+Environment.NewLine;

            BusinessProcess bp = myA.GetDocMng().GetBP();

            bp.AddForUpdate(myA.GetDocMng().GetDocContent());
            bp.AddForUpdate(myA.GetDocMng().GetDocument());
            bp.Update(); 
        }



        public void Export(string type, int srpId,string path)
        {

            atriumDB.SRPRow drSrp = this.Load(srpId);
            officeDB.OfficeRow drOffice = this.myA.LeadOfficeMng.CurrentOffice;//.GetOffice(drSrp.OfficeID);

            DataSet ds;
          //  string fileName = drOffice.OfficeCode + "_" + drSrp.SRPDate.ToString("yyyyMMdd");

            if (type == "Disb")
            {
            //    fileName += "_Disb";
                ds = this.myA.AppMan.ExecuteDataset("ExportDisbursements", drSrp.OfficeID, drSrp.SRPID);
            }
            else // (type == "Fees")
            {
             //   fileName += "_Fees";
                ds = this.myA.AppMan.ExecuteDataset("ExportFees", drSrp.OfficeID, drSrp.SRPID);
            }

            //string fullFilePath = System.IO.Path.Combine(filePath,fileName);
            this.myA.WriteDataTableToCSV(path, ds.Tables[0], "", true);

         
            //docDB.DocumentRow dr = (docDB.DocumentRow)myA.GetDocMng().GetDocument().Add(myA.CurrentFile);
            //myA.GetDocMng().GetDocContent().Add(dr);
            //dr.DocContentRow.Ext = ".csv";
            //dr.efSubject = DocumentBE.VerifySubjectLength(fileName);
            //dr.DocContentRow.ContentsAsText = sb.ToString();
            //dr.IsDraft = false;

            //BusinessProcess bp = myA.GetDocMng().GetBP();

            //bp.AddForUpdate(myA.GetDocMng().GetDocContent());
            //bp.AddForUpdate(myA.GetDocMng().GetDocument());
            //bp.Update(); 

            //return dr.DocId;
        }


        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {

            string ObjectName = this.mySRPDT.TableName;

            atriumDB.SRPRow dr = (atriumDB.SRPRow)ddr;


            switch (dc.ColumnName)
            {
                case "TaxationCompleted":
                    break;
                default:
                    break;
            }
        }

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[] { myA.CurrentFile };
        //}

        public override DataRow[] GetCurrentRow()
        {
            //get the record with no submit date
            //if it doesn't exist get a new record
            this.LoadByFileId(myA.CurrentFile.FileId);
            if (this.mySRPDT.Rows.Count == 0)
            {
                return new DataRow[] { this.Add(myA.CurrentFile) };
            }
            else if (this.mySRPDT[0].IsSRPSubmittedDateNull())
            {
                return new DataRow[] { this.mySRPDT[0] };
            }
            else
            {
                return new DataRow[] { this.Add(myA.CurrentFile) };
            }
        }

        public void LoadOfficeManager(int srpId)
        {
            atriumDB.SRPRow sr = Load(srpId);
            //JLL: is this even needed?  all references to this method come from batchBE ... should we look to ensure FM is loaded instead?
            myA.LeadOfficeMng.GetOffice(sr.OfficeID);
        }

        public bool CanAdd(int fileId)
        {
            myA = myA.AtMng.GetFile(fileId);

            //officeDB.OfficeRow or = myA.GetOffice().Load(fm.CurrentFile.LeadOfficeId);

            if (myA.CurrentFile.OwnerOfficeId == myA.AtMng.WorkingAsOfficer.OfficeId && !myA.LeadOfficeMng.CurrentOffice.UsesBilling)
                return true;

            return false;
        }
        public atriumDB.SRPRow GetCurrentSRP(int officeId)
        {
            //note: this method does not load the srprow into the dataset

            atriumDB.SRPRow sr;
            atriumDB.SRPDataTable srpDt= myDAL.LoadCurrentByOfficeID(officeId);
            if (srpDt.Rows.Count > 0)
                return srpDt[0];
            else
                return null;
            

        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {

            int i = 0;
            foreach (atriumDB.SRPRow sr in  myA.DB.SRP.Select("FileId=" + efr.FileId.ToString(), "SRPDate desc"))
            {
                i++;
                if (i >= 4)
                { break; }
                MyXml(sr, xd);
            }
            if (i == 0) // no SRP, new office
                EFileBE.XmlAddToc(xd, "srp", "SRP Info", "Info SDP", 250);
        }

        public void MyXml(atriumDB.SRPRow sr, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xeb = EFileBE.XmlAddFld(xd, "srp", "Agent Billings", "Facturation de mandataire", 250);
            System.Xml.XmlElement xes = EFileBE.XmlAddFld(xeb, "srp" + sr.SRPID.ToString(), "SRP " + sr.SRPDate.ToString("yyyy/MM/dd"), "SDP " + sr.SRPDate.ToString("yyyy/MM/dd"), 250);

            System.Xml.XmlElement xe = xd.CreateElement("toc");
            xe.SetAttribute("supertype", "srp");
            xe.SetAttribute("type", "srp");
            xe.SetAttribute("id", sr.SRPID.ToString());
            xe.SetAttribute("titlee", "SRP Info");
            xe.SetAttribute("titlef", "Info SDP");
            xes.AppendChild(xe);

            System.Xml.XmlElement xeIRP = xd.CreateElement("toc");
            xeIRP.SetAttribute("supertype", "srp");
            xeIRP.SetAttribute("type", "srpdetail");
            xeIRP.SetAttribute("id", sr.SRPID.ToString());
            xeIRP.SetAttribute("titlee", "SRP Detail");
            xeIRP.SetAttribute("titlef", "Détails SDP");
            xes.AppendChild(xeIRP);

            if (myA.LeadOfficeMng.CurrentOffice.UsesBilling)
            {
                System.Xml.XmlElement xeBR = xd.CreateElement("toc");
                xeBR.SetAttribute("supertype", "srp");
                xeBR.SetAttribute("type", "billingreview");
                xeBR.SetAttribute("id", sr.SRPID.ToString());
                xeBR.SetAttribute("titlee", "Billing Review");
                xeBR.SetAttribute("titlef", "Révision de facturation");
                xes.AppendChild(xeBR);
            }
            
            //if (xes.ParentNode == null)
            //{
            //    System.Xml.XmlElement xeb = EFileBE.XmlAddFld(xd, "srp", "Agent Billings", "Agent Billings", 250);
            //    xeb.AppendChild(xes);
            //}
        }
    }
}

