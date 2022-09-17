<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleaverule.aspx.cs" Inherits="Leave_admin_editleaverule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script type="text/javascript" language="javascript">
        function close() {
            window.close();
            return false;
        }
    </script>
</head>
<body>
    <div >
        <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax" style="left: 380px;">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">
                                        Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="8">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top">
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top" class="blue-brdr-1">
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="txt01">
                                                                    Edit Leave Rule
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
         TargetControlID="txt_enforcement">
     </cc1:CalendarExtender>--%>
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
                                                                <td class="frm-lft-clr123">
                                                                    Policy Name
                                                                </td>
                                                                <td width="72%" class="frm-rght-clr123">
                                                                    <asp:Label ID="lbl_policy_name" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Leave Type
                                                                </td>
                                                                <td width="72%" class="frm-rght-clr123">
                                                                    <asp:Label ID="lbl_leave" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20" valign="top" class="txt02">
                                                        &nbsp;General Leave Rule
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="28%" class="frm-lft-clr123">
                                                                    Days before leave to be apply
                                                                </td>
                                                                <td width="23%" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_days_before_leave" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" runat="server" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_days_before_leave"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_days_before_leave"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                        MaximumValue="1000" MinimumValue="0" Type="Integer" ValidationGroup="v"></asp:RangeValidator>
                                                                </td>
                                                                <td width="1%">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="25%" class="frm-lft-clr123">
                                                                    Entitled days per year
                                                                </td>
                                                                <td width="23%" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_entitled" runat="server" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RadioButtonList runat="server" ID="rbtn" RepeatDirection="Horizontal" AutoPostBack="true"
                                                                        OnSelectedIndexChanged="rbtn_onSelectedIndexChanges">
                                                                        <asp:ListItem Value="0">Credited</asp:ListItem>
                                                                        <asp:ListItem Value="1">Computed</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_entitled"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_entitled"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                        MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <div id="dvCompute" runat="server" visible="false">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="28%" class="frm-lft-clr123">
                                                                                    Number of days
                                                                                </td>
                                                                                <td width="23%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txtNo_of_days" onkeyup="checkNumericValueForCntrl(this)"  MaxLength="2" runat="server" CssClass="input" Width="60px">0</asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNo_of_days"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtNo_of_days"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                                        MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
                                                                                </td>
                                                                                <td style="width: 1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="25%" class="frm-lft-clr123">
                                                                                    Balance
                                                                                </td>
                                                                                <td width="23%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_balance" runat="server" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" CssClass="input" Width="60px">0</asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_balance"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txt_balance"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter  Value between 0 and 1000" />'
                                                                                        MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Double" ></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Minimum number of days
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_minimum" runat="server" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_minimum"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_minimum"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                        MaximumValue="1000" MinimumValue="0" Type="Integer" ValidationGroup="v"></asp:RangeValidator>
                                                                </td>
                                                                <td style="width: 10px">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Maximum number of days
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_maximum" runat="server" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_maximum"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_maximum"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                        MaximumValue="1000" MinimumValue="0" Type="Integer" ValidationGroup="v"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Half day leave applicable
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:RadioButton ID="opt_halfday_leave" runat="server" Checked="True" GroupName="z"
                                                                        Text="Yes" />
                                                                    <asp:RadioButton ID="opt_halfday_no" runat="server" GroupName="z" Text="No" />
                                                                </td>
                                                                <td style="width: 10px">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Document required
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:RadioButton ID="opt_document_yes" runat="server" Text="Yes" GroupName="b" Checked="True" />
                                                                    <asp:RadioButton ID="opt_document_no" runat="server" Text="No" GroupName="b" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Back date leave applying
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:RadioButton ID="opt_backdate_yes" runat="server" Text="Yes" GroupName="c" Checked="True"
                                                                        AutoPostBack="True" OnCheckedChanged="opt_backdate_yes_CheckedChanged" />
                                                                    <asp:RadioButton ID="opt_backdate_no" runat="server" Text="No" GroupName="c" AutoPostBack="True"
                                                                        OnCheckedChanged="opt_backdate_no_CheckedChanged" />
                                                                </td>
                                                                <td style="width: 10px">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    With in how many days
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_how_many" runat="server" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_how_many"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_how_many"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                        MaximumValue="1000" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Exclude Holidays
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:RadioButton ID="opt_holidays_yes" runat="server" Text="Yes" GroupName="d" Checked="True"
                                                                        OnCheckedChanged="opt_holidays_yes_CheckedChanged" />
                                                                    <asp:RadioButton ID="opt_holidays_no" runat="server" Text="No" GroupName="d" OnCheckedChanged="opt_holidays_no_CheckedChanged" />
                                                                </td>
                                                                <td style="width: 10px">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    &nbsp;Exclude Weekly off
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:RadioButton ID="opt_weekly_yes" runat="server" Checked="True" GroupName="1"
                                                                        Text="Yes" />
                                                                    <asp:RadioButton ID="opt_weekly_no" runat="server" GroupName="1" Text="No" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            <td colspan="5" height="5">
                                                            </td>
                                                        </tr>
                                                          <tr>
                                                            <td class="frm-lft-clr123">
                                                                Short day leave applicable
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:RadioButton ID="opt_short_yes" runat="server" Checked="True" GroupName="y"
                                                                    Text="Yes" />
                                                                <asp:RadioButton ID="opt_short_no" runat="server" GroupName="y" Text="No" />
                                                            </td>
                                                            <td style="width: 10px">
                                                                &nbsp;
                                                            </td>
                                                            </tr>  
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20" valign="top" class="txt02">
                                                        &nbsp;Accumulation / Carry Forward Rule
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Carry forward for next year
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="4">
                                                                    <asp:RadioButton ID="opt_carryforward_yes" runat="server" Text="Yes" GroupName="e"
                                                                        Checked="True" AutoPostBack="True" OnCheckedChanged="opt_carryforward_yes_CheckedChanged" />
                                                                    <asp:RadioButton ID="opt_carryforward_no" runat="server" Text="No" GroupName="e"
                                                                        AutoPostBack="True" OnCheckedChanged="opt_carryforward_no_CheckedChanged" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="8">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="28%">
                                                                    Carry forward days
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 23%">
                                                                    <asp:RadioButton ID="opt_carry_all" runat="server" AutoPostBack="True" Checked="True"
                                                                        GroupName="ac" OnCheckedChanged="opt_carry_all_CheckedChanged" Text="All" />
                                                                    <asp:RadioButton ID="opt_carry_days" runat="server" AutoPostBack="True" GroupName="ac"
                                                                        OnCheckedChanged="opt_carry_days_CheckedChanged" Text="Days" />&nbsp;
                                                                    <asp:TextBox ID="txt_carry_maximumdays" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" runat="server" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_carry_maximumdays"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_carry_maximumdays"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Numeric Value between 0 and 1000" />'
                                                                        MaximumValue="1000" MinimumValue="0" ValidationGroup="v" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                                <td style="width: 1%">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123" width="24%">
                                                                    Accumulation days
                                                                </td>
                                                                <td class="frm-rght-clr123" width="27%">
                                                                    <asp:RadioButton ID="opt_accumulation_all" runat="server" AutoPostBack="True" Checked="True"
                                                                        GroupName="ab" Text="All" OnCheckedChanged="opt_accumulation_all_CheckedChanged" />
                                                                    <asp:RadioButton ID="opt_accumulation_days" runat="server" AutoPostBack="True" GroupName="ab"
                                                                        Text="Days" OnCheckedChanged="opt_accumulation_days_CheckedChanged" />&nbsp;
                                                                    <asp:TextBox ID="txt_accumulation" runat="server" onkeyup="checkNumericValueForCntrl(this)" MaxLength="2" CssClass="input" Width="60px">0</asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_accumulation"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_accumulation"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Numeric Value between 0 and 1000" />'
                                                                        MaximumValue="1000" MinimumValue="0" ValidationGroup="v" Type="Double"></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20" valign="top" class="txt02">
                                                        &nbsp;Leave Extension / Shortened Rule
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 9%">
                                                                    Leave extension/shorten
                                                                </td>
                                                                <td width="23%" class="frm-rght-clr123">
                                                                    <asp:RadioButton ID="opt_extension_yes" runat="server" Text="Yes" Checked="True"
                                                                        GroupName="g" AutoPostBack="True" CausesValidation="True" />
                                                                    <asp:RadioButton ID="opt_extension_no" runat="server" Text="No" GroupName="g" AutoPostBack="True" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="8">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td align="left">
                                                                    <a href="leaveadmin.aspx" class="txt-red" target="name123">Back</a>
                                                                </td>
                                                                <td align="right">
                                                                    <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="button" ValidationGroup="v"
                                                                        OnClick="btnsbmit_Click" />
                                                                    <%--<input id="Button1" class="button" onclick="javascript:window.close();" type="button" value="Cancel" />--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="hidden_leaveid" runat="server" />
                                            <asp:HiddenField ID="hidden_entitled" runat="server" />
                                            <asp:HiddenField ID="hidden_policyid" runat="server" />
                                        </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                </td> </tr> </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        </form>
    </div>
</body>
</html>
