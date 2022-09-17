<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewdeclaration.aspx.cs"
    Inherits="payroll_admin_viewdeclaration" %>

    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
         <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="Payroll"
        AsyncPostBackTimeout="2400" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--  <Triggers>
            <asp:PostBackTrigger ControlID="imgExportExcel" />
        </Triggers>--%>
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                    <td valign="bottom">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table width="718" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" height="463px" style="width: 719px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%" style="height: 16px">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01" style="height: 16px">
                                                        View Employee Declaration</td>
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
                                                    <td height="20" valign="top" class="txt02">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="27%" class="txt02">
                                                                    Search Declaration</td>
                                                                <td width="73%" align="right" class="txt-red">
                                                                    <span id="message" runat="server"></span>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="22%">
                                                                    Financial Year</td>
                                                                <td class="frm-rght-clr123" width="27%">
                                                                    <asp:DropDownList ID="dd_fyr" AutoPostBack="false" runat="server" CssClass="select"
                                                                        DataSourceID="SqlDataSourceFYear" DataTextField="financial_year" DataValueField="financial_year"
                                                                        Width="110px">
                                                                        <%--<asp:ListItem>Select Financial Year</asp:ListItem>AppendDataBoundItems="True"--%>
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceFYear" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="SELECT financial_year FROM tbl_payroll_tax_master  order by id desc"
                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                                <td width="1%" rowspan="6">
                                                                </td>
                                                                <td class="frm-lft-clr123" width="22%">
                                                                    Employee Name/Code</td>
                                                                <td class="frm-rght-clr123" width="28%">
                                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="120px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="5">
                                                                </td>
                                                                <td height="5" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td class="frm-lft-clr123">
                                                                    Branch</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSourceBranch"
                                                                        DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound"
                                                                        Width="110px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_BranchMaster]"
                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Department</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_dept" runat="server" CssClass="select" DataSourceID="SqlDataSourceDept"
                                                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound"
                                                                        Width="125px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceDept" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name"
                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td align="right" colspan="5" valign="bottom">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Status</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_status" runat="server" CssClass="select" Width="110px">
                                                                        <asp:ListItem Selected="True" Value="1">Approved</asp:ListItem>
                                                                        <asp:ListItem Value="0">Not approved</asp:ListItem>
                                                                        <asp:ListItem Value="2">Not Applied</asp:ListItem>
                                                                    </asp:DropDownList></td>
                                                                <td class="frm-rght-clr123" colspan='3' align="right">
                                                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
                                                                    <input type="button" id="Button1" class="button" value="Back" onclick="javascript:history.go(-1);" />
                                                               <%--     <asp:ImageButton ID="imgExportExcel" runat="server" ImageUrl="~/images/icon_import_excel.png"
                                                                     Height="30px" Width="30px" ToolTip="Export to Excel" OnClick="imgExportExcel_Click" /></td>--%>
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
                                                                            <td valign="top" style="width: 719px">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td valign="top" class="txt02" style="height: 20px">
                                                                                            Employee List</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="head-2" valign="top">
                                                                                            <div style="overflow-x: scroll; overflow-y: hidden; width: 709px; position: absolute;">
                                                                                                <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                                                    CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                                    BorderWidth="0px" AllowPaging="True" PageSize="100" EmptyDataText="No such declaration found !"
                                                                                                    OnPageIndexChanging="griddetail_PageIndexChanging">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="Emp Code">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                     <%--   <asp:TemplateField HeaderText="Branch">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Department">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>--%>
                                                                                                        <asp:TemplateField HeaderText="Financial Year">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("financialyr") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Status">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l6" runat="server" Text='<%# Bind ("dstatus") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField>
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                                                                Width="8%" />
                                                                                                            <ItemTemplate>
                                                                                                                <%#linkviewdedit(DataBinder.Eval(Container.DataItem, "ref_no").ToString(), DataBinder.Eval(Container.DataItem, "visibility").ToString())%>
                                                                                                                <%--<a class="link05"   href="viewdeclarationdetail.aspx?ref_no=<%#DataBinder.Eval(Container.DataItem, "ref_no")%>" target="_self">View</a> |  
                       <a class="link05"  href="editdeclarationdetail.aspx?ref_no=<%#DataBinder.Eval(Container.DataItem, "ref_no")%>" target="_self">Edit</a>  
--%>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                    <RowStyle Height="5px" />
                                                                                                    <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    runat="server" SelectCommand="sp_payroll_fetch_declaration_detail" SelectCommandType="StoredProcedure">
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
                                    <tr>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
