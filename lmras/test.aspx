<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="lmras.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Atrium</title>
    <style type="text/css">
        .style1 {
            width: 100%;
        }
        .style2
        {
            width: 262px;
        }
    </style>
</head>
<body style="font-family:Calibri">
<h2>Welcome to Atrium</h2>
    <form id="form1" runat="server">
    <div>
        &nbsp;<table class="style1">
            <tr>
                <td class="style2">
                    Connect using</td>
                <td>
                    <asp:TextBox ID="tbServer" runat="server">DATABASE1</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    User (only if SQL auth)</td>
                <td>
                    <asp:TextBox ID="tbUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Password</td>
                <td>
        <asp:TextBox ID="tbPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Test Connection" 
            onclick="Button1_Click" /><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label></div>
    <p>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    </p>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    </p>
   </form>


    </body>
</html>
