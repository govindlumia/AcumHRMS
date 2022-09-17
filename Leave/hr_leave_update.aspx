<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hr_leave_update.aspx.cs" Inherits="leave_hr_leave_update" %>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>

             <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                </tr>
                </table></div>
            
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">Apply Leave</td>
            </tr>
        </table></td>
      </tr>
      <tr>
        <td height="5" valign="top"></td>
      </tr>
          <tr>
        <td height="20" valign="top" class="txt02">
        <table width="100%">
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
            <td width="20%" class="frm-lft-clr123">Employee Name</td>
            <td width="80%" class="frm-rght-clr123">
            <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_employee"
                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                <a href="JavaScript:newPopup1('admin/pickemployee.aspx');" class="link05">Pick Employee</a>
                </td>
            
          </tr>

        </table></td>
      </tr>
      <tr>
        <td height="6" valign="top"></td>
      </tr>
      <tr>
        <td align="right" valign="top" style="height: 18px">
           <%-- <input id="Button1" class="button1" onclick="document.getElementById('light').style.display='block';" type="button" value="Leave Status" />--%>
            
        </td>
      </tr>
      <tr>
        <td height="22" valign="top" class="txt02">Apply Leave</td>
      </tr>
      <tr>
        <td height="10" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          
          <tr>
            <td width="19%" class="frm-lft-clr123">Type of Leave </td>
            <td class="frm-rght-clr123">
                <asp:DropDownList ID="dd_typeleave" runat="server" CssClass="select" DataSourceID="SqlDataSource1" DataTextField="leavetype" DataValueField="leaveid" OnDataBound="dd_typeleave_DataBound" OnSelectedIndexChanged="dd_typeleave_SelectedIndexChanged" AutoPostBack="True" Width="109px">
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_typeleave"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                    ToolTip="Select Leave Name" ValueToCompare="100" ValidationGroup="calculate"></asp:CompareValidator>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    
                    ProviderName="System.Data.SqlClient" SelectCommand="select crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid where elm.empcode=@empcode and crleave.leaveid not in (0) order by crleave.leavetype"
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
                    <SelectParameters>
                        <asp:SessionParameter Name="empcode" SessionField="empcode" />
                    </SelectParameters>                    
                </asp:SqlDataSource>
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
             <div id="div" visible="false" runat="server" >
                <asp:RadioButton ID="rdofullday" runat="server" Checked="True"  GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged" Text="Full Day" ValidationGroup="noone" AutoPostBack="True" /><asp:RadioButton ID="rdohalfday"
                    runat="server"  GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged" Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
           </div>
           </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 5px">
                </td>
            </tr>

          <tr>
            <td colspan="2">
            <div id="divfull" visible="true" runat="server" >
                  <table width="100%" cellpadding="0" cellspacing="0" border="0">
                     <tr>
                         <td width="19%" class="frm-lft-clr123">From Date </td>
                         <td class="frm-rght-clr123">
                          <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>&nbsp;<asp:Image
                         ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                 ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="calculate"></asp:RequiredFieldValidator>
                         <cc1:calendarextender
                        id="CalendarExtender1" runat="server" popupbuttonid="img_f" targetcontrolid="txt_sdate"></cc1:calendarextender></td>
                     </tr>
                     <tr>
                        <td colspan="2" style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td width="19%" class="frm-lft-clr123">To Date </td>
                         <td class="frm-rght-clr123">
                        <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>&nbsp;<asp:Image
                         ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                 ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="calculate"></asp:RequiredFieldValidator>
                         <cc1:calendarextender
                        id="CalendarExtender3" runat="server" popupbuttonid="img_t" targetcontrolid="txt_edate"></cc1:calendarextender></td>
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
                         <td width="19%" class="frm-lft-clr123" style="height: 36px">
                             Half Day Mode</td>
                         <td class="frm-rght-clr123" style="height: 36px">
                     <asp:RadioButton ID="opt_first" runat="server" Checked="True" GroupName="b" Text="First Half" OnCheckedChanged="opt_first_CheckedChanged" />
                             <asp:RadioButton ID="opt_second" runat="server" GroupName="b" Text="Second Half" OnCheckedChanged="opt_second_CheckedChanged" /></td>
                     </tr>
                       <tr>
                        <td height="5" colspan="2"></td>
                    </tr>
                     <tr>
                         <td width="19%" class="frm-lft-clr123">
                             Select Date</td>
                         <td class="frm-rght-clr123">
                             <asp:TextBox ID="txt_select" runat="server" CssClass="input"></asp:TextBox>
                             <asp:Image
                         ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_select"
                                 ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="calculate"></asp:RequiredFieldValidator>
                             <cc1:CalendarExtender
                        id="Calendarextender2" runat="server" popupbuttonid="img_select" targetcontrolid="txt_select">
                             </cc1:CalendarExtender>
                         </td>
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
                <asp:TextBox ID="txt_nod" runat="server" CssClass="select" Enabled="False">0</asp:TextBox>
                &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nod"
                    ErrorMessage='<img src="../images/error1.gif" alt="Calculate No. of days" />'
                    MaximumValue="100" MinimumValue="0.5" Type="Double" ValidationGroup="all"></asp:RangeValidator>
                <asp:Button ID="btn_calc" runat="server" Text="Calculate No. of Days" OnClick="btn_calc_Click" Width="124px" CssClass="butt" ValidationGroup="calculate" /></td>
            </tr>
       
          
          <tr>
            <td height="10" colspan="2"></td>
          </tr>
          <tr>
          <td valign="top" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="22" valign="top" class="txt02">Leave Adjustment</td>
            </tr>
            <tr>
              <td class="head-2" valign="top" >
              
              
              
                  <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No leave to adjust"
                  DataKeyNames="leaveid">
                   <Columns>               
                   <asp:TemplateField HeaderText="Leave Type">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="50%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("leavename") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                                  
                   <asp:TemplateField HeaderText="No. of Days">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="50%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("noofdays") %>'></asp:Label>
                  
                  </ItemTemplate>
                   </asp:TemplateField>
                   
                    <asp:TemplateField Visible="false" >                 
                   <ItemStyle Width="0%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>
                  
                  <asp:Label ID="l4" runat="server" Text ='<%# Bind ("status") %>'></asp:Label>
                  
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
            <td height="5" colspan="2"></td>
          </tr>
          <tr>
            <td class="frm-lft-clr123">Reason</td>
            <td class="frm-rght-clr123"><asp:TextBox ID="txt_reason" runat="server" CssClass="select" TextMode="MultiLine"
                    Width="270px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_reason"
                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="all"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td height="5" colspan="2"></td>
            </tr>
          <tr>
            <td class="frm-lft-clr123">Attachment (if any) </td>
            <td class="frm-rght-clr123"><asp:FileUpload ID="upload_attach" runat="server" CssClass="input2" Width="287px" />
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="upload_attach"
                    ErrorMessage='<img src="../images/error1.gif" alt="Upload file" />' ValidationGroup="all" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="upload_attach"
                    CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="file format not supported" />'
                    ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$" ValidationGroup="all"></asp:RegularExpressionValidator>--%>
                    
                    <asp:HiddenField ID="HiddenField_gender" runat="server" />
                    </td>
          </tr>
              <tr>
            <td height="10" colspan="2"></td>
            </tr>
          
      <tr>
              <td class="head-2" style="display:none;" valign="top" colspan="2" >
              <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  EmptyDataText="No leave to adjust"
                  DataKeyNames="empcode" DataSourceID="SqlDataSource2">
                   <Columns>  
                   
                   <asp:TemplateField HeaderText="Employee Code">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="33%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l1" runat="server" Text ='<%# Bind ("empcode") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>
                                
                   <asp:TemplateField HeaderText="Approver Name">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="33%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l2" runat="server" Text ='<%# Bind ("empname") %>'></asp:Label>
                  </ItemTemplate>
                   </asp:TemplateField>                   
                                  
                   <asp:TemplateField HeaderText="Level">
                   <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"/>                  
                   <ItemStyle Width="33%"  HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                  <ItemTemplate>                  
                  <asp:Label ID="l3" runat="server" Text ='<%# Bind ("Levels") %>'></asp:Label>                  
                  </ItemTemplate>
                   </asp:TemplateField>                  
                   
                   </Columns> 
                      <HeaderStyle CssClass="frm-lft-clr123" />
                      <FooterStyle CssClass="frm-lft-clr123" />
                      <RowStyle Height="5px" />                 
                  
                  </asp:GridView></td>
            </tr>
          <tr>
            <td height="5" colspan="2"></td>
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
        <td valign="top" height="10">
            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />
            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" runat="server" SelectCommand="select &#13;&#10;coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as empname,&#13;&#10;approverid as empcode,&#13;&#10;case when eh.HC=0 then 'Level ' + cast(approverpriority as varchar(10)) else 'HC' end as levels&#13;&#10;&#13;&#10;from tbl_leave_employee_hierarchy eh &#13;&#10;inner join &#13;&#10;tbl_intranet_employee_jobDetails ed&#13;&#10;&#13;&#10;on eh.approverid=ed.empcode &#13;&#10;where eh.employeecode=@empcode&#13;&#10;order by approverpriority">
                <SelectParameters>
                    <asp:SessionParameter Name="empcode" SessionField="empcode" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
      </tr>
      
      <tr>
        <td align="right" valign="top">
            <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Update" OnClick="btn_submit_Click" Enabled="False" />
            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" Visible="False" />
            <asp:Button ID="btn_draft" runat="server" CssClass="button" Text="Save Draft" OnClick="btn_draftl_Click" Visible="False" />&nbsp;
        </td>
      </tr>
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
    </table>
    </div>
    </ContentTemplate>
    <Triggers>
     <asp:PostBackTrigger ControlID="btn_submit" />     
     <asp:PostBackTrigger ControlID="btn_draft" />     
    </Triggers>                                     
    </asp:UpdatePanel>
    
    <div id="light" runat="server" style="top:35%;left:10%; display:none;" class="pop1" align="center">
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
<td colspan="2" align="center" valign="top"><iframe id="mybalance_leave" runat="server" src="my_balance_leave.aspx?empcode='00002'" frameborder="0" scrolling="no" width="600" height="250"></iframe></td>
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
