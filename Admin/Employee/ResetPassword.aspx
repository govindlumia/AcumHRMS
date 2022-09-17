<%@ Page Title="Employee Master" Language="C#" MasterPageFile="~/Admin/Employee/EmployeeMaster.master"
    AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style type="text/Css" media="all">
@import "../../Css/blue1.css";
@import "../../Css/example.css";
</style>

    <script type="text/javascript" src="../../js/tabber.js"></script>

    <script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
     <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
     <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>

    
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tbody>
                    <tr>
                        <td valign="top" class="blue-brdr-1" colspan="2">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%" style="height: 16px">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                    <td class="txt01" style="height: 16px">
                                        Reset Password</td>
                                    <td align="right" style="height: 16px">
                                        <span id="message" runat="server" class="txt-red" enableviewstate="false">&nbsp;</span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="frm-lft-clr123" valign="top">
                                            Employee Code</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lblcode" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" valign="top">
                                            Employee Name</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="25%" style="height: 29px">
                                            New Password</td>
                                        <td class="frm-rght-clr123" width="75%" style="height: 29px">
                                            <asp:TextBox ID="txt_password" CssClass="input" size="52" runat="server" TextMode="Password"
                                                Width="186px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_password"
                                                ToolTip="Must enter some password"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" valign="top">
                                            Confirm Password</td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txt_cpassword" runat="server" CssClass="input" size="52" TextMode="Password"
                                                Width="186px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_cpassword"
                                                Display="Dynamic" ToolTip="Enter the same password as above"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txt_password"
                                                ControlToValidate="txt_cpassword" ToolTip="Password did not match" ErrorMessage="Password did not match"
                                                Display="Dynamic">Password did not match</asp:CompareValidator></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            &nbsp;</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Reset" CssClass="button">
                                            </asp:Button></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="20" valign="bottom">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
      </asp:UpdatePanel>
      </asp:Content>
  
