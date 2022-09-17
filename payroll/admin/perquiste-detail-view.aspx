<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perquiste-detail-view.aspx.cs"
    Inherits="payroll_admin_perquiste_detail_view" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>
<script language="javascript" type="text/javascript">
    function checkNumericValue(cntl) {

        if (cntl != null) {
            if (isNaN(cntl.value) || cntl.value.trim() == '') {
                alert('Please enter only numeric value');
                cntl.value = "";
                return false;
            }
        }
        return true;
    }
    
    </script>
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
                                                    Perquisite Detail Entry</td>
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
                                        <table width="718" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="txt02">
                                                    Create Perquisite Detail
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td height="5" valign="top">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="25%" class="frm-lft-clr123">
                                                                            Perquisite Name</td>
                                                                        <td width="75%" class="frm-rght-clr123">
                                                                            <asp:DropDownList ID="ddlperquistename" runat="server" Width="207px" CssClass="select"
                                                                                DataSourceID="SqlDataSource12" DataTextField="name" DataValueField="id">
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                ProviderName="System.Data.SqlClient" SelectCommand="select id, name from tbl_payroll_perquisite_head where flag=1  order by name">
                                                                            </asp:SqlDataSource>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" class="frm-lft-clr123">
                                                                            &nbsp;Perquisite Details</td>
                                                                        <td width="75%" class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txtperquistedetail" runat="server" CssClass="input" Width="201px"
                                                                                MaxLength="50"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtperquistedetail"
                                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" class="frm-lft-clr123">
                                                                            &nbsp;Perquisite Amount</td>
                                                                        <td width="75%" class="frm-rght-clr123">
                                                                            
                                                                            <asp:TextBox ID="txtamount" runat="server" CssClass="input" Width="198px" onkeyup="checkNumericValue(this)" MaxLength="9"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtamount"
                                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtamount"
                                                                                ErrorMessage="Enter correct amount" MaximumValue="100000000" MinimumValue="0"
                                                                                Type="Double" ValidationGroup="v"></asp:RangeValidator></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" class="frm-lft-clr123">
                                                                            Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;</td>
                                                                        <td width="75%" class="frm-rght-clr123">
                                                                            &nbsp;
                                                                            <asp:Button ID="btncreatsection" runat="server" Text="Submit" CssClass="button" ValidationGroup="v"
                                                                                ToolTip="Click to submit " OnClick="btncreatsection_Click" /></td>
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
                                                            <td height="5">
                                                                Perquisite Detail View</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-rght-clr123" colspan="2">
                                                                &nbsp;&nbsp;
                                                                <asp:GridView ID="perquistedetailgrid" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                    BorderWidth="0px" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2"
                                                                    EmptyDataText="Sorry no record found" Font-Names="Arial" Font-Size="11px" PageSize="50"
                                                                    Width="100%" OnRowUpdating="perquistedetailgrid_RowUpdating" 
                                                                    onrowediting="perquistedetailgrid_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Perquisite">
                                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="40%" />
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblnameg" runat="server" Text='<%#Bind("perquistehead")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:DropDownList ID="ddlnameg" runat="server" DataSourceID="sqlnameg" DataTextField="name"
                                                                                    DataValueField="id" SelectedValue='<%#Bind("headid")%>' Width="211px">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource ID="sqlnameg" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT id, name FROM tbl_payroll_perquisite_head where flag=1">
                                                                                </asp:SqlDataSource>
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Detail">
                                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="35%" />
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblperquistedetailg" runat="server" Text='<%#Bind("perquistedetail")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtperquistedetailg" runat="server" Text='<%#Bind("perquistedetail")%>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtperquistedetailg"
                                                                                    ErrorMessage="Enter Name" ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount">
                                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblamountg" runat="server" Text='<%#Bind("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:TextBox ID="txtamountg" runat="server" Text='<%#Bind("amount")%>'></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtamountg"
                                                                                    Display="Dynamic" ErrorMessage="Enter amount" ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtamountg"
                                                                                    Display="Dynamic" ErrorMessage="Enter correct amount" MaximumValue="999999999"
                                                                                    MinimumValue="0" Type="Double" ValidationGroup="grid"></asp:RangeValidator>
                                                                            </EditItemTemplate>
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
                                                                            <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                                    Enabled='<%#Bind("flag")%>' CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                                
                                                                               <%-- <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" Enabled='<%#Bind("flag")%>'
                                                                                    OnClientClick="return confirm(' Do you want to Delete this record?');" CommandName="Delete"
                                                                                    CssClass="link05" Text="Delete" ToolTip="Delete" />--%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                    <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                                    <RowStyle Height="5px" />
                                                                </asp:GridView>
                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT h.id headid, h.name perquistehead,d.id id,d.name perquistedetail,d.amount, d.flag from tbl_payroll_perquisite_head h INNER JOIN tbl_payroll_perquiste_detail d ON h.id=d.head_id&#13;&#10;ORDER BY h.id,d.name&#13;&#10;"
                                                                    DeleteCommand="DELETE FROM tbl_payroll_perquiste_detail WHERE id=@id" UpdateCommand="UPDATE tbl_payroll_perquiste_detail SET head_id=@head_id, name=@name, amount=@amount&#13;&#10;where id=@id">
                                                                    <DeleteParameters>
                                                                        <asp:Parameter Name="id" />
                                                                    </DeleteParameters>
                                                                    <UpdateParameters>
                                                                        <asp:Parameter Name="head_id" />
                                                                        <asp:Parameter Name="name" />
                                                                        <asp:Parameter Name="amount" />
                                                                        <asp:Parameter Name="id" />
                                                                    </UpdateParameters>
                                                                </asp:SqlDataSource>
                                                            </td>
                                                        </tr>
                                                    </table>
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
