<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaveadmin.aspx.cs" Inherits="leave_admin_leaveadmin" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Leave Admin</title>
<style type="text/css" media="all">
@import "../css/blue1.css";
</style>
<script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>
<script type="text/javascript" src="../js/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="../js/ddaccordion.js"></script>
<script type="text/javascript" src="../js/timepicker.js"></script>
<script type="text/javascript">
ddaccordion.init({
headerclass: "expandable", //Shared CSS class name of headers group
contentclass: "submenu", //Shared CSS class name of contents group
collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
animatedefault: false, //Should contents open by default be animated into view?
persiststate: true, //persist state of opened contents within browser session?
toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
})
</script>
<%--<script type="text/javascript">
function time()
{
var t1=document.getElementById("ctl00_ContentPlaceHolder1_txtstime").toString();
}
</script>--%>
</head>
<body>
    <form id="form1" runat="server">  
<div class="header">
<table width="969" border="0" align="center" cellpadding="0" cellspacing="0">
<%--<tr>
<td colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; height: 30px;">Leave Management &gt;&gt; Create Leave</td>
</tr>--%>
<tr>
<td height="5" colspan="3"></td>
</tr>
<tr>
<td width="12%" valign="top" class="blue-brdr"><!--................................LEFT NAVIGAION........................-->
<table width="210" border="0" cellspacing="0" cellpadding="0">
<tr>
<td class="nav-head">Leave Management</td>
</tr>
<tr>
<td><div class="glossymenu">
<a class="menuitem expandable" href="#">Leave Master</a>
<div class="submenu">
<ul>
<li><a href="createleave.aspx" target="content">Create Leave</a></li>
<li><a href="editleave.aspx" target="content">View / Edit Leave</a></li>
</ul>
</div>

<a class="menuitem expandable" href="#">Leave Policy</a>
<div class="submenu">
<ul>
<li><a href="createleavepolicy.aspx" target="content">Create Leave Policy</a></li>
<li><a href="editleavepolicy.aspx" target="content">View / Edit Policy</a></li>
</ul>
</div>

<a class="menuitem expandable" href="#">Leave Rule</a>
<div class="submenu">
<ul>
<li><a href="createdefaultrule.aspx">Create General Rule</a></li>
<li><a href="create_leave_adjustment_rule.aspx" target="content">Create Adjustment Rule</a></li>
<%--<li> <a href="create_leave_clubbing_rule.aspx" target="content">Create Clubbing Rule</a></li>--%>
<li><a href="overviewrule.aspx" target="content">View / Edit Leave Rule</a></li>
</ul>
</div>

<a class="menuitem expandable" href="#">Employee Leave Profile</a>
<div class="submenu">
<ul>
<li><a href="create_employee_leave_profile.aspx" target="content">Create Leave Profile</a></li>
<li><a href="viewemployeeprofile.aspx" target="content">View / Edit Profile</a></li>
</ul>
</div>

<a class="menuitem expandable" href="#">Duty Roster</a>
<div class="submenu">
<ul>
<li><a href="set_dutyroster.aspx">Create Duty Roster</a></li>
<li><a href="view_dutyroster.aspx">View / Edit Duty Roster</a></li>
</ul>
</div>

<a class="menuitem expandable" href="#">Attendance</a>
<div class="submenu">
<ul>
<li><a href="attendance.aspx" target="content">Attendance Entry</a></li>
<li><a href="uploadattendance.aspx" target="content">Upload Attendance</a></li>
</ul>
</div>


<a class="menuitem expandable" href="#">Shift Master</a>
<div class="submenu">
<ul>
<li><a href="createshift.aspx" target="content">Create Shift Master</a></li>
<li><a href="editshift.aspx" target="content">View / Edit Shift Master</a></li>
</ul>
</div>
<a class="menuitem expandable" href="#">Holiday Master</a>
<div class="submenu">
<ul>
<li><a href="createholiday.aspx" target="content">Create Holidays</a></li>
<li><a href="editholiday.aspx" target="content">View / Edit Holidays</a></li>
</ul>
</div>	

<a class="menuitem expandable" href="#">Report</a>
<div class="submenu">
<ul>
<li><a href="../report-dept-attendance.aspx">Department Attendance</a></li>
<li><a href="viewattendance.aspx" target="content">Datewise Attendance</a></li>
<li><a href="report_attendance_dataewise.aspx">Employeewise Attendance </a></li>
<li><a href="../monthwisereport.aspx" target="content">Monthwise Attendance</a></li>
<li><a href="../report-leaveregister.aspx">Leave Register</a></li>
<li><a href="../employee_detail.aspx">Employee Leave Balance</a></li>
<li><a href="../report_employeeresign.aspx">Resigned Employee</a></li>
<li><a href="../report_approver.aspx">Reporting Approver Detail</a></li>
<li><a href="../report_employee.aspx">Reporting Employee Detail</a></li>
</ul>
</div>
<%--<a class="menuitem expandable" href="#">Reports</a>
<div class="submenu">
<ul>
<li></li>
</ul>
</div>--%>
</div></td>
</tr>
</table>
<!--................................END LEFT NAVIGAION........................--></td>
<td width="1%" valign="top"><img src="../images/5x5.gif" width="10" height="5" /></td>
<td width="87%" height="450" align="left" valign="top" class="blue-brdr-1">
<iframe name="content" frameborder="0" width="736px" height="495px" src="../leave-main.html" scrolling="yes">
    
</iframe> </td>
</tr>
</table>
</div>  
</form>
</body>
</html>
