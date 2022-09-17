<%@ Page Title="View KRA Form " Language="C#" MasterPageFile="~/Appraisal/UserMaster.master" AutoEventWireup="true" CodeFile="ViewKRAForm.aspx.cs" 
    Inherits="Appraisal_User_ViewKRAForm" %>


<%@ Register src="../UserControl/UCViewKRAForm.ascx" tagname="UCViewKRAForm" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:UCViewKRAForm ID="UCViewKRAForm1" runat="server" />

</asp:Content>

