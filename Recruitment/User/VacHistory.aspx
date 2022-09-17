<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VacHistory.aspx.cs" Inherits="Recruitment_User_VacHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vaccancy Approval History</title>
</head>
<body>
    <form id="form1" runat="server">
    <link href="../../Css/blue1.css" rel="stylesheet" type="text/css" />
    <fieldset id="fieldset" runat="server">
        <legend><b>Vaccancy Approval History</b></legend>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="frm-lft-clr123" width="10%">
                    Vaccancy ID
                </td>
                <td class="frm-rght-clr123">
                    <asp:Label ID="lblVacId" runat="server">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td height="5px">
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <div id="dvResult" style="overflow: scroll; height: 500px;" runat="server">
                        <asp:GridView ID="GvAppHistory" runat="server" AutoGenerateColumns="False" BorderColor="#c9dffb"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Arial" Font-Size="11px"
                            Width="100%" OnRowDataBound="GvAppHistory_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="Employee">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                        Width="20%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmployee" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedBy") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                        Width="35%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemarks" runat="server" SkinID="gridLabel" Text='<%# bind("Remarks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Comments">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                        Width="35%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblComment" runat="server" SkinID="gridLabel" Text='<%# bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action Date">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                        Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" SkinID="gridLabel" Text='<%# bind("CreatedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    </form>
</body>
</html>
