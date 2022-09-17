<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pickemployee.aspx.cs" Inherits="Leave_admin_pickemployee"
    Title="Employee Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Details</title>
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function returnempcode(val) {
            window.opener.updateValue(val);
            window.close();
        }
    </script>
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
                                    <img src="../../images/loading.gif" alt="" />
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
                <table width="803" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="middle" class="txt02 blue-brdr-1">
                            &nbsp;Search Employee
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="11%">
                                        Employee Name
                                    </td>
                                    <td class="frm-rght-clr123" width="11%">
                                        <asp:TextBox ID="txtEmpCode" runat="server" CssClass="input" Width="100px"></asp:TextBox>
                                    </td>
                                    <td class="frm-lft-clr123" width="11%">
                                        Designation
                                    </td>
                                    <td class="frm-rght-clr123" width="11%">
                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="select" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="frm-lft-clr123" style="width: 11%">
                                        Category
                                    </td>
                                    <td class="frm-rght-clr123" width="11%">
                                        &nbsp;<asp:DropDownList ID="dd_category" runat="server" CssClass="select"
                                            Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                     <td class="frm-lft-clr123" width="11%">
                                                                        Business Unit
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="11%">
                                                                        <asp:DropDownList ID="dd_bu" runat="server" CssClass="select" Width="100px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                    <td class="frm-lft-clr123" width="12%">
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="top" class="txt02">
                                                                &nbsp;Employee Record
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="head-2" valign="top">
                                                                <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                    CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                    BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                                    OnRowEditing="empgrid_RowEditing" OnPageIndexChanging="empgrid_PageIndexChanging"
                                                                    OnRowDataBound="empgrid_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton class="link05" ID="lnk" runat="server"><%#Eval("empcode") %></asp:LinkButton>
                                                                                <asp:Label ID="value" runat="server" Visible="false" Text='<%#Eval("empcode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("EMPNAME") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Designation">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Category">
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("CategoryName") %>'></asp:Label>
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
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top">
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
