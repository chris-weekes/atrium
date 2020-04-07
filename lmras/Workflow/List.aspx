<%@ Page Title="" Language="C#" MasterPageFile="~/Workflow/wf.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="lmras.Workflow.List" %>
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
<asp:Label ID="Label5" Runat="server" Text="<%$ Resources:LocalizedText, allFlows %>"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!--<h2><img alt="" src="images/workflow.gif" />Listing of Active Workflows</h2>-->
<%
    lmDatasets.ActivityConfig.SeriesRow[] aSrs = (lmDatasets.ActivityConfig.SeriesRow[])myWF.myACM.DB.Series.Select("Status in ('ACT','DEV')", "SeriesTypeCode, SeriesCode");
    string previousSeriesCode = "";

    System.Data.DataTable dtSeriesType = myWF.myACM.AtMng.GetFile().Codes("SeriesType");
    //string navOutput="";
    //foreach (System.Data.DataRow dr in dtSeriesType.Rows)
    //{ 
    //    lmDatasets.ActivityConfig.SeriesRow[] wfr = (lmDatasets.ActivityConfig.SeriesRow[])myWF.myACM.DB.Series.Select("Status in ('ACT','DEV') and SeriesTypeCode='" + dr["SeriesTypeCode"].ToString() + "'", "");
    //    if (wfr.Length > 0)
    //    {

    //        string rOut = "<a class=\"navlink\" href=\"#" + dr["SeriesTypeCode"].ToString() + "\">" + dr["SeriesTypeCode"].ToString() + " - " + dr["SeriesTypeDescription" + Session["DBLang"].ToString()].ToString() + " (" + wfr.Length + ")</a>";
    //        if (navOutput == "")
    //            navOutput = rOut;
    //        else
    //            navOutput += " <br/> " + rOut;
    //    }

    //}
    //Response.Write(navOutput);

    %>
    <a id="oCollapse" class="aBtn" onclick="xpnd(false);" href="#"><asp:Label ID="Label1" Runat="server" Text="<%$ Resources:LocalizedText, Collapse %>"></asp:Label></a><a id="oExpand" class="aBtn" onclick="xpnd(true);" href="#" style="display:none;"><asp:Label ID="Label2" Runat="server" Text="<%$ Resources:LocalizedText, Expand %>"></asp:Label></a><br />
    
    <table class="module-versatile3">
    <tr>
        <th colspan="2"><asp:Label ID="Label3" Runat="server" Text="<%$ Resources:LocalizedText, WFCode %>"></asp:Label></th>
        <th><asp:Label ID="Label4" Runat="server" Text="<%$ Resources:LocalizedText,  WFDesc%>"></asp:Label></th>
        <th><asp:Label ID="Label6" Runat="server" Text="<%$ Resources:LocalizedText, WFStatus %>"></asp:Label></th>
        <th><asp:Label ID="Label7" Runat="server" Text="<%$ Resources:LocalizedText, WFCreatesFile %>"></asp:Label></th>
        <th><asp:Label ID="Label8" Runat="server" Text="<%$ Resources:LocalizedText, WFAlwaysAvail %>"></asp:Label></th>
    </tr>
    <%    
    foreach (lmDatasets.ActivityConfig.SeriesRow sr in aSrs)
    {
        System.Data.DataRow[] dr = dtSeriesType.Select("SeriesTypeCode='" + sr.SeriesTypeCode + "'", "");

        if (previousSeriesCode == "" || previousSeriesCode!=dr[0]["SeriesTypeCode"]) //create new grouping row
        {
            lmDatasets.ActivityConfig.SeriesRow[] wfr = (lmDatasets.ActivityConfig.SeriesRow[])myWF.myACM.DB.Series.Select("Status in ('ACT','DEV') and SeriesTypeCode='" + dr[0]["SeriesTypeCode"].ToString() + "'", "");
            %>
          <tr name="trGrp"><td colspan="6" class="grp"><img class="hnd" alt="" src="images/minus.gif" onclick="toggleGrp('tr<%:dr[0]["SeriesTypeCode"] %>');" /><a name="<%:dr[0]["SeriesTypeCode"]%>"></a><%:dr[0]["SeriesTypeDescription" + Session["DBLang"].ToString()]%> (<%:wfr.Length.ToString() %>)</td></tr>
        <%
            previousSeriesCode = dr[0]["SeriesTypeCode"].ToString();
            }%>
         
          <tr id="xpndcol" name="tr<%:dr[0]["SeriesTypeCode"] %>" onmouseover="this.className='trMOver';" onmouseout="this.className='trMOut';" onclick="location='workflow.aspx?seriesid=<%: sr.SeriesId %>';">
          <td class="spcr"></td>
          <td class="bt"><%:sr.SeriesCode %></td>
          <td class="bt"><%:sr["SeriesDesc" + Session["DBLang"].ToString()] %></td>
          <td class="cntr bt">
          <%
        if (sr.Status == "ACT")
            Response.Write("<img alt=\"\" src=\"images/greenLight.gif\"/>");
        else
            Response.Write("<img alt=\"\" src=\"images/yellowLight.gif\"/>");
               %>
          </td>
          <td class="cntr bt">
          <%if (sr.CreatesFile)
            {
            Response.Write("<img src=\"images/NewFile.png\" alt=\"\" />");
            }%>
          </td>
          <td class="cntr lst">
          <%if (sr.AlwaysAvailable)
            {
            Response.Write("<img src=\"images/alwaysavailable.png\" alt=\"\" />");
            }%>
          </td>
          </tr>
        <%
    }
    %>
    </table>
</asp:Content>
