using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using lmDatasets;
using atLogic;
using atriumBE.Properties;

namespace atriumBE
{
    public class CLASManager : atLogic.BEManager
    {

        FileManager myFM;

        public FileManager FM
        {
            get { return myFM; }
            set { myFM = value; }
        }
        atriumManager myatMng;
        public atriumManager AtMng
        {
            get { return myatMng; }
            set { myatMng = value; }
        }

        AccountHistoryBE myAccountHistory;
        public AccountHistoryBE GetAccountHistory()
        {

            if (myAccountHistory == null)
            {
                myAccountHistory = new AccountHistoryBE(this);
            }

            return myAccountHistory;
        }

        BankruptcyAccountBE myBankruptcyAccount;
        public BankruptcyAccountBE GetBankruptcyAccount()
        {

            if (myBankruptcyAccount == null)
            {
                myBankruptcyAccount = new BankruptcyAccountBE(this);
            }

            return myBankruptcyAccount;
        }

        HardshipBE myHardship;
        public HardshipBE GetHardship()
        {

            if (myHardship == null)
            {
                myHardship = new HardshipBE(this);
            }

            return myHardship;
        }

        InsolvencyAccountBE myInsolvencyAccount;
        public InsolvencyAccountBE GetInsolvencyAccount()
        {

            if (myInsolvencyAccount == null)
            {
                myInsolvencyAccount = new InsolvencyAccountBE(this);
            }

            return myInsolvencyAccount;
        }
        BankruptcyBE myBankruptcy;
        CashBlotterBE myCashBlotter;
        CBDetailBE myCBDetail;
        CostBE myCost;
        DebtBE myDebt;
        DebtorBE myDebtor;
        InsolvencyBE myInsolvency;
        JudgmentBE myJudgment;
        JudgmentAccountBE myJudgmentAccount;
        PropertyBE myProperty;
        WritBE myWrit;
        WritHistoryBE myWritHistory;
        CompOfferBE myCompOffer;
        CompOfferDetailBE myCompOfferDetail;
        ActivityAttributionBE myActivityAttribution;
        FileAccountBE myFileAccount;
        FileHistoryBE myFileHistory;
        TaxingBE myTaxing;
        OfficeAccountBE myOfficeAccount;

        public OfficeAccountBE GetOfficeAccount()
        {

            if (myOfficeAccount == null)
            {
                myOfficeAccount = new OfficeAccountBE(this);
            }

            return myOfficeAccount;
        }

        public TaxingBE GetTaxing()
        {

            if (myTaxing == null)
            {
                myTaxing = new TaxingBE(this);
            }

            return myTaxing;
        }

        public FileHistoryBE GetFileHistory()
        {

            if (myFileHistory == null)
            {
                myFileHistory = new FileHistoryBE(this);
            }

            return myFileHistory;
        }

        public FileAccountBE GetFileAccount()
        {

            if (myFileAccount == null)
            {
                myFileAccount = new FileAccountBE(this);
            }

            return myFileAccount;
        }

        public ActivityAttributionBE GetActivityAttribution()
        {

            if (myActivityAttribution == null)
            {
                myActivityAttribution = new ActivityAttributionBE(this);
            }

            return myActivityAttribution;
        }


        public CompOfferBE GetCompOffer()
        {

            if (myCompOffer == null)
            {
                myCompOffer = new CompOfferBE(this);
            }

            return myCompOffer;
        }
        public CompOfferDetailBE GetCompOfferDetail()
        {

            if (myCompOfferDetail == null)
            {
                myCompOfferDetail = new CompOfferDetailBE(this);
            }

            return myCompOfferDetail;
        }
     
        public BankruptcyBE GetBankruptcy()
        {

            if (myBankruptcy == null)
            {
                myBankruptcy = new BankruptcyBE(this);
            }

            return myBankruptcy;
        }

        public CashBlotterBE GetCashBlotter()
        {

            if (myCashBlotter == null)
            {
                myCashBlotter = new CashBlotterBE(this);
            }

            return myCashBlotter;
        }


        public CBDetailBE GetCBDetail()
        {

            if (myCBDetail == null)
            {
                myCBDetail = new CBDetailBE(this);
            }

            return myCBDetail;
        }

        public CostBE GetCost()
        {

            if (myCost == null)
            {
                myCost = new CostBE(this);
            }

            return myCost;
        }


        public DebtBE GetDebt()
        {

            if (myDebt == null)
            {
                myDebt = new DebtBE(this);
            }

            return myDebt;
        }


        public DebtorBE GetDebtor()
        {

            if (myDebtor == null)
            {
                myDebtor = new DebtorBE(this);
            }

            return myDebtor;
        }



        public InsolvencyBE GetInsolvency()
        {

            if (myInsolvency == null)
            {
                myInsolvency = new InsolvencyBE(this);
            }

            return myInsolvency;
        }


        public JudgmentBE GetJudgment()
        {

            if (myJudgment == null)
            {
                myJudgment = new JudgmentBE(this);
            }

            return myJudgment;
        }


        public JudgmentAccountBE GetJudgmentAccount()
        {

            if (myJudgmentAccount == null)
            {
                myJudgmentAccount = new JudgmentAccountBE(this);
            }

            return myJudgmentAccount;
        }


        public PropertyBE GetProperty()
        {

            if (myProperty == null)
            {
                myProperty = new PropertyBE(this);
            }

            return myProperty;
        }



        public WritBE GetWrit()
        {

            if (myWrit == null)
            {
                myWrit = new WritBE(this);
            }

            return myWrit;
        }


        public WritHistoryBE GetWritHistory()
        {

            if (myWritHistory == null)
            {
                myWritHistory = new WritHistoryBE(this);
            }

            return myWritHistory;
        }

