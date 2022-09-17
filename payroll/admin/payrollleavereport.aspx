<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payrollleavereport.aspx.cs"
    Inherits="payroll_admin_payrollleavereport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Acuminous Software. :: Leave Details</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
       <cc1:ToolkitScriptManager runat="server" ID="tsmgr"></cc1:ToolkitScriptManager>
        <%--
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
                        &nbsp;Search Employee Criteria</td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                        <asp:RadioButton ID="rbtnusedleave" runat="server" AutoPostBack="True" GroupName="p"
                            Text="Used Leave" OnCheckedChanged="rbtnusedleave_CheckedChanged" />&nbsp;<asp:RadioButton
                                ID="rbtnbalancedleave" runat="server" AutoPostBack="True" Checked="True" GroupName="p"
                                Text="Balanced Leave" OnCheckedChanged="rbtnbalancedleave_CheckedChanged" /></td>
                </tr>
                <tr>
                    <td height="5" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frm-lft-clr123" width="15%">
                                    Designation</td>
                                <td class="frm-rght-clr123" width="15%">
                                    &nbsp;<asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                        DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                        Width="158px">
                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                    </asp:SqlDataSource>
                                </td>
                                <td class="frm-lft-clr123" colspan="2"
                                >
                                    </td>
                              <%--  <td class="frm-rght-clr123" width="15%">
                                    &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                        Width="145px">
                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                    </asp:SqlDataSource>
                                </td>--%>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123" width="15%">
                                    Financial Year</td>
                                <td class="frm-rght-clr123" width="15%">
                                    &nbsp;<asp:Label ID="lbl_fyear" runat="server"></asp:Label></td>
                                <td class="frm-lft-clr123" width="15%">
                                    Month</td>
                                <td class="frm-lft-clr123">
                                    &nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select">
                                        <asp:ListItem Value="1">Jan</asp:ListItem>
                                        <asp:ListItem Value="2">Feb</asp:ListItem>
                                        <asp:ListItem Value="3">Mar</asp:ListItem>
                                        <asp:ListItem Value="4">Apr</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">Jun</asp:ListItem>
                                        <asp:ListItem Value="7">Jul</asp:ListItem>
                                        <asp:ListItem Value="8">Aug</asp:ListItem>
                                        <asp:ListItem Value="9">Sep</asp:ListItem>
                                        <asp:ListItem Value="10">Oct</asp:ListItem>
                                        <asp:ListItem Value="11">Nov</asp:ListItem>
                                        <asp:ListItem Value="12">Dec</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp; &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="7">
                                    &nbsp;</td>
                            </tr>
                            <tr id="date" runat="server">
                                <td class="frm-lft-clr123" width="14%">
                                    From Date</td>
                                <td class="frm-rght-clr123" width="15%">
                                    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                    <cc1:CalendarExtender ID="cextender" Format="dd-MMM-yyyy" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="frm-lft-clr123" width="14%%">
                                    To Date</td>
                                <td class="frm-rght-clr123" colspan="3" width="20%">
                                    <asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox>
                                    <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                    <cc1:CalendarExtender ID="cextender1" Format="dd-MMM-yyyy" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate">
                                    </cc1:CalendarExtender>
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
                    <td height="5" valign="top">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td valign="top" align="right">
                                    <asp:Button ID="btnreport" runat="server" CssClass="button" Text="Report" ToolTip="View Report"
                                        OnClick="btnreport_Click" />&nbsp;&nbsp; &nbsp;<asp:Button ID="btnexport" runat="server"
                                            CssClass="button" ToolTip="Export" Text="Export" OnClick="btnexport_Click" />&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" class="txt02">
                                                &nbsp;Employee Record</td>
                                        </tr>
                                        <tr>
                                            <td class="head-2" valign="top">
                                                <div style="overflow-x: scroll; overflow-y: hidden; width: 1000px;">
                                                    <asp:GridView ID="empgrid" GridLines="Both" runat="server" Width="100%" AllowPaging="True"
                                                        OnPageIndexChanging="empgrid_PageIndexChanging" PageSize="50">
                                                        <HeaderStyle Wrap="true" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <RowStyle CssClass="frm-rght-clr1234" />
                                                    </asp:GridView>
                                                </div>
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
        </div>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
