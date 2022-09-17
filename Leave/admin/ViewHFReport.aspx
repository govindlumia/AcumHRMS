<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewHFReport.aspx.cs" Inherits="leave_admin_ViewHFReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<%--<title>Acuminous Software Intranet</title>--%>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="leave" runat="server">
</asp:ScriptManager>

<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        
<table width="718" border="0" cellspacing="0" cellpadding="0">

  <tr>
    <td valign="top" height="463px" colspan="5"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
              <td class="txt01">
                  Half Day Report</td>
                  
            </tr>
        </table></td>
      </tr>

      <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="frm-lft-clr123" width="20%" >
                From Date</td>
            <td class="frm-rght-clr123" width="30%">
               <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
               <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
                    ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                    ValidationGroup="c" ValueToCompare="MM/dd/yyyy" Display="Dynamic"></asp:CompareValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
            </td>
                 <td class="frm-lft-clr123" width="20%">
                     &nbsp;To Date</td>
              <td class="frm-rght-clr123" width="30%">
                  &nbsp;<asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox><asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" /><asp:RequiredFieldValidator
                          ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_edate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                          ValidationGroup="c"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                              runat="server" ControlToValidate="txt_edate" Display="Dynamic" ErrorMessage="Check date format(MM/dd/yyyy)"
                              Operator="DataTypeCheck" Type="Date" ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator><cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate" Format="MM/dd/yyyy">
                              </cc1:CalendarExtender>
                  &nbsp;&nbsp;
                </td>

            </tr>
             <tr><td height="5px"></td></tr>
        <tr>
            <td class="frm-lft-clr123" >
                  Branch</td>
            <td class="frm-rght-clr123" >
                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="select" DataSourceID="SqlDataSource21"
                      DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound" Width="140px" AutoPostBack="False">
                  </asp:DropDownList>
                  <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                      ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                  </asp:SqlDataSource>
            </td>
            <td class="frm-lft-clr123" >
                Department</td>
            <td class="frm-rght-clr123" >
                <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2111"
                      DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound" Width="140px">
                  </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2111" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid],department_name FROM [tbl_internate_departmentdetails] order by department_name">
        
    </asp:SqlDataSource>
            </td>

        </tr>
        <tr><td height="5px"></td></tr>
        <tr>
            <td class="frm-lft-clr123">
                Employee Name</td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="119px"></asp:TextBox></td>
            <td class="frm-rght-clr123" colspan="2">
            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" ValidationGroup="c" />
            </td>
            
        </tr>
       </table></td>
    </tr>
      
  
       
    
    
    
      <tr>
        <td height="7"></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
              <td valign="bottom" class="txt02"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr>
                       <td width="27%" class="txt02" style="height: 13px">View Half Day</td>
                       <td width="73%" align="right" class="txt-red" style="height: 13px"><span id="message" runat="server"></span>&nbsp;</td>
                     </tr>
                    
              </table></td> 
            </tr> 
            <tr>
              <td>
                  <asp:Button ID="btnexport" runat="server" CssClass="button" OnClick="btnexport_Click"
                      Text="Export" ToolTip="Export" /></td>              
            </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top" class="head-2">
                      
    <asp:GridView ID="GridView1" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"  Width="100%" 
    AllowPaging="True"  BorderWidth="1px"  OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" GridLines="Both">
        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
        <FooterStyle CssClass="frm-lft-clr123" />
        <RowStyle Height="5px" CssClass="frm-rght-clr1234" />
        <PagerStyle CssClass="frm-lft-clr123"/>
    </asp:GridView>
        </td>
      </tr>
      <tr>
        <td align="right" valign="top"></td>
      </tr>
      <tr>
        <td valign="top"></td>
      </tr>
    </table></td>
  </tr>
</table>
<%--</ContentTemplate>
</asp:UpdatePanel>  --%>
</form>
</body>
</html>
