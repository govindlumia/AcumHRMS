<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create_employee_leave_profile.aspx.cs"
    Inherits="Leave_admin_createemployeeprofile" Title="Employee Leave profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../images/loading.gif" />
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
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="blue-brdr-1">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01">
                                    Employee Leave Profile
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5" valign="top" align="right" class="txt-red">
                        <span id="message" runat="server"></span>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td height="20" valign="top" class="txt02">
                        &nbsp;Create Employee Profile
                    </td>
                </tr>
                <tr>
                    <td height="10" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="19%" class="frm-lft-clr123">
                                    Employee Code(<img alt="" src="../images/error1.gif" />)
                                </td>
                                <td class="frm-rght-clr123">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="26%" style="height: 20px">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="input"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_employee"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="74%" style="height: 20px">
                                               <%-- <a href="JavaScript:newPopup1('pickemployee.aspx');" class="link05">Pick Employee</a>--%>
                                               <a class="link05" href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');">Pick Employee</a>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                    <div runat="server" style="display:none;">
                        <table width="718" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="22" valign="top" class="txt02">
                                    &nbsp;Add Approver
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                Approver Name
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="26%">
                                                            <asp:TextBox ID="txt_approver" runat="server" CssClass="input"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                ValidationGroup="app" ControlToValidate="txt_approver" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_approver"
                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Select approver" />'
                    ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                                        </td>
                                                        <td width="59%">
                                                            <a href="JavaScript:newPopup1('pickapprover.aspx');" class="link05">Pick Approver</a>
                                                        </td>
                                                        <td width="15%" align="right">
                                                            <asp:Button ID="btn_add" runat="server" CssClass="button" Text="Add" OnClick="btn_add_Click"
                                                                ValidationGroup="app" />&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
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
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="20" valign="top" class="txt02">
                                                            &nbsp;Approval Level&nbsp;
                                                            <asp:Button ID="btn_resetgrid" runat="server" CssClass="button" ValidationGroup="onone"
                                                                Text="Reset Grid" OnClick="btn_greset_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="head-2" valign="top">
                                                            <asp:GridView ID="approvalgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No record found">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Emp Code">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Approver Name">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Level">
                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                        <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("level") %>'></asp:Label>
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
                                                        <td height="20">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table></div>
                    </td>
                </tr>
                <tr runat="server" visible="true">
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="19%" class="frm-lft-clr123">
                                    HC&nbsp;<%--(<img alt="" src="../images/error1.gif" />)--%>
                                </td>
                                <td class="frm-rght-clr123">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="26%">
                                                <asp:TextBox ID="txt_hr" runat="server" CssClass="input"></asp:TextBox>
                                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_hr"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td width="74%" style="height: 20px">
                                                <a href="JavaScript:newPopup1('pickhr.aspx?code=hr');" class="link05">Pick HC</a>
                                            <%--   <a class="link05" href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=1&MSS=0&Emp=0&Con=txt_hr');">Pick HC</a>--%>
                                            </td>
                                        </tr>
                                    </table>
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
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frm-lft-clr123" width="17%">
                                    Pro Rata Applicable
                                </td>
                                <td width="23%" class="frm-rght-clr123">
                                    <asp:RadioButton ID="opt_prorata_yes" runat="server" GroupName="kb" Text="Yes" />
                                    <asp:RadioButton ID="opt_prorata_no" runat="server" GroupName="kb" Text="No" Checked="True" />
                                </td>
                                <td colspan="3" width="1%">
                                    &nbsp;
                                </td>
                                <%-- <td id="a1" width="25%" class="frm-lft-clr123" runat="server">Enforcement Date</td>
    <td width="23%" class="frm-rght-clr123" runat="server" id="a2"><asp:TextBox ID="txt_enforcement" runat="server" Width="80px" CssClass="select"></asp:TextBox>&nbsp;<asp:Image
            ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_enforcement"
    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Enter enforcement date" />'
    ValidationGroup="v"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_enforcement"
            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="You can not set leave policy to previous years" />'
            MaximumValue="1/1/2015" MinimumValue="1/1/2009" Type="Date" ValidationGroup="a"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_enforcement"
            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Select date of enforcement" />'
            ValidationGroup="a"></asp:RequiredFieldValidator></td>--%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10" valign="top">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top" class="txt02" style="height: 20px">
                        Set Leave Rule
                    </td>
                </tr>
                <tr>
                    <td height="10" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="19%" class="frm-lft-clr123">
                                    Leave Policy&nbsp;(<img alt="" src="../images/error1.gif" />)
                                </td>
                                <td class="frm-rght-clr123">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="30%" style="height: 20px">
                                                <asp:DropDownList ID="drp_policy" runat="server" CssClass="select" DataSourceID="SqlDataSource2"
                                                    DataTextField="policyname" DataValueField="policyid" OnDataBound="drp_policy_DataBound"
                                                    Width="150px">
                                                </asp:DropDownList>
                                                &nbsp;<asp:CompareValidator ID="CompareValidator5" runat="server" ValueToCompare="0"
                                                    ValidationGroup="a" Operator="NotEqual" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                    Display="Dynamic" ControlToValidate="drp_policy"><img src="../images/error1.gif" alt="" /></asp:CompareValidator><asp:SqlDataSource
                                                        ID="SqlDataSource2" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        runat="server" SelectCommand="select policyid,policyname from tbl_leave_createleavepolicy where status=1">
                                                    </asp:SqlDataSource>
                                            </td>
                                            <td width="24%">
                                                <asp:Button ID="btn_policy" runat="server" CssClass="button" OnClick="btn_policy_Click"
                                                    Text="Set Policy" ValidationGroup="a" />
                                            </td>
                                            <td align="right" width="46%">
                                                <a href="#" class="link05" onclick="document.getElementById('light').style.display='block';">
                                                    Leave Policy</a>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10" valign="top">
                    </td>
                </tr>
                <tr>
                    <td height="10" valign="top">
                        <asp:GridView ID="grid_customizerule" runat="server" DataKeyNames="id" Font-Size="11px"
                            Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                            EmptyDataText="No record found">
                            <Columns>
                                <asp:TemplateField Visible="False">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="0%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("policyid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False">
                                    <ItemStyle Width="0%" />
                                    <ItemTemplate>
                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("leaveid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave Policy">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="40%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("policyname") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Leave Type">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("leavetype") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Entitled Days">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_entdays" Text='<%# Bind("entitled_days")%>' onkeyup="checkNumericValueForCntrl(this)" MaxLength="5"  CssClass="input"
                                            runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_entdays"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Entitled days cannot be blank " />'></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_entdays"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="Data should be numeric and greater than 0" />'
                                            MaximumValue="1000" MinimumValue="0.1" Type="Double"></asp:RangeValidator>
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
                    <td height="10" valign="top">
                        <asp:HiddenField ID="hidd_name" runat="server" />
                        <asp:HiddenField ID="hiddenlevel" runat="server" Value="1" />
                        Mandatory fields (<img alt="" src="../images/error1.gif" />)
                        <%-- <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
            TargetControlID="txt_enforcement">
        </cc1:CalendarExtender>--%>
                        &nbsp;&nbsp;
                        <asp:HiddenField ID="hidden_hr" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                        <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click"
                            ValidationGroup="a" />
                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click"
                            ValidationGroup="x" />
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <div id="light" class="pop1" align="center">
                <table width="680" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="pop-brdr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                    </td>
                                    <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                        <a href="#" onclick="document.getElementById('light').style.display='none';">
                                            <img src="../images/btn-close.gif" width="16" height="19" border="0" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" valign="top">
                                        <iframe src="check_leavepolicy.aspx" frameborder="0" scrolling="yes" width="670"
                                            height="300"></iframe>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
