<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalarySheetNew.aspx.cs" Inherits="payroll_admin_SalarySheetNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        absolute fieldset
        {
            margin: 0;
            padding: 0;
            border: 1px solid #c9dffb;
            padding: 0 7px 10px 7px;
        }
        legend
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #08486d;
            padding-bottom: 0px;
            padding-top: 2px;
        }
    </style>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server" AsyncPostBackTimeout="50000">
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
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" colspan="5">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%" style="height: 16px">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td id="Td1" class="txt01" runat="server" style="width: 347px; height: 16px">
                                                Salary Sheet Report
                                            </td>
                                            <td id="Td2" runat="server" align="right" class="txt02" style="height: 16px">
                                                <asp:Label ID="lbl_message" runat="server" Enabled="true" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                    <%--<asp:RadioButton ID="rbtnprocess" runat="server" Checked="true" AutoPostBack="True" OnCheckedChanged="rbtnprocess_CheckedChanged" Text="Process Attendance" GroupName="c" /> | <asp:RadioButton ID="rbtnupload" runat="server" Checked="false" AutoPostBack="True" Text="Upload Attendance" GroupName="c" OnCheckedChanged="rbtnupload_CheckedChanged" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="20%">
                                                Financial Year
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2" style="width: 572px">
                                            <asp:DropDownList runat="server" ID="ddl_fyear" CssClass="select2"></asp:DropDownList>
                                              <%--  &nbsp;<asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Select Month
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2" style="width: 572px">
                                                &nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" AutoPostBack="True"
                                                    OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Select Company<span style="color: Red">*</span>
                                            </td>
                                            <td align="left" colspan="2" class="frm-rght-clr123" style="width: 572px">
                                                &nbsp;<asp:DropDownList ID="ddlcompany" runat="server" CssClass="select" DataTextField="companyname"
                                                    DataValueField="companyid" Width="140px" OnDataBound="ddlcompany_DataBound" OnSelectedIndexChanged="ddlcompany_selectIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                &nbsp;
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlcompany"
                                                    ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [companyid], [companyname] FROM [tbl_intranet_companydetails]">
                                                    </asp:SqlDataSource>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="3">
                                            </td>
                                        </tr>
                                        <%--     <tr>
                                                <td class="frm-lft-clr123">
                                                    Select Branch</td>
                                                <td align="left" colspan="2" class="frm-rght-clr123" style="width: 572px">
                                                    &nbsp;<asp:DropDownList ID="ddlbranch" runat="server" CssClass="select"
                                                        DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound"
                                                        Width="140px">
                                                    </asp:DropDownList>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlbranch"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td height="5" colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Select Department</td>
                                                <td align="left" colspan="2" class="frm-rght-clr123" style="width: 572px">
                                                    &nbsp;<asp:DropDownList ID="ddlDepartment" runat="server" CssClass="select"
                                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddlDepartment_DataBound"
                                                        Width="140px">
                                                    </asp:DropDownList>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlDepartment"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td height="5" colspan="3">
                                                </td>
                                            </tr>
                                            <tr>
                                             <td class="frm-lft-clr123">
                                                                Salary to be Paid in Phase
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:DropDownList ID="ddlPhase" runat="server" CssClass="select" Height="20px">
                                                                    <asp:ListItem Text="Phase 1"></asp:ListItem>
                                                                    <asp:ListItem Text="Phase 2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                            </tr>
                                        --%>
                                        <tr>
                                            <td height="5" colspan="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <div id="processattendance" runat="server">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" style="width: 137px">
                                                                Fetch Report
                                                            </td>
                                                            <td align="left" class="frm-rght-clr123" colspan="2">
                                                                &nbsp;<asp:Button ID="btn_procs_att" runat="server" CssClass="button2" Text="Fetch Report"
                                                                    ValidationGroup="v" OnClick="btn_procs_att_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="15" colspan="3">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                            <tr>
                                <td height="7" class="frm-rght-clr123">
                                    <asp:Button ID="btnexport" runat="server" CssClass="button" OnClick="btnexport_Click"
                                        Text="Export" ToolTip="Export" />
                                </td>
                            </tr>
                            <tr>
                                <td class="head-2" valign="top">
                                    <div style="overflow-x: scroll; overflow-y: hidden;">
                                        <asp:GridView ID="empgrid" GridLines="Both" runat="server" Width="100%" AllowPaging="True" EmptyDataText="No data found(s)"
                                            OnPageIndexChanging="empgrid_PageIndexChanging" PageSize="50">
                                            <HeaderStyle Wrap="true" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <RowStyle CssClass="frm-rght-clr1234" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnexport" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
