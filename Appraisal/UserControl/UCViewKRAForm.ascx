<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCViewKRAForm.ascx.cs" Inherits="Appraisal_UserControl_UCViewKRAForm" %>
<%@ Register Src="../EmployeeDetail.ascx" TagName="EmployeeDetail" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserApprovalDetail.ascx" TagName="UserApprovalDetail" TagPrefix="uc2" %>
<link href="../../Css/modal.css" rel="stylesheet" />
<script src="../../js/modal.js"></script>
<style type="text/css" media="all">
    @import "../../Css/blue1.css";
    @import "../../Css/example.css";
    @import "../../Css/ajax__tab_xp2.css";
</style>
<script type="text/javascript" src="../../js/tabber.js"></script>
<script type="text/javascript">
    document.write('<style type="text/css">.tabber{display:none;}<\/style>');
</script>
<script type="text/javascript">jQuery.noConflict();</script>
<script type="text/javascript">

    $(document).ready(function () {

    });


    function isEmpty(str) {
        return (!str || 0 === str.length);
    }
    function Validate() {
        var msg = '';
        // $("[id*=grdKRAHead] [id$=grdDetails]").each(function () {

        $("[id*=grdTraining] [id*=txtTrainingDesc]").each(function () {

            if (isEmpty($(this).val()))
                if (msg != '') {
                    msg += "\n" + "Training Description is Required";
                }
                else
                    msg += "Training Description is Required";
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
    function divexpandcollapse(divname) {

        var dvModal = document.getElementById('modal' + divname);

        if (dvModal.style.display == '' || dvModal.style.display == "none") {
            $("#" + dvModal.id.toString() + ", .modal-backdrop").fadeIn('fast');

        } else {

            $("#" + dvModal.id.toString() + ", .modal-backdrop").fadeOut('fast');
        }
    }

</script>
<Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</Ajax:ToolkitScriptManager>

<div>
    <table width="100%">
        <tr>
            <td valign="top" class="blue-brdr-1">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="3%">
                            <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                        </td>
                        <td class="txt01">KRA Form
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


    </table>

    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
        CssClass="ajax__tab_xp2">
        <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Job Detail">
            <HeaderTemplate>
                Performance Review
            </HeaderTemplate>
            <ContentTemplate>

                <table width="100%">
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Performance Review 
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-2" valign="top">
                            <asp:GridView ID="grdKRAForm" runat="server" Font-Size="11px" Font-Names="Arial" AllowPaging="false"
                                Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grd_RowDataBound">
                                <columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="frm-rght-clr1234">
                                                <b>
                                                    <asp:Label ID="lblKRA" runat="server" Text='<%# Bind ("KRAHead") %>'></asp:Label>
                                                </b>
                                                (<asp:Label ID="lblweightage" runat="server" Text='<%# Bind ("WeightAge") %>'></asp:Label>)
                                            <asp:Label ID="lblKRAHeadID" runat="server" Visible="false" Text='<%# Bind ("KRAHeadID") %>'></asp:Label>
                                                <asp:Label ID="lblKRAFormID" runat="server" Visible="false" Text='<%# Bind ("ID") %>'></asp:Label>
                                                
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdDetails" runat="server" Font-Size="11px" Font-Names="Arial" AllowPaging="false"
                                                    Width="100%" AutoGenerateColumns="False" BorderWidth="0px"  OnRowDataBound="grdDetails_RowDataBound" >
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="30%">KRA</td>
                                                                        <td class="frm-lft-clr123" width="25%">Weightage</td>
                                                                        <td class="frm-lft-clr123" width="25%">Rating</td>
                                                                        <td class="frm-lft-clr123" width="20%">Action</td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-rght-clr1234" width="30%">
                                                                            <asp:Label ID="lblKRASettingDetail" Visible="false" runat="server" Text='<%# Bind ("ID") %>'></asp:Label>
                                                                            <asp:Label ID="txtKRA" runat="server" Text='<%# Bind ("KRA") %>'></asp:Label></td>
                                                                        <asp:Label ID="lblSelfRating" runat="server" Visible="false" Text='<%# Bind ("SelfRating") %>'></asp:Label></td>
                                                                        <td class="frm-rght-clr1234" width="25%">
                                                                            <asp:Label ID="txtWeightage" runat="server" Text='<%# Bind ("Weightage") %>'></asp:Label></td>
                                                                        <td class="frm-rght-clr1234" width="25%">
                                                                            <asp:DropDownList ID="ddlRating" runat="server">
                                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                 <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                 <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                 <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                 <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                 <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                                 <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                                                 <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                                                 <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                                                 <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        <td class="frm-rght-clr1234" width="20%">
                                                                        <a href="JavaScript:divexpandcollapse('<%# Eval("ID") %>');" style="cursor:pointer;text-decoration: underline;float:left;margin-left:10px;"> Add </a>
                                                                        <div id='modal<%# Eval("ID") %>' class="modal">
    <div class="modal-header">
        <h3>Comment <a class="close-modal" href="JavaScript:divexpandcollapse('<%# Eval("ID") %>')">&times;</a></h3>
    </div>
    <div  class="modal-body">
       
              <div style="text-align:center; padding:20px; margin-bottom:20px"      >
                  <asp:TextBox ID="txtAddComment" Text= '<%# Bind ("Comment") %>' runat="server" TextMode="MultiLine" Rows="10" Columns="30" ></asp:TextBox>
              </div>
    </div>
    <div class="modal-footer">
         <%--<asp:Button ID="btn_close" runat="server" Text="OK" CssClass="modalOK close-modal" />--%>
        <a href="JavaScript:divexpandcollapse('<%# Eval("ID") %>')" class="button">OK</a>
    </div>
</div>
                                                                        <div class="modal-backdrop"></div>
                                                                            <a href="JavaScript:divexpandcollapse('<%# Eval("ID") %>');" style="cursor:pointer;float:left;margin-left:10px;text-decoration: underline;" class="openModal"> View </a>
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
                        </columns>
                            </asp:GridView>
                        </td>
                    </tr>

                </table>

            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Job Detail">
            <HeaderTemplate>
                Training
            </HeaderTemplate>
            <ContentTemplate>

                <table width="100%">
                    <tr>
                        <td>
                            <asp:GridView ID="grdTraining" runat="server" Font-Size="11px" Font-Names="Arial"
                                Width="100%" AutoGenerateColumns="False" BorderWidth="0px" ShowFooter="True" OnRowCommand="grdTraining_RowCommand" OnRowDataBound="grdTraining_RowDataBound">
                                <columns>
                            <asp:TemplateField>
                                        <FooterTemplate>
                                            <asp:Button ID="btnAddRow" CssClass="button" runat="server" Text="Add Row" OnClick="AddRow" ></asp:Button>
                                        </FooterTemplate>
                                        <ItemTemplate>
                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTrainingID" Visible="false" runat="server" Text='<%# Bind ("ID") %>'></asp:Label>
                                                        <label style="float:left;margin:10px">
                                                        Training Description</label>
                                                        <asp:TextBox ID="txtTrainingDesc" TextMode="MultiLine" runat="server" Text='<%# Bind ("TrainingDesc") %>'></asp:TextBox>
                                                        <asp:LinkButton Id="lnkDelete" style="margin:10px" runat="server" Text="Delete" CommandName="DeleteRecord" CommandArgument ='<%# Bind ("ID") %>'></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                 </columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
    <table>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td height="20" valign="top" class="txt02">
                <table width="100%">
                    <tr>
                        <td width="27%" class="txt02" height="22">Comments
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" Rows="4" Columns="40" TextMode="MultiLine" runat="server"></asp:TextBox>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="head-2" valign="top">
                <asp:Button ID="btnDraft" CssClass="button" ValidationGroup="C"
                    runat="server" Text="Save as Draft" OnClick="SavaData" />
                <asp:Button ID="btnSubmit" OnClientClick="return Validate();" OnClick="SavaData" CssClass="button" runat="server" Text="Submit" />
                <asp:Button ID="btnClose" CssClass="button" runat="server" Text="Close" />
            </td>
        </tr>
    </table>
</div>
