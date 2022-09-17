<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="FinalSubmit.aspx.cs" Inherits="Appraisal_Admin_FinalSubmit" %>

<%@ Register src="../UserControl/UCKRAFormFinalSubmit.ascx" tagname="UCKRAFormFinalSubmit" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UCKRAFormFinalSubmit ID="UCKRAFormFinalSubmit1" runat="server" />
</asp:Content>

