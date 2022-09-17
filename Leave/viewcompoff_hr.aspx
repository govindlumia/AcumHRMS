<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewcompoff_hr.aspx.cs" Inherits="leave_viewcompoff_hr" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>KOD Intranet</title>
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
    <%--<script type="text/javascript">
function noOfDayschanges() 
{

	var d1 =document.getElementById('txt_sdate').value;
	var d2 =document.getElementById('txt_edate').value;
	var date1 = new Date(d1);
	var date2 = new Date(d2);
	var day = parseInt(1000*60*60*24);
	//alert(d1);
	//alert(d2);
	//alert(day);
	var diff =parseInt(Math.ceil((date2.getTime()-date1.getTime())/(day))+1);
	//alert(diff);//txt_no_of_days
     document.getElementById('txt_nod').value=diff;
}

</script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager id="leaveapply" runat="server">
    </asp:ScriptManager>
    <div>
        <td width="87%" height="450" align="left" valign="top" class="blue-brdr-1">
            <table width="728" border="0" cellspacing="0" cellpadding="0">
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
                                            <td class="txt01">
                                                Comp-off Leave
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top" align="right" class="txt-red">
                                    <span id="message" runat="server"></span>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top" class="txt02">
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
                                <td height="10" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top" class="txt02">
                                    &nbsp;Apply Comp-off Leave
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 10px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                From Date
                                            </td>
                                            <td width="31%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_fromdate" runat="server"></asp:Label>
                                            </td>
                                            <td style="width: 1%">
                                                &nbsp;
                                            </td>
                                            <td width="18%" class="frm-lft-clr123">
                                                To Date
                                            </td>
                                            <td width="31%" class="frm-rght-clr123">
                                                <asp:Label ID="lbl_todate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 46px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                Number of days
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_nodays" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px">
                                </td>
                            </tr>
                            <%--<tr>
        <td height="10" valign="top" class="head-2">
        
        <asp:GridView ID="grid_workedon" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                CellPadding="4" CellSpacing="0" DataKeyNames="date" Font-Names="Arial" Font-Size="11px"
               Width="100%" EmptyDataText="No record found">
                <Columns>                   
                  <asp:TemplateField HeaderText="Worked On Date">
                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                        <ItemStyle CssClass="frm-rght-clr1234"  HorizontalAlign="Left"
                            VerticalAlign="Top" Width="25%" />
                        <ItemTemplate>
                            <asp:Label ID="l3" runat="server" Text='<%# Bind("date")%>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
            
                </Columns>
                <HeaderStyle CssClass="frm-lft-clr123" />
                <FooterStyle CssClass="frm-lft-clr123" />
                <RowStyle Height="5px" />
            </asp:GridView>
        </td>
      </tr>--%>
                            <%-- <tr>
                                <td valign="middle" height="25">
                                    &nbsp;Mandatory Fields (<img alt="" src="../images/error1.gif" />)
                                </td>
                            </tr>--%>
                            <tr>
                                <td height="5">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 101px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123">
                                                Reason
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_reason" runat="server"></asp:Label>&nbsp;
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
                                                    DataKeyNames="empcode">
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
                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("Status") %>'></asp:Label>
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
                                            <td colspan="2" height="5">
                                                <asp:Label ID="lbl_comments" runat="server"></asp:Label>
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
                                <td valign="top" height="10">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top">
                                    <asp:Button ID="btn_approve" runat="server" CssClass="button" OnClick="btn_approve_Click"
                                        Text="Update" /><asp:Button ID="btn_cancel" runat="server" CssClass="button" Text="Reset" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
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
                        <asp:HiddenField ID="hidd_leaveapplyid" runat="server" Value="0" />
                        &nbsp;
                        <asp:HiddenField ID="hidd_leaveid" runat="server" />
                        <asp:HiddenField ID="prvimg" runat="server" />
                        <asp:HiddenField ID="hidd_empcode" runat="server" Value="0" />
                    </td>
                </tr>
            </table>
        </td>
    </div>
    </form>
</body>
</html>
