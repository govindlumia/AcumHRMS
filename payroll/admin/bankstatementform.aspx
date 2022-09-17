<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="bankstatementform.aspx.cs"
    Inherits="payroll_admin_bankstatementform" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divajax" style="left: 250px; top: 150px">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
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
                                                            Bank Statement Form
                                                        </td>
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
                                                            Create Bank Statement
                                                        </td>
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
                                                            Year<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" DataSourceID="SqlDataSource12"
                                                                DataTextField="financialyear" DataValueField="financialyear" OnDataBound="dd_year_DataBound"
                                                                CssClass="select" Width="180px">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                SelectCommand="SELECT financial_year financialyear FROM tbl_payroll_tax_master  order by id desc"
                                                                ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Month<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="select" Width="180px">
                                                      <asp:ListItem Value="0">---Select Month---</asp:ListItem>
                                                     <asp:ListItem Value="1">Apr</asp:ListItem>
                                                     <asp:ListItem Value="2">May</asp:ListItem>
                                                     <asp:ListItem Value="3">Jun</asp:ListItem>
                                                     <asp:ListItem Value="4">Jul</asp:ListItem>
                                                     <asp:ListItem Value="5">Aug</asp:ListItem>
                                                     <asp:ListItem Value="6">Sep</asp:ListItem>
                                                     <asp:ListItem Value="7">Oct</asp:ListItem>
                                                     <asp:ListItem Value="8">Nov</asp:ListItem>
                                                     <asp:ListItem Value="9">Dec</asp:ListItem>
                                                     <asp:ListItem Value="10">Jan</asp:ListItem>
                                                     <asp:ListItem Value="11">Feb</asp:ListItem>
                                                     <asp:ListItem Value="12">Mar</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlmonth"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Operator="NotEqual" ValueToCompare="0" ToolTip="Select Reimbursement" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                           Disbursement Type<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="Ddldisbursementtype" runat="server" CssClass="select" Width="180px">
                                                                <asp:ListItem Value="0">---Select Type---</asp:ListItem>
                                                                <asp:ListItem Value="1">Bank</asp:ListItem>
                                                                <asp:ListItem Value="2">Cheque</asp:ListItem>
                                                                <asp:ListItem Value="3">Cash</asp:ListItem>
                                                            </asp:DropDownList>
                                                             <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="Ddldisbursementtype"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Operator="NotEqual" ValueToCompare="0" ToolTip="Select Disbursement Type" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                  <%--  <tr>
                                                        <td class="frm-lft-clr123">
                                                            Location
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:DropDownList ID="dd_branch" runat="server" DataSourceID="SqlDataSourceBranch"
                                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound"
                                                                CssClass="select" Width="180px">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_branch"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Operator="NotEqual" ValueToCompare="0" ToolTip="Select Branch" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_BranchMaster]"
                                                                ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Type<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="ddl_reimbursement_type" runat="server" CssClass="select" Width="180px">
                                                                <asp:ListItem Value="0">Salary</asp:ListItem>
                                                                <asp:ListItem Value="1">Reimbursement</asp:ListItem>
                                                                <asp:ListItem Value="2">Bonus</asp:ListItem>
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Bank Name
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="ddl_bank_name" runat="server"  DataSourceID="SqlDataSource1"
                                                                DataTextField="bankname" DataValueField="branchcode" OnDataBound="ddl_bank_name_DataBound"
                                                                CssClass="select" Width="180px">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                SelectCommand="SELECT id as [branchcode],[bankname] as bankname FROM tbl_payroll_bank "
                                                                ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123" style="width:20%">&nbsp;</td>
                                                        <td class="frm-rght-clr123" align="left">
                                                            <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="button" 
                                                                ToolTip="Click here to Submit" style="text-indent:-17px !important;" ValidationGroup="v" Text="Submit">
                                                             </asp:Button>
                                                              &nbsp;
                                                              <asp:Button ID="lnkResign" OnClick="lnkResign_Click" runat="server" CssClass="button"
                                                                ValidationGroup="v" Text="Resigned"></asp:Button>
                                                              &nbsp;
                                                             <asp:Button ID="btnviewtransaction" OnClick="btnviewtransaction_Click" runat="server" CssClass="button" 
                                                                ToolTip="Click here to view transactions"   Text="View">
                                                             </asp:Button> &nbsp;
                                                            <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="button"
                                                                Text="Reset"></asp:Button>
                                                            <asp:Button ID="btnexport" Visible="false" OnClick="btnexport_Click" runat="server" CssClass="button"
                                                                ValidationGroup="v" Text="Export"></asp:Button>
                                                          
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height:5px" ></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 123px" valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="frm-lft-clr123">
                                                            Payment Advice For
                                                            <asp:Label ID="lblmonth" runat="server" Text=""></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">
                                                            <asp:Label ID="lblbankname" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%">
                                                            <asp:GridView ID="bankgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px" AllowPaging="True"
                                                              OnRowDataBound="bankgrid_RowDataBound"  PageSize="15" EmptyDataText="Sorry No Records Found" OnPageIndexChanging="bankgrid_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Select">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />
                                                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
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
                                                                    <asp:TemplateField HeaderText="Account Number">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblACName" runat="server" Text='<%# Bind("acno")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Cheque No">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Txtcheckno" runat="server" Text=""></asp:TextBox>
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
                                                           <%-- ----------------------CHECK GRIDVIEW-----------------%>
                                                            
                                                        </td>
                                                    </tr>
                                                      <tr id="transactioncommentssection" runat="server">
                                                        <td class="frm-lft-clr123">
                                                             <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                            <tr>
                                                            <td class="frm-lft-clr123"><asp:Label ID="lblname" runat="server" Text="Enter Breif Details About Transaction"></asp:Label>
                                                            </td>
                                                                <td>
                                                                <asp:TextBox ID="Txttransactiondetails" runat="server" TextMode="MultiLine" Width="273px"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator ID="reqTxttransactiondetails" runat="server" ControlToValidate="Txttransactiondetails"  ValidationGroup="submit"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Brief Details"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="BtnDeliversal" OnClick="BtnDeliversal_Click" ValidationGroup="submit" runat="server" CssClass="button"
                                                                 Text="Submit"></asp:Button>
                                                             
                                                                </td>
                                                                
                                                            </tr>
                                                            </tbody>
                                                            </table>


                                                        </td>
                                                        
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td width="25%">
                                                            &nbsp;
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
        <triggers>
<Asp:PostBackTrigger ControlID="btnexport"/>
</triggers>
    </asp:UpdatePanel>
    
    </form>
</body>
</html>
