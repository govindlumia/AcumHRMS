﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMaster.master" AutoEventWireup="true" CodeFile="AppraisalKRAHead.aspx.cs" Inherits="Appraisal_Admin_AppraisalKRAHead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
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
                                            Appraisal KRA
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
                                                                <td class="frm-lft-clr123">KRA Head<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_kra_head" runat="server" CssClass="blue1" MaxLength="100" Width="250px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_kra_head"
                                                                        Display="None" SetFocusOnError="True" ToolTip="Enter KRA Head" ValidationGroup="c"
                                                                        ErrorMessage="Enter KRA Head" Width="6px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Weightage<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_weightage" onkeypress="return isNumber(event)" MaxLength="3" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_weightage"
                                                                        Display="None" SetFocusOnError="True" ToolTip="Enter Weightage" ValidationGroup="c"
                                                                        ErrorMessage="Enter Weightage" Width="6px"></asp:RequiredFieldValidator>
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
                                                                                    <asp:Button ID="btnKRAHeadSave" runat="server" Text="Save" CssClass="button" ValidationGroup="c" OnClick="btnKRAHeadSave_Click"></asp:Button>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" OnClick="btnReset_Click"></asp:Button>Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                                                            </td>
                                                                            
                                                                        </tr>
                                                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="c"
                                                                            ShowMessageBox="true" ShowSummary="true" />
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
                                                <td>
                                                    <div id="dvResult" style="overflow: auto; height: 490px; border: 0px #000 solid;"
                                                        runat="server">
                                                        <asp:GridView ID="grdAppraisalKRAHead" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                                            EmptyDataText="no record(s) found.."   OnPageIndexChanging="grdAppraisalKRAHead_PageIndexChanging"
                                                            BorderColor="#C9DFFB" OnRowCommand="grdAppraisalKRAHead_RowCommand">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>                                                                
                                                                <asp:TemplateField HeaderText="KRA Head">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblKRAHead" runat="server" Text='<%# Bind("KRAHead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Weightage">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblWeightage" runat="server" ToolTip='<%# Bind("ID") %>' Text='<%# Bind("Weightage") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Action">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="10%" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnEdit" class="link01" runat="server" ToolTip="Active" CommandName="EditRecord"
                                                                            CommandArgument='<%# Eval("ID") %>'>Edit</asp:LinkButton> | 
                                                                         <asp:LinkButton ID="btnDelete" class="link01" runat="server" ToolTip="Active" CommandName="DeleteRecord"
                                                                            CommandArgument='<%# Eval("ID") %>'>Delete</asp:LinkButton>
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


