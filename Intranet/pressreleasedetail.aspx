<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pressreleasedetail.aspx.cs"
    Inherits="pressreleasedetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css" media="all">
        @import "css/blue.css";
        @import "css/home.css";
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="blue-brdr-1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" class="dot-line" style="height: 22px">
                        Company Press Release</td>
                </tr>
                <tr>
                    <td valign="top" height="5">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;&nbsp;<asp:Label ID="lbldate" runat="server" Text=""></asp:Label><asp:Label
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
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="11%" class="txt01">
                                </td>
                                <td width="20%">
                                    &nbsp;</td>
                                <td width="34%">
                                </td>
                                <td width="35%">
                                    <table width="50" border="0" align="right" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="5" align="left" valign="top">
                                                <img src="images/button-right.jpg" width="5" height="18" /></td>
                                            <td width="90" align="center" valign="middle" class="button-bg">
                                                <a href="javascript:history.go(-1)" class="back">Back</a></td>
                                            <td width="5" align="right">
                                                <img src="images/button-right1.jpg" width="5" height="18" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
