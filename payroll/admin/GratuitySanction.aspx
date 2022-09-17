<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GratuitySanction.aspx.cs"
    Inherits="payroll_admin_perquisite_employee_accommodation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager  ID="payroll" runat="server">
        </cc1:ToolkitScriptManager>
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
                    <tr>
                        <td valign="top">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td class="blue-brdr-1" valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tr>
                                                <td width="3%">
                                                    <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                </td>
                                                <td class="txt01">
                                                    Gratuity</td>
                                            </tr>
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
                                            <tr>
                                                <td class="txt02" width="27%">
                                                    Entry Gratuity detail</td>
                                                <td class="txt-red" align="right" width="73%">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 123px" valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    Year
                                                </td>
                                                <td class="frm-rght-clr123" width="75%">
                                                    <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" CssClass="select"
                                                        DataSourceID="SqlDataSource12" DataTextField="financialyear" DataValueField="financialyear"
                                                        Width="180px">
                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"
                                                        SelectCommand="select [financial_year] as financialyear from tbl_payroll_tax_master where id not in (1,2,3,4,5,6) order by id desc">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    Employee Code<span style="color:Red">*</span></td>
                                                <td class="frm-rght-clr123" width="75%">
                                                    <asp:TextBox ID="txt_employee" size="40" CssClass="input" runat="server" ToolTip="Employee Code"
                                                        Width="88px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                        ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <%--<a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">
                                                        Pick Employee</a>--%>
                                                        <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');" class="link05">Pick Employee</a>&nbsp;
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Sanction Date<span style="color:Red">*</span></td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtleasefrom" runat="server" CssClass="input" size="40" ToolTip="Lease From"
                                                        Width="88px"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                    <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txtleasefrom"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                        ToolTip="Select Loan Sanction Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="Range4from" runat="server" ControlToValidate="txtleasefrom"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="Invalid Date" />' 
                                                        ValidationGroup="v"></asp:RangeValidator>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txtleasefrom" Format="dd-MMM-yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Month</td>
                                                <td class="frm-rght-clr123">
                                                    &nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" DataTextField="month "
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
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Amount<span style="color:Red">*</span></td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtamount" runat="server" CssClass="input" size="40" ToolTip="Perquisite amount Received"
                                                        Width="88px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter Perquisite Amount Received" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtamount"
                                                        Display="Dynamic" ErrorMessage="Enter Correct Amount" MaximumValue="999999" MinimumValue="0"
                                                        Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    &nbsp;</td>
                                                <td class="frm-rght-clr123" width="75%">
                                                    &nbsp;<asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" ValidationGroup="v"
                                                        OnClick="btnsubmit_Click" />
                                                    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                                        Text="Reset" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    Mandatory Fields (<img alt="" src="../../images/error1.gif" />)</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="20">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td class="txt02" width="27%">
                                                    Employee lease Detail</td>
                                                <td class="txt-red" align="right" width="73%">
                                                    <span id="SPAN1" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grid" runat="server" Width="100%" EmptyDataText="Sorry No Records Found"
                    PageSize="50" DataKeyNames="id" AllowPaging="true" Font-Size="11px" Font-Names="Arial"
                    CellSpacing="0" CellPadding="4" BorderWidth="1px" AutoGenerateColumns="false"
                    OnPageIndexChanging="grid_PageIndexChanging" OnRowUpdating="grid_RowUpdating"
                    OnRowDeleting="grid_RowDeleting" onrowdatabound="grid_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Financial Year">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l1" runat="server" Text='<%# Bind("fyear")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Emp Code">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l2" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sanction Date">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lbl_sdate_grid" runat="server" Text='<%# Bind("sanction_date")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Month">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l4" runat="server" Text='<%# Bind("month")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="l5" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Update"
                                    CssClass="link05" Text="Edit" ToolTip="Edit" />
                                |
                                <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                    CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="frm-lft-clr123" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="frm-lft-clr123" />
                    <FooterStyle CssClass="frm-lft-clr123" />
                    <RowStyle Height="5px" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
