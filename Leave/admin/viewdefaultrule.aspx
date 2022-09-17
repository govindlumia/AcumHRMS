<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewdefaultrule.aspx.cs"
    Inherits="Leave_admin_viewdefaultrule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>View Leave Rule</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="blue-brdr-1">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="txt01" style="height: 15px">
                                        View Leave Rule
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="7" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="31%" class="frm-lft-clr123">
                                        Policy Name
                                    </td>
                                    <td width="69%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_policy_name" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="31%" class="frm-lft-clr123">
                                        Leave Type
                                    </td>
                                    <td width="69%" class="frm-rght-clr123">
                                        <asp:Label ID="lblleave" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            &nbsp;General Leave Rule
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="31%" class="frm-lft-clr123">
                                        Days before leave to be apply
                                    </td>
                                    <td width="21%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_days_before_leave" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="1%">
                                        &nbsp;
                                    </td>
                                    <td width="26%" class="frm-lft-clr123">
                                        Entitled days per year
                                    </td>
                                    <td width="21%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_entitled_days" runat="server" Text="Label"></asp:Label>
                                        <asp:RadioButtonList runat="server" ID="rbtn" RepeatDirection="Horizontal" AutoPostBack="false"
                                            Enabled="false">
                                            <asp:ListItem Value="0">Credited</asp:ListItem>
                                            <asp:ListItem Value="1">Computed</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        <div id="dvCompute" runat="server" visible="false">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="31%" class="frm-lft-clr123">
                                                        Number of days
                                                    </td>
                                                    <td width="21%" class="frm-rght-clr123">
                                                        <asp:Label ID="txtNo_of_days" runat="server" Text="Label" Width="60px"></asp:Label>
                                                    </td>
                                                    <td style="width: 1%">
                                                        &nbsp;
                                                    </td>
                                                    <td width="26%" class="frm-lft-clr123">
                                                        Balance
                                                    </td>
                                                    <td width="21%" class="frm-rght-clr123">
                                                        <asp:Label ID="txt_balance" runat="server" Text="Label" Width="60px"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Minimum number of days
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_minimum_days" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td class="frm-lft-clr123">
                                        Maximum number of days
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_entitled_maxdays" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Half day leave applicable
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_halfdays_leave" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="frm-lft-clr123">
                                        Document required
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Back date leave applying
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="frm-lft-clr123">
                                        With in how many days
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_how_many_days" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Exclude Holidays
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="frm-lft-clr123">
                                        Exclude Weekly off
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_weekly" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Short day leave applicable
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_short" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td style="width: 10px">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            &nbsp;Accumulation / Carry Forward
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Carry forward for next year
                                    </td>
                                    <td colspan="4" class="frm-rght-clr123">
                                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="31%" class="frm-lft-clr123" style="height: 26px">
                                        Carry forward days
                                    </td>
                                    <td width="21%" class="frm-rght-clr123" style="height: 26px">
                                        <asp:Label ID="lbl_carryforward" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="1%" style="height: 26px">
                                        &nbsp;
                                    </td>
                                    <td width="26%" class="frm-lft-clr123" style="height: 26px">
                                        Accumulation days
                                    </td>
                                    <td width="21%" class="frm-rght-clr123" style="height: 26px">
                                        <asp:Label ID="lbl_accumulation_days" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            &nbsp;Leave Extension / Shortened Rule
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="31%">
                                        Leave extension/shorten
                                    </td>
                                    <td width="69%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_modification" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
