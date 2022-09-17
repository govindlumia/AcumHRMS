<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-empleavedetail.aspx.cs"
    Inherits="leave_report_empleavedetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Detail</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
        .disp
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="400" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="pop-brdr">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                        Leave Detail
                                    </td>
                                    <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                        <a href="#" onclick="window.close()">
                                            <img src="images/btn-close.gif" border="0" /></a>
                                    </td>
                                </tr>
                            </table>
                            <span id="message" runat="server">&nbsp;</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="30%" valign="middle" class="frm-lft-clr123">
                                                                Employee Code
                                                            </td>
                                                            <td width="70%" valign="top" class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_code" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle" class="frm-lft-clr123" width="26%">
                                                                Employee Name
                                                            </td>
                                                            <td valign="top" class="frm-rght-clr123">
                                                                <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="18" valign="top" class="txt02">
                                                    &nbsp;Leave Detail
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" class="head-2">
                                                    <asp:GridView ID="grid_leave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                        CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%" EmptyDataText="No record found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Leave Type">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="25%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("leavetype") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No of Days">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="25%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
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
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
