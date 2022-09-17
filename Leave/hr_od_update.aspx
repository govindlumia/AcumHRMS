<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hr_od_update.aspx.cs" Inherits="leave_hr_od_update" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>KOD Intranet</title>
<style type="text/css" media="all">
@import "css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
<script type="text/javascript" src="js/timepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>        
    <div>
    <table width="718" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
            <td class="txt01">Official Duty </td>
            </tr>
        </table></td>
      </tr>
      <tr>
      <td height="9"></td>
      </tr>
      <tr>
        <td height="20" valign="top" class="txt02"><table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td>&nbsp;Employee Information</td>
        <td class="txt-red" align="right"><span id="message" runat="server" ></span>&nbsp;</td>
        </tr>
        </table></td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="20%" class="frm-lft-clr123">Employee Name</td>
            <td width="80%" class="frm-rght-clr123">
            <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_employee"
                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                <a href="JavaScript:newPopup1('admin/pickemployee.aspx');" class="link05">Pick Employee</a>
                </td>
            
          </tr>

        </table></td>
      </tr>
      <tr>
        <td valign="top" style="height: 10px">&nbsp;</td>
      </tr>
      <tr>
        <td height="20" valign="top" class="txt02">&nbsp;Apply Official Duty </td>
      </tr>
      <tr>
        <td height="10" valign="top">
        
        <table width="100%" border="0" cellspacing="0" cellpadding="0">  
             <tr>
            <td colspan="2">
             <div id="div" runat="server" >
                <asp:RadioButton ID="rdofullday" runat="server" Checked="True"  GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged" Text="Full Day" ValidationGroup="noone" AutoPostBack="True" />
                <asp:RadioButton ID="rdohalfday" runat="server"  GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged" Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
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
           <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="19%" class="frm-lft-clr123"> From Date </td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_date" runat="server" CssClass="input" Enabled="False" AutoPostBack="True" OnTextChanged="txt_date_TextChanged"></asp:TextBox>
                <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_date"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_date"
                    Display="Dynamic" ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px"
                    Operator="DataTypeCheck" ToolTip="Check date format (MM/dd/yyyy)" Type="Date"
                    ValidationGroup="v" Width="175px"></asp:CompareValidator></td>
          </tr>
          
          <tr>
            <td height="5" colspan="2"></td>            
          </tr>
          
           <tr>
            <td width="19%" class="frm-lft-clr123">
                To Date</td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_ftime" runat="server" CssClass="input" Enabled="False" AutoPostBack="True" OnTextChanged="txt_ftime_TextChanged"></asp:TextBox>
                <asp:Image ID="imgf" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_ftime"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_ftime" Display="Dynamic" ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px" Operator="DataTypeCheck" ToolTip="Check date format (MM/dd/yyyy)" Type="Date" ValidationGroup="v" Width="175px"></asp:CompareValidator>
            </td>
          </tr>
          <tr>
          <td height="5" colspan="2" valign="top"></td>
        </tr>
          <tr>
          <td valign="middle" class="frm-lft-clr123">
              From-Time</td>
          <td valign="top" class="frm-rght-clr123">
               <asp:TextBox ID="txt_time" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
              <asp:Image ID="Image1" runat="server" ImageUrl="~/Leave/images/clndr.gif" /><asp:RequiredFieldValidator
                      ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_time" Display="Dynamic"
                      ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />' ValidationGroup="v"></asp:RequiredFieldValidator></td>
        </tr>
        
    
        <tr>
          <td height="5" colspan="2" valign="top"></td>
        </tr>
        <tr>
          <td width="15%" valign="middle" class="frm-lft-clr123">
              To-Time
          </td>
          <td width="85%" valign="top" class="frm-rght-clr123">
              
               <asp:TextBox ID="txtouttime" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
              <asp:Image ID="imgouttime" runat="server" ImageUrl="~/Leave/images/clndr.gif" /><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtouttime"
                  Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Select employee" />'
                  ValidationGroup="v"></asp:RequiredFieldValidator></td>
        </tr>
      
       
             
          
          </table>
          </div>
          </td></tr> 
          
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
                                 ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator>
                             <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_select"
                                 Display="Dynamic" ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px"
                                 Operator="DataTypeCheck" ToolTip="Check date format (MM/dd/yyyy)" Type="Date"
                                 ValidationGroup="v" Width="175px"></asp:CompareValidator>
                             <cc1:CalendarExtender
                        id="Calendarextender3" runat="server" popupbuttonid="img_select" targetcontrolid="txt_select">
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
            <td width="19%" class="frm-lft-clr123">Reason</td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_reason" runat="server" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
          </tr>
          <tr>
            <td height="5" colspan="2" ></td>
          </tr>
          <tr>
            <td width="19%" class="frm-lft-clr123">
                Add Comment</td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_comment" runat="server" TextMode="MultiLine" Width="240px"></asp:TextBox></td>
          </tr>
          
         <tr>
            <td height="5" colspan="2"></td>
          </tr>
                
        </table>        
        </td>
      </tr>
      <tr>
        <td valign="top" height="10">
            &nbsp;<cc1:calendarextender id="CalendarExtender1" runat="server" popupbuttonid="img" targetcontrolid="txt_date"></cc1:calendarextender>
                  <cc1:calendarextender id="Calendarextender2" runat="server" popupbuttonid="imgf" targetcontrolid="txt_ftime"></cc1:CalendarExtender>
            <asp:HiddenField ID="HiddenField1" runat="server" />
        </td>
      </tr>
      
      <tr>
        <td align="right" valign="top">
            <asp:Button ID="btn_sbmit" runat="server" CssClass="button" Text="Submit" OnClick="btn_sbmit_Click" ValidationGroup="v" />
            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />
            &nbsp;
        </td>
      </tr>
      <tr>
        <td valign="top">&nbsp;</td>
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
