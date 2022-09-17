<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="TaxDeclarationForm.aspx.cs"
    Inherits="payroll_admin_reports_TaxDeclarationForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>IT Computation Report</title>
    <link href="../../../css/blue1.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
	 function HideShow()
   {
   
   if(document.getElementById("tdviewenq").style.display=="block")
        {
            document.getElementById("tdviewenq").style.display="none";
			document.getElementById("incentive").innerText="- Incentive View";
			document.getElementById("incentive").style.color="red";
            return false;
        }
    if(document.getElementById("tdviewenq").style.display=="none")
        {
            document.getElementById("tdviewenq").style.display="block";
			document.getElementById("incentive").innerText="+ Incentive View";
			document.getElementById("incentive").style.color="blue";
            return false;
        }
   }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 4px 4px 4px 4px; border: #CCCCCC 4px solid;" id="dvText" runat="server">
            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                <tr>
                    <td id="companyDetails">
                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblCompanyname" Style="font-weight: bold; font-size: 15px; color: #000099;"
                                        runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblAddress" runat="server" Style="font-weight: bold; font-size: 15px;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblFinancialYear" runat="server" Style="font-weight: bold; font-size: 13px;"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                            <tr>
                                <td width="8%">
                                    Employee Name :
                                </td>
                                <td width="58%">
                                    <asp:Label ID="lblEmpName" Style="font-weight: bold; font-size: 12px; color: #000099;"
                                        runat="server"></asp:Label></td>
                                <td width="8%">
                                    Date Of Joining :
                                </td>
                                <td width="26%">
                                    <asp:Label ID="lblDOJ" Style="font-weight: bold; font-size: 12px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="4" height="5px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    PAN No. :
                                </td>
                                <td>
                                    <asp:Label ID="lblPanNo" Style="font-weight: bold; font-size: 12px;" runat="server"></asp:Label></td>
                                <td>
                                    Gender :
                                </td>
                                <td>
                                    <asp:Label ID="lblGender" Style="font-weight: bold; font-size: 12px;" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdItComputation" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowDataBound="grdItComputation_RowDataBound" ShowFooter="True" Style="margin-top: 0px">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                                            <tr>
                                                <td width="16%" style="line-height: 22px;" class="black-hdr">
                                                    A) Taxable Income
                                                </td>
                                                <td width="84%">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td width="8%" height="22" class="black-hdr" align="right">
                                                                Apr</td>
                                                            <td width="8%" class="black-hdr" align="right">
                                                                May
                                                            </td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Jun</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Jul</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Aug</td>
                                                            <td width="8%" class="black-hdr" align="right">
                                                                Sep</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Oct</td>
                                                            <td width="8%" class="black-hdr" align="right">
                                                                Nov</td>
                                                            <td width="9%" class="black-hdr" align="right">
                                                                Dec</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Jan</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Feb</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Mar</td>
                                                            <td width="10%" class="black-hdr" align="right" style="border-left: #cccccc 1px solid;
                                                                padding-left: 10px;">
                                                                Total</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #EAEAEA;">
                                            <tr>
                                                <td class="black-hdr" style="line-height: 22px;" width="16%">
                                                    Total
                                                </td>
                                                <td width="84%">
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td class="black-hdr" height="22" width="8%" align="right">
                                                                <asp:Label ID="lblAprT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblMayT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJunT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJulT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblAugT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblSepT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblOctT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblNovT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="9%" align="right">
                                                                <asp:Label ID="lblDecT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJanT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblFebT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblMarT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="10%" align="right" style="border-left: #cccccc 1px solid;
                                                                padding-left: 10px;">
                                                                <asp:Label ID="lblFTotal" runat="server" ForeColor="Red"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="16%" style="line-height: 22px;" align="left">
                                                    <asp:Label ID="lblPayheadid" runat="server" Visible="false" Text='<%# bind("payheadid") %>'></asp:Label>
                                                    <asp:Label ID="lblPayhead" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                </td>
                                                <td width="84%">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblApr" runat="server" Text='<%# bind("Apr") %>'></asp:Label>
                                                            </td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblMay" runat="server" Text='<%# bind("May") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJun" runat="server" Text='<%# bind("Jun") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJul" runat="server" Text='<%# bind("Jul") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblAug" runat="server" Text='<%# bind("Aug") %>'></asp:Label></td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblSep" runat="server" Text='<%# bind("Sep") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblOct" runat="server" Text='<%# bind("Oct") %>'></asp:Label></td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblNov" runat="server" Text='<%# bind("Nov") %>'></asp:Label></td>
                                                            <td width="9%" align="right">
                                                                <asp:Label ID="lblDec" runat="server" Text='<%# bind("Dec") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJan" runat="server" Text='<%# bind("Jan") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblFeb" runat="server" Text='<%# bind("Feb") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblMar" runat="server" Text='<%# bind("Mar") %>'></asp:Label></td>
                                                            <td width="10%" align="right" style="border-left: #cccccc 1px solid; padding-left: 10px;">
                                                                <asp:Label ID="lblTotal" Font-Bold="true" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <%--<tr>
                    <td>
                        <a id="incentive" href="#" style="text-decoration: none; color: #FF0000; font-size: 12px;"
                            onclick="return HideShow();">- Incentive View</a></td>
                </tr>--%>
                <tr>
                    <td id="tdviewenq" style="display: none;">
                        <asp:GridView ID="grdItComputationPerformance" runat="server" AutoGenerateColumns="False"
                            Width="100%" ShowFooter="True" Style="margin-top: 0px" OnRowDataBound="grdItComputationPerformance_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                                            <tr>
                                                <td width="16%" style="line-height: 22px;" class="black-hdr">
                                                    Incentive View</td>
                                                <td width="84%">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td width="8%" height="22" class="black-hdr" align="right">
                                                                Apr</td>
                                                            <td width="8%" class="black-hdr" align="right">
                                                                May
                                                            </td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Jun</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Jul</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Aug</td>
                                                            <td width="8%" class="black-hdr" align="right">
                                                                Sep</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Oct</td>
                                                            <td width="8%" class="black-hdr" align="right">
                                                                Nov</td>
                                                            <td width="9%" class="black-hdr" align="right">
                                                                Dec</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Jan</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Feb</td>
                                                            <td width="7%" class="black-hdr" align="right">
                                                                Mar</td>
                                                            <td width="10%" class="black-hdr" align="right" style="border-left: #cccccc 1px solid;
                                                                padding-left: 10px;">
                                                                Total</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #EAEAEA;">
                                            <tr>
                                                <td class="black-hdr" style="line-height: 22px;" width="16%">
                                                    Total
                                                </td>
                                                <td width="84%">
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td class="black-hdr" height="22" width="8%" align="right">
                                                                <asp:Label ID="lblAprPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblMayPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJunPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJulPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblAugPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblSepPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblOctPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblNovPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="9%" align="right">
                                                                <asp:Label ID="lblDecPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJanPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblFebPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblMarPI" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="10%" align="right" style="border-left: #cccccc 1px solid;
                                                                padding-left: 10px;">
                                                                <asp:Label ID="lblFTotalPI" runat="server" ForeColor="Red"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="16%" style="line-height: 22px;" align="left">
                                                    <asp:Label ID="lblPayheadidPI" runat="server" Visible="false" Text='<%# bind("payheadid") %>'></asp:Label>
                                                    <asp:Label ID="lblPayheadPI" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                </td>
                                                <td width="84%">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblAprPI" runat="server" Text='<%# bind("Apr") %>'></asp:Label>
                                                            </td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblMayPI" runat="server" Text='<%# bind("May") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJunPI" runat="server" Text='<%# bind("Jun") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJulPI" runat="server" Text='<%# bind("Jul") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblAugPI" runat="server" Text='<%# bind("Aug") %>'></asp:Label></td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblSepPI" runat="server" Text='<%# bind("Sep") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblOctPI" runat="server" Text='<%# bind("Oct") %>'></asp:Label></td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblNovPI" runat="server" Text='<%# bind("Nov") %>'></asp:Label></td>
                                                            <td width="9%" align="right">
                                                                <asp:Label ID="lblDecPI" runat="server" Text='<%# bind("Dec") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJanPI" runat="server" Text='<%# bind("Jan") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblFebPI" runat="server" Text='<%# bind("Feb") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblMarPI" runat="server" Text='<%# bind("Mar") %>'></asp:Label></td>
                                                            <td width="10%" align="right" style="border-left: #cccccc 1px solid; padding-left: 10px;">
                                                                <asp:Label ID="lblTotalPI" Font-Bold="true" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdItComputationPF" runat="server" AutoGenerateColumns="False"
                            Width="100%" OnRowDataBound="grdItComputationPF_RowDataBound" ShowFooter="True"
                            Style="margin-top: 0px" ShowHeader="True">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                                            <tr>
                                                <td width="16%" style="line-height: 22px;" class="black-hdr">
                                                    B) Other Items
                                                </td>
                                                <td width="84%">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr style="display: none;">
                                                            <td width="8%" height="22" class="black-hdr">
                                                                Apr</td>
                                                            <td width="8%" class="black-hdr">
                                                                May
                                                            </td>
                                                            <td width="7%" class="black-hdr">
                                                                Jun</td>
                                                            <td width="7%" class="black-hdr">
                                                                Jul</td>
                                                            <td width="7%" class="black-hdr">
                                                                Aug</td>
                                                            <td width="8%" class="black-hdr">
                                                                Sep</td>
                                                            <td width="7%" class="black-hdr">
                                                                Oct</td>
                                                            <td width="8%" class="black-hdr">
                                                                Nov</td>
                                                            <td width="9%" class="black-hdr">
                                                                Dec</td>
                                                            <td width="7%" class="black-hdr">
                                                                Jan</td>
                                                            <td width="7%" class="black-hdr">
                                                                Feb</td>
                                                            <td width="7%" class="black-hdr">
                                                                Mar</td>
                                                            <td width="10%" class="black-hdr" style="border-left: #cccccc 1px solid; padding-left: 10px;">
                                                                Total</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #EAEAEA;">
                                            <tr>
                                                <td class="black-hdr" style="line-height: 22px;" width="16%">
                                                    Total
                                                </td>
                                                <td width="84%">
                                                    <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                                        <tr>
                                                            <td class="black-hdr" height="22" width="8%" align="right">
                                                                <asp:Label ID="lblAprT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblMayT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJunT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJulT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblAugT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblSepT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblOctT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="8%" align="right">
                                                                <asp:Label ID="lblNovT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="9%" align="right">
                                                                <asp:Label ID="lblDecT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblJanT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblFebT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="7%" align="right">
                                                                <asp:Label ID="lblMarT" runat="server"></asp:Label></td>
                                                            <td class="black-hdr" width="10%" align="right" style="border-left: #cccccc 1px solid;
                                                                padding-left: 10px;">
                                                                <asp:Label ID="lblFTotal" ForeColor="Red" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="16%" style="line-height: 22px;">
                                                    <asp:Label ID="lblPayheadid" runat="server" Visible="false" Text='<%# bind("payheadid") %>'></asp:Label>
                                                    <asp:Label ID="lblPayhead0" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                </td>
                                                <td width="84%">
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="1">
                                                        <tr>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblApr" runat="server" Text='<%# bind("Apr") %>'></asp:Label>
                                                            </td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblMay" runat="server" Text='<%# bind("May") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJun" runat="server" Text='<%# bind("Jun") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJul" runat="server" Text='<%# bind("Jul") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblAug" runat="server" Text='<%# bind("Aug") %>'></asp:Label></td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblSep" runat="server" Text='<%# bind("Sep") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblOct" runat="server" Text='<%# bind("Oct") %>'></asp:Label></td>
                                                            <td width="8%" align="right">
                                                                <asp:Label ID="lblNov" runat="server" Text='<%# bind("Nov") %>'></asp:Label></td>
                                                            <td width="9%" align="right">
                                                                <asp:Label ID="lblDec" runat="server" Text='<%# bind("Dec") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblJan" runat="server" Text='<%# bind("Jan") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblFeb" runat="server" Text='<%# bind("Feb") %>'></asp:Label></td>
                                                            <td width="7%" align="right">
                                                                <asp:Label ID="lblMar" runat="server" Text='<%# bind("Mar") %>'></asp:Label></td>
                                                            <td width="10%" align="right" style="border-left: #cccccc 1px solid; padding-left: 10px;">
                                                                <asp:Label ID="lblTotal" Font-Bold="true" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="24%" style="line-height: 22px;" class="black-hdr">
                                    C) Perquisite</td>
                                <td width="76%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblPerquisite" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
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
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="30%" style="line-height: 22px;" class="black-hdr">
                                    D) Gross Salary (A+C)
                                </td>
                                <td width="70%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblGrossSalary" Style="font-size: 11px;" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
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
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td class="black-hdr" style="line-height: 22px;">
                                    E) Less Exemption Under Sec-10</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="td-head">
                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                            <tr>
                                <td width="0%">
                                    &nbsp;</td>
                                <td width="13%">
                                    House Rent Allowance
                                </td>
                                <td width="7%">
                                    <span class="txt06">:</span> Sec-10</td>
                                <td width="13%">
                                    &nbsp;</td>
                                <td width="67%">
                                    <asp:Label ID="lblHRARec" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="txt06" style="padding-left: 6px;">
                                    Total Rent Paid (p.a)
                                </td>
                                <td class="txt06">
                                    :</td>
                                <td align="right" style="padding-right: 6px;">
                                    <asp:Label CssClass="txt06" ID="lblTotRentPaid" runat="server" Style="font-weight: bold;
                                        font-size: 10px;"></asp:Label></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="txt06" style="padding-left: 6px;">
                                    HRA Received
                                </td>
                                <td class="txt06">
                                    :</td>
                                <td align="right" style="padding-right: 6px;">
                                    <asp:Label CssClass="txt06" ID="lblHRARecL" runat="server" Style="font-weight: bold;
                                        font-size: 10px;"></asp:Label></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="txt06" style="padding-left: 6px;">
                                    40% Of Basic
                                </td>
                                <td class="txt06">
                                    :</td>
                                <td align="right" style="padding-right: 6px;">
                                    <asp:Label CssClass="txt06" ID="lblPerBasic" runat="server" Style="font-weight: bold;
                                        font-size: 10px;"></asp:Label></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="txt06" style="padding-left: 6px;">
                                    Rent Paid&gt;10% Basic
                                </td>
                                <td class="txt06">
                                    :</td>
                                <td align="right" style="padding-right: 6px;">
                                    <asp:Label CssClass="txt06" ID="lblRentPaidBasic" runat="server" Style="font-weight: bold;
                                        font-size: 10px;"></asp:Label></td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Intrest US 20
                                </td>
                                <td class="black-hdr">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Transport Allowance</td>
                                <td>
                                    <span class="txt06">:</span> Sec-10 (14)
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblConvAss" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Medical Assistance</td>
                                <td>
                                    <span class="txt06">:</span> Sec-10</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblMedAss" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Helper Allowance
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblhelperAll" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Uniform Allowance</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblUniform" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Tax free allowance
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblTaxFreeAll" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    LTA NON TAXABLE
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblLTA" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Medical Reim.</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblMedRem" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    Telephone Reim.</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblTelRem" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="td-head">
                        <table width="100%" border="0" cellspacing="1" cellpadding="1" style="border: #E0E0E0 1px solid;">
                            <tr>
                                <td width="6%" height="22">
                                    &nbsp;</td>
                                <td width="19%">
                                    &nbsp;</td>
                                <td width="6%">
                                    &nbsp;</td>
                                <td width="12%">
                                    &nbsp;</td>
                                <td width="7%">
                                    &nbsp;</td>
                                <td width="11%">
                                    &nbsp;</td>
                                <td width="6%">
                                    &nbsp;</td>
                                <td width="13%">
                                    &nbsp;</td>
                                <td width="11%" align="right" class="td-head" style="color: red;">
                                    Sub Total :
                                </td>
                                <td width="9%" align="right" style="padding-right: 3px;">
                                    <asp:Label ID="lblTotalexmption" Text="0.0" runat="server" CssClass="td-head" ForeColor="Red"
                                        Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="33%" style="line-height: 22px;" class="black-hdr">
                                    F) Income From Previous Employer
                                </td>
                                <td width="67%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="td-head">
                        <table width="100%" border="0" cellspacing="1" cellpadding="1">
                            <tr>
                                <td width="0%">
                                    &nbsp;</td>
                                <td width="2%" align="center">
                                    &nbsp;</td>
                                <td width="8%" align="left">
                                    Total Income :
                                </td>
                                <td width="6%">
                                    0.0</td>
                                <td width="8%">
                                    Income Tax :
                                </td>
                                <td width="5%">
                                    0.0</td>
                                <td width="7%">
                                    Prof. Tax :
                                </td>
                                <td width="5%">
                                    0.0</td>
                                <td width="3%">
                                    PF :
                                </td>
                                <td width="35%">
                                    0.0</td>
                                <td width="21%" class="black-hdr">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="57%" height="20" align="right" class="td-head" style="color: red;">
                                                Sub Total :
                                            </td>
                                            <td width="43%" align="right" style="padding-right: 3px;">
                                                <asp:Label ID="lblIncomeFromPrevEmp" Text="0.0" runat="server" CssClass="td-head"
                                                    ForeColor="Red" Style="font-weight: bold; font-size: 11px;"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="31%" style="line-height: 22px;" class="black-hdr">
                                    G) Income after Exemption (D-E+F)
                                </td>
                                <td width="69%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblIncomeInoneAfterExmp" Style="font-weight: bold; font-size: 11px;"
                                                    runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="31%" style="line-height: 22px;" class="black-hdr">
                                    H) Less Deduction Under Section-16
                                </td>
                                <td width="69%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblDedUndr16" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="51%" style="line-height: 22px;" class="black-hdr">
                                    I) Income Chargable Under the head salaries ( G-H )
                                </td>
                                <td width="49%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblIncomeChraUnHdSalar" Style="font-weight: bold; font-size: 11px;"
                                                    runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="41%" style="line-height: 22px;" class="black-hdr">
                                    J) Add any other income declared by employee
                                </td>
                                <td width="59%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblAddAnIncdecByEmp" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="45%" style="line-height: 22px;" class="black-hdr">
                                    K) Gross Total Income( Professional Tax - I+J )
                                </td>
                                <td width="55%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblGrossTotalIncome" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="36%" style="line-height: 22px;" class="black-hdr">
                                    L) Deduction under chapter VI A
                                </td>
                                <td width="64%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdTaxDedundCh6A" BorderWidth="0" runat="server" AutoGenerateColumns="False"
                            Width="100%" ShowFooter="False" Style="margin-top: 0px" OnRowDataBound="TaxDedu">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                                            <tr>
                                                <td width="23%" style="line-height: 22px;" class="black-hdr">
                                                    Investment</td>
                                                <td width="17%" class="black-hdr">
                                                    Section</td>
                                                <td width="60%" class="black-hdr">
                                                    Deductible
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <FooterTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #EAEAEA;">
                                            <tr>
                                                <td width="23%" style="line-height: 22px;" class="black-hdr">
                                                    Sub Total
                                                </td>
                                                <td width="17%">
                                                    &nbsp;
                                                </td>
                                                <td width="60%" align="right">
                                                    <asp:Label ID="lblAmountT" runat="server" CssClass="txt-red" Font-Bold="true"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="23%" style="line-height: 22px;">
                                                    <asp:Label ID="lblSD" runat="server" Text='<%# bind("section_detail") %>'></asp:Label>
                                                </td>
                                                <td width="17%">
                                                    <asp:Label ID="lblSN" runat="server" Text='<%# bind("section_name") %>'></asp:Label>
                                                </td>
                                                <td width="60%">
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# bind("a_amount") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="td-head">
                                    <table width="100%" border="0" cellspacing="1" cellpadding="1" style="border: #E0E0E0 1px solid;">
                                        <tr>
                                            <td width="14%">
                                                PF</td>
                                            <td width="26%" class="black-hdr">
                                                &nbsp;</td>
                                            <td width="13%">
                                                <asp:Label ID="lblPfTotal" Text="0.0" runat="server" Font-Bold="false" Style="font-size: 11px;"></asp:Label>
                                            </td>
                                            <td width="0%" class="black-hdr">
                                                &nbsp;</td>
                                            <td width="1%" class="black-hdr">
                                                &nbsp;</td>
                                            <td width="0%" class="black-hdr">
                                                &nbsp;</td>
                                            <td width="25%" class="black-hdr">
                                                &nbsp;</td>
                                            <td width="21%" class="black-hdr">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="57%" height="20" align="right" class="td-head" style="color: red;">
                                                            Sub Total :
                                                        </td>
                                                        <td width="43%" align="right" style="padding-right: 3px;">
                                                            <asp:Label ID="lblAmountT" Text="0.0" runat="server" CssClass="td-head" ForeColor="Red"
                                                                Style="font-weight: bold; font-size: 11px;"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="80%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="31%" style="line-height: 22px;" class="black-hdr">
                                    M) Taxable Income
                                </td>
                                <td width="69%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblTaxableIncome" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="31%" style="line-height: 22px;" class="black-hdr">
                                    N) Round Off nearest 10 rupee
                                </td>
                                <td width="69%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #FFFFFF;">
                                        <tr>
                                            <td width="85%" height="20" align="right" class="td-head">
                                                Total :
                                            </td>
                                            <td width="13%" align="right" style="padding-right: 3px;" class="td-head">
                                                <asp:Label ID="lblRoundOff" Style="font-weight: bold; font-size: 11px;" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="black-hdr">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="20%" style="line-height: 22px;" class="black-hdr">
                                    O)Total Tax to be paid
                                </td>
                                <td width="80%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="td-head">
                        <table width="100%" border="0" cellspacing="1" cellpadding="1" style="border: #E0E0E0 1px solid;">
                            <tr>
                                <td width="6%" height="22">
                                    Paid Till :
                                </td>
                                <td width="19%">
                                    <asp:Label ID="lblPaidTill" Text="0.0" runat="server" Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                                <td width="6%">
                                    Raw Tax :
                                </td>
                                <td width="12%">
                                    <asp:Label ID="lblRawTax" Text="0.0" runat="server" Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                                <td width="7%">
                                    Surcharge :
                                </td>
                                <td width="11%">
                                    <asp:Label ID="lblsurcharge" Text="0.0" runat="server" Style="font-weight: bold;
                                        font-size: 11px;"></asp:Label>
                                </td>
                                <td width="6%">
                                    Edu. Cess :
                                </td>
                                <td width="13%">
                                    <asp:Label ID="lblEducess" Text="0.0" runat="server" Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                                <td width="11%" align="right" class="td-head" style="color: red;">
                                    Sub Total :
                                </td>
                                <td width="9%" align="right" style="padding-right: 3px;">
                                    <asp:Label ID="lblTTPaid" Text="0.0" runat="server" CssClass="td-head" ForeColor="Red"
                                        Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                            <tr>
                                <td width="20%" style="line-height: 22px;" class="black-hdr">
                                    P)Total Tax to be due
                                </td>
                                <td width="80%">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="td-head">
                        <table width="100%" border="0" cellspacing="1" cellpadding="1" style="border: #E0E0E0 1px solid;">
                            <tr>
                                <td width="6%" height="22">
                                    Paid Till :
                                </td>
                                <td width="19%">
                                    <asp:Label ID="lblPaidTillD" Text="0.0" runat="server" Style="font-weight: bold;
                                        font-size: 11px;"></asp:Label>
                                </td>
                                <td width="6%">
                                    Raw Tax :
                                </td>
                                <td width="12%">
                                    <asp:Label ID="lblRawTaxD" Text="0.0" runat="server" Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                                <td width="7%">
                                    Surcharge :
                                </td>
                                <td width="11%">
                                    <asp:Label ID="lblsurchargeD" Text="0.0" runat="server" Style="font-weight: bold;
                                        font-size: 11px;"></asp:Label>
                                </td>
                                <td width="6%">
                                    Edu. Cess :
                                </td>
                                <td width="13%">
                                    <asp:Label ID="lblEducessD" Text="0.0" runat="server" Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                                <td width="11%" align="right" class="td-head" style="color: red;">
                                    Sub Total :
                                </td>
                                <td width="9%" align="right" style="padding-right: 3px;">
                                    <asp:Label ID="lblTTDue" Text="0.0" runat="server" CssClass="td-head" ForeColor="Red"
                                        Style="font-weight: bold; font-size: 11px;"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnGenPDF" runat="server" Visible="false" Text="Save To PDF" OnClick="btnGenPDF_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
