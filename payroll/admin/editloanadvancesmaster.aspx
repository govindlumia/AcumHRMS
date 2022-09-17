<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editloanadvancesmaster.aspx.cs"
    Inherits="payroll_admin_editloanmaster" %>

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
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
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
                                                    Loan/Advances Master</td>
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
                                                <td width="32%" class="txt02">
                                                    Update Loan/Advances Details</td>
                                                <td width="68%" align="right" class="txt-red">
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
                                                    Name<span style="color:Red">*</span></td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_name" size="40" CssClass="input2" runat="server" ToolTip="Loan/Advances Name"
                                                        MaxLength="20"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                        ToolTip="Enter Loan/Advances Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Alias Name<span style="color:Red">*</span></td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_alias" runat="server" CssClass="input2" Width="223px" ToolTip="Loan/Advances Alias Name"
                                                        MaxLength="20"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter Alias Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Name in Payslip<span style="color:Red">*</span></td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_payslip" runat="server" CssClass="input2" Width="223px" ToolTip="Loan/Advances Name in Payslip"
                                                        MaxLength="20"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_payslip"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter name to display in payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr id="tr1" runat="server">
                                                <td width="25%" class="frm-lft-clr123">
                                                    Interest</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_interest" size="40" CssClass="input2" runat="server" ToolTip="Enter Interest applicable on Loan">0.0</asp:TextBox>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_interest"
                                                        ErrorMessage="Enter year between 0 and 60" MaximumValue="100" MinimumValue="0"
                                                        Type="Double">Enter interest between 0 and 100</asp:RangeValidator></td>
                                            </tr>
                                            <tr id="tr3" runat="server">
                                                <td height="5" colspan="2" >
                                                </td>
                                            </tr>
                                            <tr id="tr2" runat="server">
                                                <td width="25%" class="frm-lft-clr123">
                                                    Interest (@ SBI)<span style="color:Red">*</span></td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_taxSBI" size="40" CssClass="input2" runat="server" ToolTip="Interest applicable on Loan/Advances">0.0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_taxSBI"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter name to display in payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_taxSBI"
                                                        ErrorMessage="Enter year between 0 and 60" MaximumValue="100" MinimumValue="0"
                                                        Type="Double">Enter interest between 0 and 100</asp:RangeValidator></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2" id="tr4" runat="server">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Loan/Advances A/c No.<span style="color:Red">*</span></td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_loan_acno" size="40" CssClass="input2" runat="server" ToolTip="Loan/Advances A/c No."
                                                        MaxLength="20"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_loan_acno"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                        ToolTip="Enter Loan/Advances A/c No."><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Eligibility Year<span style="color:Red">*</span></td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_eligibility_yr" size="40" CssClass="input2" runat="server" ToolTip="Eligibility Year" onkeyup="javascript:checkNumericValueForCntrl(this)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_eligibility_yr"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                        ToolTip="Enter Eligibility Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_eligibility_yr"
                                                        ErrorMessage="Enter year between 0 and 60" MaximumValue="60" MinimumValue="0"
                                                        Type="Double">Enter year between 0 and 60</asp:RangeValidator></td>
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
                                                        ToolTip="Click to submit the updated Loan/Advances Type" />
                                                    <asp:Button ID="btncncl" runat="server" CssClass="button" Text="Cancel" OnClick="btncncl_Click"
                                                        ToolTip="Click to cancel the updation" ValidationGroup="none" /></td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
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
