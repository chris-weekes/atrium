using System;
using System.Data;
using atLogic;
using lmDatasets;
using System.Collections.Generic;
using System.Linq;

namespace atriumBE
{
    /// <summary>
    /// 
    /// </summary>
    public class ADMSLookupBE :atLogic.ObjectBE
    {
        SSTManager myA;
        SST.ADMSLookupDataTable myPartyLookupDT;

        internal ADMSLookupBE(SSTManager pBEMng)
            : base(pBEMng, pBEMng.DB.ADMSLookup)
        {
            myA = pBEMng;
            myPartyLookupDT = (SST.ADMSLookupDataTable)myDT;

            IsVirtual = true;
        }


        protected override void AfterAdd(DataRow row)
        {
            base.AfterAdd(row);

            SST.ADMSLookupRow dr = (SST.ADMSLookupRow)row;
            string ObjectName = this.myPartyLookupDT.TableName;

            
        }

        //public override DataRow[] GetParentRow()
        //{
        //    return base.GetParentRow();
        //}

        public override DataRow[] GetCurrentRow()
        {

            return myPartyLookupDT.Select();

        }

        protected override void AfterChange(DataColumn dc, DataRow row)
        {
            SST.ADMSLookupRow dr=(SST.ADMSLookupRow)row;

            switch(dc.ColumnName)
            {
                case "DumpIssues":
                    if(dr.DumpIssues)
                        DumpIssues();
                    break;
                case "DumpParticipants":
                    if(dr.DumpParticipants)
                        DumpParticipants();
                    break;
                case "Send":
                    if (dr.Send)
                        CallWS(dr);
                        break;
            }

        }


        protected override void BeforeChange(DataColumn dc, DataRow row)
        {
            SST.ADMSLookupRow dr = (SST.ADMSLookupRow)row;

            switch (dc.ColumnName)
            {
                case "SIN":
                    if (!dr.IsSINNull())
                    {
                       
                        if (dr.SIN.Length != 9 || !ContactBE.IsValidSIN(dr.SIN))
                        {
                            throw new AtriumException(atriumBE.Properties.Resources.BadSIN, dr.SIN);
                        }
                       
                    }
                    break;
                case "BusinessNumber":
                    if (!dr.IsBusinessNumberNull())
                    {

                        //if (dr.BusinessNumber.Length >= 9 || !ContactBE.IsValidSIN(dr.BusinessNumber.Substring(0,9)))
                        //{
                        //    throw new AtriumException(atriumBE.Properties.Resources.BadBN, dr.BusinessNumber);
                        //}

                    }
                    break;
            }

        }
        
        private void DumpIssues()
        {
            int i = 0;
            myA.DB.ADMSEIssues.Clear();
            myA.DB.ADMSEIssues.AcceptChanges();

            foreach (SST.SSTCaseMatterRow scmr in myA.DB.SSTCaseMatter)
            {
                SST.ADMSEIssuesRow air = (SST.ADMSEIssuesRow)myA.GetADMSEIssues().Add(null);
               // air.AppealSeqId = myA.DB.SSTCase[0].ReconsiderationID;
              //  air.IssueSeq = i++;
                air.OutComeM = scmr.OutcomeId.ToString();
                air.DecisionDate = scmr.SSTCaseRow.DecisionDate;
                air.IssueIdM = scmr.IssueId;

            }
        }

