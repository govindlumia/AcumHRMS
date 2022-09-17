<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewdeclarationdetail.aspx.cs"
    Inherits="payroll_admin_viewdeclarationdetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Company Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/example.css";
        @import "../../css/ajax__tab_xp2.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="payroll" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
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
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        View & Approve Employee Declaration
                                    </td>
                                    <td width="55%" align="right" class="txt-red">
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
                                        Self Occupied
                                    </td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:Label ID="lbl_self" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123">
                                        Loan Borrowed
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_loan" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="frm-lft-clr123" width="20%">
                                        Interest
                                    </td>
                                    <td class="frm-rght-clr123" width="30%">
                                        <asp:Label ID="txt_houseint" runat="server" Text="Label"></asp:Label>
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
                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
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
                                <cc2:TabPanel ID="Tab_rent" runat="server" HeaderText="Rent Paid Details">
                                    <ContentTemplate>
                                        <div>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">
                                                        Monthly Paid Rent
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
                                                                <td colspan="6">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="24%">
                                                                                Metro/Non-metro City
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="76%">
                                                                                <asp:Label ID="lbl_metro" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_apr" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    May
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:Label ID="txt_may" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    June
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:Label ID="txt_june" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_jul" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    August
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_aug" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    September
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_sep" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_oct" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    November
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_nov" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    December
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_dec" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_jan" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    February
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_feb" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    March
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_mar" runat="server" Text="Label"></asp:Label>
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
                                </cc2:TabPanel>
                                <cc2:TabPanel ID="Tab_children" runat="server" HeaderText="Children(Studying) Details">
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
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:Label ID="txt_apr2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    May
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:Label ID="txt_may2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123" width="15%">
                                                                    June
                                                                </td>
                                                                <td class="frm-rght-clr123" width="18%">
                                                                    <asp:Label ID="txt_june2" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_jul2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    August
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_aug2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    September
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_sep2" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_oct2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    November
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_nov2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    December
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_dec2" runat="server" Text="Label"></asp:Label>
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
                                                                    <asp:Label ID="txt_jan2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    February
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_feb2" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123">
                                                                    March
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="txt_mar2" runat="server" Text="Label"></asp:Label>
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
                                </cc2:TabPanel>
                                <cc2:TabPanel ID="Tab_6Adetail" runat="server" HeaderText="VI-A Deduction">
                                    <ContentTemplate>
                                        <div>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">
                                                        VI-A Deduction
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" valign="top" colspan="2" class="head-2">
                                                        <asp:GridView ID="grid_6A" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="4" DataKeyNames="section_detail" Font-Names="Arial" Font-Size="11px"
                                                            Width="100%" EmptyDataText="No record found">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="5%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("status")%>'></asp:Label>
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
                                                                        Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="pck" runat="server" Text='<%# Bind("section_detail")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                        Width="30%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="acl" runat="server" Text='<%# Bind("a_amount")%>'></asp:Label>
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
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </cc2:TabPanel>
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
                    <cc1:TabPanel ID="Tab_LandLordDetail" runat="server" HeaderText="Land Lord Detail">
                                    <ContentTemplate>
                                        <div>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td>
                                                        <fieldset class="fieldsetBorder">
                                                            <legend><span class="txt02">Land Lord Details</span></legend>
                                                            <div>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Land Lord Name
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="30%">
                                                                            <asp:Label ID="lbl_LName" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123" width="20%">
                                                                            Pan Card No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="30%">
                                                                            <asp:Label ID="lbl_panNo" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Address
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="lbl_address" runat="server"></asp:Label>&nbsp;
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
                                <%--<cc2:tabpanel ID ="Tab_nscdetail" runat="server" HeaderText="NSC Detail"   ><ContentTemplate>
    <div>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
<tr>
<td height="5" colspan="2"></td>
</tr>
<tr>
<td colspan="2" class="txt02">National Saving Certificate Details</td>
</tr>
<tr>
<td height="5" colspan="2"></td>
</tr>
  <tr>
    <td height="10" valign="top" colspan="2" class="head-2">    
    <asp:GridView ID="grid_nsc" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
            CellPadding="4" DataKeyNames="certi_no" Font-Names="Arial" Font-Size="11px"
              Width="100%" EmptyDataText="No record found">
            <Columns>                   
                             
                 <asp:TemplateField HeaderText="Certi. No.">
                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                        VerticalAlign="Top" Width="25%" />
                    <ItemTemplate>
                        <asp:Label ID="nkck" runat="server" Text='<%# Bind("certi_no")%>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                  <asp:TemplateField HeaderText="Inv. Date">
                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                        VerticalAlign="Top" Width="25%" />
                    <ItemTemplate>
                        <asp:Label ID="npck" runat="server" Text='<%# Bind("inv_date")%>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField HeaderText="Amount">
                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                    <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                        VerticalAlign="Top" Width="30%" />
                    <ItemTemplate>
                        <asp:Label ID="nacl" runat="server" Text='<%# Bind("nsc_amount")%>' ></asp:Label>
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
  <td  height="5" colspan="2"></td>
  </tr> 
</table>
</div>
    
</ContentTemplate>
</cc2:tabpanel>--%>
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
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnsubmit" runat="server" Text="Approve" CssClass="button" OnClick="btnsubmit_Click"
                                            ToolTip="Click to submit the Declaration" />
                                        <asp:Button ID="Btndelarationpermission" runat="server" Text="User edit" CssClass="button" OnClick="Btndelarationpermission_Click"
                                            ToolTip="Click to give editable permission to user for Declaration" />
                                        <input type="button" id="Button1" class="button" value="Back" onclick="javascript:history.go(-1);" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
