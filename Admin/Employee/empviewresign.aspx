<%@ Page Title="View Resigned Employee" Language="C#" MasterPageFile="~/Admin/Employee/Admin.master"
    AutoEventWireup="true" CodeFile="empviewresign.aspx.cs" Inherits="Admin_company_empviewresign" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>--%>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
    <div class="header">
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
                                                    Employee Master View
                                                </td>
                                                <td class="txt-red" align="right">
                                                    <span id="message" runat="server">&nbsp;</span>
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
                                                <td valign="middle" class="txt02 blue-brdr-1" height="23">
                                                    &nbsp;Search Employee
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
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Company
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList runat="server" ID="ddl_company" CssClass="Select" AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddl_company_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Emp Name/Code
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Designation
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="dd_designation" runat="server" CssClass="select">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Category
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="dd_category" runat="server" CssClass="select">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="10%">
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
                                                                                        &nbsp;Employee List
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="head-2" valign="top">
                                                                                        <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                                            CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                            AllowSorting="true" OnSorting="empgrid_Sorting" BorderWidth="0px" AllowPaging="True"
                                                                                            PageSize="25" EmptyDataText="No such employee exists !" OnRowEditing="empgrid_RowEditing"
                                                                                            OnRowDataBound="empgrid_RowDataBound" OnPageIndexChanging="empgrid_PageIndexChanging">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Emp Code" HeaderStyle-ForeColor="#013366" SortExpression="empcode">
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                    <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Emp Name" HeaderStyle-ForeColor="#013366" SortExpression="name">
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                    <ItemStyle Width="21%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Designation" HeaderStyle-ForeColor="#013366" SortExpression="designationname">
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                    <ItemStyle Width="21%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Category Name" HeaderStyle-ForeColor="#013366" SortExpression="CategoryName">
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                    <ItemStyle Width="19%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("CategoryName") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Date of Resign">
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                    <ItemStyle Width="19%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("emp_doleaving" , "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="viewempdetail.aspx?empcode={0}"
                                                                                                    NavigateUrl="viewempdetail.aspx" Text="View">
                                                                                                    <ControlStyle CssClass="link05" Width="6%" />
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="5%"></ItemStyle>
                                                                                                </asp:HyperLinkField>
                                                                                                  <asp:HyperLinkField DataNavigateUrlFields="empcode,companyid" DataNavigateUrlFormatString="editempmaster.aspx?empcode={0}&companyid={1}"
                                                                                                        NavigateUrl="editempmaster.aspx" Text="Edit">
                                                                                                        <ControlStyle CssClass="link05" Width="6%" />
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="5%"></ItemStyle>
                                                                                                    </asp:HyperLinkField>
                                                                                            </Columns>
                                                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                                                            <RowStyle Height="5px" />
                                                                                            <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                                                                                VerticalAlign="Top" />
                                                                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                                                                NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
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
    </div>
</asp:Content>
