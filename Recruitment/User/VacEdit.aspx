<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentMaster.master"
    AutoEventWireup="true" CodeFile="VacEdit.aspx.cs" Inherits="Recruitment_User_VacAdvanceDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <script type="text/javascript" src="../../js/number.js"></script>
    <table width="100%" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td class="frm-lft-clr123">
                <strong>Edit Job Vacancy</strong>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="5px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Vaccancy ID
            </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lblVacID" runat="server"></asp:Label>
            </td>
            <td class="frm-lft-clr123">
                Created By
            </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lblCreatedBy" runat="server"></asp:Label>
            </td>
            <td class="frm-lft-clr123">
                Created Date
            </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="5px">
            </td>
        </tr>
    </table>
    <table width="100%" runat="server" cellpadding="0" cellspacing="0">
        <tr>
            <td class="frm-lft-clr123" width="35px">
                Job Title
            </td>
            <td class="frm-lft-clr123" width="20px">
                <asp:DropDownList runat="server" Width="178px" ID="ddl_jobtitle" CssClass="select"
                    DataTextField="Name" DataValueField="Vac_ID" OnDataBound="ddljobtitle_DataBound">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_jobtitle"
                    Display="Dynamic" ErrorMessage="Select Job Title." ToolTip="Select Job Title"
                    ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="0">
                <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Job Name
            </td>
            <td class="frm-lft-clr123">
                <asp:TextBox ID="txt_jobname" runat="server" CssClass="blue1" Width="370px" MaxLength='30'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_jobname"
                    Display="Dynamic" ErrorMessage="Enter Job Name" ToolTip="Enter Job Name" ValidationGroup="v"
                    Width="6px" SetFocusOnError="True">
               <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Job Location
            </td>
            <td class="frm-lft-clr123">
                <asp:DropDownList runat="server" Width="178px" ID="ddl_joblocation" CssClass="select"
                    OnDataBound="ddljoblocation_DataBound">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_joblocation"
                    Display="Dynamic" ErrorMessage="Select Job Location." ToolTip="Select Job Location"
                    ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="0">
            <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                No. Of Positions
            </td>
            <td class="frm-lft-clr123">
                <asp:TextBox ID="txt_position" onkeypress=" return isNumber (event)" runat="server"
                    CssClass="blue1" Width="172px" MaxLength='3'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_position"
                    Display="Dynamic" ErrorMessage="Enter No.Of Positions." ToolTip="Enter No.Of Positions."
                    ValidationGroup="v" Width="6px" SetFocusOnError="True">
                    <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_position"
                    ValidationExpression="\d+" ValidationGroup="v" Display="Static" EnableClientScript="true"
                    ErrorMessage="Please enter numbers only." runat="server" />
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Required Date
            </td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_reqdate" runat="server" CssClass="blue1" Width="172px"></asp:TextBox>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                    ToolTip="click to open calender" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_reqdate"
                    Display="Dynamic" ErrorMessage="Enter Date of Required" SetFocusOnError="True"
                    ToolTip="Enter Date of Required" ValidationGroup="v" Width="6px">
                                                                            <img src="../../images/error1.gif" alt="" />
                </asp:RequiredFieldValidator>
                <Ajax:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                    Format="dd-MMM-yyyy" TargetControlID="txt_reqdate">
                </Ajax:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Description
            </td>
            <td class="frm-rght-clr123">
                <asp:Label ID="lblDesca" runat="server" Style="autosize: true; wrap: true;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Comment
            </td>
            <td class="frm-lft-clr123">
                <asp:TextBox ID="txt_comment" runat="server" CssClass="blue1" Width="370px" Height="70px"
                    Style="resize: none" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_comment"
                    Display="Dynamic" ErrorMessage="Enter Remarks." ToolTip="Enter Remarks" ValidationGroup="v"
                    Width="6px" SetFocusOnError="True">
             <img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
            </td>
            <td class="frm-rght-clr123">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" OnClick="btnUpdate_Click"
                    ValidationGroup="v" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
</asp:Content>
