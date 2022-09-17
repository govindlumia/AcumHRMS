<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="TrainingReport.aspx.cs" Inherits="Appraisal_Reports_TrainingReport" %>

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
                                            Training Report
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
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="20%">Start Date
                                        </td>
                                        <td class="frm-lft-clr123" width="20%">End Date
                                        </td>
                                        <td class="frm-lft-clr123" width="20%">Company
                                        </td>
                                        <td class="frm-lft-clr123" width="20%">Emp Name/Code
                                        </td>
                                        <td class="frm-lft-clr123" colspan="2" width="20%">Designation
                                        </td>
                                    </tr>
                                    <tr>

                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:TextBox ID="txtSDate" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                            <asp:Image
                                                ID="Image8" runat="server" ImageUrl="~/images/clndr.gif" />
                                            <Ajax:calendarextender id="CalendarExtender8" runat="server"
                                                popupbuttonid="Image8" targetcontrolid="txtSDate" enabled="True" format="dd-MMM-yyyy">
                                                                            </Ajax:calendarextender>
                                        </td>

                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:TextBox ID="txtEDate" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                            <asp:Image
                                                ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                            <Ajax:calendarextender id="CalendarExtender1" runat="server"
                                                popupbuttonid="Image1" targetcontrolid="txtEDate" enabled="True" format="dd-MMM-yyyy">
                                                                            </Ajax:calendarextender>
                                        </td>

                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:DropDownList runat="server" CssClass="select" ID="ddl_company" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddl_company_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>

                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                        </td>

                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="select">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
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
                                <asp:GridView ID="grdResult" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                    CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                    EmptyDataText="no record(s) found.."
                                    BorderColor="#C9DFFB" OnRowCommand="grdResult_RowCommand" OnPageIndexChanging="grdResult_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Code">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblempcode" runat="server" Text='<%# Bind("empcode") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblEmpName" runat="server" Text='<%# Bind("EmpName") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldesignationname" runat="server" Text='<%# Bind("designationname") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkView" runat="server" CommandName="Summary" CommandArgument='<%# Bind("EmpCode") %>' Text="View"></asp:LinkButton>
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
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                                    (<asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("EmpCode") %>'></asp:Label>)
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Training Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTrainingName" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("TrainingName") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="Venue">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVenue" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("Venue") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Conducted By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblConductedBy" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("ConductedBy") %>'></asp:Label>
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

                                            <asp:TemplateField HeaderText="Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("Comments") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblComments" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="5%" />
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

