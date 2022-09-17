<%@ Page Title="View KRA Setting" Language="C#" MasterPageFile="~/Appraisal/AppraisalMasterWithoutLeftPanel.master" AutoEventWireup="true" CodeFile="ViewKRASetting.aspx.cs" Inherits="Appraisal_Admin_ViewKRASetting" %>
<%@ Reference Page="~/Appraisal/User/ViewKRAApprovals.aspx" %>
<%@ Reference Page="~/Appraisal/User/AllKRAFormStatus.aspx" %>

<%@ Register src="../UserControl/UCViewKRA.ascx" tagname="UCViewKRA" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UCViewKRA ID="ucViewKRASetting" runat="server" CurrentKRAID="1" />
</asp:Content>

