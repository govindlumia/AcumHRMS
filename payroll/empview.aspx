<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empview.aspx.cs" Inherits="Admin_company_empview"
    Title="Acuminous Software. : Employee Master View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
@import "../css/blue1.css";
@import "../css/example.css";
</style>

    <script type="text/javascript" src="../js/tabber.js"></script>

    <script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <asp:UpdatePanel ID="updatepannel1" runat="server">
                    <ContentTemplate>
                        <div>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="blue-brdr-1">
                                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                <tr>
                                                    <td class="txt01">
                                                        Employee Master View</td>
                                                    <td class="txt-red" align="right">
                                                        <span id="message" runat="server">&nbsp;</span></td>
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
                                            <%--<asp:GridView id="Grid_Emp" runat="server" DataSourceID="SqlDataSource1" AllowPaging="True" BorderWidth="0"  Width="100%" HorizontalAlign="Left" DataKeyNames="empcode" CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" AllowSorting="True" PageSize="100">
<PagerSettings PageButtonCount="100"></PagerSettings>
        <FooterStyle CssClass="frm-lft-clr123" />
<Columns>
<asp:BoundField DataField="emp_name" HeaderText="Employee Name" ReadOnly="True" SortExpression="emp_name" ItemStyle-CssClass="frm-rght-clr1234">

    <HeaderStyle CssClass="frm-lft-clr123" />

</asp:BoundField>
<asp:BoundField DataField="designationname" HeaderText="Degination"  SortExpression="designationname" ItemStyle-CssClass="frm-rght-clr1234">
    <HeaderStyle CssClass="frm-lft-clr123" />
</asp:BoundField>
<asp:BoundField DataField="department_name" HeaderText="Department" SortExpression="department_name" ItemStyle-CssClass="frm-rght-clr1234">

    <HeaderStyle CssClass="frm-lft-clr123" />
</asp:BoundField>
<asp:BoundField DataField="empcode" HeaderText="Employee Code" ReadOnly="True" SortExpression="empcode" ItemStyle-CssClass="frm-rght-clr1234" >

    <HeaderStyle CssClass="frm-lft-clr123"  />
</asp:BoundField>
<asp:BoundField  DataField="card_no" HeaderText="Card No." SortExpression="card_no" ItemStyle-CssClass="frm-rght-clr1234" >
   
    <HeaderStyle CssClass="frm-lft-clr123" />
</asp:BoundField>

<asp:HyperLinkField DataNavigateUrlFields="empcode" ItemStyle-CssClass="frm-rght-clr1234" DataNavigateUrlFormatString="viewempdetail.aspx?empcode={0}" NavigateUrl="viewempdetail.aspx" Text="View">
    <ControlStyle CssClass="link05" />
    <HeaderStyle CssClass="frm-lft-clr123" />
</asp:HyperLinkField>

<asp:HyperLinkField DataNavigateUrlFields="empcode" ItemStyle-CssClass="frm-rght-clr1234" DataNavigateUrlFormatString="editempmaster.aspx?empcode={0}" NavigateUrl="editempmaster.aspx" Text="Edit">
    <ControlStyle CssClass="link05" />
    <HeaderStyle CssClass="frm-lft-clr123" />
</asp:HyperLinkField>
</Columns>

<HeaderStyle  CssClass="frm-lft-clr123" HorizontalAlign="Left" />
</asp:GridView>--%>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="middle" class="txt02 blue-brdr-1" height="23">
                                                        &nbsp;Search Employee</td>
                                                </tr>
                                                <tr>
                                                    <td height="5" valign="top">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    Emp Name/Code</td>
                                                                <td class="frm-rght-clr123" width="15%">
                                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="130px"></asp:TextBox>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    Designation</td>
                                                                <td class="frm-rght-clr123" width="25%">
                                                                    <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                                                        Width="152px" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="13%">
                                                                    Department</td>
                                                                <td class="frm-rght-clr123" width="15%">
                                                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                                        Width="152px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 2%">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    Branch</td>
                                                                <td class="frm-rght-clr123" width="15%">
                                                                    <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="select" Width="135px"
                                                                        Height="20px" DataSourceID="SqlDataSource4" DataTextField="branch_name" DataValueField="Branch_Id"
                                                                        OnDataBound="drp_comp_name_DataBound">
                                                                    </asp:DropDownList>
                                                                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
          ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0" ToolTip="Select Branch Name"><img src="../images/../images/error1.gif" alt="" /></asp:CompareValidator>--%>
                                                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="4">
                                                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" /></td>
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
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                                    <tr>
                                                                                        <td valign="middle" class="txt02" style="height: 24px">
                                                                                            &nbsp;Employee List</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="head-2" valign="top">
                                                                                            <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                                                CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                                BorderWidth="0px" AllowPaging="True" PageSize="200" EmptyDataText="No such employee exists !"
                                                                                                OnRowEditing="empgrid_RowEditing" OnRowDataBound="empgrid_RowDataBound" OnPageIndexChanging="empgrid_PageIndexChanging">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Emp Code">
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Designation">
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                        <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Department">
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                        <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="viewempdetail.aspx?empcode={0}"
                                                                                                        NavigateUrl="viewempdetail.aspx" Text="View">
                                                                                                        <ControlStyle CssClass="link05" Width="10%" />
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                    </asp:HyperLinkField>
                                                                                                </Columns>
                                                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                <RowStyle Height="5px" />
                                                                                                <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                                                                    <SelectParameters>
                                                                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                                                        <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                                                                        <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                                                                        <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                                                                        <asp:Parameter Name="status" Type="String" />
                                                                                    </SelectParameters>
                                                                                </asp:SqlDataSource>
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
                                </tbody>
                            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
