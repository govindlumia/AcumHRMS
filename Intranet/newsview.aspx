<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsview.aspx.cs" Inherits="newsview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css" media="all">
        @import "../css/blue.css";
        @import "../css/home.css";
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
                    <td valign="top" class="dot-line">
                         News Room</td>
                </tr>
                <tr>
                    <td height="26" valign="bottom">
                       <%-- &nbsp;&nbsp;<a href="newsview.aspx" class="link-red1">Today's News</a> &nbsp;l&nbsp;
                        <a href="newsview.aspx?news=1" class="link-red1">Date Wise News</a>&nbsp;l&nbsp;
                        <a href="newsview.aspx?news=2" class="link-red1">Priority Wise News</a> &nbsp;&nbsp;--%><asp:TextBox
                            ID="txtsearch" CssClass="input1" Text="" runat="server" MaxLength="150" Width="241px"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="go-btn" OnClick="btnsearch_Click" /></td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="Newsgrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No news has been posted today. Click on Datewise link to view more news"
                            ToolTip="News posted" AllowPaging="True" OnPageIndexChanging="Newsgrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="../images/arrows1.gif" width="3" height="5" /></td>
                                                <td width="98%" valign="top">
                                                    <a href="newsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>" class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                    ....
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
                        <asp:GridView ID="newsdatewise" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No news has been posted" ToolTip="News posted" AllowPaging="True"
                            OnPageIndexChanging="newsdatewise_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="../images/arrows1.gif" width="3" height="5" /></td>
                                                <td valign="top">
                                                    Posted On :
                                                    <%#DataBinder.Eval(Container.DataItem,"posteddate")%>
                                                    , By :
                                                    <%#DataBinder.Eval(Container.DataItem,"postedby")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td width="98%" valign="top">
                                                    <a href="newsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>" class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                    ....
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
                        <asp:GridView ID="priority" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No news has been posted in priority category" ToolTip="News posted"
                            AllowPaging="True" OnPageIndexChanging="priority_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="../images/arrows1.gif" width="3" height="5" /></td>
                                                <td valign="top">
                                                    Posted On :
                                                    <%#DataBinder.Eval(Container.DataItem,"posteddate")%>
                                                    , By :
                                                    <%#DataBinder.Eval(Container.DataItem,"postedby")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td width="98%" valign="top">
                                                    <a href="newsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>" class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                    ....
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
                            EmptyDataText="No news has been found" ToolTip="News posted" AllowPaging="True"
                            OnPageIndexChanging="searchgrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="../images/arrows1.gif" width="3" height="5" /></td>
                                                <td width="98%" valign="top">
                                                    <a href="newsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>" class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                    ....
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
                <tr>
                    <td colspan="2" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="14%" class="txt01">
                                 <%--   Select Category--%></td>
                                <td width="18%">
                                    <asp:DropDownList ID="ddlcategory" CssClass="select2" runat="server" Visible="false">
                                    </asp:DropDownList>
                                </td>
                                <td width="68%">
                                    <asp:Button ID="btngo" runat="server" Text="Go" Width="27px" OnClick="btngo_Click"
                                        CssClass="go-btn" Visible="false" />
                                    <span id="message" runat="server" enableviewstate="false" class="txt02"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
