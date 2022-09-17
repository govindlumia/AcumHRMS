<%@ Page Title="Rating Scale" Language="C#" MasterPageFile="~/Appraisal/AppraisalMaster.master" AutoEventWireup="true" CodeFile="AppraisalRatingScale.aspx.cs" Inherits="Appraisal_Admin_AppraisalRatingScale" %>

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
                                            Appraisal Rating Scale
                                        </td>
                                        <td align="right"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
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
                                                                <td class="frm-lft-clr123">Scale From<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="drpScaleFrom" CssClass="select" runat="server">                                                                                                                                                                                                                   
                                                                    </asp:DropDownList>                                                                                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Scale To<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="drpScaleTo" CssClass="select" runat="server" >                                                                                                                                              
                                                                    </asp:DropDownList>                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Rating<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_rating" runat="server" ContentEditable="true" CssClass="blue1" Width="100px" ValidationGroup="c"></asp:TextBox> 
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_rating"
                                                                    Display="None" SetFocusOnError="True" ToolTip="Rating" ValidationGroup="c"
                                                                    ErrorMessage="Give Rating" Width="6px"></asp:RequiredFieldValidator>   

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
                                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" ValidationGroup="c" OnClick="btnSave_Click"></asp:Button>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" OnClick="btnReset_Click"></asp:Button>
                                                                            </td>
                                                                            <td align="left" colspan="2">
                                                                             Mandatory Fields (<img alt="" src="../../images/error1.gif" />)</td>
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
                                                <td height="5"></td>
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
                                              <%--  <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="13%">Company
                                                            </td>
                                                            <td class="frm-rght-clr123" width="25%">
                                                                <asp:DropDownList CssClass="select" runat="server" ID="drpCompanySearch"></asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" />&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" valign="top"></td>
                                            </tr>--%>
                                            <tr>
                                                <td>
                                                    <div id="dvResult" style="overflow: auto; height: 490px; border: 0px #000 solid;"
                                                        runat="server">
                                                        <asp:GridView ID="grdAppraisalRatingScale" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                                            EmptyDataText="no record(s) found.."  OnPageIndexChanging="grdAppraisalRatingScale_PageIndexChanging"
                                                            BorderColor="#C9DFFB" OnRowCommand="grdAppraisalRatingScale_RowCommand">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Scale From">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScaleFrom" runat="server" Text='<%# Bind("ScaleFrom") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Scale To">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblScaleTo" runat="server" Text='<%# Bind("ScaleTo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Rating">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRating" runat="server" Text='<%# Bind("Rating") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Action">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="10%" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" class="link01" runat="server" ToolTip="Edit" CommandName="EditRecord"
                                                                            CommandArgument='<%# Eval("AppraisalRatingScaleId") %>'>Edit</asp:LinkButton> |
                                                                        <asp:LinkButton ID="btnDelete" class="link01" runat="server" ToolTip="Delete" CommandName="DeleteRecord"
                                                                            CommandArgument='<%# Eval("AppraisalRatingScaleId") %>'>Delete</asp:LinkButton>
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


