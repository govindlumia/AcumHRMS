<%@ Page Language="C#" AutoEventWireup="true" CodeFile="set_dutyroster.aspx.cs" Inherits="admin_set_tmt_dutyroster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title> Employee Information</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<style type="text/css" media="all">

@import "../css/blue1.css";
.input3 {font: normal 11px Arial, Helvetica, sans-serif; color: #000;
}
</style>

<script type="text/javascript">

//function checkStartdate()
//{    
//    var stDate = new Date(document.forms[0].txt_start_date.value);
//    var edDate = new Date(document.forms[0].txt_end_date.value);
//            
//    if (stDate > edDate) 
//    {
//        alert("From date must be less than To date");
//        document.forms[0].txt_start_date.value=document.getElementById('HiddenField1').value;
//    }
//}

//function checkEnddate()
//{
//    var stDate = new Date(document.forms[0].txt_start_date.value);
//    var edDate = new Date(document.forms[0].txt_end_date.value);
//           
//    if (stDate > edDate)
//    {
//        alert("To date must be greater than From date");
//        document.forms[0].txt_end_date.value=document.getElementById('HiddenField2').value;
//    }  
//}

</script>

</head>

<body>

<form id="DutyRoster" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
            </table></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

<div style="overflow-x:hidden; overflow-y:scroll; height:524px; width:968px;" >
<table width="923" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td colspan="2" valign="top"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td align="left" class="txt01">Duty Roster</td>
<td align="right" class="txt-red"><span id="message" runat="server" class="txt-red"></span></td>
<td align="right"><a href="leaveadmin.aspx" class="txt-red" target="name123" >Back</a> | <asp:LinkButton ID="lnkrefresh" runat="server" OnClick="lnkrefresh_Click" CssClass="txt-red">Refresh</asp:LinkButton>&nbsp;</td>
</tr>
</table></td>
</tr>

<tr><td colspan="2"><div id="divempsearch" runat="server"><table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td align="left" class="txt02" colspan="7">Search Employee</td>
</tr>
<tr >
        <td class="frm-lft-clr123" width="12%">Name</td >
        <td class="frm-rght-clr123" width="17%">
        <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="95px"></asp:TextBox>
        </td>
       <td class="frm-lft-clr123" width="14%">Designation</td>
       <td class="frm-rght-clr123" width="16%"><asp:DropDownList ID="dd_designation" runat="server"
                CssClass="select" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound" Width="131px">
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]">
            </asp:SqlDataSource></td>
          <td class="frm-lft-clr123" width="11%">Department</td>
          <td class="frm-rght-clr123" width="16%">
              &nbsp;<asp:DropDownList ID="dd_dpt" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                  DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dpt_DataBound" Width="172px">
              </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                  ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name">
              </asp:SqlDataSource>
            </td>
            <td class="frm-lft-clr123" width="14%">
            
            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="Button1_Click1" />
       </td>
        </tr>
 </table></div></td></tr>
 
<tr>
  <td colspan="2" valign="top">&nbsp;</td>
</tr>
<tr>
<td colspan="2" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="20%" class="frm-lft-clr123">From Date</td>
<td width="30%" class="frm-rght-clr123" valign="top"><asp:TextBox ID="txt_start_date" runat="server" CssClass="input2" Width="100px" Enabled="False"></asp:TextBox>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_start_date"
        Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Code" ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txt_start_date" FirstDayOfWeek="Monday"></cc1:CalendarExtender>
<%--  OnChange="chkDate()"--%>
</td>
<td width="20%" class="frm-lft-clr123">To Date</td>
<td width="30%" class="frm-rght-clr123"><asp:TextBox ID="txt_end_date" runat="server" CssClass="input2" Width="100px" Enabled="False"></asp:TextBox>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_end_date"
        Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Code" ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
    <asp:HiddenField ID="HiddenField2" runat="server" />
   <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2" TargetControlID="txt_end_date"></cc1:CalendarExtender>
