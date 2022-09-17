<%@ Page Language="C#" MasterPageFile="general.master" AutoEventWireup="true" CodeFile="Feedbackentry.aspx.cs"
    Inherits="Feedbackentry" Title="Feedback Entry Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="generalmaster" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="blue-brdr-1">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="3%">
                            <img src="images/employee-icon.jpg" width="16" height="16" /></td>
                        <td class="txt01">
                            Feedback Form</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5" valign="top">
                <span id="message" runat="server" class="txt02" enableviewstate="false"></span>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="25%" class="frm-lft-clr123">
                            Subject</td>
                        <td width="75%" class="frm-rght-clr123">
                            &nbsp;<asp:TextBox ID="txtsubject" runat="server" CssClass="blue1" Width="235px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubject" ErrorMessage="Subject"
                                ValidationGroup="v"><img src="images\error1.gif" alt="*" /></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td height="5" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td width="25%" class="frm-lft-clr123" valign="top">
                            Description</td>
                        <td width="75%" class="frm-rght-clr123">
                            &nbsp;<asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Width="238px"
                                Height="59px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdescription"
                                ErrorMessage="Description" ValidationGroup="v"><img src="images\error1.gif" alt="*" /></asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" height="10">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                    HeaderText="Enter a value for following fields" Height="1px" ShowMessageBox="True"
                    ShowSummary="False" ValidationGroup="v" Width="280px" />
                <span style="color: #ff0033">All fields are manadatory&nbsp;</span></td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click"
                    ValidationGroup="v" />&nbsp;
                <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
