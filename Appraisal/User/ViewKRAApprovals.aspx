<%@ Page Title="Approve" Language="C#" MasterPageFile="~/Appraisal/UserMaster.master" AutoEventWireup="true" CodeFile="ViewKRAApprovals.aspx.cs" Inherits="Appraisal_Admin_ViewKRAApprovals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td valign="top" class="blue-brdr-1">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="3%">
                                <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                            </td>
                            <td class="txt01">KRA Form
                            </td>
                            <td align="right">
                                <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td class="head-2">
                    <div id="GridDept" runat="server" style="overflow: hidden; height: 490px; display: block;">
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <div id="dvResult" style="overflow: auto; height: 490px; border: 0px #000 solid;"
                                            runat="server">
                                            <asp:GridView ID="grdAppraisalPeriod" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                PageSize="10" BorderWidth="1px"
                                                EmptyDataText="no record(s) found.."
                                                BorderColor="#c9dffb" OnRowDataBound="grdAppraisalPeriod_RowDataBound" OnRowCommand="grdAppraisalPeriod_RowCommand">
                                                <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("EmpCode") %>'></asp:Label>
                                                            <asp:Label ID="lblEmpCode" runat="server" Visible="false" Text='<%# Eval("EmpCode") %>'></asp:Label>
                                                            <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName1" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                            <asp:Label ID="lblEmpCode1" runat="server" Visible="false" Text='<%# Eval("EmpCode") %>'></asp:Label>
                                                            <asp:Label ID="lblID1" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                    </asp:TemplateField>
                                                   <%-- <asp:TemplateField HeaderText="Duration">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDuration" runat="server" Text='<%# Eval("Duration") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Created On">
                                                        <ItemTemplate>
                                                            <asp:Label ID="txtApproverComment" runat="server" Text='<%# UtilMethods.ConvertDateTimeddmmmmyyyy(Eval("CreatedOn")) %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="left" Width="10%" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="View" CommandArgument='<%# Eval("ID") %>' Text="View">
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>
                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                <RowStyle></RowStyle>
                                                <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                                    VerticalAlign="Top" />
                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                    NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>

