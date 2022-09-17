<%@ Page Title="Role" Language="C#" MasterPageFile="~/Appraisal/AppraisalMaster.master" AutoEventWireup="true" CodeFile="AppraisalRole.aspx.cs" Inherits="Appraisal_Admin_AppraisalRole" %>


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
                                            Appraisal Role
                                        </td>
                                        <td align="right"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5">&nbsp;</td>
                        </tr>
                        <tr runat="server" visible="false">
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
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Role <span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtRole" CssClass="blue1" Width="100px" runat="server" ValidationGroup="c"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="C" runat="server" ControlToValidate="txtRole"
                                                                        SetFocusOnError="True" ToolTip="Select Customer"
                                                                        ErrorMessage="Required" Width="6px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
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
                                                                                    <asp:Button ID="btnSave" runat="server" ValidationGroup="C" Text="Save" CssClass="button" OnClick="btnSave_Click"></asp:Button>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnCancel" runat="server" Text="Reset" CssClass="button" OnClick="btnCancel_Click"></asp:Button>
                                                                            </td>
                                                                            <td align="left" colspan="2">Mandatory Fields (<img alt="" src="../../images/error1.gif" />)</td>
                                                                        </tr>
                                                            </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="5">&nbsp;</td>
                        </tr>

                    </tbody>
                </table>
            </div>
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
                                                            EmptyDataText="no record(s) found.." OnPageIndexChanging="grdAppraisalPeriod_PageIndexChanging"
                                                            BorderColor="#c9dffb" OnRowCommand="grdAppraisalPeriod_RowCommand">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Role">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRole" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="40%" />
                                                                </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="Created By">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPeriodType" runat="server" Text='<%# Bind("CreatedBy") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CreatedOn">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("CreatedOn") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Edit">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="20%" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" class="link01" runat="server" ToolTip="Edit" CommandName="EditRecord"
                                                                            CommandArgument='<%# Eval("AppraisalRoleId") %>'>Edit</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="10%" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" class="link01" runat="server" CommandName="DeleteRecord"
                                                                            CommandArgument='<%# Eval("AppraisalRoleId") %>'>Delete </asp:LinkButton>
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