        private void DumpParticipants()
        {
            myA.DB.ADMSEParticipant.Clear();
            myA.DB.ADMSEParticipant.AcceptChanges();

            foreach (atriumDB.ContactRow pr in myA.FM.DB.Contact)
            {
                if (pr.ContactClass == "P")
                {
                    SST.ADMSEParticipantRow apr = (SST.ADMSEParticipantRow)myA.GetADMSEParticipant().Add(null);
                    if (!pr.IsFirstNameNull())
                        apr.FirstName = pr.FirstName;
                    if (!pr.IsLastNameNull())
                        apr.LastName = pr.LastName;
                    //if (!pr.IsPartyTypeCodeNull())
                    //    apr.ParticipantTypeM = pr.PartyTypeCode;
                    apr["SIN"] = pr["SIN"];
                    apr["BusinessNumber"] = pr["BusinessNumber"];
                    apr["LegalName"] = pr["LegalName"];
                    apr["OperatingAs"] = pr["OperatingAs"];

                    if (!pr.IsTelephoneNumberNull())
                        apr["TelephoneNumber"] = pr["TelephoneNumber"];
                    apr.LangCdM = pr.LanguageCode;
                    //    apr.AppealSeqId = myA.DB.SSTCase[0].ReconsiderationID;

                    try
                    {
                        atriumDB.FileContactRow fcr = pr.GetFileContactRows()[0];
                        apr.ParticipantTypeM = fcr.ContactType;
                        SST.FilePartyRow fpr = (SST.FilePartyRow)myA.DB.FileParty.Select("FileContactId=" + fcr.FileContactid.ToString())[0];
                        apr.IsAppellant = fpr.IsAppellant;
                    }
                    catch (Exception x)
                    {
                        apr.IsAppellant = false;
                    }

                    if (!pr.IsAddressCurrentIDNull())
                    {
                        atriumDB.AddressRow ar = myA.FM.DB.Address.FindByAddressId(pr.AddressCurrentID);
                        apr["AddressLine1"] = ar["Address1"];
                        apr["AddressLine2"] = ar["Address2"];
                        apr["AddressLine3"] = ar["Address3"];
                        apr["City"] = ar["City"];
                        apr["ProvinceCodeM"] = ar["ProvinceCode"];
                        apr["PostalCode"] = ar["PostalCode"];
                        apr["CountryM"] = ar["CountryCode"];

                    }
                }
            }
                
        }

        private void CallWS(SST.ADMSLookupRow ADMSr)
        {

            try
            {
                //through web service(s)
                MapBE map = myA.AtMng.GetMap();
                ADMSr.Send = false;
                ADMSr.AcceptChanges();

                //add into ACEngine reltables

                ADMS.ADMS_LookupClient ws = new ADMS.ADMS_LookupClient( );
                ws.Endpoint.Address =new System.ServiceModel.EndpointAddress( myA.AtMng.AppMan.ServerInfo.ADMSWS);


                if (ADMSr.Call == "EI")
                {
                    EI_WS(ADMSr, map, ws);

                }
                else if (ADMSr.Call == "EP")
                {
                    //only call EP if it is an EI file
                    if(myA.DB.SSTCase[0].ProgramId==3)
                        EP_WS(ADMSr, map, ws);

                }
                else if (ADMSr.Call == "P")
                {
                    P_WS(ADMSr, map, ws);
                   
                }
                else
                {//throw error
                    throw new AtriumException("Invalid call to web service");
                }
            }
            catch (Exception x)
            {
                ADMSr.Message ="Unexpected error!\n\r"+ x.Message;
            }
        }

        private void P_WS(SST.ADMSLookupRow ADMSr, MapBE map, ADMS.ADMS_LookupClient ws)
        {
            DataSet ds = ws.Get_ADMSP_SST_Info(ADMSr.SIN, ADMSr.LastName, ADMSr.ProgBenefit, ADMSr.ReconDate);

            //if (ds.Tables.Contains("ERROR"))
            //{
            //    //get status message
            //    ADMSr.Message = ds.Tables["ERROR"].Rows[0]["MESSAGE"].ToString();
            //    if (ADMSr.Message.ToUpper() == "SUCCESS")
            //    {
            //        if (ds.Tables.Contains("ADMSP_SST_INFO"))
            //        {
            //            DataTable dtR = ds.Tables["ADMSP_SST_INFO"];
            //            DataRow dr = dtR.Rows[0];

            //            SST.SSTCaseRow scr = (SST.SSTCaseRow)myA.GetSSTCase().GetCurrentRow()[0];
            //           // scr.ProgramId=
            //            scr.OrigDecisionDate =System.Convert.ToDateTime( dr["STATUS_DATE"]);

            //            string tempID=dr["IDENTIFIER_NUMBER"].ToString();

                        
            //            if (ds.Tables.Contains("ADMSP_SST_INFO_PARTICIPANTS"))
            //            {

            //                foreach (DataRow drp in ds.Tables["ADMSP_SST_INFO_PARTICIPANTS"].Rows)
            //                {
            //                    if (tempID == dr["IDENTIFIER_NUMBER"].ToString())
            //                    {
            //                        SST.PartyRow pr = (SST.PartyRow)myA.GetParty().GetCurrentRow()[0];
            //                        if (drp["IDENTIFIER_TYPE_CODE"].ToString() == "SIN")
            //                            pr.SIN = drp["ID_SIN"].ToString();

            //                        if (pr.GetColumnError("SIN") == Properties.Resources.DebtDuplicateSIN)
            //                        {
            //                            pr = myA.GetParty().SwapBySIN(pr, pr.SIN);
            //                        }
            //                        pr.LastName = drp["LAST_NAME"].ToString();
            //                        pr.FirstName = drp["FIRST_NAME"].ToString();
            //                    }
            //                }     
            //            }


            //        }

            //    }

            //}

        }

