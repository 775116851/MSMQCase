<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebTest.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td><asp:TextBox ID="txtUrl" runat="server" Width="415px">192.168.102.188\private$\myqueue</asp:TextBox></td>
            <td rowspan="2"><asp:Button ID="btnSend" runat="server" Text="发送" Width="64px" OnClick="btnSend_Click" /></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="txtInfo" runat="server" Height="73px" Width="410px"></asp:TextBox></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
