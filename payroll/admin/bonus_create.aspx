<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bonus_create.aspx.cs" Inherits="payroll_admin_bonus_create" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Information</title>
    <style type="text/css" media="all">
    @import "../../css/blue1.css";
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:ScriptManager ID="bank" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        <table width="718" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" height="463px">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%" style="height: 16px">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01" style="height: 16px">
                                            Create Employee Bonus</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 5px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="14%">
                                            Financial Year</td>
                                        <td class="frm-rght-clr123" width="10%">
                                            <asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td class="frm-lft-clr123" width="14%">
                                            Month to be Given</td>
                                        <td class="frm-rght-clr123" colspan="3">
                                            <asp:DropDownList ID="dd_month" runat="server" CssClass="select" DataTextField="month "
                                                DataValueField="month " ToolTip="Month" Width="145px">
                                                <asp:ListItem>Apr</asp:ListItem>
                                                <asp:ListItem>May</asp:ListItem>
                                                <asp:ListItem>Jun</asp:ListItem>
                                                <asp:ListItem>Jul</asp:ListItem>
                                                <asp:ListItem>Aug</asp:ListItem>
                                                <asp:ListItem>Sep</asp:ListItem>
                                                <asp:ListItem>Oct</asp:ListItem>
                                                <asp:ListItem>Nov</asp:ListItem>
                                                <asp:ListItem>Dec</asp:ListItem>
                                                <asp:ListItem>Jan</asp:ListItem>
                                                <asp:ListItem>Feb</asp:ListItem>
                                                <asp:ListItem>Mar</asp:ListItem>
                                            </asp:DropDownList><asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                ToolTip="Select Month" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="6">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="14%">
                                            Percent</td>
                                        <td class="frm-rght-clr123" width="15%">
                                            <asp:TextBox ID="txt_bonus_percent" runat="server" CssClass="input" Width="58px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_bonus_percent"
                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Range between 0 and 100"
                                                MaximumValue="100" MinimumValue="0" Type="Double" ValidationGroup="v" ControlToValidate="txt_bonus_percent"></asp:RangeValidator></td>
                                        <td class="frm-lft-clr123" width="14%%">
                                            &nbsp;</td>
                                        <td class="frm-rght-clr123" colspan="3" width="20%">
                                            <%--Branch<asp:DropDownList ID="ddlbranch" runat="server"  Width="143px" DataSourceID="SqlDataSource2" DataTextField="branch_name" DataValueField="branch_id" ToolTip="Select Branch of the Company" CssClass="select" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">For All Branch</asp:ListItem>
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>" 
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                            </asp:SqlDataSource>--%>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" style="height: 5px">
                            </td>
                        </tr>
                        <tr>
                            <td height="5" align="right" valign="top">
                                &nbsp;<asp:Button ID="btnsv" runat="server" CssClass="button" OnClick="btnsv_Click"
                                    Text="Calculate" ValidationGroup="v" />
                                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                    Text="Reset" />
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" valign="top" class="txt02">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="27%" class="txt02" style="height: 13px">
                                                        Bonus Detail</td>
                                                    <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                        <span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="head-2" valign="top">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                        runat="server">
                                                        <ProgressTemplate>
                                                            <div class="divajax" style="top: 160px;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img alt="" src="../../images/loading.gif" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="bottom" align="center" class="txt01">
                                                                            Please Wait...</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:GridView ID="adjustgridview" runat="server" Font-Size="11px" Font-Names="Arial"
                                                        CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No previous year data found !"
                                                        DataKeyNames="empcode,year" OnPageIndexChanging="adjustgridview_PageIndexChanging"
                                                        PageSize="40" AllowSorting="True" OnSorting="adjustgridview_Sorting" AllowPaging="True">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Emp Code" SortExpression="empcode">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Name" SortExpression="empname">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="28%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bonus Amount">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("bonus_amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Percent(%)">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("interest") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bonus">
                                                                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                        <PagerSettings Position="TopAndBottom" />
                                                    </asp:GridView>
                                                    &nbsp;<br />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
