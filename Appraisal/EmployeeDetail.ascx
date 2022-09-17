<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmployeeDetail.ascx.cs" Inherits="Appraisal_EmployeeDetail" %>
<div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">

        <tr>
            <td height="1"></td>
        </tr>
        <tr>
            <td height="20" valign="top" class="txt02">
                <table width="100%">
                    <tr>
                        <td width="27%" class="txt02" height="22">Employee Information
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
                        <td width="19%" class="frm-lft-clr123">Employee Name
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td width="1%" rowspan="7">&nbsp;
                        </td>
                        <td width="18%" class="frm-lft-clr123">Employee Code
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px"></td>
                        <td colspan="2" style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td width="19%" class="frm-lft-clr123">Category
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>

                        </td>
                        <td width="18%" class="frm-lft-clr123">Designation
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:Label ID="lbl_Designation" runat="server" Text="Label"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px"></td>
                        <td colspan="2" style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td width="19%" class="frm-lft-clr123">Date of Joining
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:Label ID="lbl_dated" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td width="19%" class="frm-lft-clr123">Review Period
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:DropDownList ID="drpReviewPeriod" runat="server" CssClass="select"></asp:DropDownList>
                            <asp:Label runat="server" ID="lblPeriod" Text=""></asp:Label>
                            <asp:Label ID="lbl_Location" Visible="false" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 5px"></td>
                        <td colspan="2" style="height: 5px"></td>
                    </tr>
                    <tr>
                        <td width="19%" class="frm-lft-clr123">Current Experience
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            <asp:Label ID="lblExp" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td width="19%" class="frm-lft-clr123">&nbsp;
                        </td>
                        <td width="31%" class="frm-rght-clr123">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</div>
