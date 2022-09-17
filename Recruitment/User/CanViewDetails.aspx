<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="CanViewDetails.aspx.cs" Inherits="Recruitment_User_ViewCanAdvanceDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../Css/tab/tabcontent.css" rel="stylesheet" type="text/css" />
    <script src="../Css/tab/tabcontent.js" type="text/javascript"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <script language="javascript" type="text/javascript">
        function popup(url) {
            var width = 1000;
            var height = 500;
            var left = (screen.width - width) / 2;
            var top = (screen.height - height) / 2;
            var params = 'width=' + width + ', height=' + height;
            params += ', top=' + top + ', left=' + left;
            params += ', directories=no';
            params += ', location=no';
            params += ', menubar=no';
            params += ', resizable=no';
            params += ', scrollbars=no';
            params += ', status=no';
            params += ', toolbar=no';
            
            newwin = window.open(url, 'Evaluation Details', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
    </script>
    <ajaxtoolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkDownloadVac" />
            <asp:PostBackTrigger ControlID="lnkDownloadCan" />
            <asp:PostBackTrigger ControlID="lnkDownloadOLetter" />
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
                    <legend><b>Vacancy Information</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="20%" class="frm-lft-clr123">
                                Vac ID
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblVacId" runat="server"></asp:Label>
                            </td>
                            <td width="20%" class="frm-lft-clr123">
                                Job Title
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Vacancy Name
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblVacName" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                Job Location
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Open Vacancy
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblNoofVac" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                Closed Vacancy
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblClosed" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Vacancy Status
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblVacStatus" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                Created Date
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Created By
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblCreateBy" runat="server"></asp:Label>&nbsp&nbsp(<asp:Label ID="lbl_creName"
                                    runat="server"></asp:Label>)
                            </td>
                            <td class="frm-lft-clr123">
                                Job Description
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:LinkButton ID="lnkDownloadVac" runat="server" OnClick="lnkDownload_Click" Text='Download'></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div>
                <fieldset id="Fieldset1" runat="server">
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
                                <asp:Label ID="lblCanId" runat="server"></asp:Label>
                            </td>
                            <td width="20%" class="frm-lft-clr123">
                                Candidate Name
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Email ID
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                Contact No.
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblContactno" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Application Date
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblapplicationdate" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                KeyWords
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblkeywords" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Created Date
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblCCreatedDate" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                Resume
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:LinkButton ID="lnkDownloadCan" runat="server" OnClick="lnkDownload_Click" Text='Download'></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Created By
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblCCreatedBy" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                Candidate Status Log
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:HyperLink ID="HyAppHistory" runat="server" ForeColor="Black" Text="(Click To Open)"></asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Status
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblCanStatus" runat="server"></asp:Label>
                            </td>
                            <td class="frm-lft-clr123">
                                <asp:Label ID="lblOletter" Text="Offer Letter" runat="server"></asp:Label>
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:LinkButton ID="lnkDownloadOLetter" runat="server" OnClick="lnkDownloadOLetter_Click"
                                    Text='Download'></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Remarks
                            </td>
                            <td class="frm-rght-clr123" colspan="3">
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div id="DivActions" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="frm-lft-clr123">
                            Comments
                        </td>
                        <td class="frm-rght-clr123" colspan="3">
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Style="resize: none"
                                Width="370px" Height="70px"></asp:TextBox><span><i>Max 200 Chars</i></span>
                        </td>
                    </tr>
                    <tr>
                        <td height="2px">
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123">
                        </td>
                        <td class="frm-rght-clr123" colspan="3">
                            <asp:Button ID="btnShortList" runat="server" Text="Shortlist" CssClass="button" OnClick="btnShortList_Click" />
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="button" OnClick="btnReject_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="DivRoundInfo" runat="server">
                <fieldset id="FldRounds" runat="server">
                    <legend><b>Rounds Information</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="countrytabs1" class="shadetabs">
                                    <li id="liRP" runat="server">
                                        <asp:LinkButton ID="lnkRP" runat="server" OnClick="lnkRP_Click">Round Panel</asp:LinkButton></li>
                                    <li id="liRPR" runat="server">
                                        <asp:LinkButton ID="lnkRPR" runat="server" OnClick="lnkRPR_Click">Round Schedule</asp:LinkButton></li>
                                </div>
                                <div id="DivRP" runat="server" style="display: none;">
                                    <fieldset id="Fieldset3" runat="server">
                                        <legend><b>Employees Panel</b></legend>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="2px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GvPanelFinal" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                        EmptyDataText="No Record(s) Found" Width="100%" OnRowDataBound="GvPanelFinal_DataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Round Code" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoundCode" runat="server" SkinID="gridLabel" Text='<%# bind("RoundCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Round Name" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="35%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoundName" runat="server" SkinID="gridLabel" Text='<%# bind("RoundName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Employee" ItemStyle-Width="100px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="35%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpCode" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("EmpCode") %>'></asp:Label>
                                                                    <asp:Label ID="lblEmpName" runat="server" SkinID="gridLabel" Text='<%# bind("EmpName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Feedback" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCurRound" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("CURROUND") %>'></asp:Label>
                                                                    <asp:Label ID="lblFeedback" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("Feedback") %>'></asp:Label>
                                                                    <asp:Label ID="lblIsFeedback" runat="server" SkinID="gridLabel" Text='<%# bind("IsFeedback") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Can Status" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEmpStatus" runat="server" SkinID="gridLabel" Text='<%# bind("EmpStatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Evaluation" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="lnk_EvalView" Text="View"></asp:LinkButton>
                                                                    <asp:LinkButton runat="server" ID="lnk_Eval" Text="Evaluate"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                                <div id="DivRPR" runat="server" style="display: none;">
                                    <fieldset id="Fieldset5" runat="server">
                                        <legend><b>Round Priority</b></legend>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="2px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="GvRoundSch" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                        EmptyDataText="No Record(s) Found" Width="100%" OnRowDataBound="GvRoundSch_DataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Round Code" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoundCode" runat="server" SkinID="gridLabel" Text='<%# bind("RoundCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Round Name" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="30%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoundName" runat="server" SkinID="gridLabel" Text='<%# bind("RoundName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Schedule Date And Time" ItemStyle-Width="10px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="20%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDate" runat="server" SkinID="gridLabel" Text='<%# bind("SCHDATE") %>'></asp:Label>
                                                                    <asp:Label ID="lblTime" runat="server" SkinID="gridLabel"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Round Status" ItemStyle-Width="100px">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRoundStatus" runat="server" SkinID="gridLabel" Text='<%# bind("ROUNDSTATUS") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Current Round" ItemStyle-Width="10px" Visible="false">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCurRound" runat="server" SkinID="gridLabel" Text='<%# bind("CURROUND") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </div>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div id="DivHRActions" runat="server" style="text-align: right; padding-top: 10px; padding-bottom:25px;">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button" OnClick="btnEdit_Click" />
                <asp:Button ID="btnRounds" runat="server" Text="Rounds" CssClass="button" OnClick="btnRounds_Click" />
                <asp:Button ID="btnEditRound" runat="server" Text="Edit Rounds" CssClass="button"
                    OnClick="btnEditRound_Click" />
                <asp:Button ID="btnOfferLtr" runat="server"  Text="Generate Offer Letter" Width="200px" CssClass="button2" OnClick="btnOfferLtr_Click" />
                <asp:Button ID="btnEditOfferLtr" runat="server" Text="Edit Offer" CssClass="button"
                    OnClick="btnEditOfferLtr_Click" />
                <asp:DropDownList ID="ddlAction" OnDataBound="ddlAction_DataBound" runat="server"
                    Width="150px" CssClass="select" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlAction"
                    Display="None" ErrorMessage="Select Action" ToolTip="Select EmploActionyee" ValidationGroup="s"
                    Width="6px" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" ValidationGroup="s"
                    OnClick="btnSubmit_Click" />
                <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
                    runat="server" ValidationGroup="s"></asp:ValidationSummary>
            </div>
            <div runat="server" id="dv_text">
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
