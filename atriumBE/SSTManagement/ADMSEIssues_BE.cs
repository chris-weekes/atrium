using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ADMSEIssuesBE : atLogic.ObjectBE
    {
        SSTManager myA;
        SST.ADMSEIssuesDataTable myADMSEIssuesDT;


        internal ADMSEIssuesBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.ADMSEIssues)
        {
            myA = pBEMng;
            myADMSEIssuesDT = (SST.ADMSEIssuesDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetADMSEIssues();

        }

        public atriumDAL.ADMSEIssuesDAL myDAL
        {
            get
            {
                return (atriumDAL.ADMSEIssuesDAL)myODAL;
            }
        }

        public SST.ADMSEIssuesRow Load(int Id)
        {
            Fill(myDAL.Load(Id));
            return myADMSEIssuesDT.FindById(Id);
        }
        public void LoadBySSTFileNumber(string SSTFileNumber)
        {
            try
            {
                Fill(myDAL.LoadByFileNumber(SSTFileNumber));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByFileNumber(SSTFileNumber));
            }

        }
        protected override void AfterAdd(DataRow row)
        {
            SST.ADMSEIssuesRow dr = (SST.ADMSEIssuesRow)row;
            string ObjectName = this.myDT.TableName;

            dr.Id = myA.AtMng.PKIDGet(ObjectName, 10);
            dr.TransferStatus = "UNPROCESSED";
            dr.AtriumUser = myA.AtMng.OfficerLoggedOn.UserName;
            dr.SSTFileNumber = myA.FM.CurrentFile.FullFileNumber;


        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.ADMSEIssuesRow dr = (SST.ADMSEIssuesRow)row;
            switch (dc.ColumnName)
            {
                case "AppealStatusM":
                   // dr.AppealStatus =myA.AtMng.GetMap().MapOut(" dr.AppealStatusM;
                    break;
                case "IssueIdM":

                    string i0 = myA.AtMng.GetMap().MapOut("Issue", dr.IssueIdM.ToString());
                    if(i0!=null)
                        dr.IssueID = System.Convert.ToInt32(i0);

                    string i1 = myA.AtMng.GetMap().MapOut("Issue1", dr.IssueIdM.ToString());
                    if(i1!=null)
                        dr.IssueSub1Id =System.Convert.ToInt32(i1 );

                    string i2 = myA.AtMng.GetMap().MapOut("Issue2", dr.IssueIdM.ToString());
                    if(i2!=null)
                        dr.IssueSub2Id =System.Convert.ToInt32(i2);
                    break;
                case "OutComeM":
                    dr.OutCome = myA.AtMng.GetMap().MapOut("OutCome",dr.OutComeM);
                    break;
            }
        }

    }
}

