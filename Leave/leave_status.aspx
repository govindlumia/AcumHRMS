<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave_status.aspx.cs" Inherits="leave_leave_status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Approval</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
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
                                Leave Status
                            </td>
                            <td align="right">
                                       <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                                    </td>
                        </tr>
                    </table>
                </td>
            </tr>
        <%--    <tr>
                <td height="5" valign="top">
        Leave Type : 
        <asp:CheckBoxList runat="server" ID="chk_lvtype" RepeatDirection="Horizontal">
       <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
       <asp:ListItem Text="Approved" Value="6"></asp:ListItem>
        <asp:ListItem  Text="Rejected" Value="3"></asp:ListItem>
        <asp:ListItem  Text="Cancelled" Value="2"></asp:ListItem>
        </asp:CheckBoxList>
                </td>
            </tr>--%>
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr >
                    <td height="5" class="txt02">
                     Leave Detail
                    </td>
                    </tr>
                        <tr>
                            <td height="5" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td height="10" valign="top" class="head-2">
                                <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderWidth="0px" CellPadding="4" Width="100%" EmptyDataText="No Data Available !"
                                    DataSourceID="SqlDataSource2" DataKeyNames="id" PageSize="100" 
                                    onrowdatabound="leave_approval_grid_RowDataBound" >
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Leave Type">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "leave_status")))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave Status">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("leavestatus") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Date">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Date">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of Days">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                        DeleteCommand="DELETE FROM [tbl_leave_createleave] WHERE [leaveid] = @leaveid"
                        InsertCommand="INSERT INTO [tbl_leave_createleave] ([leavetype]) VALUES (@leavetype)"
                        ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetchleavesummary_user"
                        SelectCommandType="StoredProcedure" UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
                        <DeleteParameters>
                            <asp:Parameter Name="leaveid" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="leavetype" Type="String" />
                            <asp:Parameter Name="leaveid" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="leavetype" Type="String" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                            <asp:SessionParameter DefaultValue="" Name="empcode" SessionField="empcode" Type="String" />
                         <asp:QueryStringParameter DefaultValue="" Name="leavestatus" QueryStringField="leavestatus" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
             <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr >
                    <td height="5" class="txt02">
                    Compensatory Off Detail
                    </td>
                    </tr>
                        <tr>
                            <td height="5" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td height="10" valign="top" class="head-2">
                                <asp:GridView ID="compoff_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderWidth="0px" CellPadding="4" Width="100%" EmptyDataText="No Data Available !"
                                    DataSourceID="SqlDataSource1" DataKeyNames="id" PageSize="100" 
                                    onrowdatabound="compoff_approval_grid_RowDataBound">
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Leave Type">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#linkCompOff(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "approval_status")))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave Status">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("leavestatus") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From Date">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To Date">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l6" runat="server" Text='<%# Bind("todate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="No of Days">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("nod") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                        DeleteCommand="DELETE FROM [tbl_leave_apply_compoff] WHERE [leaveid] = @leaveid"
                        ProviderName="System.Data.SqlClient" SelectCommand="sp_leave_fetchCompoffsummary_user"
                        SelectCommandType="StoredProcedure">
                        <DeleteParameters>
                            <asp:Parameter Name="leaveid" Type="Int32" />
                        </DeleteParameters>
                        <SelectParameters>
                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                            <asp:SessionParameter DefaultValue="" Name="empcode" SessionField="empcode" Type="String" />
                            <asp:QueryStringParameter DefaultValue="0" Name="leavestatus" QueryStringField="leavestatus"
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
