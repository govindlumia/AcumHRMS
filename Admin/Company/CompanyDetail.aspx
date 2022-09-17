<%@ Page Title="Company Master" Language="C#" MasterPageFile="~/Admin/Company/CompanyMaster.master"
    AutoEventWireup="true" CodeFile="CompanyDetail.aspx.cs" Inherits="Admin_Company_CompanyDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
    <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <Triggers ><asp:PostBackTrigger ControlID="btnCreate" /></Triggers>
        <ContentTemplate>
            <div id="Homepage" runat="server">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tbody>
                        <tr>
                            <td class="blue-brdr-1">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td class="txt01">
                                            <img alt="" src="../../images/header-icon.png" />
                                            Company Master
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10" align="right">
                                <asp:LinkButton ID="lnkCreate" CssClass="link02" runat="server" OnClick="lnkCreate_Click">Create New</asp:LinkButton>
                                <asp:LinkButton ID="lnkView" CssClass="link02" runat="server" OnClick="lnkView_Click">View</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="createCompany" runat="server" style="display: block;">
                                    <div style="overflow: scroll; height: 850px;">
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tbody>
                                                <tr>
                                                    <td height="5">
                                                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="20%">
                                                                        Company Name
                                                                        <span style="color:Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="29%">
                                                                        <asp:TextBox ID="txtcmpname" runat="server" MaxLength="50" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcmpname"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Company Name" ValidationGroup="c"
                                                                            Width="6px" ErrorMessage="Enter Company Name"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td width="2%" rowspan="14">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="20%">
                                                                        Company Code
                                                                      <%--  <span style="color:Red">*</span>--%>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="29%">
                                                                        <asp:TextBox ID="txtcmpycode" runat="server" CssClass="blue1" Width="142px" MaxLength="6"></asp:TextBox>
                                                                         <asp:Label ID="LBLCompanyCode" runat="server"></asp:Label>
                                                                              <%--<asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtcmpycode"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Company Code" ValidationGroup="c"
                                                                            Width="6px" ErrorMessage="Enter Company Code"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Company Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:DropDownList ID="drp_type" runat="server" CssClass="blue1" Width="145px" Height="20px">
                                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                                            <asp:ListItem Value="1">Manufacturing</asp:ListItem>
                                                                            <asp:ListItem Value="2">IT</asp:ListItem>
                                                                            <asp:ListItem Value="3">Others</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td class="frm-lft-clr123">
                                                                        PAN Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_pan" runat="server" CssClass="blue1" MaxLength="10" Width="142px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        TIN Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txttin" runat="server" MaxLength="20" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-lft-clr123">
                                                                        Registration Number
                                                                   <%--<span style="color:Red">*</span>--%>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txtregno" runat="server" MaxLength="50" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtregno"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Registration Number" ValidationGroup="c"
                                                                            Width="6px" ErrorMessage="Enter Registration Number"></asp:RequiredFieldValidator>--%>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        TAN Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_tanno" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-lft-clr123">
                                                                        TDS Circle
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_tds" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Company PF Trust
                                                                        <span style="color:Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:DropDownList ID="drp_pftrust" runat="server" CssClass="blue1" Width="145px"
                                                                            Height="20px">
                                                                            <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drp_pftrust"
                                                                            ErrorMessage="Enter Company PF Trust" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                                            ToolTip="Select PF"></asp:CompareValidator>
                                                                    </td>
                                                                    <td class="frm-lft-clr123">
                                                                        Company Engaged
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_comp_eng" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Responsible Person
                                                                        <span style="color:Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_resppers" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_resppers"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Responsible Person" ValidationGroup="c"
                                                                            Width="6px" ErrorMessage="Enter Responsible Person"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                    <td class="frm-lft-clr123">
                                                                        Company URL
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txtcmpurl" runat="server" MaxLength="50" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Establishment Date
                                                                        <span style="color:Red">*</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="4">
                                                                        <asp:TextBox ID="txt_est_date" runat="server" CssClass="blue1" Width="130px"></asp:TextBox>
                                                                        <asp:Image ID="Image1" runat="server" ImageUrl="../../images/clndr.gif" ToolTip="click to open calendar" />
                                                                        <Ajax:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                            TargetControlID="txt_est_date" Format="dd-MMM-yyyy">
                                                                        </Ajax:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_est_date"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Establishment Date" ValidationGroup="c"
                                                                            Width="6px" ErrorMessage="Enter Establishment Date"></asp:RequiredFieldValidator>
                                                                    </td>                                                                
                                                                </tr>
                                                                 <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Logo Image
                                                                </td>
                                                                <td>
                                                                 <img style="border: white 1px solid;" src='' runat="server" id="Imgedit" width="70"
                                                                  height="80" alt="" />
                                                              </td>
                                                              <td class="frm-rght-clr123" width="29%" colspan="3">
                                                                          <asp:FileUpload ID="FileUpload2" runat="server" />
                                                                             <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                    </td>
                                                            </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5">
                                                    </td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txt02" height="20" valign="top">
                                                                    PF Details
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="20%">
                                                                                Company PF No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="29%">
                                                                                <asp:TextBox ID="txt_epfno" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                            <td width="2%" rowspan="3">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="frm-lft-clr123" width="20%">
                                                                                DBF File Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="29%">
                                                                                <asp:TextBox ID="txt_dbffile" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Extension
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_fileext" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="8">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txt02" height="20" valign="top">
                                                                    ESI Details
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="20%">
                                                                                Company ESI No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="29%">
                                                                                <asp:TextBox ID="txt_esino" runat="server" MaxLength="20" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                            <td width="2%" rowspan="3">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="frm-lft-clr123" width="20%">
                                                                                ESI Local No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="29%">
                                                                                <asp:TextBox ID="txt_esilocalno" runat="server" MaxLength="20" CssClass="blue1" Width="142px"></asp:TextBox>
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
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="txt02" width="48%">
                                                                    Corporate Address
                                                                </td>
                                                                <td class="txt02" width="52%">
                                                                    Correspondance Address Same as Corporate Address<asp:CheckBox ID="check1" runat="server" AutoPostBack="True" Font-Bold="True" OnCheckedChanged="check1_CheckedChanged" /> <%--Text="Same as Corporate Address"--%>                                                                  
                                                                    </asp:CheckBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="20%">
                                                                                Address 1
                                                                                <span style="color:Red">*</span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="29%">
                                                                                <asp:TextBox ID="txt_pre_add1" runat="server" MaxLength="50" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pre_add1"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address 1" ValidationGroup="c"
                                                                                    Width="6px" ErrorMessage="Enter Corporate Address 1"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td width="2%" rowspan="13">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="frm-lft-clr123" width="20%">
                                                                                Address 1
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="29%">
                                                                                <asp:TextBox ID="txt_per_add1" runat="server" MaxLength="50" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Address 2
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_pre_Add2" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="frm-lft-clr123">
                                                                                Address 2
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_per_add2" MaxLength="50" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                City    
                                                                                <span style="color:Red">*</span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_pre_city" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_pre_city"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter City Name" ValidationGroup="c"
                                                                                    Width="6px" ErrorMessage="Enter City Name"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td class="frm-lft-clr123">
                                                                                City
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_per_city" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                State
                                                                                 <span style="color:Red">*</span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_pre_state"  MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_pre_state"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter State Name" ValidationGroup="c"
                                                                                    Width="6px" ErrorMessage="Enter State Name"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td class="frm-lft-clr123">
                                                                                State
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_per_state" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Country
                                                                                 <span style="color:Red">*</span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_pre_country" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_pre_country"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Country Name" ValidationGroup="c"
                                                                                    Width="6px" ErrorMessage="Enter Country Name" ></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td class="frm-lft-clr123">
                                                                                Country
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_per_country" MaxLength="20" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Pin Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_pre_zip" MaxLength="6" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                               
                                                                            </td>
                                                                            <td class="frm-lft-clr123">
                                                                                Pin Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_per_zip"  MaxLength="6" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Phone No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_pre_phone"  MaxLength="10" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                            <td class="frm-lft-clr123">
                                                                                Phone No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_per_phone"  MaxLength="10" runat="server" CssClass="blue1" Width="142px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="20%">
                                                                    Mandatory Fields ( <span style="color:Red">*</span>)
                                                                </td>
                                                                </tr>
                                                            <tr>
                                                                <td width="40%" align="right">
                                                                    <div id="edit" runat="server">
                                                                        <asp:Button ID="BtnSave" OnClick="BtnSave_Click" runat="server" Text="Save" CssClass="button" width="11%"
                                                                            ValidationGroup="c"/>&nbsp;
                                                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" width="11%" OnClick="btn_reset_Click" />&nbsp;
                                                                        <asp:Button ID="Button1" runat="server" CssClass="button" Text="Cancel" width="11%" OnClick="Button1_Click" />
                                                                    </div>
                                                                </td>
                                                                </tr>
                                                            <tr>
                                                                <td align="right" width="10%">
                                                                    <div id="create" runat="server">
                                                                        <asp:Button ID="btnCreate" runat="server" Text="Create" width="11%" CssClass="button" ValidationGroup="c"
                                                                          OnClick="btnCreate_Click1"></asp:Button>&nbsp;
                                                                        <asp:Button ID="BTNCancel" runat="server" CssClass="button" width="11%" Text="Cancel" OnClick="BTNCancel_Click"></asp:Button>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="7">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="view_Company" runat="server" style="overflow: scroll; height: 800px; display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tbody>
                                            <tr>
                                                <td height="5" valign="top">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="20%">
                                                                    Company Name
                                                                </td>
                                                                <td class="frm-rght-clr123" width="29%">
                                                                    <asp:Label ID="LblCmpyName" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                                <td width="2%" rowspan="12">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123" width="20%">
                                                                    Company Code
                                                                </td>
                                                                <td class="frm-rght-clr123" width="29%">
                                                                    <asp:Label ID="LblcmpyCode" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Company Type
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblCmpyType" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    PAN Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblPanNo" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    TIN Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblTinNo" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Registration Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblRegNo" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    TAN Number
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblTanNo" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    TDS Circle
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblTdsCircle" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Company PF Trust
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblPfTrust" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Company Engaged
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblCmpyEng" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Responsible Person
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblResPer" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    Company URL
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="LblCmpyUrl" runat="server"></asp:Label>&nbsp;
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Logo
                                                                </td>
                                                                <td colspan="4">
                                                                 <img style="border: white 1px solid;" src='' runat="server" id="imageProf" width="70"
                                                                                                                                height="80" alt="" />
                                                              </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" height="20" valign="top">
                                                                PF Details
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Company PF No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="29%">
                                                                            <asp:Label ID="LblCmpyPF" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td width="2%" rowspan="3">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            DBF File Code
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="29%">
                                                                            <asp:Label ID="LblDBFFile" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Extension
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblExtnPF" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="8">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" height="20" valign="top">
                                                                ESI Details
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Company ESI No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="29%">
                                                                            <asp:Label ID="LblCmpyEsi" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td width="2%" rowspan="3">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            ESI Local No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="29%">
                                                                            <asp:Label ID="LblEsi" runat="server"></asp:Label>&nbsp;
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
                                                <td colspan="2">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="txt02" width="48%" height="23">
                                                                Corporate Address
                                                            </td>
                                                            <td class="txt02" width="52%" height="23">
                                                                Correspondance Address Same as Above<asp:CheckBox ID="CheckBox1" runat="server" 
                                                                    AutoPostBack="True" Font-Bold="True" OnCheckedChanged="check1_CheckedChanged">
                                                                </asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Address 1
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="29%">
                                                                            <asp:Label ID="LblCorAdd1" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td rowspan="13" style="width: 2%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Address 1
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="29%">
                                                                            <asp:Label ID="LblCorrAdd1" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Address 2
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorAdd2" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Address 2
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorrAdd2" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            City
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorCity" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            City
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorrCity" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            State
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorState" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            State
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorrState" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Country
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorCountry" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Country
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorrCountry" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Pin Code
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorCode" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Pin Code
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorrCode" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Phone No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorPhone" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Phone No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="LblCorrPhone" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="right" width="80%">
                                                                <asp:Button ID="btn_cncl" runat="server" CssClass="button" Text="Cancel" OnClick="btn_cncl_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="FillGrid" runat="server" style="overflow: hidden; height: 490px; display: block;">
                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                        <tbody>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="20%">
                                                                Company Name
                                                            </td>
                                                            <td class="frm-rght-clr123" width="18%">
                                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="130px"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="20%">
                                                                Company
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="select" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="20%">
                                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" Width="80px" OnClick="btn_search_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" valign="top">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123">
                                                    <table cellpadding="0" cellspacing="0" width="99%" border="0">
                                                        <tr>
                                                            <td align="right">
                                                                <label>
                                                                    <asp:LinkButton ID="lnkPre" runat="server" CommandName="Previous" ForeColor="#013366"
                                                                        OnCommand="ChangePage" SkinID="linkGrid"><b>Previous</b></asp:LinkButton>
                                                                    &nbsp;&nbsp;|&nbsp;&nbsp;<asp:LinkButton ID="lnkNext" runat="server" CommandName="Next"
                                                                        ForeColor="#013366" OnCommand="ChangePage" SkinID="linkGrid"><b>Next</b></asp:LinkButton>
                                                                </label>
                                                            </td>
                                                            <td align="right" width="100px">
                                                                <span class="p-page">( Page -
                                                                    <asp:Label ID="lblCurrentPage" runat="server" CssClass="p-page1"></asp:Label>
                                                                    of
                                                                    <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
                                                                    ) </span>
                                                            </td>
                                                            <td align="right" width="125px">
                                                                <b>Page Size:</b>
                                                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" CssClass="select"
                                                                    EnableViewState="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
                                                                    Width="40">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="height: 3px;">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="dvResult" runat="server" style="overflow: auto; height: 490px; border: 0px #000 solid;">
                                                        <asp:GridView ID="Grid_Emp" runat="server" AllowPaging="True" AllowSorting="True" EmptyDataText="no record(s) found"
                                                            AutoGenerateColumns="False" BorderColor="#c9dffb" BorderWidth="1px" CaptionAlign="Left"
                                                            CellPadding="4" HorizontalAlign="Left" OnPageIndexChanging="Grid_Emp_PageIndexChanging"
                                                            OnRowCommand="Grid_Emp_RowCommand" OnRowDataBound="Grid_Emp_RowDataBound" OnRowEditing="Grid_Emp_RowEditing"
                                                            OnSorting="Grid_Emp_Sorting" Width="100%">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Company Name" SortExpression="companyname">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("companyname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Company Code" SortExpression="CompanyCode">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblEstDate" runat="server" Text='<%# Bind("CompanyCode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="16%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Registration No." SortExpression="reg_no">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("reg_no") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="13%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Responsible Person" SortExpression="resp_person">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("resp_person") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="18%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Address" SortExpression="address">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" Width="29%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Action" SortExpression="companyname">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Edit_btn" runat="server" class="link01" CommandArgument='<%# Eval("companyid") %>'
                                                                            CommandName="Edit" ToolTip="Edit">Edit</asp:LinkButton>
                                                                        |
                                                                        <asp:LinkButton ID="View_btn" runat="server" class="link01" CommandArgument='<%# Eval("companyid") %>'
                                                                            CommandName="View" ToolTip="View">View</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="8%" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top" />
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle />
                                                        </asp:GridView>

                                                        <asp:GridView>                                                            
                                                           
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            </td> </tr> </tbody> </table> </div>
            <div>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="middle">
                                        <img alt="" src="../../images/loading.gif" />
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
            </div>
            <asp:ValidationSummary ID="ValidationSummary6" ShowMessageBox="True" ShowSummary="False"
        runat="server" ValidationGroup="v"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
