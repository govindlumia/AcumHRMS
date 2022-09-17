<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewApplyOd.aspx.cs" Inherits="Leave_ViewApplyOd" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply OD</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";

        .style2
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #013366;
            width: 184px;
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

        .completionList
        {
            border: solid 1px Gray;
            margin: 0px;
            padding: 3px;
            height: 120px;
            overflow-y: scroll;
            background-color: #FFFFFF;
        }

        .listItem
        {
            color: #191919;
        }

        .itemHighlighted
        {
            background-color: #ADD6FF;
        }
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
         <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
        <div>
            <table width="718" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">Official Duty
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="7"></td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" class="txt02" height="20">&nbsp;Employee Information
                                            </td>
                                            <td valign="top" align="right" class="txt-red">
                                                <span id="message" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                       <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                     <tr>
                                            <td width="19%" class="frm-lft-clr123">From Date<span style="color: Red">*</span>
                                            </td>
                                           
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_Fromdate" runat="server" CssClass="input"></asp:TextBox>
                                                <asp:Image ID="img" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Fromdate"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator>
                                               <ajax:CalendarExtender ID="Calendarextender1" runat="server" Format="dd-MMM-yyyy"
                                                    PopupButtonID="img" TargetControlID="txt_Fromdate">
                                                </ajax:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">To Date<span style="color: Red">*</span>
                                            </td>

                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_Todate" runat="server" CssClass="input"></asp:TextBox>
                                                <asp:Image ID="imgf" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Todate"
                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <ajax:CalendarExtender ID="Calendarextender3" runat="server" Format="dd-MMM-yyyy"
                                                    PopupButtonID="imgf" TargetControlID="txt_Todate">
                                                </ajax:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click"
                                                    ValidationGroup="v" />
                                            </td>
                                        </tr>
                                    </table>--%>
                                   
                                        <table width="100%" border="0">
                                            <%-- Added by keerti for exporting excel on 27 june 2018 --%>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="ImgExcel" CssClass="button2" runat="server" Visible="false" OnClick="ImgExcel_Click"
                                                    Text="Export To Excel" />
                                            </td>
                                        </tr>
                                        <%--// upto here--%>
                                            <tr>
                                                <asp:GridView ID="grdviewEmpod" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                                    BorderWidth="0px">
                                                    <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Employee Code" SortExpression="Employee Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("EmployeeCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("LoginName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Comment" SortExpression="Employee Comment">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("EmployeeComments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Leave From Date" SortExpression="Leave Date">
                                                            <ItemTemplate>
                                                                <%--changed here by keerti dwivedi on july 7--%>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("LeaveTime1" ,"{0:dd/MM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Leave To Date" SortExpression="Leave Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("LeaveTime","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <%--upto here--%>
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Leave Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </tr>
                                        </table>
                                    </td>
                            </tr>
                        </table>
        </div>
    </form>
</body>
</html>
