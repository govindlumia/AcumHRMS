<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BalanceHistory.aspx.cs" Inherits="Leave_BalanceHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Balance history</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
     <script type="text/javascript" src="js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" class="blue-brdr-1">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="3%">
                                <img src="../images/employee-icon.jpg" width="16" height="16" />
                            </td>
                            <td class="txt01">
                                 Balance Detail
                            </td>
                            <td align="right">
                                       <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                                    </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    
                        <tr>
                            <td height="10" valign="top" class="head-2">
                                <asp:GridView ID="Bind_leave_balance" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderWidth="0px" CellPadding="4" Width="100%" EmptyDataText="No Data Available !"
                                     DataKeyNames="employeecode" PageSize="100" >
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Code">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("employeecode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee  Name">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("designationname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                             <ItemTemplate>
                                           <a href="#" onclick="newPopup('my_balance_leave.aspx?empcode=<%#DataBinder.Eval(Container.DataItem, "employeecode")%>')"
                                           class="link05">View Detail</a>
                                              </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                  
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
