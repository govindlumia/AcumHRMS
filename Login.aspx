<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
  <%--  <title>Acuminous Software</title>--%>
      <title>Acuminous Software Pvt. Ltd</title>
       <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <style type="text/css">
        @import "css/login1.css";
        /*.button
        {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            background: #4CAF50;
            color: #FFFFFF;
            font: bold 11px/15px Arial, Helvetica, sans-serif;
            width: 78px;
            cursor: hand;
        }
        
        .style1
        {
            height: 28px;
        }
        .style2
        {
            height: 24px;
        }*/
    </style>
    <style type="text/css">
        @import url(https://fonts.googleapis.com/css?family=Roboto:300);

.login-page {
  width: 360px;
  /*padding: 8% 0 0;*/
  padding: 10% 0% 0% 64%;
  margin: auto;
}

.form input[type='text'], .form input[type='password'] {
    border:  1px solid #ddd;
    background: #fff;
}

.button:hover {
    background: #208cb5;
}

.form input[type='text']:focus, .form input[type='password']:focus {
    border-color: #208cb5;
}
.button {
    background: #208cb5d1;
    color:#fff;
	}

.form {
  position: relative;
  z-index: 1;
  background: #feffff;
  max-width: 360px;
  margin: 0 auto 100px;
  padding: 45px;
  text-align: center;
  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24);
}
.form input {
  font-family: "Roboto", sans-serif;
  outline: 0;
  /*background: #cbe0e8;*/
  width: 100%;
  border: 0;
  margin: 0 0 15px;
  padding: 12px;
  box-sizing: border-box;
  font-size: 14px;
}
/*.form button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: #4CAF50;
  width: 100%;
  border: 0;
  padding: 15px;
  color: #FFFFFF;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
.form button:hover,.form button:active,.form button:focus {
  background: #43A047;
}*/
.form .message {
  margin: 15px 0 0;
  color: #b3b3b3;
  font-size: 12px;
}
.form .message a {
  color: #4CAF50;
  text-decoration: none;
}
.form .register-form {
  display: none;
}
.container {
  position: relative;
  z-index: 1;
  max-width: 300px;
  margin: 0 auto;
}
.container:before, .container:after {
  content: "";
  display: block;
  clear: both;
}
.container .info {
  margin: 50px auto;
  text-align: center;
}
.container .info h1 {
  margin: 0 0 15px;
  padding: 0;
  font-size: 36px;
  font-weight: 300;
  color: #1a1a1a;
}
.container .info span {
  color: #4d4d4d;
  font-size: 12px;
}
.container .info span a {
  color: #000000;
  text-decoration: none;
}
.container .info span .fa {
  color: #EF3B3A;
}
body {
    background: url(../images/Hrms.jpg) repeat-x top;
  /*background:  #208cb5;*/ /* fallback for old browsers */
  /*background: -webkit-linear-gradient(right, #208cb5, #208cb5);
  background: -moz-linear-gradient(right, #208cb5, #208cb5);
  background: -o-linear-gradient(right, #208cb5, #208cb5);
  background: linear-gradient(to left, #208cb5, #208cb5);
  font-family: "Roboto", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;*/  
    /*width: 100%;
    height: auto;
    background-image: url(../images/Hrms.jpg);
    background-size: cover;*/   
}
    </style>
    <script language="javascript" type="text/javascript">
        function ResetPassword()
        {
        var args;
        args = document.getElementById("txtEmailAddress").value;
           
           <%= ClientScript.GetCallbackEventReference(this,"args","showres",null,"showerr",false) %>;
           return false ;
        }
        function showres(args)
        {  
        document.getElementById("txtEmailAddress").value = "";
        alert(args);
        }
        function showerr(args)
        {
         alert("error : "+args);
        }
        function OpenPopUp(url) {
            var resultObject = window.showModalDialog(url, "ForgotPassord", "dialogWidth:500px;dialogHeight:400px;")
        }
    </script>
    <style type="text/css">
     .black_overlay {
    display: none;
    position: fixed;
    top: 0%;
    left: 0%;
    right: 0;
    bottom: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, .7);
    z-index: 1;
    -moz-opacity: 0.8;
    filter: alpha(opacity=80);
}
        .white_content {
    display: none;
    position: fixed;
    top: 110px;
    left: 50%;
    padding: 16px;
    border: 16px solid #038ec2;
    background-color: white;
    z-index: 2;
    overflow: auto;
    transform: translate(-50%);
    max-width: 300px;
}

        .white_content p {
    font-size: 11px;
    line-height: 16px;
}

.white_content label {
    font-size: 12px;
    margin: 0 0 10px 0;
    display: block;
}
    </style>
