<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payrolladmin.aspx.cs" Inherits="payroll_admin_payrolladmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payroll Admin</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/jquery.treeview.css";
         
    </style>
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>
    <script type="text/javascript" src="../../js/timepicker.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>
    <script type="text/javascript" src="../../js/ddaccordion.js"></script>
    <script type="text/javascript"></script>
    <style type="text/css">
        a:focus
        {
            outline: none;
        }
        .blue-brdr
        {
            border: none;
            background: #fff;
            padding: 0px;
            border-left: none;
            border-bottom: none;
            width: 210px;
        }
        * html ul ul li a
        {
            height: 100%;
        }
        * html ul ul li
        {
            margin-top: -1px;
        }
        * html ul li a
        {
            height: 100%;
        }
        * html ul li
        {
            margin-bottom: -1px;
        }
        ul, li, h3, h4
        {
            margin: 0;
            padding: 0;
            list-style: none;
        }
        
        #theMenu
        {
            margin: 0;
            padding: 0;
            width: 210px;
        }
        
        ul ul li a
        {
            display: block;
            color: #02679c;
            padding: 4px 0 4px 30px;
            font-size: small;
            font: normal 11px Tahoma, Helvetica, sans-serif;
            text-decoration: none;
            background: #fff url(../../images/arrows1.gif) no-repeat 20px 8px;
        }
        ul ul li a:hover
        {
            color: #02679c;
            text-decoration: underline;
        }
        ul ul ul li a
        {
            display: block;
            color: #02679c;
            padding: 4px 0 4px 30px;
            font-size: small;
            font: normal 11px Tahoma, Helvetica, sans-serif;
            text-decoration: none;
            background: #fff url(../../images/arrows1.gif) no-repeat 20px 8px;
        }
        ul ul ul li a:hover
        {
            color: #02679c;
            text-decoration: underline;
        }
        
        h3.head a
        {
            color: #08486d;
            display: block;
            background: #d7e9f3 url(../../images/down.gif) no-repeat;
            background-position: 3% 50%;
            padding: 4px 0 4px 21px;
            font: bold 12px/20px Arial, Helvetica, sans-serif;
            text-decoration: none;
            border-bottom: 1px solid #a1c5f2;
            _border-bottom: 2px solid #a1c5f2;
        }
        h3.head a:hover
        {
            color: #08486d;
            background: #d7e9f3 url(../../images/down.gif) no-repeat;
            background-position: 3% 50%;
        }
        h3.selected a
        {
            background: #c6e0ee url(../../images/up.gif) no-repeat;
            background-position: 3% 50%;
            color: #000;
            padding: 4px 0 4px 21px;
        }
        h3.selected a:hover
        {
            background: #c6e0ee url(../../images/up.gif) no-repeat;
            background-position: 3% 50%;
            color: #08486d;
        }
        
        h4.head a
        {
            color: #02679c;
            display: block;
            background: #eff7fa url(../../images/down.gif) no-repeat;
            background-position: 3% 50%;
            padding: 3px 0px 3px 22px;
            font: bold 11px/16px Arial, Helvetica, sans-serif;
            text-decoration: none;
            border-bottom: 1px solid #c9dffb;
        }
        h4.head a:hover
        {
            color: #02679c;
            background: #f7fdff url(../../images/down.gif) no-repeat;
            background-position: 3% 50%;
            text-decoration: none;
        }
        h4.selected a
        {
            background: #f7fdff url(../../images/up.gif) no-repeat;
            background-position: 3% 50%;
            color: #02679c;
            padding: 3px 0px 3px 22px;
        }
        h4.selected a:hover
        {
            background: #f7fdff url(../../images/up.gif) no-repeat;
            background-position: 3% 50%;
            color: #02679c;
        }
     
    </style>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/accordion.js"></script>
    <script type="text/javascript">
        jQuery().ready(function () {
            // applying the settings
            jQuery('#theMenu').Accordion({
                active: 'h3.selected',
                header: 'h3.head',
                alwaysOpen: false,
                animated: true,
                showSpeed: 400,
                hideSpeed: 800
            });
            jQuery('#xtraMenu').Accordion({
                active: 'h4.selected',
                header: 'h4.head',
                alwaysOpen: false,
                animated: true,
                showSpeed: 400,
                hideSpeed: 800
            });
            jQuery('#xtraMenu1').Accordion({
                active: 'h4.selected',
                header: 'h4.head',
                alwaysOpen: false,
                animated: true,
                showSpeed: 400,
                hideSpeed: 800
            });
            jQuery('#xtraMenu2').Accordion({
                active: 'h4.selected',
                header: 'h4.head',
                alwaysOpen: false,
                animated: true,
                showSpeed: 400,
                hideSpeed: 800
            });
            jQuery('#xtraMenu3').Accordion({
                active: 'h4.selected',
                header: 'h4.head',
                alwaysOpen: false,
                animated: true,
                showSpeed: 400,
                hideSpeed: 800
            });
            jQuery('#xtraMenu4').Accordion({
                active: 'h4.selected',
                header: 'h4.head',
                alwaysOpen: false,
                animated: true,
                showSpeed: 400,
                hideSpeed: 800
            });
        });	
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">
        <table width="969" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3" valign="top" class="wht-clr">
                </td>
            </tr>
            <tr>
                <td colspan="3" height="20" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="56%" style="height: 70px;" valign="middle">
                                <img src="~/images/Rossel-Techsys-Logo1(1).png" runat="server" id="imageDynamic" />
                            </td>
                            <td width="44%" align="right">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td colspan="2" align="right">
                                        </td>
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
                <td align="center" colspan="3">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="green-bar">
                        <tr>
                            <td width="50%" height="24" valign="middle" align="left" style="padding-left: 10px;
                                color: #fff; font-weight: bold;">
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
            <tr>
                <td height="5" colspan="3">
                </td>
            </tr>
            <tr>
                <td width="12%" valign="top" class="blue-brdr">
                    <!--................................LEFT NAVIGAION........................-->
                    <ul id="theMenu">
                        <li>
                            <h3 class="head">
                                <a href="javascript:;">Payroll Master</a></h3>
                            <ul id="xtraMenu">
                                <li>
                                    <%--<h4 class="head">
                                        <a href="javascript:;">Pay Period</a></h4>
                                    <ul>
                                        <li><a href="PayPeriod.aspx" target="content">Edit Period</a></li>
                                    </ul>--%>
                                    <h4 class="head">
                                        <a href="javascript:;">Pay Head</a></h4>
                                    <ul>
                                        <li><a href="viewpayheadmaster.aspx" target="content">Edit Head</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Allowances</a></h4>
                                    <ul>
                                        <li><a href="allowancesmaster.aspx" target="content">Create Allowances</a></li>
                                        <li><a href="viewallowances.aspx" target="content">View / Edit Allowances</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Reimbursement</a></h4>
                                    <ul>
                                        <li><a href="reimbursementmaster.aspx" target="content">Create Reimbursement</a></li>
                                        <li><a href="viewreimbursement.aspx" target="content">View / Edit Reimbursement</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Loan/Advances</a></h4>
                                    <ul>
                                        <li><a href="loanadvancesmaster.aspx" target="content">Create Loan/Advances</a></li>
                                        <li><a href="viewloanadvances.aspx" target="content">View/Edit Loan/Advances</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Provident Fund / ESI</a></h4>
                                    <ul>
                                        <li><a href="view_provident_esi.aspx" target="content">Customize Fund</a></li>
                                    </ul>
                                    <%-- <h4 class="head">
                                        <a href="javascript:;">Cost Center</a></h4>
                                    <ul>
                                        <li><a href="cost_center_master.aspx" target="content">Create Cost Center</a></li>
                                        <li><a href="viewcostcenter.aspx" target="content">View / Delete Cost Center</a></li>
                                    </ul>--%>
                                    <h4 class="head">
                                        <a href="javascript:;">Tax Master</a></h4>
                                    <ul>
                                        <li><a href="taxmaster.aspx" target="content">Tax Slab</a></li>
                                        <li><a href="sectionmaster_detail.aspx" target="content">Section Master</a></li>
                                        <li><a href="tax_payer_detail.aspx" target="content">Tax Payer Detail Master</a></li>
                                        <%--   <li><a href="tax_payer_detail_view.aspx" target="content">View/Update Tax Payer Detail
                                            Master</a></li>--%>
                                    </ul>
                                    <%--  <h4 class="head">
                                        <a href="javascript:;">Perquisite Master</a></h4>
                                    <ul>
                                        <li><a href="perquiste-master-detail.aspx" target="content">Create Perquisite</a></li>
                                        <li><a href="perquiste-detail-view.aspx" target="content">Create Perquisite Detail</a></li>
                                    </ul>--%>
                                    <h4 class="head">
                                        <a href="javascript:;">Bank</a></h4>
                                    <ul>
                                        <li><a href="bankmaster.aspx" target="content">Add Bank detail</a></li>
                                        <li><a href="viewbankmaster.aspx" target="content">View/Edit Detail</a></li>
                                    </ul>
                                    <%--<h4 class="head">
                                        <a href="javascript:;">Gratuity</a></h4>
                                    <ul>
                                        <li><a href="create_view_graduity.aspx" target="content">Create/View Gratuity</a></li>
                                    </ul>--%>
                                    <h4 class="head">
                                        <a href="javascript:;">Other Source Inc Master</a></h4>
                                    <ul>
                                        <li><a href="other-source-income.aspx" target="content">Create/View Other Source Inc</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3 class="head">
                                <a href="javascript:;">Payroll Transaction</a></h3>
                            <ul id="xtraMenu1">
                                <li>
                                    <h4 class="head">
                                        <a href="javascript:;">Employee Pay Structure</a></h4>
                                    <ul>
                                        <li><a href="employee_paystructure.aspx" target="content">Create Structure</a></li>
                                        <li><a href="paystructureempview.aspx" target="content">View / Edit Structure</a></li>
                                        <li><a href="viewpaystructureemp.aspx" target="content">Apply New Structure</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Reimbursement</a></h4>
                                    <ul>
                                        <li><a href="apply_reimbursement.aspx" target="content">Sanction Reimbursement</a></li>
                                        <li><a href="view_reimbursement.aspx" target="content">View / Edit Reimbursement</a></li>
                                        <li><a href="reimbursementautocreate.aspx" target="content">Auto-create Reimbursement</a></li>
                                        <%--<li><a href="FullandFinalVariableAllowance.aspx" target="content">Upload Variable Allowance</a></li>--%>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Loan/Advances</a></h4>
                                    <ul>
                                        <li><a href="applyloanadvances.aspx" target="content">Sanction Loan/Advances</a></li>
                                        <li><a href="view_applyloanadvances.aspx" target="content">View Loan/Advances</a></li>
                                        <li><a href="settleloanadvances.aspx" target="content">Loan/Advances Settlement</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Bonus</a></h4>
                                    <ul>
                                        <li><a href="bonus_create.aspx" target="content">Sanction Bonus</a></li>
                                        <li><a href="editbonus.aspx" target="content">View / Edit Bonus</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">Declaration</a></h4>
                                    <ul>
                                        <li><a href="declaration.aspx" target="content">Declaration Form</a></li>
                                        <li><a href="viewdeclaration.aspx" target="content">View / Edit Declaration</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">TDS</a></h4>
                                    <ul>
                                        <%-- <li><a href="Acknowlegement.aspx" target="content">Acknowledgment No.</a></li>
                                        <li><a href="monthly_tds_challan.aspx" target="content">Monthly TDS Challan</a></li>
                                        <li><a href="monthly_tds_challan_view.aspx" target="content">Payment TDS Challan</a></li>
                                        <li><a href="other_source_income.aspx" target="content">Other Source Income</a></li>
                                        <li><a href="view_other_source_income.aspx" target="content">View/Edit Others Source</a></li>--%>
                                        <li><a href="tds_amendment.aspx" target="content">TDS Amendment</a></li>
                                        <li><a href="tds_upload.aspx" target="content">TDS Upload</a></li>
                                    </ul>
                                    <%-- <h4 class="head">
                                        <a href="javascript:;">Perquisite</a></h4>
                                    <ul>
                                        <li><a href="perquisite-employee-create.aspx" target="content">Employee Perquisite Form</a></li>
                                        <li><a href="perquisite-employee-viewedit.aspx" target="content">Edit Perquisite Form</a></li>
                                        <li><a href="perquisite-employee-accommodation.aspx" target="content">Lease Detail</a></li>
                                    </ul>--%>
                                    <h4 class="head">
                                        <a href="javascript:;">Leave Encashment</a></h4>
                                    <ul>
                                       <%-- <li><a href="GratuitySanction.aspx" target="content">Sanction Gratuity</a></li>--%>
                                        <li><a href="EncashmentExemption.aspx" target="content">Encashment Exmp. u/s 10</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3 class="head">
                                <a href="javascript:;">Process Salary Master</a></h3>
                            <ul id="xtraMenu3">
                                <li>
                                    <%-- <h4 class="head">
                                        <a href="javascript:;">Process Salary</a></h4>--%>
                                    <ul>
                                        <%--<li><a href="process_attendance.aspx" target="content">Process Attendance</a></li>--%>
                                        <li><a href="overtimeupload.aspx" target="content">Upload Over Time</a></li>
                                        <li><a href="Add_Discrepancy.aspx" target="content">Add Discrepancy</a></li>
                                        <%-- <li><a href="uploadnightattendanceallowance.aspx" target="content">Compute Variable
                                            Allownce</a></li>--%>
                                        <%--    <li><a href="AttendanceCumNightAllowance.aspx" target="content">Attendance-Night Allowance</a></li>--%>
                                        <li><a href="uploadallowance.aspx" target="content">Upload Earning/ deductions Allowance</a></li>
                                       <%-- <li><a href="tds_upload.aspx" target="content">TDS Upload</a></li>--%>
                                        <li><a href="process_attendance_salary.aspx" target="content">Process Salary Company/Employee</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h3 class="head">
                                <a href="javascript:;">Payroll Reports</a></h3>
                            <ul id="xtraMenu2">
                                <li>
                                    <h4 class="head">
                                        <a href="javascript:;">Salary Report</a></h4>
                                    <ul>
                                        <%-- <li><a href="sendmailtoallemployee.aspx" target="content">Payslip Print / Mail</a></li>--%>
                                        <li><a href="view_payslip.aspx" target="content">View Pay Slip</a></li>
                                        <li><a href="DownloadAllEmpSalarySlip.aspx" target="content">Download Payslip</a></li>
                                        <li><a href="bankstatementform.aspx" target="content">Payment Statement</a></li>
                                        <li><a href="Viewpaymenttransactiondetails.aspx" target="content">View/Edit Transaction</a></li>
                                        <%--  <li><a href="uploadallowance_view.aspx" target="content">Allowance View</a></li>--%>
                                        <%--    <li><a href="AttendanceCumNightAllowance.aspx" target="content">Attendance-Night Allowance</a></li>--%>
                                        <%-- <li><a href="costofemployeereport.aspx" target="content">Cost of Employee Report</a></li>--%>
                                        <%-- <li><a href="SalarySheet.aspx" target="content">Salary Sheet</a></li>
                                        <li><a href="costofemployee.aspx" target="content">Cost Of Employee</a></li>--%>
                                        <%--<li><a href="SalarySheetNew.aspx" target="content">Cost Of Employee</a></li>--%>
                                        <li><a href="ComputeItComputation.aspx" target="content">CTC</a></li>
                                        <li><a href="reports/ReportForm22.aspx" target="content">Form 22</a></li>
                                        <li><a href="reports/report-Annexure22.aspx" target="content">Form 22 Annexure</a></li>
                                        <%-- <li><a href="report-balance-reimbursement.aspx" target="content">Reimbursement</a></li>
 
                                        <li><a href="PerformanceInsentive.aspx" target="content">Performance Incentive</a></li>--%>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">PF Reports</a></h4>
                                    <ul>
                                        <li><a href="reports/report-pfform5.aspx" target="content">Form 5</a></li>
                                        <li><a href="reports/report-pfform10.aspx" target="content">Form 10</a></li>
                                        <li><a href="reports/report-pfform3A.aspx" target="content">Form 3A</a></li>
                                        <li><a href="reports/report-pfform6A.aspx" target="content">Form 6A</a></li>
                                        <li><a href="reports/report-pfform12A.aspx" target="content">Form 12A</a></li>
                                        <li><a href="reports/report-pfmonthly.aspx" target="content">Monthly Report</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">ESI Reports</a></h4>
                                    <ul>
                                        <li><a href="reports/report-esiForm6.aspx" target="content">Form 32</a></li>
                                        <%--<li><a href="reports/report-esimonthly.aspx" target="content">Monthly Report</a></li>--%>
                                        <li><a href="reports/MonthlyESIReportNew.aspx" target="content">Monthly ESI Report</a></li>
                                        <li><a href="reports/report-esiForm6A.aspx" target="content">Form 6</a></li>
                                    </ul>
                                    <h4 class="head">
                                        <a href="javascript:;">TDS Reports</a></h4>
                                    <ul>
                                        <%-- <li><a href="reports/Form24Q.aspx" target="content">Generate Form 16,24Q,27A,FVU</a></li>
                                        <li><a href="reports/report-Form16.aspx" target="content">Form 16,Form 16AA,ITR 1 Ack,ITR
                                            1</a></li>--%>
                                        <li><a href="reports/report-Form16.aspx" target="content">Form 16</a></li>
                                        <li><a href="report-declaration.aspx" target="content">Saving & Investment</a></li>
                                        <li><a href="report-tax-variance.aspx" target="content">Tax Deducted Detail</a></li>
                                        <%-- <li><a href="report-tax-variance-till.aspx" target="content">Tax Deducted Detail(Till)</a></li>
                                        <li><a href="projectedtaxmasterview.aspx" target="content">Projected Tax Report</a></li>--%>
                                    </ul>
                                    <%-- <h4 class="head">
                                        <a href="javascript:;">Leave Reports</a></h4>
                                    <ul>
                                        <li><a href="payrollleavereport.aspx" target="content">Used / Balance Leave</a></li>
                                    </ul>--%>
                                </li>
                            </ul>
                        </li>
                        <%--<li>
                            <h3 class="head">
                                <a href="javascript:;">Master Employee</a></h3>
                            <ul id="xtraMenu4">
                                <li>
                                    <h4 class="head">
                                        <a href="javascript:;">Master Report</a></h4>
                                    <ul>
                                        <li><a href="../empview.aspx" target="content">Master Employee View</a></li>
                                        <li><a href="update_dutyroaster.aspx" target="content">Update Duty Roaster</a></li>
                                        <li><a href="update_card.aspx" target="content">Update Card No</a></li>
                                        <li><a href="tds_upload.aspx" target="content">TDS Upload</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>--%>
                        <h3 class="head">
                            <a href="javascript:;">Full and Final</a></h3>
                        <ul id="Ul1">
                            <li>
                                <ul>
                                   <%-- <li><a href="calculate_gratuity.aspx" target="content">Calculate_Gratuity</a></li>
                                    <li><a href="ProcessAttendanceForfullandFinal.aspx" target="content">Process Attendance</a></li>--%>
                                   <%-- <li><a href="ProcessAttendanceForFandF.aspx" target="content">Process Attendance</a></li>--%>
                                    <%--<li><a href="uploadnightattendanceallowance.aspx" target="content">Compute Variable Allownce</a></li>
                                    <li><a href="FullandFinalVariableAllowance.aspx" target="content">Upload Variable Allowance</a></li>
                                    <li><a href="process_attendance_salary.aspx" target="content">Process Salary Branch/Employee</a></li>--%>
                                    <li><a href="FullandFinalEmployee.aspx?Empcodeeditfnf=insert" target="content">Full and Final Report</a></li>
                                     <li><a href="ViewFNFInfo.aspx" target="content">Edit/View FNF</a></li>
                                </ul>
                            </li>
                        </ul>
                    </ul>
                    <!--................................END LEFT NAVIGAION........................-->
                </td>
                <td width="1%" valign="top">
                    <img src="../../images/5x5.gif" width="10" height="5" />
                </td>
                <td width="87%" height="450" align="left" valign="top" class="blue-brdr-1">
                    <iframe name="content" frameborder="0" width="736px" height="495px" src="../payroll-main.html"
                        scrolling="yes"></iframe>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
