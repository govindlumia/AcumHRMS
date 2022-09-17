<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payslip.aspx.cs" Inherits="payroll_admin_payroll" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payslip</title>
    <style type="text/css">
        body
        {
            margin: 0;
            padding: 0;
            font: 11px Arial, Helvetica, sans-serif;
            color: #333;
        }
        .bm-lne
        {
            border-bottom: 1px solid #e7f1ff;
            padding: 5px 0 5px 0px;
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #013366;
        }
        
        .txt-un
        {
            font: bold 14px Arial, Helvetica, sans-serif;
            color: #08486d;
            padding: 6px 0;
        }
        .blue-bg1
        {
            background: #1a638d;
            color: #fff;
            padding: 0 3px;
            font: normal 11px Tahoma, Helvetica, sans-serif;
        }
        .blue-bg
        {
            background: #08486d;
            color: #fff;
            padding: 0 10px;
            font: normal 11px Tahoma, Helvetica, sans-serif;
        }
        .txt-red
        {
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #990000;
        }
        .bdr
        {
            border: 1px solid #08486d;
        }
        .line-right
        {
            border-left: 1px solid #08486d;
            border-bottom: 1px solid #08486d;
        }
        .line-left
        {
            border-bottom: 1px solid #08486d;
        }
        .line-left1
        {
            border-left: 0px;
        }
        .line-right1
        {
            border-right: 0px;
        }
        @page { size: landscape; }
    </style>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <script src="../jsPDF.js" type="text/javascript"></script>
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        function printsalaryslip() {
            $('#printbutton').hide();
            $('#b1').hide();
            window.print();
}
    </script>
</head>
<body>
    <form runat="server" id="form1">
    <div id="dvContainer">
        <table width="80%" border="0" align="center" cellpadding="3" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr id="printbutton">
                            <td colspan="3" style="height: 21px">
                                &nbsp;<asp:LinkButton ID="lnkprint" OnClientClick="printsalaryslip();" runat="server"  CssClass="txt-red">Click here to Print</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="blue-bg" style="width: 8%">
                            </td>
                            <td width="87%" height="22" align="center" class="blue-bg">
                                <strong>
                                    <asp:Label ID="lbl_companyname" runat="server" Text=""></asp:Label>
                                </strong>
                            </td>
                            <td width="7%" align="right" class="blue-bg">
                            </td>
                        </tr>
                        <tr>
                            <td height="22" colspan="3" valign="top">
                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="22" align="right" valign="middle">
                                            <span class="txt-red">&nbsp;</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="txt-un">
                                            Pay Slip for the month of
                                            <asp:Label ID="lbl_month" runat="server" Text=""></asp:Label>
                                            -
                                            <asp:Label ID="lbl_year" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Employee Name</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_empname" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Total Working Days</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Designation</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>No. of Holidays</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblHolidays" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Employee No</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>No. of Working Days</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblDays" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>DOJ</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>No. of Days Worked</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblDayWorked" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>PF No</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblPF" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Leave Taken</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblLeaveTaken" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>UAN No</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblUAN" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Absent (Previous)</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblAbsentPrevious" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>ESI No</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblESI" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Absent (Current)</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>PAN</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblPAN" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>BANK A/C No</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Category</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>BANK Name</strong>
                                                    </td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Employee Code</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Designation</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Date of Joining</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                </tr>--%>
                                                <%--  <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Grade</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblgrade" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Department</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_dept" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Branch</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                </tr>--%>
                                                <%--<tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Payment Mode</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblpaymentmode" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Bank Name</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>A/C No</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                </tr>--%>
                                                <%--<tr>

<td class="bm-lne" width="16%"><strong>ESI Number</strong></td>
<td class="bm-lne">
    <asp:Label ID="lbl_esi_number" runat="server" Text=""></asp:Label>&nbsp;</td>
    <td width="16%" class="bm-lne"><strong>PF Account Number</strong></td>
<td class="bm-lne">
    <asp:Label ID="lbl_pf_acnumber" runat="server" Text=""></asp:Label>&nbsp;</td>>
<td class="bm-lne" width="16%"><strong>Employee I.T. PAN</strong></td>
<td class="bm-lne">
    <asp:Label ID="lbl_emp_IT_pan" runat="server" Text=""></asp:Label>&nbsp;</td>
