using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class HardshipBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.HardshipDataTable myHardshipDT;
	 
		
		internal HardshipBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Hardship)
		{
			myA=pBEMng;
			myHardshipDT=(CLAS.HardshipDataTable)myDT;
	
		}
        
        public atriumDAL.HardshipDAL myDAL
        {
            get
            {
                return (atriumDAL.HardshipDAL)myODAL;
            }
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.HardshipRow or = (CLAS.HardshipRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.FileId, atSecurity.SecurityManager.Features.Hardship);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.HardshipRow fo = (CLAS.HardshipRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.FileId, atSecurity.SecurityManager.Features.Hardship);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        protected override void AfterAdd(DataRow dr)
        {
            CLAS.HardshipRow myRow = (CLAS.HardshipRow)dr;
            string ObjectName = this.myDT.TableName;

            myRow.HardshipId = this.myA.AtMng.PKIDGet(ObjectName, 1);
            myRow.FileId = myA.FM.CurrentFileId;
            myRow.Recovery = false;
            myRow.Setoff = false;
            myRow.RequestDate = DateTime.Today;
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.HardshipRow myRow = (CLAS.HardshipRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(myRow, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;

        }

        private void MyXml(CLAS.HardshipRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='hardship' and @id=" + r.HardshipId.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "hardship");
                xe.SetAttribute("supertype", "bankruptcy");
            }
            xe.SetAttribute("id", r.HardshipId.ToString());

            string title =  r.RequestDate.ToString("yyyy/MM/dd");
            xe.SetAttribute("titlee", title);
            xe.SetAttribute("titlef", title);
         

            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "hardship", "Hardships", "Hardships", 240);
                xes.AppendChild(xe);
            }

        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
            foreach (CLAS.HardshipRow r in myHardshipDT)
            {
                MyXml(r, xd);

            }



        }
        protected override void BeforeUpdate(DataRow dr)
        {
            this.BeforeChange(dr.Table.Columns["RequestDate"], dr);

        }
        protected override void BeforeChange(DataColumn dc, DataRow ddr)
        {
            CLAS.HardshipRow myRow = (CLAS.HardshipRow)ddr;
            switch (dc.ColumnName)
            {
               
                default:
                    break;
            }
        }

        protected override void AfterChange(DataColumn dc, DataRow ddr)
        {


            CLAS.HardshipRow myRow = (CLAS.HardshipRow)ddr;
            switch (dc.ColumnName)
            {
               
                default:
                    break;
            }
        }

        protected override void BeforeDelete(DataRow row)
        {
            CLAS.HardshipRow myRow = (CLAS.HardshipRow)row;
            string ObjectName = this.myDT.TableName;
            this.myA.FM.GetActivity().DeleteRelatedCA(myRow.FileId, ObjectName, myRow.HardshipId);
        }

     

        public override DataRow[] GetCurrentRow()
        {
           
                return this.myDT.Select();
        }

        public override string PromptColumnName()
        {
            return "RequestDate"; ;
        }

        public override string PromptFormat()
        {
            return "{0}";
        }

        public override string FriendlyName()
        {
            return "Hardship";
        }

	}
}

