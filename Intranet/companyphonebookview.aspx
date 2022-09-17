<%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyphonebookview.aspx.cs"
    Inherits="companyphonebookviewview" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Acuminous Software</title>
    <style type="text/css" media="all">
@import "css/blue1.css";
@import "css/example.css";
</style>
    <link href="css/blue1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <asp:UpdatePanel id="updatepannel1" runat="server">
                    <contenttemplate>
<div>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">

<tr>
<td class="blue-brdr-1"><table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr>
<td class="txt01">Company Phone Book View</td>
<td class="txt-red" align="right"><span id="message" runat="server">&nbsp;</span></td>
</tr>
</table>
</td>
</tr>
<tr>
<td height="7"></td>
</tr>
<tr>
<td valign="top">



<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="middle" class="txt02 blue-brdr-1" height="23">&nbsp;Company Phone Book</td>
</tr>
 <tr>
 <td height="5" valign="top"></td>
 </tr>
 <tr>
 <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
  <td class="frm-lft-clr123" width="15%" >
      Emp Name/Code</td >
  <td class="frm-rght-clr123" width="15%" >
  <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="90px"></asp:TextBox>
  </td>
  <td class="frm-lft-clr123" width="15%" >Designation</td>
  <td class="frm-rght-clr123" width="15%" ><asp:DropDownList ID="dd_designation" runat="server"
     CssClass="select" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]">
            </asp:SqlDataSource></td>
   <td class="frm-lft-clr123" width="13%" >
       Department</td>
   <td class="frm-rght-clr123" width="15%" ><asp:DropDownList ID="dd_branch" runat="server" Width="145px" CssClass="select" DataSourceID="SqlDataSource2" DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name">
            </asp:SqlDataSource></td>
   <td class="frm-rght-clr123" width="12%" ><asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;</td>
   </tr>
</table></td>
 </tr>
 <tr>
 <td height="5" valign="top"></td>
 </tr>
 <tr>
 <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0" id="table1" onclick="return table1_onclick()">
            <tr>
              <td valign="middle" class="txt02" style="height: 24px">&nbsp;Contact List</td>
            </tr>
            <tr>
              <td class="head-2" valign="top" >          
               <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial"  CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  AllowPaging="true" PageSize="10" EmptyDataText="No such employee exists !" OnRowEditing="empgrid_RowEditing" OnRowDataBound="empgrid_RowDataBound" OnPageIndexChanging="empgrid_PageIndexChanging">
                   <Columns>
                   
                   <asp:TemplateField HeaderText="Employee Name">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="20%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                        
                   <asp:Label ID="l0" runat="server" Text ='<%# Bind ("name") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField> 
                    
                     <asp:TemplateField HeaderText="Department">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="15%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l2" runat="server" Text ='<%# Bind ("departmentname") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                      <asp:TemplateField HeaderText="Designation">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="15%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("designationname") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                     <asp:TemplateField HeaderText="Mobile">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="15%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l3" runat="server" Text ='<%# Bind ("mobileno") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                      
                   <asp:TemplateField HeaderText="Ext Number">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="15%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l4" runat="server" Text ='<%# Bind ("extnumber") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField> 
                   
                   <asp:TemplateField HeaderText="E-mail">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="15%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                    <asp:Label ID="l5" runat="server" Text ='<%# Bind ("email") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField> 


                  </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle Height="5px" /><PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                  </asp:GridView>
              </td>
            </tr>
        </table>
         <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" runat="server" SelectCommand="sp_company_phone_emp_detail" SelectCommandType="StoredProcedure">
                                <SelectParameters>
                                    <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                    <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                    <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                    <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                    <asp:Parameter Name="status" Type="String" />
                                </SelectParameters>
         </asp:SqlDataSource>
        </td>
      </tr>  
    </table></td>
  </tr>
  </table></td>
 </tr>
<tr>
</tr>
</table>
</td></tr></table></div>
</contenttemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
