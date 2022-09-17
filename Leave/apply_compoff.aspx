<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apply_compoff.aspx.cs" Inherits="leave_apply_compoff" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <%--<title>Acuminous Software Intranet</title>--%>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
    <script type="text/javascript" src="js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="js/ddaccordion.js"></script>
    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group
            contentclass: "submenu", //Shared CSS class name of contents group
            collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
            animatedefault: false, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["suffix", "<img src='images/plus3.gif' class='statusicon' />", "<img src='images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
        })
    </script>
    <%--<script type="text/javascript" language="javascript">
function noOfDayschanges() 
{
	var d1 =document.getElementById('txt_fromdate').value;
	var d2 =document.getElementById('txt_todate').value;
	var date1 = new Date(d1);
	var date2 = new Date(d2);
	var day = parseInt(1000*60*60*24);
	//alert(d1);
	//alert(d2);
	//alert(day);
	var diff =parseInt(Math.ceil((date2.getTime()-date1.getTime())/(day))+1);
	//alert(diff);//lbl_no_of_days
     document.getElementById('lbl_no_of_days').value=diff;
}

</script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img alt="" src="../images/loading.gif" />
                                </td>
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div>
                <td width="87%" height="450" align="left" valign="top" class="blue-brdr-1">
                    <table width="728" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1" style="width: 729px">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%">
                                                        <img src="images/employee-icon.jpg" width="16" height="16" alt="" />
                                                    </td>
                                                    <td class="txt01">
                                                        Comp-off Leave
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" valign="top" align="right" class="txt-red" style="width: 729px">
                                            <span id="message" runat="server"></span>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" valign="top" class="txt02" style="width: 729px">
                                            &nbsp;Employee Information
                                        </td>
                                    </tr>
                                      <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="19%" class="frm-lft-clr123">
                                        Employee Name
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="1%" rowspan="7">
                                        &nbsp;
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Employee Code
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 5px">
                                    </td>
                                    <td colspan="2" style="height: 5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19%" class="frm-lft-clr123">
                                        Department
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_gender" Visible="false" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td width="18%" class="frm-lft-clr123">
                                        Designation
                                    </td>
                                    <td width="31%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_designation" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_branch" Visible="false" runat="server" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_doj" runat="server" Visible="false" Text="Label"></asp:Label>
                                        <asp:Label ID="lbl_emp_status" runat="server" Visible="false" Text="Label"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                                    <tr>
                                        <td height="10" valign="top" style="width: 729px" align="right">
                                            &nbsp;<input id="Button2" class="button1" onclick="document.getElementById('light').style.display='block';"
                                                type="button" value="Compoff Status" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20" valign="top" class="txt02" style="width: 729px">
                                            &nbsp;Apply Comp-off Leave
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rdofullday" runat="server" Checked="True" GroupName="days" OnCheckedChanged="rdofullday_CheckedChanged"
                                                Text="Full Day" ValidationGroup="noone" AutoPostBack="True" /><asp:RadioButton ID="rdohalfday"
                                                    runat="server" GroupName="days" OnCheckedChanged="rdohalfday_CheckedChanged"
                                                    Text="Half Day" ValidationGroup="noone" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="height: 10px; width: 729px;">
                                            <div id="divfull" visible="true" runat="server">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="19%" class="frm-lft-clr123">
                                                            From Date
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:TextBox ID="txt_fromdate" runat="server" CssClass="input"></asp:TextBox>
                                                            <asp:Image ID="img_fromdate" runat="server" ImageUrl="~/images/clndr.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fromdate"
                                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter from date"
                                                                ValidationGroup="calculate"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_fromdate"
                                                                ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px" ToolTip="Check date format (MM/dd/yyyy)"
                                                                Type="Date" ValidationGroup="calculate" Width="178px" Operator="DataTypeCheck"
                                                                Display="Dynamic"></asp:CompareValidator>
                                                        </td>
                                                        <td style="width: 1%">
                                                            &nbsp;
                                                        </td>
                                                        <td class="frm-lft-clr123" style="width: 18%">
                                                            To Date
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            &nbsp;<asp:TextBox ID="txt_todate" runat="server" CssClass="input"></asp:TextBox>
                                                            <asp:Image ID="img_todate" runat="server" ImageUrl="~/images/clndr.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_todate"
                                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter to date"
                                                                ValidationGroup="calculate"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_todate"
                                                                ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px" ToolTip="Check date format (MM/dd/yyyy)"
                                                                Type="Date" ValidationGroup="calculate" Width="177px" Operator="DataTypeCheck"
                                                                Display="Dynamic"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_fromdate"
                                                TargetControlID="txt_fromdate">
                                            </cc1:CalendarExtender>
                                            <cc1:CalendarExtender ID="Calendarextender2" runat="server" PopupButtonID="img_todate"
                                                TargetControlID="txt_todate">
                                            </cc1:CalendarExtender>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <div id="divhalf" visible="false" runat="server">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="19%" class="frm-lft-clr123">
                                                            Select Date
                                                        </td>
                                                        <td width="31%" class="frm-rght-clr123">
                                                            <asp:TextBox ID="txtdateone" runat="server" CssClass="input"></asp:TextBox>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdateone"
                                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter  date"
                                                                ValidationGroup="calculate"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtdateone"
                                                                ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px" ToolTip="Check date format (MM/dd/yyyy)"
                                                                Type="Date" ValidationGroup="calculate" Width="181px" Operator="DataTypeCheck"
                                                                Display="Dynamic"></asp:CompareValidator>
                                                        </td>
                                                        <td width="50%" class="frm-rght-clr123">
                                                            &nbsp;<cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="Image1"
                                                                TargetControlID="txtdateone">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" style="width: 729px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 46px; width: 729px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Number of days
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="lbl_no_of_days" runat="server" CssClass="input" Enabled="False"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="lbl_no_of_days"
                                                            ErrorMessage='<img src="../images/error1.gif" alt="Calculate No. of days" />'
                                                            MaximumValue="100" MinimumValue="0.5" Type="Double" ValidationGroup="all"></asp:RangeValidator>
                                                        <asp:Button ID="btn_calc" runat="server" CssClass="butt" OnClick="btn_calc_Click"
                                                            Text="Calculate No. of Days" ValidationGroup="calculate" Width="124px" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" style="width: 729px">
                                        </td>
                                    </tr>
                                    <%--<tr>
        <td valign="top" style="width: 729px"><table width="100%" border="0" cellspacing="0" cellpadding="0">

          <tr>
            <td width="19%" class="frm-lft-clr123">Worked on </td>
            <td class="frm-rght-clr123"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="85%">
                    <asp:TextBox ID="txt_workedon" runat="server" CssClass="input"></asp:TextBox>
                    <asp:Image ID="img_workedon" runat="server" ImageUrl="~/images/clndr.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_workedon"
                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter workedon date"
                        ValidationGroup="u"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_workedon"
                        ErrorMessage="Check date format (MM/dd/yyyy)" Height="9px" ToolTip="Check date format (MM/dd/yyyy)"
                        Type="Date" ValidationGroup="u" Width="175px" Operator="DataTypeCheck" Display="Dynamic"></asp:CompareValidator></td>
                <td width="15%" align="right">
                    <asp:Button ID="btn_add" runat="server" Text="Add" CssClass="button" OnClick="btn_add_Click" ValidationGroup="u"/>&nbsp;</td>
              </tr>
            </table></td>
            </tr>

        </table>
            <cc1:CalendarExtender ID="Calendarextender3" runat="server" PopupButtonID="img_workedon"
                TargetControlID="txt_workedon">
            </cc1:CalendarExtender>
        </td>
      </tr>--%>
                                    <%--<tr>
        <td height="5" style="width: 729px"></td>
      </tr>--%>
                                    <%--<tr>
        <td height="10" valign="top" class="head-2" style="width: 729px">
        
        <asp:GridView ID="grid_workedon" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="workedon" Font-Names="Arial" Font-Size="11px"
               Width="100%" EmptyDataText="No record found" OnRowDeleting="grid_workedon_RowDeleting">
                <Columns>                   
                  <asp:TemplateField HeaderText="Worked On Date">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("workedon")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  
                   
                    <asp:TemplateField>
                        <HeaderStyle CssClass="frm-lft-clr123" />
                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="5%" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete" CssClass="link05"
                                OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
        </td>
      </tr>--%>
                                    <tr>
                                        <td valign="middle" height="25" style="width: 729px">
                                            &nbsp;Mandatory Fields (<img alt="" src="../images/error1.gif" />)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" style="width: 729px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="height: 101px; width: 729px;">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="19%" class="frm-lft-clr123">
                                                        Reason
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_reason" runat="server" TextMode="MultiLine" Width="225px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_reason"
                                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter reason"
                                                            ValidationGroup="v"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="22" valign="top" class="txt02">
                                                        Approver Hierarchy
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="head-2" valign="top" colspan="2">
                                                        <asp:GridView ID="approvergrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No leave to adjust"
                                                            DataKeyNames="empcode" DataSourceID="SqlDataSource2">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Employee Code">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Approver Name">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Level">
                                                                    <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle Width="33%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("Levels") %>'></asp:Label>
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
                                                    <td colspan="2" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Add Comment
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_comment" runat="server" TextMode="MultiLine" Width="225px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="10" style="width: 729px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" valign="top" style="width: 729px">
                                            <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click1"
                                                ValidationGroup="v" Enabled="False" />
                                            <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />&nbsp;<asp:Button
                                                ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click1" Text="Save as draft"
                                                ValidationGroup="v" Enabled="False" /><br />
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 729px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                    SelectCommand="select &#13;&#10;coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as empname,&#13;&#10;approverid as empcode,&#13;&#10;case when eh.hr=0 then 'Level ' + cast(approverpriority as varchar(10)) else 'HR' end as levels&#13;&#10;&#13;&#10;from tbl_leave_employee_hierarchy eh &#13;&#10;inner join &#13;&#10;tbl_intranet_employee_jobDetails ed&#13;&#10;&#13;&#10;on eh.approverid=ed.empcode &#13;&#10;where eh.employeecode=@empcode&#13;&#10;order by approverpriority">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="empcode" SessionField="empcode" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </div>
            <div id="light" runat="server" style="top: 35%; left: 10%;" class="pop1" align="center">
                <table width="600px" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="pop-brdr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                        Comp-off Balance
                                    </td>
                                    <td width="5%" align="right" valign="top" class="pop-tp-clr">
                                        <a href="#" onclick="document.getElementById('light').style.display='none';">
                                            <img src="images/btn-close.gif" width="16" height="19" border="0" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" valign="top">
                                        <table width="100%">
                                            <tr>
                                                <td class="txt02">
                                                    Entitled
                                                </td>
                                                <td class="txt02">
                                                    Used
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <hr />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblentitled" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblused" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <hr />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" height="10">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;
    </form>
</body>
</html>
