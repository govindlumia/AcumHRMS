﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TimeSheet/Admin/TimesheetMaster.master"
    AutoEventWireup="true" CodeFile="ProjectStatus.aspx.cs" Inherits="TimeSheet_Admin_ProjectStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    </style>
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
                                            Project Status Master
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
                                <asp:LinkButton ID="lnkCreate" CssClass="link02" runat="server" OnClick="lnkCreate_Click">Create New</asp:LinkButton>
                                <asp:LinkButton ID="lnkView" CssClass="link02" runat="server" OnClick="lnkView_Click">View</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="5">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="createProjectstatus" runat="server" style="display: block;">
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
                                                                    <td class="frm-lft-clr123">
                                                                        Project Status <span style="color: Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_emp_status" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_emp_status"
                                                                            Display="None" SetFocusOnError="True" ToolTip="Enter Project Status" ValidationGroup="c"
                                                                            ErrorMessage="Enter Project Status" Width="6px"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Description
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_desc" MaxLength="50" runat="server" CssClass="blue1" Width="142px" TextMode="MultiLine"></asp:TextBox>
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
                                                                                            ValidationGroup="c"  OnClick="btnsavenew_Click"></asp:Button>
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
                                                <%--     <tr>
                                                <td colspan="2">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                </td>
                                            </tr>--%>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="viewempstatus" runat="server" style="display: block;">
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
                                                                    <td class="style2">
                                                                        Project Status
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="LblEmpStatus" runat="server" Width="142px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style2">
                                                                        Description
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="LblDesc" runat="server" Width="142px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style2">
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
                                <div id="GridempStatus" runat="server" style="overflow: hidden; height: 490px; display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="13%">
                                                                Project Status Name
                                                            </td>
                                                            <td class="frm-rght-clr123" width="10%">
                                                                <asp:TextBox ID="txt_employee" MaxLength="20" runat="server" CssClass="input" Width="100px"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="10%">
                                                                Project Status
                                                            </td>
                                                            <td class="frm-rght-clr123" width="13%">
                                                                <asp:DropDownList ID="dd_Status" runat="server" CssClass="select" Width="150px">
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
                                                        <asp:GridView ID="Grid_empstatus" runat="server" AllowPaging="True" Width="100%"
                                                            HorizontalAlign="Left" CellPadding="0" CaptionAlign="Left" AutoGenerateColumns="False"
                                                            AllowSorting="True" BorderWidth="1px" OnPageIndexChanging="Grid_empstatus_PageIndexChanging"
                                                            OnRowCommand="Grid_empstatus_RowCommand" OnRowEditing="Grid_empstatus_RowEditing"
                                                            OnSorting="Grid_empstatus_Sorting" BorderColor="#c9dffb">
                                                            <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Project Status" SortExpression="Status">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="left" Width="45%" CssClass="frm-rght-clr1234" />
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="45%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action" SortExpression="Edit">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="left" Width="10%" CssClass="frm-rght-clr1234" />
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
                                                            <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                                                VerticalAlign="Top" />
                                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                                NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
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
