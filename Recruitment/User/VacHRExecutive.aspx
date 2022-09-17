<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="VacHRExecutive.aspx.cs" Inherits="Recruitment_User_VacHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_message" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
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
            <div id="DivCreate" runat="server">
                <fieldset id="fieldset1" runat="server">
                    <legend><b>Map Open Vaccancy HC Executive</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="frm-lft-clr123">
                                Open Vacancy
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlOpenVac" CssClass="select" Width="200px" OnDataBound="ddlOpenVac_DataBound"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlOpenVac"
                                    Display="None" ErrorMessage="Select Vacancy" ValidationGroup="v"
                                    Width="6px" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-lft-clr123">
                                HC Employee
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlHREmp" CssClass="select" Width="200px" OnDataBound="ddlHREmp_DataBound"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlHREmp"
                                    Display="None" ErrorMessage="Select Employee" ValidationGroup="v"
                                    Width="6px" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                            </td>
                        </tr>
                        <tr>
                            <td class="frm-rght-clr123" colspan="3" align="center">
                                <asp:Button ID="btnAdd" runat="server" CssClass="button" ValidationGroup="v" Text="Add"
                                    OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td height="5px">
                            </td>
                        </tr>
                        <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="false"
                            runat="server" ValidationGroup="v"></asp:ValidationSummary>
                    </table>
                </fieldset>
            </div>
            <div>
                <fieldset id="fieldset" runat="server">
                    <legend><b>Result</b></legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="frm-lft-clr123">
                                Vacancies
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlOpenVacSel" CssClass="select" Width="200px" OnDataBound="ddlOpenVacSel_DataBound"
                                    runat="server">
                                </asp:DropDownList>
                                <asp:CheckBox ID="chkClosed" runat="server" TextAlign="Right" Text="Closed" OnCheckedChanged="chkClosed_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                            <td class="frm-lft-clr123">
                                HC Employee
                            </td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="ddlHREmpSel" CssClass="select" Width="150px" OnDataBound="ddlHREmpSel_DataBound"
                                    runat="server">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click"
                                    Text="Search" />
                                <asp:Button ID="btnClear" runat="server" CssClass="button" OnClick="btnClear_Click"
                                    Text="Clear" />
                            </td>
                        </tr>
                        <tr>
                            <td height="2px">
                                <tr>
                                    <td colspan="4">
                                        <div id="dvResult" runat="server" style="overflow: scroll; height: 500px;">
                                            <asp:GridView ID="GvHRExecutive" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" EmptyDataText="No Record(s) found"
                                                Font-Names="Arial" Font-Size="11px" OnRowDataBound="GvHRExecutive_RowDataBound"
                                                Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="vacancy">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="40%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblID" Visible="false" runat="server" SkinID="gridLabel" Text='<%# bind("ID") %>'></asp:Label>
                                                            <asp:Label ID="lblvacancy" runat="server" SkinID="gridLabel" Text='<%# bind("Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="40%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEmployee" runat="server" SkinID="gridLabel" Text='<%# bind("EmpName") %>'></asp:Label>
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
                                                    <asp:TemplateField HeaderText="Vacancy Status">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                            Width="2%" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblVacStatus" runat="server" SkinID="gridLabel" Text='<%# bind("VacStatus") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
