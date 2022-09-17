<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthwisereport.aspx.cs"
    Inherits="leave_monthwisereport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Report</title>
    <script type="text/javascript" language="javascript" src="js/popup.js"></script>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leaveapply1" runat="server" AsyncPostBackTimeout="6000">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="wht-clr">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="txt01">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" align="absmiddle" alt="" />
                                        &nbsp;Monthwise Attendance Report
                                    </td>
                                    <td width="50%" valign="middle" align="right" class="txt-red">
                                        <span id="message" runat="server" enableviewstate="false"></span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td valign="middle" class="frm-lft-clr123" width="20%">
                                                    Select Year<span style="color:Red">*</span>
                                                </td>
                                                <td valign="middle" class="frm-rght-clr123" width="80%">
                                                    <asp:DropDownList ID="dd_year" runat="server" CssClass="select1" Width="150px" OnDataBound="dd_year_DataBound">
                                                        <asp:ListItem Value="0">Select Year</asp:ListItem>
                                                        <asp:ListItem>2012</asp:ListItem>
                                                        <asp:ListItem>2013</asp:ListItem>
                                                        <asp:ListItem>2014</asp:ListItem>
                                                        <asp:ListItem>2015</asp:ListItem>
                                                        <asp:ListItem>2016</asp:ListItem>
                                                        <asp:ListItem>2017</asp:ListItem>
                                                        <asp:ListItem>2018</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                                        ErrorMessage='<img src="../images/error1.gif" alt="Select Policy" />' Operator="NotEqual"
                                                        ValueToCompare="0" ValidationGroup="a"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" class="frm-lft-clr123" width="20%">
                                                    Select Month<span style="color:Red">*</span>
                                                </td>
                                                <td valign="middle" class="frm-rght-clr123" width="80%">
                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="select1" Width="150px" OnDataBound="dd_month_DataBound"
                                                        OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">Select Month</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--<asp:RequiredFieldValidator ID="rfvld" runat="server" ControlToValidate="dd_month"  InitialValue="0"
                                                        ErrorMessage='<img src="../images/error1.gif" alt="Select Policy" />' ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="txt-red">
                                                    <span id="Span1" runat="server" class="txt-red"></span>
                                                </td>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" class="frm-lft-clr123" width="20%">
                                                    <%--Select Category--%>
                                                    Select Department
                                                </td>
                                                <td valign="middle" class="frm-rght-clr123" width="80%">
                                                    <asp:DropDownList ID="dd_dept" runat="server" CssClass="select2" Width="150px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Employee Name
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_employee" MaxLength="20" runat="server" CssClass="input" Width="145px"></asp:TextBox>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td class="frm-lft-clr123">
                                                   Select Company
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList runat="server" ID="ddl_cmpny" CssClass="select2"></asp:DropDownList>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                              <tr>
                                                <td class="frm-lft-clr123">
                                                   Include Past Employees
                                                </td>
                                                <td class="frm-rght-clr123">
                                             <asp:CheckBox runat="server" ID="chk_empstatus" Text="" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <td valign="middle" class="frm-lft-clr123" width="20%">
                                                </td>
                                                <td valign="middle" class="frm-rght-clr123" width="80%">
                                                    <asp:Button ID="btnreport" runat="server" Text="Report" CssClass="button" OnClick="btnreport_Click" ValidationGroup="a" />&nbsp;
                                                 <span style="padding-left:100px">   <asp:Button ID="btnexport" runat="server" CssClass="button2" OnClick="btnexport_Click"
                                                        Text="Export To Excel" ToolTip="Export" ValidationGroup="a" /> </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="head-2">
                            <div style="overflow: scroll; width: 700px; position: absolute;">
                                <asp:GridView ID="GridView1" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"
                                    BorderWidth="1px" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    PageSize="20" onrowdatabound="GridView1_RowDataBound">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <PagerStyle CssClass="frm-lft-clr123" />
                                </asp:GridView>
                            </div>
                        </td>
                        <tr>
                            <td style="height: 10px">
                                &nbsp;
                            </td>
                        </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
