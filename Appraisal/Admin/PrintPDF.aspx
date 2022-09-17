<%@ Page Title="" Language="C#" MasterPageFile="~/Appraisal/BlankMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="PrintPDF.aspx.cs" Inherits="Appraisal_Admin_PrintPDF" %>

<%@ Register src="../UserControl/PrintPDF.ascx" tagname="PrintPDF" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PrintPDF ID="PrintPDF1" runat="server" />
</asp:Content>

