<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leaveadmin.aspx.cs" Inherits="leave_admin_leaveadmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
    <style type="text/css">
         body {
    background: #208cb5d1;
}
    </style>
    
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
            <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" background="../../images/bg.gif">
                <tr>
                    <td valign="top">
                        <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top" class="wht-clr"></td>
                            </tr>
                            <tr>
                                <td height="20" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="56%" style="height: 70px;" valign="middle">
                                                 <a href="../../Admin/Home.aspx">
                                                <img src="~/images/product/Rossel-Techsys-Logo1(1).png" style="width:22%" runat="server" id="imageDynamic" />
                                                     </a>
                                            </td>
                                            <td width="44%" align="right">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td colspan="2" align="right"></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="91%" height="24" align="right" valign="bottom">
                                                            <strong>Welcome</strong>
                                                            <asp:Label ID="lblname" runat="server"></asp:Label>
                                                        </td>
                                                        <td width="9%" align="center" valign="bottom">
                                                            <img src="../../images/welcome-icon.jpg" width="14" height="16" alt="" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="bottom" height="17">
                                                            <asp:LinkButton ID="lnkbtnlogout" CssClass="link01" runat="server" OnClick="lnkbtnlogout_Click">Logout</asp:LinkButton>
                                                        </td>
                                                        <td align="center" valign="bottom">
                                                            <img src="../../images/log-out-icons.jpg" width="10" height="10" alt="" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top">
                                    <table width="969" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="center" colspan="3">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="green-bar">
                                                    <tr>
                                                        <td width="50%" height="24" valign="middle" align="left" style="padding-left: 10px; color: #fff; font-weight: bold;">
                                                            <%-- <a href="javascript:history.back();">
                                                                            <img alt="" src="../../images/back1.png" height="30px" title="Back" /></a>--%>
                                                            <strong>Administrator Section</strong>
                                                        </td>
                                                        <td width="50%" align="right" valign="middle">
                                                            <a href="../../Admin/Home.aspx" class="link-wht" style="padding-right: 10px;">Home Page</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                      <td colspan="3" bgcolor="#f1f4f5" class="black1" style="padding-left:5px; height: 30px;">Leave Management &gt;&gt; Create Leave</td>
                                      </tr>--%>
                                        <tr>
                                            <td height="5" colspan="3"></td>
                                        </tr>
                                        <tr>
                                            <td width="12%" valign="top" class="blue-brdr">
                                                <!--................................LEFT NAVIGAION........................-->
                                                <table width="210" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="nav-head">Leave Management
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="glossymenu">
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
                                                                        <li><a href="createdefaultrule.aspx" target="content">Create General Rule</a></li>
                                                                        <li><a href="create_leave_adjustment_rule.aspx" target="content">Create Adjustment Rule</a></li>
                                                                        <%--<li> <a href="create_leave_clubbing_rule.aspx" target="content">Create Clubbing Rule</a></li>--%>
                                                                        <li><a href="overviewrule.aspx" target="content">View / Edit Leave Rule</a></li>
                                                                    </ul>
                                                                </div>
                                                                <a class="menuitem expandable" href="#">Attendance Rule</a>
                                                                <div class="submenu">
                                                                    <ul>
                                                                        <li><a href="Create_leave_attendance_rule.aspx" target="content">Create General Rule</a></li>
                                                                        <li><a href="OverViewAttendanceRule.aspx" target="content">View / Edit Attendance Rule</a></li>
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
                                                                        <li><a href="set_dutyroster.aspx" target="_self">Create Duty Roster</a></li>
                                                                        <li><a href="view_dutyroster.aspx" target="_self">View / Edit Duty Roster</a></li>
                                                                        <%-- <li><a href="viewdutyroster.aspx" target="_self">Export Duty Roster</a></li>--%>
                                                                    </ul>
                                                                </div>
                                                                <a class="menuitem expandable" href="#">Attendance</a>
                                                                <div class="submenu">
                                                                    <ul>
                                                                        <li><a href="attendance.aspx" target="content">Attendance Entry</a></li>
                                                                        <li><a href="../../payroll/admin/process_attendance.aspx" target="content">Compute Attendance</a></li>
                                                                        <li><a href="ProcessAttendence.aspx" target="content">Process Attendance</a></li>
                                                                        <li><a href="AttendenceManually.aspx" target="content">Process Attendance Manually</a></li>
                                                                        <li><a href="applyod.aspx" target="content">Apply OD</a></li>
                                                                        <li><a href="applyleaveByHC.aspx" target="content">Apply Leave</a></li>
                                                                        <li><a href="viewLtCmErGo.aspx" target="content">Late In/ Early Out Time Approval</a></li>

                                                                        <%-- <li><a href="uploadattendance.aspx" target="content">Upload Attendance</a></li>
                                                                    <li><a href="ProcessAttendenceManually.aspx" target="content"> Process Attendance</a></li>--%>
                                                                        <li><a href="Overwrite-attendance.aspx" target="content">Overwrite Attendance</a></li>
                                                                        <li><a href="AttendanceReport.aspx" target="">Attendance Report</a></li>
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
                                                                <%-- <a class="menuitem expandable" href="#">Branch HR Mapping</a>
                                                            <div class="submenu">
                                                                <ul>
                                                                    <li><a href="CreateBranchHR.aspx" target="content">Create Branch HR</a></li>
                                                                    <li><a href="ViewBranchHR.aspx" target="content">View / Edit Branch HR</a></li>
                                                                </ul>
                                                            </div>--%>
                                                                <a class="menuitem expandable" href="#">Report</a>
                                                                <div class="submenu">
                                                                    <ul>
                                                                        <li><a href="../report-dept-attendance.aspx" target="content">Departmentwise Attendance</a></li>
                                                                        <li><a href="viewattendance.aspx" target="content">Datewise Attendance</a></li>
                                                                        <li><a href="report_attendance_dataewise.aspx" target="content">Employeewise Attendance</a></li>
                                                                        <li><a href="../monthwisereport.aspx" target="content">Monthwise Attendance</a></li>
                                                                        <li><a href="../report-leaveregister.aspx" target="content">Leave Register</a></li>
                                                                        <li><a href="../report-calendarview.aspx" target="content">Leave Calendar View</a></li>
                                                                        <li><a href="../employee_detail.aspx" target="content">Employee Leave Balance</a></li>
                                                                        <li><a href="Lopreport.aspx" target="content">LOP List</a></li>
                                                                        <li><a href="ViewAttendancehourwise.aspx" target="content">Hourwise Attendance</a></li>
                                                                        <li><a href="../report_employeeresign.aspx" target="content">Resigned Employee</a></li>
                                                                        <li><a href="../report_approver.aspx" target="content">Reporting Approver Detail</a></li>
                                                                        <li><a href="../report_employee.aspx" target="content">Reporting Employee Detail</a></li>
                                                                    </ul>
                                                                </div>
                                                                <a class="menuitem expandable" href="#">On Demand</a>
                                                                <div class="submenu">
                                                                <ul>
                                                                    <li><a href="showleave_audit.aspx" target="content">Leave Details</a></li>
                                                                    <li><a href="ViewHFReport.aspx" target="content">Non Punched Report</a></li>
                                                                    <li><a href="LeaveEnchasementForm.aspx" target="content">Leave Encashment</a></li>
                                                                    <li><a href="leaveEncashmentReport.aspx" target="content">Leave Encashment Report</a></li>
                                                                    <li><a href="ODReportForm.aspx" target="content">OD Report</a></li>
                                                                    <li><a href="over_write_attendance_update.aspx" target="content">Overwrite Attendance
                                                                        New</a></li>
                                                                    <li><a href="leave_not_applied.aspx" target="content">Mail to Absentee</a></li>
                                                                    <li><a href="leave_not_approved.aspx" target="content">Mail to Leave Not Approved</a></li>
                                                                </ul>
                                                            </div>
                                                                <%-- <a class="menuitem expandable" href="#">On Priority</a>--%>
                                                                <%-- <div class="submenu">
                                                                <ul>
                                                                    <li><a href="showErrorReport.aspx" target="content">Error Report</a></li>
                                                                    <li><a href="uploadErrorReport.aspx" target="content">Error Report Upload</a></li>
                                                                    <li><a href="Report_Attendance.aspx" target="content">ManHour/Attendance/HF/Leave Report</a></li>
                                                                </ul>
                                                            </div>--%>
                                                                <%--<a class="menuitem expandable" href="#">Reports</a>
                                                                <div class="submenu">
                                                                <ul>
                                                                <li></li>
                                                                </ul>
                                                                </div>--%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <!--................................END LEFT NAVIGAION........................-->
                                            </td>
                                            <td width="1%" valign="top">
                                                <img src="../images/5x5.gif" width="10" height="5" />
                                            </td>
                                            <td width="87%" height="450" align="left" valign="top" class="blue-brdr-1">
                                                <iframe name="content" frameborder="0" width="736px" height="495px" src="../leave-main.html"
                                                    scrolling="yes"></iframe>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
