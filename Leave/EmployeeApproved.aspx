<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeApproved.aspx.cs" Inherits="Leave_EmployeeApproved" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                </td>
                            </tr>
                            <tr>

                                <td valign="top">
                                    <table width="100%" border="0">
                                        <tr>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" BorderStyle="Solid"
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
                                                     <asp:TemplateField HeaderText="Leave From Date" SortExpression="Leave Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("LeaveTime1") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Leave To Date" SortExpression="Leave Time">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("LeaveTime") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Left" Width="21%" CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("EmployeeCode")  + "," +Eval("leaveid") + "," + "1" %>'><b>Approve</b></asp:LinkButton>
                                                              <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("EmployeeCode")  + "," +Eval("leaveid" ) + "," + "0" %>'><b>Reject</b></asp:LinkButton>
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
                    </td>
                </tr>
            </table>
        </div>

    </form>
</body>
</html>
