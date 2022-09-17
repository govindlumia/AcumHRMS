<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <!--................................MID SECTION........................-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2%" class="txt01">
                                            <img src="images/header-icon.png" width="16" height="16" alt="" />
                                        </td>
                                        <td class="txt01">
                                            Reset Password
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
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">
                                            Employee Code
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txtEmpCode" runat="server" CssClass="input" readonly="true" MaxLength="8"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter new password"
                                                ValidationGroup="v" ControlToValidate="txtEmpCode" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">
                                            New Password
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txt_newpassword" runat="server" CssClass="input" MaxLength="15"
                                                TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter new password"
                                                ValidationGroup="v" ControlToValidate="txt_newpassword" Display="None"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            Confirm Password
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txt_confrmpassword" runat="server" CssClass="input" MaxLength="15"
                                                TextMode="Password"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="None" ErrorMessage="Password does not match"
                                                ControlToCompare="txt_newpassword" ControlToValidate="txt_confrmpassword" ValidationGroup="v">
                                            </asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_confrmpassword"
                                                Display="None" ErrorMessage="Please enter confirm password" ValidationGroup="v"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            &nbsp;
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="button" OnClick="btnSubmit_Click"
                                                Text="Submit" ValidationGroup="v" />
                                        </td>
                                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                                            ValidationGroup="v" runat="server" />
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
                            <td valign="top">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <!--................................END MID SECTION........................-->
        </td>
    </div>
    </form>
</body>
</html>
