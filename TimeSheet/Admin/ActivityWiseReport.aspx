<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/Admin/TimesheetMaster.master"
    AutoEventWireup="true" CodeFile="ActivityWiseReport.aspx.cs" Inherits="TimeSheet_Admin_ActivityWiseReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        .style2
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #013366;
            width: 184px;
            border-left: 1px solid #c9dffb;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #c9dffb;
            border-bottom: 1px solid #c9dffb;
            padding-left: 5px;
            padding-right: 0;
            padding-top: 4px;
            padding-bottom: 4px;
            background: #edf5ff;
        }
    </style>
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
                                            Project Wise Report
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                        <tr>
                            <td height="10" align="right">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div >
                                    <div >
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
                                                                    <td class="frm-lft-clr123">
                                                                        Project Name <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:DropDownList runat="server" ID="ddl_project" Width="140px">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfv_ddl_project" runat="server" ControlToValidate="ddl_project"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Select Project" ValidationGroup="vg_main"
                                                                            InitialValue="0" ErrorMessage="Select Project" Width="6px"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Date Range
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td style="width: 10%">
                                                                                    From
                                                                                </td>
                                                                                <td style="width: 40%">
                                                                                    <asp:TextBox ID="txt_frmdate" runat="server" CssClass="blue1" Width="100px" ContentEditable="false"></asp:TextBox>&#160;<asp:Image
                                                                                        ID="img_cal_from" runat="server" ImageUrl="~/images/clndr.gif" /><asp:RequiredFieldValidator
                                                                                            ID="rfv_frm_date" runat="server" ControlToValidate="txt_frmdate" Display="Dynamic"
                                                                                            ErrorMessage="Enter From Date" SetFocusOnError="True" ToolTip="Enter From Date"
                                                                                            ValidationGroup="vg_main">
                                                                                        </asp:RequiredFieldValidator>
                                                                                    <Ajax:CalendarExtender ID="calex_frmdate" runat="server" PopupButtonID="img_cal_from"
                                                                                        TargetControlID="txt_frmdate" Enabled="True" Format="dd-MMM-yyyy">
                                                                                    </Ajax:CalendarExtender>
                                                                                </td>
                                                                                <td style="width: 10%">
                                                                                    To
                                                                                </td>
                                                                                <td style="width: 40%">
                                                                                    <asp:TextBox ID="txt_to_date" runat="server" CssClass="blue1" Width="100px" ContentEditable="false"></asp:TextBox>&#160;
                                                                                    <asp:Image ID="img_cal_to" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                                    <asp:RequiredFieldValidator ID="rfv_todate" runat="server" ControlToValidate="txt_to_date"
                                                                                        Display="Dynamic" ErrorMessage="Enter To Date" SetFocusOnError="True" ToolTip="Enter To Date"
                                                                                        ValidationGroup="vg_main">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <Ajax:CalendarExtender ID="Calext_todate" runat="server" PopupButtonID="img_cal_to"
                                                                                        TargetControlID="txt_to_date" Enabled="True" Format="dd-MMM-yyyy">
                                                                                    </Ajax:CalendarExtender>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Only include<br />
                                                                        approved Timesheet
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:CheckBox runat="server" ID="chk_Isapprove" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Button ID="btn_view" runat="server" Text="View" CssClass="button" 
                                                                                        ValidationGroup="vg_main" onclick="btn_view_Click">
                                                                                    </asp:Button>
                                                                                </td>
                                                                            </tr>
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vg_main"
                                                                                ShowMessageBox="true" ShowSummary="false" />
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="20">
                                                    </td>
                                                </tr>
                                             
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    
                        <tr>
                            <td class="head-2">
                                <div id="GridempStatus" runat="server" style="overflow: hidden; height: 490px; display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" valign="top">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123">
                                                    <table cellpadding="0" cellspacing="0" width="99%" border="0">
                                                        <tr align="right">
                                                            <td align="right">
                                                                <label>
                                                                   <%-- <asp:LinkButton ID="lnkPre" runat="server" SkinID="linkGrid" CommandName="Previous"
                                                                        ForeColor="#013366" OnCommand="ChangePage"><b>Previous</b></asp:LinkButton>
                                                                    &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" SkinID="linkGrid" runat="server"
                                                                        ForeColor="#013366" CommandName="Next" OnCommand="ChangePage"><b>Next</b></asp:LinkButton>--%>
                                                                </label>
                                                            </td>
                                                            <td width="100px" align="right">
                                                                <span class="p-page">( Page -
                                                                    <asp:Label ID="lblCurrentPage" CssClass="p-page1" runat="server"></asp:Label>
                                                                    of
                                                                    <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
                                                                    ) </span>
                                                            </td>
                                                            <td width="125px" align="right">
                                                                <b>Page Size:</b>
                                                           <%--     <asp:DropDownList ID="ddlPageSize" runat="server" EnableViewState="true" CssClass="select"
                                                                    Width="40" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                                </asp:DropDownList>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height: 3px;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="dvResult" style="overflow: scroll; height: 490px; border: 0px #000 solid;"
                                                        runat="server">
                                                        <asp:GridView ID="grd_report" runat="server" AllowPaging="True" Width="100%"
                                                            HorizontalAlign="Left" CellPadding="0" CaptionAlign="Left" AutoGenerateColumns="true"
                                                            AllowSorting="false" BorderWidth="1px"  BorderColor="#c9dffb" EmptyDataText="No Data Found">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>
                                                         
                                                            
                                                            </Columns>
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle></RowStyle>
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
                                    <td valign="bottom" align="center" class="txt01" height="23">
                                        Please Wait...
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
