<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave_approval.aspx.cs" Inherits="leave_leave_approval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                                Leave
                            </td>
                               <td align="right">
<%--   <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
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
                            <td height="22" valign="top" class="txt02">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="27%" class="txt02">
                                            Leave Approval
                                        </td>
                                        <td width="73%" align="right" class="txt-red">
                                            <span id="message" runat="server"></span>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <!--New Work --> 
                           <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="txt02">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="22" width="27%" class="txt02">
                                        Compensatory Off Approval
                                    </td>
                                    <td width="73%" align="right" class="txt-red">
                                        <span id="Span1" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="head-2" style="height: 10px">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%"
                                EmptyDataText="No Data Available !" DataSourceID="SqlDataSource3" 
                                DataKeyNames="id" >
                                <HeaderStyle CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#linkleaveCompOff(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), DataBinder.Eval(Container.DataItem, "leavestatus").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("todate","{0:dd-MMM-yyyy}") %>'></asp:Label>
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
                <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    runat="server" SelectCommand="sp_leave_fetchcompoff_summary" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                        <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" DefaultValue="0" />
                        <asp:QueryStringParameter Name="hr" QueryStringField="hr" Type="Int32" DefaultValue="0" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            </tr>




                        <tr>
                            <td valign="top" class="head-2" style="height: 10px">
                                <asp:GridView ID="leave_approval_grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%"
                                    EmptyDataText="No Data Available !" DataSourceID="SqlDataSource1" 
                                    DataKeyNames="id" onrowdatabound="leave_approval_grid_RowDataBound">
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Code">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Leave Type">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), DataBinder.Eval(Container.DataItem, "leavestatus").ToString())%>
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
                    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                        runat="server" SelectCommand="sp_leave_fetchleavesummary" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                            <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" />
                            <asp:QueryStringParameter Name="hr" QueryStringField="hr" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
 

 <%-- <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="txt02">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="22" width="27%" class="txt02">
                                        Compensatory Off Approval
                                    </td>
                                    <td width="73%" align="right" class="txt-red">
                                        <span id="Span3" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="head-2" style="height: 10px">
                            <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%"
                                EmptyDataText="No Data Available !" DataSourceID="SqlDataSource3" 
                                DataKeyNames="id" >
                                <HeaderStyle CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <%#linkleaveCompOff(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "leavename").ToString(), Convert.ToInt32(DataBinder.Eval(Container.DataItem, "id")), DataBinder.Eval(Container.DataItem, "leavestatus").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("fromdate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="l6" runat="server" Text='<%# Bind("todate","{0:dd-MMM-yyyy}") %>'></asp:Label>
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
                <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    runat="server" SelectCommand="sp_leave_fetchcompoff_summary" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                        <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" DefaultValue="0" />
                        <asp:QueryStringParameter Name="hr" QueryStringField="hr" Type="Int32" DefaultValue="0" />
                    </SelectParameters>
                </asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            </tr>
        </table>
    </div>--%>




    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="5" valign="top">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="20" valign="top" class="txt02">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" class="txt02" style="height: 13px">
                                            <asp:Label ID="Label1" runat="server" Text="Compensatory Off Credit Approval/Rejection"></asp:Label>
                                        </td>
                                        <td width="50%" align="right" class="txt-red" style="height: 13px">
                                            <span id="Span2" runat="server"></span>&nbsp;
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
                            <td height="10" valign="top" class="head-2">
                                <asp:GridView ID="grdApproveRejectCompOff" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BorderWidth="0px" CellPadding="4" Width="100%" EmptyDataText="No Data Available !"
                                    DataKeyNames="id" PageSize="100" 
                                    OnRowCommand="leave_approval_grid_RowCommand" 
                                    onrowdatabound="grdApproveRejectCompOff_RowDataBound">
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="EmpCode">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "empcode")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmpName">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l4" runat="server" Text='<%# Bind("empname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l5" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Day">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="6%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l6" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reason">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="40%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:Label ID="l7" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="14%" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btn_ter" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")%>'
                                                    CommandName="accept" CssClass="link05" Text="Accept" />l
                                                <asp:LinkButton ID="Button1" runat="server" CommandArgument='<%#Eval("id") + "," + Eval("empcode")%>'
                                                    CommandName="reject" CssClass="link05" Text="Reject" />
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
        </table>
    </div>
    </form>
</body>
</html>
