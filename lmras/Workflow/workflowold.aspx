<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workflowold.aspx.cs" Inherits="lmras.Deskbook.workflow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            <%:mySeries.SeriesCode %>
            -
            <%:mySeries.SeriesDescEng %></h1>
        <%if (mySeries.CreatesFile)
          { %><p>
              Creates a file</p>
        <%}

          foreach (lmDatasets.ActivityConfig.ACSeriesRow acs in myACM.DB.ACSeries.Select("StepType=0 and Obsolete=0 and SeriesId=" + mySeries.SeriesId.ToString(), "StepCode"))
          {%>
        <h2>
            <%:acs.StepCode %>
            -
            <%:acs.ActivityNameEng %>
            <%:acs.DescEng %></h2>
        <%if (!acs.IsRoleCodeNull())
          { %>
        <p>
            Role:
            <%:acs.RoleCode%></p>
        <%}%>
        <h3>Blocks</h3>
        <table>
        <tr>
        <th>Block</th>
        <th>Seq</th>
        <th>Table</th>
        <th>Field</th>
        <th>Default</th>
        </tr>
        <%foreach (lmDatasets.ActivityConfig.ActivityFieldRow afr in myACM.DB.ActivityField.Select("ACSeriesId=" + acs.ACSeriesId.ToString(), "Step,Seq"))
          {
          %>
          <tr>
          <td><%:afr.Step %></td>
          <td><%:afr.Seq %></td>
          <td><%:afr.ObjectName %></td>
          <td><%:afr.FieldName %></td>
          <td><%:afr.Required %></td>
          <td><%:afr.FieldType %></td>
          </tr>
          <%
          }
            
             %>
        </table>
        <h3>
            Next Steps</h3>
        <%

              foreach (lmDatasets.ActivityConfig.ACDependencyRow acd in acs.GetACDependencyRowsByNextSteps())
              {
                  if (acd.LinkType != 99)
                  {
                      if (acd.ACSeriesRowByPreviousSteps.IsSubseriesIdNull())
                      {%>
        <p>
            <%:acd.ACSeriesRowByPreviousSteps.StepCode %>
            -
            <%:acd.ACSeriesRowByPreviousSteps.ActivityNameEng%></p>
        <%if (acd.ACBFRow != null && !acd.ACBFRow.IsRoleCodeNull())
          { %>
        <p>
            Role:
            <%:acd.ACBFRow.RoleCode%></p>
        <%}
                  }
                  else
                  {
                      lmDatasets.ActivityConfig.SeriesRow ssr = myACM.DB.Series.FindBySeriesId(acd.ACSeriesRowByPreviousSteps.SubseriesId);
        %><p>
            Sub-Process:
            <%:ssr.SeriesCode %>
            -
            <%:ssr.SeriesDescEng %></p>
        <%}

              }
          }
          }  %>
    </div>
    </form>
</body>
</html>
