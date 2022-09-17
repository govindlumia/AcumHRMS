<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="PendingTrainingUpdates.aspx.cs" Inherits="Appraisal_User_PendingTrainingUpdates" %>

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
                                            Pending Training Update
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
                                <asp:GridView ID="grdPending" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                    EmptyDataText="no record(s) found.."
                                    BorderColor="#C9DFFB" OnRowDataBound="grdPending_RowDataBound" OnPageIndexChanging="grdPending_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkBox" />
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Training Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrainingName" ToolTip='<%# Bind("Id") %>' runat="server" Text='<%# Bind("TrainingName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Conducted By">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConductedBy" runat="server" Text='<%# Bind("ConductedBy") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Duration">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromDate" runat="server" Text='<%# Bind("FromDate") %>'></asp:Label>
                                                -
                                                    <asp:Label ID="lblToDate" runat="server" Text='<%# Bind("ToDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="18%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Certification Received">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCertificationReceived" runat="server" Text='<%# Bind("CertificationReceived") %>'></asp:Label>
                                                <asp:Label ID="lblCertificationValidDate" runat="server" Text='<%# Bind("CertificationValidDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="hdnValue" Value='<%# Bind("Id") %>' />
                                                <a runat="server" id="lnkView" href="" class="link05">View</a>
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
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Approved Training Update
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
                                                        <asp:TextBox runat="server" ID="txtAName" Text=""></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="80%">
                                                        <asp:Button ID="btnSearchApproved" runat="server" CssClass="button" Text="Search" OnClick="btnSearchApproved_Click" />&nbsp;
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
                                    BorderColor="#C9DFFB" OnRowDataBound="grdApproved_RowDataBound" OnPageIndexChanging="grdApproved_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Training Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTrainingName" runat="server" Text='<%# Bind("TrainingName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Conducted By">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConductedBy" runat="server" Text='<%# Bind("ConductedBy") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Duration">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFromDate" runat="server" Text='<%# Bind("FromDate") %>'></asp:Label>
                                                -
                                                    <asp:Label ID="lblToDate" runat="server" Text='<%# Bind("ToDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="18%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Certification Received">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCertificationReceived" runat="server" Text='<%# Bind("CertificationReceived") %>'></asp:Label>
                                                <asp:Label ID="lblCertificationValidDate" runat="server" Text='<%# Bind("CertificationValidDate") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="hdnValue" Value='<%# Bind("Id") %>' />
                                                <a runat="server" id="lnkView" href="" class="link05">View</a>
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

