<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave_not_approved.aspx.cs" Inherits="leave_admin_leave_not_approved" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Details</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <%--
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                          <div class="divajax" style="left: 250px; top: 150px">
                    <table width="100%">
                    <tr>
                    <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                    </tr>
                    <tr>
                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                    </tr>
                    </table>
                    </div>
            </ProgressTemplate>
            </asp:UpdateProgress>--%>
       
    <div>
    <table width="718px" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="middle" class="txt02 blue-brdr-1">&nbsp;Search Employee</td>
  </tr>
  <tr>
    <td height="5" valign="top"></td>
  </tr>
  <tr>
    <td height="5" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="frm-lft-clr123" width="15%">Employee Name</td >
        <td class="frm-rght-clr123" width="15%">
                <asp:TextBox ID="txt_employee" runat="server"  CssClass="input" Width="124px"></asp:TextBox>
        </td>
       <td class="frm-lft-clr123" width="15%">Designation</td>
       <td class="frm-rght-clr123" width="15%">
            <asp:DropDownList ID="dd_designation" runat="server"
                CssClass="select" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound" Width="158px">
            </asp:DropDownList>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]">
            </asp:SqlDataSource></td>
            
          <td class="frm-lft-clr123" style="width: 11%">
              Department</td>
          
          <td colspan="2" class="frm-rght-clr123" width="15%">
              &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                  DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound" Width="145px">
              </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                  ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], department_name FROM [tbl_internate_departmentdetails] order by department_name">
              </asp:SqlDataSource>
          </td>
          
          
        </tr>
        <tr><td colspan="7">&nbsp;</td></tr>
        <tr >
        <td class="frm-lft-clr123" width="15%">
            FromDate</td >
        <td class="frm-rght-clr123" width="15%">
           &nbsp; <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
               <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
                    ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                    ValidationGroup="c" ValueToCompare="MM/dd/yyyy" Display="Dynamic"></asp:CompareValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="MM/dd/yyyy"></cc1:CalendarExtender>&nbsp;</td>
       <td class="frm-lft-clr123" width="15%">
           ToDate</td>
            <td class="frm-lft-clr123" >
                 &nbsp;<asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox><asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" /><asp:RequiredFieldValidator
                          ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_edate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                          ValidationGroup="c"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidator1"
                              runat="server" ControlToValidate="txt_edate" Display="Dynamic" ErrorMessage="Check date format(MM/dd/yyyy)"
                              Operator="DataTypeCheck" Type="Date" ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator><cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate" Format="MM/dd/yyyy">
                              </cc1:CalendarExtender>
                &nbsp;&nbsp;
            </td>
             <td colspan="3" class="frm-lft-clr123" width="12%">        
             <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" ValidationGroup="c" />&nbsp;
          </td>
        </tr>
    </table></td>
  </tr>
  <tr>
    <td height="5" valign="top"><table width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
            <td valign="top" align="right">
            <table width="100%">
            <tr><td class="frm-lft-clr123" align="left" width="20%">
                &nbsp;Send Mail</td>
            <td class="frm-rght-clr123">
                &nbsp;&nbsp;&nbsp;
                &nbsp;<asp:Button ID="btnsend" runat="server" CssClass="button" ToolTip="Send Mail" Text="Send mail" OnClick="btnsend_Click" />&nbsp;
                
         
            </td>
            </tr>
            
            </table>
                
                      
                </td>
          </tr>
          <tr>
            <td valign="top">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                              <td valign="top" class="txt02" >&nbsp;Employee Record
                              <br />
                               <asp:LinkButton id="lnkcheckall" onclick="lnkcheckall_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                |
                               <asp:LinkButton ID="lnkuncheckall" runat="server" CssClass="txt-red" OnClick="lnkuncheckall_Click">Uncheck All</asp:LinkButton>
                              </td>
                            </tr>
                            <tr>
                              <td class="head-2" valign="top" >          
                               <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial"  CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%"
                                AutoGenerateColumns="False" BorderWidth="0px"  AllowPaging="True" PageSize="200" EmptyDataText="No such employee exists !" OnPageIndexChanging="empgrid_PageIndexChanging">
                                   <Columns>                                  

                                   <asp:TemplateField HeaderText="Select">
                                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                   <ItemStyle Width="6%" HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                  <ItemTemplate>                                  
                                  <asp:CheckBox ID="checkg" runat="Server" Checked="false"></asp:CheckBox>
                                  </ItemTemplate>
                                   </asp:TemplateField>  
                                   
                                   <asp:TemplateField HeaderText="Emp Code">
                                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                   <ItemStyle Width="8%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                  <ItemTemplate>                                  
                                  <asp:Label ID="lblempcodeg" runat="server" Text ='<%# Bind("empcode")%>'></asp:Label>
                                  </ItemTemplate>
                                   </asp:TemplateField> 
                                   
                                    <asp:TemplateField HeaderText="Employee Name">
                                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                   <ItemStyle Width="24%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                  <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text ='<%# Bind ("name") %>'></asp:Label>
                                  </ItemTemplate>
                                   </asp:TemplateField>
                                   
                                   <asp:TemplateField HeaderText="Designation">
                                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                   <ItemStyle Width="18%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                  <ItemTemplate>
                                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("designation") %>'></asp:Label>
                                  </ItemTemplate>
                                   </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Department">
                                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                   <ItemStyle Width="18%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                  <ItemTemplate>
                                    <asp:Label ID="l4" runat="server" Text ='<%# Bind ("department") %>'></asp:Label>
                                  </ItemTemplate>
                                   </asp:TemplateField>     
                                   
                                   <asp:TemplateField HeaderText="No_Of_Days">
                                   <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                   <ItemStyle Width="12%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                  <ItemTemplate>
                                    <asp:Label ID="l5" runat="server" Text ='<%# Bind ("NO_OF_DAYS") %>'></asp:Label>
                                  </ItemTemplate>
                                   </asp:TemplateField>                    
                  
                                  </Columns> 
                                      <HeaderStyle CssClass="frm-lft-clr123" />
                                      <FooterStyle CssClass="frm-lft-clr123" />
                                      <RowStyle Height="5px" />
                                   <PagerSettings Position="TopAndBottom" />
                                  </asp:GridView>
                              </td>
                            </tr>
                        </table>
                            
                        
                        </td>
                      </tr>  
             </table></td>
          </tr>
          
          <tr>
            <td height="10" valign="top"></td>
          </tr>          
     
  </table>
  </td>
  </tr>
  <tr>
  </tr>
</table>
</div>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
</form>
</body>
</html>
