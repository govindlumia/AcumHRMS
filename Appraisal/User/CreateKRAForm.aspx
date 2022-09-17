<%@ Page Title="Create Appraisal Form" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="CreateKRAForm.aspx.cs" Inherits="Appraisal_User_CreateKRAForm" %>



<%@ Register src="../UserControl/UCKRAForm.ascx" tagname="UCKRAForm" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

    
    <uc1:UCKRAForm ID="UCKRAForm1" runat="server" />
    

    
</asp:Content>

