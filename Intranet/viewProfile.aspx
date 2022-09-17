<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewprofile.aspx.cs" Inherits="Admin_company_empmaster"
    Title="" %>

<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Acuminous Software</title>
    <link rel="shortcut icon" href="http://teamworksindia.com/new/febicon.ico" type="image/x-icon" />
    <link rel="shortcut icon" href="febicon.ico" type="image/x-icon" />
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
    <script type="text/javascript" src="../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="2">
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="4" Width="100%"
                        CssClass="ajax__tab_xp2">
                        <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Job Detail">
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
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        First Name
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtfirstname" runat="server"></asp:Label>&nbsp;<asp:Label ID="txt_login_id"
                                                                            runat="server" Visible="False"></asp:Label>
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
                                                                        <asp:Label ID="txtmiddlename" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Last Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtlastname" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        Employee Code
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtempcode" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="33%">
                                                                        Employee Status
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="67%">
                                                                        <asp:Label ID="drpempstatus" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        Branch Name
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_branch_name" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Designation
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_desigination" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Department
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_dept_name" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Ext. Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtext" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        Employee Role
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_emp_role" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="43%">
                                                                        Division
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="57%">
                                                                        <asp:Label ID="lbl_division_name" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Grade
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_grade" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Date of Joining
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="doj" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        &nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
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
                                                                    <td class="frm-lft-clr123" width="33%">
                                                                        ESI Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="67%">
                                                                        <asp:Label ID="esino" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        PF Number
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="pfno" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                                                        <asp:Label ID="panno" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        ESI Dispensary
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="esidesp" runat="server"></asp:Label>&nbsp;&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="43%">
                                                                        PF Number for Dept File
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="57%">
                                                                        <asp:Label ID="pfno_dept" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                                                        <asp:Label ID="ward" runat="server"></asp:Label>&nbsp;&nbsp;
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
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Professional">
                            <ContentTemplate>
                                <div>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="frm-lft-clr-main">
                                                Educational Qualification :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tbody>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                            HorizontalAlign="Left" EmptyDataText="no data found !" BorderStyle="Solid" BorderWidth="1px">
                                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Education">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="20%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="School ">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Grade / %">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label43" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                            ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                            </HeaderStyle>
                                                                            <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
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
                                                            <tbody>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                            AllowSorting="True" CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left"
                                                                            CellPadding="4" EmptyDataText="no data found !" BorderStyle="Solid" BorderWidth="1px">
                                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Education">
                                                                                    <ItemTemplate>
                                                                                        <headerstyle width="15%" horizontalalign="Left" />
                                                                                        <itemstyle width="15%" horizontalalign="Left" />
                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Institute / University Name ">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Grade / %">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label43" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                            ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                            </HeaderStyle>
                                                                            <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tbody>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:GridView ID="grid_exp" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                            AllowSorting="True" CaptionAlign="Left" DataKeyNames="comp_name" HorizontalAlign="Left"
                                                                            CellPadding="4" EmptyDataText="no data found !" BorderStyle="Solid" BorderWidth="1px">
                                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="company Name">
                                                                                    <ItemTemplate>
                                                                                        <headerstyle horizontalalign="Left" />
                                                                                        <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Address / Location ">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Exp.">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labewdl43" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                            ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label></ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                            </HeaderStyle>
                                                                            <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Personal Detail">
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
                                                                            <td class="frm-lft-clr123" width="33%">
                                                                                Date of Birth
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="67%">
                                                                                <asp:Label ID="txt_DOB" runat="server" Width="100px"></asp:Label>&nbsp;
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
                                                                                <asp:Label ID="lblpaymentmode" runat="server"></asp:Label>&nbsp;
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
                                                                            <td class="frm-lft-clr123">
                                                                                Religion
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtrelg" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                D.L. No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_dl_no" runat="server" Width="142px"></asp:Label>
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
                                                                        <asp:Label ID="txt_bank_name" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &#160;&nbsp;
                                                                    </td>
                                                                    <td align="left" class="frm-lft-clr123" width="18%">
                                                                        Account No for Salary
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123" width="32%">
                                                                        <asp:Label ID="txt_bank_ac" runat="server" Width="142px"></asp:Label>
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
                                                                        <asp:Label ID="txt_bank_name_reimbursement" runat="server"></asp:Label>&#160;&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &#160;&nbsp;
                                                                    </td>
                                                                    <td align="left" class="frm-lft-clr123">
                                                                        Account No for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_bank_ac_reimbursement" runat="server" Width="142px"></asp:Label>
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
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Mobile No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtmobileno" runat="server" Width="142px"></asp:Label>
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
                                                                                <asp:Label ID="txtbloodgrp" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 5px">
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
                                                                            <td class="frm-lft-clr123">
                                                                                Email Id
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_email" runat="server" Width="142px"></asp:Label>
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
                                                                                <asp:Label ID="txt_passportno" runat="server" Width="142px"></asp:Label>
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
                                                                            <td class="frm-lft-clr123" width="33%">
                                                                                Father&apos;s Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_f_f_name" runat="server"></asp:Label>&nbsp;
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
                                                                            <td class="frm-lft-clr123" width="33%">
                                                                                Marital Status
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="ddlpersonalstatus" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="43%">
                                                                                Mother&apos;s Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_m_fname" runat="server"></asp:Label>&nbsp;
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
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2" style="height: 13px">
                                                                                                        Spouse Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="33%">
                                                                                                        Name
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="67%">
                                                                                                        &#160;<asp:Label ID="txt_sp_fname" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table align="right" border="0" cellpadding="0" cellspacing="0" width="99%">
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
                                                                                                    <td class="frm-lft-clr123" style="width: 86px">
                                                                                                        Date of Anniversary
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="57%">
                                                                                                        <asp:Label ID="txt_doa" runat="server"></asp:Label>&nbsp;
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
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2">
                                                                                                        Children Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table align="right" border="0" cellpadding="0" cellspacing="0" width="99%">
                                                                                                <tr>
                                                                                                    <td align="left" class="txt02" colspan="2">
                                                                                                        &#160;&#160;
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
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" valign="top">
                                                                                            <asp:GridView ID="grid_child" runat="Server" AllowSorting="True" AutoGenerateColumns="False"
                                                                                                BorderStyle="Solid" BorderWidth="1px" CaptionAlign="Left" CellPadding="4" DataKeyNames="Child_name"
                                                                                                EmptyDataText="no data found !" HorizontalAlign="Left" Width="100%">
                                                                                                <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Child Name ">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label></ItemTemplate>
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="150px"></ItemStyle>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Date of Birth">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label></ItemTemplate>
                                                                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"></HeaderStyle>
                                                                                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" Width="200px"></ItemStyle>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top">
                                                                                                </HeaderStyle>
                                                                                                <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                                                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                                                            <td colspan="2" style="height: 14px">
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
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Contact Detail">
                            <ContentTemplate>
                                <div>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <div>
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td height="5">
                                                                                        </td>
                                                                                        <td class="txt02">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02" align="center">
                                                                                            Present Address
                                                                                        </td>
                                                                                        <td class="txt02" align="center">
                                                                                            Permanent Address
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02">
                                                                                            &#160;&nbsp;
                                                                                        </td>
                                                                                        <td class="txt02">
                                                                                            &#160;&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td class="frm-lft-clr123" width="33%">
                                                                                                            Address 1
                                                                                                        </td>
                                                                                                        <td class="frm-rght-clr123" width="67%">
                                                                                                            <asp:Label ID="txt_pre_add1" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" height="5">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td class="frm-lft-clr123" width="33%">
                                                                                                            Address 2
                                                                                                        </td>
                                                                                                        <td class="frm-rght-clr123" width="67%">
                                                                                                            <asp:Label ID="txt_pre_add2" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_pre_city" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_pre_state" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_pre_country" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_pre_zip" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_pre_phone" runat="server"></asp:Label>&nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" height="5">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td class="frm-lft-clr123" width="43%">
                                                                                                            Address 1
                                                                                                        </td>
                                                                                                        <td class="frm-rght-clr123" width="57%">
                                                                                                            <asp:Label ID="txt_per_add1" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_per_add2" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_per_city" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_per_state" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_per_country" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_per_zip" runat="server"></asp:Label>&nbsp;
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
                                                                                                            <asp:Label ID="txt_per_phone" runat="server"></asp:Label>&nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" height="5">
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
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
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
                                                <%-- <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                    <ContentTemplate>--%>
                                                <div>
                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="2">
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
                                                                                    &#160;&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td colspan="7" height="5">
                                                                                                    <asp:GridView ID="grdTempClass" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                                        CellSpacing="0" CellPadding="5" BorderColor="#c9dffb" Style="border-collapse: collapse;"
                                                                                                        OnRowCommand="grdTempClass_RowCommand" DataKeyNames="Id">
                                                                                                        <RowStyle CssClass="clr2" />
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="S.No">
                                                                                                                <ItemTemplate>
                                                                                                                    <%#Container.DataItemIndex + 1 %>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Document Type">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblDocType" runat="server" Text=' <%#Eval("DocTypeName")%>'> </asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Document">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:LinkButton ID="lblUploadedDoc" runat="server" Text='<%# Eval("UploadedDoc") %>'
                                                                                                                        CommandName="Download" CommandArgument='<%# DataBinder.Eval(Container,"RowIndex") %>'>
                                                                                                                    </asp:LinkButton>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Description">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Desc")%>' Visible="true"></asp:Label></ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                        </Columns>
                                                                                                        <EmptyDataTemplate>
                                                                                                            <center>
                                                                                                                <span class="txt01">&nbsp;No Data Available</span></strong></center>
                                                                                                        </EmptyDataTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                                        <HeaderStyle CssClass="head" />
                                                                                                        <AlternatingRowStyle CssClass="clr2" />
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
                                                <%-- </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>