</td>
</tr>
</table></td>
</tr>
<tr>
<td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="20%" class="frm-lft-clr123">Days</td>
<td width="10%" align="center" valign="middle" class="frm-lft-clr123">Monday</td>
<td width="11%" align="center" valign="middle" class="frm-lft-clr123">Tuesday</td>
<td width="11%" align="center" valign="middle" class="frm-lft-clr123">Wednesday</td>
<td width="12%" align="center" valign="middle" class="frm-lft-clr123">Thursday</td>
<td width="12%" align="center" valign="middle" class="frm-lft-clr123">Friday</td>
<td width="12%" align="center" valign="middle" class="frm-lft-clr123">Saturday</td>
<td width="12%" align="center" valign="middle" class="frm-lft-clr123">Sunday</td>
</tr>
<tr>
<td align="left" class="frm-lft-clr123">Select Shift</td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpMonShift" runat="server" DataTextField="shiftname" DataValueField="shiftid" CssClass="select1" AutoPostBack="True" OnSelectedIndexChanged="drpMonShift_SelectedIndexChanged"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpTueShift" runat="server" class="select1"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpWedShift" runat="server" class="select1"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpThruShift" runat="server" class="select1"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpFriShift" runat="server" class="select1"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpSatShift" runat="server" class="select1"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpSunShift" runat="server" class="select1"></asp:DropDownList></td>
</tr>
<tr>
<td colspan="8" height="7"></td>
</tr>
<tr>
<td colspan="8" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td align="left" class="txt1" height="20" valign="top"><asp:LinkButton ID="lnkcheckall" runat="server" OnClick="lnkcheckall_Click" CssClass="txt-red">Check All</asp:LinkButton> l <asp:LinkButton ID="lnkuncheckall" runat="server" OnClick="lnkuncheckall_Click" CssClass="txt-red">Uncheck All</asp:LinkButton></td>
</tr>
<tr>
<td align="center"><div><table cellpadding="0" cellspacing="0" width="100%" border="0">
<tr>
<td style="overflow-x:hidden; overflow-y:scroll; width:940px;" >
<asp:GridView id="Grid_Emp" runat="server" AllowPaging="True" Width="100%" Font-Size="11px" Font-Names="Arial" HorizontalAlign="Left" DataKeyNames="empcode" CellPadding="4" AutoGenerateColumns="False" CellSpacing="0" AllowSorting="True" PageSize="50" OnPageIndexChanging="Grid_Emp_PageIndexChanging" BorderWidth="0px" EmptyDataText="No such employee exists"> 
<PagerSettings PageButtonCount="5"></PagerSettings>
<Columns>

<asp:TemplateField >
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234" Width="10%"/> 
<ItemTemplate>
<asp:CheckBox ID="Chkbox" runat="server" BorderStyle="None" Text='<%# Eval("empcode")%>' ForeColor="White"/>
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="empcode" HeaderText="Employee code">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="15%"/> 
</asp:BoundField>

<asp:BoundField DataField="name" HeaderText="Employee Name">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="25%"/> 
</asp:BoundField>

<asp:BoundField DataField="branch_name" HeaderText="Branch">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="15%"/> 
</asp:BoundField>

<asp:BoundField DataField="department_name" HeaderText="Department">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="15%"/> 
</asp:BoundField>

<asp:BoundField DataField="designationname" HeaderText="Designation">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="25%"/> 
</asp:BoundField>
</Columns>
<HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" VerticalAlign="Top"></HeaderStyle>
<FooterStyle CssClass="frm-lft-clr123" />
<PagerStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></PagerStyle>
</asp:GridView> 
</td>
</tr>
</table></div>
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td colspan="8" align="right"><table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td align="left"><a href="leaveadmin.aspx" class="txt-red" target="name123" >Back</a></td>
<td align="right"><asp:Button ID="submitbtn" runat="server" CssClass="button" Text="Submit" OnClick="submitbtn_Click" ValidationGroup="s" />&nbsp;
</td>
</tr>
</table>
</td>
</tr>
</table>
</td>
</tr>
</table>
</td>
</tr>
</table>
</div>
</ContentTemplate>

</asp:UpdatePanel>

</form>

</body>

</html>
