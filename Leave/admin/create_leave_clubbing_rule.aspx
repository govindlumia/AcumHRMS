<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create_leave_clubbing_rule.aspx.cs" Inherits="Leave_admin_create_leave_clubbing_rule" Title="Leave Clubbing Rule" %>

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
                <div class="divajax" style="top:160px;">
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
            <td class="txt01">Leave Clubbing Rule </td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="7" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span></td>
      </tr>
      <tr>
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
            <td width="24%" class="frm-lft-clr123">Policy Name</td>
            <td width="76%" class="frm-rght-clr123">
                <asp:DropDownList ID="dd_policy" runat="server" CssClass="select1" OnDataBound="dd_policy_DataBound" DataSourceID="SqlDataSource2" DataTextField="policyname" DataValueField="policyid" AutoPostBack="True" Width="140px">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="dd_policy"
                    ErrorMessage='<img src="../images/error1.gif" alt="Select Policy" />' Operator="NotEqual"
                    ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    SelectCommand="SELECT [policyid], [policyname] FROM [tbl_leave_createleavepolicy]">
                </asp:SqlDataSource>
                &nbsp;
                </td>
            </tr> 
              
               <tr>
            <td height="5" colspan="2"></td>
          </tr>
          
          <tr>
            <td width="24%" class="frm-lft-clr123">Leave Name</td>
            <td width="76%" class="frm-rght-clr123">
                <asp:DropDownList ID="drp_leave" runat="server" CssClass="select1" DataSourceID="SqlDataSource1"
                    DataTextField="leavetype" DataValueField="leaveid" OnDataBound="drp_leave_DataBound" Width="120px">
                </asp:DropDownList><asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_leave"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                    ToolTip="Select Leave Name" ValueToCompare="0"></asp:CompareValidator></td>
            </tr>
          <tr>
            <td colspan="2" style="height: 9px"></td>
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
                  </asp:DropDownList><asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drp_aleave"
                      Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                      ToolTip="Select Leave Name" ValueToCompare="0" ValidationGroup="after"></asp:CompareValidator></td>
                  <td align="right" style="height: 20px">
                      &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="btm_add_Click"
                          Text="Add" ValidationGroup="after" />&nbsp;</td>
                </tr>
            </table></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top" height="4"></td>
      </tr>
      <tr>
        <td valign="top" class="head-2">
        <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="aleaveid" Font-Names="Arial" Font-Size="11px"
                OnRowDeleting="grid_aleave_RowDeleting"  Width="100%" EmptyDataText="No record found">
                <Columns>                   
                  <asp:TemplateField HeaderText="Leave Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("aleavename")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                   
                    <asp:TemplateField>
                        <HeaderStyle CssClass="frm-lft-clr123" />
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
            <asp:Button ID="btn_submit" runat="server" CssClass="button" OnClick="btn_submit_Click"
                Text="Submit" /> <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click"
                    Text="Reset" ValidationGroup="nothing" />&nbsp;
        </td>
      </tr>
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
    </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
            ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"
            SelectCommand="SELECT tbl_leave_createleave.leavetype, tbl_leave_createleave.leaveid, tbl_leave_createdefaultrule.leaveid AS Expr1, tbl_leave_createdefaultrule.policyid FROM tbl_leave_createdefaultrule INNER JOIN tbl_leave_createleave ON tbl_leave_createdefaultrule.leaveid = tbl_leave_createleave.leaveid WHERE (tbl_leave_createdefaultrule.policyid = @policyid)">
            <SelectParameters>
                <asp:ControlParameter ControlID="dd_policy" Name="policyid" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</form>
</body>
</html>


