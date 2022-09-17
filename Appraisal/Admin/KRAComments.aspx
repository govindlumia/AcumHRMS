<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KRAComments.aspx.cs" Inherits="Appraisal_Admin_KRAComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Css/blue1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                                    </td>
                                    <td class="txt01">KRA Comments
                                    </td>
                                    <td align="right"></td>
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
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <div id="divKRA" style="overflow: auto; height: 490px; border: 0px #000 solid;"
                                                runat="server">
                                                <asp:GridView ID="grdResult" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                    PageSize="10" BorderWidth="1px"
                                                    EmptyDataText="No Records found"
                                                    BorderColor="#c9dffb">
                                                    <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Comments By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDuration" runat="server" style="word-wrap:break-word;"  Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="80%" />
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
                                            <div id="divPromotion" style="overflow: auto; height: 490px; border: 0px #000 solid;"
                                                runat="server">
                                                <asp:GridView ID="grdPromotion" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                    PageSize="10" BorderWidth="1px"
                                                    EmptyDataText="No Records found"
                                                    BorderColor="#c9dffb">
                                                    <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Comment By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lnkUser" runat="server" Text='<%# Eval("User") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Post Appraisal Action">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAction" runat="server" Text='<%# Eval("Promotion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblYes" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDuration" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="50%" />
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
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
