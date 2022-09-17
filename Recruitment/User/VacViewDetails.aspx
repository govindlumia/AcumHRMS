<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="VacViewDetails.aspx.cs" Inherits="Recruitment_User_VacViewDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

            newwin = window.open(url, 'Vaccancy History', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
    </script>
    <ajaxtoolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="lnkDownload" />
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <div>
                            <fieldset id="Vac_Info" runat="server">
                                <legend><b>Vacancy Information</b></legend>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="20%" class="frm-lft-clr123">
                                            Vacancy ID
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
                                        <td width="20%" class="frm-lft-clr123">
                                            Vacancy Name
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblVacName" runat="server"></asp:Label>
                                        </td>
                                        <td width="20%" class="frm-lft-clr123">
                                            Job Location
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="2px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="frm-lft-clr123">
                                            Open Vacancy
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblNoofVac" runat="server"></asp:Label>
                                        </td>
                                        <td width="20%" class="frm-lft-clr123">
                                            Closed Vacancy
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblClosed" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="2px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="frm-lft-clr123">
                                            Vacancy Status
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblVacStatus" runat="server"></asp:Label>
                                        </td>
                                        <td width="20%" class="frm-lft-clr123">
                                            Created Date
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblCreateDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="2px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="frm-lft-clr123">
                                            Created By
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblCreateBy" runat="server"></asp:Label>&nbsp&nbsp(<asp:Label ID="lbl_creName"
                                                runat="server"></asp:Label>)
                                        </td>
                                        <td width="20%" class="frm-lft-clr123">
                                            Job Description
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:LinkButton ID="lnkDownload" runat="server" OnClick="lnkDownload_Click" Text='Download'></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <fieldset id="Vac_ApprovalInfo" runat="server">
                                <legend><b>Approval Information</b></legend>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GvAppmaster" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                Width="100%" OnRowDataBound="GvAppmaster_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="APPROVER" Visible="false">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="15%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployee" runat="server" SkinID="gridLabel" Text='<%# bind("APPROVER") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="35%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRemarks" runat="server" SkinID="gridLabel" Text='<%# bind("APPROVERNAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="20%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComment" runat="server" SkinID="gridLabel" Text='<%# bind("Dsca") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Level" Visible="false">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="15%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAppLevel" runat="server" SkinID="gridLabel" Text='<%# bind("AppLevel") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Current Level" Visible="false">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="15%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurrLevel" runat="server" SkinID="gridLabel" Text='<%# bind("CurrLevel") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="20%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" SkinID="gridLabel" Text='<%# bind("STATUS") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action Date">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="10%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDate" runat="server" SkinID="gridLabel" Text='<%# bind("APPROVEDDATE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="2px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="20%" class="frm-lft-clr123">
                                            Approval Status
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:Label ID="lblAppStatus" runat="server"></asp:Label>
                                        </td>
                                        <td width="20%" class="frm-lft-clr123">
                                            Approval Status Log
                                        </td>
                                        <td width="30%" class="frm-rght-clr123">
                                            <asp:HyperLink ID="HyAppHistory" runat="server" ForeColor="Black" Text="(Click To Open)"></asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                        <div id="DivApproverAction" runat="server">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="2px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Remarks:
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Style="resize: none"
                                            Width="370px" Height="70px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="2px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button" OnClick="btnEdit_Click" />
                                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="button" OnClick="btnApprove_Click"
                                            ValidationGroup="v" />
                                        <asp:Button ID="btnreject" runat="server" Text="Reject" CssClass="button" OnClick="btnreject_Click" />
                                        <asp:Button ID="btnClarification" runat="server" Text="Clarification" CssClass="button"
                                            OnClick="btnClarification_Click" ValidationGroup="v" />
                                        <asp:Button ID="btnPublish" runat="server" Text="Publish" Width="100px" CssClass="button"
                                            OnClick="btnPublish_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="DivCandidate" runat="server">
                            <div id="countrytabs1" class="shadetabs">
                                <li id="liHR" runat="server">
                                    <asp:LinkButton ID="lnkHR" runat="server" OnClick="lnkHR_Click">Assigned HR</asp:LinkButton></li>
                                <li id="liUR" runat="server">
                                    <asp:LinkButton ID="lnkUR" runat="server" OnClick="lnkUR_Click">Uploaded Resume</asp:LinkButton></li>
                                <li id="liSR" runat="server">
                                    <asp:LinkButton ID="lnkSR" runat="server" OnClick="lnkSR_Click">In Process Resume</asp:LinkButton></li>
                                <li id="li1" runat="server">
                                    <asp:LinkButton ID="lnkRR" runat="server" OnClick="lnkRR_Click">Rejected Resume</asp:LinkButton></li>
                            </div>
                            <div id="DivHR" runat="server" style="display: none;">
                                <fieldset id="Fieldset1" runat="server">
                                    <legend><b>Assigned HR</b></legend>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GvHRExecutive" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                    Width="100%" PageSize="25" OnRowDataBound="GvHRExecutive_RowDataBound" EmptyDataText="No Record(s) found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Employee Name (HR)">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="15%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmpName" runat="server" SkinID="gridLabel" Text='<%# bind("EmpName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Assign Date">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDate" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div id="DivUR" runat="server" style="display: none;">
                                <fieldset id="Vac_UploadedInfo" runat="server">
                                    <legend><b>Uploaded Resume</b></legend>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GvUploadedResume" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                    Width="100%" OnRowDataBound="GvUploadedResume_RowDataBound" EmptyDataText="No Record(s) found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Can Code">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="4%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbCAN_ID" runat="server" SkinID="gridLabel" Text='<%# bind("Can_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="12%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" SkinID="gridLabel" Text='<%# bind("CandidateName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email Id">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" runat="server" SkinID="gridLabel" Text='<%# bind("Email_Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="5%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblContact" runat="server" SkinID="gridLabel" Text='<%# bind("Contact_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Applied Date">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="5%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppDate" runat="server" SkinID="gridLabel" Text='<%# bind("ApplicationDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload By">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="15%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCreatedBy" runat="server" SkinID="gridLabel" Text='<%# bind("CREATEDBYNAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" SkinID="gridLabel" Text='<%# bind("DSCA") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Resume">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="4%" />
                                                            <ItemTemplate>
                                                                <a href="../UploadResume/<%#Eval("FileName") %>" title="Download" target="_blank"
                                                                    onclick="">
                                                                    <asp:Label ID="tt" runat="server" Text='Download'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="2%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkView" runat="server" SkinID="linkGrid" Text="Details" ToolTip="Details"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div id="DivSR" runat="server" style="display: none;">
                                <fieldset id="Vac_SelectedInfo" runat="server">
                                    <legend><b>In Process Resume</b></legend>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GvShortlistResume" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                    Width="100%" OnRowDataBound="GvShortlistResume_RowDataBound" EmptyDataText="No Record(s) found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Can Code">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="4%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbCAN_ID" runat="server" SkinID="gridLabel" Text='<%# bind("Can_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Name">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="12%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTitle" runat="server" SkinID="gridLabel" Text='<%# bind("CandidateName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email Id">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" SkinID="gridLabel" Text='<%# bind("Email_Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="5%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" runat="server" SkinID="gridLabel" Text='<%# bind("Contact_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Applied Date">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="5%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppDate" runat="server" SkinID="gridLabel" Text='<%# bind("ApplicationDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload By">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="15%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCreatedDate" runat="server" SkinID="gridLabel" Text='<%# bind("CREATEDBYNAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server" SkinID="gridLabel" Text='<%# bind("DSCA") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DownLoad">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="4%" />
                                                            <ItemTemplate>
                                                                <a href="../UploadResume/<%#Eval("FileName") %>" title="Download" target="_blank"
                                                                    onclick="">
                                                                    <asp:Label ID="tt" runat="server" Text='Download'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="2%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkView" runat="server" SkinID="linkGrid" Text="Details" ToolTip="Details"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                            <div id="DivRR" runat="server" style="display: none;">
                                <fieldset id="Fieldset2" runat="server">
                                    <legend><b>Rejected Resume</b></legend>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GvRejectedResume" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                                    Width="100%" OnRowDataBound="GvRejectedResume_RowDataBound" EmptyDataText="No Record(s) found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Can Code">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="4%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbCAN_ID" runat="server" SkinID="gridLabel" Text='<%# bind("Can_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Name">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="12%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTitle" runat="server" SkinID="gridLabel" Text='<%# bind("CandidateName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email Id">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" SkinID="gridLabel" Text='<%# bind("Email_Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="8%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLocation" runat="server" SkinID="gridLabel" Text='<%# bind("Contact_No") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Applied Date">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="5%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAppDate" runat="server" SkinID="gridLabel" Text='<%# bind("ApplicationDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload By">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="10%" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCreatedDate" runat="server" SkinID="gridLabel" Text='<%# bind("CREATEDBYNAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="DownLoad">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="4%" />
                                                            <ItemTemplate>
                                                                <a href="../UploadResume/<%#Eval("FileName") %>" title="Download" target="_blank"
                                                                    onclick="">
                                                                    <asp:Label ID="tt" runat="server" Text='Download'></asp:Label>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                Width="2%" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkView" runat="server" SkinID="linkGrid" Text="Details" ToolTip="Details"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <div id="DivEmployee" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnCanCreate" runat="server" Text="Upload" CssClass="button" OnClick="btnCanCreate_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
