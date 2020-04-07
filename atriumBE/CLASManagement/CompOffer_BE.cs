using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class CompOfferBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.CompOfferDataTable myCompOfferDT;
	       
		
		internal CompOfferBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.CompOffer)
		{
			myA=pBEMng;
			myCompOfferDT=(CLAS.CompOfferDataTable)myDT;

        }
        public atriumDAL.CompOfferDAL myDAL
        {
            get
            {
                return (atriumDAL.CompOfferDAL)myODAL;
            }
        }


        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[] { this.myA.FM.CurrentFile };
        //}


        public override DataRow[] GetCurrentRow()
        {
            //this.LoadByFileID(this.myA.FM.CurrentFile.FileId);

            if (this.myCompOfferDT.Rows.Count == 1)
            {
              //  this.myA.GetCompOfferDetail().LoadByCompOfferId(this.myCompOfferDT[0].CompOfferId);
                return this.myCompOfferDT.Select();
            }
            else
                return this.myCompOfferDT.Select("Active=1");
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.CompOfferRow or = (CLAS.CompOfferRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.FileID, atSecurity.SecurityManager.Features.CompOffer);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.CompOfferRow fo = (CLAS.CompOfferRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.FileID, atSecurity.SecurityManager.Features.CompOffer);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        protected override void AfterAdd(DataRow row)
        {
            CLAS.CompOfferRow dr =(CLAS.CompOfferRow) row;

            dr.CompOfferId = this.myA.AtMng.PKIDGet("CompOffer", 1);
            dr.FileID = myA.FM.CurrentFileId;
            dr.OfficeId = myA.FM.CurrentFile.LeadOfficeId;
            dr.Active = true;

            //jll: can only be one active CompOffer
            // This fails to save when creating subsequent compoffer records
            // as i believe multiple getcurrentrow calls in related fields
            // code causes the update active flags on comp offer records to get reloaded
            foreach (CLAS.CompOfferRow cdr in myCompOfferDT)
            {
                if(cdr.CompOfferId!=dr.CompOfferId)
                    cdr.Active = false;
            }   
        }

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.CompOfferRow r = (CLAS.CompOfferRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }

        private void MyXml(CLAS.CompOfferRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='compoffer' and @id=" + r.CompOfferId.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "compoffer");
            }
            xe.SetAttribute("id", r.CompOfferId.ToString());

            CLAS.CompOfferDetailRow cor = myA.DB.CompOfferDetail.FindByCompOfferDetailId(r.CurrentOfferId);
            string title = "";
            if (r.Active)
                title= cor.CompOfferDate.ToString("yyyy/MM/dd") + ": " + cor.CompOfferAmount.ToString("C");
            else
            {
                if (!r.IsTermsDefaultedDateNull())
                    title= "Terms Defaulted: " + r.TermsDefaultedDate.ToString("yyyy/MM/dd");
                else if (!r.IsTermsFulfilledDateNull())
                    title= "Terms Fulfilled: " + r.TermsFulfilledDate.ToString("yyyy/MM/dd");
                else
                    title= cor.CompOfferDate.ToString("yyyy/MM/dd") + ": Inactive";
            }
            xe.SetAttribute("titlee", title);
            xe.SetAttribute("titlef", title);

            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "compoffer", "Compromise Offers", "Offres de règlement", 229);
                xes.AppendChild(xe);
            }


        }
        public void MyXml(atriumDB.EFileRow efr, System.Xml.XmlDocument xd)
        {
            foreach (CLAS.CompOfferRow r in myCompOfferDT)
            {
                MyXml(r, xd);

            }
        }
        
	}
}

