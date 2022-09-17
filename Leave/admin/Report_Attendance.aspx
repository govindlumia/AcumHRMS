<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Attendance.aspx.cs"
    Inherits="leave_admin_Report_Attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
   <%-- <title>Acuminous Software Intranet</title>--%>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        fieldset
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
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <%-- <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>--%>
    <cc1:ToolkitScriptManager ID="leave" runat="server">
    </cc1:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
    <table width="718" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" height="463px" colspan="5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Leave&nbsp;balance&nbsp;Report
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="20%">
                                        From Date
                                    </td>
                                    <td class="frm-rght-clr123" width="30%">
                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
                                            ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                            ValidationGroup="c" ValueToCompare="MM/dd/yyyy" Display="Dynamic"></asp:CompareValidator>
                                        <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate"
                                            Format="MM/dd/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td class="frm-lft-clr123" width="20%">
                                        &nbsp;To Date
                                    </td>
                                    <td class="frm-rght-clr123" width="30%">
                                        &nbsp;<asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox><asp:Image
                                            ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_edate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                ValidationGroup="c"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                                                    runat="server" ControlToValidate="txt_edate" Display="Dynamic" ErrorMessage="Check date format(MM/dd/yyyy)"
                                                    Operator="DataTypeCheck" Type="Date" ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator><cc1:CalendarExtender
                                                        ID="CalendarExtender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate"
                                                        Format="MM/dd/yyyy">
                                                    </cc1:CalendarExtender>
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" colspan="4">
                                        <%--<fieldset>
                                            <legend><b>Attendance Report Criteria</b></legend>--%>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-rght-clr123">
                                                    <asp:RadioButton ID="rbtnMan" runat="server" Visible="false" Checked="false" GroupName="e"
                                                        Text="ManHour Report" />&nbsp;&nbsp; &nbsp;&nbsp;<asp:RadioButton ID="rbtnAttend"
                                                            Visible="false" runat="server" GroupName="e" Text="Attendance Report" />&nbsp;&nbsp;
                                                    &nbsp;&nbsp;<asp:RadioButton ID="rbtnHF" Visible="false" runat="server" GroupName="e"
                                                        Text="HF Report" />&nbsp;&nbsp; &nbsp;&nbsp;<asp:RadioButton ID="rbtnLeave" Checked="True"
                                                            runat="server" GroupName="e" Text="Leave Report" />&nbsp; &nbsp;
                                                    <asp:RadioButton ID="rbtnIN" runat="server" Visible="false" GroupName="e" Text="Present Without IN-OUT Report" />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <%-- </fieldset>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-rght-clr123" colspan="4">
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click"
                                            ValidationGroup="c" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="7">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="txt02">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="27%" class="txt02" style="height: 13px">
                                                    &nbsp;
                                                </td>
                                                <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnexport" runat="server" Visible="false" CssClass="button" OnClick="btnexport_Click"
                                            Text="Export" ToolTip="Export" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="head-2">
                            <asp:GridView ID="GridView1" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"
                                Width="100%" AllowPaging="True" BorderWidth="1px" OnPageIndexChanging="GridView1_PageIndexChanging"
                                PageSize="20" GridLines="Both">
                                <PagerSettings Position="TopAndBottom"></PagerSettings>
                                <RowStyle CssClass="frm-rght-clr1234" Height="5px"></RowStyle>
                                <FooterStyle CssClass="frm-lft-clr123"></FooterStyle>
                                <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
</asp:UpdatePanel>  --%>
    </form>
</body>
</html>
