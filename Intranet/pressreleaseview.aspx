<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pressreleaseview.aspx.cs"
    Inherits="pressreleaseview" %>

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
                    <td valign="top" class="blue-brdr-1">
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
                        Company Press Release</td>
                </tr>
                <tr>
                    <td valign="bottom" style="height: 26px">
                        &nbsp;&nbsp;<asp:TextBox ID="txtsearch" CssClass="input1" Text="" runat="server"
                            MaxLength="150" Width="241px"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="go-btn" OnClick="btnsearch_Click" /></td>
                </tr>
                <tr>
                    <td valign="middle">
                        &nbsp;
                        <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="gridpressrelease" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                            EmptyDataText="No vision has been posted" ToolTip="Vision posted" AllowPaging="True"
                            OnPageIndexChanging="gridpressrelease_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"uploadedby")%>">
                                            <tr>
                                                <td width="2%" align="center" valign="middle">
                                                    <img src="images/arrows1.gif" width="3" height="5" /></td>
                                                <td valign="top">
                                                    Posted On :
                                                    <%#DataBinder.Eval(Container.DataItem,"uploadeddate")%>
                                                    , By :
                                                    <%#DataBinder.Eval(Container.DataItem,"uploadedby")%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td width="98%" valign="top">
                                                    <a href="pressreleasedetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                        class="link-red">
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
                        <span id="message" runat="server" enableviewstate="false" class="txt02"></span>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
