<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="KRASettingAdmin.aspx.cs" Inherits="Appraisal_Admin_KRASettingAdmin" %>

<%@ Register Src="../EmployeeDetail.ascx" TagName="EmployeeDetail" TagPrefix="uc1" %>
<%@ Register Src="../UserApprovalDetail.ascx" TagName="UserApprovalDetail" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">        jQuery.noConflict();</script>
    <script type="text/javascript">
        function GetTotalPrimaryKRA(idOfGrid) {

            var totalPrimary = 0;
            $("#" + idOfGrid + " [id*=txtWeightage]").each(function () {
                totalPrimary = totalPrimary + parseFloat($(this).val());
            });
            return totalPrimary;
        }
        function isEmpty(str) {
            return (!str || 0 === str.length);
        }
        function Validate() {
            var msg = '';
            var company = $('[id*=drp_comp_name]');
            var designation = $('[id*=drpdegination]');

            if (company && company.length > 0) {
                if (company[0].value === "0") {
                    msg += "\n" + "Select Company.";
                }
            }

            if (designation && designation.length > 0) {
                if (designation[0].value === "0") {
                    msg += "\n" + "Select Designation.";
                }
            }

            $("[id*=grdKRAHead] [id$=grdPrimaryKRA]").each(function () {
                var gridID = $(this).attr("id");
                var index = gridID.lastIndexOf('grdPrimaryKRA');
                var labelId = gridID.substring(0, index) + 'lblweightage';
                var maxWeightageVal = parseFloat('100');

                if (GetTotalPrimaryKRA(gridID) != maxWeightageVal) {
                    if (msg != '') {
                        msg += "\n" + "Total Value of KRAs should be equal to 100";
                    }
                    else
                        msg += 'Total Value of KRAs should be equal to 100';
                }


                $("#" + gridID + " [id*=txtKRA]").each(function () {
                    if (isEmpty($(this).val()))
                        if (msg != '') {
                            msg += "\n" + "KRA Required";
                        }
                        else
                            msg += "KRA Required";
                });
            });

            if (msg != '' && msg.length > 0) {
                alert(msg);
                return false;
            }
            else
                return true;

        }


    </script>
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <table width="100%">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                                    </td>
                                    <td class="txt01">KRA Setting
                                    </td>
                                    <td align="right">
                                        <asp:Button runat="server" ID="lnkView" Visible="false" CssClass="button-bg" OnClick="lnkView_Click" Text="View" />
                                        <asp:Button runat="server" ID="lnkCreate" CssClass="button-bg" OnClick="lnkCreate_Click" Text="Create/Update" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td class="frm-lft-clr123" width="20%">Company<span style="color: Red">*</span>
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" Width="145px"
                                            Height="20px" OnSelectedIndexChanged="drp_comp_name_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drp_comp_name"
                                            InitialValue="0" SetFocusOnError="True" ToolTip="Select Company" CssClass="errorMsg" ValidationGroup="create"
                                            ErrorMessage="Select Company"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" width="20%">Designation<span style="color: Red">*</span></td>
                                    <td class="frm-rght-clr123">
                                       <%-- <asp:DropDownList ID="drpdegination" runat="server" CssClass="blue1" Height="20px"
                                            Width="147px" AutoPostBack="True" OnSelectedIndexChanged="drpdegination_SelectedIndexChanged">
                                        </asp:DropDownList>--%>

                                        <asp:ListBox ID="drpdegination" runat="server" CssClass="blue1" Height="150px"
                                            Width="250px" AutoPostBack="true" SelectionMode="Single" OnSelectedIndexChanged="drpdegination_SelectedIndexChanged"></asp:ListBox>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpdegination"
                                            InitialValue="0" SetFocusOnError="True" ToolTip="Select Designation" CssClass="errorMsg" ValidationGroup="create"
                                            ErrorMessage="Select Designation"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr id="trCreate" runat="server" visible="false">
                                    <td class="frm-lft-clr123" width="20%">Copy from Designation
                                    <td class="frm-rght-clr123">
                                        <asp:DropDownList ID="drpCDesignation" runat="server" CssClass="blue1" Height="20px"
                                            Width="147px" AutoPostBack="True" OnSelectedIndexChanged="drpCDesignation_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <div id="divCreate" runat="server" visible="false">
                        <tr>
                            <td class="head-2" valign="top" colspan="2">

                                <asp:GridView ID="grdKRAHead" runat="server" Font-Size="11px" Font-Names="Arial"
                                    AllowPaging="false" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                                    OnRowDataBound="grdKRAHead_RowDataBound" OnRowCommand="grdKRAHead_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="frm-rght-clr1234">
                                                            <b>
                                                                <asp:Label ID="lblKRA" runat="server" Text='<%# Bind ("KRAHead") %>'></asp:Label>
                                                            </b>(<asp:Label ID="lblweightage" runat="server" Text='<%# Bind ("WeightAge") %>'></asp:Label>
                                                            % Weight Age)
                                                        <asp:Label ID="lblKRAHeadID" runat="server" Visible="false" Text='<%# Bind ("ID") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdPrimaryKRA" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                Width="100%" AutoGenerateColumns="False" OnRowDataBound="grdPrimaryKRA_RowDataBound" BorderWidth="0px" OnRowCommand="grdPrimaryKRA_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="70%">KRA<span style="color: Red">*</span>
                                                                                    </td>
                                                                                    <td class="frm-lft-clr123" width="20%">Weightage (%)<span style="color: Red">*</span>
                                                                                    </td>
                                                                                    <td class="frm-lft-clr123" width="10%">Action
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td class="frm-rght-clr1234" width="70%">
                                                                                        <asp:TextBox ID="txtKRA" TextMode="MultiLine" Height="40px" runat="server" Width="640px" Style="resize: none" MaxLength="3000" Text='<%# Bind ("KRA") %>'></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtKRA"
                                                                                            SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="create"
                                                                                            ErrorMessage="*" Width="6px"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr1234" valign="top" width="20%">
                                                                                        <asp:TextBox ID="txtWeightage" Width="80px" MaxLength="3" onkeypress="return isNumber(event)" runat="server" Text='<%# Bind ("Weightage") %>'></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWeightage"
                                                                                            SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="create"
                                                                                            ErrorMessage="*" Width="6px"></asp:RequiredFieldValidator>

                                                                                    </td>
                                                                                    <td class="frm-rght-clr1234" width="10%">
                                                                                        <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Bind ("ID") %>' runat="server"
                                                                                            CommandName="DeleteRecord" Text="Delete"></asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="btnAddMore" CssClass="button" runat="server" Text="Add More" CommandName="AddMore" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="head-2" valign="top" align="right">
                                <asp:Button ID="btnSubmit" CssClass="button" OnClientClick="return confirm_meth()" OnClick="SaveData" ValidationGroup="create"
                                    runat="server" Text="Submit" />
                                Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                            </td>
                        </tr>
                    </div>
                    <div id="divView" runat="server" visible="true">
                        <tr>
                            <td class="frm-rght-clr123" align="right" colspan="2">
                                <table cellpadding="0" cellspacing="0" width="99%">
                                    <tr>
                                        <td class="frm-rght-clr123" align="right">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            <asp:LinkButton ID="lnkPre" runat="server" SkinID="linkGrid" CommandName="Previous"
                                                                ForeColor="#013366" OnCommand="ChangePage"><b>Previous</b></asp:LinkButton>
                                                            &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" SkinID="linkGrid" runat="server"
                                                                ForeColor="#013366" CommandName="Next" OnCommand="ChangePage"><b>Next</b></asp:LinkButton>
                                                        </label>
                                                    </td>
                                                    <td width="100px">
                                                        <span class="p-page">( Page -
                                                                                                                            <asp:Label ID="lblCurrentPage" CssClass="p-page1" runat="server"></asp:Label>
                                                            of
                                                                                                                            <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
                                                            ) </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan="2">

                                <asp:GridView ID="grdResult" Visible="false" runat="server" Font-Size="11px" Font-Names="Arial"
                                    AllowPaging="false" Width="100%" EmptyDataText="No Records Found.." AutoGenerateColumns="False" BorderWidth="0px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="20%">Company Name</td>
                                                        <td class="frm-lft-clr123" width="20%">Designation Name</td>
                                                        <td class="frm-lft-clr123" width="20%">KRA Head</td>
                                                        <td class="frm-lft-clr123" width="20%">KRA</td>
                                                        <td class="frm-lft-clr123" width="20%">Weight Age</td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <%#Eval("companyname") %>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <%#Eval("designationname") %>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <%#Eval("KRAHead") %>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <%#Eval("KRA") %>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <%#Eval("WeightAge") %>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                                <asp:GridView ID="grdView" runat="server" Font-Size="11px" Font-Names="Arial"
                                    AllowPaging="false" Width="100%" EmptyDataText="No Records Found.." AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grdView_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="20%">Company Name</td>
                                                        <td class="frm-lft-clr123" width="20%">Designation Name</td>
                                                        <td class="frm-lft-clr123" width="15%">KRA Head</td>
                                                        <td class="frm-lft-clr123" width="35%">KRA</td>
                                                        <td class="frm-lft-clr123" width="10%">Weight Age</td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label runat="server" ID="lblCName" Style="word-wrap: break-word;" Text='<%#Eval("companyname") %>'></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label runat="server" ID="lblDName" Style="word-wrap: break-word;" ToolTip='<%#Eval("DesignationId") %>' Text='<%#Eval("designationname") %>'></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123" colspan="3" width="60%" cellpadding="0" cellspacing="0">
                                                            <asp:GridView Width="100%" runat="server" ID="grdLeve1" AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grdLeve1_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td class="frm-rght-clr123" width="15%">
                                                                                        <asp:Label runat="server" ID="lblKHead" Style="word-wrap: break-word;" ToolTip='<%#Eval("KRAHeadId") %>' Text='<%#Eval("KRAHead") %>'></asp:Label>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" colspan="2" width="45%" cellpadding="0" cellspacing="0">
                                                                                        <asp:GridView Width="100%" runat="server" ID="grdLeve2" AutoGenerateColumns="False" BorderWidth="0px">
                                                                                            <Columns>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                                                            <tr>
                                                                                                                <td class="frm-rght-clr123" width="35%">
                                                                                                                    <asp:Label runat="server" ID="lblKRA" Style="word-wrap: break-word;" Text='<%#Eval("KRA") %>'></asp:Label>
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                                                    <asp:Label runat="server" ID="lblWeightAge" Style="word-wrap: break-word;" Text='<%#Eval("WeightAge") %>'></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </div>

                </table>
            </div>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajaxmodal">
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <img alt="" src="../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

