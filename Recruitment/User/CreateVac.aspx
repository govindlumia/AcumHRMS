<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentMaster.master"
    AutoEventWireup="true" CodeFile="CreateVac.aspx.cs" Inherits="Recruitment_User_CreateVac" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <script type="text/javascript">
        function numberonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) //if not a number
                    return false //disable key press
            }
        }
    </script>
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td class="frm-rght-clr123">
                <strong>Create Job Vacancy</strong>
            </td>
        </tr>
    </table>
    <table width="100%" runat="server" cellpadding="0" cellspacing="0">
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Job Title <span style="color: Red; font-weight: bold;">*</span>
            </td>
            <td class="frm-lft-clr123">
                <asp:DropDownList runat="server" Width="178px" ID="ddl_jobtitle" CssClass="select"
                    DataTextField="Name" DataValueField="Vac_ID" OnDataBound="ddljobtitle_DataBound">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_jobtitle"
                    Display="None" ErrorMessage="Select Job Title." ToolTip="Select Job Title" ValidationGroup="v"
                    Width="6px" SetFocusOnError="True" InitialValue="0">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Job Name <span style="color: Red; font-weight: bold;">*</span>
            </td>
            <td class="frm-lft-clr123">
                <asp:TextBox ID="txt_jobname" runat="server" CssClass="select" Width="370px" MaxLength='30'>
                </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txt_jobname" Display="None" ErrorMessage="Enter Job Name"
                    ToolTip="Enter Job Name" ValidationGroup="v" Width="6px" SetFocusOnError="True"
                    Height="16px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Job Description <span style="color: Red; font-weight: bold;">*</span>
            </td>
            <td class="frm-lft-clr123">
                <asp:FileUpload ID="txtflUpload" runat="server" />
                <asp:RegularExpressionValidator ID="revImageUpload" runat="server" ControlToValidate="txtflUpload"
                    ErrorMessage="Word or Pdf document only." ValidationExpression="^.*\.(doc|docx|pdf)$"
                    ValidationGroup="v" Display="None">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequriedFieldValidator" runat="server" ControlToValidate="txtflUpload"
                    ErrorMessage="Please Upload Document File." Display="None" SetFocusOnError="true"
                    ValidationGroup="v"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Job Location <span style="color: Red; font-weight: bold;">*</span>
            </td>
            <td class="frm-lft-clr123">
                <asp:DropDownList runat="server" Width="178px" ID="ddl_joblocation" CssClass="select"
                    OnDataBound="ddljoblocation_DataBound">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_joblocation"
                    Display="None" ErrorMessage="Select Job Location." ToolTip="Select Job Location"
                    ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                No. Of Positions <span style="color: Red; font-weight: bold;">*</span>
            </td>
            <td class="frm-lft-clr123">
                <asp:TextBox ID="txt_position" runat="server" CssClass="blue1" onkeypress=" return isNumber (event)"
                    Width="172px" MaxLength="3">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_position"
                    Display="None" ErrorMessage="Enter No.Of Positions." ToolTip="Enter No.Of Positions."
                    ValidationGroup="v" Width="6px" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td height="2px">
            </td>
        </tr>
        <tr>
            <td class="frm-lft-clr123">
                Required Date <span style="color: Red; font-weight: bold;">*</span>
            </td>
            <td class="frm-rght-clr123">
                <asp:TextBox ID="txt_reqdate" runat="server" CssClass="blue1" Width="172px" EnableViewState="false">
                </asp:TextBox>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                    ToolTip="click to open calender" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_reqdate"
                    Display="None" ErrorMessage="Enter Date of Required" SetFocusOnError="True" ToolTip="Enter Date of Required"
                    ValidationGroup="v" Width="6px">
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
            <td class="frm-lft-clr123">
                <asp:TextBox ID="txt_Desc" runat="server" MaxLength="200" CssClass="blue1" Width="370px"
                    Style="resize: none" Height="70px" TextMode="MultiLine">
                </asp:TextBox>
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
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                    ValidationGroup="v" />
                <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="button" OnClick="btnreset_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
</asp:Content>
