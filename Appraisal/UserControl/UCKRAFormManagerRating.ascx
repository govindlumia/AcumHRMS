<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCKRAFormManagerRating.ascx.cs" Inherits="Appraisal_UserControl_UCKRAFormManagerRating" %>

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

    function peerManagerCheck(div, chkBox, divManager) {

        if (chkBox.checked === true) {
            div.style["display"] = "block";
            divManager.style["display"] = "none";
        } else {
            div.style["display"] = "none";
            divManager.style["display"] = "block";
        }

        return false;
    }


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
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>
<div>
    <table width="100%">
        <tr>
            <td valign="top" class="blue-brdr-1">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="3%">
                            <img src="../../images/employee-icon.jpg" width="16" height="16" alt="" />
                        </td>
                        <td class="txt01">Appraisal Form
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
                <uc1:EmployeeDetail ID="EmployeeDetail1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>

                <uc2:UserApprovalDetail ID="UserApprovalDetail1" runat="server" />
            </td>
        </tr>


    </table>

    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="100%"
        CssClass="ajax__tab_xp2">
        <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Performance Review">
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
                                                (<asp:Label ID="lblweightage" runat="server" Text='<%# UtilMethods.ConvertToDecimelUptoZero(Eval("Weightage")) %>'></asp:Label>)
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
                                                                        <td class="frm-lft-clr123" width="10%"></td>
                                                                        <td class="frm-lft-clr123" width="30%">KRA</td>
                                                                        <td class="frm-lft-clr123" width="10%">Weightage</td>
                                                                        <td class="frm-lft-clr123" width="10%">Self Rating</td>
                                                                       <%-- <td class="frm-lft-clr123" width="10%">Self Comment</td>--%>
                                                                        <%--<td class="frm-lft-clr123" width="10%">Manager Comment</td>--%>
                                                                        <td class="frm-lft-clr123" width="25%">Manager Rating</td>
                                                                        <td class="frm-lft-clr123" width="15%">Comment</td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-rght-clr1234" width="10%">
                                                                             <asp:CheckBox ID="chkKRADetailId" AutoPostBack="True" OnCheckedChanged="chk_CheckedChanged"  Visible="true" runat="server" ToolTip='<%# Bind ("ID") %>'></asp:CheckBox>
                                                                            </td>
                                                                        <td class="frm-rght-clr1234" width="30%">
                                                                            <asp:Label ID="lblKRASettingDetail" Visible="false" runat="server" Text='<%# Bind ("KRASettingDetailId") %>'></asp:Label>
                                                                            <asp:Label ID="txtKRA" runat="server" Text='<%# Bind ("KRA") %>'></asp:Label>

                                                                        </td>
                                                                        <td class="frm-rght-clr1234" align="center" width="10%">
                                                                            
                                                                            <asp:Label ID="txtWeightage" runat="server" Text='<%# UtilMethods.ConvertToDecimelUptoZero(Eval("Weightage")) %>'></asp:Label>

                                                                        </td>
                                                                         <td class="frm-rght-clr1234" align="center" width="10%">
                                                                        <asp:Label ID="lblSelfRating" runat="server"  Text='<%# Bind ("SelfRating") %>'></asp:Label>
                                                                              <asp:HiddenField runat="server" id="lblManagerRating" Value='<%# Bind ("ManagerRating") %>'></asp:HiddenField>
                                                                             <asp:Label ID="lblSelfComment" visible="false" runat="server"  Text='<%# Bind ("SelfComment") %>'></asp:Label>
                                                                             <asp:Label id="lblManagerComment" visible="false" runat="server"  Text='<%# Bind ("ManagerComment") %>'></asp:Label>
                                                                             </td>
                                                                         <%--<td class="frm-rght-clr1234" width="10%">
                                                                        
                                                                            
                                                                             </td>--%>
                                                                         <%--<td class="frm-rght-clr1234" width="10%">
                                                                             
                                                                        <%--<asp:Label id="lblManagerRating" runat="server" Visible="false" Text='<%# Bind ("ManagerRating") %>'></asp:Label>--%>
                                                                                                                                                           
                                                                        <td class="frm-rght-clr1234" width="25%">
                                                                            <div runat="server" id="divManager" style="display:block;">
                                                                            <asp:DropDownList ID="ddlRating" runat="server">                                                                             
                                                                            </asp:DropDownList>
                                                                                <span id="isPeerText" runat="server" visible="false" style="color: Red">*</span>   
                                                                                <asp:HiddenField runat="server" id="hdnPeerCode" Value='<%# Bind ("PeerManagerCode") %>'></asp:HiddenField>
                                                                                </div>
                                                                           <div id="divPeerManager" runat="server" style="display:none;">
                                                                               <asp:Label ID="hdnField" runat="server" Text=""></asp:Label>
                                                                                <asp:TextBox ID="txtEmpCode" Text="" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="peer" runat="server"
                                ControlToValidate="txtEmpCode"
                                SetFocusOnError="True" ToolTip="Select Customer"
                                ErrorMessage="Required" Width="6px">
                            </asp:RequiredFieldValidator>
                            <a runat="server" id="lnkA" 
                                class="link05" style="margin-left: 60px;">Pick</a>
                                                                           </div>
                                                                            </td>
                                                                        <td class="frm-rght-clr1234" width="15%">
                                                                        <a href="JavaScript:divexpandcollapse('<%# Eval("ID") %>');" style="cursor:pointer;text-decoration: underline;float:left;margin-left:10px;"> Add </a>
                                                                        <div id='modal<%# Eval("ID") %>' class="modal">
    <div class="modal-header">
        <h3>Comment <a class="close-modal" href="JavaScript:divexpandcollapse('<%# Eval("ID") %>')">&times;</a></h3>
    </div>
    <div  class="modal-body">
       
              <div style="text-align:center; padding:20px; margin-bottom:20px"      >
                  <asp:TextBox ID="txtAddComment" Width="292px" Height="63px" style = "resize:none" Text= '<%# Bind ("Comment") %>' runat="server" TextMode="MultiLine" Rows="10" Columns="30" ></asp:TextBox>
              </div>
    </div>
    <div class="modal-footer">
         <%--<asp:Button ID="btn_close" runat="server" Text="OK" CssClass="modalOK close-modal" />--%>
        <a href="JavaScript:divexpandcollapse('<%# Eval("ID") %>')" class="button">OK</a>
    </div>
