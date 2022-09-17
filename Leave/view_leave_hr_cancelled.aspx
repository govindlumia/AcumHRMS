<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_leave_hr_cancelled.aspx.cs" Inherits="leave_view_leave_hr_cancelled" %>
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
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">
                View Leave</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
          <tr>
        <td height="20" valign="top" class="txt02">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
         <tr>
               <td width="27%" class="txt02" height="22">Employee Information</td>
               <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
             </tr>
             </table>
       </td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="19%" class="frm-lft-clr123">Employee Name</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_emp_name" runat="server"></asp:Label></td>
            <td width="1%" rowspan="7">&nbsp;</td>
            <td width="18%" class="frm-lft-clr123">Gender</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_gender" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="5" colspan="2"></td>
            <td height="5" colspan="2"></td>
          </tr>
          <tr>
            <td width="19%" class="frm-lft-clr123">Employee Code </td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_emp_code" runat="server"></asp:Label></td>
            <td width="18%" class="frm-lft-clr123">Branch</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_branch" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="5" colspan="2"></td>
            <td height="5" colspan="2"></td>
          </tr>
          <tr>
            <td width="19%" class="frm-lft-clr123">Department</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_department" runat="server"></asp:Label></td>
            <td width="18%" class="frm-lft-clr123">D.O.J</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_doj" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td height="5" colspan="2"></td>
            <td height="5" colspan="2"></td>
          </tr>
          <tr>
            <td width="19%" class="frm-lft-clr123">Designation</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_designation" runat="server"></asp:Label></td>
            <td width="18%" class="frm-lft-clr123">Status</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:Label ID="lbl_emp_status" runat="server"></asp:Label>&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
 
       <tr>
        <td align="right" valign="top" style="height: 18px">
            <input id="Button2" class="button1" onclick="document.getElementById('light').style.display='block';" type="button" value="Leave Status" />
        </td>
      </tr>
      <tr>
        <td height="20" valign="top" class="txt02">Apply Leave</td>
      </tr>
      <tr>
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          
          <tr>
            <td width="19%" class="frm-lft-clr123" style="height: 27px">Type of Leave </td>
            <td class="frm-rght-clr123" style="height: 27px">
                <asp:Label ID="lbl_leave" runat="server"></asp:Label>
            </td>
            </tr>
          <tr>
            <td height="5" colspan="2"></td>
            </tr>
            