        private void EP_WS(SST.ADMSLookupRow ADMSr, MapBE map, ADMS.ADMS_LookupClient ws)
        {
            //only add other parties

            ACEngine ace = myA.FM.CurrentActivityProcess.CurrentACE;

            DataSet ds = ws.Get_ADMS_SST_Info(ADMSr.ReconID, ADMSr.SIN, ADMSr.BusinessNumber);

            if (ds.Tables.Contains("ERROR"))
            {
                //get status message
                ADMSr.Message = ds.Tables["ERROR"].Rows[0]["MESSAGE"].ToString();
                if (ADMSr.Message.ToUpper() == "SUCCESS")
                {
                    if (ds.Tables.Contains("ADMS_SST_INFO"))
                    {
                        DataTable dtR = ds.Tables["ADMS_SST_INFO"];
                        DataRow dr = dtR.Rows[0];

                        if (ds.Tables.Contains("ADMS_SST_INFO_PARTICIPANTS"))
                        {

                            // string participantType = map.MapIn("Source2Participant", dr["CODE_SRC"].ToString());
                            foreach (DataRow drp in ds.Tables["ADMS_SST_INFO_PARTICIPANTS"].Rows)
                            {
                                bool isAppellant = false;
                                if (!ADMSr.IsSINNull() && !drp.IsNull("ID_SIN") && ADMSr.SIN == drp["ID_SIN"].ToString())
                                    isAppellant = true;
                                else if (!ADMSr.IsBusinessNumberNull() && !drp.IsNull("ID_BSNS_NMBR"))
                                {
                                    isAppellant = IsEmployerAppellant(ADMSr, drp, isAppellant);
                                }
                                if (isAppellant)
                                {
                                    ////ignore
                                    //atriumDB.ContactRow pr = (atriumDB.ContactRow)ace.relTables["Party0"][0].Row;
                                    //atriumDB.FileContactRow fcr4 = (atriumDB.FileContactRow)ace.relTables["FileContact4"][0].Row;
                                    //SST.FilePartyRow fpr = (SST.FilePartyRow)ace.relTables["FileParty0"][0].Row;

                                    //fpr.IsAppellant = true;

                                    //pr.SIN = drp["ID_SIN"].ToString();
                                    //pr.ContactClass = "P";
                                    //if (pr.GetColumnError("SIN") == Properties.Resources.DebtDuplicateSIN)
                                    //{
                                    //    //TFS#54669 CJW 2013-09-20  called in PersonBE beforechange now
                                    //    //pr = myA.FM.GetPerson().SwapBySIN(pr, pr.SIN);

                                    //    pr = (atriumDB.ContactRow)ace.relTables["Party0"][0].Row;
                                    //    fcr4 = (atriumDB.FileContactRow)ace.relTables["FileContact4"][0].Row;
                                    //    fpr = (SST.FilePartyRow)ace.relTables["FileParty0"][0].Row;

                                    //    //alert user off swap
                                    //    ADMSr.Message = Properties.Resources.ExistingPartyFound;
                                    //}
                                    //pr.LastName = drp["NAME_INDVDL_LST"].ToString();
                                    //pr.FirstName = drp["NAME_INDVDL_FRST"].ToString();
                                    //pr.LanguageCode = map.MapIn("LanguageCode", drp["CODE_LNG"].ToString());

                                    //pr.BusinessNumber = drp["ID_BSNS_NMBR"].ToString();
                                    //pr.LegalName = drp["NAME_ORG"].ToString();
                                    //pr.OperatingAs = drp["NAME_ORG_UNT"].ToString();

                                    //pr.PartyTypeCode = map.MapIn("ContactType", drp["CODE_PRTCPNT_TYP"].ToString());

                                    //fcr4.ContactId = pr.ContactId;
                                    //fcr4.ContactType = pr.PartyTypeCode;
                                    //fpr.FileContactId = fcr4.FileContactid;

                                    //pr.TelephoneNumber = drp["NMBR_TLPHN_AR_CD_H"].ToString() + "-" + drp["NMBR_TLPHN_LCL_H"].ToString();
                                    //if (!pr.IsAddressCurrentIDNull())
                                    //{
                                    //    atriumDB.AddressRow ar = myA.FM.DB.Address.FindByAddressId(pr.AddressCurrentID);
                                    //    ar.ContactId = pr.ContactId;
                                    //    ar.EffectiveTo = DateTime.Today;
                                    //    ar.AddressSourceCode = "HRDC";
                                    //    ar.Address1 = drp["ADRS_LN_1"].ToString();
                                    //    ar.Address2 = drp["ADRS_LN_2"].ToString();
                                    //    ar.Address3 = drp["ADRS_LN_3"].ToString();
                                    //    ar.CountryCode = map.MapIn("Country", drp["NAME_CNTRY"].ToString());
                                    //    if (drp.IsNull("NAME_CNTRY"))
                                    //        ar.CountryCode = "CDN";
                                    //    ar.ProvinceCode = map.MapIn("Province", drp["CODE_PRVNC_OR_ST"].ToString());
                                    //    ar.City = drp["ADRS_MNCPLTY"].ToString();
                                    //    ar.PostalCode = drp["CODE_PSTL_OR_ZIP"].ToString();

                                    //}
                                }
                                else
                                {
                                    //add other participants automatically
                                    string pt = map.MapIn("ContactType", drp["CODE_PRTCPNT_TYP"].ToString());
                                    if(pt=="PCL" || pt== "PEMP")
                                        AddOtherParty(map, drp);
                                }
                            }
                        }


                    }

                }
                else if (ADMSr.Message.ToUpper() == "ERROR")
                {
                    //ADMSr.SetColumnError("Message", ADMSr.Message);
                    ADMSr.Message = ds.Tables["ERROR"].Rows[0]["SQL"].ToString();
                    if (ADMSr.Message.StartsWith("ORA-01403"))
                    {
                        ADMSr.Message = "No matching reconsideration found in ADMS. / Aucune révision correspondante trouvée dans le SGPA.";
                    }
                    else if (ADMSr.Message.StartsWith("ORA-01422"))
                    {
                        ADMSr.Message = "More than one matching reconsideration found in ADMS. / Il y a plus qu'une révision correspondante trouvée dans le SGPA.";
                    }
                    else if (ADMSr.Message.StartsWith("ORA-1017"))
                    {
                        ADMSr.Message = "Configuration problem with ADMS EI web service.  Contact IT support. / Il y a un problème de configuration avec le service web A-E SGPA. Contactez le support TI.";
                    }
                    else if (ADMSr.Message.StartsWith("ORA-12154"))
                    {
                        ADMSr.Message = "Configuration problem with ADMS EI web service.  Contact IT support. / Il y a un problème de configuration avec le service web A-E SGPA. Contactez le support TI.";
                    }




                }
            }
        }
   
