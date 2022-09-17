<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approvalgoodworkreward1.aspx.cs" Inherits="leave_admin_approvalgoodworkreward1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Approval for Good Work Reward</title>
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
                  Approval Work Reward</td>
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
                       <td class="txt02" style="width: 35%; height: 13px">
                           Accept/Reject Approval Work Reward</td>
                       <td width="73%" align="right" class="txt-red" style="height: 13px"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
              </table></td>
            </tr>           
            
            <tr>
              <td class="head-2">
              <asp:GridView ID="goodworkgird" runat="server" DataKeyNames="id" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="Sorry no record found"   AllowPaging="True" PageSize="30" OnPageIndexChanging="goodworkgird_PageIndexChanging" OnRowDeleting="goodworkgird_RowDeleting" OnRowEditing="goodworkgird_RowEditing" OnRowUpdating="goodworkgird_RowUpdating" OnRowCancelingEdit="goodworkgird_RowCancelingEdit">
                   <Columns>
                   
               <asp:TemplateField HeaderText="Select">               
                <ItemStyle Width="10%" />
                <ItemTemplate>
                    <asp:CheckBox ID="checkg" runat="Server" Checked="false"></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>    
                   
               <asp:TemplateField HeaderText="Department Name">
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="txtdeptg" runat="Server" Text='<%# Eval("deptname") %>' CssClass="input"></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemStyle Width="25%" />
                <ItemTemplate>
                    <asp:Label ID="lbldeptg" runat="Server" Text='<%# Eval("deptname") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Employee Code">
               <%-- <EditItemTemplate>
                    <asp:TextBox ID="txtdeptg" runat="Server" Text='<%# Eval("deptname") %>' CssClass="input"></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemStyle Width="25%" />
                <ItemTemplate>
                    <asp:Label ID="lblempcodeg" runat="Server" Text='<%# Eval("empcode") %>'></asp:Label>
                    
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Date">
                <%--<EditItemTemplate>
                    <asp:TextBox ID="txtcasualdateg" runat="Server" Text='<%# Eval("casualdate") %>' CssClass="input"></asp:TextBox>
                </EditItemTemplate>--%>
                <ItemStyle Width="15%" />
                <ItemTemplate>
                    <asp:Label ID="lblcasualdateg" runat="Server" Text='<%# Eval("oddate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="No of hours">
                <EditItemTemplate>
                    <asp:TextBox ID="txtnoofhrsg" runat="Server" Text='<%# String.Format("{0:#,##,##,##0.0}", DataBinder.Eval(Container.DataItem,"noofhours"))%>' CssClass="input"></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle Width="15%" />
                <ItemTemplate>
                    <asp:Label ID="lblnoofhrsg" runat="Server" Text='<%# String.Format("{0:#,##,##,##0.0}", DataBinder.Eval(Container.DataItem,"noofhours"))%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                       
            <asp:TemplateField HeaderText="">
                <EditItemTemplate>
                    <asp:LinkButton ID="Button3" runat="Server" CommandName="Update"  Text="Update"
                         CssClass="link05"  OnClientClick="return confirm(' Do you want to Update this record?');" /> | 
                    <asp:LinkButton ID="Button4" runat="Server" CommandName="Cancel"  Text="Cancel"
                         CssClass="link05" />
                </EditItemTemplate>
              
                <ItemStyle Width="35%" />
                <ItemTemplate>
                    <asp:LinkButton ID="Button1" runat="Server" CommandName="Edit"  Text="Edit" CssClass="link05" /> | 
                    <asp:LinkButton ID="Button2" runat="Server" CommandName="Delete"  Text="Delete" CssClass="link05"  OnClientClick="return confirm(' Do you want to Delete this record?');" />
                </ItemTemplate>
            </asp:TemplateField>        
                </Columns> 
                      <HeaderStyle HorizontalAlign="left" CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                       <AlternatingRowStyle CssClass="frm-rght-clr12345" />                     
                      <RowStyle Height="5px" />
                      
                  </asp:GridView>             &nbsp;&nbsp;
                </td>
            </tr>
            
        </table></td>
      </tr>
      <tr>
            <td align="center">
            &nbsp;<asp:Button ID="btnapprove" runat="server" CssClass="button" Text="Approve" OnClick="btnapprove_Click" />
                &nbsp; &nbsp;
                <asp:Button ID="btnrejection" runat="server" CssClass="button" Text="Rejection" OnClick="btnrejection_Click" /></td>
            </tr>
    </table></td>
  </tr>
</table>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</form>
</body>
</html>
