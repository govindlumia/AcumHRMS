<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_applyloanadvances_detail.aspx.cs"
    Inherits="payroll_admin_edit_applyloanadvances_detail" %>

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
      <cc1:ToolkitScriptManager runat="server" ID="tsmgr"></cc1:ToolkitScriptManager>
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
                                                        Edit Applied Loan/Advances Details</td>
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
                                                    <td width="29%" class="txt02">
                                                        Edit Loan/Advances Details</td>
                                                    <td width="71%" align="right" class="txt-red">
                                                        <span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="height: 123px">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Employee Code</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_empcode" runat="server" Text="Label" Width="182px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Employee Name</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_empname" runat="server" Text="Label" Width="182px"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Loan/Advances Type</td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_loanname" runat="server" CssClass="select" Width="180px"
                                                            DataSourceID="SqlDataSource1" OnSelectedIndexChanged="dd_loanname_SelectedIndexChanged"
                                                            DataTextField="loan_name" DataValueField="id" OnDataBound="dd_loanname_DataBound"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_loanname"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Enter Loan/Advances Name"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            SelectCommand="select [id],[loan_name] from tbl_payroll_loan_advances where status=1"
                                                            ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div id="divloanac" runat="server">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="30%" class="frm-lft-clr123">
                                                                        Loan/Advances A/c No.</td>
                                                                    <td width="70%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_acno" runat="server" Text="Label" Width="182px"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Loan/Advances Reference No.<span style="color:Red">*</span></td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_loanref" runat="server" CssClass="input2" size="30" ToolTip="Loan Reference ID"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_loanref"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter Loan Reference ID"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Loan/Advances Amount <span style="color:Red">*</span></td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_loanamnt" runat="server" CssClass="input2" size="30" ToolTip="Loan Amount"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvloanamnt" runat="server" ControlToValidate="txt_loanamnt"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter Loan Amount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_loanamnt"
                                                            Display="Dynamic" ErrorMessage="Enter valid amount" MaximumValue="9999999" MinimumValue="0"
                                                            Type="Currency"></asp:RangeValidator></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Sanction Date <span style="color:Red">*</span></td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                        <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txt_sdate"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                            ToolTip="Select Loan Sanction Date"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" Format="dd-MMM-yyyy"
                                                            TargetControlID="txt_sdate">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Recover From <span style="color:Red">*</span></td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_month" runat="server" CssClass="select" Width="90px">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="dd_year" runat="server" CssClass="select" Width="90px">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        No. of Installments <span style="color:Red">*</span></td>
                                                    <td class="frm-rght-clr123">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="30%">
                                                                    <asp:TextBox ID="txt_instal_no" runat="server" CssClass="input2" size="30"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_instal_no"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                        ToolTip="Enter No. of Installments"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                                <td width="40%">
                                                                    <asp:Button ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="button"
                                                                        ToolTip="Click for Re Installments Details" Text="Calculate"></asp:Button></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Interest Amount
                                                        <br />
                                                        (@<asp:Label ID="lblinterestamount" runat="server"></asp:Label>%)</td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        Rs.&nbsp;
                                                        <asp:Label ID="lblinteresttopaid" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        Monthly Amount</td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        Rs.&nbsp;
                                                        <asp:Label ID="lblmonthlypayment" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="30%" class="frm-lft-clr123">
                                                        &nbsp;</td>
                                                    <td width="70%" class="frm-rght-clr123">
                                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                                                            ToolTip="Click to submit the Loan & Advances Details" />
                                                        <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click"
                                                            ToolTip="Click to reset the entered details" ValidationGroup="none" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:HiddenField ID="sbi" runat="server" />
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
                    <div id="divdetail" runat="server" visible="true" align="center">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="95%" valign="top" class="txt02" align="left">
                                                Installment Details</td>
                                            <td width="5%" align="right" valign="top">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left" valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="1" cellspacing="0" cellpadding="3" bordercolor="#93b5c8"
                                                                style="border-collapse: collapse;">
                                                                <tr>
                                                                    <td colspan="3" valign="top" width="100%">
                                                                        <div id="divscrol" runat="server" style="position: static; width: 880px; height: 250px;
                                                                            overflow-x: hidden; overflow-y: scroll; left: 1px; top: 3px;">
                                                                            <asp:GridView ID="detailgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                                CellPadding="4" Width="95%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No record found"
                                                                                PageSize="80">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Month/Year">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("recovery") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Beginning Balance">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("beginningbalance") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Interest Payment">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("interestpayment") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Principal payment">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("principalpayment") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Ending Balance">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("endingbalance") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Total Principal">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("totalprincipal") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Total Interest">
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("totalinterest") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                                <RowStyle Height="5px" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20" colspan="3" align="right" valign="middle">
                                                                        &nbsp;</td>
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
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