</tr>--%>
                                                <%--<tr>
                                                    <td class="bm-lne">&nbsp;</td>
                                                    <td class="bm-lne">&nbsp;</td>
                                                    <td class="bm-lne">&nbsp;</td>
                                                    <td class="bm-lne">&nbsp;</td>
                                                    <td class="bm-lne" colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="16%">LWP</td>
                                                                <td>
                                                                    <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                                <td width="22%">Total Days</td>
                                                                <td>
                                                                    <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="bdr">
                                            <asp:GridView ID="grdSalaryStructure" runat="server" Font-Size="11px" Font-Names="Arial"
                                                CellSpacing="0" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                                AllowPaging="False" PageSize="5" EmptyDataText="No such employee exists !">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Salary Structure">
                                                        <HeaderStyle CssClass="blue-bg1 line-left" Height="20px" HorizontalAlign="left" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="1"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <HeaderStyle Width="17%" CssClass="blue-bg1 line-right" HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="1"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
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
                                        <td valign="top">
                                            <table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse;">
                                                <tr>
                                                    <td align="right">
                                                        <strong>Total CTC PM</strong>
                                                    </td>
                                                    <td width="17%" class="line-right" align="right">
                                                        <asp:Label ID="lblCTC" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="1" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
                                                <tr>
                                                    <td width="50%" valign="top" class="bdr">
                                                        <asp:GridView ID="earning_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No such employee exists !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Earnings">
                                                                    <HeaderStyle CssClass="blue-bg1 line-left" Height="20px" HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="1"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle Width="17%" CssClass="blue-bg1 line-right" HorizontalAlign="center" />
                                                                    <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="1"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                                                    </td>
                                                    <td valign="top" width="50%" class="bdr">
                                                        <asp:GridView ID="deduction_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No deduction !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Deductions">
                                                                    <HeaderStyle CssClass="blue-bg1 line-left" Height="20px" HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="1"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle CssClass="blue-bg1 line-right" Width="17%" HorizontalAlign="center" />
                                                                    <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="1"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
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
                                                    <td valign="top" class="bdr">
                                                        <table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse;
                                                            border-left: none; bordercolor=#08486d; border-right: none;">
                                                            <tr>
                                                                <td width="81%" class="line-left">
                                                                    <strong>Total Earnings</strong>
                                                                </td>
                                                                <td width="17%" class="line-right" align="right">
                                                                    <asp:Label ID="lbl_total_earning" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" class="bdr">
                                                        <table width="100%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse;
                                                            border-color: #08486d;">
                                                            <tr>
                                                                <td width="83%" class="line-left">
                                                                    <strong>Total Deductions</strong>
                                                                </td>
                                                                <td width="17%" class="line-right" align="right">
                                                                    <asp:Label ID="lbl_total_deductions" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="line-left">
                                                                    <strong>Net Amount</strong>
                                                                </td>
                                                                <td class="line-right" align="right">
                                                                    <asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label>
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="reimdiv" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td valign="top" class="bdr">
                                                            <asp:GridView ID="reimbursement_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                                BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No Reimbursement Exists !">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Reimbursement">
                                                                        <HeaderStyle CssClass="blue-bg1 line-left" Height="20px" HorizontalAlign="left" />
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="1"
                                                                            VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <HeaderStyle Width="17%" CssClass="blue-bg1 line-right" HorizontalAlign="center" />
                                                                        <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="1"
                                                                            VerticalAlign="Top" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
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
                                                        <td>
                                                            <table width="100%" border="1" cellspacing="0" style="border-collapse: collapse;
                                                                border-color: #08486d;">
                                                                <tr class="bdr">
                                                                    <td align="right">
                                                                        <strong>Total Reimbursement</strong>
                                                                    </td>
                                                                    <td width="17%" align="right">
                                                                        <asp:Label ID="lbl_reimbursement" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <%-- Hide Grand Total as per client call by ANUJ OJHA on 9-July-14 --%>
                                    <tr id="trTotal" runat="server" visible="false">
                                        <td>
                                            <table width="50%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse;
                                                border-color: #08486d;">
                                                <tr class="bdr">
                                                    <td class="line-left">
                                                        <strong>Grand Total</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_tot_grandtotal" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td class="line-left">
                                                        <strong>Total Deduction</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_tot_deduction" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td class="line-left">
                                                        <strong>Total Reimbursement</strong>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_tot_reimbursement" runat="server" Text=""></asp:Label>
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
                <td class="bm-lne">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    Issued by Pay Roll Team
                </td>
            </tr>
            <tr>
                <td>
                    <b>Net Salary in words:</b>
                    <asp:Label ID="lblwords" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a href="javascript: window.close ()">
                        <button class="blue1" id="b1" onclick='window.close()'>
                            Close Window</button></a>
                </td>
            </tr>
            <tr>
                <td style="height: 20px;display:none" >
                    &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true">
                    </CR:CrystalReportViewer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
