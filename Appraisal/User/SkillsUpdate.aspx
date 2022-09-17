<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="SkillsUpdate.aspx.cs" Inherits="Appraisal_User_SkillsUpdate" %>

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
                                            Skills/Competencies Update
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnView" runat="server" Visible="false" Text="View" CssClass="button" OnClick="btnView_Click"></asp:Button>
                                            <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="button" OnClick="btnCreate_Click"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="trCreate" runat="server" visible="false">
                            <td>
                                <div>
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tbody>
                                            <tr>
                                                <td height="5" valign="top">
                                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Skills/Competencies Obtained<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtSkills" TextMode="MultiLine" Style="resize: none;" runat="server" CssClass="blue1" MaxLength="20" Width="430px" Height="55px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSkills"
                                                                        Display="None" SetFocusOnError="True" ToolTip="Enter Skills" ValidationGroup="c"
                                                                        ErrorMessage="Enter Skills" Width="6px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Competencies obtained<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtCompetencies" Width="430px" Style="resize: none;" Height="55px" TextMode="MultiLine" runat="server" CssClass="blue1" MaxLength="20"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCompetencies"
                                                                        Display="None" SetFocusOnError="True" ToolTip="Enter Competencies" ValidationGroup="c"
                                                                        ErrorMessage="Enter Competencies" Width="6px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Self-Rating<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList CssClass="select" runat="server" ID="ddlSelfRating">
                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">&nbsp;
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div id="divcreate" runat="server">
                                                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" ValidationGroup="c" OnClick="btnAdd_Click"></asp:Button>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" OnClick="btnReset_Click"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="c"
                                                                            ShowMessageBox="true" ShowSummary="false" />
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td height="5">
                                                    <asp:GridView ID="grdAdd" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                        CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                                        EmptyDataText="No record(s) found.."
                                                        BorderColor="#C9DFFB" OnRowCommand="grdAdd_RowCommand">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Skills">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSkills" runat="server" Style="word-wrap: break-word;" Text='<%# Bind("Skills") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="70%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Self Rating">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action">
                                                                <ItemTemplate>
                                                                     <asp:LinkButton ID="btnActive" class="link01" runat="server" ToolTip="Active" CommandName="Remove"
                                                                            CommandArgument='<%# Eval("Id") %>'>Delete</asp:LinkButton>
                                                                </ItemTemplate>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
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
                                                <td align="right">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnSubmit_Click"></asp:Button>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr id="trView" runat="server" visible="true">
                            <td class="head-2">
                                <div id="dvResult" style="overflow: auto; border: 0px #000 solid;"
                                    runat="server">
                                    <asp:GridView ID="grdResult" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                        CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                        EmptyDataText="No record(s) found.."
                                        BorderColor="#C9DFFB" OnPageIndexChanging="grdResult_PageIndexChanging" PageSize="10">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Skills">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSkills" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("Skills") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="60%" />
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
                                                    <asp:Label ID="lblMR" runat="server" Text='<%# Bind("ManagerRating") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
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

