<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadallowance.aspx.cs"
    Inherits="payroll_admin_viewbankmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>YKK Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:ScriptManager ID="bank" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        <table width="718" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" height="463px">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%" style="height: 16px">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01" style="height: 16px">Upload Employee Allowances</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td valign="top" style="height: 5px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="14%">Financial Year</td>
                                        <td class="frm-rght-clr123" width="10%">
                                            <%--<asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>--%>
                                             <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                        CssClass="select" />
                                        </td>
                                        <td class="frm-lft-clr123" width="14%">Month</td>
                                        <td class="frm-rght-clr123" colspan="3">
                                            <asp:DropDownList ID="dd_month" runat="server" CssClass="select" DataTextField="month "
                                                DataValueField="month " ToolTip="Month" Width="145px" OnSelectedIndexChanged="dd_month_SelectedIndexChanged">                                               
                                                <asp:ListItem Value="4">Apr</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">Jun</asp:ListItem>
                                                <asp:ListItem Value="7">Jul</asp:ListItem>
                                                <asp:ListItem Value="8">Aug</asp:ListItem>
                                                <asp:ListItem Value="9">Sep</asp:ListItem>
                                                <asp:ListItem Value="10">Oct</asp:ListItem>
                                                <asp:ListItem Value="11">Nov</asp:ListItem>
                                                <asp:ListItem Value="12">Dec</asp:ListItem>
                                                 <asp:ListItem Value="1">Jan</asp:ListItem>
                                                <asp:ListItem Value="2">Feb</asp:ListItem>
                                                <asp:ListItem Value="3">Mar</asp:ListItem>
                                            </asp:DropDownList><asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                ToolTip="Select Month" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="14%">Allowance</td>
                                        <td class="frm-rght-clr123" width="15%">
                                            <asp:DropDownList ID="drpPayHead" runat="server" CssClass="select" ToolTip="Pay Head"
                                                Width="145px" OnDataBound="drpPayHead_DataBound">
                                            </asp:DropDownList><asp:CompareValidator ID="CompareValidator111" runat="server"
                                                ControlToValidate="drpPayHead" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator></td>
                                        <td class="frm-lft-clr123" width="14%%">File</td>
                                        <td class="frm-rght-clr123" colspan="3" width="20%">
                                            <asp:FileUpload ID="fupload" runat="server" CssClass="input" ToolTip="Upload File here"
                                                Width="200px" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$" ValidationGroup="a"><img src="../../images/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                                    ID="rfvupload" runat="server" ControlToValidate="fupload" Display="Dynamic" ErrorMessage="Attach Document"
                                                    ToolTip="Attach Document" ValidationGroup="a"><img src="../../images/error1.gif" alt="Attach Document" /></asp:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" style="height: 5px"></td>
                        </tr>
                        <tr>
                            <td height="5" align="right" valign="top">
                                <asp:Button ID="btn_view" runat="server" CssClass="button" OnClick="btn_view_Click"
                                    Text="View/Edit" ValidationGroup="v" />
                                <asp:Button ID="btnsv" runat="server" CssClass="button" OnClick="btnsv_Click" Text="Import"
                                    ValidationGroup="a" />
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top"></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="20" valign="top" class="txt02">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="27%" class="txt02" style="height: 13px">Allowance Detail</td>
                                                    <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                        <span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="head-2" valign="top">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                        runat="server">
                                                        <ProgressTemplate>
                                                            <div class="divajax" style="top: 160px;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img alt="" src="../../images/loading.gif" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:GridView ID="adjustgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                        CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" DataKeyNames="empcode,allowanceid,month,year"
                                                        OnRowCancelingEdit="adjustgrid_RowCancelingEdit" OnRowDeleting="adjustgrid_RowDeleting"
                                                        OnRowEditing="adjustgrid_RowEditing" OnRowUpdating="adjustgrid_RowUpdating" AllowPaging="True"
                                                        OnPageIndexChanging="adjustgrid_PageIndexChanging" PageSize="40" AllowSorting="True"
                                                        OnSorting="adjustgrid_Sorting" EmptyDataText="No data found">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Emp Code" SortExpression="empcode">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Name" SortExpression="empname">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Allowance">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("allowancename") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txt_nd" runat="Server" Text='<%# Eval("amount") %>' CssClass="input"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nd"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter days" />'
                                                                        ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nd"
                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter valid days" />'
                                                                        MaximumValue="1000000" MinimumValue="1" Type="Double" ValidationGroup="grid"></asp:RangeValidator>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lnk_update" CssClass="link05" CommandName="Update" runat="server"
                                                                        ValidationGroup="grid">Update</asp:LinkButton>|
                                                                    <asp:LinkButton ID="lnk_cancel" CssClass="link05" CommandName="Cancel" runat="server"
                                                                        ValidationGroup="noone">Cancel</asp:LinkButton>
                                                                </EditItemTemplate>
                                                                <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnk_edit" CssClass="link05" CommandName="Edit" runat="server"
                                                                        ValidationGroup="noone">Edit </asp:LinkButton>|
                                                                    <asp:LinkButton ID="lnk_delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');"
                                                                        CommandName="Delete" runat="server" ValidationGroup="noone">Delete</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                        <PagerSettings Position="TopAndBottom" />
                                                    </asp:GridView>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
