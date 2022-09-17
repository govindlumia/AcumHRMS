<%@ Page Title="CEO Message" Language="C#" MasterPageFile="~/Admin/Intranet/IntranetMasterWithoutLink.master"
    AutoEventWireup="true" CodeFile="ceomessage.aspx.cs" Inherits="ceomessage" ValidateRequest="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FreeTextBox"  Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../css/blue.css";
        @import "../css/home.css";
    </style>
    <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1"
        ScriptMode="Release" LoadScriptsBeforeUI="true" EnablePageMethods="true" />
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
          <%--  <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01" height="23">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                         <b>   Management Message </b>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblceotitle" runat="server" CssClass="txt01"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                             <FTB:FreeTextBox ID="txtEmailNotificationP" runat="server" BackColor="Gray" BreakMode="LineBreak"
                        EnableHtmlMode="False" GutterBackColor="Gray" ToolbarImagesLocation="InternalResource" Width="100%"
                        ToolbarStyleConfiguration="Office2000"  Height="400px">
                    </FTB:FreeTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button" 
                                onclick="btnEdit_Click" />
                        </td>
                    </tr>

                </table>
            </div>
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
