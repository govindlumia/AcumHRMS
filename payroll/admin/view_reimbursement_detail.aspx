<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_reimbursement_detail.aspx.cs"
    Inherits="payroll_admin_view_reimbursement_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
.pop2 {
  position:absolute; background-color: #fff; z-index:1002; overflow: auto; padding:0px; left:135px; top:48%;width:500px;
}
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
--%>
        <%--<ContentTemplate>--%>
        <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
       <div class="divajax"><table width="100%">
        <tr>
        <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
        </tr>
        <tr>
        <td valign="bottom" align="center" class="txt01">Please Wait...</td>
        </tr>
        </table></div>
    </ProgressTemplate>
    </asp:UpdateProgress>--%>
        <div id="divapply">
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                            <td class="txt01">
                                                View &nbsp;Reimbursement</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="29%" class="txt02">
                                                Reimbursement Details</td>
                                            <td width="71%" align="right" class="txt-red">
                                                <span id="message" runat="server"></span>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 123px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Employee Code</td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_empname" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 5px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Reimbursement</td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_reimbursement" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Reimbursement Ref. No.</td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_refno" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Reimbursement Amount</td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_amount" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Sanction Date</td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_sanct" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Reimburse On</td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_month" runat="server"></asp:Label>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Attachment (If any)</td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_path" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
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
        <%--
</ContentTemplate>
<Triggers>
     <asp:PostBackTrigger ControlID="btnsubmit" />     
       
    </Triggers>

<<%--/asp:UpdatePanel>--%>
    </form>
</body>
</html>
