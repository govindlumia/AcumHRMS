<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthly_tds_challan_view.aspx.cs"
    Inherits="payroll_admin_monthly_tds_challan_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>YKK Employee Information</title>
    <style type="text/css" media="all">

@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="bank" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" alt="" /></td>
                                    <td valign="bottom">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
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
                                                    <img src="../../images/employee-icon.jpg" alt="" width="16" height="16" /></td>
                                                <td class="txt01" style="height: 16px">
                                                    Monthly TDS Challan
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" width="21%">
                                                    Financial Year&nbsp;</td>
                                                <td class="frm-rght-clr123" width="27%" colspan="0">
                                                    <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="True" CssClass="select"
                                                        DataTextField="year" DataValueField="year" OnSelectedIndexChanged="dd_year_SelectedIndexChanged"
                                                        ToolTip="Financial Year" Width="129px" OnDataBound="dd_year_DataBound">
                                                    </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                        ControlToValidate="dd_year" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="frm-lft-clr123" width="23%">
                                                    Month</td>
                                                <td class="frm-rght-clr123" width="29%" colspan="2">
                                                    &nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" DataTextField="month "
                                                        DataValueField="month " ToolTip="Month" Width="129px" OnDataBound="dd_month_DataBound">
                                                    </asp:DropDownList><asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Select Month" ValidationGroup="submit"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="21%">
                                                    Cost Center</td>
                                                <td class="frm-rght-clr123" width="27%">
                                                    &nbsp;<asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" Width="125px"
                                                        Height="20px" DataSourceID="SqlDataSource2" DataTextField="cost_center_name"
                                                        DataValueField="cost_center" OnDataBound="drp_comp_name_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                        ToolTip="Select Cost Center"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT cost_center,cost_center_name FROM tbl_payroll_costcenter ORDER BY cost_center_name">
                                                    </asp:SqlDataSource>
                                                </td>
                                                <td class="frm-rght-clr123" colspan="3">
                                                    <asp:Button ID="btnsearch" runat="server" CssClass="button" OnClick="btnsearch_Click"
                                                        Text="Search" ToolTip="Search" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" align="right" height="5" valign="bottom">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="20" valign="top" class="txt02">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="27%" class="txt02">
                                                                View Monthly TDS Challan
                                                            </td>
                                                            <td width="73%" align="right" class="txt-red">
                                                                <span id="message" runat="server"></span>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-2">
                                                    <asp:GridView ID="payheadgird" runat="server" Font-Size="11px" Font-Names="Arial"
                                                        CellPadding="4" DataKeyNames="challan_no" Width="100%" AutoGenerateColumns="False"
                                                        BorderWidth="0px" EmptyDataText="Sorry no record found" 
                                                        AllowPaging="True" PageSize="30" OnRowCommand="payheadgird_RowCommand" OnPageIndexChanging="payheadgird_PageIndexChanging">
                                                        <Columns>
                                                            <asp:BoundField DataField="challan_no" HeaderText="Challan No" SortExpression="challan_no">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="financial_year" HeaderText="Financial Year" SortExpression="financial_year">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="month" HeaderText="Month" SortExpression="month">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="cost_center_name" HeaderText="Cost Center" SortExpression="cost_center_name">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="20%" />
                                                                <ItemTemplate>
                                                                    <%--<a class="link05" href="monthly_tds_challan_payment.aspx?challan_no=<%#DataBinder.Eval(Container.DataItem, "challan_no")%>" target="_self">Payment</a>--%>
                                                                    <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'
                                                                        CommandName="Edit" CssClass="link05" Text="Edit  " Enabled='<%#Bind("status")%>'
                                                                        ToolTip="Edit" />
                                                                    |
                                                                    <asp:LinkButton ID="lnkbtnpayment" runat="server" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'
                                                                        CommandName="Payment" CssClass="link05" Text="Payment  " Enabled='<%#Bind("status")%>'
                                                                        ToolTip="Payment" />
                                                                    |
                                                                    <asp:LinkButton ID="lnkbtnpaymentview" runat="server" CausesValidation="false" CommandArgument='<%# Container.DataItemIndex %>'
                                                                        CommandName="Paymentview" CssClass="link05" Text="  View" ToolTip="View" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        SelectCommand="select challan_no,financial_year,month,ch.status,c.cost_center_name
                                                            from tbl_payroll_employee_tdsmonthly_challan ch
                                                            inner join  tbl_payroll_costcenter c on ch.branch=c.cost_center
                                                            order by financial_year Desc,challan_no Desc
                                                            " ProviderName="System.Data.SqlClient"></asp:SqlDataSource>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top">
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
