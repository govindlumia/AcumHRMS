<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_employee_leave_profile.aspx.cs"
    Inherits="Leave_admin_createemployeeprofile" Title="Leave Approver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="770" border="0" cellspacing="0" cellpadding="4">
        <tr>
            <td valign="top" class="blue-brdr-1">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="3%">
                            <img src="../images/employee-icon.jpg" width="16" height="16" alt=""/>
                        </td>
                        <td class="txt01">
                            Employee Leave Profile
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5" valign="top" align="right" class="txt-red">
                <span id="message" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td height="17" valign="top" class="txt02">
                View Employee Profile
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="19%" class="frm-lft-clr123">
                            Employee Code&nbsp;
                        </td>
                        <td class="frm-rght-clr123">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        &nbsp;<asp:Label ID="lbl_empcode" runat="server"></asp:Label>
                                    </td>
                                    <td width="88px" style="height: 20px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" height="10">
            </td>
        </tr>
        <tr runat="server" visible="true">
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="20" valign="top" class="txt02">
                                        Approval Level&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="head-2" valign="top">
                                        <asp:GridView ID="approvalgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                            CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No record found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Emp Code">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind ("approverid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approver Name">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Level">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("approverpriority") %>'></asp:Label>
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
                                    <td height="10">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="19%" class="frm-lft-clr123">
                            HC
                        </td>
                        <td class="frm-rght-clr123">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="height: 20px; width: 28%;">
                                        &nbsp;<asp:Label ID="lbl_hr" runat="server"></asp:Label>
                                    </td>
                                    <td width="88px" style="height: 20px">
                                    </td>
                                </tr>
                            </table>
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
            <td height="17" valign="top" class="txt02">
                Set Leave Rule
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="grid_customizerule" runat="server" Font-Size="11px" Font-Names="Arial"
                    DataKeyNames="leaveid" CellPadding="4" Width="1200px" AutoGenerateColumns="False"
                    BorderWidth="0px" EmptyDataText="No record found" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:TemplateField HeaderText="Leave Type">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("leavetype") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Entitled Days">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("Expr4") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="leaveid" Visible="false">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("leaveid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Policy Id" Visible="false">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l5" runat="server" Text='<%# Bind ("PolicyId") %>'></asp:Label>
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
            <td height="10" valign="top">
            </td>
        </tr>
        <tr>
            <td height="10" valign="top">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>" SelectCommand="SELECT tbl_leave_employee_leave_master.PolicyId, tbl_leave_employee_leave_master.Entitled_days AS Expr4, tbl_leave_employee_leave_master.leaveid, tbl_leave_employee_leave_master.empcode, tbl_leave_createleave.leaveid AS Expr1, tbl_leave_createleave.leavetype, tbl_leave_createleavepolicy.policyid AS Expr2, tbl_leave_createleavepolicy.policyname, tbl_leave_createleave.leavetype AS Expr3 FROM tbl_leave_employee_leave_master INNER JOIN tbl_leave_createleave ON tbl_leave_createleave.leaveid = tbl_leave_employee_leave_master.leaveid INNER JOIN tbl_leave_createleavepolicy ON tbl_leave_createleavepolicy.policyid = tbl_leave_employee_leave_master.PolicyId WHERE (tbl_leave_employee_leave_master.status = 1) AND (tbl_leave_employee_leave_master.empcode = @employeeid)AND(tbl_leave_employee_leave_master.leaveid!=0)">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="employeeid" QueryStringField="empcode" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
