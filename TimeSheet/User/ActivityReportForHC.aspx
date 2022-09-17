<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/User/TimesheetUser.master" AutoEventWireup="true" CodeFile="ActivityReportForHC.aspx.cs" Inherits="TimeSheet_User_ActivityReportForHC" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
          .completionList {

        border:solid 1px Gray;

        margin:0px;

        padding:3px;

        height: 120px;

       overflow-y:scroll;

        background-color: #FFFFFF;     

        } 

        .listItem {

        color: #191919;

        } 

        .itemHighlighted {

        background-color: #ADD6FF;       

        }
- 
    </style>
    <script type="text/javascript">
        function change_emp_ckey() {
            alert('Hi');
            //  document.getElementById('ACE_txt_employee').set_contextKey(this.value); 
        }
    </script>
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
                                            Activity Wise Report For HC
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
                                <div>
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
                                                                    <td class="frm-lft-clr123">
                                                                        Activity Name <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox runat="server" ID="txt_activity"></asp:TextBox>
                                                                        <Ajax:AutoCompleteExtender runat="server" ID="AutoCom_Project" MinimumPrefixLength="1"
                                                                            CompletionSetCount="10" CompletionInterval="1000" TargetControlID="txt_activity"
                                                                            ServiceMethod="AutoComplete_Activity" CompletionListHighlightedItemCssClass="itemHighlighted" 
                                                                            CompletionListCssClass="completionList" CompletionListItemCssClass="listItem"  UseContextKey="true">
                                                                        </Ajax:AutoCompleteExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                       Select Employee<span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                           <asp:TextBox runat="server" ID="txt_employee" 
                                                                               ontextchanged="txt_employee_TextChanged"  ></asp:TextBox>
                                                                        <Ajax:AutoCompleteExtender runat="server" ID="ACE_txt_employee" MinimumPrefixLength="1"
                                                                            CompletionSetCount="10" CompletionInterval="200" TargetControlID="txt_employee"
                                                                            CompletionListHighlightedItemCssClass="itemHighlighted"  ServicePath="ProjectReportForHC.aspx"
                                                                            CompletionListCssClass="completionList" CompletionListItemCssClass="listItem" UseContextKey="true"
                                                                            ServiceMethod="AutoComplete_Employee" >
                                                                        </Ajax:AutoCompleteExtender>
                                                                    </td>
                                                                </tr>

                                                                  <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Select Period<span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        From:
                                                                        <asp:TextBox runat="server" ID="txt_fromdate"></asp:TextBox>
                                                                        <asp:Image runat="server" ID="img_cal_fromdate" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                                                        <Ajax:CalendarExtender ID="CE_txt_from_date" runat="server" Animated="true" PopupButtonID="img_cal_fromdate"
                                                                            TargetControlID="txt_fromdate" Format="dd-MMM-yyyy">
                                                                        </Ajax:CalendarExtender>
                                                                        <span style="padding-left: 40px">To:
                                                                            <asp:TextBox runat="server" ID="txt_todate"></asp:TextBox>
                                                                            <asp:Image runat="server" ID="img_cal_todate" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                                                            <Ajax:CalendarExtender ID="CE_txt_to_date" runat="server" Animated="true" PopupButtonID="img_cal_todate"
                                                                                TargetControlID="txt_todate" Format="dd-MMM-yyyy">
                                                                            </Ajax:CalendarExtender>
                                                                        </span>
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
                                                                    <td class="frm-lft-clr123">
                                                                      Include Past Employee
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:CheckBox runat="server" ID="chk_past_emp" />
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
                                                                                    <asp:Button ID="btn_view" runat="server" Text="View" CssClass="button" ValidationGroup="vg_main"
                                                                                        OnClick="btn_view_Click"></asp:Button>&nbsp;
                                                                                        <span>
                                                                                        <asp:Button ID="btn_clearall"  runat="server"  Text="clear" CssClass="Button" 
                                                                                        onclick="btn_clearall_Click" ></asp:Button>
                                                                                        </span>
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
                                                            <td width="200px" >
                                                                <label>
                                                                    <%-- <asp:LinkButton ID="lnkPre" runat="server" SkinID="linkGrid" CommandName="Previous"
                                                                        ForeColor="#013366" OnCommand="ChangePage"><b>Previous</b></asp:LinkButton>
                                                                    &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" SkinID="linkGrid" runat="server"
                                                                        ForeColor="#013366" CommandName="Next" OnCommand="ChangePage"><b>Next</b></asp:LinkButton>--%>
                                                                </label>
                                                            </td>
                                                            <td width="300px" align="right"><span>
                                                            <%--Select Page Size:<asp:TextBox Text="10" Width="50" runat="server" ID="txt_pagesize"></asp:TextBox>--%>
                                                           </span> </td>
                                                            <td width="125px" align="center">
                                                            <%-- <asp:Button ID="btn_resize" runat="server" Text="Resize" CssClass="button" 
                                                                    ValidationGroup="vg_main" onclick="btn_resize_Click"
                                                                                       ></asp:Button>--%>
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
                                                        <asp:GridView ID="grd_report" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                            CellPadding="0" CaptionAlign="Left" AutoGenerateColumns="true" AllowSorting="false" 
                                                             PageSize="25" GridLines="Both"
                                                            BorderWidth="1px" BorderColor="#c9dffb" EmptyDataText="No Data Found" 
                                                            onpageindexchanging="grd_report_PageIndexChanging">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                           <%--  <PagerStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                                             <PagerSettings FirstPageText="first" LastPageText="last" NextPageText="next" PreviousPageText="previous" Position="TopAndBottom" />--%>
                                                            <Columns>
                                                            </Columns>
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                           
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle></RowStyle>
                                                            <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px"  HorizontalAlign="Left" VerticalAlign="Top"/>
                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last" NextPageText="next" PreviousPageText="prev"  FirstPageText="first" />
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
                    <div style="float:right;padding-right:40px; height: 19px;">
         <asp:Button runat="server" ID="btn_export_excel" Text="Export To Excel" 
                 CssClass="button2" onclick="btn_export_excel_Click"></asp:Button>
         </div>
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
             <Triggers>
        <asp:PostBackTrigger ControlID="btn_export_excel" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
