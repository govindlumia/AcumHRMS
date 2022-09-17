<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OverViewAttendanceRule.aspx.cs"
    Inherits="Leave_admin_OverViewAttendanceRule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Intranet</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="../js/ddaccordion.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="718" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" height="463px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Attendance Rule
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
                                    <td height="20" valign="top" class="txt02">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="27%" class="txt02" style="height: 13px">
                                                    View Rules
                                                </td>
                                                <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="head-2" style="height: 292" valign="top">
                                        <asp:GridView ID="rulegrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                            CellPadding="4" CellSpacing="0" DataKeyNames="Policyid" Font-Names="Arial" Font-Size="11px"
                                            Width="100%" AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Policy Name">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="25%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l1" runat="server" Text='<%#Bind("PolicyName")%>'> </asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                 <asp:TemplateField HeaderText="Attendance Rule">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left" VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                        <a href="javascript:void(window.open('view_Attendance_Rule.aspx?PolicyId=<%#DataBinder.Eval(Container.DataItem,"policyid")%>','title','height=300,width=480,left=200,top=20'));" class="link05">View </a> |
                        
                       <%-- "JavaScript:newPopup5('view_leave_adjustment_rule.aspx?leaveid=<%#DataBinder.Eval(Container.DataItem, "leaveid")%>');" class="link05">View </a> |   --%> 
                       <a href="Edit_Attendance_Rule.aspx?PolicyId=<%#DataBinder.Eval(Container.DataItem,"policyid")%>" target="_self" class="link05">Edit </a> 
                        </ItemTemplate>
                    </asp:TemplateField> 
                                            </Columns>
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;<a class="txt-red" href="leaveadmin.aspx" target="name123">Back</a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