        public override void LoadAll(bool refresh)
        {
            if (refresh)
            {
                GetFileHistory().PreRefresh();
                GetDebt().PreRefresh();
                GetAccountHistory().PreRefresh();
                GetJudgment().PreRefresh();
                GetJudgmentAccount().PreRefresh();
                GetCost().PreRefresh();
                GetWrit().PreRefresh();
                GetWritHistory().PreRefresh();
                GetProperty().PreRefresh();
                GetCashBlotter().PreRefresh();
                GetCBDetail().PreRefresh();
                GetBankruptcy().PreRefresh();
                GetBankruptcyAccount().PreRefresh();
                GetInsolvency().PreRefresh();
                GetInsolvencyAccount().PreRefresh();
                GetHardship().PreRefresh();
                GetCompOffer().PreRefresh();
                GetCompOfferDetail().PreRefresh();
                GetTaxing().PreRefresh();
                GetOfficeAccount().PreRefresh();

                GetDebtor().PreRefresh();
              
            }


            DataSet ds;
            if (myatMng.AppMan.UseService)
            {
                ds = BEManager.DecompressDataSet(myatMng.AppMan.AtriumX().LoadCLAS(FM.CurrentFileId, myatMng.AppMan.AtriumXCon) , new lmDatasets.CLAS());
            }
            else
            {
                try
                {
                    ds = BEManager.DecompressDataSet(this.FM.EFile.myDAL.CLASLoadByFileId(FM.CurrentFileId), new lmDatasets.CLAS());
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    this.FM.EFile.RecoverDAL();
                    ds = BEManager.DecompressDataSet(this.FM.EFile.myDAL.CLASLoadByFileId(FM.CurrentFileId), new lmDatasets.CLAS());
                }
            }
            GetFileHistory().Fill(ds.Tables["FileHistory"]);
            GetDebt().Fill(ds.Tables["Debt"]);
            GetAccountHistory().Fill(ds.Tables["AccountHistory"]);
            GetJudgment().Fill(ds.Tables["Judgment"]);
            GetJudgmentAccount().Fill(ds.Tables["JudgmentAccount"]);
            GetCost().Fill(ds.Tables["Cost"]);
            GetWrit().Fill(ds.Tables["Writ"]);
            GetWritHistory().Fill(ds.Tables["WritHistory"]);
            GetProperty().Fill(ds.Tables["Property"]);
            GetCashBlotter().Fill(ds.Tables["CashBlotter"]);
            GetCBDetail().Fill(ds.Tables["CBDetail"]);
            GetBankruptcy().Fill(ds.Tables["Bankruptcy"]);
            GetBankruptcyAccount().Fill(ds.Tables["BankruptcyAccount"]);
            GetInsolvency().Fill(ds.Tables["Insolvency"]);
            GetInsolvencyAccount().Fill(ds.Tables["InsolvencyAccount"]);
            GetHardship().Fill(ds.Tables["Hardship"]);
            GetCompOffer().Fill(ds.Tables["CompOffer"]);
            GetCompOfferDetail().Fill(ds.Tables["CompOfferDetail"]);
            GetTaxing().Fill(ds.Tables["Taxing"]);
            GetOfficeAccount().Fill(ds.Tables["OfficeAccount"]);

            GetDebtor().Fill(ds.Tables["Debtor"]);

            ds.Clear();
            ds.Dispose();
         

        }
  
        public CLASManager(FileManager FM)
            : base(FM.AppMan)
        {

            if (FM.AtMng.GetSetting(AppBoolSetting.useCLASMngr))
            {
                Init(FM);

                if (!FM.IsVirtualFM && FM.CurrentFile != null)
                {
                    if (FM.CurrentFile.RowState != DataRowState.Added)
                        LoadAll(false);
                }
            }

        }
        private void Init(FileManager atMng)
        {

            myFM = atMng;

            base.DAL = atMng.DALMngr;
            RuleHandler = atMng.RuleHandler;
            myatMng = atMng.AtMng;
         

            MyDS = new CLAS(); ;
            MyDS.EnforceConstraints = false;
            MyDS.RemotingFormat = SerializationFormat.Binary;

            myMngrs.Add(DB.DataSetName, this);
        

        }

        public string DBXML
        {
            get
            {
                return DB.GetXml();
            }
        }
        public CLAS DB
        {
            get
            {
                return (CLAS)MyDS;
            }
        }
     

        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

 
        public override void Update(BusinessProcess BP)
        {
            BP.AddForUpdate(GetDebtor(),"Address");
            BP.AddForUpdate(GetFileHistory());
            BP.AddForUpdate(GetJudgment());
            BP.AddForUpdate(GetJudgmentAccount());
            BP.AddForUpdate(GetDebt());
            BP.AddForUpdate(GetAccountHistory());
            BP.AddForUpdate(GetTaxing());
            BP.AddForUpdate(GetWrit());
            BP.AddForUpdate(GetWritHistory());
            BP.AddForUpdate(GetCashBlotter());
            BP.AddForUpdate(GetCBDetail());
            BP.AddForUpdate(GetProperty());
            BP.AddForUpdate(GetBankruptcy());
            BP.AddForUpdate(GetBankruptcyAccount());
            BP.AddForUpdate(GetInsolvency());
            BP.AddForUpdate(GetInsolvencyAccount());
            BP.AddForUpdate(GetCompOffer());
            BP.AddForUpdate(GetCompOfferDetail());
            BP.AddForUpdate(GetHardship());
            BP.AddForUpdate(GetCost());
            BP.AddForUpdate(GetOfficeAccount());
        }

    }
}
