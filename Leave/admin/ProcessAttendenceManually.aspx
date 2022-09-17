<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessAttendenceManually.aspx.cs"
    Inherits="Leave_admin_ProcessAttendenceManually" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Process Attendance</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }
    </style>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="500">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax" style="left: 250px; top: 150px">
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
            <table width="100%" cellspacing="0" cellpadding="0" border="0">
                <div id="dvsearch" runat="server">
                    <tr>
                        <td colspan="2" valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" alt="" />
                                    </td>
                                    <td class="txt01">
                                        Process Attendace Form
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top" style="height: 5px" class="txt-red" align="left">
                        <%--<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>--%>
                            <span id="message" runat="server"></span>&nbsp;
                        </td>
                    </tr>
                    <tr>
                   <td>
                   <table style="width:100%">
                  <tr>
                  <td class="frm-lft-clr123" style="width:25%">From(<img src="../images/error1.gif" alt="" />)</td>
                  <td class="frm-rght-clr123" style="width:25%">
                  <asp:TextBox runat="server" ID="txt_fromdate" CssClass="input"></asp:TextBox>&nbsp;
                 
                  <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
                 
                      <asp:RequiredFieldValidator runat="server" ValidationGroup="common" ID="rfv_txt_fromdate" ErrorMessage='<img src="../images/error1.gif" />' ControlToValidate="txt_fromdate">
                                                                                </asp:RequiredFieldValidator>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                                    TargetControlID="txt_fromdate" FirstDayOfWeek="Monday" Format="dd-MMM-yyyy">
                                                                                </cc1:CalendarExtender>
                                                                           
                  </td>
                  <td class="frm-lft-clr123" style="width:25%">To(<img src="../images/error1.gif" alt="" />)</td>
                  <td  class="frm-rght-clr123" style="width:25%">
                  
                      <asp:TextBox runat="server" ID="txt_todate" CssClass="input"></asp:TextBox>&nbsp;
                  <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calender" />
                   <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ErrorMessage='<img src="../images/error1.gif" />' ControlToValidate="txt_todate" ValidationGroup="common">
                                                                                </asp:RequiredFieldValidator >
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                                                    TargetControlID="txt_todate" FirstDayOfWeek="Monday" Format="dd-MMM-yyyy">
                                                                                </cc1:CalendarExtender>
                  </td>
                  </tr>
                   </table>
                   </td>
                    </tr>
                    <tr>
                        <td align="right" class="frm-rght-clr123" valign="bottom">
                            <asp:Button ID="BtnProcessAttendence" runat="server" ValidationGroup="common" CssClass="button" OnClick="BtnProcessAttendence_Click"
                                Text="Process" />
                        </td>
                    </tr>
                </div>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
