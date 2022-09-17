<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_reimbursement.aspx.cs"
    Inherits="payroll_admin_view_reimbursement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        <cc1:ToolkitScriptManager ID="leave" runat="server">
        </cc1:ToolkitScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
        <%-- <div>--%>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="middle" class="txt02 blue-brdr-1">
                    &nbsp;Search Reimbursement Detail</td>
            </tr>
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="frm-lft-clr123" width="19%">
                                Employee Name</td>
                            <td class="frm-rght-clr123" width="31%">
                                <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox></td>
                            <td width="1%" rowspan="6">
                                &nbsp;</td>
                           <%-- <td class="frm-lft-clr123" width="18%">
                                Branch</td>
                            <td class="frm-rght-clr123" width="31%">
                                <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                    DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_BranchMaster]">
                                </asp:SqlDataSource>
                            </td>--%>
                             <td class="frm-lft-clr123">
                                Ref. Number</td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_ref" runat="server" CssClass="input"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                            </td>
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                     <%--   <tr>
                            <td class="frm-lft-clr123">
                                Department</td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="dd_dept" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                </asp:SqlDataSource>
                            </td>
                            <td class="frm-lft-clr123">
                                Ref. Number</td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_ref" runat="server" CssClass="input"></asp:TextBox></td>
                        </tr>--%>
                        <tr>
                            <td height="5" colspan="2">
                            </td>
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                From Date<span style="color:Red">*</span></td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="True"></asp:TextBox><asp:Image
                                    ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" /><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate" ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                        <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="dd-MMM-yyyy">
                                        </cc1:CalendarExtender>
                            </td>
                            <td class="frm-lft-clr123">
                                To Date<span style="color:Red">*</span></td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="True"></asp:TextBox>
                                <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate" Format="dd-MMM-yyyy">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                            </td>
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Reimbursement</td>
                            <td class="frm-rght-clr123" width="31%">
                                <asp:DropDownList ID="dd_reimb" runat="server" CssClass="select" Width="145px" DataSourceID="SqlDataSource4"
                                    DataTextField="PAYHEAD_NAME" DataValueField="ID" OnDataBound="dd_reimb_DataBound">
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], [PAYHEAD_NAME] FROM [tbl_payroll_reimbursement]">
                                </asp:SqlDataSource>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="4" align="right">
                                <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click"
                                    Text="Search" />
                                <input class="button" value="Back" type="button" runat="server" onclick="javascript:history.go(-1)" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="100%">
                                                        <table width="100%">
                                                            <tr>
                                                                <td height="18" valign="top" class="txt02">
                                                                    Employee List</td>
                                                                <td align="right">
                                                                    <span id="message" runat="server" class="txt02"></span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="head-2" valign="top">
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
                                    <tr>
                                        <td valign="top" class="head-2">
                                            <div style="overflow-x: scroll; overflow-y: hidden; width: 709px;">
                                                <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                    CellPadding="4" DataKeyNames="reimbursement_ref_no" AutoGenerateColumns="False"
                                                    BorderWidth="0px" Width="100%" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                    OnPageIndexChanging="empgrid_PageIndexChanging1" 
                                                    onrowdatabound="empgrid_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Ref No.">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("reimbursement_ref_no") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Reimbursment">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="11%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("PAYHEAD_NAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="EmpCode">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_empcode" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      <%--  <asp:TemplateField HeaderText="Branch">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Dept">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="7%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle Width="9%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>

                                                         <%--  <%# DataBinder.Eval(Container.DataItem,"sanction_date","{0:dd-MMM-yyyy}") %>--%>
                                                                <asp:Label ID="lbl_sanctiondate" runat="server" Text='<%#Eval("sanction_date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="left" VerticalAlign="Top"
                                                                Width="7%" />
                                                            <ItemTemplate>
                                                                <a class="link05" target="content"  href="view_reimbursement_detail.aspx?reimbursement_ref_no=<%#DataBinder.Eval(Container.DataItem, "reimbursement_ref_no")%>">
                                                                    View</a> | <a class="link05" target="content" href="edit_reimbursement_detail.aspx?reimbursement_ref_no=<%#DataBinder.Eval(Container.DataItem, "reimbursement_ref_no")%>">
                                                                        Edit</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                    <RowStyle Height="5px" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--</div>--%>
        <%--   </ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
