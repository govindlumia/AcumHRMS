
<%@ Page Title="Audit Trail" Language="C#" MasterPageFile="~/Admin/Employee/EmployeeMaster.master"
    AutoEventWireup="true" CodeFile="AuditTrailView.aspx.cs" Inherits="admin_AuditTrailView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css" media="all">
        @import "../../Css/blue1.css";
        @import "../../Css/example.css";
    </style>
    <script type="text/javascript" src="../../js/tabber.js"></script>
    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <link href="../../css/blue1.css" rel="stylesheet" type="text/css" />
    <link href="../../Calender/css/calendar.css" rel="stylesheet" type="text/css" />


    <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ScriptManager1" />
    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
  
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="middle" class="txt02 blue-brdr-1" height="23" colspan="2">
                    &nbsp;Audit Employee
                </td>
            </tr>
            <tr>
                <td height="5" valign="top" colspan="2">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    From Date
                    <asp:TextBox ID="txtFromDate" CssClass="input" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgInvoiceDate" runat="server" ImageUrl="../../images/Calendar_scheduleHS.png"
                        ToolTip="Click to open/close calender" />
                    <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFromDate"
                        PopupButtonID="imgInvoiceDate" Format="dd-MMM-yyyy" />
                </td>
                <td class="frm-lft-clr123">
                    To Date
                    <asp:TextBox ID="txtToDate" CssClass="input" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/Calendar_scheduleHS.png"
                        ToolTip="Click to open/close calender" />
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                        PopupButtonID="ImageButton1" Format="dd-MMM-yyyy" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123">
                    Employee
                    <asp:DropDownList ID="ddlEmployee" CssClass="select" Width="150px" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="frm-lft-clr123">
                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lbl" runat="server" Text="" BackColor="#999999"></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td>
                    &nbsp;
                </td>
            </tr>--%>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DataList ID="ddlAudit" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="78%" colspan="4" class="frm-rght-clr123">
                                        <strong>
                                           Field Name : <asp:Label ID="lblFieldName" runat="server" Text='<%#Eval("FieldName")%>'></asp:Label></strong><br />
                                        Previous :
                                        <asp:Label ID="lblPrevious" runat="server" Text='<%#Eval("Previous")%>'></asp:Label><br />
                                        Modified :
                                        <asp:Label ID="lblModified" runat="server" Text='<%#Eval("Modified")%>'></asp:Label><br />
                                        Employee :
                                        <asp:Label ID="lblEmployee" runat="server" Text='<%#Eval("EmpCode")%>'></asp:Label><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="blue-brdr-1">
                                        Modified Date :
                                        <%#Eval("CreatedDate")%>
                                        <br />
                                        Modified By :
                                        <%#Eval("CreatedBy")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
  </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>


