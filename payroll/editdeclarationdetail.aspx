<%@ Page Language="C#" MasterPageFile="~/Intranet/employeemaster.master" AutoEventWireup="true"
    CodeFile="editdeclarationdetail.aspx.cs" Inherits="payroll_editdeclarationdetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cplhld1" runat="Server">
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
    <script type="text/javascript" src="../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <script type="text/javascript">
        function validate() {
            if (document.getElementById('<%=dd_metro.ClientID%>').value == "0") {
                alert("Please select city type");
                document.getElementById('<%=dd_metro.ClientID%>').focus();
                return false;
            }
        }
    </script>
    <cc1:ToolkitScriptManager ID="payroll" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <Triggers>
        <asp:PostBackTrigger ControlID="btnPdf" />
    </Triggers>

        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div id="declare">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Edit Declaration
                                    </td>
                                    <td width="70%" align="right" class="txt-red">
                                        <span id="message" runat="server"></span>&nbsp;
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
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="20%" class="frm-lft-clr123">
                                        Employee Code
                                    </td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="lbl_empcode" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Employee Name
                                    </td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="lbl_empname" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Financial Year
                                    </td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" colspan="5">
                                        House Property Details
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Own House
                                    </td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:RadioButtonList ID="rbHouse" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
                                            OnSelectedIndexChanged="rbHouse_SelectedIndexChanged">
                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <%--  <asp:RadioButton ID="opt_self_yes" runat="server" Text="Yes"  GroupName="a" />
                                        <asp:RadioButton ID="opt_self_no" runat="server" GroupName="a" Checked="True" Text="No" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Housing Loan
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:RadioButton ID="opt_loan_yes" runat="server" GroupName="b" Text="Yes" OnCheckedChanged="opt_loan_yes_CheckedChanged"
                                            AutoPostBack="true" />
                                        <asp:RadioButton ID="opt_loan_no" runat="server" GroupName="b" Text="No" AutoPostBack="True"
                                            OnCheckedChanged="opt_loan_no_CheckedChanged" />
                                    </td>
                                    <td class="frm-lft-clr123" width="20%">
                                        Interest(Rs.)
                                    </td>
                                    <td class="frm-rght-clr123" width="30%">
                                        <asp:TextBox ID="txt_houseint" size="20" CssClass="input2" runat="server" AutoPostBack="True"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator27" runat="server" ControlToValidate="txt_houseint"
                                            ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                            Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%-- :::::::::::::::::::::::::::::::::::::: Declaration Tabs ::::::::::::::::::::::::::::::::::::::::: --%>
                    <tr>
                        <td colspan="2">
                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
                                CssClass="ajax__tab_xp2">
                                <cc1:TabPanel ID="Tab_checkList" runat="server" HeaderText="Acknowledge">
                                    <ContentTemplate>
                                        <div>
                                            <table width="100%" cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                        <span class="txt02" style="float: left">Check List</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" style="border: 1px solid #c9dffb;">
                                                        <asp:GridView ID="GvCheckList" runat="server" CellPadding="4" Width="99.5%" Font-Names="Arial"
                                                            Font-Size="11px" AutoGenerateColumns="False" BorderWidth="1px" BorderStyle="Solid"
                                                            BorderColor="#C9DFFB" DataKeyNames="ID">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="SNo">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSNo" SkinID="gridLabel" runat="server" Text='<%# bind("ID") %>'></asp:Label></ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDestination" SkinID="gridLabel" runat="server" Text='<%# bind("Description") %>'></asp:Label></ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab_rent" runat="server" HeaderText="Rent Paid Details">
                                    <ContentTemplate>
                                        <div>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02">
                                                        Monthly Paid Rent
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td colspan="6">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="24%">
                                                                                City
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="76%">
                                                                                <asp:DropDownList ID="dd_metro" runat="server" CssClass="select" Width="103px" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="dd_metro_SelectedIndexChanged">
                                                                                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Delhi</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Mumbai</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Kolkata</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Chennai</asp:ListItem>
                                                                                    <asp:ListItem Value="5">Any other city</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trOtherCity" runat="server" visible="False">
                                                                            <td class="frm-lft-clr123" runat="server">
                                                                                City Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" runat="server">
                                                                                <asp:TextBox ID="txtOtherCity" CssClass="input2" runat="server"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    April
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:TextBox ID="txt_apr" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_apr"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    May
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:TextBox ID="txt_may" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_may"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    June
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:TextBox ID="txt_june" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_june"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    July
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_jul" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_jul"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    August
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_aug" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_aug"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    September
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_sep" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txt_sep"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    October
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_oct" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator9" runat="server" ControlToValidate="txt_oct"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    November
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_nov" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator10" runat="server" ControlToValidate="txt_nov"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    December
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_dec" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator11" runat="server" ControlToValidate="txt_dec"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="6">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    January
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_jan" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator12" runat="server" ControlToValidate="txt_jan"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    February
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_feb" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator13" runat="server" ControlToValidate="txt_feb"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    March
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:TextBox ID="txt_mar" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator14" runat="server" ControlToValidate="txt_mar"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="6">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab_children" runat="server" HeaderText="Children(Studying) Details">
                                    <ContentTemplate>
                                        <div>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">
                                                        No. of Children Studying
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    April
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                    <asp:TextBox ID="txt_apr2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator15" runat="server" ControlToValidate="txt_apr2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    May
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                    <asp:TextBox ID="txt_may2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator16" runat="server" ControlToValidate="txt_may2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    June
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                    <asp:TextBox ID="txt_june2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator17" runat="server" ControlToValidate="txt_june2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="9">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    July
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_jul2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator18" runat="server" ControlToValidate="txt_jul2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    August
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_aug2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator19" runat="server" ControlToValidate="txt_aug2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    September
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_sep2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator20" runat="server" ControlToValidate="txt_sep2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="9">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    October
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_oct2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator21" runat="server" ControlToValidate="txt_oct2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    November
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_nov2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator22" runat="server" ControlToValidate="txt_nov2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    December
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_dec2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator23" runat="server" ControlToValidate="txt_dec2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="9">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">
                                                                    January
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_jan2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator24" runat="server" ControlToValidate="txt_jan2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    February
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_feb2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator25" runat="server" ControlToValidate="txt_feb2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    March
                                                                </td>
                                                                <td class="frm-rght-clr123" colspan="2">
                                                                    <asp:TextBox ID="txt_mar2" runat="server" CssClass="input2" Width="100px"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator26" runat="server" ControlToValidate="txt_mar2"
                                                                        ErrorMessage="RangeValidator" MaximumValue="2" MinimumValue="0" ToolTip="Can not exceed 2"
                                                                        Type="Integer" ValidationGroup="s"><img src="../images/error1.gif" alt="Enter number" /></asp:RangeValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="9">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab_6Adetail" runat="server" HeaderText="VI-A Deduction">
                                    <ContentTemplate>
                                        <div>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02">
                                                        VI-A Deduction
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="100%" class="head-2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="25%">
                                                                    Section
                                                                </td>
                                                                <td class="frm-lft-clr123" width="30%">
                                                                    Detail
                                                                </td>
                                                                <td class="frm-lft-clr123" width="30%">
                                                                    Amount
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-rght-clr1234">
                                                                    <asp:DropDownList ID="dd_smaster" runat="server" CssClass="select1" Width="120px"
                                                                        DataSourceID="SqlDataSource1" DataTextField="sname" DataValueField="sname" AutoPostBack="True"
                                                                        AppendDataBoundItems="True">
                                                                        <asp:ListItem Value="0">Select One</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_smaster"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                                                                        ToolTip="Select Section" ValueToCompare="0" ValidationGroup="c"></asp:CompareValidator>
                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="select sname from tbl_payroll_sectionmaster" ProviderName="System.Data.SqlClient">
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-rght-clr1234">
                                                                    &nbsp;<asp:DropDownList ID="dd_sdetail" runat="server" CssClass="select1" Width="160px"
                                                                        DataSourceID="SqlDataSource2" DataTextField="section_detail" DataValueField="section_detail"
                                                                        OnDataBound="dd_sdetail_DataBound">
                                                                    </asp:DropDownList>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_sdetail"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' Operator="NotEqual"
                                                                        ToolTip="Select Section Detail" ValueToCompare="0" ValidationGroup="c"></asp:CompareValidator>
                                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                                        SelectCommand="select section_detail from tbl_payroll_sectiondetail&#13;&#10;where section_name=@sname"
                                                                        ProviderName="System.Data.SqlClient">
                                                                        <SelectParameters>
                                                                            <asp:ControlParameter ControlID="dd_smaster" DefaultValue="" Name="sname" PropertyName="SelectedValue"
                                                                                Type="String" />
                                                                        </SelectParameters>
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-rght-clr1234">
                                                                    &nbsp;<asp:TextBox ID="txt_samnt" runat="server" CssClass="input"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_samnt"
                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                        Type="Currency" ValidationGroup="c" Display="Dynamic"><img src="../images/error1.gif" alt="Enter amount" /></asp:RangeValidator>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_samnt"
                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                        ValidationGroup="c"><img src="../images/error1.gif" alt="Enter amount" /></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td class="frm-rght-clr1234">
                                                                    <asp:Button ID="btn_6A_add" runat="server" Text="Add" CssClass="button" OnClick="btn_6A_add_Click"
                                                                        ValidationGroup="c" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" valign="top" class="head-2">
                                                        <asp:GridView ID="grid_6A" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="4" DataKeyNames="section_detail" Font-Names="Arial" Font-Size="11px"
                                                            Width="100%" EmptyDataText="No record found" OnRowDeleting="grid_6A_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="5%" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkstatus" runat="server" Checked='<%# Convert.ToBoolean(Eval("status"))%>'>
                                                                        </asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Section">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="kck" runat="server" Text='<%# Bind("section_name")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Detail">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="30%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="pck" runat="server" Text='<%# Bind("section_detail")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="acl" runat="server" Text='<%# Bind("a_amount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="15%" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel ID="Tab_PersonalDetail" runat="server" HeaderText="Personal Detail">
                                    <ContentTemplate>
                                        <div>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td>
                                                        <fieldset class="fieldsetBorder">
                                                            <legend><span class="txt02">Relationship Details</span></legend>
                                                            <div>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Father's Name
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="30%">
                                                                            <asp:Label ID="txt_f_f_name" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Mother's Name
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="30%">
                                                                            <asp:Label ID="txt_m_fname" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Marital Status
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="ddlpersonalstatus" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txt02" colspan="4">
                                                                            Spouse/ Husband
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Name
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="txt_sp_fname" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Date of Anniversary
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="txt_doa" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="txt02">
                                                                            Children Detail
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" colspan="4">
                                                                            <asp:GridView ID="grid_child" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                                AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name" HorizontalAlign="Left"
                                                                                EmptyDataText="No Record(s)">
                                                                                <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Child Name ">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Left" Width="150px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date of Birth">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                        <ItemStyle HorizontalAlign="Left" Width="200px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                                </HeaderStyle>
                                                                                <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </fieldset>
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
                        <td height="5" colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr id="trButton" runat="server" visible="true">
                                    <td align="right">
                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                                          OnClientClick="return validate();"  ToolTip="Click to submit the Declaration" />
                                        <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click"
                                            ToolTip="Click to reset the entered details" ValidationGroup="none" />
                                        <input type="button" id="Button1" class="button" value="Back" onclick="javascript:history.go(-1);" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnPdf" runat="server" Visible="true" Text="Gen. Pdf" CssClass="button" ToolTip="Click to submit the Declaration"
                                            OnClick="btnPdf_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2">
                                        Mandatory Fields (<img src="../images/error1.gif" alt="" />)
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
