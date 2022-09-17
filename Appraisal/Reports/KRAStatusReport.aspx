<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="KRAStatusReport.aspx.cs" Inherits="Appraisal_Reports_KRAStatusReport" %>

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
                                            KRA Status Report
                                        </td>
                                        <td align="right">&nbsp;
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
                                    BorderColor="#C9DFFB" OnRowCommand="grdResult_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>                                               
                                                <asp:LinkButton ID="lnkStatus" runat="server" CommandName="Summary" CommandArgument='<%# Bind("Id") %>' Text='<%# Bind("Status") %>'></asp:LinkButton>                                                
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="50%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Number">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumber" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
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
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <div id="divSummary" runat="server" visible="false">
                            <tr>
                                <td class="blue-brdr-1">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="txt01">
                                                <img alt="" src="../../images/header-icon.png" />
                                                Summary
                                            </td>
                                            <td align="right"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="head-2">
                                    <asp:GridView ID="grdSummary" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                        CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                        EmptyDataText="no record(s) found.."
                                        BorderColor="#C9DFFB">
                                        <Columns>
                                            <asp:TemplateField HeaderText="User">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUser" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Appraisal Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStartDate" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TAT - This Stage">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblThisStage" runat="server" Text='<%# Bind("ThisStage") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="TAT - Total">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
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
                        </div>

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


