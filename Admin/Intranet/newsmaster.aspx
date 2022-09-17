<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Intranet/IntranetMasterWithoutLink.master"
    AutoEventWireup="true" CodeFile="newsmaster.aspx.cs" Inherits="intranet_newsmaster" %>

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
                                        Intranet News Master Form
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
                                                <td class="frm-lft-clr123" valign="middle">
                                                    Category
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="blue1" Width="190px"
                                                        Height="20px">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlcategory"
                                                        ErrorMessage="Select Category" Operator="NotEqual" ValidationGroup="v" ValueToCompare="---Select Category---"
                                                        Display="Dynamic"><img src="../../images/error1.gif" alt="*" /></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="22%" class="frm-lft-clr123" valign="middle">
                                                    Heading
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
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Height="68px" TextMode="MultiLine"
                                                        ToolTip="Enter Project Name" Width="188px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdescription"
                                                        ErrorMessage="Enter Description" ValidationGroup="v" Display="Dynamic"><img src="../../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
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
                                OnRowUpdating="newsdetails_RowUpdating" ToolTip="News Details" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "category")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlcategoryg" runat="server" CssClass="blue1" Width="75px"
                                                Height="20px" DataSourceID="SqlDataSource1" DataTextField="categoryname" DataValueField="categoryname"
                                                SelectedValue='<%#Bind("category")%>'>
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RossellConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct [categoryname] FROM [category]">
                                            </asp:SqlDataSource>
                                        </EditItemTemplate>
                                        <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
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
                                        <ItemStyle Width="29%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Run Status">
                                        <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "run_status")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlrunstatusg" runat="server" Width="75px" SelectedValue='<%#Bind("run_status1")%>'
                                                CssClass="blue1" Height="20px">
                                                <asp:ListItem Value="0">Running</asp:ListItem>
                                                <asp:ListItem Value="1">Stop</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority">
                                        <ItemStyle Width="9%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "priority")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="ddlpriorityg" runat="server" SelectedValue='<%#Bind("priority1")%>'
                                                Width="55px" CssClass="blue1" Height="20px">
                                                <asp:ListItem Value="0">Low</asp:ListItem>
                                                <asp:ListItem Value="1">Medium</asp:ListItem>
                                                <asp:ListItem Value="2">High</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Updated Date">
                                        <ItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                        </EditItemTemplate>
                                        <ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                            |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                        </EditItemTemplate>
                                        <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
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
