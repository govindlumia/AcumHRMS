<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UCKRAForm.ascx.cs" Inherits="Appraisal_UserControl_UCKRAForm" %>
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
<Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</Ajax:ToolkitScriptManager>
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
        <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Performance Review">
            <HeaderTemplate>Performance Review</HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Performance Review </td>
                                    <td align="right">
                                        <asp:Button ID="btnNextP" visible="false" CssClass="button" runat="server" Text="Next" OnClick="btnNextP_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="head-2" valign="top">
                            <asp:GridView ID="grdKRAHead" runat="server" Font-Size="11px" Font-Names="Arial"
                                Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grd_RowDataBound">
                                <columns><asp:TemplateField><ItemTemplate>
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="frm-rght-clr1234">
                                                <b>
                                                    <asp:Label ID="lblKRA" runat="server" Text='<%# Bind ("KRAHead") %>'></asp:Label>
                                                </b>
                                                (<asp:Label ID="lblweightage" runat="server" Text='<%# Bind ("KRAHeadWeightAge") %>'></asp:Label>)
                                            <asp:Label ID="lblKRAHeadID" runat="server" Visible="false" Text='<%# Bind ("KRAHeadID") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdDetails" runat="server" Font-Size="11px" Font-Names="Arial"
                                                    Width="100%" AutoGenerateColumns="False" BorderWidth="0px" OnRowDataBound="grdDetails_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="30%">KRA</td>
                                                                        <td class="frm-lft-clr123" width="25%">Weightage (%)</td>
                                                                        <td class="frm-lft-clr123" width="25%">Rating</td>
                                                                        <td class="frm-lft-clr123" width="20%">Comments</td>
                                                                    </tr>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-rght-clr1234" width="30%">
                                                                            <asp:Label ID="lblKRASettingDetail" Visible="false" runat="server" Text='<%# Eval("KRASettingDetailId").ToString() != "0" ? Eval("KRASettingDetailId").ToString() : Eval("ID").ToString() %>'></asp:Label>
                                                                            <asp:Label ID="txtKRA" runat="server" Text='<%# Bind ("KRA") %>'></asp:Label></td>
                                                                        <td class="frm-rght-clr1234" width="25%">
                                                                            <asp:Label ID="txtWeightage" runat="server" Text='<%# UtilMethods.ConvertToDecimelUptoZero(Eval("Weightage")) %>'></asp:Label></td>
                                                                        <td class="frm-rght-clr1234" width="25%">
                                                                            <asp:DropDownList ID="ddlRating" runat="server">                                                                               
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="lblSelfRD" Visible="false" runat="server" Text='<%# Eval("SelfRating") %>'></asp:Label>

                                                                        <td class="frm-rght-clr1234" width="20%">
                                                                        <a href="JavaScript:divexpandcollapse('<%# Eval("KRASettingDetailId").ToString() != "0" ? Eval("KRASettingDetailId").ToString() : Eval("ID").ToString() %>');" style="cursor:pointer;text-decoration: underline;float:left;margin-left:10px;"> Add </a>
                                                                        <div id='modal<%# Eval("KRASettingDetailId").ToString() != "0" ? Eval("KRASettingDetailId").ToString() : Eval("ID").ToString() %>' class="modal">
    <div class="modal-header">
        <h3>Comment <a class="close-modal" href="JavaScript:divexpandcollapse('<%# Eval("KRASettingDetailId").ToString() != "0" ? Eval("KRASettingDetailId").ToString() : Eval("ID").ToString() %>')">&times;</a></h3>
    </div>
    <div  class="modal-body">
       
              <div style="text-align:center; padding:20px; margin-bottom:20px"      >
                  <asp:TextBox ID="txtAddComment" runat="server" Width="292px" Height="63px" Text='<%# Eval("SelfComment") %>' style = "resize:none" TextMode="MultiLine" Rows="10" Columns="30" ></asp:TextBox>
              </div>
    </div>
    <div class="modal-footer">
         <%--<asp:Button ID="btn_close" runat="server" Text="OK" CssClass="modalOK close-modal" />--%>
        <a href="JavaScript:divexpandcollapse('<%# Eval("KRASettingDetailId").ToString() != "0" ? Eval("KRASettingDetailId").ToString() : Eval("ID").ToString() %>')" class="button">OK</a>
    </div>
