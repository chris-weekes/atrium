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
    public class DocDumpBE : atLogic.ObjectBE
    {
        SSTManager myA;
        SST.DocDumpDataTable myDocDumpDT;

        internal DocDumpBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.DocDump)
        {
            myA = pBEMng;
            myDocDumpDT = (SST.DocDumpDataTable)myDT;

            IsVirtual = true;

            LoadDocs();
        }

        public void LoadDocs()
        {
            myDocDumpDT.Clear();
            myDocDumpDT.AcceptChanges();
            //load table with all doc
            foreach (docDB.DocumentRow d in myA.FM.GetDocMng().DB.Document)
            {
                if (d.isElectronic & d.RowState!= DataRowState.Added & !d.IsefTypeNull() && d.efType!="CONT")
                {
                    SST.DocDumpRow ddr = myDocDumpDT.NewDocDumpRow();
                    ddr.DocId = d.DocId;
                    ddr.efDate = d.efDate;
                    ddr.efSubject = d.efSubject;
                    ddr.efType = d.efType;
                    //if (!d.IsSentToShareFolderNull())
                    //{
                    //    if(d.SentToShareFolder==2)
                    //    {
                    //        System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(System.Drawing.Bitmap));

                    //        byte[] blob = (byte[])tc.ConvertTo(Properties.Resources.SentToShareSuccess, typeof(byte[]));
                    //        ddr.SentToShareFolder =blob;
                    //    }
                    //    else if (d.SentToShareFolder == 3)
                    //    {
                    //        System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(System.Drawing.Bitmap));

                    //        byte[] blob = (byte[])tc.ConvertTo(Properties.Resources.SentToShareFail, typeof(byte[]));
                    //        ddr.SentToShareFolder = blob;
                       
                    //    }

                    //}
                    myDocDumpDT.AddDocDumpRow(ddr);
                }
            }
            myDocDumpDT.AcceptChanges();
        }
        
        protected override void AfterAdd(DataRow row)
        {
            SST.DocDumpRow dr = (SST.DocDumpRow)row;
            string ObjectName = this.myDocDumpDT.TableName;
            dr.Dump = false;
        }

        public override DataRow[] GetCurrentRow()
        {
            return myDocDumpDT.Select();
        }
        protected override void BeforeUpdate(DataRow row)
        {
            SST.DocDumpRow dr = (SST.DocDumpRow)row;
            DumpDocs(dr);
        }
        protected override void AfterUpdate(DataRow row)
        {
            //SST.DocDumpRow dr = (SST.DocDumpRow)row;
            //DumpDocs(dr);
        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.DocDumpRow dr = (SST.DocDumpRow)row;

            switch (dc.ColumnName)
            {
                default:
                    break;
            }
        }

        private void DumpDocs(SST.DocDumpRow ddr)
        {
            SST.DocTransferRow drDocTran = myA.DB.DocTransfer[0];

            ActivityBP abp = myA.FM.CurrentActivityProcess;
            if (abp.CurrentACE != null)
            {
                drDocTran=(SST.DocTransferRow)abp.CurrentACE.relTables["DocTransfer0"][0].Row;
            }
            
            string dir = myA.GetDocTransfer().GetDocDumpShare(drDocTran) + @"\" + drDocTran.OutSubFolder;
            
            DocContentBE dcBE=myA.FM.GetDocMng().GetDocContent();
            DocumentBE dBE = myA.FM.GetDocMng().GetDocument();
        
            if (ddr.Dump)
            {
                docDB.DocumentRow dr = myA.FM.GetDocMng().DB.Document.FindByDocId(ddr.DocId);
                if (dr.DocContentRow == null)
                    dcBE.Load(dr.DocRefId, dr.CurrentVersion);

                string fileName = dcBE.GetTempFileName(dr, dir);
                
                //dcBE.WriteDoc(dBE.Print(dr), false, fileName);
                try
                {
                    dcBE.WriteDoc(dBE.Print(dr), false, fileName);
                    dr.SentToShareFolder = 2;
                   
                }
                catch (Exception x)
                {
                    dr.SentToShareFolder = 3;
                    
                    ddr.SetColumnError("Dump", String.Format(Properties.Resources.DocDumpFailed + " " + x.Message, dr.Name));  //setting this error will prevent saving the records
                    myA.AtMng.LogError(x); 
                    //myA.FM.RaiseWarning(WarningLevel.Display,String.Format( Properties.Resources.DocDumpFailed,fileName), "ATRIUM");
                }
                dr.DocDumpDate = DateTime.Now;
                dr.DocDumpFullPath = fileName;
                dr.DocDumpUser = myA.AtMng.OfficerLoggedOn.UserName;

            }
        }
    }
}