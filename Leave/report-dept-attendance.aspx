<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-dept-attendance.aspx.cs" Inherits="leave_report_dept_attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Leave Report</title>
<script language="Javascript" type="text/javascript" src="../FusionChat/FusionCharts.js">
    </script>

<script type="text/javascript" src="js/popup.js"></script>
<style type="text/css" media="all">
@import "css/blue1.css";
absolute
.disp {
 display:none;
}
.pop2 {
  position:absolute; background-color: #fff; z-index:1002; overflow: auto; padding:0px; left:240px; top:38%;width:500px;
}
fieldset {
 margin:0; padding:0; border: 1px solid #c9dffb; padding:0 7px 10px 7px;
}
legend {
 font: 12px Arial, Helvetica, sans-serif; color:#08486d; padding-bottom: 0px; padding-top: 2px;
}
.divajaxpage {
width:120px; height:32px; background-color:#fff;z-index:1004; position:absolute; top:37%; left:40%; padding: 30px; border: 5px solid #9dbde4;
}

</style>
    
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
     <%-- <asp:ScriptManager id="leaveapply" runat="server">
    </asp:ScriptManager>--%>
<%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>

             <div class="divajaxpage">
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
    <div class="header">

<div style="overflow-x:scroll; overflow-y:scroll; height:700px; width:968px;">

<table width="98%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="950" valign="top" class="blue-brdr-1"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
<td width="97%" class="txt01">Reports</td>
</tr>
</table></td>
</tr>
<tr>
<td height="5" valign="top"></td>
</tr>
<tr>
<td valign="top"><fieldset>
<legend><b>Categorywise Attendance Report</b></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="7"></td>
</tr>
<tr>
<td colspan="5" height="25" valign="top"><table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td width="88%" align="left"><asp:CheckBox ID="chk_temp" AutoPostBack="true" runat="server" Text="Template" OnCheckedChanged="chk_temp_CheckedChanged" /></td>
<td align="center" width="12%"><%--<a class="txt-red" href="admin\leaveadmin.aspx" target="name123">--%></td>
</tr>
</table></td>
</tr>
<tr><td>
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Select Company<span style="color:red">*</span></td>
<td colspan="4" valign="top" class="frm-rght-clr123" width="83%">
    <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" Height="20px" Width="145px">
    </asp:DropDownList>
      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
        ErrorMessage="CompareValidator" Operator="NotEqual" ToolTip="Select Category Name"
        ValidationGroup="c" ValueToCompare="0"><img src="../images/../images/error1.gif" alt="" /></asp:CompareValidator>
    <span style="padding-left:100px">
    <asp:CheckBox runat="server" ID="chk_empstatus" Text="Include Past Employees" Checked="false" />
    </span>

  
    
</td>
</tr>
</table>
</td>

</tr>
<tr>
<td colspan="5">
<div id="date" runat="server" visible="true">

<table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">From Date<span style="color:red">*</span></td>
<td valign="top" class="frm-rght-clr123" width="19%">
    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select"></asp:TextBox>
    <asp:ImageButton ID="img_f" runat="server" ImageUrl="../leave/images/clndr.gif"
      ToolTip="Click to open/close calender" />
    <%--<asp:Image ID="img_f" runat="server" ImageUrl="../leave/images/clndr.gif" />--%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>&nbsp;
<%--    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage="Check date format(dd-MMM-yyyy)" Operator="DataTypeCheck" Type="Date"
        ValidationGroup="c" ValueToCompare="dd-MMM-yyyy"></asp:CompareValidator>--%>
    <ajaxToolkit:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="dd-MMM-yyyy" Enabled="true"></ajaxToolkit:CalendarExtender>
</td>
<td width="1%" valign="top">&nbsp;</td>
<td width="17%" valign="middle" class="frm-lft-clr123" >To Date<span style="color:red">*</span></td>
<td width="46%" valign="top" class="frm-rght-clr123" >
    <asp:TextBox ID="txt_edate" runat="server" CssClass="select"></asp:TextBox>
     <asp:ImageButton ID="img_e" runat="server" ImageUrl="../leave/images/clndr.gif"
      ToolTip="Click to open/close calender" />
   <%-- <asp:Image ID="img_e" runat="server" ImageUrl="../leave/images/clndr.gif" />--%>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
   <%-- <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_edate"
        ErrorMessage="Check date format(dd-MMM-yyyy)" Operator="DataTypeCheck" Type="Date"
        ValidationGroup="c" ValueToCompare="dd-MMM-yyyy"></asp:CompareValidator>--%>
    <ajaxToolkit:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" 
    TargetControlID="txt_edate" Format="dd-MMM-yyyy" Enabled="true"></ajaxToolkit:CalendarExtender>
</td></tr>
</table>
</div>
<div id="template" runat="server" visible="false">
<table width="100%" cellpadding="0" cellspacing="0">
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Select Template</td>
<td colspan="4" valign="top" class="frm-rght-clr123" width="83%"><asp:DropDownList ID="drp_template" runat="server" CssClass="select"
         Width="200px">
    <asp:ListItem Selected="True" Value="0">Current Week</asp:ListItem>
    <asp:ListItem Value="1">Last Week</asp:ListItem>
    <asp:ListItem Value="2">Current Month</asp:ListItem>
    <asp:ListItem Value="3">Last Month</asp:ListItem>
</asp:DropDownList></td>
</tr>
</table>
</div>
</td>
</tr>
<tr>
<td colspan="5" style="height: 7px"></td>
</tr>
<tr><td>&nbsp;<asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_OnClick" Text="Search" ValidationGroup="c" />
    <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" ValidationGroup="c" OnClick="btn_reset_Click" />
    <input class="button" value="Back" style="text-align:center;" onclick="window.location='admin/leaveadmin.aspx'" /></td></tr>
<tr>
<td colspan="5" valign="top" style="height: 7px">
    &nbsp;</td>
</tr>
<tr>
<td colspan="5" valign="top">
    <asp:GridView ID="manhourgrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" Font-Names="Arial" Font-Size="11px"
                Width="60%" PageSize="100" EmptyDataText="Sorry no record found" OnRowDataBound="manhourgrid_RowDataBound">
                <Columns>
                
                    <asp:TemplateField HeaderText="Category Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("Category_name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("total") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Present">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("present") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Absent">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("absent")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Percent">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("Percentage")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                 
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView></td>
</tr>
<tr>
<td colspan="5" style="height: 7px"></td>
</tr>
<tr>
<td colspan="5" valign="top" style="height: 13px">
    &nbsp;<asp:Literal ID="CLiteral" runat="server"></asp:Literal></td>
</tr>

</table>
</fieldset></td>
</tr>
<tr>
<td valign="top" style="height: 14px">&nbsp;
</td>
</tr>
<tr>
<td valign="top" align="center">
<table width="100%" border="0">
<tr>
<td width="88%" align="left">&nbsp;</td>
<td align="center" width="12%" ></td>
</tr>
</table>

</td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>

</div></div>
<%--</ContentTemplate>                                     
    </asp:UpdatePanel>--%>
    
    </form>
</body>
</html>
