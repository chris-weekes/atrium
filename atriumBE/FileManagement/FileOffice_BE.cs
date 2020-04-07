using System;
using System.Data;
using atLogic;
using lmDatasets;


namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class FileOfficeBE:atLogic.ObjectBE
	{
		FileManager myA;
		atriumDB.FileOfficeDataTable myFileOfficeDT;
		
		internal FileOfficeBE(FileManager pBEMng):base(pBEMng,pBEMng.DB.FileOffice)
		{
			myA=pBEMng;
			myFileOfficeDT=(atriumDB.FileOfficeDataTable)myDT;
            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetFileOffice();
        }
        public atriumDAL.FileOfficeDAL myDAL
        {
            get
            {
                return (atriumDAL.FileOfficeDAL)myODAL;
            }
        }


		

		
                
        protected override void AfterUpdate(DataRow dr)
        {
            atriumDB.FileOfficeRow r = (atriumDB.FileOfficeRow)dr;

            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = r.EFileRow.FileStructXml;
            MyXml(r, xd);
            r.EFileRow.FileStructXml = xd.InnerXml;
            //myA.EFile.Update();
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            atriumDB.FileOfficeRow or = (atriumDB.FileOfficeRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(or.FileId, atSecurity.SecurityManager.Features.fileOffice);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            atriumDB.FileOfficeRow fo = (atriumDB.FileOfficeRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(fo.FileId, atSecurity.SecurityManager.Features.fileOffice);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        private void MyXml(atriumDB.FileOfficeRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='fileoffice' and @id=" + r.FileOfficeId.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "fileoffice");
            }
            xe.SetAttribute("id", r.FileOfficeId.ToString());
            xe.SetAttribute("officeid", r.OfficeId.ToString());


            string titlee = r.OfficeCode + " - " + r.OfficeName;
            string titlef = r.OfficeCode + " - " + r.OfficeNameFre;
           
            if (!r.IsOfficeFileNumNull())
            {
                titlee += " (" + r.OfficeFileNum + ")";
                titlef += " (" + r.OfficeFileNum + ")";
            }
            xe.SetAttribute("titlee", titlee);
            xe.SetAttribute("titlef", titlef);

            string tooltipe = "";
            string tooltipf = "";

            if (r.IsClient)
            {
                tooltipe = "Client Office";
                tooltipf = "Bureau client";
            }
            else if (r.IsLead)
            {
                tooltipe = "Lead Office";
                tooltipf = "Bureau responsable";
            }
            else if (r.IsOwner)
            {
                tooltipe = "Owner Office";
                tooltipf = "Bureau propriétaire du dossier";
            }

            //xe.SetAttribute("icon", "28"); //office icon

            xe.SetAttribute("tooltipe", tooltipe);
            xe.SetAttribute("tooltipf", tooltipf);

            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "basecontacts", "Contacts", "Contacts", 210);
                //System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "fileoffice", "Offices", "Bureaux",320);
                xes.AppendChild(xe);
            }


        }
		public  void MyXml(atriumDB.EFileRow efr,System.Xml.XmlDocument xd)
		{
			foreach(atriumDB.FileOfficeRow r in efr.GetFileOfficeRows())
			{
                MyXml(r, xd);
            }
			


		}

		protected  override void AfterChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myFileOfficeDT.TableName;
			atriumDB.FileOfficeRow dr=(atriumDB.FileOfficeRow)ddr;
			switch(dc.ColumnName)
			{
				default:
					break;
			}
		}



		protected override void AfterAdd(DataRow row)
		{
			atriumDB.FileOfficeRow dr = (atriumDB.FileOfficeRow) row;
			string ObjectName = this.myFileOfficeDT.TableName;

			dr.FileOfficeId = this.myA.AtMng.PKIDGet(ObjectName,10);
			//dr.StartDate = DateTime.Today;
            dr.IsClient = false;
            dr.IsLead = false;
            dr.IsOwner = false;
            dr.IsAgent = false;
            dr.IsPrimary = false;
            dr.PercentAlloc = 0;
            
			// dr.accesType = "OF"

            ////need to assign office based on debtor address
            //if (!dr.EFileRow.IsOpponentIDNull())
            //{
            //    object tempid = this.myA..AppMan.ExecuteScalar("AssignOfficeByCity", dr.FileId, dr.EFileRow.OpponentID);
            //    if (tempid == System.DBNull.Value)
            //        dr.OfficeId = this.myA.AtMng.OfficeLoggedOn.OfficeId;
            //    else
            //        dr.OfficeId = System.Convert.ToInt32(tempid);
            //}

		}


		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			atriumDB.FileOfficeRow dr=(atriumDB.FileOfficeRow)ddr;
			switch(dc.ColumnName)
			{
				case "OfficeId":
					if (dr.RowState!= DataRowState.Added && !myA.CheckDomain(dr.OfficeId, myA.Codes("OfficeList")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Office List");
					break;
				default:
					break;
			}
		}

        //public override DataRow[] GetParentRow()
        //{
        //    //this.LoadByFileId(this.myA.CurrentFile.FileId);
        //    return new DataRow[]{this.myA.CurrentFile};
        //}

		public override DataRow[] GetCurrentRow()
		{
			//this.LoadByFileId(this.myA.CurrentFile.FileId);
			if( this.myA.AtMng.OfficeLoggedOn.OfficeId!=this.myA.CurrentFile.OwnerOfficeId)
			{
				return this.myFileOfficeDT.Select("OfficeId="+this.myA.AtMng.OfficeLoggedOn.OfficeId.ToString());
			}
			else
			{
				return this.myFileOfficeDT.Select();
			}
		}

        public override string FriendlyName()
        {
            return "File Office";
        }

        public override string PromptColumnName()
		{
			return "OfficeCode";
		}
        protected override void BeforeDelete(DataRow dr)
        {
            atriumDB.FileOfficeRow fcr = (atriumDB.FileOfficeRow)dr;
         
                System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                xd.InnerXml = fcr.EFileRow.FileStructXml;
                System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='fileoffice' and @id=" + fcr.FileOfficeId.ToString() + "]");
                if (xe != null && xe.ParentNode != null )
                {
                    System.Xml.XmlElement parentNode = (System.Xml.XmlElement)xe.ParentNode;
                    System.Xml.XmlNode removedNode = xe.ParentNode.RemoveChild(xe);
               
                }
                fcr.EFileRow.FileStructXml = xd.InnerXml;
          
        }

		protected override void BeforeUpdate(DataRow row)
		{
			atriumDB.FileOfficeRow dr=(atriumDB.FileOfficeRow)row;

			//if the office already exisits do not add it

			if(this.myA.DB.FileOffice.Select("Fileid="+dr.FileId.ToString() +" and officeid="+dr.OfficeId.ToString()).Length>1)
				throw new AtriumException(atriumBE.Properties.Resources.DuplicateFileOfficeNumber);

            //need to make sure all rows are loaded for this to work
            //don't load the rows here!!!!!!!!!
            decimal totPrcnt = 0;
            foreach (atriumDB.FileOfficeRow fr in dr.EFileRow.GetFileOfficeRows())
            {
                if (fr.IsClient)
                    totPrcnt += fr.PercentAlloc;
            }
            if(totPrcnt!=0 && totPrcnt !=100)
                throw new AtriumException("Percent Allocation must add up to 100%");
 
            //if another LO exists and has open accounts then do not allow the LO to change
			//if the office already exisits do not add it
//			bool found=false;
//			foreach(atriumDB.FileOfficeRow fr in dr.EFileRow.GetFileOfficeRows())
//			{
//				if(fr.OfficeId==dr.OfficeId)
//				{
//					fr.BeginEdit();
//					found=true;
//					fr.AccessType="LO";
//					fr.IsLead=true;
//					fr.EndEdit();
//						
//				}
//			}
//			if(!found)
//			{
//				//add file office row
//					
//				atriumDB.FileOfficeRow fr=(atriumDB.FileOfficeRow)this.myA.GetFileOffice().Add(dr.EFileRow);
//				fr.BeginEdit();
//				fr.OfficeId=dr.OfficeId;
//				fr.AccessType="LO";
//				fr.IsLead=true;
//				fr.EndEdit();
//
//
//			}
            if (dr.IsOwner)
            {
                //if (this.myA.IsFieldChanged(dr.Table.Columns["OfficeId"], dr) || this.myA.IsFieldChanged(dr.Table.Columns["AccessType"], dr))
                //{
                    dr.EFileRow.OwnerOfficeId = dr.OfficeId;
                //}
            }
			if ( dr.IsLead )
			{
                //JLL:2017-01-25 only update efile/leadoffice if changing values for officeid or accesstype on fileoffice row; otherwise, skip the update
        		//if(this.myA.IsFieldChanged(dr.Table.Columns["OfficeId"],dr) || this.myA.IsFieldChanged(dr.Table.Columns["AccessType"],dr))
				//{
					dr.EFileRow.LeadOfficeId=dr.OfficeId;
					//this.myA.EFile.AssignOfficer(dr.EFileRow);
					//this.myA.EFile.SyncFileContact(dr.EFileRow,dr.EFileRow.LeadParalegalID,"PL");
				//}
			}

		}

        public atriumDB.FileOfficeRow AddOfficeToFile(int officeId, bool isOwner, bool isLead, bool isClient)
        {
            //load records if required
            //if (this.myA.CurrentFile.GetFileOfficeRows().Length == 0)
            //    this.myA.GetFileOffice().LoadByFileId(this.myA.CurrentFile.FileId);

            //find record for this office
            atriumDB.FileOfficeRow[] ors = (atriumDB.FileOfficeRow[])this.myFileOfficeDT.Select("OfficeId=" + officeId.ToString());
            atriumDB.FileOfficeRow or;
            if (ors.Length == 0)
            {
                or = (atriumDB.FileOfficeRow)this.Add(this.myA.CurrentFile);
                or.OfficeId = officeId;
            }
            else
            {
                or = ors[0];
            }

            //update secfilerule table

            MaintainAccessType(or, isOwner,isLead,isClient);
            return or;
        }



        public void MaintainAccessType(atriumDB.FileOfficeRow orCurrent, bool isOwner,bool isLead,bool isClient)
        {

            if (isLead)
            {
                orCurrent.IsLead = true;
                this.myA.CurrentFile.LeadOfficeId = orCurrent.OfficeId;
            }
            else
            {
                orCurrent.IsLead = false;
            }
            if (isOwner)
            {
                orCurrent.IsOwner = true;
                this.myA.CurrentFile.OwnerOfficeId = orCurrent.OfficeId;
            }

            foreach (atriumDB.FileOfficeRow or in this.myFileOfficeDT.Rows)
            {
                if (or.IsLead  & or.FileOfficeId != orCurrent.FileOfficeId)
                    or.IsLead = false;
            }
        }
	}
}

