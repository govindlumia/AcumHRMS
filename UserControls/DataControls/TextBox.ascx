<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBox.ascx.cs" Inherits="UserControls_DataControls_TextBox" %>

<asp:TextBox ID="txtDataBox" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvDataBox" runat="server" ControlToValidate="txtDataBox"></asp:RequiredFieldValidator>
