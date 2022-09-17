<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editleave.aspx.cs" Inherits="leave_applyleave" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply Leave</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="leaveapply" runat="server">
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
                                    <img src="images/loading.gif" />
                                </td>
                                <td valign="bottom">
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
                                        <img src="images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Edit Leave
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 5px">
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
                                        Category
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_gender" Visible="false" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Bussiness Unit
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
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
                                    <td width="19%" class="frm-lft-clr123">
                                        Designation
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_designation" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
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
                            <asp:GridView ID="grdMyBalance" BorderWidth="0px" runat="server" 
                                Font-Size="11px" Font-Names="Arial"
                                CellPadding="4" Width="100%" AutoGenerateColumns="False" >
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
                                <PagerStyle CssClass="frm-rght-clr1234" />
                                <RowStyle Height="5px" CssClass="frm-rght-clr1234" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                        </td>
                    </tr>
                    <tr id="lvbal" runat="server" visible="false">
                        <td align="right" valign="top" style="height: 18px">
                            <input id="Button1" class="button1" onclick="document.getElementById('light').style.display='block';"
                                type="button" value="Leave Status" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="txt02" style="height: 20px">
                            &nbsp;Apply Leave
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
                                        <asp:Label ID="lbl_leave" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="div" visible="true" runat="server">
                                            <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged"
                                                Text="Full Day" ValidationGroup="noone" AutoPostBack="True" /><asp:RadioButton ID="rdohalfday"
                                                    runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged"
                                                    Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="divfull" visible="true" runat="server">
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        From Date
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>&nbsp;<asp:Image
                                                            ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="calculate"></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_f"
                                                            TargetControlID="txt_sdate" Format="dd-MMM-yyyy">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        To Date
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="select" OnTextChanged="txt_edate_TextChanged" Enabled="True" AutoPostBack="true"></asp:TextBox>&nbsp;<asp:Image
                                                            ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="calculate"></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="img_t"
                                                            TargetControlID="txt_edate" Format="dd-MMM-yyyy">
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
                                                        <asp:RadioButton ID="rdoShortday" runat="server" GroupName="days" OnCheckedChanged="rdoShortday_CheckedChanged"
                                                            Text="Short Day" ValidationGroup="noone" AutoPostBack="True" />
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
                                                        <asp:TextBox ID="txt_select" runat="server" CssClass="input"></asp:TextBox>
                                                        <asp:Image ID="img_select" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_select"
                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="calculate"></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="Calendarextender2" runat="server" PopupButtonID="img_select"
                                                            TargetControlID="txt_select" Format="dd-MMM-yyyy">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
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
                                                            TargetControlID="txt_selectSh">
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
                                    <td width="19%" class="frm-lft-clr123">
                                        No. of Days
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:TextBox ID="txt_nod" runat="server" CssClass="select" Enabled="False">0</asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nod"
                                            ErrorMessage='<img src="../images/error1.gif" alt="Calculate No. of days" />'
                                            MaximumValue="100" MinimumValue="0.5" Type="Double" ValidationGroup="all"></asp:RangeValidator>
                                        <asp:Button ID="btn_calc" runat="server" Text="Calculate No. of Days" OnClick="btn_calc_Click" Visible="false" 
                                            Width="128px" CssClass="butt" ValidationGroup="calculate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="8" colspan="2">
                                    </td>
                                </tr>
                              <%--  <tr>
                                    <td valign="top" colspan="2">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="22" valign="top" class="txt02">
                                                    &nbsp;Leave Adjustment&nbsp;
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
                                </tr>--%>
                                <tr>
                                    <td height="7" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Reason
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:TextBox ID="txt_reason" runat="server" CssClass="select" TextMode="MultiLine"
                                            Width="270px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_reason"
                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="all"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Attachment (if any)
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_file" runat="server"></asp:Label><br />
                                        <asp:FileUpload ID="upload_attach" runat="server" CssClass="input2" Width="287px" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="upload_attach"
                                            ErrorMessage='<img src="../images/error1.gif" alt="Upload file" />' ValidationGroup="app"
                                            Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="upload_attach"
                                            CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="file format not supported" />'
                                            ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="8" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="22" valign="top" class="txt02">
                                        &nbsp;Approver Hierarchy
                                    </td>
                                </tr>
                                <tr>
                                    <td class="head-2" valign="top" colspan="2">
                                        <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                            CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                                            DataKeyNames="empcode">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Employee Code">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approver Name">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                    <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Level">
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                    <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                    <ItemStyle Width="35%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("status") %>'></asp:Label>
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
                                    <td colspan="2" style="height: 5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                        <asp:Label ID="lbl_comments" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Add Comment
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:TextBox ID="txt_comment" runat="server" CssClass="select" TextMode="MultiLine"
                                            Width="270px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                            <asp:HiddenField ID="hidden_leave" runat="server" Value="0" />
                            <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
                            <asp:HiddenField ID="hidd_leaveid" runat="server" />
                            <asp:HiddenField ID="prvimg" runat="server" />
                            <asp:HiddenField ID="hidd_leave_status" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" style="height: 1px">
                            <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Update" OnClick="btn_submit_Click" />
                            <asp:Button ID="txt_cancel" runat="server" CssClass="button" Text="Cancel leave"
                                OnClick="btn_cancel_Click" />
                            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />&nbsp;
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
                                <iframe src="my_balance_leave.aspx" frameborder="0" scrolling="yes" width="600" height="250">
                                </iframe>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" height="10">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
