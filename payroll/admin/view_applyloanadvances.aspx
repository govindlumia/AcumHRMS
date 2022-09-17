<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_applyloanadvances.aspx.cs"
    Inherits="payroll_applyloanadvances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager  ID="payroll" runat="server">
        </cc1:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                            <td valign="top" height="463px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%" style="height: 16px">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01" style="height: 16px">
                                                        View Loan/Advances Applications</td>
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
                                                                    Search Applications</td>
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
                                                                <td class="frm-lft-clr123" >
                                                                    Loan Reference No.</td>
                                                                <td class="frm-rght-clr123" >
                                                                    <asp:TextBox ID="txt_loanrefno" runat="server" CssClass="input" Width="100px"></asp:TextBox></td>
                                                                <td width="1%" rowspan="5">
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Employee Code</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input" ></asp:TextBox>
                                                             <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');" class="link05">Pick Employee</a>&nbsp;
                                                             
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="5">
                                                                </td>
                                                                <td height="5" colspan="5">
                                                                </td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Branch</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSourceBranch"
                                                                        DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound"
                                                                        Width="110px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Department</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_dept" runat="server" CssClass="select" DataSourceID="SqlDataSourceDept"
                                                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound"
                                                                        Width="145px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceDept" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name"
                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td height="5" colspan="5">
                                                                </td>
                                                                <td height="5" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Loan/Advances Name</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_loanname" runat="server" CssClass="select" DataSourceID="SqlDataSourceLoan"
                                                                        DataTextField="loan_name" DataValueField="id" OnDataBound="dd_loanname_DataBound"
                                                                        Width="110px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceLoan" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="select [id],[loan_name] from tbl_payroll_loan_advances where status=1"
                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Sanction Date</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_sdate" runat="server" CssClass="input2" Width="90px"></asp:TextBox>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" Format="dd-MMM-yyyy"
                                                                        TargetControlID="txt_sdate">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="5" height="25" valign="bottom">
                                                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
                                                                    <input type="button" id="Button1" class="button" value="Back" onclick="javascript:history.go(-1);" /></td>
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
                                                                                        <td valign="top" class="txt02" style="height: 20px">
                                                                                            Employee List</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="head-2" valign="top">
                                                                                            <div style="overflow-x: scroll; overflow-y: hidden; width: 709px; position: absolute;">
                                                                                                <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                                                    CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                                    BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such loan entry exists !"
                                                                                                    OnPageIndexChanging="griddetail_PageIndexChanging" 
                                                                                                    onrowdatabound="griddetail_RowDataBound">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="RefNo.">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("loan_ref_id") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Emp Code">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
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
                                                                                                  <%--      <asp:TemplateField HeaderText="Branch">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Dept">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>--%>
                                                                                                        <asp:TemplateField HeaderText="Loan/Adv.">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="9%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l5" runat="server" Text='<%# Bind ("loan_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Loan Amt">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l6" runat="server" Text='<%# Bind ("loan_amount") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Sanc.Date">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label  runat="server" ID="txt_sanct_date" Text='<%# Eval("sanction_date")   %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField>
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                                                                Width="9%" />
                                                                                                            <ItemTemplate>
                                                                                                                <a class="link05" href="view_applyloanadvances_detail.aspx?loan_id=<%#DataBinder.Eval(Container.DataItem, "loan_id")%>"
                                                                                                                    target="_self">View</a> | <a class="link05" href="edit_applyloanadvances_detail.aspx?loan_id=<%#DataBinder.Eval(Container.DataItem, "loan_id")%>"
                                                                                                                        target="_self">Edit</a>
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
                                                                                    runat="server" SelectCommand="sp_payroll_fetch_loandetail" SelectCommandType="StoredProcedure">
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
