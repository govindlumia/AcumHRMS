<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employeepaystructuredetails.aspx.cs"
    Inherits="payroll_admin_employeepaystructuredetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
@import "../../css/example.css";
</style>

    <script type="text/javascript" src="../../js/tabber.js"></script>

    <script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <link href="../../css/blue1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax" style="top:160px;">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img alt="" src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                    <td class="txt01" width="20%">
                                        View Details</td>
                                    <td align="right" class="txt-red" width="65%">
                                        <span id="message" runat="server"></span>&nbsp;</td>
                                    <td align="right" class="link05" width="8%">
                                        <a href="paystructureempview.aspx">Back</a>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="txt02" height="33px" colspan="2">
                            Employee Details</td>
                    </tr>
                    <tr>
                        <td height="5" valign="top" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="14%">
                                        Code</td>
                                    <td class="frm-rght-clr123" width="10%">
                                        <asp:Label ID="empCode" runat="server"></asp:Label></td>
                                    <td class="frm-lft-clr123" width="14%">
                                        Name</td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="empName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="6">
                                    </td>
                                </tr>
                                <tr>
                                   <%-- <td class="frm-lft-clr123" width="14%">
                                        Branch</td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:Label ID="empBranch" runat="server"></asp:Label></td>
                                    <td class="frm-lft-clr123" width="14%%">
                                        Department</td>
                                    <td class="frm-rght-clr123" width="20%">
                                        <asp:Label ID="empDepartment" runat="server"></asp:Label></td>--%>
                                    <td class="frm-lft-clr123" width="15%">
                                        Designation</td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:Label ID="empDesignation" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="6">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" width="14%">
                                        PF</td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:Label ID="lbl_pf" runat="server"></asp:Label>
                                    </td>
                                    <td class="frm-lft-clr123" width="11%">
                                        ESI</td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="lbl_esi" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="6">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" width="14%">
                                        Applied From</td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:Label ID="lbl_mth_yr" runat="server"></asp:Label>
                                    </td>
                                    <td class="frm-lft-clr123" width="11%">
                                        Applied To</td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="lbl_mth_yr_t" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="txt02" height="33px" colspan="2">
                            Employee Pay Structure Details</td>
                    </tr>
                    <tr>
                        <td class="head-2" valign="top" colspan="2">
                            <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                CellPadding="4" DataKeyNames="Head_Name" Width="100%" AutoGenerateColumns="False"
                                BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !">
                                <Columns>
                                    <asp:TemplateField HeaderText="Head Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("Head_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calculation Type" Visible="false">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("cal_type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate (%)" Visible="false">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("Rate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Basis">
                                       
                                       <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                       
                                               <ItemStyle Width="12%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                               
                                               <ItemTemplate>
                                                    
                                                    <asp:Label ID="l4" runat="server" Text ='<%# Bind ("Basis") %>'></asp:Label>
                                      
                                                </ItemTemplate>
                                
                                </asp:TemplateField> --%>
                                     <asp:TemplateField HeaderText="Type">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rounding Method">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind ("Rounding_Method") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" />
                                <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <%--</ContentTemplate>
</asp:UpdatePanel>--%>
            </div>
        </form>
    </div>
</body>
</html>
