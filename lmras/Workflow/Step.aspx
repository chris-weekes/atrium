<%@ Page Title="" Language="C#" MasterPageFile="~/Workflow/wf.Master" AutoEventWireup="true" CodeBehind="Step.aspx.cs" Inherits="lmras.Workflow.Step" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Globalization" %>
<script runat="server">
protected override void InitializeCulture()
{

    if (Request.QueryString["lang"] == "en")
        Session["userLang"] = "en";
    else if (Request.QueryString["lang"] == "fr")
        Session["userLang"] = "fr";
    else if (Session["userLang"] == null)
        Session["userLang"] = "en";

    if (Session["userLang"] == "en")
        Session["DBLang"] = "Eng";
    else
        Session["DBLang"] = "Fre";

    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture((string)Session["userLang"]);
    Thread.CurrentThread.CurrentUICulture = new CultureInfo((string)Session["userLang"]);
    base.InitializeCulture();
}
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%
    string sc = Request.QueryString["stepcode"];
    string id = Request.QueryString["acseriesid"];
    if (sc == null && id == null)
    {
        Response.Redirect("list.aspx", true); 
    }

    string vList = "<a href=\"List.aspx\" class=\"hm\">" + myWF.getResource("AllFlows") + "</a> ";
    string vWF = "<a href=\"Workflow.aspx?seriesid="+myACSeries.SeriesId+"\" class=\"hm\"><img alt=\"\" src=\"images/workflow.gif\"/>"+myACSeries.SeriesCode+" - "+myACSeries.SeriesRow["SeriesDesc" + Session["DBLang"].ToString()]+"</a>";
    string vACS = " <img alt=\"\" src=\"images/act.png\"/>" + myACSeries.StepCode + " - " + myACSeries["ActivityName" + Session["DBLang"].ToString()];
    
    string homelnk = vList + " / " + vWF + " / " + vACS;

    Response.Write(homelnk);
    
