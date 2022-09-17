<%@ Page Title="HRMS-Admin-Home" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Admin_Company_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style type="text/css">
        article, aside, details, figcaption, figure, footer, header, hgroup, menu, nav, section {
            display: block;
        }

        a {
            color: #15c;
            text-decoration: none;
        }

            a:active {
                color: #d14836;
            }

            a:hover {
                text-decoration: underline;
            }

        h1, h2, h3, h4, h5, h6 {
            color: #222;
            font-size: 1.54em;
            font-weight: normal;
            line-height: 24px;
            margin: 0 0 .46em;
        }

        p {
            line-height: 17px;
            margin: 0 0 1em;
        }

        ol, ul {
            list-style: none;
            line-height: 17px;
            margin: 0 0 1em;
        }

        li {
            margin: 0 0 .5em;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
        }

        strong {
            color: #222;
        }

        button, input, select, textarea {
            font-family: inherit;
            font-size: inherit;
        }

            button::-moz-focus-inner, input::-moz-focus-inner {
                border: 0;
            }

        .more-apps .button_aab {
            background: #fff;
            border: solid 1px #fff;
        }

        a.apps-promo-box {
            display: block;
            margin: 0 0px;
            padding: 0px 0px;
            border: solid 1px #fff;
        }

        .apps-promo-box:hover, .apps-promo-box:focus, .more-apps .button_aab:hover, .more-apps .button_aab:focus {
            text-decoration: none;
            border: solid 1px #efefef; /* #cccbc9; */
            background: #efefef;
        }

        .clearfix:after {
            content: ".";
            display: block;
            line-height: 0;
            height: 0;
            clear: both;
            visibility: hidden;
        }

        .clearfix {
            zoom: 1;
            _height: 1px;
        }

        .tooltips, .tooltip-button {
            position: relative;
            overflow: visible !important;
            z-index: 99;
        }


        .more-apps {
            margin: 0 auto;
            padding: 20px;
            border: 0px #000 solid;
            width: 850px;
            height: 550px;
        }

            .more-apps li {
                height: 120px;
                width: 145px;
            }

            .more-apps li {
                display: inline-block;
                float: left;
                /*margin: 40px 25px 0 0;*/
                margin: 20px 20px 45px 30px;
                padding: 0;
                position: relative;
                top: 0px;
                left: 0px;
            }

            .more-apps .button_aab {
                margin: 0px;
                padding: 15px 0;
                text-align: center;
            }

                .more-apps .button_aab img {
                    max-height: 42px;
                    max-width: 42px;
                }

                .more-apps .button_aab .product-name {
                    color: #444;
                    display: block;
                    font-size: 14px;
                    margin-top: .5em;
                    height: 52px;
                    width: 140px;
                }
    </style>
    <div class="division">
        <div class="container">
            <div class="main-bg">

                <!--...............................MID PART.........................-->
                <div class="content">
                    <div class="prod1">
                        <div class="even-more-apps">
                            <ul class="more-apps clearfix" id="more-apps">
                                <li class="tooltip-button">
                                    <div class="button_aab" visible="false" runat="server" id="dv_com_module">
                                        <a class="apps-promo-box" href="Company/AdminPanel.aspx">
                                            <img alt="Company Profile" src="../images/product/company-profile.png" />
                                            <div class="product-name">
                                                Company Profile 
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>
                                <li class="tooltip-button">
                                    <div class="button_aab" visible="false" runat="server" id="dv_emp_module">
                                        <a class="apps-promo-box" href="Employee/AdminPanel.aspx">
                                            <img alt="Employee Profile" src="../images/product/users.png" />
                                            <div class="product-name">
                                                Employee Profile
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>
                                <li class="tooltip-button">
                                    <div class="button_aab" visible="false" runat="server" id="dv_leave_module">
                                        <a class="apps-promo-box" href="../Leave/admin/leaveadmin.aspx">
                                            <img alt="Leave and Attendance" src="../images/product/leave_cal.png" />
                                            <div class="product-name">
                                                Leave and Attendance
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>

                                <li class="tooltip-button">
                                    <div class="button_aab" visible="false" runat="server" id="dv_recruit_module">
                                        <a class="apps-promo-box" href="../Recruitment/Admin/Admin.aspx">
                                            <img alt="Recruitment" src="../images/product/recruitment2.png" />
                                            <div class="product-name">
                                                Recruitment
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>

                                <li class="tooltip-button">
                                    <div class="button_aab" visible="false" runat="server" id="dv_timesheet_module">
                                        <a class="apps-promo-box" href="../TimeSheet/Admin/AdminPanel.aspx">
                                            <img alt="Training" src="../images/product/training.png" />
                                            <div class="product-name">
                                                Time Sheet
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>

                                <li class="tooltip-button">
                                    <div class="button_aab" visible="false" runat="server" id="dv_infocenter_module">
                                        <a class="apps-promo-box" href="Intranet/AdminPanel.aspx">
                                            <!-- <img alt="Reports" src=
                                    "images/icons/product/fusion_tables-64.png">-->
                                            <img alt="Reports" src="../images/product/reports.png" />
                                            <div class="product-name">
                                                Information Center
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>
                                <li class="tooltip-button">
                                    <div id="Div2" class="button_aab" runat="server">
                                        <a class="apps-promo-box" href="../Appraisal/Admin/Welcome.aspx">
<%--                                         <li id="admin" runat="server" class="level1-li Last"><a class="level1-a" href="Appraisal/Admin/Welcome.aspx"--%>
                                            <!-- <img alt="Reports" src=
                                    "images/icons/product/fusion_tables-64.png">-->
                                            <img alt="Reports" src="../images/product/appraisal.png" />
                                            <div class="product-name">
                                                Appraisal
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>
                                <li class="tooltip-button">
                                    <div visible="false" class="button_aab" runat="server" id="dv_payroll_module">
                                        <a class="apps-promo-box" href="../payroll/admin/Payrolladmin.aspx">
                                            <%--     <a class="apps-promo-box" href="#">--%>
                                            <img alt="Payroll" src="../images/product/payroll1.png" />
                                            <div class="product-name">
                                                Payroll
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>

                                <li class="tooltip-button">
                                    <div id="Div1" class="button_aab" runat="server" visible="false">
                                        <a class="apps-promo-box" href="">
                                            <!-- <img alt="Reports" src=
                                    "images/icons/product/fusion_tables-64.png">-->
                                            <img alt="Reports" src="../images/product/reports.png" />
                                            <div class="product-name">
                                                Reports
                                            </div>
                                            <div class="tooltip-content">
                                                &nbsp;
                                            </div>
                                        </a>
                                    </div>
                                </li>                             
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--...............................END MID PART.........................-->
    </div>

</asp:Content>
