<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttendanceSummary.aspx.cs"
    Inherits="Leave_AttendanceSummary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance Summary</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="header">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                <td>
                                <table width="100%" border="0">
                                <tr>
                                    <td valign="top" width="80%" align="left">
                                        <h3>
                                            Attendance Summary</h3>
                                    </td>
                                    <td align="right">
                                    <%-- <asp:Button ID="btn_close" runat="server" CssClass="button" Text="Close" OnClick="btn_close_Click" />--%>
                                    </td>
                                    </tr>
                                    </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 5px" class="txt-red" align="left">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" cellspacing="0" cellpadding="0" border="0">
                                            <tr>
                                                <td height="10" valign="middle" class="txt1">
                                                </td>
                                            </tr>
                                            <tr id="update" runat="server" visible="false">
                                                <td class="head-2" valign="top" width="100%">
                                                <div id="dvResult" runat="server" style="overflow: auto; height: 490px; border: 0px #000 solid;">
                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                        CellPadding="0" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="false"
                                                        PageSize="15" EmptyDataText="No data exists !" OnPageIndexChanging="empgrid_PageIndexChanging" AllowSorting="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldateg" runat="server" Text='<%# Bind ("adate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false" HeaderText="Mode">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcardnog" runat="server" Text='<%# Bind ("Mode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="INTime(AM)/OutTime(PM)">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtintime" runat="server" Text='<%# Eval("Intime" ,"{0:HH:mm tt}") %>' Width="81px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="Door Description">
                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtouttime" runat="server" Text='<%# Eval("doordescription") %>' Width="78px"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <%-- <asp:TemplateField HeaderText="Action">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkviewDetail" runat="server"> View Details</asp:LinkButton>
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="middle" class="txt1" align="right">
                                       
                                </tr>
                                <tr>
                                    <tdheight="5" valign="top">
                                    </td>
                            </table>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
