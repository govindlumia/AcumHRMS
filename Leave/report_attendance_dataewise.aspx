<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report_attendance_dataewise.aspx.cs" Inherits="leave_report_leaveregister" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Attendance Report</title>
<script type="text/javascript" language="javascript" src="../js/popup.js"></script>
<style type="text/css" media="all">
@import "../css/blue1.css";
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
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
        </asp:UpdateProgress>
       <div style="overflow-x:hidden; overflow-y:scroll; height:520px; width:750px;">
    <div class="header">

<table width="98%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="502" valign="top" class="blue-brdr-1"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td width="3%" style="height: 16px"><img src="../images/employee-icon.jpg" width="16" height="16" /></td>
<td width="97%" class="txt01" style="height: 16px">
    Attendance</td>
</tr>
</table></td>
</tr>
<tr>
<td height="5" valign="top"></td>
</tr>
<tr>
<td valign="top"><fieldset>
<legend><b>Search Attendence</b></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="7"></td>
</tr>
<tr>
<td colspan="5" height="25" valign="top"></td>
</tr>
<tr>
<td colspan="5">
<div id="date" runat="server" visible="true">
<table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">From Date<span style="color:red">*</span></td>
<td valign="top" class="frm-rght-clr123" width="19%">
    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate"></cc1:CalendarExtender>
</td>
<td width="1%" valign="top">&nbsp;</td>
<td width="17%" valign="middle" class="frm-lft-clr123" >To Date<span style="color:red">*</span></td>
<td width="46%" valign="top" class="frm-rght-clr123" >
    <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
    <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate"></cc1:CalendarExtender>
</td></tr>
</table>
</div>
<div id="template" runat="server" visible="false">
</div>
</td>
</tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td colspan="5" valign="top" style="height: 18px">
    <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click" Text="Search" ValidationGroup="c" />
    </td>
</tr>
    <tr>
        <td colspan="5" style="height: 18px" valign="top">
        </td>
    </tr>
</table>
</fieldset></td>
</tr>
<tr>
<td valign="top" align="left">&nbsp;<asp:GridView ID="attendancegrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" Font-Names="Arial" Font-Size="11px"
                Width="100%" AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found" OnPageIndexChanging="attendancegrid_PageIndexChanging" OnRowDataBound="attendancegrid_RowDataBound">
                <Columns>
                  <asp:TemplateField HeaderText="Date">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("date")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Day">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("dayofweek")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mode">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("mode")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                   
                    
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
</td>
</tr>

</table></td>
</tr>
</table></td>
</tr>
</table>
</div>
 </div>
</ContentTemplate>                                     
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
