<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/Admin/AdminMaster.master"
    AutoEventWireup="true" CodeFile="CanEvalSkillMaster.aspx.cs" Inherits="Recruitment_User_CanSkillMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="Div1" runat="server">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td valign="top">
                            <h3>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="3%">
                                            <img alt="" src="../../images/header-icon.png" />
                                        </td>
                                        <td width="79%" class="comment_text">
                                            Evaluation Skill Master
                                        </td>
                                        <td width="18%" align="right" class="txt-red">
                                            <asp:Button ID="lnkCreateView" CssClass="button" Text="Create" runat="server" OnClick="lnkCreateView_Click">
                                            </asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </h3>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divView" style="display: block;" runat="server">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Skill Name
                            <asp:TextBox ID="txtSkillSearch" CssClass="input" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnSearch" Text="Search" CssClass="button" runat="server" OnClick="btnSearch_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnClear" Text="Clear" CssClass="button" runat="server" OnClick="btnClear_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnEnable" Text="Enable All" CssClass="button" runat="server" OnClick="btnEnable_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnDisable" Text="Disable All" CssClass="button" runat="server" OnClick="btnDisable_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="dvResult" style="overflow: scroll; height: 500px;" runat="server">
                                <asp:GridView ID="grdResult" runat="server" AutoGenerateColumns="False" Width="100%"
                                    PageSize="50" AllowSorting="True" AllowPaging="True" CssClass="mGrid" PagerStyle-HorizontalAlign="Right"
                                    OnRowEditing="grdResult_RowEditing" OnRowUpdating="grdResult_RowUpdating" OnRowCancelingEdit="grdResult_RowCancelingEdit"
                                    OnRowDataBound="grdResult_RowDataBound" OnRowCommand="grdResult_RowCommand">
                                    <HeaderStyle Font-Bold="True" Font-Size="Small" ForeColor="#717171" HorizontalAlign="Left" />
                                    <RowStyle HorizontalAlign="Left" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="2%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" SkinID="gridLabel" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Skill Name">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="40%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSkillName" SkinID="gridLabel" runat="server" Text='<%# bind("Dsca") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtSkillName" CssClass="input" runat="server" Width="98%" MaxLength="50"
                                                    Text='<%# bind("Dsca") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSkillName"
                                                    Display="None" SetFocusOnError="True" ToolTip="Enter Skill Name" ValidationGroup="v"
                                                    Width="6px" ErrorMessage="Enter Skill Name"></asp:RequiredFieldValidator>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lnkStatus" SkinID="gridLabel" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="10%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" SkinID="linkGrid" Text="Edit" ToolTip="Edit"
                                                    CommandName="Edit"></asp:LinkButton>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" SkinID="linkGrid" ToolTip="Update"
                                                    ValidationGroup="v" CommandName="Update">Update</asp:LinkButton>
                                                &nbsp; | &nbsp;
                                                <asp:LinkButton ID="lnkCancel" runat="server" SkinID="linkGrid" CommandName="Cancel"
                                                    ToolTip="Cancel">Cancel</asp:LinkButton>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="10%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnk_disable" CommandArgument='<%# bind("ID") %>'
                                                    CommandName="disable" Text="Disable"></asp:LinkButton>
                                                <asp:LinkButton runat="server" ID="lnk_enable" CommandArgument='<%# bind("ID") %>'
                                                    CommandName="enable" Text="Enable"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        No Record(s) Found
                                    </EmptyDataTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:GridView>
                            </div>
                            <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                                runat="server" ValidationGroup="v"></asp:ValidationSummary>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divCreate" style="display: block;" runat="server">
                <table cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr-main">
                            Skill Name
                        </td>
                        <td class="frm-rght-clr123">
                            <asp:TextBox runat="server" ID="txtSName" CssClass="input" Width="40%" MaxLength="50">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSName"
                                Display="None" SetFocusOnError="True" ToolTip="Enter Skill Name" ValidationGroup="c"
                                Width="6px" ErrorMessage="Enter Skill Name"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="2px">
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-rght-clr123" colspan="2" align="center">
                            <asp:Button ID="Btnsubmit" runat="server" CssClass="button" ValidationGroup="c" Text="Submit"
                                OnClick="Btnsubmit_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="5">
                            <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
                                runat="server" ValidationGroup="c"></asp:ValidationSummary>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" Visible="true"
            runat="server">
            <ProgressTemplate>
                <div class="divajax">
                    <table width="100%">
                        <tr>
                            <td align="center" valign="top">
                                <img src="../../images/loading.gif" alt="update" height="20" width="20" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" align="center" height="32">
                                Please Wait...
                            </td>
                        </tr>
                    </table>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>
