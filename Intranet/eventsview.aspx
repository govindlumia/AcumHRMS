<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eventsview.aspx.cs" Inherits="eventsview" %>

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
                <td valign="top" class="blue-brdr-1">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                <tr>
                    <td height="22" valign="top" class="dot-line">
                       Events</td>
                </tr>
                <tr>
                    <td height="26" valign="middle">
                        <%--&nbsp;&nbsp;<a href="eventsview.aspx" class="link-red1">Today's Events</a> &nbsp;&nbsp;l&nbsp;
                        <a href="eventsview.aspx?events=1" class="link-red1">Date Wise Events</a>&nbsp;l&nbsp;
                        <a href="eventsview.aspx?events=2" class="link-red1">Priority Wise Events</a>&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;--%>&nbsp;&nbsp;<asp:TextBox ID="txtsearch" CssClass="input1"
                            Text="" runat="server" MaxLength="150" Width="241px"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="go-btn" OnClick="btnsearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                       &nbsp;&nbsp;<img src="../images/date-icon.gif" width="10" height="10" alt="" runat="server"
                            id="img1"  visible="false"/>&nbsp;
                        <asp:Label ID="lbldate" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="eventsgrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No event has been posted."
                            ToolTip="events posted" AllowPaging="True" OnPageIndexChanging="eventsgrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="../images/arrows1.gif" width="3" height="5" /></td>
                                                <td width="98%" valign="top">
                                                    <a href="eventsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                        class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                          <%--  <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    Held On :
                                                    <%# Eval("eventdate", "{0:dd MMM yyyy}")%>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                    ....</td>
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
                        <asp:GridView ID="eventsdatewise" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="10" ShowHeader="False" Width="100%"
                            EmptyDataText="No event has been posted" ToolTip="events posted" AllowPaging="True"
                            OnPageIndexChanging="eventsdatewise_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                           
                                            <tr>
                                                <td>
                                                </td>
                                                <td width="98%" valign="top">
                                                    <a href="eventsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                        class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    Held On :
                                                    <%#DataBinder.Eval(Container.DataItem,"eventdate")%>
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    <%#DataBinder.Eval(Container.DataItem,"description")%>
                                                    ....
                                                </td>
                                            </tr>
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
                            EmptyDataText="No event has been posted in priority category" ToolTip="events posted"
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
                                                    <a href="eventsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                        class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    Held On :
                                                    <%#DataBinder.Eval(Container.DataItem,"eventdate")%>
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
                            EmptyDataText="No event has been found" ToolTip="events posted" AllowPaging="True"
                            OnPageIndexChanging="searchgrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"postedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="../images/arrows1.gif" width="3" height="5" /></td>
                                                <td width="98%" valign="top">
                                                    <a href="eventsdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                        class="link-red">
                                                        <%#DataBinder.Eval(Container.DataItem,"heading")%>
                                                    </a>
                                                </td>
                                            </tr>
                                           <%-- <tr>
                                                <td valign="top">
                                                </td>
                                                <td valign="top" class="text2">
                                                    Held On :
                                                   
                                                     <%# Eval("eventdate", "{0:dd MMM yyyy}")%>
                                                </td>
                                            </tr>--%>
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
                                    <%--Select Category--%></td>
                                <td width="20%">
                                    <asp:DropDownList ID="ddlcategory" CssClass="select2" runat="server" Visible="false">
                                    </asp:DropDownList>
                                </td>
                                <td width="66%">
                                    <asp:Button ID="btngo" runat="server" Text="Go" Width="27px" OnClick="btngo_Click"
                                        CssClass="go-btn" Visible="false" />
                                    <span id="message" runat="server" enableviewstate="false" class="txt02" Visible="false"></span>
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
