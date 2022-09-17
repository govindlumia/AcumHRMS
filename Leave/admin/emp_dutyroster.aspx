<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Leave/admin/Admin.master"
    CodeFile="emp_dutyroster.aspx.cs" Inherits="admin_tmt_empdutyroster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ID="Content1">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">
                                        Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div style="overflow-x: hidden; overflow-y: scroll; height: 455px; width: 940px;">
                    <table width="923" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td width="80%" align="left" class="txt01">
                                            <asp:Label ID="lbl_empmsg1" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td width="20%" align="right" class="txt-red">
                                            <span id="spanmessage" runat="server"></span>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td valign="middle" class="frm-lft-clr123" width="10%">
                                            Select
                                        </td>
                                        <td valign="middle" class="frm-rght-clr123" width="10%">
                                            <asp:LinkButton ID="lnkcheckAll" runat="server" CssClass="txt-red" OnClick="lnkcheckAll_Click"><b>All</b></asp:LinkButton>
                                            &nbsp;l&nbsp;
                                            <asp:LinkButton ID="lnkcheckNone" runat="server" CssClass="txt-red" OnClick="lnkcheckNone_Click"><b>None</b></asp:LinkButton>
                                        </td>
                                        <td valign="middle" align="right" width="78%">
                                            <asp:Button ID="btndelete" runat="server" CssClass="button" Text="Delete" OnClick="btndelete_Click" />
                                            <asp:Button ID="btnedit" runat="server" CommandName="Edit" Text="Edit" CssClass="button"
                                                OnClick="btnedit_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Visible="false" Text="Cancel" CssClass="button"
                                                OnClick="btnCancel_Click" />
                                            <%--<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" OnClick="btnBack_Click" />--%>
                                        </td>
                                        <%--<td align="right"><input id="Button1" type="button" value="Back" onclick="javascript:history.back()" /> </td>--%>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" class="head-2">
                                <asp:GridView ID="empdutyrosterdetails" runat="server" DataKeyNames="Dated" Font-Size="11px"
                                    Font-Names="Arial" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
                                    OnPageIndexChanging="empdutyrosterdetails_PageIndexChanging" CellPadding="3"
                                    PageSize="25" AllowSorting="True" OnRowEditing="empdutyrosterdetails_RowEditing"
                                    BorderStyle="None" BorderWidth="0px">
                                    <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                    <RowStyle ForeColor="#000066" HorizontalAlign="Left"></RowStyle>
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                Width="10%" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chkbox" runat="server" BorderStyle="None" Text='<%# Eval("Date", "{0:dd-MMM-yyyy}")%>'
                                                    ForeColor="White" AutoPostBack="true" OnCheckedChanged="Chkbox_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                Width="18%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Lbldate" Visible="true" runat="server" Text='<%# Eval("DATE", "{0:dd-MMM-yyyy}") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EmpCode">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                Width="18%" />
                                            <ItemTemplate>
                                                <asp:Label ID="Lblempcode" Visible="true" runat="server" Text='<%# Eval("EMPCODE") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Week Days">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                Width="18%" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblweekdays" Visible="true" runat="server" Text='<%# Eval("DAYS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shift">
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                Width="18%" />
                                            <ItemTemplate>
                                                <%--<asp:BoundField DataField="SHIFT" HeaderText="Shift"></asp:BoundField>--%>
                                                <asp:Label ID="lblShift" Visible="true" runat="server" Text='<%# Bind("SHIFT") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="frm-rght-clr1234"
                                                Width="18%" />
                                            <ItemTemplate>
                                                <asp:DropDownList Visible="false" ID="drpShift" runat="server" DataTextField="shiftname"
                                                    DataValueField="shiftid" CssClass="select1">
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <%--<PagerStyle HorizontalAlign="Center" BackColor="White" ForeColor="#000066"></PagerStyle>--%>
                                    <EmptyDataTemplate>
                                        <span style="text-align: center">No such work roster is created.</span>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                                    <HeaderStyle Wrap="True" BackColor="#006699" CssClass="frm-lft-clr123" Font-Bold="True"
                                        ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                    <PagerStyle CssClass="frm-lft-clr123" Width="500px" Font-Size="18px" HorizontalAlign="Left"
                                        VerticalAlign="Top" />
                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" Visible="true" LastPageText="last"
                                        NextPageText="next" PreviousPageText="prev" FirstPageText="first" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
