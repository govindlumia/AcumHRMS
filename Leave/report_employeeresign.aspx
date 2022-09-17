<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report_employeeresign.aspx.cs" Inherits="leave_report_employeeresign" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Report Employee-wise</title>
    <style type="text/css" media="all">
    @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btn_search">
         <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div style="overflow-x:hidden; overflow-y:scroll; height:512px; width:968px;">
        <table width="98%" border="0" cellpadding="0" cellspacing="0">
        <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">Report Employee Who Resigned</td>
          </tr>
        </table></td>
      </tr>
      <tr>
      <td height="34"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
      <td width="26%" valign="middle" class="txt02">Search Employee</td>
      <td width="64%" valign="middle" align="right" class="txt-red"><span id="Span1" runat="server"></span></td>
      <td width="10%" valign="middle" align="right"><a href="admin/leaveadmin.aspx" class="txt-red" target="name123" >Back</a></td>
      </tr>
      </table>
      </td>
      </tr>
    </table>
    <table width="98%"  border="0" cellspacing="0" cellpadding="0">
    <tr>
<td valign="middle" class="frm-lft-clr123" width="17%">From Date<span style="color:red">*</span>
</td>
<td valign="top" class="frm-rght-clr123" width="19%">
    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="dd-MMM-yyyy"></cc1:CalendarExtender>
</td>
<td width="1%" valign="top">&nbsp;</td>
<td width="17%" valign="middle" class="frm-lft-clr123" >To Date<span style="color:red">*</span>
</td>
<td width="46%" valign="top" class="frm-rght-clr123" >
    <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
    <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate" Format="dd-MMM-yyyy"></cc1:CalendarExtender>
</td></tr>
         <tr>
       <td height="5" colspan="2"></td>
       <td height="5" colspan="2"></td>
       </tr>
      <tr>
        <td class="frm-lft-clr123" width="19%">Employee Name</td >
        <td class="frm-rght-clr123" width="30%"><asp:TextBox ID="txt_employee" MaxLength="20" runat="server" CssClass="input" Width="142px"></asp:TextBox></td>
        <td width="1%" rowspan="3">&nbsp;</td>
        <td class="frm-lft-clr123" width="18%">Designation</td>
        <td class="frm-rght-clr123" width="32%">
          <asp:DropDownList ID="dd_designation" runat="server" CssClass="select2" Width="142px">
          </asp:DropDownList></td>
        </tr>
        <tr>
       <td height="5" colspan="2"></td>
       <td height="5" colspan="2"></td>
       </tr>
        <tr>  
          <td class="frm-lft-clr123">Category</td>
          <td class="frm-rght-clr123">
             <asp:DropDownList ID="dd_branch" runat="server" CssClass="select2" Width="142px">
             </asp:DropDownList></td> 
            
            <td class="frm-lft-clr123" width="18%">Select Company</td>
        <td class="frm-rght-clr123" width="32%">
        <asp:DropDownList runat="server" ID="ddl_cmpny" CssClass="select2"></asp:DropDownList>
            </td>         
       
        </tr>
        <tr>
            <td class="frm-lft-clr123"></td>
            <td colspan="4" class="frm-rght-clr123">
            
              <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" ValidationGroup="c" OnClick="btn_search_Click" />
             &nbsp; &nbsp;&nbsp;&nbsp;
             <asp:Button ID="Button1" runat="server" CssClass="button2" OnClick="btnexport_Click" ValidationGroup="c" 
                      Text="Export To Excel" ToolTip="Export"  /></td>
        </tr>
   </table>
    
    <table width="98%" border="0" cellpadding="0" cellspacing="0">
    <tr>
    <td class="txt02" height="22">Employee Reporting Details</td>
    </tr>
    <tr>
            <td valign="top"> </td>
    </tr>
  <tr>
    <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
              <td class="head-2"  valign="top" >
                            
                  <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" 
                      CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  
                      EmptyDataText="No record found" AllowPaging="True" PageSize="80" 
                      OnPageIndexChanging="empgrid_PageIndexChanging" 
                      onselectedindexchanged="empgrid_SelectedIndexChanged">
                   <Columns>
                   
                   <asp:TemplateField HeaderText="Employee Code">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="14%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="Label1" runat="server" Text ='<%# Bind ("empcode") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                  
                  
                   <asp:TemplateField HeaderText="Employee Name">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="28%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("name") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                                  
                   <asp:TemplateField HeaderText="Designation">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="28%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("designationname") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Category">
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="15%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="Label1" runat="server" Text ='<%# Bind ("CategoryName") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                  <%-- <asp:TemplateField >
                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                   <ItemStyle Width="13%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                          <a class="link05" href="javascript:void(window.open('view_emp_approver.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>&name=<%#DataBinder.Eval(Container.DataItem, "name")%>','title','height=200,width=700,left=200,top=20',resizable='no'));">Approver List</a>
                    </ItemTemplate>
                   </asp:TemplateField>--%>
                   
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle Height="5px" />
                      <PagerStyle CssClass="frm-lft-clr123"/>
                  
                  </asp:GridView></td>
            </tr>
            <tr>
            <td height="7"></td>
            </tr>
            <tr>
            <td><%--<a href="admin/leaveadmin.aspx" class="txt-red" target="name123" >Back</a>--%></td>
            </tr>
            </table>
            </td>
            </tr>
            </table>
      
    </div>
    </form>
</body>
</html>
