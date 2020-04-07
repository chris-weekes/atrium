using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using lmDatasets;

namespace atriumBE
{
    public class DocManager : atLogic.BEManager
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

     
        internal DocManager(FileManager fm):base(fm.AppMan)
        {
            CurrentFileId = fm.CurrentFileId;
            Init(fm);
            if (!fm.IsVirtualFM && fm.CurrentFile != null && fm.CurrentFile.RowState != DataRowState.Added)
                LoadAll(false);

        }
       
        private void Init(FileManager fm)
        {
            //cc = fm.cc;
           // myDALClient = fm.AtMng.myDALClient;
            base.DAL = fm.DALMngr;
            myFM = fm;
            RuleHandler = fm.RuleHandler;
            myatMng = fm.AtMng;
            //myUser = myatMng.myUser;

            MyDS = new docDB();
            //GetObjectBE(fm.DALMngr.GetFileFormat(), DB.FileFormat).Load();
            DB.FileFormat.Merge(myatMng.CodeDB.FileFormat);

            DB.EnforceConstraints = false;
        }

        public override void LoadAll(bool refresh)
        {
            if (refresh)
            {
                GetDocContent().PreRefresh();
                GetRecipient().PreRefresh();
                GetAttachment().PreRefresh();
                GetDocument().PreRefresh();
            }
            GetDocument().LoadByFileId(myFM.CurrentFileId);
        }

        public override void Update(atLogic.BusinessProcess BP)
        {
            BP.AddForUpdate(DB.DocXRef);
        }
        public docDB DB
        {
            get
            {
                return (docDB)MyDS;
            }
        }
 
        internal atriumDAL.atriumDALManager DALMngr
        {
            get
            {
                return myatMng.DALMngr;
            }
        }

        DocXRefBE myDocXRef;
        public DocXRefBE GetDocXRef()
        {

            if (myDocXRef == null)
            {
                myDocXRef = new DocXRefBE(this);
            }

            return myDocXRef;
        }

        AttachmentBE myAttachment;
        public AttachmentBE GetAttachment()
        {

            if (myAttachment == null)
            {
                myAttachment = new AttachmentBE(this);
            }

            return myAttachment;
        }

        DocumentBE myDocument;
        public DocumentBE GetDocument()
        {

            if (myDocument == null)
            {
                myDocument = new DocumentBE(this);
            }

            return myDocument;
        }

        DocContentBE myDocContent;
        public DocContentBE GetDocContent()
        {

            if (myDocContent == null)
            {
                myDocContent = new DocContentBE(this);
            }

            return myDocContent;
        }
        RecipientBE myRecipient;
        public RecipientBE GetRecipient()
        {

            if (myRecipient == null)
            {
                myRecipient = new RecipientBE(this);
            }

            return myRecipient;
        }

        atriumDAL.DirectHelper myDalMngForHitHilite;
        public string HitHilite(int docRefId, string searchTerm, bool summaryResults, string versionNumber)
        {
            if (myatMng.AppMan.UseService)
            {
                return myatMng.AppMan.AtriumX().HitHilite(docRefId, searchTerm, summaryResults, versionNumber, myatMng.AppMan.AtriumXCon);
            }
            else
            {
                if (myatMng.AppMan.UsingRemote)
                    return DALMngr.HitHilite(docRefId, searchTerm, summaryResults, versionNumber);
                else
                {
                    try
                    {
                        if (myDalMngForHitHilite != null)
                        {
                            string x = myDalMngForHitHilite.User;
                        }
                    }
                    catch (Exception x)
                    {
                        myDalMngForHitHilite = null;
                    }

                    if (myDalMngForHitHilite == null)
                        myDalMngForHitHilite = myatMng.AppMan.RemoteHelper();

                    return myDalMngForHitHilite.HitHilite(docRefId, searchTerm, summaryResults, versionNumber);
                }
            }
        }

        public docDB.VersionHistoryListDataTable GetVersionListDataTable(int DocId,int FileId)
        {
            try
            {
                if (AtMng.AppMan.UseService)
                    return AtMng.AppMan.AtriumX().DocContentLoadVersionHistory(DocId, FileId, AtMng.AppMan.AtriumXCon);
                else
                {
                    docDB.VersionHistoryListDataTable vhl = GetDocContent().myDAL.LoadVersionHistory(DocId, FileId);
                    return vhl;
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public void ListDocVersions(int intDocId)
        {
            // TODO: create list versions code
        }

        public void DeleteSpecificDocVersion(int intDocId, string sVersion)
        {
            // TODO: delete specific version code

        }

        public void RestoreSpecificDocVersion(int intDocId, string sVersion)
        {
            // TODO: restore specific version code
        }

    }

}
