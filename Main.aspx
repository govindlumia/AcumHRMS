<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<title>Acuminous Software</title>--%>
      <title>Acuminous Software Pvt. Ltd</title>
    <!-- marque -->
    <style type="text/css">
        /*Example CSS for the two demo scrollers*/
        #button
        {
            position: relative;
            width: 200px;
            height: 30px;
            line-height: 27px;
            display: block;
            text-align: left;
        }
        #two
        {
            background: none repeat scroll 0 0 #f3f3f3;
            border-radius: 10px;
            color: #333333;
            width: 180px;
            height: 0;
            overflow: hidden;
            padding-left: 5px;
            left: 0;
            line-height: 20px;
            position: absolute;
            font-size: 12px;
            top: 30px;
            -webkit-transition: all .3s ease;
            -moz-transition: all .3s ease;
            -ms-transition: all .3s ease;
            -o-transition: all .3s ease;
            transition: all .3s ease;
        }
        #button:hover > #two
        {
            display: block;
            left: 0px;
            height: 100px;
            z-index: 1000;
        }
        
        #two2
        {
            /*background: none repeat scroll 0 0 #f3f3f3;*/
            background: none repeat scroll 0 0 #f3f3f3;
          
            border-radius: 10px;
            color: #333333;
            width: 220px;
            height: 0;
            overflow: hidden;
            padding-left: 5px;
            left: 30%;
            line-height: 20px;
            position: absolute;
            font-size: 12px;
            top: 15px;
            -webkit-transition: all .3s ease;
            -moz-transition: all .3s ease;
            -ms-transition: all .3s ease;
            -o-transition: all .3s ease;
            transition: all .3s ease;
        }
        #button:hover > #two2
        {
            display: block;
            left: 30%;
            height: 100px;
            z-index: 1000;
        }
        #pscroller1
        {
            width: 260px;
            height: 110px;
            padding: 5px;
        }
        
        #pscroller2 a
        {
            text-decoration: none;
        }
        
        .someclass
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            color: #404040;
            text-decoration: none;
            line-height: 18px;
        }
        .someclass a
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: normal;
            color: #404040;
            text-decoration: none;
            line-height: 18px;
        }
        .someclass a:hover
        {
            color: #1b2980;
            text-decoration: underline;
        }
        body {
    background: #208cb5d1;
}    
           
    </style>
    <style type="text/css">
        .black_overlay123
        {
            display: none;
            position: absolute;
            top: 0%;
            left: 0%;
            width: 100%;
            height: 100%;
            background-color: black;
            z-index: 1001;
            -moz-opacity: 0.8;
            opacity: .80;
            filter: alpha(opacity=80);
        }
        .white_content123
        {
            display: none;
            position: absolute;
            top: 25%;
            left: 25%;
            width: 500px;
            height: 500px;
            padding: 16px;
            border: 16px solid #038ec2;
            background-color: white;
            z-index: 1002;
        }

     
     
    </style>

   
    <script type="text/javascript">
        function global() {
            window.open("client_global-auto.html", "blank", "toolbar=no,width=500,height=200");
        }
        function zerox() {
            window.open("client_xerox.html", "blank", "toolbar=no,width=500,height=200");
        }
        function derc() {
            window.open("client_derc.html", "blank", "toolbar=no,width=500,height=200");
        }



        /*Example message arrays for the two demo scrollers*/

        var pausecontent = new Array()
        pausecontent[0] = '<img src="images/xerox-logo-small.gif" /><br /> <a href="#" onClick="zerox()"> Please let your team know that we at Xerox have appreciation for the software development work that IAP is carrying out for us...</a> <br /><br /><br />'

        pausecontent[1] = '<img src="images/globalauto-small.gif" /><br /> <a href="#" onClick="global()"> We appreciate the approach of IAP to provide us with an IT solution that helps us manage our business efficiently....</a> <br /><br /><br />'

        pausecontent[2] = '<img src="images/derc-logo.gif" /><br /> <a href="#" onClick="derc()">  We appreciate efforts of M/s IAP Company Ltd for successful implementation and wish them many successful projects ahead.</a> <br /><br /><br />'

    </script>
    <script type="text/javascript">

        /***********************************************
        * Pausing up-down scroller- © Dynamic Drive (www.dynamicdrive.com)
        * This notice MUST stay intact for legal use
        * Visit http://www.dynamicdrive.com/ for this script and 100s more.
        ***********************************************/

        function pausescroller(content, divId, divClass, delay) {
            this.content = content //message array content
            this.tickerid = divId //ID of ticker div to display information
            this.delay = delay //Delay between msg change, in miliseconds.
            this.mouseoverBol = 0 //Boolean to indicate whether mouse is currently over scroller (and pause it if it is)
            this.hiddendivpointer = 1 //index of message array for hidden div
            document.write('<div id="' + divId + '" class="' + divClass + '" style="position: relative; overflow: hidden"><div class="innerDiv" style="position: absolute; width: 100%" id="' + divId + '1">' + content[0] + '</div><div class="innerDiv" style="position: absolute; width: 100%; visibility: hidden" id="' + divId + '2">' + content[1] + '</div></div>')
            var scrollerinstance = this
            if (window.addEventListener) //run onload in DOM2 browsers
                window.addEventListener("load", function () { scrollerinstance.initialize() }, false)
            else if (window.attachEvent) //run onload in IE5.5+
                window.attachEvent("onload", function () { scrollerinstance.initialize() })
            else if (document.getElementById) //if legacy DOM browsers, just start scroller after 0.5 sec
                setTimeout(function () { scrollerinstance.initialize() }, 500)
        }

        // -------------------------------------------------------------------
        // initialize()- Initialize scroller method.
        // -Get div objects, set initial positions, start up down animation
        // -------------------------------------------------------------------

        pausescroller.prototype.initialize = function () {
            this.tickerdiv = document.getElementById(this.tickerid)
            this.visiblediv = document.getElementById(this.tickerid + "1")
            this.hiddendiv = document.getElementById(this.tickerid + "2")
            this.visibledivtop = parseInt(pausescroller.getCSSpadding(this.tickerdiv))
            //set width of inner DIVs to outer DIV's width minus padding (padding assumed to be top padding x 2)
            this.visiblediv.style.width = this.hiddendiv.style.width = this.tickerdiv.offsetWidth - (this.visibledivtop * 2) + "px"
            this.getinline(this.visiblediv, this.hiddendiv)
            this.hiddendiv.style.visibility = "visible"
            var scrollerinstance = this
            document.getElementById(this.tickerid).onmouseover = function () { scrollerinstance.mouseoverBol = 1 }
            document.getElementById(this.tickerid).onmouseout = function () { scrollerinstance.mouseoverBol = 0 }
            if (window.attachEvent) //Clean up loose references in IE
                window.attachEvent("onunload", function () { scrollerinstance.tickerdiv.onmouseover = scrollerinstance.tickerdiv.onmouseout = null })
            setTimeout(function () { scrollerinstance.animateup() }, this.delay)
        }


        // -------------------------------------------------------------------
        // animateup()- Move the two inner divs of the scroller up and in sync
        // -------------------------------------------------------------------

        pausescroller.prototype.animateup = function () {
            var scrollerinstance = this
            if (parseInt(this.hiddendiv.style.top) > (this.visibledivtop + 5)) {
                this.visiblediv.style.top = parseInt(this.visiblediv.style.top) - 5 + "px"
                this.hiddendiv.style.top = parseInt(this.hiddendiv.style.top) - 5 + "px"
                setTimeout(function () { scrollerinstance.animateup() }, 50)
            }
            else {
                this.getinline(this.hiddendiv, this.visiblediv)
                this.swapdivs()
                setTimeout(function () { scrollerinstance.setmessage() }, this.delay)
            }
        }

        // -------------------------------------------------------------------
        // swapdivs()- Swap between which is the visible and which is the hidden div
        // -------------------------------------------------------------------

        pausescroller.prototype.swapdivs = function () {
            var tempcontainer = this.visiblediv
            this.visiblediv = this.hiddendiv
            this.hiddendiv = tempcontainer
        }

        pausescroller.prototype.getinline = function (div1, div2) {
            div1.style.top = this.visibledivtop + "px"
            div2.style.top = Math.max(div1.parentNode.offsetHeight, div1.offsetHeight) + "px"
        }

        // -------------------------------------------------------------------
        // setmessage()- Populate the hidden div with the next message before it's visible
        // -------------------------------------------------------------------

        pausescroller.prototype.setmessage = function () {
            var scrollerinstance = this
            if (this.mouseoverBol == 1) //if mouse is currently over scoller, do nothing (pause it)
                setTimeout(function () { scrollerinstance.setmessage() }, 100)
            else {
                var i = this.hiddendivpointer
                var ceiling = this.content.length
                this.hiddendivpointer = (i + 1 > ceiling - 1) ? 0 : i + 1
                this.hiddendiv.innerHTML = this.content[this.hiddendivpointer]
                this.animateup()
            }
        }

        pausescroller.getCSSpadding = function (tickerobj) { //get CSS padding value, if any
            if (tickerobj.currentStyle)
                return tickerobj.currentStyle["paddingTop"]
            else if (window.getComputedStyle) //if DOM2
                return window.getComputedStyle(tickerobj, "").getPropertyValue("padding-top")
            else
                return 0
        }

    </script>
    <!-- End marque -->
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="Css/blue1.css" rel="stylesheet" type="text/css" />
    <link href="images/family.css" rel="stylesheet" type="text/css" />
    <!-- CSS -->
    <link rel="stylesheet" href="images/default.css" media="screen,projection" type="text/css" />
    <link rel="stylesheet" href="images/lightbox.css" media="screen,projection" type="text/css" />
    <!-- JavaScript -->
    <script type="text/javascript" src="images/prototype.js"></script>
    <script type="text/javascript" src="images/lightbox.js"></script>
    <style type="text/css">
        #header-wrapper
        {
            height: 38px;
            border-bottom: 1px #c7c7c7 solid; /* 1px #cdcdcd solid;*/
            background: #37a0f3; /* #037fb3; #cb7401; #2d2d2d;   #f1f1f1; */
        }
        /* Top menu */
        html, input, textarea
        {
            font-family: "Open Sans" ,arial,sans-serif;
        }
        html
        {
            line-height: 1.54;
        }
        h5, h6, pre, table, input, textarea, code
        {
            font-size: 1em;
        }
        
        
        /*#maia-main{margin:auto;max-width:978px;  border: 5px #fff solid;}
#maia-main{clear:both;margin-top:30px}
#maia-main:after{clear:both;content:" ";display:block;height:0;visibility:hidden}
#maia-main>img,#maia-main>iframe,#maia-main>*>img,#maia-main>*>iframe,.maia-cols>div>img,.maia-cols>div>iframe,.maia-cols>div>*>img,.maia-cols>div>*>iframe{-moz-box-sizing:border-box;box-sizing:border-box;max-width:100%}

#maia-main{max-width:978px;margin:0 auto; border: 1px #fff solid;  }*/
        
        #maia-nav
        {
            margin: 0px auto;
            max-width: 968px;
            position: relative;
            z-index: 1000;
            border: 0px #fff solid;
        }
        h5, h6, p
        {
            font-family: "Open Sans" ,arial,sans-serif;
        }
        h1, h2, h3, h4, p.intro, #homepage-feed .maia-nav-aux li, .navmenu li a, .in-page-nav li a, .gweb-lightbox-title-close, .customers-lb-title-close, .gweb-lightbox-caption, .apps-promo-box .featured, .cs-dialog-title h1, .cs-dialog-title p, .cs-dialog-title a, .cs-dialog-title .note, .cs-dialog-buttons .page-indicator, .cs-dialog label, .cs-dialog p, .cs-dialog-thanks-body p, #pricing .info .cost
        {
            font-family: "Open Sans" ,arial,sans-serif;
        }
        
        .navmenu
        {
            float: left;
            list-style: none;
            margin: 0;
            padding: 0;
            border: 0px #fff solid;
        }
        .navmenu li a.active
        {
            color: #fff;
            font-weight: 100;
        }
        .navmenu li
        {
            position: relative;
        }
        .navmenu li img
        {
            padding: 0 0 2px 4px;
        }
        .navmenu li a
        {
            color: #f4f0f0;
            font-weight: normal;
            font-size: 13px;
            text-decoration: none;
            border: 0px #fff solid;
        }
        .navmenu li a:hover
        {
            color: #fff;
            text-decoration: none;
        }
        .navmenu li, .navmenu li.last:hover, .navmenu li.last.navmenu-hover
        {
            float: left;
            font-size: 1.25em;
            margin: 0 !important;
            padding: 5px 20px 4px 0;
            border: 0px #fff solid;
        }
        .gweb-navmenu-drop:hover
        {
            text-decoration: none;
        }
        .navmenu li:hover, .navmenu li.navmenu-hover
        {
            background-position: 0 -31px;
        }
        .navmenu li ul li a:hover
        {
            background-color: none /* #e7f3ff */;
            color: #555;
            text-decoration: underline;
        }
        .navmenu li ul
        {
            background: #fff;
            background: linear-gradient(top,#dff0ff 0,#fbfbfb 14%,#fbfbfb 100%);
            -moz-box-shadow: 0 3px 3px rgba(0,0,0,.3);
            -webkit-box-shadow: 0 3px 3px rgba(0,0,0,.3);
            box-shadow: 0 3px 3px rgba(0,0,0,.3);
            border: solid 3px #e2e2e2;
            border-top: none;
            display: none;
            left: -12px;
            margin: 0;
            width: 180px;
            padding-top: 5px;
            position: absolute;
            top: 39px;
        }
        .navmenu li:hover ul
        {
            display: block;
        }
        .navmenu li ul li
        {
            font-size: 12px;
            margin: 0px;
            overflow: hidden;
            padding: 0px;
            width: 100%;
            border: 0px #000 solid;
        }
        .navmenu li ul li a
        {
            color: #555;
            display: block;
            font-weight: normal;
            font-size: 12px;
            outline: none;
            padding: 9px 0px;
        }
        
        
        .arrow-down
        {
            background: url(images/ui_sprite.png) -40px -15px no-repeat;
            height: 6px;
            position: absolute;
            right: 8px;
            top: 21px;
            width: 8px;
            padding: 4px 0px 0px 0;
            border: 0px #fff solid;
        }
       .middle {
    background: #208cb5d1;
}    
    </style>
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="images/topmenu.css" />
    <script language="JavaScript" src="js/slideshow.js" type="text/JavaScript"></script>
    <!-- Dynamic SlideShow -->
    <%--<script language="javascript" type="text/javascript">
        var Pic = new Array();
        var preLoad = new Array();
        var t;
        var j = 0;
        var slideShowSpeed = 5000;
        var crossFadeDuration = 10;
        var p;

        function GetImages() {
            $.ajax({
                type: "POST",
                url: "Main.aspx/GetImages",
                data: "{}",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: OnSuccess,
                error: OnError
            });
        }
        function OnSuccess(data) {

            for (var i = 0; i < data.d.length; i++) {
                Pic[i] = data.d[i];
            }
            slideShowDynamic();
        }
        function OnError(data) {

        }

        function slideShowDynamic() {
            p = Pic.length;

            for (i = 0; i < p; i++) {
                preLoad[i] = new Image();
                preLoad[i].src = Pic[i];
            }

            runSlideShow();
        }


        function runSlideShow() {
            if (document.all) {

                document.images.SlideShow.style.filter = "blendTrans(duration=2)";

                document.images.SlideShow.style.filter = "blendTrans(duration=crossFadeDuration)";

                document.images.SlideShow.filters.blendTrans.Apply();
            }

            document.images.SlideShow.src = preLoad[j].src;

            if (document.all) {
                document.images.SlideShow.filters.blendTrans.Play();
            }
            j = j + 1;
            if (j > (p - 1)) j = 0;
            t = setTimeout('runSlideShow()', slideShowSpeed);
        }
    </script>--%>
</head>
<body onload="runSlideShow()" >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="main">
        <div style="clear: both">
        </div>
        <%--style="background-color: #208cb5d1;--%>
        <div class="middle">
            <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="top" background="images/bg.jpg">
                        <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td bgcolor="#ffffff">
                                    <table width="970" height="60" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="148" valign="middle">
                                                <%--<a href="Main.aspx" style="border: 0">--%>
                                                    <%--<img src="images/Rossel-Techsys-Logo1(1).png" alt="Acuminous Software" align="absmiddle" />--%>
                                                     <a href="http://acuminoussoftware.com/">
                                                          <img src="images/product/Rossel-Techsys-Logo1(1).png" alt="Acuminous Software" style="width:100%" align="absmiddle" /></a>  
                                                <%--</a>--%>
                                            </td>
                                            <td width="832" valign="middle">
                                                <table width="98%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <img src="images/5x5.gif" width="5" height="8">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-repeat: no-repeat;">
                                                            <img src="images/5x5.gif" width="5" height="12" alt="">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-repeat: no-repeat;">
                                                            <table border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div id="button">
                                                                            <div align="right">
                                                                                <a href="#" class="homelinks">Welcome
                                                                                    <asp:Label runat="server" ID="lblName" Text=""></asp:Label>
                                                                                </a>&nbsp;<img src="images/welcome-icon.jpg" alt="" />
                                                                            </div>
                                                                            <div id="two">
                                                                                <strong>Name: </strong>
                                                                                <asp:Label runat="server" ID="lblNameA" Text=""></asp:Label>
                                                                                <br />
                                                                                <strong>Department:</strong>
                                                                                <asp:Label runat="server" ID="lblDept" Text=""></asp:Label><br>
                                                                                <strong>Designation:</strong>
                                                                                <asp:Label runat="server" ID="lblDesig" Text=""></asp:Label></div>
                                                                        </div>
                                                                    </td>
                                                                    <td align="center">
                                                                        <img src="images/verticle-line1.gif" width="24" height="10" alt="" />
                                                                    </td>
                                                                    <td width="70">
                                                                        <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click">Log out</asp:LinkButton>
                                                                        &nbsp;<img src="images/icon_logout.jpg" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="Navigation" style="margin-top: 20px">
                                        <!-- hash#BeginLibraryItem "/library/root_navigation.lbi" -->
                                        <div class="Navigation">
                                            <div class="TopMenuCnt">
                                                <div id="dropList">
                                                    <ul id="menu">
                                                        <li class="level1-li sub" id="hompage" style="margin-left: 4px;"><a class="level1-a" href="main.aspx"
                                                            title="Corporate">Home
                                                            <!--[if gte IE 7]><!-->
                                                        </a></li>
                                                        <li class="level1-li sub"><a class="level1-a" href="#" title="My Company">My Company
                                                        </a>
                                                            <%--<div class="listholder col3">
                                                                <div class="listcol">
                                                                    <ul>
                                                                        <li><a href="intranet/notification.aspx" title="notifications">notifications</a></li>
                                                                        <li><a href="intranet/events.aspx" title="events">events</a></li>
                                                                        <li><a href="intranet/announcements.aspx" title="news">news</a></li>
                                                                        <li><a href="intranet/companyachievements.aspx" title="press release">press release</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>--%>
                                                        </li>
                                                      <%--  <li class="level1-li sub"><a class="level1-a" href="#" title="my company">information
                                                            center </a>
                                                            <div class="listholder col3">
                                                                <div class="listcol">
                                                                    <ul>
                                                                        <li><a href="intranet/manuals.aspx" title="manuals">manuals</a></li>
                                                                        <li><a href="intranet/policydockit.aspx" title="policies">policies</a></li>
                                                                        <li><a href="intranet/productinformation.aspx" title="product information">product information</a></li>
                                                                        <li><a href="intranet/trainingdocuments.aspx" title="traning doc">training documents</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </li>--%>
                                                          <li class="level1-li sub"><a class="level1-a" href="#" title="My Workplace">My Workplace
                                                        </a>
                                                            <div class="listHolder col3">
                                                                <div class="listCol">
                                                                    <ul>
                                                                        <li><a href="#" title="Suggestions">Suggestions</a></li>
                                                                        <li><a href="#" title="Feedback">Feedback</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li class="level1-li sub"><a class="level1-a" href="#" title="Applications">ESS
                                                        </a>
                                                            <div class="listHolder col3">
                                                                <div class="listCol">
                                                                    <ul>
                                                                        <li><a href="Leave/leave.aspx" title="Leave Management">Leave Management</a></li>
                                                                        <li><a href="TimeSheet/User/UserPanel.aspx" title="TimeSheet Management">TimeSheet Management</a></li>
                                                                        <li><a href="Recruitment/User/User.aspx" title="TimeSheet Management">Recruitment</a></li>
                                                                    </ul>
                                                                </div>
                                                            </div>
                                                        </li>
                                                        <li id="admin" runat="server" class="level1-li Last"><a class="level1-a" href="Admin/Home.aspx"
                                                          <%-- <li id="admin" runat="server" class="level1-li Last"><a class="level1-a" href="Appraisal/Admin/Welcome.aspx"--%>
                                                            title="Admin Section">Admin Section </a></li>
                                                    </ul>
                                                </div>
                                                
                                            </div>
                                        </div>
                                        <!-- #EndLibraryItem -->
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#fff">
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="74%" valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Timer ID="Timer1" Interval="10000" runat="server" />
                                                            <asp:UpdatePanel ID="up1" runat="server">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <asp:AdRotator ID="banner_rotate" runat="server" ImageUrlField="FilePath" AlternateTextField="ImageName"
                                                                        Width="730" Height="144" NavigateUrlField="URL" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <%--<img src="images/banner/1.jpg" name="SlideShow" width="730" height="144">--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="31%" valign="top" style="background: #f3f5f7; border: 1px #cdcdcd solid;
                                                                        border-top: none;">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/5x5.gif" width="5" height="7" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="209" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="29" background="images/left-box-top1.jpg">
                                                                                                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="79%" class="bottomDiv-header-black" style="color: #323232;">
                                                                                                            Action Items
                                                                                                        </td>
                                                                                                        <td width="21%" align="right">
                                                                                                            <%-- <img src="images/folder_open.gif" width="16" height="16" alt=""/>--%>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="108" valign="top" background="images/left-box-middle.jpg">
                                                                                                <table width="96%" border="0" align="center" cellpadding="3" cellspacing="1">
                                                                                                    <asp:Repeater ID="rptenterprise" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <tr>
                                                                                                                <td width="6%" align="center">
                                                                                                                    <img src="images/arrows1.gif" width="3" height="5">
                                                                                                                </td>
                                                                                                                <td width="94%">
                                                                                                                    <a href="<%#DataBinder.Eval(Container.DataItem, "url")%>">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "linktitle")%>
                                                                                                                    </a>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/left-box-bottom.jpg" width="209" height="4">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/5x5.gif" width="5" height="17">
                                                                                </td>
                                                                            </tr>
                                                                            <%-- <tr>
                                                                                <td>
                                                                                    <table width="209" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="29" background="images/left-box-top1.jpg">
                                                                                                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="79%" class="bottomDiv-header-black">
                                                                                                            My Schedule
                                                                                                        </td>
                                                                                                        <td width="21%" align="right">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td background="images/left-box-middle.jpg">
                                                                                                <table width="96%" border="0" align="center" cellpadding="3" cellspacing="1">
                                                                                                    <tr>
                                                                                                        <td width="90%">
                                                                                                            <div id="button">
                                                                                                                <a href="#" class="link-black1">Appointments (3)</a>
                                                                                                                <div id="two2">
                                                                                                                    <a href="#">Appointments 1
                                                                                                                        <br>
                                                                                                                        Appointments 2<br>
                                                                                                                        Appointments 3</a></div>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <div id="button">
                                                                                                                <a href="#" class="link-black1">Meetings (2)</a>
                                                                                                                <div id="two2">
                                                                                                                    <a href="#">Meetings 1
                                                                                                                        <br>
                                                                                                                        Meetings 2</a></div>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <div id="button">
                                                                                                                <a href="#" class="link-black1">Reminders (1)</a>
                                                                                                                <div id="two2">
                                                                                                                    <a href="#">Reminders 1 </a>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <!--<table width="96%"  border="0" align="center" cellpadding="3" cellspacing="1">
                                    <tr>
                                      <td width="10%" align="center"><img src="images/bullet.jpg" width="6" height="6"></td>
                                      <td width="90%"><a href="#" class="link-blue2">For Railway Enquiry </a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><img src="images/bullet.jpg" width="6" height="6"></td>
                                      <td><a href="#" class="link-blue2">For PVR Ticket Booking </a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><img src="images/bullet.jpg" width="6" height="6"></td>
                                      <td><a href="#" class="link-blue2">For Other Importent</a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><img src="images/bullet.jpg" width="6" height="6"></td>
                                      <td><a href="#" class="link-blue2">For Railway Enquiry </a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><img src="images/bullet.jpg" width="6" height="6"></td>
                                      <td><a href="#" class="link-blue2">For PVR Ticket Booking </a></td>
                                    </tr>
                                    <tr>
                                      <td align="center"><img src="images/bullet.jpg" width="6" height="6"></td>
                                      <td><a href="#" class="link-blue2">For Other Importent</a></td>
                                    </tr>
                                </table>-->
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/left-box-bottom.jpg" width="209" height="4">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>--%>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/5x5.gif" width="5" height="17">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="209" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="29" background="images/left-box-top1.jpg">
                                                                                                <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="79%" class="bottomDiv-header-black">
                                                                                                            Helpful Links
                                                                                                        </td>
                                                                                                        <td width="21%" align="right">
                                                                                                            <!--<img src="images/_89.png" width="16" height="16">-->
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="108" valign="top" background="images/left-box-middle.jpg">
                                                                                                <table width="96%" border="0" align="center" cellpadding="3" cellspacing="1">
                                                                                                    <asp:Repeater ID="rpthelpful" runat="server">
                                                                                                        <ItemTemplate>
                                                                                                            <tr>
                                                                                                                <td align="center" width="6%">
                                                                                                                    <img src="images/arrows1.gif" width="3" height="5">
                                                                                                                </td>
                                                                                                                <td width="94%">
                                                                                                                    <a href="<%#DataBinder.Eval(Container.DataItem, "url")%>" target="_blank">
                                                                                                                        <%#DataBinder.Eval(Container.DataItem, "linktitle")%>
                                                                                                                    </a>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/left-box-bottom.jpg" width="209" height="4">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/5x5.gif" width="5" height="17">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="1%" valign="top">
                                                                        <img src="images/5x5.gif" width="9" height="5" align="right">
                                                                    </td>
                                                                    <td width="68%" valign="top">
                                                                        <table width="450" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <table width="98%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/5x5.gif" width="5" height="5" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="50%" valign="top">
                                                                                                            <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                                                                                              <%--  <tr>
                                                                                                                    <td width="1%" bgcolor="#013c80">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td width="98%" class="blue-heading" style="padding-left: 5px;">
                                                                                                                        Notifications
                                                                                                                    </td>
                                                                                                                </tr>--%>
                                                                                                               <%-- <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="3" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                    <td bgcolor="#D3F1DF">
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>--%>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="4" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                                                                            <asp:Repeater ID="rptnews" runat="server">
                                                                                                                                <ItemTemplate>
                                                                                                                                    <%--<tr>
                                                                                                                                        <td>
                                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-text-gray">
                                                                                                                                                        <%# Eval("posteddate", "{0:dd MMM yyyy}") %>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-text-gray">
                                                                                                                                                        <b><font color="#044f7c">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                                                                                                                        </font></b>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-txt2">
                                                                                                                                                        <a href="Intranet/notificationviewdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                                                                                                                            title="<%#DataBinder.Eval(Container.DataItem, "descriptionfull")%>" class="link-blk3">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                                                                                                                            ...</a>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>--%>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <img src="images/5x5.gif" width="5" height="8" alt="" />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:Repeater>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                               <%-- <tr align="right">
                                                                                                                    <td colspan="2" style="height: 12px">
                                                                                                                        <a href="Intranet/notification.aspx" class="link-view">View All </a>
                                                                                                                    </td>
                                                                                                                </tr>--%>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                        <td valign="top">
                                                                                                            <table width="96%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                                                <%--<tr>
                                                                                                                    <td width="1%" bgcolor="#013c80">
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td width="98%" class="blue-heading" style="padding-left: 5px;">
                                                                                                                        Events
                                                                                                                    </td>
                                                                                                                </tr>--%>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="3" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                    <td bgcolor="#D3F1DF">
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="3" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                                                                            <asp:Repeater ID="rptevents" runat="server">
                                                                                                                                <ItemTemplate>
                                                                                                                                   <%-- <tr>
                                                                                                                                        <td>
                                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-text-gray">
                                                                                                                                                        <%# Eval("eventdate", "{0:dd MMM yyyy}")%>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-text-gray">
                                                                                                                                                        <b><font color="#044f7c">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "heading")%></font> </b>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-txt2">
                                                                                                                                                        <a href="Intranet/eventviewdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                                                                                                                            class="link-blk3" title="<%#DataBinder.Eval(Container.DataItem, "descriptionfull")%>">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                                                                                                                            ... </a></a>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>--%>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <img src="images/5x5.gif" width="5" height="8" />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:Repeater>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr align="right">
                                                                                                                   <%-- <td colspan="2">
                                                                                                                        <a href="Intranet/events.aspx" class="link-view">View All </a>
                                                                                                                    </td>--%>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/5x5.gif" width="5" height="5" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td bgcolor="#E9E9E9">
                                                                                                <img src="images/5x5.gif" height="1" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/5x5.gif" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="50%" valign="top">
                                                                                                            <table width="96%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <%--<td width="1%" bgcolor="#013c80">
                                                                                                                        &nbsp;
                                                                                                                    </td>--%>
                                                                                                                    <%--<td width="98%" class="blue-heading" style="padding-left: 5px;">
                                                                                                                        News
                                                                                                                    </td>--%>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="3" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                    <td bgcolor="#D3F1DF">
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="4" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                                                            <asp:Repeater ID="rptannouncements" runat="server">
                                                                                                                                <ItemTemplate>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-text-gray">
                                                                                                                                                        <b><font color="#044f7c">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                                                                                                                        </font></b>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-txt2">
                                                                                                                                                        <a href="Intranet/announcementsdetailview.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                                                                                                                            class="link-blk3" title="<%#DataBinder.Eval(Container.DataItem, "descriptionfull")%>">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                                                                                                                            ... </a></a>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <img src="images/5x5.gif" width="5" height="8" />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:Repeater>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr align="right">
                                                                                                                  <%--  <td colspan="2">
                                                                                                                        <a href="Intranet/announcements.aspx" class="link-view">View All </a>
                                                                                                                    </td>--%>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                        <td valign="top">
                                                                                                            <table width="96%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                                                <tr>
                                                                                                                   <%-- <td width="1%" bgcolor="#013c80">
                                                                                                                        &nbsp;
                                                                                                                    </td>--%>
                                                                                                                  <%--  <td width="98%" class="blue-heading" style="padding-left: 5px;">
                                                                                                                        Press Release
                                                                                                                    </td>--%>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="3" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                    <td bgcolor="#D3F1DF">
                                                                                                                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td colspan="2">
                                                                                                                        <img src="images/5x5.gif" width="5" height="3" alt="" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                                            <asp:Repeater ID="rptachievements" runat="server">
                                                                                                                                <ItemTemplate>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-text-gray">
                                                                                                                                                        <b><font color="#044f7c">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                                                                                                                        </font></b>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                                <tr>
                                                                                                                                                    <td class="home-rl-txt2">
                                                                                                                                                        <a href="Intranet/achievementsviewdetail.aspx?detail=<%#DataBinder.Eval(Container.DataItem,"id")%>"
                                                                                                                                                            class="link-blk3" title="<%#DataBinder.Eval(Container.DataItem, "descriptionfull")%>">
                                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                                                                                                                            ... </a></a>
                                                                                                                                                    </td>
                                                                                                                                                </tr>
                                                                                                                                            </table>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td>
                                                                                                                                            <img src="images/5x5.gif" width="5" height="8" alt="" />
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </ItemTemplate>
                                                                                                                            </asp:Repeater>
                                                                                                                        </table>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                    <td>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr align="right">
                                                                                                                    <td colspan="2">
                                                                                                                        <a href="Intranet/companyachievements.aspx" class="link-view">View All </a>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <img src="images/5x5.gif" width="5" height="5" alt="" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td bgcolor="#E9E9E9">
                                                                                                <img src="images/5x5.gif" width="5" height="1" alt="" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/5x5.gif" width="5" height="5" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/news-top.jpg" width="488" height="5" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td background="images/news-middle.jpg" align="left" style="background-repeat: repeat-y;">
                                                                                    <table width="80%" border="0" cellspacing="5" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="48%" align="left" valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td align="left" class="contentheaders">
                                                                                                            Anniversary
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <img src="images/5x5.gif" alt="" width="5" height="5" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="text-green-sub">
                                                                                                            <marquee class="textDarkgray" onmouseover="this.setAttribute('scrollamount', 0, 0);"
                                                                                                                onmouseout="this.setAttribute('scrollamount', 6, 0);" direction="up" width="200"
                                                                                                                height="120" scrolldelay="250">
                                                                                                                <asp:DataList ID="DlsAnniversary" runat="server" DataKeyField="" Height="0px" RepeatColumns="1"
                                                                                                                RepeatDirection="Vertical" Width="100%" onitemcommand="DlsAnniversary_ItemCommand">
                                                                                                                <ItemTemplate>
                                                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                        <tr>
                                                                                                                            <td width="180" valign="top" class="border-right">
                                                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                                                                                                    <tr>
                                                                                                                                        <td width="12%" rowspan="2" align="center" valign="top">
                                                                                                                                            <img src="images/ballon-icon.gif" width="13" height="31" alt="" />
                                                                                                                                        </td>
                                                                                                                                        <td width="88%" valign="top" class="txt01">
                                                                                                                                          <asp:LinkButton runat="server" ID="lnkViewAnniversary" CommandName="View" CommandArgument='<%#Eval("empcode") %>'  Text='<%#Eval("EmpName") %>'></asp:LinkButton>
                                                        
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                        <td valign="top" class="text2">
                                                                                                                                            <%#DataBinder.Eval(Container.DataItem, "designationname")%>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                </table>
                                                                                                                                 <div id="light1" class="white_content123" runat="server">
                                                                                                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                                                                    <tr>
                                                                                                                                     <td align="right" colspan="2" class="blue-heading">
                                                                                                                                         <%--<a href="javascript:void(0)" onclick="document.getElementById('light1').style.display='none';document.getElementById('fade1').style.display='none'">
                                                                                                                                                Close</a><br />
                                                                                                                                            <br />--%>
                                                                                                                                                <asp:LinkButton runat="server" ID="lnkClose1" CommandName="Close">Close</asp:LinkButton>
                                                                                                                                        </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                    <td align="right" width="5%" class="blue-heading"><label id="LBL_text" runat="server">Dear</label></td>
                                                                                                                                    <td align="left" width="95%" class="blue-heading">&nbsp;&nbsp;<asp:Label ID="LBL_Name" runat="server"></asp:Label></td>
                                                                                                                                    </tr>
                                                                                                                                    <tr><td colspan="2" class="blue-heading">
                                                                                                                                    <label> Many Many Happy Returns of the day !!!!!</label>
                                                                                                                                    </td></tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" height="5">
                                                    
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" align="center" class="blue-heading">
                                                                                                                                 <asp:Label ID="LBL_Name1" runat="server"></asp:Label>
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" align="center" class="blue-heading">
                                                                                                                                    <asp:Label ID="LBL_Desg" runat="server"></asp:Label>
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" align="center" class="blue-heading">
                                                                                                                                   <asp:Label ID="LBL_Mobile" runat="server"></asp:Label>
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" align="center" class="blue-heading">
                                                                                                                                     <img src="images/index.jpg" width="300" height="200" alt=""/>
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" align="center" class="blue-heading">
                                                   
                                                                                                                                    <asp:Label ID="lblCurrentDate1" runat="server" Text=""></asp:Label>
                                                   

                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    <tr> <td colspan="2" height="5">
                                                    
                                                                                                                                    </td></tr>
                                                                                                                                    <tr>
                                                                                                                                    <td colspan="2" align="left" class="blue-heading">
                                                                                                                                    Warm Regards
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                     <tr>
                                                                                                                                    <td colspan="2" align="left" class="blue-heading">
                                                                                                                                    HC Team
                                                                                                                                    </td>
                                                                                                                                    </tr>
                                                                                                                                    </table>

                                                                                                                                </div>
                                                                                                                                <div id="fade1" class="black_overlay123"></div>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr>
                                                                                                                            <td colspan="4" valign="top">
                                                                                                                                &nbsp;</td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:DataList> 
                                                                                                            </marquee>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td background="images/line2.gif" style="background-repeat: repeat-y;">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="48%" valign="top" align="left" class="contentheaders-blue">
                                                                                                <table width="225" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                     <%--   <td align="left" class="contentheaders-gray">--%>
                                                                                                        <td align="left" class="contentheaders">
                                                                                                        
                                                                                                            Birthday
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <img src="images/5x5.gif" alt="" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="left" class="text-green-sub">
                                                                                                            <marquee class="textDarkgray" onmouseover="this.setAttribute('scrollamount', 0, 0);"
                                                                                                                onmouseout="this.setAttribute('scrollamount', 6, 0);" direction="up" width="200"
                                                                                                                height="120" scrollamount="2" scrolldelay="85">
                                                                                                                    <asp:DataList ID="dlstbirthday" runat="server" DataKeyField="" Height="0px" RepeatColumns="1"
                                                                                                                        RepeatDirection="Vertical" Width="100%" onitemcommand="dlstbirthday_ItemCommand">
                                                                                                                        <ItemTemplate>
                                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                                <tr>
                                                                                                                                    <td width="180" valign="top" class="border-right">
                                                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                                                                                                                            <tr>
                                                                                                                                                <td width="12%" rowspan="2" align="center" valign="top">
                                                                                                                                                    <img src="images/ballon-icon.gif" width="13" height="31" alt=""/>
                                                                                                                                                </td>
                                                                                                                                                <td width="88%" valign="top" class="txt01">
                                                                                                                                                 <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='block';document.getElementById('fade').style.display='block'">
                                                                                                                                                  <asp:LinkButton runat="server" ID="lnkView" CommandName="View" CommandArgument='<%#Eval("empcode") %>'  Text='<%#Eval("EmpName") %>'></asp:LinkButton>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                                <td valign="top" class="text2">
                                                                                                                                                    <%#DataBinder.Eval(Container.DataItem, "designationname")%>
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                        </table>
                                                                                                                                        <div id="light" runat="server" class="white_content123">
                                                                                                                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                                                                            <tr>
                                                                                                                                             <td align="right" colspan="2" class="blue-heading">
                                                                                                                                                   <%-- <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                                                                                                                                                        Close</a>--%>
                                                                                                                                                        <asp:LinkButton runat="server" ID="lnkClose" CommandName="Close">Close</asp:LinkButton>
                                                                                                                                                        <br />
                                                                                                                                                    <br />
                                                                                                                                                </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                            <td align="right" width="5%" class="blue-heading"><label id="lbl_text" runat="server">Dear</label></td>
                                                                                                                                            <td align="left" width="95%" class="blue-heading">&nbsp;&nbsp;<asp:Label ID="txt_name" runat="server"></asp:Label></td>
                                                                                                                                            </tr>
                                                                                                                                            <tr><td colspan="2" class="blue-heading">
                                                                                                                                            <label> Many Many Happy Returns of the day !!!!!</label>
                                                                                                                                            </td></tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" height="5">
                                                    
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" align="center" class="blue-heading">
                                                                                                                                         <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" align="center" class="blue-heading">
                                                                                                                                            <asp:Label ID="lbl_desg" runat="server"></asp:Label>
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" align="center" class="blue-heading">
                                                                                                                                           <asp:Label ID="Lbl_fone" runat="server"></asp:Label>
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" align="center" class="blue-heading">
                                                                                                                                             <img src="images/image001.png" width="300" height="200" alt=""/>
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" align="center" class="blue-heading">
                                                   
                                                                                                                                            <asp:Label ID="lblCurrentDate" runat="server" Text=""></asp:Label>
                                                   

                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            <tr> <td colspan="2" height="5">
                                                    
                                                                                                                                            </td></tr>
                                                                                                                                            <tr>
                                                                                                                                            <td colspan="2" align="left" class="blue-heading">
                                                                                                                                            Warm Regards
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                             <tr>
                                                                                                                                            <td colspan="2" align="left" class="blue-heading">
                                                                                                                                            HC Team
                                                                                                                                            </td>
                                                                                                                                            </tr>
                                                                                                                                            </table>

                                                                                                                                        </div>
                                                                                                                                        <div id="fade" class="black_overlay123"></div>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td colspan="4" valign="top">
                                                                                                                                        &nbsp;</td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:DataList> 
                                                                                                            </marquee>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/news-bottom.jpg" width="488" height="4" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <!-- scroll -->
                                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <!-- end scroll -->
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="25%" valign="top" style="background: #f3f5f7; border: 1px #cdcdcd solid;">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table width="212" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <img src="images/5x5.gif" width="5" height="6" alt="">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td background="images/left-box-top1.jpg">
                                                                                    <table width="93%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td class="bottomDiv-header-black">
                                                                                                <%--From The Management Desk--%>
                                                                                                From The Acuminous Software
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 75px" background="images/left-box-middle.jpg">
                                                                                    <table width="94%" border="0" align="left" cellpadding="5" cellspacing="0">
                                                                                        <asp:Repeater ID="rptceo" runat="server">
                                                                                            <ItemTemplate>
                                                                                                <tr>
                                                                                                    <td width="98%" valign="top" class="black-normal-new2-gray">
                                                                                                        <%#DataBinder.Eval(Container.DataItem, "title")%>
                                                                                                        ...<a href="Intranet/ceomessageviewmore.aspx" class="green-thn">read more</a>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <img src="images/left-box-bottom.jpg" width="209" height="4" alt="" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <img src="images/5x5.gif" width="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" bgcolor="#f5f5f5">
                                                            <table width="209" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="29" background="images/left-box-top1.jpg">
                                                                        <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="79%" class="bottomDiv-header-black">
                                                                                    My Profile
                                                                                </td>
                                                                                <td width="21%" align="right">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <tr>
                                                                    <td height="108" valign="top" background="images/left-box-middle.jpg">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="94%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="3">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="64%" valign="top">
                                                                                                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td class="personal-green-bottom">
                                                                                                            <table width="100%" border="0" align="right" cellpadding="3" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td width="37%">
                                                                                                                        <img style="border: white 1px solid;" src='' runat="server" id="imageProf" width="70"
                                                                                                                            height="80" alt="" />
                                                                                                                    </td>
                                                                                                                    <td width="63%" valign="top">
                                                                                                                        <a href="Intranet/home.aspx" class="link-blk">My Profile</a>
                                                                                                                        <br />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                           <%-- <tr>
                                                                                <td>
                                                                                    <img src="images/left-box-bottom.jpg" width="209" height="4" alt="" />
                                                                                </td>
                                                                            </tr>--%>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td>
                                                                        <img src="images/5x5.gif" width="5" alt="" />
                                                                    </td>
                                                                </tr>--%>
                                                            </table>
                                                        </td>
                                                    </tr>
                                               <%--      <tr>
                                                       <td align="center" bgcolor="#f5f5f5">
                                                            <table width="209" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                   <%-- <td height="29" background="images/left-box-top1.jpg">
                                                                        <table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">--%>
                                                                           <%-- <tr>
                                                                                <td width="79%" class="bottomDiv-header-black">
                                                                                    New Vacancy
                                                                                </td>
                                                                                <td width="21%" align="right">
                                                                                </td>
                                                                            </tr>--%>
                                                                       <%-- </table>
                                                                    </td>
                                                                </tr>--%>
                                                              <%--  <tr>
                                                                    <td height="108" valign="top" background="images/left-box-middle.jpg">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="94%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="3">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td width="64%" valign="top">
                                                                                                <table width="98%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td class="personal-green-bottom">
                                                                                                            <table width="100%" border="0" height="200px" align="right" cellpadding="3" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td style="height: 75px" background="images/left-box-middle.jpg">
                                                                                                                       <marquee class="textDarkgray" onmouseover="this.setAttribute('scrollamount', 0, 0);"
                                                                                                                            onmouseout="this.setAttribute('scrollamount', 1, 0);" direction="up" width="200"
                                                                                                                            height="120" scrollamount="1" scrolldelay="2">
                                                                                                                          <table width="94%" border="0" align="left" cellpadding="5" cellspacing="0">
                                                                                                                           <asp:Repeater ID="rprJoboppening" runat="server" OnItemDataBound="rprJoboppening_ItemDataBound">
                                                                                                                         <ItemTemplate>
                                                                                                                         <tr>
                                                                                                                             <td width="98%" valign="top" class="black-normal-new2-gray">
                                                                                                                                <asp:Label ID="lblVac_ID" runat="server" SkinID="gridLabel" Visible="false" Text='<%# bind("Vac_ID") %>'></asp:Label>
                                                                                                                                <asp:Label ID="lblTitle" runat="server" SkinID="gridLabel" Visible="false" Text='<%# bind("NAME") %>'></asp:Label>
                                                                                                                               <asp:LinkButton ID="lnkView" runat="server" SkinID="linkGrid" Text="Details" ToolTip="Details"></asp:LinkButton>
                                                                                                                            </td>
                                                                                                                            </tr>
                                                                                                                         </ItemTemplate>
                                                                                                                        </asp:Repeater>
                                                                                                                        </marquee>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>--%>
                                                               <%-- <tr>
                                                                    <td>
                                                                        <img src="images/left-box-bottom.jpg" width="209" height="4" alt="" />
                                                                    </td>
                                                                </tr>--%>
                                                            </table>
                                                 </td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/5x5.gif" width="5" height="1" alt="" />
                    </td>
                </tr>
            </table>
            </td> </tr> </table> </td> </tr>
            <tr>
                <td bgcolor="#FFFFFF">
                    <img src="images/5x5.gif" width="5" height="8" alt="">
                </td>
            </tr>
            </table>
        </div>
        <%-- <div class="footer">
            <div class="main">
                Powered By:- Ricoh India Ltd. All Rights Reserved. r="#FFFFFF">
                <img src="images/5x5.gif" width="5" height="8" alt="">
                </td> </tr> </table>
            </div>--%>
        <%--<div class="footer">
            <div class="main">
                Powered By:- Ricoh India Ltd. All Rights Reserved.
            </div>
        </div>--%>
    </div>
    </form>
</body>
</html>
