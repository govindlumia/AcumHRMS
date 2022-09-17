<%@ Page Language="C#" AutoEventWireup="true" CodeFile="overwrite-attendance.aspx.cs"
    Inherits="leave_admin_overwrite_attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
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
                                <td valign="bottom" align="center" class="txt01">
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
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="2" valign="top">
                                        <h3>
                                            Overwrite Attendance</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top" style="height: 5px" class="txt-red" align="left">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td valign="middle" class="frm-lft-clr123">
                                                    From Date (<img src="../images/error1.gif" alt="" />)
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_frmdate" runat="server" CssClass="input2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_frmdate"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:Image ID="img" runat="server" ImageUrl="../images/clndr.gif" />&nbsp;
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img" Format="dd-MMM-yyyy" TargetControlID="txt_frmdate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                                <td valign="middle" class="frm-lft-clr123">
                                                    To Date (<img src="../images/error1.gif" alt="" />)
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_todate" runat="server" CssClass="input2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_todate"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="../images/clndr.gif" />&nbsp;
                                                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd-MMM-yyyy" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txt_todate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="middle" class="frm-lft-clr123">
                                                    Emp Code (<img src="../images/error1.gif" alt="" />)
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="input2" Enabled="true"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_employee"
                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    &nbsp;<%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"
                                                        CssClass="link05" ValidationGroup="noone">Pick</asp:LinkButton>--%><a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');"
                                                            class="link05">Pick Employee</a>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123" align="right">
                                                    <asp:Button ID="Button3" runat="server" CssClass="button1" OnClick="Button1_Click"
                                                        Text="Fetch Attendance" />
                                                </td>
                                                <td valign="bottom" class="frm-rght-clr123" align="right" runat="server" id="an">
                                                    <asp:Button ID="Button2" runat="server" CssClass="button1" OnClick="Button2_Click"
                                                        Text="Update Attendance" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" height="10" valign="middle" class="txt1">
                                                </td>
                                            </tr>
                                            <tr id="update" runat="server" visible="false">
                                                <td class="head-2" valign="top" colspan="4">
                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                        CellPadding="3" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True"
                                                        PageSize="100" EmptyDataText="No data exists !" 
                                                        OnPageIndexChanging="empgrid_PageIndexChanging" 
                                                        onrowdatabound="empgrid_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldateg" runat="server" Text='<%# Bind ("date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee Code">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Card No">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcardnog" runat="server" Text='<%# Bind ("card_no") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mode">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblmodeg" runat="server" Text='<%# Bind ("mode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Change Mode">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="kcn" runat="server" CssClass="select1">
                                                                        <asp:ListItem Value="0">P</asp:ListItem>
                                                                        <asp:ListItem Value="1">A</asp:ListItem>
                                                                        <asp:ListItem Value="2">H</asp:ListItem>
                                                                        <asp:ListItem Value="3">W</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:DropDownList ID="ddlrunstatusg" runat="server" Width="75px" SelectedValue='<%#Bind("mode")%>'
                                                                        CssClass="select1" Height="20px">
                                                                        <asp:ListItem Value="0">P</asp:ListItem>
                                                                        <asp:ListItem Value="1">A</asp:ListItem>
                                                                        <asp:ListItem Value="2">H</asp:ListItem>
                                                                        <asp:ListItem Value="3">W</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Check">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="Chkbox" runat="server" BorderStyle="None" Text='<%# Eval("date")%>'
                                                                        ForeColor="White" AutoPostBack="false" />
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
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10" valign="middle" class="txt1" align="right">
                                        <asp:Button ID="Button1" runat="server" CssClass="button1" OnClick="Button1_Click2"
                                            Text="Update Attendance" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="5" valign="top">
                                    </td>
                            </table>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="p3" runat="server" visible="false" class="pop2" align="center">
                <table width="450" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="pop-brdr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                        Pick Employee
                                    </td>
                                    <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                        <a href="#" onclick="document.getElementById('divdetail').style.display='none';"
                                            class="pop-tp-clr">
                                            <asp:ImageButton ID="img_close" runat="server" ImageUrl="~/images/btn-close.gif"
                                                OnClick="img_close_Click" ValidationGroup="close" /></a>
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
                                                                <div id="divscrol" runat="server" style="position: static; width: 480px; height: 450px;
                                                                    overflow-x: hidden; overflow-y: scroll; left: 1px; top: 3px;">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="19%">
                                                                                Employee Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="30%">
                                                                                <asp:TextBox ID="txtempcode" runat="server" CssClass="input" Width="140"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="18%">
                                                                                Designation
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="32%">
                                                                                <asp:DropDownList ID="dd_designation" runat="server" CssClass="select2" DataSourceID="SqlDataSource1"
                                                                                    DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                                                                    Width="140px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Department
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="dd_branch" runat="server" CssClass="select2" DataSourceID="SqlDataSource2"
                                                                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                                                    Width="140px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid],department_name FROM [tbl_internate_departmentdetails] order by department_name">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Branch
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="select" DataSourceID="SqlDataSource21"
                                                                                    DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound"
                                                                                    Width="140px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                                                                </asp:SqlDataSource>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="9%" colspan="2" align="right">
                                                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_click"
                                                                                    ValidationGroup="search" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                        DataKeyNames="empcode" CellPadding="4" Width="100%" AutoGenerateColumns="False"
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
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Emp Name">
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                <ItemStyle Width="60%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
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
                                                                <asp:Button ID="btn_ok" runat="server" CssClass="button" Text="Add" OnClick="btn_ok_Click"
                                                                    ValidationGroup="no" />
                                                                <asp:Button ID="btn_close" runat="server" CssClass="button" Text="Close" OnClick="btn_close_Click"
                                                                    ValidationGroup="no" />
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
