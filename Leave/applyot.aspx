<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyot.aspx.cs" Inherits="leave_applyot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Apply Leave</title>
<style type="text/css" media="all">
@import "css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager id="leaveapply" runat="server">
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
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">
                Create Good Work Reward for Employee</td>
            </tr>
        </table></td>
      </tr>
      <tr>   
    <td height="5" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
  </tr>
      <tr>
        <td height="20" valign="top" class="txt02">Create Good Work Reward</td>
      </tr>
      <tr>
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          
          <tr>
            <td colspan="2">
            <div id="divfull" visible="true" runat="server" >
                  <table width="100%" cellpadding="0" cellspacing="0" border="0">
                     <tr>
                         <td width="19%" class="frm-lft-clr123">
                             &nbsp;Date </td>
                         <td class="frm-rght-clr123">
                             <asp:TextBox ID="txtdate" runat="server" Width="139px" ToolTip="Date"></asp:TextBox>
                  <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                        (mm/dd/yyyy)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                 ControlToValidate="txtdate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                 SetFocusOnError="True" ToolTip="Enter Date" ValidationGroup="v" Display="Dynamic"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
                             <cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txtdate" PopupButtonID="img"></cc1:calendarextender> </td>
                     </tr>
                     <tr>
                        <td height="5" colspan="2"></td>
                    </tr>
                    <tr>
            <td width="19%" class="frm-lft-clr123" style="height: 27px">
                             Select Employee&nbsp;</td>
            <td class="frm-rght-clr123" style="height: 27px">
                &nbsp;<asp:DropDownList ID="ddlempcode" runat="server" CssClass="select" Width="142px">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlempcode"
                    ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                    ValidationGroup="v" ValueToCompare="---Select Employee---" Display="Dynamic" ToolTip="Select Employee"><img src="../images/error1.gif" alt="" /></asp:CompareValidator></td>
            </tr>
          <tr>
            <td height="5" colspan="2"></td>
            </tr>
                    <tr>
                        <td width="19%" class="frm-lft-clr123">
                            No of Hours</td>
                         <td class="frm-rght-clr123">
                             <asp:TextBox ID="txtnoofhour" runat="server" CssClass="input2" size="40" ToolTip="No of Hours" Width="144px"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnoofhour"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v" SetFocusOnError="True" ToolTip="Enter No of hours" Display="Dynamic"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                             <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtnoofhour" ValidationGroup="v" 
                                 ErrorMessage='No of hours between 1 and 24 hours' MaximumValue="24" MinimumValue="1" Display="Dynamic" ToolTip="No of hours between 1 and 24 hours" Type="Double">No of hours between 1 and 24 hours</asp:RangeValidator></td>
                  </tr>
              </table>
         </div>
         </td>
            </tr>
            <tr><td>&nbsp;</td></tr>
          <tr>
            <td height="22" colspan="2" valign="top" class="txt02">
                <asp:Button ID="btnadd" runat="server" CssClass="button" OnClick="btnadd_Click" Text="Add" ValidationGroup="v" /></td>
          </tr>
 <tr>
            <td colspan="2">
                &nbsp;</td>
            </tr>
            <tr>
            <td colspan="2" style="height: 5px"></td>
          </tr>
          <tr>
          <td valign="top" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
              <td class="head-2" valign="top"  >
              <asp:GridView ID="otgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No Good Work to apply" OnPageIndexChanging="otgrid_PageIndexChanging" OnRowDeleting="otgrid_RowDeleting" OnRowEditing="otgrid_RowEditing" OnRowUpdating="otgrid_RowUpdating"
               DataKeyNames="oddate,empcode" OnRowCancelingEdit="otgrid_RowCancelingEdit"  >
                   <Columns>               
                   <asp:TemplateField HeaderText="Date">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("oddate") %>'></asp:Label>
                  </ItemTemplate>                    
                   </asp:TemplateField>                   
                                  
                   <asp:TemplateField HeaderText="Emp Code">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l3" runat="server" Visible="false" Text ='<%# Bind ("empcode") %>'></asp:Label>
                  <asp:Label ID="Label1" runat="server" Text ='<%# Bind ("empname") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="No of Hours">  
                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                      
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  <asp:Label ID="l4" runat="server" Text ='<%# Bind ("noofhours") %>'></asp:Label>
                  </ItemTemplate>
                   <EditItemTemplate>
                   <asp:TextBox ID="txtnoofhoursg" runat="Server" Text='<%# Eval("noofhours") %>' CssClass="input"></asp:TextBox> 
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnoofhoursg"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="grid" SetFocusOnError="True" ToolTip="Enter No of hours" Display="Dynamic"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                             <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtnoofhoursg" ValidationGroup="grid" 
                                 ErrorMessage='<img src="../images/error1.gif" alt="" />' MaximumValue="24" MinimumValue="1" Display="Dynamic" ToolTip="No of hours between 1 and 24 hours" Type="Double">No of hours between 1 and 24 hours</asp:RangeValidator>                     
                  </EditItemTemplate>
                   </asp:TemplateField>                   
                    <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/> 
                <EditItemTemplate>
                        <asp:LinkButton ID="lnk_update" CssClass="link05" CommandName="Update" runat="server" ValidationGroup="grid">Update</asp:LinkButton>|
                        <asp:LinkButton ID="lnk_cancel" CssClass="link05" CommandName="Cancel" runat="server" ValidationGroup="noone">Cancel</asp:LinkButton>
                </EditItemTemplate>
              
                <ItemStyle Width="24%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                <ItemTemplate>
                <asp:LinkButton ID="lnk_edit" CssClass="link05" CommandName="Edit" runat="server" ValidationGroup="noone">Edit </asp:LinkButton>|
                 <asp:LinkButton ID="lnk_delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');" CommandName="Delete" runat="server" ValidationGroup="noone">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
                   
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle Height="5px" />
                  </asp:GridView></td>
            </tr>
        </table></td>
          </tr>
         <tr>
            <td height="7" colspan="2"></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top" style="height: 10px">
            &nbsp;
        </td>
      </tr>
      <tr>
        <td align="right" valign="top" style="height: 18px">
            &nbsp; &nbsp;<asp:Button ID="btn_approve" runat="server" CssClass="button"
                Text="Send" OnClick="btn_approve_Click" />&nbsp;
            
        </td>
      </tr>
      <tr>
        <td valign="top">&nbsp;&nbsp;
        </td>
      </tr>
    </table>
    </div>
    </ContentTemplate> 
</asp:UpdatePanel>
    </form>
</body>
</html>
