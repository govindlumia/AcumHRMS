<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewemployeeprofile.aspx.cs" Inherits="Leave_admin_pickapprover" Title="Leave Approver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Untitled Document</title>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>

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
                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                    </tr>
                    </table>
                    </div>
            </ProgressTemplate>
            </asp:UpdateProgress>
    <div>
    <table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="middle" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%" ><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">
                Employee Profile</td>
          </tr>
        </table>
    </td>
  </tr>
  <tr>
    <td height="15" valign="top" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
  </tr>
  <tr>
    <td height="5" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr >
        <td class="frm-lft-clr123" width="12%">Name</td >
        <td class="frm-rght-clr123" width="17%">
        <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="95px"></asp:TextBox>
        </td>
       <td class="frm-lft-clr123" width="14%"> Designation</td>
       <td class="frm-rght-clr123" width="16%"><asp:DropDownList ID="dd_designation" runat="server"
                CssClass="select" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound" Width="104px">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]">
            </asp:SqlDataSource></td>
          <td class="frm-lft-clr123" width="11%">
              Category&nbsp;</td>
          <td class="frm-rght-clr123" width="16%">
              &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                  DataTextField="CategoryName" DataValueField="ID" OnDataBound="dd_branch_DataBound" Width="106px">
              </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                  ProviderName="System.Data.SqlClient" SelectCommand="select distinct [ID],CategoryName From [tbl_category_master] order by CategoryName">
              </asp:SqlDataSource>
            </td>
            <td class="frm-lft-clr123" width="14%">
            
            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="Button1_Click1" />
       </td>
        </tr>
        <tr>
        <td style="width: 78px"></td>
        </tr>
    </table></td>
  </tr>
  <tr>
  <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td valign="middle" class="txt02" style="height: 28px">&nbsp;Employee List</td>
            </tr>
            <tr>
              <td class="head-2" valign="top" >          
               <asp:GridView ID="empgird" runat="server" Font-Size="11px" Font-Names="Arial"  CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  AllowPaging="True" PageSize="80" EmptyDataText="Sorry no record found" OnRowEditing="empgird_RowEditing" OnRowDataBound="empgird_RowDataBound" OnPageIndexChanging="empgird_PageIndexChanging">
                   <Columns>
                   <asp:TemplateField HeaderText="Employee Code">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="16%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l1" runat="server" Text ='<%# Bind ("empcode") %>'></asp:Label>
                     
                  </ItemTemplate>
                   </asp:TemplateField>  
                     <asp:TemplateField HeaderText="Employee Name">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="25%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l2" runat="server" Text ='<%# Bind ("name") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                      <asp:TemplateField HeaderText="Designation">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="22%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("designationname") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                     <asp:TemplateField HeaderText="Category">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l3" runat="server" Text ='<%# Bind ("CategoryName") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>   
                   
                     <asp:TemplateField>
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                        <ItemTemplate>
                        <a href="javascript:void(window.open('view_employee_leave_profile.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>','title','height=550,width=778,left=100,top=30'));" class="link05">View </a> |
                        <a href="edit_employee_leave_profile.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>" class="link05">Edit </a> 
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
    </table></td>
  </tr>
</table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
