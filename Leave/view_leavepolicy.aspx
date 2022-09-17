<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_leavepolicy.aspx.cs" Inherits="Leave_view_leavepolicy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>KOD Intranet</title>
    <style type="text/css" media="all">
@import "../css/blue1.css";
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
         
      <table width="718" border="0" cellpadding="0" cellspacing="0">
        
      <tr>
         <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">My Activities</td>
            </tr>
         </table></td>
      </tr>
      <tr>
        <td height="7" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="20" valign="top" class="txt02">&nbsp;View Leave Policy</td>
            </tr>           
            <tr>
              <td class="head-2">          
                  <asp:GridView ID="policygrid" runat="server" Font-Size="11px" Font-Names="Arial"  CellSpacing="0" CellPadding="4" DataKeyNames="policyid" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True" OnPageIndexChanging="policygrid_PageIndexChanging" PageSize="20" EmptyDataText="Sorry no record found">
                   <Columns>
                   <asp:TemplateField HeaderText="Policy Name">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"/> 
                   <ItemTemplate>                  
                         <asp:Label ID="l2" runat="server" Text ='<%# Bind ("policyname") %>'></asp:Label>                  
                   </ItemTemplate>
                   </asp:TemplateField>
                  
                   <asp:TemplateField HeaderText="Policy File">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"/>                                                  
                   <ItemTemplate>
                        <a href="../upload/policydockit/<%#DataBinder.Eval(Container.DataItem,"policy_file_name")%>" target="_blank" class="link05">View File</a>
                   </ItemTemplate>
                   </asp:TemplateField>                  
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle />             
                  </asp:GridView>              
              </td>
            </tr>
        </table></td>
      </tr>     
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