</div>
                                                                        <div class="modal-backdrop"></div>
                                                                            <a runat="server" id="lnkViewAll" href="" style=" cursor:pointer;float:left;margin-left:10px;text-decoration: underline;">View</a>
                                                                            <a href="JavaScript:divexpandcollapse('<%# Eval("ID") %>');" style="display:none; cursor:pointer;float:left;margin-left:10px;text-decoration: underline;" class="openModal"> View </a>
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
                </ItemTemplate>
                            </asp:TemplateField>
                        </columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
            <td class="txt02" height="22">
                <table width="100%" runat="server">
                    <tr>
                        <td width="27%" class="txt02" height="22">Comments History
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="grdHistory" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                PageSize="10" BorderWidth="1px"
                                EmptyDataText="No records found.."
                                BorderColor="#c9dffb">
                                <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                <columns>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDuration" style="word-wrap:break-word;" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="70%" />
                                                        </asp:TemplateField>
                                                    </columns>
                                <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123"></headerstyle>
                                <footerstyle cssclass="frm-lft-clr123" />
                                <rowstyle></rowstyle>
                                <pagerstyle cssclass="frm-lft-clr123" width="500px" font-size="18px" horizontalalign="Left"
                                    verticalalign="Top" />
                                <pagersettings mode="NumericFirstLast" position="TopAndBottom" visible="true" lastpagetext="last"
                                    nextpagetext="next" previouspagetext="prev" firstpagetext="first" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td runat="server" id="trPeerComments" visible="false">
                            <asp:GridView ID="grdPeerComments" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                PageSize="10" BorderWidth="1px"
                                EmptyDataText="No records found.."
                                BorderColor="#c9dffb">
                                <%-- <PagerSettings PageButtonCount="100"></PagerSettings>--%>
                                <columns>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label26" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label28" style="word-wrap:break-word;" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            <ItemStyle CssClass="frm-rght-clr1234" Width="70%" />
                                                        </asp:TemplateField>
                                                    </columns>
                                <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123"></headerstyle>
                                <footerstyle cssclass="frm-lft-clr123" />
                                <rowstyle></rowstyle>
                                <pagerstyle cssclass="frm-lft-clr123" width="500px" font-size="18px" horizontalalign="Left"
                                    verticalalign="Top" />
                                <pagersettings mode="NumericFirstLast" position="TopAndBottom" visible="true" lastpagetext="last"
                                    nextpagetext="next" previouspagetext="prev" firstpagetext="first" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>  
                    <tr>
            <td height="20" valign="top" class="txt02">
                <table width="100%">
                    <tr>
                        <td width="27%" class="txt02" height="22">Comments<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" Rows="4" Columns="40" Width="489px" Height="72px" style="resize: none" TextMode="MultiLine" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComment"
                                SetFocusOnError="True" ToolTip="*" ValidationGroup="c"
                                ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                    <tr>
                        <td>
                            <table width="100%">
              
        <tr>
            <td class="head-2" align="Right" valign="top">
                <asp:Button ID="btnSubmit" ValidationGroup="c" OnClientClick ="return confirm_meth()" CssClass="button" OnClick="SaveData"
                    runat="server" Text="Submit" />
                <asp:Button ID="btnDraft" CssClass="button" OnClick="SaveData" OnClientClick ="return confirm_Draft()" runat="server" Text="Save as Draft" />
                <asp:Button ID="btnClose" CssClass="button" runat="server" Text="Close" OnClick="btnClose_Click" />
            </td>
        </tr>
    </table>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Training">
            <HeaderTemplate>
                Training
            </HeaderTemplate>
            <ContentTemplate>

                <table width="100%">
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Skills/Competencies</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdSkills" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                            EmptyDataText="No records found.."
                                            BorderColor="#C9DFFB">
                                            <columns>
                                            <asp:TemplateField HeaderText="Skills/Competencies">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSkills" style="word-wrap:break-word;" runat="server" Text='<%# Bind("Skills") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="60%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Competencies" visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCompetencies" runat="server" Text='<%# Bind("Competencies") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Self Rating">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Manager's Rating">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMR" runat="server" Text='<%# Bind("ManagerRating") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
                                            </asp:TemplateField>                                           
                                        </columns>
                                            <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123"></headerstyle>
                                            <footerstyle cssclass="frm-lft-clr123" />
                                            <rowstyle></rowstyle>
                                            <pagerstyle cssclass="frm-lft-clr123" width="500px" font-size="18px" horizontalalign="Left"
                                                verticalalign="Top" />
                                            <pagersettings mode="NumericFirstLast" position="TopAndBottom" visible="true" lastpagetext="last"
                                                nextpagetext="next" previouspagetext="prev" firstpagetext="first" />
                                        </asp:GridView>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Training Attended </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdTrainingAttended" runat="server" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                            BorderWidth="1px" EmptyDataText="No records found.." BorderColor="#C9DFFB">
                                            <columns>
                                                    <asp:TemplateField HeaderText="Training"><ItemTemplate>
                                                            <asp:Label ID="Label1" style="word-wrap:break-word;" runat="server" Text='<%# Eval("TrainingName") %>'></asp:Label>
                                                           
                                                            
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Duration"><ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Duration") %>'></asp:Label>                                                           
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>
                                                                                                                                                                                                                
                                                </columns>
                                            <footerstyle cssclass="frm-lft-clr123" />
                                            <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123">
                                                </headerstyle>
                                        </asp:GridView>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Training Required - Employee </td>
                                </tr>
                                <tr>
                                    <td width="27%" class="txt02" height="22">
                                        <asp:GridView ID="grdTrainingEmployee" runat="server" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                            BorderWidth="1px" EmptyDataText="No records found.." BorderColor="#C9DFFB" OnRowCommand="grdTraining_RowCommand1">
                                            <columns>
                                                    <asp:TemplateField HeaderText="Training Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("TrainingType") %>'></asp:Label>

                                                            <asp:Label ID="Label4" Visible="false" runat="server" Text='<%# Eval("TrainingTypeId") %>'></asp:Label>
                                                            
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Training"><ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Training") %>'></asp:Label>   
                                                         <asp:Label ID="Label6" runat="server" Visible="false" Text='<%# Eval("TrainingId") %>'></asp:Label>                                                        
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>  
                                                <asp:TemplateField HeaderText="Recommended By"><ItemTemplate>
                                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("RecommendedBy") %>'></asp:Label>                                                                                                                 
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>                                                                                                                                                                                                                
                                                </columns>
                                            <footerstyle cssclass="frm-lft-clr123" />
                                            <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123">
                                                </headerstyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Training Required - Manager </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td width="20%" class="frm-lft-clr123">Training Type</td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList id="drpTrainingType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpTrainingType_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:textbox runat="server" visible="false" text="" id="txtTType"></asp:textbox>
                                                </td>
                                                
                                            </tr>
                                            <tr>
                                                <td width="20%" class="frm-lft-clr123">Training</td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList id="drpTraining" runat="server"></asp:DropDownList>
                                                    <asp:textbox runat="server" text="" visible="false" id="txtt"></asp:textbox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" class="frm-lft-clr123">&nbsp;</td>
                                                <td class="frm-rght-clr123">
                                                    <asp:Button runat="server" id="btnAddTraining" Text="Add" OnClick="btnAddTraining_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdTraining" runat="server" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                            BorderWidth="1px" EmptyDataText="No records found.." BorderColor="#C9DFFB" OnRowCommand="grdTraining_RowCommand1">
                                            <columns>
                                                    <asp:TemplateField HeaderText="Training Type"><ItemTemplate>
                                                            <asp:Label ID="TrainingType" runat="server" Text='<%# Eval("TrainingType") %>'></asp:Label>

                                                            <asp:Label ID="TrainingTypeId" Visible="false" runat="server" Text='<%# Eval("TrainingTypeId") %>'></asp:Label>
                                                            
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Training"><ItemTemplate>
                                                            <asp:Label ID="Training" runat="server" Text='<%# Eval("Training") %>'></asp:Label>   
                                                         <asp:Label ID="TrainingId" runat="server" Visible="false" Text='<%# Eval("TrainingId") %>'></asp:Label>                                                        
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>
                                                    
                                                    
                                                    
                                                    <asp:TemplateField HeaderText="Action"><ItemTemplate>
                                                            <asp:LinkButton ID="lnkView" runat="server" CommandName="rowDelete" 
                                                                Text="Delete">
                                                            </asp:LinkButton>
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle HorizontalAlign="Left" Width="10%" CssClass="frm-rght-clr1234" />
</asp:TemplateField>
                                                </columns>
                                            <footerstyle cssclass="frm-lft-clr123" />
                                            <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123">
                                                </headerstyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Training Comments History </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdTrainingComments" runat="server" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                            BorderWidth="1px" EmptyDataText="No records found.." BorderColor="#C9DFFB">
                                            <columns>
                                                    <asp:TemplateField HeaderText="Status"><ItemTemplate>
                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                           
                                                            
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="20%" />
</asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Comments"><ItemTemplate>
                                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("Comments") %>'></asp:Label>                                                           
                                                        
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="80%" />
</asp:TemplateField>
                                                                                                                                                                                                                
                                                </columns>
                                            <footerstyle cssclass="frm-lft-clr123" />
                                            <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123">
                                                </headerstyle>
                                        </asp:GridView>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="100%">
                               <tr>
                        <td width="20%" class="txt02" height="22">Training Comments
                        </td>
                        <td>
                            <asp:TextBox ID="txtTC" Rows="4" Width="489px" Height="72px" style="resize: none" Columns="40" TextMode="MultiLine" runat="server"></asp:TextBox>                            
                        </td>
                    </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Job Detail">
            <HeaderTemplate>
                Promotion and Future Direction 
            </HeaderTemplate>
            <ContentTemplate>

                <table width="100%">
                    <tr>
                        <td>


                            <asp:GridView ID="grdPromotion" runat="server" Width="100%" HorizontalAlign="Left"
                                CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                BorderWidth="1px" EmptyDataText="No records found.." BorderColor="#C9DFFB" OnRowDataBound="grdPromotion_RowDataBound">
                                <columns>
                                    <asp:TemplateField HeaderText="Post Appraisal Actions">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPromotion" runat="server" ToolTip='<%# Eval("PromotionId") %>' Text='<%# Eval("Promotion") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" Width="25%" />
                                    </asp:TemplateField>
                                     <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" AutoPostBack="True" OnCheckedChanged="chkPromotion_CheckedChanged" ToolTip='<%# Eval("PromotionId") %>' id="chkPromotion">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Comments">
                                        <ItemTemplate>
                                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                            <asp:TextBox Id="txtComments" enabled="false" Width="493px" TextMode="MultiLine" Height="43px" style = "resize:none" runat="server"></asp:TextBox>
                                            <a runat="server" id="allComments" visible="false" href="" class="link05">View</a>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" Width="70%" />
                                    </asp:TemplateField></columns>
                                <footerstyle cssclass="frm-lft-clr123" />
                                <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123"></headerstyle>
                            </asp:GridView>

                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>    
</div>
        
 <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                       <div class="divajaxmodal">
                            <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td >
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
        </contenttemplate>
</asp:UpdatePanel>


