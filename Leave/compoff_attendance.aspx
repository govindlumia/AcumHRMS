<%@ Page Language="C#" AutoEventWireup="true" CodeFile="compoff_attendance.aspx.cs"
    Inherits="leave_compoff_attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Mark CompOff</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../images/loading.gif" />
                                </td>
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="images/employee-icon.jpg" width="16" height="16" />
                                                </td>
                                                <td class="txt01">
                                                    Mark of Comp-Off
                                                </td>
                                                <td align="right">
                                                   <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="9">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top" class="txt02">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    &nbsp;Employee Information
                                                </td>
                                                <td class="txt-red" align="right">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Employee Name
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td width="1%" rowspan="7">
                                                    &nbsp;
                                                </td>
                                                <td width="18%" class="frm-lft-clr123">
                                                    Employee Code
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Category
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>
                                                    <asp:Label ID="lbl_gender" Visible="false" runat="server" Text="Label"></asp:Label>
                                                </td>
                                                <td width="18%" class="frm-lft-clr123">
                                                    Designation
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_designation" runat="server" Text="Label"></asp:Label>
                                                    <asp:Label ID="lbl_branch" Visible="false" runat="server" Text="Label"></asp:Label>
                                                    <asp:Label ID="lbl_doj" runat="server" Visible="false" Text="Label"></asp:Label>
                                                    <asp:Label ID="lbl_emp_status" runat="server" Visible="false" Text="Label"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 10px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top" class="txt02">
                                        &nbsp;Mark Comp-Off
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Date<span style="color:red">*</span>
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_date" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                                    <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_date"
                                                        Display="Dynamic" ErrorMessage='Please select Date' ValidationGroup="v"></asp:RequiredFieldValidator>
                                                   <%-- <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_date"
                                                        Display="Dynamic" ErrorMessage="Check date format (dd/MMM/yyyy)" Height="9px"
                                                        Operator="DataTypeCheck" ToolTip="Check date format (dd/MMM/yyyy)" Type="Date"
                                                        ValidationGroup="v" Width="175px"></asp:CompareValidator>--%>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="img"
                                                                TargetControlID="txt_date" Format="dd-MMM-yyyy">
                                                            </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Extra Working Hour
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="ddl_extrahour" runat="server" CssClass="select" Width="146px">
                                                        <asp:ListItem Value="0">4-5 Hours</asp:ListItem>
                                                        <asp:ListItem Value="1">Greater Than 5 Hours</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Reason/Comment
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_comment" runat="server" TextMode="MultiLine" Width="240px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="10">
                                        &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img"
                                            TargetControlID="txt_date">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:Button ID="btn_sbmit" runat="server" CssClass="button" Text="Submit" OnClick="btn_sbmit_Click"
                                            ValidationGroup="v" />
                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />
                                        &nbsp;
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
                    <tr>
                        <td height="22" valign="top" class="txt02">
                            View Comp-off Mark History
                        </td>
                    </tr>
                    <tr>
                        <td height="10" valign="top" class="head-2" style="width: 729px">
                            <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                BorderWidth="0px" DataSourceID="SqlDataSource2" CellPadding="4" Width="100%"
                                EmptyDataText="No Data Available !" DataKeyNames="" PageSize="100">
                                <HeaderStyle CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Posted Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l7" runat="server" Text='<%# Bind("createddate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetch_compoff_mark"
                                SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="0" Name="empcode" SessionField="empcode" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                     <asp:ValidationSummary ID="ValidationSummary2" ShowMessageBox="True" ShowSummary="False"
                        runat="server" ValidationGroup="v"></asp:ValidationSummary>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
