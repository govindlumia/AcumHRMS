<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approvalcasualhours.aspx.cs" Inherits="leave_admin_approvalcasualhours" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Casual Hours Approval</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
</head>
<body>
   <form id="form1" runat="server">
<asp:ScriptManager ID="leave" runat="server">
</asp:ScriptManager>

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>

<table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top" style="height: 463px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">
                  Approval Casual Hours</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td class="txt02" style="width: 29%; height: 13px">
                           Accept/Reject Approval Hours</td>
                       <td width="73%" align="right" class="txt-red" style="height: 13px"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>           
            
            <tr>
              <td class="head-2">
              <asp:GridView ID="casualhrgird" runat="server" DataKeyNames="id" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="Sorry no casual hours found for Approval"   AllowPaging="True" PageSize="30" OnPageIndexChanging="casualhrgird_PageIndexChanging" OnRowDeleting="casualhrgird_RowDeleting" OnRowEditing="casualhrgird_RowEditing" OnRowUpdating="casualhrgird_RowUpdating" OnRowCancelingEdit="casualhrgird_RowCancelingEdit">
                   <Columns>
                   
               <asp:TemplateField HeaderText="Select">   
               <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />            
                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="10%" />
                <ItemTemplate>
                    <asp:CheckBox ID="checkg" runat="Server" Checked="false"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>    
                   
               <asp:TemplateField HeaderText="Department Name">
               <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="txtdeptg" runat="Server" Text='<%# Eval("deptname") %>' CssClass="input"></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                <ItemTemplate>
                    <asp:Label ID="lbldeptg" runat="Server" Text='<%# Eval("deptname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Date">
            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <%--<EditItemTemplate>
                    <asp:TextBox ID="txtcasualdateg" runat="Server" Text='<%# Eval("casualdate") %>' CssClass="input"></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                <ItemTemplate>
                    <asp:Label ID="lblcasualdateg" runat="Server" Text='<%# Eval("casualdate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="No of Persons">
                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# String.Format("{0:#,##,##,##0}", DataBinder.Eval(Container.DataItem,"casualno"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtnoofpersonsg" runat="server" Text='<%# String.Format("{0:#,##,##,##0}", DataBinder.Eval(Container.DataItem,"casualno"))%>' Width="123px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnoofpersonsg"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="grid" SetFocusOnError="True" ToolTip="Enter number of Persons"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </asp:TemplateField>   
            
            <asp:TemplateField HeaderText="No of hours">
            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <EditItemTemplate>
                    <asp:TextBox ID="txtnoofhrsg" runat="Server" Text='<%# String.Format("{0:#,##,##,##0.0}", DataBinder.Eval(Container.DataItem,"noofhours"))%>' CssClass="input"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnoofhrsg"
                      ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="grid" SetFocusOnError="True" ToolTip="Enter number of hours"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                <ItemTemplate>
                    <asp:Label ID="lblnoofhrsg" runat="Server" Text='<%# String.Format("{0:#,##,##,##0.0}", DataBinder.Eval(Container.DataItem,"noofhours"))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                       
            <asp:TemplateField HeaderText="">
            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <EditItemTemplate>
                    <asp:LinkButton ID="Button3" runat="Server" CommandName="Update"  Text="Update"
                         CssClass="link05"  ValidationGroup="grid" /> | 
                    <asp:LinkButton ID="Button4" runat="Server" CommandName="Cancel"  Text="Cancel"
                         CssClass="link05" />
                </EditItemTemplate>
              
                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top" Width="35%" />
                <ItemTemplate>
                    <asp:LinkButton ID="Button1" runat="Server" CommandName="Edit"  Text="Edit" CssClass="link05" /> | 
                    <asp:LinkButton ID="Button2" runat="Server" CommandName="Delete"  Text="Delete" CssClass="link05"  OnClientClick="return confirm(' Do you want to Delete this record?');" />
                </ItemTemplate>
            </asp:TemplateField>        
                </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                        <FooterStyle CssClass="frm-lft-clr123" />
                        <RowStyle Height="5px" />
                      
                  </asp:GridView>             &nbsp;&nbsp;
                </td>
            </tr>
            
        </table></td>
      </tr>
      <tr>
            <td align="center">
            &nbsp;<asp:Button ID="btnapprove" runat="server" CssClass="button" Text="Approve" OnClick="btnapprove_Click" />&nbsp;
                <asp:Button ID="btnrejection" runat="server" CssClass="button" Text="Reject" OnClick="btnrejection_Click" /></td>
            </tr>
    </table></td>
  </tr>
</table>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</form>
</body>
</html>
