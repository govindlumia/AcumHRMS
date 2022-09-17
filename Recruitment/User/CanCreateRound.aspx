<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="CanCreateRound.aspx.cs" Inherits="Recruitment_User_ViewCanAdvanceDetail" %>

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

            newwin = window.open(url, 'Vaccancy History', params);
            if (window.focus) { newwin.focus() }
            return false;
        }
    </script>
    <ajaxtoolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                    <legend><b>Select For Round</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" class="frm-lft-clr123">
                                Vacancy
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlVacancy" AutoPostBack="true" runat="server" CssClass="Select"
                                    OnDataBound="ddlVacancy_DataBound" OnSelectedIndexChanged="ddlVacancy_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlVacancy"
                                    Display="None" ErrorMessage="Select Vacancy" ToolTip="Select Vacancy" ValidationGroup="v"
                                    Width="6px" SetFocusOnError="True" InitialValue="0">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td width="10%" class="frm-lft-clr123">
                                Candidate
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlCandidate" runat="server" CssClass="Select" OnDataBound="ddlCandidate_DataBound">
                                </asp:DropDownList>
                            </td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCandidate"
                                Display="None" ErrorMessage="Select Candidate" ToolTip="Select Candidate" ValidationGroup="v"
                                Width="6px" SetFocusOnError="True" InitialValue="0">
                            </asp:RequiredFieldValidator>
                            <td width="20%" class="frm-rght-clr123">
                                <asp:Button ID="btnSelect" runat="server" ValidationGroup="v" Text="Select" CssClass="button"
                                    OnClick="btnSelect_Click" />
                            </td>
                        </tr>
                        <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
                            runat="server" ValidationGroup="v"></asp:ValidationSummary>
                    </table>
                </fieldset>
            </div>
            <div id="DivCanInfo" runat="server">
                <fieldset id="Fieldset0" runat="server">
                    <legend><b>Candidate Information</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" class="frm-lft-clr123">
                                Vacancy ID
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblvacID" runat="server"></asp:Label>
                            </td>
                            <td width="20%" class="frm-lft-clr123">
                                Vacancy Name
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:Label ID="lblvacName" runat="server"></asp:Label>
                            </td>
                        </tr>
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
                                Created Date
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Label ID="lblCCreatedDate" runat="server"></asp:Label>
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
                <fieldset id="Fieldset1" runat="server">
                    <legend><b>Add Rounds</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" class="frm-lft-clr123">
                                Round
                            </td>
                            <td width="30%" class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlRound" runat="server" CssClass="Select" OnDataBound="ddlRound_DataBound"
                                    OnSelectedIndexChanged="ddlRound_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlRound"
                                    Display="None" ErrorMessage="Select Round" ToolTip="Select Round" ValidationGroup="r"
                                    Width="6px" SetFocusOnError="True" InitialValue="0">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td width="20%" class="frm-lft-clr123">
                                Scheduled Date
                            </td>
                            <td class="frm-rght-clr123" colspan="2">
                                <asp:TextBox ID="txtSchDate" Width="75px" runat="server" CssClass="blue1"></asp:TextBox>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                                    ToolTip="click to open calender" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtSchDate"
                                    Display="None" ErrorMessage="Enter Schedule Date" SetFocusOnError="True" ToolTip="Enter Schedule Date"
                                    ValidationGroup="r" Width="6px">
                                </asp:RequiredFieldValidator>
                                <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                    Format="dd-MMM-yyyy" TargetControlID="txtSchDate">
                                </ajaxtoolkit:CalendarExtender>
                                <asp:DropDownList ID="ddlHour" Width="50px" CssClass="select" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlMinute" Width="50px" CssClass="select" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlTime" Width="50px" CssClass="select" runat="server">
                                    <asp:ListItem Value="1" Text="AM" />
                                    <asp:ListItem Value="2" Text="PM" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                Employee
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="Select" OnDataBound="ddlEmployee_DataBound">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlEmployee"
                                    Display="None" ErrorMessage="Select Employee" ToolTip="Select Employee" ValidationGroup="r"
                                    Width="6px" SetFocusOnError="True" InitialValue="0">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td class="frm-lft-clr123">
                                Feedback (Mandatory)
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:CheckBox ID="ChkFeedback" runat="server" Checked="true" />
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:Button ID="btnAdd" runat="server" ValidationGroup="r" Text="Add" CssClass="button"
                                    OnClick="btnAdd_Click" />
                                <asp:Button ID="btnClearR" runat="server" Text="Clear" CssClass="button" OnClick="btnClearR_Click" />
                            </td>
                        </tr>
                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="True" ShowSummary="False"
                            runat="server" ValidationGroup="r"></asp:ValidationSummary>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="10px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GvPanel" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                    DataKeyNames="ID" EmptyDataText="No Record(s) Found" OnRowCommand="GvPanel_RowCommand"
                                    OnRowDataBound="GvPanel_DataBound" OnRowDeleting="GvPanel_RowDeleting" Width="100%">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo" Visible="false" ItemStyle-Width="10px">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="5%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RoundNo" ItemStyle-Width="10px">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="5%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoundCount" runat="server" Text='<%# bind("RoundCount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Round" ItemStyle-Width="10px">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="35%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRoundID" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("RoundID") %>'></asp:Label>
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
                                                Width="45%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSchDate" runat="server" Visible="false" SkinID="gridLabel" Text='<%# bind("SchDate") %>'></asp:Label>
                                                <asp:Label ID="lblFeedbackN" runat="server" SkinID="gridLabel"></asp:Label>
                                                <asp:Label ID="lblFeedback" runat="server" Visible="false" SkinID="gridLabel" Text='<%# bind("Feedback") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" ItemStyle-Width="2px">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                Width="15%" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Height="10" SkinID="linkGrid"
                                                    Text="Delete" ToolTip="Delete" Width="10" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="btnFinal" CssClass="button" runat="server" Text="Submit" OnClick="btnFinal_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear All" CssClass="button" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            <div id="DivRounds" runat="server">
                <fieldset id="Fieldset4" runat="server">
                    <legend><b>Result</b></legend>
                    <div id="countrytabs1" class="shadetabs">
                        <li id="liRP" runat="server">
                            <asp:LinkButton ID="lnkRP" runat="server" OnClick="lnkRP_Click">Round Panel</asp:LinkButton></li>
                        <li id="liRPR" runat="server">
                            <asp:LinkButton ID="lnkRPR" runat="server" OnClick="lnkRPR_Click">Round Schedule</asp:LinkButton></li>
                    </div>
                    <div id="DivRP" runat="server" style="display: none;">
                        <fieldset id="Fieldset3" runat="server">
                            <legend><b>Final Panel</b></legend>
                            <table width="100%" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="2px">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnAddEmp" CssClass="button" runat="server" Text="Add" OnClick="btnAddEmp_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="2px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="GvPanelFinal" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                                            DataKeyNames="ID" EmptyDataText="No Record(s) Found" OnRowCommand="GvPanelFinal_RowCommand"
                                            OnRowDataBound="GvPanelFinal_DataBound" OnRowEditing="GvPanelFinal_RowEditing"
                                            OnRowCancelingEdit="GvPanelFinal_RowCancelingEdit" OnRowUpdating="GvPanelFinal_RowUpdating"
                                            Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="RoundNo" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="5%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoundCount" runat="server" Text='<%# bind("RoundCount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Round Code" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoundCode" runat="server" SkinID="gridLabel" Text='<%# bind("RoundCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Round" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoundID" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("RoundID") %>'></asp:Label>
                                                        <asp:Label ID="lblRoundName" runat="server" SkinID="gridLabel" Text='<%# bind("RoundName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee" ItemStyle-Width="100px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmpCode" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("EmpCode") %>'></asp:Label>
                                                        <asp:Label ID="lblEmpName" runat="server" SkinID="gridLabel" Text='<%# bind("EmpName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Feedback" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRStatus" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("RSTATUS") %>'></asp:Label>
                                                        <asp:Label ID="lblFeedbackN" runat="server" SkinID="gridLabel"></asp:Label>
                                                        <asp:Label ID="lblFeedback" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("Feedback") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlFeedback" runat="server">
                                                            <asp:ListItem Value="0">Mandatory </asp:ListItem>
                                                            <asp:ListItem Value="1">Optional </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="2px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Height="10" SkinID="linkGrid"
                                                            Text="Edit" ToolTip="Edit" Width="10" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkUpdate" Text="Update" runat="server" CommandName="Update" />
                                                        <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" CommandName="Cancel" />
                                                    </EditItemTemplate>
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
                                            EmptyDataText="No Record(s) Found" OnRowDataBound="GvRoundSch_DataBound" Width="100%"
                                            DataKeyNames="RoundCode" OnRowEditing="GvRoundSch_RowEditing" OnRowUpdating="GvRoundSch_RowUpdating"
                                            OnRowCancelingEdit="GvRoundSch_RowCancelingEdit" OnRowCommand="GvRoundSch_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Round No" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="5%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPriority" runat="server" SkinID="gridLabel" Text='<%# bind("Priority") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Round Code" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoundCode" runat="server" SkinID="gridLabel" Text='<%# bind("RoundCode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Round" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRoundID" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("RoundID") %>'></asp:Label>
                                                        <asp:Label ID="lblRoundName" runat="server" SkinID="gridLabel" Text='<%# bind("RoundName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Schedule Date And Time" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="30%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSchDate" Visible="false" Width="75px" runat="server" Text='<%# bind("SCHDATE") %>'></asp:Label>
                                                        <asp:Label ID="lblSchDateDisplay" Width="75px" runat="server" Text='<%# bind("SCHDATE") %>'></asp:Label>
                                                        <asp:Label ID="lblTimeDisplay" Width="75px" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtSchDate" Width="75px" runat="server" CssClass="blue1"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                                                            ToolTip="click to open calender" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtSchDate"
                                                            Display="None" ErrorMessage="Enter Schedule Date" SetFocusOnError="True" ToolTip="Enter Schedule Date"
                                                            ValidationGroup="e" Width="6px">
                                                        </asp:RequiredFieldValidator>
                                                        <ajaxtoolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                            Format="dd-MMM-yyyy" TargetControlID="txtSchDate">
                                                        </ajaxtoolkit:CalendarExtender>
                                                        <asp:DropDownList ID="ddlHour" Width="50px" CssClass="select" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlMinute" Width="50px" CssClass="select" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlTime" Width="50px" CssClass="select" runat="server">
                                                            <asp:ListItem Value="1" Text="AM" />
                                                            <asp:ListItem Value="2" Text="PM" />
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Round Status" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblRStatus" runat="server" SkinID="gridLabel" Text='<%# bind("RSTATUS") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Current Round" ItemStyle-Width="10px" Visible="false">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="10%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCURROUND" runat="server" SkinID="gridLabel" Text='<%# bind("CURROUND") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="10px">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="40%" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Height="10" SkinID="linkGrid"
                                                            Text="Edit" ToolTip="Edit" />
                                                        &nbsp;
                                                        <asp:LinkButton ID="lnkMTN" runat="server" CommandName="MTN" Height="10" SkinID="linkGrid"
                                                            Text="Move To Next" ToolTip="Move To Next" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkUpdate" Text="Update" ValidationGroup="e" runat="server" CommandName="Update" />
                                                        <asp:LinkButton ID="lnkCancel" Text="Cancel" runat="server" CommandName="Cancel" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:ValidationSummary ID="ValidationSummary3" ShowMessageBox="True" ShowSummary="False"
                                            runat="server" ValidationGroup="e"></asp:ValidationSummary>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>
                    <div style="margin-top: 2px; text-align: right;">
                        <asp:Button ID="btnSubmit" CssClass="button" ValidationGroup="v" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" />
                        <asp:ValidationSummary ID="ValidationSummary2" ShowMessageBox="True" ShowSummary="False"
                            runat="server" ValidationGroup="v"></asp:ValidationSummary>
                    </div>
                </fieldset>
            </div>
            <div runat="server" id="DivAdd" style="left: 25%; float: none; display: none; top: 50%;
                position: fixed;">
                <table width="98%" border="2px" border="0" cellspacing="0" cellpadding="0" align="center"
                    style="border-color: #ccd0d2;">
                    <tr>
                        <td height="2px" colspan="7" class="frm-lft-clr">
                            <div style="text-align: right;">
                                <asp:ImageButton ID="imgButAdd" runat="server" Height="15px" Width="50px" ImageUrl="~/images/close2.gif"
                                    OnClick="imgButAdd_Click" />
                            </div>
                            <div style="text-align: left;">
                                Add Employee in Rounds</div>
                        </td>
                    </tr>
                    <tr>
                        <td height="2px" colspan="7" class="frm-lft-clr">
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr">
                            Round
                        </td>
                        <td class="frm-rght-clr">
                            <asp:DropDownList ID="ddlRoundsAdd" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td class="frm-lft-clr">
                            Employee
                        </td>
                        <td class="frm-rght-clr">
                            <asp:DropDownList ID="ddlEmployeeAdd" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="frm-lft-clr">
                            Feedback
                        </td>
                        <td class="frm-rght-clr">
                            <asp:CheckBox ID="ChkFeedbackAdd" runat="server" Checked="true" />
                        </td>
                        <td class="frm-rght-clr">
                            <asp:Button ID="btnAddEmpSubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnAddEmpSubmit_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
