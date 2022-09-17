<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="TrainingUpdate.aspx.cs" Inherits="Appraisal_User_TrainingUpdate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
        </Triggers>
        <ContentTemplate>--%>
    <div id="HomePage" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td class="blue-brdr-1">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td class="txt01">
                                    <img alt="" src="../../images/header-icon.png" />
                                    Training Update
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnView" runat="server" Visible="false" Text="View" CssClass="button" OnClick="btnView_Click"></asp:Button>
                                    <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="button" OnClick="btnCreate_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td height="5" valign="top">
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trCreate" visible="false">
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td width="30%" class="frm-lft-clr123">Name of Training<span style="color: Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtTrainingName" runat="server" CssClass="blue1" MaxLength="256" Width="200px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTrainingName"
                                                                Display="None" SetFocusOnError="True" ToolTip="Enter Training Name" ValidationGroup="c"
                                                                ErrorMessage="Enter Training Name" Width="6px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="30%" class="frm-lft-clr123">Training Type
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdnType">
                                                                <asp:ListItem Selected="True">Internal</asp:ListItem>
                                                                <asp:ListItem>External</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr runat="server" visible="false">
                                                        <td class="frm-lft-clr123">Training Date<span style="color: Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtTrainingDate" runat="server" CssClass="blue1" MaxLength="20" Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">Training Venue<span style="color: Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtVenue" runat="server" CssClass="blue1" MaxLength="256" Width="200px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVenue"
                                                                Display="None" SetFocusOnError="True" ToolTip="Enter Training Venue" ValidationGroup="c"
                                                                ErrorMessage="Enter Training Venue" Width="6px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">Conducted By<span style="color: Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtConducted" runat="server" CssClass="blue1" MaxLength="256" Width="200px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConducted"
                                                                Display="None" SetFocusOnError="True" ToolTip="Enter Conducted By" ValidationGroup="c"
                                                                ErrorMessage="Enter Conducted By" Width="6px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">Training Duration<span style="color: Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">From 
                                                                    <asp:TextBox ID="txtFrom" runat="server" CssClass="blue1" MaxLength="20" Width="100px"></asp:TextBox>
                                                            &nbsp; &nbsp;<asp:Image ID="Image1" runat="server" ToolTip="click to open calender"
                                                                ImageUrl="~/images/clndr.gif"></asp:Image><Ajax:CalendarExtender ID="CalendarExtender1"
                                                                    runat="server" TargetControlID="txtFrom" PopupButtonID="Image1" Format="dd-MMM-yyyy">
                                                                </Ajax:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFrom"
                                                                Display="None" SetFocusOnError="True" ToolTip="Select From Date" ValidationGroup="c"
                                                                ErrorMessage="Select From Date" Width="6px"></asp:RequiredFieldValidator>

                                                            To   
                                                                    <asp:TextBox ID="txtTo" runat="server" CssClass="blue1" MaxLength="20" Width="100px"></asp:TextBox>
                                                            &nbsp; &nbsp;<asp:Image ID="Image2" runat="server" ToolTip="click to open calender"
                                                                ImageUrl="~/images/clndr.gif"></asp:Image><Ajax:CalendarExtender ID="CalendarExtender2"
                                                                    runat="server" TargetControlID="txtTo" PopupButtonID="Image2" Format="dd-MMM-yyyy">
                                                                </Ajax:CalendarExtender>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTo"
                                                                Display="None" SetFocusOnError="True" ToolTip="Select To Date" ValidationGroup="c"
                                                                ErrorMessage="Select To Date" Width="6px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">No of Hours
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtHours" onkeypress="return isNumber(event)" runat="server" CssClass="blue1" MaxLength="3" Width="100px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">Certification Received
                                                        </td>
                                                        <td class="frm-rght-clr123">

                                                            <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="chkCertification" AutoPostBack="True" OnSelectedIndexChanged="chkCertification_SelectedIndexChanged">
                                                                <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                                <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <div id="divValidDate" runat="server" visible="false">
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123">Certification Valid Date<span style="color: Red">*</span>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtValid" runat="server" CssClass="blue1" MaxLength="20" Width="100px"></asp:TextBox>
                                                                &nbsp; &nbsp;<asp:Image ID="Image3" runat="server" ToolTip="click to open calender"
                                                                    ImageUrl="~/images/clndr.gif"></asp:Image><Ajax:CalendarExtender ID="CalendarExtender3"
                                                                        runat="server" TargetControlID="txtValid" PopupButtonID="Image3" Format="dd-MMM-yyyy">
                                                                    </Ajax:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123">File Upload<span style="color: Red">*</span>
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:FileUpload runat="server" ID="flp" />&nbsp;
                                                                        <a runat="server" id="lnkFile" href="" class="link05">Attachment</a>&nbsp;       
                                                            </td>
                                                        </tr>
                                                    </div>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">Comments<span style="color: Red">*</span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtComments" TextMode="MultiLine" runat="server" Style="resize: none;" CssClass="blue1" MaxLength="1000" Width="425px" Height="75px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtComments"
                                                                Display="None" SetFocusOnError="True" ToolTip="Enter Comments" ValidationGroup="c"
                                                                ErrorMessage="Enter Comments" Width="6px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="5"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">&nbsp;
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <div id="divcreate" runat="server">
                                                                            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" ValidationGroup="c" OnClick="btnAdd_Click"></asp:Button>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" OnClick="btnReset_Click"></asp:Button>
                                                                    </td>
                                                                </tr>
                                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="c"
                                                                    ShowMessageBox="true" ShowSummary="false" />
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5"></td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>

                <tr runat="server" id="trView" visible="true">
                    <td>
                        <table width="100%">
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="20%">Training Name
                                            </td>
                                            <td class="frm-lft-clr123" width="20%">From Date
                                            </td>
                                            <td class="frm-lft-clr123" colspan="2" width="20%">To Date
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123" width="20%">
                                                <asp:TextBox runat="server" ID="txtSName" Text=""></asp:TextBox>
                                            </td>

                                            <td class="frm-rght-clr123" width="20%">
                                                <asp:TextBox ID="txtSDate" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                                <asp:Image
                                                    ID="Image8" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <Ajax:CalendarExtender ID="CalendarExtender8" runat="server"
                                                    PopupButtonID="Image8" TargetControlID="txtSDate" Enabled="True" Format="dd-MMM-yyyy">
                                                </Ajax:CalendarExtender>
                                            </td>

                                            <td class="frm-rght-clr123" width="20%">
                                                <asp:TextBox ID="txtEDate" runat="server" CssClass="input" Width="90px"></asp:TextBox>
                                                <asp:Image
                                                    ID="Image4" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <Ajax:CalendarExtender ID="CalendarExtender4" runat="server"
                                                    PopupButtonID="Image4" TargetControlID="txtEDate" Enabled="True" Format="dd-MMM-yyyy">
                                                </Ajax:CalendarExtender>
                                            </td>

                                            <td class="frm-rght-clr123" width="20%">
                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="head-2">
                                    <div id="dvResult" style="overflow: auto; border: 0px #000 solid;"
                                        runat="server">
                                        <asp:GridView ID="grdResult" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                            EmptyDataText="Np record(s) found.."
                                            BorderColor="#C9DFFB" OnRowCommand="grdResult_RowCommand" OnRowDataBound="grdResult_RowDataBound" OnPageIndexChanging="grdResult_PageIndexChanging" PageSize="10">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Training Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTrainingName" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("TrainingName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Venue">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVenue" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("Venue") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Conducted By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConductedBy" Style="word-wrap: break-word;" runat="server" Text='<%# Bind("ConductedBy") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="12%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Duration">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFromDate" runat="server" Text='<%# Bind("FromDate") %>'></asp:Label>
                                                        -
                                                    <asp:Label ID="lblToDate" runat="server" Text='<%# Bind("ToDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="28%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Status" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:HiddenField runat="server" ID="hdnValue" Value='<%# Bind("Id") %>' />
                                                        <a runat="server" id="lnkView" href="" class="link05">V</a>&nbsp;                                                      
                                                                <asp:LinkButton runat="server" CommandName="E" CommandArgument='<%# Bind("Id") %>' ToolTip="Edit" CssClass="link05" ID="lnkEdit">E</asp:LinkButton>&nbsp;
                                                                <asp:LinkButton runat="server" CommandName="D" CommandArgument='<%# Bind("Id") %>' ToolTip="Delete" CssClass="link05" ID="lnlDelete">D</asp:LinkButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <RowStyle></RowStyle>
                                            <PagerStyle Width="500px" HorizontalAlign="Left"
                                                VerticalAlign="Top" />
                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                                NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>

                </tr>
            </tbody>
        </table>
    </div>
    <%--<div>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img alt="" src="../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>--%>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

