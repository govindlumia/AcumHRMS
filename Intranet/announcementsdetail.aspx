<%@ Page Language="C#" AutoEventWireup="true" CodeFile="announcementsdetail.aspx.cs"
    Inherits="announcementsdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css" media="all">
        @import "../css/blue.css";
        @import "../css/home.css";
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="dot-line" style="height: 22px">
                        News</td>
                </tr>
                <tr>
                    <td valign="top" height="5">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    &nbsp;&nbsp;<img src="../images/date-icon.gif" width="10" height="10" alt="" />&nbsp;
                       <asp:Label ID="lbldate" runat="server" Text=""></asp:Label><asp:Label
                            ID="lblname" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td height="26" valign="middle" class="txt01">
                        &nbsp;&nbsp;<asp:Label ID="lblheading" runat="server" CssClass="txt3"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <p>
                            <asp:Label ID="lbldetails" runat="server" Text=""></asp:Label>
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
