<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editemployeepaystructure.aspx.cs"
    Inherits="payroll_admin_editemployeepaystructure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
</style>

    <script type="text/javascript">

function blankmessage()
{

    document.forms[0].elements['lblCheckEmpRecords'].value ="" ;
}
    </script>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../js/timepicker.js"></script>

    <script type="text/javascript">
ddaccordion.init({
headerclass: "expandable", //Shared CSS class name of headers group
contentclass: "submenu", //Shared CSS class name of contents group
collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
animatedefault: false, //Should contents open by default be animated into view?
persiststate: true, //persist state of opened contents within browser session?
toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
togglehtml: ["suffix", "<img src='../../images/plus3.gif' class='statusicon' />", "<img src='../../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
})


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Emp_PayStructure" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax" style="top: 160px;">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img alt="" src="../../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01">
                                                    Employee Edit Pay Structure Master</td>
                                                <td align="right">
                                                    <samp id="backid" runat="server" visible="false">
                                                        <a href="paystructureempview.aspx">Back</a></samp></td>
                                                <td class="txt02" align="right">
                                                    <asp:Label ID="lblCheckEmpRecords" runat="server"></asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="Updatedconfirmationdiv" runat="server" visible="false">
                                            <table id="table3" border="0" cellpadding="0" cellspacing="4" width="718px">
                                                <tr>
                                                    <td align="right" valign="middle" style="font-weight: bolder; color: #cc6633">
                                                        Records Updated Sucessfully for employee
                                                        <asp:Label ID="lblconfempcode" runat="server" Font-Bold="True"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                    </td>
                                                    <td align="center">
                                                        <asp:Button ID="btnviewok" runat="server" Text="ok" CssClass="button" OnClick="btnviewok_Click" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="4">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 123px">
                                        <div id="Divallhide" runat="server">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 11%">
                                                        Employee Code</td>
                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                        <asp:TextBox ID="txt_employee" size="40" CssClass="input" runat="server" ToolTip="Employee Code"
                                                            Width="121px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <span id="pickemp" runat="server"><a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');"
                                                            class="link05">Pick Employee</a></span></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Applied From</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_month_f" runat="server" CssClass="select" Width="90px">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="dd_year_f" runat="server" CssClass="select" Width="90px">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month_f"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year_f"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        PF/ESI</td>
                                                    <td class="frm-rght-clr123">
                                                        &nbsp;
                                                        <asp:CheckBox ID="chk_pf" runat="server" Text="PF" />
                                                        <asp:CheckBox ID="chk_esi" runat="server" Text="ESI" /></td>
                                                </tr>
                                                <%--          <tr>
                       <td height="5" colspan="4"></td>
                </tr>
               <tr >
                   <td class="frm-lft-clr123">
                       Applied To</td>
                   <td class="frm-rght-clr123">
                   <asp:DropDownList id="dd_month_t" runat="server" Width="90px" CssClass="select">
                       <asp:ListItem Value="0">N/A</asp:ListItem>
                   </asp:DropDownList>
                   <asp:DropDownList id="dd_year_t" runat="server" Width="90px" CssClass="select">
                       <asp:ListItem Value="0">N/A</asp:ListItem>
                   </asp:DropDownList>&nbsp;</td>
               </tr>--%>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="25" valign="middle" class="txt02">
                                                        Edit Pay Structure</td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 11%">
                                                        Pay Head</td>
                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                        <asp:DropDownList ID="drpPayHead" runat="server" Width="129px" OnSelectedIndexChanged="drpPayHead_SelectedIndexChanged"
                                                            AutoPostBack="True" ToolTip="Pay Head" CssClass="select" DataSourceID="payheadsqldatasource"
                                                            DataTextField="payhead_name" DataValueField="id">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="payheadsqldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:RossellConnectionString.ProviderName %>"
                                                            SelectCommand="[sp_payroll_payheadname]"></asp:SqlDataSource>
                                                        <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="drpPayHead"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Select Pay Head"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblpayHeadMsg" runat="server" Width="342px" ForeColor="Red"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 11%">
                                                        Pay Calculation Type</td>
                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                        <asp:DropDownList ID="drpPayCalType" runat="server" Width="129px" AutoPostBack="True"
                                                            OnSelectedIndexChanged="drpPayCalType_SelectedIndexChanged" ToolTip="Pay Calculation Type"
                                                            CssClass="select">
                                                            <asp:ListItem Value="0" Selected="True">Monthly Flat Rate</asp:ListItem>
                                                            <asp:ListItem Value="1">Attendance</asp:ListItem>
                                                            <asp:ListItem Value="2">Computed on Basic %</asp:ListItem>
                                                            <asp:ListItem Value="3">Computed on Basic</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="reqPayCalType" runat="server" ControlToValidate="drpPayCalType"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                            ToolTip="Select Pay Calculation Type" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div id="valuebase" runat="server" visible="true">
                                                            <table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 11%">
                                                                        Value Basis</td>
                                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                                        <asp:TextBox ID="txtValueBase" runat="server" CssClass="input" size="40" ToolTip="Rate"
                                                                            Width="121px" AutoPostBack="True" OnTextChanged="txtValueBase_TextChanged"></asp:TextBox>&nbsp;
                                                                        <asp:Label ID="lblpercent" runat="server" Text="%" ForeColor="Red" ToolTip="Percent"
                                                                            Visible="False"></asp:Label>
                                                                        <asp:RequiredFieldValidator ID="reqRate" runat="server" ControlToValidate="txtValueBase"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                            ToolTip="Enter Rate" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="rngcheckpercentage" runat="server" ControlToValidate="txtValueBase"
                                                                            ErrorMessage="Value Range Should be 0.1 to 100 in %" MaximumValue="100" MinimumValue="0.1"
                                                                            Type="Double" Width="215px" ToolTip="Range Value"></asp:RangeValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="4">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div id="divbasic" runat="server" visible="true">
                                                            <table id="TABLE2" width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 11%">
                                                                        Amount</td>
                                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                                        <asp:TextBox ID="txtamount" runat="server" CssClass="input" size="40" ToolTip="Amount"
                                                                            Width="121px"></asp:TextBox>&nbsp;
                                                                        <asp:RequiredFieldValidator ID="reqamount" runat="server" ControlToValidate="txtamount"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                            ToolTip="Enter Amount" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtamount"
                                                                            Display="Dynamic" ErrorMessage="Enter valid amount" MaximumValue="9999999" MinimumValue="0"
                                                                            Type="Currency"></asp:RangeValidator></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="4">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 11%">
                                                        Rounding Value</td>
                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                        <asp:DropDownList ID="drpRoundValue" runat="server" Width="129px" ToolTip="Rounding Value"
                                                            CssClass="select">
                                                            <asp:ListItem Value="0" Selected="True">Higher Rupees</asp:ListItem>
                                                            <asp:ListItem Value="1">Nearest Rupees</asp:ListItem>
                                                            <asp:ListItem Value="2">Higher Five Paisa</asp:ListItem>
                                                            <asp:ListItem Value="3">Normal</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="reqRoundValue" runat="server" ControlToValidate="drpRoundValue"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                            ToolTip="Select Round Value"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 35px" valign="top">
                                                        Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                                    <td align="right" valign="top">
                                                        <asp:Button ID="Add" runat="server" Text="Add" CssClass="button" OnClick="Add_Click"
                                                            ToolTip="Add Employee Pay Master Details" /></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <asp:GridView ID="employeePayStructure" runat="server" AutoGenerateColumns="false"
                                                        DataKeyNames="PayheadID" BorderWidth="1px" CellPadding="4" CellSpacing="0" Font-Names="Arial"
                                                        Font-Size="11px" Width="100%" AllowPaging="true" PageSize="15" EmptyDataText="Sorry No Records Found"
                                                        OnRowDeleting="employeePayStructure_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="EmpCode">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="10%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("Empcode")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pay Head">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="15%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind("PayheadName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Pay Calculation Type" Visible="false">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="25%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("PayCalculationType")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate (%)" Visible="false">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="14%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("ValueBase")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="13%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Type">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="13%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind("Type")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Round Type">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="18%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l6" runat="server" Text='<%# Bind("RoundMethod")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="5%" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                        CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2" style="height: 35px" valign="bottom">
                                                        <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click"
                                                            ValidationGroup="v" /></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
