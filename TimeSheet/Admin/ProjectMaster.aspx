<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/Admin/TimesheetMaster.master"
    AutoEventWireup="true" CodeFile="ProjectMaster.aspx.cs" Inherits="TimeSheet_Admin_ProjectMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                document.write('<style type="text/css">.tabber{display:none;}<\/style>');
                function updateValue(amount) {
                    var textBox = document.getElementById('<%=txt_proadmin.ClientID %>');
                    textBox.value = amount;
                }    
            </script>
            <script type="text/javascript">
                document.write('<style type="text/css">.tabber{display:none;}<\/style>');
                function updateValue1(amount) {
                    var textBox = document.getElementById('<%=txt_proadmin.ClientID %>');
                    textBox.value = amount;
                }
                function HeaderClick(CheckBox) {
                    //Get target base & child control.
                    var TargetBaseControl =
       document.getElementById('<%= this.grdActivity.ClientID %>');
                    var TargetChildControl = "chkselect";

                    //Get all the control of the type INPUT in the base control.
                    var Inputs = TargetBaseControl.getElementsByTagName("input");

                    //Checked/Unchecked all the checkBoxes in side the GridView.
                    for (var n = 0; n < Inputs.length; ++n)
                        if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                            Inputs[n].checked = CheckBox.checked;
                }   
            </script>
            <div id="HomePage" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Project Master
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" align="right">
                                <asp:LinkButton ID="lnkCreate" CssClass="link02" runat="server" OnClick="lnkCreate_Click">Create New</asp:LinkButton>
                                <asp:LinkButton ID="lnkView" CssClass="link02" runat="server" OnClick="lnkView_Click">View</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="createdept" runat="server" style="display: block;">
                                    <div style="overflow: scroll; height: 600px;">
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
                                                                        Customer Name <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:DropDownList ID="ddl_customer" runat="server" CssClass="blue1" Width="145px"
                                                                            Height="20px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Status <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:DropDownList ID="ddl_prostat_create" runat="server" CssClass="blue1" Width="145px"
                                                                            Height="20px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Code <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_pro_code" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_pro_code"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Enter Project Code" ValidationGroup="c"
                                                                            ErrorMessage="Enter Project Code" Width="6px"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Name <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_pro_name" runat="server" MaxLength="50" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pro_name"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Enter Project Name" ValidationGroup="c"
                                                                            ErrorMessage="Enter Project Name" Width="6px"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="25%">
                                                                        Project Admin<span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_proadmin" ClientIDMode="Static" runat="server" Width="142px" CssClass="blue1"></asp:TextBox>
                                                                        &nbsp; <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?MSS=0&HR=0&Emp=1&Con=txt_proadmin');"
                                                                            class="link05">Pick Employee</a>
                                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_proadmin"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Enter Project Admin" ValidationGroup="c"
                                                                            ErrorMessage="Enter Project Admin" Width="6px"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="25%">
                                                                        Due Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_duedate" runat="server" Width="142px" CssClass="blue1"></asp:TextBox>&nbsp;&nbsp;
                                                                        <img src="../../images/Calendar_scheduleHS.png" alt="duedate" id="img_duedate" />
                                                                        <Ajax:CalendarExtender runat="server" ID="Cal_duedate" PopupButtonID="img_duedate"
                                                                            TargetControlID="txt_duedate" PopupPosition="BottomRight" Format="dd-MMM-yyyy">
                                                                        </Ajax:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="25%">
                                                                        Delay Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_delaydate" runat="server" Width="142px" CssClass="blue1"></asp:TextBox>&nbsp;&nbsp;
                                                                        <img src="../../images/Calendar_scheduleHS.png" alt="duedate" id="img_delaydate" />
                                                                        <Ajax:CalendarExtender runat="server" ID="cal_delaydate" PopupButtonID="img_delaydate"
                                                                            TargetControlID="txt_delaydate" PopupPosition="BottomRight" Format="dd-MMM-yyyy">
                                                                        </Ajax:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                        <asp:GridView ID="grdviewadmin" runat="server" AutoGenerateColumns="false">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="EmpCode">
                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Employee Name">
                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                    <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="l3" runat="server" Text='<%# bind ("empcode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="25%">
                                                                        Description
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_desc" runat="server" MaxLength="100" Width="170px" CssClass="blue1" TextMode="MultiLine"
                                                                            Height="75px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table id="tbl1" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123">
                                                                                    &nbsp; Add Activity
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="3">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div id="divactivity" style="overflow: scroll; width: 500px; height: 500px" runat="server">
                                                                                        <asp:GridView ID="grdActivity" runat="server" DataKeyNames="Id" AutoGenerateColumns="false" Width="100%"
                                                                                            EmptyDataText="No Emp record found" OnRowDataBound="grdActivity_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:TemplateField>
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <HeaderTemplate>
                                                                                                        <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:CheckBox ID="chkselect" runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Activity Name">
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("ActivityName") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="3">
                                                                                    &nbsp;
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
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <div id="divcreate" runat="server">
                                                                                        <asp:Button ID="btncreate" runat="server" Text="Save" CssClass="button" ValidationGroup="c"
                                                                                            OnClick="btncreate_Click"></asp:Button>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <div id="divSave" runat="server">
                                                                                        <asp:Button ID="btnSave" runat="server" Text="Update" CssClass="button" ValidationGroup="c"
                                                                                            OnClick="btnSave_Click"></asp:Button>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="Btncancel1" runat="server" Text="Cancel" CssClass="button" OnClick="Btncancel1_Click">
                                                                                    </asp:Button>
                                                                                </td>
                                                                            </tr>
                                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="c"
                                                                                ShowMessageBox="true" ShowSummary="false" />
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        Mandatory Fields (<span style="color: Red">*</span>)
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="viewdept" runat="server" style="display: block;">
                                    <div style="overflow: scroll; height: 490px;">
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tbody>
                                                <tr>
                                                    <td height="5" valign="top">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="25%">
                                                                        Customer ID
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="75%">
                                                                        <asp:Label ID="LblCmpyName" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="LblDeptName" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Description
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="LblDeptCode" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Admin
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label runat="server" ID="lbl_admin"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Project Status
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label runat="server" ID="lbl_status"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Due Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_duedate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Delay Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_delaydate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:GridView ID="grdadmin" runat="server" AutoGenerateColumns="false">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="EmpCode">
                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Employee Name">
                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                    <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="l3" runat="server" Text='<%# bind ("empcode") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" class="frm-lft-clr123">
                                                                      <%--  Project Activity--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Button ID="BtnCancel" runat="server" Text="Back" CssClass="button" OnClick="BtnCancel_Click">
                                                                        </asp:Button>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
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
                                <div id="GridDept" runat="server" style="overflow: hidden; height: 490px; display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="13%">
                                                                Project
                                                            </td>
                                                            <td class="frm-rght-clr123" width="10%">
                                                                <asp:TextBox ID="txt_employee" MaxLength="20" runat="server" CssClass="input" Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Project Status
                                                            </td>
                                                            <td class="frm-rght-clr123" width="13%">
                                                                <asp:DropDownList ID="ddl_Projectstatus" runat="server" CssClass="select" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <%-- <td class="frm-lft-clr123" width="10%">
                                                                Project
                                                            </td>
                                                            <td class="frm-rght-clr123" width="13%">
                                                                <asp:DropDownList ID="ddl_Project" runat="server" CssClass="select" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>--%>
                                                            <td class="frm-rght-clr123" width="10%">
                                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
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
                                                <td class="frm-rght-clr123">
                                                    <table cellpadding="0" cellspacing="0" width="99%" border="0">
                                                        <tr align="right">
                                                            <td align="right">
                                                                <label>
                                                                    <asp:LinkButton ID="lnkPre" runat="server" SkinID="linkGrid" CommandName="Previous"
                                                                        ForeColor="#013366" OnCommand="ChangePage"><b>Previous</b></asp:LinkButton>
                                                                    &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" SkinID="linkGrid" runat="server"
                                                                        ForeColor="#013366" CommandName="Next" OnCommand="ChangePage"><b>Next</b></asp:LinkButton>
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
                                                                <asp:DropDownList ID="ddlPageSize" runat="server" EnableViewState="true" CssClass="select"
                                                                    Width="40" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                                                </asp:DropDownList>
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
                                                    <div id="dvResult" style="overflow:scroll; height: 400px; border: 0px #000 solid;"
                                                        runat="server">
                                                        <asp:GridView ID="Grid_Dept" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                            EmptyDataText="No Record Found.." CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                            AllowSorting="True" BorderWidth="1px" OnPageIndexChanging="Grid_Dept_PageIndexChanging"
                                                            OnRowCommand="Grid_Dept_RowCommand" OnRowEditing="Grid_Dept_RowEditing" OnSorting="Grid_Dept_Sorting"
                                                            BorderColor="#c9dffb" OnRowDataBound="Grid_Dept_RowDataBound">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>
                                                             <asp:TemplateField HeaderText="Project Code" SortExpression="ProjectCode">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_projectcode" runat="server" Text='<%# Bind("ProjectCode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Project Name" SortExpression="ProjectName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_proname" runat="server" Text='<%# Bind("ProjectName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                               
                                                                <asp:TemplateField HeaderText="Project Admin" SortExpression="adminName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_admin" runat="server" Text='<%# Bind("adminName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Due Date" SortExpression="DueDate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lbl_duedate" runat="server" Text='<%# Bind("DueDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delay">
                                                                    <ItemTemplate>
                                                                        <%--   <asp:Label ID="lbl_delay" runat="server" ToolTip='<%# bind("DueDate")%>'></asp:Label>--%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Project Status" SortExpression="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action" SortExpression="ID">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="20%" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Edit_btn" class="link01" runat="server" ToolTip="Edit" CommandName="Edit"
                                                                            CommandArgument='<%# Eval("Id") %>'>Edit</asp:LinkButton>
                                                                        |
                                                                        <asp:LinkButton ID="View_btn" class="link01" runat="server" CommandName="View" CommandArgument='<%# Eval("Id") %>'
                                                                            ToolTip="View">View</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
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
