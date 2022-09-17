<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthly_tds_challan1.aspx.cs"
    Inherits="payroll_admin_view_employee_tds" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax" style="left: 250px; top: 150px">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table width="718" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%" style="height: 16px">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01" style="height: 16px">
                                                        Monthly TDS Challan</td>
                                                </tr>
                                            </table>
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
                                                                    Monthly TDS Challan</td>
                                                                <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                    <span id="message" runat="server"></span>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="21%">
                                                                    Financial Year</td>
                                                                <td class="frm-rght-clr123" width="27%">
                                                                    <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="True" CssClass="select"
                                                                        DataTextField="year" DataValueField="year" OnSelectedIndexChanged="dd_year_SelectedIndexChanged"
                                                                        ToolTip="Financial Year" Width="129px">
                                                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                        ControlToValidate="dd_year" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                        ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                                <td class="frm-lft-clr123" width="23%">
                                                                    Month</td>
                                                                <td class="frm-rght-clr123" width="29%" colspan="2">
                                                                    &nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" DataTextField="month "
                                                                        DataValueField="month " ToolTip="Month" Width="129px" OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                                                    </asp:DropDownList><asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                        ToolTip="Select Month" ValidationGroup="submit"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="21%">
                                                                    Bank Name</td>
                                                                <td class="frm-rght-clr123" width="27%">
                                                                    <asp:DropDownList ID="ddl_bank_name" runat="server" CssClass="select" Width="131px"
                                                                        DataSourceID="SqlDataSource1" DataTextField="bankname" DataValueField="branchcode"
                                                                        OnDataBound="ddl_bank_name_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddl_bank_name_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="ddl_bank_name"
                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                        ToolTip="Select Employee Bank Name" ValidationGroup="v" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[bankname] as bankname FROM tbl_payroll_bank where tds=1">
                                                                    </asp:SqlDataSource>
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123" width="23%">
                                                                    BSR Code</td>
                                                                <td class="frm-rght-clr123" width="29%" colspan="2">
                                                                    &nbsp;<asp:TextBox ID="txt_bsr" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_bsr"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                        ToolTip="BSR Code" ValidationGroup="submit"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="23%">
                                                                    Branch Code</td>
                                                                <td class="frm-rght-clr123" width="29%" colspan="3">
                                                                    &nbsp;
                                                                    <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" Width="125px"
                                                                        Height="20px" DataSourceID="SqlDataSource2" DataTextField="branch_name" DataValueField="Branch_Id"
                                                                        OnDataBound="drp_comp_name_DataBound" OnSelectedIndexChanged="drp_comp_name_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
                                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                                        ToolTip="Select Branch Name"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="button" OnClick="btnsearch_Click" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top" colspan="4" class="txt02">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="27%" class="txt02" style="height: 13px">
                                                                                TDS Challan Details</td>
                                                                            <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                                <span id="Span1" runat="server"></span>&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="21%">
                                                                    Cheque/DD No.</td>
                                                                <td class="frm-rght-clr123" width="27%" colspan="4">
                                                                    <asp:TextBox ID="txt_no" runat="server" CssClass="input"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="21%">
                                                                    Tranfer Voucher No</td>
                                                                <td class="frm-rght-clr123" width="27%">
                                                                    <asp:TextBox ID="txt_vou" runat="server" CssClass="input"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_vou"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                        ToolTip="Select Month" ValidationGroup="submit"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                                <td class="frm-lft-clr123" width="23%">
                                                                    &nbsp;Tax Deposite Date</td>
                                                                <td class="frm-rght-clr123" colspan="2" width="29%">
                                                                    <asp:TextBox ID="txt_date" runat="server" CssClass="input"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_date"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                        ToolTip="Select Month" ValidationGroup="submit"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img" TargetControlID="txt_date">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                                    &nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" class="txt01">
                                                        DETAILS OF PAYMENT</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE2" onclick="return TABLE1_onclick()">
                                                            <tr>
                                                                <td class="head-2" valign="top">
                                                                    <asp:GridView ID="GridView1" runat="server" Width="100%" Font-Size="11px" Font-Names="Arial"
                                                                        CellSpacing="0" CellPadding="4" AutoGenerateColumns="False" BorderWidth="0px">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Income Tax">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("Tax") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Surcharge">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("Surcharge") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Education Cess">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("Cess") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("Total") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Button ID="Button2" runat="server" Text="Submit" CssClass="button" OnClick="Button1_Click"
                                                            ValidationGroup="submit" />&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt01" style="height: 15px" valign="top">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" class="txt01" style="height: 15px">
                                                        Tax Detail for the month (<asp:LinkButton ID="lnkbtnexcelexport" runat="server" CssClass="link05"
                                                            OnClick="lnkbtnexcelexport_Click">Click here to Export to Excel</asp:LinkButton>)</td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                                    <tr>
                                                                                        <td class="head-2" valign="top">
                                                                                            <div style="overflow: scroll; width: 709px; ">
                                                                                                <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                                                    CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="96%" AutoGenerateColumns="False"
                                                                                                    BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="NO TDS entry found for the month"
                                                                                                    OnPageIndexChanging="griddetail_PageIndexChanging1">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="Emp Code">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Branch">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="TDS Amount">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("tds_rupees") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Surcharge">
                                                                                                            <HeaderStyle Width="8%" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("surcharge") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Education Cess">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("education_cess") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Total Tax">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("total_tax") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                    <RowStyle Height="5px" />
                                                                                                    <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 18px">
                                                                                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="button" OnClick="Button1_Click" /></td>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkbtnexcelexport" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
