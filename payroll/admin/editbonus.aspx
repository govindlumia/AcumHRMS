<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editbonus.aspx.cs" Inherits="payroll_admin_editbonus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Information</title>
    <style type="text/css" media="all">

@import "../../css/blue1.css";
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:ScriptManager ID="bank" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        <table width="718" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" height="463px">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%" style="height: 16px">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01" style="height: 16px">
                                            Edit Employee Bonus</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 5px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" colspan="2">
                                            Financial Year</td>
                                        <td class="frm-rght-clr123" colspan="4">
                                            <asp:DropDownList ID="dd_year" runat="server" DataSourceID="SqlDataSource12" DataTextField="financialyear"
                                                DataValueField="financialyear" OnDataBound="dd_year_DataBound" CssClass="select"
                                                Width="145px">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                SelectCommand="select [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"
                                                ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                        </td>
                                    </tr>
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
                                      <%--  <td class="frm-lft-clr123" style="width: 11%">
                                            Department</td>--%>
                                        <td class="frm-rght-clr123" colspan="2">
                                           <%-- &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                Width="145px">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                            </asp:SqlDataSource>--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" align="right" valign="top">
                                &nbsp;<asp:Button ID="btnsv" runat="server" CssClass="button" OnClick="btnsv_Click"
                                    Text="View" ValidationGroup="v" />
                                <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export" ValidationGroup="v"
                                    OnClick="btnexport_Click" />&nbsp;
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
                                        <td height="20" valign="top" class="txt02">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="27%" class="txt02" style="height: 13px">
                                                        Bonus Detail</td>
                                                    <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                        <span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="head-2" valign="top">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                        runat="server">
                                                        <ProgressTemplate>
                                                            <div class="divajax" style="top: 160px;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img alt="" src="../../images/loading.gif" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="bottom" align="center" class="txt01">
                                                                            Please Wait...</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                        CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No previous year data found"
                                                        DataKeyNames="empcode,year" OnRowCancelingEdit="adjustgrid_RowCancelingEdit"
                                                        OnRowEditing="adjustgrid_RowEditing" OnRowUpdating="adjustgrid_RowUpdating" AllowPaging="True"
                                                        OnPageIndexChanging="adjustgrid_PageIndexChanging" PageSize="40" AllowSorting="True"
                                                        OnSorting="adjustgrid_Sorting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Emp Code" SortExpression="empcode">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Name" SortExpression="empname">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Financial Year">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l41" runat="server" Text='<%# Bind ("year") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bonus Amount">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("bonus_amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Percent(%)">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind ("interest") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bonus">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txt_nd" runat="Server" Text='<%# Eval("amount") %>' CssClass="input"
                                                                        Width="89px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nd"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter days" />'
                                                                        ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nd"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter valid days" />'
                                                                        MaximumValue="1000000" MinimumValue="1" Type="Double" ValidationGroup="grid"></asp:RangeValidator>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Month to Received">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l77" runat="server" Text='<%# Bind ("month") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="dd_monthg" runat="server" CssClass="select" DataTextField='<%# Bind ("month") %>'
                                                                        DataValueField='<%# Bind ("month") %>' ToolTip="Month" Width="145px">
                                                                        <asp:ListItem>Apr</asp:ListItem>
                                                                        <asp:ListItem>May</asp:ListItem>
                                                                        <asp:ListItem>Jun</asp:ListItem>
                                                                        <asp:ListItem>Jul</asp:ListItem>
                                                                        <asp:ListItem>Aug</asp:ListItem>
                                                                        <asp:ListItem>Sep</asp:ListItem>
                                                                        <asp:ListItem>Oct</asp:ListItem>
                                                                        <asp:ListItem>Nov</asp:ListItem>
                                                                        <asp:ListItem>Dec</asp:ListItem>
                                                                        <asp:ListItem>Jan</asp:ListItem>
                                                                        <asp:ListItem>Feb</asp:ListItem>
                                                                        <asp:ListItem>Mar</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lnk_update" CssClass="link05" CommandName="Update" runat="server"
                                                                        ValidationGroup="grid">Update</asp:LinkButton>|
                                                                    <asp:LinkButton ID="lnk_cancel" CssClass="link05" CommandName="Cancel" runat="server"
                                                                        ValidationGroup="noone">Cancel</asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_edit" CssClass="link05" CommandName="Edit" runat="server"
                                                                        Enabled='<%#Bind("flag")%>' ValidationGroup="noone">Edit </asp:LinkButton>
                                                                    <%--<asp:LinkButton ID="lnk_delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');" CommandName="Delete" runat="server" ValidationGroup="noone">Delete</asp:LinkButton>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                        <PagerSettings Position="TopAndBottom" />
                                                    </asp:GridView>
                                                    &nbsp;<br />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
