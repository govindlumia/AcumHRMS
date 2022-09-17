<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeFile="vision-mission.aspx.cs"
    Inherits="vision_mission" Title="Acuminous Software. - Vision & Mission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function WatermarkFocus(txtElem, strWatermark) {
            if (txtElem.value == strWatermark)
                txtElem.value = '';
        }
        function WatermarkBlur(txtElem, strWatermark) {
            if (txtElem.value == '')
                txtElem.value = strWatermark;
        }
    </script>
    <div id="divResult" style="display: block;" runat="server">
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
                    Company Vision and Mission
                </td>
            </tr>
            <tr>
                <td valign="bottom" style="height: 26px">
                    &nbsp;&nbsp;<a href="vision-mission.aspx?type=1&d=0" class="link-red1">Company Vision</a>
                    &nbsp;l&nbsp; <a href="vision-mission.aspx?type=2&d=0" class="link-red1">Company Mission</a>
                    &nbsp;&nbsp;<asp:TextBox ID="txtsearch" CssClass="input1" Text="" runat="server"
                        MaxLength="150" Width="241px"></asp:TextBox>
                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="go-btn" OnClick="btnsearch_Click" />
                </td>
            </tr>
            <tr>
                <td valign="middle">
                    &nbsp;
                    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <asp:GridView ID="gridvision" runat="server" AutoGenerateColumns="False" CellPadding="2"
                        CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="False" Width="100%"
                        EmptyDataText="No vision has been posted" ToolTip="Vision posted" AllowPaging="True"
                        OnPageIndexChanging="gridvision_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2" title="Posted By : <%#DataBinder.Eval(Container.DataItem,"uploadedby")%>">
                                        <tr>
                                            <td>
                                            </td>
                                            <td width="98%" valign="top">
                                                <a href="vision-mission.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>&d=1"
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
                                            <td width="2%" align="center" valign="middle">
                                                <img src="images/arrows1.gif" width="3" height="5" />
                                            </td>
                                            <td valign="top">
                                                Posted On :
                                                <%#DataBinder.Eval(Container.DataItem,"uploadeddate")%>
                                                , By :
                                                <%#DataBinder.Eval(Container.DataItem,"uploadedby")%>
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

    <div id="divDetail" style="display: none;" runat="server">
       <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="blue-brdr-1">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" class="dot-line" style="height: 22px">
                        Company Vision-Mission</td>
                </tr>
                <tr>
                    <td valign="top" height="5">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label><asp:Label
                            ID="lblname" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td height="26" valign="middle" class="txt01">
                        &nbsp;&nbsp;<asp:Label ID="lblheading" runat="server" CssClass="txt3"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <p>
                            <asp:Label ID="lbldetails" runat="server" Text=""></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                            <tr>
                                <td width="11%" class="txt01">
                                </td>
                                <td width="20%">
                                    &nbsp;</td>
                                <td width="34%">
                                </td>
                                <td width="35%" >
                                    <table width="50" border="0" align="right" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="5" align="left" valign="top">
                                                <img src="images/button-right.jpg" width="5" height="18" /></td>
                                            <td width="90" align="center" valign="middle" class="button-bg">
                                                <a href="javascript:history.go(-1)" class="back">Back</a></td>
                                            <td width="5" align="right">
                                                <img src="images/button-right1.jpg" width="5" height="18" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
    </div>
</asp:Content>
