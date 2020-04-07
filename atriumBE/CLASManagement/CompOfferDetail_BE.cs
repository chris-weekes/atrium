using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class CompOfferDetailBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.CompOfferDetailDataTable myCompOfferDetailDT;
		
		internal CompOfferDetailBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.CompOfferDetail)
		{
			myA=pBEMng;
			myCompOfferDetailDT=(CLAS.CompOfferDetailDataTable)myDT;

		}
        public atriumDAL.CompOfferDetailDAL  myDAL
        {
            get
            {
                return (atriumDAL.CompOfferDetailDAL)myODAL;
            }
        }

        public override DataRow[] GetCurrentRow()
        {
            ////DataRow[] dr = base.GetCurrentRow();
            ////if (dr == null)
            ////{
            //CLAS.CompOfferRow jr = (CLAS.CompOfferRow)this.GetParentRow()[0];
            //this.LoadByCompOfferId(jr.CompOfferId);
            ////}
            //return this.myCompOfferDetailDT.Select("CompOfferDetailId=" + jr.CurrentOfferId);
            return this.myCompOfferDetailDT.Select();
        }

        protected override void AfterAdd(DataRow row)
        {
            CLAS.CompOfferDetailRow dr = (CLAS.CompOfferDetailRow)row;

            dr.CompOfferDetailId = this.myA.AtMng.PKIDGet("CompOfferDetail", 1);
            dr.FileId = myA.FM.CurrentFileId;
            dr.CompOfferAmount = 0;
            dr.InitiatedByDebtor = false;
            dr.LumpSum = false;

            //jll: update current compofferdetail to reflect it is refused/rejected.
            //jll: updating current offer id on parent compoffer row
            CLAS.CompOfferRow cor = (CLAS.CompOfferRow)myA.GetCompOffer().GetCurrentRow()[0];
            if (myCompOfferDetailDT.Count > 1)
            {
                CLAS.CompOfferDetailRow[] codr = (CLAS.CompOfferDetailRow[])myCompOfferDetailDT.Select("CompOfferDetailId=" + cor.CurrentOfferId);
                if (codr[0] != null)
                {
                    codr[0].RefusedDate = DateTime.Today; 
                }
            }
            cor.CurrentOfferId = dr.CompOfferDetailId;
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.CompOfferDetailRow or = (CLAS.CompOfferDetailRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.CompOfferRow.FileID, atSecurity.SecurityManager.Features.CompOfferDetail);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.CompOfferDetailRow fo = (CLAS.CompOfferDetailRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.CompOfferRow.FileID, atSecurity.SecurityManager.Features.CompOfferDetail);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }
	}
}

