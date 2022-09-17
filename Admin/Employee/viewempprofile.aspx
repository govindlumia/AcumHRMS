<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="viewempprofile.aspx.cs" Inherits="viewempprofile" %>

<%-- <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>--%>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
     
    <%--<title>Acuminous Software</title>--%>
    <title>Acuminous Software Pvt. Ltd</title>
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
        @import "../../Css/ajax__tab_xp2.css";
        .style6
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #013366;
            width: 164px;
            border-left: 1px solid #c9dffb;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #c9dffb;
            border-bottom: 1px solid #c9dffb;
            padding-left: 5px;
            padding-right: 0;
            padding-top: 4px;
            padding-bottom: 4px;
            background: #edf5ff;
        }
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.0/jquery.min.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    </head>
    <body>
    
       
    <div class="header">
        <form id="cmaster" runat="server">
     <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
</cc1:ToolkitScriptManager>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="2">
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="100%"
                        CssClass="ajax__tab_xp2">
                        <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Job Detail">
                            <ContentTemplate>
                                <div>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">
                                                Employee Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                            <td width="33%" class="frm-lft-clr123">
                                                                Company Name
                                                            </td>
                                                            <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtcompanyname" runat="server"></asp:Label>
                                                                       
                                                                    </td>
                                                            </tr>
                                                              <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        First Name
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="txtlastname" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                             <asp:Label ID="txt_login_id" runat="server" ></asp:Label>
                                                                             &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                            <td height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">
                                                Work Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5">
                                            </td> 
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="33%">
                                                                        Employee Status
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="67%">
                                                                        <asp:Label ID="drpempstatus" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        Category
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_category_name" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Job Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_job_type" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                <td class="frm-lft-clr123">
                                                                        Date of Joining
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="doj" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="txtdol" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Salary Calculation From
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtsalary" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>--%>
                                                              
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        Employee Role
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_emp_role" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                   <td class="frm-lft-clr123">
                                                                        Designation
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_desigination" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>
                                                               <%-- <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Home Business unit
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_bu" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2">
                                                                    </td>
                                                                </tr>--%>
                                                              <%--  <tr>
                                                                 <td class="frm-lft-clr123">
                                                                        Secondary Business unit
                                                                    </td>
                                                                       <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_sbu" runat="server"></asp:Label>
                                                                           &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="lblrelieving" runat="server"></asp:Label>
                                                                           &nbsp;&nbsp;</td>
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
                                        <td height="5">
                                        </td>
                                    </tr>
                                    <%-- <tr>
                                        <td class="txt02">
                                           Insurance Detail
                                        </td>
                                    </tr>
                                     <tr>
                                        <td height="5">
                                        </td>
                                    </tr>--%>
                                    <tr>
                                    <td>
                                     <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td valign="top" width="50%">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                          <%--  <tr>
                                                                <td class="frm-lft-clr123" width="36%">
                                                                    Policy Name
                                                                </td>
                                                                <td class="frm-rght-clr123" width="64%">
                                                                   <asp:Label ID="LblPolicyName" runat="server"></asp:Label>
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
                                                                    <asp:Label ID="Lbl_CustomerID" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123">
                                                                    Policy Limit
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                   <asp:Label ID="Lbl_Limit" runat="server"></asp:Label>
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
                                                            <%--<tr>
                                                                <td class="frm-lft-clr123" width="36%">
                                                                    Company Name
                                                                </td>
                                                                <td class="frm-rght-clr123" width="54%">
                                                                    <asp:Label ID="Lbl_InsCmpyName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>--%>
                                                            <%--<tr>
                                                                <td colspan="2" height="5">
                                                                </td>
                                                            </tr>--%>
                                                           <%-- <tr>
                                                                <td class="frm-lft-clr123" width="40%">
                                                                    Valid From 
                                                                </td>
                                                                <td class="frm-rght-clr123" width="60%">
                                                                    <asp:Label ID="LblValiddate" runat="server"></asp:Label>
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
                                        <td height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="txt02">
                                            Approval Hierarchy
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                     <td class="frm-lft-clr123">
                                                        Reporting Manager 1
                                                    </td>
                                                    </tr>
                                                     <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                     <tr>
                                                    <td>
                                                        <asp:GridView ID="Grid_approval" runat="server" Width="100%" CellPadding="4"
                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="approverid"
                                                            HorizontalAlign="Left" BorderWidth="1px" BorderColor="#c9dffb">
                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Approver Code">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("approverid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="Approver Name">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Lable12" runat="server" Text='<%# Eval("approvername") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Category">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Lable13" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="17%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                              <%--  <asp:TemplateField HeaderText="Business Unit">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Lable14" runat="server" Text='<%# Eval("BU") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="17%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>--%>
                                                                <asp:TemplateField HeaderText="Designation">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Lable15" runat="server" Text='<%# Eval("designation") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approval Level ">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("approverpriority") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                               
                                                            </Columns>
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Reporting Manager 2
                                                    </td>
                                                    
                                        </tr>
                                        <tr>
                                            <td height="5">
                                            </td>
                                        </tr>
                                          <tr>
                                                    <td>
                                                        <asp:GridView ID="Grid_rep_approval" runat="server" Width="100%" CellPadding="4"
                                                             AutoGenerateColumns="False" AllowSorting="True"
                                                            CaptionAlign="Left" DataKeyNames="approverid" HorizontalAlign="Left" BorderWidth="1px" BorderColor="#c9dffb">
                                                            <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Approver Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label11" runat="Server" Text='<%# Eval("approverid") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Approver Name">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("approvername") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Category">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="17%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Business Unit">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("BU") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="17%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                               <asp:TemplateField HeaderText="Designation">
                                                            <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("designation") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="18%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                            </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approval Level ">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label12" runat="Server" Text='<%# Eval("approverpriority") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                </asp:TemplateField>
                                                             
                                                            </Columns>
                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                            </HeaderStyle>
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                 <tr>
                                            <td height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">
                                                Payroll Details
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="33%">
                                                                        ESI Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="67%">
                                                                        <asp:Label ID="esino" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="pfno" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="panno" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="esidesp" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="43%">
                                                                        PF Account Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="57%">
                                                                        <asp:Label ID="pfno_dept" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                                        <asp:Label ID="ward" runat="server"></asp:Label>
                                                                        &nbsp;&nbsp;</td>
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
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grid_edu_education" runat="server" Width="100%" CellPadding="4"
                                                                        AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                        HorizontalAlign="Left" EmptyDataText="no data found !" BorderStyle="Solid" 
                                                                        BorderWidth="1px" BorderColor="#c9dffb">
                                                                        <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Education">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label6" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="School ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label7" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Grade / %">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label43" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label8" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                        ID="Label9" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
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
                                                        </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr-main">
                                                Professional Qualification :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grid_Pro_education" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                        AllowSorting="True" CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left"
                                                                        CellPadding="4" EmptyDataText="no data found !" BorderStyle="Solid" 
                                                                        BorderWidth="1px" BorderColor="#c9dffb">
                                                                        <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Education">
                                                                                <ItemTemplate>
                                                                                    <headerstyle width="15%" horizontalalign="Left" />
                                                                                    <itemstyle width="15%" horizontalalign="Left" />
                                                                                    <asp:Label ID="Label10" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Institute / University Name ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label13" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="35%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Grade / %">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label14" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemTemplate>
                                                                                 <asp:Label ID="Lbl_month" runat="server" Text='<%# Eval("month_from") %>'></asp:Label>
                                                                                    <asp:Label ID="Label15" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label> - 
                                                                                     <asp:Label ID="Lbl_monthto" runat="server" Text='<%# Eval("month_to") %>'></asp:Label>
                                                                                    <asp:Label
                                                                                        ID="Label16" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr-main">
                                                Experience Details :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grid_exp" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                        AllowSorting="True" CaptionAlign="Left" DataKeyNames="comp_name" HorizontalAlign="Left"
                                                                        CellPadding="4" EmptyDataText="no data found !" BorderStyle="Solid" 
                                                                        BorderWidth="1px" BorderColor="#c9dffb">
                                                                        <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Company Name">
                                                                                <ItemTemplate>
                                                                                    <headerstyle horizontalalign="Left" />
                                                                                    <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address / Location ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Designation ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblDesg" runat="Server" Text='<%# Eval("Designation") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            
                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                             <asp:TemplateField HeaderText="From">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Labewdl43" runat="Server" Text='<%# Eval("datefrom") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="To">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("dateto") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="12%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Duration">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="LblDuration" runat="Server" Text='<%# Eval("duration") %>'></asp:Label></ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                        </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                        </HeaderStyle>
                                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                             <tr><td colspan="4">
                                                             <table width="100%">
                                                             <tr>
                                                              </td>
                                                        <td  align="right" class="td-head" width="75%">
                                                        <asp:Label ID="Lbltotal" runat="server" Text="Total Experience:-"></asp:Label>
                                                        </td>
                                                        <td width="25%">
                                                        <asp:Label ID="Txttotal" runat="server" ></asp:Label>
                                                        </td>
                                                             </tr>
                                                             </table>
                                                            
                                                        </tr>
                                                        </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Personal Detail">
                           
                                    <ContentTemplate>
                                        <div>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02">
                                                        Personal Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Date of Birth
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                <asp:Label ID="txt_DOB" runat="server" Width="100px"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Payment Mode
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
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
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Religion
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                <asp:Label ID="txtrelg" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Name in Bank
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                <asp:Label ID="txt_bank_emp" runat="server" Width="142px"></asp:Label>
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
                                                    <td valign="top">
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
                                                                        &nbsp;&nbsp;</td>
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
                                                                    <td align="left" class="frm-lft-clr123" width="18%">
                                                                        Bank Name for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123" width="32%">
                                                                        <asp:Label ID="txt_bank_name_reimbursement" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;&nbsp;</td>
                                                                    <td align="left" class="frm-lft-clr123" width="18%">
                                                                        Account No for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123" width="32%">
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
                                                    <td valign="top">
                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Mobile No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                <asp:Label ID="txtmobileno" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Blood Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                <asp:Label ID="txtbloodgrp" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 5px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                            Passport Expiry Date</td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                            <asp:Label ID="LblPassexpiryDate" runat="server" width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 5px">
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
                                                                                <asp:Label ID="txt_email" runat="server" Width="142px"></asp:Label>
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
                                                                                <asp:Label ID="txt_altemailid" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Passport No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
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
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" height="5">
                                                        Relationship Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Father&#39;s Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
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
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Marital Status
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                <asp:Label ID="ddlpersonalstatus" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                Mother&#39;s Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="64%">
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
                                                    <td style="height: 12px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <table  id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server" visible="false">
                                                                        <tr>
                                                                            <td>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" >
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
                                                                                                        &nbsp;<asp:Label ID="txt_sp_fname" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                  <tr>
                                                                                                <td class="frm-lft-clr123" width="36%">
                                                                                                Date of Birth
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="LblSpouseDob" runat="server"></asp:Label>
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
                                                                                                    <td class="txt02" colspan="2" height="5">
                                                                                                        &nbsp;&nbsp;</td>
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
                                                                                </td>
                                                                                </tr>
                                                                                </table>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02">
                                                                                                        Children Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txt02">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" align="left">
                                                                                                        &nbsp;&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" colspan="2">
                                                                                            <asp:GridView ID="grid_child" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                                                AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name" HorizontalAlign="Left"
                                                                                                CellPadding="4" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="no data found !" BorderColor="#c9dffb">
                                                                                                <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Child Name ">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label17" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="150px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Date of Birth">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label18" runat="Server" Text='<%# Eval("child_dob" , "{0:dd-MMM-yyyy}") %>'></asp:Label>
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
                                                                            <td style="height: 14px">
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
                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Contact Detail">
                            <ContentTemplate>
                                <div>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                        <div>
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
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
                                                                                    &nbsp;&nbsp;</td>
                                                                                <td class="txt02">
                                                                                    &nbsp;&nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Address 1
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_pre_add1" runat="server"></asp:Label>&nbsp;
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
                                                                                                <asp:Label ID="txt_pre_add2" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                City
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_pre_city" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                State
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_pre_state" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Country
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_pre_country" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Zip Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_pre_zip" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Phone No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_pre_phone" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
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
                                                                                                <asp:Label ID="Lbl_emg_name" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Mode of Transport
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="lblmodeoftransport" runat="server"></asp:Label>&nbsp;
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
                                                                                                <asp:Label ID="txt_per_add1" runat="server"></asp:Label>&nbsp;
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
                                                                                                <asp:Label ID="txt_per_add2" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                City
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_per_city" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                State
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_per_state" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Country
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_per_country" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Zip Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_per_zip" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Phone No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txt_per_phone" runat="server"></asp:Label>&nbsp;
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
                                                                                                <asp:Label ID="Lbl_phone_emg" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="36%">
                                                                                                Pick Up Point
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="64%">
                                                                                                <asp:Label ID="txtmodeoftransport" runat="server"></asp:Label>&nbsp;
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
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <%-- <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Salary Detail">
                        <ContentTemplate>
                        <div>
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                       <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02">
                                                        Salary Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td valign="top">
                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Basic Salary
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                 <asp:Label ID="Lblbasic" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Mobile Allowance
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                 <asp:Label ID="LblMobilAllow" runat="server"></asp:Label>&nbsp;
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
                                                                                Conveyance Allowance
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="LblConvAll" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Total Salary
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="Lbltotal" runat="server"></asp:Label>&nbsp;
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
                                                    <td height="5">
                                                    </td>
                                                </tr>
                        </table>
                        </div>
                        </ContentTemplate>
                        </cc1:TabPanel>--%>
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
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td height="5">
                                                                                                            <asp:GridView ID="grdTempClass" runat="server" AutoGenerateColumns="False" 
                                                                                                                Width="100%" CellPadding="5" BorderColor="#c9dffb" Style="border-collapse: collapse;"
                                                                                                                OnRowCommand="grdTempClass_RowCommand" DataKeyNames="Id">
                                                                                                                <RowStyle CssClass="clr2" />
                                                                                                                <Columns>
                                                                                                                   
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
                                                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="head" />
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
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                      <%--  <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Edit Profile">
                            
                        </cc1:TabPanel>--%>
                    </cc1:TabContainer>
                </td>
            </tr>
               <tr>
            <td>
            </td>
            <td height="10px">
            </td>
        </tr>
        <tr >
            <td  width="90%">
                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
            </td>
            <td align="center" width="10%">
               
<%--                    <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" 
                    onclick="btnCancel_Click" align="right"/>--%>
            </td>
        </tr>
        </table>
          </form>
    </div>
        <script>

            //$("#TabContainer1_TabPanel5_tab").click(function () {

            // debugger

            //$("#btngeneralsubmit").hide();
            //});
            //});



    </script>
</body>
</html>