<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FullandFinalEmployee.aspx.cs"
    Inherits="payroll_admin_FullandFinalEmployee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
@import "../../css/blue1.css";
        .auto-style1 {
            font: bold 11px verdana;
            color: #d17100;
            height: 13px;
        }
    </style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../js/timepicker.js"></script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css" >
        .hidehidder{
            display:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <Ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </Ajax:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--  <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
                <div style="height:500px !important" >
                <table width="718" border="0" cellspacing="0" cellpadding="0" id="editmasterinfo" runat="server">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1" style="width: 719px">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%" style="height: 16px;">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01" style="height: 16px">
                                                    Employee Full and Final Settlement</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 88px; width: 719px;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="height: 5px;" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Employee Code</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:TextBox ID="txt_employee" size="40" CssClass="input" runat="server" ToolTip="Employee Code"
                                                        Width="121px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"  ValidationGroup="v"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <%--<a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">
                                                        Pick Employee</a>--%>
                                                        <a href="JavaScript:newPopup1('../../pickempdataforfullandfinal.aspx?Con=txt_employee');" class="link05">Pick Employee</a>&nbsp;
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-ckkkkklr123" style="width: 11%">
                                                    &nbsp;</td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:Button ID="btnsbmit" runat="server"  ValidationGroup="v" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" />
                                                     <asp:Button ID="Btnviewloandetails" Visible="false" runat="server" Text="View Info" CssClass="button"  OnClick="Btnviewloandetails_Click" />
                                                    <asp:Label ID="lbmsgdue" CssClass="txt02" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <hr id="editmasterinfoline" runat="server" />
                     
                    <table width="718" border="0" id="Table1" cellspacing="0" cellpadding="0" runat="server">
                <tr>
                    <td valign="top" colspan="5">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>                                          
                                            <td class="txt02" runat="server" style="width: 309px">
                                               Employee Details.
                                            </td>
                                            <td runat="server" align="right" class="txt02">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>                          
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                                Date Of Leave
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 25%; font-weight: bold;">
                                               <asp:Label ID="dol" runat="server"></asp:Label> 
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                                Last Salary Date 
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                              <asp:Label ID="lbllastsaldate" runat="server"></asp:Label> 
                                            </td>                                          
                                        </tr>
                                         <tr>
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                             Payment Mode  
                                            </td>
                                           <td class="frm-lft-clr123" style="width: 25%;">
                                           <asp:DropDownList ID="Ddlreimbursmenttype" runat="server" CssClass="select" ToolTip="Reimbursement Type" 
                                                Width="145px" AutoPostBack="True" onselectedindexchanged="Ddlreimbursmenttype_SelectedIndexChanged">

                                                <asp:ListItem Value="0">Select Type</asp:ListItem>
                                                <asp:ListItem Value="1">Check</asp:ListItem>
                                                <asp:ListItem Value="2">Cash</asp:ListItem>
                                                <asp:ListItem Value="3">Bank</asp:ListItem>


                                            </asp:DropDownList>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Ddlreimbursmenttype" Display="Dynamic"  ValidationGroup="Fnffinal" InitialValue="0"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                      
                                               
                         </td>
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                               Full AND Final Date
                                            </td>
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                                <asp:TextBox ID="txt_FAF" runat="server" CssClass="blue1" Width="142px" ContentEditable="false"></asp:TextBox>&nbsp;
                                                                            <asp:Image ID="Image1" runat="server" ToolTip="click to open calender" ImageUrl="../../images/clndr.gif">
                                                                            </asp:Image>
                                                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_FAF"
                                                                                PopupButtonID="Image1" Format="dd-MMM-yyyy">
                                                                            </cc1:CalendarExtender>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_FAF"
                                                                                Display="Dynamic" ErrorMessage="Enter Date of FNF" SetFocusOnError="True" ToolTip="Select Date!"
                                                                                ValidationGroup="Fnffinal" Width="6px"></asp:RequiredFieldValidator> 
                                            </td>                                          
                                        </tr>
                                          <tr id="tblrowbankinfo" runat="server" >
                                            <td class="frm-lft-clr123" style="width: 25%;">
                                                Bank Name
                                                </td>
                                                  <td class="frm-lft-clr123" style="width: 25%;">
                                                      <asp:DropDownList ID="Ddlbanknametype" runat="server" CssClass="select" ToolTip="Select Bank Name" 
                                                Width="145px">
                                            </asp:DropDownList>
                                                      
                                                </td>
                                                  <td class="frm-lft-clr123" style="width: 25%;">
                                                      Employee Account No
                                                </td>
                                                  <td class="frm-lft-clr123" style="width: 25%;">
                                                         <asp:Label ID="lblempaccountno"  runat="server"></asp:Label> 
                                                </td>
                                              </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                <hr />
                    <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="20" valign="top" style="width: 719px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="auto-style1 blue-brdr-1">
                                                   Employee Gratuity Section </td>
                                                <td class="auto-style1" align="right">
                                                    <span id="Span1" runat="server"></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 100px; width: 719px;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td colspan="2">
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 11%">
                                                            Gratuity Amount</td>
                                                        <td class="frm-rght-clr123" style="width: 27%">
                                                            <asp:Label ID="lblgraduityAmount" runat="server"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 11%">
                                                            Max Exmption
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 27%">
                                                            <asp:Label ID="lblMaxExmption" runat="server"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px;" colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 11%">
                                                            Last 10 Basic Average</td>
                                                        <td class="frm-rght-clr123" style="width: 27%">
                                                            <asp:Label ID="lblLast10basic" runat="server"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 5px;" colspan="2">
                                                        </td>
                                                    </tr>
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <hr />
             <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" height="200px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                              
                                                <td class="txt02" style="height: 16px"  colspan="2">
                                                    Add Employee Allowances(Earnings/Deductions)</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 5px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="15%">
                                            Allowance<span style="color:Red">*</span></td>
                                        <td class="frm-rght-clr123" width="25%">
                                            <asp:DropDownList ID="drpPayHead" runat="server" CssClass="select" ToolTip="Pay Head" 
                                                Width="145px">

                                            </asp:DropDownList>
                                            
                                        <asp:RequiredFieldValidator ID="Requiredallowancetype" runat="server" ControlToValidate="drpPayHead" Display="Dynamic"  ValidationGroup="attd" InitialValue="0"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                         </td>
                                        <td class="frm-lft-clr123" width="15%">
                                            Amount<span style="color:Red">*</span></td>
                                        <td class="frm-rght-clr123" width="40%">
                                            <asp:TextBox ID="txtAllowanceAmount" size="40" CssClass="input" runat="server" ToolTip="Employee Code"
                                                Width="121px"></asp:TextBox>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAllowanceAmount"  ValidationGroup="attd"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Amount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                              </td>
                                        <td class="frm-rght-clr123" width="15%" >
                                            <asp:Button ID="btnadddeductallowance" runat="server" CssClass="button" Text="Add"  ValidationGroup="attd"  OnClick="btnadddeductallowance_Click"></asp:Button>
                                        </td>
                                    </tr>
                                <tr>
                                    <td colspan="5" style="height:5px">

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" class="frm-lft-clr123">
                                          <asp:GridView ID="addallowanceforfnf" runat="server" Font-Size="11px" Font-Names="Arial"
                                                    CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No Allowance Exist."
                                                    DataKeyNames="Allowance_id,AllowanceName,Amount" OnRowCancelingEdit="addallowanceforfnf_RowCancelingEdit"
                                                    OnRowDeleting="addallowanceforfnf_RowDeleting" OnRowEditing="addallowanceforfnf_RowEditing" OnRowUpdating="addallowanceforfnf_RowUpdating"
                                                    AllowPaging="True" OnPageIndexChanging="addallowanceforfnf_PageIndexChanging" PageSize="10"
                                                    >
                                                    <Columns>     
                                                           <asp:TemplateField visible="false" ItemStyle-CssClass="hidehidder" SortExpression="Allowanceid">
                                                            <ItemTemplate>
                                                                <asp:Label ID="l2" Visible="false" runat="server" Text='<%# Bind ("Allowance_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Allowance">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("AllowanceName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l5" runat="server" Text='<%# Bind ("Amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txt_nd" runat="Server" Text='<%# Eval("Amount") %>' CssClass="input"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_nd"
                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter days" />'
                                                                    ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_nd"
                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="Enter valid days" />'
                                                                    MaximumValue="1000000" MinimumValue="1" Type="Double" ValidationGroup="grid"></asp:RangeValidator>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="lnk_update" CssClass="link05" CommandName="Update" runat="server"
                                                                    ValidationGroup="grid">Update</asp:LinkButton>|
                                                                <asp:LinkButton ID="lnk_cancel" CssClass="link05" CommandName="Cancel" runat="server"
                                                                    ValidationGroup="noone">Cancel</asp:LinkButton>
                                                            </EditItemTemplate>
                                                            <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnk_edit" CssClass="link05" CommandName="Edit" runat="server"
                                                                    ValidationGroup="noone">Edit </asp:LinkButton>|
                                                                <asp:LinkButton ID="lnk_delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');"
                                                                    CommandName="Delete" runat="server" ValidationGroup="noone">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                    <RowStyle Height="5px" />
                                                    <PagerSettings Position="TopAndBottom" />
                                                </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="head-2" valign="top">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
                                                     </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <hr />
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                                <td  style="height: 5px;">
                                                </td>
                                            </tr>
                                <tr>
                                    <td height="20" valign="top" style="width: 719px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="txt02 blue-brdr-1" style="height: 13px;color:#d17100 !important">
                                                    Add Paid Working Days</td>
                                                <td class="txt02" align="right">
                                                    <span id="Span2" runat="server"></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 30px; width: 719px;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 45%">
                                                    Attendance
                                                    </td>
                                                <td class="frm-rght-clr123" style="width: 55%">                                               
                                                    Working Days<span style="color:Red">*</span>&nbsp;
                                                    <asp:TextBox ID="txtWorkingDays" onkeyup="checkNumericValueForCntrl(this)"  AutoPostBack="true" runat="server" CssClass="input" size="40" ontextchanged="txtWorkingDays_TextChanged" ToolTip="Employee Code"
                                                        Width="121px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="Rqrdworkingday" runat="server" ControlToValidate="txtWorkingDays" ValidationGroup="Leaveworking"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Working Days"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                               
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <hr id="line" runat="server" />
                    <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="20" valign="top" style="width: 719px">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="txt02 blue-brdr-1" style="height: 13px;color:#d17100 !important">
                                                 <asp:CheckBox ID="ChkExp" runat="server" Text="Include Last Month's On-Hold Salary" ></asp:CheckBox>   
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="718" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                         <td  style="height: 5px;">
                                                </td>
                    </tr>
                <tr>
                    <td>
                     <asp:Button ID="Btngeneratefnd" CssClass="button2" Text="Generate FNF"  ValidationGroup="Fnffinal" runat="server" OnClick="Btngeneratefnd_Click" />
                    </td>
                    </tr>
                    </table>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
