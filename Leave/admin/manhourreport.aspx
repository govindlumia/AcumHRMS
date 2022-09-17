<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manhourreport.aspx.cs" Inherits="leave_admin_manhourreport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title></title>
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
       <div style="overflow-x:hidden; overflow-y:scroll; height:520px; width:970px;">
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
    Man Hour Reports</td>
</tr>
</table></td>
</tr>
<tr>
<td height="5" valign="top"></td>
</tr>
<tr>
<td valign="top"><fieldset>
<legend><b>Report Criteria</b></legend>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td height="7"></td>
</tr>
<tr>
<td colspan="5" height="25" valign="top"><table width="100%" cellpadding="0" cellspacing="0">
<tr>
<td width="25%" align="left" style="height: 20px"></td>
<td align="right" width="75%" style="height: 20px"><a class="txt-red" href="leaveadmin.aspx" target="name123">Back</a></td>
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
<div id="template" runat="server">
<table width="100%" cellpadding="0" cellspacing="0">
<tr><td colspan="2">&nbsp;</td></tr>
<tr><td valign="middle" class="frm-lft-clr123" width="17%">Select Branch</td>
<td><asp:DropDownList ID="dd_branch" runat="server" CssClass="select2" DataSourceID="SqlDataSource1"
        DataTextField="branch_name" DataValueField="Branch_Id" OnDataBound="dd_branch_DataBound" AutoPostBack="true" Width="150px">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
    </asp:SqlDataSource></td>
</tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td valign="middle" class="frm-lft-clr123" width="17%">Select Department</td>
<td colspan="4" valign="top" class="frm-rght-clr123" width="83%">
    <asp:DropDownList ID="dd_dept" runat="server" CssClass="select2" DataSourceID="SqlDataSource2"
        DataTextField="department_name"  DataValueField="departmentid" OnDataBound="dd_dept_DataBound" Width="150px">
    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name">
        <SelectParameters>
            <asp:ControlParameter ControlID="dd_branch" DefaultValue="0" Name="branch" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource></td>
</tr>
</table>
</div>
</td>
</tr>
<tr><td colspan="2">&nbsp;</td></tr>
<tr>
<td colspan="5" valign="top" style="height: 18px">
    <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click" Text="View" ValidationGroup="c" />
    <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click" Text="Reset" ValidationGroup="c" /></td>
</tr>
</table>
</fieldset></td>
</tr>
<tr>
<td valign="top">&nbsp;<asp:GridView ID="attendancegrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" Font-Names="Arial" Font-Size="11px"
                Width="100%" AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found" OnPageIndexChanging="attendancegrid_PageIndexChanging" OnRowDataBound="attendancegrid_RowDataBound">
                <Columns>
                
                    <asp:TemplateField HeaderText="Department Name">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("deptname") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Emp Worked Hrs">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("employeeworkhours") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Good Work Reward Hrs">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("othour") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Casual Hrs">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l4" runat="server"  Text='<%# Bind("casualhr")%>'></asp:Label>
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
<td valign="top" align="right"><a class="txt-red" href="leaveadmin.aspx" target="name123">Back</a></td>
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
