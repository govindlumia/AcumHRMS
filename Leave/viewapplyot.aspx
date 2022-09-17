<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewapplyot.aspx.cs" Inherits="leave_viewapplyot" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply Leave</title>
    <style type="text/css">
            @import "css/ykk.css";@import "css/blue1.css";
            .pop2 {
                       position:absolute; background-color: #fff; z-index:1002; overflow: auto; padding:0px; left:135px; top:48%;width:500px;
                  }
      </style>
      <style type="text/css" media="all">
        @import "css/blue1.css";
      </style>
        <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager id="leaveapply" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">
                View Good Work Reward</td>
            </tr>
        </table></td>
      </tr>
 
       <tr>
        <td align="right" valign="top" style="height: 18px">
            
        </td>
      </tr>
      <tr>
        <td height="20" valign="top" class="txt02">
            Good Work Reward</td>
      </tr>
      <tr>
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            
 <tr>
            <td colspan="2"></td>
            </tr>
            <tr>
            <td colspan="2" style="height: 5px"></td>
          </tr>
          <tr>
          <td valign="top" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
              <td class="head-2" valign="top">
              <asp:GridView ID="applyotgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No Good Work Reward apply"
                  DataKeyNames="id" OnPageIndexChanging="applyotgrid_PageIndexChanging" OnRowCommand="applyotgrid_RowCommand" OnRowDeleting="applyotgrid_RowDeleting">
                   <Columns>               
                   <asp:TemplateField HeaderText="Date">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="40%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("date") %>'></asp:Label>
                  </ItemTemplate>                   
                   </asp:TemplateField>
                 
                                  
                   <asp:TemplateField HeaderText="Total Hours">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="40%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("total_hours") %>'></asp:Label>                  
                  </ItemTemplate>  
                                
                   </asp:TemplateField>        
                                      
                    <asp:TemplateField >
                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/> 
                <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                <ItemTemplate>
                 <asp:LinkButton id="lnk_view" class="link05" runat="server" OnClientClick="document.getElementById('light').style.display='block';" CommandName="View" CommandArgument='<%# Container.DataItemIndex %>'>View</asp:LinkButton>|
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
        </table></td>
      </tr>
    </table>
    </div>
    <div id="divot" runat="server" visible="false" class="pop2" style="height:350px" align="center">
<table width="490" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="pop-brdr"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="95%" valign="top" class="pop-tp-clr" align="left">
    Employee Details</td>
<td width="5%" align="right" valign="top" class="pop-tp-clr">
    <asp:ImageButton ID="img_close" runat="server" ImageUrl="images/btn-close.gif" OnClick="img_close_Click" /></td>
</tr>
<tr>
<td colspan="2" align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top">
<table width="100%" border="1" cellspacing="0" cellpadding="3" bordercolor="#93b5c8" style="border-collapse:collapse;">
<tr>
<td  valign="top" colspan="3">
<asp:GridView
 id="applyotviewgrid"
   runat="server"
    DataKeyNames="id"
     EmptyDataText="No Apply Good Work Reward"
      BorderWidth="0px"
       AutoGenerateColumns="False"
        Width="100%"
         CellPadding="4"
          Font-Names="Arial"
           Font-Size="11px" OnPageIndexChanging="applyotviewgrid_PageIndexChanging" OnRowCancelingEdit="applyotviewgrid_RowCancelingEdit" OnRowDeleting="applyotviewgrid_RowDeleting" OnRowEditing="applyotviewgrid_RowEditing" OnRowUpdating="applyotviewgrid_RowUpdating">
                   <Columns>   
                                                  
                   <asp:TemplateField HeaderText="Date">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />                  
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234" /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("date") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField> 
                   
                   <asp:TemplateField HeaderText="Empcode">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />                  
                   <ItemStyle Width="40%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234" /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l4" runat="server" Text ='<%# Bind ("empcode") %>'></asp:Label> - 
                  <asp:Label ID="Label111" runat="server" Text ='<%# Bind ("name") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                                 
                   <asp:TemplateField HeaderText="Total Hours">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />                  
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"   /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("noofhour") %>'></asp:Label>                  
                  </ItemTemplate>
                  <EditItemTemplate>
                    <asp:TextBox ID="txtnoofhoursg" runat="server" Text='<%# Bind ("noofhour") %>' Width="72px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnoofhoursg"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="grid" SetFocusOnError="True" ToolTip="Enter No of hours" Display="Dynamic"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                             <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtnoofhoursg" ValidationGroup="grid" 
                                 ErrorMessage='<img src="../images/error1.gif" alt="" />' MaximumValue="24" MinimumValue="1" Display="Dynamic" ToolTip="No of hours between 1 and 24 hours" Type="Double">No of hours between 1 and 24 hours</asp:RangeValidator>  
                  </EditItemTemplate> 
                   </asp:TemplateField>

                      <asp:TemplateField>
                      <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />   
                    <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                <ItemTemplate>               
                <asp:LinkButton ID="lnk_edit" CssClass="link05" CommandName="Edit" runat="server" ValidationGroup="noone">Edit </asp:LinkButton>|
                 <asp:LinkButton ID="lnk_delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');" CommandName="Delete" runat="server" ValidationGroup="noone">Delete</asp:LinkButton>
                </ItemTemplate>
                 <EditItemTemplate>
                    <asp:LinkButton ID="Button3" runat="Server" CommandName="Update" ValidationGroup="grid"  Text="Update"
                         CssClass="link05" /> | 
                    <asp:LinkButton ID="Button4" runat="Server" CommandName="Cancel"  Text="Cancel"
                         CssClass="link05" />
                </EditItemTemplate>
            </asp:TemplateField>
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123"  />
                      <FooterStyle CssClass="frm-lft-clr123"  />
                      <RowStyle Height="5px"  />
                  </asp:GridView>
</td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
</div>
    </form>
</body>
</html>
