<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave-user.aspx.cs" Inherits="leave_dutyleave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<title>Acuminous Software Intranet</title>--%>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="12%" valign="top" class="blue-brdr">
                    <!--................................LEFT NAVIGAION........................-->
                    <table width="210" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="nav-head">
                                Leave Activities
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="glossymenu">
                                        <div id="emp" runat="server">
                                       <a class="menuitem expandable" href="#">Self service</a>
                                       <div class="submenu">
                                       <ul>
                                       <li><a href="applyleave.aspx" target="_self">Apply Leave</a></li>
                                       <li><a href="Admin/applyod.aspx" target="_self">Apply OD</a></li>
                                       <li><a href="ViewApplyOd.aspx?btnval=0" target="_self">View Apply OD</a></li>
                                       <li><a href="compoff_attendance.aspx" target="_self">Mark Comp-Off</a></li>
                                       <li><a href="my_balance_leave.aspx" target="">Balance Leave</a></li>
                                       <li><a href="leave_status.aspx?leavestatus=0&compoffstatus=0" target="">My Leave Status</a></li>
                                       <li><a href="AttendanceReport.aspx" target="">My Attendence</a></li>
                                        </ul>
                                        </div>
                                        </div>
                                        <div id="manager" runat="server">
                                         <a class="menuitem expandable" href="#">Manager service</a>
                                        <div  class="submenu">
                                        <ul>
                                        <li><a href="leave_approval.aspx?leavestatus=0&hr=0" target="">Pending for approval</a></li>
                                        <li><a href="EmployeeApproved.aspx" target="_self">Pending for Approvals OD</a></li>
                                            <li><a href="ViewApplyOd.aspx?btnval=1" target="_self">View Apply OD</a></li>
                                       <%-- <li><a href="compoff_approval.aspx?compoffstatus=0&hr=0" target="">Comp-Off Pending for approval</a></li>--%>
                                        <li><a href="DelegateApproval.aspx" target="_self">Delegate my leave rights</a></li>
                                        <li><a href="view_delegated_job.aspx" target="">Leave right delegation request</a></li>
                                        <li><a href="View_sended_delegation.aspx" target="">View my delegation status</a></li>
                                        <li><a href="approverleaveregister.aspx" target="">Leave register</a></li>
                                        <li><a href="LeaveapprovalHistory.aspx?leavestatus=0&hr=0" target="">Approved & rejected leave</a></li>
                                        <li><a href="BalanceHistory.aspx" target="">Leave balance</a></li>
                                         <li><a href="report-calendarview.aspx" target="">Leave Calender View</a></li>
                                        <li><a href="SubEmpAttReport.aspx" target="">Attendance Report</a></li>
                                        </ul>
                                        </div>
                                        </div>
                                        <%-- <div id="showDirector" runat="server">
                                            <a class="menuitem" href="leave_approvalDirector.aspx?leavestatus=1&hr=1" target="">Pending
                                                for Director Approval </a>
                                        </div>--%>
                                     
                                        <div id="ShowHr" runat="server">
                                        <a class="menuitem expandable" href="#">HC service</a>
                                        <div class="submenu">
                                        <ul>
                                        <li><a href="leave_approval_hr.aspx?leavestatus=0&hr=1" target="">Leave status
                                                for HC </a></li>
                                        <li><a href="HRleavehistory.aspx?leavestatus=0&hr=1" target="">Approved & rejected leave</a></li>
                                        <li><a href="report-leaveregister.aspx" target="">Leave Register</a></li>
                                            <li><a href="Comp-offcredited.aspx" target="">Marked Com-Off Details</a></li>
                                        </ul>
                                        </div>
                                        </div>
                                        
                                        <div id="Reports" runat="server" visible="false">
                                        <a class="menuitem expandable" href="#">Reports</a>
                                        <div class="submenu">
                                            <ul>
                                                <li><a href="report-leaveregister.aspx">Leave Details</a></li>
                                                <li><a href="employee_detail.aspx">Leave Balance Report</a></li>
                                                <li><a href="uploadleavedetails.aspx" target="content">Upload Employee Leave Detail</a></li>
                                                <li><a href="uploadcompoffdetails.aspx" target="content">Upload Employee Comp-Off Detail</a></li>
                                            </ul>
                                        </div>
                                        </div>
                                    </div>                                
                            </td>
                        </tr>
                    </table>
                    <!--................................END LEFT NAVIGAION........................-->
                </td>
                <td width="1%" valign="top">
                    <img src="images/5x5.gif" width="10" height="5" />
                </td>
                <td width="100%" valign="top" align="left" class="blue-brdr-1">
                    <iframe name="content" runat="server" id="frame" frameborder="0" width="718px" height="495px"
                        src="leave-main.html" scrolling="no"></iframe>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
