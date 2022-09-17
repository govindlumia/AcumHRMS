<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayPeriod.aspx.cs" Inherits="payroll_admin_PayPeriod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="bank" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" height="463px">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%" style="height: 16px">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01" style="height: 16px">
                                                Pay-Period Master
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="20" valign="top" class="txt02">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="27%" class="txt02">
                                                            Pay-Period Details
                                                        </td>
                                                        <td width="73%" align="right" class="txt-red">
                                                            <span id="message" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="head-2">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="frm-lft-clr123">
                                                            From
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:DropDownList runat="server" ID="drpFrom">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="frm-lft-clr123">
                                                            To
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:DropDownList runat="server" ID="drpTo">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Button runat="server" ID="btnUpdate" CssClass="butt" Text="Update" OnClick="btnUpdate_Click" />                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="10" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
