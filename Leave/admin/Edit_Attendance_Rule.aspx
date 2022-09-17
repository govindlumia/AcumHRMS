<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Edit_Attendance_Rule.aspx.cs"
    Inherits="Leave_admin_Edit_Attendance_Rule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <asp:UpdateProgress ID="UpdateProgress1" DisplayAfter="1" runat="server">
        <ProgressTemplate>
            <div class="divajax">
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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                        Attendance Rule
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="7" valign="top" align="right" class="txt-red">
                            <span id="message" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="25%" class="frm-lft-clr123">
                                            Policy Name (<img src="../images/error1.gif" alt="" />)
                                        </td>
                                        <td width="25%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_policy" runat="server" Text="Label"></asp:Label>
                                            &nbsp;
                                        </td>
                                        <td style="width: 1%">
                                            &nbsp;
                                        </td>
                                        <td class="frm-lft-clr123" width="24%">
                                            Coming Type
                                        </td>
                                        <td class="frm-rght-clr123" width="25%">
                                            <asp:DropDownList ID="ddl_comingType" runat="server" CssClass="select1" DataTextField="ComingType"
                                                DataValueField="ComingType" AutoPostBack="True" Width="140px">
                                                <asp:ListItem Value="0" Text="Late Coming">Late Coming</asp:ListItem>
                                                <asp:ListItem Value="1" Text="Early Going">Early Going</asp:ListItem>
                                            </asp:DropDownList>
                                    </tr>
                                </table>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    Time Interval (In Minutes)
                                                </td>
                                                <td class="frm-rght-clr123" width="25%">
                                                    <asp:TextBox ID="txt_Timeint" MaxLength="2"   onkeyup="checkNumericValueForCntrl(this)"  runat="server" CssClass="input" Width="60px">0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Timeint"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;"
                                                        ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_Timeint"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;Enter Integer Value between 0 and 1000&quot; /&gt;"
                                                        MaximumValue="365" MinimumValue="15" Type="Integer" ValidationGroup="v"></asp:RangeValidator>
                                                </td>
                                                <td style="width: 1%">
                                                    &nbsp;
                                                </td>
                                                <td class="frm-lft-clr123" width="24%">
                                                    Repeat
                                                </td>
                                                <td class="frm-rght-clr123" width="25%">
                                                    <asp:TextBox ID="txt_repeat" runat="server" MaxLength="2"   onkeyup="checkNumericValueForCntrl(this)"  CssClass="input" Width="60px">0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_repeat"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;"
                                                        ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_repeat"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;Enter Integer Value between 0 and 1000&quot; /&gt;"
                                                        MaximumValue="365" MinimumValue="0" Type="Integer" ValidationGroup="v"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    Repeat Frequency
                                                </td>
                                                <td class="frm-rght-clr123" width="25%">
                                                    <asp:TextBox ID="txt_repeatFrequency" MaxLength="2"   onkeyup="checkNumericValueForCntrl(this)"  runat="server" CssClass="input" Width="60px">0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_repeatFrequency"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;"
                                                        ValidationGroup="v"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_repeatFrequency"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;Enter Integer Value between 0 and 1000&quot; /&gt;"
                                                        MaximumValue="365" MinimumValue="0" Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                                </td>
                                                <td style="width: 1%">
                                                    &nbsp;
                                                </td>
                                                <td class="frm-lft-clr123" width="24%">
                                                    Action Type
                                                </td>
                                                <td class="frm-lft-clr123" width="25%">
                                                    <asp:DropDownList ID="ddl_ActionType" runat="server" CssClass="select1" DataSourceID="SqlDataSource3"
                                                        DataTextField="Actiontype" DataValueField="id" OnDataBound="drp_aleave_DataBound"
                                                        Width="120px">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddl_ActionType"
                                                        Display="Dynamic" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;"
                                                        Operator="NotEqual" ToolTip="Select Action Type" ValidationGroup="v" ValueToCompare="100"></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                        ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>" SelectCommand="Select id,ActionType from tbl_leave_attendance_actiontype_master;">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" colspan="5">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" style="height: 20px">
                                        <asp:Button ID="btm_add" runat="server" CssClass="button" Text="Add" ValidationGroup="v"
                                            OnClick="btm_add_Click" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="4" valign="top">
            </td>
        </tr>
        <tr>
            <td class="head-2" height="10" valign="top">
                <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                    CellPadding="4" CellSpacing="0" DataKeyNames="id" OnRowDeleting="grid_aleave_RowDeleting"
                    EmptyDataText="No record found" Font-Names="Arial" Font-Size="11px" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Policy Name">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text='<%# Bind("Policyname")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Coming Type">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="l4" runat="server" Text='<%# Bind("ComingType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time Interval (In Minutes)">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="l5" runat="server" Text='<%# Bind("TimeInt")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Repeat">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="l7" runat="server" Text='<%# Bind("Repeat")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Repeat Frequency">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="l8" runat="server" Text='<%# Bind("RepeatFrequency")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action Type">
                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="l9" runat="server" Text='<%# Bind("ActionType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderStyle CssClass="frm-lft-clr123" />
                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                Width="5%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link05"
                                    OnClientClick="return confirm('Do you want to Delete this record?');" ValidationGroup="noone">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="frm-lft-clr123" />
                    <FooterStyle CssClass="frm-lft-clr123" />
                    <RowStyle Height="5px" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td height="10%">
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr align="right">
            <td valign="middle" height="25">
                &nbsp;Mandatory Fields (<img alt="" src="../images/error1.gif" />)
            </td>
            <td align="right">
                <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click"
                    ToolTip="Click here to submit the updated rule" />
                <asp:Button ID="btnrst" runat="server" CssClass="button" OnClick="btnrst_Click" Text="Cancel"
                    ToolTip="Click here to cancel the updation" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>" SelectCommand="select leaveid,leavetype from tbl_leave_createleave where status=1 ">
                        </asp:SqlDataSource>--%>
                <asp:HiddenField ID="hiddenvalue" runat="server" />
                <asp:HiddenField ID="hidden_policy" runat="server" />
            </td>
        </tr>
    </table>
   <%-- </td> </tr> </table>--%>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
