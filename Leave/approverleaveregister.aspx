<%@ Page Language="C#" AutoEventWireup="true" CodeFile="approverleaveregister.aspx.cs"
    Inherits="Leave_approverleaveregister" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <titLeave Report</title>
    <script type="text/javascript" src="js/popup.js"></script>
    <style type="text/css" media="all">
        @import "css/blue1.css";
        absolute .disp
        {
            display: none;
        }
        .pop2
        {
            position: absolute;
            background-color: #fff;
            z-index: 1002;
            overflow: auto;
            padding: 0px;
            left: 240px;
            top: 38%;
            width: 500px;
        }
        fieldset
        {
            margin: 0;
            padding: 0;
            border: 1px solid #c9dffb;
            padding: 0 7px 10px 7px;
        }
        legend
        {
            font: 12px Arial, Helvetica, sans-serif;
            color: #08486d;
            padding-bottom: 0px;
            padding-top: 2px;
        }
        .divajaxpage
        {
            width: 120px;
            height: 32px;
            background-color: #fff;
            z-index: 1004;
            position: absolute;
            top: 37%;
            left: 40%;
            padding: 30px;
            border: 5px solid #9dbde4;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btn_search">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <Triggers>
   <asp:PostBackTrigger ControlID="btn_emporttoexcel" />
   </Triggers>
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajaxpage">
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
            <div class="header">
                <script type="text/javascript">
                    var TotalChkBx;
                    var Counter;

                    window.onload = function () {
                        //Get total no. of CheckBoxes in side the GridView.
                        TotalChkBx = parseInt('<%= this.adjustgrid.Rows.Count %>');

                        //Get total no. of checked CheckBoxes in side the GridView.
                        Counter = 0;
                    }

                    function HeaderClick(CheckBox) {
                        //Get target base & child control.
                        var TargetBaseControl =
       document.getElementById('<%= this.adjustgrid.ClientID %>');
                        var TargetChildControl = "chkselect";

                        //Get all the control of the type INPUT in the base control.
                        var Inputs = TargetBaseControl.getElementsByTagName("input");

                        //Checked/Unchecked all the checkBoxes in side the GridView.
                        for (var n = 0; n < Inputs.length; ++n)
                            if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                                Inputs[n].checked = CheckBox.checked;

                        //Reset Counter
                        Counter = CheckBox.checked ? TotalChkBx : 0;
                    }

                    function ChildClick(CheckBox, HCheckBox) {
                        //get target control.
                        var HeaderCheckBox = document.getElementById(HCheckBox);

                        //Modifiy Counter; 
                        if (CheckBox.checked && Counter < TotalChkBx)
                            Counter++;
                        else if (Counter > 0)
                            Counter--;

                        //Change state of the header CheckBox.
                        if (Counter < TotalChkBx)
                            HeaderCheckBox.checked = false;
                        else if (Counter == TotalChkBx)
                            HeaderCheckBox.checked = true;
                    }
                </script>
                <div style="overflow-x: hidden; overflow-y: scroll; height: 512px; width: 100%;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="502" valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top" class="blue-brdr-1">
                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="3%">
                                                                    <img src="images/employee-icon.jpg" width="16" height="16" alt=""/>
                                                                </td>
                                                                <td width="97%" class="txt01">
                                                                    Reports
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
                                                    <td valign="top">
                                                        <fieldset>
                                                            <legend><b>Leave Details</b></legend>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="7">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5" height="25" valign="top">
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="25%" align="left" style="height: 20px">
                                                                                    <asp:CheckBox ID="chk_temp" AutoPostBack="true" runat="server" Text="Template" OnCheckedChanged="chk_temp_CheckedChanged" />
                                                                                </td>
                                                                                <td align="right" width="75%" style="height: 20px">
                                                                                   <%-- <a class="txt-red" href="javascript:history.back()">Back</a>--%>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5">
                                                                        <div id="date" runat="server" visible="true">
                                                                            <table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td valign="middle" class="frm-lft-clr123" width="17%">
                                                                                        From Date
                                                                                    </td>
                                                                                    <td valign="top" class="frm-rght-clr123" width="19%">
                                                                                        <asp:TextBox ID="txt_sdate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
                                                                                        <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                                                                        <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
                                                                                            ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                                                            ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>--%>
                                                                                        <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate"
                                                                                            Format="dd-MMM-yyyy">
                                                                                        </cc1:CalendarExtender>
                                                                                    </td>
                                                                                    <td width="1%" valign="top">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td width="17%" valign="middle" class="frm-lft-clr123">
                                                                                        To Date
                                                                                    </td>
                                                                                    <td width="46%" valign="top" class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_edate" runat="server" CssClass="select" Enabled="False"></asp:TextBox>
                                                                                        <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
                                                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                                                                        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_edate"
                                                                                            ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                                                            ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>--%>
                                                                                        <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate"
                                                                                            Format="dd-MMM-yyyy">
                                                                                        </cc1:CalendarExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                        <div id="template" runat="server" visible="false">
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td valign="middle" class="frm-lft-clr123" width="17%">
                                                                                        Select Template
                                                                                    </td>
                                                                                    <td colspan="4" valign="top" class="frm-rght-clr123" width="83%">
                                                                                        <asp:DropDownList ID="drp_template" runat="server" CssClass="select" Width="200px">
                                                                                            <asp:ListItem Selected="True" Value="0">Current Week</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Last Week</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Next Week</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Current Month</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Last Month</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Next Month</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5" height="7">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="17%" valign="middle" class="frm-lft-clr123">
                                                                        Emp Code
                                                                    </td>
                                                                    <td valign="top" class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_empcode" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                                                 <asp:RequiredFieldValidator runat="server" ID="rfv_txt_empcode" ValidationGroup="c"  ErrorMessage='<img src="../images/error1.gif" />' ControlToValidate="txt_empcode"   ></asp:RequiredFieldValidator> 
                                                                  
                                                                  
                                                                       <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="link05"
                                                                            ValidationGroup="noone">Pick</asp:LinkButton>--%>
                                                                             <a href="JavaScript:newPopup1('../pickempwithdata.aspx?HR=0&MSS=1&Emp=0&Con=txt_empcode');" class="link05">
                                                                            Pick Employee</a>&nbsp;
                                                                            <asp:TextBox ID="lbl_empcode" runat="server" Visible="false"></asp:TextBox>
                                                                    </td>
                                                                    <td valign="top" style="width: 1%">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td width="17%" valign="middle" class="frm-lft-clr123">
                                                                        Leave Type
                                                                    </td>
                                                                    <td width="46%" valign="middle" class="frm-rght-clr123">
                                                                        <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="select2" DataSourceID="SqlDataSource3"
                                                                            DataTextField="leavetype" DataValueField="leaveid" OnDataBound="ddl_leaveType_DataBound"
                                                                            Width="150px">
                                                                        </asp:DropDownList>
                                                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [leaveid],leavetype FROM [tbl_leave_createleave] order by leavetype">
                                                                        </asp:SqlDataSource>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="17%" valign="middle" class="frm-lft-clr123">
                                                                        Leave Status
                                                                    </td>
                                                                    <td valign="top" class="frm-rght-clr123" colspan="4">
                                                                    <%--    <asp:DropDownList ID="drp_leavestatus" runat="server" CssClass="select2" Width="150px">
                                                                            <asp:ListItem Value="0">Pending</asp:ListItem>
                                                                            <asp:ListItem Selected="True" Value="6">Approved &amp; Updated</asp:ListItem>
                                                                            <asp:ListItem Value="2">Cancelled</asp:ListItem>
                                                                            <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                                        </asp:DropDownList>--%>
                                                                         <asp:CheckBoxList runat="server" RepeatLayout="Flow" ID="chk_leave_status" TextAlign="Right"
                                                                            RepeatDirection="Horizontal" AutoPostBack="true" CellSpacing="5" OnSelectedIndexChanged="chk_leave_status_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">All</asp:ListItem>
                                                                            <asp:ListItem Value="1">Pending Approval</asp:ListItem>
                                                                            <asp:ListItem Value="4">Scheduled</asp:ListItem>
                                                                            <asp:ListItem Value="6" Selected="True">Approved &amp; Updated</asp:ListItem>
                                                                            <asp:ListItem Value="2">Cancelled</asp:ListItem>
                                                                            <asp:ListItem Value="3">Rejected</asp:ListItem>
                                                                        </asp:CheckBoxList>
                                                                    </td>
                                                                 <%--   <td valign="top" style="width: 1%">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td width="17%" valign="middle" class="frm-lft-clr123">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td width="46%" valign="middle" class="frm-rght-clr123">
                                                                        &nbsp;
                                                                    </td>--%>
                                                                </tr>
                                                                <tr>
                                                                    <td height="10" colspan="5">
                                                                    </td>
                                                                </tr>
                                                                  <tr>
                                                                    <td width="17%" valign="middle" class="frm-lft-clr123">
                                                                        Include Past Employees
                                                                    </td>
                                                                    <td valign="top" class="frm-rght-clr123" colspan="4">
                                                                        <asp:CheckBox runat="server" ID="chk_emp_status" />
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td height="10" colspan="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5" valign="top">
                                                                        <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click"
                                                                            Text="Search" ValidationGroup="c" />
                                                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click"
                                                                            Text="Reset" ValidationGroup="c" />
                                                                            <span style="padding-left:100px">
                                                                             <asp:Button ID="btn_emporttoexcel" runat="server" CssClass="button2" OnClick="btn_emporttoexcel_Click"
                                                                            Text="Export to Excel" ValidationGroup="c" />
                                                                            </span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </fieldset>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        &nbsp;<asp:GridView ID="empleavegrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            BorderWidth="0px" CellPadding="4" CellSpacing="0" DataKeyNames="empcode" EmptyDataText="No employee leave data found!"
                                                            Font-Names="Arial" Font-Size="11px" OnPageIndexChanging="empleavegrid_PageIndexChanging"
                                                            PageSize="50" Width="100%">
                                                       <%--    <Columns>
                                                                <asp:TemplateField HeaderText="Emp Code">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Name">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("ename") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Designation">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("designation") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                              
                                                                <asp:TemplateField HeaderText="No. of leaves">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("nod") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Center" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                      <a href="#" onclick="newPopup('report-empleavedetail.aspx?sdate=<%=txt_sdate.Text%>&status=<%=drp_leavestatus.SelectedValue%>&edate=<%=txt_edate.Text%>&empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>')"
                                                                            class="link05">View Detail</a>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>--%>
                                                             <Columns>
                                                                <asp:TemplateField HeaderText="From">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="fromdate" runat="server" Text='<%# Eval ("fromdate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="To">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="todate" runat="server" Text='<%# Bind ("todate","{0:dd-MMM-yyyy}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Code">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="empcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Name">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="empname" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Leave Type">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="leave_type" runat="server" Text='<%# Bind ("leave_type") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No. of leaves">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="no_of_days" runat="server" Text='<%# Bind ("no_of_days") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Leave Status">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="leave_status" runat="server" Text='<%# Bind ("leave_status") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Comment">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" Width="15%" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="comments" runat="server" Text='<%# Bind ("comments") %>'></asp:Label>
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
                                                <td valign="top">
                                                 &nbsp;<asp:GridView ID="empapproverleavegrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                            BorderWidth="0px" CellPadding="4" CellSpacing="0" DataKeyNames="empcode" EmptyDataText="No employee leave data found!"
                                                            Font-Names="Arial" Font-Size="11px" OnPageIndexChanging="empapproverleavegrid_PageIndexChanging"
                                                            PageSize="50" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Emp Code">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Name">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("ename") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Designation">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("designation") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                              
                                                                <asp:TemplateField HeaderText="No. of leaves">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="20%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("nod") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Center" VerticalAlign="Top"
                                                                        Width="10%" />
                                                                    <ItemTemplate>
                                                                        <a href="#" onclick="newPopup('report_empleavedetailapprover.aspx?status=6&empcode=<%#DataBinder.Eval(Container.DataItem, "empcode")%>')"
                                                                            class="link05">View Detail</a>
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
                                                    <td valign="top" align="right">
                                                        <%--<a class="txt-red" href="admin/leaveadmin.aspx" target="name123">Back</a>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="p3" runat="server" visible="false" class="pop2" align="center">
                <table width="490" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="pop-brdr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                        Pick Employee
                                    </td>
                                    <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                        <asp:ImageButton ID="img_close" runat="server" ImageUrl="images/btn-close.gif" OnClick="img_close_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="1" cellspacing="0" cellpadding="3" bordercolor="#93b5c8"
                                                        style="border-collapse: collapse;">
                                                        <tr>
                                                            <td colspan="3" valign="top" width="100%">
                                                                <div id="divscrol" runat="server" style="position: static; width: 480px; height: 250px;
                                                                    overflow-x: hidden; overflow-y: scroll; left: 1px; top: 3px;">
                                                                    <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                        DataKeyNames="employeecode" CellPadding="4" Width="100%" AutoGenerateColumns="False"
                                                                        BorderWidth="0px" EmptyDataText="No Emp record found" OnRowDataBound="adjustgrid_RowDataBound"
                                                                        OnRowCreated="adjustgrid_RowCreated">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkselect" runat="server" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("employeecode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Emp Name">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="60%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="20" colspan="3" align="right" valign="middle">
                                                                <asp:Button ID="btn_ok" runat="server" CssClass="button" Text="Add" OnClick="btn_ok_Click" />
                                                                <asp:Button ID="btn_close" runat="server" CssClass="button" Text="Close" OnClick="btn_close_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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
