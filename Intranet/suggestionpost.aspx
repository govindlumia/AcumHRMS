<%@ Page Language="C#" AutoEventWireup="true" CodeFile="suggestionpost.aspx.cs" Inherits="suggestionpost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css" media="all">
        @import "css/blue.css";
        @import "css/home.css";
        </style>

    <script type="text/javascript">
        function WatermarkFocus(txtElem, strWatermark) 
        {
            if (txtElem.value == strWatermark) 
                txtElem.value = '';
        }
        function WatermarkBlur(txtElem, strWatermark) 
        {
            if (txtElem.value == '') 
                txtElem.value = strWatermark;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" style="height: 28px">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="22" valign="top" class="dot-line">
                        Suggestions</td>
                </tr>
                <tr>
                    <td height="26" valign="middle">
                        &nbsp;&nbsp;<span class="txt01">Suggestion Post </span>&nbsp;l&nbsp; <a href="suggestionview.aspx?view=2"
                            class="link-red1">Suggestion View</a></td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="5" valign="top" align="right">
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
                                <td width="20%">
                                    Mandatory Fields (<img src="images/error1.gif" alt="" />)</td>
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
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
