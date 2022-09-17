<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cashstatement.aspx.cs" Inherits="payroll_admin_cashstatement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                    DisplayAfter="1">
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
                <table cellspacing="0" cellpadding="0" width="718" border="0">
                    <tbody>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="blue-brdr-1" valign="top">
                                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td width="3%">
                                                                <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                            </td>
                                                            <td class="txt01">
                                                                Cash/Cheque Statement Form</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" height="20">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="txt02" width="27%">
                                                                View Cash/Cheque Statement</td>
                                                            <td class="txt-red" align="right" width="73%">
                                                                <span id="message" runat="server"></span>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 123px" valign="top">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="25%">
                                                                Year<span style="color:Red">*</span></td>
                                                            <td class="frm-rght-clr123" width="75%">
                                                                <asp:DropDownList ID="dd_year" runat="server" Width="180px" CssClass="select" OnDataBound="dd_year_DataBound"
                                                                    DataValueField="financialyear" DataTextField="financialyear" DataSourceID="SqlDataSource12"
                                                                    AutoPostBack="False">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ValidationGroup="v"
                                                                    ToolTip="Select Financial Year" ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                    Display="Dynamic" ControlToValidate="dd_year"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"
                                                                    SelectCommand="SELECT financial_year financialyear FROM tbl_payroll_tax_master  order by id desc"
                                                                    ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"></asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="25%">
                                                                Month<span style="color:Red">*</span></td>
                                                            <td class="frm-rght-clr123" width="75%">
                                                                <asp:DropDownList ID="ddlmonth" runat="server" Width="180px" CssClass="select">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="v" ToolTip="Select Reimbursement"
                                                                    ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                    Display="Dynamic" ControlToValidate="ddlmonth"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                       <%-- <tr>
                                                            <td class="frm-lft-clr123">
                                                                Location</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:DropDownList ID="dd_branch" runat="server" Width="180px" CssClass="select" OnDataBound="dd_branch_DataBound"
                                                                    DataValueField="branch_id" DataTextField="branch_name" DataSourceID="SqlDataSourceBranch">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="v" ToolTip="Select Branch"
                                                                    ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                    Display="Dynamic" ControlToValidate="dd_branch"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                <asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ProviderName="System.Data.SqlClient"
                                                                    SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_BranchMaster]"
                                                                    ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"></asp:SqlDataSource>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="25%">
                                                                Payment Mode</td>
                                                            <td class="frm-rght-clr123" width="75%">
                                                                &nbsp;<asp:RadioButton ID="rbtnCash" runat="server" Checked="True" Text="Cash" ValidationGroup="p" GroupName="cash" />
                                                                |
                                                                <asp:RadioButton ID="rbtnCheque" runat="server" Text="Cheque" ValidationGroup="p" GroupName="cash" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="25%">
                                                                &nbsp;</td>
                                                            <td class="frm-rght-clr123" width="75%">
                                                                <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="button"
                                                                    ValidationGroup="v" ToolTip="Submit" Text="Submit">
                                                                </asp:Button>&nbsp;&nbsp;
                                                                <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export" OnClick="btnexport_Click"
                                                                    ValidationGroup="v" ToolTip="Export To Excel"></asp:Button>
                                                                &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="2">
                                                                Mandatory Fields (<img alt="" src="../../images/error1.gif" />)</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" height="20">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="txt02" style="width: 29%">
                                                                Cash/Cheque Statement Details</td>
                                                            <td class="txt-red" align="right" width="73%">
                                                                <span id="SPAN1" runat="server"></span>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 123px" valign="top">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="frm-lft-clr123">
                                                                Cash/Cheque Advice
                                                                <asp:Label ID="lblmonth" runat="server" Text=""></asp:Label>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            <asp:LinkButton ID="BtnDeliversal" OnClick="BtnDeliversal_Click"  runat="server" Font-Size="Small" ForeColor="#000066" Font-Underline="True">Click Here To Pay Employee?</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="25%">
                                                                <asp:GridView ID="bankgrid" runat="server" Width="100%" OnPageIndexChanging="bankgrid_PageIndexChanging"
                                                                    EmptyDataText="Sorry No Records Found" PageSize="15" AllowPaging="True" Font-Size="11px"
                                                                    Font-Names="Arial" CellPadding="4" BorderWidth="1px" AutoGenerateColumns="False">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Empcode">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                                Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmpCode" Visible="true" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                                Width="10%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Payment Mode">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                                Width="13%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblACName" runat="server" Text='<%# Bind("paymentmode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total Amount">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                                Width="13%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTotAmount" runat="server" Text='<%# Bind("totamount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                    <RowStyle Height="5px" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnexport" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
