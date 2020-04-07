using System;
using System.Data;
using atLogic;
using lmDatasets;
using atriumBE.Properties;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class CostBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.CostDataTable myCostDT;
		
			
		internal CostBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Cost)
		{
			myA=pBEMng;
			myCostDT=(CLAS.CostDataTable)myDT;

			this.myCostDT.CostAmountColumn.ExtendedProperties.Add("format","C");
            this.myCostDT.InterestRateColumn.ExtendedProperties.Add("format", "#0.0#\\%");

        }
        public atriumDAL.CostDAL myDAL
        {
            get
            {
                return (atriumDAL.CostDAL)myODAL;
            }
        }


		protected override void AfterAdd(DataRow row)
		{
			CLAS.CostRow dr=(CLAS.CostRow)row;
			string ObjectName = this.myCostDT.TableName;

			dr.CostID= this.myA.AtMng.PKIDGet(ObjectName,1);
            dr.FileID = dr.JudgmentRow.FileID;// this.myA.FM.CurrentFile.FileId;
			dr.CostDate=DateTime.Today;
            dr.Recoverable = true;
            dr.CostType = "1";

		}

		protected  override void BeforeUpdate(DataRow ddr)
		{
			CLAS.CostRow dr=(CLAS.CostRow)ddr;
			this.BeforeChange(CostFields.CostAmount,dr);
			this.BeforeChange(CostFields.CostDate,dr);
			this.BeforeChange(CostFields.InterestRate,dr);
			this.BeforeChange(CostFields.PostJudgmentActivityCode,dr);
			this.BeforeChange(CostFields.RateType,dr);

			


		}

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.CostRow or = (CLAS.CostRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.Cost);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.CostRow fo = (CLAS.CostRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.Cost);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			CLAS.CostRow dr=(CLAS.CostRow)ddr;
			switch(dc.ColumnName)
			{
				case CostFields.CostAmount:
					if(dr.IsCostAmountNull() || dr.CostAmount<=0)
						throw new AtriumException(Resources.MustBeGreaterThanZero,Resources.CostCostAmount);
					break;
				case CostFields.RateType:
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.ResourceManager.GetString("Cost" + dc.ColumnName));
                    else if (!myA.CheckDomain(dr.RateType, myA.FM.Codes("InterestRateType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Interest Rate Type");
                    break;
				case CostFields.InterestRate:
				case CostFields.CostDate:
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.ResourceManager.GetString("Cost" + dc.ColumnName));
                    break;
				case CostFields.PostJudgmentActivityCode:
					if(dr.IsNull(dc))
						throw new RequiredException(Resources.ResourceManager.GetString("Cost"+dc.ColumnName));
                    else if (!myA.CheckDomain(dr.PostJudgmentActivityCode, myA.FM.Codes("PostJudgmentActivity")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Post Judgment Activity Type");
					break;
				default:
					break;
			}
		}


		public override DataRow[] GetCurrentRow()
		{
		
			return this.myA.DB.Cost.Select();
		
		}

		public override string BestFKName()
		{
			return CostFields.JudgmentID;
		}
        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.CostRow r = (CLAS.CostRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        private void MyXml(CLAS.CostRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='cost' and @id=" + r.CostID.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "cost");

            }
            xe.SetAttribute("id", r.CostID.ToString());
            //xe.SetAttribute("judgmentid", wr.JudgmentID.ToString());
            //xe.SetAttribute("officeid",wr.OfficeID.ToString());
            //xe.SetAttribute("postjudgmentactivitycode", wr.PostJudgmentActivityCode.ToString());
            string costdate = "[Cost Date Missing]";
            string costamount = "";

            if (!r.IsCostDateNull())
                costdate=r.CostDate.ToString("yyyy/MM/dd");

            if (!r.IsCostAmountNull())
            {
                costamount= r.CostAmount.ToString("C");
            }
            xe.SetAttribute("titlee", costdate + " - " + costamount);
            xe.SetAttribute("titlef", costdate + " - " + costamount);

            if (!r.IsPostJudgmentActivityCodeNull())
            {
                //JLL Yuck ... should move desc to view/dataset
                DataRow[] dr = myA.FM.Codes("PostJudgmentActivity").Select("PostJudgmentActivityCode='"+r.PostJudgmentActivityCode+"'", "");
                if (dr.Length == 1)
                {
                    xe.SetAttribute("tooltipe", dr[0]["PostJudgmentActivityDescEng"].ToString());
                    xe.SetAttribute("tooltipf", dr[0]["PostJudgmentActivityDescFre"].ToString());
                }
            }

            if (xe.ParentNode == null)
            {
                System.Xml.XmlNode xeJudg=xd.SelectSingleNode("//toc[@type='judgment' and @id="+r.JudgmentID.ToString()+"]");
                System.Xml.XmlElement xes =(System.Xml.XmlElement) xeJudg.SelectSingleNode("fld[@type='costs']");
                if (xes == null)
                {
                    xes = xeJudg.OwnerDocument.CreateElement("fld");
                    xes.SetAttribute("type", "costs");
                    xes.SetAttribute("titlee", "Costs");
                    xes.SetAttribute("titlef", "Coûts");
                    xeJudg.AppendChild(xes);
                }
                xes.AppendChild(xe);
            }



        }
        internal void MyXml(CLAS.JudgmentRow jr, System.Xml.XmlDocument xd)
		{
			//get Cost xml
			foreach(CLAS.CostRow r in jr.GetCostRows())
			{
                MyXml(r, xd);

			}

		}


	}
}

