<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewattendance.aspx.cs" Inherits="leave_admin_viewattendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Report</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
    <table width="718" runat="server" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" height="463px" colspan="5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Attendance
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="20%">
                                        Date
                                    </td>
                                    <td class="frm-rght-clr123" width="22%">
                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                        <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
                    ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                    ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>--%>
                                        <ajaxToolkit:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f"
                                            TargetControlID="txt_sdate" Format="dd-MMM-yyyy">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td class="frm-lft-clr123" width="20%">
                                        Category&nbsp;
                                    </td>
                                    <td class="frm-rght-clr123" width="38%">
                                        &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                    <%--<td class="frm-lft-clr123" width="8%">Branch</td>
             <td class="frm-rght-clr123" width="20%"><asp:DropDownList ID="ddlbranch" runat="server" CssClass="select" DataSourceID="SqlDataSource21"
                      DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound" Width="140px">
                  </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                      ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                  </asp:SqlDataSource></td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="20%">
                                        Employee Name
                                    </td>
                                    <td class="frm-rght-clr123" width="22%">
                                        <asp:TextBox ID="txt_employee" runat="server" MaxLength="20" CssClass="input" Width="119px"></asp:TextBox>
                                    </td>
                                    <td class="frm-lft-clr123" width="20%">
                                        Designation
                                    </td>
                                    <td class="frm-rght-clr123" width="20%">
                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" Width="140px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="frm-lft-clr123" width="20%">
                                       Select Company
                                    </td>
                                    <td class="frm-rght-clr123" width="22%">
                          <asp:DropDownList runat="server" ID="ddl_cmpy" CssClass="select2"></asp:DropDownList>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" width="20%" colspan="4">
                                        <asp:CheckBox runat="server" ID="chk_empstatus" Text="Include Past Employees" />
                                    </td>
                                    <td class="frm-lft-clr123" width="18%" align="center">
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click"
                                            ValidationGroup="c" />&nbsp;
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
                                    <td valign="bottom" class="txt02">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="27%" class="txt02">
                                                    View Attendance
                                                </td>
                                                <td width="73%" align="right" class="txt-red">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnexport" runat="server" CssClass="button2" OnClick="btnexport_Click"
                                            Text="Export To Excel" ToolTip="Export To Excel" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="head-2">
                            <asp:GridView ID="attendancegrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                CellPadding="4" CellSpacing="0" Font-Names="Arial" Font-Size="11px" Width="100%"
                                AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found" OnPageIndexChanging="attendancegrid_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("category_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mode">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("mode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Day">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="14%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# GetDay(Eval("date").ToString())%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="14%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("date", "{0:dd-MMM-yyyy}")%>'></asp:Label>
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
                        <td align="right" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
</asp:UpdatePanel>  --%>
    </form>
</body>
</html>
