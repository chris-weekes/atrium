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
	public class PropertyBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.PropertyDataTable myPropertyDT;
		
		internal PropertyBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Property)
		{
			myA=pBEMng;
			myPropertyDT=(CLAS.PropertyDataTable)myDT;

			this.myPropertyDT.EstimatedValueofPropertyColumn.ExtendedProperties.Add("format","C");
			this.myPropertyDT.AmountofMortgageColumn.ExtendedProperties.Add("format","C");
        }
        public atriumDAL.PropertyDAL myDAL
        {
            get
            {
                return (atriumDAL.PropertyDAL)myODAL;
            }
        }

		
		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myPropertyDT.TableName;
			CLAS.PropertyRow dr=(CLAS.PropertyRow)ddr;
			switch(dc.ColumnName)
			{
				case "NatureofPropertyCode":
                    if (dr.IsNatureofPropertyCodeNull())
                        throw new RequiredException(Resources.PropertyNatureofPropertyCode);
                    break;
				case "LegalDescription":
                    if (dr.RealProperty)
                        if (dr.IsLegalDescriptionNull())
                            throw new RequiredException(Resources.PropertyLegalDescription);
					break;
				default:
					break;
			}
		}
		protected override void BeforeUpdate(DataRow row) 
		{
			CLAS.PropertyRow dr = (CLAS.PropertyRow) row;
			this.BeforeChange(dr.Table.Columns["NatureofPropertyCode"],dr);
			this.BeforeChange(dr.Table.Columns["LegalDescription"],dr);
		}

		protected override void AfterAdd(DataRow row)
		{
			CLAS.PropertyRow dr=(CLAS.PropertyRow)row;
			string ObjectName = this.myPropertyDT.TableName;

            dr.PropertyID = this.myA.AtMng.PKIDGet(ObjectName,1);
            //dr.FileID = dr.WritRow.FileID;
            dr.FileID=this.myA.FM.CurrentFile.FileId;
		}


		protected override void AfterChange(DataColumn dc,DataRow ddr)
		{
			
			string ObjectName = this.myPropertyDT.TableName;

			CLAS.PropertyRow dr=(CLAS.PropertyRow)ddr;


			switch(dc.ColumnName)
			{

				case "RealProperty":
					break;
				case "NatureofPropertyCode":
					if (dr.RealProperty && dr.NatureofPropertyCode=="PR")
					{
                        atriumDB.FileContactRow fcr = (atriumDB.FileContactRow)this.myA.FM.DB.FileContact.Select("FileId=" + myA.FM.CurrentFile.FileId + " and ContactType='DB'")[0];
						dr.AddressID = fcr.ContactRow.AddressCurrentID;
					}
                    dr.EndEdit();
                    break;
				default:
					break;
			}
		}

		protected override void BeforeDelete(DataRow row) 
		{
			CLAS.PropertyRow dr = (CLAS.PropertyRow) row;
			string ObjectName = this.myPropertyDT.TableName;
			this.myA.FM.GetActivity().DeleteRelatedCA(dr.FileID, ObjectName, dr.PropertyID);
		}

        protected override void AfterUpdate(DataRow dr)
        {
            CLAS.PropertyRow r = (CLAS.PropertyRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }
        private void MyXml(CLAS.PropertyRow pr, System.Xml.XmlDocument xd)
        {

            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='acs-104412' and @id=" + pr.PropertyID.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "acs-104412");
                xe.SetAttribute("supertype", "writ");
            }
            xe.SetAttribute("id", pr.PropertyID.ToString());
            //xe.SetAttribute("writid", pr.WritID.ToString());
            //xe.SetAttribute("officeid",wr.OfficeID.ToString());
            xe.SetAttribute("tooltipe", pr.NatureofPropertyCode.ToString());
            if (!pr.IsExecutedAgainstDateNull())
            {
                xe.SetAttribute("titlee", pr.ExecutedAgainstDate.ToString("yyyy/MM/dd"));
                xe.SetAttribute("titlef", pr.ExecutedAgainstDate.ToString("yyyy/MM/dd"));
            }

            if (xe.ParentNode == null)
            {
                System.Xml.XmlNode xeWrit = xd.SelectSingleNode("//toc[@type='writ' and @id=" + pr.WritID.ToString() + "]");
                System.Xml.XmlElement xes = (System.Xml.XmlElement)xeWrit.SelectSingleNode("fld[@type='property']");
                if (xes == null)
                {
                    xes = xd.CreateElement("fld");
                    xes.SetAttribute("type", "property");
                    xes.SetAttribute("supertype", "writ");
                    xes.SetAttribute("titlee", "Property");
                    xes.SetAttribute("titlef", "Propriété");
                    xeWrit.AppendChild(xes);
                }
                xes.AppendChild(xe);
            }


        }
		internal void MyXml(CLAS.WritRow wr,System.Xml.XmlDocument xd)
		{
			//get Property xml
			foreach(CLAS.PropertyRow pr in wr.GetPropertyRows())
			{
                MyXml(pr, xd);

			}

		}
	}
}

