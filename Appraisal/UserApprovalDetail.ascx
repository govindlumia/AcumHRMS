<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserApprovalDetail.ascx.cs" Inherits="Appraisal_UserApprovalDetail" %>
<div>
    <table width="100%">
        <tr>
            <td colspan="2" height="22" valign="top" class="txt02">Approver Hierarchy
            </td>
        </tr>
        <tr>
            <td class="head-2" valign="top" colspan="2">
                <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                    CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                    DataKeyNames="empcode" DataSourceID="SqlDataSource2"
                    >
                    <Columns>
                        <asp:TemplateField HeaderText="Approval Authority">
                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                            <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Code" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                            <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approver Name">
                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                            <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approval Authority" Visible="false">
                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                            <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                            <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="frm-lft-clr123" />
                    <FooterStyle CssClass="frm-lft-clr123" />
                    <RowStyle Height="5px" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                    runat="server" ProviderName="System.Data.SqlClient" SelectCommand="sp_Select_Approvertest"
                    SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <%--<asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" />   --%>
                        <asp:Parameter Name="empcode" DefaultValue="" />                     
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</div>
