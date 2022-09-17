<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMonthWiseInsentive.aspx.cs"
    Inherits="payroll_admin_AddMonthWiseInsentive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Monthly Incentive Details</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";

.disp {
 display:none;
}
.pop2 {
  display: none; position:absolute; background-color: #fff; z-index:1002; overflow: auto; padding:0px; left:410px; top:30%;
}
fieldset {
 margin:0; padding:0; border: 1px solid #c9dffb; padding:0 7px 10px 7px;
}
legend {
 font: 12px Arial, Helvetica, sans-serif; color:#08486d; padding-bottom: 0px; padding-top: 2px;
}
.frmcls
{ 
	position:absolute;
	z-index:998;
	border-style: none;
}
</style>

    <script language="javascript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" class="bg">
                        <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top" class="blue-bg">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="50%" height="24" valign="middle">
                                                <strong>Monthly Performance Incentive </strong>
                                            </td>
                                            <td width="50%" align="right" valign="middle">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" class="light-blue">
                                    <!--................................MID SECTION........................-->
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="490" valign="top" class="blue-brdr-1">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="11%" valign="middle" class="frm-lft-clr-main">
                                                                                    Employee Code
                                                                                </td>
                                                                                <td valign="top" class="frm-lft-clr-main">
                                                                                    Financial Year
                                                                                </td>
                                                                                <td valign="middle" class="frm-lft-clr-main">
                                                                                    Amount</td>
                                                                                <td width="34%" valign="top" class="frm-lft-clr-main">
                                                                                    &nbsp;</td>
                                                                                <td width="16%" valign="middle" class="frm-lft-clr-main">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" height="5">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="middle" class="frm-rght-clr123">
                                                                                    <asp:Label ID="lblEmpcode" runat="server" Width="121px"></asp:Label></td>
                                                                                <td width="19%" valign="middle" class="frm-rght-clr123">
                                                                                    <asp:Label ID="lblFyear" runat="server" Width="121px"></asp:Label></td>
                                                                                <td width="20%" valign="middle" class="frm-rght-clr123">
                                                                                    <asp:Label ID="lblAmount" runat="server" Width="121px"></asp:Label></td>
                                                                                <td valign="middle" class="frm-rght-clr123">
                                                                                    <asp:Button ID="btnsbmit0" runat="server" Text="Process" CssClass="button" OnClick="Refresh" />
                                                                                </td>
                                                                                <td valign="middle" class="frm-rght-clr123">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10" colspan="5">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" valign="top" class="head-2">
                                                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                        OnRowDataBound="row">
                                                                                        <Columns>
                                                                                            <asp:TemplateField>
                                                                                                <HeaderTemplate>
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                        <tr class="frm-lft-clr-main">
                                                                                                            <td width="5%" style="display: none;">
                                                                                                                Select</td>
                                                                                                            <td height="20" width="19%">
                                                                                                                Emp. Code</td>
                                                                                                            <td width="19%">
                                                                                                                Financial Year</td>
                                                                                                            <td width="15%">
                                                                                                                Month</td>
                                                                                                            <td width="34%">
                                                                                                                Amount</td>
                                                                                                            <td width="8%">
                                                                                                                &nbsp;</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </HeaderTemplate>
                                                                                                <EditItemTemplate>
                                                                                                </EditItemTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                        <tr>
                                                                                                            <td width="5%" style="font-weight: bold; display: none;">
                                                                                                                <asp:CheckBox Visible="false" ID="rowCheck" runat="server" /></td>
                                                                                                            <td height="20" width="19%">
                                                                                                                &nbsp;
                                                                                                                <asp:Label ID="id" Visible="false" runat="server" Text='<%# bind("id") %>'></asp:Label>
                                                                                                                <asp:Label ID="lblPayheadId" Visible="false" runat="server" Text='<%# bind("payheadid") %>'></asp:Label>
                                                                                                                <asp:Label ID="lblInsId" Visible="false" runat="server" Text='<%# bind("insentive_id") %>'></asp:Label>
                                                                                                                <asp:Label ID="lblEmpCode0" runat="server" Text='<%# bind("empcode") %>'></asp:Label></td>
                                                                                                            <td width="19%">
                                                                                                                <asp:Label ID="lblFyear" runat="server" Text='<%# bind("fyear") %>'></asp:Label>
                                                                                                            </td>
                                                                                                            <td width="15%">
                                                                                                                <asp:Label ID="lblMonth" runat="server" Text='<%# bind("month") %>'></asp:Label>
                                                                                                            </td>
                                                                                                            <td width="34%">
                                                                                                                <asp:TextBox ID="txtAmount" Width="100" runat="server" Text='<%# bind("amount") %>'></asp:TextBox>
                                                                                                                &nbsp;<asp:Label ID="lblStatus" Visible="false" runat="server" Text='<%# bind("status") %>'></asp:Label>
                                                                                                                <asp:Image ImageUrl="~/images/action_check.gif" ID="imgStatus" runat="server" />
                                                                                                            </td>
                                                                                                            <td width="8%">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" valign="top" style="padding-top: 5px;">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="12%">
                                                                                                <asp:Button ID="btnsbmit" runat="server" Text="Update" Visible="false" CssClass="button"
                                                                                                    OnClick="btnsbmit_Click" />
                                                                                            </td>
                                                                                            <td width="88%" align="left">
                                                                                                <asp:Label ID="lblMessage" Font-Bold="true" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" valign="top">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" valign="top">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5" valign="top">
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <!--................................END MID SECTION........................-->
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
