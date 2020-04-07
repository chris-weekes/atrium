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
	public class OpinionBE:atLogic.ObjectBE
	{
		AdvisoryManager myA;
		Advisory.OpinionDataTable myOpinionDT;

        internal OpinionBE(AdvisoryManager pBEMng)
            : base(pBEMng,pBEMng.DB.Opinion)
		{
			myA=pBEMng;
            myOpinionDT = (Advisory.OpinionDataTable)myDT;


            if (!myA.AtMng.AppMan.UseService && myODAL == null)
                myODAL = myA.AtMng.DALMngr.GetOpinion();
        }

        public atriumDAL.OpinionDAL myDAL
        {
            get
            {
                return (atriumDAL.OpinionDAL)myODAL;
            }
        }

		public void LoadByFileId(int fileId)
		{
            if (myA.AtMng.AppMan.UseService)
                Fill(myA.AtMng.AppMan.AtriumX().OpinionLoadByFileId(fileId,myA.AtMng.AppMan.AtriumXCon));
            else
            {
                try
                {
                    Fill(this.myDAL.LoadByFileID(fileId));
                }
                catch (System.Runtime.Serialization.SerializationException x)
                {
                    RecoverDAL();
                    Fill(this.myDAL.LoadByFileID(fileId));
                }
            }
			
		}

		protected override void AfterAdd(DataRow row)
		{
            Advisory.OpinionRow dr = (Advisory.OpinionRow)row;
			string ObjectName = this.myOpinionDT.TableName;

			dr.OpinionId = myA.AtMng.PKIDGet(ObjectName,10);

            dr.FileId = myA.FM.CurrentFileId;
            dr.OpinionTypeId = 1;
            //assume opnion is being create from an email ?
            //through the relbp add method

            //atriumDB.ActivityRow prevac= myA.InitActivityProcess(true).CurrentACE.prevAcRow;
            //if(prevac!=null && !prevac.IsDocIdNull())
            //{
            //    dr.RequestDocId = prevac.DocId;
            //}
			
		}

        protected override void AfterChange(DataColumn dc, DataRow dr)
        {
            Advisory.OpinionRow or = (Advisory.OpinionRow)dr;
            switch (dc.ColumnName)
            {
                case "DueDate":
                //maintain bfdate 
                    myA.FM.GetActivityBF().MaintainBFDate(or.OpinionId, "Opinion", "OPINIONDUEDATE", or.DueDate);
                    break;

                case "ReceivedDate":
                    if (or.IsDueDateNull())
                    {
                        or.DueDate = or.ReceivedDate.AddDays(35);
                        myA.FM.GetActivityBF().MaintainBFDate(or.OpinionId, "Opinion", "OPINIONDUEDATE", or.DueDate);
                    }
                        
                    break;
                //case "CompletedDate":
                //    if (!or.IsCompletedDateNull() && !or.IsDocIdNull())
                //    {
                //        //mark opinion read-only
                //        docDB.DocumentRow odoc = myA.FM.GetDocMng().DB.Document.FindByDocId(or.DocId);
                //        if (odoc == null)
                //            odoc=myA.FM.GetDocMng().GetDocument().Load(or.DocId);

                //        docDB.DocContentRow odcc = myA.FM.GetDocMng().DB.DocContent.FindByDocId(or.DocId);
                //        if (odcc == null)
                //            odcc = myA.FM.GetDocMng().GetDocContent().Load(or.DocId);
                //        if(!odcc.ReadOnly)
                //            odcc.ReadOnly = true;
                //    }
                //    break;
                default:
                    break;
            }
        }
		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
            Advisory.OpinionRow dr = (Advisory.OpinionRow)ddr;
			string ObjectName = this.myOpinionDT.TableName;

			switch(dc.ColumnName)
			{
                case "AssignedToId":
                    //JLL 2018-04-23
                    //commented out lawyer list rule for demo
                    //if (!myA.CheckDomain(dr.AssignedToId,myA.FM.Codes("LawyerList")))
                    //    throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, "Assigned To",dr.Table.TableName,"Lawyer List");
                    break;
                case "RequestDocId":

                    if (dr.IsRequestContactIdNull())
                    {
                        //myA.FM.GetDocMng().GetRecipient().LoadByDocId(dr.RequestDocId);
                        docDB.RecipientRow[] rs = (docDB.RecipientRow[])myA.FM.GetDocMng().DB.Recipient.Select("Type='0' and DocId=" + dr.RequestDocId.ToString());
                        if (rs.Length == 1 && rs[0].Address != rs[0].Name)
                        {

                            atriumDB.FileContactRow fcr = myA.FM.GetDocMng().GetRecipient().AddRecipToFile(rs[0], false, "FCC");
                            if (!fcr.IsOfficeIdNull())
                                dr.RequestOfficeId = fcr.OfficeId;

                            dr.RequestContactId = fcr.ContactId;

                        }
                    }
                    break;
				case "ReceivedDate":
                    if (dr.IsReceivedDateNull())
                        throw new RequiredException(Resources.OpinionReceivedDate);
					//if(dr.EFileRow.IsOpenedDateNull())
					//	this.myA.RaiseError(AtriumEnum.AppErrorCodes.RelatedDateRequired, myA.GetLabelLeft(ObjectName, dc.ColumnName), myA.GetLabelLeft("Efile", "ReceivedByJusticeDate"));
					myA.IsValidDate(Resources.OpinionReceivedDate, dr.ReceivedDate, false, DateTime.MinValue, DateTime.Today,  Resources.ValidationTheBeginning, Resources.ValidationToday);
					break;
				case "RequestDate":
                    if (dr.IsRequestDateNull())
                        throw new RequiredException(Resources.OpinionRequestDate);
					myA.IsValidDate(Resources.OpinionRequestDate, dr.RequestDate, false, DateTime.MinValue, DateTime.Today, Resources.ValidationTheBeginning ,Resources.ValidationToday);
					break;
				case "AssignedDate":
					if(!dr.IsAssignedDateNull())
					{
						if (dr.IsRequestDateNull())
							throw new RelatedException(Resources.OpinionAssignedDate,Resources.OpinionRequestDate);
						myA.IsValidDate(Resources.OpinionAssignedDate, dr.AssignedDate, true, dr.RequestDate, DateTime.Today, Resources.OpinionRequestDate,Resources.ValidationToday);
					}
					break;
				case "DueDate":
					if(!dr.IsDueDateNull())
					{
                        if (dr.IsAssignedDateNull())
                            throw new RelatedException(Resources.OpinionDueDate, Resources.OpinionAssignedDate);
						myA.IsValidDate(Resources.OpinionDueDate, dr.DueDate, true, dr.AssignedDate, DateTime.Today.AddMonths(6), Resources.OpinionAssignedDate, Resources.ValidationSixMonthsFromNow);
					}
					break;
				case "CompletedDate":
					if(!dr.IsCompletedDateNull())
					{
                        if (dr.IsAssignedDateNull())
                            throw new RelatedException(Resources.OpinionCompletedDate, Resources.OpinionAssignedDate);
                        myA.IsValidDate(Resources.OpinionCompletedDate, dr.CompletedDate, true, dr.AssignedDate, DateTime.Today, Resources.OpinionAssignedDate, Resources.ValidationToday);
					}
					break;
				case "Subject":
				//case "Number":
                    if (dr.IsNull(dc))
                        throw new RequiredException(Resources.ResourceManager.GetString(ObjectName + dc.ColumnName));
					break;
                case "OpinionTypeId":
                    if (!myA.CheckDomain(dr.OpinionTypeId, myA.FM.Codes("OpinionType")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Opinion Type");
                    break;
				default:
					break;
			}
		}

		protected override void BeforeUpdate(DataRow dr)
		{
			this.BeforeChange(dr.Table.Columns["Subject"], dr);
			this.BeforeChange(dr.Table.Columns["RequestDate"],dr);
			this.BeforeChange(dr.Table.Columns["Number"],dr);

            Advisory.OpinionRow or = (Advisory.OpinionRow)dr;

          

            if (!or.IsCompletedDateNull() && !or.IsDocIdNull())
            {
                //mark opinion read-only
                docDB.DocumentRow odoc = myA.FM.GetDocMng().DB.Document.FindByDocId(or.DocId);
                if (odoc == null)
                    odoc = myA.FM.GetDocMng().GetDocument().Load(or.DocId);

                // 2013-06-12 JLL: update to use isDraft only
                odoc.IsDraft = false;
                
                //docDB.DocContentRow odcc = myA.FM.GetDocMng().DB.DocContent.FindByDocId(or.DocId);
                //if (odcc == null)
                //    odcc = myA.FM.GetDocMng().GetDocContent().Load(or.DocId);
                //if (!odcc.ReadOnly)
                //    odcc.ReadOnly = true;
            }

		}

        //public override DataRow[] GetParentRow()
        //{
        //    return new DataRow[]{this.myA.FM.CurrentFile};
        //}

        protected override void AfterUpdate(DataRow dr)
        {
            Advisory.OpinionRow fcr = (Advisory.OpinionRow)dr;
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();

            xd.InnerXml =myA.FM.CurrentFile.FileStructXml;
            MyXml(fcr, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
        }
        private void MyXml(Advisory.OpinionRow r, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='opinion' and @id=" + r.OpinionId.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "opinion");
            }
            xe.SetAttribute("id", r.OpinionId.ToString());

            //if(! r.IsOfficerCodeNull())
            //    xe.SetAttribute("assignedtocode",r.OfficerCode.ToString());

            string title = "";
            if (!r.IsNumberNull())
                title = r.Number.ToString();

            if (!r.IsCompletedDateNull())
            {
                title += "(" + atriumRes.OpinionCompletedDate + ": " + r.CompletedDate.ToString("yyyy/MM/dd") + ")";
            }
            else if (!r.IsRequestDateNull())
            {
                title += atriumRes.OpinionRequestDate + ": " + r.RequestDate.ToString("yyyy/MM/dd") ;

            }

            xe.SetAttribute("titlee", title);
            xe.SetAttribute("titlef", title);
            if (xe.ParentNode == null)
            {
                System.Xml.XmlElement xes = EFileBE.XmlAddFld(xd, "opinions", "Opinions", "Opinions", 150);
                xes.AppendChild(xe);
            }


        }

		public  void MyXml(atriumDB.EFileRow efr,System.Xml.XmlDocument xd)
		{
			foreach(Advisory.OpinionRow r in myOpinionDT)
			{
                MyXml(r, xd);
            }
			
        }
		public override DataRow[] GetCurrentRow()
		{
			if(this.myOpinionDT.Rows.Count==0)
				this.LoadByFileId(myA.FM.CurrentFile.FileId);

            if (myOpinionDT.Rows.Count == 1)
                return myOpinionDT.Select();
            else
			    return this.myOpinionDT.Select("CompletedDate is null");

		}

		public override string PromptColumnName()
		{
			return "Number,RequestDate";
		}

		public override string FriendlyName()
		{
			return Resources.Opinion;
		}

		public override string PromptFormat()
		{
			return Resources.OpinionPF;
		}


	}
}

