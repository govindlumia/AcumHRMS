<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="KRAFormPeerApprove.aspx.cs" Inherits="Appraisal_Admin_KRAFormPeerApprove" %>

<%@ Register src="../UserControl/UCKRAFormPeerRating.ascx" tagname="UCKRAFormPeerRating" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UCKRAFormPeerRating ID="UCKRAFormPeerRating1" runat="server" />
</asp:Content>

