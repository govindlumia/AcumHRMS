<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Employee/Admin.master" AutoEventWireup="true"
    CodeFile="editempmaster.aspx.cs" Inherits="editempmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/example.css";
        @import "../../css/ajax__tab_xp2.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
        function updateValue(amount) {
            var textBox = document.getElementById('<%=Ttxtunderwriter.ClientID %>');
            textBox.value = amount;
        }    
    </script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
        function updateValue1(amount) {
            var textBox = document.getElementById('<%=Txt_rep_underwriter.ClientID %>');
            textBox.value = amount;
        }    
    </script>
    <script type="text/javascript" language="javascript">
        function ValidateText(i) {
            if (i.value.length > 0) {
                i.value = i.value.replace(/[^\d]+/g, '');
            }
        }

        
    </script>
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>--%>
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="2">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" Width="100%"
                    CssClass="ajax__tab_xp2">
                    <cc1:TabPanel ID="Tab_Job" BackColor="Red" CssClass="link05" runat="server" HeaderText="Job Detail">
                        <ContentTemplate>
                            <div>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="txt02">
                                            Employee Information
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="50%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="36%">
                                                                    Company Name
                                                                </td>
                                                                <td width="64%" class="frm-rght-clr123">
                                                                    <asp:Label ID="txtcompanyname" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="36%" class="frm-lft-clr123">
                                                                    First Name<span style="color: Red">*</span>
                                                                </td>
                                                                <td width="64%" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtfirstname" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfirstname"
                                                                        Display="Dynamic" ErrorMessage="Enter Employee First Name" ToolTip="Enter Employee First Name"
                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Middle Name
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtmiddlename" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Last Name<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtlastname" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                                 <asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtlastname"
                                                                        Display="Dynamic" ErrorMessage="Enter Employee last name" ToolTip="Enter Employee last Name"
                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True">
                                                                    </asp:RequiredFieldValidator>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td class="frm-lft-clr123">
                                                                   Login Id
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                 <asp:TextBox ID="txt_login_id" runat="server" CssClass="blue1" Width="142px" MaxLength="100"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="36%" class="frm-lft-clr123">
                                                                    Employee Code
                                                                </td>
                                                                <td width="64%" class="frm-rght-clr123">
                                                                    <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Employee Card No.
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                   <asp:TextBox ID="txt_card_no" runat="server" MaxLength="10" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Gender
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    &nbsp;<asp:DropDownList ID="drpgender" runat="server" CssClass="blue1" Height="20px"
                                                                        Width="147px">
                                                                        <asp:ListItem Value="0">---------Select---------</asp:ListItem>
                                                                        <asp:ListItem>Male</asp:ListItem>
                                                                        <asp:ListItem>Female</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="drpgender"
                                                                        ErrorMessage="Select Employee Gender" Operator="NotEqual" SetFocusOnError="True"
                                                                        ToolTip="Select Employee Gender" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="txt02">
                                            Work Information
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="50%" valign="top">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel5"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="divajax">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../../images/loading.gif" alt="" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="bottom" align="center" class="txt01" height="23">
                                                                                        Please Wait...
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Employee Status
                                                                            <span style="color: Red">*</span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:DropDownList ID="drpempstatus" runat="server" CssClass="blue1" Height="20px"
                                                                                Width="147px">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpempstatus"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Status" ValidationGroup="v"
                                                                                Width="6px" ErrorMessage="Please Enter Employee Status" InitialValue="0">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 5px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                           Category<span style="color: Red">*</span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:DropDownList ID="drpcategory" runat="server" CssClass="blue1" Height="20px" Width="147px">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpcategory"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Category Name" ValidationGroup="v"
                                                                                Width="6px" ErrorMessage="Please Enter Category Name" InitialValue="0">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5" colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                   <%-- <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Job Type <span style="color: Red">*</span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:DropDownList ID="drpjobtype" runat="server" CssClass="blue1" Height="20px"
                                                                                Width="147px">
                                                                            </asp:DropDownList>
                                                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="drpjobtype"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Job Type" ValidationGroup="v"
                                                                                Width="6px" ErrorMessage="Please Enter Job Type" InitialValue="0">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5" colspan="2">
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Date of Joining<span style="color: Red">*</span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="doj" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&#160;&#160;<asp:Image
                                                                                ID="Image8" runat="server" ImageUrl="~/images/clndr.gif" /><asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator18" runat="server" ControlToValidate="doj" Display="Dynamic"
                                                                                    ErrorMessage="Please Enter Joining Date" SetFocusOnError="True" ToolTip="Enter Joining Date"
                                                                                    ValidationGroup="v" Width="6px">
                                                                                </asp:RequiredFieldValidator><cc1:CalendarExtender ID="CalendarExtender8" runat="server"
                                                                                    PopupButtonID="Image8" TargetControlID="doj" Enabled="True" Format="dd-MMM-yyyy">
                                                                                </cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                              Date of Resignation
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txtdoleaving" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&#160;&#160;<asp:Image
                                                                                ID="Image5" runat="server" ImageUrl="../../images/clndr.gif" /><cc1:CalendarExtender
                                                                                    ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtdoleaving"
                                                                                    Enabled="True" Format="dd-MMM-yyyy">
                                                                                </cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="36%">
                                                                    Employee Role<span style="color: Red">*</span>
                                                                </td>
                                                                <td width="64%" class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="drprole" runat="server" Height="20px" CssClass="blue1" Width="142px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="drprole"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Role" ValidationGroup="v"
                                                                        Width="6px" ErrorMessage="Please Enter Employee Role" InitialValue="0"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Designation<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="drpdegination" runat="server" CssClass="blue1" Height="20px"
                                                                        Width="147px" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="drpdegination"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Designation Name" ValidationGroup="v"
                                                                        Width="6px" ErrorMessage="Please Enter Designation Name" InitialValue="0"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                          <%--  <tr>
                                                                <td class="frm-lft-clr123">
                                                                   Home Business Unit<span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="drphbu" runat="server" CssClass="blue1" Height="20px" Width="147px">
                                                                    </asp:DropDownList>
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="drphbu"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Home Business Unit" ValidationGroup="v"
                                                                        Width="6px" ErrorMessage="Please Enter Employee Home Business Unit" InitialValue="0"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>--%>
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123">
                                                                   Secondary Business Unit <span style="color: Red">*</span>
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                     <asp:DropDownList ID="drp_sbu" runat="server" CssClass="blue1" Height="20px" Width="147px">
                                                                    </asp:DropDownList>
                                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="drp_sbu"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Secondary Business Unit" ValidationGroup="v"
                                                                        Width="6px" ErrorMessage="Please Enter Secondary Business Unit" InitialValue="0"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Date of Relieving
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtdorelieving" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&nbsp;&nbsp;<asp:Image
                                                                        ID="Image7" runat="server" ImageUrl="../../images/clndr.gif" /><cc1:CalendarExtender
                                                                            ID="CalendarExtender7" runat="server" PopupButtonID="Image7" TargetControlID="txtdorelieving"
                                                                            Enabled="True" Format="dd-MMM-yyyy">
                                                                        </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="30%">
                                                                    Salary Calculation From<%--<span style="color: Red">*</span>--%></td>
                                                                <td class="frm-rght-clr123" width="70%">
                                                                    <asp:TextBox ID="txtsalary" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&nbsp;&nbsp;
                                                                    <asp:Image ID="Image11" runat="server" ImageUrl="../../images/clndr.gif" />&nbsp;&nbsp;
                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtsalary"
                                                                        Display="Dynamic" ErrorMessage="Please Enter Salary Calculation From Date" SetFocusOnError="True"
                                                                        ToolTip="Enter Salary Calculation From Date" ValidationGroup="v" Width="6px"></asp:RequiredFieldValidator>--%>
                                                                    <cc1:CalendarExtender
                                                                            ID="CalendarExtender6" runat="server" PopupButtonID="Image11" TargetControlID="txtsalary"
                                                                            Enabled="True" Format="dd-MMM-yyyy">
                                                                        </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" height="27px">
                                                                    Employee Photo
                                                                </td>
                                                                <td class="frm-rght-clr123" height="27px">
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                     <asp:Label ID= "lblphoto" runat="server" Visible="False"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                     <%--<tr>
                                        <td colspan="2" class="txt02">
                                            Insurance Detail
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>--%>
                                    <tr>
                                    <td colspan="2"> 
                                      <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td valign="top" width="50%">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123" width="40%">
                                                                    Policy Name
                                                                </td>
                                                                <td class="frm-rght-clr123" width="60%">
                                                                    <asp:TextBox ID="TxtPolicyName" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="height: 5px">
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td class="frm-lft-clr123">
                                                                  Customer ID
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="TxtCustID" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td class="frm-lft-clr123">
                                                                    Policy Limit
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="TxtPolicyLimit"  onkeyup="checkNumericValueForCntrl(this)" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table align="right" border="0" cellpadding="0" cellspacing="0" width="99%">
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123" width="40%">
                                                                    Company Name
                                                                </td>
                                                                <td class="frm-rght-clr123" width="60%">
                                                                    <asp:TextBox ID="TxtInsurance" runat="server" CssClass="blue1" Width="142px" MaxLength="100"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123" width="40%">
                                                                    Valid From 
                                                                </td>
                                                                <td class="frm-rght-clr123" width="60%">
                                                                    <asp:TextBox ID="TxtValidFrm" runat="server" CssClass="blue1" Width="100px" ContentEditable="False"></asp:TextBox>
                                                                   &nbsp;&nbsp; <asp:Image ID="Image4" runat="server" ImageUrl="../../images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="Image4"
                                                                        TargetControlID="TxtValidFrm" Enabled="True" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td >
                                                                   
                                                                </td>
                                                                <td >
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="txt02">
                                            Approval Hierarchy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td class="frm-lft-clr123" width="30%">
                                                        Reporting Manager 1 <span style="color: Red">*</span>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="70%">
                                                        <asp:TextBox ID="Ttxtunderwriter" runat="server" ClientIDMode="Static" CssClass="blue1" Width="100px"></asp:TextBox><div
                                                            id="pick1" runat="server">
                                                            <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=Ttxtunderwriter');" class="link05">Pick Employee</a>
                                                        </div>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;
                                                        <asp:Button ID="Btn_app_underwriter" runat="server" Text="Add" CssClass="button"
                                                            ToolTip="Click here to add Underwriter" OnClick="Btn_app_underwriter_Click">
                                                        </asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:GridView ID="Grid_approval" runat="server" Width="100%" CellPadding="4" OnRowDeleting="Grid_approval_RowDeleting"
                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="approverid"
                                                            HorizontalAlign="Left" BorderWidth="0px">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Approver Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("approverid") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approver Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable12" runat="server" Text='<%# Eval("approvername") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Category">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable13" runat="server" Text='<%# Eval("category") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="Business Unit">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable14" runat="server" Text='<%# Eval("BU") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Designation">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable15" runat="server" Text='<%# Eval("designation") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approval Level ">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("approverpriority") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04"
                                                                            Text="Delete"></asp:LinkButton></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                       Reporting Manager 2 <%--<span style="color: Red">*</span>--%>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="Txt_rep_underwriter" runat="server"  ClientIDMode="Static" CssClass="blue1" Width="100px"></asp:TextBox><div
                                                            id="pick2" runat="server">&nbsp;&nbsp; <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=Txt_rep_underwriter');" class="link05">PickEmployee</a>
                                                        </div>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;
                                                        <asp:Button ID="Btn_app_rep_underwriter" runat="server" Text="Add" CssClass="button"
                                                            ToolTip="Click here to add Reporting Underwriter" OnClick="Btn_app_rep_underwriter_Click">
                                                        </asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:GridView ID="Grid_rep_approval" runat="server" Width="100%" CellPadding="4"
                                                            OnRowDeleting="Grid_rep_approval_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
                                                            CaptionAlign="Left" DataKeyNames="approverid" HorizontalAlign="Left" 
                                                            BorderWidth="0px" >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Approver Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label11" runat="Server" Text='<%# Eval("approverid") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approver Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable12" runat="server" Text='<%# Eval("approvername") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Category">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable13" runat="server" Text='<%# Eval("category") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                             <%--   <asp:TemplateField HeaderText="Business Unit">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable14" runat="server" Text='<%# Eval("BU") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Designation">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lable15" runat="server" Text='<%# Eval("designation") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approval Level ">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label12" runat="Server" Text='<%# Eval("approverpriority") %>'></asp:Label></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04"
                                                                            Text="Delete"></asp:LinkButton></ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="txt02">
                                            Payroll Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="50%" valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="36%">
                                                                    ESI Number
                                                                </td>
                                                                <td class="frm-rght-clr123" width="64%">
                                                                    <asp:TextBox ID="esino" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="height: 5px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    PF Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="pfno" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    PAN Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="panno" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="36%" class="frm-lft-clr123">
                                                                    ESI Dispensary
                                                                </td>
                                                                <td width="64%" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="esidesp" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="36%">
                                                                    PF Account Number
                                                                </td>
                                                                <td class="frm-rght-clr123" width="64%">
                                                                    <asp:TextBox ID="pfno_dept" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Ward/Circle
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="ward" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="2">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Professional">
                        <HeaderTemplate>
                            Professional
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="frm-lft-clr-main">
                                            Educational Qualification :
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 1px;">
                                            <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                <ContentTemplate>
                                                    <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                        width="100%" border="1">
                                                        <tr>
                                                            <td class="td-head" width="21%">
                                                                Education<span style="color: Red">*</span>
                                                            </td>
                                                            <td class="td-head" width="43%">
                                                                School / Institute / University Name<span style="color: Red">*</span>
                                                            </td>
                                                            <td class="td-head" width="13%">
                                                                Grade / %
                                                            </td>
                                                            <td class="td-head" width="23%">
                                                                Year&#160;&#160;&#160;&#160;&#160;&#160;&#160; &#160;
                                                                <asp:Button ID="btn_quali_add" OnClick="btn_quali_add_Click" runat="server" Text="Add"
                                                                    CssClass="button" ToolTip="Click here to add Educational Qualification" ValidationGroup="acc_edu">
                                                                </asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 150px" class="frm-rght-clr12345">
                                                           <%-- <asp:TextBox ID="txtedu_qualification" runat="server" CssClass="blue1" Height="20px" Width="120px"></asp:TextBox>--%>
                                                               <asp:DropDownList ID="drp_edu_qualification" runat="server" CssClass="blue1" Height="20px" Width="120px"></asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator9" runat="server" ValidationGroup="acc_edu"
                                                                    ValueToCompare="0" Operator="NotEqual" ControlToValidate="drp_edu_qualification"
                                                                    ErrorMessage="Select Education"></asp:CompareValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtedush" runat="server" CssClass="blue1" Width="175px" MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="rfvprofedu" runat="server" ControlToValidate="txtedush" Display="Dynamic"
                                                                    SetFocusOnError="True" ToolTip="Enter School / Institute / University Name" ValidationGroup="acc_edu"
                                                                    Width="6px" ErrorMessage="Enter School / Institute / University Name">
                                                                   </asp:RequiredFieldValidator>&nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txteduper" runat="server" CssClass="blue1" Width="60px" MaxLength="2"
                                                                onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtedufrom" runat="server" CssClass="blue1" Width="40px" MaxLength="4"
                                                                    onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox> &nbsp;to
                                                                <asp:TextBox ID="txteduto" runat="server" CssClass="blue1" Width="40px" MaxLength="4"
                                                                   onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>&nbsp;
                                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtedufrom"
                                                                    ControlToValidate="txteduto" ErrorMessage="Education to must be greater than to Education From"
                                                                    Operator="GreaterThanEqual" ValidationGroup="acc_edu" Display="None"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                            <div id="education" runat="server">
                                                                 <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4"
                                                                    OnRowDeleting="grid_edu_education_RowDeleting" OnRowDataBound="grid_edu_education_OnRowDataBound" 
                                                                    OnPageIndexChanging="grid_edu_education_OnPageIndexChanging" OnRowCancelingEdit="grid_edu_education_OnRowCancelingEdit" 
                                                                    OnRowEditing="grid_edu_education_OnRowEditing" OnRowUpdating="grid_edu_education_OnRowUpdating"
                                                                    AutoGenerateColumns="False" AllowSorting="True"
                                                                    CaptionAlign="Left" DataKeyNames="id" HorizontalAlign="Left" BorderStyle="Solid"
                                                                    BorderWidth="0px" EmptyDataText="no data found">
                                                                    <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Education">
                                                                            <ItemTemplate>
                                                                             <asp:Label ID="lblID" Visible="false" runat="Server" Text='<%# Eval("id") %>'></asp:Label>
                                                                            <asp:Label ID="Lbl_Education" runat="server" Text='<%# Bind("education") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                               <EditItemTemplate>
                                                                               <asp:TextBox ID="DrpEducation" runat="server" CssClass="blue1" Width="120px" Text='<%# Bind("education") %>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="School ">
                                                                            <ItemTemplate>
                                                                            <asp:Label ID="Lblschool" runat="server" Text='<%# Bind("school") %>'></asp:Label>
                                                                               </ItemTemplate>
                                                                               <EditItemTemplate>
                                                                               <asp:TextBox ID="TxtSchool" runat="server" CssClass="blue1" Width="175px" Text='<%# Bind("school") %>'></asp:TextBox>
                                                                               </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="43%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Grade / %">
                                                                            <ItemTemplate>
                                                                            <asp:Label ID="LblPercentage" runat="server" Text='<%# Bind("percentage") %>'></asp:Label>
                                                                               </ItemTemplate>
                                                                               <EditItemTemplate>
                                                                               <asp:TextBox ID="txtGrade" runat="server" CssClass="blue1" Width="60px" Text='<%# Bind("percentage") %>'></asp:TextBox>
                                                                               </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="13%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Year">
                                                                            <ItemTemplate>
                                                                            <asp:Label ID="Lblfrom" runat="server" Text='<%# Bind("from_year") %>'></asp:Label> -
                                                                            <asp:Label ID="LblTo" runat="server" Text='<%# Bind("to_year") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="Txtfrom" runat="server" CssClass="blue1" Width="40px" Text='<%# Bind("from_year") %>'></asp:TextBox>
                                                                            <asp:TextBox ID="txtto" runat="server" CssClass="blue1" Width="40px" Text='<%# Bind("to_year") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="13%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                        <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                               <%-- |
                                                <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                CssClass="link05" Text="Cancel" ToolTip="Cancel" />--%>
                                                                        </EditItemTemplate>
                                                                            <ItemTemplate>
                                                                             <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                CssClass="link04" Text="Edit |" ToolTip="Edit" />
                                                
                                                                                <asp:LinkButton ID="lnkbtndelete" runat="server" CommandName="Delete" CssClass="link04"  CausesValidation="false" 
                                                                                OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                                                    Text="Delete"></asp:LinkButton></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                    </HeaderStyle>
                                                                    <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="acc_edu" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr-main">
                                            Professional Qualification :
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 1px;">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                        width="100%" border="1">
                                                        <tr>
                                                            <td class="td-head" width="21%">
                                                                Education<span style="color: Red">*</span>
                                                            </td>
                                                            <td class="td-head" width="43%">
                                                                Institute / University Name<span style="color: Red">*</span>
                                                            </td>
                                                            <td class="td-head" width="13%">
                                                                Grade / %
                                                            </td>
                                                            <td class="td-head" width="23%">
                                                               Month &nbsp;&nbsp; Year &#160; &#160; &#160; &#160; &#160;
                                                                <asp:Button ID="btn_pro_qual_add" OnClick="btn_pro_qual_add_Click" runat="server"
                                                                    Text="Add" CssClass="button" ToolTip="Click here to add Professional Qualification"
                                                                    ValidationGroup="pro_edu"></asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txteduc1" runat="server" CssClass="blue1" Width="110px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="Requfdsfsd" runat="server" Width="6px" ToolTip="Enter Education" ValidationGroup="pro_edu"
                                                                    ControlToValidate="txteduc1" SetFocusOnError="True" Display="Dynamic" ErrorMessage="Enter Education"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 189px">
                                                                <asp:TextBox ID="txtsch1" runat="server" CssClass="blue1" Width="175px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredfdfFieldValidator7" runat="server" Width="6px" ToolTip="Enter School / Institute / University Name"
                                                                    ValidationGroup="pro_edu" ControlToValidate="txtsch1" SetFocusOnError="True"
                                                                    Display="Dynamic" ErrorMessage="Enter School / Institute / University Name">
                                                                    </asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtper1" runat="server" CssClass="blue1" Width="60px" MaxLength="2"
                                                                   onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            <asp:DropDownList ID="ddlMonthfrom" CssClass="select" runat="server" Width="50PX">
                                                             <asp:ListItem Text="Jan" Value="Jan" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                                                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                                                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                                                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                                                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                                             </asp:DropDownList>
                                                                <asp:TextBox ID="txtfrm1" runat="server" CssClass="blue1" Width="30px" MaxLength="4"
                                                                  onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>&nbsp;to
                                                             <asp:DropDownList ID="ddlMonthto" CssClass="select" runat="server" Width="50PX">
                                                              <asp:ListItem Text="Jan" Value="Jan" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                                                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                                                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                                                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                                                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                                             </asp:DropDownList>
                                                                <asp:TextBox ID="txtto1" runat="server" CssClass="blue1" Width="30px" MaxLength="4"
                                                                onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox><asp:CompareValidator ID="CompareValidator5"
                                                                        runat="server" ControlToCompare="txtfrm1" Display="None" ControlToValidate="txtto1"
                                                                        ErrorMessage="Education to must be greater than to Education From" Operator="GreaterThanEqual"
                                                                        ValidationGroup="pro_edu"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" OnRowDeleting="grid_Pro_education_RowDeleting"
                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="id"
                                                                    HorizontalAlign="Left" CellPadding="4" BorderStyle="Solid" BorderWidth="0px"
                                                                    EmptyDataText="no data found" OnRowCancelingEdit="grid_Pro_education_RowCancelingEdit" 
                                                                    OnRowDataBound="grid_Pro_education_RowDataBound" OnPageIndexChanging="grid_Pro_education_PageIndexChanging" 
                                                                    OnRowEditing="grid_Pro_education_RowEditing" OnRowUpdating="grid_Pro_education_RowUpdating" >
                                                                    <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Education">
                                                                            <ItemTemplate>
                                                                                <headerstyle width="15%" horizontalalign="Left" />
                                                                                <itemstyle width="15%" horizontalalign="Left" />
                                                                                 <asp:Label ID="lblID" Visible="false" runat="Server" Text='<%# Eval("id") %>'></asp:Label>
                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label></ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                <asp:TextBox ID="TxtProEducation" runat="server" Width="110px" Text='<%# Eval("education") %>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Institute / University Name ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label></ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                <asp:TextBox ID="TxtUniName" runat="server" Width="175px" Text='<%# Eval("school") %>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="35%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Grade / %">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label43" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label></ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                <asp:TextBox ID="txPer" runat="server" Width="60px" Text='<%# Eval("percentage") %>'></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="13%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Month     Year">
                                                                            <ItemTemplate>
                                                                            <asp:Label ID="Lbl_month" runat="server" Text='<%# Eval("month_from") %>'></asp:Label>
                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label> -
                                                                                <asp:Label ID="Lbl_monthto" runat="server" Text='<%# Eval("month_to") %>'></asp:Label>
                                                                                <asp:Label
                                                                                    ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                   <asp:DropDownList ID="DropMonthfrom" runat="server">
                                                                                   <asp:ListItem Text="Jan" Value="Jan" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                                                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                                                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                                                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                                                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                                                                   </asp:DropDownList>
                                                                                   <asp:TextBox ID="TxtyearFrom" runat="server" Text='<%# Eval("from_year") %>' Width="40px"></asp:TextBox> - 
                                                                                   <asp:DropDownList ID="DropMonthto" runat="server">
                                                                                   <asp:ListItem Text="Jan" Value="Jan" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="Feb" Value="Feb"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mar" Value="Mar"></asp:ListItem>
                                                                                    <asp:ListItem Text="Apr" Value="Apr"></asp:ListItem>
                                                                                    <asp:ListItem Text="May" Value="May"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jun" Value="Jun"></asp:ListItem>
                                                                                    <asp:ListItem Text="Jul" Value="Jul"></asp:ListItem>
                                                                                    <asp:ListItem Text="Aug" Value="Aug"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sep" Value="Sep"></asp:ListItem>
                                                                                    <asp:ListItem Text="Oct" Value="Oct"></asp:ListItem>
                                                                                    <asp:ListItem Text="Nov" Value="Nov"></asp:ListItem>
                                                                                    <asp:ListItem Text="Dec" Value="Dec"></asp:ListItem>
                                                                                   </asp:DropDownList>
                                                                                   <asp:TextBox ID="Txtyearto" runat="server" Text='<%# Eval("to_year") %>' Width="40px"></asp:TextBox>
                                                                                    </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="20%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                CssClass="link04" Text="Edit  |" ToolTip="Edit" />
                                                
                                                                                <asp:LinkButton CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete"
                                                                                    Text="Delete"></asp:LinkButton></ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                                                    </EditItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                    </HeaderStyle>
                                                                    <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="pro_edu" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr-main">
                                            Experience Details :
                                            <asp:CheckBox ID="ChkExp" runat="server" Text="Current Company" OnCheckedChanged="ChkExp_CheckedChanged"
                                            AutoPostBack="True"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left: 1px;">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                        width="100%" border="1">
                                                        <tr>
                                                            <td class="td-head" width="20%">
                                                                Company Name<span style="color: Red">*</span>
                                                            </td>
                                                           
                                                            <td class="td-head" width="20%">
                                                                Location<span style="color: Red">*</span>
                                                            </td>
                                                             <td class="td-head" width="20%">
                                                            Designation
                                                            </td>
                                                            <td class="td-head" width="10%">
                                                               From
                                                            </td>
                                                            <td class="td-head" width="10%">
                                                               To  
                                                               </td>
                                                             <td class="td-head" width="10%">
                                                               <asp:Button ID="Button1" OnClick="btn_exp_add_Click" runat="server" Text="Add"
                                                                    CssClass="button" ValidationGroup="Exp" Height="19px"></asp:Button>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txtcomp1" runat="server" CssClass="blue1" Width="125px" MaxLength="100"></asp:TextBox>
                                                                <asp:RequiredFieldValidator
                                                                    ID="Requfdsfsddd" runat="server" Width="6px" ToolTip="Enter Company name" ErrorMessage="Enter Company name"
                                                                    ValidationGroup="Exp" ControlToValidate="txtcomp1" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                            
                                                            <td>
                                                                <asp:TextBox ID="txt_com_local" runat="server" CssClass="blue1" Width="125px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator7" runat="server" Width="6px" ToolTip="Enter Company location"
                                                                    ValidationGroup="Exp" ControlToValidate="txt_com_local" ErrorMessage="Enter Company location"
                                                                    SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                            <asp:TextBox ID="Txtdesg" runat="server" CssClass="blue1" Width="125px" MaxLength="50"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            <asp:TextBox ID="txt_from_exp" runat="server" CssClass="blue1" Width="60px"></asp:TextBox>
                                                              &nbsp;&nbsp; <asp:Image ID="Image10" runat="server" ImageUrl="../../images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image10"
                                                                        TargetControlID="txt_from_exp" Enabled="True" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                            </td>
                                                            <td colspan="2">
                                                            <div id="divTodate" runat="server">
                                                            <asp:TextBox ID="txt_to_exp" runat="server" CssClass="blue1" Width="60px"></asp:TextBox>
                                                             &nbsp;&nbsp; <asp:Image ID="Image12" runat="server" ImageUrl="../../images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12"
                                                                        TargetControlID="txt_to_exp" Enabled="True" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                                    </div>
                                                            </td>
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6">
                                                                <asp:GridView ID="grid_exp" runat="Server" Width="100%" OnRowDeleting="grid_exp_RowDeleting"
                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="id"
                                                                    HorizontalAlign="Left" CellPadding="4" BorderStyle="Solid" BorderWidth="0px"
                                                                    EmptyDataText="no data found" OnRowCancelingEdit="grid_exp_RowCancelingEdit" 
                                                                    OnRowDataBound="grid_exp_RowDataBound" OnPageIndexChanging="grid_exp_PageIndexChanging" 
                                                                    OnRowEditing="grid_exp_RowEditing" OnRowUpdating="grid_exp_RowUpdating">
                                                                    <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="company Name">
                                                                            <ItemTemplate>
                                                                                <headerstyle horizontalalign="Left" />
                                                                                 <asp:Label ID="lblID" Visible="false" runat="Server" Text='<%# Eval("id") %>'></asp:Label>
                                                                                <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="TxtCompany" runat="server" Text='<%# Eval("comp_name") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Address / Location ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="TxtLocation" runat="server" Text='<%# Eval("location") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                       <asp:TemplateField HeaderText="Designation ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblDesg" runat="Server" Text='<%# Eval("Designation") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="TxtDesg" runat="server" Text='<%# Eval("Designation") %>'></asp:TextBox>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="From ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Labewdl43" runat="Server" Text='<%# Eval("datefrom") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="txtFromdate" runat="server" Text='<%# Eval("datefrom") %>'></asp:TextBox>
                                                                            &nbsp;&nbsp; <asp:Image ID="Image12" runat="server" ImageUrl="../../images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender13" runat="server" PopupButtonID="Image12"
                                                                        TargetControlID="txtFromdate" Enabled="True" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="To">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("dateto") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="TxtTodate" runat="server" Text='<%# Eval("dateto") %>'></asp:TextBox>
                                                                             &nbsp;&nbsp; <asp:Image ID="Image13" runat="server" ImageUrl="../../images/clndr.gif" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender14" runat="server" PopupButtonID="Image13"
                                                                        TargetControlID="TxtTodate" Enabled="True" Format="dd-MMM-yyyy">
                                                                    </cc1:CalendarExtender>
                                                                            </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Duration">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblDuration" runat="Server" Text='<%# Eval("duration") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                CssClass="link04" Text="Edit  |" ToolTip="Edit" />
                                                                                <asp:LinkButton CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete"
                                                                                    Text="Delete"></asp:LinkButton></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <EditItemTemplate>
                                                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                                                    </EditItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                    </HeaderStyle>
                                                                    <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <td colspan="4" align="right" class="td-head">
                                                        <asp:Label ID="Lbltotal" runat="server" Text="Total Experience"></asp:Label>
                                                        </td>
                                                        <td colspan="2">
                                                        <asp:Label ID="Txttotal" runat="server" ></asp:Label>
                                                        </td>
                                                        </tr>
                                                    </table>
                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="Exp" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Personal Detail">
                        <HeaderTemplate>
                            Personal Detail
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txt02" colspan="2">
                                                    Personal Information
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" colspan="2">
                                                    <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" width="50%">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Date of Birth<span style="color: Red">*</span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txt_DOB" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&nbsp;
                                                                            <asp:Image ID="Image1" runat="server" ToolTip="click to open calender" ImageUrl="../../images/clndr.gif">
                                                                            </asp:Image><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dob"
                                                                                PopupButtonID="Image1" Format="dd-MMM-yyyy">
                                                                            </cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Payment Mode
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:RadioButton ID="rbtnbank" runat="server" AutoPostBack="true" Checked="true"
                                                                                Text="Bank" GroupName="paymentmode" OnCheckedChanged="rbtnbank_CheckedChanged" /><asp:RadioButton
                                                                                    ID="rbtncheque" runat="server" AutoPostBack="true" Checked="false" Text="Cheque"
                                                                                    GroupName="paymentmode" OnCheckedChanged="rbtncheque_CheckedChanged" /><asp:RadioButton
                                                                                        ID="rbtncash" runat="server" AutoPostBack="true" Checked="false" Text="Cash"
                                                                                        GroupName="paymentmode" OnCheckedChanged="rbtncash_CheckedChanged" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top">
                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Religion
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txtrelg" runat="server" CssClass="blue1" Width="142px" MaxLength="10"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                           Name in Bank
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_dl_no" runat="server" CssClass="blue1" Width="142px" 
                                                                                MaxLength="20"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
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
                                                    <div id="paymentmode" runat="server" visible="true" align="center">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="left" class="frm-lft-clr123" width="18%">
                                                                    Bank Name for Salary
                                                                </td>
                                                                <td align="left" class="frm-rght-clr123" width="32%">
                                                                    <asp:DropDownList ID="ddl_bank_name" runat="server" CssClass="blue1" Width="146px" Height="20px">
                                                                    </asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddl_bank_name"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Employee Bank Name"
                                                                        ErrorMessage="Please Select Employee Bank Name" ValidationGroup="v" Width="6px"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td>
                                                                    &#160;&nbsp;
                                                                </td>
                                                                <td align="left" class="frm-lft-clr123" width="18%">
                                                                    Account No for Salary
                                                                </td>
                                                                <td align="left" class="frm-rght-clr123" width="32%">
                                                                    <asp:TextBox ID="txt_bank_ac" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_bank_ac" Display="Dynamic"
                                                                        SetFocusOnError="True" ToolTip="Employee Account Number for Salary" ErrorMessage="Please Enter Employee Account Number for Salary"
                                                                        ValidationGroup="v" Width="6px"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="frm-lft-clr123">
                                                                    Bank Name for Reimbursement
                                                                </td>
                                                                <td align="left" class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_bank_name_reimbursement" runat="server" CssClass="blue1"
                                                                        Width="146px" Height="20px">
                                                                    </asp:DropDownList>
                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="ddl_bank_name_reimbursement"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Employee Bank Name"
                                                                        ErrorMessage="Please Select Employee Bank Name for reimbursement" ValidationGroup="v"
                                                                        Width="6px"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td>
                                                                    &#160;&nbsp;
                                                                </td>
                                                                <td align="left" class="frm-lft-clr123">
                                                                    Account No for Reimbursement
                                                                </td>
                                                                <td align="left" class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_bank_ac_reimbursement" runat="server" CssClass="blue1" Width="142px"
                                                                        MaxLength="20"></asp:TextBox>
                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13"
                                                                            runat="server" ControlToValidate="txt_bank_ac_reimbursement" Display="Dynamic"
                                                                            SetFocusOnError="True" ToolTip="Employee Account Number for Reimbursement" ErrorMessage="Please Enter Employee Account Number for reimbursement"
                                                                            ValidationGroup="v" Width="6px"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" height="5">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top" colspan="2">
                                                    <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" width="50%">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                   <%-- <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Mobile No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txtmobileno" runat="server" CssClass="blue1" Width="142px"  onkeyup="checkNumericValueForCntrl(this)"
                                                                                MaxLength="10"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                <td class="frm-lft-clr123">
                                                                  Aadhaar Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txtaadharnumber" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                              <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Blood Group
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                           <asp:DropDownList ID="drpBloodGroup" runat="server" Width="146px" CssClass="blue1" Height="20px">
                                                                           <asp:ListItem Value="Null">--------Select-------</asp:ListItem>
                                                                           <asp:ListItem Value="A+">A+</asp:ListItem>
                                                                           <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                           <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                           <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                           <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                           <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                           <asp:ListItem Value="O+">O+</asp:ListItem>
                                                                           <asp:ListItem Value="O-">O-</asp:ListItem>
                                                                           </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 5px">
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                        Passport Expiry Date
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                         <asp:TextBox ID="TxtPassportexpdate" runat="server" CssClass="blue1" Width="100px" ></asp:TextBox>
                                                                         &nbsp; &nbsp;<asp:Image ID="Image6" runat="server" ToolTip="click to open calender" ImageUrl="../../images/clndr.gif">
                                                                            </asp:Image>
                                                                             <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="TxtPassportexpdate"
                                                                                PopupButtonID="Image6" Format="dd-MMM-yyyy">
                                                                            </cc1:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top">
                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Email Id
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txt_email" runat="server" CssClass="blue1" MaxLength="50" Width="142px"></asp:TextBox><asp:RegularExpressionValidator
                                                                                ID="RegularExpressionValidator1" runat="server" ValidationGroup="v" ToolTip="Not a Vaild Email ID"
                                                                                SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_email" ErrorMessage="Not a Vaild Email ID"
                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                           Alternate Email Id
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txtAltEmailId" runat="server" MaxLength="50" CssClass="blue1" Width="142px" ></asp:TextBox>
                                                                            <asp:RegularExpressionValidator
                                                                                ID="RegularExpressionValidator2" runat="server" ValidationGroup="v" ToolTip="Not a Vaild Email ID"
                                                                                SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtAltEmailId" ErrorMessage="Not a Vaild Email ID"
                                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Passport No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_passportno" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txt02" colspan="2" height="5">
                                                    Relationship Details
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td valign="top" width="50%">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td class="txt02" colspan="2">
                                                                            Father&apos;s Detail
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Father's Name
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txt_f_f_name" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                    
                                                                    
                                                                    <tr>
                                                                        <td class="txt02" colspan="2" height="5">
                                                                            Employee Marital Status
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Marital Status
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:DropDownList ID="ddlpersonalstatus" runat="server" CssClass="blue1" Width="146px"
                                                                                Height="20px" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                <asp:ListItem Text="Unmarried" Value="Unmarried"></asp:ListItem>
                                                                                <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                                                <asp:ListItem Text="Divorcee" Value="Divorcee"></asp:ListItem>
                                                                                <asp:ListItem>Widow</asp:ListItem>
                                                                                <asp:ListItem>Widower</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td valign="top">
                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                    <tr>
                                                                        <td style="height: 13px" class="txt02" colspan="2">
                                                                            Mother&apos;s Detail
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="36%">
                                                                            Mother's Name
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="64%">
                                                                            <asp:TextBox ID="txt_m_fname" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                   
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 12px" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td>
                                                                <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server"
                                                                    visible="false">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td valign="top" width="50%">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td style="height: 13px" class="txt02" colspan="2">
                                                                                                    Spouse Detail
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="36%">
                                                                                                     Name
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="64%">
                                                                                                    <asp:TextBox ID="txt_sp_fname" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                           <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                            Date Of Birth
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                           <asp:TextBox ID="TxtSpouseDOb" runat="server" CssClass="blue1" Width="100px" ContentEditable="false"></asp:TextBox>&nbsp;
                                                                                           <asp:Image ID="Image9" runat="server" ToolTip="click to open calender" ImageUrl="../../images/clndr.gif">
                                                                                                    </asp:Image>&nbsp;
                                                                                                    <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="TxtSpouseDOb"
                                                                                                        PopupButtonID="Image9" Format="dd-MMM-yyyy">
                                                                                                    </cc1:CalendarExtender>
                                                                                            </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                            <tr>
                                                                                                <td class="txt02" colspan="2" height="5">
                                                                                                    &#160;&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="36%">
                                                                                                    Date of Anniversary
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="64%">
                                                                                                    <asp:TextBox ID="txt_doa" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&nbsp;<asp:Image
                                                                                                        ID="Image2" runat="server" ToolTip="click to open calender" ImageUrl="../../images/clndr.gif">
                                                                                                    </asp:Image>&nbsp;
                                                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_doa"
                                                                                                        PopupButtonID="Image2" Format="dd-MMM-yyyy">
                                                                                                    </cc1:CalendarExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            </td>
                                                                            </tr>
                                                                            </table>
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td valign="top" width="50%">
                                                                                        <table id="tblCHD" runat="server" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td style="height: 18px" class="txt02" colspan="2">
                                                                                                    Children Detail
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="36%">
                                                                                                    Name<span style="color: Red">*</span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="64%">
                                                                                                    <asp:TextBox ID="txt_child_name" runat="server" MaxLength="20" CssClass="blue1" Width="142px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                        ID="Requfdgggsfsd" runat="server" Width="6px" ValidationGroup="child" ToolTip="Enter Child Name"
                                                                                                        ErrorMessage="Enter Child Name" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_child_name"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <table id="tblDOB" runat="server" cellspacing="0" cellpadding="0" width="100%" align="right" border="0">
                                                                                            <tr>
                                                                                                <td class="txt02" align="right" colspan="2" height="5">
                                                                                                    &#160;&nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 5px" colspan="2">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="36%">
                                                                                                    Date of Birth
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="64%">
                                                                                                    <asp:TextBox ID="txt_child_Dob" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&nbsp;<asp:Image
                                                                                                        ID="Image3" runat="server" ToolTip="click to open calender" ImageUrl="../../images/clndr.gif">
                                                                                                    </asp:Image>&nbsp;
                                                                                                    <asp:Button ID="btn_child_Add" OnClick="btn_child_Add_Click" runat="server" Text="Add"
                                                                                                        CssClass="button" ValidationGroup="child" ToolTip="Click hare to add children detail">
                                                                                                    </asp:Button><cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_child_Dob"
                                                                                                        PopupButtonID="Image3" Format="dd-MMM-yyyy">
                                                                                                    </cc1:CalendarExtender>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" colspan="2">
                                                                                        <asp:GridView ID="grid_child" runat="Server" Width="99%" OnRowDeleting="grid_child_RowDeleting"
                                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Child Name ">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label></ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Left" Width="150px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Date of Birth">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                    <ItemStyle Width="200px" HorizontalAlign="Left" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link04"
                                                                                                            Text="Delete"></asp:LinkButton></ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                                            </HeaderStyle>
                                                                                            <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                                        </asp:GridView>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="top" width="50%">
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:ValidationSummary ID="ValidationSummary5" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Contact Detail">
                        <HeaderTemplate>
                            Contact Detail
                        </HeaderTemplate>
                        <ContentTemplate>
                            <div>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <div>
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                            <tr>
                                                                <td style="height: 34px" colspan="2">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td style="width: 365px" height="5">
                                                                            </td>
                                                                            <td class="txt02">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 365px" class="txt02">
                                                                                Present Address
                                                                            </td>
                                                                            <td class="txt02">
                                                                                Permanent Address
                                                                                <asp:CheckBox ID="CheckBox1" runat="server" Text="same as present" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                                                    AutoPostBack="True"></asp:CheckBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="36%">
                                                                                            Address 1<span style="color: Red">*</span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="64%">
                                                                                            <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator6" runat="server" Width="6px" ValidationGroup="v" ToolTip="Enter Address 1"
                                                                                                SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_pre_add1" ErrorMessage="Enter Address 1"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="36%">
                                                                                            Address 2
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="64%">
                                                                                            <asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            City<span style="color: Red">*</span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_pre_city" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator8" runat="server" Width="6px" ValidationGroup="v" ToolTip="Enter City Name"
                                                                                                SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_pre_city" ErrorMessage="Enter City Name"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            State<span style="color: Red">*</span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_pre_state" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator9" runat="server" Width="6px" ValidationGroup="v" ToolTip="Enter State Name"
                                                                                                SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_pre_state" ErrorMessage="Enter State Name"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Country<span style="color: Red">*</span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_pre_country" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator10" runat="server" Width="6px" ValidationGroup="v"
                                                                                                ToolTip="Enter Country Name" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_pre_country"
                                                                                                ErrorMessage="Enter Country Name"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Zip Code<span style="color: Red">*</span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="blue1" Width="142px" MaxLength="6"
                                                                                                onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                                                                                                    runat="server" Width="6px" ValidationGroup="v" ToolTip="Enter Zip Code" SetFocusOnError="True"
                                                                                                    Display="Dynamic" ControlToValidate="txt_pre_zip" ErrorMessage="Enter Zip Code"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Phone No.<span style="color: Red">*</span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_pre_phone" runat="server" CssClass="blue1" Width="142px" MaxLength="10"
                                                                                                onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>
                                                                                        </td>
                                                                                         <asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator19" runat="server" Width="6px" ValidationGroup="v"
                                                                                                ToolTip="Enter Phone No" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_pre_country"
                                                                                                ErrorMessage="Enter Phone No"></asp:RequiredFieldValidator>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td class="frm-lft-clr123" width="36%">
                                                                                            Emergency Contact Person Name
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="64%">
                                                                                            <asp:TextBox ID="Txt_emr_name" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Mode of Transport
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:RadioButton ID="optown" runat="server" Text="Own" GroupName="mode" AutoPostBack="True"
                                                                                                OnCheckedChanged="optown_CheckedChanged" />|
                                                                                            <asp:RadioButton ID="optcompany" runat="server" Text="Company Vehicle" GroupName="mode"
                                                                                                AutoPostBack="True" OnCheckedChanged="optcompany_CheckedChanged" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="36%">
                                                                                            Address 1
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="64%">
                                                                                            <asp:TextBox ID="txt_per_add1" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Address 2
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_per_add2" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            City
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_per_city" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            State
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_per_state" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Country
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_per_country" runat="server" CssClass="blue1" Width="142px" MaxLength="20"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Zip Code
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_per_zip" runat="server" CssClass="blue1" Width="142px" MaxLength="6"
                                                                                               onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            Phone No.
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_per_phone" runat="server" CssClass="blue1" Width="142px" MaxLength="10"
                                                                                               onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                     <tr>
                                                                                        <td class="frm-lft-clr123" width="36%">
                                                                                            Emergency Contact Phone No.
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="64%">
                                                                                            <asp:TextBox ID="txt_emr_no" runat="server" CssClass="blue1" Width="142px" MaxLength="10"
                                                                                               onkeyup="checkNumericValueForCntrl(this)"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">
                                                                                            &#160;<asp:Label ID="lblpickuppoint" runat="server" Text="Pick Up Point"></asp:Label>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            &#160;<asp:TextBox ID="txtmodeoftransport" MaxLength="50" runat="server"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            &nbsp;&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Documents">
                        <ContentTemplate>
                            <div>
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div>
                                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txt02" align="left">
                                                                                Document Details
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txt02">
                                                                                &nbsp;&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <div id="document" runat="server">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="20%">
                                                                                                    Document Type
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="80%">
                                                                                                    <asp:DropDownList ID="ddlDocumentType" runat="server" Width="150px">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">
                                                                                                    Description
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txtDesc" TextMode="MultiLine" runat="server" MaxLength="100" Width="540px"
                                                                                                        Height="80px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">
                                                                                                    Upload
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:FileUpload ID="flUpload" runat="server" /><asp:RegularExpressionValidator ID="revImageUpload"
                                                                                                        runat="server" ControlToValidate="flUpload" Display="None" ErrorMessage="Upload PDF and Word document only."
                                                                                                        ValidationExpression="^.*\.(doc|docx|pdf)$" ValidationGroup="A"></asp:RegularExpressionValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" colspan="2">
                                                                                                    <asp:Button ID="btnAddDoc" runat="server" Text="Add" OnClick="btnAddDoc_Click" ValidationGroup="A" />
                                                                                                    <asp:Label
                                                                                                        runat="server" ID="lblMsg"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </div>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                                <asp:GridView ID="grdDocument" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                                    CellPadding="5" BorderColor="#C9DFFB" Style="border-collapse: collapse;" OnRowDeleting="grdDocument_RowDeleting"
                                                                                                    DataKeyNames="Id">
                                                                                                    <AlternatingRowStyle CssClass="clr2" />
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="Document Type">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblDocType" runat="server" Visible="false" Text=' <%#Eval("DocType")%>'> </asp:Label>
                                                                                                                <asp:Label ID="lblDocTypeName" runat="server" Text=' <%#Eval("DocTypeName")%>'> </asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Document">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblUploadedDoc" runat="server" Text='<%#Eval("UploadedDoc")%>' Visible="true"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Description">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Desc")%>' Visible="true"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Action">
                                                                                                            <ControlStyle CssClass="link01" />
                                                                                                        </asp:CommandField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <center>
                                                                                                            <span class="txt01">&nbsp;No Data Available</span></strong></center>
                                                                                                    </EmptyDataTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="head" />
                                                                                                    <RowStyle CssClass="clr2" />
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5" id="tdNew" runat="server" visible="False">
                                                                                            New Record(s)
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                                <asp:GridView ID="grdTempClass" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                                    CellPadding="5" BorderColor="#C9DFFB" Style="border-collapse: collapse;" OnRowDeleting="grdTempClass_RowDeleting"
                                                                                                    DataKeyNames="pid">
                                                                                                    <AlternatingRowStyle CssClass="clr2" />
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="Doccument Type">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblDocTypeid1" runat="server" Visible="false" Text=' <%#Eval("DocType")%>'></asp:Label>
                                                                                                                <asp:Label
                                                                                                                    ID="lblDocTypeName1" runat="server" Text=' <%#Eval("DocTypeName")%>'> </asp:Label>
                                                                                                                <asp:Label ID="lblCid" runat="server" Text=' <%#Eval("pid")%>' Visible="false"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Document">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblUploadedDoc1" runat="server" Text='<%#Eval("UploadedDoc")%>' Visible="true"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Description">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="lblDesc1" runat="server" Text='<%#Eval("Desc")%>' Visible="true"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:CommandField ShowDeleteButton="True" HeaderText="Action">
                                                                                                            <ControlStyle CssClass="link01" />
                                                                                                        </asp:CommandField>
                                                                                                    </Columns>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <center>
                                                                                                            <span class="txt01">&nbsp;No Data Available</span></strong></center>
                                                                                                    </EmptyDataTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="head" />
                                                                                                    <RowStyle CssClass="clr2" />
                                                                                                </asp:GridView>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td height="10px">
            </td>
        </tr>
        <tr>
            <td align="right" width="50%" style="height: 18px" colspan="2">
                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
           
           
                <asp:Button ID="btngeneralsubmit" runat="server" CssClass="button" OnClick="btngeneralsubmit_Click"
                    Text="Submit" ValidationGroup="v"/>
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" OnClick="btnCancel_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="A" />
    <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
    <%-- </ContentTemplate>--%>
    <%--<triggers>
            <asp:PostBackTrigger ControlID="btnAddDoc" />
        </triggers>--%>
    <%-- </asp:UpdatePanel>--%>
</asp:Content>
