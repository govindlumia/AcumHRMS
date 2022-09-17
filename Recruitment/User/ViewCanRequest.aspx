<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="ViewCanRequest.aspx.cs" Inherits="Recruitment_User_ViewVacRequest" %>

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
                                    Candidate Request Status
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
                        <td class="frm-rght-clr123" width="5%">
                            Vacancy Code
                            <asp:TextBox ID="txtVacancyID" runat="server" CssClass="input" Width="80px" MaxLength='10'></asp:TextBox>
                        </td>
                        <td class="frm-rght-clr123" width="5%">
                            Candidate Code
                            <asp:TextBox ID="txtCanID" runat="server" CssClass="input" Width="80px" MaxLength='10'></asp:TextBox>
                        </td>
                        <td class="frm-rght-clr123" width="15%">
                            From Date
                            <asp:TextBox ID="txt_FromDate" runat="server" CssClass="input" Width="80px" EnableViewState="false"></asp:TextBox>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                                ToolTip="click to open calender" /><ajaxtoolkit:CalendarExtender ID="CalendarExtender1"
                                    runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_FromDate" PopupButtonID="Image1">
                                </ajaxtoolkit:CalendarExtender>
                        </td>
                        <td class="frm-rght-clr123" width="15%">
                            To Date
                            <asp:TextBox ID="txt_Todate" runat="server" CssClass="input" Width="80px" EnableViewState="false"></asp:TextBox>
                            <img src="../../images/Calendar_scheduleHS.png" id="Image2" /><ajaxtoolkit:CalendarExtender
                                ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_Todate"
                                PopupButtonID="Image2">
                            </ajaxtoolkit:CalendarExtender>
                        </td>
                        <td class="frm-rght-clr123" width="12%">
                            Status
                            <asp:DropDownList runat="server" Width="100px" ID="ddlStatus" CssClass="select" OnDataBound="ddlStatus_DataBound">
                            </asp:DropDownList>
                        </td>
                        <td class="frm-rght-clr123" width="15%" align="center">
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
                            <asp:GridView ID="GvCanRequest" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                Width="100%" OnRowDataBound="GvCanRequest_RowDataBound" EmptyDataText="No Record(s)">
                                <Columns>
                                    <asp:TemplateField HeaderText="Can Code">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="2%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbCAN_ID" runat="server" SkinID="gridLabel" Text='<%# bind("CAN_ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vacancy">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblVac_ID" runat="server" SkinID="gridLabel" Visible="false" Text='<%# bind("VAC_ID") %>'></asp:Label>
                                            <asp:Label ID="lblTitle" runat="server" SkinID="gridLabel" Text='<%# bind("DESIGNATIONNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Candidate Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCANNAME" runat="server" SkinID="gridLabel" Text='<%# bind("CANNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Upload By">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedByName" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedByName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Upload Date">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="3%" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCreatedDate" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Status">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="6%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDraft" Visible="false" runat="server" SkinID="linkGrid" ToolTip='<%# bind("CAN_STATUSID") %>' Text='<%# bind("CANSTATUSNAME") %>'></asp:LinkButton>
                                            <asp:Label ID="lblStatus" runat="server" SkinID="gridLabel" Text='<%# bind("CANSTATUSNAME") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="1%" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" SkinID="linkGrid" Text="Details" ToolTip="Click To View Details"></asp:LinkButton>
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
