<%@ Page Language="C#" MasterPageFile="general.master" AutoEventWireup="true" CodeFile="newsviewdetail.aspx.cs"
    Inherits="newsviewdetail" Title="Acuminous Software" %>

<asp:Content ID="Content1" ContentPlaceHolderID="generalmaster" runat="Server">
    <style type="text/css" media="all">
        @import "../css/blue.css";
        @import "../css/home.css";
    </style>
    <div style="height: 500px;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" class="blue-brdr-1">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" class="dot-line">
                    News Room
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;&nbsp;<img src="../images/date-icon.gif" width="10" height="10" alt="" />&nbsp;
                    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label><asp:Label ID="lblname"
                        runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="26" valign="middle" class="txt01">
                    &nbsp;&nbsp;<asp:Label ID="lblheading" runat="server" CssClass="txt3"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <p>
                        <asp:Label ID="lbldetails" runat="server" Text=""></asp:Label>
                    </p>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
