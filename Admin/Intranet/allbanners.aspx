<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Intranet/IntranetMasterWithoutLink.master"
    AutoEventWireup="true" CodeFile="allbanners.aspx.cs" Inherits="Admin_Intranet_allbanners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:GridView ID="grdImageView" Width="100%" AutoGenerateColumns="false" runat="server"
            OnRowDataBound="grdImageView_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Image ID="ImgImage" runat="server" />
                                    <asp:Label ID="lblImageName" Visible="false" runat="server" Text='<%#Eval("ImageName") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
