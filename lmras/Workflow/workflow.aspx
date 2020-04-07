<%@ Page Title="" Language="C#" MasterPageFile="~/Workflow/wf.Master" AutoEventWireup="true" CodeBehind="workflow.aspx.cs" Inherits="lmras.Workflow.workflow" %>
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

    if ((string)Session["userLang"] == "en")
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
    string sc = Request.QueryString["seriescode"];
    string id = Request.QueryString["seriesid"];
    if (sc == null && id == null)
    {
        Response.Redirect("list.aspx", true); 
    }


    string vList = "<a href=\"List.aspx\" class=\"hm\">"+myWF.getResource("AllFlows")+"</a>";
    string homelnk = vList + " / <img alt=\"\" src=\"images/workflow.gif\"/>" + mySeries.SeriesCode + " - " + mySeries["SeriesDesc" + Session["DBLang"].ToString()];
    
    Response.Write(homelnk);
    
    %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%
    SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> PossibleOutputPaths = myWF.GetOutputPaths(mySeries);
    
    System.Data.DataTable dt = myWF.myACM.AtMng.GetFile().Codes("SeriesType");
    System.Data.DataRow[] dr = dt.Select("SeriesTypeCode='" + mySeries.SeriesTypeCode + "'", "");

%>

    <!--
    //
    //  WORKFLOW PROPERTIES
    //
    -->
    <h2><%:myWF.getResource("WFProps") %></h2>
    <div style="margin-bottom:36px;">
        <table class="module-versatile">
        <tr>
            <td><asp:Label ID="Label3" Runat="server" Text="<%$ Resources:LocalizedText, WFCode %>"></asp:Label>:</td>
            <td><%:mySeries.SeriesCode %></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" Runat="server" Text="<%$ Resources:LocalizedText, WFEnglishDesc %>"></asp:Label>:</td>
            <td><%:mySeries.SeriesDescEng %></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" Runat="server" Text="<%$ Resources:LocalizedText, WFFrenchDesc %>"></asp:Label>:</td>
            <td><%:mySeries.SeriesDescFre %></td>
        </tr>
        </table>
        <br />
        <%
         //check for Series Objective   
         
         lmDatasets.ActivityConfig.ACDocumentationRow acdocr = myWF.AcDocRow(mySeries.Table.TableName.ToLower(), mySeries.SeriesId, "seriesobjective");
         if (acdocr != null) 
         {%>
            <div class="stpLnk"><strong><%:myWF.getResource("acdocWFObjective") %></strong> 
            <%if ((bool)Session["isEditMode"]){ %>
            <a class="aEdit" href="javascript:launchAcDocNote(false,'','','seriesobjective',<%Response.Write(acdocr.ACDocId); %>);"><img alt="" src="images/edit.png" /><%:myWF.getResource("acdocEdit") %></a>
            <a class="aEdit" href="javascript:deleteAcDocNote(<%Response.Write(acdocr.ACDocId); %>);"><img alt="" src="images/delete.png" /><%:myWF.getResource("acdocDelete") %></a>
            <%} %></div>

            <div class="clear"></div>
            <div style="border:1px solid #aaaaaa;background-color:#f6f6f6;padding:6px;margin-top:2px;">
                <p><%Response.Write(acdocr["Text"+Session["DBLang"].ToString()]); %></p>
            </div><br />
            <%}
         else if((bool)Session["isEditMode"])
         {%>
                <div class="stpLnk stpLnk3"><strong><a href="javascript:launchAcDocNote(true,'series','<%: mySeries.SeriesId%>','seriesobjective',null);"><img alt="" src="images/newrecord.gif" /><%:myWF.getResource("acdocAdd") %></a> <%:myWF.getResource("acdocWFObjective") %></strong></div><div class="clear"></div>
         <%}%>




        <% if (!mySeries.IsHelpTextENull() || !mySeries.IsHelpTextFNull())
           {%>
        <table>
        <tr>
            <td><%:myWF.getResource("WFHelpTextEng") %>:</td>
            <td><%:!mySeries.IsHelpTextENull() ? mySeries.HelpTextE : ""%></td>
        </tr>
        <tr>
            <td><%:myWF.getResource("WFHelpTextFre") %>:</td>
            <td><%:!mySeries.IsHelpTextFNull() ? mySeries.HelpTextF : ""%></td>
        </tr>

        </table>
        <%} %>


        <!--ALLOW MOVE-->
        <% if (mySeries.AllowMove){%>
            <p><img src="images/movefolder.gif" alt="" /><%:myWF.getResource("lblCanBeMoved") %> (<%:myWF.getResource("lblSee") %> <a href="javascript:alert('Link to deskbook not implemented');return false;"><%:myWF.getResource("lblRestrictions")%></a>).</p>
        <%}%>

        <!--ALWAYS AVAILABLE-->
        <% if (mySeries.AlwaysAvailable)
           {%>
            <p><img src="images/alwaysavailable.png" alt="" /><%:myWF.getResource("lblAlwaysAvailable")%></p>
        <%}%>

        <!--CREATES FILE-->
          <% if (mySeries.CreatesFile){%>
            <p><img src="images/NewFile.png" alt="" /><%:mySeries.SeriesCode %> <%:myWF.getResource("lblCreatesFile")%>
        

        <% if (!mySeries.IsContainerFileIdNull())
           {
               atriumBE.FileManager fm = myWF.myACM.AtMng.GetFile(mySeries.ContainerFileId);
               %>
            <%:myWF.getResource("lblContainer")%> <strong><%:fm.CurrentFile.FullFileNumber%> (<%:fm.CurrentFile.Name%>)</strong></p>
        <%}
           else
           {
          %>
            <%:myWF.getResource("lblContainerNotDefined")%></p>
          <%} %>

          <%} %>
      

        <% if (mySeries.OncePerFile){%>
            <p><img src="images/onceperfile.png" alt="" /><%:mySeries.SeriesCode %> <%:myWF.getResource("lblAllowOnce")%></p>
        <%} %>

        <!--</div>-->
        <div class="clear"></div><br />

        <!--
        //
        //  WORKFLOW STEPS
        //
        -->

        <!-- quick jump -->
        <%
            string obsChecked = "";
            if ((bool)Session["includeObsPaths"])
                obsChecked = " checked=\"true\" ";
        %>
        <div class="stpLnk"><strong><%:myWF.getResource("lblContents")%></strong></div><div id="includeObsolete"><a id="aIncObs" href="javascript:obsCheck();"><img src="images/obsolete.png" alt="" /><%:myWF.getResource("lblIncObsolete")%></a><input type="checkbox" <% Response.Write(obsChecked); %> id="incObs" onclick="IncObsChk(this.checked)"/> </div><em id="incObsReload" class="obsReload"><img alt="" src="images/refresh.png" /><%:myWF.getResource("lblReloading")%></em><div class="clear"></div>
        <div style="border:1px solid #aaaaaa;background-color:#f6f6f6;padding:6px;margin-top:2px;">
        <%
            
            string acQuickJmp = "";
            SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> ListOfActivities = myWF.GetAllSteps(mySeries, (bool)Session["includeObsPaths"]);
            foreach (lmDatasets.ActivityConfig.ACSeriesRow acs in ListOfActivities.Values)
            {
                string acSuffix = "";
                if (!acs.IsDescEngNull() && !acs.IsDescFreNull())
                    acSuffix = " <em>" + acs["Desc" + Session["DBLang"].ToString()] + "</em>";
                acQuickJmp += "<a href=\"#"+acs.StepCode+"\" class=\"ail\"><img src=\"images/workflow.png\" alt=\"\" />"+acs.StepCode+" - "+ acs["ActivityName"+Session["DBLang"].ToString()]+ acSuffix +"</a><br/>";
            }
            Response.Write(acQuickJmp);
        %>
        </div><div class="clear"></div>


        <h2><a name="steps"></a><%:myWF.getResource("lblRecordedSteps")%> <%:mySeries.SeriesCode %></h2>
        <%
            //foreach (lmDatasets.ActivityConfig.ACSeriesRow acs in myWF.myACM.DB.ACSeries.Select("StepType=0 and Obsolete=0 and SeriesId=" + mySeries.SeriesId.ToString(), "StepCode"))
            foreach (lmDatasets.ActivityConfig.ACSeriesRow acs in ListOfActivities.Values)
            {%>
        <div style="margin-bottom:36px;">
        
        <div class="stpLnk"><strong><a name="<%:acs.StepCode %>" href="step.aspx?acseriesid=<%: acs.ACSeriesId%>"><img src="images/act.png" alt="" /><%:acs.StepCode%> - <%:acs["ActivityName" + Session["DBLang"].ToString()]%> <em><%:acs["Desc" + Session["DBLang"].ToString()]%></em></a></strong></div>
        <div class="btt"><a href="#"><img alt="" src="images/arrow-up.png" /><asp:Label ID="Label5" Runat="server" Text="<%$ Resources:LocalizedText, backToTop %>"></asp:Label></a></div>
        <div class="clear"></div>
        <div style="border:1px solid #aaaaaa;background-color:#f6f6f6;padding:6px;margin-top:2px;">

        <%
             //
             // is Start, Finish or both
             //
             
                string sOutput = "";
                string noResurface = "<p><img alt=\"\" src=\"images/noresurface2.png\" />This end point will not resurface to its parent process.</p>";
                if (acs.Start && acs.Finish)
                {
                    sOutput = "<img alt=\"\" src=\"images/workflowstart.png\" class=\"mid\"/>" + acs.StepCode + myWF.getResource("lblStartFinish") + " <img alt=\"\" src=\"images/worklfowend.png\" class=\"mid\"/>";
                    
                     if (acs.Finish && acs.NoResurface)
                         sOutput += noResurface;
                }
                else if (acs.Start || myWF.isStepFirstRecordedStep(acs))
                {
                    sOutput = "<img alt=\"\" src=\"images/workflowstart.png\" class=\"mid\"/>" + acs.StepCode + myWF.getResource("lblStart");
                }
                else if (acs.Finish)
                {
                    sOutput = "<img alt=\"\" src=\"images/worklfowend.png\" class=\"mid\"/>" + acs.StepCode + myWF.getResource("lblFinish");
                    if (acs.Finish && acs.NoResurface)
                        sOutput += noResurface;
                }
                
         %>
         <%if (sOutput.Length>0) %>
         <%{ %>
            <% %>
            <div class="stepstart"><%Response.Write(sOutput);%></div><div class="clear"></div>
            <%if (acs.Start || myWF.isStepFirstRecordedStep(acs))
              {
                  bool isAccessible = false;
                  %>
                
                <!-- 
                --------------------------------------
                    HOW ACCESSED 
                --------------------------------------
                -->


                <p><strong><%:myWF.getResource("lblHowAccessed")%></strong></p>
                
                <div class="dvindnt">
                
                <% if (mySeries.AlwaysAvailable) //ALWAYS AVAILABLE
                   {
                       isAccessible = true;
                           %>

                    <p><img src="images/alwaysavailable.png" alt="" /><%Response.Write(myWF.getResource("lblAlwAvailTab"));%></p>       
                   
                <%}%>
                 
                 
                 <% if (acs.GetOfficeMandateRows().Length > 0) // available from mandate
                  {
                      isAccessible = true;
                      string OfficeConcat = "";
                      foreach (lmDatasets.ActivityConfig.OfficeMandateRow mr in acs.GetOfficeMandateRows())
                      {
                          lmDatasets.officeDB.OfficeRow or =  myWF.myACM.AtMng.GetOffice().GetOffice().Load(mr.OfficeId);
                          if(OfficeConcat=="")
                              OfficeConcat = or.OfficeCode;
                          else
                              OfficeConcat += ", " + or.OfficeCode;
                      }
                          
                      %>
                    <p><img src="images/mandates.gif" alt="" /><%:myWF.getResource("lblMandatesBtn") %> <%:OfficeConcat %></p>
                    

                <%} %>


                <%
                    
                  if (acs.GetACConvertRowsByACSeries_ACConvert1().Length > 0) //convert from mail
                  {
                      foreach (lmDatasets.ActivityConfig.ACConvertRow accr in acs.GetACConvertRowsByACSeries_ACConvert())
                      {
                          if (accr.AllowableACSeriesId == myWF.myACM.AtMng.GetSetting(atriumBE.AppIntSetting.ImportedMailCodeAcId))
                          {
                              Response.Write("<p>[TODO: Convert from mail]</p>");
                                      
                          } 
                      } 
                  }
                         
                 %>

                <% if (acs.GetACMenuRows().Length>0)  // available from ACMenu
                  {
                      isAccessible = true;
                      string AcMenuConcat = "";
                      foreach (lmDatasets.ActivityConfig.ACMenuRow acmr in acs.GetACMenuRows())
                      {
                          //possible menu values are:
                          //FileNew
                          //Activity
                          //Timekeep
                          string menu;
                          switch(acmr.Menu)
                          {
                              case "FileNew":
                                  menu="<img alt=\"\" src=\"images/apptreeexplorer.png\"/>"+myWF.getResource("lblAtExp");
                                  break;
                              case "Activity":
                                  menu = "<img alt=\"\" src=\"images/screen.gif\"/>"+myWF.getResource("lblActionsMnu");
                                  break;
                              case "Timekeep":
                                  menu = "<img alt=\"\" src=\"images/clock.png\"/>" + myWF.getResource("lblActionsTK");
                                  break;
                              default:
                                  menu=myWF.getResource("lblInvalidMenu");
                                  break;
                          }
                          //acmr.Menu
                          if (AcMenuConcat == "")
                              AcMenuConcat = menu;
                          else
                              AcMenuConcat += ", " + menu;
                      }
                          
                      %>

                    <p><img src="images/dd.png" alt="" /><%Response.Write(myWF.getResource("lblDDCntxtMenu") + " " + AcMenuConcat); %></p>
                    

                <%} %>
                

                <!-- worfklow is a subprocess in a parent process -->
                <%
                  SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> acSteps = myWF.PreviousStepToSubprocess(mySeries);
                
                if (acSteps.Count > 0)
                {
                    isAccessible = true;
                    string parentStepContact = "";
                    string enabledBy = "";
                    foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in acSteps.Values)
                    {
                        string sCode = "";
                        string sEnable = "";
                        bool isEnabled = false;
                        
                        if (acsr.StepType == (int)atriumBE.StepType.Subseries)
                        {
                            //if step type subseries, then two subseries steps are sequenced one after the other
                            // display appropriate text to indicate that
                            string parentproc = acsr.SeriesRow.SeriesCode;
                            lmDatasets.ActivityConfig.SeriesRow sr = myWF.myACM.DB.Series.FindBySeriesId(acsr.SubseriesId);
                            string subcode = sr.SeriesCode;
                            sCode = myWF.getResource("lblComingOut") + " <a href=\"workflow.aspx?seriesid=" + acsr.SubseriesId + "\"><img alt=\"\" src=\"images/subprocess.png\"/>" + subcode + "</a> " + myWF.getResource("lblSubp") + " <a href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "\"><img alt=\"\" src=\"images/workflow.gif\"/>" + parentproc + "</a> " + myWF.getResource("lblProcess");
                            
                        }
                        else
                        {
                            
                            lmDatasets.ActivityConfig.ACDependencyRow[] connsForward = acsr.GetACDependencyRowsByNextSteps();
                            foreach (lmDatasets.ActivityConfig.ACDependencyRow connF in connsForward)
                            {
                                if (connF.LinkType == (int)atriumBE.ConnectorType.Enable && connF.ACSeriesRowByPreviousSteps.SubseriesId==mySeries.SeriesId)
                                {   //enable connector points to our process
                                    sEnable = "<img alt=\"\" src=\"images/power_on.png\" />" + myWF.getResource("lblEnabledBy") + " <a href=\"step.aspx?acseriesid=" + acsr.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acsr.StepCode + " - " + acsr["ActivityName" + Session["DBLang"].ToString()] + "</a> | <a title=\"" + acsr.SeriesCode + " - " + acsr.SeriesRow["SeriesDesc" + Session["DBLang"].ToString()] + "\" href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "\"><image alt=\"\" src=\"images/workflow.gif\"/></a> | <a title=\"" + acsr.StepCode + " " + myWF.getResource("lblInWFPage") + "\" href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "#" + acsr.StepCode + "\"><image alt=\"\" src=\"images/workflow.png\"/></a>";
                                    isEnabled = true;
                                }

                                if (connF.LinkType == (int)atriumBE.ConnectorType.Transfer && connF.ACSeriesRowByPreviousSteps.SubseriesId == mySeries.SeriesId)
                                {   //transfer connector points to our process
                                    sEnable = "<img alt=\"\" src=\"images/processCB.png\" />" + myWF.getResource("lblTransferEnabledBy") + " <a href=\"step.aspx?acseriesid=" + acsr.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acsr.StepCode + " - " + acsr["ActivityName" + Session["DBLang"].ToString()] + "</a> | <a title=\"" + acsr.SeriesCode + " - " + acsr["SeriesDesc" + Session["DBLang"].ToString()] + "\" href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "\"><image alt=\"\" src=\"images/workflow.gif\"/></a> | <a title=\"" + acsr.StepCode + " " + myWF.getResource("lblInWFPage") + "\" href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "#" + acsr.StepCode + "\"><image alt=\"\" src=\"images/workflow.png\"/></a>";
                                    isEnabled = true;
                                }

                            }
                            if (!isEnabled)
                            {
                                if (acsr.SeriesRow.Status != "OBS") // add only if series is not obsolete
                                    sCode = "<a href=\"step.aspx?acseriesid=" + acsr.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acsr.StepCode + " - " + acsr["ActivityName" + Session["DBLang"].ToString()] + "</a> | <a title=\"" + acsr.SeriesCode + " - " + acsr.SeriesRow["SeriesDesc" + Session["DBLang"].ToString()] + "\" href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "\"><image alt=\"\" src=\"images/workflow.gif\"/></a> | <a title=\"" + acsr.StepCode + " " + myWF.getResource("lblInWFPage") + "\" href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "#" + acsr.StepCode + "\"><image alt=\"\" src=\"images/workflow.png\"/></a>";
                            }
                        }

                        if (!isEnabled)
                        {
                            if (parentStepContact == "")
                                parentStepContact = "<div class=\"dvindnt\"><div>" + sCode + "</div>";
                            else if (sCode != "")
                                parentStepContact += "<div>" + sCode + "</div>";
                        }
                        else
                        {
                            if (enabledBy == "")
                                enabledBy = "<div class=\"dvindnt\"><div>" + sEnable + "</div>";
                            else if (sEnable != "")
                                enabledBy += "<div>" + sEnable + "</div>";
                        }
                        
                        
                        
                    }

                    %>

                    <%if(parentStepContact!=""){
                          parentStepContact += "</div>";
                          %>
                        <p><%:myWF.getResource("lblStepsLeadToProcess") %> <%Response.Write(parentStepContact); %></p>
                    <%} %>

                     <%if (enabledBy != "")
                       {
                           enabledBy += "</div>";
                          %>
                        <p><%: myWF.getResource("lblStepsEnableProcess")%> <%Response.Write(enabledBy); %></p>
                    <%} %>


                <%}
                %>    


                <%if (!isAccessible)
                  { %>
                  <p class="warn"><img alt="" src="images/warning_16x16.png" /><%: myWF.getResource("lblCouldNotDetermine")%></p>
                  <%} %>
                  </div>
                <div class="clear"></div>
            <%} %>

         <%} %>
       

        
        <%if (acs.InitialStep == (int)atriumBE.ACEngine.Step.CreateFile || acs.InitialStep == (int)atriumBE.ACEngine.Step.PickIssue)
          {
            //This step creates a file
           %>
           <p><strong><%:myWF.getResource("lblCreateFile")%></strong></p>
            <div class="dvindnt">
            <p><%:acs.StepCode %> <%:myWF.getResource("lblCreatesNewFile")%>
              <% if (!mySeries.IsContainerFileIdNull())
                 {
                     atriumBE.FileManager fm = myWF.myACM.AtMng.GetFile(mySeries.ContainerFileId);
                     %>
                <%:myWF.getResource("lblInFile")%> <strong><%:fm.CurrentFile.FullFileNumber%> (<%:fm.CurrentFile.Name%>)</strong></p>
                <%}
                 else
                 {
                     lmDatasets.ActivityConfig.ActivityFieldRow[] hasIssueRelData = (lmDatasets.ActivityConfig.ActivityFieldRow[])myWF.myACM.DB.ActivityField.Select("ACSeriesId=" + acs.ACSeriesId.ToString() + " and tasktype='I' and objectname='IssuePrimary'", "");

                     if (hasIssueRelData.Length > 0)
                         Response.Write(myWF.getResource("lblIssueContext"));
                     else
                         Response.Write(myWF.getResource("lblTreeContext"));
                         
                 }
                %>
                    </div><div class="clear"></div>
            <%} %>
        
        <%
        //Steps leading into current step

                if (!acs.Start && !myWF.isStepFirstRecordedStep(acs))
                {
                    SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> acStepsLeadingInto = myWF.StepsLeadingTo(acs);

                    if (acStepsLeadingInto.Count > 0)
                    {
                        string previousStep = "";
         %>
            
                 <p><strong><%:myWF.getResource("lblStepsThatLeadTo")%> <%:acs.StepCode%>:</strong></p>
                    <div class="dvindnt">
                    <%
                        foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in acStepsLeadingInto.Values)
                    {
                        
                        string sCode;
                        if (acsr.StepType == (int)atriumBE.StepType.Subseries)
                        {
                            //if step type subseries, then two subseries steps are sequenced one after the other
                            // display appropriate text to indicate that
                            string parentproc = acsr.SeriesRow.SeriesCode;
                            lmDatasets.ActivityConfig.SeriesRow sr = myWF.myACM.DB.Series.FindBySeriesId(acsr.SubseriesId);
                            string subcode = sr.SeriesCode;
                            sCode = myWF.getResource("lblComingOut") + " " + subcode + " subprocess ("+acsr.StepCode+") in the " + parentproc + " process";
                            
                        }
                        else
                        {
                            if (acsr.SeriesRow.Status != "OBS") // add only if series is not obsolete
                            {
                                if (acsr.SeriesId == mySeries.SeriesId)
                                    sCode = "<a href=\"step.aspx?acseriesid=" + acsr.ACSeriesId + "\"><img alt=\"\" src=\"images/act.png\"/>" + acsr.StepCode + " - " + acsr["ActivityName" + Session["DBLang"].ToString()] + "</a>";
                                else
                                    sCode = "<a href=\"workflow.aspx?seriesid=" + acsr.SeriesId + "#" + acsr.StepCode + "\"><img alt=\"\" src=\"images/act.png\"/>" + acsr.StepCode + " - " + acsr["ActivityName" + Session["DBLang"].ToString()] + "</a>";
                            }
                            else
                                sCode = "";
                        }


                        if (previousStep == "")
                            previousStep = "<div>" + sCode + "</div>";
                        else if(sCode!="")
                            previousStep += "<div>" + sCode + "</div>";
                    }

                        //previousStep += "</div>";
                    
                        
                    %>
                         
                    <%Response.Write(previousStep); %>
                    </div>
            
        
        <%}
                } %>



          <%
                    //Access Restrictions

                   if (acs.GetACFileTypeRows().Length>0)
                   {%>
                   <p><strong><%: myWF.getResource("lblAvailRestrictions") %></strong></p>
                   <div class="dvindnt">
                   <table class="module-versatile4">
                        <tr><th><%: myWF.getResource("lblRestrictionType")%></th><th><%: myWF.getResource("lblFileType")%></th><th><%: myWF.getResource("lblMetaFileType")%></th><th><%: myWF.getResource("lblRestrictionFileNum")%></th></tr>
                        <%
                       string AllowOrDeny = myWF.getResource("lblAllowedOn");
                       string img = "allow.png";
                       if (!acs.AllowFileType)
                       {
                           AllowOrDeny = myWF.getResource("lblDeniedOn");
                           img = "deny.png";
                       }
                            
                            
                       foreach (lmDatasets.ActivityConfig.ACFileTypeRow acftr in acs.GetACFileTypeRows())
                       {
                           Response.Write("<tr>");

                           Response.Write("<td><img alt=\"\" src=\"images/" + img + "\"/> " + AllowOrDeny + "</td>");
                           
                           string ftype = null;
                           if (!acftr.IsFileTypeNull())
                               ftype = acftr.FileType; 
                           Response.Write("<td>"+ myWF.LookupLookupValue(ftype, Session["DBLang"].ToString(), "FileType") +"</td>");

                           string mtype = null;
                           if (!acftr.IsMetaFileTypeNull())
                               mtype = acftr.MetaFileType;
                           Response.Write("<td>" + myWF.LookupLookupValue(mtype, Session["DBLang"].ToString(), "FileMetaType") + "</td>");

                           string fnum = "";
                           if (!acftr.IsFullFileNumberNull())
                               fnum = acftr.FullFileNumber;
                           Response.Write("<td>" + fnum + "</td>");

                           Response.Write("</tr>");
                       }
                            
                             %>

                   </table>
                   </div><div class="clear"></div>
                   <%} 
                   
            //Check for any incoming autosteps (i.e. this step is automatic)
                if (myWF.isAnAutoStep(acs))
                {
                    lmDatasets.ActivityConfig.ACSeriesRow previousStep = myWF.GetPreviousStepToAutoStep(acs);
                    string scode = previousStep.StepCode;
                    string isAutoOutput = scode + " - " + previousStep["ActivityName" + Session["DBLang"].ToString()];
                    
                %>
                <p><strong><%: myWF.getResource("lblAutomaticStep") %></strong></p>
                <div class="dvindnt">
                <p><%Response.Write(myWF.getResource("lblCreatedAutomatically")); %> <a class="ail" href="#<%:scode %>"><img alt="" src="images/act.png"/><%: isAutoOutput %></a></p>
                </div><div class="clear"></div>

                <%}%>
                     
            <%
                //Check for any outgoing autosteps.
                if(myWF.hasAnAutoStep(acs))
                {
                    SortedDictionary<string, lmDatasets.ActivityConfig.ACSeriesRow> autoStepList =myWF.GetAutoStepsAhead(acs);
                    string autoStepOutput="";
                    foreach(lmDatasets.ActivityConfig.ACSeriesRow acsr in autoStepList.Values)
                    {
                        autoStepOutput += "<a class=\"ail\" href=\"#" + acsr.StepCode + "\"><img alt=\"\" src=\"images/act.png\"/>" + acsr.StepCode + " - " + acsr["ActivityName" + Session["DBLang"].ToString()] + "</a><br/>";    
                    }
                %>
               
                <p><strong><%: myWF.getResource("lblAutoNextSteps") %></strong></p>
                <div class="dvindnt">
                <p><% Response.Write(myWF.getResource("lblAutoCreate") + " " + acs.StepCode); %> :</p>
                <div class="dvindnt"><%Response.Write(autoStepOutput); %></div>
                </div><div class="clear"></div>

                <%}
                //Role Code
             if (!acs.IsRoleCodeNull())
            {     
              %>
            <p><strong><%: myWF.getResource("lblRole")%></strong></p>
            <div class="dvindnt">
            <p><%:acs.StepCode %> <%: myWF.getResource("lblmustBePerformed")%> (<% Response.Write(myWF.getRoleType(acs.RoleCode, false, Session["DBLang"].ToString())); %>): <img src="images/rolesbf.gif" alt="" />
                <%
              if (myWF.getRoleType(acs.RoleCode, false, Session["DBLang"].ToString()) == "global")
                  Response.Write("<strong><a href=\"javascript:launchGlobalRole('" + acs.RoleCode.ToString() + "')\">" + myWF.getRoleDesc(acs.RoleCode, Session["DBLang"].ToString()) + "</a></strong>");
              else
                  Response.Write("<strong>" + myWF.getRoleDesc(acs.RoleCode, Session["DBLang"].ToString()) + "</strong>");
                  
              %>
            </p>
            </div><div class="clear"></div>
            
          <%} %>
         <%else%>
         <%{ %>
            <p><strong><%: myWF.getResource("lblRole")%></strong></p>
            <div class="dvindnt">
            <p><img src="images/rolesbf.gif" alt="" /><%: myWF.getResource("lblNoRole")%></p>
            </div><div class="clear"></div>

         <%} %>
         
           <%
                  if (acs.Finish && PossibleOutputPaths.Count > 0)
                  {
                %>
                <p><strong><%:myWF.getResource("lblOutputPaths")%></strong></p>
                <div class="dvindnt">
                <%
                      foreach (lmDatasets.ActivityConfig.ACSeriesRow acsr in PossibleOutputPaths.Values)
                      {%>
                        <a href="workflow.aspx?seriesid=<%:acsr.SeriesId %>#<%:acsr.StepCode %>"><img alt="" src="images/act.png" /><%:acsr.StepCode %> (<%:acsr["ActivityName" + Session["DBLang"].ToString()] %>)</a> <%: myWF.getResource("lblInWF") %> <a href="workflow.aspx?seriesid=<%:acsr.SeriesRow.SeriesId %>" title="<%:acsr.SeriesRow["SeriesDesc" + Session["DBLang"].ToString()] %>"><img alt="" src="images/workflow.gif" /><%:acsr.SeriesRow.SeriesCode %></a>
                        <%if (acsr.SeriesRow.Status.ToUpper() == "OBS")
                          {
                              Response.Write("<img title=\"This worfklow is obsolete\" alt=\"\" src=\"images/redlight.gif\"/>");
                          }
                               %>
                        <br />
                      <%}
                     %>
                </div>
                <div class="clear"></div>
              <%
                  }
               %>


         <!-- NEXT STEPS -->         
         <%if (myWF.NextSteps(acs).Length > 0)
           { %>
           
           <p><strong><%: myWF.getResource("lblNextSteps")%></strong></p>
           <div class="dvindnt nxtStps">
           
            <%
               System.Xml.XmlDocument xmldoc = myWF.GetNextSteps(acs, Session["DBLang"].ToString());
               string htmlOutput = myWF.NextStepsHtmlOutput(xmldoc, Session["DBLang"].ToString());
               
               Response.Write(htmlOutput);
               %>
                </div><div class="clear"></div>
        <%} %>

        <!-- ENABLED PROCESSES -->
           <%if (myWF.EnableSteps(acs).Length > 0)
      { %>
        <p><strong><%: myWF.getResource("lblProcessesEnabledByStep")%></strong></p>
            <div class="dvindnt">
             <%foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in myWF.EnableSteps(acs))
              { %>
                
                <% if (acdr.ACSeriesRowByPreviousSteps.IsSubseriesIdNull())
                   {%>
                <div><%:acdr.ACSeriesRowByPreviousSteps.StepCode%> - <%:acdr.ACSeriesRowByPreviousSteps.ActivityNameEng %> <em><%:acdr.ACSeriesRowByPreviousSteps.DescEng%></em></div>
                <%}
                   else
                   {
                       lmDatasets.ActivityConfig.SeriesRow ssr = myWF.myACM.DB.Series.FindBySeriesId(acdr.ACSeriesRowByPreviousSteps.SubseriesId);
                       string imgSrc = "power_on.png";
                       string imgAlt = "Enabled";
                       if (acdr.LinkType == (int)atriumBE.ConnectorType.Transfer)
                       {
                           imgSrc = "processCB.png";
                           imgAlt = "Transfer";
                       }
                           
                %>
                        <div><a href="workflow.aspx?seriescode=<%:ssr.SeriesCode %>"><img alt="" title="<%:imgAlt %>" src="images/<%:imgSrc %>" /><%:ssr.SeriesCode %> - <%:ssr["SeriesDesc" + Session["DBLang"].ToString()] %></a></div>

                <%} %>
        
            <%} %>
        </div>
        <%} %>



        <!-- DISABLED PROCESSES -->
        <%if (myWF.DisalbeSteps(acs).Length > 0){ %>
        <p><strong><%: myWF.getResource("lblProcessesDisabledByStep")%></strong></p>
        <div style="margin-left:20px;">
             <%foreach (lmDatasets.ActivityConfig.ACDependencyRow acdr in myWF.DisalbeSteps(acs))
              { %>
                <% if (acdr.ACSeriesRowByPreviousSteps.IsSubseriesIdNull())
                   {%>
                <div><%:acdr.ACSeriesRowByPreviousSteps.StepCode%> - <%:acdr.ACSeriesRowByPreviousSteps["ActivityName" + Session["DBLang"].ToString()] %> <em><%:acdr.ACSeriesRowByPreviousSteps["Desc" + Session["DBLang"].ToString()]%></em></div>
                <%}
                   else
                   {
                       lmDatasets.ActivityConfig.SeriesRow ssr = myWF.myACM.DB.Series.FindBySeriesId(acdr.ACSeriesRowByPreviousSteps.SubseriesId);
                %>
                <div><a href="workflow.aspx?seriescode=<%:ssr.SeriesCode %>"><img alt="" src="images/power_off.png" /><%:ssr.SeriesCode %> - <%:ssr["SeriesDesc" + Session["DBLang"].ToString()]%></a></div>
                <%} %>
            
            <%} %>
        </div>
        <%} %>




        </div>
            
        </div>
            <%} %>
    </div>
</asp:Content>