%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--
    //
    //  STEP PROPERTIES
    //
    -->

    <h2><%:myWF.getResource("lblStepCodeProperties")%></h2>
    <p><%: myWF.getResource("lblFoundInWF") %> <a href="workflow.aspx?seriesid=<%:myACSeries.SeriesId %>"><img alt="" src="images/workflow.gif" /><%:myACSeries.SeriesCode %> - <%:myACSeries.SeriesRow["SeriesDesc"  + Session["DBLang"].ToString()] %></a></p>
    <div style="margin-bottom:12px;float:left;">
     <table class="module-versatile">
        <tr>
            <td><%:myWF.getResource("lblStepCode")%></td>
            <td><a href="workflow.aspx?seriesid=<%:myACSeries.SeriesId %>#<%:myACSeries.StepCode %>"><%:myACSeries.StepCode%></a></td>
        </tr>
        <tr>
            <td><%:myWF.getResource("lblPresentE")%></td>
            <td><%:myACSeries.ActivityNameEng%></td>
        </tr>
        <tr>
            <td><%:myWF.getResource("lblPresentF")%></td>
            <td><%:myACSeries.ActivityNameFre%></td>
        </tr>
        <tr>
            <td><%:myWF.getResource("lblPastE")%></td>
            <td><%:myACSeries.ActivityCodeRow.ActivityNamePastTenseEng%></td>
        </tr>
        <tr>
            <td><%:myWF.getResource("lblPastF")%></td>
            <td><%:myACSeries.ActivityCodeRow.ActivityNamePastTenseFre%></td>
        </tr>
        </table>
       
    </div>
    <%
        if (myWF.myACM.GetACSeries().hasPerformADMSLookup(myACSeries))
        {%>
        <div class="xfer"><img alt="" src="images/dataexchange.png" /><%Response.Write(myWF.getResource("lblADMSDataRetrieval"));%></div>
        <%}

        if (myWF.myACM.GetACSeries().hasAppealDataXchange(myACSeries))
        {%>
        <div class="xfer"><img alt="" src="images/dataexchange.png" /><%Response.Write(myWF.getResource("lblADMSDataXchange"));%></div>
        <%}
        
        if (myWF.myACM.GetACSeries().hasADMSDumpParticipants(myACSeries))
        {%>
        <div class="xfer"><img alt="" src="images/dataexchange.png" /><%Response.Write(myWF.getResource("lblADMSParticipantDump"));%></div>
        <%}

        if (myWF.myACM.GetACSeries().hasADMSDumpIssues(myACSeries))
        {%>
        <div class="xfer"><img alt="" src="images/dataexchange.png" /><%Response.Write(myWF.getResource("lblADMSAppealData"));%></div>
        <%}

        if (myWF.myACM.GetACSeries().hasSendingOfDecision(myACSeries))
        {%>
        <div class="xfer"><img alt="" src="images/decisionsent.png" /><%Response.Write(myWF.getResource("lblADMSDecision"));%></div>
        <%}
          
        if (myWF.myACM.GetACSeries().hasDocXchange(myACSeries))
        {%>
        <div class="xfer"><img alt="" src="images/transfer_document.png"/><%Response.Write(myWF.getResource("lblDocDump"));%></div>
        <%} %>

    <div class="clear"></div><br />
   

   <% //check for Step Objective   
         
         lmDatasets.ActivityConfig.ACDocumentationRow acdocr = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "stepobjective");
         if (acdocr != null) 
         {%>
            <div class="stpLnk"><strong><%:myWF.getResource("acdocStepObjective") %></strong> 
            <%if ((bool)Session["isEditMode"]){ %>
            <a class="aEdit" href="javascript:launchAcDocNote(false,'','','stepobjective',<%Response.Write(acdocr.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
            <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocr.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a>
            <%} %></div>
            
            <div class="clear"></div>
            <div style="border:1px solid #aaaaaa;background-color:#f6f6f6;padding:6px;margin-top:2px;">
                <p><%Response.Write(acdocr["Text" + Session["DBLang"].ToString()]); %></p>
            </div><br />
            <%}
         else if((bool)Session["isEditMode"])
         {%>
                <div class="stpLnk stpLnk3"><strong><%:myWF.getResource("acdocStepObjective") %></strong> <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','stepobjective',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></div><div class="clear"></div><br />
         <%}%>

        
        
        
        
        <div class="stpLnk"><img alt="" src="images/nawicon.png" /><strong><%:myWF.getResource("lblNAWContents")%></strong></div><div class="clear"></div>
        <div class="bx">
    
        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] InitiateFlds = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=-10", "Seq");
        if (InitiateFlds.Length > 0){%>
        <a href="#InitBlock"><img alt="" src="images/relfields.png" /><%:myWF.getResource("lblInit")%></a><br />
        <%}%>

        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] PickIssueBlock = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and tasktype='I' and objectname='IssuePrimary'", "");
        if (PickIssueBlock.Length > 0)
        {%>
        <a href="#PickIssue"><img alt="" src="images/issue.png" /><%:myWF.getResource("lblSelectIssue")%></a> <span class="bVis">VISIBLE</span><br />
        <%}%>


        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block1 = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=0", "Seq");
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block1RelatedFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=0 and tasktype='F' and visible=true", "Seq");
        if (Block1.Length > 0){%>
        <a href="#Block1"><img alt="" src="images/metadata.png" /><%:myWF.getResource("lblBlock1")%></a>
        <%if (Block1RelatedFields.Length > 0){ %>
        <span class="bVis">VISIBLE</span>
        <%} %>
        <br />
        <%}%>

        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block2 = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=1", "Seq");
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block2RelatedFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=1 and tasktype='F' and visible=true", "Seq");
        if (Block2.Length > 0){%>
        <a href="#Block2"><img alt="" src="images/metadata.png" /><%:myWF.getResource("lblBlock2")%></a>
        <%if (Block2RelatedFields.Length > 0){ %>
        <span class="bVis">VISIBLE</span>
        <%} %>
        <br />
        <%}%>

        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block3 = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=2", "Seq");
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block3RelatedFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=2 and tasktype='F' and visible=true", "Seq");
        if (Block3.Length > 0){%>
        <a href="#Block3"><img alt="" src="images/metadata.png" /><%:myWF.getResource("lblBlock3")%></a>
        <%if (Block3RelatedFields.Length > 0){ %>
        <span class="bVis">VISIBLE</span>
        <%} %>
        <br />
        <%}%>

        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block4 = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=3", "Seq");
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block4RelatedFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=3 and tasktype='F' and visible=true", "Seq");
        if (Block4.Length > 0){%>
        <a href="#Block4"><img alt="" src="images/metadata.png" /><%:myWF.getResource("lblBlock4")%></a>
        <%if (Block4RelatedFields.Length > 0){ %>
        <span class="bVis">VISIBLE</span>
        <%} %>
        <br />
        <%}%>

        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block5 = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=4", "Seq");
        lmDatasets.ActivityConfig.ActivityFieldRow[] Block5RelatedFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=4 and tasktype='F' and visible=true", "Seq");
        if (Block5.Length > 0){%>
        <a href="#Block5"><img alt="" src="images/metadata.png" /><%:myWF.getResource("lblBlock5")%></a>
        <%if (Block5RelatedFields.Length > 0){ %>
        <span class="bVis">VISIBLE</span>
        <%} %>
        <br />
        <%}%>

        <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] DocBlock = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step='10'", "Seq");
        if (DocBlock.Length > 0){%>
        <a href="#DocBlock"><img alt="" src="images/doc2.png" /><%:myWF.getResource("lblDocBlock")%></a><br />
        <%}%>

         <%
        lmDatasets.ActivityConfig.ActivityFieldRow[] SchedulingBlock = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step='12'", "Seq");
        if (SchedulingBlock.Length > 0)
        {%>
        <a href="#SchedulingBlock"><img alt="" src="images/bflistcalendar.png" /><%:myWF.getResource("lblSchedBlock")%></a><br />
        <%}%>

        <a href="#FinishBlock"><img alt="" src="images/save.png" /><%:myWF.getResource("lblOnFinish")%></a><br />

        <%        
       // if (.Length > 0){%>
        <!--<a href="#">Timekeeping Block</a><br />-->
        <%//}%>

        </div><br />
        
        
        <%

            //
            //Initiate Block
            //
            
            if (InitiateFlds.Length > 0)
            {%>
            <div class="stpLnk2"><a name="InitBlock"></a><img alt="" src="images/relFields.png" /><strong><%:myWF.getResource("lblInit")%></strong></div>
            <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
            <div class="clear"></div>
            <div class="bx">
            <p><%Response.Write(myWF.getResource("lblInitPar"));%></p>
            <table class="module-versatile2"><tr><th><%:myWF.getResource("lblTask")%></th><th><%:myWF.getResource("lblTable")%></th><th><%:myWF.getResource("lblField")%></th><th><%:myWF.getResource("lblObjectAlias")%></th><th><%:myWF.getResource("lblParentRow")%></th><th><%:myWF.getResource("lblDefaultValue")%></th></tr>
            <% 
                foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in InitiateFlds)
                {
                    Response.Write(myWF.UsedRecordsHTMLOutput(afr, Session["DBLang"].ToString()));
                }%>
                </table></div><div class="clear"></div><br />
            <%}


            //
            //  Pick Issue Block
            //

            if (PickIssueBlock.Length > 0)
              {%>
            <div class="stpLnk2"><a name="PickIssue"></a><img alt="" src="images/issue.png" /><strong><%: myWF.getResource("lblSelectIssue") %></strong></div>
            <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
            <div class="clear"></div>
            <div class="bx">

            <%
            //Purpose for Pick Issue
            Response.Write(myWF.AcDocRowHTMLOutput(myWF, myACSeries, "pickissuepurpose", (bool)Session["isEditMode"], myWF.getResource("lblPurpose"), Session["DBLang"].ToString()));
            %>

            <p><% Response.Write(myWF.getResource("lblPrimaryIsSet")); %></p>
            <% 
                  lmDatasets.appDB.IssueRow issr = myWF.myACM.AtMng.DB.Issue.FindByIssueId(Convert.ToInt32(PickIssueBlock[0].DefaultValue));
                  string issueName = issr.IssueNameEng;

                  atriumBE.FileManager ifm = myWF.myACM.AtMng.GetFile(issr.FileId);
                  string fileNum = ifm.CurrentFile.FullFileNumber;
                  string fileName = ifm.CurrentFile["Name" + Session["DBLang"].ToString().Substring(0,1)].ToString();
                %>
            <table>
                <tr>
                    <td><strong><%: myWF.getResource("lblIssueName") %></strong></td>
                    <td><%:issueName %></td>
                </tr>
                <tr>
                    <td><strong><%: myWF.getResource("lblFileNum") %></strong></td>
                    <td><%:fileNum%></td>
                </tr>
                <tr>
                    <td><strong><%: myWF.getResource("lblFileName") %></strong></td>
                    <td><%:fileName%></td>
                </tr>
            </table><div class="clear"></div>

           <p><strong><%:myWF.getResource("lblLayout") %></strong></p>
             <table class="naw pickissuenaw">
                    <tr><td class="nawTL"></td><td class="nawT"></td><td class="nawTR"></td></tr>
                    <tr><td class="nawL"></td><td class="ttlBar"><div class="ttlBarLeft"><img alt="" src="images/nawicon.png" /><%:myACSeries.StepCode%> - <%:myACSeries["ActivityName" + Session["DBLang"].ToString()]%></div><div class="ttlBarRight"><img alt="" src="images/toolbox.png" /></div></td><td class="nawR"></td></tr>
                    <tr>
                        <td class="nawL"></td>
                        <td class="pickissue"><div id="oPrimIss"><%:issueName %></div></td>
                        <td class="nawR"></td>
                    </tr>
                    <tr>
                        <td class="nawL"></td>
                        <td><br />
                            <div class="footerBtnBar"><img alt="" src="images/btnSuspendOn.png" /><img alt="" src="images/btnCancelOn.png" /><img alt="" src="images/btnBackOn.png" /><img alt="" src="images/btnNextOn.png" /><img alt="" src="images/btnLastOn.png" /><img alt="" src="images/btnFinishOn.png" /></div>
                        </td>
                        <td class="nawR"></td>
                    </tr>
                    <tr>
                        <td class="nawBL"> </td>
                        <td class="nawB"> </td>
                        <td class="nawBR"> </td>
                    </tr>
                    </table>


            </div><div class="clear"></div><br />
            <%}
        
                //
                // Block 1 
                //

                if (Block1.Length > 0)
                {
                %>
                <div class="stpLnk2"><a name="Block1"></a><img alt="" src="images/metadata.png" /><strong><%: myWF.getResource("lblBlock1") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">


                 <%
                    //Purpose for Block 1   
         
                     lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk1 = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block1purpose");
                     if (acdocrBlk1 != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block1purpose',<%Response.Write(acdocrBlk1.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk1.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a>
                        <%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk1["Text" +Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblPurpose") %></strong> 
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block1purpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                            </p><div class="clear"></div>
                     <%}%>




                <%
                    lmDatasets.ActivityConfig.ActivityFieldRow[] Block1UsedRecords = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=0 and tasktype<>'F'", "Seq");
                    if (Block1UsedRecords.Length > 0)
                    {%>
                <p><% Response.Write(myWF.getResource("lblUsedRecordInit")); %></p>
               <table class="module-versatile2"><tr><th><%:myWF.getResource("lblTask") %></th><th><%:myWF.getResource("lblTable") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblObjectAlias") %></th><th><%:myWF.getResource("lblParentRow") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block1UsedRecords)
                  {
                      Response.Write(myWF.UsedRecordsHTMLOutput(afr, Session["DBLang"].ToString()));
                  }%>
                </table>
                <%}

                    //
                    // Block 1 Hidden Fields
                    //    

                    lmDatasets.ActivityConfig.ActivityFieldRow[] Block1HiddenFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=0 and tasktype='F' and visible=false", "Seq");
                    if (Block1HiddenFields.Length > 0)
                    {%>
                <p><% Response.Write(myWF.getResource("lblNotVisible")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block1HiddenFields)
                  {
                      Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));
                  }%>
                </table>
                <%}

                    //
                    // Block 1 Displayed Fields
                    //  

                    if (Block1RelatedFields.Length > 0)
                    {%>
                <p><% Response.Write(myWF.getResource("lblDisplayedFields")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblLookupTable") %></th><th><%:myWF.getResource("lblControlType") %></th><th><%:myWF.getResource("lblParameter")%></th><th><%:myWF.getResource("lblDefaultValue") %></th><th><%:myWF.getResource("lblRequired") %></th><th><%:myWF.getResource("lblReadOnly") %></th><th><%:myWF.getResource("lblLabel") %></th><th><%:myWF.getResource("lblHelp") %></th></tr>

                <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block1RelatedFields)
                   {
                       Response.Write(myWF.DisplayedFieldsTableHTMLOutput(afr, Session["DBLang"].ToString()));
                   }%>
                </table>

                <%}
                  
                  //Related Fields Layout
                   if (Block1RelatedFields.Length > 0)
                    {%>
                <p><strong><%:myWF.getResource("lblLayout") %></strong></p>
                
                <%Response.Write(myWF.PrntScreenTop(myACSeries, Session["DBLang"].ToString()));
                         foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block1RelatedFields)
                         {
                             Response.Write(myWF.LayoutHTMLOutput(afr, Session["DBLang"].ToString()));
                         }
                         Response.Write(myWF.PrntScreenBottom());
                    }

                    
              //Processing for Block 1
                lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk1Proc = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block1processing");
                if (acdocrBlk1Proc != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block1processing',<%Response.Write(acdocrBlk1Proc.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk1Proc.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk1Proc["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block1processing',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>

                </div><br />
                <%}
                  
                  //
                // Block 2
                //
                
                if (Block2.Length > 0)
                {
                %>
                <div class="stpLnk2"><a name="Block2"></a><img alt="" src="images/metadata.png" /><strong><%: myWF.getResource("lblBlock2") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  

                  <%
                    //Purpose for Block 2   
         
                     lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk2 = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block2purpose");
                     if (acdocrBlk2 != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block2purpose',<%Response.Write(acdocrBlk2.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk2.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk2["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block2purpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>


                <%
                //
                // Block 2 Used Records
                //
                
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block2UsedRecords = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=1 and tasktype<>'F'", "Seq");
                if (Block2UsedRecords.Length > 0)
                {%>
               <p><% Response.Write(myWF.getResource("lblUsedRecordInit")); %></p>
               <table class="module-versatile2"><tr><th><%:myWF.getResource("lblTask") %></th><th><%:myWF.getResource("lblTable") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblObjectAlias") %></th><th><%:myWF.getResource("lblParentRow") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block2UsedRecords)
               {
                   Response.Write(myWF.UsedRecordsHTMLOutput(afr, Session["DBLang"].ToString()));
                }%>
                </table><div class="clear"></div>
                <%}

                //
                // Block 2 Hidden Fields
                //    
                
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block2HiddenFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=1 and tasktype='F' and visible=false", "Seq");
                if (Block2HiddenFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblNotVisible")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block2HiddenFields)
                {
                    Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));      
                }%>
                </table><div class="clear"></div>
                <%}

                //
                // Block 2 Displayed Fields
                //  
                if (Block2RelatedFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblDisplayedFields")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblLookupTable") %></th><th><%:myWF.getResource("lblControlType") %></th><th><%:myWF.getResource("lblParameter")%></th><th><%:myWF.getResource("lblDefaultValue") %></th><th><%:myWF.getResource("lblRequired") %></th><th><%:myWF.getResource("lblReadOnly") %></th><th><%:myWF.getResource("lblLabel") %></th><th><%:myWF.getResource("lblHelp") %></th></tr>

                <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block2RelatedFields)
                   {
                       Response.Write(myWF.DisplayedFieldsTableHTMLOutput(afr, Session["DBLang"].ToString()));
                   }%>
                </table>
                <%}
                  
                  //Related Fields Layout
                    if (Block2RelatedFields.Length > 0)
                    {%>
                <p><strong><%: myWF.getResource("lblLayout") %></strong></p>
                <% Response.Write(myWF.PrntScreenTop(myACSeries, Session["DBLang"].ToString()));
                 
                   foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block2RelatedFields)
                   { Response.Write(myWF.LayoutHTMLOutput(afr, Session["DBLang"].ToString())); }
                    
                   Response.Write(myWF.PrntScreenBottom());
                    }

                //Processing for Block 2
                lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk2Proc = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block2processing");
                if (acdocrBlk2Proc != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block2processing',<%Response.Write(acdocrBlk2Proc.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk2Proc.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk2Proc["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block2processing',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>


                    </div><br />
                <%}
                
                if (Block3.Length > 0)
                {%>
                <div class="stpLnk2"><a name="Block3"></a><img alt="" src="images/metadata.png" /><strong><%: myWF.getResource("lblBlock3") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  

                  <%
                    //Purpose for Block 3
         
                     lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk3 = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block3purpose");
                     if (acdocrBlk3 != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block3purpose',<%Response.Write(acdocrBlk3.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk3.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk3["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block3purpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                            </p><div class="clear"></div>
                     <%}%>

                <%
                //
                // Block 3 Used Records
                //
                
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block3UsedRecords = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=2 and tasktype<>'F'", "Seq");
                if (Block3UsedRecords.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblUsedRecordInit")); %></p>
               <table class="module-versatile2"><tr><th><%:myWF.getResource("lblTask") %></th><th><%:myWF.getResource("lblTable") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblObjectAlias") %></th><th><%:myWF.getResource("lblParentRow") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block3UsedRecords)
               {
                   Response.Write(myWF.UsedRecordsHTMLOutput(afr, Session["DBLang"].ToString()));
                }%>
                </table>
                <%}

                //
                // Block 3 Hidden Fields
                //    
                
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block3HiddenFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=2 and tasktype='F' and visible=false", "Seq");
                if (Block3HiddenFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblNotVisible")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block3HiddenFields)
                {
                    Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));      
                }%>
                </table>
                <%}

                //
                // Block 3 Displayed Fields
                //  
                if (Block3RelatedFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblDisplayedFields")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblLookupTable") %></th><th><%:myWF.getResource("lblControlType") %></th><th><%:myWF.getResource("lblParameter")%></th><th><%:myWF.getResource("lblDefaultValue") %></th><th><%:myWF.getResource("lblRequired") %></th><th><%:myWF.getResource("lblReadOnly") %></th><th><%:myWF.getResource("lblLabel") %></th><th><%:myWF.getResource("lblHelp") %></th></tr>

                <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block3RelatedFields)
                   {
                       Response.Write(myWF.DisplayedFieldsTableHTMLOutput(afr, Session["DBLang"].ToString()));
                   }%>
                </table>
                  <%}



               //Related Fields Layout
                    if (Block3RelatedFields.Length > 0)
                    {%>
                <p><strong><%: myWF.getResource("lblLayout") %></strong></p>
                <% Response.Write(myWF.PrntScreenTop(myACSeries, Session["DBLang"].ToString()));
                 
                   foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block3RelatedFields)
                   { Response.Write(myWF.LayoutHTMLOutput(afr, Session["DBLang"].ToString())); }
                    
                   Response.Write(myWF.PrntScreenBottom());
                    }

                     //Processing for Block 3
                lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk3Proc = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block3processing");
                if (acdocrBlk3Proc != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block3processing',<%Response.Write(acdocrBlk3Proc.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk3Proc.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk3Proc["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block3processing',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>
                    
                    </div><br />
                <%}

                if (Block4.Length > 0)
                {%>
                <div class="stpLnk2"><a name="Block4"></a><img alt="" src="images/metadata.png" /><strong><%: myWF.getResource("lblBlock4") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  
                  <%
                      
                    //Purpose for Block 4
         
                     lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk4 = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block4purpose");
                     if (acdocrBlk4 != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block4purpose',<%Response.Write(acdocrBlk4.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk4.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk4["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block4purpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                        </p><div class="clear"></div>
                     <%}

                //
                // Block 4 Used Records
                //
                
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block4UsedRecords = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=3 and tasktype<>'F'", "Seq");
                if (Block4UsedRecords.Length > 0)
                {%>
                 <p><% Response.Write(myWF.getResource("lblUsedRecordInit")); %></p>
               <table class="module-versatile2"><tr><th><%:myWF.getResource("lblTask") %></th><th><%:myWF.getResource("lblTable") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblObjectAlias") %></th><th><%:myWF.getResource("lblParentRow") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block4UsedRecords)
               {
                   Response.Write(myWF.UsedRecordsHTMLOutput(afr, Session["DBLang"].ToString()));
                }%>
                </table>
                <%}

                //
                // Block 4 Hidden Fields
                //    
                
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block4HiddenFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=3 and tasktype='F' and visible=false", "Seq");
                if (Block4HiddenFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblNotVisible")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block4HiddenFields)
                {
                    Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));      
                }%>
                </table>
                <%}

                //
                // Block 4 Displayed Fields
                //  
                if (Block4RelatedFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblDisplayedFields")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblLookupTable") %></th><th><%:myWF.getResource("lblControlType") %></th><th><%:myWF.getResource("lblParameter")%></th><th><%:myWF.getResource("lblDefaultValue") %></th><th><%:myWF.getResource("lblRequired") %></th><th><%:myWF.getResource("lblReadOnly") %></th><th><%:myWF.getResource("lblLabel") %></th><th><%:myWF.getResource("lblHelp") %></th></tr>

                <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block4RelatedFields)
                   {
                       Response.Write(myWF.DisplayedFieldsTableHTMLOutput(afr, Session["DBLang"].ToString()));
                   }%>
                </table>
                <%}
                  
                   //Related Fields Layout
                    if (Block4RelatedFields.Length > 0)
                    {%>
                <p><strong><%: myWF.getResource("lblLayout") %></strong></p>
                <% Response.Write(myWF.PrntScreenTop(myACSeries, Session["DBLang"].ToString()));
                 
                   foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block4RelatedFields)
                   { Response.Write(myWF.LayoutHTMLOutput(afr, Session["DBLang"].ToString())); }
                    
                   Response.Write(myWF.PrntScreenBottom());
                    }
                    
                    //Processing for Block 4
                lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk4Proc = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block4processing");
                if (acdocrBlk4Proc != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block4processing',<%Response.Write(acdocrBlk4Proc.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk4Proc.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk4Proc["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblProcessing") %>/strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block4processing',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>
                    
                    
                    </div><br />
                <%}
                  
                  
                //
                // Block 5 Used Records
                //
                
                
                if (Block5.Length > 0)
                {%>
                <div class="stpLnk2"><a name="Block5"></a><img alt="" src="images/metadata.png" /><strong><%: myWF.getResource("lblBlock5") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  
                  <%
                 //Purpose for Block 5
         
                     lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk5 = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block5purpose");
                     if (acdocrBlk5 != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block5purpose',<%Response.Write(acdocrBlk5.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk5.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk5["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block5purpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                        </p><div class="clear"></div>
                     <%}
                
                 //Block 5 Used Records
                       
                lmDatasets.ActivityConfig.ActivityFieldRow[] Block5UsedRecords = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=4 and tasktype<>'F'", "Seq");
                if (Block5UsedRecords.Length > 0)
                {%>
                 <p><% Response.Write(myWF.getResource("lblUsedRecordInit")); %></p>
               <table class="module-versatile2"><tr><th><%:myWF.getResource("lblTask") %></th><th><%:myWF.getResource("lblTable") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblObjectAlias") %></th><th><%:myWF.getResource("lblParentRow") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block5UsedRecords)
               {
                   Response.Write(myWF.UsedRecordsHTMLOutput(afr, Session["DBLang"].ToString()));
                }%>
                </table>
                <%}

                //
                // Block 5 Hidden Fields
                //    

                lmDatasets.ActivityConfig.ActivityFieldRow[] Block5HiddenFields = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step=4 and tasktype='F' and visible=false", "Seq");
                if (Block5HiddenFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblNotVisible")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblDefaultValue") %></th></tr>

               <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block5HiddenFields)
                {
                    Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));      
                }%>
                </table>
                <%}

                //
                // Block 5 Displayed Fields
                //  
                if (Block5RelatedFields.Length > 0)
                {%>
                <p><% Response.Write(myWF.getResource("lblDisplayedFields")); %></p>
                <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject") %></th><th><%:myWF.getResource("lblField") %></th><th><%:myWF.getResource("lblLookupTable") %></th><th><%:myWF.getResource("lblControlType") %></th><th><%:myWF.getResource("lblParameter")%></th><th><%:myWF.getResource("lblDefaultValue") %></th><th><%:myWF.getResource("lblRequired") %></th><th><%:myWF.getResource("lblReadOnly") %></th><th><%:myWF.getResource("lblLabel") %></th><th><%:myWF.getResource("lblHelp") %></th></tr>

                <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block5RelatedFields)
                   {
                       Response.Write(myWF.DisplayedFieldsTableHTMLOutput(afr, Session["DBLang"].ToString()));
                   }%>
                </table>
                <%} 
                  
                  //Related Fields Layout
                    if (Block5RelatedFields.Length > 0)
                    {%>
                <p><strong><%: myWF.getResource("lblLayout") %></strong></p>
                <% Response.Write(myWF.PrntScreenTop(myACSeries, Session["DBLang"].ToString()));
                 
                   foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in Block5RelatedFields)
                   { Response.Write(myWF.LayoutHTMLOutput(afr, Session["DBLang"].ToString())); }
                    
                   Response.Write(myWF.PrntScreenBottom());
                    }
                    
                     //Processing for Block 5
                lmDatasets.ActivityConfig.ACDocumentationRow acdocrBlk5Proc = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "block5processing");
                if (acdocrBlk5Proc != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','block5processing',<%Response.Write(acdocrBlk5Proc.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrBlk5Proc.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrBlk5Proc["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','block5processing',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>

                    </div><br />
                <%}

                 //
                // Document Block 
                //
                
                if (DocBlock.Length > 0)
                {%>
                <div class="stpLnk2"><a name="DocBlock"></a><img alt="" src="images/doc2.png" /><strong><%: myWF.getResource("lblDocDisp") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  
                <%
                 //Purpose for Block 4
         
                     lmDatasets.ActivityConfig.ACDocumentationRow acdocrDocBlk = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "docblockpurpose");
                     if (acdocrDocBlk != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','docblockpurpose',<%Response.Write(acdocrDocBlk.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrDocBlk.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrDocBlk["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','docblockpurpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                        </p><div class="clear"></div>
                     <%}%>


                

                <%
                    //find BaseDocument
                    lmDatasets.ActivityConfig.ActivityFieldRow[] BaseDoc = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and tasktype='F' and step=10 and (defaultobjectname is not null or defaultvalue is not null) and (objectalias='Document0' or objectalias='DocContent0')", "Seq");
                    if (BaseDoc.Length > 0)
                    {
                     %>
                     <p><% Response.Write(myWF.getResource("lblBaseDocPar")); %></p>
                     <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject")%></th><th><%:myWF.getResource("lblField")%></th><th><%:myWF.getResource("lblDefaultValue")%></th></tr>

                   <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in BaseDoc)
                      {
                          Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));
                      }%>
                    </table>

                    <%}
                      // look for mail connectors leading to step
                      string sReplyFwd = "";
                      foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in myACSeries.GetACDependencyRowsByPreviousSteps())
                      {
                          if (acdr.LinkType == (int)atriumBE.ConnectorType.Reply || acdr.LinkType == (int)atriumBE.ConnectorType.ReplyAll || acdr.LinkType == (int)atriumBE.ConnectorType.Forward)
                          {
                              //we have a mail connector; add new recipient type 1 and indicate which activity's type 0 recipient this mail will reply/replyall/forward to
                              switch (acdr.LinkType)
                              {
                                  case (int)atriumBE.ConnectorType.Reply:
                                      sReplyFwd += "<div><img alt=\"\" src=\"images/mailconnectors.png\"/>" + myWF.getResource("lblAutoReply") + " <a href=\"step.aspx?acseriesid=" + acdr.ACSeriesRowByNextSteps.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acdr.ACSeriesRowByNextSteps.StepCode + "</a></div>";
                                      break;
                                  case (int)atriumBE.ConnectorType.ReplyAll:
                                      sReplyFwd += "<div><img alt=\"\" src=\"images/mailconnectors.png\"/>" + myWF.getResource("lblAutoReplyAll") + " <a href=\"step.aspx?acseriesid=" + acdr.ACSeriesRowByNextSteps.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acdr.ACSeriesRowByNextSteps.StepCode + "</a></div>";
                                      break;
                                  case (int)atriumBE.ConnectorType.Forward:
                                      sReplyFwd += "<div><img alt=\"\" src=\"images/mailconnectors.png\"/>" + myWF.getResource("lblFwd") + " <a href=\"step.aspx?acseriesid=" + acdr.ACSeriesRowByNextSteps.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acdr.ACSeriesRowByNextSteps.StepCode + "</a></div>";
                                      break;
                              }
                          }
                      }

                      if (sReplyFwd != "")
                      {
                          Response.Write(myWF.getResource("lblHasMailConnector")); 
                          Response.Write(sReplyFwd);
                          Response.Write("<br/>");
                      }
                     
                        
                        //Are there any recipients?
                    lmDatasets.ActivityConfig.ActivityFieldRow[] docRecipients = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step='10' and objectname='Recipient'", "Seq");
                    if (docRecipients.Length > 0)
                    {
                         %>
                         <p><% Response.Write(myWF.getResource("lblRecipientVals"));%></p>
                          <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject")%></th><th><%:myWF.getResource("lblField")%></th><th><%:myWF.getResource("lblDefaultValue")%></th></tr>

                   <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in docRecipients)
                      {
                          Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));
                      }%>
                    </table>

                    <%}
                      
                    //Are there any attachments?
                    List<string> docAttObjects = new List<string>();
                    lmDatasets.ActivityConfig.ActivityFieldRow[] docAttach = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and tasktype<>'F' and objectname='Document' and objectalias<>'Document0'", "Seq");
                    lmDatasets.ActivityConfig.ActivityFieldRow[] docAttachFlds = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and tasktype='F' and objectname='Document' and objectalias<>'Document0'", "Seq");
                    if (docAttach.Length > 0)
                    {
                        
                        string AttachOutput = "";
                        foreach (lmDatasets.ActivityConfig.ActivityFieldRow docObj in docAttach)
                        {
                            if (!docAttObjects.Contains(docObj.ObjectAlias))
                            {
                                docAttObjects.Add(docObj.ObjectAlias);
                                if (AttachOutput == "")
                                    AttachOutput = docObj.ObjectAlias;
                                else
                                    AttachOutput += ", " + docObj.ObjectAlias;
                            }
                        }
                         %>
                         <p><% Response.Write(myWF.getResource("lblAttachedDocs")); %> <strong><%:AttachOutput%></strong></p>
                         
                         <% 
                        if (docAttachFlds.Length > 0)
                        {%>
                          <p><%: myWF.getResource("lblAttachmentVals") %></p>
                          <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject")%></th><th><%:myWF.getResource("lblField")%></th><th><%:myWF.getResource("lblDefaultValue")%></th></tr>
                        <%
                             
                            foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in docAttachFlds)
                            {
                                Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));
                            }
                            %>
                            </table>
                        <%}%>
                    
                    <%} %>

                    <table class="naw docnaw">
                    <tr><td class="nawTL"></td><td class="nawT"></td><td class="nawTR"></td></tr>
                    <tr><td class="nawL"></td><td class="ttlBar"><div class="ttlBarLeft"><img alt="" src="images/nawicon.png" /><%:myACSeries.StepCode%> - <%:myACSeries["ActivityName" + Session["DBLang"].ToString()]%></div><div class="ttlBarRight"><img alt="" src="images/toolbox.png" /></div></td><td class="nawR"></td></tr>
                    <tr>
                        <td class="nawL"></td>
                        <td class="docheader">
                            <div id="docRecs">
                             <% 
                            string dRec = "";
                            foreach (lmDatasets.ActivityConfig.ActivityFieldRow rr in docRecipients)
                            {
                                if(rr.FieldName.ToUpper() == "ADDRESS") //display defaults
                                {
                                    string vVal = "";
                                    if (rr.IsDefaultValueNull())
                                        vVal = rr.DefaultObjectName + "/" + rr.DefaultFieldName;
                                    else
                                        vVal = rr.DefaultValue;
                                                                        
                                    if (dRec == "")
                                        dRec = "{ " + vVal + " }";
                                    else
                                        dRec += ", { " + vVal + " }";
                             
                                }
                            }
                    
                            Response.Write(dRec);%>
                            </div>
                            <div id="docMail">
                            <%
                                string dMail = "";
                            if(myACSeries.ActivityCodeRow.Communication) //display mail flag
                            {
                                dMail = "<img alt=\"\" src=\"images/outlook2010.png\"/>";
                            }

                            lmDatasets.ActivityConfig.ActivityFieldRow[] doc0Subject = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and objectalias='Document0' and fieldname='efSubject' and tasktype='F'", "Seq");
                            if (doc0Subject.Length == 1 && !doc0Subject[0].IsDefaultValueNull())
                            {
                                dMail += doc0Subject[0].DefaultValue;
                            }
                            
                            Response.Write(dMail);%>
                            </div>
                            <div id="docAttachments">
                            <%
                            string attHTML = "";
                            foreach (string docObject in docAttObjects)
                            {
                                attHTML += "<div class=\"attachObject\">{ " + docObject + " }</div>";
                            }
                            Response.Write(attHTML);   
                             %>
                            </div>
                        </td>
                        <td class="nawR"></td>
                    </tr>
                    <tr>
                        <td class="nawL"></td>
                        <td class="doccontent">
                        
                        <%
                        lmDatasets.ActivityConfig.ActivityFieldRow[] doc0Template = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and objectalias='Document0' and fieldname='TemplateCode' and tasktype='F'", "Seq");
                        if (doc0Template.Length>0 && !doc0Template[0].IsDefaultValueNull())
                        {%>
                        <div id="docTemplate"><a href="docdisplay.aspx?fileid=1028654&templatecode=<%:doc0Template[0].DefaultValue %>" class="tmplt2"><img alt="" src="images/word.png"/><%:myWF.getResource("lblViewDoc") %> <%: doc0Template[0].DefaultValue%></a></div>
                        <%} %>
                        
                        </td>
                        <td class="nawR"></td>
                    </tr>
                    <tr>
                        <td class="nawL"></td>
                        <td><br />
                            <div class="footerBtnBar"><img alt="" src="images/btnSuspendOn.png" /><img alt="" src="images/btnCancelOn.png" /><img alt="" src="images/btnBackOn.png" /><img alt="" src="images/btnNextOn.png" /><img alt="" src="images/btnLastOn.png" /><img alt="" src="images/btnFinishOn.png" /></div>
                        </td>
                        <td class="nawR"></td>
                    </tr>
                    <tr>
                        <td class="nawBL"> </td>
                        <td class="nawB"> </td>
                        <td class="nawBR"> </td>
                    </tr>
                    </table>


                    <%
                    //Processing for Doc Block
                lmDatasets.ActivityConfig.ACDocumentationRow acdocrDocProc = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "docprocessing");
                if (acdocrDocProc != null) 
                     {%>
                        <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                        <%if ((bool)Session["isEditMode"]){ %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','docprocessing',<%Response.Write(acdocrDocProc.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrDocProc.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrDocProc["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                     else if((bool)Session["isEditMode"])
                     {%>
                            <p><strong><%: myWF.getResource("lblProcessing") %></strong>
                            <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','docprocessing',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a></p>
                            <div class="clear"></div>
                     <%}%>


                </div><br />
                <%} %>


                 <%if (SchedulingBlock.Length > 0)
                   {%>
                <div class="stpLnk2"><a name="SchedulingBlock"></a><img alt="" src="images/bflistcalendar.png" /><strong><%: myWF.getResource("lblSchedBlock")%></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  
                <%
                       //Purpose for Scheduling block

                       lmDatasets.ActivityConfig.ACDocumentationRow acdocrSchdlBlk = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "schedulingblockpurpose");
                       if (acdocrSchdlBlk != null)
                       {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <%if ((bool)Session["isEditMode"])
                          { %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','schedulingblockpurpose',<%Response.Write(acdocrSchdlBlk.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrSchdlBlk.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrSchdlBlk["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                       else if ((bool)Session["isEditMode"])
                       {%>
                        <p><strong><%: myWF.getResource("lblPurpose") %></strong>
                        <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','schedulingblockpurpose',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                        </p><div class="clear"></div>
                     <%}%>


                <p><% Response.Write(myWF.getResource("lblSchedDefaults")); %></p>
                <%
                    lmDatasets.ActivityConfig.ActivityFieldRow[] apptRows = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step='12' and objectname='Appointment'", "Seq");
                    
                     %>
                     <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject")%></th><th><%:myWF.getResource("lblField")%></th><th><%:myWF.getResource("lblDefaultValue")%></th></tr>

                   <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in apptRows)
                    {
                        Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));      
                    }%>
                    </table>

                     <%
                        //Are there any attendees?
                    lmDatasets.ActivityConfig.ActivityFieldRow[] apptAttendees = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and step='12' and objectname='Attendee'", "Seq");
                    if (apptAttendees.Length > 0)
                    {   
                         %>
                         <p><% Response.Write(myWF.getResource("lblAttendeeDefaults")); %></p>
                          <table class="module-versatile2"><tr><th><%:myWF.getResource("lblObject")%></th><th><%:myWF.getResource("lblField")%></th><th><%:myWF.getResource("lblDefaultValue")%></th></tr>

                   <% foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in apptAttendees)
                      {
                          Response.Write(myWF.HiddenFieldsHTMLOutput(afr, Session["DBLang"].ToString()));
                      }%>
                    </table>

                    <%}%>
                    <p><strong><%:myWF.getResource("lblLayout") %></strong></p>
                    <table class="naw schdlnaw">
                    <tr><td class="nawTL"></td><td class="nawT"></td><td class="nawTR"></td></tr>
                    <tr><td class="nawL"></td><td class="ttlBar"><div class="ttlBarLeft"><img alt="" src="images/nawicon.png" /><%:myACSeries.StepCode%> - <%:myACSeries["ActivityName" + Session["DBLang"].ToString()]%></div><div class="ttlBarRight"><img alt="" src="images/toolbox.png" /></div></td><td class="nawR"></td></tr>
                    <tr>
                    <td class="nawL"></td>
                    <td class="schdlHead">
                        <div id="defSubject">
                    <%
                    lmDatasets.ActivityConfig.ActivityFieldRow[] apptSubject = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + myACSeries.ACSeriesId.ToString() + " and objectname='Appointment' and fieldname='Subject'", "Seq");
                    if (apptSubject.Length == 1 && !apptSubject[0].IsDefaultValueNull())
                        Response.Write("{ " + apptSubject[0].DefaultValue + " }");
                    %>
                        </div>
                    </td>
                    <td class="nawR"></td>
                    </tr>
                    <tr>
                    <td class="nawL"></td>
                    <td class="schdlTimeline">
                        <div id="defAttendees">
                    <%
                    List<string> attendeeObjects = new List<string>();
                    string AttachOutput = "";
                    foreach (lmDatasets.ActivityConfig.ActivityFieldRow attendeeObj in apptAttendees)
                    {
                        if (!attendeeObjects.Contains(attendeeObj.ObjectAlias))
                        {
                            attendeeObjects.Add(attendeeObj.ObjectAlias);
                            AttachOutput += "<div class=\"apptAtt\">{ " + attendeeObj.ObjectAlias + " }</div>";
                        }
                    }


                    Response.Write(AttachOutput);
                    %>
                        </div>
                    </td>
                    <td class="nawR"></td>
                    </tr>
                     <tr>
                        <td class="nawL"></td>
                        <td><br />
                            <div class="footerBtnBar"><img alt="" src="images/btnSuspendOn.png" /><img alt="" src="images/btnCancelOn.png" /><img alt="" src="images/btnBackOn.png" /><img alt="" src="images/btnNextOn.png" /><img alt="" src="images/btnLastOn.png" /><img alt="" src="images/btnFinishOn.png" /></div>
                        </td>
                        <td class="nawR"></td>
                    </tr>
                    <tr><td class="nawBL"></td><td class="nawB"></td><td class="nawBR"></td></tr>
                    </table>


                    </div><br />
                <%} %>

                <div class="stpLnk2"><a name="FinishBlock"></a><strong><img alt="" src="images/save.png" /><%: myWF.getResource("lblOnFinish") %></strong></div>
                <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><%:myWF.getResource("backToTop") %></a></div>
                <div class="clear"></div>
                <div class="bx">  
                <%//Purpose for Finish block

                       lmDatasets.ActivityConfig.ACDocumentationRow acdocrFinishBlk = myWF.AcDocRow(myACSeries.Table.TableName.ToLower(), myACSeries.ACSeriesId, "finishblock");
                       if (acdocrFinishBlk != null)
                       {%>
                        <p><strong><%: myWF.getResource("lblNote") %></strong>
                        <%if ((bool)Session["isEditMode"])
                          { %>
                        <a class="aEdit" href="javascript:launchAcDocNote(false,'','','finishblock',<%Response.Write(acdocrFinishBlk.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit")%></a>
                        <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocrFinishBlk.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete")%></a><%} %>
                        </p>
                        
            
                        <p><%Response.Write(acdocrFinishBlk["Text" + Session["DBLang"].ToString()]); %></p>
                        <br />
                        <%}
                       else if ((bool)Session["isEditMode"])
                       {%>
                        <p><strong><%: myWF.getResource("lblNote") %></strong>
                        <a class="aEdit2" href="javascript:launchAcDocNote(true,'acseries','<%: myACSeries.ACSeriesId%>','finishblock',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a>
                        </p><div class="clear"></div>
                     <%}%>

                     <%
                         bool hasBFs=false;
                         string bfOutput = "";
                         //get array so it can be sorted by acbfid to group matching bfonly connectors
                         lmDatasets.ActivityConfig.ACDependencyRow[] acda = (lmDatasets.ActivityConfig.ACDependencyRow[])myWF.myACM.DB.ACDependency.Select("CurrentStepId=" + myACSeries.ACSeriesId, "ACBFId");
                         int acbfid = 0;
                         foreach(lmDatasets.ActivityConfig.ACDependencyRow acdpr in acda)
                         {
                             if (!acdpr.IsACBFIdNull() && (acdpr.LinkType == (int)atriumBE.ConnectorType.NextStep || acdpr.LinkType == (int)atriumBE.ConnectorType.BFOnly))
                             {
                                 
                                 lmDatasets.ActivityConfig.ACBFRow[] bfr = (lmDatasets.ActivityConfig.ACBFRow[])myWF.myACM.DB.ACBF.Select("ACBFId=" + acdpr.ACBFId, "BFCode");
                                 if(bfr.Length==1)
                                 {
                                     hasBFs=true;
                                     if (acbfid == acdpr.ACBFId)
                                     {
                                         //same BFCode 
                                         string vbf = "<tr><td class=\"tbfo\" colspan=\"7\">" + acdpr.ACSeriesRowByPreviousSteps.StepCode + "</td></tr>";
                                         if (bfOutput == "")
                                             bfOutput = vbf;
                                         else
                                             bfOutput += vbf;
                                             
                                     }
                                     else
                                     {
                                         acbfid = acdpr.ACBFId;
                                     
                                         string ConnType="";
                                         string CompletedBy = myWF.getResource("lblNextStepBF");
                                         if (acdpr.LinkType == (int)atriumBE.ConnectorType.NextStep)
                                             ConnType = "<strong>" + myWF.getResource("lblNextStepBF") + "</strong>";
                                         else if (acdpr.LinkType == (int)atriumBE.ConnectorType.BFOnly)
                                         {
                                             ConnType = "<strong>" + myWF.getResource("lblBFOnlyBF") + "</strong>";
                                             CompletedBy = acdpr.ACSeriesRowByPreviousSteps.StepCode;
                                         }
                                         string vbf = "<tr><td class=\"nbrdr\">" + ConnType + "</td>";
                                         vbf += "<td class=\"nbrdr\">" + myWF.getBFType(bfr[0].BFType) + "</td>";
                                         vbf += "<td class=\"nbrdr\">" + bfr[0]["BFDescription" + Session["DBLang"].ToString()] + "</td>";
                                         vbf += "<td class=\"nbrdr\">" + bfr[0].BFDate + "</td>";

                                         if (bfr[0].IsRoleCodeNull())
                                         {
                                             vbf += "<td class=\"nbrdr\"> </td>";
                                             vbf += "<td class=\"nbrdr\"> </td>";
                                         }
                                         else
                                         {
                                             string roleType = myWF.getRoleType(bfr[0].RoleCode, true, Session["DBLang"].ToString());
                                             vbf += "<td class=\"nbrdr\">" + roleType + "</td>";
                                             string roleLnk = myWF.getRoleDesc(bfr[0].RoleCode, Session["DBLang"].ToString());
                                             if (roleType.ToLower() != "global")
                                                 vbf += "<td class=\"nbrdr\">" + myWF.getRoleDesc(bfr[0].RoleCode, Session["DBLang"].ToString()) + "</td>";
                                             else
                                                 vbf += "<td class=\"nbrdr\"><a href=\"javascript:launchGlobalRole('" + bfr[0].RoleCode + "');\">" + myWF.getRoleDesc(bfr[0].RoleCode, Session["DBLang"].ToString()) + "</td>";
                                         }
                                         vbf += "<td class=\"nbrdr\">" + CompletedBy + "</td></tr>";
                                         if (bfOutput == "")
                                             bfOutput = vbf;
                                         else
                                             bfOutput += vbf;
                                     }
                                 }
                             }
                         }
                         if (hasBFs)
                         {%>
                           <p><strong><%: myWF.getResource("lblBFsCreated") %></strong></p>
                           <table class="module-versatile4">
                           <tr><th><%: myWF.getResource("lblConnector")%></th><th><%: myWF.getResource("lblBFType")%></th><th><%: myWF.getResource("lblBFDesc")%></th><th><%: myWF.getResource("lblBFDate")%></th><th><%: myWF.getResource("lblRoleType")%></th><th><%: myWF.getResource("lblBFRole")%></th><th><%: myWF.getResource("lblCompletedBy")%></th></tr>
                           <%Response.Write(bfOutput); %>
                           </table>
                           <div class="clear"></div>
                         <%}
                          %>
                           <!-- NEXT STEPS -->         
         <%if (myWF.NextSteps(myACSeries).Length > 0)
           { %>
           
           <p><strong><%: myWF.getResource("lblNextSteps") %></strong></p>
           <div class="dvindnt nxtStps">
           
            <%
               System.Xml.XmlDocument xmldoc = myWF.GetNextSteps(myACSeries, Session["DBLang"].ToString());
               string htmlOutput = myWF.NextStepsHtmlOutput(xmldoc, Session["DBLang"].ToString());
               
               Response.Write(htmlOutput);
               %>
                </div><div class="clear"></div>
        <%} %>
                </div>




</asp:Content>
