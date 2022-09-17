<%@ Page Language="C#" MasterPageFile="employeemaster.master" AutoEventWireup="true"
    CodeFile="home.aspx.cs" Inherits="home" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cplhld1" runat="Server">
    <iframe name="content" id="frame1" runat="server" frameborder="0" width="784px" height="500px"
        src="../Admin/Employee/viewempprofile.aspx" scrolling="yes"></iframe>
</asp:Content>