</div>
                                                                        <div class="modal-backdrop"></div>
                                                                            <a href="JavaScript:divexpandcollapse('<%# Eval("KRASettingDetailId").ToString() != "0" ? Eval("KRASettingDetailId").ToString() : Eval("ID").ToString() %>');" style="display:none; cursor:pointer;float:left;margin-left:10px;text-decoration: underline;" class="openModal"> View </a>
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
</asp:TemplateField></columns>
                            </asp:GridView></td>
                    </tr>
                     <tr>
            <td height="20" valign="top">
                <table width="100%">
                    <tr>
                        <td width="10%" class="txt02" height="22">Comments<span style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtComment" Rows="4" Width="489px" Height="72px" style="resize: none" Columns="40" TextMode="MultiLine" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtComment"
                                SetFocusOnError="True" ToolTip="Enter Comments" ValidationGroup="c"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                    <tr>
                        <td>
                            <table width="100%">
        <tr>
            <td></td>
        </tr>       
        <tr>
            <td class="head-2" align="right" valign="top">
                <asp:Button ID="btnDraft" CssClass="button" ValidationGroup="c"
                    runat="server" Text="Save as Draft" OnClick="SavaData" />
                <asp:Button ID="btnSubmit" ValidationGroup="c" OnClick="SavaData" OnClientClick ="return confirm_meth()" CssClass="button" runat="server" Text="Submit" />
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
            <HeaderTemplate>Training</HeaderTemplate>
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td height="20" valign="top" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td width="27%" class="txt02" height="22">Skills/Competencies</td>
                                    <td align="right">
                                        <asp:Button ID="btnPrev" visible="False" CssClass="button" runat="server" Text="Previous" OnClick="btnPrev_Click"  />                                        
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="grdSkills" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left"
                                            CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" BorderWidth="1px"
                                            EmptyDataText="No records found.."
                                            BorderColor="#C9DFFB">
                                            <columns>
                                            <asp:TemplateField HeaderText="Skills/Competencies"><ItemTemplate>
                                                        <asp:Label ID="lblSkills" style="word-wrap:break-word;" runat="server" Text='<%# Bind("Skills") %>'></asp:Label>
                                                    
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="60%" />
</asp:TemplateField>
                                            <asp:TemplateField HeaderText="Competencies" visible="false"><ItemTemplate>
                                                        <asp:Label ID="lblCompetencies" runat="server" Text='<%# Bind("Competencies") %>'></asp:Label>
                                                    
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
</asp:TemplateField>
                                            <asp:TemplateField HeaderText="Self Rating"><ItemTemplate>
                                                        <asp:Label ID="lblSR" runat="server" Text='<%# Bind("SelfRating") %>'></asp:Label>
                                                    
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
</asp:TemplateField>

                                            <asp:TemplateField HeaderText="Manager's Rating"><ItemTemplate>
                                                        <asp:Label ID="lblMR" runat="server" Text='<%# Bind("ManagerRating") %>'></asp:Label>
                                                    
</ItemTemplate>

<HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />

<ItemStyle CssClass="frm-rght-clr1234" Width="10%" />
</asp:TemplateField>                                           
                                        </columns>
                                            <footerstyle cssclass="frm-lft-clr123" />
                                            <headerstyle horizontalalign="Left" verticalalign="Top" cssclass="frm-lft-clr123"></headerstyle>
                                            <pagersettings mode="NumericFirstLast" position="TopAndBottom" lastpagetext="last"
                                                nextpagetext="next" previouspagetext="prev" firstpagetext="first" />
                                            <pagerstyle cssclass="frm-lft-clr123" width="500px" font-size="18px" horizontalalign="Left"
                                                verticalalign="Top" />
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
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TrainingName") %>'></asp:Label>
                                                    
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
                                    <td width="27%" class="txt02" height="22">Training Required </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr>
                                                <td width="20%" class="frm-lft-clr123">Training Type</td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList id="drpTrainingType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpTrainingType_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:textbox runat="server" visible="False" id="txtTType"></asp:textbox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%" class="frm-lft-clr123">Training</td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList id="drpTraining" runat="server"></asp:DropDownList>
                                                    <asp:textbox runat="server" visible="False" id="txtt"></asp:textbox>
                                                    
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
                        <td>&nbsp;</td>
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
    </cc1:TabContainer>    
</div>


<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajaxmodal">
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
                        </div>
                        
                    </ProgressTemplate>
                </asp:UpdateProgress>
        </contenttemplate>
</asp:UpdatePanel>

