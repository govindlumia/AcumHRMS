<%@ Page Language="C#" AutoEventWireup="true" CodeFile="applyleaveByHC.aspx.cs" Inherits="leave_applyleaveByHC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply Leave</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
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
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../images/loading.gif" alt="" />
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
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="images/employee-icon.jpg" width="16" height="16" alt="" />
                                    </td>
                                    <td class="txt01">
                                        Apply Leave
                                    </td>
                                    <td align="right">
                                        <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="1">
                        </td>
                    </tr>
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
                                        Select Employee<span style="color: red">*</span>
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:DropDownList runat="server" ID="ddl_employee" CssClass="select" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddl_employee_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv_ddl_emp" ToolTip="select employee" ValidationGroup="a"
                                            ErrorMessage="select employee" ControlToValidate="ddl_employee" Display="None"
                                            InitialValue="0">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td width="1%" rowspan="6">
                                        &nbsp;
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Employee Code
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_code" runat="server"></asp:Label>
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
                                        Category
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_department" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_gender" Visible="false" runat="server"></asp:Label>
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Bussiness Unit
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_branch" runat="server"></asp:Label>
                                        <asp:Label ID="lbl_doj" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lbl_emp_status" runat="server" Visible="false"></asp:Label>&nbsp;
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
                                        Designation:
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                    </td>
                                    <%-- <td width="19%" class="frm-lft-clr123">
                                        Dated:
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_dated" runat="server" Text="Label"></asp:Label>
                                    </td>--%>
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
                        <td width="100%" class="head-2" valign="top">
                            <asp:GridView ID="grdMyBalance" BorderWidth="0px" runat="server" Font-Size="11px"
                                Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Leave Type">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                        <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("leavename") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance">
                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                        <ItemStyle Width="50%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("balance") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" CssClass="frm-rght-clr1234" />
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
                        <td colspan="2" height="10" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Type of Leave<span style="color: red">*</span>
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="dd_typeleave" runat="server" CssClass="select" OnSelectedIndexChanged="dd_typeleave_SelectedIndexChanged"
                                                        AutoPostBack="True" Width="109px">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_typeleave"
                                                        Display="None" ErrorMessage='Please Select Leave' Operator="NotEqual" ToolTip="Select Leave"
                                                        ValueToCompare="100" ValidationGroup="a"></asp:CompareValidator>
                                                </td>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Handheld/Landline No.:<span style="color: red">*</span>
                                                </td>
                                                <td width="31%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_MobileNo" runat="server" ToolTip="Emergency contact number"
                                                        CssClass="blue1" Width="142px" onblur="javascript:if(this.value.length<10){alert('number must be of 10 digits');this.value='';this.focus();}"
                                                        onkeyup="ValidateText(this)" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_MobileNo"
                                                        ErrorMessage='Select Handheld/Landline No.' Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                </tr>
                            </table>
                        </td>
                        <tr>
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%">
                                    <div id="divDirector" runat="server" visible="false">
                                        <tr>
                                            <td class="frm-lft-clr123" width="19%">
                                                Director<span style="color: red">*</span>
                                            </td>
                                            <td width="31%" class="frm-rght-clr123">
                                                <asp:DropDownList ID="ddlDirector" runat="server" AutoPostBack="true" CssClass="select"
                                                    OnSelectedIndexChanged="ddlDirector_SelectedIndexChanged" Width="109px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvDir" runat="server" ControlToValidate="ddlDirector"
                                                    Display="None" ErrorMessage="Please Select Director" InitialValue="0" SetFocusOnError="True"
                                                    ValidationGroup="Submit" />
                                            </td>
                                            <td class="frm-lft-clr123" width="19%">
                                                Responsible Employee<span style="color: red">*</span>
                                            </td>
                                            <td width="31%" class="frm-rght-clr123">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_employee"
                                                                ErrorMessage="Please Pick Responsible Person" Display="none" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td>
                                                            <a class="link05" href="JavaScript:newPopup1('pickemployee.aspx');">Pick Employee</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </div>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="div" visible="false" runat="server">
                                    <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged"
                                        Text="Full Day" ValidationGroup="noone" AutoPostBack="True" />
                                    <asp:RadioButton ID="rdohalfday" runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged"
                                        Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                    <%-- <asp:RadioButton ID="rdoShortday" runat="server" GroupName="days" OnCheckedChanged="rdoShortday_CheckedChanged"
                                        Text="Short Day" ValidationGroup="noone" AutoPostBack="True" />--%>
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
                                                            From Date<span style="color: red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" AutoPostBack="True"
                                                                OnTextChanged="txt_sdate_TextChanged" ValidationGroup="a"></asp:TextBox>&nbsp;<asp:Image
                                                                    ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                                                ErrorMessage='Please Select FromDate' Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_f"
                                                                TargetControlID="txt_sdate" Format="dd-MMM-yyyy">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                        <td width="19%" class="frm-lft-clr123">
                                                            To Date<span style="color: red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="true" AutoPostBack="True"
                                                                OnTextChanged="txt_edate_TextChanged" ValidationGroup="a"></asp:TextBox>&nbsp;<asp:Image
                                                                    ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                                ErrorMessage='Please Select ToDate' Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="img_t"
                                                                TargetControlID="txt_edate" Format="dd-MMM-yyyy">
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
                                            <td width="19%" class="frm-lft-clr123">
                                                Half Day Mode
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:RadioButton ID="opt_first" runat="server" Checked="True" GroupName="b" Text="First Half"
                                                    OnCheckedChanged="opt_first_CheckedChanged" />
                                                <asp:RadioButton ID="opt_second" runat="server" GroupName="b" Text="Second Half"
                                                    OnCheckedChanged="opt_second_CheckedChanged" />
                                            </td>
                                            <td width="19%" class="frm-lft-clr123">
                                                Select Date<span style="color: red">*</span>
                                            </td>
                                            <td class="frm-rght-clr123" width="31%">
                                                <asp:TextBox ID="txt_select" runat="server" CssClass="input" ValidationGroup="a"
                                                    AutoPostBack="True" OnTextChanged="txt_select_TextChanged"></asp:TextBox>
                                                <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_select"
                                                    ErrorMessage='Please Select Date' Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="Calendarextender2" runat="server" PopupButtonID="img_select"
                                                    TargetControlID="txt_select" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>--%>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="divshort" visible="false" runat="server">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                Short Day Mode
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:RadioButton ID="opt_inFirst" runat="server" Checked="True" GroupName="b" Text="In First Half"
                                                    OnCheckedChanged="opt_inFirst_CheckedChanged" />
                                                <asp:RadioButton ID="opt_inSecond" runat="server" GroupName="b" Text="In Second Half"
                                                    OnCheckedChanged="opt_inSecond_CheckedChanged" />
                                            </td>
                                            <td width="19%" class="frm-lft-clr123">
                                                Select Date<span style="color: red">*</span>
                                            </td>
                                            <td class="frm-rght-clr123" width="31%">
                                                <asp:TextBox ID="txt_selectSh" runat="server" CssClass="input" ValidationGroup="a"
                                                    AutoPostBack="True" OnTextChanged="txt_selectSh_TextChanged"></asp:TextBox>
                                                <asp:Image ID="img_selectSh" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_selectSh"
                                                    ErrorMessage='Please Select Date' Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="Calendarextender4" runat="server" PopupButtonID="img_selectSh"
                                                    TargetControlID="txt_selectSh" Format="dd-MMM-yyyy">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>--%>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
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
                                                Width="200px" CssClass="butt" ValidationGroup="calculate" />
                                        </td>
                                        <td width="19%" class="frm-lft-clr123">
                                            Attachment
                                        </td>
                                        <td width="31%" class="frm-rght-clr123">
                                            <asp:FileUpload ID="upload_attach" runat="server" CssClass="input2" Width="150px" />
                                            <asp:Label ID="lbl_file" runat="server"></asp:Label>
                                            [Upload only .docx and .pdf file]
                                            <asp:HiddenField ID="HiddenField_gender" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                        <tr runat="server" visible="false">
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
                                Reason<span style="color: red">*</span>
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_reason" runat="server" CssClass="select" TextMode="MultiLine"
                                    ValidationGroup="a" Width="374px" Height="30px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_reason"
                                    ErrorMessage='Please Select reason' Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Address while on Leave:<span style="color: red"></span>
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_Address" runat="server" CssClass="select" TextMode="MultiLine"
                                    ValidationGroup="a" Width="374px" Height="30px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="22" valign="top" class="txt02">
                                Approver Hierarchy
                            </td>
                        </tr>
                        <tr>
                            <td class="head-2" valign="top" colspan="2">
                                <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                    CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                                    DataKeyNames="empcode" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="approvergrid_SelectedIndexChanged">
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
                            <td height="5" colspan="2">
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td class="frm-lft-clr123">
                                Remarks(if any)
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txt_comment" runat="server" CssClass="select" TextMode="MultiLine"
                                    Width="374px"></asp:TextBox>
                            </td>
                        </tr>
                </table>
                </td> </tr>
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
                        &nbsp;
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_submit" />
            <%-- <asp:PostBackTrigger ControlID="btn_draft" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <div id="light" style="top: 35%; left: 10%;" class="pop1" align="center">
        <table width="600px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="pop-brdr">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="95%" valign="top" class="pop-tp-clr" align="left">
                            </td>
                            <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                <a href="#" onclick="document.getElementById('light').style.display='none';">
                                    <img src="images/btn-close.gif" width="16" height="19" border="0" /></a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" valign="top">
                                <%-- <iframe src="my_balance_leave.aspx" frameborder="0" scrolling="no" width="600" height="250">
                                </iframe>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="10">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <asp:ValidationSummary ID="ValidationSummary2" ShowMessageBox="True" ShowSummary="False"
                runat="server" ValidationGroup="a"></asp:ValidationSummary>
        </table>
    </div>
    </form>
</body>
</html>
