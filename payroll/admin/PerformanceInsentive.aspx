<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PerformanceInsentive.aspx.cs"
    Inherits="payroll_admin_PerformanceInsentive" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>

    <script language="javascript" type="text/javascript" src="../../js/popup.js"></script>

    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../js/timepicker.js"></script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Emp_PayStructure" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1" style="width: 719px">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%" style="height: 16px">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01" style="height: 16px">
                                                    Employee Performance Incentive</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" align="right" style="padding-right: 5px;">
                                        <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 123px; width: 719px;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Financial Year</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                        CssClass="select" DataTextField="year" DataValueField="year" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dd_year"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Select Payhead</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:DropDownList ID="ddlPayhead" runat="server" Width="129px" ToolTip="Financial Year"
                                                        CssClass="select" DataTextField="year" DataValueField="year" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPayhead"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Incentive Amout<span style="color:Red">*</span></td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="input" size="40" ToolTip="Employee Code"
                                                        Width="121px"></asp:TextBox>
                                                    &nbsp;<asp:RequiredFieldValidator ID="reqEmpcodeE" runat="server" ControlToValidate="txtAmount"
                                                        ErrorMessage="&lt;img src=&quot;../../images/error1.gif&quot; alt=&quot;&quot; /&gt;"
                                                        ToolTip="Enter Employee Code"><img alt="" src="../../images/error1.gif" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Employee Code<span style="color:Red">*</span></td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:TextBox ID="txt_employee" size="40" CssClass="input" runat="server" ToolTip="Employee Code"
                                                        Width="121px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <%--<a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">
                                                        Pick Employee</a>--%>
                                                        <a href="JavaScript:newPopup1('../../pickempwithdata.aspx?HR=0&MSS=0&Emp=1&Con=txt_employee');" class="link05">Pick Employee</a>&nbsp;
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    &nbsp;</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" />
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="color: #d17100;" style="color: #d17100;">
                                                     Month Wise Incentive</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Employee Code</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:TextBox ID="txtSearchEmpcode" runat="server" CssClass="input" size="40" ToolTip="Employee Code"
                                                        Width="121px"></asp:TextBox>
                                                    &nbsp;
                                                    <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" CausesValidation="False"
                                                        OnClick="btnSearch_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        OnRowDataBound="grdDetails_RowDataBound" OnRowEditing="grdDetails_RowEditing"
                                                        OnRowCancelingEdit="grdDetails_RowCancelingEdit" OnRowDeleting="grdDetails_RowDeleting"
                                                        OnRowUpdating="grdDetails_RowUpdating" DataKeyNames="insentive_id">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td height="20" width="19%">
                                                                                Emp. Code</td>
                                                                            <td width="19%">
                                                                                Financial Year</td>
                                                                            <td width="20%">
                                                                                Payhead</td>
                                                                            <td width="14%">
                                                                                Amount</td>
                                                                            <td width="28%">
                                                                                Action</td>
                                                                        </tr>
                                                                    </table>
                                                                </HeaderTemplate>
                                                                <EditItemTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td height="20" width="19%">
                                                                                <asp:Label ID="lblInsId" Visible="false" runat="server" Text='<%# bind("insentive_id") %>'></asp:Label>
                                                                                <asp:Label ID="lblEmpCode" runat="server" Text='<%# bind("empcode") %>'></asp:Label></td>
                                                                            <td width="19%">
                                                                                <asp:Label ID="lblFyear" runat="server" Text='<%# bind("fyear") %>'></asp:Label></td>
                                                                            <td width="20%">
                                                                                <asp:Label ID="lblheadid" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="14%">
                                                                                <asp:TextBox ID="txtAmount" runat="server" Width="92" Text='<%# bind("amount") %>'></asp:TextBox></td>
                                                                            <td width="28%">
                                                                                <asp:LinkButton ID="lnkUpdate" CausesValidation="false" runat="server" SkinID="linkGrid"
                                                                                    ToolTip="Update" CommandName="Update">Update</asp:LinkButton>
                                                                                &nbsp;l&nbsp;
                                                                                <asp:LinkButton ID="lnkCancel" runat="server" SkinID="linkGrid" CausesValidation="false"
                                                                                    CommandName="Cancel" ToolTip="Cancel">Cancel</asp:LinkButton></td>
                                                                        </tr>
                                                                    </table>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tr>
                                                                            <td height="20" width="19%">
                                                                                <asp:Label ID="lblInsId" Visible="false" runat="server" Text='<%# bind("insentive_id") %>'></asp:Label>
                                                                                <asp:Label ID="lblEmpCode" runat="server" Text='<%# bind("empcode") %>'></asp:Label></td>
                                                                            <td width="19%">
                                                                                <asp:Label ID="lblFyear" runat="server" Text='<%# bind("fyear") %>'></asp:Label></td>
                                                                            <td width="20%">
                                                                                <asp:Label ID="lblHeadId" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                                                <asp:Label ID="lblPayHeadId" runat="server" Visible="false" Text='<%# bind("payheadid") %>'></asp:Label>
                                                                            </td>
                                                                            <td width="14%">
                                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# bind("amount") %>'></asp:Label></td>
                                                                            <td width="28%">
                                                                                <asp:LinkButton ID="lnkEdit" CausesValidation="false" runat="server" SkinID="linkGrid"
                                                                                    ToolTip="Edit" CommandName="Edit">Edit</asp:LinkButton>
                                                                                &nbsp;l&nbsp;
                                                                                <asp:LinkButton ID="lnkDelete" CausesValidation="false" runat="server" SkinID="linkGrid"
                                                                                    OnClientClick="return confirm('Are you sure for delete! ?');" CommandName="Delete"
                                                                                    ToolTip="Delete">Delete</asp:LinkButton>
                                                                                &nbsp;l&nbsp;
                                                                                <asp:LinkButton ID="lnkAddMonthly" CausesValidation="false" runat="server" SkinID="linkGrid"
                                                                                    ToolTip="Add Monthly Performance">Add 
                                     Monthly Per</asp:LinkButton>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            No Record(s) Found
                                                        </EmptyDataTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
