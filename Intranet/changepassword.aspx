<%@ Page Title="Change Password" Language="C#" 

    AutoEventWireup="true" CodeFile="changepassword.aspx.cs" Inherits="changepassword" %>
<%--<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Intranet/employeemaster.master"--%>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="cplhld1" runat="Server">--%>
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
<form runat="server">
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
                                        <td width="3%" class="txt01">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" alt="" />
                                        </td>
                                        <td width="51%" class="txt01">
                                            Reset Password
                                        </td>
                                        <td width="46%" align="right" class="txt-red">
                                            <span id="message" runat="server"></span>
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
                                        <td width="19%" class="frm-lft-clr123">
                                            Employee Name
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_name" runat="server" Text="">&nbsp;</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">
                                            Employee Code
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lblcode" runat="server" Text="">&nbsp;</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">
                                            Old Password
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txt_oldpswd" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage='<img src="images/error1.gif" alt="Enter new password" />'
                                                ValidationGroup="v" ControlToValidate="txt_oldpswd" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txt_newpassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='<img src="images/error1.gif" alt="Enter new password" />'
                                                ValidationGroup="v" ControlToValidate="txt_newpassword" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox ID="txt_confrmpassword" runat="server" CssClass="input" TextMode="Password"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="Password does not match" />'
                                                ControlToCompare="txt_newpassword" ControlToValidate="txt_confrmpassword" ValidationGroup="v"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_confrmpassword"
                                                Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="Password does not match" />'
                                                ValidationGroup="v"></asp:RequiredFieldValidator>
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
                                            <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                                Text="Submit" ValidationGroup="v" />
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
<%--</asp:Content>--%>
