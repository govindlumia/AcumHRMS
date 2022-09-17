<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewpaymenttransactiondetails.aspx.cs" Inherits="payroll_admin_Viewpaymenttransactiondetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>View Transaction Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                                                           View Transactions Details
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
                                <td valign="middle" class="txt02" height="23">
                                    &nbsp;Search Transactions</td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="11%">
                                                Payment Type</td>
                                            <td class="frm-rght-clr123" width="11%">
                                                 <asp:DropDownList ID="Ddlpaytype" runat="server" CssClass="select" 
                                                    Width="130px">
                                                     <asp:ListItem Value="0">---Select Type---</asp:ListItem>
                                                     <asp:ListItem Value="1">Bank</asp:ListItem>
                                                     <asp:ListItem Value="2">Cheque</asp:ListItem>
                                                     <asp:ListItem Value="3">Cash</asp:ListItem>
                                                </asp:DropDownList>
                                            <td class="frm-lft-clr123" width="11%">
                                                Month</td>
                                            <td class="frm-rght-clr123" width="19%">
                                                 <asp:DropDownList ID="Ddlmonth" runat="server" CssClass="select" 
                                                    Width="130px">
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
                                            </td>
                                             <td class="frm-lft-clr123" width="11%">
                                                Financial year</td>
                                            <td class="frm-rght-clr123" width="11%">
                                               <asp:DropDownList ID="ddlfinancialyear" runat="server" CssClass="select" DataSourceID="SqlDataSource1" 
                                                     DataTextField="financialyear" DataValueField="financialyear" OnDataBound="ddlfinancialyear_DataBound"  Width="130px">
                                                </asp:DropDownList>
                                               <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                SelectCommand="SELECT financial_year financialyear FROM tbl_payroll_tax_master  order by id desc"
                                                                ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"></asp:SqlDataSource>
                                            <td class="frm-rght-clr123" width="12%">
                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="10" valign="top">
                                </td>
                            </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="Viewtransactiongrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px" AllowPaging="True" OnRowDataBound="Viewtransactiongrid_RowDataBound"
                                                              PageSize="15" EmptyDataText="Sorry No Records Found" OnRowCommand="Viewtransactiongrid_RowCommand" OnPageIndexChanging="Viewtransactiongrid_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Transaction ID " >
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltransactioid" Visible="false" runat="server" Text='<%# Bind("Id")%>'></asp:Label>
                                                                             <asp:Label ID="lbltransactionref"  runat="server" Text='<%# Bind("TRANSACTION_REF_ID")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mode of Payment ">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="10%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LBLDISBURSEMENTTYPE" runat="server" Text='<%# Bind("DISBURSEMENTTYPE")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date of Disbursement ">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LBLCREATEDATE" runat="server" Text='<%# Bind("CREATEDATE")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Salary Month ">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                           <asp:Label ID="LBLMONTH" runat="server" Text='<%# Bind("MONTH")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Financial Year">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LBLYEAR" runat="server" Text='<%# Bind("YEAR")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="Amount">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="LBLTOTALAMOUNT" runat="server" Text='<%# Bind("TOTALAMOUNT")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>                                                                   
                                                                       <asp:ButtonField CommandName="Edit Info" Text="Edit Info" ButtonType="Button" ControlStyle-CssClass="frm-lft-clr123 frm-rght-clr1234" />
                                                                      <asp:ButtonField CommandName="Bank Letter" Text="Bank Letter" ButtonType="Button" ControlStyle-CssClass="frm-lft-clr123 frm-rght-clr1234" />
                                                                      <asp:ButtonField CommandName="Cover Letter" Text="Cover Letter" ButtonType="Button" ControlStyle-CssClass="frm-lft-clr123 frm-rght-clr1234" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                <RowStyle Height="5px" />
                                                            </asp:GridView>
                                                           <%-- ----------------------CHECK GRIDVIEW-----------------%>
                                                            
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
            
    </form>
</body>
</html>
