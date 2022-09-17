<%@ Page Language="C#" AutoEventWireup="true" CodeFile="costofemployee.aspx.cs" Inherits="payroll_admin_paystructureempview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
@import "../../css/example.css";
</style>

    <script type="text/javascript" src="../../js/tabber.js"></script>

    <script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <link href="../../css/blue1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%" style="height: 16px">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                    <td class="txt01" style="height: 16px">
                                        Cost of Employee</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="txt02" height="23">
                            &nbsp;Cost of Employee</td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="5" width="100%">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                    runat="server">
                                                    <ProgressTemplate>
                                                        <div class="divajax" style="top: 160px;">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center" valign="top" style="height: 34px">
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
                                                <table>
                                                    <tr>
                                                        <td class="frm-rght-clr123" colspan="4">
                                                            <asp:RadioButton ID="rdo_D" Text="Detail" runat="server" Checked="True" GroupName="r" />
                                                            <asp:RadioButton ID="rdo_S" Text="Summarize" runat="server" GroupName="r" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="19%">
                                                            Branch</td>
                                                        <td class="frm-rght-clr123" width="19%">
                                                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_designation_DataBound"
                                                                Width="130px" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT branch_id, branch_name FROM tbl_BranchMaster">
                                                            </asp:SqlDataSource>
                                                        </td>
                                                        <td class="frm-lft-clr123" width="11%">
                                                            Department</td>
                                                        <td class="frm-rght-clr123" width="19%">
                                                            <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                                Width="130px">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid where branch_id=@branch or 0=@branch order by department_name 
">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="dd_designation" DefaultValue="0" Name="branch" PropertyName="SelectedValue" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" width="11%">
                                        Year</td>
                                    <td class="frm-rght-clr123" width="11%">
                                        <asp:DropDownList ID="ddl_year" runat="server" CssClass="select" DataSourceID="SqlYear"
                                            DataTextField="year" DataValueField="year">
                                        </asp:DropDownList><asp:SqlDataSource ID="SqlYear" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                            SelectCommand="select distinct year from tbl_payroll_employee_salary order by year desc">
                                        </asp:SqlDataSource>
                                    </td>
                                    <td class="frm-lft-clr123" width="11%">
                                        Month</td>
                                    <td class="frm-rght-clr123" width="19%">
                                        <asp:DropDownList ID="ddl_month" runat="server" CssClass="select">
                                            <asp:ListItem Selected="True">None</asp:ListItem>
                                            <asp:ListItem>Jan</asp:ListItem>
                                            <asp:ListItem>Feb</asp:ListItem>
                                            <asp:ListItem>Mar</asp:ListItem>
                                            <asp:ListItem>Apr</asp:ListItem>
                                            <asp:ListItem>May</asp:ListItem>
                                            <asp:ListItem>Jun</asp:ListItem>
                                            <asp:ListItem>Jul</asp:ListItem>
                                            <asp:ListItem>Aug</asp:ListItem>
                                            <asp:ListItem>Sep</asp:ListItem>
                                            <asp:ListItem>Oct</asp:ListItem>
                                            <asp:ListItem>Nov</asp:ListItem>
                                            <asp:ListItem>Dec</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td class="frm-rght-clr123">
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
