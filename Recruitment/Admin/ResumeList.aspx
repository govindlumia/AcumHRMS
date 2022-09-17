<%@ Page Title="" Language="C#" MasterPageFile="~/Recruitment/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ResumeList.aspx.cs" Inherits="Recruitment_Admin_ResumeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
    <asp:Label runat="server" ID="lbl_srch" Text="Search"></asp:Label>
    <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="Search" AutoPostBack="true"></asp:TextBox>
   
<hr />
    <asp:GridView ID="GvResume" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
        CellPadding="4" DataKeyNames="ID" Width="100%" AutoGenerateColumns="False"
        AllowSorting="true" BorderWidth="0px" EmptyDataText="No such Resume exists !" 
        AllowPaging="true" OnPageIndexChanging = "GvResume_PageIndexChanging"   
      OnRowCommand="GvResume_RowCommand"
        OnRowDataBound="GvResume_RowDataBound" OnRowEditing="GvResume_RowEditing" OnSorting="GvResume_Sorting">
        <Columns>
            <asp:TemplateField HeaderText="ID" SortExpression="ID" HeaderStyle-ForeColor="#013366">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                <ItemTemplate>
                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="name" HeaderStyle-ForeColor="#013366">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                <ItemTemplate>
                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("NAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email" SortExpression="Email" HeaderStyle-ForeColor="#013366">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle Width="23%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                <ItemTemplate>
                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("Email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Phone" SortExpression="Phone" HeaderStyle-ForeColor="#013366">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                <ItemTemplate>
                    <asp:Label ID="l9" runat="server" Text='<%# Bind ("Phone") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Experience" SortExpression="Total_Exp" HeaderStyle-ForeColor="#013366">
                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                <ItemTemplate>
                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("Total_Exp") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            
                  <asp:TemplateField HeaderText="Download Here">  
                                    <ItemTemplate>  
                                        <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" CommandArgument='<%# Eval("ResumeName") %>'  
                                            CommandName="cmd_DownloadResume" Text='<%# Eval("ResumeName") %>' />  
                                    </ItemTemplate>  
                                </asp:TemplateField> 
            <%--<asp:TemplateField HeaderText="Bussiness Unit" SortExpression="BussinessUnitName"
                                                                                                            HeaderStyle-ForeColor="#013366">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                           <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("BussinessUnitName") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>--%>
      
        </Columns>
        <HeaderStyle CssClass="frm-lft-clr123" />
        <FooterStyle CssClass="frm-lft-clr123" />
        <RowStyle Height="5px" />
        <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
    </asp:GridView>
</asp:Content>

