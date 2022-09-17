<%@ Page Language="C#" AutoEventWireup="true" CodeFile="check_leavepolicy.aspx.cs" Inherits="leave_admin_check_leavepolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Acuminous Software Leave Policy</title>

<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/timepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02">View Policy</td>
                       <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>
            <tr>
              <td class="head-2" style="height: 292" valign="top" >
              
                  <asp:GridView ID="policygrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="id" Font-Names="Arial" Font-Size="11px"
                Width="100%" AllowPaging="True" PageSize="30"  EmptyDataText="Sorry no record found" >
                <Columns>
                          <asp:TemplateField HeaderText="Leave Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%#Bind("leavetype")%>' > </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Entitled Days">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="entitled" runat="server" Text='<%#Bind("Entitled_days")%>' > </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                                     
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
                  
                </td>
            </tr>
        </table></td>
      </tr>
    </div>
    </form>
</body>
</html>
