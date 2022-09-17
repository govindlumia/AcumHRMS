<%@ Page Language="C#" AutoEventWireup="true" CodeFile="suggestionview.aspx.cs" Inherits="suggestionview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css" media="all">
        @import "css/blue.css";
        @import "css/home.css";
        </style>

    <script type="text/javascript">
        function WatermarkFocus(txtElem, strWatermark) 
        {
            if (txtElem.value == strWatermark) 
                txtElem.value = '';
        }
        function WatermarkBlur(txtElem, strWatermark) 
        {
            if (txtElem.value == '') 
                txtElem.value = strWatermark;
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" style="height: 28px">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="22" valign="top" class="dot-line">
                        Suggestions</td>
                </tr>
                <tr>
                    <td height="26" valign="middle">
                        &nbsp;&nbsp;<a href="suggestionpost.aspx?view=1" class="link-red1">Suggestion Post </a>
                        &nbsp;l&nbsp; <span class="txt01">Suggestion View</span></td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;<span id="message" runat="server" enableviewstate="false" class="txt02"></span></td>
                </tr>
                <tr>
                    <td height="26" valign="bottom">
                        &nbsp;&nbsp;<a href="suggestionview.aspx" class="link-red1">View All Suggestions</a>&nbsp;&nbsp;<asp:TextBox
                            ID="txtsearch" CssClass="input1" Text="" runat="server" MaxLength="150" Width="241px"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="go-btn" OnClick="btnsearch_Click" /></td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="suggestiongrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No suggestion has been posted." ToolTip="Suggestions posted today"
                            AllowPaging="True" OnPageIndexChanging="suggestiongrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                          
                                            <tr>
                                                <td>
                                                </td>
                                                <td width="98%" valign="top">
                                                    <%#DataBinder.Eval(Container.DataItem,"subject")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="images/arrows1.gif" width="3" height="5" /></td>
                                                <td valign="top">
                                                    Posted On :
                                                    <%#DataBinder.Eval(Container.DataItem,"posteddate")%>
                                                    , By :
                                                    <%#DataBinder.Eval(Container.DataItem,"postedby")%>
                                                    (
                                                    <%#DataBinder.Eval(Container.DataItem,"department_name")%>
                                                    )
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="8" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        </asp:GridView>
                        <asp:GridView ID="searchgrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No such suggestion has been found." ToolTip="Suggestions posted"
                            AllowPaging="True" OnPageIndexChanging="searchgrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="images/arrows1.gif" width="3" height="5" /></td>
                                                <td valign="top">
                                                    Posted On :
                                                    <%#DataBinder.Eval(Container.DataItem,"posteddate")%>
                                                    , By :
                                                    <%#DataBinder.Eval(Container.DataItem,"postedby")%>
                                                    (
                                                    <%#DataBinder.Eval(Container.DataItem,"department_name")%>
                                                    )
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td width="98%" valign="top">
                                                    <%#DataBinder.Eval(Container.DataItem, "subject")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="8" colspan="2">
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
