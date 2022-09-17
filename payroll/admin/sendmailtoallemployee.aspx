<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sendmailtoallemployee.aspx.cs"
    Inherits="payroll_admin_sendmailtoallemployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Earth Infra Pvt. Ltd. : Employee Details</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <%--<asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                          <div class="divajax" style="left: 250px; top: 150px">
                    <table width="100%">
                    <tr>
                    <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                    </tr>
                    <tr>
                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                    </tr>
                    </table>
                    </div>
            </ProgressTemplate>
            </asp:UpdateProgress>--%>
        <div>
            <table width="718px" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="middle" class="txt02 blue-brdr-1">
                        &nbsp;Search Employee</td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frm-lft-clr123" width="15%">
                                    Employee Name</td>
                                <td class="frm-rght-clr123" width="15%">
                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="124px"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123" width="15%">
                                    Designation</td>
                                <td class="frm-rght-clr123" width="15%">
                                    <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                        DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                        Width="158px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                    </asp:SqlDataSource>
                                </td>
                                <td class="frm-lft-clr123" style="width: 11%">
                                    Department</td>
                                <td colspan="2" class="frm-rght-clr123" width="15%">
                                    &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                        Width="145px">
                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123" width="15%">
                                    Financial Year</td>
                                <td class="frm-rght-clr123" width="15%">
                                    &nbsp;<asp:DropDownList ID="dd_year" runat="server" AutoPostBack="true" CssClass="select" DataTextField="year"
                                        DataValueField="year" ToolTip="Financial Year" Width="129px" OnSelectedIndexChanged="dd_year_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                                <td class="frm-lft-clr123" width="15%">
                                    Month</td>
                                <td class="frm-lft-clr123">
                                    &nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" DataTextField="month "
                                        DataValueField="month " ToolTip="Month" Width="129px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                        ToolTip="Select Month" ValidationGroup="a"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    &nbsp;&nbsp;
                                </td>
                                <td colspan="3" class="frm-lft-clr123" width="12%">
                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
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
                    <td valign="middle" class="txt02 blue-brdr-1">
                        &nbsp;Print & Send Salary Slip</td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="top" align="right">
                                    <table width="100%">
                                        <tr>
                                            <td class="frm-lft-clr123" align="left" width="20%">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="select" DataSourceID="SqlDataSource4"
                                                    DataTextField="department" DataValueField="printername" OnDataBound="DropDownList1_DataBound"
                                                    Width="158px">
                                                </asp:DropDownList><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownList1"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ValidationGroup="b" ValueToCompare="0"></asp:CompareValidator><asp:SqlDataSource
                                                        ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        SelectCommand="SELECT [department], [printername] FROM [tbl_intranet_printersetting]">
                                                    </asp:SqlDataSource>
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Print" ToolTip="Print"
                                                    OnClick="btnprint_Click" ValidationGroup="b" />&nbsp;&nbsp; &nbsp;<asp:Button ID="btnsend"
                                                        runat="server" CssClass="button" ToolTip="Send Mail" Text="Send mail" OnClick="btnsend_Click" />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" class="txt02">
                                                            &nbsp;Employee Record
                                                            <br />
                                                            <asp:LinkButton ID="lnkcheckall" OnClick="lnkcheckall_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                            |
                                                            <asp:LinkButton ID="lnkuncheckall" runat="server" CssClass="txt-red" OnClick="lnkuncheckall_Click">Uncheck All</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="head-2" valign="top">
                                                            <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                BorderWidth="0px" AllowPaging="True" PageSize="200" EmptyDataText="No such employee exists !"
                                                                OnPageIndexChanging="empgrid_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="checkg" runat="Server" Checked="false"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Emp Code">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblempcodeg" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="28%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Designation">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Department">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                <RowStyle Height="5px" />
                                                                <PagerSettings Position="TopAndBottom" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                    runat="server" SelectCommand="sp_payroll_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                                    <SelectParameters>
                                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                        <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                                        <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                                        <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                                        <asp:Parameter Name="status" Type="String" />
                                                        <asp:Parameter Name="month" Type="String" />
                                                        <asp:Parameter Name="year" Type="String" />
                                                    </SelectParameters>
                                                </asp:SqlDataSource>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="10" valign="top">
                                </td>
                            </tr>
                        </table>
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="false">
                        </CR:CrystalReportViewer>
                    </td>
                </tr>
                <tr>
                </tr>
            </table>
        </div>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
