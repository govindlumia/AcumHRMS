<%@ Page Language="C#" AutoEventWireup="true" CodeFile="policydockit.aspx.cs" Inherits="intranet_policydockit"
    MasterPageFile="~/Admin/Intranet/IntranetMasterWithoutLink.master"
    Title="Policy Dockit" %>

<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
                <ProgressTemplate>
                    <div class="divajax">
                    <table width="100%">
                    <tr>
                    <td align="center" valign="top"><img src="../images/loading.gif" /></td>
                    </tr>
                    <tr>
                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                    </tr>
                    </table>
                    </div>
                </ProgressTemplate>
                </asp:UpdateProgress>   
    <div>--%>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                        </td>
                                        <td class="txt01">
                                            Policy Dockit Posting Form
                                        </td>
                                        <td align="right">
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25%" class="frm-lft-clr123">
                                            Subject
                                            <span style="color:Red">*</span>
                                        </td>
                                        <td width="75%" class="frm-rght-clr123">
                                            <asp:TextBox ID="txtsubject" runat="server" CssClass="blue1" Width="235px"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsubject" ErrorMessage="Subject"
                                                Display="Dynamic" ValidationGroup="v"><img src="../../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%" class="frm-lft-clr123" valign="top">
                                            Description
                                            <span style="color:Red">*</span>
                                        </td>
                                        <td width="75%" class="frm-rght-clr123">
                                            <asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Width="238px" Height="59px"
                                                TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdescription"
                                                Display="Dynamic" ErrorMessage="Description" ValidationGroup="v"><img src="../../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">
                                            Attach Document
                                            <span style="color:Red">*</span>
                                        </td>
                                        <td class="frm-rght-clr123">
                                            <asp:FileUpload ID="fupload" runat="server" CssClass="input2" ToolTip="Upload File here"
                                                Width="287px" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                                CssClass="txt-red" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$"
                                                ValidationGroup="v" Display="Dynamic"><img src="../../images/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="rfvupload" runat="server" ControlToValidate="fupload"
                                                Display="Dynamic" ErrorMessage="Attach Document" ToolTip="Attach Document" ValidationGroup="v"><img src="../../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                            <asp:Label ID="lbl_file" runat="server"></asp:Label>
                                            [Upload only .docx and .pdf file]
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
                                        <td class="frm-rght-clr123">
                                            <asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click"
                                                ValidationGroup="v" />&nbsp;
                                            <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click" />
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
                            <td height="5">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="head-2">
                                            <asp:GridView ID="griddetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                                DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="griddetails_RowDataBound"
                                                OnPageIndexChanging="griddetails_PageIndexChanging" OnRowDeleting="griddetails_RowDeleting"
                                                OnRowEditing="griddetails_RowEditing" ToolTip="Catalog Details" AllowPaging="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "type")%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Subject">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "subject")%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="22%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemStyle Width="35%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Attached Document">
                                                        <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "upload")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                            |
                                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                                CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                        </ItemTemplate>
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
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <%--</div>
                </ContentTemplate>
                </asp:UpdatePanel>--%>
    </div>
</asp:Content>
