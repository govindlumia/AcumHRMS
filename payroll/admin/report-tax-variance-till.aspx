<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-tax-variance-till.aspx.cs"
    Inherits="payroll_admin_report_tax_variance_till" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script type="text/javascript" language="javascript">

function returnempcode(val,val2)

{
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
        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
               <div class="divajax">
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
        <table width="712" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="middle" class="txt02 blue-brdr-1">
                    &nbsp;Report Tax Variance</td>
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
                                &nbsp;Name</td>
                            <td class="frm-rght-clr123" width="14%">
                                <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="90"></asp:TextBox>
                            </td>
                            <td class="frm-lft-clr123" width="10%">
                                Designation</td>
                            <td class="frm-rght-clr123" width="14%">
                                <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                    DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                    Width="115px">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                </asp:SqlDataSource>
                            </td>
                           <%-- <td class="frm-lft-clr123" width="8%">
                                Department&nbsp;</td>
                            <td class="frm-rght-clr123" width="12%">
                                &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                    Width="115px">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                </asp:SqlDataSource>
                            </td>--%>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123" width="10%">
                                Financial Year<span style="color:Red">*</span></td>
                            <td class="frm-rght-clr123" width="14%">
                                <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" CssClass="select"
                                    DataSourceID="SqlDataSource12" DataTextField="financialyear" DataValueField="financialyear"
                                    OnDataBound="dd_year_DataBound" Width="115px">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                    Operator="NotEqual" ToolTip="Select Financial Year" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="select  [financial_year] as financialyear from tbl_payroll_tax_master order by id desc">
                                </asp:SqlDataSource>
                            </td>
                            <td class="frm-lft-clr123" style="width: 0%">
                            </td>
                            <td class="frm-rght-clr123" style="width: 0%">
                                &nbsp;<asp:DropDownList ID="dd_month" runat="server" Width="129px" Visible="false"
                                    ToolTip="Month" CssClass="select">
                                    <asp:ListItem Value="0">---Select Month---</asp:ListItem>
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
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_month"
                                    Display="Dynamic" Visible="false" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                    Operator="NotEqual" ToolTip="Select Month" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                            </td>
                            <td class="frm-lft-clr123" colspan='2' width="8%">
                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export" OnClick="btnexport_Click" /></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="6" valign="top">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table>
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
                                                    <td valign="middle" class="txt02" style="height: 24px">
                                                        &nbsp;Employee List</td>
                                                </tr>
                                                <tr>
                                                    <td class="head-2" valign="top" style="width:100%">
                                                        <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                            CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                            OnPageIndexChanging="empgrid_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Emp Code">
                                                                    <HeaderStyle Wrap="false" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Wrap="false" Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Name">
                                                                    <HeaderStyle Wrap="false" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Wrap="false" Width="21%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Designation">
                                                                    <HeaderStyle Wrap="false" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Wrap="false" Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            <%--    <asp:TemplateField HeaderText="Department">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Wrap="false" Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Month">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Wrap="false" Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("month") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Monthly Tax">
                                                                    <HeaderStyle Wrap="false" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind ("total_tax") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Gross Amt(M)">
                                                                    <HeaderStyle Wrap="false" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind ("gross_amount") %>'></asp:Label>
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
        </table>
        <%-- </table></td>
    </tr>--%>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
        <%--</TD></TR></TABLE>--%>
    </form>
</body>
</html>
