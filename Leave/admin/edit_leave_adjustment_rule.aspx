<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_leave_adjustment_rule.aspx.cs" Inherits="Leave_admin_create_leave_adjustment_rule" Title="Leave Adjustment Rule" %>

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
<asp:ScriptManager ID="leave" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>

<table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">Edit Leave Adjustment Rule</td>
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
                <asp:Label ID="lbl_policy" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            </tr>
            <tr>
            <td height="5" colspan="2"></td>
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
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="24%" class="frm-lft-clr123">Adjustment Leave</td>
            <td width="76%" class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td style="height: 20px;"><asp:DropDownList ID="drp_aleave" runat="server" CssClass="select1" OnDataBound="drp_aleave_DataBound" DataSourceID="SqlDataSource1" DataTextField="leavetype" DataValueField="leaveid">
                </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drp_aleave"
                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                        ToolTip="Select Leave Name" ValueToCompare="100" ValidationGroup="add"></asp:CompareValidator></td>
                <td align="right" style="height: 20px">
                    <asp:Button ID="btm_add" runat="server" Text="Add" CssClass="button" OnClick="btm_add_Click" ValidationGroup="add" />
                    
                  &nbsp;</td>
              </tr>
            </table></td>
          </tr>

        </table></td>
      </tr>
      <tr>
        <td height="4" valign="top"></td>
      </tr>
      <tr>
        <td height="10" valign="top" class="head-2">
        
        <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="aleaveid" Font-Names="Arial" Font-Size="11px"
                OnRowDeleting="grid_aleave_RowDeleting"  Width="100%" EmptyDataText="No leave adjustment rule is defined">
                <Columns>                   
                  <asp:TemplateField HeaderText="Leave Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
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
        <td align="right" valign="top" style="height: 18px">
            <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click" Tooltip="Click here to submit the updated rule"/>
            <asp:Button ID="btnrst" runat="server" CssClass="button" OnClick="btnrst_Click" Text="Cancel" Tooltip="Click here to cancel the updation"/>          
          </td>
      </tr>
      <tr>
        <td valign="top">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>" SelectCommand="select leaveid,leavetype from tbl_leave_createleave where status=1 "></asp:SqlDataSource>
            <asp:HiddenField ID="hiddenvalue" runat="server" />
            <asp:HiddenField ID="hidden_policy" runat="server" />
        </td>
      </tr>
    </table></td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>    
</form>
</body>
</html>

