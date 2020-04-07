using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
    public enum FXLinkType
    {
        ParentChild=0,
        XRef=1,
        Shortcut=2
    }
	/// <summary>
	/// 
	/// </summary>
	public class FileXRefBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.FileXRefDataTable myFileXRefDT;

		
		internal FileXRefBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.FileXRef)
		{
			myA=pBEMng;
			myFileXRefDT=(atriumDB.FileXRefDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileXRef();
        }

        public atriumDAL.FileXRefDAL myDAL
        {
            get
            {
                return (atriumDAL.FileXRefDAL)myODAL;
            }
        }

		public atriumDB.FileXRefRow Load(int Id)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().FileXRefLoad(Id, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.Load(Id));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.Load(Id));
                }
            }
			return myFileXRefDT.FindById(Id);
		}


		public void LoadByFileId(int FileId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().FileXRefLoadByFileId(FileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
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
		}

		public void LoadByOtherFileId(int OtherFileId)
		{
            if (myA.AtMng.AppMan.UseService)
            {
                Fill(myA.AtMng.AppMan.AtriumX().FileXRefLoadByOtherFileId(OtherFileId, myA.AtMng.AppMan.AtriumXCon));
            }
            else
            {
                try
                {
                    Fill(myDAL.LoadByOtherFileId(OtherFileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(myDAL.LoadByOtherFileId(OtherFileId));
                }
            }
		}

        protected override void AfterAdd(DataRow dr)
        {
            atriumDB.FileXRefRow row = (atriumDB.FileXRefRow)dr;
            //use odd
            row.Id = myA.AtMng.PKIDGet("FileXRef", 10);
            row.Rollup = false;
            row.LinkType = (int)FXLinkType.ParentChild;
            row.secBreakInherit = false;
            
        }

        protected override void BeforeChange(DataColumn dc, DataRow dr)
        {
            atriumDB.FileXRefRow row = (atriumDB.FileXRefRow)dr;
            switch (dc.ColumnName)
            {
                case "FileId":
                case "OtherFileId":
                    if (!row.IsNull("FileId") && !row.IsNull("OtherFileId") && !row.IsNull("LinkType"))
                    {
                        if (myA.DB.FileXRef.Select("Fileid=" + row.FileId.ToString() + " and linktype="+row.LinkType.ToString() +" and OTherFileid=" + row.OtherFileId.ToString()).Length > 1)
                        {
                            if(row.LinkType == (int)FXLinkType.ParentChild)
                                throw new AtriumException("A problem has occurred.\n\nYou cannot create a duplicate child file.");
                            else if (row.LinkType == (int)FXLinkType.Shortcut)
                            {
                                string DuplicateShortcut="";
                                foreach (atriumDB.FileXRefRow fxref in myA.DB.FileXRef.Select("Fileid=" + row.FileId.ToString() + " and linktype=" + row.LinkType.ToString() + " and OTherFileid=" + row.OtherFileId.ToString()))
                                {
                                    if (fxref.Id != row.Id)
                                        DuplicateShortcut = fxref.Name;
                                }                                    
                                throw new AtriumException("There is already a shortcut to this file called "+DuplicateShortcut+".\n\nYou can not create a duplicate shortcut to the same file in the same folder.");
                            }
                            else if (row.LinkType == (int)FXLinkType.XRef)
                                throw new AtriumException("A cross-reference already exists between the selected files.\n\nYou can not create duplicate cross-references between the same files.");
                        }
                    }
                    break;

            }
        }
        public override bool CanAdd(DataRow parent)
        {
            atriumDB.EFileRow efr = (atriumDB.EFileRow)parent;
            return true;
            
        }
        //private void MyXml(atriumDB.FileXRefRow fxr, System.Xml.XmlDocument xd,bool reverse)
        //{
        //    System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='filexref' and @id=" + fxr.Id.ToString() + "]");
        //    if (xe == null)
        //    {
        //        xe = xd.CreateElement("toc");
        //        xe.SetAttribute("supertype", "filexref");

        //    }
        //    xe.SetAttribute("type", "filexref");

        //    xe.SetAttribute("id", fxr.Id.ToString());

        //    //string ffn = "";
        //    atriumDB.EFileRow er;
        //    if (!reverse)
        //        er = myA.EFile.Load(fxr.OtherFileId, false);
        //    else
        //        er = myA.EFile.Load(fxr.FileId, false);

        //    //ffn =String.Format("{0} [{1}]",er.NameE, er.FullFileNumber );
        //    if (!er.IsNameENull())
        //    {
        //        xe.SetAttribute("titlee", String.Format("{0} [{1}]", er.NameE, er.FullFileNumber));
        //        xe.SetAttribute("titlef", String.Format("{0} [{1}]", er.NameF, er.FullFileNumber));
        //    }
        //    if (xe.ParentNode == null)
        //    {
        //        System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "filexrefs", "File X-refs", "File X-refs",500);
        //        xes.AppendChild(xe);
        //    }
        //}

        //private void TocXml(atriumDB.FileXRefRow fxr, System.Xml.XmlDocument xd, bool reverse)
        //{
        //    System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@supertype='filexref' and @id=" + fxr.Id.ToString() + "]");
        //    if (xe == null)
        //    {
        //        xe = xd.CreateElement("toc");
        //        xe.SetAttribute("supertype", "filexref");

        //    }
        //    xe.SetAttribute("type", "tocxref");

        //    xe.SetAttribute("id", fxr.Id.ToString());

        //    //string ffn = "";
        //    atriumDB.EFileRow er;
        //    if (!reverse)
        //        er = myA.EFile.Load(fxr.OtherFileId, false);
        //    else
        //        er = myA.EFile.Load(fxr.FileId, false);

        //    //ffn =String.Format("{0} [{1}]",er.NameE, er.FullFileNumber );
        //    xe.SetAttribute("titlee", String.Format("{0} [{1}]", er.NameE, er.FullFileNumber));
        //    xe.SetAttribute("titlef", String.Format("{0} [{1}]", er.NameF, er.FullFileNumber));
        //    //xe.SetAttribute("tooltipe", er.NameE);
        //    //xe.SetAttribute("tooltipf", er.NameF);

        //    if (xe.ParentNode == null)
        //    {
        //        System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "tocxrefs", "Sub-files", "Sub-files",600);
        //        xes.AppendChild(xe);
        //    }
        //}
        //public void TocXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        //{
        //    //
        //    atriumDB.FileXRefRow[] fcrs = (atriumDB.FileXRefRow[])myFileXRefDT.Select("LinkType =0 and Fileid=" + efr.FileId.ToString());
        //    foreach (atriumDB.FileXRefRow fcr in fcrs)
        //    {
        //        TocXml(fcr, xd, false);
        //    }
        //}

        //public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        //{
        //    //
        //    //LoadByFileId(efr.FileId);
        //    atriumDB.FileXRefRow[] fcrs = (atriumDB.FileXRefRow[])myFileXRefDT.Select("LinkType <>0 and Fileid=" + efr.FileId.ToString());
        //    foreach (atriumDB.FileXRefRow fcr in fcrs)
        //    {
        //        MyXml(fcr, xd,false);
        //    }

        //    //LinkType =1 and 
        //    //LoadByOtherFileId(efr.FileId);
        //    fcrs = (atriumDB.FileXRefRow[])myFileXRefDT.Select("LinkType =1 and OtherFileid=" + efr.FileId.ToString());
        //    foreach (atriumDB.FileXRefRow fcr in fcrs)
        //    {
        //        MyXml(fcr, xd,true);
        //    }
        //}

        protected override void AfterDelete(DataRow dr)
        {
            UpdateEventArgs e=new UpdateEventArgs();
            e.SavedOK=true;
            e.ChangedRows=new DataRow[] {dr};

            RaiseUpdateEvent(e);
        }
        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.FileXRefRow fxr = (atriumDB.FileXRefRow)dr;

            //System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            //if (fxr.LinkType != (int)FXLinkType.ParentChild)
            //{
            //    //TODO: fix for moves of shortcuts
            //    //if (fxr.EFileRowByEFile_FileXRefChild == null)
            //    //    myA.EFile.Load(fxr.OtherFileId, false);
            //    //xd.InnerXml = fxr.EFileRowByEFile_FileXRefChild.FileStructXml;
                
            //    //MyXml(fxr, xd, false);
            //    //fxr.EFileRowByEFile_FileXRefChild.FileStructXml = xd.InnerXml;

            //    ////////if (fxr.LinkType == (int)FXLinkType.XRef)
            //    ////////{
            //    ////////    MyXml(fxr, xd, true);
            //    ////////    fxr.EFileRowByEFile_FileXRefChild.FileStructXml = xd.InnerXml;

            //    ////////}
            //}
        }


	}
}

