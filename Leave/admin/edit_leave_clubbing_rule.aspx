<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_leave_clubbing_rule.aspx.cs" Inherits="Leave_admin_create_leave_clubbing_rule" Title="Leave Clubbing Rule" %>

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
    <table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%" style="height: 16px"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01" style="height: 16px">
                Edit Leave Clubbing Rule</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="7" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span></td>
      </tr>    
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
         <tr>
            <td width="24%" class="frm-lft-clr123">Policy Name</td>
            <td width="76%" class="frm-rght-clr123">
                &nbsp;<asp:Label ID="lbl_policy" runat="server"></asp:Label></td>
            </tr>
         <tr>
            <td height="5" colspan="2"></td>
          </tr>
          <tr>
            <td width="24%" class="frm-lft-clr123">Leave Name</td>
            <td width="76%" class="frm-rght-clr123">
                &nbsp;<asp:Label ID="lbl_leave" runat="server"></asp:Label></td>
            </tr>
          <tr>
            <td height="10" colspan="2"></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="20" valign="top" class="txt02">&nbsp;After (not applicable)</td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="24%" class="frm-lft-clr123">Leave</td>
            <td width="76%" class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td style="height: 20px"><asp:DropDownList ID="drp_aleave" runat="server" CssClass="select1" DataSourceID="SqlDataSource1"
                        DataTextField="leavetype" DataValueField="leaveid" OnDataBound="drp_aleave_DataBound" Width="120px">
                  </asp:DropDownList>
                      <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drp_aleave"
                      Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Select leave name" />' Operator="NotEqual"
                      ToolTip="Select Leave Name" ValueToCompare="100" ValidationGroup="v"></asp:CompareValidator></td>
                  <td align="right" style="height: 20px">
                      &nbsp;
                      <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="btm_add_Click"
                          Text="Add" ValidationGroup="v" />&nbsp;</td>
                </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top" height="5"></td>
      </tr>
      <tr>
        <td valign="top" class="head-2">
        <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="aleaveid" Font-Names="Arial" Font-Size="11px"
                OnRowDeleting="grid_aleave_RowDeleting"  Width="100%" EmptyDataText="No clubbing rule defined.">
                <Columns>                   
                  <asp:TemplateField HeaderText="Leave Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("aleavename")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                   
                    <asp:TemplateField>
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="5%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete" CssClass="link05"
                                OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
        <td valign="middle" height="25">&nbsp;Mandatory Fields (<img alt="" src="../images/error1.gif" />)</td>
      </tr>
      
      <tr>
        <td align="right" valign="top">
            <asp:Button ID="btn_submit" runat="server" CssClass="button" OnClick="btn_submit_Click" Text="Submit" Tooltip="Click here to submit the updated rule"/>
            <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click" Text="Cancel" ValidationGroup="nothing" Tooltip="Click here to cancel the updation"/>
        </td>
      </tr>       
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
    </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"
            SelectCommand="select leaveid,leavetype from tbl_leave_createleave where status=1 AND leaveid!=0">
        </asp:SqlDataSource>
        <asp:HiddenField ID="hiddenvalue" runat="server" />
        <asp:HiddenField ID="hidden_policy" runat="server" />
    </td>
  </tr>
</table>
</form>
</body>
</html>


