<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DelegateApproval.aspx.cs"
    Inherits="Leave_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Delagate Rights</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <%--<script type="text/javascript">
         document.write('<style type="text/css">.tabber{display:none;}<\/style>');
         function updateValue1(amount) {
             var textBox = document.getElementById('<%=txt_employee1.ClientID %>');
             textBox.value = amount;
         }    
    </script>--%>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
     <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="images/loading.gif" alt="" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01" height="23">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="images/employee-icon.jpg" width="16" height="16" alt="" />
                                                </td>
                                                <td class="txt01">
                                                    Delegate Employee's Job
                                                </td>
                                                <td align="right">
                                                    <%--<a href="leave-user.aspx" target="" class="txt-red">Back</a>--%> <span id="message" runat="server">
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="27%" class="frm-lft-clr123">
                                                    Delegated Employee Code (<img src="images/error1.gif" alt="" />)
                                                </td>
                                                <td width="73%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input2" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_employee"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />'><img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <a href="JavaScript:newPopup1('../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');" class="link05">Pick Manager</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div id="divfull" visible="true" runat="server">
                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td width="27%" class="frm-lft-clr123">
                                                                    From Date (<img src="images/error1.gif" alt="" />)
                                                                </td>
                                                                <td width="73%" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_sdate" runat="server" CssClass="input2" Enabled="false"></asp:TextBox>&nbsp;
                                                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                                                        ErrorMessage="Enter From Date" Display="Dynamic">
                                                                    </asp:RequiredFieldValidator>&nbsp;
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_f"
                                                                        TargetControlID="txt_sdate" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="27%">
                                                                    To Date (<img src="images/error1.gif" alt="" />)
                                                                </td>
                                                                <td class="frm-rght-clr123" width="73%">
                                                                    <asp:TextBox ID="txt_edate" runat="server" CssClass="input2" Enabled="false"></asp:TextBox>&nbsp;
                                                                    <asp:Image ID="img_t" runat="server" ImageUrl="images/clndr.gif" />&nbsp;
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                                        ErrorMessage='<img src="images/error1.gif" alt="" />' Display="Dynamic">
                                                                        <img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="img_t"
                                                                        TargetControlID="txt_edate" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10" colspan="2">
                                                                </td>
                                                                <tr>
                                                                    <td valign="middle" class="frm-lft-clr123">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td height="35" valign="bottom" class="frm-rght-clr123" align="right">
                                                                        <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click" />
                                                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click"
                                                                            ValidationGroup="a" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10" colspan="2">
                                                                    </td>
                                                                    <tr>
                                                                        <td colspan="2" height="10">
                                                                        </td>
                                                                        <tr>
                                                                            <td height="25" colspan="2" class="txt1" style="width: 729px" valign="middle">
                                                                                &nbsp;Mandatory Fields (<img src="images/error1.gif" alt="" />)
                                                                            </td>
                                                        </table>
                                                    </div>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
