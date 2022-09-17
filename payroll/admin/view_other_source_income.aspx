<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_other_source_income.aspx.cs"
    Inherits="payroll_admin_view_other_source_income" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acuminous Software</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
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
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                    <td valign="bottom">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <div id="divedit" visible="false" runat="server">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01">
                                                        Other Source Income Master</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" valign="top">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="27%" class="txt02">
                                                        Other Source Income</td>
                                                    <td width="73%" align="right" class="txt-red">
                                                        <span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="height: 123px">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Emp Code</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_employee" size="40" CssClass="input" runat="server" ToolTip="Employee Code"
                                                            Width="88px" Enabled="False"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                            ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Financial Year</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_year" runat="server" DataSourceID="SqlDataSource12" DataTextField="financialyear"
                                                            DataValueField="financialyear" Enabled="false" OnDataBound="dd_year_DataBound"
                                                            CssClass="select" Width="163px">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                        <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            SelectCommand="select distinct [financial_year] as financialyear from tbl_payroll_tax_master"
                                                            ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Income Source</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddlincomesource" runat="server" Width="168px" DataSourceID="SqlDataSource2"
                                                            DataTextField="incomesource" DataValueField="id" CssClass="select">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            SelectCommand="select id,incomesource from tbl_payroll_income_source_master"
                                                            ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Amount</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtamount" runat="server" Width="129px" CssClass="input"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ToolTip="Enter Employee Code"
                                                            Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ControlToValidate="txtamount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        &nbsp;</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                            ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
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
                                                    View/Edit Others Source</td>
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
                                                            <td width="27%" class="txt02">
                                                                View Others Source Details</td>
                                                            <td width="73%" align="right" class="txt-red">
                                                                <span id="message1" runat="server"></span>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-2">
                                                    <asp:GridView ID="payheadgird" runat="server" Font-Size="11px" Font-Names="Arial"
                                                        CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                                        EmptyDataText="Sorry no record found" DataSourceID="SqlDataSource1" AllowPaging="True"
                                                        PageSize="30">
                                                        <Columns>
                                                            <asp:BoundField DataField="empcode" HeaderText="Employee Code" SortExpression="empcode">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="fyear" HeaderText="Financial Year" SortExpression="fyear">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="incomesource" HeaderText="Income Source" SortExpression="incomesource">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <a class="link05" href="view_other_source_income.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                        target="_self">Edit</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        SelectCommand="SELECT i.id,empcode,fyear,i.incomesourceid as incomesourceid,m.incomesource,amount,createdby,createddate FROM tbl_payroll_other_source_income i inner join tbl_payroll_income_source_master m on i.incomesourceid=m.id"
                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
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
