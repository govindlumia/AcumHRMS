<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextBoxEmailAndRequiredValidation.ascx.cs" Inherits="UserControls_DataControls_TextBoxEmailAndRequiredValidation" %>

<asp:TextBox ID="txtDataBox" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvDataBox" runat="server" ControlToValidate="txtDataBox" ErrorMessage="Cannot be blank"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="regExpEmailDataBox" runat="server" 
    ControlToValidate="txtDataBox" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid EmailID" ></asp:RegularExpressionValidator>
