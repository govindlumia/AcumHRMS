<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-manhour.aspx.cs" Inherits="leave_report_manhour" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>KOD Intranet</title>
<script type="text/javascript" src="js/popup.js"></script>
<script language="Javascript" type="text/javascript" src="../FusionChat/FusionCharts.js">
    </script>
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
      <asp:ScriptManager id="leaveapply" runat="server">
    </asp:ScriptManager>
<%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
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
        </asp:UpdateProgress>--%> <div class="header">
        <div style="overflow-x:scroll; overflow-y:scroll; height:530px; width:1000px;">
        <table width="98%" border="0" cellspacing="0" cellpadding="0">
            <tr>
            <td class="blue-brdr-1" valign="top" height=502>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
            <td valign="top">
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
            <td class="blue-brdr-1" valign="top">
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
            <tr>
            <td width="0%" style="height: 19px">
            <img height="16" src="images/employee-icon.jpg" width="16" />
            </td>
            <td class="txt01" width="100%" style="height: 19px" align="left">Reports</td>
            </tr>
            </table>
            </td>
            </tr>
            <tr>
            <td valign="top" height="5">
            </td></tr><tr><td valign="top"><fieldset><LEGEND><b>Man Hour Report</b></LEGEND><table cellSpacing=0 cellPadding=0 width="100%" border=0><tr><td height=7></td></tr><tr><td valign="top" colspan=5 height=25><table cellSpacing=0 cellPadding=0 width="100%"><tr><td align=left width="25%"><asp:CheckBox id="chk_temp" runat="server" OnCheckedChanged="chk_temp_CheckedChanged" Text="Template" AutoPostBack="true"></asp:CheckBox></td><td align=right width="75%">
                &nbsp;</td></tr></table></td></tr><tr><td><table cellSpacing=0 cellPadding=0 width="100%"><tr><td class="frm-lft-clr123" valign=middle width="17%">Select Branch</td><td class="frm-rght-clr123" valign="top" width="83%" colspan=4><asp:DropDownList id="drp_comp_name" runat="server" CssClass="blue1" Width="145px" OnDataBound="drp_comp_name_DataBound" Height="20px" DataValueField="Branch_Id" DataTextField="branch_name" DataSourceID="SqlDataSource1">
    </asp:DropDownList> <asp:CompareValidator id="CompareValidator1" runat="server" ValidationGroup="c" ErrorMessage="CompareValidator" ControlToValidate="drp_comp_name" ValueToCompare="0" ToolTip="Select Branch Name" Operator="NotEqual"><img src="../images/../images/error1.gif" alt="" /></asp:CompareValidator> <asp:SqlDataSource id="SqlDataSource1" runat="server" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>">
    </asp:SqlDataSource> </td></tr></table></td></tr><tr><td colspan=5><div id="date" runat="server" visible="true"><table id="table1" cellspacing="0" cellPadding="0" width="100%"><tr><td class="frm-lft-clr123" valign=middle width="17%">From Date</td><td class="frm-rght-clr123" valign="top" width="19%"><asp:TextBox id="txt_sdate" runat="server" CssClass="select"></asp:TextBox> <asp:Image id="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif"></asp:Image> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ValidationGroup="c" ErrorMessage='<img src="../images/error1.gif" alt="" />' ControlToValidate="txt_sdate"></asp:RequiredFieldValidator> 
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
            ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
            ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
        <cc1:CalendarExtender id="cextender" runat="server" TargetControlID="txt_sdate" PopupButtonID="img_f" Format="MM/dd/yyyy"></cc1:CalendarExtender> </td><td valign="top" width="1%">&nbsp;</td><td class="frm-lft-clr123" valign=middle width="17%">To Date</td><td class="frm-rght-clr123" valign="top" width="46%"><asp:TextBox id="txt_edate" runat="server" CssClass="select"></asp:TextBox> <asp:Image id="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif"></asp:Image> <asp:RequiredFieldValidator id="RequiredFieldValidator11" runat="server" ValidationGroup="c" ErrorMessage='<img src="../images/error1.gif" alt="" />' ControlToValidate="txt_edate"></asp:RequiredFieldValidator> 
    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_edate"
        ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
        ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
    <cc1:CalendarExtender id="cextender1" runat="server" TargetControlID="txt_edate" PopupButtonID="img_e" Format="MM/dd/yyyy"></cc1:CalendarExtender> </td></tr></table></div><div id="template" runat="server" visible="false"><table cellSpacing=0 cellPadding=0 width="100%"><tr><td class="frm-lft-clr123" valign=middle width="17%">Select Template</td><td class="frm-rght-clr123" valign="top" width="83%" colspan=4><asp:DropDownList id="drp_template" runat="server" CssClass="select" Width="200px">
    <asp:ListItem Selected="True" Value="0">Current Week</asp:ListItem>
    <asp:ListItem Value="1">Last Week</asp:ListItem>
    <asp:ListItem Value="2">Current Month</asp:ListItem>
    <asp:ListItem Value="3">Last Month</asp:ListItem>
</asp:DropDownList></td></tr></table></div></td></tr><tr><td style="HEIGHT: 14px" align="right">&nbsp;</td></tr><tr><td valign="top" colspan=5 style="height: 18px"><asp:Button id="Button1" onclick="btn_search_OnClick" runat="server" Text="Search" CssClass="button" ValidationGroup="c"></asp:Button> <asp:Button id="Button2" onclick="btn_reset_Click" runat="server" Text="Reset" CssClass="button"></asp:Button>&nbsp;<input class="button" value="Back" style="text-align:center;" onclick="window.location='admin/leaveadmin.aspx'" /></td></tr><tr><td style="HEIGHT: 14px">&nbsp;</td></tr><tr><td colspan=5 height=7 align="left">
<asp:GridView id="manhourgrid" runat="server" Width="60%" OnRowDataBound="manhourgrid_RowDataBound" OnPageIndexChanging="manhourgrid_PageIndexChanging" EmptyDataText="Sorry no record found" PageSize="50" Font-Size="11px" Font-Names="Arial" CellSpacing="0" CellPadding="4" BorderWidth="0px" AutoGenerateColumns="False">
<FooterStyle CssClass="frm-lft-clr123"></FooterStyle>
<Columns>
<asp:TemplateField HeaderText="Department Name">
<ItemStyle Width="25%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
<ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Emp Worked Hrs">
<ItemStyle Width="25%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
<ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("Per_Hour") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Good Work Reward Hrs">
<ItemStyle Width="25%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
<ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("Ot_hour") %>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Casual Hrs">
<ItemStyle Width="25%" CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
<ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("Cas_Hours")%>'></asp:Label>
                        
</ItemTemplate>
</asp:TemplateField>
</Columns>

<RowStyle Height="5px"></RowStyle>

<HeaderStyle CssClass="frm-lft-clr123"></HeaderStyle>
</asp:GridView>
</td>
</tr>
<tr>
<td style="HEIGHT: 7px" colspan="5"></td></tr><tr><td style="HEIGHT: 14px" valign="top" colspan="5">&nbsp;<asp:Literal id="CLiteral" runat="server"></asp:Literal></td></tr></table></fieldset></td></tr><tr><td valign="top">&nbsp; </td></tr></table></td></tr></table></td></tr></table></div>

</div>
<%--</ContentTemplate>                                     
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
