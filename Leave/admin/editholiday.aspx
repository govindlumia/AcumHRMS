<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editholiday.aspx.cs" Inherits="Leave_admin_editholiday"
    Title="Acuminous Software." %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%--<title>Acuminous Software Intranet</title>--%>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

}
</script>--%>
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
                                    <img src="../images/loading.gif" />
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
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" height="463">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">
                                                Holiday Master
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="7" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="20" valign="top" class="txt02">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="27%" class="txt02">
                                                            &nbsp;View Holiday List
                                                        </td>
                                                        <td width="73%" align="right" class="txt-red">
                                                            <span id="message" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <%--  <tr>
                      <td class="frm-lft-clr123" width="17%">Branch</td>
                      <td width="60%" class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                      <td><asp:DropDownList ID="ddlbranch" runat="server"  DataSourceID="SqlDataSource1"
                              DataTextField="branch_name" DataValueField="branch_id"
                              OnSelectedIndexChanged="ddlbranch_SelectedIndexChanged" ToolTip="Select Branch" CssClass="select"
                              Width="182px" AppendDataBoundItems="True">
                          <asp:ListItem Value="0">For all Branch</asp:ListItem>
                          </asp:DropDownList>
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                              ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                          </asp:SqlDataSource> </td>
                      <td align="right" width="23%"><asp:Button ID="search" runat="server" Text="Search" CssClass="button" OnClick="search_Click"/>&nbsp;</td>
                      </tr>
                   </table></td>
</tr>--%>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>
                                                         <tr>
                                                      <td class="frm-lft-clr123" style="width:50%">
                                                      Select year
                                                        </td>
                                                        <td  class="frm-rght-clr123">
                                                        <asp:DropDownList runat="server" ID="ddl_year"  AutoPostBack="true"
                                                                onselectedindexchanged="ddl_year_SelectedIndexChanged"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5">
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="head-2">
                                    <asp:GridView ID="holidaygrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        BorderWidth="0px" CellPadding="4" CellSpacing="0" DataKeyNames="holidayid" Font-Names="Arial"
                                        Font-Size="11px" Width="100%" AllowPaging="True" PageSize="20" OnPageIndexChanging="holidaygrid_PageIndexChanging"
                                        OnRowDeleting="holidaygrid_RowDeleting" EmptyDataText="No Data Available !" OnRowEditing="holidaygrid_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Name">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="32%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="16%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l411" runat="server" Text='<%# Eval("Date", "{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Day of Week">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="16%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# GetDay(Eval("Date").ToString())%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="20%" />
                                                <ItemTemplate>
                                                    <a class="link05" href="updateholiday.aspx?holidayid=<%#DataBinder.Eval(Container.DataItem, "holidayid")%>"
                                                        target="_self">Edit</a> |
                                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05"
                                                        OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                <td align="right" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
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
