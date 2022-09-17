<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Uploader.ascx.cs" Inherits="CustomControl" %>
<html>
<head>
<title>
</title>
</head>
<body>
<asp:FileUpload ID="FilUpl" runat="server" CssClass="blue111" Width="200px" Height="18" />
<asp:CustomValidator CssClass ="blue5" ID="ErrorMsg" runat="server" ErrorMessage="CustomValidator" OnServerValidate="ErrorMsg_ServerValidate" ForeColor="#0000C0" Display="Dynamic"></asp:CustomValidator>
</body>
</html>