        private void EI_WS(SST.ADMSLookupRow ADMSr, MapBE map, ADMS.ADMS_LookupClient ws)
        {
            ACEngine ace= myA.FM.CurrentActivityProcess.CurrentACE;

            DataSet ds = ws.Get_ADMS_SST_Info(ADMSr.ReconID, ADMSr.SIN, ADMSr.BusinessNumber);

            if (ds.Tables.Contains("ERROR"))
            {
                //get status message
                ADMSr.Message = ds.Tables["ERROR"].Rows[0]["MESSAGE"].ToString();
                if (ADMSr.Message.ToUpper() == "SUCCESS")
                {
                    if (ds.Tables.Contains("ADMS_SST_INFO"))
                    {
                        DataTable dtR = ds.Tables["ADMS_SST_INFO"];
                        DataRow dr = dtR.Rows[0];

                        SST.SSTCaseRow scr = (SST.SSTCaseRow)myA.GetSSTCase().GetCurrentRow()[0];
             //           scr.AppelantSourceId = System.Convert.ToInt32(map.MapIn("AppelantSource", dr["CODE_SRC"].ToString()));
                        scr.ReconsiderationID = ADMSr.ReconID;
                        if (!dr.IsNull("DATE_DCSN_ISD"))
                            scr.OrigDecisionDate = System.Convert.ToDateTime(dr["DATE_DCSN_ISD"]);

                        int officeid = System.Convert.ToInt32(map.MapIn("Office", dr["ID_OFC_ANCHR"].ToString()));
                        atriumDB.FileOfficeRow focr = myA.FM.GetFileOffice().AddOfficeToFile(officeid, false, false, false);
                        focr.OfficeFileNum = scr.ReconsiderationID.ToString();

                        //find the gd account
                        OfficeManager om = myA.AtMng.GetOffice(focr.OfficeId);

                        if (om.DB.Officer.Rows.Count == 0)
                        {
                            om.GetOfficer().LoadByOfficeId(focr.OfficeId);
                        }

                        var oGD = from o in om.DB.Officer
                                  where o.PositionCode == "GD"
                                  select o;

                        if (oGD.Count() == 1)
                        {
                            atriumDB.FileContactRow fcr = myA.FM.GetFileContact().Add(oGD.Single(), "FHGD");
                            fcr.HideInToc = true;
                        }
                        if (ds.Tables.Contains("ADMS_SST_INFO_PARTICIPANTS"))
                        {

                           // string participantType = map.MapIn("Source2Participant", dr["CODE_SRC"].ToString());
                            foreach (DataRow drp in ds.Tables["ADMS_SST_INFO_PARTICIPANTS"].Rows)
                            {
                                bool isAppellant = false;
                                if (!ADMSr.IsSINNull() && !drp.IsNull("ID_SIN") && ADMSr.SIN == drp["ID_SIN"].ToString())
                                    isAppellant = true;
                                else if (!ADMSr.IsBusinessNumberNull() && !drp.IsNull("ID_BSNS_NMBR") )
                                {
                                    isAppellant = IsEmployerAppellant(ADMSr, drp, isAppellant);
                                }
                                if (isAppellant)
                                {
                                    atriumDB.ContactRow pr = (atriumDB.ContactRow)ace.relTables["Party0"][0].Row;
                                    atriumDB.FileContactRow fcr4 = (atriumDB.FileContactRow)ace.relTables["FileContact4"][0].Row;
                                    SST.FilePartyRow fpr = (SST.FilePartyRow)ace.relTables["FileParty0"][0].Row;

                                    fpr.IsAppellant = true;

                                    pr.SIN = drp["ID_SIN"].ToString();
                                    pr.ContactClass = "P";
                                    //if (pr.GetColumnError("SIN") == Properties.Resources.DebtDuplicateSIN)
                                    //changed test to test for Added as the column error would never be present on the exisiting contact after the swap
                                    if(pr.RowState != DataRowState.Added)
                                    {
                                        //TFS#54669 CJW 2013-09-20  called in PersonBE beforechange now
                                        //pr = myA.FM.GetPerson().SwapBySIN(pr, pr.SIN);
                                        
                                        pr = (atriumDB.ContactRow)ace.relTables["Party0"][0].Row;
                                        fcr4 = (atriumDB.FileContactRow)ace.relTables["FileContact4"][0].Row;
                                        fpr = (SST.FilePartyRow)ace.relTables["FileParty0"][0].Row;

                                        //alert user off swap
                                        ADMSr.Message = Properties.Resources.ExistingPartyFound;
                                    }
                                    pr.LastName = drp["NAME_INDVDL_LST"].ToString();
                                    pr.FirstName = drp["NAME_INDVDL_FRST"].ToString();
                                    pr.LanguageCode = map.MapIn("LanguageCode", drp["CODE_LNG"].ToString());

                                    pr.BusinessNumber = drp["ID_BSNS_NMBR"].ToString();
                                    pr.LegalName = drp["NAME_ORG"].ToString();
                                    pr.OperatingAs = drp["NAME_ORG_UNT"].ToString(); 

                                    pr.PartyTypeCode = map.MapIn("ContactType", drp["CODE_PRTCPNT_TYP"].ToString());

                                    fcr4.ContactId = pr.ContactId;
                                    fcr4.ContactType = pr.PartyTypeCode;
                                    fpr.FileContactId = fcr4.FileContactid;

                                    pr.TelephoneNumber = drp["NMBR_TLPHN_AR_CD_H"].ToString() + "-" + drp["NMBR_TLPHN_LCL_H"].ToString();
                                    if (!pr.IsAddressCurrentIDNull())
                                    {
                                        atriumDB.AddressRow ar = myA.FM.DB.Address.FindByAddressId(pr.AddressCurrentID);
                                        ar.ContactId = pr.ContactId;
                                        ar.EffectiveTo = DateTime.Today;
                                        ar.AddressSourceCode = "HRDC";
                                        ar.Address1 = drp["ADRS_LN_1"].ToString();
                                        ar.Address2 = drp["ADRS_LN_2"].ToString();
                                        ar.Address3 = drp["ADRS_LN_3"].ToString();
                                        string prov = map.MapIn("Province", drp["CODE_PRVNC_OR_ST"].ToString());
                                        if (prov != null)
                                        {
                                            DataTable dtProv = myA.FM.Codes("Province");
                                            DataRow drs = dtProv.Rows.Find(prov);

                                            if (drs != null)
                                                ar.CountryCode = drs["CountryCode"].ToString();
                                            else
                                                ar.CountryCode = "CDN";
                                        }
                                        else
                                        {
                                            ar.CountryCode = map.MapIn("Country", drp["NAME_CNTRY"].ToString());
                                            if (drp.IsNull("NAME_CNTRY") || ar.IsNull("CountryCode"))
                                                ar.CountryCode = "CDN";
                                        }
                                        ar.ProvinceCode = prov;
                                        ar.City = drp["ADRS_MNCPLTY"].ToString();
                                        ar.PostalCode = drp["CODE_PSTL_OR_ZIP"].ToString();

                                    }
                                }
                                else
                                {
                                    //add other participants automatically
                                    AddOtherParty(map, drp);
                                }
                            }
                        }


                    }

                }
                else if (ADMSr.Message.ToUpper() == "ERROR")
                {
                //    ADMSr.SetColumnError("Message", ADMSr.Message);
                    ADMSr.Message = ds.Tables["ERROR"].Rows[0]["SQL"].ToString();
                    if (ADMSr.Message.StartsWith("ORA-01403"))
                    {
                        ADMSr.Message = "No matching reconsideration found in ADMS. / Aucune révision correspondante trouvée dans le SGPA.";
                    }
                    else if (ADMSr.Message.StartsWith("ORA-01422"))
                    {
                        ADMSr.Message = "More than one matching reconsideration found in ADMS. / Il y a plus qu'une révision correspondante trouvée dans le SGPA.";
                    }
                    else if (ADMSr.Message.StartsWith("ORA-1017"))
                    {
                        ADMSr.Message = "Configuration problem with ADMS EI web service.  Contact IT support. / Il y a un problème de configuration avec le service web A-E SGPA. Contactez le support TI.";
                    }
                    else if (ADMSr.Message.StartsWith("ORA-12154"))
                    {
                        ADMSr.Message = "Configuration problem with ADMS EI web service.  Contact IT support. / Il y a un problème de configuration avec le service web A-E SGPA. Contactez le support TI.";
                    }




                }
            }
        }

