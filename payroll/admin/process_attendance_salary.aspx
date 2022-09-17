<%@ Page Language="C#" AutoEventWireup="true" CodeFile="process_attendance_salary.aspx.cs"
    Inherits="payroll_admin_process_attendance_salary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="leave" runat="server" AsyncPostBackTimeout="360000">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        <table width="718" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top" colspan="5">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                        </td>
                                        <td class="txt01" runat="server" style="width: 309px">Process Salary Single Employee Wise / Company Wise
                                        </td>
                                        <td runat="server" align="right" class="txt02">
                                            <asp:Label ID="lbl_message" runat="server" Enabled="true" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5">
                                <asp:RadioButton ID="rbtnemp" runat="server" AutoPostBack="True" GroupName="p" Text="Employee"
                                    OnCheckedChanged="rbtnemp_CheckedChanged" />&nbsp;<asp:RadioButton ID="rbtnbranch"
                                        runat="server" AutoPostBack="True" Checked="True" GroupName="p" Text="Company"
                                        OnCheckedChanged="rbtnbranch_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="20%">Financial Year
                                        </td>
                                        <td class="frm-rght-clr123" colspan="2" width="80%">&nbsp;<%--<asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>--%><asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                            CssClass="select" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Select Month
                                        </td>
                                        <td class="frm-rght-clr123" colspan="2">&nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" AutoPostBack="False"
                                            OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                        </asp:DropDownList>
                                            &nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td height="5" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="3">
                                            <div id="divbranch" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%">Select Company<span style="color: Red">*</span>
                                                        </td>
                                                        <td align="left" colspan="2" class="frm-rght-clr123" style="width: 572px">&nbsp;<asp:DropDownList ID="ddlcompany" runat="server" CssClass="select" DataTextField="companyname"
                                                            DataValueField="companyid" Width="140px" OnSelectedIndexChanged="ddlcompany_selectIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                            &nbsp;
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlcompany"
                                                                    ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>

                                                        </td>
                                                    </tr>
                                                    <%--  <tr>
                                                            <td class="frm-lft-clr123" width="20%">
                                                                Select Branch
                                                            </td>
                                                            <td align="left" class="frm-rght-clr123" colspan="2">
                                                                &nbsp;<asp:DropDownList ID="ddlbranch" runat="server" CssClass="select" DataTextField="branch_name"
                                                                    DataValueField="branch_id" OnDataBound="ddlbranch_DataBound" Width="140px">
                                                                </asp:DropDownList>
                                                                &nbsp;
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlbranch"
                                                                    ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                           
                                                                &nbsp;
                                                            </td>
                                                        </tr>--%>
                                                </table>
                                            </div>
                                            <div id="divemp" visible="false" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="20%">Emp Code<span style="color: Red">*</span>
                                                        </td>
                                                        <td align="left" class="frm-rght-clr123" colspan="2">
                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="input" Width="140px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                                ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            <span id="pickemp" runat="server"><a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');"
                                                                class="link05">Pick Employee</a></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Process Salary
                                        </td>
                                        <td align="left" class="frm-rght-clr123" colspan="2">&nbsp;<asp:Button ID="btn_procs_salary" runat="server" CssClass="button2" Text="Process Salary" Enabled="true"
                                            ValidationGroup="v" OnClick="btn_procs_salary_Click" />&nbsp;
                                                <asp:Button ID="Btnverifieddetils" runat="server" CssClass="button2" Text="View Processed Salary"
                                                    ValidationGroup="v" OnClick="Btnverifieddetils_Click" Visible="true" />
                                            <asp:Button ID="btn_reprocs_salary" runat="server" CssClass="button2" Text="Reprocess Salary"
                                                ValidationGroup="v" OnClick="btn_reprocs_salary_Click" Visible="False" />
                                            <asp:Button ID="btn_reprocs_att" runat="server" CssClass="button2" Text="Reprocess Attendance"
                                                ValidationGroup="v" OnClick="btn_reprocs_att_Click" Visible="False" />
                                            <asp:Button ID="btn_procs_att" runat="server" CssClass="button2" Text="Process Attendance"
                                                ValidationGroup="v" OnClick="btn_procs_att_Click" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="7">
                                <asp:GridView ID="GridView1"  runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top"></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </ContentTemplate>
         <Triggers>
        <asp:PostBackTrigger ControlID="Btnverifieddetils" />
        </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
