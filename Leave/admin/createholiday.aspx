<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createholiday.aspx.cs" Inherits="Leave_admin_create_holiday"
    Title="Leave Holiday Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
    <script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="../js/ddaccordion.js"></script>
    <script type="text/javascript" src="../js/timepicker.js"></script>
    <script type="text/javascript">
        function time() {
            var t1 = document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table width="718" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Holiday Master
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
                        <td height="20" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="27%" class="txt02">
                                        Create Holiday
                                    </td>
                                    <td width="73%" align="right" class="txt-red">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Year
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:DropDownList ID="ddlyear" runat="server" Width="103px" CssClass="select" ToolTip="Select year">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="cmpvyear" runat="server" ControlToValidate="ddlyear" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                            Operator="NotEqual" ValueToCompare="Select" ToolTip="Select Year of holiday"
                                            ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Branch
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:DropDownList ID="ddlbranch" runat="server" Width="182px" DataSourceID="SqlDataSource2"
                                            DataTextField="branch_name" DataValueField="branch_id" ToolTip="Select Branch of the Company"
                                            CssClass="select" AppendDataBoundItems="True">
                                            <asp:ListItem Value="0">For All Branch</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                        </asp:SqlDataSource>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Name
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:TextBox ID="txtholiday" runat="server" MaxLength="20" Width="175px" CssClass="input2" ToolTip="Add Holiday Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvhname" runat="server" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                            ControlToValidate="txtholiday" ValidationGroup="v" ToolTip="Enter Holiday Name"
                                            Display="Dynamic" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Detail
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:TextBox ID="txtdetail" runat="server" Width="175px" CssClass="input2" TextMode="MultiLine"
                                            ToolTip="Add detail of the holiday" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Date
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:TextBox ID="txtdate" runat="server" CssClass="input" Width="88px"></asp:TextBox>
                                        <asp:Image ID="img1" runat="server" ImageUrl="~/Leave/images/clndr.gif" />
                                      <%--  (dd-MMM-yyyy)--%><%--<asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdate"
                                            PopupButtonID="img1">
                                        </asp:CalendarExtender>--%>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate"
                                            PopupButtonID="img1" Format="dd-MMM-yyyy">
                                        </asp:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        &nbsp;
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                            ValidationGroup="v" ToolTip="Click here to submit the new holiday" />
                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" ValidationGroup="nothing"
                                            Text="Reset" OnClick="btn_reset_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="width: 66%; height: 22px;">
                                        Mandatory Fields (<img src="../images/error1.gif" alt="" />)
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
