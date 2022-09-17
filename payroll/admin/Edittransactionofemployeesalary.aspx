<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edittransactionofemployeesalary.aspx.cs" Inherits="payroll_admin_Edittransactionofemployeesalary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script type="text/javascript" >
        function UserDeleteConfirmation() {
            return confirm("Are you sure you want to delete this Transaction?");
        }
    </script>
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
                                                            Edit Transaction Info Form
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
                                                            Edit Transaction Info
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
                                                            Month<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="25%">
                                                            <asp:Label Font-Bold="true" ID="Lblmonthh" runat="server" ></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Year<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="25%">
                                                            <asp:Label Font-Bold="true" ID="lblyear" runat="server"  ></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Disbursement Type<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="25%">
                                                            <asp:Label Font-Bold="true" ID="Lbldisbursementtype" runat="server"  ></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123" width="25%">
                                                          Amount Type<span style="color:Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="25%">
                                                            <asp:Label Font-Bold="true" ID="lblamountpaytype" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Transaction Details
                                                        </td>
                                                        <td class="frm-rght-clr123" width="25%">
                                                           <asp:TextBox ID="Txttransactiodetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                        <td class="frm-lft-clr123" width="25%">
                                                         <span id="bankinfo" runat="server" >Bank Name</span>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="25%">
                                                           <asp:Label ID="lblbanknamme" runat="server" Text="" Font-Bold="true" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" height="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123" style="width:20%">&nbsp;</td>
                                                        <td class="frm-rght-clr123" align="left" colspan="3" >
                                                            <asp:Button ID="btnupdate" OnClick="btnupdate_Click" runat="server" CssClass="button" 
                                                                ToolTip="Click here to Submit" style="text-indent:-17px !important;"  Text="Update">
                                                             </asp:Button>    
                                                            <asp:Button ID="Btndeletetransaction"  OnClientClick="if ( ! UserDeleteConfirmation()) return false;"  OnClick="Btndeletetransaction_Click" runat="server" CssClass="button"
                                                                Text="Delete"></asp:Button>                                              
                                                              <asp:Button ID="btnback" OnClick="btnback_Click" runat="server" CssClass="button"
                                                                Text="Back"></asp:Button>                                                             
                                                            <asp:Button ID="btnbankletter" OnClick="btnbankletter_Click" runat="server" style="text-indent:-15px" CssClass="button"
                                                                Text="Bank Letter"></asp:Button>
                                                            <asp:Button ID="btnbankcoverletter"  OnClick="btnbankcoverletter_Click" runat="server" style="text-indent:-17px" CssClass="button"
                                                                 Text="Cover Letter"></asp:Button>
                                                          
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
                                                            <asp:GridView ID="Editbankgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px" AllowPaging="True"
                                                              OnRowDataBound="Editbankgrid_RowDataBound"  PageSize="15" EmptyDataText="Sorry No Records Found" OnPageIndexChanging="Editbankgrid_PageIndexChanging">
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
                                                                     <asp:TemplateField HeaderText="Cheque No">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                            Width="13%" />
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Txtcheckno" Text='<%# Bind("ChequeNo")%>' runat="server" ></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
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
                                                    <tr>
                                                        <td style="height:5px" >
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td  width="25%">&nbsp;</td>
                                                                    <td  width="25%">&nbsp;</td>
                                                                    <td  width="25%"align="center">Total Amount</td>
                                                                    <td  width="25%" align="left" ><asp:Label ID="lbltotalamountpaid" Font-Bold="true" runat="server" Text=""></asp:Label></td>
                                                                </tr>
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
        <Triggers>
         <asp:PostBackTrigger ControlID="btnbankcoverletter" /> 
             <asp:PostBackTrigger ControlID="btnbankletter" /> 
</Triggers>      
    </asp:UpdatePanel>
    
    </form>
</body>
</html>

