<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="CanOffer.aspx.cs" Inherits="Recruitment_User_CanOffer" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function numberonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) //if not a number
                    return false //disable key press
            }
        }
    </script>
    <ajax:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDownload" />
        </Triggers>
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0"
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
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <fieldset id="Fieldset2" runat="server">
                    <legend><b>Candidate Information</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="frm-lft-clr123">
                                Candidate ID
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblCanID" runat="server" Text="CAN0005"></asp:Label>
                            </td>
                            <td width="20%" class="frm-lft-clr123">
                                Candidate Name
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblCanName" runat="server" Text="Rakesh Srivastava"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Include Header Footer
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:CheckBox ID="chkheader" runat="server" Checked="true" />
                            </td>
                            <td class="frm-lft-clr123">
                                Company
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlCompany" runat="server" OnDataBound="ddlCompany_DataBound"
                                    CssClass="select" Width="150px" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Letter Template
                            </td>
                            <td class="frm-rght-clr123" colspan="3">
                                <asp:DropDownList ID="ddlTemplate" runat="server" OnDataBound="ddlTemplate_DataBound"
                                    AutoPostBack="true" CssClass="select" Width="150px" OnSelectedIndexChanged="ddlTemplate_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div id="DivLetter" runat="server" style="display: block;">
                <fieldset id="Fieldset1" runat="server">
                    <legend><b>Offer Letter</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <FTB:FreeTextBox ID="txtTerms" runat="server" BackColor="Gray" BreakMode="LineBreak"
                                    EnableHtmlMode="false" GutterBackColor="Gray" ToolbarImagesLocation="InternalResource"
                                    ToolbarStyleConfiguration="Office2000" Width="100%" Height="250px">
                                </FTB:FreeTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="5px">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Generate" CssClass="button" OnClick="btnSave_Click" />
                                <asp:Button ID="btnEdit" runat="server" Text="Update" CssClass="button" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDownload" runat="server" Text="Download" CssClass="button" OnClick="btnDownload_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div runat="server" id="dv_text">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
