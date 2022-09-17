<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="Copy (2) of CanOffer.aspx.cs" Inherits="Recruitment_User_CanOffer" %>

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
            <asp:PostBackTrigger ControlID="btnsave" />
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
                            <td width="15%" class="frm-lft-clr123">
                                Candidate ID
                            </td>
                            <td width="35%" class="frm-rght-clr123">
                                <asp:Label ID="lblCanID" runat="server" Text="CAN0005"></asp:Label>
                            </td>
                            <td width="15%" class="frm-lft-clr123">
                                Candidate Name
                            </td>
                            <td width="35%" class="frm-rght-clr123">
                                <asp:Label ID="lblCanName" runat="server" Text="Rakesh Srivastava"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Postal Address
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="CanAddress" runat="server" Style="resize: none" TextMode="MultiLine"
                                    Width="320px" Height="40px"></asp:TextBox>
                            </td>
                            <td class="frm-lft-clr123">
                                Designation
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblDesignation" runat="server" Text="Software Developer"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Joining Date
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txtJoinDate" runat="server"></asp:TextBox>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                                    ToolTip="click to open calender" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtJoinDate"
                                    Display="Dynamic" ErrorMessage="Enter Date of Joining" SetFocusOnError="True"
                                    ToolTip="Enter Date of Joining" ValidationGroup="v" Width="6px">
                                </asp:RequiredFieldValidator>
                                <ajax:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                    Format="dd-MMM-yyyy" TargetControlID="txtJoinDate">
                                </ajax:CalendarExtender>
                            </td>
                            <td class="frm-lft-clr123">
                                CTC
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:TextBox ID="txtCTC" MaxLength="10" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Job Location
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddllocation" OnDataBound="ddllocation_DataBound" Width="150px"
                                    runat="server" CssClass="select">
                                </asp:DropDownList>
                            </td>
                            <td class="frm-lft-clr123">
                                Letter Template
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlTemplate" runat="server" CssClass="select" Width="150px">
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
                                    EnableHtmlMode="False" GutterBackColor="Gray" ToolbarImagesLocation="InternalResource"
                                    ToolbarStyleConfiguration="Office2000" Width="99%" Height="250px">
                                </FTB:FreeTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="5px">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" OnClick="btnGenerate_Click" />
                                <asp:Button ID="btnGenOffer" runat="server" Text="Generate" CssClass="button" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div runat="server" id="dv_text">
                    <asp:Label runat="server" ID="lbl_txt" Text="Amrit"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
