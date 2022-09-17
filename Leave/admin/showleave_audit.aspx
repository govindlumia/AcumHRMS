<%@ Page Language="C#" AutoEventWireup="true" CodeFile="showleave_audit.aspx.cs" Inherits="leave_admin_showleave_audit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Leave Detail</title>
<script type="text/javascript" language="javascript" src="../js/popup.js"></script>
<style type="text/css" media="all">
@import "../css/blue1.css";
.disp { display:none;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager id="leaveapply" runat="server">
    </asp:ScriptManager>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td><table width="100%" border="0" cellspacing="0" cellpadding="0">

<tr>
  <td align="left" valign="top">
  
  <table width="100%" border="0" cellspacing="0" cellpadding="4">
    <tr>
      <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
        <td>
        <table>
        <tr>
<td valign="middle" class="frm-lft-clr123" width="17%">From Date</td>
<td valign="top" class="frm-rght-clr123" width="19%">
    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate"></cc1:CalendarExtender>
</td>
<td width="1%" valign="top">&nbsp;</td>
<td width="17%" valign="middle" class="frm-lft-clr123" >To Date</td>
<td width="46%" valign="top" class="frm-rght-clr123" >
    <asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox>
    <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate"></cc1:CalendarExtender>
</td></tr>
        <tr>
<td width="17%" valign="middle" class="frm-lft-clr123">Emp Code</td>
<td valign="top" class="frm-rght-clr123" colspan="4"><asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox> <a href="JavaScript:newPopup1('pickemployee.aspx');" class="link05">Pick Employee</a>&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_employee"
        ErrorMessage='<img src="../images/error1.gif" alt="Pick Employee" />' ValidationGroup="c"></asp:RequiredFieldValidator></td>

</tr>
<tr><td class="frm-lft-clr123"> 
    <asp:Button ID="Button1" runat="server" CssClass="button" Text="Search" OnClick="Button1_Click" ValidationGroup="c" /></td></tr>
        </table>
        </td>
        </tr>
        <tr>
          <td height="10"><span id="message" runat="server">&nbsp;</span></td>
        </tr>
        <tr>
          <td height="18" valign="top" class="txt02">&nbsp;Leave Detail</td>
        </tr>
        <tr>
          <td valign="top" class="head-2" >
          <asp:GridView ID="grid_leave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" Font-Names="Arial" Font-Size="11px"
                Width="100%"  EmptyDataText="No record found">
                <Columns>   
                <asp:TemplateField HeaderText="Empcode">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                        <ItemTemplate>
                      <asp:Label ID="l5" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                 
                    <asp:TemplateField HeaderText="Leave Type">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                      <asp:Label ID="l5" runat="server" Text='<%# Bind("leavetype") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                      
                    
                       <asp:TemplateField HeaderText="No of Days">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="10%" />
                        <ItemTemplate>
                        <asp:Label ID="l7" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    
                    <asp:TemplateField HeaderText="Comments">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="50%" />
                        <ItemTemplate>
                        <asp:Label ID="l7" runat="server" Text='<%# Bind("comments") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                                           
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
          </td>
        </tr>
        <tr>
          <td valign="top">&nbsp;</td>
        </tr>
      </table></td>
    </tr>
  </table></td>
</tr>
</table></td>
</tr>
</table>
    </form>
</body>
</html>
