<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createdefaultrule.aspx.cs"
    Inherits="Leave_admin_createdefaultrule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Admin</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="javascript" type="text/javascript">

    </script>
    <script src="../../js/popup.js" language="javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
   
    <table width="718" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                &nbsp;
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
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top" class="blue-brdr-1">
                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="3%">
                                                                <img src="../images/employee-icon.jpg" width="16" height="16" />
                                                            </td>
                                                            <td class="txt01">
                                                                Create Leave Rule
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="7" valign="top" align="right" class="txt-red">
                                                    <span id="message" runat="server"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="32%" class="frm-lft-clr123">
                                                                Select Policy
                                                            </td>
                                                            <td width="68%" class="frm-rght-clr123">
                                                                <asp:DropDownList ID="dd_policy" runat="server" CssClass="select2" DataSourceID="SqlDataSource2"
                                                                    DataTextField="policyname" DataValueField="policyid" OnDataBound="dd_policy_DataBound">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_policy"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                                                                    ValidationGroup="v" ValueToCompare="0"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [policyid], [policyname] FROM [tbl_leave_createleavepolicy]">
                                                                </asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="28%" class="frm-lft-clr123">
                                                                Leave Name
                                                            </td>
                                                            <td width="72%" class="frm-rght-clr123">
                                                                <asp:DropDownList ID="ddleave" runat="server" CssClass="select2" DataSourceID="SqlDataSource1"
                                                                    DataTextField="leavetype" DataValueField="leaveid" OnDataBound="ddleave_DataBound">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddleave"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                                                                    ValidationGroup="v" ValueToCompare="100"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                    ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>" SelectCommand="SELECT [leaveid], [leavetype] FROM [tbl_leave_createleave]where leaveid!=0 and status!=0">
                                                                    <DeleteParameters>
                                                                        <asp:Parameter Name="leaveid" Type="Int32" />
                                                                    </DeleteParameters>
                                                                    <UpdateParameters>
                                                                        <asp:Parameter Name="leavetype" Type="String" />
                                                                        <asp:Parameter Name="leaveid" Type="Int32" />
                                                                    </UpdateParameters>
                                                                    <InsertParameters>
                                                                        <asp:Parameter Name="leavetype" Type="String" />
                                                                    </InsertParameters>
                                                                </asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" height="10">
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
                                                            <td width="32%" class="frm-lft-clr123">
                                                                Days before leave to be apply
                                                            </td>
                                                            <td width="20%" class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_days_before_leave" runat="server"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0</asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_days_before_leave"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_days_before_leave"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
                                                            </td>
                                                            <td style="width: 1%">
                                                                &nbsp;
                                                            </td>
                                                            <td width="24%" class="frm-lft-clr123">
                                                                Entitled days per year
                                                            </td>
                                                            <td width="27%" class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_entitled" runat="server"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0</asp:TextBox>
                                                                <%-- <asp:RadioButton ID="radio_entitled_created" runat="server" Checked="true" GroupName="z"
                                                                            Text="Created" />"
                                                                        <asp:RadioButton ID="radio_entitled_computed" OnCheckedChanged="radio_entitled_computed_CheckedChanged"
                                                                            Checked="false" AutoPostBack="true" runat="server" GroupName="z" Text="Computed" />
                                                                --%>
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
                                                                            <td width="32%" class="frm-lft-clr123">
                                                                                Number of days
                                                                            </td>
                                                                            <td width="20%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txtNo_of_days" runat="server"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0</asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNo_of_days"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txtNo_of_days"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
                                                                            </td>
                                                                            <td style="width: 1%">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="24%" class="frm-lft-clr123">
                                                                                Balance
                                                                            </td>
                                                                            <td width="27%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_balance" runat="server"   onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0.0</asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_balance"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txt_balance"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Value between 0 and 1000" />'
                                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Double"></asp:RangeValidator>
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
                                                                <asp:TextBox ID="txt_minimum" runat="server"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0</asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_minimum"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_minimum"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
                                                            </td>
                                                            <td style="width: 10px">
                                                                &nbsp;
                                                            </td>
                                                            <td class="frm-lft-clr123">
                                                                Maximum number of days
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_maximum" runat="server"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0</asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_maximum"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_maximum"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Integer Value between 0 and 1000" />'
                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
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
                                                                <asp:RadioButton ID="opt_halfdays_yes" runat="server" Checked="True" GroupName="z"
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
                                                                <asp:RadioButton ID="RadioButton6" runat="server" Text="No" GroupName="b" />
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
                                                                    OnCheckedChanged="RadioButton4_CheckedChanged" />
                                                            </td>
                                                            <td style="width: 10px">
                                                                &nbsp;
                                                            </td>
                                                            <td class="frm-lft-clr123">
                                                                With in how many days
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_how_many" runat="server"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" CssClass="input" Width="60px">0</asp:TextBox>
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
                                                                Exclude Holiday
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:RadioButton ID="opt_holidays_yes" runat="server" Text="Yes" GroupName="d" Checked="True" />
                                                                <asp:RadioButton ID="RadioButton2" runat="server" Text="No" GroupName="d" />
                                                            </td>
                                                            <td style="width: 10px">
                                                                &nbsp;
                                                            </td>
                                                            <td class="frm-lft-clr123">
                                                                Exclude Weekly off
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
                                                <td valign="top" height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" class="txt02" height="20">
                                                    &nbsp;Accumulation / Carry Forward
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
                                                            <td colspan="5" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="32%">
                                                                Carry forward days
                                                            </td>
                                                            <td class="frm-rght-clr123" width="20%">
                                                                <asp:RadioButton ID="opt_carry_all" runat="server" AutoPostBack="True" Checked="True"
                                                                    GroupName="ac" OnCheckedChanged="opt_carry_all_CheckedChanged" Text="All" />
                                                                <asp:RadioButton ID="opt_carry_days" runat="server" AutoPostBack="True" GroupName="ac"
                                                                    OnCheckedChanged="opt_carry_days_CheckedChanged" Text="Days" />&nbsp;
                                                                <asp:TextBox ID="txt_carry_maximumdays"  onkeyup="checkNumericValueForCntrl(this)" MaxLength="3" runat="server" CssClass="input" Width="25px">0</asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_carry_maximumdays"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_carry_maximumdays"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Numeric Value between 0 and 1000" />'
                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Integer"></asp:RangeValidator>
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
                                                                <asp:TextBox ID="txt_accumulation" runat="server"  onkeyup="checkNumericValueForCntrl(this)"  MaxLength="3" CssClass="input" Width="25px">0</asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_accumulation"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_accumulation"
                                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter Numeric Value between 0 and 1000" />'
                                                                    MaximumValue="365" MinimumValue="0" ValidationGroup="v" Type="Double"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" height="10">
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
                                                            <td class="frm-lft-clr123" width="32%">
                                                                Leave extension/shorten
                                                            </td>
                                                            <td width="68%" class="frm-rght-clr123">
                                                                <asp:RadioButton ID="opt_modification_yes" runat="server" Text="Yes" Checked="True"
                                                                    GroupName="g" />
                                                                <asp:RadioButton ID="opt_modification_no" runat="server" Text="No" GroupName="g"
                                                                    CausesValidation="True" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 8px">
                                                                <asp:HiddenField ID="hidden_empcode" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="bottom" height="25">
                                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td>
                                                                <a href="leaveadmin.aspx" class="txt-red" target="name123">Back</a>
                                                            </td>
                                                            <td align="right">
                                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                                    ValidationGroup="v" />
                                                                <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="button" OnClick="btnreset_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                &nbsp;
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <!--................................END MID SECTION........................-->
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
