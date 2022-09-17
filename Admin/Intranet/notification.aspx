<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Intranet/IntranetMasterWithoutLink.master"
    AutoEventWireup="true" CodeFile="notification.aspx.cs" Inherits="intranet_newsmaster" %>
    <%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="tool" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ajaxToolkit:ToolkitScriptManager EnablePartialRendering="true" runat="Server" ID="ToolkitScriptManager1"
        ScriptMode="Release" LoadScriptsBeforeUI="true" EnablePageMethods="true" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DisplayAfter="1">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
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
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Notification Master Form
                                    </td>
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
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="22%" class="frm-lft-clr123" valign="middle">
                                                    Heading
                                                    <span style="color:Red">*</span>
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtheading" runat="server" CssClass="blue1" Width="188px" ToolTip="Enter Project Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtheading"
                                                        ErrorMessage="Enter Heading" ValidationGroup="v" Display="Dynamic"><img src="../../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 5px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" valign="top">
                                                    Description
                                                    <span style="color:Red">*</span>
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Height="68px" TextMode="MultiLine"
                                                        ToolTip="Enter Project Name" Width="188px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdescription"
                                                        ErrorMessage="Enter Description" ValidationGroup="v" Display="Dynamic"><img src="../../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>


                                                 <tr>
                                                <td class="frm-lft-clr123" valign="top">
                                                   Description New
                                                    <span style="color:Red">*</span>
                                                </td>
                                                <td class="frm-rght-clr123">
                                     <tool:FreeTextBox runat="server" ID="RichTextDesc" BackColor="Gray" BreakMode="LineBreak"
                        EnableHtmlMode="False" GutterBackColor="Gray" ToolbarImagesLocation="InternalResource" Width="100%"
                        ToolbarStyleConfiguration="Office2000"  Height="400px"></tool:FreeTextBox>      
                                                </td>
                                            </tr>


                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    &nbsp;
                                                </td>
                                                <td class="frm-rght-clr123" align="left">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="v"
                                                        OnClick="btnSave_Click" ToolTip="Click here to save news" />
                                                         <asp:Button ID="btnupdate" runat="server" CssClass="button" Text="Update" ValidationGroup="v"
                                                        ToolTip="Click here to update" Visible="false" onclick="btnupdate_Click" />
                                                    <asp:Button ID="btnclear" runat="server" CssClass="button" Text="Clear" OnClick="btnclear_Click"
                                                        ToolTip="Reset" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" height="20" valign="bottom">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="5">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="timesheetgrid" runat="server">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="head-2">
                            <asp:GridView ID="newsdetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="newsdetails_RowDataBound"
                                OnPageIndexChanging="newsdetails_PageIndexChanging" OnRowDeleting="newsdetails_RowDeleting"
                                OnRowCancelingEdit="newsdetails_RowCancelingEdit" OnRowEditing="newsdetails_RowEditing"
                                OnRowUpdating="newsdetails_RowUpdating" ToolTip="News Details" 
                                AllowPaging="True" onrowcommand="newsdetails_RowCommand">
                                <Columns>
                                 
                                    <asp:TemplateField HeaderText="Heading">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtheadingg" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "heading")%>'
                                                runat="server" Width="75px"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdescriptiong" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "description")%>'
                                                runat="server" Width="190px" Height="41px" TextMode="MultiLine"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemStyle Width="41%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                            
                                    <asp:TemplateField HeaderText="Added On">
                                        <ItemTemplate>
                                            <%# Eval("posteddate", "{0:dd MMM yyyy}")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                             <%# Eval("posteddate", "{0:dd MMM yyyy}")%>
                                        </EditItemTemplate>
                                        <ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                  
                                        <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Link_Update" CommandArgument='<%#bind("ID") %>'
                                                CssClass="link05" Text="Edit" ToolTip="Edit" />
                                            |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                </HeaderStyle>
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                <PagerStyle CssClass="frm-lft-clr123" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
