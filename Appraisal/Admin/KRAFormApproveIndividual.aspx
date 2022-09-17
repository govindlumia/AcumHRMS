<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="KRAFormApproveIndividual.aspx.cs" Inherits="Appraisal_Admin_KRAFormApproveIndividual" %>

<%@ Register src="../UserControl/UCKRAFormManagerRating.ascx" tagname="UCKRAFormManagerRating" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UCKRAFormManagerRating ID="UCKRAFormManagerRating1" runat="server" />
</asp:Content>

