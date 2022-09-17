<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taxmaster.aspx.cs" Inherits="payroll_admin_taxmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
.pop2 {
  position:absolute; background-color: #fff; z-index:1002; overflow: auto; padding:0px; left:135px; top:48%;width:500px;
}
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
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
                <div id="divapply">
                    <table width="718" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01">
                                                        Tax Slab Master</td>
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
                                                    <td width="29%" class="txt02" style="height: 13px">
                                                        Tax Details</td>
                                                    <td width="71%" align="right" class="txt-red" style="height: 13px">
                                                        <span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" class="frm-lft-clr123">
                                                        Financial Year</td>
                                                    <td width="29%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dd_year_SelectedIndexChanged"
                                                            CssClass="select">
                                                        </asp:DropDownList></td>
                                                    <td width="1%" rowspan="3">
                                                    </td>
                                                    <td width="18%" class="frm-lft-clr123">
                                                        Education Cess</td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_ecess" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>&nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_ecess"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter education cess" ValidationGroup="k"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Surcharge Percentage</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_scharge" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_scharge"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter surcharge percentage" ValidationGroup="k"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                    <td class="frm-lft-clr123">
                                                        Surcharge Limit</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_slimit" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_slimit"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter surcharge limit" ValidationGroup="k"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txt02" align="left" height="22" valign="middle">
                                            Slab Detail For Men</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" class="frm-lft-clr123">
                                                        Minimum Amount</td>
                                                    <td width="29%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_min_amt" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_min_amt"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter minimum amount" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                    <td width="1%" rowspan="3">
                                                    </td>
                                                    <td width="18%" class="frm-lft-clr123">
                                                        Maximum Amount</td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_max_amt" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Percentage</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_percentage" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_percentage"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter deduction percentage" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                    <td colspan="2" align="right">
                                                        <asp:Button ID="btn_add" runat="server" CssClass="button" Text="Add" OnClick="btn_add_Click1"
                                                            ValidationGroup="v" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" class="head-2">
                                                        <asp:GridView ID="tax_grid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="4" CellSpacing="0" DataKeyNames="minimumamount" Font-Names="Arial"
                                                            Font-Size="11px" Width="100%" EmptyDataText="No record found" OnRowDeleting="tax_grid_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Minimum Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Maximum Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Percentage Deduction">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="30%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("percentage")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                        <td height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txt02" align="left" height="22" valign="middle">
                                            Slab Detail For Women</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" class="frm-lft-clr123">
                                                        Minimum Amount</td>
                                                    <td width="29%" class="frm-lft-clr123">
                                                        <asp:TextBox ID="txt_wminamnt" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_wminamnt"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter minimum amount" ValidationGroup="u"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                    <td width="1%" rowspan="3">
                                                        &nbsp;</td>
                                                    <td width="18%" class="frm-lft-clr123">
                                                        Maximum Amount</td>
                                                    <td width="31%" class="frm-lft-clr123">
                                                        <asp:TextBox ID="txt_wmaxamt" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Percentage</td>
                                                    <td class="frm-lft-clr123">
                                                        <asp:TextBox ID="txt_wpercentag" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>&nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_wpercentag"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter deduction percentage" ValidationGroup="u"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                    <td colspan="2" align="right">
                                                        <asp:Button ID="btn_wadd" runat="server" CssClass="button" Text="Add" OnClick="btn_wadd_Click"
                                                            ValidationGroup="u" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" class="head-2">
                                                        <asp:GridView ID="tax_wgrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="4" CellSpacing="0" DataKeyNames="minimumamount" Font-Names="Arial"
                                                            Font-Size="11px" Width="100%" EmptyDataText="No record found" OnRowDeleting="tax_wgrid_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Minimum Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="d" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Maximum Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="e" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Percentage Deduction">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="30%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="f" runat="server" Text='<%# Bind("percentage")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                        <td height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txt02" align="left" height="22" valign="middle">
                                            Slab Detail For Senior Citizen</td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" class="frm-lft-clr123">
                                                        Minimum Amount</td>
                                                    <td class="frm-rght-clr123" width="29%">
                                                        <asp:TextBox ID="txt_semin" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_semin"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter minimum amount" ValidationGroup="w"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="1%" rowspan="3">
                                                        &nbsp;</td>
                                                    <td width="18%" class="frm-lft-clr123">
                                                        Maximum Amount</td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_semax" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Percentage</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_seper" runat="server" CssClass="input2" size="30" MaxLength="12"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_seper"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter deduction percentage" ValidationGroup="w"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td colspan="2" align="right">
                                                        <asp:Button ID="btn_seadd" runat="server" CssClass="button" Text="Add" OnClick="btn_seadd_Click"
                                                            ValidationGroup="w" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="5" class="head-2">
                                                        <asp:GridView ID="tax_sgrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="4" CellSpacing="0" DataKeyNames="minimumamount" Font-Names="Arial"
                                                            Font-Size="11px" Width="100%" EmptyDataText="No record found" OnRowDeleting="tax_sgrid_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Minimum Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="g" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Maximum Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="h" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Percentage Deduction">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="30%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="i" runat="server" Text='<%# Bind("percentage")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" class="frm-lft-clr123">
                                                        &nbsp;</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" ToolTip="Click to submit Reimbursement Details"
                                                            OnClick="btnsubmit_Click" ValidationGroup="k" />&nbsp;
                                                        <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" ToolTip="Click to reset the entered details"
                                                            ValidationGroup="none" OnClick="btnreset_Click" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                        </td>
                                    </tr>
                                </table>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
