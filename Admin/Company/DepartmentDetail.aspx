<%@ Page Title="Category Master" Language="C#" MasterPageFile="~/Admin/Company/CompanyMaster.master"
    AutoEventWireup="true" CodeFile="DepartmentDetail.aspx.cs" Inherits="Admin_Company_DepartmentDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
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
                                            Department Master
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
                                    <div style="overflow: scroll; height: 490px;">
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
                                                                    <td class="frm-lft-clr123" width="25%">
                                                                        Company Name <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="75%">
                                                                        <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" Width="145px"
                                                                            Height="20px">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="rfvComplaintType" runat="server" ControlToValidate="drp_comp_name"
                                                                            Display="None" ValidationGroup="c" ErrorMessage="Please select Company Name"
                                                                            InitialValue="0" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Department Code <%--<span style="color: Red">*</span>--%>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_dept_code"  MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dept_code"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Enter Category code" ValidationGroup="c"
                                                                            ErrorMessage="Enter Category code" Width="6px"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Department Name <%--<span style="color: Red">*</span>--%>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_dept_name"  MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dept_name"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Enter Category Name" ValidationGroup="c"
                                                                            ErrorMessage="Enter Category name" Width="6px"></asp:RequiredFieldValidator>--%>
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
                                                                                        <asp:Button ID="btnsavenew" runat="server" Text="Save & Add New" CssClass="button2"
                                                                                            ValidationGroup="c" OnClick="btnsavenew_Click"></asp:Button>
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
                                                                        Company Name
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
                                                                        Department Name
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
                                                                        Department Code
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
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="BtnCancel_Click">
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
                                                                Department
                                                            </td>
                                                            <td class="frm-rght-clr123" width="10%">
                                                                <asp:TextBox ID="txt_employee"  MaxLength="50" runat="server" CssClass="input" Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Company
                                                            </td>
                                                            <td class="frm-rght-clr123" width="13%">
                                                                <asp:DropDownList ID="ddl_company" runat="server" CssClass="select" Width="100px"
                                                                    OnSelectedIndexChanged="ddl_company_OnSelectedIndexChanged" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Department
                                                            </td>
                                                            <td class="frm-rght-clr123" width="13%">
                                                                <asp:DropDownList ID="ddl_Department" runat="server" CssClass="select" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
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
                                                    <div id="dvResult" style="overflow: auto; height: 490px; border: 0px #000 solid;"
                                                        runat="server">
                                                        <asp:GridView ID="Grid_Dept" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" AllowSorting="True" EmptyDataText="no record(s) found"
                                                            BorderWidth="1px" OnPageIndexChanging="Grid_Dept_PageIndexChanging" OnRowCommand="Grid_Dept_RowCommand"
                                                            OnRowEditing="Grid_Dept_RowEditing" OnSorting="Grid_Dept_Sorting" BorderColor="#c9dffb">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Company Name" SortExpression="companyname">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("companyname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department Code" SortExpression="DepartmentCode">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("DepartmentCode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department Name" SortExpression="DepartmentName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action" SortExpression="ID">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="10%" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Edit_btn" class="link01" runat="server" ToolTip="Edit" CommandName="Edit"
                                                                            CommandArgument='<%# Eval("ID") %>'>Edit</asp:LinkButton>
                                                                        |
                                                                        <asp:LinkButton ID="View_btn" class="link01" runat="server" CommandName="View" CommandArgument='<%# Eval("ID") %>'
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
