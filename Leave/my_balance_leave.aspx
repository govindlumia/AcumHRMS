<%@ Page Language="C#" AutoEventWireup="true" CodeFile="my_balance_leave.aspx.cs"
    Inherits="leave_my_balance_leave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>My Balance Leave</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="8">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                     <tr> <td>
                     <table width="100%">
                     <tr>
                       <td width="3%">
                                <img src="../images/employee-icon.jpg" width="16" height="16" alt=""/>
                            </td>
                            <td class="txt01">
                              My Balance Leave
                            </td>
                            <td align="right">
                                       <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                                    </td>
                     </tr>
                     </table>
                     </td>
                          
                        </tr>
                       
                        <tr>
                            <td height="3">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 10px">
                                <asp:GridView ID="balancegrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%"
                                    EmptyDataText="No Data Available !" DataSourceID="SqlDataSource1">
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Leave">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="l1" runat="server" Text='<%# Bind("leavename")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entitled Days">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind("entitled_days")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Taken">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("taken") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Scheduled">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("scheduled") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Available">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="25%" />
                                            <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="25%" />
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    runat="server" SelectCommand="sp_leave_myballeaveEIL" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                        <asp:ControlParameter ControlID="hidd_empcode" Name="empcode" PropertyName="Value"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hidd_empcode" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
