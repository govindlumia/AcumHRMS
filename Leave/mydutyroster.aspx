<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mydutyroster.aspx.cs" Inherits="leave_mydutyroster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

    <title>Acuminous Software.</title>

<style type="text/css" media="all">
@import "../css/blue1.css";
@import "../css/example.css";
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
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
<div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>


<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
        <ProgressTemplate>
            <div class="divajax">
                &nbsp;<table width="100%">
            <tr>
            <td align="center" valign="top"><img src="../images/loading.gif" /></td>
            </tr>
            <tr>
            <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
            </tr>
            </table></div>
        </ProgressTemplate> 
    </asp:UpdateProgress>



<div style="overflow-x:hidden; overflow-y:scroll; height:524px; width:100%;">       
       
<table width="98%" border="0" cellpadding="0" cellspacing="0">



<tr>
<td colspan="6" height="25" valign="top">
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td width="25%" class="txt01" align="left" style="height: 20px">
    &nbsp;My Duty Roaster</td>
<td align="right" width="75%" style="height: 20px"><asp:CheckBox ID="Chk_holiday" AutoPostBack="true" runat="server" Text="Holidays" OnCheckedChanged="Chk_holiday_CheckedChanged" Visible="False"/>
    <asp:CheckBox ID="chk_temp" AutoPostBack="true" runat="server" Text="Template" OnCheckedChanged="chk_temp_CheckedChanged" Visible="False"/></td>
</tr>
</table>
</td>
</tr>

<tr>
<td colspan="6">
<div id="date" runat="server" visible="true">
<table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
<tr>

<td width="15%" class="frm-lft-clr123">From Date<span class="mandatory">*</span> </td>

<td width="20%" class="frm-rght-clr123" valign="top"><asp:TextBox ID="txt_sdate" runat="server" CssClass="blue1" Width="100px" OnChange="checkStartdate()"></asp:TextBox>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_sdate"
        Display="Dynamic" SetFocusOnError="True" ToolTip="From Date" ValidationGroup="s"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txt_sdate" FirstDayOfWeek="Monday"></cc1:CalendarExtender>
    </td>
<td width="1%">&nbsp;</td>    
<td width="12%" class="frm-lft-clr123">To Date</td>
<td width="52%" class="frm-rght-clr123"><asp:TextBox ID="txt_edate" runat="server" CssClass="blue1" Width="100px" onChange="checkEnddate()"></asp:TextBox>
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
        Display="Dynamic" SetFocusOnError="True" ToolTip="To Date" ValidationGroup="s"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
    <asp:HiddenField ID="HiddenField2" runat="server" />
   <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClick="btnsearch_Click" Text="Search" ValidationGroup="s" /> 
   <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2" TargetControlID="txt_edate"></cc1:CalendarExtender>
</td>

</tr>
    <tr>
        <td class="frm-lft-clr123" width="15%">
        </td>
        <td class="frm-rght-clr123" valign="top" width="20%">
        </td>
        <td width="1%">
        </td>
        <td class="frm-lft-clr123" width="12%">
        </td>
        <td class="frm-rght-clr123" width="52%">
        </td>
    </tr>

</table>
</div>
</td>
</tr>

<tr>


<td colspan="6" style="height:7px">

</td>

</tr>

<tr>
<td colspan="6">


<div id="holiday" runat="server" visible="false">
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Select Holidays off </td>
<td colspan="4" valign="middle" class="frm-rght-clr123" width="83%"><asp:DropDownList ID="drp_holiday" runat="server" CssClass="select"
  Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drp_holiday_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="0">C-off</asp:ListItem>
    <asp:ListItem Value="1">H-off</asp:ListItem>
    <asp:ListItem Value="2">w-off</asp:ListItem>
    </asp:DropDownList></td>
    </tr>
    </table>
    </div>
    
    </td>
    
    </tr>
    
    
    <tr>
    
    <td colspan="6">
    
<div id="template" runat="server" visible="false">
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Select Template</td>
<td colspan="4" valign="middle" class="frm-rght-clr123" width="83%"><asp:DropDownList ID="drp_template" runat="server" CssClass="select"
  Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drp_template_SelectedIndexChanged">
    <asp:ListItem Selected="True" Value="0">Current Week</asp:ListItem>
    <asp:ListItem Value="1">Next Week</asp:ListItem>
    <asp:ListItem Value="2">Current Month</asp:ListItem>
    <asp:ListItem Value="3">Next Month</asp:ListItem>
    <asp:ListItem Value="4">Current Year</asp:ListItem>
    <asp:ListItem Value="5">Next Year</asp:ListItem>
</asp:DropDownList></td>
</tr>
</table>
</div>

</td>
</tr>


<tr>
<td colspan="6" height="10"></td>
</tr>
<tr>
<td colspan="6" class="head-2">
<div id="divgrid" runat="server">
<asp:GridView ID="empdutyrosterdetails" runat="server" DataKeyNames="DATE" Font-Size="11px" Font-Names="Arial" Width="100%" AllowPaging="True" CellPadding="0" AllowSorting="True" BorderStyle="None" BorderWidth="0px" AutoGenerateColumns="False" OnPageIndexChanging="empdutyrosterdetails_PageIndexChanging" PageSize="50">

<FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
<RowStyle ForeColor="#000066" HorizontalAlign="Left"></RowStyle>

<Columns>
                                                               
<asp:BoundField DataField="DATE" HeaderText="Date">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>
<asp:BoundField DataField="EMPCODE" HeaderText="EmpCode">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>  
<asp:BoundField DataField="DAYS" HeaderText="Week Days">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>
<asp:BoundField DataField="SHIFT" HeaderText="Shift">
<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/> 
<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234" Width="20%"/> 
</asp:BoundField>

</Columns>
<PagerStyle HorizontalAlign="Center" BackColor="White" ForeColor="#000066"></PagerStyle>
<EmptyDataTemplate>
<span style="text-align:center">Sorry! No Records Found</span>
</EmptyDataTemplate>
<SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
<HeaderStyle Wrap="True" BackColor="#006699" CssClass="link05" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
<PagerSettings PageButtonCount="30" Position="TopAndBottom" />
</asp:GridView>
</div>
<div id="divmessage" runat="server"><asp:Label ID="lblmessage" runat="server" Text="Label"></asp:Label></div>
</td>
</tr>
</table>
</div>  
</ContentTemplate>  
</asp:UpdatePanel>
</div>
 
    </form>

</body>

</html>
