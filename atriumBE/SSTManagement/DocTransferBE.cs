using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.Collections.Generic;
using System.Linq;
 
namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class DocTransferBE : atLogic.ObjectBE
    {
        SSTManager myA;
        SST.DocTransferDataTable myDocTransferDT;

        internal DocTransferBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.DocTransfer)
        {
            myA = pBEMng;
            myDocTransferDT = (SST.DocTransferDataTable)myDT;

            IsVirtual = true;
        }

        
        protected override void AfterAdd(DataRow row)
        {
           

            SST.DocTransferRow dr = (SST.DocTransferRow)row;
            string ObjectName = this.myDocTransferDT.TableName;

            dr.CreateShare = false;
            dr.DeleteAfter = false;
            dr.DeleteShare = false;
            dr.Pickup = false;
            dr.PickupOK = false;

            if (myA.DB.SSTCase[0].ProgramId == 3)
            {
                dr.ShareFolder = myA.AtMng.GetSetting(AppStringSetting.DataExchangeNetworkPath);
                dr.OutSubFolder = myA.AtMng.GetSetting(AppStringSetting.ToADMSFolder);
                dr.InSubFolder = myA.AtMng.GetSetting(AppStringSetting.TOAtriumFolder);
            }
            else
            {
                dr.ShareFolder = myA.AtMng.GetSetting(AppStringSetting.ISDataExchangeNetworkPath);
                dr.OutSubFolder = myA.AtMng.GetSetting(AppStringSetting.ISToADMSFolder);
                dr.InSubFolder = myA.AtMng.GetSetting(AppStringSetting.ISTOAtriumFolder);
            }

        }

        //public override DataRow[] GetParentRow()
        //{
        //    return base.GetParentRow();
        //}

        public override DataRow[] GetCurrentRow()
        {

            return myDocTransferDT.Select();

        }

        protected override void AfterUpdate(DataRow row)
        {
            SST.DocTransferRow dr = (SST.DocTransferRow)row;
            if (dr.DeleteAfter)
            {
                string dir = GetDocDumpShare(dr) + @"\" + dr.InSubFolder;

                foreach (string f in System.IO.Directory.GetFiles(dir))
                {
                    try
                    {
                        System.IO.File.SetAttributes(f, System.IO.FileAttributes.Normal);
                        System.IO.File.Delete(f);
                    }
                    catch (Exception x) { }
                }

            }
         
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.DocTransferRow dr = (SST.DocTransferRow)row;

            switch (dc.ColumnName)
            {
                case "CreateShare":
                    if (dr.CreateShare)
                        CreateFileDocumentDumpShare(dr);
                    break;
                case "Pickup":
                    if(dr.Pickup && !dr.PickupOK)
                        PickupDocs(dr);
                    break;
                case "DeleteShare":
                    DeleteShare(GetDocDumpShare(dr));
                    break;
                case "Dump":
                    
                    myA.GetDocDump().LoadDocs();
                    break;
                default:
                    break;
            }

        }

        private void DeleteShare(string temp)
        {
            if (System.IO.Directory.Exists(temp))
            {
                
                string[] files = System.IO.Directory.GetFiles(temp, "*", System.IO.SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    try
                    {
                        System.IO.File.SetAttributes(f, System.IO.FileAttributes.Normal);
                        System.IO.File.Delete(f);
                    }
                    catch (Exception x)
                    { }

                }
                try
                {
                    System.IO.Directory.Delete(temp, true);
                }
                catch (Exception x1)
                { }

            }
        }
        private void PickupDocs(SST.DocTransferRow dtr)
        {
            string dir = GetDocDumpShare(dtr) + @"\" + dtr.InSubFolder;
            docDB.DocumentRow dr = myA.FM.GetDocMng().DB.Document.FindByDocId(dtr.CoverDocId);

            foreach (string f in System.IO.Directory.GetFiles(dir))
            {


                docDB.DocumentRow newDoc = (docDB.DocumentRow)myA.FM.GetDocMng().GetDocument().Add(myA.FM.CurrentFile, f);
                //string tmp = f.Substring(f.LastIndexOf("\\") + 1);
                newDoc.efSubject = System.IO.Path.GetFileNameWithoutExtension(f);// tmp.Remove(tmp.LastIndexOf("."));
                newDoc.PopDocViewer = true;
                newDoc.SetColumnError("PageCount", "Page count is a required field");


                //newDoc.efType = "ATT";
                newDoc.SetefTypeNull();

                newDoc.IsDraft = false;
                // 2013-06-12 JLL: update to use isDraft only
                //newDoc.DocContentRow.ReadOnly = true;
                atriumBE.AttachmentBE d = myA.FM.GetDocMng().GetAttachment();
                lmDatasets.docDB.AttachmentRow att = (lmDatasets.docDB.AttachmentRow)d.Add(dr);
                att.AttachmentId = newDoc.DocId;
            }

            dtr.PickupOK = true;
        }

        public void CreateFileDocumentDumpShare(SST.DocTransferRow dr)
        {
            string fld = GetDocDumpShare(dr);
            if (!System.IO.Directory.Exists(fld))
            {
                System.IO.Directory.CreateDirectory(fld + @"\" + dr.OutSubFolder);
                System.IO.Directory.CreateDirectory(fld + @"\" +dr.InSubFolder);
            }
        }

        public string GetDocDumpShare(SST.DocTransferRow dr)
        {
            string fld="";
            if(!myA.FM.CurrentFile.IsFullFileNumberNull())
                fld = dr.ShareFolder + myA.FM.CurrentFile.FullFileNumber.Replace("-", @"\");
            if(!dr.IsOtherFFNNull())
                fld = dr.ShareFolder + dr.OtherFFN.Replace("-", @"\");

            dr.ShareFolderFFN = fld.Replace("\\","/");
            return fld;
        }

    }
}

