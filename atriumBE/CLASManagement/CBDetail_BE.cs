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
    public class CBDetailBE : atLogic.ObjectBE
    {
        CLASManager myA;
        CLAS.CBDetailDataTable myCBDetailDT;

        internal CBDetailBE(CLASManager pBEMng)
            : base(pBEMng, pBEMng.DB.CBDetail)
        {
            myA = pBEMng;
            myCBDetailDT = (CLAS.CBDetailDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetCBDetail();

            this.myCBDetailDT.ValuableAmountColumn.ExtendedProperties.Add("format", "C");
            this.myCBDetailDT.SINColumn.ExtendedProperties.Add("format", "### ### ###");
        }
        public atriumDAL.CBDetailDAL myDAL
        {
            get
            {
                return (atriumDAL.CBDetailDAL)myODAL;
            }
        }

        public override bool CanAdd(DataRow parent)
        {
            CLAS.CashBlotterRow er = (CLAS.CashBlotterRow)parent;
            return AllowAdd || myA.AtMng.SecurityManager.CanAdd(er.FileID, atSecurity.SecurityManager.Features.CBDetail) > atSecurity.SecurityManager.ExPermissions.No;
        }
        public override bool CanEdit(DataRow dr)
        {
            CLAS.CBDetailRow er = (CLAS.CBDetailRow)dr;
            return AllowEdit || myA.AtMng.SecurityManager.CanUpdate(er.FileID, atSecurity.SecurityManager.Features.CBDetail) > atSecurity.SecurityManager.LevelPermissions.No;
        }

        public void LoadByCashBlotterId(int cashBlotterId)
        {
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().CBDetailLoadByCashBlotterId(cashBlotterId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByCashBlotterID(cashBlotterId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByCashBlotterID(cashBlotterId));
                }
            }
        }

        public decimal AllPayments()
        {
            decimal allPayments = 0;
            foreach (CLAS.CBDetailRow dr in myCBDetailDT)
            {
                allPayments += dr.ValuableAmount;
            }
            return allPayments;
        }

        public decimal CompletedPayments()
        {
            DateTime today = DateTime.Today;
            decimal completedPayments = 0;

            foreach (CLAS.CBDetailRow dr in myCBDetailDT)
            {
                if (dr.StatusCode == "OK" && dr.ValuableDate < today)
                {
                    completedPayments += dr.ValuableAmount;
                }
            }
            return completedPayments;
        }
        public bool MoreThanTwoNSFs()
        {
            int NSFCount = 0;
            foreach (CLAS.CBDetailRow dr in myCBDetailDT)
            {
                if (dr.StatusCode == "NF")
                {
                    NSFCount++;
                }
            }
            if (NSFCount > 2)
                return true;
            else
                return false;
        }

        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            string ObjectName = this.myCBDetailDT.TableName;
            CLAS.CBDetailRow dr = (CLAS.CBDetailRow)ddr;
            switch (dc.ColumnName)
            {
                case "ValuableAmount":
                    if (dr.IsValuableAmountNull())
                        throw new RequiredException(Resources.CBDetailValuableAmount);
                    if (dr.ValuableAmount < 0)
                        throw new AtriumException(Resources.MustBeGreaterThanZero, Resources.CBDetailValuableAmount);
                    break;
                case "ValuableType":
                    if (dr.IsValuableTypeNull())
                        throw new RequiredException(Resources.CBDetailValuableType);
                    else if (!myA.CheckDomain(dr.ValuableType, myA.FM.Codes("CBInstrumentType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Instrument Type");
                    break;
                case "OfficeID":
                    if (dr.IsOfficeIDNull())
                        throw new RequiredException(Resources.CBDetailOfficeID);
                    else if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
                    break;
                case "CurrencyCode":
                    if (dr.IsCurrencyCodeNull())
                        throw new RequiredException(Resources.CBDetailCurrencyCode);
                    else if (!myA.CheckDomain(dr.CurrencyCode, myA.FM.Codes("currencycode")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Currency Code");
                    break;
                case "StatusCode":
                    if (dr.IsStatusCodeNull())
                        throw new RequiredException(Resources.CBDetailStatusCode);
                    else if (!myA.CheckDomain(dr.StatusCode, myA.FM.Codes("CBStatus")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Payment Status Code");
                    break;
                case "PaymentSource":
                    if (dr.IsPaymentSourceNull())
                        throw new RequiredException(Resources.CBDetailPaymentSource);
                    else if (!myA.CheckDomain(dr.PaymentSource, myA.FM.Codes("CBPaymentSource")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Payment Source Code");
                    break;
                case "NatureOfPayment":
                    if (dr.IsNatureOfPaymentNull())
                        throw new RequiredException(Resources.CBDetailNatureOfPayment);
                     else if (!myA.CheckDomain(dr.NatureOfPayment, myA.FM.Codes("CBNatureOfPayment")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Nature of Payment Code");
                    break;

                //				case "NumberInSeries":
                //					if (dr.IsNull(dc,DataRowVersion.Current))
                //						myA.RaiseError((int)AtriumEnum.AppErrorCodes.CannotBeBlank, myA.GetLabelLeft(ObjectName, dc.ColumnName));
                //					break;		            
                case "ValuableDate":
                    if (dr.IsValuableDateNull())
                        throw new RequiredException(Resources.CBDetailValuableDate);
                    myA.IsValidDate(Resources.CBDetailValuableDate, dr.ValuableDate, false, DateTime.Today.AddMonths(-6), DateTime.Today.AddYears(3), Resources.ValidationSixMonthsAgo, Resources.Validation3YearsLater);
                    if (!dr.IsLastDayOfMonthNull() && dr.LastDayOfMonth && dr.ValuableDate.AddDays(1).Month == dr.ValuableDate.Month)
                        RaiseWarning(WarningLevel.Display, Resources.CBDetailValuableNotEOM);
                    break;
                case "ReceivedDate":
                    if (dr.IsReceivedDateNull())
                        throw new RequiredException(Resources.CBDetailReceivedDate);
                    myA.IsValidDate(Resources.CBDetailReceivedDate, dr.ReceivedDate, false, DateTime.Today.AddMonths(-6), DateTime.Today, Resources.ValidationSixMonthsAgo, Resources.ValidationToday);
                    break;
                case "SIN":
                    if (!dr.IsSINNull())
                    {
                        if (dr.SIN.Length != 9)
                            throw new AtriumException(Resources.BadSIN, dr.SIN);
                        else if (!ContactBE.IsValidSIN(dr.SIN))
                            throw new AtriumException(Resources.BadSIN, dr.SIN);
                    }
                    break;
                default:
                    break;
            }
        }

        protected override void BeforeUpdate(DataRow row)
        {
            CLAS.CBDetailRow dr = (CLAS.CBDetailRow)row;
            this.BeforeChange(dr.Table.Columns["ValuableAmount"], dr);
            if (dr.CashBlotterRow != null)
            {
                this.BeforeChange(dr.Table.Columns["ReceivedDate"], dr);
                this.BeforeChange(dr.Table.Columns["ValuableDate"], dr);
            }
            this.BeforeChange(dr.Table.Columns["ValuableType"], dr);
            this.BeforeChange(dr.Table.Columns["OfficeID"], dr);
            this.BeforeChange(dr.Table.Columns["CurrencyCode"], dr);
            this.BeforeChange(dr.Table.Columns["StatusCode"], dr);
            this.BeforeChange(dr.Table.Columns["PaymentSource"], dr);
            this.BeforeChange(dr.Table.Columns["NatureOfPayment"], dr);
        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {

            string ObjectName = this.myCBDetailDT.TableName;

            CLAS.CBDetailRow dr = (CLAS.CBDetailRow)ddr;

            switch (dc.ColumnName)
            {
                case "CalculateSeries":
                    if (dr.CalculateSeries && !dr.IsNumberInSeriesNull() && !dr.CalculateComplete)
                    {
                        //use current record as template
                        //create new records
                        //do not set numberinseries on new records
                        int n = dr.NumberInSeries;
                        //dr.SetNumberInSeriesNull();

                        for (int i = 1; i < n; i++)
                        {
                            CLAS.CBDetailRow drSeries = (CLAS.CBDetailRow)this.Add(dr.CashBlotterRow);
                            drSeries.BeginEdit();
                            drSeries.CashBlotterDetailID = myA.AtMng.PKIDGet("CBDetail", 1);
                            drSeries.CashBlotterID = dr.CashBlotterID;
                            drSeries.OfficeID = dr.OfficeID;
                            drSeries.updateDate = dr.updateDate;
                            drSeries.updateUser = dr.updateUser;
                            drSeries.entryDate = dr.entryDate;
                            drSeries.entryUser = dr.entryUser;

                            //							if(!dr.IsCommentsNull())
                            //								drSeries.Comments=dr.Comments;
                            drSeries.CurrencyCode = dr.CurrencyCode;
                            if (!dr.IsFileIDNull())
                                drSeries.FileID = dr.FileID;
                            if (!dr.IsSINNull())
                                drSeries.SIN = dr.SIN;
                            if (!dr.IsFirstNameNull())
                                drSeries.FirstName = dr.FirstName;
                            if (!dr.IsLastNameNull())
                                drSeries.LastName = dr.LastName;
                            drSeries.StatusCode = dr.StatusCode;
                            drSeries.ValuableAmount = dr.ValuableAmount;
                            drSeries.ValuableType = dr.ValuableType;
                            drSeries.ReceivedDate = dr.ReceivedDate;
                            drSeries.PaymentSource = dr.PaymentSource;
                            drSeries.NatureOfPayment = dr.NatureOfPayment;

                            if (dr.LastDayOfMonth)  //ignore period
                            {
                                //calculate last day of each month
                                DateTime d = dr.ValuableDate.AddMonths(i);
                                d = d.AddMonths(1);
                                d = d.AddDays(-d.Day);
                                drSeries.ValuableDate = d;
                            }
                            else
                            {
                                switch (dr.Period)
                                {

                                    case "w":
                                        drSeries.ValuableDate = dr.ValuableDate.AddDays(i * 7);
                                        break;
                                    case "b":
                                        drSeries.ValuableDate = dr.ValuableDate.AddDays(i * 14);
                                        break;
                                    case "m":
                                        drSeries.ValuableDate = dr.ValuableDate.AddMonths(i);
                                        break;
                                }
                            }
                            drSeries.EndEdit();

                        }
                        dr.CalculateComplete = true;
                    }
                    break;
                case "NumberInSeries":
                    //if (!dr.IsNumberInSeriesNull())
                   // {
                   //     
                    //}
                    break;
                case "SIN":
                    //try
                    //{
                    //    appDB.EFileSearchDataTable efsrs = myA.AtMng.FileSearchBySIN(dr.SIN);
                    //    if (efsrs.Count > 0)
                    //    {
                    //        appDB.EFileSearchRow efsr = efsrs[0];
                    //        dr.FileID = efsr.FileId;
                            
                    //        this.myA.GetDebtor().LoadBySIN(dr.SIN);
                    //        CLAS.DebtorRow cor = (CLAS.DebtorRow)this.myA.DB.Debtor.Select("SIN=" + dr.SIN)[0];
                    //        dr.LastName = cor.LastName;
                    //        dr.FirstName = cor.FirstName;
                    //        dr.EndEdit();
                    //    }
                    //}
                    //catch (Exception x)
                    //{
                    //    System.Diagnostics.Trace.WriteLine(Resources.SINNotFound + x.Message);
                    //}
                    break;
                default:
                    break;
            }
        }

        protected override void AfterAdd(DataRow row)
        {
            CLAS.CBDetailRow dr = (CLAS.CBDetailRow)row;
            string ObjectName = this.myCBDetailDT.TableName;

            dr.CashBlotterDetailID = this.myA.AtMng.PKIDGet(ObjectName, 1);
            dr.Period = "m";
        }

        protected override void AfterUpdate(DataRow row)
        {
            CLAS.CBDetailRow dr = (CLAS.CBDetailRow)row;
            EFileBE.XmlAddToc(myA.FM.CurrentFile, "cbdetail", "Payments Received", "Paiements reçus", 110);

        }

        protected override void BeforeDelete(DataRow row)
        {
            CLAS.CBDetailRow dr = (CLAS.CBDetailRow)row;
            string ObjectName = this.myCBDetailDT.TableName;
            myA.FM.GetActivity().DeleteRelatedCA(dr.FileID, ObjectName, dr.CashBlotterDetailID);
        }
    }
}

