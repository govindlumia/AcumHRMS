<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ceomessageview.aspx.cs" Inherits="ceomessageview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                <td valign="top" class="blue-brdr-1">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="22" valign="top" class="dot-line">
                <%--  From Management Desk--%>
                      From Acuminous Software
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblceotitle" runat="server" CssClass="txt01"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:Label ID="lblceomessage" runat="server" CssClass="text2"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
