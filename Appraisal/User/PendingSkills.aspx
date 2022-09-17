<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="PendingSkills.aspx.cs" Inherits="Appraisal_User_PendingSkills" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="HomePage" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Pending Skills/Competencies Update
                                        </td>
                                        <td align="right">
                                            <asp:Button CssClass="button" ID="btnUpdate" runat="server" Text="Approve" OnClick="btnUpdate_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" colspan="2" width="20%">Employee Name/Code
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-rght-clr123" width="20%">
                                                        <asp:TextBox runat="server" ID="txtPName" Text=""></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="80%">
                                                        <asp:Button ID="btnPSearch" runat="server" CssClass="button" Text="Search" OnClick="btnPSearch_Click" />&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="head-2">
                                <asp:GridView ID="grdResult" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                    EmptyDataText="no record(s) found.."
                                    BorderColor="#C9DFFB" OnPageIndexChanging="grdResult_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chk" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Skills/Competencies">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSkills" runat="server" Style="word-wrap: break-word;" Text='<%# Bind("Skills") %>'></asp:Label>
                                                <asp:HiddenField runat="server" ID="hdnId" Value='<%# Bind("Id") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="50%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Competencies" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompetencies" runat="server" Text='<%# Bind("Competencies") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Self Rating">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Manager's Rating">
                                            <ItemTemplate>
                                                <asp:DropDownList CssClass="select" runat="server" ID="ddlMR">
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
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
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Approved Skills/Competencies Update
                                        </td>
                                        <td align="right"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" colspan="2" width="20%">Employee Name/Code
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-rght-clr123" width="20%">
                                                        <asp:TextBox runat="server" ID="txtSName" Text=""></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="80%">
                                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="head-2">
                                <asp:GridView ID="grdApproved" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                    EmptyDataText="no record(s) found.."
                                    BorderColor="#C9DFFB" OnPageIndexChanging="grdApproved_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Skills/Competencies">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSkills" runat="server" Style="word-wrap:break-word;" Text='<%# Bind("Skills") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="50%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Competencies" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompetencies" runat="server" Text='<%# Bind("Competencies") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Self Rating">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Manager's Rating">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSR" runat="server" Text='<%# Bind("ManagerRating") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
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
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img alt="" src="../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

