<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/User/RecruitmentWithoutLink.master"
    AutoEventWireup="true" CodeFile="Copy of CanOffer.aspx.cs" Inherits="Recruitment_User_CanOffer" %>

<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
    can name
    <asp:TextBox ID="txtCan" runat="server"></asp:TextBox>
    <br />
    <br />
    can Address
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    <br />
    <br />
    can CTC
    <asp:TextBox ID="txtCTC" runat="server"></asp:TextBox>
    <asp:Button ID="btnGenerate" runat="server" Text="click" OnClick="btnGenerate_Click" />
    <br />
    <br />
    <br />
    <br />
    <br />
    </p>
    <FTB:freetextbox id="txtTerms" runat="server" backcolor="Gray" breakmode="LineBreak"
        enablehtmlmode="False" gutterbackcolor="Gray" toolbarimageslocation="InternalResource"
        toolbarstyleconfiguration="Office2000" width="830px" height="250px">
                                                        </FTB:freetextbox>
</asp:Content>
