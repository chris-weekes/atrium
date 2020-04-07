using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class AttachmentBE:atLogic.ObjectBE
	{
		DocManager myA;
		docDB.AttachmentDataTable myAttachmentDT;


        internal AttachmentBE(DocManager pBEMng)
            : base(pBEMng, pBEMng.DB.Attachment)
		{
			myA=pBEMng;
			myAttachmentDT=(docDB.AttachmentDataTable)myDT;
            //if (myODAL == null)
            //    myODAL = myA.AtMng.DALMngr.GetAttachment();
        }
        public atriumDAL.AttachmentDAL myDAL
        {
            get
            {
                return (atriumDAL.AttachmentDAL)myODAL;
            }
        }


        //public docDB.AttachmentRow Load(int Id)
        //{
        //    try
        //    {
        //        Fill(myDAL.Load(Id));
        //    }
        //    catch (System.Runtime.Serialization.SerializationException x)
        //    {
        //        RecoverDAL();
        //        Fill(myDAL.Load(Id));
        //    }
			
        //    return myAttachmentDT.FindById(Id);
        //}


        //public void LoadByMsgId(int MsgId)
        //{
        //    try
        //    {
        //        Fill(myDAL.LoadByMsgId(MsgId));
        //    }
        //    catch (System.Runtime.Serialization.SerializationException x)
        //    {
        //        RecoverDAL();
        //        Fill(myDAL.LoadByMsgId(MsgId));
        //    }
			
        //}



        //public void LoadByAttachmentId(int AttachmentId)
        //{
        //    try
        //    {
        //        Fill(myDAL.LoadByAttachmentId(AttachmentId));
        //    }
        //    catch (System.Runtime.Serialization.SerializationException x)
        //    {
        //        RecoverDAL();
        //        Fill(myDAL.LoadByAttachmentId(AttachmentId));
        //    }
			
        //}

        protected override void AfterAdd(DataRow dr)
        {
            docDB.AttachmentRow row = (docDB.AttachmentRow)dr;
            row.Id = myA.AtMng.PKIDGet("Attachment", 10);
        }


        //public override DataRow[] GetParentRow()
        //{
        //    return myA.GetDocument().GetCurrentRow();
        //}

        public void Delete(docDB.AttachmentRow attchrow)
        {
            docDB.DocumentRow docrow = attchrow.DocumentRowByDocument_Attachment1;


            //delete doc if just added
            if (docrow.RowState == DataRowState.Added)
            {
                if (docrow.DocContentRow != null)
                    docrow.DocContentRow.Delete();
                docrow.Delete();
            }
            else
            {
                myA.GetDocument().Delete(docrow.DocId, null, attchrow);
            }

            //delete attachment
            attchrow.Delete();
        }




	}
}

