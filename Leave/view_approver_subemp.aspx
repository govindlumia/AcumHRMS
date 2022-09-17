<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_approver_subemp.aspx.cs"
    Inherits="leave_view_approver_subemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Report Employee-wise</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" height: 320px; width: 502px;">
        <table width="718" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" align="left" class="blue-brdr-1">
                    <b><span id="message" runat="server"></span></b>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%">
                        <tr>
                            <td class="frm-lft-clr123" style="width: 40%">
                                View Complete Hierarchy
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:CheckBox runat="server" AutoPostBack="true" ID="chk_includeall" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="7">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="head-2" valign="top">
                                <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                    CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No record found"
                                    AllowPaging="True" OnPageIndexChanging="approvergrid_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Code">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind ("employeecode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                </asp:GridView>
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
