<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="CreateCan.aspx.cs" Inherits="Recruitment_User_UploadResume" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function Display(name) {
            alert(name + ':::Record save successfully!');
        }
    </script>
    <script type="text/javascript">
        //  funcation for to check no
        function numberonly(e) {
            var KeyID = (window.event) ? event.keyCode : e.which;
            if ((KeyID >= 48 && KeyID <= 57) || KeyID == 8)
                return true;
            else
                alert("Please Enter Number Only");
            return false;
        }
    </script>
    <%--<script type="text/javascript">
        function DateSelectionChanged(e) {
            var today = new Date();
            var dob = e.get_selectedDate();
            var months = (today.getMonth() - dob.getMonth() + (12 * (today.getFullYear() - dob.getFullYear())));
            alert("Your age: " + Math.round(months / 12));
            var dob = document.getElementById("<%= txtDOB.ClientID %>");
            dob.value = "";
        }    
    </script>--%>
    <style type="text/css">
        .ddl
        {
            border: 1px solid #0171b1;
            font: normal 11px Arial, Helvetica, sans-serif;
            padding-left: 2px;
            color: Black;
        }
    </style>
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <table width="100%" border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td class="frm-lft-clr123">
                <strong>Add Candidate</strong>
            </td>
        </tr>
    </table>
    <fieldset id="Fieldset2" runat="server">
        <legend><b>Vacancy Details</b></legend>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="frm-lft-clr123">
                    Vacancy <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123">
                    <asp:DropDownList runat="server" Width="200px" ID="ddlvacancy" CssClass="ddl" OnDataBound="ddlvacancy_DataBound">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlvacancy"
                        Display="None" ErrorMessage="Select Job Vacancy." ToolTip="Select Job Vacancy"
                        ValidationGroup="v" Width="6px" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
                <td class="frm-lft-clr123">
                    Employee Reference <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123">
                    <asp:DropDownList runat="server" Width="178px" ID="ddlEmp_Ref" CssClass="ddl" OnDataBound="ddlEmp_Ref_DataBound">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlEmp_Ref"
                        Display="None" ErrorMessage="Select Employee" ToolTip="Select Employee" ValidationGroup="v"
                        Width="6px" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="2px">
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset id="Fieldset1" runat="server">
        <legend><b>Candidate Details</b></legend>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="2px">
                </td>
            </tr>
            <tr>
                <td width="10%" class="frm-lft-clr123">
                    First Name <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td width="10%" class="frm-rght-clr123">
                    <asp:TextBox ID="txtfirstname" runat="server" CssClass="input" MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfirstname"
                        Display="None" ErrorMessage="Enter Candidate First Name" ToolTip="Enter Candidate First Name"
                        ValidationGroup="v" Width="6px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td width="10%" class="frm-lft-clr123">
                    Last Name <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td width="10%" class="frm-rght-clr123">
                    <asp:TextBox ID="txtlastname" runat="server" CssClass="blue1" MaxLength="30"></asp:TextBox>
                </td>
                <td width="10%" class="frm-lft-clr123">
                    <%-- Middle Name--%>
                </td>
                <td width="10%" class="frm-rght-clr123">
                    <asp:TextBox ID="txtmidname" runat="server" Visible="false" CssClass="blue1" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="2px">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    Father Name <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123">
                    <asp:TextBox ID="txtFatherName" runat="server" CssClass="blue1" MaxLength='30'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFatherName"
                        Display="None" ErrorMessage="Enter Father Name" ToolTip="Enter Father Name" ValidationGroup="v"
                        Width="6px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="frm-lft-clr123">
                    DOB (Age > 18 ) <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123">
                    <asp:TextBox ID="txtDOB" Width="75px" runat="server" CssClass="blue1"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                        ToolTip="click to open calender" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtapplicationdate"
                        Display="None" ErrorMessage="Enter Date of Birth" SetFocusOnError="True" ToolTip="Enter DOB"
                        ValidationGroup="v" Width="6px">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDOB" runat="server" ControlToValidate="txtDOB" ClientValidationFunction="VAge"
                        ErrorMessage="Birth Date is under age 18." ValidationGroup="v" ForeColor="Red">*</asp:CustomValidator>
                    <Ajax:CalendarExtender ID="Calendar1" runat="server" PopupButtonID="Image2" Format="dd-MMM-yyyy"
                        TargetControlID="txtDOB">
                    </Ajax:CalendarExtender>
                </td>
                <td class="frm-lft-clr123">
                    Applied Date <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123">
                    <asp:TextBox ID="txtapplicationdate" Width="75px" runat="server" CssClass="blue1"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Calender/images/calendar_icon.gif"
                        ToolTip="click to open calender" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtapplicationdate"
                        Display="None" ErrorMessage="Enter Date of Application" SetFocusOnError="True"
                        ToolTip="Enter Application date" ValidationGroup="v" Width="6px">
                <img src="../../images/error1.gif" alt="" />
                    </asp:RequiredFieldValidator>
                    <Ajax:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                        Format="dd-MMM-yyyy" TargetControlID="txtapplicationdate">
                    </Ajax:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td height="2px">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    Email ID
                </td>
                <td class="frm-rght-clr123">
                    <asp:TextBox ID="txtemail" runat="server" CssClass="blue1" MaxLength='40'></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail" Display="None"
                        ErrorMessage="Enter Email Address" ToolTip="Enter Email Address" ValidationGroup="v"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Width="6px"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td class="frm-lft-clr123">
                    Contact No. <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123" colspan="3">
                    <asp:TextBox ID="txtcontactno" runat="server" onkeypress=" return isNumber (event)"
                        CssClass="blue1" MaxLength="10"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcontactno"
                        Display="None" ErrorMessage="Enter Contact No." ToolTip="Enter Contact No." ValidationGroup="v"
                        Width="6px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="2px">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    Search KeyWords
                </td>
                <td class="frm-rght-clr123" colspan="5">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="blue1" Width="492px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="2px">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    Resume <span style="color: Red; font-weight: bold;">*</span>
                </td>
                <td class="frm-rght-clr123" colspan="5">
                    <asp:FileUpload ID="txtflUpload" runat="server" />
                    <asp:RegularExpressionValidator ID="revImageUpload" runat="server" ControlToValidate="txtflUpload"
                        ErrorMessage="Word or Pdf document only." ValidationExpression="^.*\.(doc|docx|pdf)$"
                        ValidationGroup="v" Display="None"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtflUpload"
                        Display="None" ErrorMessage="Upload Resume" ToolTip="Upload Resume" ValidationGroup="v"
                        Width="6px" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="2px">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    Remarks
                </td>
                <td class="frm-rght-clr123" colspan="5">
                    <asp:TextBox ID="txtcomment" MaxLength="200" TextMode="MultiLine" Style="resize: none"
                        Width="400px" Height="70px" runat="server" CssClass="blue1"></asp:TextBox>
                    <span style="vertical-align: bottom"><i>(Max 200 chars)</i></span>
                </td>
            </tr>
        </table>
    </fieldset>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="5px">
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                    ValidationGroup="v" />
                <asp:Button ID="btndraft" ValidationGroup="v" runat="server" Text="Draft" CssClass="button"
                    OnClick="btndraft_Click" />
                <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="button" OnClick="btnreset_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="false"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
</asp:Content>
