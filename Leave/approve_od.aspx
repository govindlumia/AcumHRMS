<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approve_od.aspx.cs" Inherits="leave_approve_od" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%--<title>Acuminous Software Intranet</title>--%>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                                            <img src="images/employee-icon.jpg" width="16" height="16" />
                                        </td>
                                        <td class="txt01">
                                            Official Duty
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="txt02" height="20">
                                            &nbsp;Employee Information
                                        </td>
                                        <td valign="top" align="right" class="txt-red">
                                            <span id="message" runat="server"></span>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="19%" class="frm-lft-clr123">
                                        Employee Name
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="1%" rowspan="7">
                                        &nbsp;
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Employee Code
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
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
                                        <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_gender" Visible="false" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Designation
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_designation" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_branch" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_doj" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_emp_status" runat="server" Visible="false" Text="Label"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                        </tr>
                        <tr>
                            <td height="10" valign="top">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="20" valign="top" class="txt02">
                                &nbsp;View Official Duty
                            </td>
                        </tr>
                        <tr>
                            <td height="10" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">
                                            From Date&nbsp;
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_date" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">
                                            To Date
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_ftime" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            Working Days
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_whour" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            Reason
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_reason" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lbl_comment" runat="server" Text="lbl_comment"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            Add Comment
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txt_comment" runat="server" TextMode="MultiLine" Width="240px"></asp:TextBox>
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
                            <td valign="top" align="right">
                                <asp:Button ID="btn_approve" runat="server" CssClass="button" OnClick="btn_approve_Click"
                                    Text="Approve" />
                                <asp:Button ID="btn_back" runat="server" CssClass="button1" Text="Back to user" OnClick="btn_back_Click" />&nbsp;<asp:Button
                                    ID="btn_reject" runat="server" CssClass="button" OnClick="btn_cancel_Click" Text="Reject" />
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
