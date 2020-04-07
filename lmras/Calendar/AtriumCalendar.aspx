<%@ Page Title="" Language="C#" MasterPageFile="~/Calendar/CalMaster.Master" AutoEventWireup="true"
    CodeBehind="AtriumCalendar.aspx.cs" Inherits="lmras.Calendar.AtriumCalendar" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblLinks" runat="server" Font-Bold="True" 
        Text="<%$ Resources:LocalizedText, SelectCal %>" Font-Size="Medium" 
        CssClass="align-left"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="pnlCalendarLinks" runat="server" CssClass="align-left" style="font-family: Calibri">
    </asp:Panel>
    <br />
</asp:Content>
