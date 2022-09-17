<%@ Page Language="C#" AutoEventWireup="true" CodeFile="set-duty-roster-for-all-employee.aspx.cs" Inherits="leave_admin_set_duty_roster_for_all_employee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Change Duty Roster for All Employee</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<style type="text/css" media="all">

@import "../css/blue1.css";
.input3 {font: normal 11px Arial, Helvetica, sans-serif; color: #000;
}
</style>

<script type="text/javascript">

function checkStartdate()
{

    
    var stDate = new Date(document.forms[0].txt_start_date.value);
    var edDate = new Date(document.forms[0].txt_end_date.value);
            
            if (stDate > edDate) 
                {
                    alert("From date must be less than To date");
                    document.forms[0].txt_start_date.value=document.getElementById('HiddenField1').value;
                }
}

function checkEnddate()
{
    var stDate = new Date(document.forms[0].txt_start_date.value);
    var edDate = new Date(document.forms[0].txt_end_date.value);
           
            if (stDate > edDate)
                {
                    alert("To date must be greater than From date");
                    document.forms[0].txt_end_date.value=document.getElementById('HiddenField2').value;
                }  
}

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

<div style="overflow-x:hidden; overflow-y:scroll; height:524px; width:968px;">
<table width="951" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="7"></td>
</tr>
<tr>
<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td colspan="2" valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td width="3%"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
<td class="txt01">Duty Roster </td>
<td align="right"><span id="message" runat="server" class="txt-red"></span></td>
<td align="right"><asp:CheckBox ID="chkempfilters" Text="More filter" runat="server" AutoPostBack="True" OnCheckedChanged="chkempfilters_CheckedChanged" />
&nbsp;<asp:LinkButton ID="lnkrefresh" runat="server" OnClick="lnkrefresh_Click">Refresh</asp:LinkButton></td>
</tr>
</table></td>
</tr>
<tr>
<td colspan="2" height="5"></td>
</tr>
<tr>
<td colspan="2" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="frm-lft-clr123" width="15%"> Branch</td>
<td class="frm-rght-clr123" width="20%"><asp:DropDownList ID="DropDownList8" runat="server" AutoPostBack="True" OnDataBound="DropDownList8_DataBound" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" class="select2">
    <asp:ListItem Value="0">ALL</asp:ListItem>
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;</td>
<td width="1%">&nbsp;</td>    
<td valign="top" colspan="2" width="64%"><div id="pic_more" runat="Server" visible="false">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="19%" class="frm-lft-clr123">Deptment</td>
<td width="40%" class="frm-rght-clr123"><asp:DropDownList ID="drpDept" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpDept_SelectedIndexChanged" class="select2"></asp:DropDownList>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>&nbsp;</td>
<td width="1%">&nbsp;</td>
<td width="15%" class="frm-lft-clr123">
    EmpID/Name</td>
<td width="18%" class="frm-rght-clr123" align="center"><asp:TextBox ID="txtempID" runat="server" Width="54px" CssClass="blue1"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rqValidator4EmpID" runat="server" ControlToValidate="txtempID" Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Code/Name" ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
<td width="7%" class="frm-rght-clr123" align="center"><asp:ImageButton ID="imgbtn4empid" runat="server" ImageUrl="~/images/action_check.gif" OnClick="imgbtn4empid_Click" ValidationGroup="v" /></td>
</tr>
</table>
</div></td>
</tr>
<tr>
<td colspan="5" height="5"></td>
</tr>
<tr>
<td width="15%" class="frm-lft-clr123">From Date<span class="mandatory">*</span></td>
<td width="20%" class="frm-rght-clr123" valign="top"><asp:TextBox ID="txt_start_date" runat="server" CssClass="blue1" Width="100px" onChange="checkStartdate()"></asp:TextBox>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_start_date"
        Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Code" ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txt_start_date" FirstDayOfWeek="Monday"></cc1:CalendarExtender>
