<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_leave_adjustment_rule.aspx.cs" Inherits="Leave_admin_create_leave_adjustment_rule" Title="Leave Adjustment Rule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
</head>
<body>
    <form id="form1" runat="server">

<table width="480" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" class="blue-brdr-1"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="5%" style="height: 16px"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
            <td width="95%" class="txt01" style="height: 16px">
                View Leave Adjustment Rule</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="7" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
      </tr>
      <tr>
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
           <tr>
            <td width="24%" class="frm-lft-clr123">Policy Name</td>
            <td width="76%" class="frm-rght-clr123">
                <asp:Label ID="lbl_policy" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            </tr>
          <tr>
            <td height="10" colspan="2"></td>
          </tr>
          <tr>
            <td width="24%" class="frm-lft-clr123">Leave Name</td>
            <td width="76%" class="frm-rght-clr123">
                <asp:Label ID="lbl_leave" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            </tr>
          <tr>
            <td height="10" colspan="2"></td>
          </tr>
          <tr>
            <td height="20" valign="top" class="txt02" colspan="2">&nbsp;Adjust Leave</td>
            </tr>
        </table></td>
      </tr>
   
      <tr>
        <td height="2" valign="top"></td>
      </tr>
      <tr>
        <td height="10" valign="top" >
        
        <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                CellPadding="4" CellSpacing="0" DataKeyNames="aleaveid" Font-Names="Arial" Font-Size="11px"
                Width="100%" EmptyDataText="No adjustment of leave is specified">
                <Columns>                   
                  <asp:TemplateField HeaderText="Leave Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("aleavename")%>' ></asp:Label>
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
        <td valign="top" style="height: 14px"></td>
      </tr>
      
      <tr>
        <td align="right" valign="top" style="height: 18px">
            <asp:HiddenField ID="HiddenField1" runat="server" />
            &nbsp;&nbsp;
          
          </td>
      </tr>
      <tr>
        <td valign="top">
            &nbsp;
        </td>
      </tr>
    </table></td>
  </tr>
</table>
</form>
</body>
</html>

