<%@ Page Title="Appraisal Form" Language="C#" MasterPageFile="~/Appraisal/UserMaster.master" AutoEventWireup="true" CodeFile="KRAFormApprove.aspx.cs" Inherits="Appraisal_Admin_KRAFormApprove" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tbody>
            <tr>
                <td valign="top" class="blue-brdr-1">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="3%">
                                <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                            </td>
                            <td class="txt01">Pending Appraisal Form
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
                                            <asp:GridView ID="grdKRAForm" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                PageSize="10" BorderWidth="1px"
                                                EmptyDataText="No Record(s) Found"
                                                BorderColor="#c9dffb"  OnRowCommand="grd_RowCommand" OnRowDataBound="grdKRAForm_RowDataBound">
                                                <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Appraisal ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDuration" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("EmployeeName") %>'></asp:Label>
                                                            <asp:Label ID="lblEmpCode" Visible="false" runat="server" Text='<%# Eval("EmpCode") %>'></asp:Label>
                                                            <asp:Label ID="lblID" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                                            <asp:Label ID="lblCurrentLevel" runat="server" Visible="false" Text='<%# Eval("CurrentLevel") %>'></asp:Label>
                                                            <asp:Label ID="lblIsPeer" runat="server" Visible="false" Text='<%# Eval("IsPeer") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                    </asp:TemplateField> 
                                                    <asp:TemplateField HeaderText="Period">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="txtApproverComment" runat="server" Text='<%# UtilMethods.ConvertDateTimeddmmmmyyyy(Eval("CreatedOn")) %>'></asp:Label>--%>
                                                            <asp:Label ID="lblPeriod" runat="server" Text='<%# Eval("KRADuration") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                                    </asp:TemplateField>                                                   
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="txtApproverComment" runat="server" Text='<%# UtilMethods.ConvertDateTimeddmmmmyyyy(Eval("CreatedOn")) %>'></asp:Label>--%>
                                                            <asp:Label ID="txtApproverComment" runat="server" Text='Pending at RM'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="left" Width="20%" CssClass="frm-rght-clr1234" />
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

