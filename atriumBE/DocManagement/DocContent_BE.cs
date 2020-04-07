using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.IO;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class DocContentBE : atLogic.ObjectBE
    {
        DocManager myA;
        docDB.DocContentDataTable myDocContentDT;
        public static string RTF = @"{\rtf1}";

        private global::System.Object missing = global::System.Type.Missing;

        internal DocContentBE(DocManager pBEMng)
            : base(pBEMng, pBEMng.DB.DocContent)
        {
            myA = pBEMng;
            myDocContentDT = (docDB.DocContentDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetDocContent();
        }
        public atriumDAL.DocContentDAL myDAL
        {
            get
            {
                return (atriumDAL.DocContentDAL)myODAL;
            }
        }

        public docDB.DocContentRow Load(int DocRefId)
        {
            //docDB.DocumentRow dr=myA.DB.Document.FindByDocId(DocId);
            return Load(DocRefId,null);
        }

        public docDB.DocContentRow Load(int DocRefId, string Version)
        {
            if (myA.AtMng.AppMan.UseService)
                Fill(myA.AtMng.AppMan.AtriumX().DocContentLoad(DocRefId, Version, myA.AtMng.AppMan.AtriumXCon));
            else
            {
                try
                {
                    Fill(myDAL.Load(DocRefId, Version));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(DocRefId, Version));
                }
            }
            return myDocContentDT.FindByDocId(DocRefId);
        }

        public int DocContentAuditDelete(int docId, string version)
        {
            if (myA.AtMng.AppMan.UseService)
                return myA.AtMng.AppMan.AtriumX().DocContentAuditDelete(docId,version, myA.AtMng.AppMan.AtriumXCon);
            else
            {
                return myDAL.DocContentAuditDelete(docId, version);
            }
        }

        //public void LoadByFileId(int FileId)
        //{
        //    Fill(myDAL.LoadByFileId(FileId));
        //}

        //public void LoadByCheckedOutBy(int officerId)
        //{
        //    Fill(myDAL.LoadByCheckedOutBy(officerId));
        //}

        public override DataRow Add(DataRow parentRow)
        {
            docDB.DocContentRow dr = (docDB.DocContentRow)base.Add(parentRow);

            return dr;
        }

        //public DataRow Add(DataRow parentRow, string fileName)
        //{
        //    docDB.DocumentRow newDoc = (docDB.DocumentRow)this.Add(parentRow);
        //    LoadFile(newDoc, fileName);
        //    return newDoc;
        //}

        //public void LoadFile(docDB.DocumentRow newDoc, string f)
        //{
        //    newDoc.Name = Path.GetFileName(f);

        //    docDB.DocContentRow newContent = null;
        //    newContent.Ext = Path.GetExtension(newDoc.Name);
        //    if (newContent.FileFormatRow == null || !newContent.FileFormatRow.AllowUpload)
        //    {
        //        newDoc.RejectChanges();
        //        newContent.RejectChanges();
        //        throw new AtriumException(Properties.Resources.YouCanTAddThisTypeOfDocumentToLawMate);
        //    }
        //    newContent.Contents = File.ReadAllBytes(f);

        //    FileInfo fi = new FileInfo(f);
        //    newContent.CreateDate = fi.CreationTime;
        //    newContent.ModDate = fi.LastWriteTime;
        //    newContent.Size = (int)fi.Length;

        //    newDoc.efDate = DateTime.Today;
        //    newDoc.efSubject = Path.GetFileNameWithoutExtension(newDoc.Name);

        //}

        protected override void AfterAdd(DataRow dr)
        {
            docDB.DocContentRow doc = (docDB.DocContentRow)dr;

            doc.CreateDate = DateTime.Now;
            doc.ReadOnly = false;
            doc.Ext = ".txt";
            doc.ModDate = doc.CreateDate;
            doc.Size = 0;

        }

        public string GetTempPath(docDB.DocumentRow ddr)
        {
            string fld = myA.AtMng.AppMan.TempPath;
            if (ddr  == null)
                fld += @"print\";
            else if (ddr != null && !ddr.IsNull("FileID"))
                fld += ddr.FileId.ToString() + @"\";

            if (!Directory.Exists(fld))
                Directory.CreateDirectory(fld);

            return fld;
        }
 
        protected override void AfterChange(DataColumn dc, DataRow r)
        {
            docDB.DocContentRow dr = (docDB.DocContentRow)r;

            switch (dc.ColumnName)
            {
                case "Ext":
                    //if (!dr.DocumentRow.IsefSubjectNull())
                    //    dr.DocumentRow.Name =DocumentBE.StripInvalidVarChar( dr.DocumentRow.efSubject) + dr.Ext;
                    ////else if (!dr.DocumentRow.IsNameNull())
                    ////    dr.DocumentRow.Name = dr.DocumentRow.Name.Substring(0, dr.DocumentRow.Name.LastIndexOf(".")) + dr.Ext;
                    //else
                    //    dr.DocumentRow.Name = "New Document" + dr.Ext;

                    if (dr.Ext.ToLower() == ".rtf" && dr.IsContentsNull())
                        dr.ContentsAsText = RTF;

                    dr.DocumentRow.ext = dr.Ext;
                    break;
                case "Contents":
                    dr.Size = dr.Contents.Length;
                    dr.ModDate = DateTime.Now;
                    break;
                // 2013-06-12 JLL: update to use isDraft only
                //case "ReadOnly":
                //    dr.DocumentRow.IsDraft = !dr.ReadOnly;
                //    break;
            }
        }

        protected override void BeforeUpdate(DataRow r)
        {
            docDB.DocContentRow dr = (docDB.DocContentRow)r;
            if (!dr.IsVersionNull())
            {
                if (dr.RowState != DataRowState.Added)
                {
                    object o = myA.AtMng.AppMan.ExecuteScalar("DocumentMaxVersion", dr.DocId);
                    int version = Convert.ToInt32(o);
                    version += 1;
                    dr.Version = version.ToString();
                }
                if (dr.RowState == DataRowState.Modified && dr.DocumentRow.RowState == DataRowState.Added)
                {
                    dr.forceInsert = true;
                }
                else
                    dr.forceInsert = false;

                dr.DocumentRow.CurrentVersion = dr.Version;
            }
            else
                dr.Version = "1";
        }

        protected override void BeforeChange(DataColumn dc, DataRow r)
        {
            docDB.DocContentRow dr = (docDB.DocContentRow)r;

            switch (dc.ColumnName)
            {
                case "Ext":
                    if(dr.IsExtNull())
                        throw new RequiredException("Extension");
                    else if(dr.FileFormatRow == null || !dr.FileFormatRow.AllowUpload)
                        throw new AtriumException(Properties.Resources.YouCanTAddThisTypeOfDocumentToLawMate, dr.Ext);

                    break;
                //case "ReadOnly":
                //    if (dr.HasVersion(DataRowVersion.Original) && (bool)dr[dc, DataRowVersion.Original] == true && dr.DocumentRow.IsDraft == true)
                //        throw new ReadOnlyException();
                //    break;
            }
        }

        public override bool CanEdit(DataRow ddr)
        {
            try
            {

                docDB.DocContentRow dr = (docDB.DocContentRow)ddr;
                if (dr == null)
                    return false;
                if (dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Unchanged)
                {
                    //make read-only if the document does not relate to the current file
                    if (myA.FM.IsVirtualFM || dr.DocumentRow.IsNull("FileId")|| dr.DocumentRow.FileId != myA.FM.CurrentFile.FileId)
                        return false | AllowEdit;

                    if (!dr.DocumentRow.IsCheckedOutByNull() && dr.DocumentRow.CheckedOutBy != myA.AtMng.OfficerLoggedOn.OfficerId)
                        return false | AllowEdit;

                    // 2013-06-12 JLL: update to use isDraft only
                    //bool ok =!(bool)dr["ReadOnly", DataRowVersion.Original];
                    bool ok = true;
                    if (dr.DocumentRow.HasVersion(DataRowVersion.Original))
                        ok = (bool)dr.DocumentRow["isDraft", DataRowVersion.Original];
                    else if (dr.DocumentRow.RowState == DataRowState.Added)
                        ok = true;
                    else
                        ok = (bool)dr.DocumentRow.IsDraft;

                    return ok | AllowEdit;
                }
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public string WriteTempFile(docDB.DocumentRow ddr, bool CreateAsReadOnly,string folder)
        {

            if (!ddr.IsCheckedOutDateNull() && ddr.CheckedOutBy == myA.AtMng.OfficerLoggedOn.OfficerId)
            {
                if (System.IO.File.Exists(ddr.CheckedOutPath))
                    return ddr.CheckedOutPath;
            }

            string temp = GetTempFileName(ddr,folder);

            WriteDoc(ddr.DocContentRow, CreateAsReadOnly, temp);
            return temp;
        }

        public string WriteTempFile(docDB.DocumentRow ddr, bool CreateAsReadOnly)
        {

            if (!ddr.IsCheckedOutDateNull() && ddr.CheckedOutBy == myA.AtMng.OfficerLoggedOn.OfficerId)
            {
                if (System.IO.File.Exists(ddr.CheckedOutPath))
                    return ddr.CheckedOutPath;
            }

            string temp = GetTempFileName(ddr);

            WriteDoc(ddr.DocContentRow, CreateAsReadOnly, temp);
            return temp;
        }

        //public void WriteDoc(docDB.DocContentRow ddr, bool CreateAsReadOnly, string temp)
        //{
        //    WriteDoc(ddr, CreateAsReadOnly, temp, false);
        //    //if (ddr.IsContentsNull())
        //    //{
        //    //    StreamWriter sw = File.CreateText(temp);
        //    //    sw.Close();
        //    //}
        //    //else
        //    //    File.WriteAllBytes(temp, ddr.Contents);

        //    //if (CreateAsReadOnly)
        //    //    File.SetAttributes(temp, FileAttributes.ReadOnly);
        //}

        public void WriteDoc(docDB.DocContentRow ddr, bool CreateAsReadOnly, string temp)
        {
            if (ddr.IsContentsNull())
            {
                StreamWriter sw = File.CreateText(temp);
                sw.Close();
            }
            else
            {
              
                    File.WriteAllBytes(temp, ddr.Contents);
              
            }

            if (CreateAsReadOnly)
                File.SetAttributes(temp, FileAttributes.ReadOnly);

        }

        public string GetTempFileName(docDB.DocumentRow ddr)
        {
            //create temp folder for viewing docs
            string fld = GetTempPath(ddr);
            return GetTempFileName(ddr, fld);
        }

        public string GetTempFileName(docDB.DocumentRow ddr, string fld)
        {
            //strip invalid characters out of file name
            string temp = fld;// +ddr.DocId.ToString() + " " + DateTime.Now.Ticks.ToString();
            if (ddr != null)
            {
                temp = System.IO.Path.Combine(fld, ddr.Name);
                //temp += ddr.DocumentRow.Name;
            }
            else
                temp = System.IO.Path.Combine(fld, "print" + ddr.ext);
                //temp += "print" + ddr.Ext;

            temp = temp.Trim();
            temp = GetUniqueTempFileName(fld, temp);
            return temp;
        }

        public static string GetUniqueTempFileName(string fld, string temp)
        {
            if (!fld.EndsWith(@"\"))
                fld += @"\";

            int i = 1;
            string test = temp;
            while (System.IO.File.Exists(test))
            {
                test = fld + System.IO.Path.GetFileNameWithoutExtension(temp) + "_" + i.ToString() + System.IO.Path.GetExtension(temp);
                i++;
            }
            return test;
        }

        public override DataRow[] GetCurrentRow()
        {
            return myDocContentDT.Select(); ;
        }

        public override string PromptFormat()
        {
            return base.PromptFormat();
        }

        public bool IsLatest(docDB.DocContentRow dr)
        {
            if (dr == null)
                return true;
            if (dr.IstsNull())
                return true;
            else
            {
                if (myA.AtMng.AppMan.UseService)
                    return myA.AtMng.AppMan.AtriumX().DocContentIsLatest(dr.DocId, dr.ts,myA.AtMng.AppMan.AtriumXCon);
                else
                {
                    try
                    {
                        return myDAL.IsLatest(dr.DocId, dr.ts);
                    }
                    catch (System.Runtime.Serialization.SerializationException x)
                    {
                        RecoverDAL();
                        return myDAL.IsLatest(dr.DocId, dr.ts);
                    }
                }
            } 
        }

    }
}