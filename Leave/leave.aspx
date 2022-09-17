<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave.aspx.cs" Inherits="leave1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Leave Activities</title>
    <link rel="shortcut icon" href="../images/favicon.ico" type="image/x-icon" />
    <link href="../images/family.css" rel="stylesheet" type="text/css" />
    <link href="../Css/blue1.css" rel="stylesheet" type="text/css" />
    <!-- CSS -->
    <link rel="stylesheet" href="../images/default.css" media="screen,projection"
        type="text/css" />
    <link rel="stylesheet" href="../images/lightbox.css" media="screen,projection"
        type="text/css" />
        <link href="../images/style.css" rel="stylesheet" type="text/css" />
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
    <div class="header">
        <table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td class="bg">
                    <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="20" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="148" height="60" valign="middle">
                                            <a href="../Main.aspx" style="border: 0">
                                                <img src="../images/Rossel-Techsys-Logo1(1).png" alt="Acuminous Software" />
                                            </a>
                                        </td>
                                        <td width="44%" align="right">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="background-repeat: no-repeat;">
                                                        <img src="../images/5x5.gif" width="5" height="12">
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
                                                                            </a>&nbsp;<img src="../images/welcome-icon.jpg">
                                                                        </div>
                                                                        
                                                                    </div>
                                                                </td>
                                                                <td align="center">
                                                                    <img src="../images/verticle-line1.gif" width="24" height="10">
                                                                </td>
                                                                <td width="70">
                                                                    <asp:LinkButton runat="server" ID="lnkLogOut" OnClick="lnkLogOut_Click">Log Out</asp:LinkButton>
                                                                    &nbsp;<img src="../images/icon_logout.jpg" width="10" height="10">
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
                            <td align="center">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="green-bar">
                                    <tr>
                                        <td width="50%" height="24" valign="middle" align="left" style="padding-left: 10px;
                                            color: #fff; font-weight: bold;">
                                            <strong>Leave Management</strong>
                                        </td>
                                        <td width="50%" align="right" valign="middle">
                                            <a href="../Main.aspx" class="link-wht" style="padding-right: 10px;">Home Page</a>
                                        </td>
                                    </tr>

                                </table>
                            </td>
                        </tr>
                          <tr>
                            <td bgcolor="#fff">
                                <img src="../images/5x5.gif" width="5" alt="" />
                            </td>
                        </tr>
                         <tr> 
                         <td align="right">
                                                            <table width="10%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="5" align="left" valign="top">
                                                                        <img src="../images/button-right.jpg" width="5" height="18" />
                                                                    </td>
                                                                    <td width="90" align="center" valign="middle" class="button-bg">
                                                                        <a href="leave.aspx" class="back">Back</a>
                                                                    </td>
                                                                    <td width="5" align="right">
                                                                        <img src="../images/button-right1.jpg" width="5" height="18" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                                        </tr>
                           <tr>
                            <td bgcolor="#fff">
                                <img src="../images/5x5.gif" width="5" alt="" />
                            </td>
                        </tr>
                        <tr>
                            <td class="light-white">
                                <iframe name="name123" frameborder="0" width="950px" height="560px" src="../leave/leave-user.aspx"
                                    scrolling="yes"></iframe>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="footer">
        <%--<div class="main">
           Powered By:- Ricoh India Ltd. All Rights Reserved.
        </div>--%>
    </div>
    </form>
</body>
</html>