<%--           <tr>
       <td colspan="2" style="height: 46px">
                 <div id="div1" runat="server">
                  <table width="100%" cellpadding="0" cellspacing="0" border="0">
                     <tr>
                         <td width="19%" class="frm-lft-clr123">
                             Leave Mode</td>
                         <td class="frm-rght-clr123">
                     <asp:RadioButton ID="opt_fullday" runat="server" Checked="True" GroupName="a" Text="Full Day" AutoPostBack="True" OnCheckedChanged="opt_fullday_CheckedChanged" />
                             <asp:RadioButton ID="opt_halfday" runat="server" GroupName="a" Text="Half Day" AutoPostBack="True" CausesValidation="True" OnCheckedChanged="opt_halfday_CheckedChanged" /></td>
                     </tr>
                   </table>
                 </div>
        </td>
         </tr> --%>

          <tr>
            <td colspan="2">
            <div id="divfull" visible="true" runat="server" >
                  <table width="100%" cellpadding="0" cellspacing="0" border="0">
                     <tr>
                         <td width="19%" class="frm-lft-clr123">From Date </td>
                         <td class="frm-rght-clr123">
                             <asp:Label ID="lbl_sdate" runat="server" Text=""></asp:Label></td>
                     </tr>
                     <tr>
                        <td height="5" colspan="2"></td>
                    </tr>
                    <tr>
                        <td width="19%" class="frm-lft-clr123">To Date </td>
                         <td class="frm-rght-clr123">
                             <asp:Label ID="lbl_edate" runat="server" Text=""></asp:Label></td>
                  </tr>
              </table>
         </div>
         </td>
            </tr>
              <tr>
       <td colspan="2">
                 <div id="divhalf" visible="false" runat="server">
                  <table width="100%" cellpadding="0" cellspacing="0" border="0">
                       <tr>
                         <td width="19%" class="frm-lft-clr123">
                             Half Day Mode</td>
                         <td class="frm-rght-clr123">
                             <asp:Label ID="lbl_half" runat="server" Text=""></asp:Label></td>
                     </tr>
                       <tr>
                        <td height="5" colspan="2"></td>
                    </tr>
                     <tr>
                         <td width="19%" class="frm-lft-clr123">
                             Select Date</td>
                         <td class="frm-rght-clr123">
                             <asp:Label ID="lbl_select" runat="server" Text=""></asp:Label></td>
                     </tr>
                   </table>
                 </div>
        </td>
   </tr>
            <tr>
            <td height="5" colspan="2"></td>
            </tr>
          <tr>
            <td width="19%" class="frm-lft-clr123">No. of Days </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lbl_nod" runat="server" Text=""></asp:Label></td>
            </tr>
       <tr>
            <td height="10" colspan="2"></td>
          </tr>
          <tr>
            <td height="22" colspan="2" valign="top" class="txt02">Leave Adjustment</td>
          </tr>
 <tr>
            <td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="display: none">
            <tr>
            <td width="19%" class="frm-lft-clr123">Leave Type</td>
            <td width="31%" class="frm-rght-clr123">
                <asp:DropDownList ID="drp_leave" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                    DataTextField="leavetype" DataValueField="leaveid">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    DeleteCommand="DELETE FROM [tbl_leave_createleave] WHERE [leaveid] = @leaveid"
                    InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype]) VALUES (@leavetype)"
                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [leaveid], [leavetype] FROM [tbl_leave_createleave] where status=1"
                    UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
                    <DeleteParameters>
                        <asp:Parameter Name="leaveid" Type="Int32" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="leavetype" Type="String" />
                        <asp:Parameter Name="leaveid" Type="Int32" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="leavetype" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
            </td>
            <td width="1%">&nbsp;</td>
            <td width="18%" class="frm-lft-clr123">No. of Days</td>
            <td width="31%" class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
            <td>
                <asp:TextBox ID="txt_noofdays" CssClass="input" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_noofdays"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter days" />'
                    ValidationGroup="add"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_noofdays"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter valid days" />'
                    MaximumValue="100" MinimumValue="1" Type="Double" ValidationGroup="add"></asp:RangeValidator></td>
            <td align="right" width="30%"><asp:Button ID="btn_add" runat="server" CssClass="button" OnClick="btn_add_Click" Text="Add" ValidationGroup="add" />&nbsp;</td>
            </tr>
            </table>
            </td>
            </tr>
            </table></td>
            </tr>
            <tr>
            <td colspan="2" style="height: 5px"></td>
          </tr>
          <tr>
          <td valign="top" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
              <td class="head-2" valign="top"  >
              <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No leave to adjust"
                  DataKeyNames="leaveid" OnRowCancelingEdit="adjustgrid_RowCancelingEdit" OnRowDeleting="adjustgrid_RowDeleting" OnRowEditing="adjustgrid_RowEditing" OnRowUpdating="adjustgrid_RowUpdating">
                   <Columns>               
                   <asp:TemplateField HeaderText="Leave Type">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="40%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("leavename") %>'></asp:Label>
                  </ItemTemplate>
                    <EditItemTemplate>
                
                  <asp:DropDownList ID="drp_lv" CssClass="select" runat="server" SelectedValue='<%# Bind("leaveid") %>'  Font-Size="8pt" DataSourceID="SqlDataSource1" DataTextField="leavetype" DataValueField="leaveid"></asp:DropDownList>  
                </EditItemTemplate>
                   </asp:TemplateField>
                   
                                  
                   <asp:TemplateField HeaderText="No. of Days">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="40%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("noofdays") %>'></asp:Label>
                  
                  </ItemTemplate>
                  <EditItemTemplate>
                   <asp:TextBox ID="txt_nd" runat="Server" Text='<%# Eval("noofdays") %>' CssClass="input"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nd"
                          Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter days" />'
                          ValidationGroup="grid"></asp:RequiredFieldValidator>
                      <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nd"
                          Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter valid days" />'
                          MaximumValue="100" MinimumValue="1" Type="Double" ValidationGroup="grid"></asp:RangeValidator>
                        </EditItemTemplate>
                   </asp:TemplateField>
                   
                    <asp:TemplateField Visible="False" >                 
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l4" runat="server" Text ='<%# Bind ("status") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                   
                    <asp:TemplateField Visible="false" >
                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/> 
                <EditItemTemplate>
                        <asp:LinkButton ID="lnk_update" CssClass="link05" CommandName="Update" runat="server" ValidationGroup="grid">Update</asp:LinkButton>|
                        <asp:LinkButton ID="lnk_cancel" CssClass="link05" CommandName="Cancel" runat="server" ValidationGroup="noone">Cancel</asp:LinkButton>
                </EditItemTemplate>
              
                <ItemStyle Width="24%"    HorizontalAlign="left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                <ItemTemplate>
                <asp:LinkButton ID="lnk_edit" CssClass="link05"  CommandName="Edit" runat="server" ValidationGroup="noone">Edit </asp:LinkButton>|
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
         <tr>
            <td class="frm-lft-clr123">Reason</td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lbl_reason" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td colspan="2" style="height: 5px"></td>
            </tr>
          <tr>
            <td class="frm-lft-clr123">Attachment (if any) </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lbl_file" runat="server"></asp:Label></td>
          </tr>
              <tr>
            <td height="10" colspan="2"></td>
            </tr>
          <tr>
                <td colspan="2" height="22" valign="top" class="txt02">Approver Hierarchy&nbsp;</td>
            </tr>
      <tr>
              <td class="head-2" valign="top" colspan="2" >
              <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No leave to adjust"
                  DataKeyNames="empcode">
                   <Columns>  
                   
                   <asp:TemplateField HeaderText="Employee Code">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="20%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("empcode") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                                
                   <asp:TemplateField HeaderText="Approver Name">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="30%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("empname") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>               
                   <asp:TemplateField HeaderText="Level">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="15%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("Levels") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>

                      <asp:TemplateField>
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="35%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("status") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle Height="5px" />
                  </asp:GridView></td>
            </tr>
          <tr>
            <td colspan="2" style="height: 5px"></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 5px">
                    <asp:Label ID="lbl_comments" runat="server"></asp:Label></td>
            </tr>
                <tr>
            <td class="frm-lft-clr123">Add Comment</td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_comment" runat="server" CssClass="select" TextMode="MultiLine"
                    Width="270px"></asp:TextBox></td>
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
            &nbsp; &nbsp;<asp:Button ID="btn_approve" runat="server" CssClass="button" OnClick="btn_approve_Click"
                Text="Update" Visible="False" />&nbsp;
            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" Visible="False" />&nbsp;<asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" OnClick="btncancel_Click" Visible="False" />&nbsp;
        </td>
      </tr>
      <tr>
        <td valign="top">&nbsp;<asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
            <asp:HiddenField ID="hidd_empcode" runat="server" Value="0" />
        </td>
      </tr>
    </table>
    </div>
    <div id="light" style="top:35%;left:10%;" class="pop1" align="center">
<table width="600px" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="pop-brdr"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="95%" valign="top" class="pop-tp-clr" align="left"> </td>
<td width="5%" align="right" valign="top" class="pop-tp-clr"><a href="#" onclick="document.getElementById('light').style.display='none';"><img src="images/btn-close.gif" width="16" height="19" border="0" /></a></td>
</tr>
<tr>
<td colspan="2" height="10"></td>
</tr>
<tr>
<td colspan="2" align="center" valign="top"><iframe src="my_balance_leave.aspx?empcode=<%=hidd_empcode.Value%>" frameborder="0" scrolling="yes" width="600" height="250"></iframe></td>
</tr>
<tr>
<td colspan="2" height="10"></td>
</tr>
</table></td>
</tr>
</table>
</div>
    </form>
</body>
</html>
