using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class IssueBE:atLogic.ObjectBE
	{
		atriumManager myA;
		appDB.IssueDataTable myIssueDT;

		
		internal IssueBE(atriumManager pBEMng):base(pBEMng,pBEMng.DB.Issue)
		{
			myA=pBEMng;
			myIssueDT=(appDB.IssueDataTable)myDT;

            myIssueDT.AnalysisTextEngColumn.ExtendedProperties.Add("rtf", true);
            myIssueDT.AnalysisTextFreColumn.ExtendedProperties.Add("rtf", true);

            if (!myA.AppMan.UseService & myODAL == null)
                myODAL = myA.DALMngr.GetIssue();
        }
        public atriumDAL.IssueDAL myDAL
        {
            get
            {
                return (atriumDAL.IssueDAL)myODAL;
            }
        }

		

        protected override void AfterAdd(DataRow dr)
        {
            appDB.IssueRow ir = (appDB.IssueRow)dr;
            string ObjectName = this.myIssueDT.TableName;

            ir.IssueId = this.myA.PKIDGet(ObjectName, 1);
            ir.IssueNameEng = "[New Issue]";
            ir.IssueNameFre = "[New Issue]";
            if(ir.IsParentIssueIdNull())
                ir.ParentIssueId = 0;

            ir.SortByFileNumber = true;
        }

        public void Export(string path)
        {
            
            
            myA.DB.WriteXml(path, XmlWriteMode.WriteSchema);
        }

        public void Import(string path, int rootIssueId,  int targetIssueId,int rootFileId)
        {
            appDB ds = new appDB();
            ds.ReadXml(path);

            appDB.IssueDataTable tempIssues = ds.Issue;

            appDB.IssueRow ir = tempIssues.FindByIssueId(rootIssueId);
            appDB.IssueRow pir = myIssueDT.FindByIssueId(targetIssueId);

           
            ImportNode(tempIssues, ir, pir,rootFileId);

            BusinessProcess bp = myA.GetBP();
            bp.AddForUpdate(this);
            bp.Update();
        }

        public appDB.IssueRow Load(int IssueId)
        {
            try
            {
                Fill(myDAL.Load(IssueId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.Load(IssueId));
            }

            return myIssueDT.FindByIssueId(IssueId);
        }


        public void LoadByFileId(int FileId)
        {
            try
            {
                Fill(myDAL.LoadByFileId(FileId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByFileId(FileId));
            }
        }

        public void LoadByParentIssueId(int ParentIssueId)
        {
            try
            {
                Fill(myDAL.LoadByParentIssueId(ParentIssueId));
            }
            catch (System.Runtime.Serialization.SerializationException x)
            {
                RecoverDAL();
                Fill(myDAL.LoadByParentIssueId(ParentIssueId));
            }

        }

        private void ImportNode(appDB.IssueDataTable tempIssues,appDB.IssueRow ir, appDB.IssueRow parentIssue ,int rootFileId)
        {
            //this will recreate the issue structure
            //it does not try to synchronize it
            //only to be used to setup test data
            appDB.IssueRow newIR = (appDB.IssueRow)Add(null);
            
            newIR.ParentIssueId = parentIssue.IssueId;
            newIR.IssueNameEng = ir.IssueNameEng;
            newIR.IssueNameFre = ir.IssueNameFre;
            newIR.SortByFileNumber = ir.SortByFileNumber;

            //create file
            FileManager myFile = myA.CreateFile(myA.GetFile(rootFileId));
            myFile.CurrentFile.NameE = newIR.IssueNameEng;
            myFile.CurrentFile.NameF = newIR.IssueNameFre;

            BusinessProcess bp = myA.GetBP();

            bp.AddForUpdate(myFile.EFile);
            bp.AddForUpdate(myFile.GetFileXRef());
            bp.AddForUpdate(myFile.GetFileOffice());
            bp.AddForUpdate(myFile.GetFileContact());
            bp.AddForUpdate(myFile.EFile);
            bp.Update();

            if (!ir.IsFileIdNull())
            {
               

                newIR.FileId = myFile.CurrentFile.FileId;

            }
            foreach (appDB.IssueRow cir in ir.GetIssueRows())
            {
                ImportNode(tempIssues, cir, newIR,myFile.CurrentFileId);
            }
        }
	}
}

