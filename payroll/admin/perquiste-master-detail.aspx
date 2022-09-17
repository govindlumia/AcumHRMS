<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perquiste-master-detail.aspx.cs"
    Inherits="payroll_admin_perquiste_master_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01">
                                                    Perquisite Master</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="27%" class="txt02">
                                                </td>
                                                <td width="73%" align="right" class="txt-red">
                                                    <span id="message" runat="server"></span>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="txt02">
                                        Create Perquisite
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Perquisite Head</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    &nbsp;<asp:TextBox ID="txtperquistename" runat="server" CssClass="input" Width="152px"
                                                        MaxLength="50"></asp:TextBox>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtperquistename"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                        ValidationGroup="s" ToolTip="Click to submit " />&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="5" class="txt02">
                                        View Perquisite Head</td>
                                </tr>
                                <tr>
                                    <td class="frm-rght-clr123" colspan="2">
                                        <asp:GridView ID="perquistegird" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            BorderWidth="0px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1"
                                            EmptyDataText="Sorry no record found" Font-Names="Arial" Font-Size="11px" PageSize="30"
                                            Width="100%" OnRowUpdating="perquistegird_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Perquisite Head">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblperquistenameg" runat="server" Text='<%#Bind("name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtperquistenameg" runat="server" CssClass="blue1" Text='<%#Bind("name")%>'
                                                            ValidationGroup="grid"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Perquisite Head can not be blank"
                                                            ControlToValidate="txtperquistenameg" ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="80%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnupdate" runat="server" CausesValidation="false" ValidationGroup="grid"
                                                            OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update"
                                                            CssClass="link05" Text="Update" ToolTip="Update" />
                                                        |
                                                        <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                            CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            CssClass="link05" Text="Edit" Enabled='<%#Bind("flag")%>' ToolTip="Edit" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                            ProviderName="System.Data.SqlClient" DeleteCommand="DELETE FROM tbl_payroll_perquisite_head WHERE id=@id"
                                            SelectCommand="SELECT id,name,flag from tbl_payroll_perquisite_head ORDER BY id"
                                            UpdateCommand="update tbl_payroll_perquisite_head set name=@name where id=@id"
                                            InsertCommand="INSERT INTO tbl_payroll_perquisite_head(name) VALUES(@name)">
                                            <DeleteParameters>
                                                <asp:Parameter Name="id" Type="Int32" />
                                            </DeleteParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="name" Type="String" />
                                                <asp:Parameter Name="id" Type="Int32" />
                                            </UpdateParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="name" Type="String" />
                                            </InsertParameters>
                                            <SelectParameters>
                                                <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