</head>
<body>
    <div class="login-page">
  <div class="form">
    <form id="form1" class="login-form" runat="server">
       
    <%--<div class="division">
        <div class="container">--%>
          <%--  <div>--%>
               
                <!--...............................MID PART.........................-->
              <%--  <div class="content">--%>
                  <%--  <div class="left1">
                        <div align="center">
                          <img src="images/HCMS1.png" alt="Acuminous Software" />
                        </div>
                    </div>
                    <div class="right">--%>
                        <div id="UpdatePanel1">
                            <div >
                                <table cellpadding="0" cellspacing="0" border="0" align="center" style="width:100%">
                                 
                                    <tr style="padding:15px;">
                                        <td height="25" colspan="2" valign="top" style="color:#208cb5d1" class="txt-orange1">
                                            Login
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="style2">
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <%--<td width="40%" height="28" class="style1">
                                            <label>UserName</label>&nbsp;&nbsp;
                                        </td>--%>
                                       
                                        <td >
                                           <%-- <asp:TextBox ID="txt_name" size="25" runat="server" align="right"></asp:TextBox>--%>
                                             <asp:TextBox ID="txt_name" runat="server" type="text" placeholder="Username" autocomplete="off"></asp:TextBox>
                                             
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td height="28" width="40%" class="style1">
                                            <label>Password</label>&nbsp;&nbsp;
                                        </td>--%>
                                        <td class="pass">
                                         <%--   <asp:TextBox ID="txt_password" runat="server" size="25" TextMode="Password" align="right"></asp:TextBox>--%>
                                            <asp:TextBox TextMode="Password" ID="txt_password" runat="server" placeholder="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="right">
                                            <asp:Button ID="btn_logon" runat="server" OnClick="btn_logon_Click" Text="Submit"
                                                CssClass="button" ValidationGroup="v1" />&nbsp;
                                            <asp:Button ID="ibtnreset" runat="server" CssClass="button" Text="Reset" OnClick="ibtnreset_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="left" height="20" valign="middle">
                                            <span id="lbl_message" style="color: #1a7f02" class="link02" runat="server"></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                     <%--       <asp:LinkButton ID="lnkForgotPassword" Style="color: Gray; text-decoration: none;"
                                                runat="server">Forgot Password?</asp:LinkButton>--%>
                                            <p>
                                                <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='block';document.getElementById('fade').style.display='block'">
                                                    Forgot Password?</a></p>
                                            <div id="light" class="white_content">
                                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td align="right">
                                                            <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                                                                Close</a><br />
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <p>
                                                                Enter your registered Email Id below .We will send you an email on your email id
                                                                with a link to reset your password.</p>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>
                                                                Employee Email</label>
                                                            <asp:TextBox ID="txtEmpCode" runat="server" CssClass="input"></asp:TextBox>
                                                            <asp:Button ID="txtSave" runat="server" Text="Submit" CssClass="button" ValidationGroup="v"
                                                                OnCommand="ForgotPassword" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter employee code"
                                                                ValidationGroup="v" ControlToValidate="txtEmpCode" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td >                                                         
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <em>
                                                                * After click on submit button, Kindly check your mail.</em>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="fade" class="black_overlay">
                                            </div>
                                        </td>
                                    </tr>
                                
                                    <tr>
                                        <td colspan="2">
                                         <%--<label>This system is only for authorised users. </label>--%>
                                           <%-- <div class="autho_user">
                                                This system is only for authorised users.<br />
                                            </div>--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="clear: both">
                            </div>
                            <div id="box" class="pop1" align="center">
                                <table width="400" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="pop-brdr">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="95%" valign="top" class="pop-tp-clr" align="left">
                                                        Forgot Password
                                                    </td>
                                                    <td width="5%" align="right" valign="middle" class="pop-tp-clr">
                                                        <a href="#" onclick="document.getElementById('box').style.display='none';" class="link01">
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left" valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="reset">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                                        <tr>
                                                                            <td width="20%" valign="top">
                                                                                <img src="images/error-ico.gif" alt="" />
                                                                            </td>
                                                                            <td width="80%" valign="middle">
                                                                                <img src="images/reset-msg.gif" alt="" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="7">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td class="txt1" width="20%">
                                                                                            Emp Code
                                                                                        </td>
                                                                                        <td width="80%">
                                                                                            <input name="txt_username" type="text" id="txt_username" class="input2" />
                                                                                            <span id="RequiredFieldValidator1" style="color: Red; display: none;">
                                                                                                <img src="images/error1.gif" alt="" /></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="9">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt01" style="width: 82px">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td>
                                                                                            <input type="submit" name="Button1" value="Submit" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;Button1&quot;, &quot;&quot;, true, &quot;v&quot;, &quot;&quot;, false, false))"
                                                                                                id="Button1" class="button" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="10">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" valign="top" class="txt02">
                                                                                <span id="message"></span>
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
                            </div>
                        </div>
                   <%-- </div>--%>
                 <%--   <div style="clear: both;">
                        &nbsp;</div>--%>
               <%-- </div>--%>
           <%-- </div>--%>
            <!--...............................END MID PART.........................-->
       <%-- </div>
    </div>--%>
    <!--...............................FOOTER PART.........................-->
   <%--  <div class="footer">
        <div class="main">
            <p>
                Powered By:- Acuminous Software Pvt. Ltd</p>
        </div>
    </div>--%>
    <!--...............................END FOOTER PART.........................-->
    </form>
      </div>
        </div>
</body>
</html>
