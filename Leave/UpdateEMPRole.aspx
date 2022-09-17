<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateEMPRole.aspx.cs" Inherits="Leave_UpdateEMPRole" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>View Employee Role</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
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
                                    <img src="../images/loading.gif" />
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
                <table width="1000" border="0" align="center" cellspacing="0" cellpadding="0" background="../../images/bg.gif">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Update Employee Role
                                    </td>
                                    <td align="right" style="padding-right: 10px;">
                                        <a href="~/Admin/Employee/AdminPanel.aspx" id="lnkBack" runat="server" class="link06">
                                            &gt;&gt; Back </a>
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
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="15%">
                                        Company
                                    </td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:DropDownList ID="drpcompany" runat="server" CssClass="select" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpcompany_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="frm-lft-clr123" width="15%">
                                        Update Type
                                    </td>
                                    <td class="frm-rght-clr123" width="15%">
                                        <asp:DropDownList ID="drpType" runat="server" CssClass="select" AutoPostBack="True"
                                            OnSelectedIndexChanged="drpType_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Single Update</asp:ListItem>
                                            <asp:ListItem Value="1">Bulk Update</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="frm-rght-clr123" width="40%">
                                        <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="button" Text="Update All"
                                            OnClick="btnUpdate_Click" />
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
                        <td>
                            <div id="singleUpdate" runat="server" style="display: block;">
                                <asp:GridView ID="grdResult" runat="server" AllowPaging="true" PageSize="20" Font-Size="11px"
                                    Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                    EmptyDataText="No Data Found.." OnRowDataBound="grdResult_RowDataBound" OnRowCommand="grdResult_RowCommand"
                                    OnRowUpdating="grdResult_RowUpdating" OnPageIndexChanging="grdResult_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Employee Name
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Employee Code
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Department
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Designation
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Role
                                                        </td>
                                                        <td width="10%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Action
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Bind ("EMPName") %>'></asp:Label>
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="lblEmpCode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="lblDept" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="lblDesig" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                        </td>
                                                        <td width="18%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:DropDownList ID="ddlRole" CssClass="select" Width="145px" Height="20px" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblRoleID" runat="server" Visible="false" Text='<%# Bind ("id") %>'></asp:Label>
                                                        </td>
                                                        <td width="10%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:LinkButton ID="lnkUpdate" CssClass="link02" CommandName="Update" CommandArgument='<%# Bind ("empcode") %>'
                                                                runat="server">Update</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                </asp:GridView>
                            </div>
                            <div id="bulkUpdate" runat="server" style="display: none;">
                                <asp:GridView ID="grdBulk" runat="server" AllowPaging="true" PageSize="20" Font-Size="11px"
                                    Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                    EmptyDataText="No Data Found.." OnRowDataBound="grdResult_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Employee Name
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Employee Code
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Department
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Designation
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-lft-clr123">
                                                            Role
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%">
                                                    <tr>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("EMPName") %>'></asp:Label>
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                        </td>
                                                        <td width="20%" align="Left" valign="Top" cssclass="frm-rght-clr1234">
                                                            <asp:DropDownList ID="ddlRole" CssClass="select" Width="145px" Height="20px" runat="server">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblRoleID" runat="server" Visible="false" Text='<%# Bind ("id") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <RowStyle Height="5px" />
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 10px;">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
