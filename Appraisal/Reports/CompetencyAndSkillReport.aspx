<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="CompetencyAndSkillReport.aspx.cs" Inherits="Appraisal_Reports_CompetencyAndSkillReport" %>

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
                                            Competency and Skill Report
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
                                            <Ajax:CalendarExtender ID="CalendarExtender8" runat="server"
                                                PopupButtonID="Image8" TargetControlID="txtSDate" Enabled="True" Format="dd-MMM-yyyy">
                                            </Ajax:CalendarExtender>
                                        </td>

                                        <td class="frm-rght-clr123" width="20%">
                                            <asp:TextBox ID="txtEDate" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                            <asp:Image
                                                ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                            <Ajax:CalendarExtender ID="CalendarExtender1" runat="server"
                                                PopupButtonID="Image1" TargetControlID="txtEDate" Enabled="True" Format="dd-MMM-yyyy">
                                            </Ajax:CalendarExtender>
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
                                    BorderColor="#C9DFFB" OnPageIndexChanging="grdResult_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumber" runat="server" Text='<%# Bind("EmpName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Skills / Competency Obtained">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSkills" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("Skills") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="50%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Competency Obtained" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompetencies" runat="server" Text='<%# Bind("Competencies") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Self Rating's">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="13%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Manager Rating's">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMR" runat="server" Text='<%# Bind("ManagerRating") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" Width="13%" />
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

