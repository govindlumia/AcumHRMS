<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewbankmaster.aspx.cs" Inherits="payroll_admin_viewbankmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">

@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../js/timepicker.js"></script>

    <script type="text/javascript">
ddaccordion.init({
headerclass: "expandable", //Shared CSS class name of headers group
contentclass: "submenu", //Shared CSS class name of contents group
collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
animatedefault: false, //Should contents open by default be animated into view?
persiststate: true, //persist state of opened contents within browser session?
toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
})
    </script>

    <script type="text/javascript">
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="bank" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                                                <td class="txt01" style="height: 16px">
                                                    Bank Master</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" valign="top">
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
                                                                View Bank Details</td>
                                                            <td width="73%" align="right" class="txt-red">
                                                                <span id="message" runat="server"></span>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-2">
                                                    <asp:GridView ID="bankgird" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"
                                                        DataKeyNames="branchcode" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                                        EmptyDataText="Sorry no record found" DataSourceID="SqlDataSource1" AllowPaging="True"
                                                        PageSize="30">
                                                        <Columns>
                                                            <asp:BoundField DataField="bankname" HeaderText="Bank Name" SortExpression="bankname">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="branchcode" HeaderText="Bank Code" SortExpression="branchcode">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="accountnumber" HeaderText="Account Number" SortExpression="accountnumber">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="address" HeaderText="Bank Address" SortExpression="Bank Address">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Center" VerticalAlign="Top"
                                                                    Width="15%" />
                                                                <ItemTemplate>
                                                                    <a class="link05" href="updatebankmaster.aspx?branchcode=<%#DataBinder.Eval(Container.DataItem, "branchcode")%>"
                                                                        target="_self">Edit</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        SelectCommand="SELECT [branchcode], [bankname], [accountnumber], [address] FROM [tbl_payroll_bank]"
                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;</td>
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
