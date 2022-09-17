<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyod.aspx.cs" Inherits="leave_applyod" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply OD</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        .style2
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #013366;
            width: 184px;
            border-left: 1px solid #c9dffb;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #c9dffb;
            border-bottom: 1px solid #c9dffb;
            padding-left: 5px;
            padding-right: 0;
            padding-top: 4px;
            padding-bottom: 4px;
            background: #edf5ff;
        }
        .completionList
        {
            border: solid 1px Gray;
            margin: 0px;
            padding: 3px;
            height: 120px;
            overflow-y: scroll;
            background-color: #FFFFFF;
        }
        
        .listItem
        {
            color: #191919;
        }
        
        .itemHighlighted
        {
            background-color: #ADD6FF;
        }
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
    <%-- <asp:ScriptManager runat="server" ID="scrpt_mngr"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../images/loading.gif" />
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
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                                </td>
                                                <td class="txt01">
                                                    Official Duty
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="9">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top" class="txt02">
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    &nbsp;Employee Information
                                                </td>
                                                <td class="txt-red" align="right">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Employee Name<span style="color:Red">*</span>
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_employee" AutoPostBack="true" MaxLength="30" runat="server" OnTextChanged="txt_employee_changed"></asp:TextBox>
                                                    <ajax:AutoCompleteExtender runat="server" ID="ACE_txt_employee" MinimumPrefixLength="1"
                                                        CompletionSetCount="10" CompletionInterval="200" TargetControlID="txt_employee"
                                                        ServiceMethod="AutoComplete_Employee" ServicePath="~/TimeSheet/User/ProjectReportForHC.aspx"
                                                        CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"
                                                        UseContextKey="true">
                                                    </ajax:AutoCompleteExtender>
                                                </td>
                                                <td width="1%" rowspan="7">
                                                    &nbsp;
                                                </td>
                                                <td width="18%" class="frm-lft-clr123">
                                                    Employee Code
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_emp_code" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Department
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_category" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl_gender" Visible="false" runat="server"></asp:Label>
                                                </td>
                                                <td width="18%" class="frm-lft-clr123">
                                                    Designation
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl_branch" Visible="false" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl_doj" runat="server" Visible="false"></asp:Label>
                                                    <asp:Label ID="lbl_emp_status" runat="server" Visible="false"></asp:Label>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 10px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top" class="txt02">
                                        &nbsp;Apply Official Duty
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td colspan="2">
                                                    <div id="div" runat="server">
                                                        <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged"
                                                            Text="Full Day" ValidationGroup="noone" AutoPostBack="True" />
                                                        <asp:RadioButton ID="rdohalfday" runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged"
                                                            Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div id="divfull" visible="true" runat="server">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="19%" class="frm-lft-clr123">
                                                                    From Date<span style="color:Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_date" runat="server" CssClass="input" Enabled="False" AutoPostBack="True"
                                                                        OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                                                                    <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_date"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="19%" class="frm-lft-clr123">
                                                                    To Date<span style="color:Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_ftime" runat="server" CssClass="input" Enabled="False" AutoPostBack="True"
                                                                        OnTextChanged="txt_ftime_TextChanged"></asp:TextBox>
                                                                    <asp:Image ID="imgf" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_ftime"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2" valign="top">
                                                                </td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td valign="middle" class="frm-lft-clr123">
                                                                    From-Time<span style="color:Red">*</span>
                                                                </td>
                                                                <td valign="top" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_time" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_time" Display="Dynamic"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />' ValidationGroup="v">
                                                                       </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td height="5" colspan="2" valign="top">
                                                                </td>
                                                            </tr>
                                                         <%--   <tr>
                                                                <td width="15%" valign="middle" class="frm-lft-clr123">
                                                                    To-Time<span style="color:Red">*</span>
                                                                </td>
                                                                <td width="85%" valign="top" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtouttime" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                                                    <asp:Image ID="imgouttime" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                                    <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtouttime" Display="Dynamic"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />' ValidationGroup="v">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div id="divhalf" visible="false" runat="server">
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td width="19%" class="frm-lft-clr123" style="height: 36px">
                                                                    Half Day Mode
                                                                </td>
                                                                <td class="frm-rght-clr123" style="height: 36px">
                                                                    <asp:RadioButton ID="opt_first" runat="server" Checked="True" GroupName="b" Text="First Half"
                                                                        OnCheckedChanged="opt_first_CheckedChanged" />
                                                                    <asp:RadioButton ID="opt_second" runat="server" GroupName="b" Text="Second Half"
                                                                        OnCheckedChanged="opt_second_CheckedChanged" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="19%" class="frm-lft-clr123">
                                                                    Select Date
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_select" runat="server" CssClass="input"></asp:TextBox>
                                                                    <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_select"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator>
                                                                    <ajax:CalendarExtender ID="Calendarextender3" runat="server" Format="dd-MMM-yyyy"
                                                                        PopupButtonID="img_select" TargetControlID="txt_select">
                                                                    </ajax:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Reason/Comment<span style="color: Red">*</span>
                                                </td>
                                               
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_reason" runat="server" MaxLength="100" TextMode="MultiLine" Width="240px"></asp:TextBox>
                                                     <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_reason"
                                                                        Display="Dynamic" ErrorMessage="Enter Reason For Apply OD" ToolTip="Enter Reason For Apply OD"
                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True">
                                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr runat="server" visible="false">
                                                <td width="19%" class="frm-lft-clr123">
                                                    Add Comment
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_comment" runat="server" MaxLength="100" TextMode="MultiLine" Width="240px"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="10">
                                        &nbsp;<ajax:CalendarExtender ID="CalendarExtender1" Format="dd-MMM-yyyy" runat="server"
                                            PopupButtonID="img" TargetControlID="txt_date">
                                        </ajax:CalendarExtender>
                                        <ajax:CalendarExtender ID="Calendarextender2" Format="dd-MMM-yyyy" runat="server"
                                            PopupButtonID="imgf" TargetControlID="txt_ftime">
                                        </ajax:CalendarExtender>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:Button ID="btn_sbmit" runat="server" CssClass="button" Text="Submit" OnClick="btn_sbmit_Click"
                                            ValidationGroup="v" />
                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
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
