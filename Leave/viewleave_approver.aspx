<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewleave_approver.aspx.cs"
    Inherits="leave_applyleave" %>

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
    <asp:ScriptManager ID="leaveapply" runat="server">
    </asp:ScriptManager>
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
                                View Leave
                            </td>
                             <td align="right">
                                <a href="leave-user.aspx" target="" class="txt-red">Back</a>
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
                <td height="20" valign="top" class="txt02">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                        CellPadding="4" Width="100%" AutoGenerateColumns="False">
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
                <td colspan="4" style="height: 5px">
                </td>
            </tr>
           
            <tr>
                <td height="22" valign="top" class="txt02">
                    &nbsp;Apply Leave
                </td>
            </tr>
            <tr>
                <td height="10" valign="top" colspan="4">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="19%" class="frm-lft-clr123">
                                Type of Leave
                            </td>
                            <td width="31%" class="frm-rght-clr123">
                                <asp:Label ID="lbl_leave" runat="server"></asp:Label>
                            </td>
                            <td width="19%" class="frm-lft-clr123">
                                Phone No.
                            </td>
                            <td width="31%" class="frm-rght-clr123">
                                <asp:Label ID="lbl_mobileno" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="4">
                            </td>
                        </tr>
                        <tr id="divDirector" runat="server">
                            <td class="frm-lft-clr123" width="19%">
                                Director
                            </td>
                            <td width="31%" class="frm-rght-clr123">
                                <asp:Label ID="lblDirector" runat="server" Width="109px">
                                </asp:Label>
                            </td>
                            <td class="frm-lft-clr123" width="19%">
                                Responsible Employee
                            </td>
                            <td width="31%" class="frm-rght-clr123">
                                <asp:Label ID="txt_employee" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="divfull" visible="true" runat="server">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                From Date
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_sdate" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td width="19%" class="frm-lft-clr123">
                                                To Date
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_edate" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="4">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="divhalf" visible="false" runat="server">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                Half Day Mode
                                            </td>
                                            <td class="frm-rght-clr123" width="31%">
                                                <asp:Label ID="lbl_half" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td width="19%" class="frm-lft-clr123">
                                                Select Date
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_select" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="divshort" visible="false" runat="server">
                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                Short Day Mode
                                            </td>
                                            <td width="31%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_short" runat="server" Text=""></asp:Label>
                                            </td>
                                            <td width="19%" class="frm-lft-clr123">
                                                Select Date
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_selectSh" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td width="19%" class="frm-lft-clr123">
                                No. of Days
                            </td>
                            <td width="31%" class="frm-rght-clr123">
                                <asp:Label ID="lbl_nod" runat="server" Text=""></asp:Label>
                            </td>
                            <td class="frm-lft-clr123" width="19%">
                                Attachment (if any)
                            </td>
                            <td class="frm-rght-clr123" width="31%">
                                <asp:Label ID="lbl_file" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" colspan="4">
                            </td>
                        </tr>
                        <tr runat="server" visible="false">
                            <td valign="top" colspan="4">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="22" valign="top" class="txt02">
                                            &nbsp;Leave Adjustment
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
                            <td height="7" colspan="4">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="50%">
                                            Reason
                                        </td>
                                        <td class="frm-rght-clr123" width="50%">
                                            <asp:Label ID="lbl_reason" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="50%">
                                            Address while on leave:
                                        </td>
                                        <td class="frm-rght-clr123" width="50%">
                                            <asp:Label ID="lbl_address" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="4" style="height: 5px">
                        </td>
            </tr>
            <tr>
                <td height="10" colspan="4">
                </td>
            </tr>
            <tr>
                <td colspan="4" height="22" valign="top" class="txt02">
                    &nbsp;Approver Hierarchy
                </td>
            </tr>
            <tr>
                <td class="head-2" valign="top" colspan="4">
                    <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                        CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                        DataKeyNames="empcode">
                        <Columns>
                            <asp:TemplateField HeaderText="Approval Authority">
                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Approver Name">
                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                <ItemTemplate>
                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
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
                <td colspan="4" style="height: 5px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 5px">
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
        </td> </tr>
        <tr>
            <td valign="top" style="height: 10px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" style="height: 18px">
                &nbsp;<asp:Button ID="btn_approve" runat="server" CssClass="button2" OnClick="btn_approve_Click"
                    Text="Approve" />
                <asp:Button ID="btn_backuser" runat="server" CssClass="button2" OnClick="btn_backuser_Click"
                    Text="Back to User" visible="false"/>
                <asp:Button ID="btn_cancel" runat="server" CssClass="button2" OnClick="btn_cancel_Click"
                    Text="Reject" />&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
                <asp:HiddenField ID="hidd_empcode" runat="server" Value="0" />
            </td>
        </tr>
        </table>
    </div>
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
                                <iframe src="my_balance_leave.aspx?empcode=<%=hidd_empcode.Value%>" frameborder="0"
                                    scrolling="yes" width="600" height="250"></iframe>
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
