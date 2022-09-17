<%@ Page Title="KRA" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master"
    AutoEventWireup="true" CodeFile="KRASetting.aspx.cs" Inherits="Appraisal_User_KRASetting" %>

<%@ Register Src="../EmployeeDetail.ascx" TagName="EmployeeDetail" TagPrefix="uc1" %>
<%@ Register Src="../UserApprovalDetail.ascx" TagName="UserApprovalDetail" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">        jQuery.noConflict();</script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("[id*=grdKRAHead] [id*=grdPrimaryKRA]").each(function () {

                var gridID = $(this).attr("id");
                var index = gridID.lastIndexOf('grdPrimaryKRA');
                var labelId = gridID.substring(0, index) + 'lblweightage';
                var maxWeightageVal = parseFloat('100');

                $("#" + gridID + " [id*=txtWeightage]").on("change", function () {

                    if (isNaN(parseFloat($(this).val()))) {
                        $(this).val('0');
                    } else {
                        $(this).val(parseFloat($(this).val()).toString());
                    }

                    if (GetTotalPrimaryKRA(gridID) > maxWeightageVal) {
                        alert('Total Value of KRAs should be equal to 100');
                        return false;
                    }
                });

            });

        });

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
            $("[id*=grdKRAHead] [id$=grdPrimaryKRA]").each(function () {                
                var gridID = $(this).attr("id");
                var index = gridID.lastIndexOf('grdPrimaryKRA');
                var kraHead = $('#' + gridID.substring(0, index) + 'lblKRA').text();
                var labelId = gridID.substring(0, index) + 'lblweightage';
                var maxWeightageVal = parseFloat('100');

                if (GetTotalPrimaryKRA(gridID) != maxWeightageVal) {
                    if (msg != '') {
                        msg += "\n" + "Total Value of " + kraHead + " KRA should be equal to 100";
                    }
                    else
                        msg += 'Total Value of ' + kraHead + ' KRA should be equal to 100';
                }


                $("#" + gridID + " [id*=txtKRA]").each(function () {
                    if (isEmpty($(this).val()))
                        if (msg != '') {
                            msg += "\n" + "KRA Name Required";
                        }
                        else
                            msg += "KRA Name Required";
                });


            });


            if ($("#<%=txtComment.ClientID%>").val() == '') {
                if (msg != '') {
                    msg += "\n" + "Comments Required";
                }
                else
                    msg += "Comments Required";
            }

            if (msg != '' && msg.length > 0) {
                alert(msg);
                return false;
            }
            else {

                if (confirm("Are you want to submit the Form?")) {
                    return true;
                }
                else {
                    return false;
                }
            }
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
                                        <%-- <a href="leave-user.aspx" target="" class="txt-red">Back</a>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td>
                            <uc1:EmployeeDetail ID="userControlEmployee" runat="server" />
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td>
                            <uc2:UserApprovalDetail ID="userControlApprover" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Subordinates Information
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td width="10%" class="frm-lft-clr123" valign="top">
                                        Designation
                                    </td>
                                    <td width="25%" class="frm-rght-clr123" valign="top">
                                        <asp:DropDownList ID="drp_designation_name" runat="server" CssClass="blue1" Width="145px"
                                            Height="20px" utoPostBack="True" AutoPostBack="True" OnSelectedIndexChanged="drp_designation_name_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="15%" class="frm-lft-clr123" valign="top">
                                        Subordinates
                                    </td>
                                    <td class="frm-rght-clr123" valign="top">
                                        <asp:ListBox ID="lstEmployee" runat="server" CssClass="blue1" Height="100px"
                                            Width="250px" SelectionMode="Multiple" ></asp:ListBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <div runat="server" id="trCreate" visible="false">
                         <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">KRA Setting
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-2" valign="top">
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
                                                            Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowCommand="grdPrimaryKRA_RowCommand">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="40%">KRA
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="20%">Weightage (%)
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="30%">Comments
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="10%">Action
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="frm-rght-clr1234" width="40%">
                                                                                    <asp:TextBox ID="txtKRA" TextMode="MultiLine" runat="server" Style="resize: none" Width="265px" Height="40px" Text='<%# Bind ("KRA") %>'></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtKRA"
                                                                                        SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="create"
                                                                                        ErrorMessage="*" Width="6px"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td class="frm-rght-clr1234" valign="top" width="20%">
                                                                                    <asp:TextBox ID="txtWeightage" Width="80px" runat="server" MaxLength="4" onkeypress="return isNumber(event)" Text='<%# UtilMethods.ConvertToDecimelUptoZero(Eval("Weightage")) %>'></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtWeightage"
                                                                                        SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="create"
                                                                                        ErrorMessage="*" Width="6px"></asp:RequiredFieldValidator>
                                                                                </td>
                                                                                <td class="frm-rght-clr1234" valign="top" width="30%">
                                                                                    <asp:TextBox ID="txtComments" TextMode="MultiLine" Style="resize: none" Width="198px" Height="40px" runat="server" Text='<%# Bind ("KRAComment") %>'></asp:TextBox>
                                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComments"
                                                                                        SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="create"
                                                                                        ErrorMessage="*" Width="6px"></asp:RequiredFieldValidator>--%>
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
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="10%" class="txt02" height="22">Comments
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtComment" Style="resize: none" Width="500px" Height="50px" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComment"
                                            SetFocusOnError="True" CssClass="errorMsg" ValidationGroup="create"
                                            ErrorMessage="*" Width="6px"></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-2" valign="top" align="right">
                            <asp:Button ID="btnDraft" CssClass="button" Visible="false" ValidationGroup="create" OnClientClick="return confirm_Draft()" runat="server" Text="Save as Draft" OnClick="SaveData" />
                            <asp:Button ID="btnSubmit" OnClick="SaveData" OnClientClick="return Validate()" ValidationGroup="create" CssClass="button"
                                runat="server" Text="Submit" />
                            <asp:Button ID="btnClose" CssClass="button" OnClick="btnClose_Click" runat="server" Text="Close" />
                        </td>
                    </tr>
                    </div>

                   
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
