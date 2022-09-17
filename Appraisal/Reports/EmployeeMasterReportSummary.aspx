<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="EmployeeMasterReportSummary.aspx.cs" Inherits="Appraisal_Reports_EmployeeMasterReportSummary" %>

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
                                            Employee Master Report Summary
                                        </td>
                                        <td align="right">&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="20" valign="top" class="txt02">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="27%" class="txt02" height="22">Employee Information
                                                        </td>
                                                        <td width="73%" align="right" class="txt-red">
                                                            <span id="message" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="19%" class="frm-lft-clr123">Employee Name
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                        <td width="1%" rowspan="7">&nbsp;
                                                        </td>
                                                        <td width="18%" class="frm-lft-clr123">Employee Code
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 5px"></td>
                                                        <td colspan="2" style="height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="19%" class="frm-lft-clr123">Category Name
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                        <td width="18%" class="frm-lft-clr123">Designation
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lbl_Designation" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 5px"></td>
                                                        <td colspan="2" style="height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="19%" class="frm-lft-clr123">Date of Joining
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lbl_dated" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                        <td width="19%" class="frm-lft-clr123">Location
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lbl_Location" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 5px"></td>
                                                        <td colspan="2" style="height: 5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="19%" class="frm-lft-clr123">Current Experience
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lblCE" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                        <td width="19%" class="frm-lft-clr123">Last Promotion Year
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:Label ID="lblLPY" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td height="20" valign="top" class="txt02">
                                <table width="100%">
                                    <tr>
                                        <td width="27%" class="txt02" height="22">Rating History
                                        </td>
                                        <td width="73%" align="right" class="txt-red">
                                            <span id="Span1" runat="server"></span>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="head-2">
                                <asp:GridView ID="grdResult" runat="server" AllowPaging="false" Width="100%" HorizontalAlign="Left"
                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                    EmptyDataText="no record(s) found.."
                                    BorderColor="#C9DFFB">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Appraisal Year">
                                            <ItemTemplate>
                                                <asp:Label ID="lblYear" runat="server" Text='<%# Bind("year") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Bind("designationname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rating">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRating" runat="server" Text='<%# Bind("Rating") %>'></asp:Label>
                                                -
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("RatingName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Duration">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDuration" runat="server" Text='<%# Bind("Duration") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Promotion">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPromotion" runat="server" Text='<%# Bind("Promotion") %>'></asp:Label>
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

