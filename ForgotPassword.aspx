<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import "css/login1.css";
        .button
        {
            border-style: none;
            border-color: inherit;
            border-width: 0;
            background: url('images/button-bg.gif') no-repeat;
            color: #020950;
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
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Panel ID="Panel2" runat="server">
            <br />
                <span style="font-family: 'Courier New', Courier, monospace; font-size: medium;">Enter
                    your User Name / Emp Code below .We will send you an email on your email id with
                    a link to reset your password.</span><br /><br />
                <p align="center">
                    <asp:TextBox ID="txtEmpCode" CssClass="input" MaxLength="8" runat="server"></asp:TextBox>                   
                    <asp:Button ID="btnSendMail" runat="server" Text="Submit" CssClass="button" 
                        onclick="btnSendMail_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" /></p>
            </asp:Panel>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
