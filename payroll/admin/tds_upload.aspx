<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tds_upload.aspx.cs" Inherits="payroll_admin_tds_upload" %>

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
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
            <ProgressTemplate>
                <div class="divajax" style="left: 250px; top: 150px">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
                <table cellspacing="0" cellpadding="0" width="718" border="0">
                    <tr>
                        <td valign="top">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="blue-brdr-1" valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tr>
                                                <td width="3%">
                                                    <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                </td>
                                                <td class="txt01">
                                                    TDS Amendment Upload</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="20">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td class="txt02" width="27%">
                                                    Employee TDS Amendment</td>
                                                <td class="txt-red" align="right" width="73%">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 123px" valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Upload Excel</td>
                                                <td class="frm-rght-clr123">
                                                    <asp:FileUpload ID="fupload" runat="server" CssClass="input" ToolTip="Upload File here"
                                                        Width="200px" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                        ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$" ValidationGroup="a"><img src="../../images/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                            ID="rfvupload" runat="server" ControlToValidate="fupload" Display="Dynamic" ErrorMessage="Attach Document"
                                                            ToolTip="Attach Document" ValidationGroup="a"><img src="../../images/error1.gif" alt="Attach Document" /></asp:RequiredFieldValidator>
                                           <span  style="text-align:right;padding-left:60px">
                                           <a href="reports/Format for TDS Upload.xls" style="text-decoration:none"> Format for file upload</a>
                                           </span>
                                           
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    &nbsp;</td>
                                                <td class="frm-rght-clr123" width="75%">
                                                    &nbsp;<asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Upload" OnClick="btnsubmit_Click"
                                                        ValidationGroup="a" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    Mandatory Fields (<img alt="" src="../../images/error1.gif" />)</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="20">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td class="txt02" width="27%" style="height: 13px">
                                                    Employee TDS Amendment</td>
                                                <td class="txt-red" align="right" width="73%" style="height: 13px">
                                                    <span id="SPAN1" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="718" border="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="15%">
                                        Emp Name/Code</td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:TextBox ID="txtempcode" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                    </td>
                                    <td class="frm-lft-clr123" width="15%">
                                        Designation</td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                            DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                            Width="119px">
                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_DesignationMaster]">
                                        </asp:SqlDataSource>
                                    </td>
                                 <%--   <td class="frm-lft-clr123" width="13%">
                                        Department</td>--%>
                                    <td class="frm-rght-clr123" colspan="2">
                                       <%-- <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                            DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                            Width="127px">
                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_DepartmentMaster] INNER JOIN tbl_BranchMaster ON tbl_BranchMaster.company_id =tbl_DepartmentMaster.companyid order by department_name">
                                        </asp:SqlDataSource>--%>
                                    </td>
                                    <td class="frm-rght-clr123" width="12%">
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Button ID="btnupdate" runat="server" CssClass="button" Text="Update" OnClick="btnupdate_Click" /></td>
                    </tr>
                    <tr>
                        <td valign="top" height="5">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grid" runat="server" Width="100%" EmptyDataText="Sorry No Records Found"
                                PageSize="100" DataKeyNames="empcode" AllowPaging="true" Font-Size="11px" Font-Names="Arial"
                                CellSpacing="0" CellPadding="4" BorderWidth="1px" AutoGenerateColumns="false"
                                OnPageIndexChanging="grid_PageIndexChanging" OnRowUpdating="grid_RowUpdating"
                                OnRowDeleting="grid_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Emp Code">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblempcodeg" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Emp Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblempnameg" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Applicable">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkstatusg" runat="server" Checked='<%# Convert.ToBoolean(Eval("status"))%>' />
                                            <%--<asp:Label ID="l7" runat="server" Text='<%# Bind("status")%>' ></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtamountg" CssClass="input" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'></asp:TextBox>
                                            <%--<asp:Label ID="l6" runat="server" Text='<%# Bind("amount")%>' ></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="5">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Button ID="btnupdate1" runat="server" CssClass="button" Text="Update"
                                OnClick="btnupdate1_Click" /></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