<%--  OnChange="chkDate()"--%>
</td>
<td width="1%">&nbsp;</td>
<td width="12%" class="frm-lft-clr123">To Date</td>
<td width="52%" class="frm-rght-clr123"><asp:TextBox ID="txt_end_date" runat="server" CssClass="blue1" Width="100px" onChange="checkEnddate()"></asp:TextBox>
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
<td colspan="2" height="5"></td>
</tr>
<tr>
<td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="frm-lft-clr123" width="14%">Days</td>
<td class="frm-lft-clr123" width="12%" align="center">Monday</td>
<td class="frm-lft-clr123" width="12%" align="center">Tuesday</td>
<td class="frm-lft-clr123" width="12%" align="center">Wednesday</td>
<td class="frm-lft-clr123" width="12%" align="center">Thursday</td>
<td class="frm-lft-clr123" width="12%" align="center">Friday</td>
<td class="frm-lft-clr123" width="12%" align="center">Saturday</td>
<td class="frm-lft-clr123" width="12%" align="center">Sunday</td>
</tr>
<tr>
<td align="left" class="frm-lft-clr123">Select Shift</td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpMonShift" runat="server" DataTextField="shiftname" DataValueField="shiftid" class="select2" OnSelectedIndexChanged="drpMonShift_SelectedIndexChanged"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpTueShift" runat="server" class="select2"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpWedShift" runat="server" class="select2"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpThruShift" runat="server" class="select2"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpFriShift" runat="server" class="select2"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpSatShift" runat="server" class="select2"></asp:DropDownList></td>
<td align="center" class="frm-rght-clr1234"><asp:DropDownList ID="drpSunShift" runat="server" class="select2"></asp:DropDownList></td>
</tr>
<tr>
<td colspan="8" height="7"></td>
</tr>
<tr>
<td colspan="8" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="14%" align="left" class="frm-lft-clr123">Select Employee</td>
<td width="9%" align="center" class="frm-lft-clr123"><asp:LinkButton ID="lnkcheckall" runat="server" OnClick="lnkcheckall_Click">Check All</asp:LinkButton></td>
<td width="10%" align="center" class="frm-lft-clr123"><asp:LinkButton ID="lnkuncheckall" runat="server" OnClick="lnkuncheckall_Click">Uncheck All</asp:LinkButton></td>
<td width="67%" class="frm-lft-clr123">&nbsp;</td>
</tr>
<tr>
<td align="center" colspan="4"><div><table cellpadding="0" cellspacing="0" width="100%" border="0">
<tr>
<td><asp:GridView id="Grid_Emp" runat="server" AllowPaging="True" Width="100%" Font-Size="11px" Font-Names="Arial" HorizontalAlign="Left" DataKeyNames="empcode" CellPadding="4" AutoGenerateColumns="False" AllowSorting="True" PageSize="25" OnPageIndexChanging="Grid_Emp_PageIndexChanging" BorderWidth="0px"> 
<PagerSettings PageButtonCount="100"></PagerSettings>
<Columns>
<asp:TemplateField >
<HeaderStyle CssClass="frm-btm-line" HorizontalAlign="Left"/>                  
<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234" Width="10%"/> 
<ItemTemplate>
<asp:CheckBox ID="Chkbox" runat="server" BorderStyle="None" Text='<%# Eval("empcode")%>' ForeColor="White"/>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="empcode" HeaderText="Emp code">
<HeaderStyle CssClass="frm-btm-line" HorizontalAlign="Left" Width="10%"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"/> 
</asp:BoundField>
<asp:BoundField DataField="emp_name" HeaderText="Employee Name">
<HeaderStyle CssClass="frm-btm-line" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>
<asp:BoundField DataField="designationname" HeaderText="Degination">
<HeaderStyle CssClass="frm-btm-line" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="25%"/> 
</asp:BoundField>
<asp:BoundField DataField="branch_name" HeaderText="Branch">
<HeaderStyle CssClass="frm-btm-line" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="15%"/> 
</asp:BoundField>
<asp:BoundField DataField="department_name" HeaderText="Department">
<HeaderStyle CssClass="frm-btm-line" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
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
<td colspan="8">&nbsp;</td>
</tr>
<tr>
<td colspan="8" align="right"><table width="100%" cellpadding="0" cellspacing="0" border="0">
<tr>
<td align="left"><input type="button" id="bck" class="button" value="Back" onclick="javascript:history.go(-1);" /></td>
<td align="right"><asp:Button ID="submitbtn" runat="server" CssClass="button" Text="Submit" OnClick="submitbtn_Click" ValidationGroup="s" />
<asp:Button ID="cancelbtn" runat="server" CssClass="button" Text="Cancel" /></td>
</tr>
</table>
</td>
</tr>
</table>
<asp:HiddenField ID="hidden_sup" runat="server" Value="0" />
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
