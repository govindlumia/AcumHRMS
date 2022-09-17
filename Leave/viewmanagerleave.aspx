<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewmanagerleave.aspx.cs" Inherits="leave_viewmanagerleave" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Acuminous Software Intranet</title>

<style type="text/css" media="all">

@import "../css/blue1.css";
</style>
</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--<asp:ScriptManager ID="bank" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>

<table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" height="463px" style="width: 719px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%" style="height: 16px"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01" style="height: 16px">
                  Employee Attendance Export</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" class="txt-red" valign="top"><span id="message" runat="server"></span>
            &nbsp;</td>
      </tr>
         <tr>
        <td valign="top" style="height: 5px">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" >
                            
                            <tr>
                                    <td class="frm-lft-clr123" width="14%" >
                                        From Date</td>
                                    <td class="frm-rght-clr123" width="15%" >
                                         <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
        ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate"></cc1:CalendarExtender></td>
                            
                                    <td class="frm-lft-clr123" width="14%%" >
                                        To Date</td>
                                    <td class="frm-rght-clr123" colspan="3" width="20%" >
                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox>
    <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_edate"
        ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
        ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
    <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate"></cc1:CalendarExtender></td>
                                    
                                    
                            </tr>

                   </table>
        </td>
      </tr>
        <tr>
            <td align="right" valign="top" style="height: 5px">
            </td>
        </tr>
      
      
        <tr>
            <td align="right" valign="top" style="height: 5px">
                &nbsp;<asp:Button ID="btnexport" runat="server"
                        CssClass="button" OnClick="btnexport_Click" Text="Export" ValidationGroup="v" />&nbsp;
                </td>
        </tr>
        <tr>
            <td height="5" valign="top">
            </td>
        </tr>
      <tr>
        <td valign="top"></td>
      </tr>
    </table></td>
  </tr>
</table>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</form>
</body>
</html>
