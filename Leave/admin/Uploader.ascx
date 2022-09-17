<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uploader.ascx.cs" Inherits="CustomControl" %>
<link href ="images/mes.css" rel="stylesheet" type="text/css" />

<html>
<head>
<title>

</title>

 
</head>
<body>
<asp:FileUpload ID="FilUpl" runat="server" CssClass="blue5" Width="200px" />
<br />
<asp:CustomValidator CssClass ="blue5" ID="ErrorMsg" runat="server" ErrorMessage="CustomValidator" OnServerValidate="ErrorMsg_ServerValidate" ForeColor="#0000C0"></asp:CustomValidator><br />
</body>
</html>