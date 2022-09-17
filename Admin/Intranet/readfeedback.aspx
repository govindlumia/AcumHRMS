<%@ Page Language="C#" AutoEventWireup="true" CodeFile="readfeedback.aspx.cs" Inherits="admin_readfeedback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Intranet Module</title>
    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                    DisplayAfter="1">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">
                                        Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01">
                                            View Feedback</td>
                                        <td align="right">
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" align="left" valign="middle">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" class="head-2">
                                <asp:GridView ID="suggestionsgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                    DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnPageIndexChanging="suggestions_PageIndexChanging"
                                    ToolTip="Read Feedback" AllowPaging="True">
                                    <%--   OnRowDeleting="suggestions_RowDeleting" OnRowCancelingEdit="suggestions_RowCancelingEdit" OnRowEditing="suggestions_RowEditing" 
          OnRowUpdating="suggestions_RowUpdating"  --%>
                                    <Columns>
                                        <asp:TemplateField HeaderText="Posted By">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "postedby")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "department_name")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "subject")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Description">
                                            <ItemTemplate>
                                                <a href="viewfeedbackdetail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                    target="_self" class="link05">
                                                    <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                    ...</a>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Status">
       <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234"/>
       <ItemTemplate>
       <%#DataBinder.Eval(Container.DataItem, "status")%>
       </ItemTemplate>
       <EditItemTemplate>
       <asp:DropDownList id="ddlapprovalstatus" runat="server" Width="95px" SelectedValue='<%#Bind("status1")%>' CssClass="blue1" Height="20px">
       <asp:ListItem Value="0">Not Approved</asp:ListItem>
       <asp:ListItem Value="1">Approved</asp:ListItem></asp:DropDownList>
       </EditItemTemplate>
        <HeaderStyle CssClass="frm-lft-clr123" />
       </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Posted Date">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField>                                                
       <EditItemTemplate>
       <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" /> | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
       </EditItemTemplate>
                                                  
       <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234"/>
       <ItemTemplate>
       <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" CssClass="link05" Text="Edit" ToolTip="Edit" /> | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
       </ItemTemplate>                                                       
           <HeaderStyle CssClass="frm-lft-clr123" />
       </asp:TemplateField>--%>
                                    </Columns>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>
                                    <FooterStyle CssClass="frm-lft-clr123" />
                                    <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                    <PagerStyle CssClass="frm-lft-clr123" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <div>
                        </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
