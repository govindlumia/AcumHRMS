<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="KRAFormApproveReviewer.aspx.cs" Inherits="Appraisal_Admin_KRAFormApproveReviewer" %>

<%@ Register src="../UserControl/UCKRAFormReviewerRating.ascx" tagname="UCKRAFormReviewerRating" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:UCKRAFormReviewerRating ID="UCKRAFormReviewerRating1" runat="server" />

</asp:Content>