        private static bool IsEmployerAppellant(SST.ADMSLookupRow ADMSr, DataRow drp, bool isAppellant)
        {
            string bnEntered = ADMSr.BusinessNumber.ToUpper();
            string bnReturned = drp["ID_BSNS_NMBR"].ToString().ToUpper();
            if (bnReturned.StartsWith(bnEntered))
                isAppellant = true;
            return isAppellant;
        }

        private void AddOtherParty(MapBE map, DataRow drp)
        {
            atriumDB.ContactRow pr = null;
            //search for party
            if (!drp.IsNull("ID_SIN"))
            {
                string SIN = drp["ID_SIN"].ToString();
                myA.FM.GetPerson().LoadBySIN(SIN);

                var ps = from p in myA.FM.DB.Contact
                         where !p.IsSINNull() && p.SIN == SIN
                         select p;
                if (ps.Count() == 1)
                    pr = ps.Single();



            }
            if (pr == null)
            {
                //create party
                pr = (atriumDB.ContactRow)myA.FM.GetPerson().Add(null);
                pr.SIN = drp["ID_SIN"].ToString();
            }

            pr.ContactClass = "P";

            //if (drp.IsNull("NAME_INDVDL_LST"))
            //    pr.LastName = "Resources";
            //else
            pr.LastName = drp["NAME_INDVDL_LST"].ToString();


            //if (drp.IsNull("NAME_INDVDL_FRST"))
            //    pr.FirstName = "Human";
            //else
            pr.FirstName = drp["NAME_INDVDL_FRST"].ToString();

            pr.LanguageCode = map.MapIn("LanguageCode", drp["CODE_LNG"].ToString());

            pr.BusinessNumber = drp["ID_BSNS_NMBR"].ToString();
            pr.LegalName = drp["NAME_ORG"].ToString();
            pr.OperatingAs = drp["NAME_ORG_UNT"].ToString();

            pr.PartyTypeCode = map.MapIn("ContactType", drp["CODE_PRTCPNT_TYP"].ToString());
            pr.TelephoneNumber = drp["NMBR_TLPHN_AR_CD_H"].ToString() + "-" + drp["NMBR_TLPHN_LCL_H"].ToString();

            //create address
            atriumDB.AddressRow ar = (atriumDB.AddressRow)myA.FM.GetAddress().Add(pr);
          //  ar.ContactId = pr.ContactId;
            ar.EffectiveTo = DateTime.Today;
            ar.AddressSourceCode = "HRDC";
            ar.Address1 = drp["ADRS_LN_1"].ToString();
            ar.Address2 = drp["ADRS_LN_2"].ToString();
            ar.Address3 = drp["ADRS_LN_3"].ToString();
            string prov = map.MapIn("Province", drp["CODE_PRVNC_OR_ST"].ToString());
            if (prov !=null)
            {
                DataTable dtProv = myA.FM.Codes("Province");
                DataRow drs = dtProv.Rows.Find(prov);

                if (drs != null)
                    ar.CountryCode = drs["CountryCode"].ToString();
                else
                    ar.CountryCode = "CDN";
            }
            else
            {
                ar.CountryCode = map.MapIn("Country", drp["NAME_CNTRY"].ToString());
                if (drp.IsNull("NAME_CNTRY") || ar.IsNull("CountryCode"))
                    ar.CountryCode = "CDN";
            }
            ar.ProvinceCode = prov;
            ar.City = drp["ADRS_MNCPLTY"].ToString();
            ar.PostalCode = drp["CODE_PSTL_OR_ZIP"].ToString();

          //  pr.AddressCurrentID = ar.AddressId;

            //create filecontact
            atriumDB.FileContactRow fcrp = (atriumDB.FileContactRow)myA.FM.GetFileContact().Add(myA.FM.CurrentFile);
            fcrp.ContactId = pr.ContactId;
            fcrp.ContactType = pr.PartyTypeCode;

            //create fileparty
            SST.FilePartyRow fpr = (SST.FilePartyRow)myA.GetFileParty().Add(myA.FM.CurrentFile);
            // fpr.PartyId = pr.PartyId;
            // fpr.ContactTypeCode = pr.PartyTypeCode;
            fpr.IsPending = true;
            fpr.FileContactId = fcrp.FileContactid;
        }
    }
}

