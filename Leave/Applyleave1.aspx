<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Applyleave1.aspx.cs" MasterPageFile="~/Admin/Admin.master"
    Inherits="Leave_Applyleave1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";
        .style1
        {
            border-left: 1px solid #c9dffb;
            border-top: 1px solid #c9dffb;
            border-bottom: 1px solid #c9dffb;
            background: #edf5ff;
            padding: 4px 0 4px 5px;
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #013366;
            height: 42px;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
        }
        .style2
        {
            background: #f8fbff;
            border: 1px solid #c9dffb;
            padding: 5px 0 5px 5px;
            font: normal 12px Arial, Helvetica, sans-serif;
            color: #013366;
            height: 42px;
        }
        .style3
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #013366;
            width: 43%;
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
    <script type="text/javascript" language="javascript">
        function ValidateText(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[^\d]+/g, '');
            }
        }

        function Validatedecimal(i) {
            if (i.value.lenght > 0) {
                i.value = i.value.replace(/^[-+]?[0-9]+\.[0-9]+$/, '');
            }
        }
    </script>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
   
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" height="5">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
                    CssClass="ajax__tab_xp2">
                    <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Leave Policy">
                        <ContentTemplate>
                            <div>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Leave Information">
                        <ContentTemplate>
                            <div>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" valign="top" class="txt02">
                                            <table width="100%">
                                                <tr>
                                                    <td width="27%" class="txt02" height="22">
                                                        Employee Information
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
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Employee Name
                                                    </td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <td width="1%" rowspan="7">
                                                        &nbsp;
                                                    </td>
                                                    <td width="18%" class="frm-lft-clr123">
                                                        Employee Code
                                                    </td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Department
                                                    </td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lbl_gender" Visible="false" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <td width="18%" class="frm-lft-clr123">
                                                        Location
                                                    </td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_designation" runat="server" Visible="false" Text="Label"></asp:Label>
                                                        <asp:Label ID="lbl_branch" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lbl_doj" runat="server" Visible="false" Text="Label"></asp:Label>
                                                        <asp:Label ID="lbl_emp_status" runat="server" Visible="false" Text="Label"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Dated:
                                                    </td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_dated" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" valign="top" class="txt02">
                                            <table width="100%">
                                                <tr>
                                                    <td width="27%" class="txt02" height="22">
                                                        Leave Balance
                                                    </td>
                                                    <td width="73%" align="right" class="txt-red">
                                                        <span id="Span1" runat="server"></span>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" valign="top">
                                            <asp:GridView ID="grdMyBalance" runat="server" Font-Size="11px" Font-Names="Arial"
                                                CellPadding="4" Width="100%" BorderWidth="1px" EmptyDataText="No Leave profile created..">
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                <RowStyle Height="5px" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="22" valign="top" class="txt02">
                                            <table width="100%">
                                                <tr>
                                                    <td width="27%" class="txt02" height="22">
                                                        Leave Application for:
                                                    </td>
                                                    <td width="73%" align="right" class="txt-red">
                                                        <span id="Span2" runat="server"></span>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Type of Leave
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_typeleave" runat="server" CssClass="select" DataSourceID="SqlDataSource1"
                                                            DataTextField="leavetype" DataValueField="leaveid" OnDataBound="dd_typeleave_DataBound"
                                                            OnSelectedIndexChanged="dd_typeleave_SelectedIndexChanged" AutoPostBack="True"
                                                            Width="109px">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_typeleave"
                                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                                                            ToolTip="Select Leave" ValueToCompare="100" ValidationGroup="a"></asp:CompareValidator>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="select crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave  order by crleave.leavetype"
                                                            UpdateCommand="UPDATE [tbl_leave_createleave] SET [leavetype] = @leavetype WHERE [leaveid] = @leaveid">
                                                            <DeleteParameters>
                                                                <asp:Parameter Name="leaveid" Type="Int32" />
                                                            </DeleteParameters>
                                                            <UpdateParameters>
                                                                <asp:Parameter Name="leavetype" Type="String" />
                                                                <asp:Parameter Name="leaveid" Type="Int32" />
                                                            </UpdateParameters>
                                                            <InsertParameters>
                                                                <asp:Parameter Name="leavetype" Type="String" />
                                                            </InsertParameters>
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="empcode" SessionField="empcode" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div id="div" visible="false" runat="server">
                                                            <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged"
                                                                Text="Full Day" ValidationGroup="noone" AutoPostBack="True" />
                                                            <asp:RadioButton ID="rdohalfday" runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged"
                                                                Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div id="divfull" visible="true" runat="server">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td width="19%" class="frm-lft-clr123">
                                                                                    From Date
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" AutoPostBack="True"
                                                                                        OnTextChanged="txt_sdate_TextChanged" ValidationGroup="a"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_f"
                                                                                        TargetControlID="txt_sdate">
                                                                                    </cc1:CalendarExtender>
                                                                                </td>
                                                                                <td width="19%" class="frm-lft-clr123">
                                                                                    To Date
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="true" AutoPostBack="True"
                                                                                        OnTextChanged="txt_edate_TextChanged" ValidationGroup="a"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="img_t"
                                                                                        TargetControlID="txt_edate">
                                                                                    </cc1:CalendarExtender>
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
                                                    <td colspan="2">
                                                        <div id="divhalf" visible="false" runat="server">
                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td width="19%" class="frm-lft-clr123" style="height: 36px">
                                                                        Half Day Mode
                                                                    </td>
                                                                    <td class="frm-rght-clr123" style="height: 36px">
                                                                        <asp:RadioButton ID="opt_first" runat="server" Checked="True" GroupName="b" Text="First Half"
                                                                            OnCheckedChanged="opt_first_CheckedChanged" />
                                                                        <asp:RadioButton ID="opt_second" runat="server" GroupName="b" Text="Second Half"
                                                                            OnCheckedChanged="opt_second_CheckedChanged" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="19%" class="frm-lft-clr123">
                                                                        Select Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_select" runat="server" CssClass="input" ValidationGroup="a"
                                                                            AutoPostBack="True" OnTextChanged="txt_select_TextChanged"></asp:TextBox>
                                                                        <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_select"
                                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                                        <cc1:CalendarExtender ID="Calendarextender2" runat="server" PopupButtonID="img_select"
                                                                            TargetControlID="txt_select">
                                                                        </cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Total No. of Days
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_nodA" Visible="false" runat="server" CssClass="select" Enabled="False">0</asp:TextBox>
                                                        <asp:Label ID="txt_nod" runat="server" CssClass="select" Text="0"></asp:Label>
                                                        &nbsp;<%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nod"
                                            ErrorMessage='<img src="../images/error1.gif" alt="Calculate No. of days" />'
                                            MaximumValue="100" MinimumValue="0.5" Type="Double" ValidationGroup="all"></asp:RangeValidator>--%><asp:Button
                                                ID="btn_calc" runat="server" Text="Calculate No. of Days" Visible="false" OnClick="btn_calc_Click"
                                                Width="124px" CssClass="butt" ValidationGroup="calculate" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr id="Tr1" runat="server" visible="false">
                                                    <td valign="top" colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="22" valign="top" class="txt02">
                                                                    Leave Adjustment
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="head-2" valign="top">
                                                                    <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                        CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                                                                        DataKeyNames="leaveid">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Leave Type">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("leavename") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="No. of Days">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("noofdays") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField Visible="false">
                                                                                <ItemStyle Width="0%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("status") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Attachment
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="upload_attach" runat="server" CssClass="input2" Width="287px" />
                                                        <asp:HiddenField ID="HiddenField_gender" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Reason
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_reason" runat="server" CssClass="select" TextMode="MultiLine"
                                                            ValidationGroup="a" Width="374px" Height="30px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_reason"
                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Address while on Leave:
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_Address" runat="server" CssClass="select" TextMode="MultiLine"
                                                            ValidationGroup="a" Width="374px" Height="30px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Address"
                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td class="frm-lft-clr123">
                                                        Handheld/Landline No.:
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_MobileNo" runat="server" CssClass="blue1" Width="142px" onkeyup="ValidateText(this)"
                                                            MaxLength="10"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <tr id="Tr2" runat="server">
                                                    <td class="frm-lft-clr123">
                                                        Remarks(if any)
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_comment" runat="server" CssClass="select" TextMode="MultiLine"
                                                            Width="382px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                                                      
                                    <tr>
                                        <td valign="top">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Approver Hierarchy">
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <table>
                                            <tr>
                                                <td colspan="2" height="22" valign="top" class="txt02">
                                                    Approver Hierarchy
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-2" valign="top" colspan="2">
                                                    <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                        CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                                                        DataKeyNames="empcode" DataSourceID="SqlDataSource2">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Approval Authority">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee Code" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approver Name">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Approval Authority" Visible="false">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                        <td valign="top" height="10">
                                            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />
                                            <asp:SqlDataSource ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                runat="server" ProviderName="System.Data.SqlClient" SelectCommand="sp_Select_Approvertest"
                                                SelectCommandType="StoredProcedure">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="empcode" SessionField="empcode" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Button ID="btn_submit" runat="server" ValidationGroup="a" CssClass="button"
                                                Text="Submit" OnClick="btn_submit_Click" />
                                            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />
                                            <asp:Button ID="btn_draft" runat="server" CssClass="button" Text="Save Draft" OnClick="btn_draftl_Click" />&nbsp;
                                        </td>
                                    </tr>
                                        </table>
                                        <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td height="10px">
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="A" />
    
</asp:Content>
