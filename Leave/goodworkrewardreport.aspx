<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goodworkrewardreport.aspx.cs" Inherits="leave_goodworkrewardreport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<%--<title>Acuminous Software Intranet</title>--%>
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
    <form id="form1" runat="server" defaultbutton="btn_search">
      <asp:ScriptManager id="leaveapply" runat="server">
    </asp:ScriptManager>
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
    <div class="header">

<div style="overflow-x:hidden; overflow-y:scroll; height:512px; width:968px;">
<table width="718" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="502" valign="top" class="blue-brdr-1"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td valign="top" class="blue-brdr-1"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td width="3%"><img src="images/employee-icon.jpg" width="16" height="16" /></td>
<td width="97%" class="txt01">Good Work Reward Reports</td>
</tr>
</table></td>
</tr>
<tr>
<td height="5" valign="top"></td>
</tr>
<tr>
<td valign="top"><fieldset>
<legend><b>Search Good Work Reward Criteria</b></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="7"></td>
</tr>
<tr>
<td colspan="5" height="25" valign="top"><table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td width="25%" align="left"><asp:CheckBox ID="chk_temp" AutoPostBack="true" runat="server" Text="Template" OnCheckedChanged="chk_temp_CheckedChanged" /></td>
<td align="right" width="75%"><a class="txt-red" href="admin\leaveadmin.aspx" target="name123">Back</a></td>
</tr>
</table></td>
</tr>
<tr>
<td colspan="5">
<div id="date" runat="server" visible="true">
<table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">From Date</td>
<td valign="top" class="frm-rght-clr123" width="19%">
    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate"></cc1:CalendarExtender>
</td>
<td width="1%" valign="top">&nbsp;</td>
<td width="17%" valign="middle" class="frm-lft-clr123" >To Date</td>
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
<table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Select Template</td>
<td colspan="4" valign="top" class="frm-rght-clr123" width="83%"><asp:DropDownList ID="drp_template" runat="server" CssClass="select"
        DataTextField="department_name"  DataValueField="departmentid" OnDataBound="dd_dept_DataBound" Width="200px">
    <asp:ListItem Selected="True" Value="0">Current Week</asp:ListItem>
    <asp:ListItem Value="1">Last Week</asp:ListItem>
    <asp:ListItem Value="2">Next Week</asp:ListItem>
    <asp:ListItem Value="3">Current Month</asp:ListItem>
    <asp:ListItem Value="4">Last Month</asp:ListItem>
    <asp:ListItem Value="5">Next Month</asp:ListItem>
</asp:DropDownList></td>
</tr>
</table>
</div>
</td>
</tr>
<tr>
<td colspan="5" height="7"></td>
</tr>
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Emp Name</td>
<td width="19%" valign="top" class="frm-rght-clr123">
    &nbsp;<asp:TextBox ID="txt_empcode" runat="server" CssClass="input"></asp:TextBox>
</td>
<td valign="top" width="1%">&nbsp;</td>
<td width="17%" valign="middle" class="frm-lft-clr123">Department</td>
<td width="46%" valign="middle" class="frm-rght-clr123">
    <asp:DropDownList ID="dd_dept" runat="server" CssClass="select2" DataSourceID="SqlDataSource2"
        DataTextField="department_name"  DataValueField="departmentid" OnDataBound="dd_dept_DataBound" Width="150px">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid],department_name FROM [tbl_internate_departmentdetails] order by department_name">
        <%--<SelectParameters>
            <asp:ControlParameter ControlID="dd_branch" DefaultValue="0" Name="branch" PropertyName="SelectedValue" />
        </SelectParameters>--%>
    </asp:SqlDataSource>
</td>
</tr>
<tr>
<td colspan="5" height="7"></td>
</tr>
<tr>
<td colspan="5" valign="top">
    <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click" Text="Search" ValidationGroup="c" />
    <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click" Text="Reset" ValidationGroup="c" /></td>
</tr>
</table>
</fieldset></td>
</tr>
<tr>
<td valign="top">&nbsp;<asp:GridView ID="empleavegrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BorderWidth="0px" CellPadding="4" CellSpacing="0" DataKeyNames="empcode" EmptyDataText="No employee leave data found!"
        Font-Names="Arial" Font-Size="11px" OnPageIndexChanging="empleavegrid_PageIndexChanging" PageSize="50"
        Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Emp Code">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="10%" />
                <ItemTemplate>
                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Emp Name">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="20%" />
                <ItemTemplate>
                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Department">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="20%" />
                <ItemTemplate>
                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="No. of hours">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                    Width="20%" />
                <ItemTemplate>
                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("hours") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             
        </Columns>
        <HeaderStyle CssClass="frm-lft-clr123" />
        <FooterStyle CssClass="frm-lft-clr123" />
        <RowStyle Height="5px" />
    </asp:GridView>
</td>
</tr>
<tr>
<td valign="top" align="right"><a class="txt-red" href="admin\leaveadmin.aspx" target="name123">Back</a></td>
</tr>
</table></td>
</tr>
</table></td>
</tr>
</table>
</div></div>
</ContentTemplate>                                     
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
