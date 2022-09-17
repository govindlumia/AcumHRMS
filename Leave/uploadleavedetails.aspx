<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadleavedetails.aspx.cs"
    Inherits="leave_uploadleavedetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>KOD Intranet</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
    <script type="text/javascript" src="../../js/timepicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
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
                                            Upload Leave Master
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
                            <td valign="middle" class="frm-lft-clr123" style="width: 149px">
                                Upload Leave Data&nbsp;
                            </td>
                            <td valign="top" class="frm-rght-clr123" style="width: 471px">
                                &nbsp;<asp:FileUpload ID="fupload" runat="server" Width="390px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupload"
                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' SetFocusOnError="True"
                                    ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                <a href="../LeaveBalanceUpload.xlsx">Download Format</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" class="frm-lft-clr123" style="width: 149px">
                            </td>
                            <td valign="top" class="frm-rght-clr123" style="width: 471px">
                                &nbsp;
                                <asp:TextBox ID="txtcode" runat="server" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" style="height: 18px">
                                <asp:Button ID="btn_sbmit" runat="server" CssClass="button" Text="Submit" ValidationGroup="v"
                                    OnClick="btn_sbmit_Click" />
                                &nbsp;
                                <div runat="server" id="divMessage">
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
