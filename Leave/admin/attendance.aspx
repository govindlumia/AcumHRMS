<%@ Page Language="C#" AutoEventWireup="true" CodeFile="attendance.aspx.cs" Inherits="leave_admin_attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Attendance</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
                                    <img src="../images/loading.gif" alt="" />
                                </td>
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../images/employee-icon.jpg" width="16" height="16" alt="" />
                                                </td>
                                                <td class="txt01">
                                                    Attendace Form
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top" style="height: 5px" class="txt-red" align="right">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" class="frm-lft-clr123" style="width:25%">
                                        Select Employee
<span style="color:Red">*</span>
                                    </td>
                                    <td valign="top" class="frm-rght-clr123">
                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_employee"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />'
                                            ValidationGroup="v"></asp:RequiredFieldValidator>
                                        <%--   <a href="JavaScript:newPopup1('pickemployee_attendance.aspx');" class="link05">Pick
                                            Employee</a>--%>
                                        <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');"
                                            class="link05">Pick Employee</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" class="frm-lft-clr123">
                                        In-Time
<span style="color:Red">*</span>
                                    </td>
                                    <td valign="top" class="frm-rght-clr123">
                                        <div style="float: left">
                                            <asp:TextBox ID="txt_time" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                            <asp:Image ID="imgf" runat="server" ImageUrl="~/Leave/images/clndr.gif" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_time" Display="Dynamic"
                                                ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />' ValidationGroup="v"></asp:RequiredFieldValidator>
                                            <asp:CheckBox runat="server" ID="chk_intime_manual" Text="Enter Manually" OnCheckedChanged="chk_intime_manual_CheckedChanged"
                                                AutoPostBack="true" />
                                        </div>
                                        <div id="dv_in_manual" style="float: right;" runat="server" visible="false">
                                            <asp:DropDownList runat="server" ID="ddl_in_hour" CssClass="input">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;
                                            <asp:DropDownList runat="server" ID="ddl_in_minute" CssClass="input">
                                            </asp:DropDownList>
                                            &nbsp; &nbsp;
                                            <asp:RadioButtonList runat="server" ID="rbtn_in_ampm" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="am" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="pm" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%" valign="middle" class="frm-lft-clr123">
                                        Out-Time
<span style="color:Red">*</span>
                                    </td>
                                    <td width="85%" valign="top" class="frm-rght-clr123">
                                        <div style="float: left">
                                            <asp:TextBox ID="txtouttime" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                            <asp:Image ID="imgouttime" runat="server" ImageUrl="~/Leave/images/clndr.gif" /><asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtouttime" Display="Dynamic"
                                                ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />' ValidationGroup="v"></asp:RequiredFieldValidator>
                                            <asp:CheckBox runat="server" ID="chk_out_manual" Text="Enter Manually" OnCheckedChanged="chk_out_manual_CheckedChanged"
                                                AutoPostBack="true" />
                                        </div>
                                        <div id="dv_out_manual" style="float: right" runat="server" visible="false">
                                            <asp:DropDownList runat="server" ID="ddl_out_hour" CssClass="input">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;
                                            <asp:DropDownList runat="server" ID="ddl_out_minute" CssClass="input">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;
                                            <asp:RadioButtonList runat="server" ID="rbtn_out_ampm" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="am" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="pm" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" class="frm-lft-clr123">
                                        Date
<span style="color:Red">*</span>
                                    </td>
                                    <td valign="top" class="frm-rght-clr123">
                                        <asp:TextBox ID="txt_date" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                        <asp:Image ID="img_date" runat="server" ImageUrl="~/images/clndr.gif" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_date"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />'
                                            ValidationGroup="v"></asp:RequiredFieldValidator>
                                        <span style="padding-left: 40px">
                                            <asp:CheckBox runat="server" ID="chk_isOD" Visible="false" Text="Is OD" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2" valign="top">
                                        (<img alt="Select employee" src="../images/error1.gif" />) is mandatory fields
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:Button ID="btn_sbmit" runat="server" CssClass="button" Text="Submit" ValidationGroup="v"
                                            OnClick="btn_sbmit_Click" />
                                        <asp:Button ID="btn_rst" runat="server" CssClass="button" Text="Reset" OnClick="btn_rst_Click" />
                                    </td>
                                </tr>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_date"
                                TargetControlID="txt_date" Format="dd-MMM-yyyy">
                            </cc1:CalendarExtender>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
