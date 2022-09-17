<%@ Page Language="C#" MasterPageFile="general.master" AutoEventWireup="true" CodeFile="achievementsviewdetail.aspx.cs"
    Inherits="achievementsviewdetail" Title="Achievements View Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="generalmaster" runat="Server">

<style type="text/css" media="all">
        @import "../css/blue.css";
        @import "../css/home.css";
        </style>
    <div style="height: 500px;">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" class="blue-brdr-1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top" class="dot-line">
                    Press Release</td>
            </tr>
            <tr>
                <td valign="top">
                &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                 &nbsp;&nbsp;<img src="../images/date-icon.gif" width="10" height="10" alt="" />&nbsp;
                   <asp:Label ID="lbldate" runat="server" Text=""></asp:Label><asp:Label
                        ID="lblname" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td valign="middle" class="txt01" height="26">
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
                    <table border="3" style="width:90%;border-color:Black;border-width:1" align="center">
                    <tr>
                    <td style="padding:5px 5px 5px 5px">
                    <p>
                     &nbsp;&nbsp;<asp:Label ID="lbl_richData" runat="server" Text=""></asp:Label>
                    </p>
                    </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td height="10"></td>
            </tr>
            <%--<tr>
                <td valign="top">
                    &nbsp;</td>
            </tr>--%>
           <%-- <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="11%" class="txt01">
                            </td>
                            <td width="20%">
                                &nbsp;</td>
                            <td width="34%">
                            </td>
                            <td width="35%">
                                <table width="50" border="0" align="right" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="5" align="left" valign="top">
                                            <img src="../images/button-right.jpg" width="5" height="18" /></td>
                                        <td width="90" align="center" valign="middle" class="button-bg">
                                            <a href="javascript:history.go(-1)" class="back">Back</a></td>
                                        <td width="5" align="right">
                                            <img src="../images/button-right1.jpg" width="5" height="18" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
        </table>
    </div>
</asp:Content>
