<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCViewKRA.ascx.cs" Inherits="Appraisal_UserControl_UCViewKRA" %>
<%@ Register Src="../EmployeeDetail.ascx" TagName="EmployeeDetail" TagPrefix="uc1" %>
<%@ Register Src="../UserApprovalDetail.ascx" TagName="UserApprovalDetail" TagPrefix="uc2" %>
<script type="text/javascript">    jQuery.noConflict();</script>
<script type="text/javascript">

    $(document).ready(function () {


        $("[id*=grdKRAHead] [id*=grdPrimaryKRA]").each(function () {

            var gridID = $(this).attr("id");
            var index = gridID.lastIndexOf('grdPrimaryKRA');
            var labelId = gridID.substring(0, index) + 'lblweightage';
            var maxWeightageVal = parseFloat($('#' + labelId).text());

            $("#" + gridID + " [id*=txtWeightage]").on("change", function () {

                if (isNaN(parseFloat($(this).val()))) {
                    $(this).val('0');
                } else {
                    $(this).val(parseFloat($(this).val()).toString());
                }

                if (GetTotalPrimaryKRA(gridID) > maxWeightageVal) {
                    alert('Total Value of KRAs should be equal to KRA Head Value');
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
            debugger
            var gridID = $(this).attr("id");
            var index = gridID.lastIndexOf('grdPrimaryKRA');
            var labelId = gridID.substring(0, index) + 'lblweightage';
            var maxWeightageVal = parseFloat($('#' + labelId).text());

            if (GetTotalPrimaryKRA(gridID) != maxWeightageVal) {
                if (msg != '') {
                    msg += "\n" + "Total Value of KRAs should be equal to KRA Head Value";
                }
                else
                    msg += 'Total Value of KRAs should be equal to KRA Head Value';
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
        else
            return true;

    }


</script>
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
        <tr>
            <td>
                <uc1:EmployeeDetail ID="userControlEmployee" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <uc2:UserApprovalDetail ID="userControlApprover" runat="server" />
            </td>
        </tr>
        <tr>
            <td height="20" valign="top" class="txt02">
                <table width="100%">
                    <tr>
                        <td width="27%" class="txt02" height="22">KRA
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="head-2" valign="top">
                <asp:GridView ID="grdKRAHead" runat="server" Font-Size="11px" Font-Names="Arial"
                    Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grdKRAHead_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="frm-rght-clr1234">
                                            <b>
                                                <asp:Label ID="lblKRA" style="word-wrap:break-word;" runat="server" Text='<%# Bind ("KRAHead") %>'></asp:Label>
                                            </b>(<asp:Label ID="lblweightage" runat="server" Text='<%# Bind ("KRAHeadWeightAge") %>'></asp:Label>)
                                            <asp:Label ID="lblKRAHeadID" runat="server" Visible="false" Text='<%# Bind ("KRAHeadID") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdSettingDetails" runat="server" Font-Size="11px" Font-Names="Arial"
                                                Width="100%" AutoGenerateColumns="False" BorderWidth="0px">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="40%">KRA
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="20%">Weightage
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="30%">Comments
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="frm-rght-clr1234" width="40%">
                                                                        <asp:Label ID="txtKRA" style="word-wrap:break-word;" runat="server" Text='<%# Bind ("KRA") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="frm-rght-clr1234" width="20%">
                                                                        <asp:Label ID="txtWeightage" runat="server" Text='<%# Bind ("Weightage") %>'></asp:Label>
                                                                    </td>
                                                                    <td class="frm-rght-clr1234" width="30%">
                                                                        <asp:Label ID="txtComments" style="word-wrap:break-word;" runat="server" Text='<%# Bind ("SelfComment") %>'></asp:Label>
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
        <tr>
            <td></td>
        </tr>
        <tr>
            <td height="20" valign="top">
                <table width="100%">
                    <tr>
                        <td width="15%" class="txt02" height="22">User Comments
                        </td>
                        <td style="word-wrap: break-word;">
                            <%-- <asp:TextBox ID="txtUserComment" Rows="4" Columns="40" ReadOnly="true" TextMode="MultiLine" ValidationGroup="C"
                                runat="server"></asp:TextBox>    --%>
                            <asp:Label runat="server" ID="txtUserComment"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" runat="server" id="tblApproverComment">
                    <tr>
                        <td width="10%" class="txt02" height="22">Comments
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" Style="resize: none" Width="500px" Height="50px" TextMode="MultiLine" ValidationGroup="C"
                                runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqv" runat="server" ErrorMessage="Required" ValidationGroup="C"
                                ControlToValidate="txtComment"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <asp:Button ID="btnApprove" CssClass="button" OnClick="SaveData" ValidationGroup="C"
                    runat="server" Text="Approve" />
                <asp:Button ID="btnReject" CssClass="button" ValidationGroup="C" OnClick="SaveData"
                    runat="server" Text="Reject" />
                <asp:Button ID="btnEdit" CssClass="button" runat="server" Visible="false"
                    Text="Edit" OnClick="btnEdit_Click" />
            </td>
        </tr>
    </table>
</div>
