<%@ Page Language="C#" MasterPageFile="general.master" AutoEventWireup="true" CodeFile="companyphonebook.aspx.cs"
    Inherits="companyphonebook" Title="Acuminous Software - Company Phone Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="generalmaster" runat="Server">
    <style type="text/css" media="all">
@import "css/blue1.css";
@import "css/example.css";
</style>
    <link href="css/blue1.css" rel="stylesheet" type="text/css" />
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
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="txt01">
                                                        Company Phone Book View</td>
                                                    <td class="txt-red" align="right">
                                                        <span id="message" runat="server">&nbsp;</span></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="7">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="txt02 blue-brdr-1" valign="middle" height="23">
                                                        &nbsp;Company Phone Book</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="15%">
                                                                        Emp Name/Code</td>
                                                                    <td class="frm-rght-clr123" width="15%">
                                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="15%">
                                                                        Designation</td>
                                                                    <td class="frm-rght-clr123" width="15%">
                                                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" OnDataBound="dd_designation_DataBound"
                                                                            DataValueField="id" DataTextField="designationname" DataSourceID="SqlDataSource1">
                                                                        </asp:DropDownList>
                                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"
                                                                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>">
                                                                        </asp:SqlDataSource>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="13%">
                                                                        Department</td>
                                                                    <td class="frm-rght-clr123" width="15%">
                                                                        <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" Width="145px" OnDataBound="dd_branch_DataBound"
                                                                            DataValueField="departmentid" DataTextField="department_name" DataSourceID="SqlDataSource2">
                                                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"
                                                                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>">
                                                                        </asp:SqlDataSource>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="12%">
                                                                        <asp:Button ID="btn_search" OnClick="btn_search_Click" runat="server" CssClass="button"
                                                                            Text="Search"></asp:Button>&nbsp;</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td valign="top">
                                                                                        <table id="table1" onclick="return table1_onclick()" cellspacing="0" cellpadding="0"
                                                                                            width="100%" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="height: 24px" class="txt02" valign="middle">
                                                                                                        &nbsp;Contact List</td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="head-2" valign="top">
                                                                                                        <asp:GridView ID="empgrid" runat="server" Width="100%" OnPageIndexChanging="empgrid_PageIndexChanging"
                                                                                                            OnRowDataBound="empgrid_RowDataBound" OnRowEditing="empgrid_RowEditing" EmptyDataText="No such employee exists !"
                                                                                                            PageSize="100" AllowPaging="true" BorderWidth="0px" AutoGenerateColumns="False"
                                                                                                            DataKeyNames="empcode" CellPadding="4" CellSpacing="0" Font-Names="Arial" Font-Size="11px">
                                                                                                            <FooterStyle CssClass="frm-lft-clr123"></FooterStyle>
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Employee Name">
                                                                                                                    <ItemStyle Width="20%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                                    </ItemStyle>
                                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l0" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Department">
                                                                                                                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                                    </ItemStyle>
                                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("departmentname") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Designation">
                                                                                                                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                                    </ItemStyle>
                                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Mobile">
                                                                                                                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                                    </ItemStyle>
                                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("mobileno") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Ext Number">
                                                                                                                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                                    </ItemStyle>
                                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("extnumber") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="E-mail">
                                                                                                                    <ItemStyle Width="15%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                                    </ItemStyle>
                                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind ("email") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <RowStyle Height="5px"></RowStyle>
                                                                                                            <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                        </asp:GridView>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" SelectCommand="sp_company_phone_emp_detail"
                                                                                            ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" SelectCommandType="StoredProcedure">
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
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </tbody>
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
