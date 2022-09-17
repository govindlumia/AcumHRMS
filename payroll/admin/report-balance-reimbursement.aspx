<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-balance-reimbursement.aspx.cs"
    Inherits="Leave_admin_pickapprover" Title="Leave Approver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script type="text/javascript" language="javascript">
        function returnempcode(val, val2) {
            window.opener.document.getElementById("txt_approver").value = val;
            window.opener.document.getElementById("hidd_name").value = val2;
            window.opener.focus();
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01" height="23">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table width="712" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="middle" class="txt02 blue-brdr-1">
                        &nbsp;Report Reimbursement
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
                                    Name
                                </td>
                                <td class="frm-rght-clr123" width="14%">
                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="90"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123" width="10%">
                                    Designation
                                </td>
                                <td class="frm-rght-clr123" width="14%" colspan="3">
                                    <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                        DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                        Width="115px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                    </asp:SqlDataSource>
                                </td>
                               <%-- <td class="frm-lft-clr123" width="8%">
                                    Department
                                </td>--%>
                            <%--    <td class="frm-rght-clr123" width="12%">
                                    &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                        Width="115px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name 
"></asp:SqlDataSource>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123" width="10%">
                                    Financial Year<span style="color:Red">*</span>
                                </td>
                                <td class="frm-rght-clr123" width="14%">
                                    <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" CssClass="select"
                                        DataSourceID="SqlDataSource12" DataTextField="financialyear" DataValueField="financialyear"
                                        OnDataBound="dd_year_DataBound" Width="115px">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                        Operator="NotEqual" ToolTip="Select Financial Year" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                    <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="select  [financial_year] as financialyear from tbl_payroll_tax_master order by 1 desc">
                                    </asp:SqlDataSource>
                                </td>
                                <td class="frm-lft-clr123" width="8%">
                                    Reimbursement <span style="color:Red">*</span>
                                </td>
                                <td class="frm-rght-clr123" width="12%">
                                    <asp:DropDownList ID="ddlreimbursement" runat="server" CssClass="select" DataSourceID="SqlDataSource4"
                                        DataTextField="PAYHEAD_NAME" DataValueField="id" OnDataBound="ddlreimbursement_DataBound"
                                        Width="115px">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlreimbursement"
                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                        Operator="NotEqual" ToolTip="Select Reimbursement" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator><asp:SqlDataSource
                                            ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="select [id],[PAYHEAD_NAME] from tbl_payroll_reimbursement">
                                        </asp:SqlDataSource>
                                </td>
                                <td class="frm-lft-clr123" colspan='2' width="8%">
                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                    <asp:Button ID="btnexport" runat="server" CssClass="button" OnClick="btnexport_Click"
                                        Text="Export" />
                                </td>
                                <tr>
                                    <td colspan="6" height="5" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" valign="top">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td valign="middle" class="txt02">
                                                                            &nbsp;Employee List
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="head-2" valign="top">
                                                                            <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                                CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                BorderWidth="0px" AllowPaging="True" PageSize="45" EmptyDataText="No such employee exists !"
                                                                                OnPageIndexChanging="empgrid_PageIndexChanging">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="EmpCode">
                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Wrap="false" Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Emp Name">
                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Wrap="false" Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Designation">
                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Wrap="false" Width="19%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                  <%--  <asp:TemplateField HeaderText="Department">
                                                                                        <HeaderStyle Wrap="false" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Width="17%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>--%>
                                                                                    <asp:TemplateField HeaderText="Amount">
                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Wrap="false" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Total") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Sanction">
                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Wrap="false" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("SANCTIONED") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Balance">
                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                        <ItemStyle Wrap="false" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Balance") %>'></asp:Label>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                    </td>
                </tr>
            </table>
            </table></td> </tr>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnexport" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
