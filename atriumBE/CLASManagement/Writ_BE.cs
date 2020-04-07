using System;
using System.Data;
using atLogic;
using lmDatasets;

namespace atriumBE
{
	/// <summary>
	/// 
	/// </summary>
	public class WritBE:atLogic.ObjectBE
	{
		CLASManager myA;
		CLAS.WritDataTable myWritDT;
		
		public bool bEditOnly=false;

		internal WritBE(CLASManager pBEMng):base(pBEMng,pBEMng.DB.Writ)
		{
			myA=pBEMng;
			myWritDT=(CLAS.WritDataTable)myDT;
        }
        public atriumDAL.WritDAL myDAL
        {
            get
            {
                return (atriumDAL.WritDAL)myODAL;
            }
        }

        public override bool CanEdit(DataRow dr)
        {
            bool ok = false;
            CLAS.WritRow or = (CLAS.WritRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanUpdate(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.Writ);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

        public override bool CanDelete(DataRow dr)
        {
            bool ok = false;
            CLAS.WritRow fo = (CLAS.WritRow)dr;
            atSecurity.SecurityManager.LevelPermissions perm = myA.AtMng.SecurityManager.CanDelete(myA.FM.CurrentFileId, atSecurity.SecurityManager.Features.Writ);
            if (perm != atSecurity.SecurityManager.LevelPermissions.No)
                ok = true;

            return ok;
        }

		protected override void AfterAdd(DataRow row)
		{
			CLAS.WritRow dr=(CLAS.WritRow)row;
			string ObjectName = this.myWritDT.TableName;

			dr.WritID = this.myA.AtMng.PKIDGet(ObjectName,1);    
			dr.FileID=this.myA.FM.CurrentFile.FileId;
			dr.IssueRenewalDate=DateTime.Today;
            dr.OfficeID = myA.AtMng.OfficeLoggedOn.OfficeId;
            //dr["OfficeCode"]=dr.JudgmentRow.OfficeCode;
            //dr["JudgmentDate"]=dr.JudgmentRow.JudgmentDate;
            //dr["ActionNumber"]=dr.JudgmentRow.ActionNumber;
		}

		protected override void AfterChange(DataColumn dc, DataRow ddr)
		{
			string ObjectName = this.myWritDT.TableName;

			CLAS.WritRow dr=(CLAS.WritRow)ddr;
			switch(dc.ColumnName)
			{
                case WritFields.ExpiryDate:
                    myA.FM.GetActivityBF().MaintainBFDate(dr.WritID, "Writ", "WRITLPDATE",dr.ExpiryDate);
                    break;

				case "IssueRenewalDate":
					if(!dr.IsOfficeIDNull())
					{
                        if (!this.myA.AtMng.GetOffice(dr.OfficeID).CurrentOffice.IsWritofExecutionLPNull() )
                            dr.ExpiryDate = dr.IssueRenewalDate.AddYears(this.myA.AtMng.GetOffice(dr.OfficeID).CurrentOffice.WritofExecutionLP);
//					else
//						dr.ExpiryDate=dr.IssueRenewalDate.AddYears();
                        myA.FM.GetActivityBF().MaintainBFDate(dr.WritID, "Writ", "WRITLPDATE", dr.ExpiryDate);
                        dr.EndEdit();
                }
					break;
			}
		}

		protected  override void BeforeChange(DataColumn dc,DataRow ddr)
		{
			string ObjectName = this.myWritDT.TableName;

			CLAS.WritRow dr=(CLAS.WritRow)ddr;
			switch(dc.ColumnName)
			{
				case "IssueRenewalDate":
                    if (dr.IsIssueRenewalDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.WritIssueRenewalDate);
					if (dr.JudgmentRow.IsJudgmentDateNull())
                        throw new RelatedException( atriumBE.Properties.Resources.WritIssueRenewalDate, atriumBE.Properties.Resources.JudgmentJudgmentDate);
                    myA.IsValidDate(atriumBE.Properties.Resources.WritIssueRenewalDate, dr.IssueRenewalDate, false, dr.JudgmentRow.JudgmentDate, DateTime.Today, atriumBE.Properties.Resources.JudgmentJudgmentDate, atriumBE.Properties.Resources.ValidationToday);						
					break;
				case "ExpiryDate":
					if (dr.IsExpiryDateNull())
                        throw new RequiredException(atriumBE.Properties.Resources.WritExpiryDate);
                    if (dr.IsIssueRenewalDateNull())
                        throw new RelatedException( atriumBE.Properties.Resources.WritExpiryDate, atriumBE.Properties.Resources.WritIssueRenewalDate);
                    myA.IsValidDate(atriumBE.Properties.Resources.WritExpiryDate, dr.ExpiryDate, false, dr.IssueRenewalDate, DateTime.Today.AddYears(30), atriumBE.Properties.Resources.WritIssueRenewalDate, atriumBE.Properties.Resources.ValidationThirtyYearsLater);						
					break;
				case "ExecutionorRegistrationNumber":
                    if (dr.IsExecutionorRegistrationNumberNull())
                        throw new RequiredException(atriumBE.Properties.Resources.WritExecutionorRegistrationNumber);
					break;
                case "OfficeID":
                    if (dr.IsOfficeIDNull())
                        throw new RequiredException(atriumBE.Properties.Resources.ResourceManager.GetString(ObjectName + dc.ColumnName));
                    else if (!myA.CheckDomain(dr.OfficeID, myA.FM.Codes("officelist")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dc.Table.TableName, "Office List");
                    break;
                case "TypeofWritCode":
                    if (dr.IsTypeofWritCodeNull())
                        throw new RequiredException(atriumBE.Properties.Resources.ResourceManager.GetString(ObjectName + dc.ColumnName));
                    else if (!myA.CheckDomain(dr.TypeofWritCode, myA.FM.Codes("TypeofWrit")))
                        throw new AtriumException(atriumBE.Properties.Resources.BadDomainValue, dc.ColumnName, dr.Table.TableName, "Writ Type");
                    break;
				default:
					break;
			}
		}
		protected override void AfterUpdate(DataRow row)
		{
			CLAS.WritRow r=(CLAS.WritRow)row;
			
            System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
            xd.InnerXml = myA.FM.CurrentFile.FileStructXml;
            MyXml(r, xd);
            myA.FM.CurrentFile.FileStructXml = xd.InnerXml;
        }
        private void MyXml(CLAS.WritRow wr, System.Xml.XmlDocument xd)
        {
            System.Xml.XmlElement xe = (System.Xml.XmlElement)xd.SelectSingleNode("//toc[@type='writ' and @id=" + wr.WritID.ToString() + "]");
            if (xe == null)
            {
                xe = xd.CreateElement("toc");
                xe.SetAttribute("type", "writ");
            }
            xe.SetAttribute("id", wr.WritID.ToString());

            string writtypeEng = "";
            string writtypeFre = "";
            if (!wr.IsTypeofWritCodeNull())
            {
                //JLL Yuck ... should move desc to view/dataset
                DataRow[] dr = myA.FM.Codes("TypeofWrit").Select("TypeofWritCode='" + wr.TypeofWritCode + "'", "");
                if (dr.Length == 1)
                {
                    writtypeEng = dr[0]["TypeofWritDescEng"].ToString();
                    writtypeFre = dr[0]["TypeofWritDescFre"].ToString();
                }
            }

            if (!wr.IsIssueRenewalDateNull())
            {
                xe.SetAttribute("titlee", wr.IssueRenewalDate.ToString("yyyy/MM/dd") + " - " + writtypeEng);
                xe.SetAttribute("titlef", wr.IssueRenewalDate.ToString("yyyy/MM/dd") + " - " + writtypeFre);
            }

            if (!wr.IsSheriffJurisdictionNull())
            {
                xe.SetAttribute("tooltipe", wr.SheriffJurisdiction);
                xe.SetAttribute("tooltipf", wr.SheriffJurisdiction);
            }


            if (xe.ParentNode == null)
            {
                System.Xml.XmlNode xeJudg = xd.SelectSingleNode("//toc[@type='judgment' and @id=" + wr.JudgmentID.ToString() + "]");
                System.Xml.XmlElement xes = (System.Xml.XmlElement)xeJudg.SelectSingleNode("fld[@type='writs']");

                if (xes == null)
                {
                    xes = xeJudg.OwnerDocument.CreateElement("fld");
                    xes.SetAttribute("type", "writs");
                    xes.SetAttribute("titlee", "Encumbrances");
                    xes.SetAttribute("titlef", "Grèvements");
                    xeJudg.AppendChild(xes);
                }
                xes.AppendChild(xe);
            }

		}

		protected override void BeforeUpdate(DataRow row)
		{
			CLAS.WritRow dr = (CLAS.WritRow) row;

			this.BeforeChange(dr.Table.Columns["OfficeID"],dr);
			this.BeforeChange(dr.Table.Columns["IssueRenewalDate"],dr);
			this.BeforeChange(dr.Table.Columns["ExecutionorRegistrationNumber"],dr);

			if (! bEditOnly && dr.HasVersion(DataRowVersion.Original))
			{
				WritHistoryBE wh=this.myA.GetWritHistory();
				CLAS.WritHistoryRow whr=(CLAS.WritHistoryRow)wh.Add(row);

				whr.BeginEdit();
				whr.FileID=dr.FileID;
				whr.ExpiryDate=Convert.ToDateTime(dr["ExpiryDate",DataRowVersion.Original]);
				whr.IssueRenewalDate=Convert.ToDateTime(dr["IssueRenewalDate",DataRowVersion.Original]);
				whr.OfficeID=Convert.ToInt32(dr["OfficeID",DataRowVersion.Original]);
				whr.EndEdit();


			}

			//		Public Sub Save(Optional bEditOnly As Boolean)
			//    On Error GoTo Error_Trap
			//    
			//    Dim nErrNum As Long
			//    Dim sErrDesc As String
			//    Dim bWHGen As Boolean
			//    
			//    With moDataMan
			//        If mbDirty Then
			//            Validate csAgentID
			//            Validate csIssueRenewalDate
			//            Validate csExecutionorRegistrationNumber
			//            
			//            .BeginTrans
			//            
			//            If Not bEditOnly Then
			//                bWHGen = CAGen()
			//            End If
			//            
			//            .UpdateRecord mrst
			//            UpdateXMLToc
			//            
			//            If bWHGen Then
			//                WHGen
			//            End If
			//            WHValuesCache
			//            
			//            .CommitTrans
			//        Else
			//            If Not (mrst.EOF Or mrst.BOF) Then mrst.CancelUpdate
			//        End If
			//    End With
			//    
			//    mbDirty = False
			//    
			//    Exit Sub
			//    
			//Error_Trap:
			//    nErrNum = Err.Number
			//    sErrDesc = Err.Description
			//    GetCLASMate(Me).ErrMessage = Err.Description
			//    moDataMan.RollbackTrans
			//    Select Case nErrNum
			//        Case secInvalidDataType
			//            Err.Raise secInvalidDataType, csObjectName & csSave, sErrDesc
			//        Case Else
			//            Err.Raise nErrNum, csObjectName & csSave, sErrDesc
			//    End Select
			//    
			//End Sub


		}

		internal void MyXml(CLAS.JudgmentRow jr,System.Xml.XmlDocument xd)
		{
			//get writ xml

			PropertyBE pbe=this.myA.GetProperty();

			foreach(CLAS.WritRow wr in jr.GetWritRows())
			{
                MyXml(wr, xd);
				pbe.MyXml(wr,xd);


			}

		}



      

		public override DataRow[] GetCurrentRow()
		{
          
            return this.myA.DB.Writ.Select();
		}

		public override string PromptColumnName()
		{
			return "IssueRenewalDate,ExecutionorRegistrationNumber";
		}

	}
}

