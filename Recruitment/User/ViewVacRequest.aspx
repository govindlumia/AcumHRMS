<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="ViewVacRequest.aspx.cs" Inherits="Recruitment_User_ViewVacRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_message" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxtoolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="blue-brdr-1">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td>
                                    <img alt="" src="../../images/header-icon.png" />
                                    Vacancy Request Status
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="2px">
                    </td>
                </tr>
            </table>
            <fieldset id="Fieldset1" runat="server">
                <legend><b>Search</b></legend>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td class="frm-lft-clr123">
                            Vacancy ID
                            <asp:TextBox ID="txtVacancyID" runat="server" CssClass="input" Width="80px" MaxLength='20'></asp:TextBox>
                        </td>
                        <td class="frm-lft-clr123">
                            From Date
                            <asp:TextBox ID="txt_FromDate" runat="server" CssClass="input" Width="80px" EnableViewState="false"></asp:TextBox>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                                ToolTip="click to open calender" /><ajaxtoolkit:CalendarExtender ID="CalendarExtender1"
                                    runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_FromDate" PopupButtonID="Image1">
                                </ajaxtoolkit:CalendarExtender>
                        </td>
                        <td class="frm-lft-clr123">
                            To Date
                            <asp:TextBox ID="txt_Todate" runat="server" CssClass="input" Width="80px" EnableViewState="false"></asp:TextBox>
                            <img src="../../images/Calendar_scheduleHS.png" id="Image2" /><ajaxtoolkit:CalendarExtender
                                ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_Todate"
                                PopupButtonID="Image2">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                        <td class="frm-lft-clr123">
                            Location
                            <asp:DropDownList runat="server" Width="80px" ID="ddl_joblocation" CssClass="select"
                                OnDataBound="ddljoblocation_DataBound">
                            </asp:DropDownList>
                        </td>
                        <td class="frm-lft-clr123">
                            Vaccancy Status
                            <asp:DropDownList runat="server" Width="80px" ID="ddlStatus" CssClass="select" OnDataBound="ddlStatus_DataBound">
                            </asp:DropDownList>
                        </td>
                        <td class="frm-lft-clr123">
                            Approval Status
                            <asp:DropDownList runat="server" Width="80px" ID="ddlAppStatus" CssClass="select"
                                OnDataBound="ddlAppStatus_DataBound">
                            </asp:DropDownList>
                        </td>
                        <td class="frm-lft-clr123">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td height="2px">
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset id="Fieldset2" runat="server">
                <legend><b>Result</b></legend>
                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td align="right" width="150px">
                            <%-- <asp:ImageButton ID="ImgBtnDownload" ImageUrl="~/images/excel.gif" runat="server"
                                            OnClick="ImgBtnDownload_Click" />--%>
                        </td>
                        <td align="right" width="200px">
                            <label>
                                <asp:LinkButton ID="lnkFirst" runat="server" SkinID="linkGrid" CommandName="First"
                                    ForeColor="#013366" OnCommand="ChangePage"><b>First</b></asp:LinkButton>
                                &nbsp;&nbsp;|&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkPre" runat="server" SkinID="linkGrid" CommandName="Previous"
                                    ForeColor="#013366" OnCommand="ChangePage"><b>Previous</b></asp:LinkButton>
                                &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" SkinID="linkGrid" runat="server"
                                    ForeColor="#013366" CommandName="Next" OnCommand="ChangePage"><b>Next</b></asp:LinkButton>
                                &nbsp;&nbsp;|&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkLast" runat="server" SkinID="linkGrid" CommandName="Last"
                                    ForeColor="#013366" OnCommand="ChangePage"><b>Last</b></asp:LinkButton>
                            </label>
                        </td>
                        <td width="100px" align="right">
                            <span class="p-page">( Page -
                                <asp:Label ID="lblCurrentPage" CssClass="p-page1" runat="server"></asp:Label>
                                of
                                <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
                                ) </span>
                        </td>
                        <%--<td width="150px" align="right">
                                        <b>Page Size:</b>
                                        <asp:DropDownList ID="ddlPageSize" runat="server" EnableViewState="true" CssClass="select"
                                            Width="80" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>--%>
                    </tr>
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td>
                            <asp:GridView ID="GvVacRequest" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                Width="100%" OnRowDataBound="GvVacRequest_RowDataBound" EmptyDataText="No Record(s)">
                                <Columns>
                                    <asp:TemplateField HeaderText="Vacancy ID">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="2%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVac_ID" runat="server" SkinID="gridLabel" Text='<%# bind("Vac_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vacancy name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" SkinID="gridLabel" Text='<%# bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitle" runat="server" SkinID="gridLabel" Text='<%# bind("designationname") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblLocation" runat="server" SkinID="gridLabel" Text='<%# bind("branch_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Positions">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Center" VerticalAlign="Top"
                                            Width="1%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCount" runat="server" SkinID="gridLabel" Text='<%# bind("Count") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Closed">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Center" VerticalAlign="Top"
                                            Width="1%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblClosed" runat="server" SkinID="gridLabel" Text='<%# bind("Closed") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="4%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDate" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Created By">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedByName" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedByName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vacancy Status">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="4%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVacStatusID" Visible="false" runat="server" SkinID="gridLabel"
                                                Text='<%# bind("VacStatusID") %>'></asp:Label>
                                            <asp:Label ID="lblVacStatus" runat="server" SkinID="gridLabel" Text='<%# bind("Dsca") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approval Status">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="4%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAppStatusName" runat="server" SkinID="gridLabel" Text='<%# bind("AppStatusName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Add Candidate">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="2%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAddCan" runat="server" SkinID="linkGrid" Text="Add" ToolTip="Add Candidate"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="2%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" SkinID="linkGrid" Text="Details" ToolTip="Details"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
